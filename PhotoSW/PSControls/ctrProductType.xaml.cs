using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.Data;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;

namespace PhotoSW.PSControls
{
    public partial class ctrProductType : UserControl, IComponentConnector//, IStyleConnector
    {
        private UIElement _parent;

        private bool _hideRequest = false;

        private int _result;

        public static readonly DependencyProperty Message1Property = DependencyProperty.Register("Message1", typeof(string), typeof(ModalDialog), new UIPropertyMetadata(string.Empty));

       

        public List<Product> _ProductType
        {
            get;
            set;
        }

        public string ItemNumber
        {
            get;
            set;
        }

        public int _SelectedProductID
        {
            get;
            set;
        }

        public string Message1
        {
            get
            {
                return (string)base.GetValue(ctrProductType.Message1Property);
            }
            set
            {
                base.SetValue(ctrProductType.Message1Property, value);
            }
        }

        public ctrProductType()
        {
            this.InitializeComponent();
            this.FillGroupCombo();
            this.lstProductType.ItemsSource = this._ProductType;
        }

        private void FillGroupCombo()
        {
            List<SubStoresInfo> logicalSubStore = new StoreSubStoreDataBusniess().GetLogicalSubStore();
            CommonUtility.BindComboWithSelect<SubStoresInfo>(this.CmbGroup, logicalSubStore, "DG_SubStore_Name", "DG_SubStore_pkey", 0, ClientConstant.SelectString);
            SubStoresInfo substoreData = new StoreSubStoreDataBusniess().GetSubstoreData(LoginUser.SubStoreId);
            if (substoreData != null)
            {
                this.CmbGroup.SelectedValue = ((substoreData.LogicalSubStoreID == 0) ? LoginUser.SubStoreId.ToString() : substoreData.LogicalSubStoreID.ToString());
            }
            else
            {
                this.CmbGroup.SelectedValue = LoginUser.SubStoreId.ToString();
            }
            string value = this.CmbGroup.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(value) && Convert.ToInt16(value) > 0)
            {
                this.FillProductType(Convert.ToInt32(value));
            }
            else
            {
                this.CmbGroup.SelectedValue = "0";
                this.FillProductType(0);
            }
        }

        private void CmbGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox;
            if (!false)
            {
                if (-1 == 0)
                {
                    goto IL_19;
                }
                comboBox = (sender as ComboBox);
            }
            bool arg_60_0 = comboBox.SelectedValue == null;
        IL_17:
            bool flag = arg_60_0;
        IL_19:
            bool expr_63 = arg_60_0 = flag;
            if (!false)
            {
                if (!expr_63)
                {
                    string text = comboBox.SelectedValue.ToString();
                    int num = 0;
                    flag = !int.TryParse(text, out num);
                    if (!false)
                    {
                        if (4 != 0 && flag)
                        {
                            goto IL_4E;
                        }
                    }
                    this.FillProductType(Convert.ToInt32(text));
                IL_4E: ;
                }
                return;
            }
            goto IL_17;
        }

        private void FillProductType(int SubStoreID)
        {
            try
            {
                List<ProductTypeInfo> expr_1D2 = new ProductBusiness().GetProductTypeforOrder(SubStoreID);
                List<ProductTypeInfo> list;
                if (!false)
                {
                    list = expr_1D2;
                }
                IOrderedEnumerable<ProductTypeInfo> orderedEnumerable = from t in list.FindAll(delegate(ProductTypeInfo t)
                {
                    int? dG_Orders_ProductNumber = t.DG_Orders_ProductNumber;
                    if (dG_Orders_ProductNumber.GetValueOrDefault() == 0)
                    {
                        goto IL_0C;
                    }
                    goto IL_18;
                IL_19:
                    while (false)
                    {
                    }
                    bool arg_45_0;
                    bool flag2 = arg_45_0;
                    bool arg_29_0;
                    if (8 != 0)
                    {
                        if (!false)
                        {
                            arg_29_0 = flag2;
                            return arg_29_0;
                        }
                        goto IL_18;
                    }
                IL_0C:
                    arg_45_0 = (arg_29_0 = !dG_Orders_ProductNumber.HasValue);
                    if (true)
                    {
                        goto IL_19;
                    }
                    return arg_29_0;
                IL_18:
                    arg_45_0 = true;
                    goto IL_19;
                })
                                                                        orderby t.DG_Orders_ProductNumber
                                                                        select t;
                this._ProductType = new List<Product>();
                if (4 != 0)
                {
                    using (IEnumerator<ProductTypeInfo> enumerator = orderedEnumerable.GetEnumerator())
                    {
                        while (true)
                        {
                            bool flag = enumerator.MoveNext();
                            if (!flag)
                            {
                                break;
                            }
                            ProductTypeInfo current = enumerator.Current;
                            Product product;
                            int arg_DE_0;
                            bool isBundled=false;
                            if (2 != 0)
                            {
                                product = new Product();
                                product.ProductID = current.DG_Orders_ProductType_pkey;
                                product.ProductName = current.DG_Orders_ProductType_Name.ToString();
                                int expr_C3 = arg_DE_0 = 0;
                                if (expr_C3 == 0)
                                {
                                    isBundled = (expr_C3 != 0);
                                    flag = !current.DG_Orders_ProductType_IsBundled.HasValue;
                                    goto IL_DC;
                                }
                                goto IL_DE;
                            }
                        IL_146:
                            if (false)
                            {
                                goto IL_DC;
                            }
                            product.MaxQuantity = current.DG_MaxQuantity;
                            product.IsPrintType = new int?(current.IsPrintType);
                            do
                            {
                                this._ProductType.Add(product);
                                if (5 == 0)
                                {
                                    goto IL_E1;
                                }
                            }
                            while (4 == 0);
                            if (6 != 0)
                            {
                                continue;
                            }
                        IL_FB:
                            product.ProductIcon = current.DG_Orders_ProductType_Image.ToString();
                            product.DiscountOption = current.DG_Orders_ProductType_DiscountApplied.Value;
                            product.IsPackage = current.DG_IsPackage;
                            product.IsAccessory = current.DG_IsAccessory.Value;
                            goto IL_146;
                        IL_F3:
                            product.IsBundled = isBundled;
                            goto IL_FB;
                        IL_E1:
                            isBundled = current.DG_Orders_ProductType_IsBundled.Value;
                            goto IL_F3;
                        IL_DE:
                            if (arg_DE_0 == 0)
                            {
                                goto IL_E1;
                            }
                            goto IL_F3;
                        IL_DC:
                            arg_DE_0 = (flag ? 1 : 0);
                            goto IL_DE;
                        }
                    }
                }
                this.lstProductType.ItemsSource = this._ProductType;
            }
            catch
            {
            }
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public int ShowHandlerDialog(string message)
        {
            this.Message1 = message;
            while (-1 == 0)
            {
            }
            base.Visibility = Visibility.Visible;
            this.lstProductType.ItemsSource = this._ProductType;
            this.SetInitial();
            this._parent.IsEnabled = true;
            this._hideRequest = false;
            int arg_DB_0;
            while (true)
            {
                bool arg_74_0;
                bool arg_C3_0 = arg_74_0 = this._hideRequest;
                int arg_C0_0 = 0;
                while (true)
                {
                    int arg_71_0;
                    int expr_C0 = arg_71_0 = arg_C0_0;
                    bool arg_C5_0;
                    if (expr_C0 == 0)
                    {
                        arg_C5_0 = ((arg_C3_0 ? 1 : 0) == expr_C0);
                        goto IL_C5;
                    }
                IL_71:
                    int expr_71 = arg_C0_0 = arg_71_0;
                    if (expr_71 != 0)
                    {
                        continue;
                    }
                    int arg_7D_0;
                    arg_C5_0 = ((arg_7D_0 = ((arg_74_0 == (expr_71 != 0)) ? 1 : 0)) != 0);
                    if (!false)
                    {
                        goto IL_7C;
                    }
                    goto IL_C5;
                IL_65:
                    arg_C3_0 = (arg_74_0 = base.Dispatcher.HasShutdownFinished);
                    arg_71_0 = 0;
                    goto IL_71;
                IL_C5:
                    bool flag = arg_C5_0;
                    bool expr_C6 = (arg_DB_0 = (flag ? 1 : 0)) != 0;
                    if (false)
                    {
                        return arg_DB_0;
                    }
                    if (expr_C6)
                    {
                        if (!base.Dispatcher.HasShutdownStarted)
                        {
                            goto IL_65;
                        }
                        arg_7D_0 = 0;
                        goto IL_7C;
                    }
                IL_CF:
                    if (!false)
                    {
                        goto Block_8;
                    }
                    goto IL_65;
                IL_7C:
                    if (arg_7D_0 == 0)
                    {
                        goto IL_CF;
                    }
                    break;
                }
                base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                }));
                Thread.Sleep(20);
            }
        Block_8:
            arg_DB_0 = this._result;
            return arg_DB_0;
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

        public void SetInitial()
        {
            int arg_B4_0;
            for (int i = 0; i < this.lstProductType.Items.Count; i = arg_B4_0)
            {
                DependencyObject dependencyObject = this.lstProductType.ItemContainerGenerator.ContainerFromIndex(i);
                bool expr_31 = (arg_B4_0 = ((dependencyObject == null) ? 1 : 0)) != 0;
                if (!false)
                {
                    if (!expr_31)
                    {
                        RadioButton radioButton = ctrProductType.FindVisualChild<RadioButton>(dependencyObject);
                        if (radioButton != null)
                        {
                            radioButton.IsChecked = new bool?(false);
                        }
                        Product product = (Product)this.lstProductType.Items[i];
                        int arg_80_0 = this._SelectedProductID;
                        bool flag = 1 == 0;
                        if (product.ProductID == this._SelectedProductID)
                        {
                            radioButton.IsChecked = new bool?(true);
                        }
                    }
                    arg_B4_0 = i + 1;
                }
            }
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            int num = 0;
            childItem result;
            while (true)
            {
                int arg_83_0 = num;
                int arg_83_1 = VisualTreeHelper.GetChildrenCount(obj);
                int expr_75;
                int expr_77;
                while (true)
                {
                IL_83:
                    bool flag = arg_83_0 < arg_83_1;
                    bool arg_89_0 = flag;
                    while (true)
                    {
                    IL_89:
                        if (!arg_89_0)
                        {
                            result = default(childItem);
                            goto IL_9B;
                        }
                        goto IL_0D;
                    IL_23:
                        DependencyObject dependencyObject;
                        int arg_34_0;
                        arg_83_0 = (arg_34_0 = ((dependencyObject is childItem) ? 1 : 0));
                        int arg_31_0 = 0;
                        while (true)
                        {
                            int expr_31 = arg_83_1 = arg_31_0;
                            if (expr_31 != 0)
                            {
                                goto IL_83;
                            }
                            if (arg_34_0 != expr_31)
                            {
                                break;
                            }
                            childItem childItem1 = ctrProductType.FindVisualChild<childItem>(dependencyObject);
                            bool expr_5E = arg_89_0 = (childItem1 == null);
                            if (4 == 0)
                            {
                                goto IL_89;
                            }
                            if (!expr_5E)
                            {
                                goto Block_4;
                            }
                            expr_75 = (arg_34_0 = (arg_83_0 = num));
                            expr_77 = (arg_31_0 = 1);
                            if (expr_77 != 0)
                            {
                                goto Block_7;
                            }
                        }
                        result = (childItem)((object)dependencyObject);
                        goto IL_9B;
                    Block_4:
                        if (!false && -1 != 0)
                        {
                            childItem childItem1 = ctrProductType.FindVisualChild<childItem>(dependencyObject);
                            result = childItem1;
                            goto IL_9B;
                        }
                    IL_0D:
                        DependencyObject expr_B5 = VisualTreeHelper.GetChild(obj, num);
                        if (7 == 0)
                        {
                            goto IL_23;
                        }
                        dependencyObject = expr_B5;
                        goto IL_23;
                    IL_9B:
                        if (4 != 0)
                        {
                            return result;
                        }
                        goto IL_23;
                    }
                }
            Block_7:
                num = expr_75 + expr_77;
            }
            return result;
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            int arg_D4_0 = 0;
            int result;
            int num = 0;

            DependencyObject dependencyObject = (DependencyObject)sender;
            while (true)
            {
                result = arg_D4_0;
               // num;
                while (true)
                {
                    int arg_43_0;
                    int expr_A6 = arg_43_0 = num;
                    bool arg_BC_0;
                    if (8 != 0)
                    {
                        arg_BC_0 = (expr_A6 < this.lstProductType.Items.Count);
                        //goto IL_BC;
                    }
                  
                    int expr_A1;
                    do
                    {
                   // IL_43:
                        if (arg_43_0 == 0)
                        {
                            RadioButton radioButton = ctrProductType.FindVisualChild<RadioButton>(dependencyObject);
                            bool flag = radioButton == null;
                            bool arg_75_0;
                            bool expr_53 = arg_75_0 = flag;
                            //if (false)
                            //{
                            //    goto IL_75;
                            //}
                            if (!expr_53)
                            {
                                bool expr_6C = arg_BC_0 = !Convert.ToBoolean(radioButton.IsChecked);
                                if (true)
                                {
                                    flag = expr_6C;
                                    arg_75_0 = flag;
                                    goto IL_75;
                                }
                                goto IL_BC;
                            }
                            goto IL_9E;
                        IL_75:
                            if (!arg_75_0)
                            {
                                Product product = (Product)this.lstProductType.Items[num];
                                result = product.ProductID;
                                if (-1 == 0)
                                {
                                    return;
                                }
                            }
                        }
                    IL_9E:
                        expr_A1 = (arg_43_0 = num + 1);
                    }
                    while (7 == 0);
                    num = expr_A1;
                   // continue;
                IL_BC:
                    if (!arg_BC_0)
                    {
                        goto Block_9;
                    }
                    dependencyObject = this.lstProductType.ItemContainerGenerator.ContainerFromIndex(num);
                    bool expr_37 = (arg_D4_0 = ((dependencyObject == null) ? 1 : 0)) != 0;
                    if (true)
                    {
                        bool flag = expr_37;
                        arg_43_0 = (flag ? 1 : 0);
                        //goto IL_43;
                    }
                      break;
                }
            }
        Block_9:
            this._result = result;
            this.HideHandlerDialog();
        }

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            do
            {
            IL_00:
                int num = 0;
                while (true)
                {
                    int arg_81_0 = num++;
                    while (true)
                    {
                    IL_71:
                        bool flag = arg_81_0 < this.lstProductType.Items.Count;
                        while (flag)
                        {
                            if (false)
                            {
                                goto IL_4A;
                            }
                            DependencyObject dependencyObject = this.lstProductType.ItemContainerGenerator.ContainerFromIndex(num);
                            flag = (dependencyObject == null);
                            if (false)
                            {
                                goto IL_58;
                            }
                            RadioButton radioButton;
                            if (!flag)
                            {
                                radioButton = ctrProductType.FindVisualChild<RadioButton>(dependencyObject);
                                goto IL_4A;
                            }
                            goto IL_6B;
                        IL_67:
                            if (3 != 0)
                            {
                                goto IL_6B;
                            }
                            continue;
                        IL_4A:
                            bool expr_4C = (arg_81_0 = ((radioButton == null) ? 1 : 0)) != 0;
                            if (false)
                            {
                                goto IL_71;
                            }
                            flag = expr_4C;
                            if (false)
                            {
                                goto IL_00;
                            }
                            if (flag)
                            {
                                goto IL_67;
                            }
                        IL_58:
                            radioButton.IsChecked = new bool?(false);
                            goto IL_67;
                        }
                        goto Block_5;
                    }
                IL_6B:
                    num++;
                }
            Block_5: ;
            }
            while (4 == 0);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this._result = -2;
            this.HideHandlerDialog();
        }

        private void rdoSelect_Click(object sender, RoutedEventArgs e)
        {
        this.btnSubmit_Click(sender, e);
        }

       
    }
}
