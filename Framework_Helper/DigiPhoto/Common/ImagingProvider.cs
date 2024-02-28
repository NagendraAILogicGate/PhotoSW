namespace DigiPhoto.Common
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    internal class ImagingProvider
    {
        private Point origin;
        private Point start;

        public static void FitToContentMagnifier(Image imgObject, TransformGroup tg, Canvas parentCanvas, Canvas canvasMagnifier, Image imgMagnifier)
        {
            ScaleTransform transform = (ScaleTransform) tg.Children[0];
            TranslateTransform transform2 = (TranslateTransform) tg.Children[1];
            transform2.X = 0.0;
            transform2.Y = 0.0;
            transform.CenterX = 0.0;
            transform.CenterY = 0.0;
            double num = parentCanvas.ActualWidth / imgObject.ActualWidth;
            double num2 = parentCanvas.ActualHeight / imgObject.ActualHeight;
            transform.ScaleX = (num > num2) ? num2 : num;
            transform.ScaleY = (num > num2) ? num2 : num;
        }

        public static void LoadImage(Uri fileUri, Image frente)
        {
            TiffBitmapDecoder decoder = new TiffBitmapDecoder(fileUri, BitmapCreateOptions.None, BitmapCacheOption.Default);
            frente.Source = decoder.Frames[0];
        }

        public void Magnifier(Canvas imgCanvas, Image imgObject, Canvas imgCanvasMagnifier, Image imgMagnifier, MouseEventArgs e)
        {
            double width = imgCanvasMagnifier.Width;
            double height = imgCanvasMagnifier.Height;
            int num3 = 8;
            if (imgMagnifier.Source != imgObject.Source)
            {
                imgMagnifier.Source = imgObject.Source;
            }
            Size renderSize = imgObject.RenderSize;
            RotateTransform layoutTransform = (RotateTransform) imgObject.LayoutTransform;
            TranslateTransform transform2 = (TranslateTransform) ((TransformGroup) imgObject.RenderTransform).Children[1];
            ScaleTransform transform3 = (ScaleTransform) ((TransformGroup) imgObject.RenderTransform).Children[0];
            double num4 = (e.GetPosition(imgCanvas).X - transform2.X) + 20.0;
            double num5 = (e.GetPosition(imgCanvas).Y - transform2.Y) + 20.0;
            Point position = e.MouseDevice.GetPosition(imgCanvas);
            double top = Canvas.GetTop(imgObject);
            TransformGroup group = new TransformGroup();
            ScaleTransform transform4 = new ScaleTransform {
                ScaleX = transform3.ScaleX * num3,
                ScaleY = transform3.ScaleY * num3
            };
            RotateTransform transform5 = new RotateTransform {
                Angle = layoutTransform.Angle
            };
            TranslateTransform transform6 = new TranslateTransform();
            double num7 = transform3.CenterX * (transform3.ScaleX - 1.0);
            double num8 = transform3.CenterY * (transform3.ScaleY - 1.0);
            if (layoutTransform.Angle == 0.0)
            {
                transform6.X = -(num4 + num7) / transform3.ScaleX;
                transform6.Y = -(num5 + num8) / transform3.ScaleY;
                transform4.CenterX = (num4 + num7) / transform3.ScaleX;
                transform4.CenterY = (num5 + num8) / transform3.ScaleY;
            }
            if (layoutTransform.Angle == 90.0)
            {
                transform6.X = -(num4 + num7) / transform3.ScaleX;
                transform6.Y = -(num5 + num8) / transform3.ScaleY;
                transform6.X += (imgObject.ActualHeight * transform3.ScaleX) * num3;
                transform4.CenterX = (num4 + num7) / transform3.ScaleX;
                transform4.CenterY = (num5 + num8) / transform3.ScaleY;
            }
            if (layoutTransform.Angle == 180.0)
            {
                transform6.X = -(num4 + num7) / transform3.ScaleX;
                transform6.Y = -(num5 + num8) / transform3.ScaleY;
                transform6.X += (imgObject.ActualWidth * transform3.ScaleX) * num3;
                transform6.Y += (imgObject.ActualHeight * transform3.ScaleY) * num3;
                transform4.CenterX = (num4 + num7) / transform3.ScaleX;
                transform4.CenterY = (num5 + num8) / transform3.ScaleY;
            }
            if (layoutTransform.Angle == 270.0)
            {
                transform6.X = -(num4 + num7) / transform3.ScaleX;
                transform6.Y = -(num5 + num8) / transform3.ScaleY;
                transform6.Y += (imgObject.ActualWidth * transform3.ScaleX) * num3;
                transform4.CenterX = (num4 + num7) / transform3.ScaleX;
                transform4.CenterY = (num5 + num8) / transform3.ScaleY;
            }
            transform6.X += width / 2.0;
            transform6.Y += height / 2.0;
            group.Children.Add(transform5);
            group.Children.Add(transform4);
            group.Children.Add(transform6);
            imgMagnifier.RenderTransform = group;
        }

        public void MouseDown(Canvas imgCanvas, Image imgObject, TranslateTransform tt, MouseButtonEventArgs e)
        {
            imgObject.CaptureMouse();
            this.start = e.GetPosition(imgCanvas);
            this.origin = new Point(tt.X, tt.Y);
        }

        public void MouseMove(Canvas imgCanvas, Image imgObject, TranslateTransform tt, MouseEventArgs e)
        {
            if (imgObject.IsMouseCaptured)
            {
                Vector vector = (Vector) (this.start - e.GetPosition(imgCanvas));
                tt.X = this.origin.X - vector.X;
                tt.Y = this.origin.Y - vector.Y;
            }
        }

        public void MouseMoveMagnifier(Canvas imgCanvas, Image imgObject, Canvas imgCanvasMagnifier, Image imgMagnifier, MouseEventArgs e)
        {
            this.Magnifier(imgCanvas, imgObject, imgCanvasMagnifier, imgMagnifier, e);
            if (imgObject.IsMouseCaptured)
            {
                TranslateTransform transform = (TranslateTransform) ((TransformGroup) imgObject.RenderTransform).Children[1];
                Vector vector = (Vector) (this.start - e.GetPosition(imgCanvas));
                transform.X = e.GetPosition(imgCanvas).X;
                transform.Y = e.GetPosition(imgCanvas).Y;
            }
        }

        public void MouseUp(Image imgObject, MouseButtonEventArgs e)
        {
            imgObject.ReleaseMouseCapture();
        }

        public static void MouseWheel(Canvas c, TransformGroup tg, MouseWheelEventArgs e)
        {
            int delta = e.Delta;
            TranslateTransform transform = (TranslateTransform) tg.Children[1];
            ScaleTransform transform2 = (ScaleTransform) tg.Children[0];
            double x = e.GetPosition(c).X;
            double y = e.GetPosition(c).Y;
            double num4 = e.GetPosition(c).X - transform.X;
            double num5 = e.GetPosition(c).Y - transform.Y;
            double num6 = transform2.CenterX * (transform2.ScaleX - 1.0);
            double num7 = transform2.CenterY * (transform2.ScaleY - 1.0);
            transform2.CenterX = num4;
            transform2.CenterY = num5;
            if (delta > 0)
            {
                transform2.ScaleX *= 1.25;
                transform2.ScaleY *= 1.25;
            }
            else
            {
                transform2.ScaleX *= 0.75;
                transform2.ScaleY *= 0.75;
            }
        }

        public static void Rotate(RotateTransform rt)
        {
            if (rt.Angle == 270.0)
            {
                rt.Angle = 0.0;
            }
            else
            {
                rt.Angle += 90.0;
            }
            rt.CenterX = 100.0;
            rt.CenterY = 100.0;
        }

        public static void SetScale(TransformGroup tg, double scale)
        {
            ScaleTransform transform = (ScaleTransform) tg.Children[0];
            transform.ScaleX = (scale / 5.0) + 0.1;
            transform.ScaleY = (scale / 5.0) + 0.1;
        }

        public static void ZoomIn(TransformGroup tg)
        {
            ScaleTransform transform = (ScaleTransform) tg.Children[0];
            transform.ScaleX *= 1.25;
            transform.ScaleY *= 1.25;
        }

        public static void ZoomOut(TransformGroup tg)
        {
            ScaleTransform transform = (ScaleTransform) tg.Children[0];
            transform.ScaleX *= 0.75;
            transform.ScaleY *= 0.75;
        }
    }
}

