using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PhotoSW.Common
{
   
    public class UriToBitmapConverter : IValueConverter
    {

        
        public object Convert(object value, Type targetType,
                               object parameter, System.Globalization.CultureInfo culture)
        {

            if (value != null)
            {
                if (value is string) // Image path
                {
                    try
                    {
                        string imgPath = System.AppDomain.CurrentDomain.BaseDirectory + "//images//adv_graphics_btn.png";



                        if (System.IO.File.Exists(imgPath))
                        {
                            string fileName = imgPath;



                            using (var fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                            {
                                BitmapImage image = new BitmapImage();
                                image.BeginInit();
                                image.CacheOption = BitmapCacheOption.OnLoad;
                                image.StreamSource = fs;
                                image.EndInit();
                                image.Freeze();
                                return image;
                            }
                        }
                        else
                        {
                            return null; 
                        }

                    }


                    catch (Exception ex)
                    {
                        return null; 
                    }

                }
                else
                {
                    return null; 
                }
            }
            else
            {
                return null;
            }

        }

        public object ConvertBack(object value, Type targetType,
                                  object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        //public static string Domain { get { return @"http://br1.beepconnect.com/"; } }
        //public static string UserImageUrl { get { return Domain; } }
    }
}
