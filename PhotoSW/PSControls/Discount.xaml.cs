using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Orders;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using System.Xml.Linq;

namespace PhotoSW.PSControls
{
    public partial class Discount : UserControl, IComponentConnector
    {
        private ObservableCollection<DiscountItem> _objItemDiscount;

        private bool _hideRequest = false;

        private discount _result;

        private UIElement _parent;

        public static readonly DependencyProperty MessageDiscountProperty = DependencyProperty.Register("MessageDiscount", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));


        public bool IsItemLevel
        {
            get;
            set;
        }

        public string DiscountResult
        {
            get;
            set;
        }

        public double TotalCost
        {
            get;
            set;
        }

        public double OrignalCost
        {
            get;
            set;
        }

        public string MessageDiscount
        {
            get
            {
                return (string)base.GetValue(Discount.MessageDiscountProperty);
            }
            set
            {
                base.SetValue(Discount.MessageDiscountProperty, value);
            }
        }

        public Discount()
        {
            try
            {
                this.InitializeComponent();
                base.Visibility = Visibility.Hidden;
                this._objItemDiscount = new ObservableCollection<DiscountItem>();
            }
            catch (Exception var_0_2D)
            {
            }
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public discount ShowHandlerDialog(string message)
        {
            if (false)
            {
                goto IL_BD;
            }
            this.MessageDiscount = message;
        IL_17:
            Visibility expr_1C = Visibility.Visible;
            if (!false)
            {
                base.Visibility = expr_1C;
            }
            if (8 != 0)
            {
                this._parent.IsEnabled = true;
                bool expr_42 = false;
                if (!false)
                {
                    this.GetDiscountType(expr_42);
                }
                this._hideRequest = false;
            }
        IL_BB:
        IL_BD:
            bool arg_C6_0 = !this._hideRequest;
            bool flag;
            int arg_7B_0;
            do
            {
                flag = arg_C6_0;
                if (!flag)
                {
                    goto IL_CD;
                }
                if (!base.Dispatcher.HasShutdownStarted)
                {
                    if (false)
                    {
                        goto IL_7C;
                    }
                    arg_C6_0 = ((arg_7B_0 = ((!base.Dispatcher.HasShutdownFinished) ? 1 : 0)) != 0);
                }
                else
                {
                    arg_C6_0 = ((arg_7B_0 = 0) != 0);
                }
            }
            while (2 == 0);
            flag = (arg_7B_0 != 0);
        IL_7C:
            if (!flag)
            {
                while (!false)
                {
                    if (!false)
                    {
                        goto IL_CD;
                    }
                }
                goto IL_17;
            }
            base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            {
            }));
            Thread.Sleep(20);
            goto IL_BB;
        IL_CD:
            return this._result;
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

        public void GetDiscountType(bool onCancel)
        {
            this._objItemDiscount.Clear();
            if (this.IsItemLevel)
            {
                IEnumerable<DiscountTypeInfo> enumerable = new DiscountBusiness().GetDiscountType().Where(delegate(DiscountTypeInfo discount)
                {
                    bool? flag;
                    if (!false)
                    {
                        flag = discount.DG_Orders_DiscountType_ItemLevel;
                    }
                    int arg_3D_0;
                    bool expr_85 = (arg_3D_0 = (this.IsItemLevel ? 1 : 0)) != 0;
                    if (4 == 0)
                    {
                        goto IL_39;
                    }
                    bool flag2 = expr_85;
                IL_21:
                    if (-1 == 0)
                    {
                        goto IL_62;
                    }
                    if (flag.GetValueOrDefault() == flag2)
                    {
                        arg_3D_0 = (flag.HasValue ? 1 : 0);
                    }
                    else
                    {
                        arg_3D_0 = 0;
                    }
                IL_39:
                    int arg_64_0;
                    if (arg_3D_0 != 0 && 7 != 0)
                    {
                        if (3 != 0)
                        {
                            flag = discount.DG_Orders_DiscountType_Active;
                            arg_64_0 = ((flag == true) ? 1 : 0);
                            return arg_64_0 != 0;
                        }
                        goto IL_21;
                    }
                IL_62:
                    arg_64_0 = 0;
                    return arg_64_0 != 0;
                });
                IEnumerator<DiscountTypeInfo> enumerator = enumerable.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        DiscountTypeInfo current = enumerator.Current;
                        DiscountItem discountItem = new DiscountItem();
                        bool? dG_Orders_DiscountType_AsPercentage = current.DG_Orders_DiscountType_AsPercentage;
                        if (5 != 0)
                        {
                            if (dG_Orders_DiscountType_AsPercentage.Value)
                            {
                                discountItem.DiscountName = current.DG_Orders_DiscountType_Name.ToString() + " (%): ";
                            }
                            else
                            {
                                discountItem.DiscountName = current.DG_Orders_DiscountType_Name.ToString() + ": ";
                            }
                            discountItem.DiscountID = current.DG_Orders_DiscountType_Pkey;
                            discountItem.IsPercentageDiscount = current.DG_Orders_DiscountType_AsPercentage.Value;
                            discountItem.IsSecure = current.DG_Orders_DiscountType_Secure.Value;
                            discountItem.DiscountSyncCode = current.SyncCode;
                            this._objItemDiscount.Add(discountItem);
                        }
                    }
                }
                finally
                {
                    if (false || (!false && enumerator != null))
                    {
                        enumerator.Dispose();
                    }
                }
                this.dgDiscount.ItemsSource = this._objItemDiscount;
            }
            else
            {
                DiscountBusiness discountBusiness = new DiscountBusiness();
                IEnumerable<DiscountTypeInfo> enumerable = new DiscountBusiness().GetDiscountType().Where(delegate(DiscountTypeInfo discount)
                {
                    bool? dG_Orders_DiscountType_Active = discount.DG_Orders_DiscountType_Active;
                    int arg_42_0;
                    if (!dG_Orders_DiscountType_Active.GetValueOrDefault())
                    {
                        arg_42_0 = 0;
                        goto IL_16;
                    }
                    arg_42_0 = (dG_Orders_DiscountType_Active.HasValue ? 1 : 0);
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
                });
                using (IEnumerator<DiscountTypeInfo> enumerator = enumerable.GetEnumerator())
                {
                    while (true)
                    {
                        DiscountTypeInfo current;
                        DiscountItem discountItem;
                        if (!enumerator.MoveNext())
                        {
                            if (7 != 0)
                            {
                                break;
                            }
                        }
                        else
                        {
                            current = enumerator.Current;
                            discountItem = new DiscountItem();
                            if (current.DG_Orders_DiscountType_AsPercentage.Value)
                            {
                                discountItem.DiscountName = current.DG_Orders_DiscountType_Name.ToString() + " (%): ";
                            }
                            else
                            {
                                discountItem.DiscountName = current.DG_Orders_DiscountType_Name.ToString() + ": ";
                            }
                        }
                        discountItem.DiscountID = current.DG_Orders_DiscountType_Pkey;
                        discountItem.IsPercentageDiscount = current.DG_Orders_DiscountType_AsPercentage.Value;
                        if (4 != 0)
                        {
                            discountItem.IsSecure = current.DG_Orders_DiscountType_Secure.Value;
                        }
                        discountItem.DiscountAmount = 0.0;
                        discountItem.DiscountSyncCode = current.SyncCode;
                        this._objItemDiscount.Add(discountItem);
                    }
                }
                this.dgDiscount.ItemsSource = this._objItemDiscount;
            }
            if (!onCancel)
            {
                this.ShowDiscountDetail();
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.GetDiscountType(false);
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

        private void ShowDiscountDetail()
        {
            string expr_189 = this.DiscountResult;
            string text;
            if (!false)
            {
                text = expr_189;
            }
            bool flag;
            int arg_3D_0;
            if (!false)
            {
                flag = (text == null);
                if (!flag)
                {
                    arg_3D_0 = ((text != string.Empty) ? 1 : 0);
                    goto IL_3C;
                }
                if (!false)
                {
                    return;
                }
                return;
            }
        IL_44:
            while (!flag)
            {
                XDocument xDocument = XDocument.Parse(text);
                if (false)
                {
                    break;
                }
                int expr_5A = arg_3D_0 = 0;
                if (expr_5A != 0)
                {
                    goto IL_3C;
                }
                int num = expr_5A;
                IEnumerator<DiscountItem> enumerator = this._objItemDiscount.GetEnumerator();
                try
                {
                    while (true)
                    {
                        flag = enumerator.MoveNext();
                        if (!flag)
                        {
                            break;
                        }
                        DiscountItem item = enumerator.Current;
                        if (2 == 0)
                        {
                            break;
                        }
                       // XName Xname=(XName)"discountid";
                       // XElement xElement1 = xDocument.Element("Discount").Elements("Option").Single(x => x.Attribute(Xname,false));
                        XElement xElement = xDocument.Element("Discount").Elements("Option").Single(delegate(XElement x)
                        {
                            int? num2 = (int?)x.Attribute("discountid");
                            bool arg_35_0=false;
                            int expr_5E = item.DiscountID;// arg_35_0 = item.DiscountID;
                            int num3;
                            //if (!false)
                            //{
                            //    if (!false)
                            //    {
                            //        num3 = expr_5E;
                            //        goto IL_20;
                            //    }
                            //}
                            bool expr_3B;
                            do
                            {
                            IL_35:
                                bool flag2 = arg_35_0 != false;
                                if (-1 == 0)
                                {
                                    goto IL_20;
                                }
                                expr_3B = ((arg_35_0 = (flag2 ? true : false)) != false);
                            }
                            while (2 == 0);
                            return expr_3B;
                        IL_20:
                            arg_35_0 = (((num2.GetValueOrDefault() == num3 || 4 == 0) && num2.HasValue) ? true : false);
                            //goto IL_35;
                        });
                        double discountAmount = Convert.ToDouble(xElement.Attribute("discount").Value.ToString());
                        DataGridRow dataGridRow = (DataGridRow)this.dgDiscount.ItemContainerGenerator.ContainerFromIndex(num);
                        flag = (dataGridRow == null);
                        if (!flag)
                        {
                            TextBox textBox = this.FindByName("txtquantity", dataGridRow) as TextBox;
                            textBox.Text = discountAmount.ToString();
                        }
                        item.DiscountAmount = discountAmount;
                        num++;
                    }
                }
                finally
                {
                    flag = (enumerator == null);
                    if (!flag)
                    {
                        enumerator.Dispose();
                    }
                }
                if (2 != 0)
                {
                    if (!false)
                    {
                        break;
                    }
                    break;
                }
            }
            return;
        IL_3C:
            flag = (arg_3D_0 == 0);
            goto IL_44;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            double num = 0.0;
            int num2 = 0;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<Discount TotalPrice = '" + this.TotalCost + "'>");
            foreach (DiscountItem current in this._objItemDiscount)
            {
                DataGridRow root = (DataGridRow)this.dgDiscount.ItemContainerGenerator.ContainerFromIndex(num2);
                TextBox textBox = this.FindByName("txtquantity", root) as TextBox;
                double num3 = 0.0;
                if (double.TryParse(textBox.Text, out num3))
                {
                    if (current.IsPercentageDiscount)
                    {
                        double num4 = this.TotalCost * (num3 / 100.0);
                        num += num4;
                    }
                    else
                    {
                        num += num3;
                    }
                }
                stringBuilder.Append(string.Concat(new object[]
				{
					"<Option Name='",
					current.DiscountName.ToString(),
					"' discount='",
					num3,
					"'  InPercentmode='",
					current.IsPercentageDiscount.ToString(),
					"' discountid = '",
					current.DiscountID.ToString(),
					"' discountSyncCode = '",
					current.DiscountSyncCode.ToString(),
					"'/>"
				}));
                num2++;
            }
            stringBuilder.Append("</Discount>");
            this._result = new discount();
            this._result.DiscountDetail = stringBuilder.ToString();
            this._result.TotalDiscountAmount = num;
            this.HideHandlerDialog();
        }

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            this.GetDiscountType(true);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = null;
            this.HideHandlerDialog();
        }

        private void dgDiscount_CurrentCellChanged(object sender, EventArgs e)
        {
        }


    }
}
