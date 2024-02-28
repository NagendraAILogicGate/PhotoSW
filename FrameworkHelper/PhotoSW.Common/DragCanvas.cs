using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Media3D;

namespace PhotoSW.Common
{
	public class DragCanvas : Canvas
	{
		private UIElement elementBeingDragged;

		private Point origCursorLocation;

		private double origHorizOffset;

		private double origVertOffset;

		private bool modifyLeftOffset;

		private bool modifyTopOffset;

		private bool isDragInProgress;

		public static readonly DependencyProperty CanBeDraggedProperty;

		public static readonly DependencyProperty AllowDraggingProperty;

		public static readonly DependencyProperty AllowDragOutOfViewProperty;

		public bool AllowDragging
		{
			get
			{
				return (bool)base.GetValue(DragCanvas.AllowDraggingProperty);
			}
			set
			{
				base.SetValue(DragCanvas.AllowDraggingProperty, value);
			}
		}

		public bool AllowDragOutOfView
		{
			get
			{
				return (bool)base.GetValue(DragCanvas.AllowDragOutOfViewProperty);
			}
			set
			{
				base.SetValue(DragCanvas.AllowDragOutOfViewProperty, value);
			}
		}

		public UIElement ElementBeingDragged
		{
			get
			{
				UIElement result;
				if (!this.AllowDragging)
				{
					result = null;
				}
				else
				{
					result = this.elementBeingDragged;
				}
				return result;
			}
			protected set
			{
				if (this.elementBeingDragged != null)
				{
					this.elementBeingDragged.ReleaseMouseCapture();
				}
				if (!this.AllowDragging)
				{
					this.elementBeingDragged = null;
				}
				else if (DragCanvas.GetCanBeDragged(value))
				{
					this.elementBeingDragged = value;
					this.elementBeingDragged.CaptureMouse();
				}
				else
				{
					this.elementBeingDragged = null;
				}
			}
		}

		public static bool GetCanBeDragged(UIElement uiElement)
		{
			return uiElement != null && (bool)uiElement.GetValue(DragCanvas.CanBeDraggedProperty);
		}

		public static void SetCanBeDragged(UIElement uiElement, bool value)
		{
			if (uiElement != null)
			{
				uiElement.SetValue(DragCanvas.CanBeDraggedProperty, value);
			}
		}

		static DragCanvas()
		{
			DragCanvas.AllowDraggingProperty = DependencyProperty.Register("AllowDragging", typeof(bool), typeof(DragCanvas), new PropertyMetadata(true));
			DragCanvas.AllowDragOutOfViewProperty = DependencyProperty.Register("AllowDragOutOfView", typeof(bool), typeof(DragCanvas), new UIPropertyMetadata(false));
			DragCanvas.CanBeDraggedProperty = DependencyProperty.RegisterAttached("CanBeDragged", typeof(bool), typeof(DragCanvas), new UIPropertyMetadata(true));
		}

		public void BringToFront(UIElement element)
		{
			this.UpdateZOrder(element, true);
		}

		public void SendToBack(UIElement element)
		{
			this.UpdateZOrder(element, false);
		}

		public UIElement FindCanvasChild(DependencyObject depObj)
		{
			while (depObj != null)
			{
				UIElement uIElement = depObj as UIElement;
				if (uIElement != null && base.Children.Contains(uIElement))
				{
					break;
				}
				if (depObj is Visual || depObj is Visual3D)
				{
					depObj = VisualTreeHelper.GetParent(depObj);
				}
				else
				{
					depObj = LogicalTreeHelper.GetParent(depObj);
				}
			}
			return depObj as UIElement;
		}

		protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
		    {
			base.OnPreviewMouseLeftButtonDown(e);
			this.isDragInProgress = false;
			this.origCursorLocation = e.GetPosition(this);
			this.ElementBeingDragged = this.FindCanvasChild(e.Source as DependencyObject);
			if (this.ElementBeingDragged != null)
			{
				double left = Canvas.GetLeft(this.ElementBeingDragged);
				double right = Canvas.GetRight(this.ElementBeingDragged);
				double top = Canvas.GetTop(this.ElementBeingDragged);
				double bottom = Canvas.GetBottom(this.ElementBeingDragged);
				this.origHorizOffset = DragCanvas.ResolveOffset(left, right, out this.modifyLeftOffset);
				this.origVertOffset = DragCanvas.ResolveOffset(top, bottom, out this.modifyTopOffset);
				e.Handled = true;
				this.isDragInProgress = true;
				if (e.Source is Image)
				{
					Image image = (Image)e.Source;
					if (image.Parent is Button)
					{
						Button button = (Button)image.Parent;
						button.Focus();
					}
				}
			}
		}

		protected override void OnPreviewMouseMove(MouseEventArgs e)
		{
			base.OnPreviewMouseMove(e);
			if (this.ElementBeingDragged != null && this.isDragInProgress)
			{
				Point position = e.GetPosition(this);
				double num;
				if (this.modifyLeftOffset)
				{
					num = this.origHorizOffset + (position.X - this.origCursorLocation.X);
				}
				else
				{
					num = this.origHorizOffset - (position.X - this.origCursorLocation.X);
				}
				double num2;
				if (this.modifyTopOffset)
				{
					num2 = this.origVertOffset + (position.Y - this.origCursorLocation.Y);
				}
				else
				{
					num2 = this.origVertOffset - (position.Y - this.origCursorLocation.Y);
				}
				if (!this.AllowDragOutOfView)
				{
					Rect rect = this.CalculateDragElementRect(num, num2);
					bool flag = rect.Left < 0.0;
					bool flag2 = rect.Right > base.ActualWidth;
					if (flag)
					{
						num = (this.modifyLeftOffset ? 0.0 : (base.ActualWidth - rect.Width));
					}
					else if (flag2)
					{
						num = (this.modifyLeftOffset ? (base.ActualWidth - rect.Width) : 0.0);
					}
					bool flag3 = rect.Top < 0.0;
					bool flag4 = rect.Bottom > base.ActualHeight;
					if (flag3)
					{
						num2 = (this.modifyTopOffset ? 0.0 : (base.ActualHeight - rect.Height));
					}
					else if (flag4)
					{
						num2 = (this.modifyTopOffset ? (base.ActualHeight - rect.Height) : 0.0);
					}
				}
				if (this.modifyLeftOffset)
				{
					Canvas.SetLeft(this.ElementBeingDragged, num);
				}
				else
				{
					Canvas.SetRight(this.ElementBeingDragged, num);
				}
				if (this.modifyTopOffset)
				{
					Canvas.SetTop(this.ElementBeingDragged, num2);
				}
				else
				{
					Canvas.SetBottom(this.ElementBeingDragged, num2);
				}
			}
		}

		protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
		{
			base.OnPreviewMouseUp(e);
			this.ElementBeingDragged = null;
		}

		private Rect CalculateDragElementRect(double newHorizOffset, double newVertOffset)
		{
			if (this.ElementBeingDragged == null)
			{
				throw new System.InvalidOperationException("ElementBeingDragged is null.");
			}
			Size renderSize = this.ElementBeingDragged.RenderSize;
			double x;
			if (this.modifyLeftOffset)
			{
				x = newHorizOffset;
			}
			else
			{
				x = base.ActualWidth - newHorizOffset - renderSize.Width;
			}
			double y;
			if (this.modifyTopOffset)
			{
				y = newVertOffset;
			}
			else
			{
				y = base.ActualHeight - newVertOffset - renderSize.Height;
			}
			Point location = new Point(x, y);
			return new Rect(location, renderSize);
		}

		private static double ResolveOffset(double side1, double side2, out bool useSide1)
		{
			useSide1 = true;
			double result;
			if (double.IsNaN(side1))
			{
				if (double.IsNaN(side2))
				{
					result = 0.0;
				}
				else
				{
					result = side2;
					useSide1 = false;
				}
			}
			else
			{
				result = side1;
			}
			return result;
		}

		private void UpdateZOrder(UIElement element, bool bringToFront)
		{
			if (element == null)
			{
				throw new System.ArgumentNullException("element");
			}
			if (!base.Children.Contains(element))
			{
				throw new System.ArgumentException("Must be a child element of the Canvas.", "element");
			}
			int num = -1;
			if (bringToFront)
			{
				//using (System.Collections.IEnumerator enumerator = base.Children.GetEnumerator())
                try
                {
                    System.Collections.IEnumerator enumerator = base.Children.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        UIElement uIElement = (UIElement)enumerator.Current;
                        if (uIElement.Visibility != Visibility.Collapsed)
                        {
                            num++;
                        }
                    }
                }
                catch
                {
                    throw;
                }
			}
			else
			{
				num = 0;
			}
			int num2 = (num == 0) ? 1 : -1;
			int zIndex = Panel.GetZIndex(element);
			foreach (UIElement uIElement2 in base.Children)
			{
				if (uIElement2 == element)
				{
					Panel.SetZIndex(element, num);
				}
				else
				{
					int zIndex2 = Panel.GetZIndex(uIElement2);
					if ((bringToFront && zIndex < zIndex2) || (!bringToFront && zIndex2 < zIndex))
					{
						Panel.SetZIndex(uIElement2, zIndex2 + num2);
					}
				}
			}
		}
	}
}
