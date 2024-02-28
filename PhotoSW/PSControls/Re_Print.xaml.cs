using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using PhotoSW.ViewModels;

namespace PhotoSW.PSControls
{
    public partial class Re_Print : UserControl, IComponentConnector, IStyleConnector
    {
        private UIElement _parent;

        private bool _hideRequest = false;

        private string _result;

        private List<string> printerqueueid = new List<string>();

 

        public Re_Print()
        {
            this.InitializeComponent();
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public string ShowHandlerDialog()
        {
            int arg_6F_0;
            if (!false)
            {
                if (false)
                {
                    goto IL_B1;
                }
                base.Visibility = Visibility.Visible;
                do
                {
                    this.txtOrderno.Text = "";
                    if (8 == 0)
                    {
                        goto IL_7C;
                    }
                }
                while (false);
                arg_6F_0 = (this.txtOrderno.Focus() ? 1 : 0);
                if (5 == 0)
                {
                    goto IL_6E;
                }
            }
            this._hideRequest = false;
            goto IL_B1;
        IL_63:
            arg_6F_0 = (base.Dispatcher.HasShutdownFinished ? 1 : 0);
        IL_6E:
            bool arg_75_0 = arg_6F_0 == 0;
        IL_74:
            if (!arg_75_0)
            {
                goto IL_C1;
            }
        IL_7C:
            base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
            }));
            Thread.Sleep(20);
        IL_B1:
            if (!this._hideRequest)
            {
                if (!base.Dispatcher.HasShutdownStarted)
                {
                    goto IL_63;
                }
                arg_75_0 = false;
                goto IL_74;
            }
        IL_C1:
            if (5 != 0)
            {
                return this._result;
            }
            goto IL_63;
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = string.Empty;
            this.HideHandlerDialog();
        }

        private void btnSearchReprint_Click(object sender, RoutedEventArgs e)
        {
            if (4 != 0)
            {
                bool arg_2C_0;
                bool arg_15_0;
                bool expr_25 = arg_15_0 = (arg_2C_0 = this.CheckValidation());
                if (6 == 0)
                {
                    goto IL_12;
                }
                arg_2C_0 = !expr_25;
            IL_0E:
                bool flag = arg_2C_0;
                arg_2C_0 = (arg_15_0 = flag);
            IL_12:
                if (false)
                {
                    goto IL_0E;
                }
                if (!arg_15_0)
                {
                    while (3 == 0)
                    {
                    }
                    this.GetPrinterQueueDetails();
                }
            }
        }

        public void GetPrinterQueueDetails()
        {
            string text;
            if (!false)
            {
                text = this.txtOrderno.Text.ToUpperInvariant();
                bool flag;
                if (true)
                {
                    flag = (text.IndexOf("DG-", StringComparison.OrdinalIgnoreCase) >= 0);
                }
                if (!flag)
                {
                    text = "DG-" + text;
                }
            }
            List<AllPrinterQueue> list = new List<AllPrinterQueue>();
            try
            {
                do
                {
                    List<PrinterQueueDetailsInfo> printerQueueDetails = new PrinterBusniess().GetPrinterQueueDetails(text);
                    bool flag = printerQueueDetails.Count == 0;
                    if (flag)
                    {
                        goto IL_182;
                    }
                    List<PrinterQueueDetailsInfo>.Enumerator enumerator = printerQueueDetails.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            bool arg_C4_0;
                            bool expr_133 = arg_C4_0 = enumerator.MoveNext();
                            PrinterQueueDetailsInfo current;
                            AllPrinterQueue allPrinterQueue;
                            PhotoInfo photoByPhotoID;
                            if (2 != 0)
                            {
                                flag = expr_133;
                                if (!flag)
                                {
                                    break;
                                }
                                current = enumerator.Current;
                                allPrinterQueue = new AllPrinterQueue();
                                allPrinterQueue.Imagname = current.DG_Photos_RFID;
                                photoByPhotoID = new PhotoBusiness().GetPhotoByPhotoID(current.DG_Photos_pKey);
                                flag = (photoByPhotoID != null);
                                arg_C4_0 = flag;
                            }
                            if (!arg_C4_0)
                            {
                                allPrinterQueue.Filepath = Path.Combine(photoByPhotoID.HotFolderPath, "Thumbnails");
                            }
                            else
                            {
                                if (false)
                                {
                                    break;
                                }
                                allPrinterQueue.Filepath = Path.Combine(photoByPhotoID.HotFolderPath, "Thumbnails", photoByPhotoID.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoByPhotoID.DG_Photos_FileName);
                            }
                            allPrinterQueue.Printerkey = current.DG_PrinterQueue_Pkey;
                            list.Add(allPrinterQueue);
                        }
                    }
                    finally
                    {
                        ((IDisposable)enumerator).Dispose();
                        while (false)
                        {
                        }
                    }
                    this.dgReprint.ItemsSource = list;
                    if (false)
                    {
                        break;
                    }
                    this.dgReprint.Visibility = Visibility.Visible;
                }
                while (false);
                goto IL_18F;
            IL_182:
                MessageBox.Show("No records found, please check the order number");
            IL_18F: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool CheckValidation()
        {
            bool result;
            while (true)
            {
                bool arg_15_0;
                bool arg_1E_0 = arg_15_0 = (this.txtOrderno.Text == "");
                while (true)
                {
                    bool flag;
                    if (4 != 0)
                    {
                        flag = !arg_15_0;
                        goto IL_19;
                    }
                IL_1B:
                    if (false)
                    {
                        continue;
                    }
                    if (!arg_1E_0)
                    {
                        MessageBox.Show("Please enter the Order number first");
                        while (7 != 0)
                        {
                            bool expr_2C = false;
                            if (!false)
                            {
                                result = expr_2C;
                            }
                            if (4 != 0)
                            {
                                if (!false)
                                {
                                    goto Block_5;
                                }
                                goto IL_19;
                            }
                        }
                        break;
                    }
                    goto IL_39;
                IL_19:
                    arg_1E_0 = (arg_15_0 = flag);
                    goto IL_1B;
                }
            }
        Block_5:
            return result;
        IL_39:
            result = true;
            return result;
        }

        private void btnReprint_Click(object sender, RoutedEventArgs e)
        {
            if (this.printerqueueid.Count != 0)
            {
                foreach (string current in this.printerqueueid)
                {
                    PrinterQueueInfo queueDetail = new PrinterBusniess().GetQueueDetail(Convert.ToInt32(current));
                    new PrinterBusniess().UpdatePrintCountForReprint(Convert.ToInt32(current));
                    new OrderBusiness().SetOrderDetailsForReprint(queueDetail.DG_Orders_LineItems_pkey, LoginUser.SubStoreId);
                    AuditLog.AddUserLog(LoginUser.UserId, 44, string.Concat(new string[]
					{
						"Reprint ",
						queueDetail.DG_Orders_ProductType_Name.ToString(),
						" ( image no:",
						queueDetail.DG_Photos_RFID.ToString(),
						" ) of Order No ",
						queueDetail.DG_Orders_Number.ToString(),
						" from substore ",
						LoginUser.SubstoreName
					}));
                }
                this.printerqueueid = new List<string>();
                MessageBox.Show("Images sent to re-print succesfully");
                this.HideHandlerDialog();
            }
            else
            {
                MessageBox.Show("Please select any image to Re-Print");
            }
        }

        private void IsChecked_Checked(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_12;
            }
        IL_04:
            if (6 == 0)
            {
                goto IL_25;
            }
            CheckBox expr_09 = (CheckBox)sender;
            CheckBox checkBox;
            if (!false)
            {
                checkBox = expr_09;
            }
        IL_12:
            if (3 != 0)
            {
                this.printerqueueid.Add(checkBox.CommandParameter.ToString());
            }
        IL_25:
            if (!false)
            {
                return;
            }
            goto IL_04;
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                if (8 != 0)
                {
                    this.txtOrderno.Text = "";
                    if (!false)
                    {
                        this.txtOrderno.Focus();
                    }
                }
                if (!false)
                {
                    this.dgReprint.Visibility = Visibility.Collapsed;
                }
            }
            while (false);
        }

        private void txtOrderno_GotFocus(object sender, RoutedEventArgs e)
        {
            this.btnSearchReprint.IsDefault = true;
        }

        private void txtOrderno_LostFocus(object sender, RoutedEventArgs e)
        {
            this.btnSearchReprint.IsDefault = false;
        }

       void IStyleConnector.Connect(int connectionId, object target)
        {
            while (true)
            {
                if (8 == 0)
                {
                    goto IL_15;
                }
                int arg_0E_0 = connectionId;
                if (8 != 0)
                {
                    arg_0E_0 = connectionId;
                }
                if (arg_0E_0 == 5 || false)
                {
                    goto IL_15;
                }
            IL_2E:
                if (!false)
                {
                    break;
                }
                continue;
            IL_15:
                ((CheckBox)target).Checked += new RoutedEventHandler(this.IsChecked_Checked);
                goto IL_2E;
            }
        }
    }
}
