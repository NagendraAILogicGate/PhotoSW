//using BarcodeReaderLib;

using PhotoSW.Common;
using PhotoSW.DataLayer;
using PhotoSW.DataLayer.Model;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using PhotoSW.Shader;
using ErrorHandler;
using ExifLib;
using FrameworkHelper;
//using ImageMagickObject;
using LevDan.Exif;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;

namespace PhotoSW.PSControls
{
    public partial class AcquiredFrames : UserControl, IComponentConnector
    {
        private DeviceManager deviceManager = null;

       private PS_SemiOrder_Settings  objDG_SemiOrder_Settings;

        private static bool isrotated = false;

        private string _BorderFolder;

        private string Directoryname = string.Empty;

        private bool is_SemiOrder;

        private string path = string.Empty;

        private string defaultBrightness = string.Empty;

        private string defaultContrast = string.Empty;

        private UIElement _parent;

        private bool _hideRequest = false;

        private string _result;

        private bool? IsAutoRotate;

        private static int count;

        private static int ProcessedCount;

        private Dictionary<string, int> _locationList;

        private List<MyImageClass> ImageName;

        private bool IsBarcodeActive = false;

        private int MappingType = 0;

        private int scanType = 0;

        private bool IsDelete = false;

        private bool IsAnonymousCodeActive = false;

        private string QRWebURLReplace = string.Empty;

        private Dictionary<string, int> _photoGrapherList;

        public Hashtable htVidL = new Hashtable();

        private string thumbnailspath = string.Empty;

        private vw_GetConfigdata config = null;

        private string filepath;

        private string filepathdate;

        private string autoProVideoBackground = string.Empty;

        private int maxInstant = 2;

        public static Hashtable htVideosToProcess;

        public static int videoCount;

        public static int ProcessedvideoCount;

        public static int videothreadCount;

        private int CountImagesDownload = 0;

        private int needrotaion = 0;

        private string PhotoLayer = null;

        //internal AcquiredFrames UserControl;

        //internal Grid LayoutRoot;

        //internal Grid MainPanel;

        //internal Viewbox vb1;

        //internal StackPanel bg_withlogo;

        //internal System.Windows.Controls.Image bg;

        //internal ComboBox CmbPhotographerNo;

        //internal TextBox tbStartingNo;

        //internal ComboBox CmbLocation;

        //internal TextBlock Lastimageno;

        //internal ProgressBar DownloadProgress;

        //internal Button btnDownload;

        //internal Button btnBack;

        //private bool _contentLoaded;

        public List<MyImageClass> imagelist
        {
            get
            {
                return this.ImageName;
            }
            set
            {
                this.ImageName = value;
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

        public AcquiredFrames()
        {
            try
            {
                this.InitializeComponent();
                this.DownloadProgress.Minimum = 0.0;
                AcquiredFrames.count = 0;
                this.btnDownload.Content = "Download";
                List<PhotoGraphersInfo> list = new List<PhotoGraphersInfo>();
                list = new UserBusiness().GetPhotoGraphersList(LoginUser.StoreId);
                List<LocationInfo> list2 = new List<LocationInfo>();
                list2 = new LocationBusniess().GetLocationList(LoginUser.StoreId);
                this.LocationList = new Dictionary<string, int>();
                this.LocationList.Add("--Select--", 0);
                this.PhotoGrapherList = new Dictionary<string, int>();
                this.PhotoGrapherList.Add("--Select--", 0);
                if (list != null)
                {
                    foreach (PhotoGraphersInfo current in list)
                    {
                        this.PhotoGrapherList.Add(current.DG_User_First_Name + " " + current.DG_User_Last_Name, current.DG_User_pkey);
                    }
                    this.CmbPhotographerNo.ItemsSource = this.PhotoGrapherList;
                    this.CmbPhotographerNo.SelectedValue = "0";
                }
                if (list2 != null)
                {
                    foreach (LocationInfo current2 in list2)
                    {
                        this.LocationList.Add(current2.DG_Location_Name, current2.DG_Location_pkey);
                    }
                    this.CmbLocation.ItemsSource = this.LocationList;
                    this.CmbLocation.SelectedValue = "0";
                }
                ConfigurationInfo configurationData = new ConfigBusiness().GetConfigurationData(LoginUser.SubStoreId);
                this.QRWebURLReplace = new LocationBusniess().GetQRCodeWebUrl();
                this.filepath = configurationData.DG_Hot_Folder_Path;
                this.filepathdate = Path.Combine(this.filepath, DateTime.Now.ToString("yyyyMMdd"));
                if (!Directory.Exists(this.filepathdate))
                {
                    Directory.CreateDirectory(this.filepathdate);
                }
                this._BorderFolder = configurationData.DG_Frame_Path;
                this.IsAutoRotate = configurationData.DG_IsAutoRotate;
                this.is_SemiOrder = Convert.ToBoolean(configurationData.DG_SemiOrderMain);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public string ShowHandlerDialog()
        {
            base.Visibility = Visibility.Visible;
            this._hideRequest = false;
            string result;
            while (true)
            {
                int arg_99_0;
                int arg_50_0;
                int arg_4E_0;
                bool expr_8E = (arg_4E_0 = (arg_50_0 = (arg_99_0 = (this._hideRequest ? 1 : 0)))) != 0;
                if (!false)
                {
                    arg_99_0 = ((!expr_8E) ? 1 : 0);
                    goto IL_99;
                }
            IL_47:
                bool flag;
                if (!false)
                {
                    if (8 == 0)
                    {
                        goto IL_99;
                    }
                    flag = (arg_4E_0 != 0);
                    arg_50_0 = (flag ? 1 : 0);
                }
                if (arg_50_0 == 0)
                {
                    goto IL_A0;
                }
                base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                {
                }));
                int arg_9B_0;
                int expr_83 = arg_9B_0 = 20;
                if (expr_83 != 0)
                {
                    Thread.Sleep(expr_83);
                    continue;
                }
            IL_9B:
                if (arg_9B_0 == 0)
                {
                    goto IL_A0;
                }
                if (!false)
                {
                    arg_50_0 = (base.Dispatcher.HasShutdownStarted ? (arg_4E_0 = (arg_99_0 = 0)) : (arg_4E_0 = (arg_99_0 = ((!base.Dispatcher.HasShutdownFinished) ? 1 : 0))));
                    goto IL_47;
                }
            IL_A7:
                if (!false)
                {
                    break;
                }
                continue;
            IL_A0:
                result = this._result;
                goto IL_A7;
            IL_99:
                flag = (arg_99_0 != 0);
                arg_9B_0 = (flag ? 1 : 0);
                goto IL_9B;
            }
            return result;
        }

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
                            this._parent.IsEnabled = true;
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
            try
            {
                do
                {
                    bool arg_07_0 = this.IsValidData();
                    bool expr_40;
                    do
                    {
                        bool flag = !arg_07_0;
                        expr_40 = (arg_07_0 = flag);
                    }
                    while (false);
                    if (expr_40)
                    {
                        goto IL_20;
                    }
                }
                while (false);
            IL_16:
                if (true)
                {
                    this.Go();
                }
                goto IL_30;
            IL_20:
                if (7 != 0)
                {
                    if (false)
                    {
                        goto IL_16;
                    }
                    MessageBox.Show("Please enter valid data");
                }
            IL_30: ;
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

        private bool AcquireVideos(string vidFile, long PhotoNo, string PhotographerId, int locationid)
        {
            bool result;
            if (7 != 0)
            {
                IEnumerable<DriveInfo> enumerable = DriveInfo.GetDrives().Where(delegate(DriveInfo drive)
                {
                    bool result2;
                    while (8 != 0)
                    {
                        bool arg_36_0;
                        if (drive.DriveType == DriveType.Removable)
                        {
                            arg_36_0 = drive.IsReady;
                            if (2 != 0)
                            {
                            }
                        }
                        else
                        {
                            if (5 == 0 || false)
                            {
                                continue;
                            }
                            arg_36_0 = false;
                        }
                        result2 = arg_36_0;
                        break;
                    }
                    return result2;
                });
                int arg_65_0;
                int expr_59 = arg_65_0 = enumerable.Count<DriveInfo>();
                int arg_65_1;
                int expr_5F = arg_65_1 = 0;
                if (expr_5F == 0)
                {
                    arg_65_0 = ((expr_59 > expr_5F) ? 1 : 0);
                    arg_65_1 = 0;
                }
                if (arg_65_0 != arg_65_1)
                {
                    IEnumerator<DriveInfo> enumerator = enumerable.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            DriveInfo current = enumerator.Current;
                            //List<string> source = Directory.EnumerateFiles(current.Name, "*.*", SearchOption.AllDirectories).Where(delegate(string s)
                            //{
                            //    bool arg_14_0 = s.ToLower().EndsWith(".wmv");
                            //IL_14:
                            //    bool arg_F2_0;
                            //    while (!arg_14_0)
                            //    {
                            //        bool arg_2D_0 = s.ToLower().EndsWith(".mp4");
                            //        while (!arg_2D_0)
                            //        {
                            //            bool expr_13B = arg_14_0 = (arg_2D_0 = s.ToLower().EndsWith(".avi"));
                            //            if (6 == 0)
                            //            {
                            //                goto IL_14;
                            //            }
                            //            if (true)
                            //            {
                            //                if (expr_13B || s.ToLower().EndsWith(".mov"))
                            //                {
                            //                    break;
                            //                }
                            //                bool arg_C7_0;
                            //                bool expr_71 = arg_C7_0 = s.ToLower().EndsWith(".3gp");
                            //                if (7 != 0)
                            //                {
                            //                    if (expr_71)
                            //                    {
                            //                        break;
                            //                    }
                            //                    bool arg_A3_0;
                            //                    bool expr_86 = arg_A3_0 = s.ToLower().EndsWith(".3g2");
                            //                    if (!false)
                            //                    {
                            //                        if (expr_86 || false)
                            //                        {
                            //                            break;
                            //                        }
                            //                        arg_A3_0 = s.ToLower().EndsWith(".m2v");
                            //                    }
                            //                    if (arg_A3_0 || s.ToLower().EndsWith(".m4v"))
                            //                    {
                            //                        break;
                            //                    }
                            //                    arg_C7_0 = s.ToLower().EndsWith(".flv");
                            //                }
                            //                if (!arg_C7_0 && !s.ToLower().EndsWith(".mpg"))
                            //                {
                            //                    arg_F2_0 = s.ToLower().EndsWith("ffmpeg");
                            //                    goto IL_EB;
                            //                }
                            //                break;
                            //            }
                            //        }
                            //        break;
                            //    IL_EB:
                            //    IL_EE:
                            //        if (!false)
                            //        {
                            //            return arg_F2_0;
                            //        }
                            //        goto IL_EB;
                            //    }
                            //    arg_F2_0 = true;
                            //    //goto IL_EE;
                            //}).ToList<string>();
                            //string text = (from v in source
                            //               where v.Contains(vidFile)
                            //               select v).FirstOrDefault<string>();

                            string text = "";
                            if (text != null)
                            {
                                if (false)
                                {
                                    break;
                                }
                                string text2 = Path.GetExtension(text).ToLower();
                                DateTime dateTime = new CustomBusineses().ServerDateTime();
                                int arg_12A_0;
                                int arg_1D1_0;
                                if (8 != 0)
                                {
                                    arg_1D1_0 = (arg_12A_0 = dateTime.Day);
                                    goto IL_11D;
                                }
                                goto IL_165;
                            IL_207:
                                int expr_208 = arg_12A_0 = (arg_1D1_0 = 2);
                                string text3;
                                long vidLength;
                                if (expr_208 != 0)
                                {
                                    int mediaType = expr_208;
                                    int num = this.UpdateVideoDatabase(PhotoNo, text3 + text2, text3 + ".jpg", LoginUser.UserId, new CustomBusineses().ServerDateTime(), 0, mediaType, Convert.ToString(PhotographerId), locationid, vidLength);
                                    if (ConfigManager.IMIXConfigurations.ContainsKey(56L) && Convert.ToBoolean(ConfigManager.IMIXConfigurations[56L]))
                                    {
                                    }
                                    continue;
                                }
                                goto IL_11D;
                            IL_1D1:
                                int arg_1D1_1;
                                AcquiredFrames.videoCount = arg_1D1_0 + arg_1D1_1;
                                vidLength = (this.htVidL.ContainsKey(Path.GetFileName(text)) ? Convert.ToInt64(this.htVidL[Path.GetFileName(text)]) : 0L);
                                goto IL_207;
                            IL_11D:
                                int expr_11F = arg_1D1_1 = dateTime.Month;
                                if (false)
                                {
                                    goto IL_1D1;
                                }
                                text3 = (long)(arg_12A_0 + expr_11F) + PhotoNo + "_" + PhotographerId;
                                if (!new PhotoBusiness().CheckPhotos(text3 + text2, Convert.ToInt32(PhotographerId)))
                                {
                                    MessageBox.Show(PhotoNo + " already exists for today.");
                                    result = false;
                                    goto IL_2CB;
                                }
                            IL_165:
                                string dest = this.filepath + "\\Videos\\" + text3 + text2;
                                this.CopyVideo(text, dest);
                                if (7 != 0)
                                {
                                    string sourceFileName = Path.GetDirectoryName(this.path) + "\\" + Path.GetFileName(text) + ".jpg";
                                    File.Copy(sourceFileName, this.filepath + "Thumbnails\\" + text3 + ".jpg", true);
                                    arg_1D1_0 = AcquiredFrames.videoCount;
                                    arg_1D1_1 = 1;
                                    goto IL_1D1;
                                }
                                goto IL_207;
                            }
                        }
                    }
                    finally
                    {
                        if (4 != 0 && enumerator != null)
                        {
                            enumerator.Dispose();
                        }
                    }
                }
                result = true;
            IL_2CB: ;
            }
            return result;
        }

        private int UpdateVideoDatabase(long vidRFID, string vidName, string vidThumbnail, int createdBy, DateTime dateCreated, int productId, int MediaType, string PhotographerId, int locationid, long vidLength)
        {
            int result;
            do
            {
                if (!false)
                {
                    result = new PhotoBusiness().SetPhotoDetails(LoginUser.SubStoreId, vidRFID.ToString(), vidName, dateCreated, PhotographerId, string.Empty, locationid, null, string.Empty, null, new int?(0), 1, null, new long?(vidLength), true, new int?(1), new int?(0), null, 0, false);
                }
            }
            while (false);
            return result;
        }

        private void CopyVideo(string source, string dest)
        {
            bool expr_4D = Directory.Exists(this.filepath + "\\Videos");
            bool flag;
            if (!false)
            {
                flag = expr_4D;
            }
            if (!flag)
            {
                if (false || !false)
                {
                    goto IL_20;
                }
            }
        IL_32:
            while (4 != 0)
            {
                File.Copy(source, dest, true);
                if (2 != 0)
                {
                    return;
                }
            }
        IL_20:
            Directory.CreateDirectory(this.filepath + "\\Videos");
            goto IL_32;
        }

        private void Go()
        {
            do
            {
                if (8 != 0)
                {
                    int getitem = 0;
                    ThreadStart start;
                    DateTime? CaptureDate;
                    long PhotoNo;
                    string PhotographerId;
                    int locationid;
                    do
                    {
                        CaptureDate = new DateTime?(default(DateTime));
                        do
                        {
                            PhotoNo = Convert.ToInt64(this.tbStartingNo.Text);
                        }
                        while (false);
                        PhotographerId = this.CmbPhotographerNo.SelectedValue.ToString();
                        locationid = Convert.ToInt32(this.CmbLocation.SelectedValue);
                        start = delegate
                        {
                            string currentDirectory = Environment.CurrentDirectory;
                            this.path = currentDirectory + "\\";
                            this.path = Path.Combine(this.path, "Download\\");
                            this.thumbnailspath = Path.Combine(this.path, "Temp\\");
                            string str = string.Empty;
                            int num = 0;
                            List<MyImageClassList> list = new List<MyImageClassList>();
                            MyImageClassList myImageClassList = new MyImageClassList();
                            string empty = string.Empty;
                            string empty2 = string.Empty;
                            this.GetNewConfigLocationValues(locationid);
                            if (this.IsBarcodeActive)
                            {
                                if (this.scanType == Convert.ToInt32(ScanType.PreScan))
                                {
                                    this.ImageName = (from y in this.ImageName
                                                      where y.IsChecked
                                                      select y into x
                                                      orderby x.CreatedDate
                                                      select x).ToList<MyImageClass>();
                                }
                                else if (this.scanType == Convert.ToInt32(ScanType.PostScan))
                                {
                                    this.ImageName = (from y in this.ImageName
                                                      where y.IsChecked
                                                      select y into x
                                                      orderby x.CreatedDate descending
                                                      select x).ToList<MyImageClass>();
                                }
                                for (int i = 0; i < this.ImageName.Count; i++)
                                {
                                    if (this.ImageName[i].IsChecked)
                                    {
                                        
                                        //barcode barcode = null;
                                        string title = this.ImageName[i].Title;
                                        try
                                        {
                                            switch (this.MappingType)
                                            {
                                                //case 401:
                                                //    {

                                                //        BarcodeDecoder barcodeDecoder = (BarcodeDecoder)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("8389C2AD-BD70-47CA-8598-4B49CED46FC5")));
                                                //        barcodeDecoder.BarcodeTypes = 1073741824;
                                                //        barcodeDecoder.DecodeFile(this.thumbnailspath + title + ".jpg");
                                                //        BarcodeList barcodes = barcodeDecoder.Barcodes;
                                                //        if (barcodes.length > 0)
                                                //        {
                                                //            barcode = barcodes.item(0);
                                                //        }
                                                //        break;
                                                //    }
                                                //case 402:
                                                //    {
                                                //        BarcodeDecoder barcodeDecoder2 = (BarcodeDecoder)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("8389C2AD-BD70-47CA-8598-4B49CED46FC5")));
                                                //        barcodeDecoder2.LinearFindBarcodes = 1;
                                                //        barcodeDecoder2.LinearShowSymbologyID = false;
                                                //        barcodeDecoder2.BarcodeTypes = 3;
                                                //        barcodeDecoder2.LinearShowCheckDigit = false;
                                                //        barcodeDecoder2.DecodeFile(this.thumbnailspath + title + ".jpg");
                                                //        BarcodeList barcodes2 = barcodeDecoder2.Barcodes;
                                                //        if (barcodes2.length > 0)
                                                //        {
                                                //            barcode = barcodes2.item(0);
                                                //        }
                                                //        break;
                                                //    }
                                                //case 405:
                                                //    {
                                                //        BarcodeDecoder barcodeDecoder3 = (BarcodeDecoder)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("8389C2AD-BD70-47CA-8598-4B49CED46FC5")));
                                                //        barcodeDecoder3.BarcodeTypes = 1073741824;
                                                //        barcodeDecoder3.DecodeFile(this.thumbnailspath + title + ".jpg");
                                                //        BarcodeList barcodes = barcodeDecoder3.Barcodes;
                                                //        BarcodeDecoder barcodeDecoder4 = (BarcodeDecoder)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("8389C2AD-BD70-47CA-8598-4B49CED46FC5")));
                                                //        barcodeDecoder4.LinearFindBarcodes = 1;
                                                //        barcodeDecoder4.BarcodeTypes = 3;
                                                //        barcodeDecoder4.LinearShowCheckDigit = false;
                                                //        barcodeDecoder4.LinearShowSymbologyID = false;
                                                //        barcodeDecoder4.DecodeFile(this.thumbnailspath + title + ".jpg");
                                                //        BarcodeList barcodes2 = barcodeDecoder4.Barcodes;
                                                //        if (barcodes.length == 1 && barcodes2.length == 1)
                                                //        {
                                                //            barcode = barcodes.item(0);
                                                //        }
                                                //        else if (!false)
                                                //        {
                                                //            if (barcodes.length == 1 && barcodes2.length < 1)
                                                //            {
                                                //                barcode = barcodes.item(0);
                                                //            }
                                                //            else if (barcodes.length < 1 && barcodes2.length == 1)
                                                //            {
                                                //                barcode = barcodes2.item(0);
                                                //            }
                                                //        }
                                                //        break;
                                                //    }
                                            }
                                        }
                                        catch (Exception serviceException)
                                        {
                                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                                        }
                                        //if (barcode != null && (barcode.BarcodeType == EBarcodeTypes.Code128 || barcode.BarcodeType == EBarcodeTypes.Code39 || barcode.BarcodeType == EBarcodeTypes.QRCode))
                                        //{
                                        //    if (myImageClassList.ListMyImageClass.Count > 0)
                                        //    {
                                        //        list.Add(myImageClassList);
                                        //    }
                                        //    myImageClassList = new MyImageClassList();
                                        //    this.ImageName[i].IsCodeType = true;
                                        //    myImageClassList.ListMyImageClass.Add(this.ImageName[i]);
                                        //    if (!string.IsNullOrWhiteSpace(this.QRWebURLReplace))
                                        //    {
                                        //        myImageClassList.Barcode = barcode.Text.Replace(this.QRWebURLReplace, "");
                                        //    }
                                        //    else
                                        //    {
                                        //        myImageClassList.Barcode = barcode.Text;
                                        //    }
                                        //    myImageClassList.Format = barcode.BarcodeType.ToString();
                                        //}
                                        //else
                                        //{
                                            if (false)
                                            {
                                                goto IL_1C8C;
                                            }
                                            this.ImageName[i].IsCodeType = false;
                                            myImageClassList.ListMyImageClass.Add(this.ImageName[i]);
                                            if (i == this.ImageName.Count - 1)
                                            {
                                                list.Add(myImageClassList);
                                            }
                                        //}
                                    }
                                }
                                foreach (MyImageClassList current in list)
                                {
                                    getitem = getitem + current.ListMyImageClass.Count - 1;
                                }
                                foreach (MyImageClassList current in list)
                                {
                                    for (int j = 0; j < current.ListMyImageClass.Count; j++)
                                    {
                                        try
                                        {
                                            string text;
                                            if (2 != 0)
                                            {
                                                num++;
                                                text = current.ListMyImageClass[j].Title + ".jpg";
                                                if (!(text != "Thumbs.db"))
                                                {
                                                    goto IL_1134;
                                                }
                                            }
                                            string text2 = text;
                                            str = str + ", " + text2;
                                            if (current.ListMyImageClass[j].IsChecked)
                                            {
                                                try
                                                {
                                                    ExifTagCollection exifTagCollection = new ExifTagCollection(Path.Combine(current.ListMyImageClass[j].ImagePath, current.ListMyImageClass[j].srcPath) + ".jpg");
                                                    string text3 = "'##'";
                                                    string text4 = "'##'";
                                                    string text5 = "'##'";
                                                    string text6 = "'##'";
                                                    string text7 = "'##'";
                                                    string text8 = "'##'";
                                                    string text9 = "'##'";
                                                    string text10 = "'##'";
                                                    string text11 = "'##'";
                                                    string text12 = "'##'";
                                                    if (this.IsAutoRotate.Value)
                                                    {
                                                        string text13 = "";
                                                        try
                                                        {
                                                            ExifReader exifReader = new ExifReader(Path.Combine(current.ListMyImageClass[j].ImagePath, current.ListMyImageClass[j].Title) + ".jpg");
                                                            foreach (ushort tagID in Enum.GetValues(typeof(ExifTags)))
                                                            {
                                                                object obj;
                                                                if (exifReader.GetTagValue<object>(tagID, out obj))
                                                                {
                                                                    text13 = obj.ToString();
                                                                }
                                                            }
                                                        }
                                                        catch (Exception serviceException)
                                                        {
                                                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                                                        }
                                                        if (!string.IsNullOrEmpty(text13))
                                                        {
                                                            this.needrotaion = AcquiredFrames.GetRotationValue(text13);
                                                        }
                                                        else
                                                        {
                                                            this.needrotaion = 0;
                                                        }
                                                    }
                                                    if ((from o in exifTagCollection
                                                         where o.Id == 36867
                                                         select o).Count<ExifTag>() > 0)
                                                    {
                                                        try
                                                        {
                                                            DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
                                                            dateTimeFormatInfo.ShortDatePattern = "yyyy/MM/dd HH:mm:ss";
                                                            string text14 = exifTagCollection[36867].Value.Split(new char[]
															{
																' '
															}).First<string>();
                                                            text14 = text14.Replace(':', '/');
                                                            string str2 = exifTagCollection[36867].Value.Split(new char[]
															{
																' '
															}).Last<string>();
                                                            CaptureDate = new DateTime?(Convert.ToDateTime(text14 + " " + str2, dateTimeFormatInfo));
                                                        }
                                                        catch (Exception serviceException)
                                                        {
                                                            CaptureDate = null;
                                                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        CaptureDate = null;
                                                    }
                                                    foreach (ExifTag current2 in exifTagCollection)
                                                    {
                                                        if (current2.Id == 271)
                                                        {
                                                            text3 = "'" + exifTagCollection[271].Value + "'";
                                                        }
                                                        else
                                                        {
                                                            if (current2.Id == 272)
                                                            {
                                                                text4 = "'" + exifTagCollection[272].Value + "'";
                                                            }
                                                            else if (current2.Id == 274)
                                                            {
                                                                text5 = "'" + exifTagCollection[274].Value + "'";
                                                            }
                                                            else
                                                            {
                                                                bool flag = current2.Id != 282;
                                                                bool arg_ACF_0 = flag;
                                                                while (arg_ACF_0)
                                                                {
                                                                    flag = (current2.Id != 283);
                                                                    if (false)
                                                                    {
                                                                        goto IL_A75;
                                                                    }
                                                                    if (!flag)
                                                                    {
                                                                        text7 = "'" + exifTagCollection[283].Value + "'";
                                                                        goto IL_CC1;
                                                                    }
                                                                    if (current2.Id == 36867)
                                                                    {
                                                                        text8 = "'" + exifTagCollection[36867].Value + "'";
                                                                        goto IL_CC1;
                                                                    }
                                                                    if (current2.Id == 40962 || current2.Id == 40963)
                                                                    {
                                                                        text9 = string.Concat(new string[]
																		{
																			"'",
																			exifTagCollection[40962].Value,
																			" x ",
																			exifTagCollection[40963].Value,
																			"'"
																		});
                                                                        goto IL_CC1;
                                                                    }
                                                                    if (current2.Id == 34855)
                                                                    {
                                                                        text10 = "'" + exifTagCollection[34855].Value + "'";
                                                                        goto IL_CC1;
                                                                    }
                                                                    if (current2.Id == 41986)
                                                                    {
                                                                        text11 = "'" + exifTagCollection[41986].Value + "'";
                                                                        goto IL_CC1;
                                                                    }
                                                                    int expr_C82 = (arg_ACF_0 = (current2.Id != 0)) ? 1 : 0;
                                                                    if (!false)
                                                                    {
                                                                        if (expr_C82 == 41994)
                                                                        {
                                                                            text12 = "'" + exifTagCollection[41994].Value + "'";
                                                                            goto IL_CC1;
                                                                        }
                                                                        goto IL_CC1;
                                                                    }
                                                                }
                                                                text6 = "'" + exifTagCollection[282].Value + "'";
                                                            }
                                                        IL_A75: ;
                                                        }
                                                    IL_CC1: ;
                                                    }
                                                    this.ImageMetaData = string.Concat(new string[]
													{
														"<image Dimensions=",
														text9,
														" CameraManufacture=",
														text3,
														" HorizontalResolution=",
														text6,
														" VerticalResolution=",
														text7,
														" CameraModel=",
														text4,
														" ISO-SpeedRating=",
														text10,
														" DateTaken=",
														text8,
														" ExposureMode=",
														text11,
														" Sharpness=",
														text12,
														" Orientation=",
														text5,
														"></image>"
													});
                                                }
                                                catch (Exception serviceException)
                                                {
                                                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                                                }
                                                DateTime dateTime = new CustomBusineses().ServerDateTime();
                                                string text15 = string.Concat(new object[]
												{
													(long)(dateTime.Day + dateTime.Month) + PhotoNo,
													"_",
													PhotographerId,
													".jpg"
												});
                                                this.DefaultEffects = string.Concat(new string[]
												{
													"<image brightness = '",
													this.defaultBrightness,
													"' contrast = '",
													this.defaultContrast,
													"' Crop='##' colourvalue = '##' rotate='##' ><effects sharpen='##' greyscale='0' digimagic='0' sepia='0' defog='0' underwater='0' emboss='0' invert = '0' granite='0' hue ='##' cartoon = '0'></effects></image>"
												});
                                                if (!new PhotoBusiness().CheckPhotos(text15, Convert.ToInt32(PhotographerId)))
                                                {
                                                    MessageBox.Show(PhotoNo + " already exists for today");
                                                    return;
                                                }
                                                int photoId = new PhotoBusiness().SetPhotoDetails(LoginUser.SubStoreId, PhotoNo.ToString(), text15, new CustomBusineses().ServerDateTime(), PhotographerId, this.ImageMetaData, locationid, this.PhotoLayer, this.DefaultEffects, CaptureDate, App.RfidScanType, 1, null, new long?(0L), true, new int?(1), new int?(0), null, 0, false);
                                                if (j == 0 && current.ListMyImageClass[j].IsCodeType)
                                                {
                                                    new PhotoBusiness().DeletePhotoByPhotoId(photoId);
                                                }
                                                else if (!string.IsNullOrWhiteSpace(current.Barcode) && !string.IsNullOrWhiteSpace(current.Format))
                                                {
                                                    new PhotoBusiness().SetImageAssociationInfo(photoId, current.Format, current.Barcode, this.IsAnonymousCodeActive);
                                                }
                                                do
                                                {
                                                    string photonameOld = PhotoNo.ToString();
                                                    File.Copy(Path.Combine(current.ListMyImageClass[j].ImagePath, text2), Path.Combine(this.filepathdate, text15));
                                                    this.ResizeWPFImage(Path.Combine(this.filepathdate, text15), 210, this.filepath + "\\Thumbnails\\" + text15, Path.Combine(this.filepathdate, text15));
                                                    this.ResizeWPFImage(Path.Combine(this.filepathdate, text15), 900, this.filepath + "\\Thumbnails_Big\\" + text15);
                                                    if (!this.IsCodeType(photoId))
                                                    {
                                                        this.ApplySettings(photonameOld, text15, photoId, LoginUser.SubStoreId, locationid, this.filepathdate);
                                                    }
                                                    this.CountImagesDownload++;
                                                }
                                                while (false);
                                                PhotoNo += 1L;
                                                if (this.IsDelete)
                                                {
                                                    try
                                                    {
                                                        File.Delete(Path.Combine(current.ListMyImageClass[j].ImagePath, text2));
                                                    }
                                                    catch
                                                    {
                                                    }
                                                }
                                            }
                                        IL_1134: ;
                                        }
                                        catch (Exception serviceException)
                                        {
                                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                                        }
                                        object[] arg;
                                        if (!false)
                                        {
                                            arg = new object[]
											{
												num,
												getitem
											};
                                        }
                                        this.Dispatcher.Invoke(DispatcherPriority.Normal, new Action<object[]>(this.Update), arg);
                                    }
                                }
                            }
                            else
                            {
                                foreach (MyImageClass current3 in this.ImageName)
                                {
                                    string a = Path.GetExtension(current3.Title).ToLower();
                                    try
                                    {
                                        int arg_1220_0 = num + 1;
                                        bool expr_1BA3;
                                        while (true)
                                        {
                                            num = arg_1220_0;
                                            getitem = this.ImageName.Count;
                                            if (a == ".jpg")
                                            {
                                                break;
                                            }
                                            if (!current3.IsChecked)
                                            {
                                                goto IL_1BE9;
                                            }
                                            expr_1BA3 = ((arg_1220_0 = (this.AcquireVideos(current3.Title, PhotoNo, PhotographerId, locationid) ? 1 : 0)) != 0);
                                            if (6 != 0)
                                            {
                                                goto Block_101;
                                            }
                                        }
                                        string text = current3.Title;
                                        if (text != "Thumbs.db")
                                        {
                                            string text2 = text;
                                            str = str + ", " + text2;
                                            if (current3.IsChecked)
                                            {
                                                try
                                                {
                                                    ExifTagCollection exifTagCollection = new ExifTagCollection(current3.ImagePath);
                                                    string text3 = "'##'";
                                                    string text4 = "'##'";
                                                    string text5 = "'##'";
                                                    string text6 = "'##'";
                                                    string text7 = "'##'";
                                                    string text8 = "'##'";
                                                    string text9 = "'##'";
                                                    string text10 = "'##'";
                                                    string text11 = "'##'";
                                                    string text12 = "'##'";
                                                    if (this.IsAutoRotate.Value)
                                                    {
                                                        string text13 = "";
                                                        try
                                                        {
                                                            ExifReader exifReader = new ExifReader(Path.Combine(current3.ImagePath, current3.Title) + ".jpg");
                                                            foreach (ushort tagID in Enum.GetValues(typeof(ExifTags)))
                                                            {
                                                                object obj;
                                                                if (exifReader.GetTagValue<object>(tagID, out obj))
                                                                {
                                                                    text13 = obj.ToString();
                                                                }
                                                            }
                                                        }
                                                        catch (Exception serviceException)
                                                        {
                                                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                                                        }
                                                        if (!string.IsNullOrEmpty(text13))
                                                        {
                                                            this.needrotaion = AcquiredFrames.GetRotationValue(text13);
                                                            if (true)
                                                            {
                                                                goto IL_13FD;
                                                            }
                                                        }
                                                        this.needrotaion = 0;
                                                    IL_13FD: ;
                                                    }
                                                    if ((from o in exifTagCollection
                                                         where o.Id == 36867
                                                         select o).Count<ExifTag>() > 0)
                                                    {
                                                        try
                                                        {
                                                            DateTimeFormatInfo dateTimeFormatInfo = new DateTimeFormatInfo();
                                                            dateTimeFormatInfo.ShortDatePattern = "yyyy/MM/dd HH:mm:ss";
                                                            string text14 = exifTagCollection[36867].Value.Split(new char[]
															{
																' '
															}).First<string>();
                                                            text14 = text14.Replace(':', '/');
                                                            string str2 = exifTagCollection[36867].Value.Split(new char[]
															{
																' '
															}).Last<string>();
                                                            CaptureDate = new DateTime?(Convert.ToDateTime(text14 + " " + str2, dateTimeFormatInfo));
                                                        }
                                                        catch (Exception serviceException)
                                                        {
                                                            CaptureDate = null;
                                                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        CaptureDate = null;
                                                    }
                                                    foreach (ExifTag current2 in exifTagCollection)
                                                    {
                                                        if (current2.Id == 271)
                                                        {
                                                            text3 = "'" + exifTagCollection[271].Value + "'";
                                                        }
                                                        else
                                                        {
                                                            int arg_1573_0 = (current2.Id == 272) ? 1 : 0;
                                                            int arg_1573_1 = 0;
                                                            while (arg_1573_0 == arg_1573_1)
                                                            {
                                                                if (current2.Id == 274)
                                                                {
                                                                    text5 = "'" + exifTagCollection[274].Value + "'";
                                                                    goto IL_17E5;
                                                                }
                                                                if (current2.Id == 282)
                                                                {
                                                                    text6 = "'" + exifTagCollection[282].Value + "'";
                                                                    goto IL_17E5;
                                                                }
                                                                if (current2.Id == 283)
                                                                {
                                                                    text7 = "'" + exifTagCollection[283].Value + "'";
                                                                    goto IL_17E5;
                                                                }
                                                                if (current2.Id == 36867)
                                                                {
                                                                    text8 = "'" + exifTagCollection[36867].Value + "'";
                                                                    goto IL_17E5;
                                                                }
                                                                if (current2.Id == 40962 || current2.Id == 40963)
                                                                {
                                                                    text9 = string.Concat(new string[]
																	{
																		"'",
																		exifTagCollection[40962].Value,
																		" x ",
																		exifTagCollection[40963].Value,
																		"'"
																	});
                                                                    goto IL_17E5;
                                                                }
                                                                if (current2.Id == 34855)
                                                                {
                                                                    text10 = "'" + exifTagCollection[34855].Value + "'";
                                                                    goto IL_17E5;
                                                                }
                                                                int expr_1769 = arg_1573_0 = current2.Id;
                                                                int expr_1773 = arg_1573_1 = 41986;
                                                                if (expr_1773 != 0)
                                                                {
                                                                    if (expr_1769 == expr_1773)
                                                                    {
                                                                        text11 = "'" + exifTagCollection[41986].Value + "'";
                                                                        goto IL_17E5;
                                                                    }
                                                                    if (current2.Id == 41994)
                                                                    {
                                                                        text12 = "'" + exifTagCollection[41994].Value + "'";
                                                                        goto IL_17E5;
                                                                    }
                                                                    goto IL_17E5;
                                                                }
                                                            }
                                                            text4 = "'" + exifTagCollection[272].Value + "'";
                                                        }
                                                    IL_17E5: ;
                                                    }
                                                    this.ImageMetaData = string.Concat(new string[]
													{
														"<image Dimensions=",
														text9,
														" CameraManufacture=",
														text3,
														" HorizontalResolution=",
														text6,
														" VerticalResolution=",
														text7,
														" CameraModel=",
														text4,
														" ISO-SpeedRating=",
														text10,
														" DateTaken=",
														text8,
														" ExposureMode=",
														text11,
														" Sharpness=",
														text12,
														" Orientation=",
														text5,
														"></image>"
													});
                                                }
                                                catch (Exception serviceException)
                                                {
                                                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                                                }
                                                DateTime dateTime2 = new CustomBusineses().ServerDateTime();
                                                string text15 = string.Concat(new object[]
												{
													(long)(dateTime2.Day + dateTime2.Month) + PhotoNo,
													"_",
													PhotographerId,
													".jpg"
												});
                                                this.DefaultEffects = string.Concat(new string[]
												{
													"<image brightness = '",
													this.defaultBrightness,
													"' contrast = '",
													this.defaultContrast,
													"' Crop='##' colourvalue = '##' rotate='##' ><effects sharpen='##' greyscale='0' digimagic='0' sepia='0' defog='0' underwater='0' emboss='0' invert = '0' granite='0' hue ='##' cartoon = '0'></effects></image>"
												});
                                                if (!new PhotoBusiness().CheckPhotos(text15, Convert.ToInt32(PhotographerId)))
                                                {
                                                    MessageBox.Show(PhotoNo + " already exists for today");
                                                    return;
                                                }
                                                if (!false)
                                                {
                                                    int photoId2 = new PhotoBusiness().SetPhotoDetails(LoginUser.SubStoreId, PhotoNo.ToString(), text15, new CustomBusineses().ServerDateTime(), PhotographerId, this.ImageMetaData, locationid, this.PhotoLayer, this.DefaultEffects, CaptureDate, App.RfidScanType, 1, null, new long?(0L), true, new int?(1), new int?(0), null, 0, false);
                                                    string photonameOld = PhotoNo.ToString();
                                                    File.Copy(current3.ImagePath, Path.Combine(this.filepathdate, text15));
                                                    this.ResizeWPFImage(Path.Combine(this.filepathdate, text15), 210, Path.Combine(this.filepath, "Thumbnails", text15), Path.Combine(this.filepathdate, text15));
                                                    this.ResizeWPFImage(Path.Combine(this.filepathdate, text15), 900, Path.Combine(this.filepath, "Thumbnails_Big", text15));
                                                    this.ApplySettings(photonameOld, text15, photoId2, LoginUser.SubStoreId, locationid, this.filepathdate);
                                                    this.CountImagesDownload++;
                                                }
                                                PhotoNo += 1L;
                                            }
                                        }
                                        goto IL_1BEA;
                                    Block_101:
                                        if (!expr_1BA3)
                                        {
                                            return;
                                        }
                                        this.CountImagesDownload++;
                                        PhotoNo += 1L;
                                    IL_1BE9:
                                    IL_1BEA: ;
                                    }
                                    catch (Exception serviceException)
                                    {
                                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                                    }
                                    object[] arg = new object[]
									{
										num,
										getitem
									};
                                    this.Dispatcher.Invoke(DispatcherPriority.Normal, new Action<object[]>(this.Update), arg);
                                }
                            }
                            if (this.CountImagesDownload <= 0)
                            {
                                return;
                            }
                        IL_1C8C:
                            MessageBox.Show(this.CountImagesDownload + " File(s) Acquired Successfully");
                            this._result = string.Empty;
                            this.HideHandlerDialog();
                        };
                    }
                    while (4 == 0 || 5 == 0);
                    new Thread(start).Start();
                }
            }
            while (false);
        }

        private void Update(object[] obj)
        {
            if (false)
            {
                goto IL_38;
            }
            if (false)
            {
                goto IL_49;
            }
            int num = (int)obj[0];
            int num2 = (int)obj[1];
            this.btnDownload.IsEnabled = false;
        IL_28:
            if (!false)
            {
                this.DownloadProgress.Maximum = (double)num2;
            }
        IL_38:
            this.DownloadProgress.Value = (double)num;
            if (!false)
            {
            }
        IL_49:
            if (5 != 0)
            {
                return;
            }
            goto IL_28;
        }

        private bool IsValidData()
        {
            int arg_100_0;
            int arg_C9_0;
            int expr_02 = arg_C9_0 = (arg_100_0 = 1);
            if (expr_02 == 0)
            {
                goto IL_C3;
            }
            bool flag = expr_02 != 0;
            bool arg_2F_0;
            bool arg_6D_0 = arg_2F_0 = (this.CmbPhotographerNo.SelectedValue.ToString() == "0");
            if (2 == 0)
            {
                goto IL_6D;
            }
            int arg_2F_1 = 0;
        IL_2F:
            bool flag2 = (arg_2F_0 ? 1 : 0) == arg_2F_1;
            bool arg_3B_0 = flag2;
            while (arg_3B_0)
            {
                bool expr_60 = arg_3B_0 = (this.CmbLocation.SelectedValue.ToString() == "0");
                if (!false)
                {
                    flag2 = !expr_60;
                    arg_6D_0 = flag2;
                    goto IL_6D;
                }
            }
            arg_100_0 = 0;
        IL_3F:
            flag = (arg_100_0 != 0);
            //goto IL_73;
        IL_6D:
            if (!arg_6D_0)
            {
                flag = false;
            }
            try
            {
            IL_73:
                if (!false)
                {
                    Convert.ToInt64(this.tbStartingNo.Text);
                }
            }
            catch (Exception var_1_8B)
            {
                flag = false;
            }
            int expr_A8 = (arg_2F_0 = (this.tbStartingNo.Text.Trim() == "")) ? 1 : 0;
            int expr_AE = arg_2F_1 = 0;
            if (expr_AE != 0)
            {
                goto IL_2F;
            }
            if (expr_A8 != expr_AE)
            {
                flag = false;
            }
            bool flag3 = flag;
            arg_100_0 = (arg_C9_0 = (flag3 ? 1 : 0));
        IL_C3:
            if (!false)
            {
                return arg_C9_0 != 0;
            }
            goto IL_3F;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            this._result = string.Empty;
            this.HideHandlerDialog();
        }

        private void CmbPhotographerNo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int arg_16_0 = Convert.ToInt32(this.CmbPhotographerNo.SelectedValue);
            bool expr_16;
            do
            {
                expr_16 = ((arg_16_0 = ((arg_16_0 == 0) ? 1 : 0)) != 0);
            }
            while (false);
            if (!expr_16)
            {
                this.Lastimageno.Visibility = Visibility.Visible;
                try
                {
                    string photoGrapherLastImageId = new PhotoBusiness().GetPhotoGrapherLastImageId(Convert.ToInt32(this.CmbPhotographerNo.SelectedValue));
                    this.Lastimageno.Text = "Last Photo no. of " + ((KeyValuePair<string, int>)this.CmbPhotographerNo.SelectedItem).Key + " is " + photoGrapherLastImageId;
                }
                catch (Exception serviceException)
                {
                    if (true)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        if (!false)
                        {
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                    }
                }
            }
            else
            {
                this.Lastimageno.Visibility = Visibility.Collapsed;
                while (false)
                {
                }
            }
        }

        private void GetNewConfigValues()
        {
            List<iMIXConfigurationInfo> newConfigValues = new ConfigBusiness().GetNewConfigValues(LoginUser.SubStoreId);
            foreach (iMIXConfigurationInfo current in newConfigValues)
            {
                long iMIXConfigurationMasterId = current.IMIXConfigurationMasterId;
                long arg_B1_0;
                long expr_3E = arg_B1_0 = iMIXConfigurationMasterId;
                long arg_B1_1;
                long expr_41 = arg_B1_1 = 23L;
                if (false)
                {
                    goto IL_B1;
                }
                int arg_59_0;
                if (expr_3E <= expr_41)
                {
                    if (iMIXConfigurationMasterId > 3L)
                    {
                        //goto IL_6A;
                    }
                    if (iMIXConfigurationMasterId >= 1L)
                    {
                        arg_59_0 = (int)(iMIXConfigurationMasterId - 1L);
                        goto IL_59;
                    }
                }
                else
                {
                    if (iMIXConfigurationMasterId != 38L)
                    {
                        goto IL_9E;
                    }
                    this.IsAnonymousCodeActive = Convert.ToBoolean(current.ConfigurationValue);
                }
                continue;
            IL_59:
                switch (arg_59_0)
                {
                    case 0:
                        this.IsBarcodeActive = Convert.ToBoolean(current.ConfigurationValue);
                        if (!false)
                        {
                            continue;
                        }
                        continue;
                    case 1:
                        this.MappingType = Convert.ToInt32(current.ConfigurationValue);
                        continue;
                    case 2:
                        this.scanType = Convert.ToInt32(current.ConfigurationValue);
                        continue;
                    default:
                    IL_6A:
                        if (iMIXConfigurationMasterId <= 23L)
                        {
                            if (false)
                            {
                                goto IL_9E;
                            }
                            if (iMIXConfigurationMasterId >= 21L)
                            {
                                switch ((int)(iMIXConfigurationMasterId - 21L))
                                {
                                    case 0:
                                        this.defaultContrast = (string.IsNullOrEmpty(current.ConfigurationValue) ? "1" : current.ConfigurationValue);
                                        break;
                                    case 1:
                                        goto IL_149;
                                    case 2:
                                        this.IsDelete = Convert.ToBoolean(current.ConfigurationValue);
                                        break;
                                }
                            }
                        }
                        continue;
                }
            IL_149:
                this.defaultBrightness = (string.IsNullOrEmpty(current.ConfigurationValue) ? "0" : current.ConfigurationValue);
                if (3 != 0)
                {
                    continue;
                }
                continue;
            IL_B1:
                int arg_1EA_0;
                switch ((int)(arg_B1_0 - arg_B1_1))
                {
                    case 0:
                        {
                            int arg_1BD_0;
                            if (current.ConfigurationValue == null || !(current.ConfigurationValue != ""))
                            {
                                if ((arg_59_0 = (arg_1BD_0 = (arg_1EA_0 = 0))) != 0)
                                {
                                    goto IL_59;
                                }
                            }
                            else
                            {
                                arg_1EA_0 = (arg_1BD_0 = (Convert.ToBoolean(current.ConfigurationValue) ? 1 : 0));
                            }
                            if (8 != 0)
                            {
                                App.IsRFIDEnabled = (arg_1BD_0 != 0);
                                continue;
                            }
                            break;
                        }
                    case 1:
                        arg_1EA_0 = ((!App.IsRFIDEnabled || current.ConfigurationValue == null || !(current.ConfigurationValue != "")) ? 1 : 0);
                        break;
                    default:
                        continue;
                }
                bool flag = arg_1EA_0 != 0;
                if (2 != 0)
                {
                    if (!flag)
                    {
                        App.RfidScanType = new int?(Convert.ToInt32(current.ConfigurationValue));
                    }
                    else
                    {
                        App.RfidScanType = null;
                    }
                    continue;
                }
                goto IL_149;
            IL_9E:
                if (iMIXConfigurationMasterId <= 50L)
                {
                    if (iMIXConfigurationMasterId >= 49L)
                    {
                        arg_B1_0 = iMIXConfigurationMasterId;
                        arg_B1_1 = 49L;
                        goto IL_B1;
                    }
                }
            }
        }

        private void GetNewConfigLocationValues(int LocationId)
        {
            ConfigBusiness configBusiness = new ConfigBusiness();
            List<iMixConfigurationLocationInfo> configLocation = configBusiness.GetConfigLocation(LocationId, LoginUser.SubStoreId);
            List<iMixConfigurationLocationInfo>.Enumerator enumerator = configLocation.GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    if (false)
                    {
                        goto IL_56;
                    }
                    iMixConfigurationLocationInfo current = enumerator.Current;
                    long iMIXConfigurationMasterId = current.IMIXConfigurationMasterId;
                    if (false)
                    {
                        goto IL_E4;
                    }
                    if (iMIXConfigurationMasterId <= 23L)
                    {
                        goto IL_56;
                    }
                    long arg_8B_0;
                    long arg_8B_1;
                    if (iMIXConfigurationMasterId != 38L)
                    {
                        long arg_C6_0;
                        long expr_B4 = arg_8B_0 = (arg_C6_0 = iMIXConfigurationMasterId);
                        if (!false)
                        {
                            long expr_BB = arg_8B_1 = 50L;
                            if (5 == 0)
                            {
                                goto IL_8B;
                            }
                            if (expr_B4 > expr_BB)
                            {
                                continue;
                            }
                            arg_C6_0 = iMIXConfigurationMasterId;
                        }
                        if (arg_C6_0 >= 49L)
                        {
                            switch ((int)(iMIXConfigurationMasterId - 49L))
                            {
                                case 0:
                                    App.IsRFIDEnabled = (current.ConfigurationValue != null && current.ConfigurationValue != "" && Convert.ToBoolean(current.ConfigurationValue));
                                    break;
                                case 1:
                                    {
                                        bool arg_1D3_0 = App.IsRFIDEnabled;
                                        bool arg_1F7_0;
                                        while (arg_1D3_0 && current.ConfigurationValue != null)
                                        {
                                            bool expr_1E8 = arg_1D3_0 = (current.ConfigurationValue != "");
                                            if (2 != 0)
                                            {
                                                arg_1F7_0 = !expr_1E8;
                                            IL_1F6:
                                                if (!arg_1F7_0)
                                                {
                                                    App.RfidScanType = new int?(Convert.ToInt32(current.ConfigurationValue));
                                                }
                                                else
                                                {
                                                    App.RfidScanType = null;
                                                }
                                                goto IL_223;
                                            }
                                        }
                                        arg_1F7_0 = true;
                                        //goto IL_1F6;
                                        break;
                                    }
                            }
                        }
                    }
                    else
                    {
                        this.IsAnonymousCodeActive = Convert.ToBoolean(current.ConfigurationValue);
                    }
                IL_223:
                    continue;
                IL_E4:
                    this.IsBarcodeActive = Convert.ToBoolean(current.ConfigurationValue);
                    continue;
                IL_8B:
                    if (arg_8B_0 >= arg_8B_1)
                    {
                        switch ((int)(iMIXConfigurationMasterId - 21L))
                        {
                            case 0:
                                this.defaultContrast = (string.IsNullOrEmpty(current.ConfigurationValue) ? "1" : current.ConfigurationValue);
                                break;
                            case 1:
                                this.defaultBrightness = (string.IsNullOrEmpty(current.ConfigurationValue) ? "0" : current.ConfigurationValue);
                                break;
                            case 2:
                                this.IsDelete = Convert.ToBoolean(current.ConfigurationValue);
                                break;
                        }
                        continue;
                    }
                    continue;
                IL_56:
                    long arg_5A_0 = iMIXConfigurationMasterId;
                    long arg_5A_1 = 3L;
                    while (arg_5A_0 <= arg_5A_1)
                    {
                        long expr_5C = arg_5A_0 = iMIXConfigurationMasterId;
                        long expr_5F = arg_5A_1 = 1L;
                        if (8 != 0)
                        {
                            if (expr_5C >= expr_5F)
                            {
                                switch ((int)(iMIXConfigurationMasterId - 1L))
                                {
                                    case 0:
                                        goto IL_E4;
                                    case 1:
                                        this.MappingType = Convert.ToInt32(current.ConfigurationValue);
                                        goto IL_223;
                                    case 2:
                                        this.scanType = Convert.ToInt32(current.ConfigurationValue);
                                        goto IL_223;
                                }
                                break;
                            }
                            goto IL_221;
                        }
                    }
                    if (iMIXConfigurationMasterId <= 23L)
                    {
                        arg_8B_0 = iMIXConfigurationMasterId;
                        arg_8B_1 = 21L;
                        goto IL_8B;
                    }
                IL_221: ;
                }
            }
            finally
            {
                if (!false)
                {
                    ((IDisposable)enumerator).Dispose();
                }
            }
        }

        private void ResizeWPFImage(string sourceImage, int maxHeight, string saveToPath, string rotatePath)
        {
            do
            {
                try
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    BitmapImage bitmapImage2 = new BitmapImage();
                    using (FileStream fileStream = File.OpenRead(sourceImage))
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        fileStream.CopyTo(memoryStream);
                        memoryStream.Seek(0L, SeekOrigin.Begin);
                        fileStream.Close();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                        bitmapImage.Freeze();
                        bool arg_152_0;
                        //MagickImage magickImage;
                        do
                        {
                            bool expr_80 = arg_152_0 = (bitmapImage.Width < bitmapImage.Height);
                            if (false)
                            {
                                goto IL_151;
                            }
                            int decodePixelWidth;
                            int decodePixelHeight;
                            if (!expr_80)
                            {
                                decimal d = Convert.ToDecimal(bitmapImage.Width) / Convert.ToDecimal(bitmapImage.Height);
                                decodePixelWidth = maxHeight;
                                decodePixelHeight = Convert.ToInt32(maxHeight / d);
                            }
                            else
                            {
                                decimal d = Convert.ToDecimal(bitmapImage.Height) / Convert.ToDecimal(bitmapImage.Width);
                                decodePixelHeight = maxHeight;
                                decodePixelWidth = Convert.ToInt32(maxHeight / d);
                            }
                            memoryStream.Seek(0L, SeekOrigin.Begin);
                            bitmapImage2.BeginInit();
                            bitmapImage2.StreamSource = memoryStream;
                            bitmapImage2.DecodePixelWidth = decodePixelWidth;
                            bitmapImage2.DecodePixelHeight = decodePixelHeight;
                            //magickImage = (MagickImage)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("5630BE5A-3F5F-4BCA-A511-AD6A6386CAC1")));
                        }
                        while (2 == 0);
                        arg_152_0 = (this.needrotaion > 0);
                    IL_151:
                        if (arg_152_0)
                        {
                            if (this.needrotaion == 0)
                            {
                                bitmapImage2.Rotation = Rotation.Rotate0;
                                AcquiredFrames.isrotated = false;
                            }
                            else
                            {
                                int arg_1F3_0;
                                int expr_186 = arg_1F3_0 = this.needrotaion;
                                int arg_1F3_1;
                                int expr_18D = arg_1F3_1 = 90;
                                if (expr_18D == 0)
                                {
                                    goto IL_1F3;
                                }
                                bool flag = expr_186 != expr_18D;
                            IL_197:
                                if (!flag)
                                {
                                    bitmapImage2.Rotation = Rotation.Rotate90;
                                    object[] array = new object[]
									{
										"-rotate",
										" 90 ",
										rotatePath
									};
                                    object[] array2 = array;
                                    //IMagickImage arg_1D0_0 = magickImage;
                                    //array = array2;
                                    //arg_1D0_0.Mogrify(ref array);
                                    AcquiredFrames.isrotated = true;
                                    goto IL_2A6;
                                }
                                arg_1F3_0 = ((this.needrotaion == 180) ? 1 : 0);
                                arg_1F3_1 = 0;
                            IL_1F3:
                                flag = (arg_1F3_0 == arg_1F3_1);
                                if (8 == 0)
                                {
                                    goto IL_2BE;
                                }
                                if (!flag)
                                {
                                    bitmapImage2.Rotation = Rotation.Rotate180;
                                    if (false)
                                    {
                                        goto IL_197;
                                    }
                                    object[] array = new object[]
									{
										"-rotate",
										" 180 ",
										rotatePath
									};
                                    object[] array2 = array;
                                    //IMagickImage arg_239_0 = magickImage;
                                    //array = array2;
                                    //arg_239_0.Mogrify(ref array);
                                    AcquiredFrames.isrotated = false;
                                }
                                else if (this.needrotaion == 270)
                                {
                                    bitmapImage2.Rotation = Rotation.Rotate270;
                                    object[] array = new object[]
									{
										"-rotate",
										" 270 ",
										rotatePath
									};
                                    object[] array2 = array;
                                    //IMagickImage arg_296_0 = magickImage;
                                    //array = array2;
                                    //arg_296_0.Mogrify(ref array);
                                    AcquiredFrames.isrotated = true;
                                }
                            }
                        IL_2A6: ;
                        }
                        //magickImage = null;
                        bitmapImage2.EndInit();
                        bitmapImage2.Freeze();
                        fileStream.Close();
                    IL_2BE: ;
                    }
                    while (false)
                    {
                    }
                    using (FileStream fileStream2 = new FileStream(saveToPath, FileMode.Create, FileAccess.ReadWrite))
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
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
            while (2 == 0);
        }

        private void ResizeWPFImage(string sourceImage, int maxHeight, string saveToPath)
        {
            try
            {
                BitmapImage expr_1D8 = new BitmapImage();
                BitmapImage bitmapImage;
                if (true)
                {
                    bitmapImage = expr_1D8;
                }
                BitmapImage bitmapImage2 = new BitmapImage();
                using (FileStream fileStream = File.OpenRead(sourceImage))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    memoryStream.Seek(0L, SeekOrigin.Begin);
                    int decodePixelWidth;
                    int decodePixelHeight;
                    while (true)
                    {
                        fileStream.Close();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = memoryStream;
                        decimal d;
                        int arg_F0_0;
                        int expr_BE;
                        while (true)
                        {
                            bitmapImage.EndInit();
                            bitmapImage.Freeze();
                            int arg_69_0 = 0;
                            while (true)
                            {
                                d = new decimal(arg_69_0);
                                if ((arg_F0_0 = 0) != 0)
                                {
                                    goto IL_F0;
                                }
                                if (bitmapImage.Width < bitmapImage.Height)
                                {
                                    break;
                                }
                                d = Convert.ToDecimal(bitmapImage.Width) / Convert.ToDecimal(bitmapImage.Height);
                                decodePixelWidth = maxHeight;
                                expr_BE = (arg_69_0 = Convert.ToInt32(maxHeight / d));
                                if (!false)
                                {
                                    goto Block_6;
                                }
                            }
                            if (!false)
                            {
                                goto Block_7;
                            }
                        }
                    IL_107:
                        memoryStream.Seek(0L, SeekOrigin.Begin);
                        if (!false)
                        {
                            break;
                        }
                        continue;
                    Block_6:
                        decodePixelHeight = expr_BE;
                        goto IL_107;
                    IL_F0:
                        decodePixelHeight = arg_F0_0;
                        decodePixelWidth = Convert.ToInt32(maxHeight / d);
                        goto IL_107;
                    Block_7:
                        d = Convert.ToDecimal(bitmapImage.Height) / Convert.ToDecimal(bitmapImage.Width);
                        arg_F0_0 = maxHeight;
                        goto IL_F0;
                    }
                    do
                    {
                        bitmapImage2.BeginInit();
                        bitmapImage2.StreamSource = memoryStream;
                        bitmapImage2.DecodePixelWidth = decodePixelWidth;
                        bitmapImage2.DecodePixelHeight = decodePixelHeight;
                        bitmapImage2.EndInit();
                        bitmapImage2.Freeze();
                    }
                    while (8 == 0);
                    fileStream.Close();
                }
                FileStream fileStream2 = new FileStream(saveToPath, FileMode.Create, FileAccess.ReadWrite);
                try
                {
                    JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
                    jpegBitmapEncoder.QualityLevel = 94;
                    jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapImage2));
                    if (!false)
                    {
                        jpegBitmapEncoder.Save(fileStream2);
                    }
                    fileStream2.Close();
                }
                finally
                {
                    if (8 == 0 || fileStream2 != null)
                    {
                        ((IDisposable)fileStream2).Dispose();
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private static int GetRotationValue(string orientation)
        {
            int num = int.Parse(orientation);
            int arg_16_0 = num;
            int expr_7E=0;
            int expr_3F=0;
            while (true)
            {
                int arg_17_0 = arg_16_0 - 1;
                while (true)
                {
                    switch (arg_17_0)
                    {
                        case 0:
                            goto IL_3E;
                        case 1:
                            goto IL_49;
                        case 2:
                            goto IL_54;
                        case 3:
                            goto IL_60;
                        case 4:
                            goto IL_69;
                        case 5:
                            goto IL_74;
                        case 6:
                            expr_7E = (arg_17_0 = 270);
                            if (expr_7E != null)
                            {
                                goto Block_5;
                            }
                            continue;
                        case 7:
                            goto IL_87;
                    }
                    goto Block_1;
                }
            IL_3E:
                expr_3F = (arg_16_0 = 0);
                if (expr_3F == 0)
                {
                    goto Block_2;
                }
            }
        Block_1:
            int result = 0;
            if (2 != 0)
            {
                return result;
            }
            goto IL_67;
        Block_2:
            result = expr_3F;
            return result;
        IL_49:
            int arg_8C_0;
            int expr_4A = arg_8C_0 = 0;
            if (expr_4A == 0)
            {
                result = expr_4A;
                return result;
            }
            goto IL_8C;
        IL_54:
            result = 180;
            return result;
        IL_60:
            result = 180;
        IL_67:
            return result;
        IL_69:
            if (!false)
            {
                int expr_6C = 90;
                if (!false)
                {
                    result = expr_6C;
                }
                return result;
            }
            return result;
        IL_74:
            result = 90;
            return result;
        Block_5:
            result = expr_7E;
            return result;
        IL_87:
            arg_8C_0 = 270;
        IL_8C:
            result = arg_8C_0;
            return result;
        }

        private static RotateFlipType OrientationToFlipType(string orientation)
        {
            int num = int.Parse(orientation);
            int arg_13_0 = num;
            int expr_47=0;
            RotateFlipType expr_67 ;
            int expr_3C = 0 ;
            while (true)
            {
                int arg_14_0 = arg_13_0 - 1;
                while (true)
                {
                    int arg_67_0;
                    switch (arg_14_0)
                    {
                        case 0:
                            goto IL_3B;
                        case 1:
                            expr_47 = (arg_67_0 = 4);
                            if (expr_47 != 0)
                            {
                                goto Block_3;
                            }
                            goto IL_67;
                        case 2:
                            goto IL_4E;
                        case 3:
                            goto IL_53;
                        case 4:
                            goto IL_58;
                        case 5:
                            goto IL_62;
                        case 6:
                            arg_67_0 = 7;
                            goto IL_67;
                        case 7:
                            goto IL_70;
                    }
                    goto Block_1;
                IL_67:
                    //expr_67 = (arg_14_0 = arg_67_0);
                    //if (expr_67 != null)
                    //{
                    //    goto Block_5;
                    //}
                    ;
                }
            IL_3B:
                expr_3C = (arg_13_0 = 0);
                if (expr_3C == 0)
                {
                    goto Block_2;
                }
            }
        Block_1:
            RotateFlipType result = RotateFlipType.RotateNoneFlipNone;
            if (2 != 0)
            {
                return result;
            }
            goto IL_56;
        Block_2:
            result = (RotateFlipType)expr_3C;
            return result;
        Block_3:
            result = (RotateFlipType)expr_47;
            return result;
        IL_4E:
            result = RotateFlipType.Rotate180FlipNone;
            return result;
        IL_53:
            result = RotateFlipType.Rotate180FlipX;
        IL_56:
            return result;
        IL_58:
            if (!false)
            {
                RotateFlipType expr_5B = RotateFlipType.Rotate90FlipX;
                if (!false)
                {
                    result = expr_5B;
                }
                return result;
            }
            return result;
        IL_62:
            result = RotateFlipType.Rotate90FlipNone;
            return result;
        Block_5:
            result = expr_67;
            return result;
        IL_70:
            result = RotateFlipType.Rotate270FlipNone;
            return result;
        }

        private SemiOrderSettings GetSemiOrderSettings(int substoreId, int locationId)
        {
            SemiOrderSettings result;
            try
            {
                SemiOrderSettings semiOrderSettings = LoginUser.ListSemiOrderSettingsSubStoreWise.Where(delegate(SemiOrderSettings x)
                {
                    int? dG_LocationId = x.PS_LocationId;
                    int arg_55_0;
                    while (true)
                    {
                        int arg_41_0 = locationId;
                        while (true)
                        {
                        IL_0D:
                            int num = arg_41_0;
                            while (!false)
                            {
                                if (dG_LocationId.GetValueOrDefault() == num)
                                {
                                    arg_55_0 = (arg_41_0 = (dG_LocationId.HasValue ? 1 : 0));
                                    if (!false)
                                    {
                                    }
                                }
                                else
                                {
                                    if (false)
                                    {
                                        continue;
                                    }
                                    arg_55_0 = (arg_41_0 = 0);
                                }
                                if (!false)
                                {
                                    return arg_55_0 != 0;
                                }
                                goto IL_0D;
                            }
                            break;
                        }
                    }
                    return arg_55_0 != 0;
                }).FirstOrDefault<SemiOrderSettings>();
                if (!false)
                {
                    result = semiOrderSettings;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                if (6 != 0)
                {
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    result = new SemiOrderSettings();
                }
            }
            return result;
        }

        private double GetActualCropRatio(double m)
        {
            bool arg_83_0;
            bool arg_DB_0;
            if (m < 0.68)
            {
                bool expr_1F = arg_83_0 = (m > 0.64);
                if (false)
                {
                    goto IL_83;
                }
                arg_DB_0 = !expr_1F;
            }
            else
            {
                arg_DB_0 = true;
            }
            bool flag = arg_DB_0;
        IL_30:
            bool expr_E1 = arg_83_0 = flag;
            double arg_CE_0;
            double arg_C1_0;
            if (!false)
            {
                if (!expr_E1)
                {
                    m = 0.6667;
                    goto IL_C3;
                }
                bool arg_FA_0;
                if (m < 0.76)
                {
                    double expr_F4 = arg_C1_0 = (arg_CE_0 = m);
                    if (false)
                    {
                        goto IL_BE;
                    }
                    arg_FA_0 = (expr_F4 <= 0.74);
                }
                else
                {
                    if (4 == 0)
                    {
                        goto IL_7E;
                    }
                    arg_FA_0 = true;
                }
                if (-1 != 0)
                {
                    flag = arg_FA_0;
                }
            IL_7E:
                arg_83_0 = flag;
            }
        IL_83:
            if (!arg_83_0)
            {
                m = 0.75;
                goto IL_C3;
            }
            flag = (m >= 0.81 || m <= 0.79);
            if (flag)
            {
                goto IL_C3;
            }
            arg_CE_0 = (arg_C1_0 = 0.8);
        IL_BE:
            if (!true)
            {
                return arg_CE_0;
            }
            m = arg_C1_0;
        IL_C3:
            double num = m;
            if (4 == 0)
            {
                goto IL_30;
            }
            arg_CE_0 = num;
            return arg_CE_0;
        }

        public BitmapImage GetBitmapImageFromPath(string value)
        {
            BitmapImage bitmapImage = new BitmapImage();
            BitmapImage result;
            try
            {
                if (value != null)
                {
                    if (!false)
                    {
                        using (FileStream fileStream = File.OpenRead(value))
                        {
                            MemoryStream memoryStream;
                            do
                            {
                                memoryStream = new MemoryStream();
                                fileStream.CopyTo(memoryStream);
                                if (-1 == 0)
                                {
                                    goto IL_6E;
                                }
                                memoryStream.Seek(0L, SeekOrigin.Begin);
                                fileStream.Close();
                                bitmapImage.BeginInit();
                            }
                            while (7 == 0);
                            bitmapImage.StreamSource = memoryStream;
                            if (!false)
                            {
                                bitmapImage.EndInit();
                            }
                        IL_6E:
                            if (5 != 0)
                            {
                            }
                        }
                    }
                }
                else if (!false)
                {
                    bitmapImage = new BitmapImage();
                }
                result = bitmapImage;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                result = bitmapImage;
            }
            return result;
        }

        public void SaveXml(string bvalue, bool childnode, string rfid, string cvalue, string fvalue, string fvvalue, string BG, string glayer, int photoId, string ZoomDetails, bool isCropActive, int ProductId, string filedatepath)
        {
            XmlDocument expr_374 = new XmlDocument();
            XmlDocument xmlDocument;
            if (5 != 0)
            {
                xmlDocument = expr_374;
            }
            xmlDocument.LoadXml(this.DefaultEffects);
            if (!childnode)
            {
                XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//image");
                foreach (XmlElement xmlElement in xmlNodeList)
                {
                    xmlElement.SetAttribute("brightness", bvalue);
                }
                foreach (XmlElement xmlElement in xmlNodeList)
                {
                    xmlElement.SetAttribute("contrast", cvalue);
                }
                if (isCropActive)
                {
                    foreach (XmlElement xmlElement in xmlNodeList)
                    {
                        if (ProductId == 1)
                        {
                            xmlElement.SetAttribute("Crop", "6 * 8");
                        }
                        else if (ProductId == 2 || ProductId == 3)
                        {
                            xmlElement.SetAttribute("Crop", "8 * 10");
                        }
                        else if (ProductId == 30 || ProductId == 5)
                        {
                            xmlElement.SetAttribute("Crop", "4 * 6");
                        }
                        else if (ProductId == 98)
                        {
                            xmlElement.SetAttribute("Crop", "3 * 3");
                        }
                    }
                }
                BitmapImage bitmapImageFromPath = this.GetBitmapImageFromPath(Path.Combine(filedatepath, new PhotoBusiness().GetFileNameByPhotoID(Convert.ToString(photoId))));
                string text;
                if (bitmapImageFromPath.Height > bitmapImageFromPath.Width)
                {
                    if (!string.IsNullOrWhiteSpace(fvvalue))
                    {
                        BitmapImage bitmapImageFromPath2 = this.GetBitmapImageFromPath(this._BorderFolder + fvvalue);
                    }
                    text = fvvalue;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(fvalue))
                    {
                        BitmapImage bitmapImageFromPath2 = this.GetBitmapImageFromPath(this._BorderFolder + fvalue);
                    }
                    text = fvalue;
                }
                string[] array = ZoomDetails.Split(new char[]
				{
					','
				});
                string value = string.Concat(new string[]
				{
					"<photo zoomfactor='",
					array[0],
					"' border='",
					text,
					"' bg= '",
					BG,
					"' canvasleft='",
					array[1],
					"' canvastop='",
					array[2],
					"' scalecentrex='",
					array[3],
					"' scalecentrey='",
					array[4],
					"'>",
					glayer,
					"</photo>"
				});
                new PhotoBusiness().UpdateLayering(photoId, value);
            }
            this.DefaultEffects = xmlDocument.InnerXml;
            new PhotoBusiness().SetEffectsonPhoto(this.DefaultEffects, photoId, false);
        }

        private bool IsCodeType(int PhotoId)
        {
            return new PhotoBusiness().CheckIsCodeType(PhotoId);
        }

        private void ResizeWPFImageWithoutRotation(string sourceImage, int maxHeight, string saveToPath)
        {
            try
            {
                BitmapImage expr_1D8 = new BitmapImage();
                BitmapImage bitmapImage;
                if (true)
                {
                    bitmapImage = expr_1D8;
                }
                BitmapImage bitmapImage2 = new BitmapImage();
                using (FileStream fileStream = File.OpenRead(sourceImage))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    fileStream.CopyTo(memoryStream);
                    memoryStream.Seek(0L, SeekOrigin.Begin);
                    int decodePixelWidth;
                    int decodePixelHeight;
                    while (true)
                    {
                        fileStream.Close();
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = memoryStream;
                        decimal d;
                        int arg_F0_0;
                        int expr_BE;
                        while (true)
                        {
                            bitmapImage.EndInit();
                            bitmapImage.Freeze();
                            int arg_69_0 = 0;
                            while (true)
                            {
                                d = new decimal(arg_69_0);
                                if ((arg_F0_0 = 0) != 0)
                                {
                                    goto IL_F0;
                                }
                                if (bitmapImage.Width < bitmapImage.Height)
                                {
                                    break;
                                }
                                d = Convert.ToDecimal(bitmapImage.Width) / Convert.ToDecimal(bitmapImage.Height);
                                decodePixelWidth = maxHeight;
                                expr_BE = (arg_69_0 = Convert.ToInt32(maxHeight / d));
                                if (!false)
                                {
                                    goto Block_6;
                                }
                            }
                            if (!false)
                            {
                                goto Block_7;
                            }
                        }
                    IL_107:
                        memoryStream.Seek(0L, SeekOrigin.Begin);
                        if (!false)
                        {
                            break;
                        }
                        continue;
                    Block_6:
                        decodePixelHeight = expr_BE;
                        goto IL_107;
                    IL_F0:
                        decodePixelHeight = arg_F0_0;
                        decodePixelWidth = Convert.ToInt32(maxHeight / d);
                        goto IL_107;
                    Block_7:
                        d = Convert.ToDecimal(bitmapImage.Height) / Convert.ToDecimal(bitmapImage.Width);
                        arg_F0_0 = maxHeight;
                        goto IL_F0;
                    }
                    do
                    {
                        bitmapImage2.BeginInit();
                        bitmapImage2.StreamSource = memoryStream;
                        bitmapImage2.DecodePixelWidth = decodePixelWidth;
                        bitmapImage2.DecodePixelHeight = decodePixelHeight;
                        bitmapImage2.EndInit();
                        bitmapImage2.Freeze();
                    }
                    while (8 == 0);
                    fileStream.Close();
                }
                FileStream fileStream2 = new FileStream(saveToPath, FileMode.Create, FileAccess.ReadWrite);
                try
                {
                    JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
                    jpegBitmapEncoder.QualityLevel = 94;
                    jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapImage2));
                    if (!false)
                    {
                        jpegBitmapEncoder.Save(fileStream2);
                    }
                    fileStream2.Close();
                }
                finally
                {
                    if (8 == 0 || fileStream2 != null)
                    {
                        ((IDisposable)fileStream2).Dispose();
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void ApplySettings(string photonameOld, string photonameNew, int photoId, int substoreId, int locationId, string dateFolderPath)
        {
            ContrastAdjustEffect contrastAdjustEffect = new ContrastAdjustEffect();
            new ContrastAdjustEffect();
            MonochromeEffect monochromeEffect = new MonochromeEffect();
            this.Directoryname = LoginUser.DigiFolderPath;
            try
            {
                if (this.is_SemiOrder)
                {
                    SemiOrderSettings semiOrderSettings = LoginUser.ListSemiOrderSettingsSubStoreWise.Where(delegate(SemiOrderSettings x)
                    {
                        int? dG_LocationId = x.PS_LocationId;
                        int arg_55_0;
                        while (true)
                        {
                            int arg_41_0 = locationId;
                            while (true)
                            {
                            IL_0D:
                                int num9 = arg_41_0;
                                while (!false)
                                {
                                    if (dG_LocationId.GetValueOrDefault() == num9)
                                    {
                                        arg_55_0 = (arg_41_0 = (dG_LocationId.HasValue ? 1 : 0));
                                        if (!false)
                                        {
                                        }
                                    }
                                    else
                                    {
                                        if (false)
                                        {
                                            continue;
                                        }
                                        arg_55_0 = (arg_41_0 = 0);
                                    }
                                    if (!false)
                                    {
                                        return arg_55_0 != 0;
                                    }
                                    goto IL_0D;
                                }
                                break;
                            }
                        }
                        return arg_55_0 != 0;
                    }).FirstOrDefault<SemiOrderSettings>();
                    bool arg_7F3_0;
                    if (semiOrderSettings != null)
                    {
                        if (semiOrderSettings.PS_SemiOrder_Settings_AutoBright == true)
                        {
                            contrastAdjustEffect.Brightness = semiOrderSettings.PS_SemiOrder_Settings_AutoBright_Value.Value;
                        }
                        else
                        {
                            semiOrderSettings.PS_SemiOrder_Settings_AutoBright_Value = new double?(Convert.ToDouble(this.defaultBrightness));
                        }
                    IL_CA:
                        bool? flag = semiOrderSettings.PS_SemiOrder_Settings_AutoContrast;
                        int arg_10A_0;
                        if (flag.GetValueOrDefault())
                        {
                            if (false)
                            {
                                goto IL_8A0;
                            }
                            arg_10A_0 = (flag.HasValue ? 1 : 0);
                        }
                        else
                        {
                            arg_10A_0 = 0;
                        }
                        if (arg_10A_0 != 0)
                        {
                            contrastAdjustEffect.Contrast = semiOrderSettings.PS_SemiOrder_Settings_AutoContrast_Value.Value;
                        }
                        else
                        {
                            semiOrderSettings.PS_SemiOrder_Settings_AutoContrast_Value = new double?(Convert.ToDouble(this.defaultContrast));
                        }
                        double num = 0;
                        string[] array=null;
                        while (true)
                        {
                            flag = semiOrderSettings.PS_SemiOrder_IsCropActive;
                            int arg_169_0;
                            int arg_1EE_0 = (!flag.GetValueOrDefault()) ? (arg_169_0 = 0) : (arg_169_0 = (flag.HasValue ? 1 : 0));
                            int arg_1EE_1;
                            int expr_163 = arg_1EE_1 = 0;
                            if (expr_163 != 0)
                            {
                                goto IL_1EE;
                            }
                            if (arg_169_0 == expr_163)
                            {
                                goto IL_50B;
                            }
                            Uri uriSource = new Uri(Path.Combine(dateFolderPath, photonameNew));
                            BitmapSource bitmapSource = new BitmapImage(uriSource);
                             num = (double)bitmapSource.PixelWidth / bitmapSource.Width;
                          
                            if (bitmapSource.Width > bitmapSource.Height)
                            {
                                array = semiOrderSettings.HorizontalCropValues.Split(new char[]
								{
									','
								});
                                arg_1EE_0 = ((Convert.ToDouble(array[2]) > Convert.ToDouble(array[3])) ? 1 : 0);
                                arg_1EE_1 = 0;
                                goto IL_1EE;
                            }
                            if (8 == 0)
                            {
                                goto IL_CA;
                            }
                            array = semiOrderSettings.VerticalCropValues.Split(new char[]
							{
								','
							});
                            double arg_23B_0;
                            double expr_2EA = arg_23B_0 = Convert.ToDouble(array[2]);
                            double arg_23B_1;
                            double expr_2F3 = arg_23B_1 = Convert.ToDouble(array[3]);
                            if (5 == 0)
                            {
                                goto IL_23B;
                            }
                            double num2;
                            if (expr_2EA > expr_2F3)
                            {
                                num2 = Convert.ToDouble(array[3]) / Convert.ToDouble(array[2]);
                            }
                            else
                            {
                                num2 = Convert.ToDouble(array[2]) / Convert.ToDouble(array[3]);
                            }
                            double arg_378_0;
                            double expr_335 = arg_378_0 = num;
                            double num3;
                            double num4;
                            double num5;
                            double num6;
                            if (!false)
                            {
                                num3 = expr_335 * Convert.ToDouble(array[0]);
                                num4 = num * Convert.ToDouble(array[1]);
                                num5 = num * Convert.ToDouble(array[2]);
                                num6 = num * Convert.ToDouble(array[3]);
                                arg_378_0 = this.GetActualCropRatio(num2);
                            }
                            num2 = arg_378_0;
                            double arg_3A4_0;
                            if ((double)bitmapSource.PixelWidth < num3 + num5)
                            {
                                num5 = (double)bitmapSource.PixelWidth - num3;
                                arg_3A4_0 = num6;
                                goto IL_3A2;
                            }
                        IL_3C1:
                            num5 = Math.Round(num5, 0);
                            num6 = Math.Round(num6, 0);
                            CroppedBitmap source = new CroppedBitmap(bitmapSource, new Int32Rect(Convert.ToInt32(num3), Convert.ToInt32(num4), Convert.ToInt32(num5), Convert.ToInt32(num6)));
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                new JpegBitmapEncoder
                                {
                                    Frames = 
									{
										BitmapFrame.Create(source)
									},
                                    QualityLevel = 50
                                }.Save(memoryStream);
                                System.Drawing.Image original = System.Drawing.Image.FromStream(memoryStream);
                                Bitmap bitmap = new Bitmap(original);
                                bitmap.SetResolution(300f, 300f);
                                bitmap.Save(LoginUser.DigiFolderCropedPath + photonameNew);
                                try
                                {
                                    IntPtr hbitmap = bitmap.GetHbitmap();
                                    AcquiredFrames.DeleteObject(hbitmap);
                                    bitmap.Dispose();
                                }
                                catch
                                {
                                }
                            }
                            if (2 != 0)
                            {
                                break;
                            }
                            continue;
                        IL_23B:
                            num4 = arg_23B_0 * arg_23B_1;
                            num5 = num * Convert.ToDouble(array[2]);
                            num6 = num * Convert.ToDouble(array[3]);
                            double num7 = this.GetActualCropRatio(num7);
                             uriSource = new Uri(Path.Combine(dateFolderPath, photonameNew));
                            bitmapSource = new BitmapImage(uriSource);
                            if ((double)bitmapSource.PixelHeight < num4 + num6)
                            {
                                double expr_284 = arg_3A4_0 = (double)bitmapSource.PixelHeight;
                                if (8 == 0)
                                {
                                    goto IL_3A2;
                                }
                                num6 = (double)Convert.ToInt32(expr_284 - num4);
                                bool flag2 = num6 <= num5;
                                bool expr_2A1 = arg_7F3_0 = flag2;
                                if (false)
                                {
                                    goto IL_7F2;
                                }
                                if (!expr_2A1)
                                {
                                    num5 = num7 * num6;
                                }
                                else
                                {
                                    num5 = num6 / num7;
                                }
                            }
                            goto IL_3C1;
                        IL_1EE:
                            if (arg_1EE_0 != arg_1EE_1)
                            {
                                //string[] array;
                                num7 = Convert.ToDouble(array[3]) / Convert.ToDouble(array[2]);
                            }
                            else
                            {
                                num7 = Convert.ToDouble(array[2]) / Convert.ToDouble(array[3]);
                            }
                            num3 = num * Convert.ToDouble(array[0]);
                            arg_23B_0 = num;
                            arg_23B_1 = Convert.ToDouble(array[1]);
                            goto IL_23B;
                        IL_3C0:
                            goto IL_3C1;
                        IL_3A2:
                            if (arg_3A4_0 > num5)
                            {
                                num5 = num2 * num6;
                            }
                            else
                            {
                                num5 = num6 / num2;
                            }
                            goto IL_3C0;
                        }
                        this.ResizeWPFImageWithoutRotation(LoginUser.DigiFolderCropedPath + photonameNew, 250, LoginUser.DigiFolderThumbnailPath + photonameNew);
                        this.ResizeWPFImageWithoutRotation(LoginUser.DigiFolderCropedPath + photonameNew, 900, LoginUser.DigiFolderBigThumbnailPath + photonameNew);
                        new PhotoBusiness().SaveIsCropedPhotos((long)photoId, true, "Crop");
                    IL_50B:
                        if (semiOrderSettings.PS_SemiOrder_Settings_ImageFrame != null)
                        {
                            if (semiOrderSettings.PS_SemiOrder_Settings_ImageFrame.Trim() != string.Empty)
                            {
                                while (false)
                                {
                                }
                                string text;
                                if (AcquiredFrames.isrotated)
                                {
                                    text = this._BorderFolder + "\\" + semiOrderSettings.PS_SemiOrder_Settings_ImageFrame_Vertical;
                                }
                                else
                                {
                                    text = this._BorderFolder + "\\" + semiOrderSettings.PS_SemiOrder_Settings_ImageFrame;
                                }
                                BitmapImage bitmapImage = new BitmapImage();
                                using (FileStream fileStream = File.OpenRead(text))
                                {
                                    MemoryStream memoryStream2 = new MemoryStream();
                                    fileStream.CopyTo(memoryStream2);
                                    memoryStream2.Seek(0L, SeekOrigin.Begin);
                                    fileStream.Close();
                                    bitmapImage.BeginInit();
                                    bitmapImage.StreamSource = memoryStream2;
                                    bitmapImage.EndInit();
                                    bitmapImage.Freeze();
                                }
                                if (semiOrderSettings.PS_SemiOrder_Settings_IsImageBG.Value)
                                {
                                    this.SaveXml(Convert.ToString(semiOrderSettings.PS_SemiOrder_Settings_AutoBright_Value), false, photonameOld, Convert.ToString(semiOrderSettings.PS_SemiOrder_Settings_AutoContrast_Value), Convert.ToString(semiOrderSettings.PS_SemiOrder_Settings_ImageFrame), semiOrderSettings.PS_SemiOrder_Settings_ImageFrame_Vertical, semiOrderSettings.PS_SemiOrder_BG, semiOrderSettings.PS_SemiOrder_Graphics_layer, photoId, semiOrderSettings.PS_SemiOrder_Image_ZoomInfo, semiOrderSettings.PS_SemiOrder_IsCropActive.Value, Convert.ToInt32(semiOrderSettings.PS_SemiOrder_ProductTypeId), dateFolderPath);
                                }
                                else
                                {
                                    this.SaveXml(Convert.ToString(semiOrderSettings.PS_SemiOrder_Settings_AutoBright_Value), false, photonameOld, Convert.ToString(semiOrderSettings.PS_SemiOrder_Settings_AutoContrast_Value), Convert.ToString(semiOrderSettings.PS_SemiOrder_Settings_ImageFrame), semiOrderSettings.PS_SemiOrder_Settings_ImageFrame_Vertical, string.Empty, semiOrderSettings.PS_SemiOrder_Graphics_layer, photoId, semiOrderSettings.PS_SemiOrder_Image_ZoomInfo, semiOrderSettings.PS_SemiOrder_IsCropActive.Value, Convert.ToInt32(semiOrderSettings.PS_SemiOrder_ProductTypeId), dateFolderPath);
                                }
                            }
                            else if (semiOrderSettings.PS_SemiOrder_Settings_IsImageBG.Value)
                            {
                                this.SaveXml(Convert.ToString(semiOrderSettings.PS_SemiOrder_Settings_AutoBright_Value), false, photonameOld, Convert.ToString(semiOrderSettings.PS_SemiOrder_Settings_AutoContrast_Value), Convert.ToString(semiOrderSettings.PS_SemiOrder_Settings_ImageFrame), semiOrderSettings.PS_SemiOrder_Settings_ImageFrame_Vertical, semiOrderSettings.PS_SemiOrder_BG, semiOrderSettings.PS_SemiOrder_Graphics_layer, photoId, semiOrderSettings.PS_SemiOrder_Image_ZoomInfo, semiOrderSettings.PS_SemiOrder_IsCropActive.Value, Convert.ToInt32(semiOrderSettings.PS_SemiOrder_ProductTypeId), dateFolderPath);
                            }
                            else
                            {
                                this.SaveXml(Convert.ToString(semiOrderSettings.PS_SemiOrder_Settings_AutoBright_Value), false, photonameOld, Convert.ToString(semiOrderSettings.PS_SemiOrder_Settings_AutoContrast_Value), Convert.ToString(semiOrderSettings.PS_SemiOrder_Settings_ImageFrame), semiOrderSettings.PS_SemiOrder_Settings_ImageFrame_Vertical, string.Empty, semiOrderSettings.PS_SemiOrder_Graphics_layer, photoId, semiOrderSettings.PS_SemiOrder_Image_ZoomInfo, semiOrderSettings.PS_SemiOrder_IsCropActive.Value, Convert.ToInt32(semiOrderSettings.PS_SemiOrder_ProductTypeId), dateFolderPath);
                            }
                        }
                        goto IL_7E5;
                    }
                    goto IL_7E5;
                IL_8A0:
                    int i;
                    string[] array2;
                    while (i < array2.Length)
                    {
                        string productTypeId = array2[i];
                        int num8 = new OrderBusiness().SetOrderDetails(new int?(photoId), productTypeId, new LocationBusniess().GetSubStoreIdbyLocationId(locationId), string.Empty);
                        i++;
                    }
                    goto IL_8AF;
                IL_7E5:
                    arg_7F3_0 = (semiOrderSettings == null || this.IsCodeType(photoId));
                IL_7F2:
                    if (!arg_7F3_0)
                    {
                        if (this.is_SemiOrder && semiOrderSettings.PS_SemiOrder_Environment == false && semiOrderSettings.PS_SemiOrder_IsPrintActive.Value)
                        {
                            string[] array3 = semiOrderSettings.PS_SemiOrder_ProductTypeId.Split(new char[]
							{
								','
							});
                            array2 = array3;
                            i = 0;
                            goto IL_8A0;
                        }
                    }
                IL_8AF: ;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
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
        //            Uri resourceLocator = new Uri("/DigiPhoto;component/usercontrol/acquiredframes.xaml", UriKind.Relative);
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
        //            this.UserControl = (AcquiredFrames)target;
        //            break;
        //        case 2:
        //            this.LayoutRoot = (Grid)target;
        //            break;
        //        case 3:
        //            this.MainPanel = (Grid)target;
        //            break;
        //        case 4:
        //            this.vb1 = (Viewbox)target;
        //            break;
        //        case 5:
        //            this.bg_withlogo = (StackPanel)target;
        //            break;
        //        case 6:
        //            this.bg = (System.Windows.Controls.Image)target;
        //            break;
        //        case 7:
        //            this.CmbPhotographerNo = (ComboBox)target;
        //            this.CmbPhotographerNo.SelectionChanged += new SelectionChangedEventHandler(this.CmbPhotographerNo_SelectionChanged);
        //            break;
        //        case 8:
        //            this.tbStartingNo = (TextBox)target;
        //            break;
        //        case 9:
        //            this.CmbLocation = (ComboBox)target;
        //            break;
        //        case 10:
        //            this.Lastimageno = (TextBlock)target;
        //            break;
        //        case 11:
        //            this.DownloadProgress = (ProgressBar)target;
        //            break;
        //        case 12:
        //            this.btnDownload = (Button)target;
        //            this.btnDownload.Click += new RoutedEventHandler(this.btnDownload_Click);
        //            break;
        //        case 13:
        //            this.btnBack = (Button)target;
        //            this.btnBack.Click += new RoutedEventHandler(this.btnBack_Click);
        //            break;
        //        default:
        //            this._contentLoaded = true;
        //            break;
        //    }
        //}

        static AcquiredFrames()
        {
            // Note: this type is marked as 'beforefieldinit'.
            while (true)
            {
                AcquiredFrames.count = 0;
                AcquiredFrames.ProcessedCount = 0;
                AcquiredFrames.htVideosToProcess = new Hashtable();
                while (!false)
                {
                    AcquiredFrames.videoCount = 0;
                    do
                    {
                        AcquiredFrames.ProcessedvideoCount = 0;
                    }
                    while (false);
                    AcquiredFrames.videothreadCount = 0;
                    if (8 != 0)
                    {
                        if (!false)
                        {
                            return;
                        }
                        break;
                    }
                }
            }
        }
    }
}
