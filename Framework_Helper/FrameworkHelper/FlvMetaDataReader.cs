namespace FrameworkHelper
{
    using System;
    using System.IO;

    public class FlvMetaDataReader
    {
        private static double ByteArrayToDouble(byte[] bytes, bool readInReverse)
        {
            if (bytes.Length != 8)
            {
                throw new Exception("bytes must be exactly 8 in Length");
            }
            if (readInReverse)
            {
                Array.Reverse(bytes);
            }
            return BitConverter.ToDouble(bytes, 0);
        }

        private static string ByteArrayToString(byte[] bytes)
        {
            string str = string.Empty;
            foreach (byte num in bytes)
            {
                str = str + Convert.ToChar(num).ToString();
            }
            return str;
        }

        public static FlvMetaInfo GetFlvMetaInfo(string path)
        {
            if (!File.Exists(path))
            {
                throw new Exception(string.Format("File '{0}' doesn't exist for FlvMetaDataReader.GetFlvMetaInfo(path)", path));
            }
            bool hasMetaData = false;
            double duration = 0.0;
            FileStream fileStream = new FileStream(path, FileMode.Open);
            try
            {
                byte[] buffer = new byte[10];
                fileStream.Seek(0x1bL, SeekOrigin.Begin);
                int num2 = fileStream.Read(buffer, 0, 10);
                if (ByteArrayToString(buffer) == "onMetaData")
                {
                    hasMetaData = true;
                    duration = GetNextDouble(fileStream, 0x10, 8);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                fileStream.Close();
            }
            return new FlvMetaInfo(hasMetaData, duration);
        }

        private static double GetNextDouble(FileStream fileStream, int offset, int length)
        {
            fileStream.Seek((long) offset, SeekOrigin.Current);
            byte[] buffer = new byte[length];
            int num = fileStream.Read(buffer, 0, length);
            return ByteArrayToDouble(buffer, true);
        }
    }
}

