using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.Data;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using PhotoSW.Views;

namespace PhotoSW.Manage
{
    public partial class PrintLog : Window, IComponentConnector
    {
       

        public PrintLog()
        {
            try
            {
                this.InitializeComponent();
                this.DGPrintLog.ItemsSource = new PrinterBusniess().GetPrintLogDetails();
                this.FillPhotographerCombo();
                this.txbUserName.Text = LoginUser.UserName;
                this.txbStoreName.Text = LoginUser.StoreName;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            ManageReport manageReport = new ManageReport();
            manageReport.Show();
            base.Close();
        }

        private void FillPhotographerCombo()
        {
            do
            {
                List<PhotoGraphersInfo> photoGrapher = new PhotoBusiness().GetPhotoGrapher();
                do
                {
                    CommonUtility.BindComboWithSelect<PhotoGraphersInfo>(this.cmbPhotographer, photoGrapher, "Photograper", "DG_User_pkey", 0, ClientConstant.SelectString);
                }
                while (false || !true || false);
                this.cmbPhotographer.SelectedValue = "0";
            }
            while (false);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    AuditLog.AddUserLog(LoginUser.UserId, 39, "Logged out at ");
                    do
                    {
                        Login login = new Login();
                        login.Show();
                        base.Close();
                    }
                    while (false);
                }
                catch (Exception serviceException)
                {
                    while (true)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                        while (!false)
                        {
                            if (5 != 0)
                            {
                                goto Block_6;
                            }
                        }
                    }
                Block_6: ;
                }
                while (false)
                {
                }
            }
            while (6 == 0);
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            this.cmbPhotographer.SelectedValue.ToString();
        }

       
    }
}
