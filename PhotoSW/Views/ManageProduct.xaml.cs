using DigiAuditLogger;
using PhotoSW.Common;
using DigiPhoto.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Manage;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using Excel;
using FrameworkHelper;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using PhotoSW.Views;
using PhotoSW.ViewModels;
using PhotoSW.DataLayer;
//using DigiPhoto;

namespace PhotoSW.Views
{
    public partial class ManageProduct : Window, IComponentConnector, IStyleConnector
    {
        private bool isEditGroupProduct = false;

        private int _productId = 0;

        private string packagefilename = string.Empty;

        private string _filedatasource = string.Empty;

        private string _syncCode = string.Empty;

        private string _syncodeforPackage = string.Empty;

        private int? _isInvisible = null;

        private DataTable _dtExcelRecords;

        private DataTable _dt;

        private BackgroundWorker BackupWorker = new BackgroundWorker();

        private BusyWindow bs = new BusyWindow();

        private List<ProductTypeList> lstProductTypeList;

        private int packageId = 0;

        private bool IsBeingEdited = false;

        private int GroupPkey = 0;

        private bool isEditGroup = false;

        private int GroupProductPkey = 0;


        public ManageProduct()
        {
            try
            {
                this.InitializeComponent();
                this.GetProductTypeList();
                this.GetPackageDetails();
                this.txbUserName.Text = LoginUser.UserName;
                this.txbStoreName.Text = LoginUser.StoreName;
                this.btnSave.IsDefault = true;
                this.FillSubstore();
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                do
                {
                    do
                    {
                        AuditLog.AddUserLog(LoginUser.UserId, 39, "Logged out at ");
                    }
                    while (8 == 0);
                    Login login = new Login();
                    Window expr_45 = login;
                    if (!false)
                    {
                        expr_45.Show();
                    }
                    do
                    {
                        if (!false)
                        {
                            base.Close();
                        }
                    }
                    while (5 == 0);
                }
                while (false);
            }
            catch (Exception serviceException)
            {
                string message;
                if (2 != 0)
                {
                    message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                }
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            finally
            {
                MemoryManagement.FlushMemory();
            }
        }

        private bool IsPricingUpdated(int ProductID, double newprice, out string OldPrice)
        {
            if (!false)
            {
            }
            ProductBusiness expr_78 = new ProductBusiness();
            ProductBusiness productBusiness;
            if (!false)
            {
                productBusiness = expr_78;
            }
            ProductTypeInfo productTypeListById = productBusiness.GetProductTypeListById(this._productId);
            int arg_70_0;
            bool expr_38 = (arg_70_0 = ((productTypeListById.DG_Product_Pricing_ProductPrice != newprice) ? 1 : 0)) != 0;
            bool flag2;
            if (true)
            {
                bool flag = expr_38;
                while (!flag)
                {
                    if (3 != 0)
                    {
                        OldPrice = productTypeListById.DG_Product_Pricing_ProductPrice.ToString();
                        flag2 = false;
                        if (!false)
                        {
                            goto IL_76;
                        }
                        break;
                    }
                }
                OldPrice = productTypeListById.DG_Product_Pricing_ProductPrice.ToString();
                arg_70_0 = 1;
            }
            int arg_77_0;
            int expr_70 = arg_77_0 = arg_70_0;
            if (expr_70 == 0)
            {
                return arg_77_0 != 0;
            }
            flag2 = (expr_70 != 0);
        IL_76:
            arg_77_0 = (flag2 ? 1 : 0);
            return arg_77_0 != 0;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string syncCode = string.Empty;

            try
            {
                if (this.Isvalidate())
                {
                    int? isInvisible;
                    bool flag2;
                    ProductBusiness productBusiness;
                    int arg_358_0;
                    string empty;
                    int ProductTypePkey = 0;
                    int expr_2DB;
                    string[] array;
                    while (true)
                    {
                        bool flag = false;
                        int arg_3A_0 = this._productId;
                        int arg_3A_1 = 0;
                        bool? isChecked;
                        while (true)
                        {
                            if (arg_3A_0 > arg_3A_1)
                            {
                                flag = true;
                            }
                            if (false)
                            {
                                goto IL_2C6;
                            }
                            isInvisible = null;
                            int num = Convert.ToInt32(ApplicationObjectEnum.Product);
                            bool flag3;
                            if (4 != 0)
                            {
                                syncCode = CommonUtility.GetUniqueSynccode(num.ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                                flag2 = !flag;
                                if (!true)
                                {
                                    goto IL_17B;
                                }
                                if (flag2)
                                {
                                    break;
                                }
                                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Alert: Are you sure you want to update the product details?", "Temper Alert", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                                if (messageBoxResult != MessageBoxResult.Yes)
                                {
                                    goto IL_3AC;
                                }
                                if (6 == 0)
                                {
                                    goto IL_2C7;
                                }
                                productBusiness = new ProductBusiness();
                                ProductTypeInfo productByID = productBusiness.GetProductByID(this._productId);
                                this._syncodeforPackage = productByID.SyncCode;
                                isChecked = this.chkPackage.IsChecked;
                                if (isChecked == true)
                                {
                                    string str = this._syncodeforPackage.Remove(this._syncodeforPackage.Length - 2, 2);
                                    this._syncodeforPackage = str + Convert.ToInt32(ApplicationObjectEnum.Package).ToString().PadLeft(2, '0');
                                }
                                isChecked = this.chkInvisible.IsChecked;
                                if (isChecked.GetValueOrDefault())
                                {
                                    goto IL_17B;
                                }
                                int arg_187_0 = 0;
                            IL_185:
                                bool expr_187 = (arg_3A_0 = (arg_358_0 = ((arg_187_0 == 0) ? 1 : 0))) != 0;
                                if (false)
                                {
                                    goto IL_2DB;
                                }
                                if (!expr_187)
                                {
                                    isInvisible = new int?(0);
                                }
                                else if (productByID.DG_Orders_ProductNumber == 0)
                                {
                                    isInvisible = null;
                                    if (false)
                                    {
                                        goto IL_57C;
                                    }
                                }
                                else
                                {
                                    isInvisible = productByID.DG_Orders_ProductNumber;
                                }
                                empty = string.Empty;
                                flag3 = this.IsPricingUpdated(this._productId, this.txtProductPrice.Text.ToDouble(false), out empty);
                                ProductTypePkey = String.IsNullOrEmpty(this.hdnProductTypePkey.Text) ? 0 : Convert.ToInt32(this.hdnProductTypePkey.Text);
                                if (new ProductBusiness().SetProductTypeInfo(this._productId, this.txtProductName.Text, this.txtPRoductDescription.Text, this.chkDiscount.IsChecked, this.txtProductPrice.Text, LoginUser.StoreId, LoginUser.UserId, this.chkPackage.IsChecked == true, this.chkIsActive.IsChecked, this.chkAccessory.IsChecked, this.chkTaxIncluded.IsChecked, this.txtProductCode.Text, syncCode, this._syncodeforPackage, isInvisible, this.chkWaterMarkIncluded.IsChecked, Convert.ToInt32(this.cmbSite.SelectedValue), ProductTypePkey))
                                {
                                    this.GetProductTypeList();
                                    this.GetPackageDetails();
                                    goto IL_2C6;
                                }
                                goto IL_3AB;
                            IL_17B:
                                arg_187_0 = (isChecked.HasValue ? 1 : 0);
                                goto IL_185;
                            }
                            break;
                        IL_2DB:
                            expr_2DB = (arg_3A_1 = 32);
                            array = new string[7];
                            array[0] = "Product (";
                            array[1] = this.txtProductName.Text;
                            array[2] = ") pricing has been changed from ";
                            if (!false)
                            {
                                goto Block_18;
                            }
                            continue;
                        IL_2C7:
                            if (flag3)
                            {
                                arg_358_0 = (arg_3A_0 = LoginUser.UserId);
                                goto IL_2DB;
                            }
                            goto IL_361;
                        IL_2C6:
                            goto IL_2C7;
                        }
                        isChecked = this.chkPackage.IsChecked;
                        if (isChecked == true)
                        {
                            syncCode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Package).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                        }
                        isChecked = this.chkInvisible.IsChecked;
                        flag2 = !(isChecked == true);
                        if (!false)
                        {
                            goto Block_22;
                        }
                    }
                Block_18:
                    array[3] = empty.ToDouble(false).ToString();
                    array[4] = " to ";
                    array[5] = this.txtProductPrice.Text.ToDouble(false).ToString();
                    array[6] = " on ";
                    AuditLog.AddUserLog(arg_358_0, expr_2DB, string.Concat(array));
                    goto IL_38A;
                IL_361:
                    AuditLog.AddUserLog(LoginUser.UserId, 26, "Product (" + this.txtProductName.Text + ") has been updated on ");
                IL_38A:
                    System.Windows.MessageBox.Show("[" + this.txtProductName.Text + "] Product has been updated successfully");
                IL_3AB:
                IL_3AC:
                    goto IL_561;
                Block_22:
                    if (!flag2)
                    {
                        isInvisible = new int?(0);
                    }
                    productBusiness = new ProductBusiness();
                    ProductTypePkey = String.IsNullOrEmpty(this.hdnProductTypePkey.Text) ? 0 : Convert.ToInt32(this.hdnProductTypePkey.Text);
                    if (productBusiness.SetProductTypeInfo(this._productId, this.txtProductName.Text, this.txtPRoductDescription.Text, this.chkDiscount.IsChecked, this.txtProductPrice.Text, LoginUser.StoreId, LoginUser.UserId, this.chkPackage.IsChecked==true, this.chkIsActive.IsChecked, this.chkAccessory.IsChecked, this.chkTaxIncluded.IsChecked, this.txtProductCode.Text, syncCode, this._syncodeforPackage, isInvisible, this.chkWaterMarkIncluded.IsChecked, Convert.ToInt32(this.cmbSite.SelectedValue), ProductTypePkey))
                    {
                        this.GetProductTypeList();
                        this.GetPackageDetails();
                        //AuditLog.AddUserLog(LoginUser.UserId, 28, "Product (" + this.txtProductName.Text + ") has been created on " + new CustomBusineses().ServerDateTime().ToShortDateString());
                        System.Windows.MessageBox.Show("[" + this.txtProductName.Text + "] Product details has been created successfully");
                    }
                IL_561:
                    this.ClearControls();
                    if (!false)
                    {
                        goto IL_57B;
                    }
                }
                System.Windows.MessageBox.Show("Please enter all required values");
            IL_57B:
            IL_57C:;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnImport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (false)
                {
                    goto IL_0F;
                }
            IL_05:
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Multiselect = false;
            IL_0F:
                if (false)
                {
                    goto IL_05;
                }
                openFileDialog.Filter = "Excel documents (.xls)|*.xls";
                if (8 == 0)
                {
                    goto IL_05;
                }
                openFileDialog.ShowDialog();
                this.GetProductsFromExcel(openFileDialog.FileName);
            }
            catch (Exception serviceException)
            {
                string message;
                do
                {
                    message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    if (false)
                    {
                        goto IL_75;
                    }
                }
                while (false);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            IL_75:;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                do
                {
                    this.ClearControls();
                }
                while (false || 7 == 0);
            }
            catch (Exception serviceException)
            {
                do
                {
                    string message;
                    do
                    {
                        message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    }
                    while (false);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (false);
            }
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
                IL_19:;
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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                try
                {
                    ProductTypeInfo productTypebyProductId;
                    bool flag;
                    bool arg_16A_0;
                    while (true)
                    {
                        bool arg_4D_0;
                        if (3 != 0)
                        {
                            new System.Windows.Controls.Button();
                            System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                            this._productId = button.CommandParameter.ToInt32(false);
                            this.hdnProductTypePkey.Text = this._productId.ToString();
                            productTypebyProductId = this.GetProductTypebyProductId();
                            arg_4D_0 = (productTypebyProductId == null);
                            goto IL_4D;
                        }
                    IL_80:
                        this.chkDiscount.IsChecked = productTypebyProductId.DG_Orders_ProductType_DiscountApplied;
                        this.txtProductPrice.Text = productTypebyProductId.DG_Product_Pricing_ProductPrice.ToString();
                        bool expr_AF = arg_4D_0 = productTypebyProductId.DG_IsPackage;
                        if (!false)
                        {
                            if (!expr_AF)
                            {
                                this.chkPackage.IsEnabled = false;
                            }
                            else
                            {
                                this.chkPackage.IsEnabled = true;
                            }
                            this.chkPackage.IsChecked = new bool?(productTypebyProductId.DG_IsPackage);
                            if (2 == 0)
                            {
                                goto IL_191;
                            }
                            this.chkIsActive.IsChecked = productTypebyProductId.DG_IsActive;
                            this.chkAccessory.IsChecked = productTypebyProductId.DG_IsAccessory;
                            this.chkTaxIncluded.IsChecked = productTypebyProductId.DG_IsTaxEnabled;
                            this.txtProductCode.Text = productTypebyProductId.DG_Orders_ProductCode;
                            if (7 != 0)
                            {
                                break;
                            }
                            continue;
                        }
                    IL_4D:
                        flag = arg_4D_0;
                        bool expr_4F = arg_16A_0 = flag;
                        if (-1 == 0)
                        {
                            goto IL_16A;
                        }
                        if (!expr_4F)
                        {
                            this.txtProductName.Text = productTypebyProductId.DG_Orders_ProductType_Name;
                            this.txtPRoductDescription.Text = productTypebyProductId.DG_Orders_ProductType_Desc;
                            goto IL_80;
                        }
                        goto IL_1BC;
                    }
                    int? dG_Orders_ProductNumber = productTypebyProductId.DG_Orders_ProductNumber;
                    int arg_164_0;
                    if (dG_Orders_ProductNumber.GetValueOrDefault() == 0)
                    {
                        arg_164_0 = (dG_Orders_ProductNumber.HasValue ? 1 : 0);
                    }
                    else
                    {
                        arg_164_0 = 0;
                    }
                IL_15C:
                    if (7 == 0)
                    {
                        goto IL_15C;
                    }
                    flag = (arg_164_0 == 0);
                    arg_16A_0 = flag;
                IL_16A:
                    if (!arg_16A_0)
                    {
                        this.chkInvisible.IsChecked = new bool?(true);
                    }
                    else
                    {
                        this.chkInvisible.IsChecked = new bool?(false);
                    }
                IL_191:
                    this.chkWaterMarkIncluded.IsChecked = productTypebyProductId.DG_IsWaterMarkIncluded;
                    this.cmbSite.SelectedValue = productTypebyProductId.DG_SubStore_pkey;
                IL_1BC:;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new System.Windows.Controls.Button();
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                string dG_Orders_ProductType_Name = "";
                while (true)
                {
                    this._productId = button.CommandParameter.ToInt32(false);
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Alert: Are you sure you want to delete the product details?", "Temper Alert", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
                    bool arg_94_0;
                    int arg_50_0;
                    int arg_8B_0 = arg_50_0 = ((arg_94_0 = (messageBoxResult == MessageBoxResult.Yes)) ? 1 : 0);
                    if (7 == 0)
                    {
                        goto IL_91;
                    }
                    int arg_50_1 = 0;
                IL_50:
                    bool expr_50 = (arg_8B_0 = ((arg_50_0 == arg_50_1) ? 1 : 0)) != 0;
                    if (4 == 0)
                    {
                        goto IL_8A;
                    }
                    if (expr_50)
                    {
                        goto IL_EE;
                    }
                    if (true)
                    {
                        ProductBusiness productBusiness = new ProductBusiness();
                        dG_Orders_ProductType_Name = productBusiness.GetProductTypeListById(this._productId).DG_Orders_ProductType_Name;
                        arg_8B_0 = (new ProductBusiness().DeleteProductType(this._productId) ? 1 : 0);
                        goto IL_8A;
                    }
                    continue;
                IL_91:
                    if (6 != 0)
                    {
                        if (arg_94_0)
                        {
                            goto IL_E0;
                        }
                        int expr_97 = arg_50_0 = LoginUser.UserId;
                        int expr_9E = arg_50_1 = 27;
                        if (expr_9E == 0)
                        {
                            goto IL_50;
                        }
                        //string dG_Orders_ProductType_Name;
                        AuditLog.AddUserLog(expr_97, expr_9E, "Product (" + dG_Orders_ProductType_Name + ") has been deleted on ");
                        System.Windows.MessageBox.Show("Record deleted successfully");
                        this.GetProductTypeList();
                        this.GetPackageDetails();
                        if (!false)
                        {
                            break;
                        }
                        continue;
                    }
                IL_8A:
                    bool flag = arg_8B_0 == 0;
                    arg_94_0 = ((arg_8B_0 = (flag ? 1 : 0)) != 0);
                    goto IL_91;
                }
                this._productId = 0;
                goto IL_ED;
            IL_E0:
                System.Windows.MessageBox.Show("Record is in use");
            IL_ED:
            IL_EE:;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool Isvalidate()
        {
            bool result = true;
            if (string.IsNullOrEmpty(this.txtProductName.Text))
            {
                result = false;
                this.txtProductName.Focus();
            }
            bool arg_80_0;
            int expr_4D = (arg_80_0 = string.IsNullOrEmpty(this.txtPRoductDescription.Text)) ? 1 : 0;
            int arg_80_1;
            int expr_53 = arg_80_1 = 0;
            if (expr_53 != 0)
            {
                goto IL_80;
            }
            if (expr_4D == expr_53)
            {
                goto IL_6F;
            }
        IL_5C:
            result = false;
            int arg_D2_0 = this.txtPRoductDescription.Focus() ? 1 : 0;
            if (3 == 0)
            {
                goto IL_D1;
            }
        IL_6F:
            arg_80_0 = string.IsNullOrEmpty(this.txtProductCode.Text);
        IL_7F:
            arg_80_1 = 0;
        IL_80:
            if ((arg_80_0 ? 1 : 0) == arg_80_1)
            {
                goto IL_96;
            }
            result = false;
        IL_89:
            this.txtProductCode.Focus();
        IL_96:
            bool arg_AC_0 = !string.IsNullOrEmpty(this.txtProductPrice.Text);
            if (!false)
            {
                if (!arg_AC_0)
                {
                    result = false;
                    if (7 == 0)
                    {
                        goto IL_5C;
                    }
                    this.txtProductPrice.Focus();
                }
            }
            arg_D2_0 = ((this.cmbSite.SelectedIndex == 0) ? 1 : 0);
        IL_D1:
            bool expr_D2 = arg_80_0 = (arg_D2_0 == 0);
            if (!false)
            {
                if (!expr_D2)
                {
                    result = false;
                    this.cmbSite.Focus();
                    if (2 == 0)
                    {
                        goto IL_89;
                    }
                }
                return result;
            }
            goto IL_7F;
        }

        private void ClearControls()
        {
            this.hdnProductTypePkey.Text = string.Empty;
            this.txtPRoductDescription.Text = "";
            if (-1 != 0)
            {
                this.txtProductName.Text = "";
                this.txtProductPrice.Text = "";
                this.txtProductCode.Text = "";
                this._productId = 0;
                this.chkAccessory.IsChecked = new bool?(false);
                this.chkDiscount.IsChecked = new bool?(false);
                this.chkIsActive.IsChecked = new bool?(true);
            }
            this.chkPackage.IsChecked = new bool?(true);
            this.chkInvisible.IsChecked = new bool?(false);
            this.chkTaxIncluded.IsChecked = new bool?(false);
            this.chkWaterMarkIncluded.IsChecked = new bool?(false);
            this.cmbSite.SelectedIndex = 0;
            this.chkPackage.IsEnabled = true;
            while (3 == 0)
            {
            }
        }

        private void GetProductTypeList()
        {
            while (true)
            {
                if (!false)
                {
                }
                while (true)
                {
                IL_04:
                    ProductBusiness expr_2C = new ProductBusiness();
                    ProductBusiness productBusiness;
                    if (5 != 0)
                    {
                        productBusiness = expr_2C;
                    }
                    while (!false)
                    {
                        this.grdProductType.ItemsSource = productBusiness.GetProductTypeList(new bool?(false));
                        if (false)
                        {
                            goto IL_04;
                        }
                        if (!false)
                        {
                            return;
                        }
                    }
                    break;
                }
            }
        }

        private ProductTypeInfo GetProductTypebyProductId()
        {
            if (!true)
            {
                goto IL_0B;
            }
        IL_04:
            if (3 == 0)
            {
                goto IL_1D;
            }
            ProductBusiness productBusiness = new ProductBusiness();
        IL_0B:
            if (false)
            {
                goto IL_04;
            }
            ProductTypeInfo productTypeListById = productBusiness.GetProductTypeListById(this._productId);
        IL_1D:
            if (8 != 0)
            {
                return productTypeListById;
            }
            goto IL_04;
        }

        private void GetProductsFromExcel(string filepath)
        {
            FileStream expr_2A2 = File.Open(filepath, FileMode.Open, FileAccess.Read);
            FileStream fileStream;
            if (!false)
            {
                fileStream = expr_2A2;
            }
            IExcelDataReader excelDataReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
            excelDataReader.IsFirstRowAsColumnNames = true;
            DataSet dataSet = excelDataReader.AsDataSet();
            int num = 0;
            foreach (DataTable dataTable in dataSet.Tables)
            {
                int i = 0;
                while (i <= dataTable.Rows.Count)
                {
                    try
                    {
                        ProductBusiness productBusiness = new ProductBusiness();
                        ProductBusiness arg_1FA_0 = productBusiness;
                        int arg_1FA_1 = this._productId;
                        string arg_1FA_2 = dataTable.Rows[i][1].ToString();
                        string arg_1FA_3 = dataTable.Rows[i][2].ToString();
                        string text = dataTable.Rows[i][3].ToString();
                        bool? arg_1FA_4 = new bool?(dataTable.Rows[i][7].ToBoolean(false));
                        string arg_1FA_5 = text;
                        int arg_1FA_6 = LoginUser.StoreId;
                        int arg_1FA_7 = LoginUser.UserId;
                        bool? arg_1FA_8 = new bool?(dataTable.Rows[i][6].ToBoolean(false));
                        bool? arg_1FA_9 = new bool?(dataTable.Rows[i][5].ToBoolean(false));
                        bool? arg_1FA_10 = new bool?(dataTable.Rows[i][4].ToBoolean(false));
                        string productcode = dataTable.Rows[i][8].ToString();
                        string syncCode = this._syncCode;
                        string syncodeforPackage = this._syncodeforPackage;
                        int? isInvisible = new int?(Convert.ToInt32(dataTable.Rows[i][10]));
                        int ProductTypePkey = String.IsNullOrEmpty(this.hdnProductTypePkey.Text) ? 0 : Convert.ToInt32(this.hdnProductTypePkey.Text);
                        if (arg_1FA_0.SetProductTypeInfo(arg_1FA_1, arg_1FA_2, arg_1FA_3, arg_1FA_4, arg_1FA_5, arg_1FA_6, arg_1FA_7, arg_1FA_8 == true, arg_1FA_9, arg_1FA_10, new bool?(dataTable.Rows[i][11].ToBoolean(false)), productcode, syncCode, syncodeforPackage, isInvisible, new bool?(dataTable.Rows[i][12].ToBoolean(false)), Convert.ToInt32(dataTable.Rows[i][9]), ProductTypePkey))
                        {
                            num++;
                        }
                    }
                    catch (Exception var_7_211)
                    {
                    }
                IL_218:
                    i++;
                    continue;
                    goto IL_218;
                }
            }
            if (num > 0)
            {
                System.Windows.MessageBox.Show("Products imported from excel successfully!");
                this.GetProductTypeList();
                this.GetPackageDetails();
            }
            excelDataReader.Close();
        }

        private void GetProductTypeListforPackage(int packageId)
        {
            ProductBusiness productBusiness = new ProductBusiness();
            this.lstProductTypeList = new List<ProductTypeList>();
            if (packageId == 0)
            {
                foreach (ProductTypeInfo current in productBusiness.GetProductTypeList(new bool?(false)))
                {
                    ProductTypeList productTypeList = new ProductTypeList();
                    productTypeList.IsPackage = false;
                    productTypeList.ProductTypeId = current.DG_Orders_ProductType_pkey;
                    productTypeList.ProductTypeName = current.DG_Orders_ProductType_Name;
                    productTypeList.MaxQuantity = new int?(current.DG_MaxQuantity.ToInt32(false));
                    productTypeList.Quantity = new int?(0);
                    if (productTypeList.ProductTypeId == 95)
                    {
                        productTypeList.visibleVideoLength = Visibility.Visible;
                        productTypeList.Isactive = new bool?(false);
                    }
                    else
                    {
                        productTypeList.visibleVideoLength = Visibility.Collapsed;
                    }
                    this.lstProductTypeList.Add(productTypeList);
                }
            }
            else
            {
                List<PackageDetailsViewInfo> packagDetails = productBusiness.GetPackagDetails(packageId);
                bool flag = packagDetails.Count <= 0;
                while (!flag)
                {
                    if (!false)
                    {
                        foreach (PackageDetailsViewInfo current2 in packagDetails)
                        {
                            ProductTypeList productTypeList = new ProductTypeList();
                            productTypeList.ProductTypeId = current2.DG_Orders_ProductType_pkey;
                            productTypeList.ProductTypeName = current2.DG_Orders_ProductType_Name;
                            productTypeList.Quantity = new int?(current2.DG_Product_Quantity);
                            if (current2.DG_Orders_ProductType_IsBundled)
                            {
                                productTypeList.Isactive = new bool?(false);
                            }
                            if (current2.DG_IsAccessory)
                            {
                                productTypeList.Isactive = new bool?(false);
                            }
                            if (productTypeList.ProductTypeId == 95)
                            {
                                productTypeList.visibleVideoLength = Visibility.Visible;
                                productTypeList.Isactive = new bool?(false);
                            }
                            else
                            {
                                productTypeList.visibleVideoLength = Visibility.Collapsed;
                            }
                            productTypeList.MaxQuantity = new int?(current2.DG_Product_MaxImage);
                            productTypeList.VideoLength = current2.DG_Video_Length;
                            this.lstProductTypeList.Add(productTypeList);
                        }
                        goto IL_380;
                    }
                }
                foreach (ProductTypeInfo current in productBusiness.GetProductTypeList(new bool?(false)))
                {
                    ProductTypeList productTypeList = new ProductTypeList();
                    productTypeList.IsPackage = false;
                    productTypeList.ProductTypeId = current.DG_Orders_ProductType_pkey;
                    productTypeList.ProductTypeName = current.DG_Orders_ProductType_Name;
                    productTypeList.MaxQuantity = new int?(0);
                    productTypeList.Quantity = new int?(0);
                    if (current.DG_Orders_ProductType_IsBundled == true)
                    {
                        productTypeList.Isactive = new bool?(false);
                    }
                    if (current.DG_IsAccessory == true)
                    {
                        productTypeList.Isactive = new bool?(false);
                    }
                    if (productTypeList.ProductTypeId == 95)
                    {
                        productTypeList.visibleVideoLength = Visibility.Visible;
                        productTypeList.Isactive = new bool?(false);
                    }
                    else
                    {
                        productTypeList.visibleVideoLength = Visibility.Collapsed;
                    }
                    this.lstProductTypeList.Add(productTypeList);
                }
            }
        IL_380:
            this.dgProducttype.ItemsSource = this.lstProductTypeList;
        }

        private void GetPackageDetails()
        {
            if (!true)
            {
                goto IL_0B;
            }
        IL_04:
            if (3 == 0)
            {
                return;
            }
            ProductBusiness productBusiness = new ProductBusiness();
        IL_0B:
            if (false)
            {
                goto IL_04;
            }
            this.grdPackageType.ItemsSource = productBusiness.GetPackageNames(true);
            if (8 == 0)
            {
                goto IL_04;
            }
        }

        private void PackageClearControl()
        {
            do
            {
                this.packageId = 0;
                this.txtPackageName.Text = "";
            }
            while (false);
            do
            {
                this.dgProducttype.ItemsSource = null;
            }
            while (8 == 0);
        }

        private void FillSubstore()
        {
            do
            {
                try
                {
                    List<SubStoresInfo> logicalSubStore = new StoreSubStoreDataBusniess().GetLogicalSubStore();
                    CommonUtility.BindComboWithSelect<SubStoresInfo>(this.cmbSite, logicalSubStore, "DG_SubStore_Name", "DG_SubStore_pkey", 0, "--Select--");
                    SubStoresInfo substoreData;
                    if (true)
                    {
                        if (7 == 0)
                        {
                            goto IL_AF;
                        }
                        substoreData = new StoreSubStoreDataBusniess().GetSubstoreData(LoginUser.SubStoreId);
                    }
                    bool flag = substoreData == null;
                    while (!flag)
                    {
                        if (!false)
                        {
                            if (!false)
                            {
                                this.cmbSite.SelectedValue = ((substoreData.LogicalSubStoreID == 0) ? LoginUser.SubStoreId.ToString() : substoreData.LogicalSubStoreID.ToString());
                                if (false)
                                {
                                    continue;
                                }
                            }
                            goto IL_C9;
                        }
                        goto IL_CA;
                    }
                IL_AF:
                    this.cmbSite.SelectedValue = LoginUser.SubStoreId.ToString();
                IL_C9:
                IL_CA:;
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
            while (5 == 0);
        }

        private void btnBackToHome_Click(object sender, RoutedEventArgs e)
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
                IL_19:;
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

        private void btnPackageClose_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    this.GrdPackage.Visibility = Visibility.Collapsed;
                    if (!false)
                    {
                        this.PackageClearControl();
                    }
                    this.GetPackageDetails();
                    this.IsBeingEdited = false;
                    this.btnSave.IsDefault = true;
                    this.btnpackageSave.IsDefault = false;
                }
                catch (Exception serviceException)
                {
                    if (!false)
                    {
                    }
                    if (!false)
                    {
                        if (!false)
                        {
                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                            if (-1 != 0)
                            {
                                ErrorHandler.ErrorHandler.LogFileWrite(message);
                            }
                        }
                    }
                }
            }
            while (7 == 0);
        }

        private void btnPackageEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new System.Windows.Controls.Button();
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                if (4 != 0)
                {
                    this.packageId = button.CommandParameter.ToInt32(false);
                    this.GrdPackage.Visibility = Visibility.Visible;
                    do
                    {
                        this.GetProductTypeListforPackage(button.CommandParameter.ToInt32(false));
                        if (5 != 0)
                        {
                            ProductBusiness productBusiness = new ProductBusiness();
                            double dG_Product_Pricing_ProductPrice = productBusiness.GetProductTypeListById(button.CommandParameter.ToInt32(false)).DG_Product_Pricing_ProductPrice;
                            this.txtProductPricePackage.Text = dG_Product_Pricing_ProductPrice.ToString();
                        }
                        if (8 == 0)
                        {
                            goto IL_E2;
                        }
                    }
                    while (5 == 0);
                    this.txtPackageName.Text = button.Tag.ToString();
                    if (!false)
                    {
                        this.IsBeingEdited = true;
                        this.btnSave.IsDefault = false;
                        this.btnBackToHome.IsDefault = false;
                    }
                    this.btnpackageSave.IsDefault = true;
                }
            IL_E2:;
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

        private void btnPackageDelete_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (8 != 0)
                    {
                    }
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        if (!false)
                        {
                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                    }
                    while (false);
                }
            }
            while (false);
        }

        private void btnpackageSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int? quantity;
                ProductTypeList productTypeList2;
                ProductTypeList productTypeList3;
                while (true)
                {
                    bool expr_02 = true;
                    bool flag;
                    if (!false)
                    {
                        flag = expr_02;
                    }
                    int expr_371;
                    int expr_377;
                    while (true)
                    {
                        using (List<ProductTypeList>.Enumerator enumerator = this.lstProductTypeList.GetEnumerator())
                        {
                            ProductTypeList productTypeList;
                            while (true)
                            {
                            IL_F9:
                                bool flag2 = enumerator.MoveNext();
                                while (flag2)
                                {
                                    ProductTypeList expr_10B = enumerator.Current;
                                    if (!false)
                                    {
                                        productTypeList = expr_10B;
                                    }
                                    int arg_C5_0;
                                    bool arg_D6_0;
                                    if (productTypeList.ProductTypeId != 35)
                                    {
                                        int expr_46 = arg_C5_0 = productTypeList.ProductTypeId;
                                        if (8 == 0)
                                        {
                                            goto IL_C4;
                                        }
                                        if (expr_46 != 36 && productTypeList.ProductTypeId != 80)
                                        {
                                            if (false)
                                            {
                                                goto IL_AB;
                                            }
                                            if (productTypeList.ProductTypeId != 81 && productTypeList.ProductTypeId != 82 && productTypeList.ProductTypeId != 83 && productTypeList.ProductTypeId != 78)
                                            {
                                                arg_D6_0 = true;
                                                goto IL_D5;
                                            }
                                        }
                                    }
                                    quantity = productTypeList.Quantity;
                                    if (false)
                                    {
                                        continue;
                                    }
                                    if (quantity != 0)
                                    {
                                        goto IL_AB;
                                    }
                                    arg_D6_0 = true;
                                IL_D5:
                                    if (!arg_D6_0)
                                    {
                                        goto Block_29;
                                    }
                                    goto IL_F9;
                                IL_D1:
                                    goto IL_D5;
                                IL_CA:
                                    int arg_CC_0;
                                    arg_D6_0 = (arg_CC_0 == 0);
                                    goto IL_D1;
                                IL_C4:
                                    arg_CC_0 = ((arg_C5_0 == 0) ? 1 : 0);
                                    goto IL_CA;
                                IL_AB:
                                    quantity = productTypeList.Quantity;
                                    if (quantity.GetValueOrDefault() == 1)
                                    {
                                        arg_C5_0 = (quantity.HasValue ? 1 : 0);
                                        goto IL_C4;
                                    }
                                    arg_CC_0 = 1;
                                    goto IL_CA;
                                }
                                goto Block_30;
                            }
                        Block_29:
                            System.Windows.MessageBox.Show("Quantity should be 0 or 1 for product : " + productTypeList.ProductTypeName);
                            return;
                        Block_30:;
                        }
                        productTypeList2 = (from c in this.lstProductTypeList
                                            where c.ProductTypeId == 104
                                            select c).FirstOrDefault<ProductTypeList>();
                        productTypeList3 = (from c in this.lstProductTypeList
                                            where c.ProductTypeId == 84
                                            select c).FirstOrDefault<ProductTypeList>();
                        bool arg_1BF_0 = productTypeList2.Quantity > 0;
                        int arg_1BF_1 = 0;
                        while (true)
                        {
                            if ((arg_1BF_0 ? 1 : 0) == arg_1BF_1)
                            {
                                goto IL_1FF;
                            }
                            if (false)
                            {
                                break;
                            }
                            if (5 != 0)
                            {
                                if (productTypeList3.Quantity < 1)
                                {
                                    flag = false;
                                }
                                goto IL_1FF;
                            }
                        IL_370:
                            expr_371 = ((arg_1BF_0 = this.IsBeingEdited) ? 1 : 0);
                            expr_377 = (arg_1BF_1 = 0);
                            if (expr_377 == 0)
                            {
                                goto Block_13;
                            }
                            continue;
                        IL_1FF:
                            if (!flag)
                            {
                                goto Block_10;
                            }
                            PackageBusniess packageBusniess = new PackageBusniess();
                            bool flag3 = packageBusniess.SetPackageMasterDetails(this.packageId, this.txtPackageName.Text, this.txtProductPricePackage.Text);
                            if (flag3)
                            {
                                using (List<ProductTypeList>.Enumerator enumerator = this.lstProductTypeList.GetEnumerator())
                                {
                                    if (!false)
                                    {
                                    }
                                    while (enumerator.MoveNext())
                                    {
                                        ProductTypeList productTypeList = enumerator.Current;
                                        if (productTypeList.ProductTypeId == 4 || productTypeList.ProductTypeId == 101)
                                        {
                                            productTypeList.MaxQuantity = new int?((productTypeList.Quantity > 0) ? 4 : 1);
                                        }
                                        packageBusniess.SetPackageDetails(this.packageId, productTypeList.ProductTypeId, productTypeList.Quantity, (productTypeList.MaxQuantity == 0) ? new int?(1) : productTypeList.MaxQuantity, productTypeList.VideoLength);
                                    }
                                }
                            }
                            goto IL_370;
                        }
                    }
                Block_13:
                    if (expr_371 != expr_377)
                    {
                        AuditLog.AddUserLog(LoginUser.UserId, 64, "Package (" + this.txtPackageName.Text + ") has been Edited on ");
                    }
                    else
                    {
                        AuditLog.AddUserLog(LoginUser.UserId, 29, "Package (" + this.txtPackageName.Text + ") has been created on ");
                    }
                    quantity = productTypeList2.Quantity;
                    if (quantity.GetValueOrDefault() <= 0)
                    {
                        goto IL_3F6;
                    }
                    if (!false)
                    {
                        goto Block_16;
                    }
                }
            Block_10:
                System.Windows.MessageBox.Show(string.Concat(new string[]
                {
                    "Please Include ",
                    productTypeList3.ProductTypeName,
                    " product with ",
                    productTypeList2.ProductTypeName,
                    " product"
                }));
                return;
            Block_16:
                int arg_3F9_0 = quantity.HasValue ? 1 : 0;
                goto IL_3F7;
            IL_3F6:
                arg_3F9_0 = 0;
            IL_3F7:
                if (arg_3F9_0 != 0)
                {
                    System.Windows.MessageBox.Show(string.Concat(new string[]
                    {
                        "Package[",
                        this.txtPackageName.Text,
                        "] has been saved successfully.Please verify the setting for ",
                        productTypeList2.ProductTypeName,
                        " Product in digiconfig utility."
                    }));
                }
                else
                {
                    System.Windows.MessageBox.Show("Package[" + this.txtPackageName.Text + "] has been saved successfully");
                }
                this.IsBeingEdited = false;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnimportPackageSave_Click(object sender, RoutedEventArgs e)
        {
            this.BackupWorker.DoWork += new DoWorkEventHandler(this.BackupWorker_DoWork);
            this.BackupWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BackupWorker_RunWorkerCompleted);
            System.Windows.Forms.OpenFileDialog openFileDialog = new System.Windows.Forms.OpenFileDialog();
            openFileDialog.Title = "Select file";
            openFileDialog.Filter = "Excel Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls|All Files(*.*)|*.*";
            if (!false)
            {
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;
                bool flag = openFileDialog.ShowDialog() != System.Windows.Forms.DialogResult.OK;
                if (3 != 0)
                {
                    if (!flag)
                    {
                        this._filedatasource = openFileDialog.FileName;
                        string[] source = openFileDialog.FileName.Split(new char[]
                        {
                            '\\'
                        });
                        this.packagefilename = source.Last<string>();
                        this.Import(this._filedatasource);
                        System.Windows.Forms.Application.DoEvents();
                    }
                }
            }
        }

        private void btndownload_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                string text = Path.Combine(Environment.CurrentDirectory, "ICER Price List - Template.xlsx");
                string fileName = Path.GetFileName(text);
                System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
                saveFileDialog.FileName = fileName;
                saveFileDialog.Filter = "Excel Sheet(*.xlsx)|*.xlsx|All Files(*.*)|*.*";
                string fileName2;
                bool expr_75;
                while (true)
                {
                    saveFileDialog.RestoreDirectory = true;
                    if (-1 != 0)
                    {
                    }
                    bool arg_5A_0 = saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel;
                    while (true)
                    {
                        bool flag = arg_5A_0;
                        if (6 == 0)
                        {
                            break;
                        }
                        if (flag)
                        {
                            return;
                        }
                        fileName2 = saveFileDialog.FileName;
                        bool arg_75_0 = arg_5A_0 = File.Exists(text);
                        while (!false)
                        {
                            expr_75 = (arg_5A_0 = (arg_75_0 = !arg_75_0));
                            if (true)
                            {
                                goto Block_3;
                            }
                        }
                    }
                }
            Block_3:
                if (expr_75)
                {
                    return;
                }
                if (8 == 0)
                {
                    return;
                }
                File.Copy(text, fileName2, true);
            }
            while (false);
            System.Windows.MessageBox.Show("File Downloaded Successfully");
        }

        private void Import(string filedatasource)
        {
            if (filedatasource != string.Empty)
            {
                try
                {
                    if (6 != 0)
                    {
                    }
                    //string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filedatasource + ";Extended Properties='Excel 12.0 Xml;'";
                    string connectionString  = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0;", filedatasource);
                    //string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filedatasource + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";
                    OleDbConnection oleDbConnection = new OleDbConnection(connectionString);
                    OleDbCommand oleDbCommand = new OleDbCommand();
                    DataColumn column;
                    while (true)
                    {
                        oleDbCommand.CommandType = CommandType.Text;
                        oleDbCommand.Connection = oleDbConnection;
                        OleDbDataAdapter oleDbDataAdapter;
                        DataTable oleDbSchemaTable;
                        int num;
                        if (4 != 0)
                        {
                            oleDbDataAdapter = new OleDbDataAdapter(oleDbCommand);
                            this._dtExcelRecords = new DataTable("Package");
                            oleDbConnection.Open();
                            oleDbSchemaTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                            num = 0;
                            num = 0;
                            goto IL_D6;
                        }
                        goto IL_98;
                    IL_FF:
                        int arg_FF_0;
                        bool flag = arg_FF_0 != 0;
                        if (2 == 0)
                        {
                            continue;
                        }
                        if (!flag)
                        {
                            break;
                        }
                        string str = oleDbSchemaTable.Rows[num]["Table_Name"].ToString();
                        oleDbCommand.CommandText = "SELECT * FROM [" + str + "]";
                        oleDbDataAdapter.SelectCommand = oleDbCommand;
                        oleDbDataAdapter.Fill(this._dtExcelRecords);
                        oleDbConnection.Close();
                        column = new DataColumn("SyncCode", typeof(string));
                        if (!false)
                        {
                            goto Block_9;
                        }
                        goto IL_CF;
                    IL_98:
                        bool expr_C1 = (arg_FF_0 = ((!oleDbSchemaTable.Rows[num]["Table_Name"].ToString().EndsWith("$")) ? 1 : 0)) != 0;
                        if (false)
                        {
                            goto IL_FF;
                        }
                        if (!expr_C1)
                        {
                            goto IL_EF;
                        }
                        goto IL_CF;
                    IL_D6:
                        int expr_D6 = arg_FF_0 = num;
                        if (false)
                        {
                            goto IL_FF;
                        }
                        if (expr_D6 >= oleDbSchemaTable.Rows.Count)
                        {
                            goto IL_EF;
                        }
                        goto IL_98;
                    IL_CF:
                        num++;
                        goto IL_D6;
                    IL_EF:
                        arg_FF_0 = ((num < oleDbSchemaTable.Rows.Count) ? 1 : 0);
                        goto IL_FF;
                    }
                    throw new Exception("There is no valid Excel Sheet");
                Block_9:
                    this._dtExcelRecords.Columns.Add(column);
                    foreach (DataRow dataRow in this._dtExcelRecords.Rows)
                    {
                        while (3 == 0)
                        {
                        }
                        if (!string.IsNullOrWhiteSpace(Convert.ToString(dataRow[0])))
                        {
                            dataRow["SyncCode"] = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Product).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                        }
                    }
                    this._dt = this._dtExcelRecords.Rows.Cast<DataRow>().Where(delegate (DataRow row)
                    {
                        bool arg_3A_0;
                        while (true)
                        {
                            bool arg_26_0 = row.ItemArray.All(delegate (object field)
                            {
                                if (-1 == 0)
                                {
                                    goto IL_26;
                                }
                                int arg_3E_0;
                                int arg_30_0;
                                if (!(field is DBNull))
                                {
                                    int expr_37 = arg_30_0 = (arg_3E_0 = string.Compare(field as string, string.Empty));
                                    if (false)
                                    {
                                        goto IL_2A;
                                    }
                                    arg_3E_0 = ((expr_37 == 0) ? 1 : 0);
                                }
                                else
                                {
                                    arg_3E_0 = 1;
                                }
                            IL_23:
                            IL_24:
                                bool flag3 = arg_3E_0 != 0;
                            IL_26:
                                arg_3E_0 = (arg_30_0 = (flag3 ? 1 : 0));
                            IL_2A:
                                if (false)
                                {
                                    goto IL_24;
                                }
                                if (true)
                                {
                                    return arg_30_0 != 0;
                                }
                                goto IL_23;
                            });
                            while (true)
                            {
                                bool expr_26 = arg_26_0 = (arg_3A_0 = !arg_26_0);
                                if (!false)
                                {
                                    bool flag2 = expr_26;
                                    if (!false)
                                    {
                                    }
                                    if (false)
                                    {
                                        break;
                                    }
                                    arg_3A_0 = (arg_26_0 = flag2);
                                }
                                if (7 != 0)
                                {
                                    return arg_3A_0;
                                }
                            }
                        }
                        return arg_3A_0;
                    }).CopyToDataTable<DataRow>();
                    this.bs.Show();
                    this.BackupWorker.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void BackupWorker_DoWork(object Sender, DoWorkEventArgs e)
        {
            bool flag = new ProductBusiness().BulkSaveProduct(this._dt, LoginUser.UserId, LoginUser.StoreId);
            if (flag)
            {
                System.Windows.MessageBox.Show("Packages Saved Successfully");
            }
            else
            {
                System.Windows.MessageBox.Show("There is some error while saving Products/Packages");
            }
        }

        private void BackupWorker_RunWorkerCompleted(object Sender, RunWorkerCompletedEventArgs e)
        {
            this.bs.Hide();
        }

        private void btnpackageCancel_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    this.txtPackageName.Text = "";
                    System.Windows.Controls.TextBox expr_13 = this.txtProductPricePackage;
                    string expr_18 = "0";
                    if (!false)
                    {
                        expr_13.Text = expr_18;
                    }
                    this.GetProductTypeListforPackage(0);
                    this.btnSave.IsDefault = true;
                    this.btnpackageSave.IsDefault = false;
                }
                catch (Exception serviceException)
                {
                    if (!false)
                    {
                    }
                    if (!false)
                    {
                        if (!false)
                        {
                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                            if (-1 != 0)
                            {
                                ErrorHandler.ErrorHandler.LogFileWrite(message);
                            }
                        }
                    }
                }
            }
            while (7 == 0);
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

        private void txtProductPrice_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !ManageProduct.IsTextAllowed(e.Text);
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
                    bool expr_4D = arg_27_0 = ManageProduct.IsTextAllowed(text);
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

       /* void IStyleConnector.Connect(int connectionId, object target)
        {
            if (3 != 0)
            {
            }
            while (true)
            {
                switch (connectionId)
                {
                    case 29:
                        goto IL_31;
                    case 30:
                        goto IL_56;
                    default:
                        if (8 != 0)
                        {
                            goto Block_2;
                        }
                        break;
                }
            }
        Block_2:
            if (connectionId != 36)
            {
                return;
            }
             ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnPackageEdit_Click);
            return;
        IL_31:
            if (!false)
            {
                System.Windows.Controls.Primitives.ButtonBase expr_39 = (System.Windows.Controls.Button)target;
                RoutedEventHandler expr_49 = new RoutedEventHandler(this.btnEdit_Click);
                if (!false)
                {
                    expr_39.Click += expr_49;
                }
                return;
            }
            return;
        IL_56:
            if (2 == 0)
            {
                goto IL_31;
            }
            if (3 != 0)
            {
                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDelete_Click);
            }
        }*/
    }
}
