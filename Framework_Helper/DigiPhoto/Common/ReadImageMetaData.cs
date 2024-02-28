namespace DigiPhoto.Common
{
    using ErrorHandler;
    using System;
    using System.Windows.Media.Imaging;

    public class ReadImageMetaData
    {
        public string GetImageMetaData(string filename)
        {
            Exception exception;
            string str = string.Empty;
            try
            {
                BitmapSource source = BitmapFrame.Create(new Uri(filename));
                BitmapMetadata metadata = (BitmapMetadata) source.Metadata;
                double num = ((double) (source.PixelHeight * source.PixelWidth)) / 1000000.0;
                string str2 = source.PixelWidth.ToString() + "x" + source.PixelHeight.ToString();
                string str3 = num.ToString() + " mb";
                string str4 = source.DpiX.ToString() + "x" + source.DpiY.ToString();
                string str5 = "##";
                string str6 = "##";
                string str7 = "##";
                string str8 = "##";
                string str9 = "##";
                string str10 = "##";
                string str11 = "##";
                str = str2 + "@" + str3 + "@" + str4 + "@" + str5 + "@" + str6 + "@" + str7 + "@" + str8 + "@" + str9 + "@" + str10 + "@" + str11;
                try
                {
                    if (metadata.Title != null)
                    {
                        str5 = metadata.Title.ToString();
                    }
                }
                catch
                {
                    str5 = "";
                }
                try
                {
                    if (metadata.Subject != null)
                    {
                        str6 = metadata.Subject.ToString();
                    }
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    str6 = "";
                }
                try
                {
                    if (metadata.Comment != null)
                    {
                        str7 = metadata.Comment.ToString();
                    }
                }
                catch
                {
                    str7 = "";
                }
                try
                {
                    if (metadata.DateTaken != null)
                    {
                        str8 = metadata.DateTaken.ToString();
                    }
                }
                catch
                {
                    str8 = "";
                }
                try
                {
                    if ((metadata.CameraManufacturer != null) || (metadata.CameraModel != null))
                    {
                        str9 = metadata.CameraManufacturer.ToString() + " " + metadata.CameraModel.ToString();
                    }
                }
                catch (Exception exception2)
                {
                    exception = exception2;
                    str9 = "";
                }
                try
                {
                    if (metadata.Copyright != null)
                    {
                        str10 = metadata.Copyright.ToString();
                    }
                }
                catch
                {
                    str10 = "";
                }
                try
                {
                    if (metadata.Keywords != null)
                    {
                        str11 = metadata.Keywords.ToString();
                    }
                }
                catch
                {
                    str11 = "";
                }
                return (str2 + "@" + str3 + "@" + str4 + "@" + str5 + "@" + str6 + "@" + str7 + "@" + str8 + "@" + str9 + "@" + str10 + "@" + str11);
            }
            catch (Exception exception3)
            {
                exception = exception3;
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                return str;
            }
        }
    }
}

