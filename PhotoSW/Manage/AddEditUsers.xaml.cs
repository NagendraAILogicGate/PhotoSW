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
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using PhotoSW.Views;
using PhotoSW.DataLayer;

namespace PhotoSW.Manage
{
    public partial class AddEditUsers : Window, IComponentConnector, IStyleConnector
    {
        private TextBox controlon;

        public string _email;

        public string _password;

        public string _roleName;

        public string _firstname;

        public string _username;

        public string _lastname;

        public string _storename;

        public string _location;

        public string _status;

        public string _Temparmsg;

        private Dictionary<string, string> lstStatus = new Dictionary<string, string>();

        private int userId = 0;

        private Dictionary<string, int> _locationList;



        public Dictionary<string, int> LocationList
        {
            get
            {
                return this._locationList;
            }
            set
            {
                this._locationList = value;
            }
        }

        public AddEditUsers()
        {
            this.InitializeComponent();
            this.BindGrid();
            this.FillDropDown();
            this.ClearControls();
            this.Add_EditUser.Visibility = Visibility.Collapsed;
            this.grdUsers.Visibility = Visibility.Visible;
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
        }

        public void BindGrid()
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
            UserBusiness userBusiness = new UserBusiness();
        IL_0B:
            if (false)
            {
                goto IL_04;
            }

            this.grdUsers.ItemsSource = userBusiness.GetChildUserDetailByUserId(LoginUser.RoleId);

            if (8 == 0)
            {
                goto IL_04;
            }
        }

        public string checkTempar()
        {
            this._Temparmsg = this._username + " details updated,";
            bool flag = false;
            bool expr_44 = !(this._email != this.txtEmail.Text);
            bool flag2;
            if (5 != 0)
            {
                flag2 = expr_44;
            }
            if (!flag2)
            {
                string temparmsg = this._Temparmsg;
                this._Temparmsg = string.Concat(new string[]
                {
                    temparmsg,
                    " email '",
                    this._email,
                    "' has been changed to '",
                    this.txtEmail.Text,
                    "'"
                });
                flag = true;
            }
            flag2 = !(this._password != this.txtPassword.Password);
            if (!flag2)
            {
                flag2 = !flag;
                if (!flag2)
                {
                    this._Temparmsg += " and password has been changed";
                }
                else
                {
                    this._Temparmsg += " password has been changed";
                }
                flag = true;
            }
            flag2 = !(this._location != this.cmbLocation.Text);
            if (flag2)
            {
                goto IL_1E0;
            }
            flag2 = !flag;
            if (!flag2)
            {
                string temparmsg = this._Temparmsg;
                this._Temparmsg = string.Concat(new string[]
                {
                    temparmsg,
                    " and location' ",
                    this._location,
                    " ' has been changed to '",
                    this.cmbLocation.Text,
                    "'"
                });
            }
            else
            {
                string temparmsg = this._Temparmsg;
                this._Temparmsg = string.Concat(new string[]
                {
                    temparmsg,
                    " location'",
                    this._location,
                    "' has been changed to '",
                    this.cmbLocation.Text,
                    "'"
                });
            }
        IL_1DC:
            flag = true;
        IL_1E0:
            flag2 = !(this._roleName != this.cmbRoleName.Text);
            if (!flag2)
            {
                flag2 = !flag;
                if (!flag2)
                {
                    string temparmsg = this._Temparmsg;
                    this._Temparmsg = string.Concat(new string[]
                    {
                        temparmsg,
                        " and role '",
                        this._roleName,
                        "' has been changed to '",
                        this.cmbRoleName.Text,
                        "'"
                    });
                }
                else
                {
                    string temparmsg = this._Temparmsg;
                    this._Temparmsg = string.Concat(new string[]
                    {
                        temparmsg,
                        "role '",
                        this._roleName,
                        "' has been changed to '",
                        this.cmbRoleName.Text,
                        "'"
                    });
                }
                flag = true;
            }
            flag2 = !(this._status != this.cmbStatus.Text);
            if (!flag2)
            {
                flag2 = !flag;
                if (!flag2)
                {
                    string temparmsg = this._Temparmsg;
                    this._Temparmsg = string.Concat(new string[]
                    {
                        temparmsg,
                        " and user status '",
                        this._status,
                        "' has been changed to '",
                        this.cmbStatus.Text,
                        "'"
                    });
                }
                else
                {
                    string temparmsg = this._Temparmsg;
                    this._Temparmsg = string.Concat(new string[]
                    {
                        temparmsg,
                        "user status '",
                        this._status,
                        "' has been changed to '",
                        this.cmbStatus.Text,
                        "'"
                    });
                }
                if (false)
                {
                    goto IL_3B5;
                }
                flag = true;
            }
            flag2 = !(this._firstname != this.txtFName.Text);
        IL_3B5:
            if (!flag2)
            {
                flag2 = !flag;
                if (!flag2)
                {
                    string temparmsg = this._Temparmsg;
                    this._Temparmsg = string.Concat(new string[]
                    {
                        temparmsg,
                        " and first name '",
                        this._firstname,
                        "' has been changed to '",
                        this.txtFName.Text,
                        "'"
                    });
                }
                else
                {
                    string temparmsg = this._Temparmsg;
                    this._Temparmsg = string.Concat(new string[]
                    {
                        temparmsg,
                        " first name '",
                        this._firstname,
                        "' has been changed to '",
                        this.txtFName.Text,
                        "'"
                    });
                }
                flag = true;
            }
            if (!false)
            {
                flag2 = !(this._lastname != this.txtLName.Text);
                if (!flag2)
                {
                    flag2 = !flag;
                    if (!flag2)
                    {
                        string temparmsg = this._Temparmsg;
                        this._Temparmsg = string.Concat(new string[]
                        {
                            temparmsg,
                            " and last name '",
                            this._lastname,
                            "' has been changed to '",
                            this.txtLName.Text,
                            "'"
                        });
                    }
                    else
                    {
                        string temparmsg = this._Temparmsg;
                        this._Temparmsg = string.Concat(new string[]
                        {
                            temparmsg,
                            " last name '",
                            this._lastname,
                            "' has been changed to '",
                            this.txtLName.Text,
                            "'"
                        });
                    }
                }
                return this._Temparmsg;
            }
            goto IL_1DC;
        }

        public void FillDropDown()
        {
            this.lstStatus.Add("--Select--", "0");
            do
            {
                this.lstStatus.Add("Active", "1");
                this.lstStatus.Add("InActive", "2");
                this.cmbStatus.ItemsSource = this.lstStatus;
                do
                {
                    this.cmbStatus.SelectedValue = "0";
                    List<SubStoresInfo> SubStoresInfoList = new StoreSubStoreDataBusniess().GetAllLogicalSubstoreName();
                    CommonUtility.BindComboWithSelect<SubStoresInfo>(this.cmbStoreName, SubStoresInfoList, "DG_SubStore_Name", "DG_SubStore_pkey", 0, ClientConstant.SelectString);
                }
                while (2 == 0);
                RolePermissionsBusniess rolePermissionsBusniess = new RolePermissionsBusniess();
                this.LocationList = new Dictionary<string, int>();
            }
            while (7 == 0);
            //this.cmbStoreName.SelectedValue = LoginUser.StoreId;
            //this.cmbStoreName.IsEnabled = false;
            //this.cmbStoreName.SelectedValue = "0";
            //int storeId = this.cmbStoreName.SelectedValue.ToInt32(false);
            //LocationBusniess locationBusniess = new LocationBusniess();

            // this.cmbLocation.ItemsSource = locationBusniess.GetLocationNameDirTest();

            // this.cmbLocation.ItemsSource = locationBusniess.GetLocationList(storeId <= 0 ? 0 : storeId);

            //this.cmbLocation.SelectedValue = "0";
        }

        public void ClearControls()
        {
            this.txtEmail.Text = "";
            this.txtEmail.BorderBrush = new SolidColorBrush(Colors.Gray);
            TextBox expr_35 = this.txtFName;
            string expr_3A = "";
            if (8 != 0)
            {
                expr_35.Text = expr_3A;
            }
            this.txtFName.BorderBrush = new SolidColorBrush(Colors.Gray);
            this.txtLName.Text = "";
            this.txtLName.BorderBrush = new SolidColorBrush(Colors.Gray);
            this.txtMobileNumber.Text = "";
            do
            {
                this.txtMobileNumber.BorderBrush = new SolidColorBrush(Colors.Gray);
                this.cmbRoleName.SelectedValue = "0";
                this.cmbRoleName.BorderBrush = new SolidColorBrush(Colors.Gray);
                this.cmbStatus.SelectedValue = "0";
                this.cmbStatus.BorderBrush = new SolidColorBrush(Colors.Gray);
                this.cmbStoreName.SelectedValue = 0;
                this.cmbStoreName.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
            while (false);
            this.txtFName.Focus();
            this.cmbLocation.SelectedValue = "0";
            this.cmbLocation.BorderBrush = new SolidColorBrush(Colors.Gray);
            this.txtUserName.Text = "";
            this.txtPassword.Password = "";
            this.txtPassword.BorderBrush = new SolidColorBrush(Colors.Gray);
        }

        public bool ControlValidation()
        {
            if (6 == 0)
            {
                goto IL_10C;
            }
            bool result = true;
            if (7 != 0)
            {
                if (!string.IsNullOrEmpty(this.txtFName.Text))
                {
                    this.txtFName.BorderBrush = new SolidColorBrush(Colors.Gray);
                    goto IL_6B;
                }
                this.txtFName.BorderBrush = new SolidColorBrush(Colors.Red);
            }
            result = false;
        IL_6B:
            bool flag = !string.IsNullOrEmpty(this.txtUserName.Text);
        IL_7F:
            if (!flag)
            {
                this.txtUserName.BorderBrush = new SolidColorBrush(Colors.Red);
                result = false;
            }
            else
            {
                this.txtUserName.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
            if (false)
            {
                goto IL_17D;
            }
            flag = !string.IsNullOrEmpty(this.txtEmail.Text);
            bool arg_D1_0 = flag;
        IL_D1:
            int arg_17A_0;
            if (!arg_D1_0)
            {
                this.txtEmail.BorderBrush = new SolidColorBrush(Colors.Red);
                int expr_EB = arg_17A_0 = 0;
                if (expr_EB != 0)
                {
                    goto IL_17A;
                }
                result = (expr_EB != 0);
            }
            else
            {
                this.txtEmail.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
        IL_10C:
            bool arg_123_0;
            bool expr_118 = arg_123_0 = string.IsNullOrEmpty(this.txtMobileNumber.Text);
            if (3 != 0)
            {
                arg_123_0 = !expr_118;
            }
            if (!arg_123_0)
            {
                this.txtMobileNumber.BorderBrush = new SolidColorBrush(Colors.Red);
                result = false;
            }
            else
            {
                this.txtMobileNumber.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
            flag = !(this.cmbRoleName.SelectedValue.ToString() == "0");
            arg_17A_0 = (flag ? 1 : 0);
        IL_17A:
            if (arg_17A_0 != 0)
            {
                this.cmbRoleName.BorderBrush = new SolidColorBrush(Colors.Gray);
                goto IL_1B0;
            }
        IL_17D:
            this.cmbRoleName.BorderBrush = new SolidColorBrush(Colors.Red);
            result = false;
        IL_1B0:
            bool expr_1C5 = arg_D1_0 = (this.cmbStatus.SelectedValue.ToString() == "0");
            if (false)
            {
                goto IL_D1;
            }
            if (expr_1C5)
            {
                this.cmbStatus.BorderBrush = new SolidColorBrush(Colors.Red);
                result = false;
            }
            else
            {
                this.cmbStatus.BorderBrush = new SolidColorBrush(Colors.Gray);
            }
            //flag = !(this.cmbStoreName.SelectedValue.ToString() == "0");
            //if (!flag)
            //{
            //    this.cmbStoreName.BorderBrush = new SolidColorBrush(Colors.Red);
            //    result = false;
            //}
            //else
            //{
            //    this.cmbStoreName.BorderBrush = new SolidColorBrush(Colors.Gray);
            //}
            if (!false)
            {
                return result;
            }
            goto IL_7F;
        }

        private bool ControlValueValidate(bool retvalue)
        {
            return retvalue;
        }

        private void cmbStoreName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (4 != 0)
            {
                try
                {
                    do
                    {
                        this.cmbLocation.ItemsSource = null;
                        if (8 == 0)
                        {
                            goto IL_5A;
                        }
                        this.LocationList = new Dictionary<string, int>();
                    }
                    while (false);
                    int storeId = this.cmbStoreName.SelectedValue.ToInt32(false);
                    do
                    {
                        LocationBusniess locationBusniess = new LocationBusniess();
                        List<LocationInfo> ItemsSource = locationBusniess.GetLocationNameDir(storeId);
                        CommonUtility.BindComboWithSelect<LocationInfo>(this.cmbLocation, ItemsSource, "DG_Location_Name", "DG_Location_pkey", 0, ClientConstant.SelectString);
                    }
                    while (4 == 0);
                    this.cmbLocation.SelectedValue = "0";
                IL_5A:;
                }
                catch (Exception serviceException)
                {
                    if (6 != 0)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
            }
        }

        private void btnManageRole_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UserPermission userPermission = new UserPermission();
                if (5 != 0)
                {
                    List<RoleInfo> list = (from o in new RolePermissionsBusniess().GetChildUserData(LoginUser.RoleId)
                                           where o.DG_User_Roles_pkey != LoginUser.RoleId
                                           select o).ToList<RoleInfo>();
                    if (list != null)
                    {
                        do
                        {
                            userPermission.Show();
                        }
                        while (false || 6 == 0);
                    }
                    else
                    {
                        if (!false)
                        {
                            MessageBox.Show(UIConstant.NotAuthorized);
                            goto IL_7F;
                        }
                        goto IL_6C;
                    }
                }
                base.Close();
            IL_6C:
            IL_7F:;
            }
            catch (Exception serviceException)
            {
                if (8 != 0)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    if (!false)
                    {
                    }
                }
            }
        }

        private void txtUserName_LostFocus(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                bool flag;
                if (!false)
                {
                    flag = (string.IsNullOrEmpty(this.txtUserName.Text.Trim()) || this.SPSearchCancel.Visibility != Visibility.Collapsed);
                }
                if (flag)
                {
                    return;
                }
                while (true)
                {
                    UserBusiness userBusiness = new UserBusiness();
                    List<UsersInfo> userDetailByUserId = userBusiness.GetUserDetailByUserId(0, this.txtUserName.Text, LoginUser.RoleId);
                    int arg_6F_0;
                    int expr_64 = arg_6F_0 = userDetailByUserId.Count;
                    if (5 != 0)
                    {
                        arg_6F_0 = ((expr_64 == 0) ? 1 : 0);
                    }
                    flag = (arg_6F_0 != 0);
                    if (flag)
                    {
                        return;
                    }
                    if (false)
                    {
                        break;
                    }
                    if (5 != 0 && !false)
                    {
                        goto Block_6;
                    }
                }
            }
        Block_6:
            MessageBox.Show(UIConstant.UsernameAlreadyExists);
        }

        //private void btn_Click(object sender, RoutedEventArgs e)
        //{
        //    new Button();
        //    Button button = (Button)sender;
        //    string text = button.Content.ToString();
        //    if (text == null)
        //    {
        //        goto IL_19D;
        //    }
        //    if (text == "ENTER")
        //    {
        //        this.KeyBorder.Visibility = Visibility.Collapsed;
        //        this.controlon.Focus();
        //        return;
        //    }
        //    int num;
        //    int arg_B5_0;
        //    if (!(text == "SPACE"))
        //    {
        //        if (text == "CLOSE")
        //        {
        //            this.KeyBorder.Visibility = Visibility.Collapsed;
        //            return;
        //        }
        //        if (!(text == "Back"))
        //        {
        //            goto IL_19D;
        //        }
        //        if (this.controlon.Text.Length > 0 && this.controlon.SelectionStart > 0)
        //        {
        //            num = this.controlon.SelectionStart;
        //            this.controlon.Text = this.controlon.Text.Remove(this.controlon.SelectionStart - 1, 1);
        //            this.controlon.Select(num - 1, 0);
        //        }
        //        this.controlon.Focus();
        //        return;
        //    }
        //    else
        //    {
        //        if (this.controlon.SelectionStart < 0)
        //        {
        //            goto IL_F6;
        //        }
        //        arg_B5_0 = this.controlon.SelectionStart;
        //    }
        //IL_B5:
        //    num = arg_B5_0;
        //    do
        //    {
        //        this.controlon.Text = this.controlon.Text.Insert(this.controlon.SelectionStart, " ");
        //    }
        //    while (6 == 0);
        //    this.controlon.Select(num + 1, 0);
        //IL_F6:
        //    this.controlon.Focus();
        //    return;
        //IL_19D:
        //    bool flag = this.controlon.SelectionStart < 0;
        //    bool expr_1AD = (arg_B5_0 = (flag ? 1 : 0)) != 0;
        //    if (2 == 0)
        //    {
        //        goto IL_B5;
        //    }
        //    if (!expr_1AD)
        //    {
        //        num = this.controlon.SelectionStart;
        //        this.controlon.Text = this.controlon.Text.Insert(this.controlon.SelectionStart, button.Content.ToString());
        //        this.controlon.Select(num + 1, 0);
        //    }
        //    this.controlon.Focus();
        //}

        private void Window_Loaded(object sender, RoutedEventArgs e)
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

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new List<RoleInfo>();
                Button button = (Button)sender;
                this.userId = button.Tag.ToInt32(false);
                UserBusiness userBusiness = new UserBusiness();
                UsersInfo usersInfo = new UsersInfo();
                usersInfo = userBusiness.GetUsersInfoDataById(button.Tag.ToInt32(false));//, null, LoginUser.RoleId);
                if (usersInfo != null)
                {
                    this.txtFName.Text = usersInfo.DG_User_First_Name;
                    this.txtLName.Text = usersInfo.DG_User_Last_Name;
                    this.txtEmail.Text = usersInfo.DG_User_Email;
                    this.txtUserName.Text = usersInfo.DG_User_Name;
                    this.txtPassword.Password = PhotoSW.CryptorEngine.Decrypt(usersInfo.DG_User_Password, true);
                    this.txtMobileNumber.Text = usersInfo.DG_User_PhoneNo;
                    if (usersInfo.DG_User_Roles_Id == LoginUser.RoleId)
                    {
                        List<RoleInfo> oList = new RolePermissionsBusniess().GetChildUserData(LoginUser.RoleId);
                        CommonUtility.BindComboWithSelect<RoleInfo>(this.cmbRoleName, oList, "DG_User_Role", "DG_User_Roles_pkey", 0, ClientConstant.SelectString);
                        this.cmbRoleName.SelectedValue = LoginUser.RoleId;
                    }
                    else
                    {
                        List<RoleInfo> oList = (from o in new RolePermissionsBusniess().GetChildUserData(LoginUser.RoleId)
                                                where o.DG_User_Roles_pkey != LoginUser.RoleId
                                                select o).ToList<RoleInfo>();
                        CommonUtility.BindComboWithSelect<RoleInfo>(this.cmbRoleName, oList, "DG_User_Role", "DG_User_Roles_pkey", 0, ClientConstant.SelectString);
                        this.cmbRoleName.SelectedValue = usersInfo.DG_User_Roles_Id.ToString();
                    }
                    this.cmbStatus.SelectedValue = ((usersInfo.DG_User_Status == true) ? "1" : "2");
                    this.cmbStoreName.SelectedValue = usersInfo.DG_Store_ID.ToString();
                    this._email = usersInfo.DG_User_Email;
                    this._password = PhotoSW.CryptorEngine.Decrypt(usersInfo.DG_User_Password, true);
                    this._roleName = this.cmbRoleName.Text;
                    this._firstname = usersInfo.DG_User_First_Name;
                    this._username = usersInfo.DG_User_Name;
                    this._lastname = usersInfo.DG_User_Last_Name;
                    this._storename = this.cmbStoreName.Text;
                    this._location = this.cmbLocation.Text;
                    this._status = this.cmbStatus.Text;
                    this.txtUserName.IsEnabled = false;
                    this.txtPassword.IsEnabled = true;

                    LocationBusniess locationBusniess = new LocationBusniess();
                    List<LocationInfo> ItemsSource = locationBusniess.GetLocationNameDir(Convert.ToInt32(this.cmbStoreName.SelectedValue));
                    CommonUtility.BindComboWithSelect<LocationInfo>(this.cmbLocation, ItemsSource, "DG_Location_Name", "DG_Location_pkey", 0, ClientConstant.SelectString);
                    this.cmbLocation.SelectedValue = usersInfo.DG_Location_pkey;
                    
                    this._location = this.cmbLocation.Text;
                    this.Add_EditUser.Visibility = Visibility.Visible;
                    this.SPSearchCancel.Visibility = Visibility.Collapsed;
                    this.SPSubmitCancel.Visibility = Visibility.Visible;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                if (!false)
                {
                    try
                    {
                        Button expr_0A = (Button)sender;
                        Button button;
                        if (-1 != 0)
                        {
                            button = expr_0A;
                        }
                        MessageBox.Show(button.Tag.ToString());
                        UserBusiness expr_B4 = new UserBusiness();
                        UserBusiness userBusiness;
                        if (!false)
                        {
                            userBusiness = expr_B4;
                        }
                        int arg_7A_0;
                        int arg_56_0;
                        int expr_48 = arg_56_0 = (arg_7A_0 = (userBusiness.DeleteUsers(button.Tag.ToInt32(false)) ? 1 : 0));
                        int arg_7A_1;
                        if (!false)
                        {
                            int expr_51 = arg_7A_1 = 0;
                            if (expr_51 != 0)
                            {
                                goto IL_75;
                            }
                            arg_56_0 = ((expr_48 == expr_51) ? 1 : 0);
                        }
                        if (arg_56_0 != 0)
                        {
                            goto IL_81;
                        }
                        MessageBox.Show(UIConstant.UserDeleted);
                        CustomBusineses customBusineses = new CustomBusineses();
                        arg_7A_0 = LoginUser.UserId;
                        arg_7A_1 = 20;
                    IL_75:
                        AuditLog.AddUserLog(arg_7A_0, arg_7A_1, "Delete user at:- ");
                    IL_81:;
                    }
                    catch (Exception serviceException)
                    {
                        string message;
                        while (true)
                        {
                            while (true)
                            {
                                message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                if (!false)
                                {
                                    if (!false)
                                    {
                                        goto Block_7;
                                    }
                                }
                            }
                        }
                    Block_7:
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
            }
            while (4 == 0);
        }

        private void btnSearchUser_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (5 != 0)
                {
                    new List<RoleInfo>();
                    if (!false)
                    {
                        List<RoleInfo> childUserData = new RolePermissionsBusniess().GetChildUserData(LoginUser.RoleId);
                        if (!false)
                        {
                            if (4 == 0)
                            {
                                goto IL_C2;
                            }
                            CommonUtility.BindComboWithSelect<RoleInfo>(this.cmbRoleName, childUserData, "DG_User_Role", "DG_User_Roles_pkey", 0, ClientConstant.SelectString);
                            this.cmbRoleName.SelectedValue = "0";
                            this.SPSearchCancel.Visibility = Visibility.Visible;
                        }
                        this.SPSubmitCancel.Visibility = Visibility.Collapsed;
                        if (!false)
                        {
                            this.grdUsers.Visibility = Visibility.Visible;
                            this.Add_EditUser.Visibility = Visibility.Visible;
                            this.txtUserName.IsEnabled = true;
                            this.txtPassword.IsEnabled = false;
                            this.ClearControls();
                        }
                    IL_C2:;
                    }
                }
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

        private void btnAddUsers_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new List<RoleInfo>();
                List<RoleInfo> oList = (from o in new RolePermissionsBusniess().GetChildUserData(LoginUser.RoleId)
                                        where o.DG_User_Roles_pkey != LoginUser.RoleId
                                        select o).ToList<RoleInfo>();
                CommonUtility.BindComboWithSelect<RoleInfo>(this.cmbRoleName, oList, "DG_User_Role", "DG_User_Roles_pkey", 0, ClientConstant.SelectString);
                this.cmbRoleName.SelectedValue = "0";
                this.userId = 0;
                this.txtUserName.IsEnabled = true;
                this.txtPassword.IsEnabled = true;
                this.SPSearchCancel.Visibility = Visibility.Collapsed;
                this.SPSubmitCancel.Visibility = Visibility.Visible;
                this.Add_EditUser.Visibility = Visibility.Visible;
                this.ClearControls();
                this.btnSubmit.IsDefault = true;
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                }
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                do
                {
                    UserBusiness useBiz;
                    string uniqueSynccode;
                    bool flag;
                    do
                    {
                        UserBusiness expr_94 = new UserBusiness();
                        if (!false)
                        {
                            useBiz = expr_94;
                        }
                        uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.User).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                        flag = this.ControlValidation();
                    }
                    while (false);
                    bool flag2 = !flag;
                    do
                    {
                        if (!flag2)
                        {
                            flag2 = !this.ValidateUserInfo();
                            if (flag2)
                            {
                                goto IL_7E;
                            }
                        }
                        else
                        {
                            MessageBox.Show(UIConstant.PleaseCheckAllEnteredInformation);
                            if (5 != 0)
                            {
                                goto IL_91;
                            }
                        }
                        this.UserSaveAndUpdate(useBiz, uniqueSynccode);
                    }
                    while (-1 == 0);
                }
                while (!false && -1 == 0);
            IL_7E:
            IL_91:;
            }
            catch (Exception serviceException)
            {
                do
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (false);
            }
        }

        private bool ValidateUserInfo()
        {
            bool result = true;
            Regex expr_1A0 = new Regex("^[0-9]+$");
            Regex regex;
            if (!false)
            {
                regex = expr_1A0;
            }
            if (Regex.IsMatch(this.txtEmail.Text, "^[a-zA-Z][\\w\\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\\w\\.-]*[a-zA-Z0-9]\\.[a-zA-Z][a-zA-Z\\.]*[a-zA-Z]$"))
            {
                if (!false)
                {
                    if (!regex.IsMatch(this.txtMobileNumber.Text))
                    {
                        MessageBox.Show(UIConstant.MobileNumberNumeric);
                        this.txtMobileNumber.Focus();
                        result = false;
                        if (!false)
                        {
                        }
                    }
                    else
                    {
                        if (this.txtPassword.Password == "")
                        {
                            MessageBox.Show(UIConstant.EmptyPassword);
                            goto IL_CC;
                        }
                        int arg_F1_0 = this.txtPassword.Password.Length;
                        while (arg_F1_0 >= 6)
                        {
                            int arg_135_0;
                            int expr_128 = arg_135_0 = this.txtPassword.Password.Length;
                            int arg_135_1;
                            int expr_12F = arg_135_1 = 12;
                            if (expr_12F != 0)
                            {
                                arg_135_0 = ((expr_128 > expr_12F) ? 1 : 0);
                                arg_135_1 = 0;
                            }
                            if (arg_135_0 != arg_135_1)
                            {
                                MessageBox.Show(UIConstant.MaximumPassword);
                                this.txtPassword.Focus();
                                result = false;
                                goto IL_155;
                            }
                            if (Regex.IsMatch(this.txtPassword.Password, "\r\n    # Match string having one letter and one digit (min).\r\n    \\A                        # Anchor to start of string.\r\n      (?=[^0-9]*[0-9])        # at least one number and\r\n      (?=[^A-Za-z]*[A-Za-z])  # at least one letter.\r\n      \\w+                     # Match string of alphanums.\r\n    \\Z                        # Anchor to end of string.\r\n    ", RegexOptions.IgnorePatternWhitespace))
                            {
                                return result;
                            }
                            MessageBox.Show(UIConstant.AlphanumericPassword);
                            this.txtPassword.Focus();
                            int expr_18C = arg_F1_0 = 0;
                            if (expr_18C == 0)
                            {
                                result = (expr_18C != 0);
                                goto IL_193;
                            }
                        }
                        MessageBox.Show(UIConstant.MinimunPassword);
                        if (!false)
                        {
                            this.txtPassword.Focus();
                            result = false;
                        }
                    }
                IL_193:;
                }
            IL_155:
                return result;
            }
            MessageBox.Show(UIConstant.ValidEmail);
            this.txtEmail.Focus();
            result = false;
            while (!false)
            {
                if (!false)
                {
                    return result;
                }
            }
        IL_CC:
            this.txtPassword.Focus();
            result = false;
            return result;
        }

        private void UserSaveAndUpdate(UserBusiness useBiz, string SyncCode)
        {
            //if (this.userId == 0)
            if (true)
            {
                List<UsersInfo> userDetailByUserId = useBiz.GetUserDetailByUserId(0, this.txtUserName.Text, LoginUser.RoleId);
                if (userDetailByUserId.Count != 0)
                {
                    MessageBox.Show(UIConstant.UsernameAlreadyExists);
                }
                else
                {
                    bool? dG_User_Status;
                    if (this.cmbStatus.SelectedValue.ToString() == "1")
                    {
                        dG_User_Status = new bool?(true);
                    }
                    else
                    {
                        dG_User_Status = new bool?(false);
                    }
                    string LocationName = this.cmbLocation.Text;
                    string UserRole = this.cmbRoleName.Text;
                    bool flag = useBiz.AddUpdateUserDetails(this.userId, this.txtUserName.Text, this.txtFName.Text, this.txtLName.Text, PhotoSW.CryptorEngine.Encrypt(this.txtPassword.Password, true), this.cmbRoleName.SelectedValue.ToInt32(false), this.cmbLocation.SelectedValue.ToInt32(false), dG_User_Status, this.txtMobileNumber.Text, this.txtEmail.Text, SyncCode, LocationName, UserRole, Convert.ToInt32(this.cmbStoreName.SelectedValue), Convert.ToInt32(this.cmbLocation.SelectedValue));
                    if (flag)
                    {
                        string description = this.checkTempar();
                        this.ClearControls();
                        this.BindGrid();
                        this.Add_EditUser.Visibility = Visibility.Collapsed;
                        MessageBox.Show(UIConstant.RecordSavedSuccessfully);

                        CustomBusineses customBusineses = new CustomBusineses();
                        // AuditLog.AddUserLog(LoginUser.UserId, 19, "Add user data at:- ");
                        this.btnSubmit.IsDefault = false;
                        this.LoadSearchPhotographer();
                    }
                    else
                    {
                        MessageBox.Show(UIConstant.Error);
                    }
                }
            }
            else
            {
                UsersInfo usersInfo = useBiz.GetUserDetailByUserId(this.userId, null, LoginUser.RoleId).FirstOrDefault<UsersInfo>();
                bool flag;
                if (usersInfo.DG_User_Name != this.txtUserName.Text.Trim())
                {
                    List<UsersInfo> userDetailByUserId2 = useBiz.GetUserDetailByUserId(0, this.txtUserName.Text, LoginUser.RoleId);
                    if (userDetailByUserId2 != null)
                    {
                        MessageBox.Show(UIConstant.UsernameAlreadyExists);
                        goto IL_328;
                    }
                    bool? dG_User_Status;
                    if (this.cmbStatus.SelectedValue.ToString() == "1")
                    {
                        dG_User_Status = new bool?(true);
                    }
                    else
                    {
                        dG_User_Status = new bool?(false);
                    }

                    string LocationName = this.cmbLocation.Text;
                    string UserRole = this.cmbRoleName.Text;

                    flag = useBiz.AddUpdateUserDetails(this.userId, this.txtUserName.Text, this.txtFName.Text, this.txtLName.Text, PhotoSW.CryptorEngine.Encrypt(this.txtPassword.Password, true), this.cmbRoleName.SelectedValue.ToInt32(false), this.cmbLocation.SelectedValue.ToInt32(false), dG_User_Status, this.txtMobileNumber.Text, this.txtEmail.Text, SyncCode, LocationName, UserRole, Convert.ToInt32(this.cmbStoreName.SelectedValue), Convert.ToInt32(this.cmbLocation.SelectedValue));
                }
                else
                {
                    bool? dG_User_Status;
                    if (this.cmbStatus.SelectedValue.ToString() == "1")
                    {
                        dG_User_Status = new bool?(true);
                    }
                    else
                    {
                        dG_User_Status = new bool?(false);
                    }

                    string LocationName = this.cmbLocation.Text;
                    string UserRole = this.cmbRoleName.Text;

                    flag = useBiz.AddUpdateUserDetails(this.userId, this.txtUserName.Text, this.txtFName.Text, this.txtLName.Text, PhotoSW.CryptorEngine.Encrypt(this.txtPassword.Password, true), this.cmbRoleName.SelectedValue.ToInt32(false), this.cmbLocation.SelectedValue.ToInt32(false), dG_User_Status, this.txtMobileNumber.Text, this.txtEmail.Text, SyncCode, LocationName, UserRole, Convert.ToInt32(this.cmbStoreName.SelectedValue), Convert.ToInt32(this.cmbLocation.SelectedValue));
                    if (flag)
                    {
                        string description = this.checkTempar();
                        this.ClearControls();
                        this.BindGrid();
                        this.Add_EditUser.Visibility = Visibility.Collapsed;
                        MessageBox.Show(UIConstant.RecordSuccessfullyUpdated);
                        //  AuditLog.AddUserLog(LoginUser.UserId, 19, description);
                        this.btnSubmit.IsDefault = false;
                        this.LoadSearchPhotographer();
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }
                    if (!false)
                    {
                        goto IL_450;
                    }
                }
                if (flag)
                {
                    string description = this.checkTempar();
                    this.ClearControls();
                    this.BindGrid();
                    this.Add_EditUser.Visibility = Visibility.Collapsed;
                    MessageBox.Show(UIConstant.RecordSuccessfullyUpdated);
                    //   AuditLog.AddUserLog(LoginUser.UserId, 19, description);
                    this.btnSubmit.IsDefault = false;
                    this.LoadSearchPhotographer();
                }
                else
                {
                    MessageBox.Show(UIConstant.Error);
                }
            IL_328:
            IL_450:;
            }
        }

        private void btnSubmitCancel_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    this.ClearControls();
                    do
                    {
                        this.Add_EditUser.Visibility = Visibility.Collapsed;
                        this.grdUsers.Visibility = Visibility.Visible;
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

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            UserBusiness userBusiness = new UserBusiness();
            try
            {
                bool arg_CE_0;
                if (string.IsNullOrEmpty(this.txtFName.Text) && string.IsNullOrEmpty(this.txtLName.Text))
                {
                    if (false)
                    {
                        goto IL_29C;
                    }
                    if (string.IsNullOrEmpty(this.txtEmail.Text))
                    {
                        if (false)
                        {
                            goto IL_249;
                        }
                        if (string.IsNullOrEmpty(this.txtMobileNumber.Text) && this.cmbRoleName.SelectedValue.ToString() == "0")
                        {
                            if (false)
                            {
                                goto IL_D3;
                            }
                            if (this.cmbStatus.SelectedValue.ToString() == "0")
                            {
                                arg_CE_0 = !(this.cmbStoreName.SelectedValue.ToString() == "0");
                                goto IL_CD;
                            }
                        }
                    }
                }
                arg_CE_0 = true;
            IL_CD:
                if (arg_CE_0)
                {
                    if (LoginUser.RoleId == 7)
                    {
                        this.grdUsers.ItemsSource = userBusiness.SearchUserDetails(this.txtFName.Text, this.txtLName.Text, this.cmbStoreName.SelectedValue.ToInt32(false), Convert.ToString(this.cmbStatus.SelectedValue), this.cmbRoleName.SelectedValue.ToInt32(false), this.txtMobileNumber.Text, this.txtEmail.Text, this.cmbLocation.SelectedValue.ToInt32(false), this.txtUserName.Text);
                        goto IL_24A;
                    }
                    this.grdUsers.ItemsSource = from t in userBusiness.SearchUserDetails(this.txtFName.Text, this.txtLName.Text, this.cmbStoreName.SelectedValue.ToInt32(false), Convert.ToString(this.cmbStatus.SelectedValue), this.cmbRoleName.SelectedValue.ToInt32(false), this.txtMobileNumber.Text, this.txtEmail.Text, this.cmbLocation.SelectedValue.ToInt32(false), this.txtUserName.Text)
                                                where t.DG_User_Roles_Id != 7
                                                select t;
                    goto IL_249;
                }
            IL_D3:
                this.grdUsers.ItemsSource = userBusiness.GetUserDetailByUserId(0, null, LoginUser.RoleId);
            IL_249:
            IL_24A:
                if (this.grdUsers.Items.Count <= 0)
                {
                    this.grdUsers.ItemsSource = null;
                    MessageBox.Show(UIConstant.NoResultFound);
                    //this.grdUsers.ItemsSource = userBusiness.GetUserDetailByUserId(0, null, LoginUser.RoleId);
                    this.grdUsers.ItemsSource = userBusiness.GetChildUserDetailByUserId(LoginUser.RoleId);
                }
                this.userId = 0;
            IL_29C:
                this.SPSearchCancel.Visibility = Visibility.Visible;
                this.SPSubmitCancel.Visibility = Visibility.Collapsed;
                this.Add_EditUser.Visibility = Visibility.Collapsed;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnSearchCancel_Click(object sender, RoutedEventArgs e)
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
            this.Add_EditUser.Visibility = Visibility.Collapsed;
        IL_11:
            if (!false)
            {
                this.grdUsers.Visibility = Visibility.Visible;
            }
        IL_20:
            if (!false)
            {
                return;
            }
            goto IL_04;
        }

        private void txtFName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (-1 != 0)
            {
                try
                {
                    if (5 != 0)
                    {
                        TextBox textBox = (TextBox)sender;
                        this.controlon = textBox;
                        //   bool arg_27_0 = this.KeyBorder.Visibility == Visibility.Collapsed;
                        //    bool expr_27;
                        //do
                        //{
                        //    expr_27 = (arg_27_0 = !arg_27_0);
                        //}
                        //while (false);
                        //  bool flag = expr_27;

                        //if (!false)
                        //{
                        //    if (!flag)
                        //    {
                        //        this.KeyBorder.Visibility = Visibility.Visible;
                        //    }
                        //}
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    do
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (2 == 0);
                }
            }
        }

        private void cmbStoreName_GotFocus(object sender, RoutedEventArgs e)
        {
            // this.KeyBorder.Visibility = Visibility.Collapsed;
            //this.cmbStoreName.SelectedValue = LoginUser.StoreId;
            //this.cmbStoreName.IsEnabled = false;
            //this.cmbStoreName.SelectedValue = "0";
            int storeId = this.cmbStoreName.SelectedValue.ToInt32(false);
            LocationBusniess locationBusniess = new LocationBusniess();
            if (storeId > 0)
            {
                List<LocationInfo> LocationInfolist = locationBusniess.GetLocationList(storeId <= 0 ? 0 : storeId);
                CommonUtility.BindComboWithSelect<LocationInfo>(this.cmbLocation, LocationInfolist, "DG_Location_Name", "DG_Location_pkey", 0, ClientConstant.SelectString);


                this.cmbLocation.SelectedValue = "0";
            }

        }

        private void btnSearchPhoto_Copy_Click(object sender, RoutedEventArgs e)
        {
            ManageHome manageHome = new ManageHome();
            manageHome.Show();
            base.Close();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                new CustomBusineses();
                if (7 == 0)
                {
                }
                int arg_42_0 = LoginUser.UserId;
                //do
                //{
                //    arg_42_0 = (AuditLog.AddUserLog(arg_42_0, 39, "Logged out at ") ? 1 : 0);
                //}
                //while (-1 == 0);
                Login login = new Login();
                if (!true)
                {
                    return;
                }
                login.Show();
            }
            while (false)
            {
            }
            base.Close();
        }

        private void LoadSearchPhotographer()
        {
            SearchByPhoto searchByPhoto;
            bool flag;
            if (7 != 0)
            {
                if (false)
                {
                    goto IL_44;
                }
                if (5 == 0)
                {
                    goto IL_45;
                }
                searchByPhoto = (from Window wnd in Application.Current.Windows
                                 where wnd.Title == "Search"
                                 select wnd).Cast<SearchByPhoto>().FirstOrDefault<SearchByPhoto>();
                if (false)
                {
                    return;
                }
                flag = (searchByPhoto == null);
            }
            if (flag)
            {
                return;
            }
        IL_44:
        IL_45:
            searchByPhoto.LoadPhotoGrapher();
        }

        /*   void IStyleConnector.Connect(int connectionId, object target)
           {
               while (true)
               {
                   int arg_16_0 = connectionId;
                   if (false)
                   {
                       goto IL_16;
                   }
                   if (4 != 0)
                   {
                       arg_16_0 = connectionId - 11;
                       goto IL_16;
                   }
               IL_5A:
                   if (!false)
                   {
                       if (true)
                       {
                           break;
                       }
                       continue;
                   }
               IL_23:
                   goto IL_5A;
               IL_16:
                   switch (arg_16_0)
                   {
                       case 0:
                           ((Button)target).Click += new RoutedEventHandler(this.btnEdit_Click);
                           break;
                       case 1:
                           if (!false)
                           {
                               ((Button)target).Click += new RoutedEventHandler(this.btnDelete_Click);
                           }
                           break;
                   }
                   goto IL_23;
               }
           }
       */
    }
}
