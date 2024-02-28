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
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using PhotoSW.Views;
using PhotoSW.DataLayer;

namespace PhotoSW.Manage
{
    public partial class ManageSubstores : Window, IComponentConnector, IStyleConnector
    {
        public int _subStoreId = 0;

        public List<SubStoresInfo> lstStoreSubStore;

        public ManageSubstores()
        {
            try
            {
                this.InitializeComponent();
                this.FillSubstore();
                this.ddlLogicalSiteName.SelectedIndex = 0;
                this.GetSubstoreData();
                this.GetSiteCode();
                this.txbUserName.Text = LoginUser.UserName;
                this.txbStoreName.Text = LoginUser.StoreName;
                this.btnSave.IsDefault = true;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }



        public bool IsValidate()
        {
            bool result;
            while (true)
            {
                if (8 != 0)
                {
                    result = true;
                    bool arg_57_0 = !string.IsNullOrEmpty(this.txtSubStoreName.Text.Trim());
                    bool expr_5A;
                    do
                    {
                        bool flag = arg_57_0;
                        expr_5A = (arg_57_0 = flag);
                    }
                    while (false || !true);
                    if (expr_5A)
                    {
                        goto IL_33;
                    }
                }
            IL_24:
                MessageBox.Show("Please enter Substore name");
                result = false;
                if (!false)
                {
                    goto IL_33;
                }
                continue;
            IL_23:
                goto IL_24;
            IL_33:
                if (!false)
                {
                    break;
                }
                goto IL_23;
            }
            return result;
        }

        private void FillSubstore()
        {
            do
            {
                if (!false && !false && 7 != 0)
                {
                    try
                    {
                        while (false)
                        {
                        }
                        this.lstStoreSubStore = new StoreSubStoreDataBusniess().GetAllLogicalSubstoreName();
                        new List<SubStoresInfo>();
                        List<SubStoresInfo> oList = (from t in this.lstStoreSubStore
                                                     where t.IsLogicalSubStore
                                                     select t).ToList<SubStoresInfo>();
                        CommonUtility.BindComboWithSelect<SubStoresInfo>(this.ddlLogicalSiteName, oList, "DG_SubStore_Name", "DG_SubStore_pkey", 0, ClientConstant.SelectString);
                        this.ddlLogicalSiteName.SelectedValue = LoginUser.SubStoreId.ToString();
                    }
                    catch (Exception serviceException)
                    {
                        while (false)
                        {
                        }
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (4 == 0);
        }

        public void GetSubstoreData()
        {
            this.DGManageSubStore.ItemsSource = this.lstStoreSubStore;
        }

        public void GetSiteCode()
        {
            do
            {
                if (3 != 0)
                {
                }
                new List<SiteCodeDetail>();
                List<SiteCodeDetail> siteCodeBusiness = new StoreSubStoreDataBusniess().GetSiteCodeBusiness();
                if (2 != 0)
                {
                    CommonUtility.BindComboWithSelect<SiteCodeDetail>(this.cmbSiteCode, siteCodeBusiness, "SiteCode", "SiteId", 0, ClientConstant.SelectString);
                    do
                    {
                        this.cmbSiteCode.ItemsSource = siteCodeBusiness;
                    }
                    while (2 == 0);
                    if (3 == 0)
                    {
                        goto IL_7D;
                    }
                }
                this.cmbSiteCode.SelectedIndex = 0;
            }
            while (2 == 0);
            this.cmbSiteCode.DisplayMemberPath = "SiteCode";
        IL_7D:
            this.cmbSiteCode.SelectedValuePath = "SiteId";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                try
                {
                    bool arg_27_0 = this.cmbSiteCode.SelectedIndex > 0;
                    int arg_27_1 = 0;
                    while ((arg_27_0 ? 1 : 0) != arg_27_1)
                    {
                        List<SubStoresInfo> source = this.lstStoreSubStore.Where(delegate (SubStoresInfo t)
                        {
                            int arg_40_0;
                            int expr_B6 = arg_40_0 = t.SiteID;
                            if (!false)
                            {
                                if (expr_B6 != Convert.ToInt32(this.cmbSiteCode.SelectedValue))
                                {
                                    goto IL_A9;
                                }
                                if (-1 == 0)
                                {
                                    goto IL_AC;
                                }
                                arg_40_0 = t.DG_SubStore_pkey;
                            }
                            int arg_AF_0;
                            int arg_AB_0;
                            while (arg_40_0 != this._subStoreId)
                            {
                                int? num2 = t.LogicalSubStoreID;
                                bool arg_67_0;
                                if (num2.GetValueOrDefault() == 0)
                                {
                                    arg_67_0 = num2.HasValue;
                                    goto IL_66;
                                }
                                if (7 != 0)
                                {
                                    arg_67_0 = false;
                                    goto IL_66;
                                }
                                goto IL_69;
                            IL_7A:
                                int? arg_7B_0;
                                num2 = arg_7B_0;
                                int subStoreId = this._subStoreId;
                                if (num2.GetValueOrDefault() == subStoreId)
                                {
                                    arg_67_0 = ((arg_40_0 = (arg_AB_0 = (arg_AF_0 = ((!num2.HasValue) ? 1 : 0)))) != 0);
                                    if (-1 == 0)
                                    {
                                        goto IL_67;
                                    }
                                }
                                else
                                {
                                    arg_AB_0 = (arg_40_0 = (arg_AF_0 = 1));
                                }
                                if (7 == 0)
                                {
                                    continue;
                                }
                                if (8 != 0)
                                {
                                    goto IL_AA;
                                }
                                return arg_AF_0 != 0;
                            IL_69:
                                arg_7B_0 = t.LogicalSubStoreID;
                                goto IL_7A;
                            IL_67:
                                if (!arg_67_0)
                                {
                                    goto IL_69;
                                }
                                arg_7B_0 = null;
                                goto IL_7A;
                            IL_66:
                                goto IL_67;
                            }
                        IL_A9:
                            arg_AB_0 = 0;
                        IL_AA:
                            bool flag3 = arg_AB_0 != 0;
                        IL_AC:
                            arg_AF_0 = (flag3 ? 1 : 0);
                            return arg_AF_0 != 0;
                        }).ToList<SubStoresInfo>();
                        bool? isChecked = this.chkLogicalSite.IsChecked;
                        int arg_8F_0;
                        bool arg_2B6_0;
                        if (isChecked.GetValueOrDefault())
                        {
                            arg_2B6_0 = ((arg_8F_0 = (isChecked.HasValue ? 1 : 0)) != 0);
                            if (4 == 0)
                            {
                                goto IL_2B6;
                            }
                        }
                        else
                        {
                            arg_8F_0 = 0;
                        }
                        bool flag2;
                        if (arg_8F_0 != 0)
                        {
                            SubStoresInfo subStoresInfo = source.Where(delegate (SubStoresInfo s)
                            {
                                if (-1 == 0)
                                {
                                    goto IL_21;
                                }
                                int arg_51_0;
                                if (s.SiteID == Convert.ToInt32(this.cmbSiteCode.SelectedValue))
                                {
                                    if (false)
                                    {
                                        goto IL_23;
                                    }
                                    arg_51_0 = (s.IsLogicalSubStore ? 1 : 0);
                                }
                                else
                                {
                                    arg_51_0 = 0;
                                }
                            IL_1E:
                            IL_1F:
                                bool flag3 = arg_51_0 != 0;
                            IL_21:
                            IL_23:
                                bool expr_54 = (arg_51_0 = (flag3 ? 1 : 0)) != 0;
                                if (false)
                                {
                                    goto IL_1F;
                                }
                                if (true)
                                {
                                    return expr_54;
                                }
                                goto IL_1E;
                            }).FirstOrDefault<SubStoresInfo>();
                            bool flag = subStoresInfo == null;
                            if (true && !flag)
                            {
                                MessageBox.Show("This site code is already mapped.");
                                if (5 != 0)
                                {
                                    goto IL_422;
                                }
                            }
                        }
                        else
                        {
                            int expr_EA = (arg_27_0 = (this.ddlLogicalSiteName.SelectedIndex == 0)) ? 1 : 0;
                            int expr_ED = arg_27_1 = 0;
                            if (expr_ED != 0)
                            {
                                continue;
                            }
                            bool flag = expr_EA == expr_ED;
                            bool arg_1E9_0;
                            bool expr_F7 = arg_1E9_0 = flag;
                            if (false)
                            //if (!false) vikas
                            {
                                if (!expr_F7)
                                {
                                    SubStoresInfo subStoresInfo2 = source.Where(delegate (SubStoresInfo s)
                                    {
                                        bool result;
                                        do
                                        {
                                            if (true && !false)
                                            {
                                                result = (s.SiteID == Convert.ToInt32(this.cmbSiteCode.SelectedValue));
                                            }
                                            while (false)
                                            {
                                            }
                                        }
                                        while (8 == 0);
                                        return result;
                                    }).FirstOrDefault<SubStoresInfo>();
                                    if (subStoresInfo2 != null)
                                    {
                                        MessageBox.Show("This site code is already mapped.");
                                        goto IL_422;
                                    }
                                }
                            }
                            else
                            {
                            IL_1E9:
                                string uniqueSynccode = "";
                                bool islogiaclsubstore = this.chkLogicalSite.IsChecked == true;
                                int StoreID =0;
                                if (!arg_1E9_0)
                                {
                                    if (this.cmbSiteCode.SelectedIndex != 0)
                                    {

                                        int num = this.ddlLogicalSiteName.SelectedValue.ToInt32();
                                        if (String.IsNullOrEmpty(this.hdnID.Text))
                                        {
                                            flag2 = new StoreSubStoreDataBusniess().SetSubStoreDetails(this.txtSubStoreName.Text, this.txtDescription.Text, StoreID, uniqueSynccode, LoginUser.StoreName, islogiaclsubstore, new int?(num), this.cmbSiteCode.Text, this.cmbSiteCode.SelectedValue.ToInt32());
                                        }
                                        else
                                        {
                                            flag2 = new StoreSubStoreDataBusniess().UpdateSubStore(this.txtSubStoreName.Text, this.txtDescription.Text, this.hdnID.Text, this.cmbSiteCode.Text, this.cmbSiteCode.SelectedValue.ToInt32(),LoginUser.StoreName,this.chkLogicalSite.IsChecked==true,this.ddlLogicalSiteName.SelectedValue.ToInt32());
                                        }

                                        goto IL_2D8;
                                    }
                                    MessageBox.Show("Please Select Site Code");
                                    this.cmbSiteCode.Focus();
                                    goto IL_422;
                                }
                                else
                                {
                                    if (this.cmbSiteCode.SelectedIndex != 0)
                                    {
                                        if (String.IsNullOrEmpty(this.hdnID.Text))
                                        {
                                            arg_2B6_0 = new StoreSubStoreDataBusniess().SetSubStoreDetails(this.txtSubStoreName.Text, this.txtDescription.Text, StoreID, uniqueSynccode, LoginUser.StoreName, islogiaclsubstore, null, this.cmbSiteCode.Text, this.cmbSiteCode.SelectedValue.ToInt32());
                                        }
                                        else
                                        {
                                            arg_2B6_0 = new StoreSubStoreDataBusniess().UpdateSubStore(this.txtSubStoreName.Text, this.txtDescription.Text, this.hdnID.Text, this.cmbSiteCode.Text, this.cmbSiteCode.SelectedValue.ToInt32(), LoginUser.StoreName, this.chkLogicalSite.IsChecked == true, this.ddlLogicalSiteName.SelectedValue.ToInt32());
                                        }
                                        goto IL_2B6;
                                    }
                                    MessageBox.Show("Please Select Site Code");
                                    this.cmbSiteCode.Focus();
                                    goto IL_422;
                                }
                            }
                        }
                        break;
                    IL_2B6:
                        flag2 = arg_2B6_0;
                    IL_2D8:
                        int arg_2DB_0 = flag2 ? 1 : 0;
                        int arg_2DB_1 = 0;
                    IL_2DB:
                        if (arg_2DB_0 != arg_2DB_1)
                        {
                            if (this._subStoreId != 0)
                            {
                                //AuditLog.AddUserLog(LoginUser.UserId, 61, "Edit a Substore at");
                            }
                            else
                            {
                                //AuditLog.AddUserLog(LoginUser.UserId, 60, "Add a Substore at");
                            }
                            if (this._subStoreId == 0)
                            {
                                MessageBox.Show("Record saved successfully");
                            }
                            else
                            {
                                MessageBox.Show("Record updated successfully");
                            }
                            this.txtDescription.Text = string.Empty;
                            this.txtSubStoreName.Text = string.Empty;
                            this.hdnID.Text = string.Empty;
                            do
                            {
                                this._subStoreId = 0;
                            }
                            while (false);
                            this.chkLogicalSite.IsChecked = new bool?(false);
                            this.ddlLogicalSiteName.SelectedIndex = 0;
                            this.cmbSiteCode.SelectedIndex = 0;
                            this.cmbSiteCode.IsEnabled = true;
                            this.chkLogicalSite.IsEnabled = true;
                        }
                        else
                        {
                            MessageBox.Show("Problem while saving record.");
                        }
                        this.FillSubstore();
                        this.GetSubstoreData();
                        this.ddlLogicalSiteName.SelectedIndex = 0;
                        goto IL_420;
                    }
                    if (this.IsValidate())
                    {
                        string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Location).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                        bool islogiaclsubstore = this.chkLogicalSite.IsChecked == true;
                        int num = (this.ddlLogicalSiteName.SelectedValue != null) ? int.Parse(this.ddlLogicalSiteName.SelectedValue.ToString()) : 0;
                        int arg_2DB_0;
                        int expr_1DB = arg_2DB_0 = num;
                        int arg_2DB_1;
                        int expr_1DE = arg_2DB_1 = 0;
                        if (expr_1DE == 0)
                        {
                            bool arg_1E9_0 = expr_1DB <= expr_1DE;
                            //goto IL_1E9;
                        }
                        //goto IL_2DB;

                    }
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            IL_422:
                if (!false)
                {
                    break;
                }
                continue;
            IL_420:
                goto IL_422;
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.txtDescription.Text = string.Empty;
                if (-1 != 0)
                {
                    this.txtSubStoreName.Text = string.Empty;
                    this.hdnID.Text = string.Empty;
                    this._subStoreId = 0;
                    ToggleButton expr_3F = this.chkLogicalSite;
                    bool? expr_C3 = new bool?(false);
                    if (7 != 0)
                    {
                        expr_3F.IsChecked = expr_C3;
                    }
                    while (-1 == 0)
                    {
                    }
                    this.ddlLogicalSiteName.SelectedIndex = 0;
                    if (false)
                    {
                        goto IL_86;
                    }
                    this.cmbSiteCode.SelectedIndex = 0;
                }
                if (!false)
                {
                    this.cmbSiteCode.IsEnabled = true;
                }
            IL_86:
                this.chkLogicalSite.IsEnabled = true;
            }
            catch (Exception serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (false);
            }
            if (8 != 0)
            {
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    AuditLog.AddUserLog(LoginUser.UserId, 39, "Logged out at ");
                    do
                    {
                        Login login = new Login();
                        login.Show();
                        base.Close();
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
                                goto Block_6;
                            }
                        }
                    }
                Block_6:;
                }
                while (false)
                {
                }
            }
            while (6 == 0);
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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button expr_07 = (Button)sender;
                Button button;
                if (!false)
                {
                    button = expr_07;
                }
                SubStoresInfo substoreData = new StoreSubStoreDataBusniess().GetSubstoreData(((SubStoresInfo)DGManageSubStore.SelectedValue).DG_SubStore_pkey.ToInt32(false));
                if (substoreData != null)
                {
                    this.hdnID.Text = Convert.ToString(substoreData.DG_SubStore_pkey);
                    this.txtSubStoreName.Text = substoreData.DG_SubStore_Name;
                    this.txtDescription.Text = substoreData.DG_SubStore_Description;
                    this._subStoreId = substoreData.DG_SubStore_pkey;
                    this.cmbSiteCode.SelectedValue = substoreData.SiteID;
                    this.chkLogicalSite.IsEnabled = false;
                    if (substoreData.IsLogicalSubStore)
                    {
                        this.chkLogicalSite.IsChecked = new bool?(true);
                        this.lblLogicalsiteNmae.Visibility = Visibility.Visible;
                        this.ddlLogicalSiteName.Visibility = Visibility.Visible;
                        this.ddlLogicalSiteName.SelectedIndex = 0;
                        this.ddlLogicalSiteName.IsEnabled = false;
                        this.chkLogicalSite_Checked(sender, e);
                        this.cmbSiteCode.IsEnabled = true;
                    }
                    else
                    {
                        this.ddlLogicalSiteName.IsEnabled = true;
                        this.chkLogicalSite.IsChecked = new bool?(false);
                        this.ddlLogicalSiteName.SelectedValue = substoreData.LogicalSubStoreID.ToString();
                        this.chkLogicalSite_Unchecked(sender, e);
                        if (this.ddlLogicalSiteName.SelectedIndex > 0)
                        {
                            this.cmbSiteCode.IsEnabled = false;
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void btnLocations_Click(object sender, RoutedEventArgs e)
        {
            AddLocationstoSubstore addLocationstoSubstore = new AddLocationstoSubstore();
            addLocationstoSubstore.Show();
            base.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (3 == 0)
                {
                    goto IL_96;
                }
                string arg_106_0 = string.Empty;
                Button button = (Button)sender;
                int num = button.CommandParameter.ToInt32(false);
                bool flag = num == 0;
                bool arg_48_0 = flag;
                if (false)
                {
                    goto IL_BA;
                }
                if (arg_48_0)
                {
                    goto IL_D3;
                }
                LocationBusniess locationBusniess = new LocationBusniess();
                int arg_5C_0 = locationBusniess.IsSiteAssociatedToLocation(num) ? 1 : 0;
            IL_5B:
                bool arg_68_0;
                bool expr_5C = arg_68_0 = (arg_5C_0 == 0);
                if (3 != 0 && !false)
                {
                    flag = expr_5C;
                    arg_68_0 = flag;
                }
                if (!arg_68_0)
                {
                    string siteAssociation = UIConstant.SiteAssociation;
                    MessageBox.Show(siteAssociation);
                    return;
                }
                //string value = new StoreSubStoreDataBusniess().DeleteSubstore(num);
                //flag = !string.IsNullOrEmpty(value);
                flag = new StoreSubStoreDataBusniess().DeleteSubstore(num);
            IL_96:
                if (flag)
                {
                    MessageBox.Show("Substore Successfully deleted");
                    int expr_A6 = arg_5C_0 = LoginUser.UserId;
                    if (5 == 0)
                    {
                        goto IL_5B;
                    }
                    //AuditLog.AddUserLog(expr_A6, 103, "Delete substore at:- ");
                }
                else
                {
                    this.GetSubstoreData();
                    MessageBox.Show("You can not delete this site because this site has some dependencies, first remove those dependencies.");
                }
            IL_BA:
            IL_D3:
                this.chkLogicalSite.IsChecked = new bool?(false);
                this.FillSubstore();
                this.GetSubstoreData();
                this.ddlLogicalSiteName.SelectedIndex = 0;
                if (-1 != 0)
                {
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void chkLogicalSite_Checked(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_11;
            }
        IL_04:
            if (6 == 0)
            {
                goto IL_20;
            }
            this.ddlLogicalSiteName.IsEnabled = false;
        IL_11:
            if (!false)
            {
                this.cmbSiteCode.IsEnabled = true;
            }
        IL_20:
            if (!false)
            {
                return;
            }
            goto IL_04;
        }

        private void chkLogicalSite_Unchecked(object sender, RoutedEventArgs e)
        {
            this.ddlLogicalSiteName.IsEnabled = true;
        }

        private void ddlLogicalSiteName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            while (true)
            {
                Func<SubStoresInfo, bool> expr_00 = null;
                if (!false)
                {
                    Func<SubStoresInfo, bool> predicate = expr_00;
                }
                SubStoresInfo subStoresInfo;
                if (true)
                {
                    if (this.ddlLogicalSiteName.SelectedIndex <= 0)
                    {
                        this.cmbSiteCode.IsEnabled = true;
                        this.ddlLogicalSiteName.SelectedIndex = 0;
                        if (!false)
                        {
                            return;
                        }
                    }
                    IEnumerable<SubStoresInfo> arg_5A_0 = this.lstStoreSubStore;
                    Func<SubStoresInfo, bool> predicate = delegate (SubStoresInfo t)
                    {
                        bool result;
                        do
                        {
                            if (true && !false)
                            {
                                result = (t.DG_SubStore_pkey == Convert.ToInt32(this.ddlLogicalSiteName.SelectedValue));
                            }
                            while (false)
                            {
                            }
                        }
                        while (8 == 0);
                        return result;
                    };
                    subStoresInfo = arg_5A_0.Where(predicate).FirstOrDefault<SubStoresInfo>();
                    goto IL_65;
                }
            IL_6E:
                this.cmbSiteCode.SelectedValue = subStoresInfo.SiteID;
                if (-1 != 0)
                {
                    if (false)
                    {
                        goto IL_A0;
                    }
                    if (-1 != 0)
                    {
                        break;
                    }
                    continue;
                }
            IL_65:
                if (subStoresInfo != null)
                {
                    goto IL_6E;
                }
                goto IL_9F;
            }
        IL_91:
            this.cmbSiteCode.IsEnabled = false;
        IL_9F:
        IL_A0:
            if (5 == 0)
            {
                goto IL_91;
            }
        }

        //void IStyleConnector.Connect(int connectionId, object target)
        //{
        //    while (true)
        //    {
        //        int arg_16_0 = connectionId;
        //        if (false)
        //        {
        //            goto IL_16;
        //        }
        //        if (4 != 0)
        //        {
        //            arg_16_0 = connectionId - 15;
        //            goto IL_16;
        //        }
        //    IL_5A:
        //        if (!false)
        //        {
        //            if (true)
        //            {
        //                break;
        //            }
        //            continue;
        //        }
        //    IL_23:
        //        goto IL_5A;
        //    IL_16:
        //        switch (arg_16_0)
        //        {
        //            case 0:
        //                ((Button)target).Click += new RoutedEventHandler(this.btnEdit_Click);
        //                break;
        //            case 1:
        //                if (!false)
        //                {
        //                    ((Button)target).Click += new RoutedEventHandler(this.btnDelete_Click);
        //                }
        //                break;
        //        }
        //        goto IL_23;
        //    }
        //}

    }
}
