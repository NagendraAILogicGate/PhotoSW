using DigiAuditLogger;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.DirectoryInfoExt;
using ErrorHandler;
using FrameworkHelper;
using MControls;
using MPLATFORMLib;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using DigiPhoto;
using PhotoSW.PSControls;
using PhotoSW.Shader;
using DigiPhoto.Utility.Repository.ValueType;
using System.Windows.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Input;

namespace PhotoSW.Views
{
    public partial class ClientView : Window, IComponentConnector
    {
        private System.Windows.Forms.Timer tmr;

        private int mktImgcount = 0;

        private string retPath = "";

        public int _currentImageId = 0;

        public bool Preview;

        private string MktImgPath = string.Empty;

        private int mktImgTime = 0;

        private List<FileInfo> imgfilesInfo = null;

        private MFileSeeking mSeeking = new MFileSeeking();

        public MPreviewClass previewSecondary;

        public int FilpFrom = 0;

        private string viewGroupList = string.Empty;    
        public static string selectImageForFB = "";
        public static List<string> listImageForFB = new List<string>();
        public BitmapImage unlockImage;
        private string _currentImage;
        public delegate void NextPrimeDelegate();

        public enum SearchTypeConfig
        {
            Image = 1,
            Video,
            ImageVideo
        }

        public static List<LstMyItems> itemsNotPrinted = new List<LstMyItems>();

        public bool flgViewScrl = false;

        private int num = 0;

        public string pagename;

        private bool continueCalculating = false;

        private bool IsEnableGrouping = false;

        private int count;


        private double dbContr = 0.0;

        private double dbBrit = 0.0;

        private Process currentProcess = Process.GetCurrentProcess();

        public string Photoname = "";

        public long unlockImageId;

        public bool ismod;


        private int _currentMediaType;

        private bool flgLoadNext = false;

        private bool isBarcodeActive = false;

        private ShEffect _sharpeff = new ShEffect();

        private bool flgGridWithoutPreview = true;

        private int scrollIndexWithoutPreview;

        private int scrollIndexWithPreview;

        public string Savebackpid = "";

        public AssociateImage uctlAssociateImage = null;

        public ModalDialog ModalDialog = null;

        public SaveGroup savegroupusercontrol = null;

        public bool isSingleScreenPreview = false;

        private ClientView clientWin = null;

        public bool returntoHome = true;

        private SearchDetailInfo searchDetails = new SearchDetailInfo();

        public int serachType = 0;

        private FileStream memoryFileStream;

        private static string vsMediaFileName = "";

        public long MaxPhotoIdCriteria = 0L;

        public long MinPhotoIdCriteria = 0L;

        public int NewReord = 0;

        public int AngleValue = 0;

        public MLMediaPlayer mplayer;

        private int searchType = 3;

        private int viewCount = 0;
        private int currentWidth = 0;

        private string currentBarCodePath = "";

        private string barcode = "";
        private string keygen = "";
        private string QRCode = "";
        private string currentPhotoName = "";
        private SearchResult.SearchTypeConfig searchConfig = (SearchResult.SearchTypeConfig)0;

        private List<string> imageList = new List<string>
        {
            "EPS",
            "TIFF",
            "JPEG",
            "GIF",
            "PNG",
            "BMP",
            "JPG"
        };

        private List<string> videoList = new List<string>
        {
            "3G2",
            "3GP",
            "ASF",
            "ASX",
            "AVI",
            "FLV",
            "MOV",
            "MP4",
            "MPG",
            "RM",
            "SWF",
            "VOB",
            "WMV"
        };

        private MLFrameExtractor mExtractor;



        //private bool _contentLoaded;

        public BitmapImage CurrentBitmapImage
        {
            get;
            set;
        }


        public BitmapImage ChildImage
        {
            get;
            set;
        }

        public bool DefaultView
        {
            get;
            set;
        }

        public bool GroupView
        {
            get;
            set;
        }


        public string ProductType
        {
            get;
            set;
        }

        public ClientView()
        {
            this.InitializeComponent();           

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                this.GetMktImgInfo();
                bool expr_12 = this.Preview;
                bool flag;
                if (!false)
                {
                    flag = expr_12;
                }
                bool arg_23_0 = flag;
                while (!arg_23_0)
                {
                    bool expr_205 = arg_23_0 = this.GroupView;
                    if (!false)
                    {
                        flag = expr_205;
                        if (flag)
                        {
                            //this.thumbPreview.Visibility = Visibility.Visible;
                            //  this.lstImages.Items.Clear();
                            using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.GroupImages.GetEnumerator())
                            {
                                while (true)
                                {
                                    flag = enumerator.MoveNext();
                                    if (!flag)
                                    {
                                        break;
                                    }
                                    LstMyItems current = enumerator.Current;
                                    // this.lstImages.Items.Add(current);
                                }
                            }
                            //this.imgMain1.Visibility = Visibility.Collapsed;
                            //this.watermark.Visibility = Visibility.Collapsed;
                            goto IL_18B;
                        }
                        //this.thumbPreview.Visibility = Visibility.Collapsed;
                        bool arg_CA_0;
                        bool expr_54 = arg_CA_0 = this.DefaultView;
                        if (8 == 0)
                        {
                            goto IL_CA;
                        }
                        flag = !expr_54;
                        if (flag)
                        {
                            break;
                        }
                        this.imgDefault.Source = new BitmapImage(new Uri("/images/all_frames_new.png", UriKind.Relative));
                        //this.imgMain1.Visibility = Visibility.Collapsed;
                        //this.watermark.Visibility = Visibility.Collapsed;
                        int arg_AD_0 = (this.MktImgPath == "") ? 1 : 0;
                        bool arg_C5_0;
                        do
                        {
                        IL_AD:
                            if (arg_AD_0 == 0)
                            {
                                arg_C5_0 = ((arg_AD_0 = ((this.mktImgTime == 0) ? 1 : 0)) != 0);
                            }
                            else
                            {
                                if (false)
                                {
                                    goto IL_18B;
                                }
                                arg_C5_0 = ((arg_AD_0 = 1) != 0);
                            }
                        }
                        while (5 == 0);
                        flag = arg_C5_0;
                        if (-1 == 0)
                        {
                            break;
                        }
                        arg_CA_0 = flag;
                    IL_CA:
                        if (!arg_CA_0)
                        {
                            // this.instructionVideo.Visibility = Visibility.Visible;
                            this.StartSaver();
                            //  this.SetMediaSource(this.MktImgPath);
                        }
                        else
                        {
                            this.imgDefault.Visibility = Visibility.Visible;
                        }
                        break;
                    IL_18B:
                        this.imgDefault.Visibility = Visibility.Collapsed;
                        bool expr_1A5 = (arg_AD_0 = ((!this.tmr.Enabled) ? 1 : 0)) != 0;
                        if (2 == 0)
                        {
                            //goto IL_AD;
                        }
                        flag = expr_1A5;
                        if (!flag)
                        {
                            this.tmr.Stop();
                        }
                        // this.instructionVideo.Visibility = Visibility.Collapsed;
                        if (6 != 0)
                        {
                        }
                        break;
                    }
                }
                base.WindowState = WindowState.Maximized;
                this.ContentContainer.Focus();
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }


        public void LoadWindow()
        {
            try
            {
                //this.txbUserName.Text = LoginUser.UserName;
                //this.txbStoreName.Text = LoginUser.StoreName;
                this.returntoHome = true;
                RobotImageLoader.GetConfigData();
                RobotImageLoader.LstUnlocknames = new List<string>();
                RobotImageLoader.IsPreviewModeActive = false;
                bool flag = !RobotImageLoader.Is9ImgViewActive;
                bool arg_5F_0 = flag;
                int arg_6F2_0;
                bool expr_21F;
                do
                {
                    if (!arg_5F_0)
                    {
                        this.scrollIndexWithoutPreview = 9;
                        this.scrollIndexWithPreview = 9;
                    }
                    RobotImageLoader.thumbSet = this.scrollIndexWithoutPreview;
                    if (this.pagename != "Saveback")
                    {
                        if (this.serachType == 1)
                        {
                            this.searchDetails.NewRecord = 0;
                            this.searchDetails.StartIndex = 0L;
                            RobotImageLoader.Is16ImgViewActive = false;
                            RobotImageLoader.Is9ImgViewActive = true;
                            this.searchDetails.PageSize = 9;
                        }
                        this.serachType = 0;
                        this.searchDetails.PageNumber = 1;
                        //this.SetMediaType();
                        RobotImageLoader.LoadImages(this.searchDetails);
                        flag = !(RobotImageLoader.SearchCriteria != "TimeWithQrcode");
                        bool expr_11F = (arg_6F2_0 = (flag ? 1 : 0)) != 0;
                        if (false)
                        {
                            goto IL_6F1;
                        }
                        if (!expr_11F)
                        {
                            //this.btnPrevButton.IsEnabled = true;
                            //this.btnNextButton.IsEnabled = true;
                            //this.clearGifCollage();
                            //this.btnEdit.Visibility = Visibility.Visible;
                        }
                        if (5 == 0)
                        {
                            goto IL_408;
                        }
                    }
                    if (RobotImageLoader.robotImages != null)
                    {
                        this.count = RobotImageLoader.robotImages.Count;
                    }
                    if (RobotImageLoader.GroupImages == null)
                    {
                        RobotImageLoader.GroupImages = new List<LstMyItems>();
                    }
                    if (RobotImageLoader.PrintImages == null)
                    {
                        RobotImageLoader.PrintImages = new List<LstMyItems>();
                    }
                    if (this.scrollIndexWithoutPreview != 9)
                    {
                        goto IL_2A5;
                    }
                    if (RobotImageLoader.GroupImages != null && RobotImageLoader.GroupImages.Count > 0)
                    {
                        RobotImageLoader.GroupImages.ForEach(delegate (LstMyItems t)
                        {
                            if (!false)
                            {
                                t.GridMainHeight = 190;
                                if (!false)
                                {
                                    if (false)
                                    {
                                        return;
                                    }
                                    t.GridMainWidth = 226;
                                }
                            }
                            do
                            {
                                t.GridMainRowHeight1 = 140;
                                int expr_2A = 50;
                                if (4 != 0)
                                {
                                    t.GridMainRowHeight2 = expr_2A;
                                }
                            }
                            while (-1 == 0);
                        });
                    }
                    flag = (RobotImageLoader.PrintImages == null || RobotImageLoader.PrintImages.Count <= 0);
                    expr_21F = (arg_5F_0 = flag);
                }
                while (-1 == 0);
                if (!expr_21F)
                {
                    RobotImageLoader.PrintImages.ForEach(delegate (LstMyItems t)
                    {
                        if (!false)
                        {
                            t.GridMainHeight = 190;
                            if (!false)
                            {
                                if (false)
                                {
                                    return;
                                }
                                t.GridMainWidth = 226;
                            }
                        }
                        do
                        {
                            t.GridMainRowHeight1 = 140;
                            int expr_2A = 50;
                            if (4 != 0)
                            {
                                t.GridMainRowHeight2 = expr_2A;
                            }
                        }
                        while (-1 == 0);
                    });
                }
                if (RobotImageLoader.robotImages == null || RobotImageLoader.robotImages.Count <= 0)
                {
                    goto IL_29E;
                }
            IL_274:
                RobotImageLoader.robotImages.ForEach(delegate (LstMyItems t)
                {
                    if (!false)
                    {
                        t.GridMainHeight = 190;
                        if (!false)
                        {
                            if (false)
                            {
                                return;
                            }
                            t.GridMainWidth = 226;
                        }
                    }
                    do
                    {
                        t.GridMainRowHeight1 = 140;
                        int expr_2A = 50;
                        if (4 != 0)
                        {
                            t.GridMainRowHeight2 = expr_2A;
                        }
                    }
                    while (-1 == 0);
                });
            IL_29E:
                if (false)
                {
                    goto IL_6F0;
                }
            IL_2A5:
                this._sharpeff.Strength = 0.075000000000000011;
                this._sharpeff.PixelWidth = 0.0015;
                this._sharpeff.PixelHeight = 0.0015;
                this.GrdSharpen.Effect = this._sharpeff;
                //this.PreviewPhoto();
                flag = (!(RobotImageLoader.SearchCriteria == "Time") && !(RobotImageLoader.SearchCriteria == "QRCODE") && !(RobotImageLoader.SearchCriteria == "TimeWithQrcode"));
            IL_337:
                if (!flag)
                {
                    //this.btnPrevButton.Visibility = Visibility.Visible;
                    //this.btnNextButton.Visibility = Visibility.Visible;
                    ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
                }
                else if (RobotImageLoader.RFID == "")
                {
                    //this.btnPrevButton.Visibility = Visibility.Hidden;
                    //this.btnNextButton.Visibility = Visibility.Hidden;
                    ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
                    if (false)
                    {
                        goto IL_274;
                    }
                }
                else
                {
                    //this.btnPrevButton.Visibility = Visibility.Visible;
                    //this.btnNextButton.Visibility = Visibility.Visible;
                    ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
                    //this.vwGroup.Text = "View Group";
                }
                MainWindow instance;
                if (!(this.pagename == "MainGroup"))
                {
                    if (this.pagename == "Saveback")
                    {
                        try
                        {
                            if (MainWindow.Instance != null)
                            {
                                instance = MainWindow.Instance;
                            }
                            else
                            {
                                instance = MainWindow.Instance;
                                if (2 == 0)
                                {
                                    goto IL_4BB;
                                }
                            }
                            if (instance != null && !(instance.IsGoupped == "View All"))
                            {
                                instance.IsGoupped = "View Group";
                                //this.vwGroup.Text = "View Group";
                                this.lstImages.Items.Clear();
                                this.continueCalculating = true;
                                //this.SetMessageText("Grouped");
                                //this.SetMessageText("");
                                if (RobotImageLoader._objnewincrement != null && RobotImageLoader._objnewincrement.Count == 0)
                                {
                                    RobotImageLoader._objnewincrement = RobotImageLoader.robotImages;
                                }
                                this.LoadImagestoList();
                                goto IL_53E;
                            }
                        IL_4BB:
                            //this.ViewGroup();
                            if (true)
                            {
                                goto IL_54E;
                            }
                        IL_53E:
                            this.FillImageList();
                            this.CheckSelectAllGroup();
                        IL_54E:;
                        }
                        catch (Exception serviceException)
                        {
                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                        goto IL_6A5;
                    }
                    if (this.pagename == "Placeback")
                    {
                        try
                        {
                            if (RobotImageLoader.robotImages.Count == 0)
                            {
                                RobotImageLoader.LoadImages();
                            }
                            if (RobotImageLoader.robotImages.Count != 0)
                            {
                                bool flag2 = false;
                                while (true)
                                {
                                IL_668:
                                    flag = !flag2;
                                    while (flag)
                                    {
                                        if (6 != 0)
                                        {
                                            LstMyItems lstMyItems = new LstMyItems();
                                            lstMyItems = RobotImageLoader.robotImages.Where(delegate (LstMyItems xb)
                                            {
                                                bool result;
                                                do
                                                {
                                                    if (true && !false)
                                                    {
                                                        result = (xb.PhotoId == this.Savebackpid.ToInt32(false));
                                                    }
                                                    while (false)
                                                    {
                                                    }
                                                }
                                                while (8 == 0);
                                                return result;
                                            }).FirstOrDefault<LstMyItems>();
                                            if (lstMyItems != null)
                                            {
                                                goto Block_50;
                                            }
                                            if (RobotImageLoader.robotImages.Count != 0)
                                            {
                                                RobotImageLoader.LoadImages();
                                                goto IL_668;
                                            }
                                            break;
                                        }
                                    }
                                    goto IL_675;
                                }
                            Block_50:
                                this.continueCalculating = true;
                                if (this.lstImages.Items.Count > 0)
                                {
                                    this.lstImages.Items.Clear();
                                }
                                this.LoadImagestoList();
                            IL_675:;
                                //	this.SetMessageText("Grouped");
                            }
                        }
                        catch (Exception serviceException)
                        {
                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                        goto IL_6A5;
                    }
                    this.LoadImages();
                    goto IL_6A5;
                }
            IL_408:

                if (!flag)
                {
                    //this.vwGroup.Text = "View Group";
                    if (8 == 0)
                    {
                        goto IL_337;
                    }
                }
            //this.ViewGroup();
            IL_6A5:
                if (this.pagename == "Placeback")
                {
                    this.CheckForAllImgSelectToPrint();
                    goto IL_708;
                }
                if (this.pagename != "MainGroup")
                {
                    arg_6F2_0 = ((!(this.pagename != "Saveback")) ? 1 : 0);
                    goto IL_6F1;
                }
            IL_6F0:
                arg_6F2_0 = 1;
            IL_6F1:
                if (arg_6F2_0 == 0)
                {
                    this.FillImageList();
                    this.CheckSelectAllGroup();
                }
            IL_708:;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            finally
            {
                MemoryManagement.FlushMemory();
            }
            this.IMGFrame.Visibility = Visibility.Collapsed;
            Grid.SetColumnSpan(this.thumbPreview, 2);
            Grid.SetColumn(this.thumbPreview, 0);
            this.thumbPreview.Margin = new Thickness(0.0);
            if (RobotImageLoader.robotImages != null)
            {
                if (RobotImageLoader.Is16ImgViewActive && !RobotImageLoader.Is9ImgViewActive)
                {
                    //this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1.png", UriKind.Relative));
                    ////this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/16blocks_red.png", UriKind.Relative));
                    //this.imgwithoutPreview9.Source = new BitmapImage(new Uri("/images/9Blocks_black.png", UriKind.Relative));
                    //this.ImageSize(16);
                }
                else if (!RobotImageLoader.Is16ImgViewActive && RobotImageLoader.Is9ImgViewActive)
                {
                    //this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1.png", UriKind.Relative));
                    ////	this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/16blocks_black.png", UriKind.Relative));
                    //this.imgwithoutPreview9.Source = new BitmapImage(new Uri("/images/9Blocks_red.png", UriKind.Relative));
                    //this.ImageSize(9);
                }
                else
                {
                    //this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1.png", UriKind.Relative));
                    ////	this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/16blocks_black.png", UriKind.Relative));
                    //this.imgwithoutPreview9.Source = new BitmapImage(new Uri("/images/9Blocks_black.png", UriKind.Relative));
                }
            }
        }

        private void StartSaver()
        {
            while (true)
            {
                if (!false)
                {
                    this.tmr = new System.Windows.Forms.Timer();
                    goto IL_0D;
                }
            IL_1D:
                if (!false)
                {
                }
                if (false)
                {
                    continue;
                }
                this.tmr.Tick += new EventHandler(this.tmr_Tick);
                if (!false)
                {
                    break;
                }
            IL_0D:
                this.tmr.Interval = this.mktImgTime;
                goto IL_1D;
            }
        }

        private void tmr_Tick(object sender, EventArgs e)
        {
            // this.SetMediaSource(this.MktImgPath);
        }

        private void GetMktImgInfo()
        {
            do
            {
                if (!false)
                {
                    try
                    {
                        StreamReader streamReader = new StreamReader(Environment.CurrentDirectory + "\\ss.dat");
                        //goto IL_35;
                        try
                        {
                            do
                            {
                            IL_35:
                                string cipherString = streamReader.ReadLine();
                                string text = PhotoSW.CryptorEngine.Decrypt(cipherString, true);
                                LoginUser.SubStoreId = Convert.ToInt32(text.Split(new char[]
                                {
                                    ','
                                })[0]);
                            }
                            while (false);
                        }
                        finally
                        {
                            if (streamReader != null)
                            {
                                ((IDisposable)streamReader).Dispose();
                            }
                        }
                        List<long> objList = new List<long>
                        {
                            24L,
                            25L
                        };
                        ConfigBusiness configBusiness = new ConfigBusiness();
                        List<iMIXConfigurationInfo> list = (from o in configBusiness.GetNewConfigValues(LoginUser.SubStoreId)
                                                            where objList.Contains(o.IMIXConfigurationMasterId)
                                                            select o).ToList<iMIXConfigurationInfo>();
                        int arg_F1_0;
                        if (list == null)
                        {
                            bool expr_E5 = (arg_F1_0 = ((list.Count > 0) ? 1 : 0)) != 0;
                            if (!false)
                            {
                                arg_F1_0 = ((!expr_E5) ? 1 : 0);
                            }
                        }
                        else
                        {
                            arg_F1_0 = 0;
                        }
                        if (arg_F1_0 == 0)
                        {
                            foreach (iMIXConfigurationInfo current in list)
                            {
                                if (5 == 0)
                                {
                                    goto IL_12E;
                                }
                                long iMIXConfigurationMasterId = current.IMIXConfigurationMasterId;
                                if (iMIXConfigurationMasterId <= 25L)
                                {
                                    if (6 == 0)
                                    {
                                        break;
                                    }
                                    if (iMIXConfigurationMasterId >= 24L)
                                    {
                                        goto IL_12E;
                                    }
                                }
                                continue;
                                continue;
                            IL_12E:
                                switch ((int)(iMIXConfigurationMasterId - 24L))
                                {
                                    case 0:
                                        this.MktImgPath = current.ConfigurationValue;
                                        break;
                                    case 1:
                                        this.mktImgTime = ((current.ConfigurationValue != null) ? Convert.ToInt32(current.ConfigurationValue) : 10) * 1000;
                                        break;
                                }
                            }
                        }
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
            }
            while (false);
        }

        private void ExitSlideShow_Click(object sender, RoutedEventArgs e)
        {
            base.Close();
        }

        private void LoadImages()
        {
            try
            {
                //this.txtimageofphotographer.Visibility = Visibility.Collapsed;
                //this.txtcountspace.Visibility = Visibility.Collapsed;

                if (RobotImageLoader.robotImages.Count != 0)
                {
                    int arg_77_0;
                    if (RobotImageLoader.UserId > 0)
                    {
                        if (!(RobotImageLoader.SearchCriteria == "Time"))
                        {
                            bool expr_1C3 = (arg_77_0 = ((RobotImageLoader.SearchCriteria == "TimeWithQrcode") ? 1 : 0)) != 0;
                            if (!false)
                            {
                                arg_77_0 = ((!expr_1C3) ? 1 : 0);
                            }
                        }
                        else
                        {
                            arg_77_0 = 0;
                        }
                    }
                    else
                    {
                        arg_77_0 = 1;
                    }

                    while (true)
                    {
                        RobotImageLoader.IsLastPage = false;
                        this.lstImages.Items.Clear();
                        this.num = 0;
                        if (!this.continueCalculating)
                        {
                            goto IL_112;
                        }
                        if (8 == 0)
                        {
                            goto IL_180;
                        }
                        this.continueCalculating = false;
                    IL_14C:
                        if (4 == 0)
                        {
                            continue;
                        }
                        if (!false)
                        {
                            break;
                        }
                    IL_112:
                        this.continueCalculating = true;
                        if (RobotImageLoader.robotImages == null)
                        {
                            RobotImageLoader.LoadImages();
                        }
                        this.LoadImagestoList();
                        this.CheckSelectAllGroup();
                        //	this.SPSelectAll.Visibility = Visibility.Visible;
                        goto IL_14C;
                    }
                }
                else
                {
                    this.lstImages.Items.Clear();
                    RobotImageLoader.IsLastPage = true;
                }
            IL_156:
                if (2 == 0)
                {
                    goto IL_156;
                }
            //	this.SetMessageText("Grouped");
            IL_180:;
            }
            catch (Exception serviceException)
            {
                if (8 != 0)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
            finally
            {
            }
            if (!false)
            {
            }
        }

        private void CheckSelectAllGroup()
        {
            int arg_35_0;
            int expr_01 = arg_35_0 = (RobotImageLoader.IsLastPage ? 1 : 0);
            int arg_35_1;
            int expr_07 = arg_35_1 = 0;
            if (expr_07 != 0)
            {
                goto IL_35;
            }
            bool flag = expr_01 == expr_07;
            bool arg_13_0 = flag;
        IL_13:
            if (!arg_13_0)
            {
                return;
            }
            if (RobotImageLoader.ViewGroupedImagesCount == null)
            {
                goto IL_3F;
            }
            arg_35_0 = RobotImageLoader.robotImages.Count<LstMyItems>();
        IL_2B:
            arg_35_1 = RobotImageLoader.ViewGroupedImagesCount.Count;
        IL_35:
            bool expr_35 = arg_13_0 = (arg_35_0 == arg_35_1);
            bool arg_A1_0;
            if (3 != 0)
            {
                arg_A1_0 = !expr_35;
                goto IL_40;
            }
            goto IL_13;
        IL_3F:
            arg_A1_0 = true;
        IL_40:
            flag = arg_A1_0;
            bool expr_A4 = (arg_35_0 = (flag ? 1 : 0)) != 0;
            if (false)
            {
                goto IL_2B;
            }
            if (!expr_A4)
            {
                //  this.chkSelectAll.IsChecked = new bool?(true);
                if (8 != 0)
                {
                    goto IL_70;
                }
            }
        //  this.chkSelectAll.IsChecked = new bool?(false);
        IL_70:
            if (4 == 0)
            {
                goto IL_3F;
            }
            // this.chkSelectAll.Visibility = Visibility.Visible;
        }

        public void LoadImagestoList1(List<LstMyItems> lstMyItems, string str)
        {
            this.lstImages.Items.Clear();
            var obj = lstMyItems.GetEnumerator();

            if (str == "View All")
            {
                while (obj.MoveNext())
                {
                    LstMyItems photoItem = obj.Current;
                    this.lstImages.Items.Add(photoItem);
                    this.viewGroupList = str;
                }
            }
            else if (str == "View Group")
            {
                while (obj.MoveNext())
                {
                    LstMyItems photoItem = obj.Current;
                    this.lstImages.Items.Add(photoItem);
                    this.viewGroupList = str;
                }
            }
            else
            {
                this.lstImages.Items.Clear();
                this.viewGroupList = "";
            }
        }
     

        public void LoadImagestoList()
        {
            this.imgDefault.Visibility = Visibility.Collapsed;
            int num = RobotImageLoader.robotImages.Count;
            string test = this.viewGroupList;
            LstMyItems expr_2A9 = new LstMyItems();
            LstMyItems lstMyItems;
            if (true)
            {
                lstMyItems = expr_2A9;
            }
            //  this.txtSelectedImages.Foreground = new SolidColorBrush(Colors.White);
            bool flag = this.num >= num;
            if (!flag)
            {
                if (false)
                {
                    goto IL_FC;
                }
                lstMyItems = RobotImageLoader.robotImages[this.num];
                if (!this.continueCalculating)
                {
                    goto IL_271;
                }
                if(this.viewGroupList == "View All")
                {
                    this.lstImages.Items.Clear();
                    if (viewCount >= 1)
                        while (viewCount >= 1)
                        {
                            this.lstImages.Items.Add(lstMyItems);
                            viewCount--;
                        }
                }
                else
                {
                    this.lstImages.Items.Add(lstMyItems);
                }
               
                int arg_B7_0;
            //  bool arg_15E_0 = ((this.pagename == "Saveback") ? (arg_B7_0 = 0) : (arg_B7_0 = ((!(this.pagename == "Placeback")) ? 1 : 0))) != 0;
            IL_B0:
                if (8 == 0)
                {
                    goto IL_15D;
                }
                //if (arg_B7_0 != 0)
                //{
                //    goto IL_14D;
                //}
                //if (lstMyItems.PhotoId != this.Savebackpid.ToInt32(false))
                //{
                //    goto IL_14C;
                //}

                if (false)
                {
                    goto IL_14B;
                }
                this.lstImages.SelectedIndex = this.lstImages.Items.Count - 1;
            IL_FC:
                this.lstImages.ScrollIntoView(this.lstImages.SelectedIndex);
                ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
                listBoxItem.Focus();
                this.pagename = "";
            IL_14B:
            IL_14C:
            IL_14D:
            //  arg_15E_0 = (lstMyItems.Name == RobotImageLoader.RFID);
            IL_15D:
                //if (!arg_15E_0)
                //{
                //    goto IL_1DA;
                //}
                //  bool expr_171 = (arg_B7_0 = ((arg_15E_0 = (this.lstImages.SelectedItem == null)) ? 1 : 0)) != 0;
                if (false)
                {
                    goto IL_B0;
                }
                // flag = !expr_171;
            }
            else
            {
                this.continueCalculating = false;
                if (6 != 0)
                {
                    this.num = 0;
                    return;
                }
            }
            if (!flag)
            {
                if (2 == 0)
                {
                    goto IL_270;
                }
                //this.lstImages.SelectedItem = lstMyItems;
                //this.lstImages.ScrollIntoView(this.lstImages.SelectedIndex);
                //ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
                //listBoxItem.Focus();
            }
        IL_1DA:
            int arg_1E6_0;
            int arg_200_0 = arg_1E6_0 = this.num;
            while (2 != 0)
            {
                if (arg_1E6_0 == num - 1)
                {
                    bool expr_1F4 = (arg_1E6_0 = (arg_200_0 = ((this.lstImages.SelectedIndex == -1) ? 1 : 0))) != 0;
                    if (false)
                    {
                        continue;
                    }
                    arg_200_0 = ((!expr_1F4) ? 1 : 0);
                }
                else
                {
                    arg_200_0 = 1;
                }
                break;
            }
            if (arg_200_0 == 0)
            {
                this.lstImages.SelectedIndex = 0;
                this.lstImages.ScrollIntoView(this.lstImages.SelectedIndex);
                ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
                listBoxItem.Focus();
            }
            base.Dispatcher.BeginInvoke(DispatcherPriority.Background, new SearchResult.NextPrimeDelegate(this.LoadImagestoList));
        IL_270:
        IL_271:
            this.num++;
        }

        private void btnAddToGroup_Click(object sender, RoutedEventArgs e)
        {
            Func<LstMyItems, bool> expr_06 = null;
            if (2 != 0)
            {
                Func<LstMyItems, bool> predicate = expr_06;
            }
            try
            {
                RobotImageLoader.curItem = null;
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                System.Windows.Controls.Image image = (System.Windows.Controls.Image)button.Content;
                List<LstMyItems> list = RobotImageLoader.GroupImages.Where(delegate (LstMyItems t)
                {
                    if (false)
                    {
                        goto IL_24;
                    }
                    int arg_1A_0 = t.PhotoId;
                    bool expr_1A;
                    do
                    {
                    IL_07:
                        expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)sender).CommandParameter) ? 1 : 0)) != 0);
                    }
                    while (7 == 0 || 8 == 0);
                    bool flag2 = expr_1A;
                IL_24:
                    bool expr_43 = (arg_1A_0 = (flag2 ? 1 : 0)) != 0;
                    if (!false)
                    {
                        return expr_43;
                    }
                    //goto IL_07;
                }).ToList<LstMyItems>();
                int arg_706_0;
                int arg_706_1;
                bool arg_778_0;
                if (list.Count == 0)
                {
                    IEnumerable<LstMyItems> arg_BB_0 = RobotImageLoader.robotImages;
                    Func<LstMyItems, bool> predicate = delegate (LstMyItems t)
                    {
                        if (false)
                        {
                            goto IL_24;
                        }
                        int arg_1A_0 = t.PhotoId;
                        bool expr_1A;
                        do
                        {
                        IL_07:
                            expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)sender).CommandParameter) ? 1 : 0)) != 0);
                        }
                        while (7 == 0 || 8 == 0);
                        bool flag2 = expr_1A;
                    IL_24:
                        bool expr_43 = (arg_1A_0 = (flag2 ? 1 : 0)) != 0;
                        if (!false)
                        {
                            return expr_43;
                        }
                        //goto IL_07;
                    };
                    LstMyItems lstMyItems = arg_BB_0.Where(predicate).First<LstMyItems>();
                    this.lstImages.SelectedItem = lstMyItems;
                    ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
                    listBoxItem.Focus();
                    if (3 != 0)
                    {
                        LstMyItems lstMyItems2 = new LstMyItems();
                        lstMyItems2 = lstMyItems;
                        lstMyItems2.MediaType = lstMyItems.MediaType;
                        lstMyItems2.VideoLength = lstMyItems.VideoLength;
                        lstMyItems2.Name = lstMyItems.Name;
                        lstMyItems2.IsPassKeyVisible = Visibility.Collapsed;
                        lstMyItems2.PhotoId = lstMyItems.PhotoId;
                        lstMyItems2.FileName = lstMyItems.FileName;
                        lstMyItems2.CreatedOn = lstMyItems.CreatedOn;
                        lstMyItems2.OnlineQRCode = lstMyItems.OnlineQRCode;
                        lstMyItems2.IsLocked = Visibility.Visible;
                        lstMyItems2.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                        lstMyItems2.FrameBrdr = ((LstMyItems)this.lstImages.SelectedItem).FrameBrdr;
                        lstMyItems2.FilePath = lstMyItems.FilePath;
                        RobotImageLoader.GroupImages.Add(lstMyItems2);
                        if (RobotImageLoader.ViewGroupedImagesCount == null)
                        {
                            RobotImageLoader.ViewGroupedImagesCount = new List<string>();
                        }
                        RobotImageLoader.ViewGroupedImagesCount.Add(lstMyItems2.Name);
                        int expr_21A = arg_706_0 = ((this._currentImage == (string)((System.Windows.Controls.Button)sender).Tag) ? 1 : 0);
                        int expr_220 = arg_706_1 = 0;
                        if (expr_220 == 0)
                        {
                            if (expr_21A != expr_220)
                            {
                                if (8 == 0)
                                {
                                    //  goto IL_A2E;
                                }
                                //this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                                //this.btnImageAddToGroup.ToolTip = "Remove from group";
                                if (-1 == 0)
                                {
                                    //goto IL_83F;
                                }
                            }
                            LstMyItems lstMyItems3 = RobotImageLoader.robotImages.Where(delegate (LstMyItems t)
                            {
                                if (false)
                                {
                                    goto IL_24;
                                }
                                int arg_1A_0 = t.PhotoId;
                                bool expr_1A;
                                do
                                {
                                IL_07:
                                    expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)sender).CommandParameter) ? 1 : 0)) != 0);
                                }
                                while (7 == 0 || 8 == 0);
                                bool flag2 = expr_1A;
                            IL_24:
                                bool expr_43 = (arg_1A_0 = (flag2 ? 1 : 0)) != 0;
                                if (!false)
                                {
                                    return expr_43;
                                }
                                //goto IL_07;
                            }).First<LstMyItems>();
                            if (lstMyItems3 != null)
                            {
                                lstMyItems3.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                            }
                            image.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                            //goto IL_909;
                        }
                        //goto IL_706;
                    }
                }
                else
                {
                    int sname = (int)button.CommandParameter;
                    List<LstMyItems> list2 = (from t in RobotImageLoader.GroupImages
                                              where t.PhotoId == sname
                                              select t).ToList<LstMyItems>();
                    if (list2.Count == 0)
                    {
                        goto IL_67B;
                    }
                    RobotImageLoader.GroupImages.Remove(list2.First<LstMyItems>());
                    if (RobotImageLoader.ViewGroupedImagesCount != null && RobotImageLoader.ViewGroupedImagesCount.Count > 0)
                    {
                        RobotImageLoader.ViewGroupedImagesCount.Remove(list2.First<LstMyItems>().Name);
                    }
                    int arg_3A9_0 = 0;
                    //if (!(this.vwGroup.Text == "View All"))
                    //{
                    //    //arg_778_0 = ((arg_3A9_0 = ((!(this.pagename == "Saveback")) ? 1 : 0)) != 0);
                    //    //if (false)
                    //    //{
                    //    //    //goto IL_778;
                    //    //}
                    //}
                    //else
                    //{
                    //    arg_3A9_0 = 0;
                    //}
                    if (arg_3A9_0 != 0)
                    {
                        LstMyItems lstMyItems = RobotImageLoader.robotImages.Where(delegate (LstMyItems t)
                        {
                            if (false)
                            {
                                goto IL_24;
                            }
                            int arg_1A_0 = t.PhotoId;
                            bool expr_1A;
                            do
                            {
                            IL_07:
                                expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)sender).CommandParameter) ? 1 : 0)) != 0);
                            }
                            while (7 == 0 || 8 == 0);
                            bool flag2 = expr_1A;
                        IL_24:
                            bool expr_43 = (arg_1A_0 = (flag2 ? 1 : 0)) != 0;
                            if (!false)
                            {
                                return expr_43;
                            }
                            //goto IL_07;
                        }).First<LstMyItems>();
                        this.lstImages.SelectedItem = lstMyItems;
                        image.Source = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));

                        ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
                        listBoxItem.Focus();
                        goto IL_67A;
                    }
                    int index = this.NextGroupSelectedIndex(this.lstImages.Items.IndexOf(list2.First<LstMyItems>()));
                    this.lstImages.Items.Remove(list2.First<LstMyItems>());
                    if (this.lstImages.Items.Count == 0)
                    {
                        // this.pagename = "";
                    }
                    if (false)
                    {
                        //goto IL_7A4;
                    }
                    if (this.lstImages.Items.Count > 0)
                    {
                        this.lstImages.Focus();
                        this.lstImages.SelectedItem = this.lstImages.Items[index];
                        ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[index]);
                        listBoxItem.Focus();
                        if (8 != 0)
                        {
                            goto IL_617;
                        }
                        //goto IL_83D;
                    }
                    else
                    {
                        this.continueCalculating = false;
                        this.num = 0;
                        RobotImageLoader.IsZeroSearchNeeded = true;
                        RobotImageLoader.currentCount = 0;
                        RobotImageLoader.RFID = "0";
                        RobotImageLoader.SearchCriteria = "";
                        RobotImageLoader.LoadImages();
                        this.LoadImages();
                        this.IMGFrame.Visibility = Visibility.Collapsed;
                        Grid.SetColumnSpan(this.thumbPreview, 2);
                        Grid.SetColumn(this.thumbPreview, 0);
                        this.thumbPreview.Margin = new Thickness(0.0);
                        //  this.vwGroup.Text = "View Group";
                        this.flgGridWithoutPreview = true;
                        if ((string.Compare(RobotImageLoader.SearchCriteria, "PhotoId", true) == 0 || string.IsNullOrEmpty(RobotImageLoader.SearchCriteria)) && RobotImageLoader.RFID == "0")
                        {
                            //this.btnPrevButton.Visibility = Visibility.Visible;
                            //this.btnNextButton.Visibility = Visibility.Visible;
                            ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
                            goto IL_616;
                        }
                    }
                }
                if (RobotImageLoader.RFID == "")
                {
                    //this.btnPrevButton.Visibility = Visibility.Hidden;
                    //this.btnNextButton.Visibility = Visibility.Hidden;
                    ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
                }
                else
                {
                    //this.btnPrevButton.Visibility = Visibility.Visible;
                    //this.btnNextButton.Visibility = Visibility.Visible;
                    ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
                    //  this.vwGroup.Text = "View Group";
                }
            IL_616:
            IL_617:
            IL_67A:
            IL_67B:
                if (RobotImageLoader.robotImages == null || RobotImageLoader.robotImages.Count <= 0)
                {
                    //goto IL_908;
                }

                //if (this.vwGroup.Text == "View Group")
                //{
                //    //	this.SetMessageText("Grouped");
                //    this.SetMessageText("");
                //}
                //else
                //{
                //    this.SetMessageText("PrintGrouped");
                //}
                //if (this.pagename == "Saveback" && RobotImageLoader.PrintImages.Count > 0 && this.SPSelectAll.Visibility == Visibility.Hidden)
                //{
                //    //this.SetMessageText("EditPrintGrouped");
                //    //this.SPSelectAll.Visibility = Visibility.Hidden;
                //}
                //else
                //{
                //	this.SPSelectAll.Visibility = Visibility.Visible;
                //}
                if (this.lstImages.Items.Count > 0 && this.lstImages.SelectedIndex == -1)
                {
                    this.lstImages.SelectedIndex = 0;
                    ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[0]);
                    listBoxItem.Focus();
                    this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
                }
                // IL_A2E:
                //if (this.vwGroup.Text == "View All")
                //{
                //    this.CheckForAllImgSelectToPrint();
                //}
                //else
                //{
                //    this.FillImageList();
                //    this.CheckSelectAllGroup();
                //}
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            finally
            {
                while (7 == 0)
                {
                }
            }
        }


        private int NextGroupSelectedIndex(int currentIndex)
        {
            int arg_40_0;
            int num;
            int arg_47_0;
            int expr_33;
            while (true)
            {
            IL_00:
                int arg_02_0 = -1;
                int num2 = 0;
                bool expr_1A;
                do
                {
                    int expr_02 = arg_40_0 = arg_02_0;
                    if (expr_02 == 0)
                    {
                        goto IL_3F;
                    }
                    num = expr_02;
                    num2 = this.lstImages.Items.Count;
                    expr_1A = ((arg_02_0 = ((num2 <= 0) ? 1 : 0)) != 0);
                }
                while (7 == 0);
                bool flag = expr_1A;
                bool arg_26_0;
                arg_47_0 = ((arg_26_0 = flag) ? 1 : 0);
                while (5 != 0)
                {
                    if (arg_26_0)
                    {
                        goto IL_42;
                    }
                    if (8 == 0)
                    {
                        goto IL_00;
                    }
                    if (num2 > currentIndex + 1)
                    {
                        goto IL_3E;
                    }
                    expr_33 = ((arg_26_0 = ((arg_47_0 = currentIndex) != 0)) ? 1 : 0);
                    if (8 != 0)
                    {
                        goto Block_6;
                    }
                }
                return arg_47_0;
            }
        Block_6:
            arg_40_0 = (currentIndex = expr_33 - 1);
            goto IL_3F;
        IL_3E:
            arg_40_0 = currentIndex;
        IL_3F:
            num = arg_40_0;
        IL_42:
            int num3 = num;
            arg_47_0 = num3;
            return arg_47_0;
        }

        private void CheckForAllImgSelectToPrint()
        {
            int num = (from p in RobotImageLoader.PrintImages
                       join g in RobotImageLoader.GroupImages on p.PhotoId equals g.PhotoId
                       select p.PhotoId).Count<int>();
            if (RobotImageLoader.PrintImages.Count <= 0)
            {
                goto IL_AD;
            }
            int arg_8F_0;
            int arg_A3_0 = arg_8F_0 = RobotImageLoader.GroupImages.Count;
            int arg_8C_0 = 0;
            int expr_A3;
            int expr_A6;
            do
            {
                int arg_A3_1;
                int expr_8C = arg_A3_1 = arg_8C_0;
                if (expr_8C == 0)
                {
                    if (arg_8F_0 <= expr_8C)
                    {
                        goto IL_AD;
                    }
                    if (false)
                    {
                        // goto IL_B8;
                    }
                    arg_A3_0 = num;
                    arg_A3_1 = RobotImageLoader.GroupImages.Count;
                }
                expr_A3 = (arg_8F_0 = (arg_A3_0 = ((arg_A3_0 == arg_A3_1) ? 1 : 0)));
                expr_A6 = (arg_8C_0 = 0);
            }
            while (expr_A6 != 0);
            int arg_120_0 = (expr_A3 == expr_A6) ? 1 : 0;
            bool expr_126;
            do
            {
            IL_AE:
                bool flag = arg_120_0 != 0;
                expr_126 = ((arg_120_0 = (flag ? 1 : 0)) != 0);
            }
            while (6 == 0);
            if (!expr_126)
            {
                // goto IL_B8;
            }

            return;
        IL_AD:
            arg_120_0 = 1;
            //goto IL_AE;

        }

        private void FillImageList()
        {
            RobotImageLoader.ViewGroupedImagesCount = new List<string>();
            List<LstMyItems>.Enumerator enumerator = RobotImageLoader.robotImages.GetEnumerator();
            //goto IL_1B;
            try
            {
                while (true)
                {
                IL_1B:
                    if (4 != 0)
                    {
                        if (!false)
                        {
                            goto IL_5E;
                        }
                        goto IL_5E;
                    }
                    LstMyItems current;
                    bool flag;
                    do
                    {
                    IL_2A:
                        flag = !(current.BmpImageGroup.UriSource.ToString() == "/images/view-accept.png");
                    }
                    while (false);
                    if (5 == 0)
                    {
                        continue;
                    }
                    if (!flag)
                    {
                        RobotImageLoader.ViewGroupedImagesCount.Add(current.Name);
                    }
                    if (!false)
                    {
                        goto IL_5E;
                    }
                IL_23:
                    current = enumerator.Current;
                //goto IL_2A;
                IL_5E:
                    if (!enumerator.MoveNext())
                    {
                        break;
                    }
                    goto IL_23;
                }
            }
            finally
            {
                ((IDisposable)enumerator).Dispose();
            }
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            //SearchResult.c__DisplayClass2d expr_7C1 = new SearchResult.c__DisplayClass2d();
            //SearchResult.c__DisplayClass2d  c__DisplayClass2d;
            System.Windows.Controls.Button btn = new System.Windows.Controls.Button();
            //if (4 != 0)
            //{
            //     c__DisplayClass2d = expr_7C1;
            //}
            btn = (System.Windows.Controls.Button)sender;
            try
            {
                System.Windows.Controls.Button button = (System.Windows.Controls.Button)sender;
                System.Windows.Controls.Image image = (System.Windows.Controls.Image)button.Content;
                //if (this.vwGroup.Text == "View Group" && this.pagename != "Saveback")
                //{
                //RobotImageLoader.curItem = RobotImageLoader.robotImages.Where(delegate (LstMyItems t)
                //{
                //    if (false)
                //    {
                //        goto IL_24;
                //    }
                //    int arg_1A_0 = t.PhotoId;
                //    bool expr_1A;
                //    do
                //    {
                //    IL_07:
                //        expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)sender).CommandParameter) ? 1 : 0)) != 0);
                //    }
                //    while (7 == 0 || 8 == 0);
                //    bool flag = expr_1A;
                //IL_24:
                //    bool expr_43 = (arg_1A_0 = (flag ? 1 : 0)) != 0;
                //    if (!false)
                //    {
                //        return expr_43;
                //    }
                //    //goto IL_07;
                //}).First<LstMyItems>();
                //}
                //else
                //{
                RobotImageLoader.curItem = RobotImageLoader.GroupImages.Where(delegate (LstMyItems t)
                {
                    if (false)
                    {
                        goto IL_24;
                    }
                    int arg_1A_0 = t.PhotoId;
                    bool expr_1A;
                    do
                    {
                    IL_07:
                        expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)sender).CommandParameter) ? 1 : 0)) != 0);
                    }
                    while (7 == 0 || 8 == 0);
                    bool flag = expr_1A;
                IL_24:
                    bool expr_43 = (arg_1A_0 = (flag ? 1 : 0)) != 0;
                    if (!false)
                    {
                        return expr_43;
                    }
                    // goto IL_07;
                }).First<LstMyItems>();
                //}
                LstMyItems lstMyItems = RobotImageLoader.PrintImages.Where(delegate (LstMyItems t)
                {
                    if (false)
                    {
                        goto IL_24;
                    }
                    int arg_1A_0 = t.PhotoId;
                    bool expr_1A = false;
                    do
                    {
                    IL_07:
                        expr_1A = ((arg_1A_0 = ((arg_1A_0 == (int)((System.Windows.Controls.Button)sender).CommandParameter) ? 1 : 0)) != 0);
                    }
                    while (7 == 0 || 8 == 0);
                    bool flag = expr_1A;
                IL_24:
                    bool expr_43 = (arg_1A_0 = (flag ? 1 : 0)) != 0;
                    if (!false)
                    {
                        return expr_43;
                    }
                    // goto IL_07;
                }).FirstOrDefault<LstMyItems>();
                int num = 0;
                if (lstMyItems == null)
                {
                    LstMyItems lstMyItems2 = new LstMyItems();
                    lstMyItems2 = RobotImageLoader.curItem;
                    lstMyItems2.Name = (string)((System.Windows.Controls.Button)sender).Tag;
                    lstMyItems2.PhotoId = RobotImageLoader.curItem.PhotoId;
                    lstMyItems2.MediaType = RobotImageLoader.curItem.MediaType;
                    lstMyItems2.VideoLength = RobotImageLoader.curItem.VideoLength;
                    lstMyItems2.FileName = RobotImageLoader.curItem.FileName;
                    lstMyItems2.CreatedOn = RobotImageLoader.curItem.CreatedOn;
                    lstMyItems2.OnlineQRCode = RobotImageLoader.curItem.OnlineQRCode;
                    lstMyItems2.FilePath = RobotImageLoader.curItem.FilePath;
                    RobotImageLoader.PrintImages.Add(lstMyItems2);
                    image.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                    RobotImageLoader.curItem.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                    // this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                }
                else
                {
                    //  num = this.NextGroupSelectedIndex(this.lstImages.Items.IndexOf(lstMyItems));
                    RobotImageLoader.PrintImages.Remove(lstMyItems);
                    image.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                    RobotImageLoader.curItem.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                    //  this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                    if (this.lstImages.Items.Count == 0)
                    {
                        //  this.pagename = "";
                    }
                    if (this.lstImages.Items.Count > 0)
                    {
                        if (num < 0)
                        {
                            num = 0;
                        }
                        this.lstImages.SelectedItem = this.lstImages.Items[num];
                        ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[num]);
                        listBoxItem.Focus();
                    }
                    else
                    {
                        //  this.continueCalculating = false;
                        //   this.num = 0;
                        RobotImageLoader.currentCount = 0;
                        RobotImageLoader.IsZeroSearchNeeded = true;
                        RobotImageLoader.RFID = "0";
                        RobotImageLoader.LoadImages();
                        //  this.LoadImages();
                        this.IMGFrame.Visibility = Visibility.Collapsed;
                        Grid.SetColumnSpan(this.thumbPreview, 2);
                        Grid.SetColumn(this.thumbPreview, 0);
                        this.thumbPreview.Margin = new Thickness(0.0);
                        //this.vwGroup.Text = "View Group";
                        //this.flgGridWithoutPreview = true;
                        //this.btnPrevButton.Visibility = Visibility.Visible;
                        //this.btnNextButton.Visibility = Visibility.Visible;
                        ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Hidden);
                    }
                }
                this.lstImages.SelectedItem = RobotImageLoader.curItem;
                //if (this.vwGroup.Text == "View All")
                //{
                //    this.CheckForAllImgSelectToPrint();
                //}
                //if (this.vwGroup.Text == "View Group")
                //{
                //    //  this.SetMessageText("Grouped");
                //    this.SetMessageText("");
                //}
                //else
                //{
                //    this.SetMessageText("PrintGrouped");
                //}
                //if (this.vwGroup.Text == "View Group" && this.pagename == "Saveback")
                //{
                using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.GroupImages.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        LstMyItems itx = enumerator.Current;
                        LstMyItems lstMyItems3 = (from xs in RobotImageLoader.PrintImages
                                                  where xs.PhotoId == itx.PhotoId
                                                  select xs).FirstOrDefault<LstMyItems>();
                        if (lstMyItems3 == null)
                        {
                            RobotImageLoader.NotPrintedImages.Add(itx);
                        }
                    }
                }
                if (RobotImageLoader.NotPrintedImages.Count != 0)
                {
                    using (List<LstMyItems>.Enumerator enumerator = RobotImageLoader.NotPrintedImages.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            LstMyItems ity = enumerator.Current;
                            this.lstImages.Items.Remove(ity);
                            LstMyItems lstMyItems4 = (from tg in RobotImageLoader.GroupImages
                                                      where tg.PhotoId == ity.PhotoId
                                                      select tg).FirstOrDefault<LstMyItems>();
                            lstMyItems4.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        }
                    }
                }
                //    this.SetMessageText("EditPrintGrouped");
                //    this.SPSelectAll.Visibility = Visibility.Hidden;
                //}
                //else
                //{
                //    this.SPSelectAll.Visibility = Visibility.Visible;
                //}
                if (this.lstImages.Items.Count == 0)
                {
                    this.IMGFrame.Visibility = Visibility.Collapsed;
                    Grid.SetColumnSpan(this.thumbPreview, 2);
                    Grid.SetColumn(this.thumbPreview, 0);
                    this.thumbPreview.Margin = new Thickness(0.0);
                    //this.pagename = "";
                    ////   this.SPSelectAll.Visibility = Visibility.Visible;
                    //this.vwGroup.Text = "View Group";
                    //this.ViewGroup();
                }
                else
                {
                    ListBoxItem listBoxItem2 = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
                    if (listBoxItem2 != null)
                    {
                        listBoxItem2.Focus();
                    }
                    else if (this.lstImages.Items.Count > 0 && this.lstImages.SelectedIndex == -1)
                    {
                        this.lstImages.SelectedIndex = num;
                        ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[num]);
                        listBoxItem.Focus();
                        this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
                    }
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


        private void MediaStop()
        {
            bool arg_4D_0;
            bool flag;
            while (true)
            {
                bool expr_09 = arg_4D_0 = false;//(this.mplayer == null);
                if (false)
                {
                    goto IL_4D;
                }
                if (expr_09)
                {
                    goto IL_33;
                }
            IL_15:
                while (!false)
                {
                    //MLMediaPlayer expr_1A = this.mplayer;
                    if (true)
                    {
                        //expr_1A.MediaStop();
                    }
                    //this.mplayer = null;
                    if (7 == 0)
                    {
                        //goto IL_4F;
                    }
                    if (!false)
                    {
                        goto IL_33;
                    }
                }
                continue;
            IL_33:
                //this.gdMediaPlayer.Children.Clear();
                flag = false; //(this.clientWin == null);
                if (!false)
                {
                    break;
                }
                goto IL_15;
            }
            arg_4D_0 = flag;
        IL_4D:
            if (arg_4D_0)
            {
                return;
            }
            //IL_4F:
            //  if(this.clientWin!=null)
            //  this.clientWin.StopMediaPlay();
        }

        private void lstImages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Func<LstMyItems, bool> expr_06 = null;
            if (3 != 0)
            {
                Func<LstMyItems, bool> predicate = expr_06;
            }
            try
            {
                this.MediaStop();
                if (this.clientWin == null)
                {
                    foreach (Window window in System.Windows.Application.Current.Windows)
                    {
                        if (window.Title == "ClientView")
                        {
                            this.clientWin = (ClientView)window;
                            break;
                        }
                    }
                }
                if (this.lstImages.Items.Count > 0 && this.lstImages.SelectedItem != null)
                {
                    LstMyItems lstMyItems = null;
                    IEnumerable<string> source;
                    PhotoBusiness photoBusiness;
                    int arg_9C0_0;
                    int arg_9C0_1;
                    if (this.IMGFrame.Visibility != Visibility.Visible)
                    {
                        lstMyItems = (LstMyItems)this.lstImages.SelectedItem;
                        int Photo_PKey = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
                        source = from x in RobotImageLoader.LstUnlocknames
                                 where x.Equals(Photo_PKey.ToString())
                                 select x;
                        photoBusiness = new PhotoBusiness();
                        bool flag = !photoBusiness.GetModeratePhotos((long)Photo_PKey) || source.Count<string>() != 0;
                        if (2 != 0)
                        {
                            if (!flag)
                            {
                                //this.btnEdit.IsEnabled = false;
                                //this.splockedImages.Visibility = Visibility.Visible;
                                ////this.spaddtoalbumnunlockedImages.Visibility = Visibility.Collapsed;
                                //this.spunlockedImages.Visibility = Visibility.Collapsed;
                                this.mainFrame.Source = null;
                                this.imgmain.Source = new BitmapImage(new Uri(LoginUser.DigiFolderPath + "/Locked.png"));
                                goto IL_8AB;
                            }
                            //this.splockedImages.Visibility = Visibility.Collapsed;
                            ////this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
                            //this.spunlockedImages.Visibility = Visibility.Visible;
                            //this.btnEdit.IsEnabled = true;
                            if (lstMyItems.MediaType != 1)
                            {
                                goto IL_931;
                            }
                        }

                        selectImageForFB = lstMyItems.BigThumbnailPath;
                        listImageForFB.Add(selectImageForFB);
                        this.unlockImage = CommonUtility.GetImageFromPath(lstMyItems.BigThumbnailPath);   //////
                    IL_931:
                        this.imgmain.Source = this.unlockImage;
                        if (((LstMyItems)this.lstImages.SelectedItem).FrameBrdr != null)
                        {
                            try
                            {
                                this.mainFrame.Source = new BitmapImage(new Uri(((LstMyItems)this.lstImages.SelectedItem).FrameBrdr));
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            this.mainFrame.Source = null;
                        }
                        arg_9C0_0 = ((((LstMyItems)this.lstImages.SelectedItem).MediaType == 1) ? 1 : 0);
                        arg_9C0_1 = 0;
                        goto IL_9C0;
                    }
                    if (!RobotImageLoader.Is9ImgViewActive)
                    {
                        foreach (LstMyItems lstMyItems2 in ((IEnumerable)this.lstImages.Items))
                        {
                            lstMyItems2.GridMainHeight = 140;
                            lstMyItems2.GridMainWidth = 170;
                            lstMyItems2.GridMainRowHeight1 = 90;
                            lstMyItems2.GridMainRowHeight2 = 60;
                        }
                    }

                    this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
                    this.txtMainImage.Text = ((LstMyItems)this.lstImages.SelectedItem).Name;
                    RobotImageLoader.PhotoId = ((LstMyItems)this.lstImages.SelectedItem).Name;
                    RobotImageLoader.UniquePhotoId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
                    LstMyItems lstMyItems3 = (LstMyItems)this.lstImages.SelectedItem;
                    this._currentImage = ((LstMyItems)this.lstImages.SelectedItem).Name;
                    this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
                    LstMyItems lstMyItems4 = (from t in RobotImageLoader.GroupImages
                                              where t.PhotoId == this._currentImageId
                                              select t).FirstOrDefault<LstMyItems>();


                    IEnumerable<LstMyItems> arg_312_0 = RobotImageLoader.PrintImages;
                    Func<LstMyItems, bool> predicate = (LstMyItems t) => t.PhotoId == this._currentImageId;
                    LstMyItems lstMyItems5 = arg_312_0.Where(predicate).FirstOrDefault<LstMyItems>();
                    if (lstMyItems5 != null)
                    {
                        // this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                        if (this.isSingleScreenPreview)
                        {
                            //this.clientWin.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                        }
                    }
                    else
                    {
                        //  this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        if (this.isSingleScreenPreview)
                        {
                            //	this.clientWin.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        }
                    }
                    int currentImageId = this._currentImageId;
                    this.unlockImageId = (long)currentImageId;
                    LstMyItems myItems = (LstMyItems)this.lstImages.SelectedItem;
                IL_3EF:
                    source = RobotImageLoader.LstUnlocknames.Where(delegate (string x)
                    {
                        if (false)
                        {
                            goto IL_20;
                        }
                        bool arg_27_0;
                        bool arg_46_0 = arg_27_0 = x.Equals(myItems.PhotoId.ToString());
                    IL_16:
                        if (7 == 0 || 8 == 0)
                        {
                            goto IL_24;
                        }
                        bool flag2;
                        if (!false)
                        {
                            flag2 = arg_46_0;
                        }
                    IL_20:
                        arg_46_0 = (arg_27_0 = flag2);
                    IL_24:
                        if (!false)
                        {
                            return arg_27_0;
                        }
                        goto IL_16;
                    });
                IL_408:
                    photoBusiness = new PhotoBusiness();
                    int arg_613_0;
                    int arg_613_1;
                    if (photoBusiness.GetModeratePhotos((long)currentImageId) && source.Count<string>() == 0)
                    {
                        //this.btnEdit.IsEnabled = false;
                        //this.splockedImages.Visibility = Visibility.Visible;
                        ////this.spaddtoalbumnunlockedImages.Visibility = Visibility.Collapsed;
                        //this.spunlockedImages.Visibility = Visibility.Collapsed;
                        this.mainFrame.Source = null;
                        this.imgmain.Source = new BitmapImage(new Uri(LoginUser.DigiFolderPath + "/Locked.png"));
                        this.CurrentBitmapImage = new BitmapImage(new Uri(LoginUser.DigiFolderPath + "/Locked.png"));
                    }
                    else
                    {
                        bool flag;
                        do
                        {
                            //this.splockedImages.Visibility = Visibility.Collapsed;
                            ////this.spaddtoalbumnunlockedImages.Visibility = Visibility.Visible;
                            //this.spunlockedImages.Visibility = Visibility.Visible;
                            //this.btnEdit.IsEnabled = true;
                            int expr_4FE = arg_613_0 = myItems.MediaType;
                            int expr_504 = arg_613_1 = 1;
                            if (expr_504 == 0)
                            {
                                //goto IL_613;
                            }
                            flag = (expr_4FE != expr_504);
                        }
                        while (false);
                        if (!flag)
                        {
                            this.CurrentBitmapImage = CommonUtility.GetImageFromPath(myItems.BigThumbnailPath);
                            this.imgmain.Source = this.CurrentBitmapImage;
                            //this.picoriginal.Width = this.Width / 2;
                            //this.picoriginal.Height = this.Height / 2 + 130;

                        }
                        if (((LstMyItems)this.lstImages.SelectedItem).FrameBrdr != null)
                        {
                            this.mainFrame.Source = new BitmapImage(new Uri(((LstMyItems)this.lstImages.SelectedItem).FrameBrdr));
                        }
                        else
                        {
                            this.mainFrame.Source = null;

                        }
                    }
                IL_58C:
                    bool arg_5BC_0;
                    if (lstMyItems3.MediaType != 2)
                    {
                        int expr_5A7 = arg_9C0_0 = lstMyItems3.MediaType;
                        int expr_5AD = arg_9C0_1 = 3;
                        if (expr_5AD == 0)
                        {
                            goto IL_9C0;
                        }
                        arg_5BC_0 = (expr_5A7 != expr_5AD);
                    }
                    else
                    {
                        arg_5BC_0 = false;
                    }
                    if (arg_5BC_0)
                    {
                        // this.btnEdit.IsEnabled = true;
                        this.img.Visibility = Visibility.Visible;
                        //this.vidoriginal.Visibility = Visibility.Hidden;
                        goto IL_735;
                    }
                    // this.btnEdit.IsEnabled = false;
                    this.img.Visibility = Visibility.Hidden;
                    //this.vidoriginal.Visibility = Visibility.Visible;
                    if (false)
                    {
                        goto IL_3EF;
                    }
                    string fileName = lstMyItems3.FileName;
                    if (string.IsNullOrEmpty(fileName))
                    {
                        goto IL_709;
                    }
                    arg_613_0 = lstMyItems3.MediaType;
                    arg_613_1 = 2;

                    base.Dispatcher.Invoke(new Action(delegate
                    {
                        this.MediaPlay();
                    }), new object[0]);
                //this.txtMainVideo.Text = lstMyItems3.Name;
                IL_709:
                IL_735:
                    //   bool? isChecked = this.btnchkpreview.IsChecked;
                    int arg_75D_0 = 0;

                    if (arg_75D_0 != 0)
                    {
                        if (!false)
                        {
                            AuditLog.AddUserLog(LoginUser.UserId, 1, "Show Preview of " + ((LstMyItems)this.lstImages.SelectedItem).Name.ToString() + " image.", ((LstMyItems)this.lstImages.SelectedItem).PhotoId);
                        }
                    }
                    goto IL_A1A;
                IL_8AB:
                    this.CurrentBitmapImage = new BitmapImage(new Uri(LoginUser.DigiFolderPath + "/Locked.png"));
                    if (2 != 0)
                    {
                        goto IL_9DC;
                    }
                    goto IL_58C;
                IL_9C0:
                    if (arg_9C0_0 != arg_9C0_1)
                    {
                        this.CurrentBitmapImage = CommonUtility.GetImageFromPath(lstMyItems.BigThumbnailPath);
                    }
                IL_9DC:
                    if (lstMyItems.MediaType == 2 || lstMyItems.MediaType == 3)
                    {
                        //  this.btnEdit.IsEnabled = false;
                    }
                    else
                    {
                        // this.btnEdit.IsEnabled = true;
                    }
                IL_A1A:;
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


        private void MediaPlay()
        {
            if (false || -1 == 0)
            {
                goto IL_13;
            }
        IL_07:
            bool flag = false; //this.mplayer == null;
        IL_13:
            if (6 == 0)
            {
                goto IL_07;
            }
            if (!flag)
            {
                this.MediaStop();
            }
        IL_20:

            if (!false)
            {
                //this.gdMediaPlayer.EndInit();
                return;
            }
            goto IL_20;
        }


        private void MainImage_Click(object sender, RoutedEventArgs e)
        {

            // this.MediaStop();
            Grid.SetColumnSpan(this.thumbPreview, 1);
            Grid.SetColumn(this.thumbPreview, 1);
            this.thumbPreview.Margin = new Thickness(0.0, 0.0, -77.5, 8.0);
            ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
            // this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1_active.png", UriKind.Relative));
            //this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/16blocks_black.png", UriKind.Relative));
            //   this.imgwithoutPreview9.Source = new BitmapImage(new Uri("/images/9Blocks_black.png", UriKind.Relative));
            try
            {
                this.IMGFrame.Visibility = Visibility.Visible;
                LstMyItems lstMyItems;
                LstMyItems lstMyItems2;
                int photoId;
                LstMyItems curItem;
                 if (!(this.pagename != "Saveback")) //!(this.vwGroup.Text == "View Group") || 
                {
                    string strPath = ((System.Windows.Controls.Button)sender).Tag.ToString();

                    curItem = RobotImageLoader.GroupImages.Where(t => t.FilePath == strPath).FirstOrDefault<LstMyItems>();

                    if (curItem == null)return;

                    if (curItem.MediaType != 1)
                    {
                        if (curItem.MediaType == 2)
                        {
                            if (!false)
                            {
                                //using (FileStream fileStream = File.OpenRead(Path.Combine(curItem.HotFolderPath, "Videos", curItem.CreatedOn.ToString("yyyyMMdd"), curItem.FileName)))
                                //{
                                //  //  SearchResult.vsMediaFileName = fileStream.Name;
                                //}
                            }
                        }
                        else
                        {
                            //using (FileStream fileStream = File.OpenRead(Path.Combine(curItem.HotFolderPath, "ProcessedVideos", curItem.CreatedOn.ToString("yyyyMMdd"), curItem.FileName)))
                            //{
                            //   // SearchResult.vsMediaFileName = fileStream.Name;
                            //}
                        }
                        // this.MediaPlay();
                    }
                    if (this.lstImages.SelectedItem != curItem)
                    {
                        this.lstImages.SelectedItem = curItem;
                        ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
                        listBoxItem.Focus();
                        RobotImageLoader.UniquePhotoId = curItem.PhotoId;
                        RobotImageLoader.PhotoId = curItem.Name.ToString();
                    }
                    else
                    {
                        this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
                        this.txtMainImage.Text = ((LstMyItems)this.lstImages.SelectedItem).Name;
                        this._currentImage = ((LstMyItems)this.lstImages.SelectedItem).Name;
                        this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
                        lstMyItems = (from t in RobotImageLoader.GroupImages
                                      where t.PhotoId == this._currentImageId
                                      select t).FirstOrDefault<LstMyItems>();
                        //if (lstMyItems != null)
                        //{
                        //    this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                        //    this.btnImageAddToGroup.ToolTip = "Remove from group";
                        //}
                        //else
                        //{
                        //    this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-GROUP.png", UriKind.Relative));
                        //    this.btnImageAddToGroup.ToolTip = "Add to group";
                        //}
                        lstMyItems2 = (from t in RobotImageLoader.PrintImages
                                       where t.PhotoId == curItem.PhotoId
                                       select t).FirstOrDefault<LstMyItems>();
                        if (lstMyItems2 != null)
                        {
                            if (false)
                            {
                                goto IL_6A8;
                            }
                            // this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                        }
                        else
                        {
                            // this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        }
                        photoId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
                        // this.unlockImageId = (long)photoId;
                    }
                    goto IL_A3E;

                }
                //SearchResult.c__DisplayClass41 CS$<>8__locals42;

                while (true)
                {
                    int _PhotoId = Convert.ToInt32(((System.Windows.Controls.Button)sender).CommandParameter);
                    curItem = RobotImageLoader.robotImages.Where(t => t.PhotoId == _PhotoId).FirstOrDefault<LstMyItems>();
                    //currentBarCodePath = curItem.HotFolderPath;
                    //currentPhotoName = curItem.FileName;
                    if (curItem != null)
                    {
                        if (curItem.MediaType != 2 && curItem.MediaType != 3)
                        {
                            goto IL_303;
                        }
                        if (-1 == 0)
                        {
                            goto IL_303;
                        }
                        // this.btnEdit.IsEnabled = false;
                        this.img.Visibility = Visibility.Hidden;
                        //this.vidoriginal.Visibility = Visibility.Visible;
                        string fileName = curItem.FileName;
                        if (!string.IsNullOrEmpty(fileName))
                        {
                            if (curItem.MediaType == 2)
                            {
                                //using (FileStream fileStream = File.OpenRead(Path.Combine(curItem.HotFolderPath, "Videos", curItem.CreatedOn.ToString("yyyyMMdd"), fileName)))
                                //{
                                //   // SearchResult.vsMediaFileName = fileStream.Name;
                                //}
                            }
                            else
                            {
                                //using (FileStream fileStream = File.OpenRead(Path.Combine(curItem.HotFolderPath, "ProcessedVideos", curItem.CreatedOn.ToString("yyyyMMdd"), fileName)))
                                //{
                                // //   SearchResult.vsMediaFileName = fileStream.Name;
                                //}
                            }
                        }
                    //  this.MediaPlay();
                    //this.txtMainVideo.Text = curItem.Name;
                    IL_332:
                        if (this.lstImages.SelectedItem != curItem)
                        {
                            if (curItem != null)
                            {
                                this.lstImages.SelectedItem = curItem;
                                RobotImageLoader.PhotoId = curItem.Name;
                                ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
                                listBoxItem.Focus();
                                this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
                            }
                        }
                        if (this.lstImages.SelectedItem != null)
                        {
                            if (false)
                            {
                                goto IL_669;
                            }
                            this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
                            this.txtMainImage.Text = ((LstMyItems)this.lstImages.SelectedItem).Name;
                        }
                        lstMyItems = (from t in RobotImageLoader.GroupImages
                                      where t.PhotoId == curItem.PhotoId
                                      select t).FirstOrDefault<LstMyItems>();
                        if (lstMyItems != null)
                        {
                            //this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                            //this.btnImageAddToGroup.ToolTip = "Remove from group";
                        }
                        else
                        {
                            //this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-GROUP.png", UriKind.Relative));
                            //this.btnImageAddToGroup.ToolTip = "Add to group";
                        }
                        lstMyItems2 = (from t in RobotImageLoader.PrintImages
                                       where t.PhotoId == curItem.PhotoId
                                       select t).FirstOrDefault<LstMyItems>();
                        if (lstMyItems2 == null)
                        {
                            goto IL_510;
                        }
                        if (false)
                        {
                            break;
                        }
                        // this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                        if (2 != 0)
                        {
                            break;
                        }
                        continue;
                    IL_303:
                        // this.btnEdit.IsEnabled = true;
                        this.img.Visibility = Visibility.Visible;
                        //this.vidoriginal.Visibility = Visibility.Hidden;
                        // this.MediaStop();
                        goto IL_332;
                    }
                    goto IL_534;
                }
                goto IL_52E;
            IL_510:
            //this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
            //  this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
            IL_52E:
                goto IL_6CA;
            IL_534:
                this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
                this.txtMainImage.Text = ((LstMyItems)this.lstImages.SelectedItem).Name;
                this._currentImage = ((LstMyItems)this.lstImages.SelectedItem).Name;
                this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
                lstMyItems = (from t in RobotImageLoader.GroupImages
                              where t.PhotoId == this._currentImageId
                              select t).FirstOrDefault<LstMyItems>();
                if (lstMyItems != null)
                {
                    //this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                    //this.btnImageAddToGroup.ToolTip = "Remove from group";
                }
                else
                {
                    //this.ImgAddToGroup.Source = new BitmapImage(new Uri("/images/view-GROUP.png", UriKind.Relative));
                    //this.btnImageAddToGroup.ToolTip = "Add to group";
                }
                lstMyItems2 = (from t in RobotImageLoader.PrintImages
                               where t.PhotoId == curItem.PhotoId
                               select t).FirstOrDefault<LstMyItems>();
                if (lstMyItems2 == null)
                {
                    //this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                    //this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                    goto IL_6A8;
                }
            IL_669:
            // this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
            IL_6A8:
                photoId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
            // this.unlockImageId = (long)photoId;
            IL_6CA:
            IL_A3E:
                if (this.lstImages.Items.Count > 0 && this.lstImages.SelectedIndex == -1)
                {
                    this.lstImages.SelectedIndex = 0;
                    ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[0]);
                    this.lstImages.SelectedItem = listBoxItem;
                    this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
                    listBoxItem.Focus();
                }
                //  this.flgGridWithoutPreview = false;
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

        public async Task SelectClientView(int ID)
        {            
            Grid.SetColumnSpan(this.thumbPreview, 1);
            Grid.SetColumn(this.thumbPreview, 1);
            this.thumbPreview.Margin = new Thickness(0.0, 0.0, -77.5, 8.0);
            ScrollViewer.SetVerticalScrollBarVisibility(this.lstImages, ScrollBarVisibility.Visible);
            
            try
            {
                this.IMGFrame.Visibility = Visibility.Visible;
                LstMyItems lstMyItems;
                LstMyItems lstMyItems2;
                int photoId;
                LstMyItems curItem;
                if (!(this.pagename != "Saveback")) 
                {                    
                    string strPath = "";
                    curItem = RobotImageLoader.GroupImages.Where(t => t.FilePath == strPath).FirstOrDefault<LstMyItems>();

                    if (curItem == null) return;

                    if (this.lstImages.SelectedItem != curItem)
                    {
                        this.lstImages.SelectedItem = curItem;
                        ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
                        listBoxItem.Focus();
                        RobotImageLoader.UniquePhotoId = curItem.PhotoId;
                        RobotImageLoader.PhotoId = curItem.Name.ToString();
                    }
                    else
                    {
                        this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
                        this.txtMainImage.Text = ((LstMyItems)this.lstImages.SelectedItem).Name;
                        this._currentImage = ((LstMyItems)this.lstImages.SelectedItem).Name;
                        this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;

                        lstMyItems = (from t in RobotImageLoader.GroupImages
                                      where t.PhotoId == this._currentImageId
                                      select t).FirstOrDefault<LstMyItems>();
                       
                        lstMyItems2 = (from t in RobotImageLoader.PrintImages
                                       where t.PhotoId == curItem.PhotoId
                                       select t).FirstOrDefault<LstMyItems>();

                        if (lstMyItems2 != null)
                        {
                            if (false)
                            {
                                goto IL_6A8;
                            }
                           
                        }                      
                        photoId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
                        
                    }
                    goto IL_A3E;

                }
               

                while (true)
                {                    
                    int _PhotoId = ID;
                    curItem = RobotImageLoader.robotImages.Where(t => t.PhotoId == _PhotoId).FirstOrDefault<LstMyItems>();

                    if (curItem != null)
                    {
                        if (curItem.MediaType != 2 && curItem.MediaType != 3)
                        {
                            goto IL_303;
                        }
                        if (-1 == 0)
                        {
                            goto IL_303;
                        }
                        
                        this.img.Visibility = Visibility.Hidden;                        
                        string fileName = curItem.FileName;
                        if (!string.IsNullOrEmpty(fileName))
                        {
                            
                        }
                    
                    IL_332:
                        if (this.lstImages.SelectedItem != curItem)
                        {
                            if (curItem != null)
                            {
                                this.lstImages.SelectedItem = curItem;
                                RobotImageLoader.PhotoId = curItem.Name;
                                ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
                                listBoxItem.Focus();
                                this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
                            }
                        }
                        if (this.lstImages.SelectedItem != null)
                        {
                            if (false)
                            {
                                goto IL_669;
                            }
                            this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
                            this.txtMainImage.Text = ((LstMyItems)this.lstImages.SelectedItem).Name;
                        }
                        lstMyItems = (from t in RobotImageLoader.GroupImages
                                      where t.PhotoId == curItem.PhotoId
                                      select t).FirstOrDefault<LstMyItems>();
                        
                        lstMyItems2 = (from t in RobotImageLoader.PrintImages
                                       where t.PhotoId == curItem.PhotoId
                                       select t).FirstOrDefault<LstMyItems>();

                        if (lstMyItems2 == null)
                        {
                            goto IL_510;
                        }
                        if (false)
                        {
                            break;
                        }
                        
                        if (2 != 0)
                        {
                            break;
                        }
                        continue;
                    IL_303:
                        
                        this.img.Visibility = Visibility.Visible;
                        
                        goto IL_332;
                    }
                    goto IL_534;
                }
                goto IL_52E;
            IL_510:
            
            IL_52E:
                goto IL_6CA;
            IL_534:

                this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
                this.txtMainImage.Text = ((LstMyItems)this.lstImages.SelectedItem).Name;
                this._currentImage = ((LstMyItems)this.lstImages.SelectedItem).Name;
                this._currentImageId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;

                lstMyItems = (from t in RobotImageLoader.GroupImages
                              where t.PhotoId == this._currentImageId
                              select t).FirstOrDefault<LstMyItems>();
                
                lstMyItems2 = (from t in RobotImageLoader.PrintImages
                               where t.PhotoId == curItem.PhotoId
                               select t).FirstOrDefault<LstMyItems>();
                if (lstMyItems2 == null)
                {
                    
                    goto IL_6A8;
                }
            IL_669:
            
            IL_6A8:
                photoId = ((LstMyItems)this.lstImages.SelectedItem).PhotoId;
         
            IL_6CA:
            IL_A3E:
                if (this.lstImages.Items.Count > 0 && this.lstImages.SelectedIndex == -1)
                {
                    this.lstImages.SelectedIndex = 0;
                    ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.Items[0]);
                    this.lstImages.SelectedItem = listBoxItem;
                    this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
                    listBoxItem.Focus();
                }
               
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            finally
            {
                await Task.Run(() =>
                {
                    Thread.Sleep(1000);                    
                });
            }
        }

        //public void SelectClientView(int ID)
        //{
        //    LstMyItems curItem;
        //    int _PhotoId = ID;
        //    curItem = RobotImageLoader.robotImages.Where(t => t.PhotoId == _PhotoId).FirstOrDefault<LstMyItems>();

        //    if (curItem != null)
        //    {
        //        this.img.Visibility = Visibility.Visible;


        //        if (this.lstImages.SelectedItem != curItem)
        //        {
        //            if (curItem != null)
        //            {
        //                this.lstImages.SelectedItem = curItem;
        //                RobotImageLoader.PhotoId = curItem.Name;
        //                ListBoxItem listBoxItem = (ListBoxItem)this.lstImages.ItemContainerGenerator.ContainerFromItem(this.lstImages.SelectedItem);
        //                listBoxItem.Focus();
        //                this.lstImages.ScrollIntoView(this.lstImages.SelectedItem);
        //            }
        //        }
        //    }
        //}

    }
}
