namespace DigiPhoto.Common
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class OpaqueClickableImage : Image
    {
        protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
        {
            BitmapSource source = (BitmapSource) base.Source;
            int x = (int) ((hitTestParameters.HitPoint.X / base.ActualWidth) * source.PixelWidth);
            int y = (int) ((hitTestParameters.HitPoint.Y / base.ActualHeight) * source.PixelHeight);
            if (x == source.PixelWidth)
            {
                x--;
            }
            if (y == source.PixelHeight)
            {
                y--;
            }
            byte[] pixels = new byte[4];
            source.CopyPixels(new Int32Rect(x, y, 1, 1), pixels, 4, 0);
            if (pixels[3] < 1)
            {
                return null;
            }
            return new PointHitTestResult(this, hitTestParameters.HitPoint);
        }
    }
}

