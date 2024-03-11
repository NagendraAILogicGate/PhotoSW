using DigiAuditLogger;
using Digiphoto.Cache.Cache;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Manage;
using ErrorHandler;
using FrameworkHelper.Common;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using PhotoSW.ViewModels;
using PhotoSW.CF.DataLayer.BAL;
using System.Windows.Media;
//using DigiPhoto;

namespace PhotoSW.Views
{
    public partial class Login : Window, IComponentConnector
    {
        private delegate void LoadTabDelegate();

        private delegate void ClearCacheDelegate();

        private int _countAttempt = 0;

        private bool IsCapsOn = false;

        private ConfigBusiness _configBusiness;

        private UserBusiness _userBusiness;
        private baUser _user;

        private string _controlOn;



        // private bool _contentLoaded;

        public Login()
        {
            this.InitializeComponent();
            this.ClearControls();
            local();
            if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "db\\"))
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "db\\");
            PhotoSW.CF.DataLayer.CF_Common.Common.MargeLocalDB();
            // base.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Login.ClearCacheDelegate(this.clearCache));
            RobotImageLoader.GetConfigData();
            RobotImageLoader.Is9ImgViewActive = true;
            this.tbDigiVersion.Text = "Version: PhotoSW " + this.CurrentRegistryVersion();
            this.btnLogin.IsDefault = true;
            var vals = System.Configuration.ConfigurationManager.AppSettings.GetValues("Env");
            if (vals !=null && vals.Contains("dev"))
            {
                this.txtUserName.Text = "Test05";
                this.txtPassword.Password = "123456";
            }
        }
        private void local()
        {
            ClientView clientView = null;
            foreach (Window window in System.Windows.Application.Current.Windows)
            {
                if (window.Title == "ClientView")
                {
                    clientView = (ClientView)window;
                }
            }
            if (clientView != null)
            {
                clientView.WindowStartupLocation = WindowStartupLocation.Manual;
                clientView.DefaultView = true;
                clientView.ChildImage = new System.Windows.Media.Imaging.BitmapImage(new Uri("/images/all_frames_new.png", UriKind.Relative));
            }
            else
            {
                clientView = new ClientView();
                clientView.WindowStartupLocation = WindowStartupLocation.Manual;
                clientView.DefaultView = true;
                clientView.ChildImage = new System.Windows.Media.Imaging.BitmapImage(new Uri("/images/all_frames_new.png", UriKind.Relative));
            }
            System.Windows.Forms.Screen[] allScreens = System.Windows.Forms.Screen.AllScreens;
            if (allScreens.Length > 1)
            {
                if (allScreens[0].Primary)
                {
                    System.Windows.Forms.Screen screen = System.Windows.Forms.Screen.AllScreens[1];
                    System.Drawing.Rectangle workingArea = screen.WorkingArea;
                    clientView.Top = (double)workingArea.Top;
                    clientView.Left = (double)workingArea.Left;
                    clientView.Show();
                }
                else
                {
                    System.Drawing.Rectangle workingArea = allScreens[0].WorkingArea;
                    clientView.Top = (double)workingArea.Top;
                    clientView.Left = (double)workingArea.Left;
                    clientView.Show();
                }
            }
            else
            {
                clientView.Show();
            }
        }
        private void clearCache()
        {
            try
            {
                CacheHelper.ClearAllCache();
            }
            catch
            {
            }
        }

        private string CurrentRegistryVersion()
        {
            ModifyRegistry modifyRegistry = new ModifyRegistry();
            return modifyRegistry.Read("InstallVersion");
        }

        private void ClearControls()
        {
            if (-1 == 0)
            {
                goto IL_40;
            }
            PasswordBox expr_06 = this.txtPassword;
            string expr_0B = string.Empty;
            if (4 != 0)
            {
                expr_06.Password = expr_0B;
            }
        IL_15:
        IL_16:
            this.txtUserName.Text = string.Empty;
            this.txtUserName.Focus();
            TextBlock expr_31 = this.txbErrorMessage;
            string expr_36 = string.Empty;
            if (!false)
            {
                expr_31.Text = expr_36;
            }
        IL_40:
            if (5 == 0)
            {
                goto IL_15;
            }
            if (!false)
            {
                return;
            }
            goto IL_16;
        }

        private bool Isvalidate()
        {
            bool result;
            if (8 != 0)
            {
                bool arg_1C_0 = string.IsNullOrWhiteSpace(this.txtUserName.Text);
                int arg_1C_1 = 0;
                bool flag;
                bool arg_6D_0;
                int expr_60;
                int expr_66;
                while (true)
                {
                    flag = ((arg_1C_0 ? 1 : 0) == arg_1C_1);
                    bool expr_B8 = arg_6D_0 = flag;
                    if (false)
                    {
                        goto IL_6D;
                    }
                    if (!expr_B8)
                    {
                        break;
                    }
                    expr_60 = ((arg_1C_0 = string.IsNullOrWhiteSpace(this.txtPassword.Password)) ? 1 : 0);
                    expr_66 = (arg_1C_1 = 0);
                    if (expr_66 == 0)
                    {
                        goto Block_5;
                    }
                }
                this.ShowErrorMessage("Please enter username");
            IL_3E:
                this.txtUserName.Focus();
                if (8 != 0)
                {
                    result = false;
                    return result;
                }
                goto IL_6C;
            Block_5:
                flag = (expr_60 == expr_66);
            IL_6C:
                arg_6D_0 = flag;
            IL_6D:
                if (!arg_6D_0)
                {
                    if (3 != 0)
                    {
                        this.ShowErrorMessage("Please enter password");
                        this.txtPassword.Focus();
                        goto IL_8B;
                    }
                }
                else
                {
                    if (7 == 0)
                    {
                        goto IL_3E;
                    }
                    result = true;
                }
                return result;
            }
        IL_8B:
            result = false;
            return result;
        }
        private UsersInfo GetUsersInfoDetails(baUser user)
        {
            UsersInfo usersinfo = new UsersInfo();

            // usersinfo.CountryCode =user.CountryCode;


            usersinfo.DG_Location_ID = user.Location_ID;
            //////
            usersinfo.DG_Location_Name = "bhopal";
            usersinfo.DG_Location_pkey = 11;
            usersinfo.DG_Store_ID = 1;
            usersinfo.DG_Store_Name = "Bhopal";
            usersinfo.DG_Substore_ID = 3;
            usersinfo.DG_User_CreatedDate = DateTime.Now;

            /////
            usersinfo.DG_User_Email = user.User_Email;
            usersinfo.DG_User_First_Name = user.User_First_Name;
            usersinfo.DG_User_Last_Name = user.User_Last_Name;
            usersinfo.DG_User_Name = user.User_Name;
            usersinfo.DG_User_Password = user.User_Password;
            usersinfo.DG_User_PhoneNo = user.User_PhoneNo;
            usersinfo.DG_User_pkey = user.User_pkey;
            usersinfo.DG_User_Role = "Admin";////user.User_Role;
            usersinfo.DG_User_Roles_Id = user.User_Roles_Id;
            usersinfo.DG_User_Status = user.User_Status;
            ///////////////
            usersinfo.IsSynced = true; //user.IsSynced;
            usersinfo.ServerHotFolderPath = "";// user.ServerHotFolderPath;
            usersinfo.StatusName = "";// user.StatusName;
            usersinfo.StoreCode = "001";//user.StoreCode;
                                        /////////////
            usersinfo.SyncCode = user.SyncCode;
            usersinfo.UserFullName = user.User_First_Name + " " + user.User_Last_Name;
            usersinfo.UserName = user.User_Name;
            return usersinfo;
        }
        private void UserLogin()
        {

            bool flag = !this.Isvalidate();
            if (!flag)
            {
                try
                {////////
                    this._userBusiness = new UserBusiness();
                    //UsersInfo userDetails = this._userBusiness.GetUserDetails(this.txtUserName.Text, PhotoSW.ViewModels. CryptorEngine.Encrypt(this.txtPassword.Password, true));
                    this._user = new baUser();
                    baUser user = baUser.GetUserDetails(this.txtUserName.Text, this.txtPassword.Password);//PhotoSW.ViewModels.CryptorEngine.Encrypt(this.txtPassword.Password, true));
                    UsersInfo userDetails = user != null ? GetUsersInfoDetails(user) : null;
                    flag = (user == null);
                    if (flag)
                    {
                        this.ShowErrorMessage("Incorrect username or password");
                        this.txtUserName.Focus();
                        goto IL_18C;
                    }
                    ///////
                    LoginUser.StoreName = userDetails.DG_Store_Name;
                    int arg_1AE_0;
                    int arg_93_0;
                    int expr_79 = arg_93_0 = (arg_1AE_0 = userDetails.DG_User_pkey);
                    if (8 == 0)
                    {
                        goto IL_8D;
                    }
                    LoginUser.UserId = expr_79;
                IL_87:
                    arg_1AE_0 = (arg_93_0 = userDetails.DG_User_Roles_Id);
                IL_8D:
                    if (false)
                    {
                        goto IL_1AE;
                    }
                    LoginUser.RoleId = arg_93_0;
                IL_98:
                    if (false)
                    {
                        goto IL_87;
                    }
                    int arg_A8_0 = userDetails.DG_Store_ID;
                    if (6 == 0)
                    {
                        goto IL_18C;
                    }
                    LoginUser.StoreId = arg_A8_0;
                    LoginUser.UserName = (userDetails.DG_User_First_Name + " " + userDetails.DG_User_Last_Name).Trim();
                    LoginUser.Storecode = userDetails.StoreCode;
                    LoginUser.countrycode = userDetails.CountryCode;
                    LoginUser.ServerHotFolderPath = userDetails.ServerHotFolderPath;
                    if (4 == 0)
                    {
                        goto IL_1B0;
                    }
                    this.ReadSubStore();
                    Home home = new Home();
                    home.Show();
                //AuditLog.AddUserLog(userDetails.DG_User_pkey, 38, "Logged in ");
                //AuditLog.AddUserLog(11, 38, "Logged in ");
                IL_11F:
                    try
                    {
                        this.SetAnonymousQrCodeEnableStatus(LoginUser.SubStoreId);
                        base.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Login.LoadTabDelegate(this.LoadTabData));
                    }
                    catch
                    {
                    }
                    base.Close();
                    if (5 != 0)
                    {
                        home.Focus();
                        home.Activate();
                        this.SetCurrencyProfile();
                        goto IL_19C;
                    }
                    goto IL_98;
                IL_18C:
                    this._countAttempt++;
                IL_19C:
                    int expr_19D = this._countAttempt;
                    if (3 == 0)
                    {
                        goto IL_11F;
                    }
                    arg_1AE_0 = ((expr_19D != 3) ? 1 : 0);
                IL_1AE:
                    flag = (arg_1AE_0 != 0);
                IL_1B0:
                    if (!flag)
                    {
                        AuditLog.AddUserLog(LoginUser.UserId, 45, "Unauthorized access attempted from " + Environment.MachineName);
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    MessageBox.Show("Could not connect to database! Please check error log for more details.");
                }
            }
        }

        private void LoadTabData()
        {
            Configuration.Instance = null;
            Configuration arg_18_0 = Configuration.Instance;
        }

        private void ShowErrorMessage(string strMessage)
        {
            this.txbErrorMessage.Text = strMessage;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                do
                {
                    this.UserLogin();
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

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (4 == 0)
                {
                    goto IL_25;
                }
                bool arg_0D_0 = e.Key == Key.Return;
                bool expr_37;
                do
                {
                    bool flag = !arg_0D_0;
                    expr_37 = (arg_0D_0 = flag);
                }
                while (2 == 0);
                if (expr_37)
                {
                    goto IL_24;
                }
            IL_18:
                if (8 != 0 && !false)
                {
                    this.UserLogin();
                }
            IL_24:
            IL_25:
                if (7 == 0)
                {
                    goto IL_18;
                }
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

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (4 == 0)
                {
                    goto IL_25;
                }
                bool arg_0D_0 = e.Key == Key.Return;
                bool expr_37;
                do
                {
                    bool flag = !arg_0D_0;
                    expr_37 = (arg_0D_0 = flag);
                }
                while (2 == 0);
                if (expr_37)
                {
                    goto IL_24;
                }
            IL_18:
                if (8 != 0 && !false)
                {
                    this.UserLogin();
                }
            IL_24:
            IL_25:
                if (7 == 0)
                {
                    goto IL_18;
                }


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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                Button button = new Button();
                Button expr_10 = (Button)sender;
                if (!false)
                {
                    button = expr_10;
                }
                string text = button.Content.ToString();
                if (text == null)
                {
                    goto IL_199;
                }
                if (text == "ENTER")
                {
                    break;
                }
                if (text == "SPACE")
                {
                    goto IL_80;
                }
                if (text == "CLOSE")
                {
                    //  goto IL_A7;
                }
                if (!(text == "Back"))
                {
                    goto IL_199;
                }
                bool arg_CC_0 = this._controlOn == "UserName";
                int arg_CC_1 = 0;
                bool flag;
                int arg_E7_0;
                int expr_12F;
                int expr_135;
                while (true)
                {
                    flag = ((arg_CC_0 ? 1 : 0) == arg_CC_1);
                    bool expr_CF = (arg_E7_0 = (flag ? 1 : 0)) != 0;
                    if (!true)
                    {
                        break;
                    }
                    if (!expr_CF)
                    {
                        goto Block_6;
                    }
                    expr_12F = ((arg_CC_0 = (this._controlOn == "Password")) ? 1 : 0);
                    expr_135 = (arg_CC_1 = 0);
                    if (expr_135 == 0)
                    {
                        goto Block_8;
                    }
                }
            IL_E6:
                flag = (arg_E7_0 <= 0);
                goto IL_ED;
            Block_8:
                flag = (expr_12F == expr_135);
                bool arg_13C_0 = flag;
                while (!arg_13C_0)
                {
                    flag = (this.txtPassword.Password.Length <= 0);
                    bool expr_156 = arg_13C_0 = flag;
                    if (4 != 0)
                    {
                        if (!expr_156)
                        {
                            this.txtPassword.Password = this.txtPassword.Password.Remove(this.txtPassword.Password.Length - 1, 1);
                        }
                        break;
                    }
                }
                goto IL_18E;
            Block_6:
                arg_E7_0 = this.txtUserName.Text.Length;
                goto IL_E6;
            IL_18E:
                if (!false)
                {
                    return;
                }
                continue;
            IL_122:
                goto IL_18E;
            IL_ED:
                if (!flag)
                {
                    this.txtUserName.Text = this.txtUserName.Text.Remove(this.txtUserName.Text.Length - 1, 1);
                }
                goto IL_122;
            IL_199:
                flag = !(this._controlOn == "UserName");
                if (!flag)
                {
                    this.txtUserName.Text = this.txtUserName.Text + button.Content;
                    if (2 != 0)
                    {
                        return;
                    }
                    goto IL_122;
                }
                else
                {
                    bool arg_1F5_0;
                    bool expr_1EE = arg_1F5_0 = !(this._controlOn == "Password");
                    if (!false)
                    {
                        flag = expr_1EE;
                        arg_1F5_0 = flag;
                    }
                    if (arg_1F5_0)
                    {
                        return;
                    }
                    this.txtPassword.Password = this.txtPassword.Password + button.Content;
                    if (5 != 0)
                    {
                        return;
                    }
                    goto IL_ED;
                }
            }
            this.UserLogin();
            return;
        IL_80:
            this.txtUserName.Text = this.txtUserName.Text + " ";
            return;
            //  IL_A7:

            // this.KeyBorder.Visibility = Visibility.Collapsed;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            vb1.Stretch = Stretch.Fill;
            vb1.Width = this.Width;
            vb1.Height = this.Height;
        }

        private void txtUserName_GotFocus(object sender, RoutedEventArgs e)
        {
            //   this.KeyBorder.Visibility = Visibility.Visible;
            this._controlOn = "UserName";
        }

        private void txtPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            // this.KeyBorder.Visibility = Visibility.Visible;
            this._controlOn = "Password";
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.btnLogin.Click -= new RoutedEventHandler(this.btnLogin_Click);
            this.txtPassword.GotFocus -= new RoutedEventHandler(this.txtPassword_GotFocus);
            this.txtUserName.GotFocus -= new RoutedEventHandler(this.txtUserName_GotFocus);
            this.txtPassword.KeyDown -= new KeyEventHandler(this.txtPassword_KeyDown);
            this.txtUserName.KeyDown -= new KeyEventHandler(this.txtUserName_KeyDown);
        }

        public void SetAnonymousQrCodeEnableStatus(int substoreId)
        {
            try
            {
                this._configBusiness = new ConfigBusiness();
                List<iMIXConfigurationInfo> expr_1BE = this._configBusiness.GetNewConfigValues(substoreId);
                List<iMIXConfigurationInfo> list;
                if (!false)
                {
                    list = expr_1BE;
                }
                int arg_4A_0;
                if (list == null)
                {
                    arg_4A_0 = 1;
                    goto IL_49;
                }
                int arg_95_0 = arg_4A_0 = ((list.Count <= 0) ? 1 : 0);
                if (4 != 0)
                {
                    goto IL_49;
                }
                iMIXConfigurationInfo iMIXConfigurationInfo;
                iMIXConfigurationInfo iMIXConfigurationInfo2;
                int expr_105;
                do
                {
                IL_94:
                    if (arg_95_0 == 0)
                    {
                        if (2 == 0)
                        {
                            goto IL_141;
                        }
                        App.IsAnonymousQrCodeEnabled = Convert.ToBoolean(iMIXConfigurationInfo.ConfigurationValue);
                    }
                    iMIXConfigurationInfo2 = list.FirstOrDefault((iMIXConfigurationInfo o) => o.IMIXConfigurationMasterId == 49L);
                    if (iMIXConfigurationInfo2 != null && !string.IsNullOrEmpty(iMIXConfigurationInfo2.ConfigurationValue))
                    {
                        goto IL_EF;
                    }
                    expr_105 = (arg_95_0 = 0);
                }
                while (expr_105 != 0);
                App.IsRFIDEnabled = (expr_105 != 0);
                goto IL_111;
            IL_49:
                int arg_188_0;
                if (arg_4A_0 != 0)
                {
                    App.IsRFIDEnabled = false;
                    arg_188_0 = 0;
                    goto IL_188;
                }
                while (false)
                {
                }
                iMIXConfigurationInfo = list.FirstOrDefault((iMIXConfigurationInfo o) => o.IMIXConfigurationMasterId == 38L);
                if (iMIXConfigurationInfo == null)
                {
                    arg_95_0 = 1;
                    //goto IL_94;
                }
                if (!false)
                {
                    if (iMIXConfigurationInfo == null)
                        iMIXConfigurationInfo = new IMIX.Model.iMIXConfigurationInfo();

                    arg_95_0 = (string.IsNullOrEmpty(iMIXConfigurationInfo.ConfigurationValue) ? 1 : 0);
                    // goto IL_94;
                }
                goto IL_17E;
            IL_EF:
                App.IsRFIDEnabled = Convert.ToBoolean(iMIXConfigurationInfo2.ConfigurationValue);
            IL_111:
                iMIXConfigurationInfo iMIXConfigurationInfo3 = list.FirstOrDefault((iMIXConfigurationInfo o) => o.IMIXConfigurationMasterId == 50L);
                bool expr_137 = (arg_188_0 = (App.IsRFIDEnabled ? 1 : 0)) != 0;
                if (false)
                {
                    goto IL_188;
                }
                if (!expr_137)
                {
                    goto IL_151;
                }
            IL_141:
                bool arg_153_0;
                if (iMIXConfigurationInfo3 != null)
                {
                    arg_153_0 = string.IsNullOrEmpty(iMIXConfigurationInfo3.ConfigurationValue);
                    goto IL_152;
                }
            IL_151:
                arg_153_0 = true;
            IL_152:
                if (!arg_153_0)
                {
                    App.RfidScanType = new int?(Convert.ToInt32(iMIXConfigurationInfo3.ConfigurationValue));
                }
                else
                {
                    App.RfidScanType = null;
                }
            IL_17E:
                goto IL_199;
            IL_188:
                App.IsAnonymousQrCodeEnabled = (arg_188_0 != 0);
                App.RfidScanType = null;
            IL_199:
                if (8 == 0)
                {
                    goto IL_EF;
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void ReadSubStore()
        {
            try
            {
                if (!false)
                {
                }
                string currentDirectory;
                do
                {
                    currentDirectory = Environment.CurrentDirectory;
                    if (File.Exists(currentDirectory + "\\ss.dat"))
                    {
                        goto IL_37;
                    }
                }
                while (false);
                return;
            IL_37:
                StreamReader streamReader = new StreamReader(currentDirectory + "\\ss.dat");
                try
                {
                    do
                    {
                        string cipherString = streamReader.ReadLine();
                        if (4 != 0)
                        {
                            string text = PhotoSW.CryptorEngine.Decrypt(cipherString, true);
                            LoginUser.SubStoreId = Convert.ToInt32(text.Split(new char[]
                            {
                                ','
                            })[0]);
                        }
                    }
                    while (false);
                }
                finally
                {
                    if (streamReader != null)
                    {
                        ((IDisposable)streamReader).Dispose();
                    }
                IL_98:
                    if (-1 == 0)
                    {
                        goto IL_98;
                    }
                }
            }
            catch (Exception serviceException)
            {
                while (false)
                {
                }
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void btnCapsLock_Click(object sender, RoutedEventArgs e)
        {
            if (!true)
            {
                goto IL_1B;
            }
            if (!false)
            {
            }
        IL_07:
            if (3 == 0)
            {
                return;
            }
            this.IsCapsOn = !this.IsCapsOn;
        IL_1B:
            //   this.ToggleKey();
            if (8 == 0)
            {
                goto IL_07;
            }
        }

        //private void ToggleKey ()
        //    {
        //    if(7 != 0)
        //        {
        //        if(this.IsCapsOn)
        //            {
        //            this.btnA.Content = "A";
        //            ContentControl expr_3E = this.btnB;
        //            object expr_43 = "B";
        //            if(6 != 0)
        //                {
        //                expr_3E.Content = expr_43;
        //                }
        //            this.btnC.Content = "C";
        //            this.btnD.Content = "D";
        //            this.btnE.Content = "E";
        //            this.btnF.Content = "F";
        //            this.btnG.Content = "G";
        //            this.btnH.Content = "H";
        //            this.btnI.Content = "I";
        //            this.btnJ.Content = "J";
        //            if(!false)
        //                {
        //                this.btnK.Content = "K";
        //                this.btnL.Content = "L";
        //                this.btnM.Content = "M";
        //                this.btnN.Content = "N";
        //                this.btnO.Content = "O";
        //                }
        //            this.btnP.Content = "P";
        //            this.btnQ.Content = "Q";
        //            this.btnR.Content = "R";
        //            this.btnS.Content = "S";
        //            if(!false)
        //                {
        //                this.btnT.Content = "T";
        //                this.btnU.Content = "U";
        //                this.btnV.Content = "V";
        //                this.btnW.Content = "W";
        //                this.btnX.Content = "X";
        //                this.btnY.Content = "Y";
        //                this.btnZ.Content = "Z";
        //                return;
        //                }
        //            return;
        //            }
        //        else
        //            {
        //            this.btnA.Content = "a";
        //            this.btnB.Content = "b";
        //            this.btnC.Content = "c";
        //            this.btnD.Content = "d";
        //            this.btnE.Content = "e";
        //            this.btnF.Content = "f";
        //            this.btnG.Content = "g";
        //            this.btnH.Content = "h";
        //            this.btnI.Content = "i";
        //            }
        //        }
        //    this.btnJ.Content = "j";
        //    this.btnK.Content = "k";
        //    this.btnL.Content = "l";
        //    this.btnM.Content = "m";
        //    this.btnN.Content = "n";
        //    this.btnO.Content = "o";
        //    this.btnP.Content = "p";
        //    this.btnQ.Content = "q";
        //    this.btnR.Content = "r";
        //    this.btnS.Content = "s";
        //    this.btnT.Content = "t";
        //    this.btnU.Content = "u";
        //    this.btnV.Content = "v";
        //    this.btnW.Content = "w";
        //    this.btnX.Content = "x";
        //    this.btnY.Content = "y";
        //    this.btnZ.Content = "z";
        //    }

        public void SetCurrencyProfile()
        {
            if (-1 != 0)
            {
                try
                {
                    new CurrencyExchangeBussiness().UpdateInsertProfile((long)LoginUser.UserId);
                    if (4 == 0)
                    {
                    }
                    while (false)
                    {
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    if (!false && !false)
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
            }
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
        //    IL_1A:
        //        this._contentLoaded = true;
        //        while (6 != 0)
        //        {
        //            Uri resourceLocator = new Uri("/DigiPhoto;component/login.xaml", UriKind.Relative);
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
        //    IL_14:
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
        //        case 1:
        //            {
        //                ((Login)target).Loaded += new RoutedEventHandler(this.Window_Loaded);
        //                Window expr_151 = (Login)target;
        //                EventHandler expr_161 = new EventHandler(this.Window_Closed);
        //                if (8 != 0)
        //                {
        //                    expr_151.Closed += expr_161;
        //                }
        //                break;
        //            }
        //        case 2:
        //            this.KEYBOARDStoryboard = (BeginStoryboard)target;
        //            break;
        //        case 3:
        //            this.vb1 = (Viewbox)target;
        //            break;
        //        case 4:
        //            this.bg_withlogo = (StackPanel)target;
        //            break;
        //        case 5:
        //            this.bg = (Image)target;
        //            break;
        //        case 6:
        //            this.frame = (Viewbox)target;
        //            break;
        //        case 7:
        //            this.frameimage = (Image)target;
        //            break;
        //        case 8:
        //            this.grid1 = (Grid)target;
        //            break;
        //        case 9:
        //            this.grid = (Grid)target;
        //            break;
        //        case 10:
        //            this.txbErrorMessage = (TextBlock)target;
        //            break;
        //        case 11:
        //            this.txtUserName = (TextBox)target;
        //            this.txtUserName.KeyDown += new KeyEventHandler(this.txtUserName_KeyDown);
        //            this.txtUserName.GotFocus += new RoutedEventHandler(this.txtUserName_GotFocus);
        //            break;
        //        case 12:
        //            this.txtPassword = (PasswordBox)target;
        //            this.txtPassword.KeyDown += new KeyEventHandler(this.txtPassword_KeyDown);
        //            this.txtPassword.GotFocus += new RoutedEventHandler(this.txtPassword_GotFocus);
        //            break;
        //        case 13:
        //            this.btnLogin = (Button)target;
        //            this.btnLogin.Click += new RoutedEventHandler(this.btnLogin_Click);
        //            break;
        //        case 14:
        //            this.viewbox = (Viewbox)target;
        //            break;
        //        case 15:
        //            this.pnlMain = (ContentControl)target;
        //            break;
        //        case 16:
        //            this.KeyBorder = (Border)target;
        //            break;
        //        case 17:
        //            this.btnQ = (Button)target;
        //            this.btnQ.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 18:
        //            this.btnW = (Button)target;
        //            this.btnW.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 19:
        //            this.btnE = (Button)target;
        //            this.btnE.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 20:
        //            this.btnR = (Button)target;
        //            this.btnR.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 21:
        //            this.btnT = (Button)target;
        //            this.btnT.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 22:
        //            this.btnY = (Button)target;
        //            this.btnY.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 23:
        //            this.btnU = (Button)target;
        //            this.btnU.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 24:
        //            this.btnI = (Button)target;
        //            this.btnI.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 25:
        //            this.btnO = (Button)target;
        //            this.btnO.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 26:
        //            this.btnP = (Button)target;
        //            this.btnP.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 27:
        //            this.Delete = (Button)target;
        //            this.Delete.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 28:
        //            this.btnA = (Button)target;
        //            this.btnA.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 29:
        //            this.btnS = (Button)target;
        //            this.btnS.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 30:
        //            this.btnD = (Button)target;
        //            this.btnD.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 31:
        //            this.btnF = (Button)target;
        //            this.btnF.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 32:
        //            this.btnG = (Button)target;
        //            if (-1 != 0)
        //            {
        //                this.btnG.Click += new RoutedEventHandler(this.btn_Click);
        //            }
        //            break;
        //        case 33:
        //            this.btnH = (Button)target;
        //            this.btnH.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 34:
        //            this.btnJ = (Button)target;
        //            this.btnJ.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 35:
        //            this.btnK = (Button)target;
        //            this.btnK.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 36:
        //            this.btnL = (Button)target;
        //            this.btnL.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 37:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 38:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 39:
        //            this.btnZ = (Button)target;
        //            this.btnZ.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 40:
        //            this.btnX = (Button)target;
        //            this.btnX.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 41:
        //            this.btnC = (Button)target;
        //            this.btnC.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 42:
        //            this.btnV = (Button)target;
        //            this.btnV.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 43:
        //            this.btnB = (Button)target;
        //            this.btnB.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 44:
        //            this.btnN = (Button)target;
        //            this.btnN.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 45:
        //            this.btnM = (Button)target;
        //            this.btnM.Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 46:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 47:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 48:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 49:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 50:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 51:
        //            ((Button)target).Click += new RoutedEventHandler(this.btnCapsLock_Click);
        //            break;
        //        case 52:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 53:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 54:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 55:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 56:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 57:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 58:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 59:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 60:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 61:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 62:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 63:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 64:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 65:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 66:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 67:
        //            ((Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //            break;
        //        case 68:
        //            this.tbDigiVersion = (TextBlock)target;
        //            break;
        //        default:
        //            this._contentLoaded = true;
        //            break;
        //    }
        //}
    }
}
