using PhotoSW.Common;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;

namespace PhotoSW.PSControls//.DigiPhoto.usercontrol
{
    /// <summary>
    /// Interaction logic for DynamicImgCrop.xaml
    /// </summary>
    public partial class DynamicImgCrop : UserControl, IComponentConnector
    {
        private Brush _brOriginal;
        private double _canvasLeft;
        private double _canvasTop;
        private string _centerX = "";
        private string _centerY = "";
        private CroppingAdorner _clp;
    
        private string _cropSize = string.Empty;
        private int _drawX = 0;
        private int _drawY = 0;
        private FrameworkElement _felCur = null;
        private int _flipMode;
        private int _flipModeY;
        private UIElement _parent;
        private int _rotateangle;
        private RotateTransform _rotateTransform;
        private UIElement _shapeToRemove;
        private TransformGroup _transformGroup;
        private TranslateTransform _translateTransform;
        private ScaleTransform _zoomTransform;
        

        public DynamicImgCrop()
        {
            this.InitializeComponent();
            this.Onload();
          //  this.dragCanvas.IsEnabled = true;
            this.GrdsubCrop.Visibility = Visibility.Visible;
            this.GrdFlip.LayoutTransform = new TransformGroup();
            this.GrdRotate.LayoutTransform = new TransformGroup();
            this.grdZoomCanvas.Visibility = Visibility.Collapsed;
            this.GrdRotateCropParent.Visibility = Visibility.Visible;
            //DragCanvas.SetCanBeDragged(this.Opacitymsk, false);
            //DragCanvas.SetCanBeDragged(this.mainImage, false);
            //this.MyInkCanvas.SnapsToDevicePixels = true;
            //this.MyInkCanvas.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            //this.mainImage.SnapsToDevicePixels = true;
            //this.mainImage.SetValue(RenderOptions.EdgeModeProperty, EdgeMode.Aliased);
            //this.mainImage.OverridesDefaultStyle = true;
            //Panel.SetZIndex(this.imageundoGrid, 0);
            //Panel.SetZIndex(this.canbackgroundParent, 4);
            //Panel.SetZIndex(this.Opacitymsk, 2);
            //this.canbackgroundParent.IsHitTestVisible = false;
            //this.canbackground.IsHitTestVisible = false;
        }

        private void Onload()
        {
           // throw new NotImplementedException();
        }

        private void AddCropToElement(FrameworkElement fel, bool IsRedeye, Image cropImage, decimal aspectRatio)
        {
            // This item is obfuscated and can not be translated.
        }

        private void AddCropToElementDefault(FrameworkElement fel, Image cropImage)
        {
            // This item is obfuscated and can not be translated.
        }

        private void AntiRotate(int angle)
        {
            // This item is obfuscated and can not be translated.
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }

        private void btnantirotate_Click(object sender, RoutedEventArgs e)
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

        private void btnflip_Click(object sender, RoutedEventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }

        private void btnRotateclick_Click(object sender, RoutedEventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }

        private void btnSelectCrop3By3_Click(object sender, RoutedEventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }

        private void btnSelectCrop4by6_Click(object sender, RoutedEventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }

        private void btnSelectCrop5By7_Click(object sender, RoutedEventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }

        private void btnSelectCrop6By8_Click(object sender, RoutedEventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }

        private void btnSelectCrop8By10_Click(object sender, RoutedEventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }

        private void btnSelectReverse_Click(object sender, RoutedEventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }

        private void cleanResource()
        {
            // This item is obfuscated and can not be translated.
        }

        private void Crop()
        {
            // This item is obfuscated and can not be translated.
        }

        private void Flip(int mode)
        {
            // This item is obfuscated and can not be translated.
        }

        //private Rect GetCropRectangle(decimal constraintRatio)
        //{
        //    // This item is obfuscated and can not be translated.
        //}

        private void GrdBrightness_LayoutUpdated(object sender, EventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }


        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }

       
        private void RemoveCropFromCur()
        {
            // This item is obfuscated and can not be translated.
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            // This item is obfuscated and can not be translated.
        }

        private void Rotate(int angle)
        {
            // This item is obfuscated and can not be translated.
        }

        private void SetClipColorGrey()
        {
            // This item is obfuscated and can not be translated.
        }

        public void SetParent(UIElement parent)
        {
            // This item is obfuscated and can not be translated.
        }

     
        public void Zomout(bool orignal)
        {
            // This item is obfuscated and can not be translated.
        }
    }
}
