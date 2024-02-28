using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Baracoda.Cameleon.PC.Common;
using DigiPhoto;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using FrameworkHelper;
using PhotoSW.Shader;
using PhotoSW.Views;

namespace PhotoSW.PSControls
{
    /// <summary>
    /// Interaction logic for EditingControl.xaml
    /// </summary>
   public partial class EditingControl : UserControl, IComponentConnector, IStyleConnector
{
    // Fields
    public ContrastAdjustEffect _brighteff = new ContrastAdjustEffect();
    private Brush _brOriginal;
    private string _cartoon = "0";
    private string _centerX = "";
    private string _centerY = "";
    private CroppingAdorner _clp;
    private MonochromeEffect _colorfiltereff = new MonochromeEffect();
   // private bool _contentLoaded;
    private string _defoger = "0";
    private string _digimagic = "0";
    private string _emboss = "0";
    private FrameworkElement _felCur = null;
    private string _granite = "0";
    private double _GraphicsZoomFactor = 1.0;
    private UndoBrushEffect _greenUndoEffect = new UndoBrushEffect();
    private string _GreyScale = "0";
    private bool _hideRequest = false;
    private string _hue = "##";
    private string _invert = "0";
    private double _maxZoomFactor = 4.0;
    private UIElement _parent;
    private long _photoId;
    private int _previousPhotoId;
    private string _result = "done";
    private int _semiOrderProfileId;
    private string _sepia = "0";
    private string _Sharepen = "##";
    private ShEffect _sharpeff = new ShEffect();
    private ShiftHueEffect _shifthueeff = new ShiftHueEffect();
    private string _tempFileName;
    private MultiChannelContrastEffect _under = new MultiChannelContrastEffect();
    private string _underwater = "0";
    private int _x;
    private int _y;
    private double _ZoomFactor = 1.0;
    private double _ZoomFactorGreen = 1.0;
    //internal SolidColorBrush AliceBlue;
    //internal AngleRotate angleRotate1;
    //internal DrawingAttributes attribute;
    private double attributeHeight = 10.0;
    private double attributeWidth = 10.0;
    private string BackgroundDBValue = string.Empty;
    private string BackgroundSelectedValue = string.Empty;
   
    public string borderfilename = string.Empty;
    private string borderName;
   
    private int borderSelectedIndex = -1;
    private double bright = 0.0;
   
    private double canvasLeft;
    private double canvasTop;
    
    private bool checkDigimagic = false;
    private string ChromaBorderPath = string.Empty;
    private double ChromaCenterX = 0.0;
    private double ChromaCenterY = 0.0;
    private static string ChromaColorDefault;
    private Dictionary<string, decimal?> chromaDefaultInfo = new Dictionary<string, decimal?>();
    private double ChromaGridLeft = 0.0;
    private double ChromaGridTop = 0.0;
    private double ChromaZoomFactor = 0.0;
 
    private Color color;
    private string ColorCode = string.Empty;
   
    private double cont = 1.0;
  
    public string CropSize = "##";
    private double currentbrightness = 0.0;
    private Color currentcolor;
    private double currentcontrast = 0.0;
    private double currenthueshift = 0.0;
    private double currentsharpen = 0.0;
 
    public double dbBrit = 0.0;
    public double dbContr = 0.0;
    private string DefaultBackgroundImagePath = string.Empty;
    
    private int drawX = 0;
    private int drawY = 0;
    private Stack EffectLog;
    private object EffectsSender = null;
    private UIElement elementForContextMenu;
   
    private int fillSize = 5;
    private int FlipMode;
    private int FlipModeY;
    
    private List<LstMyItems> Frames = new List<LstMyItems>();
 
    private List<LstMyItems> Graphics = new List<LstMyItems>();
    private bool graphicsBorderApplied = false;
    private int graphicsCount = 0;
    private bool graphicsframeApplied = false;
    private int graphicsTextBoxCount = 0;
  
    private int gumballTextCount = 0;
    private double hgt = 10.0;
    private double hueshift = 0.0;
    private bool ImageClick = true;
  
    private int index = 0;
    private static Ellipse inkCanvasEllipse;
    private static Rectangle inkCanvasRectangle;
    private static MainWindow instance;
    private bool IsBtnBackgroundClicked = false;
    private bool IsbtnBackgroundWithoutChroma = false;
    private bool isChromaApplied = false;
    private bool IsChromaChanged = false;
    private bool IsComingOnLoad = false;
    private bool IsCropped = false;
    private bool IsDefaultBackgroundEnabled = false;
    private bool IsEffectChange = false;
    private bool IsEraserActive = false;
    private bool IsEraserDrawEllipseActive = false;
    private bool IsEraserDrawRectangleActive = false;
    public string IsGoupped;
    private bool IsGraphicsChange = false;
    private bool IsGreenCorrection = false;
    private bool isGreenImage = false;
    private bool IsGreenRemove = false;
    private bool IsLoad = false;
    private bool islstBackgroundVisible = false;
    private bool IsModerate = false;
    private bool IsMoreImages = true;
    private bool IsMoveEnabled = false;
    private bool isPrintButtonsVisible = false;
    public bool IsRestoreRideClick = false;
    public bool IsSceneApply = false;
    private bool IsSelectedMainImage = false;
    public bool isSingleScreenPreview = false;
    private bool IsZoomed = false;

    private int lastVisibleIndex = 0;
    
    private static double lightness;
    
    private List<string> LstGridEffects = new List<string>();
    
    public long MaxPhotoIdCriteria = 0L;
   
    public long MinPhotoIdCriteria = 0L;
    private string MktImgPath = string.Empty;
    private int mktImgTime = 0;
   
    public int NewReord = 0;
    private int NoOfDisplayItem = 4;
    
    private string OriginalBorder = string.Empty;
  
    private int previouscounter = -1;
    private string primaryColor = string.Empty;
    private string primaryColorDefault = string.Empty;
    private string primaryColorName = string.Empty;
    private int ProducttypeforGS = 0;
    private int ProductTypeId = 0;
   
    private bool rectangleEraser = false;
   
    private int rotateangle = 0;
    private RotateTransform rotateTransform;
    private static double saturation;
    public SearchDetailInfo searchDetails = new SearchDetailInfo();
    private string selectedbackground = string.Empty;
    private string selectedborder = string.Empty;
    public string selectedbordername = string.Empty;
    private Stack SerialLog;
    private bool SetRedeye = false;
    private UIElement shapeToRemove;
    private double sharpen = 0.0;
    public string specproductType = string.Empty;
   
    private float tolerance = float.Parse("0");
    private float toleranceDefault = float.Parse("0");
    private TransformGroup transformGroup;
    private TranslateTransform translateTransform;

    private bool undoEraser = false;
 
    private double wdt = 10.0;
  
    private double x = 0.0;
    private double y = 0.0;
   
    private ScaleTransform zoomTransform;

    // Methods
    static EditingControl()
    {
        // This item is obfuscated and can not be translated.
    }

    public EditingControl()
    {
        this.InitializeComponent();
        this.SerialLog = new Stack();
        this.EffectLog = new Stack();
        this.EnabledAllButtons();
       // DragCanvas.SetCanBeDragged(this.Opacitymsk, false);
       // DragCanvas.SetCanBeDragged(this.mainImage, false);
        this.LoadFeatures();
       // this.mainImage.MouseLeftButtonUp += new MouseButtonEventHandler(this.mainImage_MouseLeftButtonUp);
        this.IsEffectChange = false;
        this.IsGraphicsChange = false;
        //this.squre.Cursor = Cursors.None;
        //this.MyInkCanvas.SnapsToDevicePixels = true;
        //this.MyInkCanvas.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
        //this.mainImage.SnapsToDevicePixels = true;
        //this.mainImage.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
        //this.mainImage.OverridesDefaultStyle = true;
        //this.GrdGreenScreenDefault.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
        //Panel.SetZIndex(this.imageundoGrid, 0);
        //Panel.SetZIndex(this.canbackgroundParent, 4);
        //Panel.SetZIndex(this.Opacitymsk, 2);
        //Panel.SetZIndex(this.frm, 6);
        //this.canbackgroundParent.IsHitTestVisible = false;
        //this.canbackground.IsHitTestVisible = false;
        this.FillProductCombo();
        this.GetBackImageSettings();
        this.IsImageDirtyState = false;
       // this.lstStrip.ItemContainerGenerator.StatusChanged += new EventHandler(this.ItemContainerGenerator_StatusChanged);
    }

    void IStyleConnector.Connect(int connectionId, object target)
    {
        // This item is obfuscated and can not be translated.
    }



    private void AddCropToElement(FrameworkElement fel, bool IsRedeye, Image cropImage, decimal aspectRatio)
    {
        // This item is obfuscated and can not be translated.
    }

    private void AddDefaultItems()
    {
        // This item is obfuscated and can not be translated.
    }

    private void angleAltitudeSelector1_AngleChanged()
    {
        // This item is obfuscated and can not be translated.
    }

    private void AntiRotate(int angle)
    {
        // This item is obfuscated and can not be translated.
    }

    private void AntiRotateButton_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ApplyBorder(string FileName, string selectedborder, int ProductType, object sender)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ApplyEffectsAgainAfterChroma()
    {
        // This item is obfuscated and can not be translated.
    }

    private void BindStrip()
    {
        // This item is obfuscated and can not be translated.
    }

    private void BrightnessMinus_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void BrightnessPlus_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void BringToFront_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnAddgraphics_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnantirotate_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnBackground_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnbringtofront_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnClose_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnClose1_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnColorEffects_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnColorEffectsfilters_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnCrop_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnDefogger_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btndelete_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnDigiMagic_Click(object sender, RoutedEventArgs e)
    {
        this.DigiMagic();
    }

    private void btndown_Click(object sender, RoutedEventArgs e)
    {
        this.down();
    }

    private void btnEdgeDetect_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnEmboss_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnenlargeminus_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnenlargeplus_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    public void btnExit_Click(object sender, EventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnflip_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnframe_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btngraphics_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnGreenScreenBackGround_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnGreyScale_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btngrph_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btngrph_GotFocus(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnHue_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnInvert_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnleft_Click(object sender, RoutedEventArgs e)
    {
        this.left();
    }

    private void btnMoveImage_Click(object sender, RoutedEventArgs e)
    {
        this.MoveImageStartStop();
    }

    private void btnRestore_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnRestoreBrightCont_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnRestoreGraphics_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnrestoremainimg_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnRevert_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnright_Click(object sender, RoutedEventArgs e)
    {
        this.right();
    }

    private void btnRotateclick_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnrotateGraphics_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnSaveBack_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnselect_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnSelectCrop3by3_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnSelectCrop4by6_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnSelectCrop5by7_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnselectEightByEleven_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnselectfourBySix_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnSelectReverse_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnSendtoBack_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnSepia_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnSharpen_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnStartMove_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnThumbnails_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnUnderWater_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void btnundocoloreffects_Click(object sender, RoutedEventArgs e)
    {
        this.UndoEffect();
    }

    private void btnup_Click(object sender, RoutedEventArgs e)
    {
        this.up();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void canbackgroundold_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void CancelButtoncolor_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void CancelButtoncoloreffect_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void CanvasInkInkCanvas_MouseEnter(object sender, MouseEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    //private static RenderTargetBitmap CaptureScreen(Visual target, double dpiX, double dpiY, bool Isrotate)
    //{
    //    // This item is obfuscated and can not be translated.
    //}

    //private RenderTargetBitmap CaptureScreenForCrop(Grid grdzoomOut, double dpiX, double dpiY, bool Isrotate)
    //{
    //    // This item is obfuscated and can not be translated.
    //}

    //private RenderTargetBitmap CaptureScreenForGreenScreen(Grid forWdht, double dpiX, double dpiY, bool Isrotate)
    //{
    //    // This item is obfuscated and can not be translated.
    //}

    //private RenderTargetBitmap CaptureScreenForPNGImage(Grid forWdht, double dpiX, double dpiY, bool Isrotate)
    //{
    //    // This item is obfuscated and can not be translated.
    //}

    private void Cartoonize_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void Cartoonizeeffect()
    {
        // This item is obfuscated and can not be translated.
    }

    private void ChangeCheckedEffect()
    {
        // This item is obfuscated and can not be translated.
    }

    private void ClearResources()
    {
        // This item is obfuscated and can not be translated.
    }

    private void CmbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void cmbFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void CmbFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void CmbProductType_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    public void CompileEffectChanged(VisualBrush compiledBitmapImage, int ProductType, int Height, int Width)
    {
        // This item is obfuscated and can not be translated.
    }

    //public BitmapImage compilephoto(double dpi, bool PrintJob)
    //{
    //    // This item is obfuscated and can not be translated.
    //}

    private void CompleteRestore()
    {
        // This item is obfuscated and can not be translated.
    }

    private void ContrastMinus_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ContrastPlus_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ControlCleanup()
    {
        // This item is obfuscated and can not be translated.
    }

    //public BitmapImage ConvertToBitmap()
    //{
    //    // This item is obfuscated and can not be translated.
    //}

    private void Crop()
    {
        // This item is obfuscated and can not be translated.
    }

    private void Defogger()
    {
        // This item is obfuscated and can not be translated.
    }

    private void DelayedAction()
    {
        // This item is obfuscated and can not be translated.
    }

    //[DllImport("gdi32.dll")]
    //public static extern bool DeleteObject(IntPtr hObject);
    private void DigiMagic()
    {
        // This item is obfuscated and can not be translated.
    }

    private void disableAllButtons()
    {
        // This item is obfuscated and can not be translated.
    }

    private void DisableButtonForLayering()
    {
        // This item is obfuscated and can not be translated.
    }

    private void DisableSideButton()
    {
        // This item is obfuscated and can not be translated.
    }

    private void down()
    {
        // This item is obfuscated and can not be translated.
    }

    private void EdgeDetecteffect()
    {
        // This item is obfuscated and can not be translated.
    }

    private void EditImage(MyImageClass objItem)
    {
        // This item is obfuscated and can not be translated.
    }

    private void EffectLogOperation(LogEffect objeffectOperation)
    {
        // This item is obfuscated and can not be translated.
    }

    private void Effects_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
    }

    private void Embosseffect()
    {
        // This item is obfuscated and can not be translated.
    }

    private void EnableButtonForLayering()
    {
        // This item is obfuscated and can not be translated.
    }

    private void EnabledAllButtons()
    {
        // This item is obfuscated and can not be translated.
    }

    private void EnableSideButton()
    {
        // This item is obfuscated and can not be translated.
    }

    private void FillProductCombo()
    {
        // This item is obfuscated and can not be translated.
    }

    //private Button FindVisualChild<item>(DependencyObject obj, string borderName) where item: DependencyObject
    //{
    //    // This item is obfuscated and can not be translated.
    //}

    //public static childItem FindVisualChild1<childItem>(DependencyObject obj) where childItem: DependencyObject
    //{
    //    // This item is obfuscated and can not be translated.
    //}

    private void Flip(int mode)
    {
        // This item is obfuscated and can not be translated.
    }

    private void GetBackImageSettings()
    {
        // This item is obfuscated and can not be translated.
    }

    private Rect GetCropRectangle(decimal constraintRatio)
    {
        Rect Rect = new Rect();
        return Rect;// This item is obfuscated and can not be translated.
    }

    private void GetMktImgInfo()
    {
        // This item is obfuscated and can not be translated.
    }

    private void GrdBrightness_LayoutUpdated(object sender, EventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void GrdEffects_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void GreyScaleeffect()
    {
        // This item is obfuscated and can not be translated.
    }

    private void HideGraphics()
    {
        // This item is obfuscated and can not be translated.
    }

    private void HideHandlerDialog()
    {
        // This item is obfuscated and can not be translated.
    }

    private void ImgLoader()
    {
        // This item is obfuscated and can not be translated.
    }

    

    private void InvertEffect()
    {
        // This item is obfuscated and can not be translated.
    }

    private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void jangleAltitudeSelector1_AngleChanged()
    {
        // This item is obfuscated and can not be translated.
    }

    private void jrotate_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void left()
    {
        // This item is obfuscated and can not be translated.
    }

    public void LoadBackground()
    {
        // This item is obfuscated and can not be translated.
    }

    private void LoadBackgroundInGrid(BitmapImage objCurrent)
    {
        // This item is obfuscated and can not be translated.
    }

    private void LoadFeatures()
    {
        if (1 != 0)
        {
            if (3 == 0)
            {
                return;
            }
            this.LoadFrames();
            if (0 == 0)
            {
            }
            this.LoadGraphics();
        }
        if (0 == 0)
        {
            this.LoadBackground();
        }
    }

    public void LoadFrames()
    {
        // This item is obfuscated and can not be translated.
    }

    private void LoadFromDB()
    {
        // This item is obfuscated and can not be translated.
    }

    public void LoadGraphics()
    {
        // This item is obfuscated and can not be translated.
    }

    private void loadImagestoList()
    {
        // This item is obfuscated and can not be translated.
    }

    public void LoadPhotoAlbum()
    {
        // This item is obfuscated and can not be translated.
    }

    private void LoadXaml(string inputXml)
    {
        // This item is obfuscated and can not be translated.
    }

    public void LoadXml(string ImageXml)
    {
        // This item is obfuscated and can not be translated.
    }

    private void LogOperation(LogObject objOperation)
    {
        // This item is obfuscated and can not be translated.
    }

    private void lstBackground_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void lstStrip_VisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void mainImage_MouseDown(object sender, MouseButtonEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void mainImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void mainImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void mainImage_MouseLeftButtonUp1(object sender, MouseButtonEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void mainImage_MouseMove_1(object sender, MouseEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void mainImage_TouchDown(object sender, TouchEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void MoveImageStartStop()
    {
        // This item is obfuscated and can not be translated.
    }

    private void MyInkCanvas_KeyDown(object sender, KeyEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void MyInkCanvas_MouseEnter(object sender, MouseEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void Noeffect()
    {
        // This item is obfuscated and can not be translated.
    }

    private void objCurrent_Loaded(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void OkButtoncolor_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void OkButtoncoloreffect_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    public void Onload(bool crop, bool isGreenImageParam, string graphicEffect, bool IsGumBallshow)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ReloadAllGraphicsEffect()
    {
        // This item is obfuscated and can not be translated.
    }

    public void RemoveAllBorders()
    {
        // This item is obfuscated and can not be translated.
    }

    private void RemoveAllGraphicsEffect()
    {
        // This item is obfuscated and can not be translated.
    }

    private void RemoveAllShaderEffects()
    {
        // This item is obfuscated and can not be translated.
    }

    private void RemoveBorder(string FileName, string selectedborder, int ProductType, object sender)
    {
        // This item is obfuscated and can not be translated.
    }

    private void RemoveCropFromCur()
    {
        // This item is obfuscated and can not be translated.
    }

    private void RepeatButton_MouseWheel(object sender, MouseWheelEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void RepeatButton_MouseWheel_1(object sender, MouseWheelEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void RepeatButton_MouseWheel_2(object sender, MouseWheelEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ResetZOrder()
    {
        // This item is obfuscated and can not be translated.
    }

    private void ResizeWPFImage(string sourceImage, int maxHeight, string saveToPath)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ResizeWPFImage(BitmapSource sourceImage, int maxHeight, string saveToPath)
    {
        // This item is obfuscated and can not be translated.
    }

    private void right()
    {
        // This item is obfuscated and can not be translated.
    }

    private void Rotate(int angle)
    {
        // This item is obfuscated and can not be translated.
    }

    private void RotateInButton_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    public void SaveCropEffectsintoDB()
    {
        // This item is obfuscated and can not be translated.
    }

    private void SaveCropNRedEyeImage(BitmapSource mainImageSouce, string operation)
    {
        // This item is obfuscated and can not be translated.
    }

    public void SaveEffectsintoDB()
    {
        PhotoBusiness business = new PhotoBusiness();
    }

    private void SaveintoDB(string input)
    {
        try
        {
            PhotoBusiness business;
        Label_0001:
            while (0 != 0)
            {
            }
            goto Label_0016;
        Label_0009:
            if (4 == 0)
            {
                goto Label_0001;
            }
            goto Label_002F;
        Label_0016:
            business = new PhotoBusiness();
            goto Label_0009;
        }
        catch (Exception exception)
        {
            string message = ErrorHandler.ErrorHandler.CreateErrorMessage(exception);
            do
            {
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            while (0 != 0);
        }
    Label_002F:
        if (-1 != 0)
        {
        }
    }

    private void SaveOnImageChange()
    {
        // This item is obfuscated and can not be translated.
    }

    private string SaveXaml(ref bool graphicsChange)
    {
        return "";  // This item is obfuscated and can not be translated.
    }

    public void SaveXml(string operation, string value, bool childnode)
    {
        // This item is obfuscated and can not be translated.
    }

    private void SelectObject(object sender, MouseButtonEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void SendToBack_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void Sepia()
    {
        // This item is obfuscated and can not be translated.
    }

    private void SetClipColorGrey()
    {
        // This item is obfuscated and can not be translated.
    }

    public void SetEffect()
    {
        // This item is obfuscated and can not be translated.
    }

    public void SetParent(UIElement parent)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ShowGraphics()
    {
        // This item is obfuscated and can not be translated.
    }

    public string ShowHandlerDialog(bool IsCrop, bool IsGreen, string Layering)
    {
        return "";  // This item is obfuscated and can not be translated.
    }

    public void ShowStripImages()
    {
        // This item is obfuscated and can not be translated.
    }

   

    private void txtContent_GotFocus(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void txtContent_LostFocus(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void txtContent_TextChanged(object sender, TextChangedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void txtTest_TextChanged(object sender, TextChangedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void UncheckEffectsButton()
    {
        // This item is obfuscated and can not be translated.
    }

    private void UncheckGraphicsButton()
    {
        // This item is obfuscated and can not be translated.
    }

    private void UnderWater()
    {
        // This item is obfuscated and can not be translated.
    }

    private void Undo()
    {
        // This item is obfuscated and can not be translated.
    }

    private void UndoEffect()
    {
        // This item is obfuscated and can not be translated.
    }

    private void up()
    {
        // This item is obfuscated and can not be translated.
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        this.ClearResources();
        MemoryManagement.FlushMemory();
    }

    private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void Window_Unloaded(object sender, RoutedEventArgs e)
    {
        MemoryManagement.FlushMemory();
    }

    private void Window1_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void Zomout(bool orignal)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ZoomInButton_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ZoomInButton_Click1(object sender, RoutedEventArgs e)
    {
        this.IsImageDirtyState = (bool)sender;
        this.ZoomInButtonClick1();
    }

    private void ZoomInButtonClick1()
    {
        // This item is obfuscated and can not be translated.
    }

    private void ZoomInButtonGreenScreen_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ZoomOutButton_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ZoomOutButton_Click1(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    private void ZoomOutButtonGreenScreen_Click(object sender, RoutedEventArgs e)
    {
        // This item is obfuscated and can not be translated.
    }

    // Properties
    public string CropFolderPath
    {
        get;
        set;
    }

    public string DateFolder { get; set; }
    

    public string GraphicEffect
    {
        get;
        set;
    }

    public string HotFolderPath
    {
        get;
        set;
    }

    public string ImageEffect
    {
        get;
        set;
    }

    public bool IsImageDirtyState
    {
        get;
        set;
    }

    public List<MyImageClass> lstMyImageClass
    {
        get;
        set;
    }

    public long PhotoId
    {
        get;
        set;
    }

    public string PhotoName
    {
        get;
        set;
    }

    public int PreviousPhotoId
    {
        get;
        set;
    }

    public DrawingAttributes SelectedDrawingAttributes
    {
        get;
        set;
    }

    public int selectedIndex
    {
        get;
        set;
    }

    public int semiOrderProfileId
    {
        get;
        set;
    }

    public SemiOrderSettings semiOrderSettings
    {
        get;
        set;
    }

    public string SpecImageEffect
    {
        get;
        set;
    }

    public string SpecLayering
    {
        get;
        set;
    }

    public string tempfilename
    {
        get;
        set;
    }
}

 

}
