using System;
using System.Windows.Media.Imaging;

namespace PhotoSW.Common
{
	public interface ICanGetThumbBitmapImage
	{
		BitmapImage GetMiniThumb_BitmapImage(string path, int decodeWidth);

		BitmapImage GetThumb_BitmapImage(string path, int decodeWidth);
	}
}
