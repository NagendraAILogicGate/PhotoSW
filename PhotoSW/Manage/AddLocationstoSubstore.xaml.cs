using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using PhotoSW.Views;

namespace PhotoSW.Manage
{
    public partial class AddLocationstoSubstore : Window, IComponentConnector, IStyleConnector
    {
        private Dictionary<string, string> lstSubstores;

        private List<LocationInfo> availableList;

        private List<LocationInfo> associatedList;

       

        public AddLocationstoSubstore()
        {
            this.InitializeComponent();
            this.GetSubstoreDropDown();
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
            this.btnSave.IsDefault = true;
        }

        public void GetSubstoreDropDown()
        {
            do
            {
                try
                {
                    StoreSubStoreDataBusniess storeSubStoreDataBusniess = new StoreSubStoreDataBusniess();
                    this.lstSubstores = new Dictionary<string, string>();
                    Dictionary<string, string> expr_11 = this.lstSubstores;
                    string expr_16 = "0";
                    string expr_1B = "--Select--";
                    if (!false)
                    {
                        expr_11.Add(expr_16, expr_1B);
                    }
                    this.cmbSubStoreName.ItemsSource = storeSubStoreDataBusniess.GetSubstoreDataDir(this.lstSubstores);
                    this.cmbSubStoreName.SelectedValue = "0";
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

        public void GetListAvailableLocations(int SubstoreID)
        {
            do
            {
                StoreSubStoreDataBusniess storeSubStoreDataBusniess = new StoreSubStoreDataBusniess();
                try
                {
                    do
                    {
                        this.availableList = storeSubStoreDataBusniess.GetAvailableLocationsSubstore(SubstoreID);
                        this.lstAvailableLocations.ItemsSource = this.availableList;
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
                                goto Block_5;
                            }
                        }
                    }
                Block_5: ;
                }
            }
            while (false || 6 == 0);
        }

        public void GetListSelectedLocations(int SubStoreID)
        {
            if (!false)
            {
                try
                {
                    do
                    {
                        this.associatedList = new StoreSubStoreDataBusniess().GetSelectedLocationsSubstore(SubStoreID);
                        this.lstSelectedLocations.ItemsSource = this.associatedList;
                    }
                    while (7 == 0);
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        if (!false)
                        {
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                        if (2 != 0)
                        {
                        }
                    }
                    while (3 == 0);
                }
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            base.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }

        public void DoubleClickHandler(object sender, MouseEventArgs e)
        {
            ListBoxItem listBoxItem = sender as ListBoxItem;
            if (listBoxItem.Content.ToString() == "DigiPhoto.DataLayer.Model.vw_GetSubStoreLocations")
            {
                if (this.cmbSubStoreName.SelectedValue != "0" && this.lstSelectedLocations.SelectedItem != null)
                {
                    object selectedItem = this.lstSelectedLocations.SelectedItem;
                    LocationInfo locationInfo = new LocationInfo();
                    locationInfo.DG_Location_Name = ((LocationInfo)selectedItem).DG_Location_Name;
                    locationInfo.DG_Location_pkey = ((LocationInfo)selectedItem).DG_Location_pkey;
                    this.lstAvailableLocations.Items.Add(locationInfo);
                    this.lstSelectedLocations.Items.Remove(selectedItem);
                    this.lstSelectedLocations.Items.Refresh();
                    if (false)
                    {
                        goto IL_1E3;
                    }
                    this.lstAvailableLocations.Items.Refresh();
                }
                else
                {
                    MessageBox.Show(UIConstant.SelectSubstoreAndLocation);
                }
                this.ApplyNoSelection();
                return;
            }
            if (!(listBoxItem.Content.ToString() == "DigiPhoto.DataLayer.Model.vw_GetListAvailableLocations"))
            {
                return;
            }
            if (this.cmbSubStoreName.SelectedValue != "0" && this.lstAvailableLocations.SelectedItem != null)
            {
                object selectedItem = this.lstAvailableLocations.SelectedItem;
                LocationInfo locationInfo = new LocationInfo();
                locationInfo.DG_Location_Name = ((LocationInfo)selectedItem).DG_Location_Name;
                locationInfo.DG_Location_pkey = ((LocationInfo)selectedItem).DG_Location_pkey;
                this.lstSelectedLocations.Items.Add(locationInfo);
                this.lstAvailableLocations.Items.Remove(selectedItem);
                this.lstSelectedLocations.Items.Refresh();
                this.lstAvailableLocations.Items.Refresh();
            }
            else
            {
                MessageBox.Show(UIConstant.SelectSubstoreAndLocation);
            }
        IL_1E3:
            this.ApplyNoSelection();
        }

        private void cmbSubStoreName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!false)
            {
                try
                {
                    ItemsControl expr_0A = this.lstSelectedLocations;
                    IEnumerable expr_0F = null;
                    if (2 != 0)
                    {
                        expr_0A.ItemsSource = expr_0F;
                    }
                    this.lstAvailableLocations.ItemsSource = null;
                    this.GetListSelectedLocations(this.cmbSubStoreName.SelectedValue.ToInt32(false));
                    if (!false)
                    {
                        this.GetListAvailableLocations(((KeyValuePair<string, string>)this.cmbSubStoreName.SelectedItem).Key.ToInt32(false));
                    }
                    this.ApplyNoSelection();
                }
                catch (Exception serviceException)
                {
                    string message;
                    do
                    {
                        message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    }
                    while (false);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void ApplyNoSelection()
        {
            int arg_16_0 = this.lstAvailableLocations.Items.Count;
            int arg_8F_0;
            do
            {
                bool expr_19 = (arg_16_0 = (arg_8F_0 = ((arg_16_0 != 0) ? 1 : 0))) != 0;
                if (8 != 0)
                {
                    if (!expr_19)
                    {
                        this.lstAvailableLocations.Visibility = Visibility.Collapsed;
                        if (7 != 0)
                        {
                            if (6 == 0)
                            {
                                return;
                            }
                            this.noitemlstAvailableLocations.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        do
                        {
                            this.noitemlstAvailableLocations.Visibility = Visibility.Collapsed;
                            this.lstAvailableLocations.Visibility = Visibility.Visible;
                        }
                        while (2 == 0);
                    }
                    arg_8F_0 = (arg_16_0 = this.lstSelectedLocations.Items.Count);
                }
            }
            while (7 == 0);
            if (arg_8F_0 == 0)
            {
                this.lstSelectedLocations.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.noitemlstSelectedLocations.Visibility = Visibility.Collapsed;
                this.lstSelectedLocations.Visibility = Visibility.Visible;
                if (!false)
                {
                    return;
                }
            }
            this.noitemlstSelectedLocations.Visibility = Visibility.Visible;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (true)
            {
            }
            StoreSubStoreDataBusniess storeSubStoreDataBusniess = new StoreSubStoreDataBusniess();
            try
            {
                bool flag = this.cmbSubStoreName.SelectedValue == "0";
                int arg_13E_0;
                do
                {
                    bool expr_179 = (arg_13E_0 = (flag ? 1 : 0)) != 0;
                    if (4 == 0)
                    {
                        goto IL_FE;
                    }
                    if (expr_179)
                    {
                        goto IL_152;
                    }
                    storeSubStoreDataBusniess.DeleteSubStoreLocations(this.cmbSubStoreName.SelectedValue.ToInt32(false));
                }
                while (-1 == 0);
                string text = "";
                IEnumerator enumerator = ((IEnumerable)this.lstSelectedLocations.Items).GetEnumerator();
                try
                {
                    while (true)
                    {
                        flag = enumerator.MoveNext();
                        bool expr_C6 = flag;
                        object current;
                        if (2 != 0)
                        {
                            if (!expr_C6)
                            {
                                break;
                            }
                            current = enumerator.Current;
                            storeSubStoreDataBusniess.SetSubStoreLocationsDetails(this.cmbSubStoreName.SelectedValue.ToInt32(false), ((LocationInfo)current).DG_Location_pkey);
                        }
                        text = text + ", " + ((LocationInfo)current).DG_Location_Name;
                    }
                }
                finally
                {
                    if (!false)
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        flag = (disposable == null);
                        if (false || !flag)
                        {
                            disposable.Dispose();
                        }
                    }
                }
                CustomBusineses customBusineses = new CustomBusineses();
                arg_13E_0 = LoginUser.UserId;
            IL_FE:
                AuditLog.AddUserLog(arg_13E_0, 62, string.Concat(new string[]
				{
					"Assign ",
					text,
					"to ",
					this.cmbSubStoreName.Text,
					" at :-"
				}));
                MessageBox.Show(UIConstant.SubstoreSavedSuccessfully);
                goto IL_15F;
            IL_152:
                MessageBox.Show(UIConstant.SelectSubstore);
            IL_15F: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                if (!false)
                {
                }
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                while (true)
                {
                    if (!false)
                    {
                        this.cmbSubStoreName.SelectedValue = "0";
                        if (2 != 0)
                        {
                            this.lstAvailableLocations.ItemsSource = null;
                            this.lstSelectedLocations.ItemsSource = null;
                        }
                    }
                IL_2D:
                    this.GetListAvailableLocations(this.cmbSubStoreName.SelectedValue.ToInt32(false));
                    if (2 == 0)
                    {
                        continue;
                    }
                    this.ApplyNoSelection();
                    if (!false)
                    {
                        break;
                    }
                    goto IL_2D;
                }
            }
            catch (Exception var_0_7F)
            {
                while (false)
                {
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    while (true)
                    {
                        while (!false)
                        {
                           // ManageSubstores manageSubstores = new ManageSubstores();
                           // manageSubstores.Show();
                            do
                            {
                                base.Close();
                            }
                            while (false);
                            if (!false)
                            {
                                goto Block_4;
                            }
                        }
                    }
                Block_4: ;
                }
                catch (Exception var_1_3A)
                {
                }
            }
            while (false);
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            bool arg_111_0 = this.cmbSubStoreName.SelectedValue == "0" || this.lstAvailableLocations.SelectedItem == null;
            bool expr_117;
            do
            {
                bool flag = arg_111_0;
                expr_117 = (arg_111_0 = flag);
            }
            while (7 == 0);
            if (!expr_117)
            {
                LocationInfo locationInfo = (LocationInfo)this.lstAvailableLocations.SelectedItem;
                LocationInfo locationInfo2 = new LocationInfo();
                locationInfo2.DG_Location_Name = locationInfo.DG_Location_Name;
                locationInfo2.DG_Location_pkey = locationInfo.DG_Location_pkey;
                this.associatedList.Add(locationInfo2);
                this.lstSelectedLocations.ItemsSource = this.associatedList;
                this.availableList.Remove(locationInfo);
                this.lstAvailableLocations.ItemsSource = this.availableList;
                this.lstSelectedLocations.Items.Refresh();
                this.lstAvailableLocations.Items.Refresh();
            }
            else
            {
                MessageBox.Show(UIConstant.SelectSubstoreAndLocation);
            }
            this.ApplyNoSelection();
        }

        private void Removebtn_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                bool arg_123_0 = this.cmbSubStoreName.SelectedValue == "0" || this.lstSelectedLocations.SelectedItem == null;
                while (true)
                {
                    if (!false)
                    {
                    }
                    while (true)
                    {
                        bool flag = arg_123_0;
                        bool expr_129 = arg_123_0 = flag;
                        if (7 == 0)
                        {
                            break;
                        }
                        if (expr_129)
                        {
                            goto IL_E8;
                        }
                        LocationInfo locationInfo = (LocationInfo)this.lstSelectedLocations.SelectedItem;
                        LocationInfo locationInfo2 = new LocationInfo();
                        locationInfo2.DG_Location_Name = locationInfo.DG_Location_Name;
                        locationInfo2.DG_Location_pkey = locationInfo.DG_Location_pkey;
                        this.availableList.Add(locationInfo2);
                        arg_123_0 = this.associatedList.Remove(locationInfo);
                        if (!false)
                        {
                            goto IL_99;
                        }
                    }
                }
            IL_99:
                while (3 != 0)
                {
                    this.lstAvailableLocations.ItemsSource = this.availableList;
                    this.lstSelectedLocations.ItemsSource = this.associatedList;
                    this.lstSelectedLocations.Items.Refresh();
                    if (!false)
                    {
                        this.lstAvailableLocations.Items.Refresh();
                        break;
                    }
                }
            IL_F5:
                this.ApplyNoSelection();
                if (!false)
                {
                    break;
                }
                continue;
            IL_E8:
                MessageBox.Show(UIConstant.SelectSubstoreAndLocation);
                goto IL_F5;
            }
        }

       void IStyleConnector.Connect(int connectionId, object target)
        {
            int arg_5F_0 = connectionId;
            while (true)
            {
                int num = arg_5F_0;
                while (true)
                {
                    int expr_65 = arg_5F_0 = num;
                    if (2 == 0)
                    {
                        break;
                    }
                    if (expr_65 == 1)
                    {
                        //goto IL_18;
                    }
                    if (true)
                    {
                        return;
                    }
                }
            }
            EventSetter eventSetter;
            while (true)
            {
            IL_18:
                eventSetter = new EventSetter();
                eventSetter.Event = Control.MouseDoubleClickEvent;
                while (true)
                {
                    eventSetter.Handler = new MouseButtonEventHandler(this.DoubleClickHandler);
                    if (!false)
                    {
                        if (3 != 0)
                        {
                            goto Block_6;
                        }
                        goto IL_18;
                    }
                }
                return;
            }
        Block_6:
            ((Style)target).Setters.Add(eventSetter);
        }
    }
}
