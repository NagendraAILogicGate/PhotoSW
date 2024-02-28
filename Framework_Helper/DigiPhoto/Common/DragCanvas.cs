namespace DigiPhoto.Common
{
    using System;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Media3D;

    public class DragCanvas : Canvas
    {
        public static readonly DependencyProperty AllowDraggingProperty = DependencyProperty.Register("AllowDragging", typeof(bool), typeof(DragCanvas), new PropertyMetadata(true));
        public static readonly DependencyProperty AllowDragOutOfViewProperty = DependencyProperty.Register("AllowDragOutOfView", typeof(bool), typeof(DragCanvas), new UIPropertyMetadata(false));
        public static readonly DependencyProperty CanBeDraggedProperty = DependencyProperty.RegisterAttached("CanBeDragged", typeof(bool), typeof(DragCanvas), new UIPropertyMetadata(true));
        private UIElement elementBeingDragged;
        private bool isDragInProgress;
        private bool modifyLeftOffset;
        private bool modifyTopOffset;
        private Point origCursorLocation;
        private double origHorizOffset;
        private double origVertOffset;

        public void BringToFront(UIElement element)
        {
            this.UpdateZOrder(element, true);
        }

        private Rect CalculateDragElementRect(double newHorizOffset, double newVertOffset)
        {
            double num;
            double num2;
            if (this.ElementBeingDragged == null)
            {
                throw new InvalidOperationException("ElementBeingDragged is null.");
            }
            Size renderSize = this.ElementBeingDragged.RenderSize;
            if (this.modifyLeftOffset)
            {
                num = newHorizOffset;
            }
            else
            {
                num = (base.ActualWidth - newHorizOffset) - renderSize.Width;
            }
            if (this.modifyTopOffset)
            {
                num2 = newVertOffset;
            }
            else
            {
                num2 = (base.ActualHeight - newVertOffset) - renderSize.Height;
            }
            return new Rect(new Point(num, num2), renderSize);
        }

        public UIElement FindCanvasChild(DependencyObject depObj)
        {
            while (depObj != null)
            {
                UIElement element = depObj as UIElement;
                if ((element != null) && base.Children.Contains(element))
                {
                    break;
                }
                if ((depObj is Visual) || (depObj is Visual3D))
                {
                    depObj = VisualTreeHelper.GetParent(depObj);
                }
                else
                {
                    depObj = LogicalTreeHelper.GetParent(depObj);
                }
            }
            return (depObj as UIElement);
        }

        public static bool GetCanBeDragged(UIElement uiElement)
        {
            if (uiElement == null)
            {
                return false;
            }
            return (bool) uiElement.GetValue(CanBeDraggedProperty);
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
                this.origHorizOffset = ResolveOffset(left, right, out this.modifyLeftOffset);
                this.origVertOffset = ResolveOffset(top, bottom, out this.modifyTopOffset);
                e.Handled = true;
                this.isDragInProgress = true;
                if (e.Source is Image)
                {
                    Image source = (Image) e.Source;
                    if (source.Parent is Button)
                    {
                        ((Button) source.Parent).Focus();
                    }
                }
            }
        }

        protected override void OnPreviewMouseMove(MouseEventArgs e)
        {
            base.OnPreviewMouseMove(e);
            if ((this.ElementBeingDragged != null) && this.isDragInProgress)
            {
                double num;
                double num2;
                Point position = e.GetPosition(this);
                if (this.modifyLeftOffset)
                {
                    num = this.origHorizOffset + (position.X - this.origCursorLocation.X);
                }
                else
                {
                    num = this.origHorizOffset - (position.X - this.origCursorLocation.X);
                }
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
                        num = this.modifyLeftOffset ? 0.0 : (base.ActualWidth - rect.Width);
                    }
                    else if (flag2)
                    {
                        num = this.modifyLeftOffset ? (base.ActualWidth - rect.Width) : 0.0;
                    }
                    bool flag3 = rect.Top < 0.0;
                    bool flag4 = rect.Bottom > base.ActualHeight;
                    if (flag3)
                    {
                        num2 = this.modifyTopOffset ? 0.0 : (base.ActualHeight - rect.Height);
                    }
                    else if (flag4)
                    {
                        num2 = this.modifyTopOffset ? (base.ActualHeight - rect.Height) : 0.0;
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

        private static double ResolveOffset(double side1, double side2, out bool useSide1)
        {
            useSide1 = true;
            if (double.IsNaN(side1))
            {
                if (double.IsNaN(side2))
                {
                    return 0.0;
                }
                double num = side2;
                useSide1 = false;
                return num;
            }
            return side1;
        }

        public void SendToBack(UIElement element)
        {
            this.UpdateZOrder(element, false);
        }

        public static void SetCanBeDragged(UIElement uiElement, bool value)
        {
            if (uiElement != null)
            {
                uiElement.SetValue(CanBeDraggedProperty, value);
            }
        }

        private void UpdateZOrder(UIElement element, bool bringToFront)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            if (!base.Children.Contains(element))
            {
                throw new ArgumentException("Must be a child element of the Canvas.", "element");
            }
            int num = -1;
            if (bringToFront)
            {
                foreach (UIElement element2 in base.Children)
                {
                    if (element2.Visibility != Visibility.Collapsed)
                    {
                        num++;
                    }
                }
            }
            else
            {
                num = 0;
            }
            int num2 = (num == 0) ? 1 : -1;
            int zIndex = Panel.GetZIndex(element);
            foreach (UIElement element3 in base.Children)
            {
                if (element3 == element)
                {
                    Panel.SetZIndex(element, num);
                }
                else
                {
                    int num4 = Panel.GetZIndex(element3);
                    if ((bringToFront && (zIndex < num4)) || (!bringToFront && (num4 < zIndex)))
                    {
                        Panel.SetZIndex(element3, num4 + num2);
                    }
                }
            }
        }

        public bool AllowDragging
        {
            get
            {
                return (bool) base.GetValue(AllowDraggingProperty);
            }
            set
            {
                base.SetValue(AllowDraggingProperty, value);
            }
        }

        public bool AllowDragOutOfView
        {
            get
            {
                return (bool) base.GetValue(AllowDragOutOfViewProperty);
            }
            set
            {
                base.SetValue(AllowDragOutOfViewProperty, value);
            }
        }

        public UIElement ElementBeingDragged
        {
            get
            {
                if (!this.AllowDragging)
                {
                    return null;
                }
                return this.elementBeingDragged;
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
                else if (GetCanBeDragged(value))
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
    }
}

