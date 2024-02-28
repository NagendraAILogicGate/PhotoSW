namespace DigiPhoto.Common
{
    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class ResetDPI
    {
        private ResetDPI()
        {
        }

        public static Image ScaleByHeight(Image img, int height)
        {
            double num = ((double) height) / ((double) img.Height);
            int outputWidth = (int) (img.Width * num);
            int outputHeight = height;
            return ScaleImage(img, outputWidth, outputHeight);
        }

        public static Image ScaleByHeightAndResolution(Image img, int height, float Resolution)
        {
            double num = ((double) height) / ((double) img.Height);
            int outputWidth = (int) (img.Width * num);
            int outputHeight = height;
            return ScaleImageAndResolution(img, outputWidth, outputHeight, Resolution);
        }

        public static Image ScaleByPercentage(Image img, double percent)
        {
            double num = percent / 100.0;
            int outputWidth = (int) (img.Width * num);
            int outputHeight = (int) (img.Height * num);
            return ScaleImage(img, outputWidth, outputHeight);
        }

        public static Image ScaleByWidth(Image img, int width)
        {
            double num = ((double) width) / ((double) img.Width);
            int outputWidth = width;
            int outputHeight = (int) (img.Height * num);
            return ScaleImage(img, outputWidth, outputHeight);
        }

        public static Image ScaleImage(Image img, int outputWidth, int outputHeight)
        {
            Bitmap image = new Bitmap(outputWidth, outputHeight, img.PixelFormat);
            image.SetResolution(img.HorizontalResolution, img.VerticalResolution);
            Graphics graphics = Graphics.FromImage(image);
            graphics.InterpolationMode = InterpolationMode.Bilinear;
            graphics.DrawImage(img, new Rectangle(0, 0, outputWidth, outputHeight), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            graphics.Dispose();
            return image;
        }

        public static Image ScaleImageAndResolution(Image img, int outputWidth, int outputHeight, float Resolution)
        {
            Bitmap image = new Bitmap(outputWidth, outputHeight, img.PixelFormat);
            image.SetResolution(Resolution, Resolution);
            Graphics graphics = Graphics.FromImage(image);
            graphics.InterpolationMode = InterpolationMode.Bilinear;
            graphics.DrawImage(img, new Rectangle(0, 0, outputWidth, outputHeight), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            graphics.Dispose();
            return image;
        }
    }
}

