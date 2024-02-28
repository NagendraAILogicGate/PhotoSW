using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PhotoSW.Common
{
	public class CroppingAdorner : Adorner
	{
		private class CropThumb : Thumb
		{
			private int _cpx;

			internal CropThumb(int cpx)
			{
				this._cpx = cpx;
			}

			protected override Visual GetVisualChild(int index)
			{
				return null;
			}

			protected override void OnRender(DrawingContext drawingContext)
			{
				drawingContext.DrawEllipse(Brushes.Wheat, new Pen(Brushes.Brown, 1.0), new Point(8.0, 8.0), 16.0, 16.0);
			}

			internal void SetPos(double x, double y)
			{
				Canvas.SetTop(this, y - (double)(this._cpx / 2));
				Canvas.SetLeft(this, x - (double)(this._cpx / 2));
			}
		}

		private const int _cpxThumbWidth = 16;

		private PuncturedRect _prCropMask;

		private Canvas _cnvThumbs;

		private CroppingAdorner.CropThumb _crtTopLeft;

		private CroppingAdorner.CropThumb _crtTopRight;

		private CroppingAdorner.CropThumb _crtBottomLeft;

		private CroppingAdorner.CropThumb _crtBottomRight;

		private CroppingAdorner.CropThumb _crtTop;

		private CroppingAdorner.CropThumb _crtLeft;

		private CroppingAdorner.CropThumb _crtBottom;

		private CroppingAdorner.CropThumb _crtRight;

		private VisualCollection _vc;

		public static double s_dpiX;

		public static double s_dpiY;

		public static DependencyProperty FillProperty;

		private double OrigenX;

		private double OrigenY;

		public Rect ClippingRectangle
		{
			get
			{
				return this._prCropMask.RectInterior;
			}
		}

		public Brush Fill
		{
			get
			{
				return (Brush)base.GetValue(CroppingAdorner.FillProperty);
			}
			set
			{
				base.SetValue(CroppingAdorner.FillProperty, value);
			}
		}

		protected override int VisualChildrenCount
		{
			get
			{
				return this._vc.Count;
			}
		}

		private static void FillPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
		{
			CroppingAdorner croppingAdorner = d as CroppingAdorner;
			if (croppingAdorner != null)
			{
				croppingAdorner._prCropMask.Fill = (Brush)args.NewValue;
			}
		}

		static CroppingAdorner()
		{
			CroppingAdorner.FillProperty = Shape.FillProperty.AddOwner(typeof(CroppingAdorner));
			Color red = Colors.Red;
			CroppingAdorner.s_dpiX = 300.0;
			CroppingAdorner.s_dpiY = 300.0;
			red.A = 80;
			CroppingAdorner.FillProperty.OverrideMetadata(typeof(CroppingAdorner), new PropertyMetadata(new SolidColorBrush(red), new PropertyChangedCallback(CroppingAdorner.FillPropChanged)));
		}

		public CroppingAdorner(UIElement adornedElement, Rect rcInit) : base(adornedElement)
		{
			this._vc = new VisualCollection(this);
			this._prCropMask = new PuncturedRect();
			this._prCropMask.IsHitTestVisible = false;
			this._prCropMask.RectInterior = rcInit;
			this._prCropMask.Fill = this.Fill;
			this._vc.Add(this._prCropMask);
			this._cnvThumbs = new Canvas();
			this._cnvThumbs.HorizontalAlignment = HorizontalAlignment.Stretch;
			this._cnvThumbs.VerticalAlignment = VerticalAlignment.Stretch;
			this._vc.Add(this._cnvThumbs);
			this.BuildCorner(ref this._crtTop, Cursors.SizeNS);
			this.BuildCorner(ref this._crtBottom, Cursors.SizeNS);
			this.BuildCorner(ref this._crtLeft, Cursors.SizeWE);
			this.BuildCorner(ref this._crtRight, Cursors.SizeWE);
			this.BuildCorner(ref this._crtTopLeft, Cursors.SizeNWSE);
			this.BuildCorner(ref this._crtTopRight, Cursors.SizeNESW);
			this.BuildCorner(ref this._crtBottomLeft, Cursors.SizeNESW);
			this.BuildCorner(ref this._crtBottomRight, Cursors.SizeNWSE);
			this._crtBottomLeft.DragDelta += new DragDeltaEventHandler(this.HandleBottomLeft);
			this._crtBottomRight.DragDelta += new DragDeltaEventHandler(this.HandleBottomRight);
			this._crtTopLeft.DragDelta += new DragDeltaEventHandler(this.HandleTopLeft);
			this._crtTopRight.DragDelta += new DragDeltaEventHandler(this.HandleTopRight);
			this._crtTop.DragDelta += new DragDeltaEventHandler(this.HandleTop);
			this._crtBottom.DragDelta += new DragDeltaEventHandler(this.HandleBottom);
			this._crtRight.DragDelta += new DragDeltaEventHandler(this.HandleRight);
			this._crtLeft.DragDelta += new DragDeltaEventHandler(this.HandleLeft);
			adornedElement.MouseLeftButtonDown += new MouseButtonEventHandler(this.Handle_MouseLeftButtonDown);
			adornedElement.MouseLeftButtonUp += new MouseButtonEventHandler(this.Handle_MouseLeftButtonUp);
			adornedElement.MouseMove += new MouseEventHandler(this.Handle_MouseMove);
			FrameworkElement frameworkElement = adornedElement as FrameworkElement;
			if (frameworkElement != null)
			{
				frameworkElement.SizeChanged += new SizeChangedEventHandler(this.AdornedElement_SizeChanged);
			}
			this.OrigenY = 0.0;
			this.OrigenX = 0.0;
		}

		public void ReleaseResources(UIElement adornedElement)
		{
			adornedElement.MouseLeftButtonDown -= new MouseButtonEventHandler(this.Handle_MouseLeftButtonDown);
			adornedElement.MouseLeftButtonUp -= new MouseButtonEventHandler(this.Handle_MouseLeftButtonUp);
			adornedElement.MouseMove -= new MouseEventHandler(this.Handle_MouseMove);
		}

		private void HandleDrag(double dx, double dy)
		{
			Rect rectInterior = this._prCropMask.RectInterior;
			rectInterior = new Rect(dx, dy, rectInterior.Width, rectInterior.Height);
			this._prCropMask.RectInterior = rectInterior;
			this.SetThumbs(this._prCropMask.RectInterior);
		}

		private void Handle_MouseMove(object sender, MouseEventArgs args)
		{
			Grid grid = new Grid();
			if (sender is Grid)
			{
				grid = (sender as Grid);
				if (grid.Name != "GrdCrop")
				{
					return;
				}
			}
			if (grid != null && grid.IsMouseCaptured)
			{
				double x = args.GetPosition(grid).X;
				double y = args.GetPosition(grid).Y;
				double num = this._prCropMask.RectInterior.X;
				double num2 = this._prCropMask.RectInterior.Y;
				double width = this._prCropMask.RectInterior.Width;
				double height = this._prCropMask.RectInterior.Height;
				if (x != this.OrigenX || y != this.OrigenY)
				{
					if (x > num && x < num + width && y > num2 && y < num2 + height)
					{
						num += x - this.OrigenX;
						num2 += y - this.OrigenY;
						if (num < 0.0)
						{
							num = 0.0;
						}
						if (num + width > grid.ActualWidth)
						{
							num = grid.ActualWidth - width;
						}
						if (num2 < 0.0)
						{
							num2 = 0.0;
						}
						if (num2 + height > grid.ActualHeight)
						{
							num2 = grid.ActualHeight - height;
						}
						this.OrigenX = x;
						this.OrigenY = y;
						this.HandleDrag(num, num2);
					}
				}
			}
		}

		private void Handle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			Grid grid = new Grid();
			if (sender is Grid)
			{
				grid = (sender as Grid);
				if (grid.Name != "GrdCrop")
				{
					return;
				}
			}
			if (grid != null)
			{
				this.OrigenX = e.GetPosition(grid).X;
				this.OrigenY = e.GetPosition(grid).Y;
				grid.CaptureMouse();
			}
		}

		private void Handle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			Grid grid = new Grid();
			if (sender is Grid)
			{
				grid = (sender as Grid);
				if (grid.Name != "GrdCrop")
				{
					return;
				}
			}
			if (grid != null)
			{
				grid.ReleaseMouseCapture();
			}
		}

		private void HandleThumb(double drcL, double drcT, double drcW, double drcH, double dx, double dy)
		{
			Rect rectInterior = this._prCropMask.RectInterior;
			if (rectInterior.Width + drcW * dx < 0.0)
			{
				dx = -rectInterior.Width / drcW;
			}
			if (rectInterior.Height + drcH * dy < 0.0)
			{
				dy = -rectInterior.Height / drcH;
			}
			rectInterior = new Rect(rectInterior.Left + drcL * dx, rectInterior.Top + drcT * dy, rectInterior.Width + drcW * dx, rectInterior.Height + drcH * dy);
			this._prCropMask.RectInterior = rectInterior;
			this.SetThumbs(this._prCropMask.RectInterior);
		}

		private void HandleBottomLeft(object sender, DragDeltaEventArgs args)
		{
		}

		private void HandleBottomRight(object sender, DragDeltaEventArgs args)
		{
		}

		private void HandleTopRight(object sender, DragDeltaEventArgs args)
		{
		}

		private void HandleTopLeft(object sender, DragDeltaEventArgs args)
		{
		}

		private void HandleTop(object sender, DragDeltaEventArgs args)
		{
		}

		private void HandleLeft(object sender, DragDeltaEventArgs args)
		{
		}

		private void HandleRight(object sender, DragDeltaEventArgs args)
		{
		}

		private void HandleBottom(object sender, DragDeltaEventArgs args)
		{
		}

		private void AdornedElement_SizeChanged(object sender, SizeChangedEventArgs e)
		{
			FrameworkElement frameworkElement = sender as FrameworkElement;
			Rect rectInterior = this._prCropMask.RectInterior;
			bool flag = false;
			double num = rectInterior.Left;
			double num2 = rectInterior.Top;
			double width = rectInterior.Width;
			double height = rectInterior.Height;
			if (rectInterior.Left > frameworkElement.RenderSize.Width)
			{
				num = frameworkElement.RenderSize.Width;
				width = 0.0;
				flag = true;
			}
			if (rectInterior.Top > frameworkElement.RenderSize.Height)
			{
				num2 = frameworkElement.RenderSize.Height;
				height = 0.0;
				flag = true;
			}
			if (rectInterior.Right > frameworkElement.RenderSize.Width)
			{
				width = System.Math.Max(0.0, frameworkElement.RenderSize.Width - num);
				flag = true;
			}
			if (rectInterior.Bottom > frameworkElement.RenderSize.Height)
			{
				height = System.Math.Max(0.0, frameworkElement.RenderSize.Height - num2);
				flag = true;
			}
			if (flag)
			{
				this._prCropMask.RectInterior = new Rect(num, num2, width, height);
			}
		}

		private void AdornedElement_SizeChanged(object sender, MouseEventArgs e)
		{
			FrameworkElement frameworkElement = sender as FrameworkElement;
			Rect rectInterior = this._prCropMask.RectInterior;
			bool flag = false;
			double num = rectInterior.Left;
			double num2 = rectInterior.Top;
			double width = rectInterior.Width;
			double height = rectInterior.Height;
			if (rectInterior.Left > frameworkElement.RenderSize.Width)
			{
				num = frameworkElement.RenderSize.Width;
				width = 0.0;
				flag = true;
			}
			if (rectInterior.Top > frameworkElement.RenderSize.Height)
			{
				num2 = frameworkElement.RenderSize.Height;
				height = 0.0;
				flag = true;
			}
			if (rectInterior.Right > frameworkElement.RenderSize.Width)
			{
				width = System.Math.Max(0.0, frameworkElement.RenderSize.Width - num);
				flag = true;
			}
			if (rectInterior.Bottom > frameworkElement.RenderSize.Height)
			{
				height = System.Math.Max(0.0, frameworkElement.RenderSize.Height - num2);
				flag = true;
			}
			if (flag)
			{
				this._prCropMask.RectInterior = new Rect(num, num2, width, height);
			}
		}

		private void SetThumbs(Rect rc)
		{
			this._crtBottomRight.SetPos(rc.Right, rc.Bottom);
			this._crtTopLeft.SetPos(rc.Left, rc.Top);
			this._crtTopRight.SetPos(rc.Right, rc.Top);
			this._crtBottomLeft.SetPos(rc.Left, rc.Bottom);
			this._crtTop.SetPos(rc.Left + rc.Width / 2.0, rc.Top);
			this._crtBottom.SetPos(rc.Left + rc.Width / 2.0, rc.Bottom);
			this._crtLeft.SetPos(rc.Left, rc.Top + rc.Height / 2.0);
			this._crtRight.SetPos(rc.Right, rc.Top + rc.Height / 2.0);
		}

		protected override Size ArrangeOverride(Size finalSize)
		{
			Rect rect = new Rect(0.0, 0.0, base.AdornedElement.RenderSize.Width, base.AdornedElement.RenderSize.Height);
			this._prCropMask.RectExterior = rect;
			Rect rectInterior = this._prCropMask.RectInterior;
			this._prCropMask.Arrange(rect);
			this.SetThumbs(rectInterior);
			this._cnvThumbs.Arrange(rect);
			return finalSize;
		}

		public Int32Rect getCordinate()
		{
			Thickness thickness = this.AdornerMargin();
			Rect rectInterior = this._prCropMask.RectInterior;
			Point point = this.UnitsToPx(rectInterior.Width, rectInterior.Height);
			Point point2 = this.UnitsToPx(rectInterior.Left + thickness.Left, rectInterior.Top + thickness.Top);
			Point point3 = this.UnitsToPx(base.AdornedElement.RenderSize.Width + thickness.Left, base.AdornedElement.RenderSize.Height + thickness.Left);
			point.X = System.Math.Max(System.Math.Min(point3.X - point2.X, point.X), 0.0);
			point.Y = System.Math.Max(System.Math.Min(point3.Y - point2.Y, point.Y), 0.0);
			Int32Rect result = new Int32Rect((int)point2.X, (int)point2.Y, (int)point.X, (int)point.Y);
			return result;
		}

		public BitmapSource BpsCrop()
		{
			BitmapSource result;
			try
			{
				Thickness thickness = this.AdornerMargin();
				Rect rectInterior = this._prCropMask.RectInterior;
				Point point = this.UnitsToPx(rectInterior.Width, rectInterior.Height);
				Point point2 = this.UnitsToPx(rectInterior.Left + thickness.Left, rectInterior.Top + thickness.Top);
				Point point3 = this.UnitsToPx(base.AdornedElement.RenderSize.Width + thickness.Left, base.AdornedElement.RenderSize.Height + thickness.Left);
				point.X = System.Math.Max(System.Math.Min(point3.X - point2.X, point.X), 0.0);
				point.Y = System.Math.Max(System.Math.Min(point3.Y - point2.Y, point.Y), 0.0);
				if (point.X == 0.0 || point.Y == 0.0)
				{
					result = null;
				}
				else
				{
					Int32Rect sourceRect = new Int32Rect((int)point2.X, (int)point2.Y, (int)point.X, (int)point.Y);
					RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap((int)point3.X, (int)point3.Y, CroppingAdorner.s_dpiX, CroppingAdorner.s_dpiY, PixelFormats.Default);
					renderTargetBitmap.Render(base.AdornedElement);
					result = new CroppedBitmap(renderTargetBitmap, sourceRect);
				}
			}
			catch (System.Exception var_7_191)
			{
				result = null;
			}
			finally
			{
				MemoryManagement.FlushMemory();
			}
			return result;
		}

		private Thickness AdornerMargin()
		{
			Thickness margin = new Thickness(0.0);
			if (base.AdornedElement is FrameworkElement)
			{
				margin = ((FrameworkElement)base.AdornedElement).Margin;
			}
			return margin;
		}

		private void BuildCorner(ref CroppingAdorner.CropThumb crt, Cursor crs)
		{
			if (crt == null)
			{
				crt = new CroppingAdorner.CropThumb(16);
				crt.Cursor = crs;
				crt.Background = new SolidColorBrush(Colors.MediumBlue);
				this._cnvThumbs.Children.Add(crt);
			}
		}

		private Point UnitsToPx(double x, double y)
		{
			return new Point((double)((int)(x * CroppingAdorner.s_dpiX / 96.0)), (double)((int)(y * CroppingAdorner.s_dpiY / 96.0)));
		}

		protected override Visual GetVisualChild(int index)
		{
			return this._vc[index];
		}
	}
}
