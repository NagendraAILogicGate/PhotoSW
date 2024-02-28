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
//using WPFToolkit;
namespace PhotoSW.PSControls
{
    public partial class CtrlOpeningForm : UserControl, IComponentConnector
    {
        private UIElement _parent;

        private bool _hideRequest = false;

        private string _result;

        private TextBox controlon;

        public static readonly DependencyProperty MessageOpeningFormProperty =
            DependencyProperty.Register("MessageOpeningForm", typeof(string), typeof(ModalDialog),
            new UIPropertyMetadata(string.Empty));

      // private bool _contentLoaded;

        public DateTime FromDate
        {
            get;
            set;
        }

        public bool IsPermission
        {
            get;
            set;
        }

        public long printAutoStart6850
        {
            get;
            set;
        }

        public long printAutoStart8810
        {
            get;
            set;
        }

        public string MessageOpeningForm
        {
            get
            {
                return (string)base.GetValue(CtrlOpeningForm.MessageOpeningFormProperty);
            }
            set
            {
                base.SetValue(CtrlOpeningForm.MessageOpeningFormProperty, value);
            }
        }

        public CtrlOpeningForm()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
            //this.MonthlyCalendar.DisplayDateStart = new DateTime?(DateTime.Now);
            //this.MonthlyCalendar.DisplayDateEnd = new DateTime?(DateTime.Now.AddDays(1.0));
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public string ShowHandlerDialog(string message)
        {
            while (8 == 0)
            {
            }
            this.MessageOpeningForm = message;
            base.Visibility = Visibility.Visible;
            if (7 != 0)
            {
                this.txt6X8StarNumber.Focus();
                this.txt6X8AutoStarNumber.Text = this.printAutoStart6850.ToString();
                if (!false && -1 != 0)
                {
                    this.txt8X10AutoStarNumber.Text = this.printAutoStart8810.ToString();
                    this._hideRequest = false;
                    goto IL_DA;
                }
                goto IL_A5;
            }
        IL_7F:
            int arg_9E_0;
            if (base.Dispatcher.HasShutdownStarted)
            {
                arg_9E_0 = 0;
                goto IL_9D;
            }
            bool arg_98_0 = base.Dispatcher.HasShutdownFinished;
            int arg_98_1 = 0;
        IL_98:
            arg_9E_0 = (((arg_98_0 ? 1 : 0) == arg_98_1) ? 1 : 0);
        IL_9D:
            if (arg_9E_0 == 0)
            {
                goto IL_F0;
            }
        IL_A5:
            base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
            }));
            Thread.Sleep(20);
        IL_DA:
            int expr_DB = (arg_98_0 = this._hideRequest) ? 1 : 0;
            int expr_E1 = arg_98_1 = 0;
            if (expr_E1 != 0)
            {
                goto IL_98;
            }
            bool flag = expr_DB == expr_E1;
            bool expr_E7 = (arg_9E_0 = (flag ? 1 : 0)) != 0;
            if (!true)
            {
                goto IL_9D;
            }
            if (expr_E7)
            {
                goto IL_7F;
            }
        IL_F0:
            return this._result;
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
                    bool expr_4D = arg_27_0 = CtrlOpeningForm.IsTextAllowed(text);
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
                    Regex expr_2A = new Regex("[^0-9]+");
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
            e.Handled = !CtrlOpeningForm.IsTextAllowed(e.Text);
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            if (8 == 0)
            {
                goto IL_148;
            }
            this._result = string.Empty;
            bool expr_30 = !(this.txt6X8StarNumber.Text == string.Empty);
            bool flag;
            if (5 != 0)
            {
                flag = expr_30;
            }
            if (!flag)
            {
                MessageBox.Show("Please enter 6X8 printer starting number", "Spectra Photo");
                this.txt6X8StarNumber.Focus();
                this.txt6X8StarNumber.BorderBrush = Brushes.Red;
                return;
            }
            int arg_8E_0 = (this.txt8X10StarNumber.Text == string.Empty) ? 1 : 0;
        IL_8D:
            flag = (arg_8E_0 == 0);
            if (!flag)
            {
                MessageBox.Show("Please enter 8X10 printer starting number", "Spectra Photo");
                this.txt8X10StarNumber.Focus();
                this.txt8X10StarNumber.BorderBrush = Brushes.Red;
            }
            else
            {
                flag = !(this.txtPosterStarNumber.Text == string.Empty);
                if (!false)
                {
                    if (flag)
                    {
                        flag = !(this.txtCashFloat.Text == string.Empty);
                        if (flag)
                        {
                            this._result = string.Concat(new string[]
							{
								this.txt6X8StarNumber.Text.ToString(),
								"%##%",
								this.txt8X10StarNumber.Text,
								"%##%",
								this.txtPosterStarNumber.Text,
								"%##%",
								this.txtCashFloat.Text,
								"%##%",
								//this.MonthlyCalendar.SelectedDate.ToString()
							});
                            if (!false)
                            {
                                this.HideHandlerDialog();
                                return;
                            }
                        }
                        MessageBox.Show("Please enter cash float amount", "Spectra Photo");
                        goto IL_148;
                    }
                    MessageBox.Show("Please enter poster printer starting number", "Spectra Photo");
                    this.txtPosterStarNumber.Focus();
                    this.txtPosterStarNumber.BorderBrush = Brushes.Red;
                }
            }
            return;
        IL_148:
            arg_8E_0 = (this.txtCashFloat.Focus() ? 1 : 0);
            if (2 == 0)
            {
                goto IL_8D;
            }
            this.txtCashFloat.BorderBrush = Brushes.Red;
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

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                while (true)
                {
                    this.txt6X8StarNumber.Text = string.Empty;
                    while (!false)
                    {
                        this.txt8X10StarNumber.Text = string.Empty;
                        this.txtCashFloat.Text = string.Empty;
                        if (!false)
                        {
                            this.txtPosterStarNumber.Text = string.Empty;
                        IL_42:
                            break;
                        }
                    }
                    this._result = string.Empty;
                    if (!false)
                    {
                        if (false)
                        {
                            //goto IL_42;
                        }
                        if (true)
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = string.Empty;
            this.HideHandlerDialog();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtCashFloat.Focus();
        }

        private void txtCashFloat_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
        }

        private void txt6X8StarNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
        }

        private void txt8X10StarNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
        }

        private void txtPosterStarNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            this.controlon = (TextBox)sender;
        }

        private void txt6X8StarNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (4 == 0)
            {
                goto IL_20;
            }
            bool arg_0D_0 = e.Key == Key.Space;
            int arg_0D_1 = 0;
        IL_0D:
            bool arg_35_0;
            bool expr_0D = arg_0D_0 = (arg_35_0 = ((arg_0D_0 ? 1 : 0) == arg_0D_1));
            if (-1 == 0)
            {
                goto IL_31;
            }
            bool flag = expr_0D;
        IL_14:
            if (flag)
            {
                arg_35_0 = (arg_0D_0 = (e.Key == Key.Decimal));
                goto IL_31;
            }
            bool expr_1A = true;
            if (!false)
            {
                e.Handled = expr_1A;
            }
        IL_20:
            if (false)
            {
                goto IL_14;
            }
            if (!false)
            {
                return;
            }
            goto IL_39;
        IL_31:
            int expr_32 = arg_0D_1 = 0;
            if (expr_32 != 0)
            {
                goto IL_0D;
            }
            flag = ((arg_35_0 ? 1 : 0) == expr_32);
        IL_39:
            if (!flag)
            {
                e.Handled = !CtrlOpeningForm.IsTextAllowed(".");
            }
        }

        private void txt8X10StarNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (4 == 0)
            {
                goto IL_20;
            }
            bool arg_0D_0 = e.Key == Key.Space;
            int arg_0D_1 = 0;
        IL_0D:
            bool arg_35_0;
            bool expr_0D = arg_0D_0 = (arg_35_0 = ((arg_0D_0 ? 1 : 0) == arg_0D_1));
            if (-1 == 0)
            {
                goto IL_31;
            }
            bool flag = expr_0D;
        IL_14:
            if (flag)
            {
                arg_35_0 = (arg_0D_0 = (e.Key == Key.Decimal));
                goto IL_31;
            }
            bool expr_1A = true;
            if (!false)
            {
                e.Handled = expr_1A;
            }
        IL_20:
            if (false)
            {
                goto IL_14;
            }
            if (!false)
            {
                return;
            }
            goto IL_39;
        IL_31:
            int expr_32 = arg_0D_1 = 0;
            if (expr_32 != 0)
            {
                goto IL_0D;
            }
            flag = ((arg_35_0 ? 1 : 0) == expr_32);
        IL_39:
            if (!flag)
            {
                e.Handled = !CtrlOpeningForm.IsTextAllowed(".");
            }
        }

        private void txtPosterStarNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (4 == 0)
            {
                goto IL_20;
            }
            bool arg_0D_0 = e.Key == Key.Space;
            int arg_0D_1 = 0;
        IL_0D:
            bool arg_35_0;
            bool expr_0D = arg_0D_0 = (arg_35_0 = ((arg_0D_0 ? 1 : 0) == arg_0D_1));
            if (-1 == 0)
            {
                goto IL_31;
            }
            bool flag = expr_0D;
        IL_14:
            if (flag)
            {
                arg_35_0 = (arg_0D_0 = (e.Key == Key.Decimal));
                goto IL_31;
            }
            bool expr_1A = true;
            if (!false)
            {
                e.Handled = expr_1A;
            }
        IL_20:
            if (false)
            {
                goto IL_14;
            }
            if (!false)
            {
                return;
            }
            goto IL_39;
        IL_31:
            int expr_32 = arg_0D_1 = 0;
            if (expr_32 != 0)
            {
                goto IL_0D;
            }
            flag = ((arg_35_0 ? 1 : 0) == expr_32);
        IL_39:
            if (!flag)
            {
                e.Handled = !CtrlOpeningForm.IsTextAllowed(".");
            }
        }

        private void txtCashFloat_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            bool flag;
            do
            {
                bool arg_0D_0;
                bool arg_31_0 = arg_0D_0 = (e.Key == Key.Space);
                do
                {
                    if (2 != 0)
                    {
                        arg_31_0 = (arg_0D_0 = !arg_0D_0);
                    }
                }
                while (false);
                if (7 != 0)
                {
                    flag = arg_31_0;
                }
            }
            while (false);
            if (flag)
            {
                goto IL_23;
            }
        IL_1D:
            e.Handled = true;
        IL_23:
            if (8 != 0)
            {
                return;
            }
            goto IL_1D;
        }

    
    }
}
