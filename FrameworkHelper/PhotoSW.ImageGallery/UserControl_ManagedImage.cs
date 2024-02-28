using PhotoSW.Common;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PhotoSW.ImageGallery
{
	public class UserControl_ManagedImage : UserControl, IComponentConnector
	{
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
				return this.ScrollableHeight == sv.ScrollableHeight && this.ScrollableWidth == sv.ScrollableWidth && this.VerticalOffset == sv.VerticalOffset && this.HorizontalOffset == sv.HorizontalOffset;
			}
		}

		public delegate void delegate_Void();

		public delegate void delegate_Void_BI(BitmapImage obj);

		public delegate void delegate_Void_BI_int(BitmapImage obj, int pixelWidth);

		public delegate void delegate_Void_SV(ScrollViewer topScrollViewer);

		private const int c_miniThumbWidth = 75;

		private static object s_classLockObj = new object();

		private static System.Collections.ObjectModel.Collection<ScrollViewer> s_hostScrollViewers = new System.Collections.ObjectModel.Collection<ScrollViewer>();

		private static System.Collections.Generic.Dictionary<ScrollViewer, UserControl_ManagedImage.ScrollViewerInfo> s_hostScrollViewerInfos = new System.Collections.Generic.Dictionary<ScrollViewer, UserControl_ManagedImage.ScrollViewerInfo>();

		private static System.Collections.ObjectModel.Collection<UserControl_ManagedImage> s_miniThumbQueue = new System.Collections.ObjectModel.Collection<UserControl_ManagedImage>();

		private static System.Collections.ObjectModel.Collection<UserControl_ManagedImage> s_priorityThumbQueue = new System.Collections.ObjectModel.Collection<UserControl_ManagedImage>();

		private static System.Collections.ObjectModel.Collection<UserControl_ManagedImage> s_releaseThumbQueue = new System.Collections.ObjectModel.Collection<UserControl_ManagedImage>();

		private static System.Threading.Thread s_miniThumbThread;

		private static System.Threading.Thread s_priorityThumbThread;

		private static System.Threading.Thread s_releaseThumbThread;

		private static System.Threading.Thread s_isInTheViewThread;

		public static readonly DependencyProperty SourceUriProperty = DependencyProperty.Register("SourceUri", typeof(Uri), typeof(UserControl_ManagedImage), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(UserControl_ManagedImage.OnSourceUriCallback)));

		public static readonly RoutedEvent SourceUriChangedEvent = EventManager.RegisterRoutedEvent("SourceUriChangedEvent", RoutingStrategy.Bubble, typeof(DependencyPropertyChangedEventHandler), typeof(UserControl_ManagedImage));

		public static DependencyProperty MainWidthProperty = DependencyProperty.Register("MainWidth", typeof(string), typeof(UserControl_ManagedImage), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(UserControl_ManagedImage.OnMainWidthCallback)));

		public static DependencyProperty MainHeightProperty = DependencyProperty.Register("MainHeight", typeof(string), typeof(UserControl_ManagedImage), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(UserControl_ManagedImage.OnMainHeightCallback)));

		private Uri _uri;

		private int _decodedPiexlWidth = 0;

		public static ICanGetThumbPath _thumbPathMaker = null;

		public static ICanGetThumbBitmapImage _thumbBitmapMaker = null;

		internal UserControl_ManagedImage x_MainControl;

		internal Grid x_Grid;

		internal Image x_ImageThumb;

		internal Image x_Image;

		private bool _contentLoaded;

		public event RoutedEventHandler SourceUriChanged
		{
			add
			{
				base.AddHandler(UserControl_ManagedImage.SourceUriChangedEvent, value);
			}
			remove
			{
				base.RemoveHandler(UserControl_ManagedImage.SourceUriChangedEvent, value);
			}
		}

		public Uri SourceUri
		{
			get
			{
				return (Uri)base.GetValue(UserControl_ManagedImage.SourceUriProperty);
			}
			set
			{
				base.SetValue(UserControl_ManagedImage.SourceUriProperty, value);
			}
		}

		public string MainWidth
		{
			get
			{
				return (string)base.GetValue(UserControl_ManagedImage.MainWidthProperty);
			}
			set
			{
				base.SetValue(UserControl_ManagedImage.MainWidthProperty, value);
			}
		}

		public string MainHeight
		{
			get
			{
				return (string)base.GetValue(UserControl_ManagedImage.MainHeightProperty);
			}
			set
			{
				base.SetValue(UserControl_ManagedImage.MainHeightProperty, value);
			}
		}

		public static void s_ActivateThreads()
		{
			if (UserControl_ManagedImage.s_miniThumbThread == null || !UserControl_ManagedImage.s_miniThumbThread.IsAlive)
			{
				UserControl_ManagedImage.s_miniThumbThread = new System.Threading.Thread(new System.Threading.ThreadStart(UserControl_ManagedImage.s_miniThumbProcessor));
				UserControl_ManagedImage.s_miniThumbThread.Priority = System.Threading.ThreadPriority.Normal;
				UserControl_ManagedImage.s_miniThumbThread.Start();
			}
			if (UserControl_ManagedImage.s_priorityThumbThread == null || !UserControl_ManagedImage.s_priorityThumbThread.IsAlive)
			{
				UserControl_ManagedImage.s_priorityThumbThread = new System.Threading.Thread(new System.Threading.ThreadStart(UserControl_ManagedImage.s_priorityThumbProcessor));
				UserControl_ManagedImage.s_priorityThumbThread.Priority = System.Threading.ThreadPriority.BelowNormal;
				UserControl_ManagedImage.s_priorityThumbThread.Start();
			}
			if (UserControl_ManagedImage.s_releaseThumbThread == null || !UserControl_ManagedImage.s_releaseThumbThread.IsAlive)
			{
				UserControl_ManagedImage.s_releaseThumbThread = new System.Threading.Thread(new System.Threading.ThreadStart(UserControl_ManagedImage.s_releaseThumbProcessor));
				UserControl_ManagedImage.s_releaseThumbThread.Priority = System.Threading.ThreadPriority.Lowest;
				UserControl_ManagedImage.s_releaseThumbThread.Start();
			}
			if (UserControl_ManagedImage.s_isInTheViewThread == null || !UserControl_ManagedImage.s_isInTheViewThread.IsAlive)
			{
				UserControl_ManagedImage.s_isInTheViewThread = new System.Threading.Thread(new System.Threading.ThreadStart(UserControl_ManagedImage.s_isInTheViewProcessor));
				UserControl_ManagedImage.s_isInTheViewThread.Priority = System.Threading.ThreadPriority.Lowest;
				UserControl_ManagedImage.s_isInTheViewThread.Start();
			}
			while (!UserControl_ManagedImage.s_miniThumbThread.IsAlive || !UserControl_ManagedImage.s_priorityThumbThread.IsAlive || !UserControl_ManagedImage.s_releaseThumbThread.IsAlive || !UserControl_ManagedImage.s_isInTheViewThread.IsAlive)
			{
				System.Console.WriteLine(string.Concat(new string[]
				{
					"Waiting thread: ",
					UserControl_ManagedImage.s_miniThumbThread.IsAlive.ToString(),
					" ",
					UserControl_ManagedImage.s_priorityThumbThread.IsAlive.ToString(),
					" ",
					UserControl_ManagedImage.s_releaseThumbThread.IsAlive.ToString(),
					" ",
					UserControl_ManagedImage.s_isInTheViewThread.IsAlive.ToString(),
					" "
				}));
			}
		}

		public static void s_DeactivateThreads()
		{
			try
			{
				UserControl_ManagedImage.s_miniThumbThread.Abort();
			}
			catch
			{
			}
			try
			{
				UserControl_ManagedImage.s_priorityThumbThread.Abort();
			}
			catch
			{
			}
			try
			{
				UserControl_ManagedImage.s_releaseThumbThread.Abort();
			}
			catch
			{
			}
			try
			{
				UserControl_ManagedImage.s_isInTheViewThread.Abort();
			}
			catch
			{
			}
		}

		private void ReleaseMini()
		{
			this.x_Grid.Background = Brushes.Gray;
			this.x_ImageThumb.Source = null;
		}

		private void SetMini(BitmapImage obj)
		{
			this.x_Grid.Background = Brushes.Transparent;
			this.x_ImageThumb.Source = obj;
		}

		private void ReleaseImage()
		{
			this.x_Image.Source = null;
			this._decodedPiexlWidth = 0;
		}

		private void SetImage(BitmapImage obj, int decodeWidth)
		{
			this.x_Image.Source = obj;
			this._decodedPiexlWidth = decodeWidth;
		}

		private static void s_ChildInView_Driver(ScrollViewer sv)
		{
			if (UserControl_ManagedImage.s_hostScrollViewerInfos.ContainsKey(sv))
			{
				if (UserControl_ManagedImage.s_hostScrollViewerInfos[sv].IsSameInfo(sv))
				{
					return;
				}
				UserControl_ManagedImage.s_hostScrollViewerInfos[sv] = new UserControl_ManagedImage.ScrollViewerInfo(sv);
			}
			else
			{
				UserControl_ManagedImage.s_hostScrollViewerInfos.Add(sv, new UserControl_ManagedImage.ScrollViewerInfo(sv));
			}
			System.Console.WriteLine("Running s_ChildInView(sv, sv).");
			lock (UserControl_ManagedImage.s_classLockObj)
			{
				UserControl_ManagedImage.s_priorityThumbQueue.Clear();
				UserControl_ManagedImage.s_releaseThumbQueue.Clear();
			}
			UserControl_ManagedImage.s_ChildInView(sv, sv);
		}

		private static void s_ChildInView(ScrollViewer sv, DependencyObject currentParent)
		{
			if (currentParent.GetType() == typeof(UserControl_ManagedImage))
			{
				UserControl_ManagedImage userControl_ManagedImage = (UserControl_ManagedImage)currentParent;
				if (userControl_ManagedImage.x_MainControl.ActualWidth <= 75.0)
				{
					userControl_ManagedImage.ReleaseImage();
				}
				else if ((double)userControl_ManagedImage._decodedPiexlWidth != userControl_ManagedImage.x_MainControl.ActualWidth)
				{
					lock (UserControl_ManagedImage.s_classLockObj)
					{
						if (!UserControl_ManagedImage.s_priorityThumbQueue.Contains(userControl_ManagedImage))
						{
							UserControl_ManagedImage.s_priorityThumbQueue.Add(userControl_ManagedImage);
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
						UserControl_ManagedImage.s_DeepRelease(child);
					}
					else if (UserControl_ManagedImage.UIElementInTheView(sv, child))
					{
						if (num == 0)
						{
							num++;
						}
						UserControl_ManagedImage.s_ChildInView(sv, child);
					}
					else
					{
						if (num == 1)
						{
							num++;
						}
						UserControl_ManagedImage.s_DeepRelease(child);
					}
				}
			}
		}

		private static bool UIElementInTheView(ScrollViewer topScrollViewer, DependencyObject dObj)
		{
			bool result;
			try
			{
				if (!((UIElement)dObj).IsVisible)
				{
					result = false;
				}
				else
				{
					GeneralTransform generalTransform = ((UIElement)dObj).TransformToAncestor(topScrollViewer);
					Rect rect = generalTransform.TransformBounds(new Rect(new Point(0.0, 0.0), ((UIElement)dObj).RenderSize));
					Rect rect2 = Rect.Intersect(new Rect(new Point(topScrollViewer.RenderSize.Width * -4.0, topScrollViewer.RenderSize.Height * -4.0), new Point(topScrollViewer.RenderSize.Width * 5.0, topScrollViewer.RenderSize.Height * 5.0)), rect);
					if (rect2 == Rect.Empty)
					{
						result = false;
					}
					else
					{
						result = true;
					}
				}
			}
			catch
			{
				result = false;
			}
			return result;
		}

		private static void s_DeepRelease(DependencyObject currentParent)
		{
			if (currentParent.GetType() == typeof(UserControl_ManagedImage))
			{
				UserControl_ManagedImage userControl_ManagedImage = (UserControl_ManagedImage)currentParent;
				if (userControl_ManagedImage.x_Image.Source != null)
				{
					lock (UserControl_ManagedImage.s_classLockObj)
					{
						if (!UserControl_ManagedImage.s_releaseThumbQueue.Contains(userControl_ManagedImage))
						{
							UserControl_ManagedImage.s_releaseThumbQueue.Add(userControl_ManagedImage);
						}
					}
				}
			}
			else
			{
				for (int i = 0; i < VisualTreeHelper.GetChildrenCount(currentParent); i++)
				{
					DependencyObject child = VisualTreeHelper.GetChild(currentParent, i);
					UserControl_ManagedImage.s_DeepRelease(child);
				}
			}
		}

		private static void s_miniThumbProcessor()
		{
			while (true)
			{
				try
				{
					UserControl_ManagedImage userControl_ManagedImage = null;
					lock (UserControl_ManagedImage.s_miniThumbQueue)
					{
						if (UserControl_ManagedImage.s_miniThumbQueue.Count > 0)
						{
							userControl_ManagedImage = UserControl_ManagedImage.s_miniThumbQueue[0];
							UserControl_ManagedImage.s_miniThumbQueue.RemoveAt(0);
						}
					}
					if (userControl_ManagedImage == null)
					{
						System.Threading.Thread.Sleep(500);
					}
					else
					{
						BitmapImage bitmapImage = UserControl_ManagedImage.MakeBitmapImage(userControl_ManagedImage._uri, 75);
						if (bitmapImage != null)
						{
							UserControl_ManagedImage.delegate_Void_BI method = new UserControl_ManagedImage.delegate_Void_BI(userControl_ManagedImage.SetMini);
							userControl_ManagedImage.Dispatcher.Invoke(method, new object[]
							{
								bitmapImage
							});
						}
					}
				}
				catch (System.Exception ex)
				{
					System.Console.WriteLine("s_miniThumbProcessor Error: \n" + ex.ToString());
				}
			}
		}

		private static void s_priorityThumbProcessor()
		{
			while (true)
			{
				try
				{
					UserControl_ManagedImage userControl_ManagedImage = null;
					if (UserControl_ManagedImage.s_priorityThumbQueue.Count > 0)
					{
						userControl_ManagedImage = UserControl_ManagedImage.s_priorityThumbQueue[0];
						UserControl_ManagedImage.s_priorityThumbQueue.RemoveAt(0);
					}
					if (userControl_ManagedImage == null)
					{
						System.Threading.Thread.Sleep(500);
					}
					else if (userControl_ManagedImage.x_MainControl.ActualWidth <= 75.0)
					{
						UserControl_ManagedImage.delegate_Void method = new UserControl_ManagedImage.delegate_Void(userControl_ManagedImage.ReleaseImage);
						userControl_ManagedImage.Dispatcher.Invoke(method, new object[0]);
					}
					else if ((double)userControl_ManagedImage._decodedPiexlWidth != userControl_ManagedImage.x_MainControl.ActualWidth)
					{
						BitmapImage bitmapImage = UserControl_ManagedImage.MakeBitmapImage(userControl_ManagedImage._uri, (int)userControl_ManagedImage.x_MainControl.ActualWidth);
						if (bitmapImage != null)
						{
							UserControl_ManagedImage.delegate_Void_BI_int method2 = new UserControl_ManagedImage.delegate_Void_BI_int(userControl_ManagedImage.SetImage);
							userControl_ManagedImage.Dispatcher.Invoke(method2, new object[]
							{
								bitmapImage,
								(int)userControl_ManagedImage.x_MainControl.ActualWidth
							});
						}
					}
				}
				catch (System.Exception ex)
				{
					System.Console.WriteLine("s_priorityThumbProcessor Error: \n" + ex.ToString());
				}
			}
		}

		private static void s_releaseThumbProcessor()
		{
			while (true)
			{
				try
				{
					UserControl_ManagedImage userControl_ManagedImage = null;
					lock (UserControl_ManagedImage.s_releaseThumbQueue)
					{
						if (UserControl_ManagedImage.s_releaseThumbQueue.Count > 0)
						{
							userControl_ManagedImage = UserControl_ManagedImage.s_releaseThumbQueue[0];
							UserControl_ManagedImage.s_releaseThumbQueue.RemoveAt(0);
						}
					}
					if (userControl_ManagedImage == null)
					{
						System.Threading.Thread.Sleep(10000);
					}
					else
					{
						UserControl_ManagedImage.delegate_Void method = new UserControl_ManagedImage.delegate_Void(userControl_ManagedImage.ReleaseImage);
						userControl_ManagedImage.Dispatcher.Invoke(method, new object[0]);
					}
				}
				catch (System.Exception ex)
				{
					System.Console.WriteLine("s_releaseThumbQueue Error: \n" + ex.ToString());
				}
			}
		}

		private static void s_isInTheViewProcessor()
		{
			while (true)
			{
				foreach (ScrollViewer current in UserControl_ManagedImage.s_hostScrollViewers)
				{
					UserControl_ManagedImage.delegate_Void_SV method = new UserControl_ManagedImage.delegate_Void_SV(UserControl_ManagedImage.s_ChildInView_Driver);
					current.Dispatcher.Invoke(method, new object[]
					{
						current
					});
				}
				System.Console.WriteLine(string.Concat(new object[]
				{
					"s_isInTheViewProcessor Update: ",
					UserControl_ManagedImage.s_priorityThumbQueue.Count,
					" Release: ",
					UserControl_ManagedImage.s_releaseThumbQueue.Count
				}));
				System.Threading.Thread.Sleep(1000);
			}
		}

		public UserControl_ManagedImage()
		{
			this.InitializeComponent();
		}

		private void x_MainControl_Loaded(object sender, RoutedEventArgs e)
		{
			try
			{
				ScrollViewer scrollViewer = null;
				for (DependencyObject parent = VisualTreeHelper.GetParent(this); parent != null; parent = VisualTreeHelper.GetParent(parent))
				{
					if (parent.GetType() == typeof(ScrollViewer))
					{
						scrollViewer = (ScrollViewer)parent;
					}
				}
				if (scrollViewer != null && !UserControl_ManagedImage.s_hostScrollViewers.Contains(scrollViewer))
				{
					UserControl_ManagedImage.s_hostScrollViewers.Add(scrollViewer);
				}
			}
			catch
			{
			}
		}

		private void x_MainControl_Unloaded(object sender, RoutedEventArgs e)
		{
			lock (UserControl_ManagedImage.s_miniThumbQueue)
			{
				UserControl_ManagedImage.s_miniThumbQueue.Remove(this);
			}
		}

		private void x_MainControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
		{
			if (base.IsVisible)
			{
				lock (UserControl_ManagedImage.s_miniThumbQueue)
				{
					if (!UserControl_ManagedImage.s_miniThumbQueue.Contains(this))
					{
						UserControl_ManagedImage.s_miniThumbQueue.Add(this);
					}
				}
			}
			else
			{
				lock (UserControl_ManagedImage.s_miniThumbQueue)
				{
					if (UserControl_ManagedImage.s_miniThumbQueue.Contains(this))
					{
						UserControl_ManagedImage.s_miniThumbQueue.Remove(this);
					}
				}
				if (this.x_ImageThumb.Source != null)
				{
					this.ReleaseMini();
				}
			}
		}

		private static void OnSourceUriCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			UserControl_ManagedImage userControl_ManagedImage = (UserControl_ManagedImage)d;
			Uri uri = (Uri)e.NewValue;
			userControl_ManagedImage._uri = uri;
			RoutedEventArgs e2 = new RoutedEventArgs(UserControl_ManagedImage.SourceUriChangedEvent);
			(d as FrameworkElement).RaiseEvent(e2);
		}

		private static void OnMainWidthCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			UserControl_ManagedImage userControl_ManagedImage = (UserControl_ManagedImage)d;
			string text = (string)e.NewValue;
			double width = 0.0;
			if (text != null && double.TryParse(text, out width))
			{
				userControl_ManagedImage.x_MainControl.Width = width;
			}
		}

		private static void OnMainHeightCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			UserControl_ManagedImage userControl_ManagedImage = (UserControl_ManagedImage)d;
			string text = (string)e.NewValue;
			double height = 0.0;
			if (text != null && double.TryParse(text, out height))
			{
				userControl_ManagedImage.x_MainControl.Height = height;
			}
		}

		private static BitmapImage MakeBitmapImage(Uri uri, int decodeWidth)
		{
			BitmapImage result;
			try
			{
				string localPath = uri.LocalPath;
				if (UserControl_ManagedImage._thumbPathMaker != null)
				{
					string text;
					if (decodeWidth <= 75)
					{
						text = UserControl_ManagedImage._thumbPathMaker.GetMiniThumbPath(localPath, true);
					}
					else
					{
						text = UserControl_ManagedImage._thumbPathMaker.GetThumbPath(localPath, true);
					}
					if (text == null)
					{
						result = UserControl_ManagedImage.MakeBitmapImage_Default(uri, decodeWidth);
						return result;
					}
					result = UserControl_ManagedImage.MakeBitmapImage_Default(new Uri(text), decodeWidth);
					return result;
				}
				else if (UserControl_ManagedImage._thumbBitmapMaker != null)
				{
					BitmapImage bitmapImage;
					if (decodeWidth <= 75)
					{
						bitmapImage = UserControl_ManagedImage._thumbBitmapMaker.GetMiniThumb_BitmapImage(localPath, decodeWidth);
					}
					else
					{
						bitmapImage = UserControl_ManagedImage._thumbBitmapMaker.GetThumb_BitmapImage(localPath, decodeWidth);
					}
					if (bitmapImage == null)
					{
						result = UserControl_ManagedImage.MakeBitmapImage_Default(uri, decodeWidth);
						return result;
					}
					result = bitmapImage;
					return result;
				}
			}
			catch
			{
			}
			result = UserControl_ManagedImage.MakeBitmapImage_Default(uri, decodeWidth);
			return result;
		}

		private static BitmapImage MakeBitmapImage_Default(Uri uri, int decodeWidth)
		{
			BitmapImage result;
			try
			{
				BitmapImage bitmapImage = new BitmapImage();
				bitmapImage.BeginInit();
				bitmapImage.UriSource = uri;
				bitmapImage.DecodePixelWidth = decodeWidth;
				bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
				bitmapImage.CreateOptions = BitmapCreateOptions.None;
				bitmapImage.EndInit();
				bitmapImage.Freeze();
				result = bitmapImage;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), System.Diagnostics.DebuggerNonUserCode]
		public void InitializeComponent()
		{
			if (!this._contentLoaded)
			{
				this._contentLoaded = true;
				Uri resourceLocator = new Uri("/FrameworkHelper;component/imagegallery/usercontrol_managedimage.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), System.Diagnostics.DebuggerNonUserCode]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			switch (connectionId)
			{
			case 1:
				this.x_MainControl = (UserControl_ManagedImage)target;
				this.x_MainControl.Loaded += new RoutedEventHandler(this.x_MainControl_Loaded);
				this.x_MainControl.Unloaded += new RoutedEventHandler(this.x_MainControl_Unloaded);
				this.x_MainControl.IsVisibleChanged += new DependencyPropertyChangedEventHandler(this.x_MainControl_IsVisibleChanged);
				break;
			case 2:
				this.x_Grid = (Grid)target;
				break;
			case 3:
				this.x_ImageThumb = (Image)target;
				break;
			case 4:
				this.x_Image = (Image)target;
				break;
			default:
				this._contentLoaded = true;
				break;
			}
		}
	}
}
