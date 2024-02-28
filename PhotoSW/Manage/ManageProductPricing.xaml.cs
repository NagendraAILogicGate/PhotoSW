using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.Data;
using DigiPhoto.Utility.Repository.ValueType;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using PhotoSW.ViewModels;

namespace PhotoSW.Manage
{
    public partial class ManageProductPricing : Window, IComponentConnector
    {
        private List<ProductListWithPricing> _objPricingList = new List<ProductListWithPricing>();

       

        public ManageProductPricing()
        {
            this.InitializeComponent();
            this.GetStoreDropDown();
        }

        private void cmbStoreName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!false && -1 != 0)
            {
                try
                {
                    bool arg_1E_0 = this.cmbStoreName.SelectedValue.ToString() != "0";
                    bool expr_1E;
                    do
                    {
                        expr_1E = (arg_1E_0 = !arg_1E_0);
                    }
                    while (false);
                    if (!expr_1E)
                    {
                        this.GetPricingDataForStore(this.cmbStoreName.SelectedValue.ToInt32(false));
                    }
                    else
                    {
                        this.dgPricing.ItemsSource = null;
                    }
                }
                catch (Exception var_0_7D)
                {
                    if (!false)
                    {
                    }
                    if (5 != 0)
                    {
                    }
                }
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    List<ProductListWithPricing>.Enumerator expr_CF = this._objPricingList.GetEnumerator();
                    List<ProductListWithPricing>.Enumerator enumerator;
                    if (!false)
                    {
                        enumerator = expr_CF;
                    }
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            ProductListWithPricing current = enumerator.Current;
                            do
                            {
                                new ProductBusiness().SetProductPricingData(current.ProductTypeId, current.Price, new int?(current.SelectedCurrency.ToInt32(false)), new int?(LoginUser.UserId), new int?(this.cmbStoreName.SelectedValue.ToInt32(false)), current.IsAvailable);
                            }
                            while (false);
                        }
                    }
                    finally
                    {
                        do
                        {
                            ((IDisposable)enumerator).Dispose();
                        }
                        while (false);
                    }
                }
                catch (Exception var_1_DF)
                {
                    while (false)
                    {
                    }
                }
            }
            while (false);
        }

        private void GetStoreDropDown()
        {
            List<StoreInfo> storeName = new StoreSubStoreDataBusniess().GetStoreName();
            CommonUtility.BindComboWithSelect<StoreInfo>(this.cmbStoreName, storeName, "DG_Store_Name", "DG_Store_pkey", 0, ClientConstant.SelectString);
            Selector arg_37_0 = this.cmbStoreName;
            int expr_6C = LoginUser.StoreId;
            int num;
            if (!false)
            {
                num = expr_6C;
            }
            arg_37_0.SelectedValue = num.ToString();
            this.cmbStoreName.IsEnabled = false;
        }

        private void GetPricingDataForStore(int storeId)
        {
            do
            {
                this._objPricingList = new List<ProductListWithPricing>();
            }
            while (7 == 0);
            List<ProductPriceInfo> productPricingStoreWise = new ProductBusiness().GetProductPricingStoreWise(LoginUser.StoreId);
            if (productPricingStoreWise.Count == 0)
            {
                List<ProductTypeInfo> packageNames = new ProductBusiness().GetPackageNames(false);
                foreach (ProductTypeInfo current in packageNames)
                {
                    ProductListWithPricing productListWithPricing = new ProductListWithPricing();
                    productListWithPricing.IsAvailable = new bool?(false);
                    productListWithPricing.LstCurrency = new CurrencyBusiness().GetCurrencyList();
                    productListWithPricing.Price = new double?(0.0);
                    productListWithPricing.ProductType = current.DG_Orders_ProductType_Name;
                    productListWithPricing.ProductTypeId = new int?(current.DG_Orders_ProductType_pkey);
                    productListWithPricing.SelectedCurrency = new CurrencyBusiness().GetDefaultCurrency().ToString();
                    this._objPricingList.Add(productListWithPricing);
                }
            }
            else
            {
                List<ProductTypeInfo> packageNames = new ProductBusiness().GetPackageNames(false);
                List<int?> source = (from t in productPricingStoreWise
                                     select t.DG_Product_Pricing_ProductType).ToList<int?>();
                using (List<ProductTypeInfo>.Enumerator enumerator = packageNames.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        ProductTypeInfo item = enumerator.Current;
                        ProductListWithPricing productListWithPricing = new ProductListWithPricing();
                        if (source.Where(delegate(int? t)
                        {
                            bool arg_2C_0;
                            while (true)
                            {
                                int num = t.Value;
                                string arg_52_0 = num.ToString();
                                num = item.DG_Orders_ProductType_pkey;
                                bool arg_59_0 = arg_2C_0 = arg_52_0.Contains(num.ToString());
                                while (true)
                                {
                                    if (!false)
                                    {
                                        bool flag = arg_59_0;
                                        if (8 == 0)
                                        {
                                            break;
                                        }
                                        arg_59_0 = (arg_2C_0 = flag);
                                    }
                                    if (!false && !false)
                                    {
                                        return arg_2C_0;
                                    }
                                }
                            }
                            return arg_2C_0;
                        }).ToList<int?>().Count > 0)
                        {
                            productListWithPricing.IsAvailable = productPricingStoreWise.Where(delegate(ProductPriceInfo t)
                            {
                                if (false)
                                {
                                    goto IL_2F;
                                }
                                int? dG_Product_Pricing_ProductType;
                                if (!false)
                                {
                                    dG_Product_Pricing_ProductType = t.DG_Product_Pricing_ProductType;
                                }
                                if (7 == 0)
                                {
                                    goto IL_2D;
                                }
                                int expr_44 = item.DG_Orders_ProductType_pkey;
                                int num;
                                if (6 != 0)
                                {
                                    num = expr_44;
                                }
                                bool arg_2C_0 = dG_Product_Pricing_ProductType == num;
                            IL_2B:
                                bool flag = arg_2C_0;
                            IL_2D:
                            IL_2F:
                                bool expr_2F = arg_2C_0 = flag;
                                if (!false)
                                {
                                    return expr_2F;
                                }
                                goto IL_2B;
                            }).FirstOrDefault<ProductPriceInfo>().DG_Product_Pricing_IsAvaliable;
                            productListWithPricing.LstCurrency = new CurrencyBusiness().GetCurrencyList();
                            productListWithPricing.Price = productPricingStoreWise.Where(delegate(ProductPriceInfo t)
                            {
                                if (false)
                                {
                                    goto IL_2F;
                                }
                                int? dG_Product_Pricing_ProductType;
                                if (!false)
                                {
                                    dG_Product_Pricing_ProductType = t.DG_Product_Pricing_ProductType;
                                }
                                if (7 == 0)
                                {
                                    goto IL_2D;
                                }
                                int expr_44 = item.DG_Orders_ProductType_pkey;
                                int num;
                                if (6 != 0)
                                {
                                    num = expr_44;
                                }
                                bool arg_2C_0 = dG_Product_Pricing_ProductType == num;
                            IL_2B:
                                bool flag = arg_2C_0;
                            IL_2D:
                            IL_2F:
                                bool expr_2F = arg_2C_0 = flag;
                                if (!false)
                                {
                                    return expr_2F;
                                }
                                goto IL_2B;
                            }).FirstOrDefault<ProductPriceInfo>().DG_Product_Pricing_ProductPrice;
                            productListWithPricing.ProductType = item.DG_Orders_ProductType_Name;
                            productListWithPricing.ProductTypeId = new int?(item.DG_Orders_ProductType_pkey);
                            productListWithPricing.SelectedCurrency = new CurrencyBusiness().GetDefaultCurrency().ToString();
                        }
                        else
                        {
                            productListWithPricing.IsAvailable = new bool?(false);
                            productListWithPricing.LstCurrency = new CurrencyBusiness().GetCurrencyList();
                            do
                            {
                                productListWithPricing.Price = new double?(0.0);
                                productListWithPricing.ProductType = item.DG_Orders_ProductType_Name;
                                productListWithPricing.ProductTypeId = new int?(item.DG_Orders_ProductType_pkey);
                            }
                            while (false);
                            productListWithPricing.SelectedCurrency = new CurrencyBusiness().GetDefaultCurrency().ToString();
                        }
                        this._objPricingList.Add(productListWithPricing);
                    }
                }
            }
            this.dgPricing.ItemsSource = this._objPricingList;
        }

      
    }
}
