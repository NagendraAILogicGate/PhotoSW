/// Sample photo frame control
/// Written by Isak Savo <isak.savo@gmail.com> for Code Project. 
/// Licensed under the Code Project Open License (http://www.codeproject.com/info/cpol10.aspx)
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using System.ComponentModel;

namespace PhotoSW.Views
    {
	
    public partial class PhotoFrame : UserControl
        {
        #region Dependency Properties
        
		public TimeSpan Interval
		{
			get { return (TimeSpan)GetValue(IntervalProperty); }
			set { SetValue(IntervalProperty, value); }
		}


		public static readonly DependencyProperty IntervalProperty =
			DependencyProperty.Register("Interval", typeof(TimeSpan), typeof(PhotoFrame), new UIPropertyMetadata(TimeSpan.FromSeconds(5), new PropertyChangedCallback(HandleIntervalChanged)));

		
		public string ImageFolder
		{
			get { return (string)GetValue(ImageFolderProperty); }
			set { SetValue(ImageFolderProperty, value); }
		}


		public static readonly DependencyProperty ImageFolderProperty =
			DependencyProperty.Register("ImageFolder", typeof(string), typeof(PhotoFrame), new UIPropertyMetadata(null, new PropertyChangedCallback(HandleImageFolderChanged)));

		static void HandleIntervalChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var ctrl = (PhotoFrame)sender;
            ctrl.InitializeStoryboards();
            ctrl.m_switchImageTimer.Interval = ctrl.Interval;
            ctrl.LoadNextImage();
		}

		static void HandleImageFolderChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
		{
			var ctrl = (PhotoFrame)sender;
			ctrl.LoadFolder((string)e.NewValue);
			//if (e.OldValue == null)
				ctrl.LoadNextImage();
		}
        #endregion

        private List<ImageSource> m_images = new List<ImageSource>();
		private int m_currentSourceIndex;
		private int m_currentCtrlIndex;
		private static string[] ValidExtensions = new[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };
		private Image[] m_imageControls;
		private Storyboard m_moveStoryboard;
        private Storyboard n_moveStoryboard;
        private DispatcherTimer m_switchImageTimer;
        private int imgCount = 0;
        private int boxImg = 0;
		public PhotoFrame()
		{
			InitializeComponent();
			InitializeStoryboards();
			m_imageControls = new [] { c_image1, c_image2 };

			m_switchImageTimer = new DispatcherTimer();
			m_switchImageTimer.Interval = Interval;
			m_switchImageTimer.Tick += (s, e) => LoadNextImage();
            if(System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == false)
                {
                this.Loaded += ( s, e ) => m_switchImageTimer.Start();
                this.Unloaded += ( s, e ) => m_switchImageTimer.Stop();
                }
            }

        public PhotoFrame (int value)
            {
            InitializeComponent();
            InitializeStoryboards();
            m_imageControls = new[] { c_image1 }; /*{ c_image1, c_image2 };*/

            m_switchImageTimer = new DispatcherTimer();
            m_switchImageTimer.Interval = Interval;
            m_switchImageTimer.Tick += ( s, e ) => LoadNextImage(value);
            if(System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == false)
                {
                this.Loaded += ( s, e ) => m_switchImageTimer.Start();
                this.Unloaded += ( s, e ) => m_switchImageTimer.Stop();
                }
            }

        private void InitializeStoryboards()
		{
			m_moveStoryboard = (Storyboard)FindResource("MoveStoryboard");
            n_moveStoryboard = (Storyboard)FindResource("MoveStoryboard");
            m_moveStoryboard.Duration = new Duration(Interval.Add(TimeSpan.FromSeconds(1)));
			foreach (var child in m_moveStoryboard.Children)
			{
                child.Duration = m_moveStoryboard.Duration;
				Storyboard.SetTargetName(child, "");
			}
		}

		public void LoadNextImage()
		{
            int count = m_images.Count;
            
			if (m_images.Count == 0)
				return;
			var oldCtrlIndex = m_currentCtrlIndex;
            m_currentCtrlIndex = (m_currentCtrlIndex + 1) % 2;
			m_currentSourceIndex = (m_currentSourceIndex + 1) % m_images.Count;

			Image oldImage = m_imageControls[oldCtrlIndex];
			Image newImage = m_imageControls[m_currentCtrlIndex];
			ImageSource newSource = m_images[m_currentSourceIndex];
			newImage.Source = newSource;
			 if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == false)
			{
                int value = MainWindow.dropdownGiFAnimation;
                if (value == 1)
                {
                    //BeginFadeInImage(newImage);
                    //BeginFadeOutImage(oldImage);

                    string strFileName = newImage.Source.ToString().Substring(newImage.Source.ToString().LastIndexOf("/") + 1, (newImage.Source.ToString().Length - newImage.Source.ToString().LastIndexOf("/")) - 1);

                    Application.Current.Properties["Result"] = false;
                    Animations.DissolvedAnimation dissolvedAnimation = new Animations.DissolvedAnimation();
                    dissolvedAnimation.MakeZoomAnimation(newImage, oldImage, new TimeSpan(0, 0, 1), strFileName, this.fwdWidth);

                }
                else if (value == 2)
                {
                    if (imgCount == 0)
                    {
                        BeginFadeInImage(newImage);
                        BeginFadeOutImage(oldImage);
                        imgCount = 1;
                    }
                    else
                    {
                        //string strFileName = newSource.ToString().Substring(newSource.ToString().LastIndexOf("/") + 1, (newSource.ToString().Length - newSource.ToString().LastIndexOf("/")) - 1);
                        Application.Current.Properties["Result"] = false;
                        Animations.CircleAnimation circleAnimationHelper = new Animations.CircleAnimation();
                        circleAnimationHelper.MakeCircleAnimation((FrameworkElement)newImage, 400, 300, new TimeSpan(0, 0, 1));
                    }
                }
                else if (value == 3)
                {
                    if (imgCount == 0)
                    {
                        BeginFadeInImage(newImage);
                        BeginFadeOutImage(oldImage);
                        imgCount = 1;
                        Application.Current.Properties["Result"] = false;
                    }
                    else
                    {
                        
                        string strFileName = newImage.Source.ToString().Substring(newImage.Source.ToString().LastIndexOf("/") + 1, (newImage.Source.ToString().Length - newImage.Source.ToString().LastIndexOf("/")) - 1);

                        Animations.BlockAnimation_old blockAnimationHelper = new Animations.BlockAnimation_old();
                        //if (m_currentCtrlIndex >= m_images.Count)
                        //{
                        //    blockAnimationHelper._status = true;
                        //}
                        blockAnimationHelper.MakeBlockAnimation((FrameworkElement)newImage, 400, 300, new TimeSpan(0, 0, 1), strFileName);
                       // MessageBox.Show();
                        
                    }
                }
                else if (value == 4)
                {
                    if (imgCount == 0)
                    {
                        BeginFadeInImage(newImage);
                        BeginFadeOutImage(oldImage);
                        imgCount = 1;
                    }
                    else
                    {
                        string strFileName = newImage.Source.ToString().Substring(newImage.Source.ToString().LastIndexOf("/") + 1, (newImage.Source.ToString().Length - newImage.Source.ToString().LastIndexOf("/")) - 1);

                        Animations.WaterFallAnimation interlacedAnimation = new Animations.WaterFallAnimation();
                        count = count + 1;
                        if (m_currentCtrlIndex > m_images.Count)
                        {
                            interlacedAnimation._status = true;
                        }

                        interlacedAnimation.MakeWaterFallAnimation((FrameworkElement)newImage, 400, 300, new TimeSpan(0, 0, 1), strFileName);

                    }
                }
                else if (imgCount == 0)
                {
                    Application.Current.Properties["Result"] = false;
                    CreateAndStartKenBurnsEffect(newImage);
                }
			} 
		}

        //public void MakeCircleAnimation ( FrameworkElement animatedElement, double width, double height, TimeSpan timeSpan )
        //    {
        //    EllipseGeometry ellipseGeometry = new EllipseGeometry();
        //    ellipseGeometry.RadiusX = 0;
        //    ellipseGeometry.RadiusY = 0;
        //    double centrex = width / 2;
        //    double centrey = height / 2;
        //    ellipseGeometry.Center = new Point(centrex, centrey);
        //    animatedElement.Clip = ellipseGeometry; //The most important line           
        //    double halfWidth = width / 2;
        //    double halfheight = height / 2;
        //    DoubleAnimation a = new DoubleAnimation();
        //    a.Completed += new EventHandler(a_Completed);
        //    a.From = 0;
        //    a.To = Math.Sqrt(halfWidth * halfWidth + halfheight * halfheight);
        //    a.Duration = new Duration(timeSpan);
        //    ellipseGeometry.BeginAnimation(EllipseGeometry.RadiusXProperty, a);
        //    ellipseGeometry.BeginAnimation(EllipseGeometry.RadiusYProperty, a);

        //    }
        public void LoadNextImage (int value)
            {
            if(m_images.Count == 0)
                return;
            var oldCtrlIndex = m_currentCtrlIndex;
            m_currentCtrlIndex = (m_currentCtrlIndex + 1) % 2;
            m_currentSourceIndex = (m_currentSourceIndex + 1) % m_images.Count;

            Image oldImage = m_imageControls[oldCtrlIndex];
            Image newImage = m_imageControls[m_currentCtrlIndex];
            ImageSource newSource = m_images[m_currentSourceIndex];
            newImage.Source = newSource;
            if(System.ComponentModel.DesignerProperties.GetIsInDesignMode(this) == false)
                {
                BeginFadeInImage(newImage);
                BeginFadeOutImage(oldImage);
                CreateAndStartKenBurnsEffect(newImage,value);
                }
            }

        private void BeginFadeInImage(Image img)
		{            
			var fadeIn = new DoubleAnimation(0.0, 1.0, new Duration(TimeSpan.FromSeconds(2.0)));
			fadeIn.Freeze();
			img.BeginAnimation(UIElement.OpacityProperty, fadeIn);
		}

      
        private void BeginFadeOutImage(Image img)
        {
            var fadeOut = new DoubleAnimation(1.0, 0.0, new Duration(TimeSpan.FromSeconds(2.0)));           
            fadeOut.Freeze();
            img.BeginAnimation(UIElement.OpacityProperty, fadeOut);
        }


        private void CreateAndStartKenBurnsEffect ( Image img )
            {
            var rand = new Random();
            double scaleFrom = rand.Next(1100, 1500) / 1000.0;
            double scaleTo = rand.Next(1100, 1500) / 1000.0;
            //PhotoSW.IMIX.Business.TestPhotoFrame test = new IMIX.Business.TestPhotoFrame();
            int value = MainWindow.dropdownGiFAnimation;
           
                foreach(var child in m_moveStoryboard.Children)
                    {
                    var dblAnim = child as DoubleAnimation;
                    if(dblAnim != null)
                        {
                        if(value == 0)
                            {
                            if( dblAnim.Name == "moveY")
                                {
                                dblAnim.To = rand.Next(-1, 1);
                                //  dblAnim.To =  400;
                                }
                            }
                        else
                            {
                            if(dblAnim.Name == "moveY")
                                {
                                dblAnim.To = value;
                                }
                            }

                        //if (dblAnim.Name == "moveX" || dblAnim.Name == "moveY")
                        //    {
                        //        dblAnim.To = rand.Next(-10, 10);               
                        //      //  dblAnim.To =  400;                    
                        //    }

                        //else if (dblAnim.Name == "scaleX" || dblAnim.Name == "scaleY")
                        //{
                        //    dblAnim.To = scaleTo;
                        //    dblAnim.From = scaleFrom;
                        //}

                        dblAnim.Duration = m_moveStoryboard.Duration;
                        }
                    Storyboard.SetTarget(child, img);
                    }
                m_moveStoryboard.Begin(img, true);                
           
            }

        public void CreateAndStartKenBurnsEffect ( Image img , int move)
            {
            var rand = new Random();
            double scaleFrom = rand.Next(1100, 1500) / 1000.0;
            double scaleTo = rand.Next(1100, 1500) / 1000.0;
            foreach(var child in m_moveStoryboard.Children)
                {
                var dblAnim = child as DoubleAnimation;
                if(dblAnim != null)
                    {

                    if(dblAnim.Name == "moveX" || dblAnim.Name == "moveY")
                        {
                        // dblAnim.To = rand.Next(-10, 10);
                        dblAnim.To = move;
                        }

                    else if(dblAnim.Name == "scaleX" || dblAnim.Name == "scaleY")
                        {
                        dblAnim.To = scaleTo;
                        dblAnim.From = scaleFrom;
                        }

                    dblAnim.Duration = m_moveStoryboard.Duration;
                    }
                Storyboard.SetTarget(child, img);
                }
            m_moveStoryboard.Begin(img, true);
            }


        private ImageSource CreateImageSource(string file, bool forcePreLoad)
        {
            if (forcePreLoad)
            {
                var src = new BitmapImage();
                src.BeginInit();
                src.UriSource = new Uri(file, UriKind.Absolute);
                src.CacheOption = BitmapCacheOption.OnLoad;
                src.EndInit();
                src.Freeze();
                return src;
            }
            else
            {
                var src = new BitmapImage(new Uri(file, UriKind.Absolute));
                src.Freeze();
                return src;
            }
        }

       
        private void LoadFolder(string folder)
		{
            c_errorText.Visibility = Visibility.Collapsed;
            var sw = System.Diagnostics.Stopwatch.StartNew();
			if (!System.IO.Path.IsPathRooted(folder))
				folder = System.IO.Path.Combine(Environment.CurrentDirectory, folder);
            if (!System.IO.Directory.Exists(folder))
            {
                c_errorText.Text = "The specified folder does not exist: " + Environment.NewLine + folder;
                c_errorText.Visibility = Visibility.Visible;                
                return;
            }
			Random r = new Random();
            //folder = @"F:\PhotoSW_19Sep\PhotoSW\bin\Debug\HotFolderPath\Thumbnails_Big\GIFImages";
            var sources = from file in new System.IO.DirectoryInfo(folder).GetFiles().AsParallel()
                          where ValidExtensions.Contains(file.Extension, StringComparer.InvariantCultureIgnoreCase)
                          orderby r.Next()
                          select CreateImageSource(file.FullName, true);
            m_images.Clear();
			 m_images.AddRange(sources);
            sw.Stop();
           
		}

        private int _value;
        public int value
            {
            get { return this._value; }
            set { this._value = value; }
            }

       
        }
}
