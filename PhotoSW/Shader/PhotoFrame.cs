using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Effects;

namespace PhotoSW.Shader
    {
    public partial class PhotoFrame : ShaderEffect
        {

        //public static readonly DependencyProperty IntervalProperty =
        //    DependencyProperty.Register("Interval", typeof(TimeSpan), typeof(PhotoFrame), new UIPropertyMetadata(TimeSpan.FromSeconds(5), new PropertyChangedCallback(HandleIntervalChanged)));

        //public static readonly DependencyProperty ImageFolderProperty =
        //    DependencyProperty.Register("ImageFolder", typeof(string), typeof(PhotoFrame), new UIPropertyMetadata(null, new PropertyChangedCallback(HandleImageFolderChanged)));

        public static readonly DependencyProperty IntervalProperty =
         DependencyProperty.Register("Interval", typeof(TimeSpan), typeof(PhotoFrame), new UIPropertyMetadata(TimeSpan.FromSeconds(5), ShaderEffect.PixelShaderConstantCallback(0)));

        public static readonly DependencyProperty ImageFolderProperty =
            DependencyProperty.Register("ImageFolder", typeof(string), typeof(PhotoFrame), new UIPropertyMetadata(null, ShaderEffect.PixelShaderConstantCallback(1)));
                
        private static void HandleIntervalChanged ( DependencyObject sender, DependencyPropertyChangedEventArgs e )
            {
            var ctrl = (PhotoSW.Views.MainWindow)sender;
            var phots = (PhotoFrame)sender;
            ctrl.InitializeStoryboards();
            ctrl.m_switchImageTimer.Interval = phots.Interval;
            // Force a load of the next image to make sure the switch timer and storyboards have the same duration
            ctrl.LoadNextImage();
            }

        private static void HandleImageFolderChanged ( DependencyObject sender, DependencyPropertyChangedEventArgs e )
            {
            var ctrl = (PhotoSW.Views.MainWindow)sender;
            ctrl.LoadFolder((string)e.NewValue);
          
            ctrl.LoadNextImage();
            }

        public TimeSpan Interval
            {
            get { return (TimeSpan)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
            }
        public string ImageFolder
            {
            get { return (string)GetValue(ImageFolderProperty); }
            set { SetValue(ImageFolderProperty, value); }
            }

        public PhotoFrame()
            {

            }
        }
    }
