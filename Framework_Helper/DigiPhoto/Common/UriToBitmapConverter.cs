namespace DigiPhoto.Common
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    public class UriToBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            object obj2;
            try
            {
                BitmapImage image = new BitmapImage();
                if (value != null)
                {
                    GC.AddMemoryPressure(0x2710L);
                    using (FileStream stream = File.OpenRead(value.ToString()))
                    {
                        MemoryStream destination = new MemoryStream();
                        stream.CopyTo(destination);
                        destination.Seek(0L, SeekOrigin.Begin);
                        stream.Close();
                        image.BeginInit();
                        image.CacheOption = BitmapCacheOption.OnLoad;
                        image.StreamSource = destination;
                        image.EndInit();
                        image.Freeze();
                    }
                }
                else
                {
                    image = new BitmapImage();
                }
                obj2 = image;
            }
            catch (Exception)
            {
                obj2 = null;
            }
            finally
            {
                GC.RemoveMemoryPressure(0x2710L);
            }
            return obj2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}

