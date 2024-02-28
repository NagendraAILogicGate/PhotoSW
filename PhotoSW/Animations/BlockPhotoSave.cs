using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using System.IO;

namespace PhotoSW.Animations
{
    
    public class BlockPhotoSave
    {
        DispatcherTimer _timer = null;
        PathGeometry pathGeometry = null;
        FrameworkElement _animatedElement = null;
        int _numberOfalreadyDrawnRectangles = 0;
        double numberofrectangles = 0;
        RandomNumberFromAGivenSetOfNumbers rdm = null;
        int _count = 0;
        public void SaveBlockImage(RenderTargetBitmap bmp, FrameworkElement animatedElement,string _filename, int count, double _numberofrectangles)
        {
            rdm = new RandomNumberFromAGivenSetOfNumbers(0, Convert.ToInt32(_numberofrectangles * _numberofrectangles - 1));
            pathGeometry = new PathGeometry();
            _timer = new DispatcherTimer(DispatcherPriority.Input);
            _timer.Interval = TimeSpan.FromSeconds(1000);
            //_timer.Interval = TimeSpan.FromSeconds(10);
            //_timer.Tick += new EventHandler(_timer_Tick);
            numberofrectangles = _numberofrectangles;
            _timer.Tick += _timer_Tick;
            _timer.IsEnabled = true;
            _count = count;
            bmp.Render(animatedElement);
            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(bmp));
            string filename = String.Empty;

            if (count < 10)
            {
                filename = _filename.Replace(".jpg", "_0") + count.ToString() + ".png";
            }
            else
            {
                filename = _filename.Replace(".jpg", "_") + count.ToString() + ".png";
            }

            string imgPath = PhotoSW.Views.MainWindow.fileHotPath;
            //   string filepath = @"E:\GIFTest\" + filename;

            string hotpath = imgPath.Replace("Thumbnails_Big", "");

            if (!Directory.Exists(System.IO.Path.Combine(hotpath, "BlockAnimation")))
            {
                Directory.CreateDirectory(System.IO.Path.Combine(hotpath, "BlockAnimation"));
            }

            string filepath = hotpath + "BlockAnimation\\" + filename;

            using (Stream stm = File.Create(filepath)) ///////////////////////////
            {
                png.Save(stm);
            }

        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            try
            {
                int random = rdm.Next();
                int i = random / (int)0;
                int j = random % (int)0;
                RectangleGeometry myRectGeometry2 = new RectangleGeometry();
                myRectGeometry2.Rect = new Rect(j * 40, i * 40, 40, 40);
                pathGeometry = Geometry.Combine(pathGeometry, myRectGeometry2, GeometryCombineMode.Union, null);
                _animatedElement.Clip = pathGeometry;


                //  RenderTargetBitmap bmp = new RenderTargetBitmap(Convert.ToInt32(_animatedElement.ActualWidth), Convert.ToInt32(_animatedElement.ActualHeight), 120, 96, PixelFormats.Pbgra32);
                RenderTargetBitmap bmp = new RenderTargetBitmap(400, 280, 120, 96, PixelFormats.Pbgra32);
                BlockPhotoSave bps = new BlockPhotoSave();


                //if (_numberOfalreadyDrawnRectangles == numberofrectangles * numberofrectangles)
                //{
                //    _timer.IsEnabled = false;
                //    if (AnimationCompleted != null)
                //    {
                //        AnimationCompleted();
                //    }
                //}

                _numberOfalreadyDrawnRectangles++;
                _count = _count + 1;
            }
            catch (Exception)
            {
                throw;
            }
            
        }

    }
}
