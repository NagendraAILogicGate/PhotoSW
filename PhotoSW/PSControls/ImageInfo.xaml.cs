using PhotoSW.IMIX.Model;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Threading;
using System.Xml;
using PhotoSW.ViewModels;

namespace PhotoSW.PSControls
{
    public partial class ImageInfo : UserControl, IComponentConnector
    {
        private bool _hideRequest = false;

        private bool _result = false;

        private UIElement _parent;

        public bool IsVideo = false;

        public static readonly DependencyProperty captureInfoProperty = DependencyProperty.Register("captureInfo", typeof(PhotoCaptureInfo), typeof(ImageInfo), new UIPropertyMetadata(new PhotoCaptureInfo()));

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

        public PhotoCaptureInfo captureInfodetails
        {
            get
            {
                return (PhotoCaptureInfo)base.GetValue(ImageInfo.captureInfoProperty);
            }
            set
            {
                base.SetValue(ImageInfo.captureInfoProperty, value);
            }
        }

        public ImageInfo()
        {
            this.InitializeComponent();
            base.Visibility = Visibility.Hidden;
            base.DataContext = this.captureInfodetails;
        }

        protected virtual void OnExecuteMethod()
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

        private void btnok_Click(object sender, RoutedEventArgs e)
        {
            this._result = true;
            this.HideHandlerDialog();
        }

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        public bool ShowHandlerDialog(PhotoCaptureInfo info)
        {
            if (!this.IsVideo)
            {
                if (true)
                {
                    this.btnCameraDetails.Visibility = Visibility.Visible;
                    goto IL_47;
                }
                goto IL_EF;
            }
        IL_1A:
            UIElement expr_1F = this.btnCameraDetails;
            Visibility expr_24 = Visibility.Collapsed;
            if (!false)
            {
                expr_1F.Visibility = expr_24;
            }
        IL_47:
            this.captureInfodetails = info;
            base.Visibility = Visibility.Visible;
            bool result;
            if (false)
            {
                return result;
            }
            this.ImageAttribute.DataContext = this.captureInfodetails;
            this._parent.IsEnabled = false;
            this._hideRequest = false;
        IL_8B:
            goto IL_F8;
        IL_EF:
            Thread.Sleep(20);
        IL_F8:
            if (!this._hideRequest)
            {
                if (false)
                {
                    goto IL_8B;
                }
                int arg_B9_0;
                if (!base.Dispatcher.HasShutdownStarted)
                {
                    bool expr_A4 = (arg_B9_0 = (base.Dispatcher.HasShutdownFinished ? 1 : 0)) != 0;
                    if (!false)
                    {
                        arg_B9_0 = ((!expr_A4) ? 1 : 0);
                    }
                }
                else
                {
                    if (false)
                    {
                        goto IL_1A;
                    }
                    arg_B9_0 = 0;
                }
                if (arg_B9_0 != 0)
                {
                    if (true)
                    {
                        base.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate
                        {
                        }));
                        goto IL_EF;
                    }
                    goto IL_EF;
                }
            }
            result = this._result;
            return result;
        }

        private void HideHandlerDialog()
        {
            if (!false)
            {
                this._hideRequest = true;
                Visibility expr_0E = Visibility.Collapsed;
                if (7 != 0)
                {
                    base.Visibility = expr_0E;
                }
                if (-1 != 0)
                {
                    this._parent.IsEnabled = true;
                }
            }
            while (false || false)
            {
            }
            this.OnExecuteMethod();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this._result = true;
            this.HideHandlerDialog();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this._result = false;
            this.HideHandlerDialog();
        }

        private void btnCameraDetails_Click(object sender, RoutedEventArgs e)
        {
            if (!false)
            {
                try
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    XmlDocument expr_22D = xmlDocument;
                    string expr_243 = this.captureInfodetails.MetaData;
                    if (!false)
                    {
                        expr_22D.LoadXml(expr_243);
                    }
                    XmlNode xmlNode = xmlDocument.SelectSingleNode("image");
                    if (xmlNode == null)
                    {
                        goto IL_1FA;
                    }
                    CameraAttribute cameraAttribute = new CameraAttribute();
                    cameraAttribute.CameraModel = (xmlNode.Attributes["CameraModel"].Value ?? string.Empty);
                IL_78:
                    cameraAttribute.CameraManufacture = (xmlNode.Attributes["CameraManufacture"].Value ?? string.Empty);
                    cameraAttribute.DateTaken = (xmlNode.Attributes["DateTaken"].Value ?? string.Empty);
                    cameraAttribute.Dimensions = (xmlNode.Attributes["Dimensions"].Value ?? string.Empty);
                    cameraAttribute.ExposureMode = (xmlNode.Attributes["ExposureMode"].Value ?? string.Empty);
                    cameraAttribute.ISO = (xmlNode.Attributes["ISO-SpeedRating"].Value ?? string.Empty);
                    cameraAttribute.Orientation = (xmlNode.Attributes["Orientation"].Value ?? string.Empty);
                    cameraAttribute.Sharpness = (xmlNode.Attributes["Sharpness"].Value ?? string.Empty);
                    cameraAttribute.HorizontalResolution = (xmlNode.Attributes["HorizontalResolution"].Value ?? string.Empty);
                    cameraAttribute.ExposureTime = (xmlNode.Attributes["ExposureTime"].Value ?? string.Empty);
                    cameraAttribute.ApertureValue = (xmlNode.Attributes["ApertureValue"].Value ?? string.Empty);
                    CameraAttribute dataContext = cameraAttribute;
                    this.CameraAttribute.DataContext = dataContext;
                IL_1FA:
                    this.CameraAttribute.Visibility = Visibility.Visible;
                    if (false)
                    {
                        goto IL_78;
                    }
                    this.ImageAttribute.Visibility = Visibility.Collapsed;
                }
                catch (Exception var_4_267)
                {
                }
            }
        }

        private void btnCameraOk_Click(object sender, RoutedEventArgs e)
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
            this.CameraAttribute.Visibility = Visibility.Collapsed;
        IL_11:
            if (!false)
            {
                this.ImageAttribute.Visibility = Visibility.Visible;
            }
        IL_20:
            if (!false)
            {
                return;
            }
            goto IL_04;
        }


    }
}
