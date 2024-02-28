using DigiAuditLogger;
using DigiPhoto.Common;
using DigiPhoto.IMIX.Business;
using DigiPhoto.IMIX.Model;
using PhotoSW.Manage;
using PhotoSW.Shader;
using DigiPhoto.Utility.Repository.Data;
using ErrorHandler;
using FrameworkHelper;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;
using DigiPhoto;

namespace PhotoSW.PSControls
{
    public partial class AddEditSpecPrintProfile : System.Windows.Controls.UserControl, IComponentConnector, IStyleConnector
    {
        private class TextContent
        {
            public string Id
            {
                get;
                set;
            }

            public string Name
            {
                get;
                set;
            }

            public int FontSize
            {
                get;
                set;
            }

            public string FontColor
            {
                get;
                set;
            }

            public string FontFamily
            {
                get;
                set;
            }
        }

        private List<AddEditSpecPrintProfile.TextContent> lstTextCollection;

        private List<AddEditSpecPrintProfile.TextContent> lstTextContent;

        private UIElement elementForContextMenu;

        private Dictionary<string, string> lstBGList = null;

        private string SpecFileName = string.Empty;

        private int _numValue = 0;

        private double _ZoomFactor = 1.0;

        private double _GraphicsZoomFactor = 1.0;

        private TransformGroup transformGroup;

        private ScaleTransform zoomTransform = new ScaleTransform();

        private UIElement _parentConfig;

        private int pkey = 0;

        private int selectedProductType = 0;

        private List<BorderInfo> lstBorderList;

        private ContrastAdjustEffect _brighteff = new ContrastAdjustEffect();

        private ContrastAdjustEffect _conteff = new ContrastAdjustEffect();

        private double saturation = 0.38;

        private double lightness = 0.15;

        private string itemNo;

        private List<ProductTypeInfo> lstproductTypes;

        //internal Grid grdSpecProf;

        //internal StackPanel spZoompanel;

        //private System.Windows.Controls.TextBox txtAngle;

        //private RepeatButton cmdUp;

        //private RepeatButton cmdDown;

      

       // private bool _contentLoaded;

        public SemiOrderSettings semiOrderSettings
        {
            get;
            set;
        }

        public int NumValue
        {
            get
            {
                return this._numValue;
            }
            set
            {
                while (true)
                {
                    if (true)
                    {
                        goto IL_04;
                    }
                IL_10:
                    if (false)
                    {
                        continue;
                    }
                    
                    this.txtAngle.Text = value.ToString();
                    if (8 != 0)
                    {
                        break;
                    }
                IL_04:
                    if (3 != 0)
                    {
                        this._numValue = value;
                        goto IL_10;
                    }
                    break;
                }
            }
        }

        public int LocationId
        {
            get;
            set;
        }

        public AddEditSpecPrintProfile()
        {
            this.InitializeComponent();
            this.BindBorders();
            this.FillProductCombo();
            this.LoadGraphics();
            //this.ucDynamicImgCrop.SetParent(this.grdSpecProf);
            if (this.chkBorder.IsChecked == false)
            {
                this.cmbVerticalBorder.IsEnabled = false;
                this.cmbborder.IsEnabled = false;
            }
            if (this.chkBG.IsChecked == false)
            {
                this.cmbBG.IsEnabled = false;
            }
            this.loadProductType();
            this.AddDefaultFontSize();
            this.lstTextCollection = new List<AddEditSpecPrintProfile.TextContent>();
            this.lstTextContent = new List<AddEditSpecPrintProfile.TextContent>();
        }

        public void SetParentConfig(UIElement parent)
        {
            this._parentConfig = parent;
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

        private void chkCrop_Checked(object sender, RoutedEventArgs e)
        {
            this.btnCropEdit.IsEnabled = true;
        }

        private void chkCrop_Unchecked(object sender, RoutedEventArgs e)
        {
            this.btnCropEdit.IsEnabled = false;
        }

        private void btnSaveAutoCorrect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedProducts = this.GetSelectedProducts();
                if (string.IsNullOrWhiteSpace(selectedProducts))
                {
                    System.Windows.MessageBox.Show("Please select product type.");
                }
                else if (this.chkBorder.IsChecked == true && this.cmbborder.SelectedIndex == 0 && this.cmbVerticalBorder.SelectedIndex == 0)
                {
                    System.Windows.MessageBox.Show("Please select border.");
                }
                else
                {
                    bool arg_BC_0 = this.chkBG.IsChecked == true;
                    string text2;
                    string text3;
                    string text4;
                    string text5;
                    string text6;
                    string text7;
                    string dG_SemiOrder_BG;
                    StringBuilder stringBuilder;
                    while (true)
                    {
                        if (arg_BC_0)
                        {
                            goto IL_BE;
                        }
                        bool arg_D9_0;
                        if (!false)
                        {
                            arg_D9_0 = true;
                            goto IL_D8;
                        }
                        goto IL_201;
                    IL_6DC:
                        bool arg_6DC_0;
                        bool flag = arg_6DC_0;
                        bool expr_6DE = arg_BC_0 = flag;
                        XmlReader xmlReader;
                        if (!false)
                        {
                            if (!expr_6DE)
                            {
                                string text = xmlReader.Name.ToString().ToLower();
                                if (text != null)
                                {
                                    if (text == "scaletransform")
                                    {
                                        if (xmlReader.GetAttribute("CenterX") != null)
                                        {
                                            text2 = xmlReader.GetAttribute("CenterX").ToString();
                                        }
                                        if (xmlReader.GetAttribute("CenterY") != null)
                                        {
                                            text3 = xmlReader.GetAttribute("CenterY").ToString();
                                        }
                                    }
                                }
                            }
                            goto IL_768;
                        }
                        continue;
                    IL_D8:
                        if (!arg_D9_0)
                        {
                            break;
                        }
                        if (5 != 0)
                        {
                            bool? isChecked = this.chkCrop.IsChecked;
                            bool arg_11A_0;
                            if (isChecked.GetValueOrDefault())
                            {
                                arg_11A_0 = isChecked.HasValue;
                            }
                            else
                            {
                                if (6 == 0)
                                {
                                    goto IL_BE;
                                }
                                arg_11A_0 = false;
                            }
                            if (!arg_11A_0)
                            {
                                goto IL_13D;
                            }
                            bool expr_121 = arg_6DC_0 = string.IsNullOrWhiteSpace(Configuration.HorizontalCropCoordinates);
                            if (false)
                            {
                                goto IL_6DC;
                            }
                            if (!expr_121)
                            {
                                goto IL_13D;
                            }
                            int arg_13F_0 = (!string.IsNullOrWhiteSpace(Configuration.VerticalCropCoordinates)) ? 1 : 0;
                        IL_13E:
                            if (arg_13F_0 == 0)
                            {
                                goto Block_16;
                            }
                            text4 = string.Empty;
                            if (this.cmbborder.SelectedItem != null)
                            {
                                text4 = ((BorderInfo)this.cmbborder.SelectedItem).DG_Border;
                                bool expr_18E = (arg_13F_0 = (text4.Equals("--Select--", StringComparison.CurrentCultureIgnoreCase) ? 1 : 0)) != 0;
                                if (3 == 0)
                                {
                                    goto IL_13B;
                                }
                                if (expr_18E)
                                {
                                    text4 = string.Empty;
                                }
                            }
                            else
                            {
                                text4 = string.Empty;
                            }
                            text5 = string.Empty;
                            if (this.cmbborder.SelectedItem != null)
                            {
                                text5 = ((BorderInfo)this.cmbVerticalBorder.SelectedItem).DG_Border;
                                if (text5.Equals("--Select--", StringComparison.CurrentCultureIgnoreCase))
                                {
                                    text5 = string.Empty;
                                }
                                goto IL_201;
                            }
                            goto IL_201;
                        IL_13D:
                            arg_13F_0 = 1;
                        IL_13B:
                            goto IL_13E;
                        }
                        goto IL_5C1;
                    IL_BE:
                        arg_D9_0 = (this.cmbBG.SelectedIndex != 0);
                        goto IL_D8;
                    IL_768:
                        if (!xmlReader.Read())
                        {
                            goto Block_33;
                        }
                        arg_6DC_0 = (xmlReader.NodeType != XmlNodeType.Element);
                        goto IL_6DC;
                    IL_5C1:
                        text6 = "-1";
                        text7 = "-1";
                        text2 = "-1";
                        text3 = "-1";
                        XmlDocument xmlDocument;
                        string xml;
                        if (!false)
                        {
                            foreach (object current in xmlDocument.ChildNodes[0].Attributes)
                            {
                                string text = ((XmlAttribute)current).Name.ToLower();
                                if (text != null)
                                {
                                    if (!(text == "canvas.left"))
                                    {
                                        if (text == "canvas.top")
                                        {
                                            text7 = ((XmlAttribute)current).Value.ToString();
                                        }
                                    }
                                    else
                                    {
                                        text6 = ((XmlAttribute)current).Value.ToString();
                                    }
                                }
                            }
                            XmlDocument xmlDocument2 = new XmlDocument();
                            xmlDocument2.LoadXml(xml);
                            xmlReader = XmlReader.Create(new StringReader(xmlDocument2.InnerXml.ToString()));
                            goto IL_768;
                        }
                        goto IL_789;
                    IL_201:
                        dG_SemiOrder_BG = string.Empty;
                        if (this.cmbBG.SelectedItem != null && this.cmbBG.SelectedIndex > 0)
                        {
                            dG_SemiOrder_BG = ((KeyValuePair<string, string>)this.cmbBG.SelectedItem).Key;
                        }
                        stringBuilder = new StringBuilder();
                        //foreach (object current2 in this.dragCanvas.Children)
                        //{
                        //    if (current2 is System.Windows.Controls.Button)
                        //    {
                        //        System.Windows.Controls.Button button = (System.Windows.Controls.Button)current2;
                        //        string text8 = "-1";
                        //        double num;
                        //        try
                        //        {
                        //            num = ((RotateTransform)button.RenderTransform).Angle;
                        //            text8 = num.ToString();
                        //        }
                        //        catch (Exception)
                        //        {
                        //        }
                        //        double top = Canvas.GetTop(button);
                        //        double left = Canvas.GetLeft(button);
                        //        string text9 = ((System.Windows.Controls.Image)button.Content).Source.ToString();
                        //        int num2 = text9.Split(new char[]
                        //        {
                        //            '/'
                        //        }).Count<string>();
                        //        text9 = text9.Split(new char[]
                        //        {
                        //            '/'
                        //        })[num2 - 1].ToString();
                        //        TransformGroup transformGroup = button.GetValue(UIElement.RenderTransformProperty) as TransformGroup;
                        //        RotateTransform rotateTransform = new RotateTransform();
                        //        ScaleTransform scaleTransform = new ScaleTransform();
                        //        if (transformGroup != null)
                        //        {
                        //            if (transformGroup.Children.Count > 0)
                        //            {
                        //                if (transformGroup.Children[0] is ScaleTransform)
                        //                {
                        //                    if (false)
                        //                    {
                        //                        goto IL_3ED;
                        //                    }
                        //                    scaleTransform = (ScaleTransform)transformGroup.Children[0];
                        //                }
                        //                else if (transformGroup.Children[0] is RotateTransform)
                        //                {
                        //                    rotateTransform = (RotateTransform)transformGroup.Children[0];
                        //                    num = rotateTransform.Angle;
                        //                    goto IL_3ED;
                        //                }
                        //                goto IL_3F8;
                        //            IL_3ED:
                        //                text8 = num.ToString();
                        //            }
                        //        IL_3F8:
                        //            if (transformGroup.Children.Count > 1)
                        //            {
                        //                if (transformGroup.Children[1] is ScaleTransform)
                        //                {
                        //                    scaleTransform = (ScaleTransform)transformGroup.Children[1];
                        //                }
                        //                else if (transformGroup.Children[1] is RotateTransform)
                        //                {
                        //                    rotateTransform = (RotateTransform)transformGroup.Children[1];
                        //                    num = rotateTransform.Angle;
                        //                    text8 = num.ToString();
                        //                }
                        //            }
                        //        }
                        //        StringBuilder arg_564_0 = stringBuilder;
                        //        object[] array = new object[17];
                        //        array[0] = "<graphics wthsource ='";
                        //        array[1] = button.Width;
                        //        array[2] = "' source ='";
                        //        array[3] = text9;
                        //        array[4] = "' angle='";
                        //        array[5] = text8;
                        //        array[6] = "' top ='";
                        //        array[7] = top;
                        //        array[8] = "' left='";
                        //        array[9] = left;
                        //        array[10] = "' scalex ='";
                        //        object[] arg_518_0 = array;
                        //        int arg_518_1 = 11;
                        //        num = scaleTransform.ScaleX;
                        //        arg_518_0[arg_518_1] = num.ToString();
                        //        array[12] = "' scaley ='";
                        //        object[] arg_537_0 = array;
                        //        int arg_537_1 = 13;
                        //        num = scaleTransform.ScaleY;
                        //        arg_537_0[arg_537_1] = num.ToString();
                        //        array[14] = "' zoomfactor = '";
                        //        array[15] = button.Tag.ToString();
                        //        array[16] = "' zindex='4'></graphics>";
                        //        arg_564_0.Append(string.Concat(array));
                        //    }
                        //}
                        xml = XamlWriter.Save(this.GrdBrightness);
                        xmlDocument = new XmlDocument();
                        xmlDocument.LoadXml(xml);
                        StringBuilder stringBuilder2 = new StringBuilder();
                        goto IL_5C1;
                    }
                    System.Windows.MessageBox.Show("Please select background.");
                    return;
                Block_16:
                    System.Windows.MessageBox.Show("Please Set the cropping Coordinates");
                    return;
                Block_33:
                    string allTextLogos = this.GetAllTextLogos();
                    string[] array2 = new string[9];
                IL_789:
                    array2[0] = this._ZoomFactor.ToString();
                    array2[1] = ",";
                    array2[2] = text6.ToString();
                    array2[3] = ",";
                    array2[4] = text7;
                    array2[5] = ",";
                    array2[6] = text2;
                    array2[7] = ",";
                    array2[8] = text3.ToString();
                    string dG_SemiOrder_Image_ZoomInfo = string.Concat(array2);
                    SemiOrderSettings semiOrderSettings = new SemiOrderSettings();
                    semiOrderSettings.DG_SemiOrder_Settings_Pkey = this.pkey;
                    semiOrderSettings.DG_SemiOrder_Settings_AutoBright = this.chkbrightness.IsChecked;
                    semiOrderSettings.DG_SemiOrder_Settings_AutoBright_Value = new double?(Convert.ToDouble((this.txtbrightness.Text == "") ? "0" : this.txtbrightness.Text));
                    semiOrderSettings.DG_SemiOrder_Settings_AutoContrast = this.chkcontrast.IsChecked;
                    semiOrderSettings.DG_SemiOrder_Settings_AutoContrast_Value = new double?(Convert.ToDouble(this.txtcontrast.Text));
                    semiOrderSettings.DG_SemiOrder_Settings_ImageFrame = text4;
                    semiOrderSettings.DG_SemiOrder_Settings_IsImageFrame = this.chkBorder.IsChecked;
                    semiOrderSettings.DG_SemiOrder_ProductTypeId = selectedProducts;
                    semiOrderSettings.DG_SemiOrder_Settings_ImageFrame_Vertical = text5;
                    semiOrderSettings.DG_SemiOrder_Environment = this.chkEnableSOrder.IsChecked;
                    semiOrderSettings.DG_SemiOrder_BG = dG_SemiOrder_BG;
                    semiOrderSettings.DG_SemiOrder_Settings_IsImageBG = this.chkBG.IsChecked;
                    semiOrderSettings.DG_SemiOrder_Graphics_layer = stringBuilder.ToString();
                    semiOrderSettings.DG_SemiOrder_Image_ZoomInfo = dG_SemiOrder_Image_ZoomInfo;
                    semiOrderSettings.DG_SubStoreId = new int?(LoginUser.SubStoreId);
                    semiOrderSettings.DG_SemiOrder_IsPrintActive = this.chkPrintActive.IsChecked;
                    semiOrderSettings.DG_SemiOrder_IsCropActive = this.chkCrop.IsChecked;
                    semiOrderSettings.VerticalCropValues = Configuration.VerticalCropCoordinates;
                    semiOrderSettings.HorizontalCropValues = Configuration.HorizontalCropCoordinates;
                    semiOrderSettings.DG_LocationId = new int?(this.LocationId);
                    semiOrderSettings.ChromaColor = this.cmbChromaClr.SelectedValue.ToString();
                    semiOrderSettings.ColorCode = this.txtColorCode.Text;
                    do
                    {
                        semiOrderSettings.ClrTolerance = this.txtChromaTol.Text;
                        semiOrderSettings.TextLogos = allTextLogos;
                        bool flag2 = new ConfigBusiness().SetSemiorderConfigurationData(semiOrderSettings);
                        if (!flag2)
                        {
                            break;
                        }
                        DialogResult dialogResult = System.Windows.Forms.MessageBox.Show("Spec Printing settings has been saved successfully.\n\nYou need to restart the following services and application for this site.\nClick on Yes to re-start automatically.\n\n1) DigiWatchManualProcess service. \n\n2) DigiWatcher application. \n\n3) ImageProcessingEngine application.", "I-MIX", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            string text10 = "1) " + this.ServiceStart("DigiWatcher", true);
                            text10 = text10 + "\n\n2) " + this.ServiceStart("ImageProcessingEngine", true);
                            text10 = text10 + "\n\n3) " + this.ServiceStart("DigiWatchManualProcess", false);
                            System.Windows.Forms.MessageBox.Show("Spec settings are saved.\n\n" + text10, "I-MIX", MessageBoxButtons.OK);
                            AuditLog.AddUserLog(LoginUser.UserId, 56, "Add/Edit spec print data at:- ");
                            ServicePosInfoBusiness servicePosInfoBusiness = new ServicePosInfoBusiness();
                            string text11 = servicePosInfoBusiness.ServiceStart(true);
                        }
                        this.backAndClose();
                    }
                    while (8 == 0);
                    this.RemoveTextFields();
                    this.lstTextCollection.Clear();
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        public string ServiceStart(string serviceName, bool IsExe)
        {
            string result;
            try
            {
                bool flag = false;
                string systemName = this.getSystemName();
                bool status = true;
                string createdBy = "itadmin";
                bool flag2;
                while (true)
                {
                    List<GetServiceStatus> list = new List<GetServiceStatus>();
                    ServicePosInfoBusiness servicePosInfoBusiness = new ServicePosInfoBusiness();
                    ServiceController serviceController = new ServiceController(serviceName, systemName);
                    list = servicePosInfoBusiness.GetServiceStatusBusiness(systemName, serviceName);
                    int num = 0;
                    long num2 = 0L;
                    int level = 0;
                    while (true)
                    {
                        long imixPosDetailId = 0L;
                        flag2 = (list == null);
                        if (!flag2)
                        {
                            num = (from p in list
                                   select p.ServiceId).FirstOrDefault<int>();
                            num2 = (from p in list
                                    select p.SubStoreID).FirstOrDefault<long>();
                            level = (from p in list
                                     select p.Runlevel).FirstOrDefault<int>();
                            imixPosDetailId = (from p in list
                                               select p.iMixPosId).FirstOrDefault<long>();
                            if (false)
                            {
                                break;
                            }
                        }
                        string a = servicePosInfoBusiness.CheckRunnignServiceBusiness((long)num, num2, level, systemName);
                        if (8 == 0)
                        {
                            goto IL_278;
                        }
                        string text;
                        Process[] processes;
                        int num3;
                        ServiceController serviceController2;
                        if (IsExe)
                        {
                            if (a == "")
                            {
                                servicePosInfoBusiness.StartStopServiceByPosIdBusiness((long)num, num2, imixPosDetailId, false, "Webusers");
                                text = new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath;
                                text = Path.GetDirectoryName(text);
                                processes = Process.GetProcesses();
                                num3 = 0;
                                goto IL_1E2;
                            }
                            goto IL_242;
                        }
                        else
                        {
                            if (7 != 0)
                            {
                                serviceController2 = new ServiceController(serviceName, systemName);
                                flag2 = !(a == "");
                                goto IL_278;
                            }
                            goto IL_2CC;
                        }
                    IL_1F0:
                        Process process = Process.Start(text + "\\" + serviceName + ".exe");
                        flag2 = !flag;
                        if (8 == 0)
                        {
                            continue;
                        }
                        if (!flag2)
                        {
                            goto Block_12;
                        }
                        result = serviceName + " application has been started successfully.";
                        if (5 != 0)
                        {
                            goto Block_13;
                        }
                        goto IL_2AC;
                    IL_1D9:
                        goto IL_1F0;
                    IL_1B8:
                        Process process2;
                        if (process2.ProcessName.Contains(serviceName))
                        {
                            process2.Kill();
                            flag = true;
                            goto IL_1D9;
                        }
                        num3++;
                        goto IL_1E2;
                    IL_1EC:
                        if (!flag2)
                        {
                            goto IL_1F0;
                        }
                        process2 = processes[num3];
                        goto IL_1B8;
                    IL_2D5:
                        flag2 = !flag;
                        if (!false)
                        {
                            goto Block_17;
                        }
                        goto IL_1EC;
                    IL_2AC:
                        flag = true;
                        serviceController2.Stop();
                        serviceController.WaitForStatus(ServiceControllerStatus.Stopped);
                        serviceController2.Start();
                        goto IL_2D5;
                    IL_1E2:
                        flag2 = (num3 < processes.Length);
                        goto IL_1EC;
                    IL_278:
                        if (5 == 0)
                        {
                            goto IL_1B8;
                        }
                        if (!flag2)
                        {
                            int num4 = servicePosInfoBusiness.StartStopServiceByPosIdBusiness((long)num, num2, imixPosDetailId, status, createdBy);
                            if (serviceController2.Status == ServiceControllerStatus.Running)
                            {
                                goto IL_2AC;
                            }
                        }
                        else
                        {
                            if (8 != 0)
                            {
                                goto Block_19;
                            }
                            goto IL_1D9;
                        }
                    IL_2CC:
                        serviceController2.Start();
                        goto IL_2D5;
                    }
                }
            Block_12:
                result = serviceName + " application has been re-started successfully.";
            Block_13:
                return result;
            IL_242:
                result = "Please re-start " + serviceName + " application manually.";
                return result;
            Block_17:
                if (!flag2)
                {
                    result = serviceName + " service has been started.";
                    return result;
                }
                result = serviceName + " service has been re-started.";
                return result;
            Block_19:
                result = serviceName + " service.";
            }
            catch (Exception var_18_357)
            {
                result = "Please re-start " + serviceName + " manually.";
            }
            return result;
        }

        public string getSystemName()
        {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT Name FROM Win32_ComputerSystem");
            string result;
            do
            {
                using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
                {
                    do
                    {
                        bool arg_5E_0 = enumerator.MoveNext();
                        while (true)
                        {
                            bool flag = arg_5E_0;
                            while (true)
                            {
                                bool expr_60 = arg_5E_0 = flag;
                                if (false)
                                {
                                    break;
                                }
                                if (expr_60)
                                {
                                    goto IL_36;
                                }
                                if (!false)
                                {
                                    goto Block_7;
                                }
                            }
                        }
                    IL_36: ;
                    }
                    while (5 == 0);
                    ManagementObject managementObject = (ManagementObject)enumerator.Current;
                    result = managementObject["Name"].ToString();
                    goto IL_9D;
                Block_7: ;
                }
                result = "";
                if (!false && false)
                {
                    continue;
                }
            IL_9D: ;
            }
            while (false);
            return result;
        }

        private string GetAllTextLogos()
        {
            string text = string.Empty;
            int num = 0;
            try
            {
                IEnumerator enumerator = this.dragCanvas.Children.GetEnumerator();
                try
                {
                    while (enumerator.MoveNext())
                    {
                        object current = enumerator.Current;
                        string text2 = string.Empty;
                        string text3 = string.Empty;
                        string text4 = string.Empty;
                        string text5 = string.Empty;
                        string text6 = string.Empty;
                        string text7 = string.Empty;
                        string text8 = string.Empty;
                        string text9 = string.Empty;
                        string text10 = string.Empty;
                        if (current is System.Windows.Controls.TextBox)
                        {
                            num++;
                            System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)current;
                            text2 = Convert.ToString(textBox.Text);
                            text3 = Convert.ToString(textBox.FontFamily);
                            text4 = Convert.ToString(textBox.FontSize);
                            text5 = Convert.ToString(textBox.Foreground);
                            text6 = Convert.ToString(Canvas.GetTop(textBox));
                            text7 = Convert.ToString(Canvas.GetLeft(textBox));
                            text8 = Convert.ToString(num);
                            text10 = "25";
                            TransformGroup transformGroup = textBox.GetValue(UIElement.RenderTransformProperty) as TransformGroup;
                            RotateTransform rotateTransform = new RotateTransform();
                            ScaleTransform scaleTransform = new ScaleTransform();
                            if (transformGroup != null)
                            {
                                bool flag = transformGroup.Children.Count <= 0;
                                while (true)
                                {
                                    if (!flag)
                                    {
                                        if (transformGroup.Children[0] is ScaleTransform)
                                        {
                                            scaleTransform = (ScaleTransform)transformGroup.Children[0];
                                        }
                                        else if (transformGroup.Children[0] is RotateTransform)
                                        {
                                            rotateTransform = (RotateTransform)transformGroup.Children[0];
                                            text9 = rotateTransform.Angle.ToString();
                                        }
                                    }
                                    flag = (transformGroup.Children.Count <= 1);
                                    if (flag)
                                    {
                                        break;
                                    }
                                    if (3 != 0)
                                    {
                                        goto Block_9;
                                    }
                                }
                                goto IL_269;
                            Block_9:
                                if (transformGroup.Children[1] is ScaleTransform)
                                {
                                    scaleTransform = (ScaleTransform)transformGroup.Children[1];
                                }
                                else if (transformGroup.Children[1] is RotateTransform)
                                {
                                    rotateTransform = (RotateTransform)transformGroup.Children[1];
                                    text9 = rotateTransform.Angle.ToString();
                                }
                            }
                        IL_269:
                            text9 = ((!string.IsNullOrEmpty(text9)) ? text9 : "0");
                            string text11 = text;
                            text = string.Concat(new string[]
							{
								text11,
								"<TextLogo Name='",
								text8,
								"' FontFamily='",
								text3,
								"' FontColor='",
								text5,
								"' FontSize='",
								text4,
								"' Top='",
								text6,
								"' Left='",
								text7,
								"' Angle='",
								text9,
								"' ZIndex='",
								text10,
								"' Content='",
								text2,
								"' />"
							});
                        }
                    }
                }
                finally
                {
                    if (!false)
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                }
            }
            catch
            {
            }
            return text;
        }

        private string GetSelectedProducts()
        {
            string result;
            try
            {
                string text = string.Empty;
                while (true)
                {
                IL_0C:
                    int i = 0;
                    while (i < this.lstboxProductTypes.Items.Count)
                    {
                        if (4 == 0)
                        {
                            goto IL_6F;
                        }
                        this.lstboxProductTypes.ScrollIntoView(this.lstboxProductTypes.Items[i]);
                        DependencyObject dependencyObject = this.lstboxProductTypes.ItemContainerGenerator.ContainerFromIndex(i);
                        if (!true)
                        {
                            goto IL_8F;
                        }
                        if (dependencyObject != null)
                        {
                            goto IL_68;
                        }
                    IL_BB:
                        if (!false)
                        {
                            i++;
                            continue;
                        }
                        goto IL_0C;
                    IL_8F:
                        int arg_95_0;
                        if (3 != 0)
                        {
                            arg_95_0 = 0;
                            goto IL_93;
                        }
                        goto IL_BB;
                    IL_6F:
                        if (5 == 0)
                        {
                            goto IL_68;
                        }
                        System.Windows.Controls.CheckBox checkBox;
                        bool arg_9B_0;
                        if (checkBox != null)
                        {
                            bool? isChecked = checkBox.IsChecked;
                            if (isChecked.GetValueOrDefault())
                            {
                                arg_95_0 = (isChecked.HasValue ? 1 : 0);
                                goto IL_93;
                            }
                            goto IL_8F;
                        }
                        else
                        {
                            arg_9B_0 = true;
                        }
                    IL_9A:
                        if (!arg_9B_0)
                        {
                            text = text + "," + checkBox.Tag.ToString();
                        }
                        goto IL_BB;
                    IL_93:
                        arg_9B_0 = (arg_95_0 == 0);
                        goto IL_9A;
                    IL_68:
                        checkBox = AddEditSpecPrintProfile.FindVisualChild<System.Windows.Controls.CheckBox>(dependencyObject);
                        goto IL_6F;
                    }
                    break;
                }
                if (text.Length > 0)
                {
                    text = text.Remove(0, 1);
                }
                result = text;
            }
            catch (Exception serviceException)
            {
                if (!false)
                {
                }
                if (!false)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                    result = string.Empty;
                }
            }
            return result;
        }

        private void btnCropEdit_Click(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    this.mainImage.Source = null;
                    Uri uriSource;
                    do
                    {
                        System.Windows.Controls.Image expr_18 = this.mainImage_Size;
                        ImageSource expr_1D = null;
                        if (7 != 0)
                        {
                            expr_18.Source = expr_1D;
                        }
                        this.mainImagesize.Source = null;
                        uriSource = new Uri("/DigiPhoto;component/images/125412626.jpg", UriKind.RelativeOrAbsolute);
                        do
                        {
                            this.mainImage.Source = new BitmapImage(uriSource);
                        }
                        while (4 == 0);
                        this.mainImage_Size.Source = new BitmapImage(uriSource);
                    }
                    while (false || -1 == 0);
                    this.mainImagesize.Source = new BitmapImage(uriSource);
                    this.OpenAssociateWindow();
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
            while (4 == 0 || 4 == 0);
        }

        private void btnPreviewAutoCorrect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string selectedProducts = this.GetSelectedProducts();
                string[] array = selectedProducts.Split(new char[]
				{
					','
				});
                if (!(this.chkBorder.IsChecked == true) || this.cmbborder.SelectedIndex <= 0)
                {
                    goto IL_5B9;
                }
                for (int i = 0; i < this.frm.Children.Count; i++)
                {
                    this.frm.Children.RemoveAt(i);
                }
                BitmapImage source;
                if (this.mainImage.ActualWidth > this.mainImage.ActualHeight)
                {
                    source = new BitmapImage(new Uri(LoginUser.DigiFolderFramePath + "\\" + ((BorderInfo)this.cmbborder.SelectionBoxItem).DG_Border));
                }
                else
                {
                    source = new BitmapImage(new Uri(LoginUser.DigiFolderFramePath + "\\" + ((BorderInfo)this.cmbVerticalBorder.SelectionBoxItem).DG_Border));
                }
                OpaqueClickableImage opaqueClickableImage = new OpaqueClickableImage();
                opaqueClickableImage.Uid = "frame";
                opaqueClickableImage.Source = source;
                opaqueClickableImage.Stretch = Stretch.Fill;
                if (false)
                {
                    goto IL_293;
                }
                this.frm.Children.Add(opaqueClickableImage);
                DragCanvas.SetCanBeDragged(this.frm, false);
                if (this.mainImage.ActualWidth <= this.mainImage.ActualHeight)
                {
                    if (array[0] == "1")
                    {
                        this.frm.Height = this.mainImage.ActualHeight;
                        this.frm.Width = this.frm.Height * 0.75;
                    }
                    else if (array[0] == "2")
                    {
                        this.frm.Height = this.mainImage.ActualHeight;
                        this.frm.Width = this.frm.Height * 0.8;
                    }
                    else if (array[0] == "30" || array[0] == "104" || array[0] == "5" || array[0] == "102")
                    {
                        this.frm.Height = this.mainImage.ActualHeight;
                        this.frm.Width = this.frm.Height * 0.667;
                    }
                    else if (array[0] == "103")
                    {
                        this.frm.Height = this.mainImage.ActualHeight;
                        this.frm.Width = this.frm.Height * 0.714;
                    }
                    else if (array[0] == "3")
                    {
                        this.frm.Height = this.mainImage.ActualHeight;
                        this.frm.Width = this.frm.Height * 0.83;
                    }
                    else
                    {
                        this.frm.Height = this.mainImage.ActualHeight;
                        this.frm.Width = this.mainImage.ActualWidth;
                    }
                    goto IL_5B8;
                }
                if (array[0] == "1")
                {
                    this.frm.Width = this.mainImage.ActualWidth;
                    this.frm.Height = this.frm.Width * 0.75;
                    goto IL_3A9;
                }
                bool flag = !(array[0] == "2");
                bool arg_20B_0 = flag;
            IL_20B:
                if (!arg_20B_0)
                {
                    this.frm.Width = this.mainImage.ActualWidth;
                    this.frm.Height = this.frm.Width * 0.8;
                    goto IL_3A9;
                }
                if (array[0] == "30" || array[0] == "104")
                {
                    goto IL_28B;
                }
                bool arg_277_0 = array[0] == "5";
            IL_277:
                bool arg_28D_0;
                if (!arg_277_0)
                {
                    arg_28D_0 = !(array[0] == "102");
                    goto IL_28C;
                }
            IL_28B:
                arg_28D_0 = false;
            IL_28C:
                if (arg_28D_0)
                {
                    if (array[0] == "103")
                    {
                        this.frm.Width = this.mainImage.ActualWidth;
                        this.frm.Height = this.frm.Width * 0.714;
                        goto IL_3A9;
                    }
                    if (array[0] == "3")
                    {
                        this.frm.Width = this.mainImage.ActualWidth;
                        this.frm.Height = this.frm.Width * 0.83;
                        goto IL_3A9;
                    }
                    this.frm.Height = this.mainImage.ActualHeight;
                    this.frm.Width = this.mainImage.ActualWidth;
                    goto IL_3A9;
                }
            IL_293:
                this.frm.Width = this.mainImage.ActualWidth;
                this.frm.Height = this.frm.Width * 0.667;
            IL_3A9:
            IL_5B8:
            IL_5B9:
                if (this.chkbrightness.IsChecked == true)
                {
                    this._brighteff.Brightness = Convert.ToDouble(this.txtbrightness.Text);
                    this._brighteff.Contrast = 1.0;
                    this.GrdBrightness.Effect = this._brighteff;
                }
                if (this.chkcontrast.IsChecked == true)
                {
                    this._conteff.Contrast = Convert.ToDouble(this.txtcontrast.Text);
                    this.GrdContrast.Effect = this._conteff;
                }
                if (this.chklogo.IsChecked == true)
                {
                }
                if (this.chkBG.IsChecked == true && this.cmbBG.SelectedIndex > 0)
                {
                    string key = ((KeyValuePair<string, string>)this.cmbBG.SelectedItem).Key;
                    Uri uriSource = new Uri(LoginUser.DigiFolderBackGroundPath + "\\8x10\\" + key);
                    BitmapImage imageSource = new BitmapImage(uriSource);
                    this.canbackground.Background = new ImageBrush
                    {
                        ImageSource = imageSource
                    };
                    if (array[0] == "1")
                    {
                        this.canbackground.Height = this.canbackground.Width * 0.75;
                    }
                    else if (array[0] == "2")
                    {
                        this.canbackground.Height = this.canbackground.Width * 0.8;
                    }
                    else
                    {
                        bool arg_80E_0;
                        if (!(array[0] == "30") && !(array[0] == "104") && !(array[0] == "5"))
                        {
                            bool expr_7FC = arg_277_0 = (array[0] == "102");
                            if (8 == 0)
                            {
                                goto IL_277;
                            }
                            arg_80E_0 = !expr_7FC;
                        }
                        else
                        {
                            arg_80E_0 = false;
                        }
                        if (!arg_80E_0)
                        {
                            this.canbackground.Height = this.canbackground.Width * 0.667;
                        }
                        else
                        {
                            flag = !(array[0] == "103");
                            bool expr_84B = arg_20B_0 = flag;
                            if (!true)
                            {
                                goto IL_20B;
                            }
                            if (!expr_84B)
                            {
                                this.canbackground.Height = this.canbackground.Width * 0.714;
                            }
                            else if (array[0] == "3")
                            {
                                this.canbackground.Height = this.canbackground.Width * 0.83;
                            }
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void chkBorder_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = ((System.Windows.Controls.CheckBox)sender).Name;
                if (name == null)
                {
                    goto IL_148;
                }
                if (!(name == "chkBorder"))
                {
                    if (!(name == "chkbrightness"))
                    {
                        if (name == "chkcontrast")
                        {
                            this.txtcontrast.IsEnabled = true;
                            this.txtcontrast.Focus();
                            goto IL_148;
                        }
                    }
                    else
                    {
                        if (8 == 0)
                        {
                            goto IL_139;
                        }
                        this.txtbrightness.Text = "0";
                        if (!false)
                        {
                            this.txtbrightness.IsEnabled = true;
                            this.txtbrightness.Focus();
                            goto IL_148;
                        }
                        goto IL_EA;
                    }
                }
                else if (true)
                {
                    this.cmbborder.IsEnabled = true;
                    this.cmbborder.Focus();
                    this.cmbVerticalBorder.IsEnabled = true;
                    goto IL_148;
                }
                if (!(name == "chkBG"))
                {
                    goto IL_148;
                }
            IL_EA:
                this.cmbBG.IsEnabled = true;
                bool flag = string.IsNullOrWhiteSpace(this.SpecFileName);
            IL_103:
                if (!flag)
                {
                    this.btnChroma.IsEnabled = true;
                }
                this.btndelete.IsEnabled = false;
                this.btngraphics1.IsEnabled = false;
                this.btnHighPreview.IsEnabled = false;
            IL_139:
                this.cmbBG.Focus();
            IL_148:
                if (8 == 0)
                {
                    goto IL_103;
                }
            }
            catch (Exception serviceException)
            {
                do
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
                while (false);
            }
        }

        private void chkBorder_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = ((System.Windows.Controls.CheckBox)sender).Name;
                if (name != null)
                {
                    bool arg_2F_0 = name == "chkBorder";
                    while (!arg_2F_0)
                    {
                        if (!(name == "chkbrightness"))
                        {
                            if (!(name == "chkcontrast"))
                            {
                                if (name == "chkfilter")
                                {
                                    this.Grdcolorfilter.Effect = null;
                                    goto IL_36B;
                                }
                                if (false)
                                {
                                    goto IL_1F7;
                                }
                                bool expr_77 = arg_2F_0 = (name == "chkBG");
                                if (3 == 0)
                                {
                                    continue;
                                }
                                if (!expr_77)
                                {
                                    goto IL_36B;
                                }
                            IL_24B:
                                this.cmbBG.IsEnabled = false;
                                this.btnChroma.IsEnabled = false;
                                this.btndelete.IsEnabled = true;
                                this.btngraphics1.IsEnabled = true;
                                this.btnHighPreview.IsEnabled = true;
                                this.cmbBG.SelectedValue = "0";
                                this.canbackground.Background = null;
                                this.Grdcartoonize.Effect = null;
                                if (!string.IsNullOrWhiteSpace(this.SpecFileName))
                                {
                                    if (4 == 0)
                                    {
                                        goto IL_1E7;
                                    }
                                    this.mainImage.Source = null;
                                    this.mainImage_Size.Source = null;
                                    this.mainImagesize.Source = null;
                                    string uriString = this.SpecFileName.Replace("png", "jpg").Replace("PNG", "JPG");
                                    Uri uriSource = new Uri(uriString);
                                    this.mainImage.Source = new BitmapImage(uriSource);
                                    this.mainImage_Size.Source = new BitmapImage(uriSource);
                                    this.mainImagesize.Source = new BitmapImage(uriSource);
                                }
                                this.canbackground.UpdateLayout();
                                goto IL_36B;
                            }
                        IL_1E7:
                            this.txtcontrast.Text = "1";
                        IL_1F7:
                            this._conteff.Contrast = Convert.ToDouble(this.txtcontrast.Text);
                            this.GrdContrast.Effect = this._conteff;
                            this.txtcontrast.IsEnabled = false;
                            goto IL_36B;
                        }
                        this.txtbrightness.Text = "0";
                        this.txtbrightness.IsEnabled = false;
                        this._brighteff.Brightness = Convert.ToDouble(this.txtbrightness.Text);
                        this._brighteff.Contrast = 1.0;
                        this.GrdBrightness.Effect = this._brighteff;
                        goto IL_36B;
                    }
                    this.cmbborder.SelectedValue = "0";
                    this.cmbVerticalBorder.SelectedValue = "0";
                    List<UIElement> list = new List<UIElement>();
                    IEnumerator enumerator = this.frm.Children.GetEnumerator();
                    try
                    {
                        while (enumerator.MoveNext())
                        {
                            UIElement uIElement = (UIElement)enumerator.Current;
                            list.Add(uIElement);
                        }
                    }
                    finally
                    {
                        if (!false)
                        {
                            IDisposable disposable = enumerator as IDisposable;
                            if (disposable != null)
                            {
                                disposable.Dispose();
                            }
                        }
                    IL_10B:
                        if (5 == 0)
                        {
                            goto IL_10B;
                        }
                    }
                    //if (false)
                    //{
                    //    goto IL_24B;
                    //}
                    foreach (UIElement uIElement in list)
                    {
                       // UIElement uIElement;
                        this.frm.Children.Remove(uIElement);
                    }
                    this.cmbborder.IsEnabled = false;
                    this.cmbVerticalBorder.IsEnabled = false;
                    //if (4 == 0)
                    //{
                    //    goto IL_1E7;
                    //}
                }
            IL_36B: ;
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

        private void cmbBG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            while (true)
            {
                bool flag;
                if (2 != 0)
                {
                    int arg_CA_0;
                    if (this.cmbBG.SelectedItem != null)
                    {
                        if (false)
                        {
                            goto IL_62;
                        }
                        int expr_C0 = arg_CA_0 = this.cmbBG.SelectedIndex;
                        if (!false)
                        {
                            arg_CA_0 = ((expr_C0 <= 0) ? 1 : 0);
                        }
                    }
                    else
                    {
                        arg_CA_0 = 1;
                    }
                IL_34:
                    flag = (arg_CA_0 != 0);
                    goto IL_39;
                    goto IL_34;
                }
                goto IL_73;
            IL_A3:
                if (4 != 0)
                {
                    break;
                }
                continue;
            IL_73:
                string uriString;
                this.imgBackImage.Source = new BitmapImage(new Uri(uriString, UriKind.Absolute));
                if (!false)
                {
                    goto IL_A3;
                }
            IL_39:
                string key;
                if (!flag)
                {
                    key = ((KeyValuePair<string, string>)this.cmbBG.SelectedItem).Key;
                }
                else if (2 != 0)
                {
                    this.imgBackImage.Source = null;
                    goto IL_A3;
                }
            IL_62:
                uriString = Path.Combine(LoginUser.DigiFolderBackGroundPath, "Thumbnails", key);
                goto IL_73;
            }
        }

        private void btnChroma_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (false)
                {
                    goto IL_160;
                }
                bool arg_31_0 = this.chkBG.IsChecked == true;
            IL_30:
                if (!arg_31_0)
                {
                    goto IL_2B9;
                }
            IL_43:
                bool expr_53 = arg_31_0 = (this.cmbBG.SelectedIndex > 0);
                string text;
                ColorKeyAlphaEffect colorKeyAlphaEffect;
                ChromaKeyHSVEffect chromaKeyHSVEffect;
                if (7 != 0)
                {
                    bool flag = !expr_53;
                    bool arg_5F_0 = flag;
                    while (!arg_5F_0)
                    {
                        text = this.SpecFileName.Replace("jpg", "png").Replace("JPG", "PNG");
                        string text2 = this.cmbChromaClr.SelectedValue.ToString();
                        if (text2 != null)
                        {
                            if (!(text2 == "Green"))
                            {
                                if (!(text2 == "Blue"))
                                {
                                    bool expr_C6 = arg_5F_0 = (text2 == "Red");
                                    if (4 == 0)
                                    {
                                        continue;
                                    }
                                    if (!expr_C6 && !(text2 == "Gray"))
                                    {
                                        goto IL_186;
                                    }
                                }
                                colorKeyAlphaEffect = new ColorKeyAlphaEffect();
                                colorKeyAlphaEffect.ColorKey = (System.Windows.Media.Color)System.Windows.Media.ColorConverter.ConvertFromString(this.txtColorCode.Text);
                                goto IL_160;
                            }
                            chromaKeyHSVEffect = new ChromaKeyHSVEffect();
                            chromaKeyHSVEffect.HueMin = 0.2;
                            goto IL_F8;
                        }
                    IL_186:
                        goto IL_188;
                    }
                    System.Windows.MessageBox.Show("Please select Background");
                    goto IL_2B8;
                }
                goto IL_30;
            IL_F8:
                chromaKeyHSVEffect.HueMax = 0.5;
                chromaKeyHSVEffect.LightnessShift = this.lightness;
                if (6 == 0)
                {
                    goto IL_2B9;
                }
                chromaKeyHSVEffect.SaturationShift = this.saturation;
                this.Grdcartoonize.Effect = chromaKeyHSVEffect;
                if (7 != 0)
                {
                    goto IL_188;
                }
                goto IL_26E;
            IL_160:
                colorKeyAlphaEffect.Tolerance = Convert.ToDouble(this.txtChromaTol.Text);
                this.Grdcartoonize.Effect = colorKeyAlphaEffect;
            IL_188:
                this.Grdcartoonize.UpdateLayout();
                RenderTargetBitmap source = this.jCaptureScreen(this.Grdcartoonize);
                using (FileStream fileStream = new FileStream(text, FileMode.Create, FileAccess.ReadWrite))
                {
                    PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
                    do
                    {
                        pngBitmapEncoder.Interlace = PngInterlaceOption.On;
                    }
                    while (false);
                    pngBitmapEncoder.Frames.Add(BitmapFrame.Create(source));
                    pngBitmapEncoder.Save(fileStream);
                }
                this.mainImage.Source = null;
                this.mainImage_Size.Source = null;
                this.mainImagesize.Source = null;
                this.canbackground.UpdateLayout();
                Uri uriSource = new Uri(text);
                this.mainImage.Source = new BitmapImage(uriSource);
                if (5 == 0)
                {
                    goto IL_43;
                }
                this.mainImage_Size.Source = new BitmapImage(uriSource);
                this.mainImagesize.Source = new BitmapImage(uriSource);
            IL_26E:
                this.btnChroma.IsEnabled = false;
                this.btndelete.IsEnabled = true;
                this.btngraphics1.IsEnabled = true;
                if (false)
                {
                    goto IL_F8;
                }
                this.btnHighPreview.IsEnabled = true;
            IL_2B8:
            IL_2B9: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void cmbChromaClr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool arg_175_0 = !(this.cmbChromaClr.SelectedValue.ToString() == "Green");
            bool expr_C1;
            while (true)
            {
            IL_22:
                bool flag = arg_175_0;
                bool arg_2C_0 = flag;
                while (arg_2C_0)
                {
                    flag = !(this.cmbChromaClr.SelectedValue.ToString() == "Blue");
                    bool expr_7D = arg_175_0 = flag;
                    if (-1 == 0)
                    {
                        goto IL_22;
                    }
                    if (!expr_7D)
                    {
                        goto Block_3;
                    }
                    expr_C1 = (arg_2C_0 = (this.cmbChromaClr.SelectedValue.ToString() == "Red"));
                    if (!false)
                    {
                        goto Block_4;
                    }
                }
                break;
            }
            this.txtColorCode.Text = "#00FF00";
            this.txtChromaTol.Text = "1";
        IL_58:
            return;
        Block_3:
            this.txtColorCode.Text = "#0080FF";
            this.txtChromaTol.Text = "0.5";
            return;
        Block_4:
            if (!expr_C1)
            {
                if (false)
                {
                    goto IL_58;
                }
                if (!(this.cmbChromaClr.SelectedValue.ToString() == "Gray"))
                {
                    return;
                }
                if (3 == 0)
                {
                    return;
                }
                if (true)
                {
                    this.txtColorCode.Text = "#A9A9A9";
                    if (2 != 0)
                    {
                        this.txtChromaTol.Text = "0.15";
                        return;
                    }
                    goto IL_58;
                }
            }
            this.txtColorCode.Text = "#FF0000";
            this.txtChromaTol.Text = "0.4";
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                this.lstTextCollection.Clear();
                while (true)
                {
                    if (!false)
                    {
                        this.RemoveTextFields();
                        goto IL_12;
                    }
                IL_16:
                    if (!false)
                    {
                        this.backAndClose();
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

        private void backAndClose()
        {
            if (!false)
            {
                ((Configuration)this._parentConfig).loadSpecGrid(this.LocationId);
                base.Visibility = Visibility.Collapsed;
                do
                {
                    ((Configuration)this._parentConfig).btn.Opacity = 1.0;
                }
                while (false);
                ((Configuration)this._parentConfig).btn.IsEnabled = true;
            }
        }

        private void txtAngle_TextChanged(object sender, TextChangedEventArgs e)
        {
            int numValue = this._numValue;
            bool flag;
            do
            {
                if (3 != 0)
                {
                    flag = int.TryParse(this.txtAngle.Text, out this._numValue);
                    if (7 == 0)
                    {
                        goto IL_6B;
                    }
                    if (!flag)
                    {
                        this.txtAngle.Text = this._numValue.ToString();
                    }
                    int arg_72_0;
                    int expr_5C = arg_72_0 = this._numValue;
                    int arg_72_1;
                    int expr_66 = arg_72_1 = 360;
                    if (expr_66 == 0)
                    {
                        goto IL_72;
                    }
                    if (expr_5C <= expr_66)
                    {
                        goto IL_6B;
                    }
                    bool arg_7B_0 = false;
                IL_7A:
                    flag = arg_7B_0;
                    goto IL_7C;
                IL_72:
                    arg_7B_0 = (arg_72_0 >= arg_72_1);
                    goto IL_7A;
                IL_6B:
                    arg_72_0 = this._numValue;
                    arg_72_1 = 0;
                    goto IL_72;
                }
            IL_7C: ;
            }
            while (5 == 0);
            if (!flag)
            {
                this.txtAngle.Text = numValue.ToString();
                this._numValue = numValue;
            }
        IL_A0:
            flag = string.IsNullOrEmpty(this.txtAngle.Text);
            while (4 != 0)
            {
                if (!flag)
                {
                    this.jangleAltitudeSelector1_AngleChanged();
                }
                if (3 != 0)
                {
                    return;
                }
            }
            goto IL_A0;
        }

        private void btngrph_GotFocus(object sender, RoutedEventArgs e)
        {
            this.elementForContextMenu = (System.Windows.Controls.Button)sender;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.Button button = new System.Windows.Controls.Button();
            System.Windows.Controls.Button button2 = (System.Windows.Controls.Button)sender;
            button.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            button.VerticalAlignment = VerticalAlignment.Center;
            Style style = (Style)base.FindResource("ButtonStyleGraphic");
            button.Style = style;
            System.Windows.Controls.Image image = new System.Windows.Controls.Image();
            BitmapImage source = new BitmapImage(new Uri(button2.Tag.ToString()));
            image.Name = "A" + Guid.NewGuid().ToString().Split(new char[]
			{
				'-'
			})[0].ToString();
            button.Name = "btn" + Guid.NewGuid().ToString().Split(new char[]
			{
				'-'
			})[0].ToString();
            button.Uid = "uid" + Guid.NewGuid().ToString().Split(new char[]
			{
				'-'
			})[0].ToString();
            image.Source = source;
            button.Tag = "1";
            double num = 0.0;
            double num2 = 0.0;
            if (num != 0.0)
            {
                if (num < 1.0)
                {
                    button.Width = 90.0 / num;
                    button.Height = 90.0 / num2;
                }
                else
                {
                    button.Width = 90.0 * num;
                    button.Height = 90.0 * num2;
                }
            }
            else
            {
                button.Width = 90.0;
                button.Height = 90.0;
            }
            button.Content = image;
            this.dragCanvas.Children.Add(button);
            Canvas.SetLeft(button, this.GrdBrightness.ActualWidth / 2.0);
            Canvas.SetTop(button, this.GrdBrightness.ActualHeight / 2.0);
            image.MouseLeftButtonUp += new MouseButtonEventHandler(this.SelectObject);
            button.MouseLeftButtonUp += new MouseButtonEventHandler(this.SelectObject);
            button.KeyDown += new System.Windows.Input.KeyEventHandler(this.MyInkCanvas_KeyDown);
            button.GotFocus += new RoutedEventHandler(this.btngrph_GotFocus);
            button.Focus();
            System.Windows.Controls.Panel.SetZIndex(button, 4);
        }

        private void SelectObject(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (e.LeftButton == MouseButtonState.Released)
                {
                    if (sender is System.Windows.Controls.Button)
                    {
                        this.elementForContextMenu = (System.Windows.Controls.Button)sender;
                    }
                    else
                    {
                        bool arg_63_0 = sender is System.Windows.Controls.TextBox;
                        while (true)
                        {
                        IL_62:
                            bool flag = !arg_63_0;
                        IL_67:
                            while (flag)
                            {
                                int arg_12B_0 = (!(sender is System.Windows.Controls.Image)) ? 1 : 0;
                            IL_12B:
                                while (arg_12B_0 == 0)
                                {
                                    if (!true)
                                    {
                                        goto IL_6E;
                                    }
                                    object obj = (System.Windows.Controls.Image)sender;
                                    int num = 0;
                                    while (true)
                                    {
                                    IL_2FA:
                                        int arg_2FD_0 = num;
                                        int arg_2FD_1 = 3;
                                        while (arg_2FD_0 < arg_2FD_1)
                                        {
                                            obj = VisualTreeHelper.GetParent(obj as DependencyObject);
                                            int expr_15E = arg_12B_0 = (arg_2FD_0 = ((obj is System.Windows.Controls.Button) ? 1 : 0));
                                            if (false)
                                            {
                                                goto IL_12B;
                                            }
                                            int expr_164 = arg_2FD_1 = 0;
                                            if (expr_164 == 0)
                                            {
                                                if (expr_15E != expr_164)
                                                {
                                                    TransformGroup transformGroup = null;
                                                    if (this.elementForContextMenu != null)
                                                    {
                                                        transformGroup = (this.elementForContextMenu.GetValue(UIElement.RenderTransformProperty) as TransformGroup);
                                                    }
                                                    RotateTransform rotateTransform = new RotateTransform();
                                                    ScaleTransform scaleTransform = new ScaleTransform();
                                                    if (transformGroup != null)
                                                    {
                                                        flag = (transformGroup.Children == null || transformGroup.Children.Count <= 0);
                                                        bool expr_1DF = arg_63_0 = flag;
                                                        if (false)
                                                        {
                                                            goto IL_62;
                                                        }
                                                        if (!expr_1DF)
                                                        {
                                                            if (transformGroup.Children[0] is RotateTransform)
                                                            {
                                                                rotateTransform = (RotateTransform)transformGroup.Children[0];
                                                            }
                                                            else if (transformGroup.Children[0] is ScaleTransform)
                                                            {
                                                                scaleTransform = (ScaleTransform)transformGroup.Children[0];
                                                            }
                                                        }
                                                        bool arg_27B_0;
                                                        if (transformGroup.Children != null)
                                                        {
                                                            int arg_269_0 = transformGroup.Children.Count;
                                                            int arg_269_1 = 1;
                                                            int expr_269;
                                                            int expr_26C;
                                                            do
                                                            {
                                                                expr_269 = (arg_269_0 = ((arg_269_0 > arg_269_1) ? 1 : 0));
                                                                expr_26C = (arg_269_1 = 0);
                                                            }
                                                            while (expr_26C != 0);
                                                            arg_27B_0 = (expr_269 == expr_26C);
                                                        }
                                                        else
                                                        {
                                                            if (false)
                                                            {
                                                                break;
                                                            }
                                                            arg_27B_0 = true;
                                                        }
                                                        if (!arg_27B_0)
                                                        {
                                                            flag = !(transformGroup.Children[1] is RotateTransform);
                                                            if (!flag)
                                                            {
                                                                rotateTransform = (RotateTransform)transformGroup.Children[1];
                                                                if (false)
                                                                {
                                                                    goto IL_67;
                                                                }
                                                            }
                                                            else if (transformGroup.Children[0] is ScaleTransform)
                                                            {
                                                                scaleTransform = (ScaleTransform)transformGroup.Children[0];
                                                            }
                                                        }
                                                    }
                                                }
                                                num++;
                                                goto IL_2FA;
                                            }
                                        }
                                        goto IL_309;
                                    }
                                }
                                goto IL_309;
                            }
                            break;
                        }
                    IL_6E:
                        System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)sender;
                        double num2 = Convert.ToDouble(textBox.GetValue(Canvas.TopProperty));
                        double num3 = Convert.ToDouble(textBox.GetValue(Canvas.LeftProperty));
                        textBox.BorderBrush = System.Windows.Media.Brushes.OrangeRed;
                        this.elementForContextMenu = textBox;
                        this.txtContent.Text = textBox.Text;
                        this.txtContent.Focus();
                        textBox.Focus();
                        this.cmbFont.SelectedItem = textBox.FontFamily;
                        this.CmbFontSize.Text = textBox.FontSize.ToString();
                        this.CmbColor.Text = ((SolidColorBrush)textBox.Foreground).ToString();
                    }
                IL_309: ;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void MyInkCanvas_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            while (-1 != 0)
            {
                if (8 != 0)
                {
                    if (7 != 0)
                    {
                        bool flag = e.Key != Key.Delete;
                        if (false)
                        {
                            continue;
                        }
                        if (!flag)
                        {
                            goto IL_1F;
                        }
                    }
                    return;
                }
            IL_1F:
                this.DeleteGraphics();
                break;
            }
        }

        private void jangleAltitudeSelector1_AngleChanged()
        {
            System.Windows.Controls.Button button;
            TransformGroup transformGroup;
            TransformGroup transformGroup2;
            RotateTransform rotateTransform;
            if (-1 != 0)
            {
                if (this.elementForContextMenu != null)
                {
                    bool flag = !(this.elementForContextMenu is System.Windows.Controls.Button);
                    while (!flag)
                    {
                        button = (System.Windows.Controls.Button)this.elementForContextMenu;
                        transformGroup = new TransformGroup();
                        transformGroup2 = (this.elementForContextMenu.GetValue(UIElement.RenderTransformProperty) as TransformGroup);
                        if (transformGroup2 == null)
                        {
                            goto IL_13D;
                        }
                        if (transformGroup2.Children.Count <= 0)
                        {
                            goto IL_13C;
                        }
                        flag = !(transformGroup2.Children[0] is ScaleTransform);
                        if (!false)
                        {
                            if (!flag)
                            {
                                transformGroup.Children.Add(transformGroup2.Children[0]);
                                if (false)
                                {
                                IL_256:
                                    transformGroup.Children.Add(rotateTransform);
                                    System.Windows.Controls.TextBox textBox;
                                    textBox.RenderTransform = transformGroup;
                                    return;
                                }
                            }
                            bool arg_FD_0;
                            bool expr_F4 = arg_FD_0 = (transformGroup2.Children.Count <= 1);
                            if (!false)
                            {
                                flag = expr_F4;
                                arg_FD_0 = flag;
                            }
                            if (!arg_FD_0)
                            {
                                goto IL_100;
                            }
                            goto IL_13B;
                        }
                    }
                    if (this.elementForContextMenu is System.Windows.Controls.TextBox)
                    {
                        System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)this.elementForContextMenu;
                        transformGroup = new TransformGroup();
                        transformGroup2 = (this.elementForContextMenu.GetValue(UIElement.RenderTransformProperty) as TransformGroup);
                        rotateTransform = new RotateTransform();
                        textBox.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
                        rotateTransform.CenterX = 0.0;
                        rotateTransform.CenterY = 0.0;
                        rotateTransform.Angle = Convert.ToDouble(this.txtAngle.Text);
                        //goto IL_256;
                    }
                    return;
                }
                else
                {
                    RotateTransform rotateTransform2 = new RotateTransform();
                    rotateTransform2.CenterX = 0.0;
                    rotateTransform2.CenterY = 0.0;
                    if (4 != 0)
                    {
                        return;
                    }
                    goto IL_13D;
                }
            }
        IL_100:
            bool arg_115_0 = transformGroup2.Children[1] is ScaleTransform;
            bool expr_119;
            do
            {
                bool flag = !arg_115_0;
                expr_119 = (arg_115_0 = flag);
            }
            while (false);
            if (!expr_119)
            {
                transformGroup.Children.Add(transformGroup2.Children[1]);
            }
        IL_138:
        IL_13B:
        IL_13C:
        IL_13D:
            rotateTransform = new RotateTransform();
            button.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            rotateTransform.CenterX = 0.0;
            rotateTransform.CenterY = 0.0;
            rotateTransform.Angle = Convert.ToDouble(this.txtAngle.Text);
            transformGroup.Children.Add(rotateTransform);
            button.RenderTransform = transformGroup;
            if (7 == 0)
            {
                goto IL_138;
            }
        }

        private void cmdUp_Click(object sender, RoutedEventArgs e)
        {
            while (!false)
            {
                bool arg_16_0;
                bool expr_0D = arg_16_0 = (this.NumValue < 360);
                if (!false)
                {
                    bool flag = expr_0D;
                    arg_16_0 = flag;
                }
                if (!arg_16_0)
                {
                    break;
                }
                if (!false)
                {
                    this.NumValue++;
                    if (-1 != 0)
                    {
                        return;
                    }
                    break;
                }
            }
        }

        private void cmdDown_Click(object sender, RoutedEventArgs e)
        {
            while (!false)
            {
                bool arg_12_0;
                bool expr_09 = arg_12_0 = (this.NumValue > 0);
                if (!false)
                {
                    bool flag = expr_09;
                    arg_12_0 = flag;
                }
                if (!arg_12_0)
                {
                    break;
                }
                if (!false)
                {
                    this.NumValue--;
                    if (-1 != 0)
                    {
                        return;
                    }
                    break;
                }
            }
        }

        private void ZoomInButton_Click(object sender, RoutedEventArgs e)
        {
            RenderOptions.SetEdgeMode(this.mainImage, EdgeMode.Aliased);
            try
            {
                System.Windows.Controls.Button button;
                TransformGroup transformGroup;
                RotateTransform rotateTransform;
                ScaleTransform scaleTransform;
                if (this.elementForContextMenu is System.Windows.Controls.Button)
                {
                    button = (System.Windows.Controls.Button)this.elementForContextMenu;
                    if (button.Tag != null)
                    {
                        this._GraphicsZoomFactor = Convert.ToDouble(button.Tag);
                        this._GraphicsZoomFactor += 0.025;
                    }
                    else
                    {
                        this._GraphicsZoomFactor = 1.0;
                    }
                    transformGroup = new TransformGroup();
                    TransformGroup transformGroup2 = this.elementForContextMenu.GetValue(UIElement.RenderTransformProperty) as TransformGroup;
                    rotateTransform = new RotateTransform();
                    button.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
                    rotateTransform.CenterX = 0.0;
                    rotateTransform.CenterY = 0.0;
                    scaleTransform = new ScaleTransform();
                    if (transformGroup2 == null)
                    {
                        goto IL_222;
                    }
                    if (transformGroup2.Children.Count <= 0)
                    {
                        goto IL_194;
                    }
                    bool arg_13F_0 = !(transformGroup2.Children[0] is ScaleTransform);
                IL_13F:
                    bool flag;
                    bool arg_22A_0;
                    if (!arg_13F_0)
                    {
                        scaleTransform = (ScaleTransform)transformGroup2.Children[0];
                    }
                    else
                    {
                        flag = !(transformGroup2.Children[0] is RotateTransform);
                        bool expr_175 = arg_22A_0 = flag;
                        if (false)
                        {
                            goto IL_22A;
                        }
                        if (!expr_175)
                        {
                            rotateTransform = (RotateTransform)transformGroup2.Children[0];
                        }
                    }
                IL_194:
                    bool expr_1A3 = arg_13F_0 = (transformGroup2.Children.Count <= 1);
                    if (3 == 0)
                    {
                        goto IL_13F;
                    }
                    if (expr_1A3)
                    {
                        goto IL_221;
                    }
                    flag = !(transformGroup2.Children[1] is ScaleTransform);
                IL_1C8:
                    if (!flag)
                    {
                        scaleTransform = (ScaleTransform)transformGroup2.Children[1];
                        if (3 == 0)
                        {
                            goto IL_2D0;
                        }
                    }
                    else
                    {
                        if (2 == 0)
                        {
                            goto IL_34D;
                        }
                        if (transformGroup2.Children[1] is RotateTransform)
                        {
                            rotateTransform = (RotateTransform)transformGroup2.Children[1];
                        }
                    }
                IL_221:
                IL_222:
                    arg_22A_0 = (scaleTransform != null);
                IL_22A:
                    flag = arg_22A_0;
                    if (!flag)
                    {
                        scaleTransform = new ScaleTransform();
                        scaleTransform.ScaleX = this._GraphicsZoomFactor;
                        scaleTransform.ScaleY = this._GraphicsZoomFactor;
                        scaleTransform.CenterX = 0.0;
                        if (false)
                        {
                            goto IL_1C8;
                        }
                        scaleTransform.CenterY = 0.0;
                    }
                    else
                    {
                        scaleTransform.ScaleX = this._GraphicsZoomFactor;
                        if (false)
                        {
                            goto IL_30A;
                        }
                        scaleTransform.ScaleY = this._GraphicsZoomFactor;
                        scaleTransform.CenterX = 0.0;
                        scaleTransform.CenterY = 0.0;
                    }
                }
                else if (!false)
                {
                    if (this.elementForContextMenu == null)
                    {
                        goto IL_34D;
                    }
                    goto IL_43E;
                }
                transformGroup.Children.Add(scaleTransform);
            IL_2D0:
                if (false)
                {
                    goto IL_324;
                }
                if (rotateTransform != null)
                {
                    transformGroup.Children.Add(rotateTransform);
                }
                button.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            IL_30A:
                button.Tag = this._GraphicsZoomFactor.ToString();
                button.RenderTransform = transformGroup;
            IL_324:
                this.elementForContextMenu = button;
                goto IL_43E;
            IL_34D:
                if (this._ZoomFactor >= 4.0)
                {
                    this._ZoomFactor = 4.0;
                }
                else
                {
                    this._ZoomFactor += 0.025;
                    if (this.zoomTransform != null)
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
            IL_43E: ;
            }
            catch (Exception ex)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(ex);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                System.Windows.MessageBox.Show(ex.Message);
            }
            finally
            {
                MemoryManagement.FlushMemory();
            }
        }

        private void ZoomOutButton_Click(object sender, RoutedEventArgs e)
        {
            RenderOptions.SetEdgeMode(this.mainImage, EdgeMode.Aliased);
            try
            {
                System.Windows.Controls.Button button;
                double arg_2F7_0;
                double arg_2F7_1;
                TransformGroup transformGroup;
                TransformGroup transformGroup2;
                RotateTransform rotateTransform;
                if (this.elementForContextMenu is System.Windows.Controls.Button)
                {
                    button = (System.Windows.Controls.Button)this.elementForContextMenu;
                    bool flag = button.Tag == null;
                    if (false)
                    {
                        goto IL_2A4;
                    }
                    if (!flag)
                    {
                        this._GraphicsZoomFactor = Convert.ToDouble(button.Tag);
                    }
                    double expr_79 = arg_2F7_0 = this._GraphicsZoomFactor;
                    double expr_7E = arg_2F7_1 = 0.625;
                    if (2 == 0)
                    {
                        goto IL_2F7;
                    }
                    if (expr_79 < expr_7E)
                    {
                        return;
                    }
                    this._GraphicsZoomFactor -= 0.025;
                    transformGroup = new TransformGroup();
                    transformGroup2 = (this.elementForContextMenu.GetValue(UIElement.RenderTransformProperty) as TransformGroup);
                    rotateTransform = new RotateTransform();
                }
                else
                {
                    if (this.elementForContextMenu == null)
                    {
                        arg_2F7_0 = this._ZoomFactor;
                        arg_2F7_1 = 0.525;
                        goto IL_2F7;
                    }
                    goto IL_3E1;
                }
            IL_D5:
                ScaleTransform scaleTransform = new ScaleTransform();
            IL_DC:
                if (transformGroup2 == null)
                {
                    goto IL_1ED;
                }
                if (transformGroup2.Children.Count <= 0)
                {
                    goto IL_168;
                }
                if (transformGroup2.Children[0] is ScaleTransform)
                {
                    scaleTransform = (ScaleTransform)transformGroup2.Children[0];
                    goto IL_167;
                }
                if (!(transformGroup2.Children[0] is RotateTransform))
                {
                    goto IL_167;
                }
            IL_154:
                rotateTransform = (RotateTransform)transformGroup2.Children[0];
            IL_167:
            IL_168:
                if (transformGroup2.Children.Count <= 1)
                {
                    goto IL_1EC;
                }
                if (transformGroup2.Children[1] is ScaleTransform)
                {
                    scaleTransform = (ScaleTransform)transformGroup2.Children[1];
                }
                else
                {
                    if (transformGroup2.Children[1] is RotateTransform)
                    {
                        rotateTransform = (RotateTransform)transformGroup2.Children[1];
                        goto IL_1EB;
                    }
                    goto IL_1EB;
                }
            IL_1B1:
                if (false)
                {
                    goto IL_2FF;
                }
            IL_1EB:
            IL_1EC:
            IL_1ED:
                if (scaleTransform == null)
                {
                    if (7 != 0)
                    {
                        return;
                    }
                    goto IL_1B1;
                }
                else
                {
                    scaleTransform.ScaleX -= 0.025;
                    scaleTransform.ScaleY -= 0.025;
                    scaleTransform.CenterX = 0.0;
                    scaleTransform.CenterY = 0.0;
                }
            IL_258:
                transformGroup.Children.Add(scaleTransform);
                if (false)
                {
                    goto IL_DC;
                }
                if (rotateTransform != null)
                {
                    transformGroup.Children.Add(rotateTransform);
                }
                button.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
            IL_2A4:
                button.Tag = this._GraphicsZoomFactor;
                button.RenderTransform = transformGroup;
                this.elementForContextMenu = button;
                if (!false)
                {
                    goto IL_3E1;
                }
                goto IL_D5;
            IL_2F7:
                if (arg_2F7_0 < arg_2F7_1)
                {
                    this._ZoomFactor = 0.5;
                    return;
                }
            IL_2FF:
                this._ZoomFactor -= 0.025;
                if (false)
                {
                    goto IL_258;
                }
                if (this.zoomTransform != null)
                {
                    this.zoomTransform.CenterX = this.mainImage.ActualWidth / 2.0;
                    this.zoomTransform.CenterY = this.mainImage.ActualHeight / 2.0;
                    this.zoomTransform.ScaleX = this._ZoomFactor;
                    this.zoomTransform.ScaleY = this._ZoomFactor;
                    this.transformGroup = new TransformGroup();
                    this.transformGroup.Children.Add(this.zoomTransform);
                    this.GrdBrightness.RenderTransform = this.transformGroup;
                }
            IL_3E1:
                if (-1 == 0)
                {
                    goto IL_154;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void objCurrent_Loaded(object sender, RoutedEventArgs e)
        {
            if (7 != 0)
            {
                if (!false)
                {
                    UIElement expr_09 = this.frm;
                    double expr_2A = (this.dragCanvas.ActualWidth - this.frm.ActualWidth) / 2.0;
                    if (!false)
                    {
                        Canvas.SetLeft(expr_09, expr_2A);
                    }
                }
            }
            Canvas.SetTop(this.frm, (this.dragCanvas.ActualHeight - this.frm.ActualHeight) / 2.0);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                while (true)
                {
                    this.GrdPrint.Visibility = Visibility.Collapsed;
                    if (!false)
                    {
                        bool arg_1E_0 = this.dragCanvas.Children.Count > 2;
                        bool expr_5E;
                        do
                        {
                            bool flag = !arg_1E_0;
                            expr_5E = (arg_1E_0 = flag);
                        }
                        while (false);
                        if (!expr_5E)
                        {
                            this.spZoompanel.Visibility = Visibility.Visible;
                        }
                    }
                IL_36:
                    if (false)
                    {
                        break;
                    }
                    if (!false)
                    {
                        if (true)
                        {
                            return;
                        }
                        break;
                    }
                    goto IL_36;
                }
            }
        }

        private void btnGraphics_Click(object sender, RoutedEventArgs e)
        {
            this.GrdPrint.Visibility = Visibility.Visible;
        }

        private void btnFileOpen_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Multiselect = false;
                openFileDialog.Filter = "All Image Files | *.*";
                if (openFileDialog.ShowDialog().Value)
                {
                    this.ResetSpecPrintEffects();
                    string safeFileName = openFileDialog.SafeFileName;
                    this.SpecFileName = openFileDialog.FileName;
                    while (true)
                    {
                        bool arg_AF_0;
                        if (this.chkBG.IsChecked == true)
                        {
                            arg_AF_0 = !File.Exists(openFileDialog.FileName.Replace("jpg", "png"));
                        }
                        else
                        {
                            if (7 == 0)
                            {
                                goto IL_363;
                            }
                            arg_AF_0 = true;
                        }
                        if (!arg_AF_0)
                        {
                            this.SpecFileName = this.SpecFileName.Replace("jpg", "png");
                        }
                        Uri uriSource = new Uri(this.SpecFileName);
                        this.mainImage.Source = new BitmapImage(uriSource);
                        if (-1 != 0)
                        {
                            this.mainImage_Size.Source = new BitmapImage(uriSource);
                            this.mainImagesize.Source = new BitmapImage(uriSource);
                            if (this.mainImage.Source.Height <= this.mainImage.Source.Width)
                            {
                                goto IL_316;
                            }
                        }
                        string selectedProducts = this.GetSelectedProducts();
                        string[] array = selectedProducts.Split(new char[]
						{
							','
						});
                        if (array[0] == "1")
                        {
                            break;
                        }
                        if (array[0] == "2")
                        {
                            goto Block_9;
                        }
                        bool flag = !(array[0] == "30");
                        if (false)
                        {
                            goto IL_28B;
                        }
                        if (!flag)
                        {
                            goto Block_13;
                        }
                        this.canbackground.Height = 535.0;
                        if (false)
                        {
                            goto IL_1FC;
                        }
                        this.canbackground.Width = 356.84;
                        this.canbackground.InvalidateArrange();
                        this.canbackground.InvalidateMeasure();
                        if (false)
                        {
                            goto IL_38A;
                        }
                        if (6 != 0)
                        {
                            goto Block_16;
                        }
                    }
                    this.canbackground.Height = 535.0;
                    this.canbackground.Width = 401.25;
                    this.canbackground.InvalidateArrange();
                    this.canbackground.InvalidateMeasure();
                    this.canbackground.UpdateLayout();
                    goto IL_315;
                Block_9:
                    this.canbackground.Height = 535.0;
                IL_1FC:
                    this.canbackground.Width = 428.0;
                    this.canbackground.InvalidateArrange();
                    if (false)
                    {
                        goto IL_353;
                    }
                    this.canbackground.InvalidateMeasure();
                    this.canbackground.UpdateLayout();
                    if (-1 != 0)
                    {
                        goto IL_315;
                    }
                    goto IL_397;
                Block_13:
                    this.canbackground.Height = 535.0;
                    this.canbackground.Width = 356.84;
                IL_28B:
                    this.canbackground.InvalidateArrange();
                    this.canbackground.InvalidateMeasure();
                    this.canbackground.UpdateLayout();
                    goto IL_315;
                Block_16:
                    this.canbackground.UpdateLayout();
                IL_315:
                IL_316:
                    if (!(this.chkBG.IsChecked == true) || this.SpecFileName.Contains(".png"))
                    {
                        goto IL_363;
                    }
                IL_353:
                    this.btnChroma.IsEnabled = true;
                    goto IL_398;
                IL_363:
                    this.btnChroma.IsEnabled = false;
                    this.btndelete.IsEnabled = true;
                    this.btngraphics1.IsEnabled = true;
                IL_38A:
                    this.btnHighPreview.IsEnabled = true;
                IL_397:
                IL_398: ;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btndelete_Click_1(object sender, RoutedEventArgs e)
        {
            this.DeleteGraphics();
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
            bool arg_0B_0 = this.Grdcartoonize.IsMouseOver;
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

        private void txtChromaTol_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            int arg_191_0=0;
            if (!char.IsLetter((char)KeyInterop.VirtualKeyFromKey(e.Key)))
            {
                arg_191_0 = (ushort)KeyInterop.VirtualKeyFromKey(e.Key);
                goto IL_29;
            }
            goto IL_5D;
            int arg_5F_0;
            string text;
            while (true)
            {
            IL_5E:
                if (arg_5F_0 == 0)
                {
                    e.Handled = true;
                }
                if (false)
                {
                    break;
                }
                text = this.txtChromaTol.Text;
                while (true)
                {
                    bool expr_8F = (arg_5F_0 = ((this.txtChromaTol.Text != "") ? 1 : 0)) != 0;
                    if (-1 == 0)
                    {
                        break;
                    }
                    if (!expr_8F)
                    {
                        return;
                    }
                    bool flag = text[0] != '.';
                    if (3 != 0)
                    {
                        if (flag)
                        {
                            goto IL_D3;
                        }
                        if (true)
                        {
                            text = "0.";
                            this.txtChromaTol.Text = "0.";
                            goto IL_D1;
                        }
                    IL_10E:
                        if (!false)
                        {
                            goto Block_13;
                        }
                        continue;
                    IL_D3:
                        if (!(decimal.Parse(text) < 0m))
                        {
                            goto IL_10E;
                        }
                        System.Windows.MessageBox.Show("This Value should be a decimal number between 0 and 2");
                        this.txtChromaTol.Text = "";
                        if (!false)
                        {
                            goto Block_12;
                        }
                    IL_D1:
                        goto IL_D3;
                    }
                    goto IL_133;
                }
            }
        Block_12:
            return;
        Block_13:
            bool expr_120 = (arg_191_0 = ((decimal.Parse(text) > 2m) ? 1 : 0)) != 0;
            if (4 == 0)
            {
                goto IL_29;
            }
            if (!expr_120)
            {
                return;
            }
        IL_133:
            System.Windows.MessageBox.Show("This Value should be a decimal number between 0 and 2");
            this.txtChromaTol.Text = "";
            return;
        IL_29:
            if (!char.IsSymbol((char)arg_191_0) && !char.IsWhiteSpace((char)KeyInterop.VirtualKeyFromKey(e.Key)))
            {
                arg_5F_0 = ((!char.IsPunctuation((char)KeyInterop.VirtualKeyFromKey(e.Key))) ? 1 : 0);
                //goto IL_5E;
            }
        IL_5D:
            arg_5F_0 = 0;
            //goto IL_5E;
        }

        public void GetSemiOrderSettings()
        {
            Func<BorderInfo, bool> expr_00 = null;
            if (5 != 0)
            {
                Func<BorderInfo, bool> predicate = expr_00;
            }
            Func<BorderInfo, bool> expr_14 = null;
            if (!false)
            {
                Func<BorderInfo, bool> predicate2 = expr_14;
            }
            bool? flag;
            bool arg_528_0;
            bool arg_29D_0;
            if (this.semiOrderSettings != null)
            {
                this.txtbrightness.Text = Convert.ToString(this.semiOrderSettings.DG_SemiOrder_Settings_AutoBright_Value);
                this.chkBorder.IsChecked = ((!this.semiOrderSettings.DG_SemiOrder_Settings_IsImageFrame.HasValue) ? new bool?(false) : this.semiOrderSettings.DG_SemiOrder_Settings_IsImageFrame);
                this.chkbrightness.IsChecked = ((!this.semiOrderSettings.DG_SemiOrder_Settings_AutoBright.HasValue) ? new bool?(false) : this.semiOrderSettings.DG_SemiOrder_Settings_AutoBright);
                this.chkcontrast.IsChecked = ((!this.semiOrderSettings.DG_SemiOrder_Settings_AutoContrast.HasValue) ? new bool?(false) : this.semiOrderSettings.DG_SemiOrder_Settings_AutoContrast);
                this.pkey = this.semiOrderSettings.DG_SemiOrder_Settings_Pkey;
                this.BindProfileProductAssociation(this.pkey, this.semiOrderSettings.ProductName);
                this.chkPrintActive.IsChecked = ((!this.semiOrderSettings.DG_SemiOrder_IsPrintActive.HasValue) ? new bool?(true) : this.semiOrderSettings.DG_SemiOrder_IsPrintActive);
                ToggleButton arg_192_0 = this.chkCrop;
                flag = this.semiOrderSettings.DG_SemiOrder_IsCropActive;
                arg_192_0.IsChecked = ((!flag.HasValue) ? new bool?(false) : this.semiOrderSettings.DG_SemiOrder_IsCropActive);
                Configuration.HorizontalCropCoordinates = this.semiOrderSettings.HorizontalCropValues;
                Configuration.VerticalCropCoordinates = this.semiOrderSettings.VerticalCropValues;
                this.cmbChromaClr.SelectedValue = this.semiOrderSettings.ChromaColor.ToString();
                this.txtColorCode.Text = this.semiOrderSettings.ColorCode;
                this.txtChromaTol.Text = this.semiOrderSettings.ClrTolerance;
                IEnumerable<BorderInfo> arg_21B_0 = this.lstBorderList;
                Func<BorderInfo, bool> predicate = (BorderInfo t) => t.DG_Border == this.semiOrderSettings.DG_SemiOrder_Settings_ImageFrame;
                BorderInfo borderInfo = arg_21B_0.Where(predicate).FirstOrDefault<BorderInfo>();
                bool expr_228 = arg_528_0 = (borderInfo == null);
                if (!true)
                {
                    goto IL_527;
                }
                if (!expr_228)
                {
                    this.cmbborder.SelectedValue = (from t in this.lstBorderList
                                                    where t.DG_Border == this.semiOrderSettings.DG_SemiOrder_Settings_ImageFrame
                                                    select t).FirstOrDefault<BorderInfo>().DG_Borders_pkey;
                }
                BorderInfo borderInfo2 = (from t in this.lstBorderList
                                          where t.DG_Border == this.semiOrderSettings.DG_SemiOrder_Settings_ImageFrame_Vertical
                                          select t).FirstOrDefault<BorderInfo>();
                arg_29D_0 = (borderInfo2 == null);
            }
            else
            {
                this.pkey = 0;
                this.chkEnableSOrder.IsChecked = new bool?(false);
                if (4 != 0)
                {
                    this.chkBorder.IsChecked = new bool?(false);
                    this.chkBG.IsChecked = new bool?(false);
                    this.chkbrightness.IsChecked = new bool?(false);
                    this.chkcontrast.IsChecked = new bool?(false);
                    this.cmbborder.SelectedValue = "0";
                    this.cmbVerticalBorder.SelectedValue = "0";
                    goto IL_5E6;
                }
                goto IL_4A2;
            }
        IL_29D:
            if (!arg_29D_0)
            {
                Selector arg_2D9_0 = this.cmbVerticalBorder;
                IEnumerable<BorderInfo> arg_2C5_0 = this.lstBorderList;
                Func<BorderInfo, bool> predicate2 = (BorderInfo t) => t.DG_Border == this.semiOrderSettings.DG_SemiOrder_Settings_ImageFrame_Vertical;
                arg_2D9_0.SelectedValue = arg_2C5_0.Where(predicate2).FirstOrDefault<BorderInfo>().DG_Borders_pkey;
            }
        IL_2DF:
            this.chkBG.IsChecked = ((!this.semiOrderSettings.DG_SemiOrder_Settings_IsImageBG.HasValue) ? new bool?(false) : this.semiOrderSettings.DG_SemiOrder_Settings_IsImageBG);
            this.cmbBG.SelectedValue = (from t in this.lstBGList
                                        where t.Key == this.semiOrderSettings.DG_SemiOrder_BG
                                        select t).FirstOrDefault<KeyValuePair<string, string>>().Value;
            bool flag2 = this.cmbBG.SelectedValue != null;
            bool arg_365_0 = flag2;
            string a;
            bool expr_440;
            do
            {
                if (!arg_365_0)
                {
                    this.cmbBG.SelectedIndex = 0;
                }
                this.chkEnableSOrder.IsChecked = ((!this.semiOrderSettings.DG_SemiOrder_Environment.HasValue) ? new bool?(false) : this.semiOrderSettings.DG_SemiOrder_Environment);
                this.DisplayTextFields();
                bool expr_3C0 = arg_29D_0 = (this.cmbborder.SelectedValue != null);
                if (7 == 0)
                {
                    goto IL_29D;
                }
                if (!expr_3C0)
                {
                    this.cmbborder.SelectedIndex = 0;
                }
                if (this.cmbVerticalBorder.SelectedValue == null)
                {
                    if (8 == 0)
                    {
                        goto IL_5E6;
                    }
                    this.cmbVerticalBorder.SelectedIndex = 0;
                }
                a = string.Empty;
                if (this.semiOrderSettings.DG_SemiOrder_ProductTypeId.Contains(','))
                {
                    a = "1";
                }
                else
                {
                    a = this.semiOrderSettings.DG_SemiOrder_ProductTypeId;
                }
                expr_440 = (arg_365_0 = (a == "1"));
            }
            while (5 == 0);
            if (expr_440)
            {
                this.canbackground.Height = 401.25;
                this.canbackground.Width = 535.0;
                this.canbackground.InvalidateArrange();
                this.canbackground.InvalidateMeasure();
                this.canbackground.UpdateLayout();
            }
            else if (a == "2")
            {
                this.canbackground.Height = 428.0;
                this.canbackground.Width = 535.0;
                this.canbackground.InvalidateArrange();
                this.canbackground.InvalidateMeasure();
                this.canbackground.UpdateLayout();
            }
        IL_4A2:
            flag = this.chkBorder.IsChecked;
        IL_517:
            int arg_52F_0;
            if (!flag.GetValueOrDefault())
            {
                arg_52F_0 = 1;
                goto IL_52D;
            }
            arg_528_0 = flag.HasValue;
        IL_527:
            arg_52F_0 = ((!arg_528_0) ? 1 : 0);
        IL_52D:
            if (arg_52F_0 != 0)
            {
                this.cmbborder.IsEnabled = false;
                this.cmbVerticalBorder.IsEnabled = false;
            }
            if (5 != 0)
            {
                goto IL_61F;
            }
            goto IL_517;
        IL_5E6:
            this.chkEnableSOrder.IsChecked = new bool?(false);
            this.chkCrop.IsChecked = new bool?(false);
            Configuration.HorizontalCropCoordinates = string.Empty;
            Configuration.VerticalCropCoordinates = string.Empty;
        IL_61F:
            if (!false)
            {
                return;
            }
            goto IL_2DF;
        }

        private void DisplayTextFields()
        {
            this.txtContent.Text = "Enter Text...";
            this.cmbFont.SelectedIndex = 0;
            this.CmbColor.SelectedIndex = 0;
            this.CmbFontSize.SelectedIndex = 6;
            string text = this.semiOrderSettings.TextLogos;
            text = "<XmlRoot>" + text + "</XmlRoot>";
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(text);
            XmlNodeList elementsByTagName = xmlDocument.GetElementsByTagName("TextLogo");
            XmlReader xmlReader = XmlReader.Create(new StringReader(xmlDocument.InnerXml.ToString()));
            this.lstTextContent.Clear();
            while (true)
            {
                bool flag = xmlReader.Read();
                bool arg_B8_0;
                bool expr_549 = arg_B8_0 = flag;
                if (8 != 0)
                {
                    if (!expr_549)
                    {
                        break;
                    }
                    arg_B8_0 = (xmlReader.NodeType != XmlNodeType.Element);
                }
                if (!arg_B8_0)
                {
                    goto IL_C2;
                }
            IL_4F6:
                bool arg_516_0;
                if (this.lstTextContent != null)
                {
                    arg_516_0 = (this.lstTextContent.Count != 0);
                }
                else
                {
                    if (8 == 0)
                    {
                        continue;
                    }
                    arg_516_0 = false;
                }
                flag = arg_516_0;
                if (!false)
                {
                    if (!flag)
                    {
                        this.grdTextField.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        this.grdTextField.Visibility = Visibility.Visible;
                    }
                    continue;
                }
                goto IL_489;
            IL_4CA:
                if (6 == 0)
                {
                    goto IL_C2;
                }
                if (!false)
                {
                    this.grdTextField.ItemsSource = null;
                    this.grdTextField.ItemsSource = this.lstTextContent;
                    goto IL_4F6;
                }
                goto IL_2BE;
            IL_4B4:
                System.Windows.Controls.TextBox textBox;
                textBox.MouseLeftButtonUp += new MouseButtonEventHandler(this.SelectObject);
                goto IL_4CA;
            IL_489:
                System.Windows.Controls.Panel.SetZIndex(textBox, Convert.ToInt32(xmlReader.GetAttribute("ZIndex").ToString()));
                goto IL_4B4;
            IL_304:
                bool arg_2B5_0;
                bool expr_31F = arg_2B5_0 = !(xmlReader.GetAttribute("FontSize").ToString() != string.Empty);
                if (-1 == 0)
                {
                    goto IL_2B4;
                }
                if (!expr_31F)
                {
                    textBox.FontSize = Convert.ToDouble(xmlReader.GetAttribute("FontSize").ToString());
                }
                else
                {
                    textBox.FontSize = 36.0;
                }
                bool arg_463_0;
                int expr_373 = (arg_463_0 = (xmlReader.GetAttribute("Content").ToString() != string.Empty)) ? 1 : 0;
                int arg_463_1;
                int expr_379 = arg_463_1 = 0;
                if (expr_379 == 0)
                {
                    if (expr_373 != expr_379)
                    {
                        textBox.Text = xmlReader.GetAttribute("Content").ToString();
                    }
                    textBox.Uid = "txtLogoBlock";
                    if (xmlReader.GetAttribute("Name").ToString() != string.Empty)
                    {
                        textBox.Name = "txt" + xmlReader.GetAttribute("Name").ToString();
                    }
                    if (!true)
                    {
                        goto IL_299;
                    }
                    this.dragCanvas.Children.Add(textBox);
                    Canvas.SetLeft(textBox, Convert.ToDouble(xmlReader.GetAttribute("Left").ToString()));
                    Canvas.SetTop(textBox, Convert.ToDouble(xmlReader.GetAttribute("Top").ToString()));
                    arg_463_0 = (xmlReader.GetAttribute("ZIndex").ToString() != string.Empty);
                    arg_463_1 = 0;
                }
                if ((arg_463_0 ? 1 : 0) != arg_463_1)
                {
                    System.Windows.Controls.Panel.SetZIndex(textBox, Convert.ToInt32(xmlReader.GetAttribute("ZIndex").ToString()));
                    goto IL_489;
                }
                System.Windows.Controls.Panel.SetZIndex(textBox, 4);
                goto IL_4B4;
            IL_2BE:
                BrushConverter brushConverter = new BrushConverter();
                System.Windows.Media.Brush foreground = (System.Windows.Media.Brush)brushConverter.ConvertFromString(xmlReader.GetAttribute("FontColor").ToString());
                textBox.Foreground = foreground;
                goto IL_304;
            IL_2B4:
                if (arg_2B5_0)
                {
                    goto IL_2BE;
                }
                textBox.Foreground = new SolidColorBrush(Colors.DarkRed);
                goto IL_304;
            IL_299:
                arg_2B5_0 = (xmlReader.GetAttribute("FontColor").ToString() != string.Empty);
                goto IL_2B4;
            IL_C2:
                string text2 = xmlReader.Name.ToString().ToLower();
                if (text2 == null)
                {
                    goto IL_4CA;
                }
                if (!(text2 == "textlogo"))
                {
                    goto IL_4CA;
                }
                this.lstTextContent.Add(new AddEditSpecPrintProfile.TextContent
                {
                    Id = "txt" + Convert.ToString(xmlReader.GetAttribute("Name")),
                    Name = Convert.ToString(xmlReader.GetAttribute("Content")),
                    FontSize = Convert.ToInt32(xmlReader.GetAttribute("FontSize")),
                    FontFamily = Convert.ToString(xmlReader.GetAttribute("FontFamily")),
                    FontColor = ColorTranslator.FromHtml(Convert.ToString(xmlReader.GetAttribute("FontColor"))).Name
                });
                this.lstTextCollection.Add(new AddEditSpecPrintProfile.TextContent
                {
                    Id = "txt" + Convert.ToString(xmlReader.GetAttribute("Name")),
                    Name = Convert.ToString(xmlReader.GetAttribute("Content")),
                    FontSize = Convert.ToInt32(xmlReader.GetAttribute("FontSize")),
                    FontFamily = Convert.ToString(xmlReader.GetAttribute("FontFamily")),
                    FontColor = Convert.ToString(xmlReader.GetAttribute("FontColor"))
                });
                StackPanel stackPanel = new StackPanel();
                textBox = new System.Windows.Controls.TextBox();
                if (xmlReader.GetAttribute("FontFamily").ToString() != string.Empty)
                {
                    System.Windows.Media.FontFamily fontFamily = (System.Windows.Media.FontFamily)new FontFamilyConverter().ConvertFromString(xmlReader.GetAttribute("FontFamily").ToString());
                    textBox.FontFamily = fontFamily;
                }
                textBox.Background = new SolidColorBrush(Colors.Transparent);
                goto IL_299;
            }
        }

        private void RemoveTextFields()
        {
            List<UIElement> list = new List<UIElement>();
            do
            {
                IEnumerator enumerator = this.dragCanvas.Children.GetEnumerator();
                try
                {
                    while (true)
                    {
                    IL_54:
                        bool arg_5A_0 = enumerator.MoveNext();
                    IL_5A:
                        while (arg_5A_0)
                        {
                            UIElement uIElement = (UIElement)enumerator.Current;
                            bool arg_3F_0 = !(uIElement is System.Windows.Controls.TextBox);
                            bool expr_40;
                            do
                            {
                                bool flag = arg_3F_0;
                                expr_40 = (arg_3F_0 = (arg_5A_0 = flag));
                                if (2 == 0)
                                {
                                    goto IL_5A;
                                }
                            }
                            while (false);
                            if (!expr_40)
                            {
                                list.Add(uIElement);
                            }
                            goto IL_54;
                        }
                        break;
                    }
                }
                finally
                {
                    if (7 != 0)
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        if (disposable != null)
                        {
                            disposable.Dispose();
                        }
                    }
                }
                do
                {
                    List<UIElement>.Enumerator enumerator2 = list.GetEnumerator();
                    try
                    {
                        while (enumerator2.MoveNext())
                        {
                            UIElement uIElement = enumerator2.Current;
                            this.dragCanvas.Children.Remove(uIElement);
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
                while (6 == 0);
            }
            while (7 == 0);
        }

        private void BindBorders()
        {
            this.lstBorderList = new BorderBusiness().GetBorderDetails();
            this.lstBorderList = (from o in this.lstBorderList
                                  where o.DG_IsActive
                                  select o).ToList<BorderInfo>();
            CommonUtility.BindComboWithSelect<BorderInfo>(this.cmbborder, this.lstBorderList, "DG_Border", "DG_Borders_pkey", 0, ClientConstant.SelectString);
            CommonUtility.BindCombo<BorderInfo>(this.cmbVerticalBorder, this.lstBorderList, "DG_Border", "DG_Borders_pkey");
            this.cmbborder.SelectedValue = "0";
            this.cmbVerticalBorder.SelectedValue = "0";
        }

        public void DeleteGraphics()
        {
            System.Windows.Controls.Button button;
            while (true)
            {
                bool arg_5F_0;
                bool expr_0E = arg_5F_0 = (this.elementForContextMenu is System.Windows.Controls.Button);
                if (!false)
                {
                    arg_5F_0 = !expr_0E;
                }
                bool flag = arg_5F_0;
                while (true)
                {
                    bool arg_3D_0;
                    bool expr_62 = arg_3D_0 = flag;
                    if (6 == 0)
                    {
                        goto IL_3D;
                    }
                    if (expr_62)
                    {
                        return;
                    }
                IL_20:
                    button = (System.Windows.Controls.Button)this.elementForContextMenu;
                    if (false)
                    {
                        continue;
                    }
                    flag = (button == null);
                    if (false)
                    {
                        break;
                    }
                    arg_3D_0 = flag;
                IL_3D:
                    if (arg_3D_0)
                    {
                        return;
                    }
                    if (!false)
                    {
                        goto Block_5;
                    }
                    goto IL_20;
                }
            }
        Block_5:
            this.dragCanvas.Children.Remove(button);
        }

        private void OpenAssociateWindow()
        {
            while (true)
            {
                this.grdSpecProf.IsEnabled = false;
                this.grdSpecProf.Opacity = 0.4;
                if (false)
                {
                    goto IL_4B;
                }
                this.ucDynamicImgCrop.Visibility = Visibility.Visible;
                if (!false)
                {
                }
                if (-1 != 0)
                {
                    this.ucDynamicImgCrop.txtImgPath.Focus();
                    goto IL_4B;
                }
            IL_5E:
                Keyboard.Focus(this.ucDynamicImgCrop.txtImgPath);
                if (!false)
                {
                    break;
                }
                continue;
            IL_4B:
                FocusManager.SetFocusedElement(this, this.ucDynamicImgCrop.txtImgPath);
                goto IL_5E;
            }
        }

        public RenderTargetBitmap jCaptureScreen(Grid forWdht)
        {
            RenderTargetBitmap result;
            do
            {
                RenderTargetBitmap renderTargetBitmap = null;
                try
                {
                    base.InvalidateVisual();
                    BitmapImage bitmapImage = this.mainImage.Source as BitmapImage;
                    double dpiX = bitmapImage.DpiX;
                    double dpiY = bitmapImage.DpiY;
                    RenderOptions.SetBitmapScalingMode(forWdht, BitmapScalingMode.HighQuality);
                    RenderOptions.SetEdgeMode(forWdht, EdgeMode.Aliased);
                    try
                    {
                        System.Windows.Size size;
                        int arg_D7_0;
                        int arg_D7_1;
                        double arg_D7_2;
                        if (this._ZoomFactor > 1.4)
                        {
                            size = new System.Windows.Size(forWdht.ActualWidth, forWdht.ActualHeight);
                            arg_D7_0 = (int)(size.Width * dpiX / 96.0 * (1.0 / this._ZoomFactor));
                            double arg_B0_0 = size.Height;
                            double arg_B0_1 = dpiY;
                            double expr_B0;
                            double expr_B1;
                            do
                            {
                                expr_B0 = (arg_B0_0 *= arg_B0_1);
                                expr_B1 = (arg_B0_1 = 96.0);
                            }
                            while (false);
                            arg_D7_1 = (int)(expr_B0 / expr_B1 * (1.0 / this._ZoomFactor));
                            arg_D7_2 = dpiX;
                        }
                        else
                        {
                            size = new System.Windows.Size(forWdht.ActualWidth, forWdht.ActualHeight);
                            int expr_180 = arg_D7_0 = (int)(size.Width * dpiY / 96.0);
                            int expr_194 = arg_D7_1 = (int)(size.Height * dpiY / 96.0);
                            double expr_195 = arg_D7_2 = dpiX;
                            if (!false)
                            {
                                renderTargetBitmap = new RenderTargetBitmap(expr_180, expr_194, expr_195, dpiY, PixelFormats.Default);
                                RenderOptions.SetEdgeMode(forWdht, EdgeMode.Aliased);
                                forWdht.SnapsToDevicePixels = true;
                                forWdht.RenderTransform = new ScaleTransform(1.0, 1.0, 0.5, 0.5);
                                forWdht.Measure(size);
                                forWdht.Arrange(new Rect(size));
                                if (!false)
                                {
                                    renderTargetBitmap.Render(forWdht);
                                    forWdht.RenderTransform = null;
                                    goto IL_216;
                                }
                                goto IL_149;
                            }
                        }
                        renderTargetBitmap = new RenderTargetBitmap(arg_D7_0, arg_D7_1, arg_D7_2, dpiY, PixelFormats.Default);
                        RenderOptions.SetEdgeMode(forWdht, EdgeMode.Aliased);
                        forWdht.SnapsToDevicePixels = true;
                        forWdht.RenderTransform = new ScaleTransform(1.0 / this._ZoomFactor, 1.0 / this._ZoomFactor, 0.5, 0.5);
                        forWdht.Measure(size);
                        forWdht.Arrange(new Rect(size));
                        renderTargetBitmap.Render(forWdht);
                    IL_149:
                        forWdht.RenderTransform = null;
                    IL_216:
                        result = renderTargetBitmap;
                    }
                    catch (Exception var_5_25C)
                    {
                        Rect descendantBounds = VisualTreeHelper.GetDescendantBounds(this.GrdBrightness);
                        DrawingVisual drawingVisual = new DrawingVisual();
                        int arg_2A5_0 = (int)(descendantBounds.Width * dpiX / 96.0);
                        double arg_28F_0 = descendantBounds.Height;
                        double arg_28F_1 = dpiY;
                        int expr_28F;
                        int expr_290;
                        do
                        {
                            expr_28F = (int)(arg_28F_0 *= arg_28F_1);
                            expr_290 = (int)(arg_28F_1 = 96.0);
                        }
                        while (-1 == 0);
                        renderTargetBitmap = new RenderTargetBitmap(arg_2A5_0, expr_28F / expr_290, dpiX, dpiY, PixelFormats.Default);
                        using (DrawingContext drawingContext = drawingVisual.RenderOpen())
                        {
                            if (8 == 0)
                            {
                                goto IL_2E5;
                            }
                            VisualBrush brush = new VisualBrush(forWdht);
                        IL_2C0:
                            if (3 != 0)
                            {
                                drawingContext.DrawRectangle(brush, null, new Rect(default(System.Windows.Point), descendantBounds.Size));
                            }
                        IL_2E5:
                            if (3 == 0)
                            {
                                goto IL_2C0;
                            }
                        }
                        renderTargetBitmap.Render(drawingVisual);
                        result = renderTargetBitmap;
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                    result = renderTargetBitmap;
                }
            }
            while (false);
            return result;
        }

        public void ResetSpecControlValues()
        {
            this.txtContent.Text = "Enter Text...";
            this.cmbFont.SelectedIndex = 0;
            this.CmbColor.SelectedIndex = 0;
            this.CmbFontSize.SelectedIndex = 6;
            this.grdTextField.ItemsSource = null;
            this.grdTextField.Visibility = Visibility.Collapsed;
            this.RemoveTextFields();
            this.txtAngle.Text = "0";
            this.chkbrightness.IsChecked = new bool?(false);
            this.chkcontrast.IsChecked = new bool?(false);
            this.txtbrightness.Text = "0";
            this.txtcontrast.Text = "1";
            this.chkBorder.IsChecked = new bool?(false);
            this.chkBorder2.IsChecked = new bool?(false);
            this.cmbborder.SelectedIndex = 0;
            this.cmbVerticalBorder.SelectedIndex = 0;
            this.chkCrop.IsChecked = new bool?(false);
            this.cmbChromaClr.SelectedIndex = 0;
            this.txtColorCode.Text = string.Empty;
            this.txtChromaTol.Text = string.Empty;
            this.chkBG.IsChecked = new bool?(false);
            this.cmbBG.SelectedIndex = 0;
            this.chkPrintActive.IsChecked = new bool?(true);
            this.chkEnableSOrder.IsChecked = new bool?(false);
            Configuration.HorizontalCropCoordinates = string.Empty;
            Configuration.VerticalCropCoordinates = string.Empty;
            this.semiOrderSettings = null;
            this.pkey = 0;
            for (int i = 0; i < this.lstboxProductTypes.Items.Count; i++)
            {
                DependencyObject dependencyObject = this.lstboxProductTypes.ItemContainerGenerator.ContainerFromIndex(i);
                if (dependencyObject != null)
                {
                    System.Windows.Controls.CheckBox checkBox = AddEditSpecPrintProfile.FindVisualChild<System.Windows.Controls.CheckBox>(dependencyObject);
                    if (checkBox != null)
                    {
                        checkBox.IsChecked = new bool?(false);
                    }
                }
            }
        }

        public void ResetSpecPrintEffects()
        {
            this.SpecFileName = string.Empty;
            if (!string.IsNullOrWhiteSpace(this.SpecFileName))
            {
                this.btnChroma.IsEnabled = true;
            }
            this.btndelete.IsEnabled = false;
            this.btngraphics1.IsEnabled = false;
            this.btnHighPreview.IsEnabled = false;
            this.Grdcartoonize.Effect = null;
            this.Grdcartoonize.RenderTransform = null;
            Canvas.SetLeft(this.Grdcartoonize, 0.0);
            Canvas.SetTop(this.Grdcartoonize, 0.0);
            this.GrdContrast.Effect = null;
            this.GrdContrast.RenderTransform = null;
            Canvas.SetLeft(this.GrdContrast, 0.0);
            Canvas.SetTop(this.GrdContrast, 0.0);
            this.GrdBrightness.Effect = null;
            this.GrdBrightness.RenderTransform = null;
            Canvas.SetLeft(this.GrdBrightness, 0.0);
            Canvas.SetTop(this.GrdBrightness, 0.0);
            this.canbackground.Effect = null;
            this.canbackground.RenderTransform = null;
            Canvas.SetLeft(this.canbackground, 0.0);
            Canvas.SetTop(this.canbackground, 0.0);
            this.canbackground.Background = null;
            if (this.frm.Children.Count > 0)
            {
                for (int i = 0; i < this.frm.Children.Count; i++)
                {
                    this.frm.Children.RemoveAt(i);
                }
            }
            for (int j = 0; j < this.dragCanvas.Children.Count; j++)
            {
                if (this.dragCanvas.Children[j] is System.Windows.Controls.Button)
                {
                    this.dragCanvas.Children.RemoveAt(j);
                    j--;
                }
            }
            this.frm.Effect = null;
            this.frm.RenderTransform = null;
            this.mainImage.Source = null;
            this.mainImage_Size.Source = null;
            this.mainImagesize.Source = null;
            Uri uriSource = new Uri("/DigiPhoto;component/images/125412626.jpg", UriKind.RelativeOrAbsolute);
            this.mainImage.Source = new BitmapImage(uriSource);
            this.mainImage_Size.Source = new BitmapImage(uriSource);
            this.mainImagesize.Source = new BitmapImage(uriSource);
            this.canbackground.UpdateLayout();
        }

        private void loadProductType()
        {
            this.lstBGList = new Dictionary<string, string>();
            try
            {
                this.lstBGList.Add("--Select--", "0");
                while (true)
                {
                    BackgroundBusiness backgroundBusiness = new BackgroundBusiness();
                    do
                    {
                        List<BackGroundInfo>.Enumerator enumerator = backgroundBusiness.GetBackgoundDetailsALL().GetEnumerator();
                        try
                        {
                            while (true)
                            {
                                bool flag = enumerator.MoveNext();
                                if (!flag)
                                {
                                    break;
                                }
                                BackGroundInfo current = enumerator.Current;
                                bool arg_7C_0;
                                if (current.DG_Background_IsActive.HasValue)
                                {
                                    arg_7C_0 = !current.DG_Background_IsActive.Value;
                                    goto IL_7B;
                                }
                                if (5 != 0)
                                {
                                    arg_7C_0 = true;
                                    goto IL_7B;
                                }
                            IL_7E:
                                if (!flag)
                                {
                                    this.lstBGList.Add(current.DG_BackGround_Image_Name.ToString(), current.DG_Background_pkey.ToString());
                                }
                                continue;
                            IL_7B:
                                flag = arg_7C_0;
                                goto IL_7E;
                            }
                        }
                        finally
                        {
                            do
                            {
                                ((IDisposable)enumerator).Dispose();
                            }
                            while (5 == 0 || 7 == 0);
                        }
                    }
                    while (false);
                    this.cmbBG.ItemsSource = this.lstBGList;
                    this.cmbBG.SelectedValue = "0";
                    while (!false)
                    {
                        if (6 != 0)
                        {
                            goto Block_6;
                        }
                    }
                }
            Block_6: ;
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void FillProductCombo()
        {
            if (!false)
            {
                if (4 != 0)
                {
                    try
                    {
                        do
                        {
                            this.lstproductTypes = new ProductBusiness().GetProductType().Where(delegate(ProductTypeInfo t)
                            {
                                bool? dG_IsPrimary = t.DG_IsPrimary;
                                int arg_42_0;
                                if (!dG_IsPrimary.GetValueOrDefault())
                                {
                                    arg_42_0 = 0;
                                    goto IL_16;
                                }
                                arg_42_0 = (dG_IsPrimary.HasValue ? 1 : 0);
                            IL_10:
                                if (!false)
                                {
                                }
                            IL_16:
                                bool expr_45;
                                do
                                {
                                    bool flag = arg_42_0 != 0;
                                    if (!false)
                                    {
                                    }
                                    expr_45 = ((arg_42_0 = (flag ? 1 : 0)) != 0);
                                }
                                while (8 == 0);
                                if (!false)
                                {
                                    return expr_45;
                                }
                                goto IL_10;
                            }).ToList<ProductTypeInfo>();
                            this.lstboxProductTypes.ItemsSource = this.lstproductTypes;
                        }
                        while (8 == 0);
                        if (8 != 0)
                        {
                            this.lstboxProductTypes.ScrollIntoView(this.lstboxProductTypes.Items[0]);
                        }
                    }
                    catch (Exception serviceException)
                    {
                        string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                        if (7 != 0)
                        {
                        }
                    }
                }
            }
        }

        public void LoadGraphics()
        {
            try
            {
                string str = LoginUser.DigiFolderGraphicsPath + "\\";
                this.lstGraphics.Items.Clear();
                List<GraphicsInfo> graphicsDetails = new GraphicsBusiness().GetGraphicsDetails();
                using (List<GraphicsInfo>.Enumerator enumerator = graphicsDetails.GetEnumerator())
                {
                    while (true)
                    {
                        bool arg_FA_0 = enumerator.MoveNext();
                        bool expr_FC;
                        do
                        {
                            bool flag = arg_FA_0;
                            expr_FC = (arg_FA_0 = flag);
                        }
                        while (3 == 0);
                        GraphicsInfo current;
                        LstMyItems lstMyItems;
                        if (!expr_FC)
                        {
                            if (!false)
                            {
                                break;
                            }
                            goto IL_CA;
                        }
                        else
                        {
                            current = enumerator.Current;
                            if (current.DG_Graphics_IsActive.HasValue && current.DG_Graphics_IsActive.Value)
                            {
                                Uri uriSource = new Uri(str + current.DG_Graphics_Name);
                                lstMyItems = new LstMyItems();
                                BitmapImage bmpImage = new BitmapImage(uriSource);
                                lstMyItems.BmpImage = bmpImage;
                                lstMyItems.Name = current.DG_Graphics_Name;
                                lstMyItems.Photoname1 = current.DG_Graphics_Displayname;
                                goto IL_CA;
                            }
                        }
                        continue;
                    IL_CA:
                        lstMyItems.FilePath = str + current.DG_Graphics_Name;
                        this.lstGraphics.Items.Add(lstMyItems);
                    }
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj) where childItem : DependencyObject
        {
            int num = 0;
            childItem result;
            while (true)
            {
                int arg_83_0 = num;
                int arg_83_1 = VisualTreeHelper.GetChildrenCount(obj);
                int expr_75;
                int expr_77;
                while (true)
                {
                IL_83:
                    bool flag = arg_83_0 < arg_83_1;
                    bool arg_89_0 = flag;
                    while (true)
                    {
                    IL_89:
                        if (!arg_89_0)
                        {
                            result = default(childItem);
                            goto IL_9B;
                        }
                        goto IL_0D;
                    IL_23:
                        DependencyObject dependencyObject;
                        int arg_34_0;
                        arg_83_0 = (arg_34_0 = ((dependencyObject is childItem) ? 1 : 0));
                        int arg_31_0 = 0;
                        while (true)
                        {
                            int expr_31 = arg_83_1 = arg_31_0;
                            if (expr_31 != 0)
                            {
                                goto IL_83;
                            }
                            if (arg_34_0 != expr_31)
                            {
                                break;
                            }
                            childItem childItem = AddEditSpecPrintProfile.FindVisualChild<childItem>(dependencyObject);
                            bool expr_5E = arg_89_0 = (childItem == null);
                            if (4 == 0)
                            {
                                goto IL_89;
                            }
                            if (!expr_5E)
                            {
                                goto Block_4;
                            }
                            expr_75 = (arg_34_0 = (arg_83_0 = num));
                            expr_77 = (arg_31_0 = 1);
                            if (expr_77 != 0)
                            {
                                goto Block_7;
                            }
                        }
                        result = (childItem)((object)dependencyObject);
                        goto IL_9B;
                    Block_4:
                        if (!false && -1 != 0)
                        {
                            childItem childItem;
                            result = childItem;
                            goto IL_9B;
                        }
                    IL_0D:
                        DependencyObject expr_B5 = VisualTreeHelper.GetChild(obj, num);
                        if (7 == 0)
                        {
                            goto IL_23;
                        }
                        dependencyObject = expr_B5;
                        goto IL_23;
                    IL_9B:
                        if (4 != 0)
                        {
                            return result;
                        }
                        goto IL_23;
                    }
                }
            Block_7:
                num = expr_75 + expr_77;
            }
            return result;
        }

        public string BindProfileProductAssociation(int profileId, string ProfileName)
        {
            string result;
            while (true)
            {
                if (false)
                {
                    goto IL_BA;
                }
                string empty = string.Empty;
                if (this.lstproductTypes != null)
                {
                    foreach (ProductTypeInfo current in this.lstproductTypes)
                    {
                        string[] source = ProfileName.Split(new char[]
						{
							','
						});
                        bool arg_79_0;
                        bool expr_70 = arg_79_0 = !source.Contains(current.DG_Orders_ProductType_Name);
                        if (2 != 0)
                        {
                            bool flag = expr_70;
                            arg_79_0 = flag;
                        }
                        if (!arg_79_0)
                        {
                            current.IsChecked = true;
                        }
                        else
                        {
                            current.IsChecked = false;
                        }
                    }
                    goto IL_BA;
                }
            IL_107:
                result = empty;
                if (true)
                {
                    break;
                }
                continue;
            IL_BA:
                this.lstboxProductTypes.ItemsSource = null;
                this.lstboxProductTypes.ItemsSource = this.lstproductTypes;
                this.lstboxProductTypes.UpdateLayout();
                this.lstboxProductTypes.ScrollIntoView(this.lstboxProductTypes.Items[0]);
                if (5 != 0)
                {
                    goto IL_107;
                }
                goto IL_107;
            }
            return result;
        }

        private void AddDefaultFontSize()
        {
            this.CmbFontSize.Items.Clear();
            this.CmbFontSize.Items.Add("10");
            this.CmbFontSize.Items.Add("11");
            this.CmbFontSize.Items.Add("12");
            this.CmbFontSize.Items.Add("14");
            this.CmbFontSize.Items.Add("16");
            this.CmbFontSize.Items.Add("18");
            this.CmbFontSize.Items.Add("20");
            do
            {
                this.CmbFontSize.Items.Add("22");
                this.CmbFontSize.Items.Add("24");
                this.CmbFontSize.Items.Add("26");
                this.CmbFontSize.Items.Add("28");
                this.CmbFontSize.Items.Add("36");
                this.CmbFontSize.Items.Add("48");
                this.CmbFontSize.Items.Add("72");
            }
            while (6 == 0);
            this.CmbFontSize.Items.Add("80");
            this.CmbFontSize.Items.Add("90");
            this.CmbFontSize.Items.Add("100");
        }

        private void btnAddTextLogo_Click(object sender, RoutedEventArgs e)
        {
            this.elementForContextMenu = null;
            this.AddTextLogo();
        }

        private void AddTextLogo()
        {
            System.Windows.Controls.TextBox textBox = new System.Windows.Controls.TextBox();
            textBox.ContextMenu = this.dragCanvas.ContextMenu;
            do
            {
                textBox.Foreground = new SolidColorBrush(Colors.DarkRed);
                do
                {
                    textBox.Background = new SolidColorBrush(Colors.Transparent);
                    textBox.FontWeight = FontWeights.Bold;
                    textBox.MaxLength = 200;
                    if (!true)
                    {
                        goto IL_1DA;
                    }
                    textBox.FontSize = 20.0;
                    this.CmbFontSize.SelectedIndex = 6;
                    this.cmbFont.SelectedIndex = 0;
                    this.CmbColor.SelectedIndex = 0;
                    if (false)
                    {
                        goto IL_1DA;
                    }
                    textBox.FontFamily = (System.Windows.Media.FontFamily)new FontFamilyConverter().ConvertFromString("Arial");
                }
                while (6 == 0);
                textBox.Text = "Enter Text...";
                textBox.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);
                textBox.Uid = "txtblock";
            }
            while (false);
            textBox.BorderBrush = null;
            textBox.Style = (Style)base.FindResource("SearchIDTB");
            do
            {
                RotateTransform renderTransform = new RotateTransform();
                textBox.RenderTransform = renderTransform;
                textBox.MouseLeftButtonUp += new MouseButtonEventHandler(this.SelectObject);
                textBox.LostFocus += new RoutedEventHandler(this.txtContent_LostFocus);
                textBox.GotFocus += new RoutedEventHandler(this.txtContent_GotFocus);
                textBox.TextChanged += new TextChangedEventHandler(this.txtTest_TextChanged);
                this.txtContent.Text = textBox.Text;
            }
            while (5 == 0);
            this.dragCanvas.Children.Add(textBox);
            Canvas.SetLeft(textBox, this.GrdBrightness.ActualWidth / 2.0);
            Canvas.SetTop(textBox, this.GrdBrightness.ActualHeight / 2.0);
        IL_1DA:
            System.Windows.Controls.Panel.SetZIndex(textBox, 11);
            this.txtContent.Focus();
        }

        private void txtTest_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool arg_3A_0;
            bool expr_09 = arg_3A_0 = (sender is System.Windows.Controls.TextBox);
            if (!false)
            {
                arg_3A_0 = !expr_09;
            }
            if (!arg_3A_0)
            {
                if (!false)
                {
                    System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)sender;
                    if (3 != 0)
                    {
                        this.txtContent.Text = textBox.Text;
                    }
                }
            }
        }

        private void txtContent_LostFocus(object sender, RoutedEventArgs e)
        {
            if (-1 != 0)
            {
                bool arg_17_0;
                bool arg_58_0 = arg_17_0 = (this.elementForContextMenu is System.Windows.Controls.TextBox);
                bool flag;
                while (!false)
                {
                    flag = !arg_17_0;
                    bool expr_7F = arg_17_0 = (arg_58_0 = flag);
                    if (7 != 0)
                    {
                        if (!expr_7F)
                        {
                        IL_25:
                            System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)this.elementForContextMenu;
                            if (4 != 0)
                            {
                                textBox.BorderBrush = System.Windows.Media.Brushes.Transparent;
                            }
                            else
                            {
                            IL_59:
                                if (false)
                                {
                                    goto IL_25;
                                }
                                if (!flag)
                                {
                                    this.txtContent.Text = "Enter text...";
                                    return;
                                }
                                return;
                            }
                        }
                        arg_58_0 = !(this.txtContent.Text == "");
                        break;
                    }
                }
                flag = arg_58_0;
                goto IL_59;
            }
        }

        private void txtContent_GotFocus(object sender, RoutedEventArgs e)
        {
            if (-1 != 0)
            {
                bool arg_17_0;
                bool arg_58_0 = arg_17_0 = (this.elementForContextMenu is System.Windows.Controls.TextBox);
                bool flag;
                while (!false)
                {
                    flag = !arg_17_0;
                    bool expr_7F = arg_17_0 = (arg_58_0 = flag);
                    if (7 != 0)
                    {
                        if (!expr_7F)
                        {
                        IL_25:
                            System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)this.elementForContextMenu;
                            if (4 != 0)
                            {
                                textBox.BorderBrush = System.Windows.Media.Brushes.OrangeRed;
                            }
                            else
                            {
                            IL_59:
                                if (false)
                                {
                                    goto IL_25;
                                }
                                if (!flag)
                                {
                                    this.txtContent.Text = "";
                                    return;
                                }
                                return;
                            }
                        }
                        arg_58_0 = !(this.txtContent.Text == "Enter text...");
                        break;
                    }
                }
                flag = arg_58_0;
                goto IL_59;
            }
        }

        private void txtContent_TextChanged(object sender, TextChangedEventArgs e)
        {
            do
            {
                bool flag = this.elementForContextMenu == null;
                if (5 != 0)
                {
                    bool arg_2E_0;
                    bool expr_73 = arg_2E_0 = flag;
                    if (-1 != 0)
                    {
                        if (expr_73)
                        {
                            goto IL_60;
                        }
                        arg_2E_0 = (this.elementForContextMenu is System.Windows.Controls.TextBox);
                    }
                    flag = !arg_2E_0;
                    while (true)
                    {
                        if (flag)
                        {
                            goto IL_5C;
                        }
                    IL_36:
                        System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)this.elementForContextMenu;
                        if (-1 == 0)
                        {
                            continue;
                        }
                        textBox.Text = this.txtContent.Text;
                    IL_5C:
                        if (5 != 0)
                        {
                            break;
                        }
                        goto IL_36;
                    }
                }
            IL_60: ;
            }
            while (false);
        }

        private void cmbFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            while (this.elementForContextMenu != null)
            {
                bool arg_2E_0 = this.elementForContextMenu is System.Windows.Controls.TextBox;
                bool expr_94;
                do
                {
                    bool flag = !arg_2E_0;
                    expr_94 = (arg_2E_0 = flag);
                }
                while (7 == 0);
                if (!expr_94)
                {
                    if (this.cmbFont.SelectedValue != null)
                    {
                        System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)this.elementForContextMenu;
                        textBox.FontFamily = (System.Windows.Media.FontFamily)this.cmbFont.SelectedValue;
                    }
                    if (false)
                    {
                        continue;
                    }
                }
                break;
            }
        }

        private void CmbColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            while (this.elementForContextMenu != null)
            {
                bool arg_2E_0 = this.elementForContextMenu is System.Windows.Controls.TextBox;
                bool expr_94;
                do
                {
                    bool flag = !arg_2E_0;
                    expr_94 = (arg_2E_0 = flag);
                }
                while (7 == 0);
                if (!expr_94)
                {
                    if (this.CmbColor.SelectedValue != null)
                    {
                        System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)this.elementForContextMenu;
                        textBox.Foreground = (SolidColorBrush)this.CmbColor.SelectedValue;
                    }
                    if (false)
                    {
                        continue;
                    }
                }
                break;
            }
        }

        private void CmbFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bool flag;
            if (!false)
            {
                if (4 == 0)
                {
                    goto IL_54;
                }
                flag = (this.elementForContextMenu == null);
                if (8 == 0)
                {
                    return;
                }
                if (flag)
                {
                    return;
                }
            }
            if (!(this.elementForContextMenu is System.Windows.Controls.TextBox))
            {
                return;
            }
            flag = (this.CmbFontSize.SelectedValue == null);
            if (4 != 0)
            {
                if (flag)
                {
                    return;
                }
            }
        IL_54:
            System.Windows.Controls.TextBox textBox = (System.Windows.Controls.TextBox)this.elementForContextMenu;
            if (5 != 0)
            {
                textBox.FontSize = Convert.ToDouble(this.CmbFontSize.SelectedValue.ToString());
            }
        }

        private void DeleteTextLogo()
        {
            try
            {
                System.Windows.Controls.TextBox textBox;
                if (-1 != 0)
                {
                    bool arg_8F_0;
                    bool expr_0D = arg_8F_0 = (this.elementForContextMenu == null);
                    if (!false)
                    {
                        if (expr_0D)
                        {
                            goto IL_71;
                        }
                        arg_8F_0 = !(this.elementForContextMenu is System.Windows.Controls.TextBox);
                    }
                    bool flag = arg_8F_0;
                    bool arg_38_0 = flag;
                    while (!arg_38_0)
                    {
                        if (false)
                        {
                            break;
                        }
                        textBox = (System.Windows.Controls.TextBox)this.elementForContextMenu;
                        if (false)
                        {
                            break;
                        }
                        flag = (textBox == null);
                        bool expr_55 = arg_38_0 = flag;
                        if (!false)
                        {
                            if (!expr_55)
                            {
                                goto IL_5C;
                            }
                            break;
                        }
                    }
                    goto IL_70;
                }
            IL_5C:
                this.dragCanvas.Children.Remove(textBox);
            IL_6D:
            IL_70:
            IL_71:
                if (false)
                {
                    goto IL_6D;
                }
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
        }

        private void btnDeleteTextLogo_Click(object sender, RoutedEventArgs e)
        {
            this.DeleteTextLogo();
            AddEditSpecPrintProfile.TextContent item = this.lstTextContent.SingleOrDefault((AddEditSpecPrintProfile.TextContent s) => s.Id == this.itemNo);
            this.lstTextContent.Remove(item);
            this.grdTextField.ItemsSource = null;
            this.grdTextField.ItemsSource = this.lstTextContent;
            this.txtContent.Text = "Enter text...";
            this.CmbFontSize.SelectedIndex = 6;
            this.cmbFont.SelectedIndex = 0;
            this.CmbColor.SelectedIndex = 0;
        }

        private void chkPrintActive_Checked(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                bool arg_17_0;
                bool arg_30_0 = arg_17_0 = (this.chkEnableSOrder == null);
                do
                {
                    if (2 != 0)
                    {
                        bool flag;
                        if (7 != 0)
                        {
                            flag = arg_30_0;
                        }
                        arg_30_0 = (arg_17_0 = flag);
                    }
                }
                while (false);
                if (arg_17_0)
                {
                    goto IL_29;
                }
            IL_19:
                if (false)
                {
                    continue;
                }
                this.chkEnableSOrder.IsChecked = new bool?(false);
            IL_29:
                if (8 != 0)
                {
                    break;
                }
                goto IL_19;
            }
        }

        private void chkEnableSOrder_Checked(object sender, RoutedEventArgs e)
        {
            while (true)
            {
                bool arg_17_0;
                bool arg_30_0 = arg_17_0 = (this.chkPrintActive == null);
                do
                {
                    if (2 != 0)
                    {
                        bool flag;
                        if (7 != 0)
                        {
                            flag = arg_30_0;
                        }
                        arg_30_0 = (arg_17_0 = flag);
                    }
                }
                while (false);
                if (arg_17_0)
                {
                    goto IL_29;
                }
            IL_19:
                if (false)
                {
                    continue;
                }
                this.chkPrintActive.IsChecked = new bool?(false);
            IL_29:
                if (8 != 0)
                {
                    break;
                }
                goto IL_19;
            }
        }

        private void PastingHandler(object sender, DataObjectPastingEventArgs e)
        {
            bool arg_5A_0;
            bool expr_8B = arg_5A_0 = e.DataObject.GetDataPresent(typeof(string));
            if (5 != 0)
            {
                bool flag = !expr_8B;
                bool arg_27_0 = flag;
                while (!arg_27_0)
                {
                    string text;
                    do
                    {
                        text = (string)e.DataObject.GetData(typeof(string));
                    }
                    while (false);
                    bool expr_4D = arg_27_0 = AddEditSpecPrintProfile.IsTextAllowed(text);
                    if (!false)
                    {
                        flag = expr_4D;
                    IL_56:
                        if (!false)
                        {
                            arg_5A_0 = flag;
                            goto IL_5A;
                        }
                        return;
                    }
                }
                e.CancelCommand();
                if (5 != 0)
                {
                    return;
                }
                goto IL_56;
            }
        IL_5A:
            if (!arg_5A_0)
            {
                e.CancelCommand();
            }
        }

        private static bool IsTextAllowed(string text)
        {
            bool arg_29_0;
            bool flag;
            while (true)
            {
                while (!false)
                {
                    Regex expr_2A = new Regex("[< >]+");
                    Regex regex;
                    if (4 != 0)
                    {
                        regex = expr_2A;
                    }
                    while (true)
                    {
                        bool expr_16 = arg_29_0 = !regex.IsMatch(text);
                        if (-1 == 0)
                        {
                            return arg_29_0;
                        }
                        if (5 != 0)
                        {
                            flag = expr_16;
                        }
                        if (false)
                        {
                            break;
                        }
                        if (2 != 0)
                        {
                            goto Block_3;
                        }
                    }
                }
            }
        Block_3:
            arg_29_0 = flag;
            return arg_29_0;
        }

        private void txtContent_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!true)
            {
                goto IL_19;
            }
            if (!false)
            {
            }
        IL_07:
            if (3 == 0)
            {
                return;
            }
            e.Handled = !AddEditSpecPrintProfile.IsTextAllowed(e.Text.Trim());
        IL_19:
            if (8 == 0)
            {
                goto IL_07;
            }
        }

        private void grdTextField_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (false || this.grdTextField.SelectedItem != null)
            {
                string name = ((AddEditSpecPrintProfile.TextContent)this.grdTextField.SelectedItem).Name;
                List<AddEditSpecPrintProfile.TextContent>.Enumerator enumerator = this.lstTextCollection.GetEnumerator();
                try
                {
                    while (true)
                    {
                        if (2 != 0)
                        {
                            if (!enumerator.MoveNext())
                            {
                                break;
                            }
                            AddEditSpecPrintProfile.TextContent current;
                            while (true)
                            {
                            IL_5A:
                                current = enumerator.Current;
                                bool flag = !(name == current.Name);
                                while (!flag)
                                {
                                    this.LocateTextBox(current.Id);
                                    this.itemNo = current.Id;
                                    this.txtContent.Text = current.Name;
                                    if (5 != 0)
                                    {
                                        this.cmbFont.Text = current.FontFamily;
                                        if (8 == 0)
                                        {
                                            goto IL_5A;
                                        }
                                    }
                                    this.CmbFontSize.Text = Convert.ToString(current.FontSize);
                                    if (!false)
                                    {
                                        goto Block_6;
                                    }
                                }
                                goto IL_E7;
                            }
                        Block_6:
                            this.CmbColor.Text = current.FontColor;
                        }
                    IL_E7: ;
                    }
                }
                finally
                {
                    ((IDisposable)enumerator).Dispose();
                    if (!false)
                    {
                    }
                }
            }
        }

        private void LocateTextBox(string TBNum)
        {
            while (true)
            {
                System.Windows.Controls.TextBox textBox;
                bool arg_20_0;
                bool flag;
                if (!false)
                {
                    textBox = AddEditSpecPrintProfile.FindChild<System.Windows.Controls.TextBox>(this.dragCanvas, TBNum);
                    bool expr_14 = arg_20_0 = (textBox == null);
                    if (false)
                    {
                        goto IL_20;
                    }
                    flag = expr_14;
                }
            IL_1B:
                if (false)
                {
                    continue;
                }
                arg_20_0 = flag;
            IL_20:
                if (!arg_20_0)
                {
                    this.elementForContextMenu = textBox;
                }
                if (!false)
                {
                    break;
                }
                goto IL_1B;
            }
        }

        public static T FindChild<T>(DependencyObject parent, string childName) where T : DependencyObject
        {
            int arg_119_0 = (parent != null) ? 1 : 0;
            T t;
            DependencyObject child;
            while (true)
            {
                int childrenCount;
                int arg_96_0;
                int num;
                if (arg_119_0 == 0)
                {
                    if (!false)
                    {
                        break;
                    }
                    goto IL_81;
                }
                else
                {
                    t = default(T);
                    childrenCount = VisualTreeHelper.GetChildrenCount(parent);
                    int expr_4A = arg_96_0 = 0;
                    if (expr_4A == 0)
                    {
                        num = expr_4A;
                        goto IL_FB;
                    }
                    goto IL_96;
                }
            IL_CC:
                if (false)
                {
                    continue;
                }
                bool arg_D6_0;
                if (!false)
                {
                    if (!arg_D6_0)
                    {
                        goto Block_10;
                    }
                    goto IL_F3;
                }
            IL_AA:
                int arg_AA_0;
                if (arg_AA_0 != 0)
                {
                    goto IL_E9;
                }
                FrameworkElement frameworkElement = child as FrameworkElement;
                if (frameworkElement != null)
                {
                    arg_D6_0 = ((arg_AA_0 = (arg_119_0 = ((!(frameworkElement.Name == childName)) ? 1 : 0))) != 0);
                    goto IL_CC;
                }
                goto IL_CB;
            IL_FB:
                int arg_F9_0;
                int expr_FB = arg_F9_0 = num;
                int arg_F9_1;
                int expr_FC = arg_F9_1 = childrenCount;
                if (false)
                {
                    goto IL_F9;
                }
                if (expr_FB >= expr_FC)
                {
                    goto IL_10B;
                }
                child = VisualTreeHelper.GetChild(parent, num);
                T t2 = child as T;
                if (t2 == null)
                {
                    goto IL_81;
                }
                bool flag = string.IsNullOrEmpty(childName);
                arg_AA_0 = (flag ? 1 : 0);
                goto IL_AA;
            IL_CB:
                arg_D6_0 = ((arg_AA_0 = (arg_119_0 = 1)) != 0);
                goto IL_CC;
            IL_96:
                if (arg_96_0 == 0)
                {
                    goto Block_4;
                }
                if (!false)
                {
                    goto IL_F3;
                }
                goto IL_CB;
            IL_81:
                t = AddEditSpecPrintProfile.FindChild<T>(child, childName);
                flag = (t == null);
                arg_96_0 = (flag ? 1 : 0);
                goto IL_96;
            IL_F3:
                if (false)
                {
                    goto IL_FB;
                }
                arg_F9_0 = num;
                arg_F9_1 = 1;
            IL_F9:
                num = arg_F9_0 + arg_F9_1;
                goto IL_FB;
            }
            T result = default(T);
            return result;
        Block_4:
            goto IL_10B;
        Block_10:
            t = (T)((object)child);
            goto IL_10B;
        IL_E9:
            t = (T)((object)child);
        IL_10B:
            result = t;
            return result;
        }

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
        //public void InitializeComponent()
        //{
        //    bool arg_09_0 = this._contentLoaded;
        //    bool expr_09;
        //    do
        //    {
        //        expr_09 = (arg_09_0 = !arg_09_0);
        //    }
        //    while (false);
        //    bool flag = expr_09;
        //    while (true)
        //    {
        //        if (!flag)
        //        {
        //            goto IL_14;
        //        }
        //    IL_1A:
        //        this._contentLoaded = true;
        //        while (6 != 0)
        //        {
        //            Uri resourceLocator = new Uri("/DigiPhoto;component/usercontrol/addeditspecprintprofile.xaml", UriKind.Relative);
        //            if (!false)
        //            {
        //                System.Windows.Application.LoadComponent(this, resourceLocator);
        //                if (-1 != 0)
        //                {
        //                    return;
        //                }
        //                goto IL_14;
        //            }
        //        }
        //        continue;
        //    IL_14:
        //        if (6 != 0)
        //        {
        //            break;
        //        }
        //        goto IL_1A;
        //    }
        //}

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), DebuggerNonUserCode]
        //internal Delegate _CreateDelegate(Type delegateType, string handler)
        //{
        //    return Delegate.CreateDelegate(delegateType, this, handler);
        //}

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        //void IComponentConnector.Connect(int connectionId, object target)
        //{
        //    switch (connectionId)
        //    {
        //        case 2:
        //            this.grdSpecProf = (Grid)target;
        //            break;
        //        case 3:
        //            this.spZoompanel = (StackPanel)target;
        //            break;
        //        case 4:
        //            this.txtAngle = (System.Windows.Controls.TextBox)target;
        //            this.txtAngle.TextChanged += new TextChangedEventHandler(this.txtAngle_TextChanged);
        //            break;
        //        case 5:
        //            this.cmdUp = (RepeatButton)target;
        //            this.cmdUp.Click += new RoutedEventHandler(this.cmdUp_Click);
        //            break;
        //        case 6:
        //            this.cmdDown = (RepeatButton)target;
        //            this.cmdDown.Click += new RoutedEventHandler(this.cmdDown_Click);
        //            break;
        //        case 7:
        //            ((RepeatButton)target).Click += new RoutedEventHandler(this.ZoomInButton_Click);
        //            ((RepeatButton)target).MouseWheel += new MouseWheelEventHandler(this.RepeatButton_MouseWheel);
        //            break;
        //        case 8:
        //            ((RepeatButton)target).Click += new RoutedEventHandler(this.ZoomOutButton_Click);
        //            ((RepeatButton)target).MouseWheel += new MouseWheelEventHandler(this.RepeatButton_MouseWheel);
        //            break;
        //        case 9:
        //            this.btnHighPreview = (System.Windows.Controls.Button)target;
        //            this.btnHighPreview.Click += new RoutedEventHandler(this.btnPreviewAutoCorrect_Click);
        //            break;
        //        case 10:
        //            this.txbPreview = (TextBlock)target;
        //            break;
        //        case 11:
        //            this.btngraphics1 = (System.Windows.Controls.Button)target;
        //            this.btngraphics1.Click += new RoutedEventHandler(this.btnGraphics_Click);
        //            break;
        //        case 12:
        //            this.btngraphics2 = (System.Windows.Controls.Button)target;
        //            this.btngraphics2.Click += new RoutedEventHandler(this.btnFileOpen_Click);
        //            break;
        //        case 13:
        //            this.btndelete = (System.Windows.Controls.Button)target;
        //            this.btndelete.Click += new RoutedEventHandler(this.btndelete_Click_1);
        //            break;
        //        case 14:
        //            this.lstboxProductTypes = (System.Windows.Controls.ListBox)target;
        //            break;
        //        case 15:
        //            this.chkbrightness = (System.Windows.Controls.CheckBox)target;
        //            this.chkbrightness.Unchecked += new RoutedEventHandler(this.chkBorder_Unchecked);
        //            this.chkbrightness.Checked += new RoutedEventHandler(this.chkBorder_Checked);
        //            break;
        //        case 16:
        //            this.txtbrightness = (System.Windows.Controls.TextBox)target;
        //            break;
        //        case 17:
        //            this.chkcontrast = (System.Windows.Controls.CheckBox)target;
        //            this.chkcontrast.Unchecked += new RoutedEventHandler(this.chkBorder_Unchecked);
        //            this.chkcontrast.Checked += new RoutedEventHandler(this.chkBorder_Checked);
        //            break;
        //        case 18:
        //            this.txtcontrast = (System.Windows.Controls.TextBox)target;
        //            break;
        //        case 19:
        //            this.grdsize = (Grid)target;
        //            break;
        //        case 20:
        //            this.mainImagesize = (System.Windows.Controls.Image)target;
        //            break;
        //        case 21:
        //            this.canbackground = (Grid)target;
        //            break;
        //        case 22:
        //            this.ZoomBox = (Viewbox)target;
        //            break;
        //        case 23:
        //            this.mainImage_Size = (System.Windows.Controls.Image)target;
        //            this.mainImage_Size.MouseLeftButtonUp += new MouseButtonEventHandler(this.mainImage_Size_MouseLeftButtonUp);
        //            break;
        //        case 24:
        //            this.dragCanvas = (DragCanvas)target;
        //            break;
        //        case 25:
        //            this.GrdBrightness = (Grid)target;
        //            break;
        //        case 26:
        //            this.GrdContrast = (Grid)target;
        //            break;
        //        case 27:
        //            this.GrdHueShift = (Grid)target;
        //            break;
        //        case 28:
        //            this.GrdGreyScale = (Grid)target;
        //            break;
        //        case 29:
        //            this.GrdInvert = (Grid)target;
        //            break;
        //        case 30:
        //            this.GrdSharpen = (Grid)target;
        //            break;
        //        case 31:
        //            this.GrdSketchGranite = (Grid)target;
        //            break;
        //        case 32:
        //            this.GrdEmboss = (Grid)target;
        //            break;
        //        case 33:
        //            this.Grdcolorfilter = (Grid)target;
        //            break;
        //        case 34:
        //            this.Grdcartoonize = (Grid)target;
        //            this.Grdcartoonize.MouseWheel += new MouseWheelEventHandler(this.GrdBrightn_MouseWheel);
        //            break;
        //        case 35:
        //            this.mainImage = (System.Windows.Controls.Image)target;
        //            this.mainImage.MouseLeftButtonUp += new MouseButtonEventHandler(this.mainImage_MouseLeftButtonUp);
        //            break;
        //        case 36:
        //            this.frm = (Grid)target;
        //            break;
        //        case 37:
        //            this.chkBorder = (System.Windows.Controls.CheckBox)target;
        //            this.chkBorder.Unchecked += new RoutedEventHandler(this.chkBorder_Unchecked);
        //            this.chkBorder.Checked += new RoutedEventHandler(this.chkBorder_Checked);
        //            break;
        //        case 38:
        //            this.cmbVerticalBorder = (System.Windows.Controls.ComboBox)target;
        //            break;
        //        case 39:
        //            this.chkBorder2 = (System.Windows.Controls.CheckBox)target;
        //            this.chkBorder2.Unchecked += new RoutedEventHandler(this.chkBorder_Unchecked);
        //            this.chkBorder2.Checked += new RoutedEventHandler(this.chkBorder_Checked);
        //            break;
        //        case 40:
        //            this.cmbborder = (System.Windows.Controls.ComboBox)target;
        //            break;
        //        case 41:
        //            this.chkCrop = (System.Windows.Controls.CheckBox)target;
        //            this.chkCrop.Checked += new RoutedEventHandler(this.chkCrop_Checked);
        //            this.chkCrop.Unchecked += new RoutedEventHandler(this.chkCrop_Unchecked);
        //            break;
        //        case 42:
        //            this.btnCropEdit = (System.Windows.Controls.Button)target;
        //            this.btnCropEdit.Click += new RoutedEventHandler(this.btnCropEdit_Click);
        //            break;
        //        case 43:
        //            this.txbCrop = (TextBlock)target;
        //            break;
        //        case 44:
        //            this.chklogo = (System.Windows.Controls.CheckBox)target;
        //            this.chklogo.Unchecked += new RoutedEventHandler(this.chkBorder_Unchecked);
        //            if (7 != 0)
        //            {
        //                this.chklogo.Checked += new RoutedEventHandler(this.chkBorder_Checked);
        //            }
        //            break;
        //        case 45:
        //            this.cmblogo = (System.Windows.Controls.ComboBox)target;
        //            break;
        //        case 46:
        //            this.cmbChromaClr = (System.Windows.Controls.ComboBox)target;
        //            this.cmbChromaClr.SelectionChanged += new SelectionChangedEventHandler(this.cmbChromaClr_SelectionChanged);
        //            break;
        //        case 47:
        //            this.txtColorCode = (System.Windows.Controls.TextBox)target;
        //            break;
        //        case 48:
        //            this.txtChromaTol = (System.Windows.Controls.TextBox)target;
        //            this.txtChromaTol.KeyUp += new System.Windows.Input.KeyEventHandler(this.txtChromaTol_KeyUp);
        //            break;
        //        case 49:
        //            this.txbTolRange = (TextBlock)target;
        //            break;
        //        case 50:
        //            this.chkBG = (System.Windows.Controls.CheckBox)target;
        //            this.chkBG.Unchecked += new RoutedEventHandler(this.chkBorder_Unchecked);
        //            this.chkBG.Checked += new RoutedEventHandler(this.chkBorder_Checked);
        //            break;
        //        case 51:
        //            this.cmbBG = (System.Windows.Controls.ComboBox)target;
        //            this.cmbBG.SelectionChanged += new SelectionChangedEventHandler(this.cmbBG_SelectionChanged);
        //            break;
        //        case 52:
        //            this.btnChroma = (System.Windows.Controls.Button)target;
        //            this.btnChroma.Click += new RoutedEventHandler(this.btnChroma_Click);
        //            break;
        //        case 53:
        //            this.imgBackImage = (System.Windows.Controls.Image)target;
        //            break;
        //        case 54:
        //            this.stkTextLogo = (StackPanel)target;
        //            break;
        //        case 55:
        //            this.btnAddTextLogo = (System.Windows.Controls.Button)target;
        //            this.btnAddTextLogo.Click += new RoutedEventHandler(this.btnAddTextLogo_Click);
        //            break;
        //        case 56:
        //            this.txtContent = (System.Windows.Controls.TextBox)target;
        //            this.txtContent.PreviewTextInput += new TextCompositionEventHandler(this.txtContent_PreviewTextInput);
        //            this.txtContent.AddHandler(System.Windows.DataObject.PastingEvent, new DataObjectPastingEventHandler(this.PastingHandler));
        //            this.txtContent.TextChanged += new TextChangedEventHandler(this.txtContent_TextChanged);
        //            this.txtContent.GotFocus += new RoutedEventHandler(this.txtContent_GotFocus);
        //            this.txtContent.LostFocus += new RoutedEventHandler(this.txtContent_LostFocus);
        //            break;
        //        case 57:
        //            this.cmbFont = (System.Windows.Controls.ComboBox)target;
        //            this.cmbFont.SelectionChanged += new SelectionChangedEventHandler(this.cmbFont_SelectionChanged);
        //            break;
        //        case 58:
        //            this.CmbFontSize = (System.Windows.Controls.ComboBox)target;
        //            this.CmbFontSize.SelectionChanged += new SelectionChangedEventHandler(this.CmbFontSize_SelectionChanged);
        //            break;
        //        case 59:
        //            this.CmbColor = (System.Windows.Controls.ComboBox)target;
        //            this.CmbColor.SelectionChanged += new SelectionChangedEventHandler(this.CmbColor_SelectionChanged);
        //            break;
        //        case 60:
        //            this.DarkRed = (SolidColorBrush)target;
        //            break;
        //        case 61:
        //            this.Black = (SolidColorBrush)target;
        //            break;
        //        case 62:
        //            this.White = (SolidColorBrush)target;
        //            break;
        //        case 63:
        //            this.Red = (SolidColorBrush)target;
        //            break;
        //        case 64:
        //            this.OrangeRed = (SolidColorBrush)target;
        //            break;
        //        case 65:
        //            this.Orange = (SolidColorBrush)target;
        //            break;
        //        case 66:
        //            this.Green = (SolidColorBrush)target;
        //            break;
        //        case 67:
        //            this.Blue = (SolidColorBrush)target;
        //            break;
        //        case 68:
        //            this.AliceBlue = (SolidColorBrush)target;
        //            break;
        //        case 69:
        //            this.Cyan = (SolidColorBrush)target;
        //            break;
        //        case 70:
        //            this.Magenta = (SolidColorBrush)target;
        //            break;
        //        case 71:
        //            this.Yellow = (SolidColorBrush)target;
        //            break;
        //        case 72:
        //            this.Pink = (SolidColorBrush)target;
        //            break;
        //        case 73:
        //            this.Purple = (SolidColorBrush)target;
        //            break;
        //        case 74:
        //            this.Brown = (SolidColorBrush)target;
        //            break;
        //        case 75:
        //            this.btnDeleteTextLogo = (System.Windows.Controls.Button)target;
        //            this.btnDeleteTextLogo.Click += new RoutedEventHandler(this.btnDeleteTextLogo_Click);
        //            break;
        //        case 76:
        //            this.grdTextField = (System.Windows.Controls.DataGrid)target;
        //            this.grdTextField.SelectionChanged += new SelectionChangedEventHandler(this.grdTextField_SelectionChanged);
        //            break;
        //        case 77:
        //            this.chkPrintActive = (System.Windows.Controls.CheckBox)target;
        //            this.chkPrintActive.Checked += new RoutedEventHandler(this.chkPrintActive_Checked);
        //            break;
        //        case 78:
        //            this.chkEnableSOrder = (System.Windows.Controls.CheckBox)target;
        //            this.chkEnableSOrder.Checked += new RoutedEventHandler(this.chkEnableSOrder_Checked);
        //            break;
        //        case 79:
        //            this.btnSaveAutoCorrect = (System.Windows.Controls.Button)target;
        //            this.btnSaveAutoCorrect.Click += new RoutedEventHandler(this.btnSaveAutoCorrect_Click);
        //            break;
        //        case 80:
        //            this.btnBackAutoCorrect = (System.Windows.Controls.Button)target;
        //            this.btnBackAutoCorrect.Click += new RoutedEventHandler(this.btnBack_Click);
        //            break;
        //        case 81:
        //            this.GrdPrint = (Grid)target;
        //            break;
        //        case 82:
        //            this.lstGraphics = (System.Windows.Controls.ListBox)target;
        //            break;
        //        case 83:
        //            ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.Button_Click);
        //            break;
        //        case 84:
        //            this.ucDynamicImgCrop = (DynamicImgCrop)target;
        //            break;
        //        default:
        //            this._contentLoaded = true;
        //            break;
        //    }
        //}

        //[GeneratedCode("PresentationBuildTasks", "4.0.0.0"), EditorBrowsable(EditorBrowsableState.Never), DebuggerNonUserCode]
        void IStyleConnector.Connect(int connectionId, object target)
        {
            while (true)
            {
                if (8 == 0)
                {
                    goto IL_15;
                }
                int arg_0E_0 = connectionId;
                if (8 != 0)
                {
                    arg_0E_0 = connectionId;
                }
                if (arg_0E_0 == 1 || false)
                {
                    goto IL_15;
                }
            IL_2E:
                if (!false)
                {
                    break;
                }
                continue;
            IL_15:
                ((System.Windows.Controls.Button)target).Click += new RoutedEventHandler(this.Button_Click_1);
                goto IL_2E;
            }
        }
    }
}
