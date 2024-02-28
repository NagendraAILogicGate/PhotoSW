using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.Data;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using PhotoSW.Manage;

namespace PhotoSW.PSControls
{
    public partial class EditAddCard : UserControl, IComponentConnector
    {
        private bool _hideRequest = false;

        private string _result;

        private UIElement _parent;

       

        public int cardId
        {
            get;
            set;
        }

        public new string Name
        {
            get;
            set;
        }

        public string CardIdentificationDigit
        {
            get;
            set;
        }

        public int ImageIdentificationType
        {
            get;
            set;
        }

        public int MaxImage
        {
            get;
            set;
        }

        public string CardDesc
        {
            get;
            set;
        }

        public bool IsActive
        {
            get;
            set;
        }

        public EditAddCard()
        {
            this.InitializeComponent();
            this.LoadComboValues();
            this.BindPackageTypes();
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string empty = string.Empty;
                bool flag = !this.Isvalidate(out empty);
                bool arg_25_0 = flag;
            IL_25:
                while (!arg_25_0)
                {
                    bool arg_54_0 = this.chkIsPrePaid.IsChecked == false;
                    CardBusiness cardBusiness;
                    int strcodeType;
                    bool expr_28B;
                    while (true)
                    {
                        flag = !arg_54_0;
                        bool arg_60_0;
                        int arg_28B_0 = (arg_60_0 = flag) ? 1 : 0;
                        do
                        {
                            if (!false)
                            {
                                if (!arg_60_0)
                                {
                                    this.cmbPackage.SelectedIndex = 0;
                                }
                                cardBusiness = new CardBusiness();
                                if (this.cardId <= 0)
                                {
                                    goto Block_6;
                                }
                                strcodeType = this.cmbCardFormatType.SelectedValue.ToInt32(false);
                                arg_28B_0 = ((arg_60_0 = cardBusiness.SetCardTypeInfo(this.cardId, this.txtName.Text, this.txtCardIdentificationDigit.Text, strcodeType, this.chkIsActive.IsChecked, this.txtMaxImage.Text.ToInt32(false), this.txtCardDesc.Text, this.chkIsPrePaid.IsChecked.ToBoolean(false), this.cmbPackage.SelectedValue.ToInt32(false), this.chkIsWaterMark.IsChecked.ToBoolean(false))) ? 1 : 0);
                            }
                        }
                        while (7 == 0);
                        expr_28B = (arg_54_0 = (arg_28B_0 == 0));
                        if (2 != 0)
                        {
                            goto Block_14;
                        }
                    }
                IL_9C:
                    flag = !cardBusiness.IsCardSeriesExits(this.txtCardIdentificationDigit.Text);
                    do
                    {
                        bool expr_B2 = arg_25_0 = flag;
                        if (false)
                        {
                            goto IL_25;
                        }
                        if (expr_B2)
                        {
                            goto IL_1BA;
                        }
                        flag = !cardBusiness.SetCardTypeInfo(this.cardId, this.txtName.Text, this.txtCardIdentificationDigit.Text, strcodeType, this.chkIsActive.IsChecked, this.txtMaxImage.Text.ToInt32(false), this.txtCardDesc.Text, this.chkIsPrePaid.IsChecked.ToBoolean(false), this.cmbPackage.SelectedValue.ToInt32(false), this.chkIsWaterMark.IsChecked.ToBoolean(false));
                    }
                    while (false);
                    if (!flag)
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show("[" + this.txtName.Text + "] Card details has been created successfully", "Digiphoto", MessageBoxButton.OK);
                        if (-1 != 0)
                        {
                            if (messageBoxResult == MessageBoxResult.OK)
                            {
                                ((CardType)this._parent).GetCardTypeList();
                                this.ClearControls();
                                this.HideHandlerDialog();
                                this.cardId = 0;
                            }
                        }
                    }
                    goto IL_1DC;
                IL_1BA:
                    MessageBox.Show("[" + this.txtCardIdentificationDigit.Text + "] Card Series already exits , duplicate Card Series not allowed.");
                IL_1DC:
                    this.cardId = 0;
                    goto IL_2FE;
                Block_6:
                    strcodeType = this.cmbCardFormatType.SelectedValue.ToInt32(false);
                    goto IL_9C;
                Block_14:
                    if (!expr_28B)
                    {
                        MessageBoxResult messageBoxResult = MessageBox.Show("[" + this.txtName.Text + "] Card details has been updated successfully", "Digiphoto", MessageBoxButton.OK);
                        if (messageBoxResult == MessageBoxResult.OK)
                        {
                            ((CardType)this._parent).GetCardTypeList();
                            this.ClearControls();
                            this.HideHandlerDialog();
                            if (false)
                            {
                                goto IL_9C;
                            }
                            this.cardId = 0;
                        }
                    }
                IL_2FE:
                    this.cardId = 0;
                    return;
                }
                if (!string.IsNullOrEmpty(empty))
                {
                    MessageBox.Show(empty);
                }
                else
                {
                    MessageBox.Show("Please enter all required values");
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandler.LogError(ex);
                bool flag = !ex.ToString().ToUpper().Contains("UQ_CARDIDENTIFICATIONDIGIT");
                bool arg_3A0_0 = flag;
                while (!arg_3A0_0)
                {
                    bool expr_3B3 = arg_3A0_0 = !string.IsNullOrEmpty(this.txtCardIdentificationDigit.Text);
                    if (!false)
                    {
                        if (!expr_3B3)
                        {
                            MessageBox.Show("Card having WaterMark has already exist");
                            break;
                        }
                        MessageBox.Show("Card Series Starting 4 Digits has already exist");
                        break;
                    }
                }
            }
        }
        //private string error = "";
        private bool Isvalidate(out string error)
        {
            error = string.Empty;
            bool flag = true;
            if (!string.IsNullOrEmpty(this.txtName.Text))
            {
                goto IL_4D;
            }
        IL_36:
            flag = false;
            this.txtName.Focus();
        IL_4D:
            int arg_6E_0 = (this.chkIsWaterMark.IsChecked == false) ? 1 : 0;
            while (arg_6E_0 != 0)
            {
                int arg_BE_0;
                bool result;
                if (!string.IsNullOrEmpty(this.txtCardIdentificationDigit.Text))
                {
                    int expr_92 = arg_6E_0 = this.txtCardIdentificationDigit.Text.Length;
                    if (false)
                    {
                        continue;
                    }
                    if (expr_92 > 1)
                    {
                    IL_9D:
                        int arg_1A6_0 = arg_BE_0 = ((this.txtCardIdentificationDigit.Text.Length <= 16) ? 1 : 0);
                        if (-1 != 0)
                        {
                            goto IL_BD;
                        }
                    IL_1A5:
                        if (arg_1A6_0 != 0)
                        {
                            error = "Check IsPrepaid option.";
                            result = false;
                            return result;
                        }
                    IL_1B9:
                        if (5 != 0)
                        {
                            result = flag;
                            if (!false)
                            {
                                return result;
                            }
                            goto IL_36;
                        }
                        else
                        {
                        IL_105:
                        IL_15D:
                            if (this.chkIsWaterMark.IsChecked == true)
                            {
                                arg_1A6_0 = ((this.chkIsPrePaid.IsChecked == false) ? 1 : 0);
                                goto IL_1A5;
                            }
                            goto IL_1B9;
                        }
                    }
                }
                arg_BE_0 = 0;
            IL_BD:
                if (arg_BE_0 != 0)
                {
                    break;
                }
                this.txtCardIdentificationDigit.Focus();
                error = "Card Series length should be between 2 to 16 characters ";
                result = false;
                return result;
            }
            if (string.IsNullOrEmpty(this.txtMaxImage.Text))
            {
                flag = false;
                this.txtMaxImage.Focus();
                //goto IL_105;
            }
            bool? isChecked = this.chkIsPrePaid.IsChecked;
            bool arg_12D_0;
            if (isChecked.GetValueOrDefault())
            {
                arg_12D_0 = isChecked.HasValue;
            }
            else
            {
                if (-1 == 0)
                {
                    //goto IL_9D;
                }
                arg_12D_0 = false;
            }
            if (arg_12D_0 && this.cmbPackage.SelectedIndex <= 0)
            {
                this.cmbPackage.Focus();
                error = "Select package name.";
                bool result = false;
                return result;
            }
            //goto IL_15D;
            return false;
        }

        private void ClearControls()
        {
            if (7 == 0)
            {
                goto IL_AE;
            }
            this.txtName.Text = string.Empty;
            if (false)
            {
                goto IL_60;
            }
            this.txtCardDesc.Text = string.Empty;
        IL_33:
            if (!false)
            {
                this.txtCardIdentificationDigit.Text = string.Empty;
            }
        IL_4C:
            this.txtMaxImage.Text = string.Empty;
        IL_60:
            if (3 != 0)
            {
                this.chkIsActive.IsChecked = new bool?(false);
                if (-1 == 0)
                {
                    goto IL_4C;
                }
            }
            this.cmbCardFormatType.SelectedIndex = 0;
            this.chkIsPrePaid.IsChecked = new bool?(false);
            this.chkIsWaterMark.IsChecked = new bool?(false);
        IL_AE:
            this.txtCardIdentificationDigit.IsEnabled = true;
            if (6 != 0)
            {
                this.cmbPackage.SelectedIndex = 0;
                return;
            }
            goto IL_33;
        }

        private void LoadComboValues()
        {
            if (false)
            {
                goto IL_48;
            }
            if (false)
            {
                goto IL_59;
            }
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            if (2 == 0)
            {
                goto IL_36;
            }
            dictionary.Add("--Select--", 0);
            dictionary.Add("QRCode", 401);
        IL_28:
            dictionary.Add("Barcode", 402);
        IL_36:
            dictionary.Add("QRCode+Barcode", 405);
        IL_48:
            do
            {
                this.cmbCardFormatType.ItemsSource = dictionary;
            }
            while (false);
        IL_59:
            if (5 != 0)
            {
                return;
            }
            goto IL_28;
        }

        private void BindPackageTypes()
        {
            try
            {
                List<ProductTypeInfo> oList = new ProductBusiness().GetPackageType().Where(delegate(ProductTypeInfo o)
                {
                    bool? dG_IsActive = o.DG_IsActive;
                    int arg_42_0;
                    if (!dG_IsActive.GetValueOrDefault())
                    {
                        arg_42_0 = 0;
                        goto IL_16;
                    }
                    arg_42_0 = (dG_IsActive.HasValue ? 1 : 0);
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
                CommonUtility.BindComboWithSelect<ProductTypeInfo>(this.cmbPackage, oList, "DG_Orders_ProductType_Name", "DG_Orders_ProductType_pkey", 0, ClientConstant.SelectString);
                this.cmbPackage.SelectedValue = "0";
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
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

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.ClearControls();
            this.HideHandlerDialog();
        }

        private void HideHandlerDialog()
        {
            do
            {
                try
                {
                    while (true)
                    {
                        this._hideRequest = true;
                        if (!false)
                        {
                            base.Visibility = Visibility.Collapsed;
                            if (6 != 0)
                            {
                            }
                            this._parent.IsEnabled = true;
                            if (6 != 0)
                            {
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    if (!false)
                    {
                    }
                }
            }
            while (-1 == 0);
        }

        private void chkIsPrePaid_Checked(object sender, RoutedEventArgs e)
        {
            this.stkPackage.Visibility = Visibility.Visible;
        }

        private void chkIsPrePaid_Unchecked(object sender, RoutedEventArgs e)
        {
            this.stkPackage.Visibility = Visibility.Collapsed;
        }

        private void chkIsWaterMark_Checked(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_11;
            }
        IL_04:
            if (6 == 0)
            {
                goto IL_24;
            }
            this.txtCardIdentificationDigit.IsEnabled = false;
        IL_11:
            if (!false)
            {
                this.txtCardIdentificationDigit.Text = string.Empty;
            }
        IL_24:
            if (!false)
            {
                return;
            }
            goto IL_04;
        }

        private void chkIsWaterMark_Unchecked(object sender, RoutedEventArgs e)
        {
            this.txtCardIdentificationDigit.IsEnabled = true;
        }


    }
}
