using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Manage;
using DigiPhoto.Utility.Repository.Data;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using PhotoSW.ViewModels;

using PhotoSW.Views;
//using DigiPhoto.IMIX.Model;

namespace PhotoSW.Orders
{
    public partial class OrderRefund : Window, IComponentConnector, IStyleConnector
    {
        private ReportDocument report = new ReportDocument();

        private List<PhotosDetails> _objPhotoList;

        private List<OrderDetails> _objOrderList;

        private List<CheckedItems> _objSelectedItems;

        private decimal? discountOnTotal = new decimal?(0m);

        private int _lineitemId;

        private int _orderId;

        private TextBox controlon;

        private bool isEnableSlipPrint = true;

        private List<AlreadyrefundInfo> _alreadyRefunded;

        

        public string DefaultCurrency
        {
            get;
            set;
        }

        public double _NetAmount
        {
            get;
            set;
        }

        public double _TotalAmount
        {
            get;
            set;
        }

        public double _TotalDiscount
        {
            get;
            set;
        }

        public double _RefundAmount
        {
            get;
            set;
        }

        public OrderRefund()
        {
            this.InitializeComponent();
            this.GetDefaultCurrency();
            RobotImageLoader.GetConfigData();
            this.clear();
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
            this.dgOrderList.Visibility = Visibility.Collapsed;
            List<iMIXConfigurationInfo> newConfigValues = new ConfigBusiness().GetNewConfigValues(LoginUser.SubStoreId);
            foreach (iMIXConfigurationInfo current in newConfigValues)
            {
                long iMIXConfigurationMasterId = current.IMIXConfigurationMasterId;
                if (iMIXConfigurationMasterId == 79L)
                {
                    this.isEnableSlipPrint = (string.IsNullOrWhiteSpace(current.ConfigurationValue) || Convert.ToBoolean(current.ConfigurationValue));
                }
            }
        }

        private void GetDefaultCurrency()
        {
            string defaultCurrency;
            if (7 != 0 && !false)
            {
                string expr_7A = (from objcurrency in new CurrencyBusiness().GetCurrencyList().Where(delegate(CurrencyInfo objcurrency)
                {
                    bool? dG_Currency_Default = objcurrency.DG_Currency_Default;
                    int arg_42_0;
                    if (!dG_Currency_Default.GetValueOrDefault())
                    {
                        arg_42_0 = 0;
                        goto IL_16;
                    }
                    arg_42_0 = (dG_Currency_Default.HasValue ? 1 : 0);
                IL_10:
                    if (!false)
                    {
                    }
                IL_16:
                    bool expr_45;
                    do
                    {
                        bool flag = arg_42_0 != 0;
                        if (!false)
                        {
                        }
                        expr_45 = ((arg_42_0 = (flag ? 1 : 0)) != 0);
                    }
                    while (8 == 0);
                    if (!false)
                    {
                        return expr_45;
                    }
                    goto IL_10;
                })
                                  select objcurrency.DG_Currency_Symbol.ToString()).FirstOrDefault<string>();
                if (!false)
                {
                    defaultCurrency = expr_7A;
                }
            }
            this.DefaultCurrency = defaultCurrency;
        }

        private void btnSubmitRefund(object sender, RoutedEventArgs e)
        {
            this.GrdPrint.Visibility = Visibility.Hidden;
            string text = string.Empty;
            ValueTypeInfo valueTypeInfo;
            bool flag;
            if (!false)
            {
                valueTypeInfo = (ValueTypeInfo)this.CmbReasonType.SelectedItem;
                bool arg_4D_0 = valueTypeInfo.Name == "Others";
                int arg_4D_1 = 0;
                int expr_122;
                int expr_128;
                while (true)
                {
                    flag = ((arg_4D_0 ? 1 : 0) == arg_4D_1);
                    if (!flag)
                    {
                        break;
                    }
                    flag = !string.IsNullOrWhiteSpace(this.txtreason.Text.Trim());
                    if (!flag)
                    {
                        text = valueTypeInfo.Name;
                    }
                    else
                    {
                        text = valueTypeInfo.Name + "-" + this.txtreason.Text.Trim();
                    }
                    flag = !string.IsNullOrWhiteSpace(text);
                    if (!flag)
                    {
                        goto Block_5;
                    }
                    expr_122 = ((arg_4D_0 = (valueTypeInfo.Name == "--Select--")) ? 1 : 0);
                    expr_128 = (arg_4D_1 = 0);
                    if (expr_128 == 0)
                    {
                        goto Block_6;
                    }
                }
                flag = !string.IsNullOrWhiteSpace(this.txtreason.Text.Trim());
                goto IL_70;
            Block_5:
                MessageBox.Show("Please select reason for refund.");
                return;
            Block_6:
                flag = (expr_122 == expr_128);
                if (!flag)
                {
                    MessageBox.Show("Please select reason for refund.");
                    return;
                }
                goto Block_8;
            }
        IL_70:
            if (!flag)
            {
                MessageBox.Show("Please enter the comment.");
                return;
            }
            text = valueTypeInfo.Name + "-" + this.txtreason.Text.Trim();
        Block_8:
            try
            {
                flag = (this.dgOrderList.Items.Count <= 0);
                if (!flag)
                {
                    this.GrdPrinting.Visibility = Visibility.Collapsed;
                    RefundBusiness refundBusiness = new RefundBusiness();
                    int dG_RefundMaster_ID = refundBusiness.SetRefundMasterData(this._orderId, this._RefundAmount.ToDecimal(false), new CustomBusineses().ServerDateTime(), LoginUser.UserId);
                    using (List<CheckedItems>.Enumerator enumerator = this._objSelectedItems.GetEnumerator())
                    {
                        while (true)
                        {
                            flag = enumerator.MoveNext();
                            if (!flag)
                            {
                                break;
                            }
                            CheckedItems current = enumerator.Current;
                            refundBusiness.SetRefundDetailsData(current.LineItemId, dG_RefundMaster_ID, current.SelectetdItems.ToString(), current.RefundPrice, text);
                        }
                    }
                    int arg_279_0 = LoginUser.UserId;
                    int arg_279_1 = 40;
                    string[] array = new string[8];
                    do
                    {
                        array[0] = "Reason For Refund :";
                    }
                    while (8 == 0);
                    array[1] = text;
                    array[2] = "Refund Order ";
                    array[3] = this.txtSearchOrderNO.Text;
                    array[4] = " and Total Refunded Amount is ";
                    array[5] = new CurrencyBusiness().GetDefaultCurrencyName();
                    array[6] = " ";
                    array[7] = this._RefundAmount.ToDecimal(false).ToString();
                    AuditLog.AddUserLog(arg_279_0, arg_279_1, string.Concat(array));
                    MessageBox.Show("Refund successfully.");
                    this.dgOrderList.ItemsSource = null;
                    this.dgOrderList.Visibility = Visibility.Collapsed;
                    this.txtreason.Clear();
                    while (true)
                    {
                        this.lstItems.ItemsSource = null;
                        while (true)
                        {
                            this.clear();
                            this._objSelectedItems = new List<CheckedItems>();
                            flag = !this.isEnableSlipPrint;
                            if (!flag)
                            {
                                this.refundReceipt(LoginUser.SubstoreName.ToString(), LoginUser.UserName.ToString(), text, this.txtSearchOrderNO.Text);
                                if (false)
                                {
                                    break;
                                }
                            }
                            if (!false)
                            {
                                goto Block_13;
                            }
                        }
                    }
                Block_13: ;
                }
                else
                {
                    MessageBox.Show("No item for refund.");
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        public void refundReceipt(string storeName, string operatorName, string refundReassonReason, string searchOrderNo)
        {
            try
            {
                new StoreInfo();
               TaxBusiness taxBusiness = new TaxBusiness();
                StoreInfo taxConfigData = taxBusiness.getTaxConfigData();
                this.InitializeComponent();
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                this.report.Load(baseDirectory + "\\Reports\\RefundOrder.rpt");
                TextObject textObject = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["Txtstorename"];
                textObject.Text = storeName;
                TextObject textObject2 = (TextObject)this.report.ReportDefinition.Sections["Section3"].ReportObjects["txtOperator"];
                textObject2.Text = operatorName;
                TextObject textObject3 = (TextObject)this.report.ReportDefinition.Sections["DetailSection1"].ReportObjects["txtRefundReason"];
                textObject3.Text = refundReassonReason;
                TextObject textObject4 = (TextObject)this.report.ReportDefinition.Sections["DetailSection1"].ReportObjects["txtOrdersNo"];
                textObject4.Text = searchOrderNo;
                TextObject textObject5 = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtAddress"];
                textObject5.Text = (taxConfigData.Address.Replace("\n", " ").Replace("\r", "") ?? "");
                TextObject textObject6 = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtReceiptTitle"];
                textObject6.Text = taxConfigData.BillReceiptTitle;
                TextObject textObject7 = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtPhone"];
                textObject7.Text = "Phone: " + taxConfigData.PhoneNo;
                TextObject textObject8 = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtEmail"];
                textObject8.Text = "Email: " + taxConfigData.EmailID;
                TextObject textObject9 = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtUrl"];
                textObject9.Text = taxConfigData.WebsiteURL;
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("StoreName", typeof(string));
                dataTable.Columns.Add("Operator", typeof(string));
                dataTable.Columns.Add("Reason", typeof(string));
                dataTable.Columns.Add("OrderNos", typeof(string));
                dataTable.Rows.Add(new object[]
				{
					textObject,
					operatorName,
					refundReassonReason
				});
                this.report.SetDataSource(dataTable);
                this.report.Refresh();
                this.report.PrintOptions.PrinterName = LoginUser.ReceiptPrinterPath;
                string digiFolderPath = LoginUser.DigiFolderPath;
                string text = Path.Combine(digiFolderPath, "OrderReceipt\\" + DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                string text2 = searchOrderNo + "_Refund.pdf";
                this.report.ExportToDisk(ExportFormatType.PortableDocFormat, text2);
                string text3 = Environment.CurrentDirectory + "\\" + text2;
                if (File.Exists(text3))
                {
                    File.Move(text3, text + "\\" + text2);
                }
                this.report.ExportToDisk(ExportFormatType.PortableDocFormat, "refundslippp.pdf");
                this.report.PrintToPrinter(1, true, 1, 1);
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void CmbReasonType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtreason.IsEnabled = true;
        }

        private void CmbReasonTyped_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtboxreason.IsEnabled = true;
        }

        private void btn_Click2(object sender, RoutedEventArgs e)
        {
            new Button();
            if (!false)
            {
                Button button = (Button)sender;
                int arg_153_0;
                if (!false)
                {
                    string text = button.Content.ToString();
                    if (text != null)
                    {
                        bool arg_4F_0 = text == "ENTER";
                        while (!arg_4F_0)
                        {
                            int arg_127_0;
                            int arg_135_0;
                            if (!(text == "SPACE"))
                            {
                                bool expr_64 = arg_4F_0 = (text == "CLOSE");
                                if (!true)
                                {
                                    continue;
                                }
                                if (!expr_64)
                                {
                                    if (!(text == "Back"))
                                    {
                                        goto IL_19D;
                                    }
                                    TextBox textBox = this.controlon;
                                    arg_127_0 = this.controlon.Text.Length;
                                }
                                else
                                {
                                    this.KeyBorderOrder.Visibility = Visibility.Collapsed;
                                    if (2 != 0)
                                    {
                                        return;
                                    }
                                    goto IL_19D;
                                }
                            }
                            else
                            {
                                this.controlon.Text = this.controlon.Text + " ";
                                arg_135_0 = (this.controlon.Focus() ? 1 : 0);
                                if (!false)
                                {
                                    return;
                                }
                                goto IL_134;
                            }
                        IL_126:
                            bool arg_141_0;
                            if (arg_127_0 <= 0)
                            {
                                arg_141_0 = ((arg_127_0 = 1) != 0);
                                goto IL_13D;
                            }
                            arg_135_0 = this.controlon.SelectionStart;
                        IL_134:
                            arg_141_0 = ((arg_127_0 = ((arg_135_0 <= 0) ? 1 : 0)) != 0);
                        IL_13D:
                            if (false)
                            {
                                goto IL_126;
                            }
                            if (!arg_141_0)
                            {
                                arg_153_0 = this.controlon.SelectionStart;
                                goto IL_153;
                            }
                            goto IL_18F;
                        }
                        this.controlon.Text = this.controlon.Text + Environment.NewLine;
                        goto IL_A7;
                    }
                IL_19D:
                    this.controlon.Text = this.controlon.Text + button.Content;
                    this.controlon.SelectionStart = this.controlon.Text.Length;
                    goto IL_1DB;
                }
            IL_A7:
                arg_153_0 = (this.controlon.Focus() ? 1 : 0);
                if (!false)
                {
                    return;
                }
            IL_153:
                int num = arg_153_0;
                this.controlon.Text = this.controlon.Text.Remove(this.controlon.SelectionStart - 1, 1);
                this.controlon.Select(num - 1, 0);
            IL_18F:
                this.controlon.Focus();
                return;
            }
        IL_1DB:
            this.controlon.Focus();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            int num;
            while (6 != 0)
            {
                if (!false)
                {
                    Button expr_12 = (Button)sender;
                    Button button;
                    if (!false)
                    {
                        button = expr_12;
                    }
                    string expr_1F7 = button.Content.ToString();
                    string text;
                    if (!false)
                    {
                        text = expr_1F7;
                    }
                    if (text != null)
                    {
                        if (text == "ENTER")
                        {
                            this.controlon.Text = this.controlon.Text + Environment.NewLine;
                            this.controlon.Focus();
                            return;
                        }
                        bool arg_77_0;
                        bool expr_55 = arg_77_0 = (text == "SPACE");
                        if (!false)
                        {
                            if (expr_55)
                            {
                                this.controlon.Text = this.controlon.Text + " ";
                                this.controlon.Focus();
                                return;
                            }
                            if (text == "CLOSE")
                            {
                                goto IL_E5;
                            }
                            arg_77_0 = (text == "Back");
                        }
                        if (arg_77_0)
                        {
                            if (!false)
                            {
                                TextBox textBox = this.controlon;
                                bool flag = this.controlon.Text.Length <= 0 || this.controlon.SelectionStart <= 0;
                                int arg_131_0 = flag ? 1 : 0;
                                while (arg_131_0 == 0)
                                {
                                    int expr_13A = arg_131_0 = this.controlon.SelectionStart;
                                    if (!false)
                                    {
                                        num = expr_13A;
                                        goto IL_143;
                                    }
                                }
                            IL_17E:
                                this.controlon.Focus();
                                return;
                            }
                            continue;
                        }
                    }
                    this.controlon.Text = this.controlon.Text + button.Content;
                    this.controlon.SelectionStart = this.controlon.Text.Length;
                    this.controlon.Focus();
                    return;
                }
            IL_E5:
                this.KeyBorder.Visibility = Visibility.Collapsed;
                return;
            }
        IL_143:
            this.controlon.Text = this.controlon.Text.Remove(this.controlon.SelectionStart - 1, 1);
            this.controlon.Select(num - 1, 0);
           // goto IL_17E;
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
                    this.KeyBorder.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void txtboxreason_GotFocus(object sender, RoutedEventArgs e)
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
                    this.KeyboxBorder1.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void btn_Click1(object sender, RoutedEventArgs e)
        {
            int num;
            while (6 != 0)
            {
                if (!false)
                {
                    Button expr_12 = (Button)sender;
                    Button button;
                    if (!false)
                    {
                        button = expr_12;
                    }
                    string expr_1F7 = button.Content.ToString();
                    string text;
                    if (!false)
                    {
                        text = expr_1F7;
                    }
                    if (text != null)
                    {
                        if (text == "ENTER")
                        {
                            this.controlon.Text = this.controlon.Text + Environment.NewLine;
                            this.controlon.Focus();
                            return;
                        }
                        bool arg_77_0;
                        bool expr_55 = arg_77_0 = (text == "SPACE");
                        if (!false)
                        {
                            if (expr_55)
                            {
                                this.controlon.Text = this.controlon.Text + " ";
                                this.controlon.Focus();
                                return;
                            }
                            if (text == "CLOSE")
                            {
                                goto IL_E5;
                            }
                            arg_77_0 = (text == "Back");
                        }
                        if (arg_77_0)
                        {
                            if (!false)
                            {
                                TextBox textBox = this.controlon;
                                bool flag = this.controlon.Text.Length <= 0 || this.controlon.SelectionStart <= 0;
                                int arg_131_0 = flag ? 1 : 0;
                                while (arg_131_0 == 0)
                                {
                                    int expr_13A = arg_131_0 = this.controlon.SelectionStart;
                                    if (!false)
                                    {
                                        num = expr_13A;
                                        goto IL_143;
                                    }
                                }
                            IL_17E:
                                this.controlon.Focus();
                                return;
                            }
                            continue;
                        }
                    }
                    this.controlon.Text = this.controlon.Text + button.Content;
                    this.controlon.SelectionStart = this.controlon.Text.Length;
                    this.controlon.Focus();
                    return;
                }
            IL_E5:
                this.KeyBorder.Visibility = Visibility.Collapsed;
                return;
            }
        IL_143:
            this.controlon.Text = this.controlon.Text.Remove(this.controlon.SelectionStart - 1, 1);
            this.controlon.Select(num - 1, 0);
            //goto IL_17E;
        }

        private void btnRefundOrder_Click(object sender, RoutedEventArgs e)
        {
            while (this.dgOrderList.Items.Count > 0)
            {
                if (5 != 0)
                {
                    while (!false)
                    {
                        this.GrdPrinting.Visibility = Visibility.Visible;
                        if (-1 == 0)
                        {
                            goto IL_15;
                        }
                        if (!false)
                        {
                            return;
                        }
                    }
                    continue;
                }
            }
        IL_15:
            if (!false)
            {
                MessageBox.Show("No item for refund.");
                return;
            }
        }

        private void btnClosing_Click(object sender, RoutedEventArgs e)
        {
            this.GrdPrinting.Visibility = Visibility.Hidden;
        }

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            this.GrdPrinting.Visibility = Visibility.Hidden;
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            base.Close();
            login.Show();
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                while (true)
                {
                    this.KeyBorderOrder.Visibility = Visibility.Collapsed;
                    this._alreadyRefunded = new List<AlreadyrefundInfo>();
                    this._objSelectedItems = new List<CheckedItems>();
                    this.lstItems.ItemsSource = null;
                    this.dgOrderList.Visibility = Visibility.Collapsed;
                    this.btnRefundOrder.IsEnabled = true;
                    while (true)
                    {
                        this.discountOnTotal = new decimal?(0m);
                        int arg_9A_0;
                        bool expr_78 = (arg_9A_0 = ((!this.GetMasterData()) ? 1 : 0)) != 0;
                        if (5 != 0)
                        {
                            if (expr_78)
                            {
                                goto IL_E4;
                            }
                            this.GetSearchedDetailData();
                            arg_9A_0 = this.dgOrderList.Items.Count;
                        }
                        bool flag = arg_9A_0 > 0;
                        if (false)
                        {
                            goto IL_E4;
                        }
                        if (flag)
                        {
                            //goto IL_CF;
                        }
                        MessageBox.Show("Please enter a valid order number.");
                        this.dgOrderList.Visibility = Visibility.Collapsed;
                        this.clear();
                        if (5 == 0)
                        {
                            break;
                        }
                        if (7 != 0)
                        {
                            goto Block_6;
                        }
                    }
                }
                do
                {
                IL_CF:
                    this.dgOrderList.Visibility = Visibility.Visible;
                }
                while (false);
            Block_6:
                goto IL_F6;
            IL_E4:
                do
                {
                    this.btnRefundOrder.IsEnabled = false;
                }
                while (6 == 0);
            IL_F6: ;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void btnRefund_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new Button();
                Button button = (Button)sender;
                this.lstItems.ItemsSource = null;
                this._objPhotoList = new List<PhotosDetails>();
                this._lineitemId = button.CommandParameter.ToInt32(false);
                this.dgOrderList.ItemsSource = null;
                this.dgOrderList.ItemsSource = this._objOrderList;
                OrderDetails _objitem = (from t in this._objOrderList
                                         where t.DG_LineItemId == this._lineitemId
                                         select t).FirstOrDefault<OrderDetails>();
                if (_objitem.IsBundled)
                {
                    int i = 1;
                    int loopquantity = _objitem.loopquantity;
                    while (i <= loopquantity)
                    {
                        string[] array = _objitem.PhotoIds.Split(new char[]
						{
							','
						});
                        int j = 0;
                        if (j < array.Length)
                        {
                            PhotosDetails photosDetails;
                            IEnumerable<AlreadyrefundInfo> source;
                            string item;
                            if (8 != 0)
                            {
                                item = array[j];
                                photosDetails = new PhotosDetails();
                                PhotoInfo photoInfo = new PhotoBusiness().GetPhotoRFIDByPhotoID((long)item.ToInt32(false));
                                photosDetails.PhotoName = photoInfo.DG_Photos_RFID;
                                photosDetails.PhotoId = Convert.ToString(item);
                                photosDetails.ImageVisibility = Visibility.Collapsed;
                                photosDetails.OtherVisibility = Visibility.Visible;
                                photosDetails.AmountRefunded = _objitem.DG_LineItem_RefundPrice;
                                photosDetails.FilePath = Path.Combine(photoInfo.HotFolderPath, "Thumbnails", photoInfo.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photosDetails.PhotoName + ".jpg");
                                source = this._alreadyRefunded.Where(delegate(AlreadyrefundInfo result)
                                {
                                    int arg_2C_0 = result.Photo;
                                    string arg_7D_0;
                                    if (!(item == ""))
                                    {
                                        arg_7D_0 = item;
                                        goto IL_28;
                                    }
                                IL_23:
                                    arg_7D_0 = "0";
                                IL_28:
                                    int arg_4C_0;
                                    if (arg_2C_0 == arg_7D_0.ToInt32(false))
                                    {
                                        arg_4C_0 = (arg_2C_0 = ((result.LineItemId == _objitem.DG_LineItemId) ? 1 : 0));
                                    }
                                    else
                                    {
                                        arg_4C_0 = (arg_2C_0 = 0);
                                    }
                                IL_45:
                                    if (false)
                                    {
                                        goto IL_23;
                                    }
                                    bool flag = arg_4C_0 != 0;
                                    if (5 != 0)
                                    {
                                    }
                                    bool expr_52 = (arg_2C_0 = (arg_4C_0 = (flag ? 1 : 0))) != 0;
                                    if (!false)
                                    {
                                        return expr_52;
                                    }
                                    goto IL_45;
                                });
                            }
                            if (item != null)
                            {
                                if (item.Count<char>() > 0)
                                {
                                    if (i <= source.Count<AlreadyrefundInfo>())
                                    {
                                        photosDetails.ischekd = true;
                                    }
                                }
                            }
                            this._objPhotoList.Add(photosDetails);
                        }
                        i++;
                    }
                }
                else
                {
                    long? num = _objitem.DG_Orders_LineItems_Quantity / (long)_objitem.PhotoIds.Split(new char[]
					{
						','
					}).Count<string>();
                    string[] array2 = _objitem.PhotoIds.Split(new char[]
					{
						','
					});
                    int num2 = 1;
                    while ((long)num2 <= num)
                    {
                        string[] array = array2;
                        for (int j = 0; j < array.Length; j++)
                        {
                            string phid = array[j];
                            PhotosDetails photosDetails = new PhotosDetails();
                            photosDetails.PhotoName = _objitem.DG_Orders_ProductType_Name + "-" + num2.ToString();
                            photosDetails.PhotoId = phid;
                            photosDetails.AmountRefunded = _objitem.DG_LineItem_RefundPrice;
                            List<ProductTypeInfo> productType = new ProductBusiness().GetProductType();
                            ProductTypeInfo productTypeInfo = productType.Where(delegate(ProductTypeInfo t)
                            {
                                if (false)
                                {
                                    goto IL_2F;
                                }
                                int dG_Orders_ProductType_pkey;
                                if (!false)
                                {
                                    dG_Orders_ProductType_pkey = t.DG_Orders_ProductType_pkey;
                                }
                                if (7 == 0)
                                {
                                    goto IL_2D;
                                }
                                int? expr_44 = _objitem.DG_ProductTypeId;
                                int? num3;
                                if (6 != 0)
                                {
                                    num3 = expr_44;
                                }
                                int arg_2C_0;
                                if (dG_Orders_ProductType_pkey == num3.GetValueOrDefault())
                                {
                                    arg_2C_0 = (num3.HasValue ? 1 : 0);
                                }
                                else
                                {
                                    arg_2C_0 = 0;
                                }
                            IL_28:
                                bool flag = arg_2C_0 != 0;
                            IL_2D:
                            IL_2F:
                                bool expr_2F = (arg_2C_0 = (flag ? 1 : 0)) != 0;
                                if (!false)
                                {
                                    return expr_2F;
                                }
                                goto IL_28;
                            }).FirstOrDefault<ProductTypeInfo>();
                            if (productTypeInfo != null)
                            {
                                PhotoInfo photoInfo = new PhotoBusiness().GetPhotoNameByPhotoID((long)phid.ToInt32(false));
                                if (photoInfo != null)
                                {
                                    photosDetails.FilePath = Path.Combine(photoInfo.HotFolderPath, "Thumbnails", photoInfo.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoInfo.DG_Photos_FileName);
                                }
                            }
                            IEnumerable<AlreadyrefundInfo> enumerable = this._alreadyRefunded.Where(delegate(AlreadyrefundInfo result)
                            {
                                int arg_2C_0 = result.Photo;
                                string arg_7D_0;
                                if (!(phid == ""))
                                {
                                    arg_7D_0 = phid;
                                    goto IL_28;
                                }
                            IL_23:
                                arg_7D_0 = "0";
                            IL_28:
                                int arg_4C_0;
                                if (arg_2C_0 == arg_7D_0.ToInt32(false))
                                {
                                    arg_4C_0 = (arg_2C_0 = ((result.LineItemId == _objitem.DG_LineItemId) ? 1 : 0));
                                }
                                else
                                {
                                    arg_4C_0 = (arg_2C_0 = 0);
                                }
                            IL_45:
                                if (false)
                                {
                                    goto IL_23;
                                }
                                bool flag = arg_4C_0 != 0;
                                if (5 != 0)
                                {
                                }
                                bool expr_52 = (arg_2C_0 = (arg_4C_0 = (flag ? 1 : 0))) != 0;
                                if (!false)
                                {
                                    return expr_52;
                                }
                                goto IL_45;
                            });
                            if (enumerable != null)
                            {
                                if (enumerable.Count<AlreadyrefundInfo>() > 0)
                                {
                                    if (num2 <= enumerable.Count<AlreadyrefundInfo>())
                                    {
                                        photosDetails.ischekd = true;
                                    }
                                }
                            }
                            photosDetails.ImageVisibility = Visibility.Visible;
                            photosDetails.OtherVisibility = Visibility.Visible;
                            this._objPhotoList.Add(photosDetails);
                        }
                        num2++;
                    }
                }
                this.lstItems.ItemsSource = this._objPhotoList;
                this.GrdPrint.Visibility = Visibility.Visible;
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.GrdPrint.Visibility = Visibility.Collapsed;
        }

        private void btnsubmit_Click(object sender, RoutedEventArgs e)
        {
            this.GrdPrint.Visibility = Visibility.Collapsed;
        }

        private void chkImageName_Checked(object sender, RoutedEventArgs e)
        {
            Func<OrderDetails, bool> expr_00 = null;
            if (4 != 0)
            {
                Func<OrderDetails, bool> predicate = expr_00;
            }
            while (true)
            {
                try
                {
                    CheckBox checkBox = (CheckBox)sender;
                    IEnumerable<OrderDetails> arg_1FE_0 = this._objOrderList;
                    Func<OrderDetails, bool> predicate = (OrderDetails t) => t.DG_LineItemId == this._lineitemId;
                    OrderDetails orderDetails = arg_1FE_0.Where(predicate).FirstOrDefault<OrderDetails>();
                    orderDetails.DG_Refund_Quantity++;
                    orderDetails.DG_Refund_Amount += checkBox.Tag.ToDecimal(false);
                    this.dgOrderList.ItemsSource = null;
                    if (true)
                    {
                        this.dgOrderList.ItemsSource = this._objOrderList;
                        this._RefundAmount += checkBox.Tag.ToDouble(false);
                    }
                    this.txtTotalRefund.Text = this._RefundAmount.ToString();
                    this.txtTotalRefund.Text = decimal.Round(this.txtTotalRefund.Text.ToDecimal(false), 2, MidpointRounding.ToEven).ToString();
                    CheckedItems checkedItems = new CheckedItems();
                    checkedItems.LineItemId = this._lineitemId;
                    checkedItems.RefundPrice = new decimal?(checkBox.Tag.ToDecimal(false));
                    checkedItems.SelectetdItems = Convert.ToString(checkBox.CommandParameter);
                    this._objSelectedItems.Add(checkedItems);
                    AlreadyrefundInfo alreadyrefundInfo = new AlreadyrefundInfo();
                    alreadyrefundInfo.LineItemId = this._lineitemId;
                    if (string.IsNullOrEmpty(checkBox.CommandParameter.ToString()))
                    {
                        alreadyrefundInfo.Photo = 0;
                    }
                    else
                    {
                        alreadyrefundInfo.Photo = checkBox.CommandParameter.ToInt32(false);
                    }
                    this._alreadyRefunded.Add(alreadyrefundInfo);
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (!false)
                {
                    if (!false)
                    {
                        return;
                    }
                }
            }
        }

        private void chkImageName_Unchecked(object sender, RoutedEventArgs e)
        {
            if (-1 == 0)
            {
                goto IL_2A2;
            }
        IL_0C:
            try
            {
                CheckBox objchk = (CheckBox)sender;
                if (false)
                {
                    goto IL_1B2;
                }
                OrderDetails orderDetails = (from t in this._objOrderList
                                             where t.DG_LineItemId == this._lineitemId
                                             select t).FirstOrDefault<OrderDetails>();
                bool arg_79_0 = orderDetails.DG_Refund_Quantity > 0;
                bool expr_BA;
                do
                {
                    if (arg_79_0)
                    {
                        orderDetails.DG_Refund_Quantity--;
                    }
                    expr_BA = (arg_79_0 = !(orderDetails.DG_Refund_Amount > 0m));
                }
                while (false);
                bool flag = expr_BA;
            IL_C1:
                while (!flag)
                {
                    if (true)
                    {
                        orderDetails.DG_Refund_Amount -= objchk.Tag.ToDecimal(false);
                        break;
                    }
                }
                this.dgOrderList.ItemsSource = null;
                if (false)
                {
                    goto IL_212;
                }
                this.dgOrderList.ItemsSource = this._objOrderList;
                if (this._RefundAmount.ToDecimal(false) > 0m)
                {
                    this._RefundAmount = (double)(this._RefundAmount.ToDecimal(false) - objchk.Tag.ToDecimal(false));
                    this.txtTotalRefund.Text = this.DefaultCurrency + " " + this._RefundAmount;
                }
            IL_1B2:
                this.txtTotalRefund.Text = this.DefaultCurrency + " " + decimal.Round(this._RefundAmount.ToDecimal(false), 2, MidpointRounding.AwayFromZero).ToString();
                CheckedItems checkedItems = this._objSelectedItems.Where(delegate(CheckedItems t)
                {
                    if (false)
                    {
                        goto IL_33;
                    }
                    int arg_30_0;
                    if (false || t.LineItemId == this._lineitemId)
                    {
                        arg_30_0 = ((t.SelectetdItems == objchk.CommandParameter.ToString()) ? 1 : 0);
                        if (2 != 0)
                        {
                        }
                    }
                    else
                    {
                        arg_30_0 = 0;
                    }
                IL_2F:
                    bool flag2 = arg_30_0 != 0;
                IL_33:
                    bool expr_33 = (arg_30_0 = (flag2 ? 1 : 0)) != 0;
                    if (!false)
                    {
                        return expr_33;
                    }
                    goto IL_2F;
                }).FirstOrDefault<CheckedItems>();
                if (checkedItems == null)
                {
                    goto IL_220;
                }
            IL_212:
                this._objSelectedItems.Remove(checkedItems);
            IL_220:
                AlreadyrefundInfo alreadyrefundInfo = this._alreadyRefunded.Where(delegate(AlreadyrefundInfo result)
                {
                    bool result2;
                    while (true)
                    {
                        int arg_19_0 = result.LineItemId;
                        int arg_75_0;
                        int expr_9C;
                        while (true)
                        {
                        IL_0A:
                            int arg_19_1 = this._lineitemId;
                            while (arg_19_0 == arg_19_1)
                            {
                                expr_9C = (arg_19_0 = (arg_75_0 = result.Photo));
                                bool expr_C0 = (arg_19_1 = ((Convert.ToString(objchk.CommandParameter) == "") ? 1 : 0)) != 0;
                                if (!false)
                                {
                                    if (!expr_C0)
                                    {
                                        goto Block_2;
                                    }
                                    if (false)
                                    {
                                        goto IL_6E;
                                    }
                                    if (!false)
                                    {
                                        goto Block_4;
                                    }
                                    goto IL_0A;
                                }
                            }
                            goto IL_70;
                        }
                    IL_76:
                        if (4 != 0)
                        {
                            break;
                        }
                        continue;
                    IL_70:
                        if (-1 == 0)
                        {
                            goto IL_76;
                        }
                        arg_75_0 = 0;
                    IL_74:
                        result2 = (arg_75_0 != 0);
                        goto IL_76;
                    IL_6E:
                        goto IL_74;
                    IL_65:
                        string arg_67_0;
                        arg_75_0 = ((expr_9C == arg_67_0.ToInt32(false)) ? 1 : 0);
                        goto IL_6E;
                    Block_2:
                        arg_67_0 = Convert.ToString(objchk.CommandParameter);
                        goto IL_65;
                    Block_4:
                        arg_67_0 = "0";
                        goto IL_65;
                    }
                    return result2;
                }).FirstOrDefault<AlreadyrefundInfo>();
                flag = (alreadyrefundInfo == null);
                if (!flag)
                {
                    this._alreadyRefunded.Remove(alreadyrefundInfo);
                }
                if (false)
                {
                    goto IL_C1;
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        IL_2A2:
            if (4 != 0)
            {
                return;
            }
            goto IL_0C;
        }

        public void clear()
        {
            if (!false)
            {
            }
            while (true)
            {
                this.txt_TotalDiscount.Text = this.DefaultCurrency + " 0.00";
                if (!false)
                {
                    while (!false)
                    {
                        this.txt_NetAmount.Text = this.DefaultCurrency + " 0.00";
                        if (7 == 0)
                        {
                            return;
                        }
                        if (!false)
                        {
                            goto Block_3;
                        }
                    }
                }
            }
        Block_3:
            this.txt_TotalAmount.Text = this.DefaultCurrency + " 0.00";
            this.txtTotalRefund.Text = this.DefaultCurrency + " 0.00";
        }

        public List<RefundInfo> GetRefundedItems(int orderId)
        {
            return new RefundBusiness().GetRefundedItems(orderId);
        }

        private void GetSearchedDetailData()
        {
            try
            {
                this._alreadyRefunded = new List<AlreadyrefundInfo>();
                this._objOrderList = new List<OrderDetails>();
                string text = this.txtSearchOrderNO.Text.ToUpperInvariant();
                if (text.IndexOf("DG-", StringComparison.OrdinalIgnoreCase) < 0)
                {
                    text = "DG-" + text;
                }
                List<OrderDetailInfo> orderDetailsforRefund = new OrderBusiness().GetOrderDetailsforRefund(text);
                if (orderDetailsforRefund != null && orderDetailsforRefund.Count > 0)
                {
                    List<RefundInfo> refundedItems = this.GetRefundedItems(orderDetailsforRefund[0].DG_Orders_ID.Value);
                    this._objSelectedItems = new List<CheckedItems>();
                    foreach (RefundInfo current in refundedItems)
                    {
                        AlreadyrefundInfo alreadyrefundInfo = new AlreadyrefundInfo();
                        alreadyrefundInfo.LineItemId = current.DG_LineItemId;
                        alreadyrefundInfo.Photo = current.RefundPhotoId;
                        this._alreadyRefunded.Add(alreadyrefundInfo);
                        CheckedItems checkedItems = new CheckedItems();
                        checkedItems.LineItemId = this._lineitemId;
                        checkedItems.SelectetdItems = Convert.ToString(current.RefundPhotoId);
                        this._objSelectedItems.Add(checkedItems);
                    }
                    decimal? num = new decimal?(0m);
                    foreach (OrderDetailInfo current2 in orderDetailsforRefund)
                    {
                        num += current2.DG_Orders_LineItems_DiscountAmount;
                        num = new decimal?(decimal.Round(num.ToDecimal(false), 4, MidpointRounding.AwayFromZero));
                    }
                    if (this._TotalDiscount.ToDecimal(false) > 0m)
                    {
                        this.discountOnTotal = this._TotalDiscount.ToDecimal(false) - num;
                        this.discountOnTotal = new decimal?(decimal.Round(this.discountOnTotal.ToDecimal(false), 4, MidpointRounding.AwayFromZero));
                    }
                    using (List<OrderDetailInfo>.Enumerator enumerator2 = orderDetailsforRefund.GetEnumerator())
                    {
                        while (enumerator2.MoveNext())
                        {
                            OrderDetailInfo item = enumerator2.Current;
                            decimal? num2 = (this._TotalAmount > 0.0) ? (item.DG_Orders_Details_Items_UniPrice * 100m / this._TotalAmount.ToDecimal(false)) : new decimal?(0m);
                            decimal? num3;
                            if (this.discountOnTotal == 0m)
                            {
                                num3 = new decimal?(0m);
                            }
                            else
                            {
                                num3 = num2 * ((this.discountOnTotal == 0m) ? new decimal?(1m) : this.discountOnTotal) / 100m;
                            }
                            OrderDetails orderDetails = new OrderDetails();
                            orderDetails.DG_LineItemId = item.DG_Orders_LineItems_pkey;
                            orderDetails.DG_Orders_Details_Items_TotalCost = item.DG_Orders_Details_Items_UniPrice * item.TotalQuantity;
                            orderDetails.DG_Orders_LineItems_DiscountAmount = new decimal?(item.LineItemshare);
                            orderDetails.DG_ProductTypeId = item.DG_Orders_Details_ProductType_pkey;
                            if (item.DG_Orders_ProductType_IsBundled)
                            {
                                goto IL_939;
                            }
                            if (num3 != 100m)
                            {
                                if (item.DG_IsPackage)
                                {
                                    OrderDetails arg_5BB_0 = orderDetails;
                                    decimal? dG_Orders_Details_Items_UniPrice = item.DG_Orders_Details_Items_UniPrice;
                                    decimal lineItemshare = item.LineItemshare;
                                    int? dG_Orders_LineItems_Quantity = item.DG_Orders_LineItems_Quantity;
                                    arg_5BB_0.DG_LineItem_RefundPrice = dG_Orders_Details_Items_UniPrice - (dG_Orders_LineItems_Quantity.HasValue ? new decimal?(lineItemshare / dG_Orders_LineItems_Quantity.GetValueOrDefault()) : null);
                                }
                                else
                                {
                                    orderDetails.DG_LineItem_RefundPrice = item.DG_Orders_Details_Items_UniPrice - (item.DG_Orders_LineItems_DiscountAmount.ToDecimal(false) / item.TotalQuantity + num3);
                                }
                            }
                            else if (item.DG_IsPackage)
                            {
                                if (item.DG_Orders_LineItems_DiscountAmount == 0m)
                                {
                                    orderDetails.DG_LineItem_RefundPrice = item.DG_Orders_Details_Items_UniPrice - this.discountOnTotal / item.TotalQuantity;
                                }
                                else
                                {
                                    orderDetails.DG_LineItem_RefundPrice = item.DG_Orders_Details_Items_UniPrice - item.DG_Orders_LineItems_DiscountAmount / item.TotalQuantity - this.discountOnTotal / item.TotalQuantity;
                                }
                            }
                            else
                            {
                                orderDetails.DG_LineItem_RefundPrice = item.DG_Orders_Details_Items_UniPrice - item.DG_Orders_LineItems_DiscountAmount / item.TotalQuantity;
                            }
                            orderDetails.DG_Orders_LineItems_Quantity = new long?(item.TotalQuantity);
                        IL_AF8:
                            orderDetails.DG_LineItem_RefundPrice = new decimal?(decimal.Round(orderDetails.DG_LineItem_RefundPrice.ToDecimal(false), 4, MidpointRounding.AwayFromZero));
                            orderDetails.DG_LineItemUnitPrice = item.DG_Orders_Details_Items_UniPrice;
                            orderDetails.DG_Orders_ProductType_Name = item.DG_Orders_ProductType_Name;
                            IEnumerable<AlreadyrefundInfo> enumerable = from Ritem in this._alreadyRefunded
                                                                        where Ritem.LineItemId == item.DG_Orders_LineItems_pkey
                                                                        select Ritem;
                            if (enumerable != null)
                            {
                                if (enumerable.Count<AlreadyrefundInfo>() > 0)
                                {
                                    orderDetails.DG_Refund_Amount = orderDetails.DG_LineItem_RefundPrice * ((enumerable.Count<AlreadyrefundInfo>() == 0) ? 1 : enumerable.Count<AlreadyrefundInfo>());
                                    orderDetails.DG_Refund_Quantity = enumerable.Count<AlreadyrefundInfo>();
                                }
                                else
                                {
                                    orderDetails.DG_Refund_Amount = new decimal?(0m);
                                    orderDetails.DG_Refund_Quantity = 0;
                                }
                            }
                            else
                            {
                                orderDetails.DG_Refund_Amount = new decimal?(0m);
                                orderDetails.DG_Refund_Quantity = 0;
                            }
                            orderDetails.PhotoIds = item.DG_Photos_ID;
                            orderDetails.IsBundled = item.DG_Orders_ProductType_IsBundled;
                            orderDetails.IsPackage = item.DG_IsPackage;
                            orderDetails.loopquantity = item.DG_Orders_LineItems_Quantity.Value;
                            bool arg_D64_0;
                            if (!(item.DG_Orders_Details_Items_TotalCost == 0m) || !(orderDetails.DG_Refund_Amount == 0m))
                            {
                                if (8 == 0)
                                {
                                    goto IL_939;
                                }
                                arg_D64_0 = (!(item.DG_Orders_Details_Items_TotalCost > 0m) || !(item.DG_Orders_Details_Items_TotalCost >= orderDetails.DG_Refund_Amount));
                            }
                            else
                            {
                                arg_D64_0 = false;
                            }
                            if (!arg_D64_0)
                            {
                                this._objOrderList.Add(orderDetails);
                            }
                            continue;
                        IL_939:
                            orderDetails.DG_Orders_LineItems_Quantity = new long?(item.TotalQuantity);
                            if (num3 != 100m)
                            {
                                orderDetails.DG_LineItem_RefundPrice = item.DG_Orders_Details_Items_UniPrice - (item.DG_Orders_LineItems_DiscountAmount / item.TotalQuantity + num3);
                            }
                            else
                            {
                                orderDetails.DG_LineItem_RefundPrice = item.DG_Orders_Details_Items_UniPrice - item.DG_Orders_LineItems_DiscountAmount / item.TotalQuantity;
                            }
                            goto IL_AF8;
                        }
                    }
                    this.dgOrderList.ItemsSource = this._objOrderList;
                }
                else
                {
                    this.dgOrderList.ItemsSource = null;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        public bool GetMasterData()
        {
            bool result;
            OrderInfo order;
            if (2 != 0)
            {
                string text = this.txtSearchOrderNO.Text.ToUpperInvariant();
                if (text.IndexOf("DG-", StringComparison.OrdinalIgnoreCase) < 0)
                {
                    if (5 == 0)
                    {
                        return result;
                    }
                    text = "DG-" + text;
                }
                order = new OrderBusiness().GetOrder(text);
            }
            double orderRefundedAmount = new RefundBusiness().GetOrderRefundedAmount(order.DG_Orders_pkey);
            if (order.DG_Orders_Number == null)
            {
                goto IL_366;
            }
            this.txt_NetAmount.Text = this.DefaultCurrency + " " + decimal.Round(order.DG_Orders_NetCost.ToDecimal(false), 2, MidpointRounding.ToEven).ToString();
            this._NetAmount = order.DG_Orders_NetCost.ToString().ToDouble(false);
            this.txt_TotalAmount.Text = this.DefaultCurrency + " " + order.DG_Orders_Cost.ToDouble(false).ToString(".00");
            this._TotalAmount = order.DG_Orders_Cost.ToString().ToDouble(false);
            this._TotalDiscount = order.DG_Orders_Total_Discount.ToString().ToDouble(false);
        IL_165:
            this.txt_TotalDiscount.Text = this.DefaultCurrency + " " + decimal.Round(order.DG_Orders_Total_Discount.ToDecimal(false), 2, MidpointRounding.ToEven).ToString();
            this.txtTotalRefund.Text = this.DefaultCurrency + " " + orderRefundedAmount.ToString("00.00");
            this._RefundAmount = orderRefundedAmount;
            this._orderId = order.DG_Orders_pkey;
            bool arg_230_0;
            if (this._RefundAmount > 0.0)
            {
                arg_230_0 = false;
                goto IL_22F;
            }
        IL_1EF:
            arg_230_0 = (this._TotalAmount != 0.0 || this._RefundAmount != 0.0 || this.GetRefundedItems(order.DG_Orders_pkey).Count<RefundInfo>() <= 0);
        IL_22F:
            if (!arg_230_0)
            {
                this.txt_NetAmount.Text = string.Concat(new string[]
				{
					this.DefaultCurrency,
					" ",
					decimal.Round(order.DG_Orders_NetCost.ToDecimal(false) - this._RefundAmount.ToDecimal(false), 2, MidpointRounding.ToEven).ToString(),
					" ( ",
					order.DG_Orders_NetCost.ToDouble(false).ToString(".00"),
					"-",
					this._RefundAmount.ToString(".00"),
					" (Refunded)) "
				});
                MessageBox.Show("This Order is already refunded , you need to cancel the order.");
                this.btnRefundOrder.IsEnabled = false;
            }
            else
            {
                this.btnRefundOrder.IsEnabled = true;
                if (false)
                {
                    goto IL_165;
                }
                if (3 == 0)
                {
                    goto IL_3AD;
                }
                this.txt_NetAmount.Text = this.DefaultCurrency + " " + order.DG_Orders_NetCost.ToDouble(false).ToString("0.00");
            }
        IL_366:
            if (order.DG_Orders_Canceled.HasValue)
            {
                bool? dG_Orders_Canceled = order.DG_Orders_Canceled;
                if (false)
                {
                    goto IL_1EF;
                }
                if (dG_Orders_Canceled.Value)
                {
                    MessageBox.Show("Sorry you can't cancel/refund as it is already cancelled.");
                    result = false;
                    return result;
                }
            }
        IL_3AD:
            result = true;
            return result;
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

        private void btnSubmitCanceling_Click(object sender, RoutedEventArgs e)
        {
            this.GrdPrintcancel.Visibility = Visibility.Collapsed;
        }

        private void btnClosed_Click(object sender, RoutedEventArgs e)
        {
            this.GrdPrintcancel.Visibility = Visibility.Collapsed;
        }

        private void btnRefundCancel_Click(object sender, RoutedEventArgs e)
        {
            while (this.dgOrderList.Items.Count > 0)
            {
                if (5 != 0)
                {
                    while (!false)
                    {
                        this.GrdPrintcancel.Visibility = Visibility.Visible;
                        if (-1 == 0)
                        {
                            goto IL_15;
                        }
                        if (!false)
                        {
                            return;
                        }
                    }
                    continue;
                }
            }
        IL_15:
            if (!false)
            {
                MessageBox.Show("No item for cancel.");
                return;
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            do
            {
                if (!false)
                {
                    try
                    {
                        if (7 != 0)
                        {
                            this.fillCombos();
                        }
                        this.txtSearchOrderNO.Focus();
                        while (!true)
                        {
                        }
                    }
                    catch (Exception ex)
                    {
                        if (!false)
                        {
                        }
                        throw ex;
                    }
                }
            }
            while (7 == 0);
        }

        private void fillCombos()
        {
            if (true)
            {
                List<string> list;
                do
                {
                    list = new List<string>();
                    if (6 == 0)
                    {
                        return;
                    }
                }
                while (!true);
                list.Add("--Select--");
                try
                {
                    List<ValueTypeInfo> reasonType = new ValueTypeBusiness().GetReasonType(3);
                    reasonType.Add(new ValueTypeInfo
                    {
                        Name = "Others",
                        ValueTypeId = -1
                    });
                    CommonUtility.BindComboWithSelect<ValueTypeInfo>(this.CmbReasonTyped, reasonType, "Name", "ValueTypeId", 0, ClientConstant.SelectString);
                    CommonUtility.BindCombo<ValueTypeInfo>(this.CmbReasonType, reasonType, "Name", "ValueTypeId");
                    if (!false)
                    {
                        this.CmbReasonTyped.SelectedIndex = 0;
                        this.CmbReasonType.SelectedIndex = 0;
                    }
                }
                catch (Exception serviceException)
                {
                    if (!false)
                    {
                    }
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                    if (!false)
                    {
                    }
                }
            }
        }

        private void btnSubmitCanceled_Click(object sender, RoutedEventArgs e)
        {
            string arg_2ED_0 = string.Empty;
            ValueTypeInfo valueTypeInfo = (ValueTypeInfo)this.CmbReasonTyped.SelectedItem;
            bool arg_39_0 = valueTypeInfo.Name == "Others";
            string text;
            bool expr_12D=false;
            bool expr_69;
            do
            {
                bool flag = !arg_39_0;
                bool arg_45_0 = flag;
                while (arg_45_0)
                {
                    if (string.IsNullOrWhiteSpace(this.txtboxreason.Text.TrimStart(new char[0]).TrimEnd(new char[0])))
                    {
                        text = valueTypeInfo.Name;
                    }
                    else
                    {
                        text = valueTypeInfo.Name + "-" + this.txtboxreason.Text.Trim();
                    }
                    expr_12D = (arg_45_0 = !string.IsNullOrWhiteSpace(text.TrimStart(new char[0]).TrimEnd(new char[0])));
                    if (!false)
                    {
                        goto Block_5;
                    }
                }
                expr_69 = (arg_39_0 = string.IsNullOrWhiteSpace(this.txtboxreason.Text.TrimStart(new char[0]).TrimEnd(new char[0])));
            }
            while (false);
            if (expr_69)
            {
                MessageBox.Show("Please enter the comment.");
                return;
            }
            text = valueTypeInfo.Name + "-" + this.txtboxreason.Text.Trim();
           // goto IL_177;
        Block_5:
            if (!expr_12D)
            {
                MessageBox.Show("Please select reason for cancel.");
                return;
            }
            if (valueTypeInfo.Name == "--Select--")
            {
                MessageBox.Show("Please select reason for cancel.");
                return;
            }
            try
            {
            IL_177:
                bool arg_1FE_0;
                int expr_189 = (arg_1FE_0 = (this.dgOrderList.Items.Count > 0)) ? 1 : 0;
                int arg_1FE_1;
                int expr_18C = arg_1FE_1 = 0;
                string text2="";
                if (expr_18C == 0)
                {
                    if (expr_189 != expr_18C)
                    {
                        if (!false)
                        {
                            text2 = this.txtSearchOrderNO.Text.ToUpperInvariant();
                            if (text2.IndexOf("DG-", StringComparison.OrdinalIgnoreCase) < 0)
                            {
                                text2 = "DG-" + text2;
                            }
                            if (!false)
                            {
                                this.GrdPrintcancel.Visibility = Visibility.Collapsed;
                                goto IL_1E7;
                            }
                            goto IL_24A;
                        }
                    }
                    MessageBox.Show("No item for cancel.");
                    goto IL_2D7;
                }
                goto IL_1FE;
            IL_1E7:
                MessageBoxResult messageBoxResult = MessageBox.Show("Are you sure you want to cancel this order.", "Spectra Photo", MessageBoxButton.YesNo);
                arg_1FE_0 = (messageBoxResult == MessageBoxResult.Yes);
                arg_1FE_1 = 0;
            IL_1FE:
                if ((arg_1FE_0 ? 1 : 0) == arg_1FE_1)
                {
                    goto IL_2C7;
                }
                new OrderBusiness().SetCancelOrder(text2, text);
                AuditLog.AddUserLog(LoginUser.UserId, 43, "Reason For cancel order :" + text + "Cancel Order " + this.txtSearchOrderNO.Text);
                MessageBox.Show("Your Order has been cancelled.");
            IL_24A:
                this.dgOrderList.ItemsSource = null;
                this.dgOrderList.Visibility = Visibility.Collapsed;
                this.txtboxreason.Clear();
                this.lstItems.ItemsSource = null;
                if (5 == 0)
                {
                    goto IL_1E7;
                }
                this.clear();
                this._objSelectedItems = new List<CheckedItems>();
                if (this.isEnableSlipPrint)
                {
                    this.CancelReceipt(LoginUser.SubstoreName.ToString(), LoginUser.UserName.ToString(), text, text2);
                    if (4 != 0)
                    {
                    }
                }
            IL_2C7:
            IL_2D7: ;
            }
            catch (Exception serviceException)
            {
                while (8 == 0)
                {
                }
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        public void CancelReceipt(string storeName, string operatorName, string cancelReason, string OrderNumber)
        {
            try
            {
                this.InitializeComponent();
                new StoreInfo();
                TaxBusiness taxBusiness = new  TaxBusiness();
                StoreInfo taxConfigData = taxBusiness.getTaxConfigData();
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                this.report.Load(baseDirectory + "\\Reports\\CancelReceipt.rpt");
                TextObject textObject = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["Txtstorename"];
                textObject.Text = storeName;
                TextObject textObject2 = (TextObject)this.report.ReportDefinition.Sections["Section3"].ReportObjects["txtOperator"];
                textObject2.Text = operatorName;
                TextObject textObject3 = (TextObject)this.report.ReportDefinition.Sections["DetailSection1"].ReportObjects["txtCancelReason"];
                textObject3.Text = cancelReason;
                TextObject textObject4 = (TextObject)this.report.ReportDefinition.Sections["DetailSection1"].ReportObjects["txtOrderNo"];
                textObject4.Text = OrderNumber;
                TextObject textObject5 = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtAddress"];
                textObject5.Text = (taxConfigData.Address.Replace("\n", " ").Replace("\r", "") ?? "");
                TextObject textObject6 = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtReceiptTitle"];
                textObject6.Text = taxConfigData.BillReceiptTitle;
                TextObject textObject7 = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtPhone"];
                textObject7.Text = "Phone: " + taxConfigData.PhoneNo;
                TextObject textObject8 = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtEmail"];
                textObject8.Text = "Email: " + taxConfigData.EmailID;
                TextObject textObject9 = (TextObject)this.report.ReportDefinition.Sections["Section1"].ReportObjects["txtUrl"];
                textObject9.Text = taxConfigData.WebsiteURL;
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("StoreName", typeof(string));
                dataTable.Columns.Add("Operator", typeof(string));
                dataTable.Columns.Add("Reason", typeof(string));
                dataTable.Columns.Add("OrderNumber", typeof(string));
                dataTable.Rows.Add(new object[]
				{
					textObject,
					operatorName,
					cancelReason
				});
                this.report.SetDataSource(dataTable);
                this.report.Refresh();
                this.report.PrintOptions.PrinterName = LoginUser.ReceiptPrinterPath;
                string digiFolderPath = LoginUser.DigiFolderPath;
                string text = Path.Combine(digiFolderPath, "OrderReceipt\\" + DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                string text2 = OrderNumber + "_Cancel.pdf";
                this.report.ExportToDisk(ExportFormatType.PortableDocFormat, text2);
                string text3 = Environment.CurrentDirectory + "\\" + text2;
                if (File.Exists(text3))
                {
                    File.Move(text3, text + "\\" + text2);
                }
                this.report.ExportToDisk(ExportFormatType.PortableDocFormat, "cancelslip.pdf");
                this.report.PrintToPrinter(1, true, 1, 1);
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void txtSearchOrderNO_LostFocus(object sender, RoutedEventArgs e)
        {
            this.btnSearch.IsDefault = false;
        }

        private void txtSearchOrderNO_GotFocus(object sender, RoutedEventArgs e)
        {
            if (-1 != 0 && 8 != 0)
            {
                if (true)
                {
                    if (7 == 0)
                    {
                        return;
                    }
                    this.controlon = (TextBox)sender;
                    this.btnSearch.IsDefault = true;
                }
            }
            this.KeyBorderOrder.Visibility = Visibility.Visible;
        }

        private void btnReprintOrder_Click(object sender, RoutedEventArgs e)
        {
        }

        void IStyleConnector.Connect(int connectionId, object target)
        {
            if (!false)
            {
            }
            while (true)
            {
                int arg_20_0 = connectionId;
                int arg_14_0 = connectionId;
                int arg_14_1;
                if (!false)
                {
                    arg_14_0 = connectionId;
                    arg_14_1 = 2;
                    goto IL_14;
                }
            IL_1B:
                int expr_1D = arg_14_1 = 9;
                if (expr_1D != 0)
                {
                    if (arg_20_0 == expr_1D)
                    {
                        goto IL_5D;
                    }
                    if (!false)
                    {
                        break;
                    }
                    continue;
                }
            IL_14:
                if (arg_14_0 != arg_14_1)
                {
                    arg_20_0 = connectionId;
                    arg_14_0 = connectionId;
                    goto IL_1B;
                }
                goto IL_27;
            }
            return;
        IL_27:
            ((CheckBox)target).Checked += new RoutedEventHandler(this.chkImageName_Checked);
            if (7 != 0)
            {
                ((CheckBox)target).Unchecked += new RoutedEventHandler(this.chkImageName_Unchecked);
                return;
            }
            return;
        IL_5D:
            ((Button)target).Click += new RoutedEventHandler(this.btnRefund_Click);
        }
    }
}
