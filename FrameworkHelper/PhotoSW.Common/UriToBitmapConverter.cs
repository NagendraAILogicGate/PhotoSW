using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PhotoSW.Common
{
	public class UriToBitmapConverter : IValueConverter
	{
		public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			object result;
			try
			{
				BitmapImage bitmapImage = new BitmapImage();
				if (value != null)
				{
					System.GC.AddMemoryPressure(10000L);
					using (System.IO.FileStream fileStream = System.IO.File.OpenRead(value.ToString()))
					{
						System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
						fileStream.CopyTo(memoryStream);
						memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
						fileStream.Close();
						bitmapImage.BeginInit();
						bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
						bitmapImage.StreamSource = memoryStream;
						bitmapImage.EndInit();
						bitmapImage.Freeze();
					}
				}
				else
				{
					bitmapImage = new BitmapImage();
				}
				result = bitmapImage;
			}
			catch (System.Exception var_3_96)
			{
				result = null;
			}
			finally
			{
				System.GC.RemoveMemoryPressure(10000L);
			}
			return result;
		}

		public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			throw new System.Exception("The method or operation is not implemented.");
		}
	}
}
