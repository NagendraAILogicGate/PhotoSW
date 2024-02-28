using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoSW.Common
{
	public class OpaqueClickableImage : Image
	{
		protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
		{
			BitmapSource bitmapSource = (BitmapSource)base.Source;
			int num = (int)(hitTestParameters.HitPoint.X / base.ActualWidth * (double)bitmapSource.PixelWidth);
			int num2 = (int)(hitTestParameters.HitPoint.Y / base.ActualHeight * (double)bitmapSource.PixelHeight);
			if (num == bitmapSource.PixelWidth)
			{
				num--;
			}
			if (num2 == bitmapSource.PixelHeight)
			{
				num2--;
			}
			byte[] array = new byte[4];
			bitmapSource.CopyPixels(new Int32Rect(num, num2, 1, 1), array, 4, 0);
			HitTestResult result;
			if (array[3] < 1)
			{
				result = null;
			}
			else
			{
				result = new PointHitTestResult(this, hitTestParameters.HitPoint);
			}
			return result;
		}
	}
}
