using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;

namespace PhotoSW.PSControls
{
    public partial class SendEmailOrder : UserControl, IComponentConnector
    {
        private bool _hideRequest = false;

        private bool _result = false;

        private TextBox controlon;

        private UIElement _parent;

        public static readonly DependencyProperty mailInfoProperty = DependencyProperty.Register("mailInfo", typeof(EMailInfo), typeof(SendEmailOrder), new UIPropertyMetadata(new EMailInfo()));

      

        public EMailInfo emailInfo
        {
            get
            {
                return (EMailInfo)base.GetValue(SendEmailOrder.mailInfoProperty);
            }
            set
            {
                base.SetValue(SendEmailOrder.mailInfoProperty, value);
            }
        }

        public SendEmailOrder()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
        }

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            this._result = true;
            this.HideHandlerDialog();
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public bool ShowHandlerDialog(EMailInfo info)
        {
            if (false)
            {
                goto IL_BD;
            }
            this.emailInfo = info;
        IL_17:
            bool expr_1C = true;
            if (!false)
            {
                base.IsEnabled = expr_1C;
            }
            if (8 != 0)
            {
                base.Visibility = Visibility.Visible;
                UIElement expr_3D = this._parent;
                bool expr_42 = false;
                if (!false)
                {
                    expr_3D.IsEnabled = expr_42;
                }
                this._hideRequest = false;
            }
        IL_BB:
        IL_BD:
            bool flag = !this._hideRequest;
            bool arg_C8_0 = flag ? true : false;
            while (arg_C8_0)
            {
                bool arg_7B_0;
                if (!base.Dispatcher.HasShutdownStarted)
                {
                    if (false)
                    {
                        goto IL_7C;
                    }
                    arg_C8_0 = (arg_7B_0 = ((!base.Dispatcher.HasShutdownFinished) ? true : false));
                }
                else
                {
                    arg_C8_0 = (arg_7B_0 = false);
                }
                if (2 == 0)
                {
                    continue;
                }
                flag = (arg_7B_0 != false);
            IL_7C:
                if (!flag)
                {
                    while (!false)
                    {
                        if (!false)
                        {
                            goto IL_CD;
                        }
                    }
                    goto IL_17;
                }
                base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                }));
                Thread.Sleep(20);
                goto IL_BB;
            }
        IL_CD:
            return this._result;
        }

        private void HideHandlerDialog()
        {
            if (4 != 0)
            {
                this._hideRequest = true;
                do
                {
                    Visibility expr_0E = Visibility.Hidden;
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

        private void btnSendMail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool expr_0D = !this.IsValid();
                bool flag;
                if (8 != 0)
                {
                    flag = expr_0D;
                }
                if (!flag)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    string[] array = this.emailInfo.OtherMessage.Split(new char[]
					{
						','
					});
                    string[] array2 = array;
                    int num = 0;
                    while (true)
                    {
                        flag = (num < array2.Length);
                        if (!flag)
                        {
                            break;
                        }
                        string str = array2[num];
                        stringBuilder.Append(str + "[" + this.txtMessage.Text + "{");
                        num++;
                    }
                    EMailInfo emailInfo = new EMailInfo
                    {
                        Emailto = this.txtReciepentsEmail.Text,
                        EmailBcc = ((this.txtBCCEmail.Text == string.Empty) ? string.Empty : this.txtBCCEmail.Text),
                        EmailIsSent = "0",
                        MailSubject = ((this.txtEmailSubject.Text == string.Empty) ? string.Empty : this.txtEmailSubject.Text),
                        OrderId = this.emailInfo.OrderId,
                        EmailMessage = ((this.txtEmailBody.Text == string.Empty) ? string.Empty : this.txtEmailBody.Text),
                        Sendername = this.emailInfo.Sendername,
                        MediaName = "EM",
                        OtherMessage = stringBuilder.ToString().Substring(0, stringBuilder.Length - 1)
                    };
                    EmailBusniess emailBusniess = new EmailBusniess();
                    bool flag2 = emailBusniess.InsertEmailDetails(emailInfo);
                    flag = !flag2;
                    if (!flag)
                    {
                        AuditLog.AddUserLog(LoginUser.UserId, 105, "Finance Report Email Sent At ");
                        this._result = true;
                        this.HideHandlerDialog();
                        this.txtBCCEmail.Text = string.Empty;
                        this.txtEmailBody.Text = string.Empty;
                        this.txtEmailSubject.Text = string.Empty;
                        this.txtMessage.Text = string.Empty;
                        this.txtReciepentsEmail.Text = string.Empty;
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool IsValid()
        {
            Regex regex = new Regex("^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$");
            Match match = regex.Match(this.txtReciepentsEmail.Text);
            bool result;
            if (this.txtReciepentsEmail.Text == "")
            {
                if (!false)
                {
                    MessageBox.Show("Please Enter Reciepent MailId");
                    this.txtReciepentsEmail.Focus();
                    result = false;
                    return result;
                }
                goto IL_EF;
            }
            else
            {
                bool flag = match.Success;
                bool arg_81_0 = flag;
                if (3 == 0)
                {
                    goto IL_10C;
                }
                if (arg_81_0)
                {
                    bool arg_CB_0;
                    if (!string.IsNullOrEmpty(this.txtBCCEmail.Text))
                    {
                        arg_CB_0 = string.IsNullOrWhiteSpace(this.txtBCCEmail.Text);
                    }
                    else
                    {
                        if (7 == 0)
                        {
                            goto IL_119;
                        }
                        arg_CB_0 = true;
                    }
                    flag = arg_CB_0;
                    if (false)
                    {
                        goto IL_EF;
                    }
                    if (!flag)
                    {
                        match = regex.Match(this.txtBCCEmail.Text);
                        if (!match.Success)
                        {
                            goto IL_EF;
                        }
                        result = true;
                        return result;
                    }
                IL_119:
                    result = true;
                    return result;
                }
            }
        IL_84:
            MessageBox.Show("Please Enter Vaild Email Address");
            this.txtReciepentsEmail.Focus();
            result = false;
            return result;
        IL_EF:
            MessageBox.Show("Please Enter Vaild Email Address");
            if (false)
            {
                goto IL_84;
            }
            this.txtBCCEmail.Focus();
        IL_10C:
            if (8 != 0)
            {
                result = false;
            }
            return result;
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string expr_167 = button.Content.ToString();
            string text;
            if (8 != 0)
            {
                text = expr_167;
            }
            while (text != null)
            {
                if (!(text == "ENTER"))
                {
                    if (!(text == "SPACE"))
                    {
                        if (text == "CLOSE")
                        {
                            this.KeyBorder.Visibility = Visibility.Hidden;
                            return;
                        }
                        if (8 == 0)
                        {
                            goto IL_120;
                        }
                        if (!(text == "Back"))
                        {
                            if (!false)
                            {
                                break;
                            }
                            continue;
                        }
                        else
                        {
                            TextBox textBox = this.controlon;
                        }
                    }
                    else if (true)
                    {
                        this.controlon.Text = this.controlon.Text + " ";
                        if (6 != 0)
                        {
                            return;
                        }
                        break;
                    }
                    int arg_EB_0;
                    int expr_DF = arg_EB_0 = this.controlon.Text.Length;
                    int arg_EB_1;
                    int expr_E5 = arg_EB_1 = 0;
                    if (expr_E5 == 0)
                    {
                        arg_EB_0 = ((expr_DF > expr_E5) ? 1 : 0);
                        arg_EB_1 = 0;
                    }
                    if (arg_EB_0 != arg_EB_1)
                    {
                        this.controlon.Text = this.controlon.Text.Remove(this.controlon.Text.Length - 1, 1);
                    }
                IL_120:
                    return;
                }
                if (!false)
                {
                    this.KeyBorder.Visibility = Visibility.Hidden;
                    return;
                }
            IL_125:
                this.controlon.Text = this.controlon.Text + button.Content;
                return;
            }
            //goto IL_125;
        }

        private void txtReciepentsEmail_GotFocus(object sender, RoutedEventArgs e)
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

        private void txtBCCEmail_GotFocus(object sender, RoutedEventArgs e)
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

        private void txtEmailSubject_GotFocus(object sender, RoutedEventArgs e)
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

        private void txtMessage_GotFocus(object sender, RoutedEventArgs e)
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

        private void txtEmailBody_GotFocus(object sender, RoutedEventArgs e)
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

 
    }
}
