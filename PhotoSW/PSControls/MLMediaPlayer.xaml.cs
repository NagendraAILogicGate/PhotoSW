using PhotoSW.IMIX.Business;
using ErrorHandler;
using MControls;
using MPLATFORMLib;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms.Integration;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using PhotoSW.Views;

namespace PhotoSW.PSControls
{
    public partial class MLMediaPlayer : UserControl, IComponentConnector
    {
        public MFileClass mFile;

        private string vsMediaFileName = "";

        private DispatcherTimer dispatcherTimer;

        private BackgroundWorker bwCopyFiles = new BackgroundWorker();

        private bool IsMute = false;

        private ClientView clientWin = null;

        private string replayFilePath = string.Empty;

        private int folderCount = 0;

       

        public MLMediaPlayer()
        {
            this.InitializeComponent();
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
            this.clientWin.mPreviewControl.m_pPreview.PreviewFullScreen("", 0, -1);
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

        public MLMediaPlayer(string fileName, string type)
        {
            this.InitializeComponent();
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
            catch (Exception var_0_131)
            {
                return;
            }
            try
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    this.vsMediaFileName = fileName;
                    this.bwCopyFiles.DoWork += new DoWorkEventHandler(this.bwCopyFiles_DoWork);
                    this.bwCopyFiles.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwCopyFiles_RunWorkerCompleted);
                    this.MPreviewControl1.SetControlledObject(this.mFile);
                    this.mFile.FileNameSet(this.vsMediaFileName, "loop=true");
                    if (!string.IsNullOrEmpty(this.vsMediaFileName))
                    {
                        this.MediaPlay();
                    }
                    if (type == "VideoEditor")
                    {
                        this.mpGrid.Height = 400.0;
                    }
                    else if (type == "VideoPlayer")
                    {
                        this.mpGrid.Height = 550.0;
                    }
                    else if (type == "AdvancePreview")
                    {
                        this.mpGrid.Width = 800.0;
                        this.mpGrid.Height = 715.0;
                    }
                    else
                    {
                        this.mpGrid.Height = 500.0;
                    }
                }
            }
            catch (Exception var_1_277)
            {
            }
        }

        public MLMediaPlayer(string fileName, string type, bool playOnclientView)
        {
            this.InitializeComponent();
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
            catch (Exception var_0_131)
            {
                return;
            }
            try
            {
                if (!string.IsNullOrEmpty(fileName))
                {
                    this.vsMediaFileName = fileName;
                    this.bwCopyFiles.DoWork += new DoWorkEventHandler(this.bwCopyFiles_DoWork);
                    this.bwCopyFiles.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwCopyFiles_RunWorkerCompleted);
                    this.MPreviewControl1.SetControlledObject(this.mFile);
                    this.mFile.FileNameSet(this.vsMediaFileName, "loop=true");
                    if (!string.IsNullOrEmpty(this.vsMediaFileName))
                    {
                        this.MediaPlay();
                        if (playOnclientView)
                        {
                            if (this.clientWin == null)
                            {
                                this.LoadClientViewObject();
                            }
                            if (this.clientWin != null)
                            {
                                this.clientWin.PlayVideoOnClient(type, this.mFile, null);
                            }
                        }
                    }
                    if (type == "VideoEditor")
                    {
                        this.mpGrid.Height = 400.0;
                    }
                    else if (type == "VideoPlayer")
                    {
                        this.mpGrid.Height = 550.0;
                    }
                    else if (type == "AdvancePreview")
                    {
                        this.mpGrid.Width = 800.0;
                        this.mpGrid.Height = 715.0;
                    }
                    else
                    {
                        this.mpGrid.Height = 500.0;
                    }
                }
            }
            catch (Exception var_1_2C3)
            {
            }
        }

        private void CreateSecondaryPreview(MFileClass mfile, string source)
        {
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

        private void btLed_Click(object sender, RoutedEventArgs e)
        {
            while (8 != 0 && 5 != 0)
            {
                if (!false)
                {
                    UIElement expr_0C = this.btLed;
                    bool expr_11 = false;
                    if (4 != 0)
                    {
                        expr_0C.IsEnabled = expr_11;
                    }
                    if (2 != 0)
                    {
                        BackgroundWorker expr_1D = this.bwCopyFiles;
                        object expr_24 = this.vsMediaFileName;
                        if (5 != 0)
                        {
                            expr_1D.RunWorkerAsync(expr_24);
                        }
                    }
                    break;
                }
            }
        }

        private object CopyVideoToDisplayFolder(string videofile)
        {
            object result = null;
            //goto IL_07;
            try
            {
                while (true)
                {
                IL_07:
                    if (!ConfigManager.IMIXConfigurations.ContainsKey(62L) || !Convert.ToBoolean(ConfigManager.IMIXConfigurations[62L]))
                    {
                        result = "Video display utility settings not found.";
                        goto IL_14A;
                    }
                    if (4 == 0)
                    {
                        break;
                    }
                    string str = ConfigManager.IMIXConfigurations.ContainsKey(63L) ? ConfigManager.IMIXConfigurations[63L] : null;
                    int num = ConfigManager.IMIXConfigurations.ContainsKey(87L) ? Convert.ToInt32(ConfigManager.IMIXConfigurations[87L]) : 0;
                IL_8D:
                    this.folderCount++;
                    int arg_A0_0 = (num > 0) ? 1 : 0;
                    int arg_A0_1 = 0;
                    while (true)
                    {
                        int arg_11A_0;
                        bool expr_A0 = (arg_11A_0 = ((arg_A0_0 == arg_A0_1) ? 1 : 0)) != 0;
                        if (-1 == 0)
                        {
                            goto IL_119;
                        }
                        if (expr_A0)
                        {
                            goto IL_13B;
                        }
                        int num2 = 1;
                    IL_11C:
                        int expr_11C = arg_A0_0 = num2;
                        int expr_11D = arg_A0_1 = num;
                        if (!true)
                        {
                            continue;
                        }
                        if (expr_11C > expr_11D)
                        {
                            goto Block_13;
                        }
                        string text = str + "\\Display\\Display" + num2.ToString();
                        bool flag = Directory.Exists(text);
                        if (8 != 0)
                        {
                            if (!flag)
                            {
                                Directory.CreateDirectory(text);
                            }
                            string text2 = text + "\\" + Path.GetFileName(videofile);
                            File.Copy(videofile, text2, true);
                            if (-1 == 0)
                            {
                                goto IL_07;
                            }
                            DateTime now = DateTime.Now;
                            File.SetCreationTime(text2, now);
                        }
                        arg_11A_0 = num2;
                    IL_119:
                        num2 = arg_11A_0 + 1;
                        goto IL_11C;
                    }
                IL_141:
                    goto IL_14A;
                IL_13B:
                    result = "Video display utility settings not found.";
                    goto IL_141;
                Block_13:
                    result = "Video copied to display folder successfully!";
                IL_14A:
                    if (!false)
                    {
                        break;
                    }
                    goto IL_8D;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                if (!false)
                {
                }
            }
            return result;
        }

        private void bwCopyFiles_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                do
                {
                    string videofile = Convert.ToString(e.Argument);
                    if (!false)
                    {
                        e.Result = this.CopyVideoToDisplayFolder(videofile);
                        if (false)
                        {
                            break;
                        }
                    }
                }
                while (4 == 0);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                if (true)
                {
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void bwCopyFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UIElement expr_03 = this.btLed;
            bool expr_08 = true;
            if (!false)
            {
                expr_03.IsEnabled = expr_08;
            }
            if (false)
            {
                goto IL_41;
            }
            string arg_6A_0;
            while (e.Result != null)
            {
                if (!false && !false)
                {
                    arg_6A_0 = e.Result.ToString();
                    goto IL_2E;
                }
            }
        IL_26:
            if (false)
            {
                goto IL_31;
            }
            arg_6A_0 = "Video copied to display folder successfully!";
        IL_2E:
            string messageBoxText = arg_6A_0;
        IL_31:
            MessageBox.Show(messageBoxText, "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        IL_41:
            if (2 != 0)
            {
                return;
            }
            goto IL_26;
        }

        private void btReplay_Click(object sender, RoutedEventArgs e)
        {
        }

        private void btStop_Click(object sender, RoutedEventArgs e)
        {
            this.MediaStop();
        }

        public void MediaStop()
        {
            try
            {
                if (this.mFile != null)
                {
                    this.mFile.FilePosSet(0.0, 0.0);
                    this.mFile.FilePlayStop(0.0);
                    //this.mFile.OnFrame -= new IMEvents_OnFrameEventHandler(this, (UIntPtr)ldftn(myPlaylist_OnFrame));
                    //this.mFile.OnEvent -= new IMEvents_OnEventEventHandler(this, (UIntPtr)ldftn(MyPlaylist_OnEvent));
                    this.mFile.ObjectClose();
                    if (!false)
                    {
                    }
                }
            }
            catch
            {
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
                if (2 != 0)
                {
                    try
                    {
                        bool flag = this.mFile == null;
                        bool arg_73_0;
                        bool expr_99 = arg_73_0 = flag;
                        if (false)
                        {
                            goto IL_73;
                        }
                        if (expr_99)
                        {
                            goto IL_87;
                        }
                    //IL_25:
                    //    this.mFile.OnFrame += new IMEvents_OnFrameEventHandler(this, (UIntPtr)ldftn(myPlaylist_OnFrame));
                    //    this.mFile.OnEvent += new IMEvents_OnEventEventHandler(this, (UIntPtr)ldftn(MyPlaylist_OnEvent));
                    IL_5C:
                        if (8 != 0)
                        {
                            string text;
                            this.mFile.FileNameGet(out text);
                            flag = (text == null);
                        }
                        arg_73_0 = flag;
                    IL_73:
                        if (!arg_73_0)
                        {
                            this.mFile.FilePlayStart();
                            if (false)
                            {
                                //goto IL_25;
                            }
                        }
                    IL_87:
                        if (2 == 0)
                        {
                            goto IL_5C;
                        }
                    }
                    catch
                    {
                    }
                }
            }
            while (4 == 0);
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
            if (!false)
            {
                this.MediaStop();
            }
            do
            {
                this.mFile.ObjectClose();
                if (!false)
                {
                    if (false)
                    {
                        continue;
                    }
                    Marshal.ReleaseComObject(this.mFile);
                }
            }
            while (false);
        }

        public void Dispose()
        {
            GC.Collect();
        }

        private void btMute_Click(object sender, RoutedEventArgs e)
        {
            this.IsMute = !this.IsMute;
            IMProps iMProps = this.mFile;
            if (!this.IsMute)
            {
                iMProps.PropsSet("object::audio_gain", "1");
                this.imgMute.Source = new BitmapImage(new Uri("/images/mute.png", UriKind.Relative));
                this.btMute.ToolTip = "Mute";
            }
            else
            {
                iMProps.PropsSet("object::audio_gain", "-100");
                this.imgMute.Source = new BitmapImage(new Uri("/images/mute-on.png", UriKind.Relative));
                this.btMute.ToolTip = "Unmute";
            }
        }

        private void sldVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (4 == 0)
            {
                goto IL_74;
            }
        IL_04:
            double num = this.sldVolume.Value / this.sldVolume.Maximum;
            bool flag = this.MPreviewControl1.m_pPreview == null;
            if (4 == 0)
            {
                return;
            }
            if (!flag)
            {
                this.MPreviewControl1.m_pPreview.PreviewAudioVolumeSet("", -1, -100.0 * (1.0 - num));
            }
        IL_74:
            if (false)
            {
                goto IL_04;
            }
            this.sldVolume.UpdateLayout();
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
                bool expr_40 = false;
                 expr_40 = arg_7A_0 = (this.clientWin == null);
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
                this.clientWin.mPreviewControl.m_pPreview.PreviewFullScreen("", 1, -1);
                if (!false)
                {
                    break;
                }
                goto IL_18;
            }
        }

    }
}
