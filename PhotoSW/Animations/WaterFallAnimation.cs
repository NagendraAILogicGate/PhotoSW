using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

namespace PhotoSW.Animations
{
    public class WaterFallAnimation
    {

        DispatcherTimer _timer = null;
        PathGeometry pathGeometry = null;
        double _rectangleSize = 10 + 50;
        double _offset = 5;
        int _waterFallHeight = 50;
        double _width = 0;
        double _height = 0;
        Random random = new Random();
        FrameworkElement _animatedElement = null;
        RectangleGeometry myRectGeometry2 = null;
        PathGeometry pathGeometry2 = null;
        RectangleGeometry myRectGeometry5 = null;
        public event Action AnimationCompleted;
        int count = 1;
        string _filename = String.Empty;
        public static List<string> listAnimationGif = new List<string>();
        public bool _status= false;
        public static string GIFPath;
        public void MakeWaterFallAnimation(FrameworkElement animatedElement, double width, double height, TimeSpan timeSpan,string filename)
        {
            _animatedElement = animatedElement;
            _height = height;
            _width = width;
            _filename = filename;
            myRectGeometry2 = new RectangleGeometry();
            pathGeometry2 = new PathGeometry();
            myRectGeometry5 = new RectangleGeometry();
            double steps = (_height / _offset);
            double tickTime = timeSpan.TotalSeconds / steps;
            pathGeometry = new PathGeometry();
            animatedElement.Clip = pathGeometry;
            _timer = new DispatcherTimer(DispatcherPriority.Input);
            _timer.Interval = TimeSpan.FromSeconds(tickTime);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.IsEnabled = true;
        }
                               

        private void _timer_Tick(object sender, EventArgs e)
        {
            myRectGeometry2.Rect = new Rect(0, 0, _width, _rectangleSize);
            pathGeometry2 = Geometry.Combine(pathGeometry2, myRectGeometry2, GeometryCombineMode.Union, null);

            for (int i = 1; i <= _width; i = i + 2)
            {
                myRectGeometry5.Rect = new Rect(new Point(i, _rectangleSize), new Point(i + 2, _rectangleSize - random.Next(0, _waterFallHeight)));
                pathGeometry2 = Geometry.Combine(pathGeometry2, myRectGeometry5, GeometryCombineMode.Exclude, null);
            }
            _animatedElement.Clip = pathGeometry2;

            ///////////////////////////////////////////////////////////////////////////////
            if (!_status)
            {

                RenderTargetBitmap bmp = new RenderTargetBitmap(Convert.ToInt32(_animatedElement.ActualWidth), Convert.ToInt32(_animatedElement.ActualHeight), 120, 96, PixelFormats.Pbgra32);
                bmp.Render(_animatedElement);

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
               
               string hotpath =  imgPath.Replace("Thumbnails_Big","");

                if(!Directory.Exists(System.IO.Path.Combine(hotpath, "WaterAnimation")))
                    {
                    Directory.CreateDirectory(System.IO.Path.Combine(hotpath, "WaterAnimation"));
                    }
                
                string filepath = hotpath + "\\WaterAnimation\\" + filename;
               
              

                using(Stream stm = File.Create(filepath)) ///////////////////////////
                    {
                    png.Save(stm);
                    listAnimationGif.Add(filename);
                    }
                }


            ////////////////////////////////////////////
            if (_rectangleSize == _height + _waterFallHeight)
            {
                _timer.IsEnabled = false;
                if (AnimationCompleted != null)
                {
                    AnimationCompleted();
                }
            }
            else
            {
              
            }
            _rectangleSize += _offset;
            count = count + 1;            

        }        

    }
}
