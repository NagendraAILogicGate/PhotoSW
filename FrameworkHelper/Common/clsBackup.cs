using DigiPhoto.DataLayer;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using Ionic.Zip;
using Ionic.Zlib;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;


namespace FrameworkHelper.Common
{
	public class clsBackup
	{
		private static System.Collections.Hashtable htPhotoname = new System.Collections.Hashtable();

		private static System.Collections.Generic.Dictionary<int, System.DateTime> dicPhotoCreated = new System.Collections.Generic.Dictionary<int, System.DateTime>();

		private static DataTable dtPhotos = new DataTable();

		private static System.Collections.Hashtable _PhotosToDelete = new System.Collections.Hashtable();

		public static bool BackupDatabase(string databaseName, string userName, string password, string serverName, string destinationPath, ref int errorId)
		{
			bool flag = false;
			string text = string.Empty;
			bool isNetworkBackup = false;
			bool result;
			try
			{
				System.Console.WriteLine("Backup is being executed...");
				Backup backup = new Backup();
				backup.Action = BackupActionType.Database;
				backup.BackupSetDescription = "BackUp of:" + databaseName + "on" + System.DateTime.Now.ToShortDateString();
				backup.BackupSetName = "FullBackUp";
				backup.Database = databaseName;
				string text2 = databaseName + "_" + System.DateTime.Now.ToString("dd-MMM-yyyy-HH-mm-ss") + ".bak";
				if (clsBackup.IsBackupAvailable(destinationPath, databaseName))
				{
					System.Console.WriteLine("Backup already taken for today at : " + destinationPath);
					errorId = System.Convert.ToInt32(BackupErrorMessage.DatabaseBackupAlreadyExists);
					result = true;
					return result;
				}
				string localPath = new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath;
				text = System.IO.Path.GetDirectoryName(localPath) + "\\";
				BackupDeviceItem item = new BackupDeviceItem(text + text2, DeviceType.File);
				ServerConnection serverConnection = new ServerConnection(serverName, userName, password);
				Server server = new Server(serverConnection);
				server.ConnectionContext.StatementTimeout = 3600;
				Database database = server.Databases[databaseName];
				backup.Initialize = true;
				backup.Checksum = true;
				backup.ContinueAfterError = true;
				backup.Devices.Add(item);
				backup.Incremental = false;
				backup.ExpirationDate = System.DateTime.Now.AddDays(3.0);
				backup.LogTruncation = BackupTruncateLogType.Truncate;
				backup.FormatMedia = false;
				backup.SqlBackup(server);
				backup.Devices.Remove(item);
				string str = clsBackup.SaveBackUp(destinationPath, ref flag, text, isNetworkBackup, text2, ref errorId);
				if (errorId != 1)
				{
					System.Console.WriteLine("Backup successfully taken at: " + str);
				}
				System.Console.WriteLine("Press any key to exit...");
			}
			catch (System.Exception ex)
			{
				throw new System.Exception("Backup operation could not be executed. Error: " + ex.Message);
			}
			result = flag;
			return result;
		}

		private static string SaveBackUp(string destinationPath, ref bool IsBackupSuccess, string localPath, bool IsNetworkBackup, string bakfilename, ref int errorId)
		{
			string result;
			try
			{
				long num = 0L;
				string text = System.IO.Path.Combine(destinationPath, System.IO.Path.GetFileNameWithoutExtension(bakfilename) + ".zip");
				string text2 = System.IO.Path.Combine(localPath, bakfilename);
				if (System.IO.File.Exists(text2))
				{
					clsBackup.DriveFreeBytes(destinationPath, out num);
					System.IO.FileInfo fileInfo = new System.IO.FileInfo(text2);
					if (num > fileInfo.Length)
					{
						using (ZipFile zipFile = new ZipFile())
						{
							zipFile.AddFile(System.IO.Path.Combine(new string[]
							{
								text2
							}), "");
							zipFile.UseZip64WhenSaving = Zip64Option.Always;
							zipFile.Save(text);
							IsBackupSuccess = true;
						}
						System.IO.File.Delete(text2);
						result = text;
						return result;
					}
					errorId = 1;
					IsBackupSuccess = false;
				}
			}
			catch
			{
				IsBackupSuccess = false;
			}
			result = string.Empty;
			return result;
		}

		private static bool IsBackupAvailable(string destinationPath, string dataBaseName)
		{
			bool result;
			try
			{
				System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(destinationPath);
				System.IO.FileInfo[] files = directoryInfo.GetFiles("*.zip");
				int num = 0;
				if (num >= files.Length)
				{
					result = false;
				}
				else
				{
					System.IO.FileInfo fileInfo = files[num];
					if (fileInfo.CreationTime.Date == System.DateTime.Today && fileInfo.Name.Contains(dataBaseName + "_" + System.DateTime.Now.ToString("dd-MMM-yyyy")))
					{
						result = true;
					}
					else
					{
						result = false;
					}
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public static bool EmptyTables(string heavytables, int _cleanupdaysBackup, int oldCleanUpDays, int subStoreId, int _FailedOnlineOrderCleanupdays)
		{
			bool result;
			try
			{
				string connectionString = ConfigurationManager.ConnectionStrings["DigiConnectionString"].ConnectionString;
				int commandTimeout;
				if (ConfigurationManager.AppSettings["SQLCommandTimeOut"] != null)
				{
					commandTimeout = System.Convert.ToInt32(ConfigurationManager.AppSettings["SQLCommandTimeOut"]);
				}
				else
				{
					commandTimeout = 300;
				}
				if (!string.IsNullOrEmpty(heavytables))
				{
					using (SqlConnection sqlConnection = new SqlConnection(connectionString))
					{
						using (SqlCommand sqlCommand = new SqlCommand("DG_TableCleanup", sqlConnection))
						{
							sqlCommand.CommandTimeout = commandTimeout;
							sqlCommand.CommandType = CommandType.StoredProcedure;
							sqlCommand.Parameters.Add("@tables", SqlDbType.VarChar).Value = heavytables;
							sqlCommand.Parameters.Add("@BackUpDays", SqlDbType.Int).Value = _cleanupdaysBackup;
							sqlCommand.Parameters.Add("@OldCleanUpDays", SqlDbType.Int).Value = oldCleanUpDays;
							sqlCommand.Parameters.Add("@SubStoreId", SqlDbType.Int).Value = subStoreId;
							sqlCommand.Parameters.Add("@FaliledOnlineOrderCleanupdays", SqlDbType.Int).Value = _FailedOnlineOrderCleanupdays;
							sqlConnection.Open();
							sqlCommand.ExecuteNonQuery();
						}
					}
				}
				result = true;
			}
			catch (System.Exception var_5_15A)
			{
				throw;
			}
			return result;
		}

		public static bool BackupCompress(string strSource, string strDestination)
		{
			bool result;
			try
			{
				string text = System.IO.Path.GetFileNameWithoutExtension(strSource);
				text = ((!string.IsNullOrEmpty(text)) ? text : "HotFolderBackup");
				string fileName = string.Concat(new string[]
				{
					strDestination,
					text,
					"_",
					System.DateTime.Now.ToString("dd-MMM-yyyy-HH-mm-ss"),
					".zip"
				});
				using (ZipFile zipFile = new ZipFile())
				{
					zipFile.AddDirectory(strSource, text);
					zipFile.UseZip64WhenSaving = Zip64Option.Always;
					zipFile.CompressionLevel = CompressionLevel.BestCompression;
					zipFile.BufferSize = 524288;
					zipFile.Save(fileName);
				}
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public static string CreateBackupFolderExits(string strSource, string strDestination)
		{
			string result;
			try
			{
				string text = System.IO.Path.GetFileNameWithoutExtension(strSource);
				text = ((!string.IsNullOrEmpty(text)) ? text : "HotFolderBackup");
				string text2 = strDestination + text + "_" + System.DateTime.Now.ToString("dd-MMM-yyyy");
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
				}
				result = text2;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		public static string CreateBackupFolderExits(string strDestination)
		{
			string result;
			try
			{
				string text = strDestination + "HotFolderBackup_" + System.DateTime.Now.ToString("dd-MMM-yyyy");
				if (!System.IO.Directory.Exists(text))
				{
					System.IO.Directory.CreateDirectory(text);
				}
				result = text;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		public static bool UpdateArchivedPhotoDetails()
		{
			bool result;
			try
			{
				string connectionString = ConfigurationManager.ConnectionStrings["DigiConnectionString"].ConnectionString;
				if (clsBackup.dtPhotos.Rows.Count > 0)
				{
					using (SqlConnection sqlConnection = new SqlConnection(connectionString))
					{
						using (SqlCommand sqlCommand = new SqlCommand("UpdateArchivedPhotoDetails", sqlConnection))
						{
							sqlCommand.CommandType = CommandType.StoredProcedure;
							sqlCommand.Parameters.Add("@ArchivedPhotoDetails", clsBackup.dtPhotos);
							sqlConnection.Open();
							sqlCommand.ExecuteNonQuery();
						}
					}
				}
				bool flag = true;
				result = flag;
			}
			catch
			{
				throw;
			}
			return result;
		}

		public static int CopyDirectoryFiles(string destinationFld, string clrDirectoryPath)
		{
			int num = 0;
			System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
			int result;
			try
			{
				hashtable.Add(1, "Croped");
				hashtable.Add(2, "Download");
				hashtable.Add(3, "PendingItems");
				hashtable.Add(4, "PrintImages");
				hashtable.Add(5, "Thumbnails");
				hashtable.Add(6, "Thumbnails//Temp");
				hashtable.Add(7, "Thumbnails_Big");
				hashtable.Add(8, "");
				hashtable.Add(9, "EditedImages");
				hashtable.Add(10, "Videos");
				hashtable.Add(11, "ProcessedVideos");
				foreach (int num2 in clsBackup.htPhotoname.Keys)
				{
					try
					{
						bool flag = false;
						bool flag2 = false;
						string text = string.Empty;
						ArchivedPhotoInfo archivedPhotoInfo = (ArchivedPhotoInfo)clsBackup.htPhotoname[num2];
						string text2 = archivedPhotoInfo.FileName;
						int mediaType = archivedPhotoInfo.MediaType;
						foreach (string text3 in hashtable.Values)
						{
							if (text3.Equals("Videos") && mediaType == 2)
							{
								text = "Videos\\" + clsBackup.dicPhotoCreated[num2].ToString("yyyyMMdd");
							}
							else if (text3.Equals("ProcessedVideos") && mediaType == 3)
							{
								text = "ProcessedVideos\\" + clsBackup.dicPhotoCreated[num2].ToString("yyyyMMdd");
							}
							else if (text3 == "")
							{
								text = clsBackup.dicPhotoCreated[num2].ToString("yyyyMMdd");
							}
							else if (text3.Equals("Thumbnails", System.StringComparison.OrdinalIgnoreCase))
							{
								text = "Thumbnails\\" + clsBackup.dicPhotoCreated[num2].ToString("yyyyMMdd");
							}
							else if (text3.Equals("Thumbnails_Big", System.StringComparison.OrdinalIgnoreCase))
							{
								text = "Thumbnails_Big\\" + clsBackup.dicPhotoCreated[num2].ToString("yyyyMMdd");
							}
							else if (text3.Equals("Videos", System.StringComparison.OrdinalIgnoreCase))
							{
								text = "Videos\\" + clsBackup.dicPhotoCreated[num2].ToString("yyyyMMdd");
							}
							else
							{
								text = text3;
							}
							if (text3 == "" || text3.Contains("Videos") || text3.Contains("ProcessedVideos"))
							{
								if (!System.IO.Directory.Exists(destinationFld + "\\" + text))
								{
									System.IO.Directory.CreateDirectory(destinationFld + "\\" + text);
								}
							}
							else
							{
								flag = true;
							}
							if (mediaType != 1 && text3 == "Thumbnails")
							{
								text2 = System.IO.Path.GetFileNameWithoutExtension(text2);
								text2 += ".jpg";
							}
							if (System.IO.Directory.Exists(destinationFld + "\\" + text))
							{
								if (System.IO.File.Exists(clrDirectoryPath + text + "\\" + text2))
								{
									try
									{
										System.IO.File.Copy(clrDirectoryPath + text + "\\" + text2, string.Concat(new string[]
										{
											destinationFld,
											"\\",
											text,
											"\\",
											text2
										}), true);
										flag = true;
									}
									catch
									{
										flag = false;
									}
								}
								else if (System.IO.File.Exists(clrDirectoryPath + text + "\\tmp" + text2))
								{
									try
									{
										System.IO.File.Copy(clrDirectoryPath + text + "\\tmp" + text2, string.Concat(new string[]
										{
											destinationFld,
											"\\",
											text,
											"\\tmp",
											text2
										}), true);
										flag = true;
									}
									catch
									{
										flag = false;
									}
								}
								if (mediaType == 1)
								{
									if (System.IO.File.Exists(clrDirectoryPath + text + "\\" + text2.Replace(".jpg", ".png")))
									{
										try
										{
											System.IO.File.Copy(clrDirectoryPath + text + "\\" + text2.Replace(".jpg", ".png"), string.Concat(new string[]
											{
												destinationFld,
												"\\",
												text,
												"\\",
												text2.Replace(".jpg", ".png")
											}), true);
											flag = true;
										}
										catch
										{
											flag = false;
										}
									}
								}
							}
							if (flag)
							{
								try
								{
									if (System.IO.File.Exists(clrDirectoryPath + text + "\\" + text2))
									{
										try
										{
											System.IO.File.Delete(clrDirectoryPath + text + "\\" + text2);
											flag2 = true;
										}
										catch
										{
											flag2 = false;
										}
									}
									else if (System.IO.File.Exists(clrDirectoryPath + text + "\\tmp" + text2))
									{
										try
										{
											System.IO.File.Delete(clrDirectoryPath + text + "\\tmp" + text2);
											flag2 = true;
										}
										catch
										{
											flag2 = false;
										}
									}
									if (mediaType == 1)
									{
										if (System.IO.File.Exists(clrDirectoryPath + text + "\\" + text2.Replace(".jpg", ".png")))
										{
											try
											{
												System.IO.File.Delete(clrDirectoryPath + text + "\\" + text2.Replace(".jpg", ".png"));
												flag2 = true;
											}
											catch
											{
												flag2 = false;
											}
										}
									}
									try
									{
										if (text3 == "")
										{
											string[] files = System.IO.Directory.GetFiles(clrDirectoryPath + text + "\\");
											if (files.Length == 0)
											{
												System.IO.Directory.Delete(clrDirectoryPath + text + "\\");
											}
										}
									}
									catch (System.Exception serviceException)
									{
										string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
										ErrorHandler.ErrorHandler.LogFileWrite(message);
										string[] files = System.IO.Directory.GetFiles(clrDirectoryPath + text + "\\");
										if (files.Length == 0)
										{
											System.IO.Directory.Delete(clrDirectoryPath + text + "\\");
										}
									}
								}
								catch
								{
								}
							}
						}
						if (flag2)
						{
							try
							{
								DataRow[] array = clsBackup.dtPhotos.Select("ArchivedPhotoId =" + num2);
								DataRow[] array2 = array;
								for (int i = 0; i < array2.Length; i++)
								{
									DataRow dataRow = array2[i];
									dataRow["FileDeleted"] = 1;
									dataRow["FileDeletedOn"] = System.DateTime.Now.ToString();
								}
							}
							catch (System.Exception serviceException)
							{
								string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
								ErrorHandler.ErrorHandler.LogFileWrite(message);
							}
						}
						else
						{
							DataRow[] array = clsBackup.dtPhotos.Select("ArchivedPhotoId =" + num2);
							DataRow[] array2 = array;
							for (int i = 0; i < array2.Length; i++)
							{
								DataRow dataRow = array2[i];
								dataRow["FileDeleted"] = 1;
							}
						}
						num++;
					}
					catch (System.Exception var_15_832)
					{
						throw;
					}
				}
				result = num;
			}
			catch
			{
				throw;
			}
			return result;
		}

		public static int GetPhotoArchived(int subStoreId)
		{
			int num = 0;
			int result;
			try
			{
				if (!clsBackup.dtPhotos.Columns.Contains("ArchivedPhotoId"))
				{
					clsBackup.dtPhotos.Columns.Add("ArchivedPhotoId", typeof(long));
				}
				if (!clsBackup.dtPhotos.Columns.Contains("FileDeleted"))
				{
					clsBackup.dtPhotos.Columns.Add("FileDeleted", typeof(bool));
				}
				if (!clsBackup.dtPhotos.Columns.Contains("FileDeletedOn"))
				{
					clsBackup.dtPhotos.Columns.Add("FileDeletedOn", typeof(System.DateTime));
				}
				clsBackup.htPhotoname.Clear();
				clsBackup.dtPhotos.Clear();
				clsBackup.dicPhotoCreated.Clear();
				string connectionString = ConfigurationManager.ConnectionStrings["DigiConnectionString"].ConnectionString;
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					using (SqlCommand sqlCommand = new SqlCommand("dbo.GetArchivedPhotoName", sqlConnection))
					{
						sqlCommand.CommandType = CommandType.StoredProcedure;
						sqlCommand.Parameters.Add("@SubStoreId", SqlDbType.Int).Value = subStoreId;
						sqlConnection.Open();
						using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
						{
							if (sqlDataReader.HasRows)
							{
								while (sqlDataReader.Read())
								{
									string fileName = sqlDataReader["DG_Photos_FileName"].ToString();
									int num2 = System.Convert.ToInt32(sqlDataReader["ArchivedPhotoId"]);
									int mediaType = System.Convert.ToInt32(sqlDataReader["DG_MediaType"]);
									System.DateTime value = System.Convert.ToDateTime(sqlDataReader["DG_Photos_CreatedOn"]);
									bool flag = System.Convert.ToBoolean(sqlDataReader["FileDeleted"]);
									if (!clsBackup.htPhotoname.ContainsKey(num2))
									{
										clsBackup.htPhotoname.Add(num2, new ArchivedPhotoInfo
										{
											FileName = fileName,
											MediaType = mediaType,
											ArchivedPhotoId = num2,
											FileDeleted = flag
										});
										clsBackup.dicPhotoCreated.Add(System.Convert.ToInt32(num2), value);
										DataRow dataRow = clsBackup.dtPhotos.NewRow();
										dataRow["ArchivedPhotoId"] = num2;
										dataRow["FileDeleted"] = flag;
										clsBackup.dtPhotos.Rows.Add(dataRow);
										num++;
									}
								}
							}
						}
					}
				}
				result = num;
			}
			catch
			{
				throw;
			}
			return result;
		}

		public static int GetPhotosToDelete(int subStoreId)
		{
			int num = 0;
			int result;
			try
			{
				clsBackup._PhotosToDelete.Clear();
				string connectionString = ConfigurationManager.ConnectionStrings["DigiConnectionString"].ConnectionString;
				using (SqlConnection sqlConnection = new SqlConnection(connectionString))
				{
					using (SqlCommand sqlCommand = new SqlCommand("dbo.usp_GET_PhotosToDelete", sqlConnection))
					{
						sqlCommand.CommandType = CommandType.StoredProcedure;
						sqlCommand.Parameters.Add("@SubStoreId", SqlDbType.Int).Value = subStoreId;
						sqlConnection.Open();
						using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader(CommandBehavior.CloseConnection))
						{
							if (sqlDataReader.HasRows)
							{
								while (sqlDataReader.Read())
								{
									string key = sqlDataReader["DG_Photos_FileName"].ToString();
									System.DateTime dateTime = System.Convert.ToDateTime(sqlDataReader["DG_Photos_CreatedOn"]);
									clsBackup._PhotosToDelete.Add(key, dateTime);
									num++;
								}
							}
						}
					}
				}
				result = num;
			}
			catch
			{
				throw;
			}
			return result;
		}

		public static bool IsMemoryAvailable(string sourcePath, string destinationPath, int subStoreID)
		{
			long num = 0L;
			long num2 = 0L;
			bool result;
			try
			{
				clsBackup.DriveFreeBytes(destinationPath, out num);
				long num3 = num / 1073741824L;
				clsBackup.GetPhotosToDelete(subStoreID);
				System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(sourcePath);
				System.Collections.Generic.List<System.IO.FileInfo> list = (from x in directoryInfo.GetFiles("*.jpg", System.IO.SearchOption.AllDirectories)
				where clsBackup._PhotosToDelete.ContainsKey(x.Name)
				select x).ToList<System.IO.FileInfo>();
				foreach (System.IO.FileInfo current in list)
				{
					num2 += current.Length;
				}
				if ((double)num > (double)num2 + 2684354560.0)
				{
					result = true;
					return result;
				}
				result = false;
				return result;
			}
			catch (System.Exception ex)
			{
				System.Console.WriteLine(ex.Message);
			}
			result = true;
			return result;
		}

		[System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
		public static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out long lpFreeBytesAvailable, out long lpTotalNumberOfBytes, out long lpTotalNumberOfFreeBytes);

		public static bool DriveFreeBytes(string folderName, out long freespace)
		{
			freespace = 0L;
			if (string.IsNullOrEmpty(folderName))
			{
				throw new System.ArgumentNullException("folderName");
			}
			if (!folderName.EndsWith("\\"))
			{
				folderName += '\\';
			}
			long num = 0L;
			long num2 = 0L;
			long num3 = 0L;
			bool result;
			if (clsBackup.GetDiskFreeSpaceEx(folderName, out num, out num2, out num3))
			{
				freespace = num;
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}
	}
}
