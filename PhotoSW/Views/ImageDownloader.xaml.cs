using PhotoSW.Common;
using DigiPhoto.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using ExifLib;
using FrameworkHelper;
using FrameworkHelper.Common;
//using ImageMagickObject;
using LevDan.Exif;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;
using DigiPhoto;
using PhotoSW.PSControls;
using PhotoSW.CF.DataLayer.BAL;
using PhotoSW.DataLayer;

namespace PhotoSW.Views
{
    public partial class ImageDownloader : Window, IComponentConnector, IStyleConnector
    {
        private const string fileExtension = ".jpg";

        private int _selectStartIndex = -1;

        private int _selectEndIndex = -1;

        private string[] mediaExtensions = new string[]
		{
			".jpg",
			".avi",
			".mp4",
			".wmv",
			".mov",
			".3gp",
			".3g2",
			".m2v",
			".m4v",
			".flv",
			".mpeg",
			".ffmpeg",
			".mkv",
			".mts"
		};

        private bool processVideos;

        private string filepath;

        private List<string> ImageName;

        private static int count = 0;

        private static int ProcessedCount = 0;

        private string _filePath;

        private string _path = string.Empty;

        private string _thumbnailsPath = string.Empty;

        private Stopwatch _stopwatch = new Stopwatch();

        private bool _isBarcodeActive = false;

        private bool _isUsbDelete = false;

        private bool _show = false;

        private Dictionary<string, DownloadFileInfo> _img = new Dictionary<string, DownloadFileInfo>();

        private BackgroundWorker _manualDownloadWorker = new BackgroundWorker();

        private BusyWindow _busyWindows = new BusyWindow();

        private readonly DispatcherTimer plyTimer = new DispatcherTimer();

        private bool userIsDraggingSlider = false;

        private bool mediaPlayerIsPlaying = false;

        private bool CheckBoxState = true;

        private string selectedImage = string.Empty;

        private BackgroundWorker ManualDownloadworker = new BackgroundWorker();

        private BusyWindow bs = new BusyWindow();

        private FileStream memoryFileStream;

        private static string vsMediaFileName = "";

        private bool isMuted = false;

        private Hashtable htFileSize = new Hashtable();

        private bool isVideoEditingEnabled = false;

        private MLMediaPlayer mplayer;

        private bool imgType = false;

        private BitmapImage _bitMapImage;

        private string ImageEffect = string.Empty;

        private string ProductNamePreference = string.Empty;

        private List<SemiOrderSettings> lstDG_SemiOrder_Settings = new List<SemiOrderSettings>();

        private string hotFolderPath = string.Empty;

        private string dateFolder = string.Empty;

        private string cropFolderPath = string.Empty;

        private bool IsSpecActiveForSubstore = false;

        private List<ConfigurationInfo> lstConfig = null;
       // private List<baConfigurationInfo> lstConfig = null;

        private string originalDirectoryPath = string.Empty;

        private string binpath = string.Empty;

        private string DateFolder = string.Empty;

        private bool? _IsAutoRotate = new bool?(false);

        private int _needRotation = 0;

        private ConfigurationInfo _configInfo = null;

        public bool isImageAcquired = false;

        public Hashtable htVidLength = new Hashtable();

        public bool IsEnabledSessionSelect = false;

        public bool IsEnabledSelectEndPoint = false;

        public bool _isEnabledImageEditingMDownload = false;

        public string defaultContrast = "1";

        public string defaultBrightness = "0";

        //internal Grid grdupscroll;

        //internal Button btnWithPreviewActive;

        //internal System.Windows.Controls.Image imgwithPreview;

        //internal Button btnWithoutPreview;

        //internal System.Windows.Controls.Image imgwithoutPreview;

        //internal Canvas SPSelectAll;

        //internal CheckBox chkSelectAll;

        //internal TextBlock txbSelectedImages;

        //internal TextBlock txbCount;

        //internal Grid thumbPreview1;

        //internal Grid thumbPreview;

        //internal ListBox lstImages;

        //internal Grid IMGFrame;

        //internal System.Windows.Controls.Image imgmain;

        //internal Grid vidoriginal;

        //internal Grid gdMediaPlayer;

        //internal Label timer;

        //internal Button btnacquire;

        //internal Button btnOpenEditControl;

        //internal Button btnBack;

        //internal ManualDownload ManualCtrl;

        //internal EditingControl ucEditing;

        // private bool _contentLoaded;

        public string FolderParth = String.Empty; 

        public ObservableCollection<MyImageClass> MyImages
        {
            get;
            set;
        }

        public ObservableCollection<MyImageClass> UpdatedSelectedList
        {
            get;
            set;
        }

        public ImageDownloader()
        {
            this.InitializeComponent();
            this.GetConfigurationInfo();
            this.lstImages.Items.Clear();
            this.lstConfig = GetConfigurationData(baConfigurationInfo.GetConfigurationData()); ///new ConfigBusiness().GetConfigurationData();
            //ConfigurationInfo configurationInfo = (from x in this.lstConfig
            //                                       where x.DG_Substore_Id == LoginUser.SubStoreId
            //                                       select x).FirstOrDefault<ConfigurationInfo>();
            //this.lstConfig = 
            baConfigurationInfo configurationInfo = baConfigurationInfo.GetConfigurationData(LoginUser.SubStoreId);

            this._filePath = configurationInfo.PS_Hot_Folder_Path;
            this._path = Environment.CurrentDirectory + "\\";
            this._path = Path.Combine(this._path, "Download\\");
            this._thumbnailsPath = Path.Combine(this._path, "Temp\\");
            if (Directory.Exists(this._path))
            {
                this.DeletePath(this._path);
            }
            //this.CreateImages();
            this._manualDownloadWorker.DoWork += new DoWorkEventHandler(this.ManualDownloadworker_DoWork);
            this._manualDownloadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.ManualDownloadworker_RunWorkerCompleted);
            if (_manualDownloadWorker.IsBusy != true)
            {
                _manualDownloadWorker.RunWorkerAsync();
            }
            if (this.CheckDriveForImages())
            {
                this._show = true;
            }
            else
            {
                this.Close();
                Home home = new Home();
                home.Show();
            }
            this.btnacquire.IsDefault = true;
            this.hotFolderPath = AppDomain.CurrentDomain.BaseDirectory;
            this.dateFolder = DateTime.Now.ToString("yyyyMMdd");
            this.cropFolderPath = Path.Combine(this.hotFolderPath, this.dateFolder, "Croped");
            if (!Directory.Exists(this.cropFolderPath))
            {
                Directory.CreateDirectory(this.cropFolderPath);
            }
            this.mplayer = new MLMediaPlayer(ImageDownloader.vsMediaFileName, "ImageDownloader");
        }


        public ImageDownloader(string desktop)
        {
            this.InitializeComponent();
            this.GetConfigurationInfo();
            this.lstImages.Items.Clear();
            this.lstConfig = GetConfigurationData(baConfigurationInfo.GetConfigurationData()); ///new ConfigBusiness().GetConfigurationData();
            //ConfigurationInfo configurationInfo = (from x in this.lstConfig
            //                                       where x.DG_Substore_Id == LoginUser.SubStoreId
            //                                       select x).FirstOrDefault<ConfigurationInfo>();
            //this.lstConfig = 
            baConfigurationInfo configurationInfo = baConfigurationInfo.GetConfigurationData(LoginUser.SubStoreId);

            this._filePath = configurationInfo.PS_Hot_Folder_Path;
            this._path = Environment.CurrentDirectory + "\\";
            this._path = Path.Combine(this._path, "Download\\");
            this._thumbnailsPath = Path.Combine(this._path, "Temp\\");
            if (Directory.Exists(this._path))
            {
                this.DeletePath(this._path);
            }

            using (var fbd = new System.Windows.Forms.FolderBrowserDialog())
            {
                System.Windows.Forms.DialogResult result = fbd.ShowDialog();

                if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    FolderParth = fbd.SelectedPath;
                }
            }

          //  this.CreateImagesForDesktop();
            this._manualDownloadWorker.DoWork += new DoWorkEventHandler(this.ManualDownloadworker_DoWork);
            this._manualDownloadWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.ManualDownloadworker_RunWorkerCompleted);
            if (_manualDownloadWorker.IsBusy != true)
            {
                _manualDownloadWorker.RunWorkerAsync();
            }
            if (this.CheckDesktopForImages())
            {
                this._show = true;
            }
            else
            {
                this.Close();
                Home home = new Home();
                home.Show();
            }
            this.btnacquire.IsDefault = true;
            this.hotFolderPath = AppDomain.CurrentDomain.BaseDirectory;
            this.dateFolder = DateTime.Now.ToString("yyyyMMdd");
            this.cropFolderPath = Path.Combine(this.hotFolderPath, this.dateFolder, "Croped");
            if (!Directory.Exists(this.cropFolderPath))
            {
                Directory.CreateDirectory(this.cropFolderPath);
            }
            this.mplayer = new MLMediaPlayer(ImageDownloader.vsMediaFileName, "ImageDownloader");
        }

        private void ShowImages()
        {
            try
            {
                this.lstImages.Items.Clear();
                this.MyImages = new ObservableCollection<MyImageClass>();
                string baseDirectory;
                string str;
                if (8 != 0)
                {
                    this.MyImages.Clear();
                    baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    str = DateTime.Now.ToString("yyyyMMdd");
                    if (!this._isEnabledImageEditingMDownload)
                    {
                        this.btnOpenEditControl.Visibility = Visibility.Collapsed;
                        goto IL_FD;
                    }
                    bool flag = Directory.Exists(baseDirectory + str);
                    if (false)
                    {
                        goto IL_CE;
                    }
                    if (!flag)
                    {
                        Directory.CreateDirectory(baseDirectory + str);
                    }
                }
                if (!Directory.Exists(baseDirectory + str + "\\Thumbnails"))
                {
                    Directory.CreateDirectory(baseDirectory + str + "\\Thumbnails");
                }
                if (Directory.Exists(baseDirectory + str + "\\Temp"))
                {
                    goto IL_E0;
                }
            IL_CE:
                Directory.CreateDirectory(baseDirectory + str + "\\Temp");
            IL_E0:
                this.btnOpenEditControl.Visibility = Visibility.Visible;
            IL_EC:
            IL_FD:
                int num = 0;
                using (Dictionary<string, DownloadFileInfo>.Enumerator enumerator = this._img.GetEnumerator())
                {
                    while (true)
                    {
                        while (true)
                        {
                            bool arg_18B_0;
                            bool arg_17E_0;
                            bool expr_291 = arg_17E_0 = (arg_18B_0 = enumerator.MoveNext());
                            if (false)
                            {
                                goto IL_17B;
                            }
                            if (!expr_291)
                            {
                                goto Block_16;
                            }
                            KeyValuePair<string, DownloadFileInfo> current = enumerator.Current;
                            num++;
                            DownloadFileInfo value = current.Value;
                            string text = string.Empty;
                            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(value.fileName);
                            string text2 = fileNameWithoutExtension;
                            if (!value.isVideo)
                            {
                                text = value.filePath;
                                if (7 == 0)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                text = value.videoPath;
                                text2 = Path.GetFileNameWithoutExtension(text2);
                            }
                            arg_18B_0 = (arg_17E_0 = this._isEnabledImageEditingMDownload);
                            goto IL_17B;
                            break;
                            break;
                        IL_17B:
                            if (!false)
                            {
                                arg_18B_0 = (!arg_17E_0 || value.isVideo);
                            }
                            if (!arg_18B_0)
                            {
                                File.Copy(value.filePath + "\\" + value.fileName, baseDirectory + str + "\\" + value.fileName, true);
                                this.ResizeWPFImageThumbnails(value.filePath + "\\" + value.fileName, 1200, baseDirectory + str + "\\Thumbnails\\" + value.fileName);
                                text = baseDirectory + str;
                                if (7 != 0)
                                {
                                    this.MyImages.Add(new MyImageClass(text2, this.GetImageFromResourceString(fileNameWithoutExtension, text), false, value.CreatedDate, text + "\\Thumbnails\\" + value.fileName, value.fileExtension, null, null, SettingStatus.None, (long)num));
                                }
                            }
                            else
                            {
                                this.MyImages.Add(new MyImageClass(text2, this.GetImageFromResourceString(fileNameWithoutExtension, value.filePath), false, value.CreatedDate, text, value.fileExtension, null, null, SettingStatus.None, 0L));
                            }
                        }
                    }
                Block_16: ;
                }
                this.lstImages.ItemsSource = this.MyImages;
                if (false)
                {
                    goto IL_EC;
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
            if (true)
            {
            }
        }

        private bool CheckResetDPIRequired(int hr, int vr, string PhotographerId)
        {
            bool result;
            try
            {
                int arg_70_0;
                int arg_5E_0;
                int arg_1F_0;
                int arg_27_0 = arg_1F_0 = (arg_5E_0 = (arg_70_0 = (new CameraBusiness().GetIsResetDPIRequired(Convert.ToInt32(PhotographerId)) ? 1 : 0)));
                while (true)
                {
                    if (2 == 0)
                    {
                        goto IL_2F;
                    }
                    bool flag = arg_5E_0 != 0;
                    int arg_1F_1;
                    if (hr == 300)
                    {
                        arg_1F_0 = vr;
                        arg_1F_1 = 300;
                        goto IL_1F;
                    }
                    goto IL_21;
                IL_23:
                    int expr_24 = arg_1F_1 = 0;
                    if (expr_24 != 0)
                    {
                        goto IL_1F;
                    }
                    arg_27_0 = (arg_1F_0 = (arg_5E_0 = (arg_70_0 = ((arg_27_0 == expr_24) ? 1 : 0))));
                    if (!false)
                    {
                        goto IL_2F;
                    }
                    continue;
                IL_21:
                    arg_27_0 = (arg_1F_0 = (flag ? 1 : 0));
                    goto IL_23;
                IL_2F:
                    if (2 != 0)
                    {
                        break;
                    }
                    goto IL_23;
                IL_1F:
                    if (arg_1F_0 != arg_1F_1)
                    {
                        goto IL_21;
                    }
                    arg_27_0 = (arg_1F_0 = (arg_70_0 = 1));
                    goto IL_2F;
                }
                if (arg_70_0 == 0)
                {
                    result = true;
                }
                else
                {
                    result = false;
                }
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

        private void ResetImageDPI(string fileName)
        {
            try
            {
                string text = "'##'";
                string text2 = "'##'";
                FileInfo fileInfo = new FileInfo(fileName);
                ExifTagCollection expr_268 = new ExifTagCollection(fileInfo.FullName);
                ExifTagCollection exifTagCollection;
                if (true)
                {
                    exifTagCollection = expr_268;
                }
                foreach (ExifTag current in exifTagCollection)
                {
                    if (current.Id == 282)
                    {
                        text = "'" + exifTagCollection[282].Value + "'";
                    }
                    else if (current.Id == 283)
                    {
                        text2 = "'" + exifTagCollection[283].Value + "'";
                    }
                }
                text = text.Replace("'", "");
                text2 = text2.Replace("'", "");
                int num = 0;
                int num2 = 0;
                int arg_136_0;
                if (!text.Contains("##"))
                {
                    bool expr_127 = (arg_136_0 = (text2.Contains("##") ? 1 : 0)) != 0;
                    if (!false)
                    {
                        arg_136_0 = ((!expr_127) ? 1 : 0);
                    }
                }
                else
                {
                    arg_136_0 = 0;
                }
                BitmapImage bitmapImage;
                if (arg_136_0 == 0)
                {
                    bitmapImage = new BitmapImage();
                    using (FileStream fileStream = File.OpenRead(fileInfo.FullName))
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        do
                        {
                            fileStream.CopyTo(memoryStream);
                            if (4 != 0)
                            {
                                memoryStream.Seek(0L, SeekOrigin.Begin);
                                while (true)
                                {
                                    fileStream.Close();
                                    while (!false)
                                    {
                                        bitmapImage.BeginInit();
                                        bitmapImage.StreamSource = memoryStream;
                                        bitmapImage.EndInit();
                                        if (!false)
                                        {
                                            goto IL_19C;
                                        }
                                    }
                                }
                            }
                        IL_19C:
                            bitmapImage.Freeze();
                        }
                        while (2 == 0);
                    }
                    num = Convert.ToInt32(bitmapImage.DpiX);
                }
                else
                {
                    if (!int.TryParse(text, out num))
                    {
                        goto IL_1F0;
                    }
                    goto IL_1F4;
                }
            IL_1CD:
                num2 = Convert.ToInt32(bitmapImage.DpiY);
                if (6 != 0)
                {
                    goto IL_207;
                }
            IL_1F0:
                num = 72;
            IL_1F4:
                if (!int.TryParse(text2, out num2))
                {
                    num2 = 72;
                }
            IL_207:
                if (num != 300 || num2 != 300)
                {
                    this.ResetLowDPI(fileInfo.FullName);
                }
                if (7 == 0)
                {
                    goto IL_1CD;
                }
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ex.Message);
            }
        }

        private void ResetLowDPI(string FilePath)
        {
            try
            {
                string fileName = Path.GetFileName(FilePath);
                string directoryName = Path.GetDirectoryName(FilePath);
                string text = Path.Combine(directoryName, "Temp");
                if (!Directory.Exists(text))
                {
                    Directory.CreateDirectory(text);
                }
                File.Move(Path.Combine(directoryName, fileName), Path.Combine(text, fileName));
                System.Drawing.Image image = System.Drawing.Image.FromFile(Path.Combine(text, fileName));
                System.Drawing.Image image2 = ResetDPI.ScaleByHeightAndResolution(image, 2136, 300f);
                image2.Save(Path.Combine(directoryName, fileName));
                image.Dispose();
                image2.Dispose();
                File.Delete(Path.Combine(text, fileName));
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ex.Message);
            }
        }

        private void rotateImage(string rotatePath, int changed = 0)
        {
            try
            {
                this._configInfo = new ConfigBusiness().GetConfigurationData(LoginUser.SubStoreId);
                this._IsAutoRotate = this._configInfo.DG_IsAutoRotate;
                if (this._IsAutoRotate.Value)
                {
                    string text = "";
                    try
                    {
                        using (ExifReader exifReader = new ExifReader(rotatePath))
                        {
                            foreach (ushort tagID in Enum.GetValues(typeof(ExifTags)))
                            {
                                object obj;
                                if (exifReader.GetTagValue<object>(tagID, out obj))
                                {
                                    text = obj.ToString();
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(ex.Message);
                    }
                    if (!string.IsNullOrEmpty(text))
                    {
                        this._needRotation = this.GetRotationValue(text);
                        if (-1 == 0)
                        {
                            goto IL_32A;
                        }
                    }
                    else
                    {
                        this._needRotation = 0;
                    }
                }
                //MagickImage magickImage = (MagickImage)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid()));
                int arg_14B_0 = this._needRotation;
                int arg_14B_1 = 0;
                object[] array;
                object[] array2;
                while (arg_14B_0 > arg_14B_1)
                {
                    if (changed == 1)
                    {
                        int expr_173 = arg_14B_0 = ((this._needRotation == 90) ? 1 : 0);
                        int expr_176 = arg_14B_1 = 0;
                        if (expr_176 == 0)
                        {
                            if (expr_173 != expr_176)
                            {
                                array = new object[]
								{
									"-rotate",
									" -90 ",
									rotatePath
								};
                                array2 = array;
                                //IMagickImage arg_1AD_0 = magickImage;
                                //array = array2;
                                //arg_1AD_0.Mogrify(ref array);
                            }
                            else if (this._needRotation == 180)
                            {
                                array = new object[]
								{
									"-rotate",
									" -180 ",
									rotatePath
								};
                                array2 = array;
                                //IMagickImage arg_1FE_0 = magickImage;
                                //array = array2;
                                //arg_1FE_0.Mogrify(ref array);
                            }
                            else if (this._needRotation == 270)
                            {
                                array = new object[]
								{
									"-rotate",
									" -270 ",
									rotatePath
								};
                                array2 = array;
                                //IMagickImage arg_24C_0 = magickImage;
                                //array = array2;
                                //arg_24C_0.Mogrify(ref array);
                            }
                            break;
                        }
                    }
                    else
                    {
                        if (this._needRotation == 90)
                        {
                            array = new object[]
							{
								"-rotate",
								" 90 ",
								rotatePath
							};
                            array2 = array;
                            //IMagickImage arg_29C_0 = magickImage;
                            //array = array2;
                            //arg_29C_0.Mogrify(ref array);
                            break;
                        }
                        if (this._needRotation == 180)
                        {
                            array = new object[]
							{
								"-rotate",
								" 180 ",
								rotatePath
							};
                            array2 = array;
                            //IMagickImage arg_2ED_0 = magickImage;
                            //array = array2;
                            //arg_2ED_0.Mogrify(ref array);
                            break;
                        }
                        if (this._needRotation == 270)
                        {
                            array = new object[3];
                            array[0] = "-rotate";
                            array[1] = " 270 ";
                            goto IL_32A;
                        }
                        break;
                    }
                }
                goto IL_347;
            IL_32A:
                array[2] = rotatePath;
                array2 = array;
                //IMagickImage arg_33B_0 = magickImage;
                //array = array2;
                //arg_33B_0.Mogrify(ref array);
            IL_347:
                ;//magickImage = null;
            }
            catch (Exception ex)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ex.Message);
            }
        }

        private int GetRotationValue(string orientation)
        {
            int num = int.Parse(orientation);
            int arg_16_0 = num;
            object expr_7E;
            int expr_3F;
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
            result =Convert.ToInt32( expr_7E);
            return result;
        IL_87:
            arg_8C_0 = 270;
        IL_8C:
            result = arg_8C_0;
            return result;
        }

        private void ResizeWPFImageThumbnails(string sourceImage, int maxHeight, string saveToPath)
        {
            try
            {
                if (2 != 0)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    BitmapImage bitmapImage2 = new BitmapImage();
                    FileStream fileStream = File.OpenRead(sourceImage.ToString());
                    //goto IL_30;
                    try
                    {
                        while (true)
                        {
                        IL_30:
                            MemoryStream memoryStream = new MemoryStream();
                            fileStream.CopyTo(memoryStream);
                            memoryStream.Seek(0L, SeekOrigin.Begin);
                            fileStream.Close();
                            bitmapImage.BeginInit();
                            while (true)
                            {
                                bitmapImage.StreamSource = memoryStream;
                                bitmapImage.EndInit();
                                while (true)
                                {
                                    if (false)
                                    {
                                        goto IL_D7;
                                    }
                                    bitmapImage.Freeze();
                                    decimal d = Convert.ToDecimal(bitmapImage.Width) / Convert.ToDecimal(bitmapImage.Height);
                                    int decodePixelWidth = Convert.ToInt32(maxHeight * d);
                                    if (3 != 0)
                                    {
                                        memoryStream.Seek(0L, SeekOrigin.Begin);
                                        bitmapImage2.BeginInit();
                                        if (!false)
                                        {
                                            bitmapImage2.StreamSource = memoryStream;
                                            bitmapImage2.DecodePixelWidth = decodePixelWidth;
                                            bitmapImage2.DecodePixelHeight = maxHeight;
                                            goto IL_D7;
                                        }
                                        goto IL_30;
                                    }
                                IL_EC:
                                    if (6 != 0)
                                    {
                                        goto Block_10;
                                    }
                                    continue;
                                IL_D7:
                                    if (!false)
                                    {
                                        bitmapImage2.EndInit();
                                        bitmapImage2.Freeze();
                                        goto IL_EC;
                                    }
                                    break;
                                }
                            }
                        }
                    Block_10: ;
                    }
                    finally
                    {
                        bool flag = fileStream == null;
                        while (!flag)
                        {
                            if (7 != 0)
                            {
                                ((IDisposable)fileStream).Dispose();
                                break;
                            }
                        }
                    }
                    using (FileStream fileStream2 = new FileStream(saveToPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite))
                    {
                        new JpegBitmapEncoder
                        {
                            QualityLevel = 94,
                            Frames = 
							{
								BitmapFrame.Create(bitmapImage2)
							}
                        }.Save(fileStream2);
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
                MemoryManagement.FlushMemory();
            }
        }

        private void ResizeWPFImage(string sourceImage, int maxHeight, string saveToPath)
        {
            try
            {
                BitmapImage bitmapImage = new BitmapImage();
                BitmapImage bitmapImage2 = new BitmapImage();
                FileStream fileStream = File.OpenRead(sourceImage.ToString());
                try
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        do
                        {
                            fileStream.CopyTo(memoryStream);
                            memoryStream.Seek(0L, SeekOrigin.Begin);
                            fileStream.Close();
                        }
                        while (8 == 0);
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                        bitmapImage.Freeze();
                        decimal d = 0m;
                        int decodePixelHeight;
                        int decodePixelWidth;
                        if (bitmapImage.Width < bitmapImage.Height)
                        {
                            d = Convert.ToDecimal(bitmapImage.Height) / Convert.ToDecimal(bitmapImage.Width);
                            decodePixelHeight = maxHeight;
                            decodePixelWidth = Convert.ToInt32(maxHeight / d);
                            goto IL_101;
                        }
                        if (false)
                        {
                            goto IL_132;
                        }
                        d = Convert.ToDecimal(bitmapImage.Width) / Convert.ToDecimal(bitmapImage.Height);
                    IL_B1:
                        decodePixelWidth = maxHeight;
                        decodePixelHeight = Convert.ToInt32(maxHeight / d);
                    IL_101:
                        memoryStream.Seek(0L, SeekOrigin.Begin);
                        bitmapImage2.BeginInit();
                        bitmapImage2.StreamSource = memoryStream;
                        bitmapImage2.DecodePixelWidth = decodePixelWidth;
                        bitmapImage2.DecodePixelHeight = decodePixelHeight;
                        bitmapImage2.EndInit();
                    IL_132:
                        bitmapImage2.Freeze();
                        fileStream.Close();
                        if (!true)
                        {
                            goto IL_B1;
                        }
                    }
                }
                finally
                {
                    bool flag;
                    do
                    {
                        flag = (fileStream == null);
                    }
                    while (false);
                    if (!flag)
                    {
                        ((IDisposable)fileStream).Dispose();
                    }
                }
                if (8 != 0)
                {
                    FileStream fileStream2 = new FileStream(saveToPath, FileMode.Create, FileAccess.ReadWrite);
                    try
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
                    finally
                    {
                        bool arg_1CC_0 = fileStream2 == null;
                        bool expr_1CE;
                        do
                        {
                            bool flag = arg_1CC_0;
                            expr_1CE = (arg_1CC_0 = flag);
                        }
                        while (false);
                        if (!expr_1CE)
                        {
                            ((IDisposable)fileStream2).Dispose();
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
        }

        private void DeletePath(string path)
        {
            try
            {
                string[] expr_A3 = Directory.GetFiles(path);
                string[] array;
                if (8 != 0)
                {
                    array = expr_A3;
                }
                string[] array2 = array;
                for (int i = 0; i < array2.Length; i++)
                {
                    string path2 = array2[i];
                    try
                    {
                        if (!false)
                        {
                            if (!File.Exists(path2))
                            {
                                goto IL_56;
                            }
                            File.Delete(path2);
                        }
                        if (true)
                        {
                        }
                    IL_56: ;
                    }
                    catch (Exception serviceException)
                    {
                        do
                        {
                            ErrorHandler.ErrorHandler.LogError(serviceException);
                        }
                        while (7 == 0 || 2 == 0);
                    }
                }
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            finally
            {
                if (Directory.Exists(path))
                {
                    try
                    {
                        Directory.Delete(path, true);
                        while (4 == 0)
                        {
                        }
                    }
                    catch (Exception serviceException)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                }
                if (!false)
                {
                }
            }
            if (3 != 0)
            {
            }
        }


        private bool CheckDriveForImages()
        {
            int arg_259_0;
            object expr_02 = arg_259_0 = 0;
            bool result = false;
            if (expr_02 == null)
            {
                result = (expr_02 != null);
            }
            IEnumerable<DriveInfo> enumerable = DriveInfo.GetDrives().Where(delegate (DriveInfo drive)
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



            bool flag = enumerable.Count<DriveInfo>() <= 0;
            while (!flag)
            {
                this._show = true;
                if (!false)
                {
                    foreach (DriveInfo current in enumerable)
                    {
                        List<string> list = (from s in Directory.EnumerateFiles(current.Name, "*.*", SearchOption.AllDirectories)
                                             where s.ToLower().EndsWith(".jpg")
                                             select s).ToList<string>();
                        List<string> list2 = Directory.EnumerateFiles(current.Name, "*.*", SearchOption.AllDirectories).Where(delegate (string s)
                        {
                            bool result2;
                            bool arg_10D_0;
                            if (!false && !s.ToLower().EndsWith(".wmv"))
                            {
                                bool arg_E2_0;
                                bool arg_55_0;
                                bool expr_13C = arg_55_0 = (arg_E2_0 = s.ToLower().EndsWith(".mp4"));
                                if (8 != 0)
                                {
                                    if (!false)
                                    {
                                        if (expr_13C)
                                        {
                                            goto IL_10B;
                                        }
                                        arg_55_0 = s.ToLower().EndsWith(".avi");
                                    }
                                    if (arg_55_0 || s.ToLower().EndsWith(".mov") || s.ToLower().EndsWith(".3gp") || s.ToLower().EndsWith(".3g2") || s.ToLower().EndsWith(".m2v") || s.ToLower().EndsWith(".m4v"))
                                    {
                                        goto IL_10B;
                                    }
                                    if (false)
                                    {
                                        return result2;
                                    }
                                    bool expr_C8 = arg_E2_0 = s.ToLower().EndsWith(".flv");
                                    if (2 != 0)
                                    {
                                        if (expr_C8)
                                        {
                                            goto IL_10B;
                                        }
                                        arg_E2_0 = s.ToLower().EndsWith(".mpeg");
                                    }
                                }
                                while (!arg_E2_0 && !s.ToLower().EndsWith(".mkv"))
                                {
                                    arg_10D_0 = (arg_E2_0 = s.ToLower().EndsWith(".mts"));
                                    if (!false)
                                    {
                                        goto IL_10C;
                                    }
                                }
                            }
                            IL_10B:
                            arg_10D_0 = true;
                            IL_10C:
                            result2 = arg_10D_0;
                            return result2;
                        }).ToList<string>();
                        bool arg_FE_0 = this.isVideoEditingEnabled;
                        int arg_FE_1 = 0;
                        int arg_120_0;
                        int arg_11E_0;
                        int expr_1AA;
                        int expr_116;
                        while (true)
                        {
                            if ((arg_FE_0 ? 1 : 0) != arg_FE_1)
                            {
                                arg_11E_0 = ((arg_FE_0 = ((arg_120_0 = list.Count) != 0)) ? 1 : 0);
                            }
                            else
                            {
                                expr_1AA = ((arg_FE_0 = ((arg_11E_0 = (arg_120_0 = list.Count)) != 0)) ? 1 : 0);
                                if (7 != 0)
                                {
                                    goto Block_15;
                                }
                            }
                            if (false)
                            {
                                goto IL_11F;
                            }
                            expr_116 = (arg_FE_1 = list2.Count);
                            if (5 != 0)
                            {
                                goto Block_12;
                            }
                        }
                        continue;
                        IL_11F:
                        if (arg_120_0 > 0)
                        {
                            object[] array = new object[5];
                            if (!false)
                            {
                                array[0] = "Found\n\rImages: ";
                                array[1] = list.Count;
                            }
                            array[2] = " \n\rVideos: ";
                            array[3] = list2.Count;
                            array[4] = "\n\rProcessing starting....";
                            string messageBoxText = string.Concat(array);
                            MessageBox.Show(messageBoxText, "iMIX", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            result = true;
                        }
                        else
                        {
                            MessageBox.Show("No file(s) found.");
                            this._show = false;
                        }
                        continue;
                        Block_15:
                        if (expr_1AA > 0)
                        {
                            string messageBoxText = "Found images: " + list.Count + "\n\rProcessing starting....";
                            MessageBox.Show(messageBoxText, "iMIX", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            result = true;
                        }
                        else
                        {
                            MessageBox.Show("No file(s) found.");
                            this._show = false;
                        }
                        continue;
                        Block_12:
                        arg_120_0 = arg_11E_0 + expr_116;
                        goto IL_11F;
                    }
                    return result;
                }
            }
            do
            {
                MessageBox.Show("No drive(s) find.");
            }
            while (false);
            this._show = false;
            return result;
        }

        private bool CheckDesktopForImages()
        {
            int arg_259_0;
            object expr_02 = arg_259_0 = 0;
            bool result=false;
            if (expr_02 == null)
            {
                result = (expr_02 != null);
            }


            //IEnumerable<DriveInfo> enumerable = DriveInfo.GetDrives().Where(delegate (DriveInfo drive)
            //{
            //    bool result2;
            //    while (8 != 0)
            //    {
            //        bool arg_36_0;
            //        if (drive.DriveType == DriveType.Removable)
            //        {
            //            arg_36_0 = drive.IsReady;
            //            if (2 != 0)
            //            {
            //            }
            //        }
            //        else
            //        {
            //            if (5 == 0 || false)
            //            {
            //                continue;
            //            }
            //            arg_36_0 = false;
            //        }
            //        result2 = arg_36_0;
            //        break;
            //    }
            //    return result2;
            //});


            bool flag = false;
           
            if(String.IsNullOrEmpty(FolderParth))
                flag = true;
           


            while (!flag)
            {
                this._show = true;
                if (!false)
                {
                    if (Directory.Exists(FolderParth))
                    {
                        List<string> list = (from s in Directory.EnumerateFiles(FolderParth, "*.*", SearchOption.AllDirectories)
                                             where s.ToLower().EndsWith(".jpg")
                                             select s).ToList<string>();
                        List<string> list2 = Directory.EnumerateFiles(FolderParth, "*.*", SearchOption.AllDirectories).Where(delegate(string s)
                        {
                            bool result2;
                            bool arg_10D_0;
                            if (!false && !s.ToLower().EndsWith(".wmv"))
                            {
                                bool arg_E2_0;
                                bool arg_55_0;
                                bool expr_13C = arg_55_0 = (arg_E2_0 = s.ToLower().EndsWith(".mp4"));
                                if (8 != 0)
                                {
                                    if (!false)
                                    {
                                        if (expr_13C)
                                        {
                                            goto IL_10B;
                                        }
                                        arg_55_0 = s.ToLower().EndsWith(".avi");
                                    }
                                    if (arg_55_0 || s.ToLower().EndsWith(".mov") || s.ToLower().EndsWith(".3gp") || s.ToLower().EndsWith(".3g2") || s.ToLower().EndsWith(".m2v") || s.ToLower().EndsWith(".m4v"))
                                    {
                                        goto IL_10B;
                                    }
                                    if (false)
                                    {
                                        return result2;
                                    }
                                    bool expr_C8 = arg_E2_0 = s.ToLower().EndsWith(".flv");
                                    if (2 != 0)
                                    {
                                        if (expr_C8)
                                        {
                                            goto IL_10B;
                                        }
                                        arg_E2_0 = s.ToLower().EndsWith(".mpeg");
                                    }
                                }
                                while (!arg_E2_0 && !s.ToLower().EndsWith(".mkv"))
                                {
                                    arg_10D_0 = (arg_E2_0 = s.ToLower().EndsWith(".mts"));
                                    if (!false)
                                    {
                                        goto IL_10C;
                                    }
                                }
                            }
                        IL_10B:
                            arg_10D_0 = true;
                        IL_10C:
                            result2 = arg_10D_0;
                            return result2;
                        }).ToList<string>();
                        bool arg_FE_0 = this.isVideoEditingEnabled;
                        int arg_FE_1 = 0;
                        int arg_120_0;
                        int arg_11E_0;
                        int expr_1AA;
                        int expr_116;
                        while (true)
                        {
                            if ((arg_FE_0 ? 1 : 0) != arg_FE_1)
                            {
                                arg_11E_0 = ((arg_FE_0 = ((arg_120_0 = list.Count) != 0)) ? 1 : 0);
                            }
                            else
                            {
                                expr_1AA = ((arg_FE_0 = ((arg_11E_0 = (arg_120_0 = list.Count)) != 0)) ? 1 : 0);
                                if (7 != 0)
                                {
                                    goto Block_15;
                                }
                            }
                            if (false)
                            {
                                goto IL_11F;
                            }
                            expr_116 = (arg_FE_1 = list2.Count);
                            if (5 != 0)
                            {
                                goto Block_12;
                            }
                        }
                        return result;
                        IL_11F:
                        if (arg_120_0 > 0)
                        {
                            object[] array = new object[5];
                            if (!false)
                            {
                                array[0] = "Found\n\rImages: ";
                                array[1] = list.Count;
                            }
                            array[2] = " \n\rVideos: ";
                            array[3] = list2.Count;
                            array[4] = "\n\rProcessing starting....";
                            string messageBoxText = string.Concat(array);
                            //MessageBox.Show(messageBoxText, "iMIX", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            MessageBox.Show(messageBoxText, "Spectra", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            result = true;
                        }
                        else
                        {
                            MessageBox.Show("No file(s) found.");
                            this._show = false;
                        }
                        return result;
                        Block_15:
                        if (expr_1AA > 0)
                        {
                            string messageBoxText = "Found images: " + list.Count + "\n\rProcessing starting....";
                        //    MessageBox.Show(messageBoxText, "iMIX", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            MessageBox.Show(messageBoxText, "Spectra", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                            result = true;
                        }
                        else
                        {
                            MessageBox.Show("No file(s) found.");
                            this._show = false;
                        }
                        return result;
                        Block_12:
                        arg_120_0 = arg_11E_0 + expr_116;
                        goto IL_11F;
                    }
                    return result;
                }
            }
            do
            {
                MessageBox.Show("No drive(s) find.");
            }
            while (false);
            this._show = false;
            return result;
        }

        private void SelectSessionImages()
        {
            int arg_FB_0;
            bool arg_1D1_0 = ((this._selectStartIndex <= -1 || this._selectEndIndex <= -1) ? (arg_FB_0 = 1) : (arg_FB_0 = ((this._selectStartIndex > this._selectEndIndex) ? 1 : 0))) != 0;
            int num;
            if (2 != 0)
            {
                if (!arg_1D1_0)
                {
                    num = this._selectStartIndex;
                    goto IL_FC;
                }
                return;
            }
        IL_FB:
            num = arg_FB_0;
        IL_FC:
            bool flag = num <= this._selectEndIndex;
            bool expr_198;
            while (true)
            {
            IL_109:
                int arg_10D_0 = arg_FB_0 = (flag ? 1 : 0);
                while (7 != 0)
                {
                    if (arg_10D_0 == 0)
                    {
                        if (false)
                        {
                            goto IL_109;
                        }
                        this.lstImages.Items.Refresh();
                        flag = (int.Parse(this.txbSelectedImages.Text.Split(new char[]
						{
							':'
						}).Last<string>().Trim()) != this.lstImages.Items.Count);
                    }
                    else
                    {
                        flag = ((MyImageClass)this.lstImages.Items[num]).IsChecked;
                        if (flag)
                        {
                            goto IL_F7;
                        }
                        ((MyImageClass)this.lstImages.Items[num]).IsChecked = true;
                        if (false)
                        {
                            goto IL_1A4;
                        }
                        this.txbSelectedImages.Text = "Selected :" + (int.Parse(this.txbSelectedImages.Text.Split(new char[]
						{
							':'
						}).Last<string>().Trim()) + 1).ToString();
                        if (7 != 0)
                        {
                            goto IL_F7;
                        }
                    }
                    if (!flag)
                    {
                        this.chkSelectAll.IsChecked = new bool?(true);
                    }
                    else
                    {
                        this.chkSelectAll.IsChecked = new bool?(false);
                        if (false)
                        {
                            goto IL_109;
                        }
                    }
                    expr_198 = ((arg_FB_0 = (arg_10D_0 = (this.IsEnabledSelectEndPoint ? 1 : 0))) != 0);
                    if (!false)
                    {
                        goto Block_11;
                    }
                }
                goto IL_FB;
            }
        IL_F7:
            arg_FB_0 = num + 1;
            goto IL_FB;
        Block_11:
            flag = expr_198;
        IL_1A4:
            if (!flag)
            {
                this._selectStartIndex = (this._selectEndIndex = -1);
            }
        }

        private BitmapImage GetImageFromResourceString(string imageName, string imageDrivePath)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            if (8 == 0)
            {
                goto IL_47;
            }
            if (!false)
            {
                bitmapImage.DecodePixelWidth = 150;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
            }
        IL_29:
            bitmapImage.UriSource = new Uri(imageDrivePath + "\\" + imageName + ".jpg");
        IL_46:
        IL_47:
            bitmapImage.EndInit();
            if (false)
            {
                goto IL_46;
            }
            BitmapImage result;
            do
            {
                result = bitmapImage;
            }
            while (false);
            if (3 != 0)
            {
                return result;
            }
            goto IL_29;
        }

        private void CreateImages()
        {
            GC.AddMemoryPressure(20000L);
            IEnumerable<DriveInfo> enumerable = DriveInfo.GetDrives().Where(delegate (DriveInfo drive)
            {
                bool result;
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
                    result = arg_36_0;
                    break;
                }
                return result;
            });
            if (enumerable.Count<DriveInfo>() > 0)
            {
                using (IEnumerator<DriveInfo> enumerator = enumerable.GetEnumerator())
                {
                    while (true)
                    {
                        while (2 != 0)
                        {
                            if (!enumerator.MoveNext())
                            {
                                goto Block_7;
                            }
                            if (!false)
                            {
                                DriveInfo current = enumerator.Current;
                                try
                                {
                                    DirectoryInfo directoryInfo = new DirectoryInfo(current.Name);
                                    FileInfo[] array = (from f in directoryInfo.EnumerateFiles("*.*", SearchOption.AllDirectories)
                                                        where this.mediaExtensions.Contains(f.Extension.ToLower())
                                                        select f).ToArray<FileInfo>();
                                    if (!Directory.Exists(this._path))
                                    {
                                        Directory.CreateDirectory(this._path);
                                    }
                                    int arg_EB_0;
                                    if (array != null && array.Count<FileInfo>() > 0)
                                    {
                                        arg_EB_0 = ((!this._isBarcodeActive) ? 1 : 0);
                                    }
                                    else
                                    {
                                        arg_EB_0 = 1;
                                    }
                                    while (true)
                                    {
                                        IL_EA:
                                        bool flag = arg_EB_0 != 0;
                                        bool arg_27A_0;
                                        bool expr_ED = arg_27A_0 = flag;
                                        FileInfo[] array2;
                                        int num;
                                        if (!false)
                                        {
                                            if (!expr_ED)
                                            {
                                                if (!Directory.Exists(this._thumbnailsPath))
                                                {
                                                    Directory.CreateDirectory(this._thumbnailsPath);
                                                }
                                            }
                                            array2 = array;
                                            num = 0;
                                            goto IL_386;
                                        }
                                        IL_27A:
                                        FileInfo fileInfo;
                                        if (!arg_27A_0)
                                        {
                                            string text = "";
                                            MLHelpers.ResizeImage(text, 210, this._path + fileInfo.Name + ".jpg");
                                        }
                                        long num2 = Convert.ToInt64(MLHelpers.VideoLength);
                                        flag = this.htVidLength.ContainsKey(fileInfo.Name);
                                        bool expr_2C0 = (arg_EB_0 = (flag ? 1 : 0)) != 0;
                                        if (4 != 0)
                                        {
                                            if (expr_2C0)
                                            {
                                                goto IL_2E9;
                                            }
                                            if (!false)
                                            {
                                                this.htVidLength.Add(fileInfo.Name, num2);
                                                goto IL_2E9;
                                            }
                                            goto IL_301;
                                            IL_37C:
                                            goto IL_37D;
                                            IL_2E9:
                                            if (this._img.ContainsKey(fileInfo.Name))
                                            {
                                                goto IL_37C;
                                            }
                                            IL_301:
                                            this._img.Add(fileInfo.Name, new DownloadFileInfo
                                            {
                                                CreatedDate = fileInfo.CreationTime,
                                                isVideo = true,
                                                fileName = fileInfo.Name + ".jpg",
                                                filePath = this._path,
                                                videoPath = fileInfo.DirectoryName,
                                                fileExtension = fileInfo.Extension
                                            });
                                            goto IL_37C;
                                        }
                                        continue;
                                        IL_386:
                                        if (num >= array2.Length)
                                        {
                                            break;
                                        }
                                        fileInfo = array2[num];
                                        flag = fileInfo.Name.Contains("Thumbs.db");
                                        bool arg_13F_0 = flag;
                                        int arg_383_0;
                                        int arg_383_1;
                                        while (!arg_13F_0)
                                        {
                                            int expr_156 = arg_383_0 = (fileInfo.Extension.ToLower().Equals(".jpg") ? 1 : 0);
                                            int expr_15C = arg_383_1 = 0;
                                            if (expr_15C != 0)
                                            {
                                                goto IL_383;
                                            }
                                            flag = (expr_156 == expr_15C);
                                            bool expr_166 = (arg_EB_0 = (flag ? 1 : 0)) != 0;
                                            //if (false)
                                            //{
                                            //    goto IL_E7;
                                            //}
                                            if (!expr_166)
                                            {
                                                this.originalDirectoryPath = fileInfo.DirectoryName;
                                                if (this._isBarcodeActive)
                                                {
                                                    this.ResizeWPFImage(Path.Combine(fileInfo.DirectoryName, fileInfo.Name), 900, this._thumbnailsPath + fileInfo.Name);
                                                }
                                                if (!this._img.ContainsKey(fileInfo.Name))
                                                {
                                                    this._img.Add(fileInfo.Name, new DownloadFileInfo
                                                    {
                                                        CreatedDate = fileInfo.CreationTime,
                                                        isVideo = false,
                                                        fileName = fileInfo.Name,
                                                        filePath = fileInfo.DirectoryName,
                                                        fileExtension = ".jpg"
                                                    });
                                                }
                                                break;
                                            }
                                            bool expr_248 = arg_13F_0 = !this.isVideoEditingEnabled;
                                            if (!false)
                                            {
                                                if (!expr_248)
                                                {
                                                    string text = string.Empty;
                                                    text = MLHelpers.ExtractThumbnail(fileInfo.FullName);
                                                    flag = string.IsNullOrEmpty(text);
                                                    arg_27A_0 = flag;
                                                    goto IL_27A;
                                                }
                                                break;
                                            }
                                        }
                                        goto IL_37F;
                                        IL_383:
                                        num = arg_383_0 + arg_383_1;
                                        goto IL_386;
                                        IL_37F:
                                        arg_383_0 = num;
                                        arg_383_1 = 1;
                                        goto IL_383;
                                        IL_37E:
                                        goto IL_37F;
                                        IL_37D:
                                        goto IL_37E;
                                    }
                                    break;
                                    //IL_E7:
                                    //    goto IL_EA;
                                }
                                catch (Exception serviceException)
                                {
                                    ErrorHandler.ErrorHandler.LogError(serviceException);
                                }
                            }
                        }
                    }
                    Block_7:;
                }
                GC.Collect();
                GC.RemoveMemoryPressure(20000L);
            }
        }

        private void CreateImagesForDesktop()
        {
            GC.AddMemoryPressure(20000L);
            IEnumerable<DriveInfo> enumerable = DriveInfo.GetDrives().Where(delegate (DriveInfo drive)
            {
                bool result;
                while (8 != 0)
                {
                    bool arg_36_0;
                    if (drive.Name == "C:\\")
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
                    result = arg_36_0;
                    break;
                }
                return result;
            });
            if (enumerable.Count<DriveInfo>() > 0)
            {
                using (IEnumerator<DriveInfo> enumerator = enumerable.GetEnumerator())
                {
                    
                    while (true)
                    {
                        while (2 != 0)
                        {
                            if (!enumerator.MoveNext())
                            {
                                goto Block_7;
                            }
                            if (!false)
                            {
                                DriveInfo current = enumerator.Current;
                                try
                                {
                                    DirectoryInfo directoryInfo = new DirectoryInfo(FolderParth);
                                    FileInfo[] array = (from f in directoryInfo.EnumerateFiles("*.*", SearchOption.AllDirectories)
                                                        where this.mediaExtensions.Contains(f.Extension.ToLower())
                                                        select f).ToArray<FileInfo>();
                                    if (!Directory.Exists(this._path))
                                    {
                                        Directory.CreateDirectory(this._path);
                                    }
                                    int arg_EB_0;
                                    if (array != null && array.Count<FileInfo>() > 0)
                                    {
                                        arg_EB_0 = ((!this._isBarcodeActive) ? 1 : 0);
                                    }
                                    else
                                    {
                                        arg_EB_0 = 1;
                                    }
                                    while (true)
                                    {
                                    IL_EA:
                                        bool flag = arg_EB_0 != 0;
                                        bool arg_27A_0;
                                        bool expr_ED = arg_27A_0 = flag;
                                        FileInfo[] array2;
                                        int num;
                                        if (!false)
                                        {
                                            if (!expr_ED)
                                            {
                                                if (!Directory.Exists(this._thumbnailsPath))
                                                {
                                                    Directory.CreateDirectory(this._thumbnailsPath);
                                                }
                                            }
                                            array2 = array;
                                            num = 0;
                                            goto IL_386;
                                        }
                                    IL_27A:
                                        FileInfo fileInfo;
                                        if (!arg_27A_0)
                                        {
                                            string text = "";
                                            MLHelpers.ResizeImage(text, 210, this._path + fileInfo.Name + ".jpg");
                                        }
                                        long num2 = Convert.ToInt64(MLHelpers.VideoLength);
                                        flag = this.htVidLength.ContainsKey(fileInfo.Name);
                                        bool expr_2C0 = (arg_EB_0 = (flag ? 1 : 0)) != 0;
                                        if (4 != 0)
                                        {
                                            if (expr_2C0)
                                            {
                                                goto IL_2E9;
                                            }
                                            if (!false)
                                            {
                                                this.htVidLength.Add(fileInfo.Name, num2);
                                                goto IL_2E9;
                                            }
                                            goto IL_301;
                                        IL_37C:
                                            goto IL_37D;
                                        IL_2E9:
                                            if (this._img.ContainsKey(fileInfo.Name))
                                            {
                                                goto IL_37C;
                                            }
                                        IL_301:
                                            this._img.Add(fileInfo.Name, new DownloadFileInfo
                                            {
                                                CreatedDate = fileInfo.CreationTime,
                                                isVideo = true,
                                                fileName = fileInfo.Name + ".jpg",
                                                filePath = this._path,
                                                videoPath = fileInfo.DirectoryName,
                                                fileExtension = fileInfo.Extension
                                            });
                                            goto IL_37C;
                                        }
                                        continue;
                                    IL_386:
                                        if (num >= array2.Length)
                                        {
                                            break;
                                        }
                                        fileInfo = array2[num];
                                        flag = fileInfo.Name.Contains("Thumbs.db");
                                        bool arg_13F_0 = flag;
                                        int arg_383_0;
                                        int arg_383_1;
                                        while (!arg_13F_0)
                                        {
                                            int expr_156 = arg_383_0 = (fileInfo.Extension.ToLower().Equals(".jpg") ? 1 : 0);
                                            int expr_15C = arg_383_1 = 0;
                                            if (expr_15C != 0)
                                            {
                                                goto IL_383;
                                            }
                                            flag = (expr_156 == expr_15C);
                                            bool expr_166 = (arg_EB_0 = (flag ? 1 : 0)) != 0;
                                            //if (false)
                                            //{
                                            //    goto IL_E7;
                                            //}
                                            if (!expr_166)
                                            {
                                                this.originalDirectoryPath = fileInfo.DirectoryName;
                                                if (this._isBarcodeActive)
                                                {
                                                    this.ResizeWPFImage(Path.Combine(fileInfo.DirectoryName, fileInfo.Name), 900, this._thumbnailsPath + fileInfo.Name);
                                                }
                                                if (!this._img.ContainsKey(fileInfo.Name))
                                                {
                                                    this._img.Add(fileInfo.Name, new DownloadFileInfo
                                                    {
                                                        CreatedDate = fileInfo.CreationTime,
                                                        isVideo = false,
                                                        fileName = fileInfo.Name,
                                                        filePath = fileInfo.DirectoryName,
                                                        fileExtension = ".jpg"
                                                    });
                                                }
                                                break;
                                            }
                                            bool expr_248 = arg_13F_0 = !this.isVideoEditingEnabled;
                                            if (!false)
                                            {
                                                if (!expr_248)
                                                {
                                                    string text = string.Empty;
                                                    text = MLHelpers.ExtractThumbnail(fileInfo.FullName);
                                                    flag = string.IsNullOrEmpty(text);
                                                    arg_27A_0 = flag;
                                                    goto IL_27A;
                                                }
                                                break;
                                            }
                                        }
                                        goto IL_37F;
                                    IL_383:
                                        num = arg_383_0 + arg_383_1;
                                        goto IL_386;
                                    IL_37F:
                                        arg_383_0 = num;
                                        arg_383_1 = 1;
                                        goto IL_383;
                                    IL_37E:
                                        goto IL_37F;
                                    IL_37D:
                                        goto IL_37E;
                                    }
                                    break;
                                    //IL_E7:
                                    //    goto IL_EA;
                                }
                                catch (Exception serviceException)
                                {
                                    ErrorHandler.ErrorHandler.LogError(serviceException);
                                }
                            }
                        }
                    }
                Block_7:;
                }
                GC.Collect();
                GC.RemoveMemoryPressure(20000L);
            }
        
    }

        private void GetConfigurationInfo()
        {
            while (true)
            {
                try
                {
                    List<long> objList;
                    do
                    {
                        objList = new List<long>();
                        objList.Add(24L);
                        if (!false)
                        {
                            objList.Add(25L);
                            objList.Add(48L);
                        }
                        objList.Add(1L);
                        objList.Add(23L);
                        if (!true)
                        {
                            goto IL_23F;
                        }
                        objList.Add(179L);
                        objList.Add(22L);
                        objList.Add(21L);
                    }
                    while (!true);
                    List<iMIXConfigurationInfo> list = (from o in new ConfigBusiness().GetNewConfigValues(LoginUser.SubStoreId)
                                                        where objList.Contains(o.IMIXConfigurationMasterId)
                                                        select o).ToList<iMIXConfigurationInfo>();
                    if (list == null && list.Count <= 0)
                    {
                        goto IL_28F;
                    }
                    int arg_F4_0 = 0;
                IL_F4:
                    int num = arg_F4_0;
                    goto IL_276;
                IL_11D:
                    long num2;
                    if (num2 >= 21L)
                    {
                        switch ((int)(num2 - 21L))
                        {
                            case 0:
                                this.defaultContrast = ((list[num].ConfigurationValue != null) ? list[num].ConfigurationValue : "1");
                                break;
                            case 1:
                                goto IL_23F;
                            case 2:
                                this._isUsbDelete = (list[num].ConfigurationValue != null && Convert.ToBoolean(list[num].ConfigurationValue));
                                break;
                        }
                    }
                IL_13F:
                    goto IL_269;
                IL_23F:
                    this.defaultBrightness = ((list[num].ConfigurationValue != null) ? list[num].ConfigurationValue : "0");
                IL_269:
                IL_26B:
                    if (false)
                    {
                        goto IL_11D;
                    }
                    num++;
                IL_276:
                    int expr_276 = arg_F4_0 = num;
                    if (3 == 0)
                    {
                        goto IL_F4;
                    }
                    if (expr_276 < list.Count)
                    {
                        long arg_107_0 = list[num].IMIXConfigurationMasterId;
                        long expr_144;
                        while (true)
                        {
                            num2 = arg_107_0;
                            if (num2 <= 23L)
                            {
                                break;
                            }
                            expr_144 = (arg_107_0 = num2);
                            if (!false)
                            {
                                goto Block_12;
                            }
                        }
                        if (num2 == 1L)
                        {
                            this._isBarcodeActive = (list[num].ConfigurationValue != null && Convert.ToBoolean(list[num].ConfigurationValue));
                            goto IL_26B;
                        }
                        if (num2 <= 23L)
                        {
                            goto IL_11D;
                        }
                        goto IL_13F;
                    Block_12:
                        if (expr_144 == 48L)
                        {
                            this.isVideoEditingEnabled = (list[num].ConfigurationValue != null && Convert.ToBoolean(list[num].ConfigurationValue));
                            goto IL_26B;
                        }
                        if (num2 != 179L)
                        {
                            goto IL_269;
                        }
                        this._isEnabledImageEditingMDownload = (list[num].ConfigurationValue != null && Convert.ToBoolean(list[num].ConfigurationValue));
                        goto IL_26B;
                    }
                IL_28F: ;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (!false)
                {
                    if (!false)
                    {
                        return;
                    }
                }
            }
        }

        private bool ApplyCrop(string fileName)
        {
            bool result;
            if (!false)
            {
                try
                {
                    if (this.lstDG_SemiOrder_Settings.FirstOrDefault<SemiOrderSettings>().PS_SemiOrder_IsCropActive == true)
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        this.rotateImage(Path.Combine(this.hotFolderPath, this.dateFolder, fileName), 0);
                        this.ResetImageDPI(Path.Combine(this.hotFolderPath, this.dateFolder, fileName));
                        byte[] array = File.ReadAllBytes(Path.Combine(this.hotFolderPath, this.dateFolder, fileName));
                        memoryStream.Write(array, 0, array.Length);
                        memoryStream.Position = 0L;
                        BitmapSource bitmapSource = BitmapFrame.Create(memoryStream);
                        double num = (double)bitmapSource.PixelWidth / bitmapSource.Width;
                        string[] array2 = this.lstDG_SemiOrder_Settings.FirstOrDefault<SemiOrderSettings>().HorizontalCropValues.Split(new char[]
						{
							','
						});
                        int arg_EE_0 = array2.Length;
                        while (arg_EE_0 == 4)
                        {
                            bool expr_10B = (arg_EE_0 = ((bitmapSource.Width > bitmapSource.Height) ? 1 : 0)) != 0;
                            if (4 != 0)
                            {
                                double num2;
                                double arg_274_0;
                                double num3;
                                double num4;
                                double num5;
                                double num6;
                                bool arg_2AF_0;
                                double num7;
                                double arg_275_0;
                                if (expr_10B)
                                {
                                    if (Convert.ToDouble(array2[2]) > Convert.ToDouble(array2[3]))
                                    {
                                        num2 = Convert.ToDouble(array2[3]) / Convert.ToDouble(array2[2]);
                                    }
                                    else
                                    {
                                        double expr_163 = arg_274_0 = Convert.ToDouble(array2[2]) / Convert.ToDouble(array2[3]);
                                        if (false)
                                        {
                                            goto IL_26B;
                                        }
                                        num2 = expr_163;
                                    }
                                    num3 = num * Convert.ToDouble(array2[0]);
                                    num4 = num * Convert.ToDouble(array2[1]);
                                    num5 = num * Convert.ToDouble(array2[2]);
                                    num6 = num * Convert.ToDouble(array2[3]);
                                    num2 = this.GetActualCropRatio(num2);
                                    if ((double)bitmapSource.PixelHeight >= num4 + num6)
                                    {
                                        goto IL_1F4;
                                    }
                                }
                                else
                                {
                                    bool expr_210 = arg_2AF_0 = (Convert.ToDouble(array2[2]) <= Convert.ToDouble(array2[3]));
                                    if (false)
                                    {
                                        goto IL_2AF;
                                    }
                                    if (!expr_210)
                                    {
                                        num7 = Convert.ToDouble(array2[3]) / Convert.ToDouble(array2[2]);
                                        goto IL_24A;
                                    }
                                    double arg_247_0 = Convert.ToDouble(array2[2]);
                                    double arg_247_1 = Convert.ToDouble(array2[3]);
                                IL_247:
                                    num7 = arg_247_0 / arg_247_1;
                                IL_24A:
                                    double expr_24A = arg_275_0 = num;
                                    if (false)
                                    {
                                        goto IL_275;
                                    }
                                    num3 = expr_24A * Convert.ToDouble(array2[0]);
                                    double expr_25A = arg_247_0 = num;
                                    double expr_25F = arg_247_1 = Convert.ToDouble(array2[1]);
                                    if (!false)
                                    {
                                        num4 = expr_25A * expr_25F;
                                        arg_274_0 = num;
                                        goto IL_26B;
                                    }
                                    goto IL_247;
                                }
                            IL_1C2:
                                double arg_1CC_0 = (double)bitmapSource.PixelHeight - num4;
                            IL_1CC:
                                num6 = (double)Convert.ToInt32(arg_1CC_0);
                                if (num6 > num5)
                                {
                                    num5 = num2 * num6;
                                }
                                else
                                {
                                    num5 = num6 / num2;
                                }
                            IL_1F4:
                                goto IL_2D3;
                            IL_26B:
                                arg_275_0 = arg_274_0 * Convert.ToDouble(array2[2]);
                            IL_275:
                                num5 = arg_275_0;
                                num6 = num * Convert.ToDouble(array2[3]);
                                num7 = this.GetActualCropRatio(num7);
                                if ((double)bitmapSource.PixelWidth >= num3 + num5)
                                {
                                    goto IL_2D2;
                                }
                                arg_2AF_0 = (num6 <= num5);
                            IL_2AF:
                                if (!arg_2AF_0)
                                {
                                    num5 = num7 * num6;
                                }
                                else
                                {
                                    num5 = num6 / num7;
                                }
                                num5 = (double)bitmapSource.PixelWidth - num3;
                            IL_2D2:
                            IL_2D3:
                                double expr_2D6 = arg_1CC_0 = Math.Round(num5, 0);
                                if (false)
                                {
                                    goto IL_1CC;
                                }
                                num5 = expr_2D6;
                                num6 = Math.Round(num6, 0);
                                if (num3 + num5 > (double)bitmapSource.PixelWidth)
                                {
                                    num5 = (double)bitmapSource.PixelWidth - num3;
                                }
                                if (num4 + num6 > (double)bitmapSource.PixelHeight)
                                {
                                    num6 = (double)bitmapSource.PixelHeight - num4;
                                }
                                CroppedBitmap source;
                                try
                                {
                                    source = new CroppedBitmap(bitmapSource, new Int32Rect(Convert.ToInt32(num3), Convert.ToInt32(num4), Convert.ToInt32(num5), Convert.ToInt32(num6)));
                                    while (6 == 0)
                                    {
                                    }
                                }
                                catch (ArgumentException var_12_363)
                                {
                                    source = new CroppedBitmap(bitmapSource, Int32Rect.Empty);
                                }
                                MemoryStream memoryStream2 = new MemoryStream();
                                if (5 != 0)
                                {
                                    new JpegBitmapEncoder
                                    {
                                        Frames = 
										{
											BitmapFrame.Create(source)
										},
                                        QualityLevel = 50
                                    }.Save(memoryStream2);
                                    System.Drawing.Image original = System.Drawing.Image.FromStream(memoryStream2);
                                    Bitmap bitmap = new Bitmap(original);
                                    bitmap.SetResolution(300f, 300f);
                                    bitmap.Save(Path.Combine(this.cropFolderPath, fileName));
                                    memoryStream2.Dispose();
                                    bitmapSource.Freeze();
                                    bitmapSource = null;
                                    memoryStream.Dispose();
                                    result = true;
                                    goto IL_48C;
                                }
                                goto IL_1C2;
                            }
                        }
                        string message = "Invalid HorizontalCropValues in Semiorder settings";
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                        result = false;
                    }
                    else
                    {
                        result = false;
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    result = false;
                }
            IL_48C: ;
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

        private string CreateXMLwithSpecPrintEffects(SemiOrderSettings objDG_SemiOrder_Settings, string dateFolderPath, string fileName)
        {
            if (8 == 0)
            {
                goto IL_101;
            }
            new PhotoBusiness();
            bool? expr_1FE = objDG_SemiOrder_Settings.PS_SemiOrder_Settings_AutoBright;
            bool? flag;
            if (true)
            {
                flag = expr_1FE;
            }
            bool flag2 = !(flag == false) || string.IsNullOrEmpty(this.defaultBrightness);
            if (!flag2)
            {
                objDG_SemiOrder_Settings.PS_SemiOrder_Settings_AutoBright_Value = new double?(Convert.ToDouble(this.defaultBrightness));
            }
            flag = objDG_SemiOrder_Settings.PS_SemiOrder_Settings_AutoContrast;
            int arg_86_0 = (flag == false) ? 1 : 0;
            string result;
            int expr_BD;
            do
            {
                bool arg_9D_0;
                if (arg_86_0 != 0)
                {
                    arg_9D_0 = string.IsNullOrEmpty(this.defaultBrightness);
                }
                else
                {
                    if (false)
                    {
                        return result;
                    }
                    arg_9D_0 = true;
                }
                flag2 = arg_9D_0;
                if (!flag2)
                {
                    objDG_SemiOrder_Settings.PS_SemiOrder_Settings_AutoContrast_Value = new double?(Convert.ToDouble(this.defaultContrast));
                }
                expr_BD = (arg_86_0 = 0);
            }
            while (expr_BD != 0);
            int productId = expr_BD;
            flag2 = !objDG_SemiOrder_Settings.PS_SemiOrder_ProductTypeId.Contains(',');
            if (!flag2)
            {
                productId = 1;
            }
            else
            {
                productId = Convert.ToInt32(objDG_SemiOrder_Settings.PS_SemiOrder_ProductTypeId);
            }
            string text = string.Empty;
        IL_ED:
            flag = objDG_SemiOrder_Settings.PS_SemiOrder_Settings_IsImageBG;
            flag2 = !flag.Value;
        IL_101:
            if (!flag2)
            {
                string arg_169_1 = Convert.ToString(objDG_SemiOrder_Settings.PS_SemiOrder_Settings_AutoBright_Value);
                string arg_169_2 = Convert.ToString(objDG_SemiOrder_Settings.PS_SemiOrder_Settings_AutoContrast_Value);
                string arg_169_3 = Convert.ToString(objDG_SemiOrder_Settings.PS_SemiOrder_Settings_ImageFrame);
                string arg_169_4 = objDG_SemiOrder_Settings.PS_SemiOrder_Settings_ImageFrame_Vertical;
                string arg_169_5 = objDG_SemiOrder_Settings.ProductName;
                string arg_169_6 = objDG_SemiOrder_Settings.PS_SemiOrder_BG;
                string arg_169_7 = objDG_SemiOrder_Settings.PS_SemiOrder_Graphics_layer;
                string arg_169_8 = objDG_SemiOrder_Settings.PS_SemiOrder_Image_ZoomInfo;
                flag = objDG_SemiOrder_Settings.PS_SemiOrder_IsCropActive;
                text = this.SaveXml(arg_169_1, arg_169_2, arg_169_3, arg_169_4, arg_169_5, arg_169_6, arg_169_7, arg_169_8, flag.Value, productId, dateFolderPath, true, fileName, objDG_SemiOrder_Settings.TextLogos);
            }
            else
            {
                string arg_1D5_1 = Convert.ToString(objDG_SemiOrder_Settings.PS_SemiOrder_Settings_AutoBright_Value);
                string arg_1D5_2 = Convert.ToString(objDG_SemiOrder_Settings.PS_SemiOrder_Settings_AutoContrast_Value);
                string arg_1D5_3 = Convert.ToString(objDG_SemiOrder_Settings.PS_SemiOrder_Settings_ImageFrame);
                string arg_1D5_4 = objDG_SemiOrder_Settings.PS_SemiOrder_Settings_ImageFrame_Vertical;
                string arg_1D5_5 = objDG_SemiOrder_Settings.ProductName;
                string arg_1D5_6 = string.Empty;
                string arg_1D5_7 = objDG_SemiOrder_Settings.PS_SemiOrder_Graphics_layer;
                string arg_1D5_8 = objDG_SemiOrder_Settings.PS_SemiOrder_Image_ZoomInfo;
                flag = objDG_SemiOrder_Settings.PS_SemiOrder_IsCropActive;
                text = this.SaveXml(arg_1D5_1, arg_1D5_2, arg_1D5_3, arg_1D5_4, arg_1D5_5, arg_1D5_6, arg_1D5_7, arg_1D5_8, flag.Value, productId, dateFolderPath, false, fileName, objDG_SemiOrder_Settings.TextLogos);
            }
            if (false)
            {
                goto IL_ED;
            }
            result = text;
            return result;
        }

        private string SaveXml(string bvalue, string cvalue, string fvalue, string fvvalue,
            string ProductName, string BG, string glayer, string ZoomDetails, 
            bool isCropActive, int ProductId, string filedatepath, bool isGreenSreen,
            string fileName, string textLogos)
        {
            StringBuilder stringBuilder = new StringBuilder();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(this.ImageEffect);
            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("//image");
            foreach (XmlElement xmlElement in xmlNodeList)
            {
                //XmlElement xmlElement;
                xmlElement.SetAttribute("brightness", bvalue);
            }
            //using (var enumerator = xmlNodeList.GetEnumerator())
            //{
            //    while (true)
            //    {
            //        while (enumerator.MoveNext())
            //        {
            //            XmlElement xmlElement = (XmlElement)enumerator.Current;
            //            xmlElement.SetAttribute("contrast", cvalue);
            //            if (2 != 0)
            //            {
            //            }
            //        }
            //        break;
            //    }
            //}
            bool arg_E8_0 = isCropActive;
            int arg_E8_1 = 0;
            bool arg_257_0=false;
            while (true)
            {
                int arg_EA_0 = ((arg_E8_0 ? 1 : 0) == arg_E8_1) ? 1 : 0;
                while (true)
                {
                    if (arg_EA_0 == 0)
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
                    int expr_1DF = (arg_E8_0 = ProductName.Contains("6 * 8")) ? 1 : 0;
                    int expr_1E5 = arg_E8_1 = 0;
                    if (expr_1E5 != 0)
                    {
                        break;
                    }
                    if (expr_1DF != expr_1E5)
                    {
                        goto Block_6;
                    }
                    if (ProductName.Contains("8 * 10"))
                    {
                        goto IL_215;
                    }
                    arg_257_0 = (((ProductName.Contains("4 * 6") || ProductName.Contains("(4x6) & QR")) ? (arg_EA_0 = 0) : (arg_EA_0 = ((!ProductName.Contains("4 Small Wallets")) ? 1 : 0))) != 0);
                    if (7 != 0)
                    {
                        goto Block_9;
                    }
                }
            }
            object[] array2;
            while (true)
            {
            IL_275:
                string text = string.Empty;
                PhotoBusiness photoBusiness = new PhotoBusiness();
                BitmapImage bitmapImageFromPath = this.GetBitmapImageFromPath(Path.Combine(filedatepath, fileName));
                if (bitmapImageFromPath.Height > bitmapImageFromPath.Width)
                {
                    text = fvvalue;
                }
                else
                {
                    text = fvalue;
                }
                string[] array = ZoomDetails.Split(new char[]
				{
					','
				});
                array2 = new object[21];
                array2[0] = "<photo producttype='";
                array2[1] = this.ProductNamePreference;
                while (true)
                {
                    array2[2] = "' zoomfactor='";
                    array2[3] = array[0];
                    array2[4] = "' border='";
                    do
                    {
                        array2[5] = text;
                        array2[6] = "' bg= '";
                        array2[7] = BG;
                        array2[8] = "' canvasleft='";
                    }
                    while (false);
                    array2[9] = array[1];
                    array2[10] = "' canvastop='";
                    array2[11] = array[2];
                    array2[12] = "' scalecentrex='";
                    array2[13] = array[3];
                    array2[14] = "' scalecentrey='";
                    array2[15] = array[4];
                    array2[16] = "'>";
                    array2[17] = glayer;
                    if (false)
                    {
                        break;
                    }
                    array2[18] = stringBuilder;
                    array2[19] = textLogos;
                    if (7 != 0)
                    {
                        goto Block_14;
                    }
                }
            }
        Block_14:
            array2[20] = "</photo>";
            if (false)
            {
                goto IL_220;
            }
            string text2 = string.Concat(array2);
            this.ImageEffect = xmlDocument.InnerXml.ToString();
            string result = text2;
            if (8 != 0)
            {
                return result;
            }
            goto IL_215;
        Block_6:
            this.ProductNamePreference = "1";
            //goto IL_275;
        IL_215:
            this.ProductNamePreference = "2";
        IL_220:
           // goto IL_275;
        Block_9:
            if (!arg_257_0)
            {
                this.ProductNamePreference = "30";
               // goto IL_275;
            }
            this.ProductNamePreference = "2";
           // goto IL_275;

            return "";
        }

        private BitmapImage GetBitmapImageFromPath(string value)
        {
            BitmapImage result;
            if (8 != 0)
            {
                BitmapImage bitmapImage = new BitmapImage();
                try
                {
                    if (value != null)
                    {
                        using (FileStream fileStream = File.OpenRead(value.ToString()))
                        {
                            while (!true)
                            {
                            }
                            MemoryStream memoryStream = new MemoryStream();
                            fileStream.CopyTo(memoryStream);
                            memoryStream.Seek(0L, SeekOrigin.Begin);
                            if (!false)
                            {
                                fileStream.Close();
                                bitmapImage.BeginInit();
                            }
                            bitmapImage.StreamSource = memoryStream;
                            do
                            {
                                bitmapImage.EndInit();
                            }
                            while (false);
                        }
                    }
                    else
                    {
                        bitmapImage = new BitmapImage();
                    }
                    result = bitmapImage;
                }
                catch (Exception serviceException)
                {
                    if (5 != 0)
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                    result = bitmapImage;
                }
            }
            if (!false)
            {
            }
            return result;
        }

        private static DependencyObject RecursiveVisualChildFinder<T>(DependencyObject rootObject)
        {
            DependencyObject child = VisualTreeHelper.GetChild(rootObject, 0);
            DependencyObject result;
            if (child == null)
            {
                result = null;
            }
            else
            {
                result = ((child.GetType() == typeof(T)) ? child : ImageDownloader.RecursiveVisualChildFinder<T>(child));
                if (!false)
                {
                }
            }
            return result;
        }

        public void btnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.MediaStop();
                this.isImageAcquired = false;
                Home home = new Home();
                home.Show();
                base.Close();
                while (true)
                {
                IL_38:
                    this.MyImages.Clear();
                    bool flag = Directory.Exists(this._path);
                    while (true)
                    {
                        bool arg_56_0;
                        int arg_6F_0 = (arg_56_0 = flag) ? 1 : 0;
                        string[] array;
                        int num;
                        string path;
                        int arg_E9_0;
                        while (true)
                        {
                            if (!false)
                            {
                                if (!arg_56_0)
                                {
                                    goto Block_3;
                                }
                                flag = !Directory.Exists(this._thumbnailsPath);
                                arg_6F_0 = (flag ? 1 : 0);
                            }
                            if (arg_6F_0 != 0)
                            {
                                goto IL_D8;
                            }
                            string[] files = Directory.GetFiles(this._thumbnailsPath);
                            if (false)
                            {
                                goto IL_38;
                            }
                            array = files;
                            num = 0;
                            while (true)
                            {
                                int expr_B6 = (arg_56_0 = ((arg_6F_0 = num) != 0)) ? 1 : 0;
                                if (false)
                                {
                                    break;
                                }
                                if (expr_B6 >= array.Length)
                                {
                                    goto Block_9;
                                }
                                path = array[num];
                                if (File.Exists(path))
                                {
                                    File.Delete(path);
                                    if (-1 == 0)
                                    {
                                        goto IL_107;
                                    }
                                }
                                int expr_B0 = arg_E9_0 = num + 1;
                                if (false)
                                {
                                    goto IL_E9;
                                }
                                num = expr_B0;
                            }
                        }
                    IL_116:
                        flag = (num < array.Length);
                        if (!flag)
                        {
                            Directory.Delete(this._path, true);
                        }
                        else
                        {
                            path = array[num];
                            if (!false)
                            {
                                if (File.Exists(path))
                                {
                                    goto IL_107;
                                }
                                goto IL_10F;
                            }
                        }
                        if (-1 != 0)
                        {
                            goto Block_12;
                        }
                        continue;
                    IL_E9:
                        num = arg_E9_0;
                        goto IL_116;
                    IL_10F:
                        num++;
                        goto IL_116;
                    IL_107:
                        File.Delete(path);
                        goto IL_10F;
                    IL_D8:
                        string[] files2 = Directory.GetFiles(this._path);
                        array = files2;
                        arg_E9_0 = 0;
                        goto IL_E9;
                    Block_9:
                        Directory.Delete(this._thumbnailsPath, true);
                        goto IL_D8;
                    }
                }
            Block_3:
            Block_12: ;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void btnacquire_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                UIElement expr_07 = this.btnacquire;
                bool expr_0C = false;
                if (8 != 0)
                {
                    expr_07.IsEnabled = expr_0C;
                }
                //this.btnBack.IsEnabled = false;
                //this.chkSelectAll.IsEnabled = false;
                //this.isImageAcquired = true;
                List<MyImageClass> list = (from item in this.MyImages
                                           select item).ToList<MyImageClass>();
                int num = list.Count((MyImageClass x) => x.IsChecked);
                int arg_9F_0 = num;
                int arg_9F_1 = 0;
            IL_9F:
                while (arg_9F_0 > arg_9F_1)
                {
                    this.MediaStop();
                    this.ManualCtrl.SetParent(this);
                    this.ManualCtrl.Visibility = Visibility.Collapsed;
                    if (!false)
                    {
                        string text = "";
                        this.ManualCtrl.Imagelist = list.FindAll((MyImageClass x) => x.IsChecked);
                        this.btnacquire.IsDefault = false;
                        this.ManualCtrl.btnDownload.IsDefault = true;
                        this.ManualCtrl.htVidL = this.htVidLength;
                        text = this.ManualCtrl.ShowHandlerDialog();
                        this.btnacquire.IsDefault = true;
                        this.ManualCtrl.btnDownload.IsDefault = false;
                        bool flag = string.IsNullOrEmpty( text);
                        bool arg_198_0;
                        bool expr_167 = arg_198_0 = flag;
                        int arg_192_0;
                        int arg_192_1;
                        if (!false)
                        {
                            if (!expr_167)
                            {
                                Home home = new Home();
                                home.Show();
                                base.Close();
                                arg_192_0 = (Directory.Exists(this._path) ? 1 : 0);
                                arg_192_1 = 0;
                                goto IL_192;
                            }
                            goto IL_2AA;
                        }
                    IL_198:
                        if (arg_198_0)
                        {
                            goto IL_2A9;
                        }
                        int arg_1B3_0;
                        arg_192_0 = (arg_9F_0 = (arg_1B3_0 = (Directory.Exists(this._thumbnailsPath) ? 1 : 0)));
                        int arg_1AA_0 = 0;
                        while (true)
                        {
                            int expr_1AA = arg_9F_1 = arg_1AA_0;
                            if (expr_1AA != 0)
                            {
                                goto IL_9F;
                            }
                            arg_192_1 = expr_1AA;
                            if (expr_1AA == 0)
                            {
                                string[] array;
                                int i;
                                string path;
                                int arg_290_0;
                                int arg_289_0;
                                if (arg_1B3_0 != expr_1AA)
                                {
                                    string[] files = Directory.GetFiles(this._thumbnailsPath);
                                    array = files;
                                    int expr_20C;
                                    int expr_20F;
                                    for (i = 0; i < array.Length; i = expr_20C + expr_20F)
                                    {
                                        path = array[i];
                                        try
                                        {
                                            bool arg_1E4_0 = File.Exists(path);
                                            bool expr_1E8;
                                            do
                                            {
                                                flag = !arg_1E4_0;
                                                expr_1E8 = (arg_1E4_0 = flag);
                                            }
                                            while (false);
                                            if (!expr_1E8)
                                            {
                                                File.Delete(path);
                                            }
                                        }
                                        catch (Exception serviceException)
                                        {
                                            ErrorHandler.ErrorHandler.LogError(serviceException);
                                        }
                                        expr_20C = (arg_9F_0 = (arg_192_0 = (arg_1B3_0 = (arg_290_0 = i))));
                                        expr_20F = (arg_289_0 = 1);
                                        if (expr_20F == 0)
                                        {
                                            goto IL_289;
                                        }
                                    }
                                    Directory.Delete(this._thumbnailsPath, true);
                                    goto IL_231;
                                }
                                goto IL_231;
                            IL_289:
                                int expr_289 = arg_1AA_0 = arg_289_0;
                                if (4 == 0)
                                {
                                    continue;
                                }
                                if (arg_290_0 >= expr_289)
                                {
                                    break;
                                }
                                path = array[i];
                                try
                                {
                                    if (File.Exists(path))
                                    {
                                        File.Delete(path);
                                    }
                                }
                                catch (Exception serviceException)
                                {
                                    ErrorHandler.ErrorHandler.LogError(serviceException);
                                }
                                i++;
                            IL_284:
                                arg_192_0 = (arg_9F_0 = (arg_1B3_0 = (arg_290_0 = i)));
                                arg_289_0 = array.Length;
                                goto IL_289;
                            IL_231:
                                string[] files2 = Directory.GetFiles(this._path);
                                array = files2;
                                i = 0;
                                goto IL_284;
                            }
                            goto IL_192;
                        }
                        Directory.Delete(this._path, true);
                        if (4 != 0)
                        {
                            goto IL_2A9;
                        }
                    IL_2AE:
                        this.btnacquire.IsEnabled = true;
                        this.btnBack.IsEnabled = true;
                        this.chkSelectAll.IsEnabled = true;
                        MessageBox.Show("Please select at least one image/video.");
                        goto IL_2E1;
                    IL_192:
                        flag = (arg_192_0 == arg_192_1);
                        arg_198_0 = flag;
                        goto IL_198;
                    }
                IL_2A9:
                IL_2AA:
                IL_2E1:
                    return;
                }
                //goto IL_2AE;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void chkSelectAll_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                IEnumerator enumerator = ((IEnumerable)this.lstImages.Items).GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        MyImageClass myImageClass = (MyImageClass)enumerator.Current;
                        myImageClass.IsChecked = ((CheckBox)sender).IsChecked.Value;
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (5 != 0)
                    {
                        bool arg_7B_0 = disposable == null;
                        bool expr_7C;
                        do
                        {
                            bool flag = arg_7B_0;
                            expr_7C = (arg_7B_0 = flag);
                        }
                        while (false);
                        if (!expr_7C)
                        {
                            disposable.Dispose();
                        }
                    }
                }
                this.txbSelectedImages.Text = "Selected:" + ((((CheckBox)sender).IsChecked == true) ? this.lstImages.Items.Count.ToString() : "0");
                this.lstImages.Items.Refresh();
            }
        }

        private void Selectedimages_Click(object sender, RoutedEventArgs e)
        {
            bool expr_14 = this.IMGFrame.Visibility != Visibility.Visible;
            bool flag;
            if (6 != 0)
            {
                flag = expr_14;
            }
            if (flag)
            {
                this.selectedImage = ((BitmapImage)((System.Windows.Controls.Image)((Grid)((CheckBox)e.Source).Parent).FindName("thumbImage")).Source).UriSource.OriginalString;
                goto IL_310;
            }
            bool? isChecked = ((CheckBox)sender).IsChecked;
            flag = !(isChecked == true);
            if (false)
            {
                goto IL_310;
            }
            if (!flag)
            {
                this.txbSelectedImages.Text = "Selected :" + (int.Parse(this.txbSelectedImages.Text.Split(new char[]
				{
					':'
				}).Last<string>().Trim()) + 1).ToString();
            }
            isChecked = ((CheckBox)sender).IsChecked;
            int arg_D3_0;
            if (!isChecked.GetValueOrDefault())
            {
                if (6 == 0)
                {
                    goto IL_31C;
                }
                arg_D3_0 = (isChecked.HasValue ? 1 : 0);
            }
            else
            {
                arg_D3_0 = 0;
            }
            flag = (arg_D3_0 == 0);
            if (!flag)
            {
                this.txbSelectedImages.Text = "Selected :" + (int.Parse(this.txbSelectedImages.Text.Split(new char[]
				{
					':'
				}).Last<string>().Trim()) - 1).ToString();
            }
            flag = (int.Parse(this.txbSelectedImages.Text.Split(new char[]
			{
				':'
			}).Last<string>().Trim()) != this.lstImages.Items.Count);
            if (!flag)
            {
                this.chkSelectAll.IsChecked = new bool?(true);
                if (false)
                {
                    goto IL_3AA;
                }
            }
            else
            {
                this.chkSelectAll.IsChecked = new bool?(false);
            }
            string text = ((BitmapImage)((System.Windows.Controls.Image)((Grid)((CheckBox)e.Source).Parent).FindName("thumbImage")).Source).UriSource.OriginalString.ToLower();
            bool arg_274_0;
            if (!text.EndsWith("avi.jpg") && !text.EndsWith("mp4.jpg") && !text.EndsWith("wmv.jpg"))
            {
                if (-1 == 0)
                {
                    goto IL_386;
                }
                if (!text.EndsWith("mov.jpg") && !text.EndsWith("3gp.jpg") && !text.EndsWith("3g2.jpg") && !text.EndsWith("m2v.jpg") && !text.EndsWith("m4v.jpg") && !text.EndsWith("flv.jpg") && !text.EndsWith("mpg.jpg"))
                {
                    arg_274_0 = !text.EndsWith("ffmpeg.jpg");
                    goto IL_273;
                }
            }
            arg_274_0 = false;
        IL_273:
            flag = arg_274_0;
            if (!flag)
            {
                goto IL_2CB;
            }
            this.MediaStop();
            this.imgmain.Visibility = Visibility.Visible;
            this.vidoriginal.Visibility = Visibility.Collapsed;
        IL_29E:
            this.imgmain.Visibility = Visibility.Visible;
            this.vidoriginal.Visibility = Visibility.Collapsed;
            this.imgmain.Source = CommonUtility.GetImageFromPath(text);
        IL_2CB:
            goto IL_468;
        IL_310:
            isChecked = ((CheckBox)sender).IsChecked;
        IL_31C:
            flag = !(isChecked == true);
            if (!flag)
            {
                this.txbSelectedImages.Text = "Selected :" + (int.Parse(this.txbSelectedImages.Text.Split(new char[]
				{
					':'
				}).Last<string>().Trim()) + 1).ToString();
            }
        IL_386:
            isChecked = ((CheckBox)sender).IsChecked;
            flag = !(isChecked == false);
        IL_3AA:
            if (!flag)
            {
                this.txbSelectedImages.Text = "Selected :" + (int.Parse(this.txbSelectedImages.Text.Split(new char[]
				{
					':'
				}).Last<string>().Trim()) - 1).ToString();
            }
            flag = (int.Parse(this.txbSelectedImages.Text.Split(new char[]
			{
				':'
			}).Last<string>().Trim()) != this.lstImages.Items.Count);
            if (!flag)
            {
                this.chkSelectAll.IsChecked = new bool?(true);
            }
            else
            {
                this.chkSelectAll.IsChecked = new bool?(false);
            }
        IL_468:
            bool arg_497_0;
            if (this.IsEnabledSessionSelect)
            {
                isChecked = ((CheckBox)sender).IsChecked;
                arg_497_0 = !(isChecked == true);
            }
            else
            {
                arg_497_0 = true;
            }
            flag = arg_497_0;
            if (!flag)
            {
                this.lstImages.SelectedItem = (MyImageClass)((CheckBox)sender).DataContext;
                flag = !this.IsEnabledSelectEndPoint;
                if (!flag)
                {
                    flag = (this._selectStartIndex <= -1);
                    if (3 == 0)
                    {
                        goto IL_29E;
                    }
                    if (!flag)
                    {
                        this._selectEndIndex = this.lstImages.SelectedIndex;
                    }
                }
                else
                {
                    this._selectEndIndex = this.lstImages.Items.Count - 1;
                }
                flag = (int.Parse(this.txbSelectedImages.Text.Split(new char[]
				{
					':'
				}).Last<string>().Trim()) != 1);
                if (!flag)
                {
                    this._selectStartIndex = this.lstImages.SelectedIndex;
                }
                this.SelectSessionImages();
            }
        }

        private void btnWithPreviewActive_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				if (this.lstImages.Items.Count > 0)
				{
					IEnumerable<DriveInfo> enumerable;
					if (true)
					{
						this.chkSelectAll.IsEnabled = true;
						this.thumbPreview.HorizontalAlignment = HorizontalAlignment.Right;
						this.lstImages.Width = 250.0;
						this.IMGFrame.Visibility = Visibility.Visible;
						this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1_active.png", UriKind.Relative));
						this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/thumbnailview2.png", UriKind.Relative));
						string vidFileName = this.selectedImage;
						if (string.IsNullOrEmpty(vidFileName))
						{
							this.lstImages.SelectedItem = this.lstImages.Items[0];
							this.MediaStop();
							vidFileName = ((BitmapImage)((MyImageClass)this.lstImages.SelectedItem).Image).UriSource.OriginalString.ToLower();
						}
						bool arg_258_0;
						if (!vidFileName.EndsWith("avi.jpg") && !vidFileName.EndsWith("mp4.jpg") && !vidFileName.EndsWith("wmv.jpg") && !vidFileName.EndsWith("mov.jpg") && !vidFileName.EndsWith("3gp.jpg") && !vidFileName.EndsWith("3g2.jpg") && !vidFileName.EndsWith("m2v.jpg"))
						{
							bool arg_1DD_0 = vidFileName.EndsWith("m4v.jpg");
							while (!arg_1DD_0 && !vidFileName.EndsWith("flv.jpg") && !vidFileName.EndsWith("mpg.jpg"))
							{
								if (2 == 0)
								{
									goto IL_39F;
								}
								if (vidFileName.EndsWith("ffmpeg.jpg"))
								{
									break;
								}
								if (false)
								{
									goto IL_425;
								}
								if (vidFileName.EndsWith("mkv.jpg"))
								{
									break;
								}
								arg_258_0 = (arg_1DD_0 = !vidFileName.EndsWith("mts.jpg"));
								if (-1 != 0)
								{
									goto IL_257;
								}
							}
						}
						arg_258_0 = false;
						IL_257:
						if (!arg_258_0)
						{
							vidFileName = vidFileName.Replace(".jpg", string.Empty);
							enumerable = DriveInfo.GetDrives().Where(delegate(DriveInfo drive)
							{
								bool result;
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
									result = arg_36_0;
									break;
								}
								return result;
							});
							if (enumerable.Count<DriveInfo>() > 0)
							{
								goto IL_2BE;
							}
							goto IL_39C;
						}
						IL_39F:
						this.imgmain.Visibility = Visibility.Visible;
						this.vidoriginal.Visibility = Visibility.Collapsed;
						this.imgmain.Source = CommonUtility.GetImageFromPath(vidFileName);
						goto IL_3D3;
					}
					IL_2BE:
					foreach (DriveInfo current in enumerable)
					{
						List<string> source = Directory.EnumerateFiles(current.Name, "*.*", SearchOption.AllDirectories).Where(delegate(string s)
						{
							int arg_116_0;
							bool expr_12B = (arg_116_0 = (s.ToLower().EndsWith(".wmv") ? 1 : 0)) != 0;
							if (!false)
							{
								if (!expr_12B && !s.ToLower().EndsWith(".mp4") && !s.ToLower().EndsWith(".avi"))
								{
									while (!s.ToLower().EndsWith(".mov") && !s.ToLower().EndsWith(".3gp") && !s.ToLower().EndsWith(".3g2") && !s.ToLower().EndsWith(".m2v") && !s.ToLower().EndsWith(".m4v") && !s.ToLower().EndsWith(".flv") && !s.ToLower().EndsWith(".mpg"))
									{
										if (6 != 0)
										{
											if (!s.ToLower().EndsWith(".ffmpeg") && !s.ToLower().EndsWith(".mkv"))
											{
												arg_116_0 = (s.ToLower().EndsWith(".mts") ? 1 : 0);
												return arg_116_0 != 0;
											}
											break;
										}
									}
								}
								arg_116_0 = 1;
							}
							return arg_116_0 != 0;
						}).ToList<string>();
                        string vidFileName = this.selectedImage;
						string text = (from v in source
						where v.ToLower().Contains(Path.GetFileName(vidFileName))
						select v).FirstOrDefault<string>();
						if (text != null)
						{
							this.imgmain.Visibility = Visibility.Collapsed;
							this.vidoriginal.Visibility = Visibility.Visible;
							this.MediaStop();
							ImageDownloader.vsMediaFileName = text.ToString();
							this.MediaPlay();
						}
					}
					IL_39C:
					IL_3D3:
					this.lstImages.SelectedItem = this.lstImages.Items[0];
					this.imgmain.Source = CommonUtility.GetImageFromPath(((BitmapImage)((MyImageClass)this.lstImages.SelectedItem).Image).UriSource.OriginalString);
					IL_425:;
				}
				else
				{
					this.IMGFrame.Visibility = Visibility.Collapsed;
				}
			}
			catch (Exception serviceException)
			{
				ErrorHandler.ErrorHandler.LogError(serviceException);
			}
			finally
			{
				MemoryManagement.FlushMemory();
			}
			while (2 == 0)
			{
			}
		}

        private void btnWithoutPreview_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.MediaStop();
                while (-1 == 0)
                {
                }
                if (this.lstImages.Items.Count <= 0)
                {
                    goto IL_C2;
                }
            IL_39:
                this.selectedImage = string.Empty;
                this.chkSelectAll.IsEnabled = true;
            IL_59:
                this.thumbPreview.HorizontalAlignment = HorizontalAlignment.Stretch;
                this.lstImages.Width = double.NaN;
                this.IMGFrame.Visibility = Visibility.Collapsed;
                this.imgwithPreview.Source = new BitmapImage(new Uri("images/thumbnailview1.png", UriKind.Relative));
                this.imgwithoutPreview.Source = new BitmapImage(new Uri("/images/thumbnailview2_active.png", UriKind.Relative));
            IL_C2:
                if (false)
                {
                    goto IL_59;
                }
                if (2 == 0)
                {
                    goto IL_39;
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
            finally
            {
                if (!false)
                {
                    if (!false)
                    {
                        MemoryManagement.FlushMemory();
                    }
                }
            }
        }

        private void vidPlay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void vidPlay_Click(object sender, RoutedEventArgs e)
        {
            string expr_6C = ((BitmapImage)((System.Windows.Controls.Image)((Grid)((Button)e.Source).Parent).FindName("thumbImage")).Source).UriSource.OriginalString.ToLower();
            string text;
            if (!false)
            {
                text = expr_6C;
            }
            this.selectedImage = text;
            this.btnWithPreviewActive_Click(sender, e);
        }

        private void btnOpenEditControl_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string text = string.Empty;
                bool isCrop = false;
                bool isGreen = false;
                List<MyImageClass> expr_76B = (from item in this.MyImages
                                               where item.FileExtension == ".jpg"
                                               select item).ToList<MyImageClass>();
                List<MyImageClass> list;
                if (4 != 0)
                {
                    list = expr_76B;
                }
                int num = list.Count((MyImageClass x) => x.IsChecked);
                List<MyImageClass> list2 = (from x in list
                                            where x.IsChecked
                                            select x).ToList<MyImageClass>();
                list2 = (from x in list2
                         orderby x.CreatedDate
                         select x).ToList<MyImageClass>();
                if (list2.Count > 0)
                {
                    int num2 = Convert.ToInt32(list2.First<MyImageClass>().PhotoNumber);
                    //this.ucEditing.PhotoName = list2.First<MyImageClass>().Title;
                    //this.ucEditing.PhotoId = (long)num2;
                    //this.ucEditing.dbBrit = (this.ucEditing._brighteff.Brightness = Convert.ToDouble(this.defaultBrightness));
                    //this.ucEditing.dbContr = (this.ucEditing._brighteff.Contrast = Convert.ToDouble(this.defaultContrast));
                    //this.ucEditing.SetEffect();
                    PhotoBusiness photoBusiness = new PhotoBusiness();
                    //this.ucEditing.HotFolderPath = this.hotFolderPath;
                    //this.ucEditing.DateFolder = this.dateFolder;
                    //this.ucEditing.CropFolderPath = this.cropFolderPath;
                    //this.ucEditing.tempfilename = list2.First<MyImageClass>().Title + ".jpg";
                    if (string.IsNullOrWhiteSpace(this.defaultBrightness))
                    {
                        this.defaultBrightness = "0";
                    }
                    if (string.IsNullOrWhiteSpace(this.defaultContrast))
                    {
                        this.defaultContrast = "1";
                    }
                    this.ImageEffect = string.Concat(new string[]
					{
						"<image brightness = '",
						this.defaultBrightness,
						"' contrast = '",
						this.defaultContrast,
						"' Crop='##' colourvalue = '##' rotate='##' ><effects sharpen='##' greyscale='0' digimagic='0' sepia='0' defog='0' underwater='0' emboss='0' invert = '0' granite='0' hue ='##' cartoon = '0'></effects></image>"
					});
                    //this.ucEditing.ImageEffect = this.ImageEffect;
                    //this.ucEditing.SpecImageEffect = this.ImageEffect;
                    MyImageClass current;
                    if (this.lstDG_SemiOrder_Settings != null && this.lstDG_SemiOrder_Settings.Count > 0)
                    {
                        //this.ucEditing.semiOrderProfileId = this.lstDG_SemiOrder_Settings.FirstOrDefault<SemiOrderSettings>().DG_SemiOrder_Settings_Pkey;
                        //this.ucEditing.semiOrderSettings = this.lstDG_SemiOrder_Settings.FirstOrDefault<SemiOrderSettings>();
                        //text = this.CreateXMLwithSpecPrintEffects(this.lstDG_SemiOrder_Settings.FirstOrDefault<SemiOrderSettings>(), Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DateTime.Now.ToString("yyyyMMdd")), this.ucEditing.tempfilename);
                        //this.ucEditing.SpecLayering = text;
                        if (this.lstDG_SemiOrder_Settings.FirstOrDefault<SemiOrderSettings>().PS_SemiOrder_IsCropActive == true)
                        {
                            ErrorHandler.ErrorHandler.LogFileWrite("Crop Start Time: " + DateTime.Now.ToString());
                            using (List<MyImageClass>.Enumerator enumerator = list2.GetEnumerator())
                            {
                                while (enumerator.MoveNext())
                                {
                                    current = enumerator.Current;
                                    if (current.SettingStatus == SettingStatus.Spec)
                                    {
                                        if (!File.Exists(Path.Combine(this.cropFolderPath, current.Title + ".jpg")))
                                        {
                                            current.IsCropped = this.ApplyCrop(current.Title + ".jpg");
                                        }
                                        else
                                        {
                                            current.IsCropped = true;
                                        }
                                    }
                                }
                            }
                            ErrorHandler.ErrorHandler.LogFileWrite("Crop Complete Time: " + DateTime.Now.ToString());
                        }
                        if (list2.First<MyImageClass>().SettingStatus == SettingStatus.Spec)
                        {
                            isCrop = list2.First<MyImageClass>().IsCropped;
                        }
                        isGreen = this.lstDG_SemiOrder_Settings.FirstOrDefault<SemiOrderSettings>().PS_SemiOrder_Settings_IsImageBG.Value;
                    }
                    else
                    {
                        //this.ucEditing.semiOrderProfileId = 0;
                        //this.ucEditing.semiOrderSettings = new SemiOrderSettings();
                        text = string.Empty;
                        //this.ucEditing.SpecLayering = text;
                        isCrop = false;
                        isGreen = false;
                    }
                    if (list2.First<MyImageClass>().SettingStatus == SettingStatus.SpecUpdated)
                    {
                        isCrop = list2.First<MyImageClass>().IsCropped;
                        text = list2.First<MyImageClass>().NewLayeringXML;
                    }
                    if (!string.IsNullOrWhiteSpace(list2.First<MyImageClass>().NewEffectsXML))
                    {
                       // this.ucEditing.ImageEffect = list2.First<MyImageClass>().NewEffectsXML;
                    }
                    if (list2.First<MyImageClass>().SettingStatus == SettingStatus.None)
                    {
                        isCrop = false;
                        text = null;
                    }
                    //this.ucEditing.selectedIndex = 0;
                    using (List<MyImageClass>.Enumerator enumerator = list2.GetEnumerator())
                    {
                        if (!false)
                        {
                            goto IL_5D1;
                        }
                    IL_58B:
                        bool arg_58D_0 = true;
                    IL_58C:
                        if (!arg_58D_0)
                        {
                            this.rotateImage(current.ImagePath.Replace("\\Thumbnails", ""), 0);
                            this.ResetImageDPI(current.ImagePath.Replace("\\Thumbnails", ""));
                        }
                    IL_5D1:
                        if (enumerator.MoveNext())
                        {
                            current = enumerator.Current;
                            if (current.NewEffectsXML == null)
                            {
                                arg_58D_0 = (current.NewLayeringXML != null);
                                goto IL_58C;
                            }
                            goto IL_58B;
                        }
                    }
                    //this.ucEditing.lstMyImageClass = list2;
                    //this.ucEditing.SetParent(this);
                    string text2 = ""; //this.ucEditing.ShowHandlerDialog(isCrop, isGreen, text);
                    IEnumerator<MyImageClass> enumerator2 = this.UpdatedSelectedList.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            MyImageClass miClass = enumerator2.Current;
                            if (miClass.NewEffectsXML == null && miClass.NewLayeringXML == null)
                            {
                                this.rotateImage(miClass.ImagePath.Replace("\\Thumbnails", ""), 1);
                                this.ResetImageDPI(miClass.ImagePath.Replace("\\Thumbnails", ""));
                            }
                            int index;
                            if ((index = list.FindIndex(delegate(MyImageClass x)
                            {
                                int arg_04_0 = x.IsChecked ? 1 : 0;
                                bool arg_2B_0;
                                while (true)
                                {
                                    int arg_4A_0;
                                    if (arg_04_0 != 0)
                                    {
                                        arg_2B_0 = ((arg_04_0 = (arg_4A_0 = ((x.PhotoNumber == miClass.PhotoNumber) ? 1 : 0))) != 0);
                                        if (!false)
                                        {
                                            goto IL_1E;
                                        }
                                    }
                                    else
                                    {
                                        if (!false)
                                        {
                                            arg_4A_0 = 0;
                                            goto IL_1E;
                                        }
                                        goto IL_23;
                                    }
                                IL_25:
                                    if (false)
                                    {
                                        goto IL_1F;
                                    }
                                    if (!false)
                                    {
                                        break;
                                    }
                                    continue;
                                IL_23:
                                    bool flag;
                                    arg_2B_0 = ((arg_04_0 = (arg_4A_0 = (flag ? 1 : 0))) != 0);
                                    goto IL_25;
                                IL_1F:
                                    flag = (arg_4A_0 != 0);
                                    goto IL_23;
                                IL_1E:
                                    goto IL_1F;
                                }
                                return arg_2B_0;
                            })) > -1)
                            {
                                list[index] = miClass;
                            }
                        }
                    }
                    finally
                    {
                        if (enumerator2 != null)
                        {
                            if (!false)
                            {
                                enumerator2.Dispose();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select at least one photo", "Digiphoto");
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (false)
                {
                    goto IL_23;
                }
                if (!this._show)
                {
                    break;
                }
            IL_15:
                if (false)
                {
                    continue;
                }
                this.btnacquire.IsEnabled = true;
            IL_23:
                if (!false)
                {
                    this._busyWindows.Show();
                    FrameworkElement expr_32 = this._busyWindows;
                    if (2 != 0)
                    {
                        expr_32.BringIntoView();
                    }
                }
                this._manualDownloadWorker.RunWorkerAsync();
                if (-1 != 0)
                {
                    break;
                }
                goto IL_15;
            }
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            bool flag = !this._isUsbDelete;
            if (!flag)
            {
                bool expr_29 = !this.isImageAcquired;
                if (!false)
                {
                    flag = expr_29;
                }
                if (!flag)
                {
                    foreach (MyImageClass current in from item in this.MyImages
                                                     where item.IsChecked
                                                     select item)
                    {
                        try
                        {
                            File.Delete(Path.Combine(this.originalDirectoryPath, current.Title + current.FileExtension));
                        }
                        catch
                        {
                        }
                    }
                }
            }
            this.isImageAcquired = false;
            this.MyImages.Clear();
            Directory.Delete(Path.Combine(this.binpath, this.dateFolder), true);
            this.btnWithoutPreview.Click -= new RoutedEventHandler(this.btnWithoutPreview_Click);
            this.btnWithPreviewActive.Click -= new RoutedEventHandler(this.btnWithPreviewActive_Click);
            this.chkSelectAll.Click -= new RoutedEventHandler(this.chkSelectAll_Click);
            base.Loaded -= new RoutedEventHandler(this.Window_Loaded);
            this.btnBack.Click -= new RoutedEventHandler(this.btnBack_Click);
            this.btnacquire.Click -= new RoutedEventHandler(this.btnacquire_Click);
        }

        public bool IsShoworHide()
        {
            return this._show;
        }
        /// <summary>
        /// //////////Test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 
        public static List<ConfigurationInfo> GetConfigurationData(List<baConfigurationInfo> Obj)
        {
            List<ConfigurationInfo> lst = new List<ConfigurationInfo>();
            //baConfigurationInfo baConfigurationInfo = new baConfigurationInfo();
           ConfigurationInfo ConfigurationInfo =new ConfigurationInfo();
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

        ///////////Test End
        private void ManualDownloadworker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!String.IsNullOrEmpty(FolderParth))
                this.CreateImagesForDesktop();
            else
                this.CreateImages();
        }

        private void ManualDownloadworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            TextBlock arg_1BF_0 = this.txbCount;
            string arg_1B5_0 = "/";
            int num = this._img.Count;
            arg_1BF_0.Text = arg_1B5_0 + num.ToString();
            TextBlock arg_5A_0 = this.txbSelectedImages;
            string arg_55_0 = "Selected :";
            num = 0;
            arg_5A_0.Text = arg_55_0 + num.ToString();
            int subs;
            int locationIdS;
            bool flag;
            do
            {
                this.ShowImages();
                this._busyWindows.Hide();
                string text = this.ManualCtrl.ShowHandlerDialog();
                int photogrpherIdS = ManualDownload._photogrpherIdS;
                long startingNoS = ManualDownload._startingNoS;
                locationIdS = ManualDownload._locationIdS;
                subs = ManualDownload._substoreIdS;
                this.IsSpecActiveForSubstore = Convert.ToBoolean(this.lstConfig.FirstOrDefault().DG_SemiOrderMain);
                //this.IsSpecActiveForSubstore = Convert.ToBoolean(this.lstConfig.Where(delegate(ConfigurationInfo x)
                //{
                //    int? dG_Substore_Id = x.DG_Substore_Id;
                //    int arg_55_0_1;
                //    while (true)
                //    {
                //        int arg_41_0 = subs;
                //        while (true)
                //        {
                //        IL_0D:
                //            int num2 = arg_41_0;
                //            while (!false)
                //            {
                //                if (dG_Substore_Id.GetValueOrDefault() == num2)
                //                {
                //                    arg_55_0_1 = (arg_41_0 = (dG_Substore_Id.HasValue ? 1 : 0));
                //                    if (!false)
                //                    {
                //                    }
                //                }
                //                else
                //                {
                //                    if (false)
                //                    {
                //                        continue;
                //                    }
                //                    arg_55_0_1 = (arg_41_0 = 0);
                //                }
                //                if (!false)
                //                {
                //                    return arg_55_0_1 != 0;
                //                }
                //                goto IL_0D;
                //            }
                //            break;
                //        }
                //    }
                //    return arg_55_0_1 != 0;
                //}).FirstOrDefault<ConfigurationInfo>().DG_SemiOrderMain);
                flag = !this.IsSpecActiveForSubstore;
            }
            while (false);
            if (flag)
            {
                goto IL_FF;
            }
        IL_E4:
            this.lstDG_SemiOrder_Settings = new SemiOrderBusiness().GetSemiOrderSetting(null, locationIdS);
        IL_FF:
            flag = (this.lstDG_SemiOrder_Settings == null || this.lstDG_SemiOrder_Settings.Count <= 0);
            while (!flag)
            {
                IEnumerator<MyImageClass> enumerator = this.MyImages.GetEnumerator();
                try
                {
                    while (true)
                    {
                        bool arg_14E_0 = enumerator.MoveNext();
                        bool expr_150;
                        do
                        {
                            flag = arg_14E_0;
                            expr_150 = (arg_14E_0 = flag);
                        }
                        while (false);
                        if (!expr_150)
                        {
                            break;
                        }
                        MyImageClass current = enumerator.Current;
                        current.SettingStatus = SettingStatus.Spec;
                    }
                }
                finally
                {
                    flag = (enumerator == null);
                    if (2 == 0 || !flag)
                    {
                        enumerator.Dispose();
                    }
                }
                if (!false)
                {
                    break;
                }
            }
            if (!false)
            {
                return;
            }
            goto IL_E4;
        }

        private void MediaStop()
        {
            if (!false)
            {
            }
            while (true)
            {
            IL_04:
                bool flag = this.mplayer == null;
                while (!flag)
                {
                    if (!false)
                    {
                        while (!false)
                        {
                            MLMediaPlayer expr_23 = this.mplayer;
                            if (true)
                            {
                                expr_23.MediaStop();
                            }
                            this.mplayer.Dispose();
                            if (7 == 0)
                            {
                                goto IL_58;
                            }
                            if (!false)
                            {
                                goto Block_4;
                            }
                        }
                        goto IL_04;
                    }
                }
                goto IL_46;
            }
        Block_4:
            this.mplayer = null;
        IL_46:
            this.gdMediaPlayer.Children.Clear();
        IL_58:
            this.gdMediaPlayer.Children.Remove(this.mplayer);
        }

        private void MediaPlay()
        {
            while (!false)
            {
                if (5 != 0)
                {
                    this.MediaStop();
                    bool flag = this.mplayer == null;
                    if (false)
                    {
                        continue;
                    }
                    if (false || !flag)
                    {
                        break;
                    }
                }
                else
                {
                IL_23:
                    this.mplayer.Dispose();
                    if (false)
                    {
                        return;
                    }
                }
                this.gdMediaPlayer.Dispatcher.BeginInvoke(new Action(delegate
                {
                    while (true)
                    {
                        this.mplayer = new MLMediaPlayer(ImageDownloader.vsMediaFileName, "ImageDownloader");
                        if (true)
                        {
                            this.gdMediaPlayer.BeginInit();
                            if (!false)
                            {
                                break;
                            }
                        }
                    }
                    this.gdMediaPlayer.Children.Clear();
                    do
                    {
                        this.gdMediaPlayer.Children.Add(this.mplayer);
                    }
                    while (2 == 0);
                    this.gdMediaPlayer.EndInit();
                }), new object[0]);
                return;
            }
            //goto IL_23;
        }

        private BitmapImage GetImageFromPath(string path)
        {
            BitmapImage result;
            try
            {
                BitmapImage bitmapImage;
                if (!false)
                {
                    bitmapImage = new BitmapImage();
                }
                FileStream fileStream = File.OpenRead(path);
                try
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        Stream expr_6F = fileStream;
                        Stream expr_72 = memoryStream;
                        if (8 != 0)
                        {
                            expr_6F.CopyTo(expr_72);
                        }
                        do
                        {
                            memoryStream.Seek(0L, SeekOrigin.Begin);
                            if (8 != 0)
                            {
                                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                                bitmapImage.BeginInit();
                            }
                            bitmapImage.StreamSource = memoryStream;
                            if (5 != 0)
                            {
                                bitmapImage.EndInit();
                                bitmapImage.Freeze();
                                if (!false)
                                {
                                }
                            }
                            fileStream.Close();
                        }
                        while (!true);
                        memoryStream.Close();
                        result = bitmapImage;
                    }
                }
                finally
                {
                    if (!false)
                    {
                        if (fileStream != null)
                        {
                            ((IDisposable)fileStream).Dispose();
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
                result = null;
            }
            return result;
        }

        private string EstimatedAcquisitionTime()
        {
            string arg_174_0 = string.Empty;
            double num = 0.0;
            foreach (object current in ((IEnumerable)this.lstImages.Items))
            {
                MyImageClass myImageClass = (MyImageClass)current;
                if (myImageClass.IsChecked)
                {
                    if (this.htFileSize.ContainsKey(myImageClass.Title))
                    {
                        double num2 = Convert.ToDouble(this.htFileSize[myImageClass.Title].ToString()) * 0.25;
                        if (!myImageClass.Title.ToLower().EndsWith(".jpg"))
                        {
                            num += num2 + 2.0;
                        }
                        else
                        {
                            num += num2;
                        }
                    }
                }
            }
            TimeSpan timeSpan = TimeSpan.FromSeconds(num);
            return "[Minimum acquisition time: " + string.Format("{0:D2}h:{1:D2}m:{2:D2}s", timeSpan.Hours, timeSpan.Minutes, timeSpan.Seconds) + "]";
        }

        private BitmapImage GetImageFromResourceString(string imageName)
        {
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            if (2 != 0)
            {
                bitmapImage.DecodePixelWidth = 150;
                if (-1 != 0)
                {
                    bool flag;
                    do
                    {
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        bool arg_3C_0;
                        bool expr_31 = arg_3C_0 = File.Exists(imageName);
                        if (!false)
                        {
                            arg_3C_0 = !expr_31;
                        }
                        flag = arg_3C_0;
                    }
                    while (2 == 0);
                    if (3 == 0)
                    {
                        return bitmapImage;
                    }
                    if (flag)
                    {
                        return bitmapImage;
                    }
                }
            }
            bitmapImage.UriSource = new Uri(imageName);
            bitmapImage.EndInit();
            return bitmapImage;
        }

        private double ConvertBytesToMegabytes(long bytes)
        {
            float arg_09_0 = (float)bytes;
            double expr_2A;
            while (true)
            {
                double arg_12_0;
                double arg_27_0 = arg_12_0 = (double)(arg_09_0 / 1024f);
                while (true)
                {
                    if (!false)
                    {
                        double expr_12 = (double)(arg_09_0 = (float)arg_12_0 / 1024f);
                        if (false)
                        {
                            break;
                        }
                        arg_27_0 = expr_12;
                    }
                    double num = arg_27_0;
                    while (false)
                    {
                    }
                    expr_2A = (arg_12_0 = (arg_27_0 = num));
                    if (!false)
                    {
                        return expr_2A;
                    }
                }
            }
            return expr_2A;
        }

        private void btnWithPreviewActive_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
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
        //            Uri resourceLocator = new Uri("/DigiPhoto;component/imagedownloader.xaml", UriKind.Relative);
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

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
        //internal Delegate _CreateDelegate(Type delegateType, string handler)
        //{
        //    return Delegate.CreateDelegate(delegateType, this, handler);
        //}

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        //void IComponentConnector.Connect(int connectionId, object target)
        //{
        //    if (false)
        //    {
        //    }
        //    switch (connectionId)
        //    {
        //        case 1:
        //            ((ImageDownloader)target).Loaded += new RoutedEventHandler(this.Window_Loaded);
        //            ((ImageDownloader)target).Unloaded += new RoutedEventHandler(this.Window_Unloaded);
        //            return;
        //        case 4:
        //            this.grdupscroll = (Grid)target;
        //            return;
        //        case 5:
        //            this.btnWithPreviewActive = (Button)target;
        //            this.btnWithPreviewActive.Click += new RoutedEventHandler(this.btnWithPreviewActive_Click);
        //            return;
        //        case 6:
        //            this.imgwithPreview = (System.Windows.Controls.Image)target;
        //            return;
        //        case 7:
        //            this.btnWithoutPreview = (Button)target;
        //            this.btnWithoutPreview.Click += new RoutedEventHandler(this.btnWithoutPreview_Click);
        //            return;
        //        case 8:
        //            this.imgwithoutPreview = (System.Windows.Controls.Image)target;
        //            return;
        //        case 9:
        //            this.SPSelectAll = (Canvas)target;
        //            return;
        //        case 10:
        //            this.chkSelectAll = (CheckBox)target;
        //            this.chkSelectAll.Click += new RoutedEventHandler(this.chkSelectAll_Click);
        //            return;
        //        case 11:
        //            this.txbSelectedImages = (TextBlock)target;
        //            return;
        //        case 12:
        //            this.txbCount = (TextBlock)target;
        //            return;
        //        case 13:
        //            this.thumbPreview1 = (Grid)target;
        //            return;
        //        case 14:
        //            this.thumbPreview = (Grid)target;
        //            return;
        //        case 15:
        //            this.lstImages = (ListBox)target;
        //            return;
        //        case 16:
        //            this.IMGFrame = (Grid)target;
        //            return;
        //        case 17:
        //            this.imgmain = (System.Windows.Controls.Image)target;
        //            return;
        //        case 18:
        //            this.vidoriginal = (Grid)target;
        //            return;
        //        case 19:
        //            this.gdMediaPlayer = (Grid)target;
        //            return;
        //        case 20:
        //            this.timer = (Label)target;
        //            return;
        //        case 21:
        //            this.btnacquire = (Button)target;
        //            this.btnacquire.Click += new RoutedEventHandler(this.btnacquire_Click);
        //            return;
        //        case 22:
        //            this.btnOpenEditControl = (Button)target;
        //            this.btnOpenEditControl.Click += new RoutedEventHandler(this.btnOpenEditControl_Click);
        //            return;
        //        case 23:
        //            this.btnBack = (Button)target;
        //            this.btnBack.Click += new RoutedEventHandler(this.btnBack_Click);
        //            return;
        //        case 24:
        //            this.ManualCtrl = (ManualDownload)target;
        //            return;
        //        case 25:
        //            this.ucEditing = (EditingControl)target;
        //            return;
        //    }
        //    this._contentLoaded = true;
        //}

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        void IStyleConnector.Connect(int connectionId, object target)
        {
            while (true)
            {
                int arg_18_0 = connectionId;
                if (!false)
                {
                    goto IL_0E;
                }
            IL_18:
                switch (arg_18_0)
                {
                    case 0:
                        ((CheckBox)target).Click += new RoutedEventHandler(this.Selectedimages_Click);
                        goto IL_40;
                    case 1:
                        if (false)
                        {
                            goto IL_0E;
                        }
                        ((Button)target).MouseDoubleClick += new MouseButtonEventHandler(this.vidPlay_MouseDoubleClick);
                        if (3 != 0)
                        {
                            goto Block_5;
                        }
                        continue;
                }
                break;
            IL_0E:
                if (!false)
                {
                    arg_18_0 = connectionId - 2;
                    goto IL_18;
                }
            IL_40:
                if (!false)
                {
                    break;
                }
                goto IL_0E;
            }
            return;
        Block_5:
            ((Button)target).Click += new RoutedEventHandler(this.vidPlay_Click);
        }
    }
}
