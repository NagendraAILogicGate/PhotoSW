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
    public class BlockAnimation
    {
        DispatcherTimer _timer = null;
        PathGeometry pathGeometry = null;
        double _rectangleSize = 40;
        double _numberofrectangles = 0;
        RandomNumberFromAGivenSetOfNumbers rdm = null;
        int _numberOfalreadyDrawnRectangles = 0;
        double _height = 0;
        double _width = 0;
        int count = 1;
        FrameworkElement _animatedElement = null;
        public event Action AnimationCompleted;
        public bool _status = false;
        public static string GIFPath;
        string _filename = String.Empty;
        public void MakeBlockAnimation(FrameworkElement animatedElement, double width, double height, TimeSpan timeSpan, string filename)
        {
            _filename = filename;
            _animatedElement = animatedElement;
            _height = width;
            _width = height;
            if (_height > _width)
            {
                _numberofrectangles = Math.Ceiling(_height / _rectangleSize);
            }
            else
            {
                _numberofrectangles = Math.Ceiling(_width / _rectangleSize);

            }

            rdm = new RandomNumberFromAGivenSetOfNumbers(0, Convert.ToInt32(_numberofrectangles * _numberofrectangles - 1));

            double steps = _numberofrectangles * _numberofrectangles;
            double tickTime = timeSpan.TotalSeconds / steps;

            pathGeometry = new PathGeometry();
            _animatedElement.Clip = pathGeometry;
            _timer = new DispatcherTimer(DispatcherPriority.Input);
            _timer.Interval = TimeSpan.FromSeconds(tickTime);
            //_timer.Interval = TimeSpan.FromSeconds(10);
            //_timer.Tick += new EventHandler(_timer_Tick);
            _timer.Tick += _timer_Tick;
            _timer.IsEnabled = true;

        }
        private void _timer_Tick(object sender, EventArgs e)
        {
            //try
            //{
            
            int random = rdm.Next();
            int i = random / (int)_numberofrectangles;
            int j = random % (int)_numberofrectangles;
            RectangleGeometry myRectGeometry2 = new RectangleGeometry();
            myRectGeometry2.Rect = new Rect(j * _rectangleSize, i * _rectangleSize, _rectangleSize, _rectangleSize);
            pathGeometry = Geometry.Combine(pathGeometry, myRectGeometry2, GeometryCombineMode.Union, null);
            _animatedElement.Clip = pathGeometry;

            if (!_status)
            //if(_numberOfalreadyDrawnRectangles < _numberofrectangles * _numberofrectangles)
            {

                //   RenderTargetBitmap bmp = new RenderTargetBitmap(Convert.ToInt32(_animatedElement.ActualWidth), Convert.ToInt32(_animatedElement.ActualHeight), 120, 96, PixelFormats.Pbgra32);
                RenderTargetBitmap bmp = new RenderTargetBitmap(400, 280, 120, 96, PixelFormats.Pbgra32);
                bool result = Convert.ToBoolean( Application.Current.Properties["Result"]);
                if(!result)
                {
                    BlockPhotoSave bps = new BlockPhotoSave();
                    bps.SaveBlockImage(bmp, _animatedElement, _filename, count, _numberofrectangles);
                }                

                //if (count < 10)
                //{
                //    filename = _filename.Replace(".jpg", "_0") + count.ToString() + ".png";
                //}
                //else
                //{
                //    filename = _filename.Replace(".jpg", "_") + count.ToString() + ".png";
                //}

            }



            if (_numberOfalreadyDrawnRectangles == _numberofrectangles * _numberofrectangles)
            {
                _timer.IsEnabled = false;
                if (AnimationCompleted != null)
                {
                    AnimationCompleted();
                }
            }

            _numberOfalreadyDrawnRectangles++;
            if(count < 99)
            count = count + 1;

            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

    }
}
