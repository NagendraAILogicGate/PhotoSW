namespace DigiPhoto.ImageGallery
{
    using DigiPhoto.Common;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class UserControl_ManagedImage : UserControl, IComponentConnector
    {
        private bool _contentLoaded;
        private int _decodedPiexlWidth = 0;
        public static ICanGetThumbBitmapImage _thumbBitmapMaker = null;
        public static ICanGetThumbPath _thumbPathMaker = null;
        private Uri _uri;
        private const int c_miniThumbWidth = 0x4b;
        public static DependencyProperty MainHeightProperty = DependencyProperty.Register("MainHeight", typeof(string), typeof(UserControl_ManagedImage), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(UserControl_ManagedImage.OnMainHeightCallback)));
        public static DependencyProperty MainWidthProperty = DependencyProperty.Register("MainWidth", typeof(string), typeof(UserControl_ManagedImage), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(UserControl_ManagedImage.OnMainWidthCallback)));
        private static object s_classLockObj = new object();
        private static Dictionary<ScrollViewer, ScrollViewerInfo> s_hostScrollViewerInfos = new Dictionary<ScrollViewer, ScrollViewerInfo>();
        private static Collection<ScrollViewer> s_hostScrollViewers = new Collection<ScrollViewer>();
        private static Thread s_isInTheViewThread;
        private static Collection<UserControl_ManagedImage> s_miniThumbQueue = new Collection<UserControl_ManagedImage>();
        private static Thread s_miniThumbThread;
        private static Collection<UserControl_ManagedImage> s_priorityThumbQueue = new Collection<UserControl_ManagedImage>();
        private static Thread s_priorityThumbThread;
        private static Collection<UserControl_ManagedImage> s_releaseThumbQueue = new Collection<UserControl_ManagedImage>();
        private static Thread s_releaseThumbThread;
        public static readonly RoutedEvent SourceUriChangedEvent = EventManager.RegisterRoutedEvent("SourceUriChangedEvent", RoutingStrategy.Bubble, typeof(DependencyPropertyChangedEventHandler), typeof(UserControl_ManagedImage));
        public static readonly DependencyProperty SourceUriProperty = DependencyProperty.Register("SourceUri", typeof(Uri), typeof(UserControl_ManagedImage), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(UserControl_ManagedImage.OnSourceUriCallback)));
        internal Grid x_Grid;
        internal Image x_Image;
        internal Image x_ImageThumb;
        internal UserControl_ManagedImage x_MainControl;

        public event RoutedEventHandler SourceUriChanged
        {
            add
            {
                base.AddHandler(SourceUriChangedEvent, value);
            }
            remove
            {
                base.RemoveHandler(SourceUriChangedEvent, value);
            }
        }

        public UserControl_ManagedImage()
        {
            this.InitializeComponent();
        }

        [DebuggerNonUserCode, GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent()
        {
            if (!this._contentLoaded)
            {
                this._contentLoaded = true;
                Uri resourceLocator = new Uri("/FrameworkHelper;component/imagegallery/usercontrol_managedimage.xaml", UriKind.Relative);
                Application.LoadComponent(this, resourceLocator);
            }
        }

        private static BitmapImage MakeBitmapImage(Uri uri, int decodeWidth)
        {
            try
            {
                string localPath = uri.LocalPath;
                if (_thumbPathMaker != null)
                {
                    string uriString = null;
                    if (decodeWidth <= 0x4b)
                    {
                        uriString = _thumbPathMaker.GetMiniThumbPath(localPath, true);
                    }
                    else
                    {
                        uriString = _thumbPathMaker.GetThumbPath(localPath, true);
                    }
                    if (uriString == null)
                    {
                        return MakeBitmapImage_Default(uri, decodeWidth);
                    }
                    return MakeBitmapImage_Default(new Uri(uriString), decodeWidth);
                }
                if (_thumbBitmapMaker != null)
                {
                    BitmapImage image = null;
                    if (decodeWidth <= 0x4b)
                    {
                        image = _thumbBitmapMaker.GetMiniThumb_BitmapImage(localPath, decodeWidth);
                    }
                    else
                    {
                        image = _thumbBitmapMaker.GetThumb_BitmapImage(localPath, decodeWidth);
                    }
                    if (image == null)
                    {
                        return MakeBitmapImage_Default(uri, decodeWidth);
                    }
                    return image;
                }
            }
            catch
            {
            }
            return MakeBitmapImage_Default(uri, decodeWidth);
        }

        private static BitmapImage MakeBitmapImage_Default(Uri uri, int decodeWidth)
        {
            try
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = uri;
                image.DecodePixelWidth = decodeWidth;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.CreateOptions = BitmapCreateOptions.None;
                image.EndInit();
                image.Freeze();
                return image;
            }
            catch
            {
                return null;
            }
        }

        private static void OnMainHeightCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_ManagedImage image = (UserControl_ManagedImage) d;
            string newValue = (string) e.NewValue;
            double result = 0.0;
            if ((newValue != null) && double.TryParse(newValue, out result))
            {
                image.x_MainControl.Height = result;
            }
        }

        private static void OnMainWidthCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_ManagedImage image = (UserControl_ManagedImage) d;
            string newValue = (string) e.NewValue;
            double result = 0.0;
            if ((newValue != null) && double.TryParse(newValue, out result))
            {
                image.x_MainControl.Width = result;
            }
        }

        private static void OnSourceUriCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UserControl_ManagedImage image = (UserControl_ManagedImage) d;
            Uri newValue = (Uri) e.NewValue;
            image._uri = newValue;
            RoutedEventArgs args = new RoutedEventArgs(SourceUriChangedEvent);
            (d as FrameworkElement).RaiseEvent(args);
        }

        private void ReleaseImage()
        {
            this.x_Image.Source = null;
            this._decodedPiexlWidth = 0;
        }

        private void ReleaseMini()
        {
            this.x_Grid.Background = Brushes.Gray;
            this.x_ImageThumb.Source = null;
        }

        public static void s_ActivateThreads()
        {
            if (!((s_miniThumbThread != null) && s_miniThumbThread.IsAlive))
            {
                s_miniThumbThread = new Thread(new ThreadStart(UserControl_ManagedImage.s_miniThumbProcessor));
                s_miniThumbThread.Priority = ThreadPriority.Normal;
                s_miniThumbThread.Start();
            }
            if (!((s_priorityThumbThread != null) && s_priorityThumbThread.IsAlive))
            {
                s_priorityThumbThread = new Thread(new ThreadStart(UserControl_ManagedImage.s_priorityThumbProcessor));
                s_priorityThumbThread.Priority = ThreadPriority.BelowNormal;
                s_priorityThumbThread.Start();
            }
            if (!((s_releaseThumbThread != null) && s_releaseThumbThread.IsAlive))
            {
                s_releaseThumbThread = new Thread(new ThreadStart(UserControl_ManagedImage.s_releaseThumbProcessor));
                s_releaseThumbThread.Priority = ThreadPriority.Lowest;
                s_releaseThumbThread.Start();
            }
            if (!((s_isInTheViewThread != null) && s_isInTheViewThread.IsAlive))
            {
                s_isInTheViewThread = new Thread(new ThreadStart(UserControl_ManagedImage.s_isInTheViewProcessor));
                s_isInTheViewThread.Priority = ThreadPriority.Lowest;
                s_isInTheViewThread.Start();
            }
            while (((!s_miniThumbThread.IsAlive || !s_priorityThumbThread.IsAlive) || !s_releaseThumbThread.IsAlive) || !s_isInTheViewThread.IsAlive)
            {
                Console.WriteLine("Waiting thread: " + s_miniThumbThread.IsAlive.ToString() + " " + s_priorityThumbThread.IsAlive.ToString() + " " + s_releaseThumbThread.IsAlive.ToString() + " " + s_isInTheViewThread.IsAlive.ToString() + " ");
            }
        }

        private static void s_ChildInView(ScrollViewer sv, DependencyObject currentParent)
        {
            if (currentParent.GetType() == typeof(UserControl_ManagedImage))
            {
                UserControl_ManagedImage item = (UserControl_ManagedImage) currentParent;
                if (item.x_MainControl.ActualWidth <= 75.0)
                {
                    item.ReleaseImage();
                }
                else if (item._decodedPiexlWidth != item.x_MainControl.ActualWidth)
                {
                    lock (s_classLockObj)
                    {
                        if (!s_priorityThumbQueue.Contains(item))
                        {
                            s_priorityThumbQueue.Add(item);
                        }
                    }
                }
            }
            else
            {
                int num = 0;
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(currentParent); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(currentParent, i);
                    if (num >= 2)
                    {
                        s_DeepRelease(child);
                    }
                    else if (UIElementInTheView(sv, child))
                    {
                        if (num == 0)
                        {
                            num++;
                        }
                        s_ChildInView(sv, child);
                    }
                    else
                    {
                        if (num == 1)
                        {
                            num++;
                        }
                        s_DeepRelease(child);
                    }
                }
            }
        }

        private static void s_ChildInView_Driver(ScrollViewer sv)
        {
            if (s_hostScrollViewerInfos.ContainsKey(sv))
            {
                ScrollViewerInfo info = s_hostScrollViewerInfos[sv];
                if (info.IsSameInfo(sv))
                {
                    return;
                }
                s_hostScrollViewerInfos[sv] = new ScrollViewerInfo(sv);
            }
            else
            {
                s_hostScrollViewerInfos.Add(sv, new ScrollViewerInfo(sv));
            }
            Console.WriteLine("Running s_ChildInView(sv, sv).");
            lock (s_classLockObj)
            {
                s_priorityThumbQueue.Clear();
                s_releaseThumbQueue.Clear();
            }
            s_ChildInView(sv, sv);
        }

        public static void s_DeactivateThreads()
        {
            try
            {
                s_miniThumbThread.Abort();
            }
            catch
            {
            }
            try
            {
                s_priorityThumbThread.Abort();
            }
            catch
            {
            }
            try
            {
                s_releaseThumbThread.Abort();
            }
            catch
            {
            }
            try
            {
                s_isInTheViewThread.Abort();
            }
            catch
            {
            }
        }

        private static void s_DeepRelease(DependencyObject currentParent)
        {
            if (currentParent.GetType() == typeof(UserControl_ManagedImage))
            {
                UserControl_ManagedImage item = (UserControl_ManagedImage) currentParent;
                if (item.x_Image.Source != null)
                {
                    lock (s_classLockObj)
                    {
                        if (!s_releaseThumbQueue.Contains(item))
                        {
                            s_releaseThumbQueue.Add(item);
                        }
                    }
                }
            }
            else
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(currentParent); i++)
                {
                    s_DeepRelease(VisualTreeHelper.GetChild(currentParent, i));
                }
            }
        }

        private static void s_isInTheViewProcessor()
        {
            while (true)
            {
                foreach (ScrollViewer viewer in s_hostScrollViewers)
                {
                    delegate_Void_SV method = new delegate_Void_SV(UserControl_ManagedImage.s_ChildInView_Driver);
                    viewer.Dispatcher.Invoke(method, new object[] { viewer });
                }
                Console.WriteLine(string.Concat(new object[] { "s_isInTheViewProcessor Update: ", s_priorityThumbQueue.Count, " Release: ", s_releaseThumbQueue.Count }));
                Thread.Sleep(0x3e8);
            }
        }

        private static void s_miniThumbProcessor()
        {
            while (true)
            {
                try
                {
                    UserControl_ManagedImage image = null;
                    lock (s_miniThumbQueue)
                    {
                        if (s_miniThumbQueue.Count > 0)
                        {
                            image = s_miniThumbQueue[0];
                            s_miniThumbQueue.RemoveAt(0);
                        }
                    }
                    if (image == null)
                    {
                        Thread.Sleep(500);
                    }
                    else
                    {
                        BitmapImage image2 = MakeBitmapImage(image._uri, 0x4b);
                        if (image2 != null)
                        {
                            delegate_Void_BI method = new delegate_Void_BI(image.SetMini);
                            image.Dispatcher.Invoke(method, new object[] { image2 });
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("s_miniThumbProcessor Error: \n" + exception.ToString());
                }
            }
        }

        private static void s_priorityThumbProcessor()
        {
            while (true)
            {
                try
                {
                    UserControl_ManagedImage image = null;
                    if (s_priorityThumbQueue.Count > 0)
                    {
                        image = s_priorityThumbQueue[0];
                        s_priorityThumbQueue.RemoveAt(0);
                    }
                    if (image == null)
                    {
                        Thread.Sleep(500);
                    }
                    else if (image.x_MainControl.ActualWidth <= 75.0)
                    {
                        delegate_Void method = new delegate_Void(image.ReleaseImage);
                        image.Dispatcher.Invoke(method, new object[0]);
                    }
                    else if (image._decodedPiexlWidth != image.x_MainControl.ActualWidth)
                    {
                        BitmapImage image2 = null;
                        image2 = MakeBitmapImage(image._uri, (int) image.x_MainControl.ActualWidth);
                        if (image2 != null)
                        {
                            delegate_Void_BI_int _int = new delegate_Void_BI_int(image.SetImage);
                            image.Dispatcher.Invoke(_int, new object[] { image2, (int) image.x_MainControl.ActualWidth });
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("s_priorityThumbProcessor Error: \n" + exception.ToString());
                }
            }
        }

        private static void s_releaseThumbProcessor()
        {
            while (true)
            {
                try
                {
                    UserControl_ManagedImage image = null;
                    lock (s_releaseThumbQueue)
                    {
                        if (s_releaseThumbQueue.Count > 0)
                        {
                            image = s_releaseThumbQueue[0];
                            s_releaseThumbQueue.RemoveAt(0);
                        }
                    }
                    if (image == null)
                    {
                        Thread.Sleep(0x2710);
                    }
                    else
                    {
                        delegate_Void method = new delegate_Void(image.ReleaseImage);
                        image.Dispatcher.Invoke(method, new object[0]);
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("s_releaseThumbQueue Error: \n" + exception.ToString());
                }
            }
        }

        private void SetImage(BitmapImage obj, int decodeWidth)
        {
            this.x_Image.Source = obj;
            this._decodedPiexlWidth = decodeWidth;
        }

        private void SetMini(BitmapImage obj)
        {
            this.x_Grid.Background = Brushes.Transparent;
            this.x_ImageThumb.Source = obj;
        }

        [DebuggerNonUserCode, GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never)]
        void IComponentConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 1:
                    this.x_MainControl = (UserControl_ManagedImage) target;
                    this.x_MainControl.Loaded += new RoutedEventHandler(this.x_MainControl_Loaded);
                    this.x_MainControl.Unloaded += new RoutedEventHandler(this.x_MainControl_Unloaded);
                    this.x_MainControl.IsVisibleChanged += new DependencyPropertyChangedEventHandler(this.x_MainControl_IsVisibleChanged);
                    break;

                case 2:
                    this.x_Grid = (Grid) target;
                    break;

                case 3:
                    this.x_ImageThumb = (Image) target;
                    break;

                case 4:
                    this.x_Image = (Image) target;
                    break;

                default:
                    this._contentLoaded = true;
                    break;
            }
        }

        private static bool UIElementInTheView(ScrollViewer topScrollViewer, DependencyObject dObj)
        {
            try
            {
                if (!((UIElement) dObj).IsVisible)
                {
                    return false;
                }
                Rect rect = ((UIElement) dObj).TransformToAncestor(topScrollViewer).TransformBounds(new Rect(new Point(0.0, 0.0), ((UIElement) dObj).RenderSize));
                if (Rect.Intersect(new Rect(new Point(topScrollViewer.RenderSize.Width * -4.0, topScrollViewer.RenderSize.Height * -4.0), new Point(topScrollViewer.RenderSize.Width * 5.0, topScrollViewer.RenderSize.Height * 5.0)), rect) == Rect.Empty)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void x_MainControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            Collection<UserControl_ManagedImage> collection;
            if (base.IsVisible)
            {
                lock ((collection = s_miniThumbQueue))
                {
                    if (!s_miniThumbQueue.Contains(this))
                    {
                        s_miniThumbQueue.Add(this);
                    }
                }
            }
            else
            {
                lock ((collection = s_miniThumbQueue))
                {
                    if (s_miniThumbQueue.Contains(this))
                    {
                        s_miniThumbQueue.Remove(this);
                    }
                }
                if (this.x_ImageThumb.Source != null)
                {
                    this.ReleaseMini();
                }
            }
        }

        private void x_MainControl_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag;
                ScrollViewer item = null;
                DependencyObject parent = VisualTreeHelper.GetParent(this);
                goto Label_0046;
            Label_000D:
                if (parent == null)
                {
                    goto Label_004A;
                }
                if (parent.GetType() == typeof(ScrollViewer))
                {
                    item = (ScrollViewer) parent;
                }
                parent = VisualTreeHelper.GetParent(parent);
            Label_0046:
                flag = true;
                goto Label_000D;
            Label_004A:
                if (!((item == null) || s_hostScrollViewers.Contains(item)))
                {
                    s_hostScrollViewers.Add(item);
                }
            }
            catch
            {
            }
        }

        private void x_MainControl_Unloaded(object sender, RoutedEventArgs e)
        {
            lock (s_miniThumbQueue)
            {
                s_miniThumbQueue.Remove(this);
            }
        }

        public string MainHeight
        {
            get
            {
                return (string) base.GetValue(MainHeightProperty);
            }
            set
            {
                base.SetValue(MainHeightProperty, value);
            }
        }

        public string MainWidth
        {
            get
            {
                return (string) base.GetValue(MainWidthProperty);
            }
            set
            {
                base.SetValue(MainWidthProperty, value);
            }
        }

        public Uri SourceUri
        {
            get
            {
                return (Uri) base.GetValue(SourceUriProperty);
            }
            set
            {
                base.SetValue(SourceUriProperty, value);
            }
        }

        public delegate void delegate_Void();

        public delegate void delegate_Void_BI(BitmapImage obj);

        public delegate void delegate_Void_BI_int(BitmapImage obj, int pixelWidth);

        public delegate void delegate_Void_SV(ScrollViewer topScrollViewer);

        [StructLayout(LayoutKind.Sequential)]
        private struct ScrollViewerInfo
        {
            public double ScrollableHeight;
            public double ScrollableWidth;
            public double VerticalOffset;
            public double HorizontalOffset;
            public ScrollViewerInfo(ScrollViewer sv)
            {
                this.ScrollableHeight = sv.ScrollableHeight;
                this.ScrollableWidth = sv.ScrollableWidth;
                this.VerticalOffset = sv.VerticalOffset;
                this.HorizontalOffset = sv.HorizontalOffset;
            }

            public bool IsSameInfo(ScrollViewer sv)
            {
                if (!(this.ScrollableHeight == sv.ScrollableHeight))
                {
                    return false;
                }
                if (!(this.ScrollableWidth == sv.ScrollableWidth))
                {
                    return false;
                }
                if (!(this.VerticalOffset == sv.VerticalOffset))
                {
                    return false;
                }
                if (!(this.HorizontalOffset == sv.HorizontalOffset))
                {
                    return false;
                }
                return true;
            }
        }
    }
}

