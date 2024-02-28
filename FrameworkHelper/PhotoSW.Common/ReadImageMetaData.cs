using ErrorHandler;
using System;
using System.Windows.Media.Imaging;

namespace PhotoSW.Common
{
	public class ReadImageMetaData
	{
		public string GetImageMetaData(string filename)
		{
			string text = string.Empty;
			string result;
			try
			{
				BitmapSource bitmapSource = BitmapFrame.Create(new Uri(filename));
				BitmapMetadata bitmapMetadata = (BitmapMetadata)bitmapSource.Metadata;
				double num = (double)(bitmapSource.PixelHeight * bitmapSource.PixelWidth) / 1000000.0;
				string text2 = bitmapSource.PixelWidth.ToString() + "x" + bitmapSource.PixelHeight.ToString();
				string text3 = num.ToString() + " mb";
				string text4 = bitmapSource.DpiX.ToString() + "x" + bitmapSource.DpiY.ToString();
				string text5 = "##";
				string text6 = "##";
				string text7 = "##";
				string text8 = "##";
				string text9 = "##";
				string text10 = "##";
				string text11 = "##";
				text = string.Concat(new string[]
				{
					text2,
					"@",
					text3,
					"@",
					text4,
					"@",
					text5,
					"@",
					text6,
					"@",
					text7,
					"@",
					text8,
					"@",
					text9,
					"@",
					text10,
					"@",
					text11
				});
				try
				{
					if (bitmapMetadata.Title != null)
					{
						text5 = bitmapMetadata.Title.ToString();
					}
				}
				catch
				{
					text5 = "";
				}
				try
				{
					if (bitmapMetadata.Subject != null)
					{
						text6 = bitmapMetadata.Subject.ToString();
					}
				}
				catch (System.Exception serviceException)
				{
					text6 = "";
				}
				try
				{
					if (bitmapMetadata.Comment != null)
					{
						text7 = bitmapMetadata.Comment.ToString();
					}
				}
				catch
				{
					text7 = "";
				}
				try
				{
					if (bitmapMetadata.DateTaken != null)
					{
						text8 = bitmapMetadata.DateTaken.ToString();
					}
				}
				catch
				{
					text8 = "";
				}
				try
				{
					if (bitmapMetadata.CameraManufacturer != null || bitmapMetadata.CameraModel != null)
					{
						text9 = bitmapMetadata.CameraManufacturer.ToString() + " " + bitmapMetadata.CameraModel.ToString();
					}
				}
				catch (System.Exception serviceException)
				{
					text9 = "";
				}
				try
				{
					if (bitmapMetadata.Copyright != null)
					{
						text10 = bitmapMetadata.Copyright.ToString();
					}
				}
				catch
				{
					text10 = "";
				}
				try
				{
					if (bitmapMetadata.Keywords != null)
					{
						text11 = bitmapMetadata.Keywords.ToString();
					}
				}
				catch
				{
					text11 = "";
				}
				text = string.Concat(new string[]
				{
					text2,
					"@",
					text3,
					"@",
					text4,
					"@",
					text5,
					"@",
					text6,
					"@",
					text7,
					"@",
					text8,
					"@",
					text9,
					"@",
					text10,
					"@",
					text11
				});
				result = text;
			}
			catch (System.Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
				result = text;
			}
			return result;
		}
	}
}
