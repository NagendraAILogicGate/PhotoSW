using AVT.VmbAPINET;
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
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using PhotoSW.Views;
using PhotoSW.PSControls;
using PhotoSW.IMIX.Business;
using PhotoSW.DataLayer;

namespace PhotoSW.Manage
{
    public partial class ManageCamera : Window, IComponentConnector, IStyleConnector
    {
        private DeviceManager objDeviceMgr = null;

        private Dictionary<string, string> lstPhotographerList;

        public int CameraId = 0;

        public int _CameraId = 0;

        private Dictionary<string, int> _locationList;

        private List<DeviceInfo> deviceInforList = null;

        private Dictionary<string, string> lstSubStore;

        private Vimba system = new Vimba();

        private CameraCollection cameras;

       

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

        public ManageCamera()
        {
            try
            {
                this.InitializeComponent();
                this.chkIsTripCam.IsEnabled = false;
                this.btnSave.Tag = "0";
                this.GetCameraData();
                this.FillPhotographerCombo();
                this.FillSubstore();
                this.cmbSubStore.SelectedValue = LoginUser.SubStoreId.ToString();
                this.FillLocationBysubstore();
                this.FillCharacter();
                this.txbUserName.Text = LoginUser.UserName;
                this.txbStoreName.Text = LoginUser.StoreName;
                this.btnSave.IsDefault = true;
                this.lstDevice.Visibility = Visibility.Visible;
                this.tbDevice.Visibility = Visibility.Visible;
                this.GetDevice();
                this.MsgBox.SetParent(this.myBorder);
                this.GetCameras();
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login;
            do
            {
                int arg_2F_0 = LoginUser.UserId;
                do
                {
                    arg_2F_0 = (AuditLog.AddUserLog(arg_2F_0, 39, "Logged out at") ? 1 : 0);
                }
                while (2 == 0 || false);
                login = new Login();
            }
            while (false);
            login.Show();
            do
            {
                base.Close();
            }
            while (8 == 0);
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int cameraId = ((Button)sender).Tag.ToInt32(false);
                CameraBusiness cameraBusiness = new CameraBusiness();
                CameraInfo cameraByID = cameraBusiness.GetCameraByID(((Button)sender).Tag.ToInt32(false));
                this.btnSave.Tag = cameraByID.DG_Camera_ID.Value;
                this.CameraId = cameraByID.DG_Camera_pkey;
                this._CameraId = cameraByID.DG_Camera_ID.Value;
                List<UsersInfo> userDetailsByUserIddetail;
                do
                {
                    this.txtCameraName.Text = cameraByID.DG_Camera_Name;
                    this.txtCameraMake.Text = cameraByID.DG_Camera_Make;
                    this.txtCameraModel.Text = cameraByID.DG_Camera_Model;
                    this.txtPhotoSeries.Text = cameraByID.DG_Camera_Start_Series.ToString();
                    this.cmbPhotoGraphers.SelectedValue = cameraByID.DG_AssignTo.ToString();
                    this.chkIsChromaColor.IsChecked = cameraByID.IsChromaColor;
                    this.chkIsTripCam.IsChecked = cameraByID.IsTripCam;
                    this.txtCameraSerialNumber.Text = cameraByID.SerialNo;
                    if (cameraByID.IsTripCam.Value)
                    {
                        if (this.cmbTripCamModels.Items.Contains(cameraByID.DG_Camera_Model))
                        {
                            this.cmbTripCamModels.Text = cameraByID.DG_Camera_Model.Trim();
                        }
                        else
                        {
                            this.cmbTripCamModels.SelectedIndex = 0;
                        }
                        this.cmbTripCamModels.IsEnabled = true;
                    }
                    this.chkIsLiveStream.IsChecked = cameraByID.IsLiveStream;
                    this.cmbCharacter.SelectedValue = ((!cameraByID.CharacterId.HasValue) ? "0" : cameraByID.CharacterId.ToString());
                    UserBusiness userBusiness = new UserBusiness();
                    userDetailsByUserIddetail = userBusiness.GetUserDetailsByUserIddetail(this.cmbPhotoGraphers.SelectedValue.ToInt32(false));
                    this.cmbSubStore.SelectedValue = userDetailsByUserIddetail.FirstOrDefault<UsersInfo>().DG_Substore_ID;
                }
                while (!true);
                this.cmbStore_SelectionChanged(null, null);
                this.cmbLocation.SelectedValue = userDetailsByUserIddetail.FirstOrDefault<UsersInfo>().DG_Location_pkey;
                this.txtPhotoSeries.Focus();
                this.BindCameraDeviceAssociation(cameraId);
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void BindCameraDeviceAssociation(int cameraId)
        {
            this.objDeviceMgr = new DeviceManager();
            List<CameraDeviceAssociationInfo> cameraDeviceList = this.objDeviceMgr.GetCameraDeviceList(this._CameraId);
            int num;
            if (!false)
            {
                num = 0;
                goto IL_181;
            }
        IL_C3:
            int num2;
            CheckBox checkBox;
            int arg_DF_0;
            if (num2 != this.lstDevice.Items.Count)
            {
                arg_DF_0 = ((checkBox == null) ? 1 : 0);
            }
            else
            {
                arg_DF_0 = 0;
            }
        IL_DB:
            if (arg_DF_0 == 0)
            {
                goto IL_F2;
            }
        IL_E8:
            DependencyObject dependencyObject;
            int arg_12E_0;
            int arg_12E_1;
            if (checkBox == null)
            {
                this.lstDevice.ScrollIntoView(this.lstDevice.Items[num2]);
                checkBox = ManageCamera.FindVisualChild<CheckBox>(dependencyObject);
                int expr_B7 = arg_DF_0 = (arg_12E_0 = num2);
                if (-1 == 0)
                {
                    goto IL_DB;
                }
                int expr_BD = arg_12E_1 = 1;
                if (expr_BD != 0)
                {
                    num2 = expr_B7 + expr_BD;
                    goto IL_C3;
                }
                goto IL_12E;
            }
        IL_F2:
            bool arg_134_0;
            if (checkBox == null)
            {
                arg_134_0 = true;
                goto IL_133;
            }
            int arg_17F_0 = arg_12E_0 = ((from o in cameraDeviceList
                                          select o.DeviceId).Contains((int)Convert.ToInt16(checkBox.Tag)) ? 1 : 0);
            if (false)
            {
                goto IL_17E;
            }
            arg_12E_1 = 0;
        IL_12E:
            arg_134_0 = (arg_12E_0 == arg_12E_1);
        IL_133:
            if (!arg_134_0)
            {
                checkBox.IsChecked = new bool?(true);
                this.lstDevice.ScrollIntoView(this.lstDevice.Items[num]);
            }
            else
            {
                checkBox.IsChecked = new bool?(false);
            }
            if (false)
            {
                goto IL_F2;
            }
        IL_17C:
            arg_17F_0 = num;
        IL_17E:
            num = arg_17F_0 + 1;
        IL_181:
            if (num >= this.lstDevice.Items.Count)
            {
                return;
            }
            this.lstDevice.ScrollIntoView(this.lstDevice.Items[num]);
            dependencyObject = this.lstDevice.ItemContainerGenerator.ContainerFromIndex(num);
            if (dependencyObject != null)
            {
                checkBox = ManageCamera.FindVisualChild<CheckBox>(dependencyObject);
                num2 = 0;
                goto IL_E8;
            }
            goto IL_17C;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                while (true)
                {
                    bool expr_16 = MessageBox.Show("Do you want to delete this camera?", "Confirm delete", MessageBoxButton.YesNo) != MessageBoxResult.Yes;
                    bool flag;
                    if (!false)
                    {
                        flag = expr_16;
                    }
                    if (flag)
                    {
                        goto IL_A5;
                    }
                    CameraBusiness cameraBusiness = new CameraBusiness();
                    string text = cameraBusiness.DeleteCameraDetails((int)((Button)sender).Tag.ToInt16(false));
                    while (true)
                    {
                        if (false)
                        {
                            goto IL_8F;
                        }
                        flag = string.IsNullOrWhiteSpace(text);
                        if (flag)
                        {
                            goto IL_8F;
                        }
                        DirectoryInfo directoryInfo = new DirectoryInfo(text);
                    IL_6B:
                        flag = !directoryInfo.Exists;
                        if (!flag)
                        {
                            if (-1 == 0)
                            {
                                continue;
                            }
                            if (!false)
                            {
                                if (-1 == 0)
                                {
                                    break;
                                }
                                directoryInfo.Delete(true);
                            }
                        }
                    IL_8F:
                        MessageBox.Show("Camera deleted successfully");
                        if (5 != 0)
                        {
                            goto Block_8;
                        }
                        goto IL_6B;
                    }
                }
            Block_8:
                this.GetCameraData();
            IL_A5: ;
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.objDeviceMgr = new DeviceManager();
                string selectedDevices = this.GetSelectedDevices();
                bool expr_2B = !this.Isvalidated();
                bool flag;
                int num3 = 0;
                if (-1 != 0)
                {
                    flag = expr_2B;
                }
                if (!flag)
                {
                    ConfigBusiness configBusiness = new ConfigBusiness();
                    FolderStructureInfo folderStructureInfo = new FolderStructureInfo();
                    folderStructureInfo = configBusiness.GetFolderStructureInfo(Convert.ToInt32(this.cmbSubStore.SelectedValue));
                    try
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(folderStructureInfo.HotFolderPath, "Camera"));
                    }
                    catch (Exception serviceException)
                    {
                        MessageBox.Show("Please check the permission on folder.There is some problem while creating folder.");
                        return;
                    }
                    flag = !(selectedDevices != "");
                    if (flag)
                    {
                        goto IL_D4;
                    }
                IL_A4:
                    flag = this.CheckSingleDevice(selectedDevices);
                    if (-1 == 0)
                    {
                        goto IL_F0;
                    }
                    if (!flag)
                    {
                        if (8 != 0)
                        {
                            this.MsgBox.ShowHandlerDialog("Please select a single device", DigiMessageBox.DialogType.OK);
                            return;
                        }
                        goto IL_3A4;
                    }
                IL_D4:
                    flag = !this.objDeviceMgr.IsDeviceAssociatedToOthers(this._CameraId, selectedDevices);
                    if (flag)
                    {
                        goto IL_115;
                    }
                IL_F0:
                    string message = "The device(s) you have selected are already associated with other camera. Do you want to re-associate with this camera?";
                    bool flag2 = this.MsgBox.ShowHandlerDialog(message, DigiMessageBox.DialogType.Confirm);
                    flag = flag2;
                    if (!flag)
                    {
                        return;
                    }
                IL_115:
                    string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Camera).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                    CameraBusiness cameraBusiness = new CameraBusiness();
                    CameraInfo cameraInfo;
                    if (-1 != 0)
                    {
                        cameraInfo = new CameraInfo();
                        cameraInfo.DG_Camera_Name = this.txtCameraName.Text;
                        cameraInfo.DG_Camera_Make = this.txtCameraMake.Text;
                    }
                    cameraInfo.DG_Camera_Model = this.txtCameraModel.Text;
                    cameraInfo.DG_Camera_Start_Series = this.txtPhotoSeries.Text;
                    cameraInfo.DG_Camera_ID = new int?(this.CameraId);
                    cameraInfo.DG_AssignTo = new int?(this.cmbPhotoGraphers.SelectedValue.ToInt32(false));
                    cameraInfo.DG_Updatedby = LoginUser.UserId;
                IL_1E2:
                    cameraInfo.DG_Location_ID = this.cmbLocation.SelectedValue.ToInt32(false);
                    cameraInfo.SyncCode = uniqueSynccode;
                    cameraInfo.IsSynced = false;
                    cameraInfo.IsChromaColor = this.chkIsChromaColor.IsChecked;
                    cameraInfo.IsLiveStream = this.chkIsLiveStream.IsChecked;
                    cameraInfo.IsTripCam = this.chkIsTripCam.IsChecked;
                    cameraInfo.SubStoreId = this.cmbSubStore.SelectedValue.ToInt32(false);
                    cameraInfo.SerialNo = this.txtCameraSerialNumber.Text;
                    CustomBusineses customBusineses = new CustomBusineses();
                    cameraInfo.DG_UpdatedDate = DateTime.Now;
                    int num = 0;
                    cameraBusiness.SetCameraDetails(cameraInfo);
                    num = cameraInfo.CameraId;
                    bool arg_2AC_0 = this._CameraId != 0;
                IL_2AC:
                    flag = arg_2AC_0;
                    int num2;
                    if (!flag)
                    {
                        num2 = cameraInfo.DG_Camera_pkey;
                    }
                    else
                    {
                        num2 = this._CameraId;
                    }
                    int arg_3AA_0;
                    int arg_3AA_1;
                    bool arg_2FE_0;
                    if (cameraInfo.IsTripCam == true)
                    {
                        int expr_2E9 = arg_3AA_0 = this.CameraId;
                        int expr_2EF = arg_3AA_1 = 0;
                        if (expr_2EF != 0)
                        {
                            goto IL_3AA;
                        }
                        arg_2FE_0 = (expr_2E9 <= expr_2EF);
                    }
                    else
                    {
                        arg_2FE_0 = true;
                    }
                    flag = arg_2FE_0;
                    if (!flag)
                    {
                        int cameraId = this.CameraId;
                        int newCamid = num2;
                        TripCamBusiness tripCamBusiness = new TripCamBusiness();
                        tripCamBusiness.UpdCamIdForTripCamPOSMapping(cameraId, newCamid);
                    }
                    bool flag3 = this.objDeviceMgr.SaveCameraDeviceAssociation(num2, selectedDevices);
                 
                    flag = !(selectedDevices != "");
                    if (!flag)
                    {
                        num3 = this.objDeviceMgr.DeleteCameraDeviceSyncDetails(num2, selectedDevices);
                    }
                    flag = (this.cmbCharacter.SelectedIndex <= 0);
                    if (!flag)
                    {
                        this.objDeviceMgr.SaveCameraCharacterAssociation(this.CameraId, cameraInfo.DG_Camera_pkey, new int?(this.cmbCharacter.SelectedValue.ToInt32(false)));
                    }
                IL_3A4:
                    arg_3AA_0 = ((num > 0) ? 1 : 0);
                    arg_3AA_1 = 0;
                IL_3AA:
                    flag = (arg_3AA_0 == arg_3AA_1);
                    if (!flag)
                    {
                        flag = (num3 <= 0);
                        if (!flag)
                        {
                            MessageBox.Show("Camera details saved successfully.\n Please Sync your camera and mobile device.");
                        }
                        else
                        {
                            if (7 == 0)
                            {
                                goto IL_D4;
                            }
                            MessageBox.Show("Camera details saved successfully");
                        }
                        DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(folderStructureInfo.HotFolderPath, "Camera", "C" + num));
                        flag = directoryInfo.Exists;
                        if (!flag)
                        {
                            directoryInfo.Create();
                        }
                        if (false)
                        {
                            goto IL_1E2;
                        }
                        flag = !(this.chkIsTripCam.IsChecked == true);
                        if (!flag)
                        {
                            DirectoryInfo directoryInfo2 = new DirectoryInfo(Path.Combine(folderStructureInfo.HotFolderPath, "Camera", "RideC" + num));
                            flag = directoryInfo2.Exists;
                            if (6 == 0)
                            {
                                goto IL_A4;
                            }
                            if (!flag)
                            {
                                directoryInfo2.Create();
                            }
                            DirectoryInfo directoryInfo3 = new DirectoryInfo(Path.Combine(folderStructureInfo.HotFolderPath, "Camera", "RideC" + num, "marketing"));
                            bool expr_4C6 = arg_2AC_0 = directoryInfo3.Exists;
                            if (false)
                            {
                                goto IL_2AC;
                            }
                            flag = expr_4C6;
                            if (!flag)
                            {
                                if (8 == 0)
                                {
                                    goto IL_507;
                                }
                                directoryInfo3.Create();
                            }
                            DirectoryInfo directoryInfo4 = new DirectoryInfo(Path.Combine(folderStructureInfo.HotFolderPath, "Camera", "RideCamera"));
                            flag = directoryInfo4.Exists;
                        IL_507:
                            if (!flag)
                            {
                                directoryInfo4.Create();
                            }
                            DirectoryInfo directoryInfo5 = new DirectoryInfo(Path.Combine(folderStructureInfo.HotFolderPath, "Camera", "RideCamera", "marketing"));
                            flag = directoryInfo5.Exists;
                            if (!flag)
                            {
                                directoryInfo5.Create();
                            }
                        }
                        this.GetCameraData();
                        this.ClearControls();
                    }
                }
                else
                {
                    MessageBox.Show("Please check all the mandatory fields .");
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private bool CheckSingleDevice(string DeviceID)
        {
            string[] array = DeviceID.Split(new char[]
			{
				','
			});
            bool result;
            if (!false)
            {
                int arg_1D_0 = array.Length;
                bool expr_5D;
                do
                {
                    int arg_1F_0 = arg_1D_0;
                    int arg_1F_1 = 1;
                    int expr_1F;
                    int expr_22;
                    do
                    {
                        expr_1F = (arg_1F_0 = ((arg_1F_0 > arg_1F_1) ? 1 : 0));
                        expr_22 = (arg_1F_1 = 0);
                    }
                    while (expr_22 != 0);
                    bool flag = expr_1F == expr_22;
                    if (7 == 0)
                    {
                        goto IL_3A;
                    }
                    expr_5D = ((arg_1D_0 = (flag ? 1 : 0)) != 0);
                }
                while (8 == 0);
                if (!expr_5D)
                {
                    result = false;
                    return result;
                }
                result = true;
            IL_3A:
                if (!false)
                {
                }
            }
            return result;
        }

        private string GetSelectedDevices()
        {
            string result;
            try
            {
                string text = string.Empty;
                int num = 0;
                while (true)
                {
                IL_12:
                    while (true)
                    {
                        int arg_B7_0 = num;
                        int arg_B7_1 = this.lstDevice.Items.Count;
                        while (true)
                        {
                            DependencyObject dependencyObject;
                            bool flag;
                            if (arg_B7_0 < arg_B7_1)
                            {
                                dependencyObject = this.lstDevice.ItemContainerGenerator.ContainerFromIndex(num);
                                flag = (dependencyObject == null);
                                goto IL_43;
                            }
                            int arg_78_0;
                            bool expr_C9 = (arg_78_0 = (arg_B7_0 = ((text.Length > 0) ? 1 : 0))) != 0;
                            if (!false)
                            {
                                flag = !expr_C9;
                                goto IL_D3;
                            }
                        IL_73:
                            int expr_75 = arg_B7_1 = 0;
                            bool arg_7E_0;
                            if (expr_75 == 0)
                            {
                                arg_7E_0 = (arg_78_0 == expr_75);
                                goto IL_7D;
                            }
                            continue;
                        IL_6D:
                            goto IL_73;
                        IL_43:
                            CheckBox checkBox;
                            if (!flag)
                            {
                                checkBox = ManageCamera.FindVisualChild<CheckBox>(dependencyObject);
                                if (checkBox == null)
                                {
                                    arg_7E_0 = true;
                                    goto IL_7D;
                                }
                                bool? isChecked = checkBox.IsChecked;
                                if (5 == 0)
                                {
                                    goto IL_D3;
                                }
                                if (isChecked.GetValueOrDefault())
                                {
                                    arg_B7_0 = (arg_78_0 = (isChecked.HasValue ? 1 : 0));
                                    goto IL_6D;
                                }
                                if (-1 != 0)
                                {
                                    arg_B7_0 = (arg_78_0 = 0);
                                    goto IL_73;
                                }
                                goto IL_12;
                            }
                        IL_9E:
                            if (!false)
                            {
                                break;
                            }
                            goto IL_43;
                        IL_9D:
                            goto IL_9E;
                        IL_84:
                            text = text + "," + checkBox.Tag.ToString();
                            goto IL_9D;
                        IL_D3:
                            if (!flag)
                            {
                                text = text.Remove(0, 1);
                            }
                            result = text;
                            if (true)
                            {
                                goto Block_12;
                            }
                            goto IL_84;
                        IL_7D:
                            flag = arg_7E_0;
                            if (!flag)
                            {
                                goto IL_84;
                            }
                            goto IL_9D;
                        }
                        num++;
                    }
                }
            Block_12: ;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
                result = string.Empty;
            }
            return result;
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
                            childItem childItem1 = ManageCamera.FindVisualChild<childItem>(dependencyObject);
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
                            childItem childItem1 = ManageCamera.FindVisualChild<childItem>(dependencyObject);
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

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (8 != 0)
                    {
                        this.ClearControls();
                    }
                IL_09:
                    if (false)
                    {
                        goto IL_09;
                    }
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
            while (false);
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!false)
                {
                    ManageHome manageHome = new ManageHome();
                    manageHome.Show();
                    if (!false)
                    {
                        this.system.Shutdown();
                        base.Close();
                    }
                }
            }
            catch (Exception serviceException)
            {
                if (4 != 0)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
        }

        private void GetDevice()
        {
            int num;
            if (2 != 0)
            {
                this.lstDevice.Items.Clear();
                this.deviceInforList = new List<DeviceInfo>();
                DeviceManager deviceManager = new DeviceManager();
                this.deviceInforList = (from o in deviceManager.GetDeviceList()
                                        where o.IsActive
                                        select o).ToList<DeviceInfo>();
                this.deviceInforList.ForEach(delegate(DeviceInfo o)
                {
                    do
                    {
                        if (true && !false)
                        {
                            o.Name = o.Name + "(" + o.SerialNo + ")";
                        }
                    }
                    while (!false && 8 == 0);
                });
                this.lstDevice.ItemsSource = this.deviceInforList;
                if (false)
                {
                    goto IL_D6;
                }
                if (!false)
                {
                    num = 0;
                    goto IL_DF;
                }
                goto IL_F3;
            }
        IL_B9:
            this.lstDevice.ScrollIntoView(this.lstDevice.Items[num]);
        IL_D6:
        IL_D7:
            int arg_F2_0;
            int expr_D8 = arg_F2_0 = num;
            if (false)
            {
                goto IL_F2;
            }
            num = expr_D8 + 1;
        IL_DF:
            int arg_F0_0 = num;
        IL_E0:
            arg_F2_0 = ((arg_F0_0 < this.lstDevice.Items.Count) ? 1 : 0);
        IL_F2:
            bool flag = arg_F2_0 != 0;
        IL_F3:
            bool expr_F3 = (arg_F0_0 = (flag ? 1 : 0)) != 0;
            if (false)
            {
                goto IL_E0;
            }
            if (expr_F3)
            {
                goto IL_B9;
            }
            if (true)
            {
                return;
            }
            goto IL_D7;
        }

        private void GetCameraData()
        {
            CameraBusiness cameraBusiness = new CameraBusiness();
            this.DGManageCamrea.ItemsSource = cameraBusiness.GetCameraList();
        }

        private void FillPhotographerCombo()
        {
            if (8 == 0)
            {
                goto IL_2F;
            }
            this.lstPhotographerList = new Dictionary<string, string>();
        IL_13:
            if (!false)
            {
                this.lstPhotographerList.Add("0", "--Select--");
            }
        IL_2F:
            if (8 != 0)
            {
                try
                {
                    UserBusiness userBusiness = new UserBusiness();
                    foreach (UserInfo current in userBusiness.GetPhotoGrapher())
                    {
                        do
                        {
                            this.lstPhotographerList.Add(current.UserId.ToString(), current.Photographer + " (" + current.UserName + ")");
                        }
                        while (false);
                    }
                    this.cmbPhotoGraphers.ItemsSource = this.lstPhotographerList;
                    do
                    {
                        this.cmbPhotoGraphers.SelectedValue = "0";
                    }
                    while (5 == 0);
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                    while (false)
                    {
                    }
                }
                return;
            }
            goto IL_13;
        }

        private void FillPhotographerLocation()
        {
            this.cmbLocation.ItemsSource = null;
            if (-1 != 0)
            {
                this.LocationList = new Dictionary<string, int>();
                if (!false)
                {
                    while (true)
                    {
                        new List<LocationInfo>();
                        LocationBusniess locationBusniess = new LocationBusniess();
                        int storeId = LoginUser.StoreId;
                        List<LocationInfo> locationName = locationBusniess.GetLocationName(storeId);
                        if (locationName == null)
                        {
                            this.LocationList = new Dictionary<string, int>();
                            goto IL_E7;
                        }
                        this.LocationList = new Dictionary<string, int>();
                        if (6 != 0)
                        {
                            if (!false)
                            {
                                this.LocationList.Add("--Select--", 0);
                                using (List<LocationInfo>.Enumerator enumerator = locationName.GetEnumerator())
                                {
                                    while (true)
                                    {
                                        while (enumerator.MoveNext())
                                        {
                                            LocationInfo current = enumerator.Current;
                                            this.LocationList.Add(current.DG_Location_Name, current.DG_Location_pkey);
                                            if (!false)
                                            {
                                            }
                                        }
                                        break;
                                    }
                                }
                                goto IL_D6;
                            }
                            goto IL_10B;
                        }
                    }
                    return;
                }
            IL_E7:
                this.LocationList.Add("--Select--", 0);
            }
        IL_D6:
            this.cmbLocation.ItemsSource = this.LocationList;
        IL_10B:
            this.cmbLocation.SelectedValue = "0";
        }

        private void FillLocationBysubstore()
        {
            int substoreId;
            List<LocationInfo> oList;
            if (7 != 0)
            {
                if (false)
                {
                    goto IL_26;
                }
                int expr_5F = Convert.ToInt32(this.cmbSubStore.SelectedValue);
                if (!false)
                {
                    substoreId = expr_5F;
                }
                oList = new List<LocationInfo>();
            }
            oList = new StoreSubStoreDataBusniess().GetSelectedLocationsSubstore(substoreId).ToList<LocationInfo>();
        IL_26:
            CommonUtility.BindComboWithSelect<LocationInfo>(this.cmbLocation, oList, "DG_Location_Name", "DG_Location_pkey", 0, ClientConstant.SelectString);
            this.cmbLocation.SelectedValue = "0";
        }

        private void FillCharacter()
        {
            do
            {
                new List<CharacterInfo>();
            }
            while (false);
            List<CharacterInfo> oList = new CharacterBusiness().GetCharacter().ToList<CharacterInfo>();
            do
            {
                CommonUtility.BindComboWithSelect<CharacterInfo>(this.cmbCharacter, oList, "DG_Character_Name", "DG_Character_Pkey", 0, ClientConstant.SelectString);
            }
            while (3 == 0);
            if (!false)
            {
                this.cmbCharacter.SelectedValue = "0";
            }
        }

        private void ClearControls()
        {
            this.txtCameraSerialNumber.Text = string.Empty;
            this.txtCameraMake.Text = string.Empty;
            this.txtCameraModel.Text = string.Empty;
            this.txtCameraName.Text = string.Empty;
            this.txtPhotoSeries.Text = string.Empty;
            while (true)
            {
            IL_69:
                this.cmbPhotoGraphers.SelectedValue = "0";
                this.cmbSubStore.SelectedValue = "0";
                this.cmbLocation.SelectedValue = "0";
                while (8 != 0)
                {
                    this.cmbCharacter.SelectedValue = "0";
                    if (false)
                    {
                        goto IL_112;
                    }
                    this.CameraId = 0;
                    if (false)
                    {
                        break;
                    }
                    this.chkIsChromaColor.IsChecked = new bool?(false);
                    this.chkIsTripCam.IsChecked = new bool?(false);
                    this.cmbTripCamModels.SelectedIndex = 0;
                    if (false)
                    {
                        goto IL_69;
                    }
                    this.chkIsLiveStream.IsChecked = new bool?(false);
                    if (!false)
                    {
                        goto Block_5;
                    }
                }
                goto IL_14C;
            }
        Block_5:
            int num = 0;
        IL_112:
            goto IL_155;
        IL_14C:
        IL_14D:
            int arg_153_0;
            int arg_169_0 = arg_153_0 = num;
            if (8 == 0)
            {
                goto IL_156;
            }
            int arg_153_1 = 1;
        IL_153:
            num = arg_153_0 + arg_153_1;
        IL_155:
            arg_169_0 = (arg_153_0 = num);
        IL_156:
            int expr_161 = arg_153_1 = this.lstDevice.Items.Count;
            if (false)
            {
                goto IL_153;
            }
            if (arg_169_0 >= expr_161)
            {
                return;
            }
            DependencyObject dependencyObject = this.lstDevice.ItemContainerGenerator.ContainerFromIndex(num);
            if (dependencyObject == null)
            {
                goto IL_14D;
            }
            CheckBox checkBox = ManageCamera.FindVisualChild<CheckBox>(dependencyObject);
            if (checkBox != null)
            {
                checkBox.IsChecked = new bool?(false);
                goto IL_14C;
            }
            goto IL_14C;
        }

        private bool Isvalidated()
        {
            bool result = false;
            bool flag;
            bool flag2;
            int arg_171_0;
            if (2 != 0)
            {
                flag = true;
                flag2 = !(this.txtCameraName.Text.Trim() == "");
                if (!flag2)
                {
                    arg_171_0 = 0;
                    goto IL_3C;
                }
                goto IL_42;
            }
            do
            {
            IL_104:
                if (!flag2)
                {
                    if (4 == 0)
                    {
                        goto IL_D9;
                    }
                    flag = false;
                }
                try
                {
                    this.txtPhotoSeries.Text.ToInt64(false);
                }
                catch (Exception)
                {
                    flag = false;
                }
            }
            while (false);
             result = flag;
            if (!false)
            {
                return result;
            }
            goto IL_BB;
        IL_3C:
            flag = (arg_171_0 != 0);
        IL_42:
            flag2 = !(this.txtCameraModel.Text.Trim() == "");
            int arg_B1_0;
            if (!flag2)
            {
                do
                {
                    int expr_69 = arg_B1_0 = 0;
                    if (expr_69 != 0)
                    {
                        goto IL_B0;
                    }
                    flag = (expr_69 != 0);
                }
                while (false);
            }
            flag2 = !(this.txtPhotoSeries.Text.Trim() == "");
            if (!flag2)
            {
                flag = false;
            }
            arg_B1_0 = ((this.txtCameraMake.Text.Trim() == "") ? 1 : 0);
        IL_B0:
            flag2 = (arg_B1_0 == 0);
            if (!flag2)
            {
                flag = false;
            }
        IL_BB:
            flag2 = !(this.cmbPhotoGraphers.SelectedValue.ToString() == "0");
        IL_D9:
            if (!flag2)
            {
                int expr_DE = arg_171_0 = 0;
                if (expr_DE != 0)
                {
                    goto IL_3C;
                }
                flag = (expr_DE != 0);
            }
            flag2 = !(this.cmbLocation.SelectedValue.ToString() == "0");
            return flag2;
            //goto IL_104;
        }

        private void FillSubstore()
        {
            try
            {
                do
                {
                    List<SubStoresInfo> allSubstoreName = new StoreSubStoreDataBusniess().GetAllSubstoreName();
                    CommonUtility.BindComboWithSelect<SubStoresInfo>(this.cmbSubStore, allSubstoreName, "DG_SubStore_Name", "DG_SubStore_pkey", 0, ClientConstant.SelectString);
                    if (-1 != 0 && !false)
                    {
                        this.cmbSubStore.SelectedValue = LoginUser.SubStoreId.ToString();
                    }
                }
                while (6 == 0);
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
            if (5 != 0)
            {
            }
        }

        private void cmbStore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.FillLocationBysubstore();
        }

        private void txtnumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text;
            do
            {
                text = string.Empty;
            }
            while (false);
            if (string.IsNullOrEmpty(((TextBox)sender).Text))
            {
                string arg_107_0 = string.Empty;
            }
            else
            {
                double num = 0.0;
                if (true)
                {
                    bool flag = double.TryParse(((TextBox)sender).Text, out num);
                    bool arg_7F_0 = flag;
                    bool arg_7F_1;
                    bool expr_74 = arg_7F_1 = (num < 0.0);
                    if (!false && !false)
                    {
                        arg_7F_1 = !expr_74;
                    }
                    if (!(arg_7F_0 & arg_7F_1))
                    {
                        goto IL_A9;
                    }
                }
                ((TextBox)sender).Text.Trim();
                text = ((TextBox)sender).Text;
                goto IL_D6;
            IL_A9:
                ((TextBox)sender).Text = text;
                if (3 == 0)
                {
                    return;
                }
                ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            IL_D6:
                if (false)
                {
                    goto IL_A9;
                }
            }
        }

        private void NumericOnly(object sender, TextCompositionEventArgs e)
        {
            e.Handled = ManageCamera.IsTextNumeric(e.Text);
        }

        private static bool IsTextNumeric(string str)
        {
            Regex regex;
            do
            {
                if (true)
                {
                    if (3 == 0)
                    {
                        goto IL_20;
                    }
                    regex = new Regex("[^0-9]");
                }
            }
            while (false);
            bool arg_22_0;
            bool expr_33 = arg_22_0 = regex.IsMatch(str);
            if (false)
            {
                return arg_22_0;
            }
            bool flag = expr_33;
        IL_20:
            arg_22_0 = flag;
            return arg_22_0;
        }

        private void chkIsTripCam_Click(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            bool? isChecked = checkBox.IsChecked;
            if (2 == 0)
            {
                goto IL_77;
            }
            int arg_3D_0;
            if (isChecked.GetValueOrDefault())
            {
                arg_3D_0 = (isChecked.HasValue ? 1 : 0);
            }
            else
            {
                arg_3D_0 = 0;
            }
        IL_32:
            if (6 == 0 || !true)
            {
                goto IL_32;
            }
            if (arg_3D_0 == 0)
            {
                this.cmbTripCamModels.SelectedIndex = 0;
                goto IL_8B;
            }
        IL_4B:
            this.txtCameraModel.Text = "";
            this.cmbTripCamModels.IsEnabled = true;
            this.txtCameraModel.IsEnabled = false;
        IL_77:
            if (!false)
            {
                return;
            }
        IL_8B:
            this.txtCameraModel.Text = "";
            if (false)
            {
                goto IL_4B;
            }
            this.cmbTripCamModels.IsEnabled = false;
            this.txtCameraModel.IsEnabled = true;
        }

        private void GetCameras()
        {
            try
            {
                if (3 != 0)
                {
                    this.cmbTripCamModels.Items.Add("--Select--");
                    this.system.Startup();
                    this.cameras = this.system.Cameras;
                    bool arg_6C_0;
                    if (this.cameras == null)
                    {
                        arg_6C_0 = true;
                        goto IL_6B;
                    }
                IL_57:
                    arg_6C_0 = (this.cameras.Count <= 0);
                IL_6B:
                    if (!arg_6C_0)
                    {
                        //using (IEnumerator enumerator = this.cameras.GetEnumerator())
                        IEnumerator enumerator = this.cameras.GetEnumerator();
                        try
                        {
                            while (true)
                            {
                                if (-1 != 0)
                                {
                                    if (!enumerator.MoveNext())
                                    {
                                        break;
                                    }
                                    Camera camera = (Camera)enumerator.Current;
                                    if (6 != 0)
                                    {
                                        this.cmbTripCamModels.Items.Add(camera.Id);
                                    }
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            throw ex;
                        }
                    }
                    if (6 == 0)
                    {
                        goto IL_57;
                    }
                    if (this.cmbTripCamModels.Items.Count <= 1)
                    {
                        goto IL_116;
                    }
                }
                this.chkIsTripCam.IsEnabled = true;
                if (!false)
                {
                    this.cmbTripCamModels.IsEnabled = true;
                }
            IL_116: ;
            }
            catch (Exception ex)
            {
                bool flag = this.cmbTripCamModels.Items.Count > 1;
                bool arg_179_0 = flag;
                bool expr_1A7;
                do
                {
                    if (!arg_179_0)
                    {
                        this.chkIsTripCam.IsEnabled = false;
                        this.cmbTripCamModels.IsEnabled = false;
                    }
                    flag = (((VimbaException)ex).ReturnCode == -16);
                    expr_1A7 = (arg_179_0 = flag);
                }
                while (false);
                if (!expr_1A7)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
            if (7 != 0)
            {
            }
        }

        private void cmbTripCamModels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int arg_14_0;
            int expr_51 = arg_14_0 = this.cmbTripCamModels.SelectedIndex;
            int arg_14_1;
            if (true)
            {
                int expr_0E = arg_14_1 = 0;
                if (expr_0E != 0)
                {
                    goto IL_14;
                }
                arg_14_0 = ((expr_51 > expr_0E) ? 1 : 0);
            }
        IL_13:
            arg_14_1 = 0;
        IL_14:
            bool expr_14 = (arg_14_0 = ((arg_14_0 == arg_14_1) ? 1 : 0)) != 0;
            if (-1 != 0)
            {
                bool flag = expr_14;
                while (true)
                {
                    if (!flag)
                    {
                        if (8 != 0)
                        {
                            break;
                        }
                    }
                    else
                    {
                        this.txtCameraModel.Text = "";
                    }
                    if (4 != 0)
                    {
                        return;
                    }
                }
                this.txtCameraModel.Text = this.cmbTripCamModels.SelectedValue.ToString();
                return;
            }
            goto IL_13;
        }

        private void DetectCameraSerial(object sender, RoutedEventArgs e)
        {
            try
            {
                App app = (App)Application.Current;
                bool arg_42_0;
                bool arg_2B_0;
                bool expr_AC = arg_2B_0 = (arg_42_0 = app.IsCameraConnected);
                if (!true)
                {
                    goto IL_3F;
                }
                bool flag = !expr_AC;
                arg_2B_0 = flag;
            IL_2B:
                if (arg_2B_0)
                {
                    MessageBox.Show("Please either connect a Camera to fetch it's serial number or manually enter the serial number.");
                    ErrorHandler.ErrorHandler.LogFileWrite("Camera is not connected");
                    goto IL_93;
                }
                flag = string.IsNullOrEmpty(app.CameraSerialNumber);
                arg_42_0 = (arg_2B_0 = flag);
            IL_3F:
                if (5 == 0)
                {
                    goto IL_2B;
                }
                if (arg_42_0 && 6 != 0)
                {
                    MessageBox.Show("Please either connect a Camera to fetch it's serial number or manually enter the serial number.");
                    ErrorHandler.ErrorHandler.LogFileWrite("Unable to fetch Camera serial number");
                }
                else
                {
                    this.txtCameraSerialNumber.Text = app.CameraSerialNumber;
                    if (!false)
                    {
                    }
                }
            IL_93: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            do
            {
                if (!false)
                {
                }
            }
            while (3 == 0);
        }

       
        void IStyleConnector.Connect(int connectionId, object target)
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
                    arg_16_0 = connectionId - 14;
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
    }
}
