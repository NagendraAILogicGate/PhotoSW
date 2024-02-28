using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;

namespace PhotoSW.Animations
    {
    public class CircleAnimation_old
        {
        int count = 1;
        public event Action AnimationCompleted;
        DispatcherTimer _timer = null;
        EllipseGeometry ellipseGeometry = null;  //new EllipseGeometry();
        FrameworkElement _animatedElement = null;
        public bool _status = false;
        string _filename = String.Empty;
        double Width;
        double Height;
        TimeSpan timeCount = new TimeSpan();
        public void MakeCircleAnimation ( FrameworkElement animatedElement, double width, double height, TimeSpan timeSpan, string filename )
            {
            ellipseGeometry = new EllipseGeometry();
            _animatedElement = animatedElement;
            ellipseGeometry.RadiusX = 0;
            ellipseGeometry.RadiusY = 0;
            double centrex = width / 2;
            double centrey = height / 2;
            _filename = filename;
            double tickTime = timeSpan.TotalSeconds ;
            ellipseGeometry.Center = new Point(centrex, centrey);
            animatedElement.Clip = ellipseGeometry;       
            _timer = new DispatcherTimer(DispatcherPriority.Input);
            _timer.Interval = TimeSpan.FromSeconds(tickTime);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.IsEnabled = true;
            Width = width;
            Height = height;
            timeCount = timeSpan;            
           
            }

        private void _timer_Tick ( object sender, EventArgs e )
            {

            double halfWidth = Width / 2;
            double halfheight = Height / 2;
            DoubleAnimation a = new DoubleAnimation();
            a.Completed += new EventHandler(a_Completed);
            a.From = 0;
            a.To = Math.Sqrt(halfWidth * halfWidth + halfheight * halfheight);
            a.Duration = new Duration(timeCount);
            ellipseGeometry.BeginAnimation(EllipseGeometry.RadiusXProperty, a);
            ellipseGeometry.BeginAnimation(EllipseGeometry.RadiusYProperty, a);
            _animatedElement.Clip = ellipseGeometry;

            string fileName = String.Empty;
            string imgPath = PhotoSW.Views.MainWindow.fileHotPath;

            string hotpath = imgPath.Replace("Thumbnails_Big", "");
            fileName = _filename.Replace(".jpg", "_0") + count.ToString() + ".png";

            if(!Directory.Exists(System.IO.Path.Combine(hotpath, "CircleAnimation")))
                {
                Directory.CreateDirectory(System.IO.Path.Combine(hotpath, "CircleAnimation"));
                }

            string filepath = hotpath + "CircleAnimation\\" + fileName;

            RenderTargetBitmap source = new RenderTargetBitmap(Convert.ToInt32(_animatedElement.ActualWidth), Convert.ToInt32(_animatedElement.ActualHeight), 120, 96, PixelFormats.Pbgra32);
            source.Render(_animatedElement);

            using(FileStream fileStream = new FileStream(filepath, FileMode.Create, FileAccess.ReadWrite))
                {
                new JpegBitmapEncoder
                    {
                    QualityLevel = 95,
                    Frames =
                {
                BitmapFrame.Create(source)
                }
                    }.Save(fileStream);
                }

            count = count + 1;

            }
            void a_Completed ( object sender, EventArgs e )
            {
            if(AnimationCompleted != null)
                {
                AnimationCompleted();
                }
            }

      
        }
    }
