using CGEditor_WinForms;
using DigiPhoto.Common;
using DigiPhoto.IMIX.Business;
using DigiPhoto.IMIX.Model;
using PhotoSW.Interop;
using PhotoSW.Shader;
using ErrorHandler;
using FrameworkHelper;
using FrameworkHelper.Common;
using MCHROMAKEYLib;
using MCOLORSLib;
using MControls;
using MLCHARGENLib;
using MPLATFORMLib;
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
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Xml;
using PhotoSW.Views;
using PhotoSW.PSControls;
using DigiPhoto;

namespace PhotoSW.Manage
{
    public partial class VideoEditor : Window, IComponentConnector, IStyleConnector
    {
        private delegate void EditorStopDelegate();

        public int DropPhotoId = 0;

        public List<TemplateListItems> objTemplateList = new List<TemplateListItems>();

        private List<VideoElements> lstVideoElements = new List<VideoElements>();

        private List<VideoFrames> lstVideoFrames = new List<VideoFrames>();

        private ProcessedVideoInfo objProcVideoInfo = new ProcessedVideoInfo();

        public string IsGoupped;

        private string processVideoTemp = Environment.CurrentDirectory + "\\PhotoSWProcessVideoTemp\\";

        private Dictionary<string, int> listValueType;

        private string templateType = "chroma";

        private List<VideoProducts> lstVideoProduct = new List<VideoProducts>();

        private ProcessedVideoInfo lstProcessedVideo = new ProcessedVideoInfo();

        private bool IsProcessedVideoSaved = true;

        private bool IsProcessedVideoEditing = false;

        private int ProcessedVideoID = 0;

        private bool isCreateNew = false;

        private List<VideoPage> lstVideoPage;

        private int productId = 0;

        public List<VideoTemplateInfo.VideoSlot> slotList = new List<VideoTemplateInfo.VideoSlot>();

        private BusyWindow bs = new BusyWindow();

        private string outputFormat = "mp4";

        private FileStream memoryFileStream;

        public static string vsMediaFileName;

        private readonly DispatcherTimer timer = new DispatcherTimer();

        public int defaultProcessListCount = 10;

        private bool isVideoTempSelected = false;

        private int activePage = 0;

        private bool isGroup = false;

        private DateTime lastmemoryUpdateTime = DateTime.Now;

        private int folderCount = 0;

        private bool AutomatedVideoEditWorkFlow = false;

        private BackgroundWorker bwSaveVideos = new BackgroundWorker();

        private string tempFile;

        private string path_tempThumbnail;

        private int Vidlength = 0;

        private string m_strItemID = "";

        public MLCHARGENLib.CoMLCharGen m_objCharGen = (MLCHARGENLib.CoMLCharGen)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("0F56D2E7-033C-4A05-BCDA-DF58C9BBF06F")));

        private CGEditor_WinForms.MainWindow cgEditor = new CGEditor_WinForms.MainWindow();

        private ConfigBusiness objConfigBL;

        private CGConfigSettings objCGConfig;

        private Dictionary<int, string> dicConfig;

        private UIElement elementForContextMenu;

        private double numericTimeForChange = 0.0;

        private CoMColorsClass m_objColors;

        private string strGuestStreamID = string.Empty;

        private bool IsLoadChroma = false;

        public static readonly DependencyProperty PrintOrderPageProperty;

        private bool ChangeGuestElement = true;

        private bool isImageAsGraphic = false;

        private string extractVideoPath = "";

        private long extractVideoEndTime = 0L;

        private static volatile object _lockObject;

        public static bool isVideoEditorStopped;

        public MLMediaPlayer mplayer;

        private ClientView clientWin = null;

        private FilePhotoInfo processImageItem = null;

        private bool IsVideoInput = false;

        private int graphicId = 51;

        private string strBorderStream = string.Empty;

        private string strOverlayStream = string.Empty;

        private readonly Stopwatch _doubleTapStopwatch = new Stopwatch();

        private System.Windows.Point _lastTapLocation;

        public static int tempGraphicId;

        private double _ZoomFactor = 1.0;

        private double _GraphicsZoomFactor = 1.0;

        private TransformGroup transformGroup;

        private ScaleTransform zoomTransform = new ScaleTransform();

        private double _maxZoomFactor = 4.0;

        private string specFileName = string.Empty;

        private VideoColorEffects colorEffects;

        private MMixerClass m_objMixer;

        private MCHROMAKEYLib.IMPersist m_pMPersist;

        private string _guestVideoObject;

        private IMStreams m_pMixerStreams;

        private DispatcherTimer VidTimer;

        public MWriterClass m_objWriter;

        private string overlayChromaSetting = string.Empty;

        private string strTransition = "Pixelate";

        private string VideoSettings = string.Empty;

        private decimal vidLength = 0m;

        private string CurrentITemStream = string.Empty;

        private double NextItemStartTime = 0.0;

        private double NextAudioStartTime = 0.0;

        private double CurrentAudioStoptTime = 0.0;

        private string CurrentAudioStream = string.Empty;

        private List<StreamList> lstStreamDetails = new List<StreamList>();

        private bool IsExternalAudio = false;

        private bool thumCaptured = false;

        private MElement GuestElement;

        private MElement AudioElement;

        private MElement BorderElement;

        private MElement OverlayElement;

        private static MCHROMAKEYLib.MChromaKey objChromaKey;

        private int _configId = 0;

        private string CurrentchromaSetting = string.Empty;

        private bool IsSceneLoaded = false;

        private string PresetNode = "None";

        private bool IsLoadOverlayChroma = false;

        

        public ObservableCollection<VideoPage> PrintOrderPageList
        {
            get
            {
                return (ObservableCollection<VideoPage>)base.GetValue(VideoEditor.PrintOrderPageProperty);
            }
            set
            {
                base.SetValue(VideoEditor.PrintOrderPageProperty, value);
            }
        }

        public VideoEditor()
        {
            try
            {
                this.InitializeComponent();
                this.isGroup = RobotImageLoader.isGroup;
                this.slotList.Clear();
                this.PrintOrderPageList.Clear();
                this.lstVideoElements.Clear();
                this.lstDragImages.Items.Clear();
                this.objTemplateList.Clear();
                this.listValueType = this.LoadValueTypeList();
                this.mplayer = new MLMediaPlayer(VideoEditor.vsMediaFileName, "VideoEditor");
                this.LoadGuestImageList();
                this.BindPageStrips();
                this.ShowHideControls("video");
                this.LoadTemplateList();
                this.BindCGConfigCombo();
                this.templateType = "chroma";
                this.MsgBox.SetParent(this.OuterBorder);
                CommonUtility.CleanFolder(Environment.CurrentDirectory, new string[]
				{
					"CroppedImage"
				});
                ConfigManager.SubStoreId = LoginUser.SubStoreId;
                this.viewControl.SetParent(this.OuterBorder);
                this.FrameBox.ExecuteMethod += new EventHandler(this.FrameBox_ExecuteMethod);
                if (!Directory.Exists(this.processVideoTemp))
                {
                    Directory.CreateDirectory(this.processVideoTemp);
                }
                this.m_objColors = new CoMColorsClass();
                this.HighlightSelectedButton("btnVideo");
                this.btnSave.IsEnabled = false;
                this.m_objMixer = new MMixerClass();
                this.mPreviewControlMixer1.SetControlledObject(this.m_objMixer);
                this.mMixerList1.SetControlledObject(this.m_objMixer);
                this.mMixerList1.OnMixerSelChanged += new EventHandler(this.mMixerList1_OnMixerSelChanged);
                this.m_objMixer.ObjectStart(null);
                this.VidTimer = new DispatcherTimer();
                this.VidTimer.Tick += new EventHandler(this.VidTimer_Tick);
                this.m_objWriter = new MWriterClass();
                this.mFormatControl1.SetControlledObject(this.m_objMixer);
                this.mElementsTree1.SetControlledObject(this.m_objMixer);
                this.mFormatControl1.comboBoxVideo.SelectedIndex = 0;
                this.mFormatControl1.comboBoxAudio.SelectedIndex = 0;
                this.mConfigList1.SetControlledObject(this.m_objWriter);
                this.mConfigList1.OnConfigChanged += new EventHandler(this.mConfigList1_OnConfigChanged);
                this.bwSaveVideos.DoWork += new DoWorkEventHandler(this.bwSaveVideos_DoWork);
                this.bwSaveVideos.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwSaveVideos_RunWorkerCompleted);
                if (this.mPreviewControlMixer1.m_pPreview != null)
                {
                    this.mPreviewControlMixer1.m_pPreview.PreviewEnable("", 0, 1);
                }
                this.mConfigList1_OnConfigChanged(null, EventArgs.Empty);
                this.m_objMixer.PluginsAdd(this.m_objColors, 0L);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void LoadDefaultSceneAndFile()
        {
            if (4 != 0)
            {
                do
                {
                    this.VideoEditPlayerPanel.Visibility = Visibility.Collapsed;
                }
                while (7 == 0);
                if (!false)
                {
                    this.loadScene(0);
                }
                if (-1 != 0)
                {
                    this.LoadFirstItemOnMixer();
                }
            }
        }

        private void LoadFirstItemOnMixer()
        {
            if (true)
            {
                this.VideoEditPlayerPanel.Visibility = Visibility.Visible;
            }
            VideoElements videoElements = this.lstVideoElements.FirstOrDefault<VideoElements>();
            string arg_EC_0 = string.Empty;
            int arg_7C_0;
            int expr_38 = arg_7C_0 = (this.AutomatedVideoEditWorkFlow ? 1 : 0);
            int arg_7C_1;
            int expr_3E = arg_7C_1 = 0;
            bool flag;
            bool arg_85_0;
            if (expr_3E == 0)
            {
                bool expr_41 = expr_38 == expr_3E;
                if (7 != 0)
                {
                    flag = expr_41;
                }
                int arg_4F_0 = flag ? 1 : 0;
                while (arg_4F_0 == 0)
                {
                    int expr_53 = arg_4F_0 = (arg_7C_0 = videoElements.MediaType);
                    if (!false)
                    {
                        int expr_5C = arg_7C_1 = 1;
                        if (expr_5C == 0)
                        {
                            goto IL_7C;
                        }
                        if (expr_53 == expr_5C)
                        {
                            arg_7C_0 = (File.Exists(videoElements.VideoFilePath.Replace("jpg", "png")) ? 1 : 0);
                            arg_7C_1 = 0;
                            goto IL_7C;
                        }
                        if (!false)
                        {
                            arg_85_0 = true;
                            goto IL_84;
                        }
                        goto IL_A6;
                    }
                }
                goto IL_B8;
            }
        IL_7C:
            arg_85_0 = (arg_7C_0 == arg_7C_1);
        IL_84:
            flag = arg_85_0;
            if (flag)
            {
                this.IsLoadChroma = true;
                goto IL_B7;
            }
            videoElements.VideoFilePath = videoElements.VideoFilePath.Replace("jpg", "png");
        IL_A6:
            this.IsLoadChroma = false;
        IL_B7:
        IL_B8:
            this.SetFirstGuestStream(videoElements.VideoFilePath);
        }

        private void SetFirstGuestStream(string filepath)
        {
            bool flag = this.m_objMixer == null;
            if (!flag)
            {
                if (5 == 0)
                {
                    goto IL_102;
                }
                this.m_pMixerStreams = this.m_objMixer;
                int num = 0;
                string empty = string.Empty;
                bool arg_58_0 = string.IsNullOrEmpty(this.strGuestStreamID);
                bool expr_5B;
                do
                {
                    flag = !arg_58_0;
                    expr_5B = (arg_58_0 = flag);
                }
                while (false);
                MItem mItem;
                if (expr_5B)
                {
                    this.m_pMixerStreams.StreamsAdd(this.strGuestStreamID, null, filepath, "loop=false", out mItem, 0.0);
                    goto IL_D9;
                }
                this.m_pMixerStreams.StreamsAdd("", null, filepath, "loop=false", out mItem, 0.0);
            IL_84:
                if (true)
                {
                    this.m_pMixerStreams.StreamsGetCount(out num);
                    this.m_pMixerStreams.StreamsGetByIndex(num - 1, out empty, out mItem);
                    this.strGuestStreamID = empty;
                }
            IL_D9:
                this.GuestElement.ElementMultipleSet("stream_id=" + this.strGuestStreamID + " audio_gain=-100 show=true", 0.0);
            IL_102:
                try
                {
                    if (!false)
                    {
                        if (false)
                        {
                            goto IL_112;
                        }
                        flag = (mItem == null);
                    }
                    if (flag)
                    {
                        goto IL_11F;
                    }
                IL_112:
                    this.mMixerList1.SelectFile(mItem);
                IL_11E:
                IL_11F:
                    if (false)
                    {
                        goto IL_11E;
                    }
                }
                catch
                {
                }
                this.mMixerList1.UpdateList(true, 1);
                if (false)
                {
                    goto IL_84;
                }
                this.InitializeStream(this.strGuestStreamID, false);
            }
        }

        private void BindGuestNodeProps()
        {
            if (-1 != 0)
            {
                bool expr_0C = this.GuestElement == null;
                bool flag;
                if (4 != 0)
                {
                    flag = expr_0C;
                }
                if (!flag)
                {
                    if (!false)
                    {
                        string text;
                        string text2;
                        this.GuestElement.ElementGet(out text, out text2);
                        if (!false && !false)
                        {
                            string expr_50 = text2;
                            if (!false)
                            {
                                this.GetElementInformation(expr_50);
                            }
                        }
                    }
                }
            }
        }

        private void LoadTemplateList()
        {
            try
            {
                ConfigBusiness expr_751 = new ConfigBusiness();
                ConfigBusiness configBusiness;
                if (!false)
                {
                    configBusiness = expr_751;
                }
                List<AudioTemplateInfo> audioTemplateList = configBusiness.GetAudioTemplateList();
                int num = 0;
                bool flag;
                TemplateListItems templateListItems;
                while (true)
                {
                    flag = (num < audioTemplateList.Count);
                    if (!flag)
                    {
                        break;
                    }
                    flag = !audioTemplateList[num].IsActive;
                    if (!flag)
                    {
                        templateListItems = new TemplateListItems();
                        templateListItems.isActive = true;
                        templateListItems.FilePath = "/DigiPhoto;component/images/audioico.png";
                        templateListItems.Item_ID = audioTemplateList[num].AudioTemplateId;
                        templateListItems.IsChecked = false;
                        templateListItems.DisplayName = audioTemplateList[num].DisplayName;
                        templateListItems.MediaType = 604;
                        templateListItems.Length = audioTemplateList[num].AudioLength;
                        templateListItems.StartTime = 0;
                        templateListItems.EndTime = (int)templateListItems.Length;
                        templateListItems.InsertTime = 0;
                        templateListItems.Name = audioTemplateList[num].Name;
                        templateListItems.Tooltip = string.Concat(new string[]
						{
							"Audio Template\nName : ",
							templateListItems.DisplayName,
							"\nLength: ",
							templateListItems.Length.ToString(),
							" sec"
						});
                        this.objTemplateList.Add(templateListItems);
                    }
                    num++;
                }
                List<VideoTemplateInfo> videoTemplate = configBusiness.GetVideoTemplate();
                num = 0;
                while (true)
                {
                    flag = (num < videoTemplate.Count);
                    if (!flag)
                    {
                        break;
                    }
                    flag = !videoTemplate[num].IsActive;
                    if (!flag)
                    {
                        templateListItems = new TemplateListItems();
                        templateListItems.isActive = true;
                        templateListItems.FilePath = "/DigiPhoto;component/images/vidico.png";
                        templateListItems.Item_ID = videoTemplate[num].VideoTemplateId;
                        templateListItems.IsChecked = false;
                        templateListItems.DisplayName = videoTemplate[num].DisplayName;
                        templateListItems.MediaType = 603;
                        templateListItems.Name = videoTemplate[num].Name;
                        templateListItems.Length = videoTemplate[num].VideoLength;
                        List<VideoTemplateInfo.VideoSlot> videoSlots = configBusiness.GetVideoTemplate(videoTemplate[num].VideoTemplateId).videoSlots;
                        string text = "";
                        int num2 = 0;
                        while (true)
                        {
                            flag = (num2 < videoSlots.Count);
                            if (!flag)
                            {
                                break;
                            }
                            object obj = text;
                            object[] array = new object[8];
                            array[0] = obj;
                            array[1] = "\n(";
                            if (false)
                            {
                                goto IL_368;
                            }
                            array[2] = num2 + 1;
                            array[3] = ") Slot:";
                            array[4] = videoSlots[num2].FrameTimeIn;
                            array[5] = " sec,Photo Display Time:";
                            array[6] = videoSlots[num2].PhotoDisplayTime;
                            array[7] = " sec.";
                            text = string.Concat(array);
                            num2++;
                        }
                        templateListItems.Tooltip = string.Concat(new object[]
						{
							"Video Template\nName : ",
							videoTemplate[num].DisplayName,
							"\nLength : ",
							videoTemplate[num].VideoLength,
							" sec\nSlots",
							text
						});
                        this.objTemplateList.Add(templateListItems);
                    }
                    num++;
                }
                List<VideoBackgroundInfo> videoBackgrounds = configBusiness.GetVideoBackgrounds();
                num = 0;
                goto IL_44A;
            IL_368:
                if (!flag)
                {
                    templateListItems = new TemplateListItems();
                    templateListItems.isActive = true;
                    templateListItems.Item_ID = videoBackgrounds[num].VideoBackgroundId;
                    templateListItems.IsChecked = false;
                    templateListItems.DisplayName = videoBackgrounds[num].DisplayName;
                    templateListItems.MediaType = 605;
                    templateListItems.Name = videoBackgrounds[num].Name;
                    flag = (templateListItems.Name.Contains(".jpg") || templateListItems.Name.Contains(".png"));
                    if (!flag)
                    {
                        templateListItems.FilePath = "/DigiPhoto;component/images/vidico.png";
                    }
                    else
                    {
                        templateListItems.FilePath = LoginUser.DigiFolderPath + "VideoBackGround\\" + videoBackgrounds[num].Name;
                    }
                    templateListItems.Tooltip = "Video BackGround";
                    this.objTemplateList.Add(templateListItems);
                }
                num++;
            IL_44A:
                flag = (num < videoBackgrounds.Count);
                if (flag)
                {
                    flag = !videoBackgrounds[num].IsActive;
                    goto IL_368;
                }
                List<VideoOverlay> videoOverlays = configBusiness.GetVideoOverlays();
                num = 0;
                while (true)
                {
                    flag = (num < videoOverlays.Count);
                    if (!flag)
                    {
                        break;
                    }
                    flag = !videoOverlays[num].IsActive;
                    if (!flag)
                    {
                        templateListItems = new TemplateListItems();
                        templateListItems.isActive = true;
                        templateListItems.Item_ID = videoOverlays[num].VideoOverlayId;
                        templateListItems.IsChecked = false;
                        templateListItems.DisplayName = videoOverlays[num].DisplayName;
                        templateListItems.MediaType = 609;
                        templateListItems.Name = videoOverlays[num].Name;
                        templateListItems.FilePath = "/DigiPhoto;component/images/vidico.png";
                        templateListItems.Tooltip = "Video Overlay";
                        this.objTemplateList.Add(templateListItems);
                    }
                    num++;
                }
                IEnumerable<GraphicsInfo> enumerable = new GraphicsBusiness().GetGraphicsDetails().Where(delegate(GraphicsInfo t)
                {
                    bool? dG_Graphics_IsActive = t.DG_Graphics_IsActive;
                    int arg_42_0;
                    if (!dG_Graphics_IsActive.GetValueOrDefault())
                    {
                        arg_42_0 = 0;
                        goto IL_16;
                    }
                    arg_42_0 = (dG_Graphics_IsActive.HasValue ? 1 : 0);
                IL_10:
                    if (!false)
                    {
                    }
                IL_16:
                    bool expr_45;
                    do
                    {
                        bool flag2 = arg_42_0 != 0;
                        if (!false)
                        {
                        }
                        expr_45 = ((arg_42_0 = (flag2 ? 1 : 0)) != 0);
                    }
                    while (8 == 0);
                    if (!false)
                    {
                        return expr_45;
                    }
                    goto IL_10;
                });
                IEnumerator<GraphicsInfo> enumerator = enumerable.GetEnumerator();
                try
                {
                    while (true)
                    {
                        flag = enumerator.MoveNext();
                        if (!flag)
                        {
                            break;
                        }
                        GraphicsInfo current = enumerator.Current;
                        templateListItems = new TemplateListItems();
                        templateListItems.isActive = true;
                        templateListItems.FilePath = LoginUser.DigiFolderGraphicsPath + current.DG_Graphics_Name;
                        templateListItems.Item_ID = (long)current.DG_Graphics_pkey;
                        templateListItems.IsChecked = false;
                        templateListItems.DisplayName = current.DG_Graphics_Displayname;
                        templateListItems.MediaType = 606;
                        templateListItems.Name = current.DG_Graphics_Name;
                        templateListItems.Tooltip = "Graphics";
                        this.objTemplateList.Add(templateListItems);
                    }
                }
                finally
                {
                    flag = (enumerator == null);
                    if (!flag)
                    {
                        enumerator.Dispose();
                    }
                }
                IEnumerable<BorderInfo> enumerable2 = new BorderBusiness().GetBorderDetails().Where(delegate(BorderInfo t)
                {
                    bool result;
                    if (4 != 0)
                    {
                        bool arg_39_0;
                        if (!t.DG_IsActive)
                        {
                            arg_39_0 = false;
                            goto IL_1A;
                        }
                        if (6 == 0)
                        {
                            return result;
                        }
                        arg_39_0 = (t.DG_ProductTypeID == 95);
                    IL_14:
                        if (false)
                        {
                            goto IL_1E;
                        }
                    IL_1A:
                        if (3 == 0)
                        {
                            goto IL_14;
                        }
                    IL_1E:
                        result = arg_39_0;
                    }
                    return result;
                });
                IEnumerator<BorderInfo> enumerator2 = enumerable2.GetEnumerator();
                try
                {
                    while (true)
                    {
                        if (8 != 0)
                        {
                            flag = enumerator2.MoveNext();
                            if (!flag)
                            {
                                break;
                            }
                            BorderInfo current2 = enumerator2.Current;
                            templateListItems = new TemplateListItems();
                            templateListItems.isActive = true;
                            templateListItems.FilePath = LoginUser.DigiFolderFramePath + "\\Thumbnails\\" + current2.DG_Border;
                            templateListItems.Item_ID = (long)current2.DG_Borders_pkey;
                            templateListItems.IsChecked = false;
                            templateListItems.DisplayName = current2.DG_Border;
                            templateListItems.MediaType = 608;
                            templateListItems.Name = current2.DG_Border;
                            templateListItems.Tooltip = "Borders";
                        }
                        this.objTemplateList.Add(templateListItems);
                    }
                }
                finally
                {
                    flag = (enumerator2 == null);
                    if (!flag)
                    {
                        enumerator2.Dispose();
                    }
                }
                if (7 == 0)
                {
                    goto IL_368;
                }
                List<TemplateListItems> itemsSource = this.objTemplateList.Where(delegate(TemplateListItems o)
                {
                    bool result;
                    while (8 != 0)
                    {
                        bool arg_3A_0;
                        if (o.MediaType == 605)
                        {
                            arg_3A_0 = o.isActive;
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
                            arg_3A_0 = false;
                        }
                        result = arg_3A_0;
                        break;
                    }
                    return result;
                }).ToList<TemplateListItems>();
                this.lstTemplates.ItemsSource = itemsSource;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnCloseTempList_Click(object sender, RoutedEventArgs e)
        {
            while (8 != 0)
            {
                if (this.lstTemplates.Visibility == Visibility.Collapsed)
                {
                    if (3 != 0)
                    {
                        if (!false && true)
                        {
                            this.SetTemplateListVisibility(true);
                        }
                        break;
                    }
                    break;
                }
                else if (!false)
                {
                    this.SetTemplateListVisibility(false);
                    return;
                }
            }
        }

        private void SetTemplateListVisibility(bool IsVisible)
        {
            bool flag = !IsVisible;
            while (true)
            {
                if (!flag)
                {
                    if (6 == 0)
                    {
                        return;
                    }
                    if (false)
                    {
                        goto IL_67;
                    }
                    this.lstTemplates.Visibility = Visibility.Visible;
                    if (-1 != 0)
                    {
                        break;
                    }
                    continue;
                }
            IL_4A:
                if (false)
                {
                    continue;
                }
                this.lstTemplates.Visibility = Visibility.Collapsed;
                this.btnCloseTempList.Visibility = Visibility.Collapsed;
            IL_67:
                this.txtTemplateRotate.Visibility = Visibility.Collapsed;
                if (8 != 0)
                {
                    return;
                }
                goto IL_4A;
            }
            this.btnCloseTempList.Visibility = Visibility.Visible;
            UIElement expr_3A = this.txtTemplateRotate;
            Visibility expr_3F = Visibility.Visible;
            if (!false)
            {
                expr_3A.Visibility = expr_3F;
            }
        }

        private void btnPlayAudio_Click(object sender, RoutedEventArgs e)
        {
            int audioId = Convert.ToInt32(this.txtAudioId.Text);
            TemplateListItems templateListItems = this.objTemplateList.Where(delegate(TemplateListItems o)
            {
                if (o.Item_ID == (long)audioId)
                {
                    goto IL_0E;
                }
                goto IL_1E;
            IL_1F:
                while (false)
                {
                }
                bool arg_47_0;
                bool flag = arg_47_0;
                bool arg_2F_0;
                if (8 != 0)
                {
                    if (!false)
                    {
                        arg_2F_0 = flag;
                        return arg_2F_0;
                    }
                    goto IL_1E;
                }
            IL_0E:
                arg_47_0 = (arg_2F_0 = (o.MediaType == 604));
                if (true)
                {
                    goto IL_1F;
                }
                return arg_2F_0;
            IL_1E:
                arg_47_0 = false;
                goto IL_1F;
            }).FirstOrDefault<TemplateListItems>();
            string text = LoginUser.DigiFolderAudioPath + System.IO.Path.GetFileName(templateListItems.Name);
            VideoEditor.vsMediaFileName = text;
            do
            {
                this.MediaPlay();
            }
            while (3 == 0);
        }

        private void LoadGuestImageList()
        {
            try
            {
                int num = RobotImageLoader.PrintImages.Count<LstMyItems>();
                for (int i = 0; i < num; i++)
                {
                    LstMyItems lstMyItems = new LstMyItems();
                    lstMyItems = RobotImageLoader.PrintImages[i];
                    VideoElements videoElements = new VideoElements();
                    VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
                    videoElements.GuestImagePath = lstMyItems.FilePath.Replace(videoProcessingClass.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(videoProcessingClass.SupportedVideoFormats["ffmpeg"].ToString(), ".jpg");
                    if (lstMyItems.MediaType == 2)
                    {
                        if (-1 == 0)
                        {
                            break;
                        }
                        using (FileStream fileStream = File.OpenRead(System.IO.Path.Combine(lstMyItems.HotFolderPath, "Videos", lstMyItems.CreatedOn.ToString("yyyyMMdd"), lstMyItems.FileName)))
                        {
                            videoElements.VideoFilePath = fileStream.Name;
                        }
                    }
                    else if (lstMyItems.MediaType == 3)
                    {
                        using (FileStream fileStream = File.OpenRead(System.IO.Path.Combine(lstMyItems.HotFolderPath, "ProcessedVideos", lstMyItems.CreatedOn.ToString("yyyyMMdd"), lstMyItems.FileName)))
                        {
                            videoElements.VideoFilePath = fileStream.Name;
                        }
                    }
                    else
                    {
                        bool arg_2A9_0 = lstMyItems.MediaType != 1;
                        while (!arg_2A9_0)
                        {
                            if (num == 1)
                            {
                                videoElements.VideoFilePath = System.IO.Path.Combine(lstMyItems.HotFolderPath, lstMyItems.CreatedOn.ToString("yyyyMMdd"), lstMyItems.FileName);
                            }
                            else if (File.Exists(System.IO.Path.Combine(lstMyItems.HotFolderPath, "EditedImages", lstMyItems.FileName)))
                            {
                                videoElements.VideoFilePath = System.IO.Path.Combine(lstMyItems.HotFolderPath, "EditedImages", lstMyItems.FileName);
                            }
                            else
                            {
                                bool expr_34A = arg_2A9_0 = File.Exists(System.IO.Path.Combine(lstMyItems.HotFolderPath, lstMyItems.FileName));
                                if (false)
                                {
                                    continue;
                                }
                                if (expr_34A)
                                {
                                    videoElements.VideoFilePath = System.IO.Path.Combine(lstMyItems.HotFolderPath, lstMyItems.FileName);
                                }
                                else
                                {
                                    videoElements.VideoFilePath = System.IO.Path.Combine(lstMyItems.HotFolderPath, lstMyItems.CreatedOn.ToString("yyyyMMdd"), lstMyItems.FileName);
                                }
                            }
                            break;
                        }
                    }
                    videoElements.PhotoId = lstMyItems.PhotoId;
                    videoElements.Name = lstMyItems.Name;
                    videoElements.MediaType = lstMyItems.MediaType;
                    videoElements.videoLength = ((!lstMyItems.VideoLength.HasValue) ? 0L : lstMyItems.VideoLength.Value);
                    videoElements.PageNo = i + 1;
                    videoElements.CreatedDate = lstMyItems.CreatedOn;
                    this.lstVideoElements.Add(videoElements);
                }
                if (this.lstVideoElements.Count > 0)
                {
                    this.lstGuestImages.ItemsSource = this.lstVideoElements;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void Image_PreviewMouseDown(object sender, EventArgs e)
        {
            try
            {
                VideoElements videoElements = (VideoElements)(sender as System.Windows.Controls.Image).DataContext;
                this.DropPhotoId = videoElements.PhotoId;
                this.activePage = videoElements.PageNo;
                int arg_B6_0;
                int expr_48 = arg_B6_0 = videoElements.MediaType;
                int arg_B6_1;
                int expr_4E = arg_B6_1 = 2;
                if (expr_4E == 0)
                {
                    goto IL_B6;
                }
                bool arg_63_0;
                if (expr_48 == expr_4E)
                {
                    arg_63_0 = false;
                    goto IL_62;
                }
                bool arg_5D_0 = videoElements.MediaType == 3;
            IL_5C:
                arg_63_0 = !arg_5D_0;
            IL_62:
                if (!arg_63_0)
                {
                    this.StackImageDisplayTime.Visibility = Visibility.Collapsed;
                    this.StackVideoStartEndTime.Visibility = Visibility.Collapsed;
                    this.StackVideoTemplatePlay.Visibility = Visibility.Collapsed;
                }
                else if (!false)
                {
                    this.StackImageDisplayTime.Visibility = Visibility.Collapsed;
                    goto IL_D5;
                }
                do
                {
                    this.StackGraphicSettingPanel1.Visibility = Visibility.Collapsed;
                }
                while (false);
                this.StackGraphicSettingPanel2.Visibility = Visibility.Collapsed;
                arg_B6_0 = ((videoElements.MediaType == 3) ? 1 : 0);
                arg_B6_1 = 0;
            IL_B6:
                bool flag = arg_B6_0 == arg_B6_1;
                bool expr_B9 = arg_5D_0 = flag;
                if (!false)
                {
                    if (!expr_B9)
                    {
                    }
                    goto IL_10A;
                }
                goto IL_5C;
            IL_D5:
                this.StackVideoStartEndTime.Visibility = Visibility.Collapsed;
            IL_E2:
                this.StackVideoTemplatePlay.Visibility = Visibility.Collapsed;
                this.StackGraphicSettingPanel1.Visibility = Visibility.Collapsed;
                this.StackGraphicSettingPanel2.Visibility = Visibility.Collapsed;
            IL_10A:
                DragDrop.DoDragDrop((DependencyObject)sender, ((System.Windows.Controls.Image)sender).Source, System.Windows.DragDropEffects.Copy);
                if (3 == 0)
                {
                    goto IL_E2;
                }
                if (8 == 0)
                {
                    goto IL_D5;
                }
            }
            catch (Exception serviceException)
            {
                while (!true)
                {
                }
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnImgPlay_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                VideoElements videoElements = (VideoElements)(sender as System.Windows.Controls.Button).DataContext;
                if (true)
                {
                    bool arg_D3_0;
                    if (videoElements.MediaType != 2)
                    {
                        arg_D3_0 = (videoElements.MediaType != 3);
                    }
                    else
                    {
                        if (5 == 0)
                        {
                            goto IL_68;
                        }
                        arg_D3_0 = false;
                    }
                    if (arg_D3_0)
                    {
                        this.MediaStop();
                        VideoEditor.vsMediaFileName = videoElements.GuestImagePath.Replace("Thumbnails", "Thumbnails_Big");
                        if (!false)
                        {
                            this.MediaPlay();
                            goto IL_97;
                        }
                    }
                IL_51:
                    VideoEditor.vsMediaFileName = videoElements.VideoFilePath;
                    this.MediaPlay();
                    if (6 == 0)
                    {
                        goto IL_51;
                    }
                }
            IL_67:
            IL_68:
            IL_97:
                if (false)
                {
                    goto IL_67;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
            if (!false)
            {
            }
        }

        private void btnSetDisplayTime_Click(object sender, RoutedEventArgs e)
        {
            VideoPage videoPage = this.PrintOrderPageList.Where(delegate(VideoPage o)
            {
                int arg_0B_0 = o.PhotoId;
                int arg_0B_1 = this.DropPhotoId;
                bool arg_30_0;
                bool flag2;
                while (true)
                {
                    bool arg_4B_0;
                    if (arg_0B_0 != arg_0B_1)
                    {
                        arg_4B_0 = false;
                        goto IL_26;
                    }
                IL_0D:
                    if (-1 == 0)
                    {
                        break;
                    }
                    int expr_41 = arg_0B_0 = o.PageNo;
                    int expr_16 = arg_0B_1 = this.activePage;
                    if (2 == 0)
                    {
                        continue;
                    }
                    arg_4B_0 = (arg_30_0 = (expr_41 == expr_16));
                    if (!true)
                    {
                        return arg_30_0;
                    }
                IL_26:
                    flag2 = arg_4B_0;
                    if (8 != 0)
                    {
                        break;
                    }
                    goto IL_0D;
                }
                arg_30_0 = flag2;
                return arg_30_0;
            }).FirstOrDefault<VideoPage>();
            bool arg_3F_0;
            bool expr_30 = arg_3F_0 = (videoPage == null);
            if (6 != 0)
            {
                bool flag = expr_30;
                arg_3F_0 = flag;
            }
            if (!arg_3F_0)
            {
                int imageDisplayTime = Convert.ToInt32(this.txtImageDisplayTime.Text);
                bool? isChecked = this.chkImgDTSetToAll.IsChecked;
                int arg_78_0;
                if (!isChecked.GetValueOrDefault())
                {
                    arg_78_0 = 0;
                    goto IL_76;
                }
            IL_6C:
                arg_78_0 = (isChecked.HasValue ? 1 : 0);
            IL_76:
                bool flag = arg_78_0 == 0;
                if (7 == 0 || !flag)
                {
                    IEnumerator<VideoPage> enumerator = (from o in this.PrintOrderPageList
                                                         where o.MediaType == 601
                                                         select o).GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            while (true)
                            {
                                flag = enumerator.MoveNext();
                                if (!flag)
                                {
                                    goto Block_8;
                                }
                                VideoPage current = enumerator.Current;
                                if (8 != 0)
                                {
                                    current.ImageDisplayTime = imageDisplayTime;
                                    current.tooltip = "Image display time: " + current.ImageDisplayTime;
                                }
                            }
                        }
                    Block_8: ;
                    }
                    finally
                    {
                        while (true)
                        {
                            if (false)
                            {
                                goto IL_103;
                            }
                            bool arg_104_0;
                            bool expr_FD = arg_104_0 = (enumerator == null);
                            if (4 != 0)
                            {
                                flag = expr_FD;
                                goto IL_103;
                            }
                        IL_104:
                            if (arg_104_0)
                            {
                                goto IL_111;
                            }
                            if (!false)
                            {
                                break;
                            }
                            continue;
                        IL_103:
                            arg_104_0 = flag;
                            goto IL_104;
                        }
                        enumerator.Dispose();
                    IL_111: ;
                    }
                }
                else
                {
                    if (false)
                    {
                        goto IL_6C;
                    }
                    videoPage.ImageDisplayTime = imageDisplayTime;
                    videoPage.tooltip = "Image display time: " + videoPage.ImageDisplayTime;
                }
                this.chkImgDTSetToAll.IsChecked = new bool?(false);
                this.BindPageStrips();
            }
            this.StackImageDisplayTime.Visibility = Visibility.Collapsed;
        }

        private int CalculateProcessedVideoLength()
        {
            int arg_237_0 = 0;
            int expr_22E;
            do
            {
                int num = arg_237_0;
                int num2;
                try
                {
                    List<TemplateListItems> list = this.objTemplateList.Where(delegate(TemplateListItems o)
                    {
                        if (o.MediaType != 603)
                        {
                            goto IL_0E;
                        }
                        goto IL_38;
                        int arg_17_0;
                        int arg_17_1;
                        do
                        {
                        IL_19:
                            int expr_71 = arg_17_0 = o.MediaType;
                            int expr_22 = arg_17_1 = 607;
                            if (expr_22 == 0)
                            {
                                goto IL_17;
                            }
                            if (expr_71 == expr_22)
                            {
                                goto IL_38;
                            }
                        }
                        while (false);
                        if (7 != 0 && o.MediaType == 601)
                        {
                            goto IL_38;
                        }
                        int arg_49_0;
                        if (!false)
                        {
                            arg_49_0 = 0;
                            return arg_49_0 != 0;
                        }
                    IL_0E:
                        arg_17_0 = o.MediaType;
                        arg_17_1 = 602;
                    IL_17:
                        if (arg_17_0 != arg_17_1)
                        {
                            //goto IL_19;
                        }
                    IL_38:
                        if (false)
                        {
                            goto IL_19;
                        }
                        arg_49_0 = (o.IsChecked ? 1 : 0);
                        return arg_49_0 != 0;
                    }).ToList<TemplateListItems>();
                    if (list.Count > 0)
                    {
                        do
                        {
                            using (List<TemplateListItems>.Enumerator enumerator = list.GetEnumerator())
                            {
                                do
                                {
                                IL_F0:
                                    bool arg_F7_0 = enumerator.MoveNext();
                                    while (arg_F7_0)
                                    {
                                        TemplateListItems current = enumerator.Current;
                                        if (current.MediaType == 601)
                                        {
                                            bool arg_D2_0;
                                            arg_F7_0 = (arg_D2_0 = (this.objTemplateList.Where(delegate(TemplateListItems x)
                                            {
                                                bool result;
                                                while (8 != 0)
                                                {
                                                    bool arg_3A_0;
                                                    if (x.MediaType == 603)
                                                    {
                                                        arg_3A_0 = x.IsChecked;
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
                                                        arg_3A_0 = false;
                                                    }
                                                    result = arg_3A_0;
                                                    break;
                                                }
                                                return result;
                                            }).ToList<TemplateListItems>().Count == 0));
                                            while (7 != 0)
                                            {
                                                bool expr_D2 = arg_D2_0 = (arg_F7_0 = !arg_D2_0);
                                                if (!false)
                                                {
                                                    if (!expr_D2)
                                                    {
                                                        num = Convert.ToInt32(this.txtImageDisplayTime.Text);
                                                    }
                                                    goto IL_EF;
                                                }
                                            }
                                            continue;
                                        }
                                        num += (int)current.Length;
                                    IL_EF:
                                        goto IL_F0;
                                    }
                                }
                                while (3 == 0);
                            }
                        }
                        while (false);
                    }
                    else
                    {
                        foreach (VideoPage current2 in this.PrintOrderPageList.Where(delegate(VideoPage o)
                        {
                            if (false)
                            {
                                goto IL_09;
                            }
                            bool arg_07_0 = o.MediaType != 0;
                        IL_07:
                            if (arg_07_0)
                            {
                                goto IL_11;
                            }
                        IL_09:
                            arg_07_0 = (o.MediaType != 0);
                            if (false)
                            {
                                goto IL_07;
                            }
                        IL_11:
                            bool result = true;
                            while (false)
                            {
                            }
                            if (8 != 0)
                            {
                                return result;
                            }
                            goto IL_09;
                        }))
                        {
                            while (true)
                            {
                                int arg_177_0;
                                if (current2.MediaType != 602)
                                {
                                    arg_177_0 = current2.MediaType;
                                    goto IL_172;
                                }
                                bool arg_180_0 = false;
                            IL_17F:
                                if (!arg_180_0)
                                {
                                    int expr_195 = arg_177_0 = num + (current2.videoEndTime - current2.videoStartTime);
                                    if (false)
                                    {
                                        goto IL_172;
                                    }
                                    num = expr_195;
                                }
                                else
                                {
                                    num += current2.ImageDisplayTime;
                                }
                                if (3 != 0)
                                {
                                    break;
                                }
                                continue;
                            IL_172:
                                arg_180_0 = (arg_177_0 != 607);
                                goto IL_17F;
                            }
                        }
                    }
                    num2 = num;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.LogFileWrite(message);
                    num2 = 0;
                }
                expr_22E = (arg_237_0 = num2);
            }
            while (5 == 0);
            return expr_22E;
        }

        private void ClearVideoEditPlayer()
        {
            try
            {
                if (true)
                {
                    this.videoEditorGrid.Children.Clear();
                    bool flag;
                    while (true)
                    {
                        if (!false)
                        {
                            VideoEditor.vsMediaFileName = "";
                            if (5 != 0)
                            {
                                if (false)
                                {
                                    goto IL_71;
                                }
                                this.MediaStop();
                                this.RemoveColorPlugins();
                            }
                            this.RemoveChromaPlugins();
                            goto IL_50;
                        }
                        goto IL_50;
                    IL_71:
                        if (false)
                        {
                            continue;
                        }
                        flag = (this.m_objWriter == null);
                        if (!false)
                        {
                            break;
                        }
                    IL_57:
                        if (this.m_objMixer != null)
                        {
                            this.m_objMixer.ObjectClose();
                            goto IL_71;
                        }
                        goto IL_71;
                    IL_50:
                        this.RemovePlugins();
                        goto IL_57;
                    }
                    if (!flag)
                    {
                        this.m_objWriter.ObjectClose();
                    }
                }
                this.mMixerList1.ClearList();
                Marshal.FinalReleaseComObject(this.m_objWriter);
            }
            catch (Exception var_0_F5)
            {
            }
        }

        private void RemoveChromaPlugins()
        {
            if (4 != 0)
            {
                do
                {
                    this.m_objMixer.PluginsRemove(VideoEditor.objChromaKey);
                    if (!false)
                    {
                        Marshal.ReleaseComObject(VideoEditor.objChromaKey);
                        VideoEditor.objChromaKey = null;
                    }
                }
                while (false);
                if (!false)
                {
                    GC.Collect();
                }
            }
        }

        private void btnVideo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.HighlightSelectedButton("btnVideo");
                this.txtTemplateRotate.Visibility = Visibility.Visible;
                this.templateType = "chroma";
                this.ShowHideControls("video");
                List<TemplateListItems> list = this.objTemplateList.Where(delegate(TemplateListItems o)
                {
                    bool result;
                    while (8 != 0)
                    {
                        bool arg_3A_0;
                        if (o.MediaType == 605)
                        {
                            arg_3A_0 = o.isActive;
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
                            arg_3A_0 = false;
                        }
                        result = arg_3A_0;
                        break;
                    }
                    return result;
                }).ToList<TemplateListItems>();
                int arg_80_0 = (list.Count == 0) ? 1 : 0;
                int expr_D3;
                do
                {
                    if (arg_80_0 != 0)
                    {
                        this.lstTemplates.ItemsSource = null;
                    }
                    else
                    {
                        this.lstTemplates.ItemsSource = list;
                    }
                    expr_D3 = (arg_80_0 = this.objTemplateList.Where(delegate(TemplateListItems o)
                    {
                        int arg_09_0 = o.MediaType;
                        int arg_52_0;
                        while (true)
                        {
                            int arg_1E_0;
                            if (arg_09_0 != 602)
                            {
                                do
                                {
                                    int expr_41 = arg_1E_0 = o.MediaType;
                                    if (false)
                                    {
                                        goto IL_1D;
                                    }
                                    if (expr_41 == 607)
                                    {
                                        goto IL_19;
                                    }
                                }
                                while (false);
                                arg_52_0 = (arg_09_0 = 0);
                                goto IL_29;
                            }
                            goto IL_19;
                            do
                            {
                            IL_1D:
                                arg_1E_0 = (arg_09_0 = (arg_52_0 = ((arg_1E_0 == 0) ? 1 : 0)));
                            }
                            while (false);
                        IL_29:
                            if (!false)
                            {
                                break;
                            }
                            continue;
                        IL_19:
                            arg_1E_0 = (o.isActive ? 1 : 0);
                            //goto IL_1D;
                        }
                        return arg_52_0 != 0;
                    }).ToList<TemplateListItems>().Count);
                }
                while (3 == 0);
                if (expr_D3 > 0)
                {
                    this.lstTemplates.IsEnabled = false;
                }
                else
                {
                    this.lstTemplates.IsEnabled = true;
                }
                this.txtTemplateRotate.Text = "Chroma Backgrounds";
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnAudio_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                try
                {
                    List<TemplateListItems> list;
                    while (!false)
                    {
                        this.SetTemplateListVisibility(true);
                        this.StackGraphicSettingPanel1.Visibility = Visibility.Collapsed;
                        this.StackGraphicSettingPanel2.Visibility = Visibility.Collapsed;
                        if (!false)
                        {
                            this.txtTemplateRotate.Visibility = Visibility.Visible;
                            this.templateType = "audio";
                            this.lstTemplates.IsEnabled = true;
                            list = (from o in this.objTemplateList
                                    where o.MediaType == 604
                                    select o).ToList<TemplateListItems>();
                            int arg_AC_0;
                            int expr_A0 = arg_AC_0 = list.Count;
                            int arg_AC_1;
                            int expr_A6 = arg_AC_1 = 0;
                            if (expr_A6 == 0)
                            {
                                arg_AC_0 = ((expr_A0 == expr_A6) ? 1 : 0);
                                arg_AC_1 = 0;
                            }
                            if (arg_AC_0 == arg_AC_1)
                            {
                                break;
                            }
                            this.lstTemplates.ItemsSource = null;
                            if (8 == 0)
                            {
                                continue;
                            }
                        }
                        else
                        {
                        IL_D6: ;
                        }
                        this.txtTemplateRotate.Text = "Audio Templates";
                        int num = this.CalculateProcessedVideoLength();
                        goto IL_14C;
                    }
                    this.lstTemplates.ItemsSource = list;
                    goto IL_D6;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.LogFileWrite(message);
                }
            IL_14C:
                if (6 != 0)
                {
                }
            }
        }

        private void btnChroma_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                while (true)
                {
                    string expr_07 = "btnChroma";
                    if (3 != 0)
                    {
                        this.HighlightSelectedButton(expr_07);
                    }
                    this.txtTemplateRotate.Visibility = Visibility.Visible;
                    this.templateType = "chroma";
                    string expr_3A = "chroma";
                    if (!false)
                    {
                        this.ShowHideControls(expr_3A);
                    }
                    List<TemplateListItems> list;
                    if (true)
                    {
                        this.lstTemplates.IsEnabled = true;
                        list = (from o in this.objTemplateList
                                where o.MediaType == 605
                                select o).ToList<TemplateListItems>();
                        int arg_A0_0;
                        int expr_8D = arg_A0_0 = list.Count;
                        if (!false)
                        {
                            bool flag = expr_8D != 0;
                            if (!true)
                            {
                                break;
                            }
                            arg_A0_0 = (flag ? 1 : 0);
                        }
                        if (arg_A0_0 == 0)
                        {
                            break;
                        }
                    }
                    this.lstTemplates.ItemsSource = list;
                    if (2 != 0)
                    {
                        goto IL_C6;
                    }
                }
                this.lstTemplates.ItemsSource = null;
            IL_C6:
                this.txtTemplateRotate.Text = "Chroma Backgrounds";
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                while (true)
                {
                    ErrorHandler.LogFileWrite(message);
                    while (8 != 0)
                    {
                        if (!false)
                        {
                            goto Block_7;
                        }
                    }
                }
            Block_7: ;
            }
        }

        private void ShowHideControls(string ctrl)
        {
            do
            {
                try
                {
                    if (!false)
                    {
                        this.lstTemplates.Visibility = Visibility.Visible;
                        this.btnCloseTempList.Visibility = Visibility.Visible;
                        bool arg_3A_0 = ctrl == "video";
                        int arg_3A_1 = 0;
                        while ((arg_3A_0 ? 1 : 0) == arg_3A_1)
                        {
                            int expr_8D = (arg_3A_0 = (ctrl == "audio")) ? 1 : 0;
                            int expr_93 = arg_3A_1 = 0;
                            if (expr_93 == 0)
                            {
                                if (expr_8D == expr_93)
                                {
                                    bool arg_EA_0;
                                    bool expr_E3 = arg_EA_0 = !(ctrl == "chroma");
                                    if (4 != 0)
                                    {
                                        bool flag = expr_E3;
                                        arg_EA_0 = flag;
                                    }
                                    if (!arg_EA_0)
                                    {
                                        this.grdVideoControls.Visibility = Visibility.Collapsed;
                                        this.grdChromaControls.Visibility = Visibility.Visible;
                                    }
                                    else if (ctrl == "Video Capture")
                                    {
                                        if (4 != 0)
                                        {
                                            this.grdVideoControls.Visibility = Visibility.Collapsed;
                                            this.grdChromaControls.Visibility = Visibility.Collapsed;
                                            this.grdColorEffects.Visibility = Visibility.Collapsed;
                                            goto IL_163;
                                        }
                                        goto IL_120;
                                    }
                                    else
                                    {
                                        if (!(ctrl == "ColorEffects"))
                                        {
                                            goto IL_1C8;
                                        }
                                        this.grdVideoControls.Visibility = Visibility.Collapsed;
                                        this.grdChromaControls.Visibility = Visibility.Collapsed;
                                        if (2 != 0)
                                        {
                                            this.grdVideoCaptureControls.Visibility = Visibility.Collapsed;
                                            this.grdColorEffects.Visibility = Visibility.Visible;
                                            if (!false)
                                            {
                                                goto IL_1C8;
                                            }
                                            goto IL_AA;
                                        }
                                    }
                                    this.grdColorEffects.Visibility = Visibility.Collapsed;
                                    this.grdVideoCaptureControls.Visibility = Visibility.Collapsed;
                                IL_120:
                                    goto IL_1C8;
                                }
                                this.grdVideoControls.Visibility = Visibility.Collapsed;
                            IL_AA:
                                this.grdChromaControls.Visibility = Visibility.Collapsed;
                                this.grdColorEffects.Visibility = Visibility.Collapsed;
                                this.grdVideoCaptureControls.Visibility = Visibility.Collapsed;
                                goto IL_1C8;
                            }
                        }
                        this.grdVideoControls.Visibility = Visibility.Visible;
                        this.grdChromaControls.Visibility = Visibility.Collapsed;
                        this.grdVideoCaptureControls.Visibility = Visibility.Collapsed;
                        this.grdColorEffects.Visibility = Visibility.Collapsed;
                        goto IL_1C8;
                    }
                IL_163:
                    this.grdVideoCaptureControls.Visibility = Visibility.Visible;
                IL_1C8: ;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.LogFileWrite(message);
                }
            }
            while (false);
        }

        private void btnCollapse_Click(object sender, RoutedEventArgs e)
        {
            while (this.RightPanel.Visibility == Visibility.Collapsed)
            {
                this.playerMainGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                if (2 != 0)
                {
                    this.LeftPanel.Width = 700.0;
                    if (4 == 0)
                    {
                        continue;
                    }
                    this.RightPanel.Width = 300.0;
                    this.RightPanel.Visibility = Visibility.Visible;
                    this.imgCollapse.Source = new BitmapImage(new Uri("/images/RightArrow.png", UriKind.Relative));
                }
                else
                {
                IL_7E:
                    this.playerMainGrid.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                }
                return;
            }
            this.RightPanel.Width = 0.0;
            this.LeftPanel.Width = 965.0;
            this.RightPanel.Visibility = Visibility.Collapsed;
            this.imgCollapse.Source = new BitmapImage(new Uri("/images/LeftArrow.png", UriKind.Relative));
            goto IL_7E;
        }

        [DllImport("gdi32.dll")]
        public static extern bool DeleteObject(IntPtr hObject);

        private Bitmap BitmapImage2Bitmap(BitmapImage bitmapImage)
        {
            MemoryStream expr_7B = new MemoryStream();
            MemoryStream memoryStream;
            if (!false)
            {
                memoryStream = expr_7B;
                goto IL_0A;
            }
            Bitmap result;
            try
            {
                Bitmap original;
                while (true)
                {
                IL_0A:
                    BitmapEncoder bitmapEncoder = new BmpBitmapEncoder();
                    if (2 != 0)
                    {
                        bitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapImage));
                        goto IL_1C;
                    }
                IL_24:
                    if (5 != 0)
                    {
                        if (false)
                        {
                            continue;
                        }
                        original = new Bitmap(memoryStream);
                        if (2 != 0)
                        {
                            break;
                        }
                    }
                IL_1D:
                    bitmapEncoder.Save(memoryStream);
                    goto IL_24;
                IL_1C:
                    goto IL_1D;
                }
                result = new Bitmap(original);
            }
            finally
            {
                if (6 == 0 || memoryStream != null)
                {
                    ((IDisposable)memoryStream).Dispose();
                }
            }
            return result;
        }

        private void Image_Drop(object sender, System.Windows.DragEventArgs e)
        {
            Func<VideoElements, bool> expr_00 = null;
            if (!false)
            {
                Func<VideoElements, bool> predicate = expr_00;
            }
            try
            {
                VideoElements videoElements;
                VideoPage videoPage;
                int num;
                bool arg_609_0;
                int arg_6EF_0;
                bool arg_450_0;
                while (true)
                {
                IL_16:
                    bool flag = false;
                    if (!this.IsProcessedVideoSaved)
                    {
                        flag = this.MsgBox.ShowHandlerDialog("Do you wish to save changes?", DigiMessageBox.DialogType.Confirm);
                    }
                    if ((this.IsProcessedVideoSaved || !flag) && !this.IsProcessedVideoSaved)
                    {
                        goto IL_81B;
                    }
                    if (-1 == 0)
                    {
                        goto IL_5A7;
                    }
                    this.IsProcessedVideoSaved = true;
                    this.btnSave.IsEnabled = false;
                    IEnumerable<VideoElements> arg_A2_0 = this.lstVideoElements;
                    Func<VideoElements, bool> predicate = (VideoElements o) => o.PhotoId == this.DropPhotoId;
                    videoElements = arg_A2_0.Where(predicate).FirstOrDefault<VideoElements>();
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    if (!true)
                    {
                        goto IL_5F2;
                    }
                    bitmapImage.UriSource = new Uri(videoElements.GuestImagePath, UriKind.Relative);
                    bitmapImage.DecodePixelWidth = 50;
                    bitmapImage.EndInit();
                    Bitmap bitmap = this.BitmapImage2Bitmap(bitmapImage);
                    IntPtr hbitmap = bitmap.GetHbitmap();
                    VideoEditor.DeleteObject(hbitmap);
                    string name = ((System.Windows.Shapes.Rectangle)sender).Name;
                    object obj = ((System.Windows.Shapes.Rectangle)sender).FindName("ViewBox1");
                    object obj2 = ((System.Windows.Shapes.Rectangle)sender).FindName("img1");
                    if (!(obj2 is System.Windows.Controls.Image))
                    {
                        goto IL_81A;
                    }
                    System.Windows.Controls.Image image;
                    if (!false)
                    {
                        image = (System.Windows.Controls.Image)obj2;
                    }
                    System.Windows.Shapes.Rectangle rectangle = (System.Windows.Shapes.Rectangle)sender;
                    int activePage = int.Parse(rectangle.Uid.ToString());
                    videoPage = (from o in this.PrintOrderPageList
                                 where o.PageNo == activePage
                                 select o).FirstOrDefault<VideoPage>();
                    VideoPage videoPage2 = (from o in this.PrintOrderPageList
                                            where o.PhotoId == this.DropPhotoId
                                            select o).FirstOrDefault<VideoPage>();
                    while (true)
                    {
                        if (videoPage2 != null)
                        {
                            if (videoPage2.MediaType == 607)
                            {
                                goto Block_12;
                            }
                        }
                        bool flag2 = videoPage.PhotoId != 0;
                        int arg_20C_0 = flag2 ? 1 : 0;
                        while (arg_20C_0 == 0)
                        {
                            num = (from o in this.PrintOrderPageList
                                   where o.PhotoId == 0
                                   select o).Count<VideoPage>();
                            videoPage = (from o in this.PrintOrderPageList
                                         where o.PhotoId == 0
                                         select o).FirstOrDefault<VideoPage>();
                            image.Source = bitmapImage;
                            videoPage.FilePath = videoElements.GuestImagePath;
                            videoPage.PhotoId = videoElements.PhotoId;
                            videoPage.Name = videoElements.Name;
                            videoPage.DropVideoPath = videoElements.VideoFilePath;
                            videoPage.IsGuestImage = true;
                            if (videoElements.MediaType == 2)
                            {
                                videoPage.MediaType = 602;
                                videoPage.videoLength = videoElements.videoLength;
                                if (-1 == 0)
                                {
                                    goto IL_16;
                                }
                                videoPage.videoStartTime = 0;
                                videoPage.videoEndTime = (int)videoPage.videoLength;
                                videoPage.tooltip = "Video length: " + videoPage.videoLength + " sec.";
                            }
                            else if (videoElements.MediaType == 3)
                            {
                                videoPage.MediaType = 607;
                                videoPage.videoLength = videoElements.videoLength;
                                videoPage.videoStartTime = 0;
                                videoPage.videoEndTime = (int)videoPage.videoLength;
                                videoPage.tooltip = "Video length: " + videoPage.videoLength + " sec.";
                            }
                            else
                            {
                                videoPage.MediaType = 601;
                                bool arg_3D4_0;
                                if (videoPage.ImageDisplayTime != 0)
                                {
                                    arg_609_0 = (videoPage.ImageDisplayTime != 0);
                                    if (4 == 0)
                                    {
                                        goto IL_609;
                                    }
                                    int expr_3C7 = arg_6EF_0 = 0;
                                    if (expr_3C7 != 0)
                                    {
                                        goto IL_6EE;
                                    }
                                    arg_3D4_0 = (expr_3C7 == 0);
                                }
                                else
                                {
                                    arg_3D4_0 = false;
                                }
                                if (!arg_3D4_0)
                                {
                                    videoPage.ImageDisplayTime = 10;
                                }
                                videoPage.tooltip = "Image display time: " + videoPage.ImageDisplayTime + " sec.";
                            }
                            num = (from o in this.PrintOrderPageList
                                   where o.PhotoId == 0
                                   select o).Count<VideoPage>();
                            arg_450_0 = (((num >= 1) ? (arg_20C_0 = 1) : (arg_20C_0 = (this.isVideoTempSelected ? 1 : 0))) != 0);
                            if (true)
                            {
                                goto Block_25;
                            }
                        }
                        int pageNo = videoPage.PageNo;
                        this.ShuffleList(pageNo, false);
                        videoPage = new VideoPage();
                        videoPage.PageNo = pageNo;
                        image.Source = bitmapImage;
                        if (!false)
                        {
                            goto Block_27;
                        }
                    }
                }
            Block_12:
                System.Windows.MessageBox.Show("Same processed video cannot be added more than once!!\n", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
                return;
            Block_25:
                if (!arg_450_0)
                {
                    videoPage = new VideoPage();
                    videoPage.PageNo = this.PrintOrderPageList.Count + 1;
                    videoPage.slotTime = "Drop here!";
                    this.PrintOrderPageList.Add(videoPage);
                }
                goto IL_803;
            Block_27:
                videoPage.FilePath = videoElements.GuestImagePath;
                videoPage.PhotoId = videoElements.PhotoId;
                videoPage.Name = videoElements.Name;
                videoPage.IsGuestImage = true;
                videoPage.DropVideoPath = videoElements.VideoFilePath;
                videoPage.slotTime = "Drop here!";
                if (videoElements.MediaType == 2)
                {
                    videoPage.MediaType = 602;
                    videoPage.videoLength = videoElements.videoLength;
                    videoPage.videoStartTime = 0;
                    videoPage.videoEndTime = (int)videoPage.videoLength;
                    videoPage.tooltip = "Video length: " + videoPage.videoLength + " sec.";
                    goto IL_651;
                }
                if (videoElements.MediaType != 3)
                {
                    videoPage.MediaType = 601;
                    arg_609_0 = (videoPage.ImageDisplayTime != 0);
                    goto IL_609;
                }
                videoPage.MediaType = 607;
            IL_5A7:
                videoPage.videoLength = videoElements.videoLength;
                videoPage.videoStartTime = 0;
                videoPage.videoEndTime = (int)videoPage.videoLength;
                videoPage.tooltip = "Video length: " + videoPage.videoLength + " sec.";
            IL_5F2:
                goto IL_651;
            IL_609:
                bool arg_61B_0;
                if (arg_609_0)
                {
                    int arg_612_0 = videoPage.ImageDisplayTime;
                    arg_61B_0 = (0 == 0);
                }
                else
                {
                    arg_61B_0 = false;
                }
                if (!arg_61B_0)
                {
                    videoPage.ImageDisplayTime = 10;
                }
                videoPage.tooltip = "Image display time: " + videoPage.ImageDisplayTime + " sec.";
            IL_651:
                this.PrintOrderPageList.Add(videoPage);
                num = (from o in this.PrintOrderPageList
                       where o.PhotoId == 0
                       select o).Count<VideoPage>();
                if (num > 1)
                {
                    videoPage = (from o in this.PrintOrderPageList
                                 where o.PhotoId == 0
                                 select o).LastOrDefault<VideoPage>();
                    if (videoPage != null)
                    {
                        this.PrintOrderPageList.Remove(videoPage);
                    }
                    goto IL_73A;
                }
                arg_6EF_0 = num;
            IL_6EE:
                if (arg_6EF_0 < 1 && !this.isVideoTempSelected)
                {
                    videoPage = new VideoPage();
                    videoPage.PageNo = this.PrintOrderPageList.Count + 1;
                    videoPage.slotTime = "Drop here!";
                    this.PrintOrderPageList.Add(videoPage);
                }
            IL_73A:
                if (this.isVideoTempSelected)
                {
                    if (this.PrintOrderPageList.Count > this.defaultProcessListCount)
                    {
                        List<VideoPage> list = (from o in this.PrintOrderPageList
                                                where o.PageNo > this.defaultProcessListCount
                                                orderby o.PageNo
                                                select o).ToList<VideoPage>();
                        while (false)
                        {
                        }
                        foreach (VideoPage current in list)
                        {
                            this.PrintOrderPageList.Remove(current);
                        }
                    }
                }
            IL_803:
                this.BindPageStrips();
                int num2 = this.CalculateProcessedVideoLength();
                this.UpdateGuestImage();
            IL_81A:
            IL_81B: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void ShuffleList(int pagenum, bool isDeleted)
        {
            IEnumerator<VideoPage> enumerator;
            while (isDeleted)
            {
                enumerator = this.PrintOrderPageList.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        VideoPage current = enumerator.Current;
                        bool flag = current.PageNo < pagenum;
                        if (false)
                        {
                            break;
                        }
                        if (!flag)
                        {
                            current.PageNo--;
                        }
                    }
                }
                finally
                {
                    bool arg_D1_0;
                    bool expr_CA = arg_D1_0 = (enumerator == null);
                    if (!false)
                    {
                        bool flag = expr_CA;
                        arg_D1_0 = flag;
                    }
                    if (!arg_D1_0)
                    {
                        enumerator.Dispose();
                    }
                }
                if (5 != 0)
                {
                    return;
                }
            }
            enumerator = this.PrintOrderPageList.GetEnumerator();
            try
            {
                while (true)
                {
                IL_52:
                    bool flag = enumerator.MoveNext();
                    bool arg_5A_0 = flag;
                    while (arg_5A_0)
                    {
                        VideoPage current = enumerator.Current;
                        flag = (current.PageNo < pagenum);
                        bool expr_3A = arg_5A_0 = flag;
                        if (!false)
                        {
                            if (!expr_3A)
                            {
                                current.PageNo++;
                            }
                            goto IL_52;
                        }
                    }
                    break;
                }
            }
            finally
            {
                bool arg_6C_0 = enumerator == null;
                while (true)
                {
                    bool flag = arg_6C_0;
                    while (true)
                    {
                        bool expr_6D = arg_6C_0 = flag;
                        if (6 == 0)
                        {
                            break;
                        }
                        if (expr_6D)
                        {
                            goto IL_7D;
                        }
                        enumerator.Dispose();
                        if (!false)
                        {
                            goto IL_7D;
                        }
                    }
                }
            IL_7D: ;
            }
        }

        public void BindPageStrips()
        {
            try
            {
                int num;
                VideoPage videoPage;
                if (this.PrintOrderPageList.Count<VideoPage>() == 0)
                {
                    while (false)
                    {
                    }
                    num = 1;
                    while (true)
                    {
                    IL_132:
                        int arg_139_0 = num;
                        int arg_139_1 = this.defaultProcessListCount;
                        while (arg_139_0 <= arg_139_1)
                        {
                            videoPage = new VideoPage();
                            videoPage.PageNo = num;
                            int arg_130_0;
                            int expr_4F = arg_130_0 = (arg_139_0 = (this.isVideoTempSelected ? 1 : 0));
                            int arg_12D_0;
                            int expr_55 = arg_12D_0 = 0;
                            if (expr_55 == 0)
                            {
                                if (expr_4F != expr_55)
                                {
                                    videoPage.slotTime = string.Concat(new string[]
									{
										"Slot - ",
										num.ToString(),
										"\n",
										this.slotList[num - 1].FrameTimeIn.ToString(),
										" sec"
									});
                                    videoPage.ImageDisplayTime = this.slotList[num - 1].PhotoDisplayTime;
                                    videoPage.tooltip = "Image display time: " + videoPage.ImageDisplayTime + " sec.";
                                }
                                else
                                {
                                    videoPage.slotTime = "Drop here!";
                                }
                                if (false)
                                {
                                    goto IL_21B;
                                }
                                if (videoPage != null)
                                {
                                    this.PrintOrderPageList.Add(videoPage);
                                }
                                arg_139_0 = (arg_130_0 = num);
                                arg_12D_0 = 1;
                            }
                            int expr_12D = arg_139_1 = arg_12D_0;
                            if (expr_12D != 0)
                            {
                                num = arg_130_0 + expr_12D;
                                goto IL_132;
                            }
                        }
                        break;
                    }
                    this.PrintOrderPageList.Reverse<VideoPage>();
                    goto IL_153;
                }
                num = 1;
                while (true)
                {
                IL_237:
                    bool flag = num <= this.defaultProcessListCount;
                    if (3 == 0)
                    {
                        goto IL_153;
                    }
                    if (!flag)
                    {
                        goto IL_253;
                    }
                    videoPage = this.PrintOrderPageList[num - 1];
                    if (this.isVideoTempSelected)
                    {
                        break;
                    }
                    videoPage.slotTime = "Drop here!";
                    if (4 != 0)
                    {
                        goto IL_22F;
                    }
                }
                videoPage.slotTime = string.Concat(new string[]
				{
					"Slot - ",
					num.ToString(),
					"\n",
					this.slotList[num - 1].FrameTimeIn.ToString(),
					" sec"
				});
                videoPage.ImageDisplayTime = this.slotList[num - 1].PhotoDisplayTime;
                videoPage.tooltip = "Image display time: " + videoPage.ImageDisplayTime + " sec.";
                goto IL_21B;
            IL_153:
                goto IL_253;
            IL_21B:
            IL_22F:
                if (3 != 0)
                {
                    num++;
                    goto IL_237;
                }
                goto IL_28D;
            IL_253:
                this.lstDragImages.ItemsSource = (from o in this.PrintOrderPageList
                                                  orderby o.PageNo
                                                  select o).ToList<VideoPage>();
            IL_28D: ;
            }
            catch (Exception serviceException)
            {
                do
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.LogFileWrite(message);
                }
                while (false);
            }
        }

        private void UpdateGuestImage()
        {
            while (false)
            {
            }
            if (this.ChangeGuestElement)
            {
                try
                {
                    if (this.PrintOrderPageList.Where(delegate(VideoPage o)
                    {
                        int arg_08_0;
                        int arg_25_0 = arg_08_0 = o.PageNo;
                        int arg_05_0 = 1;
                        bool result;
                        while (true)
                        {
                            int arg_22_0;
                            int expr_05 = arg_22_0 = arg_05_0;
                            if (expr_05 != 0)
                            {
                                if (arg_08_0 == expr_05)
                                {
                                    goto IL_0A;
                                }
                                goto IL_29;
                            }
                        IL_22:
                            int expr_22 = arg_05_0 = arg_22_0;
                            bool arg_5D_0;
                            if (expr_22 == 0)
                            {
                                arg_5D_0 = (arg_25_0 == expr_22);
                                goto IL_2D;
                            }
                            continue;
                        IL_1A:
                            arg_25_0 = (arg_08_0 = ((o.FilePath == null) ? 1 : 0));
                            arg_22_0 = 0;
                            goto IL_22;
                        IL_29:
                            if (3 != 0)
                            {
                                arg_5D_0 = false;
                                goto IL_2D;
                            }
                            goto IL_1A;
                        IL_0A:
                            if (false || o.FilePath != "")
                            {
                                goto IL_1A;
                            }
                            goto IL_29;
                        IL_2D:
                            result = arg_5D_0;
                            if (-1 != 0)
                            {
                                break;
                            }
                            goto IL_0A;
                        }
                        return result;
                    }).FirstOrDefault<VideoPage>() != null)
                    {
                        VideoPage videoPage = this.PrintOrderPageList.Where(delegate(VideoPage o)
                        {
                            int arg_08_0;
                            int arg_25_0 = arg_08_0 = o.PageNo;
                            int arg_05_0 = 1;
                            bool result;
                            while (true)
                            {
                                int arg_22_0;
                                int expr_05 = arg_22_0 = arg_05_0;
                                if (expr_05 != 0)
                                {
                                    if (arg_08_0 == expr_05)
                                    {
                                        goto IL_0A;
                                    }
                                    goto IL_29;
                                }
                            IL_22:
                                int expr_22 = arg_05_0 = arg_22_0;
                                bool arg_5D_0;
                                if (expr_22 == 0)
                                {
                                    arg_5D_0 = (arg_25_0 == expr_22);
                                    goto IL_2D;
                                }
                                continue;
                            IL_1A:
                                arg_25_0 = (arg_08_0 = ((o.FilePath == null) ? 1 : 0));
                                arg_22_0 = 0;
                                goto IL_22;
                            IL_29:
                                if (3 != 0)
                                {
                                    arg_5D_0 = false;
                                    goto IL_2D;
                                }
                                goto IL_1A;
                            IL_0A:
                                if (false || o.FilePath != "")
                                {
                                    goto IL_1A;
                                }
                                goto IL_29;
                            IL_2D:
                                result = arg_5D_0;
                                if (-1 != 0)
                                {
                                    break;
                                }
                                goto IL_0A;
                            }
                            return result;
                        }).FirstOrDefault<VideoPage>();
                        this.SetFirstGuestStream(videoPage.DropVideoPath);
                    }
                    else
                    {
                        this.LoadFirstItemOnMixer();
                    }
                }
                catch
                {
                    while (false)
                    {
                    }
                }
            }
            this.ChangeGuestElement = true;
        }

        private void ContentControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            VideoPage item;
            if (-1 != 0 && 8 != 0 && true)
            {
                if (7 == 0)
                {
                    return;
                }
                item = new VideoPage();
                item = this.PrintOrderPageList.Where(delegate(VideoPage o)
                {
                    int arg_0B_0 = o.PageNo;
                    int arg_0B_1 = this.activePage;
                    bool arg_30_0;
                    bool flag;
                    while (true)
                    {
                        bool arg_4B_0;
                        if (arg_0B_0 != arg_0B_1)
                        {
                            arg_4B_0 = false;
                            goto IL_26;
                        }
                    IL_0D:
                        if (-1 == 0)
                        {
                            break;
                        }
                        int expr_41 = arg_0B_0 = o.PhotoId;
                        int expr_16 = arg_0B_1 = this.DropPhotoId;
                        if (2 == 0)
                        {
                            continue;
                        }
                        arg_4B_0 = (arg_30_0 = (expr_41 == expr_16));
                        if (!true)
                        {
                            return arg_30_0;
                        }
                    IL_26:
                        flag = arg_4B_0;
                        if (8 != 0)
                        {
                            break;
                        }
                        goto IL_0D;
                    }
                    arg_30_0 = flag;
                    return arg_30_0;
                }).FirstOrDefault<VideoPage>();
            }
            this.RemoveItem(item);
        }

        private void RemoveItem(VideoPage item)
        {
            try
            {
                if (this.DropPhotoId != 0)
                {
                    string name = item.Name;
                    bool flag;
                    if (!this.IsProcessedVideoSaved)
                    {
                        this.MediaStop();
                        if (2 == 0)
                        {
                            goto IL_BB;
                        }
                        flag = this.MsgBox.ShowHandlerDialog("Do you wish to save changes?", DigiMessageBox.DialogType.Confirm);
                    }
                    else
                    {
                        flag = (System.Windows.MessageBox.Show("Do you want to remove the selected item- '" + name + "' from processing list?", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes);
                    }
                    if ((this.IsProcessedVideoSaved || !flag) && !flag)
                    {
                        VideoEditor.vsMediaFileName = this.processVideoTemp + "\\Output." + this.outputFormat;
                        this.MediaPlay();
                        goto IL_15E;
                    }
                    this.IsProcessedVideoSaved = true;
                    this.btnSave.IsEnabled = false;
                IL_BB:
                    this.PrintOrderPageList.Remove(item);
                    this.ShuffleList(item.PageNo + 1, true);
                    if (this.PrintOrderPageList.Count < this.defaultProcessListCount)
                    {
                        item = new VideoPage();
                        item.PageNo = this.PrintOrderPageList.Count + 1;
                        this.PrintOrderPageList.Add(item);
                    }
                    this.BindPageStrips();
                    VideoEditor.vsMediaFileName = "";
                    this.UpdateGuestImage();
                IL_15E: ;
                }
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void lstDragImagesStackPanel_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.SelectDragImageOrVideo(sender);
        }

        private void lstDragImagesStackPanel_TouchDown(object sender, TouchEventArgs e)
        {
            do
            {
            }
            while (4 == 0);
            this.SelectDragImageOrVideo(sender);
            bool arg_72_0;
            bool expr_27 = arg_72_0 = !this.IsDoubleTap(e);
            VideoPage videoPage;
            if (!false)
            {
                if (expr_27)
                {
                    return;
                }
                if (3 == 0)
                {
                    return;
                }
                do
                {
                    videoPage = new VideoPage();
                }
                while (7 == 0);
                videoPage = this.PrintOrderPageList.Where(delegate(VideoPage o)
                {
                    int arg_0B_0 = o.PageNo;
                    int arg_0B_1 = this.activePage;
                    bool arg_30_0;
                    bool flag2;
                    while (true)
                    {
                        bool arg_4B_0;
                        if (arg_0B_0 != arg_0B_1)
                        {
                            arg_4B_0 = false;
                            goto IL_26;
                        }
                    IL_0D:
                        if (-1 == 0)
                        {
                            break;
                        }
                        int expr_41 = arg_0B_0 = o.PhotoId;
                        int expr_16 = arg_0B_1 = this.DropPhotoId;
                        if (2 == 0)
                        {
                            continue;
                        }
                        arg_4B_0 = (arg_30_0 = (expr_41 == expr_16));
                        if (!true)
                        {
                            return arg_30_0;
                        }
                    IL_26:
                        flag2 = arg_4B_0;
                        if (8 != 0)
                        {
                            break;
                        }
                        goto IL_0D;
                    }
                    arg_30_0 = flag2;
                    return arg_30_0;
                }).FirstOrDefault<VideoPage>();
                if (8 == 0)
                {
                    goto IL_74;
                }
                bool flag = videoPage == null;
                arg_72_0 = flag;
            }
            if (arg_72_0)
            {
                return;
            }
        IL_74:
            this.RemoveItem(videoPage);
        }

        private void SelectDragImageOrVideo(object sender)
        {
            try
            {
                VideoPage videoPage = new VideoPage();
                int arg_1A_0 = (sender is StackPanel) ? 1 : 0;
                int arg_F1_0;
                bool expr_DF;
                do
                {
                    if (arg_1A_0 != 0)
                    {
                        StackPanel stackPanel = sender as StackPanel;
                        this.DropPhotoId = Convert.ToInt32(stackPanel.Tag.ToString());
                        int page = Convert.ToInt32(stackPanel.Uid);
                        videoPage = this.PrintOrderPageList.Where(delegate(VideoPage o)
                        {
                            int arg_23_0;
                            int expr_39 = arg_23_0 = o.PhotoId;
                            int arg_23_1;
                            if (!false)
                            {
                                int expr_0E = arg_23_1 = this.DropPhotoId;
                                if (4 == 0)
                                {
                                    goto IL_23;
                                }
                                if (expr_39 != expr_0E)
                                {
                                    goto IL_27;
                                }
                                arg_23_0 = o.PageNo;
                            }
                            arg_23_1 = page;
                        IL_23:
                            bool arg_50_0 = arg_23_0 == arg_23_1;
                            goto IL_28;
                        IL_27:
                            arg_50_0 = false;
                        IL_28:
                            bool result = arg_50_0;
                            if (!false && -1 != 0)
                            {
                                return result;
                            }
                            goto IL_27;
                        }).FirstOrDefault<VideoPage>();
                        this.extractVideoPath = videoPage.DropVideoPath;
                        this.extractVideoEndTime = videoPage.videoLength;
                    }
                    this.activePage = videoPage.PageNo;
                    if (string.IsNullOrEmpty(videoPage.Name))
                    {
                        goto IL_229;
                    }
                    if (videoPage.MediaType == 602)
                    {
                        goto IL_EF;
                    }
                    expr_DF = ((arg_1A_0 = (arg_F1_0 = ((videoPage.MediaType == 607) ? 1 : 0))) != 0);
                }
                while (7 == 0);
                if (2 != 0)
                {
                    arg_F1_0 = ((!expr_DF) ? 1 : 0);
                }
                goto IL_F0;
            IL_EF:
                arg_F1_0 = 0;
            IL_F0:
                if (arg_F1_0 == 0)
                {
                    this.StackVideoTemplatePlay.Visibility = Visibility.Collapsed;
                    this.StackImageDisplayTime.Visibility = Visibility.Collapsed;
                    this.StackVideoStartEndTime.Visibility = Visibility.Visible;
                    this.StackGraphicSettingPanel1.Visibility = Visibility.Collapsed;
                    this.StackGraphicSettingPanel2.Visibility = Visibility.Collapsed;
                    this.txtvideoStart.Text = videoPage.videoStartTime.ToString();
                    this.txtVideoEnd.Text = videoPage.videoEndTime.ToString();
                    this.RangeSldGuestVideo.LowerValue = (double)videoPage.videoStartTime;
                    this.RangeSldGuestVideo.UpperValue = (double)videoPage.videoEndTime;
                    this.RangeSldGuestVideo.Maximum = (double)videoPage.videoLength;
                }
                else
                {
                    this.StackVideoTemplatePlay.Visibility = Visibility.Collapsed;
                    this.txtImageDisplayTime.Text = videoPage.ImageDisplayTime.ToString();
                    this.StackImageDisplayTime.Visibility = Visibility.Visible;
                    this.StackVideoStartEndTime.Visibility = Visibility.Collapsed;
                    this.StackGraphicSettingPanel1.Visibility = Visibility.Collapsed;
                    this.StackGraphicSettingPanel2.Visibility = Visibility.Collapsed;
                    VideoEditor.vsMediaFileName = videoPage.FilePath.Replace("Thumbnails", "Thumbnails_Big");
                }
                goto IL_26C;
            IL_229:
                this.StackImageDisplayTime.Visibility = Visibility.Collapsed;
                this.StackVideoStartEndTime.Visibility = Visibility.Collapsed;
                this.StackVideoTemplatePlay.Visibility = Visibility.Collapsed;
                this.StackGraphicSettingPanel1.Visibility = Visibility.Collapsed;
                this.StackGraphicSettingPanel2.Visibility = Visibility.Collapsed;
            IL_26C:
                if (this.isVideoTempSelected)
                {
                    this.btnSetDisplayTime.IsEnabled = false;
                    this.chkImgDTSetToAll.IsEnabled = false;
                }
                else
                {
                    this.btnSetDisplayTime.IsEnabled = true;
                    this.chkImgDTSetToAll.IsEnabled = true;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnDropImgPlay_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    new VideoPage();
                    System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
                    this.DropPhotoId = Convert.ToInt32(button.Tag.ToString());
                    VideoPage videoPage = (from o in this.PrintOrderPageList
                                           where o.PhotoId == this.DropPhotoId
                                           select o).FirstOrDefault<VideoPage>();
                    if (!string.IsNullOrEmpty(videoPage.Name))
                    {
                        int arg_9C_0;
                        if (videoPage.MediaType != 602)
                        {
                            int expr_86 = arg_9C_0 = videoPage.MediaType;
                            if (4 != 0)
                            {
                                arg_9C_0 = ((expr_86 != 607) ? 1 : 0);
                            }
                        }
                        else
                        {
                            arg_9C_0 = 0;
                        }
                        if (arg_9C_0 == 0)
                        {
                            VideoEditor.vsMediaFileName = videoPage.DropVideoPath;
                            this.MediaPlay();
                        }
                        else
                        {
                            if (true)
                            {
                                this.MediaStop();
                            }
                            VideoEditor.vsMediaFileName = videoPage.FilePath.Replace("Thumbnails", "Thumbnails_Big");
                            this.MediaPlay();
                        }
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.LogFileWrite(message);
                }
            }
            while (7 == 0);
        }

        private void FillProductCombo()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			dictionary.Add("Select Product", "0");
			try
			{
				ProcessedVideoBusiness processedVideoBusiness = new ProcessedVideoBusiness();
				this.lstVideoProduct = processedVideoBusiness.GetVideoPackages();
				using (IEnumerator<VideoProducts> enumerator = (from o in this.lstVideoProduct
				orderby o.ProductID
				select o).GetEnumerator())
				{
					if (!false)
					{
						while (true)
						{
							if (!false)
							{
								bool arg_EE_0;
								bool expr_DF = arg_EE_0 = enumerator.MoveNext();
								if (7 != 0)
								{
									bool flag = expr_DF;
									if (2 == 0)
									{
										break;
									}
									arg_EE_0 = flag;
								}
								if (!arg_EE_0)
								{
									break;
								}
								VideoProducts item = enumerator.Current;
							}
							if ((from o in dictionary
							where o.Key == item.ProductName
							select o).Count<KeyValuePair<string, string>>() <= 0)
							{
								dictionary.Add(item.ProductName, item.ProductID.ToString());
							}
						}
					}
				}
				this.CmbProductType.ItemsSource = dictionary;
				int arg_11E_0 = dictionary.Count;
				int arg_11E_1 = 1;
				int expr_11E;
				int expr_121;
				do
				{
					expr_11E = (arg_11E_0 = ((arg_11E_0 > arg_11E_1) ? 1 : 0));
					expr_121 = (arg_11E_1 = 0);
				}
				while (expr_121 != 0);
				if (expr_11E != expr_121)
				{
					this.CmbProductType.SelectedIndex = 1;
					if (5 != 0)
					{
					}
				}
				else
				{
					this.CmbProductType.SelectedValue = "0";
				}
			}
			catch (Exception serviceException)
			{
				do
				{
					this.CmbProductType.ItemsSource = dictionary;
				}
				while (false);
				string message = ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.LogFileWrite(message);
			}
		}

        private static string GetFileExt(string filename)
        {
            string result;
            if (-1 != 0 && 8 != 0)
            {
                int num;
                if (true)
                {
                    if (7 == 0)
                    {
                        return result;
                    }
                    num = filename.LastIndexOf('.');
                }
                result = filename.Substring(num, filename.Length - num);
            }
            return result;
        }

        private void btnSelectAll_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = false;
                this.MediaStop();
                this.objTemplateList.RemoveAll(delegate(TemplateListItems o)
                {
                    bool result;
                    while (8 != 0)
                    {
                        bool arg_3A_0;
                        if (o.MediaType == 601)
                        {
                            arg_3A_0 = o.IsChecked;
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
                            arg_3A_0 = false;
                        }
                        result = arg_3A_0;
                        break;
                    }
                    return result;
                });
                if (!this.IsProcessedVideoSaved)
                {
                    flag = this.MsgBox.ShowHandlerDialog("Do you wish to save changes?", DigiMessageBox.DialogType.Confirm);
                }
                bool flag2 = (this.IsProcessedVideoSaved || !flag) && !this.IsProcessedVideoSaved;
                if (7 != 0)
                {
                    if (flag2)
                    {
                        goto IL_40D;
                    }
                    this.IsProcessedVideoSaved = true;
                    this.btnSave.IsEnabled = false;
                    int num = 1;
                    this.PrintOrderPageList.Clear();
                    foreach (VideoElements current in this.lstVideoElements)
                    {
                        int arg_FD_0;
                        if (this.isVideoTempSelected)
                        {
                            arg_FD_0 = ((this.PrintOrderPageList.Count != this.slotList.Count) ? 1 : 0);
                        }
                        else
                        {
                            arg_FD_0 = 1;
                        }
                    IL_FC:
                        if (arg_FD_0 == 0)
                        {
                            break;
                        }
                        VideoPage videoPage = new VideoPage();
                        videoPage.FilePath = current.GuestImagePath;
                        videoPage.PhotoId = current.PhotoId;
                        videoPage.Name = current.Name;
                        videoPage.DropVideoPath = current.VideoFilePath;
                        videoPage.PageNo = num;
                        videoPage.IsGuestImage = true;
                        if (current.MediaType == 2)
                        {
                            videoPage.MediaType = 602;
                            videoPage.videoLength = current.videoLength;
                            videoPage.videoStartTime = 0;
                            videoPage.videoEndTime = (int)videoPage.videoLength;
                            if (2 != 0)
                            {
                                videoPage.tooltip = "Video length: " + videoPage.videoLength + " sec.";
                                goto IL_2D4;
                            }
                        }
                        else
                        {
                            bool expr_1CC = (arg_FD_0 = ((current.MediaType != 3) ? 1 : 0)) != 0;
                            if (true)
                            {
                                if (!expr_1CC)
                                {
                                    videoPage.MediaType = 607;
                                    videoPage.videoLength = current.videoLength;
                                    videoPage.videoStartTime = 0;
                                    if (8 != 0)
                                    {
                                        videoPage.videoEndTime = (int)videoPage.videoLength;
                                        videoPage.tooltip = "Video length: " + videoPage.videoLength + " sec.";
                                        goto IL_2D4;
                                    }
                                }
                                else
                                {
                                    videoPage.MediaType = 601;
                                    if (this.isVideoTempSelected && this.slotList.Count <= num)
                                    {
                                        videoPage.ImageDisplayTime = this.slotList[num - 1].PhotoDisplayTime;
                                    }
                                    else
                                    {
                                        videoPage.ImageDisplayTime = 10;
                                    }
                                }
                            IL_28A:
                                bool arg_2A1_0;
                                if (videoPage.ImageDisplayTime != 0)
                                {
                                    int arg_298_0 = videoPage.ImageDisplayTime;
                                    arg_2A1_0 = (0 == 0);
                                }
                                else
                                {
                                    arg_2A1_0 = false;
                                }
                                if (!arg_2A1_0)
                                {
                                    videoPage.ImageDisplayTime = 10;
                                }
                                videoPage.tooltip = "Image display time: " + videoPage.ImageDisplayTime + " sec.";
                                goto IL_2D4;
                                goto IL_28A;
                            }
                            goto IL_F9;
                        }
                        continue;
                    IL_2D4:
                        this.PrintOrderPageList.Add(videoPage);
                        num++;
                        continue;
                    IL_F9:
                        goto IL_FC;
                    }
                    bool arg_31E_0 = this.PrintOrderPageList.Count >= this.defaultProcessListCount;
                    bool arg_3BB_0;
                    do
                    {
                        if (!arg_31E_0)
                        {
                            for (int i = this.PrintOrderPageList.Count; i < this.defaultProcessListCount; i++)
                            {
                                VideoPage videoPage = new VideoPage();
                                videoPage.PageNo = i;
                                videoPage.slotTime = "Drop here!";
                                this.PrintOrderPageList.Add(videoPage);
                            }
                        }
                        int num2 = (from o in this.PrintOrderPageList
                                    where o.PhotoId == 0
                                    select o).Count<VideoPage>();
                        if (num2 >= 1)
                        {
                            goto IL_3B9;
                        }
                        arg_3BB_0 = (arg_31E_0 = this.isVideoTempSelected);
                    }
                    while (5 == 0);
                    goto IL_3BA;
                IL_3B9:
                    arg_3BB_0 = true;
                IL_3BA:
                    flag2 = arg_3BB_0;
                }
                if (!flag2)
                {
                    VideoPage videoPage = new VideoPage();
                    videoPage.PageNo = this.PrintOrderPageList.Count + 1;
                    videoPage.slotTime = "Drop here!";
                    this.PrintOrderPageList.Add(videoPage);
                }
                this.BindPageStrips();
                int num3 = this.CalculateProcessedVideoLength();
                this.UpdateGuestImage();
            IL_40D: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = false;
                if (!this.IsProcessedVideoSaved)
                {
                    flag = this.MsgBox.ShowHandlerDialog("Do you wish to save changes?", DigiMessageBox.DialogType.Confirm);
                }
                bool arg_44_0 = this.IsProcessedVideoSaved;
                while (true)
                {
                    if ((!arg_44_0 && flag) || this.IsProcessedVideoSaved)
                    {
                        goto IL_64;
                    }
                    goto IL_EC;
                IL_6B:
                    this.btnSave.IsEnabled = false;
                    this.PrintOrderPageList.Clear();
                    this.BindPageStrips();
                    this.MediaStop();
                    if (!false)
                    {
                        int num = this.CalculateProcessedVideoLength();
                        string currentDirectory = Environment.CurrentDirectory;
                        string text = currentDirectory + "\\";
                        if (!false)
                        {
                            text = System.IO.Path.Combine(text, "CapturedFrames\\");
                        }
                        bool expr_BE = arg_44_0 = Directory.Exists(text);
                        if (7 == 0)
                        {
                            continue;
                        }
                        bool flag2 = !expr_BE;
                        if (false)
                        {
                            goto IL_64;
                        }
                        if (!flag2)
                        {
                            Directory.Delete(text);
                        }
                    }
                    goto IL_DE;
                IL_64:
                    this.IsProcessedVideoSaved = true;
                    goto IL_6B;
                IL_DE:
                    this.UpdateGuestImage();
                    if (false)
                    {
                        goto IL_6B;
                    }
                IL_EC:
                    if (6 != 0)
                    {
                        break;
                    }
                    goto IL_DE;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void ResizeWPFImage(string sourceImage, int maxHeight, string saveToPath)
        {
            try
            {
                BitmapImage expr_15F = new BitmapImage();
                BitmapImage bitmapImage;
                if (!false)
                {
                    bitmapImage = expr_15F;
                }
                BitmapImage expr_16F = new BitmapImage();
                BitmapImage bitmapImage2;
                if (3 != 0)
                {
                    bitmapImage2 = expr_16F;
                }
                using (FileStream fileStream = File.OpenRead(sourceImage.ToString()))
                {
                    MemoryStream memoryStream = new MemoryStream();
                    if (2 != 0)
                    {
                        fileStream.CopyTo(memoryStream);
                    }
                    memoryStream.Seek(0L, SeekOrigin.Begin);
                    fileStream.Close();
                    while (true)
                    {
                        bitmapImage.BeginInit();
                        bitmapImage.StreamSource = memoryStream;
                        bitmapImage.EndInit();
                        bitmapImage.Freeze();
                        decimal d = Convert.ToDecimal(bitmapImage.Width) / Convert.ToDecimal(bitmapImage.Height);
                        int arg_A3_0;
                        int expr_98 = arg_A3_0 = Convert.ToInt32(maxHeight * d);
                        int decodePixelWidth;
                        if (!false)
                        {
                            decodePixelWidth = expr_98;
                            arg_A3_0 = maxHeight;
                        }
                        int decodePixelHeight = arg_A3_0;
                        memoryStream.Seek(0L, SeekOrigin.Begin);
                        bitmapImage2.BeginInit();
                        while (true)
                        {
                            bitmapImage2.StreamSource = memoryStream;
                            bitmapImage2.DecodePixelWidth = decodePixelWidth;
                            if (false)
                            {
                                break;
                            }
                            bitmapImage2.DecodePixelHeight = decodePixelHeight;
                            bitmapImage2.EndInit();
                            bitmapImage2.Freeze();
                            if (6 != 0)
                            {
                                goto Block_8;
                            }
                        }
                    }
                Block_8: ;
                }
                FileStream fileStream2 = new FileStream(saveToPath, FileMode.Create, FileAccess.ReadWrite, FileShare.ReadWrite);
                try
                {
                    JpegBitmapEncoder jpegBitmapEncoder = new JpegBitmapEncoder();
                    jpegBitmapEncoder.QualityLevel = 94;
                    do
                    {
                        jpegBitmapEncoder.Frames.Add(BitmapFrame.Create(bitmapImage2));
                        jpegBitmapEncoder.Save(fileStream2);
                    }
                    while (false);
                }
                finally
                {
                    if (fileStream2 == null)
                    {
                        goto IL_157;
                    }
                IL_14F:
                    ((IDisposable)fileStream2).Dispose();
                IL_157:
                    if (4 == 0)
                    {
                        goto IL_14F;
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
            finally
            {
                if (DateTime.Now.Subtract(this.lastmemoryUpdateTime).Seconds > 30)
                {
                    MemoryManagement.FlushMemory();
                    this.lastmemoryUpdateTime = DateTime.Now;
                }
            }
        }

        private void CopyVideoToDisplayFolder(string videofile)
        {
            bool flag = !ConfigManager.IMIXConfigurations.ContainsKey(62L) || !Convert.ToBoolean(ConfigManager.IMIXConfigurations[62L]);
            while (!flag)
            {
                string text = ConfigManager.IMIXConfigurations.ContainsKey(63L) ? ConfigManager.IMIXConfigurations[63L] : null;
                if (!true)
                {
                    goto IL_13F;
                }
                int num = ConfigManager.IMIXConfigurations.ContainsKey(87L) ? Convert.ToInt32(ConfigManager.IMIXConfigurations[87L]) : 0;
                this.folderCount++;
                int arg_BF_0;
                if (!ConfigManager.IMIXConfigurations.ContainsKey(88L))
                {
                    arg_BF_0 = 0;
                }
                else
                {
                    if (false)
                    {
                        goto IL_1AE;
                    }
                    arg_BF_0 = (Convert.ToBoolean(ConfigManager.IMIXConfigurations[88L]) ? 1 : 0);
                }
            IL_BE:
                bool flag2 = arg_BF_0 != 0;
                int num2;
                if (!flag2)
                {
                    num2 = 1;
                    goto IL_1B6;
                }
                int arg_1BC_0;
                int expr_CF = arg_1BC_0 = this.folderCount;
                int arg_1BC_1;
                int expr_D4 = arg_1BC_1 = num;
                if (false)
                {
                    goto IL_1BC;
                }
                if (expr_CF > expr_D4)
                {
                    goto IL_162;
                }
                string text2 = text + "\\Display\\Display" + this.folderCount;
                flag = string.IsNullOrEmpty(text2);
                if (false)
                {
                    continue;
                }
                if (!flag)
                {
                    if (!Directory.Exists(text2))
                    {
                        Directory.CreateDirectory(text2);
                    }
                    string destFileName = text2 + "\\" + System.IO.Path.GetFileName(videofile);
                    File.Copy(videofile, destFileName);
                }
            IL_140:
                bool expr_14A = (arg_BF_0 = ((this.folderCount != num) ? 1 : 0)) != 0;
                if (!false)
                {
                    if (!expr_14A)
                    {
                        this.folderCount = 0;
                    }
                    goto IL_162;
                }
                goto IL_BE;
            IL_13F:
                goto IL_140;
            IL_162:
                if (3 != 0)
                {
                    break;
                }
                break;
            IL_1AE:
                num2++;
            IL_1B6:
                arg_1BC_0 = ((num2 > num) ? 1 : 0);
                arg_1BC_1 = 0;
            IL_1BC:
                flag = (arg_1BC_0 == arg_1BC_1);
                if (3 != 0 && flag)
                {
                    text2 = text + "\\Display\\Display" + num2.ToString();
                    if (!Directory.Exists(text2))
                    {
                        Directory.CreateDirectory(text2);
                    }
                    File.Copy(videofile, text2 + "\\" + System.IO.Path.GetFileName(videofile));
                    goto IL_1AE;
                }
                break;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool flag = false;
                bool flag2;
                bool arg_62_0;
                bool arg_68_0;
                if (3 != 0)
                {
                    flag2 = this.IsProcessedVideoSaved;
                    if (!true)
                    {
                        goto IL_87;
                    }
                    if (!flag2)
                    {
                        bool expr_3C = arg_62_0 = (System.Windows.MessageBox.Show("Would you like to continue exit? Click “Yes” to exit or click “No” to save processed video.", "Digiphoto", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No) == MessageBoxResult.Yes);
                        if (5 == 0)
                        {
                            goto IL_61;
                        }
                        flag = expr_3C;
                    }
                    if (!this.IsProcessedVideoSaved)
                    {
                        if (false)
                        {
                            goto IL_69;
                        }
                        if (flag)
                        {
                            arg_68_0 = false;
                            goto IL_67;
                        }
                    }
                }
                arg_62_0 = this.IsProcessedVideoSaved;
            IL_61:
                arg_68_0 = !arg_62_0;
            IL_67:
                flag2 = arg_68_0;
            IL_69:
                if (!flag2)
                {
                    this.MediaStop();
                    this.ClearVideoEditPlayer();
                    if (-1 != 0)
                    {
                        this.ShowVOS();
                    }
                }
            IL_87: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
            while (3 == 0)
            {
            }
        }

        private void MediaStop()
        {
            bool arg_6C_0;
            bool expr_09 = arg_6C_0 = (this.mplayer == null);
            if (!false)
            {
                if (expr_09)
                {
                    goto IL_37;
                }
                this.mplayer.MediaStop();
            IL_28:
                this.mplayer = null;
                if (!false)
                {
                }
            IL_37:
                this.gdMediaPlayer.Children.Remove(this.mplayer);
                this.gdMediaPlayer.Children.Clear();
                if (false)
                {
                    goto IL_28;
                }
                bool flag = this.clientWin == null;
                arg_6C_0 = flag;
            }
            if (!arg_6C_0)
            {
                this.clientWin.StopMediaPlay();
            }
        }

        private void MediaPlay()
        {
            bool flag;
            while (true)
            {
                this.stkbtnClosePreview.Visibility = Visibility.Visible;
                this.VideoEditPlayerPanel.Visibility = Visibility.Collapsed;
                this.vidoriginal.Visibility = Visibility.Visible;
                this.MediaStop();
                bool? isChecked;
                int arg_FC_0;
                if (!false)
                {
                    flag = (this.mplayer == null);
                    if (2 != 0)
                    {
                        if (!flag)
                        {
                            this.mplayer.Dispose();
                            goto IL_67;
                        }
                        goto IL_67;
                    }
                IL_AE:
                    this.gdMediaPlayer.Children.Add(this.mplayer);
                    this.gdMediaPlayer.EndInit();
                    if (!false)
                    {
                        isChecked = this.btnchkpreview.IsChecked;
                        if (isChecked.GetValueOrDefault())
                        {
                            goto IL_EA;
                        }
                        arg_FC_0 = 0;
                        goto IL_FA;
                    }
                IL_67:
                    string arg_99_0 = VideoEditor.vsMediaFileName;
                    string arg_99_1 = "VideoEditor";
                    isChecked = this.btnchkpreview.IsChecked;
                    this.mplayer = new MLMediaPlayer(arg_99_0, arg_99_1, isChecked == true);
                    this.gdMediaPlayer.BeginInit();
                    goto IL_AE;
                }
                goto IL_EA;
            IL_FA:
                flag = (arg_FC_0 == 0);
                if (true)
                {
                    break;
                }
                continue;
            IL_EA:
                if (8 != 0)
                {
                    arg_FC_0 = (isChecked.HasValue ? 1 : 0);
                    goto IL_FA;
                }
                return;
            }
            if (!flag)
            {
                if (this.clientWin == null)
                {
                    IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            Window window = (Window)enumerator.Current;
                            flag = !(window.Title == "ClientView");
                            while (!flag)
                            {
                                this.clientWin = (ClientView)window;
                                if (!false)
                                {
                                    goto IL_171;
                                }
                            }
                        }
                    IL_171: ;
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        if (disposable != null && 5 != 0)
                        {
                            disposable.Dispose();
                        }
                    }
                }
            }
        }

        private void btnCapture_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                this.HighlightSelectedButton("btnCapture");
                while (true)
                {
                IL_0A:
                    this.txtTemplateRotate.Visibility = Visibility.Visible;
                    if (!false)
                    {
                        if (-1 == 0)
                        {
                            break;
                        }
                        this.lstTemplates.IsEnabled = true;
                    }
                    this.ShowHideControls("Video Capture");
                    while (!false)
                    {
                        this.btnStopProcess.IsEnabled = false;
                        if (!false)
                        {
                            if (true)
                            {
                                return;
                            }
                            goto IL_0A;
                        }
                    }
                    break;
                }
            }
        }

        private Dictionary<string, int> LoadValueTypeList()
        {
            if (3 == 0)
            {
                goto IL_2D;
            }
        IL_04:
            this.listValueType = new Dictionary<string, int>();
            this.listValueType.Add("Image", 601);
        IL_2D:
            this.listValueType.Add("Video", 602);
            this.listValueType.Add("VideoTemplate", 603);
            this.listValueType.Add("AudioTemplate", 604);
            this.listValueType.Add("VideoBackground", 605);
            this.listValueType.Add("Graphics", 606);
            this.listValueType.Add("ProcessedVideo", 607);
            if (!false)
            {
                return this.listValueType;
            }
            goto IL_04;
        }

        private void ChkSelected_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				bool flag = false;
				bool flag2 = this.IsProcessedVideoSaved;
				System.Windows.Controls.CheckBox checkBox;
				bool? isChecked;
				TemplateListItems templateListItems;
				List<TemplateListItems> itemsSource;
				while (true)
				{
					IL_1D:
					if (!flag2)
					{
						flag = this.MsgBox.ShowHandlerDialog("Do you wish to save changes?", DigiMessageBox.DialogType.Confirm);
					}
					int arg_5C_0;
					if (this.IsProcessedVideoSaved || !flag)
					{
						arg_5C_0 = ((!this.IsProcessedVideoSaved) ? 1 : 0);
					}
					else
					{
						arg_5C_0 = 0;
					}
					IL_5B:
					if (arg_5C_0 != 0)
					{
						goto IL_D59;
					}
					this.IsProcessedVideoSaved = true;
					this.btnSave.IsEnabled = false;
					checkBox = (sender as System.Windows.Controls.CheckBox);
					int id = Convert.ToInt32(checkBox.Uid);
					flag2 = !(this.templateType == "chroma");
					IL_B6:
					int num;
					while (flag2)
					{
						if (this.templateType == "video")
						{
							num = 0;
							while (true)
							{
								flag2 = (num < this.objTemplateList.Count);
								if (!flag2)
								{
									break;
								}
								bool arg_32A_0;
								if (this.objTemplateList[num].MediaType == 603 && this.objTemplateList[num].Item_ID == (long)id)
								{
									isChecked = checkBox.IsChecked;
									int arg_324_0;
									if (isChecked.GetValueOrDefault())
									{
										if (false)
										{
											goto IL_B6;
										}
										arg_324_0 = (isChecked.HasValue ? 1 : 0);
									}
									else
									{
										arg_324_0 = 0;
									}
									arg_32A_0 = (arg_324_0 == 0);
								}
								else
								{
									arg_32A_0 = true;
								}
								if (!arg_32A_0)
								{
									this.objTemplateList[num].IsChecked = true;
									this.objTemplateList[num].CheckedBoxVisible = Visibility.Visible;
									ConfigBusiness configBusiness = new ConfigBusiness();
									this.slotList = configBusiness.GetVideoTemplate((long)id).videoSlots;
									if (this.slotList == null)
									{
										this.slotList = new List<VideoTemplateInfo.VideoSlot>();
									}
									string text = LoginUser.DigiFolderVideoTemplatePath + System.IO.Path.GetFileName(this.objTemplateList[num].Name);
									this.txtSelVideoTemp.Text = id.ToString();
								}
								else if (this.objTemplateList[num].MediaType == 603)
								{
									this.MediaStop();
									this.objTemplateList[num].IsChecked = false;
									this.isVideoTempSelected = false;
								}
								num++;
							}
							bool expr_46D = (arg_5C_0 = ((this.objTemplateList.Where(delegate(TemplateListItems o)
							{
								bool result;
								while (8 != 0)
								{
									bool arg_3A_0;
									if (o.MediaType == 603)
									{
										arg_3A_0 = o.IsChecked;
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
										arg_3A_0 = false;
									}
									result = arg_3A_0;
									break;
								}
								return result;
							}).ToList<TemplateListItems>().Count<TemplateListItems>() <= 0) ? 1 : 0)) != 0;
							if (false)
							{
								goto IL_58;
							}
							flag2 = expr_46D;
							if (!flag2)
							{
								this.isVideoTempSelected = true;
								this.defaultProcessListCount = this.slotList.Count;
								this.PrintOrderPageList.Clear();
								this.BindPageStrips();
								this.StackImageDisplayTime.Visibility = Visibility.Collapsed;
								this.StackVideoStartEndTime.Visibility = Visibility.Collapsed;
								this.StackVideoTemplatePlay.Visibility = Visibility.Visible;
								goto IL_534;
							}
							this.isVideoTempSelected = false;
							this.defaultProcessListCount = 10;
							this.PrintOrderPageList.Clear();
							if (4 == 0)
							{
								goto IL_A4F;
							}
							this.BindPageStrips();
							this.StackImageDisplayTime.Visibility = Visibility.Collapsed;
							if (!false)
							{
								this.StackVideoStartEndTime.Visibility = Visibility.Collapsed;
								this.StackVideoTemplatePlay.Visibility = Visibility.Collapsed;
								this.slotList.Clear();
								goto IL_533;
							}
							goto IL_B4E;
						}
						else
						{
							if (this.templateType == "audio")
							{
								goto Block_34;
							}
							if (this.templateType == "graphics")
							{
								templateListItems = this.objTemplateList.Where(delegate(TemplateListItems o)
								{
									if (o.MediaType == 606)
									{
										goto IL_0B;
									}
									goto IL_1E;
									IL_1F:
									while (false)
									{
									}
									bool arg_47_0;
									bool flag3 = arg_47_0;
									bool arg_2F_0;
									if (8 != 0)
									{
										if (!false)
										{
											arg_2F_0 = flag3;
											return arg_2F_0;
										}
										goto IL_1E;
									}
									IL_0B:
									arg_47_0 = (arg_2F_0 = (o.Item_ID == (long)id));
									if (true)
									{
										goto IL_1F;
									}
									return arg_2F_0;
									IL_1E:
									arg_47_0 = false;
									goto IL_1F;
								}).FirstOrDefault<TemplateListItems>();
								bool arg_7F7_0;
								if (templateListItems != null)
								{
									isChecked = checkBox.IsChecked;
									arg_7F7_0 = !(isChecked == true);
								}
								else
								{
									arg_7F7_0 = true;
								}
								if (!arg_7F7_0)
								{
									templateListItems.IsChecked = true;
									templateListItems.CheckedBoxVisible = Visibility.Visible;
								}
								else if (templateListItems.MediaType == 606)
								{
									templateListItems.IsChecked = false;
								}
								if (-1 != 0)
								{
									goto Block_47;
								}
								goto IL_B4E;
							}
							else
							{
								if (this.templateType == "overlay")
								{
									num = 0;
									goto IL_A3F;
								}
								num = 0;
							}
						}
						IL_C9C:
						bool arg_B69_0;
						if (num >= this.objTemplateList.Count)
						{
							flag2 = (this.objTemplateList.Where(delegate(TemplateListItems o)
							{
								bool result;
								while (8 != 0)
								{
									bool arg_3A_0;
									if (o.MediaType == 608)
									{
										arg_3A_0 = o.IsChecked;
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
										arg_3A_0 = false;
									}
									result = arg_3A_0;
									break;
								}
								return result;
							}).ToList<TemplateListItems>().Count != 0);
							if (flag2)
							{
								goto IL_D15;
							}
							this.BorderElement.ElementMultipleSet("show=false", 0.0);
							if (!false)
							{
								goto IL_D15;
							}
							goto IL_1D;
						}
						else
						{
							if (this.objTemplateList[num].MediaType == 608 && this.objTemplateList[num].Item_ID == (long)id)
							{
								isChecked = checkBox.IsChecked;
								goto IL_B4E;
							}
							arg_B69_0 = true;
							goto IL_B68;
						}
						IL_C97:
						num++;
						goto IL_C9C;
						IL_B68:
						if (!arg_B69_0)
						{
							this.objTemplateList[num].IsChecked = true;
							this.objTemplateList[num].CheckedBoxVisible = Visibility.Visible;
							string bsPath = LoginUser.DigiFolderFramePath + System.IO.Path.GetFileName(this.objTemplateList[num].Name);
							MItem mItem;
							this.m_pMixerStreams.StreamsAdd(this.strBorderStream, null, bsPath, null, out mItem, 0.0);
							string empty = string.Empty;
							if (string.IsNullOrEmpty(this.strBorderStream))
							{
								int num2;
								this.m_pMixerStreams.StreamsGetCount(out num2);
								this.m_pMixerStreams.StreamsGetByIndex(num2 - 1, out empty, out mItem);
								this.strBorderStream = empty;
								goto IL_C22;
							}
							goto IL_C23;
						}
						else
						{
							if (this.objTemplateList[num].MediaType == 608)
							{
								this.objTemplateList[num].IsChecked = false;
								goto IL_C97;
							}
							goto IL_C97;
						}
						IL_B4E:
						arg_B69_0 = !(isChecked == true);
						goto IL_B68;
						IL_C23:
						this.BorderElement.ElementMultipleSet("stream_id=" + this.strBorderStream + " audio_gain=-100 show=true h=1 w=1 x=0 y=0", 0.0);
						this.BorderElement.ElementReorder(1000);
						goto IL_C97;
						IL_C22:
						goto IL_C23;
						IL_534:
						itemsSource = this.objTemplateList.Where(delegate(TemplateListItems o)
						{
							bool result;
							while (8 != 0)
							{
								bool arg_3A_0;
								if (o.MediaType == 603)
								{
									arg_3A_0 = base.IsActive;
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
									arg_3A_0 = false;
								}
								result = arg_3A_0;
								break;
							}
							return result;
						}).ToList<TemplateListItems>();
						this.lstTemplates.ItemsSource = itemsSource;
						if (!false)
						{
							goto Block_33;
						}
						goto IL_C22;
						IL_533:
						goto IL_534;
						IL_A4F:
						if (!flag2)
						{
							if (this.objTemplateList.Where(delegate(TemplateListItems o)
							{
								bool result;
								while (8 != 0)
								{
									bool arg_3A_0;
									if (o.MediaType == 609)
									{
										arg_3A_0 = o.IsChecked;
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
										arg_3A_0 = false;
									}
									result = arg_3A_0;
									break;
								}
								return result;
							}).ToList<TemplateListItems>().Count != 0)
							{
								goto IL_AC5;
							}
							this.OverlayElement.ElementMultipleSet("show=false", 0.0);
							if (!false)
							{
								goto Block_59;
							}
							goto IL_533;
						}
						else
						{
							bool arg_8FB_0;
							if (this.objTemplateList[num].MediaType == 609 && this.objTemplateList[num].Item_ID == (long)id)
							{
								isChecked = checkBox.IsChecked;
								arg_8FB_0 = !(isChecked == true);
							}
							else
							{
								arg_8FB_0 = true;
							}
							if (!arg_8FB_0)
							{
								this.StackOverlayChroma.Visibility = Visibility.Visible;
								this.objTemplateList[num].IsChecked = true;
								this.objTemplateList[num].CheckedBoxVisible = Visibility.Visible;
								string bsPath = LoginUser.DigiFolderVideoOverlayPath + System.IO.Path.GetFileName(this.objTemplateList[num].Name);
								MItem mItem;
								this.m_pMixerStreams.StreamsAdd(this.strOverlayStream, null, bsPath, "loop=false", out mItem, 0.0);
								string empty = string.Empty;
								if (string.IsNullOrEmpty(this.strOverlayStream))
								{
									int num2;
									this.m_pMixerStreams.StreamsGetCount(out num2);
									this.m_pMixerStreams.StreamsGetByIndex(num2 - 1, out empty, out mItem);
									this.strOverlayStream = empty;
								}
								this.OverlayElement.ElementMultipleSet("stream_id=" + this.strOverlayStream + " audio_gain=-100 show=true h=1 w=1 x=0 y=0", 0.0);
								this.OverlayElement.ElementReorder(500);
							}
							else if (this.objTemplateList[num].MediaType == 609)
							{
								this.objTemplateList[num].IsChecked = false;
							}
							num++;
						}
						IL_A3F:
						flag2 = (num < this.objTemplateList.Count);
						goto IL_A4F;
					}
					num = 0;
					int expr_21F;
					int expr_225;
					while (true)
					{
						int arg_1B4_0;
						int arg_1B4_1;
						if (num >= this.objTemplateList.Count)
						{
							expr_21F = (arg_1B4_0 = this.objTemplateList.Where(delegate(TemplateListItems o)
							{
								bool result;
								while (8 != 0)
								{
									bool arg_3A_0;
									if (o.MediaType == 605)
									{
										arg_3A_0 = o.IsChecked;
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
										arg_3A_0 = false;
									}
									result = arg_3A_0;
									break;
								}
								return result;
							}).ToList<TemplateListItems>().Count);
							expr_225 = (arg_1B4_1 = 0);
							if (expr_225 == 0)
							{
								break;
							}
							goto IL_1B4;
						}
						else
						{
							bool arg_11C_0;
							if (this.objTemplateList[num].MediaType == 605 && this.objTemplateList[num].Item_ID == (long)id)
							{
								isChecked = checkBox.IsChecked;
								arg_11C_0 = !(isChecked == true);
							}
							else
							{
								arg_11C_0 = true;
							}
							if (arg_11C_0)
							{
								arg_1B4_0 = this.objTemplateList[num].MediaType;
								arg_1B4_1 = 605;
								goto IL_1B4;
							}
							this.objTemplateList[num].IsChecked = true;
							this.objTemplateList[num].CheckedBoxVisible = Visibility.Visible;
							VideoEditor.vsMediaFileName = System.IO.Path.Combine(LoginUser.DigiFolderVideoBackGroundPath, System.IO.Path.GetFileName(this.objTemplateList[num].Name));
							MItem mItem2;
							this.m_objMixer.StreamsBackgroundSet(null, VideoEditor.vsMediaFileName, "", out mItem2, 0.0);
							Thread.Sleep(1000);
						}
						IL_1D4:
						num++;
						continue;
						IL_1B4:
						if (arg_1B4_0 == arg_1B4_1)
						{
							this.objTemplateList[num].IsChecked = false;
							goto IL_1D4;
						}
						goto IL_1D4;
					}
					if (expr_21F == expr_225)
					{
						MItem mItem2;
						this.m_objMixer.StreamsBackgroundSet(null, null, "", out mItem2, 0.0);
						Thread.Sleep(1000);
					}
					itemsSource = (from o in this.objTemplateList
					where o.MediaType == 605
					select o).ToList<TemplateListItems>();
					if (8 != 0)
					{
						break;
					}
					goto IL_533;
					IL_58:
					goto IL_5B;
				}
				this.lstTemplates.ItemsSource = itemsSource;
				Block_33:
				goto IL_D55;
				Block_34:
				int num3 = this.CalculateProcessedVideoLength();
				this.txtVideoLength.Text = "Expected video length : " + num3.ToString() + " sec";
				templateListItems = this.objTemplateList.Where(delegate(TemplateListItems o)
				{
					if (o.MediaType == 604)
					{
						goto IL_0B;
					}
					goto IL_1E;
					IL_1F:
					while (false)
					{
					}
					bool arg_47_0;
					bool flag3 = arg_47_0;
					bool arg_2F_0;
					if (8 != 0)
					{
						if (!false)
						{
							arg_2F_0 = flag3;
							return arg_2F_0;
						}
						goto IL_1E;
					}
					IL_0B:
					arg_47_0 = (arg_2F_0 = (o.Item_ID == (long)f.id));
					if (true)
					{
						goto IL_1F;
					}
					return arg_2F_0;
					IL_1E:
					arg_47_0 = false;
					goto IL_1F;
				}).FirstOrDefault<TemplateListItems>();
				bool arg_60D_0;
				if (templateListItems != null)
				{
					isChecked = checkBox.IsChecked;
					arg_60D_0 = !(isChecked == true);
				}
				else
				{
					arg_60D_0 = true;
				}
				if (!arg_60D_0)
				{
					templateListItems.IsChecked = true;
					templateListItems.CheckedBoxVisible = Visibility.Visible;
					this.StackAudioStartEndTime.Visibility = Visibility.Visible;
					this.StackGraphicSettingPanel1.Visibility = Visibility.Collapsed;
					this.StackGraphicSettingPanel2.Visibility = Visibility.Collapsed;
					this.txtAudioStart.Text = templateListItems.StartTime.ToString();
					this.txtAudioEnd.Text = templateListItems.EndTime.ToString();
					this.txtAudioInsert.Text = templateListItems.InsertTime.ToString();
					this.txtAudioId.Text = f.id.ToString();
					this.lstTemplates.SelectedItem = templateListItems;
					this.RangeSliderAudio.LowerValue = (double)templateListItems.StartTime;
					this.RangeSliderAudio.UpperValue = (double)templateListItems.EndTime;
					this.RangeSliderAudio.Maximum = (double)templateListItems.Length;
				}
				else if (templateListItems.MediaType == 604)
				{
					templateListItems.IsChecked = false;
					this.StackAudioStartEndTime.Visibility = Visibility.Collapsed;
					this.lstTemplates.SelectedItem = null;
				}
				itemsSource = (from o in this.objTemplateList
				where o.MediaType == 604
				select o).ToList<TemplateListItems>();
				this.lstTemplates.ItemsSource = itemsSource;
				goto IL_D55;
				Block_47:
				itemsSource = (from o in this.objTemplateList
				where o.MediaType == 606
				select o).ToList<TemplateListItems>();
				this.lstTemplates.ItemsSource = itemsSource;
				goto IL_D55;
				Block_59:
				this.StackOverlayChroma.Visibility = Visibility.Collapsed;
				IL_AC5:
				itemsSource = (from o in this.objTemplateList
				where o.MediaType == 609
				select o).ToList<TemplateListItems>();
				this.lstTemplates.ItemsSource = itemsSource;
				goto IL_D55;
				IL_D15:
				itemsSource = (from o in this.objTemplateList
				where o.MediaType == 608
				select o).ToList<TemplateListItems>();
				this.lstTemplates.ItemsSource = itemsSource;
				IL_D55:
				goto IL_DA7;
				IL_D59:
				checkBox = (sender as System.Windows.Controls.CheckBox);
				isChecked = checkBox.IsChecked;
				if (isChecked == true)
				{
					checkBox.IsChecked = new bool?(false);
				}
				else
				{
					checkBox.IsChecked = new bool?(true);
				}
				IL_DA7:;
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.LogFileWrite(message);
			}
		}

        private void DisableControls()
        {
            UIElement expr_06 = this.btnVideo;
            bool expr_0B = false;
            if (!false)
            {
                expr_06.IsEnabled = expr_0B;
            }
            if (4 == 0)
            {
                goto IL_D3;
            }
            this.btnChroma.IsEnabled = false;
        IL_2B:
            if (7 == 0)
            {
                goto IL_8C;
            }
            this.btnSave.IsEnabled = false;
            this.btnIncludeAll.IsEnabled = false;
            this.btnProcess.IsEnabled = false;
        IL_62:
            this.btnReset.IsEnabled = false;
            this.grdChromaControls.IsEnabled = false;
            if (false)
            {
                goto IL_2B;
            }
            this.grdVideoControls.IsEnabled = false;
        IL_8C:
            this.lstGuestImages.IsEnabled = false;
            if (!false)
            {
            }
            this.lstDragImages.IsEnabled = false;
            this.lstTemplates.IsEnabled = false;
            this.btnExit.IsEnabled = false;
            if (!false)
            {
            }
            this.btnStopProcess.IsEnabled = true;
        IL_D3:
            if (true)
            {
                this.btnDefaultSettings.IsEnabled = false;
                return;
            }
            goto IL_62;
        }

        private void EnableControls()
        {
            this.btnVideo.IsEnabled = true;
            do
            {
                this.btnChroma.IsEnabled = true;
                this.btnSave.IsEnabled = true;
                this.btnIncludeAll.IsEnabled = true;
                this.btnProcess.IsEnabled = true;
            }
            while (false);
            if (false)
            {
                goto IL_103;
            }
            this.btnReset.IsEnabled = true;
            this.grdChromaControls.IsEnabled = true;
        IL_78:
            if (false)
            {
                goto IL_13D;
            }
            this.grdVideoControls.IsEnabled = true;
            this.lstGuestImages.IsEnabled = true;
        IL_98:
            this.lstDragImages.IsEnabled = true;
            this.lstTemplates.IsEnabled = true;
            int arg_EE_0;
            int expr_E2 = arg_EE_0 = this.objTemplateList.Where(delegate(TemplateListItems o)
            {
                int arg_09_0 = o.MediaType;
                int arg_52_0;
                while (true)
                {
                    int arg_1E_0;
                    if (arg_09_0 != 602)
                    {
                        do
                        {
                            int expr_41 = arg_1E_0 = o.MediaType;
                            if (false)
                            {
                                goto IL_1D;
                            }
                            if (expr_41 == 607)
                            {
                                goto IL_19;
                            }
                        }
                        while (false);
                        arg_52_0 = (arg_09_0 = 0);
                        goto IL_29;
                    }
                    goto IL_19;
                    do
                    {
                    IL_1D:
                        arg_1E_0 = (arg_09_0 = (arg_52_0 = ((arg_1E_0 == 0) ? 1 : 0)));
                    }
                    while (false);
                IL_29:
                    if (!false)
                    {
                        break;
                    }
                    continue;
                IL_19:
                    arg_1E_0 = (o.isActive ? 1 : 0);
                    goto IL_1D;
                }
                return arg_52_0 != 0;
            }).ToList<TemplateListItems>().Count;
            int arg_EE_1;
            int expr_E8 = arg_EE_1 = 0;
            if (expr_E8 == 0)
            {
                arg_EE_0 = ((expr_E2 > expr_E8) ? 1 : 0);
                arg_EE_1 = 0;
            }
            if (arg_EE_0 != arg_EE_1)
            {
                this.lstTemplates.IsEnabled = false;
            }
            else
            {
                this.lstTemplates.IsEnabled = true;
                if (6 == 0)
                {
                    goto IL_13D;
                }
            }
        IL_103:
            this.btnExit.IsEnabled = true;
            this.btnDefaultSettings.IsEnabled = true;
            this.btnStopProcess.IsEnabled = false;
        IL_13D:
            if (6 == 0)
            {
                goto IL_98;
            }
            if (6 != 0)
            {
                this.VideoEditPlayerPanel.IsEnabled = true;
                return;
            }
            goto IL_78;
        }

        private void btnSetVideoTime_Click(object sender, RoutedEventArgs e)
        {
            VideoPage videoPage = this.PrintOrderPageList.Where(delegate(VideoPage o)
            {
                int arg_0B_0 = o.PhotoId;
                int arg_0B_1 = this.DropPhotoId;
                bool arg_30_0;
                bool flag2;
                while (true)
                {
                    bool arg_4B_0;
                    if (arg_0B_0 != arg_0B_1)
                    {
                        arg_4B_0 = false;
                        goto IL_26;
                    }
                IL_0D:
                    if (-1 == 0)
                    {
                        break;
                    }
                    int expr_41 = arg_0B_0 = o.PageNo;
                    int expr_16 = arg_0B_1 = this.activePage;
                    if (2 == 0)
                    {
                        continue;
                    }
                    arg_4B_0 = (arg_30_0 = (expr_41 == expr_16));
                    if (!true)
                    {
                        return arg_30_0;
                    }
                IL_26:
                    flag2 = arg_4B_0;
                    if (8 != 0)
                    {
                        break;
                    }
                    goto IL_0D;
                }
                arg_30_0 = flag2;
                return arg_30_0;
            }).FirstOrDefault<VideoPage>();
            while (videoPage != null)
            {
                if (string.IsNullOrEmpty(this.txtvideoStart.Text))
                {
                    goto IL_A1;
                }
                bool arg_7E_0;
                bool expr_5F = arg_7E_0 = string.IsNullOrEmpty(this.txtVideoEnd.Text);
                if (!false)
                {
                    if (expr_5F)
                    {
                        goto IL_A1;
                    }
                    arg_7E_0 = this.txtvideoStart.Text.Contains(".");
                }
                if (!arg_7E_0)
                {
                    goto IL_80;
                }
                int arg_A3_0;
                bool arg_120_0 = (arg_A3_0 = 1) != 0;
                goto IL_98;
            IL_B0:
                if (2 == 0)
                {
                    goto IL_15F;
                }
                if ((long)Convert.ToInt32(this.txtvideoStart.Text) >= videoPage.videoLength || (long)Convert.ToInt32(this.txtVideoEnd.Text) > videoPage.videoLength)
                {
                    System.Windows.MessageBox.Show("Video Start/End time cannot be greater than video length.", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                    goto IL_198;
                }
                if (!false)
                {
                    arg_120_0 = (Convert.ToInt32(this.txtvideoStart.Text) >= Convert.ToInt32(this.txtVideoEnd.Text));
                    goto IL_120;
                }
                continue;
            IL_A2:
                bool flag = arg_A3_0 != 0;
                if (!false)
                {
                    if (!flag)
                    {
                        goto IL_B0;
                    }
                }
                System.Windows.MessageBox.Show("Video Start/End time has some invalid data!.", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                goto IL_1B1;
            IL_98:
                if (!false)
                {
                    goto IL_A2;
                }
                goto IL_120;
            IL_80:
                arg_120_0 = ((arg_A3_0 = (this.txtVideoEnd.Text.Contains(".") ? 1 : 0)) != 0);
                goto IL_98;
            IL_179:
                if (!false)
                {
                    goto IL_198;
                }
                goto IL_B0;
            IL_120:
                if (!arg_120_0)
                {
                    videoPage.videoStartTime = Convert.ToInt32(this.txtvideoStart.Text);
                    videoPage.videoEndTime = Convert.ToInt32(this.txtVideoEnd.Text);
                    this.StackVideoStartEndTime.Visibility = Visibility.Collapsed;
                }
                else
                {
                    System.Windows.MessageBox.Show("Video start time should be less than video end time!", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                }
            IL_15F:
                goto IL_179;
            IL_A1:
                arg_A3_0 = 1;
                goto IL_A2;
            IL_1B1:
                if (2 != 0)
                {
                    break;
                }
                goto IL_80;
            IL_198:
                goto IL_1B1;
            }
        }

        private bool validateAudio()
        {
            return true;
        }

        private void btnchkpreview_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                this.PreviewVideo();
            }
            while (true)
            {
                if (false)
                {
                    goto IL_20;
                }
                bool arg_22_0;
                bool expr_16 = arg_22_0 = (this.gdMediaPlayer.Visibility == Visibility.Visible);
                bool flag;
                if (!false)
                {
                    flag = !expr_16;
                    goto IL_20;
                }
            IL_22:
                if (!arg_22_0)
                {
                    this.MediaPlay();
                }
                if (!false)
                {
                    break;
                }
                continue;
            IL_20:
                arg_22_0 = flag;
                goto IL_22;
            }
        }

        private void PreviewVideo()
        {
            if (3 != 0)
            {
            }
            if (!this.btnchkpreview.IsChecked.Value)
            {
                if (!false)
                {
                    this.CompileEffectChanged(null, -1);
                    goto IL_4F;
                }
                goto IL_33;
            }
        IL_1D:
            if (false)
            {
                goto IL_4F;
            }
            VisualBrush compiledBitmapImage = new VisualBrush();
            compiledBitmapImage = new VisualBrush(this.grdMain);
        IL_33:
            if (!false)
            {
                this.CompileEffectChanged(compiledBitmapImage, -1);
            }
        IL_4F:
            if (2 != 0)
            {
                return;
            }
            goto IL_1D;
        }

        public void CompileEffectChanged(VisualBrush compiledBitmapImage, int ProductType)
        {
            try
            {
                ClientView expr_02 = null;
                ClientView clientView;
                if (!false)
                {
                    clientView = expr_02;
                }
                using (IEnumerator enumerator = System.Windows.Application.Current.Windows.GetEnumerator())
                {
                    while (true)
                    {
                    IL_56:
                        bool flag = enumerator.MoveNext();
                        while (flag)
                        {
                            if (!false)
                            {
                                Window expr_28 = (Window)enumerator.Current;
                                Window window;
                                if (8 != 0)
                                {
                                    window = expr_28;
                                }
                                if (window.Title == "ClientView")
                                {
                                    clientView = (ClientView)window;
                                }
                                goto IL_56;
                            }
                        }
                        break;
                    }
                }
                if (clientView != null)
                {
                    goto IL_B4;
                }
                if (false)
                {
                    goto IL_113;
                }
                clientView = new ClientView();
            IL_AB:
                clientView.WindowStartupLocation = WindowStartupLocation.Manual;
            IL_B4:
                clientView.GroupView = false;
                if (false)
                {
                    goto IL_120;
                }
                if (7 == 0)
                {
                    goto IL_AB;
                }
                clientView.DefaultView = false;
                if (compiledBitmapImage != null)
                {
                    clientView.testR.Fill = null;
                    compiledBitmapImage.Stretch = Stretch.Uniform;
                    clientView.imgDefault.Visibility = Visibility.Collapsed;
                    clientView.testR.Fill = compiledBitmapImage;
                    goto IL_12E;
                }
                clientView.DefaultView = true;
                if (false)
                {
                    goto IL_146;
                }
            IL_113:
                clientView.imgDefault.Visibility = Visibility.Visible;
            IL_120:
                clientView.testR.Fill = null;
            IL_12E:
                Screen[] allScreens = Screen.AllScreens;
                int arg_13E_0;
                int expr_136 = arg_13E_0 = allScreens.Length;
                if (2 != 0)
                {
                    arg_13E_0 = ((expr_136 > 1) ? 1 : 0);
                }
                if (arg_13E_0 == 0)
                {
                    goto IL_1C5;
                }
            IL_146:
                if (allScreens[0].Primary)
                {
                    Screen screen = Screen.AllScreens[1];
                    System.Drawing.Rectangle workingArea = screen.WorkingArea;
                    clientView.Top = (double)workingArea.Top;
                    clientView.Left = (double)workingArea.Left;
                    clientView.Show();
                }
                else
                {
                    System.Drawing.Rectangle workingArea = allScreens[0].WorkingArea;
                    clientView.Top = (double)workingArea.Top;
                    clientView.Left = (double)workingArea.Left;
                    clientView.Show();
                }
                goto IL_1CE;
            IL_1C5:
                clientView.Show();
            IL_1CE:
                if (false)
                {
                    goto IL_1C5;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
            finally
            {
                MemoryManagement.FlushMemory();
            }
        }

        private void btnSetAudioTime_Click(object sender, RoutedEventArgs e)
        {
            int audioId = Convert.ToInt32(this.txtAudioId.Text);
            TemplateListItems templateListItems = this.objTemplateList.Where(delegate(TemplateListItems o)
            {
                if (o.Item_ID == (long)audioId)
                {
                    goto IL_0E;
                }
                goto IL_1E;
            IL_1F:
                while (false)
                {
                }
                bool arg_47_0;
                bool flag = arg_47_0;
                bool arg_2F_0;
                if (8 != 0)
                {
                    if (!false)
                    {
                        arg_2F_0 = flag;
                        return arg_2F_0;
                    }
                    goto IL_1E;
                }
            IL_0E:
                arg_47_0 = (arg_2F_0 = (o.MediaType == 604));
                if (true)
                {
                    goto IL_1F;
                }
                return arg_2F_0;
            IL_1E:
                arg_47_0 = false;
                goto IL_1F;
            }).FirstOrDefault<TemplateListItems>();
            if (templateListItems != null)
            {
                if (this.validateAudio())
                {
                    if ((long)Convert.ToInt32(this.txtAudioStart.Text) < templateListItems.Length && (long)Convert.ToInt32(this.txtAudioEnd.Text) <= templateListItems.Length)
                    {
                        if (Convert.ToInt32(this.txtAudioStart.Text) < Convert.ToInt32(this.txtAudioEnd.Text))
                        {
                            templateListItems.StartTime = Convert.ToInt32(this.txtAudioStart.Text);
                            templateListItems.EndTime = Convert.ToInt32(this.txtAudioEnd.Text);
                            templateListItems.InsertTime = Convert.ToInt32(this.txtAudioInsert.Text);
                            this.StackAudioStartEndTime.Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            System.Windows.MessageBox.Show("Audio start time must be less then audio end time!", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Audio Start/End time can not exceed the audio length.", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Exclamation, MessageBoxResult.OK);
                    }
                }
            }
        }

        private bool IsDoubleTap(TouchEventArgs e)
        {
            System.Windows.Point position = e.GetTouchPoint(this).Position;
            bool flag = VideoEditor.GetDistanceBetweenPoints(position, this._lastTapLocation) < 40.0;
            this._lastTapLocation = position;
            TimeSpan elapsed = this._doubleTapStopwatch.Elapsed;
            this._doubleTapStopwatch.Restart();
            bool arg_85_0;
            if (elapsed != TimeSpan.Zero)
            {
                arg_85_0 = (elapsed < TimeSpan.FromSeconds(0.7));
            }
            else
            {
                arg_85_0 = false;
            }
        IL_7E:
            if (3 != 0)
            {
                bool flag2 = arg_85_0;
                bool result;
                do
                {
                    result = (flag && flag2);
                }
                while (4 == 0);
                return result;
            }
            goto IL_7E;
        }

        public static double GetDistanceBetweenPoints(System.Windows.Point p, System.Windows.Point q)
        {
            double result;
            if (!false)
            {
                do
                {
                    double arg_4A_0 = p.X - q.X;
                    double expr_26;
                    while (true)
                    {
                        double num = arg_4A_0;
                        double arg_5B_0 = p.Y - q.Y;
                        while (true)
                        {
                            double num2 = arg_5B_0;
                            double expr_5E = arg_4A_0 = num;
                            if (7 == 0)
                            {
                                break;
                            }
                            expr_26 = (arg_5B_0 = expr_5E * num + num2 * num2);
                            if (!false)
                            {
                                goto Block_2;
                            }
                        }
                    }
                Block_2:
                    double num3 = Math.Sqrt(expr_26);
                    if (2 != 0)
                    {
                        result = num3;
                    }
                }
                while (3 == 0);
            }
            return result;
        }

        private void btnPlayVideoTemp_Click(object sender, RoutedEventArgs e)
		{
			if (!false)
			{
			}
			videoid = 0;
			if (!string.IsNullOrEmpty(this.txtSelVideoTemp.Text.Trim()))
			{
				videoid = Convert.ToInt32(this.txtSelVideoTemp.Text);
			}
			TemplateListItems templateListItems = this.objTemplateList.Where(delegate(TemplateListItems o)
			{
				if (o.Item_ID == (long)videoid)
				{
					goto IL_0E;
				}
				goto IL_1E;
				IL_1F:
				while (false)
				{
				}
				bool arg_47_0;
				bool flag = arg_47_0;
				bool arg_2F_0;
				if (8 != 0)
				{
					if (!false)
					{
						arg_2F_0 = flag;
						return arg_2F_0;
					}
					goto IL_1E;
				}
				IL_0E:
				arg_47_0 = (arg_2F_0 = (o.MediaType == 603));
				if (true)
				{
					goto IL_1F;
				}
				return arg_2F_0;
				IL_1E:
				arg_47_0 = false;
				goto IL_1F;
			}).FirstOrDefault<TemplateListItems>();
			if (templateListItems != null)
			{
				string text = LoginUser.DigiFolderVideoTemplatePath + System.IO.Path.GetFileName(templateListItems.Name);
				VideoEditor.vsMediaFileName = text;
				this.MediaPlay();
			}
		}

        private void btnPlayAudio_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void btnPlayVideoTemp_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void btnImgPlay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDropImgPlay_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void btnDefaultSettings_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                if (false)
                {
                    return;
                }
                try
                {
                    this.btnClosePreview_Click(sender, e);
                    this.LoadDefaultSceneAndFile();
                    while (8 != 0)
                    {
                        this.BindGuestNodeProps();
                        if (5 != 0)
                        {
                            this.applyDefaultSettings();
                            this.CurrentchromaSetting = string.Empty;
                            this.overlayChromaSetting = string.Empty;
                            this.IsLoadChroma = false;
                            this.IsLoadOverlayChroma = false;
                            MItem mItem;
                            this.m_objMixer.StreamsBackgroundSet(null, null, "", out mItem, 0.0);
                        IL_8B:
                            break;
                        }
                    }
                    this.OverlayElement.ElementMultipleSet("show=false", 0.0);
                    Thread.Sleep(1000);
                    this.rbNone.IsChecked = new bool?(true);
                    this.rbColorEffect_Click(this.rbNone, null);
                    if (false)
                    {
                        goto IL_8B;
                    }
                }
                catch
                {
                }
            }
            if (6 != 0)
            {
            }
        }

        private void applyDefaultSettings()
        {
            (from o in this.objTemplateList
             where o.IsChecked
             select o).ToList<TemplateListItems>().ForEach(delegate(TemplateListItems t)
             {
                 t.IsChecked = false;
             });
            bool expr_6E = !this.templateType.Equals("graphics");
            bool flag;
            if (!false)
            {
                flag = expr_6E;
            }
            if (!flag)
            {
                if (false)
                {
                    goto IL_262;
                }
                List<TemplateListItems> itemsSource = (from o in this.objTemplateList
                                                       where o.MediaType == 606
                                                       select o).ToList<TemplateListItems>();
                this.lstTemplates.ItemsSource = null;
                this.lstTemplates.ItemsSource = itemsSource;
            }
            flag = !this.templateType.Equals("audio");
            if (!flag)
            {
                List<TemplateListItems> itemsSource = (from o in this.objTemplateList
                                                       where o.MediaType == 604
                                                       select o).ToList<TemplateListItems>();
                this.lstTemplates.ItemsSource = null;
                this.lstTemplates.ItemsSource = itemsSource;
            }
            flag = !this.templateType.Equals("video");
            if (!flag)
            {
                List<TemplateListItems> itemsSource = (from o in this.objTemplateList
                                                       where o.MediaType == 603
                                                       select o).ToList<TemplateListItems>();
                this.lstTemplates.ItemsSource = null;
                this.lstTemplates.ItemsSource = itemsSource;
            }
            flag = !this.templateType.Equals("chroma");
            if (!flag)
            {
                List<TemplateListItems> itemsSource = (from o in this.objTemplateList
                                                       where o.MediaType == 605
                                                       select o).ToList<TemplateListItems>();
                this.lstTemplates.ItemsSource = null;
                this.lstTemplates.ItemsSource = itemsSource;
            }
            flag = !this.templateType.Equals("border");
            while (!flag)
            {
                List<TemplateListItems> itemsSource = (from o in this.objTemplateList
                                                       where o.MediaType == 608
                                                       select o).ToList<TemplateListItems>();
                this.lstTemplates.ItemsSource = null;
                this.lstTemplates.ItemsSource = itemsSource;
                if (!false)
                {
                    break;
                }
            }
        IL_262:
            flag = !this.templateType.Equals("overlay");
            if (!flag)
            {
                List<TemplateListItems> itemsSource = (from o in this.objTemplateList
                                                       where o.MediaType == 609
                                                       select o).ToList<TemplateListItems>();
                this.lstTemplates.ItemsSource = null;
                this.lstTemplates.ItemsSource = itemsSource;
            }
        }

        private void BindGuestTemplateList(VideoElements lstMyItem, bool addTemplate)
        {
            if (true)
            {
                if (addTemplate)
                {
                    TemplateListItems templateListItems = new TemplateListItems();
                    do
                    {
                        templateListItems.isActive = false;
                        do
                        {
                            templateListItems.FilePath = "/DigiPhoto;component/images/vidico.png";
                            templateListItems.Item_ID = (long)lstMyItem.PhotoId;
                            templateListItems.IsChecked = true;
                            templateListItems.DisplayName = lstMyItem.Name;
                        }
                        while (false);
                        templateListItems.MediaType = ((lstMyItem.MediaType == 2) ? 602 : 607);
                        if (!false)
                        {
                            templateListItems.Name = lstMyItem.Name;
                        }
                    }
                    while (6 == 0);
                    templateListItems.Length = lstMyItem.videoLength;
                    templateListItems.GuestVideoPath = lstMyItem.VideoFilePath;
                    this.objTemplateList.Add(templateListItems);
                    this.lstTemplates.IsEnabled = false;
                }
                else if (!false)
                {
                    TemplateListItems templateListItems = this.objTemplateList.Where(delegate(TemplateListItems o)
                    {
                        int arg_09_0 = o.MediaType;
                        int arg_52_0;
                        while (true)
                        {
                            int arg_1E_0;
                            if (arg_09_0 != 602)
                            {
                                do
                                {
                                    int expr_41 = arg_1E_0 = o.MediaType;
                                    if (false)
                                    {
                                        goto IL_1D;
                                    }
                                    if (expr_41 == 607)
                                    {
                                        goto IL_19;
                                    }
                                }
                                while (false);
                                arg_52_0 = (arg_09_0 = 0);
                                goto IL_29;
                            }
                            goto IL_19;
                            do
                            {
                            IL_1D:
                                arg_1E_0 = (arg_09_0 = (arg_52_0 = ((arg_1E_0 == 0) ? 1 : 0)));
                            }
                            while (false);
                        IL_29:
                            if (!false)
                            {
                                break;
                            }
                            continue;
                        IL_19:
                            arg_1E_0 = (o.isActive ? 1 : 0);
                            goto IL_1D;
                        }
                        return arg_52_0 != 0;
                    }).FirstOrDefault<TemplateListItems>();
                    this.objTemplateList.Remove(templateListItems);
                    return;
                }
                if (!false)
                {
                }
            }
        }

        public void LoadGuestVideoSlots()
        {
            while (true)
            {
                if (this.slotList.Count <= 0)
                {
                    this.markImage.Source = new BitmapImage(new Uri("/DigiPhoto;component/images/MarkT1.png", UriKind.Relative));
                    goto IL_108;
                }
                this.markImage.Source = new BitmapImage(new Uri("/DigiPhoto;component/images/UnMarkT1.png", UriKind.Relative));
            IL_4C:
                this.btnGuestVideoTemplate.Tag = 0;
                this.isVideoTempSelected = true;
                this.PrintOrderPageList.Clear();
                this.defaultProcessListCount = this.slotList.Count;
                this.BindPageStrips();
                if (7 != 0)
                {
                    VideoElements videoElements = this.lstVideoElements.Where(delegate(VideoElements o)
                    {
                        int arg_0E_0 = o.PhotoId;
                        int arg_0E_1 = this.DropPhotoId;
                        bool arg_33_0;
                        bool flag;
                        while (true)
                        {
                            bool arg_47_0;
                            if (arg_0E_0 != arg_0E_1)
                            {
                                arg_47_0 = false;
                                goto IL_29;
                            }
                        IL_10:
                            if (-1 == 0)
                            {
                                break;
                            }
                            int expr_3D = arg_0E_0 = o.PageNo;
                            int expr_19 = arg_0E_1 = this.activePage;
                            if (2 == 0)
                            {
                                continue;
                            }
                            arg_47_0 = (arg_33_0 = (expr_3D == expr_19));
                            if (!true)
                            {
                                return arg_33_0;
                            }
                        IL_29:
                            flag = arg_47_0;
                            if (8 != 0)
                            {
                                break;
                            }
                            goto IL_10;
                        }
                        arg_33_0 = flag;
                        return arg_33_0;
                    }).FirstOrDefault<VideoElements>();
                    videoElements.isVideoTemplate = Visibility.Visible;
                    this.lstGuestImages.ItemsSource = null;
                    if (false)
                    {
                        continue;
                    }
                    this.lstGuestImages.ItemsSource = this.lstVideoElements;
                    this.BindGuestTemplateList(videoElements, true);
                }
            IL_11C:
                if (false)
                {
                    goto IL_108;
                }
                if (2 != 0)
                {
                    break;
                }
                goto IL_4C;
            IL_11B:
                goto IL_11C;
            IL_108:
                this.btnGuestVideoTemplate.Tag = 1;
                goto IL_11B;
            }
        }

        private void btnHide_Click(object sender, RoutedEventArgs e)
        {
            SearchResult searchResult = new SearchResult();
            int arg_15_0 = RobotImageLoader.GroupImages.Count;
            bool arg_F9_0;
            do
            {
                arg_F9_0 = (((arg_15_0 != 0) ? (arg_15_0 = 1) : (arg_15_0 = ((!(this.IsGoupped == "View All")) ? 1 : 0))) != 0);
            }
            while (!true);
            if (!arg_F9_0)
            {
                this.IsGoupped = "View Group";
            }
        IL_51:
            searchResult.pagename = "Saveback";
            int arg_6C_0 = RobotImageLoader.PrintImages.Count;
            int arg_6C_1 = 0;
            bool arg_77_0;
            int expr_6C;
            int expr_72;
            do
            {
                expr_6C = (arg_6C_0 = ((arg_77_0 = (arg_6C_0 > arg_6C_1)) ? 1 : 0));
                if (false)
                {
                    goto IL_77;
                }
                expr_72 = (arg_6C_1 = 0);
            }
            while (expr_72 != 0);
            arg_77_0 = (expr_6C == expr_72);
        IL_77:
            if (!arg_77_0)
            {
                if (2 != 0)
                {
                    searchResult.Savebackpid = Convert.ToString(RobotImageLoader.PrintImages[RobotImageLoader.PrintImages.Count - 1].PhotoId);
                    goto IL_B6;
                }
            }
            else
            {
                if (!false)
                {
                    searchResult.Savebackpid = "0";
                    goto IL_B6;
                }
                goto IL_51;
            }
            do
            {
            IL_BC:
                searchResult.LoadWindow();
            }
            while (false);
            base.Hide();
            return;
        IL_B6:
            searchResult.Show();
            goto IL_BC;
        }

        private void extractBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        protected void FrameBox_ExecuteMethod(object sender, EventArgs e)
        {
            this.txtvideoStart.Text = this.FrameBox.txtvideoStart.Text;
            this.txtVideoEnd.Text = this.FrameBox.txtVideoEnd.Text;
            VideoPage videoPage = this.PrintOrderPageList.Where(delegate(VideoPage o)
            {
                int arg_0B_0 = o.PhotoId;
                int arg_0B_1 = this.DropPhotoId;
                bool arg_30_0;
                bool flag2;
                while (true)
                {
                    bool arg_4B_0;
                    if (arg_0B_0 != arg_0B_1)
                    {
                        arg_4B_0 = false;
                        goto IL_26;
                    }
                IL_0D:
                    if (-1 == 0)
                    {
                        break;
                    }
                    int expr_41 = arg_0B_0 = o.PageNo;
                    int expr_16 = arg_0B_1 = this.activePage;
                    if (2 == 0)
                    {
                        continue;
                    }
                    arg_4B_0 = (arg_30_0 = (expr_41 == expr_16));
                    if (!true)
                    {
                        return arg_30_0;
                    }
                IL_26:
                    flag2 = arg_4B_0;
                    if (8 != 0)
                    {
                        break;
                    }
                    goto IL_0D;
                }
                arg_30_0 = flag2;
                return arg_30_0;
            }).FirstOrDefault<VideoPage>();
            bool arg_6E_0 = videoPage == null;
            while (!arg_6E_0)
            {
                if (!string.IsNullOrEmpty(this.txtvideoStart.Text) && !string.IsNullOrEmpty(this.txtVideoEnd.Text) && !this.txtvideoStart.Text.Contains(".") && !this.txtVideoEnd.Text.Contains("."))
                {
                    long arg_F0_0;
                    long arg_10C_0 = arg_F0_0 = (long)Convert.ToInt32(this.txtvideoStart.Text);
                    long arg_10C_1;
                    while (true)
                    {
                        long expr_E8 = arg_10C_1 = videoPage.videoLength;
                        if (false)
                        {
                            goto IL_10C;
                        }
                        if (arg_F0_0 >= expr_E8)
                        {
                            goto IL_110;
                        }
                        arg_10C_0 = (arg_F0_0 = (long)Convert.ToInt32(this.txtVideoEnd.Text));
                        if (8 != 0)
                        {
                            goto Block_8;
                        }
                    }
                IL_111:
                    bool arg_112_0;
                    bool flag = arg_112_0;
                    bool expr_113 = arg_6E_0 = flag;
                    if (true)
                    {
                        if (!expr_113)
                        {
                            int arg_13D_0 = Convert.ToInt32(this.txtvideoStart.Text);
                            int arg_13D_1 = Convert.ToInt32(this.txtVideoEnd.Text);
                            int expr_13D;
                            int expr_140;
                            while (true)
                            {
                                expr_13D = (arg_13D_0 = ((arg_13D_0 < arg_13D_1) ? 1 : 0));
                                expr_140 = (arg_13D_1 = 0);
                                if (expr_140 == 0)
                                {
                                    arg_13D_1 = expr_140;
                                    if (expr_140 == 0)
                                    {
                                        break;
                                    }
                                }
                            }
                            if (expr_13D != expr_140)
                            {
                                videoPage.videoStartTime = Convert.ToInt32(this.txtvideoStart.Text);
                                videoPage.videoEndTime = Convert.ToInt32(this.txtVideoEnd.Text);
                            }
                            else
                            {
                                this.MsgBox.ShowHandlerDialog("Video start time should be less than video end time!", DigiMessageBox.DialogType.OK);
                            }
                        }
                        else
                        {
                            do
                            {
                                this.MsgBox.ShowHandlerDialog("Video Start/End time cannot be greater than video length.", DigiMessageBox.DialogType.OK);
                            }
                            while (false);
                        }
                        break;
                    }
                    continue;
                IL_10C:
                    arg_112_0 = (arg_10C_0 > arg_10C_1);
                    goto IL_111;
                IL_110:
                    arg_112_0 = true;
                    goto IL_111;
                Block_8:
                    arg_10C_1 = videoPage.videoLength;
                    goto IL_10C;
                }
                this.MsgBox.ShowHandlerDialog("Video Start/End time has some invalid data!.", DigiMessageBox.DialogType.OK);
                break;
            }
        }

        protected void LogoControlBox_ExecuteMethod(object sender, EventArgs e)
        {
        }

        private void btnGuestVideoTemplate_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = sender as System.Windows.Controls.Button;
            if (Convert.ToInt32(button.Tag) == 1)
            {
                this.objTemplateList.Where(delegate(TemplateListItems o)
                {
                    bool result;
                    if (4 != 0)
                    {
                        bool arg_3C_0;
                        if (!o.IsChecked)
                        {
                            arg_3C_0 = false;
                            goto IL_1D;
                        }
                        if (6 == 0)
                        {
                            return result;
                        }
                        arg_3C_0 = (o.MediaType == 603);
                    IL_17:
                        if (false)
                        {
                            goto IL_21;
                        }
                    IL_1D:
                        if (3 == 0)
                        {
                            goto IL_17;
                        }
                    IL_21:
                        result = arg_3C_0;
                    }
                    return result;
                }).ToList<TemplateListItems>().ForEach(delegate(TemplateListItems t)
                {
                    t.IsChecked = false;
                });
                List<TemplateListItems> itemsSource = (from o in this.objTemplateList
                                                       where o.MediaType == 603
                                                       select o).ToList<TemplateListItems>();
                this.lstTemplates.ItemsSource = null;
                this.lstTemplates.ItemsSource = itemsSource;
                this.slotList.Clear();
                VideoElements videoElements = this.lstVideoElements.Where(delegate(VideoElements o)
                {
                    int arg_0E_0 = o.PhotoId;
                    int arg_0E_1 = this.DropPhotoId;
                    bool arg_33_0;
                    bool flag;
                    while (true)
                    {
                        bool arg_47_0;
                        if (arg_0E_0 != arg_0E_1)
                        {
                            arg_47_0 = false;
                            goto IL_29;
                        }
                    IL_10:
                        if (-1 == 0)
                        {
                            break;
                        }
                        int expr_3D = arg_0E_0 = o.PageNo;
                        int expr_19 = arg_0E_1 = this.activePage;
                        if (2 == 0)
                        {
                            continue;
                        }
                        arg_47_0 = (arg_33_0 = (expr_3D == expr_19));
                        if (!true)
                        {
                            return arg_33_0;
                        }
                    IL_29:
                        flag = arg_47_0;
                        if (8 != 0)
                        {
                            break;
                        }
                        goto IL_10;
                    }
                    arg_33_0 = flag;
                    return arg_33_0;
                }).FirstOrDefault<VideoElements>();
                this.VideoSlotsTime.VideoLength = videoElements.videoLength;
                this.VideoSlotsTime.VideoName = videoElements.Name;
                this.VideoSlotsTime.isGuestVideoTemplate = true;
                this.VideoSlotsTime.SetParent(this);
                this.VideoSlotsTime.Visibility = Visibility.Visible;
                this.markImage.Source = new BitmapImage(new Uri("/images/UnMarkT1.png", UriKind.Relative));
                button.Tag = 0;
            }
            else
            {
                VideoElements videoElements = this.lstVideoElements.Where(delegate(VideoElements o)
                {
                    int arg_0E_0 = o.PhotoId;
                    int arg_0E_1 = this.DropPhotoId;
                    bool arg_33_0;
                    bool flag;
                    while (true)
                    {
                        bool arg_47_0;
                        if (arg_0E_0 != arg_0E_1)
                        {
                            arg_47_0 = false;
                            goto IL_29;
                        }
                    IL_10:
                        if (-1 == 0)
                        {
                            break;
                        }
                        int expr_3D = arg_0E_0 = o.PageNo;
                        int expr_19 = arg_0E_1 = this.activePage;
                        if (2 == 0)
                        {
                            continue;
                        }
                        arg_47_0 = (arg_33_0 = (expr_3D == expr_19));
                        if (!true)
                        {
                            return arg_33_0;
                        }
                    IL_29:
                        flag = arg_47_0;
                        if (8 != 0)
                        {
                            break;
                        }
                        goto IL_10;
                    }
                    arg_33_0 = flag;
                    return arg_33_0;
                }).FirstOrDefault<VideoElements>();
                if (this.isVideoTempSelected)
                {
                    button.Tag = 1;
                    if (!false)
                    {
                        this.markImage.Source = new BitmapImage(new Uri("/DigiPhoto;component/images/MarkT1.png", UriKind.Relative));
                        this.isVideoTempSelected = false;
                        this.defaultProcessListCount = 10;
                        this.PrintOrderPageList.Clear();
                        this.BindGuestTemplateList(videoElements, false);
                        this.BindPageStrips();
                        videoElements.isVideoTemplate = Visibility.Collapsed;
                    }
                    this.lstGuestImages.ItemsSource = null;
                    this.lstGuestImages.ItemsSource = this.lstVideoElements;
                    this.lstTemplates.IsEnabled = true;
                    this.slotList.Clear();
                }
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            this.UnsubscribeEvents();
        }

        private void UnsubscribeEvents()
        {
            this.btnCloseTempList.Click -= new RoutedEventHandler(this.btnCloseTempList_Click);
            this.btnCollapse.Click -= new RoutedEventHandler(this.btnCollapse_Click);
            while (true)
            {
                this.btnProcess.Click -= new RoutedEventHandler(this.btnProcess_Click);
                if (false)
                {
                    goto IL_160;
                }
                this.btnStopProcess.Click -= new RoutedEventHandler(this.btnStopProcess_Click);
                this.btnchkpreview.Click -= new RoutedEventHandler(this.btnchkpreview_Click);
                this.btnIncludeAll.Click -= new RoutedEventHandler(this.btnSelectAll_Click);
                while (true)
                {
                    this.btnReset.Click -= new RoutedEventHandler(this.btnReset_Click);
                    this.btnSave.Click -= new RoutedEventHandler(this.btnSave_Click);
                    if (false)
                    {
                        break;
                    }
                    this.btnExit.Click -= new RoutedEventHandler(this.btnExit_Click);
                    if (6 != 0)
                    {
                        goto Block_3;
                    }
                }
            }
        Block_3:
            this.btnDefaultSettings.Click -= new RoutedEventHandler(this.btnDefaultSettings_Click);
            this.btnHide.Click -= new RoutedEventHandler(this.btnHide_Click);
            this.btnVideo.Click -= new RoutedEventHandler(this.btnVideo_Click);
            this.btnAudioEffects.Click -= new RoutedEventHandler(this.btnAudio_Click);
        IL_160:
            this.btnChroma.Click -= new RoutedEventHandler(this.btnChroma_Click);
            this.mMixerList1.OnMixerSelChanged -= new EventHandler(this.mMixerList1_OnMixerSelChanged);
            this.VidTimer.Tick -= new EventHandler(this.VidTimer_Tick);
            this.mConfigList1.OnConfigChanged -= new EventHandler(this.mConfigList1_OnConfigChanged);
            this.bwSaveVideos.DoWork -= new DoWorkEventHandler(this.bwSaveVideos_DoWork);
            this.bwSaveVideos.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(this.bwSaveVideos_RunWorkerCompleted);
        }

        private void txtvideoStart_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void btnBorder_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                this.StackGraphicSettingPanel1.Visibility = Visibility.Collapsed;
            }
            while (3 == 0);
            this.StackGraphicSettingPanel2.Visibility = Visibility.Collapsed;
            this.SetTemplateListVisibility(true);
            if (!false)
            {
                try
                {
                    this.txtTemplateRotate.Visibility = Visibility.Visible;
                    this.templateType = "border";
                    while (true)
                    {
                    IL_59:
                        this.lstTemplates.IsEnabled = true;
                        List<TemplateListItems> list = (from o in this.objTemplateList
                                                        where o.MediaType == 608
                                                        select o).ToList<TemplateListItems>();
                        bool flag = list.Count != 0;
                        while (flag)
                        {
                            if (!false)
                            {
                            }
                            this.lstTemplates.ItemsSource = list;
                            if (4 != 0)
                            {
                            IL_CA:
                                this.txtTemplateRotate.Text = "Borders";
                                while (false)
                                {
                                }
                                if (!false)
                                {
                                    goto Block_6;
                                }
                                goto IL_59;
                            }
                        }
                        this.lstTemplates.ItemsSource = null;
                        goto IL_CA;
                    }
                Block_6: ;
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void btnLoadGraphic_Click(object sender, RoutedEventArgs e)
        {
            this.LoadGraphicsList();
            if (2 == 0)
            {
                goto IL_11;
            }
            if (false)
            {
                goto IL_20;
            }
        IL_0C:
            this.SetTemplateListVisibility(true);
        IL_11:
            this.StackGraphicSettingPanel1.Visibility = Visibility.Visible;
            if (false)
            {
                goto IL_0C;
            }
        IL_20:
            if (!false)
            {
                this.StackGraphicSettingPanel2.Visibility = Visibility.Visible;
                return;
            }
            goto IL_0C;
        }

        private void LoadGraphicsList()
        {
            while (true)
            {
                List<TemplateListItems> list = (from o in this.objTemplateList
                                                where o.MediaType == 606
                                                select o).ToList<TemplateListItems>();
                List<TemplateListItems>.Enumerator enumerator = list.GetEnumerator();
                try
                {
                    while (true)
                    {
                        TemplateListItems current;
                        if (2 != 0)
                        {
                            bool arg_6B_0 = enumerator.MoveNext();
                            bool expr_6C;
                            do
                            {
                                bool flag = arg_6B_0;
                                expr_6C = (arg_6B_0 = flag);
                            }
                            while (false);
                            if (!expr_6C)
                            {
                                break;
                            }
                            current = enumerator.Current;
                        }
                        current.IsChecked = false;
                    }
                }
                finally
                {
                    do
                    {
                        ((IDisposable)enumerator).Dispose();
                    }
                    while (5 == 0);
                }
                if (!false)
                {
                    this.lstTemplates.ItemsSource = list;
                }
                this.lstTemplates.IsEnabled = true;
                if (!false)
                {
                    this.templateType = "graphics";
                    break;
                }
            }
            this.txtTemplateRotate.Text = "Graphics Templates";
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
        }

        private void btAcquiredFrame_Click(object sender, RoutedEventArgs e)
        {
            CaptureFrameDownloader captureFrameDownloader;
            while (-1 != 0 && 8 != 0)
            {
                if (7 != 0)
                {
                    captureFrameDownloader = new CaptureFrameDownloader();
                    bool flag = !captureFrameDownloader.IsShoworHide();
                    if (false)
                    {
                        continue;
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
                return;
            }
            captureFrameDownloader.Show();
        }

        private void btnGuestImageAsGraphic_Click(object sender, RoutedEventArgs e)
        {
            VideoElements videoElements = this.lstVideoElements.Where(delegate(VideoElements o)
            {
                int arg_0E_0 = o.PhotoId;
                int arg_58_0;
                while (arg_0E_0 == this.DropPhotoId && o.PageNo == this.activePage)
                {
                    int expr_51 = arg_0E_0 = o.MediaType;
                    if (7 != 0)
                    {
                        bool arg_3A_0 = (arg_0E_0 = (arg_58_0 = ((expr_51 == 1) ? 1 : 0))) != 0;
                        if (!false && !false)
                        {
                            if (-1 == 0)
                            {
                                continue;
                            }
                        IL_33:
                            bool flag = arg_58_0 != 0;
                            arg_3A_0 = flag;
                        }
                        return arg_3A_0;
                    }
                }
                arg_58_0 = 0;
                goto IL_33;
            }).FirstOrDefault<VideoElements>();
            if (videoElements != null)
            {
                string filePath = videoElements.GuestImagePath.Replace("\\Thumbnails", "");
                this.CreateGraphicsFromImage(filePath, videoElements.CreatedDate, videoElements.PhotoId);
            }
            else if (this.processImageItem != null)
            {
                string filePath = this.processImageItem.HotFolderPath + this.processImageItem.CreatedOn.ToString("yyyyMMdd") + "\\" + this.processImageItem.FileName;
                this.CreateGraphicsFromImage(filePath, this.processImageItem.CreatedOn, Convert.ToInt32(this.processImageItem.Photo_RFID));
            }
        }

        private void CreateGraphicsFromImage(string filePath, DateTime createdDate, int photoId)
        {
            try
            {
                this.ClearEffects();
                this.isImageAsGraphic = true;
                int arg_8B_0;
                bool expr_18A = (arg_8B_0 = (Directory.Exists(Environment.CurrentDirectory + "\\CroppedImage") ? 1 : 0)) != 0;
                if (false)
                {
                    goto IL_8B;
                }
                if (!expr_18A)
                {
                    Directory.CreateDirectory(Environment.CurrentDirectory + "\\CroppedImage");
                }
                string text = filePath;
                string fileName = System.IO.Path.GetFileName(text);
                bool arg_6F_0 = File.Exists(text.Replace(".jpg", ".png"));
                int arg_6F_1 = 0;
            IL_6F:
                if ((arg_6F_0 ? 1 : 0) != arg_6F_1)
                {
                    text = filePath.Replace(".jpg", ".png");
                }
                arg_8B_0 = 4;
            IL_8B:
                object[] array = new object[arg_8B_0];
                TemplateListItems templateListItems;
                if (!false)
                {
                    array[0] = Environment.CurrentDirectory;
                    array[1] = "\\CroppedImage\\";
                    array[2] = VideoEditor.tempGraphicId;
                    array[3] = System.IO.Path.GetExtension(text);
                    string text2 = string.Concat(array);
                    int expr_CB = (arg_6F_0 = File.Exists(text2)) ? 1 : 0;
                    int expr_D1 = arg_6F_1 = 0;
                    if (expr_D1 != 0)
                    {
                        goto IL_6F;
                    }
                    if (expr_CB != expr_D1)
                    {
                        if (false)
                        {
                            goto IL_113;
                        }
                        File.Delete(text2);
                    }
                    text2 = this.CropImageAsPerAspectRatio(text, text2);
                    this.dragCanvas.Visibility = Visibility.Visible;
                    templateListItems = new TemplateListItems();
                    templateListItems.isActive = true;
                    templateListItems.FilePath = text2;
                IL_113:
                    templateListItems.Item_ID = (long)photoId;
                    templateListItems.IsChecked = true;
                    templateListItems.DisplayName = fileName;
                    templateListItems.MediaType = 601;
                    do
                    {
                        templateListItems.Name = fileName;
                    }
                    while (4 == 0);
                }
                VideoEditor.tempGraphicId++;
                this.objTemplateList.Add(templateListItems);
            }
            catch (Exception serviceException)
            {
                if (!false && 4 != 0)
                {
                    this.ClearImageSourceControl();
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private string CropImageAsPerAspectRatio(string inputImage, string CroppedImagePath)
        {
            string result;
            try
            {
                this.ClearImageSourceControl();
                VideoProcessingClass videoProcessingClass = new VideoProcessingClass();
                int width = ConfigManager.IMIXConfigurations.ContainsKey(43L) ? Convert.ToInt32(ConfigManager.IMIXConfigurations[43L]) : 1920;
                int height = ConfigManager.IMIXConfigurations.ContainsKey(42L) ? Convert.ToInt32(ConfigManager.IMIXConfigurations[42L]) : 1072;
                videoProcessingClass.CropeImageAsperAspectRatio(inputImage, CroppedImagePath, width, height);
                this.specFileName = CroppedImagePath;
                Uri uriSource = new Uri(CroppedImagePath);
                this.ClearImageSourceControl();
                this.mainImage.Source = new BitmapImage(uriSource);
                this.mainImage_Size.Source = new BitmapImage(uriSource);
                this.mainImagesize.Source = new BitmapImage(uriSource);
                this.mainImage.UpdateLayout();
                this.mainImagesize.UpdateLayout();
                this.mainImage_Size.UpdateLayout();
                this.canbackground.UpdateLayout();
                if (System.IO.Path.GetExtension(inputImage).ToLower() != ".png")
                {
                    this.ExtractPng(this.specFileName);
                }
            }
            catch (Exception serviceException)
            {
                this.ClearImageSourceControl();
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
                result = null;
                return result;
            }
            finally
            {
            }
            result = CroppedImagePath;
            return result;
        }

        private string LoadChromacolor()
        {
            return string.Empty;
        }

        private void ZoomInButton_Click(object sender, RoutedEventArgs e)
        {
            this.ZoomIn();
        }

        private void ZoomIn()
        {
            RenderOptions.SetEdgeMode(this.mainImage, EdgeMode.Aliased);
            try
            {
                try
                {
                    System.Windows.Controls.Button button;
                    TransformGroup transformGroup;
                    TransformGroup transformGroup2;
                    RotateTransform rotateTransform;
                    ScaleTransform scaleTransform;
                    bool arg_36E_0;
                    bool arg_22F_0;
                    int arg_36E_1;
                    bool arg_1AE_0;
                    if (this.elementForContextMenu is System.Windows.Controls.Button)
                    {
                        button = (System.Windows.Controls.Button)this.elementForContextMenu;
                        string path = ((System.Windows.Controls.Image)button.Content).Source.ToString();
                        if (!(System.IO.Path.GetExtension(path) != ".gif"))
                        {
                            goto IL_358;
                        }
                        if (button.Tag != null)
                        {
                            this._GraphicsZoomFactor += 0.025;
                        }
                        else
                        {
                            this._GraphicsZoomFactor = 1.0;
                        }
                        transformGroup = new TransformGroup();
                        transformGroup2 = (this.elementForContextMenu.GetValue(UIElement.RenderTransformProperty) as TransformGroup);
                        rotateTransform = new RotateTransform();
                        if (6 == 0)
                        {
                            goto IL_3ED;
                        }
                        button.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
                        rotateTransform.CenterX = 0.0;
                        rotateTransform.CenterY = 0.0;
                        scaleTransform = new ScaleTransform();
                        if (false)
                        {
                            goto IL_2B7;
                        }
                        if (transformGroup2 == null)
                        {
                            goto IL_24C;
                        }
                        int expr_14D = (arg_22F_0 = (arg_36E_0 = (transformGroup2.Children.Count > 0))) ? 1 : 0;
                        if (3 == 0)
                        {
                            goto IL_22F;
                        }
                        int expr_156 = arg_36E_1 = 0;
                        if (expr_156 != 0)
                        {
                            goto IL_36E;
                        }
                        if (expr_14D == expr_156)
                        {
                            goto IL_1CC;
                        }
                        if (transformGroup2.Children[0] is ScaleTransform)
                        {
                            scaleTransform = (ScaleTransform)transformGroup2.Children[0];
                            goto IL_1CB;
                        }
                        arg_1AE_0 = (transformGroup2.Children[0] is RotateTransform);
                    }
                    else
                    {
                        arg_36E_0 = (arg_1AE_0 = (this.elementForContextMenu == null));
                        if (!false)
                        {
                            arg_36E_1 = 0;
                            goto IL_36E;
                        }
                    }
                    if (arg_1AE_0)
                    {
                        rotateTransform = (RotateTransform)transformGroup2.Children[0];
                    }
                IL_1CB:
                IL_1CC:
                    if (transformGroup2.Children.Count <= 1)
                    {
                        goto IL_24B;
                    }
                    if (transformGroup2.Children[1] is ScaleTransform)
                    {
                        scaleTransform = (ScaleTransform)transformGroup2.Children[1];
                        goto IL_24A;
                    }
                    arg_22F_0 = !(transformGroup2.Children[1] is RotateTransform);
                IL_22F:
                    if (!arg_22F_0)
                    {
                        rotateTransform = (RotateTransform)transformGroup2.Children[1];
                    }
                IL_24A:
                IL_24B:
                IL_24C:
                    if (scaleTransform != null)
                    {
                        scaleTransform.ScaleX = this._GraphicsZoomFactor;
                        goto IL_2B7;
                    }
                    scaleTransform = new ScaleTransform();
                    scaleTransform.ScaleX = this._GraphicsZoomFactor;
                IL_26F:
                    scaleTransform.ScaleY = this._GraphicsZoomFactor;
                    if (8 != 0)
                    {
                        scaleTransform.CenterX = 0.0;
                        scaleTransform.CenterY = 0.0;
                        goto IL_2E9;
                    }
                    goto IL_34F;
                IL_2B7:
                    scaleTransform.ScaleY = this._GraphicsZoomFactor;
                    scaleTransform.CenterX = 0.0;
                    scaleTransform.CenterY = 0.0;
                IL_2E9:
                    transformGroup.Children.Add(scaleTransform);
                    if (rotateTransform != null)
                    {
                        transformGroup.Children.Add(rotateTransform);
                    }
                    if (5 == 0)
                    {
                        goto IL_26F;
                    }
                    button.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
                    button.Tag = this._GraphicsZoomFactor.ToString();
                    button.RenderTransform = transformGroup;
                IL_34F:
                    this.elementForContextMenu = button;
                IL_358:
                    goto IL_468;
                IL_36E:
                    if ((arg_36E_0 ? 1 : 0) == arg_36E_1)
                    {
                        goto IL_468;
                    }
                    if (this._ZoomFactor >= this._maxZoomFactor)
                    {
                        this._ZoomFactor = 4.0;
                        return;
                    }
                    this._ZoomFactor += 0.025;
                    if (this.zoomTransform == null)
                    {
                        goto IL_467;
                    }
                    this.zoomTransform.CenterX = this.mainImage.ActualWidth / 2.0;
                IL_3ED:
                    this.zoomTransform.CenterY = this.mainImage.ActualHeight / 2.0;
                    this.zoomTransform.ScaleX = this._ZoomFactor;
                    this.zoomTransform.ScaleY = this._ZoomFactor;
                    this.transformGroup = new TransformGroup();
                    this.transformGroup.Children.Add(this.zoomTransform);
                    this.GrdBrightness.RenderTransform = this.transformGroup;
                IL_467:
                IL_468: ;
                }
                catch (Exception ex)
                {
                    string message = ErrorHandler.CreateErrorMessage(ex);
                    ErrorHandler.LogFileWrite(message);
                    System.Windows.MessageBox.Show(ex.Message);
                }
                if (3 != 0)
                {
                }
            }
            finally
            {
            }
        }

        private void ZoomOutButton_Click(object sender, RoutedEventArgs e)
        {
            DependencyObject expr_06 = this.mainImage;
            EdgeMode expr_0B = EdgeMode.Aliased;
            if (!false)
            {
                RenderOptions.SetEdgeMode(expr_06, expr_0B);
            }
            try
            {
                bool expr_29 = !(this.elementForContextMenu is System.Windows.Controls.Button);
                bool flag;
                if (!false)
                {
                    flag = expr_29;
                }
                if (!flag)
                {
                    System.Windows.Controls.Button button = (System.Windows.Controls.Button)this.elementForContextMenu;
                    string path = ((System.Windows.Controls.Image)button.Content).Source.ToString();
                    bool arg_220_0;
                    bool expr_7C = arg_220_0 = !(System.IO.Path.GetExtension(path) != ".gif");
                    TransformGroup transformGroup;
                    RotateTransform rotateTransform;
                    ScaleTransform scaleTransform;
                    if (4 != 0)
                    {
                        flag = expr_7C;
                        if (flag)
                        {
                            goto IL_2E7;
                        }
                        flag = (button.Tag == null);
                        if (!flag)
                        {
                        }
                        if (!true)
                        {
                            goto IL_2E6;
                        }
                        flag = (this._GraphicsZoomFactor < 0.625);
                        if (flag)
                        {
                            return;
                        }
                        this._GraphicsZoomFactor -= 0.025;
                        transformGroup = new TransformGroup();
                        TransformGroup transformGroup2 = this.elementForContextMenu.GetValue(UIElement.RenderTransformProperty) as TransformGroup;
                        rotateTransform = new RotateTransform();
                        scaleTransform = new ScaleTransform();
                        flag = (transformGroup2 == null);
                        if (!flag)
                        {
                            flag = (transformGroup2.Children.Count <= 0);
                            if (!flag)
                            {
                                flag = !(transformGroup2.Children[0] is ScaleTransform);
                                if (!flag)
                                {
                                    scaleTransform = (ScaleTransform)transformGroup2.Children[0];
                                }
                                else
                                {
                                    flag = !(transformGroup2.Children[0] is RotateTransform);
                                    if (!flag)
                                    {
                                        do
                                        {
                                            rotateTransform = (RotateTransform)transformGroup2.Children[0];
                                        }
                                        while (-1 == 0);
                                    }
                                }
                            }
                            flag = (transformGroup2.Children.Count <= 1);
                            if (!flag)
                            {
                                flag = !(transformGroup2.Children[1] is ScaleTransform);
                                if (!flag)
                                {
                                    scaleTransform = (ScaleTransform)transformGroup2.Children[1];
                                }
                                else
                                {
                                    flag = !(transformGroup2.Children[1] is RotateTransform);
                                    if (!flag)
                                    {
                                        rotateTransform = (RotateTransform)transformGroup2.Children[1];
                                    }
                                }
                            }
                        }
                        flag = (scaleTransform != null);
                        arg_220_0 = flag;
                    }
                    if (arg_220_0)
                    {
                        scaleTransform.ScaleX -= 0.025;
                        scaleTransform.ScaleY -= 0.025;
                        scaleTransform.CenterX = 0.0;
                        scaleTransform.CenterY = 0.0;
                        transformGroup.Children.Add(scaleTransform);
                        flag = (rotateTransform == null);
                        if (!flag)
                        {
                            transformGroup.Children.Add(rotateTransform);
                        }
                        button.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
                        button.Tag = this._GraphicsZoomFactor;
                        button.RenderTransform = transformGroup;
                        this.elementForContextMenu = button;
                    }
                IL_2E6:
                IL_2E7: ;
                }
                else
                {
                    flag = (this.elementForContextMenu != null);
                    if (!flag)
                    {
                        flag = (this._ZoomFactor < 0.525);
                        if (!flag)
                        {
                            this._ZoomFactor -= 0.025;
                            flag = (this.zoomTransform == null);
                            if (!flag)
                            {
                                this.zoomTransform.CenterX = this.mainImage.ActualWidth / 2.0;
                                this.zoomTransform.CenterY = this.mainImage.ActualHeight / 2.0;
                                this.zoomTransform.ScaleX = this._ZoomFactor;
                                this.zoomTransform.ScaleY = this._ZoomFactor;
                                this.transformGroup = new TransformGroup();
                                this.transformGroup.Children.Add(this.zoomTransform);
                                this.GrdBrightness.RenderTransform = this.transformGroup;
                            }
                        }
                        else
                        {
                            this._ZoomFactor = 0.5;
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void mainImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            while (-1 != 0 && 8 != 0)
            {
                if (7 != 0)
                {
                    bool flag = e.LeftButton != MouseButtonState.Released;
                    if (false)
                    {
                        continue;
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
                return;
            }
            this.elementForContextMenu = null;
        }

        private void mainImage_Size_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            while (-1 != 0 && 8 != 0)
            {
                if (7 != 0)
                {
                    bool flag = e.LeftButton != MouseButtonState.Released;
                    if (false)
                    {
                        continue;
                    }
                    if (!flag)
                    {
                        break;
                    }
                }
                return;
            }
            this.elementForContextMenu = null;
        }

        private void RepeatButton_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            bool arg_0C_0;
            bool arg_18_0 = arg_0C_0 = (e.Delta > 0);
            while (true)
            {
                bool flag;
                if (!false)
                {
                    flag = !arg_0C_0;
                    goto IL_10;
                }
            IL_15:
                if (!false)
                {
                    if (arg_18_0)
                    {
                        this.ZoomOutButton_Click(sender, new RoutedEventArgs());
                        if (4 != 0)
                        {
                            goto IL_3A;
                        }
                    }
                    this.ZoomInButton_Click(sender, new RoutedEventArgs());
                    goto IL_24;
                }
                continue;
            IL_10:
                if (-1 != 0)
                {
                    arg_18_0 = (arg_0C_0 = flag);
                    goto IL_15;
                }
            IL_3A:
                if (!false)
                {
                    break;
                }
                goto IL_10;
            IL_24:
                goto IL_3A;
            }
        }

        private void GrdBrightn_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            bool arg_0B_0 = this.dragCanvas.IsMouseOver;
            while (arg_0B_0)
            {
                int arg_1F_0 = e.Delta;
                int arg_1F_1 = 0;
                int expr_1F;
                int expr_22;
                do
                {
                    expr_1F = (arg_1F_0 = ((arg_1F_0 > arg_1F_1) ? 1 : 0));
                    expr_22 = (arg_1F_1 = 0);
                }
                while (expr_22 != 0);
                bool arg_88_0 = arg_0B_0 = (expr_1F == expr_22);
                while (!false)
                {
                    bool flag = arg_88_0;
                    bool expr_8B = arg_0B_0 = (arg_88_0 = flag);
                    if (!false)
                    {
                        if (!expr_8B)
                        {
                            do
                            {
                                if (2 != 0)
                                {
                                }
                            }
                            while (false);
                            this.ZoomInButton_Click(sender, new RoutedEventArgs());
                        }
                        else
                        {
                            this.ZoomOutButton_Click(sender, new RoutedEventArgs());
                        }
                        return;
                    }
                }
            }
        }

        private void ExtractPng(string imagename)
        {
            try
            {
                imagename = imagename.Replace("jpg", "png").Replace("JPG", "PNG");
                this.specFileName = imagename;
                string text = this.LoadChromacolor();
                ChromaEffectAllColor chromaEffectAllColor = new ChromaEffectAllColor();
                string text2 = text;
                if (4 != 0)
                {
                    if (text2 != null)
                    {
                        if (!(text2 == "Green"))
                        {
                            if (!(text2 == "Blue"))
                            {
                                if (text2 == "Red")
                                {
                                    chromaEffectAllColor.ColorKey = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#FF0000");
                                    chromaEffectAllColor.Tolerance = 0.4f;
                                    this.Grdcartoonize.Effect = chromaEffectAllColor;
                                }
                            }
                            else
                            {
                                chromaEffectAllColor.ColorKey = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString("#4D8AEC");
                                chromaEffectAllColor.Tolerance = float.Parse(".6");
                                this.Grdcartoonize.Effect = chromaEffectAllColor;
                            }
                        }
                        else
                        {
                            ChromaKeyHSVEffect chromaKeyHSVEffect = new ChromaKeyHSVEffect();
                            chromaKeyHSVEffect.HueMin = 0.2;
                            chromaKeyHSVEffect.HueMax = 0.5;
                            chromaKeyHSVEffect.LightnessShift = 0.15;
                            chromaKeyHSVEffect.SaturationShift = 0.38;
                            this.Grdcartoonize.Effect = chromaKeyHSVEffect;
                        }
                    }
                    foreach (object current in this.dragCanvas.Children)
                    {
                        if (current is System.Windows.Controls.Button)
                        {
                            System.Windows.Controls.Button button = (System.Windows.Controls.Button)current;
                            string path = ((System.Windows.Controls.Image)button.Content).Source.ToString();
                            if (System.IO.Path.GetExtension(path) == ".gif")
                            {
                                button.Visibility = Visibility.Hidden;
                            }
                        }
                    }
                    this.canbackground.Width = this.mainImage.Source.Width;
                    this.canbackground.Height = this.mainImage.Source.Height;
                    this.canbackground.UpdateLayout();
                    RenderTargetBitmap source = this.jCaptureScreen(this.canbackground);
                    using (FileStream fileStream = new FileStream(imagename, FileMode.Create, FileAccess.ReadWrite))
                    {
                        new PngBitmapEncoder
                        {
                            Interlace = PngInterlaceOption.On,
                            Frames = 
							{
								BitmapFrame.Create(source)
							}
                        }.Save(fileStream);
                    }
                    this.ClearImageSourceControl();
                    this.canbackground.UpdateLayout();
                }
                Uri uriSource = new Uri(imagename);
                this.canbackground.Width = 500.0;
                this.canbackground.Height = 290.0;
                this.canbackground.UpdateLayout();
                this.mainImage.Source = new BitmapImage(uriSource);
                this.mainImage_Size.Source = new BitmapImage(uriSource);
                this.mainImagesize.Source = new BitmapImage(uriSource);
                this.canbackground.UpdateLayout();
            }
            catch (Exception serviceException)
            {
                this.ClearImageSourceControl();
                if (6 != 0)
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    do
                    {
                        ErrorHandler.LogFileWrite(message);
                    }
                    while (3 == 0);
                }
            }
        }

        public RenderTargetBitmap jCaptureScreen(Grid forWdht)
        {
            RenderTargetBitmap renderTargetBitmap = null;
            RenderTargetBitmap result;
            try
            {
                base.InvalidateVisual();
                BitmapImage bitmapImage = this.mainImage.Source as BitmapImage;
                if (bitmapImage == null)
                {
                    this.ClearImageSourceControl();
                    bitmapImage = (this.mainImage.Source as BitmapImage);
                }
                double dpiX = bitmapImage.DpiX;
                double dpiY = bitmapImage.DpiY;
                RenderOptions.SetBitmapScalingMode(forWdht, BitmapScalingMode.HighQuality);
                while (false)
                {
                }
                RenderOptions.SetEdgeMode(forWdht, EdgeMode.Aliased);
                try
                {
                    System.Windows.Size size;
                    do
                    {
                        size = new System.Windows.Size(forWdht.Width, forWdht.Height);
                    }
                    while (false);
                    double arg_A2_0;
                    double expr_94 = arg_A2_0 = size.Width * dpiY;
                    if (8 != 0)
                    {
                        arg_A2_0 = expr_94 / 96.0;
                    }
                    renderTargetBitmap = new RenderTargetBitmap((int)arg_A2_0, (int)(size.Height * dpiY / 96.0), dpiX, dpiY, PixelFormats.Default);
                    RenderOptions.SetEdgeMode(forWdht, EdgeMode.Aliased);
                    do
                    {
                        forWdht.SnapsToDevicePixels = true;
                        forWdht.RenderTransform = new ScaleTransform(1.0, 1.0, 0.5, 0.5);
                    }
                    while (8 == 0);
                    forWdht.Measure(size);
                    forWdht.Arrange(new Rect(size));
                    renderTargetBitmap.Render(forWdht);
                    forWdht.RenderTransform = null;
                    result = renderTargetBitmap;
                }
                catch (Exception serviceException)
                {
                    Rect descendantBounds = VisualTreeHelper.GetDescendantBounds(this.GrdBrightness);
                    DrawingVisual drawingVisual = new DrawingVisual();
                    renderTargetBitmap = new RenderTargetBitmap((int)(descendantBounds.Width * dpiX / 96.0), (int)(descendantBounds.Height * dpiY / 96.0), dpiX, dpiY, PixelFormats.Default);
                    using (DrawingContext drawingContext = drawingVisual.RenderOpen())
                    {
                        if (!false)
                        {
                            VisualBrush brush;
                            do
                            {
                                brush = new VisualBrush(forWdht);
                            }
                            while (2 == 0);
                            drawingContext.DrawRectangle(brush, null, new Rect(default(System.Windows.Point), descendantBounds.Size));
                        }
                    }
                    renderTargetBitmap.Render(drawingVisual);
                    result = renderTargetBitmap;
                }
            }
            catch (Exception serviceException)
            {
                this.ClearImageSourceControl();
                do
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.LogFileWrite(message);
                }
                while (false);
                result = renderTargetBitmap;
            }
            return result;
        }

        private void ClearImageSourceControl()
        {
            Uri uriSource;
            while (-1 != 0)
            {
                this.mainImage.Source = null;
                this.mainImage_Size.Source = null;
                if (7 != 0)
                {
                    if (!false)
                    {
                        this.mainImagesize.Source = null;
                    }
                    while (!false)
                    {
                        uriSource = new Uri("/DigiPhoto;component/images/blank.png", UriKind.RelativeOrAbsolute);
                        this.mainImage.Source = new BitmapImage(uriSource);
                        if (4 != 0)
                        {
                            this.mainImage_Size.Source = new BitmapImage(uriSource);
                            goto IL_6C;
                        }
                    }
                    return;
                }
            }
        IL_6C:
            this.mainImagesize.Source = new BitmapImage(uriSource);
        }

        private void ClearEffects()
        {
            this.mainImage.Source = null;
            System.Windows.Controls.Image expr_17 = this.mainImage_Size;
            ImageSource expr_1C = null;
            if (3 != 0)
            {
                expr_17.Source = expr_1C;
            }
            while (true)
            {
                this._ZoomFactor = 1.0;
                this.VideoEditPlayerPanel.Visibility = Visibility.Hidden;
                if (7 == 0)
                {
                    goto IL_6D;
                }
                this.gdMediaPlayer.Visibility = Visibility.Visible;
                this.grdZoom.UpdateLayout();
                if (!false)
                {
                    goto IL_6D;
                }
            IL_C0:
                this.GrdBrightness.Margin = new Thickness(0.0, 0.0, 0.0, 0.0);
                if (!false)
                {
                    break;
                }
                continue;
            IL_6D:
                this.grdsize.UpdateLayout();
                if (!false)
                {
                }
                if (false)
                {
                    goto IL_136;
                }
                this.mainImage.SnapsToDevicePixels = true;
                if (!false)
                {
                    RenderOptions.SetEdgeMode(this.mainImage, EdgeMode.Aliased);
                    this.canbackground.RenderTransform = new RotateTransform();
                    this.dragCanvas.AllowDragOutOfView = true;
                    goto IL_C0;
                }
                goto IL_158;
            }
            this.canbackground.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            this.canbackground.VerticalAlignment = VerticalAlignment.Center;
            this.canbackground.RenderTransform = null;
            Canvas.SetLeft(this.GrdBrightness, 0.0);
        IL_136:
            Canvas.SetTop(this.GrdBrightness, 0.0);
            this.GrdBrightness.RenderTransform = null;
        IL_158:
            this.grdZoom.RenderTransform = null;
        }

        private void GetGraphicPosition()
        {
            using (IEnumerator enumerator = this.dragCanvas.Children.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (false)
                    {
                        goto IL_CC;
                    }
                    object expr_15B = enumerator.Current;
                    object obj;
                    if (4 != 0)
                    {
                        obj = expr_15B;
                    }
                    if (false || obj is System.Windows.Controls.Button)
                    {
                        System.Windows.Controls.Button button = (System.Windows.Controls.Button)obj;
                        double arg_6F_0;
                        double expr_60 = arg_6F_0 = Canvas.GetTop(button);
                        if (8 != 0)
                        {
                            double num = expr_60;
                            arg_6F_0 = Canvas.GetLeft(button);
                        }
                        double num2 = arg_6F_0;
                        string text = ((System.Windows.Controls.Image)button.Content).Source.ToString();
                        int num3 = text.Split(new char[]
						{
							'/'
						}).Count<string>();
                        text = text.Split(new char[]
						{
							'/'
						})[num3 - 1].ToString();
                        if (!false)
                        {
                            goto IL_CC;
                        }
                    }
                    continue;
                    continue;
                IL_CC:
                    List<SlotProperty>.Enumerator enumerator2 = this.LogoControlBox.LogoSlotList.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            bool flag = enumerator2.MoveNext();
                            bool arg_FB_0;
                            bool expr_121 = arg_FB_0 = flag;
                            if (false)
                            {
                                goto IL_FB;
                            }
                            SlotProperty current;
                            if (expr_121)
                            {
                                current = enumerator2.Current;
                                string text;
                                arg_FB_0 = !current.FilePath.Contains(text);
                                goto IL_FB;
                            }
                            if (!false)
                            {
                                break;
                            }
                        IL_FD:
                            if (!flag)
                            {
                                double num;
                                current.Top = (int)num;
                                double num2;
                                current.Left = (int)num2;
                            }
                            continue;
                        IL_FB:
                            flag = arg_FB_0;
                            goto IL_FD;
                        }
                    }
                    finally
                    {
                        if (!false)
                        {
                            ((IDisposable)enumerator2).Dispose();
                        }
                    }
                }
            }
        }

        private void btnRemoveMarkGraphic_Click(object sender, RoutedEventArgs e)
        {
            TemplateListItems expr_69 = (from o in this.objTemplateList
                                         where o.MediaType == 601
                                         select o).FirstOrDefault<TemplateListItems>();
            TemplateListItems templateListItems;
            if (!false)
            {
                templateListItems = expr_69;
            }
            bool flag = templateListItems == null;
            while (2 != 0)
            {
                if (flag)
                {
                    return;
                }
                this.ClearImageSourceControl();
                this.isImageAsGraphic = false;
                if (!false)
                {
                    this.objTemplateList.Remove(templateListItems);
                    break;
                }
            }
        }

        private void HighlightSelectedButton(string btName)
        {
            if (btName == "btnVideo")
            {
                this.btnVideo.IsEnabled = false;
            }
            else
            {
                this.btnVideo.IsEnabled = true;
            }
            if (btName == "btnChroma")
            {
                this.btnChroma.IsEnabled = false;
            }
            else
            {
                this.btnChroma.IsEnabled = true;
            }
            if (btName == "btnCapture")
            {
                this.btnCapture.IsEnabled = false;
            }
            else
            {
                this.btnCapture.IsEnabled = true;
            }
            if (btName == "btnColorEffects")
            {
                this.btnColorEffects.IsEnabled = false;
            }
            else
            {
                this.btnColorEffects.IsEnabled = true;
            }
        }

        private void LoadSceneSettingsBasedOnImage(LstMyItems ImgDetail)
        {
            ConfigBusiness configBusiness = new ConfigBusiness();
            new VideoSceneViewModel();
            if (false)
            {
            }
            VideoSceneViewModel videoSceneBasedOnPhotoId = configBusiness.GetVideoSceneBasedOnPhotoId(ImgDetail.PhotoId);
            if (videoSceneBasedOnPhotoId != null)
            {
                try
                {
                    string bsXMLDescOrFile = System.IO.Path.Combine(ConfigManager.DigiFolderPath, videoSceneBasedOnPhotoId.VideoScene.ScenePath);
                    this.Vidlength = videoSceneBasedOnPhotoId.VideoScene.VideoLength;
                    this.m_pMPersist = (MCHROMAKEYLib.IMPersist)this.m_objMixer;
                    this.m_pMPersist.PersistLoad("", bsXMLDescOrFile, "");
                    this.mMixerList1.UpdateList(true, 1);
                    this.mElementsTree1.UpdateTree(false);
                    this.GetGuestElement();
                    this.LoadFirstItemOnMixer();
                    this.LoadChromaAndCGConfig(videoSceneBasedOnPhotoId.VideoScene.Name, videoSceneBasedOnPhotoId.VideoScene.CG_ConfigID);
                    this.GetAudioListToBeApplied(videoSceneBasedOnPhotoId.VideoScene.Name);
                    this.CheckTemplateItems();
                    this.IsSceneLoaded = true;
                    this.colorEffects = MLHelpers.ReadColorXml(System.IO.Path.Combine(ConfigManager.DigiFolderPath, "Profiles", videoSceneBasedOnPhotoId.VideoScene.Name, "Color.xml"));
                    if (this.colorEffects != null)
                    {
                        this.LoadValuestoColorControls(this.colorEffects);
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("File does not Exists!");
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.LogFileWrite(message);
                }
            }
            else
            {
                System.Windows.MessageBox.Show("No scene settings found for the selected image/video!\nDefault scene settings will be loaded.", "DigiPhoto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void CheckTemplateItems()
        {
            try
            {
                string empty = string.Empty;
                MItem mItem;
                this.m_objMixer.StreamsBackgroundGet(out empty, out mItem);
                TemplateListItems templateListItems;
                if (!string.IsNullOrEmpty(empty))
                {
                    string name1 = System.IO.Path.GetFileName(empty);
                    templateListItems = this.objTemplateList.Where(delegate(TemplateListItems o)
                    {
                        int arg_09_0 = o.MediaType;
                        bool arg_2E_0;
                        while (true)
                        {
                            int arg_4D_0;
                            if (arg_09_0 == 605)
                            {
                                arg_2E_0 = ((arg_09_0 = (arg_4D_0 = (o.Name.Contains(name1) ? 1 : 0))) != 0);
                                if (!false)
                                {
                                    goto IL_21;
                                }
                            }
                            else
                            {
                                if (!false)
                                {
                                    arg_4D_0 = 0;
                                    goto IL_21;
                                }
                                goto IL_26;
                            }
                        IL_28:
                            if (false)
                            {
                                goto IL_22;
                            }
                            if (!false)
                            {
                                break;
                            }
                            continue;
                        IL_26:
                            bool flag2;
                            arg_2E_0 = ((arg_09_0 = (arg_4D_0 = (flag2 ? 1 : 0))) != 0);
                            goto IL_28;
                        IL_22:
                            flag2 = (arg_4D_0 != 0);
                            goto IL_26;
                        IL_21:
                            goto IL_22;
                        }
                        return arg_2E_0;
                    }).FirstOrDefault<TemplateListItems>();
                    if (templateListItems != null)
                    {
                        templateListItems.IsChecked = true;
                    }
                }
                this.OverlayElement.AttributesStringGet("stream_id", out empty);
                bool flag = string.IsNullOrEmpty(empty);
                bool arg_9C_0 = flag;
                bool expr_22E;
                do
                {
                    int num2;
                    string a;
                    if (!arg_9C_0)
                    {
                        mItem = null;
                        int num;
                        this.m_objMixer.StreamsGet(empty, out num, out mItem);
                        if (mItem != null)
                        {
                            string videOverlayName = string.Empty;
                            mItem.FileNameGet(out videOverlayName);
                            videOverlayName = System.IO.Path.GetFileName(videOverlayName);
                            templateListItems = this.objTemplateList.Where(delegate(TemplateListItems o)
                            {
                                int arg_09_0 = o.MediaType;
                                bool arg_2E_0;
                                while (true)
                                {
                                    int arg_4D_0;
                                    if (arg_09_0 == 609)
                                    {
                                        arg_2E_0 = ((arg_09_0 = (arg_4D_0 = (o.Name.Contains(videOverlayName) ? 1 : 0))) != 0);
                                        if (!false)
                                        {
                                            goto IL_21;
                                        }
                                    }
                                    else
                                    {
                                        if (!false)
                                        {
                                            arg_4D_0 = 0;
                                            goto IL_21;
                                        }
                                        goto IL_26;
                                    }
                                IL_28:
                                    if (false)
                                    {
                                        goto IL_22;
                                    }
                                    if (!false)
                                    {
                                        break;
                                    }
                                    continue;
                                IL_26:
                                    bool flag2;
                                    arg_2E_0 = ((arg_09_0 = (arg_4D_0 = (flag2 ? 1 : 0))) != 0);
                                    goto IL_28;
                                IL_22:
                                    flag2 = (arg_4D_0 != 0);
                                    goto IL_26;
                                IL_21:
                                    goto IL_22;
                                }
                                return arg_2E_0;
                            }).FirstOrDefault<TemplateListItems>();
                            if (templateListItems != null)
                            {
                                num2 = 0;
                                this.OverlayElement.AttributesHave("show", out num2, out a);
                                if (a == "true")
                                {
                                    if (!true)
                                    {
                                        goto IL_25F;
                                    }
                                    templateListItems.IsChecked = true;
                                    this.OverlayElement.ElementReorder(500);
                                    this.StackOverlayChroma.Visibility = Visibility.Visible;
                                }
                            }
                        }
                    }
                    this.BorderElement.AttributesStringGet("stream_id", out empty);
                    mItem = null;
                    int num3;
                    this.m_objMixer.StreamsGet(empty, out num3, out mItem);
                    if (mItem == null)
                    {
                        goto IL_25F;
                    }
                    string bordername = string.Empty;
                    mItem.FileNameGet(out bordername);
                    bordername = System.IO.Path.GetFileName(bordername);
                    templateListItems = this.objTemplateList.Where(delegate(TemplateListItems o)
                    {
                        int arg_09_0 = o.MediaType;
                        bool arg_2E_0;
                        while (true)
                        {
                            int arg_4D_0;
                            if (arg_09_0 == 608)
                            {
                                arg_2E_0 = ((arg_09_0 = (arg_4D_0 = (o.FilePath.Contains(bordername) ? 1 : 0))) != 0);
                                if (!false)
                                {
                                    goto IL_21;
                                }
                            }
                            else
                            {
                                if (!false)
                                {
                                    arg_4D_0 = 0;
                                    goto IL_21;
                                }
                                goto IL_26;
                            }
                        IL_28:
                            if (false)
                            {
                                goto IL_22;
                            }
                            if (!false)
                            {
                                break;
                            }
                            continue;
                        IL_26:
                            bool flag2;
                            arg_2E_0 = ((arg_09_0 = (arg_4D_0 = (flag2 ? 1 : 0))) != 0);
                            goto IL_28;
                        IL_22:
                            flag2 = (arg_4D_0 != 0);
                            goto IL_26;
                        IL_21:
                            goto IL_22;
                        }
                        return arg_2E_0;
                    }).FirstOrDefault<TemplateListItems>();
                    if (templateListItems == null)
                    {
                        goto IL_25E;
                    }
                    num2 = 0;
                    this.BorderElement.AttributesHave("show", out num2, out a);
                    expr_22E = (arg_9C_0 = (a == "true"));
                }
                while (7 == 0);
                if (expr_22E)
                {
                    templateListItems.IsChecked = true;
                    this.BorderElement.ElementReorder(1000);
                }
            IL_25E:
            IL_25F:
                this.lstTemplates.ItemsSource = null;
                List<TemplateListItems> itemsSource = this.objTemplateList.Where(delegate(TemplateListItems o)
                {
                    bool result;
                    while (8 != 0)
                    {
                        bool arg_3A_0;
                        if (o.MediaType == 605)
                        {
                            arg_3A_0 = o.isActive;
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
                            arg_3A_0 = false;
                        }
                        result = arg_3A_0;
                        break;
                    }
                    return result;
                }).ToList<TemplateListItems>();
                this.lstTemplates.ItemsSource = itemsSource;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void mMixerList1_OnMixerSelChanged(object sender, EventArgs e)
        {
            try
            {
                while (!false)
                {
                    if (!false)
                    {
                        System.Windows.Forms.ListView listView = (System.Windows.Forms.ListView)sender;
                        int arg_18_0 = listView.SelectedItems.Count;
                        bool expr_60;
                        while (true)
                        {
                            bool expr_1B = (arg_18_0 = ((arg_18_0 <= 0) ? 1 : 0)) != 0;
                            if (!false)
                            {
                                bool flag = expr_1B;
                                expr_60 = ((arg_18_0 = (flag ? 1 : 0)) != 0);
                                if (!false)
                                {
                                    break;
                                }
                            }
                        }
                        if (!expr_60)
                        {
                            if (false)
                            {
                                continue;
                            }
                            MCHROMAKEYLib.MChromaKey chromakeyFilter = this.GetChromakeyFilter(listView.SelectedItems[0]);
                        }
                    }
                    break;
                }
            }
            catch
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

        private void mPersistControl1_OnLoad(object sender, EventArgs e)
        {
            if (false)
            {
                goto IL_11;
            }
        IL_04:
            if (6 == 0)
            {
                goto IL_20;
            }
            this.mMixerList1.UpdateList(false);
        IL_11:
            if (!false)
            {
                this.mElementsTree1.UpdateTree(false);
            }
        IL_20:
            if (!false)
            {
                return;
            }
            goto IL_04;
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.MediaStop();
                this.thumCaptured = false;
                if ((from o in this.PrintOrderPageList.Where(delegate(VideoPage o)
                {
                    int arg_0D_0;
                    if (o.Name != null)
                    {
                        arg_0D_0 = o.Name.Length;
                        goto IL_0C;
                    }
                    int arg_41_0 = 0;
                    bool expr_44;
                    do
                    {
                    IL_15:
                        bool flag = arg_41_0 != 0;
                        if (!false)
                        {
                        }
                        expr_44 = ((arg_0D_0 = (arg_41_0 = (flag ? 1 : 0))) != 0);
                    }
                    while (8 == 0);
                    if (!false)
                    {
                        return expr_44;
                    }
                    goto IL_0F;
                IL_0C:
                    arg_41_0 = (arg_0D_0 = ((arg_0D_0 > 0) ? 1 : 0));
                IL_0F:
                    if (!false)
                    {
                        goto IL_15;
                    }
                    goto IL_0C;
                })
                     orderby o.PageNo
                     select o).ToList<VideoPage>().Count<VideoPage>() > 0)
                {
                    this.stkbtnClosePreview.Visibility = Visibility.Collapsed;
                    this.IsExternalAudio = false;
                    this.btnStopProcess.IsEnabled = true;
                    this.NextAudioStartTime = 0.0;
                    this.NextItemStartTime = 0.0;
                    this.ClearAllControl();
                    this.UpdatePageListTime();
                    if (this.OverlayElement != null)
                    {
                        if (this.OverlayElement != null)
                        {
                            this.OverlayElement.ElementReorder(500);
                        }
                    }
                    if (this.BorderElement != null)
                    {
                        this.BorderElement.ElementReorder(1000);
                    }
                    this.AddInputFiles();
                    Thread.Sleep(500);
                    this.StartWriter();
                }
                else
                {
                    System.Windows.MessageBox.Show("Include guest images or video in processing list", "DigiPhoto", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void UpdatePageListTime()
        {
            int num;
            if (!false)
            {
                num = 0;
            }
            IEnumerator<VideoPage> expr_162 = (from o in this.PrintOrderPageList.Where(delegate(VideoPage o)
            {
                int arg_0D_0;
                if (o.Name != null)
                {
                    arg_0D_0 = o.Name.Length;
                    goto IL_0C;
                }
                int arg_41_0 = 0;
                bool expr_44;
                do
                {
                IL_15:
                    bool flag2 = arg_41_0 != 0;
                    if (!false)
                    {
                    }
                    expr_44 = ((arg_0D_0 = (arg_41_0 = (flag2 ? 1 : 0))) != 0);
                }
                while (8 == 0);
                if (!false)
                {
                    return expr_44;
                }
                goto IL_0F;
            IL_0C:
                arg_41_0 = (arg_0D_0 = ((arg_0D_0 > 0) ? 1 : 0));
            IL_0F:
                if (!false)
                {
                    goto IL_15;
                }
                goto IL_0C;
            })
                                               orderby o.PageNo
                                               select o).GetEnumerator();
            IEnumerator<VideoPage> enumerator;
            if (5 != 0)
            {
                enumerator = expr_162;
            }
            try
            {
                while (true)
                {
                    bool flag = enumerator.MoveNext();
                    int arg_8E_0;
                    bool expr_DB = (arg_8E_0 = (flag ? 1 : 0)) != 0;
                    if (false)
                    {
                        goto IL_89;
                    }
                    if (!expr_DB)
                    {
                        break;
                    }
                    VideoPage current;
                    if (2 != 0)
                    {
                        current = enumerator.Current;
                        current.InsertTime = (double)num;
                        arg_8E_0 = current.MediaType;
                        goto IL_89;
                    }
                    goto IL_BE;
                    int arg_91_0;
                    bool expr_94;
                    do
                    {
                    IL_90:
                        flag = (arg_91_0 == 0);
                        expr_94 = ((arg_91_0 = (flag ? 1 : 0)) != 0);
                    }
                    while (false);
                    if (expr_94)
                    {
                        goto IL_BE;
                    }
                    current.videoStartTime = num;
                    current.videoEndTime = num + current.ImageDisplayTime;
                    num += current.ImageDisplayTime;
                    continue;
                IL_89:
                    arg_91_0 = ((arg_8E_0 == 601) ? 1 : 0);
                    goto IL_90;
                IL_BE:
                    int expr_BF = arg_91_0 = num;
                    if (3 == 0)
                    {
                        goto IL_90;
                    }
                    num = expr_BF + (current.videoEndTime - current.videoStartTime);
                }
            }
            finally
            {
                do
                {
                    if (enumerator != null)
                    {
                        enumerator.Dispose();
                    }
                }
                while (false);
            }
            if (!false)
            {
                this.pbProgress.Maximum = (double)this.CalculateProcessedVideoLength();
            }
            this.vidLength = (decimal)this.pbProgress.Maximum;
        }

        private void ClearAllControl()
        {
            try
            {
                int num;
                if (!false)
                {
                    do
                    {
                        this.lstStreamDetails.Clear();
                    }
                    while (-1 == 0);
                    this.m_objMixer.StreamsGetCount(out num);
                }
                try
                {
                    int num2 = 0;
                    while (!false && num2 < num)
                    {
                        this.m_objMixer.StreamsRemoveByIndex(0, 0, 0.0);
                        num2++;
                    }
                }
                catch
                {
                }
                this.m_objWriter.ObjectClose();
                do
                {
                    this.VideoEditPlayerPanel.Visibility = Visibility.Visible;
                    this.vidoriginal.Visibility = Visibility.Collapsed;
                    this.VideoEditPlayerPanel.IsEnabled = false;
                }
                while (false);
                this.DisableControls();
            }
            catch (Exception serviceException)
            {
                string message;
                if (!false)
                {
                    message = ErrorHandler.CreateErrorMessage(serviceException);
                }
                if (!false)
                {
                    ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void loadScene(int sceneId)
        {
            try
            {
                this.m_pMPersist = (MCHROMAKEYLib.IMPersist)this.m_objMixer;
                string text = ConfigManager.DigiFolderPath;
                bool flag = !this.AutomatedVideoEditWorkFlow;
                if (!true)
                {
                    goto IL_CA;
                }
                if (flag)
                {
                    goto IL_5B;
                }
            IL_45:
                text += "Profiles\\DefaultProfiles\\StandardScene_overlay.xml";
                if (true)
                {
                    goto IL_69;
                }
                goto IL_C2;
            IL_5B:
                text += "Profiles\\DefaultProfiles\\StandardScene_concatenate.xml";
            IL_69:
                if (!File.Exists(text))
                {
                    if (6 == 0)
                    {
                        goto IL_45;
                    }
                    System.Windows.MessageBox.Show("No video scene settings found!\n", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
                    if (!false)
                    {
                        goto IL_F2;
                    }
                    goto IL_45;
                }
            IL_77:
                if (false)
                {
                    goto IL_5B;
                }
                this.m_pMPersist.PersistLoad("", text, "");
                this.mMixerList1.UpdateList(true, 1);
                this.mElementsTree1.UpdateTree(false);
                this.m_objMixer.StreamsRemoveByIndex(0, 0, 0.0);
            IL_C2:
                this.GetGuestElement();
            IL_CA:
                if (false)
                {
                    goto IL_77;
                }
            IL_F2: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void AddInputFiles()
        {
            while (!true)
            {
            }
            foreach (VideoPage expr_A7 in from o in this.PrintOrderPageList
                                          where o.FilePath != "" && o.FilePath != null
                                          orderby o.InsertTime
                                          select o)
            {
                VideoPage videoPage;
                if (!false)
                {
                    videoPage = expr_A7;
                }
                this.AddFile(videoPage.DropVideoPath, (double)videoPage.videoStartTime, (double)videoPage.videoEndTime, videoPage.InsertTime, videoPage.MediaType);
            }
            IEnumerator<TemplateListItems> enumerator2 = (from o in this.objTemplateList.Where(delegate(TemplateListItems o)
            {
                bool result;
                while (8 != 0)
                {
                    bool arg_3A_0;
                    if (o.MediaType == 604)
                    {
                        arg_3A_0 = o.IsChecked;
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
                        arg_3A_0 = false;
                    }
                    result = arg_3A_0;
                    break;
                }
                return result;
            })
                                                          orderby o.InsertTime
                                                          select o).GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    TemplateListItems current = enumerator2.Current;
                    this.IsExternalAudio = true;
                    string empty = string.Empty;
                    MItem mItem;
                    this.m_objMixer.StreamsBackgroundGet(out empty, out mItem);
                    bool arg_14B_0 = mItem == null;
                    bool expr_14D;
                    do
                    {
                        bool flag = arg_14B_0;
                        expr_14D = (arg_14B_0 = flag);
                    }
                    while (false);
                    if (!expr_14D)
                    {
                        ((MPLATFORMLib.IMProps)mItem).PropsSet("object::audio_gain", "-100");
                    }
                    string filePath = LoginUser.DigiFolderAudioPath + System.IO.Path.GetFileName(current.Name.ToString());
                    this.AddFile(filePath, (double)current.StartTime, (double)current.EndTime, (double)current.InsertTime, 604);
                }
            }
            finally
            {
                bool flag = enumerator2 == null;
                while (!flag)
                {
                    enumerator2.Dispose();
                    if (!false)
                    {
                        break;
                    }
                }
            }
            enumerator2 = this.objTemplateList.Where(delegate(TemplateListItems o)
            {
                bool result;
                while (8 != 0)
                {
                    bool arg_3A_0;
                    if (o.MediaType == 608)
                    {
                        arg_3A_0 = o.IsChecked;
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
                        arg_3A_0 = false;
                    }
                    result = arg_3A_0;
                    break;
                }
                return result;
            }).GetEnumerator();
            try
            {
                while (true)
                {
                    bool arg_258_0 = enumerator2.MoveNext();
                    bool expr_25A;
                    do
                    {
                        bool flag = arg_258_0;
                        expr_25A = (arg_258_0 = flag);
                    }
                    while (false);
                    if (!expr_25A)
                    {
                        break;
                    }
                    TemplateListItems current = enumerator2.Current;
                    string filePath = LoginUser.DigiFolderFramePath + System.IO.Path.GetFileName(current.Name.ToString());
                    this.AddFile(filePath, (double)current.StartTime, (double)current.EndTime, (double)current.InsertTime, 608);
                }
            }
            finally
            {
                if (enumerator2 != null)
                {
                    enumerator2.Dispose();
                }
            IL_275:
                if (false)
                {
                    goto IL_275;
                }
            }
            enumerator2 = this.objTemplateList.Where(delegate(TemplateListItems o)
            {
                bool result;
                while (8 != 0)
                {
                    bool arg_3A_0;
                    if (o.MediaType == 609)
                    {
                        arg_3A_0 = o.IsChecked;
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
                        arg_3A_0 = false;
                    }
                    result = arg_3A_0;
                    break;
                }
                return result;
            }).GetEnumerator();
            try
            {
                while (enumerator2.MoveNext())
                {
                    TemplateListItems current = enumerator2.Current;
                    if (!false)
                    {
                        string filePath2 = LoginUser.DigiFolderVideoOverlayPath + System.IO.Path.GetFileName(current.Name.ToString());
                        this.AddFile(filePath2, (double)current.StartTime, (double)current.EndTime, (double)current.InsertTime, 609);
                    }
                }
            }
            finally
            {
                bool arg_30F_0 = enumerator2 == null;
                bool expr_311;
                do
                {
                    bool flag = arg_30F_0;
                    expr_311 = (arg_30F_0 = flag);
                }
                while (3 == 0);
                if (!expr_311)
                {
                    enumerator2.Dispose();
                }
            }
        }

        private void AddFile(string filePath, double InTime, double OutTime, double InsertTime, int MediaType)
        {
            if (!false)
            {
                try
                {
                    this.m_pMixerStreams = this.m_objMixer;
                    MItem mItem = null;
                    string empty = string.Empty;
                    goto IL_2C;
                    try
                    {
                        while (true)
                        {
                        IL_2C:
                            int num;
                            bool flag;
                            if (7 != 0)
                            {
                                this.m_pMixerStreams.StreamsAdd(empty, null, filePath, "", out mItem, this.numericTimeForChange);
                                this.m_pMixerStreams.StreamsGetCount(out num);
                                this.m_pMixerStreams.StreamsGetByIndex(num - 1, out empty, out mItem);
                                flag = (MediaType == 601);
                            }
                            if (!flag)
                            {
                                this.InitializeStream(empty, true);
                            }
                            StreamList streamList = new StreamList();
                            streamList.Index = num;
                            streamList.streamName = empty;
                            streamList.Isprocessed = false;
                            streamList.In = InTime;
                            streamList.Out = OutTime;
                            streamList.InsertTime = InsertTime;
                            while (true)
                            {
                                streamList.MediaType = MediaType;
                                this.lstStreamDetails.Add(streamList);
                                if (3 == 0)
                                {
                                    break;
                                }
                                flag = (num != 1);
                                if (!flag)
                                {
                                    this.strGuestStreamID = empty;
                                }
                                double dblIn = MHelpers.ParsePos(InTime.ToString());
                                double dblOut = MHelpers.ParsePos(OutTime.ToString());
                                mItem.FileInOutSet(dblIn, dblOut);
                                flag = (!this.IsLoadChroma && !this.IsLoadOverlayChroma);
                                if (!flag)
                                {
                                    if (string.IsNullOrEmpty(this.CurrentchromaSetting))
                                    {
                                        goto IL_16C;
                                    }
                                    int arg_161_0;
                                    int arg_161_1;
                                    if (MediaType != 601)
                                    {
                                        arg_161_0 = MediaType;
                                        arg_161_1 = 602;
                                        goto IL_161;
                                    }
                                    goto IL_18B;
                                IL_18C:
                                    int arg_18D_0;
                                    flag = (arg_18D_0 != 0);
                                    if (!flag)
                                    {
                                        arg_161_0 = MediaType;
                                        int expr_19B = arg_161_1 = 609;
                                        if (expr_19B == 0)
                                        {
                                            goto IL_161;
                                        }
                                        bool expr_19E = (arg_18D_0 = ((MediaType == expr_19B) ? 1 : 0)) != 0;
                                        if (false)
                                        {
                                            goto IL_185;
                                        }
                                        flag = !expr_19E;
                                        if (!flag)
                                        {
                                            this.LoadChromaString(mItem, this.overlayChromaSetting);
                                        }
                                        else
                                        {
                                            this.LoadChromaString(mItem, this.CurrentchromaSetting);
                                        }
                                    }
                                    goto IL_1CC;
                                IL_18B:
                                    arg_18D_0 = 0;
                                IL_188:
                                    goto IL_18C;
                                IL_16C:
                                    if (!string.IsNullOrEmpty(this.overlayChromaSetting))
                                    {
                                        arg_18D_0 = ((MediaType != 609) ? 1 : 0);
                                    }
                                    else
                                    {
                                        arg_18D_0 = 1;
                                    }
                                IL_185:
                                    goto IL_188;
                                IL_161:
                                    if (arg_161_0 != arg_161_1 && MediaType != 607)
                                    {
                                        goto IL_16C;
                                    }
                                    goto IL_18B;
                                }
                            IL_1CC:
                                if (5 != 0)
                                {
                                    goto Block_19;
                                }
                            }
                        }
                    Block_19: ;
                    }
                    catch (Exception)
                    {
                        do
                        {
                            System.Windows.MessageBox.Show("File " + filePath + " can't be added as stream");
                        }
                        while (4 == 0);
                    }
                    try
                    {
                        bool flag = mItem == null;
                        if (!flag)
                        {
                            this.mMixerList1.SelectFile(mItem);
                        }
                    }
                    catch
                    {
                    }
                    this.mMixerList1.UpdateList(true, 1);
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        string message = ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.LogFileWrite(message);
                    }
                    while (false);
                }
            }
        }

        private void LoadChromaString(MItem pFile, string ChromaString)
        {
            MCHROMAKEYLib.MChromaKey mChromaKey = this.LoadChromaPlugin(true, pFile, 1);
            try
            {
                if (!false)
                {
                    string empty = string.Empty;
                    ((MPLATFORMLib.IMProps)mChromaKey).PropsGet("gpu_mode", out empty);
                    bool flag;
                    do
                    {
                        flag = string.IsNullOrEmpty(empty);
                    }
                    while (false);
                    if (!flag && -1 != 0)
                    {
                        do
                        {
                            flag = (!empty.ToLower().Equals("0") || empty.ToLower().Equals("true"));
                        }
                        while (false);
                        if (!flag)
                        {
                            ((MPLATFORMLib.IMProps)mChromaKey).PropsSet("gpu_mode", "true");
                        }
                    }
                }
            }
            catch (Exception var_2_BB)
            {
                while (7 == 0)
                {
                }
            }
            (mChromaKey as MCHROMAKEYLib.IMPersist).PersistLoad("", ChromaString, "");
            do
            {
                Marshal.ReleaseComObject(mChromaKey);
                Marshal.ReleaseComObject(pFile);
                GC.Collect();
            }
            while (6 == 0);
        }

        private string GetStreamName(int index)
        {
            string result;
            while (true)
            {
                string text = "stream-000";
                int arg_11_0 = index;
                int arg_0E_0 = index;
                bool expr_49;
                while (true)
                {
                    int arg_11_1;
                    int expr_0B = arg_11_1 = 0;
                    if (expr_0B == 0)
                    {
                        arg_11_0 = ((arg_0E_0 > expr_0B) ? 1 : 0);
                        arg_11_1 = 0;
                    }
                    bool expr_11 = (arg_0E_0 = (arg_11_0 = ((arg_11_0 == arg_11_1) ? 1 : 0))) != 0;
                    if (!false)
                    {
                        bool flag = expr_11;
                        expr_49 = ((arg_0E_0 = (arg_11_0 = (flag ? 1 : 0))) != 0);
                        if (!false)
                        {
                            break;
                        }
                    }
                }
                if (!expr_49)
                {
                    text = "stream-00" + (index - 1).ToString();
                }
            IL_34:
                if (2 != 0)
                {
                    result = text;
                    if (3 != 0)
                    {
                        break;
                    }
                    continue;
                }
                goto IL_34;
            }
            return result;
        }

        private MCHROMAKEYLib.MChromaKey LoadChromaPlugin(bool onloadChroma, object source, int a)
        {
            MCHROMAKEYLib.MChromaKey mChromaKey = null;
            try
            {
                IMPlugins iMPlugins;
                object obj;
                bool flag;
                while (true)
                {
                IL_08:
                    IMPlugins expr_0E = (IMPlugins)source;
                    if (!false)
                    {
                        iMPlugins = expr_0E;
                    }
                    obj = null;
                    flag = false;
                    if (6 != 0)
                    {
                        int num;
                        iMPlugins.PluginsGetCount(out num);
                        for (int i = 0; i < num; i++)
                        {
                            long num2;
                            iMPlugins.PluginsGetByIndex(i, out obj, out num2);
                            bool arg_8B_0;
                            if (!(obj.GetType().Name == "CoMChromaKeyClass"))
                            {
                                if (false)
                                {
                                    goto IL_10E;
                                }
                                arg_8B_0 = !(obj.GetType().Name == "MChromaKeyClass");
                            }
                            else
                            {
                                arg_8B_0 = false;
                            }
                            if (!arg_8B_0 && 5 != 0)
                            {
                                goto Block_6;
                            }
                            if (!true)
                            {
                                goto IL_08;
                            }
                        }
                        goto IL_B5;
                    }
                }
            Block_6:
                flag = true;
            IL_B5:
                bool arg_C9_0;
                if (flag)
                {
                    if (false)
                    {
                        goto IL_EA;
                    }
                    arg_C9_0 = (!onloadChroma || flag);
                }
                else
                {
                    arg_C9_0 = false;
                }
                if (!arg_C9_0)
                {
                    mChromaKey = (MCHROMAKEYLib.MChromaKey)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("FF12951C-DC32-42B7-B676-583883EF574E")));
                }
                else
                {
                    if (flag)
                    {
                        iMPlugins.PluginsRemove(obj);
                        goto IL_10D;
                    }
                    goto IL_10D;
                }
            IL_EA:
                iMPlugins.PluginsAdd(mChromaKey, 0L);
            IL_10D:
            IL_10E: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
                if (2 != 0)
                {
                }
            }
            MCHROMAKEYLib.MChromaKey result = mChromaKey;
            if (!false)
            {
            }
            return result;
        }

        private void LoadWriterSettings(string settings)
        {
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(settings);
                XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("Settings");
                if (elementsByTagName.Count > 0)
                {
                    foreach (XmlNode xmlNode in elementsByTagName)
                    {
                        int selectedIndex;
                        if (-1 != 0)
                        {
                            selectedIndex = Convert.ToInt32(xmlNode.ChildNodes[1].InnerText);
                        }
                        int selectedIndex2 = Convert.ToInt32(xmlNode.ChildNodes[3].InnerText);
                        string innerText = xmlNode.ChildNodes[4].InnerText;
                        string text = xmlNode.ChildNodes[6].InnerText.Trim();
                        string text2 = xmlNode.ChildNodes[5].InnerText.Trim();
                        this.mFormatControl1.comboBoxVideo.SelectedIndex = selectedIndex;
                        this.mFormatControl1.comboBoxAudio.SelectedIndex = selectedIndex2;
                        if (xmlNode.ChildNodes.Count >= 6)
                        {
                            this.VideoSettings = xmlNode.ChildNodes[7].InnerText.Trim();
                        }
                        this.mConfigList1.Columns[1].ListView.Items[0].SubItems[1].Text = innerText;
                        this.mConfigList1.Columns[1].ListView.Items[1].SubItems[1].Text = text2;
                        if (text != "")
                        {
                            this.mConfigList1.Columns[1].ListView.Items[2].SubItems[1].Text = text;
                        }
                        IMAttributes iMAttributes;
                        this.m_objWriter.ConfigSet("format", innerText, out iMAttributes);
                        int num = 0;
                        string empty = string.Empty;
                        iMAttributes.AttributesHave("extensions", out num, out empty);
                        string[] array = empty.Split(new char[]
						{
							','
						});
                        this.outputFormat = array[0];
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void VidTimer_Tick(object sender, EventArgs e)
        {
            decimal num = 0m;
            this.UpdateStatus(this.m_objWriter, out num);
            if (8 == 0)
            {
                goto IL_D5;
            }
            eMState eMState;
            this.m_objWriter.ObjectStateGet(out eMState);
            if (false)
            {
                goto IL_12D;
            }
            this.pbProgress.Value = Convert.ToDouble(num);
            if (!this.thumCaptured && num > 0.50m)
            {
                this.ExtractThumbnail();
                this.thumCaptured = true;
            }
            bool flag = !(num >= this.vidLength);
            if (!flag)
            {
                this.StopWriter(false);
                if (5 != 0)
                {
                    return;
                }
            }
            else
            {
                flag = ((double)num < this.NextItemStartTime);
            }
            bool arg_D0_0 = flag;
        IL_D0:
            if (arg_D0_0)
            {
                goto IL_1E2;
            }
        IL_D5:
            int inx2 = (from o in this.lstStreamDetails
                        where o.streamName == this.CurrentITemStream
                        select o).FirstOrDefault<StreamList>().Index;
            StreamList streamList = this.lstStreamDetails.Where(delegate(StreamList o)
            {
                bool result;
                if (!false)
                {
                    int arg_10_0 = o.Index;
                    int arg_0F_0 = inx2;
                    bool arg_4B_0;
                    while (arg_10_0 == arg_0F_0 + 1)
                    {
                        if (4 == 0)
                        {
                            return result;
                        }
                        int expr_1E = arg_10_0 = ((o.MediaType == 604) ? 1 : 0);
                        int expr_21 = arg_0F_0 = 0;
                        if (expr_21 == 0)
                        {
                            arg_4B_0 = (expr_1E == expr_21);
                            if (2 != 0)
                            {
                            IL_2C: ;
                            }
                            result = arg_4B_0;
                            return result;
                        }
                    }
                    arg_4B_0 = false;
                    goto IL_2C;
                }
                return result;
            }).FirstOrDefault<StreamList>();
        IL_12D:
            bool expr_12F = arg_D0_0 = (streamList == null);
            if (false)
            {
                goto IL_D0;
            }
            flag = expr_12F;
            bool arg_138_0 = flag;
        IL_138:
            if (arg_138_0)
            {
                goto IL_1E1;
            }
            string streamName = streamList.streamName;
            int arg_150_0 = streamList.MediaType;
        IL_14B:
            flag = (arg_150_0 == 601);
            bool expr_154 = arg_138_0 = flag;
            if (false)
            {
                goto IL_138;
            }
            if (!expr_154)
            {
                if (false)
                {
                    goto IL_227;
                }
                this.InitializeStream(streamName, false);
            }
            if (this.IsExternalAudio)
            {
                this.GuestElement.ElementMultipleSet("stream_id=" + streamName + " audio_gain=-100 show=true", this.numericTimeForChange);
            }
            else
            {
                this.GuestElement.ElementMultipleSet("stream_id=" + streamName + " audio_gain=1 show=true", this.numericTimeForChange);
            }
            this.CurrentITemStream = streamName;
            this.NextItemStartTime = streamList.InsertTime + (streamList.Out - streamList.In);
        IL_1E1:
        IL_1E2:
            if (this.NextAudioStartTime == 0.0 || (double)num < this.NextAudioStartTime)
            {
                goto IL_362;
            }
            if (string.IsNullOrEmpty(this.CurrentAudioStream))
            {
                goto IL_361;
            }
        IL_227:
            int inx = (from o in this.lstStreamDetails
                       where o.streamName == this.CurrentAudioStream
                       select o).FirstOrDefault<StreamList>().Index;
            StreamList sl = this.lstStreamDetails.Where(delegate(StreamList o)
            {
                int arg_48_0;
                int arg_10_0;
                int arg_21_0 = arg_10_0 = (arg_48_0 = o.Index);
                if (false)
                {
                    goto IL_16;
                }
                int arg_0F_0 = inx;
            IL_0E:
                if (arg_10_0 != arg_0F_0 + 1)
                {
                    arg_48_0 = 0;
                    goto IL_26;
                }
                arg_21_0 = (arg_10_0 = (arg_48_0 = o.MediaType));
            IL_16:
                if (!false)
                {
                    int expr_1E = arg_0F_0 = 604;
                    if (expr_1E == 0)
                    {
                        goto IL_0E;
                    }
                    arg_48_0 = ((arg_21_0 == expr_1E) ? 1 : 0);
                }
            IL_23:
            IL_26:
                bool flag2 = arg_48_0 != 0;
                bool expr_4B = (arg_48_0 = (flag2 ? 1 : 0)) != 0;
                if (!false)
                {
                    return expr_4B;
                }
                goto IL_23;
            }).FirstOrDefault<StreamList>();
            flag = (sl == null);
            bool expr_291 = (arg_150_0 = (flag ? 1 : 0)) != 0;
            if (6 == 0)
            {
                goto IL_14B;
            }
            if (!expr_291)
            {
                streamName = sl.streamName;
                this.InitializeStream(streamName, false);
                this.AudioElement.ElementMultipleSet("stream_id=" + streamName + " audio_gain=1", 0.0);
                StreamList streamList2 = this.lstStreamDetails.Where(delegate(StreamList o)
                {
                    int arg_09_0 = o.MediaType;
                    int arg_51_0;
                    do
                    {
                        if (arg_09_0 != 604 && !false)
                        {
                            arg_51_0 = (arg_09_0 = 0);
                        }
                        else
                        {
                            int arg_1D_0 = arg_09_0 = (arg_51_0 = o.Index);
                            do
                            {
                                if (!false)
                                {
                                    arg_1D_0 = (arg_09_0 = (arg_51_0 = ((arg_1D_0 == sl.Index + 1) ? 1 : 0)));
                                }
                            }
                            while (false);
                        }
                    }
                    while (false);
                    return arg_51_0 != 0;
                }).FirstOrDefault<StreamList>();
                if (streamList2 != null)
                {
                    this.NextAudioStartTime = streamList2.InsertTime;
                }
                else
                {
                    this.NextAudioStartTime = 0.0;
                }
                this.CurrentAudioStream = streamName;
                this.CurrentAudioStoptTime = sl.InsertTime + (sl.Out - sl.In);
            }
        IL_361:
        IL_362:
            double arg_371_0 = this.CurrentAudioStoptTime;
            bool arg_389_0;
            while (arg_371_0 != 0.0)
            {
                double expr_374 = arg_371_0 = (double)num;
                if (!false)
                {
                    arg_389_0 = (expr_374 < this.CurrentAudioStoptTime);
                IL_388:
                    if (!arg_389_0)
                    {
                        this.InitializeStream(this.CurrentAudioStream, true);
                    }
                    return;
                }
            }
            arg_389_0 = true;
            goto IL_388;
        }

        private string GetElementInformation(string strAttributes, string PropRequired)
        {
            string result = string.Empty;
            try
            {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(strAttributes);
                while (true)
                {
                IL_26:
                    XmlNode firstChild = xmlDocument.FirstChild;
                    int arg_36_0 = 0;
                    while (true)
                    {
                    IL_36:
                        int num = arg_36_0;
                        while (true)
                        {
                            int arg_A0_0;
                            int arg_76_0;
                            int arg_7C_0 = arg_76_0 = (arg_A0_0 = num);
                            int expr_81;
                            while (true)
                            {
                                bool flag;
                                int arg_AC_0;
                                if (2 != 0)
                                {
                                    if (6 == 0)
                                    {
                                        goto IL_75;
                                    }
                                    bool expr_A0 = (arg_36_0 = ((arg_A0_0 < firstChild.Attributes.Count) ? 1 : 0)) != 0;
                                    if (7 != 0)
                                    {
                                        flag = expr_A0;
                                        arg_AC_0 = (flag ? 1 : 0);
                                        goto IL_AC;
                                    }
                                    goto IL_36;
                                }
                            IL_7C:
                                if (arg_7C_0 == 0)
                                {
                                    goto Block_3;
                                }
                                expr_81 = (arg_76_0 = (arg_7C_0 = (arg_A0_0 = (arg_AC_0 = num))));
                                if (false)
                                {
                                    continue;
                                }
                                if (!false)
                                {
                                    break;
                                }
                                goto IL_AC;
                            IL_75:
                                flag = (arg_76_0 == 0);
                                arg_7C_0 = (flag ? 1 : 0);
                                goto IL_7C;
                            IL_AC:
                                if (arg_AC_0 == 0)
                                {
                                    goto IL_B1;
                                }
                                if (7 != 0)
                                {
                                    string a = Convert.ToString(firstChild.Attributes[num].Name);
                                    result = Convert.ToString(firstChild.Attributes[num].Value);
                                    arg_76_0 = ((a == PropRequired) ? 1 : 0);
                                    goto IL_75;
                                }
                                goto IL_26;
                            }
                            num = expr_81 + 1;
                        }
                    }
                }
            Block_3:
            IL_B1: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
            return result;
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
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                do
                {
                    ErrorHandler.LogFileWrite(message);
                }
                while (false);
            }
        }

        private void InitializeStream(string streamId, bool isStop)
        {
            try
            {
                int num = 0;
                MItem mItem;
                this.m_objMixer.StreamsGet(streamId, out num, out mItem);
                if (mItem != null)
                {
                    mItem.FilePosSet(MHelpers.ParsePos("00:00:00"), 1.0);
                    bool arg_55_0 = !isStop;
                    bool expr_5C;
                    do
                    {
                        bool flag = arg_55_0;
                        if (3 == 0)
                        {
                            goto IL_71;
                        }
                        if (false)
                        {
                            goto IL_7C;
                        }
                        expr_5C = (arg_55_0 = flag);
                    }
                    while (false);
                    if (!expr_5C)
                    {
                        mItem.FilePlayStop(0.0);
                    }
                    else
                    {
                        mItem.FilePlayStart();
                    }
                IL_71: ;
                }
            IL_7C: ;
            }
            catch (Exception var_2_BD)
            {
                while (true)
                {
                    while (false || !false)
                    {
                        if (!false)
                        {
                            goto Block_8;
                        }
                    }
                }
            Block_8: ;
            }
        }

        private void GetGuestElement()
        {
            if (8 != 0)
            {
            }
            MElement mElement = null;
            try
            {
                string arg_9B_0 = string.Empty;
                this.m_objMixer.ElementsGetByIndex(0, out mElement);
                IMElements expr_2D = (IMElements)mElement;
                string expr_32 = "Guest_Video";
                if (!false)
                {
                    expr_2D.ElementsGetByID(expr_32, out this.GuestElement);
                }
                while (8 != 0)
                {
                    if (!false)
                    {
                        ((IMElements)mElement).ElementsGetByID("Audio_Video", out this.AudioElement);
                        break;
                    }
                }
                ((IMElements)mElement).ElementsGetByID("Border_Video", out this.BorderElement);
                ((IMElements)mElement).ElementsGetByID("Overlay_Video", out this.OverlayElement);
            }
            catch (Exception var_2_CD)
            {
                if (7 == 0 || -1 != 0)
                {
                }
                while (false)
                {
                }
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

        private void StopWriter(bool isbtnStop)
        {
            if (!false)
            {
                try
                {
                    if (!isbtnStop)
                    {
                        this.StopAllInputFiles();
                    }
                    this.VidTimer.Stop();
                    if (6 != 0)
                    {
                        this.m_objWriter.ObjectClose();
                        this.pbProgress.Value = 0.0;
                    }
                IL_5B:
                    this.EnableControls();
                    do
                    {
                        this.btnStopProcess.IsEnabled = false;
                        if (5 == 0)
                        {
                            goto IL_107;
                        }
                        VideoEditor.vsMediaFileName = this.tempFile;
                        if (isbtnStop)
                        {
                            goto IL_108;
                        }
                        if (2 == 0)
                        {
                            goto IL_5B;
                        }
                        File.Copy(this.tempFile, this.processVideoTemp + "PlayerOutput." + this.outputFormat, true);
                        VideoEditor.vsMediaFileName = this.processVideoTemp + "Output." + this.outputFormat;
                        System.Windows.MessageBox.Show("The video has been processed successfully!", "DigiPhoto", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    while (!true);
                    if (this.AutomatedVideoEditWorkFlow)
                    {
                        this.btnSave_Click(null, null);
                    }
                    else
                    {
                        this.MediaPlay();
                    }
                IL_107:
                IL_108: ;
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        string message = ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.LogFileWrite(message);
                    }
                    while (!true);
                }
            }
        }

        private void StopAllInputFiles()
        {
            string empty = string.Empty;
            int arg_0C_0 = 0;
            while (true)
            {
                int arg_B3_0;
                int expr_0C = arg_B3_0 = arg_0C_0;
                int num;
                if (expr_0C == 0)
                {
                    num = expr_0C;
                    this.m_objMixer.StreamsGetCount(out num);
                    arg_B3_0 = 0;
                }
                int num2 = arg_B3_0;
                while (true)
                {
                    int arg_91_0;
                    if (!false)
                    {
                        bool flag = num2 < num;
                        arg_91_0 = (flag ? 1 : 0);
                        goto IL_91;
                    }
                IL_47:
                    MItem mItem;
                    try
                    {
                        if (7 == 0 || mItem != null)
                        {
                            mItem.FilePlayStop(1.0);
                        }
                    }
                    catch
                    {
                    }
                    int arg_85_0;
                    int expr_76 = arg_0C_0 = (arg_85_0 = (arg_91_0 = num2));
                    if (-1 != 0)
                    {
                        arg_85_0 = (arg_0C_0 = (arg_91_0 = expr_76 + 1));
                    }
                    if (7 == 0)
                    {
                        break;
                    }
                    if (8 != 0)
                    {
                        num2 = arg_85_0;
                        continue;
                    }
                IL_91:
                    if (arg_91_0 == 0)
                    {
                        return;
                    }
                    this.m_objMixer.StreamsGetByIndex(num2, out empty, out mItem);
                    goto IL_47;
                }
            }
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

        private void Initilizebackground()
        {
            if (!false)
            {
                string empty = string.Empty;
                do
                {
                    MItem mItem;
                    this.m_objMixer.StreamsBackgroundGet(out empty, out mItem);
                    bool arg_28_0;
                    bool arg_63_0 = arg_28_0 = (mItem == null);
                    do
                    {
                        if (!false)
                        {
                            bool flag = arg_63_0;
                            arg_63_0 = (arg_28_0 = flag);
                        }
                    }
                    while (7 == 0);
                    if (arg_28_0)
                    {
                        break;
                    }
                    IMItem expr_69 = mItem;
                    double expr_6C = MHelpers.ParsePos("00:00:00");
                    double expr_34 = 1.0;
                    if (!false)
                    {
                        expr_69.FilePosSet(expr_6C, expr_34);
                    }
                    while (2 == 0)
                    {
                    }
                    mItem.FilePlayStart();
                }
                while (3 == 0);
            }
        }

        private void StartWriter()
        {
            this.VidTimer.Start();
            while (true)
            {
                this.mFormatControl1.SetControlledObjectForMWriter(this.m_objMixer);
                while (true)
                {
                    eMState eMState;
                    this.m_objWriter.ObjectStateGet(out eMState);
                    if (eMState == eMState.eMS_Paused)
                    {
                        this.m_objWriter.ObjectStart(this.m_objMixer);
                    }
                IL_65:
                    if (eMState == eMState.eMS_Running)
                    {
                        goto Block_2;
                    }
                    if (false)
                    {
                        return;
                    }
                    this.CurrentITemStream = "stream-000";
                    StreamList streamList = (from o in this.lstStreamDetails
                                             where o.streamName == "stream-000"
                                             select o).FirstOrDefault<StreamList>();
                    this.NextItemStartTime = streamList.InsertTime + (streamList.Out - streamList.In);
                    this.InitializeStream(this.CurrentITemStream, false);
                    if (this.IsExternalAudio)
                    {
                        this.GuestElement.ElementMultipleSet("stream_id=" + this.CurrentITemStream + " audio_gain=-100 show=true", this.numericTimeForChange);
                    }
                    else
                    {
                        this.GuestElement.ElementMultipleSet("stream_id=" + this.CurrentITemStream + " audio_gain=1 show=true", this.numericTimeForChange);
                    }
                    StreamList slAudio = (from o in this.lstStreamDetails
                                          where o.MediaType == 604
                                          select o).FirstOrDefault<StreamList>();
                    if (!false)
                    {
                        if (slAudio != null)
                        {
                            StreamList streamList2 = this.lstStreamDetails.Where(delegate(StreamList o)
                            {
                                int arg_09_0 = o.MediaType;
                                int arg_51_0;
                                do
                                {
                                    if (arg_09_0 != 604 && !false)
                                    {
                                        arg_51_0 = (arg_09_0 = 0);
                                    }
                                    else
                                    {
                                        int arg_1D_0 = arg_09_0 = (arg_51_0 = o.Index);
                                        do
                                        {
                                            if (!false)
                                            {
                                                arg_1D_0 = (arg_09_0 = (arg_51_0 = ((arg_1D_0 == slAudio.Index + 1) ? 1 : 0)));
                                            }
                                        }
                                        while (false);
                                    }
                                }
                                while (false);
                                return arg_51_0 != 0;
                            }).FirstOrDefault<StreamList>();
                            if (streamList2 != null)
                            {
                                this.NextAudioStartTime = streamList2.InsertTime;
                            }
                            else
                            {
                                this.NextAudioStartTime = 0.0;
                            }
                            this.CurrentAudioStream = slAudio.streamName;
                            this.CurrentAudioStoptTime = slAudio.InsertTime + (slAudio.Out - slAudio.In);
                            if (slAudio.InsertTime == 0.0)
                            {
                                if (false)
                                {
                                    break;
                                }
                                this.AudioElement.ElementMultipleSet("stream_id=" + this.CurrentAudioStream + " audio_gain=1", 0.0);
                                this.InitializeStream(this.CurrentAudioStream, false);
                            }
                        }
                        StreamList streamList3 = (from o in this.lstStreamDetails
                                                  where o.MediaType == 608
                                                  select o).FirstOrDefault<StreamList>();
                        if (streamList3 != null)
                        {
                            this.BorderElement.ElementMultipleSet("stream_id=" + streamList3.streamName + " audio_gain=-100 show=true h=1 w=1 x=0 y=0", 0.0);
                            this.InitializeStream(streamList3.streamName, false);
                        }
                        if (4 != 0)
                        {
                            goto Block_15;
                        }
                        continue;
                    }
                    goto IL_65;
                }
            }
        Block_2:
            this.m_objWriter.WriterNameSet("", "");
            return;
        Block_15:
            StreamList streamList4 = (from o in this.lstStreamDetails
                                      where o.MediaType == 609
                                      select o).FirstOrDefault<StreamList>();
            if (streamList4 != null)
            {
                this.OverlayElement.ElementMultipleSet("stream_id=" + streamList4.streamName + " audio_gain=-100 show=true h=1 w=1 x=0 y=0", 0.0);
                this.InitializeStream(streamList4.streamName, false);
                this.strOverlayStream = streamList4.streamName;
            }
            this.Initilizebackground();
            Thread.Sleep(500);
            string text;
            IMAttributes iMAttributes;
            this.m_objWriter.ConfigGet("format", out text, out iMAttributes);
            this.tempFile = this.processVideoTemp + "Output." + this.outputFormat;
            try
            {
                this.m_objWriter.WriterNameSet(this.tempFile, (this.VideoSettings != "") ? this.VideoSettings : "audio::bitrate=256K video::bitrate=30M video::codec=mpeg4 gop_size=1 qmin=1 qscale=1 v422=true");
                this.m_objWriter.ObjectStart(this.m_objMixer);
                if (8 != 0)
                {
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void ExtractThumbnail()
        {
            do
            {
                if (2 != 0)
                {
                    try
                    {
                        MFrame mFrame;
                        this.m_objMixer.ObjectFrameGet(out mFrame, "");
                        while (true)
                        {
                            this.path_tempThumbnail = this.processVideoTemp + "Output.jpg";
                            int arg_41_0 = File.Exists(this.path_tempThumbnail) ? 1 : 0;
                            while (true)
                            {
                                if (arg_41_0 != 0)
                                {
                                    if (6 != 0)
                                    {
                                    }
                                    File.Delete(this.path_tempThumbnail);
                                    if (!true)
                                    {
                                        break;
                                    }
                                }
                                mFrame.FrameVideoSaveToFile(this.path_tempThumbnail);
                                arg_41_0 = Marshal.ReleaseComObject(mFrame);
                                if (2 != 0)
                                {
                                    goto Block_4;
                                }
                            }
                        }
                    Block_4: ;
                    }
                    catch (Exception serviceException)
                    {
                        string message = ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.LogFileWrite(message);
                        while (false)
                        {
                        }
                    }
                }
            }
            while (4 == 0);
        }

        private void buttonChromaProps_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                while (false)
                {
                }
                int num = 0;
                MItem mItem;
                this.m_objMixer.StreamsGet(this.strGuestStreamID, out num, out mItem);
                string path;
                mItem.FileNameGet(out path);
                bool flag;
                if (true)
                {
                    flag = (!(System.IO.Path.GetExtension(path).ToLower() != ".jpg") || !(System.IO.Path.GetExtension(path).ToLower() != ".png"));
                }
                if (!false && flag)
                {
                    goto IL_87;
                }
            IL_79:
                this.InitializeStream(this.strGuestStreamID, false);
            IL_87:
                flag = (mItem == null);
                if (!flag)
                {
                    MLHelpers mLHelpers = new MLHelpers();
                    VideoEditor.objChromaKey = mLHelpers.LoadChromaScreen(mItem, this.strGuestStreamID);
                    flag = (VideoEditor.objChromaKey == null);
                    if (false)
                    {
                        goto IL_79;
                    }
                    if (!flag)
                    {
                        this.IsLoadChroma = true;
                        this.CurrentchromaSetting = this.SaveChromaSetting(mItem);
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message;
                while (!false)
                {
                    if (3 != 0)
                    {
                        message = ErrorHandler.CreateErrorMessage(serviceException);
                        break;
                    }
                }
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void LoadChromaPlugin(bool onloadChroma, object source)
        {
            try
            {
                bool arg_10D_0 = source == null;
                while (!arg_10D_0)
                {
                    IMPlugins iMPlugins = source as IMPlugins;
                    object obj = null;
                    int arg_12D_0 = 0;
                    bool flag;
                    int num;
                    int expr_43;
                    do
                    {
                        flag = (arg_12D_0 != 0);
                        iMPlugins.PluginsGetCount(out num);
                        expr_43 = (arg_12D_0 = 0);
                    }
                    while (expr_43 != 0);
                    bool arg_AD_0 = expr_43 != 0;
                    if (expr_43 != 0)
                    {
                        goto IL_AD;
                    }
                    bool arg_B4_0 = expr_43 != 0;
                    int num2;
                    if (expr_43 == 0)
                    {
                        num2 = expr_43;
                        goto IL_A4;
                    }
                IL_B4:
                    int arg_C9_0;
                    if (arg_B4_0)
                    {
                        arg_10D_0 = (((!onloadChroma) ? (arg_C9_0 = 1) : (arg_C9_0 = (flag ? 1 : 0))) != 0);
                        if (6 == 0)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        arg_C9_0 = 0;
                    }
                    bool flag2 = arg_C9_0 != 0;
                    if (-1 == 0)
                    {
                        break;
                    }
                    if (!flag2)
                    {
                        iMPlugins.PluginsAdd((MCHROMAKEYLib.MChromaKey)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("FF12951C-DC32-42B7-B676-583883EF574E"))), 0L);
                        goto IL_F4;
                    }
                    goto IL_F6;
                IL_AD:
                    if (arg_AD_0)
                    {
                        long num3;
                        iMPlugins.PluginsGetByIndex(num2, out obj, out num3);
                        if (!(obj.GetType().Name == "CoMChromaKeyClass") && !(obj.GetType().Name == "MChromaKeyClass"))
                        {
                            num2++;
                            goto IL_A4;
                        }
                        flag = true;
                    }
                    if (!false)
                    {
                        arg_B4_0 = flag;
                        goto IL_B4;
                    }
                    goto IL_F4;
                IL_A4:
                    flag2 = (num2 < num);
                    arg_AD_0 = flag2;
                    goto IL_AD;
                IL_F4:
                IL_F6:
                    this.buttonChromaProps.IsEnabled = true;
                    break;
                }
            }
            catch (Exception serviceException)
            {
                if (5 != 0)
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                do
                {
                    this.MediaStop();
                    this.lstVideoPage = this.PrintOrderPageList.ToList<VideoPage>();
                    Window expr_16 = this.bs;
                    if (!false)
                    {
                        expr_16.Show();
                    }
                }
                while (false);
                this.bwSaveVideos.RunWorkerAsync();
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void bwSaveVideos_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            while (true)
            {
                this.bs.Hide();
                while (true)
                {
                    if (!false)
                    {
                        this.ClearVideoEditPlayer();
                        goto IL_12;
                    }
                IL_16:
                    if (!false)
                    {
                        this.ShowVOS();
                    }
                    if (!false)
                    {
                        if (!false)
                        {
                            return;
                        }
                        continue;
                    }
                IL_12:
                    if (!false)
                    {
                        goto IL_16;
                    }
                    break;
                }
            }
        }

        private void bwSaveVideos_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                bool expr_0B = !File.Exists(this.tempFile);
                bool flag;
                if (!false)
                {
                    flag = expr_0B;
                }
                if (!flag)
                {
                    if (false || !false)
                    {
                        this.saveOutputVideo();
                    }
                    if (!false)
                    {
                        break;
                    }
                }
                if (7 != 0)
                {
                    goto Block_3;
                }
            }
            return;
        Block_3:
            System.Windows.MessageBox.Show("Video not found!\n", "Video Editor", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
        }

        private void saveOutputVideo()
        {
            try
            {
                VideoPage videoPage = (from o in this.lstVideoPage
                                       where o.MediaType != 0
                                       orderby o.PageNo
                                       select o).FirstOrDefault<VideoPage>();
                if (videoPage != null)
                {
                    PhotoBusiness photoBusiness = new PhotoBusiness();
                    string text = LoginUser.DigiFolderPath + "ProcessedVideos\\" + DateTime.Now.ToString("yyyyMMdd");
                    string destFileName = string.Concat(new string[]
					{
						text,
						"\\",
						videoPage.Name,
						"_",
						DateTime.Now.ToString("HH:mm").Replace(":", ""),
						".",
						this.outputFormat
					});
                    string text2 = string.Concat(new string[]
					{
						videoPage.Name,
						"_",
						DateTime.Now.ToString("HH:mm").Replace(":", ""),
						".",
						this.outputFormat
					});
                    string text3 = System.IO.Path.Combine(LoginUser.DigiFolderPath, "Thumbnails", DateTime.Now.ToString("yyyyMMdd"));
                    if (!Directory.Exists(text))
                    {
                        Directory.CreateDirectory(text);
                    }
                    if (!Directory.Exists(text3))
                    {
                        Directory.CreateDirectory(text3);
                    }
                    if (File.Exists(this.tempFile))
                    {
                        File.Copy(this.tempFile, destFileName, true);
                    }
                    if (File.Exists(this.path_tempThumbnail))
                    {
                        this.ResizeWPFImage(this.path_tempThumbnail, 210, System.IO.Path.Combine(text3, System.IO.Path.GetFileNameWithoutExtension(text2) + ".jpg"));
                    }
                    PhotoCaptureInfo photoCaptureInfo = new PhotoBusiness().GetphotoCapturedetails(videoPage.PhotoId).FirstOrDefault<PhotoCaptureInfo>();
                    int locationId = photoCaptureInfo.LocationId;
                    int num = photoBusiness.SetPhotoDetails(ConfigManager.SubStoreId, videoPage.Name, text2, DateTime.Now, LoginUser.UserId.ToString(), "", locationId, string.Empty, string.Empty, null, null, 1, null, new long?((long)this.vidLength), true, new int?(3), new int?(0), null, 0, false);
                    if (num > 0)
                    {
                        this.VideoAssociation(videoPage.PhotoId, num);
                        System.Windows.MessageBox.Show("Video saved successfully!\n", "Video Editor", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
                    }
                    if (this.isGroup)
                    {
                        LstMyItems lstMyItems = new LstMyItems();
                        lstMyItems.MediaType = 3;
                        lstMyItems.VideoLength = new long?(this.objProcVideoInfo.VideoLength);
                        lstMyItems.FilePath = text3 + "\\" + text2.Replace(".avi", ".jpg").Replace(".mp4", ".jpg").Replace(".wmv", ".jpg");
                        lstMyItems.Name = videoPage.Name;
                        lstMyItems.IsPassKeyVisible = Visibility.Collapsed;
                        lstMyItems.PhotoId = videoPage.PhotoId;
                        lstMyItems.FileName = text2;
                        lstMyItems.CreatedOn = DateTime.Now;
                        lstMyItems.IsLocked = Visibility.Visible;
                        lstMyItems.HotFolderPath = LoginUser.DigiFolderPath;
                        if (RobotImageLoader.GroupImages.Count > 0)
                        {
                            lstMyItems.BmpImageGroup = RobotImageLoader.GroupImages[0].BmpImageGroup;
                        }
                        RobotImageLoader.GroupImages.Add(lstMyItems);
                        RobotImageLoader.ViewGroupedImagesCount.Add(lstMyItems.Name);
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void VideoAssociation(int photoId, int videoId)
        {
            if (-1 != 0)
            {
                try
                {
                    AssociateImageBusiness expr_18 = new AssociateImageBusiness();
                    if (4 != 0)
                    {
                        expr_18.AssociateVideos(photoId, videoId);
                    }
                    while (false)
                    {
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.CreateErrorMessage(serviceException);
                    if (!false && !false)
                    {
                        ErrorHandler.LogFileWrite(message);
                    }
                }
            }
        }

        private void ShowVOS()
        {
            SearchResult searchResult;
            while (true)
            {
                RobotImageLoader.RFID = "0";
                RobotImageLoader.SearchCriteria = "PhotoId";
                searchResult = null;
                foreach (Window window in System.Windows.Application.Current.Windows)
                {
                    if (window.Title == "View/Order Station")
                    {
                        searchResult = (SearchResult)window;
                        break;
                    }
                }
                bool flag = searchResult != null;
                if (7 != 0)
                {
                    if (!flag)
                    {
                        searchResult = new SearchResult();
                    }
                    if (!false)
                    {
                        break;
                    }
                }
            }
            if (RobotImageLoader.GroupImages.Count == 0 && this.IsGoupped == "View All")
            {
                this.IsGoupped = "View Group";
            }
            searchResult.pagename = "Saveback";
            searchResult.Savebackpid = Convert.ToString(RobotImageLoader.PrintImages[RobotImageLoader.PrintImages.Count - 1].PhotoId);
            if (this.AutomatedVideoEditWorkFlow)
            {
                if (RobotImageLoader.PrintImages.Count == 1)
                {
                    RobotImageLoader.curItem = (from t in RobotImageLoader.robotImages
                                                where t.PhotoId == RobotImageLoader.PrintImages.FirstOrDefault<LstMyItems>().PhotoId
                                                select t).First<LstMyItems>();
                    if (RobotImageLoader.curItem != null)
                    {
                        RobotImageLoader.curItem.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                    }
                    RobotImageLoader.PrintImages.Clear();
                }
            }
            searchResult.Show();
            searchResult.LoadWindow();
            base.Close();
        }

        private void btnStopProcess_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    while (4 != 0)
                    {
                        this.StopWriter(true);
                        this.EnableControls();
                        while (true)
                        {
                            this.GuestElement.ElementMultipleSet("stream_id=" + this.strGuestStreamID + " audio_gain=-100 show=true", 0.0);
                            if (false)
                            {
                                break;
                            }
                            if (6 != 0)
                            {
                                goto IL_3C;
                            }
                        }
                    }
                IL_3C:
                    this.InitializeStream(this.strGuestStreamID, false);
                }
                catch (Exception var_0_79)
                {
                }
                if (5 != 0)
                {
                }
            }
            while (false);
        }

        private void btnCGEditor_Click(object sender, RoutedEventArgs e)
        {
            this.RemovePlugins();
            this.LoadGraphicEditor();
        }

        private void RemovePlugins()
        {
            if (4 != 0)
            {
                try
                {
                    while (!false)
                    {
                        this.m_objCharGen.RemoveItem("", 1000);
                        if (-1 != 0)
                        {
                            this.m_objMixer.PluginsRemove(this.m_objCharGen);
                        }
                        if (!false)
                        {
                            Marshal.ReleaseComObject(this.m_objCharGen);
                            this.m_strItemID = "";
                            break;
                        }
                    }
                    this.m_objCharGen = null;
                }
                catch (Exception var_0_7E)
                {
                    if (true)
                    {
                    }
                }
            }
        }

        private void RemoveColorPlugins()
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
                        this.m_objMixer.PluginsRemove(this.m_objColors);
                    }
                }
                while (false);
            }
            catch (Exception var_0_2C)
            {
                while (false)
                {
                }
            }
        }

        private void cgEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            do
            {
                if (-1 != 0 && 8 != 0)
                {
                    if (7 == 0)
                    {
                        return;
                    }
                    this.cgEditor.CGConfig -= new EventHandler(this.SaveCGConfig);
                }
            }
            while (false);
            this.cgEditor.FormClosed -= new FormClosedEventHandler(this.cgEditor_FormClosed);
        }

        private void btnDelCGConfig_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.objConfigBL = new ConfigBusiness();
                int arg_21_0 = this.cmbGraphicsSettings.SelectedIndex;
                while (arg_21_0 > 0)
                {
                    int num;
                    CGConfigSettings cGConfigSettings;
                    if (7 != 0)
                    {
                        num = Convert.ToInt32(this.cmbGraphicsSettings.SelectedValue);
                        cGConfigSettings = this.GetCGConfigSettings(num);
                        if (cGConfigSettings == null)
                        {
                            break;
                        }
                    }
                    File.Delete(System.IO.Path.Combine(ConfigManager.DigiFolderPath, "CGSettings", cGConfigSettings.ConfigFileName + cGConfigSettings.Extension));
                    bool flag = this.objConfigBL.DeleteCGConfigSettngs(num);
                    bool expr_94 = (arg_21_0 = (flag ? 1 : 0)) != 0;
                    if (3 == 0)
                    {
                        continue;
                    }
                    if (expr_94)
                    {
                        System.Windows.MessageBox.Show("Graphics profile deleted successfully");
                    }
                    this.BindCGConfigCombo();
                    this._configId = 0;
                    break;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void txtStreamId_LostFocus(object sender, RoutedEventArgs e)
        {
            this.InvalidatePropertyChange((System.Windows.Controls.TextBox)sender, 0.0);
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
            this.txtCropH.Text = (htAttrib.ContainsKey("sh") ? htAttrib["sh"].ToString() : "1.0");
            this.txtCropW.Text = (htAttrib.ContainsKey("sw") ? htAttrib["sw"].ToString() : "1.0");
            this.txtAudioGain.Text = (htAttrib.ContainsKey("audio_gain") ? htAttrib["audio_gain"].ToString() : "+0.0");
            this.txtStreamId.Text = (htAttrib.ContainsKey("stream_id") ? htAttrib["stream_id"].ToString() : "");
            this.drpPosition.SelectedValue = (htAttrib.ContainsKey("pos") ? htAttrib["pos"].ToString() : "center");
            this.drpCropP.SelectedValue = (htAttrib.ContainsKey("spos") ? htAttrib["spos"].ToString() : "center");
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

        private void FillTransitionCombo()
        {
            List<string> list = new List<string>();
            list.Add("--Select--");
        IL_1A:
            while (2 != 0)
            {
                do
                {
                    if (-1 != 0)
                    {
                        List<string> expr_E9 = list;
                        string expr_29 = "fade";
                        if (4 != 0)
                        {
                            expr_E9.Add(expr_29);
                        }
                    }
                    list.Add("pixelate");
                    list.Add("blur");
                    if (false)
                    {
                        goto IL_1A;
                    }
                    list.Add("slide-h");
                    list.Add("slide-v");
                    do
                    {
                        list.Add("slide-rep-h");
                        if (5 == 0)
                        {
                            goto IL_AD;
                        }
                        list.Add("slide-rep-v");
                    }
                    while (false);
                }
                while (false);
                list.Add("slide-rep-h-2");
                list.Add("slide-rep-v-2");
            IL_AD:
                this.cmbTransitions.ItemsSource = list;
                break;
            }
            this.cmbTransitions.SelectedIndex = 0;
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
                        message = ErrorHandler.CreateErrorMessage(serviceException);
                    }
                    ErrorHandler.LogFileWrite(message);
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

        private void drpPosition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.InvalidatePropertyChange((System.Windows.Controls.ComboBox)sender, 0.0);
        }

        private void drpCropP_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.InvalidatePropertyChange((System.Windows.Controls.ComboBox)sender, 0.0);
        }

        private void InvalidatePropertyChange(System.Windows.Controls.TextBox textB, double timeForChange)
        {
            bool flag;
            if (2 != 0)
            {
                flag = (this.GuestElement == null);
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
                        this.ApplyPropertyChange(this.GuestElement, "audio_gain", Convert.ToString(this.txtAudioGain.Text), timeForChange);
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
            this.ApplyPropertyChange(this.GuestElement, "stream_id", Convert.ToString(this.txtStreamId.Text), timeForChange);
        }

        private void InvalidatePropertyChange(System.Windows.Controls.ComboBox cmb, double timeForChange)
        {
            bool flag;
            if (2 != 0)
            {
                flag = (this.GuestElement == null);
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
                        this.ApplyPropertyChange(this.GuestElement, "pos", Convert.ToString(this.drpPosition.SelectedValue), timeForChange);
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
            this.ApplyPropertyChange(this.GuestElement, "spos", Convert.ToString(this.drpCropP.SelectedValue), timeForChange);
        }

        private void ApplyPropertyChange(MElement SelectedElem, string attribute, string value, double timeForChange)
        {
            SelectedElem.ElementMultipleSet(attribute + "=" + value, timeForChange);
        }

        private void InvalidatePropertyChange(Slider sdr, double timeForChange)
        {
            if (this.GuestElement == null)
            {
                goto IL_1EA;
            }
            if (sdr == this.sldXAxis)
            {
                this.ApplyPropertyChange(this.GuestElement, "x", Convert.ToString(sdr.Value), timeForChange);
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
                this.ApplyPropertyChange(this.GuestElement, "w", Convert.ToString(sdr.Value), timeForChange);
                goto IL_F7;
            }
            goto IL_F7;
        IL_73:
            if (!arg_73_0)
            {
                this.ApplyPropertyChange(this.GuestElement, "y", Convert.ToString(sdr.Value), timeForChange);
            }
            flag = (sdr != this.sldHeight);
            bool arg_A3_0 = flag;
        IL_A3:
            if (!arg_A3_0)
            {
                this.ApplyPropertyChange(this.GuestElement, "h", Convert.ToString(sdr.Value), timeForChange);
            }
        IL_C3:
            bool expr_CA = arg_A3_0 = (sdr == this.sldWidth);
            if (6 != 0)
            {
                bool arg_D2_0 = !expr_CA;
                goto IL_D2;
            }
            goto IL_A3;
        IL_F7:
            if (sdr == this.sldRotation)
            {
                this.ApplyPropertyChange(this.GuestElement, "r", Convert.ToString(sdr.Value), timeForChange);
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
                    goto IL_D2;
                }
                if (!expr_132)
                {
                    this.ApplyPropertyChange(this.GuestElement, "sx", Convert.ToString(sdr.Value), timeForChange);
                }
                if (sdr == this.sldCropY)
                {
                    this.ApplyPropertyChange(this.GuestElement, "sy", Convert.ToString(sdr.Value), timeForChange);
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
                this.ApplyPropertyChange(this.GuestElement, "sh", Convert.ToString(sdr.Value), timeForChange);
            }
            if (sdr == this.sldCropW)
            {
                this.ApplyPropertyChange(this.GuestElement, "sw", Convert.ToString(sdr.Value), timeForChange);
            }
        IL_1EA:
            if (5 != 0)
            {
                return;
            }
            goto IL_F7;
        }

        private void btnAudios_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            }
            catch
            {
            }
        }

        private void sldVolume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            while (8 == 0)
            {
            }
            double arg_10_0;
            double arg_1D_0 = arg_10_0 = this.sldVolume.Value;
            while (true)
            {
                if (!false)
                {
                    arg_1D_0 = (arg_10_0 = arg_10_0);
                }
                if (!false)
                {
                    arg_1D_0 = (arg_10_0 = arg_1D_0 / this.sldVolume.Maximum);
                    if (8 != 0)
                    {
                        break;
                    }
                }
            }
        }

        private void btnVideoPreview_Click(object sender, RoutedEventArgs e)
        {
            while (this.mPreviewControlMixer1.m_pPreview != null)
            {
                IMPreview arg_5B_0 = this.mPreviewControlMixer1.m_pPreview;
                string arg_5B_1 = "";
                bool? isChecked = this.btnAudios.IsChecked;
                int arg_5B_2 = isChecked.Value ? 0 : 1;
                isChecked = this.btnVideoPreview.IsChecked;
                arg_5B_0.PreviewEnable(arg_5B_1, arg_5B_2, isChecked.Value ? 0 : 1);
                if (3 != 0)
                {
                    break;
                }
            }
        }

        private void btnFullScreen_Checked(object sender, RoutedEventArgs e)
        {
            if (8 != 0)
            {
            }
            if (this.mPreviewControlMixer1.m_pPreview != null)
            {
                if (!false)
                {
                    bool flag = !this.btnFullScreen.IsChecked.Value;
                    if (8 != 0)
                    {
                        if (false || !flag)
                        {
                            this.mPreviewControlMixer1.m_pPreview.PreviewFullScreen("", 1, 1);
                        }
                        else
                        {
                            if (false)
                            {
                                goto IL_A5;
                            }
                            this.mPreviewControlMixer1.m_pPreview.PreviewFullScreen("", 0, 1);
                            if (!false)
                            {
                                goto IL_A5;
                            }
                        }
                    }
                    this.btnFullScreen.IsChecked = new bool?(false);
                }
            IL_A5: ;
            }
        }

        private void btnAspectRatio_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                bool flag;
                if (!false)
                {
                    flag = (this.mPreviewControlMixer1.m_pPreview == null);
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
            MPLATFORMLib.IMProps arg_7F_0 = (MPLATFORMLib.IMProps)this.mPreviewControlMixer1.m_pPreview;
            string arg_7F_1 = "maintain_ar";
            bool? expr_6E = this.btnAspectRatio.IsChecked;
            bool? flag2;
            if (2 != 0)
            {
                flag2 = expr_6E;
            }
            arg_7F_0.PropsSet(arg_7F_1, flag2.Value ? "none" : "letter-box");
        }

        private void cmbGraphicsSettings_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.RemovePlugins();
            this.LoadCGConfigSettingFromProfile();
        }

        private void LoadCGConfigSettingFromProfile()
        {
            try
            {
                int arg_90_0;
                bool expr_0D = (arg_90_0 = ((this.m_objMixer == null) ? 1 : 0)) != 0;
                if (false)
                {
                    goto IL_90;
                }
                if (expr_0D)
                {
                    goto IL_146;
                }
                if (false)
                {
                    goto IL_96;
                }
                if (false)
                {
                    goto IL_FC;
                }
                if (!true)
                {
                    goto IL_145;
                }
                this.m_objCharGen = (MLCHARGENLib.CoMLCharGen)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("0F56D2E7-033C-4A05-BCDA-DF58C9BBF06F")));
                this.m_objMixer.PluginsAdd(this.m_objCharGen, 0L);
                if (4 == 0)
                {
                    goto IL_AE;
                }
                this.cgEditor.SetSourceObject(this.m_objMixer, this.m_objCharGen);
            IL_8B:
                arg_90_0 = 1000;
            IL_90:
                Thread.Sleep(arg_90_0);
            IL_96:
                if (this.cmbGraphicsSettings.SelectedIndex <= 0)
                {
                    goto IL_145;
                }
            IL_AE:
                if (false)
                {
                    goto IL_8B;
                }
                CGConfigSettings cGConfigSettings = this.GetCGConfigSettings(Convert.ToInt32(this.cmbGraphicsSettings.SelectedValue));
                if (cGConfigSettings == null)
                {
                    return;
                }
                this.cgEditor.UpdateFileName(cGConfigSettings.DisplayName);
                this.cgEditor.ConfigFileName = cGConfigSettings.DisplayName;
            IL_FC:
                MLCHARGENLib.IMLXMLPersist iMLXMLPersist = (MLCHARGENLib.IMLXMLPersist)this.m_objCharGen;
                iMLXMLPersist.LoadFromXML(System.IO.Path.Combine(ConfigManager.DigiFolderPath, "CGSettings", cGConfigSettings.ConfigFileName + cGConfigSettings.Extension), -1);
                do
                {
                    this.cgEditor.Editor.UpdateItemsList();
                }
                while (-1 == 0);
            IL_145:
            IL_146: ;
            }
            catch (Exception var_2_18B)
            {
            }
        }

        private void LoadGraphicEditor()
        {
            try
            {
                List<TemplateListItems> list = this.objTemplateList.Where(delegate(TemplateListItems o)
                {
                    bool result;
                    while (8 != 0)
                    {
                        bool arg_3A_0;
                        if (o.MediaType == 606)
                        {
                            arg_3A_0 = o.IsChecked;
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
                            arg_3A_0 = false;
                        }
                        result = arg_3A_0;
                        break;
                    }
                    return result;
                }).ToList<TemplateListItems>();
                int arg_212_0;
                bool arg_182_0;
                bool arg_A7_0;
                if (list.Count <= 0)
                {
                    bool? isChecked = this.chkTextLogo.IsChecked;
                    int arg_7E_0;
                    if (isChecked.GetValueOrDefault())
                    {
                        if (false)
                        {
                            goto IL_B0;
                        }
                        arg_182_0 = ((arg_7E_0 = (arg_212_0 = (isChecked.HasValue ? 1 : 0))) != 0);
                    }
                    else
                    {
                        arg_182_0 = ((arg_7E_0 = (arg_212_0 = 0)) != 0);
                    }
                    if (7 == 0)
                    {
                        goto IL_182;
                    }
                    if (false)
                    {
                        goto IL_212;
                    }
                    if (arg_7E_0 == 0 || string.IsNullOrEmpty(this.txtTextLogo.Text))
                    {
                        arg_A7_0 = (this.cmbGraphicsSettings.SelectedIndex <= 0);
                        goto IL_A6;
                    }
                }
                arg_A7_0 = false;
            IL_A6:
                bool flag = arg_A7_0;
            IL_A9:
                if (flag)
                {
                    System.Windows.MessageBox.Show("Please select graphics profile or graphics.", "Digiphoto", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    goto IL_359;
                }
            IL_B0:
                string bsFileNameOrItemDesc = string.Empty;
                this.m_objCharGen = (MLCHARGENLib.CoMLCharGen)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("0F56D2E7-033C-4A05-BCDA-DF58C9BBF06F")));
                CGConfigSettings cGConfigSettings;
                if (5 != 0)
                {
                    this.m_objMixer.PluginsAdd(this.m_objCharGen, 0L);
                    do
                    {
                        this.cgEditor = new CGEditor_WinForms.MainWindow();
                        this.cgEditor.CGConfig += new EventHandler(this.SaveCGConfig);
                        this.cgEditor.FormClosed += new FormClosedEventHandler(this.cgEditor_FormClosed);
                        this.cgEditor.SetSourceObject(this.m_objMixer, this.m_objCharGen);
                        if (this.cmbGraphicsSettings.SelectedIndex <= 0)
                        {
                            goto IL_1F0;
                        }
                        cGConfigSettings = this.GetCGConfigSettings(Convert.ToInt32(this.cmbGraphicsSettings.SelectedValue));
                    }
                    while (false);
                    arg_182_0 = (cGConfigSettings != null);
                    goto IL_182;
                IL_1F0:
                    arg_212_0 = ((this.chkTextLogo.IsChecked == true) ? 1 : 0);
                    goto IL_212;
                }
                goto IL_1E5;
            IL_182:
                if (!arg_182_0)
                {
                    goto IL_3BB;
                }
                this.cgEditor.UpdateFileName(cGConfigSettings.DisplayName);
                this.cgEditor.ConfigFileName = cGConfigSettings.DisplayName;
                MLCHARGENLib.IMLXMLPersist iMLXMLPersist = (MLCHARGENLib.IMLXMLPersist)this.m_objCharGen;
                iMLXMLPersist.LoadFromXML(System.IO.Path.Combine(ConfigManager.DigiFolderPath, "CGSettings", cGConfigSettings.ConfigFileName + cGConfigSettings.Extension), -1);
            IL_1E5:
                if (!false)
                {
                    goto IL_324;
                }
                goto IL_35A;
            IL_212:
                flag = (arg_212_0 == 0 || string.IsNullOrEmpty(this.txtTextLogo.Text));
                if (!flag)
                {
                    bsFileNameOrItemDesc = this.txtTextLogo.Text.Trim();
                    this.m_objCharGen.AddNewItem(bsFileNameOrItemDesc, 0.1, 0.1, 1, 1, ref this.m_strItemID);
                    this.m_objCharGen.SetItemProperties(this.m_strItemID, "", "", "", 0);
                    this.m_objCharGen.ShowItem(this.m_strItemID, 1, 1000);
                    this.m_strItemID = string.Empty;
                    if (!true)
                    {
                        goto IL_A9;
                    }
                }
                foreach (TemplateListItems current in list)
                {
                    this.m_objCharGen.AddNewItem(current.FilePath, 0.0, 0.0, 0, 1, ref this.m_strItemID);
                    this.m_strItemID = string.Empty;
                }
            IL_324:
                this.cgEditor.Editor.UpdateItemsList();
                this.cgEditor.ShowDialog();
            IL_359:
            IL_35A: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        IL_3BA:
        IL_3BB:
            if (!false)
            {
                return;
            }
            goto IL_3BA;
        }

        private void SaveCGConfig(object sender, EventArgs e)
        {
            this.SaveCGConfigDb();
            while (true)
            {
                this.BindCGConfigCombo();
                while (true)
                {
                IL_14:
                    if (true)
                    {
                        this.LoadGraphicsList();
                    }
                    if (!false)
                    {
                        this.chkTextLogo.IsChecked = new bool?(false);
                        while (7 != 0)
                        {
                            this.txtTextLogo.Text = string.Empty;
                            if (!false)
                            {
                                bool arg_5C_0 = this.cgEditor.IsFleNameExists;
                                bool expr_5D;
                                do
                                {
                                    bool flag = arg_5C_0;
                                    expr_5D = (arg_5C_0 = flag);
                                }
                                while (false);
                                if (expr_5D)
                                {
                                    return;
                                }
                                if (!false)
                                {
                                    break;
                                }
                                goto IL_14;
                            }
                        }
                        goto IL_67;
                    }
                    break;
                }
            }
        IL_67:
            this.cgEditor.Close();
        }

        private void SaveCGConfigDb()
        {
            this.objConfigBL = new ConfigBusiness();
            this.objCGConfig = new CGConfigSettings();
            while (this.dicConfig.ContainsValue(this.cgEditor.ConfigFileName) && !this.cgEditor.IsUpdateConfig)
            {
                this.cgEditor.IsFleNameExists = true;
                if (!false)
                {
                    return;
                }
            }
            this.cgEditor.IsFleNameExists = false;
            string text = ".ml-cgc";
            do
            {
                this.objCGConfig.Extension = text;
            }
            while (6 == 0);
            this.objCGConfig.ConfigFileName = this.cgEditor.ConfigFileName;
            this.objCGConfig.IsActive = true;
            try
            {
                if (this.cgEditor.IsUpdateConfig)
                {
                    this._configId = Convert.ToInt32(this.cmbGraphicsSettings.SelectedValue);
                }
                if (!this.cgEditor.IsUpdateConfig)
                {
                    this._configId = this.objConfigBL.SaveCGConfigSetting(this.objCGConfig);
                }
                int arg_116_0;
                int expr_10A = arg_116_0 = this._configId;
                if (7 != 0)
                {
                    arg_116_0 = ((expr_10A > 0) ? 1 : 0);
                }
                int arg_118_0 = (arg_116_0 == 0) ? 1 : 0;
                MLCHARGENLib.IMLXMLPersist iMLXMLPersist;
                int expr_141;
                do
                {
                    if (arg_118_0 == 0)
                    {
                        this.cgEditor.IsSaved = true;
                    }
                    iMLXMLPersist = (MLCHARGENLib.IMLXMLPersist)this.cgEditor.Editor.CGObject;
                    expr_141 = (arg_118_0 = 4);
                }
                while (expr_141 == 0);
                object[] array = new object[expr_141];
                array[0] = this.cgEditor.ConfigFileName;
                array[1] = "_";
                array[2] = this._configId;
                array[3] = text;
                string path = string.Concat(array);
                string text2 = System.IO.Path.Combine(ConfigManager.DigiFolderPath, "CGSettings");
                if (!Directory.Exists(text2))
                {
                    Directory.CreateDirectory(text2);
                }
                iMLXMLPersist.SaveToXMLFile(System.IO.Path.Combine(text2, path), 1);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void BindCGConfigCombo()
        {
            try
            {
                do
                {
                    new List<CGConfigSettings>();
                }
                while (6 == 0);
                this.objConfigBL = new ConfigBusiness();
                List<CGConfigSettings> cGConfigSettngs;
                do
                {
                    cGConfigSettngs = this.objConfigBL.GetCGConfigSettngs(0);
                }
                while (false);
                this.dicConfig = new Dictionary<int, string>();
                this.dicConfig.Add(0, "-Select Graphics Profile-");
                List<CGConfigSettings>.Enumerator enumerator = cGConfigSettngs.GetEnumerator();
                try
                {
                    if (8 != 0)
                    {
                    }
                IL_8F:
                    if (enumerator.MoveNext())
                    {
                        CGConfigSettings current = enumerator.Current;
                        if (!false)
                        {
                            this.dicConfig.Add(current.ID, current.DisplayName);
                            goto IL_8F;
                        }
                        goto IL_8F;
                    }
                }
                finally
                {
                    do
                    {
                        ((IDisposable)enumerator).Dispose();
                    }
                    while (5 == 0);
                }
                this.cmbGraphicsSettings.ItemsSource = this.dicConfig;
                KeyValuePair<int, string> keyValuePair = (from x in this.dicConfig
                                                          where x.Key == this._configId
                                                          select x).FirstOrDefault<KeyValuePair<int, string>>();
                if (this._configId > 0)
                {
                    this.cmbGraphicsSettings.SelectedItem = keyValuePair;
                }
                else
                {
                    this.cmbGraphicsSettings.SelectedIndex = 0;
                    if (5 != 0)
                    {
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
            if (3 != 0)
            {
            }
        }

        private CGConfigSettings GetCGConfigSettings(int configID)
        {
            CGConfigSettings result;
            while (true)
            {
                if (4 != 0)
                {
                    try
                    {
                        if (4 != 0 && true)
                        {
                            this.objConfigBL = new ConfigBusiness();
                            this.objCGConfig = new CGConfigSettings();
                            this.objCGConfig = this.objConfigBL.GetCGConfigSettngs(Convert.ToInt32(this.cmbGraphicsSettings.SelectedValue)).FirstOrDefault<CGConfigSettings>();
                        }
                    }
                    catch (Exception serviceException)
                    {
                        string message = ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.LogFileWrite(message);
                    }
                    goto IL_85;
                }
            IL_8C:
                if (6 != 0)
                {
                    if (2 != 0)
                    {
                        break;
                    }
                    continue;
                }
            IL_85:
                result = this.objCGConfig;
                goto IL_8C;
            }
            return result;
        }

        private string SaveChromaSetting(MItem mitem)
        {
            while (false)
            {
            }
            string empty = string.Empty;
            string result;
            try
            {
                this.GetChromakeyFilter(mitem);
                while (true)
                {
                    MCHROMAKEYLib.MKey mKey;
                    VideoEditor.objChromaKey.KeyGet(null, out mKey, "");
                    MCHROMAKEYLib.IMPersist iMPersist = (MCHROMAKEYLib.IMPersist)VideoEditor.objChromaKey;
                    if (mKey != null)
                    {
                        goto IL_48;
                    }
                    bool arg_C6_0 = true;
                    goto IL_56;
                IL_86:
                    GC.Collect();
                    if (5 == 0)
                    {
                        continue;
                    }
                    if (!false)
                    {
                        break;
                    }
                IL_48:
                    arg_C6_0 = (VideoEditor.objChromaKey == null);
                    if (8 == 0)
                    {
                        goto IL_86;
                    }
                IL_56:
                    bool flag;
                    if (8 != 0)
                    {
                        flag = arg_C6_0;
                    }
                    if (!flag)
                    {
                        if (6 != 0)
                        {
                        }
                        iMPersist.PersistSaveToString("", out empty, "");
                    }
                    Marshal.ReleaseComObject(iMPersist);
                    Marshal.ReleaseComObject(mitem);
                    goto IL_86;
                }
                result = empty;
            }
            catch
            {
                do
                {
                    result = empty;
                }
                while (false);
            }
            return result;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.MediaStop();
            this.IsLoadChroma = false;
            this.CurrentchromaSetting = string.Empty;
            this.overlayChromaSetting = string.Empty;
            try
            {
                if (!ConfigManager.IMIXConfigurations.ContainsKey(58L) || string.IsNullOrEmpty(ConfigManager.IMIXConfigurations[58L]))
                {
                    goto IL_7F;
                }
            IL_67:
                string settings = ConfigManager.IMIXConfigurations[58L];
                this.LoadWriterSettings(settings);
            IL_7F:
                if (this.mPreviewControlMixer1.m_pPreview != null)
                {
                    this.mPreviewControlMixer1.m_pPreview.PreviewEnable("", this.btnAudios.IsChecked.Value ? 0 : 1, this.btnVideoPreview.IsChecked.Value ? 0 : 1);
                    if (3 == 0)
                    {
                        goto IL_2B1;
                    }
                }
                if (ConfigManager.IMIXConfigurations.ContainsKey(123L) && Convert.ToBoolean(ConfigManager.IMIXConfigurations[123L]))
                {
                    this.AutomatedVideoEditWorkFlow = true;
                }
                int arg_160_0;
                int expr_14A = arg_160_0 = RobotImageLoader.PrintImages.Where(delegate(LstMyItems o)
                {
                    int arg_39_0;
                    if (o.MediaType == 1)
                    {
                        arg_39_0 = 1;
                        goto IL_14;
                    }
                    int arg_0C_0 = o.MediaType;
                    do
                    {
                    IL_0B:
                        arg_39_0 = (arg_0C_0 = ((arg_0C_0 == 2) ? 1 : 0));
                    }
                    while (false);
                    bool expr_3C;
                    do
                    {
                    IL_14:
                        bool flag3 = arg_39_0 != 0;
                        if (!false)
                        {
                        }
                        expr_3C = ((arg_0C_0 = (arg_39_0 = (flag3 ? 1 : 0))) != 0);
                    }
                    while (8 == 0);
                    if (!false)
                    {
                        return expr_3C;
                    }
                    goto IL_0B;
                }).ToList<LstMyItems>().Count;
                int arg_160_1;
                int expr_150 = arg_160_1 = 1;
                if (expr_150 != 0)
                {
                    if (expr_14A != expr_150)
                    {
                        goto IL_16D;
                    }
                    arg_160_0 = RobotImageLoader.PrintImages.Count;
                    arg_160_1 = 1;
                }
                if (arg_160_0 != arg_160_1)
                {
                    goto IL_16D;
                }
                bool arg_169_0 = this.AutomatedVideoEditWorkFlow;
            IL_168:
                bool arg_16F_0 = !arg_169_0;
                goto IL_16E;
            IL_16D:
                arg_16F_0 = true;
            IL_16E:
                bool flag = arg_16F_0;
                if (3 == 0 || !flag)
                {
                    bool flag2 = false;
                    if (ConfigManager.IMIXConfigurations.ContainsKey(56L))
                    {
                        flag2 = Convert.ToBoolean(ConfigManager.IMIXConfigurations[56L]);
                    }
                    LstMyItems lstMyItems = RobotImageLoader.PrintImages.Where(delegate(LstMyItems x)
                    {
                        int arg_39_0;
                        if (x.MediaType == 1)
                        {
                            arg_39_0 = 1;
                            goto IL_14;
                        }
                        int arg_0C_0 = x.MediaType;
                        do
                        {
                        IL_0B:
                            arg_39_0 = (arg_0C_0 = ((arg_0C_0 == 2) ? 1 : 0));
                        }
                        while (false);
                        bool expr_3C;
                        do
                        {
                        IL_14:
                            bool flag3 = arg_39_0 != 0;
                            if (!false)
                            {
                            }
                            expr_3C = ((arg_0C_0 = (arg_39_0 = (flag3 ? 1 : 0))) != 0);
                        }
                        while (8 == 0);
                        if (!false)
                        {
                            return expr_3C;
                        }
                        goto IL_0B;
                    }).FirstOrDefault<LstMyItems>();
                    bool arg_1E7_0;
                    if (lstMyItems != null)
                    {
                        if (8 == 0)
                        {
                            goto IL_2B8;
                        }
                        arg_1E7_0 = !flag2;
                    }
                    else
                    {
                        arg_1E7_0 = true;
                    }
                    if (!arg_1E7_0)
                    {
                        this.DropPhotoId = lstMyItems.PhotoId;
                        this.activePage = 1;
                        this.VideoEditPlayerPanel.Visibility = Visibility.Collapsed;
                        this.btnSelectAll_Click(sender, e);
                        this.LoadSceneSettingsBasedOnImage(lstMyItems);
                        flag = !this.IsSceneLoaded;
                        if (7 == 0)
                        {
                            goto IL_67;
                        }
                        bool expr_233 = arg_169_0 = flag;
                        if (5 == 0)
                        {
                            goto IL_168;
                        }
                        if (!expr_233)
                        {
                            VideoPage videoPage = this.PrintOrderPageList.Where(delegate(VideoPage o)
                            {
                                int arg_0B_0 = o.PhotoId;
                                int arg_0B_1 = this.DropPhotoId;
                                int arg_44_0;
                                while (arg_0B_0 == arg_0B_1)
                                {
                                    int arg_2C_0;
                                    int expr_3D = arg_0B_0 = (arg_2C_0 = (arg_44_0 = o.PageNo));
                                    if (false)
                                    {
                                        goto IL_26;
                                    }
                                    int expr_15 = arg_0B_1 = 1;
                                    if (expr_15 == 0)
                                    {
                                        continue;
                                    }
                                    arg_44_0 = ((expr_3D == expr_15) ? 1 : 0);
                                IL_1A:
                                IL_1D:
                                    bool flag3;
                                    if (!false)
                                    {
                                        flag3 = (arg_44_0 != 0);
                                    }
                                    arg_44_0 = (arg_2C_0 = (flag3 ? 1 : 0));
                                IL_26:
                                    if (-1 == 0)
                                    {
                                        goto IL_1A;
                                    }
                                    if (true)
                                    {
                                        return arg_2C_0 != 0;
                                    }
                                    goto IL_1D;
                                }
                                arg_44_0 = 0;
                                goto IL_1D;
                            }).FirstOrDefault<VideoPage>();
                            videoPage.ImageDisplayTime = this.Vidlength;
                            VideoElements videoElements = this.lstVideoElements.FirstOrDefault<VideoElements>();
                            videoPage.DropVideoPath = videoElements.VideoFilePath;
                            this.StackImageDisplayTime.Visibility = Visibility.Visible;
                        }
                    }
                }
                if (this.IsSceneLoaded)
                {
                    goto IL_2C0;
                }
                this.AutomatedVideoEditWorkFlow = false;
            IL_2B1:
                this.LoadDefaultSceneAndFile();
            IL_2B8:
                this.IsSceneLoaded = true;
            IL_2C0:
                if (this.IsSceneLoaded)
                {
                    this.BindGuestNodeProps();
                }
                this.FillPositionDropDown();
                this.FillTransitionCombo();
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private void LoadChromaAndCGConfig(string sceneName, int CG_ConfigID)
        {
            try
            {
                string expr_26 = this.strGuestStreamID;
                string streamID;
                if (2 != 0)
                {
                    streamID = expr_26;
                }
                this.m_objCharGen = (MLCHARGENLib.CoMLCharGen)Activator.CreateInstance(Type.GetTypeFromCLSID(new Guid("0F56D2E7-033C-4A05-BCDA-DF58C9BBF06F")));
                this.m_objMixer.PluginsAdd(this.m_objCharGen, 0L);
                Thread.Sleep(1000);
                bool arg_80_0 = CG_ConfigID == 0;
                string text2;
                int arg_1FA_0;
                string a;
                while (true)
                {
                    bool flag = arg_80_0;
                    while (true)
                    {
                        if (!flag)
                        {
                            goto IL_8A;
                        }
                        goto IL_14F;
                    IL_E6:
                        int arg_E6_0;
                        flag = (arg_E6_0 != 0);
                        bool expr_E8 = arg_80_0 = flag;
                        if (false)
                        {
                            break;
                        }
                        if (!expr_E8)
                        {
                            MLCHARGENLib.IMLXMLPersist iMLXMLPersist;
                            string text;
                            iMLXMLPersist.LoadFromXML(text, -1);
                        }
                        KeyValuePair<int, string> keyValuePair = (from x in this.dicConfig
                                                                  where x.Key == CG_ConfigID
                                                                  select x).FirstOrDefault<KeyValuePair<int, string>>();
                        flag = (CG_ConfigID <= 0);
                        if (flag)
                        {
                            goto IL_14D;
                        }
                        if (!false)
                        {
                            this.cmbGraphicsSettings.SelectedItem = keyValuePair;
                            goto IL_14C;
                        }
                        continue;
                    IL_8A:
                        CGConfigSettings cGConfigSettings = this.objConfigBL.GetCGConfigSettngs(CG_ConfigID).FirstOrDefault<CGConfigSettings>();
                        if (cGConfigSettings != null)
                        {
                            MLCHARGENLib.IMLXMLPersist iMLXMLPersist = (MLCHARGENLib.IMLXMLPersist)this.m_objCharGen;
                            string text = System.IO.Path.Combine(ConfigManager.DigiFolderPath, "CGSettings", cGConfigSettings.ConfigFileName + cGConfigSettings.Extension);
                            arg_E6_0 = ((!File.Exists(text)) ? 1 : 0);
                            goto IL_E6;
                        }
                    IL_14F:
                        if (this.IsLoadChroma)
                        {
                            string chromaPath = System.IO.Path.Combine(ConfigManager.DigiFolderPath, "Profiles", sceneName, sceneName + "_Chroma.xml");
                            if (false)
                            {
                                goto IL_14C;
                            }
                            this.CurrentchromaSetting = this.LoadChromaFromFile(streamID, chromaPath);
                        }
                        text2 = System.IO.Path.Combine(ConfigManager.DigiFolderPath, "Profiles", sceneName, sceneName + "_OverlayChroma.xml");
                        bool arg_1CB_0 = ((this.OverlayElement == null) ? (arg_E6_0 = (arg_1FA_0 = 1)) : (arg_E6_0 = (arg_1FA_0 = ((!File.Exists(text2)) ? 1 : 0)))) != 0;
                        if (6 == 0)
                        {
                            goto IL_1F9;
                        }
                        if (false)
                        {
                            goto IL_E6;
                        }
                        if (arg_1CB_0)
                        {
                            goto IL_239;
                        }
                        int num;
                        this.OverlayElement.AttributesHave("show", out num, out a);
                        if (!false)
                        {
                            goto Block_15;
                        }
                        goto IL_8A;
                    IL_14E:
                        goto IL_14F;
                    IL_14D:
                        goto IL_14E;
                    IL_14C:
                        goto IL_14D;
                    }
                }
            Block_15:
                arg_1FA_0 = ((a == "true") ? 1 : 0);
            IL_1F9:
                if (arg_1FA_0 == 0)
                {
                    goto IL_235;
                }
                string empty = string.Empty;
                this.OverlayElement.AttributesStringGet("stream_id", out empty);
            IL_21C:
                this.overlayChromaSetting = this.LoadChromaFromFile(empty, text2);
                this.IsLoadOverlayChroma = true;
            IL_235:
                if (false)
                {
                    goto IL_21C;
                }
            IL_239: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.LogFileWrite(message);
            }
        }

        private string LoadChromaFromFile(string streamID, string chromaPath)
        {
            string empty;
            MItem source;
            do
            {
                empty = string.Empty;
                int num;
                this.m_objMixer.StreamsGet(streamID, out num, out source);
                this.LoadChromaPlugin(true, source);
            }
            while (false);
            Thread.Sleep(500);
            MCHROMAKEYLib.MChromaKey chromakeyFilter = this.GetChromakeyFilter(source);
            try
            {
                ((MPLATFORMLib.IMProps)chromakeyFilter).PropsSet("gpu_mode", "true");
            }
            catch
            {
            }
            int arg_74_0 = 500;
            bool expr_7E;
            do
            {
                Thread.Sleep(arg_74_0);
                if (false)
                {
                    goto IL_8F;
                }
                expr_7E = ((arg_74_0 = (File.Exists(chromaPath) ? 1 : 0)) != 0);
            }
            while (false);
            if (!expr_7E)
            {
                goto IL_A6;
            }
        IL_8F:
            (chromakeyFilter as MPLATFORMLib.IMPersist).PersistLoad("", chromaPath, "");
        IL_A5:
        IL_A6:
            Thread.Sleep(500);
            string result;
            if (File.Exists(chromaPath))
            {
                (chromakeyFilter as MPLATFORMLib.IMPersist).PersistLoad("", chromaPath, "");
                if (false)
                {
                    return result;
                }
                (chromakeyFilter as MPLATFORMLib.IMPersist).PersistSaveToString("", out empty, "");
                if (false)
                {
                    goto IL_A5;
                }
            }
            result = empty;
            if (3 == 0)
            {
                goto IL_A5;
            }
            return result;
        }

        private void btnClosePreview_Click(object sender, RoutedEventArgs e)
        {
            if (3 != 0)
            {
            }
            this.MediaStop();
            this.VideoEditPlayerPanel.Visibility = Visibility.Visible;
            do
            {
                if (-1 != 0)
                {
                    this.vidoriginal.Visibility = Visibility.Collapsed;
                    this.stkbtnClosePreview.Visibility = Visibility.Collapsed;
                }
                if (false)
                {
                    return;
                }
            }
            while (2 == 0);
            if (3 != 0)
            {
                this.GuestElement.ElementMultipleSet("stream_id=" + this.strGuestStreamID + " audio_gain=-100 show=true", 0.0);
            }
            this.InitializeStream(this.strGuestStreamID, false);
        }

        private void mConfigList1_OnConfigChanged(object sender, EventArgs e)
        {
            do
            {
                string videoSettings;
                this.m_objWriter.ConfigGetAll(1, out videoSettings);
                while (5 != 0)
                {
                    if (-1 != 0)
                    {
                        this.VideoSettings = videoSettings;
                        while (true)
                        {
                            string text;
                            IMAttributes iMAttributes;
                            this.m_objWriter.ConfigGet("format", out text, out iMAttributes);
                            int num = 0;
                            try
                            {
                                do
                                {
                                    iMAttributes.AttributesBoolGet("network", out num);
                                }
                                while (-1 == 0);
                            }
                            catch (Exception)
                            {
                            }
                            if (5 != 0)
                            {
                                goto IL_5F;
                            }
                        }
                    }
                }
            IL_5F: ;
            }
            while (false);
        }

        private void cmbTransitions_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.numericTimeForChange = 1.0;
        }

        private void GetAudioListToBeApplied(string sceneName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            string expr_197 = System.IO.Path.Combine(ConfigManager.DigiFolderPath, "Profiles", sceneName, sceneName + "_Audio.xml");
            string text;
            if (!false)
            {
                text = expr_197;
            }
            if (File.Exists(text))
            {
                xmlDocument.Load(text);
                XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("audio");
                foreach (XmlNode xmlNode in elementsByTagName)
                {
                    TemplateListItems templateListItems;
                    while (true)
                    {
                        int id = Convert.ToInt32(xmlNode["ItemID"].InnerText);
                        templateListItems = (from o in this.objTemplateList
                                             where o.Item_ID == (long)id
                                             select o).FirstOrDefault<TemplateListItems>();
                        if (templateListItems == null)
                        {
                            break;
                        }
                        if (8 != 0)
                        {
                            goto Block_5;
                        }
                    }
                    continue;
                Block_5:
                    if (!false)
                    {
                        templateListItems.StartTime = Convert.ToInt32(xmlNode["StartTime"].InnerText);
                        templateListItems.EndTime = Convert.ToInt32(xmlNode["StopTime"].InnerText);
                        templateListItems.InsertTime = Convert.ToInt32(xmlNode["InsertTime"].InnerText);
                    }
                    if (6 == 0)
                    {
                        break;
                    }
                    templateListItems.IsChecked = true;
                }
            }
        }

        private void btnBackgrounds_Click(object sender, RoutedEventArgs e)
        {
            List<TemplateListItems> itemsSource;
            if (3 != 0)
            {
                if (8 == 0)
                {
                    goto IL_8A;
                }
                this.SetTemplateListVisibility(true);
                this.templateType = "chroma";
                this.lstTemplates.IsEnabled = true;
                if (false)
                {
                    return;
                }
                itemsSource = (from o in this.objTemplateList
                               where o.MediaType == 605
                               select o).ToList<TemplateListItems>();
                this.lstTemplates.ItemsSource = null;
                if (8 == 0)
                {
                    goto IL_88;
                }
                if (3 == 0)
                {
                    goto IL_8A;
                }
            }
            this.lstTemplates.ItemsSource = itemsSource;
        IL_88:
        IL_8A:
            this.txtTemplateRotate.Text = "Chroma Backgrounds";
        }

        private void ZoomInOut(bool blGrow)
        {
            double num = 0.05;
            double num2;
            this.GuestElement.AttributesDoubleGet("w", out num2);
            double num3;
            while (true)
            {
                this.GuestElement.AttributesDoubleGet("h", out num3);
                if (!(num2 == 0.0 & num3 == 0.0))
                {
                    goto IL_A9;
                }
                string value;
                this.GuestElement.AttributesInfoGet("w", MPLATFORMLib.eMInfoType.eMIT_Default, out value);
                string value2;
                this.GuestElement.AttributesInfoGet("h", MPLATFORMLib.eMInfoType.eMIT_Default, out value2);
                if (!false)
                {
                    num2 = Convert.ToDouble(value);
                    num3 = Convert.ToDouble(value2);
                    goto IL_A9;
                }
                goto IL_AC;
            IL_B4:
                double arg_B5_0;
                num2 = arg_B5_0;
                string bsAttributesList;
                bool arg_122_0;
                if (5 != 0)
                {
                    num3 = (blGrow ? (num3 + num) : (num3 - num));
                    object[] array = new object[4];
                    array[0] = "w=";
                    array[1] = num2;
                    if (false)
                    {
                        goto IL_16D;
                    }
                    array[2] = " h=";
                    array[3] = num3;
                    bsAttributesList = string.Concat(array);
                    if (num3 > 0.01)
                    {
                        goto IL_10F;
                    }
                    arg_122_0 = true;
                    goto IL_121;
                }
            IL_12B:
                if (!blGrow)
                {
                    goto IL_14A;
                }
                double arg_157_0;
                double expr_12F = arg_157_0 = num3;
                bool arg_177_0;
                if (!false)
                {
                    if (expr_12F > 4.0 && num2 > 4.0)
                    {
                        goto IL_14A;
                    }
                    arg_177_0 = false;
                    goto IL_176;
                }
            IL_14E:
                if (arg_157_0 >= 0.25)
                {
                    goto IL_16D;
                }
                if (!false)
                {
                    arg_177_0 = (num2 < 0.25);
                    goto IL_16E;
                }
                continue;
            IL_14A:
                if (!blGrow)
                {
                    arg_157_0 = num3;
                    goto IL_14E;
                }
                arg_177_0 = true;
                goto IL_172;
            IL_121:
                if (!arg_122_0)
                {
                    goto IL_12B;
                }
                return;
            IL_10F:
                arg_122_0 = (num2 <= 0.01);
                goto IL_121;
            IL_176:
                bool flag = arg_177_0;
                if (5 == 0)
                {
                    return;
                }
                if (flag)
                {
                    return;
                }
                this.GuestElement.AttributesMultipleSet(bsAttributesList, eMUpdateType.eMUT_Update);
                if (num2 > 1.0 || num2 < 0.0)
                {
                    goto IL_1CC;
                }
                if (2 != 0)
                {
                    break;
                }
                goto IL_10F;
            IL_172:
                goto IL_176;
            IL_16E:
                goto IL_172;
            IL_16D:
                arg_177_0 = false;
                goto IL_16E;
            IL_AC:
                arg_B5_0 = num2 - num;
                goto IL_B4;
            IL_A9:
                if (!blGrow)
                {
                    goto IL_AC;
                }
                arg_B5_0 = num2 + num;
                goto IL_B4;
            }
            bool arg_1CE_0 = num3 > 1.0 || num3 < 0.0;
            goto IL_1CD;
        IL_1CC:
            arg_1CE_0 = true;
        IL_1CD:
            if (!arg_1CE_0)
            {
                this.txtHeight.Text = Convert.ToString(num3);
                this.txtWidth.Text = Convert.ToString(num2);
            }
        }

        private void buttonZoomIn_Click(object sender, RoutedEventArgs e)
        {
            this.ZoomInOut(true);
        }

        private void buttonZoomOut_Click(object sender, RoutedEventArgs e)
        {
            this.ZoomInOut(false);
        }

        private void btnLoadOverlay_Click(object sender, RoutedEventArgs e)
        {
            this.StackGraphicSettingPanel1.Visibility = Visibility.Collapsed;
            this.StackGraphicSettingPanel2.Visibility = Visibility.Collapsed;
            this.SetTemplateListVisibility(true);
            this.templateType = "overlay";
            this.lstTemplates.IsEnabled = true;
            List<TemplateListItems> itemsSource = (from o in this.objTemplateList
                                                   where o.MediaType == 609
                                                   select o).ToList<TemplateListItems>();
            this.lstTemplates.ItemsSource = null;
            this.lstTemplates.ItemsSource = itemsSource;
            this.txtTemplateRotate.Text = "Video Overlays";
        }

        private void btnColorEffects_Click(object sender, RoutedEventArgs e)
        {
            if (false)
            {
                goto IL_39;
            }
            if (!false)
            {
            }
            this.HighlightSelectedButton("btnColorEffects");
            UIElement expr_13 = this.txtTemplateRotate;
            Visibility expr_18 = Visibility.Visible;
            if (6 != 0)
            {
                expr_13.Visibility = expr_18;
            }
        IL_1E:
            this.ShowHideControls("ColorEffects");
            if (2 != 0)
            {
            }
            UIElement expr_2E = this.lstTemplates;
            bool expr_33 = true;
            if (!false)
            {
                expr_2E.IsEnabled = expr_33;
            }
        IL_39:
            if (!false)
            {
                return;
            }
            goto IL_1E;
        }

        private void rbColorEffect_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.RadioButton radioButton = sender as System.Windows.Controls.RadioButton;
            VideoColorEffects videoColorEffects = new VideoColorEffects();
            bool? isChecked = radioButton.IsChecked;
            if (isChecked == true && radioButton.Name == "rbGrayScale")
            {
                this.PresetNode = "GrayScale";
                videoColorEffects = MLHelpers.VideoPresetColorEffects(1);
            }
            else
            {
                isChecked = radioButton.IsChecked;
                if (8 != 0)
                {
                    int arg_9D_0;
                    bool arg_B6_0;
                    if (isChecked.GetValueOrDefault())
                    {
                        if (6 == 0)
                        {
                            goto IL_114;
                        }
                        arg_B6_0 = ((arg_9D_0 = (isChecked.HasValue ? 1 : 0)) != 0);
                    }
                    else
                    {
                        arg_B6_0 = ((arg_9D_0 = 0) != 0);
                    }
                    if (4 != 0)
                    {
                        arg_B6_0 = (arg_9D_0 == 0 || !(radioButton.Name == "rbSepia"));
                    }
                    if (!arg_B6_0)
                    {
                        this.PresetNode = "Sepia";
                        videoColorEffects = MLHelpers.VideoPresetColorEffects(2);
                    }
                    else
                    {
                        isChecked = radioButton.IsChecked;
                        bool arg_15E_0;
                        bool arg_10D_0;
                        if (isChecked == true)
                        {
                            bool arg_101_0 = radioButton.Name == "rbNone";
                            do
                            {
                                arg_10D_0 = (arg_101_0 = (arg_15E_0 = !arg_101_0));
                                if (false)
                                {
                                    goto IL_15D;
                                }
                            }
                            while (-1 == 0);
                        }
                        else
                        {
                            arg_10D_0 = true;
                        }
                        bool flag = arg_10D_0;
                        int arg_145_0;
                        bool expr_10E = (arg_145_0 = (flag ? 1 : 0)) != 0;
                        if (!false)
                        {
                            if (!expr_10E)
                            {
                                goto IL_114;
                            }
                            isChecked = radioButton.IsChecked;
                            if (isChecked.GetValueOrDefault())
                            {
                                arg_145_0 = (isChecked.HasValue ? 1 : 0);
                            }
                            else
                            {
                                arg_145_0 = 0;
                            }
                        }
                        arg_15E_0 = (arg_145_0 == 0 || !(radioButton.Name == "rbInvert"));
                    IL_15D:
                        if (!arg_15E_0)
                        {
                            if (!false)
                            {
                                this.PresetNode = "Invert";
                                videoColorEffects = MLHelpers.VideoPresetColorEffects(4);
                            }
                        }
                    }
                    goto IL_17C;
                IL_114:
                    this.PresetNode = "None";
                }
                videoColorEffects = MLHelpers.VideoPresetColorEffects(3);
            }
        IL_17C:
            this.UpdateColorSliderValues(videoColorEffects);
        }

        private void UpdateColorSliderValues(VideoColorEffects colorEffects)
        {
            do
            {
                this.sldULevelSlider.Value = colorEffects.ULevel;
            }
            while (false);
            this.sldUVGainSlider.Value = colorEffects.UVGain;
            if (4 != 0)
            {
                this.sldVLevelSlider.Value = colorEffects.VLevel;
                this.sldYGainSlider.Value = colorEffects.YGain;
                this.sldYLevelSlider.Value = colorEffects.YLevel;
                this.sldBlackSlider.Value = colorEffects.BlackLevel;
                this.sldBrightnessSlider.Value = colorEffects.Brightness;
                this.sldColorSlider.Value = colorEffects.ColorGain;
            }
            this.sldContrastSlider.Value = colorEffects.Contrast;
            do
            {
                this.sldWhiteSlider.Value = colorEffects.WhiteLevel;
            }
            while (false);
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                VideoColorEffects videoColorEffects;
                while (true)
                {
                    videoColorEffects = new VideoColorEffects();
                    while (true)
                    {
                        VideoColorEffects expr_3A = MLHelpers.VideoPresetColorEffects(3);
                        if (7 != 0)
                        {
                            videoColorEffects = expr_3A;
                        }
                        this.rbNone.IsChecked = new bool?(true);
                        if (3 == 0)
                        {
                            break;
                        }
                        if (!true)
                        {
                            break;
                        }
                        if (!false)
                        {
                            goto Block_2;
                        }
                    }
                }
            Block_2:
                this.UpdateColorSliderValues(videoColorEffects);
            }
            while (7 == 0);
        }

        private void SetColorConversion(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.SetColorConversion();
        }

        private void SetBrightnessContrast(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            this.SetBrightnessContrast();
        }

        private void SetColorConversion()
        {
            bool arg_E0_0 = this.m_objColors == null;
            bool expr_E6;
            do
            {
                bool flag = arg_E0_0;
                expr_E6 = (arg_E0_0 = flag);
            }
            while (false);
            if (!expr_E6)
            {
                MG_COLOR_PARAM mG_COLOR_PARAM = new MG_COLOR_PARAM
                {
                    dblUlevel = this.sldULevelSlider.Value / 100.0,
                    dblUVGain = this.sldUVGainSlider.Value / 100.0,
                    dblVlevel = this.sldVLevelSlider.Value / 100.0,
                    dblYGain = this.sldYGainSlider.Value / 100.0,
                    dblYlevel = this.sldYLevelSlider.Value / 100.0
                };
                this.m_objColors.SetColorParam(ref mG_COLOR_PARAM, 1, 0);
            }
        }

        private void SetBrightnessContrast()
        {
            bool arg_E0_0 = this.m_objColors == null;
            bool expr_E6;
            do
            {
                bool flag = arg_E0_0;
                expr_E6 = (arg_E0_0 = flag);
            }
            while (false);
            if (!expr_E6)
            {
                MG_BRIGHT_CONT_PARAM mG_BRIGHT_CONT_PARAM = new MG_BRIGHT_CONT_PARAM
                {
                    dblWhiteLevel = this.sldWhiteSlider.Value / 100.0,
                    dblContrast = this.sldContrastSlider.Value / 100.0,
                    dblColorGain = this.sldColorSlider.Value / 100.0,
                    dblBrightness = this.sldBrightnessSlider.Value / 100.0,
                    dblBlackLevel = this.sldBlackSlider.Value / 100.0
                };
                this.m_objColors.SetBrightContParam(ref mG_BRIGHT_CONT_PARAM, 1, 0);
            }
        }

        private void LoadValuestoColorControls(VideoColorEffects colorEffects)
        {
            while (true)
            {
            IL_00:
                string presetEffects = colorEffects.PresetEffects;
                if (!false)
                {
                    bool flag = !(presetEffects == "Sepia");
                    bool arg_2F_0 = flag;
                    while (arg_2F_0)
                    {
                        bool expr_55 = arg_2F_0 = !(presetEffects == "GrayScale");
                        if (8 != 0)
                        {
                            if (expr_55)
                            {
                                goto IL_75;
                            }
                            if (!false)
                            {
                                goto Block_4;
                            }
                            goto IL_00;
                        }
                    }
                    break;
                }
                goto IL_8E;
            }
            this.rbSepia.IsChecked = new bool?(true);
        IL_46:
            goto IL_87;
        Block_4:
            this.rbGrayScale.IsChecked = new bool?(true);
        IL_73:
            goto IL_87;
        IL_75:
            this.rbNone.IsChecked = new bool?(true);
        IL_87:
            this.UpdateColorSliderValues(colorEffects);
        IL_8E:
            if (7 != 0)
            {
                do
                {
                    this.SetColorConversion();
                    if (5 == 0)
                    {
                        goto IL_73;
                    }
                }
                while (false);
                return;
            }
            goto IL_46;
        }

        private void btnOverlayChroma_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                this.StackGraphicSettingPanel1.Visibility = Visibility.Collapsed;
                if (true)
                {
                    this.StackGraphicSettingPanel2.Visibility = Visibility.Collapsed;
                    goto IL_26;
                }
                MItem mItem;
                bool flag;
                do
                {
                IL_61:
                    MLHelpers mLHelpers = new MLHelpers();
                    if (false)
                    {
                        goto IL_48;
                    }
                    VideoEditor.objChromaKey = mLHelpers.LoadChromaScreen(mItem, this.strOverlayStream);
                    flag = (VideoEditor.objChromaKey == null);
                }
                while (6 == 0);
                if (!flag)
                {
                    this.IsLoadOverlayChroma = true;
                    this.overlayChromaSetting = this.SaveChromaSetting(mItem);
                }
                goto IL_A2;
            IL_48:
                int num;
                this.m_objMixer.StreamsGet(this.strOverlayStream, out num, out mItem);
                if (6 != 0)
                {
                    goto IL_61;
                }
                continue;
            IL_26:
                num = 0;
                if (!string.IsNullOrEmpty(this.strOverlayStream))
                {
                    goto IL_48;
                }
            IL_A2:
                if (!false)
                {
                    if (!false)
                    {
                        break;
                    }
                    goto IL_26;
                }
            }
        }

       void IStyleConnector.Connect(int connectionId, object target)
        {
            switch (connectionId)
            {
                case 8:
                    break;
                case 9:
                    ((System.Windows.Controls.Image)target).MouseDown += new MouseButtonEventHandler(this.Image_PreviewMouseDown);
                    if (false)
                    {
                        return;
                    }
                    ((System.Windows.Controls.Image)target).TouchDown += new EventHandler<TouchEventArgs>(this.Image_PreviewMouseDown);
                    if (6 != 0)
                    {
                        goto IL_CF;
                    }
                    goto IL_120;
                case 10:
                    goto IL_D4;
                case 11:
                    return;
                case 12:
                    ((StackPanel)target).TouchDown += new EventHandler<TouchEventArgs>(this.lstDragImagesStackPanel_TouchDown);
                    goto IL_120;
                case 13:
                IL_141:
                    ((ContentControl)target).MouseDoubleClick += new MouseButtonEventHandler(this.ContentControl_MouseDoubleClick);
                    return;
                case 14:
                    if (!false)
                    {
                        ((System.Windows.Shapes.Rectangle)target).Drop += new System.Windows.DragEventHandler(this.Image_Drop);
                        return;
                    }
                    goto IL_D4;
                case 15:
                    ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnDropImgPlay_Click);
                    ((System.Windows.Controls.Button)target).MouseDoubleClick += new MouseButtonEventHandler(this.btnDropImgPlay_MouseDoubleClick);
                    return;
                default:
                    if (true)
                    {
                        if (connectionId != 48)
                        {
                            return;
                        }
                        if (!false)
                        {
                            ((System.Windows.Controls.CheckBox)target).Click += new RoutedEventHandler(this.ChkSelected_Click);
                            return;
                        }
                        goto IL_CF;
                    }
                    break;
            }
            ((System.Windows.Controls.Image)target).MouseDown += new MouseButtonEventHandler(this.Image_PreviewMouseDown);
            if (6 != 0)
            {
                ((System.Windows.Controls.Image)target).TouchDown += new EventHandler<TouchEventArgs>(this.Image_PreviewMouseDown);
            }
        IL_CF:
            return;
        IL_D4:
            ((System.Windows.Controls.Button)target).MouseDoubleClick += new MouseButtonEventHandler(this.btnImgPlay_MouseDoubleClick);
            ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.btnImgPlay_Click);
            return;
        IL_120:
            if (false)
            {
                goto IL_141;
            }
            ((StackPanel)target).MouseDown += new MouseButtonEventHandler(this.lstDragImagesStackPanel_MouseDown);
        }

        static VideoEditor()
        {
            // Note: this type is marked as 'beforefieldinit'.
            if (!true)
            {
                goto IL_3A;
            }
            VideoEditor.vsMediaFileName = "";
        IL_0D:
            VideoEditor.PrintOrderPageProperty = DependencyProperty.Register("PrintOrderPageList", typeof(ObservableCollection<VideoPage>), typeof(VideoEditor), new PropertyMetadata(new ObservableCollection<VideoPage>()));
            VideoEditor._lockObject = new object();
            VideoEditor.isVideoEditorStopped = true;
        IL_3A:
            VideoEditor.tempGraphicId = 100;
            if (!false)
            {
                return;
            }
            goto IL_0D;
        }
    }
}
