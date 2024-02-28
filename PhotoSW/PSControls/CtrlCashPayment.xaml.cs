using PhotoSW.IMIX.Business;
using System;
using System.CodeDom.Compiler;
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
    public partial class CtrlCashPayment : UserControl, IComponentConnector
    {
        private UIElement _parent;

        private bool _hideRequest = false;

        private string _result;

        public static readonly DependencyProperty MessageCashPaymentProperty = DependencyProperty.Register("MessageCashPayment", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));

      

        public string MessageCashPayment
        {
            get
            {
                return (string)base.GetValue(CtrlCashPayment.MessageCashPaymentProperty);
            }
            set
            {
                base.SetValue(CtrlCashPayment.MessageCashPaymentProperty, value);
            }
        }

        public CtrlCashPayment()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public string ShowHandlerDialog(string message)
        {
            this.TxtAmount.Text = string.Empty;
            if (3 == 0)
            {
                goto IL_68;
            }
            this.MessageCashPayment = message;
            if (!false)
            {
                base.Visibility = Visibility.Visible;
            }
            this.LoadCurrency();
        IL_43:
            this.TxtAmount.CaretIndex = 0;
        IL_50:
            this.TxtAmount.Focus();
            this._parent.IsEnabled = true;
        IL_68:
            this._hideRequest = false;
            this.TxtAmount.Text = string.Empty;
            string result;
            while (!this._hideRequest)
            {
                if (7 == 0)
                {
                    goto IL_50;
                }
                bool arg_AC_0;
                if (!base.Dispatcher.HasShutdownStarted)
                {
                    arg_AC_0 = !base.Dispatcher.HasShutdownFinished;
                }
                else
                {
                    if (4 == 0)
                    {
                        return result;
                    }
                    arg_AC_0 = false;
                }
                if (!arg_AC_0)
                {
                    if (!false)
                    {
                        break;
                    }
                    goto IL_43;
                }
                else
                {
                    base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                    {
                    }));
                    Thread.Sleep(20);
                }
            }
            result = this._result;
            return result;
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

        private void rdoSelect_Click(object sender, RoutedEventArgs e)
        {
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            int num = 0;
            childItem result;
            while (true)
            {
                int arg_83_0 = num;
                int arg_83_1 = VisualTreeHelper.GetChildrenCount(obj);
                int expr_75;
                int expr_77;
                while (true)
                {
                IL_83:
                    bool flag = arg_83_0 < arg_83_1;
                    bool arg_89_0 = flag;
                    while (true)
                    {
                    IL_89:
                        if (!arg_89_0)
                        {
                            result = default(childItem);
                            goto IL_9B;
                        }
                        goto IL_0D;
                    IL_23:
                        DependencyObject dependencyObject;
                        int arg_34_0;
                        arg_83_0 = (arg_34_0 = ((dependencyObject is childItem) ? 1 : 0));
                        int arg_31_0 = 0;
                        while (true)
                        {
                            int expr_31 = arg_83_1 = arg_31_0;
                            if (expr_31 != 0)
                            {
                                goto IL_83;
                            }
                            if (arg_34_0 != expr_31)
                            {
                                break;
                            }
                            childItem childItem1 = CtrlCashPayment.FindVisualChild<childItem>(dependencyObject);
                            bool expr_5E = arg_89_0 = (childItem1 == null);
                            if (4 == 0)
                            {
                                goto IL_89;
                            }
                            if (!expr_5E)
                            {
                                goto Block_4;
                            }
                            expr_75 = (arg_34_0 = (arg_83_0 = num));
                            expr_77 = (arg_31_0 = 1);
                            if (expr_77 != 0)
                            {
                                goto Block_7;
                            }
                        }
                        result = (childItem)((object)dependencyObject);
                        goto IL_9B;
                    Block_4:
                        if (!false && -1 != 0)
                        {
                            childItem childItem1=CtrlCashPayment.FindVisualChild<childItem>(dependencyObject);;
                            result = childItem1;
                            goto IL_9B;
                        }
                    IL_0D:
                        DependencyObject expr_B5 = VisualTreeHelper.GetChild(obj, num);
                        if (7 == 0)
                        {
                            goto IL_23;
                        }
                        dependencyObject = expr_B5;
                        goto IL_23;
                    IL_9B:
                        if (4 != 0)
                        {
                            return result;
                        }
                        goto IL_23;
                    }
                }
            Block_7:
                num = expr_75 + expr_77;
            }
            return result;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string text = string.Empty;
            int num = 0;
            while (true)
            {
                int arg_DF_0;
                int expr_8D = arg_DF_0 = num;
                int arg_DF_1;
                int expr_99 = arg_DF_1 = this.lstCurrency.Items.Count;
                bool flag;
                if (-1 != 0)
                {
                    flag = (expr_8D < expr_99);
                    goto IL_A5;
                }
                goto IL_DF;
            IL_3F:
                if (flag)
                {
                    goto IL_88;
                }
                DependencyObject dependencyObject;
                RadioButton radioButton = CtrlCashPayment.FindVisualChild<RadioButton>(dependencyObject);
                int arg_8C_0;
                bool expr_4D = (arg_8C_0 = ((radioButton == null) ? 1 : 0)) != 0;
                if (!false)
                {
                    if (!expr_4D)
                    {
                        flag = !Convert.ToBoolean(radioButton.IsChecked);
                        if (!flag)
                        {
                            if (false)
                            {
                                goto IL_A5;
                            }
                            text = radioButton.Tag.ToString();
                        }
                    }
                    if (!false)
                    {
                        goto IL_88;
                    }
                    goto IL_89;
                }
            IL_8C:
                num = arg_8C_0;
                continue;
            IL_89:
                arg_8C_0 = num + 1;
                goto IL_8C;
            IL_88:
                goto IL_89;
            IL_A5:
                if (flag)
                {
                    dependencyObject = this.lstCurrency.ItemContainerGenerator.ContainerFromIndex(num);
                    flag = (dependencyObject == null);
                    goto IL_3F;
                }
                double num2 = 0.0;
                if (!(text != string.Empty))
                {
                    break;
                }
                arg_DF_0 = (double.TryParse(this.TxtAmount.Text, out num2) ? 1 : 0);
                arg_DF_1 = 0;
            IL_DF:
                flag = (arg_DF_0 == arg_DF_1);
                if (!flag)
                {
                    goto IL_E8;
                }
            IL_108:
                if (!false)
                {
                    if (2 != 0)
                    {
                        break;
                    }
                    goto IL_3F;
                }
            IL_E8:
                this._result = text + "%#%" + num2.ToString();
                this.HideHandlerDialog();
                goto IL_108;
            }
        }

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.TxtAmount.Focus();
                    if (false)
                    {
                        break;
                    }
                    this.TxtAmount.Text = string.Empty;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
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
                    bool expr_4D = arg_27_0 = CtrlCashPayment.IsTextAllowed(text);
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
                //goto IL_56;
            }
        IL_5A:
            if (!arg_5A_0)
            {
                e.CancelCommand();
            }
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
            e.Handled = !CtrlCashPayment.IsTextAllowed(e.Text);
        }

        private void LoadCurrency()
        {
            this.lstCurrency.ItemsSource = new CurrencyBusiness().GetCurrencyOnly();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = null;
            this.HideHandlerDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                while (true)
                {
                    this.TxtAmount.Focusable = true;
                    this.TxtAmount.Focus();
                    if (-1 != 0)
                    {
                        FocusManager.SetFocusedElement(this, this.TxtAmount);
                        Keyboard.Focus(this.TxtAmount);
                        while (!false)
                        {
                            this.TxtAmount.Text = string.Empty;
                            if (!false)
                            {
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void TxtAmount_GotKeyboardFocus(object sender, RoutedEventArgs e)
        {
        }


    }
}
