using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

namespace PhotoSW.PSControls
{
    public partial class CtrlCardPayment : UserControl, IComponentConnector
    {
        private UIElement _parent;

        private bool _hideRequest = false;

        private string _result;

        private TextBox controlon;

        public static readonly DependencyProperty MessageCardPaymentProperty = DependencyProperty.Register("MessageCardPayment", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));


        public string DefaultCurrency
        {
            get;
            set;
        }

        public double TotalBillAmount
        {
            get;
            set;
        }

        public string MessageCardPayment
        {
            get
            {
                return (string)base.GetValue(CtrlCardPayment.MessageCardPaymentProperty);
            }
            set
            {
                base.SetValue(CtrlCardPayment.MessageCardPaymentProperty, value);
            }
        }

        public CtrlCardPayment()
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
            if (3 != 0)
            {
                this.MessageCardPayment = message;
            }
            base.Visibility = Visibility.Visible;
            this.cmbCardType.Focus();
            this.FillYear();
            this.FillMonth();
            this.cmbCardType.SelectedIndex = 0;
            this.txtDefault.Text = this.DefaultCurrency;
            this.TxtAmount.Text = this.TotalBillAmount.ToString("0.00");
            this._parent.IsEnabled = true;
            this._hideRequest = false;
            while (!this._hideRequest)
            {
                if (base.Dispatcher.HasShutdownStarted || base.Dispatcher.HasShutdownFinished)
                {
                    break;
                }
                base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                }));
                Thread.Sleep(20);
            }
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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            new Button();
            Button button = (Button)sender;
            string text = button.Content.ToString();
            int arg_22F_0;
            if (text != null)
            {
                bool expr_3F = (arg_22F_0 = ((text == "ENTER") ? 1 : 0)) != 0;
                if (6 == 0)
                {
                    goto IL_22E;
                }
                if (!false)
                {
                    if (!expr_3F)
                    {
                        if (!(text == "SPACE"))
                        {
                            if (text == "CLOSE")
                            {
                                this.KeyBorder.Visibility = Visibility.Collapsed;
                                return;
                            }
                            if (!(text == "Back"))
                            {
                                goto IL_137;
                            }
                            TextBox textBox = this.controlon;
                            if (!false)
                            {
                                if (this.controlon.Text.Length > 0)
                                {
                                    if (7 == 0)
                                    {
                                        goto IL_82;
                                    }
                                    this.controlon.Text = this.controlon.Text.Remove(this.controlon.Text.Length - 1, 1);
                                }
                                return;
                            }
                            goto IL_8E;
                        }
                        else
                        {
                            this.controlon.Text = this.controlon.Text + " ";
                            if (!false)
                            {
                                return;
                            }
                            return;
                        }
                    }
                IL_82:
                    this.KeyBorder.Visibility = Visibility.Collapsed;
                IL_8E:
                    return;
                }
                goto IL_22B;
            }
        IL_137:
            if (this.controlon.Text.Count<char>() >= 18)
            {
                return;
            }
        IL_158:
            string[] array = new string[]
			{
				"0",
				"1",
				"2",
				"3",
				"4",
				"5",
				"6",
				"7",
				"8",
				"9",
				"."
			};
            int num = Array.IndexOf<object>(array, button.Content);
            if (num <= -1)
            {
                return;
            }
            string[] array2 = (this.controlon.Text + button.Content).Split(new char[]
			{
				'.'
			});
            int arg_218_0 = array2.Length;
            while (arg_218_0 == 2)
            {
                int expr_220 = arg_218_0 = array2[1].Length;
                if (true)
                {
                    arg_22F_0 = ((expr_220 > 2) ? 1 : 0);
                    goto IL_22B;
                }
            }
            arg_22F_0 = 1;
        IL_22B:
        IL_22E:
            if (arg_22F_0 == 0)
            {
                if (true)
                {
                    this.controlon.Text = this.controlon.Text + button.Content;
                    if (2 == 0)
                    {
                        goto IL_158;
                    }
                }
            }
            else if (array2.Length < 2)
            {
                this.controlon.Text = this.controlon.Text + button.Content;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            this._result = string.Empty;
            if (this.cmbCardType.SelectedIndex != 0)
            {
                bool flag = this.cmbMonth.SelectedIndex != 0;
                if (5 != 0)
                {
                    if (!flag)
                    {
                        this.Validation.Text = CommonUtility.getRequiredMessageForDdl(UIConstant.Month);
                        MessageBox.Show(this.Validation.Text, "Spectra Photo");
                        this.cmbMonth.Focus();
                        return;
                    }
                    if (5 != 0)
                    {
                        if (this.cmbYear.SelectedIndex == 0)
                        {
                            this.Validation.Text = CommonUtility.getRequiredMessageForDdl(UIConstant.year);
                            if (4 == 0)
                            {
                                goto IL_23D;
                            }
                            if (5 == 0)
                            {
                                goto IL_31;
                            }
                            MessageBox.Show(this.Validation.Text, "Spectra Photo");
                            this.cmbYear.Focus();
                        }
                        else if (!false)
                        {
                            flag = !(this.txtCardNumber.Text.Trim() == string.Empty);
                            while (!flag)
                            {
                                if (false)
                                {
                                    goto IL_283;
                                }
                                this.Validation.Text = CommonUtility.getRequiredMessage(UIConstant.CardNumber);
                                while (true)
                                {
                                    MessageBox.Show(this.Validation.Text, "Spectra Photo");
                                    this.txtCardNumber.Focus();
                                    if (5 != 0)
                                    {
                                        return;
                                    }
                                }
                            }
                            flag = (this.txtCardNumber.Text.Trim().Length == 4);
                            goto IL_1C0;
                        }
                        return;
                    }
                IL_1C0:
                    if (!flag)
                    {
                        this.Validation.Text = CommonUtility.getRequiredMessage(UIConstant.CardNumberLength);
                        MessageBox.Show(this.Validation.Text, "Spectra Photo");
                        this.txtCardNumber.Focus();
                        return;
                    }
                    bool arg_23F_0;
                    if (!(this.TxtAmount.Text.Trim() == string.Empty))
                    {
                        arg_23F_0 = !(this.TxtAmount.Text.Trim() == "0");
                        goto IL_23E;
                    }
                IL_23D:
                    arg_23F_0 = false;
                IL_23E:
                    if (!arg_23F_0)
                    {
                        this.Validation.Text = CommonUtility.getRequiredMessage(UIConstant.Amount);
                        MessageBox.Show(this.Validation.Text, "Spectra Photo");
                        this.TxtAmount.Focus();
                        return;
                    }
                }
            IL_283:
                this._result = string.Concat(new string[]
				{
					((ComboBoxItem)this.cmbCardType.SelectedItem).Content.ToString(),
					"%##%",
					this.cmbYear.SelectedItem.ToString(),
					"%##%",
					this.cmbMonth.SelectedItem.ToString(),
					"%##%",
					this.txtCardNumber.Text,
					"%##%",
					this.TxtAmount.Text
				});
                this.HideHandlerDialog();
                return;
            }
        IL_31:
            this.Validation.Text = CommonUtility.getRequiredMessageForDdl(UIConstant.CardType);
            MessageBox.Show(this.Validation.Text, "Spectra Photo");
            this.cmbCardType.Focus();
        }

        public void FillYear()
        {
            if (false)
            {
                goto IL_6A;
            }
            this.cmbYear.Items.Clear();
        IL_19:
            DateTime now;
            int num;
            if (!false)
            {
                this.cmbYear.Items.Add("Year");
                now = DateTime.Now;
                num = now.Year;
                goto IL_6A;
            }
        IL_4B:
            this.cmbYear.Items.Add(num);
        IL_61:
            int arg_81_0;
            int expr_65 = arg_81_0 = num + 1;
            if (6 == 0)
            {
                goto IL_7D;
            }
            num = expr_65;
        IL_6A:
            int arg_7B_0 = num;
            now = DateTime.Now;
            arg_81_0 = ((arg_7B_0 > now.Year + 15) ? 1 : 0);
        IL_7D:
            if (false)
            {
                goto IL_61;
            }
            bool flag = arg_81_0 == 0;
            if (2 == 0 || flag)
            {
                goto IL_4B;
            }
            this.cmbYear.SelectedIndex = 0;
            if (8 != 0)
            {
                return;
            }
            goto IL_19;
        }

        public void FillMonth()
        {
            while (3 != 0)
            {
                this.cmbMonth.Items.Clear();
                int arg_34_0;
                int arg_67_0 = arg_34_0 = this.cmbMonth.Items.Add("Month");
                if (true)
                {
                    arg_34_0 = 1;
                    goto IL_34;
                }
                goto IL_63;
            IL_5B:
                int num;
                if (!false)
                {
                    arg_67_0 = (arg_34_0 = ((num > 12) ? 1 : 0));
                    goto IL_63;
                }
                continue;
            IL_34:
                int arg_5A_0;
                int expr_34 = arg_5A_0 = arg_34_0;
                if (expr_34 != 0)
                {
                    if (!false)
                    {
                        num = expr_34;
                    }
                    goto IL_5B;
                }
            IL_5A:
                num = arg_5A_0;
                goto IL_5B;
            IL_63:
                if (false)
                {
                    goto IL_34;
                }
                if (arg_67_0 != 0)
                {
                    break;
                }
                this.cmbMonth.Items.Add(num);
                arg_5A_0 = num + 1;
                goto IL_5A;
            }
            this.cmbMonth.SelectedIndex = 0;
        }

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                Selector expr_06 = this.cmbCardType;
                int expr_0B = 0;
                if (true)
                {
                    expr_06.SelectedIndex = expr_0B;
                }
                while (4 != 0)
                {
                    this.cmbYear.SelectedIndex = 0;
                    if (8 != 0)
                    {
                        this.cmbMonth.SelectedIndex = 0;
                        if (7 == 0)
                        {
                            goto IL_5B;
                        }
                        if (3 != 0)
                        {
                            goto Block_3;
                        }
                    }
                }
            }
        Block_3:
            this.txtCardNumber.Text = string.Empty;
            this.TxtAmount.Text = string.Empty;
        IL_5B:
            this.cmbCardType.Focus();
            this._result = string.Empty;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            while (8 != 0 && 5 != 0)
            {
                if (!false)
                {
                    TextBox expr_0C = this.txtCardNumber;
                    string expr_11 = string.Empty;
                    if (4 != 0)
                    {
                        expr_0C.Text = expr_11;
                    }
                    if (2 != 0)
                    {
                        this._result = string.Empty;
                    }
                    if (5 != 0)
                    {
                        this.HideHandlerDialog();
                    }
                    break;
                }
            }
        }

        private void txtAmountEntered_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CtrlCardPayment.IsTextAllowed(e.Text);
        }

        private void txtAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CtrlCardPayment.IsTextAllowed(e.Text);
        }

        private void txtCardNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !CtrlCardPayment.IsTextAllowedForlast4Digit(e.Text);
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

        private static bool IsTextAllowedForlast4Digit(string text)
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
                    bool expr_4D = arg_27_0 = CtrlCardPayment.IsTextAllowed(text);
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

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.txtDefault.Text = this.DefaultCurrency;
            this.TxtAmount.Focus();
            this.TxtAmount.Text = this.TotalBillAmount.ToString("0.00");
        }

        private void txtCardType_GotFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.controlon = (TextBox)sender;
                    if (false)
                    {
                        break;
                    }
                    this.KeyBorder.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void txtCustomerName_GotFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.controlon = (TextBox)sender;
                    if (false)
                    {
                        break;
                    }
                    this.KeyBorder.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void txtCardNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.controlon = (TextBox)sender;
                    if (false)
                    {
                        break;
                    }
                    this.KeyBorder.Visibility = Visibility.Collapsed;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void TxtAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.controlon = (TextBox)sender;
                    if (false)
                    {
                        break;
                    }
                    this.KeyBorder.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void txtCardNumber_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (6 == 0)
            {
                goto IL_1E;
            }
            bool arg_33_0;
            bool expr_0A = arg_33_0 = (e.Key == Key.Space);
            if (5 != 0)
            {
                arg_33_0 = !expr_0A;
            }
            bool flag;
            if (!false)
            {
                flag = arg_33_0;
            }
        IL_16:
            if (flag)
            {
                return;
            }
            if (!true)
            {
                return;
            }
        IL_1E:
            e.Handled = true;
            if (8 == 0)
            {
                goto IL_16;
            }
        }

        private void TxtAmount_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (6 == 0)
            {
                goto IL_1E;
            }
            bool arg_33_0;
            bool expr_0A = arg_33_0 = (e.Key == Key.Space);
            if (5 != 0)
            {
                arg_33_0 = !expr_0A;
            }
            bool flag;
            if (!false)
            {
                flag = arg_33_0;
            }
        IL_16:
            if (flag)
            {
                return;
            }
            if (!true)
            {
                return;
            }
        IL_1E:
            e.Handled = true;
            if (8 == 0)
            {
                goto IL_16;
            }
        }


    }
}
