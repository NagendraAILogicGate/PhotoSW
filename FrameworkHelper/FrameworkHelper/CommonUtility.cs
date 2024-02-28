using PhotoSW.IMIX.Model;
using ErrorHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace FrameworkHelper
{
	public class CommonUtility
	{
		private static volatile object _object = new object();

		public static int GetRandomNumber(int maxNumber)
		{
			if (maxNumber < 1)
			{
				throw new System.Exception("The maxNumber value should be greater than 1");
			}
			byte[] array = new byte[4];
			new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(array);
			int seed = (int)(array[0] & 127) << 24 | (int)array[1] << 16 | (int)array[2] << 8 | (int)array[3];
			System.Random random = new System.Random(seed);
			return random.Next(1, maxNumber);
		}

		public static string GetRandomString(int length)
		{
			string[] array = new string[]
			{
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"8",
				"9",
				"A",
				"B",
				"C",
				"D",
				"E",
				"F",
				"G",
				"H",
				"J",
				"K",
				"L",
				"M",
				"N",
				"P",
				"R",
				"S",
				"T",
				"U",
				"V",
				"W",
				"X",
				"Y",
				"Z"
			};
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			for (int i = 0; i < length; i++)
			{
				stringBuilder.Append(array[CommonUtility.GetRandomNumber(32)]);
			}
			return stringBuilder.ToString();
		}

		public static string GetUniqueSynccode(string ApplicationObject, string countryCode, string storeCode, string subStoreid)
		{
			string text = string.Format("{0:yyyyMMdd}", System.DateTime.Now);
			string text2 = string.Format("{0}{1:HHmmssfff}", "T", System.DateTime.Now);
			string text3 = System.Guid.NewGuid().ToString();
			string text4 = text3.Substring(0, 25).Replace("-", "");
			if (string.IsNullOrEmpty(countryCode))
			{
				countryCode = "000";
			}
			if (string.IsNullOrEmpty(storeCode))
			{
				storeCode = "0000";
			}
			if (subStoreid.Length < 2)
			{
				subStoreid = "0" + subStoreid.ToString();
			}
			string text5 = string.Concat(new string[]
			{
				countryCode,
				storeCode,
				subStoreid,
				text,
				text2,
				text4,
				ApplicationObject
			});
			return text5.ToUpper();
		}

		public static Stopwatch Watch()
		{
			return new Stopwatch();
		}

		public static void WatchStop(string processName, Stopwatch watch)
		{
			watch.Stop();
			lock (CommonUtility._object)
			{
				CommonUtility.LogPerfWrite(processName, watch.Elapsed);
			}
		}

		public static void LogPerfWrite(string processName, System.TimeSpan timesapn)
		{
			System.IO.FileStream fileStream = null;
			System.IO.StreamWriter streamWriter = null;
			try
			{
				string str = System.IO.Path.Combine(new string[]
				{
					System.AppDomain.CurrentDomain.BaseDirectory
				});
				string text = str + "\\";
				text = System.IO.Path.Combine(text, "DigiLogError");
				text = text + "\\DigiPerfLog-" + System.DateTime.Today.ToString("yyyyMMdd") + ".txt";
				if (!text.Equals(""))
				{
					System.IO.FileInfo fileInfo = new System.IO.FileInfo(text);
					System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(fileInfo.DirectoryName);
					if (!directoryInfo.Exists)
					{
						directoryInfo.Create();
					}
					if (!fileInfo.Exists)
					{
						fileStream = fileInfo.Create();
					}
					else
					{
						fileStream = new System.IO.FileStream(text, System.IO.FileMode.Append);
					}
					streamWriter = new System.IO.StreamWriter(fileStream);
					streamWriter.WriteLine(string.Format("Time elapsed for: {0} : {1} | {2}", processName, timesapn.ToString(), timesapn.Milliseconds.ToString()));
				}
			}
			finally
			{
				if (streamWriter != null)
				{
					streamWriter.Close();
				}
				if (fileStream != null)
				{
					fileStream.Close();
				}
			}
		}

		public static BitmapImage GetImageFromPath(string path)
		{
			BitmapImage result;
			try
			{
				BitmapImage bitmapImage = new BitmapImage();
				using (System.IO.FileStream fileStream = System.IO.File.OpenRead(path))
				{
					System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
					fileStream.CopyTo(memoryStream);
					memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
					fileStream.Close();
					bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
					bitmapImage.BeginInit();
					bitmapImage.StreamSource = memoryStream;
					bitmapImage.EndInit();
					bitmapImage.Freeze();
					fileStream.Close();
					memoryStream.Flush();
				}
				result = bitmapImage;
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				result = null;
			}
			return result;
		}

		public static void BindCombo<T>(ComboBox combo, System.Collections.Generic.List<T> oList, string displayMemberPath, string selectedValuePath)
		{
			combo.DisplayMemberPath = displayMemberPath;
			combo.SelectedValuePath = selectedValuePath;
			combo.ItemsSource = oList;
		}

		public static void BindComboWithSelect<T>(ComboBox combo, System.Collections.Generic.List<T> oList, string displayMemberPath, string selectedValuePath, int val, string text) where T : new()
		{
			combo.DisplayMemberPath = displayMemberPath;
			combo.SelectedValuePath = selectedValuePath;
			System.Reflection.PropertyInfo property = typeof(T).GetProperty(displayMemberPath);
			System.Reflection.PropertyInfo property2 = typeof(T).GetProperty(selectedValuePath);
			T t = (default(T) == null) ? System.Activator.CreateInstance<T>() : default(T);
			property.SetValue(t, System.Convert.ChangeType(text, property.PropertyType), null);
			property2.SetValue(t, System.Convert.ChangeType(val, property2.PropertyType), null);
			oList.Insert(0, t);
			combo.ItemsSource = oList;
		}

		public static void BindListBox<T>(ListBox list, System.Collections.Generic.List<T> oList)
		{
			list.ItemsSource = oList;
		}

		public static void BindComboWithSelect(ComboBox combo, System.Collections.Generic.List<ValueTypeInfo> oList, int value, string Text)
		{
			combo.DisplayMemberPath = "Name";
			combo.SelectedValuePath = "ValueTypeId";
			oList.Insert(0, new ValueTypeInfo
			{
				ValueTypeId = value,
				Name = Text
			});
			combo.ItemsSource = oList;
		}

		public static DataTable ToDataTable<T>(System.Collections.Generic.IList<T> data)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
			DataTable dataTable = new DataTable();
			for (int i = 0; i < properties.Count; i++)
			{
				PropertyDescriptor propertyDescriptor = properties[i];
				dataTable.Columns.Add(propertyDescriptor.Name, propertyDescriptor.PropertyType);
			}
			object[] array = new object[properties.Count];
			foreach (T current in data)
			{
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = properties[i].GetValue(current);
				}
				dataTable.Rows.Add(array);
			}
			return dataTable;
		}

		public static string getRequiredMessage(string param)
		{
			return string.Format(UIConstant.requiredParam, param);
		}

		public static string getRequiredMessageForDdl(string param)
		{
			return string.Format(UIConstant.requiredParamForDdl, param);
		}

		public static void CleanFolder(string DirectoryName, params string[] FolderNames)
		{
			for (int i = 0; i < FolderNames.Length; i++)
			{
				string path = FolderNames[i];
				if (System.IO.Directory.Exists(System.IO.Path.Combine(DirectoryName, path)))
				{
					System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(System.IO.Path.Combine(DirectoryName, path));
					System.IO.FileInfo[] files = directoryInfo.GetFiles();
					for (int j = 0; j < files.Length; j++)
					{
						System.IO.FileInfo fileInfo = files[j];
						try
						{
							fileInfo.Delete();
						}
						catch (System.Exception serviceException)
						{
							string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
							ErrorHandler.ErrorHandler.LogFileWrite(message);
						}
					}
				}
			}
		}
	}
}
