using DigiAuditLogger;
using PhotoSW.Common;
//using PhotoSW.Manage.Reports;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using PhotoSW.Views;

namespace PhotoSW.Manage
{
    public partial class ManageReport : Window, IComponentConnector
    {
        

        public ManageReport()
        {
            this.InitializeComponent();
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
        }

        private void btnPrntLog_Click(object sender, RoutedEventArgs e)
        {
            PrintLog printLog = new PrintLog();
            printLog.Show();
            base.Hide();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ManageHome manageHome = new ManageHome();
            manageHome.Show();
            base.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login;
            do
            {
                int arg_2F_0 = LoginUser.UserId;
                do
                {
                    arg_2F_0 = (AuditLog.AddUserLog(arg_2F_0, 39, "Logged out at ") ? 1 : 0);
                }
                while (2 == 0 || false);
                login = new Login();
            }
            while (false);
            login.Show();
            do
            {
                base.Close();
            }
            while (8 == 0);
        }

        private void btnUserLog_Click(object sender, RoutedEventArgs e)
        {
            //ActivityReport activityReport = new ActivityReport();
            base.Hide();
            //activityReport.Show();
        }

   
    }
}
