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
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using PhotoSW.Views;
using PhotoSW.DataLayer;

namespace PhotoSW.Manage
{
    public partial class UserPermission : Window, IComponentConnector, IStyleConnector
    {
        private List<RoleInfo> _objRoleList;

        private List<PermisiionList> _objPerList;

        private int _roleId = 0;

       
        public UserPermission()
        {
            this.InitializeComponent();
            this.GetRoledata();
            this.GetDropdownData();
            this.txtUserRole.Text = string.Empty;
            this._roleId = 0;
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Role).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                if (!string.IsNullOrEmpty(this.txtUserRole.Text))
                {
                    if (!true)
                    {
                        goto IL_C5;
                    }
                }
                else
                {
                    MessageBox.Show("Please enter the Role.");
                    if (!false)
                    {
                        new SolidColorBrush(Colors.Red);
                        goto IL_12E;
                    }
                }
                int arg_E3_0;
                if (4 != 0)
                {
                    RolePermissionsBusniess rolePermissionsBusniess = new  RolePermissionsBusniess();
                    new SolidColorBrush(Colors.Gray);
                    int RolePkey = String.IsNullOrEmpty(this.hdnRole.Text) ?0: Convert.ToInt32(this.hdnRole.Text);
                    bool a = rolePermissionsBusniess.AddUpdateRoleData(RolePkey, this._roleId, this.txtUserRole.Text, uniqueSynccode, LoginUser.RoleId);
                    bool expr_94 = (arg_E3_0 = ((a) ? 1 : 0)) != 0;
                    if (false)
                    {
                        goto IL_DC;
                    }
                    if (expr_94)
                    {
                        this.GetRoledata();
                        this.GetDropdownData();
                    }
                    else
                    {
                        //if (a == "Duplicate")
                        //{
                            MessageBox.Show("Record already exists!");
                            goto IL_10D;
                        //}
                       // goto IL_10D;
                    }
                }
                this.txtUserRole.Text = string.Empty;
            IL_C5:
                this._roleId = 0;
                MessageBox.Show("Record saved successfully!");
                this.hdnRole.Text = string.Empty;
                arg_E3_0 = LoginUser.UserId;
            IL_DC:
                AuditLog.AddUserLog(arg_E3_0, 54, "Role Add/Edit at ");
            IL_10D:
            IL_10E:
            IL_12E:
                if (-1 == 0)
                {
                    goto IL_10E;
                }
                
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
                this.hdnRole.Text = string.Empty;
            }
        }

        private void btnRoleEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button button = (Button)sender;
                this._roleId = button.CommandParameter.ToInt32(false);
                this.hdnRole.Text = this._roleId.ToString();
                this.txtUserRole.Text = (from t in this._objRoleList
                                         where t.DG_User_Roles_pkey == this._roleId
                                         select t).FirstOrDefault<RoleInfo>().DG_User_Role;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void btnRoleDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Do you want to delete this role?", "Confirm delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    Button button = (Button)sender;
                    this._roleId = button.CommandParameter.ToInt32(false);
                    RolePermissionsBusniess rolePermissionsBusniess = new RolePermissionsBusniess();
                    //AuditLog.AddUserLog(LoginUser.UserId, 23, "Deleted Role-" + rolePermissionsBusniess.GetRoleName(this._roleId));
                    if (rolePermissionsBusniess.DeleteRoleData(this._roleId))
                    {
                        this.GetRoledata();
                        this.GetDropdownData();
                        this.txtUserRole.Text = string.Empty;
                        this._roleId = 0;
                    }
                    else
                    {
                        MessageBox.Show("Reocrd is in use");
                    }
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void GetRoledata()
        {
            RolePermissionsBusniess rolePermissionsBusniess = new RolePermissionsBusniess();
            try
            {
                while (true)
                {
                    do
                    {
                        new RolePermissionsBusniess();
                    }
                    while (4 == 0);
                    // this._objRoleList = (from o in new RolePermissionsBusniess().GetChildUserData(LoginUser.RoleId)
                    //where o.DG_User_Roles_pkey != LoginUser.RoleId
                    //select o).ToList<RoleInfo>();
                    this._objRoleList = rolePermissionsBusniess.GetChildUserData(LoginUser.RoleId);
                    this.grdUserRoles.ItemsSource = this._objRoleList;
                    while (!false)
                    {
                        if (!false)
                        {
                            return;
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }

        }

        private void GetDropdownData()
        {
            List<RoleInfo> list;
            if (2 != 0)
            {
                list = new List<RoleInfo>();
                List<RoleInfo> expr_56 = list;
                IEnumerable<RoleInfo> expr_0C = this._objRoleList;
                if (!false)
                {
                    expr_56.AddRange(expr_0C);
                }
            }
            while (true)
            {
                CommonUtility.BindComboWithSelect<RoleInfo>(this.cmbUserRole, list, "DG_User_Role", "DG_User_Roles_pkey", 0, ClientConstant.SelectString);
                while (4 != 0)
                {
                    this.cmbUserRole.SelectedValue = "0";
                    if (2 != 0)
                    {
                        return;
                    }
                }
            }
        }

        private void btnPermissionSave_Click(object sender, RoutedEventArgs e)
        {
            RolePermissionsBusniess rolePermissionsBusniess = new RolePermissionsBusniess();
            string arg_326_0 = string.Empty;
            string arg_32C_0 = string.Empty;
            try
            {
                if (this.cmbUserRole.SelectedValue.ToString() == "0")
                {
                    MessageBox.Show("Please select the Role");
                }
                else
                {
                    DataTable dataTable = new DataTable();
                    dataTable.Columns.Add("RoleId", typeof(string));
                    //dataTable.Columns.Add("PermissonRolePKey", typeof(string));
                    dataTable.Columns.Add("PermissonId", typeof(string));
                    dataTable.Columns.Add("IsAvailable", typeof(bool));
                    List<PermisiionList>.Enumerator enumerator = new List<PermisiionList>.Enumerator();
                    enumerator = this._objPerList.GetEnumerator();
                    bool flag;
                    try
                    {
                        if (!false)
                        {
                            string hdnPermissionPkeys = string.Empty;
                            while (true)
                            {
                                bool arg_147_0 = enumerator.MoveNext();
                                bool expr_149;
                                do
                                {
                                    flag = arg_147_0;
                                    expr_149 = (arg_147_0 = flag);
                                }
                                while (false);
                                if (!expr_149)
                                {
                                    break;
                                }
                                PermisiionList current = enumerator.Current;
                                DataRow dataRow = dataTable.NewRow();
                                dataRow["RoleId"] = this.cmbUserRole.SelectedValue.ToInt32(false);
                                //dataRow["PermissonRolePKey"] = this.hdnPermissionPkey.Text;
                                dataRow["PermissonId"] = current.PermissionId;
                                dataRow["IsAvailable"] = current.IsAvailable;
                                dataTable.Rows.Add(dataRow);
                            }
                        }
                    }
                    finally
                    {
                        if (7 != 0)
                        {
                            ((IDisposable)enumerator).Dispose();
                        }
                    }
                    string text = string.Join(",", from c in this._objPerList.Where(delegate(PermisiionList a)
                    {
                        bool? isAvailable = a.IsAvailable;
                        int arg_42_0;
                        if (!isAvailable.GetValueOrDefault())
                        {
                            arg_42_0 = 0;
                            goto IL_16;
                        }
                        arg_42_0 = (isAvailable.HasValue ? 1 : 0);
                    IL_10:
                        if (!false)
                        {
                        }
                    IL_16:
                        bool expr_45;
                        do
                        {
                            bool flag2 = arg_42_0 != 0;
                            if (!false)
                            {
                            }
                            expr_45 = ((arg_42_0 = (flag2 ? 1 : 0)) != 0);
                        }
                        while (8 == 0);
                        if (!false)
                        {
                            return expr_45;
                        }
                        goto IL_10;
                    })
                                                   select c.PermissionName);
                    string text2 = string.Join(",", from c in this._objPerList.Where(delegate(PermisiionList a)
                    {
                        bool? isAvailable = a.IsAvailable;
                        int arg_42_0;
                        if (isAvailable.GetValueOrDefault())
                        {
                            arg_42_0 = 0;
                            goto IL_16;
                        }
                        arg_42_0 = (isAvailable.HasValue ? 1 : 0);
                    IL_10:
                        if (!false)
                        {
                        }
                    IL_16:
                        bool expr_45;
                        do
                        {
                            bool flag2 = arg_42_0 != 0;
                            if (!false)
                            {
                            }
                            expr_45 = ((arg_42_0 = (flag2 ? 1 : 0)) != 0);
                        }
                        while (8 == 0);
                        if (!false)
                        {
                            return expr_45;
                        }
                        goto IL_10;
                    })
                                                    select c.PermissionName);
                    flag = !new RolePermissionsBusniess().SetremovePermissionData(dataTable);
                    if (8 != 0)
                    {
                        if (!flag)
                        {
                            if (!(text == string.Empty))
                            {
                               // AuditLog.AddUserLog(LoginUser.UserId, 24, "Added Permission- " + text + " to " + rolePermissionsBusniess.GetRoleName(this.cmbUserRole.SelectedValue.ToInt32(false)));
                            }
                            if (!(text2 == string.Empty))
                            {
                                //AuditLog.AddUserLog(LoginUser.UserId, 25, "Removed Permission- " + text2 + " from " + rolePermissionsBusniess.GetRoleName(this.cmbUserRole.SelectedValue.ToInt32(false)));
                            }
                            MessageBox.Show("Records updated successfully!");
                            this.GetPermissionDataforGridIsChecked(false, false);
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void cmbUserRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            do
            {
                if (2 != 0)
                {
                    try
                    {
                        while (true)
                        {
                            if (!false)
                            {
                                this.GetPermissionDataforGridIsChecked(false, false);
                                if (!false)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (false);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (!false)
                    {
                        AuditLog.AddUserLog(LoginUser.UserId, 39, "Logged out at ");
                        if (false)
                        {
                            goto IL_20;
                        }
                        Login login = new Login();
                        login.Show();
                    }
                    if (false)
                    {
                        goto IL_26;
                    }
                IL_20:
                    base.Close();
                IL_26: ;
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                    while (4 == 0);
                }
            }
            while (false);
        }

        private void btnback_Click(object sender, RoutedEventArgs e)
        {
            if (-1 != 0)
            {
                try
                {
                    AddEditUsers addEditUsers = new AddEditUsers();
                    addEditUsers.Show();
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

        private void chkALL_Checked(object sender, RoutedEventArgs e)
        {
            do
            {
                if (2 != 0)
                {
                    try
                    {
                        while (true)
                        {
                            if (!false)
                            {
                                this.GetPermissionDataforGridIsChecked(true, true);
                                if (!false)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (false);
        }

        private void chkALL_Unchecked(object sender, RoutedEventArgs e)
        {
            do
            {
                if (2 != 0)
                {
                    try
                    {
                        while (true)
                        {
                            if (!false)
                            {
                                this.GetPermissionDataforGridIsChecked(false, true);
                                if (!false)
                                {
                                    break;
                                }
                            }
                        }
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            while (false);
        }

        private void GetPermissionDataforGridIsChecked(bool isAllcheecked, bool isChecked)
        {
            
            RolePermissionsBusniess rolePermissionsBusniess = new RolePermissionsBusniess();
            this._objPerList = new List<PermisiionList>();
            List<PermissionRoleInfo> permissionData = rolePermissionsBusniess.GetPermissionData(this.cmbUserRole.SelectedValue.ToInt32(false));
            string permissionId = LoginUser.RoleId.ToString() + "," + this.cmbUserRole.SelectedValue;
            if (permissionData.Count == 0)
            {
                List<PermissionInfo> permissionNames = rolePermissionsBusniess.GetPermissionNames(permissionId, string.Empty);
                foreach (PermissionInfo current in permissionNames)
                {
                    PermisiionList permisiionList = new PermisiionList();
                    if (isChecked)
                    {
                        permisiionList.IsAvailable = new bool?(isAllcheecked);
                    }
                    else
                    {
                        permisiionList.IsAvailable = new bool?(false);
                    }
                    permisiionList.PermissionName = current.DG_Permission_Name;
                    permisiionList.PermissionId = current.DG_Permission_pkey;
                    this._objPerList.Add(permisiionList);
                }
            }
            else
            {
                List<PermissionInfo> permissionNames2 = rolePermissionsBusniess.GetPermissionNames(permissionId, string.Empty);
                List<int> list = (from t in permissionData
                                  select t.DG_Permission_Id).ToList<int>();
                foreach (PermissionInfo current in permissionNames2)
                {
                    PermisiionList permisiionList = new PermisiionList();
                    if (list.Contains(current.DG_Permission_pkey))
                    {
                        permisiionList.PermissionId = current.DG_Permission_pkey;
                        bool flag = !isChecked;
                        if (4 != 0)
                        {
                            if (!flag)
                            {
                                permisiionList.IsAvailable = new bool?(isAllcheecked);
                            }
                            else
                            {
                                permisiionList.IsAvailable = new bool?(true);
                            }
                        }
                    IL_1C4:
                        permisiionList.PermissionName = current.DG_Permission_Name;
                        goto IL_21E;
                        goto IL_1C4;
                    }
                    permisiionList.PermissionId = current.DG_Permission_pkey;
                    if (isChecked)
                    {
                        permisiionList.IsAvailable = new bool?(isAllcheecked);
                    }
                    else
                    {
                        permisiionList.IsAvailable = new bool?(false);
                    }
                    permisiionList.PermissionName = current.DG_Permission_Name;
                IL_21E:
                    this._objPerList.Add(permisiionList);
                }
            }
            this.grdPermission.ItemsSource = this._objPerList;
        }

        /*  void IStyleConnector.Connect(int connectionId, object target)
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
                        arg_16_0 = connectionId - 12;
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
                            ((Button)target).Click += new RoutedEventHandler(this.btnRoleEdit_Click);
                            break;
                        case 1:
                            if (!false)
                            {
                                ((Button)target).Click += new RoutedEventHandler(this.btnRoleDelete_Click);
                            }
                            break;
                    }
                    goto IL_23;
                }
            }
        */
    }
}
