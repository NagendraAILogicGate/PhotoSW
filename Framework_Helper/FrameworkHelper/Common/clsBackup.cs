namespace FrameworkHelper.Common
{
    using DigiPhoto.DataLayer;
    using DigiPhoto.IMIX.Model;
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

    public class clsBackup
    {
        private static Hashtable _PhotosToDelete = new Hashtable();
        private static Dictionary<int, DateTime> dicPhotoCreated = new Dictionary<int, DateTime>();
        private static DataTable dtPhotos = new DataTable();
        private static Hashtable htPhotoname = new Hashtable();

        public static bool BackupCompress(string strSource, string strDestination)
        {
            try
            {
                string fileNameWithoutExtension = "";
                fileNameWithoutExtension = Path.GetFileNameWithoutExtension(strSource);
                fileNameWithoutExtension = !string.IsNullOrEmpty(fileNameWithoutExtension) ? fileNameWithoutExtension : "HotFolderBackup";
                string fileName = strDestination + fileNameWithoutExtension + "_" + DateTime.Now.ToString("dd-MMM-yyyy-HH-mm-ss") + ".zip";
                using (ZipFile file = new ZipFile())
                {
                    file.AddDirectory(strSource, fileNameWithoutExtension);
                    file.UseZip64WhenSaving = Zip64Option.Always;
                    file.CompressionLevel = CompressionLevel.BestCompression;
                    file.BufferSize = 0x80000;
                    file.Save(fileName);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool BackupDatabase(string databaseName, string userName, string password, string serverName, string destinationPath, ref int errorId)
        {
            bool isBackupSuccess = false;
            string localPath = string.Empty;
            bool isNetworkBackup = false;
            try
            {
                Console.WriteLine("Backup is being executed...");
                Backup backup = new Backup {
                    Action = BackupActionType.Database,
                    BackupSetDescription = "BackUp of:" + databaseName + "on" + DateTime.Now.ToShortDateString(),
                    BackupSetName = "FullBackUp",
                    Database = databaseName
                };
                string bakfilename = databaseName + "_" + DateTime.Now.ToString("dd-MMM-yyyy-HH-mm-ss") + ".bak";
                if (!IsBackupAvailable(destinationPath, databaseName))
                {
                    localPath = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath) + @"\";
                }
                else
                {
                    Console.WriteLine("Backup already taken for today at : " + destinationPath);
                    errorId = Convert.ToInt32(BackupErrorMessage.DatabaseBackupAlreadyExists);
                    return true;
                }
                BackupDeviceItem item = new BackupDeviceItem(localPath + bakfilename, DeviceType.File);
                ServerConnection serverConnection = new ServerConnection(serverName, userName, password);
                Server srv = new Server(serverConnection) {
                    ConnectionContext = { StatementTimeout = 0xe10 }
                };
                Database database = srv.Databases[databaseName];
                backup.Initialize = true;
                backup.Checksum = true;
                backup.ContinueAfterError = true;
                backup.Devices.Add(item);
                backup.Incremental = false;
                backup.ExpirationDate = DateTime.Now.AddDays(3.0);
                backup.LogTruncation = BackupTruncateLogType.Truncate;
                backup.FormatMedia = false;
                backup.SqlBackup(srv);
                backup.Devices.Remove(item);
                string str4 = SaveBackUp(destinationPath, ref isBackupSuccess, localPath, isNetworkBackup, bakfilename, ref errorId);
                if (errorId != 1)
                {
                    Console.WriteLine("Backup successfully taken at: " + str4);
                }
                Console.WriteLine("Press any key to exit...");
            }
            catch (Exception exception)
            {
                throw new Exception("Backup operation could not be executed. Error: " + exception.Message);
            }
            return isBackupSuccess;
        }

        public static int CopyDirectoryFiles(string destinationFld, string clrDirectoryPath)
        {
            int num4;
            int num = 0;
            Hashtable hashtable = new Hashtable();
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
                foreach (int num2 in htPhotoname.Keys)
                {
                    try
                    {
                        Exception exception;
                        DataRow[] rowArray;
                        bool flag = false;
                        bool flag2 = false;
                        string str = string.Empty;
                        ArchivedPhotoInfo info = (ArchivedPhotoInfo) htPhotoname[num2];
                        string fileName = info.FileName;
                        int mediaType = info.MediaType;
                        foreach (string str3 in hashtable.Values)
                        {
                            DateTime time;
                            if (str3.Equals("Videos") && (mediaType == 2))
                            {
                                time = dicPhotoCreated[num2];
                                str = @"Videos\" + time.ToString("yyyyMMdd");
                            }
                            else if (str3.Equals("ProcessedVideos") && (mediaType == 3))
                            {
                                time = dicPhotoCreated[num2];
                                str = @"ProcessedVideos\" + time.ToString("yyyyMMdd");
                            }
                            else if (str3 == "")
                            {
                                time = dicPhotoCreated[num2];
                                str = time.ToString("yyyyMMdd");
                            }
                            else if (str3.Equals("Thumbnails", StringComparison.OrdinalIgnoreCase))
                            {
                                time = dicPhotoCreated[num2];
                                str = @"Thumbnails\" + time.ToString("yyyyMMdd");
                            }
                            else if (str3.Equals("Thumbnails_Big", StringComparison.OrdinalIgnoreCase))
                            {
                                time = dicPhotoCreated[num2];
                                str = @"Thumbnails_Big\" + time.ToString("yyyyMMdd");
                            }
                            else if (str3.Equals("Videos", StringComparison.OrdinalIgnoreCase))
                            {
                                str = @"Videos\" + dicPhotoCreated[num2].ToString("yyyyMMdd");
                            }
                            else
                            {
                                str = str3;
                            }
                            if (((str3 == "") || str3.Contains("Videos")) || str3.Contains("ProcessedVideos"))
                            {
                                if (!Directory.Exists(destinationFld + @"\" + str))
                                {
                                    Directory.CreateDirectory(destinationFld + @"\" + str);
                                }
                            }
                            else
                            {
                                flag = true;
                            }
                            if ((mediaType != 1) && (str3 == "Thumbnails"))
                            {
                                fileName = Path.GetFileNameWithoutExtension(fileName) + ".jpg";
                            }
                            if (Directory.Exists(destinationFld + @"\" + str))
                            {
                                if (File.Exists(clrDirectoryPath + str + @"\" + fileName))
                                {
                                    try
                                    {
                                        File.Copy(clrDirectoryPath + str + @"\" + fileName, destinationFld + @"\" + str + @"\" + fileName, true);
                                        flag = true;
                                    }
                                    catch
                                    {
                                        flag = false;
                                    }
                                }
                                else if (File.Exists(clrDirectoryPath + str + @"\tmp" + fileName))
                                {
                                    try
                                    {
                                        File.Copy(clrDirectoryPath + str + @"\tmp" + fileName, destinationFld + @"\" + str + @"\tmp" + fileName, true);
                                        flag = true;
                                    }
                                    catch
                                    {
                                        flag = false;
                                    }
                                }
                                if ((mediaType == 1) && File.Exists(clrDirectoryPath + str + @"\" + fileName.Replace(".jpg", ".png")))
                                {
                                    try
                                    {
                                        File.Copy(clrDirectoryPath + str + @"\" + fileName.Replace(".jpg", ".png"), destinationFld + @"\" + str + @"\" + fileName.Replace(".jpg", ".png"), true);
                                        flag = true;
                                    }
                                    catch
                                    {
                                        flag = false;
                                    }
                                }
                            }
                            if (flag)
                            {
                                try
                                {
                                    if (File.Exists(clrDirectoryPath + str + @"\" + fileName))
                                    {
                                        try
                                        {
                                            File.Delete(clrDirectoryPath + str + @"\" + fileName);
                                            flag2 = true;
                                        }
                                        catch
                                        {
                                            flag2 = false;
                                        }
                                    }
                                    else if (File.Exists(clrDirectoryPath + str + @"\tmp" + fileName))
                                    {
                                        try
                                        {
                                            File.Delete(clrDirectoryPath + str + @"\tmp" + fileName);
                                            flag2 = true;
                                        }
                                        catch
                                        {
                                            flag2 = false;
                                        }
                                    }
                                    if ((mediaType == 1) && File.Exists(clrDirectoryPath + str + @"\" + fileName.Replace(".jpg", ".png")))
                                    {
                                        try
                                        {
                                            File.Delete(clrDirectoryPath + str + @"\" + fileName.Replace(".jpg", ".png"));
                                            flag2 = true;
                                        }
                                        catch
                                        {
                                            flag2 = false;
                                        }
                                    }
                                    try
                                    {
                                        if ((str3 == "") && (Directory.GetFiles(clrDirectoryPath + str + @"\").Length == 0))
                                        {
                                            Directory.Delete(clrDirectoryPath + str + @"\");
                                        }
                                    }
                                    catch (Exception exception1)
                                    {
                                        exception = exception1;
                                        ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                                        if (Directory.GetFiles(clrDirectoryPath + str + @"\").Length == 0)
                                        {
                                            Directory.Delete(clrDirectoryPath + str + @"\");
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
                                rowArray = dtPhotos.Select("ArchivedPhotoId =" + num2);
                                foreach (DataRow row in rowArray)
                                {
                                    row["FileDeleted"] = 1;
                                    row["FileDeletedOn"] = DateTime.Now.ToString();
                                }
                            }
                            catch (Exception exception3)
                            {
                                exception = exception3;
                                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                            }
                        }
                        else
                        {
                            rowArray = dtPhotos.Select("ArchivedPhotoId =" + num2);
                            foreach (DataRow row in rowArray)
                            {
                                row["FileDeleted"] = 1;
                            }
                        }
                        num++;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
                num4 = num;
            }
            catch
            {
                throw;
            }
            return num4;
        }

        public static string CreateBackupFolderExits(string strDestination)
        {
            try
            {
                string path = strDestination + "HotFolderBackup_" + DateTime.Now.ToString("dd-MMM-yyyy");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
            catch
            {
                return null;
            }
        }

        public static string CreateBackupFolderExits(string strSource, string strDestination)
        {
            try
            {
                string fileNameWithoutExtension = "";
                fileNameWithoutExtension = Path.GetFileNameWithoutExtension(strSource);
                fileNameWithoutExtension = !string.IsNullOrEmpty(fileNameWithoutExtension) ? fileNameWithoutExtension : "HotFolderBackup";
                string path = strDestination + fileNameWithoutExtension + "_" + DateTime.Now.ToString("dd-MMM-yyyy");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return path;
            }
            catch
            {
                return null;
            }
        }

        public static bool DriveFreeBytes(string folderName, out long freespace)
        {
            freespace = 0L;
            if (string.IsNullOrEmpty(folderName))
            {
                throw new ArgumentNullException("folderName");
            }
            if (!folderName.EndsWith(@"\"))
            {
                folderName = folderName + '\\';
            }
            long lpFreeBytesAvailable = 0L;
            long lpTotalNumberOfBytes = 0L;
            long lpTotalNumberOfFreeBytes = 0L;
            if (GetDiskFreeSpaceEx(folderName, out lpFreeBytesAvailable, out lpTotalNumberOfBytes, out lpTotalNumberOfFreeBytes))
            {
                freespace = lpFreeBytesAvailable;
                return true;
            }
            return false;
        }

        public static bool EmptyTables(string heavytables, int _cleanupdaysBackup, int oldCleanUpDays, int subStoreId, int _FailedOnlineOrderCleanupdays)
        {
            bool flag;
            try
            {
                int num;
                string connectionString = ConfigurationManager.ConnectionStrings["DigiConnectionString"].ConnectionString;
                if (ConfigurationManager.AppSettings["SQLCommandTimeOut"] != null)
                {
                    num = Convert.ToInt32(ConfigurationManager.AppSettings["SQLCommandTimeOut"]);
                }
                else
                {
                    num = 300;
                }
                if (!string.IsNullOrEmpty(heavytables))
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand("DG_TableCleanup", connection))
                        {
                            command.CommandTimeout = num;
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@tables", SqlDbType.VarChar).Value = heavytables;
                            command.Parameters.Add("@BackUpDays", SqlDbType.Int).Value = _cleanupdaysBackup;
                            command.Parameters.Add("@OldCleanUpDays", SqlDbType.Int).Value = oldCleanUpDays;
                            command.Parameters.Add("@SubStoreId", SqlDbType.Int).Value = subStoreId;
                            command.Parameters.Add("@FaliledOnlineOrderCleanupdays", SqlDbType.Int).Value = _FailedOnlineOrderCleanupdays;
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                }
                flag = true;
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", CharSet=CharSet.Auto, SetLastError=true)]
        public static extern bool GetDiskFreeSpaceEx(string lpDirectoryName, out long lpFreeBytesAvailable, out long lpTotalNumberOfBytes, out long lpTotalNumberOfFreeBytes);
        public static int GetPhotoArchived(int subStoreId)
        {
            int num4;
            int num = 0;
            try
            {
                if (!dtPhotos.Columns.Contains("ArchivedPhotoId"))
                {
                    dtPhotos.Columns.Add("ArchivedPhotoId", typeof(long));
                }
                if (!dtPhotos.Columns.Contains("FileDeleted"))
                {
                    dtPhotos.Columns.Add("FileDeleted", typeof(bool));
                }
                if (!dtPhotos.Columns.Contains("FileDeletedOn"))
                {
                    dtPhotos.Columns.Add("FileDeletedOn", typeof(DateTime));
                }
                htPhotoname.Clear();
                dtPhotos.Clear();
                dicPhotoCreated.Clear();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DigiConnectionString"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("dbo.GetArchivedPhotoName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@SubStoreId", SqlDbType.Int).Value = subStoreId;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string str2 = reader["DG_Photos_FileName"].ToString();
                                    int key = Convert.ToInt32(reader["ArchivedPhotoId"]);
                                    int num3 = Convert.ToInt32(reader["DG_MediaType"]);
                                    DateTime time = Convert.ToDateTime(reader["DG_Photos_CreatedOn"]);
                                    bool flag = Convert.ToBoolean(reader["FileDeleted"]);
                                    if (!htPhotoname.ContainsKey(key))
                                    {
                                        ArchivedPhotoInfo info = new ArchivedPhotoInfo {
                                            FileName = str2,
                                            MediaType = num3,
                                            ArchivedPhotoId = key,
                                            FileDeleted = flag
                                        };
                                        htPhotoname.Add(key, info);
                                        dicPhotoCreated.Add(Convert.ToInt32(key), time);
                                        DataRow row = dtPhotos.NewRow();
                                        row["ArchivedPhotoId"] = key;
                                        row["FileDeleted"] = flag;
                                        dtPhotos.Rows.Add(row);
                                        num++;
                                    }
                                }
                            }
                        }
                    }
                }
                num4 = num;
            }
            catch
            {
                throw;
            }
            return num4;
        }

        public static int GetPhotosToDelete(int subStoreId)
        {
            int num2;
            int num = 0;
            try
            {
                _PhotosToDelete.Clear();
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DigiConnectionString"].ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("dbo.usp_GET_PhotosToDelete", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.Add("@SubStoreId", SqlDbType.Int).Value = subStoreId;
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection))
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    string key = reader["DG_Photos_FileName"].ToString();
                                    DateTime time = Convert.ToDateTime(reader["DG_Photos_CreatedOn"]);
                                    _PhotosToDelete.Add(key, time);
                                    num++;
                                }
                            }
                        }
                    }
                }
                num2 = num;
            }
            catch
            {
                throw;
            }
            return num2;
        }

        private static bool IsBackupAvailable(string destinationPath, string dataBaseName)
        {
            try
            {
                FileInfo[] files = new DirectoryInfo(destinationPath).GetFiles("*.zip");
                int index = 0;
                while (index < files.Length)
                {
                    FileInfo info2 = files[index];
                    return ((info2.CreationTime.Date == DateTime.Today) && info2.Name.Contains(dataBaseName + "_" + DateTime.Now.ToString("dd-MMM-yyyy")));
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsMemoryAvailable(string sourcePath, string destinationPath, int subStoreID)
        {
            long freespace = 0L;
            long num2 = 0L;
            try
            {
                DriveFreeBytes(destinationPath, out freespace);
                long num3 = freespace / 0x40000000L;
                GetPhotosToDelete(subStoreID);
                DirectoryInfo info = new DirectoryInfo(sourcePath);
                List<FileInfo> list = (from x in info.GetFiles("*.jpg", SearchOption.AllDirectories)
                    where _PhotosToDelete.ContainsKey(x.Name)
                    select x).ToList<FileInfo>();
                foreach (FileInfo info2 in list)
                {
                    num2 += info2.Length;
                }
                return (freespace > (num2 + 2684354560));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
            return true;
        }

        private static string SaveBackUp(string destinationPath, ref bool IsBackupSuccess, string localPath, bool IsNetworkBackup, string bakfilename, ref int errorId)
        {
            try
            {
                long freespace = 0L;
                string fileName = Path.Combine(destinationPath, Path.GetFileNameWithoutExtension(bakfilename) + ".zip");
                string path = Path.Combine(localPath, bakfilename);
                if (File.Exists(path))
                {
                    DriveFreeBytes(destinationPath, out freespace);
                    FileInfo info = new FileInfo(path);
                    if (freespace > info.Length)
                    {
                        using (ZipFile file = new ZipFile())
                        {
                            file.AddFile(Path.Combine(new string[] { path }), "");
                            file.UseZip64WhenSaving = Zip64Option.Always;
                            file.Save(fileName);
                            IsBackupSuccess = true;
                        }
                        File.Delete(path);
                        return fileName;
                    }
                    errorId = 1;
                    IsBackupSuccess = false;
                }
            }
            catch
            {
                IsBackupSuccess = false;
            }
            return string.Empty;
        }

        public static bool UpdateArchivedPhotoDetails()
        {
            bool flag2;
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DigiConnectionString"].ConnectionString;
                if (dtPhotos.Rows.Count > 0)
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        using (SqlCommand command = new SqlCommand("UpdateArchivedPhotoDetails", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.Add("@ArchivedPhotoDetails", dtPhotos);
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                }
                flag2 = true;
            }
            catch
            {
                throw;
            }
            return flag2;
        }
    }
}

