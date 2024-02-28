using BurnMedia;
using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DigiPhoto;
using PhotoSW.Views;

namespace PhotoSW.Orders
{
    public partial class Payment : Window, IComponentConnector, IStyleConnector
    {
        private const string ClientName = "BurnMedia";

        public bool _issemiorder;

        private ObservableCollection<PaymentItem> _objPayment;

        private ObservableCollection<PaymentItem> _objCardPayment;

        private ObservableCollection<PaymentItem> _objRoomPayment;

        private ObservableCollection<PaymentItem> _objVoucherPayment;

        private ObservableCollection<PaymentItem> _objKVLPayment;

        private List<string> _lstPaymentMethod;

        private System.Windows.Controls.TextBox controlon;

        private List<CurrencyInfo> _lstCurrency;

        private double _totalBillAmount;

        private double _totalCardAmount = 0.0;

        private double _totalCashAmount = 0.0;

        private double _totalGrandAmount;

        private double _totalBalanceAmount;

        private double _totalAmount;

        private double _totalBillDiscount;

        private string _billDiscountDetails;

        private bool _card = false;

        private bool _cash = false;

        private bool _isEnableSlipPrint = true;

        private int _defaultCurrencyId;

        private bool _isEventEmailPackage = false;

        private double lineItemDiscountTotal = 0.0;

        private double totalAmount = 0.0;

        public List<MsftDiscRecorder2> lstmain;

        public MsftDiscMaster2 discMaster;

        private long _totalDiscSize;

        private BackgroundWorker backgroundBurnWorker = new BackgroundWorker();

        private bool _isBurning;

        private bool _isFormatting;

      private IMAPI_BURN_VERIFICATION_LEVEL _verificationLevel = IMAPI_BURN_VERIFICATION_LEVEL.IMAPI_BURN_VERIFICATION_NONE;

        private bool _closeMedia;

        private bool _ejectMedia;

       private BurnData _burnData = new BurnData();

      

        public double PaybleAmount
        {
            set
            {
                this._totalBillAmount = value;
            }
        }

        public double TotalBill
        {
            set
            {
                this._totalAmount = value;
            }
        }

        public double TotalDiscount
        {
            set
            {
                this._totalBillDiscount = value;
            }
        }

        public string DiscountDetails
        {
            get
            {
                return this._billDiscountDetails;
            }
            set
            {
                this._billDiscountDetails = value;
            }
        }

        public Window SourceParent
        {
            get;
            set;
        }

        public string DefaultCurrency
        {
            get;
            set;
        }

        public ObservableCollection<LineItem> ImagesToPrint
        {
            get;
            set;
        }

        public Payment()
        {
            this.InitializeComponent();
            this._lstCurrency = new List<CurrencyInfo>();
            this._objPayment = new ObservableCollection<PaymentItem>();
            this._objCardPayment = new ObservableCollection<PaymentItem>();
            this._objRoomPayment = new ObservableCollection<PaymentItem>();
            this._objVoucherPayment = new ObservableCollection<PaymentItem>();
            this._objKVLPayment = new ObservableCollection<PaymentItem>();
            this.dgPayment.ItemsSource = this._objPayment;
            this.dgCardPayment.ItemsSource = this._objCardPayment;
            this.dgRoomPayment.ItemsSource = this._objRoomPayment;
            this.dgVoucherPayment.ItemsSource = this._objVoucherPayment;
            this.dgKVLPayment.ItemsSource = this._objKVLPayment;
            this.CtrlCashPayment.SetParent(this.modelparent);
            this.CtrlCardPayment.SetParent(this.modelparent);
            this.MailPopUp.SetParent(this.PaymentPopup);
            bool flag = false;
            List<iMIXConfigurationInfo> newConfigValues = new ConfigBusiness().GetNewConfigValues(LoginUser.SubStoreId);
            foreach (iMIXConfigurationInfo current in newConfigValues)
            {
                long iMIXConfigurationMasterId = current.IMIXConfigurationMasterId;
                if (iMIXConfigurationMasterId > 54L)
                {
                    goto IL_1AF;
                }
                if (iMIXConfigurationMasterId >= 52L)
                {
                    switch ((int)(iMIXConfigurationMasterId - 52L))
                    {
                        case 0:
                            flag = current.ConfigurationValue.ToBoolean(false);
                            continue;
                        case 1:
                            this._card = current.ConfigurationValue.ToBoolean(false);
                            continue;
                        case 2:
                            this._cash = current.ConfigurationValue.ToBoolean(false);
                            continue;
                    }
                    goto IL_1AF;
                }
                continue;
            IL_1AF:
                if (iMIXConfigurationMasterId != 79L)
                {
                    if (iMIXConfigurationMasterId == 113L)
                    {
                        this._isEventEmailPackage = (string.IsNullOrWhiteSpace(current.ConfigurationValue) || Convert.ToBoolean(current.ConfigurationValue));
                    }
                }
                else
                {
                    this._isEnableSlipPrint = (string.IsNullOrWhiteSpace(current.ConfigurationValue) || Convert.ToBoolean(current.ConfigurationValue));
                }
            }
            if (flag)
            {
                this.ShowPaymentScreenToClient();
            }
            this.btnNextsimg.IsDefault = false;
        }

        private void InitializeValue()
        {
            while (true)
            {
                double totalTax = this.GetTotalTax();
                this._totalBillAmount += totalTax;
                if (5 != 0)
                {
                    this.txtBalance.Text = this.DefaultCurrency.ToString() + " " + this._totalBillAmount.ToString("N2");
                    goto IL_65;
                }
                goto IL_89;
            IL_106:
                this.tbAmount.Text = this._totalBillAmount.ToString("N2");
                if (false)
                {
                    continue;
                }
                this.tbName1.Text = this._totalBillAmount.ToString("N2");
                if (!false)
                {
                    break;
                }
                continue;
            IL_65:
                if (false)
                {
                    goto IL_106;
                }
                if (false)
                {
                    break;
                }
                this.txtPayable.Text = this.txtBalance.Text;
            IL_89:
                this.txtPaid.Text = "0.00 " + this.DefaultCurrency.ToString();
                this.txtTotalAmountCreditCard.Text = "0.00";
                if (!false)
                {
                    this.TxtAmounttobePaid.Text = this.DefaultCurrency.ToString() + "  " + this._totalBillAmount.ToString("N2");
                    this.tbRoomCurrency.Text = this.DefaultCurrency.ToString();
                    goto IL_106;
                }
                goto IL_65;
            }
            this.tbGiftCurrency.Text = this.DefaultCurrency.ToString();
            this.tbKVL.Text = this._totalBillAmount.ToString("N2");
            if (3 != 0)
            {
            }
            this.tbKVLCurrency.Text = this.DefaultCurrency.ToString();
            this._defaultCurrencyId = new CurrencyBusiness().GetDefaultCurrency();
        }

        private string GenerateOrderNumber()
        {
            string text = LoginUser.OrderPrefix + "-";
            string str = string.Empty;
            try
            {
                RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
                try
                {
                    byte[] array = new byte[4];
                    if (!false)
                    {
                    }
                    rNGCryptoServiceProvider.GetBytes(array);
                    int num = BitConverter.ToInt32(array, 0);
                    bool arg_56_0 = num < 0;
                    int arg_56_1 = 0;
                    int expr_74;
                    int expr_77;
                    do
                    {
                        if ((arg_56_0 ? 1 : 0) != arg_56_1)
                        {
                            num = -num;
                        }
                        if (false)
                        {
                            goto IL_82;
                        }
                        expr_74 = ((arg_56_0 = (num.ToString().Length > 10)) ? 1 : 0);
                        expr_77 = (arg_56_1 = 0);
                    }
                    while (expr_77 != 0);
                    if (expr_74 == expr_77)
                    {
                        str = num.ToString();
                        goto IL_A3;
                    }
                IL_82:
                    str = num.ToString().Substring(0, 10);
                    if (true)
                    {
                    }
                IL_A3: ;
                }
                finally
                {
                    if (!false)
                    {
                        if (rNGCryptoServiceProvider != null)
                        {
                            ((IDisposable)rNGCryptoServiceProvider).Dispose();
                        }
                    }
                }
            }
            catch (Exception var_5_EC)
            {
            }
            text += str;
            string result;
            do
            {
                result = text;
            }
            while (-1 == 0);
            return result;
        }

        private bool SaveOrder(out string orderNumber, ref string orderStatus)
        {
            bool result2;
            try
            {
                List<BurnImagesInfo> list = new List<BurnImagesInfo>();
                string text = string.Empty;
                List<LinetItemsDetails> list2 = new List<LinetItemsDetails>();
                int paymentMode = -1;
                string expr_26 = string.Empty;
                string text2;
                if (3 != 0)
                {
                    text2 = expr_26;
                }
                TabItem tabItem = (TabItem)this.tabPayment.SelectedItem;
                string paymentType = string.Empty;
                string empty = string.Empty;
                string cardnumber = string.Empty;
                string customername = string.Empty;
                string hotelname = string.Empty;
                string roomno = string.Empty;
                string voucherno = string.Empty;
                if (tabItem != null)
                {
                    text = "<Payments>";
                    bool arg_D7_0;
                    if (this._objPayment.Count != 0 || this._objCardPayment.Count != 0 || this._objRoomPayment.Count != 0 || this._objVoucherPayment.Count != 0)
                    {
                        arg_D7_0 = true;
                        goto IL_D6;
                    }
                    int arg_D1_0 = (this._objKVLPayment.Count == 0) ? 1 : 0;
                IL_D0:
                    arg_D7_0 = (arg_D1_0 == 0);
                IL_D6:
                    if (!arg_D7_0)
                    {
                        System.Windows.MessageBox.Show("Please enter details first or select the Mode/Tab in which you filled the details");
                        orderNumber = string.Empty;
                        orderStatus = "CARDFAILED";
                        result2 = false;
                        return result2;
                    }
                    while (this._totalBalanceAmount <= 0.0)
                    {
                        int num = 0;
                        this._lstPaymentMethod = new List<string>();
                        if (this.dgPayment.Items.Count != 0)
                        {
                            this._lstPaymentMethod.Add("CASH");
                            if (-1 == 0)
                            {
                                continue;
                            }
                            paymentMode = 0;
                            paymentType = "CASH";
                            foreach (PaymentItem current in this._objPayment)
                            {
                                DataGridRow dataGridRow = (DataGridRow)this.dgPayment.ItemContainerGenerator.ContainerFromIndex(num);
                                if (dataGridRow != null)
                                {
                                    TextBlock textBlock = this.FindByName("txtAmountEntered", dataGridRow) as TextBlock;
                                    TextBlock textBlock2 = this.FindByName("txtNetPrice", dataGridRow) as TextBlock;
                                    TextBlock textBlock3 = this.FindByName("txtCurrencyID", dataGridRow) as TextBlock;
                                    double num2;
                                    if (this._defaultCurrencyId != textBlock3.Text.ToInt32(false))
                                    {
                                        if (double.TryParse(textBlock2.Text, out num2))
                                        {
                                            object obj = text;
                                            text = string.Concat(new object[]
											{
												obj,
												"<Payment Mode = 'FC' Amount = '",
												Convert.ToDecimal(textBlock2.Text).ToString(),
												"' OrignalAmount = '",
												Convert.ToDecimal(textBlock2.Text).ToString(),
												"' CurrencyID = '",
												this._defaultCurrencyId,
												"' CurrencyCode = '",
												current.CurrencyCode,
												"' CurrencySyncCode = '",
												current.CurrencySyncCode,
												"' FCID = '",
												textBlock3.Text,
												"' FCAmount = '",
												Convert.ToDecimal(current.PaidAmount).ToString(),
												"'/>"
											});
                                        }
                                    }
                                    else if (double.TryParse(textBlock2.Text, out num2))
                                    {
                                        string text3 = text;
                                        text = string.Concat(new string[]
										{
											text3,
											"<Payment Mode = 'cash' Amount = '",
											Convert.ToDecimal(current.PaidAmount).ToString(),
											"' OrignalAmount = '",
											Convert.ToDecimal(current.PaidAmount).ToString(),
											"' CurrencyID = '",
											textBlock3.Text,
											"' CurrencyCode = '",
											current.CurrencyCode,
											"' CurrencySyncCode = '",
											current.CurrencySyncCode,
											"'/>"
										});
                                    }
                                }
                                num++;
                            }
                        }
                        bool flag = this.dgCardPayment.Items.Count == 0;
                        bool arg_2BCF_0;
                        bool expr_47A = arg_2BCF_0 = flag;
                        int dG_Orders_pkey;
                        StringBuilder stringBuilder;
                        string text5;
                        if (!false)
                        {
                            if (!expr_47A)
                            {
                                this._lstPaymentMethod.Add("CARD");
                                paymentMode = 1;
                                paymentType = "CARD";
                                num = 0;
                                foreach (PaymentItem current in this._objCardPayment)
                                {
                                    DataGridRow dataGridRow = (DataGridRow)this.dgCardPayment.ItemContainerGenerator.ContainerFromIndex(num);
                                    if (dataGridRow != null)
                                    {
                                        string text3 = text;
                                        text = string.Concat(new string[]
										{
											text3,
											"<Payment Mode = 'card' Amount = '",
											Convert.ToDecimal(current.PaidAmount).ToString(),
											"' CurrencyID = '",
											current.Currency.ToString(),
											"' CurrencyCode = '",
											this.DefaultCurrency,
											"' CurrencySyncCode = '",
											current.CurrencySyncCode.ToString(),
											"' CardMonth = '",
											current.CardMonth.ToString(),
											"' CardYear = '",
											current.CardYear.ToString(),
											"' CardNumber = '",
											current.CardNumber.ToString(),
											"' CardType = '",
											current.CardType.ToString(),
											"' />"
										});
                                        cardnumber = current.CardNumber.ToString();
                                    }
                                    num++;
                                }
                            }
                            if (this.dgRoomPayment.Items.Count != 0)
                            {
                                this._lstPaymentMethod.Add("ROOM");
                                paymentType = "ROOM";
                                paymentMode = 2;
                                num = 0;
                                foreach (PaymentItem current in this._objRoomPayment)
                                {
                                    DataGridRow dataGridRow = (DataGridRow)this.dgRoomPayment.ItemContainerGenerator.ContainerFromIndex(num);
                                    if (dataGridRow != null)
                                    {
                                        string text3 = text;
                                        text = string.Concat(new string[]
										{
											text3,
											"<Payment Mode = 'Room' Amount = '",
											Convert.ToDecimal(current.PaidAmount).ToString(),
											"' CurrencyID = '",
											current.Currency.ToString(),
											"' CurrencyCode = '",
											this.DefaultCurrency,
											"' CurrencySyncCode = '",
											current.CurrencySyncCode.ToString(),
											"' HotelName = '",
											current.HotelName,
											"' RoomNumber = '",
											current.RoomNumber.ToString(),
											"' Name = '",
											current.CandidateName.ToString(),
											"' />"
										});
                                        customername = current.CandidateName.ToString();
                                        hotelname = current.HotelName.ToString();
                                        roomno = current.RoomNumber.ToString();
                                    }
                                    num++;
                                }
                            }
                            if (this.dgVoucherPayment.Items.Count != 0)
                            {
                                this._lstPaymentMethod.Add("VOUCHER");
                                paymentMode = 3;
                                paymentType = "VOUCHER";
                                num = 0;
                                foreach (PaymentItem current in this._objVoucherPayment)
                                {
                                    DataGridRow dataGridRow = (DataGridRow)this.dgVoucherPayment.ItemContainerGenerator.ContainerFromIndex(num);
                                    if (dataGridRow != null)
                                    {
                                        string text3 = text;
                                        text = string.Concat(new string[]
										{
											text3,
											"<Payment Mode = 'Voucher' Amount = '",
											Convert.ToDecimal(current.PaidAmount).ToString(),
											"' CurrencyID = '",
											current.Currency.ToString(),
											"' CurrencyCode = '",
											this.DefaultCurrency,
											"' CurrencySyncCode = '",
											current.CurrencySyncCode.ToString(),
											"' VoucherNumber = '",
											current.VoucherNumber.ToString(),
											"' CustomerName = '",
											current.CandidateName,
											"' />"
										});
                                        voucherno = current.VoucherNumber;
                                        customername = current.CandidateName;
                                    }
                                    num++;
                                }
                            }
                            flag = (this.dgKVLPayment.Items.Count == 0);
                            bool arg_2B83_0;
                            bool expr_96D = arg_2B83_0 = flag;
                            if (!false)
                            {
                                if (!expr_96D)
                                {
                                    this._lstPaymentMethod.Add("KVL");
                                    paymentType = "KVL";
                                    num = 0;
                                    foreach (PaymentItem current in this._objKVLPayment)
                                    {
                                        DataGridRow dataGridRow = (DataGridRow)this.dgKVLPayment.ItemContainerGenerator.ContainerFromIndex(num);
                                        if (dataGridRow != null)
                                        {
                                            string text3 = text;
                                            text = string.Concat(new string[]
											{
												text3,
												"<Payment Mode = 'KVL' Amount = '",
												Convert.ToDecimal(current.PaidAmount).ToString(),
												"' CurrencyID = '",
												current.Currency.ToString(),
												"' CurrencyCode = '",
												this.DefaultCurrency,
												"' CurrencySyncCode = '",
												current.CurrencySyncCode.ToString(),
												"'  />"
											});
                                        }
                                        num++;
                                    }
                                }
                                double num3 = Convert.ToDouble(this.txtBalance.Text.ToString().Split(new char[]
								{
									' '
								})[1]);
                                if (num3 < 0.0)
                                {
                                    text = text + "<Payment Mode = 'Cash Refund' Amount = '" + Convert.ToDecimal(num3).ToString().Replace(",", "") + "'  />";
                                }
                                text += "</Payments>";
                                orderNumber = this.GenerateOrderNumber();
                                string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Order).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "14");
                                string empty2 = string.Empty;
                                OrderInfo orderInfo = new OrderBusiness().GenerateOrder(orderNumber, (decimal)this._totalAmount, (decimal)this._totalBillAmount, text, paymentMode, this._totalBillDiscount, this.DiscountDetails, LoginUser.UserId, this._defaultCurrencyId, "0", uniqueSynccode, LoginUser.Storecode);
                                orderNumber = orderInfo.DG_Orders_Number;
                                TaxBusiness taxBusiness = new TaxBusiness();
                                dG_Orders_pkey = orderInfo.DG_Orders_pkey;
                                taxBusiness.SaveOrderTaxDetails(LoginUser.StoreId, orderInfo.DG_Orders_pkey, LoginUser.SubStoreId);
                                int num4 = -1;
                                if (dG_Orders_pkey <= 0)
                                {
                                    goto IL_2D84;
                                }
                                stringBuilder = new StringBuilder();
                                string text4 = string.Empty;
                                int MaxGap = 0;
                                MaxGap = (from x in this.ImagesToPrint
                                          where x.SelectedProductType_Text.Length > MaxGap
                                          select x).FirstOrDefault<LineItem>().SelectedProductType_Text.Length;
                                IEnumerable<LineItem> enumerable = from result in this.ImagesToPrint
                                                                   where result.ParentID == result.ItemNumber
                                                                   select result;
                                text5 = string.Empty;
                                using (IEnumerator<LineItem> enumerator2 = enumerable.GetEnumerator())
                                {
                                    while (enumerator2.MoveNext())
                                    {
                                        LineItem item = enumerator2.Current;
                                        text4 = string.Empty;
                                        if (!item.IsPackage)
                                        {
                                            num4 = -1;
                                            if (!item.IsBundled)
                                            {
                                                int num5 = item.Quantity - 1;
                                                if (!item.IsAccessory)
                                                {
                                                    foreach (string current2 in item.SelectedImages)
                                                    {
                                                        int i = 1;
                                                        while (i <= num5)
                                                        {
                                                            string text6 = string.Empty;
                                                            num = MaxGap - item.SelectedProductType_Text.Length;
                                                            num += 35;
                                                            for (int j = 1; j <= num; j++)
                                                            {
                                                                text6 += " ";
                                                            }
                                                            i++;
                                                            stringBuilder.AppendLine(item.SelectedProductType_Text + text6 + item.UnitPrice.ToString(".00"));
                                                        }
                                                        if (text4 == string.Empty)
                                                        {
                                                            text4 = current2;
                                                        }
                                                        else
                                                        {
                                                            text4 = text4 + "," + current2;
                                                        }
                                                    }
                                                }
                                                LinetItemsDetails linetItemsDetails = new LinetItemsDetails();
                                                linetItemsDetails.Productname = item.SelectedProductType_Text;
                                                linetItemsDetails.Productprice = item.UnitPrice.ToString("#.00");
                                                if (!item.IsAccessory)
                                                {
                                                    linetItemsDetails.Productquantity = (item.Quantity * item.SelectedImages.Count).ToString();
                                                }
                                                else
                                                {
                                                    linetItemsDetails.Productquantity = item.Quantity.ToString();
                                                }
                                                list2.Add(linetItemsDetails);
                                            }
                                            else
                                            {
                                                string text6 = string.Empty;
                                                num = MaxGap - item.SelectedProductType_Text.Length;
                                                num += 40;
                                                for (int j = 1; j <= num; j++)
                                                {
                                                    text6 += " ";
                                                }
                                                int num5 = item.Quantity;
                                                for (int i = 1; i <= num5; i++)
                                                {
                                                    stringBuilder.AppendLine(item.SelectedProductType_Text + text6 + item.UnitPrice.ToString(".00"));
                                                }
                                                foreach (string current2 in item.SelectedImages)
                                                {
                                                    if (text4 == string.Empty)
                                                    {
                                                        text4 = current2;
                                                    }
                                                    else
                                                    {
                                                        text4 = text4 + "," + current2;
                                                    }
                                                }
                                                list2.Add(new LinetItemsDetails
                                                {
                                                    Productname = item.SelectedProductType_Text,
                                                    Productprice = item.UnitPrice.ToString("#.00"),
                                                    Productquantity = item.Quantity.ToString()
                                                });
                                            }
                                            if (text5 != string.Empty)
                                            {
                                                text5 = text5 + "," + text4;
                                            }
                                            else
                                            {
                                                text5 = text4;
                                            }
                                            int num6 = 0;
                                            string uniqueSynccode2 = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.OrderDetails).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString());
                                            if (item.IssemiOrder)
                                            {
                                                new OrderBusiness().setSemiOrderImageOrderDetails(new int?(dG_Orders_pkey), text4.ToString(), new int?(num4), LoginUser.SubStoreId, item.TotalDiscount, (decimal)item.TotalDiscountAmount, (decimal)item.TotalPrice, (decimal)item.NetPrice);
                                                goto IL_1258;
                                            }
                                            num6 = new OrderBusiness().SaveOrderLineItems(item.SelectedProductType_ID, new int?(dG_Orders_pkey), text4, item.Quantity, item.TotalDiscount, (decimal)item.TotalDiscountAmount, (decimal)item.UnitPrice, (decimal)item.TotalPrice, (decimal)item.NetPrice, num4, LoginUser.SubStoreId, item.CodeType, item.UniqueCode, uniqueSynccode2, null, null, null, null);
                                            if (item.SelectedProductType_ID == 79 && num6 > 0 && !string.IsNullOrEmpty(text4) && item.GroupItems.Count<LstMyItems>() > 0)
                                            {
                                                new PrinterBusniess().SaveAlbumPrintPosition(num6, item.PrintPhotoOrderPosition);
                                            }
                                            if (8 != 0)
                                            {
                                                goto IL_1258;
                                            }
                                            goto IL_1322;
                                            continue;
                                        IL_1322:
                                            using (List<string>.Enumerator enumerator3 = item.SelectedImages.GetEnumerator())
                                            {
                                                while (enumerator3.MoveNext())
                                                {
                                                    string img = enumerator3.Current;
                                                    BurnImagesInfo burnImagesInfo = list.Where(delegate(BurnImagesInfo x)
                                                    {
                                                        bool result3=false;
                                                        if (!false)
                                                        {
                                                            int arg_15_0 = x.Producttype;
                                                            int arg_15_1 = item.SelectedProductType_ID;
                                                            bool arg_61_0;
                                                            while (arg_15_0 == arg_15_1)
                                                            {
                                                                int expr_50 = arg_15_0 = x.ImageID;
                                                                int expr_5A = arg_15_1 = Convert.ToInt32(img);
                                                                if (!false)
                                                                {
                                                                    arg_61_0 = (expr_50 == expr_5A);
                                                                    if (2 != 0)
                                                                    {
                                                                    IL_2F: ;
                                                                    }
                                                                    result3 = arg_61_0;
                                                                    if (2 != 0)
                                                                    {
                                                                        return result3;
                                                                    }
                                                                    return result3;
                                                                }
                                                            }
                                                            arg_61_0 = false;
                                                            //goto IL_2F;
                                                        }
                                                        return result3;
                                                    }).FirstOrDefault<BurnImagesInfo>();
                                                    if (burnImagesInfo == null)
                                                    {
                                                        list.Add(new BurnImagesInfo
                                                        {
                                                            ImageID = img.ToInt32(false),
                                                            Producttype = item.SelectedProductType_ID
                                                        });
                                                    }
                                                }
                                            }
                                            continue;
                                        IL_1258:
                                            if (item.SelectedProductType_ID == 41 || item.SelectedProductType_ID == 80 || item.SelectedProductType_ID == 81 || item.SelectedProductType_ID == 82 || item.SelectedProductType_ID == 83 || item.SelectedProductType_ID == 48 || item.SelectedProductType_ID == 78 || item.SelectedProductType_ID == 36 || item.SelectedProductType_ID == 35 || item.SelectedProductType_ID == 96 || item.SelectedProductType_ID == 97)
                                            {
                                                goto IL_1322;
                                            }
                                            if (!item.IsAccessory && item.SelectedProductType_ID != 84)
                                            {
                                                if (!item.IssemiOrder)
                                                {
                                                    this.AddToPrintQueue(item, num6, item.PrintPhotoOrderPosition);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            IEnumerable<LineItem> enumerable2 = this.ImagesToPrint.Where(delegate(LineItem result)
                                            {
                                                int arg_54_0;
                                                do
                                                {
                                                    bool expr_43 = (arg_54_0 = ((result.ParentID == item.ItemNumber) ? 1 : 0)) != 0;
                                                    if (false)
                                                    {
                                                        goto IL_24;
                                                    }
                                                    if (!expr_43)
                                                    {
                                                        goto IL_23;
                                                    }
                                                }
                                                while (false);
                                                bool expr_4D = (arg_54_0 = (result.IsPackage ? 1 : 0)) != 0;
                                                if (!false)
                                                {
                                                    arg_54_0 = ((!expr_4D) ? 1 : 0);
                                                }
                                            IL_21:
                                                goto IL_24;
                                            IL_23:
                                                arg_54_0 = 0;
                                            IL_24:
                                                bool flag3 = arg_54_0 != 0;
                                                bool expr_57 = (arg_54_0 = (flag3 ? 1 : 0)) != 0;
                                                if (!false)
                                                {
                                                    return expr_57;
                                                }
                                                goto IL_21;
                                            });
                                            List<LineItem> list3 = enumerable2.Where(delegate(LineItem p)
                                            {
                                                bool result3;
                                                if (!false)
                                                {
                                                    bool arg_27_0;
                                                    if (!p.IsAccessory)
                                                    {
                                                        if (7 == 0)
                                                        {
                                                            goto IL_28;
                                                        }
                                                        int arg_12_0 = p.SelectedProductType_ID;
                                                        int arg_12_1 = 95;
                                                        while (arg_12_0 != arg_12_1)
                                                        {
                                                            int expr_4D = arg_12_0 = p.SelectedImages.Count;
                                                            int expr_57 = arg_12_1 = p.TotalMaxSelectedPhotos;
                                                            if (!false)
                                                            {
                                                                arg_27_0 = (expr_4D > expr_57);
                                                                goto IL_26;
                                                            }
                                                        }
                                                    }
                                                    arg_27_0 = false;
                                                IL_26:
                                                    result3 = arg_27_0;
                                                IL_28:
                                                    if (2 != 0)
                                                    {
                                                    }
                                                }
                                                return result3;
                                            }).ToList<LineItem>();
                                            if (list3.Count <= 0)
                                            {
                                                if (false)
                                                {
                                                    goto IL_1FA2;
                                                }
                                                string photoIDsUnsold = null;
                                                LineItem item2 = item;
                                                this.SetTaxDetails(ref item2);
                                                item.TaxAmount = item2.TaxAmount;
                                                item.TaxPercent = item2.TaxPercent;
                                                item.NetPrice = item2.NetPrice;
                                                item.IsTaxIncluded = item2.IsTaxIncluded;
                                                string uniqueSynccode3 = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.OrderDetails).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString());
                                                num4 = new OrderBusiness().SaveOrderLineItems(item.SelectedProductType_ID, new int?(dG_Orders_pkey), text4, item.Quantity, item.TotalDiscount, (decimal)item.TotalDiscountAmount, (decimal)item.UnitPrice, (decimal)item.TotalPrice, (decimal)item.NetPrice + (decimal)item2.TaxAmount, -1, LoginUser.SubStoreId, item.CodeType, item.UniqueCode, uniqueSynccode3, null, item.TaxPercent, new decimal?(Math.Round((decimal)item.TaxAmount, 3, MidpointRounding.ToEven)), item.IsTaxIncluded);
                                                int selectedProductType_ID = item.SelectedProductType_ID;
                                                if (item.SelectedProductType_ID == 79 && num4 > 0 && !string.IsNullOrEmpty(text4) && item.GroupItems.Count<LstMyItems>() > 0)
                                                {
                                                    goto IL_1FA2;
                                                }
                                            IL_1FBC:
                                                string text7 = string.Empty;
                                                num = MaxGap - item.SelectedProductType_Text.Length;
                                                num += 35;
                                                for (int j = 1; j <= num; j++)
                                                {
                                                    text7 += " ";
                                                }
                                                stringBuilder.AppendLine(item.SelectedProductType_Text + text7 + item.UnitPrice.ToString(".00"));
                                                list2.Add(new LinetItemsDetails
                                                {
                                                    Productname = item.SelectedProductType_Text,
                                                    Productprice = item.UnitPrice.ToString("#.00"),
                                                    Productquantity = item.Quantity.ToString()
                                                });
                                                using (IEnumerator<LineItem> enumerator4 = enumerable2.GetEnumerator())
                                                {
                                                    while (enumerator4.MoveNext())
                                                    {
                                                        LineItem Citem = enumerator4.Current;
                                                        text4 = string.Empty;
                                                        int arg_20F5_0;
                                                        if (!Citem.IsAccessory)
                                                        {
                                                            arg_20F5_0 = ((Citem.SelectedProductType_ID == 95) ? 1 : 0);
                                                        }
                                                        else
                                                        {
                                                            arg_20F5_0 = 1;
                                                        }
                                                    IL_20F4:
                                                        if (arg_20F5_0 == 0)
                                                        {
                                                            foreach (string current2 in Citem.SelectedImages)
                                                            {
                                                                if (text4 == string.Empty)
                                                                {
                                                                    text4 = current2;
                                                                }
                                                                else
                                                                {
                                                                    text4 = text4 + "," + current2;
                                                                }
                                                            }
                                                        }
                                                        int num6 = 0;
                                                        string uniqueSynccode4 = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.OrderDetails).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString());
                                                        if (Citem.IssemiOrder)
                                                        {
                                                            new OrderBusiness().setSemiOrderImageOrderDetails(new int?(dG_Orders_pkey), text4, new int?(num4), LoginUser.SubStoreId, item.TotalDiscount, 0m, 0m, 0m);
                                                        }
                                                        else
                                                        {
                                                            bool arg_222B_0 = ((Citem.SelectedProductType_ID != 84) ? (arg_20F5_0 = 1) : (arg_20F5_0 = ((!new OrderBusiness().chKIsWaterMarkedOrNot(selectedProductType_ID)) ? 1 : 0))) != 0;
                                                            if (false)
                                                            {
                                                                goto IL_20F1;
                                                            }
                                                            if (!arg_222B_0)
                                                            {
                                                                List<string> first = (from g in RobotImageLoader.GroupImages
                                                                                      select g.PhotoId.ToString()).ToList<string>();
                                                                List<string> second = Citem.SelectedImages.ToList<string>();
                                                                List<string> list4 = first.Except(second).ToList<string>();
                                                                if (list4.Count > 0)
                                                                {
                                                                    photoIDsUnsold = string.Join(",", list4);
                                                                }
                                                            }
                                                            num6 = new OrderBusiness().SaveOrderLineItems(Citem.SelectedProductType_ID, new int?(dG_Orders_pkey), text4, Citem.Quantity, item.TotalDiscount, 0m, 0m, 0m, 0m, num4, LoginUser.SubStoreId, Citem.CodeType, Citem.UniqueCode, uniqueSynccode4, photoIDsUnsold, null, null, null);
                                                            if (Citem.SelectedProductType_ID == 79 && num6 > 0 && !string.IsNullOrEmpty(text4) && Citem.GroupItems.Count<LstMyItems>() > 0)
                                                            {
                                                                new PrinterBusniess().SaveAlbumPrintPosition(num6, Citem.PrintPhotoOrderPosition);
                                                            }
                                                        }
                                                        if (text5 != string.Empty)
                                                        {
                                                            text5 = text5 + "," + text4;
                                                        }
                                                        else
                                                        {
                                                            text5 = text4;
                                                        }
                                                        if (Citem.SelectedProductType_ID == 80 || Citem.SelectedProductType_ID == 81 || Citem.SelectedProductType_ID == 82 || Citem.SelectedProductType_ID == 83 || Citem.SelectedProductType_ID == 41 || Citem.SelectedProductType_ID == 48 || Citem.SelectedProductType_ID == 78 || Citem.SelectedProductType_ID == 36 || Citem.SelectedProductType_ID == 35 || Citem.SelectedProductType_ID == 96 || Citem.SelectedProductType_ID == 97)
                                                        {
                                                            using (List<string>.Enumerator enumerator3 = Citem.SelectedImages.GetEnumerator())
                                                            {
                                                                while (enumerator3.MoveNext())
                                                                {
                                                                    string img = enumerator3.Current;
                                                                    BurnImagesInfo burnImagesInfo = list.Where(delegate(BurnImagesInfo x)
                                                                    {
                                                                        bool result3=false;
                                                                        if (!false)
                                                                        {
                                                                            int arg_15_0 = x.Producttype;
                                                                            int arg_15_1 = Citem.SelectedProductType_ID;
                                                                            bool arg_61_0;
                                                                            while (arg_15_0 == arg_15_1)
                                                                            {
                                                                                int expr_50 = arg_15_0 = x.ImageID;
                                                                                int expr_5A = arg_15_1 = Convert.ToInt32(img);
                                                                                if (!false)
                                                                                {
                                                                                    arg_61_0 = (expr_50 == expr_5A);
                                                                                    if (2 != 0)
                                                                                    {
                                                                                    IL_2F: ;
                                                                                    }
                                                                                    result3 = arg_61_0;
                                                                                    if (2 != 0)
                                                                                    {
                                                                                        return result3;
                                                                                    }
                                                                                    return result3;
                                                                                }
                                                                            }
                                                                            arg_61_0 = false;
                                                                            //goto IL_2F;
                                                                        }
                                                                        return result3;
                                                                    }).FirstOrDefault<BurnImagesInfo>();
                                                                    if (burnImagesInfo == null)
                                                                    {
                                                                        list.Add(new BurnImagesInfo
                                                                        {
                                                                            ImageID = img.ToInt32(false),
                                                                            Producttype = Citem.SelectedProductType_ID
                                                                        });
                                                                    }
                                                                }
                                                            }
                                                        }
                                                        else if (!Citem.IsAccessory && Citem.SelectedProductType_ID != 84 && Citem.SelectedProductType_ID != 95)
                                                        {
                                                            this.AddToPrintQueue(Citem, num6, Citem.PrintPhotoOrderPosition);
                                                        }
                                                        if (text2 == string.Empty)
                                                        {
                                                            text2 = text4;
                                                        }
                                                        else
                                                        {
                                                            text2 = text2 + "," + text4;
                                                        }
                                                        text4 = string.Empty;
                                                        continue;
                                                    IL_20F1:
                                                        goto IL_20F4;
                                                    }
                                                }
                                                continue;
                                            IL_1FA2:
                                                new PrinterBusniess().SaveAlbumPrintPosition(num4, item.PrintPhotoOrderPosition);
                                                goto IL_1FBC;
                                            }
                                            int num7 = 0;
                                            foreach (LineItem current3 in list3)
                                            {
                                                int num8 = current3.SelectedImages.Count / current3.TotalMaxSelectedPhotos + ((current3.SelectedImages.Count % current3.TotalMaxSelectedPhotos > 0) ? 1 : 0);
                                                if (num8 > num7)
                                                {
                                                    num7 = num8;
                                                }
                                            }
                                            item.Quantity = 1;
                                            item.TotalPrice = (item.UnitPrice * (double)item.Quantity).ToDouble(false);
                                            double totalDiscountAmount = item.TotalDiscountAmount;
                                            item.TotalDiscountAmount = totalDiscountAmount / (double)num7;
                                            item.NetPrice = item.TotalPrice - item.TotalDiscountAmount;
                                            for (int k = 0; k < num7; k++)
                                            {
                                                LineItem item2 = item;
                                                this.SetTaxDetails(ref item2);
                                                item.TaxAmount = item2.TaxAmount;
                                                item.TaxPercent = item2.TaxPercent;
                                                item.NetPrice = item2.NetPrice;
                                                item.IsTaxIncluded = item2.IsTaxIncluded;
                                                string uniqueSynccode3 = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.OrderDetails).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString());
                                                num4 = new OrderBusiness().SaveOrderLineItems(item.SelectedProductType_ID, new int?(dG_Orders_pkey), text4, item.Quantity, item.TotalDiscount, (decimal)item.TotalDiscountAmount, (decimal)item.UnitPrice, (decimal)item.TotalPrice, (decimal)item.NetPrice + (decimal)item2.TaxAmount, -1, LoginUser.SubStoreId, item.CodeType, item.UniqueCode, uniqueSynccode3, null, item.TaxPercent, new decimal?(Math.Round((decimal)item.TaxAmount, 3, MidpointRounding.ToEven)), item.IsTaxIncluded);
                                                string text6 = string.Empty;
                                                num = MaxGap - item.SelectedProductType_Text.Length;
                                                num += 35;
                                                for (int j = 1; j <= num; j++)
                                                {
                                                    text6 += " ";
                                                }
                                                stringBuilder.AppendLine(item.SelectedProductType_Text + text6 + item.UnitPrice.ToString(".00"));
                                                list2.Add(new LinetItemsDetails
                                                {
                                                    Productname = item.SelectedProductType_Text,
                                                    Productprice = item.UnitPrice.ToString("#.00"),
                                                    Productquantity = item.Quantity.ToString()
                                                });
                                                using (IEnumerator<LineItem> enumerator4 = enumerable2.GetEnumerator())
                                                {
                                                    while (enumerator4.MoveNext())
                                                    {
                                                        LineItem Citem = enumerator4.Current;
                                                        int num9 = Citem.TotalMaxSelectedPhotos * k;
                                                        int num10 = 0;
                                                        if (!Citem.IsAccessory && Citem.SelectedProductType_ID != 95)
                                                        {
                                                            if (Citem.SelectedImages.Count - num9 >= Citem.TotalMaxSelectedPhotos)
                                                            {
                                                                num10 = Citem.TotalMaxSelectedPhotos;
                                                            }
                                                            else
                                                            {
                                                                num10 = Citem.SelectedImages.Count - num9;
                                                            }
                                                        }
                                                        if (Citem.SelectedProductType_ID == 95 || Citem.IsAccessory || (num9 < Citem.SelectedImages.Count && num10 > 0))
                                                        {
                                                            List<string> list5 = null;
                                                            int num6 = 0;
                                                            while (true)
                                                            {
                                                                text4 = string.Empty;
                                                                if (!Citem.IsAccessory && Citem.SelectedProductType_ID != 95)
                                                                {
                                                                    list5 = Citem.SelectedImages.GetRange(num9, num10);
                                                                    foreach (string current2 in list5)
                                                                    {
                                                                        if (text4 == string.Empty)
                                                                        {
                                                                            text4 = current2;
                                                                        }
                                                                        else
                                                                        {
                                                                            text4 = text4 + "," + current2;
                                                                        }
                                                                    }
                                                                }
                                                                //int num6 = 0;
                                                                string uniqueSynccode4 = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.OrderDetails).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString());
                                                                if (Citem.IssemiOrder)
                                                                {
                                                                    new OrderBusiness().setSemiOrderImageOrderDetails(new int?(dG_Orders_pkey), text4, new int?(num4), LoginUser.SubStoreId, item.TotalDiscount, 0m, 0m, 0m);
                                                                }
                                                                else
                                                                {
                                                                    num6 = new OrderBusiness().SaveOrderLineItems(Citem.SelectedProductType_ID, new int?(dG_Orders_pkey), text4, Citem.Quantity, item.TotalDiscount, 0m, 0m, 0m, 0m, num4, LoginUser.SubStoreId, Citem.CodeType, Citem.UniqueCode, uniqueSynccode4, null, null, null, null);
                                                                }
                                                                if (text5 != string.Empty)
                                                                {
                                                                    text5 = text5 + "," + text4;
                                                                }
                                                                else
                                                                {
                                                                    text5 = text4;
                                                                }
                                                                if (Citem.SelectedProductType_ID == 80 || Citem.SelectedProductType_ID == 81 || Citem.SelectedProductType_ID == 82 || Citem.SelectedProductType_ID == 83 || Citem.SelectedProductType_ID == 41 || Citem.SelectedProductType_ID == 48 || Citem.SelectedProductType_ID == 78 || Citem.SelectedProductType_ID == 36 || Citem.SelectedProductType_ID == 35 || Citem.SelectedProductType_ID == 96 || Citem.SelectedProductType_ID == 97)
                                                                {
                                                                    goto Block_151;
                                                                }
                                                                if (Citem.IsAccessory)
                                                                {
                                                                    goto IL_1D22;
                                                                }
                                                                if (!false)
                                                                {
                                                                    goto Block_154;
                                                                }
                                                            }
                                                        IL_1D4B:
                                                            if (text2 == string.Empty)
                                                            {
                                                                text2 = text4;
                                                            }
                                                            else
                                                            {
                                                                text2 = text2 + "," + text4;
                                                            }
                                                            text4 = string.Empty;
                                                            continue;
                                                        Block_151:
                                                            using (List<string>.Enumerator enumerator3 = Citem.SelectedImages.GetEnumerator())
                                                            {
                                                                while (enumerator3.MoveNext())
                                                                {
                                                                    string img = enumerator3.Current;
                                                                    BurnImagesInfo burnImagesInfo = list.Where(delegate(BurnImagesInfo x)
                                                                    {
                                                                        bool result3=false;
                                                                        if (!false)
                                                                        {
                                                                            int arg_15_0 = x.Producttype;
                                                                            int arg_15_1 = Citem.SelectedProductType_ID;
                                                                            bool arg_61_0;
                                                                            while (arg_15_0 == arg_15_1)
                                                                            {
                                                                                int expr_50 = arg_15_0 = x.ImageID;
                                                                                int expr_5A = arg_15_1 = Convert.ToInt32(img);
                                                                                if (!false)
                                                                                {
                                                                                    arg_61_0 = (expr_50 == expr_5A);
                                                                                    if (2 != 0)
                                                                                    {
                                                                                    IL_2F: ;
                                                                                    }
                                                                                    result3 = arg_61_0;
                                                                                    if (2 != 0)
                                                                                    {
                                                                                        return result3;
                                                                                    }
                                                                                    return result3;
                                                                                }
                                                                            }
                                                                            arg_61_0 = false;
                                                                            //goto IL_2F;
                                                                        }
                                                                        return result3;
                                                                    }).FirstOrDefault<BurnImagesInfo>();
                                                                    if (burnImagesInfo == null)
                                                                    {
                                                                        list.Add(new BurnImagesInfo
                                                                        {
                                                                            ImageID = img.ToInt32(false),
                                                                            Producttype = Citem.SelectedProductType_ID
                                                                        });
                                                                    }
                                                                }
                                                            }
                                                            goto IL_1D4B;
                                                        IL_1D23:
                                                            bool arg_1D24_0;
                                                            if (!arg_1D24_0)
                                                            {
                                                                //int num6;
                                                                this.AddToPrintQueue(Citem, num6, list5, Citem.PrintPhotoOrderPosition);
                                                            }
                                                            goto IL_1D4B;
                                                        IL_1D22:
                                                            arg_1D24_0 = true;
                                                            goto IL_1D23;
                                                        Block_154:
                                                            if (Citem.SelectedProductType_ID != 84)
                                                            {
                                                                arg_1D24_0 = (Citem.SelectedProductType_ID == 95);
                                                                goto IL_1D23;
                                                            }
                                                            goto IL_1D22;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                taxBusiness.SaveOrderTaxDetails(LoginUser.StoreId, orderInfo.DG_Orders_pkey, LoginUser.SubStoreId);
                                orderStatus = "OrderPlaced";
                                if (list.Count <= 0)
                                {
                                    goto IL_2BC2;
                                }
                                StringBuilder stringBuilder2 = new StringBuilder();
                                string text8 = string.Empty;
                                bool flag2 = false;
                                List<string> values = (from x in list
                                                       select x.ImageID.ToString()).ToList<string>();
                                string photoIdList = string.Join(",", values);
                                List<PhotoInfo> photoRFIDByPhotoIDList = new PhotoBusiness().GetPhotoRFIDByPhotoIDList(photoIdList);
                                string path = string.Empty;
                                if (string.IsNullOrWhiteSpace(LoginUser.ServerHotFolderPath))
                                {
                                    path = LoginUser.DigiFolderPath;
                                }
                                else
                                {
                                    path = LoginUser.ServerHotFolderPath;
                                }
                                using (List<BurnImagesInfo>.Enumerator enumerator6 = list.GetEnumerator())
                                {
                                    while (enumerator6.MoveNext())
                                    {
                                        BurnImagesInfo itemid = enumerator6.Current;
                                        try
                                        {
                                            PhotoInfo photoInfo = (from x in photoRFIDByPhotoIDList
                                                                   where x.DG_Photos_pkey == itemid.ImageID
                                                                   select x).FirstOrDefault<PhotoInfo>();
                                            int producttype = itemid.Producttype;
                                            switch (producttype)
                                            {
                                                case 35:
                                                    flag2 = true;
                                                    text8 = Environment.CurrentDirectory + "\\DigiOrderdImages\\CDOrders\\" + orderNumber + "\\CD\\";
                                                    break;
                                                case 36:
                                                    flag2 = true;
                                                    text8 = Environment.CurrentDirectory + "\\DigiOrderdImages\\USBOrders\\" + orderNumber + "\\USB\\";
                                                    break;
                                                default:
                                                    switch (producttype)
                                                    {
                                                        case 78:
                                                            text8 = Path.Combine(path, "PrintImages", "Email", orderNumber);
                                                            break;
                                                        case 79:
                                                            break;
                                                        case 80:
                                                            text8 = Path.Combine(path, "PrintImages", "Facebook", orderNumber);
                                                            break;
                                                        case 81:
                                                            text8 = Path.Combine(path, "PrintImages", "LinkedIn", orderNumber);
                                                            break;
                                                        case 82:
                                                            text8 = Path.Combine(path, "PrintImages", "Twitter", orderNumber);
                                                            break;
                                                        case 83:
                                                            text8 = Path.Combine(path, "PrintImages", "Pinterest", orderNumber);
                                                            break;
                                                        default:
                                                            switch (producttype)
                                                            {
                                                                case 96:
                                                                    flag2 = true;
                                                                    text8 = Environment.CurrentDirectory + "\\DigiOrderdImages\\CDOrders\\" + orderNumber + "\\VideoCD\\";
                                                                    break;
                                                                case 97:
                                                                    flag2 = true;
                                                                    text8 = Environment.CurrentDirectory + "\\DigiOrderdImages\\USBOrders\\" + orderNumber + "\\VideoUSB\\";
                                                                    break;
                                                            }
                                                            break;
                                                    }
                                                    break;
                                            }
                                            if (!Directory.Exists(text8))
                                            {
                                                Directory.CreateDirectory(text8);
                                            }
                                            switch (itemid.Producttype)
                                            {
                                                case 78:
                                                    {
                                                        stringBuilder2.Append(itemid.ImageID + ",");
                                                        string text9 = Path.Combine(photoInfo.HotFolderPath, "EditedImages", photoInfo.DG_Photos_FileName);
                                                        if (File.Exists(text9))
                                                        {
                                                            File.Copy(text9, Path.Combine(text8, itemid.ImageID.ToInt32(false) + ".jpg"), true);
                                                        }
                                                        else
                                                        {
                                                            File.Copy(Path.Combine(photoInfo.HotFolderPath, photoInfo.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoInfo.DG_Photos_FileName), Path.Combine(text8, itemid.ImageID.ToString() + ".jpg"), true);
                                                        }
                                                        break;
                                                    }
                                                case 80:
                                                case 81:
                                                case 82:
                                                case 83:
                                                    File.Copy(Path.Combine(photoInfo.HotFolderPath, "Thumbnails_Big", photoInfo.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoInfo.DG_Photos_FileName), Path.Combine(text8, itemid.ImageID.ToString() + ".jpg"));
                                                    break;
                                            }
                                        }
                                        catch (Exception serviceException)
                                        {
                                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                                        }
                                        if (text2 == string.Empty)
                                        {
                                            text2 = itemid.ImageID.ToString();
                                        }
                                        else
                                        {
                                            text2 = text2 + "," + itemid.ImageID;
                                        }
                                    }
                                }
                                if (this._isEventEmailPackage)
                                {
                                    if (!string.IsNullOrEmpty(stringBuilder2.ToString()))
                                    {
                                        EMailInfo info = new EMailInfo
                                        {
                                            StoreId = LoginUser.StoreId.ToString(),
                                            UserId = LoginUser.UserId.ToString(),
                                            OrderId = orderNumber,
                                            Sendername = LoginUser.UserName,
                                            SubstoreId = LoginUser.SubStoreId.ToString(),
                                            OtherMessage = stringBuilder2.ToString().Substring(0, stringBuilder2.Length - 1)
                                        };
                                        this.MailPopUp.IsEnabled = true;
                                        arg_D1_0 = (this.MailPopUp.ShowHandlerDialog(info) ? 1 : 0);
                                        if (false)
                                        {
                                            goto IL_D0;
                                        }
                                    }
                                }
                                flag = !flag2;
                                arg_2B83_0 = flag;
                            }
                            if (!arg_2B83_0)
                            {
                                try
                                {
                                    this.InitiateBurnOrders();
                                }
                                catch (Exception serviceException)
                                {
                                    orderStatus = "BurnedProductError";
                                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                                    System.Windows.MessageBox.Show("Your order has been successfully placed. But here is issue in detecting recording media. So, if USB/CD not burned please rewrite USB/CD from Burn Order.", "i-Mix");
                                }
                            }
                        IL_2BC2:
                            arg_2BCF_0 = (text2 != string.Empty);
                        }
                        if (arg_2BCF_0)
                        {
                            this.PrintSlip(orderNumber, stringBuilder.ToString(), this._totalBillDiscount / this._totalAmount * 100.0, this._totalBillDiscount, this._totalBillAmount, text5, list2, paymentType, cardnumber, empty, customername, hotelname, roomno, voucherno, dG_Orders_pkey);
                        }
                        else
                        {
                            this.PrintSlip(orderNumber, stringBuilder.ToString(), this._totalBillDiscount / this._totalAmount * 100.0, this._totalBillDiscount, this._totalBillAmount, text5, list2, paymentType, cardnumber, empty, customername, hotelname, roomno, voucherno, dG_Orders_pkey);
                        }
                        if (this._totalBillDiscount > 0.0)
                        {
                            AuditLog.AddUserLog(LoginUser.UserId, 42, string.Concat(new string[]
							{
								"Create Order of No :",
								orderNumber,
								" of total Amount ",
								this.DefaultCurrency.ToString(),
								" ",
								this._totalAmount.ToString("0.00"),
								" including discount of ",
								this.DefaultCurrency.ToString(),
								" ",
								this._totalBillDiscount.ToString("0.00")
							}));
                        }
                        else
                        {
                            AuditLog.AddUserLog(LoginUser.UserId, 42, string.Concat(new string[]
							{
								"Create Order of No :",
								orderNumber,
								" of total Amount ",
								this.DefaultCurrency.ToString(),
								" ",
								this._totalAmount.ToString("0.00")
							}));
                        }
                        result2 = true;
                        return result2;
                    }
                    System.Windows.MessageBox.Show(string.Concat(new string[]
					{
						"Please pay remaining ",
						this.DefaultCurrency.ToString(),
						" ",
						this._totalBalanceAmount.ToString("N2"),
						" before continue."
					}));
                    orderNumber = string.Empty;
                    orderStatus = "PAYREMAINING";
                    result2 = false;
                    return result2;
                }
            IL_2D84:
                list.Clear();
                list = null;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                orderNumber = string.Empty;
                result2 = false;
                return result2;
            }
            finally
            {
                MemoryManagement.FlushMemory();
                GC.RemoveMemoryPressure(20000L);
            }
            orderNumber = string.Empty;
            result2 = true;
            return result2;
        }

        private void SetTaxDetails(ref LineItem item)
        {
            try
            {
                new StoreInfo();
                TaxBusiness taxBusiness = new TaxBusiness();
                StoreInfo taxConfigData = taxBusiness.getTaxConfigData();
                ProductBusiness productBusiness = new ProductBusiness();
                double num = 0.0;
                bool value = productBusiness.GetProductByID(item.SelectedProductType_ID).DG_IsTaxEnabled.Value;
                List<TaxDetailInfo> applicableTaxes = taxBusiness.GetApplicableTaxes(0);
                double num2 = 0.0;
                bool arg_7F_0;
                if (applicableTaxes == null)
                {
                    arg_7F_0 = true;
                    goto IL_7E;
                }
            IL_6E:
                arg_7F_0 = (applicableTaxes.Count <= 0);
            IL_7E:
                bool flag = arg_7F_0;
                while (true)
                {
                    if (!flag)
                    {
                        num2 = applicableTaxes.Sum((TaxDetailInfo x) => x.TaxPercentage).ToDouble(false);
                    }
                    if (!taxConfigData.IsTaxEnabled)
                    {
                        goto IL_1CC;
                    }
                    if (!value)
                    {
                        goto IL_1CB;
                    }
                    double arg_E1_0 = this._totalBillDiscount;
                    while (arg_E1_0 > this.lineItemDiscountTotal)
                    {
                        double num3 = this._totalBillDiscount - this.lineItemDiscountTotal;
                        double arg_118_0 = arg_E1_0 = num;
                        while (8 != 0)
                        {
                            double expr_11B = arg_E1_0 = (arg_118_0 = Math.Round(arg_118_0 + item.NetPrice / (this.totalAmount - this.lineItemDiscountTotal) * num3, 3, MidpointRounding.ToEven));
                            if (!false)
                            {
                                num = expr_11B;
                                goto IL_125;
                            }
                        }
                    }
                IL_125:
                    item.TaxPercent = new double?(Convert.ToDouble(num2));
                    flag = !taxConfigData.IsTaxIncluded;
                    if (!flag)
                    {
                        break;
                    }
                    item.TaxAmount = (item.NetPrice - num) * num2 / 100.0;
                    item.NetPrice = item.NetPrice;
                    if (3 != 0)
                    {
                        goto Block_11;
                    }
                }
                item.TaxAmount = (item.NetPrice - num) * num2 / (100.0 + num2);
            IL_16A:
                item.IsTaxIncluded = new bool?(true);
                if (7 == 0)
                {
                    goto IL_6E;
                }
            IL_17F:
                if (!false)
                {
                    goto IL_1CA;
                }
                goto IL_16A;
            Block_11:
                item.IsTaxIncluded = new bool?(false);
                if (4 == 0)
                {
                    goto IL_17F;
                }
            IL_1CA:
            IL_1CB:
            IL_1CC: ;
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private double GetTotalTax()
        {
            double num = 0.0;
            try
            {
                List<TaxDetailInfo> applicableTaxes=null;
                bool value=false;
                IEnumerable<LineItem> enumerable = from result in this.ImagesToPrint
                                                   where result.ParentID == result.ItemNumber
                                                   select result;
                double num2 = 0.0;
                IEnumerator<LineItem> enumerator = enumerable.GetEnumerator();
                try
                {
                    while (true)
                    {
                        LineItem current;
                        bool arg_76_0;
                        if (enumerator.MoveNext())
                        {
                            current = enumerator.Current;
                            arg_76_0 = current.IsPackage;
                            goto IL_75;
                        }
                        if (!false)
                        {
                            break;
                        }
                        goto IL_1EF;
                        continue;
                    IL_75:
                        StoreInfo storeInfo;
                        double num3;
                        if (arg_76_0)
                        {
                            storeInfo = new StoreInfo();
                            TaxBusiness taxBusiness = new TaxBusiness();
                            ProductBusiness productBusiness = new ProductBusiness();
                             applicableTaxes = taxBusiness.GetApplicableTaxes(0);
                            storeInfo = taxBusiness.getTaxConfigData();
                            num3 = 0.0;
                            this.totalAmount = enumerable.Sum((LineItem x) => x.TotalPrice);
                             value = productBusiness.GetProductByID(current.SelectedProductType_ID).DG_IsTaxEnabled.Value;
                            goto IL_FD;
                        }
                        continue;
                       
                    IL_FD:
                        this.lineItemDiscountTotal = enumerable.Sum((LineItem x) => x.TotalDiscountAmount);
                        if (storeInfo.IsTaxEnabled)
                        {
                            goto IL_131;
                        }
                        bool arg_13C_0 = true;
                    IL_13B:
                        bool flag = arg_13C_0;
                        if (!false)
                        {
                            if (flag)
                            {
                                continue;
                            }
                            while (3 == 0)
                            {
                            }
                           // List<TaxDetailInfo> applicableTaxes;
                            bool arg_167_0;
                            if (applicableTaxes != null)
                            {
                                bool expr_158 = arg_76_0 = (applicableTaxes.Count > 0);
                                if (7 == 0)
                                {
                                    goto IL_75;
                                }
                                arg_167_0 = !expr_158;
                            }
                            else
                            {
                                arg_167_0 = true;
                            }
                            if (!arg_167_0)
                            {
                                num2 = applicableTaxes.Sum((TaxDetailInfo x) => x.TaxPercentage).ToDouble(false);
                            }
                            //bool value;
                            if (!value)
                            {
                                continue;
                            }
                            if (this._totalBillDiscount > this.lineItemDiscountTotal)
                            {
                                double num4 = this._totalBillDiscount - this.lineItemDiscountTotal;
                                num3 = Math.Round(num3 + current.NetPrice / (this.totalAmount - this.lineItemDiscountTotal) * num4, 2);
                                goto IL_1EF;
                            }
                            goto IL_1F6;
                        }
                    IL_131:
                        arg_13C_0 = storeInfo.IsTaxIncluded;
                        goto IL_13B;
                    IL_1F6:
                        num += (current.NetPrice - num3) * num2 / 100.0;
                        continue;
                    IL_1EF:
                        if (!false)
                        {
                            goto IL_1F6;
                        }
                        goto IL_FD;
                    }
                }
                finally
                {
                    bool arg_233_0;
                    bool expr_22A = arg_233_0 = (enumerator == null);
                    if (!false)
                    {
                        bool flag = expr_22A;
                        arg_233_0 = flag;
                    }
                    if (!arg_233_0)
                    {
                        enumerator.Dispose();
                    }
                }
                while (7 == 0)
                {
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            return num;
        }

        private void InitiateBurnOrders()
        {
            if (4 == 0)
            {
                goto IL_4E;
            }
            bool arg_13_0;
            bool expr_04 = arg_13_0 = BurnOrderElements.isExecuting;
            if (4 != 0 && true)
            {
                bool flag = expr_04;
                arg_13_0 = flag;
            }
            if (arg_13_0)
            {
                return;
            }
            this.closeExistingBurnOrderWindows();
        IL_1A:
            BurnMediaOrderList burnMediaOrderList = new BurnMediaOrderList();
            burnMediaOrderList.Width = 0.0;
            if (5 == 0)
            {
                return;
            }
            burnMediaOrderList.Height = 0.0;
            burnMediaOrderList.WindowState = WindowState.Minimized;
        IL_4E:
            burnMediaOrderList.Show();
            burnMediaOrderList.Hide();
            burnMediaOrderList._isAutoStart = true;
            burnMediaOrderList.AutoExecuteOrders();
            if (2 == 0)
            {
                goto IL_1A;
            }
        }

        private void closeExistingBurnOrderWindows()
        {
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window.Title == "BurnMedia")
                {
                    window.Close();
                }
            }
        }

        private void PrintSlip(string ordernumber, string ItemDetails, double TotalPercentage, double Discount, double NetPrice, string photos, List<LinetItemsDetails> Billdetails, string PaymentType, string Cardnumber, string CardHoldername, string Customername, string Hotelname, string Roomno, string Voucherno, int OrderID)
        {
            try
            {
                int count = 0;
                if (6 == 0)
                {
                    goto IL_12A;
                }
                string[] source = photos.Split(new char[]
				{
					','
				});
                List<string> list = new List<string>();
                List<PhotoInfo> photoRFIDByPhotoIDList = new PhotoBusiness().GetPhotoRFIDByPhotoIDList(photos);
                if (photoRFIDByPhotoIDList == null)
                {
                    goto IL_134;
                }
            IL_56:
                using (List<PhotoInfo>.Enumerator enumerator = photoRFIDByPhotoIDList.GetEnumerator())
                {
                    while (true)
                    {
                        int arg_B7_0;
                        bool expr_107 = (arg_B7_0 = (enumerator.MoveNext() ? 1 : 0)) != 0;
                        if (3 == 0)
                        {
                            goto IL_B6;
                        }
                        if (!expr_107)
                        {
                            break;
                        }
                        PhotoInfo img = enumerator.Current;
                        if (img != null)
                        {
                             count = source.Where(delegate(string t)
                            {
                                bool arg_29_0;
                                bool flag;
                                while (true)
                                {
                                    if (!false)
                                    {
                                        string arg_48_0 = t.ToString();
                                        int expr_37 = img.DG_Photos_pkey;
                                        int num;
                                        if (5 != 0)
                                        {
                                            num = expr_37;
                                        }
                                        bool expr_48 = arg_29_0 = (arg_48_0 == num.ToString());
                                        if (-1 == 0)
                                        {
                                            return arg_29_0;
                                        }
                                        flag = expr_48;
                                    }
                                    while (!false)
                                    {
                                        if (2 != 0)
                                        {
                                            goto Block_3;
                                        }
                                    }
                                }
                            Block_3:
                                arg_29_0 = flag;
                                return arg_29_0;
                            }).ToList<string>().Count;
                            arg_B7_0 = count;
                            goto IL_B6;
                        }
                        continue;
                    IL_B6:
                        if (arg_B7_0 == 1)
                        {
                            list.Add(img.DG_Photos_RFID);
                        }
                        else if (3 != 0)
                        {
                           // int count;
                            list.Add("(" + img.DG_Photos_RFID + ")X" + count.ToString());
                        }
                    }
                }
            IL_12A:
                if (false)
                {
                    goto IL_56;
                }
                if (!true)
                {
                    goto IL_1AE;
                }
            IL_134:
                string text = string.Empty;
                foreach (string current in list)
                {
                    if (text == string.Empty)
                    {
                        text = current;
                    }
                    else
                    {
                        text = text + ", " + current;
                    }
                }
                if (!this._isEnableSlipPrint)
                {
                    goto IL_232;
                }
            IL_1AE:
                TestBill testBill = new TestBill(LoginUser.SubstoreName.ToString(), LoginUser.UserName.ToString(), ordernumber, text, new RefundBusiness().GetRefundText(), Math.Round(this._totalBillAmount, 2).ToString(), Math.Round(this._totalCashAmount, 2).ToString(), Math.Round(this._totalBalanceAmount, 2).ToString(), Billdetails, PaymentType, Cardnumber, CardHoldername, Customername, Hotelname, Roomno, Voucherno, this.DefaultCurrency, OrderID, false);
            IL_232: ;
            }
            catch (Exception serviceException)
            {
                do
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (false);
            }
            while (6 == 0)
            {
            }
        }

        private void AddToPrintQueue(LineItem liItem, int OrderDetailID, List<PhotoPrintPositionDic> PhotoPrintPositionDicList)
        {
            do
            {
                try
                {
                    do
                    {
                        int num = new PrinterBusniess().AddImageToPrinterQueue(
                            liItem.SelectedProductType_ID, liItem.SelectedImages, 
                            OrderDetailID, liItem.IsBundled, false, 
                            PhotoPrintPositionDicList, LoginUser.MasterTemplateId);
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
                                goto Block_5;
                            }
                        }
                    }
                Block_5: ;
                }
                while (false)
                {
                }
            }
            while (6 == 0);
        }

        private void AddToPrintQueue(LineItem liItem, int OrderDetailID, List<string> currentImages, List<PhotoPrintPositionDic> PhotoPrintPositionDicList)
        {
            if (7 != 0 && !false)
            {
                try
                {
                    while (true)
                    {
                        new PrinterBusniess().AddImageToPrinterQueue(liItem.SelectedProductType_ID, currentImages, OrderDetailID, liItem.IsBundled, false, PhotoPrintPositionDicList, 1);
                        while (!false)
                        {
                            if (7 != 0)
                            {
                                goto Block_4;
                            }
                        }
                    }
                Block_4: ;
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (-1 == 0);
                }
            }
        }

        private bool CheckCDAvailable()
        {
            int arg_3E_0;
            bool result;
            while (!false)
            {
                if (!false)
                {
                    DriveInfo[] drives = DriveInfo.GetDrives();
                    (from t in drives
                     where t.DriveType == DriveType.CDRom
                     select t).FirstOrDefault<DriveInfo>();
                    bool flag = drives == null;
                    if (5 == 0)
                    {
                        continue;
                    }
                    arg_3E_0 = (flag ? 1 : 0);
                IL_3E:
                    if (arg_3E_0 != 0)
                    {
                        break;
                    }
                    result = true;
                }
                return result;
            }
            int expr_45 = arg_3E_0 = 0;
            if (expr_45 != 0)
            {
                //goto IL_3E;
            }
            result = (expr_45 != 0);
            if (8 != 0)
            {
                return result;
            }
            return result;
        }

        private bool CheckUSBAvailable()
        {
            bool result;
            int expr_45;
            while (true)
            {
                if (false)
                {
                    goto IL_44;
                }
                if (false)
                {
                    return result;
                }
                IEnumerable<DriveInfo> source = DriveInfo.GetDrives().Where(delegate(DriveInfo drive)
                {
                    if (drive.DriveType == DriveType.Removable)
                    {
                        goto IL_21;
                    }
                IL_07:
                    if (!false && drive.DriveType != DriveType.Fixed)
                    {
                        goto IL_2A;
                    }
                IL_11:
                    if (6 != 0 && !(drive.DriveFormat == "FAT32"))
                    {
                        goto IL_2A;
                    }
                IL_21:
                    int arg_2F_0;
                    bool arg_36_0;
                    if (6 != 0)
                    {
                        arg_36_0 = ((arg_2F_0 = (drive.IsReady ? 1 : 0)) != 0);
                        goto IL_2B;
                    }
                    goto IL_07;
                IL_2A:
                    arg_36_0 = ((arg_2F_0 = 0) != 0);
                IL_2B:
                    if (!false)
                    {
                        bool flag2 = arg_2F_0 != 0;
                        if (-1 == 0)
                        {
                            goto IL_11;
                        }
                        arg_36_0 = flag2;
                    }
                    return arg_36_0;
                });
                int arg_34_0 = (source.Count<DriveInfo>() > 0) ? 1 : 0;
            IL_33:
                bool flag = arg_34_0 == 0;
                if (5 == 0)
                {
                    continue;
                }
                if (!flag)
                {
                    break;
                }
            IL_44:
                expr_45 = (arg_34_0 = 0);
                if (expr_45 == 0)
                {
                    goto Block_5;
                }
                goto IL_33;
            }
            result = true;
            return result;
        Block_5:
            result = (expr_45 != 0);
            if (8 != 0)
            {
            }
            return result;
        }

        private void CalculateSummary()
        {
            try
            {
                int num = 0;
                double num2 = 0.0;
                double num3 = 0.0;
                IEnumerator<PaymentItem> enumerator = this._objPayment.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        PaymentItem arg_D2_0 = enumerator.Current;
                        DataGridRow dataGridRow = (DataGridRow)this.dgPayment.ItemContainerGenerator.ContainerFromIndex(num);
                        bool flag = dataGridRow == null;
                        bool arg_6C_0 = flag;
                        while (!arg_6C_0)
                        {
                            TextBlock textBlock = this.FindByName("txtNetPrice", dataGridRow) as TextBlock;
                            double num4;
                            flag = !double.TryParse(textBlock.Text, out num4);
                            bool expr_96 = arg_6C_0 = flag;
                            if (true)
                            {
                                if (!expr_96)
                                {
                                    num2 += num4;
                                    num3 += num4;
                                }
                                break;
                            }
                        }
                        num++;
                    }
                }
                finally
                {
                    do
                    {
                        bool flag = enumerator == null;
                        do
                        {
                            if (!false)
                            {
                                if (flag)
                                {
                                    break;
                                }
                                enumerator.Dispose();
                            }
                        }
                        while (false);
                    }
                    while (3 == 0);
                }
                num = 0;
                foreach (PaymentItem current in this._objCardPayment)
                {
                    DataGridRow dataGridRow = (DataGridRow)this.dgCardPayment.ItemContainerGenerator.ContainerFromIndex(num);
                    if (dataGridRow != null)
                    {
                        System.Windows.Controls.TextBox textBox = this.FindByName("txtAmountEntered", dataGridRow) as System.Windows.Controls.TextBox;
                        double num4;
                        //PaymentItem current;
                        if (double.TryParse(current.PaidAmount.ToString(), out num4))
                        {
                            num2 += num4;
                            num3 += num4;
                        }
                    }
                    num++;
                }
                num = 0;
                bool arg_549_0;
                if (!false)
                {
                    foreach (PaymentItem current in this._objRoomPayment)
                    {
                        DataGridRow dataGridRow = (DataGridRow)this.dgRoomPayment.ItemContainerGenerator.ContainerFromIndex(num);
                        if (dataGridRow != null)
                        {
                            if (8 != 0)
                            {
                            }
                            System.Windows.Controls.TextBox textBox = this.FindByName("txtNetPrice", dataGridRow) as System.Windows.Controls.TextBox;
                            double num4;
                          //  PaymentItem current;
                            if (double.TryParse(current.PaidAmount.ToString(), out num4))
                            {
                                num2 += num4;
                            }
                        }
                        num++;
                    }
                    num = 0;
                    foreach (PaymentItem current in this._objVoucherPayment)
                    {
                        DataGridRow dataGridRow = (DataGridRow)this.dgVoucherPayment.ItemContainerGenerator.ContainerFromIndex(num);
                        if (dataGridRow != null)
                        {
                            System.Windows.Controls.TextBox textBox = this.FindByName("txtNetPrice", dataGridRow) as System.Windows.Controls.TextBox;
                            //PaymentItem current;
                            double arg_2C7_0;
                            double expr_2A2 = arg_2C7_0 = current.PaidAmount;
                            if (2 == 0)
                            {
                                goto IL_2C7;
                            }
                            double num5 = expr_2A2;
                            double num4;
                            if (double.TryParse(num5.ToString(), out num4))
                            {
                                arg_2C7_0 = num2 + num4;
                                goto IL_2C7;
                            }
                            goto IL_2C9;
                        IL_2C7:
                            num2 = arg_2C7_0;
                        }
                    IL_2C9:
                        num++;
                    }
                    num = 0;
                    //using (IEnumerator<PaymentItem> enumerator = this._objKVLPayment.GetEnumerator())
                    IEnumerator<PaymentItem> enumerator1 = this._objKVLPayment.GetEnumerator();
                    try
                    {
                        while (enumerator1.MoveNext() && !false)
                        {
                            PaymentItem current = enumerator1.Current;
                            DataGridRow dataGridRow = (DataGridRow)this.dgKVLPayment.ItemContainerGenerator.ContainerFromIndex(num);
                            if (dataGridRow != null)
                            {
                                System.Windows.Controls.TextBox textBox = this.FindByName("txtNetPrice", dataGridRow) as System.Windows.Controls.TextBox;
                                double num4;
                                if (double.TryParse(current.PaidAmount.ToString(), out num4))
                                {
                                    num2 += num4;
                                }
                            }
                            num++;
                        }
                    }
                    catch { throw; }
                    finally
                    {
                    }
                    this._totalGrandAmount = this._totalCardAmount + num2;
                    this._totalCashAmount = num2;
                    this._totalBalanceAmount = Math.Round(this._totalBillAmount - this._totalGrandAmount, 2);
                    bool flag = this._totalBalanceAmount < 0.0;
                    bool expr_3E0 = arg_549_0 = flag;
                    if (7 == 0)
                    {
                        goto IL_549;
                    }
                    if (!expr_3E0)
                    {
                        this.txtBalance.Text = this.DefaultCurrency + " " + this._totalBalanceAmount.ToString("N2");
                    }
                    else
                    {
                        this.txtBalance.Text = this.DefaultCurrency + " " + ((Math.Abs(this._totalBalanceAmount) > num3) ? ("-" + num3.ToString("N2")) : this._totalBalanceAmount.ToString("N2"));
                    }
                    this.txtPaid.Text = this.DefaultCurrency + " " + this._totalGrandAmount.ToString("N2");
                    if (this._totalBalanceAmount > 0.0)
                    {
                        this.tbAmount.Text = this._totalBalanceAmount.ToString("N2");
                    }
                    else
                    {
                        this.tbAmount.Text = "0.00";
                    }
                    if (this._totalBalanceAmount > 0.0)
                    {
                        this.tbName1.Text = this._totalBalanceAmount.ToString("N2");
                    }
                    else
                    {
                        this.tbName1.Text = "0.00";
                    }
                }
                arg_549_0 = (this._totalBalanceAmount <= 0.0);
            IL_549:
                if (!arg_549_0)
                {
                    this.tbKVL.Text = this._totalBalanceAmount.ToString("N2");
                }
                else
                {
                    this.tbKVL.Text = "0.00";
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void AddNewRow(string result)
        {
            try
            {
                bool expr_12 = result.IndexOf("%#%") < 0;
                bool flag;
                if (!false)
                {
                    flag = expr_12;
                }
                if (!flag)
                {
                    string[] array = new string[]
					{
						"%#%"
					};
                    string[] data;
                    PaymentItem objItem;
                    do
                    {
                        string[] separator = array;
                        data = result.Split(separator, StringSplitOptions.None);
                        objItem = new PaymentItem();
                        string itemNumber = Guid.NewGuid().ToString();
                        objItem.ItemNumber = itemNumber;
                        objItem.CurrencyList = this._lstCurrency;
                        do
                        {
                            objItem.PaidAmount = data[1].ToDouble(false);
                            objItem.Currency = data[0].ToInt32(false);
                        }
                        while (!true);
                        objItem.CurrencySyncCode = this._lstCurrency.FindAll((CurrencyInfo c) => c.DG_Currency_pkey == objItem.Currency).ToList<CurrencyInfo>().FirstOrDefault<CurrencyInfo>().SyncCode;
                        objItem.CurrencyCode = this._lstCurrency.FindAll((CurrencyInfo c) => c.DG_Currency_pkey == objItem.Currency).ToList<CurrencyInfo>().FirstOrDefault<CurrencyInfo>().DG_Currency_Code;
                        this._objPayment.Add(objItem);
                        this.dgPayment.UpdateLayout();
                    }
                    while (2 == 0);
                    DataGridRow dataGridRow = (DataGridRow)this.dgPayment.ItemContainerGenerator.ContainerFromIndex(this._objPayment.Count - 1);
                    flag = (dataGridRow == null);
                    if (!flag)
                    {
                        string text = (from currlist in this._lstCurrency.Where(delegate(CurrencyInfo currlist)
                        {
                            bool arg_26_0;
                            bool flag2;
                            while (true)
                            {
                                if (!false)
                                {
                                    bool expr_13 = arg_26_0 = (currlist.DG_Currency_pkey == data[0].ToInt32(false));
                                    if (-1 == 0)
                                    {
                                        return arg_26_0;
                                    }
                                    if (5 != 0)
                                    {
                                        flag2 = expr_13;
                                    }
                                }
                                while (!false)
                                {
                                    if (2 != 0)
                                    {
                                        goto Block_3;
                                    }
                                }
                            }
                        Block_3:
                            arg_26_0 = flag2;
                            return arg_26_0;
                        })
                                       select currlist.DG_Currency_Symbol).FirstOrDefault<string>();
                        TextBlock textBlock = this.FindByName("txtAmountEntered", dataGridRow) as TextBlock;
                        textBlock.Text = text.ToString() + " " + Math.Round(data[1].ToDouble(false), 2).ToString("N2");
                        TextBlock textBlock2 = this.FindByName("txtNetPrice", dataGridRow) as TextBlock;
                        textBlock2.Text = Math.Round(this.ConvertToDefault(data[0].ToInt32(false), data[1].ToDouble(false)), 2).ToString("N2");
                        TextBlock textBlock3 = this.FindByName("txtCurrencyID", dataGridRow) as TextBlock;
                        textBlock3.Text = data[0].ToString();
                    }
                    this.CalculateSummary();
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        protected void AddNewCard(string result)
        {
            try
            {
                if (result.IndexOf("%##%") >= 0)
                {
                    string[] separator = new string[]
					{
						"%##%"
					};
                    string[] array = result.Split(separator, StringSplitOptions.None);
                    CurrencyInfo currencyInfo = this._lstCurrency.Where(delegate(CurrencyInfo currlist)
                    {
                        int arg_16_0 = currlist.DG_Currency_pkey;
                        bool expr_3F;
                        while (true)
                        {
                            int arg_0B_0 = this._defaultCurrencyId;
                            int expr_35;
                            do
                            {
                                expr_35 = (arg_0B_0 = arg_0B_0.ToInt32(false));
                            }
                            while (false);
                            bool expr_16 = (arg_16_0 = ((arg_16_0 == expr_35) ? 1 : 0)) != 0;
                            if (7 != 0 && 8 != 0)
                            {
                                bool flag = expr_16;
                                expr_3F = ((arg_16_0 = (flag ? 1 : 0)) != 0);
                                if (!false)
                                {
                                    break;
                                }
                            }
                        }
                        return expr_3F;
                    }).FirstOrDefault<CurrencyInfo>();
                    PaymentItem paymentItem = new PaymentItem();
                    string itemNumber = Guid.NewGuid().ToString();
                    paymentItem.ItemNumber = itemNumber;
                    paymentItem.CurrencyList = this._lstCurrency;
                    paymentItem.CardType = array[0].ToString();
                    paymentItem.CardYear = array[1].ToString();
                    paymentItem.CardMonth = array[2].ToString();
                    paymentItem.CardNumber = array[3].ToString();
                    paymentItem.PaidAmount = array[4].ToString().ToDouble(false);
                    paymentItem.Currency = this._defaultCurrencyId.ToInt32(false);
                    paymentItem.CurrencySyncCode = currencyInfo.SyncCode;
                    paymentItem.CurrencyName = currencyInfo.DG_Currency_Symbol;
                    paymentItem.CardExpiryDate = array[2].ToString() + "/" + array[1].ToString();
                    this._objCardPayment.Add(paymentItem);
                    this.dgCardPayment.UpdateLayout();
                    DataGridRow dataGridRow = (DataGridRow)this.dgCardPayment.ItemContainerGenerator.ContainerFromIndex(this._objCardPayment.Count - 1);
                    if (dataGridRow != null)
                    {
                        TextBlock textBlock = this.FindByName("txtAmountEntered", dataGridRow) as TextBlock;
                        textBlock.Text = currencyInfo.DG_Currency_Symbol.ToString() + " " + Math.Round(array[4].ToDouble(false), 2).ToString("N2");
                    }
                    this.CalculateSummary();
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private double ConvertToDefault(int currencyid, double ToBeConverted)
        {
            double num;
            double arg_70_0;
            int arg_70_1;
            double arg_79_0;
            if (!false)
            {
                num = 0.0;
                CurrencyInfo currencyInfo = (from rate in this._lstCurrency
                                             where rate.DG_Currency_pkey == currencyid
                                             select rate).FirstOrDefault<CurrencyInfo>();
                bool arg_4B_0 = currencyInfo == null;
                bool expr_4D;
                do
                {
                    bool flag = arg_4B_0;
                    expr_4D = (arg_4B_0 = flag);
                }
                while (false || false);
                if (!expr_4D)
                {
                    double expr_5F = arg_70_0 = ToBeConverted / (double)currencyInfo.DG_Currency_Rate;
                    int expr_61 = arg_70_1 = 2;
                    if (expr_61 == 0)
                    {
                        goto IL_6F;
                    }
                    double expr_64 = arg_79_0 = Math.Round(expr_5F, expr_61);
                    if (6 == 0)
                    {
                        return arg_79_0;
                    }
                    num = expr_64;
                }
            }
            arg_70_0 = num;
            arg_70_1 = 3;
        IL_6F:
            double num2 = Math.Round(arg_70_0, arg_70_1, MidpointRounding.ToEven);
            arg_79_0 = num2;
            return arg_79_0;
        }

        private void ClearResources()
        {
            RobotImageLoader.PrintImages.Clear();
            RobotImageLoader.robotImages.Clear();
            this.ImagesToPrint.Clear();
            this._lstCurrency = null;
            this._objPayment.Clear();
            if (!false)
            {
                this._objCardPayment.Clear();
                this.SourceParent = null;
                if (7 != 0)
                {
                    this.btnExit.Click -= new RoutedEventHandler(this.btnExit_Click);
                }
                this.btnNextsimg.Click -= new RoutedEventHandler(this.btnNextsimg_Click);
                this.btnPreviousimg_Copy.Click -= new RoutedEventHandler(this.btnPreviousimg_Click);
                //using (IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator())
                IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator();
                try
                {
                    if (4 != 0)
                    {
                        goto IL_135;
                    }
                    goto IL_E8;
                IL_CD:
                    Window window;
                    bool arg_11E_0;
                    int expr_D9 = (arg_11E_0 = (window.Title == "Select Printer")) ? 1 : 0;
                    int arg_11E_1;
                    int expr_DF = arg_11E_1 = 0;
                    if (expr_DF != 0)
                    {
                        goto IL_11E;
                    }
                    if (expr_D9 == expr_DF)
                    {
                        goto IL_EF;
                    }
                IL_E8:
                    window.Close();
                IL_EF:
                    if (window.Title == "PlaceOrder")
                    {
                        window.Close();
                    }
                IL_10D:
                    arg_11E_0 = (window.Title == "TestBill");
                    arg_11E_1 = 0;
                IL_11E:
                    bool flag = (arg_11E_0 ? 1 : 0) == arg_11E_1;
                    if (!flag)
                    {
                        if (7 == 0)
                        {
                            goto IL_10D;
                        }
                        window.Close();
                    }
                    if (false)
                    {
                        goto IL_13C;
                    }
                    if (false)
                    {
                        goto IL_CD;
                    }
                IL_135:
                    flag = enumerator.MoveNext();
                IL_13C:
                    if (flag)
                    {
                        window = (Window)enumerator.Current;
                        goto IL_CD;
                    }
                }
                catch { throw; }
                    finally{
                }
            }
            GC.Collect();
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

        private void ShowPaymentScreenToClient()
        {
            try
            {
                VisualBrush compiledBitmapImage = new VisualBrush(this.sart);
                SearchResult searchResult = null;
                IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator();
                //goto IL_31;
                try
                {
                    while (true)
                    {
                    IL_31:
                        while (true)
                        {
                            bool flag = enumerator.MoveNext();
                            if (!flag)
                            {
                                goto Block_7;
                            }
                            if (!false)
                            {
                                Window window = (Window)enumerator.Current;
                                flag = !(window.Title == "View/Order Station");
                                if (!flag)
                                {
                                    searchResult = (SearchResult)window;
                                }
                            }
                        }
                    }
                Block_7: ;
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    bool arg_8F_0;
                    bool expr_86 = arg_8F_0 = (disposable == null);
                    if (6 == 0)
                    {
                        goto IL_8F;
                    }
                    bool flag = expr_86;
                IL_8D:
                    arg_8F_0 = flag;
                IL_8F:
                    if (!arg_8F_0)
                    {
                        disposable.Dispose();
                        if (false)
                        {
                            goto IL_8D;
                        }
                    }
                }
                do
                {
                    bool flag = searchResult != null;
                    if (!flag)
                    {
                        searchResult = new SearchResult(true);
                    }
                }
                while (false);
                searchResult.CompileEffectChanged(compiledBitmapImage, -1);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                do
                {
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    if (4 != 0)
                    {
                    }
                }
                while (3 == 0);
            }
        }

        public void ShowPopup()
        {
            int arg_4B_0;
            bool arg_77_0;
            if (this._card)
            {
                arg_77_0 = ((arg_4B_0 = (this._cash ? 1 : 0)) != 0);
                goto IL_17;
            }
        IL_16:
            arg_77_0 = ((arg_4B_0 = 1) != 0);
        IL_17:
            bool flag;
            bool arg_51_0;
            if (7 != 0)
            {
                flag = arg_77_0;
                if (false)
                {
                    goto IL_16;
                }
                if (!flag)
                {
                    this.btnAddMore1_Click(this.btnAddMore1, new RoutedEventArgs());
                }
                if (this._card)
                {
                    arg_51_0 = true;
                    goto IL_50;
                }
                if (false)
                {
                    return;
                }
                if (false)
                {
                    goto IL_52;
                }
                arg_4B_0 = (this._cash ? 1 : 0);
            }
            arg_51_0 = (arg_4B_0 == 0);
        IL_50:
            flag = arg_51_0;
        IL_52:
            if (6 != 0 && !flag)
            {
                this.btnAddMore_Click(this.btnAddMore, new RoutedEventArgs());
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                    this.InitializeValue();
                }
                while (true)
                {
                    this._lstCurrency = new CurrencyBusiness().GetCurrencyOnly();
                    if (7 == 0)
                    {
                        break;
                    }
                    if (8 != 0)
                    {
                        if (!false)
                        {
                            this.burnLoadimage();
                        }
                        if (!false)
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void btnNextsimg_Click(object sender, RoutedEventArgs e)
        {
            this.btnNextsimg.IsEnabled = false;
            string empty = string.Empty;
            string text;
            int arg_111_0;
            int arg_111_1;
            SearchResult searchResult = null;
            if (!this.SaveOrder(out text, ref empty) && !(empty == "OrderPlaced"))
            {
                bool arg_206_0;
                if (!(empty == "CARDFAILED"))
                {
                    int expr_1EE = arg_111_0 = ((empty == "PAYREMAINING") ? 1 : 0);
                    int expr_1F4 = arg_111_1 = 0;
                    if (expr_1F4 != 0)
                    {
                        goto IL_111;
                    }
                    arg_206_0 = (expr_1EE == expr_1F4);
                }
                else
                {
                    if (false)
                    {
                        goto IL_100;
                    }
                    arg_206_0 = false;
                }
                if (!arg_206_0)
                {
                    if (7 != 0)
                    {
                        this.btnNextsimg.IsEnabled = true;
                        if (2 != 0)
                        {
                            return;
                        }
                        //goto IL_52;
                    }
                }
                else if (!string.IsNullOrEmpty(empty))
                {
                    return;
                }
                System.Windows.MessageBox.Show("There is some error in placing order. Please place order again.");
                return;
            }

           
            IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    Window window = (Window)enumerator.Current;
                    if (window.Title == "View/Order Station")
                    {
                        searchResult = (SearchResult)window;
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (7 == 0 || disposable != null)
                {
                    if (3 != 0)
                    {
                        disposable.Dispose();
                    }
                }
            }
            if (searchResult == null)
            {
                searchResult = new SearchResult();
            }
            if (RobotImageLoader.GroupImages.Count > 0)
            {
                searchResult.pagename = "MainGroup";
                goto IL_148;
            }
        IL_100:
            if (4 == 0)
            {
                return;
            }
            arg_111_0 = RobotImageLoader.PrintImages.Count;
            arg_111_1 = 0;
        IL_111:
            if (arg_111_0 > arg_111_1)
            {
                searchResult.pagename = "Placeback";
                searchResult.Savebackpid = RobotImageLoader.PrintImages[0].PhotoId.ToString();
            }
        IL_148:
            List<LstMyItems> list = (from pb in RobotImageLoader.GroupImages
                                     where pb.PrintGroup.UriSource.ToString() == "/images/print-accept.png"
                                     select pb).ToList<LstMyItems>();
            for (int i = 0; i < list.Count; i++)
            {
                list[i].PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
            }
            this.ClearResources();
            searchResult.Show();
            searchResult.flgViewScrl = true;
            searchResult.LoadWindow();
            base.Close();
        }

        private void btnPreviousimg_Click(object sender, RoutedEventArgs e)
        {
            bool flag = !(this.SourceParent is SelectPrinter);
            bool arg_8D_0;
            bool arg_49_0;
            bool expr_FF = arg_49_0 = (arg_8D_0 = flag);
            if (6 == 0)
            {
                goto IL_71;
            }
            SelectPrinter selectPrinter;
            if (8 != 0)
            {
                if (expr_FF)
                {
                    goto IL_7B;
                }
                selectPrinter = (SelectPrinter)this.SourceParent;
                arg_8D_0 = (arg_49_0 = (selectPrinter == null));
            }
            int arg_8D_1;
            int expr_46 = arg_8D_1 = 0;
            if (expr_46 != 0)
            {
                goto IL_8D;
            }
            flag = ((arg_49_0 ? 1 : 0) == expr_46);
            bool arg_51_0 = flag;
        IL_51:
            if (arg_51_0)
            {
                selectPrinter.Visibility = Visibility.Visible;
                selectPrinter.Focus();
                goto IL_71;
            }
            base.Close();
        IL_59:
            if (!false)
            {
                goto IL_7A;
            }
            return;
        IL_71:
            base.Close();
        IL_7A:
        IL_7B:
            arg_8D_0 = (arg_51_0 = (this.SourceParent is PlaceOrder));
            if (false)
            {
                goto IL_51;
            }
            arg_8D_1 = 0;
        IL_8D:
            if ((arg_8D_0 ? 1 : 0) != arg_8D_1)
            {
                PlaceOrder placeOrder = (PlaceOrder)this.SourceParent;
                if (placeOrder == null)
                {
                    base.Close();
                    if (6 == 0)
                    {
                        goto IL_59;
                    }
                }
                else
                {
                    placeOrder.CtrlSelectedQrCode.QRCode = string.Empty;
                    placeOrder.Visibility = Visibility.Visible;
                    placeOrder.Focus();
                    base.Close();
                }
            }
            base.Close();
        }

        private void btndelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PaymentItem paymentItem;
                PaymentItem toBeDeleteditem;
                do
                {
                    toBeDeleteditem = (PaymentItem)this.dgPayment.CurrentItem;
                    paymentItem = this._objPayment.Where(delegate(PaymentItem lineitem)
                    {
                        bool result;
                        do
                        {
                            if (true && !false)
                            {
                                result = (lineitem.ItemNumber == toBeDeleteditem.ItemNumber.ToString());
                            }
                            while (false)
                            {
                            }
                        }
                        while (8 == 0);
                        return result;
                    }).FirstOrDefault<PaymentItem>();
                }
                while (!true);
                bool flag = paymentItem == null;
                bool arg_51_0 = flag;
                if (2 != 0 && !false)
                {
                    if (!arg_51_0)
                    {
                        this._objPayment.Remove(paymentItem);
                    }
                }
                this.CalculateSummary();
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                }
                do
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (6 == 0);
            }
        }

        private void btnCarddelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PaymentItem paymentItem;
                PaymentItem ToBeDeleteditem;
                do
                {
                    ToBeDeleteditem = (PaymentItem)this.dgCardPayment.CurrentItem;
                    paymentItem = this._objCardPayment.Where(delegate(PaymentItem lineitem)
                    {
                        bool result;
                        do
                        {
                            if (true && !false)
                            {
                                result = (lineitem.ItemNumber == ToBeDeleteditem.ItemNumber.ToString());
                            }
                            while (false)
                            {
                            }
                        }
                        while (8 == 0);
                        return result;
                    }).FirstOrDefault<PaymentItem>();
                }
                while (!true);
                bool flag = paymentItem == null;
                bool arg_51_0 = flag;
                if (2 != 0 && !false)
                {
                    if (!arg_51_0)
                    {
                        this._objCardPayment.Remove(paymentItem);
                    }
                }
                this.CalculateSummary();
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                }
                do
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (6 == 0);
            }
        }

        private void btndeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PaymentItem paymentItem;
                PaymentItem ToBeDeleteditem;
                do
                {
                    ToBeDeleteditem = (PaymentItem)this.dgRoomPayment.CurrentItem;
                    paymentItem = this._objRoomPayment.Where(delegate(PaymentItem lineitem)
                    {
                        bool result;
                        do
                        {
                            if (true && !false)
                            {
                                result = (lineitem.ItemNumber == ToBeDeleteditem.ItemNumber.ToString());
                            }
                            while (false)
                            {
                            }
                        }
                        while (8 == 0);
                        return result;
                    }).FirstOrDefault<PaymentItem>();
                }
                while (!true);
                bool flag = paymentItem == null;
                bool arg_51_0 = flag;
                if (2 != 0 && !false)
                {
                    if (!arg_51_0)
                    {
                        this._objRoomPayment.Remove(paymentItem);
                    }
                }
                this.CalculateSummary();
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                }
                do
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (6 == 0);
            }
        }

        private void btndeleteVoucher_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PaymentItem paymentItem;
                PaymentItem ToBeDeleteditem;
                do
                {
                    ToBeDeleteditem = (PaymentItem)this.dgVoucherPayment.CurrentItem;
                    paymentItem = this._objVoucherPayment.Where(delegate(PaymentItem lineitem)
                    {
                        bool result;
                        do
                        {
                            if (true && !false)
                            {
                                result = (lineitem.ItemNumber == ToBeDeleteditem.ItemNumber.ToString());
                            }
                            while (false)
                            {
                            }
                        }
                        while (8 == 0);
                        return result;
                    }).FirstOrDefault<PaymentItem>();
                }
                while (!true);
                bool flag = paymentItem == null;
                bool arg_51_0 = flag;
                if (2 != 0 && !false)
                {
                    if (!arg_51_0)
                    {
                        this._objVoucherPayment.Remove(paymentItem);
                    }
                }
                this.CalculateSummary();
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                }
                do
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (6 == 0);
            }
        }

        private void btndeleteKVL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PaymentItem paymentItem;
                PaymentItem ToBeDeleteditem;
                do
                {
                    ToBeDeleteditem = (PaymentItem)this.dgKVLPayment.CurrentItem;
                    paymentItem = this._objKVLPayment.Where(delegate(PaymentItem lineitem)
                    {
                        bool result;
                        do
                        {
                            if (true && !false)
                            {
                                result = (lineitem.ItemNumber == ToBeDeleteditem.ItemNumber.ToString());
                            }
                            while (false)
                            {
                            }
                        }
                        while (8 == 0);
                        return result;
                    }).FirstOrDefault<PaymentItem>();
                }
                while (!true);
                bool flag = paymentItem == null;
                bool arg_51_0 = flag;
                if (2 != 0 && !false)
                {
                    if (!arg_51_0)
                    {
                        this._objKVLPayment.Remove(paymentItem);
                    }
                }
                this.CalculateSummary();
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                }
                do
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (6 == 0);
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
                    bool expr_4D = arg_27_0 = Payment.IsTextAllowed(text);
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

        private void txtAmountEntered_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Payment.IsTextAllowed(e.Text);
        }

        private void tbKVL_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Payment.IsTextAllowed(e.Text);
        }

        private void tbName1L_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Payment.IsTextAllowed(e.Text);
        }

        private void tbAmount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Payment.IsTextAllowed(e.Text);
        }

        private void txtAmountEntered_TextChanged(object sender, TextChangedEventArgs e)
        {
            DataGridRow dataGridRow = (DataGridRow)this.dgPayment.ItemContainerGenerator.ContainerFromIndex(this.dgPayment.SelectedIndex);
            if (false)
            {
                goto IL_D5;
            }
            bool arg_178_0 = dataGridRow == null;
            bool flag;
            bool arg_D1_0;
            bool expr_17F;
            do
            {
                flag = arg_178_0;
                expr_17F = (arg_D1_0 = (arg_178_0 = flag));
                if (5 == 0)
                {
                    goto IL_D0;
                }
            }
            while (3 == 0);
            if (expr_17F)
            {
                return;
            }
            if (7 == 0)
            {
                goto IL_131;
            }
        IL_6F:
            if (false)
            {
                goto IL_132;
            }
            System.Windows.Controls.TextBox textBox = this.FindByName("txtNetPrice", dataGridRow) as System.Windows.Controls.TextBox;
            System.Windows.Controls.TextBox textBox2 = this.FindByName("txtAmountEntered", dataGridRow) as System.Windows.Controls.TextBox;
            System.Windows.Controls.ComboBox comboBox = this.FindByName("cmbCurrency", dataGridRow) as System.Windows.Controls.ComboBox;
            double num = this._totalBillAmount.ToDouble(false);
            arg_D1_0 = (textBox2.Text != string.Empty);
        IL_D0:
            flag = !arg_D1_0;
        IL_D5:
            if (!flag)
            {
                textBox.Text = this.ConvertToDefault(comboBox.SelectedValue.ToInt32(false), textBox2.Text.ToDouble(false)).ToString("N2");
            }
            else
            {
                textBox.Text = 0.ToString("N2");
            }
        IL_131:
        IL_132:
            this.CalculateSummary();
            if (false)
            {
                goto IL_6F;
            }
        }

        private void btnAddMore_Click(object sender, RoutedEventArgs e)
        {
            this.CtrlCashPayment.SetParent(this);
            do
            {
                this.btnNextsimg.IsDefault = false;
            }
            while (false);
            this.CtrlCashPayment.btnSubmit.IsDefault = true;
            if (4 != 0)
            {
                string text = this.CtrlCashPayment.ShowHandlerDialog("Cash");
                this.btnNextsimg.IsDefault = true;
                this.CtrlCashPayment.btnSubmit.IsDefault = false;
                if (text != null)
                {
                    this.AddNewRow(text);
                }
            }
        }

        private void btnAddMore1_Click(object sender, RoutedEventArgs e)
        {
            this.CtrlCardPayment.SetParent(this);
            this.CtrlCardPayment.DefaultCurrency = this.DefaultCurrency;
            this.CtrlCardPayment.Focus();
            double arg_52_0;
            double arg_68_0 = arg_52_0 = this._totalBalanceAmount;
            double arg_68_1;
            double expr_A1;
            while (true)
            {
                double expr_46 = arg_68_1 = 0.0;
                if (false)
                {
                    goto IL_68;
                }
                if (arg_52_0 >= expr_46)
                {
                    break;
                }
                expr_A1 = (arg_52_0 = (arg_68_0 = this._totalBalanceAmount));
                if (5 != 0)
                {
                    goto Block_4;
                }
            }
            arg_68_0 = this._totalCashAmount;
            arg_68_1 = 0.0;
        IL_68:
            if (arg_68_0 == arg_68_1)
            {
                this.CtrlCardPayment.TotalBillAmount = this._totalBillAmount;
            }
            else
            {
                this.CtrlCardPayment.TotalBillAmount = this._totalBalanceAmount;
                if (!true)
                {
                    goto IL_13D;
                }
            }
        IL_9D:
            goto IL_D5;
        Block_4:
            if (expr_A1 < 0.0)
            {
                this.CtrlCardPayment.TotalBillAmount = 0.0;
                if (2 == 0)
                {
                    goto IL_F8;
                }
            }
        IL_D5:
            if (false)
            {
                goto IL_9D;
            }
            this.CtrlCardPayment.txtAmount.Focus();
            if (!false)
            {
                this.btnNextsimg.IsDefault = false;
            }
        IL_F8:
            string text;
            if (7 != 0)
            {
                this.CtrlCardPayment.btnSubmit.IsDefault = true;
                text = this.CtrlCardPayment.ShowHandlerDialog("Cash");
                this.btnNextsimg.IsDefault = true;
            }
            this.CtrlCardPayment.btnSubmit.IsDefault = false;
        IL_13D:
            if (text != null)
            {
                this.AddNewCard(text);
            }
        }

        private void btnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            bool flag = !(this.tbAmount.Text.Trim() == "") && !(Convert.ToDecimal(this.tbAmount.Text.Trim()) <= 0m);
            CurrencyInfo currencyInfo;
            PaymentItem paymentItem;
            Guid guid;
            if (!false)
            {
                if (!flag)
                {
                    System.Windows.MessageBox.Show("Please enter valid amount first", "DEI");
                    this.tbAmount.Focus();
                    return;
                }
                if (this.tbHotelName.Text.Trim() == "")
                {
                    System.Windows.MessageBox.Show("Please enter hotel name first", "DEI");
                    this.tbHotelName.Focus();
                    return;
                }
                if (this.tbRoomNumber.Text.Trim() == "")
                {
                    System.Windows.MessageBox.Show("Please enter room number first", "DEI");
                    this.tbRoomNumber.Focus();
                    return;
                }
                currencyInfo = this._lstCurrency.Where(delegate(CurrencyInfo currlist)
                {
                    int arg_16_0 = currlist.DG_Currency_pkey;
                    bool expr_3F;
                    while (true)
                    {
                        int arg_0B_0 = this._defaultCurrencyId;
                        int expr_35;
                        do
                        {
                            expr_35 = (arg_0B_0 = arg_0B_0.ToInt32(false));
                        }
                        while (false);
                        bool expr_16 = (arg_16_0 = ((arg_16_0 == expr_35) ? 1 : 0)) != 0;
                        if (7 != 0 && 8 != 0)
                        {
                            bool flag2 = expr_16;
                            expr_3F = ((arg_16_0 = (flag2 ? 1 : 0)) != 0);
                            if (!false)
                            {
                                break;
                            }
                        }
                    }
                    return expr_3F;
                }).FirstOrDefault<CurrencyInfo>();
                if (false)
                {
                    goto IL_165;
                }
                paymentItem = new PaymentItem();
                guid = Guid.NewGuid();
            }
            string itemNumber = guid.ToString();
            paymentItem.ItemNumber = itemNumber;
            paymentItem.CurrencyList = this._lstCurrency;
            paymentItem.HotelName = this.tbHotelName.Text;
        IL_165:
            paymentItem.RoomNumber = this.tbRoomNumber.Text;
            paymentItem.CandidateName = this.tbName.Text;
            paymentItem.PaidAmount = Convert.ToDouble(this.tbAmount.Text);
            paymentItem.Currency = this._defaultCurrencyId.ToInt32(false);
            paymentItem.CurrencySyncCode = currencyInfo.SyncCode;
            paymentItem.CurrencyName = currencyInfo.DG_Currency_Symbol;
            this._objRoomPayment.Add(paymentItem);
            this.dgRoomPayment.UpdateLayout();
            DataGridRow dataGridRow = (DataGridRow)this.dgRoomPayment.ItemContainerGenerator.ContainerFromIndex(this._objRoomPayment.Count - 1);
            if (dataGridRow != null)
            {
                TextBlock textBlock = this.FindByName("txtHotelName", dataGridRow) as TextBlock;
                TextBlock textBlock2 = this.FindByName("txtRoomnumber", dataGridRow) as TextBlock;
                TextBlock textBlock3 = this.FindByName("txtNetPrice", dataGridRow) as TextBlock;
                textBlock.Text = this.tbHotelName.Text;
                textBlock2.Text = this.tbRoomNumber.Text;
                textBlock3.Text = currencyInfo.DG_Currency_Symbol.ToString() + " " + Math.Round(this.tbAmount.Text.ToDouble(false), 3).ToString("N2");
            }
            this.tbHotelName.Clear();
            this.tbRoomNumber.Clear();
            this.tbName.Clear();
            this.CalculateSummary();
        }

        private void btnAddVoucher_Click(object sender, RoutedEventArgs e)
        {
            if (this.tbName1.Text.Trim() == "" || Convert.ToDecimal(this.tbName1.Text.Trim()) <= 0m)
            {
                System.Windows.MessageBox.Show("Please enter valid amount first", "DEI");
            }
            else if (this.tbRoomNumber1.Text.Trim() == "")
            {
                System.Windows.MessageBox.Show("Please enter voucher number first", "DEI");
            }
            else
            {
                CurrencyInfo currencyInfo = this._lstCurrency.Where(delegate(CurrencyInfo currlist)
                {
                    int arg_16_0 = currlist.DG_Currency_pkey;
                    bool expr_3F;
                    while (true)
                    {
                        int arg_0B_0 = this._defaultCurrencyId;
                        int expr_35;
                        do
                        {
                            expr_35 = (arg_0B_0 = arg_0B_0.ToInt32(false));
                        }
                        while (false);
                        bool expr_16 = (arg_16_0 = ((arg_16_0 == expr_35) ? 1 : 0)) != 0;
                        if (7 != 0 && 8 != 0)
                        {
                            bool flag = expr_16;
                            expr_3F = ((arg_16_0 = (flag ? 1 : 0)) != 0);
                            if (!false)
                            {
                                break;
                            }
                        }
                    }
                    return expr_3F;
                }).FirstOrDefault<CurrencyInfo>();
                PaymentItem paymentItem = new PaymentItem();
                string itemNumber = Guid.NewGuid().ToString();
                paymentItem.ItemNumber = itemNumber;
                paymentItem.CurrencyList = this._lstCurrency;
                paymentItem.CandidateName = this.tbCustomerName.Text;
                paymentItem.VoucherNumber = this.tbRoomNumber1.Text;
                paymentItem.PaidAmount = Convert.ToDouble(this.tbName1.Text);
                paymentItem.Currency = this._defaultCurrencyId.ToInt32(false);
                paymentItem.CurrencySyncCode = currencyInfo.SyncCode;
                paymentItem.CurrencyName = currencyInfo.DG_Currency_Symbol;
                this._objVoucherPayment.Add(paymentItem);
                this.dgVoucherPayment.UpdateLayout();
                DataGridRow dataGridRow = (DataGridRow)this.dgVoucherPayment.ItemContainerGenerator.ContainerFromIndex(this._objVoucherPayment.Count - 1);
                if (dataGridRow != null)
                {
                    TextBlock textBlock = this.FindByName("txtVoucherNo", dataGridRow) as TextBlock;
                    TextBlock textBlock2 = this.FindByName("txtName", dataGridRow) as TextBlock;
                    TextBlock textBlock3 = this.FindByName("txtNetPrice", dataGridRow) as TextBlock;
                    textBlock.Text = this.tbRoomNumber1.Text;
                    textBlock2.Text = this.tbCustomerName.Text;
                    textBlock3.Text = currencyInfo.DG_Currency_Symbol.ToString() + " " + Math.Round(this.tbName1.Text.ToDouble(false), 3).ToString("N2");
                }
                this.tbRoomNumber1.Clear();
                this.tbCustomerName.Clear();
                this.CalculateSummary();
            }
        }

        private void btnAddKVL_Click(object sender, RoutedEventArgs e)
        {
            CurrencyInfo currencyInfo;
            PaymentItem paymentItem;
            while (true)
            {
                bool arg_52_0;
                if (!(this.tbKVL.Text.Trim() == ""))
                {
                    if (false)
                    {
                        goto IL_A1;
                    }
                    arg_52_0 = !(Convert.ToDecimal(this.tbKVL.Text.Trim()) <= 0m);
                }
                else
                {
                    arg_52_0 = false;
                }
                if (!arg_52_0)
                {
                    goto Block_2;
                }
                if (6 == 0)
                {
                    break;
                }
                currencyInfo = this._lstCurrency.Where(delegate(CurrencyInfo currlist)
                {
                    int arg_16_0 = currlist.DG_Currency_pkey;
                    bool expr_3F;
                    while (true)
                    {
                        int arg_0B_0 = this._defaultCurrencyId;
                        int expr_35;
                        do
                        {
                            expr_35 = (arg_0B_0 = arg_0B_0.ToInt32(false));
                        }
                        while (false);
                        bool expr_16 = (arg_16_0 = ((arg_16_0 == expr_35) ? 1 : 0)) != 0;
                        if (7 != 0 && 8 != 0)
                        {
                            bool flag2 = expr_16;
                            expr_3F = ((arg_16_0 = (flag2 ? 1 : 0)) != 0);
                            if (!false)
                            {
                                break;
                            }
                        }
                    }
                    return expr_3F;
                }).FirstOrDefault<CurrencyInfo>();
                paymentItem = new PaymentItem();
                if (7 == 0)
                {
                    continue;
                }
                Guid guid = Guid.NewGuid();
            IL_A1:
                string itemNumber = guid.ToString();
                paymentItem.ItemNumber = itemNumber;
                if (!false)
                {
                    goto Block_5;
                }
            }
            DataGridRow dataGridRow;
            bool flag;
            while (true)
            {
            IL_E0:
                paymentItem.Currency = this._defaultCurrencyId.ToInt32(false);
                while (true)
                {
                    paymentItem.CurrencySyncCode = currencyInfo.SyncCode;
                    paymentItem.CurrencyName = currencyInfo.DG_Currency_Symbol;
                    if (3 == 0)
                    {
                        break;
                    }
                    this._objKVLPayment.Add(paymentItem);
                    this.dgKVLPayment.UpdateLayout();
                    if (3 != 0)
                    {
                    }
                    dataGridRow = (DataGridRow)this.dgKVLPayment.ItemContainerGenerator.ContainerFromIndex(this._objKVLPayment.Count - 1);
                    flag = (dataGridRow == null);
                    if (!false)
                    {
                        goto Block_7;
                    }
                }
            }
        Block_7:
            if (!flag)
            {
                TextBlock textBlock = this.FindByName("txtNetPrice", dataGridRow) as TextBlock;
                textBlock.Text = currencyInfo.DG_Currency_Symbol.ToString() + " " + Math.Round(this.tbKVL.Text.ToDouble(false), 3).ToString("N2");
            }
            this.CalculateSummary();
            return;
        Block_2:
            System.Windows.MessageBox.Show("Please enter valid amount first", "DEI");
            return;
        Block_5:
            paymentItem.CurrencyList = this._lstCurrency;
            paymentItem.PaidAmount = Convert.ToDouble(this.tbKVL.Text);
            //goto IL_E0;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            SearchResult searchResult;
            while (true)
            {
                searchResult = null;
                //using (IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator())
                IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator();
                try
                {
                    while (true)
                    {
                        Window window;
                        if (!enumerator.MoveNext())
                        {
                            if (7 != 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            window = (Window)enumerator.Current;
                        }
                        if (window.Title == "View/Order Station")
                        {
                            while (2 == 0)
                            {
                            }
                            searchResult = (SearchResult)window;
                        }
                    }
                }
                catch { throw; }
                finally
                {
                }
                while (true)
                {
                    bool arg_99_0 = searchResult != null;
                    bool flag;
                    bool expr_9B;
                    do
                    {
                        flag = arg_99_0;
                        expr_9B = (arg_99_0 = flag);
                    }
                    while (false);
                    if (!expr_9B)
                    {
                        searchResult = new SearchResult();
                    }
                    if (RobotImageLoader.GroupImages.Count > 0)
                    {
                        searchResult.pagename = "MainGroup";
                        goto IL_11B;
                    }
                    int arg_187_0;
                    int expr_D2 = arg_187_0 = RobotImageLoader.PrintImages.Count;
                    if (8 != 0)
                    {
                        if (expr_D2 <= 0)
                        {
                            goto IL_11B;
                        }
                        if (true)
                        {
                            searchResult.pagename = "Placeback";
                            searchResult.Savebackpid = RobotImageLoader.PrintImages[0].PhotoId.ToString();
                            goto IL_11B;
                        }
                        break;
                    }
                IL_187:
                    if (arg_187_0 == 0)
                    {
                        goto Block_10;
                    }
                    List<LstMyItems> list;
                    int num;
                    while (!false)
                    {
                        list[num].PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        if (!false)
                        {
                            num++;
                            goto IL_17A;
                        }
                    }
                    continue;
                IL_17A:
                    flag = (num < list.Count);
                    arg_187_0 = (flag ? 1 : 0);
                    goto IL_187;
                IL_11B:
                    list = (from pb in RobotImageLoader.GroupImages
                            where pb.PrintGroup.UriSource.ToString() == "/images/print-accept.png"
                            select pb).ToList<LstMyItems>();
                    num = 0;
                    goto IL_17A;
                }
            }
        Block_10:
            searchResult.Show();
            searchResult.flgViewScrl = true;
            searchResult.LoadWindow();
            base.Close();
        }

        //private void btn_Click(object sender, RoutedEventArgs e)
        //{
        //    System.Windows.Controls.Button expr_06 = (System.Windows.Controls.Button)sender;
        //    System.Windows.Controls.Button button;
        //    if (!false)
        //    {
        //        button = expr_06;
        //    }
        //    bool flag;
        //    while (true)
        //    {
        //        string text = button.Content.ToString();
        //        if (text != null)
        //        {
        //            if (text == "ENTER")
        //            {
        //                break;
        //            }
        //            if (text == "SPACE")
        //            {
        //                goto IL_83;
        //            }
        //            if (text == "CLOSE")
        //            {
        //                goto IL_AA;
        //            }
        //            if (text == "Back")
        //            {
        //                goto IL_C0;
        //            }
        //        }
        //        if (!false)
        //        {
        //            if (!(this.controlon.Name == "tbAmount"))
        //            {
        //                goto IL_136;
        //            }
        //            goto IL_167;
        //        IL_168:
        //            bool arg_169_0;
        //            if (!arg_169_0)
        //            {
        //                if (this.controlon.Text.Length < 18)
        //                {
        //                    this.controlon.Text = this.controlon.Text + button.Content;
        //                }
        //                goto IL_1AC;
        //            }
        //            flag = (this.controlon.Text.Length >= 50);
        //            if (false)
        //            {
        //                goto IL_83;
        //            }
        //            if (true)
        //            {
        //                goto Block_15;
        //            }
        //            goto IL_136;
        //        IL_167:
        //            arg_169_0 = false;
        //            goto IL_168;
        //        IL_136:
        //            if (!(this.controlon.Name == "tbName1"))
        //            {
        //                arg_169_0 = !(this.controlon.Name == "tbKVL");
        //                goto IL_168;
        //            }
        //            goto IL_167;
        //        }
        //    IL_1AC:
        //        if (!false)
        //        {
        //            goto Block_13;
        //        }
        //    }
        //    this.KeyBorder.Visibility = Visibility.Collapsed;
        //IL_7A:
        //    if (!false)
        //    {
        //        return;
        //    }
        //    goto IL_AB;
        //IL_83:
        //    this.controlon.Text = this.controlon.Text + " ";
        //    return;
        //IL_AA:
        //IL_AB:
        //    this.KeyBorder.Visibility = Visibility.Collapsed;
        //    if (5 != 0)
        //    {
        //        return;
        //    }
        //    goto IL_7A;
        //IL_C0:
        //    System.Windows.Controls.TextBox textBox = this.controlon;
        //    if (this.controlon.Text.Length > 0)
        //    {
        //        this.controlon.Text = this.controlon.Text.Remove(this.controlon.Text.Length - 1, 1);
        //    }
        //Block_13:
        //    return;
        //Block_15:
        //    if (!flag)
        //    {
        //        this.controlon.Text = this.controlon.Text + button.Content;
        //    }
        //}

        private void tbRoomNumber_GotFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.controlon = (System.Windows.Controls.TextBox)sender;
                    if (false)
                    {
                        break;
                    }
                  //  this.KeyBorder.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void tbAmount_GotFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.controlon = (System.Windows.Controls.TextBox)sender;
                    if (false)
                    {
                        break;
                    }
                   // this.KeyBorder.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void tbName1_GotFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.controlon = (System.Windows.Controls.TextBox)sender;
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

        private void tbKVL_GotFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                }
                while (8 != 0)
                {
                    this.controlon = (System.Windows.Controls.TextBox)sender;
                    if (false)
                    {
                        break;
                    }
                   // this.KeyBorder.Visibility = Visibility.Visible;
                    if (8 != 0)
                    {
                        return;
                    }
                }
            }
        }

        public void burnLoadimage()
        {
            this.AddRecordingDevices();
            MsftDiscMaster2 msftDiscMaster = null;
            this.lstmain = new List<MsftDiscRecorder2>();
            try
            {
                if (!false)
                {
                    msftDiscMaster = (MsftDiscMaster2)new MsftDiscMaster2Class();
                    if (!msftDiscMaster.IsSupportedEnvironment)
                    {
                        return;
                    }
                    foreach (string recorderUniqueId in msftDiscMaster)
                    {
                        MsftDiscRecorder2 msftDiscRecorder = (MsftDiscRecorder2)new MsftDiscRecorder2Class();
                        msftDiscRecorder.InitializeDiscRecorder(recorderUniqueId);
                        this.lstmain.Add(msftDiscRecorder);
                    }
                    int arg_C4_0 = this.devicesComboBox.Items.Count;
                    int arg_C4_1 = 0;
                    int expr_C4;
                    int expr_C7;
                    do
                    {
                        expr_C4 = (arg_C4_0 = ((arg_C4_0 > arg_C4_1) ? 1 : 0));
                        expr_C7 = (arg_C4_1 = 0);
                    }
                    while (expr_C7 != 0);
                    bool arg_CC_0 = expr_C4 == expr_C7;
                    bool expr_CE;
                    do
                    {
                        bool flag = arg_CC_0;
                        expr_CE = (arg_CC_0 = flag);
                    }
                    while (false);
                    if (expr_CE)
                    {
                        goto IL_E4;
                    }
                }
                this.devicesComboBox.SelectedIndex = 0;
            IL_E4: ;
            }
            catch (COMException var_3_107)
            {
                return;
            }
            finally
            {
                bool arg_11A_0;
                bool expr_111 = arg_11A_0 = (msftDiscMaster == null);
                if (!false)
                {
                    bool flag = expr_111;
                    arg_11A_0 = flag;
                }
                if (!arg_11A_0)
                {
                    Marshal.ReleaseComObject(msftDiscMaster);
                }
            }
            DateTime dateTime = new CustomBusineses().ServerDateTime();
            do
            {
                this.UpdateCapacity();
            }
            while (false);
        }

        private void AddRecordingDevices()
        {
            if (-1 != 0)
            {
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                this.discMaster = (MsftDiscMaster2)new MsftDiscMaster2Class();
                try
                {
                    bool arg_42_0;
                    bool expr_189 = arg_42_0 = this.discMaster.IsSupportedEnvironment;
                    if (!false)
                    {
                        bool flag = expr_189;
                        arg_42_0 = flag;
                    }
                    if (arg_42_0)
                    {
                        foreach (string recorderUniqueId in this.discMaster)
                        {
                            int num = 0;
                            MsftDiscRecorder2 msftDiscRecorder = (MsftDiscRecorder2)new MsftDiscRecorder2Class();
                            msftDiscRecorder.InitializeDiscRecorder(recorderUniqueId);
                            string text = string.Empty;
                            int arg_F3_0;
                            bool expr_8C = (arg_F3_0 = ((msftDiscRecorder == null) ? 1 : 0)) != 0;
                            if (false)
                            {
                                goto IL_F3;
                            }
                            string str;
                            object[] volumePathNames;
                            int num2;
                            if (!expr_8C)
                            {
                                str = (string)msftDiscRecorder.VolumePathNames.GetValue(0);
                                volumePathNames = msftDiscRecorder.VolumePathNames;
                                num2 = 0;
                                goto IL_F5;
                            }
                        IL_104:
                            if (msftDiscRecorder != null)
                            {
                                dictionary.Add(string.Format("{0} [{1}]", text, msftDiscRecorder.ProductId), num.ToString());
                            }
                            if (!false)
                            {
                                continue;
                            }
                            goto IL_EF;
                        IL_F5:
                            if (num2 >= volumePathNames.Length)
                            {
                                goto IL_104;
                            }
                            string text2 = (string)volumePathNames[num2];
                            if (!string.IsNullOrEmpty(text))
                            {
                                text += ",";
                            }
                            text += str;
                            goto IL_EF;
                        IL_F3:
                            num2 = arg_F3_0;
                            goto IL_F5;
                        IL_EF:
                            arg_F3_0 = num2 + 1;
                            goto IL_F3;
                        }
                        this.devicesComboBox.ItemsSource = dictionary;
                        this.devicesComboBox.SelectedValue = "0";
                    }
                }
                catch (Exception var_7_1A7)
                {
                }
                finally
                {
                }
            }
        }

        private void UpdateCapacity()
        {
            bool arg_16_0;
            int arg_C9_0 = (arg_16_0 = (this._totalDiscSize == 0L)) ? 1 : 0;
            int arg_10_0 = 0;
            int arg_C9_1;
            int expr_BD;
            int expr_C0;
            while (true)
            {
                int expr_10 = arg_C9_1 = arg_10_0;
                if (expr_10 != 0)
                {
                    goto IL_C9;
                }
                int arg_2E_0;
                bool expr_16 = (arg_2E_0 = (((arg_16_0 ? 1 : 0) == expr_10) ? 1 : 0)) != 0;
                if (3 != 0)
                {
                    if (!expr_16)
                    {
                        break;
                    }
                    arg_2E_0 = 0;
                }
                long num = (long)arg_2E_0;
                IEnumerator enumerator = ((IEnumerable)this.listBoxFiles.Items).GetEnumerator();
              //  goto IL_4E;
                try
                {
                    while (true)
                    {
                    IL_4E:
                        while (true)
                        {
                            bool flag = enumerator.MoveNext();
                            if (8 != 0)
                            {
                                if (!flag)
                                {
                                    goto Block_9;
                                }
                                IMediaItem mediaItem = (IMediaItem)enumerator.Current;
                                num += mediaItem.SizeOnDisc;
                            }
                        }
                    }
                Block_9: ;
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    bool flag;
                    bool arg_92_0;
                    do
                    {
                        bool expr_88 = arg_92_0 = (disposable == null);
                        if (6 == 0)
                        {
                            goto IL_92;
                        }
                        flag = expr_88;
                    }
                    while (2 == 0);
                    arg_92_0 = flag;
                IL_92:
                    if (!arg_92_0)
                    {
                        disposable.Dispose();
                    }
                }
                if (num == 0L)
                {
                    break;
                }
                int num2 = (int)(num * 100L / this._totalDiscSize);
                expr_BD = ((arg_16_0 = ((arg_C9_0 = num2) != 0)) ? 1 : 0);
                expr_C0 = (arg_10_0 = 100);
                if (expr_C0 != 0)
                {
                    goto Block_6;
                }
            }
            return;
        Block_6:
            arg_C9_0 = ((expr_BD > expr_C0) ? 1 : 0);
            arg_C9_1 = 0;
        IL_C9:
            if (arg_C9_0 != arg_C9_1)
            {
            }
        }

        private void backgroundBurnWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MsftDiscRecorder2 msftDiscRecorder = null;
            MsftDiscFormat2Data msftDiscFormat2Data = null;
            IStream stream = null;
            try
            {
                msftDiscRecorder = (MsftDiscRecorder2)new MsftDiscRecorder2Class();
                BurnData burnData = (BurnData)e.Argument;
                msftDiscRecorder.InitializeDiscRecorder(burnData.uniqueRecorderId);
                while (true)
                {
                    MsftDiscFormat2Data msftDiscFormat2Data2 = (MsftDiscFormat2Data)new MsftDiscFormat2DataClass();
                    msftDiscFormat2Data2.Recorder = msftDiscRecorder;
                    msftDiscFormat2Data2.ClientName = "BurnMedia";
                    msftDiscFormat2Data2.ForceMediaToBeClosed = this._closeMedia;
                    msftDiscFormat2Data = msftDiscFormat2Data2;
                    IBurnVerification burnVerification = (IBurnVerification)msftDiscFormat2Data;
                    burnVerification.BurnVerificationLevel = this._verificationLevel;
                    object[] multisessionInterfaces = null;
                    while (true)
                    {
                        bool arg_9D_0;
                        bool expr_91 = arg_9D_0 = msftDiscFormat2Data.MediaHeuristicallyBlank;
                        if (!false)
                        {
                            bool flag = expr_91;
                            arg_9D_0 = flag;
                        }
                        if (arg_9D_0)
                        {
                            break;
                        }
                        if (!false)
                        {
                            goto Block_5;
                        }
                    }
                IL_AC:
                    //IStream stream;
                    if (this.CreateMediaFileSystem(msftDiscRecorder, multisessionInterfaces, out stream))
                    {
                        goto IL_D6;
                    }
                    if (2 != 0)
                    {
                        break;
                    }
                    continue;
                Block_5:
                    multisessionInterfaces = msftDiscFormat2Data.MultisessionInterfaces;
                    goto IL_AC;
                }
                e.Result = -1;
                return;
            IL_D6:
                msftDiscFormat2Data.Update += new DiscFormat2Data_EventHandler(this.discFormatData_Update);
                try
                {
                   // IStream stream;
                    msftDiscFormat2Data.Write(stream);
                    e.Result = 0;
                }
                catch (COMException var_6_103)
                {
                }
                finally
                {
                   // IStream stream;
                    if (stream != null)
                    {
                        Marshal.FinalReleaseComObject(stream);
                    }
                }
                msftDiscFormat2Data.Update -= new DiscFormat2Data_EventHandler(this.discFormatData_Update);
                if (true)
                {
                    msftDiscRecorder.EjectMedia();
                }
            }
            catch (COMException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                e.Result = ex.ErrorCode;
            }
            finally
            {
                bool arg_1A5_0 = msftDiscRecorder == null;
                bool expr_1B9;
                do
                {
                    bool flag = arg_1A5_0;
                    bool arg_1A9_0 = flag;
                    do
                    {
                        if (!arg_1A9_0)
                        {
                            if (5 == 0)
                            {
                                goto IL_1C8;
                            }
                            Marshal.ReleaseComObject(msftDiscRecorder);
                        }
                        expr_1B9 = (arg_1A5_0 = (arg_1A9_0 = (msftDiscFormat2Data == null)));
                    }
                    while (false);
                }
                while (-1 == 0);
                if (expr_1B9)
                {
                    goto IL_1D0;
                }
            IL_1C8:
                Marshal.ReleaseComObject(msftDiscFormat2Data);
            IL_1D0: ;
            }
        }

        private void discFormatData_Update([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, [MarshalAs(UnmanagedType.IDispatch)] [In] object progress)
        {
            bool expr_11 = !this.backgroundBurnWorker.CancellationPending;
            bool flag;
            if (3 != 0)
            {
                flag = expr_11;
            }
            if (!flag)
            {
                IDiscFormat2Data discFormat2Data = (IDiscFormat2Data)sender;
                discFormat2Data.CancelWrite();
            }
            else
            {
                IDiscFormat2DataEventArgs discFormat2DataEventArgs = (IDiscFormat2DataEventArgs)progress;
                this._burnData.task = BURN_MEDIA_TASK.BURN_MEDIA_TASK_WRITING;
                this._burnData.elapsedTime = (long)discFormat2DataEventArgs.ElapsedTime;
                this._burnData.remainingTime = (long)discFormat2DataEventArgs.RemainingTime;
                this._burnData.totalTime = (long)discFormat2DataEventArgs.TotalTime;
                this._burnData.currentAction = discFormat2DataEventArgs.CurrentAction;
                this._burnData.startLba = (long)discFormat2DataEventArgs.StartLba;
                this._burnData.sectorCount = (long)discFormat2DataEventArgs.SectorCount;
                this._burnData.lastReadLba = (long)discFormat2DataEventArgs.LastReadLba;
                this._burnData.lastWrittenLba = (long)discFormat2DataEventArgs.LastWrittenLba;
                this._burnData.totalSystemBuffer = (long)discFormat2DataEventArgs.TotalSystemBuffer;
                this._burnData.usedSystemBuffer = (long)discFormat2DataEventArgs.UsedSystemBuffer;
                this._burnData.freeSystemBuffer = (long)discFormat2DataEventArgs.FreeSystemBuffer;
                this.backgroundBurnWorker.ReportProgress(0, this._burnData);
            }
        }

        private void backgroundBurnWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this._isBurning = false;
        }

        private void backgroundBurnWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private bool CreateMediaFileSystem(IDiscRecorder2 discRecorder, object[] multisessionInterfaces, out IStream dataStream)
        {
            MsftFileSystemImage msftFileSystemImage = null;
            bool result;
            try
            {
                msftFileSystemImage = (MsftFileSystemImage)new MsftFileSystemImageClass();
                msftFileSystemImage.ChooseImageDefaults(discRecorder);
                msftFileSystemImage.FileSystemsToCreate = (FsiFileSystems.FsiFileSystemISO9660 | FsiFileSystems.FsiFileSystemJoliet);
                msftFileSystemImage.Update += new DFileSystemImage_EventHandler(this.fileSystemImage_Update);
                bool flag = multisessionInterfaces == null;
                bool arg_52_0 = flag;
                bool expr_10A;
                do
                {
                    if (!arg_52_0)
                    {
                        msftFileSystemImage.MultisessionInterfaces = multisessionInterfaces;
                        msftFileSystemImage.ImportFileSystem();
                    }
                    do
                    {
                        IFsiDirectoryItem root = msftFileSystemImage.Root;
                        IEnumerator enumerator = ((IEnumerable)this.listBoxFiles.Items).GetEnumerator();
                        try
                        {
                            if (false)
                            {
                                goto IL_BE;
                            }
                        IL_B5:
                            flag = enumerator.MoveNext();
                        IL_BE:
                            IMediaItem mediaItem;
                            if (!false)
                            {
                                if (!flag)
                                {
                                    goto IL_C5;
                                }
                                mediaItem = (IMediaItem)enumerator.Current;
                            }
                            flag = !this.backgroundBurnWorker.CancellationPending;
                            if (flag && 8 != 0)
                            {
                                mediaItem.AddToFileSystem(root);
                                goto IL_B5;
                            }
                        IL_C5: ;
                        }
                        finally
                        {
                            IDisposable disposable = enumerator as IDisposable;
                            flag = (disposable == null);
                            if (!flag)
                            {
                                disposable.Dispose();
                            }
                        }
                    }
                    while (7 == 0);
                    msftFileSystemImage.Update -= new DFileSystemImage_EventHandler(this.fileSystemImage_Update);
                    expr_10A = (arg_52_0 = !this.backgroundBurnWorker.CancellationPending);
                }
                while (!true);
                flag = expr_10A;
                if (!flag)
                {
                    dataStream = null;
                    result = false;
                    return result;
                }
                dataStream = msftFileSystemImage.CreateResultImage().ImageStream;
            }
            catch (COMException var_3_16D)
            {
                dataStream = null;
                result = false;
                return result;
            }
            finally
            {
                bool flag = msftFileSystemImage == null;
                if (!false)
                {
                    if (!flag && !false)
                    {
                        Marshal.ReleaseComObject(msftFileSystemImage);
                    }
                }
            }
            result = true;
            return result;
        }

        private void fileSystemImage_Update([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, [MarshalAs(UnmanagedType.BStr)] [In] string currentFile, [In] int copiedSectors, [In] int totalSectors)
        {
            int percentProgress;
            while (true)
            {
                int arg_44_0;
                int arg_3B_0;
                int arg_1B_0;
                int expr_02 = arg_1B_0 = (arg_3B_0 = (arg_44_0 = 0));
                if (expr_02 != 0)
                {
                    goto IL_36;
                }
                percentProgress = expr_02;
                arg_1B_0 = copiedSectors;
                int arg_1B_1;
                int expr_10 = arg_1B_1 = 0;
                if (expr_10 != 0)
                {
                    goto IL_1B;
                }
                if (copiedSectors > expr_10)
                {
                    arg_1B_0 = totalSectors;
                    arg_1B_1 = 0;
                    goto IL_1B;
                }
                bool arg_BB_0 = true;
                goto IL_23;
            IL_4B:
                if (false || string.IsNullOrEmpty(currentFile))
                {
                    return;
                }
                if (4 != 0)
                {
                    break;
                }
                continue;
            IL_23:
                if (!arg_BB_0)
                {
                    arg_44_0 = copiedSectors;
                    arg_3B_0 = copiedSectors;
                    arg_1B_0 = copiedSectors;
                    goto IL_36;
                }
                goto IL_4B;
            IL_1B:
                arg_BB_0 = (arg_1B_0 <= arg_1B_1);
                goto IL_23;
            IL_36:
                int arg_44_1;
                int expr_38 = arg_1B_1 = (arg_44_1 = 100);
                if (expr_38 != 0)
                {
                    arg_44_0 = (arg_1B_0 = arg_3B_0 * expr_38);
                    arg_44_1 = totalSectors;
                    arg_1B_1 = totalSectors;
                }
                if (!false)
                {
                    percentProgress = arg_44_0 / arg_44_1;
                    goto IL_4B;
                }
                goto IL_1B;
            }
            FileInfo fileInfo = new FileInfo(currentFile);
            this._burnData.statusMessage = "Adding \"" + fileInfo.Name + "\" to image...";
            this._burnData.task = BURN_MEDIA_TASK.BURN_MEDIA_TASK_FILE_SYSTEM;
            this.backgroundBurnWorker.ReportProgress(percentProgress, this._burnData);
        }

        private void backgroundFormatWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MsftDiscRecorder2 msftDiscRecorder = null;
            MsftDiscFormat2Erase msftDiscFormat2Erase = null;
            try
            {
                MsftDiscFormat2Erase msftDiscFormat2Erase2;
                do
                {
                    msftDiscRecorder = (MsftDiscRecorder2)new MsftDiscRecorder2Class();
                    string recorderUniqueId = (string)e.Argument;
                    msftDiscRecorder.InitializeDiscRecorder(recorderUniqueId);
                    if (4 == 0)
                    {
                        goto IL_7E;
                    }
                    msftDiscFormat2Erase2 = (MsftDiscFormat2Erase)new MsftDiscFormat2EraseClass();
                    msftDiscFormat2Erase2.Recorder = msftDiscRecorder;
                    msftDiscFormat2Erase2.ClientName = "BurnMedia";
                }
                while (3 == 0);
                msftDiscFormat2Erase = msftDiscFormat2Erase2;
                msftDiscFormat2Erase.Update += new DiscFormat2Erase_EventHandler(this.discFormatErase_Update);
            IL_7E:
                try
                {
                    msftDiscFormat2Erase.EraseMedia();
                    e.Result = 0;
                }
                catch (COMException var_3_97)
                {
                }
                while (false)
                {
                }
                msftDiscFormat2Erase.Update -= new DiscFormat2Erase_EventHandler(this.discFormatErase_Update);
            }
            catch (COMException var_5_E8)
            {
            }
            finally
            {
                bool flag = msftDiscRecorder == null;
                if (!flag)
                {
                    goto IL_FC;
                }
                goto IL_108;
            IL_10E:
                while (!false)
                {
                    if (!flag)
                    {
                        Marshal.ReleaseComObject(msftDiscFormat2Erase);
                        if (false)
                        {
                            continue;
                        }
                    }
                    goto EndFinally_13;
                }
            IL_FC:
                Marshal.ReleaseComObject(msftDiscRecorder);
                if (false)
                {
                    goto IL_10E;
                }
            IL_108:
                flag = (msftDiscFormat2Erase == null);
                goto IL_10E;
            EndFinally_13: ;
            }
        }

        private void discFormatErase_Update([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, int elapsedSeconds, int estimatedTotalSeconds)
        {
            int arg_12_0 = elapsedSeconds * 100 / estimatedTotalSeconds;
        }

        private void backgroundFormatWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void backgroundFormatWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this._isFormatting = false;
        }

      void IStyleConnector.Connect(int connectionId, object target)
        {
            int arg_F5_0 = connectionId;
            int arg_5D_0;
            int arg_40_0;
            int expr_5A;
            int expr_3D;
            while (true)
            {
                int num = arg_F5_0;
                if (6 == 0)
                {
                    goto IL_86;
                }
                int arg_15_0 = num;
                int arg_15_1 = 36;
                while (true)
                {
                    int arg_5A_0;
                    int arg_51_0;
                    int arg_51_1;
                    if (arg_15_0 <= arg_15_1)
                    {
                        int expr_101 = arg_15_0 = (arg_5D_0 = (arg_F5_0 = num));
                        if (false)
                        {
                            break;
                        }
                        int expr_21 = arg_5A_0 = 24;
                        if (expr_21 != 0)
                        {
                            switch (expr_101 - expr_21)
                            {
                                case 0:
                                    goto IL_64;
                                case 1:
                                    return;
                                case 2:
                                    goto IL_86;
                                default:
                                    arg_51_0 = (arg_40_0 = num);
                                    goto IL_3B;
                            }
                        }
                    }
                    else
                    {
                        arg_51_0 = (arg_40_0 = num);
                        if (!false)
                        {
                            arg_51_1 = 43;
                            goto IL_51;
                        }
                        goto IL_3B;
                    }
                IL_5A:
                    expr_5A = (arg_15_1 = arg_5A_0);
                    if (expr_5A != 0)
                    {
                        goto Block_10;
                    }
                    continue;
                IL_51:
                    if (arg_51_0 != arg_51_1)
                    {
                        arg_5D_0 = (arg_15_0 = num);
                        arg_5A_0 = 48;
                        goto IL_5A;
                    }
                    goto IL_BA;
                IL_3B:
                    expr_3D = (arg_51_1 = 36);
                    if (expr_3D != 0)
                    {
                        goto Block_6;
                    }
                    goto IL_51;
                }
            }
        Block_6:
            if (arg_40_0 != expr_3D)
            {
                return;
            }
            ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btndeleteRoom_Click);
            return;
        Block_10:
            if (arg_5D_0 != expr_5A)
            {
                return;
            }
            ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btndeleteKVL_Click);
            return;
        IL_64:
            ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btndelete_Click);
            return;
        IL_86:
            ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnCarddelete_Click);
            return;
        IL_BA:
            ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btndeleteVoucher_Click);
        }
    }
}
