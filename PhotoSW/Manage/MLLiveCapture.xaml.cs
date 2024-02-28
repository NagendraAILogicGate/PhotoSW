using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using ErrorHandler;
using MCHROMAKEYLib;
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
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using System.Windows.Threading;
using System.Xml;
using PhotoSW.Views;
using DigiPhoto;

namespace PhotoSW.Manage
{
    public partial class MLLiveCapture : Window, IComponentConnector, IStyleConnector
    {
        public UIElement _parent;

        private bool _result = false;

        private MComposerClass m_objComposer;

        public MWriterClass m_objWriter;

        private IMConfig m_pConfigRoot;

        private MPLATFORMLib.IMPersist m_pMPersist;

        private IMStreams m_pMixerStreams;

        private MPreviewControl mPreviewControl = new MPreviewControl();

        private string outputFormat = "mp4";

        private BackgroundWorker bwRoute = new BackgroundWorker();

        private BackgroundWorker bwSaveVideos = new BackgroundWorker();

        private BusyWindow bs = new BusyWindow();

        private string processVideoTemp = Environment.CurrentDirectory + "\\DigiProcessVideoTemp\\";

        private List<VideoScene> lstVideoScene;

        private DispatcherTimer VidTimer;

        private PhotoSW.IMIX.Business.VideoSceneBusiness business;

        private bool CancelbwRoute = false;

        private int VideoLength = 0;

        private string tempFile;

        private string path_tempThumbnail;

        private LstMyItems objLast;

        public string IsGoupped;

        private int frameCount = 0;

        private string _guestVideoObject;

        private bool _isVideoSaved = true;

        private int FlipMode = 0;

        private List<VideoSceneObject> lstVideoSceneObject = new List<VideoSceneObject>();

        private bool GoToVOS = false;

        private MElement SelectedTreeElement;

        private string strDefaultSceneSettings = string.Empty;

        private string strCapturePath_or_URL = string.Empty;

        private bool thumCaptured = false;

        private int subStoreID = 0;

        private int locationId;

        private Hashtable htVideoObjects = new Hashtable();

        private bool ShowHideSet = false;

        private bool isRightPnlVisible = false;


        private EventHandler onLoad;
        public event EventHandler OnLoad
        {
            add
            {
                do
                {
                IL_00:
                    EventHandler eventHandler = this.onLoad;
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
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.onLoad, value2, eventHandler2);
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
                    EventHandler eventHandler = this.onLoad;
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
                            eventHandler = Interlocked.CompareExchange<EventHandler>(ref this.onLoad, value2, eventHandler2);
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

        public MLLiveCapture()
        {
            this.InitializeComponent();
            this.VidTimer = new DispatcherTimer();
            this.VidTimer.Tick += new EventHandler(this.VidTimer_Tick);
            this.bwSaveVideos.DoWork += new DoWorkEventHandler(this.bwSaveVideos_DoWork);
            this.bwSaveVideos.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwSaveVideos_RunWorkerCompleted);
            base.Loaded += new RoutedEventHandler(this.MainWindow_Loaded);
            if (!Directory.Exists(this.processVideoTemp))
            {
                Directory.CreateDirectory(this.processVideoTemp);
            }
            try
            {
                this.m_objComposer = new MComposerClass();
                this.m_objWriter = new MWriterClass();
            }
            catch (Exception var_0_171)
            {
                return;
            }
            this.mMixerList1.SetControlledObject(this.m_objComposer);
            this.mElementsTree1.SetControlledObject(this.m_objComposer);
            this.mPreviewComposerControl.SetControlledObject(this.m_objComposer);
            this.mFormatControl1.SetControlledObject(this.m_objComposer);
            this.mFormatControl1.SetControlledObject(this.m_objWriter);
            this.mPersistControl1.SetControlledObject(this.m_objComposer);
            this.mScenesCombo1.SetControlledObject(this.m_objComposer);
            this.SetWriterControlledObject(this.m_objWriter);
            this.mConfigList1.SetControlledObject(this.m_objWriter);
            this.mConfigList1.OnConfigChanged += new EventHandler(this.mConfigList1_OnConfigChanged);
            this.mScenesCombo1.OnActiveSceneChange += new EventHandler(this.mScenesCombo1_OnActiveSceneChange);
            this.mMixerList1.OnMixerSelChanged += new EventHandler(this.mMixerList1_OnMixerSelChanged);
            this.mPersistControl1.OnLoad += new EventHandler(this.mPersistControl1_OnLoad);
            this.FillSenders(this.m_objWriter);
            this.mConfigList1_OnConfigChanged(null, EventArgs.Empty);
            this.mFormatControl1.comboBoxVideo.SelectedIndex = 0;
            this.mFormatControl1.comboBoxAudio.SelectedIndex = 0;
            this.mAttributesList1.ElementDescriptors = MHelpers.MComposerElementDescriptors;
            this.mElementsTree1.ElementDescriptors = MHelpers.MComposerElementDescriptors;
            this.m_objComposer.ObjectStart(null);
            this.MPersistSetControlledObject(this.m_objComposer);
            if (this.mPreviewComposerControl.m_pPreview != null)
            {
                this.mPreviewComposerControl.m_pPreview.PreviewEnable("", 0, 1);
            }
            this.ShowHideSettings(this.ShowHideSet);
            this.SetFormatControlSize();
            this.FillPositionDropDown();
        }

        private void bwSaveVideos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (-1 == 0)
            {
                goto IL_2C;
            }
            Window expr_06 = this.bs;
            if (4 != 0)
            {
                expr_06.Hide();
            }
        IL_10:
            bool flag = !this.GoToVOS;
        IL_1C:
            if (flag)
            {
                goto IL_31;
            }
            if (!false)
            {
                this.HideHandlerDialog();
            }
            this.ShowVOS();
        IL_2C:
            if (5 == 0)
            {
                goto IL_10;
            }
        IL_31:
            if (!false)
            {
                return;
            }
            goto IL_1C;
        }

        private void bwSaveVideos_DoWork(object sender, DoWorkEventArgs e)
        {
            bool arg_17_0;
            bool expr_0B = arg_17_0 = !File.Exists(this.tempFile);
            if (false)
            {
                goto IL_17;
            }
            bool flag = expr_0B;
        IL_12:
            if (4 == 0)
            {
                goto IL_47;
            }
            arg_17_0 = flag;
        IL_17:
            if (arg_17_0)
            {
                goto IL_2E;
            }
            this.saveOutputVideo();
            if (false)
            {
                goto IL_12;
            }
            this.GoToVOS = true;
            goto IL_4B;
        IL_2E:
            this.GoToVOS = false;
            System.Windows.MessageBox.Show("Video not found!\n", "Video Editor", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
        IL_47:
            if (3 != 0)
            {
            }
        IL_4B:
            if (true)
            {
                return;
            }
            goto IL_2E;
        }

        private void SetFormatControlSize()
        {
            if (7 != 0)
            {
                if (!false)
                {
                    System.Windows.Forms.Control expr_09 = this.mConfigList1;
                    int expr_0E = 250;
                    if (!false)
                    {
                        expr_09.Width = expr_0E;
                    }
                    this.mConfigList1.Columns[0].Width = 95;
                }
            }
            this.mConfigList1.Columns[1].Width = 150;
            this.mConfigList1.Height = 100;
        }

        private void m_objComposer_OnFrame(string bsChannelID, object pMFrame)
        {
            while (pMFrame != null)
            {
                this.frameCount++;
                if (!false)
                {
                    if (4 != 0)
                    {
                        IEnumerator enumerator = this.htVideoObjects.Keys.GetEnumerator();
                        try
                        {
                            while (true)
                            {
                                MElement mElement;
                                if (!false)
                                {
                                    if (!enumerator.MoveNext())
                                    {
                                        break;
                                    }
                                    object current = enumerator.Current;
                                    mElement = this.GetMElement(current.ToString());
                                    this.ApplyVideoObjectRoute(mElement, (Hashtable)this.htVideoObjects[current], this.frameCount);
                                }
                                Marshal.ReleaseComObject(mElement);
                            }
                        }
                        finally
                        {
                            IDisposable disposable;
                            if (!false)
                            {
                                disposable = (enumerator as IDisposable);
                                if (disposable == null)
                                {
                                    goto IL_BB;
                                }
                            }
                            disposable.Dispose();
                        IL_BB: ;
                        }
                    }
                    while (false)
                    {
                    }
                    if (this.frameCount == 5)
                    {
                        this.StartWriter();
                    }
                IL_D8:
                    if (4 != 0)
                    {
                        break;
                    }
                    goto IL_D8;
                }
            }
            Marshal.ReleaseComObject(pMFrame);
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.loadSceneCombo();
            if (!false)
            {
                bool arg_78_0 = this.cmbScene.SelectedValue == null;
                bool expr_7B;
                do
                {
                    bool flag = arg_78_0;
                    expr_7B = (arg_78_0 = flag);
                }
                while (false);
                if (!expr_7B)
                {
                    this.loadScene((int)this.cmbScene.SelectedValue);
                    if (2 != 0)
                    {
                        return;
                    }
                }
                else
                {
                    this.enableDisableControls(false);
                }
                System.Windows.MessageBox.Show("No video scene found!\n", "Video Editor", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
            }
        }

        private void enableDisableControls(bool value)
        {
            this.btnStartProcess.IsEnabled = value;
            do
            {
                this.btnPreviewVideo.IsEnabled = value;
                if (!false && !false)
                {
                    if (!true)
                    {
                        return;
                    }
                    UIElement expr_39 = this.btnPauseProcess;
                    if (!false)
                    {
                        expr_39.IsEnabled = value;
                    }
                    if (false)
                    {
                        continue;
                    }
                    this.btnSaveFile.IsEnabled = value;
                    this.btnStopProcess.IsEnabled = value;
                }
            }
            while (false);
            if (!value)
            {
                this.stkQuickSettings.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.stkQuickSettings.Visibility = Visibility.Visible;
            }
        }

        private void mPersistControl1_OnLoad(object sender, EventArgs e)
        {
        IL_00:
            while (8 != 0)
            {
                do
                {
                    this.mMixerList1.UpdateList(true, 1);
                    if (2 == 0)
                    {
                        goto IL_26;
                    }
                    if (5 == 0)
                    {
                        goto IL_00;
                    }
                }
                while (false);
                MElementsTree expr_1B = this.mElementsTree1;
                bool expr_20 = false;
                if (3 != 0)
                {
                    expr_1B.UpdateTree(expr_20);
                }
            IL_26:
                break;
            }
        }

        public object MPersistSetControlledObject(object pObject)
        {
            object pMPersist;
            if (true)
            {
                pMPersist = this.m_pMPersist;
                try
                {
                    this.m_pMPersist = (MPLATFORMLib.IMPersist)pObject;
                }
                catch (Exception)
                {
                    if (7 != 0)
                    {
                    }
                    while (false || false)
                    {
                    }
                }
            }
            object expr_45 = pMPersist;
            object result;
            if (4 != 0)
            {
                result = expr_45;
            }
            return result;
        }

        public bool ShowPanHandlerDialog()
        {
            bool result;
            if (-1 != 0)
            {
                if (8 != 0 && true)
                {
                    if (7 == 0)
                    {
                        return result;
                    }
                    base.Visibility = Visibility.Visible;
                    this._parent.IsEnabled = false;
                }
            }
            result = this._result;
            return result;
        }

        private void HideHandlerDialog()
        {
            do
            {
                if (true)
                {
                    try
                    {
                        while (true)
                        {
                            bool expr_13 = this.m_objComposer == null;
                            bool flag;
                            if (!false)
                            {
                                flag = expr_13;
                            }
                            if (!flag)
                            {
                                this.m_objComposer.ObjectClose();
                            }
                            flag = (this.m_objWriter == null);
                            if (!flag)
                            {
                                goto IL_37;
                            }
                            goto IL_47;
                        IL_56:
                            Marshal.FinalReleaseComObject(this.m_objWriter);
                            if (6 != 0)
                            {
                                break;
                            }
                            continue;
                        IL_37:
                            if (8 == 0)
                            {
                                goto IL_56;
                            }
                            this.m_objWriter.ObjectClose();
                        IL_47:
                            if (-1 != 0)
                            {
                                this.mMixerList1.ClearList();
                                goto IL_56;
                            }
                            goto IL_37;
                        }
                    }
                    catch (Exception var_0_93)
                    {
                    }
                }
            }
            while (7 == 0);
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                if (!true)
                {
                    goto IL_5A;
                }
                if (this._isVideoSaved)
                {
                    goto IL_5A;
                }
                MessageBoxResult expr_82 = System.Windows.MessageBox.Show("Video not saved, would you still like to exit?", "Video Editor", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                MessageBoxResult messageBoxResult;
                if (!false)
                {
                    messageBoxResult = expr_82;
                }
                bool arg_8F_0 = messageBoxResult != MessageBoxResult.Yes;
                bool expr_92;
                do
                {
                    bool flag = arg_8F_0;
                    expr_92 = (arg_8F_0 = flag);
                }
                while (8 == 0);
                if (!expr_92)
                {
                    this.HideHandlerDialog();
                    if (-1 != 0)
                    {
                        this.ShowVOS();
                    }
                }
                if (false)
                {
                    goto IL_60;
                }
            IL_69:
                if (7 != 0)
                {
                    break;
                }
                continue;
            IL_60:
                this.ShowVOS();
                goto IL_69;
            IL_5A:
                this.HideHandlerDialog();
                goto IL_60;
            }
        }

        private void ShowVOS()
        {
            RobotImageLoader.RFID = "0";
            RobotImageLoader.SearchCriteria = "PhotoId";
            SearchResult searchResult = null;
            IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator();
            try
            {
                Window window;
                do
                {
                    bool flag = enumerator.MoveNext();
                    if (!false && !flag)
                    {
                        goto IL_6E;
                    }
                    window = (Window)enumerator.Current;
                }
                while (!(window.Title == "View/Order Station"));
                searchResult = (SearchResult)window;
            IL_6E: ;
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                bool flag = disposable == null;
                do
                {
                    if (!flag)
                    {
                        if (!false)
                        {
                            disposable.Dispose();
                        }
                    }
                }
                while (3 == 0);
            }
            if (5 != 0)
            {
                bool flag = searchResult != null;
                if (3 == 0 || !flag)
                {
                    searchResult = new SearchResult();
                }
                if (RobotImageLoader.GroupImages.Count == 0 && this.IsGoupped == "View All")
                {
                    this.IsGoupped = "View Group";
                }
            }
            while (4 != 0)
            {
                searchResult.pagename = "Saveback";
                searchResult.Savebackpid = Convert.ToString(RobotImageLoader.PrintImages[RobotImageLoader.PrintImages.Count - 1].PhotoId);
                if (!false)
                {
                    searchResult.Show();
                    searchResult.LoadWindow();
                    base.Close();
                    break;
                }
            }
        }

        public object SetWriterControlledObject(object pObject)
        {
            object pConfigRoot;
            if (true)
            {
                pConfigRoot = this.m_pConfigRoot;
                try
                {
                    this.m_pConfigRoot = (IMConfig)pObject;
                }
                catch (Exception)
                {
                    if (7 != 0)
                    {
                    }
                    while (false || false)
                    {
                    }
                }
            }
            object expr_45 = pConfigRoot;
            object result;
            if (4 != 0)
            {
                result = expr_45;
            }
            return result;
        }

        private void mScenesCombo1_OnActiveSceneChange(object sender, EventArgs e)
        {
            this.mElementsTree1.UpdateTree(false);
        }

        private void mElementsTree1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (!false)
            {
                try
                {
                    MElement mElement = (MElement)e.Node.Tag;
                    this.SelectedTreeElement = mElement;
                    this.mAttributesList1.SetControlledObject(mElement);
                    string text;
                    string strAttributes;
                    mElement.ElementGet(out text, out strAttributes);
                    if (string.IsNullOrEmpty(this.strDefaultSceneSettings))
                    {
                        this.strDefaultSceneSettings = strAttributes;
                    }
                    this.GetElementInformation(strAttributes);
                    bool flag;
                    do
                    {
                        flag = false;
                        if (false)
                        {
                            goto IL_E0;
                        }
                    }
                    while (2 == 0);
                    string[] strDefaultElements = MHelpers.strDefaultElements;
                    int num = 0;
                    while (true)
                    {
                    IL_BD:
                        int arg_C3_0 = num;
                        int arg_C2_0 = strDefaultElements.Length;
                        while (arg_C3_0 < arg_C2_0)
                        {
                            string value = strDefaultElements[num];
                            if (text.Contains(value))
                            {
                                goto Block_6;
                            }
                            int expr_B4 = arg_C3_0 = num;
                            int expr_B7 = arg_C2_0 = 1;
                            if (expr_B7 != 0)
                            {
                                num = expr_B4 + expr_B7;
                                goto IL_BD;
                            }
                        }
                        goto IL_CB;
                    }
                Block_6:
                    this.mPreviewComposerControl.SetEditElement(mElement);
                    flag = true;
                IL_CB:
                    if (flag)
                    {
                        goto IL_E1;
                    }
                IL_D2:
                    this.mPreviewComposerControl.SetEditElement(null);
                IL_E0:
                IL_E1:
                    if (5 == 0)
                    {
                        goto IL_D2;
                    }
                }
                catch (Exception)
                {
                    while (!true)
                    {
                    }
                }
            }
        }

        private void mConfigList1_OnConfigChanged(object sender, EventArgs e)
        {
            string text;
            do
            {
                if (false || -1 != 0)
                {
                    this.m_objWriter.ConfigGetAll(1, out text);
                }
            }
            while (6 == 0);
            this.comboBoxProps.Text = text;
            MWriterClass expr_25 = this.m_objWriter;
            string expr_2A = "format";
            IMAttributes iMAttributes;
            if (3 != 0)
            {
                string text2;
                expr_25.ConfigGet(expr_2A, out text2, out iMAttributes);
            }
            int num = 0;
            try
            {
                iMAttributes.AttributesBoolGet("network", out num);
            }
            catch (Exception)
            {
                if (!false)
                {
                }
                if (5 != 0)
                {
                }
            }
        }

        private void btnStartProcess_Click(object sender, RoutedEventArgs e)
        {
            this.EnableORDisableControls(false);
            if (!false)
            {
            }
            this.thumCaptured = false;
        //    this.m_objComposer.OnFrame += new IMEvents_OnFrameEventHandler(this, (UIntPtr)ldftn(m_objComposer_OnFrame));
            this.CancelbwRoute = false;
            this.InitializeAllInputFiles();
        }

        private void InitializeAllInputFiles()
        {
            try
            {
                string empty = string.Empty;
                while (!false)
                {
                    int num = 0;
                    this.m_objComposer.StreamsGetCount(out num);
                    this.m_objComposer.FilePlayPause(0.0);
                    int num2 = 0;
                    while (!false)
                    {
                        bool flag = num2 < num;
                        if (false)
                        {
                            break;
                        }
                        if (!flag)
                        {
                            this.m_objComposer.FilePlayStart();
                            goto IL_B6;
                        }
                        if (6 == 0)
                        {
                            break;
                        }
                        MItem mItem;
                        this.m_objComposer.StreamsGetByIndex(num2, out empty, out mItem);
                        try
                        {
                            mItem.FilePosSet(0.0, 0.0);
                        }
                        catch
                        {
                            while (6 == 0)
                            {
                            }
                        }
                        num2++;
                    }
                }
            IL_B6: ;
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

        private void StartWriter()
        {
            while (true)
            {
                this.VidTimer.Start();
                if (6 != 0)
                {
                    goto IL_17;
                }
                goto IL_AA;
            IL_144:
                if (!false)
                {
                    break;
                }
                continue;
            IL_17:
                eMState eMState;
                if (2 != 0)
                {
                    this.m_objWriter.ObjectStateGet(out eMState);
                }
                bool flag = eMState != eMState.eMS_Paused;
                if (!false)
                {
                    if (!flag)
                    {
                        if (false)
                        {
                            goto IL_142;
                        }
                        this.m_objWriter.ObjectStart(this.m_objComposer);
                    }
                    if (eMState != eMState.eMS_Running)
                    {
                        string text;
                        IMAttributes iMAttributes;
                        this.m_objWriter.ConfigGet("format", out text, out iMAttributes);
                        goto IL_AA;
                    }
                    this.m_objWriter.WriterNameSet("", "");
                }
            IL_142:
                goto IL_144;
            IL_AA:
                if (!false)
                {
                    this.tempFile = this.processVideoTemp + "Output." + this.outputFormat;
                    this.strCapturePath_or_URL = this.tempFile;
                    try
                    {
                        this.m_objWriter.WriterNameSet(this.strCapturePath_or_URL, (this.comboBoxProps.Text != "") ? this.comboBoxProps.Text : "video::bitrate=1M audio::bitrate=64K");
                        if (!false)
                        {
                            this.m_objWriter.ObjectStart(this.m_objComposer);
                        }
                    }
                    catch (Exception serviceException)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    goto IL_142;
                }
                goto IL_17;
            }
        }

        private void btnStopProcess_Click(object sender, RoutedEventArgs e)
        {
            this.StopWriter(true);
            int arg_19_0 = string.IsNullOrEmpty(this.strCapturePath_or_URL) ? 1 : 0;
            bool expr_A2;
            while (true)
            {
                bool arg_2E_0;
                bool arg_9F_0;
                if (arg_19_0 == 0)
                {
                    if (-1 != 0)
                    {
                        arg_2E_0 = File.Exists(this.strCapturePath_or_URL);
                        goto IL_2D;
                    }
                    goto IL_54;
                }
                else
                {
                    if (5 == 0)
                    {
                        goto IL_53;
                    }
                    arg_9F_0 = ((arg_19_0 = 1) != 0);
                }
            IL_36:
                if (false)
                {
                    continue;
                }
                bool flag = arg_9F_0;
                if (false)
                {
                    return;
                }
                expr_A2 = (arg_2E_0 = flag);
                if (2 != 0)
                {
                    break;
                }
            IL_2D:
                arg_9F_0 = ((arg_19_0 = ((!arg_2E_0) ? 1 : 0)) != 0);
                goto IL_36;
            }
            if (!expr_A2)
            {
                File.Delete(this.strCapturePath_or_URL);
            }
        IL_53:
        IL_54:
            this.EnableORDisableControls(true);
            this.txbPause.Text = "Pause";
        }

        private void buttonChromaProps_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = this.mMixerList1.SelectedItem == null;
                if (flag)
                {
                    goto IL_14C;
                }
                MItem mItem = null;
                this.LoadChromaPlugin(true, this.mMixerList1.SelectedItem);
                MCHROMAKEYLib.MChromaKey chromakeyFilter = this.GetChromakeyFilter(this.mMixerList1.SelectedItem);
                try
                {
                    ((MPLATFORMLib.IMProps)chromakeyFilter).PropsSet("gpu_mode", "true");
                    mItem = this.mMixerList1.SelectedItem;
                }
                catch
                {
                }
                flag = (chromakeyFilter == null);
            IL_89:
                if (!flag)
                {
                    FormChromaKey formChromaKey = new FormChromaKey(chromakeyFilter);
                    formChromaKey.ShowDialog();
                    string streamId = string.Empty;
                    mItem.FileNameGet(out streamId);
                    ((MPLATFORMLib.IMProps)mItem).PropsGet("stream_id", out streamId);
                    string chromaPath = (from x in this.lstVideoSceneObject
                                         where x.VideoObjectId == streamId
                                         select x).FirstOrDefault<VideoSceneObject>().ObjectFileMapping.ChromaPath;
                    flag = string.IsNullOrEmpty(chromaPath);
                    if (!flag)
                    {
                        flag = !File.Exists(Path.Combine(ConfigManager.FolderPath, chromaPath));
                        if (!flag)
                        {
                            File.Copy(Path.Combine(Environment.CurrentDirectory, "ChromaSettings.xml"), Path.Combine(ConfigManager.FolderPath, chromaPath), true);
                        }
                    }
                }
            IL_14C:
                if (false)
                {
                    goto IL_89;
                }
            }
            catch (Exception var_5_199)
            {
            }
        }

        private MCHROMAKEYLib.MChromaKey GetChromakeyFilter(object source)
        {
            MCHROMAKEYLib.MChromaKey result;
            if (!false)
            {
                result = null;
                try
                {
                    int num = 0;
                    while (true)
                    {
                    IL_11:
                        IMPlugins iMPlugins = (IMPlugins)source;
                        while (true)
                        {
                        IL_20:
                            iMPlugins.PluginsGetCount(out num);
                            while (true)
                            {
                                for (int i = 0; i < num; i++)
                                {
                                    if (-1 == 0)
                                    {
                                        goto IL_20;
                                    }
                                    object obj;
                                    long num2;
                                    iMPlugins.PluginsGetByIndex(i, out obj, out num2);
                                    if (8 == 0)
                                    {
                                        break;
                                    }
                                    try
                                    {
                                        result = (MCHROMAKEYLib.MChromaKey)obj;
                                        break;
                                    }
                                    catch
                                    {
                                        if (8 != 0)
                                        {
                                        }
                                    }
                                }
                                if (5 == 0)
                                {
                                    goto IL_11;
                                }
                                if (!false)
                                {
                                    goto Block_6;
                                }
                            }
                        }
                    }
                Block_6: ;
                }
                catch
                {
                }
            }
            return result;
        }

        private void mMixerList1_OnMixerSelChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ListView listView = (System.Windows.Forms.ListView)sender;
            int arg_1D_0 = listView.SelectedItems.Count;
            int arg_1D_1 = 0;
            int expr_1D;
            int expr_20;
            do
            {
                expr_1D = (arg_1D_0 = ((arg_1D_0 > arg_1D_1) ? 1 : 0));
                expr_20 = (arg_1D_1 = 0);
            }
            while (expr_20 != 0);
            bool flag = expr_1D == expr_20;
            while (true)
            {
                if (!flag)
                {
                    goto IL_31;
                }
                if (-1 != 0)
                {
                    this.buttonChromaProps.IsEnabled = false;
                    if (3 != 0)
                    {
                        return;
                    }
                    goto IL_31;
                }
            IL_5E:
                if (6 != 0)
                {
                    break;
                }
                continue;
            IL_31:
                MCHROMAKEYLib.MChromaKey chromakeyFilter = this.GetChromakeyFilter(listView.SelectedItems[0].ToString());
                this.buttonChromaProps.IsEnabled = true;
                goto IL_5E;
            }
            if (6 != 0)
            {
            }
        }

        private void LoadChromaPlugin(bool onloadChroma, object source)
        {
            if (2 == 0)
            {
                goto IL_A5;
            }
            if (this.mMixerList1.SelectedItem == null)
            {
                return;
            }
            if (false)
            {
                goto IL_9D;
            }
            IMPlugins iMPlugins = source as IMPlugins;
            object obj = null;
            bool expr_41 = false;
            bool flag;
            if (2 != 0)
            {
                flag = expr_41;
            }
            int num;
            iMPlugins.PluginsGetCount(out num);
            int num2 = 0;
            goto IL_B5;
        IL_5C:
            long num3;
            iMPlugins.PluginsGetByIndex(num2, out obj, out num3);
            bool arg_7E_0 = obj.GetType().Name == "CoMChromaKeyClass";
            bool arg_9F_0;
            while (!arg_7E_0)
            {
                arg_9F_0 = (arg_7E_0 = !(obj.GetType().Name == "MChromaKeyClass"));
                if (5 != 0)
                {
                    goto IL_9E;
                }
            }
        IL_9D:
            arg_9F_0 = false;
        IL_9E:
            if (arg_9F_0)
            {
                goto IL_AB;
            }
        IL_A5:
            flag = true;
            goto IL_C0;
        IL_AB:
            if (!false)
            {
                num2++;
            }
        IL_B5:
            if (num2 < num)
            {
                goto IL_5C;
            }
        IL_C0:
            bool arg_D7_0;
            if (flag)
            {
                arg_D7_0 = (!onloadChroma || flag);
            }
            else
            {
                if (false)
                {
                    goto IL_5C;
                }
                arg_D7_0 = false;
            }
            if (!arg_D7_0)
            {
                iMPlugins.PluginsAdd((MCHROMAKEYLib.MChromaKey)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("FF12951C-DC32-42B7-B676-583883EF574E"))), 0L);
                if (false)
                {
                    goto IL_AB;
                }
            }
            this.buttonChromaProps.IsEnabled = true;
        }

        private void FillSenders(IMSenders pSenders)
        {
            while (true)
            {
            IL_00:
                while (true)
                {
                    this.comboBoxExtSources.Items.Clear();
                    this.comboBoxExtSources.Items.Add("<Live Source>");
                    int arg_D1_0 = 0;
                    while (true)
                    {
                        int num = arg_D1_0;
                        pSenders.SendersGetCount(out num);
                        int arg_7E_0;
                        int expr_44 = arg_7E_0 = 0;
                        if (expr_44 != 0)
                        {
                            goto IL_7E;
                        }
                        arg_7E_0 = expr_44;
                        if (expr_44 != 0)
                        {
                            goto IL_7E;
                        }
                        int num2 = expr_44;
                    IL_7F:
                        if (num2 >= num)
                        {
                            break;
                        }
                        if (-1 != 0)
                        {
                            string newItem;
                            MPLATFORMLib.M_VID_PROPS m_VID_PROPS;
                            MPLATFORMLib.M_AUD_PROPS m_AUD_PROPS;
                            pSenders.SendersGetByIndex(num2, out newItem, out m_VID_PROPS, out m_AUD_PROPS);
                            this.comboBoxExtSources.Items.Add(newItem);
                            if (false)
                            {
                                goto IL_00;
                            }
                            int expr_78 = arg_D1_0 = num2;
                            if (!false)
                            {
                                arg_7E_0 = expr_78 + 1;
                                goto IL_7E;
                            }
                            continue;
                        }
                        goto IL_7F;
                    IL_7E:
                        num2 = arg_7E_0;
                        goto IL_7F;
                    }
                    if (!false)
                    {
                        goto Block_6;
                    }
                }
            }
        Block_6:
            this.comboBoxExtSources.SelectedIndex = 0;
        }

        private void ExtractThumbnail()
        {
            MFrame mFrame;
            this.m_objComposer.ObjectFrameGet(out mFrame, "");
            while (8 == 0)
            {
            }
            this.path_tempThumbnail = this.processVideoTemp + "Output.jpg";
            bool flag;
            do
            {
                bool arg_AA_0;
                bool expr_A0 = arg_AA_0 = File.Exists(this.path_tempThumbnail);
                if (!false)
                {
                    arg_AA_0 = !expr_A0;
                }
                flag = arg_AA_0;
            }
            while (2 == 0);
            if (3 != 0)
            {
                if (!flag)
                {
                    if (!false)
                    {
                        File.Delete(this.path_tempThumbnail);
                    }
                }
                mFrame.FrameVideoSaveToFile(this.path_tempThumbnail);
            }
            Marshal.ReleaseComObject(mFrame);
        }

        private void VidTimer_Tick(object sender, EventArgs e)
        {
            decimal num = 0m;
            decimal d = this.VideoLength + 0.043m;
            this.txtStatus.Text = this.UpdateStatus(this.m_objWriter, out num);
            eMState eMState;
            this.m_objWriter.ObjectStateGet(out eMState);
            if (!this.thumCaptured && num > 0.50m)
            {
                this.ExtractThumbnail();
                this.thumCaptured = true;
            }
            this.pbProgress.Value = Convert.ToDouble(num);
            decimal d2 = num / d * 100m;
            this.txtPercentage.Text = Math.Round(d2, 0).ToString() + "%";
            this.txtTimer.Text = num.ToString("0") + " sec";
            if (num >= d)
            {
                this.StopWriter(false);
            }
        }

        private string UpdateStatus(MWriterClass pCapture, out decimal VidLength)
        {
            VidLength = 0m;
            string text = "";
            string result;
            try
            {
                eMState eMState;
                pCapture.ObjectStateGet(out eMState);
                if (7 == 0)
                {
                    goto IL_10C;
                }
                string text2;
                this.m_objWriter.PropsGet("stat::last::server_pid", out text2);
                string expr_4B = "stat::skip";
                string text3;
                if (!false)
                {
                    pCapture.PropsGet(expr_4B, out text3);
                }
                text = string.Concat(new object[]
				{
					" State: ",
					eMState,
					(text3 != null) ? (" Skip rest:" + this.DblStrTrim(text3, 3)) : "",
					" Server PID:",
					text2,
					"\r\n"
				});
                string str;
                pCapture.WriterNameGet(out str);
                text = text + " Path: " + str + "\r\n";
                text += "TOTAL:\r\n";
                string text4;
                pCapture.PropsGet("stat::buffered", out text4);
            IL_F0:
                string text5;
                pCapture.PropsGet("stat::frames", out text5);
                string str2;
                pCapture.PropsGet("stat::fps", out str2);
            IL_10C:
                string str3;
                pCapture.PropsGet("stat::video_time", out str3);
                string text6 = "0";
                pCapture.PropsGet("stat::breaks", out text6);
                string text7 = "0";
                pCapture.PropsGet("stat::frames_dropped", out text7);
                string text8;
                this.m_objWriter.PropsGet("stat::video_len", out text8);
                VidLength = Convert.ToDecimal(text8);
                string text9;
                this.m_objWriter.PropsGet("stat::av_sync_time", out text9);
                string text10;
                this.m_objWriter.PropsGet("stat::av_sync_len", out text10);
                string text11 = text;
                string[] array = new string[20];
                array[0] = text11;
                array[1] = "  Buffers:";
                array[2] = text4;
                array[3] = " Frames:";
                array[4] = text5;
                array[5] = " Fps:";
                array[6] = this.DblStrTrim(str2, 3);
                array[7] = " Dropped:";
                array[8] = text7;
                array[9] = " Breaks:";
                array[10] = text6;
                array[11] = "  Video time:";
                array[12] = this.DblStrTrim(str3, 3);
                array[13] = "\r\n Video Len:";
                if (8 == 0)
                {
                    goto IL_F0;
                }
                array[14] = text8;
                array[15] = " AV Sync time:";
                array[16] = text9;
                array[17] = " AV sync len:";
                array[18] = text10;
                array[19] = "\r\n";
                text = string.Concat(array);
                string text12;
                pCapture.PropsGet("stat::samples", out text12);
                pCapture.PropsGet("stat::audio_time", out str3);
                text11 = text;
                text = string.Concat(new string[]
				{
					text11,
					"  Samples:",
					text12,
					" Audio time:",
					this.DblStrTrim(str3, 3),
					"\r\n"
				});
                text += "LAST:\r\n";
                pCapture.PropsGet("stat::last::frames", out text5);
                str2 = "";
                pCapture.PropsGet("stat::last::fps", out str2);
                str3 = "";
                pCapture.PropsGet("stat::last::video_time", out str3);
                pCapture.PropsGet("stat::breaks", out text6);
                text11 = text;
                int arg_30C_0 = 8;
                while (true)
                {
                IL_30C:
                    array = new string[arg_30C_0];
                    while (5 != 0)
                    {
                        array[0] = text11;
                        array[1] = "  Frames:";
                        array[2] = text5;
                        array[3] = " Breaks:";
                        while (true)
                        {
                            array[4] = text6;
                            array[5] = " Video time:";
                            array[6] = this.DblStrTrim(str3, 3);
                            array[7] = "\r\n";
                            text = string.Concat(array);
                            pCapture.PropsGet("stat::last::samples", out text12);
                            pCapture.PropsGet("stat::last::audio_time", out str3);
                            text11 = text;
                            int expr_384 = arg_30C_0 = 5;
                            if (expr_384 == 0)
                            {
                                goto IL_30C;
                            }
                            array = new string[expr_384];
                            array[0] = text11;
                            array[1] = "  Samples:";
                            array[2] = text12;
                            if (false)
                            {
                                break;
                            }
                            array[3] = " Audio time:";
                            array[4] = this.DblStrTrim(str3, 3);
                            text = string.Concat(array);
                            if (!false)
                            {
                                goto IL_3CE;
                            }
                        }
                    }
                    break;
                }
            IL_3CE:
                result = text;
            }
            catch (Exception var_15_403)
            {
                result = text;
            }
            return result;
        }

        private string DblStrTrim(string str, int nPeriod)
        {
            int num;
            while (true)
            {
            IL_01:
                int arg_0A_0 = (str == null) ? 1 : 0;
                while (arg_0A_0 == 0)
                {
                    num = str.LastIndexOf('.');
                    int arg_50_0;
                    int arg_50_1;
                    if (num >= 0)
                    {
                        arg_50_0 = str.Length;
                        arg_50_1 = num;
                        goto IL_50;
                    }
                    int arg_54_0 = 0;
                IL_53:
                    int num2 = arg_54_0;
                    bool flag = num2 <= nPeriod;
                    if (8 == 0)
                    {
                        goto IL_8E;
                    }
                    if (!flag)
                    {
                        goto Block_3;
                    }
                    goto IL_75;
                IL_9B:
                    int expr_9B = arg_0A_0 = num2;
                    if (false)
                    {
                        continue;
                    }
                    for (int i = expr_9B; i < nPeriod; i++)
                    {
                        str += "0";
                    }
                    if (!false)
                    {
                        goto Block_9;
                    }
                IL_75:
                    int arg_7A_0 = arg_50_0 = num;
                    bool expr_7D;
                    do
                    {
                        int expr_77 = arg_50_1 = 0;
                        if (expr_77 != 0)
                        {
                            goto IL_50;
                        }
                        expr_7D = ((arg_50_0 = (arg_7A_0 = ((arg_7A_0 >= expr_77) ? 1 : 0))) != 0);
                    }
                    while (!true);
                    flag = expr_7D;
                    if (8 == 0)
                    {
                        goto IL_01;
                    }
                    if (flag)
                    {
                        goto IL_9B;
                    }
                IL_8E:
                    str += ".";
                    goto IL_9B;
                IL_50:
                    arg_54_0 = arg_50_0 - arg_50_1 - 1;
                    goto IL_53;
                }
                break;
            }
            string result;
            str = (result = "0");
            return result;
        Block_3:
            result = str.Substring(0, num + nPeriod + 1);
            return result;
        Block_9:
            result = str;
            return result;
        }

        private void btnLoadScene_Click(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_2B;
            }
            if (4 != 0)
            {
                this.strDefaultSceneSettings = string.Empty;
                this.txtPercentage.Text = "0%";
                goto IL_2B;
            }
            while (true)
            {
            IL_5A:
                this.htVideoObjects.Clear();
                if (4 != 0)
                {
                    goto IL_6E;
                }
            }
        IL_2B:
            this.txtTimer.Text = "0 sec";
            if (this.htVideoObjects != null)
            {
                //goto IL_5A;
            }
        IL_6E:
            bool flag = this.cmbScene.SelectedIndex <= 0;
            if (6 != 0 && 6 != 0)
            {
                if (!flag)
                {
                    this.loadScene((int)this.cmbScene.SelectedValue);
                }
            }
        }

        private void loadSceneCombo()
        {
            do
            {
                try
                {
                    this.subStoreID = ConfigManager.SubStoreId;
                    Dictionary<int, string> dictionary;
                    do
                    {
                        this.business = new VideoSceneBusiness();
                        if (!false)
                        {
                            this.lstVideoScene = new List<VideoScene>();
                            this.lstVideoScene = this.business.GetVideoScene(0, new int?(this.subStoreID));
                            dictionary = new Dictionary<int, string>();
                            dictionary.Clear();
                            dictionary.Add(0, "--Select--");
                        }
                        IEnumerator<VideoScene> enumerator = (from o in this.lstVideoScene
                                                              where o.IsActive
                                                              select o).GetEnumerator();
                        try
                        {
                            while (true)
                            {
                                while (true)
                                {
                                    bool arg_D0_0 = enumerator.MoveNext();
                                    bool expr_D2;
                                    do
                                    {
                                        bool flag = arg_D0_0;
                                        expr_D2 = (arg_D0_0 = flag);
                                    }
                                    while (false);
                                    if (!expr_D2)
                                    {
                                        goto Block_9;
                                    }
                                    VideoScene current = enumerator.Current;
                                    dictionary.Add(current.SceneId, current.Name);
                                    if (true)
                                    {
                                    }
                                }
                            }
                        Block_9: ;
                        }
                        finally
                        {
                            bool arg_E7_0;
                            bool expr_DE = arg_E7_0 = (enumerator == null);
                            if (3 != 0)
                            {
                                bool flag = expr_DE;
                                arg_E7_0 = flag;
                            }
                            if (!arg_E7_0)
                            {
                                enumerator.Dispose();
                            }
                        }
                        this.cmbScene.ItemsSource = dictionary;
                    }
                    while (false);
                    if (dictionary.Count <= 0)
                    {
                        goto IL_125;
                    }
                IL_118:
                    this.cmbScene.SelectedIndex = 1;
                IL_125:
                    if (3 == 0)
                    {
                        goto IL_118;
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

        private void LoadVideoObjectList(List<VideoSceneObject> lstVideoObjects)
        {
            foreach (VideoSceneObject current in lstVideoObjects)
            {
                int num = 0;
                MItem mItem;
                this.m_objComposer.StreamsGet(current.VideoObjectId, out num, out mItem);
                string path;
                mItem.FileNameGet(out path);
                current.FileName = Path.GetFileName(path);
            }
            this.datagrdAudioSettings.ItemsSource = lstVideoObjects;
        }

        private void cmbScene_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            do
            {
                int arg_0E_0;
                int arg_14_0 = arg_0E_0 = this.cmbScene.SelectedIndex;
                int arg_0B_0 = 0;
                int expr_11;
                do
                {
                    int arg_11_0;
                    int expr_0B = arg_11_0 = arg_0B_0;
                    if (expr_0B == 0)
                    {
                        arg_14_0 = (arg_0E_0 = ((arg_0E_0 > expr_0B) ? 1 : 0));
                        arg_11_0 = 0;
                    }
                    expr_11 = (arg_0B_0 = arg_11_0);
                }
                while (expr_11 != 0);
                if (arg_14_0 != expr_11)
                {
                    if (!false)
                    {
                        this.loadScene((int)this.cmbScene.SelectedValue);
                    }
                }
            }
            while (false);
        }

        private void loadScene(int sceneId)
        {
            try
            {
                VideoSceneObject videoSceneObject;
                if (!false)
                {
                    this.mFormatControl1.SetControlledObject(this.m_objComposer);
                    this.lstVideoScene = new List<VideoScene>();
                    this.subStoreID = ConfigManager.SubStoreId;
                    this.lstVideoScene = this.business.GetVideoScene(sceneId, new int?(this.subStoreID));
                    do
                    {
                        this.locationId = this.lstVideoScene.FirstOrDefault<VideoScene>().LocationId;
                        this.GetConfigLocationData();
                    }
                    while (false);
                    if (this.lstVideoScene == null)
                    {
                        this.btnStartProcess.IsEnabled = false;
                        System.Windows.MessageBox.Show("No video scene settings found!\n", "PhotoSW", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
                        goto IL_390;
                    }
                    string bsXMLDescOrFile = Path.Combine(ConfigManager.FolderPath, this.lstVideoScene.FirstOrDefault<VideoScene>().ScenePath);
                    this.business = new VideoSceneBusiness();
                    this.lstVideoSceneObject = this.business.GuestVideoObjectBySceneID(sceneId);
                    if (3 == 0)
                    {
                        goto IL_ED;
                    }
                    bool arg_E4_0 = this.lstVideoSceneObject.Count <= 0;
                IL_E4:
                    if (arg_E4_0)
                    {
                        if (-1 != 0)
                        {
                            this.btnStartProcess.IsEnabled = false;
                            System.Windows.MessageBox.Show("No video scene objects found!\n", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
                        }
                        goto IL_36A;
                    }
                IL_ED:
                    this.m_pMPersist = this.m_objComposer;
                    this.m_pMPersist.PersistLoad("", bsXMLDescOrFile, "");
                    this.mMixerList1.UpdateList(true, 1);
                    this.mElementsTree1.UpdateTree(false);
                    videoSceneObject = (from x in this.lstVideoSceneObject
                                        where x.GuestVideoObject
                                        select x).FirstOrDefault<VideoSceneObject>();
                    this._guestVideoObject = videoSceneObject.VideoObjectId;
                    if (false)
                    {
                        goto IL_2FE;
                    }
                    this.objLast = new LstMyItems();
                    this.objLast = RobotImageLoader.PrintImages.LastOrDefault<LstMyItems>();
                    if (!string.IsNullOrEmpty(this._guestVideoObject))
                    {
                        int arg_215_0;
                        int expr_1A4 = arg_215_0 = this.objLast.MediaType;
                        int arg_215_1;
                        int expr_1AA = arg_215_1 = 2;
                        if (expr_1AA != 0)
                        {
                            bool flag = expr_1A4 != expr_1AA;
                            bool expr_1B4 = arg_E4_0 = flag;
                            if (false)
                            {
                                goto IL_E4;
                            }
                            if (!expr_1B4)
                            {
                                this.addFile(Path.Combine(this.objLast.HotFolderPath, "Videos", this.objLast.CreatedOn.ToString("yyyyMMdd"), this.objLast.FileName), this._guestVideoObject);
                                goto IL_2A9;
                            }
                            arg_215_0 = this.objLast.MediaType;
                            arg_215_1 = 3;
                        }
                        if (arg_215_0 == arg_215_1)
                        {
                            this.addFile(Path.Combine(this.objLast.HotFolderPath, "ProcessedVideos", this.objLast.CreatedOn.ToString("yyyyMMdd"), this.objLast.FileName), this._guestVideoObject);
                        }
                        else
                        {
                            this.addFile(Path.Combine(this.objLast.HotFolderPath, this.objLast.CreatedOn.ToString("yyyyMMdd"), this.objLast.FileName), this._guestVideoObject);
                        }
                    }
                }
            IL_2A8:
            IL_2A9:
                this.LoadChromaAndRouteSettings(this.lstVideoSceneObject);
                this.VideoLength = this.lstVideoScene.FirstOrDefault<VideoScene>().VideoLength;
                this.LoadWriterSettings(this.lstVideoScene.FirstOrDefault<VideoScene>().Settings);
                if (false)
                {
                    goto IL_2A8;
                }
                this.pbProgress.Maximum = Convert.ToDouble(this.VideoLength);
            IL_2FE:
                this.LoadVideoObjectList(this.lstVideoSceneObject);
                if (this.FlipMode > 0)
                {
                    MElement guestVideoElement = this.GetGuestVideoElement(videoSceneObject.VideoObjectId);
                    this.ApplyFlip(guestVideoElement, this.FlipMode);
                    Marshal.ReleaseComObject(guestVideoElement);
                }
            IL_36A:
            IL_390: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void addFile(string filePath, string streamId)
        {
            if (true)
            {
                this.m_pMixerStreams = this.m_objComposer;
                goto IL_1B;
            }
            MItem mItem;
            do
            {
            IL_89:
                if (mItem != null)
                {
                    this.mMixerList1.SelectFile(mItem);
                }
                this.mMixerList1.UpdateList(true, 1);
                if (4 == 0)
                {
                    goto IL_21;
                }
            }
            while (8 == 0);
            if (4 != 0)
            {
                return;
            }
            goto IL_21;
        IL_1B:
            mItem = null;
        IL_21:
            System.Windows.Input.Cursor expr_D5 = base.Cursor;
            System.Windows.Input.Cursor cursor;
            if (7 != 0)
            {
                cursor = expr_D5;
            }
            try
            {
                if (true)
                {
                }
                this.m_pMixerStreams.StreamsAdd(streamId, null, filePath, null, out mItem, 0.0);
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("File " + filePath + " can't be added as stream");
            }
            if (-1 != 0)
            {
                base.Cursor = cursor;
                //goto IL_89;
            }
            goto IL_1B;
        }

        private void LoadChromaAndRouteSettings(List<VideoSceneObject> lstVideoSceneObject)
        {
            try
            {
                IEnumerator<VideoSceneObject> expr_211 = (from o in lstVideoSceneObject
                                                          where o.ObjectFileMapping.ChromaPath != null || o.ObjectFileMapping.RoutePath != null
                                                          select o).GetEnumerator();
                IEnumerator<VideoSceneObject> enumerator;
                if (2 != 0)
                {
                    enumerator = expr_211;
                    //goto IL_38;
                }
                try
                {
                    while (true)
                    {
                    IL_38:
                        while (true)
                        {
                            bool arg_DC_0;
                            bool expr_19D = arg_DC_0 = enumerator.MoveNext();
                            if (false)
                            {
                                goto IL_DB;
                            }
                            bool flag = expr_19D;
                            bool arg_E2_0;
                            bool expr_1AA = arg_E2_0 = flag;
                            if (6 == 0)
                            {
                                goto IL_E2;
                            }
                            VideoSceneObject current;
                            if (!expr_1AA)
                            {
                                if (7 != 0)
                                {
                                    goto Block_12;
                                }
                            }
                            else
                            {
                                current = enumerator.Current;
                            }
                            string text;
                            MCHROMAKEYLib.MChromaKey chromakeyFilter;
                            if (current.ObjectFileMapping.ChromaPath != "")
                            {
                                int num;
                                MItem source;
                                this.m_objComposer.StreamsGet(current.VideoObjectId, out num, out source);
                                text = Path.Combine(ConfigManager.FolderPath, current.ObjectFileMapping.ChromaPath);
                                this.LoadChromaPlugin(true, source);
                                chromakeyFilter = this.GetChromakeyFilter(source);
                                try
                                {
                                    do
                                    {
                                        ((MPLATFORMLib.IMProps)chromakeyFilter).PropsSet("gpu_mode", "true");
                                    }
                                    while (6 == 0);
                                }
                                catch
                                {
                                }
                                arg_DC_0 = File.Exists(text);
                                goto IL_DB;
                            }
                        IL_FD:
                            flag = !(current.ObjectFileMapping.RoutePath != "");
                            bool expr_117 = arg_DC_0 = flag;
                            if (!false)
                            {
                                if (!expr_117)
                                {
                                    string filePath = Path.Combine(ConfigManager.FolderPath, current.ObjectFileMapping.RoutePath);
                                    string text2 = current.ObjectFileMapping.RoutePath.Substring(current.ObjectFileMapping.RoutePath.LastIndexOf("\\") + 1).Replace("Route-", "");
                                    text2 = text2.Substring(0, text2.Length - 4);
                                    this.ReadVideoObjectRouteFile(filePath, text2);
                                    if (true)
                                    {
                                    }
                                }
                                break;
                            }
                            goto IL_DB;
                        IL_E2:
                            if (!arg_E2_0)
                            {
                                (chromakeyFilter as MPLATFORMLib.IMPersist).PersistLoad("", text, "");
                            }
                            goto IL_FD;
                        IL_DB:
                            flag = !arg_DC_0;
                            arg_E2_0 = flag;
                            goto IL_E2;
                        }
                    }
                Block_12: ;
                }
                finally
                {
                    bool arg_1EB_0 = enumerator == null;
                    bool expr_1ED;
                    do
                    {
                        bool flag = arg_1EB_0;
                        expr_1ED = (arg_1EB_0 = flag);
                    }
                    while (3 == 0);
                    if (!expr_1ED)
                    {
                        enumerator.Dispose();
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void ReadVideoObjectRouteFile(string filePath, string vidId)
        {
            int num = 0;
            Hashtable hashtable = new Hashtable();
            string value = string.Empty;
            string value2 = string.Empty;
            string value3 = string.Empty;
            string value4 = string.Empty;
            string value5 = string.Empty;
            string value6 = string.Empty;
            StreamReader streamReader = new StreamReader(filePath);
            bool flag;
            bool arg_170_0;
            while (true)
            {
                string text;
                flag = ((text = streamReader.ReadLine()) != null);
                if (3 == 0)
                {
                    goto IL_157;
                }
                bool arg_7B_0;
                bool expr_13C = arg_7B_0 = flag;
                string[] array;
                if (4 != 0)
                {
                    if (!expr_13C)
                    {
                        streamReader.Close();
                        if (7 != 0)
                        {
                            goto IL_157;
                        }
                        goto IL_A5;
                    }
                    else
                    {
                        array = text.Split(new char[]
						{
							';'
						});
                        arg_7B_0 = (array.Length > 1);
                    }
                }
                flag = !arg_7B_0;
                bool expr_7F = arg_170_0 = flag;
                if (false)
                {
                    goto IL_170;
                }
                Hashtable hashtable2;
                if (!expr_7F)
                {
                    hashtable2 = new Hashtable();
                    value = array[0];
                    value2 = array[1];
                    value3 = array[2];
                    goto IL_A5;
                }
            IL_124:
                if (3 != 0)
                {
                    continue;
                }
                goto IL_B1;
            IL_F1:
                hashtable2.Add("r", value5);
                hashtable2.Add("tc", value6);
                hashtable.Add(num, hashtable2);
                num++;
                goto IL_124;
            IL_157:
                if (2 == 0)
                {
                    goto IL_F1;
                }
                flag = this.htVideoObjects.ContainsKey(vidId);
                if (2 != 0)
                {
                    break;
                }
                goto IL_A5;
            IL_B1:
                value6 = array[5];
                hashtable2.Add("x", value);
                hashtable2.Add("y", value2);
                hashtable2.Add("h", value3);
                hashtable2.Add("w", value4);
                goto IL_F1;
            IL_A5:
                value4 = array[3];
                value5 = array[4];
                goto IL_B1;
            }
            arg_170_0 = flag;
        IL_170:
            if (!arg_170_0)
            {
                this.htVideoObjects.Add(vidId, hashtable);
            }
        }

        private void ApplyVideoObjectRoute(MElement elemRoute, Hashtable htRouteList)
        {
            while (true)
            {
            IL_00:
                int arg_A6_0 = 0;
                while (true)
                {
                    int num = arg_A6_0;
                    while (true)
                    {
                        bool expr_93 = (arg_A6_0 = ((num > htRouteList.Count - 1) ? 1 : 0)) != 0;
                        if (false)
                        {
                            break;
                        }
                        if (expr_93)
                        {
                            return;
                        }
                        string updateElementString = this.GetUpdateElementString((Hashtable)htRouteList[num]);
                        elemRoute.ElementMultipleSet(updateElementString, 0.0);
                        int arg_89_0;
                        int expr_50 = arg_89_0 = 50;
                        if (expr_50 != 0)
                        {
                            arg_89_0 = expr_50;
                            if (expr_50 != 0)
                            {
                                Thread.Sleep(expr_50);
                                while (-1 == 0)
                                {
                                }
                                int arg_66_0 = this.CancelbwRoute ? 1 : 0;
                                while (arg_66_0 == 0)
                                {
                                    if (false)
                                    {
                                        goto IL_00;
                                    }
                                    int expr_83 = arg_66_0 = num;
                                    if (!false)
                                    {
                                        arg_89_0 = expr_83 + 1;
                                        goto IL_89;
                                    }
                                }
                                goto Block_3;
                            }
                        }
                    IL_89:
                        num = arg_89_0;
                    }
                }
            }
        Block_3:
            this.KillBackgroundWorker(this.bwRoute);
        }

        private void ApplyVideoObjectRoute(MElement elemRoute, Hashtable htRouteList, int count)
        {
            do
            {
                bool arg_0D_0;
                bool arg_19_0 = arg_0D_0 = (htRouteList.Count > count);
                while (true)
                {
                    bool flag;
                    if (!false)
                    {
                        flag = !arg_0D_0;
                        goto IL_11;
                    }
                IL_16:
                    if (false)
                    {
                        continue;
                    }
                    if (!arg_19_0)
                    {
                        goto IL_1C;
                    }
                    break;
                IL_11:
                    if (-1 != 0)
                    {
                        arg_19_0 = (arg_0D_0 = flag);
                        goto IL_16;
                    }
                IL_1C:
                    string updateElementString = this.GetUpdateElementString((Hashtable)htRouteList[count]);
                    elemRoute.ElementMultipleSet(updateElementString, 0.0);
                    if (4 != 0)
                    {
                        break;
                    }
                    goto IL_11;
                }
            }
            while (false);
        }

        private MElement GetMElement(string vidObject)
        {
            MElement result;
            if (3 != 0)
            {
                MElement mElement = null;
                MElement expr_07 = null;
                if (!false)
                {
                    MElement mElement2 = expr_07;
                }
                try
                {
                    while (7 == 0)
                    {
                    }
                    string arg_3E_0 = string.Empty;
                    MElement mElement2;
                    do
                    {
                        this.m_objComposer.ElementsGetByIndex(3, out mElement2);
                    }
                    while (false);
                    ((IMElements)mElement2).ElementsGetByID(vidObject, out mElement);
                    result = mElement;
                }
                catch (Exception serviceException)
                {
                    while (true)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        while (!false)
                        {
                            ErrorHandler.ErrorHandler.LogFileWrite(message);
                            if (!false)
                            {
                                goto Block_7;
                            }
                        }
                    }
                Block_7:
                    mElement = (result = null);
                }
                finally
                {
                }
            }
            return result;
        }

        private string GetUpdateElementString(Hashtable htSingleRoute)
        {
            string text = string.Empty;
            while (!false)
            {
                IEnumerator enumerator = htSingleRoute.Keys.GetEnumerator();
                try
                {
                    while (true)
                    {
                        bool arg_54_0 = enumerator.MoveNext();
                        bool expr_56;
                        do
                        {
                            bool flag = arg_54_0;
                            expr_56 = (arg_54_0 = flag);
                        }
                        while (false);
                        if (!expr_56)
                        {
                            break;
                        }
                        string key = (string)enumerator.Current;
                        text = text + htSingleRoute[key].ToString() + " ";
                    }
                }
                finally
                {
                    IDisposable disposable = enumerator as IDisposable;
                    if (disposable != null && !false)
                    {
                        disposable.Dispose();
                    }
                }
                if (!false)
                {
                    string result;
                    if (8 != 0)
                    {
                        result = text;
                        break;
                    }
                IL_9C:
                    if (!false)
                    {
                        return result;
                    }
                    break;
                }
            }
            return text;
            //goto IL_9C;
        }

        public void KillBackgroundWorker(BackgroundWorker bw)
        {
            while (true)
            {
                if (6 == 0)
                {
                    goto IL_1D;
                }
                BackgroundWorker expr_22 = bw;
                if (!false)
                {
                    expr_22.CancelAsync();
                }
            IL_0A:
                if (3 != 0)
                {
                    bw.Dispose();
                }
                if (false)
                {
                    continue;
                }
                BackgroundWorker expr_16 = null;
                if (7 != 0)
                {
                    bw = expr_16;
                }
                GC.Collect();
            IL_1D:
                if (!false)
                {
                    break;
                }
                goto IL_0A;
            }
        }

        private void LoadWriterSettings(string settings)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(settings);
                XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Settings");
                int arg_43_0;
                int expr_35 = arg_43_0 = elementsByTagName.Count;
                if (8 != 0)
                {
                    arg_43_0 = ((expr_35 <= 0) ? 1 : 0);
                }
                if (arg_43_0 == 0)
                {
                    foreach (XmlNode xmlNode in elementsByTagName)
                    {
                        int selectedIndex = Convert.ToInt32(xmlNode.ChildNodes[1].InnerText);
                        int selectedIndex2 = Convert.ToInt32(xmlNode.ChildNodes[3].InnerText);
                        string innerText = xmlNode.ChildNodes[4].InnerText;
                        string text = xmlNode.ChildNodes[6].InnerText.Trim();
                        string text2 = xmlNode.ChildNodes[5].InnerText.Trim();
                        this.mFormatControl1.comboBoxVideo.SelectedIndex = selectedIndex;
                        this.mFormatControl1.comboBoxAudio.SelectedIndex = selectedIndex2;
                        string text3 = string.Empty;
                        if (xmlNode.ChildNodes.Count >= 6)
                        {
                            text3 = xmlNode.ChildNodes[7].InnerText.Trim();
                        }
                        this.mConfigList1.Columns[1].ListView.Items[0].SubItems[1].Text = innerText;
                        this.mConfigList1.Columns[1].ListView.Items[1].SubItems[1].Text = text2;
                        if (!(text != ""))
                        {
                            goto IL_1E9;
                        }
                        if (!false)
                        {
                            this.mConfigList1.Columns[1].ListView.Items[2].SubItems[1].Text = text;
                            goto IL_1E9;
                        }
                    IL_218:
                        string empty;
                        string[] array = empty.Split(new char[]
						{
							','
						});
                        this.outputFormat = array[0];
                        this.comboBoxProps.Text = text3;
                        continue;
                    IL_1E9:
                        IMAttributes iMAttributes;
                        this.m_objWriter.ConfigSet("format", innerText, out iMAttributes);
                        int num = 0;
                        empty = string.Empty;
                        iMAttributes.AttributesHave("extensions", out num, out empty);
                        goto IL_218;
                    }
                }
            }
            catch
            {
            }
        }

        private void StopWriter(bool isbtnStop)
        {
            if (4 != 0)
            {
                try
                {
                    this.frameCount = 0;
                    this.EnableORDisableControls(true);
                    do
                    {
                       // this.m_objComposer.OnFrame -= new IMEvents_OnFrameEventHandler(this, (UIntPtr)ldftn(m_objComposer_OnFrame));
                        if (false)
                        {
                            goto IL_E1;
                        }
                        this.CancelbwRoute = true;
                        this.VidTimer.Stop();
                    }
                    while (false);
                    this.m_objWriter.ObjectClose();
                    if (8 != 0)
                    {
                        while (true)
                        {
                        IL_72:
                            bool arg_73_0 = isbtnStop;
                            while (!arg_73_0)
                            {
                                bool flag = System.Windows.MessageBox.Show("Video created successfully!\n\rWould you like to save it now?", "Advance Video Editor", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) != MessageBoxResult.Yes;
                                bool expr_92 = arg_73_0 = flag;
                                if (2 != 0)
                                {
                                    if (expr_92)
                                    {
                                        break;
                                    }
                                    if (8 != 0)
                                    {
                                        goto Block_8;
                                    }
                                    goto IL_72;
                                }
                            }
                            goto IL_B4;
                        }
                    Block_8:
                        this.btnSaveFile.IsEnabled = false;
                        this.btnSaveFile_Click(null, null);
                    }
                IL_B4:
                    this.pbProgress.Value = 0.0;
                    this._isVideoSaved = false;
                    this.txtPercentage.Text = "0%";
                IL_E1:
                    this.txtTimer.Text = "0 sec";
                    this.pbProgress.Value = 0.0;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (4 != 0)
                    {
                        this.bs.Show();
                        if (6 != 0)
                        {
                            BackgroundWorker expr_14 = this.bwSaveVideos;
                            if (-1 != 0)
                            {
                                expr_14.RunWorkerAsync();
                            }
                        }
                    }
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                    }
                    while (-1 == 0);
                }
            }
            while (!true);
            if (!false)
            {
            }
        }

        private void btnShowHideSettings_Click(object sender, RoutedEventArgs e)
        {
            bool arg_3C_0;
            if (true)
            {
                arg_3C_0 = this.ShowHideSet;
                goto IL_0B;
            }
            goto IL_1E;
            do
            {
            IL_26:
                this.ShowHideSettings(this.ShowHideSet);
            }
            while (!true);
            if (!false)
            {
                return;
            }
            goto IL_0D;
        IL_0B:
            bool flag = arg_3C_0;
        IL_0D:
            bool expr_3F = arg_3C_0 = flag;
            if (false)
            {
                goto IL_0B;
            }
            if (!expr_3F)
            {
                this.ShowHideSet = true;
               // goto IL_26;
            }
        IL_1E:
            this.ShowHideSet = false;
           // goto IL_26;
        }

        private void ShowHideSettings(bool flag)
        {
            while (true)
            {
                bool arg_0D_0 = flag;
                if (4 != 0)
                {
                    bool flag2 = !flag;
                    arg_0D_0 = flag2;
                }
                if (!arg_0D_0)
                {
                    goto IL_0F;
                }
                this.stkSettingsRightPanel.Visibility = Visibility.Collapsed;
                goto IL_3D;
            IL_29:
                if (false)
                {
                    continue;
                }
                if (!false)
                {
                    break;
                }
            IL_0F:
                this.stkSettingsRightPanel.Visibility = Visibility.Visible;
                if (-1 != 0)
                {
                    this.stkSettingsBottomPanel.Visibility = Visibility.Visible;
                    goto IL_29;
                }
            IL_3D:
                this.stkSettingsBottomPanel.Visibility = Visibility.Collapsed;
                if (5 != 0)
                {
                    break;
                }
                goto IL_29;
            }
        }

        private void CollapseOthers(Expander exp)
        {
            if (false)
            {
                goto IL_9E;
            }
        IL_07:
            bool flag = exp == this.ExpSceneSettings;
            if (7 != 0)
            {
                if (!flag)
                {
                    this.ExpSceneSettings.IsExpanded = false;
                }
            }
            if (false)
            {
                goto IL_B7;
            }
            if (exp != this.ExpRecordSettings)
            {
                this.ExpRecordSettings.IsExpanded = false;
            }
            bool arg_71_0 = exp == this.ExpRecordProgress;
        IL_71:
            if (!arg_71_0)
            {
                this.ExpRecordProgress.IsExpanded = false;
            }
            if (exp == this.ExpPreview)
            {
                goto IL_A6;
            }
            this.ExpPreview.IsExpanded = false;
        IL_9E:
        IL_9F:
            if (8 == 0)
            {
                goto IL_07;
            }
        IL_A6:
            bool expr_AD = arg_71_0 = (exp == this.ExpEnableAudio);
            if (5 == 0)
            {
                goto IL_71;
            }
            if (expr_AD)
            {
                goto IL_C5;
            }
        IL_B7:
            this.ExpEnableAudio.IsExpanded = false;
        IL_C5:
            if (exp != this.ExpQuickSettings)
            {
                this.ExpQuickSettings.IsExpanded = false;
                if (6 == 0)
                {
                    goto IL_9F;
                }
            }
        }

        private void ExpRecordSettings_Expanded(object sender, RoutedEventArgs e)
        {
            Expander exp = (Expander)sender;
            this.CollapseOthers(exp);
        }

        private void ExpSceneSettings_Expanded(object sender, RoutedEventArgs e)
        {
            Expander exp = (Expander)sender;
            this.CollapseOthers(exp);
        }

        private void ExpPreview_Expanded(object sender, RoutedEventArgs e)
        {
            Expander exp = (Expander)sender;
            this.CollapseOthers(exp);
        }

        private void ExpRecordProgress_Expanded(object sender, RoutedEventArgs e)
        {
            Expander exp = (Expander)sender;
            this.CollapseOthers(exp);
        }

        private void btnPauseProcess_Click(object sender, RoutedEventArgs e)
        {
            eMState eMState;
            this.m_objWriter.ObjectStateGet(out eMState);
            if (eMState == eMState.eMS_Paused)
            {
                //this.m_objComposer.OnFrame += new IMEvents_OnFrameEventHandler(this, (UIntPtr)ldftn(m_objComposer_OnFrame));
                this.m_objComposer.FilePlayStart();
                this.m_objWriter.ObjectStart(null);
                this.m_objWriter.ObjectStateGet(out eMState);
                this.txbPause.Text = "Pause";
            }
            else
            {
               // this.m_objComposer.OnFrame -= new IMEvents_OnFrameEventHandler(this, (UIntPtr)ldftn(m_objComposer_OnFrame));
                this.m_objComposer.FilePlayPause(0.0);
                this.m_objWriter.WriterSkip(0.0);
                this.txbPause.Text = "Continue";
            }
        }

        private string GetVideoName()
		{
			string result;
           Random random=null;
			if (2 != 0 && -1 != 0)
			{
				//MLLiveCapture.
				if (!false)
				{
					//MLLiveCapture.expr_46 = new MLLiveCapture.);
                    //if (!false)
                    //{
                    //    = expr_46;
                    //}
					if (false)
					{
						return result;
					}
					random = new Random();
				}
				result = "live" + new string(Enumerable.Repeat<string>("0123456789", 5).Select(delegate(string s)
				{
					char result2;
					do
					{
						if (true && !false)
						{
							result2 = s[random.Next(s.Length)];
						}
						while (false)
						{
						}
					}
					while (8 == 0);
					return result2;
				}).ToArray<char>());
			}
			return result;
		}

        private void InvalidatePropertyChange(Slider sdr, double timeForChange)
        {
            if (this.SelectedTreeElement == null)
            {
                goto IL_1EA;
            }
            if (sdr == this.sldXAxis)
            {
                this.ApplyPropertyChange(this.SelectedTreeElement, "x", Convert.ToString(sdr.Value), timeForChange);
            }
            bool arg_73_0;
            if (3 != 0)
            {
                arg_73_0 = (sdr != this.sldYAxis);
                goto IL_73;
            }
            goto IL_C3;
            bool flag;
            bool expr_D3;
            do
            {
            IL_D2:
                bool arg_D2_0;
                flag = arg_D2_0;
                expr_D3 = (arg_D2_0 = flag);
            }
            while (5 == 0);
            if (!expr_D3)
            {
                this.ApplyPropertyChange(this.SelectedTreeElement, "w", Convert.ToString(sdr.Value), timeForChange);
                goto IL_F7;
            }
            goto IL_F7;
        IL_73:
            if (!arg_73_0)
            {
                this.ApplyPropertyChange(this.SelectedTreeElement, "y", Convert.ToString(sdr.Value), timeForChange);
            }
            flag = (sdr != this.sldHeight);
            bool arg_A3_0 = flag;
        IL_A3:
            if (!arg_A3_0)
            {
                this.ApplyPropertyChange(this.SelectedTreeElement, "h", Convert.ToString(sdr.Value), timeForChange);
            }
        IL_C3:
            bool expr_CA = arg_A3_0 = (sdr == this.sldWidth);
            if (6 != 0)
            {
                bool arg_D2_0 = !expr_CA;
               // goto IL_D2;
            }
            goto IL_A3;
        IL_F7:
            if (sdr == this.sldRotation)
            {
                this.ApplyPropertyChange(this.SelectedTreeElement, "r", Convert.ToString(sdr.Value), timeForChange);
            }
            bool arg_197_0;
            int expr_12C = (arg_197_0 = (sdr == this.sldCropX)) ? 1 : 0;
            int arg_197_1;
            int expr_12F = arg_197_1 = 0;
            if (expr_12F == 0)
            {
                bool arg_D2_0;
                bool expr_132 = arg_D2_0 = (expr_12C == expr_12F);
                if (4 == 0)
                {
                    //goto IL_D2;
                }
                if (!expr_132)
                {
                    this.ApplyPropertyChange(this.SelectedTreeElement, "sx", Convert.ToString(sdr.Value), timeForChange);
                }
                if (sdr == this.sldCropY)
                {
                    this.ApplyPropertyChange(this.SelectedTreeElement, "sy", Convert.ToString(sdr.Value), timeForChange);
                }
                arg_197_0 = (arg_73_0 = (sdr == this.sldCropH));
                if (3 == 0)
                {
                    goto IL_73;
                }
                arg_197_1 = 0;
            }
            if ((arg_197_0 ? 1 : 0) != arg_197_1)
            {
                this.ApplyPropertyChange(this.SelectedTreeElement, "sh", Convert.ToString(sdr.Value), timeForChange);
            }
            if (sdr == this.sldCropW)
            {
                this.ApplyPropertyChange(this.SelectedTreeElement, "sw", Convert.ToString(sdr.Value), timeForChange);
            }
        IL_1EA:
            if (5 != 0)
            {
                return;
            }
            goto IL_F7;
        }

        private void InvalidatePropertyChange(System.Windows.Controls.TextBox textB, double timeForChange)
        {
            bool flag;
            if (2 != 0)
            {
                flag = (this.SelectedTreeElement == null);
                if (false)
                {
                    goto IL_85;
                }
                if (flag)
                {
                    return;
                }
                bool arg_7F_0;
                int expr_33 = (arg_7F_0 = (textB == this.txtAudioGain)) ? 1 : 0;
                int arg_7F_1;
                int expr_36 = arg_7F_1 = 0;
                if (expr_36 == 0)
                {
                    flag = (expr_33 == expr_36);
                    if (!flag)
                    {
                        if (false)
                        {
                            return;
                        }
                        this.ApplyPropertyChange(this.SelectedTreeElement, "audio_gain", Convert.ToString(this.txtAudioGain.Text), timeForChange);
                    }
                    arg_7F_0 = (textB == this.txtStreamId);
                    arg_7F_1 = 0;
                }
                flag = ((arg_7F_0 ? 1 : 0) == arg_7F_1);
            }
            if (flag)
            {
                return;
            }
        IL_85:
            this.ApplyPropertyChange(this.SelectedTreeElement, "stream_id", Convert.ToString(this.txtStreamId.Text), timeForChange);
        }

        private void InvalidatePropertyChange(System.Windows.Controls.ComboBox cmb, double timeForChange)
        {
            bool flag;
            if (2 != 0)
            {
                flag = (this.SelectedTreeElement == null);
                if (false)
                {
                    goto IL_85;
                }
                if (flag)
                {
                    return;
                }
                bool arg_7F_0;
                int expr_33 = (arg_7F_0 = (cmb == this.drpPosition)) ? 1 : 0;
                int arg_7F_1;
                int expr_36 = arg_7F_1 = 0;
                if (expr_36 == 0)
                {
                    flag = (expr_33 == expr_36);
                    if (!flag)
                    {
                        if (false)
                        {
                            return;
                        }
                        this.ApplyPropertyChange(this.SelectedTreeElement, "pos", Convert.ToString(this.drpPosition.SelectedValue), timeForChange);
                    }
                    arg_7F_0 = (cmb == this.drpCropP);
                    arg_7F_1 = 0;
                }
                flag = ((arg_7F_0 ? 1 : 0) == arg_7F_1);
            }
            if (flag)
            {
                return;
            }
        IL_85:
            this.ApplyPropertyChange(this.SelectedTreeElement, "spos", Convert.ToString(this.drpCropP.SelectedValue), timeForChange);
        }

        private void ApplyPropertyChange(MElement SelectedElem, string attribute, string value, double timeForChange)
        {
            SelectedElem.ElementMultipleSet(attribute + "=" + value, timeForChange);
        }

        private void btnPreviewVideo_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                bool arg_CD_0;
                bool arg_13_0;
                int arg_3B_0 = (arg_13_0 = (arg_CD_0 = string.IsNullOrEmpty(this.strCapturePath_or_URL))) ? 1 : 0;
                while (-1 != 0)
                {
                    if (arg_13_0)
                    {
                        arg_CD_0 = ((arg_3B_0 = 1) != 0);
                        break;
                    }
                    arg_3B_0 = ((arg_13_0 = (arg_CD_0 = !File.Exists(this.strCapturePath_or_URL))) ? 1 : 0);
                    if (6 != 0)
                    {
                        break;
                    }
                }
                if (!false)
                {
                    bool flag = arg_CD_0;
                    arg_3B_0 = (flag ? 1 : 0);
                }
                if (arg_3B_0 != 0)
                {
                    System.Windows.MessageBox.Show("No video available to preview!", "Video Editor", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
                    goto IL_A9;
                }
            IL_3D:
                this.SetVisibility(false);
                //this.popVideoPlayer.Visibility = Visibility.Visible;
                //this.popVideoPlayer.vsMediaFileName = this.strCapturePath_or_URL;
                //this.popVideoPlayer.SetParent(this);
                if (false)
                {
                    continue;
                }
                //this.popVideoPlayer.Visibility = Visibility.Visible;
                while (4 == 0)
                {
                }
            IL_A9:
                if (!false)
                {
                    break;
                }
                goto IL_3D;
            }
        }

        public void SetVisibility(bool IsVisible)
        {
            bool flag;
            while (true)
            {
                bool arg_E7_0;
                if (!IsVisible)
                {
                    this.winMPreviewComposer.Visibility = Visibility.Hidden;
                    this.winMStreamsList.Visibility = Visibility.Hidden;
                    this.winMConfigListl.Visibility = Visibility.Hidden;
                    this.winMFormatControl.Visibility = Visibility.Hidden;
                    this.winMPreviewGreenScreen.Visibility = Visibility.Hidden;
                    flag = (this.stkSettingsRightPanel.Visibility != Visibility.Visible);
                    arg_E7_0 = flag;
                    goto IL_E7;
                }
                this.winMPreviewComposer.Visibility = Visibility.Visible;
            IL_27:
                this.winMStreamsList.Visibility = Visibility.Visible;
                this.winMConfigListl.Visibility = Visibility.Visible;
                this.winMFormatControl.Visibility = Visibility.Visible;
                this.winMPreviewGreenScreen.Visibility = Visibility.Visible;
                bool expr_64 = arg_E7_0 = this.isRightPnlVisible;
                if (5 != 0)
                {
                    flag = !expr_64;
                    if (!false)
                    {
                        break;
                    }
                    continue;
                }
            IL_E7:
                if (arg_E7_0 || 7 == 0)
                {
                    return;
                }
                this.isRightPnlVisible = true;
                this.stkSettingsRightPanel.Visibility = Visibility.Hidden;
                if (8 != 0)
                {
                    goto Block_6;
                }
                goto IL_27;
            }
            if (!flag)
            {
                this.stkSettingsRightPanel.Visibility = Visibility.Visible;
                this.isRightPnlVisible = false;
            }
            return;
        Block_6:
            if (!false)
            {
                if (8 != 0)
                {
                }
            }
        }

        public void EnableORDisableControls(bool IsEnabled)
        {
            this.winMPreviewComposer.IsEnabled = IsEnabled;
            while (true)
            {
                this.winMStreamsList.IsEnabled = IsEnabled;
                UIElement expr_30 = this.winMConfigListl;
                if (!false)
                {
                    expr_30.IsEnabled = IsEnabled;
                }
                while (true)
                {
                    this.winMFormatControl.IsEnabled = IsEnabled;
                    this.winMPreviewGreenScreen.IsEnabled = IsEnabled;
                    if (5 != 0)
                    {
                        this.btnStartProcess.IsEnabled = IsEnabled;
                        if (3 == 0)
                        {
                            goto IL_D4;
                        }
                        this.btnPreviewVideo.IsEnabled = IsEnabled;
                        this.cmbScene.IsEnabled = IsEnabled;
                        this.btnLoadScene.IsEnabled = IsEnabled;
                    }
                    while (2 != 0)
                    {
                        this.ExpSceneSettings.IsEnabled = IsEnabled;
                        if (7 != 0)
                        {
                            this.btnClose.IsEnabled = IsEnabled;
                            break;
                        }
                    }
                    this.buttonChromaProps.IsEnabled = IsEnabled;
                    this.btnSaveFile.IsEnabled = IsEnabled;
                IL_D4:
                    this.btnPauseProcess.IsEnabled = !IsEnabled;
                    if (6 != 0)
                    {
                        goto Block_6;
                    }
                }
            }
        Block_6:
            this.btnStopProcess.IsEnabled = !IsEnabled;
        }

        private void GetElementInformation(string strAttributes)
        {
            try
            {
                if (false)
                {
                    goto IL_3F;
                }
                if (false)
                {
                    goto IL_A2;
                }
                Hashtable hashtable = new Hashtable();
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(strAttributes);
            IL_2F:
                XmlNode firstChild = xmlDocument.FirstChild;
                int arg_3B_0 = 0;
            IL_3B:
                int num = arg_3B_0;
                goto IL_8F;
            IL_3F:
                string key = Convert.ToString(firstChild.Attributes[num].Name);
                string value = Convert.ToString(firstChild.Attributes[num].Value);
                bool flag = hashtable.ContainsKey(key);
                if (!flag)
                {
                    hashtable.Add(key, value);
                }
                num++;
            IL_8F:
                int arg_B3_0;
                int expr_8F = arg_B3_0 = num;
                int arg_B3_1;
                int expr_96 = arg_B3_1 = firstChild.Attributes.Count;
                if (5 == 0)
                {
                    goto IL_B3;
                }
                flag = (expr_8F < expr_96);
            IL_A2:
                bool expr_A2 = (arg_3B_0 = (flag ? 1 : 0)) != 0;
                if (8 == 0)
                {
                    goto IL_3B;
                }
                if (expr_A2)
                {
                    goto IL_3F;
                }
                arg_B3_0 = ((hashtable.Count > 0) ? 1 : 0);
                arg_B3_1 = 0;
            IL_B3:
                flag = (arg_B3_0 == arg_B3_1);
                if (false)
                {
                    goto IL_2F;
                }
                if (!flag)
                {
                    this.PopulateProperties(hashtable);
                }
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

        private void PopulateProperties(Hashtable htAttrib)
        {
            this.txtXAxis.Text = (htAttrib.ContainsKey("x") ? htAttrib["x"].ToString() : "0.0");
            this.txtYAxis.Text = (htAttrib.ContainsKey("y") ? htAttrib["y"].ToString() : "0.0");
            this.txtHeight.Text = (htAttrib.ContainsKey("h") ? htAttrib["h"].ToString() : "0.0");
            this.txtWidth.Text = (htAttrib.ContainsKey("w") ? htAttrib["w"].ToString() : "0.0");
            this.txtRotation.Text = (htAttrib.ContainsKey("r") ? htAttrib["r"].ToString() : "0.0");
            this.txtCropX.Text = (htAttrib.ContainsKey("sx") ? htAttrib["sx"].ToString() : "0.0");
            this.txtCropY.Text = (htAttrib.ContainsKey("sy") ? htAttrib["sy"].ToString() : "0.0");
            this.txtCropH.Text = (htAttrib.ContainsKey("sh") ? htAttrib["sh"].ToString() : "0.0");
            this.txtCropW.Text = (htAttrib.ContainsKey("sw") ? htAttrib["sw"].ToString() : "0.0");
            this.txtAudioGain.Text = (htAttrib.ContainsKey("audio_gain") ? htAttrib["audio_gain"].ToString() : "+0.0");
            this.txtStreamId.Text = (htAttrib.ContainsKey("stream_id") ? htAttrib["stream_id"].ToString() : "");
            this.drpPosition.SelectedValue = (htAttrib.ContainsKey("pos") ? htAttrib["pos"].ToString() : "bottom-left");
            this.drpCropP.SelectedValue = (htAttrib.ContainsKey("spos") ? htAttrib["spos"].ToString() : "bottom-left");
        }

        private List<string> FillPositionList()
        {
            List<string> list;
            do
            {
                list = new List<string>();
            }
            while (4 == 0);
            list.Add("center");
            list.Add("right");
            while (true)
            {
                list.Add("left");
                while (3 != 0)
                {
                    list.Add("top");
                    if (7 != 0)
                    {
                        list.Add("bottom");
                    }
                    list.Add("bottom-right");
                    list.Add("bottom-left");
                    if (8 != 0)
                    {
                        list.Add("top-right");
                    }
                    list.Add("top-left");
                    if (4 != 0)
                    {
                        return list;
                    }
                }
            }
            return list;
        }

        private void FillPositionDropDown()
        {
            try
            {
                while (true)
                {
                    List<string> itemsSource = this.FillPositionList();
                    this.drpPosition.Items.Clear();
                    while (7 != 0)
                    {
                        this.drpPosition.ItemsSource = itemsSource;
                        this.drpCropP.Items.Clear();
                        this.drpCropP.ItemsSource = itemsSource;
                        if (!false)
                        {
                            if (3 != 0)
                            {
                                goto Block_3;
                            }
                            break;
                        }
                    }
                }
            Block_3: ;
            }
            catch (Exception serviceException)
            {
                if (3 != 0)
                {
                    string message;
                    if (!false)
                    {
                        message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    }
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void sldXAxis_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.InvalidatePropertyChange((Slider)sender, 0.0);
        }

        private void sldYAxis_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.InvalidatePropertyChange((Slider)sender, 0.0);
        }

        private void sldHeight_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.InvalidatePropertyChange((Slider)sender, 0.0);
        }

        private void sldWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.InvalidatePropertyChange((Slider)sender, 0.0);
        }

        private void sldRotation_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.InvalidatePropertyChange((Slider)sender, 0.0);
        }

        private void sldCropX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.InvalidatePropertyChange((Slider)sender, 0.0);
        }

        private void sldCropY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.InvalidatePropertyChange((Slider)sender, 0.0);
        }

        private void sldCropW_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.InvalidatePropertyChange((Slider)sender, 0.0);
        }

        private void sldCropH_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.InvalidatePropertyChange((Slider)sender, 0.0);
        }

        private void txtAudioGain_LostFocus(object sender, RoutedEventArgs e)
        {
            this.InvalidatePropertyChange((System.Windows.Controls.TextBox)sender, 0.0);
        }

        private void txtStreamId_LostFocus(object sender, RoutedEventArgs e)
        {
            this.InvalidatePropertyChange((System.Windows.Controls.TextBox)sender, 0.0);
        }

        private void drpPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.InvalidatePropertyChange((System.Windows.Controls.ComboBox)sender, 0.0);
        }

        private void drpCropP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.InvalidatePropertyChange((System.Windows.Controls.ComboBox)sender, 0.0);
        }

        private void btnFullScreen_Checked(object sender, RoutedEventArgs e)
        {
            do
            {
                while (this.mPreviewComposerControl.m_pPreview != null)
                {
                    bool arg_C5_0 = !this.btnFullScreen.IsChecked.Value;
                    bool expr_CB;
                    do
                    {
                        bool flag = arg_C5_0;
                        expr_CB = (arg_C5_0 = flag);
                    }
                    while (false);
                    if (!expr_CB)
                    {
                        this.mPreviewComposerControl.m_pPreview.PreviewFullScreen("", 1, 1);
                        if (false)
                        {
                            continue;
                        }
                    }
                    else if (!false)
                    {
                        if (2 == 0)
                        {
                            continue;
                        }
                        this.mPreviewComposerControl.m_pPreview.PreviewFullScreen("", 0, 1);
                    }
                    break;
                }
            }
            while (7 == 0);
        }

        private void sldVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            while (true)
            {
                double arg_0D_0 = this.sldVolume.Value;
                double expr_0D;
                do
                {
                    expr_0D = (arg_0D_0 = arg_0D_0);
                }
                while (7 == 0);
                double num = expr_0D / this.sldVolume.Maximum;
                bool flag = this.mPreviewComposerControl.m_pPreview == null;
                while (4 != 0)
                {
                    if (flag)
                    {
                        goto IL_71;
                    }
                IL_41:
                    this.mPreviewComposerControl.m_pPreview.PreviewAudioVolumeSet("", -1, -30.0 * (1.0 - num));
                    if (3 == 0)
                    {
                        continue;
                    }
                IL_71:
                    if (true)
                    {
                        return;
                    }
                    goto IL_41;
                }
            }
        }

        private void btnAspectRatio_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                bool flag;
                if (!false)
                {
                    flag = (this.mPreviewComposerControl.m_pPreview == null);
                    goto IL_15;
                }
            IL_19:
                if (false)
                {
                    continue;
                }
                if (false)
                {
                    return;
                }
                if (!false)
                {
                    break;
                }
            IL_15:
                if (!flag)
                {
                    goto IL_19;
                }
                return;
            }
            MPLATFORMLib.IMProps arg_7F_0 = (MPLATFORMLib.IMProps)this.mPreviewComposerControl.m_pPreview;
            string arg_7F_1 = "maintain_ar";
            bool? expr_6E = this.btnAspectRatio.IsChecked;
            bool? flag2;
            if (2 != 0)
            {
                flag2 = expr_6E;
            }
            arg_7F_0.PropsSet(arg_7F_1, flag2.Value ? "none" : "letter-box");
        }

        private void btnAudio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                do
                {
                    bool arg_77_0 = this.mPreviewComposerControl.m_pPreview == null;
                    bool expr_7D;
                    do
                    {
                        bool flag = arg_77_0;
                        if (false)
                        {
                            goto IL_6E;
                        }
                        expr_7D = (arg_77_0 = flag);
                    }
                    while (false);
                    if (expr_7D)
                    {
                        goto IL_6E;
                    }
                }
                while (false);
                IMPreview arg_68_0 = this.mPreviewComposerControl.m_pPreview;
                string arg_68_1 = "";
                bool? isChecked = this.btnAudio.IsChecked;
                int arg_68_2 = isChecked.Value ? 0 : 1;
                isChecked = this.btnVideoPreview.IsChecked;
                arg_68_0.PreviewEnable(arg_68_1, arg_68_2, isChecked.Value ? 0 : 1);
            IL_6E: ;
            }
            catch
            {
                while (6 == 0 || !true)
                {
                }
            }
        }

        private void btnVideoPreview_Click(object sender, RoutedEventArgs e)
        {
            while (this.mPreviewComposerControl.m_pPreview != null)
            {
                IMPreview arg_5B_0 = this.mPreviewComposerControl.m_pPreview;
                string arg_5B_1 = "";
                bool? isChecked = this.btnAudio.IsChecked;
                int arg_5B_2 = isChecked.Value ? 0 : 1;
                isChecked = this.btnVideoPreview.IsChecked;
                arg_5B_0.PreviewEnable(arg_5B_1, arg_5B_2, isChecked.Value ? 0 : 1);
                if (3 != 0)
                {
                    break;
                }
            }
        }

        private void ExpEnableAudio_Expanded(object sender, RoutedEventArgs e)
        {
            Expander exp = (Expander)sender;
            this.CollapseOthers(exp);
        }

        private void chkEnableAudio_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MPLATFORMLib.IMProps iMProps;
                do
                {
                    System.Windows.Controls.CheckBox checkBox = (System.Windows.Controls.CheckBox)sender;
                    int num = 0;
                    MComposerClass arg_D0_0 = this.m_objComposer;
                    MItem mItem;
                    this.m_objComposer.StreamsGet(checkBox.Tag.ToString(), out num, out mItem);
                    iMProps = (MPLATFORMLib.IMProps)mItem;
                    if (mItem == null)
                    {
                        goto IL_B5;
                    }
                    if (checkBox.IsChecked == true)
                    {
                        goto Block_3;
                    }
                }
                while (2 == 0);
                while (true)
                {
                    iMProps.PropsSet("object::audio_gain", "-100");
                    if (!false)
                    {
                        goto IL_B4;
                    }
                }
            Block_3:
                iMProps.PropsSet("object::audio_gain", "0");
            IL_B4:
            IL_B5: ;
            }
            catch (Exception var_5_F6)
            {
            }
        }

        private void ExpQuickSettings_Expanded(object sender, RoutedEventArgs e)
        {
            Expander exp = (Expander)sender;
            this.CollapseOthers(exp);
        }

        private void saveOutputVideo()
        {
            try
            {
                bool expr_0D = this.objLast == null;
                bool flag;
                if (!false)
                {
                    flag = expr_0D;
                }
                if (!flag)
                {
                    PhotoBusiness photoBusiness = new PhotoBusiness();
                    string text = this.objLast.HotFolderPath + "ProcessedVideos\\" + DateTime.Now.ToString("yyyyMMdd");
                    string destFileName = string.Concat(new string[]
					{
						text,
						"\\",
						this.objLast.Name,
						"_",
						DateTime.Now.ToString("HH:mm").Replace(":", ""),
						".",
						this.outputFormat
					});
                    string text2 = string.Concat(new string[]
					{
						this.objLast.Name,
						"_",
						DateTime.Now.ToString("HH:mm").Replace(":", ""),
						".",
						this.outputFormat
					});
                    string text3 = Path.Combine(this.objLast.HotFolderPath, "Thumbnails", DateTime.Now.ToString("yyyyMMdd"));
                    int arg_25A_0;
                    bool expr_156 = (arg_25A_0 = (Directory.Exists(text) ? 1 : 0)) != 0;
                    if (!false)
                    {
                        flag = expr_156;
                        if (!flag)
                        {
                            Directory.CreateDirectory(text);
                        }
                        flag = Directory.Exists(text3);
                        if (!flag)
                        {
                            Directory.CreateDirectory(text3);
                        }
                        flag = !File.Exists(this.tempFile);
                        if (!flag)
                        {
                            File.Copy(this.tempFile, destFileName, true);
                        }
                        flag = !File.Exists(this.path_tempThumbnail);
                        if (!flag)
                        {
                            this.ResizeWPFImage(this.path_tempThumbnail, 210, Path.Combine(text3, Path.GetFileNameWithoutExtension(text2) + ".jpg"));
                        }
                        arg_25A_0 = photoBusiness.SetPhotoDetails(ConfigManager.SubStoreId, this.objLast.Name, text2, DateTime.Now, LoginUser.UserId.ToString(), "", 0, string.Empty, string.Empty, null, null, 1, null, new long?((long)this.VideoLength), true, new int?(3), new int?(0), null, 0, false);
                    }
                    int num = arg_25A_0;
                    flag = (num <= 0);
                    if (!flag)
                    {
                        System.Windows.MessageBox.Show("Video saved successfully!\n", "Video Editor", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void ResizeWPFImage(string sourceImage, int maxHeight, string saveToPath)
        {
            do
            {
                try
                {
                    BitmapImage expr_15C = new BitmapImage();
                    BitmapImage bitmapImage;
                    if (6 != 0)
                    {
                        bitmapImage = expr_15C;
                    }
                    BitmapImage bitmapImage2 = new BitmapImage();
                    FileStream fileStream = File.OpenRead(sourceImage.ToString());
                    try
                    {
                        MemoryStream memoryStream;
                        int decodePixelWidth;
                        while (true)
                        {
                        IL_2D:
                            memoryStream = new MemoryStream();
                            fileStream.CopyTo(memoryStream);
                            memoryStream.Seek(0L, SeekOrigin.Begin);
                            while (true)
                            {
                                fileStream.Close();
                                while (true)
                                {
                                    bitmapImage.BeginInit();
                                    bitmapImage.StreamSource = memoryStream;
                                    bitmapImage.EndInit();
                                    bitmapImage.Freeze();
                                    decimal d = Convert.ToDecimal(bitmapImage.Width) / Convert.ToDecimal(bitmapImage.Height);
                                    decodePixelWidth = Convert.ToInt32(maxHeight * d);
                                    if (false)
                                    {
                                        goto IL_2D;
                                    }
                                    if (false)
                                    {
                                        goto IL_C2;
                                    }
                                    memoryStream.Seek(0L, SeekOrigin.Begin);
                                    if (false)
                                    {
                                        break;
                                    }
                                    if (!false)
                                    {
                                        goto Block_9;
                                    }
                                }
                            }
                        }
                    Block_9:
                        bitmapImage2.BeginInit();
                        bitmapImage2.StreamSource = memoryStream;
                    IL_C2:
                        bitmapImage2.DecodePixelWidth = decodePixelWidth;
                        if (true)
                        {
                        }
                        bitmapImage2.DecodePixelHeight = maxHeight;
                        bitmapImage2.EndInit();
                        bitmapImage2.Freeze();
                    }
                    finally
                    {
                        if (3 != 0)
                        {
                            if (fileStream != null)
                            {
                                ((IDisposable)fileStream).Dispose();
                            }
                        }
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
            while (false);
        }

        private void btnChromaSettings_Click(object sender, RoutedEventArgs e)
        {
        IL_00:
            while (-1 != 0)
            {
                bool flag = this.mMixerList1.SelectedItem == null;
                while (!flag)
                {
                    if (3 != 0)
                    {
                        if (7 != 0)
                        {
                            this.LoadChromaPlugin(true, this.mMixerList1.SelectedItem);
                            goto IL_31;
                        }
                        goto IL_00;
                    }
                }
                break;
            IL_31:
                FormChromaKey formChromaKey;
                if (!false)
                {
                    MCHROMAKEYLib.MChromaKey chromakeyFilter = this.GetChromakeyFilter(this.mMixerList1.SelectedItem);
                    if (chromakeyFilter == null)
                    {
                    IL_60:
                        goto IL_61;
                    }
                    formChromaKey = new FormChromaKey(chromakeyFilter);
                }
                formChromaKey.ShowDialog();
            IL_61:
                if (5 != 0)
                {
                    return;
                }
                goto IL_31;
            }
           // goto IL_60;
        }

        public void GetConfigLocationData()
        {
            try
            {
                if (false)
                {
                    goto IL_F2;
                }
                ConfigBusiness configBusiness = new ConfigBusiness();
            IL_1C:
                List<long> filterValues = new List<long>();
                filterValues.Add(151L);
                List<iMixConfigurationLocationInfo> list = (from o in configBusiness.GetConfigLocation(this.locationId, ConfigManager.SubStoreId)
                                                            where filterValues.Contains(o.IMIXConfigurationMasterId)
                                                            select o).ToList<iMixConfigurationLocationInfo>();
            IL_6D:
                if (5 == 0)
                {
                    goto IL_E3;
                }
                int arg_89_0;
                int arg_10B_0 = (list != null) ? (arg_89_0 = 0) : (arg_89_0 = ((list.Count <= 0) ? 1 : 0));
                if (false)
                {
                    goto IL_10B;
                }
                int num;
                if (arg_89_0 == 0)
                {
                    num = 0;
                    goto IL_102;
                }
                goto IL_115;
            IL_A6:
                long iMIXConfigurationMasterId;
                if (iMIXConfigurationMasterId == 151L)
                {
                    bool expr_BE = (arg_10B_0 = (string.IsNullOrEmpty(list[num].ConfigurationValue) ? 1 : 0)) != 0;
                    if (false)
                    {
                        goto IL_10B;
                    }
                    if (!expr_BE)
                    {
                        this.FlipMode = Convert.ToInt32(list[num].ConfigurationValue);
                    }
                    else
                    {
                        if (7 == 0)
                        {
                            goto IL_1C;
                        }
                        this.FlipMode = 0;
                    }
                }
            IL_E3:
            IL_F2:
                if (false)
                {
                    goto IL_6D;
                }
                if (false)
                {
                    goto IL_A6;
                }
                num++;
            IL_102:
                arg_10B_0 = ((num < list.Count) ? 1 : 0);
            IL_10B:
                if (arg_10B_0 != 0)
                {
                    iMIXConfigurationMasterId = list[num].IMIXConfigurationMasterId;
                    goto IL_A6;
                }
            IL_115: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private MElement GetGuestVideoElement(string comparedID)
        {
            MElement result = null;
            int num;
            if (!false)
            {
                int expr_0A = 0;
                if (!false)
                {
                    num = expr_0A;
                }
                this.m_objComposer.ElementsGetCount(out num);
            }
            int num2;
            if (4 != 0)
            {
                num2 = 0;
                goto IL_E9;
            }
        IL_D4:
            int i;
            int num3;
            MElement mElement;
            int arg_EB_0;
            while (i < num3)
            {
                MElement mElement2;
                ((IMElements)mElement).ElementsGetByIndex(i, out mElement2);
                bool flag = mElement2 == null;
                if (3 == 0)
                {
                    goto IL_E9;
                }
                if (!flag)
                {
                    if (5 == 0)
                    {
                        break;
                    }
                    int num4 = 0;
                    if (!false)
                    {
                        string a;
                        mElement2.AttributesHave("stream_id", out num4, out a);
                        while (true)
                        {
                            flag = !(a == comparedID);
                            bool expr_BC = (arg_EB_0 = (flag ? 1 : 0)) != 0;
                            if (false)
                            {
                                goto IL_EA;
                            }
                            if (!expr_BC)
                            {
                                break;
                            }
                            if (!false)
                            {
                                goto IL_CD;
                            }
                        }
                        result = mElement2;
                        break;
                    }
                    goto IL_70;
                }
            IL_CD:
                i++;
            }
            goto IL_E4;
        IL_70:
            i = 0;
            goto IL_D4;
        IL_E4:
            num2++;
        IL_E9:
            arg_EB_0 = num2;
        IL_EA:
            if (arg_EB_0 >= num)
            {
                return result;
            }
            this.m_objComposer.ElementsGetByIndex(num2, out mElement);
            if (mElement != null)
            {
                num3 = 0;
                ((IMElements)mElement).ElementsGetCount(out num3);
                goto IL_70;
            }
            goto IL_E4;
        }

        private void ApplyFlip(MElement pElement, int FlipMode)
        {
            int arg_30_0;
            int arg_30_1;
            do
            {
                arg_30_0 = FlipMode;
                int expr_04 = arg_30_1 = 1;
                if (expr_04 == 0)
                {
                    goto IL_30;
                }
                int arg_0A_0 = (FlipMode == expr_04) ? 1 : 0;
                while (arg_0A_0 == 0)
                {
                    arg_30_0 = FlipMode;
                    arg_0A_0 = FlipMode;
                    if (!false)
                    {
                        goto Block_3;
                    }
                }
            }
            while (2 == 0);
            pElement.ElementMultipleSet("rh=180", 0.0);
        IL_27:
        IL_28:
            goto IL_51;
        Block_3:
            arg_30_1 = 2;
        IL_30:
            if (arg_30_0 == arg_30_1)
            {
                pElement.ElementMultipleSet("rv=180", 0.0);
            }
        IL_51:
            if (5 == 0)
            {
                goto IL_28;
            }
            if (6 != 0)
            {
                return;
            }
            goto IL_27;
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            this.GetElementInformation(this.strDefaultSceneSettings);
        }

        void IStyleConnector.Connect(int connectionId, object target)
        {
            while (true)
            {
                if (8 == 0)
                {
                    goto IL_16;
                }
                int arg_0F_0 = connectionId;
                if (8 != 0)
                {
                    arg_0F_0 = connectionId;
                }
                if (arg_0F_0 == 52 || false)
                {
                    goto IL_16;
                }
            IL_2F:
                if (!false)
                {
                    break;
                }
                continue;
            IL_16:
                ((System.Windows.Controls.CheckBox)target).Click += new RoutedEventHandler(this.chkEnableAudio_Click);
                goto IL_2F;
            }
        }
    }
}
