using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Manage;
//using DigiPhoto.Orders;
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

namespace PhotoSW.PSControls
{
    public partial class CashBoxes : UserControl, IComponentConnector
    {
        private TextBox controlon;

        private bool isEnableSlipPrint = true;

       

        public CashBoxes()
        {
            this.InitializeComponent();
            this.GrdPrint.Visibility = Visibility.Visible;
            //List<iMIXConfigurationInfo> newConfigValues = new ConfigBusiness().GetNewConfigValues(Convert.ToInt32(LoginUser.SubStoreId));
            //foreach (iMIXConfigurationInfo current in newConfigValues)
            //{
            //    long iMIXConfigurationMasterId = current.IMIXConfigurationMasterId;
            //    if (iMIXConfigurationMasterId == 79L)
            //    {
            //        this.isEnableSlipPrint = (string.IsNullOrWhiteSpace(current.ConfigurationValue) || Convert.ToBoolean(current.ConfigurationValue));
            //    }
            //}
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (8 != 0 && 5 != 0)
            {
                try
                {
                    if (!false)
                    {
                    }
                    if (4 != 0)
                    {
                        this.fillCombo();
                    }
                    while (2 == 0)
                    {
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        private void fillCombo()
        {
            do
            {
                List<string> list = new List<string>();
                list.Add("--Select--");
                try
                {
                    if (6 != 0)
                    {
                        List<ValueTypeInfo> list2 = new ValueTypeBusiness().GetReasonType(1);
                        bool flag = list2 != null;
                        bool arg_47_0 = flag;
                        if (4 != 0)
                        {
                            if (!arg_47_0)
                            {
                                list2 = new List<ValueTypeInfo>();
                            }
                        IL_50:
                            if (!false)
                            {
                                flag = (LoginUser.RoleId == 7 || LoginUser.RoleId == 101);
                                if (-1 == 0)
                                {
                                    goto IL_50;
                                }
                                if (!flag)
                                {
                                    list2.RemoveAll((ValueTypeInfo x) => x.ValueTypeId == 101);
                                }
                            }
                        }
                        list2.Add(new ValueTypeInfo
                        {
                            Name = "Others",
                            ValueTypeId = -1
                        });
                        CommonUtility.BindComboWithSelect<ValueTypeInfo>(this.CmbReasonType, list2, "Name", "ValueTypeId", 0, ClientConstant.SelectString);
                    }
                    this.CmbReasonType.SelectedIndex = 0;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
            while (8 == 0);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            if (2 == 0)
            {
                goto IL_25;
            }
            this.GrdPrint.Visibility = Visibility.Hidden;
        IL_0E:
            ManageHome manageHome;
            while (!false)
            {
                if (4 != 0)
                {
                    ManageHome expr_4B = new ManageHome();
                    if (!false)
                    {
                        manageHome = expr_4B;
                    }
                    manageHome.brdMain.IsEnabled = true;
                    break;
                }
            }
        IL_25:
            if (!false)
            {
                manageHome.Show();
                if (7 == 0)
                {
                    goto IL_0E;
                }
                Window window = Window.GetWindow(this);
                window.Close();
            }
        }

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            try
                {

               
            if (!false)
            {
                this.GrdPrint.Visibility = Visibility.Hidden;
                goto IL_0E;
            }
            while (true)
            {
            IL_16:
                ManageHome manageHome;
                manageHome.Show();
                if (false)
                {
                    break;
                }
                Window window = Window.GetWindow(this);
                window.Close();
                if (-1 != 0)
                {
                    return;
                }
            }
        IL_0E:
            if (!false)
            {
                ManageHome manageHome = new ManageHome();
                //goto IL_16;
            }

            }
            catch
             {

             }
       }

        private void btnsubmit_click(object sender, RoutedEventArgs e)
        {
            string expr_01 = string.Empty;
            if (false)
            {
            }
            ValueTypeInfo valueTypeInfo = (ValueTypeInfo)this.CmbReasonType.SelectedItem;
            string text;
            if (valueTypeInfo.Name == "Others")
            {
                if (string.IsNullOrWhiteSpace(this.txtreason.Text.Trim()))
                {
                    MessageBox.Show("Please enter the Comment.");
                    return;
                }
                text = valueTypeInfo.Name + "-" + this.txtreason.Text.Trim();
            }
            else
            {
                if (string.IsNullOrWhiteSpace(this.txtreason.Text.Trim()))
                {
                    text = valueTypeInfo.Name;
                }
                else
                {
                    text = valueTypeInfo.Name + "-" + this.txtreason.Text.Trim();
                }
                if (string.IsNullOrEmpty(text))
                {
                    MessageBox.Show("Please select reason to open cash drawer.");
                    return;
                }
                if (valueTypeInfo.Name == "--Select--")
                {
                    MessageBox.Show("Please select reason to open cash drawer.");
                    return;
                }
            }
            new PhotoSW.IMIX.Business.CashBoxBusiness().SetcashBoxReason(new PhotoSW.IMIX.Business.CustomBusineses().ServerDateTime(), LoginUser.UserId, text);
            this.txtreason.Clear();
            this.GrdPrint.Visibility = Visibility.Hidden;
            MessageBox.Show("Comment saved successfully.");
            new ManageHome
            {
                brdMain =
                {
                    IsEnabled = true
                }
            }.Show();
            Window window = Window.GetWindow(this);
            window.Close();
            AuditLog.AddUserLog(LoginUser.UserId, 65, "Action: Cash Drawer opened Reason: " + text + " Opened at ");
            if (this.isEnableSlipPrint)
            {
                //TestBill testBill = new TestBill(LoginUser.SubstoreName.ToString(), LoginUser.UserName.ToString(), text);
            }
        }

        private void txtreason_GotFocus(object sender, RoutedEventArgs e)
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
                 //   this.KeyBorder.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            new Button();
            if (false)
            {
            }
            Button button = (Button)sender;
            string text = button.Content.ToString();
            if (-1 != 0)
            {
                if (6 != 0)
                {
                    if (text != null)
                    {
                        if (5 == 0)
                        {
                            goto IL_168;
                        }
                        if (text == "ENTER")
                        {
                            this.controlon.Text = this.controlon.Text + Environment.NewLine;
                            return;
                        }
                        if (2 == 0)
                        {
                            goto IL_168;
                        }
                        if (text == "SPACE")
                        {
                            this.controlon.Text = this.controlon.Text + " ";
                            return;
                        }
                        if (text == "CLOSE")
                        {
                            goto IL_D9;
                        }
                        if (text == "Back")
                        {
                            TextBox textBox = this.controlon;
                            goto IL_F4;
                        }
                    }
                    this.controlon.Text = this.controlon.Text + button.Content;
                IL_168:
                    return;
                }
            }
        IL_D9:
           // this.KeyBorder.Visibility = Visibility.Collapsed;
            if (-1 != 0)
            {
                return;
            }
        IL_F4:
            if (this.controlon.Text.Length > 0)
            {
                if (!false)
                {
                    this.controlon.Text = this.controlon.Text.Remove(this.controlon.Text.Length - 1, 1);
                }
            }
        }

  
    }
}
