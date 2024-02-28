using System;
using System.IO;

namespace FrameworkHelper
{
	public class FlvMetaDataReader
	{
		public static FlvMetaInfo GetFlvMetaInfo(string path)
		{
			if (!System.IO.File.Exists(path))
			{
				throw new System.Exception(string.Format("File '{0}' doesn't exist for FlvMetaDataReader.GetFlvMetaInfo(path)", path));
			}
			bool hasMetaData = false;
			double duration = 0.0;
			System.DateTime minValue = System.DateTime.MinValue;
			System.IO.FileStream fileStream = new System.IO.FileStream(path, System.IO.FileMode.Open);
			try
			{
				byte[] array = new byte[10];
				fileStream.Seek(27L, System.IO.SeekOrigin.Begin);
				int num = fileStream.Read(array, 0, 10);
				string a = FlvMetaDataReader.ByteArrayToString(array);
				if (a == "onMetaData")
				{
					hasMetaData = true;
					duration = FlvMetaDataReader.GetNextDouble(fileStream, 16, 8);
				}
			}
			catch (System.Exception var_7_8A)
			{
			}
			finally
			{
				fileStream.Close();
			}
			return new FlvMetaInfo(hasMetaData, duration);
		}

		private static double GetNextDouble(System.IO.FileStream fileStream, int offset, int length)
		{
			fileStream.Seek((long)offset, System.IO.SeekOrigin.Current);
			byte[] array = new byte[length];
			int num = fileStream.Read(array, 0, length);
			return FlvMetaDataReader.ByteArrayToDouble(array, true);
		}

		private static string ByteArrayToString(byte[] bytes)
		{
			string text = string.Empty;
			for (int i = 0; i < bytes.Length; i++)
			{
				byte value = bytes[i];
				text += System.Convert.ToChar(value).ToString();
			}
			return text;
		}

		private static double ByteArrayToDouble(byte[] bytes, bool readInReverse)
		{
			if (bytes.Length != 8)
			{
				throw new System.Exception("bytes must be exactly 8 in Length");
			}
			if (readInReverse)
			{
				System.Array.Reverse(bytes);
			}
			return System.BitConverter.ToDouble(bytes, 0);
		}
	}
}
