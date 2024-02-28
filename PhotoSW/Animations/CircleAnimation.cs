using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

using System.Windows.Media.Animation;
using System.Windows;
using System.Windows.Media.Imaging;
using System.IO;
//using System.Drawing;

namespace PhotoSW.Animations
    {
    public class CircleAnimation
        {
        int count = 1;
        FrameworkElement _animatedElement;

        public event Action AnimationCompleted;
        public void MakeCircleAnimation ( FrameworkElement animatedElement, double width, double height, TimeSpan timeSpan )
        {
            _animatedElement = animatedElement;
            EllipseGeometry ellipseGeometry = new EllipseGeometry();
            ellipseGeometry.RadiusX = 0;
            ellipseGeometry.RadiusY = 0;
            double centrex = width / 2;
            double centrey = height / 2;
            ellipseGeometry.Center = new System.Windows.Point(centrex, centrey);
            animatedElement.Clip = ellipseGeometry; //The most important line           
            double halfWidth = width / 2;
            double halfheight = height / 2;
            DoubleAnimation a = new DoubleAnimation();
           // a.Completed += new EventHandler(a_Completed);
            a.From = 0;
            a.To = Math.Sqrt(halfWidth * halfWidth + halfheight * halfheight);
            a.Duration = new Duration(timeSpan);
            ellipseGeometry.BeginAnimation(EllipseGeometry.RadiusXProperty, a);
            ellipseGeometry.BeginAnimation(EllipseGeometry.RadiusYProperty, a);
            
        }

        void a_Completed ( object sender, EventArgs e )
            {
            if(AnimationCompleted != null)
                {
                AnimationCompleted();
                }
            }

        public void SaveCircleAnimation ( System.Drawing.Image animatedElement, double width, double height, Uri imagepath, int duration,string img)
            {
            float vRes = animatedElement.VerticalResolution;
            float hRes = animatedElement.HorizontalResolution;

            double x = animatedElement.Width * (96 / hRes);
            double y = animatedElement.Height * (96 / vRes);

            double halfWidth = x / 2;
            double halfheight = y / 2;

            double circleradius = Math.Sqrt(halfWidth * halfWidth + halfheight * halfheight);

            int steps = (int)circleradius / ((duration / 1000) * 30);
            
            for(int i = 0; i < circleradius; i += steps)
                {

                System.Drawing.Color backGround = System.Drawing.Color.Black;
                System.Drawing.Image dstImage = new System.Drawing.Bitmap((int)x, (int)y, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dstImage);

                using(System.Drawing.Brush br = new System.Drawing.SolidBrush(backGround))
                    {
                    g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
                    }
                System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddEllipse(((int)x / 2) - i, ((int)y / 2) - i, 2 * i, 2 * i);
                g.SetClip(path);
                g.DrawImage(animatedElement, 0, 0);

                string filename = string.Empty;
                if(count < 10)
                    {                 
                    filename = img.Replace(".jpg", "_0") + count.ToString() + ".png";
                    }
                else
                    {                   
                    filename = img.Replace(".jpg", "_") + count.ToString() + ".png";
                    }
                string imgPath = PhotoSW.Views.MainWindow.fileHotPath;
                string hotpath = imgPath.Replace("Thumbnails_Big", "");

                if(!Directory.Exists(System.IO.Path.Combine(hotpath, "CircleAnimation")))
                    {
                    Directory.CreateDirectory(System.IO.Path.Combine(hotpath, "CircleAnimation"));
                    }

                string filepath = hotpath + "CircleAnimation\\" + filename;

              //  string filepath = @"E:\GIFS\" + filename;
                dstImage.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);
                //encoder.AddFrame(System.Drawing.Image.FromFile(filepath));
                count = count + 1;

                }

            }



        //public void SaveCircleAnimation(System.Drawing.Image animatedElement, double width, double height, Uri imagepath)
        //{
        //    float vRes = animatedElement.VerticalResolution;
        //    float hRes = animatedElement.HorizontalResolution;

        //    double x = animatedElement.Width *(96 / hRes);
        //    double y = animatedElement.Height * (96 / vRes);

        //    double halfWidth = x / 2;
        //    double halfheight = y / 2;           

        //    double circleradius = Math.Sqrt(halfWidth * halfWidth + halfheight * halfheight);

        //    for (int i = 0; i < circleradius; i++)
        //    {

        //        System.Drawing.Color backGround = System.Drawing.Color.Black;
        //        System.Drawing.Image dstImage = new System.Drawing.Bitmap((int)x, (int)y, System.Drawing.Imaging.PixelFormat.Format32bppArgb);               
        //        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(dstImage);               
        //        using (System.Drawing.Brush br = new System.Drawing.SolidBrush(backGround))
        //        {
        //            g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
        //        }
        //        System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
        //        path.AddEllipse(((int)x / 2) - i, ((int)y / 2) - i, 2 * i, 2 * i);
        //        g.SetClip(path);
        //        g.DrawImage(animatedElement, 0, 0);
        //        if(count % 2 == 0)
        //            {
        //            string filename = "Test" + count.ToString() + ".png";
        //            string filepath = @"E:\GIFS\" + filename;
        //            dstImage.Save(filepath, System.Drawing.Imaging.ImageFormat.Png);                  
        //            }
        //        count = count + 1;
        //        }
        //}


        }

    }
