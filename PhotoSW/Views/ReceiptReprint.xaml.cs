using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Manage;
using PhotoSW.Orders;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;
using PhotoSW.Views;
using PhotoSW.ViewModels;

namespace PhotoSW.Views
{
    public partial class ReceiptReprint : Window, IComponentConnector
    {
        private class Payment
        {
            public string Mode
            {
                get;
                set;
            }

            public double Amount
            {
                get;
                set;
            }

            public string CurrencyID
            {
                get;
                set;
            }

            public string CardHolderName
            {
                get;
                set;
            }

            public string CardNumber
            {
                get;
                set;
            }

            public string CardType
            {
                get;
                set;
            }

            public string HotelName
            {
                get;
                set;
            }

            public string RoomNumber
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }

            public string VoucherNumber
            {
                get;
                set;
            }

            public string CustomerName
            {
                get;
                set;
            }

            public Payment()
            {
                this.Mode = (this.CurrencyID = (this.CardHolderName = (this.CardNumber = (this.Name = (this.CardType = (this.HotelName = (this.RoomNumber = (this.VoucherNumber = (this.CustomerName = string.Empty)))))))));
            }
        }

        private string photoRfids = string.Empty;

        private OrderReceiptReprintInfo order = null;

        private List<LinetItemsDetails> itemList = null;

        private int OrderId = 0;

        private List<OrderDetails> _objOrderList;

        public int lineitemId;

        private decimal? DiscountOnTotal = new decimal?(0m);

        private TextBox controlon;

       // private List<Alreadyrefund> AlreadyRefunded;



        public string sDefaultCurrency
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

        public ReceiptReprint()
        {
            this.InitializeComponent();
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
            this.btnSearch.IsDefault = true;
            this.txtSearchOrderNO.Focus();
            this.sDefaultCurrency = this.GetDefaultCurrency();
            this.ResetControls();
            this.GetLastThreeOrders();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            base.Close();
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (4 != 0)
                    {
                        ManageHome manageHome = new ManageHome();
                        Window expr_25 = manageHome;
                        if (-1 != 0)
                        {
                            expr_25.Show();
                        }
                        if (6 == 0)
                        {
                            goto IL_19;
                        }
                    }
                    base.Close();
                IL_19: ;
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
            while (!true);
            if (!false)
            {
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!false)
                {
                    this.ResetControls();
                }
                int arg_29_0 = string.IsNullOrEmpty(this.txtSearchOrderNO.Text.Trim()) ? 1 : 0;
                int arg_29_1 = 0;
                int arg_89_0;
                int expr_86;
                while (true)
                {
                    bool flag = arg_29_0 == arg_29_1;
                    bool expr_103 = (arg_29_0 = (arg_89_0 = (flag ? 1 : 0))) != 0;
                    if (!false)
                    {
                        if (!expr_103)
                        {
                            break;
                        }
                     //   this.KeyBorderOrder.Visibility = Visibility.Collapsed;
                        this.dgOrderList.Visibility = Visibility.Collapsed;
                        if (3 != 0)
                        {
                            this.GetSearchedDetailData();
                        }
                        arg_89_0 = (arg_29_0 = this.dgOrderList.Items.Count);
                    }
                    expr_86 = (arg_29_1 = 0);
                    if (expr_86 == 0)
                    {
                        goto Block_5;
                    }
                }
            IL_3A:
            IL_3B:
                MessageBox.Show("Please enter a valid order number.");
                if (-1 != 0)
                {
                    return;
                }
                goto IL_C0;
            Block_5:
                if (arg_89_0 <= expr_86)
                {
                    MessageBox.Show("Please enter a valid order number.");
                }
                else
                {
                    this.dgOrderList.Visibility = Visibility.Visible;
                    this.btnViewPhotos.Visibility = Visibility.Visible;
                    if (2 == 0)
                    {
                        goto IL_3B;
                    }
                }
            IL_C0:
                if (-1 == 0)
                {
                    goto IL_3A;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        public void ResetControls()
        {
            do
            {
                this.txt_TotalDiscount.Text = this.sDefaultCurrency + " 0.00";
                this.txt_NetAmount.Text = this.sDefaultCurrency + " 0.00";
                this.txt_TotalAmount.Text = this.sDefaultCurrency + " 0.00";
                this.order = null;
                if (3 != 0)
                {
                    this.photoRfids = string.Empty;
                    this.lstItems.ItemsSource = null;
                }
                this.btnViewPhotos.Visibility = Visibility.Collapsed;
                this.dgOrderList.ItemsSource = null;
            }
            while (5 == 0);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.GrdPrint.Visibility = Visibility.Collapsed;
        }

        private void GetSearchedDetailData()
        {
            try
            {
                this.OrderId = 0;
                //this.AlreadyRefunded = new List<Alreadyrefund>();
                this._objOrderList = new List<OrderDetails>();
                string text = this.txtSearchOrderNO.Text.ToUpperInvariant();
                if (text.IndexOf("DG-", StringComparison.OrdinalIgnoreCase) < 0)
                {
                    text = "DG-" + text;
                }
                List<OrderDetailInfo> orderDetailsforRefund = new OrderBusiness().GetOrderDetailsforRefund(text);
                if (orderDetailsforRefund != null && orderDetailsforRefund.Count > 0)
                {
                    this.itemList = new List<LinetItemsDetails>();
                    decimal? num = new decimal?(0m);
                    foreach (OrderDetailInfo current in orderDetailsforRefund)
                    {
                        LinetItemsDetails linetItemsDetails = new LinetItemsDetails();
                        this.OrderId = Convert.ToInt32(current.DG_Orders_ID);
                        num += current.DG_Orders_LineItems_DiscountAmount;
                        num = new decimal?(decimal.Round(Convert.ToDecimal(num), 4, MidpointRounding.AwayFromZero));
                        OrderDetails orderDetails = new OrderDetails();
                        while (true)
                        {
                            orderDetails.DG_LineItemId = current.DG_Orders_LineItems_pkey;
                            orderDetails.DG_Orders_Details_Items_TotalCost = current.DG_Orders_Details_Items_UniPrice * current.TotalQuantity;
                            orderDetails.DG_Orders_LineItems_DiscountAmount = new decimal?(current.LineItemshare);
                            orderDetails.DG_ProductTypeId = current.DG_Orders_Details_ProductType_pkey;
                            if (!current.DG_Orders_ProductType_IsBundled)
                            {
                                goto IL_1CD;
                            }
                            orderDetails.DG_Orders_LineItems_Quantity = new long?(current.TotalQuantity);
                        IL_1FA:
                            orderDetails.DG_LineItemUnitPrice = current.DG_Orders_Details_Items_UniPrice;
                            orderDetails.DG_Orders_ProductType_Name = current.DG_Orders_ProductType_Name;
                            orderDetails.PhotoIds = current.DG_Photos_ID;
                            orderDetails.IsBundled = current.DG_Orders_ProductType_IsBundled;
                            orderDetails.IsPackage = current.DG_IsPackage;
                            if (!false)
                            {
                                orderDetails.loopquantity = current.DG_Orders_LineItems_Quantity.Value;
                                linetItemsDetails.Productname = current.DG_Orders_ProductType_Name;
                                linetItemsDetails.Productprice = Convert.ToDecimal(current.DG_Orders_Details_Items_UniPrice.HasValue ? current.DG_Orders_Details_Items_UniPrice : new decimal?(0m)).ToString("#.00");
                                if (!false)
                                {
                                    break;
                                }
                                continue;
                            }
                        IL_1CD:
                            orderDetails.DG_Orders_LineItems_Quantity = new long?(current.TotalQuantity);
                            goto IL_1FA;
                        }
                        linetItemsDetails.Productquantity = current.TotalQuantity.ToString();
                        this.itemList.Add(linetItemsDetails);
                        this._objOrderList.Add(orderDetails);
                    }
                    if (Convert.ToDecimal(this._TotalDiscount) > 0m)
                    {
                        this.DiscountOnTotal = Convert.ToDecimal(this._TotalDiscount) - num;
                        this.DiscountOnTotal = new decimal?(decimal.Round(Convert.ToDecimal(this.DiscountOnTotal), 4, MidpointRounding.AwayFromZero));
                    }
                    this.dgOrderList.ItemsSource = this._objOrderList;
                    this.GetOrderDetail();
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

        private void GetLastThreeOrders()
        {
            try
            {
                bool flag;
                if (!false)
                {
                    bool expr_1A = !File.Exists(Environment.CurrentDirectory + "\\on.dat");
                    if (!false)
                    {
                        flag = expr_1A;
                    }
                }
                if (!flag)
                {
                    StreamReader streamReader = new StreamReader(Environment.CurrentDirectory + "\\on.dat");
                    try
                    {
                        string cipherString = streamReader.ReadLine();
                        string text = PhotoSW.ViewModels.CryptorEngine.Decrypt(cipherString, true);
                        Dictionary<int, string> dictionary = new Dictionary<int, string>();
                        int num = text.Split(new char[]
						{
							','
						}).Count<string>();
                        string[] array = text.Split(new char[]
						{
							','
						});
                        int num2 = 0;
                        while (true)
                        {
                            flag = (num2 < array.Length);
                            if (!flag)
                            {
                                break;
                            }
                            string value = array[num2];
                            dictionary.Add(num, value);
                            num--;
                            num2++;
                        }
                        this.lstOrders.ItemsSource = from o in dictionary
                                                     orderby o.Key
                                                     select o;
                    }
                    finally
                    {
                        flag = (streamReader == null);
                        if (!flag)
                        {
                            ((IDisposable)streamReader).Dispose();
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            if (7 != 0)
            {
            }
        }

        private string GetPhotoRFIDs(string imageIds)
        {
            string text = string.Empty;
            try
            {
                List<PhotosDetails> list = new List<PhotosDetails>();
                string[] source = imageIds.Split(new char[]
				{
					','
				});
                List<string> list2 = new List<string>();
                List<PhotoInfo> photoRFIDByPhotoIDList = new PhotoBusiness().GetPhotoRFIDByPhotoIDList(imageIds);
                if (photoRFIDByPhotoIDList != null)
                {
                    using (List<PhotoInfo>.Enumerator enumerator = photoRFIDByPhotoIDList.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            PhotoInfo img = enumerator.Current;
                            while (img != null)
                            {
                                int count;
                                bool flag;
                                do
                                {
                                    count = source.Where(delegate(string t)
                                    {
                                        bool arg_29_0;
                                        bool flag2;
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
                                                flag2 = expr_48;
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
                                        arg_29_0 = flag2;
                                        return arg_29_0;
                                    }).ToList<string>().Count;
                                    flag = (count != 1);
                                }
                                while (3 == 0);
                                if (!flag)
                                {
                                    list2.Add(img.DG_Photos_RFID);
                                }
                                else
                                {
                                    list2.Add("(" + img.DG_Photos_RFID + ")X" + count.ToString());
                                    if (false)
                                    {
                                        continue;
                                    }
                                }
                                PhotosDetails photosDetails = new PhotosDetails();
                                photosDetails.PhotoName = ((count == 1) ? img.DG_Photos_RFID : ("(" + img.DG_Photos_RFID + ")X" + count.ToString()));
                                photosDetails.PhotoId = Convert.ToString(img.DG_Photos_pkey);
                                photosDetails.ImageVisibility = Visibility.Visible;
                                photosDetails.OtherVisibility = Visibility.Visible;
                                while (false)
                                {
                                }
                                photosDetails.FilePath = Path.Combine(img.HotFolderPath, "Thumbnails", img.DG_Photos_CreatedOn.ToString("yyyyMMdd"), img.DG_Photos_FileName);
                                list.Add(photosDetails);
                                break;
                            }
                        }
                    }
                }
                this.lstItems.ItemsSource = list;
                text = string.Join(",", list2);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            string result;
            do
            {
                result = text;
            }
            while (-1 == 0);
            return result;
        }

        private string GetDefaultCurrency()
        {
            if (7 == 0 || false)
            {
                goto IL_54;
            }
        IL_07:
            string text = (from objcurrency in new  CurrencyBusiness().GetCurrencyList().Where(delegate(CurrencyInfo objcurrency)
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
        IL_54:
            string result = text;
            if (-1 != 0)
            {
                return result;
            }
            goto IL_07;
        }

        private void btnViewPhotos_Click(object sender, RoutedEventArgs e)
        {
            if (-1 != 0)
            {
                try
                {
                    UIElement expr_07 = this.GrdPrint;
                    Visibility expr_0C = Visibility.Visible;
                    if (4 != 0)
                    {
                        expr_07.Visibility = expr_0C;
                    }
                    while (false)
                    {
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    if (!false && !false)
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
            }
        }

        private void btn_Click2(object sender, RoutedEventArgs e)
        {
            if (this.controlon != null)
            {
                new Button();
                Button button = (Button)sender;
                string text = button.Content.ToString();
                if (text != null)
                {
                    if (text == "ENTER")
                    {
                        this.controlon.Text = this.controlon.Text + Environment.NewLine;
                        this.controlon.Focus();
                        return;
                    }
                    if (text == "SPACE")
                    {
                        this.controlon.Text = this.controlon.Text + " ";
                        this.controlon.Focus();
                        return;
                    }
                    if (text == "CLOSE")
                    {
                       // this.KeyBorderOrder.Visibility = Visibility.Collapsed;
                        return;
                    }
                    if (text == "Back")
                    {
                        TextBox textBox = this.controlon;
                        if (this.controlon.Text.Length > 0 && this.controlon.SelectionStart > 0)
                        {
                            int selectionStart = this.controlon.SelectionStart;
                            this.controlon.Text = this.controlon.Text.Remove(this.controlon.SelectionStart - 1, 1);
                            this.controlon.Select(selectionStart - 1, 0);
                        }
                        this.controlon.Focus();
                        return;
                    }
                }
                this.controlon.Text = this.controlon.Text + button.Content;
                this.controlon.SelectionStart = this.controlon.Text.Length;
                this.controlon.Focus();
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
          //  this.KeyBorderOrder.Visibility = Visibility.Visible;
        }

        private void GetOrderDetail()
        {
            try
            {
                OrderBusiness orderBusiness = new OrderBusiness();
                this.order = orderBusiness.GetOrderDetailForReceipt(this.OrderId);
                this.txt_TotalDiscount.Text = this.order.CurrencySymbol + " " + this.order.DiscountTotal.ToString("#.00");
                this.txt_NetAmount.Text = this.order.CurrencySymbol + " " + this.order.NetCost.ToString("#.00");
                this.txt_TotalAmount.Text = this.order.CurrencySymbol + " " + this.order.TotalCost.ToString("#.00");
                this.photoRfids = this.GetPhotoRFIDs(this.order.PhotoIds);
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
            while (3 == 0)
            {
            }
        }

        private void btnPrintReceipt_Click(object sender, RoutedEventArgs e)
        {
            if (6 != 0)
            {
                try
                {
                    ReceiptReprint.Payment payment;
                    int arg_18F_0;
                    if (!false)
                    {
                        if (this.order != null)
                        {
                            payment = this.LoadXml(this.order.PaymentDetail);
                            if (!false)
                            {
                                int arg_7C_0;
                                if (payment != null && this.itemList != null && -1 != 0)
                                {
                                    int arg_70_0;
                                    int expr_64 = arg_70_0 = this.itemList.Count;
                                    int arg_70_1;
                                    int expr_6A = arg_70_1 = 0;
                                    if (expr_6A == 0)
                                    {
                                        arg_70_0 = ((expr_64 > expr_6A) ? 1 : 0);
                                        arg_70_1 = 0;
                                    }
                                    arg_18F_0 = (arg_7C_0 = ((arg_70_0 == arg_70_1) ? 1 : 0));
                                }
                                else
                                {
                                    arg_18F_0 = (arg_7C_0 = 1);
                                }
                                if (-1 == 0)
                                {
                                    goto IL_173;
                                }
                                if (arg_7C_0 == 0)
                                {
                                    goto IL_85;
                                }
                                goto IL_1AF;
                            }
                        }
                        MessageBox.Show("Please search a valid order number.");
                        return;
                    }
                IL_85:
                    if (7 != 0)
                    {
                        TestBill testBill = new TestBill(LoginUser.SubstoreName.ToString(), LoginUser.UserName.ToString(), 
                            this.txtSearchOrderNO.Text.Trim(), this.photoRfids,
                            new RefundBusiness().GetRefundText(), 
                            Math.Round(this.order.NetCost, 3).ToString(), 
                            Math.Round(payment.Amount, 3).ToString(), 
                            Math.Round(this.order.NetCost - payment.Amount, 3).ToString(), 
                            this.itemList, payment.Mode, payment.CardNumber,
                            payment.CardHolderName, string.IsNullOrEmpty(payment.CustomerName) ? payment.Name : payment.CustomerName, payment.HotelName, payment.RoomNumber, payment.VoucherNumber, this.order.CurrencySymbol, this.OrderId, true);
                    }
                    arg_18F_0 = LoginUser.UserId;
                IL_173:
                    AuditLog.AddUserLog(arg_18F_0, 66, "Order No: " + this.txtSearchOrderNO.Text.Trim());
                    this.ResetControls();
                    AuditLog.AddUserLog(LoginUser.UserId, 45, "Receipt reprinted.");
                IL_1AF: ;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private ReceiptReprint.Payment LoadXml(string ImageXml)
        {
            ReceiptReprint.Payment result;
            do
            {
                ReceiptReprint.Payment payment = new ReceiptReprint.Payment();
                try
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(ImageXml);
                    //using (IEnumerator enumerator = xmlDocument.ChildNodes[0].ChildNodes[0].Attributes.GetEnumerator())
                    IEnumerator enumerator = xmlDocument.ChildNodes[0].ChildNodes[0].Attributes.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            while (enumerator.MoveNext())
                            {
                                if (!false)
                                {
                                    object current = enumerator.Current;
                                    string text = ((XmlAttribute)current).Name.ToLower();
                                    if (text != null)
                                    {

                                        Dictionary<string, int> obj = null;
                                        if (obj == null)
                                        {
                                            obj = new Dictionary<string, int>(11)
											{
												{
													"mode",
													0
												},
												{
													"amount",
													1
												},
												{
													"cardholdername",
													2
												},
												{
													"cardnumber",
													3
												},
												{
													"cardtype",
													4
												},
												{
													"currencyid",
													5
												},
												{
													"customername",
													6
												},
												{
													"hotelname",
													7
												},
												{
													"name",
													8
												},
												{
													"roomnumber",
													9
												},
												{
													"vouchernumber",
													10
												}
											};
                                        }
                                        int num;
                                        if (obj.TryGetValue(text, out num))
                                        {
                                            switch (num)
                                            {
                                                case 0:
                                                    payment.Mode = ((XmlAttribute)current).Value.ToUpper();
                                                    if (8 != 0)
                                                    {
                                                        continue;
                                                    }
                                                    continue;
                                                case 1:
                                                    goto IL_18A;
                                                case 2:
                                                    payment.CardHolderName = ((XmlAttribute)current).Value.ToString();
                                                    continue;
                                                case 3:
                                                    payment.CardNumber = ((XmlAttribute)current).Value.ToString();
                                                    continue;
                                                case 4:
                                                    payment.CardType = ((XmlAttribute)current).Value.ToString();
                                                    if (!false)
                                                    {
                                                        continue;
                                                    }
                                                    break;
                                                case 5:
                                                    payment.CurrencyID = ((XmlAttribute)current).Value.ToString();
                                                    continue;
                                                case 6:
                                                    payment.CustomerName = ((XmlAttribute)current).Value.ToString();
                                                    continue;
                                                case 7:
                                                    if (7 != 0)
                                                    {
                                                        payment.HotelName = ((XmlAttribute)current).Value.ToString();
                                                        continue;
                                                    }
                                                    continue;
                                                case 8:
                                                    payment.Name = ((XmlAttribute)current).Value.ToString();
                                                    continue;
                                                case 9:
                                                    payment.RoomNumber = ((XmlAttribute)current).Value.ToString();
                                                    continue;
                                                case 10:
                                                    if (7 != 0)
                                                    {
                                                        payment.VoucherNumber = ((XmlAttribute)current).Value.ToString();
                                                        continue;
                                                    }
                                                    goto IL_18A;
                                                default:
                                                    continue;
                                            }
                                        IL_1A0:
                                            payment.Amount = Convert.ToDouble(((XmlAttribute)current).Value);
                                            continue;
                                        IL_18A:
                                            if (!string.IsNullOrEmpty(((XmlAttribute)current).Value))
                                            {
                                                goto IL_1A0;
                                            }
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }///
                    catch
                    {
                    }
                    finally
                    {
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (false)
                {
                }
                result = payment;
            }
            while (6 == 0);
            return result;
        }

        private void lstOrders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.lstOrders.SelectedItem == null)
            {
                goto IL_42;
            }
        IL_13:
            if (false || !false)
            {
            }
            if (true)
            {
                this.txtSearchOrderNO.Text = ((KeyValuePair<int, string>)this.lstOrders.SelectedItem).Value;
            }
        IL_3D:
            if (-1 == 0)
            {
                goto IL_13;
            }
        IL_42:
            if (2 != 0)
            {
                return;
            }
            goto IL_3D;
        }


    }
}
