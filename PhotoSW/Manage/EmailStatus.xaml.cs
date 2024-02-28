using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;
using Xceed.Wpf.Toolkit;
using DigiPhoto;
using PhotoSW.Views;

namespace PhotoSW.Manage
{
    public partial class EmailStatus : Window, IComponentConnector
    {
        public int type = 1;

        private List<EmailStatusInfo> _lstEmailStatus;

        

        public EmailStatus()
        {
            this.InitializeComponent();
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
            DateTime date = new CustomBusineses().ServerDateTime().Date;
            this.dtFrom.DefaultValue = date;
            this.dtFrom.Value = new DateTime?(date);
            this.dtTo.Value = new DateTime?(new CustomBusineses().ServerDateTime());
            this.FillEmailTypeDropdown();
            this.GetPendingEmails();
            this.AllowForPhotoSend();
            this.chkALL.IsEnabled = true;
            this.chkALL.IsChecked = new bool?(false);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (-1 != 0)
            {
                try
                {
                    ManageHome manageHome = new ManageHome();
                    manageHome.Show();
                    base.Close();
                }
                catch (Exception serviceException)
                {
                    while (!false && !false)
                    {
                        if (-1 != 0)
                        {
                            ErrorHandler.ErrorHandler.LogError(serviceException);
                            break;
                        }
                    }
                }
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (2 != 0)
                {
                    int expr_28 = LoginUser.UserId;
                    if (8 != 0)
                    {
                        AuditLog.AddUserLog(expr_28, 39, "Logged out at ");
                    }
                    Login login = new Login();
                    login.Show();
                }
                do
                {
                    base.Close();
                }
                while (false);
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (6 == 0);
            }
            finally
            {
                MemoryManagement.FlushMemory();
            }
            if (5 != 0)
            {
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int arg_07_0 = this.BindGrid();
                int arg_07_1 = 0;
                int expr_07;
                int expr_0A;
                do
                {
                    expr_07 = (arg_07_0 = ((arg_07_0 == arg_07_1) ? 1 : 0));
                    expr_0A = (arg_07_1 = 0);
                }
                while (expr_0A != 0);
                if (expr_07 == expr_0A)
                {
                    goto IL_22;
                }
            IL_15:
                if (8 != 0)
                {
                    System.Windows.MessageBox.Show("There is no Record !!");
                }
            IL_22:
                this.EnableDisableSendMail();
                if (false)
                {
                    goto IL_15;
                }
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
            while (false)
            {
            }
        }

        private int BindGrid()
        {
            if (3 == 0)
            {
                goto IL_A2;
            }
            this.chkALL.IsChecked = new bool?(false);
        IL_1D:
            DateTime? expr_167 = this.dtFrom.Value;
            DateTime? dateTime;
            if (5 != 0)
            {
                dateTime = expr_167;
            }
            DateTime arg_66_0;
            if (dateTime.HasValue)
            {
                arg_66_0 = this.dtFrom.Value.ToDateTime(false);
                goto IL_65;
            }
            DateTime now = DateTime.Now;
        IL_46:
            arg_66_0 = now.Date;
        IL_65:
            DateTime startDate = arg_66_0;
            dateTime = this.dtTo.Value;
            DateTime endDate = dateTime.HasValue ? this.dtTo.Value.ToDateTime(false) : DateTime.Now;
            EmailStatusInfo emailStatusInfo = new EmailStatusInfo();
        IL_A2:
            if (!false)
            {
                emailStatusInfo.StartDate = startDate;
                emailStatusInfo.EndDate = endDate;
            }
        IL_B5:
            while (!false)
            {
                emailStatusInfo.Status = (int)Convert.ToInt16(this.cmbEmailType.SelectedValue);
                EmailStatusInfo rfidEmailObj = emailStatusInfo;
                this._lstEmailStatus = new EmailBusniess().GetEmailStatus(rfidEmailObj);
                this._lstEmailStatus.ForEach(delegate(EmailStatusInfo x)
                {
                    x.OrderId = x.OrderId.ToString().Substring(x.OrderId.LastIndexOf("\\") + 1).ToString();
                });
                this.Dg_EmailStatus.ItemsSource = this._lstEmailStatus;
                int count;
                do
                {
                    this.EnableDisableSendMail();
                    if (6 == 0)
                    {
                        goto IL_B5;
                    }
                    count = this._lstEmailStatus.Count;
                }
                while (false);
                if (2 != 0)
                {
                    return count;
                }
                goto IL_46;
            }
            goto IL_1D;
        }

        private void EnableDisableSendMail()
        {
            if (this.Dg_EmailStatus.Items.Count > 0)
            {
                this.btnEmailSend.IsEnabled = true;
                this.btnEmailSendFailed.IsEnabled = true;
                this.chkALL.IsEnabled = true;
            }
            else
            {
                this.btnEmailSend.IsEnabled = false;
                this.btnEmailSendFailed.IsEnabled = false;
                this.chkALL.IsEnabled = false;
            }
        }

        private void GetPendingEmails()
        {
            if (false)
            {
                goto IL_8A;
            }
            this.chkALL.IsChecked = new bool?(false);
        IL_1D:
            DateTime startDate;
            DateTime arg_A8_0;
            if (!false)
            {
                DateTime? value = this.dtFrom.Value;
                bool arg_3E_0 = value.HasValue;
                bool expr_80;
                do
                {
                    DateTime arg_6D_0;
                    if (!arg_3E_0)
                    {
                        arg_6D_0 = DateTime.Now.Date;
                    }
                    else
                    {
                        if (5 == 0)
                        {
                            goto IL_AF;
                        }
                        arg_6D_0 = this.dtFrom.Value.ToDateTime(false);
                    }
                    startDate = arg_6D_0;
                    value = this.dtTo.Value;
                    if (-1 == 0)
                    {
                        goto IL_91;
                    }
                    expr_80 = (arg_3E_0 = value.HasValue);
                }
                while (7 == 0);
                if (!expr_80)
                {
                    goto IL_8A;
                }
            IL_91:
                arg_A8_0 = this.dtTo.Value.ToDateTime(false);
                goto IL_A7;
            }
            goto IL_DC;
        IL_8A:
            arg_A8_0 = DateTime.Now;
        IL_A7:
            DateTime endDate = arg_A8_0;
            EmailStatusInfo emailStatusInfo = new EmailStatusInfo();
        IL_AF:
            emailStatusInfo.StartDate = startDate;
            if (false)
            {
                goto IL_1D;
            }
            emailStatusInfo.EndDate = endDate;
            emailStatusInfo.Status = (int)Convert.ToInt16(this.cmbEmailType.SelectedValue);
        IL_DC:
            EmailStatusInfo rfidEmailObj = emailStatusInfo;
            this._lstEmailStatus = new EmailBusniess().GetEmailStatus(rfidEmailObj);
            this._lstEmailStatus.ForEach(delegate(EmailStatusInfo x)
            {
                x.OrderId = x.OrderId.ToString().Substring(x.OrderId.LastIndexOf("\\") + 1).ToString();
            });
            this.Dg_EmailStatus.ItemsSource = this._lstEmailStatus;
        }

        private void cmbEmailType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                do
                {
                    this.Dg_EmailStatus.ItemsSource = null;
                }
                while (7 == 0);
                CollectionView expr_6C = this.Dg_EmailStatus.Items;
                if (!false)
                {
                    expr_6C.Refresh();
                }
                this.AllowForPhotoSend();
                int arg_2E_0 = this.type;
                bool expr_32;
                do
                {
                    bool flag = arg_2E_0 == 1;
                    expr_32 = ((arg_2E_0 = (flag ? 1 : 0)) != 0);
                }
                while (false || 2 == 0 || false || 5 == 0);
                if (!expr_32)
                {
                    this.EnableDisableSendMail();
                }
                this.type++;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void btnEmailSend_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                try
                {
                    int sendType = 0;
                    Button button = (Button)sender;
                    string name = button.Name;
                    if (name != null)
                    {
                        if (!(name == "btnEmailSend"))
                        {
                            if (name == "btnEmailSendFailed")
                            {
                                sendType = 0;
                            }
                        }
                        else
                        {
                            sendType = 1;
                        }
                    }
                    StringBuilder stringBuilder = new StringBuilder();
                    StringBuilder stringBuilder2 = new StringBuilder();
                    stringBuilder.Clear();
                    using (List<EmailStatusInfo>.Enumerator enumerator = this._lstEmailStatus.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            EmailStatusInfo current;
                            if (3 != 0)
                            {
                                current = enumerator.Current;
                            }
                            bool arg_AF_0 = current.IsAvailable == true;
                            bool expr_AF;
                            do
                            {
                                expr_AF = (arg_AF_0 = !arg_AF_0);
                            }
                            while (6 == 0);
                            if (!expr_AF)
                            {
                                stringBuilder.Append(current.DG_Email_pkey + ",");
                                stringBuilder2.Append(current.OrderId + ",");
                            }
                        }
                    }
                    if (stringBuilder.Length > 0)
                    {
                        bool arg_147_0 = new EmailBusniess().ResendEmail(stringBuilder.ToString().Substring(0, stringBuilder.Length - 1), sendType);
                        do
                        {
                            bool flag = arg_147_0;
                            if (!flag)
                            {
                                break;
                            }
                            AuditLog.AddUserLog(LoginUser.UserId, 106, "Resend email for the order  " + stringBuilder2.ToString().Substring(0, stringBuilder2.Length - 1) + " .");
                            System.Windows.MessageBox.Show("Email Re-Initiated Successfully");
                            arg_147_0 = (this.BindGrid() != 0);
                        }
                        while (3 == 0);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No record selected");
                    }
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            if (8 != 0 && 5 != 0)
            {
                try
                {
                    while (false)
                    {
                    }
                }
                catch (Exception serviceException)
                {
                    if (2 != 0)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
        }

        private void chkALL_Checked(object sender, RoutedEventArgs e)
        {
            do
            {
                if (3 != 0)
                {
                    try
                    {
                        do
                        {
                            this._lstEmailStatus.ForEach(delegate(EmailStatusInfo z)
                            {
                                z.IsAvailable = new bool?(true);
                            });
                            do
                            {
                                this.Dg_EmailStatus.ItemsSource = this._lstEmailStatus;
                            }
                            while (2 == 0);
                            if (3 == 0)
                            {
                                break;
                            }
                            this.Dg_EmailStatus.Items.Refresh();
                        }
                        while (2 == 0);
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (2 == 0);
        }

        private void chkALL_Unchecked(object sender, RoutedEventArgs e)
        {
            do
            {
                if (3 != 0)
                {
                    try
                    {
                        do
                        {
                            this._lstEmailStatus.ForEach(delegate(EmailStatusInfo z)
                            {
                                z.IsAvailable = new bool?(false);
                            });
                            do
                            {
                                this.Dg_EmailStatus.ItemsSource = this._lstEmailStatus;
                            }
                            while (2 == 0);
                            if (3 == 0)
                            {
                                break;
                            }
                            this.Dg_EmailStatus.Items.Refresh();
                        }
                        while (2 == 0);
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (2 == 0);
        }

        private void FillEmailTypeDropdown()
        {
            do
            {
                if (!false)
                {
                    ItemCollection expr_3A = this.cmbEmailType.Items;
                    if (7 != 0)
                    {
                        expr_3A.Clear();
                    }
                    if (5 != 0)
                    {
                    }
                    this.cmbEmailType.ItemsSource = RobotImageLoader.GetEmailType();
                }
                if (true)
                {
                    this.cmbEmailType.SelectedValue = "10";
                }
            }
            while (7 == 0);
        }

        private void AllowForPhotoSend()
        {
            while (true)
            {
                bool arg_D5_0;
                bool arg_2A_0;
                bool expr_15 = arg_2A_0 = (arg_D5_0 = (this.cmbEmailType.SelectedValue == "2"));
                if (-1 != 0)
                {
                    arg_D5_0 = !expr_15;
                    goto IL_1D;
                }
            IL_27:
                if (!false)
                {
                    if (arg_2A_0)
                    {
                        goto IL_8C;
                    }
                    this.btnEmailSend.Width = 265.0;
                    this.btnEmailSend.Content = "Send Email for all photos";
                    this.btnEmailSendFailed.Content = "Send Email for failed photos";
                    if (false)
                    {
                        goto IL_A1;
                    }
                    this.btnEmailSendFailed.Visibility = Visibility.Visible;
                    if (!false)
                    {
                        break;
                    }
                    continue;
                }
            IL_1D:
                bool flag = arg_D5_0;
                arg_D5_0 = (arg_2A_0 = flag);
                goto IL_27;
            }
            if (!false)
            {
                return;
            }
            goto IL_B2;
        IL_8C:
            this.btnEmailSend.Width = 127.0;
        IL_A1:
            this.btnEmailSend.Content = "Send Email";
        IL_B2:
            this.btnEmailSendFailed.Visibility = Visibility.Collapsed;
            if (8 == 0)
            {
                goto IL_8C;
            }
        }

 
    }
}
