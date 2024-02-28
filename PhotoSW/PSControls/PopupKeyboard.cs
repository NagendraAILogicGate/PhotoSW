using System;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
//using PhotoSW.PSControls;

namespace PhotoSW.PSControls
{
    public static class PopupKeyboard
    {
        private static PopupKeyboardUserControl _popupKeyboardUserControl;

        private static readonly double MinimumWidth = 180.0;

        private static readonly double MinimumHeight = 200.0;

        public static readonly DependencyProperty PlacementProperty = DependencyProperty.RegisterAttached("Placement", typeof(PlacementMode), typeof(PopupKeyboard), new FrameworkPropertyMetadata(PlacementMode.Bottom, new PropertyChangedCallback(PopupKeyboard.OnPlacementChanged)));

        public static readonly DependencyProperty PlacementTargetProperty = DependencyProperty.RegisterAttached("PlacementTarget", typeof(UIElement), typeof(PopupKeyboard), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(PopupKeyboard.OnPlacementTargetChanged)));

        public static readonly DependencyProperty PlacementRectangleProperty = DependencyProperty.RegisterAttached("PlacementRectangle", typeof(Rect), typeof(PopupKeyboard), new FrameworkPropertyMetadata(Rect.Empty, new PropertyChangedCallback(PopupKeyboard.OnPlacementRectangleChanged)));

        public static readonly DependencyProperty HorizontalOffsetProperty = DependencyProperty.RegisterAttached("HorizontalOffset", typeof(double), typeof(PopupKeyboard), new FrameworkPropertyMetadata(0.0, new PropertyChangedCallback(PopupKeyboard.OnHorizontalOffsetChanged)));

        public static readonly DependencyProperty VerticalOffsetProperty = DependencyProperty.RegisterAttached("VerticalOffset", typeof(double), typeof(PopupKeyboard), new FrameworkPropertyMetadata(0.0, new PropertyChangedCallback(PopupKeyboard.OnVerticalOffsetChanged)));

        public static readonly DependencyProperty CustomPopupPlacementCallbackProperty = DependencyProperty.RegisterAttached("CustomPopupPlacementCallback", typeof(CustomPopupPlacementCallback), typeof(PopupKeyboard), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(PopupKeyboard.OnCustomPopupPlacementCallbackChanged)));

        public static readonly DependencyProperty StateProperty = DependencyProperty.RegisterAttached("State", typeof(KeyboardState), typeof(PopupKeyboard), new FrameworkPropertyMetadata(KeyboardState.Normal, new PropertyChangedCallback(PopupKeyboard.OnStateChanged)));

        public static readonly DependencyProperty HeightProperty = DependencyProperty.RegisterAttached("Height", typeof(double), typeof(PopupKeyboard), new FrameworkPropertyMetadata(PopupKeyboard.MinimumHeight, new PropertyChangedCallback(PopupKeyboard.OnHeightChanged), new CoerceValueCallback(PopupKeyboard.CoerceHeight)));

        public static readonly DependencyProperty WidthProperty = DependencyProperty.RegisterAttached("Width", typeof(double), typeof(PopupKeyboard), new FrameworkPropertyMetadata(PopupKeyboard.MinimumWidth, new PropertyChangedCallback(PopupKeyboard.OnWidthChanged), new CoerceValueCallback(PopupKeyboard.CoerceWidth)));

        public static readonly DependencyProperty IsEnabledProperty = DependencyProperty.RegisterAttached("IsEnabled", typeof(bool), typeof(PopupKeyboard), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(PopupKeyboard.OnIsEnabledChanged)));

        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static PlacementMode GetPlacement(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            PlacementMode expr_20 = (PlacementMode)element.GetValue(PopupKeyboard.PlacementProperty);
            PlacementMode result;
            if (!false)
            {
                result = expr_20;
            }
            return result;
        }

        public static void SetPlacement(DependencyObject element, PlacementMode value)
        {
            bool arg_07_0 = element == null;
            bool expr_07;
            do
            {
                expr_07 = (arg_07_0 = !arg_07_0);
            }
            while (7 == 0);
            bool flag = expr_07;
            while (!false)
            {
                if (!flag)
                {
                    throw new ArgumentNullException("element");
                }
                if (!false && true)
                {
                    element.SetValue(PopupKeyboard.PlacementProperty, value);
                    break;
                }
            }
        }

        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static UIElement GetPlacementTarget(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            UIElement expr_20 = (UIElement)element.GetValue(PopupKeyboard.PlacementTargetProperty);
            UIElement result;
            if (!false)
            {
                result = expr_20;
            }
            return result;
        }

        public static void SetPlacementTarget(DependencyObject element, UIElement value)
        {
            if (false)
            {
                goto IL_15;
            }
            bool arg_33_0;
            bool expr_07 = arg_33_0 = (element == null);
            if (!false)
            {
                arg_33_0 = !expr_07;
            }
            bool flag = arg_33_0;
        IL_11:
            if (flag)
            {
                goto IL_20;
            }
        IL_15:
            if (!false)
            {
                throw new ArgumentNullException("element");
            }
        IL_20:
            element.SetValue(PopupKeyboard.PlacementTargetProperty, value);
            if (!false)
            {
                return;
            }
            goto IL_11;
        }

        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static Rect GetPlacementRectangle(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            Rect expr_20 = (Rect)element.GetValue(PopupKeyboard.PlacementRectangleProperty);
            Rect result;
            if (!false)
            {
                result = expr_20;
            }
            return result;
        }

        public static void SetPlacementRectangle(DependencyObject element, Rect value)
        {
            bool arg_07_0 = element == null;
            bool expr_07;
            do
            {
                expr_07 = (arg_07_0 = !arg_07_0);
            }
            while (7 == 0);
            bool flag = expr_07;
            while (!false)
            {
                if (!flag)
                {
                    throw new ArgumentNullException("element");
                }
                if (!false && true)
                {
                    element.SetValue(PopupKeyboard.PlacementRectangleProperty, value);
                    break;
                }
            }
        }

        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static double GetHorizontalOffset(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            double expr_20 = (double)element.GetValue(PopupKeyboard.HorizontalOffsetProperty);
            double result;
            if (!false)
            {
                result = expr_20;
            }
            return result;
        }

        public static void SetHorizontalOffset(DependencyObject element, double value)
        {
            bool arg_07_0 = element == null;
            bool expr_07;
            do
            {
                expr_07 = (arg_07_0 = !arg_07_0);
            }
            while (7 == 0);
            bool flag = expr_07;
            while (!false)
            {
                if (!flag)
                {
                    throw new ArgumentNullException("element");
                }
                if (!false && true)
                {
                    element.SetValue(PopupKeyboard.HorizontalOffsetProperty, value);
                    break;
                }
            }
        }

        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static double GetVerticalOffset(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            double expr_20 = (double)element.GetValue(PopupKeyboard.VerticalOffsetProperty);
            double result;
            if (!false)
            {
                result = expr_20;
            }
            return result;
        }

        public static void SetVerticalOffset(DependencyObject element, double value)
        {
            bool arg_07_0 = element == null;
            bool expr_07;
            do
            {
                expr_07 = (arg_07_0 = !arg_07_0);
            }
            while (7 == 0);
            bool flag = expr_07;
            while (!false)
            {
                if (!flag)
                {
                    throw new ArgumentNullException("element");
                }
                if (!false && true)
                {
                    element.SetValue(PopupKeyboard.VerticalOffsetProperty, value);
                    break;
                }
            }
        }

        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static CustomPopupPlacementCallback GetCustomPopupPlacementCallback(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            CustomPopupPlacementCallback expr_20 = (CustomPopupPlacementCallback)element.GetValue(PopupKeyboard.CustomPopupPlacementCallbackProperty);
            CustomPopupPlacementCallback result;
            if (!false)
            {
                result = expr_20;
            }
            return result;
        }

        public static void SetCustomPopupPlacementCallback(DependencyObject element, CustomPopupPlacementCallback value)
        {
            if (false)
            {
                goto IL_15;
            }
            bool arg_33_0;
            bool expr_07 = arg_33_0 = (element == null);
            if (!false)
            {
                arg_33_0 = !expr_07;
            }
            bool flag = arg_33_0;
        IL_11:
            if (flag)
            {
                goto IL_20;
            }
        IL_15:
            if (!false)
            {
                throw new ArgumentNullException("element");
            }
        IL_20:
            element.SetValue(PopupKeyboard.CustomPopupPlacementCallbackProperty, value);
            if (!false)
            {
                return;
            }
            goto IL_11;
        }

        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static KeyboardState GetState(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            KeyboardState expr_20 = (KeyboardState)element.GetValue(PopupKeyboard.StateProperty);
            KeyboardState result;
            if (!false)
            {
                result = expr_20;
            }
            return result;
        }

        public static void SetState(DependencyObject element, KeyboardState value)
        {
            bool arg_07_0 = element == null;
            bool expr_07;
            do
            {
                expr_07 = (arg_07_0 = !arg_07_0);
            }
            while (7 == 0);
            bool flag = expr_07;
            while (!false)
            {
                if (!flag)
                {
                    throw new ArgumentNullException("element");
                }
                if (!false && true)
                {
                    element.SetValue(PopupKeyboard.StateProperty, value);
                    break;
                }
            }
        }

        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static double GetHeight(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            double expr_20 = (double)element.GetValue(PopupKeyboard.HeightProperty);
            double result;
            if (!false)
            {
                result = expr_20;
            }
            return result;
        }

        public static void SetHeight(DependencyObject element, double value)
        {
            bool arg_07_0 = element == null;
            bool expr_07;
            do
            {
                expr_07 = (arg_07_0 = !arg_07_0);
            }
            while (7 == 0);
            bool flag = expr_07;
            while (!false)
            {
                if (!flag)
                {
                    throw new ArgumentNullException("element");
                }
                if (!false && true)
                {
                    element.SetValue(PopupKeyboard.HeightProperty, value);
                    break;
                }
            }
        }

        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static double GetWidth(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            double expr_20 = (double)element.GetValue(PopupKeyboard.WidthProperty);
            double result;
            if (!false)
            {
                result = expr_20;
            }
            return result;
        }

        public static void SetWidth(DependencyObject element, double value)
        {
            bool arg_07_0 = element == null;
            bool expr_07;
            do
            {
                expr_07 = (arg_07_0 = !arg_07_0);
            }
            while (7 == 0);
            bool flag = expr_07;
            while (!false)
            {
                if (!flag)
                {
                    throw new ArgumentNullException("element");
                }
                if (!false && true)
                {
                    element.SetValue(PopupKeyboard.WidthProperty, value);
                    break;
                }
            }
        }

        [AttachedPropertyBrowsableForType(typeof(FrameworkElement))]
        public static bool GetIsEnabled(DependencyObject element)
        {
            if (element == null)
            {
                throw new ArgumentNullException("element");
            }
            bool expr_20 = (bool)element.GetValue(PopupKeyboard.IsEnabledProperty);
            bool result;
            if (!false)
            {
                result = expr_20;
            }
            return result;
        }

        public static void SetIsEnabled(DependencyObject element, bool value)
        {
            bool arg_07_0 = element == null;
            bool expr_07;
            do
            {
                expr_07 = (arg_07_0 = !arg_07_0);
            }
            while (7 == 0);
            bool flag = expr_07;
            while (!false)
            {
                if (!flag)
                {
                    throw new ArgumentNullException("element");
                }
                if (!false && true)
                {
                    element.SetValue(PopupKeyboard.IsEnabledProperty, value);
                    break;
                }
            }
        }

        private static void OnPlacementChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = element as FrameworkElement;
            while (true)
            {
                if (frameworkElement == null)
                {
                    goto IL_1E;
                }
                bool arg_47_0 = PopupKeyboard._popupKeyboardUserControl == null;
                if (!false && !false)
                {
                }
            IL_20:
                bool flag = arg_47_0;
                if (false)
                {
                    break;
                }
                if (flag)
                {
                    break;
                }
                if (7 == 0)
                {
                    continue;
                }
                PopupKeyboard._popupKeyboardUserControl.Placement = PopupKeyboard.GetPlacement(frameworkElement);
                if (-1 != 0)
                {
                    break;
                }
                goto IL_1E;
            IL_1F:
                goto IL_20;
            IL_1E:
                arg_47_0 = true;
                goto IL_1F;
            }
        }

        private static void OnPlacementTargetChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = element as FrameworkElement;
            while (true)
            {
                if (frameworkElement == null)
                {
                    goto IL_1E;
                }
                bool arg_47_0 = PopupKeyboard._popupKeyboardUserControl == null;
                if (!false && !false)
                {
                }
            IL_20:
                bool flag = arg_47_0;
                if (false)
                {
                    break;
                }
                if (flag)
                {
                    break;
                }
                if (7 == 0)
                {
                    continue;
                }
                PopupKeyboard._popupKeyboardUserControl.PlacementTarget = PopupKeyboard.GetPlacementTarget(frameworkElement);
                if (-1 != 0)
                {
                    break;
                }
                goto IL_1E;
            IL_1F:
                goto IL_20;
            IL_1E:
                arg_47_0 = true;
                goto IL_1F;
            }
        }

        private static void OnPlacementRectangleChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = element as FrameworkElement;
            while (true)
            {
                if (frameworkElement == null)
                {
                    goto IL_1E;
                }
                bool arg_47_0 = PopupKeyboard._popupKeyboardUserControl == null;
                if (!false && !false)
                {
                }
            IL_20:
                bool flag = arg_47_0;
                if (false)
                {
                    break;
                }
                if (flag)
                {
                    break;
                }
                if (7 == 0)
                {
                    continue;
                }
                PopupKeyboard._popupKeyboardUserControl.PlacementRectangle = PopupKeyboard.GetPlacementRectangle(frameworkElement);
                if (-1 != 0)
                {
                    break;
                }
                goto IL_1E;
            IL_1F:
                goto IL_20;
            IL_1E:
                arg_47_0 = true;
                goto IL_1F;
            }
        }

        private static void OnHorizontalOffsetChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = element as FrameworkElement;
            while (true)
            {
                if (frameworkElement == null)
                {
                    goto IL_1E;
                }
                bool arg_47_0 = PopupKeyboard._popupKeyboardUserControl == null;
                if (!false && !false)
                {
                }
            IL_20:
                bool flag = arg_47_0;
                if (false)
                {
                    break;
                }
                if (flag)
                {
                    break;
                }
                if (7 == 0)
                {
                    continue;
                }
                PopupKeyboard._popupKeyboardUserControl.HorizontalOffset = PopupKeyboard.GetHorizontalOffset(frameworkElement);
                if (-1 != 0)
                {
                    break;
                }
                goto IL_1E;
            IL_1F:
                goto IL_20;
            IL_1E:
                arg_47_0 = true;
                goto IL_1F;
            }
        }

        private static void OnVerticalOffsetChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = element as FrameworkElement;
            while (true)
            {
                if (frameworkElement == null)
                {
                    goto IL_1E;
                }
                bool arg_47_0 = PopupKeyboard._popupKeyboardUserControl == null;
                if (!false && !false)
                {
                }
            IL_20:
                bool flag = arg_47_0;
                if (false)
                {
                    break;
                }
                if (flag)
                {
                    break;
                }
                if (7 == 0)
                {
                    continue;
                }
                PopupKeyboard._popupKeyboardUserControl.VerticalOffset = PopupKeyboard.GetVerticalOffset(frameworkElement);
                if (-1 != 0)
                {
                    break;
                }
                goto IL_1E;
            IL_1F:
                goto IL_20;
            IL_1E:
                arg_47_0 = true;
                goto IL_1F;
            }
        }

        private static void OnCustomPopupPlacementCallbackChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = element as FrameworkElement;
            while (true)
            {
                if (frameworkElement == null)
                {
                    goto IL_1E;
                }
                bool arg_47_0 = PopupKeyboard._popupKeyboardUserControl == null;
                if (!false && !false)
                {
                }
            IL_20:
                bool flag = arg_47_0;
                if (false)
                {
                    break;
                }
                if (flag)
                {
                    break;
                }
                if (7 == 0)
                {
                    continue;
                }
                PopupKeyboard._popupKeyboardUserControl.CustomPopupPlacementCallback = PopupKeyboard.GetCustomPopupPlacementCallback(frameworkElement);
                if (-1 != 0)
                {
                    break;
                }
                goto IL_1E;
            IL_1F:
                goto IL_20;
            IL_1E:
                arg_47_0 = true;
                goto IL_1F;
            }
        }

        private static void OnStateChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = element as FrameworkElement;
            while (true)
            {
                if (frameworkElement == null)
                {
                    goto IL_1E;
                }
                bool arg_47_0 = PopupKeyboard._popupKeyboardUserControl == null;
                if (!false && !false)
                {
                }
            IL_20:
                bool flag = arg_47_0;
                if (false)
                {
                    break;
                }
                if (flag)
                {
                    break;
                }
                if (7 == 0)
                {
                    continue;
                }
                PopupKeyboard._popupKeyboardUserControl.State = PopupKeyboard.GetState(frameworkElement);
                if (-1 != 0)
                {
                    break;
                }
                goto IL_1E;
            IL_1F:
                goto IL_20;
            IL_1E:
                arg_47_0 = true;
                goto IL_1F;
            }
        }

        private static void OnHeightChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = element as FrameworkElement;
            while (true)
            {
                if (frameworkElement == null)
                {
                    goto IL_1E;
                }
                bool arg_47_0 = PopupKeyboard._popupKeyboardUserControl == null;
                if (!false && !false)
                {
                }
            IL_20:
                bool flag = arg_47_0;
                if (false)
                {
                    break;
                }
                if (flag)
                {
                    break;
                }
                if (7 == 0)
                {
                    continue;
                }
                PopupKeyboard._popupKeyboardUserControl.NormalHeight = PopupKeyboard.GetHeight(frameworkElement);
                if (-1 != 0)
                {
                    break;
                }
                goto IL_1E;
            IL_1F:
                goto IL_20;
            IL_1E:
                arg_47_0 = true;
                goto IL_1F;
            }
        }

        private static object CoerceHeight(DependencyObject d, object value)
        {
            bool arg_3E_0;
            bool arg_16_0;
            bool arg_22_0 = arg_16_0 = (arg_3E_0 = ((double)value < PopupKeyboard.MinimumHeight));
            do
            {
                if (3 != 0)
                {
                    if (6 == 0)
                    {
                        goto IL_22;
                    }
                    arg_22_0 = (arg_16_0 = (arg_3E_0 = ((arg_16_0 ? 1 : 0) == 0)));
                }
            }
            while (7 == 0);
            if (!false)
            {
                bool flag = arg_3E_0;
                arg_22_0 = flag;
            }
        IL_22:
            object result;
            if (!arg_22_0)
            {
                result = PopupKeyboard.MinimumHeight;
            }
            else
            {
                result = value;
            }
            return result;
        }

        private static void OnWidthChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement frameworkElement = element as FrameworkElement;
            while (true)
            {
                if (frameworkElement == null)
                {
                    goto IL_1E;
                }
                bool arg_47_0 = PopupKeyboard._popupKeyboardUserControl == null;
                if (!false && !false)
                {
                }
            IL_20:
                bool flag = arg_47_0;
                if (false)
                {
                    break;
                }
                if (flag)
                {
                    break;
                }
                if (7 == 0)
                {
                    continue;
                }
                PopupKeyboard._popupKeyboardUserControl.NormalWidth = PopupKeyboard.GetWidth(frameworkElement);
                if (-1 != 0)
                {
                    break;
                }
                goto IL_1E;
            IL_1F:
                goto IL_20;
            IL_1E:
                arg_47_0 = true;
                goto IL_1F;
            }
        }

        private static object CoerceWidth(DependencyObject d, object value)
        {
            bool arg_3E_0;
            bool arg_16_0;
            bool arg_22_0 = arg_16_0 = (arg_3E_0 = ((double)value < PopupKeyboard.MinimumWidth));
            do
            {
                if (3 != 0)
                {
                    if (6 == 0)
                    {
                        goto IL_22;
                    }
                    arg_22_0 = (arg_16_0 = (arg_3E_0 = ((arg_16_0 ? 1 : 0) == 0)));
                }
            }
            while (7 == 0);
            if (!false)
            {
                bool flag = arg_3E_0;
                arg_22_0 = flag;
            }
        IL_22:
            object result;
            if (!arg_22_0)
            {
                result = PopupKeyboard.MinimumWidth;
            }
            else
            {
                result = value;
            }
            return result;
        }

        private static void OnIsEnabledChanged(DependencyObject element, DependencyPropertyChangedEventArgs e)
        {
            bool flag;
            Window window;
            if (8 != 0)
            {
                FrameworkElement frameworkElement = element as FrameworkElement;
                bool arg_202_0 = frameworkElement == null;
                while (true)
                {
                    flag = arg_202_0;
                    if (!flag)
                    {
                        if (8 == 0)
                        {
                            goto IL_CA;
                        }
                        bool arg_222_0;
                        if ((bool)e.NewValue)
                        {
                            arg_222_0 = (bool)e.OldValue;
                            goto IL_51;
                        }
                        goto IL_50;
                    IL_FA:
                        if (false)
                        {
                            continue;
                        }
                        int arg_101_0;
                        flag = (arg_101_0 != 0);
                        if (flag)
                        {
                            break;
                        }
                        frameworkElement.RemoveHandler(UIElement.GotKeyboardFocusEvent, new KeyboardFocusChangedEventHandler(PopupKeyboard.frameworkElement_GotKeyboardFocus));
                        frameworkElement.RemoveHandler(UIElement.LostKeyboardFocusEvent, new KeyboardFocusChangedEventHandler(PopupKeyboard.frameworkElement_LostKeyboardFocus));
                        frameworkElement.RemoveHandler(UIElement.MouseUpEvent, new MouseButtonEventHandler(PopupKeyboard.frameworkElement_MouseDown));
                        if (5 != 0)
                        {
                            goto Block_11;
                        }
                    IL_E8:
                        arg_202_0 = ((arg_101_0 = ((!(bool)e.OldValue) ? 1 : 0)) != 0);
                        goto IL_FA;
                    IL_CA:
                        if (false)
                        {
                            goto IL_50;
                        }
                        if (!false)
                        {
                            break;
                        }
                        goto IL_E8;
                    IL_51:
                        if (!false)
                        {
                            flag = arg_222_0;
                        }
                        if (!flag)
                        {
                            frameworkElement.AddHandler(UIElement.GotKeyboardFocusEvent, new KeyboardFocusChangedEventHandler(PopupKeyboard.frameworkElement_GotKeyboardFocus), true);
                            if (!false)
                            {
                                frameworkElement.AddHandler(UIElement.LostKeyboardFocusEvent, new KeyboardFocusChangedEventHandler(PopupKeyboard.frameworkElement_LostKeyboardFocus), true);
                                frameworkElement.AddHandler(UIElement.MouseDownEvent, new MouseButtonEventHandler(PopupKeyboard.frameworkElement_MouseDown), true);
                                frameworkElement.AddHandler(FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(PopupKeyboard.frameworkElement_SizeChanged), true);
                                goto IL_CA;
                            }
                            return;
                        }
                        else
                        {
                            if (!(bool)e.NewValue)
                            {
                                goto IL_E8;
                            }
                            arg_202_0 = ((arg_101_0 = 1) != 0);
                            goto IL_FA;
                        }
                    IL_50:
                        arg_222_0 = true;
                        goto IL_51;
                    }
                    break;
                }
                goto IL_16A;
            Block_11:
                frameworkElement.RemoveHandler(FrameworkElement.SizeChangedEvent, new SizeChangedEventHandler(PopupKeyboard.frameworkElement_SizeChanged));
            IL_16A:
                window = Window.GetWindow(element);
                flag = (window == null);
            }
            if (!flag)
            {
                flag = (!(bool)e.NewValue || (bool)e.OldValue);
                if (!flag)
                {
                    window.LocationChanged += new EventHandler(PopupKeyboard.currentWindow_LocationChanged);
                }
                else
                {
                    flag = ((bool)e.NewValue || !(bool)e.OldValue);
                    if (!flag)
                    {
                        window.LocationChanged -= new EventHandler(PopupKeyboard.currentWindow_LocationChanged);
                    }
                }
            }
        }

        private static void frameworkElement_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            FrameworkElement frameworkElement = sender as FrameworkElement;
            bool arg_139_0 = frameworkElement == null;
            while (!arg_139_0)
            {
                bool arg_10C_0;
                int arg_10C_1;
                while (true)
                {
                    int expr_2E = (arg_10C_0 = (PopupKeyboard._popupKeyboardUserControl == null)) ? 1 : 0;
                    int expr_31 = arg_10C_1 = 0;
                    if (expr_31 != 0)
                    {
                        break;
                    }
                    if (expr_2E == expr_31)
                    {
                        goto IL_125;
                    }
                    PopupKeyboard._popupKeyboardUserControl = new PopupKeyboardUserControl();
                    PopupKeyboard._popupKeyboardUserControl.Placement = PopupKeyboard.GetPlacement(frameworkElement);
                    PopupKeyboard._popupKeyboardUserControl.PlacementTarget = PopupKeyboard.GetPlacementTarget(frameworkElement);
                    PopupKeyboard._popupKeyboardUserControl.PlacementRectangle = PopupKeyboard.GetPlacementRectangle(frameworkElement);
                    PopupKeyboard._popupKeyboardUserControl.HorizontalOffset = PopupKeyboard.GetHorizontalOffset(frameworkElement);
                    PopupKeyboard._popupKeyboardUserControl.VerticalOffset = PopupKeyboard.GetVerticalOffset(frameworkElement);
                    PopupKeyboard._popupKeyboardUserControl.StaysOpen = true;
                    if (!false)
                    {
                        goto Block_3;
                    }
                }
            IL_10C:
                bool expr_10C = arg_139_0 = ((arg_10C_0 ? 1 : 0) == arg_10C_1);
                if (3 != 0)
                {
                    if (!expr_10C)
                    {
                        PopupKeyboard._popupKeyboardUserControl.IsOpen = true;
                    }
                    break;
                }
                continue;
            Block_3:
                PopupKeyboard._popupKeyboardUserControl.CustomPopupPlacementCallback = PopupKeyboard.GetCustomPopupPlacementCallback(frameworkElement);
                PopupKeyboard._popupKeyboardUserControl.State = PopupKeyboard.GetState(frameworkElement);
                PopupKeyboard._popupKeyboardUserControl.NormalHeight = PopupKeyboard.GetHeight(frameworkElement);
                PopupKeyboard._popupKeyboardUserControl.NormalWidth = PopupKeyboard.GetWidth(frameworkElement);
                arg_10C_0 = (PopupKeyboard.GetState(frameworkElement) == KeyboardState.Normal);
                arg_10C_1 = 0;
                goto IL_10C;
            IL_125:
                break;
            }
        }

        private static void frameworkElement_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (4 == 0)
            {
                goto IL_19;
            }
        IL_04:
            FrameworkElement frameworkElement = sender as FrameworkElement;
            bool arg_64_0 = frameworkElement == null;
        IL_12:
            if (arg_64_0)
            {
                return;
            }
        IL_19:
            bool expr_1F = arg_64_0 = (PopupKeyboard._popupKeyboardUserControl == null);
            if (false)
            {
                goto IL_12;
            }
            bool flag = expr_1F;
            do
            {
                bool expr_6D = arg_64_0 = flag;
                if (false)
                {
                    goto IL_12;
                }
                if (expr_6D)
                {
                    goto IL_56;
                }
                PopupKeyboard.SetState(frameworkElement, PopupKeyboard._popupKeyboardUserControl.State);
                if (3 == 0)
                {
                    goto IL_04;
                }
                PopupKeyboard._popupKeyboardUserControl.IsOpen = false;
            }
            while (!true);
            PopupKeyboard._popupKeyboardUserControl = null;
        IL_56: ;
        }

        private static void frameworkElement_MouseDown(object sender, MouseButtonEventArgs e)
        {
            while (true)
            {
                FrameworkElement expr_06 = sender as FrameworkElement;
                FrameworkElement frameworkElement;
                if (!false)
                {
                    frameworkElement = expr_06;
                }
                bool arg_90_0 = frameworkElement == null;
                while (true)
                {
                    bool flag = arg_90_0;
                    if (6 != 0)
                    {
                        if (flag)
                        {
                            return;
                        }
                        if (PopupKeyboard._popupKeyboardUserControl == null)
                        {
                            goto IL_73;
                        }
                    }
                IL_3F:
                    flag = (e.ClickCount != 2);
                    bool expr_4A = arg_90_0 = flag;
                    if (!false)
                    {
                        if (!expr_4A)
                        {
                            PopupKeyboard._popupKeyboardUserControl.State = ((PopupKeyboard._popupKeyboardUserControl.State == KeyboardState.Hidden) ? KeyboardState.Normal : KeyboardState.Hidden);
                            if (7 == 0)
                            {
                                return;
                            }
                        }
                        goto IL_73;
                    }
                    continue;
                    goto IL_3F;
                IL_73:
                    if (false)
                    {
                        break;
                    }
                    if (!false)
                    {
                        return;
                    }
                    goto IL_3F;
                }
            }
        }

        private static void frameworkElement_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            bool arg_6B_0;
            int arg_31_0;
            while (true)
            {
                FrameworkElement frameworkElement = sender as FrameworkElement;
                if (4 == 0)
                {
                    break;
                }
                bool expr_10 = (arg_31_0 = ((arg_6B_0 = (frameworkElement == null)) ? 1 : 0)) != 0;
                if (-1 == 0)
                {
                    goto IL_33;
                }
                if (expr_10)
                {
                    return;
                }
                if (6 == 0)
                {
                    return;
                }
                if (PopupKeyboard._popupKeyboardUserControl != null)
                {
                    break;
                }
                if (!false)
                {
                    goto Block_4;
                }
            }
            arg_31_0 = ((PopupKeyboard._popupKeyboardUserControl.State == KeyboardState.Normal) ? 1 : 0);
        IL_30:
            arg_6B_0 = ((arg_31_0 = ((arg_31_0 == 0) ? 1 : 0)) != 0);
        IL_33:
            goto IL_39;
        Block_4:
            arg_6B_0 = ((arg_31_0 = 1) != 0);
        IL_39:
            if (false)
            {
                goto IL_30;
            }
            if (!arg_6B_0)
            {
                PopupKeyboard._popupKeyboardUserControl.LocationChange();
            }
        }

        private static void currentWindow_LocationChanged(object sender, EventArgs e)
        {
            bool arg_6B_0;
            int arg_31_0;
            while (true)
            {
                FrameworkElement frameworkElement = sender as FrameworkElement;
                if (4 == 0)
                {
                    break;
                }
                bool expr_10 = (arg_31_0 = ((arg_6B_0 = (frameworkElement == null)) ? 1 : 0)) != 0;
                if (-1 == 0)
                {
                    goto IL_33;
                }
                if (expr_10)
                {
                    return;
                }
                if (6 == 0)
                {
                    return;
                }
                if (PopupKeyboard._popupKeyboardUserControl != null)
                {
                    break;
                }
                if (!false)
                {
                    goto Block_4;
                }
            }
            arg_31_0 = ((PopupKeyboard._popupKeyboardUserControl.State == KeyboardState.Normal) ? 1 : 0);
        IL_30:
            arg_6B_0 = ((arg_31_0 = ((arg_31_0 == 0) ? 1 : 0)) != 0);
        IL_33:
            goto IL_39;
        Block_4:
            arg_6B_0 = ((arg_31_0 = 1) != 0);
        IL_39:
            if (false)
            {
                goto IL_30;
            }
            if (!arg_6B_0)
            {
                PopupKeyboard._popupKeyboardUserControl.LocationChange();
            }
        }
    }
}
