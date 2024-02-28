using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.IO;

namespace PhotoSW.Animations
    {
   public  class InterlacedAnimation
        {

        DispatcherTimer _timer = null;
        PathGeometry pathGeometry = null;
        double _rectangleSize = 3;
        double _startingCoordinate = 0;
        double _endcoordinate = 0;
        FrameworkElement _animatedElement = null;
        double _width = 0;
        double _height = 0;
        double _offset = 0.5;
        bool IsTimerShouldBeStoppedForUp = false;
        bool IsTimerShouldBeStoppedForDown = false;
        public event Action AnimationCompleted;

        public void MakeInterlacedAnimation ( FrameworkElement animatedElement, double width, double height, TimeSpan timeSpan )
            {
            double steps = (height / (_rectangleSize + _offset));
            double tickTime = timeSpan.TotalSeconds / steps;
            _animatedElement = animatedElement;
            _width = width;
            _height = height;
            _endcoordinate = height;
            pathGeometry = new PathGeometry();
            animatedElement.Clip = pathGeometry;
            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(tickTime);
            _timer.Tick += new EventHandler(_timer_Tick);
            _timer.IsEnabled = true;
            }

        private void _timer_Tick ( object sender, EventArgs e )
            {

            if(IsTimerShouldBeStoppedForUp == true && IsTimerShouldBeStoppedForDown == true)
                {
                _timer.IsEnabled = false;
                if(AnimationCompleted != null)
                    {
                    AnimationCompleted();
                    }
                }

            if(_startingCoordinate == _endcoordinate)
                {
                _offset = 0;
                }
            if(_startingCoordinate >= (_height / 2 - 5))
                _offset = 0;
            if(_endcoordinate <= (_height / 2 - 5))
                _offset = 0;

            if(_startingCoordinate < _height)
                {
                RectangleGeometry myRectGeometry2 = new RectangleGeometry();
                myRectGeometry2.Rect = new Rect(0, _startingCoordinate, _width, _rectangleSize);
                pathGeometry = Geometry.Combine(pathGeometry, myRectGeometry2, GeometryCombineMode.Union, null);
                }
            else
                {
                IsTimerShouldBeStoppedForUp = true;
                }

            if(_endcoordinate > 0)
                {
                RectangleGeometry myRectGeometry3 = new RectangleGeometry();
                myRectGeometry3.Rect = new Rect(0, _endcoordinate, _width, _rectangleSize);
                pathGeometry = Geometry.Combine(pathGeometry, myRectGeometry3, GeometryCombineMode.Union, null);
                }
            else
                {
                IsTimerShouldBeStoppedForDown = true;
                }

            _startingCoordinate = _startingCoordinate + _rectangleSize + _offset;
            _endcoordinate = _endcoordinate - _rectangleSize - _offset;
            _animatedElement.Clip = pathGeometry;

            //Image myImage = new Image();
            GeometryDrawing aGeometryDrawing = new GeometryDrawing();
            aGeometryDrawing.Geometry = pathGeometry;
            DrawingImage geometryImage = new DrawingImage(aGeometryDrawing);

            // Freeze the DrawingImage for performance benefits.
            geometryImage.Freeze();
            DrawingVisual drawingVisual = new DrawingVisual();
            DrawingContext drawingContext = drawingVisual.RenderOpen();
            drawingContext.DrawImage(geometryImage, new Rect(0, 0, _width, _height));
            //drawingContext.DrawText(text, new Point(bi.Height / 2, 0));
            drawingContext.Close();
            RenderTargetBitmap bmp = new RenderTargetBitmap(180, 180, 120, 96, PixelFormats.Pbgra32);
            bmp.Render(drawingVisual);

            PngBitmapEncoder png = new PngBitmapEncoder();
            png.Frames.Add(BitmapFrame.Create(bmp));
            //int count = 1;
            using (Stream stm = File.Create(@"E:\new.png" ))
            {
                png.Save(stm);
            }

        }
        
        }
    }
