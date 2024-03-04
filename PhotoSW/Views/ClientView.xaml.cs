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

namespace PhotoSW.Views
{
    public partial class ClientView : Window, IComponentConnector
    {
        private Timer tmr;

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

        public string Photoname
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
                            this.thumbPreview.Visibility = Visibility.Visible;
                            this.lstImages.Items.Clear();
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
                                    this.lstImages.Items.Add(current);
                                }
                            }
                            this.imgMain.Visibility = Visibility.Collapsed;
                            this.watermark.Visibility = Visibility.Collapsed;
                            goto IL_18B;
                        }
                        this.thumbPreview.Visibility = Visibility.Collapsed;
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
                        this.imgMain.Visibility = Visibility.Collapsed;
                        this.watermark.Visibility = Visibility.Collapsed;
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
                            this.instructionVideo.Visibility = Visibility.Visible;
                            this.StartSaver();
                            this.SetMediaSource(this.MktImgPath);
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
                        this.instructionVideo.Visibility = Visibility.Collapsed;
                        if (6 != 0)
                        {
                        }
                        break;
                    }
                }
                base.WindowState = WindowState.Maximized;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void StartSaver()
        {
            while (true)
            {
                if (!false)
                {
                    this.tmr = new Timer();
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
            this.SetMediaSource(this.MktImgPath);
        }

        private void SetMediaSource(string mSource)
        {
            this.PlayMediaNow(mSource);
            this.instructionVideo.Source = new Uri(this.retPath, UriKind.Relative);
            string extension = System.IO.Path.GetExtension(this.instructionVideo.Source.ToString());
            while (true)
            {
                int arg_66_0;
                if (string.Compare(extension, ".JPG", StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    arg_66_0 = string.Compare(extension, ".PNG", StringComparison.CurrentCultureIgnoreCase);
                    goto IL_65;
                }
                int arg_6C_0 = 1;
                bool expr_BF;
                while (true)
                {
                IL_6B:
                    if (arg_6C_0 != 0)
                    {
                        goto IL_95;
                    }
                    int arg_BF_0;
                    int expr_77 = arg_BF_0 = (this.tmr.Enabled ? 1 : 0);
                    int arg_BF_1;
                    int expr_7D = arg_BF_1 = 0;
                    int arg_84_0;
                    if (expr_7D == 0)
                    {
                        bool flag = expr_77 == expr_7D;
                        arg_84_0 = (flag ? 1 : 0);
                        goto IL_84;
                    }
                IL_BF:
                    expr_BF = ((arg_6C_0 = ((arg_BF_0 == arg_BF_1) ? 1 : 0)) != 0);
                    if (6 != 0)
                    {
                        goto Block_7;
                    }
                    continue;
                IL_95:
                    this.instructionVideo.Play();
                    if (string.Compare(extension, ".JPG", StringComparison.CurrentCultureIgnoreCase) != 0)
                    {
                        goto IL_C9;
                    }
                    arg_BF_0 = (arg_84_0 = string.Compare(extension, ".PNG", StringComparison.CurrentCultureIgnoreCase));
                    if (!false)
                    {
                        arg_BF_1 = 0;
                        goto IL_BF;
                    }
                IL_84:
                    if (arg_84_0 == 0)
                    {
                        this.tmr.Stop();
                    }
                    goto IL_95;
                }
            IL_CA:
                if (false)
                {
                    goto IL_65;
                }
                bool arg_D1_0;
                if (arg_D1_0)
                {
                    return;
                }
                if (false)
                {
                    continue;
                }
                if (this.tmr.Enabled)
                {
                    return;
                }
                if (!false)
                {
                    break;
                }
                continue;
            Block_7:
                arg_D1_0 = ((arg_66_0 = ((!expr_BF) ? 1 : 0)) != 0);
                goto IL_CA;
            IL_C9:
                arg_D1_0 = ((arg_66_0 = 1) != 0);
                goto IL_CA;
            IL_65:
                arg_6C_0 = ((arg_66_0 == 0) ? 1 : 0);
                //goto IL_6B;
            }
            this.tmr.Start();
        }

        private void instructionVideo_MediaEnded(object sender, RoutedEventArgs e)
        {
            if (4 != 0)
            {
                bool arg_32_0 = this.tmr.Enabled;
                bool expr_35;
                do
                {
                    bool flag = arg_32_0;
                    expr_35 = (arg_32_0 = flag);
                }
                while (false);
                if (!expr_35)
                {
                    if (!false)
                    {
                        Timer expr_1C = this.tmr;
                        if (!false)
                        {
                            expr_1C.Start();
                        }
                    }
                }
            }
        }

        private void PlayMediaNow(string clrDirectoryPath)
        {
            try
            {
                if (!Directory.Exists(clrDirectoryPath))
                {
                    goto IL_111;
                }
                DirectoryInfo dir = new DirectoryInfo(clrDirectoryPath);
                this.imgfilesInfo = dir.GetFilesByExtensions(new string[]
				{
					".jpg",
					".JPG",
					".png",
					".PNG",
					".mp4",
					".wmv",
					".mpg",
					".avi",
					".3gp"
				}).ToList<FileInfo>();
                if (this.mktImgcount == this.imgfilesInfo.Count)
                {
                    this.mktImgcount = 0;
                }
                int num = this.mktImgcount;
                bool flag;
                do
                {
                    flag = (num < this.imgfilesInfo.Count);
                }
                while (false);
                if (!flag)
                {
                    goto IL_110;
                }
            IL_D1:
                this.retPath = this.imgfilesInfo[num].FullName;
                this.mktImgcount++;
            IL_110:
            IL_111:
                if (false)
                {
                    goto IL_D1;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
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

        private void btnSelectPrinter_Click(object sender, RoutedEventArgs e)
        {
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                if (!false)
                {
                    string a = System.Windows.MessageBox.Show("Are you sure you want to close the application?", "Confirm shutdown", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();
                    if (!(a == "Yes"))
                    {
                        e.Cancel = true;
                        goto IL_9D;
                    }
                    if (!true)
                    {
                        goto IL_85;
                    }
                    if (false)
                    {
                        goto IL_7B;
                    }
                    this.StopWindowService("FontCache3.0.0.0");
                }
                Process currentProcess = Process.GetCurrentProcess();
                while (Process.GetProcessesByName(currentProcess.ProcessName).Length >= 1)
                {
                    if (!false)
                    {
                        goto IL_7B;
                    }
                }
                goto IL_8E;
            IL_7B:
                System.Windows.Application.Current.Shutdown();
            IL_85:
                currentProcess.Kill();
            IL_8E:
                if (!false)
                {
                }
            IL_9D:
                if (-1 != 0)
                {
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void StopWindowService(string servicename)
        {
            try
            {
                ServiceController serviceController;
                do
                {
                    serviceController = new ServiceController
                    {
                        ServiceName = servicename
                    };
                }
                while (false);
                serviceController.Refresh();
                string a = serviceController.Status.ToString();
                bool arg_4D_0;
                bool arg_57_0 = arg_4D_0 = !(a == "Running");
                do
                {
                    if (!false)
                    {
                        bool flag = arg_4D_0;
                        if (false)
                        {
                            goto IL_62;
                        }
                        arg_57_0 = (arg_4D_0 = flag);
                    }
                }
                while (false);
                if (!arg_57_0)
                {
                    serviceController.Stop();
                }
            IL_62: ;
            }
            catch (Exception serviceException)
            {
                if (6 != 0)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        public void SetEffect()
        {
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                Func<LstMyItems, bool> func = null;
                try
                {
                    while (true)
                    {
                        int arg_136_0;
                        if (RobotImageLoader.GroupImages != null)
                        {
                            arg_136_0 = ((RobotImageLoader.GroupImages.Count == 0) ? 1 : 0);
                            goto IL_22;
                        }
                    IL_24:
                        if (false)
                        {
                            continue;
                        }
                        arg_136_0 = 1;
                    IL_28:
                        if (arg_136_0 != 0)
                        {
                            break;
                        }
                        IEnumerable<LstMyItems> arg_84_0 = from o in RobotImageLoader.GroupImages
                                                           orderby o.PhotoId descending
                                                           select o;
                        if (func == null)
                        {
                            Func<LstMyItems, bool> expr_74 = (LstMyItems o) => o.PhotoId > this._currentImageId;
                            if (5 != 0)
                            {
                                func = expr_74;
                            }
                        }
                        LstMyItems lstMyItems = arg_84_0.LastOrDefault(func);
                        bool flag = lstMyItems == null;
                        bool expr_90 = (arg_136_0 = (flag ? 1 : 0)) != 0;
                        if (!false)
                        {
                            if (expr_90)
                            {
                                goto IL_125;
                            }
                            this.LoadImage(lstMyItems);
                            LstMyItems lstMyItems2 = RobotImageLoader.PrintImages.FirstOrDefault((LstMyItems t) => t.PhotoId == this._currentImageId);
                            bool expr_CC = (arg_136_0 = ((lstMyItems2 != null) ? 1 : 0)) != 0;
                            if (3 == 0)
                            {
                                goto IL_22;
                            }
                            if (!expr_CC)
                            {
                                this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                                if (false)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                            }
                        IL_11E:
                            if (!false)
                            {
                                goto IL_125;
                            }
                            goto IL_24;
                        IL_11C:
                            goto IL_11E;
                        IL_125:
                            if (!false)
                            {
                                break;
                            }
                            goto IL_11C;
                        }
                    IL_22:
                        goto IL_28;
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
            while (false);
        }

        public void LoadImage(LstMyItems myitem)
        {
            this._currentImageId = myitem.PhotoId;
            string path;
            do
            {
                path = myitem.FilePath.Replace("Thumbnails", "Thumbnails_Big");
                if (false)
                {
                    goto IL_11F;
                }
            }
            while (6 == 0);
            this.imgNext.Source = CommonUtility.GetImageFromPath(path);
            this.imgNext.Visibility = Visibility.Visible;
            if (!true)
            {
                goto IL_131;
            }
            this.txtMainImage.Visibility = Visibility.Visible;
            this.txtMainImage.Text = myitem.Name;
            this.testR.Fill = null;
            this.testR.Visibility = Visibility.Collapsed;
            SearchResult searchResult = null;
            //using (IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator())
            //{
            try
            {
                IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator();
                while (true)
                {
                    if (false)
                    {
                        goto IL_EA;
                    }
                    Window window;
                    if (3 != 0)
                    {
                        if (!enumerator.MoveNext())
                        {
                            break;
                        }
                        window = (Window)enumerator.Current;
                    }
                    if (!(window.Title == "View/Order Station"))
                    {
                        goto IL_EA;
                    }
                    searchResult = (SearchResult)window;
                IL_E5:
                    if (4 != 0)
                    {
                        break;
                    }
                    continue;
                IL_EA:
                    if (8 == 0)
                    {
                        goto IL_E5;
                    }
                }
            }
            catch
            {
            }
            finally
            {
            }
           // }
        IL_11F:
            //this.mPreviewControl.SetControlledObject(searchResult.gdMediaPlayer);
        IL_131:
            searchResult.lstImages.SelectedItem = myitem;
            if (myitem != null && !string.IsNullOrEmpty(myitem.Name))
            {
                AuditLog.AddUserLog(LoginUser.UserId, 1, "Show Preview of " + myitem.Name.ToString() + " image.", myitem.PhotoId);
            }
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                Func<LstMyItems, bool> func = null;
                try
                {
                    while (true)
                    {
                        int arg_136_0;
                        if (RobotImageLoader.GroupImages != null)
                        {
                            arg_136_0 = ((RobotImageLoader.GroupImages.Count == 0) ? 1 : 0);
                            goto IL_22;
                        }
                    IL_24:
                        if (false)
                        {
                            continue;
                        }
                        arg_136_0 = 1;
                    IL_28:
                        if (arg_136_0 != 0)
                        {
                            break;
                        }
                        IEnumerable<LstMyItems> arg_84_0 = from o in RobotImageLoader.GroupImages
                                                           orderby o.PhotoId descending
                                                           select o;
                        if (func == null)
                        {
                            Func<LstMyItems, bool> expr_74 = (LstMyItems o) => o.PhotoId < this._currentImageId;
                            if (5 != 0)
                            {
                                func = expr_74;
                            }
                        }
                        LstMyItems lstMyItems = arg_84_0.FirstOrDefault(func);
                        bool flag = lstMyItems == null;
                        bool expr_90 = (arg_136_0 = (flag ? 1 : 0)) != 0;
                        if (!false)
                        {
                            if (expr_90)
                            {
                                goto IL_125;
                            }
                            this.LoadImage(lstMyItems);
                            LstMyItems lstMyItems2 = RobotImageLoader.PrintImages.FirstOrDefault((LstMyItems t) => t.PhotoId == this._currentImageId);
                            bool expr_CC = (arg_136_0 = ((lstMyItems2 != null) ? 1 : 0)) != 0;
                            if (3 == 0)
                            {
                                goto IL_22;
                            }
                            if (!expr_CC)
                            {
                                this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                                if (false)
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                this.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                            }
                        IL_11E:
                            if (!false)
                            {
                                goto IL_125;
                            }
                            goto IL_24;
                        IL_11C:
                            goto IL_11E;
                        IL_125:
                            if (!false)
                            {
                                break;
                            }
                            goto IL_11C;
                        }
                    IL_22:
                        goto IL_28;
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
            while (false);
        }

        private BitmapImage GetImageFromPath(string path)
        {
            BitmapImage result;
            if (!false)
            {
                try
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    using (FileStream fileStream = File.OpenRead(path))
                    {
                        if (4 != 0)
                        {
                            MemoryStream memoryStream;
                            if (8 != 0)
                            {
                                memoryStream = new MemoryStream();
                                fileStream.CopyTo(memoryStream);
                                memoryStream.Seek(0L, SeekOrigin.Begin);
                                fileStream.Close();
                                if (7 != 0)
                                {
                                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                                }
                                bitmapImage.BeginInit();
                                bitmapImage.StreamSource = memoryStream;
                                bitmapImage.EndInit();
                                if (!true)
                                {
                                    goto IL_8B;
                                }
                                bitmapImage.Freeze();
                                fileStream.Close();
                                memoryStream.Flush();
                            }
                            memoryStream.Close();
                        IL_8B:
                            memoryStream.Dispose();
                        }
                        result = bitmapImage;
                    }
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                    result = null;
                }
            }
            while (3 == 0)
            {
            }
            return result;
        }

        public void PlayVideoOnClient(string Source, object mfile, int? VideoId = null)
        {
            try
            {
                this.gdMediaPlayer.Height = 440.0;
                while (true)
                {
                    FrameworkElement expr_20 = this.gdMediaPlayer;
                    double expr_25 = 500.0;
                    if (7 != 0)
                    {
                        expr_20.Width = expr_25;
                    }
                    bool flag = !(Source == "VideoEditor");
                    while (true)
                    {
                        if (!flag)
                        {
                            this.gdMediaPlayer.Margin = new Thickness(-100.0, 150.0, 0.0, -210.0);
                            goto IL_8F;
                        }
                        if (!true)
                        {
                            break;
                        }
                        if (!false)
                        {
                            this.gdMediaPlayer.Margin = new Thickness(-210.0, -50.0, 0.0, 0.0);
                            this.gdMediaPlayer.Visibility = Visibility.Visible;
                            goto IL_F2;
                        }
                    IL_107:
                        if (6 == 0)
                        {
                            goto IL_8F;
                        }
                        this.imgNext.Visibility = Visibility.Collapsed;
                        this.imgNext.Source = null;
                        this.txtMainImage.Visibility = Visibility.Visible;
                        this.stkPrint.Visibility = Visibility.Collapsed;
                        if (!false)
                        {
                            this.btnMinimize.Visibility = Visibility.Collapsed;
                            this.stkPrevNext.Visibility = Visibility.Collapsed;
                            goto IL_161;
                        }
                        continue;
                    IL_F2:
                        flag = !(Source == "FrameExtractionPreview");
                        if (!flag)
                        {
                            goto IL_107;
                        }
                        goto IL_1EB;
                    IL_8F:
                        this.gdMediaPlayer.Visibility = Visibility.Visible;
                        if (true)
                        {
                            goto IL_F2;
                        }
                        goto IL_1D0;
                    IL_161:
                        this.testR.Visibility = Visibility.Collapsed;
                        if (8 != 0)
                        {
                            this.gdMediaPlayer.Height = 550.0;
                            this.gdMediaPlayer.Width = 700.0;
                            this.gdMediaPlayer.Margin = new Thickness(0.0, 50.0, 0.0, 0.0);
                            goto IL_1D0;
                        }
                        goto IL_107;
                    IL_1EB:
                        flag = (this.previewSecondary != null);
                        if (!flag)
                        {
                            this.previewSecondary = new MPreviewClass();
                        }
                        this.previewSecondary.ObjectClose();
                        this.previewSecondary.ObjectStart(mfile);
                        if (4 != 0)
                        {
                            goto Block_10;
                        }
                        goto IL_161;
                    IL_1D0:
                        this.txtMainImage.Text = VideoId.ToString();
                        goto IL_1EB;
                    }
                }
            Block_10:
                this.previewSecondary.PreviewEnable("", 0, 1);
                this.mPreviewControl.SetControlledObject(this.previewSecondary);
            }
            catch
            {
            }
        }

        public void StopMediaPlay()
        {
            this.previewSecondary = null;
            this.gdMediaPlayer.Visibility = Visibility.Collapsed;
        }

        public void StopMediaPlay(bool? HideControl)
        {
            bool? flag;
            while (true)
            {
                this.previewSecondary = null;
                this.gdMediaPlayer.Visibility = Visibility.Collapsed;
                flag = HideControl;
                if (flag.GetValueOrDefault())
                {
                    break;
                }
                if (8 != 0)
                {
                    goto Block_1;
                }
            }
            int arg_2A_0 = flag.HasValue ? 1 : 0;
            goto IL_28;
        Block_1:
            arg_2A_0 = 0;
        IL_28:
            if (arg_2A_0 != 0)
            {
                if (!false)
                {
                }
                this.testR.Visibility = Visibility.Visible;
                this.txtMainImage.Visibility = Visibility.Collapsed;
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            TransformGroup transformGroup;
            while (true)
            {
                base.UpdateLayout();
                while (true)
                {
                    SearchResult searchResult = (from Window wnd in System.Windows.Application.Current.Windows
                                                 where wnd.Title == "View/Order Station"
                                                 select wnd).Cast<SearchResult>().FirstOrDefault<SearchResult>();
                    if (this.imgNext.Visibility == Visibility.Visible)
                    {
                        goto IL_6B;
                    }
                    if (3 == 0)
                    {
                        break;
                    }
                    if (this.testR.Fill != null)
                    {
                        goto IL_6B;
                    }
                    goto IL_79;
                IL_7A:
                    int arg_7E_0;
                    if (5 != 0)
                    {
                        if (arg_7E_0 != 0)
                        {
                            goto IL_11A;
                        }
                        if (5 == 0)
                        {
                            continue;
                        }
                        transformGroup = new TransformGroup();
                        transformGroup.Children.Add(new RotateTransform(0.0));
                        this.img12.RenderTransform = transformGroup;
                        transformGroup.Children.Clear();
                        transformGroup.Children.Add(new RotateTransform(180.0));
                        transformGroup.Children.Add(new TranslateTransform(this.img12.ActualWidth, this.img12.ActualHeight));
                        if (!false)
                        {
                            goto Block_7;
                        }
                        goto IL_79;
                    }
                IL_77:
                    goto IL_7A;
                IL_6B:
                    bool expr_6C = (arg_7E_0 = (searchResult.isSingleScreenPreview ? 1 : 0)) != 0;
                    if (7 != 0)
                    {
                        arg_7E_0 = ((!expr_6C) ? 1 : 0);
                        goto IL_77;
                    }
                    goto IL_77;
                IL_79:
                    arg_7E_0 = 1;
                    goto IL_7A;
                }
            }
        Block_7:
            this.img12.RenderTransform = transformGroup;
        IL_119:
        IL_11A:
            if (3 != 0)
            {
                return;
            }
            goto IL_119;
        }

        private void btnPrintGroup_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Image image = (Image)this.btnPrintGroup.Content;
                LstMyItems lstMyItems = RobotImageLoader.GroupImages.First((LstMyItems t) => t.PhotoId == this._currentImageId);
                SearchResult searchResult = (from Window wnd in System.Windows.Application.Current.Windows
                                             where wnd.Title == "View/Order Station"
                                             select wnd).Cast<SearchResult>().FirstOrDefault<SearchResult>();
                if (searchResult != null)
                {
                    LstMyItems lstMyItems2 = RobotImageLoader.PrintImages.FirstOrDefault((LstMyItems t) => t.PhotoId == this._currentImageId);
                    if (lstMyItems2 == null)
                    {
                        LstMyItems lstMyItems3 = new LstMyItems();
                        lstMyItems3 = lstMyItems;
                        ItemCollection items = searchResult.lstImages.Items;
                        foreach (LstMyItems lstMyItems4 in ((IEnumerable)items))
                        {
                            if (lstMyItems4.PhotoId == lstMyItems.PhotoId)
                            {
                                searchResult.lstImages.SelectedItem = lstMyItems4;
                                break;
                            }
                        }
                        ListBoxItem listBoxItem = (ListBoxItem)searchResult.lstImages.ItemContainerGenerator.ContainerFromItem(searchResult.lstImages.SelectedItem);
                        if (listBoxItem != null)
                        {
                            lstMyItems3.FilePath = lstMyItems.FilePath;
                            lstMyItems3.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                            RobotImageLoader.PrintImages.Add(lstMyItems);
                            image.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                            lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                            ContentPresenter contentPresenter = this.FindVisualChild<ContentPresenter>(listBoxItem);
                            DataTemplate contentTemplate = contentPresenter.ContentTemplate;
                            Grid grid = (Grid)contentTemplate.FindName("grdMain", contentPresenter);
                            ((Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[0]).Content).Source = null;
                            ((Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[0]).Content).Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                            ((Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[0]).Content).UpdateLayout();
                            searchResult.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                        }
                    }
                    else
                    {
                        ItemCollection items = searchResult.lstImages.Items;
                        foreach (LstMyItems lstMyItems4 in ((IEnumerable)items))
                        {
                            if (lstMyItems4.PhotoId == lstMyItems.PhotoId)
                            {
                                searchResult.lstImages.SelectedItem = lstMyItems4;
                                break;
                            }
                        }
                        ListBoxItem listBoxItem = (ListBoxItem)searchResult.lstImages.ItemContainerGenerator.ContainerFromItem(searchResult.lstImages.SelectedItem);
                        if (listBoxItem != null)
                        {
                            if (!false)
                            {
                                RobotImageLoader.PrintImages.Remove(lstMyItems2);
                                image.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                            }
                            lstMyItems.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                            ContentPresenter contentPresenter = this.FindVisualChild<ContentPresenter>(listBoxItem);
                            DataTemplate contentTemplate = contentPresenter.ContentTemplate;
                            Grid grid = (Grid)contentTemplate.FindName("grdMain", contentPresenter);
                            ((Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[0]).Content).Source = null;
                            ((Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[0]).Content).Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                            ((Image)((System.Windows.Controls.Button)((Grid)grid.FindName("Printbtns")).Children[0]).Content).UpdateLayout();
                            searchResult.imgprintgroup.Source = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        }
                    }
                    if (searchResult.vwGroup.Text == "View All")
                    {
                        int num = (from groupImages in RobotImageLoader.GroupImages
                                   join printImages in RobotImageLoader.PrintImages on groupImages.PhotoId equals printImages.PhotoId
                                   select groupImages).Count<LstMyItems>();
                        searchResult.txtSelectImages.Text = "Selected : " + num.ToString() + "/" + RobotImageLoader.GroupImages.Count.ToString();
                        if (RobotImageLoader.GroupImages.Count == RobotImageLoader.PrintImages.Count)
                        {
                            searchResult.chkSelectAll.IsChecked = new bool?(true);
                        }
                        else
                        {
                            searchResult.chkSelectAll.IsChecked = new bool?(false);
                        }
                    }
                    else if (searchResult.vwGroup.Text == "View Group")
                    {
                        searchResult.txtSelectImages.Visibility = Visibility.Collapsed;
                        searchResult.txtSelectedImages.Visibility = Visibility.Visible;
                        searchResult.txtSelectedImages.Text = "Grouped : " + RobotImageLoader.GroupImages.Count;
                    }
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
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

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            base.WindowState = WindowState.Minimized;
            this.stkPrevNext.Visibility = Visibility.Collapsed;
            SearchResult searchResult;
            TransformGroup transformGroup2;
            MainWindow mainWindow;
            while (true)
            {
                this.stkPrint.Visibility = Visibility.Collapsed;
                TransformGroup transformGroup;
                if (this.FilpFrom == 1)
                {
                    searchResult = (from Window wnd in System.Windows.Application.Current.Windows
                                    where wnd.Title == "View/Order Station"
                                    select wnd).Cast<SearchResult>().FirstOrDefault<SearchResult>();
                    if (searchResult == null)
                    {
                        break;
                    }
                    if (false)
                    {
                        goto IL_17E;
                    }
                    if ((this.imgNext.Visibility != Visibility.Visible && this.testR.Fill == null) || !searchResult.isSingleScreenPreview)
                    {
                        break;
                    }
                    transformGroup = new TransformGroup();
                    transformGroup.Children.Add(new RotateTransform(0.0));
                    this.img12.LayoutTransform = transformGroup;
                    transformGroup2 = new TransformGroup();
                    transformGroup2.Children.Add(new RotateTransform(0.0));
                    if (true)
                    {
                        goto Block_7;
                    }
                }
                else
                {
                    if (this.FilpFrom == 2)
                    {
                        goto IL_17E;
                    }
                    break;
                }
            IL_264:
                transformGroup2 = new TransformGroup();
                transformGroup2.Children.Add(new RotateTransform(0.0));
                if (2 != 0)
                {
                    goto Block_13;
                }
                continue;
            IL_17E:
                mainWindow = null;
                foreach (Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.Title == "DigiMain")
                    {
                        mainWindow = (MainWindow)window;
                        break;
                    }
                    if (!false)
                    {
                    }
                }
                if (mainWindow == null)
                {
                    break;
                }
                if ((this.imgNext.Visibility != Visibility.Visible && this.testR.Fill == null) || !mainWindow.isSingleScreenPreview)
                {
                    break;
                }
                transformGroup = new TransformGroup();
                if (7 != 0)
                {
                    transformGroup.Children.Add(new RotateTransform(0.0));
                    this.img12.LayoutTransform = transformGroup;
                    goto IL_264;
                }
                goto IL_264;
            }
            return;
        Block_7:
            searchResult.ContentContainer.LayoutTransform = transformGroup2;
            searchResult.btnchkpreview.IsChecked = new bool?(false);
            searchResult.btnchkthumbpreview.IsChecked = new bool?(false);
            searchResult.PreviewPhoto();
            return;
        Block_13:
            mainWindow.ContentContainer.LayoutTransform = transformGroup2;
            mainWindow.btnchkpreview.IsChecked = new bool?(false);
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            do
            {
                WindowState windowState = base.WindowState;
                if (windowState != WindowState.Minimized)
                {
                    goto IL_1F;
                }
            IL_0E:
                if (false)
                {
                    continue;
                }
                this.btnMinimize_Click(sender, new RoutedEventArgs());
                if (!false)
                {
                }
            IL_1F:
                if (8 == 0)
                {
                    goto IL_0E;
                }
            }
            while (false);
        }

      
    }
}
