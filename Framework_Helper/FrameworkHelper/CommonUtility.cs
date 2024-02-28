namespace FrameworkHelper
{
    using DigiPhoto.IMIX.Model;
    using ErrorHandler;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;

    public class CommonUtility
    {
        private static volatile object _object = new object();

        public static void BindCombo<T>(ComboBox combo, List<T> oList, string displayMemberPath, string selectedValuePath)
        {
            combo.DisplayMemberPath = displayMemberPath;
            combo.SelectedValuePath = selectedValuePath;
            combo.ItemsSource = oList;
        }

        public static void BindComboWithSelect(ComboBox combo, List<ValueTypeInfo> oList, int value, string Text)
        {
            combo.DisplayMemberPath = "Name";
            combo.SelectedValuePath = "ValueTypeId";
            ValueTypeInfo item = new ValueTypeInfo {
                ValueTypeId = value,
                Name = Text
            };
            oList.Insert(0, item);
            combo.ItemsSource = oList;
        }

        public static void BindComboWithSelect<T>(ComboBox combo, List<T> oList, string displayMemberPath, string selectedValuePath, int val, string text) where T: new()
        {
            combo.DisplayMemberPath = displayMemberPath;
            combo.SelectedValuePath = selectedValuePath;
            PropertyInfo property = typeof(T).GetProperty(displayMemberPath);
            PropertyInfo info2 = typeof(T).GetProperty(selectedValuePath);
            T local = new T();
            property.SetValue(local, Convert.ChangeType(text, property.PropertyType), null);
            info2.SetValue(local, Convert.ChangeType(val, info2.PropertyType), null);
            oList.Insert(0, local);
            combo.ItemsSource = oList;
        }

        public static void BindListBox<T>(ListBox list, List<T> oList)
        {
            list.ItemsSource = oList;
        }

        public static void CleanFolder(string DirectoryName, params string[] FolderNames)
        {
            foreach (string str in FolderNames)
            {
                if (Directory.Exists(Path.Combine(DirectoryName, str)))
                {
                    DirectoryInfo info = new DirectoryInfo(Path.Combine(DirectoryName, str));
                    foreach (FileInfo info2 in info.GetFiles())
                    {
                        try
                        {
                            info2.Delete();
                        }
                        catch (Exception exception)
                        {
                            ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                        }
                    }
                }
            }
        }

        public static BitmapImage GetImageFromPath(string path)
        {
            try
            {
                BitmapImage image = new BitmapImage();
                using (FileStream stream = File.OpenRead(path))
                {
                    MemoryStream destination = new MemoryStream();
                    stream.CopyTo(destination);
                    destination.Seek(0L, SeekOrigin.Begin);
                    stream.Close();
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.BeginInit();
                    image.StreamSource = destination;
                    image.EndInit();
                    image.Freeze();
                    stream.Close();
                    destination.Flush();
                }
                return image;
            }
            catch (Exception exception)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                return null;
            }
        }

        public static int GetRandomNumber(int maxNumber)
        {
            if (maxNumber < 1)
            {
                throw new Exception("The maxNumber value should be greater than 1");
            }
            byte[] data = new byte[4];
            new RNGCryptoServiceProvider().GetBytes(data);
            int seed = ((((data[0] & 0x7f) << 0x18) | (data[1] << 0x10)) | (data[2] << 8)) | data[3];
            Random random = new Random(seed);
            return random.Next(1, maxNumber);
        }

        public static string GetRandomString(int length)
        {
            string[] strArray = new string[] { 
                "0", "1", "2", "3", "4", "5", "6", "8", "9", "A", "B", "C", "D", "E", "F", "G", 
                "H", "J", "K", "L", "M", "N", "P", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
             };
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                builder.Append(strArray[GetRandomNumber(0x20)]);
            }
            return builder.ToString();
        }

        public static string getRequiredMessage(string param)
        {
            return string.Format(UIConstant.requiredParam, param);
        }

        public static string getRequiredMessageForDdl(string param)
        {
            return string.Format(UIConstant.requiredParamForDdl, param);
        }

        public static string GetUniqueSynccode(string ApplicationObject, string countryCode, string storeCode, string subStoreid)
        {
            string str = string.Format("{0:yyyyMMdd}", DateTime.Now);
            string str2 = string.Format("{0}{1:HHmmssfff}", "T", DateTime.Now);
            string str4 = Guid.NewGuid().ToString().Substring(0, 0x19).Replace("-", "");
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
            return (countryCode + storeCode + subStoreid + str + str2 + str4 + ApplicationObject).ToUpper();
        }

        public static void LogPerfWrite(string processName, TimeSpan timesapn)
        {
            FileStream stream = null;
            StreamWriter writer = null;
            try
            {
                string fileName = Path.Combine(Path.Combine(new string[] { AppDomain.CurrentDomain.BaseDirectory }) + @"\", "DigiLogError") + @"\DigiPerfLog-" + DateTime.Today.ToString("yyyyMMdd") + ".txt";
                if (!fileName.Equals(""))
                {
                    DirectoryInfo info = null;
                    FileInfo info2 = new FileInfo(fileName);
                    info = new DirectoryInfo(info2.DirectoryName);
                    if (!info.Exists)
                    {
                        info.Create();
                    }
                    if (!info2.Exists)
                    {
                        stream = info2.Create();
                    }
                    else
                    {
                        stream = new FileStream(fileName, FileMode.Append);
                    }
                    writer = new StreamWriter(stream);
                    writer.WriteLine(string.Format("Time elapsed for: {0} : {1} | {2}", processName, timesapn.ToString(), timesapn.Milliseconds.ToString()));
                }
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
            }
        }

        public static DataTable ToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            int index = 0;
            while (index < properties.Count)
            {
                PropertyDescriptor descriptor = properties[index];
                table.Columns.Add(descriptor.Name, descriptor.PropertyType);
                index++;
            }
            object[] values = new object[properties.Count];
            foreach (T local in data)
            {
                for (index = 0; index < values.Length; index++)
                {
                    values[index] = properties[index].GetValue(local);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        public static Stopwatch Watch()
        {
            return new Stopwatch();
        }

        public static void WatchStop(string processName, Stopwatch watch)
        {
            watch.Stop();
            lock (_object)
            {
                LogPerfWrite(processName, watch.Elapsed);
            }
        }
    }
}

