using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;

namespace PhotoSW.PSControls
{
    public partial class SaveMail : UserControl, IComponentConnector
    {
        private bool _hideRequest = false;

        private bool _result = false;

        private UIElement _parent;

        public static readonly DependencyProperty mailInfoProperty = DependencyProperty.Register("mailInfo", typeof(EMailInfo), typeof(SaveMail), new UIPropertyMetadata(new EMailInfo()));


        public EMailInfo emailInfo
        {
            get
            {
                return (EMailInfo)base.GetValue(SaveMail.mailInfoProperty);
            }
            set
            {
                base.SetValue(SaveMail.mailInfoProperty, value);
            }
        }

        public SaveMail()
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
            while (true)
            {
                if (!false)
                {
                    this.emailInfo = info;
                    base.Visibility = Visibility.Visible;
                    this._parent.IsEnabled = false;
                    this._hideRequest = false;
                    this.txtAttachement.Text = info.OrderId.ToString().Substring(info.OrderId.LastIndexOf("\\") + 1).ToString();
                }
                this.txtAttachement.IsEnabled = false;
                if (8 != 0)
                {
                    goto IL_EA;
                }
            IL_A6:
                bool flag;
                while (!flag)
                {
                    if (true)
                    {
                        goto Block_4;
                    }
                }
                if (8 == 0)
                {
                    continue;
                }
                base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                }));
                Thread.Sleep(20);
            IL_EA:
                flag = !this._hideRequest;
                if (!flag)
                {
                    break;
                }
                flag = (!base.Dispatcher.HasShutdownStarted && !base.Dispatcher.HasShutdownFinished);
                goto IL_A6;
            }
        Block_4:
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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this._result = true;
            this.HideHandlerDialog();
        }

        private void btnSendMail_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.IsValid())
                {
                    while (true)
                    {
                        EMailInfo eMailInfo;
                        if (!false)
                        {
                            eMailInfo = new EMailInfo();
                            goto IL_2F;
                        }
                        goto IL_120;
                    IL_79:
                        eMailInfo.EmailIsSent = "0";
                        if (true)
                        {
                            if (!false)
                            {
                                eMailInfo.MailSubject = ((this.txtEmailSubject.Text == string.Empty) ? string.Empty : this.txtEmailSubject.Text);
                                eMailInfo.OrderId = this.emailInfo.OrderId;
                                eMailInfo.EmailMessage = ((this.txtEmailBody.Text == string.Empty) ? string.Empty : this.txtEmailBody.Text);
                                eMailInfo.Sendername = this.emailInfo.Sendername;
                            }
                            eMailInfo.MediaName = "D";
                            goto IL_120;
                        }
                        continue;
                    IL_2F:
                        eMailInfo.Emailto = this.txtReciepentsEmail.Text;
                        eMailInfo.EmailBcc = ((this.txtBCCEmail.Text == string.Empty) ? string.Empty : this.txtBCCEmail.Text);
                        goto IL_79;
                    IL_120:
                        if (!false)
                        {
                            eMailInfo.MediaType = "DOC";
                            eMailInfo.OtherMessage = this.emailInfo.OtherMessage;
                            EMailInfo emailInfo = eMailInfo;
                            EmailBusniess emailBusniess = new EmailBusniess();
                            bool flag = emailBusniess.InsertEmailDetails(emailInfo);
                            bool flag2 = !flag;
                            while (!flag2)
                            {
                                AuditLog.AddUserLog(LoginUser.UserId, 105, "Finance Report Email Sent At ");
                                MessageBox.Show("E-Mail Sent Successfully");
                                this._result = true;
                                this.HideHandlerDialog();
                                if (3 == 0)
                                {
                                    goto IL_79;
                                }
                                this.txtAttachement.Text = string.Empty;
                                this.txtBCCEmail.Text = string.Empty;
                                if (false)
                                {
                                    break;
                                }
                                this.txtEmailBody.Text = string.Empty;
                                this.txtEmailSubject.Text = string.Empty;
                                this.txtMessage.Text = string.Empty;
                                if (4 != 0)
                                {
                                    goto Block_12;
                                }
                            }
                            goto IL_204;
                        }
                        goto IL_2F;
                    }
                Block_12:
                    this.txtReciepentsEmail.Text = string.Empty;
                IL_204: ;
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

    }
}
