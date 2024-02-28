using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using System.Xml.Linq;

using DigiPhoto;

namespace PhotoSW.Orders
{
    public partial class SelectPrinter : Window, IComponentConnector, IStyleConnector
    {
        private ObservableCollection<LineItem> _objImagesToPrint;

        public bool _issemiorder;

        private double _NetAmount = 0.0;

        private double _TotalAmount = 0.0;

        private double _TotalDiscount = 0.0;

        private string DefaultCurrency;

      

        public ObservableCollection<LineItem> ImagesToPrint
        {
            get
            {
                return this._objImagesToPrint;
            }
            set
            {
                this.GetGroupImages(value);
            }
        }

        public PlaceOrder SourceParent
        {
            get;
            set;
        }

        public SelectPrinter()
        {
            this.InitializeComponent();
            this.CtrlDiscount.SetParent(this.grdParent);
            this.btnNextsimg.IsDefault = true;
        }

        private void DiscountAvaliable()
        {
            bool arg_F4_0 = !LoginUser.IsDiscountAllowed.Value;
            bool expr_FA;
            do
            {
                bool flag = arg_F4_0;
                expr_FA = (arg_F4_0 = flag);
            }
            while (2 == 0 || false);
            if (!expr_FA)
            {
                DataGridColumn expr_110 = this.dgOrder.Columns[7];
                Visibility expr_36 = Visibility.Visible;
                if (!false)
                {
                    expr_110.Visibility = expr_36;
                }
                this.dgOrder.Columns[8].Visibility = Visibility.Visible;
                if (LoginUser.IsDiscountAllowedonTotal.Value)
                {
                    this.btnTotalDiscount.Visibility = Visibility.Visible;
                }
                else
                {
                    this.btnTotalDiscount.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                this.btnTotalDiscount.Visibility = Visibility.Collapsed;
                this.dgOrder.Columns[7].Visibility = Visibility.Collapsed;
                this.dgOrder.Columns[8].Visibility = Visibility.Collapsed;
                this.txt_TotalDiscount.Visibility = Visibility.Collapsed;
                this.lbl_TotalDiscount.Visibility = Visibility.Collapsed;
            }
        }

        private void GetDefaultCurrency()
        {
            this.DefaultCurrency = (from objcurrency in new CurrencyBusiness().GetCurrencyList().Where(delegate(CurrencyInfo objcurrency)
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
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                if (6 != 0)
                {
                    this.DiscountAvaliable();
                }
            }
            this.GetDefaultCurrency();
            List<LineItem> list = (from result in this.ImagesToPrint
                                   where result.ParentID == result.ItemNumber
                                   select result).ToList<LineItem>();
            int num = 1;
            if (2 != 0)
            {
                foreach (LineItem current in list)
                {
                    current.ItemSeqNumber = num;
                    num++;
                    if (false)
                    {
                        break;
                    }
                }
                this.dgOrder.ItemsSource = list;
                this.dgOrder.UpdateLayout();
                num = 0;
            }
            using (List<LineItem>.Enumerator enumerator = list.GetEnumerator())
            {
                while (true)
                {
                IL_C0:
                    while (enumerator.MoveNext())
                    {
                        LineItem current = enumerator.Current;
                        Button button;
                        while (true)
                        {
                            while (!current.AllowDiscount)
                            {
                                if (-1 != 0)
                                {
                                    DataGridRow root = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(num);
                                    if (false)
                                    {
                                        goto IL_C0;
                                    }
                                    button = (this.FindByName("btnDiscount", root) as Button);
                                    if (!false)
                                    {
                                        goto Block_11;
                                    }
                                }
                            }
                            break;
                        }
                    IL_115:
                        if (!false)
                        {
                            num++;
                            continue;
                        }
                        break;
                    Block_11:
                        button.Visibility = Visibility.Collapsed;
                        goto IL_115;
                    }
                    break;
                }
            }
            this.TotalAmount(true);
            this.TotalItem.Text = " Total " + list.Count.ToString() + " Items";
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

        public void GetGroupImages(ObservableCollection<LineItem> orderedImages)
        {
            new List<LstMyItems>();
            if (3 == 0)
            {
            }
            do
            {
                int num = 1;
                IEnumerator<LineItem> expr_116 = orderedImages.GetEnumerator();
                IEnumerator<LineItem> enumerator;
                if (!false)
                {
                    enumerator = expr_116;
                    //goto IL_25;
                }
                try
                {
                    while (true)
                    {
                    IL_25:
                        while (true)
                        {
                            if (false)
                            {
                                goto IL_9A;
                            }
                            if (2 == 0)
                            {
                                break;
                            }
                            if (!enumerator.MoveNext())
                            {
                                goto Block_9;
                            }
                            LineItem image = enumerator.Current;
                            int arg_53_0 = (image.SelectedImages == null) ? 1 : 0;
                        IL_53:
                            if (arg_53_0 == 0)
                            {
                                List<LstMyItems> groupItems = RobotImageLoader.PrintImages.Where(delegate(LstMyItems OrderImage)
                                {
                                    bool arg_29_0;
                                    bool flag2;
                                    while (true)
                                    {
                                        if (!false)
                                        {
                                            List<string> arg_48_0 = image.SelectedImages;
                                            int expr_37 = OrderImage.PhotoId;
                                            int num2;
                                            if (5 != 0)
                                            {
                                                num2 = expr_37;
                                            }
                                            bool expr_48 = arg_29_0 = arg_48_0.Contains(num2.ToString());
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
                                }).ToList<LstMyItems>();
                                if (!false)
                                {
                                    image.GroupItems = groupItems;
                                    image.ItemSeqNumber = num;
                                    goto IL_9A;
                                }
                            }
                            break;
                        IL_9A:
                            int expr_9A = arg_53_0 = num;
                            if (5 == 0)
                            {
                                goto IL_53;
                            }
                            num = expr_9A + 1;
                        }
                    }
                Block_9: ;
                }
                finally
                {
                    bool arg_E0_0;
                    bool expr_D7 = arg_E0_0 = (enumerator == null);
                    if (!false)
                    {
                        bool flag = expr_D7;
                        arg_E0_0 = flag;
                    }
                    if (!arg_E0_0)
                    {
                        enumerator.Dispose();
                    }
                }
            }
            while (8 == 0);
            this._objImagesToPrint = orderedImages;
        }

        private void btnDiscount_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            bool expr_16 = button == null;
            bool flag;
            if (!false)
            {
                flag = expr_16;
            }
            if (!flag)
            {
                LineItem expr_39 = (LineItem)this.dgOrder.CurrentItem;
                LineItem lineItem;
                if (5 != 0)
                {
                    lineItem = expr_39;
                }
                this.CtrlDiscount.TotalCost = lineItem.TotalPrice;
                this.CtrlDiscount.IsItemLevel = true;
                this.CtrlDiscount.DiscountResult = lineItem.TotalDiscount;
                this.btnNextsimg.IsDefault = false;
                this.CtrlDiscount.btnSubmit.IsDefault = true;
                discount discount = this.CtrlDiscount.ShowHandlerDialog("Discount");
                this.btnNextsimg.IsDefault = true;
                this.CtrlDiscount.btnSubmit.IsDefault = false;
                flag = (discount == null);
                if (!flag)
                {
                    lineItem.TotalDiscountAmount = discount.TotalDiscountAmount;
                    lineItem.NetPrice = lineItem.TotalPrice - discount.TotalDiscountAmount;
                    flag = (discount.DiscountDetail == null);
                    if (!flag)
                    {
                        lineItem.TotalDiscount = discount.DiscountDetail.ToString();
                    }
                    DataGridRow dataGridRow;
                    do
                    {
                        dataGridRow = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(this.dgOrder.SelectedIndex);
                        flag = (dataGridRow == null);
                    }
                    while (false);
                    if (!flag)
                    {
                        TextBox textBox = this.FindByName("txtDiscount", dataGridRow) as TextBox;
                        textBox.Text = Math.Round(discount.TotalDiscountAmount, 2).ToString("N3");
                        textBox = (this.FindByName("txtNetPrice", dataGridRow) as TextBox);
                        textBox.Text = Math.Round(lineItem.NetPrice, 2).ToString("N3");
                    }
                    this.TotalAmount(false);
                }
            }
        }

        private void btnPreviousimg_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                PlaceOrder sourceParent = this.SourceParent;
                bool flag = sourceParent != null;
                while (true)
                {
                    if (flag)
                    {
                        goto IL_39;
                    }
                IL_25:
                    if (false)
                    {
                        continue;
                    }
                    if (false)
                    {
                        goto IL_2E;
                    }
                    base.Close();
                    goto IL_2E;
                IL_65:
                    if (2 != 0)
                    {
                        return;
                    }
                    goto IL_25;
                IL_39:
                    if (2 != 0)
                    {
                        sourceParent.CtrlSelectedQrCode.QRCode = string.Empty;
                        sourceParent.Visibility = Visibility.Visible;
                        sourceParent.Focus();
                        base.Close();
                        goto IL_65;
                    }
                IL_2E:
                    if (5 == 0)
                    {
                        goto IL_39;
                    }
                    if (!false)
                    {
                        goto IL_65;
                    }
                    break;
                }
            }
        }

        private void btnNextsimg_Click(object sender, RoutedEventArgs e)
        {
            double arg_25_0;
            double expr_06 = arg_25_0 = this._NetAmount;
            if (!false && !false)
            {
                arg_25_0 = expr_06.ToDouble(false);
            }
            bool expr_25 = arg_25_0 < 0.0;
            bool flag;
            if (!false)
            {
                flag = expr_25;
            }
            if (!flag)
            {
                this.GetDefaultCurrency();
                Payment payment = new Payment();
                if (true)
                {
                    payment._issemiorder = this._issemiorder;
                    payment.SourceParent = this;
                    payment.PaybleAmount = this._NetAmount.ToDouble(false);
                    payment.ImagesToPrint = this.ImagesToPrint;
                    if (!false)
                    {
                        payment.DefaultCurrency = this.DefaultCurrency;
                        while (!true)
                        {
                        }
                        payment.DiscountDetails = this.ItemDiscountDetails.Text;
                        payment.TotalDiscount = this._TotalDiscount.ToDouble(false);
                    }
                    payment.TotalBill = this._TotalAmount.ToDouble(false);
                }
                payment.Show();
                base.Visibility = Visibility.Hidden;
                payment.ShowPopup();
            }
        IL_FC:
            if (3 != 0)
            {
                return;
            }
            goto IL_FC;
        }

        private double TotalAmountAfterLineItemDiscount(ref double totalLineItemDiscount)
        {
            if (8 == 0)
            {
                goto IL_26;
            }
            double arg_128_0 = 0.0;
        IL_0D:
            double num = arg_128_0;
            double num2 = 0.0;
        IL_20:
            int i = 0;
        IL_26:
            while (i < this.ImagesToPrint.Count)
            {
                DataGridRow dataGridRow = (DataGridRow)this.dgOrder.ItemContainerGenerator.ContainerFromIndex(i);
                if (dataGridRow != null)
                {
                    double num3 = 0.0;
                    TextBox textBox = this.FindByName("txtDiscount", dataGridRow) as TextBox;
                    double expr_EA;
                    while (true)
                    {
                        double arg_A7_0;
                        if (textBox != null)
                        {
                            if (double.TryParse(textBox.Text, out num3))
                            {
                                arg_A7_0 = num + num3;
                                goto IL_A7;
                            }
                        }
                    IL_AA:
                        textBox = (this.FindByName("txtNetPrice", dataGridRow) as TextBox);
                        if (!false)
                        {
                            bool flag = textBox == null;
                            if (!true)
                            {
                                continue;
                            }
                            if (flag)
                            {
                                break;
                            }
                        }
                        if (!double.TryParse(textBox.Text, out num3))
                        {
                            break;
                        }
                        expr_EA = (arg_A7_0 = num2 + num3);
                        if (6 != 0)
                        {
                            goto Block_8;
                        }
                        goto IL_A7;
                    IL_A9:
                        goto IL_AA;
                    IL_A7:
                        num = arg_A7_0;
                        goto IL_A9;
                    }
                IL_F1:
                    goto IL_F2;
                    goto IL_F1;
                Block_8:
                    num2 = expr_EA;
                }
            IL_F2:
                if (false)
                {
                    goto IL_20;
                }
                i++;
            }
            totalLineItemDiscount = num;
            double arg_127_0;
            double expr_117 = arg_127_0 = (arg_128_0 = num2);
            if (3 != 0)
            {
                double num4 = expr_117;
                arg_128_0 = (arg_127_0 = num4);
            }
            if (!false)
            {
                return arg_127_0;
            }
            goto IL_0D;
        }

        private void AdjustTotalAmount()
        {
            while (true)
            {
                double num = 0.0;
                bool expr_7C;
                string text = "";
                while (true)
                {
                IL_18:
                    while (true)
                    {
                    IL_1D:
                        bool flag = !(this.ItemDiscountDetails.Text != string.Empty);
                        bool arg_43_0 = flag;
                        while (!arg_43_0)
                        {
                            this.TotalAmountAfterLineItemDiscount(ref num);
                            if (4 == 0)
                            {
                                goto IL_18;
                            }
                             text = this.ItemDiscountDetails.Text;
                            if (false)
                            {
                                goto IL_1D;
                            }
                            if (text == null)
                            {
                                goto IL_11B;
                            }
                            expr_7C = (arg_43_0 = (text != string.Empty));
                            if (-1 != 0)
                            {
                                goto Block_4;
                            }
                        }
                        return;
                    }
                }
            IL_11B:
                if (8 != 0)
                {
                    break;
                }
                continue;
            Block_4:
                if (expr_7C)
                {
                   // string text;
                    XDocument xDocument = XDocument.Parse(text);
                    using (IEnumerator<XElement> enumerator = xDocument.Element("Discount").Elements("Option").GetEnumerator())
                    {
                        while (true)
                        {
                            bool arg_F9_0 = enumerator.MoveNext();
                            bool expr_FB;
                            do
                            {
                                bool flag = arg_F9_0;
                                expr_FB = (arg_F9_0 = flag);
                            }
                            while (false);
                            if (!expr_FB)
                            {
                                break;
                            }
                            XElement current = enumerator.Current;
                            if (!false)
                            {
                                double num2 = current.Attribute("discount").Value.ToString().ToDouble(false);
                            }
                        }
                    }
                }
                goto IL_11B;
            }
        }

        private void TotalAmount(bool initial)
        {
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            this.txt_TotalDiscount.Text = this.DefaultCurrency + " 0.00";
            if (!false)
            {
                foreach (LineItem current in this.ImagesToPrint)
                {
                    num3 += current.TotalDiscountAmount;
                    num2 += current.NetPrice;
                    num += current.TotalPrice;
                }
                if (this.ItemDiscountDetails.Text != string.Empty)
                {
                    XDocument xDocument = XDocument.Parse(this.ItemDiscountDetails.Text);
                    if (xDocument != null)
                    {
                        string text = this.ItemDiscountDetails.Text;
                        if (text != null)
                        {
                            XDocument xDocument2 = XDocument.Parse(text);
                            IEnumerator<XElement> enumerator2 = xDocument2.Element("Discount").Elements("Option").GetEnumerator();
                            try
                            {
                                while (enumerator2.MoveNext())
                                {
                                    XElement current2 = enumerator2.Current;
                                    double num4 = current2.Attribute("discount").Value.ToString().ToDouble(false);
                                    bool flag = current2.Attribute("InPercentmode").Value.ToString().ToBoolean(false);
                                    if (flag)
                                    {
                                        num3 += num2 * (num4 / 100.0);
                                    }
                                    else
                                    {
                                        num3 += num4;
                                    }
                                }
                            }
                            finally
                            {
                                bool arg_1D3_0 = enumerator2 == null;
                                bool expr_1D5;
                                do
                                {
                                    bool flag2 = arg_1D3_0;
                                    expr_1D5 = (arg_1D3_0 = flag2);
                                }
                                while (false);
                                if (!expr_1D5)
                                {
                                    enumerator2.Dispose();
                                }
                            }
                        }
                    }
                }
                this._TotalAmount = num;
                this._TotalDiscount = num3;
                this.txt_TotalAmount.Text = this.DefaultCurrency + " " + Math.Round(num, 2).ToString("N2");
            }
            this.txt_TotalDiscount.Text = this.DefaultCurrency + " " + Math.Round(num3, 2).ToString("N2");
            this._NetAmount = Math.Round(num - num3, 2);
            this.txt_NetAmount.Text = this.DefaultCurrency + " " + this._NetAmount.ToString("N2");
        }

        private void btnTotalDiscount_Click(object sender, RoutedEventArgs e)
        {
            discount discount=null;
            while (true)
            {
                double num = 0.0;
                if (false)
                {
                    goto IL_122;
                }
                num = (from i in this.ImagesToPrint
                       select i.TotalDiscountAmount).Sum();
                double num2 = (from i in this.ImagesToPrint
                               select i.TotalPrice).Sum();
                this.CtrlDiscount.TotalCost = num2 - num;
                this.CtrlDiscount.DiscountResult = this.ItemDiscountDetails.Text;
                if (6 != 0)
                {
                    this.CtrlDiscount.IsItemLevel = false;
                    if (4 != 0)
                    {
                        this.btnNextsimg.IsDefault = false;
                        this.CtrlDiscount.btnSubmit.IsDefault = true;
                    }
                    discount = this.CtrlDiscount.ShowHandlerDialog("Discount");
                    this.btnNextsimg.IsDefault = true;
                    goto IL_108;
                }
            IL_17B:
                this.txt_NetAmount.Text = this.DefaultCurrency + " " + this._NetAmount.ToString("N2");
                if (6 == 0)
                {
                    continue;
                }
                bool flag = discount.DiscountDetail == null;
                if (flag)
                {
                    return;
                }
                if (!false)
                {
                    break;
                }
                goto IL_108;
            IL_14A:
                if (5 != 0)
                {
                    this.txt_TotalDiscount.Text = this.DefaultCurrency + " " + this._TotalDiscount.ToString("N2");
                    goto IL_17B;
                }
                return;
            IL_122:
                if (!flag)
                {
                    this._TotalDiscount = num + discount.TotalDiscountAmount;
                    this._NetAmount = this._TotalAmount - this._TotalDiscount;
                    goto IL_14A;
                }
                return;
            IL_108:
                this.CtrlDiscount.btnSubmit.IsDefault = false;
                if (2 != 0)
                {
                    flag = (discount == null);
                    goto IL_122;
                }
                goto IL_14A;
            }
            this.ItemDiscountDetails.Text = discount.DiscountDetail.ToString();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            ButtonBase expr_03 = this.btnNextsimg;
            RoutedEventHandler expr_10 = new RoutedEventHandler(this.btnNextsimg_Click);
            if (!false)
            {
                expr_03.Click -= expr_10;
            }
            this.btnPreviousimg.Click -= new RoutedEventHandler(this.btnPreviousimg_Click);
            this._objImagesToPrint.Clear();
            this.ImagesToPrint.Clear();
        }

       void IStyleConnector.Connect(int connectionId, object target)
        {
            while (true)
            {
                if (8 == 0)
                {
                    goto IL_16;
                }
                int arg_0F_0 = connectionId;
                if (8 != 0)
                {
                    arg_0F_0 = connectionId;
                }
                if (arg_0F_0 == 16 || false)
                {
                    goto IL_16;
                }
            IL_2F:
                if (!false)
                {
                    break;
                }
                continue;
            IL_16:
                ((Button)target).Click += new RoutedEventHandler(this.btnDiscount_Click);
                goto IL_2F;
            }
        }
    }
}
