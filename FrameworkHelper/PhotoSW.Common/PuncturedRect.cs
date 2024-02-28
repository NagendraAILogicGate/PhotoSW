using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PhotoSW.Common
{
	public class PuncturedRect : Shape
	{
		public static readonly DependencyProperty RectInteriorProperty = DependencyProperty.Register("RectInterior", typeof(Rect), typeof(FrameworkElement), new FrameworkPropertyMetadata(new Rect(0.0, 0.0, 0.0, 0.0), FrameworkPropertyMetadataOptions.AffectsRender, null, new CoerceValueCallback(PuncturedRect.CoerceRectInterior), false), null);

		public static readonly DependencyProperty RectExteriorProperty = DependencyProperty.Register("RectExterior", typeof(Rect), typeof(FrameworkElement), new FrameworkPropertyMetadata(new Rect(0.0, 0.0, 1.7976931348623157E+308, 1.7976931348623157E+308), FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange | FrameworkPropertyMetadataOptions.AffectsRender, null, null, false), null);

		public Rect RectInterior
		{
			get
			{
				return (Rect)base.GetValue(PuncturedRect.RectInteriorProperty);
			}
			set
			{
				base.SetValue(PuncturedRect.RectInteriorProperty, value);
			}
		}

		public Rect RectExterior
		{
			get
			{
				return (Rect)base.GetValue(PuncturedRect.RectExteriorProperty);
			}
			set
			{
				base.SetValue(PuncturedRect.RectExteriorProperty, value);
			}
		}

		protected override Geometry DefiningGeometry
		{
			get
			{
				PathGeometry pathGeometry = new PathGeometry();
				PathFigure pathFigure = new PathFigure();
				pathFigure.StartPoint = this.RectExterior.TopLeft;
				pathFigure.Segments.Add(new LineSegment(this.RectExterior.TopRight, false));
				pathFigure.Segments.Add(new LineSegment(this.RectExterior.BottomRight, false));
				pathFigure.Segments.Add(new LineSegment(this.RectExterior.BottomLeft, false));
				pathFigure.Segments.Add(new LineSegment(this.RectExterior.TopLeft, false));
				pathGeometry.Figures.Add(pathFigure);
				Rect rect = Rect.Intersect(this.RectExterior, this.RectInterior);
				PathGeometry pathGeometry2 = new PathGeometry();
				PathFigure pathFigure2 = new PathFigure();
				pathFigure2.StartPoint = rect.TopLeft;
				pathFigure2.Segments.Add(new LineSegment(rect.TopRight, false));
				pathFigure2.Segments.Add(new LineSegment(rect.BottomRight, false));
				pathFigure2.Segments.Add(new LineSegment(rect.BottomLeft, false));
				pathFigure2.Segments.Add(new LineSegment(rect.TopLeft, false));
				pathGeometry2.Figures.Add(pathFigure2);
				return new CombinedGeometry(GeometryCombineMode.Exclude, pathGeometry, pathGeometry2);
			}
		}

		private static object CoerceRectInterior(DependencyObject d, object value)
		{
			PuncturedRect puncturedRect = (PuncturedRect)d;
			Rect rectExterior = puncturedRect.RectExterior;
			Rect rect = (Rect)value;
			double num = System.Math.Max(rect.Left, rectExterior.Left);
			double num2 = System.Math.Max(rect.Top, rectExterior.Top);
			double width = System.Math.Min(rect.Right, rectExterior.Right) - num;
			double height = System.Math.Min(rect.Bottom, rectExterior.Bottom) - num2;
			rect = new Rect(num, num2, width, height);
			return rect;
		}

		public PuncturedRect() : this(new Rect(0.0, 0.0, 1.7976931348623157E+308, 1.7976931348623157E+308), default(Rect))
		{
		}

		public PuncturedRect(Rect rectExterior, Rect rectInterior)
		{
			this.RectInterior = rectInterior;
			this.RectExterior = rectExterior;
		}
	}
}
