using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
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
using PhotoSW.Views;

namespace PhotoSW.Manage
{
    public partial class ManageLocations : Window, IComponentConnector, IStyleConnector
    {
        public int _locationId = 0;

        public ManageLocations()
        {
            try
            {
                this.InitializeComponent();
                this.GetLocations(false);
                this.txbUserName.Text = LoginUser.UserName;
                this.txbStoreName.Text = LoginUser.StoreName;
                this.txtStoreName.Text = LoginUser.StoreName;
                this.btnSave.IsDefault = true;
            }
            catch (Exception var_0_62)
            {
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LocationBusniess locationBusniess;
                do
                {
                    locationBusniess = new LocationBusniess();
                    //this._locationId = ((Button)sender).Tag.ToInt32(false);
                    this._locationId = ((LocationInfo)DGManageLocation.SelectedValue).DG_Location_pkey.ToInt32(false);//((Button)sender).CommandParameter.(false);
                    //this._locationId = locationBusniess.GetIdbyLocationPkey(this._locationId);                   

                }
                while (false);
                LocationInfo locationsbyId = locationBusniess.GetLocationsbyId(this._locationId);
                bool flag = locationsbyId == null;
                if (7 == 0 || !flag)
                {
                    this.txtLocationName.Text = locationsbyId.DG_Location_Name;
                    this.hdnID.Text = locationsbyId.DG_Location_pkey.ToString();
                }
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            this.txtLocationName.Text = string.Empty;
            this.hdnID.Text = string.Empty;
            this._locationId = 0;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ManageHome manageHome = new ManageHome();
            manageHome.Show();
            base.Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!false)
                {
                    //this._locationId = ((Button)sender).Tag.ToInt32(false);
                    this._locationId = ((LocationInfo)DGManageLocation.SelectedValue).DG_Location_pkey.ToInt32(false);//((Button)sender).CommandParameter.(false);
                    LocationBusniess locationBusniess = new LocationBusniess();
                    bool arg_45_0 = !locationBusniess.IsLocationAssociatedToSite(this._locationId);
                    bool expr_72;
                    do
                    {
                        bool flag = arg_45_0;
                        bool arg_6F_0;
                        bool expr_46 = arg_6F_0 = flag;
                        if (!false)
                        {
                            if (!expr_46)
                            {
                                goto IL_4C;
                            }
                            arg_6F_0 = locationBusniess.DeleteLocations(this._locationId);
                        }
                        flag = !arg_6F_0;
                        expr_72 = (arg_45_0 = flag);
                    }
                    while (false);
                    if (!expr_72)
                    {
                        this.GetLocations(true);
                        MessageBox.Show(UIConstant.LocationSuccessfullyDeleted);
                        if (!false)
                        {
                            this.txtLocationName.Text = string.Empty;
                            this._locationId = 0;
                        }
                    }
                    goto IL_FD;
                }
            IL_4C:
                if (!false)
                {
                }
                string locationAssociation = UIConstant.LocationAssociation;
                MessageBox.Show(locationAssociation);
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        IL_FD:
            if (!false)
            {
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            base.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool arg_FE_0 = string.IsNullOrEmpty(this.txtLocationName.Text);
                bool expr_62 = false;
                while (!arg_FE_0)
                {
                    string uniqueSynccode = CommonUtility.GetUniqueSynccode("00", LoginUser.countrycode, LoginUser.Storecode, "00");
                    LocationBusniess locationBusniess = new LocationBusniess();
                    if (String.IsNullOrEmpty(this.hdnID.Text))
                    {
                        expr_62 = arg_FE_0 = locationBusniess.SetLocations(this._locationId, this.txtLocationName.Text, LoginUser.StoreId, uniqueSynccode);
                    }
                    else
                    {//UpdateLocation
                        expr_62 = arg_FE_0 = locationBusniess.UpdateLocation(Convert.ToInt32(this.hdnID.Text), this.txtLocationName.Text);
                    }
                    if (!false)
                    {
                        if (!expr_62)
                        {
                            if (6 != 0)
                            {
                                MessageBox.Show(UIConstant.Locationalreadyexist);
                                goto IL_A7;
                            }
                            goto IL_8D;
                        }
                    IL_72:
                        MessageBox.Show(UIConstant.LocationSavedSuccessfully);
                        this.txtLocationName.Text = string.Empty;
                        this.hdnID.Text = string.Empty;
                        goto IL_C6;
                    IL_8D:
                        this._locationId = 0;
                        goto IL_C6;
                    IL_A7:
                        this.txtLocationName.Text = string.Empty;
                    IL_B8:
                        if (!true)
                        {
                            goto IL_A7;
                        }
                        if (5 == 0)
                        {
                            goto IL_72;
                        }
                        this._locationId = 0;
                    IL_C6:
                        this.GetLocations(true);
                    IL_DE:
                        if (6 != 0)
                        {
                            return;
                        }
                        goto IL_B8;
                    }
                }
                MessageBox.Show(UIConstant.LocationNameCannotBeBlank);
                //goto IL_DE;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
                while (false)
                {
                }
            }
        }

        private void GetLocations(bool reloadLoc)
        {
            LocationBusniess locationBusniess = new LocationBusniess();
            List<LocationInfo> expr_7C = locationBusniess.GetLocations(LoginUser.StoreId);
            List<LocationInfo> list;
            if (true)
            {
                list = expr_7C;
            }
            int arg_26_0;
            int expr_92 = arg_26_0 = list.Count;
            if (!false)
            {
                arg_26_0 = ((expr_92 >= 0) ? 1 : 0);
            }
            bool flag;
            while (true)
            {
                flag = (arg_26_0 == 0);
                while (true)
                {
                    if (!flag)
                    {
                        if (7 == 0)
                        {
                            goto IL_53;
                        }
                        if (false)
                        {
                            continue;
                        }
                        this.DGManageLocation.ItemsSource = list;
                    }
                    bool expr_47 = (arg_26_0 = ((!reloadLoc) ? 1 : 0)) != 0;
                    if (false)
                    {
                        break;
                    }
                    flag = expr_47;
                    if (!false)
                    {
                        goto Block_6;
                    }
                }
            }
        Block_6:
            if (flag)
            {
                return;
            }
        IL_53:
            this.LoadSearchByPhotoLocation(list);
        }

        private void LoadSearchByPhotoLocation(List<LocationInfo> itemlist)
        {
            SearchByPhoto searchByPhoto;
            if (false || -1 != 0)
            {
                searchByPhoto = (from Window wnd in Application.Current.Windows
                                 where wnd.Title == "Search"
                                 select wnd).Cast<SearchByPhoto>().FirstOrDefault<SearchByPhoto>();
            }
            if (searchByPhoto != null)
            {
                List<LocationInfo> list = new List<LocationInfo>();
                list.AddRange(itemlist);
                searchByPhoto.LoadLocation(list);
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
        //            // arg_16_0 = connectionId - 14;
        //            arg_16_0 = connectionId;
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
        //            case 10:
        //                ((Button)target).Click += new RoutedEventHandler(this.btnEdit_Click);
        //                break;
        //            case 11:
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
