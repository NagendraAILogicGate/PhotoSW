using PhotoSW.IMIX.Business;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;

namespace PhotoSW.PSControls
{
    public partial class CashPayment : UserControl, IComponentConnector
    {
        private bool _hideRequest = false;

        private string _result;

        private UIElement _parent;

        public static readonly DependencyProperty Message2Property = DependencyProperty.Register("Message2", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));

        public string Message2
        {
            get
            {
                return (string)base.GetValue(CashPayment.Message2Property);
            }
            set
            {
                base.SetValue(CashPayment.Message2Property, value);
            }
        }

        public CashPayment()
        {
            this.InitializeComponent();
        }

        private static bool IsTextAllowed(string text)
        {
            bool arg_29_0;
            bool flag;
            while (true)
            {
                while (!false)
                {
                    Regex expr_2A = new Regex("[^0-9.-]+");
                    Regex regex;
                    if (4 != 0)
                    {
                        regex = expr_2A;
                    }
                    while (true)
                    {
                        bool expr_16 = arg_29_0 = !regex.IsMatch(text);
                        if (-1 == 0)
                        {
                            return arg_29_0;
                        }
                        if (5 != 0)
                        {
                            flag = expr_16;
                        }
                        if (false)
                        {
                            break;
                        }
                        if (2 != 0)
                        {
                            goto Block_3;
                        }
                    }
                }
            }
        Block_3:
            arg_29_0 = flag;
            return arg_29_0;
        }

        private void txtAmountEntered_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CashPayment.IsTextAllowed(e.Text);
        }

        private FrameworkElement FindByName(string name, FrameworkElement root)
        {
            Stack<FrameworkElement> stack;
            if (!false)
            {
                stack = new Stack<FrameworkElement>();
                stack.Push(root);
                goto IL_A3;
            }
        IL_24:
            FrameworkElement frameworkElement = stack.Pop();
            FrameworkElement result;
            if (-1 != 0 && frameworkElement.Name == name)
            {
                result = frameworkElement;
                return result;
            }
            int arg_5A_0 = VisualTreeHelper.GetChildrenCount(frameworkElement);
        IL_5A:
            int num = arg_5A_0;
            int num2 = 0;
            while (true)
            {
                bool flag = num2 < num;
                bool arg_79_0;
                bool expr_9B = arg_79_0 = flag;
                if (false)
                {
                    goto IL_79;
                }
                if (!expr_9B)
                {
                    break;
                }
                goto IL_5F;
            IL_93:
                int arg_93_0;
                int arg_93_1;
                num2 = arg_93_0 + arg_93_1;
                continue;
            IL_5F:
                DependencyObject child = VisualTreeHelper.GetChild(frameworkElement, num2);
                int expr_71 = arg_93_0 = ((child is FrameworkElement) ? 1 : 0);
                int expr_74 = arg_93_1 = 0;
                if (expr_74 != 0)
                {
                    goto IL_93;
                }
                arg_79_0 = (expr_71 == expr_74);
            IL_79:
                flag = arg_79_0;
                if (2 != 0)
                {
                    if (!flag)
                    {
                        stack.Push((FrameworkElement)child);
                    }
                    arg_93_0 = num2;
                    arg_93_1 = 1;
                    goto IL_93;
                }
                goto IL_5F;
            }
        IL_A3:
            int expr_A4 = arg_5A_0 = stack.Count;
            if (!true)
            {
                goto IL_5A;
            }
            if (expr_A4 > 0)
            {
                goto IL_24;
            }
            result = null;
            return result;
        }

        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            bool arg_5A_0;
            bool expr_8B = arg_5A_0 = e.DataObject.GetDataPresent(typeof(string));
            if (5 != 0)
            {
                bool flag = !expr_8B;
                bool arg_27_0 = flag;
                while (!arg_27_0)
                {
                    string text;
                    do
                    {
                        text = (string)e.DataObject.GetData(typeof(string));
                    }
                    while (false);
                    bool expr_4D = arg_27_0 = CashPayment.IsTextAllowed(text);
                    if (!false)
                    {
                        flag = expr_4D;
                    IL_56:
                        if (!false)
                        {
                            arg_5A_0 = flag;
                            goto IL_5A;
                        }
                        return;
                    }
                }
                e.CancelCommand();
                if (5 != 0)
                {
                    return;
                }
               // goto IL_56;
            }
        IL_5A:
            if (!arg_5A_0)
            {
                e.CancelCommand();
            }
        }

        private void txtAmountEntered_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        private void HideHandlerDialog()
        {
            if (4 != 0)
            {
                this._hideRequest = true;
                do
                {
                    Visibility expr_0E = Visibility.Collapsed;
                    if (!false)
                    {
                        base.Visibility = expr_0E;
                    }
                    if (false)
                    {
                        goto IL_25;
                    }
                }
                while (false);
                this._parent.IsEnabled = true;
            IL_25: ;
            }
        }

        private void LoadCurrency()
        {
            this.lstCurrency.ItemsSource = new CurrencyBusiness().GetCurrencyList();
        }

        public string ShowHandlerDialog(string message)
        {
            while (true)
            {
                this.Message2 = message;
                if (true)
                {
                    if (!false)
                    {
                        base.Visibility = Visibility.Visible;
                        this.LoadCurrency();
                        this._parent.IsEnabled = true;
                        this._hideRequest = false;
                    }
                    goto IL_AD;
                }
                goto IL_66;
            IL_67:
                bool arg_68_0;
                int arg_54_0;
                if (!arg_68_0)
                {
                    if (6 != 0)
                    {
                        break;
                    }
                    continue;
                }
                else
                {
                    base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                    }));
                    int expr_A3 = arg_54_0 = 20;
                    if (expr_A3 != 0)
                    {
                        Thread.Sleep(expr_A3);
                        goto IL_AD;
                    }
                    goto IL_54;
                }
            IL_62:
                bool arg_62_0;
                int arg_62_1;
                arg_68_0 = ((arg_62_0 ? 1 : 0) == arg_62_1);
                goto IL_67;
            IL_54:
                if (arg_54_0 == 0)
                {
                    arg_62_0 = base.Dispatcher.HasShutdownFinished;
                    arg_62_1 = 0;
                    goto IL_62;
                }
            IL_66:
                arg_68_0 = false;
                goto IL_67;
            IL_AD:
                bool expr_AE = arg_62_0 = this._hideRequest;
                int expr_B4 = arg_62_1 = 0;
                if (expr_B4 != 0)
                {
                    goto IL_62;
                }
                arg_62_1 = expr_B4;
                if (expr_B4 != 0)
                {
                    goto IL_62;
                }
                if ((expr_AE ? 1 : 0) != expr_B4)
                {
                    break;
                }
                arg_54_0 = (base.Dispatcher.HasShutdownStarted ? 1 : 0);
                goto IL_54;
            }
            return this._result;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.HideHandlerDialog();
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            this.HideHandlerDialog();
        }


    }
}
