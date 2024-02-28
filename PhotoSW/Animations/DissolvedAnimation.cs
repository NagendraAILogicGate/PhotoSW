using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

namespace PhotoSW.Animations
    {
    public class DissolvedAnimation
        {
        int count = 1;
        FrameworkElement _animatedElement = null;
        string fileName = String.Empty;
        string filepath = String.Empty;       
        Grid forWdhtImg = null;
        DispatcherTimer _timer = null;
        Image newImg;
        Image oldImg;
        public void MakeZoomAnimation ( Image newImage, Image oldImage, TimeSpan timeSpan, string filename, Grid forWdht )
            {
            fileName = filename;
            string imgPath = PhotoSW.Views.MainWindow.fileHotPath;
            forWdhtImg = forWdht;
            string hotpath = imgPath.Replace("Thumbnails_Big", "");
            fileName = fileName.Replace(".jpg", "_0") + count.ToString() + ".jpg";
            newImg = newImage;
            oldImg = oldImage;
            if(!Directory.Exists(System.IO.Path.Combine(hotpath, "DissolveAnimation")))
                {
                Directory.CreateDirectory(System.IO.Path.Combine(hotpath, "DissolveAnimation"));
                }

            filepath = hotpath + "DissolveAnimation\\" + fileName;
            _animatedElement = forWdht;
            double tickTime = timeSpan.TotalSeconds;           

            BeginFadeInImage(newImg);
            BeginFadeOutImage(oldImg);

            //RenderTargetBitmap source1 = this.CaptureScreenForGreenScreen(this.forWdhtImg, Common.CroppingAdorner.s_dpiX, Common.CroppingAdorner.s_dpiY, false);
            //using(FileStream fileStream = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite))
            //    {
            //    new JpegBitmapEncoder
            //        {
            //        QualityLevel = 95,
            //        Frames =
            //    {
            //    BitmapFrame.Create(source1)
            //    }
            //        }.Save(fileStream);
            //    }

            //count = count + 1;

            //_timer = new DispatcherTimer(DispatcherPriority.Input);
            //_timer.Interval = TimeSpan.FromSeconds(tickTime);
            //_timer.Tick += new EventHandler(_timer_Tick);
            //_timer.IsEnabled = true;

            }

        private void _timer_Tick ( object sender, EventArgs e )
            {
            BeginFadeInImage(newImg);
            BeginFadeOutImage(oldImg);
          //  count = count + 1;
            }


        private void BeginFadeInImage ( Image img )
            {
            var fadeIn = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(2.0)));
            fadeIn.Freeze();
            img.BeginAnimation(UIElement.OpacityProperty, fadeIn);
            
            //RenderTargetBitmap source = this.CaptureScreenForGreenScreen(this.forWdhtImg, Common.CroppingAdorner.s_dpiX, Common.CroppingAdorner.s_dpiY, false);         
            //using(FileStream fileStream = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite))
            //    {
            //    new JpegBitmapEncoder
            //        {
            //        QualityLevel = 95,
            //        Frames =
            //        {
            //        BitmapFrame.Create(source)
            //        }
            //        }.Save(fileStream);
            //    }
           
            }


        private void BeginFadeOutImage ( Image img )
            {
            var fadeOut = new DoubleAnimation(1.0, 0.0, new Duration(TimeSpan.FromSeconds(2.0)));
            fadeOut.Freeze();
            img.BeginAnimation(UIElement.OpacityProperty, fadeOut);

            //RenderTargetBitmap source = this.CaptureScreenForGreenScreen(this.forWdhtImg, Common.CroppingAdorner.s_dpiX, Common.CroppingAdorner.s_dpiY, false);                                 
            //using(FileStream fileStream = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite))
            //    {
            //    new JpegBitmapEncoder
            //        {
            //        QualityLevel = 95,
            //        Frames =
            //    {
            //    BitmapFrame.Create(source)
            //    }
            //        }.Save(fileStream);
            //    }         
            }


        private RenderTargetBitmap CaptureScreenForGreenScreen ( Grid forWdht, double dpiX, double dpiY, bool Isrotate )
            {
            RenderTargetBitmap renderTargetBitmap = null;
            RenderTargetBitmap result;
            try
                {
                RenderOptions.SetBitmapScalingMode(forWdht, BitmapScalingMode.HighQuality);
                RenderOptions.SetEdgeMode(forWdht, EdgeMode.Aliased);
                if(false)
                    {
                    goto IL_13E;
                    }
                System.Windows.Size size = new System.Windows.Size(forWdht.ActualWidth, forWdht.ActualHeight);
                bool arg_57_0 = 1.0 > 1.4;
                bool expr_57;
                do
                    {
                    expr_57 = (arg_57_0 = !arg_57_0);
                    }
                while(3 == 0);
                bool flag = expr_57;
                if(flag)
                    {
                    flag = (1.0 <= 0.1);
                    goto IL_13E;
                    }
                IL_66:
                int arg_C7_0 = (int)(size.Width * Common.CroppingAdorner.s_dpiY / 96.0 * (1.0 / 1.0));
                IL_8F:
                renderTargetBitmap = new RenderTargetBitmap(arg_C7_0, (int)(size.Height * Common.CroppingAdorner.s_dpiY / 96.0 * (1.0 / 1.0)), Common.CroppingAdorner.s_dpiX, Common.CroppingAdorner.s_dpiY, PixelFormats.Default);
                RenderOptions.SetEdgeMode(forWdht, EdgeMode.Aliased);
                forWdht.SnapsToDevicePixels = true;
                forWdht.RenderTransform = new ScaleTransform(1.0 / 1.0, 1.0 / 1.0, 0.5, 0.5);
                if(!false)
                    {
                    goto IL_273;
                    }
                goto IL_239;
                IL_13E:
                if(!flag)
                    {
                    renderTargetBitmap = new RenderTargetBitmap((int)(size.Width * Common.CroppingAdorner.s_dpiY / 96.0), (int)(size.Height * Common.CroppingAdorner.s_dpiY / 96.0), Common.CroppingAdorner.s_dpiX, Common.CroppingAdorner.s_dpiY, PixelFormats.Pbgra32);
                    RenderOptions.SetEdgeMode(forWdht, EdgeMode.Aliased);
                    forWdht.SnapsToDevicePixels = true;
                    if(!false)
                        {
                        forWdht.RenderTransform = new ScaleTransform(1.0, 1.0, 0.5, 0.5);
                        goto IL_272;
                        }
                    goto IL_297;
                    }
                else
                    {
                    int expr_1F6 = arg_C7_0 = (int)(size.Width * Common.CroppingAdorner.s_dpiY / 96.0 * 1.0);
                    if(7 == 0)
                        {
                        goto IL_8F;
                        }
                    renderTargetBitmap = new RenderTargetBitmap(expr_1F6, (int)(size.Height * Common.CroppingAdorner.s_dpiY / 96.0 * 1.0), Common.CroppingAdorner.s_dpiX, Common.CroppingAdorner.s_dpiY, PixelFormats.Default);
                    RenderOptions.SetEdgeMode(forWdht, EdgeMode.Aliased);
                    }
                IL_239:
                forWdht.SnapsToDevicePixels = true;
                forWdht.RenderTransform = new ScaleTransform(1.0, 1.0, 0.5, 0.5);
                if(-1 == 0)
                    {
                    goto IL_66;
                    }
                IL_272:
                IL_273:
                forWdht.Measure(size);
                forWdht.Arrange(new Rect(size));
                renderTargetBitmap.Render(forWdht);
                forWdht.RenderTransform = null;
                IL_297:
                result = renderTargetBitmap;
                }
            catch(Exception serviceException)
                {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                result = renderTargetBitmap;
                }
            finally
                {
                }
            return result;
            }
        }    
    }
