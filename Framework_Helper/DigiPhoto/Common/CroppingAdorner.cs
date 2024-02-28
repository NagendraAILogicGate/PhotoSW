namespace DigiPhoto.Common
{
    using DigiPhoto;
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Controls.Primitives;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;

    public class CroppingAdorner : Adorner
    {
        private Canvas _cnvThumbs;
        private const int _cpxThumbWidth = 0x10;
        private CropThumb _crtBottom;
        private CropThumb _crtBottomLeft;
        private CropThumb _crtBottomRight;
        private CropThumb _crtLeft;
        private CropThumb _crtRight;
        private CropThumb _crtTop;
        private CropThumb _crtTopLeft;
        private CropThumb _crtTopRight;
        private PuncturedRect _prCropMask;
        private VisualCollection _vc;
        public static DependencyProperty FillProperty = Shape.FillProperty.AddOwner(typeof(CroppingAdorner));
        private double OrigenX;
        private double OrigenY;
        public static double s_dpiX;
        public static double s_dpiY;

        static CroppingAdorner()
        {
            Color red = Colors.Red;
            s_dpiX = 300.0;
            s_dpiY = 300.0;
            red.A = 80;
            FillProperty.OverrideMetadata(typeof(CroppingAdorner), new PropertyMetadata(new SolidColorBrush(red), new PropertyChangedCallback(CroppingAdorner.FillPropChanged)));
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
            FrameworkElement element = adornedElement as FrameworkElement;
            if (element != null)
            {
                element.SizeChanged += new SizeChangedEventHandler(this.AdornedElement_SizeChanged);
            }
            this.OrigenY = 0.0;
            this.OrigenX = 0.0;
        }

        private void AdornedElement_SizeChanged(object sender, MouseEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            Rect rectInterior = this._prCropMask.RectInterior;
            bool flag = false;
            double left = rectInterior.Left;
            double top = rectInterior.Top;
            double width = rectInterior.Width;
            double height = rectInterior.Height;
            if (rectInterior.Left > element.RenderSize.Width)
            {
                left = element.RenderSize.Width;
                width = 0.0;
                flag = true;
            }
            if (rectInterior.Top > element.RenderSize.Height)
            {
                top = element.RenderSize.Height;
                height = 0.0;
                flag = true;
            }
            if (rectInterior.Right > element.RenderSize.Width)
            {
                width = Math.Max((double) 0.0, (double) (element.RenderSize.Width - left));
                flag = true;
            }
            if (rectInterior.Bottom > element.RenderSize.Height)
            {
                height = Math.Max((double) 0.0, (double) (element.RenderSize.Height - top));
                flag = true;
            }
            if (flag)
            {
                this._prCropMask.RectInterior = new Rect(left, top, width, height);
            }
        }

        private void AdornedElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            FrameworkElement element = sender as FrameworkElement;
            Rect rectInterior = this._prCropMask.RectInterior;
            bool flag = false;
            double left = rectInterior.Left;
            double top = rectInterior.Top;
            double width = rectInterior.Width;
            double height = rectInterior.Height;
            if (rectInterior.Left > element.RenderSize.Width)
            {
                left = element.RenderSize.Width;
                width = 0.0;
                flag = true;
            }
            if (rectInterior.Top > element.RenderSize.Height)
            {
                top = element.RenderSize.Height;
                height = 0.0;
                flag = true;
            }
            if (rectInterior.Right > element.RenderSize.Width)
            {
                width = Math.Max((double) 0.0, (double) (element.RenderSize.Width - left));
                flag = true;
            }
            if (rectInterior.Bottom > element.RenderSize.Height)
            {
                height = Math.Max((double) 0.0, (double) (element.RenderSize.Height - top));
                flag = true;
            }
            if (flag)
            {
                this._prCropMask.RectInterior = new Rect(left, top, width, height);
            }
        }

        private Thickness AdornerMargin()
        {
            Thickness margin = new Thickness(0.0);
            if (base.AdornedElement is FrameworkElement)
            {
                margin = ((FrameworkElement) base.AdornedElement).Margin;
            }
            return margin;
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Rect finalRect = new Rect(0.0, 0.0, base.AdornedElement.RenderSize.Width, base.AdornedElement.RenderSize.Height);
            this._prCropMask.RectExterior = finalRect;
            Rect rectInterior = this._prCropMask.RectInterior;
            this._prCropMask.Arrange(finalRect);
            this.SetThumbs(rectInterior);
            this._cnvThumbs.Arrange(finalRect);
            return finalSize;
        }

        public BitmapSource BpsCrop()
        {
            BitmapSource source;
            try
            {
                Thickness thickness = this.AdornerMargin();
                Rect rectInterior = this._prCropMask.RectInterior;
                Point point = this.UnitsToPx(rectInterior.Width, rectInterior.Height);
                Point point2 = this.UnitsToPx(rectInterior.Left + thickness.Left, rectInterior.Top + thickness.Top);
                Point point3 = this.UnitsToPx(base.AdornedElement.RenderSize.Width + thickness.Left, base.AdornedElement.RenderSize.Height + thickness.Left);
                point.X = Math.Max(Math.Min(point3.X - point2.X, point.X), 0.0);
                point.Y = Math.Max(Math.Min(point3.Y - point2.Y, point.Y), 0.0);
                if ((point.X == 0.0) || (point.Y == 0.0))
                {
                    return null;
                }
                Int32Rect sourceRect = new Int32Rect((int) point2.X, (int) point2.Y, (int) point.X, (int) point.Y);
                RenderTargetBitmap bitmap = new RenderTargetBitmap((int) point3.X, (int) point3.Y, s_dpiX, s_dpiY, PixelFormats.Default);
                bitmap.Render(base.AdornedElement);
                source = new CroppedBitmap(bitmap, sourceRect);
            }
            catch (Exception)
            {
                source = null;
            }
            finally
            {
                MemoryManagement.FlushMemory();
            }
            return source;
        }

        private void BuildCorner(ref CropThumb crt, Cursor crs)
        {
            if (crt == null)
            {
                crt = new CropThumb(0x10);
                crt.Cursor = crs;
                crt.Background = new SolidColorBrush(Colors.MediumBlue);
                this._cnvThumbs.Children.Add(crt);
            }
        }

        private static void FillPropChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            CroppingAdorner adorner = d as CroppingAdorner;
            if (adorner != null)
            {
                adorner._prCropMask.Fill = (Brush) args.NewValue;
            }
        }

        public Int32Rect getCordinate()
        {
            Thickness thickness = this.AdornerMargin();
            Rect rectInterior = this._prCropMask.RectInterior;
            Point point = this.UnitsToPx(rectInterior.Width, rectInterior.Height);
            Point point2 = this.UnitsToPx(rectInterior.Left + thickness.Left, rectInterior.Top + thickness.Top);
            Point point3 = this.UnitsToPx(base.AdornedElement.RenderSize.Width + thickness.Left, base.AdornedElement.RenderSize.Height + thickness.Left);
            point.X = Math.Max(Math.Min(point3.X - point2.X, point.X), 0.0);
            point.Y = Math.Max(Math.Min(point3.Y - point2.Y, point.Y), 0.0);
            return new Int32Rect((int) point2.X, (int) point2.Y, (int) point.X, (int) point.Y);
        }

        protected override Visual GetVisualChild(int index)
        {
            return this._vc[index];
        }

        private void Handle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Grid relativeTo = new Grid();
            if (sender is Grid)
            {
                relativeTo = sender as Grid;
                if (relativeTo.Name != "GrdCrop")
                {
                    return;
                }
            }
            if (relativeTo != null)
            {
                this.OrigenX = e.GetPosition(relativeTo).X;
                this.OrigenY = e.GetPosition(relativeTo).Y;
                relativeTo.CaptureMouse();
            }
        }

        private void Handle_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Grid grid = new Grid();
            if (sender is Grid)
            {
                grid = sender as Grid;
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

        private void Handle_MouseMove(object sender, MouseEventArgs args)
        {
            Grid relativeTo = new Grid();
            if (sender is Grid)
            {
                relativeTo = sender as Grid;
                if (relativeTo.Name != "GrdCrop")
                {
                    return;
                }
            }
            if ((relativeTo != null) && relativeTo.IsMouseCaptured)
            {
                double x = args.GetPosition(relativeTo).X;
                double y = args.GetPosition(relativeTo).Y;
                double dx = this._prCropMask.RectInterior.X;
                double dy = this._prCropMask.RectInterior.Y;
                double width = this._prCropMask.RectInterior.Width;
                double height = this._prCropMask.RectInterior.Height;
                if (((x != this.OrigenX) || !(y == this.OrigenY)) && (((x > dx) && (x < (dx + width))) && ((y > dy) && (y < (dy + height)))))
                {
                    dx += x - this.OrigenX;
                    dy += y - this.OrigenY;
                    if (dx < 0.0)
                    {
                        dx = 0.0;
                    }
                    if ((dx + width) > relativeTo.ActualWidth)
                    {
                        dx = relativeTo.ActualWidth - width;
                    }
                    if (dy < 0.0)
                    {
                        dy = 0.0;
                    }
                    if ((dy + height) > relativeTo.ActualHeight)
                    {
                        dy = relativeTo.ActualHeight - height;
                    }
                    this.OrigenX = x;
                    this.OrigenY = y;
                    this.HandleDrag(dx, dy);
                }
            }
        }

        private void HandleBottom(object sender, DragDeltaEventArgs args)
        {
        }

        private void HandleBottomLeft(object sender, DragDeltaEventArgs args)
        {
        }

        private void HandleBottomRight(object sender, DragDeltaEventArgs args)
        {
        }

        private void HandleDrag(double dx, double dy)
        {
            Rect rectInterior = this._prCropMask.RectInterior;
            rectInterior = new Rect(dx, dy, rectInterior.Width, rectInterior.Height);
            this._prCropMask.RectInterior = rectInterior;
            this.SetThumbs(this._prCropMask.RectInterior);
        }

        private void HandleLeft(object sender, DragDeltaEventArgs args)
        {
        }

        private void HandleRight(object sender, DragDeltaEventArgs args)
        {
        }

        private void HandleThumb(double drcL, double drcT, double drcW, double drcH, double dx, double dy)
        {
            Rect rectInterior = this._prCropMask.RectInterior;
            if ((rectInterior.Width + (drcW * dx)) < 0.0)
            {
                dx = -rectInterior.Width / drcW;
            }
            if ((rectInterior.Height + (drcH * dy)) < 0.0)
            {
                dy = -rectInterior.Height / drcH;
            }
            rectInterior = new Rect(rectInterior.Left + (drcL * dx), rectInterior.Top + (drcT * dy), rectInterior.Width + (drcW * dx), rectInterior.Height + (drcH * dy));
            this._prCropMask.RectInterior = rectInterior;
            this.SetThumbs(this._prCropMask.RectInterior);
        }

        private void HandleTop(object sender, DragDeltaEventArgs args)
        {
        }

        private void HandleTopLeft(object sender, DragDeltaEventArgs args)
        {
        }

        private void HandleTopRight(object sender, DragDeltaEventArgs args)
        {
        }

        public void ReleaseResources(UIElement adornedElement)
        {
            adornedElement.MouseLeftButtonDown -= new MouseButtonEventHandler(this.Handle_MouseLeftButtonDown);
            adornedElement.MouseLeftButtonUp -= new MouseButtonEventHandler(this.Handle_MouseLeftButtonUp);
            adornedElement.MouseMove -= new MouseEventHandler(this.Handle_MouseMove);
        }

        private void SetThumbs(Rect rc)
        {
            this._crtBottomRight.SetPos(rc.Right, rc.Bottom);
            this._crtTopLeft.SetPos(rc.Left, rc.Top);
            this._crtTopRight.SetPos(rc.Right, rc.Top);
            this._crtBottomLeft.SetPos(rc.Left, rc.Bottom);
            this._crtTop.SetPos(rc.Left + (rc.Width / 2.0), rc.Top);
            this._crtBottom.SetPos(rc.Left + (rc.Width / 2.0), rc.Bottom);
            this._crtLeft.SetPos(rc.Left, rc.Top + (rc.Height / 2.0));
            this._crtRight.SetPos(rc.Right, rc.Top + (rc.Height / 2.0));
        }

        private Point UnitsToPx(double x, double y)
        {
            return new Point((double) ((int) ((x * s_dpiX) / 96.0)), (double) ((int) ((y * s_dpiY) / 96.0)));
        }

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
                return (Brush) base.GetValue(FillProperty);
            }
            set
            {
                base.SetValue(FillProperty, value);
            }
        }

        protected override int VisualChildrenCount
        {
            get
            {
                return this._vc.Count;
            }
        }

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
                Canvas.SetTop(this, y - (this._cpx / 2));
                Canvas.SetLeft(this, x - (this._cpx / 2));
            }
        }
    }
}

