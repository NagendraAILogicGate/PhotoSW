using PhotoSW.Common;
using DigiPhoto.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.Data;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using MetadataExtractor;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xml.Linq;
using PhotoSW.Views;
using PhotoSW.DataLayer;
using PhotoSW.CF.DataLayer.BAL;

namespace PhotoSW.PSControls
{
    public partial class ManualDownload : UserControl, IComponentConnector
    {
        private const string _rootPath = "\\";

        private bool _IsEnabledSessionSelect = false;

        private bool _IsEnabledSelectEndPoint = false;

        public int _locationId = 0;

        public int _substoreId = 0;

        public static int _photogrpherIdS;

        public static long _startingNoS;

        public static int _locationIdS;

        public static int _substoreIdS;

        private Dictionary<string, string> lstSubStore;

        private string _BorderFolder;

        private string _Directoryname = string.Empty;

        private bool _is_SemiOrder;

        private BackgroundWorker bwProgress = new BackgroundWorker();

        private string _path = string.Empty;

        private char valueSeparator = '-';

        private UIElement _parent;

        private bool _hideRequest = false;

        private string _result;

        private bool? _IsAutoRotate;

        private static int _count = 0;

        private Dictionary<string, int> _locationList;

        private List<MyImageClass> imagelist;

        private bool _IsBarcodeActive = false;

        private int _MappingType = 0;

        private int _scanType = 0;

        private bool _IsDelete = false;

        private bool _IsAnonymousCodeActive = false;

        private string _QRWebURLReplace = string.Empty;

        private Dictionary<string, int> _photoGrapherList;

        public Hashtable htVidL = new Hashtable();

        private string _thumbnailsPath = string.Empty;

        private string _filepath;

        private string _filepathdate;

        private string _thumbnailFilePathDate;

        private string _bigThumbnailFilePathDate;

        private long _photoNo;

        private string _photographerId = string.Empty;

        private int _locationid;

        private int _subStoreid;

        private int _characterid;

        private string _networkPath = "\\\\192.168.29.179\\DigiImages\\ManualDownload";

        private string _networkBackupPath = "\\\\192.168.29.179\\DigiImages\\ManualDownlaodBackup";

        private List<PhotoGraphersInfo> lstUsers;

        private BackgroundWorker _manualDownloadWorkerProcessor = new BackgroundWorker();

        private string filepath;

        private bool isAutoVideoProcessingActive = false;

        public bool _isEnabledImageEditingMDownload = false;

        private static volatile object _object = new object();

        private static volatile object _object1 = new object();

        private int CountImagesDownload = 0;

        private int needrotaion = 0;

        private string PhotoLayer = null;

       

        public List<MyImageClass> Imagelist
        {
            get
            {
                return this.imagelist;
            }
            set
            {
                this.imagelist = value;
            }
        }

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

        public Dictionary<string, int> PhotoGrapherList
        {
            get
            {
                return this._photoGrapherList;
            }
            set
            {
                this._photoGrapherList = value;
            }
        }

        public string ImageMetaData
        {
            get;
            set;
        }

        public string DefaultEffects
        {
            get;
            set;
        }

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        public ManualDownload()
        {
            try
            {
                this.InitializeComponent();
                this.MsgBox.SetParent(this.MainPanel);
                this.DownloadProgress.Minimum = 0.0;
                ManualDownload._count = 0;
                this.btnDownload.Content = "Download";
                this.lstUsers = new  UserBusiness().GetPhotoGraphersList(LoginUser.StoreId);
                CommonUtility.BindComboWithSelect<PhotoGraphersInfo>(this.CmbPhotographerNo, this.lstUsers, "DG_User_Name", "DG_User_pkey", 0, ClientConstant.SelectString);
                this.CmbPhotographerNo.SelectedValue = "0";
                LocationBusniess locationBusniess = new LocationBusniess();
                List<LocationInfo> locationList = locationBusniess.GetLocationList(LoginUser.StoreId);
                CharacterBusiness characterBusiness = new CharacterBusiness();
                List<CharacterInfo> character = characterBusiness.GetCharacter();
                CommonUtility.BindComboWithSelect<LocationInfo>(this.CmbLocation, locationList, "DG_Location_Name", "DG_Location_pkey", 0, ClientConstant.SelectString);
                this.CmbLocation.SelectedValue = "0";
             //   CommonUtility.BindComboWithSelect<CharacterInfo>(this.CmbCharacter, character, "DG_Character_Name", "DG_Character_Pkey", 0, ClientConstant.SelectString);
             //   this.CmbCharacter.SelectedValue = "0";
                this.lstSubStore = new Dictionary<string, string>();
                foreach (SubStoresInfo current in new LocationBusniess().GetSubstoreData())
                {
                    this.lstSubStore.Add(current.DG_SubStore_Name, current.DG_SubStore_pkey.ToString());
                }
                this.CmbSubstore.ItemsSource = this.lstSubStore;
                this.CmbSubstore.SelectedValue = LoginUser.SubStoreId.ToString();
               ConfigurationInfo configurationData = new ConfigBusiness().GetConfigurationData(LoginUser.SubStoreId);
                this._QRWebURLReplace = locationBusniess.GetQRCodeWebUrl();
                this._filepath = configurationData.DG_Hot_Folder_Path;
                this._filepathdate = Path.Combine(this._filepath, DateTime.Now.ToString("yyyyMMdd"));
                this._thumbnailFilePathDate = Path.Combine(this._filepath, "Thumbnails", DateTime.Now.ToString("yyyyMMdd"));
                this._bigThumbnailFilePathDate = Path.Combine(this._filepath, "Thumbnails_Big", DateTime.Now.ToString("yyyyMMdd"));
                if (!System.IO.Directory.Exists(this._filepathdate))
                {
                    System.IO.Directory.CreateDirectory(this._filepathdate);
                }
                if (!System.IO.Directory.Exists(this._thumbnailFilePathDate))
                {
                    System.IO.Directory.CreateDirectory(this._thumbnailFilePathDate);
                }
                if (!System.IO.Directory.Exists(this._bigThumbnailFilePathDate))
                {
                    System.IO.Directory.CreateDirectory(this._bigThumbnailFilePathDate);
                }
                if (!System.IO.Directory.Exists(Path.Combine(this._filepath, "ManualDownload")))
                {
                    System.IO.Directory.CreateDirectory(Path.Combine(this._filepath, "ManualDownload"));
                }
                if (!System.IO.Directory.Exists(Path.Combine(this._filepath, "ManualDownloadBackup")))
                {
                    System.IO.Directory.CreateDirectory(Path.Combine(this._filepath, "ManualDownloadBackup"));
                }
                this._BorderFolder = configurationData.DG_Frame_Path;
                this._IsAutoRotate = configurationData.DG_IsAutoRotate;
                this._is_SemiOrder = configurationData.DG_SemiOrderMain.ToBoolean(false);
                this.showBeforeImage();
                this.bwProgress.DoWork += new DoWorkEventHandler(this.bwProgress_DoWork);
                this.bwProgress.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwProgress_RunWorkerCompleted);
                this.tbStartingNo.Text = GetLastPhotoID();
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private String GetLastPhotoID()
        {
            PhotoBusiness photoBusiness = new PhotoBusiness();
            return photoBusiness.GetStartNoPhotoInfo();
        }

        private void bwProgress_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void bwProgress_DoWork(object sender, DoWorkEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void showBeforeImage()
        {
            while (true)
            {
                this.btnOk.Visibility = Visibility.Visible;
                while (!false)
                {
                    if (false)
                    {
                        goto IL_4D;
                    }
                    this.btnDownload.Visibility = Visibility.Collapsed;
                    if (6 == 0)
                    {
                        goto IL_4D;
                    }
                    this.Lastimageno.Visibility = Visibility.Visible;
                    if (!false)
                    {
                        UIElement expr_30 = this.DownloadProgress;
                        Visibility expr_35 = Visibility.Collapsed;
                        if (!false)
                        {
                            expr_30.Visibility = expr_35;
                        }
                        if (!false)
                        {
                            goto Block_4;
                        }
                        break;
                    }
                }
            }
        Block_4:
            this.tblStartingNo.Visibility = Visibility.Visible;
        IL_4D:
            this.tbStartingNo.Visibility = Visibility.Visible;
        }

        private void showAfterImage()
        {
            this.btnOk.Visibility = Visibility.Collapsed;
            while (true)
            {
            IL_11:
                this.btnDownload.Visibility = Visibility.Visible;
                while (true)
                {
                    this.CmbPhotographerNo.IsEnabled = false;
                    this.CmbLocation.IsEnabled = false;
                    while (true)
                    {
                        while (true)
                        {
                            this.tbStartingNo.IsEnabled = false;
                            if (false)
                            {
                                return;
                            }
                            if (-1 != 0)
                            {
                                this.HideHandlerDialog();
                                do
                                {
                                    this.Lastimageno.Visibility = Visibility.Visible;
                                    if (false)
                                    {
                                        goto IL_11;
                                    }
                                }
                                while (false);
                                this.DownloadProgress.Visibility = Visibility.Visible;
                                this.tblStartingNo.Visibility = Visibility.Visible;
                                if (!false)
                                {
                                    goto Block_5;
                                }
                            }
                        }
                    }
                Block_5:
                    this.tbStartingNo.Visibility = Visibility.Visible;
                    if (6 != 0)
                    {
                        goto Block_6;
                    }
                }
            }
        Block_6:
            this.MainPanel.Height = 600.0;
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public string ShowHandlerDialog()
        {
            base.Visibility = Visibility.Visible;
            this._hideRequest = false;
            string result="";
            //while (true)
            //{
            //    int arg_99_0;
            //    int arg_50_0;
            //    int arg_4E_0;
            //    bool expr_8E = (arg_4E_0 = (arg_50_0 = (arg_99_0 = (this._hideRequest ? 1 : 0)))) != 0;
            //    if (!false)
            //    {
            //        arg_99_0 = ((!expr_8E) ? 1 : 0);
            //        goto IL_99;
            //    }
            //IL_47:
            //    bool flag;
            //    if (!false)
            //    {
            //        if (8 == 0)
            //        {
            //            goto IL_99;
            //        }
            //        flag = (arg_4E_0 != 0);
            //        arg_50_0 = (flag ? 1 : 0);
            //    }
            //    if (arg_50_0 == 0)
            //    {
            //        goto IL_A0;
            //    }
            //    base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
            //    {
            //    }));
            //    int arg_9B_0;
            //    int expr_83 = arg_9B_0 = 20;
            //    if (expr_83 != 0)
            //    {
            //        Thread.Sleep(expr_83);
            //        continue;
            //    }
            //IL_9B:
            //    if (arg_9B_0 == 0)
            //    {
            //        goto IL_A0;
            //    }
            //    if (!false)
            //    {
            //        arg_50_0 = (base.Dispatcher.HasShutdownStarted ? (arg_4E_0 = (arg_99_0 = 0)) : (arg_4E_0 = (arg_99_0 = ((!base.Dispatcher.HasShutdownFinished) ? 1 : 0))));
            //        goto IL_47;
            //    }
            //IL_A7:
            //    if (!false)
            //    {
            //        break;
            //    }
            //    continue;
            //IL_A0:
            //    result = this._result;
            //    goto IL_A7;
            //IL_99:
            //    flag = (arg_99_0 != 0);
            //    arg_9B_0 = (flag ? 1 : 0);
            //    goto IL_9B;
            //}
            return result;
        }
        //
        private void HideHandlerDialog()
        {
            do
            {
                try
                {
                    while (true)
                    {
                        this._hideRequest = true;
                        if (!false)
                        {
                            base.Visibility = Visibility.Collapsed;
                            if (6 != 0)
                            {
                            }
                            //this._parent.IsEnabled = true;
                            if (6 != 0)
                            {
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    if (!false)
                    {
                    }
                }
            }
            while (-1 == 0);
        }

        private void btnDownload_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (this.IsValidData())
                    {
                        this.btnDownload.IsEnabled = false;
                        do
                        {
                            while (true)
                            {
                                this.btnBack.IsEnabled = false;
                                string empty = string.Empty;
                                bool flag = !this.CheckForRFIDEnabled(out empty);
                                if (!flag)
                                {
                                    break;
                                }
                                if(4 != 0)
                                    {
                                    //  MessageBoxResult messageBoxResult = MessageBox.Show(empty + "\n Do you still want to continue?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                                    //  flag = (messageBoxResult != MessageBoxResult.Yes);
                                    flag = false;
                                    }
                                if (!flag)
                                {
                                    goto Block_8;
                                }
                                this.btnDownload.IsEnabled = true;
                                if (-1 != 0)
                                {
                                    goto Block_9;
                                }
                            }
                            this.MoveFiles();
                        }
                        while (4 == 0);
                        if (5 != 0)
                        {
                            goto IL_C1;
                        }
                        goto IL_D1;
                    Block_8:
                        this.MoveFiles();
                        goto IL_C0;
                    Block_9:
                        this.btnBack.IsEnabled = true;
                    IL_C0:
                    IL_C1: ;
                    }
                    else
                    {
                        MessageBox.Show("Please enter valid data");
                    }
                IL_D1: ;
                }
                catch (Exception serviceException)
                {
                    while (true)
                    {
                        this.btnDownload.IsEnabled = true;
                        this.btnBack.IsEnabled = true;
                        while (true)
                        {
                            ErrorHandler.ErrorHandler.LogError(serviceException);
                            if (8 == 0)
                            {
                                break;
                            }
                            if (8 != 0)
                            {
                                goto Block_11;
                            }
                        }
                    }
                Block_11: ;
                }
            }
            while (false);
        }

        private bool IsValidData()
        {
            bool expr_01 = true;
            bool flag;
            if (!false)
            {
                flag = expr_01;
            }
            bool arg_28_0 = this.CmbPhotographerNo.SelectedValue.ToString() == "0";
            bool result;
            while (true)
            {
            IL_27:
                bool expr_28 = !arg_28_0;
                bool flag2;
                if (!false)
                {
                    flag2 = expr_28;
                }
                if (!flag2)
                {
                    flag = false;
                    if (-1 != 0)
                    {
                    }
                }
                else
                {
                   flag2 = !(this.CmbLocation.SelectedValue.ToString() == "0");
                    bool expr_67 = arg_28_0 = flag2;
                    if (false)
                    {
                        continue;
                    }
                    if (!expr_67)
                    {
                        flag = false;
                    }
                }
            Block_5:
                try
                {
                    if (true)
                    {
                        this.tbStartingNo.Text.ToInt64(false);
                        
                    }
                }
                catch (Exception var_1_8A)
                {
                    do
                    {
                        flag = false;
                    }
                    while (6 == 0);
                }
                flag2 = !(this.tbStartingNo.Text.Trim() == "");
                while (true)
                {
                    bool expr_B3 = arg_28_0 = flag2;
                    if (7 == 0)
                    {
                        goto IL_27;
                    }
                    if (!expr_B3)
                    {
                        flag = false;
                    }
                    result = flag;
                    if (!false)
                    {
                        return result;
                    }
                }
                goto Block_5;
            }
            return result;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_18;
            }
            if (-1 == 0)
            {
                goto IL_1F;
            }
            bool arg_14_0 = this.btnOk.Visibility == Visibility.Visible;
        IL_13:
            bool flag = !arg_14_0;
        IL_18:
            bool expr_66 = arg_14_0 = flag;
            if (false)
            {
                goto IL_13;
            }
            if (expr_66)
            {
                ((ImageDownloader)Window.GetWindow(this)).isImageAcquired = false;
                this._result = string.Empty;
                this.HideHandlerDialog();
                return;
            }
        IL_1F:
            ((ImageDownloader)Window.GetWindow(this)).btnBack_Click(sender, e);
        }

        private void CmbPhotographerNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.CmbPhotographerNo.SelectedValue.ToInt32(false) <= 0)
            {
                this.Lastimageno.Text = string.Empty;
                if (6 != 0)
                {
                   this.CmbLocation.SelectedValue = 0;
                    this.CmbSubstore.IsEnabled = true;
                    this.CmbLocation.IsEnabled = true;
                    return;
                }
            }
            this.Lastimageno.Visibility = Visibility.Visible;
            try
            {
                int num = 0;
                int num2 = 0;
                if (this.GetRfidStatus(Convert.ToInt32(this.CmbPhotographerNo.SelectedValue), out num, out num2))
                {
                    this.CmbSubstore.SelectedValue = num2;
                    this.CmbLocation.SelectedValue = num;
                    this.CmbLocation.IsEnabled = false;
                }
                else
                {
                    this.CmbSubstore.SelectedValue = num2;
                    if (!false)
                    {
                        this.CmbLocation.SelectedValue = num;
                        this.CmbLocation.IsEnabled = true;
                        this.CmbSubstore.IsEnabled = true;
                        goto IL_F2;
                    }
                }
                this.CmbSubstore.IsEnabled = false;
            IL_F2:
                PhotoBusiness photoBusiness = new PhotoBusiness();
                string photoGrapherLastImageId = photoBusiness.GetPhotoGrapherLastImageId(this.CmbPhotographerNo.SelectedValue.ToInt32(false));
                this.Lastimageno.Text = "Last Photo no. of " + ((PhotoGraphersInfo)this.CmbPhotographerNo.SelectedItem).FullName + " is " + photoGrapherLastImageId;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private bool GetRfidStatus(int userId, out int locationId, out int _subStoreID)
        {
          // int userId;
            bool result;
            do
            {
                //userId = userId2;
                locationId = 0;
                _subStoreID = 0;
                bool flag = false;
                try
                {
                    PhotoGraphersInfo photoGraphersInfo = (from r in this.lstUsers
                                                           where r.DG_User_pkey == userId
                                                           select r).FirstOrDefault<PhotoGraphersInfo>();
                    bool flag2 = photoGraphersInfo == null;
                    bool arg_D5_0;
                    bool expr_67 = arg_D5_0 = flag2;
                    if (!true)
                    {
                        goto IL_D4;
                    }
                    if (expr_67)
                    {
                        goto IL_112;
                    }
                IL_72:
                    int dG_Location_pkey = photoGraphersInfo.DG_Location_pkey;
                    int arg_7F_0 = photoGraphersInfo.DG_Substore_ID;
                IL_7F:
                    int num = arg_7F_0;
                    ConfigBusiness configBusiness = new ConfigBusiness();
                    List<iMixConfigurationLocationInfo> configLocation = configBusiness.GetConfigLocation(dG_Location_pkey, num);
                    iMixConfigurationLocationInfo iMixConfigurationLocationInfo = configLocation.FirstOrDefault((iMixConfigurationLocationInfo x) => x.IMIXConfigurationMasterId == 49L);
                IL_BA:
                    if (iMixConfigurationLocationInfo != null)
                    {
                        flag = iMixConfigurationLocationInfo.ConfigurationValue.ToBoolean(false);
                    }
                    arg_D5_0 = flag;
                IL_D4:
                    bool expr_D5 = (arg_7F_0 = ((!arg_D5_0) ? 1 : 0)) != 0;
                    if (-1 == 0)
                    {
                        goto IL_7F;
                    }
                    if (expr_D5 && 3 != 0)
                    {
                        _subStoreID = num;
                        locationId = dG_Location_pkey;
                        result = false;
                        return result;
                    }
                    if (false)
                    {
                        goto IL_72;
                    }
                    if (!false)
                    {
                        _subStoreID = num;
                        locationId = dG_Location_pkey;
                        result = true;
                        return result;
                    }
                    goto IL_BA;
                }
                catch (Exception)
                {
                }
            IL_112: ;
            }
            while (3 == 0);
            result = false;
            return result;
        }

        private void GetNewConfigLocationValues(int LocationId, int SubstoreId)
        {
            ConfigBusiness configBusiness = new ConfigBusiness();
            List<iMixConfigurationLocationInfo> configLocation = configBusiness.GetConfigLocation(LocationId, SubstoreId);
            using (List<iMixConfigurationLocationInfo>.Enumerator enumerator = configLocation.GetEnumerator())
            {
                while (true)
                {
                    bool arg_1A9_0;
                    bool expr_275 = arg_1A9_0 = enumerator.MoveNext();
                    if (4 == 0)
                    {
                        goto IL_1A9;
                    }
                    if (!expr_275)
                    {
                        break;
                    }
                    iMixConfigurationLocationInfo current = enumerator.Current;
                    long iMIXConfigurationMasterId = current.IMIXConfigurationMasterId;
                    long arg_4E_0;
                    long arg_54_0 = arg_4E_0 = iMIXConfigurationMasterId;
                    long arg_4E_1;
                    if (true)
                    {
                        arg_4E_1 = 38L;
                        goto IL_4E;
                    }
                IL_52:
                    if (arg_54_0 > 3L)
                    {
                        goto IL_79;
                    }
                    if (iMIXConfigurationMasterId < 1L)
                    {
                        continue;
                    }
                    long arg_8B_0;
                    long expr_5F = arg_4E_0 = (arg_8B_0 = iMIXConfigurationMasterId);
                    if (!false)
                    {
                        switch ((int)(expr_5F - 1L))
                        {
                            case 0:
                                this._IsBarcodeActive = current.ConfigurationValue.ToBoolean(false);
                                continue;
                            case 1:
                                this._MappingType = current.ConfigurationValue.ToInt32(false);
                                continue;
                            case 2:
                                this._scanType = current.ConfigurationValue.ToInt32(false);
                                continue;
                        }
                        goto IL_79;
                    }
                IL_85:
                    long expr_87 = arg_4E_1 = 38L;
                    if (3 == 0)
                    {
                        goto IL_4E;
                    }
                    if (arg_8B_0 != expr_87)
                    {
                        continue;
                    }
                    this._IsAnonymousCodeActive = current.ConfigurationValue.ToBoolean(false);
                    continue;
                IL_79:
                    if (iMIXConfigurationMasterId != 23L)
                    {
                        arg_8B_0 = (arg_4E_0 = iMIXConfigurationMasterId);
                        goto IL_85;
                    }
                    this._IsDelete = current.ConfigurationValue.ToBoolean(false);
                    continue;
                IL_4E:
                    if (arg_4E_0 <= arg_4E_1)
                    {
                        arg_54_0 = iMIXConfigurationMasterId;
                        goto IL_52;
                    }
                    if (iMIXConfigurationMasterId <= 50L)
                    {
                        if (iMIXConfigurationMasterId < 49L)
                        {
                            continue;
                        }
                        switch ((int)(iMIXConfigurationMasterId - 49L))
                        {
                            case 0:
                                {
                                    bool arg_19A_0;
                                    if (current.ConfigurationValue == null || !(current.ConfigurationValue != ""))
                                    {
                                        if (5 == 0)
                                        {
                                            continue;
                                        }
                                        arg_19A_0 = false;
                                    }
                                    else
                                    {
                                        arg_19A_0 = current.ConfigurationValue.ToBoolean(false);
                                    }
                                    App.IsRFIDEnabled = arg_19A_0;
                                    continue;
                                }
                            case 1:
                                goto IL_1A4;
                        }
                    }
                    if (iMIXConfigurationMasterId <= 73L)
                    {
                        if (iMIXConfigurationMasterId < 72L)
                        {
                            continue;
                        }
                        if (6 == 0)
                        {
                            goto IL_1C8;
                        }
                        switch ((int)(iMIXConfigurationMasterId - 72L))
                        {
                            case 0:
                                this._IsEnabledSessionSelect = (!string.IsNullOrEmpty(current.ConfigurationValue) && current.ConfigurationValue.ToBoolean(false));
                                continue;
                            case 1:
                                this._IsEnabledSelectEndPoint = (!string.IsNullOrEmpty(current.ConfigurationValue) && current.ConfigurationValue.ToBoolean(false));
                                continue;
                        }
                    }
                    if (iMIXConfigurationMasterId != 179L)
                    {
                        continue;
                    }
                    if (4 == 0)
                    {
                        continue;
                    }
                    this._isEnabledImageEditingMDownload = (!string.IsNullOrEmpty(current.ConfigurationValue) && current.ConfigurationValue.ToBoolean(false));
                    if (4 != 0)
                    {
                        continue;
                    }
                IL_1A4:
                    arg_1A9_0 = App.IsRFIDEnabled;
                    goto IL_1A9;
                    continue;
                    continue;
                IL_1C9:
                    bool arg_1CA_0;
                    if (!arg_1CA_0)
                    {
                        App.RfidScanType = new int?(current.ConfigurationValue.ToInt32(false));
                    }
                    else
                    {
                        App.RfidScanType = null;
                    }
                    continue;
                IL_1C8:
                    arg_1CA_0 = true;
                    goto IL_1C9;
                IL_1A9:
                    if (arg_1A9_0 && current.ConfigurationValue != null)
                    {
                        arg_1CA_0 = !(current.ConfigurationValue != "");
                        goto IL_1C9;
                    }
                    goto IL_1C8;
                }
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
             PhotoBusiness photoBusiness = new  PhotoBusiness();
            photoBusiness.GetPhotoGrapherLastImageId(this.CmbPhotographerNo.SelectedValue.ToInt32(false));
            
            bool flag = !string.IsNullOrEmpty(this.tbStartingNo.Text);
            bool arg_4A_0 = flag;
        IL_4A:
            while (arg_4A_0)
            {
                //if(flag)
                //    {
                //    string SNo = this.tbStartingNo.Text;
                //    bool arg_4S = false;  //(SNo == PhotoSW.CF.DataLayer.BAL.baPhotoInfo.GetStartNoPhotoInfo().ToString());
                //    //List< PhotoSW.CF.DataLayer.BAL.baPhotoInfo> obj = new List<CF.DataLayer.BAL.baPhotoInfo>();
                //    var obj  = PhotoSW.CF.DataLayer.BAL.baPhotoInfo.GetPhotoInfoData().Where(x=>x.PS_Photos_RFID== SNo).FirstOrDefault();
                //    if(obj != null)
                //        {
                //        MessageBox.Show("This starting number is allready Exist");
                //   //     return;
                //        }                 
                   
                //    }
                DateTime dateTime = new  CustomBusineses().ServerDateTime();
                long num = this.tbStartingNo.Text.ToInt64(false);
                int arg_7B_0 = 6;
                while (true)
                {
                IL_7B:
                    object[] array = new object[arg_7B_0];
                    array[0] = dateTime.Day.ToString();
                    array[1] = dateTime.Month.ToString();
                    array[2] = num.ToString();
                    array[3] = "_";
                    array[4] = this.CmbPhotographerNo.SelectedValue;
                    array[5] = ".jpg";
                    string photono = string.Concat(array);
                    PhotoBusiness photoBusiness2 = new PhotoBusiness();
                    if (!photoBusiness2.CheckPhotos(photono, this.CmbPhotographerNo.SelectedValue.ToInt32(false)))
                    {
                        break;
                    }
                    bool arg_16E_0;
                    if (this.CmbLocation.SelectedValue == null || this.CmbPhotographerNo.SelectedValue == null || this.CmbLocation.SelectedValue.ToInt32(false) <= 0)
                    if(this.CmbPhotographerNo.SelectedValue == null)
                        {
                        arg_16E_0 = true;
                        goto IL_16D;
                    }
                    int arg_1AF_0;
                    int expr_15C = arg_1AF_0 = this.CmbPhotographerNo.SelectedValue.ToInt32(false);
                    if (!false)
                    {
                        arg_16E_0 = (expr_15C <= 0);
                        goto IL_16D;
                    }
                    int? photographerRFIDEnabledLocation;
                    while (true)
                    {
                    IL_1AF:
                        if (arg_1AF_0 == 0)
                        {
                           flag = (photographerRFIDEnabledLocation.Value == this.CmbLocation.SelectedValue.ToInt32(false));
                            bool arg_1D4_0 = flag;
                            while (!arg_1D4_0)
                            {
                                string message = "The location you have selected is not correct.If you continue your association of images will not be correct.Do you wish to continue??";
                                bool flag2 = this.MsgBox.ShowHandlerDialog(message, DigiMessageBox.DialogType.Confirm);
                                bool expr_1EE = arg_1D4_0 = flag2;
                                if (!false)
                                {
                                    if (!expr_1EE)
                                    {
                                        goto Block_12;
                                    }
                                    break;
                                }
                            }
                        }
                        ManualDownload._photogrpherIdS = this.CmbPhotographerNo.SelectedValue.ToInt32(false);
                        ManualDownload._startingNoS = this.tbStartingNo.Text.ToInt64(false);
                        ManualDownload._locationIdS = this.CmbLocation.SelectedValue.ToInt32(false);
                        ManualDownload._substoreIdS = this.CmbSubstore.SelectedValue.ToInt32(false);
                        this._locationId = this.CmbLocation.SelectedValue.ToInt32(false);
                        this._substoreId = this.CmbSubstore.SelectedValue.ToInt32(false);
                        while (true)
                        {
                            if (this._locationId > 0 && this._substoreId > 0)
                            {
                                this.GetNewConfigLocationValues(this._locationId, this._substoreId);
                            }
                            //bool expr_2DB = (arg_1AF_0 = ((!(this.chkCaptureAfterDummyScan.IsChecked == true)) ? 1 : 0)) != 0;
                            //if (4 == 0)
                            //{
                            //    break;
                            //}
                            //flag = expr_2DB;
                            bool expr_2E5 = (arg_7B_0 = (flag ? 1 : 0)) != 0;
                            if (2 == 0)
                            {
                                goto IL_7B;
                            }
                            if (expr_2E5)
                            {
                                goto IL_330;
                            }
                            //ConfigBusiness configBusiness = new ConfigBusiness();
                            //if (configBusiness.CheckDummyScan(Convert.ToInt64(this.CmbPhotographerNo.SelectedValue)))
                            //{
                            //    goto IL_32F;
                            //}
                            if (-1 != 0)
                            {
                                goto Block_20;
                            }
                        }
                    }
                IL_330:
                    if (4 != 0)
                    {
                        goto Block_21;
                    }
                    goto IL_178;
                IL_32F:
                    goto IL_330;
                IL_178:
                    if (false)
                    {
                        goto IL_36A;
                    }
                 RfidBusiness rfidBusiness = new RfidBusiness();
                    photographerRFIDEnabledLocation = rfidBusiness.GetPhotographerRFIDEnabledLocation(this.CmbPhotographerNo.SelectedValue.ToInt32(false));
                    bool expr_1A1 = arg_4A_0 = photographerRFIDEnabledLocation.HasValue;
                    if (7 != 0)
                    {
                        arg_1AF_0 = ((!expr_1A1) ? 1 : 0);
                       // goto IL_1AF;
                    }
                    goto IL_4A;
                IL_16D:
                    if (!arg_16E_0)
                    {
                        goto IL_178;
                    }
                    goto IL_36C;
                }
                /////testing
                ((ImageDownloader)Window.GetWindow(this)).IsEnabledSessionSelect = this._IsEnabledSessionSelect;
                ((ImageDownloader)Window.GetWindow(this)).IsEnabledSelectEndPoint = this._IsEnabledSelectEndPoint;
                this.showAfterImage();
            ////Testing
              //  MessageBox.Show(num + " already exists for today");
            Block_12:
                return;
            Block_20:
                this.MsgBox.ShowHandlerDialog("You cannot download capture for dummy scan as your dummy scan delay time is expired, Please try again with new dummy scanning process", DigiMessageBox.DialogType.OK);
                return;
            Block_21:
                ((ImageDownloader)Window.GetWindow(this)).IsEnabledSessionSelect = this._IsEnabledSessionSelect;
                ((ImageDownloader)Window.GetWindow(this)).IsEnabledSelectEndPoint = this._IsEnabledSelectEndPoint;
                this.showAfterImage();
            IL_36A:
                return;
            IL_36C:
                MessageBox.Show("Select photographer and location.");
                return;
            }
           
            MessageBox.Show("Please enter starting number");
        }

        private void CmbSubstore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            while (true)
            {
                KeyValuePair<string, string> keyValuePair = (KeyValuePair<string, string>)this.CmbSubstore.SelectedItem;
                do
                {
                    int substoreId = keyValuePair.Value.ToInt32(false);
                    if (8 != 0)
                    {
                        if (false)
                        {
                            goto IL_67;
                        }
                        List<LocationInfo> locationSubstoreWise = new StoreSubStoreDataBusniess().GetLocationSubstoreWise(substoreId);
                      CommonUtility.BindComboWithSelect<LocationInfo>(this.CmbLocation, locationSubstoreWise, "DG_Location_Name", "DG_Location_pkey", 0, ClientConstant.SelectString);
                    }
                }
                while (false);
            IL_53:
                if (false)
                {
                    continue;
                }
                this.CmbLocation.SelectedValue = "0";
            IL_67:
                if (!false)
                {
                    break;
                }
                goto IL_53;
            }
        }

        private void MoveFiles()
        {
            this._photoNo = this.tbStartingNo.Text.ToInt64(false);
            this._photographerId = this.CmbPhotographerNo.SelectedValue.ToString();
           this._locationid = this.CmbLocation.SelectedValue.ToInt32(false);
            List<MyImageClass> newList;
            if (true)
            {
                this._subStoreid = Convert.ToInt32(this.CmbSubstore.SelectedValue);
                ParallelOptions parallelOptions;
                while (true)
                {
                  //  this._characterid = Convert.ToInt32(this.CmbCharacter.SelectedValue);
                    newList = (from c in this.imagelist
                               where c.IsChecked
                               select c into p
                               orderby p.CreatedDate
                               select p).ToList<MyImageClass>();
                    PhotoBusiness photoBusiness = new PhotoBusiness();
                    var obj =  baPhotoInfo.GetPhotoInfoData();
                    obj.Where(x => x.PS_Photo_ID == _photoNo).ToList();

                    string SNo = this.tbStartingNo.Text;
                        bool arg_4S = false;  //(SNo == PhotoSW.CF.DataLayer.BAL.baPhotoInfo.GetStartNoPhotoInfo().ToString());
                        //List< PhotoSW.CF.DataLayer.BAL.baPhotoInfo> obj = new List<CF.DataLayer.BAL.baPhotoInfo>();
                        var obj1  = baPhotoInfo.GetPhotoInfoData().Where(x=>x.PS_Photos_RFID == SNo).FirstOrDefault();
                    var objlast =  baPhotoInfo.GetPhotoInfoData().Where(x => x.PS_Photos_RFID == SNo).LastOrDefault();
                    int lastId = 0;
                    if(objlast != null)
                        {
                        lastId = objlast.PS_Photo_ID;
                        lastId++;
                        }

                    DateTime dateTime = new  CustomBusineses().ServerDateTime();
                    string[] array = new string[6];
                    array[0] = dateTime.Day.ToString();
                    long num;
                    if (7 != 0)
                    {
                        array[1] = dateTime.Month.ToString();
                        array[2] = this._photoNo.ToString();
                        array[3] = "_";
                        if (true)
                        {
                            array[4] = this._photographerId.ToString();
                            array[5] = ".jpg";
                            string photono = string.Concat(array);
                            //if (!photoBusiness.CheckPhotos(photono, this._photographerId.ToInt32(false)))
                            //{
                            //    break;
                            //}
                            if(lastId != 0)
                                {
                                num = lastId;
                                }else
                            num = this._photoNo;
                        }
                    }
                    List<MyImageClass>.Enumerator enumerator = newList.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            MyImageClass current = enumerator.Current;
                            current.PhotoNumber = num;
                            num += 1L;
                        }
                    }
                    finally
                    {
                        ((IDisposable)enumerator).Dispose();
                        while (false)
                        {
                        }
                    }
                    parallelOptions = new ParallelOptions();
                    if (true)
                    {
                        goto Block_8;
                    }
                }
                MessageBox.Show(this._photoNo + " already exists for today");
                return;
            Block_8:
                parallelOptions.MaxDegreeOfParallelism = 5;
               // this._photoNo -= 1L;
                this.DownloadProgress.Maximum = (double)newList.Count;
            }
        IL_242:
            this.DownloadProgress.Value = 1.0;
            Task task;
            if (!false)
            {
                task = Task.Factory.StartNew(delegate
                {
                    this.ParallelDownload(newList);
                });
            }
            if (false)
            {
                goto IL_242;
            }
            task.ContinueWith(delegate(Task t)
            {
                bool arg_11_0 = newList.Count > 0;
                bool expr_79;
                do
                {
                    bool flag = !arg_11_0;
                    expr_79 = (arg_11_0 = flag);
                }
                while (3 == 0);
                if (expr_79)
                {
                    goto IL_5F;
                }
                if (8 != 0)
                {
                    if (false)
                    {
                        goto IL_5E;
                    }
                    MessageBox.Show(newList.Count + " File(s) Acquired Successfully");
                    this._result = string.Empty;
                }
            IL_4F:
                this.HideHandlerDialog();
                if (!false)
                {
                }
            IL_5E:
            IL_5F:
                if (!false)
                {
                    return;
                }
                goto IL_4F;
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private void ParallelDownload(List<MyImageClass> newList)
		{
			//ManualDownload <>4__this;
			//List<MyImageClass> newList;
			while (true)
			{
				IL_04:
				//newList = newList2;
				while (true)
				{
					ParallelOptions parallelOptions;
					if (!false)
					{
						//<>4__this = this;
						if (!false)
						{
						}
						do
						{
							parallelOptions = new ParallelOptions();
							parallelOptions.MaxDegreeOfParallelism = 1;
							if (7 == 0)
							{
								goto IL_04;
							}
						}
						while (false);
					}
					Parallel.For(0, newList.Count, parallelOptions, delegate(int i)
					{
						int j;
						List<MyImageClass> list;
						do
						{
							list = new List<MyImageClass>();
							j = i;
						}
						while (false);
						list.Add(newList[j]);
						CopyFromSourceToDestination(list, newList[j].PhotoNumber, _photographerId, _locationid, _subStoreid, _characterid);
						DownloadProgress.Dispatcher.BeginInvoke(DispatcherPriority.Input, new DispatcherOperationCallback(delegate(object param0)
						{
							object result;
							while (true)
							{
								IL_00:
								if (!false)
								{
									DownloadProgress.Value = DownloadProgress.Value + (double)j;
								}
								IL_34:
								if (5 == 0)
								{
									continue;
								}
								Thread.Sleep(50);
								while (true)
								{
									result = null;
									if (-1 == 0)
									{
										break;
									}
									if (!true)
									{
										goto IL_00;
									}
									if (!false)
									{
										return result;
									}
								}
								goto IL_34;
							}
							return result;
						}), null);
					});
					if (!false)
					{
						return;
					}
				}
			}
		}

        private void CopyFromSourceToDestination(List<MyImageClass> imagelist, long PhotoNo, string PhotographerId, int locationid, int subStoreid, int characterid)
        {
            try
            {
                MyImageClass myImageClass = imagelist[0];
                string text = string.Empty;
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                string directoryName = Path.GetDirectoryName(executingAssembly.Location);
                XDocument xDocument = XDocument.Load(directoryName + "\\ImageEditingManualDownload.xml");
                if (myImageClass.SettingStatus != SettingStatus.SpecUpdated)
                {
                    goto IL_62;
                }
                text = "_2";
            IL_60:
                goto IL_91;
            IL_62:
                bool arg_211_0;
                bool expr_69 = arg_211_0 = (myImageClass.SettingStatus == SettingStatus.Spec);
                if (5 == 0)
                {
                    goto IL_210;
                }
                bool flag = !expr_69;
                if (6 == 0)
                {
                    goto IL_270;
                }
                if (!flag)
                {
                    text = "_1";
                    if (-1 == 0)
                    {
                        goto IL_105;
                    }
                }
                else
                {
                    text = "_0";
                }
            IL_91:
                DateTime dateTime = new CustomBusineses().ServerDateTime();
                string text2 = string.Empty;
                string[] array = new string[15];
                array[0] = dateTime.Day.ToString();
            IL_C1:
                array[1] = dateTime.Month.ToString();
                array[2] = "_";
                array[3] = PhotoNo.ToString();
                array[4] = "_";
                array[5] = PhotographerId.ToString();
                array[6] = "_";
            IL_105:
                array[7] = subStoreid.ToString();
                array[8] = "_";
                array[9] = locationid.ToString();
                if (!true)
                {
                    goto IL_62;
                }
                array[10] = "_";
                array[11] = characterid.ToString();
                array[12] = this.getTagId(myImageClass.Title);
                if (false)
                {
                    goto IL_C1;
                }
                array[13] = text;
                array[14] = myImageClass.FileExtension.ToLower();
                text2 = string.Concat(array);
                string path = myImageClass.Title + myImageClass.FileExtension;
            IL_18A:
                 if (myImageClass.FileExtension == ".jpg" && this._isEnabledImageEditingMDownload)
                {
                    File.Copy(myImageClass.ImagePath.Replace("Thumbnails\\", ""), Path.Combine(this._filepath, "ManualDownload", text2));
                }
                else
                {
                    File.Copy(Path.Combine(myImageClass.ImagePath, path), Path.Combine(this._filepath, "ManualDownload", text2));
                    ////Edited Started
                    File.Copy(Path.Combine(myImageClass.ImagePath, path), Path.Combine(this._filepath, "Thumbnails", text2));

                    File.Copy(Path.Combine(myImageClass.ImagePath, path), Path.Combine(this._filepath, "Thumbnails", DateTime.Now.ToString("yyyyMMdd"), text2));

                    File.Copy(Path.Combine(myImageClass.ImagePath, path), Path.Combine(this._filepath, "Thumbnails_Big", text2));

                    File.Copy(Path.Combine(myImageClass.ImagePath, path), Path.Combine(this._filepath, "Thumbnails_Big", DateTime.Now.ToString("yyyyMMdd"), text2));

                    File.Copy(Path.Combine(myImageClass.ImagePath, path), Path.Combine(this._filepath, DateTime.Now.ToString("yyyyMMdd"), text2));
                    ////Edited end
                    }
                arg_211_0 = (myImageClass.SettingStatus == SettingStatus.SpecUpdated);
            IL_210:
                if (!arg_211_0)
                {
                    goto IL_2D5;
                }
                if (!string.IsNullOrWhiteSpace(myImageClass.NewEffectsXML))
                {
                    xDocument.Element("root").Element("Effects").Value = myImageClass.NewEffectsXML.ToString();
                }
                if (string.IsNullOrWhiteSpace(myImageClass.NewLayeringXML))
                {
                    goto IL_2A1;
                }
            IL_270:
                xDocument.Element("root").Element("Layering").Value = myImageClass.NewLayeringXML.ToString();
            IL_2A1:
                xDocument.Save(Path.Combine(this._filepath, "ManualDownload", text2.Replace(".jpg", "") + ".xml"));
            IL_2D5:
                string path2 = Path.Combine(this._filepath, "ManualDownload", "Croped");
                while (myImageClass.IsCropped.Equals(true))
                {
                    if (false)
                    {
                        goto IL_18A;
                    }
                    if (!System.IO.Directory.Exists(path2))
                    {
                        System.IO.Directory.CreateDirectory(path2);
                    }
                    File.Copy(myImageClass.ImagePath.Replace("Thumbnails\\", "Croped\\"), Path.Combine(this._filepath, "ManualDownload\\Croped", text2));
                    if (!false)
                    {
                        break;
                    }
                }
                if (false)
                {
                    goto IL_60;
                }
                Interlocked.Add(ref this.CountImagesDownload, 1);

                PhotoBusiness photoBussiness = new PhotoBusiness();
                string Layering = xDocument.Element("root").Element("Layering").Value=="NULL"?"":xDocument.Element("root").Element("Layering").Value.ToString();
                string Effects = xDocument.Element("root").Element("Effects").Value == "NULL" ? "" : xDocument.Element("root").Element("Effects").Value.ToString();
                photoBussiness.SetPhotoDetails1((int)subStoreid, this._photoNo.ToString(), text2, dateTime, PhotographerId, Layering, locationid, Layering, Effects, dateTime,1, (int)characterid,(int)PhotoNo);


            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private string getTagId(string imageName)
        {
            string arg_ED_0 = string.Empty;
            string text = imageName.Split(new char[]
			{
				this.valueSeparator
			}).FirstOrDefault<string>();
            int arg_74_0;
            if (!string.IsNullOrEmpty(text))
            {
                arg_74_0 = 1;
                goto IL_73;
            }
        IL_48:
            if (-1 == 0)
            {
                goto IL_E1;
            }
            int expr_66 = arg_74_0 = imageName.Split(new char[]
			{
				this.valueSeparator
			}).Length;
            if (8 != 0)
            {
                arg_74_0 = ((expr_66 <= 1) ? 1 : 0);
            }
        IL_73:
            bool flag = arg_74_0 != 0;
            if (-1 != 0)
            {
                if (!flag)
                {
                    text = imageName.Split(new char[]
					{
						this.valueSeparator
					})[1];
                }
                if (false)
                {
                    goto IL_48;
                }
                if (string.IsNullOrEmpty(text))
                {
                    goto IL_CA;
                }
            }
            if (text.Length <= 1)
            {
                goto IL_CA;
            }
        IL_A9:
            bool arg_CC_0 = imageName.Split(new char[]
			{
				this.valueSeparator
			}).Length <= 1;
            goto IL_CB;
        IL_CA:
            arg_CC_0 = true;
        IL_CB:
            if (!arg_CC_0)
            {
                text = "_" + text;
                if (!false)
                {
                    return text;
                }
                goto IL_A9;
            }
        IL_E1:
            text = string.Empty;
            return text;
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
            e.Handled = ManualDownload.IsTextNumeric(e.Text);
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

        private string GetCameraSerialNumber(MyImageClass image)
        {
            string result;
            try
            {
                bool flag = image == null;
                if (flag)
                {
                    goto IL_17A;
                }
                DateTime arg_1A1_0 = DateTime.Now;
                string str = image.Title + ".jpg";
                string text = image.ImagePath + "\\" + str;
                flag = !File.Exists(text);
            IL_5A:
                if (!flag)
                {
                    IList<MetadataExtractor.Directory> list = ImageMetadataReader.ReadMetadata(text);
                    IEnumerator<MetadataExtractor.Directory> enumerator = list.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            flag = enumerator.MoveNext();
                            if (!flag)
                            {
                                break;
                            }
                            MetadataExtractor.Directory current = enumerator.Current;
                            if (8 != 0)
                            {
                                IEnumerator<Tag> enumerator2 = current.Tags.GetEnumerator();
                                try
                                {
                                    while (4 != 0)
                                    {
                                        flag = enumerator2.MoveNext();
                                        Tag current2;
                                        while (true)
                                        {
                                            if (!false)
                                            {
                                                if (!flag)
                                                {
                                                    goto Block_17;
                                                }
                                                current2 = enumerator2.Current;
                                                flag = !current2.Name.Contains("Camera Serial Number");
                                                if (flag)
                                                {
                                                    break;
                                                }
                                                flag = (!current2.DirectoryName.ToLower().Contains("canon") && !current2.DirectoryName.ToLower().Contains("nikon"));
                                                if (!flag)
                                                {
                                                    //goto IL_FB;
                                                }
                                            }
                                            result = current2.Description;
                                            if (!false)
                                            {
                                                goto Block_13;
                                            }
                                        }
                                        continue;
                                    Block_13:
                                        if (-1 != 0)
                                        {
                                            return result;
                                        }
                                    IL_FC:
                                        result = current2.Description;
                                        return result;
                                    Block_17:
                                        goto IL_14F;
                                    }
                                //IL_FB:
                                    //goto IL_FC;
                                }
                                finally
                                {
                                    bool arg_144_0;
                                    bool expr_13B = arg_144_0 = (enumerator2 == null);
                                    if (!false)
                                    {
                                        flag = expr_13B;
                                        arg_144_0 = flag;
                                    }
                                    if (!arg_144_0)
                                    {
                                        enumerator2.Dispose();
                                    }
                                }
                            IL_14F: ;
                            }
                        }
                    }
                    finally
                    {
                        flag = (enumerator == null);
                        if (!flag)
                        {
                            enumerator.Dispose();
                        }
                    }
                }
            IL_17A:
                if (false)
                {
                    goto IL_5A;
                }
            }
            catch (Exception var_6_1C7)
            {
            }
            result = string.Empty;
            return result;
        }

        private bool CheckForRFIDEnabled(out string errorMessage)
        {
            bool result;
            if (!false)
            {
                errorMessage = string.Empty;
                try
                {
                    ConfigBusiness configBusiness = new ConfigBusiness();
                    CameraBusiness cameraBusiness = new CameraBusiness();
                    CameraInfo cameraByPhotographerId;
                    MyImageClass myImageClass;
                    while (true)
                    {
                       int locationId = this.CmbLocation.SelectedValue.ToInt32(false);
                        int photographerId = Convert.ToInt32(this.CmbPhotographerNo.SelectedValue.ToString());
                        bool flag = configBusiness.IsLocationRFIDEnabled(locationId);
                        cameraByPhotographerId = cameraBusiness.GetCameraByPhotographerId(photographerId);
                        //if (!flag)
                        //{
                        //    break;
                        //}
                        if (cameraByPhotographerId == null)
                        {
                            goto IL_1CC;
                        }
                        if (string.IsNullOrEmpty(cameraByPhotographerId.SerialNo))
                        {
                            goto IL_1C0;
                        }
                        List<MyImageClass> list = (from c in this.imagelist
                                                   where c.IsChecked
                                                   select c into p
                                                   orderby p.CreatedDate
                                                   select p).ToList<MyImageClass>();
                        if (list == null || list.Count <= 0)
                        {
                            goto IL_1B4;
                        }
                        myImageClass = list.FirstOrDefault<MyImageClass>();
                        if (myImageClass != null)
                        {
                            goto Block_12;
                        }
                        errorMessage = "Please select one or more image to continue.";
                        if (6 != 0)
                        {
                            goto Block_15;
                        }
                    }
                    int arg_18B_0;
                    int expr_72 = arg_18B_0 = 1;
                    if (expr_72 != 0)
                    {
                        result = (expr_72 != 0);
                        return result;
                    }
                    goto IL_18B;
                Block_12:
                    string cameraSerialNumber = this.GetCameraSerialNumber(myImageClass);
                    if (!cameraByPhotographerId.SerialNo.Trim().ToLower().EndsWith(cameraSerialNumber.Trim().ToLower()) && !cameraSerialNumber.Trim().ToLower().Equals(cameraByPhotographerId.SerialNo.Trim().ToLower()))
                    {
                        errorMessage = "The camera of the selected location is different from the camera attached.";
                        result = false;
                        return result;
                    }
                    arg_18B_0 = 1;
                IL_18B:
                    result = (arg_18B_0 != 0);
                    return result;
                Block_15:
                    goto IL_1BD;
                IL_1B4:
                    errorMessage = "Please select one or more image to continue.";
                IL_1BD:
                    goto IL_1C9;
                IL_1C0:
                    errorMessage = "The camera of the selected location doesn't have a serial number.";
                IL_1C9:
                    goto IL_1D5;
                IL_1CC:
                    errorMessage = "The selected location doesn't have a camera.";
                IL_1D5: ;
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                    errorMessage = "There was an exception while moving the files from Camera to the site";
                }
            }
            result = false;
            return result;
        }

     
      
    }
}
