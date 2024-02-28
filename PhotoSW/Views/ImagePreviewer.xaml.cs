using PhotoSW.Common;
using DigiPhoto.DataLayer;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using FrameworkHelper;
using FrameworkHelper.Common;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using PhotoSW.DataLayer;

namespace PhotoSW.Views
{
    public partial class ImagePreviewer : Window, IComponentConnector//, IStyleConnector
    {
        private const string fileExtension = ".jpg";

        private string _mktImgPath = string.Empty;

        private int _mktImgTime = 0;

        private string filepath;

        private int count = 0;

        private static int ProcessedCount = 0;

        private string path = string.Empty;

        private string thumbnailspath = string.Empty;

        private string thumbnailsfolderpath = string.Empty;

        private string tumbnailsfolderbigpath = string.Empty;

        private Stopwatch stopwatch = new Stopwatch();

        private Dictionary<string, DateTime> img = new Dictionary<string, DateTime>();

        private Hashtable htpath = new Hashtable();

        private bool isVideoEditingEnabled = false;

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

        private string _filePath;

        private string _path = string.Empty;

        private string _thumbnailsPath = string.Empty;

        private string _tempVideoPath = string.Empty;

        private Dictionary<string, DownloadFileInfo> _img = new Dictionary<string, DownloadFileInfo>();

        public Hashtable htVidLength = new Hashtable();

        private Dictionary<string, string> _imagePath = new Dictionary<string, string>();

        private BusyWindow _busyWindows = new BusyWindow();

        public static string imgCount = string.Empty;

        private string DirPath = string.Empty;

        
        //private bool _contentLoaded;

        public ObservableCollection<MyImageClass> MyImages
        {
            get;
            set;
        }

        public ImagePreviewer()
        {
            this.InitializeComponent();
            this.lstImages.Items.Clear();
            this.GetConfigurationInfo();
            this.filepath = LoginUser.DigiFolderPath;
            string currentDirectory = Environment.CurrentDirectory;
            this.path = currentDirectory + "\\";
            this.path = Path.Combine(this.path, "Download\\");
            ConfigurationInfo configurationData = new ConfigBusiness().GetConfigurationData(LoginUser.SubStoreId);
            this._filePath = configurationData.DG_Hot_Folder_Path;
            this._path = Environment.CurrentDirectory + "\\";
            this._path = Path.Combine(this._path, "Download\\");
            this._thumbnailsPath = Path.Combine(this._path, "Temp\\");
            this._tempVideoPath = Path.Combine(Environment.CurrentDirectory, "DownloadVideo");
            if (Directory.Exists(this._path))
            {
                this.DeletePath(this._path);
            }
            this._busyWindows.Show();
            this._busyWindows.BringIntoView();
            this.ClearImages();
            this.CreateImages();
            this._busyWindows.Hide();
            this.btnBack.IsDefault = true;
           // this.VideoPlayer.ExecuteParentMethod += new EventHandler(this.ShowClientView);
        }

        private void ShowClientView(object sender, EventArgs e)
        {
            this.ShowToClientView();
        }

        private void ShowImages()
        {
            try
            {
                do
                {
                    this.lstImages.Items.Clear();
                    this.MyImages = new ObservableCollection<MyImageClass>();
                    this.MyImages.Clear();
                }
                while (false);
                Dictionary<string, DownloadFileInfo>.Enumerator enumerator = this._img.GetEnumerator();
                try
                {
                    while (true)
                    {
                        bool arg_ED_0 = enumerator.MoveNext();
                        bool expr_EF;
                        do
                        {
                            bool flag = arg_ED_0;
                            expr_EF = (arg_ED_0 = flag);
                        }
                        while (false);
                        if (!expr_EF)
                        {
                            break;
                        }
                        KeyValuePair<string, DownloadFileInfo> current = enumerator.Current;
                        try
                        {
                            while (true)
                            {
                                DownloadFileInfo value = current.Value;
                                string imagePath = string.Empty;
                                string fileNameWithoutExtension;
                                string title;
                                while (true)
                                {
                                    fileNameWithoutExtension = Path.GetFileNameWithoutExtension(value.fileName);
                                    title = fileNameWithoutExtension;
                                    if (!value.isVideo)
                                    {
                                        goto Block_7;
                                    }
                                    if (4 != 0)
                                    {
                                        goto Block_8;
                                    }
                                }
                            IL_D5:
                                if (!false)
                                {
                                    break;
                                }
                                continue;
                            Block_8:
                                imagePath = value.videoPath;
                                title = Path.GetFileNameWithoutExtension(title);
                                if (false)
                                {
                                    goto IL_D5;
                                }
                            IL_A3:
                                this.MyImages.Add(new MyImageClass(title, this.GetImageFromResourceString(fileNameWithoutExtension, value.filePath), false, value.CreatedDate, imagePath, value.fileExtension, null, null, SettingStatus.None, 0L));
                                goto IL_D5;
                            Block_7:
                                imagePath = value.filePath;
                                goto IL_A3;
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                finally
                {
                    if (!false && !false)
                    {
                        ((IDisposable)enumerator).Dispose();
                    }
                }
                this.lstImages.ItemsSource = this.MyImages;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private BitmapImage GetImageFromResourceString(string imageName)
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
            bitmapImage.UriSource = new Uri(this.path + imageName + ".jpg");
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

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
        //    ClientView clientView;
        //    if (8 != 0)
        //    {
        //        if (4 != 0)
        //        {
        //            this.GetMktImgInfo();
        //        }
        //        while (true)
        //        {
        //            clientView = null;
        //            IEnumerator<Window> enumerator = (from Window wnd in Application.Current.Windows
        //                                              where wnd.Title == "ClientView"
        //                                              select wnd).GetEnumerator();
        //            try
        //            {
        //                if (-1 != 0)
        //                {
        //                    goto IL_99;
        //                }
        //            IL_8A:
        //                clientView.watermark.Visibility = Visibility.Collapsed;
        //            IL_99:
        //                if (enumerator.MoveNext())
        //                {
        //                    Window current = enumerator.Current;
        //                    clientView = (ClientView)current;
        //                    clientView.tbkItemCount.Visibility = Visibility.Visible;
        //                    clientView.tbkItemCount.Text = " ";
        //                    goto IL_8A;
        //                }
        //            }
        //            finally
        //            {
        //                bool arg_AD_0 = enumerator == null;
        //                bool expr_AF;
        //                do
        //                {
        //                    bool flag = arg_AD_0;
        //                    expr_AF = (arg_AD_0 = flag);
        //                }
        //                while (false);
        //                if (!expr_AF)
        //                {
        //                    enumerator.Dispose();
        //                }
        //            }
        //            int arg_C5_0 = (clientView == null) ? 1 : 0;
        //            int arg_C5_1 = 0;
        //            while (true)
        //            {
        //                if (arg_C5_0 != arg_C5_1)
        //                {
        //                    if (false)
        //                    {
        //                        break;
        //                    }
        //                    clientView = new ClientView
        //                    {
        //                        WindowStartupLocation = WindowStartupLocation.Manual
        //                    };
        //                }
        //                clientView.GroupView = false;
        //                clientView.DefaultView = false;
        //                while (true)
        //                {
        //                    bool arg_117_0;
        //                    if (!(this._mktImgPath == string.Empty))
        //                    {
        //                        int expr_108 = arg_C5_0 = this._mktImgTime;
        //                        int expr_10E = arg_C5_1 = 0;
        //                        if (expr_10E != 0)
        //                        {
        //                            break;
        //                        }
        //                        arg_117_0 = (expr_108 == expr_10E);
        //                    }
        //                    else
        //                    {
        //                        arg_117_0 = true;
        //                    }
        //                    bool flag = arg_117_0;
        //                    if (true && !flag)
        //                    {
        //                        goto Block_9;
        //                    }
        //                    clientView.imgDefault.Visibility = Visibility.Visible;
        //                    if (!false)
        //                    {
        //                        goto IL_14F;
        //                    }
        //                }
        //            }
        //        }
        //    Block_9:
        //        clientView.instructionVideo.Visibility = Visibility.Visible;
        //        clientView.instructionVideo.Play();
        //    }
        //IL_14F:
        //    clientView.testR.Fill = null;
        //    clientView.DefaultView = true;
        //    if (clientView.instructionVideo.Visibility == Visibility.Visible)
        //    {
        //        clientView.instructionVideo.Play();
        //    }
        //    else
        //    {
        //        clientView.instructionVideo.Pause();
        //    }
            Home home = new Home();
            home.Show();
            //base.Close();
            //this.ClearImages();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (8 != 0)
            {
                this._busyWindows.Show();
                if (!false)
                {
                    this._busyWindows.BringIntoView();
                }
            }
        IL_1A:
            if (-1 != 0)
            {
                this.ShowImages();
                if (!false)
                {
                    this.ShowToClientView();
                }
                if (!false)
                {
                    this._busyWindows.Hide();
                }
                return;
            }
            goto IL_1A;
        }

        private void ClearImages()
        {
            try
            {
                bool arg_6C_0;
                bool expr_0D = arg_6C_0 = (this.MyImages == null);
                if (4 == 0)
                {
                    goto IL_6B;
                }
                bool flag = expr_0D;
            IL_17:
                if (!flag)
                {
                    Collection<MyImageClass> expr_1C3 = this.MyImages;
                    if (5 != 0)
                    {
                        expr_1C3.Clear();
                    }
                }
                int arg_40_0 = Directory.Exists(this.thumbnailspath) ? 1 : 0;
            IL_3F:
                string[] array=null;
                int num=0;
                if (arg_40_0 != 0)
                {
                    string[] files = Directory.GetFiles(this.thumbnailspath);
                    array = files;
                    num = 0;
                    goto IL_84;
                }
                goto IL_A6;
            IL_6B:
                if (arg_6C_0)
                {
                    string text="";
                    File.Delete(text);
                }
                num++;
            IL_84:
                bool arg_8C_0 = num < array.Length;
            IL_8C:
                if (arg_8C_0)
                {
                    string text = array[num];
                    arg_6C_0 = File.Exists(text);
                    goto IL_6B;
                }
                if (false)
                {
                    goto IL_19A;
                }
                Directory.Delete(this.thumbnailspath, true);
            IL_A5:
            IL_A6:
                int arg_180_0;
                int expr_AC = arg_180_0 = (Directory.Exists(this.path) ? 1 : 0);
                int arg_180_1;
                int expr_B2 = arg_180_1 = 0;
                if (expr_B2 != 0)
                {
                    goto IL_180;
                }
                flag = (expr_AC == expr_B2);
                string[] files2;
                if (!flag)
                {
                    files2 = Directory.GetFiles(this.path);
                    array = files2;
                    num = 0;
                    while (5 != 0)
                    {
                        if (num >= array.Length)
                        {
                            Directory.Delete(this.path, true);
                            goto IL_11E;
                        }
                        string text = array[num];
                        flag = !File.Exists(text);
                        if (!flag)
                        {
                            File.Delete(text);
                        }
                        num++;
                    }
                    goto IL_17;
                }
            IL_11E:
                if (!Directory.Exists(this._tempVideoPath))
                {
                    goto IL_19C;
                }
                files2 = Directory.GetFiles(this._tempVideoPath);
                array = files2;
                int expr_144 = arg_40_0 = 0;
                if (expr_144 != 0)
                {
                    goto IL_3F;
                }
                num = expr_144;
            IL_17A:
                arg_180_0 = num;
                arg_180_1 = array.Length;
            IL_180:
                flag = (arg_180_0 < arg_180_1);
                bool expr_184 = arg_8C_0 = flag;
                if (6 == 0)
                {
                    goto IL_8C;
                }
                if (!expr_184)
                {
                    Directory.Delete(this._tempVideoPath, true);
                }
                else
                {
                    if (3 != 0)
                    {
                        string text = ""; //array[num];
                        if (File.Exists(text))
                        {
                            File.Delete(text);
                        }
                        num++;
                        goto IL_17A;
                    }
                    goto IL_A5;
                }
            IL_19A:
            IL_19C: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void CreateImages()
        {
            int num = 0;
            int num2 = 0;
            string text = string.Empty;
            IEnumerable<DriveInfo> enumerable = DriveInfo.GetDrives().Where(delegate(DriveInfo drive)
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
            int arg_69_0;
            bool arg_AA_0 = ((enumerable == null) ? (arg_69_0 = 0) : (arg_69_0 = ((enumerable.Count<DriveInfo>() != 0) ? 1 : 0))) != 0;
            if (2 == 0)
            {
                goto IL_AA;
            }
            if (arg_69_0 != 0)
            {
                text = "USB";
                goto IL_BB;
            }
            enumerable = DriveInfo.GetDrives().Where(delegate(DriveInfo drive)
            {
                bool result;
                while (8 != 0)
                {
                    bool arg_36_0;
                    if (drive.DriveType == DriveType.CDRom)
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
            int arg_A1_0 = enumerable.Count<DriveInfo>();
            int arg_A1_1 = 0;
        IL_A1:
            bool flag = arg_A1_0 <= arg_A1_1;
            arg_AA_0 = flag;
        IL_AA:
            if (!arg_AA_0)
            {
                text = "CD";
            }
        IL_BB:
            int expr_BC = arg_A1_0 = enumerable.Count<DriveInfo>();
            int expr_C2 = arg_A1_1 = 0;
            if (expr_C2 == 0)
            {
                if (expr_BC > expr_C2)
                {
                    foreach (DriveInfo current in enumerable)
                    {
                        try
                        {
                            if (7 == 0)
                            {
                                goto IL_228;
                            }
                            this.DirPath = current.Name;
                            DirectoryInfo directoryInfo = new DirectoryInfo(current.Name);
                            FileInfo[] array = (from f in directoryInfo.EnumerateFiles("*.*", SearchOption.AllDirectories)
                                                where this.mediaExtensions.Contains(f.Extension.ToLower())
                                                select f).ToArray<FileInfo>();
                            bool arg_148_0 = array.Count<FileInfo>() > 0;
                            int arg_148_1 = 0;
                        IL_148:
                            if ((arg_148_0 ? 1 : 0) == arg_148_1)
                            {
                                MessageBox.Show("No file(s) found.");
                                base.Close();
                                continue;
                            }
                            flag = (array == null || array.Count<FileInfo>() <= 0);
                            if (true)
                            {
                                if (flag)
                                {
                                    goto IL_1AE;
                                }
                                flag = Directory.Exists(this._path);
                            }
                            if (!flag)
                            {
                                Directory.CreateDirectory(this._path);
                            }
                            flag = Directory.Exists(this._thumbnailsPath);
                        IL_19D:
                            if (!flag)
                            {
                                Directory.CreateDirectory(this._thumbnailsPath);
                            }
                        IL_1AE:
                            FileInfo[] array2 = array;
                        IL_1B3:
                            int num3 = 0;
                            goto IL_3DC;
                        IL_228:
                            FileInfo fileInfo;
                            this._img.Add(fileInfo.Name.ToLower(), new DownloadFileInfo
                            {
                                CreatedDate = fileInfo.CreationTime,
                                isVideo = false,
                                fileName = fileInfo.Name,
                                filePath = fileInfo.DirectoryName,
                                fileExtension = ".jpg"
                            });
                            num++;
                        IL_292:
                        IL_3D4:
                        IL_3D5:
                            int arg_3D9_0 = num3;
                        IL_3D8:
                            num3 = arg_3D9_0 + 1;
                        IL_3DC:
                            if (num3 >= array2.Length)
                            {
                                MessageBox.Show(string.Concat(new object[]
								{
									text,
									"-",
									array.Count<FileInfo>(),
									" File(s) found."
								}));
                                this.tbkItemCount.Text = array.Count<FileInfo>().ToString() + " Items";
                            }
                            else
                            {
                                fileInfo = array2[num3];
                                if (fileInfo.Name.Contains("Thumbs.db"))
                                {
                                    goto IL_3D5;
                                }
                                int expr_1EF = (arg_148_0 = fileInfo.Extension.ToLower().Equals(".jpg")) ? 1 : 0;
                                int expr_1F5 = arg_148_1 = 0;
                                if (expr_1F5 != 0)
                                {
                                    goto IL_148;
                                }
                                flag = (expr_1EF == expr_1F5);
                                if (!flag)
                                {
                                    if (6 == 0)
                                    {
                                        goto IL_19D;
                                    }
                                    bool expr_217 = (arg_3D9_0 = (this._img.ContainsKey(fileInfo.Name) ? 1 : 0)) != 0;
                                    if (false)
                                    {
                                        goto IL_3D8;
                                    }
                                    if (!expr_217)
                                    {
                                        goto IL_228;
                                    }
                                    goto IL_292;
                                }
                                else
                                {
                                    string text2 = string.Empty;
                                    text2 = MLHelpers.ExtractThumbnail(fileInfo.FullName);
                                    if (!string.IsNullOrEmpty(text2))
                                    {
                                        MLHelpers.ResizeImage(text2, 210, this._path + fileInfo.Name + ".jpg");
                                    }
                                    long num4 = Convert.ToInt64(MLHelpers.VideoLength);
                                    if (!this.htVidLength.ContainsKey(fileInfo.Name))
                                    {
                                        this.htVidLength.Add(fileInfo.Name, num4);
                                    }
                                    flag = this._img.ContainsKey(fileInfo.Name);
                                    if (!false)
                                    {
                                        if (!flag)
                                        {
                                            this._img.Add(fileInfo.Name.ToLower(), new DownloadFileInfo
                                            {
                                                CreatedDate = fileInfo.CreationTime,
                                                isVideo = true,
                                                fileName = fileInfo.Name + ".jpg",
                                                filePath = this._path,
                                                videoPath = fileInfo.DirectoryName,
                                                fileExtension = fileInfo.Extension,
                                                drivePath = fileInfo.DirectoryName
                                            });
                                            num2++;
                                        }
                                        goto IL_3D4;
                                    }
                                    goto IL_1B3;
                                }
                            }
                        }
                        catch (Exception serviceException)
                        {
                            ErrorHandler.ErrorHandler.LogError(serviceException);
                        }
                    }
                    GC.Collect();
                    GC.AddMemoryPressure(20000L);
                }
                else
                {
                    MessageBox.Show("No drive(s) found.");
                    base.Close();
                }
                return;
            }
            goto IL_A1;
        }

        private void ExtractThumbnailFromVideo(string mediaFile, int waitTime, int position, string acquiredPath)
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            mediaPlayer.Volume = 0.0;
            MediaPlayer mediaPlayer2;
            Duration naturalDuration=new Duration ();
            int arg_11D_0;
            int arg_11D_1;
            RenderTargetBitmap renderTargetBitmap=null;
            while (true)
            {
                mediaPlayer.ScrubbingEnabled = true;
                int arg_6E_0;
                if (!false)
                {
                    mediaPlayer2 = mediaPlayer;
                    mediaPlayer2.Open(new Uri(mediaFile));
                    mediaPlayer2.Pause();
                    if (2 != 0)
                    {
                        mediaPlayer2.Position = TimeSpan.FromSeconds((double)position);
                        arg_6E_0 = waitTime * 1000;
                        goto IL_6E;
                    }
                    goto IL_198;
                }
            IL_FE:
                naturalDuration = mediaPlayer2.NaturalDuration;
                if ((arg_6E_0 = 0) == 0)
                {
                    if (true)
                    {
                        break;
                    }
                    continue;
                }
            IL_6E:
                Thread.Sleep(arg_6E_0);
                int expr_74 = arg_11D_0 = 120;
                int expr_78 = arg_11D_1 = 90;
                if (expr_78 != 0)
                {
                    renderTargetBitmap = new RenderTargetBitmap(expr_74, expr_78, 96.0, 96.0, PixelFormats.Pbgra32);
                    DrawingVisual drawingVisual = new DrawingVisual();
                    DrawingContext drawingContext = drawingVisual.RenderOpen();
                    try
                    {
                        drawingContext.DrawVideo(mediaPlayer2, new Rect(0.0, 0.0, 120.0, 90.0));
                    }
                    finally
                    {
                        if (drawingContext != null)
                        {
                            ((IDisposable)drawingContext).Dispose();
                            if (false || true)
                            {
                            }
                        }
                    }
                    renderTargetBitmap.Render(drawingVisual);
                    goto IL_FE;
                }
                goto IL_11D;
            }
            arg_11D_0 = (naturalDuration.HasTimeSpan ? 1 : 0);
            arg_11D_1 = 0;
        IL_11D:
            if (arg_11D_0 != arg_11D_1)
            {
                int num = (int)naturalDuration.TimeSpan.TotalSeconds;
            }
            BitmapFrame item = BitmapFrame.Create(renderTargetBitmap).GetCurrentValueAsFrozen() as BitmapFrame;
            BitmapEncoder bitmapEncoder = new JpegBitmapEncoder();
            bitmapEncoder.Frames.Add(item);
            MemoryStream memoryStream = new MemoryStream();
            bitmapEncoder.Save(memoryStream);
            FileStream fileStream = new FileStream(acquiredPath, FileMode.Create, FileAccess.Write);
            memoryStream.WriteTo(fileStream);
            fileStream.Close();
            memoryStream.Close();
        IL_198:
            mediaPlayer2.Close();
        }

        public void ShowToClientView()
        {
            if (!false)
            {
                try
                {
                    do
                    {
                        VisualBrush compiledBitmapImage = new VisualBrush(this.ThumbPreview);
                        SearchResult searchResult = new SearchResult();
                        searchResult.CompileEffectChanged(compiledBitmapImage, -1);
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

        private void GetMktImgInfo()
        {
            try
            {
                List<long> objList = new List<long>();
                objList.Add(24L);
                if (false)
                {
                    goto IL_B7;
                }
                objList.Add(25L);
                if (false)
                {
                    goto IL_131;
                }
                List<iMIXConfigurationInfo> list = (from o in new ConfigBusiness().GetNewConfigValues(LoginUser.SubStoreId)
                                                    where objList.Contains(o.IMIXConfigurationMasterId)
                                                    select o).ToList<iMIXConfigurationInfo>();
            IL_73:
                int arg_86_0;
                if (list == null)
                {
                    arg_86_0 = ((list.Count <= 0) ? 1 : 0);
                }
                else
                {
                    arg_86_0 = 0;
                }
            IL_82:
                bool flag = arg_86_0 != 0;
                if (flag)
                {
                    goto IL_131;
                }
                int num = 0;
                if (!false)
                {
                    goto IL_11E;
                }
                goto IL_73;
            IL_B7:
                long iMIXConfigurationMasterId;
                int expr_BD = arg_86_0 = (int)(iMIXConfigurationMasterId - 24L);
                if (false)
                {
                    goto IL_82;
                }
                switch (expr_BD)
                {
                    case 0:
                        this._mktImgPath = list[num].ConfigurationValue;
                        break;
                    case 1:
                        this._mktImgTime = ((list[num].ConfigurationValue != null) ? Convert.ToInt32(list[num].ConfigurationValue) : 10) * 1000;
                        break;
                }
            IL_CE:
            IL_E2:
            IL_116:
                if (false)
                {
                    goto IL_129;
                }
                num++;
            IL_11E:
                flag = (num < list.Count);
            IL_129:
                if (flag)
                {
                    iMIXConfigurationMasterId = list[num].IMIXConfigurationMasterId;
                    if (iMIXConfigurationMasterId > 25L)
                    {
                        goto IL_CE;
                    }
                    if (iMIXConfigurationMasterId >= 24L)
                    {
                        goto IL_B7;
                    }
                    goto IL_116;
                }
            IL_131:
                if (8 == 0)
                {
                    goto IL_E2;
                }
            }
            catch (Exception serviceException)
            {
                while (!true)
                {
                }
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void vidPlay_Click(object sender, RoutedEventArgs e)
        {
            string vidFileName = ((BitmapImage)((Image)((Grid)((Button)e.Source).Parent).FindName("thumbImage")).Source).UriSource.OriginalString.ToLower();
            vidFileName = this.Preview(vidFileName);
        }

        private string Preview(string vidFileName)
        {
            return "";
        //    if (vidFileName.EndsWith("avi.jpg") || vidFileName.EndsWith("mp4.jpg") || vidFileName.EndsWith("wmv.jpg") || vidFileName.EndsWith("mov.jpg") || vidFileName.EndsWith("3gp.jpg") || vidFileName.EndsWith("3g2.jpg") || vidFileName.EndsWith("m2v.jpg") || vidFileName.EndsWith("m4v.jpg"))
        //    {
        //        goto IL_CA;
        //    }
        //IL_86:
        //    bool arg_CC_0;
        //    if (!vidFileName.EndsWith("flv.jpg") && !vidFileName.EndsWith("mpg.jpg") && !vidFileName.EndsWith("ffmpeg.jpg") && !vidFileName.EndsWith("mkv.jpg"))
        //    {
        //        arg_CC_0 = !vidFileName.EndsWith("mts.jpg");
        //        goto IL_CB;
        //    }
        //IL_CA:
        //    arg_CC_0 = false;
        //IL_CB:
        //    bool flag = arg_CC_0;
        //    if (8 != 0)
        //    {
        //        if (!false)
        //        {
        //            if (!flag)
        //            {
        //                if (5 != 0)
        //                {
        //                    vidFileName = vidFileName.Replace(".jpg", string.Empty);
        //                }
        //                this.VideoPlayer.Visibility = Visibility.Visible;
        //                vidFileName = Path.GetFileName(vidFileName);
        //                DownloadFileInfo downloadFileInfo = this._img[vidFileName];
        //                VideoPlayer.vsMediaFileName = downloadFileInfo.drivePath + "\\" + downloadFileInfo.fileName.ToString().Replace(".jpg", "");
        //                if (3 == 0)
        //                {
        //                    goto IL_CA;
        //                }
        //                this.VideoPlayer.Title = Path.GetFileName(vidFileName);
        //            }
        //            else
        //            {
        //                this.VideoPlayer.Title = Path.GetFileNameWithoutExtension(vidFileName);
        //                if (!false)
        //                {
        //                    goto IL_18E;
        //                }
        //                goto IL_1AD;
        //            }
        //        }
        //        if (!false)
        //        {
        //            this.VideoPlayer.SetParent(this);
        //            if (!false)
        //            {
        //                return vidFileName;
        //            }
        //            goto IL_1AE;
        //        }
        //    IL_18E:
        //        this.VideoPlayer.imagesource = this.GetImageFromPath(vidFileName);
        //        this.VideoPlayer.Visibility = Visibility.Visible;
        //    IL_1AD:
        //    IL_1AE:
        //        this.VideoPlayer.SetParent(this);
        //        return vidFileName;
        //    }
        //    goto IL_86;
        }

        public BitmapImage GetImageFromPath(string path)
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

        private void Selectedimages_Click(object sender, RoutedEventArgs e)
        {
            string vidFileName = ((BitmapImage)((Image)((Grid)((CheckBox)e.Source).Parent).FindName("thumbImage")).Source).UriSource.OriginalString.ToLower();
            vidFileName = this.Preview(vidFileName);
        }

        private void GetConfigurationInfo()
        {
            try
            {
                List<long> objList = new List<long>();
                objList.Add(24L);
                objList.Add(25L);
                objList.Add(48L);
                objList.Add(101L);
                objList.Add(99L);
                objList.Add(100L);
                List<iMIXConfigurationInfo> list = (from o in new ConfigBusiness().GetNewConfigValues(LoginUser.SubStoreId)
                                                    where objList.Contains(o.IMIXConfigurationMasterId)
                                                    select o).ToList<iMIXConfigurationInfo>();
                if (list != null)
                {
                    goto IL_B8;
                }
                int arg_B1_0 = list.Count;
            IL_B0:
                bool arg_BD_0 = arg_B1_0 <= 0;
            IL_B6:
                goto IL_B9;
            IL_B8:
                arg_BD_0 = false;
            IL_B9:
                if (false)
                {
                    goto IL_B6;
                }
                if (!arg_BD_0)
                {
                    if (8 == 0)
                    {
                        goto IL_B8;
                    }
                    int num = 0;
                    while (true)
                    {
                        bool flag = num < list.Count;
                        bool expr_11E = (arg_B1_0 = (flag ? 1 : 0)) != 0;
                        if (false)
                        {
                            goto IL_B0;
                        }
                        if (!expr_11E)
                        {
                            break;
                        }
                        long iMIXConfigurationMasterId = list[num].IMIXConfigurationMasterId;
                        if (iMIXConfigurationMasterId == 48L)
                        {
                            this.isVideoEditingEnabled = (list[num].ConfigurationValue != null && Convert.ToBoolean(list[num].ConfigurationValue));
                        }
                        num++;
                    }
                }
            }
            catch (Exception serviceException)
            {
                while (2 != 0)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    if (2 != 0)
                    {
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                        break;
                    }
                }
                while (false)
                {
                }
            }
            while (false)
            {
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
                    string text = array2[i];
                    try
                    {
                        if (!false)
                        {
                            if (!File.Exists(text))
                            {
                                goto IL_56;
                            }
                            File.Delete(text);
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


    }
}
