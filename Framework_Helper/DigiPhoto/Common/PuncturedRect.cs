namespace DigiPhoto.Common
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Shapes;

    public class PuncturedRect : Shape
    {
        public static readonly DependencyProperty RectExteriorProperty = DependencyProperty.Register("RectExterior", typeof(Rect), typeof(FrameworkElement), new FrameworkPropertyMetadata(new Rect(0.0, 0.0, double.MaxValue, double.MaxValue), FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.AffectsParentArrange | FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsMeasure, null, null, false), null);
        public static readonly DependencyProperty RectInteriorProperty = DependencyProperty.Register("RectInterior", typeof(Rect), typeof(FrameworkElement), new FrameworkPropertyMetadata(new Rect(0.0, 0.0, 0.0, 0.0), FrameworkPropertyMetadataOptions.AffectsRender, null, new CoerceValueCallback(PuncturedRect.CoerceRectInterior), false), null);

        public PuncturedRect() : this(new Rect(0.0, 0.0, double.MaxValue, double.MaxValue), new Rect())
        {
        }

        public PuncturedRect(Rect rectExterior, Rect rectInterior)
        {
            this.RectInterior = rectInterior;
            this.RectExterior = rectExterior;
        }

        private static object CoerceRectInterior(DependencyObject d, object value)
        {
            PuncturedRect rect = (PuncturedRect) d;
            Rect rectExterior = rect.RectExterior;
            Rect rect3 = (Rect) value;
            double x = Math.Max(rect3.Left, rectExterior.Left);
            double y = Math.Max(rect3.Top, rectExterior.Top);
            double width = Math.Min(rect3.Right, rectExterior.Right) - x;
            return new Rect(x, y, width, Math.Min(rect3.Bottom, rectExterior.Bottom) - y);
        }

        protected override Geometry DefiningGeometry
        {
            get
            {
                PathGeometry geometry = new PathGeometry();
                PathFigure figure = new PathFigure {
                    StartPoint = this.RectExterior.TopLeft
                };
                figure.Segments.Add(new LineSegment(this.RectExterior.TopRight, false));
                figure.Segments.Add(new LineSegment(this.RectExterior.BottomRight, false));
                figure.Segments.Add(new LineSegment(this.RectExterior.BottomLeft, false));
                figure.Segments.Add(new LineSegment(this.RectExterior.TopLeft, false));
                geometry.Figures.Add(figure);
                Rect rect = Rect.Intersect(this.RectExterior, this.RectInterior);
                PathGeometry geometry2 = new PathGeometry();
                PathFigure figure2 = new PathFigure {
                    StartPoint = rect.TopLeft
                };
                figure2.Segments.Add(new LineSegment(rect.TopRight, false));
                figure2.Segments.Add(new LineSegment(rect.BottomRight, false));
                figure2.Segments.Add(new LineSegment(rect.BottomLeft, false));
                figure2.Segments.Add(new LineSegment(rect.TopLeft, false));
                geometry2.Figures.Add(figure2);
                return new CombinedGeometry(GeometryCombineMode.Exclude, geometry, geometry2);
            }
        }

        public Rect RectExterior
        {
            get
            {
                return (Rect) base.GetValue(RectExteriorProperty);
            }
            set
            {
                base.SetValue(RectExteriorProperty, value);
            }
        }

        public Rect RectInterior
        {
            get
            {
                return (Rect) base.GetValue(RectInteriorProperty);
            }
            set
            {
                base.SetValue(RectInteriorProperty, value);
            }
        }
    }
}

