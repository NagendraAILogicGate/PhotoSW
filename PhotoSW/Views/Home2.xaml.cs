using DigiAuditLogger;
using PhotoSW.Common;
using DigiPhoto.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Manage;
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
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using PhotoSW.ViewModels;
using PhotoSW.CF.DataLayer.BAL;
using PhotoSW.DataLayer;
///using DigiPhoto;

namespace PhotoSW.Views
{
    public partial class Home : Window, IComponentConnector
    {
        private long TotalCount8810 = 0L;

        private long TotalCount6850 = 0L;

        private List<ImixPOSDetail> lstPosDetail = new List<ImixPOSDetail>();

        private List<Printer6850> lst6850Printer = new List<Printer6850>();

        private List<Printer8810> lst8810Printer = new List<Printer8810>();

        private string pathtosave = Environment.CurrentDirectory + "\\ss.dat";

      

        public Home()
        {
            this.InitializeComponent();
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
            RobotImageLoader.IsZeroSearchNeeded = false;
            RobotImageLoader.StartIndex = 0;
            RobotImageLoader.StopIndex = 0;

            this.CtrlOpeningForm.SetParent(this.modelparent);
            this.CtrlInventoryConsumables.SetParent(this.modelparent);
            this.CtrlOperationalStatistics.SetParent(this.modelparent);
            this.CtrlOpenCloseForm.SetParent(this.modelparent);
            this.CtrlOfflineClosingForm.SetParent(this.modelparent);
            this.grdRFID.Visibility = Visibility.Visible;
            this.GetPrintServerDetails();
        }
          private void Button_Click(object sender, RoutedEventArgs e)
        {
            StackPanel sp = new StackPanel();
            sp.Name = "First";
            System.Windows.Shapes.Ellipse ep = new System.Windows.Shapes.Ellipse()
            {
                Height = 75,
                Width = 75,
                Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Black),
                StrokeThickness = 1
            };
            sp.HorizontalAlignment = HorizontalAlignment.Right;
            sp.VerticalAlignment = VerticalAlignment.Center;
            sp.Margin = new Thickness(0, 120, 50, 0);
            sp.Children.Add(ep);
            //gd = UIHelper.FindChild<StackPanel>(Application.Current.MainWindow, "gridOuterPanel");
            //gd.Children.Add(sp);
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (!false)
                    {
                       // AuditLog.AddUserLog(LoginUser.UserId, 39, "Logged out at ");
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
        public static List<ConfigurationInfo> GetConfigurationData(List<baConfigurationInfo> Obj)
        {
            List<ConfigurationInfo> lst = new List<ConfigurationInfo>();
            //baConfigurationInfo baConfigurationInfo = new baConfigurationInfo();
            ConfigurationInfo ConfigurationInfo = new ConfigurationInfo();
            foreach (var p in Obj)
            {
                // ConfigurationInfo.Id = p.Id;
                ConfigurationInfo.DefaultCurrency = p.DefaultCurrency;
                ConfigurationInfo.DefaultCurrencyId = p.DefaultCurrencyId;
                ConfigurationInfo.DG_AllowDiscount = p.PS_AllowDiscount;
                ConfigurationInfo.DG_BG_Path = p.PS_BG_Path;
                ConfigurationInfo.DG_Brightness = p.PS_Brightness;
                ConfigurationInfo.DG_ChromaColor = p.PS_ChromaColor;
                ConfigurationInfo.DG_ChromaTolerance = p.PS_ChromaTolerance;
                ConfigurationInfo.DG_CleanUpDaysBackUp = p.PS_CleanUpDaysBackUp;
                ConfigurationInfo.DG_CleanupTables = p.PS_CleanupTables;
                ConfigurationInfo.DG_Config_pkey = p.PS_Config_pkey;
                ConfigurationInfo.DG_Contrast = p.PS_Contrast;
                ConfigurationInfo.DG_DbBackupPath = p.PS_DbBackupPath;
                ConfigurationInfo.DG_EnableDiscountOnTotal = p.PS_EnableDiscountOnTotal;
                ConfigurationInfo.DG_Frame_Path = p.PS_Frame_Path;
                ConfigurationInfo.DG_Graphics_Path = p.PS_Graphics_Path;
                ConfigurationInfo.DG_HfBackupPath = p.PS_HfBackupPath;
                ConfigurationInfo.DG_HighResolution = p.PS_HighResolution;
                ConfigurationInfo.DG_Hot_Folder_Path = p.PS_Hot_Folder_Path;
                ConfigurationInfo.DG_IsAutoRotate = p.PS_IsAutoRotate;
                ConfigurationInfo.DG_IsBackupScheduled = p.PS_IsBackupScheduled;
                ConfigurationInfo.DG_IsCompression = p.PS_IsCompression;
                ConfigurationInfo.DG_IsEnableGroup = p.PS_IsEnableGroup;
                ConfigurationInfo.DG_MktImgPath = p.PS_MktImgPath;
                ConfigurationInfo.DG_MktImgTimeInSec = p.PS_MktImgTimeInSec;
                ConfigurationInfo.DG_Mod_Password = p.PS_Mod_Password;
                ConfigurationInfo.DG_NoOfBillReceipt = p.PS_NoOfBillReceipt;
                ConfigurationInfo.DG_NoOfPhotoIdSearch = p.PS_NoOfPhotoIdSearch;
                ConfigurationInfo.DG_NoOfPhotos = p.PS_NoOfPhotos;
                ConfigurationInfo.DG_PageCountGrid = p.PS_PageCountGrid;
                ConfigurationInfo.DG_PageCountPreview = p.PS_PageCountPreview;
                ConfigurationInfo.DG_ReceiptPrinter = p.PS_ReceiptPrinter;
                ConfigurationInfo.DG_ScheduleBackup = p.PS_ScheduleBackup;
                ConfigurationInfo.DG_SemiOrder = p.PS_SemiOrder;
                ConfigurationInfo.DG_SemiOrderMain = p.PS_SemiOrderMain;
                ConfigurationInfo.DG_Substore_Id = p.PS_Substore_Id;
                ConfigurationInfo.DG_Watermark = p.PS_Watermark;
                ConfigurationInfo.EK_DisplayDuration = p.EK_DisplayDuration;
                ConfigurationInfo.EK_IsScreenSaverActive = p.EK_IsScreenSaverActive;
                ConfigurationInfo.EK_SampleImagePath = p.EK_SampleImagePath;
                ConfigurationInfo.EK_ScreenStartTime = p.EK_ScreenStartTime;
                ConfigurationInfo.FolderStartingNumber = p.FolderStartingNumber;
                ConfigurationInfo.FtpFolder = p.FtpFolder;
                ConfigurationInfo.FtpIP = p.FtpIP;
                ConfigurationInfo.FtpPwd = p.FtpPwd;
                ConfigurationInfo.FtpUid = p.FtpUid;
                ConfigurationInfo.IntervalCount = p.IntervalCount;
                ConfigurationInfo.intervalType = p.intervalType;
                ConfigurationInfo.IsAutoLock = p.IsAutoLock;
                ConfigurationInfo.IsDeleteFromUSB = p.IsDeleteFromUSB;
                ConfigurationInfo.IsExportReportToAnyDrive = p.IsExportReportToAnyDrive;
                ConfigurationInfo.IsRecursive = p.IsRecursive;
                ConfigurationInfo.IsSynced = p.IsSynced;
                ConfigurationInfo.PosOnOff = p.PosOnOff;
                ConfigurationInfo.SyncCode = p.SyncCode;
                ConfigurationInfo.WiFiStartingNumber = p.WiFiStartingNumber;
                //ConfigurationInfo.IsActive = p.IsActive;
                lst.Add(ConfigurationInfo);
            }
            return lst;

        }
        private bool IspathExist()
        {
            bool result;
            while (true)
            {
            IL_00:
                int arg_5C_0 = 0;
                while (true)
                {
                    result = (arg_5C_0 != 0);
                    while (true)
                    {
                       // var ConfigurationInfo = GetConfigurationData(baConfigurationInfo.GetConfigurationData());
                        //ConfigurationInfo configurationData = ConfigurationInfo.Where(p => p.DG_Substore_Id == LoginUser.SubStoreId).FirstOrDefault();
                        ConfigurationInfo configurationData = new ConfigBusiness().GetConfigurationData(LoginUser.SubStoreId);
                        bool flag;
                        if (-1 != 0)
                        {
                            flag = (configurationData == null);
                            bool expr_8F = (arg_5C_0 = (flag ? 1 : 0)) != 0;
                            if (false)
                            {
                                break;
                            }
                            if (expr_8F)
                            {
                                goto IL_53;
                            }
                        }
                    IL_2D:
                        if (false)
                        {
                            continue;
                        }
                        flag = !new DirectoryInfo(Path.GetFullPath(configurationData.DG_Hot_Folder_Path)).Exists;
                        if (3 != 0)
                        {
                            if (!flag)
                            {
                                result = true;
                            }
                            goto IL_53;
                        }
                        goto IL_00;
                    IL_2C:
                        goto IL_2D;
                    IL_53:
                        if (true)
                        {
                            return result;
                        }
                        goto IL_2C;
                    }
                }
            }
            return result;
        }

        private void btnImageDownLoad_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            int expr_09 = 4;
            int expr_0A = 0;
            int expr_0B = 0;
            TimeSpan t2;
            if (!false)
            {
                t2 = new TimeSpan(expr_09, expr_0A, expr_0B);
            }
            try
            {
                 RolePermissionsBusniess rolePermissionsBusniess = new  RolePermissionsBusniess();
                List<PermissionRoleInfo> permissionData = rolePermissionsBusniess.GetPermissionData(LoginUser.RoleId);
                List<iMIXConfigurationInfo> newConfigValues = new  ConfigBusiness().GetNewConfigValues(LoginUser.SubStoreId);
               // List<PermissionRoleInfo> permissionData = RolePermissionsBusniess.GetPermissionData(LoginUser.RoleId);

                //List<iMIXConfigurationInfo> newConfigValues = ConfigBusiness.GetNewConfigValues(LoginUser.SubStoreId);
             
                
                iMIXConfigurationInfo iMIXConfigurationInfo = newConfigValues.Where(delegate(iMIXConfigurationInfo o)
                {
                    bool result;
                    do
                    {
                        if (!false)
                        {
                            long arg_14_0 = o.IMIXConfigurationMasterId;
                            int arg_09_0 = 125;
                            long expr_2D;
                            do
                            {
                                expr_2D = (long)(arg_09_0 = Convert.ToInt32((ConfigParams)arg_09_0));
                            }
                            while (false);
                            result = (arg_14_0 == expr_2D);
                        }
                        while (false)
                        {
                        }
                    }
                    while (8 == 0);
                    return result;
                }).FirstOrDefault<iMIXConfigurationInfo>();

                  // iMIXConfigurationInfo iMIXConfigurationInfo = newConfigValues.Where(delegate(iMIXConfigurationInfo o)
               
                if (iMIXConfigurationInfo != null)
                {
                    string[] array = iMIXConfigurationInfo.ConfigurationValue.ToString().Split(new char[]
					{
						' '
					});
                    if (array[2] == "AM")
                    {
                        t2 = new TimeSpan(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), 0);
                    }
                    else
                    {
                        t2 = new TimeSpan(Convert.ToInt32(array[0]) + 12, Convert.ToInt32(array[1]), 0);
                    }
                }
                SageInfo sageInfo = new  SageBusiness().GetOpenCloseProcDetail(LoginUser.SubStoreId);
                bool arg_10D_0 = sageInfo == null;
                DateTime serverTime;
                string uniqueSynccode;
                PermissionRoleInfo permissionRoleInfo;
                string[] separator;
                string[] array2;
                SageInfoClosing sageInfoClosing;
                SageOpenClose sageOpenClose;
                bool arg_C8D_0;
                while (true)
                {
                    if (arg_10D_0)
                    {
                        sageInfo = new SageInfo();
                    }
                    serverTime = sageInfo.ServerTime;
                    uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.OpeningFormDetail).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString().PadLeft(2, '0'));
                    DateTime d;
                    if (sageInfo.FormTypeID != 1)
                    {
                        d = sageInfo.TransDate.Value;
                        goto IL_184;
                    }
                    bool arg_19E_0 = true;
                IL_19D:
                    if (!arg_19E_0)
                    {
                        break;
                    }
                    if (sageInfo.FormTypeID != 1)
                    {
                        goto IL_642;
                    }
                    d = sageInfo.TransDate.Value;
                    if (!(d.Date < serverTime.Date))
                    {
                        goto IL_642;
                    }
                    DateTime arg_613_0 = serverTime.Date;
                    d = sageInfo.TransDate.Value;
                    bool arg_644_0 = (arg_613_0 - d.Date).TotalDays <= 1.0 && !(serverTime.TimeOfDay > t2);
                IL_643:
                    if (!arg_644_0)
                    {
                        permissionRoleInfo = (from t in permissionData
                                              where t.DG_Permission_Id == 42
                                              select t).FirstOrDefault<PermissionRoleInfo>();
                        if (permissionRoleInfo == null)
                        {
                            goto Block_25;
                        }
                        this.AutoCount6850();
                        this.AutoCount8810();
                        this.CtrlInventoryConsumables.FromDate = sageInfo.FilledOn.Value;
                        this.CtrlInventoryConsumables.BusinessDate = sageInfo.TransDate.Value;
                        this.CtrlInventoryConsumables.ToDate = serverTime;
                        this.CtrlInventoryConsumables.SubStoreID = LoginUser.SubStoreId;
                        this.CtrlInventoryConsumables.SixEightStartingNumber = sageInfo.sixEightStartingNumber;
                        this.CtrlInventoryConsumables.EightTenStartingNumber = sageInfo.eightTenStartingNumber;
                        this.CtrlInventoryConsumables.PosterStartingNumber = sageInfo.PosterStartingNumber;
                        this.CtrlInventoryConsumables.EightTenAutoStartingNumber = sageInfo.eightTenAutoStartingNumber;
                        this.CtrlInventoryConsumables.SixEightAutoStartingNumber = sageInfo.sixEightAutoStartingNumber;
                        this.CtrlInventoryConsumables.EightTenAutoClosingNumber = this.TotalCount8810;
                        this.CtrlInventoryConsumables.SixEightAutoClosingNumber = this.TotalCount6850;
                        string text =  this.CtrlInventoryConsumables.ShowHandlerDialog("Closing Form");
                        separator = new string[]
						{
							"%##%"
						};
                        array2 = text.Split(separator, StringSplitOptions.None);
                        sageInfoClosing = new SageInfoClosing();
                        List<InventoryConsumables> inventoryConsumable = new List<InventoryConsumables>();
                        if (text != "")
                        {
                            inventoryConsumable = this.CtrlInventoryConsumables.lstinventoryItem;
                            sageInfoClosing.sixEightClosingNumber = Convert.ToInt64(array2[0]);
                            sageInfoClosing.eightTenClosingNumber = Convert.ToInt64(array2[1]);
                            sageInfoClosing.PosterClosingNumber = Convert.ToInt64(array2[2]);
                            sageInfoClosing.SixEightWestage = Convert.ToInt64(array2[3]);
                            sageInfoClosing.EightTenWestage = Convert.ToInt64(array2[4]);
                            sageInfoClosing.PosterWestage = Convert.ToInt64(array2[5]);
                            sageInfoClosing.objSubStore = new SubStoresInfo();
                            sageInfoClosing.objSubStore.DG_SubStore_pkey = LoginUser.SubStoreId;
                            sageInfoClosing.ClosingDate = new DateTime?(serverTime);
                            sageInfoClosing.FilledBy = LoginUser.UserId;
                            sageInfoClosing.FormTypeID = 2;
                            sageInfoClosing.SixEightPrintCount = this.CtrlInventoryConsumables.SixEightPrintCount;
                            sageInfoClosing.EightTenPrintCount = this.CtrlInventoryConsumables.EightTenPrintCount;
                            sageInfoClosing.PosterPrintCount = this.CtrlInventoryConsumables.PosterPrintCount;
                            sageInfoClosing.TransDate = new DateTime?(this.CtrlInventoryConsumables.BusinessDate);
                            sageInfoClosing.OpeningDate = new DateTime?(sageInfo.FilledOn.Value);
                          PhotoSW.PSControls.CtrlOperationalStatistics arg_961_0 = this.CtrlOperationalStatistics;
                            if (!sageInfo.TransDate.HasValue)
                            {
                                goto IL_944;
                            }
                            DateTime? transDate = sageInfo.TransDate;
                            d = DateTime.MinValue;
                            if (!(transDate != d))
                            {
                                goto IL_944;
                            }
                            DateTime arg_961_1 = sageInfo.TransDate.Value;
                        IL_960:
                            arg_961_0.BusinessDate = arg_961_1;
                            this.CtrlOperationalStatistics.FromDate = sageInfo.FilledOn.Value;
                            this.CtrlOperationalStatistics.ToDate = serverTime;
                            while (true)
                            {
                                this.CtrlOperationalStatistics.SubStoreID = LoginUser.SubStoreId;
                                string text2 =  this.CtrlOperationalStatistics.ShowHandlerDialog("Closing Form");
                                if (!(text2 != ""))
                                {
                                    goto IL_C26;
                                }
                                string[] array3 = new string[1];
                                if (false)
                                {
                                    goto IL_184;
                                }
                                array3[0] = "%##%";
                                string[] separator2 = array3;
                                string[] array4 = text2.Split(separator2, StringSplitOptions.None);
                                sageInfoClosing.Attendance = Convert.ToInt32(array4[0]);
                                sageInfoClosing.LaborHour = Convert.ToDecimal(array4[1]);
                                sageInfoClosing.NoOfCapture = Convert.ToInt64(array4[2]);
                                sageInfoClosing.NoOfPreview = Convert.ToInt64(array4[3]);
                                sageInfoClosing.NoOfImageSold = Convert.ToInt64(array4[4]);
                                sageInfoClosing.Comments = Convert.ToString(array4[5]);
                                string uniqueSynccode2 = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.ClosingFormDetail).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString().PadLeft(2, '0'));
                                sageInfoClosing.SyncCode = uniqueSynccode2;
                                sageInfoClosing.InventoryConsumable = inventoryConsumable;
                                if (false)
                                {
                                    goto IL_30F;
                                }
                                sageOpenClose = new SageOpenClose();
                                if (!false)
                                {
                                    goto Block_32;
                                }
                            }
                        IL_944:
                            arg_961_1 = Convert.ToDateTime("1/1/1753");
                            goto IL_960;
                        }
                        goto IL_C49;
                    }
                    else
                    {
                        d = sageInfo.BusinessDate.Value;
                        if (!(d.Date == serverTime.Date))
                        {
                            goto IL_C8B;
                        }
                        arg_C8D_0 = (arg_10D_0 = (sageInfo.FormTypeID != 2));
                        if (-1 != 0)
                        {
                            goto Block_37;
                        }
                        continue;
                    }
                IL_642:
                    arg_644_0 = true;
                    goto IL_643;
                IL_184:
                    arg_19E_0 = !(d.Date < serverTime.Date);
                    goto IL_19D;
                }
                permissionRoleInfo = (from t in permissionData
                                      where t.DG_Permission_Id == 41
                                      select t).FirstOrDefault<PermissionRoleInfo>();
                if (permissionRoleInfo == null)
                {
                    MessageBox.Show("You are not an authorized user to fill opening form, Please contact administrator");
                    return;
                }
                this.AutoCount6850();
                this.AutoCount8810();
                this.CtrlOpeningForm.FromDate = serverTime.Date;
                this.CtrlOpeningForm.printAutoStart6850 = this.TotalCount6850;
                this.CtrlOpeningForm.printAutoStart8810 = this.TotalCount8810;
                string text3 = this.CtrlOpeningForm.ShowHandlerDialog("Opening Form");
                if (!(text3 != ""))
                {
                    goto IL_5BC;
                }
                flag = true;
                separator = new string[]
				{
					"%##%"
				};
                array2 = text3.Split(separator, StringSplitOptions.None);
                sageInfo = new SageInfo();
                sageInfo.sixEightStartingNumber = Convert.ToInt64(array2[0]);
                sageInfo.eightTenStartingNumber = Convert.ToInt64(array2[1]);
                sageInfo.PosterStartingNumber = Convert.ToInt64(array2[2]);
                sageInfo.CashFloatAmount = Convert.ToDecimal(array2[3]);
                sageInfo.BusinessDate = new DateTime?(Convert.ToDateTime(array2[4]));
                sageInfo.SubStoreID = LoginUser.SubStoreId;
                sageInfo.OpeningDate = new DateTime?(serverTime);
                sageInfo.FilledBy = LoginUser.UserId;
            IL_30F:
                sageInfo.FormTypeID = 1;
                sageInfo.SyncCode = uniqueSynccode;
                sageInfo.eightTenAutoStartingNumber = this.TotalCount8810;
                sageInfo.sixEightAutoStartingNumber = this.TotalCount6850;
                if (!false)
                {
                    DateTime d = sageInfo.BusinessDate.Value;
                    string text4;
                    string[] separator3;
                    string[] array5;
                    if (!(d.Date > serverTime.Date))
                    {
                        text4 = new SageBusiness().SaveOpeningForm(sageInfo, this.lst6850Printer, this.lst8810Printer);
                        separator3 = new string[]
						{
							"%##%"
						};
                        array5 = text4.Split(separator3, StringSplitOptions.None);
                        if (array5[0] == "Success")
                        {
                            string description = "Opening form filled successfully for " + array5[1] + " for business date " + string.Format("{0:dd MMM yyyy}", sageInfo.BusinessDate.Value);
                            AuditLog.AddUserLog(LoginUser.UserId, 108, description);
                            MessageBox.Show("Opening form filled successfully for business date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.BusinessDate.Value));
                        }
                        else if (text4 == "Already Exist")
                        {
                            MessageBox.Show("You have already filled the opening form for selected business date, change the date and try again.");
                        }
                        else
                        {
                            MessageBox.Show("There is some error in opening form. Please try again.");
                        }
                        goto IL_5BB;
                    }
                    if (MessageBox.Show("Do you want to fill the opening form for future date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.BusinessDate.Value) + " ?", "Confirm opening form", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                    {
                        goto IL_4BA;
                    }
                    text4 = new SageBusiness().SaveOpeningForm(sageInfo, this.lst6850Printer, this.lst8810Printer);
                    separator3 = new string[]
					{
						"%##%"
					};
                    array5 = text4.Split(separator3, StringSplitOptions.None);
                    if (array5[0] == "Success")
                    {
                        string description = "Opening form filled successfully for " + array5[1] + " for business date " + string.Format("{0:dd MMM yyyy}", sageInfo.BusinessDate.Value);
                        AuditLog.AddUserLog(LoginUser.UserId, 108, description);
                    }
                    else
                    {
                        if (text4 == "Already Exist")
                        {
                            MessageBox.Show("You have already filled the opening form for selected business date, change the date and try again.");
                            goto IL_4B9;
                        }
                        MessageBox.Show("There is some error in opening form. Please try again.");
                        goto IL_4B9;
                    }
                }
                MessageBox.Show("Opening form filled successfully for business date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.BusinessDate.Value));
            IL_4B9:
            IL_4BA:
            IL_5BB:
            IL_5BC:
                goto IL_CD1;
            Block_25:
                MessageBox.Show("You are not an authorized user to fill closing form, please contact administrator");
                return;
            Block_32:
                sageOpenClose.objClose = sageInfoClosing;
                if (new SageBusiness().SaveClosingForm(sageOpenClose, this.lst6850Printer, this.lst8810Printer))
                {
                    string filename = "Closing Form_" + string.Format("{0:dd-MMM-yyyy}", sageInfo.TransDate.Value) + "_" + sageInfoClosing.objSubStore.DG_SubStore_Name;
                    StoreSubStoreDataBusniess storeSubStoreDataBusniess = new StoreSubStoreDataBusniess();
                    StoreInfo store = storeSubStoreDataBusniess.GetStore();
                    if (!store.IsOnline)
                    {
                        string toEncrypt = string.Empty;
                        toEncrypt = sageOpenClose.SerializeObject<SageOpenClose>();
                        string encData =PhotoSW.ViewModels. CryptorEngine.Encrypt(toEncrypt, true);
                        this.CtrlOfflineClosingForm.encData = encData;
                        this.CtrlOfflineClosingForm.filename = filename;
                        this.CtrlOfflineClosingForm.ShowHandlerDialog("Offline Closing Form");
                    }
                    string description = "Closing form saved successfully for " + sageInfoClosing.objSubStore.DG_SubStore_Name + " for business date " + string.Format("{0:dd MMM yyyy}", sageInfo.TransDate.Value);
                    AuditLog.AddUserLog(LoginUser.UserId, 108, description);
                    MessageBox.Show("Closing form saved successfully for business date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.TransDate.Value));
                }
                else
                {
                    MessageBox.Show("There is some error in closing form. Please try again.");
                }
                goto IL_C48;
            IL_C26:
                if (this.CtrlOperationalStatistics.Back == 1)
                {
                    this.btnImageDownLoad_Click(sender, e);
                }
            IL_C48:
            IL_C49:
                goto IL_CD1;
            Block_37:
                goto IL_C8C;
            IL_C8B:
                arg_C8D_0 = true;
            IL_C8C:
                if (!arg_C8D_0)
                {
                    MessageBox.Show("You have already filled the closing form for business date " + string.Format("{0:dd-MMM-yyyy}, if you want to fill the opening form for next business date please go to open/close procedure section.", sageInfo.BusinessDate.Value));
                }
                else
                {
                    flag = true;
                    this.ImageDownload();
                }
            IL_CD1: ;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
            finally
            {
                bool arg_D63_0;
                int expr_D21 = (arg_D63_0 = flag) ? 1 : 0;
                int arg_D63_1;
                int expr_D23 = arg_D63_1 = 0;
                ImageDownloader imageDownloader=null;//=new ImageDownloader ();
                if (expr_D23 == 0)
                {
                    if (expr_D21 == expr_D23)
                    {
                        goto IL_D96;
                    }
                    if (!this.IspathExist())
                    {
                        goto IL_D95;
                    }
                    if (!File.Exists(this.pathtosave))
                    {
                        MessageBox.Show("Please set the Substore", "i-Mix", MessageBoxButton.OK, MessageBoxImage.Hand);
                        goto IL_D94;
                    }
                    imageDownloader = new ImageDownloader();
                    arg_D63_0 = imageDownloader.IsShoworHide();
                    arg_D63_1 = 0;
                }
                if ((arg_D63_0 ? 1 : 0) != arg_D63_1)
                {
                    imageDownloader.Show();
                }
                base.Close();
            IL_D94:
            IL_D95:
            IL_D96: ;
            }
        }

        public void ImageDownload()
        {
            bool flag;
            if (!false)
            {
                if (-1 == 0)
                {
                    goto IL_11;
                }
                flag = this.IspathExist();
            }
        IL_0D:
            bool arg_0F_0 = flag;
            while (arg_0F_0)
            {
                string currentDirectory = Environment.CurrentDirectory;
                string text = currentDirectory + "\\";
                text = Path.Combine(text, "Download\\");
                if (!false)
                {
                    bool expr_3D = arg_0F_0 = Directory.Exists(text);
                    if (5 == 0)
                    {
                        continue;
                    }
                    flag = !expr_3D;
                    if (!flag)
                    {
                        Directory.Delete(text, true);
                    }
                }
                return;
            }
        IL_11:
            MessageBox.Show("Hot Folder Path is not accessible. Please try later!");
            if (false)
            {
                goto IL_0D;
            }
        }

        private void btnRfidDown_Click(object sender, RoutedEventArgs e)
        {
            new RfidManualDownload().Show();
            base.Close();
        }

        public void btnOpenClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RolePermissionsBusniess rolePermissionsBusniess = new RolePermissionsBusniess();
                List<PermissionRoleInfo> permissionData = rolePermissionsBusniess.GetPermissionData(LoginUser.RoleId);
                SageInfo sageInfo = new SageBusiness().GetOpenCloseProcDetail(LoginUser.SubStoreId);
                if (sageInfo == null)
                {
                    sageInfo = new SageInfo();
                }
                DateTime serverTime = sageInfo.ServerTime;
                string a = string.Empty;
                if (this.CtrlOperationalStatistics.Back != 1)
                {
                    this.CtrlOpenCloseForm.FormTypeID = Convert.ToInt32(sageInfo.FormTypeID);
                    this.CtrlOpenCloseForm.BusinessDate = sageInfo.BusinessDate;
                    this.CtrlOpenCloseForm.ServerTime = serverTime;
                    this.CtrlOpenCloseForm.TransDate = sageInfo.TransDate;
                    a = this.CtrlOpenCloseForm.ShowHandlerDialog("Check Form");
                }
                else
                {
                    a = "Closing From";
                }
                string description;
                if (a == "Opening From")
                {
                    this.AutoCount8810();
                    this.AutoCount6850();
                    if (false)
                    {
                        goto IL_452;
                    }
                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                             where t.DG_Permission_Id == 41
                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                    if (permissionRoleInfo == null)
                    {
                        MessageBox.Show("You are not an authorized user to fill opening form, please contact administrator");
                        return;
                    }
                    this.CtrlOpeningForm.FromDate = serverTime.Date;
                    this.CtrlOpeningForm.printAutoStart6850 = this.TotalCount6850;
                    this.CtrlOpeningForm.printAutoStart8810 = this.TotalCount8810;
                    string text = "";
                     text = this.CtrlOpeningForm.ShowHandlerDialog("Opening Form");
                    if (!(text != ""))
                    {
                        goto IL_531;
                    }
                    string[] separator = new string[]
					{
						"%##%"
					};
                    if (false)
                    {
                        goto IL_BC6;
                    }
                    string[] array = text.Split(separator, StringSplitOptions.None);
                    sageInfo = new SageInfo();
                    sageInfo.sixEightStartingNumber = Convert.ToInt64(array[0]);
                    sageInfo.eightTenStartingNumber = Convert.ToInt64(array[1]);
                    sageInfo.PosterStartingNumber = Convert.ToInt64(array[2]);
                    sageInfo.CashFloatAmount = Convert.ToDecimal(array[3]);
                    sageInfo.BusinessDate = new DateTime?(Convert.ToDateTime(array[4]));
                    sageInfo.SubStoreID = LoginUser.SubStoreId;
                    sageInfo.OpeningDate = new DateTime?(serverTime);
                    sageInfo.FilledBy = LoginUser.UserId;
                    sageInfo.FormTypeID = 1;
                    string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.OpeningFormDetail).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString().PadLeft(2, '0'));
                    sageInfo.SyncCode = uniqueSynccode;
                    sageInfo.eightTenAutoStartingNumber = this.TotalCount8810;
                    sageInfo.sixEightAutoStartingNumber = this.TotalCount6850;
                }
                else
                {
                    if (!(a == "Closing From"))
                    {
                        goto IL_C06;
                    }
                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                             where t.DG_Permission_Id == 42
                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                    if (permissionRoleInfo == null)
                    {
                        MessageBox.Show("You are not an authorized user to fill closing form, please contact administrator");
                        return;
                    }
                    if (sageInfo.TransDate.Value > serverTime.Date)
                    {
                        MessageBox.Show("You can not fill the closing form for future date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.TransDate.Value));
                        return;
                    }
                    this.AutoCount8810();
                    this.AutoCount6850();
                    this.CtrlInventoryConsumables.FromDate = ((sageInfo.FilledOn.HasValue && sageInfo.FilledOn.Value != DateTime.MinValue) ? sageInfo.FilledOn.Value : serverTime.Date);
                    this.CtrlInventoryConsumables.BusinessDate = sageInfo.TransDate.Value;
                    this.CtrlInventoryConsumables.ToDate = serverTime;
                    this.CtrlInventoryConsumables.SubStoreID = LoginUser.SubStoreId;
                    this.CtrlInventoryConsumables.SixEightStartingNumber = sageInfo.sixEightStartingNumber;
                    this.CtrlInventoryConsumables.EightTenStartingNumber = sageInfo.eightTenStartingNumber;
                    this.CtrlInventoryConsumables.PosterStartingNumber = sageInfo.PosterStartingNumber;
                    this.CtrlInventoryConsumables.EightTenAutoStartingNumber = sageInfo.eightTenAutoStartingNumber;
                    this.CtrlInventoryConsumables.SixEightAutoStartingNumber = sageInfo.sixEightAutoStartingNumber;
                    this.CtrlInventoryConsumables.EightTenAutoClosingNumber = this.TotalCount8810;
                    string text2;
                    do
                    {
                        this.CtrlInventoryConsumables.SixEightAutoClosingNumber = this.TotalCount6850;
                        text2 =  this.CtrlInventoryConsumables.ShowHandlerDialog("Closing Form");
                    }
                    while (8 == 0);
                    string[] separator = new string[]
					{
						"%##%"
					};
                    string[] array = text2.Split(separator, StringSplitOptions.None);
                    SageInfoClosing sageInfoClosing = new SageInfoClosing();
                    List<InventoryConsumables> inventoryConsumable = new List<InventoryConsumables>();
                    if (!(text2 != ""))
                    {
                        goto IL_BFF;
                    }
                   inventoryConsumable = this.CtrlInventoryConsumables.lstinventoryItem;
                    sageInfoClosing.sixEightClosingNumber = Convert.ToInt64(array[0]);
                    sageInfoClosing.eightTenClosingNumber = Convert.ToInt64(array[1]);
                    sageInfoClosing.PosterClosingNumber = Convert.ToInt64(array[2]);
                    sageInfoClosing.SixEightWestage = Convert.ToInt64(array[3]);
                    sageInfoClosing.EightTenWestage = Convert.ToInt64(array[4]);
                    sageInfoClosing.PosterWestage = Convert.ToInt64(array[5]);
                    sageInfoClosing.objSubStore = new SubStoresInfo();
                    SageOpenClose sageOpenClose;
                    do
                    {
                        sageInfoClosing.objSubStore.DG_SubStore_pkey = LoginUser.SubStoreId;
                        sageInfoClosing.ClosingDate = new DateTime?(serverTime);
                        string text3;
                        string[] array2;
                        do
                        {
                            sageInfoClosing.FilledBy = LoginUser.UserId;
                            sageInfoClosing.FormTypeID = 2;
                            sageInfoClosing.SixEightPrintCount = this.CtrlInventoryConsumables.SixEightPrintCount;
                            sageInfoClosing.EightTenPrintCount = this.CtrlInventoryConsumables.EightTenPrintCount;
                            sageInfoClosing.PosterPrintCount = this.CtrlInventoryConsumables.PosterPrintCount;
                            sageInfoClosing.TransDate = new DateTime?(this.CtrlInventoryConsumables.BusinessDate);
                            sageInfoClosing.OpeningDate = new DateTime?(sageInfo.FilledOn.Value);
                            this.CtrlOperationalStatistics.BusinessDate = ((sageInfo.TransDate.HasValue && sageInfo.TransDate != DateTime.MinValue) ? sageInfo.TransDate.Value : serverTime.Date);
                            this.CtrlOperationalStatistics.FromDate = sageInfo.FilledOn.Value;
                            this.CtrlOperationalStatistics.ToDate = serverTime;
                            this.CtrlOperationalStatistics.SubStoreID = LoginUser.SubStoreId;
                            text3 =  this.CtrlOperationalStatistics.ShowHandlerDialog("Closing Form");
                            if (!(text3 != ""))
                            {
                                goto IL_BD6;
                            }
                            array2 = new string[]
							{
								"%##%"
							};
                        }
                        while (2 == 0);
                        string[] separator2 = array2;
                        string[] array3 = text3.Split(separator2, StringSplitOptions.None);
                        sageInfoClosing.Attendance = Convert.ToInt32(array3[0]);
                        sageInfoClosing.LaborHour = Convert.ToDecimal(array3[1]);
                        sageInfoClosing.NoOfCapture = Convert.ToInt64(array3[2]);
                        sageInfoClosing.NoOfPreview = Convert.ToInt64(array3[3]);
                        sageInfoClosing.NoOfImageSold = Convert.ToInt64(array3[4]);
                        if (false)
                        {
                            goto IL_2BC;
                        }
                        sageInfoClosing.Comments = Convert.ToString(array3[5]);
                        string uniqueSynccode2 = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.ClosingFormDetail).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString().PadLeft(2, '0'));
                        sageInfoClosing.SyncCode = uniqueSynccode2;
                        sageInfoClosing.InventoryConsumable = inventoryConsumable;
                        sageInfoClosing.eightTenAutoClosingNumber = this.TotalCount8810;
                        sageInfoClosing.sixEightAutoClosingNumber = this.TotalCount6850;
                        sageInfoClosing.SixEightAutoWestage = 0L;
                        sageInfoClosing.EightTenAutoWestage = 0L;
                        sageOpenClose = new SageOpenClose();
                        sageOpenClose.objClose = sageInfoClosing;
                        if (!new SageBusiness().SaveClosingForm(sageOpenClose, this.lst6850Printer, this.lst8810Printer))
                        {
                            goto IL_BC6;
                        }
                    }
                    while (false);
                    string filename = "Closing Form_" + string.Format("{0:dd-MMM-yyyy}", sageInfo.TransDate.Value) + "_" + sageInfoClosing.objSubStore.DG_SubStore_Name;
                    StoreSubStoreDataBusniess storeSubStoreDataBusniess = new StoreSubStoreDataBusniess();
                    StoreInfo store = storeSubStoreDataBusniess.GetStore();
                    if (!store.IsOnline)
                    {
                        string toEncrypt = string.Empty;
                        toEncrypt = sageOpenClose.SerializeObject<SageOpenClose>();
                        string encData = PhotoSW.ViewModels.CryptorEngine.Encrypt(toEncrypt, true);
                        this.CtrlOfflineClosingForm.encData = encData;
                        this.CtrlOfflineClosingForm.filename = filename;
                        this.CtrlOfflineClosingForm.ShowHandlerDialog("Offline Closing Form");
                    }
                    description = "Closing form saved successfully for " + sageInfoClosing.objSubStore.DG_SubStore_Name + " for business date " + string.Format("{0:dd MMM yyyy}", sageInfo.TransDate.Value);
                    AuditLog.AddUserLog(LoginUser.UserId, 109, description);
                    MessageBox.Show("Closing form saved successfully for business date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.TransDate.Value));
                    goto IL_BD3;
                IL_BD6:
                    if (this.CtrlOperationalStatistics.Back == 1)
                    {
                        this.btnOpenClose_Click(sender, e);
                        goto IL_BF8;
                    }
                    goto IL_BF8;
                }
            IL_2BC:
                bool flag = !(sageInfo.BusinessDate.Value.Date > serverTime.Date);
                bool arg_386_0;
                bool expr_2E5 = arg_386_0 = flag;
                string text4;
                string[] separator3;
                string[] array4;
                if (5 != 0)
                {
                    if (expr_2E5)
                    {
                        text4 = new SageBusiness().SaveOpeningForm(sageInfo, this.lst6850Printer, this.lst8810Printer);
                        goto IL_452;
                    }
                    if (MessageBox.Show("Do you want to fill the opening form for future date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.BusinessDate.Value) + " ?", "Confirm opening form", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                    {
                        goto IL_432;
                    }
                    text4 = new SageBusiness().SaveOpeningForm(sageInfo, this.lst6850Printer, this.lst8810Printer);
                    separator3 = new string[]
					{
						"%##%"
					};
                    array4 = text4.Split(separator3, StringSplitOptions.None);
                    arg_386_0 = !(array4[0] == "Success");
                }
                if (arg_386_0)
                {
                    if (text4 == "Already Exist")
                    {
                        MessageBox.Show("You have already filled the opening form for selected business date, change the date and try again.");
                        goto IL_431;
                    }
                    MessageBox.Show("There is some error in opening form. Please try again.");
                    goto IL_431;
                }
            IL_38D:
                description = "Opening form filled successfully for " + array4[1] + " for business date " + string.Format("{0:dd MMM yyyy}", sageInfo.BusinessDate.Value);
                AuditLog.AddUserLog(LoginUser.UserId, 108, description);
                MessageBox.Show("Opening form filled successfully for business date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.BusinessDate.Value));
            IL_431:
            IL_432:
                goto IL_530;
            IL_452:
                separator3 = new string[]
				{
					"%##%"
				};
                array4 = text4.Split(separator3, StringSplitOptions.None);
                if (array4[0] == "Success")
                {
                    description = "Opening form filled successfully for " + array4[1] + " for business date " + string.Format("{0:dd MMM yyyy}", sageInfo.BusinessDate.Value);
                    AuditLog.AddUserLog(LoginUser.UserId, 108, description);
                    MessageBox.Show("Opening form filled successfully for business date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.BusinessDate.Value));
                }
                else if (text4 == "Already Exist")
                {
                    MessageBox.Show("You have already filled the opening form for selected business date, change the date and try again.");
                }
                else
                {
                    MessageBox.Show("There is some error in opening form. Please try again.");
                }
            IL_530:
            IL_531:
                goto IL_C06;
            IL_BC6:
                MessageBox.Show("There is some error in form. Please try again.");
            IL_BD3:
            IL_BF8:
                if (false)
                {
                    goto IL_38D;
                }
            IL_BFF:
                if (7 != 0)
                {
                }
            IL_C06: ;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void btnOrderStation_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                TimeSpan t2 = new TimeSpan(4, 0, 0);
                RolePermissionsBusniess rolePermissionsBusniess = new RolePermissionsBusniess();
                List<PermissionRoleInfo> permissionData = rolePermissionsBusniess.GetPermissionData(LoginUser.RoleId);
                List<iMIXConfigurationInfo> newConfigValues = new ConfigBusiness().GetNewConfigValues(LoginUser.SubStoreId);
                iMIXConfigurationInfo iMIXConfigurationInfo = newConfigValues.Where(delegate(iMIXConfigurationInfo o)
                {
                    bool result;
                    do
                    {
                        if (!false)
                        {
                            long arg_14_0 = o.IMIXConfigurationMasterId;
                            int arg_09_0 = 125;
                            long expr_2D;
                            do
                            {
                                expr_2D = (long)(arg_09_0 = Convert.ToInt32((ConfigParams)arg_09_0));
                            }
                            while (false);
                            result = (arg_14_0 == expr_2D);
                        }
                        while (false)
                        {
                        }
                    }
                    while (8 == 0);
                    return result;
                }).FirstOrDefault<iMIXConfigurationInfo>();
                if (iMIXConfigurationInfo != null)
                {
                    string[] array = iMIXConfigurationInfo.ConfigurationValue.ToString().Split(new char[]
					{
						' '
					});
                    if (array[2] == "AM")
                    {
                        t2 = new TimeSpan(Convert.ToInt32(array[0]), Convert.ToInt32(array[1]), 0);
                    }
                    else
                    {
                        t2 = new TimeSpan(Convert.ToInt32(array[0]) + 12, Convert.ToInt32(array[1]), 0);
                    }
                }
                SageInfo sageInfo = new SageBusiness().GetOpenCloseProcDetail(LoginUser.SubStoreId);
                if (sageInfo == null)
                {
                    sageInfo = new SageInfo();
                }
                DateTime serverTime = sageInfo.ServerTime;
                int arg_361_0;
                int expr_11F = arg_361_0 = sageInfo.FormTypeID;
                SageInfoClosing sageInfoClosing;
                SageOpenClose sageOpenClose;
                if (2 != 0)
                {
                    if (expr_11F != 1 && sageInfo.TransDate.Value.Date < serverTime.Date)
                    {
                        PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                 where t.DG_Permission_Id == 41
                                                                 select t).FirstOrDefault<PermissionRoleInfo>();
                        if (permissionRoleInfo != null)
                        {
                            this.AutoCount6850();
                            this.AutoCount8810();
                            this.CtrlOpeningForm.FromDate = serverTime.Date;
                            this.CtrlOpeningForm.printAutoStart6850 = this.TotalCount6850;
                            this.CtrlOpeningForm.printAutoStart8810 = this.TotalCount8810;
                            string text = this.CtrlOpeningForm.ShowHandlerDialog("Opening Form");
                            if (text != "")
                            {
                                string[] separator = new string[]
								{
									"%##%"
								};
                                string[] array2 = text.Split(separator, StringSplitOptions.None);
                                sageInfo = new SageInfo();
                                sageInfo.sixEightStartingNumber = Convert.ToInt64(array2[0]);
                                sageInfo.eightTenStartingNumber = Convert.ToInt64(array2[1]);
                                sageInfo.PosterStartingNumber = Convert.ToInt64(array2[2]);
                                sageInfo.CashFloatAmount = Convert.ToDecimal(array2[3]);
                                sageInfo.BusinessDate = new DateTime?(Convert.ToDateTime(array2[4]));
                                sageInfo.SubStoreID = LoginUser.SubStoreId;
                                sageInfo.OpeningDate = new DateTime?(serverTime);
                                sageInfo.FilledBy = LoginUser.UserId;
                                sageInfo.FormTypeID = 1;
                                sageInfo.eightTenAutoStartingNumber = this.TotalCount8810;
                                sageInfo.sixEightAutoStartingNumber = this.TotalCount6850;
                                string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.OpeningFormDetail).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString().PadLeft(2, '0'));
                                sageInfo.SyncCode = uniqueSynccode;
                                arg_361_0 = ((sageInfo.BusinessDate.Value.Date > serverTime.Date) ? 1 : 0);
                                goto IL_360;
                            }
                            goto IL_5B2;
                        }
                    }
                    else if (sageInfo.FormTypeID == 1 && sageInfo.TransDate.Value.Date < serverTime.Date && ((serverTime.Date - sageInfo.TransDate.Value.Date).TotalDays > 1.0 || serverTime.TimeOfDay > t2))
                    {
                        this.AutoCount6850();
                        this.AutoCount8810();
                        PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                 where t.DG_Permission_Id == 42
                                                                 select t).FirstOrDefault<PermissionRoleInfo>();
                        if (permissionRoleInfo == null)
                        {
                            MessageBox.Show("You are not an authorized user to fill closing form, Please contact administrator");
                            return;
                        }
                        this.CtrlInventoryConsumables.FromDate = sageInfo.FilledOn.Value;
                        this.CtrlInventoryConsumables.BusinessDate = sageInfo.TransDate.Value;
                        this.CtrlInventoryConsumables.ToDate = serverTime;
                        if (!false)
                        {
                            this.CtrlInventoryConsumables.SubStoreID = LoginUser.SubStoreId;
                            this.CtrlInventoryConsumables.SixEightStartingNumber = sageInfo.sixEightStartingNumber;
                            this.CtrlInventoryConsumables.EightTenStartingNumber = sageInfo.eightTenStartingNumber;
                            this.CtrlInventoryConsumables.PosterStartingNumber = sageInfo.PosterStartingNumber;
                            this.CtrlInventoryConsumables.EightTenAutoStartingNumber = sageInfo.eightTenAutoStartingNumber;
                            this.CtrlInventoryConsumables.SixEightAutoStartingNumber = sageInfo.sixEightAutoStartingNumber;
                            this.CtrlInventoryConsumables.EightTenAutoClosingNumber = this.TotalCount8810;
                            this.CtrlInventoryConsumables.SixEightAutoClosingNumber = this.TotalCount6850;
                            string text2 =  this.CtrlInventoryConsumables.ShowHandlerDialog("Closing Form");
                            string[] separator = new string[]
							{
								"%##%"
							};
                            string[] array2 = text2.Split(separator, StringSplitOptions.None);
                            sageInfoClosing = new SageInfoClosing();
                            List<InventoryConsumables> inventoryConsumable = new List<InventoryConsumables>();
                            if (!(text2 != ""))
                            {
                                goto IL_C91;
                            }
                            inventoryConsumable = this.CtrlInventoryConsumables.lstinventoryItem;
                            sageInfoClosing.sixEightClosingNumber = Convert.ToInt64(array2[0]);
                            sageInfoClosing.eightTenClosingNumber = Convert.ToInt64(array2[1]);
                            sageInfoClosing.PosterClosingNumber = Convert.ToInt64(array2[2]);
                            sageInfoClosing.SixEightWestage = Convert.ToInt64(array2[3]);
                            sageInfoClosing.EightTenWestage = Convert.ToInt64(array2[4]);
                            sageInfoClosing.PosterWestage = Convert.ToInt64(array2[5]);
                            sageInfoClosing.objSubStore = new SubStoresInfo();
                            sageInfoClosing.objSubStore.DG_SubStore_pkey = LoginUser.SubStoreId;
                            sageInfoClosing.ClosingDate = new DateTime?(serverTime);
                            sageInfoClosing.FilledBy = LoginUser.UserId;
                            sageInfoClosing.FormTypeID = 2;
                            sageInfoClosing.SixEightPrintCount = this.CtrlInventoryConsumables.SixEightPrintCount;
                            sageInfoClosing.EightTenPrintCount = this.CtrlInventoryConsumables.EightTenPrintCount;
                            sageInfoClosing.PosterPrintCount = this.CtrlInventoryConsumables.PosterPrintCount;
                            sageInfoClosing.TransDate = new DateTime?(this.CtrlInventoryConsumables.BusinessDate);
                            sageInfoClosing.OpeningDate = new DateTime?(sageInfo.FilledOn.Value);
                            this.CtrlOperationalStatistics.BusinessDate = ((sageInfo.TransDate.HasValue && sageInfo.TransDate != DateTime.MinValue) ? sageInfo.TransDate.Value : Convert.ToDateTime("1/1/1753"));
                            this.CtrlOperationalStatistics.FromDate = sageInfo.FilledOn.Value;
                            this.CtrlOperationalStatistics.ToDate = serverTime;
                            this.CtrlOperationalStatistics.SubStoreID = LoginUser.SubStoreId;
                            string text3 = this.CtrlOperationalStatistics.ShowHandlerDialog("Closing Form");
                            if (text3 != "")
                            {
                                string[] separator2 = new string[]
								{
									"%##%"
								};
                                string[] array3 = text3.Split(separator2, StringSplitOptions.None);
                                sageInfoClosing.Attendance = Convert.ToInt32(array3[0]);
                                sageInfoClosing.LaborHour = Convert.ToDecimal(array3[1]);
                                sageInfoClosing.NoOfCapture = Convert.ToInt64(array3[2]);
                                sageInfoClosing.NoOfPreview = Convert.ToInt64(array3[3]);
                                sageInfoClosing.NoOfImageSold = Convert.ToInt64(array3[4]);
                                sageInfoClosing.Comments = Convert.ToString(array3[5]);
                                string uniqueSynccode2 = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.ClosingFormDetail).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString().PadLeft(2, '0'));
                                sageInfoClosing.SyncCode = uniqueSynccode2;
                                sageInfoClosing.InventoryConsumable = inventoryConsumable;
                                sageOpenClose = new SageOpenClose();
                                sageOpenClose.objClose = sageInfoClosing;
                                goto IL_ABC;
                            }
                            if (this.CtrlOperationalStatistics.Back == 1)
                            {
                                this.btnOrderStation_Click(sender, e);
                                goto IL_C90;
                            }
                            //goto IL_C90;
                        }
                    }
                    else
                    {
                        if (sageInfo.BusinessDate.Value.Date == serverTime.Date && sageInfo.FormTypeID == 2)
                        {
                            MessageBox.Show("You have already filled the closing form for business date " + string.Format("{0:dd-MMM-yyyy}, if you want to fill the opening form for next business date please go to open/close procedure section.", sageInfo.BusinessDate.Value));
                            goto IL_D0E;
                        }
                        this.OrderStation();
                        goto IL_D0E;
                    }
                    MessageBox.Show("You are not an authorized user to fill opening form, Please contact administrator");
                    return;
                }
            IL_360:
                if (arg_361_0 != 0)
                {
                    if (MessageBox.Show("Do you want to fill the opening form for future date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.BusinessDate.Value) + " ?", "Confirm opening form", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        string text4 = new SageBusiness().SaveOpeningForm(sageInfo, this.lst6850Printer, this.lst8810Printer);
                        string[] separator3 = new string[]
						{
							"%##%"
						};
                        string[] array4 = text4.Split(separator3, StringSplitOptions.None);
                        if (array4[0] == "Success")
                        {
                            string description = "Opening form filled successfully for " + array4[1] + " for business date " + string.Format("{0:dd MMM yyyy}", sageInfo.BusinessDate.Value);
                            AuditLog.AddUserLog(LoginUser.UserId, 108, description);
                            MessageBox.Show("Opening form filled successfully for business date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.BusinessDate.Value));
                        }
                        else if (text4 == "Already Exist")
                        {
                            MessageBox.Show("You have already filled the opening form for selected business date, change the date and try again.");
                        }
                        else
                        {
                            MessageBox.Show("There is some error in opening form. Please try again.");
                        }
                    }
                }
                else
                {
                    string text4 = new SageBusiness().SaveOpeningForm(sageInfo, this.lst6850Printer, this.lst8810Printer);
                    string[] separator3 = new string[]
					{
						"%##%"
					};
                    string[] array4 = text4.Split(separator3, StringSplitOptions.None);
                    if (array4[0] == "Success")
                    {
                        string description = "Opening form filled successfully for " + array4[1] + " for business date " + string.Format("{0:dd MMM yyyy}", sageInfo.BusinessDate.Value);
                        AuditLog.AddUserLog(LoginUser.UserId, 108, description);
                        MessageBox.Show("Opening form filled successfully for business date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.BusinessDate.Value));
                    }
                    else if (text4 == "Already Exist")
                    {
                        MessageBox.Show("You have already filled the opening form for selected business date, change the date and try again.");
                    }
                    else
                    {
                        MessageBox.Show("There is some error in opening form. Please try again.");
                    }
                }
            IL_5B2:
                if (-1 != 0)
                {
                    goto IL_D0E;
                }
            IL_ABC:
                if (new SageBusiness().SaveClosingForm(sageOpenClose, this.lst6850Printer, this.lst8810Printer))
                {
                    string filename = "Closing Form_" + string.Format("{0:dd-MMM-yyyy}", sageInfo.TransDate.Value) + "_" + sageInfoClosing.objSubStore.DG_SubStore_Name;
                    StoreSubStoreDataBusniess storeSubStoreDataBusniess = new StoreSubStoreDataBusniess();
                    StoreInfo store = storeSubStoreDataBusniess.GetStore();
                    if (!store.IsOnline)
                    {
                        string toEncrypt = string.Empty;
                        SubStoresInfo substoreData = new StoreSubStoreDataBusniess().GetSubstoreData(LoginUser.SubStoreId);
                        sageInfoClosing.objSubStore.DG_SubStore_pkey = ((substoreData.LogicalSubStoreID == 0) ? LoginUser.SubStoreId : Convert.ToInt32(substoreData.LogicalSubStoreID));
                        toEncrypt = sageOpenClose.SerializeObject<SageOpenClose>();
                        string encData = PhotoSW.ViewModels.CryptorEngine.Encrypt(toEncrypt, true);
                        this.CtrlOfflineClosingForm.encData = encData;
                        this.CtrlOfflineClosingForm.filename = filename;
                        this.CtrlOfflineClosingForm.ShowHandlerDialog("Offline Closing Form");
                    }
                    string description = "Closing form saved successfully for " + sageInfoClosing.objSubStore.DG_SubStore_Name + " for business date " + string.Format("{0:dd MMM yyyy}", sageInfo.TransDate.Value);
                    AuditLog.AddUserLog(LoginUser.UserId, 109, description);
                    MessageBox.Show("Closing form saved successfully for business date " + string.Format("{0:dd-MMM-yyyy}", sageInfo.TransDate.Value));
                }
                else
                {
                    MessageBox.Show("There is some error in closing form. Please try again.");
                }
            IL_C90:
            IL_C91:
            IL_D0E: ;
            }
            catch (Exception serviceException)
            {
                if (8 != 0)
                {
                }
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        public void OrderStation()
        {
            Window window;
            if (File.Exists(this.pathtosave))
            {
                window = null;
                IEnumerator enumerator = Application.Current.Windows.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        Window window2 = (Window)enumerator.Current;
                        if (window2.Title == "Search")
                        {
                            goto IL_65;
                        }
                    IL_6E:
                        if (5 != 0)
                        {
                            continue;
                        }
                    IL_65:
                        window = (window2 as SearchByPhoto);
                        goto IL_6E;
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable == null)
                    {
                        goto IL_99;
                    }
                IL_91:
                    disposable.Dispose();
                IL_99:
                    if (4 == 0)
                    {
                        goto IL_91;
                    }
                }
            }
            else
            {
                if (8 == 0)
                {
                    return;
                }
                MessageBox.Show("Please set the Substore", "i-Mix", MessageBoxButton.OK, MessageBoxImage.Hand);
                if (4 != 0)
                {
                    return;
                }
                goto IL_CA;
            }
        IL_9D:
            SearchByPhoto searchByPhoto;
            if (window != null)
            {
                do
                {
                    searchByPhoto = (SearchByPhoto)window;
                }
                while (false);
            }
            else
            {
                searchByPhoto = new SearchByPhoto();
            }
            base.Close();
            searchByPhoto.Show();
        IL_CA:
            if (false)
            {
                goto IL_9D;
            }
           searchByPhoto.LoadData();
        }

        private void btnManage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                do
                {
                    new ManageHome().Show();
                }
                while (false);
                if (6 != 0)
                {
                    base.Close();
                }
            }
            catch (Exception serviceException)
            {
                do
                {
                    if (!false)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
                while (false);
            }
        }

        private void btncheckcd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                do
                {
                    new ImagePreviewer().Show();
                }
                while (false);
                if (6 != 0)
                {
                    base.Close();
                }
            }
            catch (Exception serviceException)
            {
                do
                {
                    if (!false)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
                while (false);
            }
        }

        public void AutoCount8810()
        {
            do
            {
                this.TotalCount8810 = 0L;
            }
            while (false);
            List<ImixPOSDetail>.Enumerator enumerator = this.lstPosDetail.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    ImixPOSDetail current = enumerator.Current;
                    try
                    {
                        string address = "http://" + current.SystemName + ":8000/GEt8810PrintersInfo";
                        WebClient webClient = new WebClient();
                        string xmlString = webClient.DownloadString(address);
                        bool flag;
                        do
                        {
                           // this.lst8810Printer = xmlString.DeserializeXML<List<Printer8810>>();
                            flag = (this.lst8810Printer.Count != 0);
                        }
                        while (3 == 0);
                        if (!flag)
                        {
                            ErrorHandler.ErrorHandler.LogFileWrite("No Printer Found by Kodak SDK");
                        }
                        else
                        {
                            using (List<Printer8810>.Enumerator enumerator2 = this.lst8810Printer.GetEnumerator())
                            {
                                while (true)
                                {
                                    while (true)
                                    {
                                        bool arg_CB_0;
                                        bool expr_100 = arg_CB_0 = enumerator2.MoveNext();
                                        Printer8810 current2;
                                        if (3 != 0)
                                        {
                                            if (!expr_100)
                                            {
                                                goto Block_13;
                                            }
                                            current2 = enumerator2.Current;
                                            flag = !(current2.ErrorMessage != "");
                                            arg_CB_0 = flag;
                                        }
                                        if (arg_CB_0)
                                        {
                                            goto IL_E8;
                                        }
                                        if (false)
                                        {
                                            goto IL_E8;
                                        }
                                        ErrorHandler.ErrorHandler.LogFileWrite(current2.ErrorMessage);
                                        if (2 != 0)
                                        {
                                            if (8 == 0)
                                            {
                                                goto IL_E8;
                                            }
                                        }
                                        break;
                                    IL_E8:
                                        this.TotalCount8810 += current2.ImageCount;
                                    }
                                }
                            Block_13: ;
                            }
                        }
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
            }
            finally
            {
                ((IDisposable)enumerator).Dispose();
                while (false)
                {
                }
            }
        }

        public void AutoCount6850()
        {
            this.TotalCount6850 = 0L;
            using (List<ImixPOSDetail>.Enumerator enumerator = this.lstPosDetail.GetEnumerator())
            {
                while (true)
                {
                    bool flag;
                    if (8 != 0)
                    {
                        flag = enumerator.MoveNext();
                    }
                    if (!flag)
                    {
                        if (!false)
                        {
                            break;
                        }
                    }
                    else
                    {
                        ImixPOSDetail current = enumerator.Current;
                        //try
                        //{
                        //    string address = "http://" + current.SystemName + ":8000/Get6850PrintersInfo";
                        //    WebClient webClient = new WebClient();
                        //    string xmlString = webClient.DownloadString(address);
                        //    this.lst6850Printer = xmlString.DeserializeXML<List<Printer6850>>();
                        //    flag = (this.lst6850Printer.Count != 0);
                        //    if (!flag)
                        //    {
                        //        ErrorHandler.ErrorHandler.LogFileWrite("No Printer Found by Kodak SDK");
                        //    }
                        //    else
                        //    {
                        //        using (List<Printer6850>.Enumerator enumerator2 = this.lst6850Printer.GetEnumerator())
                        //        {
                        //            while (true)
                        //            {
                        //                flag = enumerator2.MoveNext();
                        //                if (!flag)
                        //                {
                        //                    break;
                        //                }
                        //                Printer6850 current2 = enumerator2.Current;
                        //                flag = !(current2.ErrorMessage != "");
                        //                if (!flag)
                        //                {
                        //                    ErrorHandler.ErrorHandler.LogFileWrite(current2.ErrorMessage);
                        //                }
                        //                else
                        //                {
                        //                    this.TotalCount6850 = current2.ImageCount;
                        //                }
                        //            }
                        //        }
                        //    }
                        //}
                        //catch (Exception serviceException)
                        //{
                        //    ErrorHandler.ErrorHandler.LogError(serviceException);
                        //}
                    }
                }
            }
        }

        public void GetPrintServerDetails()
        {
            this.lstPosDetail = new SageBusiness().GetPrintServerDetails(LoginUser.SubStoreId);
        }

    
   }
}
