using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace PhotoSW.Common
{
	public class ResetDPI
	{
		private ResetDPI()
		{
		}

		public static Image ScaleByPercentage(Image img, double percent)
		{
			double num = percent / 100.0;
			int outputWidth = (int)((double)img.Width * num);
			int outputHeight = (int)((double)img.Height * num);
			return ResetDPI.ScaleImage(img, outputWidth, outputHeight);
		}

		public static Image ScaleByWidth(Image img, int width)
		{
			double num = (double)width / (double)img.Width;
			int outputHeight = (int)((double)img.Height * num);
			return ResetDPI.ScaleImage(img, width, outputHeight);
		}

		public static Image ScaleByHeight(Image img, int height)
		{
			double num = (double)height / (double)img.Height;
			int outputWidth = (int)((double)img.Width * num);
			return ResetDPI.ScaleImage(img, outputWidth, height);
		}

		public static Image ScaleByHeightAndResolution(Image img, int height, float Resolution)
		{
			double num = (double)height / (double)img.Height;
			int outputWidth = (int)((double)img.Width * num);
			return ResetDPI.ScaleImageAndResolution(img, outputWidth, height, Resolution);
		}

		public static Image ScaleImage(Image img, int outputWidth, int outputHeight)
		{
			Bitmap bitmap = new Bitmap(outputWidth, outputHeight, img.PixelFormat);
			bitmap.SetResolution(img.HorizontalResolution, img.VerticalResolution);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.InterpolationMode = InterpolationMode.Bilinear;
			graphics.DrawImage(img, new Rectangle(0, 0, outputWidth, outputHeight), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
			graphics.Dispose();
			return bitmap;
		}

		public static Image ScaleImageAndResolution(Image img, int outputWidth, int outputHeight, float Resolution)
		{
			Bitmap bitmap = new Bitmap(outputWidth, outputHeight, img.PixelFormat);
			bitmap.SetResolution(Resolution, Resolution);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.InterpolationMode = InterpolationMode.Bilinear;
			graphics.DrawImage(img, new Rectangle(0, 0, outputWidth, outputHeight), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
			graphics.Dispose();
			return bitmap;
		}
	}
}
