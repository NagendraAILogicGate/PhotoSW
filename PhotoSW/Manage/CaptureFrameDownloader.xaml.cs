using PhotoSW.Common;
using DigiPhoto.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using FrameworkHelper;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using PhotoSW.Views;
using DigiPhoto;
using PhotoSW.DataLayer;

namespace PhotoSW
{
    public partial class CaptureFrameDownloader : Window, IComponentConnector, IStyleConnector
    {
        private bool processVideos;

        private string filepath;

        private List<string> ImageName;

        private static int count = 0;

        private static int ProcessedCount = 0;

        private string path = string.Empty;

        private string thumbnailspath = string.Empty;

        private string thumbnailsfolderpath = string.Empty;

        private string tumbnailsfolderbigpath = string.Empty;

        private Stopwatch stopwatch = new Stopwatch();

        private bool IsBarcodeActive = false;

        private bool IsUSBDelete = false;

        private new bool Show = false;

        private Dictionary<string, DateTime> img = new Dictionary<string, DateTime>();

        private Dictionary<string, string> imagePath = new Dictionary<string, string>();

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

        public Hashtable htVidLength = new Hashtable();

        private bool isVideoEditingEnabled = false;

        private DirectoryInfo dInfo = null;

    

        public ObservableCollection<MyImageClass> MyImages
        {
            get;
            set;
        }

        public CaptureFrameDownloader()
        {
            this.InitializeComponent();
            this.GetConfigurationInfo();
            this.lstImages.Items.Clear();
            this.filepath = LoginUser.DigiFolderPath;
            string currentDirectory = Environment.CurrentDirectory;
            this.path = currentDirectory + "\\";
            this.path = Path.Combine(this.path, "Download\\");
            this.thumbnailspath = Path.Combine(this.path, "Temp\\");
            string path = currentDirectory + "\\";
            path = Path.Combine(path, "CapturedFrames\\");
            this.dInfo = new DirectoryInfo(path);
            if (Directory.Exists(this.path))
            {
                this.DeletePath(this.path);
            }
            this.ManualDownloadworker.DoWork += new DoWorkEventHandler(this.ManualDownloadworker_DoWork);
            this.ManualDownloadworker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.ManualDownloadworker_RunWorkerCompleted);
            if (this.CheckDriveForImages())
            {
                this.Show = true;
            }
            this.btnacquire.IsDefault = true;
        }

        private void ShowImages()
        {
            if (!false)
            {
                try
                {
                    do
                    {
                        this.lstImages.Items.Clear();
                        this.lstImages.ItemsSource = this.MyImages;
                    }
                    while (7 == 0);
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
                        if (2 != 0)
                        {
                        }
                    }
                    while (3 == 0);
                }
            }
        }

        private BitmapImage GetImageFromResourceString(string imageName)
        {
            BitmapImage bitmapImage = new BitmapImage();
            BitmapImage result;
            while (true)
            {
                bitmapImage.BeginInit();
                if (true)
                {
                    bitmapImage.DecodePixelWidth = 150;
                    while (!false)
                    {
                        bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                        if (!true)
                        {
                            return result;
                        }
                        bitmapImage.UriSource = new Uri(imageName);
                        while (3 != 0)
                        {
                            bitmapImage.EndInit();
                            if (2 != 0)
                            {
                                goto Block_5;
                            }
                        }
                    }
                }
            }
        Block_5:
            result = bitmapImage;
            return result;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.MediaStop();
                Home home = new Home();
                while (true)
                {
                IL_17:
                    if (2 != 0)
                    {
                        home.Show();
                        goto IL_27;
                    }
                    goto IL_AD;
                IL_D0:
                    string[] files = Directory.GetFiles(this.path);
                    string[] array = files;
                    int i;
                    string text;
                    for (i = 0; i < array.Length; i++)
                    {
                        text = array[i];
                        if (false)
                        {
                            goto IL_27;
                        }
                        if (File.Exists(text))
                        {
                            File.Delete(text);
                        }
                        if (false)
                        {
                            goto IL_17;
                        }
                    }
                    Directory.Delete(this.path, true);
                    goto IL_133;
                IL_6C:
                    bool arg_6C_0;
                    if (arg_6C_0)
                    {
                        goto IL_D0;
                    }
                    string[] files2 = Directory.GetFiles(this.thumbnailspath);
                    if (!false)
                    {
                        array = files2;
                        i = 0;
                        goto IL_B4;
                    }
                    goto IL_AE;
                IL_27:
                    base.Close();
                    this.MyImages.Clear();
                    bool flag = !Directory.Exists(this.path);
                    bool arg_BC_0;
                    bool expr_53 = arg_BC_0 = flag;
                    if (7 != 0)
                    {
                        if (!expr_53)
                        {
                            arg_6C_0 = !Directory.Exists(this.thumbnailspath);
                            goto IL_6C;
                        }
                        goto IL_133;
                    }
                IL_BC:
                    if (!arg_BC_0)
                    {
                        Directory.Delete(this.thumbnailspath, true);
                        goto IL_D0;
                    }
                    text = array[i];
                    bool expr_99 = arg_6C_0 = !File.Exists(text);
                    if (false)
                    {
                        goto IL_6C;
                    }
                    if (!expr_99)
                    {
                        File.Delete(text);
                        goto IL_AD;
                    }
                    goto IL_AD;
                IL_B4:
                    arg_BC_0 = (i < array.Length);
                    goto IL_BC;
                IL_133:
                    if (!false)
                    {
                        break;
                    }
                    goto IL_B4;
                IL_AE:
                    i++;
                    goto IL_B4;
                IL_AD:
                    goto IL_AE;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnacquire_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.MediaStop();
                List<MyImageClass> imagelist;
                if (8 != 0)
                {
                    imagelist = (from item in this.MyImages
                                 select item).ToList<MyImageClass>();
                    this.ManualCtrl.SetParent(this);
                }
                this.ManualCtrl.Visibility = Visibility.Collapsed;
                this.ManualCtrl.imagelist = imagelist;
                do
                {
                    this.btnacquire.IsDefault = false;
                    string text;
                    do
                    {
                        this.ManualCtrl.btnDownload.IsDefault = true;
                        this.ManualCtrl.htVidL = this.htVidLength;
                        text = this.ManualCtrl.ShowHandlerDialog();
                        this.btnacquire.IsDefault = true;
                    }
                    while (false);
                    this.ManualCtrl.btnDownload.IsDefault = false;
                    if (text == null)
                    {
                        goto IL_225;
                    }
                }
                while (7 == 0);
                Home home = new Home();
                home.Show();
                base.Close();
                this.MyImages.Clear();
                if (Directory.Exists(this.path))
                {
                    string[] array;
                    if (Directory.Exists(this.thumbnailspath))
                    {
                        string[] files = Directory.GetFiles(this.thumbnailspath);
                        array = files;
                        for (int i = 0; i < array.Length; i++)
                        {
                            string text2 = array[i];
                            try
                            {
                                if (File.Exists(text2))
                                {
                                    File.Delete(text2);
                                }
                            }
                            catch (Exception serviceException)
                            {
                                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                ErrorHandler.ErrorHandler.LogFileWrite(message);
                            }
                        }
                        Directory.Delete(this.thumbnailspath, true);
                    }
                    string[] files2 = Directory.GetFiles(this.path);
                    array = files2;
                    for (int i = 0; i < array.Length; i++)
                    {
                        string text2 = array[i];
                        try
                        {
                            if (File.Exists(text2))
                            {
                                File.Delete(text2);
                                while (!true)
                                {
                                }
                            }
                        }
                        catch (Exception serviceException)
                        {
                            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                    }
                    Directory.Delete(this.path, true);
                }
            IL_225: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void DeletePath(string path)
        {
            try
            {
                int arg_93_0;
                int arg_93_1;
                while (true)
                {
                    string[] files = Directory.GetFiles(path);
                    string[] array = files;
                    int num = 0;
                    while (true)
                    {
                        int expr_75 = arg_93_0 = num;
                        int expr_7A = arg_93_1 = array.Length;
                        if (2 == 0)
                        {
                            goto IL_93;
                        }
                        bool flag = expr_75 < expr_7A;
                        if (7 == 0)
                        {
                            break;
                        }
                        if (!flag)
                        {
                            goto Block_5;
                        }
                        string text = array[num];
                        try
                        {
                            if (File.Exists(text) && 6 != 0)
                            {
                                File.Delete(text);
                            }
                        }
                        catch (Exception serviceException)
                        {
                            string message;
                            do
                            {
                                if (!false)
                                {
                                    message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                                }
                            }
                            while (2 == 0);
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                        }
                        num++;
                    }
                }
            Block_5:
                arg_93_0 = (Directory.Exists(path) ? 1 : 0);
                arg_93_1 = 0;
            IL_93:
                if (arg_93_0 != arg_93_1)
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
                        while (8 == 0)
                        {
                        }
                    }
                    catch (Exception serviceException)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                }
            }
            if (!false)
            {
            }
        }

        private bool CheckDriveForImages()
        {
            bool result;
            List<string> list;
            do
            {
                while (true)
                {
                    bool expr_01 = false;
                    if (!false)
                    {
                        result = expr_01;
                    }
                    this.Show = true;
                    list = (from s in Directory.EnumerateFiles(this.dInfo.FullName, "*.*", SearchOption.AllDirectories)
                            where s.ToLower().EndsWith(".jpg")
                            select s).ToList<string>();
                    bool flag = !this.isVideoEditingEnabled;
                    while (true)
                    {
                        bool arg_83_0;
                        int arg_7D_0;
                        bool expr_6B = (arg_7D_0 = ((arg_83_0 = flag) ? 1 : 0)) != 0;
                        int arg_7D_1;
                        if (3 != 0)
                        {
                            if (!expr_6B)
                            {
                                arg_7D_0 = list.Count;
                                arg_7D_1 = 0;
                                goto IL_7D;
                            }
                            return result;
                        }
                    IL_7F:
                        int expr_80 = arg_7D_1 = 0;
                        if (expr_80 == 0)
                        {
                            flag = ((arg_83_0 ? 1 : 0) == expr_80);
                            if (false)
                            {
                                break;
                            }
                            if (!flag)
                            {
                                goto Block_5;
                            }
                            if (2 != 0)
                            {
                                goto Block_7;
                            }
                            continue;
                        }
                    IL_7D:
                        arg_83_0 = ((arg_7D_0 = ((arg_7D_0 > arg_7D_1) ? 1 : 0)) != 0);
                        goto IL_7F;
                    }
                }
            Block_5: ;
            }
            while (false);
            string messageBoxText = "Found\n\rImages: " + list.Count + "\n\rProcessing starting....";
            MessageBox.Show(messageBoxText, "iMIX", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            result = true;
            return result;
        Block_7:
            MessageBox.Show("No file(s) found.");
            base.Close();
            do
            {
                this.Show = false;
            }
            while (false);
            return result;
        }

        public void CreateImages(bool sub = true)
        {
            bool arg_40E_0;
            if (!false)
            {
                bool expr_3D6 = arg_40E_0 = Directory.Exists(this.path);
                if (4 == 0)
                {
                    goto IL_43;
                }
                if (expr_3D6)
                {
                    goto IL_34;
                }
            }
        IL_23:
            Directory.CreateDirectory(this.path);
        IL_34:
            arg_40E_0 = Directory.Exists(this.thumbnailspath);
        IL_43:
            if (arg_40E_0)
            {
                goto IL_5D;
            }
            Directory.CreateDirectory(this.thumbnailspath);
        IL_59:
            if (false)
            {
                goto IL_23;
            }
        IL_5D:
            if (!false)
            {
                this.MyImages = new ObservableCollection<MyImageClass>();
                try
                {
                    if (this.isVideoEditingEnabled)
                    {
                        List<string> list = Directory.EnumerateFiles(this.dInfo.FullName, "*.*", SearchOption.AllDirectories).Where(delegate(string s)
                        {
                            bool result;
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
                                        return result;
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
                                while (!arg_E2_0 && !s.ToLower().EndsWith(".mpg"))
                                {
                                    arg_10D_0 = (arg_E2_0 = s.ToLower().EndsWith(".jpg"));
                                    if (!false)
                                    {
                                        goto IL_10C;
                                    }
                                }
                            }
                        IL_10B:
                            arg_10D_0 = true;
                        IL_10C:
                            result = arg_10D_0;
                            return result;
                        }).ToList<string>();
                        List<string>.Enumerator enumerator = list.GetEnumerator();
                        try
                        {
                            while (enumerator.MoveNext())
                            {
                                string current = enumerator.Current;
                                FileInfo _objVid = new FileInfo(current.ToString());
                                if (_objVid.Extension.ToLower() == ".jpg")
                                {
                                    base.Dispatcher.Invoke(new Action(delegate
                                    {
                                        this.MyImages.Add(new MyImageClass(_objVid.Name, this.GetImageFromResourceString(_objVid.FullName), true, _objVid.CreationTime, _objVid.FullName, "", null, null, SettingStatus.None, 0L));
                                    }), new object[0]);
                                }
                                else
                                {
                                    long num = 0L;
                                    if (!this.htVidLength.ContainsKey(_objVid.Name))
                                    {
                                        this.htVidLength.Add(_objVid.Name, num);
                                    }
                                    base.Dispatcher.Invoke(new Action(delegate
                                    {
                                        this.MyImages.Add(new MyImageClass(_objVid.Name, this.GetImageFromResourceString(this.path + _objVid.Name + ".jpg"), true, _objVid.CreationTime, _objVid.FullName, "", null, null, SettingStatus.None, 0L));
                                    }), new object[0]);
                                }
                                CaptureFrameDownloader.count++;
                                CaptureFrameDownloader.ProcessedCount++;
                                string value = this.ConvertBytesToMegabytes(_objVid.Length).ToString("0.00");
                                if (!this.htFileSize.ContainsKey(_objVid.Name))
                                {
                                    this.htFileSize.Add(_objVid.Name, value);
                                }
                            }
                        }
                        finally
                        {
                            while (true)
                            {
                                ((IDisposable)enumerator).Dispose();
                                while (!false)
                                {
                                    if (!false)
                                    {
                                        goto Block_21;
                                    }
                                }
                            }
                        Block_21: ;
                        }
                    }
                    else
                    {
                        List<string> list2 = (from s in Directory.EnumerateFiles(this.dInfo.FullName, "*.*", SearchOption.AllDirectories)
                                              where s.ToLower().EndsWith(".jpg")
                                              select s).ToList<string>();
                        if (!false)
                        {
                            foreach (string current2 in list2)
                            {
                                if (!current2.Contains("Thumbs.db"))
                                {
                                    FileInfo fileInfo = new FileInfo(current2.ToString());
                                    fileInfo.CopyTo(this.path + fileInfo.Name, true);
                                    this.ResizeWPFImage(this.path + fileInfo.Name, 900, this.thumbnailspath + fileInfo.Name);
                                    string value = this.ConvertBytesToMegabytes(fileInfo.Length).ToString("0.00");
                                    if (!this.htFileSize.ContainsKey(fileInfo.Name))
                                    {
                                        this.htFileSize.Add(fileInfo.Name, value);
                                    }
                                    CaptureFrameDownloader.count++;
                                    CaptureFrameDownloader.ProcessedCount++;
                                }
                            }
                        }
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    if (true)
                    {
                    }
                }
                return;
            }
            goto IL_59;
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

        public bool IsShoworHide()
        {
            return this.Show;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (2 == 0)
            {
                goto IL_23;
            }
            bool flag = !this.Show;
        IL_10:
            if (4 != 0 && flag)
            {
                return;
            }
            Window expr_1A = this.bs;
            if (!false)
            {
                expr_1A.Show();
            }
        IL_23:
            do
            {
                if (!false)
                {
                    this.bs.BringIntoView();
                }
            }
            while (4 == 0);
            if (false)
            {
                goto IL_10;
            }
            this.ManualDownloadworker.RunWorkerAsync();
        }

        private BitmapImage GetImageFromPath(string path)
        {
            BitmapImage result;
            try
            {
                BitmapImage bitmapImage = new BitmapImage();
                FileStream fileStream = File.OpenRead(path);
                try
                {
                    if (8 != 0)
                    {
                        MemoryStream expr_70 = new MemoryStream();
                        MemoryStream memoryStream;
                        if (!false)
                        {
                            memoryStream = expr_70;
                        }
                        do
                        {
                            Stream expr_80 = fileStream;
                            Stream expr_86 = memoryStream;
                            if (!false)
                            {
                                expr_80.CopyTo(expr_86);
                            }
                            memoryStream.Seek(0L, SeekOrigin.Begin);
                            if (4 != 0)
                            {
                                fileStream.Close();
                                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                            }
                            bitmapImage.BeginInit();
                        }
                        while (false);
                        do
                        {
                            bitmapImage.StreamSource = memoryStream;
                        }
                        while (!true);
                        bitmapImage.EndInit();
                        bitmapImage.Freeze();
                    }
                    fileStream.Close();
                    result = bitmapImage;
                }
                finally
                {
                    bool arg_BA_0 = fileStream == null;
                    while (true)
                    {
                        bool flag = arg_BA_0;
                        while (true)
                        {
                            bool expr_BC = arg_BA_0 = flag;
                            if (5 == 0)
                            {
                                break;
                            }
                            if (expr_BC)
                            {
                                goto IL_CD;
                            }
                            if (!false)
                            {
                                goto Block_10;
                            }
                        }
                    }
                Block_10:
                    ((IDisposable)fileStream).Dispose();
                IL_CD: ;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
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

        private void chkSelectAll_Click(object sender, RoutedEventArgs e)
        {
            IEnumerator enumerator = ((IEnumerable)this.lstImages.Items).GetEnumerator();
            try
            {
                while (enumerator.MoveNext())
                {
                    MyImageClass expr_21 = (MyImageClass)enumerator.Current;
                    MyImageClass myImageClass;
                    if (true)
                    {
                        myImageClass = expr_21;
                    }
                    myImageClass.IsChecked = ((CheckBox)sender).IsChecked.Value;
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                bool flag = disposable == null;
                while (!flag)
                {
                    disposable.Dispose();
                    if (!false)
                    {
                        break;
                    }
                }
            }
            this.txbSelectedImages.Text = "Selected:" + ((((CheckBox)sender).IsChecked == true) ? this.lstImages.Items.Count.ToString() : "0");
            this.lblEstimate.Text = this.EstimatedAcquisitionTime();
            this.lstImages.Items.Refresh();
        }

        private void Selectedimages_Click(object sender, RoutedEventArgs e)
        {
            string text;
            if (this.IMGFrame.Visibility == Visibility.Visible)
            {
                bool? isChecked = ((CheckBox)sender).IsChecked;
                if (isChecked == true)
                {
                    this.txbSelectedImages.Text = "Selected :" + (int.Parse(this.txbSelectedImages.Text.Split(new char[]
					{
						':'
					}).Last<string>().Trim()) + 1).ToString();
                }
                isChecked = ((CheckBox)sender).IsChecked;
                if (isChecked == false)
                {
                    this.txbSelectedImages.Text = "Selected :" + (int.Parse(this.txbSelectedImages.Text.Split(new char[]
					{
						':'
					}).Last<string>().Trim()) - 1).ToString();
                }
                if (int.Parse(this.txbSelectedImages.Text.Split(new char[]
				{
					':'
				}).Last<string>().Trim()) == this.lstImages.Items.Count)
                {
                    this.chkSelectAll.IsChecked = new bool?(true);
                }
                else
                {
                    this.chkSelectAll.IsChecked = new bool?(false);
                }
                text = ((BitmapImage)((Image)((Grid)((CheckBox)e.Source).Parent).FindName("thumbImage")).Source).UriSource.OriginalString.ToLower();
                if (text.EndsWith("avi.jpg") || text.EndsWith("mp4.jpg"))
                {
                    goto IL_258;
                }
            }
            else
            {
                this.selectedImage = ((BitmapImage)((Image)((Grid)((CheckBox)e.Source).Parent).FindName("thumbImage")).Source).UriSource.OriginalString;
                bool? isChecked = ((CheckBox)sender).IsChecked;
                if (isChecked == true)
                {
                    this.txbSelectedImages.Text = "Selected :" + (int.Parse(this.txbSelectedImages.Text.Split(new char[]
					{
						':'
					}).Last<string>().Trim()) + 1).ToString();
                }
                isChecked = ((CheckBox)sender).IsChecked;
                if (!false)
                {
                    if (isChecked == false)
                    {
                        this.txbSelectedImages.Text = "Selected :" + (int.Parse(this.txbSelectedImages.Text.Split(new char[]
						{
							':'
						}).Last<string>().Trim()) - 1).ToString();
                    }
                    if (int.Parse(this.txbSelectedImages.Text.Split(new char[]
					{
						':'
					}).Last<string>().Trim()) == this.lstImages.Items.Count)
                    {
                        this.chkSelectAll.IsChecked = new bool?(true);
                    }
                    else
                    {
                        this.chkSelectAll.IsChecked = new bool?(false);
                    }
                    goto IL_48F;
                }
            }
            bool arg_25A_0;
            if (!text.EndsWith("wmv.jpg") && !text.EndsWith("mov.jpg") && !text.EndsWith("3gp.jpg") && !text.EndsWith("3g2.jpg") && !text.EndsWith("m2v.jpg") && !text.EndsWith("m4v.jpg") && !text.EndsWith("flv.jpg") && !text.EndsWith("mpg.jpg"))
            {
                arg_25A_0 = !text.EndsWith("ffmpeg.jpg");
                goto IL_259;
            }
        IL_258:
            arg_25A_0 = false;
        IL_259:
            if (arg_25A_0)
            {
                this.MediaStop();
                this.imgmain.Visibility = Visibility.Visible;
                this.vidoriginal.Visibility = Visibility.Collapsed;
                this.imgmain.Visibility = Visibility.Visible;
                this.vidoriginal.Visibility = Visibility.Collapsed;
                this.imgmain.Source = this.GetImageFromPath(((BitmapImage)((Image)((Grid)((CheckBox)e.Source).Parent).FindName("thumbImage")).Source).UriSource.OriginalString);
            }
        IL_48F:
            this.lblEstimate.Text = this.EstimatedAcquisitionTime();
        }

        private void btnWithPreviewActive_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string text;
                if (8 != 0)
                {
                    if (this.lstImages.Items.Count > 0)
                    {
                        this.chkSelectAll.IsEnabled = true;
                        this.thumbPreview.HorizontalAlignment = HorizontalAlignment.Right;
                        this.lstImages.Width = 250.0;
                        this.IMGFrame.Visibility = Visibility.Visible;
                        this.imgwithPreview.Source = new BitmapImage(new Uri("/images/thumbnailview1_active.png", UriKind.Relative));
                        this.imgwithoutPreview.Source = new BitmapImage(new Uri("images/thumbnailview2.png", UriKind.Relative));
                        string vidFileName = this.selectedImage;
                        bool flag = !string.IsNullOrEmpty(vidFileName);
                        if (!flag)
                        {
                            this.lstImages.SelectedItem = this.lstImages.Items[0];
                            this.MediaStop();
                            vidFileName = ((BitmapImage)((MyImageClass)this.lstImages.SelectedItem).Image).UriSource.OriginalString.ToLower();
                        }
                        bool arg_216_0;
                        bool arg_212_0;
                        if (!vidFileName.EndsWith("avi.jpg"))
                        {
                            bool expr_14F = arg_216_0 = vidFileName.EndsWith("mp4.jpg");
                            if (-1 == 0)
                            {
                                goto IL_216;
                            }
                            if (!expr_14F && !vidFileName.EndsWith("wmv.jpg"))
                            {
                                if (8 == 0)
                                {
                                    goto IL_214;
                                }
                                if (!vidFileName.EndsWith("mov.jpg") && !vidFileName.EndsWith("3gp.jpg") && !vidFileName.EndsWith("3g2.jpg") && !vidFileName.EndsWith("m2v.jpg") && !vidFileName.EndsWith("m4v.jpg") && !vidFileName.EndsWith("flv.jpg") && !vidFileName.EndsWith("mpg.jpg"))
                                {
                                    arg_212_0 = !vidFileName.EndsWith("ffmpeg.jpg");
                                    goto IL_211;
                                }
                            }
                        }
                        arg_212_0 = false;
                    IL_211:
                        flag = arg_212_0;
                    IL_214:
                        arg_216_0 = flag;
                    IL_216:
                        if (arg_216_0)
                        {
                            this.imgmain.Visibility = Visibility.Visible;
                            this.vidoriginal.Visibility = Visibility.Collapsed;
                            this.imgmain.Source = this.GetImageFromPath(vidFileName);
                            goto IL_30C;
                        }
                        vidFileName = vidFileName.Replace(".jpg", string.Empty);
                        //List<string> source = Directory.EnumerateFiles(this.dInfo.FullName, "*.*", SearchOption.AllDirectories)
                        //    .Where(delegate(string s)
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

                        List<string> source = Directory.EnumerateFiles(this.dInfo.FullName, "*.*", SearchOption.AllDirectories).ToList<string>();
                        text = (from v in source
                                where v.ToLower().Contains(Path.GetFileName(vidFileName))
                                select v).FirstOrDefault<string>();
                        if (text == null)
                        {
                            goto IL_2D5;
                        }
                        this.imgmain.Visibility = Visibility.Collapsed;
                    }
                    else if (!false)
                    {
                        this.IMGFrame.Visibility = Visibility.Collapsed;
                        goto IL_31F;
                    }
                    this.vidoriginal.Visibility = Visibility.Visible;
                    this.MediaStop();
                }
                CaptureFrameDownloader.vsMediaFileName = text.ToString();
                this.MediaPlay();
            IL_2D5:
            IL_30C:
            IL_31F: ;
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

        private void btnWithoutPreview_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    while (true)
                    {
                        this.MediaStop();
                        while (true)
                        {
                            if (this.lstImages.Items.Count <= 0)
                            {
                                goto IL_CE;
                            }
                            if (7 != 0)
                            {
                                this.selectedImage = string.Empty;
                                this.chkSelectAll.IsEnabled = true;
                            }
                            this.thumbPreview.HorizontalAlignment = HorizontalAlignment.Stretch;
                            this.lstImages.Width = double.NaN;
                        IL_7C:
                            this.IMGFrame.Visibility = Visibility.Collapsed;
                            if (!true)
                            {
                                continue;
                            }
                            this.imgwithPreview.Source = new BitmapImage(new Uri("images/thumbnailview1.png", UriKind.Relative));
                            if (3 == 0)
                            {
                                break;
                            }
                            this.imgwithoutPreview.Source = new BitmapImage(new Uri("/images/thumbnailview2_active.png", UriKind.Relative));
                        IL_CE:
                            if (!false)
                            {
                                goto Block_7;
                            }
                            goto IL_7C;
                        }
                    }
                Block_7: ;
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
                if (8 != 0)
                {
                }
            }
            while (false);
        }

        private void ResizeWPFImage(string sourceImage, int maxHeight, string saveToPath)
        {
            try
            {
                if (!false)
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    BitmapImage expr_1DA = new BitmapImage();
                    BitmapImage bitmapImage2;
                    if (!false)
                    {
                        bitmapImage2 = expr_1DA;
                    }
                    FileStream fileStream = File.OpenRead(sourceImage.ToString());
                    try
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        fileStream.CopyTo(memoryStream);
                        while (true)
                        {
                            memoryStream.Seek(0L, SeekOrigin.Begin);
                            fileStream.Close();
                            bitmapImage.BeginInit();
                            while (true)
                            {
                                bitmapImage.StreamSource = memoryStream;
                                if (false)
                                {
                                    break;
                                }
                                bitmapImage.EndInit();
                                bitmapImage.Freeze();
                                if (!false)
                                {
                                    goto Block_7;
                                }
                            }
                        }
                    Block_7:
                        int decodePixelWidth;
                        int decodePixelHeight;
                        if (bitmapImage.Width >= bitmapImage.Height)
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
                        bitmapImage2.EndInit();
                        bitmapImage2.Freeze();
                        fileStream.Close();
                    }
                    finally
                    {
                        bool flag = fileStream == null;
                        do
                        {
                            if (!flag)
                            {
                                ((IDisposable)fileStream).Dispose();
                            }
                        }
                        while (4 == 0);
                    }
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
                        bool arg_1B1_0 = fileStream2 == null;
                        bool expr_1B3;
                        do
                        {
                            bool flag = arg_1B1_0;
                            expr_1B3 = (arg_1B1_0 = flag);
                        }
                        while (2 == 0);
                        if (!expr_1B3)
                        {
                            ((IDisposable)fileStream2).Dispose();
                        }
                    }
                }
            IL_1C4:
                if (7 == 0)
                {
                    goto IL_1C4;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                while (false)
                {
                }
            }
        }

        private void ManualDownloadworker_DoWork(object Sender, DoWorkEventArgs e)
        {
            this.CreateImages(true);
        }

        private void ManualDownloadworker_RunWorkerCompleted(object Sender, RunWorkerCompletedEventArgs e)
        {
            if (-1 != 0)
            {
                if (5 == 0)
                {
                    return;
                }
                TextBlock arg_BD_0 = this.txbCount;
                string arg_B3_0 = "/";
                int num = this.MyImages.Count<MyImageClass>();
                arg_BD_0.Text = arg_B3_0 + num.ToString();
                TextBlock arg_5A_0 = this.txbSelectedImages;
                string arg_55_0 = "Selected :";
                num = this.MyImages.Count<MyImageClass>();
                arg_5A_0.Text = arg_55_0 + num.ToString();
                this.ShowImages();
                this.bs.Hide();
            }
            this.lblEstimate.Text = this.EstimatedAcquisitionTime();
        }

        private void vidPlay_Click(object sender, RoutedEventArgs e)
        {
            string expr_6C = ((BitmapImage)((Image)((Grid)((Button)e.Source).Parent).FindName("thumbImage")).Source).UriSource.OriginalString.ToLower();
            string text;
            if (!false)
            {
                text = expr_6C;
            }
            this.selectedImage = text;
            this.btnWithPreviewActive_Click(sender, e);
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
                result = ((child.GetType() == typeof(T)) ? child : CaptureFrameDownloader.RecursiveVisualChildFinder<T>(child));
                if (!false)
                {
                }
            }
            return result;
        }

        private void MediaStop()
        {
        }

        private void MediaPlay()
        {
        }

        private void btnWithPreviewActive_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void vidPlay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void GetConfigurationInfo()
        {
            try
            {
                List<long> objList = new List<long>();
                if (4 == 0)
                {
                    goto IL_83;
                }
                objList.Add(24L);
            IL_31:
                objList.Add(25L);
                if (!false)
                {
                }
                objList.Add(48L);
                List<iMIXConfigurationInfo> list = (from o in new ConfigBusiness().GetNewConfigValues(LoginUser.SubStoreId)
                                                    where objList.Contains(o.IMIXConfigurationMasterId)
                                                    select o).ToList<iMIXConfigurationInfo>();
                int arg_99_0;
                if (list != null)
                {
                    arg_99_0 = 0;
                    goto IL_98;
                }
            IL_83:
                bool expr_8A = (arg_99_0 = ((list.Count > 0) ? 1 : 0)) != 0;
                int arg_ED_0;
                if (5 != 0)
                {
                    arg_ED_0 = (arg_99_0 = ((!expr_8A) ? 1 : 0));
                    if (false)
                    {
                        goto IL_EC;
                    }
                }
            IL_98:
                int num;
                if (arg_99_0 == 0)
                {
                    num = 0;
                    goto IL_EF;
                }
                goto IL_105;
            IL_EC:
                num = arg_ED_0 + 1;
            IL_EF:
                if (num < list.Count)
                {
                    long arg_BB_0;
                    long expr_AC = arg_BB_0 = list[num].IMIXConfigurationMasterId;
                    if (7 != 0)
                    {
                        long num2 = expr_AC;
                        arg_BB_0 = num2;
                    }
                    if (arg_BB_0 == 48L)
                    {
                        this.isVideoEditingEnabled = (list[num].ConfigurationValue != null && Convert.ToBoolean(list[num].ConfigurationValue));
                    }
                    arg_ED_0 = num;
                    goto IL_EC;
                }
                if (false)
                {
                    goto IL_31;
                }
            IL_105: ;
            }
            catch (Exception serviceException)
            {
                while (false)
                {
                }
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }
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
