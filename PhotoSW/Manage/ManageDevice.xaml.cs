using PhotoSW.Common;
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace PhotoSW.Manage
{
    public partial class ManageDevice : Window, IComponentConnector, IStyleConnector
    {
        private Dictionary<int, string> _deviceTypes = new Dictionary<int, string>();

        private DeviceManager _objDeviceBusiness = null;

        private List<DeviceInfo> _deviceList = null;


        public ManageDevice()
        {
            this.InitializeComponent();
            this.BindDeviceTypeCombo();
            this.btnSaveDevice.Tag = 0;
            this.GetDeviceData();
        }

        private void btnSaveDevice_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this._objDeviceBusiness = new DeviceManager();
                DeviceInfo deviceInfo = new DeviceInfo();
                bool? flag = this.chkIsActive.IsChecked;
                flag = ((!flag.HasValue) ? new bool?(false) : this.chkIsActive.IsChecked);
                bool value = flag.Value;
                int num = (int)((this.btnSaveDevice.Tag == null) ? 0 : this.btnSaveDevice.Tag);
                bool flag2 = this.IsValidEntry(num);
                if (false)
                {
                    goto IL_179;
                }
                if (!flag2)
                {
                    return;
                }
                deviceInfo.DeviceId = num;
                deviceInfo.Name = this.txtDeviceName.Text.Trim();
                deviceInfo.DeviceTypeId = (int)this.cmbDeviceType.SelectedValue;
            IL_CF:
                deviceInfo.SerialNo = this.txtDeviceSerialNo.Text.Trim();
            IL_E5:
                deviceInfo.BDA = this.txtDeviceBDA.Text.Trim();
                deviceInfo.CreatedBy = LoginUser.UserId;
                deviceInfo.IsActive = value;
                deviceInfo.CreatedDate = DateTime.Now;
            IL_11C:
                bool flag3 = this._objDeviceBusiness.SaveDevice(deviceInfo);
                if (flag3)
                {
                    if (num != 0)
                    {
                        MessageBox.Show(UIConstant.DeviceUpdatedSuccessfully);
                    }
                    else
                    {
                        if (3 == 0)
                        {
                            goto IL_E5;
                        }
                        MessageBox.Show(UIConstant.DeviceSavedSuccessfully);
                    }
                    this.ResetControls();
                    this.GetDeviceData();
                    while (3 == 0)
                    {
                    }
                }
                else
                {
                    MessageBox.Show(UIConstant.ProblemInUpdatingDevice);
                }
            IL_179:
                if (7 == 0)
                {
                    goto IL_CF;
                }
                if (2 == 0)
                {
                    goto IL_11C;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool IsValidEntry(int DeviceId)
        {
            bool result;
            if (!false)
            {
                bool flag = false;
                this._objDeviceBusiness = new DeviceManager();
                try
                {
                    bool arg_D3_0;
                    int expr_117 = (arg_D3_0 = string.IsNullOrEmpty(this.txtDeviceName.Text.Trim())) ? 1 : 0;
                    int arg_D3_1;
                    int expr_37 = arg_D3_1 = 0;
                    if (expr_37 != 0)
                    {
                        goto IL_D3;
                    }
                    bool flag2;
                    if (expr_117 != expr_37)
                    {
                        MessageBox.Show(UIConstant.PleaseEnterDeviceName);
                        flag = false;
                        if (3 != 0)
                        {
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(this.txtDeviceSerialNo.Text.Trim()))
                        {
                            flag2 = ((int)this.cmbDeviceType.SelectedValue > 0);
                            goto IL_A6;
                        }
                        MessageBox.Show(UIConstant.PleaseEnterDeviceSerialNumber);
                        flag = false;
                    }
                    goto IL_FA;
                IL_A6:
                    bool arg_A8_0 = flag2;
                IL_A8:
                    if (!arg_A8_0)
                    {
                        MessageBox.Show(UIConstant.PleaseSelectDeviceType);
                        flag = false;
                        goto IL_FA;
                    }
                    arg_D3_0 = this.IsDeviceExists(DeviceId, this.txtDeviceSerialNo.Text.Trim());
                    arg_D3_1 = 0;
                IL_D3:
                    flag2 = ((arg_D3_0 ? 1 : 0) == arg_D3_1);
                    bool expr_D7 = arg_A8_0 = flag2;
                    if (5 == 0)
                    {
                        goto IL_A8;
                    }
                    if (!expr_D7)
                    {
                        if (2 != 0)
                        {
                            MessageBox.Show(UIConstant.DeviceSerialNumberAlreadyExists);
                            if (false)
                            {
                                goto IL_A6;
                            }
                            flag = false;
                        }
                    }
                    else
                    {
                        flag = true;
                    }
                IL_FA: ;
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        flag = false;
                    }
                    while (6 == 0);
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                result = flag;
            }
            return result;
        }

        private bool IsDeviceExists(int DeviceId, string deviceNameOrSerialNo)
		{
			bool result;
			while (true)
			{
				//string deviceNameOrSerialNo;
				while (4 != 0)
				{
					if (false)
					{
						return result;
					}
					//deviceNameOrSerialNo = deviceNameOrSerialNo2;
					if (!false)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			try
			{
				do
				{
					if (!this._deviceList.Exists(delegate(DeviceInfo o)
					{
						bool result2=false;
						if (!false)
						{
							int arg_0E_0 = o.DeviceId;
							int arg_0E_1 = DeviceId;
							bool arg_56_0;
							while (arg_0E_0 != arg_0E_1)
							{
								int expr_4F = arg_0E_0 = string.Compare(o.SerialNo, deviceNameOrSerialNo, true);
								int expr_1F = arg_0E_1 = 0;
								if (expr_1F == 0)
								{
									arg_56_0 = (expr_4F == expr_1F);
									if (2 != 0)
									{
										IL_2A:;
									}
									result2 = arg_56_0;
									if (2 != 0)
									{
										return result2;
									}
									return result2;
								}
							}
							arg_56_0 = false;
							//goto IL_2A;
						}
						return result2;
					}))
					{
						goto IL_64;
					}
				}
				while (false);
				result = true;
				return result;
				IL_64:
				result = false;
			}
			catch
			{
				result = false;
			}
			return result;
		}

        private void BindDeviceTypeCombo()
        {
            do
            {
                try
                {
                    if (!false)
                    {
                        ValueTypeBusiness valueTypeBusiness = new ValueTypeBusiness();
                        List<ValueTypeInfo> reasonType = valueTypeBusiness.GetReasonType(7);
                        CommonUtility.BindComboWithSelect<ValueTypeInfo>(this.cmbDeviceType, reasonType, "Name", "ValueTypeId", 0, ClientConstant.SelectString);
                    }
                    do
                    {
                        this.cmbDeviceType.SelectedValue = "0";
                    }
                    while (false);
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
                    }
                    while (false);
                }
            }
            while (2 == 0);
        }

        private void GetDeviceData()
        {
            this._objDeviceBusiness = new DeviceManager();
            do
            {
                this._deviceList = new List<DeviceInfo>();
                if (false)
                {
                    return;
                }
                this._deviceList = this._objDeviceBusiness.GetDeviceList();
            }
            while (false);
            this.dgDevice.ItemsSource = this._deviceList;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DeviceInfo deviceInfo = (DeviceInfo)this.dgDevice.SelectedItem;
                if (true)
                {
                    if (!false)
                    {
                        this.txtDeviceName.Text = deviceInfo.Name;
                        this.txtDeviceSerialNo.Text = deviceInfo.SerialNo;
                        if (8 == 0)
                        {
                            goto IL_B8;
                        }
                        if (5 == 0)
                        {
                            goto IL_8E;
                        }
                        this.cmbDeviceType.SelectedValue = deviceInfo.DeviceTypeId;
                    }
                    if (false)
                    {
                        goto IL_A5;
                    }
                    this.chkIsActive.IsChecked = new bool?(deviceInfo.IsActive);
                IL_8E:
                    this.btnSaveDevice.Tag = deviceInfo.DeviceId;
                IL_A5:
                    this.txtDeviceBDA.Text = deviceInfo.BDA;
                IL_B8: ;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            while (3 == 0)
            {
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                while (-1 != 0)
                {
                    this._objDeviceBusiness = new DeviceManager();
                    bool arg_2B_0 = MessageBox.Show("Do you want to delete this device?", "Confirm delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
                    bool expr_2B;
                    do
                    {
                        expr_2B = (arg_2B_0 = !arg_2B_0);
                    }
                    while (!true);
                    if (!expr_2B)
                    {
                        bool arg_6E_0;
                        bool flag;
                        while (true)
                        {
                            bool expr_59 = arg_6E_0 = this._objDeviceBusiness.DeleteDevice(((Button)sender).Tag.ToInt32(false));
                            if (false)
                            {
                                break;
                            }
                            flag = expr_59;
                            if (-1 != 0)
                            {
                                goto Block_4;
                            }
                        }
                    IL_6E:
                        if (arg_6E_0)
                        {
                            goto IL_8A;
                        }
                        if (!false)
                        {
                            MessageBox.Show(UIConstant.DeviceDeletedSuccessfully);
                            break;
                        }
                        continue;
                    Block_4:
                        bool flag2 = !flag;
                        if (!false)
                        {
                            arg_6E_0 = flag2;
                            goto IL_6E;
                        }
                    IL_8A: ;
                    }
                    return;
                }
                this.GetDeviceData();
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
                    this.ResetControls();
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

        private void ResetControls()
        {
            TextBox expr_03 = this.txtDeviceBDA;
            string expr_8E = this.txtDeviceSerialNo.Text = (this.txtDeviceName.Text = string.Empty);
            if (!false)
            {
                expr_03.Text = expr_8E;
            }
            do
            {
                if (!false)
                {
                    this.cmbDeviceType.SelectedIndex = 0;
                    this.btnSaveDevice.Tag = 0;
                }
                this.chkIsActive.IsChecked = new bool?(true);
            }
            while (3 == 0);
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
                IL_19: ;
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
                    arg_16_0 = connectionId - 16;
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
