namespace DigiPhoto.Common
{
    using System;
    using System.Windows.Media.Imaging;

    public interface ICanGetThumbBitmapImage
    {
        BitmapImage GetMiniThumb_BitmapImage(string path, int decodeWidth);
        BitmapImage GetThumb_BitmapImage(string path, int decodeWidth);
    }
}

