using ErrorHandler;
using FrameworkHelper.Common;
using MControls;
using MPLATFORMLib;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms.Integration;
using System.Windows.Markup;
using System.Windows.Threading;
using PhotoSW.Views;

namespace PhotoSW.PSControls
{
    public partial class MLFrameExtractor : UserControl, IComponentConnector
    {
        public MFileClass mFile;

        private string vsMediaFileName = "";

        private DispatcherTimer dispatcherTimer;

        private BackgroundWorker bwCopyFiles = new BackgroundWorker();

        private bool IsMute = false;

        private UIElement _parent;

        private ClientView clientWin = null;

        private string SubstoreName = string.Empty;

        private string HotFolderPath = string.Empty;

        private int MediaType = 0;

        private string RFID = string.Empty;

        private int PhotographerId = 0;

        private string CropRatio = string.Empty;

        private double frameRate = 0.0;

        private string replayFilePath = string.Empty;

        private string tempFolderpath = Environment.CurrentDirectory + "\\DigiProcessVideoTemp\\";

        private static int counter = 1;

        private bool isUpdated = false;

        private bool ValidFrame = true;



        private EventHandler executeParentMethod;

        public event EventHandler ExecuteParentMethod
        {
            add
            {
                do
                {
                IL_00:
                    EventHandler eventHandler = this.executeParentMethod;
                    while (true)
                    {
                    IL_09:
                        EventHandler eventHandler2 = eventHandler;
                        while (true)
                        {
                            EventHandler value2 = (EventHandler)Delegate.Combine(eventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.executeParentMethod, value2, eventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (eventHandler == eventHandler2);
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
                Block_4: ;
                }
                while (!true);
            }
            remove
            {
                do
                {
                IL_00:
                    EventHandler eventHandler = this.executeParentMethod;
                    while (true)
                    {
                    IL_09:
                        EventHandler eventHandler2 = eventHandler;
                        while (true)
                        {
                            EventHandler value2 = (EventHandler)Delegate.Remove(eventHandler2, value);
                            if (-1 == 0)
                            {
                                goto IL_00;
                            }
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.executeParentMethod, value2, eventHandler2);
                            while (!false)
                            {
                                bool arg_39_0;
                                bool expr_31 = arg_39_0 = (eventHandler == eventHandler2);
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
                Block_4: ;
                }
                while (!true);
            }
        }

        public MLFrameExtractor()
        {
            this.InitializeComponent();
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
            this._parent.IsEnabled = false;
        }

        public object SetControlledObject(object pObject)
        {
            object result;
            if (2 != 0)
            {
                if (!false)
                {
                    object expr_09 = this.mFile;
                    object obj;
                    if (!false)
                    {
                        obj = expr_09;
                    }
                    try
                    {
                        if (7 != 0)
                        {
                        }
                        this.mFile = (MFileClass)pObject;
                        this.UpdateState();
                        while (false)
                        {
                        }
                    }
                    catch
                    {
                        if (true)
                        {
                        }
                    }
                    result = obj;
                }
            }
            return result;
        }

        private void MyPlaylist_OnEvent(string bsChannelID, string bsEventName, string bsEventParam, object pEventObject)
        {
            this.UpdateSeekControl();
        }

        public void myPlaylist_OnFrame(string bschannelid, object pmframe)
        {
            this.MFileSeeking1.UpdatePos();
            bool expr_65;
            while (true)
            {
                int arg_A0_0 = 0;
                while (true)
                {
                    int num = arg_A0_0;
                    if (4 == 0)
                    {
                        break;
                    }
                    if (false)
                    {
                        goto IL_6B;
                    }
                    int expr_1D = 0;
                    int num2;
                    if (!false)
                    {
                        num2 = expr_1D;
                    }
                    this.MPreviewControl1.m_pPreview.PreviewIsFullScreen("", ref num, ref num2);
                    int arg_C8_0;
                    if (this.clientWin != null)
                    {
                        int expr_C2 = arg_A0_0 = (arg_C8_0 = num);
                        if (!false)
                        {
                            if (5 == 0)
                            {
                                continue;
                            }
                            arg_C8_0 = ((expr_C2 == 1) ? 1 : 0);
                        }
                    }
                    else
                    {
                        arg_C8_0 = 1;
                    }
                    bool flag;
                    if (!false)
                    {
                        flag = (arg_C8_0 != 0);
                    }
                    expr_65 = ((arg_A0_0 = (flag ? 1 : 0)) != 0);
                    if (!false)
                    {
                        goto Block_6;
                    }
                }
            }
        Block_6:
            if (expr_65)
            {
                goto IL_88;
            }
        IL_6B:
            //this.clientWin.mPreviewControl.m_pPreview.PreviewFullScreen("", 0, -1);
        IL_88:
            Marshal.ReleaseComObject(pmframe);
        }

        private void LoadClientViewObject()
        {
            do
            {
                if (!false)
                {
                }
            }
            while (false);
            IEnumerator enumerator = Application.Current.Windows.GetEnumerator();
            try
            {
                bool flag;
                Window window;
                do
                {
                    bool arg_3E_0;
                    bool expr_56 = arg_3E_0 = enumerator.MoveNext();
                    if (!false)
                    {
                        flag = expr_56;
                        bool arg_60_0 = flag;
                        while (arg_60_0)
                        {
                            window = (Window)enumerator.Current;
                            bool expr_33 = arg_60_0 = (window.Title == "ClientView");
                            if (!false)
                            {
                                arg_3E_0 = !expr_33;
                                goto IL_3E;
                            }
                        }
                        goto IL_62;
                    }
                IL_3E:
                    flag = arg_3E_0;
                }
                while (false || flag);
                this.clientWin = (ClientView)window;
            IL_62: ;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                bool arg_86_0 = disposable == null;
                bool expr_87;
                do
                {
                    bool flag = arg_86_0;
                    expr_87 = (arg_86_0 = flag);
                }
                while (false);
                if (!expr_87)
                {
                    disposable.Dispose();
                }
            }
        }

        private void UpdateSeekControl()
        {
            this.MFileSeeking1.SetControlledObject(this.mFile);
        }

        public MLFrameExtractor(string fileName, string type, bool playOnclientView, int mediaType, string hotFolderPath, string rfid, string subStoreName, int photographerId, string cropRatio)
        {
            this.InitializeComponent();
            this.SubstoreName = subStoreName;
            this.HotFolderPath = hotFolderPath;
            this.MediaType = mediaType;
            this.RFID = rfid;
            this.PhotographerId = photographerId;
            this.CropRatio = cropRatio;
            this.mFormatControl.SetControlledObject(this.mFile);
            this.mFormatControl.SetControlledObject(this.MPreviewControl1);
            if (this.mFormatControl.comboBoxVideo.Items.Count > 0)
            {
                this.mFormatControl.comboBoxVideo.SelectedIndex = 12;
            }
            if (this.mFormatControl.comboBoxAudio.Items.Count > 0)
            {
                this.mFormatControl.comboBoxAudio.SelectedIndex = 8;
            }
            this.dispatcherTimer = new DispatcherTimer();
            this.dispatcherTimer.Tick += new EventHandler(this.DispatcherTimerTick);
            this.dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            this.dispatcherTimer.Start();
            try
            {
                if (this.mFile == null)
                {
                    this.mFile = new MFileClass();
                }
            }
            catch (Exception var_0_1CC)
            {
                return;
            }
            try
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    this.vsMediaFileName = fileName;
                    this.MPreviewControl1.SetControlledObject(this.mFile);
                    this.mFile.FileNameSet(this.vsMediaFileName, "loop=true");
                    IMProps iMProps = this.mFile;
                    iMProps.PropsSet("object::audio_gain", "-100");
                    if (!string.IsNullOrEmpty(this.vsMediaFileName))
                    {
                        this.MediaPlay();
                        string empty = string.Empty;
                        string empty2 = string.Empty;
                        iMProps.PropsGet("file::info::video.0::nb_frames", out empty);
                        iMProps.PropsGet("file::info::video.0::codec_frame_rate", out empty2);
                        if (!string.IsNullOrEmpty(empty))
                        {
                            this.MFileSeeking1.totalframe = Convert.ToDouble(empty);
                            this.MFileSeeking1.frameRate = Convert.ToDouble(empty2);
                            this.frameRate = Convert.ToDouble(empty2);
                            this.txtTotalFrame.Text = empty.ToString();
                        }
                        if (playOnclientView)
                        {
                            if (this.clientWin == null)
                            {
                                this.LoadClientViewObject();
                            }
                            //if (this.clientWin != null)
                            //{
                            //    this.clientWin.PlayVideoOnClient(type, this.mFile, new int?(Convert.ToInt32(this.RFID)));
                            //}
                        }
                    }
                }
            }
            catch (Exception var_4_320)
            {
            }
        }

        private void DispatcherTimerTick(object sender, EventArgs e)
        {
            this.UpdateState();
        }

        public void UpdateState()
        {
            try
            {
                do
                {
                    if (8 != 0)
                    {
                        if (5 == 0)
                        {
                            continue;
                        }
                        eMState eMState;
                        double num;
                        this.mFile.FileStateGet(out eMState, out num);
                    }
                }
                while (false);
            }
            catch
            {
                while (false)
                {
                }
            }
        }

        public void MediaStop()
        {
            try
            {
                bool flag = this.mFile == null;
                if (2 == 0)
                {
                    goto IL_9A;
                }
                bool arg_1F_0 = flag;
            IL_1F:
                if (arg_1F_0)
                {
                    goto IL_D9;
                }
            IL_25:
                this.mFile.FilePosSet(0.0, 0.0);
                this.mFile.FilePlayStop(0.0);
                if (3 == 0)
                {
                    goto IL_A7;
                }
                //this.mFile.OnFrame -= new IMEvents_OnFrameEventHandler(this, (UIntPtr)ldftn(myPlaylist_OnFrame));
                //this.mFile.OnEvent -= new IMEvents_OnEventEventHandler(this, (UIntPtr)ldftn(MyPlaylist_OnEvent));
                this.mFile.OnFrame -= new IMEvents_OnFrameEventHandler(myPlaylist_OnFrame);
                this.mFile.OnEvent -= new IMEvents_OnEventEventHandler(MyPlaylist_OnEvent);
            IL_9A:
                this.mFile.ObjectClose();
            IL_A7:
                bool expr_AE = arg_1F_0 = (this.clientWin == null);
                if (6 == 0)
                {
                    goto IL_1F;
                }
                if (!expr_AE)
                {
                    if (false)
                    {
                        goto IL_25;
                    }
                   // this.clientWin.StopMediaPlay(new bool?(true));
                }
                if (false)
                {
                    goto IL_25;
                }
            IL_D9: ;
            }
            catch
            {
                if (2 != 0)
                {
                }
            }
        }

        public void UnloadMediaPlayer()
        {
            bool arg_3C_0;
            if (!false)
            {
                this.MediaStop();
                arg_3C_0 = (this.mFile == null);
                goto IL_13;
            }
            bool flag;
            while (true)
            {
            IL_15:
                if (false)
                {
                    goto IL_1F;
                }
                bool expr_3F = arg_3C_0 = flag;
                if (false)
                {
                    goto IL_13;
                }
                if (!expr_3F)
                {
                    goto IL_1F;
                }
            IL_2B:
                if (!false)
                {
                    break;
                }
                continue;
            IL_1F:
                this.mFile.ObjectClose();
                goto IL_2B;
            }
            return;
        IL_13:
            flag = arg_3C_0;
            //goto IL_15;
        }

        private void btStart_Click(object sender, RoutedEventArgs e)
        {
            this.MediaPlay();
        }

        private void MediaPlay()
        {
            do
            {
                try
                {
                    bool arg_74_0;
                    bool expr_0D = arg_74_0 = (this.mFile == null);
                    if (false)
                    {
                        goto IL_74;
                    }
                    bool flag = expr_0D;
                    bool arg_1C_0 = flag;
                IL_1C:
                    if (arg_1C_0)
                    {
                        goto IL_A2;
                    }
                    //this.mFile.OnFrame += new IMEvents_OnFrameEventHandler(this, (UIntPtr)ldftn(myPlaylist_OnFrame));
                    //this.mFile.OnEvent += new IMEvents_OnEventEventHandler(this, (UIntPtr)ldftn(MyPlaylist_OnEvent));
                    this.mFile.OnFrame += new IMEvents_OnFrameEventHandler(myPlaylist_OnFrame);
                    this.mFile.OnEvent += new IMEvents_OnEventEventHandler(MyPlaylist_OnEvent);
                IL_62:
                    string text;
                    this.mFile.FileNameGet(out text);
                    arg_74_0 = (text == null);
                IL_74:
                    flag = arg_74_0;
                    bool expr_75 = arg_1C_0 = flag;
                    if (false)
                    {
                        goto IL_1C;
                    }
                    if (!expr_75)
                    {
                        this.mFile.FileRateSet(1.0);
                        this.mFile.FilePlayStart();
                        if (false)
                        {
                            goto IL_62;
                        }
                    }
                IL_A2: ;
                }
                catch
                {
                    while (false)
                    {
                    }
                }
            }
            while (false);
        }

        private void btPause_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (this.mFile != null)
                {
                    this.mFile.FilePlayPause(0.0);
                }
            }
            catch
            {
            }
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                this.MediaStop();
                if (7 != 0)
                {
                    if (4 == 0)
                    {
                        continue;
                    }
                    MFileClass expr_0E = this.mFile;
                    if (6 == 0)
                    {
                        goto IL_17;
                    }
                    expr_0E.ObjectClose();
                    goto IL_17;
                }
            IL_22:
                if (false)
                {
                    continue;
                }
                this.btnClose.Click -= new RoutedEventHandler(this.btnClose_Click);
                if (!false)
                {
                    break;
                }
            IL_17:
                Marshal.ReleaseComObject(this.mFile);
                goto IL_22;
            }
        }

        public void Dispose()
        {
            GC.Collect();
        }

        private void btnFullScreen_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                bool arg_7A_0;
                if (!false)
                {
                    arg_7A_0 = (this.MPreviewControl1.m_pPreview == null);
                    goto IL_13;
                }
                goto IL_49;
            IL_18:
                if (8 == 0)
                {
                    continue;
                }
                bool flag;
                if (!flag)
                {
                    this.MPreviewControl1.m_pPreview.PreviewFullScreen("", 1, -1);
                }
                bool expr_40 = arg_7A_0 = (this.clientWin == null);
                if (7 != 0)
                {
                    if (8 == 0)
                    {
                        goto IL_49;
                    }
                    flag = expr_40;
                    goto IL_49;
                }
            IL_13:
                flag = arg_7A_0;
                goto IL_18;
            IL_49:
                bool expr_99 = arg_7A_0 = flag;
                if (6 == 0)
                {
                    goto IL_13;
                }
                if (expr_99)
                {
                    break;
                }
                //this.clientWin.mPreviewControl.m_pPreview.PreviewFullScreen("", 1, -1);
                if (!false)
                {
                    break;
                }
                goto IL_18;
            }
        }

        private void btPrev_Click(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_19;
            }
        IL_04:
            if (6 == 0)
            {
                goto IL_30;
            }
            this.mFile.FileRateSet(-1.0);
        IL_19:
            if (!false)
            {
                this.mFile.FilePlayPause(0.0);
            }
        IL_30:
            if (!false)
            {
                return;
            }
            goto IL_04;
        }

        private void btNext_Click(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_19;
            }
        IL_04:
            if (6 == 0)
            {
                goto IL_30;
            }
            this.mFile.FileRateSet(1.0);
        IL_19:
            if (!false)
            {
                this.mFile.FilePlayPause(0.0);
            }
        IL_30:
            if (!false)
            {
                return;
            }
            goto IL_04;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                while (true)
                {
                    this.MediaStop();
                    while (true)
                    {
                    IL_07:
                        this.mFile.ObjectClose();
                        if (-1 != 0)
                        {
                            Marshal.ReleaseComObject(this.mFile);
                            this.vsMediaFileName = string.Empty;
                        }
                        if (!false)
                        {
                            this.OnExecuteMethodML();
                            while (!false)
                            {
                                if (2 == 0)
                                {
                                    goto IL_07;
                                }
                                if (3 != 0)
                                {
                                    break;
                                }
                            }
                            goto IL_3C;
                        }
                        break;
                    }
                }
            IL_3C: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            this.HideHandlerDialog();
        }

        private void HideHandlerDialog()
        {
            if (-1 != 0)
            {
                if (8 != 0 && true)
                {
                    if (7 == 0)
                    {
                        return;
                    }
                    base.Visibility = Visibility.Collapsed;
                    this._parent.IsEnabled = true;
                }
            }
            this._parent.Visibility = Visibility.Visible;
        }

        private void btnExtract_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                while (true)
                {
                IL_01:
                    while (true)
                    {
                    IL_02:
                        bool validFrame = this.ValidFrame;
                        bool arg_16_0 = validFrame;
                    IL_16:
                        while (arg_16_0)
                        {
                            while (true)
                            {
                                double dblPos;
                                this.mFile.FilePosGet(out dblPos);
                                MFrame mFrame;
                                object[] array;
                                do
                                {
                                    this.mFile.FileFrameGet(dblPos, 0.0, out mFrame);
                                    if (3 == 0)
                                    {
                                        goto IL_01;
                                    }
                                    array = new object[8];
                                }
                                while (8 == 0);
                                array[0] = this.RFID.ToString();
                                array[1] = "_";
                                array[2] = MLFrameExtractor.counter;
                                array[3] = "#";
                                array[4] = this.MediaType.ToString();
                                array[5] = "@";
                                if (2 == 0)
                                {
                                    goto IL_02;
                                }
                                array[6] = this.PhotographerId;
                                array[7] = ".jpg";
                                while (true)
                                {
                                    string text = string.Concat(array);
                                    string text2 = this.tempFolderpath + text;
                                    if (8 == 0)
                                    {
                                        break;
                                    }
                                    MLFrameExtractor.counter++;
                                    bool arg_158_0;
                                    bool expr_117 = arg_16_0 = (arg_158_0 = !File.Exists(text2));
                                    if (false)
                                    {
                                        goto IL_16;
                                    }
                                    if (7 != 0)
                                    {
                                        if (!expr_117)
                                        {
                                            File.Delete(text2);
                                        }
                                        mFrame.FrameVideoSaveToFile(text2);
                                        string path = MLHelpers.ExtractFrame(this.CropRatio, text, this.tempFolderpath, text2);
                                        arg_158_0 = this.MoveFrames(path, text);
                                    }
                                    if (!arg_158_0)
                                    {
                                        goto IL_18D;
                                    }
                                    MessageBox.Show("Frame extracted successfully and moved to camera folder.", "IMIX", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
                                    this.txtPos.Text = "0";
                                    if (4 != 0)
                                    {
                                        goto IL_18D;
                                    }
                                }
                            }
                        }
                        goto Block_1;
                    }
                }
            Block_1:
                MessageBox.Show("Requested frame does not exist!", "IMIX", MessageBoxButton.OK, MessageBoxImage.Hand, MessageBoxResult.OK);
                this.txtPos.Text = "0";
            IL_18D: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private bool MoveFrames(string path, string filename)
        {
            bool result;
            if (2 != 0)
            {
                try
                {
                    bool flag = string.IsNullOrEmpty(path);
                    bool arg_19_0 = flag;
                    while (!arg_19_0)
                    {
                        string path2 = Path.Combine(this.HotFolderPath, "Download", this.SubstoreName);
                        bool arg_53_0 = arg_19_0 = File.Exists(Path.Combine(path2, filename));
                        while (!false)
                        {
                            bool expr_53 = arg_19_0 = (arg_53_0 = !arg_53_0);
                            if (!false)
                            {
                                if (!expr_53)
                                {
                                    File.Delete(Path.Combine(path2, filename));
                                    while (8 == 0)
                                    {
                                    }
                                }
                                File.Move(path, Path.Combine(path2, filename));
                                result = true;
                                goto IL_DD;
                            }
                        }
                    }
                    result = false;
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                        result = false;
                    }
                    while (false);
                }
            }
        IL_DD:
            while (false)
            {
            }
            return result;
        }

        private void txtPos_TextChanged(object sender, TextChangedEventArgs e)
        {
            string text = this.txtPos.Text;
            if (this.mFile != null)
            {
                this.mFile.FilePlayPause(0.0);
            }
            bool arg_85_0;
            while (true)
            {
                bool expr_4D = arg_85_0 = this.IsDouble(text);
                if (false)
                {
                    goto IL_85;
                }
                if (expr_4D)
                {
                    break;
                }
                this.ValidFrame = false;
                if (!false)
                {
                    goto Block_5;
                }
            }
        IL_5E:
        IL_5F:
            this.ValidFrame = true;
            double num;
            double num2;
            double num3;
            this.mFile.FileInOutGet(out num, out num2, out num3);
            bool flag = Convert.ToDouble(text) > num3;
            arg_85_0 = flag;
        IL_85:
            if (arg_85_0)
            {
                this.ValidFrame = false;
                if (!false)
                {
                    this.mFile.FilePosSet(num3, 0.0);
                    if (4 == 0)
                    {
                        goto IL_87;
                    }
                }
                goto IL_D3;
            }
        IL_87:
            this.mFile.FilePosSet(Convert.ToDouble(text) + 0.03, 0.0);
        IL_D3:
            if (-1 != 0)
            {
                return;
            }
            goto IL_5E;
        Block_5:
            this.txtPos.Text = "";
            if (false)
            {
                goto IL_5F;
            }
            this.mFile.FilePosSet(0.0, 0.0);
        }

        private bool IsDouble(string value)
        {
            bool result;
            if (!false)
            {
                try
                {
                    if (5 != 0)
                    {
                        double num;
                        bool arg_3A_0 = double.TryParse(value, out num);
                        bool arg_1F_0;
                        bool expr_13;
                        do
                        {
                            bool flag = arg_3A_0;
                            expr_13 = (arg_1F_0 = (arg_3A_0 = !flag));
                        }
                        while (false);
                        if (!false)
                        {
                            bool flag2 = expr_13;
                            arg_1F_0 = flag2;
                        }
                        if (!arg_1F_0)
                        {
                            result = true;
                        }
                        else if (!false)
                        {
                            result = false;
                        }
                    }
                }
                catch (Exception var_2_4E)
                {
                    result = false;
                }
            }
            return result;
        }

        protected virtual void OnExecuteMethodML()
        {
            while (true)
            {
                bool arg_17_0;
                bool arg_34_0 = arg_17_0 = (this.executeParentMethod == null);
                do
                {
                    if (2 != 0)
                    {
                        bool flag;
                        if (7 != 0)
                        {
                            flag = arg_34_0;
                        }
                        arg_34_0 = (arg_17_0 = flag);
                    }
                }
                while (false);
                if (arg_17_0)
                {
                    goto IL_2D;
                }
            IL_19:
                if (false)
                {
                    continue;
                }
            this.executeParentMethod(this, EventArgs.Empty);
            IL_2D:
                if (8 != 0)
                {
                    break;
                }
                goto IL_19;
            }
        }


    }
}
