using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using DigiPhoto.Cache.DataCache;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
//using PhotoSW.CF.DataLayer;
using PhotoSW.Views;
namespace PhotoSW
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //private delegate int LowLevelKeyboardProcDelegate(int nCode, int wParam, ref App.KBDLLHOOKSTRUCT lParam);



        private const int WH_KEYBOARD_LL = 13;

        private const int SPI_SETSCREENSAVETIMEOUT = 15;

        private BackgroundWorker worker;
        /// <summary>
        /// //////////////////////
        /// </summary>
        public static int ViewOrderSearchIndex;

        public static int SelectedCodeType;

        public static string QRCodeWebUrl;

        public static string DataSyncServiceURl;

        public static bool IsAnonymousQrCodeEnabled;

        public static bool IsRFIDEnabled;

        public static int? RfidScanType;

        public static int tripCamCleanUpDays;

        public static int iMIXCleanUpDays;

        private IntPtr intLLKey;

        //[STAThread]
        //public static void Main()
        //{
        //    App app = new App();
        //    app.InitializeComponent();
        //    app.Run();
        //    //MainWindow MainWindow = new MainWindow();
        //    //MainWindow.ShowDialog();
        //}
        /////////////////////////////////////////
        //private static App.LowLevelKeyboardProcDelegate mHookProc;
        //private bool _contentLoaded;
        public App()
        {
            InitializeComponent();
            PhotoSW.Views.SplashScreen splash = new PhotoSW.Views.SplashScreen();
            splash.Show();
            // Step 2 - Start a stop watch  
            Stopwatch timer = new Stopwatch();
            timer.Start();

            // Step 3 - Load your windows but don't show it yet  
           // base.OnStartup(e);
            Login main = new Login();
            timer.Stop();

            int remainingTimeToShowSplash = MINIMUM_SPLASH_TIME - (int)timer.ElapsedMilliseconds;
            if (remainingTimeToShowSplash > 0)
                Thread.Sleep(remainingTimeToShowSplash);

            splash.Close();
        }
        public static string ExecutablePath
        {
            get
            {
                return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            }
        }

        public bool IsCameraConnected
        {
            get;
            set;
        }

        public string CameraSerialNumber
        {
            get;
            set;
        }

        public string ModelNumber
        {
            get;
            set;
        }

        //[DllImport("kernel32.dll")]
        //private static extern IntPtr GetModuleHandle(IntPtr path);

        //[DllImport("user32.dll", CharSet = CharSet.Ansi, EntryPoint = "SetWindowsHookExA")]
        //private static extern IntPtr SetWindowsHookEx(int idHook, App.LowLevelKeyboardProcDelegate lpfn, IntPtr hMod, int dwThreadId);

        //[DllImport("user32.dll", CharSet = CharSet.Ansi)]
        //private static extern int CallNextHookEx(int hHook, int nCode, int wParam, ref App.KBDLLHOOKSTRUCT lParam);

        //[DllImport("user32.dll")]
        //private static extern IntPtr UnhookWindowsHookEx(IntPtr hHook);

        //[DllImport("user32", CharSet = CharSet.Auto, SetLastError = true)]
        //private static extern int SystemParametersInfo(int uiAction, int uiParam, int pvParam, int fWinIni);

        private const int MINIMUM_SPLASH_TIME = 2500; // Miliseconds 
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //this.LoadMD3Files();
            //DataCacheFactory.Register();
            try
            {
                /////////////////new Code
                PhotoSW.Views.SplashScreen splash = new PhotoSW.Views.SplashScreen();
                splash.Show();
                // Step 2 - Start a stop watch  
                Stopwatch timer = new Stopwatch();
                timer.Start();

                // Step 3 - Load your windows but don't show it yet  
                base.OnStartup(e);
                Login main = new Login();
                timer.Stop();

                int remainingTimeToShowSplash = MINIMUM_SPLASH_TIME - (int)timer.ElapsedMilliseconds;
                if (remainingTimeToShowSplash > 0)
                    Thread.Sleep(remainingTimeToShowSplash);

                splash.Close();
                /////////////////
              
            //    object obj = "";
            //    string hostName = Dns.GetHostName();
            //    string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
            //    ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name FROM Win32_ComputerSystem");
            //    if (!false)
            //    {
            //        using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
            //        {
            //            while (enumerator.MoveNext())
            //            {
            //                ManagementObject managementObject = (ManagementObject)enumerator.Current;
            //                obj = managementObject["Name"];
            //            }
            //        }
            //        if (8 != 0)
            //        {
            //            ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
            //            IEnumerable<ManagementObject> source = managementObjectSearcher2.Get().Cast<ManagementObject>();
            //            string mac = (from o in source
            //                          orderby o["IPConnectionMetric"]
            //                          select o["MACAddress"].ToString()).FirstOrDefault<string>();
            //            ServicePosInfoBusiness servicePosInfoBusiness = new ServicePosInfoBusiness();
            //            string systemName = obj.ToString();
            //            servicePosInfoBusiness.StartStopSystemBusiness(mac, myIP, systemName, 1);
            //            this.worker = new BackgroundWorker();
            //            this.worker.DoWork += new DoWorkEventHandler(this.worker_DoWork_AppDataCleanUp);
            //        }
            //        this.worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted_AppDataCleanUp);
            //        Timeline.DesiredFrameRateProperty.OverrideMetadata(typeof(Timeline), new FrameworkPropertyMetadata
            //        {
            //            DefaultValue = 5
            //        });
            //        int uiParam = ConfigurationManager.AppSettings["NeverSleepTimeInMinutes"].ToInt32(false);
            //        App.SystemParametersInfo(15, uiParam, 0, 0);
            //        try
            //        {
            //            ConfigurationInfo configurationData;
            //            List<string> list;
            //            CameraBusiness cameraBusiness;
            //            do
            //            {
            //                //Splasher.Splash = new SplashScreen();
            //                //Splasher.ShowSplash();
            //                using (StreamReader streamReader = new StreamReader(Environment.CurrentDirectory + "\\ss.dat"))
            //                {
            //                    string cipherString = streamReader.ReadLine();
            //                    string text = CryptorEngine.Decrypt(cipherString, true);
            //                    LoginUser.SubStoreId = text.Split(new char[]
            //                    {
            //                        ','
            //                    })[0].ToInt32(false);
            //                }
            //                ConfigBusiness configBusiness = new ConfigBusiness();
            //                configurationData = configBusiness.GetConfigurationData(LoginUser.SubStoreId);
            //                //  ErrorHandler.LogFileWrite("Substore ID :- " + LoginUser.SubStoreId.ToString());
            //                list = new List<string>();
            //                cameraBusiness = new CameraBusiness();
            //            }
            //            while (6 == 0);
            //            using (List<CameraInfo>.Enumerator enumerator2 = cameraBusiness.GetAvailableRideCameras().GetEnumerator())
            //            {
            //                while (true)
            //                {
            //                IL_2AB:
            //                    bool flag = enumerator2.MoveNext();
            //                    while (flag)
            //                    {
            //                        CameraInfo current = enumerator2.Current;
            //                        if (!false)
            //                        {
            //                            list.Add(current.RideCameras);
            //                            goto IL_2AB;
            //                        }
            //                    }
            //                    break;
            //                }
            //            }
            //            int num = ConfigurationManager.AppSettings["DeletedOldImages"].ToInt32(false);
            //            object obj2 = configurationData;
            //            object obj3 = list;
            //            object obj4 = num;
            //            object[] argument = new object[]
            //            {
            //                obj2,
            //                obj3,
            //                obj4
            //            };
            //            this.worker.RunWorkerAsync(argument);
            //        }
            //        catch (Exception serviceException)
            //        {
            //            //string message = ErrorHandler.CreateErrorMessage(serviceException);
            //            //ErrorHandler.LogFileWrite(message);
            //        }
            //        this.DigiStartup(this, e);
            //        Splasher.Splash.Hide();
            //        this.CheckUpdate();
            //        App.RegisterSystem();
            //        global::ChromaKeypluginLic.IntializeProtection();
            //        global::DecoderlibLic.IntializeProtection();
            //    }
            //    global::EncoderlibLic.IntializeProtection();
            //    global::MComposerlibLic.IntializeProtection();
            //    global::MPlatformSDKLic.IntializeProtection();
            }
            catch (Exception serviceException)
            {
                //string message = ErrorHandler.CreateErrorMessage(serviceException);
                //ErrorHandler.LogFileWrite(message);
            }
        }

        //private void worker_DoWork_AppDataCleanUp(object sender, DoWorkEventArgs e)
        //{
        //    if (!false && -1 == 0)
        //    {
        //        goto IL_12;
        //    }
        //IL_07:
        //    object[] array = e.Argument as object[];
        //IL_12:
        //    ConfigurationInfo objdata = (ConfigurationInfo)array[0];
        //    if (!false)
        //    {
        //        List<string> mylistCam = (List<string>)array[1];
        //        int olderthandays = (int)array[2];
        //        do
        //        {
        //            this.GetStoreConfigData();
        //        }
        //        while (5 == 0);
        //        this.AppDataCleanUp(objdata, mylistCam, olderthandays);
        //        e.Result = true;
        //        return;
        //    }
        //    goto IL_07;
        //}

        //private void worker_RunWorkerCompleted_AppDataCleanUp(object sender, RunWorkerCompletedEventArgs e)
        //{
        //}

        //private void AppDataCleanUp(ConfigurationInfo _objdata, List<string> mylistCam, int olderthandays)
        //{
        //    if (_objdata != null)
        //    {
        //        string arg_9B3_0 = _objdata.DG_Hot_Folder_Path;
        //        string arg_9B3_1 = "\\";
        //        DateTime now = DateTime.Now;
        //        string path = arg_9B3_0 + arg_9B3_1 + now.ToString("yyyyMMdd");
        //        if (!Directory.Exists(path))
        //        {
        //            Directory.CreateDirectory(path);
        //        }
        //        string path2 = _objdata.DG_Hot_Folder_Path + "\\PrintImages";
        //        string path3 = _objdata.DG_Hot_Folder_Path + "\\PrintImages\\Email";
        //        string path4 = Environment.CurrentDirectory + "\\DigiOrderdImages";
        //        string text = _objdata.DG_Hot_Folder_Path + "\\Archived";
        //        string path5 = _objdata.DG_Hot_Folder_Path + "\\Camera\\RideCamera";
        //        string dG_Hot_Folder_Path = _objdata.DG_Hot_Folder_Path;
        //        string str = _objdata.DG_Hot_Folder_Path + "\\Thumbnails\\";
        //        string str2 = _objdata.DG_Hot_Folder_Path + "\\Thumbnails_Big\\";
        //        string str3 = _objdata.DG_Hot_Folder_Path + "\\Croped\\";
        //        string path6 = Path.Combine(_objdata.DG_Hot_Folder_Path, "EditedImages");
        //        string path7 = _objdata.DG_Hot_Folder_Path + "\\Thumbnails\\Temp\\";
        //        string path8 = _objdata.DG_Hot_Folder_Path + "\\MobileTags\\Processed\\";
        //        int num = 1;
        //        // ErrorHandler.LogFileWrite("No of days  :- " + olderthandays.ToString());
        //        List<string> list = new List<string>();
        //        list = this.GetImagesToDelete(dG_Hot_Folder_Path, olderthandays);
        //        FileInfo fileInfo;
        //        if (list.Count > 0)
        //        {
        //            foreach (string current in list)
        //            {
        //                //  ErrorHandler.LogFileWrite("Hot Folder Count :- " + list.Count<string>().ToString());
        //                fileInfo = new FileInfo(current);
        //                try
        //                {
        //                    PhotoBusiness photoBusiness = new PhotoBusiness();
        //                    photoBusiness.SetArchiveDetails(fileInfo.Name);
        //                    fileInfo.Delete();
        //                    fileInfo = new FileInfo(str + current);
        //                    fileInfo.Delete();
        //                    fileInfo = new FileInfo(str2 + current);
        //                    fileInfo.Delete();
        //                    fileInfo = new FileInfo(str3 + current);
        //                    fileInfo.Delete();
        //                    Thread.Sleep(1);
        //                }
        //                catch
        //                {
        //                    // ErrorHandler.LogFileWrite("In use : -" + fileInfo.Name.ToString());
        //                    continue;
        //                }
        //                num++;
        //            }
        //        }
        //        if (Directory.Exists(path6))
        //        {
        //            DirectoryInfo directoryInfo = new DirectoryInfo(path6);
        //            directoryInfo.GetFiles().ToList<FileInfo>().Where(delegate(FileInfo t)
        //            {
        //                bool result;
        //                while (4 != 0)
        //                {
        //                    result = (t.CreationTime < DateTime.Now.AddDays((double)(-(double)App.iMIXCleanUpDays)));
        //                    if (!false)
        //                    {
        //                        break;
        //                    }
        //                }
        //                return result;
        //            }).ToList<FileInfo>().ForEach(delegate(FileInfo f)
        //            {
        //                f.Delete();
        //            });
        //        }
        //        if (Directory.Exists(path8))
        //        {
        //            int deleteddayleft = ConfigurationManager.AppSettings["DeletedProcessedMobileTags"].ToInt32(false);
        //            DirectoryInfo directoryInfo = new DirectoryInfo(path8);
        //            directoryInfo.GetFiles().ToList<FileInfo>().Where(delegate(FileInfo t)
        //            {
        //                bool arg_26_0;
        //                bool arg_4C_0 = arg_26_0 = (t.CreationTime < DateTime.Now.AddDays((double)(-(double)deleteddayleft)));
        //                do
        //                {
        //                    if (5 != 0)
        //                    {
        //                        bool flag2 = arg_4C_0;
        //                        arg_4C_0 = (arg_26_0 = flag2);
        //                    }
        //                }
        //                while (3 == 0 || false);
        //                return arg_26_0;
        //            }).ToList<FileInfo>().ForEach(delegate(FileInfo f)
        //            {
        //                f.Delete();
        //            });
        //        }
        //        num = 1;
        //        if (!Directory.Exists(path2))
        //        {
        //            goto IL_4DB;
        //        }
        //        string[] files = Directory.GetFiles(path2);
        //    IL_37C:
        //       // ErrorHandler.LogFileWrite("PrintImages Count :- " + files.Count<string>().ToString());
        //        string[] array;
        //        int i;
        //        if (files.Count<string>() > 0)
        //        {
        //            array = files;
        //            for (i = 0; i < array.Length; i++)
        //            {
        //                string fileName = array[i];
        //                fileInfo = new FileInfo(fileName);
        //                DateTime arg_3E7_0 = fileInfo.CreationTime;
        //                now = DateTime.Now;
        //                if (arg_3E7_0 < now.AddDays((double)(-(double)App.iMIXCleanUpDays)))
        //                {
        //                    try
        //                    {
        //                        fileInfo.Delete();
        //                    }
        //                    catch (Exception var_22_402)
        //                    {
        //                    }
        //                    Thread.Sleep(1);
        //                }
        //                num++;
        //            }
        //        }
        //        string[] directories = Directory.GetDirectories(path2);
        //        array = directories;
        //        int arg_62E_0;
        //        int expr_43B = arg_62E_0 = 0;
        //        if (expr_43B != 0)
        //        {
        //            goto IL_62E;
        //        }
        //        for (i = expr_43B; i < array.Length; i++)
        //        {
        //            string text2 = array[i];
        //            DirectoryInfo directoryInfo2 = new DirectoryInfo(text2);
        //            DateTime arg_475_0 = directoryInfo2.CreationTime;
        //            now = DateTime.Now;
        //            if (arg_475_0 < now.AddDays((double)(-(double)App.iMIXCleanUpDays)))
        //            {
        //                try
        //                {
        //                    if (directoryInfo2.Name != "Email")
        //                    {
        //                        Directory.Delete(text2, true);
        //                    }
        //                }
        //                catch (Exception var_22_402)
        //                {
        //                }
        //                Thread.Sleep(1);
        //            }
        //            num++;
        //        }
        //    IL_4DB:
        //        num = 1;
        //        bool arg_900_0;
        //        if (Directory.Exists(path3))
        //        {
        //            string[] directories2 = Directory.GetDirectories(path3);
        //            array = directories2;
        //            for (i = 0; i < array.Length; i++)
        //            {
        //                string text2 = array[i];
        //                DirectoryInfo directoryInfo2 = new DirectoryInfo(text2);
        //                DateTime arg_530_0 = directoryInfo2.CreationTime;
        //                now = DateTime.Now;
        //                bool flag = !(arg_530_0 < now.AddDays((double)(-(double)App.iMIXCleanUpDays)));
        //                bool expr_53A = arg_900_0 = flag;
        //                if (5 == 0)
        //                {
        //                    goto IL_900;
        //                }
        //                if (!expr_53A)
        //                {
        //                    try
        //                    {
        //                        Directory.Delete(text2, true);
        //                    }
        //                    catch (Exception var_22_402)
        //                    {
        //                    }
        //                    if (false)
        //                    {
        //                        goto IL_37C;
        //                    }
        //                    Thread.Sleep(1);
        //                }
        //                num++;
        //            }
        //        }
        //        num = 1;
        //        if (Directory.Exists(path4))
        //        {
        //            string[] files2 = Directory.GetFiles(path4);
        //            array = files2;
        //            for (i = 0; i < array.Length; i++)
        //            {
        //                string fileName = array[i];
        //                fileInfo = new FileInfo(fileName);
        //                DateTime arg_5DB_0 = fileInfo.CreationTime;
        //                now = DateTime.Now;
        //                if (arg_5DB_0 < now.AddDays((double)(-(double)App.iMIXCleanUpDays)))
        //                {
        //                    try
        //                    {
        //                        fileInfo.Delete();
        //                    }
        //                    catch (Exception var_22_402)
        //                    {
        //                    }
        //                    Thread.Sleep(1);
        //                }
        //                num++;
        //            }
        //        }
        //        num = 1;
        //        arg_62E_0 = ((!Directory.Exists(path5)) ? 1 : 0);
        //    IL_62E:
        //        if (arg_62E_0 == 0)
        //        {
        //            DirectoryInfo directoryInfo3 = new DirectoryInfo(path5);
        //            if (directoryInfo3.Exists)
        //            {
        //                IEnumerable<FileInfo> source = directoryInfo3.EnumerateFiles("*.jpg", SearchOption.TopDirectoryOnly);
        //                source = source.Where(delegate(FileInfo t)
        //                {
        //                    bool result;
        //                    while (4 != 0)
        //                    {
        //                        result = (t.CreationTime < DateTime.Now.AddDays((double)(-(double)App.tripCamCleanUpDays)));
        //                        if (!false)
        //                        {
        //                            break;
        //                        }
        //                    }
        //                    return result;
        //                });
        //                if (source.Count<FileInfo>() > 36)
        //                {
        //                    IEnumerator<FileInfo> enumerator2 = (from t in source
        //                                                         orderby t.CreationTime
        //                                                         select t).Take(source.Count<FileInfo>() - 36).GetEnumerator();
        //                    try
        //                    {
        //                        while (true)
        //                        {
        //                            bool arg_718_0 = enumerator2.MoveNext();
        //                            bool expr_71A;
        //                            do
        //                            {
        //                                bool flag = arg_718_0;
        //                                expr_71A = (arg_718_0 = flag);
        //                            }
        //                            while (false);
        //                            if (!expr_71A)
        //                            {
        //                                break;
        //                            }
        //                            FileInfo current2 = enumerator2.Current;
        //                            try
        //                            {
        //                                current2.Delete();
        //                            }
        //                            catch (Exception var_22_402)
        //                            {
        //                            }
        //                            do
        //                            {
        //                                Thread.Sleep(1);
        //                            }
        //                            while (false);
        //                            num++;
        //                        }
        //                    }
        //                    finally
        //                    {
        //                        if (enumerator2 == null)
        //                        {
        //                            goto IL_736;
        //                        }
        //                    IL_72E:
        //                        enumerator2.Dispose();
        //                    IL_736:
        //                        if (2 == 0)
        //                        {
        //                            goto IL_72E;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //        num = 1;
        //        if (mylistCam != null)
        //        {
        //            using (List<string>.Enumerator enumerator = mylistCam.GetEnumerator())
        //            {
        //                while (true)
        //                {
        //                IL_87A:
        //                    bool flag = enumerator.MoveNext();
        //                    while (flag)
        //                    {
        //                        string text2 = enumerator.Current;
        //                        if (true)
        //                        {
        //                            DirectoryInfo directoryInfo3 = new DirectoryInfo(_objdata.DG_Hot_Folder_Path + "\\Camera\\" + text2);
        //                            if (directoryInfo3.Exists)
        //                            {
        //                                IEnumerable<FileInfo> source = directoryInfo3.EnumerateFiles("*.jpg", SearchOption.TopDirectoryOnly);
        //                                source = source.Where(delegate(FileInfo t)
        //                                {
        //                                    bool result;
        //                                    while (4 != 0)
        //                                    {
        //                                        result = (t.CreationTime < DateTime.Now.AddDays((double)(-(double)App.tripCamCleanUpDays)));
        //                                        if (!false)
        //                                        {
        //                                            break;
        //                                        }
        //                                    }
        //                                    return result;
        //                                });
        //                                if (source.Count<FileInfo>() > 36)
        //                                {
        //                                    foreach (FileInfo current2 in (from t in source
        //                                                                   orderby t.CreationTime
        //                                                                   select t).Take(source.Count<FileInfo>() - 36))
        //                                    {
        //                                        try
        //                                        {
        //                                            current2.Delete();
        //                                        }
        //                                        catch (Exception var_22_402)
        //                                        {
        //                                        }
        //                                        Thread.Sleep(1);
        //                                        num++;
        //                                    }
        //                                }
        //                            }
        //                            goto IL_87A;
        //                        }
        //                    }
        //                    break;
        //                }
        //            }
        //        }
        //        num = 1;
        //        if (Directory.Exists(path7))
        //        {
        //            string[] files3 = Directory.GetFiles(path7);
        //            array = files3;
        //            i = 0;
        //            goto IL_92B;
        //        }
        //        goto IL_93A;
        //    IL_900:
        //        if (!arg_900_0)
        //        {
        //            try
        //            {
        //                fileInfo.Delete();
        //            }
        //            catch (Exception var_22_402)
        //            {
        //            }
        //            Thread.Sleep(1);
        //        }
        //        num++;
        //        i++;
        //    IL_92B:
        //        if (i < array.Length)
        //        {
        //            string fileName = array[i];
        //            fileInfo = new FileInfo(fileName);
        //            DateTime arg_8F4_0 = fileInfo.CreationTime;
        //            now = DateTime.Now;
        //            bool flag = !(arg_8F4_0 < now.AddDays((double)(-(double)App.iMIXCleanUpDays)));
        //            arg_900_0 = flag;
        //            goto IL_900;
        //        }
        //    IL_93A:
        //        int num2 = ConfigurationManager.AppSettings["DeletedOldImages"].ToInt32(false);
        //        PhotoBusiness photoBusiness2 = new PhotoBusiness();
        //        photoBusiness2.TruncatePhotoGroupTablefordate(olderthandays, LoginUser.SubStoreId);
        //    }
        //    this.StartWindowService("FontCache3.0.0.0");
        //}

        //private void GetStoreConfigData()
        //{
        //    ConfigBusiness configBusiness = new ConfigBusiness();
        //    List<iMIXStoreConfigurationInfo> storeConfigData = configBusiness.GetStoreConfigData();
        //    int arg_C9_0;
        //    int expr_1B = arg_C9_0 = 0;
        //    int num = 0; ;
        //    if (expr_1B == 0)
        //    {
        //        num = expr_1B;
        //        goto IL_D5;
        //    }
        //IL_C9:
        //    App.iMIXCleanUpDays = arg_C9_0;
        //IL_D0:
        //    int arg_D4_0 = num + 1;
        //IL_D4:
        //    num = arg_D4_0;
        //IL_D5:
        //    int expr_D5 = arg_D4_0 = num;
        //    if (!false)
        //    {
        //        bool flag = expr_D5 < storeConfigData.Count;
        //        while (flag)
        //        {
        //            long arg_5D_0;
        //            long expr_3B = arg_5D_0 = storeConfigData[num].IMIXConfigurationMasterId;
        //            long num2;
        //            long arg_66_0;
        //            long arg_66_1;
        //            if (!false)
        //            {
        //                num2 = expr_3B;
        //                long expr_44 = arg_66_0 = num2;
        //                long expr_4A = arg_66_1 = 141L;
        //                if (false)
        //                {
        //                    goto IL_66;
        //                }
        //                if (expr_44 > expr_4A)
        //                {
        //                    //goto IL_75;
        //                }
        //                if (-1 == 0)
        //                {
        //                    continue;
        //                }
        //                arg_5D_0 = num2;
        //            }
        //            if (arg_5D_0 < 140L)
        //            {
        //                goto IL_D0;
        //            }
        //            arg_66_0 = num2;
        //            arg_66_1 = 140L;
        //        IL_66:
        //            int arg_9E_0;
        //            switch ((int)(arg_66_0 - arg_66_1))
        //            {
        //                case 0:
        //                    if (storeConfigData[num].ConfigurationValue != null)
        //                    {
        //                        arg_9E_0 = (int)storeConfigData[num].ConfigurationValue.ToInt16(false);
        //                        goto IL_9D;
        //                    }
        //                    break;
        //                case 1:
        //                    arg_C9_0 = (int)((storeConfigData[num].ConfigurationValue != null) ? storeConfigData[num].ConfigurationValue.ToInt16(false) : 0);
        //                    goto IL_C9;
        //                default:
        //                IL_75:
        //                    if (3 != 0)
        //                    {
        //                        goto IL_D0;
        //                    }
        //                    break;
        //            }
        //            arg_9E_0 = 0;
        //        IL_9D:
        //            App.tripCamCleanUpDays = arg_9E_0;
        //            goto IL_D0;
        //        }
        //        return;
        //    }
        //    goto IL_D4;
        //}

        //public List<string> GetImagesToDelete(string hotfolderpath, int days)
        //{
        //    List<string> list = new List<string>();
        //    List<string> result;
        //    try
        //    {
        //        string arg_41_1 = "\\";
        //        DateTime expr_146 = DateTime.Now;
        //        DateTime dateTime;
        //        if (8 != 0)
        //        {
        //            dateTime = expr_146;
        //        }
        //        dateTime = dateTime.AddDays((double)(-(double)days));
        //        string path = hotfolderpath + arg_41_1 + dateTime.ToString("yyyyMMdd");
        //        int num;
        //        if (!false)
        //        {
        //            num = days;
        //            goto IL_126;
        //        }
        //        goto IL_D9;
        //    IL_B1:
        //        int arg_DF_1;
        //        int expr_B2 = arg_DF_1 = 0;
        //        if (expr_B2 != 0)
        //        {
        //            goto IL_DF;
        //        }
        //        int arg_B5_0;
        //        if (arg_B5_0 == expr_B2)
        //        {
        //            goto IL_DA;
        //        }
        //    IL_BE:
        //        FileInfo fileInfo=null;
        //        list.Add(fileInfo.FullName);
        //      //  ErrorHandler.LogFileWrite(fileInfo.Name);
        //    IL_D9:
        //    IL_DA:
        //    IL_DB:
        //        int num2=0;
        //        int arg_DF_0 = num2;
        //        arg_DF_1 = 1;
        //    IL_DF:
        //        num2 = arg_DF_0 + arg_DF_1;
        //    IL_E2:
        //        string[] array;
        //        if (num2 >= array.Length)
        //        {
        //            if (false)
        //            {
        //                goto IL_BE;
        //            }
        //            num++;
        //            string arg_11F_1 = "\\";
        //            dateTime = DateTime.Now;
        //            dateTime = dateTime.AddDays((double)(-(double)num));
        //            path = hotfolderpath + arg_11F_1 + dateTime.ToString("yyyyMMdd");
        //        }
        //        else
        //        {
        //            string fileName = array[num2];
        //            fileInfo = new FileInfo(fileName);
        //            DateTime arg_91_0 = fileInfo.CreationTime;
        //            dateTime = DateTime.Now;
        //            if (arg_91_0 < dateTime.AddDays((double)(-(double)days)))
        //            {
        //                arg_DF_0 = (arg_B5_0 = ((fileInfo.Name != "Locked.png") ? 1 : 0));
        //                goto IL_B1;
        //            }
        //            goto IL_DB;
        //        }
        //    IL_126:
        //        if (!false)
        //        {
        //            if (!Directory.Exists(path))
        //            {
        //                result = list;
        //                return result;
        //            }
        //            string[] files = Directory.GetFiles(path);
        //            array = files;
        //        }
        //        int expr_61 = arg_B5_0 = (arg_DF_0 = 0);
        //        if (expr_61 == 0)
        //        {
        //            num2 = expr_61;
        //            goto IL_E2;
        //        }
        //        goto IL_B1;
        //    }
        //    catch (Exception serviceException)
        //    {
        //        while (2 == 0)
        //        {
        //        }
        //       // string message = ErrorHandler.CreateErrorMessage(serviceException);
        //        do
        //        {
        //            //ErrorHandler.LogFileWrite(message);
        //        }
        //        while (3 == 0);
        //        result = list;
        //    }
        //    return result;
        //}

        //private void Application_Exit(object sender, ExitEventArgs e)
        //{
        //    try
        //    {
        //        object obj = "";
        //        string hostName = Dns.GetHostName();
        //        string myIP;
        //        ManagementObjectSearcher managementObjectSearcher;
        //        if (!false)
        //        {
        //            myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
        //            managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name FROM Win32_ComputerSystem");
        //        }
        //        using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
        //        {
        //            while (enumerator.MoveNext())
        //            {
        //                ManagementObject managementObject = (ManagementObject)enumerator.Current;
        //                obj = managementObject["Name"];
        //            }
        //        }
        //        ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
        //        IEnumerable<ManagementObject> source = managementObjectSearcher2.Get().Cast<ManagementObject>();
        //        string mac = (from o in source
        //                      orderby o["IPConnectionMetric"]
        //                      select o["MACAddress"].ToString()).FirstOrDefault<string>();
        //        string systemName = obj.ToString();
        //        ServicePosInfoBusiness servicePosInfoBusiness = new ServicePosInfoBusiness();
        //        servicePosInfoBusiness.StartStopSystemBusiness(mac, myIP, systemName, 0);
        //    }
        //    catch (Exception serviceException)
        //    {
        //        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
        //        ErrorHandler.ErrorHandler.LogFileWrite(message);
        //    }
        //}

        //public void DigiStartup(object sender, EventArgs e)
        //{
        //    if (true)
        //    {
        //        try
        //        {
        //            if (false)
        //            {
        //                goto IL_99;
        //            }
        //            Process currentProcess = Process.GetCurrentProcess();
        //            if (Process.GetProcessesByName(currentProcess.ProcessName).Length > 1)
        //            {
        //                MessageBox.Show("Digiphoto is already running.");
        //                Application.Current.Shutdown();
        //                return;
        //            }
        //            if (false)
        //            {
        //                goto IL_7E;
        //            }
        //            ErrorHandler.ErrorHandler.DeleteLog();
        //        IL_60:
        //            CustomBusineses customBusineses = new CustomBusineses();
        //            customBusineses.setServicePathForApplication(Directory.GetCurrentDirectory());
        //            Taskbar.Hide();
        //            App.EnableDisableTaskManager(false);
        //        IL_7E:
        //            this.KeyboardHook(this, e);
        //            base.StartupUri = new Uri("Login.xaml", UriKind.Relative);
        //        IL_99:
        //            if (5 == 0)
        //            {
        //                goto IL_60;
        //            }
        //        }
        //        catch (Exception serviceException)
        //        {
        //            while (true)
        //            {
        //                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
        //                ErrorHandler.ErrorHandler.LogFileWrite(message);
        //                while (!false)
        //                {
        //                    if (!false)
        //                    {
        //                        goto Block_8;
        //                    }
        //                }
        //            }
        //        Block_8: ;
        //        }
        //    }
        //}

        //private static bool RegisterSystem()
        //{
        //    bool expr_223;
        //    do
        //    {
        //        if (4 == 0)
        //        {
        //        }
        //        bool flag3;
        //        try
        //        {
        //            object obj = "";
        //            string hostName = Dns.GetHostName();
        //            if (!false)
        //            {
        //                string iPAddress = Dns.GetHostByName(hostName).AddressList[0].ToString();
        //                ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name FROM Win32_ComputerSystem");
        //                ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator();
        //                try
        //                {
        //                    while (enumerator.MoveNext())
        //                    {
        //                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
        //                        try
        //                        {
        //                            obj = managementObject["Name"];
        //                        }
        //                        catch
        //                        {
        //                        }
        //                    }
        //                }
        //                finally
        //                {
        //                    bool arg_9F_0 = enumerator == null;
        //                    bool expr_A1;
        //                    do
        //                    {
        //                        bool flag = arg_9F_0;
        //                        expr_A1 = (arg_9F_0 = flag);
        //                    }
        //                    while (!true);
        //                    if (!expr_A1)
        //                    {
        //                        ((IDisposable)enumerator).Dispose();
        //                    }
        //                }
        //                ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapterConfiguration where IPEnabled=true");
        //                string macAddress = string.Empty;
        //                IEnumerable<ManagementObject> source = managementObjectSearcher2.Get().Cast<ManagementObject>();
        //                try
        //                {
        //                    macAddress = (from o in source
        //                                  orderby o["IPConnectionMetric"]
        //                                  select o["MACAddress"].ToString()).FirstOrDefault<string>();
        //                }
        //                catch
        //                {
        //                }
        //                string uniqueSynccode = CommonUtility.GetUniqueSynccode(Convert.ToInt32(ApplicationObjectEnum.PosDetail).ToString().PadLeft(2, '0'), LoginUser.countrycode, LoginUser.Storecode, "00");
        //                bool flag2 = App.InsertImixPosDetail(new ImixPOSDetail
        //                {
        //                    SystemName = obj.ToString(),
        //                    IPAddress = iPAddress,
        //                    MacAddress = macAddress,
        //                    SubStoreID = (long)LoginUser.SubStoreId,
        //                    IsActive = true,
        //                    CreatedBy = "webusers",
        //                    ImixPOSDetailID = 0L,
        //                    IsStart = false,
        //                    SyncCode = uniqueSynccode
        //                });
        //                flag3 = flag2;
        //            }
        //        }
        //        catch (Exception var_12_218)
        //        {
        //            bool flag2 = false;
        //            flag3 = flag2;
        //        }
        //        bool arg_22C_0;
        //        expr_223 = (arg_22C_0 = flag3);
        //    }
        //    while (false);
        //    return expr_223;
        //}

        //public static bool InsertImixPosDetail(ImixPOSDetail imixposdetail)
        //{
        //    bool result;
        //    try
        //    {
        //        string connectionString = ConfigurationManager.ConnectionStrings["DigiConnectionString"].ConnectionString;
        //        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        //        {
        //            SqlCommand sqlCommand = new SqlCommand("USP_INSERTUPDATEIMIXPOSDETAIL", sqlConnection);
        //            sqlCommand.CommandType = CommandType.StoredProcedure;
        //            sqlCommand.Parameters.AddWithValue("@iMixPOSDetailID", imixposdetail.ImixPOSDetailID);
        //            sqlCommand.Parameters.AddWithValue("@SystemName", imixposdetail.SystemName);
        //            sqlCommand.Parameters.AddWithValue("@IPAddress", imixposdetail.IPAddress);
        //            sqlCommand.Parameters.AddWithValue("@MacAddress", imixposdetail.MacAddress);
        //            sqlCommand.Parameters.AddWithValue("@SubStoreID", imixposdetail.SubStoreID);
        //            sqlCommand.Parameters.AddWithValue("@IsActive", imixposdetail.IsActive);
        //            sqlCommand.Parameters.AddWithValue("@CreatedBy", imixposdetail.CreatedBy);
        //            sqlCommand.Parameters.AddWithValue("@IsStart", imixposdetail.IsStart);
        //            sqlCommand.Parameters.AddWithValue("@SyncCode", imixposdetail.SyncCode);
        //            sqlConnection.Open();
        //            sqlCommand.ExecuteNonQuery();
        //            sqlConnection.Close();
        //        }
        //        result = true;
        //    }
        //    catch (Exception var_4_1A0)
        //    {
        //        result = false;
        //    }
        //    return result;
        //}

        //private bool verifyAutoUpdateEnabled()
        //{
        //    int arg_BD_0 = 0;
        //    bool expr_B4;
        //    do
        //    {
        //        bool flag = arg_BD_0 != 0;
        //        try
        //        {
        //            ConfigBusiness configBusiness = new ConfigBusiness();
        //            iMIXConfigurationInfo iMIXConfigurationInfo = configBusiness.GetNewConfigValues(LoginUser.SubStoreId).Where(delegate(iMIXConfigurationInfo o)
        //            {
        //                bool result;
        //                do
        //                {
        //                    if (!false)
        //                    {
        //                        long arg_14_0 = o.IMIXConfigurationMasterId;
        //                        int arg_09_0 = 36;
        //                        long expr_2D;
        //                        do
        //                        {
        //                            expr_2D = (long)(arg_09_0 = Convert.ToInt32((ConfigParams)arg_09_0));
        //                        }
        //                        while (false);
        //                        result = (arg_14_0 == expr_2D);
        //                    }
        //                    while (false)
        //                    {
        //                    }
        //                }
        //                while (8 == 0);
        //                return result;
        //            }).FirstOrDefault<iMIXConfigurationInfo>();
        //            bool flag2 = iMIXConfigurationInfo == null;
        //            if (!false)
        //            {
        //                if (8 == 0 || !flag2)
        //                {
        //                    flag = Convert.ToBoolean(iMIXConfigurationInfo.ConfigurationValue);
        //                }
        //            }
        //        }
        //        catch (Exception serviceException)
        //        {
        //            if (-1 != 0)
        //            {
        //            }
        //            while (true)
        //            {
        //                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
        //                while (!false)
        //                {
        //                    ErrorHandler.ErrorHandler.LogFileWrite(message);
        //                    if (2 != 0)
        //                    {
        //                        goto Block_8;
        //                    }
        //                }
        //            }
        //        Block_8: ;
        //        }
        //        bool flag3 = flag;
        //        expr_B4 = ((arg_BD_0 = (flag3 ? 1 : 0)) != 0);
        //    }
        //    while (4 == 0);
        //    return expr_B4;
        //}

        //private string GetUpdateServicePath()
        //{
        //    string result = string.Empty;
        //    iMIXConfigurationInfo iMIXConfigurationInfo = new ConfigBusiness().GetNewConfigValues(LoginUser.SubStoreId).Where(delegate(iMIXConfigurationInfo o)
        //    {
        //        bool result2;
        //        do
        //        {
        //            if (!false)
        //            {
        //                long arg_14_0 = o.IMIXConfigurationMasterId;
        //                int arg_09_0 = 37;
        //                long expr_2D;
        //                do
        //                {
        //                    expr_2D = (long)(arg_09_0 = Convert.ToInt32((ConfigParams)arg_09_0));
        //                }
        //                while (false);
        //                result2 = (arg_14_0 == expr_2D);
        //            }
        //            while (false)
        //            {
        //            }
        //        }
        //        while (8 == 0);
        //        return result2;
        //    }).FirstOrDefault<iMIXConfigurationInfo>();
        //    if (iMIXConfigurationInfo != null)
        //    {
        //        result = Convert.ToString(iMIXConfigurationInfo.ConfigurationValue);
        //    }
        //    return result;
        //}

        //private void CheckUpdate()
        //{
        //    string expr_01 = string.Empty;
        //    string text;
        //    if (!false)
        //    {
        //        text = expr_01;
        //    }
        //    string text2 = string.Empty;
        //    string arg_238_0 = string.Empty;
        //    bool expr_2C = !this.verifyAutoUpdateEnabled();
        //    bool flag;
        //    if (8 != 0)
        //    {
        //        flag = expr_2C;
        //    }
        //    if (!flag)
        //    {
        //        string text3 = this.CheckForLocalUpdates();
        //        string text4 = App.ExecutablePath + "\\DigiUpdates.exe";
        //        flag = string.IsNullOrEmpty(text3);
        //        int arg_201_0;
        //        bool expr_63 = (arg_201_0 = (flag ? 1 : 0)) != 0;
        //        int arg_201_1;
        //        int arg_211_0;
        //        if (!false)
        //        {
        //            MessageBoxResult messageBoxResult;
        //            if (!expr_63)
        //            {
        //                flag = !File.Exists(text4);
        //                if (flag)
        //                {
        //                    goto IL_BC;
        //                }
        //            }
        //            else
        //            {
        //                VersonViewModel[] array = this.VerifyUpdatesAtServer();
        //                bool arg_E0_0;
        //                if (array == null)
        //                {
        //                    arg_E0_0 = true;
        //                    goto IL_DF;
        //                }
        //                int arg_D7_0 = array.Count<VersonViewModel>();
        //                int arg_D7_1 = 0;
        //            IL_D7:
        //                arg_E0_0 = (arg_D7_0 <= arg_D7_1);
        //            IL_DF:
        //                flag = arg_E0_0;
        //                bool arg_E4_0 = flag;
        //                bool expr_1E0;
        //                do
        //                {
        //                    if (!arg_E4_0)
        //                    {
        //                        VersonViewModel[] array2 = array;
        //                        int num = 0;
        //                        while (true)
        //                        {
        //                            int expr_186 = arg_201_0 = num;
        //                            int expr_18A = arg_201_1 = array2.Length;
        //                            if (8 == 0)
        //                            {
        //                                goto IL_201;
        //                            }
        //                            flag = (expr_186 < expr_18A);
        //                            if (!flag)
        //                            {
        //                                break;
        //                            }
        //                            VersonViewModel versonViewModel = array2[num];
        //                            object[] array3 = new object[8];
        //                            array3[0] = versonViewModel.Major;
        //                            array3[1] = ".";
        //                            array3[2] = versonViewModel.Minor;
        //                            array3[3] = ".";
        //                            array3[4] = versonViewModel.Revision;
        //                            if (5 == 0)
        //                            {
        //                                goto IL_7D;
        //                            }
        //                            array3[5] = ".";
        //                            array3[6] = versonViewModel.BuildNumber;
        //                            array3[7] = ",";
        //                            text2 = string.Concat(array3);
        //                            int expr_17A = arg_211_0 = num;
        //                            if (8 == 0)
        //                            {
        //                                goto IL_210;
        //                            }
        //                            num = expr_17A + 1;
        //                        }
        //                        int expr_1A0 = arg_D7_0 = (text2.EndsWith(",") ? 1 : 0);
        //                        int expr_1A6 = arg_D7_1 = 0;
        //                        if (expr_1A6 != 0)
        //                        {
        //                            goto IL_D7;
        //                        }
        //                        flag = (expr_1A0 == expr_1A6);
        //                        if (!flag)
        //                        {
        //                            text2 = text2.Substring(0, text2.Length - 1);
        //                        }
        //                        text = "New version of i-Mix " + text2 + " is available! Would you like to download it now?";
        //                    }
        //                    flag = string.IsNullOrEmpty(text);
        //                    expr_1E0 = (arg_E4_0 = flag);
        //                }
        //                while (false);
        //                if (!expr_1E0)
        //                {
        //                    messageBoxResult = MessageBox.Show(text, "i-Mix (Server Update)", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //                    arg_201_0 = ((messageBoxResult == MessageBoxResult.Yes) ? 1 : 0);
        //                    goto IL_200;
        //                }
        //                goto IL_229;
        //            }
        //        IL_7D:
        //            text = "New version of i-Mix " + text3 + " is available! Would you like to download it now?";
        //            messageBoxResult = MessageBox.Show(text, "i-Mix (Local Update)", MessageBoxButton.YesNo, MessageBoxImage.Question);
        //            flag = (messageBoxResult != MessageBoxResult.Yes);
        //            if (!flag)
        //            {
        //                Process.Start(text4, "1");
        //            }
        //        IL_BC:
        //            goto IL_22A;
        //        }
        //    IL_200:
        //        arg_201_1 = 0;
        //    IL_201:
        //        flag = (arg_201_0 == arg_201_1);
        //        if (flag)
        //        {
        //            goto IL_228;
        //        }
        //        arg_211_0 = (File.Exists(text4) ? 1 : 0);
        //    IL_210:
        //        flag = (arg_211_0 == 0);
        //        if (!flag)
        //        {
        //            Process.Start(text4, "2");
        //        }
        //    IL_228:
        //    IL_229:
        //    IL_22A: ;
        //    }
        //}

        //private VersonViewModel[] VerifyUpdatesAtServer()
        //{
        //    if (false)
        //    {
        //        goto IL_E1;
        //    }
        //IL_07:
        //    StoreSubStoreDataBusniess storeSubStoreDataBusniess = new StoreSubStoreDataBusniess();
        //    string computer_LanIP;
        //    string mACAddress;
        //    string version;
        //    VersonViewModel versonViewModel;
        //    do
        //    {
        //        Hashtable storeDetails = storeSubStoreDataBusniess.GetStoreDetails();
        //        computer_LanIP = this.GetComputer_LanIP();
        //        mACAddress = this.GetMACAddress();
        //        version = this.CurrentRegistryVersion();
        //        if (false)
        //        {
        //            goto IL_FE;
        //        }
        //        versonViewModel = new VersonViewModel();
        //        versonViewModel.Country = (storeDetails.ContainsKey("Country") ? storeDetails["Country"].ToString() : "");
        //        versonViewModel.Store = (storeDetails.ContainsKey("Store") ? storeDetails["Store"].ToString() : "");
        //    }
        //    while (false);
        //    versonViewModel.Description = "Test description";
        //IL_BC:
        //    versonViewModel.MACAddress = mACAddress;
        //    versonViewModel.IPAddress = computer_LanIP;
        //    if (8 == 0)
        //    {
        //        goto IL_07;
        //    }
        //    versonViewModel.Location = "";
        //IL_E1:
        //    if (5 == 0)
        //    {
        //        goto IL_BC;
        //    }
        //    versonViewModel.SubStore = "";
        //    versonViewModel.User = "admin";
        //IL_FE:
        //    versonViewModel.Password = "admin";
        //    versonViewModel.Version = version;
        //    VersonViewModel[] array = this.VerifyUpdateService(versonViewModel);
        //    VersonViewModel[] result = array;
        //    if (6 != 0)
        //    {
        //        return result;
        //    }
        //    goto IL_E1;
        //}

        //private VersonViewModel[] VerifyUpdateService(VersonViewModel viewModel)
        //{
        //    if (2 != 0)
        //    {
        //    }
        //    VersonViewModel[] result;
        //    try
        //    {
        //        if (4 != 0)
        //        {
        //        }
        //        if (!false)
        //        {
        //            VersonViewModel[] array;
        //            if (-1 != 0)
        //            {
        //                string updateServicePath = this.GetUpdateServicePath();
        //                VersionServiceClient versionServiceClient = new VersionServiceClient("BasicHttpBinding_IVersionService", updateServicePath);
        //                array = versionServiceClient.CheckAvailableUpdates(viewModel);
        //            }
        //            result = array;
        //        }
        //    }
        //    catch (Exception serviceException)
        //    {
        //        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
        //        do
        //        {
        //            ErrorHandler.ErrorHandler.LogFileWrite(message);
        //        }
        //        while (false);
        //        result = null;
        //    }
        //    return result;
        //}

        //private string GetComputer_LanIP()
        //{
        //    IPAddress iPAddress;
        //    while (true)
        //    {
        //        string hostName = Dns.GetHostName();
        //        IPHostEntry hostEntry;
        //        do
        //        {
        //            hostEntry = Dns.GetHostEntry(hostName);
        //        }
        //        while (!true);
        //        IPAddress[] addressList = hostEntry.AddressList;
        //        int num = 0;
        //        while (true)
        //        {
        //            int arg_85_0 = num;
        //            bool expr_85;
        //            do
        //            {
        //                int arg_81_0 = addressList.Length;
        //                int expr_81;
        //                do
        //                {
        //                    expr_81 = (arg_81_0 = arg_81_0);
        //                }
        //                while (false);
        //                expr_85 = ((arg_85_0 = ((arg_85_0 < expr_81) ? 1 : 0)) != 0);
        //            }
        //            while (8 == 0);
        //            if (!expr_85)
        //            {
        //                goto IL_90;
        //            }
        //            iPAddress = addressList[num];
        //            if (false)
        //            {
        //                goto IL_90;
        //            }
        //            if (iPAddress.AddressFamily.ToString() == "InterNetwork")
        //            {
        //                goto Block_2;
        //            }
        //            if (7 == 0)
        //            {
        //                break;
        //            }
        //            num++;
        //        }
        //    }
        //Block_2:
        //    string result;
        //    if (4 != 0)
        //    {
        //        result = iPAddress.ToString();
        //        return result;
        //    }
        //    return result;
        //IL_90:
        //    result = "-";
        //    return result;
        //}

        //public string GetMACAddress()
        //{
        //    NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
        //    if (false)
        //    {
        //        goto IL_5D;
        //    }
        //    string text = string.Empty;
        //    if (false)
        //    {
        //        goto IL_6B;
        //    }
        //    NetworkInterface[] array = allNetworkInterfaces;
        //IL_26:
        //    int expr_26 = 0;
        //    int num;
        //    if (!false)
        //    {
        //        num = expr_26;
        //    }
        //    goto IL_74;
        //IL_5D:
        //    NetworkInterface networkInterface;
        //    text = networkInterface.GetPhysicalAddress().ToString();
        //IL_6A:
        //IL_6B:
        //    if (false)
        //    {
        //        return text;
        //    }
        //    int arg_72_0 = num + 1;
        //IL_72:
        //    num = arg_72_0;
        //IL_74:
        //    int arg_53_0;
        //    int expr_74 = arg_53_0 = num;
        //    if (!false)
        //    {
        //        bool expr_7D = (arg_72_0 = ((expr_74 < array.Length) ? 1 : 0)) != 0;
        //        if (false)
        //        {
        //            goto IL_72;
        //        }
        //        bool flag = expr_7D;
        //        if (-1 == 0)
        //        {
        //            goto IL_26;
        //        }
        //        if (!flag)
        //        {
        //            return text;
        //        }
        //        networkInterface = array[num];
        //        flag = !(text == string.Empty);
        //        arg_53_0 = (flag ? 1 : 0);
        //    }
        //    if (arg_53_0 == 0)
        //    {
        //        IPInterfaceProperties iPProperties = networkInterface.GetIPProperties();
        //        goto IL_5D;
        //    }
        //    goto IL_6A;
        //}

        //private string CheckForLocalUpdates()
        //{
        //    string result;
        //    while (true)
        //    {
        //        string arg_28_0 = string.Empty;
        //        while (8 != 0)
        //        {
        //            string expr_2E = this.CurrentRegistryVersion();
        //            string currVersion;
        //            if (7 != 0)
        //            {
        //                currVersion = expr_2E;
        //            }
        //            string text;
        //            do
        //            {
        //                text = new AppStartUpBusiness().IsUpdateAvailable(currVersion);
        //            }
        //            while (7 == 0);
        //            result = text;
        //            if (!false)
        //            {
        //                return result;
        //            }
        //        }
        //    }
        //    return result;
        //}

        //private string CurrentRegistryVersion()
        //{
        //    while (-1 == 0)
        //    {
        //    }
        //    if (6 == 0)
        //    {
        //        goto IL_21;
        //    }
        //    ModifyRegistry modifyRegistry = new ModifyRegistry();
        //IL_0B:
        //    string text;
        //    if (!false)
        //    {
        //        text = modifyRegistry.Read("InstallVersion");
        //    }
        //    string expr_3E = text;
        //    string result;
        //    if (7 != 0)
        //    {
        //        result = expr_3E;
        //    }
        //IL_21:
        //    if (!false)
        //    {
        //        return result;
        //    }
        //    goto IL_0B;
        //}

        //private void StartWindowService(string servicename)
        //{
        //    do
        //    {
        //        try
        //        {
        //            ServiceController serviceController;
        //            do
        //            {
        //                ServiceController expr_49 = new ServiceController();
        //                if (!false)
        //                {
        //                    serviceController = expr_49;
        //                }
        //                serviceController.ServiceName = servicename;
        //            }
        //            while (false);
        //            string a;
        //            if (6 != 0)
        //            {
        //                serviceController.Refresh();
        //                a = serviceController.Status.ToString();
        //            }
        //            if (a == "Stopped")
        //            {
        //                serviceController.Start();
        //            }
        //        }
        //        catch (Exception serviceException)
        //        {
        //            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
        //            ErrorHandler.ErrorHandler.LogFileWrite(message);
        //            if (7 != 0)
        //            {
        //            }
        //        }
        //    }
        //    while (false);
        //    if (!false)
        //    {
        //    }
        //}

        //private static void EnableDisableTaskManager(bool enable)
        //{
        //    if (false)
        //    {
        //        goto IL_37;
        //    }
        //    if (!false)
        //    {
        //    }
        //    RegistryKey currentUser = Registry.CurrentUser;
        //IL_0E:
        //    if (7 != 0)
        //    {
        //        RegistryKey expr_41 = currentUser.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Policies\\System");
        //        RegistryKey registryKey;
        //        if (6 != 0)
        //        {
        //            registryKey = expr_41;
        //        }
        //        registryKey.SetValue("DisableTaskMgr", enable ? 0 : 1, RegistryValueKind.DWord);
        //    }
        //IL_37:
        //    if (!false)
        //    {
        //        return;
        //    }
        //    goto IL_0E;
        //}

        //private int LowLevelKeyboardProc(int nCode, int wParam, ref App.KBDLLHOOKSTRUCT lParam)
        //{
        //    bool flag = false;
        //    int arg_134_0 = wParam;
        //    int arg_67_0;
        //    int expr_13B;
        //    do
        //    {
        //        int num = arg_134_0;
        //        expr_13B = (arg_67_0 = (arg_134_0 = num));
        //        if (false)
        //        {
        //            goto IL_65;
        //        }
        //    }
        //    while (-1 == 0);
        //    int result;
        //    switch (expr_13B)
        //    {
        //        case 256:
        //        case 257:
        //        case 260:
        //        case 261:
        //            if (!true)
        //            {
        //                return result;
        //            }
        //            if (lParam.vkCode != 9)
        //            {
        //                goto IL_69;
        //            }
        //            arg_67_0 = lParam.flags;
        //            break;
        //        case 258:
        //        //case 259:
        //        //    goto IL_E7;
        //        default:
        //            if (!false)
        //            {
        //               // goto IL_E7;
        //            }
        //            goto IL_85;
        //    }
        //IL_65:
        //    if (arg_67_0 == 32)
        //    {
        //        goto IL_D6;
        //    }
        //IL_69:
        //    if (lParam.vkCode != 27)
        //    {
        //        goto IL_85;
        //    }
        //    int arg_83_0 = lParam.flags;
        //IL_81:
        //    if (arg_83_0 == 32)
        //    {
        //        goto IL_D6;
        //    }
        //IL_85:
        //    bool arg_DB_0;
        //    if (lParam.vkCode != 27 || lParam.flags != 0)
        //    {
        //        if (lParam.vkCode != 91)
        //        {
        //            goto IL_AE;
        //        }
        //        int arg_AC_0 = lParam.flags;
        //        int arg_AC_1 = 1;
        //    IL_AC:
        //        if (arg_AC_0 == arg_AC_1)
        //        {
        //            goto IL_D6;
        //        }
        //    IL_AE:
        //        int arg_B9_0 = arg_AC_0 = lParam.vkCode;
        //        bool expr_CC;
        //        do
        //        {
        //            int expr_B6 = arg_AC_1 = 92;
        //            if (expr_B6 == 0)
        //            {
        //                goto IL_AC;
        //            }
        //            if (arg_B9_0 == expr_B6 && lParam.flags == 1)
        //            {
        //                goto IL_D6;
        //            }
        //            expr_CC = ((arg_AC_0 = (arg_B9_0 = ((lParam.flags == 32) ? 1 : 0))) != 0);
        //        }
        //        while (false);
        //        arg_DB_0 = ((arg_83_0 = ((!expr_CC) ? 1 : 0)) != 0);
        //        goto IL_D7;
        //    }
        //IL_D6:
        //    arg_DB_0 = ((arg_83_0 = 0) != 0);
        //IL_D7:
        //    if (7 == 0)
        //    {
        //        goto IL_81;
        //    }
        //    if (!arg_DB_0)
        //    {
        //        flag = true;
        //    }
        //    try
        //    {
        //    IL_E7:
        //        if (flag)
        //        {
        //            result = 1;
        //        }
        //        else
        //        {
        //            try
        //            {
        //                int num2 = App.CallNextHookEx(0, nCode, wParam, ref lParam);
        //                result = num2;
        //            }
        //            catch (Exception serviceException)
        //            {
        //                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
        //                ErrorHandler.ErrorHandler.LogFileWrite(message);
        //                result = 1;
        //            }
        //        }
        //    }
        //    catch (Exception serviceException)
        //    {
        //        result = 1;
        //    }
        //    return result;
        //}

        //private void KeyboardHook(object sender, EventArgs e)
        //{
        //    if (false || -1 != 0)
        //    {
        //        App.mHookProc = new App.LowLevelKeyboardProcDelegate(this.LowLevelKeyboardProc);
        //    }
        //    IntPtr arg_81_0;
        //    IntPtr expr_19 = arg_81_0 = IntPtr.Zero;
        //    if (6 != 0)
        //    {
        //        arg_81_0 = App.GetModuleHandle(expr_19);
        //    }
        //    IntPtr hMod = arg_81_0;
        //    this.intLLKey = App.SetWindowsHookEx(13, App.mHookProc, hMod, 0);
        //    bool arg_47_0 = this.intLLKey == IntPtr.Zero;
        //    while (true)
        //    {
        //        bool flag = !arg_47_0;
        //        while (true)
        //        {
        //            bool expr_4B = arg_47_0 = flag;
        //            if (5 == 0)
        //            {
        //                break;
        //            }
        //            if (expr_4B)
        //            {
        //                return;
        //            }
        //            if (4 != 0)
        //            {
        //                goto Block_5;
        //            }
        //        }
        //    }
        //Block_5:
        //    MessageBox.Show("Failed to set hook,error = " + Marshal.GetLastWin32Error().ToString());
        //}

        //private void ReleaseKeyboardHook()
        //{
        //    this.intLLKey = App.UnhookWindowsHookEx(this.intLLKey);
        //}

        //private void LoadMD3Files()
        //{
        //    new List<NikonManager>();
        //    string[] files = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.md3", SearchOption.AllDirectories);
        //    int arg_28_0 = files.Length;
        //    while (true)
        //    {
        //        bool flag = arg_28_0 != 0;
        //        int arg_123_0;
        //        bool expr_172 = (arg_123_0 = (flag ? 1 : 0)) != 0;
        //        if (2 == 0)
        //        {
        //            goto IL_122;
        //        }
        //        if (!expr_172)
        //        {
        //            ErrorHandler.ErrorHandler.LogFileWrite("Couldn't find any MD3 files in " + Directory.GetCurrentDirectory());
        //            ErrorHandler.ErrorHandler.LogFileWrite("Download MD3 files from Nikons SDK website: https://sdk.nikonimaging.com/apply/");
        //            if (false)
        //            {
        //                goto IL_E7;
        //            }
        //        }
        //        string[] array = files;
        //        if (3 == 0)
        //        {
        //            goto IL_B8;
        //        }
        //        int num = 0;
        //    IL_126:
        //        flag = (num < array.Length);
        //        if (false)
        //        {
        //            goto IL_120;
        //        }
        //        if (!flag)
        //        {
        //            break;
        //        }
        //        string text = array[num];
        //        string path = Path.Combine(Path.GetDirectoryName(text), "NkdPTP.dll");
        //        flag = File.Exists(path);
        //        bool expr_96 = (arg_28_0 = (flag ? 1 : 0)) != 0;
        //        if (7 == 0)
        //        {
        //            continue;
        //        }
        //        if (!expr_96)
        //        {
        //            ErrorHandler.ErrorHandler.LogFileWrite("Warning: Couldn't find NkdPTP.dll in " + Path.GetDirectoryName(text) + ". The library will not work properly without it!");
        //            goto IL_B8;
        //        }
        //        goto IL_BA;
        //    IL_122:
        //        num = arg_123_0 + 1;
        //        goto IL_126;
        //    IL_120:
        //        arg_123_0 = num;
        //        goto IL_122;
        //    IL_E7:
        //        NikonManager nikonManager;
        //        if (nikonManager != null)
        //        {
        //            nikonManager.DeviceAdded += new DeviceAddedDelegate(this._manager_DeviceAdded);
        //            if (6 != 0)
        //            {
        //                nikonManager.DeviceRemoved += new DeviceRemovedDelegate(this._manager_DeviceRemoved);
        //            }
        //        }
        //        goto IL_120;
        //    IL_BA:
        //        ErrorHandler.ErrorHandler.LogFileWrite("Opening " + text);
        //        nikonManager = null;
        //        try
        //        {
        //            nikonManager = new NikonManager(text);
        //        }
        //        catch (Exception var_5_DA)
        //        {
        //            nikonManager = null;
        //            while (false)
        //            {
        //            }
        //        }
        //        goto IL_E7;
        //    IL_B8:
        //        goto IL_BA;
        //    }
        //}

        //private void _manager_DeviceRemoved(NikonManager sender, NikonDevice device)
        //{
        //    if (4 != 0)
        //    {
        //        this.IsCameraConnected = false;
        //        this.CameraSerialNumber = string.Empty;
        //        this.ModelNumber = string.Empty;
        //    }
        //}

        //private void _manager_DeviceAdded(NikonManager sender, NikonDevice device)
        //{
        //    do
        //    {
        //        try
        //        {
        //            this.IsCameraConnected = true;
        //            do
        //            {
        //                this.ModelNumber = device.GetString(eNkMAIDCapability.kNkMAIDCapability_Name);
        //                this.FetchSerialNo();
        //            }
        //            while (false);
        //        }
        //        catch (Exception serviceException)
        //        {
        //            while (true)
        //            {
        //                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
        //                ErrorHandler.ErrorHandler.LogFileWrite(message);
        //                while (!false)
        //                {
        //                    if (5 != 0)
        //                    {
        //                        goto Block_6;
        //                    }
        //                }
        //            }
        //        Block_6: ;
        //        }
        //        while (false)
        //        {
        //        }
        //    }
        //    while (6 == 0);
        //}

        //private void FetchSerialNo()
        //{
        //    while (true)
        //    {
        //        new StringBuilder();
        //        try
        //        {
        //            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity");
        //            using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
        //            {
        //                string text;
        //                bool expr_94;
        //                while (true)
        //                {
        //                IL_C8:
        //                    bool flag = enumerator.MoveNext();
        //                    bool arg_D3_0 = flag;
        //                    while (arg_D3_0)
        //                    {
        //                        ManagementObject managementObject = (ManagementObject)enumerator.Current;
        //                        object obj = managementObject["Caption"];
        //                        if (!obj.ToString().Trim().ToUpper().Contains(this.ModelNumber.ToUpper()))
        //                        {
        //                            goto IL_C8;
        //                        }
        //                        text = managementObject["PNPDeviceID"].ToString();
        //                        expr_94 = (arg_D3_0 = true);
        //                        if (expr_94)
        //                        {
        //                            goto Block_5;
        //                        }
        //                    }
        //                    goto Block_6;
        //                }
        //            Block_5:
        //                string[] array = new string[expr_94 ? 1 : 0];
        //                array[0] = "\\";
        //                string[] separator = array;
        //                string[] array2 = text.Split(separator, StringSplitOptions.None);
        //                this.CameraSerialNumber = array2[2];
        //                goto IL_14E;
        //            Block_6: ;
        //            }
        //            while (false)
        //            {
        //            }
        //        }
        //        catch (ManagementException ex)
        //        {
        //            if (-1 != 0)
        //            {
        //                MessageBox.Show("An error occurred while querying for WMI data: " + ex.Message);
        //            }
        //        }
        //    IL_14E:
        //        if (2 != 0)
        //        {
        //            break;
        //        }
        //        continue;
        //        goto IL_14E;
        //    }
        //}

        ////[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
        //public void InitializeComponent()
        //{
        //    while (true)
        //    {
        //        if (!true)
        //        {
        //            goto IL_79;
        //        }
        //        if (!this._contentLoaded)
        //        {
        //            if (4 != 0)
        //            {
        //                this._contentLoaded = true;
        //                ExitEventHandler expr_41 = new ExitEventHandler(this.Application_Exit);
        //                if (!false)
        //                {
        //                    base.Exit += expr_41;
        //                }
        //            }
        //            do
        //            {
        //                base.Startup += new StartupEventHandler(this.Application_Startup);
        //            }
        //            while (-1 == 0);
        //            base.StartupUri = new Uri("MainWindow.xaml", UriKind.Relative);
        //            if (!false)
        //            {
        //                goto IL_79;
        //            }
        //            goto IL_85;
        //        }
        //    IL_8D:
        //        if (7 != 0)
        //        {
        //            break;
        //        }
        //        continue;
        //    IL_85:
        //        Uri resourceLocator;
        //        Application.LoadComponent(this, resourceLocator);
        //        //MainWindow MainWindow = new MainWindow();
        //        //MainWindow.ShowDialog();
        //        goto IL_8D;
        //    IL_79:
        //        resourceLocator = new Uri("/DigiPhoto;component/digiphoto/app.xaml", UriKind.Relative);
        //        goto IL_85;
        //    }
        //}

        ////[STAThread]
        ////public static void Main()
        ////{
        ////    App app = new App();
        ////    app.InitializeComponent();
        ////    app.Run();
        ////    //MainWindow MainWindow = new MainWindow();
        ////    //MainWindow.ShowDialog();
        ////}

        //static App()
        //{
        //    // Note: this type is marked as 'beforefieldinit'.
        //    int arg_31_0;
        //    int expr_01 = arg_31_0 = 0;
        //    if (expr_01 != 0)
        //    {
        //        goto IL_31;
        //    }
        //    App.ViewOrderSearchIndex = expr_01;
        //    App.SelectedCodeType = 405;
        //IL_13:
        //    App.QRCodeWebUrl = string.Empty;
        //IL_1D:
        //    App.DataSyncServiceURl = string.Empty;
        //    App.IsAnonymousQrCodeEnabled = false;
        //    if (!true)
        //    {
        //        goto IL_44;
        //    }
        //    arg_31_0 = 0;
        //IL_31:
        //    App.IsRFIDEnabled = (arg_31_0 != 0);
        //    if (false)
        //    {
        //        goto IL_13;
        //    }
        //    App.RfidScanType = null;
        //IL_44:
        //    if (8 != 0)
        //    {
        //        App.iMIXCleanUpDays = 3;
        //        return;
        //    }
        //    goto IL_1D;
        //}
    }
}
