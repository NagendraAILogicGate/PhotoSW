using DigiAuditLogger;
using PhotoSW.Common;
using DigiPhoto.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.Data;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Linq;
using System.Management;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using PhotoSW.Views;
using PhotoSW.DataLayer;

namespace PhotoSW.Manage
{
    public partial class ManagePrinter : Window, IComponentConnector, IStyleConnector
    {
        private Dictionary<string, string> lstProductList;

        private Dictionary<string, string> lstPrinterList;

        private Dictionary<string, string> lstPaperSizeList;

        private bool isPrinterTypeEdited = false;

        private int pTypeId = 0;

        private int ProductEditId = 0;


        public ManagePrinter()
        {
            this.InitializeComponent();
            this.txbStoreName.Text = LoginUser.StoreName;
            this.txbUserName.Text = LoginUser.UserName;
            this.FillProductCombo();
            this.FillPrinters();
            this.LoadPrinterDetails();
            this.FillPaperSizeCombo();
            this.btnSavePrinter.IsDefault = true;
            this.GetPrinterTypeDetails();
        }

        private void LoadPrinterDetails()
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
            PrinterBusniess printerBusniess = new PrinterBusniess();
        IL_0B:
            if (false)
            {
                goto IL_04;
            }
            this.DGManagePrinter.ItemsSource = printerBusniess.GetPrinterDetails(LoginUser.SubStoreId);
            if (8 == 0)
            {
                goto IL_04;
            }
        }

        private void FillProductCombo()
        {
            do
            {
                try
                {
                    ProductBusiness productBusiness = new ProductBusiness();
                    if (5 != 0)
                    {
                        List<ProductTypeInfo> oList = productBusiness.GetProductType().Where(delegate(ProductTypeInfo t)
                        {
                            bool? dG_IsAccessory = t.DG_IsAccessory;
                            int arg_42_0;
                            if (dG_IsAccessory.GetValueOrDefault())
                            {
                                arg_42_0 = 0;
                                goto IL_16;
                            }
                            arg_42_0 = (dG_IsAccessory.HasValue ? 1 : 0);
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
                        }).ToList<ProductTypeInfo>();
                        CommonUtility.BindComboWithSelect<ProductTypeInfo>(this.CmbProductType, oList, "DG_Orders_ProductType_Name", "DG_Orders_ProductType_pkey", 0, ClientConstant.SelectString);
                        this.CmbProductType.SelectedValue = "0";
                        if (!false)
                        {
                            CommonUtility.BindCombo<ProductTypeInfo>(this.CmbProductType1, oList, "DG_Orders_ProductType_Name", "DG_Orders_ProductType_pkey");
                        }
                    }
                    do
                    {
                    IL_9A:
                        this.CmbProductType1.SelectedValue = "0";
                    }
                    while (4 == 0);
                    goto IL_106;
                    //goto IL_9A;
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                    while (-1 == 0)
                    {
                    }
                }
            IL_106: ;
            }
            while (false || false);
        }

        private void FillPrinters()
        {
            this.lstPrinterList = new Dictionary<string, string>();
            this.lstPrinterList.Add("--Select--", "0");
            int num = 1;
            IEnumerator expr_100 = PrinterSettings.InstalledPrinters.GetEnumerator();
            IEnumerator enumerator;
            if (8 != 0)
            {
                enumerator = expr_100;
                //goto IL_42;
            }
            try
            {
                while (true)
                {
                IL_42:
                    while (true)
                    {
                        if (!false)
                        {
                            bool flag = enumerator.MoveNext();
                            while (flag && 6 != 0)
                            {
                                string text = (string)enumerator.Current;
                                if (-1 != 0)
                                {
                                    if (!false)
                                    {
                                        this.lstPrinterList.Add(text.ToString(), num.ToString());
                                        goto IL_73;
                                    }
                                    goto IL_73;
                                }
                            }
                            goto IL_89;
                        }
                    IL_73:
                        if (-1 != 0)
                        {
                            num++;
                        }
                    }
                }
            IL_89: ;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                bool flag = disposable == null;
                if (7 == 0 || !flag)
                {
                    disposable.Dispose();
                }
            }
            this.CmbPrinterType.ItemsSource = this.lstPrinterList;
            this.CmbPrinterType.SelectedValue = "0";
        }

        private void FillPaperSizeCombo()
        {
            this.lstPaperSizeList = new Dictionary<string, string>();
            PrinterSettings printerSettings;
            if (!false)
            {
                this.lstPaperSizeList.Add("--Select--", "0");
                printerSettings = new PrinterSettings();
            }
            printerSettings.PrinterName = ((KeyValuePair<string, string>)this.CmbPrinterType.SelectedItem).Key;
            int num = 1;
            if (-1 != 0)
            {
                //using (IEnumerator enumerator = printerSettings.PaperSizes.GetEnumerator())
                IEnumerator enumerator = printerSettings.PaperSizes.GetEnumerator();
                try
                {
                    while (true)
                    {
                        while (true)
                        {
                            if (!enumerator.MoveNext())
                            {
                                if (2 == 0)
                                {
                                    break;
                                }
                                if (!false)
                                {
                                    if (!false)
                                    {
                                        goto Block_8;
                                    }
                                }
                            }
                            else
                            {
                                PaperSize paperSize = (PaperSize)enumerator.Current;
                                if (false)
                                {
                                    break;
                                }
                                this.lstPaperSizeList.Add(paperSize.ToString(), num.ToString());
                            }
                        IL_9D:
                            num++;
                            break;
                            goto IL_9D;
                        }
                    }
                Block_8: ;
                }
                catch
                {
                }
            }
        }

        private bool CheckPrinterValidations()
        {
            bool result;
            while (true)
            {
                bool arg_B6_0;
                bool arg_26_0;
                bool arg_6C_0 = arg_26_0 = (arg_B6_0 = (this.CmbPrinterType.SelectedValue.ToString() == "0"));
                int arg_23_0;
                if (!false)
                {
                    arg_23_0 = 0;
                    goto IL_23;
                }
                goto IL_28;
            IL_8A:
                if (!false)
                {
                    break;
                }
                continue;
            IL_28:
                bool flag;
                if (!false)
                {
                    flag = arg_B6_0;
                }
                if (!flag)
                {
                    MessageBox.Show(UIConstant.SelectPrinterType);
                    result = false;
                    goto IL_8A;
                }
                arg_6C_0 = (arg_26_0 = (this.CmbProductType.SelectedValue.ToString() == "0"));
                int arg_69_0 = 0;
            IL_69:
                int expr_69 = arg_23_0 = arg_69_0;
                if (expr_69 == 0)
                {
                    flag = ((arg_6C_0 ? 1 : 0) == expr_69);
                    int arg_70_0 = flag ? 1 : 0;
                    while (arg_70_0 == 0)
                    {
                        MessageBox.Show(UIConstant.SelectProductType);
                        int expr_7F = arg_70_0 = 0;
                        if (expr_7F == 0)
                        {
                            result = (expr_7F != 0);
                            goto IL_8A;
                        }
                    }
                    result = true;
                    goto IL_8A;
                }
            IL_23:
                int expr_23 = arg_69_0 = arg_23_0;
                if (expr_23 == 0)
                {
                    arg_B6_0 = ((arg_26_0 ? 1 : 0) == expr_23);
                    goto IL_28;
                }
                goto IL_69;
            }
            return result;
        }

        private void btnSavePrinter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.CheckPrinterValidations())
                {
                    string dG_Orders_ProductType_Name = ((ProductTypeInfo)this.CmbProductType.SelectedItem).DG_Orders_ProductType_Name;
                    string key = ((KeyValuePair<string, string>)this.CmbPrinterType.SelectedItem).Key;
                    ProductBusiness productBusiness = new ProductBusiness();
                    int productID = productBusiness.GetProductID(dG_Orders_ProductType_Name);
                    
                    string papersize = "";
                    bool flag = productID == 0;
                    while (!flag)
                    {
                        if (!false)
                        {
                            PrinterBusniess printerBusniess = new PrinterBusniess();
                            new PrinterBusniess().SetPrinterDetails(ProductEditId ,key, productID, this.IsPrinterActive.IsChecked.Value, dG_Orders_ProductType_Name,  papersize, LoginUser.SubStoreId);
                            MessageBox.Show(UIConstant.RecordSavedSuccessfully);
                            this.CmbProductType.SelectedValue = "0";
                            this.CmbPrinterType.SelectedValue = "0";
                            this.IsPrinterActive.IsChecked = false;

                            CustomBusineses customBusineses = new CustomBusineses();
                        //    AuditLog.AddUserLog(LoginUser.UserId, 51, "Printer Add/Edit at ");
                            this.DGManagePrinter.ItemsSource = printerBusniess.GetPrinterDetails(LoginUser.SubStoreId);
                            ProductEditId = 0;
                            break;
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
                while (3 == 0)
                {
                }
            }
        }

        private void btnDeletePrinter_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
                try
                {
                    bool flag;
                    do
                    {
                        bool expr_1C = MessageBox.Show(UIConstant.DoYouWantToDeleteThisPrinter, "Confirm delete", MessageBoxButton.YesNo) != MessageBoxResult.Yes;
                        if (!false)
                        {
                            flag = expr_1C;
                        }
                        if (flag)
                        {
                            goto IL_B3;
                        }
                    }
                    while (-1 == 0);
                    Button button = (Button)sender;
                    PrinterBusniess printerBusniess = new PrinterBusniess();
                    bool flag2 = printerBusniess.DeletePrinter((int)button.Tag);
                    flag = !flag2;
                    if (3 == 0)
                    {
                        goto IL_97;
                    }
                    if (flag)
                    {
                        goto IL_B2;
                    }
                IL_73:
                    MessageBox.Show(UIConstant.PrinterDeletedSuccessfully);
                    CustomBusineses customBusineses = new CustomBusineses();
                    //AuditLog.AddUserLog(LoginUser.UserId, 17, "Printer deleted at ");
                IL_97:
                    if (!true)
                    {
                        goto IL_73;
                    }
                    this.DGManagePrinter.ItemsSource = printerBusniess.GetPrinterDetails(LoginUser.SubStoreId);
                IL_B2:
                IL_B3: ;
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                    while (false);
                }
            }
            if (!false)
            {
            }
        }

        private void btnEditPrinter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string printerNameFromID;
                
                do
                {
                    this.IsPrinterActive.IsChecked = new bool?(false);
                    Button button = (Button)sender;
                    PrinterBusniess expr_115 = new PrinterBusniess();
                    PrinterBusniess printerBusniess;
                    if (7 != 0)
                    {
                        printerBusniess = expr_115;
                    }
                    ProductEditId = (int)button.Tag;
                    printerNameFromID = printerBusniess.GetPrinterNameFromID((int)button.Tag);
                }
                while (false);
                string[] array = printerNameFromID.Split(new char[]
				{
					'#'
				});
                string key = array[0];
                string a = array[1];
              //  string text = array[3];
                string selectedValue = array[2];
                string selectedValue2;
                try
                {
                    selectedValue2 = this.lstPrinterList[key].ToString();
                   
                }
                catch (Exception serviceException)
                {
                    selectedValue2 = "0";                  
                }
                this.CmbPrinterType.SelectedValue = selectedValue2;
                // this.CmbProductType.SelectedValue = selectedValue;
                this.CmbProductType.SelectedValue = a;
                do
                {
                    bool arg_CA_0 = a == "True";
                    bool expr_CA;
                    do
                    {
                        expr_CA = (arg_CA_0 = !arg_CA_0);
                    }
                    while (6 == 0);
                    if (expr_CA)
                    {
                        goto IL_EC;
                    }
                }
                while (-1 == 0);
                this.IsPrinterActive.IsChecked = new bool?(true);
            IL_EC: ;
            }
            catch (Exception serviceException)
            {
                do
                {
                    do
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                        while (-1 == 0)
                        {
                        }
                    }
                    while (4 == 0);
                }
                while (5 == 0);
            }
        }

        private void btnLogout_Click ( object sender, RoutedEventArgs e )
            {
            try
                {
                
                    Login login = new Login();
                    login.Show();
                    base.Hide();
                    
                }
            catch(Exception serviceException)
                {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }


        private void btnClearPrinter_Click(object sender, RoutedEventArgs e)
        {
            if (-1 == 0)
            {
                goto IL_35;
            }
            Selector expr_06 = this.CmbPrinterType;
            object expr_0B = "0";
            if (4 != 0)
            {
                expr_06.SelectedValue = expr_0B;
            }
        IL_15:
            this.CmbProductType.SelectedValue = "0";
        IL_24:
            ToggleButton expr_27 = this.IsPrinterActive;
            bool? expr_58 = new bool?(true);
            if (!false)
            {
                expr_27.IsChecked = expr_58;
            }
        IL_35:
            this.FillPaperSizeCombo();
            if (5 == 0)
            {
                goto IL_15;
            }
            if (!false)
            {
                return;
            }
            goto IL_24;
        }

        private void btnBackPrinter_Click(object sender, RoutedEventArgs e)
        {
            ManageHome manageHome = new ManageHome();
            manageHome.Show();
            base.Close();
        }

        private void CmbPrinterType_DropDownClosed(object sender, EventArgs e)
        {
            this.FillPaperSizeCombo();
        }

        private void btnRefreshPrinters_Click(object sender, RoutedEventArgs e)
        {
            bool arg_83_0;
            int arg_0F_0;
            bool arg_15_0 = (arg_0F_0 = ((arg_83_0 = this.DeleteAllPrinters()) ? 1 : 0)) != 0;
            while (true)
            {
                int arg_0C_0;
                if (!false)
                {
                    arg_0C_0 = 0;
                    goto IL_0C;
                }
                goto IL_15;
            IL_21:
                int arg_21_0;
                int expr_21 = arg_0C_0 = arg_21_0;
                if (expr_21 != 0)
                {
                    arg_0C_0 = expr_21;
                    //if (expr_21 != 0)
                    //{
                    //    arg_15_0 = ((arg_0F_0 = ((arg_83_0 = AuditLog.AddUserLog(arg_83_0 ? 1 : 0, expr_21, "Printer Remapped on :- ")) ? 1 : 0)) != 0);
                    //    if (!false)
                    //    {
                    //        break;
                    //    }
                    //    continue;
                    //}
                }
            IL_0C:
                int expr_0C = arg_21_0 = arg_0C_0;
                if (expr_0C != 0)
                {
                    goto IL_21;
                }
                bool flag = arg_0F_0 == expr_0C;
                arg_15_0 = flag;
            IL_15:
                if (!arg_15_0)
                {
                    this.AddAvailablePrinters();
                    arg_83_0 = ((arg_0F_0 = LoginUser.UserId) != 0);
                    arg_21_0 = 107;
                    goto IL_21;
                }
                goto IL_45;
            }
            MessageBox.Show("Printer list refreshed successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            return;
        IL_45:
            MessageBox.Show("Printer list could not be cleared!", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
        }

        private void GetPrinterTypeDetails()
        {
            try
            {
                if (!false)
                {
                    PrinterTypeBusiness printerTypeBusiness = new PrinterTypeBusiness();
                    List<PrinterTypeInfo> expr_31 = printerTypeBusiness.GetPrinterTypeList();
                    List<PrinterTypeInfo> itemsSource;
                    if (-1 != 0)
                    {
                        itemsSource = expr_31;
                    }
                    do
                    {
                        this.DGManagePrinterType.ItemsSource = itemsSource;
                    }
                    while (false);
                }
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                    while (-1 == 0)
                    {
                    }
                }
                while (-1 == 0);
            }
            if (!false)
            {
            }
        }

        private void btnEditPrinterType_Click(object sender, RoutedEventArgs e)
        {
            PrinterTypeInfo printerTypeInfo;
            do
            {
                this.isPrinterTypeEdited = true;
                while (true)
                {
                    Button button = (Button)sender;
                    while (true)
                    {
                        this.pTypeId = button.Tag.ToInt32(false);
                        PrinterTypeBusiness printerTypeBusiness = new PrinterTypeBusiness();
                        printerTypeInfo = printerTypeBusiness.GetPrinterTypeList(this.pTypeId).FirstOrDefault<PrinterTypeInfo>();
                        if (false || 2 == 0)
                        {
                            break;
                        }
                        if (!false)
                        {
                            goto Block_2;
                        }
                    }
                }
            Block_2: ;
            }
            while (5 == 0);
            this.txtPrinterType.Text = printerTypeInfo.PrinterType;
            this.CmbProductType1.SelectedValue = printerTypeInfo.ProductTypeID;
            this.IsPrinterActiveType.IsChecked = new bool?(printerTypeInfo.IsActive);
        }

        private void btnDeletePrinterType_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    MessageBoxResult messageBoxResult;
                    if (!false)
                    {
                        Button expr_0A = (Button)sender;
                        Button button;
                        if (!false)
                        {
                            button = expr_0A;
                        }
                        this.pTypeId = button.Tag.ToInt32(false);
                        messageBoxResult = MessageBox.Show("Do you want to delete the record?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    }
                    bool arg_52_0 = messageBoxResult != MessageBoxResult.Yes;
                    bool expr_54;
                    do
                    {
                        bool flag = arg_52_0;
                        expr_54 = (arg_52_0 = flag);
                    }
                    while (false);
                    if (!expr_54)
                    {
                        PrinterTypeBusiness printerTypeBusiness = new PrinterTypeBusiness();
                        PrinterTypeInfo printerTypeInfo = printerTypeBusiness.GetPrinterTypeList(this.pTypeId).FirstOrDefault<PrinterTypeInfo>();
                        if (printerTypeInfo != null)
                        {
                            if (!false)
                            {
                                bool flag2 = printerTypeBusiness.DeletePrinterType(this.pTypeId);
                                if (flag2)
                                {
                                    this.GetPrinterTypeDetails();
                                    MessageBox.Show("Printer type deleted successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                                    goto IL_B6;
                                }
                            }
                            MessageBox.Show(UIConstant.PrinterTypeCouldNotBeDeleted, "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
                        }
                    }
                IL_B6:
                    if (false)
                    {
                        goto IL_B6;
                    }
                }
                catch (Exception serviceException)
                {
                    MessageBox.Show(UIConstant.PrinterTypeCouldNotBeDeleted, "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
                    if (3 != 0)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (8 == 0);
        }

        private void btnClearPrinterType_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!false)
                {
                    this.txtPrinterType.Text = string.Empty;
                    if (false)
                    {
                        break;
                    }
                }
                while (true)
                {
                    this.CmbProductType1.SelectedIndex = 0;
                    if (false)
                    {
                        break;
                    }
                    this.IsPrinterActiveType.IsChecked = new bool?(true);
                    if (-1 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void btnSavePrinterType_Click(object sender, RoutedEventArgs e)
        {
            string text = this.txtPrinterType.Text;
            bool arg_8D_0;
            bool expr_108 = arg_8D_0 = this.CheckPrinterTypeValidations(text);
            if (4 != 0)
            {
                if (expr_108)
                {
                    if (!true)
                    {
                        goto IL_8F;
                    }
                    bool value = this.IsPrinterActiveType.IsChecked.Value;
                    if (-1 == 0)
                    {
                        return;
                    }
                    int productTypeId = (int)this.CmbProductType1.SelectedValue.ToInt16(false);
                    string productType = this.CmbProductType1.Text;
                    bool flag = this.SavePrinterTypeDetails(this.pTypeId, text, productTypeId, productType, value);
                    this.GetPrinterTypeDetails();
                    if (!true)
                    {
                        return;
                    }
                    bool flag2 = !flag;
                    arg_8D_0 = flag2;
                }
                else
                {
                    while (true)
                    {
                        MessageBox.Show(UIConstant.PrinterTypeKeywordCannotBeEmpty, "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
                        if (3 != 0)
                        {
                            return;
                        }
                    }
                }
            }
            if (arg_8D_0 && !false)
            {
                MessageBox.Show(UIConstant.PrinterTypeCouldNotBeSavedDueToSomeError, "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
                return;
            }
        IL_8F:
            MessageBox.Show(UIConstant.PrinterTypeSavedSuccessfull, "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            this.txtPrinterType.Text = string.Empty;
            this.CmbProductType1.SelectedIndex = 0;
            this.IsPrinterActiveType.IsChecked = new bool?(false);
            this.isPrinterTypeEdited = false;
            this.pTypeId = 0;
        }

        private bool SavePrinterTypeDetails(int PrinterTypeId, string PrinterTypeKeyword, int ProductTypeId, string productType, bool isActive)
        {
            bool result;
            if (!false && -1 != 0)
            {
                try
                {
                    PrinterTypeInfo printerTypeInfo;
                    if (6 != 0)
                    {
                        printerTypeInfo = new PrinterTypeInfo();
                        PrinterTypeInfo expr_52 = printerTypeInfo;
                        if (3 != 0)
                        {
                            expr_52.PrinterTypeID = PrinterTypeId;
                        }
                        printerTypeInfo.PrinterType = PrinterTypeKeyword;
                        do
                        {
                            printerTypeInfo.ProductTypeID = ProductTypeId;
                            printerTypeInfo.ProductName = productType;
                            if (6 == 0)
                            {
                                goto IL_3E;
                            }
                        }
                        while (2 == 0);
                        printerTypeInfo.IsActive = isActive;
                    }
                    PrinterTypeBusiness printerTypeBusiness = new PrinterTypeBusiness();
                IL_3E:
                    result = printerTypeBusiness.SavePrinterType(printerTypeInfo);
                }
                catch
                {
                    result = false;
                }
            }
            return result;
        }

        private bool CheckPrinterTypeValidations(string keyword)
        {
            bool arg_28_0;
            bool flag;
            if (!false)
            {
                bool expr_09 = arg_28_0 = !string.IsNullOrEmpty(keyword);
                if (false)
                {
                    return arg_28_0;
                }
                if (expr_09)
                {
                    flag = true;
                    if (!false)
                    {
                        goto IL_23;
                    }
                    goto IL_18;
                }
            }
        IL_15:
            flag = false;
        IL_18:
        IL_23:
            if (-1 == 0)
            {
                goto IL_15;
            }
            arg_28_0 = flag;
            return arg_28_0;
        }

        private void AddAvailablePrinters()
        {
            PrinterTypeBusiness printerTypeBusiness;
            if (true)
            {
                printerTypeBusiness = new PrinterTypeBusiness();
                goto IL_11;
            }
            do
            {
            IL_A4:
                this.LoadPrinterDetails();
                printerTypeBusiness = null;
            }
            while (8 == 0);
            if (4 != 0)
            {
                return;
            }
        IL_11:
            using (Dictionary<string, string>.Enumerator enumerator = this.lstPrinterList.GetEnumerator())
            {
                while (true)
                {
                IL_6E:
                    bool flag = enumerator.MoveNext();
                IL_77:
                    while (flag)
                    {
                        string key;
                        bool active;
                        while (true)
                        {
                        IL_28:
                            KeyValuePair<string, string> current = enumerator.Current;
                            while (4 != 0)
                            {
                                flag = !(current.Value != "0");
                                if (flag)
                                {
                                    goto IL_6D;
                                }
                                key = current.Key;
                                active = this.isPrinterReady(key);
                                if (!false)
                                {
                                    if (!false)
                                    {
                                        goto Block_8;
                                    }
                                    goto IL_28;
                                }
                            }
                            goto IL_77;
                        }
                    IL_6D:
                        goto IL_6E;
                    Block_8:
                        bool flag2 = printerTypeBusiness.SaveOrActivateNewPrinter(key, LoginUser.SubStoreId, active);
                        goto IL_6D;
                    }
                    break;
                }
            }
            //goto IL_A4;
        }

        private bool DeleteAllPrinters()
        {
            int arg_61_0;
            int expr_02 = arg_61_0 = 0;
            if (expr_02 == 0)
            {
                bool flag = expr_02 != 0;
                try
                {
                    while (true)
                    {
                        PrinterTypeBusiness printerTypeBusiness = new PrinterTypeBusiness();
                        while (true)
                        {
                            flag = printerTypeBusiness.DeleteAssociatedPrinters(LoginUser.SubStoreId);
                            if (2 == 0)
                            {
                                break;
                            }
                            if (8 != 0)
                            {
                                goto Block_4;
                            }
                        }
                    }
                Block_4: ;
                }
                catch (Exception serviceException)
                {
                    flag = false;
                    do
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                        while (false)
                        {
                        }
                    }
                    while (4 == 0);
                }
                bool expr_68 = flag;
                bool flag2;
                if (!false)
                {
                    flag2 = expr_68;
                }
                arg_61_0 = (flag2 ? 1 : 0);
            }
            return arg_61_0 != 0;
        }

        private bool isPrinterReady(string PrinterName)
        {
            bool result;
            while (true)
            {
                int arg_1DB_0 = 0;
                while (true)
                {
                    bool flag = arg_1DB_0 != 0;
                    ManagementScope expr_1E1 = new ManagementScope("\\root\\cimv2");
                    ManagementScope managementScope;
                    if (7 != 0)
                    {
                        managementScope = expr_1E1;
                    }
                    managementScope.Connect();
                    ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Printer");
                    ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get();
                    string[] array = new string[7];
                    if (-1 == 0)
                    {
                        break;
                    }
                    array[0] = "Other";
                    array[1] = "Unknown";
                    array[2] = "Idle";
                    array[3] = "Printing";
                    array[4] = "WarmUp";
                    array[5] = "Stopped Printing";
                    array[6] = "Offline";
                    string[] array2 = array;
                    ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectCollection.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            ManagementObject managementObject = (ManagementObject)enumerator.Current;
                            do
                            {
                                string text = managementObject["Name"].ToString().ToLower();
                                if (text.Equals(PrinterName.ToLower()))
                                {
                                    if (!managementObject["WorkOffline"].ToString().ToLower().Equals("true"))
                                    {
                                        int num = managementObject["PrinterStatus"].ToInt32(false);
                                        string str = array2[num];
                                        int arg_150_0 = num;
                                        int arg_150_1 = Convert.ToInt32(PrinterStatus.Other);
                                        bool arg_16B_0;
                                        while (arg_150_0 != arg_150_1)
                                        {
                                            int expr_152 = arg_150_0 = num;
                                            int expr_15A = arg_150_1 = Convert.ToInt32(PrinterStatus.Offline);
                                            if (8 != 0)
                                            {
                                                arg_16B_0 = (expr_152 != expr_15A);
                                            IL_16A:
                                                if (!arg_16B_0)
                                                {
                                                    flag = false;
                                                    string message = text + " is in error (" + str + ") status : ";
                                                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                                                    goto IL_190;
                                                }
                                                flag = true;
                                                goto IL_197;
                                            }
                                        }
                                        arg_16B_0 = false;
                                        //goto IL_16A;
                                    }
                                    ErrorHandler.ErrorHandler.LogFileWrite(text + " is Offline.");
                                    if (!false)
                                    {
                                        flag = false;
                                    }
                                IL_197:
                                IL_190: ;
                                }
                            }
                            while (false);
                        }
                    }
                    finally
                    {
                        if (enumerator == null)
                        {
                            goto IL_1C5;
                        }
                    IL_1BD:
                        ((IDisposable)enumerator).Dispose();
                    IL_1C5:
                        if (false)
                        {
                            goto IL_1BD;
                        }
                    }
                    while (true)
                    {
                        bool expr_1CA = (arg_1DB_0 = (flag ? 1 : 0)) != 0;
                        if (false)
                        {
                            break;
                        }
                        result = expr_1CA;
                        if (!false)
                        {
                            return result;
                        }
                    }
                }
            }
            return result;
        }

        // void IStyleConnector.Connect(int connectionId, object target)
        //{
        //    int arg_31_0;
        //    while (true)
        //    {
        //        int arg_C5_0 = connectionId;
        //        while (true)
        //        {
        //            int num = arg_C5_0;
        //            if (7 == 0)
        //            {
        //                break;
        //            }
        //            int expr_15 = arg_31_0 = (arg_C5_0 = num - 10);
        //            if (8 != 0)
        //            {
        //                switch (expr_15)
        //                {
        //                    case 0:
        //                        goto IL_40;
        //                    case 1:
        //                        goto IL_62;
        //                    default:
        //                        arg_C5_0 = (arg_31_0 = num - 20);
        //                        break;
        //                }
        //            }
        //            if (!false)
        //            {
        //                goto Block_3;
        //            }
        //        }
        //    }
        //Block_3:
        //    switch (arg_31_0)
        //    {
        //        case 0:
        //        IL_87:
        //            ((Button)target).Click += new RoutedEventHandler(this.btnEditPrinterType_Click);
        //            if (6 != 0)
        //            {
        //                return;
        //            }
        //            return;
        //        case 1:
        //            ((Button)target).Click += new RoutedEventHandler(this.btnDeletePrinterType_Click);
        //            return;
        //        default:
        //            return;
        //    }
        //IL_40:
        //    ((Button)target).Click += new RoutedEventHandler(this.btnEditPrinter_Click);
        //    return;
        ////IL_62:
        ////    if (7 == 0)
        ////    {
        ////        //goto IL_87;
        ////    }
        ////    ((Button)target).Click += new RoutedEventHandler(this.btnDeletePrinter_Click);
        //}
    }
}
