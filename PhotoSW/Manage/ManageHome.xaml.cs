using DigiAuditLogger;
using PhotoSW.Common;
using DigiPhoto.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
//using DigiPhoto.Manage.Reports;
//using DigiPhoto.Orders;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using PhotoSW.Orders;
using PhotoSW.Views;
using PhotoSW.Manage.Reports;
using PhotoSW.DataLayer;

namespace PhotoSW.Manage
{
	public partial class ManageHome : Window, IComponentConnector
	{
		private delegate int LowLevelKeyboardProcDelegate(int nCode, int wParam, ref ManageHome.KBDLLHOOKSTRUCT lParam);

		private struct KBDLLHOOKSTRUCT
		{
			public int vkCode;

			private int scanCode;

			public int flags;

			private int time;

			private int dwExtraInfo;
		}

		private const int WH_KEYBOARD_LL = 13;

		private string _MktImgPath = string.Empty;

		private int _mktImgTime = 0;

		private IntPtr intLLKey;

		private static ManageHome.LowLevelKeyboardProcDelegate mHookProc;

		//private bool _contentLoaded;

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetModuleHandle(IntPtr path);

		[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetWindowsHookExA")]
		private static extern IntPtr SetWindowsHookEx(int idHook, ManageHome.LowLevelKeyboardProcDelegate lpfn, IntPtr hMod, int dwThreadId);

		[DllImport("user32.dll", CharSet = CharSet.Ansi)]
		private static extern int CallNextHookEx(int hHook, int nCode, int wParam, ref ManageHome.KBDLLHOOKSTRUCT lParam);

		[DllImport("user32.dll")]
		private static extern IntPtr UnhookWindowsHookEx(IntPtr hHook);

		public ManageHome()
		{
			this.InitializeComponent();
			this.txbUserName.Text = LoginUser.UserName;
			this.txbStoreName.Text = LoginUser.StoreName;
		}

      
        private void Button_Click ( object sender, RoutedEventArgs e )
            {
            new CustomBusineses();
            Dictionary<string, int> Obj = null;
            try
                {
                Button button = (Button)sender;
                RolePermissionsBusniess rolePermissionsBusniess = new RolePermissionsBusniess();
                List<PermissionRoleInfo> permissionData = rolePermissionsBusniess.GetPermissionData(LoginUser.RoleId);
                string name = button.Name;
                if(name != null)
                    {
                    if(Obj == null)
                        {
                        Obj = new Dictionary<string, int>(31)
                        {
                            {
                                "btnReceiptReprint",
                                0
                            },
                            {
                                "btnManageDevice",
                                1
                            },
                            {
                                "btnManageSubstores",
                                2
                            },
                            {
                                "btnPrntMgr",
                                3
                            },
                            {
                                "btnConfig",
                                4
                            },
                            {
                                "btnUsrMgmt",
                                5
                            },
                            {
                                "btncashbox",
                                6
                            },
                            {
                                "btnRemapPrinters",
                                7
                            },
                            {
                                "btnHelp",
                                8
                            },
                            {
                                "btnHealthChkup",
                                9
                            },
                            {
                                "btnFinancialReport",
                                10
                            },
                            {
                                "btnCleargroup",
                                11
                            },
                            {
                                "btnManageStores",       //
                                12
                            },
                            {
                                "btnMinimizeApp",
                                13
                            },
                            {
                                "btnShutDown",
                                14
                            },
                            {
                                "btnLogout",
                                15
                            },
                            {
                                "btnBack",
                                16
                            },
                            {
                                "btnManageCamera",
                                17
                            },
                            {
                                "btnManageProduct",
                                18
                            },
                            {
                                "btnPrinterQueue",
                                19
                            },
                            {
                                "btnEnableTaskbar",
                                20
                            },
                            {
                                "btnLocations",
                                21
                            },
                            {
                                "btnRefund",
                                22
                            },
                            {
                                "btnSystemprinterqueue",
                                23
                            },
                            {
                                "btnBurnOrders",
                                24
                            },
                            {
                                "btnCardType",
                                25
                            },
                            {
                                "btnsynstatus",
                                26
                            },
                            {
                                "btnRFIDMatch",
                                27
                            },
                            {
                                "btnEmailStatus",
                                28
                            },
                            {
                                "btnCurrencyExchange",
                                29
                            },
                            {
                                "btnUpldMasterData",
                                30
                            }
                        };
                        }
                    int num;
                    if(Obj.TryGetValue(name, out num))
                        {
                        int arg_3D7_0;
                        int arg_3D7_1;
                        string a;
                        ManagePrinting managePrinting;
                        switch(num)
                            {
                            case 0:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //34
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                         ReceiptReprint receiptReprint =  new ReceiptReprint();
                                        receiptReprint.Show();
                                        base.Close();
                                        }
                                    else
                                        {
                                        MessageBox.Show("You are not authorized! please contact admin");
                                     //   AuditLog.AddUserLog(LoginUser.UserId, 66, "Tried to access Receipt Re-Print");
                                        }
                                    goto IL_121E;
                                    }
                            case 1:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 // 33
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        ManageDevice manageDevice = new ManageDevice();
                                        manageDevice.Show();
                                        base.Close();
                                        }
                                    else
                                        {
                                        MessageBox.Show(UIConstant.NotAuthorized);
                                      //  AuditLog.AddUserLog(LoginUser.UserId, 45, UIConstant.TriedToAccessDeviceManager);
                                        }
                                    goto IL_121E;
                                    }
                            case 2:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1  //22
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        ManageSubstores manageSubstores = new ManageSubstores();
                                        manageSubstores.Show();
                                        base.Close();
                                        goto IL_3DE;
                                        }
                                    MessageBox.Show(UIConstant.NotAuthorized);
                                    arg_3D7_0 = LoginUser.UserId;
                                    arg_3D7_1 = 45;
                                    break;
                                    }
                            case 3:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //6
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        ManagePrinter managePrinter = new ManagePrinter();
                                        managePrinter.Show();
                                        base.Close();
                                        }
                                    else
                                        {
                                        MessageBox.Show(UIConstant.NotAuthorized);
                                        if(false)
                                            {
                                            goto IL_E31;
                                            }
                                      //  AuditLog.AddUserLog(LoginUser.UserId, 45, UIConstant.TriedToAccessPrintManager);
                                        }
                                    goto IL_121E;
                                    }
                            case 4:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //2
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    PermissionRoleInfo permissionRoleInfo2 = (from t in permissionData
                                                                              where t.DG_Permission_Id == 5
                                                                              select t).FirstOrDefault<PermissionRoleInfo>();
                                    PermissionRoleInfo permissionRoleInfo3 = (from t in permissionData
                                                                              where t.DG_Permission_Id == 7
                                                                              select t).FirstOrDefault<PermissionRoleInfo>();
                                    PermissionRoleInfo permissionRoleInfo4 = (from t in permissionData
                                                                              where t.DG_Permission_Id == 8
                                                                              select t).FirstOrDefault<PermissionRoleInfo>();
                                    PermissionRoleInfo permissionRoleInfo5 = (from t in permissionData
                                                                              where t.DG_Permission_Id == 9
                                                                              select t).FirstOrDefault<PermissionRoleInfo>();
                                    PermissionRoleInfo permissionRoleInfo6 = (from t in permissionData
                                                                              where t.DG_Permission_Id == 13
                                                                              select t).FirstOrDefault<PermissionRoleInfo>();
                                    PermissionRoleInfo permissionRoleInfo7 = (from t in permissionData
                                                                              where t.DG_Permission_Id == 14
                                                                              select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null || permissionRoleInfo2 != null || permissionRoleInfo3 != null || permissionRoleInfo4 != null || permissionRoleInfo5 != null || permissionRoleInfo6 != null || permissionRoleInfo7 != null)
                                        {
                                        Configuration instance = Configuration.Instance;
                                        instance.tbmain.SelectedIndex = 0;
                                        instance.Show();
                                        base.Close();
                                        }
                                    else
                                        {
                                        MessageBox.Show(UIConstant.NotAuthorized);
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, UIConstant.TriedToAccessAonfiguration);
                                        }
                                    goto IL_121E;
                                    }
                            case 5:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //4
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        AddEditUsers addEditUsers = new AddEditUsers();
                                        addEditUsers.Show();
                                        base.Close();
                                        }
                                    else
                                        {
                                        MessageBox.Show(UIConstant.NotAuthorized);
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, UIConstant.TriedToAccessUserManagement);
                                        }
                                    goto IL_121E;
                                    }
                            case 6:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //35
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        try
                                            {
                                            this.mycontrol.Visibility = Visibility.Visible;
                                            this.brdMain.IsEnabled = false;
                                            }
                                        catch(Exception serviceException)
                                            {
                                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                                            }
                                        }
                                    else
                                        {
                                        MessageBox.Show(UIConstant.NotAuthorized);
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, UIConstant.TriedToAccessCashBox);
                                        }
                                    goto IL_121E;
                                    }
                            case 7:
                                    {
                                    bool flag = !this.DeleteAllPrinters();
                                    if(8 != 0)
                                        {
                                        if(!flag)
                                            {
                                            this.AddAvailablePrinters();
                                            AuditLog.AddUserLog(LoginUser.UserId, 107, "Printer Remapped on :- ");
                                            MessageBox.Show("Printer list refreshed successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                                            }
                                        else
                                            {
                                            MessageBox.Show("Printer list could not be cleared!", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
                                            }
                                        goto IL_121E;
                                        }
                                    goto IL_ED2;
                                    }
                            case 8:
                                    {
                                    string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                                    string fileName = directoryName + "\\Help\\i-MixUserManual.chm";
                                    Process.Start(fileName);
                                    goto IL_121E;
                                    }
                            case 9:
                                    {
                                    SoftwareHealthCheckup softwareHealthCheckup = new SoftwareHealthCheckup();
                                    softwareHealthCheckup.Show();
                                    base.Close();
                                    goto IL_121E;
                                    }
                            case 10:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //10
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        ActivityReport activityReport = new ActivityReport();
                                        
                                        base.Hide();
                                        activityReport.Show();
                                        }
                                    else
                                        {
                                        MessageBox.Show("You are not authorized! please contact admin");
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access Financial Report");
                                        }
                                    goto IL_121E;
                                    }
                            case 11:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //25
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    int days = Convert.ToInt32(ConfigurationManager.AppSettings["DeletedOldImages"]);
                                    if(permissionRoleInfo != null)
                                        {
                                        a = MessageBox.Show("Do you want to clear all groups?", "Confirm Clear Group", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();
                                        if(a == "Yes")
                                            {
                                            PhotoBusiness photoBusiness = new PhotoBusiness();
                                            if(photoBusiness.TruncatePhotoGroupTable(days, LoginUser.SubStoreId))
                                                {
                                                MessageBox.Show("All groups cleared succesfully!");
                                                }
                                            else
                                                {
                                                MessageBox.Show("Error in clearing groups!");
                                                }
                                            }
                                        }
                                    else
                                        {
                                        MessageBox.Show("You are not authorized! please contact admin");
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access Clear Group");
                                        }
                                    goto IL_121E;
                                    }
                            case 12:
                                goto IL_121E;
                            case 13:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //24
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        a = MessageBox.Show("Do you want to minimize the application?", "Confirm Minimize", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();
                                        if(a == "Yes")
                                            {
                                            try
                                                {
                                                this.ReleaseKeyboardHook();
                                              //  ManageHome.EnableDisableTaskManager(true);
                                              //  AuditLog.AddUserLog(LoginUser.UserId, 104, "Minimized to Windows on :- ");
                                                Taskbar.Show();
                                                base.WindowState = WindowState.Minimized;
                                                }
                                            catch(Exception serviceException)
                                                {
                                                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                                ErrorHandler.ErrorHandler.LogFileWrite(message);
                                                }
                                            }
                                        }
                                    else
                                        {
                                        MessageBox.Show("You are not authorized! please contact admin");
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access Shut down at :- ");
                                        }
                                    goto IL_121E;
                                    }
                            case 14:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //11
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        goto IL_A38;
                                        }
                                    MessageBox.Show("You are not authorized! please contact admin");
                                    AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access Shut down at :- ");
                                    goto IL_AF0;
                                    }
                            case 15:
                                    {
                                  //  AuditLog.AddUserLog(LoginUser.UserId, 39, "Logged out at ");
                                    Login login = new Login();
                                    login.Show();
                                    base.Close();
                                    goto IL_121E;
                                    }
                            case 16:
                                    {
                                    this.GetMktImgInfo();
                                    ClientView clientView = null;
                                    foreach(Window window in Application.Current.Windows)
                                        {
                                        if(window.Title == "ClientView")
                                            {
                                            clientView = (ClientView)window;
                                            }
                                        }
                                    if(clientView == null)
                                        {
                                        clientView = new ClientView();
                                        clientView.WindowStartupLocation = WindowStartupLocation.Manual;
                                        }
                                    clientView.GroupView = false;
                                    clientView.DefaultView = false;
                                    if(!(this._MktImgPath == "") && this._mktImgTime != 0)
                                        {
                                        clientView.instructionVideo.Visibility = Visibility.Visible;
                                        clientView.instructionVideo.Play();
                                        }
                                    else
                                        {
                                        clientView.imgDefault.Visibility = Visibility.Visible;
                                        }
                                    clientView.testR.Fill = null;
                                    clientView.DefaultView = true;
                                    if(clientView.instructionVideo.Visibility == Visibility.Visible)
                                        {
                                        clientView.instructionVideo.Play();
                                        }
                                    else
                                        {
                                        clientView.instructionVideo.Pause();
                                        }
                                    Home home = new Home();
                                    home.Show();
                                    base.Close();
                                    goto IL_121E;
                                    }
                            case 17:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //12
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        ManageCamera manageCamera = new ManageCamera();
                                        manageCamera.Show();
                                        base.Close();
                                        }
                                    else
                                        {
                                        MessageBox.Show("You are not authorized! please contact admin");
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access Manage Camera at :- ");
                                        }
                                    goto IL_121E;
                                    }
                            case 18:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        ManageProduct manageProduct = new ManageProduct();
                                        manageProduct.Show();
                                        base.Close();
                                        }
                                    else
                                        {
                                        MessageBox.Show("You are not authorized! please contact admin");
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access Manage Product at :- ");
                                        }
                                    goto IL_121E;
                                    }
                            case 19:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //15
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        managePrinting = null;
                                        foreach(Window window in Application.Current.Windows)
                                            {
                                            if(window.Title == "ManagePrinting")
                                                {
                                                managePrinting = (ManagePrinting)window;
                                                }
                                            }
                                        goto IL_E31;
                                        }
                                    MessageBox.Show("You are not authorized! please contact admin");
                                    AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access Printer queue at :- ");
                                    goto IL_E88;
                                    }
                            case 20:
                                goto IL_121E;
                            case 21:
                                    {
                                    if(6 == 0)
                                        {
                                        goto IL_3DE;
                                        }
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1  //18
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        goto IL_ED2;
                                        }
                                    MessageBox.Show("You are not authorized! please contact admin");
                                    AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access Manage Location at :- ");
                                    goto IL_F0A;
                                    }
                            case 22:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //16
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        OrderRefund orderRefund = new OrderRefund();
                                        orderRefund.Show();
                                        base.Close();
                                        }
                                    else
                                        {
                                        MessageBox.Show("You are not authorized! please contact admin");
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access Refund Module at :- ");
                                        }
                                    goto IL_121E;
                                    }
                            case 23:
                                    {
                                    if(2 == 0)
                                        {
                                        goto IL_A38;
                                        }
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //23
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        goto IL_FC4;
                                        }
                                    MessageBox.Show("You are not authorized! please contact admin");
                                    AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access System Printer queue Module at :- ");
                                    goto IL_FFC;
                                    }
                            case 24:
                                this.RestoreMinimizeBurnOrders();
                                goto IL_1008;
                            case 25:
                                    {
                                    CardType cardType = new CardType();
                                    cardType.Show();
                                    base.Close();
                                    goto IL_121E;
                                    }
                            case 26:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //32
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        SyncStatus syncStatus = new SyncStatus();
                                        syncStatus.Show();
                                        base.Close();
                                        }
                                    else
                                        {
                                        MessageBox.Show("You are not authorized! please contact admin");
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access SyncStatus Module at :- ");
                                        }
                                    goto IL_121E;
                                    }
                            case 27:
                                    {
                                    RFIDMapping rFIDMapping = new RFIDMapping();
                                    rFIDMapping.Show();
                                    base.Close();
                                    if(6 != 0)
                                        {
                                        goto IL_121E;
                                        }
                                    goto IL_1008;
                                    }
                            case 28:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //39
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        EmailStatus emailStatus = new EmailStatus();
                                        emailStatus.Show();
                                        base.Close();
                                        }
                                    else
                                        {
                                        MessageBox.Show("You are not authorized! please contact admin");
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access SyncStatus Module at :- ");
                                        }
                                    goto IL_121E;
                                    }
                            case 29:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //43
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        ManageCurrencyProfile manageCurrencyProfile = new ManageCurrencyProfile();
                                        manageCurrencyProfile.Show();
                                        base.Close();
                                        }
                                    else
                                        {
                                        MessageBox.Show(UIConstant.NotAuthorized);
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access Manage Currency Module at :- ");
                                        }
                                    goto IL_121E;
                                    }
                            case 30:
                                    {
                                    PermissionRoleInfo permissionRoleInfo = (from t in permissionData
                                                                             where t.DG_Permission_Id == 1 //44
                                                                             select t).FirstOrDefault<PermissionRoleInfo>();
                                    if(permissionRoleInfo != null)
                                        {
                                        ManageMasterData manageMasterData = new ManageMasterData();
                                        manageMasterData.Show();
                                        base.Close();
                                        }
                                    else
                                        {
                                        MessageBox.Show(UIConstant.NotAuthorized);
                                        AuditLog.AddUserLog(LoginUser.UserId, 45, "Tried to access Manage Currency Module at :- ");
                                        }
                                    goto IL_121E;
                                    }
                            default:
                                goto IL_121E;
                            }
                        IL_3D2:
                        AuditLog.AddUserLog(arg_3D7_0, arg_3D7_1, UIConstant.TriedToAccessPrintManager);
                        IL_3DE:
                        goto IL_121E;
                        IL_A38:
                        a = MessageBox.Show("Do you want to shutdown?", "Confirm shutdown", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();
                        if(a == "Yes")
                            {
                            int expr_A76 = arg_3D7_0 = Process.GetProcessesByName("PhotoPrinting").Count<Process>();
                            int expr_A7C = arg_3D7_1 = 0;
                            if(expr_A7C != 0)
                                {
                                goto IL_3D2;
                                }
                            if(expr_A76 > expr_A7C)
                                {
                                Process[] processesByName = Process.GetProcessesByName("PhotoPrinting");
                                for(int i = 0; i < processesByName.Length; i++)
                                    {
                                    Process process = processesByName[i];
                                    process.Kill();
                                    }
                                }
                            this.Shutdown();
                            }
                        IL_AF0:
                        goto IL_121E;
                        IL_E31:
                        if(managePrinting == null)
                            {
                            managePrinting = new ManagePrinting();
                            }
                        managePrinting.PrintJob = true;
                        managePrinting.Show();
                        base.Close();
                        if(false)
                            {
                            goto IL_FC4;
                            }
                        IL_E88:
                        goto IL_121E;
                        IL_ED2:
                        ManageLocations manageLocations = new ManageLocations();
                        manageLocations.Show();
                        base.Close();
                        IL_F0A:
                        goto IL_121E;
                        IL_FC4:
                        SystemPrinterQueuee systemPrinterQueuee = new SystemPrinterQueuee();
                        systemPrinterQueuee.Show();
                        base.Close();
                        IL_FFC:
                        IL_1008:;
                        }
                    }
                IL_121E:;
                }
            catch(Exception serviceException)
                {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                }


            }


        private void RestoreMinimizeBurnOrders()
		{
            Window window = null;
            foreach(Window expr_28 in Application.Current.Windows)
                {
                Window window2;
                if(7 != 0)
                    {
                    window2 = expr_28;
                    }
                if(window2.Title == "BurnMedia")
                    {
                    window = (BurnMediaOrderList)window2;
                    window2.Height = 730.0;
                    window2.Width = 900.0;
                    window2.WindowState = WindowState.Maximized;
                    window2.Show();
                    break;
                    }
                }
            if(window == null)
                {
                BurnMediaOrderList burnMediaOrderList;
                if(!false)
                    {
                    burnMediaOrderList = new BurnMediaOrderList();
                    burnMediaOrderList.Height = 730.0;
                    burnMediaOrderList.Width = 900.0;
                    burnMediaOrderList.WindowState = WindowState.Maximized;
                    }
               // burnMediaOrderList.Show();
                }
            }

		private void Shutdown()
		{
			try
			{
				object obj = "";
				string hostName = Dns.GetHostName();
				string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name FROM Win32_ComputerSystem");
				using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						ManagementObject managementObject = (ManagementObject)enumerator.Current;
						obj = managementObject["Name"];
					}
				}
				ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
				IEnumerable<ManagementObject> source = managementObjectSearcher2.Get().Cast<ManagementObject>();
				string mac = (from o in source
				orderby o["IPConnectionMetric"]
				select o["MACAddress"].ToString()).FirstOrDefault<string>();
				ServicePosInfoBusiness servicePosInfoBusiness;
				string systemName;
				do
				{
					servicePosInfoBusiness = new ServicePosInfoBusiness();
					systemName = obj.ToString();
				}
				while (false);
				servicePosInfoBusiness.StartStopSystemBusiness(mac, myIP, systemName, 0);
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.ErrorHandler.LogFileWrite(message);
			}
			ManagementClass managementClass = new ManagementClass("Win32_OperatingSystem");
			managementClass.Get();
			managementClass.Scope.Options.EnablePrivileges = true;
			ManagementBaseObject methodParameters = managementClass.GetMethodParameters("Win32Shutdown");
			methodParameters["Flags"] = "1";
			methodParameters["Reserved"] = "0";
			using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementClass.GetInstances().GetEnumerator())
			{
				if (!false)
				{
				}
				IL_215:
				if (enumerator.MoveNext())
				{
					ManagementObject managementObject2 = (ManagementObject)enumerator.Current;
					while (3 == 0)
					{
					}
					ManagementBaseObject managementBaseObject = managementObject2.InvokeMethod("Win32Shutdown", methodParameters, null);
					goto IL_215;
				}
			}
		}

		private void ForceShutDown()
		{
			if (false)
			{
				goto IL_0B;
			}
			if (-1 == 0)
			{
				goto IL_0C;
			}
			IL_07:
			Process[] processes = Process.GetProcesses();
			IL_0B:
			IL_0C:
			Process[] array = processes;
			if (6 != 0)
			{
				int num = 0;
				while (true)
				{
					int arg_3F_0;
					int arg_31_0;
					int expr_32 = arg_31_0 = (arg_3F_0 = num);
					if (5 != 0)
					{
						bool flag = expr_32 < array.Length;
						arg_3F_0 = (flag ? 1 : 0);
						goto IL_3F;
					}
					IL_2E:
					if (!false)
					{
						num = arg_31_0;
						continue;
					}
					IL_3F:
					if (arg_3F_0 == 0)
					{
						break;
					}
					Process expr_1C = array[num];
					Process process;
					if (3 != 0)
					{
						process = expr_1C;
					}
					process.Kill();
					arg_3F_0 = (arg_31_0 = num + 1);
					goto IL_2E;
				}
				Process.Start("shutdown", "/s /t 0");
				return;
			}
			goto IL_07;
		}

		private static void EnableDisableTaskManager(bool enable)
		{
			if (false)
			{
				goto IL_37;
			}
			if (!false)
			{
			}
			RegistryKey currentUser = Registry.CurrentUser;
			IL_0E:
			if (7 != 0)
			{
				RegistryKey expr_41 = currentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
				RegistryKey registryKey;
				if (6 != 0)
				{
					registryKey = expr_41;
				}
				registryKey.SetValue("DisableTaskMgr", enable ? 0 : 1, RegistryValueKind.DWord);
			}
			IL_37:
			if (!false)
			{
				return;
			}
			goto IL_0E;
		}

		private int LowLevelKeyboardProc(int nCode, int wParam, ref ManageHome.KBDLLHOOKSTRUCT lParam)
		{
			bool flag = false;
			int arg_88_0=0;
			switch (wParam)
			{
			case 256:
			case 257:
			case 260:
			case 261:
				if (lParam.vkCode == 9)
				{
					if (3 == 0)
					{
						goto IL_110;
					}
					if (lParam.flags == 32)
					{
						goto IL_CD;
					}
				}
				if (lParam.vkCode == 27 && lParam.flags == 32)
				{
					goto IL_CD;
				}
				arg_88_0 = lParam.vkCode;
				break;
            //case 258:
            //case 259:
				//goto IL_DB;
			//default:
				//goto IL_DB;
			}
			IL_86:
			int arg_D7_0;
			bool arg_CF_0;
			if (arg_88_0 != 27 || lParam.flags != 0)
			{
				int expr_93 = arg_D7_0 = lParam.vkCode;
				if (5 == 0)
				{
					goto IL_D7;
				}
				if ((expr_93 != 91 || lParam.flags != 1) && (lParam.vkCode != 92 || lParam.flags != 1))
				{
					if (!false)
					{
						arg_CF_0 = (lParam.flags != 32);
						goto IL_CE;
					}
					goto IL_110;
				}
			}
			IL_CD:
			arg_CF_0 = false;
			IL_CE:
			if (arg_CF_0)
			{
				goto IL_D9;
			}
			arg_D7_0 = 1;
			IL_D7:
			flag = (arg_D7_0 != 0);
			IL_D9:
			int num;
			try
			{
				IL_DB:
				if (flag)
				{
					num = 1;
				}
				else
				{
					try
					{
						int num2 = ManageHome.CallNextHookEx(0, nCode, wParam, ref lParam);
						num = num2;
					}
					catch (Exception)
					{
						do
						{
							if (7 != 0)
							{
								num = 1;
							}
						}
						while (false);
					}
				}
			}
			catch (Exception var_2_106)
			{
				do
				{
					num = 1;
				}
				while (8 == 0);
			}
			IL_110:
			int expr_110 = arg_88_0 = num;
			if (!false)
			{
				return expr_110;
			}
			goto IL_86;
		}

		private void KeyboardHook(object sender, EventArgs e)
		{
			if (false || -1 != 0)
			{
				ManageHome.mHookProc = new ManageHome.LowLevelKeyboardProcDelegate(this.LowLevelKeyboardProc);
			}
			IntPtr arg_81_0;
			IntPtr expr_19 = arg_81_0 = IntPtr.Zero;
			if (6 != 0)
			{
				arg_81_0 = ManageHome.GetModuleHandle(expr_19);
			}
			IntPtr hMod = arg_81_0;
			this.intLLKey = ManageHome.SetWindowsHookEx(13, ManageHome.mHookProc, hMod, 0);
			bool arg_47_0 = this.intLLKey == IntPtr.Zero;
			while (true)
			{
				bool flag = !arg_47_0;
				while (true)
				{
					bool expr_4B = arg_47_0 = flag;
					if (5 == 0)
					{
						break;
					}
					if (expr_4B)
					{
						return;
					}
					if (4 != 0)
					{
						goto Block_5;
					}
				}
			}
			Block_5:
			MessageBox.Show("Failed to set hook,error = " + Marshal.GetLastWin32Error().ToString());
		}

		private void ReleaseKeyboardHook()
		{
			this.intLLKey = ManageHome.UnhookWindowsHookEx(this.intLLKey);
		}

		private void btnPrntMgr_Click(object sender, RoutedEventArgs e)
		{
		}

		private void GetMktImgInfo()
		{
			try
			{
				ConfigBusiness configBusiness = new ConfigBusiness();
				List<long> objList = new List<long>();
				objList.Add(24L);
				objList.Add(25L);
				List<iMIXConfigurationInfo> list;
				int num;
				if (8 != 0)
				{
					list = (from o in configBusiness.GetNewConfigValues(LoginUser.SubStoreId)
					where objList.Contains(o.IMIXConfigurationMasterId)
					select o).ToList<iMIXConfigurationInfo>();
					int arg_89_0;
					if (list == null)
					{
						int arg_83_0;
						int expr_77 = arg_83_0 = list.Count;
						int arg_83_1;
						int expr_7D = arg_83_1 = 0;
						if (expr_7D == 0)
						{
							arg_83_0 = ((expr_77 > expr_7D) ? 1 : 0);
							arg_83_1 = 0;
						}
						arg_89_0 = ((arg_83_0 == arg_83_1) ? 1 : 0);
					}
					else
					{
						arg_89_0 = 0;
					}
					IL_85:
					if (arg_89_0 != 0)
					{
						goto IL_135;
					}
					int expr_94 = arg_89_0 = 0;
					if (expr_94 == 0)
					{
						num = expr_94;
						goto IL_122;
					}
					goto IL_85;
				}
				IL_E8:
				IL_11D:
				num++;
				IL_122:
				if (num < list.Count)
				{
					long iMIXConfigurationMasterId = list[num].IMIXConfigurationMasterId;
					long arg_C2_0;
					long expr_AC = arg_C2_0 = iMIXConfigurationMasterId;
					int arg_C1_0;
					int expr_B0 = arg_C1_0 = 25;
					if (expr_B0 == 0)
					{
						goto IL_C1;
					}
					if (expr_AC > (long)expr_B0)
					{
						//goto IL_D1;
					}
					if (iMIXConfigurationMasterId < 24L)
					{
						goto IL_11D;
					}
					IL_BD:
					arg_C2_0 = iMIXConfigurationMasterId;
					arg_C1_0 = 24;
					IL_C1:
					switch ((int)(arg_C2_0 - (long)arg_C1_0))
					{
					case 0:
						if (!false)
						{
							this._MktImgPath = list[num].ConfigurationValue;
							goto IL_E8;
						}
						goto IL_BD;
					case 1:
						this._mktImgTime = ((list[num].ConfigurationValue != null) ? list[num].ConfigurationValue.ToInt32(false) : 10) * 1000;
						goto IL_11D;
					default:
						IL_D1:
						goto IL_11D;
					}
				}
				IL_135:;
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
				do
				{
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
				while (false);
			}
			while (false)
			{
			}
		}

		private void AddAvailablePrinters()
		{
			do
			{
				PrinterTypeBusiness printerTypeBusiness = new PrinterTypeBusiness();
				do
				{
					IEnumerator enumerator = PrinterSettings.InstalledPrinters.GetEnumerator();
					try
					{
						while (true)
						{
							string text;
							if (!false)
							{
								bool flag = enumerator.MoveNext();
								bool arg_30_0;
								bool expr_5E = arg_30_0 = flag;
								if (!false)
								{
									if (!expr_5E)
									{
										break;
									}
									text = (string)enumerator.Current;
									arg_30_0 = string.IsNullOrEmpty(text);
								}
								if (!arg_30_0)
								{
									goto IL_36;
								}
							}
							IL_4E:
							if (!false)
							{
								continue;
							}
							goto IL_36;
							IL_4D:
							goto IL_4E;
							IL_36:
							bool active = this.IsPrinterReady(text);
							bool flag2 = printerTypeBusiness.SaveOrActivateNewPrinter(text, LoginUser.SubStoreId, active);
							goto IL_4D;
						}
					}
					finally
					{
						IDisposable disposable = enumerator as IDisposable;
						if (6 == 0 || disposable != null)
						{
							disposable.Dispose();
						}
					}
				}
				while (-1 == 0);
				printerTypeBusiness = null;
			}
			while (false);
		}

		private bool DeleteAllPrinters()
		{
			int arg_65_0;
			int expr_02 = arg_65_0 = 0;
			if (expr_02 == 0)
			{
				bool flag = expr_02 != 0;
				//goto IL_07;
				try
				{
					PrinterTypeBusiness printerTypeBusiness;
					do
					{
						IL_07:
						if (!false)
						{
							printerTypeBusiness = new PrinterTypeBusiness();
						}
					}
					while (false);
					flag = printerTypeBusiness.DeleteAssociatedPrinters(LoginUser.SubStoreId);
					printerTypeBusiness = null;
				}
				catch (Exception serviceException)
				{
					if (!false)
					{
						flag = false;
					}
					string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
					ErrorHandler.ErrorHandler.LogFileWrite(message);
				}
				if (-1 != 0)
				{
				}
				bool flag2 = flag;
				arg_65_0 = (flag2 ? 1 : 0);
			}
			return arg_65_0 != 0;
		}

		private bool IsPrinterReady(string PrinterName)
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
									IL_190:;
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

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
        //public void InitializeComponent()
        //{
        //    bool arg_09_0 = this._contentLoaded;
        //    bool expr_09;
        //    do
        //    {
        //        expr_09 = (arg_09_0 = !arg_09_0);
        //    }
        //    while (false);
        //    bool flag = expr_09;
        //    while (true)
        //    {
        //        if (!flag)
        //        {
        //            goto IL_14;
        //        }
        //        IL_1A:
        //        this._contentLoaded = true;
        //        while (6 != 0)
        //        {
        //            Uri resourceLocator = new Uri("/DigiPhoto;component/manage/managehome.xaml", UriKind.Relative);
        //            if (!false)
        //            {
        //                Application.LoadComponent(this, resourceLocator);
        //                if (-1 != 0)
        //                {
        //                    return;
        //                }
        //                goto IL_14;
        //            }
        //        }
        //        continue;
        //        IL_14:
        //        if (6 != 0)
        //        {
        //            break;
        //        }
        //        goto IL_1A;
        //    }
        //}

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        //void IComponentConnector.Connect(int connectionId, object target)
        //{
        //    switch (connectionId)
        //    {
        //    case 1:
        //        this.bgContainer = (StackPanel)target;
        //        return;
        //    case 2:
        //        this.vb2 = (Viewbox)target;
        //        return;
        //    case 3:
        //        this.bg_withlogo1 = (StackPanel)target;
        //        return;
        //    case 4:
        //        this.bg1 = (Image)target;
        //        return;
        //    case 5:
        //        this.FooterredLine = (StackPanel)target;
        //        return;
        //    case 6:
        //        this.brdMain = (Border)target;
        //        return;
        //    case 7:
        //        this.manage = (Grid)target;
        //        return;
        //    case 8:
        //        this.btnManageSubstores = (Button)target;
        //        this.btnManageSubstores.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 9:
        //        this.btnLocations = (Button)target;
        //        this.btnLocations.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 10:
        //        break;
        //    case 11:
        //        this.btnUsrMgmt = (Button)target;
        //        this.btnUsrMgmt.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 12:
        //        this.btncashbox = (Button)target;
        //        this.btncashbox.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 13:
        //        this.btnManageCamera = (Button)target;
        //        this.btnManageCamera.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 14:
        //        this.btnManageProduct = (Button)target;
        //        goto IL_255;
        //    case 15:
        //        this.btnPrntMgr = (Button)target;
        //        this.btnPrntMgr.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 16:
        //        this.btnSystemprinterqueue = (Button)target;
        //        this.btnSystemprinterqueue.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 17:
        //        this.btnFinancialReport = (Button)target;
        //        this.btnFinancialReport.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 18:
        //        this.btnRefund = (Button)target;
        //        this.btnRefund.Click += new RoutedEventHandler(this.Button_Click);
        //        if (3 != 0)
        //        {
        //            return;
        //        }
        //        goto IL_523;
        //    case 19:
        //        if (2 != 0)
        //        {
        //            this.btnHealthChkup = (Button)target;
        //            this.btnHealthChkup.Click += new RoutedEventHandler(this.Button_Click);
        //            if (!false)
        //            {
        //                return;
        //            }
        //            goto IL_5FC;
        //        }
        //        break;
        //    case 20:
        //        this.btnRemapPrinters = (Button)target;
        //        this.btnRemapPrinters.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 21:
        //        this.btnShutDown = (Button)target;
        //        this.btnShutDown.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 22:
        //        this.btnMinimizeApp = (Button)target;
        //        this.btnMinimizeApp.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 23:
        //        this.btnManageStores = (Button)target;
        //        this.btnManageStores.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 24:
        //        this.btnCleargroup = (Button)target;
        //        this.btnCleargroup.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 25:
        //        this.btnPrinterQueue = (Button)target;
        //        this.btnPrinterQueue.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 26:
        //        this.btnBurnOrders = (Button)target;
        //        this.btnBurnOrders.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 27:
        //        do
        //        {
        //            this.btnsynstatus = (Button)target;
        //        }
        //        while (false);
        //        this.btnsynstatus.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 28:
        //        this.btnCardType = (Button)target;
        //        this.btnCardType.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 29:
        //        this.btnManageDevice = (Button)target;
        //        if (false)
        //        {
        //            goto IL_255;
        //        }
        //        this.btnManageDevice.Click += new RoutedEventHandler(this.Button_Click);
        //        if (2 != 0)
        //        {
        //            return;
        //        }
        //        goto IL_59E;
        //    case 30:
        //        this.btnRFIDMatch = (Button)target;
        //        this.btnRFIDMatch.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 31:
        //        goto IL_523;
        //    case 32:
        //        this.btnReceiptReprint = (Button)target;
        //        this.btnReceiptReprint.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 33:
        //        this.btnEmailStatus = (Button)target;
        //        this.btnEmailStatus.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 34:
        //        goto IL_59E;
        //    case 35:
        //        this.btnUpldMasterData = (Button)target;
        //        this.btnUpldMasterData.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 36:
        //        this.btnBack = (Button)target;
        //        goto IL_5FC;
        //    case 37:
        //        this.btnEnableTaskbar = (Button)target;
        //        this.btnEnableTaskbar.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 38:
        //        this.btnUserName = (Button)target;
        //        return;
        //    case 39:
        //        this.txbUserName = (TextBlock)target;
        //        return;
        //    case 40:
        //        this.txbStoreName = (TextBlock)target;
        //        return;
        //    case 41:
        //        this.btnLogout = (Button)target;
        //        this.btnLogout.Click += new RoutedEventHandler(this.Button_Click);
        //        return;
        //    case 42:
        //        this.mycontrol = (Grid)target;
        //        return;
        //    default:
        //        this._contentLoaded = true;
        //        return;
        //    }
        //    this.btnConfig = (Button)target;
        //    this.btnConfig.Click += new RoutedEventHandler(this.Button_Click);
        //    return;
        //    IL_255:
        //    this.btnManageProduct.Click += new RoutedEventHandler(this.Button_Click);
        //    return;
        //    IL_523:
        //    this.btnHelp = (Button)target;
        //    this.btnHelp.Click += new RoutedEventHandler(this.Button_Click);
        //    return;
        //    IL_59E:
        //    this.btnCurrencyExchange = (Button)target;
        //    this.btnCurrencyExchange.Click += new RoutedEventHandler(this.Button_Click);
        //    return;
        //    IL_5FC:
        //    this.btnBack.Click += new RoutedEventHandler(this.Button_Click);
        //}
	}
}
