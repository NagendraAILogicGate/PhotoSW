using DigiAuditLogger;
using DigiPhoto.Cache.DataCache;
using DigiPhoto.Cache.MasterDataCache;
using DigiPhoto.Cache.Repository;
using PhotoSW.Common;
using DigiPhoto.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
//using DigiPhoto.Shader;
using DigiPhoto.Utility.Repository.Data;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using FrameworkHelper;
using FrameworkHelper.Common;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
//using WMPLib;
using Xceed.Wpf.Toolkit;
using DigiPhoto;
using PhotoSW.Views;
using PhotoSW.DataLayer;

namespace PhotoSW.Manage
{
    public partial class Configuration : Window, IComponentConnector, INotifyPropertyChanged //IStyleConnector,
    {
        private enum IntervalType
        {
            Day = 1,
            Week,
            Month
        }

        private delegate void LoadTabDelegate();

        public class Action : INotifyPropertyChanged
        {
            private bool _isSelected;

            private string _name;
            private PropertyChangedEventHandler propertyChanged;
            public event PropertyChangedEventHandler PropertyChanged
            {
                add
                {
                    do
                    {
                    IL_00:
                        PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChanged;
                        while (true)
                        {
                        IL_09:
                            PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
                            while (true)
                            {
                                PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
                                if (-1 == 0)
                                {
                                    goto IL_00;
                                }
                                propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, value2, propertyChangedEventHandler2);
                                while (!false)
                                {
                                    bool arg_39_0;
                                    bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
                                    if (!false)
                                    {
                                        arg_39_0 = !expr_31;
                                    }
                                    if (arg_39_0)
                                    {
                                        goto IL_09;
                                    }
                                    if (!false)
                                    {
                                        goto Block_4;
                                    }
                                }
                            }
                        }
                    Block_4:;
                    }
                    while (!true);
                }
                remove
                {
                    do
                    {
                    IL_00:
                        PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChanged;
                        while (true)
                        {
                        IL_09:
                            PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
                            while (true)
                            {
                                PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
                                if (-1 == 0)
                                {
                                    goto IL_00;
                                }
                                propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, value2, propertyChangedEventHandler2);
                                while (!false)
                                {
                                    bool arg_39_0;
                                    bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
                                    if (!false)
                                    {
                                        arg_39_0 = !expr_31;
                                    }
                                    if (arg_39_0)
                                    {
                                        goto IL_09;
                                    }
                                    if (!false)
                                    {
                                        goto Block_4;
                                    }
                                }
                            }
                        }
                    Block_4:;
                    }
                    while (!true);
                }
            }

            public bool IsSelected
            {
                get
                {
                    return this._isSelected;
                }
                set
                {
                    if (-1 == 0)
                    {
                        goto IL_36;
                    }
                    this._isSelected = value;
                IL_0D:
                    bool arg_20_0;
                    bool expr_15 = arg_20_0 = (this.propertyChanged == null);
                    if (false)
                    {
                        goto IL_20;
                    }
                    bool flag;
                    if (4 != 0)
                    {
                        flag = expr_15;
                    }
                IL_1E:
                    arg_20_0 = flag;
                IL_20:
                    if (arg_20_0)
                    {
                        goto IL_3A;
                    }
                    this.propertyChanged(this, new PropertyChangedEventArgs("IsSelected"));
                IL_36:
                    if (5 == 0)
                    {
                        goto IL_0D;
                    }
                IL_3A:
                    if (!false)
                    {
                        return;
                    }
                    goto IL_1E;
                }
            }

            public string Name
            {
                get
                {
                    return this._name;
                }
                set
                {
                    if (-1 == 0)
                    {
                        goto IL_36;
                    }
                    this._name = value;
                IL_0D:
                    bool arg_20_0;
                    bool expr_15 = arg_20_0 = (this.propertyChanged == null);
                    if (false)
                    {
                        goto IL_20;
                    }
                    bool flag;
                    if (4 != 0)
                    {
                        flag = expr_15;
                    }
                IL_1E:
                    arg_20_0 = flag;
                IL_20:
                    if (arg_20_0)
                    {
                        goto IL_3A;
                    }
                    this.propertyChanged(this, new PropertyChangedEventArgs("Name"));
                IL_36:
                    if (5 == 0)
                    {
                        goto IL_0D;
                    }
                IL_3A:
                    if (!false)
                    {
                        return;
                    }
                    goto IL_1E;
                }
            }
        }

        private string chromakeyName = string.Empty;

        private string ChromaKeyDisplayname = string.Empty;

        private bool IsChromaKeyEdited = false;

        private long ChromaKeyId = 0L;

        private delegate void DelegateWork();

        private BackgroundWorker BackupWorker = new BackgroundWorker();

        private BusyWindow bs = new BusyWindow();

        private TaxBusiness taxBusiness;

        private ConfigBusiness configBusiness;

        private string _databasename = "";

        private string _username = "";

        private string _pass = "";

        private string _server = "";

        private string _destinationPath = "";

        private string _imgSource = "";

        private string _imgDestination = "";

        private string _heavyTables = "";

        private string DG_Product_Name = "";

        private long generalBackgroundId = 0L;

        private int _cleanupdaysBackup;

        private int _FailedOnlineCleanupdayes;

        private Stack EffectLog;

        private string SpecFileName = string.Empty;

        private bool _isDefaultColorCode = true;

        private string _isDefaultColorSeletedValue = string.Empty;

        private bool _iseditStockImg = false;

        private bool _isNewFileSelected = false;

        private StockShot stockShotImg = new StockShot();

        private string videoDisplayname = string.Empty;

        private string audioName = string.Empty;

        private string audioDisplayname = string.Empty;

        private bool IsAudioEdited = false;

        private long audioId = 0L;

        private string videoBGDisplayname = string.Empty;

        private string generalBGDisplayname = string.Empty;

        private int videoBGMediaType = 0;

        private int generalBGMediaType = 0;

        private bool IsVideoBGEdited = false;

        private bool IsGeneralBGEdited = false;

        private bool IsVideoOverlayEdited = false;

        private string videoBGName = string.Empty;

        private string generalBGName = string.Empty;

        private long videoBackgroundId = 0L;

        private string errorMsg = string.Empty;

        private Dictionary<string, int> _codeTypeList;

        private Dictionary<string, int> _scanTypeList;

        private List<ConfigurationInfo> lstConfigurationInfo = new List<ConfigurationInfo>();

        private ObservableCollection<BackGroundInfo> backgroundList;

        private BackGroundInfo editableBackground;

        private AllGraphics editableGraphics;

        private int originalWidth;

        private int originalHeight;

        private int ProductTypeId = 0;

        private string sourcepath = string.Empty;

        private string savepath = string.Empty;

        private string selectedFileName = string.Empty;

        private string filenamebg = string.Empty;

        private string saveFolderPath = string.Empty;

        private BackgroundWorker bw_CopySettings = new BackgroundWorker();

        private static Configuration instance;

        private int _numValue = 0;

        private Dictionary<string, string> lstPrinterList;

        public int borderId;

        public long _stockImgId;

        private List<BGMaster> lstmainBGList;

        private System.Windows.Controls.TextBox controlon;

        private List<BorderInfo> lstBorderList;

        private Dictionary<string, string> lstlogoList;

        private Dictionary<string, string> lstBackgroundList;

        private Dictionary<string, string> lstBGList;

        private Dictionary<string, string> lstProductTypeList;

        private Dictionary<string, string> lstFilterList;

        private Dictionary<string, string> lstCurrencyList;

        //private MonochromeEffect _colorfiltereff = new MonochromeEffect();

        private double cont = 1.0;

        private double bright = 0.0;

        private int pkey;

        //private ContrastAdjustEffect _brighteff = new ContrastAdjustEffect();

        //private ContrastAdjustEffect _conteff = new ContrastAdjustEffect();

        public static string HorizontalCropCoordinates = string.Empty;

        public static string VerticalCropCoordinates = string.Empty;

        public static int SelectedLocationId = 0;

        private List<BGMaster> lstmainBGListScene = new List<BGMaster>();

        private List<AllGraphics> _objgraphicsdetailScene = new List<AllGraphics>();

        private List<BorderInfo> lstBorderListScene = new List<BorderInfo>();

        private bool isEditScene = false;

        public int sceneId = 0;

        private bool isEditCharacter = false;

        public int CharacterId = 0;

        private int selectedProductType = 1;

        private string graphicsname = string.Empty;

        private string graphicsdisplayname = string.Empty;

        private UIElement elementForContextMenu;

        private string filename = string.Empty;

        private bool iseditborder = false;

        private int currencyid;

        private string backgoundname = string.Empty;

        private string backgounddisplayname = string.Empty;

        private List<BackGroundInfo> lstBackgroundInfo = new List<BackGroundInfo>();

        private int productId;

        private bool IsProductTypeSelected;

        public int BackGroundID;

        private List<SelectedSubStores> lstSelectedSubstore;

        private string stockshotname = string.Empty;

        private List<SemiOrderSettings> objDG_SemiOrder_Settings = null;

        private string OverlayDisplyname = string.Empty;

        private int overlayMediaId = 0;

        private int OverlayId = 0;

        private long VideoOverlayId = 0L;

        private string OverlayName = string.Empty;

        private long videoOverlayId = 0L;

        //internal Grid ModalDialogParent;

        //internal Grid btn;

        //internal StackPanel bgContainer;

        //internal Viewbox vb2;

        //internal StackPanel bg_withlogo1;

        //internal System.Windows.Controls.Image bg1;

        //internal StackPanel FooterredLine;

        //internal System.Windows.Controls.Button btnUserName;

        //internal TextBlock txbUserName;

        //internal TextBlock txbStoreName;

        //internal System.Windows.Controls.Button btnLogout;

        //internal System.Windows.Controls.TabControl tbmain;

        //internal TabItem TabConfiguration;

        //internal System.Windows.Controls.TextBox txtHotFolder;

        //internal System.Windows.Controls.TextBox txtBorderFolder;

        //internal System.Windows.Controls.TextBox txtbgPath;

        //internal PasswordBox txtPassword;

        //internal System.Windows.Controls.TextBox txtNumber;

        //internal System.Windows.Controls.TextBox txtPageSize;

        //internal System.Windows.Controls.Button btnSaveChanges;

        //internal System.Windows.Controls.Button btnBack;

        //internal System.Windows.Controls.Button btnhotfolder;

        //internal System.Windows.Controls.Button btnFrmaes;

        //internal System.Windows.Controls.Button btnBg;

        //internal System.Windows.Controls.Button btngraphics;

        //internal System.Windows.Controls.TextBox txtbgGraphics;

        //internal System.Windows.Controls.CheckBox chkwatermark;

        //internal TextBlock tbenablegroup;

        //internal System.Windows.Controls.CheckBox chkEnableGrouping;

        //internal System.Windows.Controls.CheckBox chkHgihResolutionPreview;

        //internal System.Windows.Controls.CheckBox chkSemiOrder;

        //internal System.Windows.Controls.CheckBox chkSemiOrderMain;

        //internal System.Windows.Controls.CheckBox chkSaveReportToAnyDerive;

        //internal System.Windows.Controls.TextBox txtNoOfReceipt;

        //internal System.Windows.Controls.TextBox txtNoOfPhotoIdSearch;

        //internal System.Windows.Controls.TextBox txtConfigColorCode;

        //internal System.Windows.Controls.CheckBox chkAutoRotate;

        //internal System.Windows.Controls.CheckBox chkTotalDiscount;

        //internal System.Windows.Controls.CheckBox chkLineItemDiscount;

        //internal System.Windows.Controls.CheckBox chkEnablePos;

        //internal System.Windows.Controls.TextBox txtChromaTolerance;

        //internal System.Windows.Controls.ComboBox cmbChromaColor;

        //internal System.Windows.Controls.ComboBox cmbCurrency;

        //internal System.Windows.Controls.ComboBox cmbReceiptPrinter;

        //internal System.Windows.Controls.TextBox txtSeqPrefix;

        //internal System.Windows.Controls.TextBox txtImageBarCodeTextFontSize;

        //internal System.Windows.Controls.CheckBox chkCompressImage;

        //internal TabItem TabVenueConfiguration;

        //internal System.Windows.Controls.CheckBox chkRunvideoProcessingEngineLocationWise;

        //internal System.Windows.Controls.CheckBox chkImageProssingEngineLocWise;

        //internal System.Windows.Controls.CheckBox chkTaxEnabled;

        //internal System.Windows.Controls.CheckBox chkStockShot;

        //internal System.Windows.Controls.CheckBox chkIsTaxIncluded;

        //internal System.Windows.Controls.TextBox txtBillReceiptTitle;

        //internal System.Windows.Controls.TextBox txtAddress;

        //internal System.Windows.Controls.TextBox txtPhoneNo;

        //internal System.Windows.Controls.TextBox txtTaxRegistrationText;

        //internal System.Windows.Controls.TextBox txtTaxRegistrationNo;

        //internal System.Windows.Controls.TextBox txtWebsiteURL;

        //internal System.Windows.Controls.TextBox txtEmail;

        //internal System.Windows.Controls.Button btnSaveVenueChanges;

        //internal System.Windows.Controls.Button btnVenueBack;

        //internal System.Windows.Controls.CheckBox chkSequenceNoReqd;

        //internal System.Windows.Controls.TextBox txtMinSeqNo;

        //internal System.Windows.Controls.TextBox txtMaxSeq;

        //internal System.Windows.Controls.TextBox txtServerHotFolder;

        //internal System.Windows.Controls.Button btnServerhotfolder;

        //internal TabItem TabSpecPrinting;

        //internal System.Windows.Controls.ComboBox cmb_Location;

        //internal System.Windows.Controls.Button btnAddNew;

        //internal System.Windows.Controls.DataGrid grdSpecSetting;

        //internal System.Windows.Controls.Button btnBackto;

        //internal TabItem TabManageBorder;

        //internal System.Windows.Controls.DataGrid DGManageBorder;

        //internal System.Windows.Controls.Button btnBackborder;

        //internal System.Windows.Controls.ComboBox CmbProductType;

        //internal System.Windows.Controls.Button btnSelectBorder;

        //internal System.Windows.Controls.TextBox txtSelectedborder;

        //internal System.Windows.Controls.Button btnSaveSelectBorder;

        //internal System.Windows.Controls.Button btnCancelSelectBorder;

        //internal System.Windows.Controls.CheckBox IsBorderActive;

        //internal TabItem TabManageBackground;

        //internal Grid GrdBackgroundDetails;

        //internal System.Windows.Controls.Button btnSelectBackground;

        //internal System.Windows.Controls.TextBox txtSelectedBackground;

        //internal System.Windows.Controls.Button btnSaveSelectBackground;

        //internal System.Windows.Controls.Button btnCancelSelectBackgound;

        //internal System.Windows.Controls.CheckBox IsBackgroundActive;

        //internal System.Windows.Controls.DataGrid DGManageBackground;

        //internal System.Windows.Controls.Button btnBackbackground;

        //internal TabItem TabManageCurrency;

        //internal System.Windows.Controls.DataGrid DGManageCurrency;

        //internal System.Windows.Controls.Button btnBackCurrency;

        //internal System.Windows.Controls.TextBox TBCurrencyName;

        //internal System.Windows.Controls.Button BtnSelectIconCurrency;

        //internal System.Windows.Controls.TextBox txtSelectedIconCurrency;

        //internal System.Windows.Controls.Button btnSaveCurrency;

        //internal System.Windows.Controls.Button btnclearCurrency;

        //internal System.Windows.Controls.TextBox TBCurrencySymbol;

        //internal System.Windows.Controls.TextBox txtDefaultCurrency;

        //internal System.Windows.Controls.TextBox TBCurrencyRate;

        //internal System.Windows.Controls.TextBox TBCurrencyCode;

        //internal TabItem TabManageGraphics;

        //internal System.Windows.Controls.DataGrid DGManageGraphics;

        //internal System.Windows.Controls.Button btnBackGraphics;

        //internal System.Windows.Controls.Button btnSelectGraphics;

        //internal System.Windows.Controls.TextBox txtSelectedgraphics;

        //internal System.Windows.Controls.Button btnSaveSelectGraphics;

        //internal System.Windows.Controls.Button btnCancelSelectgraphics;

        //internal System.Windows.Controls.CheckBox IsGraphicsActive;

        //internal TabItem TabManageDiscount;

        //internal System.Windows.Controls.DataGrid DGManageDiscount;

        //internal System.Windows.Controls.Button btnBackDiscount;

        //internal System.Windows.Controls.TextBox txtdiscountname;

        //internal System.Windows.Controls.CheckBox IsDiscountActive;

        //internal System.Windows.Controls.CheckBox IsDiscountSecure;

        //internal System.Windows.Controls.CheckBox IsDiscountItemLevel;

        //internal System.Windows.Controls.CheckBox IsDiscountasPercentage;

        //internal System.Windows.Controls.TextBox txtdiscountdescription;

        //internal System.Windows.Controls.TextBox txtDiscountCode;

        //internal System.Windows.Controls.Button btnSaveDiscount;

        //internal System.Windows.Controls.Button btnCanceldiscount;

        //internal TabItem TabSSConfiguration;

        //internal System.Windows.Controls.ComboBox cmbSelectSubstore;

        //internal System.Windows.Controls.Button btnSaveSubStore;

        //internal System.Windows.Controls.Button btnBackSubStore;

        //internal System.Windows.Controls.DataGrid dgrdLocations;

        //internal TabItem Tabdigimagic;

        //internal Slider brightVal;

        //internal System.Windows.Controls.TextBox txtbright;

        //internal Slider contrastVal;

        //internal System.Windows.Controls.TextBox txtcontrasts;

        //internal Slider sharpVal;

        //internal System.Windows.Controls.TextBox txtsharp;

        //internal Grid GrdBrightn;

        //internal Grid GrdSharpens;

        //internal System.Windows.Controls.Image Flower;

        //internal System.Windows.Controls.Button btnDefault;

        //internal System.Windows.Controls.Button btnSaveDigimagic;

        //internal System.Windows.Controls.Button btnBrionBack;

        //internal TabItem TabBackup;

        //internal System.Windows.Controls.TextBox txtDbBackupPath;

        //internal System.Windows.Controls.TextBox txtTables;

        //internal System.Windows.Controls.ListBox listtables;

        //internal System.Windows.Controls.TextBox txtHfBackupPath;

        //internal System.Windows.Controls.TextBox txtCleanupdays;

        //internal System.Windows.Controls.TextBox txtFailedOnlineOrderCleanupdays;

        //internal TextBlock hiddenHFPath;

        //internal System.Windows.Controls.CheckBox chkSchBackup;

        //internal Xceed.Wpf.Toolkit.DateTimePicker ccBackupDateTime;

        //internal System.Windows.Controls.CheckBox chkRecursive;

        //internal System.Windows.Controls.ComboBox cmbSelectRecursiveCount;

        //internal System.Windows.Controls.ComboBox cmbSelectRecursiveTime;

        //internal System.Windows.Controls.Button btnBackupNow;

        //internal System.Windows.Controls.Button btnBackupBack;

        //internal TabItem TabOnlineConfig;

        //internal System.Windows.Controls.CheckBox chkIsBarcodeActive;

        //internal TextBlock txtblMappingType;

        //internal System.Windows.Controls.ComboBox cmbMappingType;

        //internal TextBlock txtblScanType;

        //internal System.Windows.Controls.ComboBox cmbScanType;

        //internal System.Windows.Controls.TextBox txtQRCodeLen;

        //internal StackPanel spLostImgTimeGap;

        //internal System.Windows.Controls.TextBox txtLostImgTimeGap;

        //internal StackPanel spQRCodeUrl;

        //internal System.Windows.Controls.TextBox txtQRCodeWebUrl;

        //internal System.Windows.Controls.CheckBox chkIsOnline;

        //internal System.Windows.Controls.CheckBox chkIsAutoPurchaseActive;

        //internal StackPanel DgService;

        //internal System.Windows.Controls.TextBox txtDgServiceUrl;

        //internal System.Windows.Controls.CheckBox chkAnonymousQrCode;

        //internal StackPanel spOnlineResize;

        //internal System.Windows.Controls.TextBox txtOnlineResize;

        //internal Slider SliderOnlineResize;

        //internal StackPanel spStorageMediaResize;

        //internal System.Windows.Controls.TextBox txtSMResize;

        //internal Slider SliderSMResize;

        //internal System.Windows.Controls.Button btnSaveOnlineConfig;

        //internal System.Windows.Controls.Button btnOnlineBack;

        //internal TabItem TabManageScene;

        //internal System.Windows.Controls.ComboBox CmbSceneProductType;

        //internal System.Windows.Controls.ComboBox CmbBackgroundType;

        //internal System.Windows.Controls.Image ImgBacground;

        //internal System.Windows.Controls.TextBox txtSceneName;

        //internal System.Windows.Controls.ComboBox CmbBorderType;

        //internal System.Windows.Controls.Image ImgBorder;

        //internal System.Windows.Controls.CheckBox IsSceneActive;

        //internal System.Windows.Controls.Button btnSaveSelectScene;

        //internal System.Windows.Controls.Button btnCancelSelectScene;

        //internal System.Windows.Controls.Button btnBackScene;

        //internal System.Windows.Controls.DataGrid DGManageScene;

        //internal TabItem TabManageAudio;

        //internal System.Windows.Controls.DataGrid DGManageAudio;

        //internal System.Windows.Controls.Button btnBackAudio;

        //internal System.Windows.Controls.TextBox txtAudioDescription;

        //internal System.Windows.Controls.Button btnSelectAudio;

        //internal System.Windows.Controls.TextBox txtSelectedAudio;

        //internal System.Windows.Controls.Button btnSaveSelectAudio;

        //internal System.Windows.Controls.Button btnCancelSelectAudio;

        //internal System.Windows.Controls.CheckBox IsAudioActive;

        //internal TabItem TabManageVideoBG;

        //internal System.Windows.Controls.DataGrid DGManageVideoBG;

        //internal System.Windows.Controls.Button btnBackVideoBG;

        //internal System.Windows.Controls.TextBox txtVideoBGDescription;

        //internal System.Windows.Controls.Button btnSelectVideoBG;

        //internal System.Windows.Controls.TextBox txtSelectedVideoBG;

        //internal System.Windows.Controls.Button btnSaveVideoBG;

        //internal System.Windows.Controls.Button btnCancelVideoBG;

        //internal System.Windows.Controls.CheckBox IsVideoBGActive;

        //internal TabItem TabManageVideo;

        //internal System.Windows.Controls.DataGrid DGManageVideo;

        //internal System.Windows.Controls.Button btnBackVideo;

        //internal System.Windows.Controls.TextBox txtVideoDescription;

        //internal System.Windows.Controls.Button btnSelectVideo;

        //internal System.Windows.Controls.TextBox txtSelectedVideo;

        //internal System.Windows.Controls.Button btnSaveSelectVideo;

        //internal System.Windows.Controls.Button btnCancelSelectVideo;

        //internal System.Windows.Controls.CheckBox IsVideoActive;

        //internal TabItem TabCharacterConfiguration;

        //internal System.Windows.Controls.DataGrid DGCharacter;

        //internal System.Windows.Controls.TextBox txtCharacterName;

        //internal System.Windows.Controls.CheckBox IsCharacterActive;

        //internal System.Windows.Controls.Button btnSaveCharacter;

        //internal System.Windows.Controls.Button btnResetCharacter;

        //internal System.Windows.Controls.Button btnBackCharacter;

        //internal TabItem TabManageStockShot;

        //internal System.Windows.Controls.DataGrid grdManagestockShotImages;

        //internal System.Windows.Controls.Button btnBackStockShot;

        //internal System.Windows.Controls.Button btnSelectedStockImage;

        //internal System.Windows.Controls.TextBox txtSelectedStockImage;

        //internal System.Windows.Controls.CheckBox chkIsStockImageActive;

        //internal System.Windows.Controls.Button btnSaveStockShotImage;

        //internal System.Windows.Controls.Button btnCancelStockShot;

        //internal System.Windows.Controls.CheckBox IsStockShotImgActive;

        //internal TabItem TabManageOverlay;

        //internal System.Windows.Controls.DataGrid DGManageOverlay;

        //internal System.Windows.Controls.Button btnBackOverlay;

        //internal System.Windows.Controls.TextBox txtOverlayDescription;

        //internal System.Windows.Controls.Button btnSelectOverlay;

        //internal System.Windows.Controls.TextBox txtSelectedOverlay;

        //internal System.Windows.Controls.Button btnSaveSelectOverlay;

        //internal System.Windows.Controls.Button btnCancelSelectOverlay;

        //internal System.Windows.Controls.CheckBox IsOverlayActive;

        //internal Border KeyBorder;

        //internal System.Windows.Controls.Button Delete;

        //internal AddEditSpecPrintProfile ucAddEditSpecPrintProfile;

        //internal VideoSlotsTime CtrlVideoSlotsTime;

        //internal DigiMessageBox MsgBox;

        //private bool _contentLoaded;

        private PropertyChangedEventHandler propertyChanged;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add
            {
                do
                {
                IL_00:
                    PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChanged;
                    while (true)
                    {
                    IL_09:
                        PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
                        while (true)
                        {
                            PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Combine(propertyChangedEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, value2, propertyChangedEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4:;
                }
                while (!true);
            }
            remove
            {
                do
                {
                IL_00:
                    PropertyChangedEventHandler propertyChangedEventHandler = this.propertyChanged;
                    while (true)
                    {
                    IL_09:
                        PropertyChangedEventHandler propertyChangedEventHandler2 = propertyChangedEventHandler;
                        while (true)
                        {
                            PropertyChangedEventHandler value2 = (PropertyChangedEventHandler)Delegate.Remove(propertyChangedEventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            propertyChangedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.propertyChanged, value2, propertyChangedEventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (propertyChangedEventHandler == propertyChangedEventHandler2);
                                if (!false)
                                {
                                    arg_39_0 = !expr_31;
                                }
                                if (arg_39_0)
                                {
                                    goto IL_09;
                                }
                                if (!false)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    }
                Block_4:;
                }
                while (!true);
            }
        }

        public Dictionary<string, int> CodeTypeList
        {
            get
            {
                return this._codeTypeList;
            }
            set
            {
                this._codeTypeList = value;
            }
        }

        public Dictionary<string, int> ScanTypeList
        {
            get
            {
                return this._scanTypeList;
            }
            set
            {
                this._scanTypeList = value;
            }
        }

        public ObservableCollection<BackGroundInfo> BackgroundList
        {
            get
            {
                return this.backgroundList;
            }
            set
            {
                this.backgroundList = value;
                this.PropertyModified("BackgroundList");
            }
        }

        public BackGroundInfo EditableBackground
        {
            get
            {
                return this.editableBackground;
            }
            set
            {
                this.editableBackground = value;
                this.PropertyModified("SelectedBackground");
            }
        }

        public AllGraphics EditableGraphics
        {
            get
            {
                return this.editableGraphics;
            }
            set
            {
                this.editableGraphics = value;
                this.PropertyModified("EditableGraphics");
            }
        }

        public static Configuration Instance
        {
            get
            {
                do
                {
                    if (!false)
                    {
                        bool arg_10_0;
                        bool arg_33_0 = arg_10_0 = (Configuration.instance == null);
                        bool expr_36;
                        do
                        {
                            if (!false)
                            {
                                arg_33_0 = !arg_10_0;
                            }
                            bool flag = arg_33_0;
                            expr_36 = (arg_10_0 = (arg_33_0 = flag));
                        }
                        while (4 == 0);
                        if (expr_36)
                        {
                            goto IL_27;
                        }
                    }
                }
                while (5 == 0);
                Configuration.instance = new Configuration();
            IL_27:
                return Configuration.instance;
            }
            set
            {
                Configuration.instance = value;
            }
        }

        public int NumValue
        {
            get
            {
                return this._numValue;
            }
            set
            {
                this._numValue = value;
            }
        }

        public Configuration()
        {
            this.InitializeComponent();
            base.DataContext = this;
            this.txbUserName.Text = LoginUser.UserName;
            this.txbStoreName.Text = LoginUser.StoreName;
            //this.ucAddEditSpecPrintProfile.SetParentConfig(this);
            base.Dispatcher.BeginInvoke(DispatcherPriority.Background, new Configuration.LoadTabDelegate(this.LoadTabData));
            this.BackupWorker.DoWork += new DoWorkEventHandler(this.BackupWorker_DoWork);
            this.BackupWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.BackupWorker_RunWorkerCompleted);
            this.bw_CopySettings.DoWork += new DoWorkEventHandler(this.bw_CopySettings_DoWork);
            this.bw_CopySettings.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bw_CopySettings_RunWorkerCompleted);
            if (this.txtTables.Text == "")
            {
                this.txtTables.Text = "DG_Activity,ChangeTracking,CloudinaryDtl,DG_Photos,DG_Refund,DG_RefundDetails,DG_Orders_Details_Data,DG_Orders,DG_Orders_Details,DG_PrinterQueue,DG_PhotoGroup,DG_PhotosXml,RFIDTags,iMixImageAssociation,ArchivedPhotos,ArchivediMixImageAssociation,DG_Emails,DG_EmailDetail,ArchivedRFIDTags";
            }
            this.GetStockImgDetails();
            //this.MsgBox.SetParent(this.btn);
        }

        private void bw_CopySettings_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Window expr_03 = this.bs;
            if (3 != 0)
            {
                expr_03.Hide();
            }
            System.Windows.MessageBox.Show("Background saved Successfully");
            this.GetBackgrounds();
            this.txtSelectedBackground.Clear();
            if (!false)
            {
                this.lstBackgroundInfo.Clear();
            }
        }

        private void bw_CopySettings_DoWork(object sender, DoWorkEventArgs e)
        {
            this.SaveBackground();
        }

        private bool CheckValidation()
        {
            bool flag = true;
            bool arg_85_0;
            int expr_2EA = (arg_85_0 = string.IsNullOrEmpty(this.txtHotFolder.Text)) ? 1 : 0;
            int arg_85_1;
            int expr_1C = arg_85_1 = 0;
            if (expr_1C != 0)
            {
                goto IL_85;
            }
            bool flag2 = expr_2EA == expr_1C;
        IL_26:
            if (!flag2)
            {
                this.txtHotFolder.BorderBrush = System.Windows.Media.Brushes.Red;
                flag = false;
            }
            if (string.IsNullOrEmpty(this.txtPassword.Password))
            {
                this.txtPassword.BorderBrush = System.Windows.Media.Brushes.Red;
                flag = false;
            }
            arg_85_0 = string.IsNullOrEmpty(this.txtPageSize.Text);
            arg_85_1 = 0;
        IL_85:
            if ((arg_85_0 ? 1 : 0) != arg_85_1)
            {
                this.txtPageSize.BorderBrush = System.Windows.Media.Brushes.Red;
                flag = false;
            }
            bool arg_176_0;
            bool expr_B3 = arg_176_0 = !string.IsNullOrEmpty(this.txtConfigColorCode.Text);
            if (!false)
            {
                if (!expr_B3)
                {
                    this.txtConfigColorCode.BorderBrush = System.Windows.Media.Brushes.Red;
                    flag = false;
                }
                try
                {
                    int num;
                    if (!int.TryParse(this.txtPageSize.Text, out num))
                    {
                        num = 0;
                    }
                    if (num > 20 || num <= 0)
                    {
                        do
                        {
                            System.Windows.MessageBox.Show("Page size should be between 1 to 20");
                            this.txtPageSize.BorderBrush = System.Windows.Media.Brushes.Red;
                        }
                        while (false);
                        flag = false;
                    }
                }
                catch (Exception var_2_12C)
                {
                    this.txtPageSize.BorderBrush = System.Windows.Media.Brushes.Red;
                    flag = false;
                }
                if (string.IsNullOrEmpty(this.txtNoOfReceipt.Text.Trim()))
                {
                    goto IL_195;
                }
                arg_176_0 = Regex.IsMatch(this.txtNoOfReceipt.Text.Trim(), "^[0-9]*$");
            }
            if (!arg_176_0)
            {
                goto IL_195;
            }
            int arg_197_0 = (int.Parse(this.txtNoOfReceipt.Text.Trim()) >= 1) ? 1 : 0;
        IL_193:
            goto IL_196;
        IL_195:
            arg_197_0 = 0;
        IL_196:
            if (arg_197_0 != 0)
            {
                goto IL_1B2;
            }
            this.txtNoOfReceipt.BorderBrush = System.Windows.Media.Brushes.Red;
        IL_1AE:
            flag = false;
        IL_1B2:
            bool arg_204_0;
            if (string.IsNullOrEmpty(this.txtNoOfPhotoIdSearch.Text.Trim()) || !Regex.IsMatch(this.txtNoOfPhotoIdSearch.Text.Trim(), "^[0-9]*$"))
            {
                arg_204_0 = false;
                goto IL_203;
            }
        IL_1E5:
            arg_204_0 = (int.Parse(this.txtNoOfPhotoIdSearch.Text.Trim()) >= 1);
        IL_203:
            if (!arg_204_0)
            {
                this.txtNoOfPhotoIdSearch.BorderBrush = System.Windows.Media.Brushes.Red;
                flag = false;
            }
            flag2 = !flag;
            if (!flag2)
            {
                do
                {
                    this.txtbgPath.BorderBrush = System.Windows.Media.Brushes.Gray;
                    if (false)
                    {
                        goto IL_1E5;
                    }
                    this.txtBorderFolder.BorderBrush = System.Windows.Media.Brushes.Gray;
                    if (false)
                    {
                        goto IL_1AE;
                    }
                    this.txtHotFolder.BorderBrush = System.Windows.Media.Brushes.Gray;
                    this.txtPassword.BorderBrush = System.Windows.Media.Brushes.Gray;
                    if (5 == 0)
                    {
                        goto IL_26;
                    }
                    this.txtbgGraphics.BorderBrush = System.Windows.Media.Brushes.Gray;
                }
                while (false);
                this.txtNumber.BorderBrush = System.Windows.Media.Brushes.Gray;
                this.txtNoOfReceipt.BorderBrush = System.Windows.Media.Brushes.Gray;
                this.txtNoOfPhotoIdSearch.BorderBrush = System.Windows.Media.Brushes.Gray;
            }
            bool expr_2C8 = (arg_197_0 = (flag ? 1 : 0)) != 0;
            if (!false)
            {
                return expr_2C8;
            }
            goto IL_193;
        }

        private bool CheckValidationsCurrency()
        {
            bool flag;
            bool arg_42_0;
            bool arg_3E_0;
            do
            {
                flag = true;
                bool flag2;
                if (!false)
                {
                    bool expr_1A = false;
                    if (null != this.cmbCurrency.SelectedValue)
                    {



                        expr_1A = arg_3E_0 = (arg_42_0 = !(this.cmbCurrency.SelectedValue.ToString() == "0"));
                    }

                    if (false)
                    {
                        return arg_42_0;
                    }
                    if (8 == 0)
                    {
                        goto IL_3E;
                    }
                    flag2 = expr_1A;
                }
                if (flag2)
                {
                    break;
                }
                if (!false)
                {
                }
                System.Windows.MessageBox.Show("Please Select Default Currency.");
                bool expr_34 = false;
                if (!false)
                {
                    flag = expr_34;
                }
            }
            while (false);
            arg_3E_0 = flag;
        IL_3E:
            bool flag3 = arg_3E_0;
            arg_42_0 = flag3;
            return arg_42_0;
        }

        private void FillPrinters()
        {
            try
            {
                if (!false)
                {
                    goto IL_05;
                }
            IL_30:
                while (false)
                {
                }
                foreach (string text in PrinterSettings.InstalledPrinters)
                {
                    this.lstPrinterList.Add(text.ToString(), text.ToString());
                }
                if (!false)
                {
                    this.cmbReceiptPrinter.ItemsSource = this.lstPrinterList;
                    this.cmbReceiptPrinter.SelectedValue = "0";
                    return;
                }
                goto IL_14;
            IL_05:
                this.lstPrinterList = new Dictionary<string, string>();
            IL_14:
                if (-1 != 0)
                {
                    this.lstPrinterList.Add("--Select--", "0");
                    goto IL_30;
                }
                goto IL_05;
            }
            catch (Exception serviceException)
            {
                string message;
                if (!false)
                {
                    message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                }
                if (!false)
                {
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void GetConfigData()
        {
            ConfigBusiness configBusiness = new ConfigBusiness();
            ConfigurationInfo configurationData = configBusiness.GetConfigurationData(LoginUser.SubStoreId);
            if (configurationData != null)
            {
                this.txtbgPath.Text = configurationData.DG_BG_Path;
                this.txtBorderFolder.Text = configurationData.DG_Frame_Path;
                this.txtHotFolder.Text = configurationData.DG_Hot_Folder_Path;
                this.txtPassword.Password = configurationData.DG_Mod_Password;
                this.txtbgGraphics.Text = configurationData.DG_Graphics_Path;
                this.txtNumber.Text = configurationData.DG_NoOfPhotos.ToString();
                this.chkwatermark.IsChecked = configurationData.DG_Watermark;
                this.chkSemiOrder.IsChecked = configurationData.DG_SemiOrder;
                this.chkHgihResolutionPreview.IsChecked = configurationData.DG_HighResolution;
                this.chkTotalDiscount.IsChecked = configurationData.DG_EnableDiscountOnTotal;
                this.chkLineItemDiscount.IsChecked = configurationData.DG_AllowDiscount;
                this.chkEnablePos.IsChecked = configurationData.PosOnOff;
                this.chkAutoRotate.IsChecked = configurationData.DG_IsAutoRotate;
                this.chkCompressImage.IsChecked = configurationData.DG_IsCompression;
                this.cmbCurrency.SelectedValue = Convert.ToString(configurationData.DefaultCurrency);
                this.chkSemiOrderMain.IsChecked = new bool?(configurationData.DG_SemiOrderMain.ToBoolean(false));
                this.chkSaveReportToAnyDerive.IsChecked = new bool?(configurationData.IsExportReportToAnyDrive.ToBoolean(false));
                this.chkEnableGrouping.IsChecked = configurationData.DG_IsEnableGroup;
                this._isDefaultColorSeletedValue = Convert.ToString(configurationData.DG_ChromaColor);
                this.cmbChromaColor.SelectedValue = Convert.ToString(configurationData.DG_ChromaColor);
                this.txtChromaTolerance.Text = Convert.ToString(configurationData.DG_ChromaTolerance);
                this.cmbReceiptPrinter.SelectedValue = LoginUser.ReceiptPrinterPath;
                this.txtNoOfReceipt.Text = configurationData.DG_NoOfBillReceipt.ToString();
                this.txtNoOfPhotoIdSearch.Text = configurationData.DG_NoOfPhotoIdSearch.ToString();
                this.txtPageSize.Text = configurationData.DG_PageCountGrid.ToString();
                this.hiddenHFPath.Text = configurationData.DG_Hot_Folder_Path;
            }
            else
            {
                this.txtbgPath.Text = "";
                this.txtBorderFolder.Text = "";
                this.txtPassword.Password = "";
                this.txtbgGraphics.Text = "";
                this.txtNumber.Text = "";
                this.chkwatermark.IsChecked = new bool?(false);
                this.chkSemiOrder.IsChecked = new bool?(false);
                this.chkSemiOrderMain.IsChecked = new bool?(false);
                this.chkSaveReportToAnyDerive.IsChecked = new bool?(false);
                this.chkHgihResolutionPreview.IsChecked = new bool?(false);
                this.chkAutoRotate.IsChecked = new bool?(false);
                this.chkCompressImage.IsChecked = new bool?(false);
                this.cmbCurrency.SelectedValue = "0";
                this.cmbReceiptPrinter.SelectedValue = "0";
                configBusiness = new ConfigBusiness();
                ConfigurationInfo deafultPathData = configBusiness.GetDeafultPathData();
                if (deafultPathData != null)
                {
                    this.txtHotFolder.Text = deafultPathData.DG_Hot_Folder_Path;
                }
                this.txtNoOfReceipt.Text = "1";
                this.txtNoOfPhotoIdSearch.Text = "10";
            }
            this.txtHotFolder.Focus();
            this.txtbgPath.BorderBrush = System.Windows.Media.Brushes.Gray;
            this.txtBorderFolder.BorderBrush = System.Windows.Media.Brushes.Gray;
            this.txtHotFolder.BorderBrush = System.Windows.Media.Brushes.Gray;
            this.txtPassword.BorderBrush = System.Windows.Media.Brushes.Gray;
            this.txtbgGraphics.BorderBrush = System.Windows.Media.Brushes.Gray;
            this.txtNumber.BorderBrush = System.Windows.Media.Brushes.Gray;
            this.txtNoOfReceipt.BorderBrush = System.Windows.Media.Brushes.Gray;
            this.txtNoOfPhotoIdSearch.BorderBrush = System.Windows.Media.Brushes.Gray;
        }

        private void SaveConfigData()
        {
            int pageSizeGrid = this.txtPageSize.Text.ToInt32(false);
            int pageSizePreview = 4;
            if (this.txtTables.Text == "")
            {
                this.txtTables.Text = "DG_Activity,ChangeTracking,CloudinaryDtl,DG_Photos,DG_Refund,DG_RefundDetails,DG_Orders_Details_Data,DG_Orders,DG_Orders_Details,DG_PrinterQueue,DG_PhotoGroup,DG_PhotosXml,RFIDTags,iMixImageAssociation,ArchivedPhotos,ArchivediMixImageAssociation,DG_Emails,DG_EmailDetail,ArchivedRFIDTags";
            }
            string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Configuration).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, LoginUser.SubStoreId.ToString().PadLeft(2, '0'));
            ConfigBusiness configBusiness = new ConfigBusiness();
            bool flag = configBusiness.SetConfigurationData(uniqueSynccode, this.txtHotFolder.Text, this.txtHotFolder.Text + "Frames\\", this.txtHotFolder.Text + "BG\\", this.txtPassword.Password, this.txtHotFolder.Text + "Graphics\\", 1000, this.chkwatermark.IsChecked, this.chkHgihResolutionPreview.IsChecked, this.chkSemiOrder.IsChecked, this.chkAutoRotate.IsChecked, this.chkLineItemDiscount.IsChecked, this.chkTotalDiscount.IsChecked, this.chkEnablePos.IsChecked, this.cmbCurrency.SelectedValue.ToInt32(false), this.chkSemiOrderMain.IsChecked, LoginUser.SubStoreId, this.chkCompressImage.IsChecked, this.chkEnableGrouping.IsChecked, int.Parse(this.txtNoOfReceipt.Text.Trim()), this.cmbChromaColor.SelectedValue.ToString(), decimal.Parse(this.txtChromaTolerance.Text), pageSizeGrid, pageSizePreview, int.Parse(this.txtNoOfPhotoIdSearch.Text.Trim()), this.chkSaveReportToAnyDerive.IsChecked);
            List<iMIXConfigurationInfo> list = new List<iMIXConfigurationInfo>();
            iMIXConfigurationInfo iMIXConfigurationInfo = new iMIXConfigurationInfo();
            iMIXConfigurationInfo iMIXConfigurationInfo3;
            bool flag3;
            while (true)
            {
                iMIXConfigurationInfo.IMIXConfigurationMasterId = Convert.ToInt64(ConfigParams.SequencePrefix);
                bool arg_2AE_0;
                int expr_212 = (arg_2AE_0 = string.IsNullOrEmpty(this.txtSeqPrefix.Text.Trim())) ? 1 : 0;
                int arg_2AE_1;
                int expr_218 = arg_2AE_1 = 0;
                bool flag2;
                if (expr_218 == 0)
                {
                    flag2 = (expr_212 == expr_218);
                    goto IL_222;
                }
            IL_2AE:
                flag2 = ((arg_2AE_0 ? 1 : 0) == arg_2AE_1);
                iMIXConfigurationInfo iMIXConfigurationInfo2 = new iMIXConfigurationInfo();
                if (!flag2)
                {
                    iMIXConfigurationInfo2.ConfigurationValue = "7";
                }
                else
                {
                    iMIXConfigurationInfo2.ConfigurationValue = this.txtImageBarCodeTextFontSize.Text;
                }
                iMIXConfigurationInfo2.SubstoreId = LoginUser.SubStoreId;
                list.Add(iMIXConfigurationInfo2);
                if (true)
                {
                    iMIXConfigurationInfo3 = new iMIXConfigurationInfo();
                    iMIXConfigurationInfo3.IMIXConfigurationMasterId = Convert.ToInt64(ConfigParams.ColorCode);
                    iMIXConfigurationInfo3.ConfigurationValue = this.txtConfigColorCode.Text;
                    iMIXConfigurationInfo3.SubstoreId = LoginUser.SubStoreId;
                    if (!false)
                    {
                        break;
                    }
                    continue;
                }
            IL_222:
                if (!flag2)
                {
                    iMIXConfigurationInfo.ConfigurationValue = LoginUser.SubstoreName;
                }
                else
                {
                    iMIXConfigurationInfo.ConfigurationValue = this.txtSeqPrefix.Text;
                }
                iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                list.Add(iMIXConfigurationInfo);
                this.configBusiness = new ConfigBusiness();
                flag3 = this.configBusiness.SaveUpdateNewConfig(list);
                iMIXConfigurationInfo2 = new iMIXConfigurationInfo();
                iMIXConfigurationInfo2.IMIXConfigurationMasterId = Convert.ToInt64(ConfigParams.ImageBarCodeTextFontSize);
                arg_2AE_0 = string.IsNullOrEmpty(this.txtImageBarCodeTextFontSize.Text.Trim());
                arg_2AE_1 = 0;
                goto IL_2AE;
            }
            list.Add(iMIXConfigurationInfo3);
            this.configBusiness = new ConfigBusiness();
            flag3 = this.configBusiness.SaveUpdateNewConfig(list);
            if (flag && flag3)
            {
                System.Windows.MessageBox.Show("Record saved successfully");
                this.txtDefaultCurrency.Text = this.GetDefaultCurrency().ToString();
                AuditLog.AddUserLog(LoginUser.UserId, 53, "Add/Edit configuration data at:- ");
                RobotImageLoader.GetConfigData();
                this.GetNewConfigData();
            }
        }

        private string GetDefaultCurrency()
        {
            if (7 == 0 || false)
            {
                goto IL_54;
            }
        IL_07:
            string text = (from objcurrency in new PhotoSW.IMIX.Business.CurrencyBusiness().GetCurrencyList().Where(delegate (CurrencyInfo objcurrency)
            {
                bool? dG_Currency_Default = objcurrency.DG_Currency_Default;
                int arg_42_0;
                if (!dG_Currency_Default.GetValueOrDefault())
                {
                    arg_42_0 = 0;
                    goto IL_16;
                }
                arg_42_0 = (dG_Currency_Default.HasValue ? 1 : 0);
            IL_10:
                if (!false)
                {
                }
            IL_16:
                bool expr_45;
                do
                {
                    bool flag = arg_42_0 != 0;
                    if (!false)
                    {
                    }
                    expr_45 = ((arg_42_0 = (flag ? 1 : 0)) != 0);
                }
                while (8 == 0);
                if (!false)
                {
                    return expr_45;
                }
                goto IL_10;
            })
                           select objcurrency.DG_Currency_Name.ToString()).FirstOrDefault<string>();
        IL_54:
            string result = text;
            if (-1 != 0)
            {
                return result;
            }
            goto IL_07;
        }

        private void GetNewConfigData()
        {
            List<iMIXConfigurationInfo> newConfigValues = new ConfigBusiness().GetNewConfigValues(LoginUser.SubStoreId);
            if (newConfigValues != null)
            {
                bool flag = false;
                foreach (iMIXConfigurationInfo current in newConfigValues)
                {
                    long iMIXConfigurationMasterId = current.IMIXConfigurationMasterId;
                    List<TableBaseInfo> allTable;
                    if (iMIXConfigurationMasterId <= 80L)
                    {
                        if (iMIXConfigurationMasterId <= 40L)
                        {
                            if (iMIXConfigurationMasterId < 1L)
                            {
                                continue;
                            }
                            switch ((int)(iMIXConfigurationMasterId - 1L))
                            {
                                case 0:
                                    if (current.ConfigurationValue.ToLower() == "true")
                                    {
                                        this.chkIsBarcodeActive.IsChecked = new bool?(true);
                                        flag = true;
                                    }
                                    continue;
                                case 1:
                                    {
                                        bool arg_19A_0 = !flag;
                                        bool expr_19C;
                                        do
                                        {
                                            bool flag2 = arg_19A_0;
                                            expr_19C = (arg_19A_0 = flag2);
                                        }
                                        while (6 == 0);
                                        if (!expr_19C)
                                        {
                                            this.cmbMappingType.SelectedValue = current.ConfigurationValue;
                                        }
                                        continue;
                                    }
                                case 2:
                                    if (flag)
                                    {
                                        this.cmbScanType.SelectedValue = current.ConfigurationValue;
                                    }
                                    continue;
                                case 3:
                                    this.txtLostImgTimeGap.Text = current.ConfigurationValue;
                                    continue;
                                case 4:
                                    this.txtOnlineResize.Text = current.ConfigurationValue;
                                    continue;
                                case 5:
                                    this.txtSMResize.Text = current.ConfigurationValue;
                                    continue;
                                case 6:
                                    this.chkIsOnline.IsChecked = new bool?(string.Compare(current.ConfigurationValue, "True", true) == 0);
                                    continue;
                                case 7:
                                    this.txtDgServiceUrl.Text = current.ConfigurationValue;
                                    continue;
                                case 8:
                                    this.txtDbBackupPath.Text = Convert.ToString(current.ConfigurationValue);
                                    if (!string.IsNullOrWhiteSpace(this.txtDbBackupPath.Text))
                                    {
                                        this.btnBackupNow.IsEnabled = true;
                                    }
                                    continue;
                                case 9:
                                    {
                                        this.txtTables.Text = Convert.ToString(current.ConfigurationValue);
                                        string[] source = this.txtTables.Text.Split(new char[]
                                        {
                                    ','
                                        });
                                        List<string> list = source.ToList<string>();
                                        CommonBusiness commonBusiness = new CommonBusiness();
                                        allTable = commonBusiness.GetAllTable();
                                        goto IL_2F4;
                                    }
                                case 10:
                                    this.txtHfBackupPath.Text = Convert.ToString(current.ConfigurationValue);
                                    continue;
                                case 11:
                                    if (this.chkSchBackup.IsChecked == true)
                                    {
                                        goto IL_45D;
                                    }
                                    this.ccBackupDateTime.Value = new DateTime?(DateTime.Now.Date.Add(new TimeSpan(6, 0, 0)));
                                    continue;
                                case 12:
                                    this.chkSchBackup.IsChecked = new bool?(current.ConfigurationValue.ToBoolean(false));
                                    continue;
                                case 13:
                                    this.chkRecursive.IsChecked = new bool?(current.ConfigurationValue.ToBoolean(false));
                                    continue;
                                case 14:
                                    this.cmbSelectRecursiveCount.SelectedValue = Convert.ToString(current.ConfigurationValue);
                                    continue;
                                case 15:
                                    this.cmbSelectRecursiveTime.SelectedValue = Convert.ToString(current.ConfigurationValue);
                                    continue;
                                case 16:
                                    this.txtCleanupdays.Text = Convert.ToString(current.ConfigurationValue);
                                    continue;
                                case 17:
                                    this.brightVal.Value = current.ConfigurationValue.ToDouble(false);
                                    this.txtbright.Text = Convert.ToString(current.ConfigurationValue);
                                    continue;
                                case 18:
                                    this.contrastVal.Value = current.ConfigurationValue.ToDouble(false);
                                    this.txtcontrasts.Text = Convert.ToString(current.ConfigurationValue);
                                    continue;
                                case 19:
                                    this.sharpVal.Value = current.ConfigurationValue.ToDouble(false);
                                    this.txtsharp.Text = Convert.ToString(current.ConfigurationValue);
                                    continue;
                                case 20:
                                case 21:
                                case 22:
                                case 23:
                                case 24:
                                case 25:
                                case 26:
                                case 27:
                                case 28:
                                case 29:
                                case 30:
                                case 31:
                                case 32:
                                case 33:
                                case 34:
                                case 35:
                                case 36:
                                case 38:
                                    continue;
                                case 37:
                                    this.chkAnonymousQrCode.IsChecked = new bool?(current.ConfigurationValue.ToBoolean(false));
                                    continue;
                                case 39:
                                    this.chkIsAutoPurchaseActive.IsChecked = new bool?(current.ConfigurationValue.ToBoolean(false));
                                    continue;
                            }
                        }
                        if (iMIXConfigurationMasterId != 76L)
                        {
                            if (iMIXConfigurationMasterId == 80L)
                            {
                                this.txtImageBarCodeTextFontSize.Text = Convert.ToString(current.ConfigurationValue);
                            }
                        }
                        else
                        {
                            this.txtSeqPrefix.Text = current.ConfigurationValue;
                        }
                    }
                    else if (iMIXConfigurationMasterId != 94L)
                    {
                        if (iMIXConfigurationMasterId != 107L)
                        {
                            if (iMIXConfigurationMasterId == 180L)
                            {
                                if (false)
                                {
                                    goto IL_2F4;
                                }
                                this.txtFailedOnlineOrderCleanupdays.Text = current.ConfigurationValue.ToString();
                            }
                        }
                        else
                        {
                            this.txtQRCodeLen.Text = Convert.ToString(current.ConfigurationValue);
                        }
                    }
                    else
                    {
                        this.txtConfigColorCode.Text = Convert.ToString(current.ConfigurationValue);
                        if (6 == 0)
                        {
                            goto IL_45D;
                        }
                        if (this.txtConfigColorCode.Text != "")
                        {
                            this._isDefaultColorCode = false;
                        }
                    }
                    continue;
                IL_2F4:
                    List<Configuration.Action> list2 = new List<Configuration.Action>();
                    if (allTable != null)
                    {
                        List<TableBaseInfo>.Enumerator enumerator2 = allTable.GetEnumerator();
                        try
                        {
                            while (enumerator2.MoveNext())
                            {
                                TableBaseInfo current2 = enumerator2.Current;
                                list2.Add(new Configuration.Action
                                {
                                    IsSelected = false,
                                    Name = current2.name
                                });
                            }
                        }
                        finally
                        {
                            do
                            {
                                ((IDisposable)enumerator2).Dispose();
                            }
                            while (false);
                        }
                    }
                    foreach (Configuration.Action current3 in list2)
                    {
                        List<string> list = new List<string>();
                        foreach (string current4 in list)
                        {
                            if (current3.Name.Trim() == current4.Trim())
                            {
                                current3.IsSelected = true;
                            }
                        }
                    }
                    this.listtables.ItemsSource = list2;
                    continue;
                IL_45D:
                    DateTime value = DateTime.Parse(current.ConfigurationValue);
                    this.ccBackupDateTime.Value = new DateTime?(value);
                }
            }
        }

        private void GetBackupNewConfigData()
        {
            System.Windows.Controls.TextBox expr_06 = this.txtTables;
            string expr_0B = string.Empty;
            if (!false)
            {
                expr_06.Text = expr_0B;
            }
            if (!false)
            {
                ConfigBusiness configBusiness = new ConfigBusiness();
                ConfigurationInfo configurationData = configBusiness.GetConfigurationData(LoginUser.SubStoreId);
                if (configurationData == null)
                {
                    goto IL_61;
                }
                string dG_Hot_Folder_Path = configurationData.DG_Hot_Folder_Path;
            IL_53:
                this.hiddenHFPath.Text = dG_Hot_Folder_Path;
            IL_61:
                List<iMIXConfigurationInfo> newConfigValues = configBusiness.GetNewConfigValues(LoginUser.SubStoreId);
                string[] source;
                List<string> list;
                CommonBusiness commonBusiness;
                List<TableBaseInfo> allTable;
                List<Configuration.Action> list2;
                if (newConfigValues != null)
                {
                    using (List<iMIXConfigurationInfo>.Enumerator enumerator = newConfigValues.GetEnumerator())
                    {
                        while (true)
                        {
                            while (enumerator.MoveNext())
                            {
                                iMIXConfigurationInfo current = enumerator.Current;
                                long iMIXConfigurationMasterId = current.IMIXConfigurationMasterId;
                                if (iMIXConfigurationMasterId <= 17L)
                                {
                                    if (7 != 0)
                                    {
                                        if (iMIXConfigurationMasterId >= 9L)
                                        {
                                            switch ((int)(iMIXConfigurationMasterId - 9L))
                                            {
                                                case 0:
                                                    this.txtDbBackupPath.Text = Convert.ToString(current.ConfigurationValue);
                                                    if (!string.IsNullOrWhiteSpace(this.txtDbBackupPath.Text))
                                                    {
                                                        this.btnBackupNow.IsEnabled = true;
                                                    }
                                                    break;
                                                case 1:
                                                    this.txtTables.Text = Convert.ToString(current.ConfigurationValue);
                                                    source = this.txtTables.Text.Split(new char[]
                                                    {
                                                    ','
                                                    });
                                                    list = source.ToList<string>();
                                                    commonBusiness = new CommonBusiness();
                                                    allTable = commonBusiness.GetAllTable();
                                                    list2 = new List<Configuration.Action>();
                                                    if (allTable != null)
                                                    {
                                                        foreach (TableBaseInfo current2 in allTable)
                                                        {
                                                            list2.Add(new Configuration.Action
                                                            {
                                                                IsSelected = false,
                                                                Name = current2.name
                                                            });
                                                        }
                                                    }
                                                    //goto IL_1EA;
                                                    break;
                                                case 2:
                                                    this.txtHfBackupPath.Text = Convert.ToString(current.ConfigurationValue);
                                                    if (5 == 0)
                                                    {
                                                        //goto IL_1EA;
                                                    }
                                                    break;
                                                case 3:
                                                    if (this.chkSchBackup.IsChecked == true)
                                                    {
                                                        DateTime value = DateTime.Parse(current.ConfigurationValue);
                                                        this.ccBackupDateTime.Value = new DateTime?(value);
                                                    }
                                                    else
                                                    {
                                                        this.ccBackupDateTime.Value = new DateTime?(DateTime.Now.Date.Add(new TimeSpan(6, 0, 0)));
                                                    }
                                                    break;
                                                case 4:
                                                    this.chkSchBackup.IsChecked = new bool?(current.ConfigurationValue.ToBoolean(false));
                                                    break;
                                                case 5:
                                                    this.chkRecursive.IsChecked = new bool?(current.ConfigurationValue.ToBoolean(false));
                                                    break;
                                                case 6:
                                                    this.cmbSelectRecursiveCount.SelectedValue = Convert.ToString(current.ConfigurationValue);
                                                    break;
                                                case 7:
                                                    this.cmbSelectRecursiveTime.SelectedValue = Convert.ToString(current.ConfigurationValue);
                                                    break;
                                                case 8:
                                                    this.txtCleanupdays.Text = Convert.ToString(current.ConfigurationValue);
                                                    break;
                                            }
                                            continue;
                                            do
                                            {
                                            IL_1EA:
                                                foreach (Configuration.Action current3 in list2)
                                                {
                                                    List<string>.Enumerator enumerator4 = list.GetEnumerator();
                                                    try
                                                    {
                                                        while (enumerator4.MoveNext())
                                                        {
                                                            string current4 = enumerator4.Current;
                                                            if (current3.Name.Trim() == current4.Trim())
                                                            {
                                                                current3.IsSelected = true;
                                                            }
                                                        }
                                                    }
                                                    finally
                                                    {
                                                        if (!false)
                                                        {
                                                            ((IDisposable)enumerator4).Dispose();
                                                        }
                                                    }
                                                }
                                                if (5 == 0)
                                                {
                                                    goto IL_3C1;
                                                }
                                            }
                                            while (false);
                                            this.listtables.ItemsSource = list2;
                                        IL_3C1:;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                    return;
                }
                source = this.txtTables.Text.Split(new char[]
                {
                    ','
                });
                list = source.ToList<string>();
                commonBusiness = new CommonBusiness();
                allTable = commonBusiness.GetAllTable();
                list2 = new List<Configuration.Action>();
                if (!true)
                {
                    goto IL_53;
                }
                if (allTable != null)
                {
                    using (List<TableBaseInfo>.Enumerator enumerator2 = allTable.GetEnumerator())
                    {
                        while (true)
                        {
                            bool flag = enumerator2.MoveNext();
                            if (!false)
                            {
                                if (!flag)
                                {
                                    break;
                                }
                                TableBaseInfo current2 = enumerator2.Current;
                                list2.Add(new Configuration.Action
                                {
                                    IsSelected = false,
                                    Name = current2.name
                                });
                            }
                        }
                    }
                }
                List<Configuration.Action>.Enumerator enumerator3 = list2.GetEnumerator();
                try
                {
                    while (enumerator3.MoveNext())
                    {
                        Configuration.Action current3 = enumerator3.Current;
                        foreach (string current4 in list)
                        {
                            if (current3.Name.Trim() == current4.Trim())
                            {
                                current3.IsSelected = true;
                            }
                        }
                    }
                }
                finally
                {
                    if (!false)
                    {
                        ((IDisposable)enumerator3).Dispose();
                    }
                }
                this.listtables.ItemsSource = list2;
                this.txtDbBackupPath.Text = string.Empty;
                this.txtTables.Text = string.Empty;
                this.txtCleanupdays.Text = string.Empty;
                this.txtHfBackupPath.Text = string.Empty;
            }
            this.chkSchBackup.IsChecked = new bool?(false);
            this.ccBackupDateTime.Value = new DateTime?(DateTime.Now.Date.Add(new TimeSpan(6, 0, 0)));
        }

        private void fillRecursiveNewOptions()
        {
            if (!false)
            {
                this.cmbSelectRecursiveCount.Items.Clear();
                while (true)
                {
                    int num = 1;
                    while (true)
                    {
                        if (!false)
                        {
                            while (4 != 0)
                            {
                                if (num >= 30)
                                {
                                    goto IL_59;
                                }
                                this.cmbSelectRecursiveCount.Items.Add(num.ToString());
                                int arg_4B_0 = num++;
                            }
                            break;
                        }
                    IL_59:
                        this.cmbSelectRecursiveTime.Items.Clear();
                        if (!false)
                        {
                            goto Block_4;
                        }
                    }
                }
            Block_4:
                this.cmbSelectRecursiveTime.Items.Add(Configuration.IntervalType.Day.ToString());
            }
            this.cmbSelectRecursiveTime.Items.Add(Configuration.IntervalType.Week.ToString());
            this.cmbSelectRecursiveTime.Items.Add(Configuration.IntervalType.Month.ToString());
        }

        private void btnBackupNow_Click(object sender, RoutedEventArgs e)
        {
            if (4 != 0)
            {
                if (false)
                {
                    goto IL_1CA;
                }
                int arg_205_0;
                int arg_1D5_0;
                bool expr_3A8 = (arg_1D5_0 = (arg_205_0 = (string.IsNullOrEmpty(this.txtDbBackupPath.Text.Trim()) ? 1 : 0))) != 0;
                if (2 == 0)
                {
                    goto IL_1D5;
                }
                if (false)
                {
                    goto IL_200;
                }
                if (expr_3A8)
                {
                    System.Windows.MessageBox.Show("Select database backup path.", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                if (string.IsNullOrEmpty(this.txtHfBackupPath.Text.Trim()))
                {
                    System.Windows.MessageBox.Show("Select hot folder backup path.", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                bool arg_1A2_0;
                bool expr_A5 = arg_1A2_0 = string.IsNullOrEmpty(this.txtCleanupdays.Text.Trim());
                if (false)
                {
                    goto IL_1A2;
                }
                int arg_B3_0 = (!expr_A5) ? 1 : 0;
            IL_B3:
                if (arg_B3_0 == 0)
                {
                    System.Windows.MessageBox.Show("Select No of days for Cleanup Backup.", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
            IL_D2:
                bool expr_E2 = (arg_205_0 = (string.IsNullOrEmpty(this.txtFailedOnlineOrderCleanupdays.Text.Trim()) ? 1 : 0)) != 0;
                if (false)
                {
                    goto IL_200;
                }
                if (expr_E2)
                {
                    System.Windows.MessageBox.Show("Select No of days for failed online orders Backup.", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                int expr_11F = arg_B3_0 = Convert.ToInt32(this.txtCleanupdays.Text.Trim());
                if (7 == 0)
                {
                    goto IL_B3;
                }
                if (expr_11F > Convert.ToInt32(this.txtFailedOnlineOrderCleanupdays.Text.Trim()))
                {
                    System.Windows.MessageBox.Show("Failed online orders cleanup days should be grater then backup cleanup days!", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Hand);
                    return;
                }
                string connectionString = ConfigurationManager.ConnectionStrings["DigiConnectionString"].ConnectionString;
                string[] array = connectionString.Split(new char[]
                {
                    ';'
                });
                Hashtable hashtable = new Hashtable();
                bool flag = array.Length == 0;
                arg_1A2_0 = flag;
            IL_1A2:
                int num;
                if (!arg_1A2_0)
                {
                    num = 0;
                    goto IL_1FF;
                }
                goto IL_211;
            IL_1CA:
                string[] array2;
                flag = (array2.Length == 0);
                arg_1D5_0 = (flag ? 1 : 0);
            IL_1D5:
                if (arg_1D5_0 == 0)
                {
                    if (!hashtable.ContainsKey(array2[0]))
                    {
                        hashtable.Add(array2[0], array2[1]);
                    }
                }
                num++;
            IL_1FF:
                arg_205_0 = num;
            IL_200:
                if (arg_205_0 <= array.Length - 1)
                {
                    if (!false)
                    {
                        array2 = array[num].Split(new char[]
                        {
                            '='
                        });
                        goto IL_1CA;
                    }
                    goto IL_D2;
                }
            IL_211:
                this._databasename = (hashtable.ContainsKey("Initial Catalog") ? hashtable["Initial Catalog"].ToString() : ConfigurationManager.AppSettings["DatabaseName"]);
                this._username = (hashtable.ContainsKey("User ID") ? hashtable["User ID"].ToString() : ConfigurationManager.AppSettings["UserName"]);
                this._pass = (hashtable.ContainsKey("Password") ? hashtable["Password"].ToString() : ConfigurationManager.AppSettings["UserPass"]);
                this._server = (hashtable.ContainsKey("Data Source") ? hashtable["Data Source"].ToString() : ConfigurationManager.AppSettings["UserPass"]);
                this._destinationPath = this.txtDbBackupPath.Text;
                this._imgSource = this.hiddenHFPath.Text;
                this._imgDestination = this.txtHfBackupPath.Text;
                CommonBusiness commonBusiness = new CommonBusiness();
                List<TableBaseInfo> allTable = commonBusiness.GetAllTable();
                this.listtables.DataContext = allTable;
                this._heavyTables = this.txtTables.Text;
                this._cleanupdaysBackup = this.txtCleanupdays.Text.ToInt32(false);
                this._FailedOnlineCleanupdayes = this.txtFailedOnlineOrderCleanupdays.Text.ToInt32(false);
                this.bs.Show();
                this.BackupWorker.RunWorkerAsync();
            }
        }

        private void BackupWorker_DoWork(object Sender, DoWorkEventArgs e)
        {
            this.errorMsg = "Error Message: There is not enough space in the disk/Drive not found.";
            try
            {
                int arg_A8_0 = 0;
                while (true)
                {
                    int num = arg_A8_0;
                    bool flag;
                    bool flag2;
                    if (!false)
                    {
                        flag = false;
                        bool expr_3F = !FrameworkHelper.Common.clsBackup.IsMemoryAvailable(this._imgSource, this._imgDestination, LoginUser.SubStoreId);
                        if (false)
                        {
                            goto IL_48;
                        }
                        flag2 = expr_3F;
                        goto IL_48;
                    }
                IL_75:
                    int expr_77 = arg_A8_0 = 1;
                    if (expr_77 != 0)
                    {
                        flag = (expr_77 != 0);
                        goto IL_7C;
                    }
                    continue;
                IL_48:
                    if (!flag2)
                    {
                        e.Result = this.DoBackupNow(ref num);
                        goto IL_5F;
                    }
                    goto IL_75;
                IL_7C:
                    flag2 = !flag;
                    if (!flag2)
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(this.errorMsg);
                        if (2 == 0)
                        {
                            goto IL_5F;
                        }
                        this.SaveEmailDetails(this.errorMsg);
                    }
                    if (-1 != 0)
                    {
                        break;
                    }
                    goto IL_48;
                IL_5F:
                    int arg_67_0;
                    int expr_5F = arg_67_0 = num;
                    int arg_67_1;
                    int expr_61 = arg_67_1 = 1;
                    if (expr_61 != 0)
                    {
                        arg_67_0 = ((expr_5F == expr_61) ? 1 : 0);
                        goto IL_66;
                    }
                IL_67:
                    flag2 = (arg_67_0 == arg_67_1);
                    if (!flag2)
                    {
                        int expr_6E = arg_67_0 = 1;
                        if (expr_6E == 0)
                        {
                            goto IL_66;
                        }
                        flag = (expr_6E != 0);
                    }
                    goto IL_7C;
                IL_66:
                    arg_67_1 = 0;
                    goto IL_67;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ex.Message + this.errorMsg);
            }
        }

        private void BackupWorker_RunWorkerCompleted(object Sender, RunWorkerCompletedEventArgs e)
        {
            this.bs.Hide();
            System.Windows.MessageBox.Show(this, (e.Result == null) ? this.errorMsg : e.Result.ToString(), "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            this.GetBackupNewConfigData();
        }

        private object DoBackupNow(ref int errorId)
        {
            string text = "";
            object result;
            object obj;
            try
            {
                if (!string.IsNullOrEmpty(this._destinationPath) && !string.IsNullOrWhiteSpace(this._destinationPath))
                {
                    bool arg_85_0;
                    bool expr_352 = arg_85_0 = Directory.Exists(this._destinationPath);
                    bool flag;
                    if (5 != 0)
                    {
                        if (!expr_352)
                        {
                            obj = (result = "Drive Not Exists");
                            return result;
                        }
                        flag = FrameworkHelper.Common.clsBackup.BackupDatabase(this._databasename, this._username, this._pass, this._server, this._destinationPath, ref errorId);
                        arg_85_0 = flag;
                    }
                    bool arg_93_0;
                    if (arg_85_0)
                    {
                        arg_93_0 = true;
                        goto IL_92;
                    }
                    bool arg_8D_0 = errorId == 1;
                    int arg_8D_1 = 0;
                IL_8D:
                    arg_93_0 = ((arg_8D_0 ? 1 : 0) == arg_8D_1);
                IL_92:
                    bool flag2 = arg_93_0;
                    int arg_97_0 = flag2 ? 1 : 0;
                IL_97:
                    while (Convert.ToBoolean(arg_97_0))
                    {
                        if (flag)
                        {
                            int num2;
                            while (true)
                            {
                            IL_BF:
                                text += "- Database backup complete! \n\r\n\r";
                                int arg_179_0;
                                bool expr_D1 = (arg_97_0 = (arg_179_0 = (string.IsNullOrEmpty(this._heavyTables) ? 1 : 0))) != 0;
                                if (false)
                                {
                                    goto IL_16F;
                                }
                                if (expr_D1)
                                {
                                    goto IL_2CB;
                                }
                                if (!this._heavyTables.EndsWith(","))
                                {
                                    this._heavyTables += ",";
                                }
                                bool flag3 = FrameworkHelper.Common.clsBackup.EmptyTables(this._heavyTables, this._cleanupdaysBackup, this._cleanupdaysBackup, LoginUser.SubStoreId, this._FailedOnlineCleanupdayes);
                                flag2 = !flag3;
                                if (flag2)
                                {
                                    goto IL_2B8;
                                }
                                text += "- Specified tables have been emptied! \n\r\n\r";
                                if (-1 != 0)
                                {
                                    if (!string.IsNullOrEmpty(this._imgDestination))
                                    {
                                        arg_179_0 = (arg_97_0 = (string.IsNullOrWhiteSpace(this._imgDestination) ? 1 : 0));
                                        goto IL_16F;
                                    }
                                    arg_179_0 = (arg_97_0 = 1);
                                    goto IL_172;
                                }
                            IL_1E3:
                                if (flag2)
                                {
                                    goto IL_26E;
                                }
                                int num = 1;
                                string destinationFld;
                                while (true)
                                {
                                    int expr_23E = (arg_8D_0 = (num == 0)) ? 1 : 0;
                                    int expr_241 = arg_8D_1 = 0;
                                    if (expr_241 != 0)
                                    {
                                        goto IL_8D;
                                    }
                                    flag2 = (expr_23E == expr_241);
                                    if (2 == 0)
                                    {
                                        goto IL_BF;
                                    }
                                    if (!flag2)
                                    {
                                        goto Block_24;
                                    }
                                    num = FrameworkHelper.Common.clsBackup.GetPhotoArchived(LoginUser.SubStoreId);
                                    int arg_22F_0;
                                    int expr_200 = arg_22F_0 = ((num > 0) ? 1 : 0);
                                    int arg_22F_1;
                                    int expr_203 = arg_22F_1 = 0;
                                    if (expr_203 != 0)
                                    {
                                        goto IL_22F;
                                    }
                                    if (expr_200 != expr_203)
                                    {
                                        Configuration.DoBackupNowDaily(LoginUser.SubStoreId, this._imgSource);
                                        arg_22F_0 = num2;
                                        arg_22F_1 = FrameworkHelper.Common.clsBackup.CopyDirectoryFiles(destinationFld, this._imgSource);
                                        goto IL_22F;
                                    }
                                    continue;
                                IL_22F:
                                    num2 = arg_22F_0 + arg_22F_1;
                                    bool flag4 = FrameworkHelper.Common.clsBackup.UpdateArchivedPhotoDetails();
                                }
                            IL_172:
                                if (false)
                                {
                                    goto IL_97;
                                }
                                if (arg_179_0 != 0)
                                {
                                    goto IL_2A5;
                                }
                                if (!Directory.Exists(this._imgDestination))
                                {
                                    goto IL_292;
                                }
                                if (string.IsNullOrEmpty(this._imgSource))
                                {
                                    goto IL_286;
                                }
                                bool flag5 = true;
                                destinationFld = FrameworkHelper.Common.clsBackup.CreateBackupFolderExits(this._imgSource, this._imgDestination);
                                if (flag5)
                                {
                                    num2 = 0;
                                    flag2 = string.IsNullOrEmpty(this._imgSource);
                                    goto IL_1E3;
                                }
                                goto IL_271;
                            IL_16F:
                                goto IL_172;
                            }
                        Block_24:
                            text = text + "- " + num2.ToString() + " images deleted! \n\r\n\r";
                        IL_26E:
                            if (!false)
                            {
                                goto IL_28F;
                            }
                        IL_A6:
                            obj = (result = text);
                            return result;
                        IL_271:
                            throw new Exception("Images not Compressed");
                        IL_286:
                            obj = "Hot folder path has not been set!";
                        IL_28F:
                            obj = "Backup Complete\n\r\n\r" + text;
                            goto IL_375;
                        IL_292:
                            obj = (result = "Drive Not Exists");
                            return result;
                        IL_2A5:
                            obj = (result = "Image Destination Path is Null");
                            return result;
                        IL_2B8:
                            obj = (result = "Specified Tables are not Cleaned");
                            return result;
                        IL_2CB:
                            obj = (result = "No tables specified!");
                            return result;
                        }
                        obj = (result = "DB Backup operation could not be executed");
                        return result;
                    }
                    text += "ERROR : There is not enough space in the disk.";
                    //goto IL_A6;
                }
                obj = (result = "Destination Path is not correct");
                return result;
            }
            catch (Exception ex)
            {
                obj = "There was some error in backup! Error: " + ex.Message;
            }
        IL_375:
            result = obj;
            return result;
        }

        private bool SaveEmailDetails(string exceptionMsg)
        {
            ConfigBusiness configBusiness;
            string value;
            bool arg_A7_0;
            int arg_9B_0;
            bool flag;
            do
            {
                configBusiness = new ConfigBusiness();
                Dictionary<long, string> dictionary = new Dictionary<long, string>();
                dictionary = configBusiness.GetConfigurations(dictionary, LoginUser.SubStoreId);
                value = (from x in dictionary
                         where x.Key == 77L
                         select x).FirstOrDefault<KeyValuePair<long, string>>().Value;
                bool expr_64 = (arg_9B_0 = ((arg_A7_0 = (value == null)) ? 1 : 0)) != 0;
                if (3 == 0)
                {
                    goto IL_9B;
                }
                if (false)
                {
                    return arg_A7_0;
                }
                flag = expr_64;
                if (false)
                {
                    goto IL_A5;
                }
            }
            while (4 == 0);
            bool arg_79_0 = flag;
        IL_79:
            if (!arg_79_0)
            {
                bool flag2 = configBusiness.SaveEmailDetails(value, string.Empty, string.Empty, exceptionMsg, "BACKUP FAILED", LoginUser.SubStoreId);
            }
            arg_9B_0 = 1;
        IL_9B:
            bool expr_9B = arg_A7_0 = (arg_9B_0 != 0);
            if (!expr_9B)
            {
                return arg_A7_0;
            }
            arg_79_0 = expr_9B;
            if (!expr_9B)
            {
                goto IL_79;
            }
            bool flag3 = expr_9B;
        IL_A5:
            arg_A7_0 = flag3;
            return arg_A7_0;
        }

        public static void CopyAllFile(DirectoryInfo source, DirectoryInfo target)
        {
            FileInfo[] files;
            int num;
            if (3 != 0)
            {
                files = source.GetFiles();
                num = 0;
                goto IL_74;
            }
            goto IL_51;
        IL_69:
            while (8 == 0)
            {
            }
            int arg_6F_0 = num;
            goto IL_6E;
        IL_51:
            FileInfo fileInfo;
            fileInfo.CopyTo(Path.Combine(target.FullName, fileInfo.Name));
            goto IL_69;
        IL_6E:
            int arg_6F_1 = 1;
        IL_6F:
            int expr_6F = arg_6F_0 += arg_6F_1;
            if (false)
            {
                goto IL_6E;
            }
            num = expr_6F;
        IL_74:
            int arg_7B_0 = arg_6F_0 = num;
            bool expr_4B;
            do
            {
                int expr_76 = arg_6F_1 = files.Length;
                if (5 == 0)
                {
                    goto IL_6F;
                }
                if (arg_7B_0 >= expr_76)
                {
                    return;
                }
                FileInfo expr_23 = files[num];
                if (!false)
                {
                    fileInfo = expr_23;
                }
                bool flag = File.Exists(target + "\\" + fileInfo.Name);
                expr_4B = ((arg_6F_0 = (arg_7B_0 = (flag ? 1 : 0))) != 0);
            }
            while (7 == 0);
            if (!expr_4B)
            {
                goto IL_51;
            }
            goto IL_69;
        }

        private static void DoBackupNowDaily(int subStoreId, string _imgSource)
        {
            try
            {
                string text = string.Empty;
                string arg_2B9_0 = string.Empty;
                while (true)
                {
                IL_16:
                    string arg_2BF_0 = string.Empty;
                    string expr_20 = string.Empty;
                    if (false)
                    {
                    }
                    string arg_2CB_0 = string.Empty;
                    string arg_2D2_0 = string.Empty;
                    string arg_2D9_0 = string.Empty;
                    string arg_2E0_0 = string.Empty;
                    while (true)
                    {
                        iMIXConfigurationInfo iMIXConfigurationInfo = (from o in new ConfigBusiness().GetNewConfigValues(subStoreId)
                                                                       where o.IMIXConfigurationMasterId == 95L
                                                                       select o).FirstOrDefault<iMIXConfigurationInfo>();
                        bool flag = iMIXConfigurationInfo == null || string.IsNullOrEmpty(iMIXConfigurationInfo.ConfigurationValue);
                        while (true)
                        {
                            if (flag)
                            {
                                goto IL_2AA;
                            }
                            text = iMIXConfigurationInfo.ConfigurationValue.ToString();
                            bool arg_D8_0;
                            if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text))
                            {
                                arg_D8_0 = Directory.Exists(text);
                                goto IL_D7;
                            }
                            goto IL_2A9;
                        IL_2A2:
                            if (4 != 0)
                            {
                                goto IL_2A9;
                            }
                            continue;
                        IL_D7:
                            flag = !arg_D8_0;
                            if (flag)
                            {
                                goto IL_2A2;
                            }
                            flag = string.IsNullOrEmpty(_imgSource);
                            if (flag)
                            {
                                goto IL_2A1;
                            }
                        IL_F3:
                            flag = !Directory.Exists(_imgSource);
                            if (3 != 0)
                            {
                                if (!flag)
                                {
                                    string path = Path.Combine(text, "Site" + subStoreId.ToString());
                                    string path2 = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd"));
                                    string path3 = Path.Combine(path, "Thumbnails", DateTime.Now.ToString("yyyyMMdd"));
                                    string path4 = Path.Combine(path, "Thumbnails_Big", DateTime.Now.ToString("yyyyMMdd"));
                                    string path5 = Path.Combine(_imgSource, DateTime.Now.ToString("yyyyMMdd"));
                                    string path6 = Path.Combine(_imgSource, "Thumbnails", DateTime.Now.ToString("yyyyMMdd"));
                                    string path7 = Path.Combine(_imgSource, "Thumbnails_Big", DateTime.Now.ToString("yyyyMMdd"));
                                    if (!Directory.Exists(path5))
                                    {
                                        goto IL_21F;
                                    }
                                    bool arg_233_0;
                                    bool expr_1EE = arg_D8_0 = (arg_233_0 = Directory.Exists(path2));
                                    if (!false)
                                    {
                                        flag = expr_1EE;
                                        if (!flag)
                                        {
                                            Directory.CreateDirectory(path2);
                                        }
                                        Configuration.CopyAllFile(new DirectoryInfo(path5), new DirectoryInfo(path2));
                                        if (4 != 0)
                                        {
                                            goto IL_21F;
                                        }
                                        goto IL_2A2;
                                    }
                                IL_22C:
                                    if (true)
                                    {
                                        if (arg_233_0)
                                        {
                                            if (!Directory.Exists(path3))
                                            {
                                                Directory.CreateDirectory(path3);
                                            }
                                            Configuration.CopyAllFile(new DirectoryInfo(path6), new DirectoryInfo(path3));
                                        }
                                        flag = !Directory.Exists(path7);
                                        if (!flag)
                                        {
                                            flag = Directory.Exists(path4);
                                            if (!flag)
                                            {
                                                Directory.CreateDirectory(path4);
                                            }
                                            Configuration.CopyAllFile(new DirectoryInfo(path7), new DirectoryInfo(path4));
                                        }
                                        goto IL_2A0;
                                    }
                                    goto IL_D7;
                                IL_21F:
                                    if (6 != 0)
                                    {
                                        arg_233_0 = (arg_D8_0 = Directory.Exists(path6));
                                        goto IL_22C;
                                    }
                                    break;
                                }
                            IL_2A0:
                                goto IL_2A1;
                            }
                            goto IL_16;
                        IL_2AA:
                            if (7 != 0)
                            {
                                goto Block_19;
                            }
                            goto IL_F3;
                        IL_2A1:
                            goto IL_2A2;
                        IL_2A9:
                            goto IL_2AA;
                        }
                    }
                }
            Block_19:;
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

        private void FillAllCombo()
        {
            this.lstlogoList = new Dictionary<string, string>();
            this.lstBackgroundList = new Dictionary<string, string>();
            this.lstFilterList = new Dictionary<string, string>();
            this.lstCurrencyList = new Dictionary<string, string>();
            this.lstBGList = new Dictionary<string, string>();
            this.lstCurrencyList.Add("--Select--", "0");
            this.lstlogoList.Add("--Select--", "0");
            this.lstBackgroundList.Add("--Select--", "0");
            this.lstBGList.Add("--Select--", "0");
            this.BindBorders();
        }

        private void FillProductCombo()
        {
            if (!false)
            {
                if (4 != 0)
                {
                    try
                    {
                        List<ProductTypeInfo> productType = new ProductBusiness().GetProductType();
                        productType.Where(delegate (ProductTypeInfo t)
                        {
                            bool? dG_IsPrimary = t.DG_IsPrimary;
                            int arg_42_0;
                            if (!dG_IsPrimary.GetValueOrDefault())
                            {
                                arg_42_0 = 0;
                                goto IL_16;
                            }
                            arg_42_0 = (dG_IsPrimary.HasValue ? 1 : 0);
                        IL_10:
                            if (!false)
                            {
                            }
                        IL_16:
                            bool expr_45;
                            do
                            {
                                bool flag = arg_42_0 != 0;
                                if (!false)
                                {
                                }
                                expr_45 = ((arg_42_0 = (flag ? 1 : 0)) != 0);
                            }
                            while (8 == 0);
                            if (!false)
                            {
                                return expr_45;
                            }
                            goto IL_10;
                        }).ToList<ProductTypeInfo>();
                        CommonUtility.BindComboWithSelect<ProductTypeInfo>(this.CmbProductType, productType, "DG_Orders_ProductType_Name", "DG_Orders_ProductType_pkey", 0, ClientConstant.SelectString);
                        while (4 == 0)
                        {
                        }
                        this.CmbProductType.SelectedValue = "1";
                    }
                    catch (Exception serviceException)
                    {
                        if (6 != 0 && 6 != 0)
                        {
                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                    }
                }
            }
        }

        private void FillLocationCombo()
        {
            if (8 != 0)
            {
                try
                {
                    List<LocationInfo> locationSubstoreWise = new StoreSubStoreDataBusniess().GetLocationSubstoreWise(LoginUser.SubStoreId);
                    int arg_8E_0;
                    if (locationSubstoreWise != null)
                    {
                        arg_8E_0 = ((locationSubstoreWise.Count <= 0) ? 1 : 0);
                    }
                    else
                    {
                        arg_8E_0 = 1;
                    }
                IL_24:
                    bool flag = arg_8E_0 != 0;
                    bool expr_91 = (arg_8E_0 = (flag ? 1 : 0)) != 0;
                    if (8 == 0)
                    {
                        goto IL_24;
                    }
                    if (!expr_91)
                    {
                        CommonUtility.BindCombo<LocationInfo>(this.cmb_Location, locationSubstoreWise, "DG_Location_Name", "DG_Location_pkey");
                        this.cmb_Location.SelectedIndex = 0;
                    }
                }
                catch (Exception serviceException)
                {
                    while (true)
                    {
                        if (false)
                        {
                            goto IL_AE;
                        }
                        if (!false)
                        {
                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                    IL_A9:
                        if (-1 == 0)
                        {
                            continue;
                        }
                    IL_AE:
                        if (!false)
                        {
                            break;
                        }
                        goto IL_A9;
                    }
                }
            }
        }

        private void FillProductList()
        {
            do
            {
                try
                {
                    string expr_06 = "95,96,97";
                    string text;
                    if (!false)
                    {
                        text = expr_06;
                    }
                    string[] productToRemoveArray = text.Split(new char[]
                    {
                        ','
                    });
                    List<ProductTypeInfo> list = new ProductBusiness().GetProductType().Where(delegate (ProductTypeInfo x)
                    {
                        bool arg_2A_0;
                        bool flag;
                        while (4 != 0)
                        {
                            IEnumerable<string> arg_42_0 = productToRemoveArray;
                            int expr_31 = x.DG_Orders_ProductType_pkey;
                            int num;
                            if (!false)
                            {
                                num = expr_31;
                            }
                            bool arg_49_0;
                            bool expr_42 = arg_2A_0 = (arg_49_0 = arg_42_0.Contains(num.ToString()));
                            if (!false)
                            {
                                arg_49_0 = (arg_2A_0 = !expr_42);
                            }
                            if (6 == 0)
                            {
                                return arg_2A_0;
                            }
                            flag = arg_49_0;
                            if (!false)
                            {
                                break;
                            }
                        }
                        arg_2A_0 = flag;
                        return arg_2A_0;
                    }).ToList<ProductTypeInfo>();
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

        private void GetBackgrounds()
        {
            while (true)
            {
                BackgroundBusiness expr_C3 = new BackgroundBusiness();
                BackgroundBusiness backgroundBusiness;
                if (8 != 0)
                {
                    backgroundBusiness = expr_C3;
                }
                this.BackgroundList = new ObservableCollection<BackGroundInfo>();
                List<BackGroundInfo> backgoundDetails = backgroundBusiness.GetBackgoundDetails();
                bool arg_4F_0;
                if (backgoundDetails == null)
                {
                    arg_4F_0 = true;
                    goto IL_4E;
                }
                if (-1 != 0)
                {
                    int arg_49_0;
                    int expr_3A = arg_49_0 = backgoundDetails.Count;
                    int arg_49_1;
                    int expr_40 = arg_49_1 = 0;
                    if (expr_40 == 0)
                    {
                        arg_4F_0 = ((arg_49_0 = ((expr_3A > expr_40) ? 1 : 0)) != 0);
                        if (4 == 0)
                        {
                            goto IL_4F;
                        }
                        arg_49_1 = 0;
                    }
                    arg_4F_0 = (arg_49_0 == arg_49_1);
                    goto IL_4E;
                }
            IL_BC:
                if (true)
                {
                    break;
                }
                continue;
            IL_4F:
                if (!arg_4F_0)
                {
                    this.BackgroundList = new ObservableCollection<BackGroundInfo>(backgoundDetails);
                    IEnumerator<BackGroundInfo> enumerator = this.BackgroundList.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            while (enumerator.MoveNext())
                            {
                                if (8 != 0)
                                {
                                    BackGroundInfo current = enumerator.Current;
                                    current.DG_BackgroundPath = LoginUser.DigiFolderBackGroundPath + "\\Thumbnails\\" + current.DG_BackGround_Image_Name;
                                }
                            }
                            break;
                        }
                    }
                    finally
                    {
                        bool flag = enumerator == null;
                        if (!false)
                        {
                            if (!flag)
                            {
                                enumerator.Dispose();
                            }
                        }
                    }
                }
                goto IL_BC;
            IL_4E:
                goto IL_4F;
            }
        }

        private void GetGraphicsDetails()
        {
            List<AllGraphics> list = new List<AllGraphics>();
            List<GraphicsInfo> graphicsDetails = new GraphicsBusiness().GetGraphicsDetails();
            //goto IL_1A;
            try
            {
                do
                {
                IL_1A:
                    List<GraphicsInfo>.Enumerator enumerator = graphicsDetails.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            bool arg_AB_0 = enumerator.MoveNext();
                            bool expr_B0;
                            while (true)
                            {
                                bool flag = arg_AB_0;
                                if (false)
                                {
                                    goto IL_6E;
                                }
                                expr_B0 = (arg_AB_0 = flag);
                                if (6 != 0)
                                {
                                    goto Block_6;
                                }
                            }
                        IL_A0:
                            if (!false)
                            {
                                continue;
                            }
                            goto IL_8A;
                        Block_6:
                            if (!expr_B0)
                            {
                                break;
                            }
                            GraphicsInfo current = enumerator.Current;
                            AllGraphics allGraphics = new AllGraphics();
                            allGraphics.GraphicsName1 = current.DG_Graphics_Name;
                            allGraphics.GraphicsDisplayName1 = current.DG_Graphics_Displayname;
                            if (-1 != 0)
                            {
                                allGraphics.IsActive1 = current.DG_Graphics_IsActive.Value;
                                goto IL_6E;
                            }
                            goto IL_A0;
                        IL_8A:
                            allGraphics.Pkey1 = current.DG_Graphics_pkey;
                            list.Add(allGraphics);
                            goto IL_A0;
                        IL_6E:
                            allGraphics.Filepath1 = LoginUser.DigiFolderGraphicsPath + "\\" + current.DG_Graphics_Name;
                            goto IL_8A;
                        }
                    }
                    finally
                    {
                        if (!false)
                        {
                            ((IDisposable)enumerator).Dispose();
                        }
                    }
                    this.DGManageGraphics.ItemsSource = list;
                }
                while (false);
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void GetPermissions()
        {
            List<PermissionRoleInfo> permissionData;
            while (true)
            {
                RolePermissionsBusniess rolePermissionsBusniess = new RolePermissionsBusniess();
                if (3 == 0)
                {
                    goto IL_5E;
                }
                PermissionRoleInfo permissionRoleInfo;
                if (!false)
                {
                    permissionData = rolePermissionsBusniess.GetPermissionData(LoginUser.RoleId);
                    permissionRoleInfo = (from t in permissionData
                                          where t.DG_Permission_Id == 26
                                          select t).FirstOrDefault<PermissionRoleInfo>();
                }
                if (permissionRoleInfo != null)
                {
                    goto IL_5E;
                }
                this.chkEnableGrouping.Visibility = Visibility.Collapsed;
                this.tbenablegroup.Visibility = Visibility.Collapsed;
                if (8 == 0)
                {
                    goto IL_2DC;
                }
            IL_9E:
                if (true)
                {
                    break;
                }
                continue;
            IL_5E:
                this.chkEnableGrouping.Visibility = Visibility.Visible;
                this.tbenablegroup.Visibility = Visibility.Visible;
                goto IL_9E;
            }
            using (List<PermissionRoleInfo>.Enumerator enumerator = permissionData.GetEnumerator())
            {
                while (true)
                {
                    bool flag = enumerator.MoveNext();
                    if (5 == 0)
                    {
                        goto IL_18F;
                    }
                    if (!flag)
                    {
                        break;
                    }
                    PermissionRoleInfo current = enumerator.Current;
                    switch (current.DG_Permission_Id)
                    {
                        case 2:
                            this.TabSpecPrinting.Visibility = Visibility.Visible;
                            if (4 == 0)
                            {
                                goto IL_28A;
                            }
                            break;
                        case 5:
                            goto IL_18F;
                        case 7:
                            this.TabManageBorder.Visibility = Visibility.Visible;
                            break;
                        case 8:
                            this.TabManageBackground.Visibility = Visibility.Visible;
                            break;
                        case 9:
                            this.TabManageCurrency.Visibility = Visibility.Visible;
                            break;
                        case 13:
                            this.TabManageGraphics.Visibility = Visibility.Visible;
                            break;
                        case 14:
                            this.TabManageDiscount.Visibility = Visibility.Visible;
                            break;
                        case 23:
                            this.TabBackup.Visibility = Visibility.Visible;
                            break;
                        case 25:
                            this.Tabdigimagic.Visibility = Visibility.Visible;
                            break;
                        case 26:
                            this.TabManageAudio.Visibility = Visibility.Visible;


                            break;
                        case 27:
                            this.TabManageVideo.Visibility = Visibility.Visible;
                            break;
                        case 28:
                            this.TabManageVideoBG.Visibility = Visibility.Visible;


                            break;
                        case 29:
                            if (!false)
                            {
                                this.TabOnlineConfig.Visibility = Visibility.Visible;
                            }
                            break;
                        case 36:
                            this.TabManageScene.Visibility = Visibility.Visible;
                            break;
                        case 37:
                            this.TabSSConfiguration.Visibility = Visibility.Visible;
                            break;
                        case 38:
                            goto IL_28A;
                        case 40:
                            this.TabCharacterConfiguration.Visibility = Visibility.Visible;
                            break;
                    }
                    continue;
                IL_28A:
                    if (!false)
                    {
                        this.TabVenueConfiguration.Visibility = Visibility.Visible;
                    }
                    continue;
                IL_18F:
                    this.TabConfiguration.Visibility = Visibility.Visible;
                }
            }
            int i = 0;
        IL_2DC:
            while (i < 10)
            {
                if (((TabItem)this.tbmain.Items[i]).Visibility == Visibility.Visible)
                {
                    ((TabItem)this.tbmain.Items[i]).IsSelected = true;
                    break;
                }
                i++;
            }
        }

        private void btnDefault_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnSelectGraphics_Click(object sender, RoutedEventArgs e)
        {
            bool flag;
            Microsoft.Win32.OpenFileDialog openFileDialog;
            if (!false)
            {
                bool arg_EC_0 = this.EditableGraphics == null;
                bool expr_60;
                do
                {
                    flag = arg_EC_0;
                    if (!flag)
                    {
                        goto IL_1D;
                    }
                    if (!false)
                    {
                        openFileDialog = new Microsoft.Win32.OpenFileDialog();
                        openFileDialog.Multiselect = false;
                    }
                    openFileDialog.Filter = "Select Image|*.gif;*.png;|GIF|*.gif;*.GIF|PNG|*.png;*.PNG";
                    expr_60 = (arg_EC_0 = !openFileDialog.ShowDialog().Value);
                }
                while (false);
                flag = expr_60;
                goto IL_66;
            }
        IL_1D:
            if (8 != 0)
            {
                return;
            }
        IL_66:
            if (!flag)
            {
                try
                {
                    bool arg_7E_0;
                    if (7 != 0)
                    {
                        bool expr_77 = arg_7E_0 = (openFileDialog.OpenFile() == null);
                        if (5 == 0)
                        {
                            goto IL_7E;
                        }
                        flag = expr_77;
                    }
                    arg_7E_0 = flag;
                IL_7E:
                    if (!arg_7E_0)
                    {
                        this.txtSelectedgraphics.Text = openFileDialog.FileName.ToString();
                        this.graphicsname = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                        this.graphicsdisplayname = Path.GetFileName(openFileDialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnSaveSelectGraphics_Click(object sender, RoutedEventArgs e)
        {
            if (this.CheckGraphicsValidations())
            {
                try
                {
                    int arg_2D7_0;
                    bool expr_2A = (arg_2D7_0 = ((this.EditableGraphics == null) ? 1 : 0)) != 0;
                    string text;
                    string uniqueSynccode;
                    GraphicsBusiness graphicsBusiness;
                    bool isactive;
                    if (!false)
                    {
                        bool flag = expr_2A;
                        bool? isChecked;
                        if (!false)
                        {
                            Guid guid;
                            if (!flag)
                            {
                                guid = Guid.NewGuid();
                                text = string.Empty;
                                if (!string.IsNullOrEmpty(this.graphicsname) || !string.IsNullOrEmpty(this.graphicsdisplayname))
                                {
                                    this.graphicsname = this.graphicsname + guid.ToString() + ".png";
                                    text = LoginUser.DigiFolderGraphicsPath + "\\" + this.graphicsname;
                                    if (this.graphicsdisplayname != this.EditableGraphics.GraphicsDisplayName1)
                                    {
                                        File.Copy(this.txtSelectedgraphics.Text, text, true);
                                    }
                                    goto IL_112;
                                }
                            IL_7A:
                                this.graphicsname = this.EditableGraphics.GraphicsName1;
                                this.graphicsdisplayname = this.EditableGraphics.GraphicsDisplayName1;
                                if (false)
                                {
                                    goto IL_21C;
                                }
                            IL_112:
                                uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Graphic).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                                graphicsBusiness = new GraphicsBusiness();
                                isChecked = this.IsGraphicsActive.IsChecked;
                                bool arg_177_0;
                                if (!isChecked.HasValue)
                                {
                                    arg_177_0 = false;
                                }
                                else
                                {
                                    isChecked = this.IsGraphicsActive.IsChecked;
                                    arg_177_0 = isChecked.Value;
                                }
                                isactive = arg_177_0;
                                graphicsBusiness.UpdateGraphicsDetails(this.graphicsname, this.graphicsdisplayname, isactive, uniqueSynccode, this.EditableGraphics.Pkey1, LoginUser.UserId);
                                if (!string.IsNullOrEmpty(text))
                                {
                                    this.CopyToAllSubstore(this.lstConfigurationInfo, text, "", "Graphics");
                                    if (2 == 0)
                                    {
                                        goto IL_7A;
                                    }
                                }
                                this.txtSelectedgraphics.Text = "";
                                goto IL_1DB;
                            }
                        IL_21C:
                            guid = Guid.NewGuid();
                            this.graphicsname = this.graphicsname + guid.ToString() + ".png";
                            text = LoginUser.DigiFolderGraphicsPath + "\\" + this.graphicsname;
                            File.Copy(this.txtSelectedgraphics.Text, text, true);
                            if (false)
                            {
                                goto IL_20A;
                            }
                            uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Graphic).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                            graphicsBusiness = new GraphicsBusiness();
                            isChecked = this.IsGraphicsActive.IsChecked;
                            if (!isChecked.HasValue)
                            {
                                arg_2D7_0 = 0;
                                goto IL_2D6;
                            }
                            isChecked = this.IsGraphicsActive.IsChecked;
                        }
                        arg_2D7_0 = (isChecked.Value ? 1 : 0);
                    IL_2D6:
                        goto IL_2D7;
                    }
                    goto IL_2D7;
                IL_1DB:
                    this.graphicsname = string.Empty;
                    this.graphicsdisplayname = string.Empty;
                    AuditLog.AddUserLog(LoginUser.UserId, 48, "Add/Edit Graphics at ");
                    this.GetGraphicsDetails();
                IL_20A:
                    System.Windows.MessageBox.Show("Graphic saved Successfully");
                    goto IL_348;
                IL_2D7:
                    isactive = (arg_2D7_0 != 0);
                    graphicsBusiness.SetGraphicsDetails(this.graphicsname, this.graphicsdisplayname, isactive, uniqueSynccode, LoginUser.UserId);
                    this.CopyToAllSubstore(this.lstConfigurationInfo, text, "", "Graphics");
                    this.txtSelectedgraphics.Text = "";
                    AuditLog.AddUserLog(LoginUser.UserId, 48, "Add/Edit Graphics at ");
                    if (false)
                    {
                        goto IL_1DB;
                    }
                    this.GetGraphicsDetails();
                    System.Windows.MessageBox.Show("Graphic saved Successfully");
                IL_348:;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    if (!false)
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
            }
        IL_38E:
            this.graphicsname = (this.graphicsdisplayname = string.Empty);
            if (!false)
            {
                return;
            }
            goto IL_38E;
        }

        private void btnDeletegraphics_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AllGraphics allGraphics = null;
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                if (button != null && button.DataContext != null)
                {
                    try
                    {
                        AllGraphics allGraphics2 = (AllGraphics)button.DataContext;
                        allGraphics = (AllGraphics)allGraphics2.Clone();
                    }
                    catch (Exception ex)
                    {
                        allGraphics = null;
                    }
                    if (allGraphics != null)
                    {
                        string empty = string.Empty;
                        bool flag = this.FindDependencyOfGraphic(allGraphics.Pkey1, allGraphics.GraphicsName1, allGraphics.GraphicsDisplayName1, "delete", out empty);
                        if (flag)
                        {
                            //this.MsgBox.ShowHandlerDialog(empty, DigiMessageBox.DialogType.OK);
                            return;
                        }
                    }
                    bool flag2 = System.Windows.MessageBox.Show("Do you want to delete this graphic?", "Confirm delete", MessageBoxButton.YesNo) != MessageBoxResult.Yes;
                    if (!false)
                    {
                        if (flag2)
                        {
                            goto IL_17E;
                        }
                        GraphicsBusiness graphicsBusiness = new GraphicsBusiness();
                        bool flag3 = graphicsBusiness.DeleteGraphics(allGraphics.Pkey1);
                        if (!flag3)
                        {
                            goto IL_17D;
                        }
                        if (!File.Exists(LoginUser.DigiFolderGraphicsPath + "\\" + allGraphics.GraphicsName1))
                        {
                            goto IL_158;
                        }
                        File.Delete(LoginUser.DigiFolderGraphicsPath + "\\" + allGraphics.GraphicsName1);
                    }
                    this.DeleteFromAllSubstore(this.lstConfigurationInfo, allGraphics.GraphicsName1, "Graphics");
                IL_158:
                    System.Windows.MessageBox.Show("Graphic deleted successfully");
                    AuditLog.AddUserLog(LoginUser.UserId, 57, "Graphics deleted at ");
                    this.GetGraphicsDetails();
                IL_17D:
                IL_17E:;
                }
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    System.Windows.MessageBox.Show("Graphic deleted successfully");
                    this.GetGraphicsDetails();
                }
                else
                {
                    System.Windows.MessageBox.Show("Can not delete graphic because " + ex.Message);
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
            if (!false)
            {
            }
        }

        private void btnSaveDiscount_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                while (true)
                {
                    bool flag = !this.CheckValidationDiscount();
                    if (5 != 0)
                    {
                        if (flag)
                        {
                            break;
                        }
                        if (false)
                        {
                            goto IL_11B;
                        }
                        string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Discount).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                        new PhotoSW.IMIX.Business.DiscountBusiness().SetDiscountDetails(this.txtdiscountname.Text, this.txtdiscountdescription.Text, this.IsDiscountActive.IsChecked.Value, this.IsDiscountSecure.IsChecked.Value, this.IsDiscountItemLevel.IsChecked.Value, this.IsDiscountasPercentage.IsChecked.Value, this.txtDiscountCode.Text, uniqueSynccode);
                        if (7 != 0)
                        {
                            System.Windows.MessageBox.Show("Discount save Successfully");
                            goto IL_E7;
                        }
                    IL_10F:
                        if (7 != 0)
                        {
                            this.ClearControlDiscount();
                            goto IL_11B;
                        }
                        continue;
                    IL_E7:
                        //AuditLog.AddUserLog(LoginUser.UserId, 101, "Changed discount at ");
                        this.DGManageDiscount.ItemsSource = new DiscountBusiness().GetDiscountDetails();
                        goto IL_10F;
                    IL_11B:
                        if (!false)
                        {
                            break;
                        }
                        goto IL_E7;
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message;
                if (!false)
                {
                    message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                }
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool CheckValidationDiscount()
        {
            bool arg_1B_0 = this.txtdiscountname.Text == "";
            int expr_B2;
            while (true)
            {
            IL_1A:
                bool flag = !arg_1B_0;
                while (flag)
                {
                    while (true)
                    {
                        int arg_60_0 = (this.txtdiscountdescription.Text == "") ? 1 : 0;
                        while (true)
                        {
                            bool expr_60 = arg_1B_0 = (arg_60_0 == 0);
                            if (false)
                            {
                                goto IL_1A;
                            }
                            if (!expr_60)
                            {
                                goto Block_4;
                            }
                            flag = !(this.txtDiscountCode.Text == "");
                            if (!flag)
                            {
                                break;
                            }
                            expr_B2 = (arg_60_0 = 1);
                            if (expr_B2 != 0)
                            {
                                goto Block_9;
                            }
                        }
                        if (5 == 0)
                        {
                            break;
                        }
                        if (!false)
                        {
                            goto Block_8;
                        }
                    }
                }
                break;
            }
            System.Windows.MessageBox.Show("Please enter the discount name");
            int arg_B9_0;
            int expr_36 = arg_B9_0 = 0;
            bool flag2;
            if (expr_36 == 0)
            {
                flag2 = (expr_36 != 0);
                goto IL_B8;
            }
            return arg_B9_0 != 0;
        Block_4:
            if (6 != 0)
            {
                System.Windows.MessageBox.Show("Please enter the discount description");
                flag2 = false;
            }
            goto IL_B8;
        Block_8:
            System.Windows.MessageBox.Show("Please enter the discount code");
            flag2 = false;
            goto IL_B8;
        Block_9:
            flag2 = (expr_B2 != 0);
        IL_B8:
            arg_B9_0 = (flag2 ? 1 : 0);
            return arg_B9_0 != 0;
        }

        private void btnDeleteDiscount_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                if (!false)
                {
                    try
                    {
                        int arg_8C_0;
                        int arg_8C_1;
                        if (!false)
                        {
                            int expr_1C = arg_8C_0 = ((System.Windows.MessageBox.Show("Do you want to delete this discount?", "Confirm delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes) ? 1 : 0);
                            int expr_1F = arg_8C_1 = 0;
                            if (expr_1F != 0)
                            {
                                goto IL_87;
                            }
                            if (expr_1C == expr_1F)
                            {
                                goto IL_AD;
                            }
                        }
                        if (5 != 0)
                        {
                        }
                        System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                        DiscountBusiness discountBusiness = new DiscountBusiness();
                        bool flag = discountBusiness.DeleteDiscount((int)button.Tag);
                        if (!flag)
                        {
                            goto IL_AC;
                        }
                        System.Windows.MessageBox.Show("Discount deleted successfully");
                        arg_8C_0 = LoginUser.UserId;
                        arg_8C_1 = 102;
                    IL_87:
                        //AuditLog.AddUserLog(arg_8C_0, arg_8C_1, "Deleted Discount at ");
                        if (!false)
                        {
                            this.DGManageDiscount.ItemsSource = new DiscountBusiness().GetDiscountDetails();
                        }
                    IL_AC:
                    IL_AD:;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.MessageBox.Show(ex.Message);
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
            }
            while (!true);
        }

        private void btnEditDiscount_Click(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_E3;
            }
        IL_07:
            this.IsDiscountActive.IsChecked = new bool?(false);
            this.IsDiscountSecure.IsChecked = new bool?(false);
            if (!false)
            {
            }
            this.IsDiscountItemLevel.IsChecked = new bool?(false);
            this.IsDiscountasPercentage.IsChecked = new bool?(false);
            System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
            string discountDetailsFromID = new DiscountBusiness().GetDiscountDetailsFromID((int)button.Tag);
            if (false)
            {
                goto IL_188;
            }
            string[] array = discountDetailsFromID.Split(new char[]
            {
                '#'
            });
            this.txtdiscountname.Text = array[0].ToString();
            this.txtdiscountdescription.Text = array[1].ToString();
            string a = array[2].ToString();
            bool flag = !(a == "True");
            bool arg_182_0;
            bool expr_D9 = arg_182_0 = flag;
            if (2 == 0)
            {
                goto IL_182;
            }
            if (expr_D9)
            {
                goto IL_F7;
            }
        IL_E3:
            this.IsDiscountActive.IsChecked = new bool?(true);
        IL_F7:
            string a2 = array[3].ToString();
            bool arg_180_0;
            bool expr_108 = arg_180_0 = (a2 == "True");
            if (!false)
            {
                if (!expr_108)
                {
                    goto IL_12D;
                }
            IL_119:
                this.IsDiscountSecure.IsChecked = new bool?(true);
            IL_12D:
                string a3 = array[4].ToString();
                if (false)
                {
                    goto IL_07;
                }
                if (a3 == "True")
                {
                    this.IsDiscountItemLevel.IsChecked = new bool?(true);
                    if (false)
                    {
                        goto IL_119;
                    }
                }
                string a4 = array[5].ToString();
                arg_180_0 = (a4 == "True");
            }
            arg_182_0 = !arg_180_0;
        IL_182:
            if (arg_182_0)
            {
                goto IL_19C;
            }
        IL_188:
            this.IsDiscountasPercentage.IsChecked = new bool?(true);
        IL_19C:
            this.txtDiscountCode.Text = array[6].ToString();
        }

        private void btnCanceldiscount_Click(object sender, RoutedEventArgs e)
        {
            this.ClearControlDiscount();
        }

        private void ClearControlDiscount()
        {
            this.txtdiscountdescription.Text = "";
            if (!false)
            {
                this.txtdiscountname.Text = "";
                while (3 != 0)
                {
                    this.txtDiscountCode.Text = "";
                    if (!false)
                    {
                        if (!false)
                        {
                            ToggleButton expr_54 = this.IsDiscountActive;
                            bool? expr_D5 = new bool?(true);
                            if (!false)
                            {
                                expr_54.IsChecked = expr_D5;
                            }
                        }
                        do
                        {
                            this.IsDiscountSecure.IsChecked = new bool?(false);
                        }
                        while (false);
                        this.IsDiscountItemLevel.IsChecked = new bool?(false);
                        goto IL_8C;
                    }
                }
                return;
            }
        IL_8C:
            this.IsDiscountasPercentage.IsChecked = new bool?(false);
        }

        private void btnCancelSelectgraphics_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                while (true)
                {
                    this.txtSelectedgraphics.Text = "";
                    while (true)
                    {
                        ToggleButton expr_12 = this.IsGraphicsActive;
                        bool? expr_40 = new bool?(true);
                        if (7 != 0)
                        {
                            expr_12.IsChecked = expr_40;
                        }
                        if (3 == 0)
                        {
                            break;
                        }
                        if (!true)
                        {
                            break;
                        }
                        if (!false)
                        {
                            goto Block_2;
                        }
                    }
                }
            Block_2:
                this.EditableGraphics = null;
            }
            while (7 == 0);
        }

        private void loadProductType(int selectedPType)
        {
            if (true)
            {
            }
            this.lstBGList = new Dictionary<string, string>();
            try
            {
                this.lstBGList.Add("--Select--", "0");
                BackgroundBusiness backgroundBusiness = new BackgroundBusiness();
                List<BackGroundInfo>.Enumerator enumerator = backgroundBusiness.GetBackgoundDetailsALL().GetEnumerator();
                try
                {
                    while (true)
                    {
                    IL_82:
                        bool flag = enumerator.MoveNext();
                        while (flag)
                        {
                            BackGroundInfo current = enumerator.Current;
                            if (!false)
                            {
                            }
                            if (3 != 0)
                            {
                                this.lstBGList.Add(current.DG_BackGround_Image_Name.ToString(), current.DG_Background_pkey.ToString());
                                goto IL_82;
                            }
                        }
                        break;
                    }
                }
                finally
                {
                    if (!false)
                    {
                        ((IDisposable)enumerator).Dispose();
                        if (5 != 0)
                        {
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            if (!false)
            {
            }
        }

        private void BindBorders()
        {
            this.lstBorderList = new PhotoSW.IMIX.Business.BorderBusiness().GetBorderDetails();
            this.lstBorderList = (from o in this.lstBorderList
                                  where o.DG_IsActive
                                  select o).ToList<BorderInfo>();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            new System.Windows.Controls.Button();
            System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
            string text = button.Content.ToString();
        IL_2E:
            while (text != null)
            {
                bool arg_43_0 = text == "ENTER";
                while (!arg_43_0)
                {
                    if (!false)
                    {
                        if (!(text == "SPACE"))
                        {
                            bool arg_EF_0;
                            bool expr_5B = arg_EF_0 = (text == "CLOSE");
                            if (!false)
                            {
                                if (!expr_5B)
                                {
                                    int arg_EC_0;
                                    bool expr_6E = (arg_EC_0 = ((text == "Back") ? 1 : 0)) != 0;
                                    if (!false)
                                    {
                                        if (!expr_6E)
                                        {
                                            goto IL_134;
                                        }
                                        System.Windows.Controls.TextBox textBox = this.controlon;
                                        arg_EC_0 = this.controlon.Text.Length;
                                    }
                                    arg_EF_0 = (arg_EC_0 > 0);
                                }
                                else
                                {
                                    this.KeyBorder.Visibility = Visibility.Collapsed;
                                    if (!false)
                                    {
                                        return;
                                    }
                                    return;
                                }
                            }
                            bool flag = !arg_EF_0;
                            bool expr_F2 = arg_43_0 = flag;
                            if (false)
                            {
                                continue;
                            }
                            if (!expr_F2)
                            {
                                if (!false)
                                {
                                    this.controlon.Text = this.controlon.Text.Remove(this.controlon.Text.Length - 1, 1);
                                }
                                else
                                {
                                IL_7E:
                                    this.KeyBorder.Visibility = Visibility.Collapsed;
                                }
                            }
                        }
                        else
                        {
                            this.controlon.Text = this.controlon.Text + " ";
                            if (!false)
                            {
                            }
                        }
                        return;
                    }
                    goto IL_2E;
                }
                //goto IL_7E;
            }
        IL_134:
            this.controlon.Text = this.controlon.Text + button.Content;
        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (false)
                {
                    goto IL_DA;
                }
                string text = string.Empty;
                string format = string.Empty;
                if (false)
                {
                    goto IL_195;
                }
                int arg_CE_0;
                int expr_1BD = arg_CE_0 = this.cmbReceiptPrinter.SelectedIndex;
                int arg_CE_1;
                int expr_44 = arg_CE_1 = 0;
                if (expr_44 != 0)
                {
                    goto IL_CE;
                }
                if (expr_1BD > expr_44)
                {
                    do
                    {
                        text = this.lstPrinterList.Where(delegate (KeyValuePair<string, string> t)
                        {
                            bool result;
                            do
                            {
                                if (true && !false)
                                {
                                    result = (t.Value == this.cmbReceiptPrinter.SelectedValue.ToString());
                                }
                                while (false)
                                {
                                }
                            }
                            while (8 == 0);
                            return result;
                        }).FirstOrDefault<KeyValuePair<string, string>>().Key;
                    }
                    while (false);
                }
                format = text;
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to save changes.?", "Confirmation", MessageBoxButton.YesNo);
                if (messageBoxResult != MessageBoxResult.Yes)
                {
                    goto IL_19F;
                }
                if (!this.CheckValidationsCurrency())
                {
                    goto IL_19E;
                }
            IL_C7:
                arg_CE_0 = (this.CheckValidation() ? 1 : 0);
                arg_CE_1 = 0;
            IL_CE:
                if (arg_CE_0 == arg_CE_1)
                {
                    goto IL_19D;
                }
            IL_DA:
                this.SaveConfigData();
                string currentDirectory = Environment.CurrentDirectory;
                int expr_F4 = arg_CE_0 = (File.Exists(currentDirectory + "\\slipPrinter.dat") ? 1 : 0);
                int expr_FA = arg_CE_1 = 0;
                if (expr_FA != 0)
                {
                    goto IL_CE;
                }
                if (expr_F4 != expr_FA)
                {
                    File.Delete(currentDirectory + "\\slipPrinter.dat");
                }
                using (StreamWriter streamWriter = new StreamWriter(File.Open(currentDirectory + "\\slipPrinter.dat", FileMode.Create)))
                {
                    streamWriter.Write(format, true);
                    streamWriter.Close();

                    LoginUser.ReceiptPrinterPath = this.lstPrinterList.Where(t => t.Value == this.cmbReceiptPrinter.SelectedValue.ToString()
                    ).FirstOrDefault<KeyValuePair<string, string>>().Key;
                    //LoginUser.ReceiptPrinterPath = this.lstPrinterList.Where(delegate(KeyValuePair<string, string> t)
                    //{
                    //    bool result;
                    //    do
                    //    {
                    //        if (true && !false)
                    //        {
                    //            result = (t.Value == this.cmbReceiptPrinter.SelectedValue.ToString());
                    //        }
                    //        while (false)
                    //        {
                    //        }
                    //    }
                    //    while (8 == 0);
                    //    return result;
                    //}).FirstOrDefault<KeyValuePair<string, string>>().Key;
                }
            IL_195:
                if (false)
                {
                    goto IL_C7;
                }
            IL_19D:
            IL_19E:
            IL_19F:
                if (4 == 0)
                {
                    goto IL_19E;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnhotfolder_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            //    System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
            //    string name = button.Name;
            //    if (name != null)
            //    {
            //        if (<PrivateImplementationDetails>{AB42A19C-C2FF-44B8-8D01-104839115809}.$$method0x6000517-1 == null)
            //        {
            //            <PrivateImplementationDetails>{AB42A19C-C2FF-44B8-8D01-104839115809}.$$method0x6000517-1 = new Dictionary<string, int>(8)
            //            {
            //                {
            //                    "btnhotfolder",
            //                    0
            //                },
            //                {
            //                    "btnFrmaes",
            //                    1
            //                },
            //                {
            //                    "btnBg",
            //                    2
            //                },
            //                {
            //                    "btnBrowseDBbackupPath",
            //                    3
            //                },
            //                {
            //                    "btnBrowseDfbackupPath",
            //                    4
            //                },
            //                {
            //                    "btnBrowseMktImgPath",
            //                    5
            //                },
            //                {
            //                    "btnBrowseEKSamplePath",
            //                    6
            //                },
            //                {
            //                    "btnServerhotfolder",
            //                    7
            //                }
            //            };
            //        }
            //        int num;
            //        if (<PrivateImplementationDetails>{AB42A19C-C2FF-44B8-8D01-104839115809}.$$method0x6000517-1.TryGetValue(name, out num))
            //        {
            //            DialogResult dialogResult;
            //            switch (num)
            //            {
            //            case 0:
            //                dialogResult = folderBrowserDialog.ShowDialog();
            //                if (dialogResult == System.Windows.Forms.DialogResult.OK)
            //                {
            //                    this.txtHotFolder.Text = folderBrowserDialog.SelectedPath.Replace("\\", "\\\\") + "\\\\";
            //                    goto IL_12B;
            //                }
            //                break;
            //            case 1:
            //            {
            //                dialogResult = folderBrowserDialog.ShowDialog();
            //                bool flag = dialogResult != System.Windows.Forms.DialogResult.OK;
            //                if (false)
            //                {
            //                    goto IL_1B9;
            //                }
            //                if (!flag)
            //                {
            //                    if (7 != 0)
            //                    {
            //                        this.txtBorderFolder.Text = folderBrowserDialog.SelectedPath + "\\";
            //                    }
            //                }
            //                break;
            //            }
            //            case 2:
            //                dialogResult = folderBrowserDialog.ShowDialog();
            //                if (false)
            //                {
            //                    goto IL_1C6;
            //                }
            //                if (dialogResult == System.Windows.Forms.DialogResult.OK)
            //                {
            //                    this.txtbgPath.Text = folderBrowserDialog.SelectedPath + "\\";
            //                }
            //                break;
            //            case 3:
            //                dialogResult = folderBrowserDialog.ShowDialog();
            //                goto IL_1B9;
            //            case 4:
            //                goto IL_1F0;
            //            case 5:
            //                if (7 == 0)
            //                {
            //                    goto IL_12B;
            //                }
            //                break;
            //            case 7:
            //                dialogResult = folderBrowserDialog.ShowDialog();
            //                if (dialogResult == System.Windows.Forms.DialogResult.OK)
            //                {
            //                    this.txtServerHotFolder.Text = folderBrowserDialog.SelectedPath.Replace("\\", "\\\\") + "\\\\";
            //                    goto IL_277;
            //                }
            //                break;
            //            }
            //            goto IL_280;
            //            IL_12B:
            //            if (false)
            //            {
            //                goto IL_1F0;
            //            }
            //            goto IL_280;
            //            IL_1B9:
            //            if (dialogResult != System.Windows.Forms.DialogResult.OK)
            //            {
            //                goto IL_1EA;
            //            }
            //            IL_1C6:
            //            this.txtDbBackupPath.Text = folderBrowserDialog.SelectedPath + "\\";
            //            if (!false)
            //            {
            //            }
            //            IL_1EA:
            //            goto IL_280;
            //            IL_1F0:
            //            if (8 != 0)
            //            {
            //                dialogResult = folderBrowserDialog.ShowDialog();
            //                if (dialogResult == System.Windows.Forms.DialogResult.OK)
            //                {
            //                    this.txtHfBackupPath.Text = folderBrowserDialog.SelectedPath + "\\";
            //                }
            //                goto IL_280;
            //            }
            //            IL_277:
            //            if (!true)
            //            {
            //                goto IL_1B9;
            //            }
            //        }
            //    }
            //    IL_280:;
            //}
            //catch (Exception serviceException)
            //{
            //    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
            //    ErrorHandler.ErrorHandler.LogFileWrite(message);
            //}
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.GetPermissions();
            this.GetAllSubstoreConfigdata();
        }

        private void LoadTabData()
        {
            try
            {
                this.FillSubstore();
                this.GetGraphicsDetails();
                CurrencyBusiness currencyBusiness;
                do
                {
                    this.FillAllCombo();
                    this.FillProductCombo();
                    this.FillOnlineTabInfo();
                    if (false)
                    {
                        goto IL_162;
                    }
                    this.FillPrinters();
                    List<BorderInfo> borderDetails = new BorderBusiness().GetBorderDetails();
                    if (borderDetails != null)
                    {
                        List<BorderInfo>.Enumerator enumerator = borderDetails.GetEnumerator();
                        try
                        {
                            while (true)
                            {
                            IL_AF:
                                bool arg_B6_0 = enumerator.MoveNext();
                                while (arg_B6_0)
                                {
                                    BorderInfo current = enumerator.Current;
                                    bool expr_78 = arg_B6_0 = string.IsNullOrEmpty(LoginUser.DigiFolderFramePath);
                                    if (7 != 0)
                                    {
                                        if (!expr_78 && !string.IsNullOrEmpty(current.DG_Border))
                                        {
                                            current.FilePath = Path.Combine(LoginUser.DigiFolderFramePath, current.DG_Border);
                                        }
                                        goto IL_AF;
                                    }
                                }
                                break;
                            }
                        }
                        finally
                        {
                            do
                            {
                                ((IDisposable)enumerator).Dispose();
                            }
                            while (false);
                        }
                        this.DGManageBorder.ItemsSource = borderDetails;
                    }
                    currencyBusiness = new CurrencyBusiness();
                    this.DGManageCurrency.ItemsSource = currencyBusiness.GetCurrencyDetails();
                    this.DGManageDiscount.ItemsSource = new DiscountBusiness().GetDiscountDetails();
                    this.txtDefaultCurrency.Text = new CurrencyBusiness().GetDefaultCurrencyName();
                    this.GetBackgrounds();
                }
                while (false);
                this.lstCurrencyList = new Dictionary<string, string>();
                this.lstBackgroundList = new Dictionary<string, string>();
                this.lstlogoList = new Dictionary<string, string>();
                this.lstBGList = new Dictionary<string, string>();
                RobotImageLoader.GetConfigData();
            IL_162:
                this.GetNewConfigData();
                this.fillRecursiveNewOptions();
                this.getTaxConfigData();
                this.GetAudioDetails();
                this.GetChromaKeyDetails();

                this.GetVideoTemplateDetails();
                this.GetVideoBGDetails();
                this.GetVideoOverlayDetails();


                //this.GetBorderDetailsScene();
                do
                {
                    //this.GetBackGroundDetailsScene();
                    this.FillSceneProductCombo();
                }
                while (false);
                this.DGManageScene.ItemsSource = new SceneBusiness().GetSceneDetails();
                this.BindCharacterGrid();
                this.FillLocationCombo();
                try
                {
                    List<CurrencyInfo> currencyListforconfig = currencyBusiness.GetCurrencyListforconfig();
                    CommonUtility.BindComboWithSelect<CurrencyInfo>(this.cmbCurrency, currencyListforconfig, "DG_Currency_Name", "DG_Currency_pkey", 0, ClientConstant.SelectString);
                    this.cmbCurrency.SelectedValue = "0";
                    int num = 0;
                    this.GetConfigData();
                    if (LoginUser.DigiFolderBackGroundPath != null)
                    {
                        FileInfo[] files = new DirectoryInfo(LoginUser.DigiFolderBackGroundPath).GetFiles();
                        int i = 0;
                        int expr_28F;
                        while (true)
                        {
                            int arg_251_0;
                            FileInfo fileInfo = null;
                            if (i >= files.Length)
                            {
                                expr_28F = (arg_251_0 = 0);
                                if (expr_28F == 0)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                fileInfo = files[i];
                                arg_251_0 = (fileInfo.Name.Contains("Thumb") ? 1 : 0);
                            }
                            if (arg_251_0 == 0)
                            {
                                this.lstBackgroundList.Add(fileInfo.Name, num.ToString());
                                num++;
                            }
                            i++;
                        }
                        num = expr_28F;
                        files = new DirectoryInfo(LoginUser.DigiFolderGraphicsPath).GetFiles();
                        for (i = 0; i < files.Length; i++)
                        {
                            FileInfo fileInfo = files[i];
                            if (!fileInfo.Name.Contains("Thumb"))
                            {
                                this.lstlogoList.Add(fileInfo.Name, num.ToString());
                            }
                            int arg_306_0;
                            int expr_2E9 = arg_306_0 = num + 1;
                            if (false)
                            {
                                break;
                            }
                            num = expr_2E9;
                        }
                    }
                    while (false)
                    {
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                this.lstBGList.Add("--Select--", "0");
                BackgroundBusiness backgroundBusiness = new BackgroundBusiness();
                foreach (BackGroundInfo current2 in backgroundBusiness.GetBackgoundDetailsALL())
                {
                    this.lstBGList.Add(current2.DG_BackGround_Image_Name.ToString(), current2.DG_Background_pkey.ToString());
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            finally
            {
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Login login;
            do
            {
                int arg_2F_0 = LoginUser.UserId;
                //do
                //{
                //	arg_2F_0 = (AuditLog.AddUserLog(arg_2F_0, 39, "Logged out at ") ? 1 : 0);
                //}
                //while (2 == 0 || false);
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

        private void txtNumber_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
        }

        private void btnSelectBorder_Click(object sender, RoutedEventArgs e)
        {
            bool flag;
            Microsoft.Win32.OpenFileDialog openFileDialog;
            while (4 != 0)
            {
                bool arg_E9_0;
                bool expr_09 = arg_E9_0 = this.iseditborder;
                if (!false)
                {
                    arg_E9_0 = !expr_09;
                }
                if (!false)
                {
                    flag = arg_E9_0;
                }
                if (!flag || 6 == 0)
                {
                    return;
                }
                if (-1 != 0)
                {
                    openFileDialog = new Microsoft.Win32.OpenFileDialog();
                    openFileDialog.Multiselect = false;
                    openFileDialog.Filter = "All Image Files | *.*";
                    break;
                }
            }
            flag = !openFileDialog.ShowDialog().Value;
            if (flag)
            {
                return;
            }
            while (true)
            {
                try
                {
                    flag = (openFileDialog.OpenFile() == null);
                    if (!flag)
                    {
                        this.txtSelectedborder.Text = Path.GetFileName(openFileDialog.FileName);
                        this.txtSelectedborder.Tag = openFileDialog.FileName;
                        this.filename = Path.GetFileName(openFileDialog.FileName);
                    }
                }
                catch (Exception ex)
                {
                    do
                    {
                        System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    }
                    while (8 == 0);
                }
                if (!false)
                {
                    return;
                }
            }
        }

        private void btnCancelSelectBorder_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                this.txtSelectedborder.Text = "";
                if (8 == 0)
                {
                    goto IL_33;
                }
                if (false)
                {
                    goto IL_3F;
                }
            IL_19:
                this.IsBorderActive.IsChecked = new bool?(true);
                if (!false)
                {
                    this.DGManageBorder.SelectedItem = null;
                }
            IL_33:
                if (false)
                {
                    goto IL_19;
                }
                this.iseditborder = false;
            IL_3F:
                this.borderId = 0;
                this.filename = string.Empty;
            }
        }

        private void btnSaveSelectBorder_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (false)
                {
                    goto IL_7F;
                }
                if (!this.CheckBorderValidations())
                {
                    goto IL_1B2;
                }
                if (!this.iseditborder)
                {
                    this.SaveBorderFile();
                    goto IL_80;
                }
                BorderInfo borderInfo = (BorderInfo)this.DGManageBorder.SelectedItem;
            IL_59:
                if (this.txtSelectedborder.Text != borderInfo.DG_Border)
                {
                    this.SaveBorderFile();
                }
            IL_7F:
            IL_80:
                string dG_Orders_ProductType_Name = ((ProductTypeInfo)this.CmbProductType.SelectedItem).DG_Orders_ProductType_Name;
                int productsynccodeName = new ProductBusiness().GetProductsynccodeName(dG_Orders_ProductType_Name);
                if (productsynccodeName != 0)
                {
                    string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Border).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                    new BorderBusiness().SetBorderDetails(this.filename, productsynccodeName, this.IsBorderActive.IsChecked.Value, this.borderId, uniqueSynccode, LoginUser.UserId);
                    System.Windows.MessageBox.Show("Record saved successfully");
                    // AuditLog.AddUserLog(LoginUser.UserId, 11, "Add/Edit Border at ");
                }
                this.DGManageBorder.ItemsSource = null;
                BorderBusiness borderBusiness = new BorderBusiness();
                List<BorderInfo> borderDetails = borderBusiness.GetBorderDetails();
                if (false)
                {
                    goto IL_59;
                }
                borderDetails.ForEach(delegate (BorderInfo x)
                {
                    x.FilePath = Path.Combine(LoginUser.DigiFolderFramePath, x.DG_Border);
                });
                this.DGManageBorder.ItemsSource = borderDetails;
                this.borderId = 0;
                this.txtBorderFolder.Text = "";
                this.iseditborder = false;
                this.btnCancelSelectBorder_Click(null, null);
            IL_1B2:;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void SaveBorderFile()
        {
            do
            {
                try
                {
                    do
                    {
                        string destFileName = LoginUser.DigiFolderFramePath + this.txtSelectedborder.Text;
                        if (3 != 0)
                        {
                            File.Copy(this.txtSelectedborder.Tag.ToString(), destFileName, true);
                        }
                        string text;
                        do
                        {
                            text = string.Empty;
                            FileStream fileStream = File.OpenRead(LoginUser.DigiFolderFramePath + this.txtSelectedborder.Text);
                            try
                            {
                                MemoryStream memoryStream;
                                do
                                {
                                    memoryStream = new MemoryStream();
                                    fileStream.CopyTo(memoryStream);
                                    memoryStream.Seek(0L, SeekOrigin.Begin);
                                    text = LoginUser.DigiFolderFramePath + "\\Thumbnails\\" + this.txtSelectedborder.Text;
                                    this.ResizeAndSaveHighQualityImage(System.Drawing.Image.FromStream(memoryStream), text, 100, 150);
                                    fileStream.Close();
                                }
                                while (false);
                                memoryStream.Dispose();
                            }
                            finally
                            {
                                if (!false && fileStream != null)
                                {
                                    ((IDisposable)fileStream).Dispose();
                                }
                            }
                        }
                        while (2 == 0);
                        this.CopyToAllSubstore(this.lstConfigurationInfo, this.txtSelectedborder.Tag.ToString(), text, "Frames");
                    }
                    while (false);
                }
                catch (Exception var_4_153)
                {
                }
            }
            while (false);
        }

        private void ResizeAndSaveHighQualityImage(System.Drawing.Image image, string pathToSave, int quality, int height)
        {
            MemoryStream memoryStream = null;
            FileStream fileStream = null;
            try
            {
                decimal d = image.Width.ToDecimal(false) / image.Height.ToDecimal(false);
                int width = Convert.ToInt32(height * d);
                using (Bitmap bitmap = new Bitmap(width, height))
                {
                    ImageCodecInfo encoder;
                    EncoderParameters encoderParameters;
                    while (true)
                    {
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.CompositingQuality = CompositingQuality.HighQuality;
                            do
                            {
                                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                                graphics.SmoothingMode = SmoothingMode.HighQuality;
                                graphics.DrawImage(image, 0, 0, bitmap.Width, bitmap.Height);
                            }
                            while (false);
                        }
                        int arg_B4_0 = quality;
                        bool arg_C5_0;
                        do
                        {
                            arg_C5_0 = (((arg_B4_0 < 0) ? (arg_B4_0 = 0) : (arg_B4_0 = ((quality <= 100) ? 1 : 0))) != 0);
                        }
                        while (false);
                        if (!arg_C5_0)
                        {
                            break;
                        }
                        EncoderParameter encoderParameter = new EncoderParameter(Encoder.Quality, (long)quality);
                        string lookupKey = "image/jpeg";
                        encoder = (from i in ImageCodecInfo.GetImageEncoders()
                                   where i.MimeType.Equals(lookupKey)
                                   select i).FirstOrDefault<ImageCodecInfo>();
                        encoderParameters = new EncoderParameters(1);
                        encoderParameters.Param[0] = encoderParameter;
                        memoryStream = new MemoryStream();
                        if (!false)
                        {
                            goto Block_8;
                        }
                    }
                    string paramName = string.Format("quality must be 0, 100", quality);
                    throw new ArgumentOutOfRangeException(paramName);
                Block_8:
                    fileStream = new FileStream(pathToSave, FileMode.Create, FileAccess.ReadWrite);
                    bitmap.Save(memoryStream, encoder, encoderParameters);
                    byte[] array = memoryStream.ToArray();
                    fileStream.Write(array, 0, array.Length);
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
                do
                {
                    if (8 == 0 || 4 != 0)
                    {
                    }
                }
                while (8 == 0);
            }
            finally
            {
                if (memoryStream != null)
                {
                    memoryStream.Close();
                    memoryStream.Dispose();
                }
                if (fileStream != null)
                {
                    do
                    {
                        fileStream.Close();
                    }
                    while (8 == 0);
                    fileStream.Dispose();
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            IL_02:
                while (sender != null)
                {
                    bool flag = true;
                    bool arg_2B_0 = this.iseditborder;
                    int arg_2B_1 = 0;
                    while ((arg_2B_0 ? 1 : 0) != arg_2B_1)
                    {
                        MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("It looks like you have been editing a border.If you leave before saving, your changes will be lost.Would you like to save your unsaved changes ?", "Alert", MessageBoxButton.YesNo);
                        int expr_51 = (arg_2B_0 = (messageBoxResult == MessageBoxResult.Yes)) ? 1 : 0;
                        int expr_54 = arg_2B_1 = 0;
                        if (expr_54 == 0)
                        {
                            if (expr_51 != expr_54)
                            {
                                flag = false;
                            }
                            break;
                        }
                    }
                    if (flag)
                    {
                        System.Windows.Controls.Button button = new System.Windows.Controls.Button();
                        button = (System.Windows.Controls.Button)sender;
                        if (button != null)
                        {
                            BorderInfo borderInfo = (BorderInfo)button.DataContext;
                            bool arg_9B_0 = borderInfo == null;
                        IL_9B:
                            while (!arg_9B_0)
                            {
                                string empty;
                                while (true)
                                {
                                    empty = string.Empty;
                                    bool flag2 = this.FindDependencyOfBorder(borderInfo, "edit", out empty);
                                    bool expr_BF = arg_9B_0 = !flag2;
                                    if (3 == 0)
                                    {
                                        goto IL_9B;
                                    }
                                    if (!expr_BF)
                                    {
                                        break;
                                    }
                                    this.borderId = button.Tag.ToInt32(false);
                                    this.iseditborder = true;
                                    this.IsBorderActive.IsChecked = new bool?(false);
                                    if (!false)
                                    {
                                        goto Block_11;
                                    }
                                }
                                if (!false)
                                {
                                    //this.MsgBox.ShowHandlerDialog(empty, DigiMessageBox.DialogType.OK);
                                    break;
                                }
                                goto IL_02;
                            Block_11:
                                string a;
                                if (true)
                                {
                                    System.Windows.Controls.Button button2 = (System.Windows.Controls.Button)sender;
                                    BorderInfo borderNameFromID = new BorderBusiness().GetBorderNameFromID((int)button2.Tag);
                                    string text = string.Concat(new object[]
                                    {
                                        borderNameFromID.DG_Border,
                                        "#",
                                        borderNameFromID.DG_IsActive,
                                        "#",
                                        borderNameFromID.DG_ProductTypeID
                                    });
                                    string[] array = text.Split(new char[]
                                    {
                                        '#'
                                    });
                                    string text2 = array[0];
                                    a = array[1];
                                    this.filename = text2;
                                    string selectedValue = array[2];
                                    this.txtSelectedborder.Text = text2;
                                    this.CmbProductType.SelectedValue = selectedValue;
                                }
                                if (a == "True")
                                {
                                    this.IsBorderActive.IsChecked = new bool?(true);
                                }
                                break;
                            }
                        }
                    }
                    break;
                }
            }
            catch (Exception var_13_244)
            {
                if (!false)
                {
                    this.iseditborder = false;
                }
            }
        IL_255:
            while (!true)
            {
            }
            return;
            goto IL_255;
        }

        private void btnSaveCurrency_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!this.CheckCurrencyValidations())
                {
                    System.Windows.MessageBox.Show("Please enter all required fields to continue");
                    goto IL_298;
                }
                string text = this.TBCurrencyName.Text;
                string text2 = this.TBCurrencySymbol.Text;
                float num = float.Parse(this.TBCurrencyRate.Text);
                bool flag = false;
                if (this.currencyid > 0)
                {
                    flag = true;
                }
            IL_6B:
                string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Currency).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
                CustomBusineses customBusineses = new CustomBusineses();
                if (!flag)
                {
                    new CurrencyBusiness().SetCurrencyDetails(text, num, text2, this.currencyid, 4, false, customBusineses.ServerDateTime(), "Test", this.TBCurrencyCode.Text, uniqueSynccode);
                    AuditLog.AddUserLog(LoginUser.UserId, 6, "Currency (" + text + ") has been created on ");
                    if (!false)
                    {
                        System.Windows.MessageBox.Show("[" + text + "] Currency details has been created successfully");
                        goto IL_247;
                    }
                    goto IL_27B;
                }
            IL_B2:
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Alert: Are you sure you want to update the currrency details?", "Temper Alert", MessageBoxButton.YesNo, MessageBoxImage.Exclamation);
            IL_C7:
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    string empty = string.Empty;
                    bool flag2 = this.IsRateUpdated(this.currencyid, num.ToDouble(false), out empty);
                    new CurrencyBusiness().SetCurrencyDetails(text, num, text2, this.currencyid, 4, false, customBusineses.ServerDateTime(), "Test", this.TBCurrencyCode.Text, uniqueSynccode);
                    if (false)
                    {
                        goto IL_254;
                    }
                    if (flag2)
                    {
                        AuditLog.AddUserLog(LoginUser.UserId, 9, string.Concat(new string[]
                        {
                            "Currency (",
                            text,
                            ") Rate has been changed from ",
                            empty.ToDouble(false).ToString(),
                            " to ",
                            num.ToDouble(false).ToString(),
                            " on "
                        }));
                    }
                    else
                    {
                        AuditLog.AddUserLog(LoginUser.UserId, 8, "Currency (" + text + ") has been updated on ");
                    }
                    System.Windows.MessageBox.Show("[" + text + "] Currency details has been updated successfully");
                }
            IL_247:
                this.DGManageCurrency.ItemsSource = null;
            IL_254:
                CurrencyBusiness currencyBusiness = new CurrencyBusiness();
                this.DGManageCurrency.ItemsSource = currencyBusiness.GetCurrencyDetails();
                if (5 == 0)
                {
                    goto IL_B2;
                }
                this.currencyid = 0;
            IL_27B:
                this.ClearControlCurrency();
                if (7 == 0)
                {
                    goto IL_C7;
                }
            IL_298:
                if (5 == 0)
                {
                    goto IL_6B;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool IsRateUpdated(int CurrencyID, double newprice, out string OldPrice)
        {
            if (8 != 0)
            {
            }
            string currencyDetailFromID = new CurrencyBusiness().GetCurrencyDetailFromID(CurrencyID);
            string text;
            bool arg_7A_0;
            while (true)
            {
            IL_15:
                string[] array = currencyDetailFromID.Split(new char[]
                {
                    '#'
                });
                text = array[1];
                bool expr_45 = arg_7A_0 = (text.ToDouble(false) == newprice);
                if (5 != 0)
                {
                    bool flag = !expr_45;
                    while (flag)
                    {
                        if (false)
                        {
                            goto IL_74;
                        }
                        if (!false)
                        {
                            OldPrice = text.ToString();
                            if (-1 != 0)
                            {
                                goto Block_5;
                            }
                            goto IL_15;
                        }
                    }
                    break;
                }
                return arg_7A_0;
            }
            OldPrice = text.ToString();
        IL_5C:
            bool flag2 = false;
            goto IL_79;
        Block_5:
            flag2 = true;
        IL_74:
            if (false)
            {
                goto IL_5C;
            }
        IL_79:
            arg_7A_0 = flag2;
            return arg_7A_0;
        }

        private void btnEditCurrency_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string currencyDetailFromID;
                if (!false)
                {
                    System.Windows.Controls.Button button;
                    do
                    {
                        button = (System.Windows.Controls.Button)sender;
                    }
                    while (-1 == 0);
                    this.currencyid = (int)button.Tag;
                    currencyDetailFromID = new CurrencyBusiness().GetCurrencyDetailFromID((int)button.Tag);
                }
                string[] array = currencyDetailFromID.Split(new char[]
                {
                    '#'
                });
                string text = array[0];
                string text2 = array[1];
                string text3 = array[2];
                this.TBCurrencyName.Text = text;
                this.TBCurrencyRate.Text = text2;
                this.TBCurrencySymbol.Text = text3;
                this.TBCurrencyCode.Text = array[3];
            }
            catch (Exception serviceException)
            {
                string message;
                if (!false)
                {
                    message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                }
                if (!false)
                {
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void btnDeleteCurrency_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool arg_A8_0;
                bool arg_A1_0;
                int arg_C4_0;
                bool flag;
                if (!false)
                {
                    bool expr_18 = arg_A1_0 = (arg_A8_0 = (System.Windows.MessageBox.Show("Do you want to delete this currency?", "Tempar Data", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes));
                    if (8 == 0)
                    {
                        goto IL_A1;
                    }
                    if (false)
                    {
                        goto IL_A8;
                    }
                    bool expr_27 = (arg_C4_0 = ((!expr_18) ? 1 : 0)) != 0;
                    if (false)
                    {
                        goto IL_B3;
                    }
                    if (!false)
                    {
                        flag = expr_27;
                    }
                    if (flag)
                    {
                        goto IL_ED;
                    }
                }
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                string currencyDetailFromID = new CurrencyBusiness().GetCurrencyDetailFromID((int)button.Tag);
                string[] array = currencyDetailFromID.Split(new char[]
                {
                    '#'
                });
                string str = array[0];
                bool flag2 = new CurrencyBusiness().DeleteCurrency((int)button.Tag);
                arg_A1_0 = !flag2;
            IL_A1:
                flag = arg_A1_0;
                if (-1 == 0)
                {
                    goto IL_EB;
                }
                arg_A8_0 = flag;
            IL_A8:
                if (arg_A8_0)
                {
                    goto IL_EC;
                }
                if (-1 == 0)
                {
                    goto IL_ED;
                }
                arg_C4_0 = LoginUser.UserId;
            IL_B3:
                AuditLog.AddUserLog(arg_C4_0, 7, "Currency (" + str + ") has been deleted on ");
                System.Windows.MessageBox.Show("Currency deleted successfully");
                this.DGManageCurrency.ItemsSource = new CurrencyBusiness().GetCurrencyDetails();
            IL_EB:
            IL_EC:
            IL_ED:;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = sender == null;
                if (!flag)
                {
                    if (false)
                    {
                    }
                    System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                    bool expr_37 = button == null;
                    if (8 != 0)
                    {
                        flag = expr_37;
                    }
                    bool arg_45_0 = flag;
                IL_45:
                    while (!arg_45_0)
                    {
                        BorderInfo borderInfo = (BorderInfo)button.DataContext;
                        flag = (borderInfo == null);
                        int arg_61_0 = flag ? 1 : 0;
                        while (arg_61_0 == 0)
                        {
                            string empty = string.Empty;
                            bool flag2 = this.FindDependencyOfBorder(borderInfo, "edit", out empty);
                            if (flag2)
                            {
                                //this.MsgBox.ShowHandlerDialog(empty, DigiMessageBox.DialogType.OK);
                                break;
                            }
                            int id = (int)button.Tag;
                            flag = (System.Windows.MessageBox.Show("Do you want to delete this border?", "Confirm delete", MessageBoxButton.YesNo) != MessageBoxResult.Yes);
                            string dG_Border;
                            bool flag3;
                            if (!false)
                            {
                                bool expr_C2 = arg_45_0 = flag;
                                if (7 == 0)
                                {
                                    goto IL_45;
                                }
                                if (expr_C2)
                                {
                                    break;
                                }
                                dG_Border = new BorderBusiness().GetBorderNameFromID(id).DG_Border;
                                flag3 = new BorderBusiness().DeleteBorder(id);
                            }
                            int arg_127_0;
                            if (File.Exists(LoginUser.DigiFolderFramePath + "\\Thumbnails\\" + dG_Border))
                            {
                                arg_127_0 = (arg_61_0 = ((!File.Exists(LoginUser.DigiFolderFramePath + dG_Border)) ? 1 : 0));
                            }
                            else
                            {
                                arg_127_0 = (arg_61_0 = 1);
                            }
                        IL_120:
                            if (!false)
                            {
                                if (arg_127_0 == 0)
                                {
                                    do
                                    {
                                        File.Delete(LoginUser.DigiFolderFramePath + "\\Thumbnails\\" + dG_Border);
                                    }
                                    while (false);
                                    File.Delete(LoginUser.DigiFolderFramePath + dG_Border);
                                    this.DeleteFromAllSubstore(this.lstConfigurationInfo, dG_Border, "Frames");
                                    bool expr_16E = (arg_61_0 = (arg_127_0 = (flag3 ? 1 : 0))) != 0;
                                    if (false)
                                    {
                                        goto IL_11D;
                                    }
                                    if (expr_16E)
                                    {
                                        System.Windows.MessageBox.Show("Border deleted successfully");
                                        AuditLog.AddUserLog(LoginUser.UserId, 59, "Border deleted at ");
                                    }
                                }
                                List<BorderInfo> borderDetails = new BorderBusiness().GetBorderDetails();
                                borderDetails.ForEach(delegate (BorderInfo x)
                                {
                                    x.FilePath = Path.Combine(LoginUser.DigiFolderFramePath, x.DG_Border);
                                });
                                this.DGManageBorder.ItemsSource = borderDetails;
                                break;
                            }
                            continue;
                        IL_11D:
                            goto IL_120;
                            break;
                        }
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                do
                {
                    bool arg_238_0;
                    bool expr_22F = arg_238_0 = !(ex is IOException);
                    if (2 != 0)
                    {
                        bool flag = expr_22F;
                        arg_238_0 = flag;
                    }
                    if (arg_238_0)
                    {
                        goto IL_28D;
                    }
                    System.Windows.MessageBox.Show("Border deleted successfully");
                    List<BorderInfo> borderDetails = new BorderBusiness().GetBorderDetails();
                    borderDetails.ForEach(delegate (BorderInfo x)
                    {
                        x.FilePath = Path.Combine(LoginUser.DigiFolderFramePath, x.DG_Border);
                    });
                    this.DGManageBorder.ItemsSource = borderDetails;
                }
                while (false);
                goto IL_2B7;
            IL_28D:
                System.Windows.MessageBox.Show("Can not delete file because " + ex.Message);
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            IL_2B7:;
            }
        }

        private void btnclearCurrency_Click(object sender, RoutedEventArgs e)
        {
            this.ClearControlCurrency();
        }

        private void ClearControlCurrency()
        {
            while (true)
            {
                while (true)
                {
                    this.TBCurrencyName.Text = "";
                    while (!false)
                    {
                        this.TBCurrencySymbol.Text = "";
                        do
                        {
                            if (8 != 0)
                            {
                                this.TBCurrencyRate.Text = "";
                            }
                        }
                        while (3 == 0);
                        if (2 == 0)
                        {
                            break;
                        }
                        if (6 != 0)
                        {
                            goto Block_4;
                        }
                    }
                }
            }
        Block_4:
            this.TBCurrencyCode.Text = "";
        }

        private bool CheckBorderValidations()
        {
            int arg_4D_0;
            bool expr_6D = (arg_4D_0 = ((this.txtSelectedborder.Text == "") ? 1 : 0)) != 0;
            int arg_5C_0;
            bool flag;
            if (2 != 0)
            {
                bool arg_77_0 = (arg_4D_0 = ((!expr_6D) ? 1 : 0)) != 0;
                while (!false)
                {
                    if (!arg_77_0)
                    {
                        int expr_28 = arg_5C_0 = 0;
                        if (expr_28 != 0)
                        {
                            return arg_5C_0 != 0;
                        }
                        arg_77_0 = (expr_28 != 0);
                        arg_4D_0 = expr_28;
                        if (expr_28 == 0)
                        {
                            flag = (expr_28 != 0);
                            goto IL_5B;
                        }
                    }
                    else
                    {
                        if (5 != 0)
                        {
                            arg_4D_0 = ((!(this.CmbProductType.SelectedValue.ToString() == "0")) ? 1 : 0);
                            break;
                        }
                        goto IL_51;
                    }
                }
            }
            if (arg_4D_0 != 0)
            {
                flag = true;
                goto IL_5B;
            }
        IL_51:
            flag = false;
        IL_5B:
            arg_5C_0 = (flag ? 1 : 0);
            return arg_5C_0 != 0;
        }

        private bool CheckCurrencyValidations()
        {
            if (8 != 0)
            {
            }
            bool result;
            if (!(this.TBCurrencyName.Text == ""))
            {
                bool arg_73_0;
                int expr_CC = (arg_73_0 = (this.TBCurrencyRate.Text == "")) ? 1 : 0;
                int arg_73_1;
                int expr_4F = arg_73_1 = 0;
                if (expr_4F != 0)
                {
                    goto IL_73;
                }
                if (expr_CC == expr_4F)
                {
                    arg_73_0 = (this.TBCurrencyCode.Text == "");
                    arg_73_1 = 0;
                    goto IL_73;
                }
            IL_59:
                result = false;
                return result;
            IL_73:
                bool flag = (arg_73_0 ? 1 : 0) == arg_73_1;
                int arg_8B_0;
                bool expr_76 = (arg_8B_0 = (flag ? 1 : 0)) != 0;
                if (!false)
                {
                    if (!expr_76)
                    {
                        result = false;
                        if (!false)
                        {
                            return result;
                        }
                        goto IL_59;
                    }
                    else
                    {
                        if (8 == 0)
                        {
                            return result;
                        }
                        if (-1 == 0)
                        {
                            goto IL_2C;
                        }
                        arg_8B_0 = 1;
                    }
                }
                result = (arg_8B_0 != 0);
                return result;
            }
        IL_2C:
            result = false;
            return result;
        }

        private void btnSelectBackground_Click(object sender, RoutedEventArgs e)
        {
            while (this.EditableBackground == null)
            {
                Microsoft.Win32.OpenFileDialog expr_200 = new Microsoft.Win32.OpenFileDialog();
                Microsoft.Win32.OpenFileDialog openFileDialog;
                if (!false)
                {
                    openFileDialog = expr_200;
                }
                if (5 != 0)
                {
                    openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
                    this.lstBackgroundInfo.Clear();
                    openFileDialog.Multiselect = (this.EditableBackground == null);
                    if (true)
                    {
                        if (openFileDialog.ShowDialog().Value)
                        {
                            if (4 == 0)
                            {
                                continue;
                            }
                            try
                            {
                                if (openFileDialog.OpenFile() != null)
                                {
                                    string text = string.Empty;
                                    int arg_C1_0;
                                    bool expr_A8 = (arg_C1_0 = ((!openFileDialog.Multiselect) ? 1 : 0)) != 0;
                                    string[] fileNames;
                                    if (!false)
                                    {
                                        if (expr_A8)
                                        {
                                            this.txtSelectedBackground.Text = Path.GetFileName(openFileDialog.FileName);
                                            this.txtSelectedBackground.Tag = openFileDialog.FileName;
                                            break;
                                        }
                                        fileNames = openFileDialog.FileNames;
                                        arg_C1_0 = 0;
                                    }
                                    for (int i = arg_C1_0; i < fileNames.Length; i++)
                                    {
                                        string text2 = fileNames[i];
                                        BackGroundInfo backGroundInfo;
                                        do
                                        {
                                            backGroundInfo = new BackGroundInfo();
                                            text = Path.GetFileName(text2) + "," + text;
                                            backGroundInfo.DG_BackGround_Image_Name = Path.GetFileNameWithoutExtension(text2);
                                        }
                                        while (false);
                                        backGroundInfo.DG_BackGround_Image_Display_Name = Path.GetFileName(text2);
                                        backGroundInfo.DG_BackgroundPath = text2;
                                        backGroundInfo.DG_Background_IsActive = new bool?(this.IsBackgroundActive.IsChecked.HasValue && this.IsBackgroundActive.IsChecked.Value);
                                        this.lstBackgroundInfo.Add(backGroundInfo);
                                    }
                                    this.txtSelectedBackground.Text = text.Remove(text.Length - 1);
                                }
                            }
                            catch (Exception ex)
                            {
                                System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                            }
                        }
                        return;
                    }
                }
            }
        }

        private void btnSaveSelectBackground_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
            IL_00:
                while (true)
                {
                IL_01:
                    bool flag = (this.lstBackgroundInfo == null && !false) || this.lstBackgroundInfo.Count <= 0;
                    while (flag)
                    {
                        flag = (this.EditableBackground == null);
                        if (!flag)
                        {
                            if (false)
                            {
                                goto IL_00;
                            }
                            this.bs.Show();
                            if (8 != 0)
                            {
                                goto Block_6;
                            }
                        }
                        else
                        {
                            if (!false)
                            {
                                goto Block_7;
                            }
                            goto IL_01;
                        }
                    }
                    goto Block_1;
                }
            }
        Block_1:
            this.bs.Show();
            if (-1 != 0)
            {
                this.bw_CopySettings.RunWorkerAsync();
            }
        IL_58:
            if (6 != 0)
            {
                return;
            }
            goto IL_58;
        Block_6:
            this.bw_CopySettings.RunWorkerAsync();
            return;
        Block_7:
            System.Windows.MessageBox.Show("Please browse Background");
        }

        private void SaveBackground()
        {
            //try
            //{
            //    Configuration expr_136 = new Configuration();

            //    Configuration c__DisplayClass;
            //    if (!false)
            //    {
            //        c__DisplayClass = expr_136;
            //    }
            //    if (-1 != 0)
            //    {
            //        c__DisplayClass  = this;
            //        c__DisplayClass.productId = 2;
            //        if (4 != 0)
            //        {
            //            c__DisplayClass.bacBiz = new BackgroundBusiness();
            //            c__DisplayClass._backgroundname = string.Empty;
            //            c__DisplayClass.SyncCode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Background).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
            //            bool arg_AF_0;
            //            if (this.lstBackgroundInfo != null)
            //            {
            //                arg_AF_0 = (this.lstBackgroundInfo.Count <= 0);
            //                goto IL_AE;
            //            }
            //            IL_AD:
            //            arg_AF_0 = true;
            //            IL_AE:
            //            bool flag = arg_AF_0;
            //            while (!flag)
            //            {
            //                Configuration.DelegateWork method = delegate
            //                {
            //                    foreach (BackGroundInfo current in  c__DisplayClass.lstBackgroundInfo)
            //                    {
            //                        c__DisplayClass._backgroundname = current.DG_BackGround_Image_Name + ".png";
            //                        c__DisplayClass.backgounddisplayname = current.DG_BackGround_Image_Display_Name;
            //                        c__DisplayClass.BackGroundID = c__DisplayClass.bacBiz.SetBackGroundDetails(c__DisplayClass.productId, c__DisplayClass._backgroundname, c__DisplayClass.backgounddisplayname, c__DisplayClass.SyncCode, c__DisplayClass.IsBackgroundActive.IsChecked.HasValue && c__DisplayClass.IsBackgroundActive.IsChecked.Value, LoginUser.UserId);
            //                        c__DisplayClass.backgoundname = Path.GetFileNameWithoutExtension(c__DisplayClass._backgroundname) + "_" + c__DisplayClass.BackGroundID.ToString() + ".png";
            //                        c__DisplayClass.bacBiz.SetBackGroundDetails(c__DisplayClass.productId, c__DisplayClass.backgoundname, c__DisplayClass._backgroundname, c__DisplayClass.BackGroundID, c__DisplayClass.SyncCode, new bool?(c__DisplayClass.IsBackgroundActive.IsChecked.HasValue && c__DisplayClass.IsBackgroundActive.IsChecked.Value), LoginUser.UserId);
            //                        string sourcefile = LoginUser.DigiFolderBackGroundPath + "\\8x10\\" + c__DisplayClass.backgoundname;
            //                        string text = string.Empty;
            //                        c__DisplayClass.BackgroundImageOtherFormats(current.DG_BackgroundPath);
            //                        using (FileStream fileStream = File.OpenRead(LoginUser.DigiFolderBackGroundPath + "\\8x10\\" + c__DisplayClass.backgoundname))
            //                        {
            //                            MemoryStream memoryStream = new MemoryStream();
            //                            fileStream.CopyTo(memoryStream);
            //                            memoryStream.Seek(0L, SeekOrigin.Begin);
            //                            text = LoginUser.DigiFolderBackGroundPath + "\\Thumbnails\\" + c__DisplayClass.backgoundname;
            //                            c__DisplayClass.ResizeAndSaveHighQualityImage(System.Drawing.Image.FromStream(memoryStream), text, 100, 150);
            //                            fileStream.Close();
            //                            memoryStream.Dispose();
            //                        }
            //                        c__DisplayClass.CopyToAllSubstore(c__DisplayClass.lstConfigurationInfo, sourcefile, text, "BG");
            //                    }
            //                    AuditLog.AddUserLog(LoginUser.UserId, 49, "Add/Edit Background at ");
            //                };
            //                base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, method);
            //                if (!false)
            //                {
            //                    goto IL_127;
            //                }
            //            }
            //            if (this.EditableBackground != null)
            //            {
            //                if (false)
            //                {
            //                    goto IL_AD;
            //                }
            //                Configuration.DelegateWork method2 = delegate
            //                {
            //                    if (c__DisplayClass.txtSelectedBackground.Text.Equals(c__DisplayClass.EditableBackground.DG_BackGround_Image_Display_Name))
            //                    {
            //                        c__DisplayClass.backgounddisplayname = c__DisplayClass.EditableBackground.DG_BackGround_Image_Display_Name;
            //                        c__DisplayClass.backgoundname = c__DisplayClass.EditableBackground.DG_BackGround_Image_Name;
            //                    }
            //                    else
            //                    {
            //                        c__DisplayClass._backgroundname = Path.GetFileNameWithoutExtension(c__DisplayClass.txtSelectedBackground.Tag.ToString());
            //                        c__DisplayClass.backgounddisplayname = c__DisplayClass._backgroundname + ".png";
            //                        c__DisplayClass.backgoundname = c__DisplayClass._backgroundname + "_" + c__DisplayClass.BackGroundID.ToString() + ".png";
            //                    }
            //                    c__DisplayClass.bacBiz.SetBackGroundDetails(c__DisplayClass.productId, c__DisplayClass.backgoundname, c__DisplayClass.backgounddisplayname, c__DisplayClass.EditableBackground.DG_Background_pkey, c__DisplayClass.SyncCode, c__DisplayClass.IsBackgroundActive.IsChecked, LoginUser.UserId);
            //                    if (!c__DisplayClass.txtSelectedBackground.Text.Equals(c__DisplayClass.EditableBackground.DG_BackGround_Image_Display_Name))
            //                    {
            //                        if (false)
            //                        {
            //                            goto IL_2A1;
            //                        }
            //                        string sourcefile = LoginUser.DigiFolderBackGroundPath + c__DisplayClass.backgoundname;
            //                        string text = string.Empty;
            //                        c__DisplayClass.BackgroundImageOtherFormats(c__DisplayClass.txtSelectedBackground.Tag.ToString());
            //                        using (FileStream fileStream = File.OpenRead(LoginUser.DigiFolderBackGroundPath + "\\8x10\\" + c__DisplayClass.backgoundname))
            //                        {
            //                            MemoryStream memoryStream = new MemoryStream();
            //                            fileStream.CopyTo(memoryStream);
            //                            memoryStream.Seek(0L, SeekOrigin.Begin);
            //                            text = LoginUser.DigiFolderBackGroundPath + "\\Thumbnails\\" + c__DisplayClass.backgoundname;
            //                            c__DisplayClass.ResizeAndSaveHighQualityImage(System.Drawing.Image.FromStream(memoryStream), text, 100, 150);
            //                            fileStream.Close();
            //                            memoryStream.Dispose();
            //                        }
            //                        c__DisplayClass.CopyToAllSubstore(c__DisplayClass.lstConfigurationInfo, sourcefile, text, "BG");
            //                    }
            //                    c__DisplayClass.EditableBackground = null;
            //                    c__DisplayClass._backgroundname = (c__DisplayClass.backgoundname = (c__DisplayClass.backgounddisplayname = string.Empty));
            //                    c__DisplayClass.GetBackgrounds();
            //                    IL_2A1:
            //                    c__DisplayClass.btnCancelSelectBackgound_Click(null, null);
            //                    AuditLog.AddUserLog(LoginUser.UserId, 49, "Add/Edit Background at ");
            //                };
            //                base.Dispatcher.BeginInvoke(DispatcherPriority.Normal, method2);
            //            }
            //            else
            //            {
            //                System.Windows.MessageBox.Show("Please browse Background");
            //            }
            //        }
            //    }
            //    IL_127:;
            //}
            //catch (Exception serviceException)
            //{
            //    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
            //    ErrorHandler.ErrorHandler.LogFileWrite(message);
            //    while (2 == 0)
            //    {
            //    }
            //}
        }

        private void CopyToAllSubstore(List<ConfigurationInfo> _objConfigInfo, string Sourcefile, string sourceThumbnails, string ItemType)
        {
            try
            {
                do
                {
                    List<ConfigurationInfo>.Enumerator expr_4B9 = _objConfigInfo.GetEnumerator();
                    List<ConfigurationInfo>.Enumerator enumerator;
                    if (true)
                    {
                        enumerator = expr_4B9;
                    }
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            ConfigurationInfo current = enumerator.Current;
                            bool flag = !(current.DG_Substore_Id != LoginUser.SubStoreId);
                            string text;
                            bool arg_33B_0;
                            if (!flag)
                            {
                                text = string.Empty;
                                if (ItemType == "BG")
                                {
                                    text = current.DG_BG_Path;
                                    goto IL_1B0;
                                }
                                if (ItemType == "Frames")
                                {
                                    text = current.DG_Frame_Path;
                                    goto IL_1B0;
                                }
                                if (ItemType == "Graphics")
                                {
                                    text = current.DG_Graphics_Path;
                                    goto IL_1B0;
                                }
                                if (false)
                                {
                                    goto IL_40E;
                                }
                                flag = !(ItemType == "StockShot");
                                bool expr_E8 = arg_33B_0 = flag;
                                if (false)
                                {
                                    goto IL_33A;
                                }
                                if (!expr_E8)
                                {
                                    text = current.DG_Hot_Folder_Path + "StockShot\\";
                                    goto IL_1B0;
                                }
                                if (ItemType == "Audio")
                                {
                                    text = current.DG_Hot_Folder_Path + "Audio\\";
                                    goto IL_1B0;
                                }
                                if (ItemType == "Video")
                                {
                                    text = current.DG_Hot_Folder_Path + "VideoTemplate\\";
                                    goto IL_1B0;
                                }
                                flag = !(ItemType == "VideoBG");
                                goto IL_16F;
                            }
                        IL_450:
                            if (!false)
                            {
                                continue;
                            }
                            goto IL_16F;
                        IL_44F:
                            goto IL_450;
                        IL_44E:
                            goto IL_44F;
                        IL_1F5:
                            bool arg_1F5_0;
                            flag = arg_1F5_0;
                            if (flag)
                            {
                                goto IL_44E;
                            }
                            string text2 = text + "Thumbnails\\" + Path.GetFileName(sourceThumbnails);
                            flag = !File.Exists(sourceThumbnails);
                            bool arg_1C9_0;
                            bool expr_21C = arg_1C9_0 = flag;
                            if (4 == 0)
                            {
                                goto IL_1C8;
                            }
                            if (!expr_21C)
                            {
                                File.Copy(sourceThumbnails, text2, true);
                            }
                            flag = !(ItemType == "BG");
                            string text4;
                            string text5;
                            string text6;
                            string text7;
                            string text9;
                            string text10;
                            string text11;
                            string text12;
                            if (!flag)
                            {
                                string text3 = LoginUser.DigiFolderBackGroundPath + "\\3x3\\" + this.backgoundname;
                                text4 = LoginUser.DigiFolderBackGroundPath + "\\4x6\\" + this.backgoundname;
                                text5 = LoginUser.DigiFolderBackGroundPath + "\\5x7\\" + this.backgoundname;
                                text6 = LoginUser.DigiFolderBackGroundPath + "\\6x8\\" + this.backgoundname;
                                text7 = LoginUser.DigiFolderBackGroundPath + "\\8x10\\" + this.backgoundname;
                                string text8 = current.DG_BG_Path + "\\3x3\\";
                                text9 = current.DG_BG_Path + "\\4x6\\";
                                text10 = current.DG_BG_Path + "\\5x7\\";
                                text11 = current.DG_BG_Path + "\\6x8\\";
                                text12 = current.DG_BG_Path + "\\8x10\\";
                                if (!Directory.Exists(text8))
                                {
                                    Directory.CreateDirectory(text8);
                                }
                                text2 = text8 + Path.GetFileName(sourceThumbnails);
                                arg_33B_0 = File.Exists(text3);
                                goto IL_33A;
                            }
                            goto IL_44D;
                        IL_1E4:
                            bool arg_1E4_0;
                            if (!arg_1E4_0)
                            {
                                File.Copy(Sourcefile, text2, true);
                            }
                            arg_1F5_0 = string.IsNullOrEmpty(sourceThumbnails);
                            goto IL_1F5;
                        IL_1C8:
                            flag = !arg_1C9_0;
                            if (!flag)
                            {
                                flag = text.Contains("BG");
                                arg_1E4_0 = flag;
                                goto IL_1E4;
                            }
                            goto IL_44F;
                        IL_1B0:
                            text2 = text + Path.GetFileName(Sourcefile);
                            arg_1C9_0 = Directory.Exists(Path.GetDirectoryName(text2));
                            goto IL_1C8;
                        IL_44D:
                            goto IL_44E;
                        IL_40F:
                            if (!Directory.Exists(text12))
                            {
                                Directory.CreateDirectory(text12);
                            }
                            text2 = text12 + Path.GetFileName(sourceThumbnails);
                            flag = !File.Exists(text7);
                            if (!flag)
                            {
                                File.Copy(text7, text2, true);
                            }
                            goto IL_44D;
                        IL_40E:
                            goto IL_40F;
                        IL_33A:
                            if (arg_33B_0)
                            {
                                string text3 = "";
                                File.Copy(text3, text2, true);
                            }
                            if (!Directory.Exists(text9))
                            {
                                Directory.CreateDirectory(text9);
                            }
                            text2 = text9 + Path.GetFileName(sourceThumbnails);
                            if (File.Exists(text4))
                            {
                                File.Copy(text4, text2, true);
                            }
                            bool expr_38B = arg_1F5_0 = Directory.Exists(text10);
                            if (2 == 0)
                            {
                                goto IL_1F5;
                            }
                            if (!expr_38B)
                            {
                                Directory.CreateDirectory(text10);
                            }
                            text2 = text10 + Path.GetFileName(sourceThumbnails);
                            if (File.Exists(text5))
                            {
                                File.Copy(text5, text2, true);
                            }
                            flag = Directory.Exists(text11);
                            bool expr_3D5 = arg_1E4_0 = flag;
                            if (false)
                            {
                                goto IL_1E4;
                            }
                            if (!expr_3D5)
                            {
                                Directory.CreateDirectory(text11);
                            }
                            text2 = text11 + Path.GetFileName(sourceThumbnails);
                            if (File.Exists(text6))
                            {
                                File.Copy(text6, text2, true);
                                goto IL_40E;
                            }
                            goto IL_40F;
                        IL_16F:
                            if (!flag)
                            {
                                text = current.DG_Hot_Folder_Path + "VideoBackGround\\";
                                goto IL_1B0;
                            }
                            if (ItemType == "VideoOverlay")
                            {
                                text = current.DG_Hot_Folder_Path + "VideoOverlay\\";
                                goto IL_1B0;
                            }
                            goto IL_1B0;
                        }
                    }
                    finally
                    {
                        ((IDisposable)enumerator).Dispose();
                    }
                }
                while (5 == 0);
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
        }

        private void DeleteFromAllSubstore(List<ConfigurationInfo> _objConfigInfo, string Sourcefile, string ItemType)
        {
            try
            {
                List<ConfigurationInfo>.Enumerator enumerator = _objConfigInfo.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        ConfigurationInfo current = enumerator.Current;
                        if (current.DG_Substore_Id != LoginUser.SubStoreId)
                        {
                            string str = string.Empty;
                            if (ItemType == "BG")
                            {
                                goto IL_7A;
                            }
                            bool flag = !(ItemType == "Frames");
                            bool arg_113_0;
                            bool expr_98 = arg_113_0 = flag;
                            if (!false)
                            {
                                if (!expr_98)
                                {
                                    str = current.DG_Frame_Path;
                                    goto IL_1A9;
                                }
                                if (!(ItemType == "Graphics"))
                                {
                                    flag = !(ItemType == "StockShot");
                                    while (!flag)
                                    {
                                        if (!false)
                                        {
                                            str = current.DG_Hot_Folder_Path + "StockShot\\";
                                            if (7 != 0)
                                            {
                                                goto IL_1A9;
                                            }
                                            goto IL_C1;
                                        }
                                    }
                                    flag = !(ItemType == "Audio");
                                    arg_113_0 = flag;
                                    goto IL_113;
                                }
                            IL_C1:
                                str = current.DG_Graphics_Path;
                                goto IL_1A9;
                            }
                        IL_113:
                            if (!arg_113_0)
                            {
                                str = current.DG_Hot_Folder_Path + "Audio\\";
                                goto IL_1A9;
                            }
                            if (ItemType == "Video")
                            {
                                str = current.DG_Hot_Folder_Path + "VideoTemplate\\";
                                goto IL_1A9;
                            }
                            if (ItemType == "VideoBG")
                            {
                                if (!false)
                                {
                                    str = current.DG_Hot_Folder_Path + "VideoBackGround\\";
                                    goto IL_1A9;
                                }
                                goto IL_2B6;
                            }
                            else
                            {
                                if (ItemType == "VideoOverlay")
                                {
                                    str = current.DG_Hot_Folder_Path + "VideoOverlay\\";
                                    goto IL_1A9;
                                }
                                goto IL_1A9;
                            }
                            continue;
                            continue;
                        IL_1A9:
                            string path = str + Path.GetFileName(Sourcefile);
                            if (!Directory.Exists(Path.GetDirectoryName(path)))
                            {
                                continue;
                            }
                            bool arg_27C_0;
                            bool expr_1D5 = arg_27C_0 = !File.Exists(path);
                            string path4;
                            if (!false)
                            {
                                if (!expr_1D5)
                                {
                                    File.Delete(path);
                                }
                                if (7 == 0)
                                {
                                    goto IL_7A;
                                }
                                string path2 = str + "Thumbnails\\" + Path.GetFileName(path);
                                if (File.Exists(path2))
                                {
                                    File.Delete(path2);
                                }
                                if (!(ItemType == "BG"))
                                {
                                    continue;
                                }
                                string path3 = str + "3x3\\" + Path.GetFileName(path);
                                if (false)
                                {
                                    goto IL_7A;
                                }
                                if (File.Exists(path3))
                                {
                                    File.Delete(path3);
                                }
                                path4 = str + "4x6\\" + Path.GetFileName(path);
                                arg_27C_0 = File.Exists(path4);
                            }
                            if (arg_27C_0)
                            {
                                File.Delete(path4);
                            }
                            string path5 = str + "5x7\\" + Path.GetFileName(path);
                            if (File.Exists(path5))
                            {
                                File.Delete(path5);
                                goto IL_2B6;
                            }
                            goto IL_2B7;
                        IL_7A:
                            str = current.DG_BG_Path;
                            goto IL_1A9;
                        IL_2B7:
                            string path6 = str + "6x8\\" + Path.GetFileName(path);
                            if (File.Exists(path6))
                            {
                                File.Delete(path6);
                            }
                            string path7 = str + "8x10\\" + Path.GetFileName(path);
                            if (File.Exists(path7))
                            {
                                File.Delete(path7);
                            }
                            continue;
                        IL_2B6:
                            goto IL_2B7;
                        }
                    }
                }
                finally
                {
                    do
                    {
                        ((IDisposable)enumerator).Dispose();
                    }
                    while (false);
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool CheckBackGroundValidations()
        {
            if (false)
            {
                goto IL_1C;
            }
            if (-1 == 0)
            {
                goto IL_23;
            }
            bool arg_73_0 = !(this.txtSelectedBackground.Text == "");
        IL_1A:
            bool flag = arg_73_0;
        IL_1C:
            bool expr_79 = arg_73_0 = flag;
            if (false)
            {
                goto IL_1A;
            }
            bool result;
            if (expr_79)
            {
                int arg_50_0;
                bool expr_33 = (arg_50_0 = (this.IsProductTypeSelected ? 1 : 0)) != 0;
                if (7 != 0)
                {
                    flag = expr_33;
                    if (flag)
                    {
                        result = true;
                        return result;
                    }
                    if (!false)
                    {
                        System.Windows.MessageBox.Show("Please Select the product type");
                    }
                    arg_50_0 = 0;
                }
                result = (arg_50_0 != 0);
                return result;
            }
        IL_23:
            System.Windows.MessageBox.Show("Please Select the background File");
            result = false;
            return result;
        }

        private bool CheckGraphicsValidations()
        {
            bool result;
            while (true)
            {
                bool arg_15_0;
                bool arg_1E_0 = arg_15_0 = (this.txtSelectedgraphics.Text == "");
                while (true)
                {
                    bool flag;
                    if (4 != 0)
                    {
                        flag = !arg_15_0;
                        goto IL_19;
                    }
                IL_1B:
                    if (false)
                    {
                        continue;
                    }
                    if (!arg_1E_0)
                    {
                        System.Windows.MessageBox.Show("Please select the graphics file");
                        while (7 != 0)
                        {
                            bool expr_2C = false;
                            if (!false)
                            {
                                result = expr_2C;
                            }
                            if (4 != 0)
                            {
                                if (!false)
                                {
                                    goto Block_5;
                                }
                                goto IL_19;
                            }
                        }
                        break;
                    }
                    goto IL_39;
                IL_19:
                    arg_1E_0 = (arg_15_0 = flag);
                    goto IL_1B;
                }
            }
        Block_5:
            return result;
        IL_39:
            result = true;
            return result;
        }

        private void btnDeleteBackground_Click(object sender, RoutedEventArgs e)
        {
            int bgID = 0;
            try
            {
                this.btnCancelSelectBackgound_Click(sender, e);
                if (sender != null)
                {
                    System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                    string empty;
                    if (button != null)
                    {
                        BackGroundInfo backGroundInfo = null;
                        try
                        {
                            backGroundInfo = (BackGroundInfo)button.Tag;
                        }
                        catch (Exception ex)
                        {
                            backGroundInfo = null;
                        }
                        bool flag = backGroundInfo == null;
                        bool arg_261_0;
                        bool expr_6E = arg_261_0 = flag;
                        if (!false)
                        {
                            if (expr_6E)
                            {
                                goto IL_291;
                            }
                            empty = string.Empty;
                            bool flag2 = this.FindDependencyOfBackground(backGroundInfo, "delete", out empty);
                            if (flag2)
                            {
                                goto IL_9E;
                            }
                            bgID = backGroundInfo.DG_Background_pkey;
                            string text = button.CommandParameter.ToString();
                            if (System.Windows.MessageBox.Show("Do you want to delete this background?", "Confirm delete", MessageBoxButton.YesNo) != MessageBoxResult.Yes)
                            {
                                goto IL_290;
                            }
                            BackgroundBusiness backgroundBusiness = new BackgroundBusiness();
                            try
                            {
                                int arg_196_0;
                                while (true)
                                {
                                    if (File.Exists(LoginUser.DigiFolderBackGroundPath + "\\Thumbnails\\" + text))
                                    {
                                        bool expr_11B = (arg_196_0 = (File.Exists(LoginUser.DigiFolderBackGroundPath + "\\4x6\\" + text) ? 1 : 0)) != 0;
                                        if (false)
                                        {
                                            goto IL_196;
                                        }
                                        if (expr_11B && File.Exists(LoginUser.DigiFolderBackGroundPath + "\\5x7\\" + text))
                                        {
                                            while (File.Exists(LoginUser.DigiFolderBackGroundPath + "\\6x8\\" + text) && File.Exists(LoginUser.DigiFolderBackGroundPath + "\\8x10\\" + text))
                                            {
                                                if (7 != 0)
                                                {
                                                    goto Block_17;
                                                }
                                            }
                                        }
                                    }
                                    if (6 != 0)
                                    {
                                        goto Block_18;
                                    }
                                }
                            Block_17:
                                arg_196_0 = ((!File.Exists(LoginUser.DigiFolderBackGroundPath + "\\3x3\\" + text)) ? 1 : 0);
                                goto IL_195;
                            Block_18:
                                if (false)
                                {
                                    goto IL_1B7;
                                }
                                arg_196_0 = 1;
                            IL_195:
                            IL_196:
                                if (arg_196_0 != 0)
                                {
                                    goto IL_23F;
                                }
                                File.Delete(LoginUser.DigiFolderBackGroundPath + "\\Thumbnails\\" + text);
                            IL_1B7:
                                File.Delete(LoginUser.DigiFolderBackGroundPath + "\\4x6\\" + text);
                                File.Delete(LoginUser.DigiFolderBackGroundPath + "\\5x7\\" + text);
                                File.Delete(LoginUser.DigiFolderBackGroundPath + "\\3x3\\" + text);
                                File.Delete(LoginUser.DigiFolderBackGroundPath + "\\6x8\\" + text);
                                File.Delete(LoginUser.DigiFolderBackGroundPath + "\\8x10\\" + text);
                                this.DeleteFromAllSubstore(this.lstConfigurationInfo, text, "BG");
                            IL_23F:;
                            }
                            catch (Exception ex)
                            {
                                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
                                ErrorHandler.ErrorHandler.LogFileWrite(message);
                            }
                            arg_261_0 = backgroundBusiness.DeleteBackGround(bgID);
                        }
                        if (arg_261_0)
                        {
                            System.Windows.MessageBox.Show("Background deleted successfully");
                            AuditLog.AddUserLog(LoginUser.UserId, 58, "Background deleted at ");
                            this.GetBackgrounds();
                        }
                    IL_290:
                    IL_291:
                        goto IL_292;
                    }
                    goto IL_292;
                IL_9E:
                    //this.MsgBox.ShowHandlerDialog(empty, DigiMessageBox.DialogType.OK);
                    return;
                IL_292:
                    if (false)
                    {
                        goto IL_9E;
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    System.Windows.MessageBox.Show("Background deleted successfully");
                }
                else
                {
                    System.Windows.MessageBox.Show("Can not delete file because " + ex.Message);
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    if (!false)
                    {
                        goto IL_32A;
                    }
                    goto IL_2FB;
                }
            IL_2F5:
                this.GetBackgrounds();
            IL_2FB:
            IL_32A:
                if (8 == 0)
                {
                    goto IL_2F5;
                }
            }
        }

        private void btnCancelSelectBackgound_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                try
                {
                    if (!false)
                    {
                        this.txtSelectedBackground.Text = string.Empty;
                        while (-1 != 0)
                        {
                            this.lstBackgroundInfo.Clear();
                            this.DGManageBackground.SelectedItem = null;
                            if (7 == 0)
                            {
                                goto IL_49;
                            }
                            if (3 != 0)
                            {
                                this.IsBackgroundActive.IsChecked = new bool?(true);
                                break;
                            }
                        }
                    }
                    this.EditableBackground = null;
                IL_49:;
                }
                catch (Exception var_0_7C)
                {
                }
            }
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_33;
            }
            if (!false)
            {
            }
            System.Windows.Controls.RadioButton radioButton = (System.Windows.Controls.RadioButton)sender;
            this.productId = radioButton.CommandParameter.ToInt32(false);
        IL_1E:
            int arg_20_0 = 1;
            do
            {
                arg_20_0 = ((arg_20_0 == 0) ? 1 : 0);
            }
            while (2 == 0);
            if (6 == 0)
            {
            }
            this.IsProductTypeSelected = true;
        IL_33:
            if (!false)
            {
                return;
            }
            goto IL_1E;
        }

        private childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            int num;
            if (true)
            {
                num = 0;
                goto IL_81;
            }
        IL_0C:
            DependencyObject child = VisualTreeHelper.GetChild(obj, num);
            bool arg_D3_0 = child == null || !(child is childItem);
            bool flag;
            bool expr_DA;
            do
            {
                if (7 != 0)
                {
                    flag = arg_D3_0;
                }
                expr_DA = (arg_D3_0 = flag);
            }
            while (false);
            childItem result;
            if (!expr_DA)
            {
                if (3 != 0)
                {
                    result = (childItem)((object)child);
                    goto IL_A0;
                }
            }
            else
            {
                childItem childItem1 = this.FindVisualChild<childItem>(child);
                flag = (childItem1 == null);
                if (!flag)
                {
                    result = childItem1;
                    goto IL_A0;
                }
                if (false)
                {
                    goto IL_81;
                }
            }
            int arg_80_0;
            int expr_7A = arg_80_0 = num;
            if (5 != 0)
            {
                arg_80_0 = expr_7A + 1;
            }
            num = arg_80_0;
        IL_81:
            flag = (num < VisualTreeHelper.GetChildrenCount(obj));
        IL_8C:
            if (flag)
            {
                goto IL_0C;
            }
            result = default(childItem);
        IL_A0:
            if (!false)
            {
                return result;
            }
            goto IL_8C;
        }

        private void BackgroundImageOtherFormats(string selectedBGFileName)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(selectedBGFileName);
            bitmapImage.EndInit();
            while (true)
            {
            IL_36:
                this.originalWidth = bitmapImage.PixelWidth;
                while (true)
                {
                    this.originalHeight = bitmapImage.PixelHeight;
                    this.sourcepath = selectedBGFileName;
                    while (true)
                    {
                        this.savepath = LoginUser.DigiFolderPath;
                        int num = this.savepath.IndexOf("DigiImages");
                        bool flag;
                        if (!false)
                        {
                            flag = (num == -1);
                        }
                        if (5 != 0)
                        {
                            if (!flag)
                            {
                                goto IL_7F;
                            }
                        IL_95:
                            this.CreateThumbnailsFolder();
                            if (false)
                            {
                                goto IL_36;
                            }
                            this.Convert6by8();
                            if (2 == 0)
                            {
                                break;
                            }
                            this.Convert4by6();
                            if (!false)
                            {
                                this.Convert5by7();
                                this.Convert3by3();
                                this.Convert8by10();
                                if (3 != 0)
                                {
                                    return;
                                }
                                continue;
                            }
                        IL_7F:
                            this.savepath = this.savepath.Remove(num - 1);
                            goto IL_95;
                        }
                    }
                }
            }
        }

        private void Convert6by8()
        {
            if (false || -1 != 0)
            {
                this.ProductTypeId = 1;
            }
            this.saveFolderPath = Path.Combine(this.savepath, "DigiImages", "BG", "6x8");
            if (!Directory.Exists(this.saveFolderPath))
            {
                Directory.CreateDirectory(this.saveFolderPath);
            }
            this.ResizeWPFImage(this.sourcepath, this.saveFolderPath);
            this.saveFolderPath = null;
        }

        private void Convert4by6()
        {
            if (false || -1 != 0)
            {
                this.ProductTypeId = 2;
            }
            this.saveFolderPath = Path.Combine(this.savepath, "DigiImages", "BG", "4x6");
            if (!Directory.Exists(this.saveFolderPath))
            {
                Directory.CreateDirectory(this.saveFolderPath);
            }
            this.ResizeWPFImage(this.sourcepath, this.saveFolderPath);
            this.saveFolderPath = null;
        }

        private void Convert5by7()
        {
            if (false || -1 != 0)
            {
                this.ProductTypeId = 3;
            }
            this.saveFolderPath = Path.Combine(this.savepath, "DigiImages", "BG", "5x7");
            if (!Directory.Exists(this.saveFolderPath))
            {
                Directory.CreateDirectory(this.saveFolderPath);
            }
            this.ResizeWPFImage(this.sourcepath, this.saveFolderPath);
            this.saveFolderPath = null;
        }

        private void Convert3by3()
        {
            if (false || -1 != 0)
            {
                this.ProductTypeId = 4;
            }
            this.saveFolderPath = Path.Combine(this.savepath, "DigiImages", "BG", "3x3");
            if (!Directory.Exists(this.saveFolderPath))
            {
                Directory.CreateDirectory(this.saveFolderPath);
            }
            this.ResizeWPFImage(this.sourcepath, this.saveFolderPath);
            this.saveFolderPath = null;
        }

        private void Convert8by10()
        {
            if (false || -1 != 0)
            {
                this.ProductTypeId = 5;
            }
            this.saveFolderPath = Path.Combine(this.savepath, "DigiImages", "BG", "8x10");
            if (!Directory.Exists(this.saveFolderPath))
            {
                Directory.CreateDirectory(this.saveFolderPath);
            }
            this.ResizeWPFImage(this.sourcepath, this.saveFolderPath);
            this.saveFolderPath = null;
        }

        private void CreateThumbnailsFolder()
        {
            this.saveFolderPath = Path.Combine(this.savepath, "DigiImages", "BG", "Thumbnails");
            if (!Directory.Exists(this.saveFolderPath))
            {
                Directory.CreateDirectory(this.saveFolderPath);
            }
            this.saveFolderPath = null;
        }

        private void ResizeWPFImage(string sourceImage, string saveToPath)
        {
            BitmapImage bitmapImage = new BitmapImage();
            BitmapImage bitmapImage2 = new BitmapImage();
            try
            {
                using (FileStream fileStream = File.OpenRead(sourceImage.ToString()))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    memoryStream.Seek(0L, SeekOrigin.Begin);
                    fileStream.Close();
                    bitmapImage.BeginInit();
                    bitmapImage.StreamSource = memoryStream;
                    bitmapImage.EndInit();
                    bitmapImage.Freeze();
                    double arg_327_0;
                    double num;
                    if (this.ProductTypeId != 1)
                    {
                        if (this.ProductTypeId != 2)
                        {
                            int arg_338_0;
                            bool expr_24C = (arg_338_0 = ((this.ProductTypeId == 3) ? 1 : 0)) != 0;
                            bool flag;
                            if (!false)
                            {
                                flag = !expr_24C;
                                if (4 == 0)
                                {
                                    goto IL_33F;
                                }
                                if (!flag)
                                {
                                    if (this.originalWidth < this.originalHeight)
                                    {
                                        memoryStream.Seek(0L, SeekOrigin.Begin);
                                        bitmapImage2.BeginInit();
                                        bitmapImage2.StreamSource = memoryStream;
                                        bitmapImage2.DecodePixelWidth = 1500;
                                        bitmapImage2.DecodePixelHeight = 2100;
                                        bitmapImage2.EndInit();
                                        if (!false)
                                        {
                                            bitmapImage2.Freeze();
                                            arg_327_0 = (double)bitmapImage2.PixelWidth;
                                            goto IL_320;
                                        }
                                    }
                                    memoryStream.Seek(0L, SeekOrigin.Begin);
                                    bitmapImage2.BeginInit();
                                    bitmapImage2.StreamSource = memoryStream;
                                    bitmapImage2.DecodePixelWidth = 2100;
                                    bitmapImage2.DecodePixelHeight = 1500;
                                    bitmapImage2.EndInit();
                                    bitmapImage2.Freeze();
                                    num = (double)bitmapImage2.PixelWidth / (double)bitmapImage2.PixelHeight;
                                    goto IL_32B;
                                }
                                arg_338_0 = this.ProductTypeId;
                            }
                            flag = (arg_338_0 != 4);
                        IL_33F:
                            if (!flag)
                            {
                                memoryStream.Seek(0L, SeekOrigin.Begin);
                                bitmapImage2.BeginInit();
                                bitmapImage2.StreamSource = memoryStream;
                                bitmapImage2.DecodePixelWidth = 900;
                                bitmapImage2.DecodePixelHeight = 900;
                                bitmapImage2.EndInit();
                                if (7 != 0)
                                {
                                    bitmapImage2.Freeze();
                                    num = (double)bitmapImage2.PixelWidth / (double)bitmapImage2.PixelHeight;
                                    goto IL_47D;
                                }
                            }
                            else
                            {
                                if (this.ProductTypeId != 5)
                                {
                                    goto IL_47D;
                                }
                                if (this.originalWidth >= this.originalHeight)
                                {
                                    memoryStream.Seek(0L, SeekOrigin.Begin);
                                    bitmapImage2.BeginInit();
                                    bitmapImage2.StreamSource = memoryStream;
                                    bitmapImage2.DecodePixelWidth = 3000;
                                    bitmapImage2.DecodePixelHeight = 2400;
                                    bitmapImage2.EndInit();
                                    bitmapImage2.Freeze();
                                    num = (double)bitmapImage2.PixelWidth / (double)bitmapImage2.PixelHeight;
                                    if (6 != 0)
                                    {
                                        goto IL_47C;
                                    }
                                    goto IL_1D1;
                                }
                                else
                                {
                                    memoryStream.Seek(0L, SeekOrigin.Begin);
                                    bitmapImage2.BeginInit();
                                }
                            }
                            bitmapImage2.StreamSource = memoryStream;
                            bitmapImage2.DecodePixelWidth = 2400;
                            goto IL_44F;
                        }
                        if (this.originalWidth >= this.originalHeight)
                        {
                            memoryStream.Seek(0L, SeekOrigin.Begin);
                            bitmapImage2.BeginInit();
                            if (false)
                            {
                                goto IL_47C;
                            }
                            bitmapImage2.StreamSource = memoryStream;
                            bitmapImage2.DecodePixelWidth = 1800;
                            bitmapImage2.DecodePixelHeight = 1200;
                            bitmapImage2.EndInit();
                            bitmapImage2.Freeze();
                        }
                        else
                        {
                            memoryStream.Seek(0L, SeekOrigin.Begin);
                            bitmapImage2.BeginInit();
                            bitmapImage2.StreamSource = memoryStream;
                            bitmapImage2.DecodePixelWidth = 1200;
                            bitmapImage2.DecodePixelHeight = 1800;
                            if (!false)
                            {
                                bitmapImage2.EndInit();
                                bitmapImage2.Freeze();
                                num = (double)bitmapImage2.PixelHeight / (double)bitmapImage2.PixelWidth;
                                goto IL_23F;
                            }
                            goto IL_A3;
                        }
                    IL_1D1:
                        num = (double)bitmapImage2.PixelWidth / (double)bitmapImage2.PixelHeight;
                    IL_23F:
                        goto IL_47D;
                    }
                    if (this.originalWidth < this.originalHeight)
                    {
                        memoryStream.Seek(0L, SeekOrigin.Begin);
                        bitmapImage2.BeginInit();
                        if (false)
                        {
                            goto IL_44F;
                        }
                        bitmapImage2.StreamSource = memoryStream;
                        bitmapImage2.DecodePixelWidth = 1800;
                        bitmapImage2.DecodePixelHeight = 2400;
                        bitmapImage2.EndInit();
                        bitmapImage2.Freeze();
                        double expr_14F = arg_327_0 = (double)bitmapImage2.PixelHeight / (double)bitmapImage2.PixelWidth;
                        if (5 != 0)
                        {
                            num = expr_14F;
                            goto IL_159;
                        }
                        goto IL_320;
                    }
                IL_A3:
                    memoryStream.Seek(0L, SeekOrigin.Begin);
                    bitmapImage2.BeginInit();
                    bitmapImage2.StreamSource = memoryStream;
                    bitmapImage2.DecodePixelWidth = 2400;
                    bitmapImage2.DecodePixelHeight = 1800;
                    bitmapImage2.EndInit();
                    bitmapImage2.Freeze();
                    num = (double)bitmapImage2.PixelWidth / (double)bitmapImage2.PixelHeight;
                IL_159:
                    goto IL_47D;
                IL_320:
                    num = arg_327_0 / (double)bitmapImage2.PixelHeight;
                IL_32B:
                    goto IL_47D;
                IL_44F:
                    bitmapImage2.DecodePixelHeight = 3000;
                    bitmapImage2.EndInit();
                    bitmapImage2.Freeze();
                    num = (double)bitmapImage2.PixelHeight / (double)bitmapImage2.PixelWidth;
                IL_47C:
                IL_47D:
                    bitmapImage2.Freeze();
                    fileStream.Close();
                }
                using (FileStream fileStream2 = new FileStream(saveToPath + "\\" + this.backgoundname, FileMode.Create, FileAccess.ReadWrite))
                {
                    new JpegBitmapEncoder
                    {
                        QualityLevel = 94,
                        Frames =
                        {
                            BitmapFrame.Create(bitmapImage2)
                        }
                    }.Save(fileStream2);
                    fileStream2.Close();
                }
                bitmapImage2 = null;
            }
            catch (Exception var_7_531)
            {
            }
            finally
            {
                bitmapImage2 = null;
            }
        }

        private void btnSaveSubStore_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = this.cmbSelectSubstore.SelectedValue != null;
                if (!flag)
                {
                    System.Windows.MessageBox.Show("Select site name");
                }
                else
                {
                    string currentDirectory = Environment.CurrentDirectory;
                    flag = !File.Exists(currentDirectory + "\\ss.dat");
                    if (!flag)
                    {
                        File.Delete(currentDirectory + "\\ss.dat");
                        if (!false)
                        {
                        }
                    }
                    StreamWriter streamWriter = new StreamWriter(File.Open(currentDirectory + "\\ss.dat", FileMode.Create));
                    try
                    {
                        string text = "";
                        IEnumerator<SelectedSubStores> enumerator = (from t in this.lstSelectedSubstore
                                                                     where t.Isselected
                                                                     select t).GetEnumerator();
                        try
                        {
                            while (true)
                            {
                                flag = enumerator.MoveNext();
                                if (!flag)
                                {
                                    break;
                                }
                                SelectedSubStores current;
                                if (!false)
                                {
                                    current = enumerator.Current;
                                }
                                do
                                {
                                    text = text + "," + current.SubStoreId.ToString();
                                }
                                while (!true);
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
                        LoginUser.DefaultSubstores = this.cmbSelectSubstore.SelectedValue.ToString() + text;
                        LoginUser.SubStoreId = this.cmbSelectSubstore.SelectedValue.ToInt32(false);
                        LoginUser.SubstoreName = new StoreSubStoreDataBusniess().GetSubstoreNameById(LoginUser.SubStoreId);
                        //streamWriter.Write(DigiPhoto.CryptorEngine.Encrypt(this.cmbSelectSubstore.SelectedValue.ToString() + text, true));
                        //streamWriter.Close();
                        while (true)
                        {
                            System.Windows.MessageBox.Show("Substore info saved successfully");
                            string receiptPrinterPath = LoginUser.ReceiptPrinterPath;
                            flag = string.IsNullOrEmpty(receiptPrinterPath);
                            while (true)
                            {
                                if (!flag)
                                {
                                    LoginUser.ReceiptPrinterPath = receiptPrinterPath;
                                }
                                else
                                {
                                    LoginUser.ReceiptPrinterPath = "0";
                                }
                                this.cmbReceiptPrinter.SelectedValue = LoginUser.ReceiptPrinterPath;
                                if (!false)
                                {
                                    string groupValue = LoginUser.GroupValue;
                                    flag = string.IsNullOrEmpty(groupValue);
                                    if (!flag)
                                    {
                                        LoginUser.GroupValue = groupValue;
                                    }
                                    else
                                    {
                                        LoginUser.GroupValue = "0";
                                    }
                                IL_1FB:
                                    this.GetConfigData();
                                    this.FillOnlineTabInfo();
                                    this.GetNewConfigData();
                                    this.FillLocationCombo();
                                    RobotImageLoader.GroupImages = new List<LstMyItems>();
                                    RobotImageLoader.PrintImages = new List<LstMyItems>();
                                    App.DataSyncServiceURl = string.Empty;
                                    if (8 != 0)
                                    {
                                        SearchByPhoto searchWindow = Configuration.GetSearchWindow();
                                        flag = (searchWindow == null);
                                        if (!flag)
                                        {
                                            searchWindow.LoadSubStore();
                                        }
                                        try
                                        {
                                            ServicePosInfoBusiness servicePosInfoBusiness = new ServicePosInfoBusiness();
                                            ImixPOSDetail imixPOSDetail = new ImixPOSDetail();
                                            imixPOSDetail.CreatedBy = "webusers";
                                            imixPOSDetail.IsStart = true;
                                            imixPOSDetail.SyncCode = "";
                                            do
                                            {
                                                imixPOSDetail.SubStoreID = (long)this.cmbSelectSubstore.SelectedValue.ToInt32(false);
                                            }
                                            while (false);
                                            imixPOSDetail.ImixPOSDetailID = 0L;
                                            imixPOSDetail.MacAddress = this.getMAcAddress();
                                            servicePosInfoBusiness.InsertImixPosBusiness(imixPOSDetail);
                                        }
                                        catch (Exception ex)
                                        {
                                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
                                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                                        }
                                        if (7 != 0)
                                        {
                                            goto Block_14;
                                        }
                                        continue;
                                    }
                                    goto IL_1FB;
                                }
                                break;
                            }
                        }
                    Block_14:;
                    }
                    finally
                    {
                        flag = (streamWriter == null);
                        do
                        {
                            if (!flag)
                            {
                                ((IDisposable)streamWriter).Dispose();
                            }
                        }
                        while (false);
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        public string getMAcAddress()
        {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
            IEnumerable<ManagementObject> source = managementObjectSearcher.Get().Cast<ManagementObject>();
            return (from o in source
                    orderby o["IPConnectionMetric"]
                    select o["MACAddress"].ToString()).FirstOrDefault<string>();
        }

        private static SearchByPhoto GetSearchWindow()
        {
            SearchByPhoto result;
            if (2 != 0)
            {
                if (-1 != 0)
                {
                    SearchByPhoto expr_61 = (from Window wnd in System.Windows.Application.Current.Windows
                                             where wnd.Title == "Search"
                                             select wnd).Cast<SearchByPhoto>().FirstOrDefault<SearchByPhoto>();
                    SearchByPhoto searchByPhoto;
                    if (4 != 0)
                    {
                        searchByPhoto = expr_61;
                    }
                    result = searchByPhoto;
                }
            }
            return result;
        }

        private void FillSubstore()
        {
            try
            {
                this.lstSelectedSubstore = new List<SelectedSubStores>();
                List<SubStoresInfo> substoreData = new StoreSubStoreDataBusniess().GetSubstoreData();
                if (3 != 0)
                {
                }
                foreach (SubStoresInfo current in substoreData)
                {
                    while (7 != 0)
                    {
                        SelectedSubStores selectedSubStores = new SelectedSubStores();
                        selectedSubStores.SubStoreId = current.DG_SubStore_pkey;
                        if (!false)
                        {
                            selectedSubStores.SubStoreName = current.DG_SubStore_Name;
                        }
                        selectedSubStores.Isselected = false;
                        if (-1 != 0)
                        {
                            if (!false)
                            {
                                this.lstSelectedSubstore.Add(selectedSubStores);
                                if (8 == 0)
                                {
                                    continue;
                                }
                            }
                            break;
                        }
                        break;
                    }
                }
                CommonUtility.BindCombo<SubStoresInfo>(this.cmbSelectSubstore, substoreData, "DG_SubStore_Name", "DG_SubStore_pkey");
                this.cmbSelectSubstore.SelectedValue = substoreData.FirstOrDefault<SubStoresInfo>().DG_SubStore_pkey.ToString();
                this.dgrdLocations.ItemsSource = this.lstSelectedSubstore;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            this.ReadSubStore();
        }

        private void ReadSubStore()
        {
            try
            {
                string currentDirectory = Environment.CurrentDirectory;
                bool flag = !File.Exists(currentDirectory + "\\ss.dat");
                while (!flag)
                {
                    StreamReader streamReader = new StreamReader(currentDirectory + "\\ss.dat");
                    try
                    {
                        string cipherString = streamReader.ReadLine();
                        string text = "test";// DigiPhoto.CryptorEngine.Decrypt(cipherString, true);
                        LoginUser.SubStoreId = text.Split(new char[]
                        {
                            ','
                        })[0].ToInt32(false);
                        LoginUser.DefaultSubstores = text;
                        List<string> source = new List<string>();
                        source = text.Split(new char[]
                        {
                            ','
                        }).ToList<string>();
                        this.cmbSelectSubstore.SelectedValue = text.Split(new char[]
                        {
                            ','
                        })[0];
                        List<SelectedSubStores>.Enumerator enumerator = this.lstSelectedSubstore.GetEnumerator();
                        try
                        {
                            while (true)
                            {
                                flag = enumerator.MoveNext();
                                if (!flag)
                                {
                                    break;
                                }
                                SelectedSubStores item = enumerator.Current;
                                IEnumerable<string> source2 = source.Where(delegate (string t)
                                {
                                    bool arg_29_0;
                                    bool flag2;
                                    while (true)
                                    {
                                        if (!false)
                                        {
                                            string arg_48_0 = t.ToString();
                                            int expr_37 = item.SubStoreId;
                                            int num;
                                            if (5 != 0)
                                            {
                                                num = expr_37;
                                            }
                                            bool expr_48 = arg_29_0 = (arg_48_0 == num.ToString());
                                            if (-1 == 0)
                                            {
                                                return arg_29_0;
                                            }
                                            flag2 = expr_48;
                                        }
                                        while (!false)
                                        {
                                            if (2 != 0)
                                            {
                                                goto Block_3;
                                            }
                                        }
                                    }
                                Block_3:
                                    arg_29_0 = flag2;
                                    return arg_29_0;
                                });
                                flag = (source2.Count<string>() <= 0);
                                if (!flag)
                                {
                                    if (7 != 0)
                                    {
                                    }
                                    item.Isselected = true;
                                }
                            }
                        }
                        finally
                        {
                            if (4 != 0)
                            {
                                if (!false)
                                {
                                    ((IDisposable)enumerator).Dispose();
                                }
                            }
                        }
                    }
                    finally
                    {
                        flag = (streamReader == null);
                        if (!flag)
                        {
                            ((IDisposable)streamReader).Dispose();
                        }
                    }
                    if (8 != 0)
                    {
                        break;
                    }
                }
            }
            catch (Exception serviceException)
            {
                if (5 != 0)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
            if (!false)
            {
            }
        }

        private void txtChromaTolerance_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            int arg_191_0;
            if (!char.IsLetter((char)KeyInterop.VirtualKeyFromKey(e.Key)))
            {
                arg_191_0 = (ushort)KeyInterop.VirtualKeyFromKey(e.Key);
                goto IL_29;
            }
            goto IL_5D;
            int arg_5F_0;
            string text = "0";
            while (true)
            {
            IL_5E:
                if (arg_5F_0 == 0)
                {
                    e.Handled = true;
                }
                if (false)
                {
                    break;
                }
                text = this.txtChromaTolerance.Text;
                while (true)
                {
                    bool expr_8F = (arg_5F_0 = ((this.txtChromaTolerance.Text != "") ? 1 : 0)) != 0;
                    if (-1 == 0)
                    {
                        break;
                    }
                    if (!expr_8F)
                    {
                        return;
                    }
                    bool flag = text[0] != '.';
                    if (3 != 0)
                    {
                        if (flag)
                        {
                            goto IL_D3;
                        }
                        if (true)
                        {
                            text = "0.";
                            this.txtChromaTolerance.Text = "0.";
                            goto IL_D1;
                        }
                    IL_10E:
                        if (!false)
                        {
                            goto Block_13;
                        }
                        continue;
                    IL_D3:
                        if (!(decimal.Parse(text) < 0m))
                        {
                            goto IL_10E;
                        }
                        System.Windows.MessageBox.Show("This Value should be a decimal number between 0 and 2");
                        this.txtChromaTolerance.Text = "";
                        if (!false)
                        {
                            goto Block_12;
                        }
                    IL_D1:
                        goto IL_D3;
                    }
                    goto IL_133;
                }
            }
        Block_12:
            return;
        Block_13:
            bool expr_120 = (arg_191_0 = ((Convert.ToInt16(text) > 2) ? 1 : 0)) != 0 ? true : false;
            if (4 == 0)
            {
                goto IL_29;
            }
            if (!expr_120)
            {
                return;
            }
        IL_133:
            System.Windows.MessageBox.Show("This Value should be a decimal number between 0 and 2");
            this.txtChromaTolerance.Text = "";
            return;
        IL_29:
            if (!char.IsSymbol((char)arg_191_0) && !char.IsWhiteSpace((char)KeyInterop.VirtualKeyFromKey(e.Key)))
            {
                arg_5F_0 = ((!char.IsPunctuation((char)KeyInterop.VirtualKeyFromKey(e.Key))) ? 1 : 0);
                //goto IL_5E;
            }
        IL_5D:
            arg_5F_0 = 0;
            //goto IL_5E;
        }

        private void cmbChromaColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = string.Empty;
            if (false)
            {
                goto IL_120;
            }
            bool flag = !(this._isDefaultColorSeletedValue != ((ComboBoxItem)this.cmbChromaColor.SelectedItem).Content.ToString());
            if (!flag)
            {
                this._isDefaultColorCode = true;
            }
            flag = (this.cmbChromaColor.SelectedIndex != 0);
        IL_66:
            bool arg_67_0 = flag;
        IL_67:
            bool arg_139_0;
            if (!arg_67_0)
            {
                this.txtChromaTolerance.Text = "1.0";
                text = "#00FF00";
                if (!false)
                {
                    goto IL_124;
                }
                goto IL_13D;
            }
            else
            {
                flag = (this.cmbChromaColor.SelectedIndex != 1);
                if (-1 != 0)
                {
                    if (!flag)
                    {
                        this.txtChromaTolerance.Text = "0.4";
                        text = "#FF0000";
                        goto IL_124;
                    }
                    flag = (this.cmbChromaColor.SelectedIndex != 2);
                }
                if (!flag)
                {
                    this.txtChromaTolerance.Text = "0.5";
                }
                else
                {
                    flag = (this.cmbChromaColor.SelectedIndex != 3);
                    bool expr_102 = arg_139_0 = flag;
                    if (false)
                    {
                        goto IL_139;
                    }
                    if (!expr_102)
                    {
                        this.txtChromaTolerance.Text = "0.15";
                        text = "#A9A9A9";
                        goto IL_120;
                    }
                    goto IL_124;
                }
            }
        IL_E7:
            text = "#0080FF";
            goto IL_124;
        IL_120:
            if (false)
            {
                goto IL_E7;
            }
        IL_124:
            if (4 == 0)
            {
                goto IL_66;
            }
            bool expr_12B = arg_67_0 = this._isDefaultColorCode;
            if (false)
            {
                goto IL_67;
            }
            arg_139_0 = !expr_12B;
        IL_139:
            flag = arg_139_0;
            if (flag)
            {
                goto IL_14C;
            }
        IL_13D:
            this.txtConfigColorCode.Text = text;
        IL_14C:
            this._isDefaultColorCode = true;
        }

        private void btndefault_Click(object sender, RoutedEventArgs e)
        {
            this.GrdSharpens.Visibility = Visibility.Collapsed;
            if (false)
            {
                goto IL_BE;
            }
        IL_18:
            this.brightVal.Focus();
        IL_28:
            this.Flower.Visibility = Visibility.Collapsed;
        IL_38:
            this.brightVal.Value = -0.05;
            this.contrastVal.Value = 1.3;
            this.sharpVal.Value = 0.05;
            if (false)
            {
                goto IL_28;
            }
            this.txtbright.Text = "-0.05";
        IL_93:
            if (3 == 0)
            {
                goto IL_38;
            }
            if (8 == 0)
            {
                goto IL_18;
            }
            this.txtcontrasts.Text = "1.3";
            this.txtsharp.Text = "0.05";
        IL_BE:
            if (4 != 0)
            {
                return;
            }
            goto IL_93;
        }

        private void btnSaveDigimagic_click(object sender, RoutedEventArgs e)
        {
            bool arg_7B_0;
            int arg_7B_1;
            bool flag;
            while (true)
            {
                int expr_AA = (arg_7B_0 = string.IsNullOrEmpty(this.txtbright.Text)) ? 1 : 0;
                int expr_16 = arg_7B_1 = 0;
                if (expr_16 != 0)
                {
                    goto IL_7B;
                }
                if (expr_AA != expr_16)
                {
                    break;
                }
                flag = !string.IsNullOrEmpty(this.txtcontrasts.Text);
                if (flag)
                {
                    goto IL_67;
                }
                if (!false)
                {
                    goto Block_3;
                }
            }
            System.Windows.MessageBox.Show("Please enter the value of brightness");
            return;
        Block_3:
            System.Windows.MessageBox.Show("Please enter the value of contrast");
            if (3 == 0)
            {
                goto IL_7E;
            }
            if (!false)
            {
                return;
            }
            return;
        IL_67:
            if (false)
            {
                return;
            }
            arg_7B_0 = string.IsNullOrEmpty(this.txtsharp.Text);
            arg_7B_1 = 0;
        IL_7B:
            flag = ((arg_7B_0 ? 1 : 0) == arg_7B_1);
        IL_7E:
            if (!flag)
            {
                System.Windows.MessageBox.Show("Please enter the value of sharpness");
            }
            else if (!false)
            {
                this.setDigimagicbrightness();
            }
        }

        private void txtslider_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Configuration.IsTextAllowed(e.Text);
        }

        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            bool arg_5A_0;
            bool expr_8B = arg_5A_0 = e.DataObject.GetDataPresent(typeof(string));
            if (5 != 0)
            {
                bool flag = !expr_8B;
                bool arg_27_0 = flag;
                while (!arg_27_0)
                {
                    string text;
                    do
                    {
                        text = (string)e.DataObject.GetData(typeof(string));
                    }
                    while (false);
                    bool expr_4D = arg_27_0 = Configuration.IsTextAllowed(text);
                    if (!false)
                    {
                        flag = expr_4D;
                    IL_56:
                        if (!false)
                        {
                            arg_5A_0 = flag;
                            goto IL_5A;
                        }
                        return;
                    }
                }
                e.CancelCommand();
                if (5 != 0)
                {
                    return;
                }
                //goto IL_56;
            }
        IL_5A:
            if (!arg_5A_0)
            {
                e.CancelCommand();
            }
        }

        private static bool IsTextAllowed(string text)
        {
            bool arg_29_0;
            bool flag;
            while (true)
            {
                while (!false)
                {
                    Regex expr_2A = new Regex("[^0-9.-]+");
                    Regex regex;
                    if (4 != 0)
                    {
                        regex = expr_2A;
                    }
                    while (true)
                    {
                        bool expr_16 = arg_29_0 = !regex.IsMatch(text);
                        if (-1 == 0)
                        {
                            return arg_29_0;
                        }
                        if (5 != 0)
                        {
                            flag = expr_16;
                        }
                        if (false)
                        {
                            break;
                        }
                        if (2 != 0)
                        {
                            goto Block_3;
                        }
                    }
                }
            }
        Block_3:
            arg_29_0 = flag;
            return arg_29_0;
        }

        private void setDigimagicbrightness()
        {
            double arg_10D_0;
            double expr_01 = arg_10D_0 = 0.0;
            if (6 == 0)
            {
                goto IL_10D;
            }
            double num = expr_01;
            double arg_245_0 = 0.0;
            double value;
            double value2;
            double expr_31;
            do
            {
                value = arg_245_0;
                value2 = 0.0;
                expr_31 = (arg_245_0 = 0.0);
            }
            while (5 == 0);
            double value3 = expr_31;
            int arg_261_0 = LoginUser.SubStoreId;
            bool flag = !double.TryParse(this.txtbright.Text, out num);
            bool arg_FA_0;
            bool expr_67 = arg_FA_0 = flag;
            if (8 == 0)
            {
                goto IL_FA;
            }
            if (expr_67)
            {
                System.Windows.MessageBox.Show("Please enter correct value");
                return;
            }
            value = double.Parse(this.txtbright.Text);
            if (false)
            {
                goto IL_1A4;
            }
            flag = !double.TryParse(this.txtcontrasts.Text, out num);
            if (-1 == 0)
            {
                goto IL_12C;
            }
            if (flag)
            {
                System.Windows.MessageBox.Show("Please enter correct value");
                return;
            }
            value2 = double.Parse(this.txtcontrasts.Text);
        IL_E1:
            flag = !double.TryParse(this.txtsharp.Text, out num);
            arg_FA_0 = flag;
        IL_FA:
            if (arg_FA_0)
            {
                if (-1 != 0)
                {
                    System.Windows.MessageBox.Show("Please enter correct value");
                }
                return;
            }
            arg_10D_0 = double.Parse(this.txtsharp.Text);
        IL_10D:
            value3 = arg_10D_0;
            List<iMIXConfigurationInfo> list = new List<iMIXConfigurationInfo>();
        IL_12C:
            iMIXConfigurationInfo iMIXConfigurationInfo = new iMIXConfigurationInfo();
            iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
            iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.DigimagicBrightness);
            iMIXConfigurationInfo.ConfigurationValue = Convert.ToString(value);
            list.Add(iMIXConfigurationInfo);
            iMIXConfigurationInfo = new iMIXConfigurationInfo();
            iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
            iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.DigimagicContrast);
            iMIXConfigurationInfo.ConfigurationValue = Convert.ToString(value2);
        IL_1A4:
            list.Add(iMIXConfigurationInfo);
            iMIXConfigurationInfo = new iMIXConfigurationInfo();
            iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
            iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.DigimagicSharpen);
            iMIXConfigurationInfo.ConfigurationValue = Convert.ToString(value3);
            list.Add(iMIXConfigurationInfo);
            ConfigBusiness configBusiness = new ConfigBusiness();
            bool flag2 = configBusiness.SaveUpdateNewConfig(list);
            if (flag2)
            {
                if (4 == 0)
                {
                    goto IL_E1;
                }
                System.Windows.MessageBox.Show("Digimagic effects updated successfully!", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                System.Windows.MessageBox.Show("There was some error updating the data!", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Hand);
            }
        }

        private void sharpVal_GotFocus(object sender, RoutedEventArgs e)
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
            this.GrdSharpens.Visibility = Visibility.Visible;
        IL_11:
            if (!false)
            {
                this.Flower.Visibility = Visibility.Visible;
            }
        IL_20:
            if (!false)
            {
                return;
            }
            goto IL_04;
        }

        private void contrastVal_GotFocus(object sender, RoutedEventArgs e)
        {
            this.GrdSharpens.Visibility = Visibility.Collapsed;
        }

        private void brightVal_GotFocus(object sender, RoutedEventArgs e)
        {
            this.GrdSharpens.Visibility = Visibility.Collapsed;
        }

        private void sharpVal_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //while (!false)
            //{
            //    this.GrdSharpens.Visibility = Visibility.Visible;
            //    ShEffect shEffect = new ShEffect();
            //    if (7 != 0)
            //    {
            //        if (false)
            //        {
            //            goto IL_4A;
            //        }
            //        this.GrdSharpens.Visibility = Visibility.Visible;
            //        IL_46:
            //        if (5 == 0)
            //        {
            //            continue;
            //        }
            //        IL_4A:
            //        shEffect.PixelWidth = 0.0015;
            //        shEffect.PixelHeight = 0.0015;
            //        shEffect.Strength = this.sharpVal.Value;
            //        if (3 != 0)
            //        {
            //            this.Flower.Effect = shEffect;
            //            break;
            //        }
            //        goto IL_46;
            //    }
            //}
            //double value = this.sharpVal.Value;
        }

        private void btnSelectChromaKey_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog;
            if (!false)
            {
                Microsoft.Win32.OpenFileDialog expr_FB = new Microsoft.Win32.OpenFileDialog();
                if (8 != 0)
                {
                    openFileDialog = expr_FB;
                }
                openFileDialog.Multiselect = false;
            }

            openFileDialog.Filter = "Select Image|*.gif;*.png;|GIF|*.gif;*.GIF|PNG|*.png;*.PNG";
            if (openFileDialog.ShowDialog().Value)
            {
                try
                {
                    bool arg_87_0;
                    bool expr_5B = arg_87_0 = (openFileDialog.OpenFile() == null);
                    if (true)
                    {
                        bool flag = expr_5B;
                        int arg_64_0 = flag ? 1 : 0;
                        while (arg_64_0 == 0)
                        {
                            int expr_77 = arg_64_0 = Path.GetFileName(openFileDialog.FileName.ToString()).Count<char>();
                            if (!false)
                            {
                                flag = (expr_77 > 50);
                                arg_87_0 = flag;
                                goto IL_87;
                            }
                        }
                        goto IL_D1;
                    }
                IL_87:
                    if (!arg_87_0)
                    {
                        if (!false)
                        {
                            this.txtSelectedChromaKey.Text = openFileDialog.FileName.ToString();
                            this.ChromaKeyDisplayname = Path.GetFileName(openFileDialog.FileName);
                        }
                    }
                    else
                    {
                        while (!true)
                        {
                        }
                        System.Windows.MessageBox.Show("File name should not excced 50 characters.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                IL_D1:;
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                    if (4 != 0)
                    {
                    }
                }
            }
        }

        private void btnSaveSelectChromakey_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.CheckChromaKeyValidations())
                {
                    double arg_59_0 = 1;
                    int arg_21D_0;
                    while (!string.IsNullOrEmpty(TimeSpan.FromSeconds(arg_59_0).ToString()))
                    {
                        double expr_75 = arg_59_0 = 1;
                        if (!false)
                        {
                            long arg_9A_0;
                            long arg_A2_0 = arg_9A_0 = (long)TimeSpan.FromSeconds(expr_75).TotalSeconds;
                            long num;
                            if (!false)
                            {
                                //  IL_99:
                                num = arg_9A_0;
                                arg_A2_0 = num;
                            }
                            bool arg_A4_0 = arg_A2_0 > 1800L;
                            bool flag;
                            bool flag2;
                            string text;
                            while (true)
                            {
                                flag = arg_A4_0;
                                if (8 == 0)
                                {
                                    goto IL_1EF;
                                }
                                if (flag)
                                {
                                    goto IL_270;
                                }
                                flag2 = false;
                                Guid guid = Guid.NewGuid();
                                this.chromakeyName = Path.GetFileNameWithoutExtension(this.ChromaKeyDisplayname) + guid.ToString() + Path.GetExtension(this.ChromaKeyDisplayname);
                            IL_EB:
                                text = LoginUser.PhotoSWChromaKeyPath + this.chromakeyName;
                                string text2 = this.txtChromaKeyDescription.Text;
                                bool? isChecked = this.IsChromakeyActive.IsChecked;
                                flag = this.IsChromaKeyEdited;
                                if (false)
                                {
                                    goto IL_264;
                                }
                                if (!flag)
                                {
                                    if (!Directory.Exists(LoginUser.PhotoSWChromaKeyPath))
                                    {
                                        Directory.CreateDirectory(LoginUser.PhotoSWChromaKeyPath);
                                    }
                                    if (String.IsNullOrEmpty(this.hdnChromaKeyName.Text))
                                    {
                                        
                                        File.Copy(this.txtSelectedChromaKey.Text, text, true);
                                    }
                                    else
                                    {
                                        File.Copy(this.hdnChromaKeyName.Text, text, true);
                                    }






                                    flag2 = this.SaveChromaKeyDetails(this.ChromaKeyDisplayname, this.chromakeyName, text2, isChecked, this.IsChromaKeyEdited, num);
                                }
                                else
                                {
                                    string text3 = this.txtSelectedChromaKey.Text;
                                    flag = !File.Exists(text3);
                                    bool expr_199 = arg_A4_0 = flag;
                                    if (-1 == 0)
                                    {
                                        continue;
                                    }
                                    if (!expr_199)
                                    {
                                        File.Copy(text3, text, true);
                                        flag = !text3.Contains(LoginUser.PhotoSWChromaKeyPath);
                                        goto IL_1C0;
                                    }
                                    goto IL_1EF;
                                }
                            IL_20F:
                                if (!false)
                                {
                                    break;
                                }
                                goto IL_EB;
                            IL_207:
                                this.IsChromaKeyEdited = false;
                                goto IL_20F;
                            IL_1C0:
                                if (!flag)
                                {
                                    //string text3;
                                    //File.Delete(text3);
                                }
                                flag2 = this.SaveChromaKeyDetails(this.ChromaKeyDisplayname, this.chromakeyName, text2, isChecked, this.IsChromaKeyEdited, num);
                                goto IL_207;
                            IL_1EF:
                                if (!false)
                                {
                                    System.Windows.MessageBox.Show("File not found.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                                    goto IL_207;
                                }
                                goto IL_1C0;
                            }
                            flag = !flag2;
                            arg_21D_0 = (flag ? 1 : 0);
                            // IL_21D:
                            if (arg_21D_0 == 0)
                            {
                                this.CopyToAllSubstore(this.lstConfigurationInfo, text, "", "ChromaKey");
                                System.Windows.MessageBox.Show("ChromaKey saved successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                                // AuditLog.AddUserLog(LoginUser.UserId, 49, "Add/Edit Audio at ");
                                this.GetChromaKeyDetails();
                            }
                        IL_264:
                            this.ResetChromaKeyTemplateControls();
                            goto IL_285;
                        IL_270:
                            System.Windows.MessageBox.Show("ChromaKey length should not exceed 30 minutes.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        IL_285:
                            goto IL_29D;
                        }
                        // int expr_92 = arg_21D_0 = 0;
                        //if(expr_92 == 0)
                        //    {
                        //    long arg_9A_0 = (long)expr_92;
                        //    goto IL_99;
                        //    }
                        //goto IL_21D;
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Select Audio File.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            IL_29D:;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }
        private void btnCancelSelectChromakey_Click(object sender, RoutedEventArgs e)
        {
            this.ResetChromaKeyTemplateControls();
        }

        private void btnEditChromaKey_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                this.ChromaKeyId = (long)Convert.ToInt32(button.Tag);
                this.hdnChromaKey.Text = this.ChromaKeyId.ToString();


                ConfigBusiness configBusiness = new ConfigBusiness();
                ChromaKeyTemplateInfo chromaKeyTemplateInfo = configBusiness.GetChromaKeyInfosByID(this.ChromaKeyId);


                this.hdnChromaKeyName.Text = LoginUser.PhotoSWChromaKeyPath + chromaKeyTemplateInfo.Name;
                this.txtChromaKeyDescription.Text = chromaKeyTemplateInfo.Description;
                this.IsChromakeyActive.IsChecked = chromaKeyTemplateInfo.IsActive;
                //this.txtSelectedChromaKey.Text = LoginUser.PhotoSWChromaKeyPath + chromaKeyTemplateInfo.Name;

                this.txtSelectedChromaKey.Text = chromaKeyTemplateInfo.DisplayName;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool CheckChromaKeyValidations()
        {
            bool result;
            while (!true || this.txtSelectedChromaKey.Text == "")
            {
                if (7 != 0)
                {
                    bool expr_21 = false;
                    if (4 != 0)

                    {
                        result = expr_21;
                    }
                    if (!false && !false)

                    {
                    }
                    return result;
                }
            }
            result = true;
            return result;
        }

        private bool SaveChromaKeyDetails(string ChromaKeyDisplayname, string ChromakeyName, string strDescription, bool? IsActive, bool IsEdited, long ChromakeyLength)
        {
            bool result;
            try
            {
                //  AudioTemplateInfo audioTemplateInfo;
                ChromaKeyTemplateInfo chromaKeyTemplateInfo;
                if (3 != 0)
                {
                    IsActive = ((!IsActive.HasValue) ? new bool?(false) : IsActive);
                    chromaKeyTemplateInfo = new ChromaKeyTemplateInfo();
                    ChromaKeyTemplateInfo expr_130 = chromaKeyTemplateInfo;
                    if (5 != 0)
                    {
                        expr_130.DisplayName = ChromaKeyDisplayname;
                    }
                    if (false)
                    {
                        goto IL_FC;
                    }
                    chromaKeyTemplateInfo.Name = ChromakeyName;
                    if (false)
                    {
                        goto IL_A0;
                    }
                    chromaKeyTemplateInfo.IsActive = Convert.ToBoolean(IsActive);
                    if (3 == 0)
                    {
                        goto IL_97;
                    }
                    chromaKeyTemplateInfo.Description = strDescription;
                    chromaKeyTemplateInfo.ChromaLength = ChromakeyLength;
                    if (IsEdited)
                    {
                        chromaKeyTemplateInfo.CreatedBy = LoginUser.UserId;
                        chromaKeyTemplateInfo.CreatedOn = DateTime.Now;
                        chromaKeyTemplateInfo.ChromaTemplateId = this.audioId;
                        chromaKeyTemplateInfo.ModifiedBy = LoginUser.UserId;
                        chromaKeyTemplateInfo.ModifiedOn = DateTime.Now;
                        goto IL_ED;
                    }
                }
                chromaKeyTemplateInfo.CreatedBy = LoginUser.UserId;
                if (7 == 0)
                {
                    goto IL_ED;
                }
                chromaKeyTemplateInfo.CreatedOn = DateTime.Now;
            IL_97:
                chromaKeyTemplateInfo.ModifiedBy = 0;
            IL_A0:
                chromaKeyTemplateInfo.ModifiedOn = DateTime.Now;
            IL_ED:
                ConfigBusiness configBusiness = new ConfigBusiness();
                //   result = configBusiness.SaveUpdateAudioTemplate(chromaKeyTemplateInfo);
                if (String.IsNullOrEmpty(this.hdnChromaKey.Text))
                {
                    result = configBusiness.SaveUpdateChromaKeyTemplate(chromaKeyTemplateInfo);
                }
                else
                {
                    chromaKeyTemplateInfo.ChromaTemplateId = Convert.ToInt32(this.hdnChromaKey.Text);


                    result = configBusiness.SaveUpdateChromaKeyTemplate(chromaKeyTemplateInfo);
                }







            IL_FC:;
            }
            catch
            {
                result = false;
            }
            while (false)
            {
            }
            return result;
        }

        private void btnDeleteChromaKey_Click(object sender, RoutedEventArgs e)


        {
            try


            {
                while (true)


                {
                    System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                    this.ChromaKeyId = (long)Convert.ToInt32(button.Tag);
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete record?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    bool arg_4B_0 = messageBoxResult == MessageBoxResult.Yes;
                    if (!arg_4B_0)







                    {
                        break;
                    }


                    ConfigBusiness configBusiness = new ConfigBusiness();
                    ChromaKeyTemplateInfo ChromaKeyTemplateInfo = configBusiness.GetChromaKeyInfosByID(this.ChromaKeyId);
                    if (ChromaKeyTemplateInfo == null)
                    {
                        break;





                    }

                    if (!configBusiness.DeleteChromaKey(ChromaKeyTemplateInfo))


                    {
                        break;


                    }

                    this.GetChromaKeyDetails();

                    System.Windows.MessageBox.Show("Chroma deleted successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    this.ResetChromaKeyTemplateControls();
                    bool arg_AA_0 = AuditLog.AddUserLog(LoginUser.UserId, 49, "Chroma deleted at ");
                    break;







                }

            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }
        private void ResetChromaKeyTemplateControls()
        {
            while (true)
            {
                while (true)
                {
                    this.hdnChromaKey.Text = string.Empty;
                    this.hdnChromaKeyName.Text = string.Empty;
                    this.txtSelectedChromaKey.Text = "";
                    if (!false)
                    {
                        //this.txtAudioDescription.Text = "";
                        this.txtChromaKeyDescription.Text = "";

                        if (8 != 0)
                        {
                            //this.IsAudioActive.IsChecked = new bool?(false);
                            this.IsChromakeyActive.IsChecked = new bool?(false);

                        }
                        while (2 != 0)
                        {
                            if (6 == 0)
                            {
                                break;
                            }
                            if (!false)

                            {
                                goto Block_4;
                            }
                        }

                    }

                }
            }
        Block_4:
            this.audioId = 0L;

        }

        private void GetAudioDetails()
        {
            do

            {
                try
                {
                    List<AudioTemplateInfo> audioTemplateList;
                    if (!false)

                    {
                        ConfigBusiness configBusiness = new ConfigBusiness();
                        audioTemplateList = configBusiness.GetAudioTemplateList();
                    }







                    if (!false)
                    {
                        this.DGManageAudio.ItemsSource = audioTemplateList;
                    }



                    if (!false)
                    {
                    }



                }
                catch (Exception serviceException)





                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    do



                    {



                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (4 == 0);
                }

            }
            while (false);
        }
        private void GetChromaKeyDetails()
        {
            do

            {
                try
                {
                    List<ChromaKeyTemplateInfo> ChromaKeyTemplateInfo;
                    if (!false)

                    {
                        ConfigBusiness configBusiness = new ConfigBusiness();
                        ChromaKeyTemplateInfo = configBusiness.GetChromaKeyInfosData();

                    }







                    if (!false)
                    {
                        this.PSManageChromaKey.ItemsSource = ChromaKeyTemplateInfo;
                    }



                    if (!false)
                    {
                    }



                }
                catch (Exception serviceException)





                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    do


                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (4 == 0);
                }

            }
            while (false);



        }

        private void btnSelectAudio_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog;
            if (!false)



            {
                Microsoft.Win32.OpenFileDialog expr_FB = new Microsoft.Win32.OpenFileDialog();
                if (8 != 0)

                {
                    openFileDialog = expr_FB;

                }
                openFileDialog.Multiselect = false;


            }
            openFileDialog.Filter = "Select Audio|*.mp3;*.wav;*.wma;|MP3|*.mp3|WAV|*.wav|WMA|*.wma;";
            if (openFileDialog.ShowDialog().Value)
            {
                try
                {
                    bool arg_87_0;
                    bool expr_5B = arg_87_0 = (openFileDialog.OpenFile() == null);
                    if (true)

                    {
                        bool flag = expr_5B;
                        int arg_64_0 = flag ? 1 : 0;
                        while (arg_64_0 == 0)




                        {
                            int expr_77 = arg_64_0 = Path.GetFileName(openFileDialog.FileName.ToString()).Count<char>();
                            if (!false)



                            {
                                flag = (expr_77 > 50);
                                arg_87_0 = flag;
                                goto IL_87;



                            }

                        }
                        goto IL_D1;




                    }
                IL_87:
                    if (!arg_87_0)






                    {






                        if (!false)
                        {
                            this.txtSelectedAudio.Text = openFileDialog.FileName.ToString();
                            this.audioDisplayname = Path.GetFileName(openFileDialog.FileName);


                        }

                    }
                    else










                    {
                        while (!true)








































































                        {


                        }
                        System.Windows.MessageBox.Show("File name should not excced 50 characters.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);



                    }
                IL_D1:;




                }
                catch (Exception ex)





                {
                    System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);















                    if (4 != 0)











                    {

























                    }











                }







            }















































        }

        private void btnSaveSelectAudio_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (this.CheckAudioValidations())
                {
                    double arg_59_0 = 1;
                    int arg_21D_0;
                    while (!string.IsNullOrEmpty(TimeSpan.FromSeconds(arg_59_0).ToString()))
                    {
                        double expr_75 = arg_59_0 = 1;
                        if (!false)
                        {
                            long arg_9A_0;
                            long arg_A2_0 = arg_9A_0 = (long)TimeSpan.FromSeconds(expr_75).TotalSeconds;
                            long num;
                            if (!false)
                            {
                                //  IL_99:
                                num = arg_9A_0;
                                arg_A2_0 = num;
                            }
                            bool arg_A4_0 = arg_A2_0 > 1800L;
                            bool flag;
                            bool flag2;
                            string text;
                            while (true)
                            {
                                flag = arg_A4_0;
                                if (8 == 0)
                                {
                                    goto IL_1EF;
                                }
                                if (flag)
                                {
                                    goto IL_270;
                                }
                                flag2 = false;
                                Guid guid = Guid.NewGuid();
                                this.audioName = Path.GetFileNameWithoutExtension(this.audioDisplayname) + guid.ToString() + Path.GetExtension(this.audioDisplayname);
                            IL_EB:
                                text = LoginUser.DigiFolderAudioPath + this.audioName;
                                string text2 = this.txtAudioDescription.Text;
                                bool? isChecked = this.IsAudioActive.IsChecked;
                                flag = this.IsAudioEdited;
                                if (false)
                                {
                                    goto IL_264;
                                }
                                if (!flag)
                                {
                                    if (!Directory.Exists(LoginUser.DigiFolderAudioPath))
                                    {
                                        Directory.CreateDirectory(LoginUser.DigiFolderAudioPath);
                                    }
                                    File.Copy(this.txtSelectedChromaKey.Text, text, true);
                                    flag2 = this.SaveAudioDetails(this.audioDisplayname, this.audioName, text2, isChecked, this.IsAudioEdited, num);
                                }
                                else
                                {
                                    string text3 = this.txtSelectedChromaKey.Text;
                                    flag = !File.Exists(text3);
                                    bool expr_199 = arg_A4_0 = flag;
                                    if (-1 == 0)
                                    {
                                        continue;
                                    }
                                    if (!expr_199)
                                    {
                                        File.Copy(text3, text, true);
                                        flag = !text3.Contains(LoginUser.DigiFolderAudioPath);
                                        goto IL_1C0;
                                    }
                                    goto IL_1EF;
                                }
                            IL_20F:
                                if (!false)
                                {
                                    break;
                                }
                                goto IL_EB;
                            IL_207:
                                this.IsAudioEdited = false;
                                goto IL_20F;
                            IL_1C0:
                                if (!flag)
                                {
                                    //string text3;
                                    //File.Delete(text3);
                                }
                                flag2 = this.SaveAudioDetails(this.audioDisplayname, this.audioName, text2, isChecked, this.IsAudioEdited, num);
                                goto IL_207;
                            IL_1EF:
                                if (!false)
                                {
                                    System.Windows.MessageBox.Show("File not found.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                                    goto IL_207;
                                }
                                goto IL_1C0;
                            }
                            flag = !flag2;
                            arg_21D_0 = (flag ? 1 : 0);
                            // IL_21D:
                            if (arg_21D_0 == 0)
                            {
                                this.CopyToAllSubstore(this.lstConfigurationInfo, text, "", "Audio");
                                System.Windows.MessageBox.Show("Audio saved successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                                AuditLog.AddUserLog(LoginUser.UserId, 49, "Add/Edit Audio at ");
                                this.GetAudioDetails();
                            }
                        IL_264:
                            this.ResetAudioTemplateControls();
                            goto IL_285;
                        IL_270:
                            System.Windows.MessageBox.Show("Audio length should not exceed 30 minutes.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                        IL_285:
                            goto IL_29D;
                        }
                        // int expr_92 = arg_21D_0 = 0;
                        //if(expr_92 == 0)
                        //    {
                        //    long arg_9A_0 = (long)expr_92;
                        //    goto IL_99;
                        //    }
                        //goto IL_21D;
                    }
                }
                else
                {
                    System.Windows.MessageBox.Show("Select Audio File.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            IL_29D:;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnCancelSelectAudio_Click(object sender, RoutedEventArgs e)
        {
            this.ResetAudioTemplateControls();
        }

        private void btnDeleteAudio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                this.audioId = (long)Convert.ToInt32(button.Tag);
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete record?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                bool arg_4B_0 = messageBoxResult == MessageBoxResult.Yes;
                bool arg_A6_0;
                bool expr_4B;
                do
                {
                    expr_4B = (arg_4B_0 = (arg_A6_0 = !arg_4B_0));
                }
                while (false);
                if (false)
                {
                    goto IL_A6;
                }
                bool flag = expr_4B;
                bool arg_B5_0;
                bool expr_55 = arg_B5_0 = flag;
                if (false)
                {
                    goto IL_B4;
                }
                if (expr_55)
                {
                    goto IL_121;
                }
                ConfigBusiness configBusiness = new ConfigBusiness();
                AudioTemplateInfo audioTemplateList = configBusiness.GetAudioTemplateListByID(this.audioId);
                if (audioTemplateList == null)
                {
                    goto IL_119;
                }
                string path = LoginUser.DigiFolderAudioPath + audioTemplateList.Name;
            IL_93:
                bool flag2 = configBusiness.DeleteAudio(this.audioId);
                arg_A6_0 = !flag2;
            IL_A6:
                flag = arg_A6_0;
                bool arg_AA_0 = flag;
            IL_AA:
                if (arg_AA_0)
                {
                    goto IL_118;
                }
                arg_B5_0 = File.Exists(path);
            IL_B4:
                flag = !arg_B5_0;
                if (!false && !flag)
                {
                    if (false)
                    {
                        goto IL_120;
                    }
                    File.Delete(path);
                }
                this.DeleteFromAllSubstore(this.lstConfigurationInfo, audioTemplateList.Name, "Audio");
                this.GetAudioDetails();
                if (false)
                {
                    goto IL_93;
                }
                System.Windows.MessageBox.Show("Audio record deleted successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                arg_AA_0 = AuditLog.AddUserLog(LoginUser.UserId, 49, "Audio deleted at ");
                if (false)
                {
                    goto IL_AA;
                }
            IL_118:
            IL_119:
                this.ResetAudioTemplateControls();
            IL_120:
            IL_121:;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnEditAudio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                this.audioId = (long)Convert.ToInt32(button.Tag);
                this.IsAudioEdited = true;
                ConfigBusiness configBusiness = new ConfigBusiness();
                AudioTemplateInfo audioTemplateList = configBusiness.GetAudioTemplateListByID(this.audioId);
                this.audioName = audioTemplateList.Name;
                this.txtSelectedAudio.Text = LoginUser.DigiFolderAudioPath + audioTemplateList.Name;
                this.txtAudioDescription.Text = audioTemplateList.Description;
                this.IsAudioActive.IsChecked = new bool?(audioTemplateList.IsActive);
                this.audioDisplayname = Path.GetFileName(audioTemplateList.DisplayName);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool CheckAudioValidations()
        {
            bool result;
            while (!true || this.txtSelectedAudio.Text == "")
            {
                if (7 != 0)
                {
                    bool expr_21 = false;
                    if (4 != 0)
                    {
                        result = expr_21;
                    }
                    if (!false && !false)
                    {
                    }
                    return result;
                }
            }
            result = true;
            return result;
        }

        private bool SaveAudioDetails(string audioDisplayname, string audioName, string strDescription, bool? IsActive, bool IsEdited, long AudioLength)
        {
            bool result;
            try
            {
                AudioTemplateInfo audioTemplateInfo;
                if (3 != 0)
                {
                    IsActive = ((!IsActive.HasValue) ? new bool?(false) : IsActive);
                    audioTemplateInfo = new AudioTemplateInfo();
                    AudioTemplateInfo expr_130 = audioTemplateInfo;
                    if (5 != 0)
                    {
                        expr_130.DisplayName = audioDisplayname;
                    }
                    if (false)
                    {
                        goto IL_FC;
                    }
                    audioTemplateInfo.Name = audioName;
                    if (false)
                    {
                        goto IL_A0;
                    }
                    audioTemplateInfo.IsActive = Convert.ToBoolean(IsActive);
                    if (3 == 0)
                    {
                        goto IL_97;
                    }
                    audioTemplateInfo.Description = strDescription;
                    audioTemplateInfo.AudioLength = AudioLength;
                    if (IsEdited)
                    {
                        audioTemplateInfo.CreatedBy = LoginUser.UserId;
                        audioTemplateInfo.CreatedOn = DateTime.Now;
                        audioTemplateInfo.AudioTemplateId = this.audioId;
                        audioTemplateInfo.ModifiedBy = LoginUser.UserId;
                        audioTemplateInfo.ModifiedOn = DateTime.Now;
                        goto IL_ED;
                    }
                }
                audioTemplateInfo.CreatedBy = LoginUser.UserId;
                if (7 == 0)
                {
                    goto IL_ED;
                }
                audioTemplateInfo.CreatedOn = DateTime.Now;
            IL_97:
                audioTemplateInfo.ModifiedBy = 0;
            IL_A0:
                audioTemplateInfo.ModifiedOn = DateTime.Now;
            IL_ED:
                ConfigBusiness configBusiness = new ConfigBusiness();
                result = configBusiness.SaveUpdateAudioTemplate(audioTemplateInfo);
            IL_FC:;
            }
            catch
            {
                result = false;
            }
            while (false)
            {
            }
            return result;
        }

        private void ResetAudioTemplateControls()
        {
            while (true)
            {
                while (true)
                {
                    this.txtSelectedAudio.Text = "";


                    if (!false)
                    {
                        this.txtAudioDescription.Text = "";

                        if (8 != 0)
                        {
                            this.IsAudioActive.IsChecked = new bool?(false);

                        }
                        while (2 != 0)
                        {
                            if (6 == 0)
                            {
                                break;
                            }
                            if (!false)
                            {
                                goto Block_4;
                            }
                        }
                    }
                }
            }
        Block_4:
            this.audioId = 0L;
        }

        private void GetVideoTemplateDetails()
        {
            do
            {
                try
                {
                    List<VideoTemplateInfo> videoTemplate;
                    if (!false)
                    {
                        ConfigBusiness configBusiness = new ConfigBusiness();
                        videoTemplate = configBusiness.GetVideoTemplate();
                    }
                    if (!false)
                    {
                        this.DGManageVideo.ItemsSource = videoTemplate;
                    }
                    if (!false)
                    {
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    do
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (4 == 0);
                }
            }
            while (false);
        }

        private void btnSelectVideo_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog;
            bool? flag;
            do
            {
                openFileDialog = new Microsoft.Win32.OpenFileDialog();
                if (false)
                {
                    goto IL_4A;
                }
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "Select Video|*.mp4;*.wmv;*.avi;*.flv;*.mpg;*.m4a;*.3gpp;*.3gpp2;*.m2v;*.mov;|MP4|*.mp4|WMV|*.wmv|AVI|*.avi|FLV|*.flv|MPG|*.mpg|M4A|*.m4a|3GPP|*.3gpp|3GPP2|*.3gpp2|M2V|*.m2v|MOV|*.mov;";
                flag = openFileDialog.ShowDialog();
            }
            while (false);
            bool flag2 = !flag.Value;
        IL_4A:
            if (!flag2)
            {
                try
                {
                    flag2 = (openFileDialog.OpenFile() == null);
                    if (!flag2)
                    {
                        int arg_86_0;
                        int expr_7A = arg_86_0 = Path.GetFileName(openFileDialog.FileName.ToString()).ToCharArray().Count<char>();
                        if (7 != 0)
                        {
                            arg_86_0 = ((expr_7A > 50) ? 1 : 0);
                        }
                        flag2 = (arg_86_0 != 0);
                        if (!flag2)
                        {
                            do
                            {
                                this.txtSelectedVideo.Text = openFileDialog.FileName.ToString();
                                do
                                {
                                    this.videoDisplayname = Path.GetFileName(openFileDialog.FileName);
                                }
                                while (8 == 0);
                                if (false)
                                {
                                    break;
                                }
                            }
                            while (-1 == 0);
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("File name should not excced 50 characters.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnSaveSelectVideo_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    string arg_263_0 = string.Empty;
            //    long videoTemplateId = 0L;
            //    if (this.CheckVideoValidations())
            //    {
            //        WindowsMediaPlayer windowsMediaPlayer = (WindowsMediaPlayer)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("6BF52A52-394A-11D3-B153-00C04F79FAA6")));
            //        IWMPMedia iWMPMedia = windowsMediaPlayer.newMedia(this.txtSelectedVideo.Text);
            //        string text = Path.GetExtension(this.txtSelectedVideo.Text).ToLower();
            //        long num;
            //        if (text.Equals(".flv"))
            //        {
            //            FlvMetaInfo flvMetaInfo = FlvMetaDataReader.GetFlvMetaInfo(this.txtSelectedVideo.Text);
            //            num = Convert.ToInt64(flvMetaInfo.Duration);
            //        }
            //        else
            //        {
            //            num = (string.IsNullOrEmpty(TimeSpan.FromSeconds(iWMPMedia.duration).ToString()) ? 0L : ((long)TimeSpan.FromSeconds(iWMPMedia.duration).TotalSeconds));
            //        }
            //        if (num <= 1800L)
            //        {
            //            if (!string.IsNullOrEmpty(this.btnSaveSelectVideo.Tag.ToString()))
            //            {
            //                videoTemplateId = long.Parse(this.btnSaveSelectVideo.Tag.ToString());
            //            }
            //            Guid guid = Guid.NewGuid();
            //            string text2 = Path.GetFileNameWithoutExtension(this.videoDisplayname) + guid.ToString() + Path.GetExtension(this.videoDisplayname);
            //            string text3 = LoginUser.DigiFolderVideoTemplatePath + text2;
            //            if (!Directory.Exists(LoginUser.DigiFolderVideoTemplatePath))
            //            {
            //                Directory.CreateDirectory(LoginUser.DigiFolderVideoTemplatePath);
            //            }
            //            File.Copy(this.txtSelectedVideo.Text, text3, true);
            //            bool flag = this.SaveVideoDetails(videoTemplateId, this.videoDisplayname, text2, this.txtVideoDescription.Text.Trim(), this.IsVideoActive.IsChecked, num);
            //            if (flag)
            //            {
            //                this.CopyToAllSubstore(this.lstConfigurationInfo, text3, "", "Video");
            //                System.Windows.MessageBox.Show("Video saved successfully", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            //                AuditLog.AddUserLog(LoginUser.UserId, 49, "Add/Edit Audio at ");
            //                this.GetVideoTemplateDetails();
            //                this.ResetVideoTemplateControls();
            //            }
            //        }
            //        else
            //        {
            //            System.Windows.MessageBox.Show("Video length should not exceed 30 minutes.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //        }
            //    }
            //    else
            //    {
            //        System.Windows.MessageBox.Show("Select video file ", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //    }
            //}
            //catch (Exception serviceException)
            //{
            //    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
            //    ErrorHandler.ErrorHandler.LogFileWrite(message);
            //}
        }

        private void btnCancelSelectVideo_Click(object sender, RoutedEventArgs e)
        {
            this.ResetVideoTemplateControls();
        }

        private void ResetVideoTemplateControls()
        {
            this.txtVideoDescription.Text = string.Empty;
            if (!false)
            {
            }
            do
            {
                this.txtSelectedVideo.Text = string.Empty;
            }
            while (false);
            while (true)
            {
                if (false)
                {
                    goto IL_46;
                }
                this.IsVideoActive.IsChecked = new bool?(false);
            IL_35:
                if (4 == 0)
                {
                    continue;
                }
                this.btnSaveSelectVideo.Tag = string.Empty;
            IL_46:
                if (2 != 0)
                {
                    break;
                }
                goto IL_35;
            }
        }

        private void btnDeleteVideo_Click(object sender, RoutedEventArgs e)
        {
            VideoTemplateInfo videoTemplate;
            while (true)
            {
            IL_01:
                long num;
                ConfigBusiness configBusiness;
                string path;
                if (!false)
                {
                    System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                    num = long.Parse(button.Tag.ToString());
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete record?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                    bool arg_50_0 = messageBoxResult != MessageBoxResult.Yes;
                    if (-1 == 0)
                    {
                        goto IL_FE;
                    }
                    if (arg_50_0)
                    {
                        goto IL_101;
                    }
                    configBusiness = new ConfigBusiness();
                    videoTemplate = configBusiness.GetVideoTemplate(num);
                    path = LoginUser.DigiFolderVideoTemplatePath + videoTemplate.Name;
                }
                bool flag = configBusiness.DeleteVideoTemplate(num);
                bool flag2 = !flag;
                bool arg_8E_0 = flag2;
                while (!arg_8E_0)
                {
                    bool arg_9E_0 = arg_8E_0 = !File.Exists(path);
                    while (5 != 0)
                    {
                        flag2 = arg_9E_0;
                        bool expr_A0 = arg_8E_0 = (arg_9E_0 = flag2);
                        if (!false)
                        {
                            if (expr_A0)
                            {
                                goto IL_B7;
                            }
                            File.Delete(path);
                            if (8 != 0)
                            {
                                goto IL_B7;
                            }
                            goto IL_01;
                        }
                    }
                }
                goto IL_100;
            }
        IL_B7:
            this.DeleteFromAllSubstore(this.lstConfigurationInfo, videoTemplate.Name, "Video");
            this.GetVideoTemplateDetails();
            System.Windows.MessageBox.Show("Video record deleted Successfully", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            if (false)
            {
                return;
            }
            AuditLog.AddUserLog(LoginUser.UserId, 49, "Delete video at ");
        IL_FE:
        IL_100:
        IL_101:
            this.ResetVideoTemplateControls();
        }

        private void btnEditVideo_Click(object sender, RoutedEventArgs e)
        {
            VideoTemplateInfo videoTemplate;
            while (true)
            {
                long num = 0L;
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                if (!false)
                {
                    if (false)
                    {
                        goto IL_58;
                    }
                    num = long.Parse(button.Tag.ToString());
                    this.btnSaveSelectVideo.Tag = num;
                IL_52:
                    ConfigBusiness configBusiness = new ConfigBusiness();
                IL_58:
                    videoTemplate = configBusiness.GetVideoTemplate(num);
                    bool flag = videoTemplate == null;
                    if (2 != 0 && flag)
                    {
                        return;
                    }
                    this.txtSelectedVideo.Text = LoginUser.DigiFolderVideoTemplatePath + videoTemplate.Name;
                IL_89:
                    if (5 != 0)
                    {
                        this.txtVideoDescription.Text = videoTemplate.Description;
                        break;
                    }
                    goto IL_52;
                }
            }
            this.IsVideoActive.IsChecked = new bool?(videoTemplate.IsActive);
            if (2 != 0)
            {
                this.videoDisplayname = Path.GetFileName(videoTemplate.DisplayName);
                return;
            }
            //goto IL_89;
        }

        private void btnSlotTimeFrame_Click(object sender, RoutedEventArgs e)
        {
            //    if (3 == 0)
            //    {
            //        goto IL_87;
            //    }
            //    if (8 == 0)
            //    {
            //        goto IL_94;
            //    }
            //    long videoTemplateId = 0L;
            //    System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
            //    videoTemplateId = long.Parse(button.Tag.ToString());
            //    IL_3C:
            //    if (false)
            //    {
            //        return;
            //    }
            //    this.CtrlVideoSlotsTime.VideoTemplateId = videoTemplateId;
            //    DataGridRow dataGridRow = this.FindParent<DataGridRow>(button);
            //    do
            //    {
            //        this.CtrlVideoSlotsTime.VideoLength = ((VideoTemplateInfo)dataGridRow.Item).VideoLength;
            //        this.CtrlVideoSlotsTime.SetParent(this.tbmain);
            //    }
            //    while (-1 == 0);
            //    IL_87:
            //    this.CtrlVideoSlotsTime.Visibility = Visibility.Visible;
            //    IL_94:
            //    if (4 == 0)
            //    {
            //        goto IL_3C;
            //    }
            //    this.tbmain.IsEnabled = false;
            //}

            //private T FindParent<T>(DependencyObject child) where T : DependencyObject
            //{
            //    T result;
            //    while (!false)
            //    {
            //        DependencyObject parent = VisualTreeHelper.GetParent(child);
            //        bool flag = parent != null;
            //        if (2 != 0)
            //        {
            //            if (!flag)
            //            {
            //                result = default(T);
            //            }
            //            else
            //            {
            //                IL_38:
            //                T t = parent as T;
            //                if (!false)
            //                {
            //                    if (t == null || 6 == 0)
            //                    {
            //                        result = this.FindParent<T>(parent);
            //                        break;
            //                    }
            //                    result = t;
            //                }
            //            }
            //            return result;
            //        }
            //    }
            //    if (2 != 0)
            //    {
            //        return result;
            //    }
            //    //goto IL_38;
        }

        private bool CheckVideoValidations()
        {
            bool result;
            while (!true || string.IsNullOrEmpty(this.txtSelectedVideo.Text.Trim()))
            {
                if (7 != 0)
                {
                    bool expr_1E = false;
                    if (4 != 0)
                    {
                        result = expr_1E;
                    }
                    if (!false && !false)
                    {
                    }
                    return result;
                }
            }
            result = true;
            return result;
        }

        private bool SaveVideoDetails(long videoTemplateId, string videoDisplayname, string videoName, string strDescription, bool? IsActive, long videoLength)
        {
            bool result;
            try
            {
                ConfigBusiness configBusiness = new ConfigBusiness();
                VideoTemplateInfo videoTemplateInfo = new VideoTemplateInfo();
                IsActive = ((!IsActive.HasValue) ? new bool?(false) : IsActive);
                videoTemplateInfo.DisplayName = videoDisplayname;
                videoTemplateInfo.Name = videoName;
                videoTemplateInfo.IsActive = Convert.ToBoolean(IsActive);
                videoTemplateInfo.Description = strDescription;
                videoTemplateInfo.CreatedBy = LoginUser.UserId;
                videoTemplateInfo.CreatedOn = new DateTime?(DateTime.Now);
                videoTemplateInfo.VideoTemplateId = videoTemplateId;
                videoTemplateInfo.ModifiedBy = LoginUser.UserId;
                videoTemplateInfo.ModifiedOn = new DateTime?(DateTime.Now);
                videoTemplateInfo.videoSlots = null;
                videoTemplateInfo.VideoLength = videoLength;
                result = configBusiness.SaveVideoTemplate(videoTemplateInfo);
            }
            catch
            {
                if (!false)
                {
                    result = false;
                }
            }
            return result;
        }

        private void GetVideoBGDetails()
        {
            do
            {
                try
                {
                    List<VideoBackgroundInfo> videoBackgrounds;
                    if (!false)
                    {
                        ConfigBusiness configBusiness = new ConfigBusiness();
                        videoBackgrounds = configBusiness.GetVideoBackgrounds();
                    }
                    if (!false)
                    {
                        this.DGManageVideoBG.ItemsSource = videoBackgrounds;
                    }
                    if (!false)
                    {
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    do
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (4 == 0);
                }
            }
            while (false);
        }

        private void GetGeneralBGDetails()
        {
            do
            {
                try
                {
                    List<GeneralBackgroundInfo> generalBackgrounds;
                    if (!false)
                    {
                        ConfigBusiness configBusiness = new ConfigBusiness();
                        generalBackgrounds = configBusiness.GetGeneralBackgrounds();
                    }
                    if (!false)
                    {
                        this.DGManageGeneralSetting.ItemsSource = generalBackgrounds;
                    }
                    if (!false)
                    {
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    do
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (4 == 0);
                }
            }
            while (false);
        }

        private void btnSelectGeneralBG_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            Microsoft.Win32.OpenFileDialog expr_152 = openFileDialog;
            bool expr_16 = false;
            if (6 != 0)
            {
                expr_152.Multiselect = expr_16;
            }
            openFileDialog.Filter = "Select Media|*.jpg;*.png;*.mp4;*.wmv;*.avi;|JPG|*.jpg;*.JPG|PNG|*.png;*.PNG|WMV|*.wmv;*.WMV|MP4|*.mp4;*.MP4|AVI|*.avi;*.AVI;";
            if (openFileDialog.ShowDialog().Value)
            {
                try
                {
                    if (openFileDialog.OpenFile() != null)
                    {
                        if (Path.GetFileName(openFileDialog.FileName.ToString()).ToCharArray().Count<char>() <= 50)
                        {
                            this.txtSelectedGeneralBG.Text = openFileDialog.FileName.ToString();
                            this.generalBGDisplayname = Path.GetFileName(openFileDialog.FileName);
                            if (!(Path.GetExtension(openFileDialog.FileName) == ".jpg") && !(Path.GetExtension(openFileDialog.FileName) == ".JPEG"))
                            {
                                this.generalBGMediaType = 2;
                                goto IL_FF;
                            }
                        }
                        else if (!false)
                        {
                            System.Windows.MessageBox.Show("File name should not excced 50 characters.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            goto IL_11A;
                        }
                        this.generalBGMediaType = 1;
                    IL_FF:
                    IL_11A:;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnSelectVideoBG_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            Microsoft.Win32.OpenFileDialog expr_152 = openFileDialog;
            bool expr_16 = false;
            if (6 != 0)
            {
                expr_152.Multiselect = expr_16;
            }
            openFileDialog.Filter = "Select Media|*.jpg;*.png;*.mp4;*.wmv;*.avi;|JPG|*.jpg;*.JPG|PNG|*.png;*.PNG|WMV|*.wmv;*.WMV|MP4|*.mp4;*.MP4|AVI|*.avi;*.AVI;";
            if (openFileDialog.ShowDialog().Value)
            {
                try
                {
                    if (openFileDialog.OpenFile() != null)
                    {
                        if (Path.GetFileName(openFileDialog.FileName.ToString()).ToCharArray().Count<char>() <= 50)
                        {
                            this.txtSelectedVideoBG.Text = openFileDialog.FileName.ToString();
                            this.videoBGDisplayname = Path.GetFileName(openFileDialog.FileName);
                            if (!(Path.GetExtension(openFileDialog.FileName) == ".jpg") && !(Path.GetExtension(openFileDialog.FileName) == ".JPEG"))
                            {
                                this.videoBGMediaType = 2;
                                goto IL_FF;
                            }
                        }
                        else if (!false)
                        {
                            System.Windows.MessageBox.Show("File name should not excced 50 characters.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            goto IL_11A;
                        }
                        this.videoBGMediaType = 1;
                    IL_FF:
                    IL_11A:;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void SelectVideoOrImage(System.Windows.Controls.TextBox txtselect, string vDisplayname, int mediaId, string selectItem)
        {
            if (!false)
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Multiselect = false;
                while (true)
                {
                IL_23:
                    Microsoft.Win32.FileDialog expr_19A = openFileDialog;
                    string expr_28 = "Select Media|*.jpg;*.png;*.mp4;*.wmv;*.avi;|JPG|*.jpg;*.JPG|PNG|*.png;*.PNG|WMV|*.wmv;*.WMV|MP4|*.mp4;*.MP4|AVI|*.avi;*.AVI;";
                    if (!false)
                    {
                        expr_19A.Filter = expr_28;
                    }
                    while (openFileDialog.ShowDialog().Value)
                    {
                        if (4 != 0)
                        {
                            if (!false)
                            {
                                goto Block_4;
                            }
                            goto IL_23;
                        }
                    }
                    return;
                }
            Block_4:
                try
                {
                    bool arg_67_0 = openFileDialog.OpenFile() == null;
                    while (!arg_67_0)
                    {
                        if (Path.GetFileName(openFileDialog.FileName.ToString()).ToCharArray().Count<char>() <= 50)
                        {
                            while (true)
                            {
                                txtselect.Text = openFileDialog.FileName.ToString();
                                selectItem = Path.GetFileName(openFileDialog.FileName);
                                if (Path.GetExtension(openFileDialog.FileName) == ".jpg" || Path.GetExtension(openFileDialog.FileName) == ".JPEG")
                                {
                                    goto IL_11A;
                                }
                                if (!false)
                                {
                                    goto Block_9;
                                }
                            }
                        IL_11B:
                            int arg_11F_0;
                            bool arg_127_0;
                            if (true)
                            {
                                if (arg_11F_0 != 0)
                                {
                                    break;
                                }
                                arg_127_0 = true;
                            }
                            if (!(arg_67_0 = arg_127_0))
                            {
                                continue;
                            }
                            break;
                        Block_9:
                            if (!(Path.GetExtension(openFileDialog.FileName) == ".png"))
                            {
                                arg_127_0 = ((arg_11F_0 = ((!(Path.GetExtension(openFileDialog.FileName) == ".PNG")) ? 1 : 0)) != 0);
                                goto IL_11B;
                            }
                        IL_11A:
                            arg_127_0 = ((arg_11F_0 = 0) != 0);
                            goto IL_11B;
                        }
                        System.Windows.MessageBox.Show("File name should not excced 50 characters.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        break;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            while (7 == 0)
            {
            }
        }

        private void btnSaveGeneralBG_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                bool flag = !this.CheckGeneralBGValidations(this.txtSelectedGeneralBG);
                int arg_44_0 = flag ? 1 : 0;
                while (arg_44_0 == 0)
                {

                    bool flag2 = true;

                IL_112:
                    if (flag2)
                    {
                        bool flag3 = false;
                        Guid guid = Guid.NewGuid();
                        this.generalBGName = Path.GetFileNameWithoutExtension(this.generalBGDisplayname) + guid.ToString() + Path.GetExtension(this.generalBGDisplayname);
                        string text = LoginUser.PhotoSWGeneralBackGroundPath + this.generalBGName;
                        string text2 = this.txtGeneralBGDescription.Text;
                        bool? isChecked = this.IsGeneralBGActive.IsChecked;
                        if (!this.IsGeneralBGEdited)
                        {
                            flag = Directory.Exists(LoginUser.PhotoSWGeneralBackGroundPath);
                            if (!flag)
                            {
                                Directory.CreateDirectory(LoginUser.PhotoSWGeneralBackGroundPath);
                            }
                            File.Copy(this.txtSelectedGeneralBG.Text, text, true);
                            flag3 = this.SaveGeneralBGDetails(this.generalBGDisplayname, this.generalBGName, text2, isChecked, this.IsGeneralBGEdited, this.generalBGMediaType);
                            goto IL_288;
                        }
                        string text3 = this.txtSelectedGeneralBG.Text;
                        flag = !File.Exists(text3);
                        if (flag)
                        {
                            System.Windows.MessageBox.Show("File not found.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
                            goto IL_280;
                        }
                        File.Copy(text3, text, true);
                        if (false)
                        {
                            goto IL_305;
                        }
                        if (8 == 0)
                        {
                            // goto IL_BA;
                        }
                        int arg_22F_0 = text3.Contains(LoginUser.PhotoSWGeneralBackGroundPath) ? 1 : 0;
                        int arg_22F_1 = 0;
                    IL_22F:
                        flag = (arg_22F_0 == arg_22F_1);
                    IL_233:
                        if (!flag)
                        {
                            //   File.Delete(text3);
                            if (5 == 0)
                            {
                                goto IL_280;
                            }
                        }
                        flag3 = this.SaveGeneralBGDetails(this.generalBGDisplayname, this.generalBGName, text2, isChecked, this.IsGeneralBGEdited, this.generalBGMediaType);
                    IL_280:
                        this.IsGeneralBGEdited = false;
                    IL_288:
                        if (false)
                        {
                            goto IL_233;
                        }
                        if (flag3)
                        {
                            this.CopyToAllSubstore(this.lstConfigurationInfo, text, "", "GeneralBG");
                            System.Windows.MessageBox.Show("General background saved successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            int expr_2C3 = arg_22F_0 = LoginUser.UserId;
                            int expr_2CA = arg_22F_1 = 49;
                            if (expr_2CA == 0)
                            {
                                goto IL_22F;
                            }
                            //  AuditLog.AddUserLog(expr_2C3, expr_2CA, "Add/Edit Video Background at ");
                            this.GetGeneralBGDetails();
                        }
                        this.ResetGeneralBGControls();
                        if (3 != 0)
                        {
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("General Setting background length should not exceed 30 minutes.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                IL_305:
                    return;
                }
                System.Windows.MessageBox.Show("Select General Setting background file.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnSaveVideoBG_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    WindowsMediaPlayer windowsMediaPlayer = (WindowsMediaPlayer)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("6BF52A52-394A-11D3-B153-00C04F79FAA6")));
            //    bool flag = !this.CheckVideoBGValidations(this.txtSelectedVideoBG);
            //    int arg_44_0 = flag ? 1 : 0;
            //    while (arg_44_0 == 0)
            //    {
            //        IWMPMedia iWMPMedia;
            //        TimeSpan timeSpan;
            //        bool flag2;
            //        if (Path.GetExtension(this.videoBGDisplayname) == ".mp4" || Path.GetExtension(this.videoBGDisplayname) == ".wmv" || Path.GetExtension(this.videoBGDisplayname) == ".avi")
            //        {
            //            iWMPMedia = windowsMediaPlayer.newMedia(this.txtSelectedVideo.Text);
            //            timeSpan = TimeSpan.FromSeconds(iWMPMedia.duration);
            //        }
            //        else
            //        {
            //            int expr_10A = arg_44_0 = 1;
            //            if (expr_10A != 0)
            //            {
            //                flag2 = (expr_10A != 0);
            //                goto IL_112;
            //            }
            //            continue;
            //        }
            //        IL_BA:
            //        bool arg_CC_0 = string.IsNullOrEmpty(timeSpan.ToString());
            //        bool expr_F4;
            //        do
            //        {
            //            long arg_E8_0;
            //            if (!arg_CC_0)
            //            {
            //                timeSpan = TimeSpan.FromSeconds(iWMPMedia.duration);
            //                arg_E8_0 = (long)timeSpan.TotalSeconds;
            //            }
            //            else
            //            {
            //                arg_E8_0 = 0L;
            //            }
            //            long num = arg_E8_0;
            //            flag = (num > 1800L);
            //            expr_F4 = (arg_CC_0 = flag);
            //        }
            //        while (4 == 0);
            //        flag2 = !expr_F4;
            //        IL_112:
            //        if (flag2)
            //        {
            //            bool flag3 = false;
            //            Guid guid = Guid.NewGuid();
            //            this.videoBGName = Path.GetFileNameWithoutExtension(this.videoBGDisplayname) + guid.ToString() + Path.GetExtension(this.videoBGDisplayname);
            //            string text = LoginUser.DigiFolderVideoBackGroundPath + this.videoBGName;
            //            string text2 = this.txtVideoBGDescription.Text;
            //            bool? isChecked = this.IsVideoBGActive.IsChecked;
            //            if (!this.IsVideoBGEdited)
            //            {
            //                flag = Directory.Exists(LoginUser.DigiFolderVideoBackGroundPath);
            //                if (!flag)
            //                {
            //                    Directory.CreateDirectory(LoginUser.DigiFolderVideoBackGroundPath);
            //                }
            //                File.Copy(this.txtSelectedVideoBG.Text, text, true);
            //                flag3 = this.SaveVideoBGDetails(this.videoBGDisplayname, this.videoBGName, text2, isChecked, this.IsVideoBGEdited, this.videoBGMediaType);
            //                goto IL_288;
            //            }
            //            string text3 = this.txtSelectedVideoBG.Text;
            //            flag = !File.Exists(text3);
            //            if (flag)
            //            {
            //                System.Windows.MessageBox.Show("File not found.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
            //                goto IL_280;
            //            }
            //            File.Copy(text3, text, true);
            //            if (false)
            //            {
            //                goto IL_305;
            //            }
            //            if (8 == 0)
            //            {
            //                goto IL_BA;
            //            }
            //            int arg_22F_0 = text3.Contains(LoginUser.DigiFolderVideoBackGroundPath) ? 1 : 0;
            //            int arg_22F_1 = 0;
            //            IL_22F:
            //            flag = (arg_22F_0 == arg_22F_1);
            //            IL_233:
            //            if (!flag)
            //            {
            //                File.Delete(text3);
            //                if (5 == 0)
            //                {
            //                    goto IL_280;
            //                }
            //            }
            //            flag3 = this.SaveVideoBGDetails(this.videoBGDisplayname, this.videoBGName, text2, isChecked, this.IsVideoBGEdited, this.videoBGMediaType);
            //            IL_280:
            //            this.IsVideoBGEdited = false;
            //            IL_288:
            //            if (false)
            //            {
            //                goto IL_233;
            //            }
            //            if (flag3)
            //            {
            //                this.CopyToAllSubstore(this.lstConfigurationInfo, text, "", "VideoBG");
            //                System.Windows.MessageBox.Show("Video background saved successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            //                int expr_2C3 = arg_22F_0 = LoginUser.UserId;
            //                int expr_2CA = arg_22F_1 = 49;
            //                if (expr_2CA == 0)
            //                {
            //                    goto IL_22F;
            //                }
            //                AuditLog.AddUserLog(expr_2C3, expr_2CA, "Add/Edit Video Background at ");
            //                this.GetVideoBGDetails();
            //            }
            //            this.ResetVideoBGControls();
            //            if (3 != 0)
            //            {
            //            }
            //        }
            //        else
            //        {
            //            System.Windows.MessageBox.Show("Video background length should not exceed 30 minutes.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //        }
            //        IL_305:
            //        return;
            //    }
            //    System.Windows.MessageBox.Show("Select video background file.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //}
            //catch (Exception serviceException)
            //{
            //    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
            //    ErrorHandler.ErrorHandler.LogFileWrite(message);
            //}
        }

        private void btnCancelVideoBG_Click(object sender, RoutedEventArgs e)
        {
            this.ResetVideoBGControls();
        }

        private void btnDeleteVideoBG_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                this.videoBackgroundId = (long)Convert.ToInt32(button.Tag);
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete record?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
                bool arg_4B_0 = messageBoxResult == MessageBoxResult.Yes;
                bool arg_A6_0;
                bool expr_4B;
                do
                {
                    expr_4B = (arg_4B_0 = (arg_A6_0 = !arg_4B_0));
                }
                while (false);
                if (false)
                {
                    goto IL_A6;
                }
                bool flag = expr_4B;
                bool arg_B5_0;
                bool expr_55 = arg_B5_0 = flag;
                if (false)
                {
                    goto IL_B4;
                }
                if (expr_55)
                {
                    goto IL_121;
                }
                ConfigBusiness configBusiness = new ConfigBusiness();
                VideoBackgroundInfo videoBackgrounds = configBusiness.GetVideoBackgrounds(this.videoBackgroundId);
                if (videoBackgrounds == null)
                {
                    goto IL_119;
                }
                string path = LoginUser.DigiFolderVideoBackGroundPath + videoBackgrounds.Name;
            IL_93:
                bool flag2 = configBusiness.DeleteVideoBackground(this.videoBackgroundId);
                arg_A6_0 = !flag2;
            IL_A6:
                flag = arg_A6_0;
                bool arg_AA_0 = flag;
            IL_AA:
                if (arg_AA_0)
                {
                    goto IL_118;
                }
                arg_B5_0 = File.Exists(path);
            IL_B4:
                flag = !arg_B5_0;
                if (!false && !flag)
                {
                    if (false)
                    {
                        goto IL_120;
                    }
                    File.Delete(path);
                }
                this.DeleteFromAllSubstore(this.lstConfigurationInfo, videoBackgrounds.Name, "VideoBG");
                this.GetVideoBGDetails();
                if (false)
                {
                    goto IL_93;
                }
                System.Windows.MessageBox.Show("Video background record deleted successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                arg_AA_0 = AuditLog.AddUserLog(LoginUser.UserId, 49, "Video background deleted at ");
                if (false)
                {
                    goto IL_AA;
                }
            IL_118:
            IL_119:
                this.ResetVideoBGControls();
            IL_120:
            IL_121:;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);


























            }






























        }

        private void btnCancelGeneralBG_Click(object sender, RoutedEventArgs e)
        {
            this.ResetGeneralBGControls();
        }

        private void btnEditGeneralBG_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                this.generalBackgroundId = (long)Convert.ToInt32(button.Tag);
                this.IsGeneralBGEdited = true;
                ConfigBusiness configBusiness = new ConfigBusiness();
                GeneralBackgroundInfo generalBackgroundInfo = configBusiness.GetGeneralBackgrounds(this.generalBackgroundId);
                this.generalBGName = generalBackgroundInfo.Name;
                this.txtSelectedGeneralBG.Text = LoginUser.PhotoSWGeneralBackGroundPath + generalBackgroundInfo.Name;
                this.txtGeneralBGDescription.Text = generalBackgroundInfo.Description;
                this.IsGeneralBGActive.IsChecked = new bool?(generalBackgroundInfo.IsActive);
                this.generalBGDisplayname = Path.GetFileName(generalBackgroundInfo.DisplayName);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool CheckGeneralBGValidations(System.Windows.Controls.TextBox txtSelected)
        {
            bool result;
            if (!false)
            {
                if (8 == 0)
                {
                    goto IL_1C;
                }
                int arg_13_0 = (txtSelected.Text == "") ? 1 : 0;
            IL_12:
                if (arg_13_0 == 0)
                {
                    goto IL_28;
                }
            IL_1C:
                int expr_1D = arg_13_0 = 0;
                if (expr_1D != 0)
                {
                    goto IL_12;
                }
                result = (expr_1D != 0);
                if (2 != 0)
                {
                    return result;
                }
            IL_28:
                result = true;
            }
            return result;
        }

        private bool SaveGeneralBGDetails(string generalBGDisplayName, string generalBGName, string strDescription, bool? IsActive, bool IsEdited, int generalBGMediaType)
        {
            bool result;
            try
            {
                IsActive = ((!IsActive.HasValue) ? new bool?(false) : IsActive);
                GeneralBackgroundInfo generalBackgroundInfo = new GeneralBackgroundInfo();
                generalBackgroundInfo.DisplayName = generalBGDisplayName;
                generalBackgroundInfo.Name = generalBGName;
                generalBackgroundInfo.IsActive = Convert.ToBoolean(IsActive);
                generalBackgroundInfo.MediaType = generalBGMediaType;
                generalBackgroundInfo.Description = strDescription;
                if (!IsEdited)
                {
                    generalBackgroundInfo.CreatedBy = LoginUser.UserId;
                    generalBackgroundInfo.CreatedOn = DateTime.Now;
                    generalBackgroundInfo.ModifiedBy = 0;
                    generalBackgroundInfo.ModifiedOn = DateTime.Now;
                }
                else
                {
                    generalBackgroundInfo.CreatedBy = LoginUser.UserId;
                    generalBackgroundInfo.CreatedOn = DateTime.Now;
                    generalBackgroundInfo.GeneralBackgroundId = this.generalBackgroundId;
                    generalBackgroundInfo.ModifiedBy = LoginUser.UserId;
                    generalBackgroundInfo.ModifiedOn = DateTime.Now;
                }
                ConfigBusiness configBusiness = new ConfigBusiness();
                result = configBusiness.SaveUpdateGeneralBackground(generalBackgroundInfo);

                if (result)
                {
                    return result;
                }
                else
                {
                    result = false;
                    return result;
                }

            }
            catch
            {
                result = false;
            }
            return result;
        }

        private void btnDeleteGeneralBG_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                this.videoBackgroundId = (long)Convert.ToInt32(button.Tag);
                MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete record?", "PhotoSW", MessageBoxButton.YesNo, MessageBoxImage.Question);
                bool arg_4B_0 = messageBoxResult == MessageBoxResult.Yes;
                bool arg_A6_0;
                bool expr_4B;
                do
                {
                    expr_4B = (arg_4B_0 = (arg_A6_0 = !arg_4B_0));
                }
                while (false);
                if (false)
                {
                    goto IL_A6;
                }
                bool flag = expr_4B;
                bool arg_B5_0;
                bool expr_55 = arg_B5_0 = flag;
                if (false)
                {
                    goto IL_B4;
                }
                if (expr_55)
                {
                    goto IL_121;
                }
                ConfigBusiness configBusiness = new ConfigBusiness();
                VideoBackgroundInfo videoBackgrounds = configBusiness.GetVideoBackgrounds(this.videoBackgroundId);
                if (videoBackgrounds == null)
                {
                    goto IL_119;
                }
                string path = LoginUser.DigiFolderVideoBackGroundPath + videoBackgrounds.Name;
            IL_93:
                bool flag2 = configBusiness.DeleteVideoBackground(this.videoBackgroundId);
                arg_A6_0 = !flag2;
            IL_A6:
                flag = arg_A6_0;
                bool arg_AA_0 = flag;
            IL_AA:
                if (arg_AA_0)
                {
                    goto IL_118;
                }
                arg_B5_0 = File.Exists(path);
            IL_B4:
                flag = !arg_B5_0;
                if (!false && !flag)
                {
                    if (false)
                    {
                        goto IL_120;
                    }
                    File.Delete(path);
                }
                this.DeleteFromAllSubstore(this.lstConfigurationInfo, videoBackgrounds.Name, "VideoBG");
                this.GetVideoBGDetails();
                if (false)
                {
                    goto IL_93;
                }
                System.Windows.MessageBox.Show("Video background record deleted successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                arg_AA_0 = AuditLog.AddUserLog(LoginUser.UserId, 49, "Video background deleted at ");
                if (false)
                {
                    goto IL_AA;
                }
            IL_118:
            IL_119:
                this.ResetVideoBGControls();
            IL_120:
            IL_121:;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnEditVideoBG_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                this.videoBackgroundId = (long)Convert.ToInt32(button.Tag);
                this.IsVideoBGEdited = true;
                ConfigBusiness configBusiness = new ConfigBusiness();
                VideoBackgroundInfo videoBackgrounds = configBusiness.GetVideoBackgrounds(this.videoBackgroundId);
                this.videoBGName = videoBackgrounds.Name;
                this.txtSelectedVideoBG.Text = LoginUser.DigiFolderVideoBackGroundPath + videoBackgrounds.Name;
                this.txtVideoBGDescription.Text = videoBackgrounds.Description;
                this.IsVideoBGActive.IsChecked = new bool?(videoBackgrounds.IsActive);
                this.videoBGDisplayname = Path.GetFileName(videoBackgrounds.DisplayName);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool CheckVideoBGValidations(System.Windows.Controls.TextBox txtSelected)
        {
            bool result;
            if (!false)
            {
                if (8 == 0)
                {
                    goto IL_1C;
                }
                int arg_13_0 = (txtSelected.Text == "") ? 1 : 0;
            IL_12:
                if (arg_13_0 == 0)
                {
                    goto IL_28;
                }
            IL_1C:
                int expr_1D = arg_13_0 = 0;
                if (expr_1D != 0)
                {
                    goto IL_12;
                }
                result = (expr_1D != 0);
                if (2 != 0)
                {
                    return result;
                }
            IL_28:
                result = true;
            }
            return result;
        }

        private bool SaveVideoBGDetails(string videoBGDisplayName, string videoBGName, string strDescription, bool? IsActive, bool IsEdited, int videoBGMediaType)
        {
            bool result;
            try
            {
                IsActive = ((!IsActive.HasValue) ? new bool?(false) : IsActive);
                VideoBackgroundInfo videoBackgroundInfo = new VideoBackgroundInfo();
                videoBackgroundInfo.DisplayName = videoBGDisplayName;
                videoBackgroundInfo.Name = videoBGName;
                videoBackgroundInfo.IsActive = Convert.ToBoolean(IsActive);
                videoBackgroundInfo.MediaType = videoBGMediaType;
                videoBackgroundInfo.Description = strDescription;
                if (!IsEdited)
                {
                    videoBackgroundInfo.CreatedBy = LoginUser.UserId;
                    videoBackgroundInfo.CreatedOn = DateTime.Now;
                    videoBackgroundInfo.ModifiedBy = 0;
                    videoBackgroundInfo.ModifiedOn = DateTime.Now;
                }
                else
                {
                    videoBackgroundInfo.CreatedBy = LoginUser.UserId;
                    videoBackgroundInfo.CreatedOn = DateTime.Now;
                    videoBackgroundInfo.VideoBackgroundId = this.videoBackgroundId;
                    videoBackgroundInfo.ModifiedBy = LoginUser.UserId;
                    videoBackgroundInfo.ModifiedOn = DateTime.Now;
                }
                ConfigBusiness configBusiness = new ConfigBusiness();
                int num = configBusiness.SaveUpdateVideoBackground(videoBackgroundInfo);
                if (3 != 0)
                {
                    int arg_FA_0;
                    int expr_EC = arg_FA_0 = num;
                    if (!false)
                    {
                        bool flag = expr_EC <= 0;
                        arg_FA_0 = (flag ? 1 : 0);
                    }
                    if (arg_FA_0 == 0)
                    {
                        result = true;
                        return result;
                    }
                }
                result = false;
            }
            catch
            {
                result = false;
            }
            return result;
        }

        private void ResetGeneralBGControls()
        {
            while (true)
            {
                while (true)
                {
                    this.txtGeneralBGDescription.Text = string.Empty;
                    if (!false)
                    {
                        this.txtSelectedGeneralBG.Text = string.Empty;
                        if (8 != 0)
                        {
                            this.IsGeneralBGActive.IsChecked = new bool?(false);
                        }
                        while (2 != 0)
                        {
                            if (6 == 0)
                            {
                                break;
                            }
                            if (!false)
                            {
                                goto Block_4;
                            }
                        }
                    }
                }
            }
        Block_4:
            this.videoBackgroundId = 0L;
        }

        private void ResetVideoBGControls()
        {
            while (true)
            {
                while (true)
                {
                    this.txtVideoBGDescription.Text = string.Empty;
                    if (!false)
                    {
                        this.txtSelectedVideoBG.Text = string.Empty;
                        if (8 != 0)
                        {
                            this.IsVideoBGActive.IsChecked = new bool?(false);
                        }
                        while (2 != 0)
                        {
                            if (6 == 0)
                            {
                                break;
                            }
                            if (!false)
                            {
                                goto Block_4;
                            }
                        }
                    }
                }
            }
        Block_4:
            this.videoBackgroundId = 0L;
        }

        private void chkIsBarcodeActive_Checked(object sender, RoutedEventArgs e)
        {
            this.cmbMappingType.Visibility = Visibility.Visible;
            this.cmbScanType.Visibility = Visibility.Visible;
            UIElement expr_19 = this.txtblMappingType;
            Visibility expr_1E = Visibility.Visible;
            if (!false)
            {
                expr_19.Visibility = expr_1E;
            }
            this.txtblScanType.Visibility = Visibility.Visible;
            this.spLostImgTimeGap.Visibility = Visibility.Visible;
        }

        private void chkIsOnline_Checked(object sender, RoutedEventArgs e)
        {
            this.DgService.Visibility = Visibility.Visible;
        }

        private void chkIsOnline_UnChecked(object sender, RoutedEventArgs e)
        {
            this.DgService.Visibility = Visibility.Collapsed;
        }

        private void chkIsBarcodeActive_Unchecked(object sender, RoutedEventArgs e)
        {
            this.cmbMappingType.Visibility = Visibility.Collapsed;
            this.cmbScanType.Visibility = Visibility.Collapsed;
            UIElement expr_19 = this.txtblMappingType;
            Visibility expr_1E = Visibility.Collapsed;
            if (!false)
            {
                expr_19.Visibility = expr_1E;
            }
            this.txtblScanType.Visibility = Visibility.Collapsed;
            this.spLostImgTimeGap.Visibility = Visibility.Collapsed;
        }

        private void btnSaveOnlineConfig_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string pattern = "^[1-9]{1}[0-9]{0,4}$";
                string text = this.txtLostImgTimeGap.Text.Trim();
                text = text.TrimStart(new char[]
                {
                    '0'
                });
                string pattern2 = "^[0-9]*$";
                if (this.chkIsBarcodeActive.IsChecked == true && this.cmbMappingType.SelectedValue.ToString() == "400")
                {
                    System.Windows.MessageBox.Show("Please select Mapping Type");
                }
                else
                {
                    int arg_EE_0 = (!(this.chkIsBarcodeActive.IsChecked == true) || !(this.cmbScanType.SelectedValue.ToString() == "500")) ? 1 : 0;
                    while (Convert.ToBoolean(arg_EE_0))
                    {
                        bool flag = !(this.chkIsBarcodeActive.IsChecked == true) || Regex.IsMatch(text, pattern);
                        if (3 == 0)
                        {
                            goto IL_401;
                        }
                        if (!flag)
                        {
                            System.Windows.MessageBox.Show("Please select Lost Image Time Gap( integer value between 1-99999)");
                            return;
                        }
                        bool? isChecked = this.chkIsOnline.IsChecked;
                        bool arg_177_0 = ((!isChecked.GetValueOrDefault()) ? (arg_EE_0 = 0) : (arg_EE_0 = (isChecked.HasValue ? 1 : 0))) != 0;
                        if (false)
                        {
                            continue;
                        }
                        int arg_196_0;
                        bool arg_4FA_0 = ((!arg_177_0) ? (arg_196_0 = 1) : (arg_196_0 = ((!string.IsNullOrWhiteSpace(this.txtDgServiceUrl.Text)) ? 1 : 0))) != 0;
                        if (false)
                        {
                            goto IL_4FA;
                        }
                        if (arg_196_0 == 0)
                        {
                            System.Windows.MessageBox.Show("Please enter service URL.");
                            return;
                        }
                        bool arg_1D6_0;
                        if (!string.IsNullOrWhiteSpace(this.txtQRCodeLen.Text))
                        {
                            arg_1D6_0 = true;
                            goto IL_1D5;
                        }
                    IL_1BF:
                        arg_1D6_0 = !string.IsNullOrEmpty(this.txtQRCodeLen.Text);
                    IL_1D5:
                        flag = arg_1D6_0;
                        bool arg_32F_0;
                        while (flag)
                        {
                            if (!Regex.IsMatch(this.txtQRCodeLen.Text.ToString().Trim(), pattern2))
                            {
                                System.Windows.MessageBox.Show("Please Enter Valid QRCode Length.");
                                return;
                            }
                            flag = (this.txtQRCodeLen.Text.ToString().Length <= 2);
                            bool arg_32B_0;
                            if (!false)
                            {
                                if (!flag)
                                {
                                    if (!false)
                                    {
                                        System.Windows.MessageBox.Show("Please Enter Valid QRCode Length.");
                                        return;
                                    }
                                    continue;
                                }
                                else
                                {
                                    if (Convert.ToInt16(this.txtQRCodeLen.Text) > 30 || Convert.ToInt16(this.txtQRCodeLen.Text) < 5)
                                    {
                                        System.Windows.MessageBox.Show("Please Enter QRCode between 5-30.");
                                        return;
                                    }
                                    if (this.chkIsBarcodeActive.IsChecked == true && !(this.cmbMappingType.SelectedValue.ToString() == "400") && !(this.cmbScanType.SelectedValue.ToString() == "500") && Regex.IsMatch(text, pattern))
                                    {
                                        arg_32B_0 = false;
                                        goto IL_32A;
                                    }
                                    isChecked = this.chkIsBarcodeActive.IsChecked;
                                }
                            }
                            arg_32B_0 = !(isChecked == false);
                        IL_32A:
                            flag = arg_32B_0;
                            arg_32F_0 = flag;
                            goto IL_32F;
                        }
                        System.Windows.MessageBox.Show("Please Enter QR Code Length.");
                        return;
                    IL_32F:
                        if (arg_32F_0)
                        {
                            goto IL_866;
                        }
                        List<iMIXConfigurationInfo> list = new List<iMIXConfigurationInfo>();
                        iMIXConfigurationInfo iMIXConfigurationInfo = new iMIXConfigurationInfo();
                        iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                        iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.IsBarcodeActive);
                        iMIXConfigurationInfo.ConfigurationValue = Convert.ToString(this.chkIsBarcodeActive.IsChecked);
                        list.Add(iMIXConfigurationInfo);
                        int arg_39E_0 = string.IsNullOrEmpty(this.txtOnlineResize.Text.Trim()) ? 1 : 0;
                    IL_39E:
                        if (arg_39E_0 != 0 || string.IsNullOrEmpty(this.txtSMResize.Text.Trim()))
                        {
                            System.Windows.MessageBox.Show("Please provide a valid resize value", "iMIX", MessageBoxButton.OK, MessageBoxImage.Hand);
                            return;
                        }
                        if (!this.ValidateImageResizePercent(this.txtOnlineResize.Text.Trim()) || !this.ValidateImageResizePercent(this.txtSMResize.Text.Trim()))
                        {
                            System.Windows.MessageBox.Show("Resize value should be between 1 to 100", "iMIX", MessageBoxButton.OK, MessageBoxImage.Hand);
                            return;
                        }
                    IL_401:
                        iMIXConfigurationInfo = new iMIXConfigurationInfo();
                        iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                        iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.OnlineImageResize);
                        iMIXConfigurationInfo.ConfigurationValue = this.txtOnlineResize.Text.Trim();
                        list.Add(iMIXConfigurationInfo);
                        iMIXConfigurationInfo = new iMIXConfigurationInfo();
                        iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                        iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.StorageMediaImageResize);
                        iMIXConfigurationInfo.ConfigurationValue = this.txtSMResize.Text.Trim();
                        list.Add(iMIXConfigurationInfo);
                        isChecked = this.chkIsBarcodeActive.IsChecked;
                        int arg_4F4_0;
                        if (isChecked.GetValueOrDefault())
                        {
                            arg_4F4_0 = ((arg_32F_0 = isChecked.HasValue) ? 1 : 0);
                            if (false)
                            {
                                goto IL_32F;
                            }
                        }
                        else
                        {
                            arg_4F4_0 = 0;
                        }
                        flag = (arg_4F4_0 == 0);
                        arg_4FA_0 = flag;
                    IL_4FA:
                        if (!arg_4FA_0)
                        {
                            if (true)
                            {
                                iMIXConfigurationInfo = new iMIXConfigurationInfo();
                                iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                                iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.DefaultMappingCode);
                                iMIXConfigurationInfo.ConfigurationValue = Convert.ToString(this.cmbMappingType.SelectedValue);
                                list.Add(iMIXConfigurationInfo);
                                iMIXConfigurationInfo = new iMIXConfigurationInfo();
                                iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                                iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.ScanType);
                                iMIXConfigurationInfo.ConfigurationValue = Convert.ToString(this.cmbScanType.SelectedValue);
                                list.Add(iMIXConfigurationInfo);
                                iMIXConfigurationInfo = new iMIXConfigurationInfo();
                                iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                                iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.LostImgTimeGap);
                                iMIXConfigurationInfo.ConfigurationValue = text;
                                list.Add(iMIXConfigurationInfo);
                                goto IL_694;
                            }
                        }
                        else
                        {
                            iMIXConfigurationInfo = new iMIXConfigurationInfo();
                            iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                        }
                        iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.DefaultMappingCode);
                        iMIXConfigurationInfo.ConfigurationValue = "0";
                        list.Add(iMIXConfigurationInfo);
                        iMIXConfigurationInfo = new iMIXConfigurationInfo();
                        iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                        iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.ScanType);
                        iMIXConfigurationInfo.ConfigurationValue = "0";
                        list.Add(iMIXConfigurationInfo);
                        iMIXConfigurationInfo = new iMIXConfigurationInfo();
                        iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                        iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.LostImgTimeGap);
                        iMIXConfigurationInfo.ConfigurationValue = "0";
                        list.Add(iMIXConfigurationInfo);
                    IL_694:
                        int arg_6C8_0;
                        if (!this.chkIsOnline.IsChecked.HasValue)
                        {
                            if ((arg_39E_0 = (arg_6C8_0 = 0)) != 0)
                            {
                                goto IL_39E;
                            }
                        }
                        else
                        {
                            arg_6C8_0 = (this.chkIsOnline.IsChecked.Value ? 1 : 0);
                        }
                        bool onlineStatus = arg_6C8_0 != 0;
                        this.SaveSystemOnlineStatus(onlineStatus);
                        iMIXConfigurationInfo = new iMIXConfigurationInfo();
                        iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                        iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.DgServiceURL);
                        iMIXConfigurationInfo.ConfigurationValue = this.txtDgServiceUrl.Text;
                        list.Add(iMIXConfigurationInfo);
                        iMIXConfigurationInfo = new iMIXConfigurationInfo();
                        iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                        iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.IsAnonymousQrCodeEnabled);
                        iMIXConfigurationInfo.ConfigurationValue = this.chkAnonymousQrCode.IsChecked.ToString();
                        list.Add(iMIXConfigurationInfo);
                        iMIXConfigurationInfo = new iMIXConfigurationInfo();
                        iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                        iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.IsPrepaidAutoPurchaseActive);
                        iMIXConfigurationInfo arg_7B0_0 = iMIXConfigurationInfo;
                        isChecked = this.chkIsAutoPurchaseActive.IsChecked;
                        arg_7B0_0.ConfigurationValue = isChecked.ToString();
                        list.Add(iMIXConfigurationInfo);
                        if (false)
                        {
                            goto IL_1BF;
                        }
                        iMIXConfigurationInfo = new iMIXConfigurationInfo();
                        iMIXConfigurationInfo.SubstoreId = LoginUser.SubStoreId;
                        iMIXConfigurationInfo.IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.QRCodeLengthSetting);
                        iMIXConfigurationInfo.ConfigurationValue = this.txtQRCodeLen.Text.ToString();
                        list.Add(iMIXConfigurationInfo);
                        new ConfigBusiness().SaveUpdateNewConfig(list);
                        StoreSubStoreDataBusniess storeSubStoreDataBusniess = new StoreSubStoreDataBusniess();
                        bool flag2 = storeSubStoreDataBusniess.UpdateQRCodeWebUrl(this.txtQRCodeWebUrl.Text.Trim());
                        if (flag2)
                        {
                            System.Windows.MessageBox.Show("All details saved successfully");
                        }
                        Login login = new Login();
                        login.SetAnonymousQrCodeEnableStatus(LoginUser.SubStoreId);
                    IL_866:
                        return;
                    }
                    System.Windows.MessageBox.Show("Please Select Scan Type");
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool ReadSystemOnlineStatus()
        {
            bool result = false;
            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                bool expr_31 = !File.Exists(directoryName + "\\Config.dat");
                bool flag;
                if (!false)
                {
                    flag = expr_31;
                }
                if (!flag)
                {
                    StreamReader streamReader = new StreamReader(directoryName + "\\Config.dat");
                    try
                    {
                        string text = streamReader.ReadLine();
                        result = text.Split(new char[]
                        {
                            ','
                        })[1].ToBoolean(false);
                    }
                    finally
                    {
                        flag = (streamReader == null);
                        if (!flag)
                        {
                            ((IDisposable)streamReader).Dispose();
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            return result;
        }

        private void SaveSystemOnlineStatus(bool onlineStatus)
        {
            try
            {
                string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (File.Exists(directoryName + "\\Config.dat"))
                {
                    File.Delete(directoryName + "\\Config.dat");
                }
                StreamWriter streamWriter = new StreamWriter(File.Open(directoryName + "\\Config.dat", FileMode.Create));
                try
                {
                    string text = "";
                    text = text + "," + onlineStatus.ToString();
                    streamWriter.Write("IsMachineOnline" + text);
                    if (!false)
                    {
                        streamWriter.Close();
                    }
                }
                finally
                {
                    bool arg_A0_0 = streamWriter == null;
                    bool expr_A2;
                    do
                    {
                        bool flag = arg_A0_0;
                        expr_A2 = (arg_A0_0 = flag);
                    }
                    while (false);
                    if (!expr_A2)
                    {
                        ((IDisposable)streamWriter).Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                System.Windows.MessageBox.Show(ex.Message);
            }
        }

        private bool ValidateImageResizePercent(string val)
        {
            bool result;
            if (false || !false)
            {
                result = false;
                try
                {
                    int num = val.ToInt32(false);
                    int arg_14_0 = 1;
                    int arg_14_1 = 0;
                    bool flag;
                    int expr_57;
                    int expr_1F;
                    do
                    {
                        flag = (arg_14_0 == arg_14_1);
                        if (false)
                        {
                            goto IL_3D;
                        }
                        expr_57 = (arg_14_0 = num);
                        expr_1F = (arg_14_1 = 0);
                    }
                    while (expr_1F != 0);
                    bool arg_37_0;
                    bool arg_5D_0;
                    if (expr_57 > expr_1F)
                    {
                        arg_5D_0 = (arg_37_0 = (num > 100));
                        if (false)
                        {
                            goto IL_37;
                        }
                    }
                    else
                    {
                        arg_5D_0 = true;
                    }
                    if (-1 != 0)
                    {
                        flag = arg_5D_0;
                    }
                    arg_37_0 = flag;
                IL_37:
                    if (!arg_37_0)
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                IL_3D:;
                }
                catch
                {
                    do
                    {
                        result = false;
                    }
                    while (false);
                }
            }
            return result;
        }

        private void FillOnlineTabInfo()
        {
            while (7 != 0)
            {
                this.txtQRCodeWebUrl.Text = new StoreSubStoreDataBusniess().GetQRCodeWebUrl();
                List<ValueTypeInfo> scanTypes;
                if (!false)
                {
                    List<ValueTypeInfo> cardTypes = new CardBusiness().GetCardTypes();
                    CommonUtility.BindComboWithSelect(this.cmbMappingType, cardTypes, 400, ClientConstant.SelectString);
                    if (4 == 0)
                    {
                        continue;
                    }
                    scanTypes = new ValueTypeBusiness().GetScanTypes();
                }
                while (!false)
                {
                    CommonUtility.BindComboWithSelect(this.cmbScanType, scanTypes, 500, ClientConstant.SelectString);
                    if (-1 != 0)
                    {
                        this.cmbMappingType.SelectedValue = "400";
                        this.cmbScanType.SelectedValue = "500";
                        this.txtOnlineResize.Text = "70";
                        goto IL_AF;
                    }
                }
                goto IL_C4;
            IL_AF:
                break;
            IL_C4:
                this.chkIsOnline.IsChecked = new bool?(this.ReadSystemOnlineStatus());
                return;
            }
            if (!false)
            {
                this.txtSMResize.Text = "70";
                //goto IL_C4;
            }
            //goto IL_AF;
        }

        private void chkIsAutoPurchaseActive_Checked(object sender, RoutedEventArgs e)
        {
            this.chkAnonymousQrCode.IsChecked = new bool?(false);
        }

        private void chkAnonymousQrCode_Checked(object sender, RoutedEventArgs e)
        {
            this.chkIsAutoPurchaseActive.IsChecked = new bool?(false);
        }

        private void btnSaveVenueChanges_Click(object sender, RoutedEventArgs e)
        {
            StoreInfo storeInfo = new StoreInfo();
            int arg_2AE_0 = 0;
            int arg_AC_0 = 0;
            int arg_3F_0 = 0;
            int expr_0C = arg_3F_0 = (arg_AC_0 = (arg_2AE_0 = 0));
            long taxMinSequenceNo = 0;
            long taxMaxSequenceNo = 0;
            if (expr_0C == 0)
            {
                taxMinSequenceNo = (long)expr_0C;
                taxMaxSequenceNo = 0L;
                arg_AC_0 = (arg_3F_0 = (arg_2AE_0 = (string.IsNullOrEmpty(this.txtBillReceiptTitle.Text.Trim()) ? 1 : 0)));
            }
            int arg_AC_1 = 0;
            int expr_36 = arg_AC_1 = 0;
            int arg_2AE_1 = 0;
            int arg_101_0 = 0;
            bool arg_B2_0 = false;
            if (expr_36 == 0)
            {
                arg_2AE_1 = expr_36;
                if (expr_36 != 0)
                {
                    goto IL_2AE;
                }
                if (arg_3F_0 != expr_36)
                {
                    System.Windows.MessageBox.Show("Please enter receipt titile");
                    return;
                }
                if (!this.chkSequenceNoReqd.IsChecked.Value)
                {
                    goto IL_159;
                }
                bool expr_8C = (arg_101_0 = (string.IsNullOrEmpty(this.txtMinSeqNo.Text.Trim()) ? 1 : 0)) != 0;
                if (4 == 0)
                {
                    goto IL_101;
                }
                if (expr_8C)
                {
                    arg_B2_0 = false;
                    goto IL_B1;
                }
                arg_AC_0 = (string.IsNullOrEmpty(this.txtMaxSeq.Text.Trim()) ? 1 : 0);
                arg_AC_1 = 0;
            }
            arg_B2_0 = (arg_AC_0 == arg_AC_1);
        IL_B1:
            if (!arg_B2_0)
            {
                System.Windows.MessageBox.Show("Please enter min and max invoice number");
                return;
            }
            int arg_F6_0;
            bool arg_145_0 = ((!long.TryParse(this.txtMinSeqNo.Text, out taxMinSequenceNo)) ? (arg_F6_0 = 0) : (arg_F6_0 = (long.TryParse(this.txtMaxSeq.Text, out taxMaxSequenceNo) ? 1 : 0))) != 0;
            if (6 != 0)
            {
                if (arg_F6_0 == 0)
                {
                    taxMinSequenceNo = 0L;
                    arg_101_0 = 0;
                    goto IL_101;
                }
                bool flag = this.txtMinSeqNo.Text.Trim().ToInt64(false) < this.txtMaxSeq.Text.Trim().ToInt64(false);
                arg_145_0 = flag;
            }
            if (!arg_145_0)
            {
                System.Windows.MessageBox.Show("Max invoice number should be greater than min invoice number");
                return;
            }
            goto IL_159;
        IL_101:
            taxMaxSequenceNo = (long)arg_101_0;
            System.Windows.MessageBox.Show("Invoice number should be numeric");
            return;
        IL_159:
            storeInfo.IsTaxEnabled = this.chkTaxEnabled.IsChecked.Value;
            storeInfo.RunVideoProcessingEngineLocationWise = this.chkRunvideoProcessingEngineLocationWise.IsChecked.Value;
            storeInfo.BillReceiptTitle = this.txtBillReceiptTitle.Text;
            storeInfo.Address = this.txtAddress.Text;
            storeInfo.PhoneNo = this.txtPhoneNo.Text;
            storeInfo.TaxRegistrationNumber = this.txtTaxRegistrationNo.Text;
            if (!false)
            {
                storeInfo.TaxRegistrationText = this.txtTaxRegistrationText.Text;
                storeInfo.IsSequenceNoRequired = this.chkSequenceNoReqd.IsChecked;
                storeInfo.TaxMinSequenceNo = taxMinSequenceNo;
                if (false)
                {
                    goto IL_2A3;
                }
                storeInfo.TaxMaxSequenceNo = taxMaxSequenceNo;
                if (7 == 0)
                {
                    goto IL_2B6;
                }
                storeInfo.EmailID = this.txtEmail.Text;
                storeInfo.WebsiteURL = this.txtWebsiteURL.Text;
                storeInfo.ServerHotFolderPath = this.txtServerHotFolder.Text;
                storeInfo.IsActiveStockShot = this.chkStockShot.IsChecked.Value;
            }
            storeInfo.RunImageProcessingEngineLocationWise = this.chkImageProssingEngineLocWise.IsChecked.Value;
            storeInfo.IsTaxIncluded = this.chkIsTaxIncluded.IsChecked.Value;
        IL_2A3:
            bool flag2 = this.UpdateReceiptData(storeInfo);
            arg_2AE_0 = (flag2 ? 1 : 0);
            arg_2AE_1 = 0;
        IL_2AE:
            if (arg_2AE_0 == arg_2AE_1)
            {
                goto IL_2C3;
            }
        IL_2B6:
            System.Windows.MessageBox.Show("Venue configuration saved successfully");
        IL_2C3:
            this.getTaxConfigData();
        }

        private bool UpdateReceiptData(StoreInfo store)
        {
            bool arg_2D_0;
            bool flag2;
            while (4 != 0)
            {
                this.taxBusiness = new TaxBusiness();
                bool arg_4B_0;
                bool expr_3E = arg_2D_0 = (arg_4B_0 = this.taxBusiness.UpdateStoreTaxData(store));
                if (!false)
                {
                    bool flag;
                    if (!false)
                    {
                        flag = expr_3E;
                    }
                    arg_4B_0 = (arg_2D_0 = flag);
                }
                if (6 == 0)
                {
                    return arg_2D_0;
                }
                flag2 = arg_4B_0;
                if (!false)
                {
                    break;
                }
            }
            arg_2D_0 = flag2;
            return arg_2D_0;
        }

        private void getTaxConfigData()
        {
            if (-1 != 0)
            {
                new StoreInfo();
                this.taxBusiness = new TaxBusiness();
                StoreInfo taxConfigData = this.taxBusiness.getTaxConfigData();
                this.txtBillReceiptTitle.Text = taxConfigData.BillReceiptTitle;
                this.txtAddress.Text = taxConfigData.Address;
                while (true)
                {
                    if (4 != 0)
                    {
                        this.txtPhoneNo.Text = taxConfigData.PhoneNo;
                        goto IL_74;
                    }
                IL_DC:
                    this.txtMinSeqNo.Text = taxConfigData.TaxMinSequenceNo.ToString();
                    if (6 != 0)
                    {
                        this.txtWebsiteURL.Text = taxConfigData.WebsiteURL;
                        this.txtEmail.Text = taxConfigData.EmailID;
                        this.txtServerHotFolder.Text = taxConfigData.ServerHotFolderPath;
                        if (7 == 0)
                        {
                            continue;
                        }
                        this.chkStockShot.IsChecked = new bool?(taxConfigData.IsActiveStockShot);
                        this.chkImageProssingEngineLocWise.IsChecked = new bool?(taxConfigData.RunImageProcessingEngineLocationWise);
                        this.chkRunvideoProcessingEngineLocationWise.IsChecked = new bool?(taxConfigData.RunVideoProcessingEngineLocationWise);
                        if (!false)
                        {
                            break;
                        }
                    }
                IL_75:
                    this.txtTaxRegistrationNo.Text = taxConfigData.TaxRegistrationNumber;
                    this.txtTaxRegistrationText.Text = taxConfigData.TaxRegistrationText;
                    this.chkTaxEnabled.IsChecked = new bool?(taxConfigData.IsTaxEnabled);
                    this.chkSequenceNoReqd.IsChecked = taxConfigData.IsSequenceNoRequired;
                    this.txtMaxSeq.Text = taxConfigData.TaxMaxSequenceNo.ToString();
                    goto IL_DC;
                IL_74:
                    goto IL_75;
                }
                this.chkIsTaxIncluded.IsChecked = new bool?(taxConfigData.IsTaxIncluded);
                if (this.chkTaxEnabled.IsChecked.Equals(true))
                {
                    this.chkIsTaxIncluded.IsEnabled = true;
                    return;
                }
                this.chkIsTaxIncluded.IsEnabled = false;
            }
            this.chkIsTaxIncluded.IsChecked = new bool?(false);
        }

        private void chkSequenceNoReqd_Click(object sender, RoutedEventArgs e)
        {
        }

        private void FillSceneProductCombo()
        {
            if (!false)
            {
                if (4 != 0)
                {
                    try
                    {
                        List<ProductTypeInfo> productType = new ProductBusiness().GetProductType();
                        List<ProductTypeInfo> oList = productType.Where(delegate (ProductTypeInfo t)
                        {
                            bool? expr_4B = t.DG_IsPrimary;
                            bool? flag;
                            if (!false)
                            {
                                flag = expr_4B;
                            }
                            int arg_1C_0;
                            int arg_3D_0 = (!flag.GetValueOrDefault()) ? (arg_1C_0 = 0) : (arg_1C_0 = (flag.HasValue ? 1 : 0));
                            int arg_44_0;
                            if (8 != 0)
                            {
                                if (arg_1C_0 != 0)
                                {
                                    int arg_26_0;
                                    arg_3D_0 = (arg_26_0 = (arg_44_0 = t.DG_Orders_ProductType_pkey));
                                    while (true)
                                    {
                                        if (arg_26_0 != 1)
                                        {
                                            arg_3D_0 = (arg_26_0 = (arg_44_0 = ((t.DG_Orders_ProductType_pkey == 2) ? 1 : 0)));
                                            if (false)
                                            {
                                                continue;
                                            }
                                        }
                                        else
                                        {
                                            arg_3D_0 = 1;
                                        }
                                        if (!false)
                                        {
                                            goto IL_39;
                                        }
                                        goto IL_3C;
                                    }
                                    goto IL_41;
                                }
                                arg_3D_0 = 0;
                            }
                        IL_39:
                        IL_3C:
                            bool flag2 = arg_3D_0 != 0;
                            arg_44_0 = (arg_3D_0 = (flag2 ? 1 : 0));
                        IL_41:
                            if (!false)
                            {
                                return arg_44_0 != 0;
                            }
                            goto IL_39;
                        }).ToList<ProductTypeInfo>();
                        CommonUtility.BindComboWithSelect<ProductTypeInfo>(this.CmbSceneProductType, oList, "DG_Orders_ProductType_Name", "DG_Orders_ProductType_pkey", 0, ClientConstant.SelectString);
                        while (4 == 0)
                        {
                        }
                        this.CmbSceneProductType.SelectedIndex = 0;
                    }
                    catch (Exception serviceException)
                    {
                        if (6 != 0 && 6 != 0)
                        {
                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                    }
                }
            }
        }

        private void GetBorderDetailsScene()
        {
            try
            {
                ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(BorderCaches).FullName);
                List<BorderInfo> list = (List<BorderInfo>)factory.GetData();
                bool arg_38_0 = list == null;
                while (true)


                {
                    bool flag = !arg_38_0;
                    while (true)


                    {
                        bool expr_3F = arg_38_0 = flag;

                        if (-1 == 0)
                        {
                            break;
                        }
                        if (!expr_3F)
                        {
                            goto IL_46;
                        }
                    IL_9A:
                        this.lstBorderListScene = (from o in list
                                                   where o.DG_IsActive
                                                   select o).ToList<BorderInfo>();
                        if (!false)
                        {
                            if (!false)
                            {
                                goto IL_D8;
                            }
                            continue;
                        }
                    IL_46:
                        if (-1 == 0)
                        {
                            goto IL_125;
                        }
                        List<BorderInfo> borderDetails = new BorderBusiness().GetBorderDetails();
                        this.lstBorderListScene = borderDetails;
                        this.lstBorderListScene = (from o in this.lstBorderListScene
                                                   where o.DG_IsActive
                                                   select o).ToList<BorderInfo>();
                        if (-1 != 0)
                        {
                            goto Block_5;
                        }
                        goto IL_9A;
                    }
                }
            Block_5:
            IL_D8:
                this.lstBorderListScene.ForEach(delegate (BorderInfo x)
                {
                    x.FilePath = Path.Combine(LoginUser.DigiFolderFramePath, x.DG_Border);
                });
                CommonUtility.BindComboWithSelect<BorderInfo>(this.CmbBorderType, this.lstBorderListScene, "DG_Border", "DG_Borders_pkey", 0, ClientConstant.SelectString);
            IL_125:
                this.CmbBorderType.SelectedIndex = 0;
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

        private void CmbBorderType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool arg_138_0;
            if (this.CmbBorderType.SelectedValue != null)
            {
                arg_138_0 = (Convert.ToInt16(this.CmbBorderType.SelectedValue) <= 0);
            }
            else
            {
                if (false)
                {
                    goto IL_F4;
                }
                arg_138_0 = true;
            }
            if (arg_138_0)
            {
                return;
            }
            this.ImgBorder.Source = null;
            int selectedval = this.CmbBorderType.SelectedValue.ToInt32(false);
            string filePath = (from x in this.lstBorderListScene.AsQueryable<BorderInfo>()
                               where x.DG_Borders_pkey == selectedval
                               select x).SingleOrDefault<BorderInfo>().FilePath;
            if (!File.Exists(filePath))
            {
                return;
            }
        IL_F4:
            this.ImgBorder.Source = new BitmapImage(new Uri(filePath, UriKind.Absolute));
        }

        private void CmbBackgroundType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            while (true)
            {
                if (this.CmbBackgroundType.SelectedValue != null)
                {
                    goto IL_12;
                }
                bool arg_140_0 = true;
            IL_32:
                if (!arg_140_0)
                {
                    if (6 != 0)
                    {
                    IL_50:
                        int selectedval;
                        while (!false)
                        {
                            selectedval = this.CmbBackgroundType.SelectedValue.ToInt32(false);
                            string filepath;
                            bool flag;
                            do
                            {
                                filepath = (from x in this.lstmainBGListScene.AsQueryable<BGMaster>()
                                            where x.BgID == selectedval
                                            select x).SingleOrDefault<BGMaster>().Filepath;
                                if (false)
                                {
                                    goto IL_50;
                                }
                                flag = !File.Exists(filepath);
                            }
                            while (-1 == 0);
                            if (!flag)
                            {
                                this.ImgBacground.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
                            }
                            goto IL_10F;
                        }
                        goto IL_12;
                    }
                    continue;
                }
            IL_10F:
                if (!false)
                {
                    break;
                }
                continue;
            IL_12:
                arg_140_0 = (Convert.ToInt16(this.CmbBackgroundType.SelectedValue) <= 0);
                if (!false)
                {
                    goto IL_32;
                }
                goto IL_32;
            }
        }

        private void GetBackGroundDetailsScene()
        {
            try
            {
                ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(BackgroundCache).FullName);
                List<BackGroundInfo> list = (List<BackGroundInfo>)factory.GetData();
                if (list == null)
                {
                    List<BackGroundInfo> backgoundDetails = new BackgroundBusiness().GetBackgoundDetails();
                    List<BackGroundInfo>.Enumerator enumerator = backgoundDetails.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            BackGroundInfo current = enumerator.Current;
                            while (true)
                            {
                                while (true)
                                {
                                    int arg_7A_0 = current.DG_Background_IsActive.HasValue ? 1 : 0;
                                    bool arg_96_0;
                                    do
                                    {
                                        arg_96_0 = (((arg_7A_0 == 0) ? (arg_7A_0 = 1) : (arg_7A_0 = ((!current.DG_Background_IsActive.Value) ? 1 : 0))) != 0);
                                    }
                                    while (5 == 0);
                                    if (arg_96_0)
                                    {
                                        goto IL_107;
                                    }
                                    if (6 != 0)
                                    {
                                        BGMaster bGMaster = new BGMaster();
                                        bGMaster.BgDisplayName = current.DG_BackGround_Image_Display_Name;
                                        bGMaster.BgID = current.DG_Background_pkey;
                                        bGMaster.BgName = current.DG_BackGround_Image_Name;
                                        bGMaster.Filepath = Path.Combine(LoginUser.DigiFolderBackGroundPath, "Thumbnails", current.DG_BackGround_Image_Name);
                                        this.lstmainBGListScene.Add(bGMaster);
                                        if (!false)
                                        {
                                            if (4 != 0)
                                            {
                                                goto IL_107;
                                            }
                                        }
                                    }
                                }
                            }
                        IL_107:;
                        }
                    }
                    finally
                    {
                        if (3 != 0)
                        {
                            ((IDisposable)enumerator).Dispose();
                        }
                    }
                }
                else
                {
                    while (false)
                    {
                    }
                    foreach (BackGroundInfo current in list)
                    {
                        if (current.DG_Background_IsActive.HasValue && current.DG_Background_IsActive.Value)
                        {
                            BGMaster bGMaster = new BGMaster();
                            bGMaster.BgDisplayName = current.DG_BackGround_Image_Display_Name;
                            bGMaster.BgID = current.DG_Background_pkey;
                            bGMaster.BgName = current.DG_BackGround_Image_Name;
                            bGMaster.Filepath = Path.Combine(LoginUser.DigiFolderBackGroundPath, "Thumbnails", current.DG_BackGround_Image_Name);
                            this.lstmainBGListScene.Add(bGMaster);
                        }
                    }
                }
                CommonUtility.BindComboWithSelect<BGMaster>(this.CmbBackgroundType, this.lstmainBGListScene, "BgDisplayName", "BgID", 0, ClientConstant.SelectString);
                this.CmbBackgroundType.SelectedIndex = 0;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                if (!false)
                {
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private static BitmapImage GetImage(string imageUri)
        {
            BitmapImage result;
            while (true)
            {
                imageUri.Replace(" ", "");
                while (true)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    if (!false)
                    {
                        bitmapImage.BeginInit();
                        if (false)
                        {
                            break;
                        }
                        if (4 != 0)
                        {
                            bitmapImage.UriSource = new Uri("pack://siteoforigin:,,,/" + imageUri, UriKind.RelativeOrAbsolute);
                        }
                        bitmapImage.EndInit();
                        while (2 == 0)
                        {
                        }
                        result = bitmapImage;
                        if (3 != 0)
                        {
                            return result;
                        }
                    }
                }
            }
            return result;
        }

        private void CmbSceneProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool flag;
            if (!false)
            {
                if (5 == 0)
                {
                    goto IL_36;
                }
                short arg_64_0;
                if (this.CmbSceneProductType.SelectedValue != null)
                {
                    int arg_27_0 = 0;
                    int expr_5D = (int)(arg_27_0 = (arg_64_0 = Convert.ToInt16(this.CmbSceneProductType.SelectedValue)));
                    if (!false)
                    {
                        if (false)
                        {
                            goto IL_2C;
                        }
                        arg_27_0 = ((expr_5D > 0) ? 1 : 0);
                    }
                    int arg_46_0;
                    arg_64_0 = (short)(arg_46_0 = ((arg_27_0 == 0) ? 1 : 0));
                }
                else
                {
                    int arg_46_0;
                    arg_64_0 = (short)(arg_46_0 = 1);
                }
            IL_2C:
                if (false)
                {
                    return;
                }
                flag = (arg_64_0 != 0);
            }
            if (flag)
            {
                return;
            }
        IL_36:
            this.CmbSceneProductType.SelectedValue.ToInt32(false);
        }

        private bool CheckSceneValidations()
        {
            while (true)
            {
                bool arg_FD_0 = !string.IsNullOrEmpty(this.txtSceneName.Text);
                int arg_BF_0;
                while (true)
                {
                    bool flag = arg_FD_0;
                    if (false)
                    {
                        goto IL_6C;
                    }
                    if (4 == 0)
                    {
                        goto IL_D9;
                    }
                    if (!flag)
                    {
                        goto Block_2;
                    }
                    bool arg_B3_0;
                    int expr_5D = (arg_B3_0 = (this.CmbSceneProductType.SelectedValue.ToString() == "0")) ? 1 : 0;
                    int arg_B3_1;
                    int expr_63 = arg_B3_1 = 0;
                    if (expr_63 != 0)
                    {
                        goto IL_B3;
                    }
                    if (expr_5D != expr_63)
                    {
                        goto IL_6C;
                    }
                    if (!(this.CmbBackgroundType.SelectedValue.ToString() == "0"))
                    {
                        arg_B3_0 = (this.CmbBorderType.SelectedValue.ToString() == "0");
                        arg_B3_1 = 0;
                        goto IL_B3;
                    }
                    arg_FD_0 = ((arg_BF_0 = 0) != 0);
                IL_B8:
                    if (2 != 0)
                    {
                        break;
                    }
                    continue;
                IL_B3:
                    arg_FD_0 = ((arg_BF_0 = (((arg_B3_0 ? 1 : 0) == arg_B3_1) ? 1 : 0)) != 0);
                    goto IL_B8;
                }
                if (arg_BF_0 != 0)
                {
                    goto IL_D9;
                }
                if (6 != 0)
                {
                    goto IL_CA;
                }
            }
        Block_2:
            System.Windows.MessageBox.Show("Please Enter Scene Name");
            bool result = false;
            goto IL_DE;
        IL_6C:
            System.Windows.MessageBox.Show("Please Select Product Type");
            result = false;
            goto IL_DE;
        IL_CA:
            System.Windows.MessageBox.Show("Please Select Either Background or Border");
            result = false;
            goto IL_DE;
        IL_D9:
            result = true;
        IL_DE:
            if (true)
            {
                return result;
            }
            goto IL_CA;
        }

        private void btnCancelSelectScene_Click(object sender, RoutedEventArgs e)
        {
            this.CmbSceneProductType.SelectedValue = "0";
            if (!false)
            {
                do
                {
                    this.CmbBackgroundType.SelectedValue = "0";
                    do
                    {
                        this.CmbBorderType.SelectedValue = "0";
                    }
                    while (false);
                    if (!false)
                    {
                        this.IsSceneActive.IsChecked = new bool?(true);
                    }
                    this.ImgBorder.Source = null;
                    do
                    {
                        this.ImgBacground.Source = null;
                    }
                    while (-1 == 0);
                }
                while (false);
                this.txtSceneName.Text = string.Empty;
            }
            this.sceneId = 0;
        }

        private void btnEditScene_Click(object sender, RoutedEventArgs e)
        {
            this.isEditScene = true;
            try
            {
                new System.Windows.Controls.Button();
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                this.sceneId = button.Tag.ToInt32(false);
                this.isEditScene = true;
                this.IsSceneActive.IsChecked = new bool?(false);
                System.Windows.Controls.Button button2 = (System.Windows.Controls.Button)sender;
                SceneInfo sceneList = new SceneBusiness().GetSceneNameFromID((int)button2.Tag);
                this.CmbSceneProductType.SelectedValue = sceneList.ProductId;
                this.CmbBackgroundType.SelectedValue = sceneList.BackGroundId;
                this.CmbBorderType.SelectedValue = sceneList.BorderId;
                this.txtSceneName.Text = sceneList.SceneName;
                string filepath = (from x in this.lstmainBGListScene.AsQueryable<BGMaster>()
                                   where x.BgID == sceneList.BackGroundId
                                   select x).SingleOrDefault<BGMaster>().Filepath;
                string filePath = (from x in this.lstBorderListScene.AsQueryable<BorderInfo>()
                                   where x.DG_Borders_pkey == sceneList.BorderId
                                   select x).SingleOrDefault<BorderInfo>().FilePath;
                if (File.Exists(filePath))
                {
                    this.ImgBorder.Source = new BitmapImage(new Uri(filePath, UriKind.Absolute));
                }
                if (File.Exists(filepath))
                {
                    this.ImgBacground.Source = new BitmapImage(new Uri(filepath, UriKind.Absolute));
                }
                if (sceneList.IsActive)
                {
                    this.IsSceneActive.IsChecked = new bool?(true);
                }
            }
            catch (Exception var_5_2BE)
            {
                this.isEditScene = false;
            }
        }

        private void btnDeleteScene_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                while (true)
                {
                IL_02:
                    bool expr_16 = System.Windows.MessageBox.Show("Do you want to delete this Scene?", "Confirm delete", MessageBoxButton.YesNo) != MessageBoxResult.Yes;
                    bool flag;
                    if (2 != 0)
                    {
                        flag = expr_16;
                    }
                    bool arg_24_0 = flag;
                    while (!arg_24_0)
                    {
                        System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                        while (true)
                        {
                            this.sceneId = (int)button.Tag;
                            if (2 == 0)
                            {
                                goto IL_02;
                            }
                            bool expr_60 = arg_24_0 = new SceneBusiness().DeleteScene(this.sceneId);
                            if (false)
                            {
                                break;
                            }
                            bool flag2 = expr_60;
                            flag = !flag2;
                            if (!flag)
                            {
                                System.Windows.MessageBox.Show("Scene deleted successfully");
                            }
                            this.DGManageScene.ItemsSource = new SceneBusiness().GetSceneDetails();
                            this.CmbSceneProductType.SelectedValue = "0";
                            if (false)
                            {
                                goto IL_11B;
                            }
                            this.CmbBackgroundType.SelectedValue = "0";
                            while (!false)
                            {
                                this.CmbBorderType.SelectedValue = "0";
                                this.IsSceneActive.IsChecked = new bool?(true);
                                this.ImgBorder.Source = null;
                                this.ImgBacground.Source = null;
                                this.txtSceneName.Text = string.Empty;
                                if (!false)
                                {
                                    goto Block_7;
                                }
                            }
                        }
                    }
                    goto IL_11A;
                }
            Block_7:
                this.sceneId = 0;
            IL_11A:
            IL_11B:;
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

        private void btnSaveSelectScene_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool expr_0D = !this.CheckSceneValidations();
                bool flag;
                if (!false)
                {
                    flag = expr_0D;
                }
                if (!flag)
                {
                    int expr_204 = Convert.ToInt32(this.CmbSceneProductType.SelectedValue);
                    int num;
                    if (3 != 0)
                    {
                        num = expr_204;
                    }
                    int backGroundId = Convert.ToInt32(this.CmbBackgroundType.SelectedValue);
                    int num2 = Convert.ToInt32(this.CmbBorderType.SelectedValue);
                    int graphicsId = 0;
                    string text = this.txtSceneName.Text;
                    string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.Scene).ToString().PadLeft(2, '0'), "1", "1", "00");
                    SceneInfo sceneInfo = new SceneInfo();
                    sceneInfo.ProductId = num;
                    sceneInfo.BackGroundId = backGroundId;
                    sceneInfo.BorderId = num2;
                    sceneInfo.GraphicsId = graphicsId;
                    do
                    {
                        sceneInfo.SyncCode = uniqueSynccode;
                        sceneInfo.IsSynced = false;
                        sceneInfo.IsActive = this.IsSceneActive.IsChecked.Value;
                        sceneInfo.SceneName = text;
                        sceneInfo.SceneId = this.sceneId;
                        new SceneBusiness().SetSceneDetails(sceneInfo);
                        System.Windows.MessageBox.Show("Record saved successfully");
                        this.DGManageScene.ItemsSource = null;
                        SceneBusiness sceneBusiness = new SceneBusiness();
                        this.DGManageScene.ItemsSource = sceneBusiness.GetSceneDetails();
                        this.CmbSceneProductType.SelectedValue = "0";
                    }
                    while (-1 == 0);
                    this.CmbBackgroundType.SelectedValue = "0";
                    this.CmbBorderType.SelectedValue = "0";
                    this.IsSceneActive.IsChecked = new bool?(true);
                    this.ImgBorder.Source = null;
                    this.ImgBacground.Source = null;
                    this.txtSceneName.Text = string.Empty;
                    this.sceneId = 0;
                }
            }
            catch (Exception serviceException)
            {
                string message;
                if (!false)
                {
                    message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                }
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnBackScene_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnResetCharacter_Click(object sender, RoutedEventArgs e)
        {
            this.clearCharacterData();
        }

        private void btnBackCharacter_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btnEditCharacter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.isEditCharacter = true;
                //new System.Windows.Controls.Button();
                //System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                //this.CharacterId = button.Tag.ToInt32(false);
                this.CharacterId = ((CharacterInfo)DGCharacter.SelectedValue).DG_Character_Pkey.ToInt32(false);
                this.hdnIDCharacter.Text = this.CharacterId.ToString();


                this.isEditCharacter = true;
                this.IsSceneActive.IsChecked = new bool?(false);
                CharacterInfo obj = new CharacterInfo
                {
                    DG_Character_Pkey = this.CharacterId,
                    DG_Character_OperationType = 2
                };
                List<CharacterInfo> character = new CharacterBusiness().GetCharacter(obj);
                this.txtCharacterName.Text = character.Where(v => v.DG_Character_Pkey == this.CharacterId).FirstOrDefault<CharacterInfo>().DG_Character_Name;
                bool flag = character.Where(v => v.DG_Character_Pkey == this.CharacterId).FirstOrDefault<CharacterInfo>().DG_Character_IsActive != 1;
                if (-1 != 0)
                {
                    if (!flag)
                    {
                        this.IsCharacterActive.IsChecked = new bool?(true);
                        goto IL_F0;
                    }
                    if (character.FirstOrDefault<CharacterInfo>().DG_Character_IsActive != 0)
                    {
                        goto IL_F0;
                    }
                }
                this.IsCharacterActive.IsChecked = new bool?(false);
            IL_F0:;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            if (!false)
            {
            }
        }

        private void btnDeleteCharacter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //new System.Windows.Controls.Button();
                //System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                //this.CharacterId = button.Tag.ToInt32(false);
                this.CharacterId = ((CharacterInfo)DGCharacter.SelectedValue).DG_Character_Pkey.ToInt32(false);

                CharacterInfo characterInfo;
                if (5 != 0)
                {
                    characterInfo = new CharacterInfo();
                    characterInfo.DG_Character_Pkey = this.CharacterId;
                    if (-1 != 0)
                    {
                        characterInfo.DG_Character_OperationType = 3;
                    }
                }
                CharacterInfo obj = characterInfo;
                bool val = new CharacterBusiness().DeleteCharacter(characterInfo);


                List<CharacterInfo> character = new CharacterBusiness().GetCharacter(obj);
                this.BindCharacterGrid();
            }
            catch (Exception serviceException)
            {
                string message;
                if (true)
                {
                    message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    goto IL_90;
                }
            IL_98:
                while (!false)
                {
                    if (3 != 0)
                    {
                        if (!false)
                        {
                            return;
                        }
                        break;
                    }
                }
            IL_90:
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                goto IL_98;
            }
        }

        private void btnSaveCharacter_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (8 != 0)
                {
                }
                bool arg_186_0;
                if (!string.IsNullOrEmpty(this.txtCharacterName.Text))
                {
                    arg_186_0 = true;
                    goto IL_35;
                }
            IL_1B:
                arg_186_0 = !string.IsNullOrWhiteSpace(this.txtCharacterName.Text);
            IL_35:
                bool flag = arg_186_0;
                if (false)
                {
                    goto IL_11F;
                }
                if (flag)
                {
                    goto IL_59;
                }
            IL_49:
                System.Windows.MessageBox.Show("Please Enter Character Name");
                return;
            IL_59:
                CharacterInfo charInfo;
                if (this.txtCharacterName.Text.Length > 25)
                {
                    System.Windows.MessageBox.Show("Character length should be less than 25");
                }
                else if (!this.ValidateCharacter(this.txtCharacterName.Text.Trim()))
                {
                    System.Windows.MessageBox.Show("Please Enter Valid Character Name.");
                }
                else
                {
                    CharacterInfo characterInfo = new CharacterInfo();
                    characterInfo.DG_Character_Name = this.txtCharacterName.Text.ToUpper().Trim();
                    if (!false)
                    {
                        characterInfo.DG_Character_IsActive = (int)Convert.ToInt16(this.IsCharacterActive.IsChecked);
                        charInfo = characterInfo;
                        goto IL_FA;
                    }
                    goto IL_1B;
                }
                return;
            IL_FA:
                bool flag2 = false;
                if (String.IsNullOrEmpty(this.hdnIDCharacter.Text))
                {



                    flag2 = new CharacterBusiness().InsertCharacter(charInfo);
                }
                else
                {
                    charInfo.DG_Character_Pkey = Convert.ToInt32(this.hdnIDCharacter.Text);
                    flag2 = new CharacterBusiness().UpdateCharacter(charInfo);
                }
                

                if (flag2)
                {
                    System.Windows.MessageBox.Show("Character Details Saved Successfully");
                    goto IL_132;
                }
            IL_11F:
                System.Windows.MessageBox.Show("Error Occured");
                if (false)
                {
                    goto IL_59;
                }
            IL_132:
                if (false)
                {
                    goto IL_49;
                }
                this.BindCharacterGrid();
                if (8 != 0)
                {
                    this.clearCharacterData();
                    if (false)
                    {
                        goto IL_FA;
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void clearCharacterData()
        {
            this.hdnIDCharacter.Text = string.Empty;

            while (8 != 0 && 5 != 0)
            {
                if (!false)
                {
                    System.Windows.Controls.TextBox expr_0C = this.txtCharacterName;
                    string expr_11 = string.Empty;
                    if (4 != 0)
                    {
                        expr_0C.Text = expr_11;
                    }
                    if (2 != 0)
                    {
                        ToggleButton expr_21 = this.IsCharacterActive;
                        bool? expr_3D = new bool?(false);
                        if (5 != 0)
                        {
                            expr_21.IsChecked = expr_3D;
                        }
                    }
                    break;
                }
            }
        }

        private void BindCharacterGrid()
        {
            try
            {
                List<CharacterInfo> character;
                if (4 != 0)
                {
                    CharacterInfo obj = new CharacterInfo
                    {
                        DG_Character_Pkey = 0,
                        DG_Character_OperationType = 1
                    };
                    character = new CharacterBusiness().GetCharacter(obj);
                }
                this.DGCharacter.ItemsSource = character;
            }
            catch (Exception serviceException)
            {
                if (false)
                {
                    goto IL_79;
                }
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
            IL_6A:
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            IL_71:
                if (!false && false)
                {
                    goto IL_6A;
                }
            IL_79:
                if (6 == 0)
                {
                    goto IL_71;
                }
            }
        }

        private bool ValidateCharacter(string inputStr)
        {
            if (!true)
            {
                goto IL_23;
            }
            Regex regex = new Regex("^[a-zA-Z0-9 ]+$");
            bool arg_2E_0;
            bool expr_3F = arg_2E_0 = regex.IsMatch(inputStr);
            if (false)
            {
                return arg_2E_0;
            }
            bool flag = expr_3F;
        IL_18:
            int arg_1A_0 = flag ? 1 : 0;
            bool flag2;
            while (arg_1A_0 == 0)
            {
                int expr_1E = arg_1A_0 = 0;
                if (expr_1E == 0)
                {
                    flag2 = (expr_1E != 0);
                    goto IL_23;
                }
            }
            flag2 = true;
            goto IL_2D;
        IL_23:
            if (false)
            {
                goto IL_18;
            }
        IL_2D:
            arg_2E_0 = flag2;
            return arg_2E_0;
        }

        private void btnSelectedStockImage_Click(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_27;
            }
            if (false)
            {
                return;
            }
        IL_10:
            Microsoft.Win32.OpenFileDialog expr_C4 = new Microsoft.Win32.OpenFileDialog();
            Microsoft.Win32.OpenFileDialog openFileDialog;
            if (-1 != 0)
            {
                openFileDialog = expr_C4;
            }
            openFileDialog.Multiselect = false;
        IL_27:
            bool? flag;
            if (8 != 0)
            {
                openFileDialog.Filter = "Image Files | *.jpg;*.png;*.gif; | Video Files | *.mp4;*.mov;*.flv;*.wmv;*.avi;*.mpeg;*.3gp;*.";
                if (5 == 0)
                {
                    goto IL_10;
                }
                flag = openFileDialog.ShowDialog();
            }
            if (flag.Value)
            {
                try
                {
                    if (openFileDialog.OpenFile() != null)
                    {
                        this.txtSelectedStockImage.Text = openFileDialog.FileName.ToString();
                        this.stockshotname = Path.GetFileName(openFileDialog.FileName);
                        this._isNewFileSelected = true;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnSaveStockShotImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string arg_51D_0 = string.Empty;
                string text = this.txtSelectedStockImage.Text.Trim();
                bool flag = !string.IsNullOrEmpty(text);
                bool arg_228_0;
                bool expr_55A = arg_228_0 = flag;
                string text2;
                MemoryStream memoryStream;
                long num;
                if (!false)
                {
                    if (!expr_55A)
                    {
                        System.Windows.MessageBox.Show("Please select image");
                        return;
                    }
                    this.configBusiness = new ConfigBusiness();
                    if (!this._iseditStockImg)
                    {
                        this.stockShotImg = new StockShot();
                        this.stockShotImg.CreatedBy = LoginUser.UserId;
                        this.stockShotImg.ImageName = this.stockshotname;
                    }
                    else
                    {
                        this.stockShotImg = new StockShot();

                        this.stockShotImg.ModifiedBy = new int?(LoginUser.UserId);
                        this.stockShotImg.ImageId = this._stockImgId;
                        this.stockShotImg.ImageName = this.txtSelectedStockImage.Text.Trim();


                    }
                    this.stockShotImg.IsActive = this.chkIsStockImageActive.IsChecked.Value;
                    text2 = Path.Combine(LoginUser.DigiFolderPath, "StockShot");
                    if (!this._isNewFileSelected)
                    {
                        this.stockshotname = this.stockShotImg.ImageName;
                        if (String.IsNullOrEmpty(this.hdnIDStockShot.Text))
                        {
                            this.configBusiness.SaveUpdateStockShotImage(this.stockShotImg);
                        }
                        else
                        {
                            this.stockShotImg.ImageId = Convert.ToInt32(this.hdnIDStockShot.Text);







                            this.configBusiness.SaveUpdateStockShotImage(this.stockShotImg);
                        }

                        if (!File.Exists(text2 + "\\" + this.stockShotImg.ImageName))
                        {
                            File.Copy(text, text2 + "\\" + this.stockshotname, true);
                            if (Path.GetExtension(text).ToLower().Equals(".jpg") || Path.GetExtension(text).ToLower().Equals(".png") || Path.GetExtension(text).ToLower().Equals(".gif"))
                            {
                                using (FileStream fileStream = File.OpenRead(text2 + "\\" + this.stockshotname))
                                {
                                    memoryStream = new MemoryStream();
                                    fileStream.CopyTo(memoryStream);
                                    memoryStream.Seek(0L, SeekOrigin.Begin);
                                    this.ResizeAndSaveHighQualityImage(System.Drawing.Image.FromStream(memoryStream), Path.Combine(LoginUser.DigiFolderPath, "StockShot", "Thumbnails", this.stockshotname), 100, 150);
                                    fileStream.Close();
                                    if (!false)
                                    {
                                        memoryStream.Dispose();
                                    }
                                }
                            }
                            this.CopyToAllSubstore(this.lstConfigurationInfo, text2 + "\\" + this.stockshotname, Path.Combine(LoginUser.DigiFolderPath, "StockShot", "Thumbnails", this.stockshotname), "StockShot");
                        }
                        goto IL_4BF;
                    }
                    if (String.IsNullOrEmpty(this.hdnIDStockShot.Text))
                    {
                        num = this.configBusiness.SaveUpdateStockShotImage(this.stockShotImg);
                    }
                    else
                    {
                        this.stockShotImg.ImageId = Convert.ToInt32(this.hdnIDStockShot.Text);


                        num = this.configBusiness.SaveUpdateStockShotImage(this.stockShotImg);
                    }







                    if (num <= 0L)
                    {
                        goto IL_334;
                    }
                    this.stockshotname = Path.GetFileNameWithoutExtension(this.stockshotname) + "_" + num.ToString() + Path.GetExtension(this.stockshotname);
                    string text3 = Path.Combine(text2, this.stockshotname);
                    if (4 == 0)
                    {
                        goto IL_4EA;
                    }
                    if (!Directory.Exists(text2))
                    {
                        Directory.CreateDirectory(text2);
                    }
                    if (!Directory.Exists(Path.Combine(text2, "Thumbnails")))
                    {
                        Directory.CreateDirectory(Path.Combine(text2, "Thumbnails"));
                    }
                    if (!File.Exists(text2 + "\\" + this.stockshotname))
                    {
                        File.Copy(text, text2 + "\\" + this.stockshotname, true);
                    }
                    arg_228_0 = (!Path.GetExtension(text).ToLower().Equals(".jpg") && !Path.GetExtension(text).ToLower().Equals(".png") && !Path.GetExtension(text).ToLower().Equals(".gif"));
                }
                if (!arg_228_0)
                {
                    FileStream fileStream = File.OpenRead(text2 + "\\" + this.stockshotname);
                    try
                    {
                        if (!false)
                        {
                            memoryStream = new MemoryStream();
                            fileStream.CopyTo(memoryStream);
                            memoryStream.Seek(0L, SeekOrigin.Begin);
                        }
                        this.ResizeAndSaveHighQualityImage(System.Drawing.Image.FromStream(memoryStream), Path.Combine(LoginUser.DigiFolderPath, "StockShot", "Thumbnails", this.stockshotname), 100, 150);
                        fileStream.Close();
                        memoryStream.Dispose();
                    }
                    finally
                    {
                        flag = (fileStream == null);
                        if (6 != 0)
                        {
                            if (!flag)
                            {
                                ((IDisposable)fileStream).Dispose();
                            }
                        }
                    }
                }
                this.CopyToAllSubstore(this.lstConfigurationInfo, text2 + "\\" + this.stockshotname, Path.Combine(LoginUser.DigiFolderPath, "StockShot", "Thumbnails", this.stockshotname), "StockShot");
                this.stockShotImg.ImageName = this.stockshotname;
                this.stockShotImg.ImageId = num;
                this.configBusiness.SaveUpdateStockShotImage(this.stockShotImg);

            IL_334:
            IL_4BF:
                this.hdnIDStockShot.Text = string.Empty;

                System.Windows.MessageBox.Show("Item saved successfully.");
                this.stockshotname = string.Empty;
                this.GetStockImgDetails();
                this._iseditStockImg = false;
                this._isNewFileSelected = false;
            IL_4EA:
                this.txtSelectedStockImage.Text = "";
                this.chkIsStockImageActive.IsChecked = new bool?(false);
                this.btnSelectedStockImage.IsEnabled = true;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void GetStockImgDetails()
        {
            List<StockShot> list = new List<StockShot>();
            List<StockShot> stockShotImagesList = new ConfigBusiness().GetStockShotImages();
            //List<StockShot> stockShotImagesList = new ConfigBusiness().GetStockShotImagesList(0L);

            try
            {
                using (List<StockShot>.Enumerator enumerator = stockShotImagesList.GetEnumerator())
                {
                    while (true)
                    {
                    IL_122:
                        bool arg_12F_0;
                        bool arg_BA_0;
                        bool arg_D7_0 = arg_BA_0 = (arg_12F_0 = enumerator.MoveNext());
                        StockShot current;
                        bool arg_DD_0;
                        while (6 != 0)
                        {
                            bool flag = arg_12F_0;
                            bool expr_131 = arg_BA_0 = (arg_D7_0 = (arg_12F_0 = flag));
                            if (!false)
                            {
                                if (!expr_131)
                                {
                                    goto Block_13;
                                }
                                current = enumerator.Current;
                                if (!false)
                                {
                                    StockShot stockShot = new StockShot();
                                    stockShot.ImageId = current.ImageId;
                                    stockShot.ImageName = current.ImageName;
                                    stockShot.IsActive = current.IsActive;
                                    string extension = Path.GetExtension(current.ImageName);
                                    bool expr_90 = arg_BA_0 = (arg_D7_0 = (arg_12F_0 = Path.GetExtension(current.ImageName).ToLower().Equals(".jpg")));
                                    if (false)
                                    {
                                        continue;
                                    }
                                    if (!expr_90)
                                    {
                                        arg_D7_0 = (arg_BA_0 = Path.GetExtension(current.ImageName).ToLower().Equals(".png"));
                                        break;
                                    }
                                IL_DB:
                                    arg_DD_0 = false;
                                IL_DC:
                                    if (!arg_DD_0)
                                    {
                                        stockShot.ImageThumbnailPath = Path.Combine(LoginUser.DigiFolderPath, "StockShot", "Thumbnails", current.ImageName);
                                    }
                                    else if (5 != 0)
                                    {
                                        stockShot.ImageThumbnailPath = "/PhotoSW;component/images/vidico.png";
                                    }
                                    list.Add(stockShot);
                                }
                                goto IL_122;
                            }
                        }
                        if (4 != 0)
                        {
                            if (arg_BA_0)
                            {
                                //goto IL_DB;
                            }
                            arg_D7_0 = Path.GetExtension(current.ImageName).ToLower().Equals(".gif");
                        }
                        arg_DD_0 = !arg_D7_0;
                        //goto IL_DC;
                    }
                Block_13:;
                }
                if (4 != 0)
                {
                    this.grdManagestockShotImages.ItemsSource = list;
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void GetAllSubstoreConfigdata()
        {
            try
            {
                if (6 != 0)
                {
                    this.lstConfigurationInfo = new ConfigBusiness().GetAllSubstoreConfigdata();
                }
            }
            catch (Exception serviceException)
            {
                while (true)
                {
                    if (true)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                IL_31:
                    if (8 == 0)
                    {
                        continue;
                    }
                    if (!false)
                    {
                        break;
                    }
                    goto IL_31;
                }
            }
        }

        private void btnDeleteStockShotImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool arg_104_0;
                int expr_13 = (arg_104_0 = (System.Windows.MessageBox.Show("Do you want to delete this Image?", "Confirm delete", MessageBoxButton.YesNo) == MessageBoxResult.Yes)) ? 1 : 0;
                int arg_104_1;
                int expr_16 = arg_104_1 = 0;
                if (expr_16 != 0)
                {
                    goto IL_104;
                }
                bool flag = expr_13 == expr_16;
                if (false)
                {
                    goto IL_C9;
                }
                if (flag)
                {
                    goto IL_157;
                }
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
            IL_43:
                object tag = button.Tag;
                this.configBusiness = new ConfigBusiness();
                string imageName = new ConfigBusiness().GetStockShotImagesList(Convert.ToInt64(tag)).FirstOrDefault<StockShot>().ImageName;
                string text = Path.Combine(LoginUser.DigiFolderPath, "StockShot", imageName);
                string path = Path.Combine(LoginUser.DigiFolderPath, "StockShot", "Thumbnails", imageName);
                bool arg_B4_0;
                bool expr_AB = arg_B4_0 = !File.Exists(text);
                if (!false)
                {
                    flag = expr_AB;
                    arg_B4_0 = flag;
                }
                if (!arg_B4_0)
                {
                    File.Delete(text);
                }
                flag = !File.Exists(path);
            IL_C9:
                if (!flag)
                {
                    File.Delete(path);
                }
                if (false)
                {
                    goto IL_43;
                }
                bool flag2 = this.configBusiness.DeleteStockShotImg(Convert.ToInt64(tag));
                this.DeleteFromAllSubstore(this.lstConfigurationInfo, text, "StockShot");
                arg_104_0 = flag2;
                arg_104_1 = 0;
            IL_104:
                flag = ((arg_104_0 ? 1 : 0) == arg_104_1);
                if (!flag)
                {
                    System.Windows.MessageBox.Show("Image deleted successfully");
                    this.txtSelectedStockImage.Text = "";
                    if (!true)
                    {
                        goto IL_C9;
                    }
                    this.chkIsStockImageActive.IsChecked = new bool?(false);
                    this.GetStockImgDetails();
                }
                if (!false)
                {
                    this.btnSelectedStockImage.IsEnabled = true;
                }
            IL_157:;
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Can not delete Image because " + ex.Message);
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
                if (!false)
                {
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void btnEditStockShotImage_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                new System.Windows.Controls.Button();
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                this._stockImgId = (long)button.Tag.ToInt32(false);
                this._iseditStockImg = true;
                this.stockShotImg = new ConfigBusiness().GetStockShotImagesList(this._stockImgId).FirstOrDefault<StockShot>();
                do
                {
                    bool arg_6A_0;
                    bool expr_63 = arg_6A_0 = (this.stockShotImg == null);
                    if (6 != 0)
                    {
                        bool flag = expr_63;
                        arg_6A_0 = flag;
                    }
                    if (arg_6A_0)
                    {
                        break;
                    }
                    do
                    {
                        if (8 != 0)
                        {
                            this.txtSelectedStockImage.Text = this.stockShotImg.ImageName;
                            this.hdnIDStockShot.Text = this._stockImgId.ToString();

                        }
                    }
                    while (false);
                    this.chkIsStockImageActive.IsChecked = new bool?(this.stockShotImg.IsActive);
                    //this.btnSelectedStockImage.IsEnabled = false;
                }
                while (6 == 0);
            }
            catch (Exception var_1_FC)
            {
                do
                {
                    this._iseditStockImg = false;
                }
                while (false);
            }
            while (3 == 0)
            {
            }
        }

        private void btnCancelStockShot_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                this.txtSelectedStockImage.Text = string.Empty;
                this.hdnIDStockShot.Text = string.Empty;








            }
            do
            {
                this.chkIsStockImageActive.IsChecked = new bool?(false);
                this.btnSelectedStockImage.IsEnabled = true;
            }
            while (-1 == 0);
        }

        public void loadSpecGrid(int SelectedLocationId)
        {
            this.objDG_SemiOrder_Settings = new SemiOrderBusiness().GetSemiOrderSettings(null, SelectedLocationId);
            while (true)
            {
                int arg_49_0;
                int arg_78_0;
                int arg_46_0;
                if (this.objDG_SemiOrder_Settings != null)
                {
                    arg_78_0 = (arg_49_0 = ((this.objDG_SemiOrder_Settings.Count > 0) ? 1 : 0));
                    arg_46_0 = 0;
                    goto IL_46;
                }
                int arg_106_0;
                if (4 != 0)
                {
                    arg_106_0 = 1;
                    goto IL_51;
                }
                goto IL_5F;
            IL_AD:
                if (7 != 0)
                {
                    break;
                }
                continue;
            IL_7D:
                int num;
                if (num >= this.objDG_SemiOrder_Settings.Count)
                {
                    this.grdSpecSetting.ItemsSource = null;
                    this.grdSpecSetting.ItemsSource = this.objDG_SemiOrder_Settings;
                    goto IL_AD;
                }
                goto IL_5F;
            IL_52:
                if (arg_106_0 == 0)
                {
                    num = 0;
                    goto IL_7D;
                }
                this.grdSpecSetting.ItemsSource = null;
                if (!false)
                {
                    break;
                }
                goto IL_AD;
            IL_51:
                goto IL_52;
            IL_46:
                int arg_75_0;
                int expr_46 = arg_75_0 = arg_46_0;
                if (expr_46 == 0)
                {
                    arg_106_0 = ((arg_49_0 == expr_46) ? 1 : 0);
                    goto IL_51;
                }
            IL_75:
                int expr_75 = arg_46_0 = arg_75_0;
                if (expr_75 == 0)
                {
                    goto IL_46;
                }
                int expr_78 = arg_106_0 = arg_78_0 + expr_75;
                if (!false)
                {
                    num = expr_78;
                    goto IL_7D;
                }
                goto IL_52;
            IL_5F:
                string dG_SemiOrder_ProductTypeId = this.objDG_SemiOrder_Settings[num].PS_SemiOrder_ProductTypeId;
                arg_78_0 = (arg_49_0 = num);
                arg_75_0 = 1;
                goto IL_75;
            }
        }

        private void cmb_Location_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            while (true)
            {
                while (true)
                {
                    if (6 != 0)
                    {
                        Configuration.SelectedLocationId = this.cmb_Location.SelectedValue.ToInt32(false);
                        if (false)
                        {
                            break;
                        }
                        this.loadSpecGrid(Configuration.SelectedLocationId);
                        if (false)
                        {
                            break;
                        }
                    }
                    if (!false)
                    {
                        return;
                    }
                }
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            ManageHome manageHome = new ManageHome();
            manageHome.Show();
            base.Hide();
        }

        private void btnEditSpecSetting_Click(object sender, RoutedEventArgs e)
        {
            //System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
            //int id = button.Tag.ToInt32(false);
            //this.btn.IsEnabled = false;
            //if (!false)
            //{
            //    this.btn.Background = System.Windows.Media.Brushes.Black;
            //    this.btn.Opacity = 0.4;
            //    do
            //    {
            //        this.ucAddEditSpecPrintProfile.LocationId = this.cmb_Location.SelectedValue.ToInt32(false);
            //        this.ucAddEditSpecPrintProfile.semiOrderSettings = (from t in this.objDG_SemiOrder_Settings
            //        where t.DG_SemiOrder_Settings_Pkey == id
            //        select t).FirstOrDefault<SemiOrderSettings>();
            //        this.ucAddEditSpecPrintProfile.GetSemiOrderSettings();
            //    }
            //    while (false);
            //    this.ucAddEditSpecPrintProfile.Visibility = Visibility.Visible;
            //}
        }

        private void btnDeleteSpecSetting_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button;
            if (2 != 0)
            {
                button = (System.Windows.Controls.Button)sender;
                goto IL_16;
            }
        IL_D3:
            while (!false)
            {
                if (true)
                {
                    return;
                }
            }
        IL_16:
            int id = button.Tag.ToInt32(false);
            try
            {
                while (true)
                {
                    bool arg_A4_0 = 1 == 0;
                    if (System.Windows.MessageBox.Show("Do you want to delete the Spec settings?", "Tempar Data", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) != MessageBoxResult.Yes)
                    {
                        goto IL_9D;
                    }
                    if (!false)
                    {
                        SemiOrderBusiness semiOrderBusiness = new SemiOrderBusiness();
                        bool flag = semiOrderBusiness.DeleteSpecSetting(id);
                        if (flag)
                        {
                            System.Windows.MessageBox.Show("Spec settings deleted successfully");
                            goto IL_76;
                        }
                        goto IL_9C;
                    }
                IL_8C:
                    if (4 != 0)
                    {
                        this.loadSpecGrid(Configuration.SelectedLocationId);
                        goto IL_9C;
                    }
                    continue;
                IL_76:
                    Configuration.SelectedLocationId = this.cmb_Location.SelectedValue.ToInt32(false);
                    goto IL_8C;
                IL_9D:
                    if (!false)
                    {
                        break;
                    }
                    goto IL_76;
                IL_9C:
                    goto IL_9D;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            goto IL_D3;
        }

        private void btnAddNew_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                int arg_17_0 = this.cmb_Location.SelectedValue.ToInt32(false);
                bool expr_17;
                do
                {
                    expr_17 = ((arg_17_0 = ((arg_17_0 > 0) ? 1 : 0)) != 0);
                }
                while (4 == 0);
                bool flag = !expr_17;
                if (-1 == 0)
                {
                    goto IL_61;
                }
                if (flag)
                {
                    goto IL_D8;
                }
                this.btn.IsEnabled = false;
                if (false)
                {
                    break;
                }
                this.btn.Background = System.Windows.Media.Brushes.Black;
                if (!false)
                {
                    goto IL_61;
                }
            IL_75:
                Configuration.VerticalCropCoordinates = string.Empty;
                Configuration.HorizontalCropCoordinates = string.Empty;
                //this.ucAddEditSpecPrintProfile.LocationId = this.cmb_Location.SelectedValue.ToInt32(false);
                if (false)
                {
                    break;
                }
                //this.ucAddEditSpecPrintProfile.ResetSpecPrintEffects();
                //this.ucAddEditSpecPrintProfile.ResetSpecControlValues();
                //this.ucAddEditSpecPrintProfile.Visibility = Visibility.Visible;
                if (!false)
                {
                    break;
                }
                continue;
            IL_61:
                this.btn.Opacity = 0.4;
                goto IL_75;
            }
            return;
        IL_D8:
            System.Windows.MessageBox.Show("Please select the location for which new profile has to be added");
        }

        private void chkTaxEnabled_Checked(object sender, RoutedEventArgs e)
        {
            if (4 != 0)
            {
                bool flag;
                do
                {
                    bool? isChecked = this.chkTaxEnabled.IsChecked;
                    if (6 == 0)
                    {
                        goto IL_43;
                    }
                    flag = !isChecked.Equals(true);
                }
                while (7 == 0);
                if (flag)
                {
                    goto IL_46;
                }
                this.chkIsTaxIncluded.IsEnabled = true;
            IL_43:
                return;
            }
        IL_46:
            while (2 != 0)
            {
                if (!false)
                {
                    this.chkIsTaxIncluded.IsEnabled = false;
                    break;
                }
            }
            this.chkIsTaxIncluded.IsChecked = new bool?(false);
        }

        private void EditBackground(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = true;
                if (this.EditableBackground != null)
                {
                    MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("It looks like you have been editing a background.If you leave before saving, your changes will be lost.Would you like to save your unsaved changes ?", "Alert", MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        flag = false;
                    }
                }
                bool flag2 = !flag;
                while (!flag2)
                {
                    if (!false)
                    {
                        this.btnCancelSelectBackgound_Click(sender, e);
                        while (true)
                        {
                            System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                            bool arg_85_0;
                            if (button == null)
                            {
                                arg_85_0 = true;
                                goto IL_84;
                            }
                            if (6 != 0)
                            {
                                arg_85_0 = (button.DataContext == null);
                                goto IL_84;
                            }
                        IL_106:
                            if (this.EditableBackground == null)
                            {
                                break;
                            }
                            this.txtSelectedBackground.Text = this.EditableBackground.DG_BackGround_Image_Display_Name;
                            this.IsBackgroundActive.IsChecked = this.EditableBackground.DG_Background_IsActive;
                            if (!false)
                            {
                                break;
                            }
                            continue;
                        IL_84:
                            if (!arg_85_0)
                            {
                                try
                                {
                                    BackGroundInfo backGroundInfo = (BackGroundInfo)button.DataContext;
                                    if (backGroundInfo != null)
                                    {
                                        string empty = string.Empty;
                                        bool flag3 = this.FindDependencyOfBackground(backGroundInfo, "edit", out empty);
                                        bool arg_C6_0;
                                        bool expr_BE = arg_C6_0 = flag3;
                                        if (2 != 0)
                                        {
                                            arg_C6_0 = !expr_BE;
                                        }
                                        if (!arg_C6_0)
                                        {
                                            //this.MsgBox.ShowHandlerDialog(empty, DigiMessageBox.DialogType.OK);
                                            break;
                                        }
                                    }
                                    this.EditableBackground = (BackGroundInfo)backGroundInfo.Clone();
                                }
                                catch (Exception var_6_F7)
                                {
                                    this.EditableBackground = null;
                                }
                                goto IL_106;
                            }
                            break;
                        }
                        break;
                    }
                }
            }
            catch (Exception var_6_F7)
            {
            }
        }

        protected virtual void PropertyModified(string propertyName)
        {
            PropertyChangedEventHandler propertyChangedEventHandler;
            if (!false)
            {
                PropertyChangedEventHandler expr_06 = this.propertyChanged;
                if (7 != 0)
                {
                    propertyChangedEventHandler = expr_06;
                }
                bool arg_1E_0;
                bool arg_3B_0 = arg_1E_0 = (propertyChangedEventHandler == null);
                do
                {
                    if (-1 != 0)
                    {
                        bool flag = arg_3B_0;
                        arg_3B_0 = (arg_1E_0 = flag);
                    }
                }
                while (2 == 0);
                if (arg_1E_0)
                {
                    return;
                }
            }
            if (true)
            {
                propertyChangedEventHandler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void EditGraphics(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Controls.Button button;
                bool expr_81;
                while (true)
                {
                    int arg_166_0 = 1;
                    while (true)
                    {
                        bool flag = arg_166_0 != 0;
                        int arg_55_0;
                        bool expr_13 = (arg_55_0 = ((this.EditableGraphics == null) ? 1 : 0)) != 0;
                        if (false)
                        {
                            goto IL_55;
                        }
                        if (!expr_13)
                        {
                            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("It looks like you have been editing a graphics.If you leave before saving, your changes will be lost.Would you like to save your unsaved changes ?", "Alert", MessageBoxButton.YesNo);
                            if (5 == 0)
                            {
                                goto IL_114;
                            }
                            if (messageBoxResult == MessageBoxResult.Yes)
                            {
                                arg_55_0 = 0;
                                goto IL_55;
                            }
                        }
                    IL_57:
                        if (!flag)
                        {
                            goto IL_163;
                        }
                        button = (System.Windows.Controls.Button)sender;
                        bool arg_7F_0;
                        if (button != null)
                        {
                            if (7 == 0)
                            {
                                break;
                            }
                            arg_7F_0 = (button.DataContext == null);
                        }
                        else
                        {
                            arg_7F_0 = true;
                        }
                        bool flag2 = arg_7F_0;
                        expr_81 = ((arg_166_0 = (flag2 ? 1 : 0)) != 0);
                        if (!false)
                        {
                            goto Block_8;
                        }
                        continue;
                    IL_56:
                        goto IL_57;
                    IL_55:
                        flag = (arg_55_0 != 0);
                        goto IL_56;
                    }
                }
            Block_8:
                if (expr_81)
                {
                    goto IL_162;
                }
                do
                {
                    try
                    {
                        AllGraphics allGraphics = (AllGraphics)button.DataContext;
                        if (3 != 0)
                        {
                            this.EditableGraphics = (AllGraphics)allGraphics.Clone();
                        }
                    }
                    catch (Exception var_4_B4)
                    {
                        this.EditableGraphics = null;
                    }
                    if (this.EditableGraphics == null)
                    {
                        goto IL_15E;
                    }
                }
                while (3 == 0);
                string empty = string.Empty;
                if (this.FindDependencyOfGraphic(this.EditableGraphics.Pkey1, this.EditableGraphics.GraphicsName1, this.EditableGraphics.GraphicsDisplayName1, "edit", out empty))
                {
                    //this.MsgBox.ShowHandlerDialog(empty, DigiMessageBox.DialogType.OK);
                    return;
                }
            IL_114:
                this.txtSelectedgraphics.Text = this.EditableGraphics.GraphicsDisplayName1;
                this.IsGraphicsActive.IsChecked = new bool?(this.EditableGraphics.IsActive1);
            IL_148:
            IL_15E:
                if (false)
                {
                    goto IL_148;
                }
            IL_162:
            IL_163:;
            }
            catch (Exception var_4_B4)
            {
            }
        }

        private bool FindDependencyOfBorder(BorderInfo border, string mode, out string message)
        {
            if (false)
            {
                goto IL_51;
            }
            if (false)
            {
                goto IL_51;
            }
            message = string.Empty;
        IL_37:
            if (border == null)
            {
                goto IL_171;
            }
        IL_51:
            SceneBusiness sceneBusiness = new SceneBusiness();
            List<SceneInfo> sceneDetails = sceneBusiness.GetSceneDetails();
            int arg_108_0;
            int arg_108_1;
            int expr_68;
            bool arg_77_0;
            if (sceneDetails != null)
            {
                int expr_62 = arg_108_0 = sceneDetails.Count;
                expr_68 = (arg_108_1 = 0);
                if (expr_68 != 0)
                {
                    goto IL_108;
                }
                arg_77_0 = (expr_62 <= expr_68);
            }
            else
            {
                arg_77_0 = true;
            }
            bool flag = arg_77_0;
            if (false)
            {
                goto IL_150;
            }
            if (flag)
            {
                goto IL_E0;
            }
            SceneInfo sceneInfo = sceneDetails.FirstOrDefault((SceneInfo sc) => sc.BorderId == border.DG_Borders_pkey);
            flag = (sceneInfo == null || string.IsNullOrEmpty(sceneInfo.SceneName));
        IL_B6:
            if (false)
            {
                goto IL_37;
            }
            bool result;
            if (!flag)
            {
                message = string.Format("You can't {0} the border {1}, because this has been associated in a Scene.", mode, sceneInfo.BorderName);
                result = true;
                if (true)
                {
                    return result;
                }
                goto IL_115;
            }
        IL_E0:
            SemiOrderBusiness semiOrderBusiness = new SemiOrderBusiness();
            List<SemiOrderSettings> semiOrderSettings = new List<SemiOrderSettings>(); //semiOrderBusiness.GetSemiOrderSettings(null, 0);
            bool arg_10E_0;
            if (semiOrderSettings == null)
            {
                arg_10E_0 = true;
                goto IL_10D;
            }
            arg_108_0 = ((semiOrderSettings.Count > 0) ? 1 : 0);
            arg_108_1 = 0;
        IL_108:
            arg_10E_0 = (arg_108_0 == arg_108_1);
        IL_10D:
            if (arg_10E_0)
            {
                goto IL_170;
            }
        IL_115:

            semiOrderSettings = new List<SemiOrderSettings>();
            SemiOrderSettings semiOrderSettings2 = semiOrderSettings.FirstOrDefault(delegate (SemiOrderSettings os)
            {
                bool? dG_SemiOrder_Settings_IsImageFrame = os.PS_SemiOrder_Settings_IsImageFrame;
                if (!dG_SemiOrder_Settings_IsImageFrame.HasValue)
                {
                    goto IL_5D;
                }
                dG_SemiOrder_Settings_IsImageFrame = os.PS_SemiOrder_Settings_IsImageFrame;
                if (!dG_SemiOrder_Settings_IsImageFrame.Value)
                {
                    goto IL_5D;
                }
                int arg_62_0 = (os.PS_SemiOrder_Settings_ImageFrame.Trim().ToLower() == border.DG_Border.Trim().ToLower()) ? 1 : 0;
            IL_5E:
                while (!false)
                {
                    bool flag2 = arg_62_0 != 0;
                    if (5 != 0)
                    {
                    }
                    bool expr_681 = false; //(arg_62_0 = (flag2==true ? 1 : 0)) != 0?true :false;
                    if (!false)
                    {
                        return expr_681;
                    }
                }
                goto IL_5E;
            IL_5D:
                arg_62_0 = 0;
                goto IL_5E;
            });
            flag = (semiOrderSettings2 == null || string.IsNullOrEmpty(semiOrderSettings2.PS_SemiOrder_BG));
            if (flag)
            {
                goto IL_170;
            }
        IL_150:
            message = string.Format("You can't {0} the border {1}, because this has been associated in a Spec Printing.", mode, semiOrderSettings2.PS_SemiOrder_Settings_ImageFrame);
            if (8 != 0)
            {
                result = true;
                return result;
            }
            goto IL_B6;
        IL_170:
        IL_171:
            result = false;
            return result;
        }

        private bool FindDependencyOfBackground(BackGroundInfo background, string mode, out string message)
        {
            message = string.Empty;
            int arg_26A_0;
            bool expr_3C = (arg_26A_0 = ((background == null) ? 1 : 0)) != 0;
            bool result;
            if (!false)
            {
                bool flag = expr_3C;
                if (3 == 0)
                {
                    goto IL_12F;
                }
                List<SceneInfo> sceneDetails;
                if (!flag)
                {
                    SceneBusiness sceneBusiness = new SceneBusiness();
                    sceneDetails = sceneBusiness.GetSceneDetails();
                    goto IL_64;
                }
                goto IL_279;
            IL_1F4:
                int arg_1F4_0;
                int arg_1F4_1;
                iMIXConfigurationInfo iMIXConfigurationInfo = new iMIXConfigurationInfo();
                bool arg_24D_0;
                while (arg_1F4_0 != arg_1F4_1)
                {
                    string fileName = Path.GetFileName(iMIXConfigurationInfo.ConfigurationValue);
                    flag = string.IsNullOrEmpty(fileName);
                    if (!true)
                    {
                        goto IL_1C9;
                    }
                    if (flag)
                    {
                        break;
                    }
                    int expr_23E = arg_1F4_0 = ((fileName.Trim().ToLower() == background.DG_BackGround_Image_Name.Trim().ToLower()) ? 1 : 0);
                    int expr_244 = arg_1F4_1 = 0;
                    if (expr_244 == 0)
                    {
                        flag = (expr_23E == expr_244);
                        arg_24D_0 = flag;
                        goto IL_24D;
                    }
                }
                goto IL_276;
            IL_64:
                if (sceneDetails != null && !false && sceneDetails.Count > 0)
                {
                    SceneInfo sceneInfo = sceneDetails.FirstOrDefault((SceneInfo sc) => sc.BackGroundId == background.DG_Background_pkey);
                    if (sceneInfo != null && !string.IsNullOrEmpty(sceneInfo.SceneName))
                    {
                        message = string.Format("You can't {0} the background {1}, because this has been associated in a Scene.", mode, sceneInfo.BackgroundName);
                        result = true;
                        return result;
                    }
                }
                SemiOrderBusiness semiOrderBusiness = new SemiOrderBusiness();
                List<SemiOrderSettings> semiOrderSettings = semiOrderBusiness.GetSemiOrderSettings(null, 0);
                bool arg_108_0;
                if (semiOrderSettings != null)
                {
                    int expr_F3 = arg_1F4_0 = semiOrderSettings.Count;
                    int expr_F9 = arg_1F4_1 = 0;
                    if (expr_F9 != 0)
                    {
                        goto IL_1F4;
                    }
                    arg_108_0 = (expr_F3 <= expr_F9);
                }
                else
                {
                    arg_108_0 = true;
                }
                if (arg_108_0)
                {
                    goto IL_167;
                }
                SemiOrderSettings semiOrderSettings2 = semiOrderSettings.FirstOrDefault(delegate (SemiOrderSettings os)
                {
                    bool result2;
                    while (4 != 0)
                    {
                        result2 = (os.PS_SemiOrder_BG.Trim().ToLower() == background.DG_BackGround_Image_Name.Trim().ToLower());
                        if (!false)
                        {
                            break;
                        }
                    }
                    return result2;
                });
            IL_12F:
                if (semiOrderSettings2 != null && !string.IsNullOrEmpty(semiOrderSettings2.PS_SemiOrder_BG))
                {
                    message = string.Format("You can't {0} the background {1}, because this has been associated in a Spec Printing.", mode, semiOrderSettings2.PS_SemiOrder_BG);
                    result = true;
                    return result;
                }
            IL_167:
                ConfigBusiness configBusiness = new ConfigBusiness();
                List<iMIXConfigurationInfo> newConfigValues = configBusiness.GetNewConfigValues(LoginUser.SubStoreId);
                bool arg_197_0;
                if (newConfigValues != null)
                {
                    bool expr_188 = arg_24D_0 = (newConfigValues.Count > 0);
                    if (5 == 0)
                    {
                        goto IL_24D;
                    }
                    arg_197_0 = !expr_188;
                }
                else
                {
                    arg_197_0 = true;
                }
                if (arg_197_0)
                {
                    goto IL_278;
                }
                iMIXConfigurationInfo = newConfigValues.FirstOrDefault((iMIXConfigurationInfo cvl) => cvl.IMIXConfigurationMasterId == 35L);
            IL_1C9:
                if (iMIXConfigurationInfo != null && !string.IsNullOrEmpty(iMIXConfigurationInfo.ConfigurationValue))
                {
                    arg_1F4_0 = (File.Exists(iMIXConfigurationInfo.ConfigurationValue) ? 1 : 0);
                    arg_1F4_1 = 0;
                    goto IL_1F4;
                }
                goto IL_277;
            IL_24D:
                if (!arg_24D_0)
                {
                    message = string.Format("You can't {0} the background {1}, because this has been defined as default background", mode, background.DG_BackGround_Image_Name);
                    arg_26A_0 = 1;
                    goto IL_26A;
                }
                if (6 == 0)
                {
                    goto IL_64;
                }
            IL_276:
            IL_277:
            IL_278:
            IL_279:
                result = false;
                return result;
            }
        IL_26A:
            result = (arg_26A_0 != 0);
            return result;
        }

        private bool FindDependencyOfGraphic(int graphicId, string graphicName, string displayName, string mode, out string message)
        {
            bool flag;
            List<SemiOrderSettings> semiOrderSettings;
            while (true)
            {
                if (!false)
                {
                    //string graphicName = graphicName2;
                    message = string.Empty;
                    flag = (graphicName == null);
                    if (flag)
                    {
                        goto IL_D7;
                    }
                }
                if (8 != 0)
                {
                    SemiOrderBusiness semiOrderBusiness = new SemiOrderBusiness();
                    if (false)
                    {
                        goto IL_84;
                    }
                    semiOrderSettings = semiOrderBusiness.GetSemiOrderSettings(null, 0);
                }
                if (semiOrderSettings != null)
                {
                    break;
                }
                if (!false)
                {
                    goto Block_5;
                }
            }
            bool arg_82_0 = semiOrderSettings.Count <= 0;
            goto IL_81;
        Block_5:
            arg_82_0 = true;
        IL_81:
            flag = arg_82_0;
        IL_84:
            bool arg_B9_0;
            bool expr_84 = arg_B9_0 = flag;
            if (!false)
            {
                if (expr_84)
                {
                    goto IL_D6;
                }
                SemiOrderSettings semiOrderSettings2 = semiOrderSettings.FirstOrDefault(delegate (SemiOrderSettings os)
                {
                    if (false)
                    {
                        goto IL_1E;
                    }
                    bool arg_25_0;
                    bool arg_4F_0 = arg_25_0 = os.PS_SemiOrder_Graphics_layer.ToLower().Contains(graphicName.Trim().ToLower());
                IL_16:
                    if (7 == 0 || 8 == 0)
                    {
                        goto IL_22;
                    }
                    bool flag2 = arg_4F_0;
                IL_1E:
                    arg_4F_0 = (arg_25_0 = flag2);
                IL_22:
                    if (!false)
                    {
                        return arg_25_0;
                    }
                    goto IL_16;
                });
                arg_B9_0 = (semiOrderSettings2 == null || string.IsNullOrEmpty(semiOrderSettings2.PS_SemiOrder_Graphics_layer));
            }
            flag = arg_B9_0;
            bool result;
            if (!flag)
            {
                message = string.Format("You can't {0} the graphic {1}, because this has been associated in a Spec Printing.", mode, displayName);
                result = true;
                goto IL_D3;
            }
        IL_D6:
            goto IL_D7;
        IL_D3:
            return result;
        IL_D7:
            result = false;
            if (6 != 0)
            {
            }
            return result;
        }

        private void GetVideoOverlayDetails()
        {
            do
            {
                try
                {
                    List<VideoOverlay> videoOverlays;
                    if (!false)
                    {
                        ConfigBusiness configBusiness = new ConfigBusiness();
                        videoOverlays = configBusiness.GetVideoOverlays();
                    }
                    if (!false)
                    {
                        this.DGManageOverlay.ItemsSource = videoOverlays;
                    }
                    if (!false)
                    {
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    do
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (4 == 0);
                }
            }
            while (false);
        }

        private void btnSelectOverlay_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            Microsoft.Win32.OpenFileDialog expr_152 = openFileDialog;
            bool expr_16 = false;
            if (6 != 0)
            {
                expr_152.Multiselect = expr_16;
            }
            openFileDialog.Filter = "Select Media|*.jpg;*.png;*.mp4;*.wmv;*.avi;|JPG|*.jpg;*.JPG|PNG|*.png;*.PNG|WMV|*.wmv;*.WMV|MP4|*.mp4;*.MP4|AVI|*.avi;*.AVI;";
            if (openFileDialog.ShowDialog().Value)
            {
                try
                {
                    if (openFileDialog.OpenFile() != null)
                    {
                        if (Path.GetFileName(openFileDialog.FileName.ToString()).ToCharArray().Count<char>() <= 50)
                        {
                            this.txtSelectedOverlay.Text = openFileDialog.FileName.ToString();
                            this.OverlayDisplyname = Path.GetFileName(openFileDialog.FileName);
                            if (!(Path.GetExtension(openFileDialog.FileName) == ".jpg") && !(Path.GetExtension(openFileDialog.FileName) == ".JPEG"))
                            {
                                this.overlayMediaId = 2;
                                goto IL_FF;
                            }
                        }
                        else if (!false)
                        {
                            System.Windows.MessageBox.Show("File name should not excced 50 characters.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                            goto IL_11A;
                        }
                        this.overlayMediaId = 1;
                    IL_FF:
                    IL_11A:;
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void btnSaveSelectOverlay_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    long num = 0L;
            //    WindowsMediaPlayer windowsMediaPlayer = (WindowsMediaPlayer)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("6BF52A52-394A-11D3-B153-00C04F79FAA6")));
            //    if (this.CheckVideoBGValidations(this.txtSelectedOverlay))
            //    {
            //        bool arg_298_0;
            //        bool arg_B5_0;
            //        if (!(Path.GetExtension(this.OverlayDisplyname) == ".mp4"))
            //        {
            //            bool expr_75 = arg_298_0 = (Path.GetExtension(this.OverlayDisplyname) == ".wmv");
            //            if (false)
            //            {
            //                goto IL_297;
            //            }
            //            if (!expr_75 && !(Path.GetExtension(this.OverlayDisplyname) == ".avi"))
            //            {
            //                arg_B5_0 = !(Path.GetExtension(this.OverlayDisplyname) == ".mov");
            //                goto IL_B4;
            //            }
            //        }
            //        arg_B5_0 = false;
            //        IL_B4:
            //        bool flag;
            //        if (!arg_B5_0)
            //        {
            //            IWMPMedia iWMPMedia = windowsMediaPlayer.newMedia(this.txtSelectedOverlay.Text);
            //            num = (string.IsNullOrEmpty(TimeSpan.FromSeconds(iWMPMedia.duration).ToString()) ? 0L : ((long)TimeSpan.FromSeconds(iWMPMedia.duration).TotalSeconds));
            //            flag = (num <= 1800L);
            //        }
            //        else
            //        {
            //            flag = true;
            //        }
            //        if (!flag)
            //        {
            //            System.Windows.MessageBox.Show("Video overlay length should not exceed 30 minutes.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //            goto IL_306;
            //        }
            //        bool flag2 = false;
            //        Guid guid = Guid.NewGuid();
            //        this.OverlayName = Path.GetFileNameWithoutExtension(this.OverlayDisplyname) + guid.ToString() + Path.GetExtension(this.OverlayDisplyname);
            //        string text = LoginUser.DigiFolderVideoOverlayPath + this.OverlayName;
            //        string text2 = this.txtOverlayDescription.Text;
            //        bool? isChecked = this.IsOverlayActive.IsChecked;
            //        if (!this.IsVideoOverlayEdited)
            //        {
            //            if (!Directory.Exists(LoginUser.DigiFolderVideoOverlayPath))
            //            {
            //                Directory.CreateDirectory(LoginUser.DigiFolderVideoOverlayPath);
            //            }
            //            File.Copy(this.txtSelectedOverlay.Text, text, true);
            //            flag2 = this.SaveVideoOverlay(this.OverlayDisplyname, this.OverlayName, text2, isChecked, this.IsVideoOverlayEdited, this.overlayMediaId, (int)num);
            //        }
            //        else
            //        {
            //            string text3 = this.txtSelectedOverlay.Text;
            //            if (File.Exists(text3))
            //            {
            //                File.Copy(text3, text, true);
            //                if (text3.Contains(LoginUser.DigiFolderVideoOverlayPath))
            //                {
            //                    File.Delete(text3);
            //                }
            //                flag2 = this.SaveVideoOverlay(this.OverlayDisplyname, this.OverlayName, text2, isChecked, this.IsVideoOverlayEdited, this.overlayMediaId, (int)num);
            //            }
            //            else
            //            {
            //                System.Windows.MessageBox.Show("File not found.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Hand);
            //            }
            //            this.IsVideoOverlayEdited = false;
            //        }
            //        arg_298_0 = flag2;
            //        IL_297:
            //        if (arg_298_0)
            //        {
            //            this.CopyToAllSubstore(this.lstConfigurationInfo, text, "", "VideoOverlay");
            //            System.Windows.MessageBox.Show("Video overlay saved successfully.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            //            AuditLog.AddUserLog(LoginUser.UserId, 49, "Add/Edit Video overlay at ");
            //            this.GetVideoOverlayDetails();
            //        }
            //        this.ResetOverlayControls();
            //        IL_306:;
            //    }
            //    else
            //    {
            //        System.Windows.MessageBox.Show("Select video overlay file.", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            //    }
            //}
            //catch (Exception serviceException)
            //{
            //    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
            //    ErrorHandler.ErrorHandler.LogFileWrite(message);
            //}
        }

        private void ResetOverlayControls()
        {
            while (true)
            {
                while (true)
                {
                    this.txtOverlayDescription.Text = string.Empty;
                    while (!false)
                    {
                        this.txtSelectedOverlay.Text = string.Empty;
                        this.IsOverlayActive.IsChecked = new bool?(false);
                        if (!false)
                        {
                        IL_32:
                            this.VideoOverlayId = 0L;
                            this.IsVideoOverlayEdited = false;
                            break;
                        }
                    }
                    if (!false)
                    {
                        if (false)
                        {
                            //goto IL_32;
                        }
                        if (true)
                        {
                            return;
                        }
                    }
                }
            }
        }

        private bool SaveVideoOverlay(string OverlayDisplyname, string OverlayName, string strDescription, bool? IsActive, bool IsEdited, int overlayMediaId, int VidLength)
        {
            bool result;
            try
            {
                while (true)
                {
                    bool? arg_15E_0;
                    if (IsActive.HasValue)
                    {
                        if (false)
                        {
                            continue;
                        }
                        arg_15E_0 = IsActive;
                    }
                    else
                    {
                        arg_15E_0 = new bool?(false);
                    }
                    if (!false)
                    {
                        IsActive = arg_15E_0;
                    }
                    VideoOverlay videoOverlay = new VideoOverlay();
                    videoOverlay.DisplayName = OverlayDisplyname;
                    videoOverlay.Name = OverlayName;
                    videoOverlay.IsActive = Convert.ToBoolean(IsActive);
                    videoOverlay.MediaType = overlayMediaId;
                    videoOverlay.Description = strDescription;
                    videoOverlay.VideoLength = (long)VidLength;
                    if (!IsEdited)
                    {
                        videoOverlay.CreatedBy = LoginUser.UserId;
                        videoOverlay.CreatedOn = new DateTime?(DateTime.Now);
                        videoOverlay.ModifiedBy = 0;
                        goto IL_A0;
                    }
                    videoOverlay.CreatedBy = LoginUser.UserId;
                    videoOverlay.CreatedOn = new DateTime?(DateTime.Now);
                    videoOverlay.VideoOverlayId = this.videoBackgroundId;
                    videoOverlay.ModifiedBy = LoginUser.UserId;
                    if (!true)
                    {
                        goto IL_122;
                    }
                    videoOverlay.ModifiedOn = new DateTime?(DateTime.Now);
                    videoOverlay.VideoOverlayId = this.VideoOverlayId;
                IL_10E:
                    int num;
                    if (5 != 0)
                    {
                        ConfigBusiness configBusiness = new ConfigBusiness();
                        num = configBusiness.SaveUpdateVideoOverlay(videoOverlay);
                        goto IL_122;
                    }
                    continue;
                IL_A0:
                    videoOverlay.ModifiedOn = new DateTime?(DateTime.Now);
                    goto IL_10E;
                IL_122:
                    int arg_124_0 = num;
                    bool arg_133_0;
                    bool expr_124;
                    do
                    {
                        expr_124 = ((arg_124_0 = ((arg_133_0 = (arg_124_0 > 0)) ? 1 : 0)) != 0);
                    }
                    while (false);
                    if (!false)
                    {
                        bool flag = !expr_124;
                        arg_133_0 = flag;
                    }
                    if (arg_133_0)
                    {
                        goto IL_13F;
                    }
                    result = true;
                    if (!false)
                    {
                        break;
                    }
                    goto IL_A0;
                }
                goto IL_191;
            IL_13F:
                result = false;
            }
            catch
            {
                result = false;
            }
        IL_191:
            while (7 == 0)
            {
            }
            return result;
        }

        private void btnCancelSelectOverlay_Click(object sender, RoutedEventArgs e)
        {
            this.ResetOverlayControls();
        }

        private void btnDeleteOverlay_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
            long videoId = long.Parse(button.Tag.ToString());
            MessageBoxResult messageBoxResult = System.Windows.MessageBox.Show("Do you want to delete record?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (!true)
            {
                goto IL_84;
            }
            int arg_48_0 = (messageBoxResult == MessageBoxResult.Yes) ? 1 : 0;
        IL_47:
            if (arg_48_0 == 0)
            {
                return;
            }
            ConfigBusiness configBusiness = new ConfigBusiness();
            VideoOverlay videoOverlays = configBusiness.GetVideoOverlays(this.VideoOverlayId);
            string path = LoginUser.DigiFolderVideoOverlayPath + videoOverlays.Name;
            bool flag = configBusiness.DeleteVideoOverlay(videoId);
        IL_84:
            bool arg_9B_0;
            int expr_84 = (arg_9B_0 = flag) ? 1 : 0;
            int arg_9B_1;
            int expr_87 = arg_9B_1 = 0;
            if (expr_87 == 0)
            {
                if (expr_84 == expr_87)
                {
                    goto IL_F9;
                }
                arg_9B_0 = File.Exists(path);
                arg_9B_1 = 0;
            }
            if ((arg_9B_0 ? 1 : 0) != arg_9B_1)
            {
                File.Delete(path);
            }
            this.DeleteFromAllSubstore(this.lstConfigurationInfo, videoOverlays.Name, "VideoOverlay");
            this.GetVideoOverlayDetails();
            System.Windows.MessageBox.Show("Video overlay record deleted Successfully", "Spectra Photo", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            int expr_E0 = arg_48_0 = LoginUser.UserId;
            if (3 == 0)
            {
                goto IL_47;
            }
            AuditLog.AddUserLog(expr_E0, 49, "Delete video overlay at ");
        IL_F9:
            this.ResetOverlayControls();
        }

        private void btnEditOverlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                this.VideoOverlayId = (long)Convert.ToInt32(button.Tag);
                this.IsVideoOverlayEdited = true;
                ConfigBusiness configBusiness = new ConfigBusiness();
                VideoOverlay videoOverlays = configBusiness.GetVideoOverlays(this.VideoOverlayId);
                this.videoBGName = videoOverlays.Name;
                this.txtSelectedOverlay.Text = LoginUser.DigiFolderVideoOverlayPath + videoOverlays.Name;
                this.txtOverlayDescription.Text = videoOverlays.Description;
                this.IsOverlayActive.IsChecked = new bool?(videoOverlays.IsActive);
                this.videoBGDisplayname = Path.GetFileName(videoOverlays.DisplayName);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        #region Commented


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
        //            Uri resourceLocator = new Uri("/DigiPhoto;component/manage/configuration.xaml", UriKind.Relative);
        //            if (!false)
        //            {
        //                System.Windows.Application.LoadComponent(this, resourceLocator);
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

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
        //internal Delegate _CreateDelegate(Type delegateType, string handler)
        //{
        //    return Delegate.CreateDelegate(delegateType, this, handler);
        //}

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        //void IComponentConnector.Connect(int connectionId, object target)
        //{
        //    switch (connectionId)
        //    {
        //    case 1:
        //        ((Configuration)target).Loaded += new RoutedEventHandler(this.Window_Loaded);
        //        return;
        //    case 2:
        //    case 74:
        //    case 75:
        //    case 79:
        //    case 80:
        //    case 96:
        //    case 97:
        //    case 101:
        //    case 102:
        //    case 115:
        //    case 116:
        //    case 125:
        //    case 126:
        //    case 206:
        //    case 207:
        //    case 210:
        //    case 211:
        //    case 221:
        //    case 222:
        //    case 232:
        //    case 233:
        //    case 234:
        //    case 244:
        //    case 245:
        //    case 253:
        //    case 254:
        //    case 264:
        //    case 265:
        //        goto IL_23DA;
        //    case 3:
        //        this.ModalDialogParent = (Grid)target;
        //        return;
        //    case 4:
        //        this.btn = (Grid)target;
        //        return;
        //    case 5:
        //        this.bgContainer = (StackPanel)target;
        //        return;
        //    case 6:
        //        this.vb2 = (Viewbox)target;
        //        return;
        //    case 7:
        //        this.bg_withlogo1 = (StackPanel)target;
        //        return;
        //    case 8:
        //        this.bg1 = (System.Windows.Controls.Image)target;
        //        return;
        //    case 9:
        //        this.FooterredLine = (StackPanel)target;
        //        return;
        //    case 10:
        //        this.btnUserName = (System.Windows.Controls.Button)target;
        //        return;
        //    case 11:
        //        this.txbUserName = (TextBlock)target;
        //        return;
        //    case 12:
        //        this.txbStoreName = (TextBlock)target;
        //        return;
        //    case 13:
        //        this.btnLogout = (System.Windows.Controls.Button)target;
        //        this.btnLogout.Click += new RoutedEventHandler(this.btnLogout_Click);
        //        return;
        //    case 14:
        //        this.tbmain = (System.Windows.Controls.TabControl)target;
        //        return;
        //    case 15:
        //        this.TabConfiguration = (TabItem)target;
        //        return;
        //    case 16:
        //        this.txtHotFolder = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 17:
        //        this.txtBorderFolder = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 18:
        //        this.txtbgPath = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 19:
        //        this.txtPassword = (PasswordBox)target;
        //        return;
        //    case 20:
        //        this.txtNumber = (System.Windows.Controls.TextBox)target;
        //        this.txtNumber.KeyDown += new System.Windows.Input.KeyEventHandler(this.txtNumber_KeyDown);
        //        return;
        //    case 21:
        //        this.txtPageSize = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 22:
        //        this.btnSaveChanges = (System.Windows.Controls.Button)target;
        //        this.btnSaveChanges.Click += new RoutedEventHandler(this.btnSaveChanges_Click);
        //        return;
        //    case 23:
        //        this.btnBack = (System.Windows.Controls.Button)target;
        //        this.btnBack.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 24:
        //        this.btnhotfolder = (System.Windows.Controls.Button)target;
        //        this.btnhotfolder.Click += new RoutedEventHandler(this.btnhotfolder_Click);
        //        return;
        //    case 25:
        //        this.btnFrmaes = (System.Windows.Controls.Button)target;
        //        this.btnFrmaes.Click += new RoutedEventHandler(this.btnhotfolder_Click);
        //        return;
        //    case 26:
        //        this.btnBg = (System.Windows.Controls.Button)target;
        //        this.btnBg.Click += new RoutedEventHandler(this.btnhotfolder_Click);
        //        return;
        //    case 27:
        //        this.btngraphics = (System.Windows.Controls.Button)target;
        //        return;
        //    case 28:
        //        this.txtbgGraphics = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 29:
        //        this.chkwatermark = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 30:
        //        this.tbenablegroup = (TextBlock)target;
        //        return;
        //    case 31:
        //        this.chkEnableGrouping = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 32:
        //        this.chkHgihResolutionPreview = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 33:
        //        this.chkSemiOrder = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 34:
        //        this.chkSemiOrderMain = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 35:
        //        this.chkSaveReportToAnyDerive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 36:
        //        this.txtNoOfReceipt = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 37:
        //        this.txtNoOfPhotoIdSearch = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 38:
        //        this.txtConfigColorCode = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 39:
        //        this.chkAutoRotate = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 40:
        //        this.chkTotalDiscount = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 41:
        //        this.chkLineItemDiscount = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 42:
        //        this.chkEnablePos = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 43:
        //        this.txtChromaTolerance = (System.Windows.Controls.TextBox)target;
        //        this.txtChromaTolerance.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtChromaTolerance_KeyUp);
        //        return;
        //    case 44:
        //        this.cmbChromaColor = (System.Windows.Controls.ComboBox)target;
        //        this.cmbChromaColor.SelectionChanged += new SelectionChangedEventHandler(this.cmbChromaColor_SelectionChanged);
        //        return;
        //    case 45:
        //        this.cmbCurrency = (System.Windows.Controls.ComboBox)target;
        //        return;
        //    case 46:
        //        this.cmbReceiptPrinter = (System.Windows.Controls.ComboBox)target;
        //        return;
        //    case 47:
        //        this.txtSeqPrefix = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 48:
        //        this.txtImageBarCodeTextFontSize = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 49:
        //        this.chkCompressImage = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 50:
        //        this.TabVenueConfiguration = (TabItem)target;
        //        return;
        //    case 51:
        //        this.chkRunvideoProcessingEngineLocationWise = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 52:
        //        this.chkImageProssingEngineLocWise = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 53:
        //        this.chkTaxEnabled = (System.Windows.Controls.CheckBox)target;
        //        this.chkTaxEnabled.Checked += new RoutedEventHandler(this.chkTaxEnabled_Checked);
        //        this.chkTaxEnabled.Unchecked += new RoutedEventHandler(this.chkTaxEnabled_Checked);
        //        return;
        //    case 54:
        //        this.chkStockShot = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 55:
        //        this.chkIsTaxIncluded = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 56:
        //        this.txtBillReceiptTitle = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 57:
        //        this.txtAddress = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 58:
        //        this.txtPhoneNo = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 59:
        //        this.txtTaxRegistrationText = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 60:
        //        this.txtTaxRegistrationNo = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 61:
        //        this.txtWebsiteURL = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 62:
        //        this.txtEmail = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 63:
        //        this.btnSaveVenueChanges = (System.Windows.Controls.Button)target;
        //        this.btnSaveVenueChanges.Click += new RoutedEventHandler(this.btnSaveVenueChanges_Click);
        //        return;
        //    case 64:
        //        this.btnVenueBack = (System.Windows.Controls.Button)target;
        //        this.btnVenueBack.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 65:
        //        this.chkSequenceNoReqd = (System.Windows.Controls.CheckBox)target;
        //        this.chkSequenceNoReqd.Click += new RoutedEventHandler(this.chkSequenceNoReqd_Click);
        //        return;
        //    case 66:
        //        this.txtMinSeqNo = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 67:
        //        this.txtMaxSeq = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 68:
        //        this.txtServerHotFolder = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 69:
        //        this.btnServerhotfolder = (System.Windows.Controls.Button)target;
        //        this.btnServerhotfolder.Click += new RoutedEventHandler(this.btnhotfolder_Click);
        //        return;
        //    case 70:
        //        this.TabSpecPrinting = (TabItem)target;
        //        return;
        //    case 71:
        //        this.cmb_Location = (System.Windows.Controls.ComboBox)target;
        //        this.cmb_Location.SelectionChanged += new SelectionChangedEventHandler(this.cmb_Location_SelectionChanged);
        //        return;
        //    case 72:
        //        this.btnAddNew = (System.Windows.Controls.Button)target;
        //        this.btnAddNew.Click += new RoutedEventHandler(this.btnAddNew_Click);
        //        return;
        //    case 73:
        //        this.grdSpecSetting = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 76:
        //        this.btnBackto = (System.Windows.Controls.Button)target;
        //        this.btnBackto.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 77:
        //        this.TabManageBorder = (TabItem)target;
        //        return;
        //    case 78:
        //        this.DGManageBorder = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 81:
        //        this.btnBackborder = (System.Windows.Controls.Button)target;
        //        this.btnBackborder.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 82:
        //        this.CmbProductType = (System.Windows.Controls.ComboBox)target;
        //        return;
        //    case 83:
        //        this.btnSelectBorder = (System.Windows.Controls.Button)target;
        //        this.btnSelectBorder.Click += new RoutedEventHandler(this.btnSelectBorder_Click);
        //        return;
        //    case 84:
        //        this.txtSelectedborder = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 85:
        //        this.btnSaveSelectBorder = (System.Windows.Controls.Button)target;
        //        this.btnSaveSelectBorder.Click += new RoutedEventHandler(this.btnSaveSelectBorder_Click);
        //        return;
        //    case 86:
        //        this.btnCancelSelectBorder = (System.Windows.Controls.Button)target;
        //        this.btnCancelSelectBorder.Click += new RoutedEventHandler(this.btnCancelSelectBorder_Click);
        //        return;
        //    case 87:
        //        this.IsBorderActive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 88:
        //        this.TabManageBackground = (TabItem)target;
        //        return;
        //    case 89:
        //        this.GrdBackgroundDetails = (Grid)target;
        //        return;
        //    case 90:
        //        this.btnSelectBackground = (System.Windows.Controls.Button)target;
        //        this.btnSelectBackground.Click += new RoutedEventHandler(this.btnSelectBackground_Click);
        //        return;
        //    case 91:
        //        this.txtSelectedBackground = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 92:
        //        this.btnSaveSelectBackground = (System.Windows.Controls.Button)target;
        //        this.btnSaveSelectBackground.Click += new RoutedEventHandler(this.btnSaveSelectBackground_Click);
        //        return;
        //    case 93:
        //        this.btnCancelSelectBackgound = (System.Windows.Controls.Button)target;
        //        this.btnCancelSelectBackgound.Click += new RoutedEventHandler(this.btnCancelSelectBackgound_Click);
        //        return;
        //    case 94:
        //        break;
        //    case 95:
        //        this.DGManageBackground = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 98:
        //        this.btnBackbackground = (System.Windows.Controls.Button)target;
        //        this.btnBackbackground.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 99:
        //        this.TabManageCurrency = (TabItem)target;
        //        return;
        //    case 100:
        //        this.DGManageCurrency = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 103:
        //        this.btnBackCurrency = (System.Windows.Controls.Button)target;
        //        this.btnBackCurrency.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 104:
        //        this.TBCurrencyName = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 105:
        //        this.BtnSelectIconCurrency = (System.Windows.Controls.Button)target;
        //        this.BtnSelectIconCurrency.Click += new RoutedEventHandler(this.btnSelectBorder_Click);
        //        return;
        //    case 106:
        //        this.txtSelectedIconCurrency = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 107:
        //        this.btnSaveCurrency = (System.Windows.Controls.Button)target;
        //        this.btnSaveCurrency.Click += new RoutedEventHandler(this.btnSaveCurrency_Click);
        //        return;
        //    case 108:
        //        this.btnclearCurrency = (System.Windows.Controls.Button)target;
        //        this.btnclearCurrency.Click += new RoutedEventHandler(this.btnclearCurrency_Click);
        //        return;
        //    case 109:
        //        this.TBCurrencySymbol = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 110:
        //        this.txtDefaultCurrency = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 111:
        //        this.TBCurrencyRate = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 112:
        //        this.TBCurrencyCode = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 113:
        //        this.TabManageGraphics = (TabItem)target;
        //        return;
        //    case 114:
        //        this.DGManageGraphics = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 117:
        //        this.btnBackGraphics = (System.Windows.Controls.Button)target;
        //        this.btnBackGraphics.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 118:
        //        this.btnSelectGraphics = (System.Windows.Controls.Button)target;
        //        this.btnSelectGraphics.Click += new RoutedEventHandler(this.btnSelectGraphics_Click);
        //        return;
        //    case 119:
        //        this.txtSelectedgraphics = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 120:
        //        this.btnSaveSelectGraphics = (System.Windows.Controls.Button)target;
        //        this.btnSaveSelectGraphics.Click += new RoutedEventHandler(this.btnSaveSelectGraphics_Click);
        //        return;
        //    case 121:
        //        this.btnCancelSelectgraphics = (System.Windows.Controls.Button)target;
        //        this.btnCancelSelectgraphics.Click += new RoutedEventHandler(this.btnCancelSelectgraphics_Click);
        //        return;
        //    case 122:
        //        this.IsGraphicsActive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 123:
        //        this.TabManageDiscount = (TabItem)target;
        //        return;
        //    case 124:
        //        this.DGManageDiscount = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 127:
        //        this.btnBackDiscount = (System.Windows.Controls.Button)target;
        //        this.btnBackDiscount.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 128:
        //        this.txtdiscountname = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 129:
        //        this.IsDiscountActive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 130:
        //        this.IsDiscountSecure = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 131:
        //        this.IsDiscountItemLevel = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 132:
        //        this.IsDiscountasPercentage = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 133:
        //        this.txtdiscountdescription = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 134:
        //        this.txtDiscountCode = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 135:
        //        this.btnSaveDiscount = (System.Windows.Controls.Button)target;
        //        this.btnSaveDiscount.Click += new RoutedEventHandler(this.btnSaveDiscount_Click);
        //        return;
        //    case 136:
        //        this.btnCanceldiscount = (System.Windows.Controls.Button)target;
        //        this.btnCanceldiscount.Click += new RoutedEventHandler(this.btnCanceldiscount_Click);
        //        return;
        //    case 137:
        //        this.TabSSConfiguration = (TabItem)target;
        //        return;
        //    case 138:
        //        this.cmbSelectSubstore = (System.Windows.Controls.ComboBox)target;
        //        return;
        //    case 139:
        //        this.btnSaveSubStore = (System.Windows.Controls.Button)target;
        //        this.btnSaveSubStore.Click += new RoutedEventHandler(this.btnSaveSubStore_Click);
        //        return;
        //    case 140:
        //        this.btnBackSubStore = (System.Windows.Controls.Button)target;
        //        this.btnBackSubStore.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 141:
        //        this.dgrdLocations = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 142:
        //        this.Tabdigimagic = (TabItem)target;
        //        return;
        //    case 143:
        //        this.brightVal = (Slider)target;
        //        this.brightVal.GotFocus += new RoutedEventHandler(this.brightVal_GotFocus);
        //        return;
        //    case 144:
        //        this.txtbright = (System.Windows.Controls.TextBox)target;
        //        this.txtbright.PreviewTextInput += new TextCompositionEventHandler(this.txtslider_PreviewTextInput);
        //        this.txtbright.AddHandler(System.Windows.DataObject.PastingEvent, new DataObjectPastingEventHandler(this.PastingHandler));
        //        return;
        //    case 145:
        //        this.contrastVal = (Slider)target;
        //        this.contrastVal.GotFocus += new RoutedEventHandler(this.contrastVal_GotFocus);
        //        return;
        //    case 146:
        //        this.txtcontrasts = (System.Windows.Controls.TextBox)target;
        //        this.txtcontrasts.PreviewTextInput += new TextCompositionEventHandler(this.txtslider_PreviewTextInput);
        //        this.txtcontrasts.AddHandler(System.Windows.DataObject.PastingEvent, new DataObjectPastingEventHandler(this.PastingHandler));
        //        return;
        //    case 147:
        //        this.sharpVal = (Slider)target;
        //        this.sharpVal.ValueChanged += new RoutedPropertyChangedEventHandler<double>(this.sharpVal_ValueChanged);
        //        this.sharpVal.GotFocus += new RoutedEventHandler(this.sharpVal_GotFocus);
        //        return;
        //    case 148:
        //        this.txtsharp = (System.Windows.Controls.TextBox)target;
        //        this.txtsharp.PreviewTextInput += new TextCompositionEventHandler(this.txtslider_PreviewTextInput);
        //        this.txtsharp.AddHandler(System.Windows.DataObject.PastingEvent, new DataObjectPastingEventHandler(this.PastingHandler));
        //        return;
        //    case 149:
        //        this.GrdBrightn = (Grid)target;
        //        return;
        //    case 150:
        //        this.GrdSharpens = (Grid)target;
        //        return;
        //    case 151:
        //        this.Flower = (System.Windows.Controls.Image)target;
        //        return;
        //    case 152:
        //        this.btnDefault = (System.Windows.Controls.Button)target;
        //        this.btnDefault.Click += new RoutedEventHandler(this.btndefault_Click);
        //        return;
        //    case 153:
        //        this.btnSaveDigimagic = (System.Windows.Controls.Button)target;
        //        this.btnSaveDigimagic.Click += new RoutedEventHandler(this.btnSaveDigimagic_click);
        //        if (2 != 0)
        //        {
        //            return;
        //        }
        //        break;
        //    case 154:
        //        this.btnBrionBack = (System.Windows.Controls.Button)target;
        //        this.btnBrionBack.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 155:
        //        this.TabBackup = (TabItem)target;
        //        return;
        //    case 156:
        //        this.txtDbBackupPath = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 157:
        //        this.txtTables = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 158:
        //        this.listtables = (System.Windows.Controls.ListBox)target;
        //        return;
        //    case 159:
        //        this.txtHfBackupPath = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 160:
        //        this.txtCleanupdays = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 161:
        //        this.txtFailedOnlineOrderCleanupdays = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 162:
        //        this.hiddenHFPath = (TextBlock)target;
        //        return;
        //    case 163:
        //        this.chkSchBackup = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 164:
        //        this.ccBackupDateTime = (Xceed.Wpf.Toolkit.DateTimePicker)target;
        //        return;
        //    case 165:
        //        this.chkRecursive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 166:
        //        this.cmbSelectRecursiveCount = (System.Windows.Controls.ComboBox)target;
        //        return;
        //    case 167:
        //        this.cmbSelectRecursiveTime = (System.Windows.Controls.ComboBox)target;
        //        return;
        //    case 168:
        //        this.btnBackupNow = (System.Windows.Controls.Button)target;
        //        this.btnBackupNow.Click += new RoutedEventHandler(this.btnBackupNow_Click);
        //        return;
        //    case 169:
        //        this.btnBackupBack = (System.Windows.Controls.Button)target;
        //        this.btnBackupBack.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 170:
        //        this.TabOnlineConfig = (TabItem)target;
        //        return;
        //    case 171:
        //        this.chkIsBarcodeActive = (System.Windows.Controls.CheckBox)target;
        //        this.chkIsBarcodeActive.Checked += new RoutedEventHandler(this.chkIsBarcodeActive_Checked);
        //        this.chkIsBarcodeActive.Unchecked += new RoutedEventHandler(this.chkIsBarcodeActive_Unchecked);
        //        return;
        //    case 172:
        //        this.txtblMappingType = (TextBlock)target;
        //        return;
        //    case 173:
        //        this.cmbMappingType = (System.Windows.Controls.ComboBox)target;
        //        return;
        //    case 174:
        //        this.txtblScanType = (TextBlock)target;
        //        return;
        //    case 175:
        //        this.cmbScanType = (System.Windows.Controls.ComboBox)target;
        //        return;
        //    case 176:
        //        this.txtQRCodeLen = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 177:
        //        this.spLostImgTimeGap = (StackPanel)target;
        //        return;
        //    case 178:
        //        this.txtLostImgTimeGap = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 179:
        //        this.spQRCodeUrl = (StackPanel)target;
        //        return;
        //    case 180:
        //        this.txtQRCodeWebUrl = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 181:
        //        this.chkIsOnline = (System.Windows.Controls.CheckBox)target;
        //        this.chkIsOnline.Checked += new RoutedEventHandler(this.chkIsOnline_Checked);
        //        this.chkIsOnline.Unchecked += new RoutedEventHandler(this.chkIsOnline_UnChecked);
        //        return;
        //    case 182:
        //        this.chkIsAutoPurchaseActive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 183:
        //        this.DgService = (StackPanel)target;
        //        return;
        //    case 184:
        //        this.txtDgServiceUrl = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 185:
        //        this.chkAnonymousQrCode = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 186:
        //        this.spOnlineResize = (StackPanel)target;
        //        return;
        //    case 187:
        //        this.txtOnlineResize = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 188:
        //        this.SliderOnlineResize = (Slider)target;
        //        return;
        //    case 189:
        //        this.spStorageMediaResize = (StackPanel)target;
        //        return;
        //    case 190:
        //        this.txtSMResize = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 191:
        //        this.SliderSMResize = (Slider)target;
        //        return;
        //    case 192:
        //        this.btnSaveOnlineConfig = (System.Windows.Controls.Button)target;
        //        this.btnSaveOnlineConfig.Click += new RoutedEventHandler(this.btnSaveOnlineConfig_Click);
        //        return;
        //    case 193:
        //        this.btnOnlineBack = (System.Windows.Controls.Button)target;
        //        this.btnOnlineBack.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 194:
        //        this.TabManageScene = (TabItem)target;
        //        return;
        //    case 195:
        //        this.CmbSceneProductType = (System.Windows.Controls.ComboBox)target;
        //        this.CmbSceneProductType.SelectionChanged += new SelectionChangedEventHandler(this.CmbSceneProductType_SelectionChanged);
        //        return;
        //    case 196:
        //        this.CmbBackgroundType = (System.Windows.Controls.ComboBox)target;
        //        this.CmbBackgroundType.SelectionChanged += new SelectionChangedEventHandler(this.CmbBackgroundType_SelectionChanged);
        //        return;
        //    case 197:
        //        this.ImgBacground = (System.Windows.Controls.Image)target;
        //        return;
        //    case 198:
        //        this.txtSceneName = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 199:
        //        this.CmbBorderType = (System.Windows.Controls.ComboBox)target;
        //        this.CmbBorderType.SelectionChanged += new SelectionChangedEventHandler(this.CmbBorderType_SelectionChanged);
        //        return;
        //    case 200:
        //        this.ImgBorder = (System.Windows.Controls.Image)target;
        //        return;
        //    case 201:
        //        this.IsSceneActive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 202:
        //        this.btnSaveSelectScene = (System.Windows.Controls.Button)target;
        //        this.btnSaveSelectScene.Click += new RoutedEventHandler(this.btnSaveSelectScene_Click);
        //        return;
        //    case 203:
        //        this.btnCancelSelectScene = (System.Windows.Controls.Button)target;
        //        this.btnCancelSelectScene.Click += new RoutedEventHandler(this.btnCancelSelectScene_Click);
        //        return;
        //    case 204:
        //        this.btnBackScene = (System.Windows.Controls.Button)target;
        //        this.btnBackScene.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 205:
        //        this.DGManageScene = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 208:
        //        this.TabManageAudio = (TabItem)target;
        //        return;
        //    case 209:
        //        this.DGManageAudio = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 212:
        //        this.btnBackAudio = (System.Windows.Controls.Button)target;
        //        this.btnBackAudio.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 213:
        //        this.txtAudioDescription = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 214:
        //        this.btnSelectAudio = (System.Windows.Controls.Button)target;
        //        this.btnSelectAudio.Click += new RoutedEventHandler(this.btnSelectAudio_Click);
        //        return;
        //    case 215:
        //        this.txtSelectedAudio = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 216:
        //        this.btnSaveSelectAudio = (System.Windows.Controls.Button)target;
        //        this.btnSaveSelectAudio.Click += new RoutedEventHandler(this.btnSaveSelectAudio_Click);
        //        return;
        //    case 217:
        //        this.btnCancelSelectAudio = (System.Windows.Controls.Button)target;
        //        this.btnCancelSelectAudio.Click += new RoutedEventHandler(this.btnCancelSelectAudio_Click);
        //        return;
        //    case 218:
        //        this.IsAudioActive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 219:
        //        this.TabManageVideoBG = (TabItem)target;
        //        return;
        //    case 220:
        //        this.DGManageVideoBG = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 223:
        //        this.btnBackVideoBG = (System.Windows.Controls.Button)target;
        //        this.btnBackVideoBG.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 224:
        //        this.txtVideoBGDescription = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 225:
        //        this.btnSelectVideoBG = (System.Windows.Controls.Button)target;
        //        this.btnSelectVideoBG.Click += new RoutedEventHandler(this.btnSelectVideoBG_Click);
        //        return;
        //    case 226:
        //        this.txtSelectedVideoBG = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 227:
        //        this.btnSaveVideoBG = (System.Windows.Controls.Button)target;
        //        this.btnSaveVideoBG.Click += new RoutedEventHandler(this.btnSaveVideoBG_Click);
        //        return;
        //    case 228:
        //        this.btnCancelVideoBG = (System.Windows.Controls.Button)target;
        //        this.btnCancelVideoBG.Click += new RoutedEventHandler(this.btnCancelVideoBG_Click);
        //        return;
        //    case 229:
        //        this.IsVideoBGActive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 230:
        //        this.TabManageVideo = (TabItem)target;
        //        return;
        //    case 231:
        //        this.DGManageVideo = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 235:
        //        this.btnBackVideo = (System.Windows.Controls.Button)target;
        //        this.btnBackVideo.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 236:
        //        this.txtVideoDescription = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 237:
        //        this.btnSelectVideo = (System.Windows.Controls.Button)target;
        //        this.btnSelectVideo.Click += new RoutedEventHandler(this.btnSelectVideo_Click);
        //        return;
        //    case 238:
        //        this.txtSelectedVideo = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 239:
        //        this.btnSaveSelectVideo = (System.Windows.Controls.Button)target;
        //        this.btnSaveSelectVideo.Click += new RoutedEventHandler(this.btnSaveSelectVideo_Click);
        //        return;
        //    case 240:
        //        this.btnCancelSelectVideo = (System.Windows.Controls.Button)target;
        //        this.btnCancelSelectVideo.Click += new RoutedEventHandler(this.btnCancelSelectVideo_Click);
        //        return;
        //    case 241:
        //        this.IsVideoActive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 242:
        //        this.TabCharacterConfiguration = (TabItem)target;
        //        return;
        //    case 243:
        //        this.DGCharacter = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 246:
        //        this.txtCharacterName = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 247:
        //        this.IsCharacterActive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 248:
        //        this.btnSaveCharacter = (System.Windows.Controls.Button)target;
        //        this.btnSaveCharacter.Click += new RoutedEventHandler(this.btnSaveCharacter_Click);
        //        return;
        //    case 249:
        //        this.btnResetCharacter = (System.Windows.Controls.Button)target;
        //        this.btnResetCharacter.Click += new RoutedEventHandler(this.btnResetCharacter_Click);
        //        return;
        //    case 250:
        //        this.btnBackCharacter = (System.Windows.Controls.Button)target;
        //        this.btnBackCharacter.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 251:
        //        this.TabManageStockShot = (TabItem)target;
        //        return;
        //    case 252:
        //        this.grdManagestockShotImages = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 255:
        //        this.btnBackStockShot = (System.Windows.Controls.Button)target;
        //        this.btnBackStockShot.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 256:
        //        this.btnSelectedStockImage = (System.Windows.Controls.Button)target;
        //        this.btnSelectedStockImage.Click += new RoutedEventHandler(this.btnSelectedStockImage_Click);
        //        return;
        //    case 257:
        //        this.txtSelectedStockImage = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 258:
        //        this.chkIsStockImageActive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 259:
        //        this.btnSaveStockShotImage = (System.Windows.Controls.Button)target;
        //        this.btnSaveStockShotImage.Click += new RoutedEventHandler(this.btnSaveStockShotImage_Click);
        //        return;
        //    case 260:
        //        this.btnCancelStockShot = (System.Windows.Controls.Button)target;
        //        this.btnCancelStockShot.Click += new RoutedEventHandler(this.btnCancelStockShot_Click);
        //        return;
        //    case 261:
        //        this.IsStockShotImgActive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 262:
        //        this.TabManageOverlay = (TabItem)target;
        //        return;
        //    case 263:
        //        this.DGManageOverlay = (System.Windows.Controls.DataGrid)target;
        //        return;
        //    case 266:
        //        this.btnBackOverlay = (System.Windows.Controls.Button)target;
        //        this.btnBackOverlay.Click += new RoutedEventHandler(this.btnBack_Click);
        //        return;
        //    case 267:
        //        this.txtOverlayDescription = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 268:
        //        this.btnSelectOverlay = (System.Windows.Controls.Button)target;
        //        this.btnSelectOverlay.Click += new RoutedEventHandler(this.btnSelectOverlay_Click);
        //        return;
        //    case 269:
        //        this.txtSelectedOverlay = (System.Windows.Controls.TextBox)target;
        //        return;
        //    case 270:
        //        this.btnSaveSelectOverlay = (System.Windows.Controls.Button)target;
        //        this.btnSaveSelectOverlay.Click += new RoutedEventHandler(this.btnSaveSelectOverlay_Click);
        //        return;
        //    case 271:
        //        this.btnCancelSelectOverlay = (System.Windows.Controls.Button)target;
        //        this.btnCancelSelectOverlay.Click += new RoutedEventHandler(this.btnCancelSelectOverlay_Click);
        //        return;
        //    case 272:
        //        this.IsOverlayActive = (System.Windows.Controls.CheckBox)target;
        //        return;
        //    case 273:
        //        this.KeyBorder = (Border)target;
        //        return;
        //    case 274:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 275:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 276:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 277:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 278:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 279:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 280:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 281:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 282:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 283:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 284:
        //        this.Delete = (System.Windows.Controls.Button)target;
        //        this.Delete.Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 285:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 286:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 287:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 288:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 289:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 290:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 291:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 292:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 293:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 294:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 295:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 296:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 297:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 298:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 299:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 300:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 301:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 302:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 303:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 304:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 305:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 306:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 307:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 308:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 309:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 310:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 311:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 312:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 313:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 314:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 315:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 316:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 317:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 318:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 319:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 320:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 321:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 322:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 323:
        //        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btn_Click);
        //        return;
        //    case 324:
        //        this.ucAddEditSpecPrintProfile = (AddEditSpecPrintProfile)target;
        //        return;
        //    case 325:
        //        this.CtrlVideoSlotsTime = (VideoSlotsTime)target;
        //        return;
        //    case 326:
        //        this.MsgBox = (DigiMessageBox)target;
        //        return;
        //    default:
        //        goto IL_23DA;
        //    }
        //    this.IsBackgroundActive = (System.Windows.Controls.CheckBox)target;
        //    return;
        //    IL_23DA:
        //    this._contentLoaded = true;
        //}

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        //void IStyleConnector.Connect(int connectionId, object target)
        //{
        //    if (connectionId <= 126)
        //    {
        //        int arg_26_0;
        //        if (connectionId > 80)
        //        {
        //            switch (connectionId)
        //            {
        //            case 96:
        //                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.EditBackground);
        //                return;
        //            case 97:
        //                break;
        //            case 98:
        //            case 99:
        //            case 100:
        //                return;
        //            case 101:
        //                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnEditCurrency_Click);
        //                if (!false)
        //                {
        //                    return;
        //                }
        //                return;
        //            case 102:
        //                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDeleteCurrency_Click);
        //                return;
        //            default:
        //                if (!false)
        //                {
        //                    switch (connectionId)
        //                    {
        //                    case 115:
        //                        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.EditGraphics);
        //                        return;
        //                    case 116:
        //                        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDeletegraphics_Click);
        //                        return;
        //                    default:
        //                        arg_26_0 = connectionId;
        //                        if (false)
        //                        {
        //                            goto IL_25;
        //                        }
        //                        switch (connectionId)
        //                        {
        //                        case 125:
        //                            ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnEditDiscount_Click);
        //                            return;
        //                        case 126:
        //                            ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDeleteDiscount_Click);
        //                            return;
        //                        default:
        //                            return;
        //                        }
        //                        break;
        //                    }
        //                }
        //                break;
        //            }
        //            ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDeleteBackground_Click);
        //            return;
        //        }
        //        arg_26_0 = connectionId;
        //        IL_25:
        //        if (arg_26_0 != 2)
        //        {
        //            switch (connectionId)
        //            {
        //            case 74:
        //                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnEditSpecSetting_Click);
        //                break;
        //            case 75:
        //                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDeleteSpecSetting_Click);
        //                break;
        //            case 79:
        //                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnEdit_Click);
        //                break;
        //            case 80:
        //                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDelete_Click);
        //                break;
        //            }
        //        }
        //        else
        //        {
        //            ((System.Windows.Controls.RadioButton)target).Checked += new RoutedEventHandler(this.RadioButton_Checked);
        //        }
        //    }
        //    else
        //    {
        //        int arg_154_0;
        //        int expr_BD = arg_154_0 = connectionId;
        //        int arg_154_1;
        //        int expr_C3 = arg_154_1 = 234;
        //        if (expr_C3 != 0)
        //        {
        //            if (expr_BD > expr_C3)
        //            {
        //                switch (connectionId)
        //                {
        //                case 244:
        //                    ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnEditCharacter_Click);
        //                    break;
        //                case 245:
        //                    ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDeleteCharacter_Click);
        //                    break;
        //                default:
        //                    switch (connectionId)
        //                    {
        //                    case 253:
        //                        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnEditStockShotImage_Click);
        //                        break;
        //                    case 254:
        //                        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDeleteStockShotImage_Click);
        //                        break;
        //                    default:
        //                        if (!false)
        //                        {
        //                            arg_154_0 = connectionId;
        //                            arg_154_1 = 264;
        //                            goto IL_154;
        //                        }
        //                        break;
        //                    }
        //                    break;
        //                }
        //                return;
        //            }
        //            switch (connectionId)
        //            {
        //            case 206:
        //                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnEditScene_Click);
        //                return;
        //            case 207:
        //                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDeleteScene_Click);
        //                return;
        //            case 208:
        //            case 209:
        //                return;
        //            case 210:
        //                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnEditAudio_Click);
        //                return;
        //            case 211:
        //                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDeleteAudio_Click);
        //                return;
        //            default:
        //                switch (connectionId)
        //                {
        //                case 221:
        //                    ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnEditVideoBG_Click);
        //                    return;
        //                case 222:
        //                    ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDeleteVideoBG_Click);
        //                    return;
        //                default:
        //                    switch (connectionId)
        //                    {
        //                    case 232:
        //                        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnSlotTimeFrame_Click);
        //                        return;
        //                    case 233:
        //                        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnEditVideo_Click);
        //                        return;
        //                    case 234:
        //                        ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDeleteVideo_Click);
        //                        return;
        //                    default:
        //                        return;
        //                    }
        //                    break;
        //                }
        //                break;
        //            }
        //        }
        //        IL_154:
        //        switch (arg_154_0 - arg_154_1)
        //        {
        //        case 0:
        //            ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnEditOverlay_Click);
        //            break;
        //        case 1:
        //            ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDeleteOverlay_Click);
        //            break;
        //        }
        //    }
        //} 
        #endregion

    }
}
