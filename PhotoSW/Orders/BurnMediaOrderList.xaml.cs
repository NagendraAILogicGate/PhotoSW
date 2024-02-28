using BurnMedia;
using PhotoSW.Common;
using PhotoSW.IMIX.Business;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media.Imaging;
using DigiPhoto;
using PhotoSW.Views;

namespace PhotoSW.Orders
{
    public partial class BurnMediaOrderList : Window, IComponentConnector, IStyleConnector
    {
        private delegate void UpdateDelegate(object[] x);

        private enum StatusCode
        {
            Pending,
            Success,
            Failed
        }

        private enum ProductCode
        {
            CD = 35,
            USB,
            VideoCD = 96,
            VideoUSB
        }

        private const string _clientName = "BurnMedia1";

        private List<MsftDiscRecorder2> _lstmain;

        private MsftDiscMaster2 _discMaster;

        private long _totalDiscSize;

        private BackgroundWorker _backgroundBurnWorker = new BackgroundWorker();

        private bool _isBurning;

        private bool _isFormatting;

        private IMAPI_BURN_VERIFICATION_LEVEL _verificationLevel = IMAPI_BURN_VERIFICATION_LEVEL.IMAPI_BURN_VERIFICATION_NONE;

        private bool _closeMedia;

        private bool _ejectMedia;

       private BurnData _burnData = new BurnData();

        private string _msg = string.Empty;

        private string _cdOrderSuccess = string.Empty;

        public bool _isAutoStart = false;

        private bool _isActiveStockShot = false;

        private BackgroundWorker _bwBurn = new BackgroundWorker();

        private BackgroundWorker _bwResize = new BackgroundWorker();

        private bool _flgRecordLoaded = false;

        private Burningimage _mw = new Burningimage();

        private List<DirectoryItem> _lstDir = new List<DirectoryItem>();

        private List<BurnOrderElements> _objBurnOrderDetails = new List<BurnOrderElements>();

        private string _defaultEffect = "<image brightness=\"0\" contrast=\"1\" Crop=\"##\" colourvalue=\"##\" rotate=\"##\"><effects sharpen=\"##\" greyscale=\"0\" digimagic=\"0\" sepia=\"0\" defog=\"0\" underwater=\"0\" emboss=\"0\" invert=\"0\" granite=\"0\" hue=\"##\" cartoon=\"0\" /></image>";

        private string _defaultSpecPrintLayer = "<photo zoomfactor=\"1\" border=\"\" bg=\"\" canvasleft=\"-1\" canvastop=\"-1\" scalecentrex=\"-1\" scalecentrey=\"-1\" />";

        private int productId = 0;

        private List<BurnOrderInfo> listOfItems;


        public BurnMediaOrderList()
        {
            this.InitializeComponent();
            this._bwBurn.DoWork += new DoWorkEventHandler(this.bwBurn_DoWork);
            this._bwBurn.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwBurn_RunWorkerCompleted);
            this._backgroundBurnWorker.DoWork += new DoWorkEventHandler(this.backgroundBurnWorker_DoWork);
            this._backgroundBurnWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.backgroundBurnWorker_RunWorkerCompleted);
            this._bwResize.DoWork += new DoWorkEventHandler(this.bwResize_DoWork);
            this._bwResize.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bwResize_RunWorkerCompleted);
            this.burnLoadimage();
            this._isActiveStockShot = new TaxBusiness().getTaxConfigData().IsActiveStockShot;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            do
            {
                try
                {
                    if (8 != 0)
                    {
                        this.LoadBurnOrders();
                    }
                IL_09:
                    if (false)
                    {
                        goto IL_09;
                    }
                }
                catch (Exception serviceException)
                {
                    do
                    {
                        ErrorHandler.ErrorHandler.LogError(serviceException);
                    }
                    while (false);
                }
            }
            while (false);
        }

        private void GetPendingBurnOrderDetails(bool all)
        {
            this._objBurnOrderDetails = new List<BurnOrderElements>();
            try
            {
                List<BurnOrderInfo> pendingBurnOrders = new OrderBusiness().GetPendingBurnOrders(all);
                List<BurnOrderInfo>.Enumerator expr_1A9 = pendingBurnOrders.GetEnumerator();
                List<BurnOrderInfo>.Enumerator enumerator;
                if (!false)
                {
                    enumerator = expr_1A9;
                }
                try
                {
                    while (enumerator.MoveNext())
                    {
                        BurnOrderInfo current = enumerator.Current;
                        if (3 == 0)
                        {
                            goto IL_BE;
                        }
                        int arg_82_0;
                        int arg_82_1;
                        bool arg_88_0;
                        if (this.isLocalOrder(current.OrderNumber, current.ProductType))
                        {
                            if (4 != 0)
                            {
                                int arg_73_0 = current.Status;
                                while (arg_73_0 != 0)
                                {
                                    arg_82_0 = (arg_73_0 = ((current.Status == 2) ? 1 : 0));
                                    if (8 != 0)
                                    {
                                        arg_82_1 = 0;
                                        goto IL_82;
                                    }
                                }
                                arg_88_0 = false;
                                goto IL_87;
                            }
                            goto IL_118;
                        }
                        continue;
                        continue;
                    IL_132:
                        BurnOrderElements burnOrderElements;
                        this._objBurnOrderDetails.Add(burnOrderElements);
                        if (8 != 0)
                        {
                            continue;
                        }
                        goto IL_128;
                    IL_F8:
                        bool flag;
                        if (!flag)
                        {
                            burnOrderElements.IsBurnEnable1 = false;
                            burnOrderElements.IsBurnVisible1 = Visibility.Collapsed;
                            burnOrderElements.IsDisableBurnVisible1 = Visibility.Visible;
                            goto IL_132;
                        }
                        goto IL_118;
                    IL_87:
                        flag = arg_88_0;
                        if (flag)
                        {
                            continue;
                        }
                        burnOrderElements = new BurnOrderElements();
                        burnOrderElements.BurnOrderNumber1 = current.OrderNumber;
                        if (!false)
                        {
                            burnOrderElements.Status1 = Convert.ToString((BurnMediaOrderList.StatusCode)current.Status);
                            goto IL_BE;
                        }
                        goto IL_F8;
                    IL_82:
                        arg_88_0 = (arg_82_0 == arg_82_1);
                        goto IL_87;
                    IL_BE:
                        burnOrderElements.BurnKey1 = (long)current.OrderDetailId;
                        burnOrderElements.MediaType1 = Convert.ToString((BurnMediaOrderList.ProductCode)current.ProductType);
                        bool arg_F6_0;
                        int expr_EB = arg_82_0 = ((arg_F6_0 = (current.Status == 1)) ? 1 : 0);
                        if (!false)
                        {
                            int expr_F1 = arg_82_1 = 0;
                            if (expr_F1 != 0)
                            {
                                goto IL_82;
                            }
                            arg_F6_0 = (expr_EB == expr_F1);
                        }
                        flag = arg_F6_0;
                        goto IL_F8;
                    IL_128:
                        burnOrderElements.IsDisableBurnVisible1 = Visibility.Collapsed;
                        goto IL_132;
                    IL_118:
                        burnOrderElements.IsBurnEnable1 = true;
                        burnOrderElements.IsBurnVisible1 = Visibility.Visible;
                        goto IL_128;
                    }
                }
                finally
                {
                    ((IDisposable)enumerator).Dispose();
                }
                this.DGBurnOrders.ItemsSource = this._objBurnOrderDetails;
                this._flgRecordLoaded = true;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
        }

        private void ProcessUSBOrderDetails(int boId, int productId)
        {
            string expr_01 = string.Empty;
            if (false)
            {
            }
            string arg_1B7_0 = string.Empty;
            BurnOrderElements.isExecuting = true;
            PhotoBusiness photoBusiness = new PhotoBusiness();
            try
            {
                try
                {
                    List<BurnOrderInfo> expr_184 = new OrderBusiness().GetBODetails(boId);
                    List<BurnOrderInfo> list;
                    if (6 != 0)
                    {
                        list = expr_184;
                    }
                    if (list != null)
                    {
                        string orderNumber = list.First<BurnOrderInfo>().OrderNumber;
                        string photosId = list.First<BurnOrderInfo>().PhotosId;
                        int num;
                        int expr_128;
                        while (true)
                        {
                        IL_6D:
                            string[] array = photosId.Split(new char[]
							{
								','
							});
                            if (!false)
                            {
                                List<PhotoDetail> photoDetailsByPhotoIds = photoBusiness.GetPhotoDetailsByPhotoIds(list.First<BurnOrderInfo>().PhotosId);
                                bool flag = array.Length <= 0;
                                int arg_A9_0 = flag ? 1 : 0;
                                while (arg_A9_0 == 0)
                                {
                                    num = this.ExecuteUSBOrder(orderNumber, array, photoDetailsByPhotoIds);
                                    if (num == 0 || num == 3)
                                    {
                                        goto IL_EF;
                                    }
                                    int arg_F1_0 = new OrderBusiness().UpdateBurnOrderStatus(boId, num, LoginUser.UserId, new CustomBusineses().ServerDateTime()) ? 1 : 0;
                                    if (2 == 0)
                                    {
                                        goto IL_121;
                                    }
                                    if (6 != 0)
                                    {
                                        goto IL_EF;
                                    }
                                IL_128:
                                    expr_128 = (arg_A9_0 = num);
                                    if (!false)
                                    {
                                        goto Block_13;
                                    }
                                    continue;
                                IL_F0:
                                    flag = (arg_F1_0 != 1);
                                    if (false)
                                    {
                                        goto IL_6D;
                                    }
                                    if (flag)
                                    {
                                        goto IL_128;
                                    }
                                    this._msg = "USB: Order " + orderNumber + " processed successfully!";
                                    arg_F1_0 = (this.DeleteOrder(orderNumber, productId) ? 1 : 0);
                                IL_121:
                                    if (2 != 0)
                                    {
                                        break;
                                    }
                                    goto IL_F0;
                                IL_EF:
                                    arg_F1_0 = num;
                                    goto IL_F0;
                                }
                                break;
                            }
                        }
                        goto IL_16F;
                    Block_13:
                        if (expr_128 == 2)
                        {
                            this._msg = "USB: Order " + orderNumber + " failed!";
                        }
                        else if (num == 3)
                        {
                            this._msg = "No USB drive found!";
                        }
                    IL_16F: ;
                    }
                }
                catch (Exception serviceException)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (false)
                {
                }
            }
            finally
            {
            }
        }

        private void bwResize_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            while (8 != 0)
            {
                if (e.Result != null)
                {
                    if (!false)
                    {
                        object result = e.Result;
                        if (!false)
                        {
                            this._backgroundBurnWorker.RunWorkerAsync(result);
                        }
                    }
                }
                else
                {
                    if (false)
                    {
                        continue;
                    }
                    if (!false)
                    {
                        this.BurnEnd();
                        return;
                    }
                }
                break;
            }
        }

        private void bwResize_DoWork(object sender, DoWorkEventArgs e)
        {
            int ord;
            string proCode;
            do
            {
                string[] array = e.Argument.ToString().Split(new char[]
				{
					'#'
				});
                ord = Convert.ToInt32(array[0]);
                if (!false)
                {
                    this.productId = Convert.ToInt32(array[1]);
                }
                proCode = (from o in this.listOfItems
                           where o.OrderDetailId == ord
                           select o).FirstOrDefault<BurnOrderInfo>().OrderNumber;
            }
            while (5 == 0);
            List<BurnOrderInfo> list = this.listOfItems.Where(delegate(BurnOrderInfo o)
            {
                int expr_37;
                while (true)
                {
                    bool arg_0D_0 = o.OrderNumber == proCode;
                    while (true)
                    {
                        int arg_18_0;
                        int arg_64_0;
                        if (arg_0D_0)
                        {
                            if (6 == 0)
                            {
                                goto IL_37;
                            }
                            arg_18_0 = o.ProductType;
                        }
                        else
                        {
                            if (7 != 0)
                            {
                                arg_64_0 = 0;
                                goto IL_32;
                            }
                            break;
                        }
                    IL_16:
                        if (arg_18_0 != 96)
                        {
                            int expr_5D = arg_64_0 = o.ProductType;
                            if (!false)
                            {
                                arg_64_0 = ((arg_0D_0 = (expr_5D == 35)) ? 1 : 0);
                                if (-1 == 0)
                                {
                                    continue;
                                }
                            }
                        }
                        else
                        {
                            arg_64_0 = 1;
                        }
                        goto IL_32;
                    IL_37:
                        bool flag2;
                        expr_37 = (arg_18_0 = (flag2 ? 1 : 0));
                        if (!false)
                        {
                            return expr_37 != 0;
                        }
                        goto IL_16;
                    IL_32:
                        flag2 = (arg_64_0 != 0);
                        goto IL_37;
                    }
                }
                return expr_37 != 0;
            }).ToList<BurnOrderInfo>();
            using (List<BurnOrderInfo>.Enumerator enumerator = list.GetEnumerator())
            {
                do
                {
                    bool flag = enumerator.MoveNext();
                    if (!false)
                    {
                        if (!flag)
                        {
                            break;
                        }
                        BurnOrderInfo current = enumerator.Current;
                        e.Result = this.ProcessCDOrderDetails(current.OrderDetailId, current.ProductType);
                    }
                }
                while (!false);
            }
            while (3 == 0)
            {
            }
        }

        private object ProcessCDOrderDetails(int boId, int productId)
        {
            object result = null;
            BurnOrderElements.isExecuting = true;
            string arg_149_0 = string.Empty;
            string arg_14F_0 = string.Empty;
            try
            {
                List<BurnOrderInfo> bODetails = new OrderBusiness().GetBODetails(boId);
                if (bODetails != null)
                {
                    string orderNumber;
                    string[] array;
                    PhotoBusiness photoBusiness;
                    while (true)
                    {
                        orderNumber = bODetails.First<BurnOrderInfo>().OrderNumber;
                        string photosId = bODetails.First<BurnOrderInfo>().PhotosId;
                        bool flag;
                        while (true)
                        {
                            array = photosId.Split(new char[]
							{
								','
							});
                            if (array.Length <= 0)
                            {
                                goto IL_E5;
                            }
                            if (5 == 0)
                            {
                                break;
                            }
                            flag = !this.CheckCDAvailable();
                            if (3 != 0)
                            {
                                goto Block_5;
                            }
                        }
                    IL_A3:
                        photoBusiness = new PhotoBusiness();
                        if (!false)
                        {
                            break;
                        }
                        continue;
                    Block_5:
                        if (!flag)
                        {
                            goto IL_A3;
                        }
                        goto IL_D7;
                    }
                    List<PhotoDetail> photoDetailsByPhotoIds = photoBusiness.GetPhotoDetailsByPhotoIds(bODetails.First<BurnOrderInfo>().PhotosId);
                    result = this.ExecuteCDOrder(boId, orderNumber, array, photoDetailsByPhotoIds, productId);
                    goto IL_E4;
                IL_D7:
                    this._msg = "No CD drive found!";
                IL_E4: ;
                }
            IL_E5:
                if (3 == 0)
                {
                    goto IL_E5;
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
                this._msg = "Error processing the order!";
            }
            finally
            {
            }
            return result;
        }

        private string getProdType(int boId)
        {
            if (3 != 0)
            {
            }
            string text = string.Empty;
            string result;
            try
            {
                List<BurnOrderInfo> bODetails = new OrderBusiness().GetBODetails(boId);
                bool flag = bODetails == null;
                int arg_20_0;
                BurnMediaOrderList.ProductCode arg_32_0 = (BurnMediaOrderList.ProductCode)(arg_20_0 = (flag ? 1 : 0));
                while (true)
                {
                    if (!false)
                    {
                        if (arg_20_0 == 0)
                        {
                            goto IL_23;
                        }
                        break;
                    }
                IL_2F:
                    if (false)
                    {
                        continue;
                    }
                    text = Convert.ToString(arg_32_0);
                    if (!false)
                    {
                        break;
                    }
                IL_23:
                    arg_32_0 = (BurnMediaOrderList.ProductCode)(arg_20_0 = bODetails.First<BurnOrderInfo>().ProductType);
                    goto IL_2F;
                }
                result = text;
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
                if (!false)
                {
                }
                result = text;
            }
            return result;
        }

        private int ExecuteUSBOrder(string ordNumber, string[] ordList, List<PhotoDetail> photoList)
        {
            int num;
            if (!false)
            {
                bool flag = false;
                num = 0;
                try
                {
                    while (true)
                    {
                    IL_14:
                        DriveInfo[] drives = DriveInfo.GetDrives();
                        while (true)
                        {
                            string text = string.Empty;
                            DriveInfo[] array = drives;
                            for (int i = 0; i < array.Length; i++)
                            {
                                DriveInfo driveInfo = array[i];
                                if (driveInfo.IsReady && driveInfo.DriveType == DriveType.Removable && driveInfo.DriveFormat == "FAT32")
                                {
                                    if (false)
                                    {
                                        goto IL_14;
                                    }
                                    text = driveInfo.RootDirectory.ToString();
                                    flag = true;
                                }
                            }
                            if (-1 != 0 && !flag)
                            {
                                goto Block_10;
                            }
                            using (List<PhotoDetail>.Enumerator enumerator = photoList.GetEnumerator())
                            {
                                if (!false)
                                {
                                    while (enumerator.MoveNext())
                                    {
                                        PhotoDetail current = enumerator.Current;
                                        object[] array2 = new object[]
										{
											current,
											text
										};
                                        object[] array3;
                                        do
                                        {
                                            array3 = array2;
                                        }
                                        while (7 == 0);
                                        BurnMediaOrderList.UpdateDelegate method = new BurnMediaOrderList.UpdateDelegate(this.StartEngine);
                                        base.Dispatcher.Invoke(method, new object[]
										{
											array3
										});
                                    }
                                }
                            }
                            if (!false)
                            {
                                goto Block_12;
                            }
                        }
                    }
                Block_10:
                    num = 3;
                    goto IL_13B;
                Block_12:
                    num = 1;
                IL_13B: ;
                }
                catch (Exception serviceException)
                {
                    num = 2;
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
            }
            int result;
            do
            {
                result = num;
            }
            while (7 == 0);
            return result;
        }

        private void PrepareImage(PhotoInfo _objphoto, string destinationPath)
        {
            bool expr_07 = _objphoto == null;
            bool flag;
            if (-1 != 0)
            {
                flag = expr_07;
            }
            if (false)
            {
                goto IL_77;
            }
            if (flag)
            {
                goto IL_6A;
            }
            bool arg_37_0;
            bool expr_112 = arg_37_0 = string.IsNullOrEmpty(_objphoto.DG_Photos_Effects);
            if (false)
            {
                goto IL_37;
            }
            flag = expr_112;
        IL_32:
            arg_37_0 = flag;
        IL_37:
            if (!arg_37_0)
            {
                this._mw.ImageEffect = _objphoto.DG_Photos_Effects;
            }
            else
            {
                this._mw.ImageEffect = "<image brightness = '0' contrast = '1' Crop='##' colourvalue = '##' rotate='##' ><effects sharpen='##' greyscale='0' digimagic='0' sepia='0' defog='0' underwater='0' emboss='0' invert = '0' granite='0' hue ='##' cartoon = '0'></effects></image>";
            }
        IL_66:
            if (false)
            {
                goto IL_83;
            }
        IL_6A:
            this._mw.WindowStyle = WindowStyle.None;
        IL_77:
            this._mw.ResetForm(_objphoto);
        IL_83:
            if (7 == 0)
            {
                goto IL_66;
            }
            this._mw.UpdateLayout();
            RenderTargetBitmap source;
            do
            {
                source = this._mw.jCaptureScreen();
            }
            while (-1 == 0);
            FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.ReadWrite);
            try
            {
                new JpegBitmapEncoder
                {
                    QualityLevel = 94,
                    Frames = 
					{
						BitmapFrame.Create(source)
					}
                }.Save(fileStream);
            }
            finally
            {
                flag = (fileStream == null);
                if (!flag)
                {
                    ((IDisposable)fileStream).Dispose();
                }
            }
            if (!false)
            {
                return;
            }
            goto IL_32;
        }

        private bool IsEffectApplied(PhotoInfo _objphoto)
        {
            int arg_AD_0;
            int arg_4F_0;
            if (!string.IsNullOrEmpty(_objphoto.DG_Photos_Effects))
            {
                int expr_101 = arg_AD_0 = string.Compare(_objphoto.DG_Photos_Effects, this._defaultEffect.TrimStart(new char[0]).TrimEnd(new char[0]), true);
                if (false)
                {
                    goto IL_AD;
                }
                arg_4F_0 = ((expr_101 != 0) ? 1 : 0);
            }
            else
            {
                arg_4F_0 = 0;
            }
            bool flag;
            bool expr_53;
            do
            {
                flag = (arg_4F_0 != 0);
                if (4 == 0)
                {
                    goto IL_B7;
                }
                expr_53 = ((arg_4F_0 = (flag ? 1 : 0)) != 0);
            }
            while (false);
            if (expr_53)
            {
                goto IL_B7;
            }
            flag = (!string.IsNullOrEmpty(_objphoto.DG_Photos_Layering) && !(_objphoto.DG_Photos_Layering == "test") && string.Compare(_objphoto.DG_Photos_Layering, this._defaultSpecPrintLayer.TrimStart(new char[0]).TrimEnd(new char[0]), true) != 0);
            arg_AD_0 = (flag ? 1 : 0);
        IL_AD:
            bool result;
            if (arg_AD_0 == 0)
            {
                result = false;
                if (!false)
                {
                    return result;
                }
                return result;
            }
        IL_B7:
            result = true;
            return result;
        }

        private bool IsEffectApplied(PhotoDetail photoDetail)
        {
            int arg_AD_0;
            int arg_4F_0;
            if (!string.IsNullOrEmpty(photoDetail.Effects))
            {
                int expr_101 = arg_AD_0 = string.Compare(photoDetail.Effects, this._defaultEffect.TrimStart(new char[0]).TrimEnd(new char[0]), true);
                if (false)
                {
                    goto IL_AD;
                }
                arg_4F_0 = ((expr_101 != 0) ? 1 : 0);
            }
            else
            {
                arg_4F_0 = 0;
            }
            bool flag;
            bool expr_53;
            do
            {
                flag = (arg_4F_0 != 0);
                if (4 == 0)
                {
                    goto IL_B7;
                }
                expr_53 = ((arg_4F_0 = (flag ? 1 : 0)) != 0);
            }
            while (false);
            if (expr_53)
            {
                goto IL_B7;
            }
            flag = (!string.IsNullOrEmpty(photoDetail.Layering) && !(photoDetail.Layering == "test") && string.Compare(photoDetail.Layering, this._defaultSpecPrintLayer.TrimStart(new char[0]).TrimEnd(new char[0]), true) != 0);
            arg_AD_0 = (flag ? 1 : 0);
        IL_AD:
            bool result;
            if (arg_AD_0 == 0)
            {
                result = false;
                if (!false)
                {
                    return result;
                }
                return result;
            }
        IL_B7:
            result = true;
            return result;
        }

        private void StartEngine(object[] x)
        {
            try
            {
                PhotoDetail photoDetail = null;
                string text;
                if (6 != 0)
                {
                    text = x[1].ToString();
                    if (!Directory.Exists(text))
                    {
                        if (false)
                        {
                            goto IL_327;
                        }
                        Directory.CreateDirectory(text);
                    }
                    if (x[0] != null)
                    {
                        photoDetail = (PhotoDetail)x[0];
                    }
                    this._mw.PhotoName = photoDetail.PhotoRFID;
                    this._mw.PhotoId = photoDetail.PhotoId;
                    string text2 = Path.Combine(photoDetail.HotFolderPath, "EditedImages", photoDetail.FileName);
                    if (!false)
                    {
                        if (!string.IsNullOrEmpty(text))
                        {
                            bool arg_131_0;
                            bool arg_12B_0;
                            int arg_12B_1;
                            if (photoDetail.MediaType == 1)
                            {
                                if (!File.Exists(text2))
                                {
                                    goto IL_CF;
                                }
                                if (File.Exists(text2))
                                {
                                    arg_131_0 = true;
                                    goto IL_130;
                                }
                                arg_12B_0 = this.IsEffectApplied(photoDetail);
                                arg_12B_1 = 0;
                            }
                            else
                            {
                                int expr_1F2 = (arg_12B_0 = (photoDetail.MediaType == 2)) ? 1 : 0;
                                int expr_1F5 = arg_12B_1 = 0;
                                if (expr_1F5 == 0)
                                {
                                    if (expr_1F2 != expr_1F5)
                                    {
                                        string fileName = photoDetail.FileName;
                                        if (!File.Exists(Path.Combine(text, photoDetail.PhotoId + Path.GetExtension(photoDetail.FileName))))
                                        {
                                            File.Copy(Path.Combine(photoDetail.HotFolderPath, "Videos", photoDetail.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoDetail.FileName), Path.Combine(text, photoDetail.PhotoId + Path.GetExtension(photoDetail.FileName)), true);
                                        }
                                        goto IL_328;
                                    }
                                    if (photoDetail.MediaType != 3)
                                    {
                                        goto IL_328;
                                    }
                                    if (!File.Exists(Path.Combine(text, photoDetail.PhotoId + Path.GetExtension(photoDetail.FileName))))
                                    {
                                        File.Copy(Path.Combine(photoDetail.HotFolderPath, "ProcessedVideos", photoDetail.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoDetail.FileName), Path.Combine(text, photoDetail.PhotoId + Path.GetExtension(photoDetail.FileName)), true);
                                        goto IL_327;
                                    }
                                    goto IL_327;
                                }
                            }
                            arg_131_0 = ((arg_12B_0 ? 1 : 0) == arg_12B_1);
                        IL_130:
                            if (!arg_131_0)
                            {
                                PhotoInfo photoDetailsbyPhotoId = new PhotoBusiness().GetPhotoDetailsbyPhotoId(photoDetail.PhotoId);
                                this.PrepareImage(photoDetailsbyPhotoId, text + photoDetail.PhotoId + ".jpg");
                            }
                            else if (File.Exists(text2))
                            {
                                File.Copy(text2, Path.Combine(text, photoDetail.PhotoId + ".jpg"), true);
                            }
                            else
                            {
                                File.Copy(Path.Combine(photoDetail.HotFolderPath, photoDetail.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoDetail.FileName), Path.Combine(text, photoDetail.PhotoId + ".jpg"), true);
                            }
                        }
                    }
                IL_327:
                    goto IL_328;
                }
            IL_CF:
                File.Copy(Path.Combine(photoDetail.HotFolderPath, photoDetail.DG_Photos_CreatedOn.ToString("yyyyMMdd"), photoDetail.FileName), Path.Combine(text, photoDetail.PhotoId + ".jpg"));
            IL_328:
                this.WriteStockShotImages(text);
            }
            catch (Exception serviceException)
            {
                string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                ErrorHandler.ErrorHandler.LogFileWrite(message);
            }
            while (false)
            {
            }
        }

        private object ExecuteCDOrder(int ordId, string ordNumber, string[] OrdList, List<PhotoDetail> photoList, int productId)
        {
            object result;
            try
            {
                string text = Environment.CurrentDirectory + "\\DigiOrderdImages\\CDOrders\\" + ordNumber + "\\";
                string arg_18E_0 = string.Empty;
                bool expr_34 = productId != 35;
                bool flag;
                if (!false)
                {
                    flag = expr_34;
                }
                string text2;
                if (!flag)
                {
                    text2 = text + "CD\\";
                }
                else
                {
                    text2 = text + "VideoCD\\";
                }
                using (List<PhotoDetail>.Enumerator enumerator = photoList.GetEnumerator())
                {
                    while (true)
                    {
                        flag = enumerator.MoveNext();
                        if (!flag)
                        {
                            break;
                        }
                        PhotoDetail current = enumerator.Current;
                        object[] array = new object[]
						{
							current,
							text2
						};
                        BurnMediaOrderList.UpdateDelegate method = new BurnMediaOrderList.UpdateDelegate(this.StartEngine);
                        base.Dispatcher.Invoke(method, new object[]
						{
							array
						});
                    }
                }
                this._burnData = new BurnData();
                this._lstDir = new List<DirectoryItem>();
                DirectoryItem item = new DirectoryItem(text);
                this._lstDir.Add(item);
                this.UpdateCapacity();
                this._isBurning = true;
                int index = this._lstmain.Count<MsftDiscRecorder2>() - 1;
                IDiscRecorder2 discRecorder = this._lstmain[index];
                this._burnData.uniqueRecorderId = discRecorder.ActiveDiscRecorder;
                this._burnData.BOID = ordId;
                this._burnData.ORDERNUMBER = ordNumber;
                BurnData burnData = this._burnData;
                result = burnData;
            }
            catch (Exception serviceException)
            {
                string message = string.Concat(new object[]
				{
					"lstmain.Count()",
					this._lstmain.Count<MsftDiscRecorder2>(),
					", ",
					ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException)
				});
                ErrorHandler.ErrorHandler.LogFileWrite(message);
                result = null;
            }
            return result;
        }

        private void WriteStockShotImages(string OrdPath)
        {
            if (4 != 0)
            {
                try
                {
                    if (this._isActiveStockShot)
                    {
                        if (!false)
                        {
                        }
                        using (IEnumerator<StockShot> enumerator = (from x in new ConfigBusiness().GetStockShotImagesList(0L)
                                                                    where x.IsActive
                                                                    select x).GetEnumerator())
                        {
                            if (8 != 0)
                            {
                            }
                        IL_BB:
                        IL_BC:
                            bool arg_8E_0;
                            bool expr_BF = arg_8E_0 = enumerator.MoveNext();
                            StockShot current;
                            string text;
                            if (-1 != 0)
                            {
                                if (!expr_BF)
                                {
                                    goto IL_EA;
                                }
                                current = enumerator.Current;
                                text = Path.Combine(LoginUser.DigiFolderPath, "StockShot", current.ImageName);
                                arg_8E_0 = File.Exists(text);
                            }
                            if (arg_8E_0)
                            {
                                try
                                {
                                    if (8 == 0)
                                    {
                                        goto IL_AE;
                                    }
                                IL_9B:
                                    File.Copy(text, Path.Combine(OrdPath, current.ImageName), true);
                                IL_AE:
                                    if (false)
                                    {
                                        goto IL_9B;
                                    }
                                }
                                catch
                                {
                                }
                                goto IL_BB;
                            }
                            goto IL_BC;
                        }
                    IL_EA: ;
                    }
                }
                catch (Exception serviceException)
                {
                    string message = ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                    ErrorHandler.ErrorHandler.LogFileWrite(message);
                }
            }
        }

        private void backgroundBurnWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            do
            {
                bool flag = string.IsNullOrEmpty(this._cdOrderSuccess);
                while (true)
                {
                    if (false)
                    {
                        goto IL_47;
                    }
                    if (flag)
                    {
                        goto IL_3A;
                    }
                IL_13:
                    if (!false)
                    {
                        if (-1 != 0)
                        {
                            this.DeleteOrder(this._cdOrderSuccess, this.productId);
                        }
                        this._cdOrderSuccess = string.Empty;
                        goto IL_3A;
                    }
                    continue;
                IL_47:
                    if (4 != 0)
                    {
                        break;
                    }
                    goto IL_13;
                IL_3A:
                    this.LoadBurnOrders();
                    this.BurnEnd();
                    goto IL_47;
                }
            }
            while (false);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            base.Hide();
        }

        private void btnAuto_Click(object sender, RoutedEventArgs e)
        {
            this._isAutoStart = true;
            this.AutoExecuteOrders();
        }

        public void LoadBurnOrders()
        {
            this.UpdateVOS();
            this.GetPendingBurnOrderDetails(true);
        }

        private void btnBurnMedia_Click(object sender, RoutedEventArgs e)
        {
            this.BurnStart(string.Empty);
            Button button = (Button)sender;
            int num = button.Tag.ToInt32(false);
            if (this.getProdType(num) == BurnMediaOrderList.ProductCode.USB.ToString() || this.getProdType(num) == BurnMediaOrderList.ProductCode.VideoUSB.ToString())
            {
                if (this.getProdType(num) == BurnMediaOrderList.ProductCode.USB.ToString())
                {
                    this._bwBurn.RunWorkerAsync(num + "# " + 36);
                }
                else
                {
                    this._bwBurn.RunWorkerAsync(num + "#" + 97);
                }
            }
            else
            {
                this.burnLoadimage();
                bool flag = !(this.getProdType(num) == BurnMediaOrderList.ProductCode.CD.ToString());
                while (flag)
                {
                    if (8 != 0)
                    {
                        this._bwResize.RunWorkerAsync(num + "#" + 96);
                        return;
                    }
                }
                this._bwResize.RunWorkerAsync(num + "#" + 35);
            }
        }

        public void AutoExecuteOrders()
        {
            if (!false)
            {
                BurnOrderElements.isExecuting = true;
                bool flag = this.ExecuteNextOrder();
                do
                {
                    bool flag2 = flag;
                    if (8 == 0)
                    {
                        goto IL_51;
                    }
                    if (flag2)
                    {
                        return;
                    }
                    do
                    {
                        this.msgBurn.Text = "No pending orders found!";
                        if (-1 == 0)
                        {
                            return;
                        }
                    }
                    while (false);
                    MessageBox.Show("No pending orders found!", "iMIX", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    this._isAutoStart = false;
                }
                while (false);
                BurnOrderElements.isExecuting = false;
            IL_51: ;
            }
        }

        private bool ExecuteNextOrder()
        {
            bool result;
            while (true)
            {
                result = false;
                int num = 0;
                this.listOfItems = new OrderBusiness().GetPendingBurnOrders(true);
                while (true)
                {
                    foreach (BurnOrderInfo current in this.listOfItems)
                    {
                        if (!false)
                        {
                            bool flag = current.Status == 1;
                            int arg_58_0 = flag ? 1 : 0;
                            while (arg_58_0 == 0)
                            {
                                if (true)
                                {
                                    if (!this.isLocalOrder(current.OrderNumber, current.ProductType))
                                    {
                                        break;
                                    }
                                    result = true;
                                    num = current.OrderDetailId;
                                    this.BurnStart(current.OrderNumber);
                                    int arg_101_0;
                                    int arg_BA_0;
                                    int arg_101_1;
                                    if (current.ProductType != 36)
                                    {
                                        int expr_AB = arg_BA_0 = (arg_101_0 = ((current.ProductType == 97) ? 1 : 0));
                                        if (!false)
                                        {
                                            int expr_B1 = arg_101_1 = 0;
                                            if (expr_B1 != 0)
                                            {
                                                goto IL_101;
                                            }
                                            arg_BA_0 = ((expr_AB == expr_B1) ? 1 : 0);
                                        }
                                    }
                                    else
                                    {
                                        arg_BA_0 = 0;
                                    }
                                    if (arg_BA_0 == 0)
                                    {
                                        this._bwBurn.RunWorkerAsync(num + "#" + current.ProductType);
                                        goto IL_E6;
                                    }
                                    bool arg_10A_0;
                                    if (current.ProductType == 35)
                                    {
                                        arg_10A_0 = false;
                                        goto IL_109;
                                    }
                                    arg_101_0 = (arg_58_0 = current.ProductType);
                                    if (8 == 0)
                                    {
                                        continue;
                                    }
                                    arg_101_1 = 96;
                                IL_101:
                                    arg_10A_0 = (arg_101_0 != arg_101_1);
                                IL_109:
                                    if (!arg_10A_0)
                                    {
                                        goto IL_110;
                                    }
                                }
                            IL_E6:
                                goto IL_140;
                            }
                            continue;
                        }
                    IL_110:
                        this.burnLoadimage();
                        this._bwResize.RunWorkerAsync(num + "#" + current.ProductType);
                    IL_140:
                        break;
                    }
                    if (false)
                    {
                        break;
                    }
                    if (!false)
                    {
                        return result;
                    }
                }
            }
            return result;
        }

        public string FetchNextOrderDetails()
        {
            string text = "\r\nNo active orders found!";
            string str = string.Empty;
            string a = string.Empty;
            List<BurnOrderInfo> pendingBurnOrders = new OrderBusiness().GetPendingBurnOrders(true);
            string result;
            do
            {
                using (List<BurnOrderInfo>.Enumerator enumerator = pendingBurnOrders.GetEnumerator())
                {
                    while (true)
                    {
                        if (!enumerator.MoveNext())
                        {
                            goto IL_124;
                        }
                        BurnOrderInfo current = enumerator.Current;
                        bool arg_5B_0 = current.Status == 1;
                        goto IL_5B;
                        continue;
                    IL_5D:
                        bool flag;
                        bool arg_E0_0;
                        bool expr_5D = arg_5B_0 = (arg_E0_0 = flag);
                        if (7 == 0)
                        {
                            goto IL_DA;
                        }
                        int arg_83_0;
                        if (!expr_5D)
                        {
                            flag = !this.isLocalOrder(current.OrderNumber, current.ProductType);
                            arg_83_0 = (flag ? 1 : 0);
                            goto IL_83;
                        }
                        continue;
                    IL_5B:
                        flag = arg_5B_0;
                        goto IL_5D;
                        continue;
                    IL_A3:
                        bool arg_D6_0;
                        if (!(a == BurnMediaOrderList.ProductCode.USB.ToString()))
                        {
                            arg_D6_0 = ((arg_83_0 = ((!(a == BurnMediaOrderList.ProductCode.VideoUSB.ToString())) ? 1 : 0)) != 0);
                        }
                        else
                        {
                            if (8 == 0)
                            {
                                continue;
                            }
                            arg_D6_0 = ((arg_83_0 = 0) != 0);
                        }
                        if (3 != 0)
                        {
                            flag = arg_D6_0;
                            arg_E0_0 = (arg_5B_0 = flag);
                            goto IL_DA;
                        }
                    IL_83:
                        if (arg_83_0 == 0)
                        {
                            str = current.OrderNumber;
                            a = Convert.ToString((BurnMediaOrderList.ProductCode)current.ProductType);
                            goto IL_A3;
                        }
                        continue;
                    IL_DA:
                        if (7 == 0)
                        {
                            goto IL_5B;
                        }
                        if (!arg_E0_0)
                        {
                            text = "\r\nWould you like to continue processing orders?\r\nNext order in the queue is Order Number " + str + " of type USB.\r\nPlease ensure that a USB drive is plugged in before pressing YES";
                        }
                        else
                        {
                            if (false)
                            {
                                goto IL_5D;
                            }
                            text = "\r\nWould you like to continue processing orders?\r\nNext order in the queue is Order Number " + str + " of type CD.\r\nPlease ensure that a fresh CD is inserted before pressing YES";
                        }
                    IL_124:
                        if (!false)
                        {
                            break;
                        }
                        goto IL_A3;
                    }
                }
                result = text;
            }
            while (false);
            return result;
        }

        private bool DeleteOrder(string orderNumber, int prodType)
		{
			//BurnMediaOrderList expr_196 = new BurnMediaOrderList;
			//BurnMediaOrderList.<>c__DisplayClass7 <>c__DisplayClass;
            //if (8 != 0)
            //{
            //    <>c__DisplayClass = expr_196;
            //}
            //<>c__DisplayClass.orderNumber = orderNumber;
            //<>c__DisplayClass.prodType = prodType;
			List<BurnOrderElements> list = this._objBurnOrderDetails.Where(delegate(BurnOrderElements Ord)
			{
				while (true)
				{
					bool arg_0D_0 = Ord.BurnOrderNumber1 == orderNumber;
					while (arg_0D_0)
					{
						bool expr_65 = arg_0D_0 = (Ord.Status1 == "Pending");
						if (-1 != 0)
						{
							if (expr_65)
							{
								goto Block_2;
							}
							break;
						}
					}
					if (!false)
					{
						goto Block_3;
					}
				}
				Block_2:
				int arg_3F_0 = (Ord.MediaType1 == Convert.ToString((BurnMediaOrderList.ProductCode)prodType)) ? 1 : 0;
				goto IL_3E;
				Block_3:
				arg_3F_0 = 0;
				IL_3E:
				bool expr_42;
				do
				{
					bool flag4 = arg_3F_0 != 0;
					expr_42 = ((arg_3F_0 = (flag4 ? 1 : 0)) != 0);
				}
				while (false);
				return expr_42;
			}).ToList<BurnOrderElements>();
			int arg_51_0 = 0;
			bool arg_195_0;
			bool expr_185;
			do
			{
				bool flag = arg_51_0 != 0;
				try
				{
					bool arg_6C_0;
					if (list.Count == 1)
					{
						arg_6C_0 = false;
						goto IL_6B;
					}
					IL_5C:
					arg_6C_0 = (list.Count != 0);
					IL_6B:
					if (!arg_6C_0)
					{
						string path = string.Empty;
						if (prodType == 35)
						{
							path = Environment.CurrentDirectory + "\\DigiOrderdImages\\CDOrders\\" + orderNumber + "\\CD\\";
						}
						else
						{
							int arg_127_0;
							int expr_B5 = arg_127_0 = prodType;
							int arg_127_1;
							int expr_BC = arg_127_1 = 36;
							if (expr_BC == 0)
							{
								goto IL_127;
							}
							bool arg_C4_0 = expr_B5 != expr_BC;
							IL_C4:
							if (!arg_C4_0)
							{
								path = Environment.CurrentDirectory + "\\DigiOrderdImages\\USBOrders\\" + orderNumber + "\\USB\\";
								goto IL_159;
							}
							if (prodType == 96)
							{
								path = Environment.CurrentDirectory + "\\DigiOrderdImages\\CDOrders\\" + orderNumber + "\\VideoCD\\";
								goto IL_159;
							}
							arg_127_0 = prodType;
							arg_127_1 = 97;
							IL_127:
							bool expr_12A = arg_C4_0 = (arg_127_0 != arg_127_1);
							if (2 == 0)
							{
								goto IL_C4;
							}
							bool flag2 = expr_12A;
							if (4 == 0)
							{
								goto IL_5C;
							}
							if (!flag2)
							{
								path = Environment.CurrentDirectory + "\\DigiOrderdImages\\USBOrders\\" + orderNumber + "\\VideoUSB\\";
							}
						}
						IL_159:
						bool arg_169_0;
						bool expr_15A = arg_169_0 = Directory.Exists(path);
						if (!false)
						{
							bool flag2 = !expr_15A;
							arg_169_0 = flag2;
						}
						if (!arg_169_0)
						{
							flag = true;
						}
					}
				}
				catch (Exception serviceException)
				{
					flag = false;
					ErrorHandler.ErrorHandler.LogError(serviceException);
					if (!false)
					{
					}
				}
				expr_185 = ((arg_51_0 = ((arg_195_0 = flag) ? 1 : 0)) != 0);
			}
			while (-1 == 0);
			if (6 != 0)
			{
				bool flag3 = expr_185;
				arg_195_0 = flag3;
			}
			return arg_195_0;
		}

        private void bwBurn_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (-1 != 0)
                {
                    string[] array = e.Argument.ToString().Split(new char[]
					{
						'#'
					});
                    int ord = Convert.ToInt32(array[0]);
                    int num = Convert.ToInt32(array[1]);
                    string proCode = (from o in this.listOfItems
                                      where o.OrderDetailId == ord
                                      select o).FirstOrDefault<BurnOrderInfo>().OrderNumber;
                    List<BurnOrderInfo> list = this.listOfItems.Where(delegate(BurnOrderInfo o)
                    {
                        int expr_37;
                        while (true)
                        {
                            bool arg_0D_0 = o.OrderNumber == proCode;
                            while (true)
                            {
                                int arg_18_0;
                                int arg_64_0;
                                if (arg_0D_0)
                                {
                                    if (6 == 0)
                                    {
                                        goto IL_37;
                                    }
                                    arg_18_0 = o.ProductType;
                                }
                                else
                                {
                                    if (7 != 0)
                                    {
                                        arg_64_0 = 0;
                                        goto IL_32;
                                    }
                                    break;
                                }
                            IL_16:
                                if (arg_18_0 != 97)
                                {
                                    int expr_5D = arg_64_0 = o.ProductType;
                                    if (!false)
                                    {
                                        arg_64_0 = ((arg_0D_0 = (expr_5D == 36)) ? 1 : 0);
                                        if (-1 == 0)
                                        {
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    arg_64_0 = 1;
                                }
                                goto IL_32;
                            IL_37:
                                bool flag;
                                expr_37 = (arg_18_0 = (flag ? 1 : 0));
                                if (!false)
                                {
                                    return expr_37 != 0;
                                }
                                goto IL_16;
                            IL_32:
                                flag = (arg_64_0 != 0);
                                goto IL_37;
                            }
                        }
                        return expr_37 != 0;
                    }).ToList<BurnOrderInfo>();
                    List<BurnOrderInfo>.Enumerator enumerator = list.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            while (!false)
                            {
                                if (!enumerator.MoveNext())
                                {
                                    goto Block_5;
                                }
                                BurnOrderInfo current = enumerator.Current;
                                do
                                {
                                    this.ProcessUSBOrderDetails(current.OrderDetailId, current.ProductType);
                                }
                                while (5 == 0);
                            }
                        }
                    Block_5: ;
                    }
                    finally
                    {
                        ((IDisposable)enumerator).Dispose();
                        if (2 != 0)
                        {
                        }
                    }
                }
            }
            catch (Exception serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
                if (!false)
                {
                }
            }
            if (6 != 0)
            {
            }
        }

        private void bwBurn_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.LoadBurnOrders();
            this.BurnEnd();
        }

        private bool CheckCDAvailable()
        {
            bool arg_57_0;
            bool flag2;
            while (true)
            {
                DriveInfo[] drives = DriveInfo.GetDrives();
                DriveInfo driveInfo = (from t in drives
                                       where t.DriveType == DriveType.CDRom
                                       select t).FirstOrDefault<DriveInfo>();
                int arg_4D_0;
                bool expr_35 = (arg_4D_0 = ((driveInfo == null) ? 1 : 0)) != 0;
                if (false)
                {
                    goto IL_4D;
                }
                bool flag = expr_35;
            IL_3C:
                bool expr_85 = arg_57_0 = flag;
                if (7 == 0)
                {
                    return arg_57_0;
                }
                if (expr_85)
                {
                    arg_4D_0 = 0;
                    goto IL_4D;
                }
                if (8 == 0)
                {
                    continue;
                }
                flag2 = true;
            IL_53:
                if (!false)
                {
                    break;
                }
                goto IL_3C;
            IL_4D:
                flag2 = (arg_4D_0 != 0);
                if (!false)
                {
                    goto IL_53;
                }
                goto IL_53;
            }
            arg_57_0 = flag2;
            return arg_57_0;
        }

        private bool isLocalOrder(string orderNumber, int prodType)
        {
            string path = "";
            int arg_12_0 = prodType;
            bool expr_E8;
            while (true)
            {
                bool arg_15_0 = arg_12_0 == 35;
                while (true)
                {
                    bool arg_FC_0 = !arg_15_0;
                    bool flag;
                    bool expr_7A=false;
                    while (true)
                    {
                        if (!false)
                        {
                            flag = arg_FC_0;
                        }
                        if (!flag)
                        {
                            goto Block_1;
                        }
                        flag = (prodType != 36);
                        if (!flag)
                        {
                            goto Block_3;
                        }
                        expr_7A = (arg_FC_0 = (prodType == 96));
                        if (6 != 0)
                        {
                            goto Block_4;
                        }
                    }
                    while (true)
                    {
                    IL_CA:
                        flag = !Directory.Exists(path);
                        if (flag)
                        {
                            goto IL_DE;
                        }
                        if (!false)
                        {
                            goto Block_9;
                        }
                    }
                IL_E2:
                    if (false)
                    {
                        goto IL_4B;
                    }
                    bool flag2;
                    expr_E8 = (arg_15_0 = flag2);
                    if (!false)
                    {
                        return expr_E8;
                    }
                    continue;
                Block_9:
                    flag2 = true;
                    goto IL_E2;
                IL_DE:
                    flag2 = false;
                    goto IL_E2;
                IL_4B:
                    //goto IL_CA;
                Block_1:
                    if (!false)
                    {
                        path = Environment.CurrentDirectory + "\\DigiOrderdImages\\CDOrders\\" + orderNumber + "\\CD\\";
                        goto IL_4B;
                    }
                    //goto IL_C9;
                Block_3:
                    path = Environment.CurrentDirectory + "\\DigiOrderdImages\\USBOrders\\" + orderNumber + "\\USB\\";
                    //goto IL_CA;
                Block_4:
                    flag = !expr_7A;
                    if (!flag)
                    {
                        path = Environment.CurrentDirectory + "\\DigiOrderdImages\\CDOrders\\" + orderNumber + "\\VideoCD\\";
                    }
                    else
                    {
                        flag = (prodType != 97);
                        bool expr_A9 = (arg_12_0 = (flag ? 1 : 0)) != 0;
                        if (false)
                        {
                            break;
                        }
                        if (!expr_A9)
                        {
                            path = Environment.CurrentDirectory + "\\DigiOrderdImages\\USBOrders\\" + orderNumber + "\\VideoUSB\\";
                        }
                    }
               // IL_C9:
                    //goto IL_CA;
                }
            }
            return expr_E8;
        }

        private void BurnStart(string orderNumber)
        {
            if (!false && -1 != 0)
            {
                DataGridColumn expr_8F = this.DGBurnOrders.Columns[3];
                Visibility expr_16 = Visibility.Collapsed;
                if (true)
                {
                    expr_8F.Visibility = expr_16;
                }
            }
            do
            {
                this.btnLoadOrders.Visibility = Visibility.Collapsed;
                this.btnAuto.Visibility = Visibility.Collapsed;
                do
                {
                    this.msgBurn.Text = "Processing Order " + orderNumber + "...";
                    while (4 == 0)
                    {
                    }
                    this.msgBurn.Visibility = Visibility.Visible;
                }
                while (5 == 0);
            }
            while (false);
            BurnOrderElements.isExecuting = true;
        }

        private void BurnEnd()
        {
            this.DGBurnOrders.Columns[3].Visibility = Visibility.Visible;
            this.btnLoadOrders.Visibility = Visibility.Visible;
            while (true)
            {
                this.btnAuto.Visibility = Visibility.Visible;
                this.msgBurn.Text = this._msg;
                if (this._isAutoStart)
                {
                    break;
                }
                MessageBox.Show(this._msg, "iMIX", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                if (8 != 0)
                {
                    goto IL_106;
                }
            }
            string text = this.FetchNextOrderDetails();
            if (text == "\r\nNo active orders found!")
            {
                this.msgBurn.Text = text.Replace("\r\n", "");
                MessageBox.Show(this._msg + text, "iMIX", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(this._msg + text, "iMIX", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    this.AutoExecuteOrders();
                }
            }
        IL_106:
            BurnOrderElements.isExecuting = false;
        }

        private void ResizeWPFImage(string sourceImage, int maxHeight, string saveToPath)
        {
            if (8 != 0)
            {
                try
                {
                    BitmapImage bitmapImage = new BitmapImage();
                    BitmapImage bitmapImage2;
                    do
                    {
                        bitmapImage2 = new BitmapImage();
                        FileStream fileStream = File.OpenRead(sourceImage.ToString());
                        try
                        {
                            MemoryStream memoryStream = new MemoryStream();
                            if (5 != 0)
                            {
                                fileStream.CopyTo(memoryStream);
                                memoryStream.Seek(0L, SeekOrigin.Begin);
                                fileStream.Close();
                                bitmapImage.BeginInit();
                                bitmapImage.StreamSource = memoryStream;
                                bitmapImage.EndInit();
                                bitmapImage.Freeze();
                                memoryStream.Seek(0L, SeekOrigin.Begin);
                                bitmapImage2.BeginInit();
                                bitmapImage2.StreamSource = memoryStream;
                                bitmapImage2.DecodePixelWidth = (bitmapImage.PixelWidth * maxHeight / 100).ToInt32(false);
                                bitmapImage2.DecodePixelHeight = (bitmapImage.PixelHeight * maxHeight / 100).ToInt32(false);
                                if (8 == 0)
                                {
                                    goto IL_DF;
                                }
                                bitmapImage2.EndInit();
                            }
                            bitmapImage2.Freeze();
                            fileStream.Close();
                        IL_DF: ;
                        }
                        finally
                        {
                            if (6 != 0 && fileStream != null)
                            {
                                ((IDisposable)fileStream).Dispose();
                            }
                        }
                    }
                    while (false);
                    using (FileStream fileStream2 = new FileStream(saveToPath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        new JpegBitmapEncoder
                        {
                            QualityLevel = 98,
                            Frames = 
							{
								BitmapFrame.Create(bitmapImage2)
							}
                        }.Save(fileStream2);
                        fileStream2.Close();
                    }
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
        IL_1BD:
            if (!false)
            {
                return;
            }
            goto IL_1BD;
        }

        public void burnLoadimage()
        {
            this.AddRecordingDevices();
            MsftDiscMaster2 msftDiscMaster = null;
            this._lstmain = new List<MsftDiscRecorder2>();
            try
            {
                msftDiscMaster = (MsftDiscMaster2)new MsftDiscMaster2Class();
                if (!msftDiscMaster.IsSupportedEnvironment)
                {
                    return;
                }
                if (-1 != 0)
                {
                   // using (IEnumerator enumerator = msftDiscMaster.GetEnumerator())
                    IEnumerator enumerator = msftDiscMaster.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                        IL_55:
                            while (true)
                            {
                            IL_92:
                                bool flag = enumerator.MoveNext();
                            IL_9B:
                                while (flag)
                                {
                                    string recorderUniqueId = (string)enumerator.Current;
                                    MsftDiscRecorder2 msftDiscRecorder;
                                    while (true)
                                    {
                                        while (7 != 0)
                                        {
                                            msftDiscRecorder = (MsftDiscRecorder2)new MsftDiscRecorder2Class();
                                            if (!false)
                                            {
                                                msftDiscRecorder.InitializeDiscRecorder(recorderUniqueId);
                                                if (!false)
                                                {
                                                    goto Block_10;
                                                }
                                            }
                                        }
                                        goto IL_9B;
                                    }
                                Block_10:
                                    if (2 != 0)
                                    {
                                        this._lstmain.Add(msftDiscRecorder);
                                        goto IL_92;
                                    }
                                    goto IL_55;
                                }
                                goto Block_12;
                            }
                        }
                    Block_12: ;
                    }
                    catch
                    {
                    }
                    if (this.devicesComboBox.Items.Count > 0)
                    {
                        this.devicesComboBox.SelectedIndex = 0;
                    }
                }
            }
            catch (COMException serviceException)
            {
                while (true)
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                    while (7 != 0)
                    {
                        if (!false)
                        {
                            goto Block_16;
                        }
                    }
                }
            Block_16: ;
            }
            finally
            {
                if (msftDiscMaster != null)
                {
                    Marshal.ReleaseComObject(msftDiscMaster);
                }
            }
            DateTime dateTime = new CustomBusineses().ServerDateTime();
            this.UpdateCapacity();
        }

        private void AddRecordingDevices()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            this._discMaster = (MsftDiscMaster2)new MsftDiscMaster2Class();
            try
            {
                bool flag = this._discMaster.IsSupportedEnvironment;
                while (flag)
                {
                    IEnumerator enumerator = this._discMaster.GetEnumerator();
                    try
                    {
                        while (true)
                        {
                            int arg_ED_0;
                            int arg_AC_0;
                            bool expr_12B = (arg_AC_0 = (arg_ED_0 = (enumerator.MoveNext() ? 1 : 0))) != 0;
                            int num;
                            MsftDiscRecorder2 msftDiscRecorder;
                            string text;
                            string str;
                            object[] volumePathNames;
                            int num2;
                            if (6 != 0)
                            {
                                if (8 != 0)
                                {
                                    flag = expr_12B;
                                    if (!flag)
                                    {
                                        break;
                                    }
                                    string recorderUniqueId = (string)enumerator.Current;
                                    num = 0;
                                    msftDiscRecorder = (MsftDiscRecorder2)new MsftDiscRecorder2Class();
                                    msftDiscRecorder.InitializeDiscRecorder(recorderUniqueId);
                                    text = string.Empty;
                                    flag = (msftDiscRecorder == null);
                                    bool expr_87 = (arg_AC_0 = (flag ? 1 : 0)) != 0;
                                    if (!false)
                                    {
                                        if (expr_87)
                                        {
                                            goto IL_FE;
                                        }
                                        str = (string)msftDiscRecorder.VolumePathNames.GetValue(0);
                                        volumePathNames = msftDiscRecorder.VolumePathNames;
                                        arg_AC_0 = 0;
                                    }
                                }
                                num2 = arg_AC_0;
                                goto IL_EF;
                            }
                            goto IL_ED;
                        IL_FE:
                            flag = (msftDiscRecorder == null);
                            if (!flag)
                            {
                                dictionary.Add(string.Format("{0} [{1}]", text, msftDiscRecorder.ProductId), num.ToString());
                            }
                            continue;
                        IL_EF:
                            int arg_F5_0 = num2;
                            int arg_F4_0 = volumePathNames.Length;
                            int expr_E6;
                            int expr_E9;
                            do
                            {
                                flag = (arg_F5_0 < arg_F4_0);
                                if (!flag)
                                {
                                    goto IL_FE;
                                }
                                string text2 = (string)volumePathNames[num2];
                                flag = string.IsNullOrEmpty(text);
                                if (!flag)
                                {
                                    text += ",";
                                }
                                text += str;
                                expr_E6 = (arg_F5_0 = num2);
                                expr_E9 = (arg_F4_0 = 1);
                            }
                            while (expr_E9 == 0);
                            arg_ED_0 = expr_E6 + expr_E9;
                        IL_ED:
                            num2 = arg_ED_0;
                            goto IL_EF;
                        }
                    }
                    finally
                    {
                        IDisposable disposable = enumerator as IDisposable;
                        flag = (disposable == null);
                        if (false || !flag)
                        {
                            disposable.Dispose();
                        }
                    }
                    if (2 != 0)
                    {
                        if (5 == 0)
                        {
                            continue;
                        }
                        this.devicesComboBox.ItemsSource = dictionary;
                    }
                    this.devicesComboBox.SelectedValue = "0";
                    break;
                }
            }
            catch (COMException serviceException)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException);
            }
            catch (Exception serviceException2)
            {
                ErrorHandler.ErrorHandler.LogError(serviceException2);
            }
        }

        private void UpdateCapacity()
        {
            if (2 != 0)
            {
                long arg_6C_0;
                long expr_06 = arg_6C_0 = this._totalDiscSize;
                if (8 != 0)
                {
                    bool arg_66_0 = expr_06 != 0L;
                    bool expr_69;
                    do
                    {
                        bool flag = arg_66_0;
                        expr_69 = (arg_66_0 = flag);
                    }
                    while (false);
                    if (!expr_69)
                    {
                        return;
                    }
                }
                do
                {
                    if (!false)
                    {
                        List<DirectoryItem> source = this._lstDir.ToList<DirectoryItem>();
                        (from i in source
                         select i.SizeOnDisc).Sum();
                    }
                }
                while (5 == 0);
            }
        }

        private void backgroundBurnWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!false)
            {
                MsftDiscRecorder2 msftDiscRecorder = null;
                MsftDiscFormat2Data msftDiscFormat2Data = null;
                BurnData burnData = (BurnData)e.Argument;
                IStream stream = null;
                try
                {
                    msftDiscRecorder = (MsftDiscRecorder2)new MsftDiscRecorder2Class();
                    msftDiscRecorder.InitializeDiscRecorder(burnData.uniqueRecorderId);
                    MsftDiscFormat2Data msftDiscFormat2Data2 = (MsftDiscFormat2Data)new MsftDiscFormat2DataClass();
                    msftDiscFormat2Data2.Recorder = msftDiscRecorder;
                    msftDiscFormat2Data2.ClientName = "BurnMedia1";
                    msftDiscFormat2Data2.ForceMediaToBeClosed = this._closeMedia;
                    msftDiscFormat2Data = msftDiscFormat2Data2;
                    IBurnVerification burnVerification = (IBurnVerification)msftDiscFormat2Data;
                    burnVerification.BurnVerificationLevel = this._verificationLevel;
                    object[] multisessionInterfaces = null;
                    if (!msftDiscFormat2Data.MediaHeuristicallyBlank)
                    {
                        multisessionInterfaces = msftDiscFormat2Data.MultisessionInterfaces;
                    }
                    do
                    {
                        //IStream stream;
                        bool flag = this.CreateMediaFileSystem(msftDiscRecorder, multisessionInterfaces, out stream);
                        if (flag)
                        {
                            goto IL_1D9;
                        }
                        string proCode = (from o in this.listOfItems
                                          where o.OrderDetailId == burnData.BOID
                                          select o).FirstOrDefault<BurnOrderInfo>().OrderNumber;
                        List<BurnOrderInfo> list = this.listOfItems.Where(delegate(BurnOrderInfo o)
                        {
                            int expr_37;
                            while (true)
                            {
                                bool arg_0D_0 = o.OrderNumber == proCode;
                                while (true)
                                {
                                    int arg_18_0;
                                    int arg_64_0;
                                    if (arg_0D_0)
                                    {
                                        if (6 == 0)
                                        {
                                            goto IL_37;
                                        }
                                        arg_18_0 = o.ProductType;
                                    }
                                    else
                                    {
                                        if (7 != 0)
                                        {
                                            arg_64_0 = 0;
                                            goto IL_32;
                                        }
                                        break;
                                    }
                                IL_16:
                                    if (arg_18_0 != 96)
                                    {
                                        int expr_5D = arg_64_0 = o.ProductType;
                                        if (!false)
                                        {
                                            arg_64_0 = ((arg_0D_0 = (expr_5D == 35)) ? 1 : 0);
                                            if (-1 == 0)
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        arg_64_0 = 1;
                                    }
                                    goto IL_32;
                                IL_37:
                                    bool flag2;
                                    expr_37 = (arg_18_0 = (flag2 ? 1 : 0));
                                    if (!false)
                                    {
                                        return expr_37 != 0;
                                    }
                                    goto IL_16;
                                IL_32:
                                    flag2 = (arg_64_0 != 0);
                                    goto IL_37;
                                }
                            }
                            return expr_37 != 0;
                        }).ToList<BurnOrderInfo>();
                        using (List<BurnOrderInfo>.Enumerator enumerator = list.GetEnumerator())
                        {
                            while (true)
                            {
                                if (false)
                                {
                                    goto IL_18A;
                                }
                                if (!false)
                                {
                                    flag = enumerator.MoveNext();
                                    goto IL_18A;
                                }
                            IL_149:
                                BurnOrderInfo current = enumerator.Current;
                                new OrderBusiness().UpdateBurnOrderStatus(burnData.BOID, 2, LoginUser.UserId, new CustomBusineses().ServerDateTime());
                                continue;
                            IL_18A:
                                if (!flag)
                                {
                                    break;
                                }
                                goto IL_149;
                            }
                        }
                    }
                    while (false);
                    this._msg = "CD: Order " + burnData.ORDERNUMBER + " failed!";
                    e.Result = -1;
                    return;
                IL_1D9:
                    msftDiscFormat2Data.Update += new DiscFormat2Data_EventHandler(this.discFormatData_Update);
                    try
                    {
                       // IStream stream;
                        msftDiscFormat2Data.Write(stream);
                        e.Result = 1;
                        this._msg = "CD: Order " + burnData.ORDERNUMBER + " processed successfully!";
                        string proCode = (from o in this.listOfItems
                                          where o.OrderDetailId == burnData.BOID
                                          select o).FirstOrDefault<BurnOrderInfo>().OrderNumber;
                        List<BurnOrderInfo> list = this.listOfItems.Where(delegate(BurnOrderInfo o)
                        {
                            int expr_37;
                            while (true)
                            {
                                bool arg_0D_0 = o.OrderNumber == proCode;
                                while (true)
                                {
                                    int arg_18_0;
                                    int arg_64_0;
                                    if (arg_0D_0)
                                    {
                                        if (6 == 0)
                                        {
                                            goto IL_37;
                                        }
                                        arg_18_0 = o.ProductType;
                                    }
                                    else
                                    {
                                        if (7 != 0)
                                        {
                                            arg_64_0 = 0;
                                            goto IL_32;
                                        }
                                        break;
                                    }
                                IL_16:
                                    if (arg_18_0 != 96)
                                    {
                                        int expr_5D = arg_64_0 = o.ProductType;
                                        if (!false)
                                        {
                                            arg_64_0 = ((arg_0D_0 = (expr_5D == 35)) ? 1 : 0);
                                            if (-1 == 0)
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        arg_64_0 = 1;
                                    }
                                    goto IL_32;
                                IL_37:
                                    bool flag2;
                                    expr_37 = (arg_18_0 = (flag2 ? 1 : 0));
                                    if (!false)
                                    {
                                        return expr_37 != 0;
                                    }
                                    goto IL_16;
                                IL_32:
                                    flag2 = (arg_64_0 != 0);
                                    goto IL_37;
                                }
                            }
                            return expr_37 != 0;
                        }).ToList<BurnOrderInfo>();
                        foreach (BurnOrderInfo current in list)
                        {
                            new OrderBusiness().UpdateBurnOrderStatus(current.OrderDetailId, 1, LoginUser.UserId, new CustomBusineses().ServerDateTime());
                        }
                        this._cdOrderSuccess = burnData.ORDERNUMBER;
                    }
                    catch (COMException serviceException)
                    {
                        string message = "There may be some issue in CD format for order no " + burnData.ORDERNUMBER + ". Error may be " + ErrorHandler.ErrorHandler.CreateErrorMessage(serviceException);
                        ErrorHandler.ErrorHandler.LogFileWrite(message);
                        if (8 != 0 && !false)
                        {
                            e.Result = 1;
                        }
                        this._msg = "CD: Order " + burnData.ORDERNUMBER + " processed successfully!";
                        string proCode = (from o in this.listOfItems
                                          where o.OrderDetailId == burnData.BOID
                                          select o).FirstOrDefault<BurnOrderInfo>().OrderNumber;
                        List<BurnOrderInfo> list = this.listOfItems.Where(delegate(BurnOrderInfo o)
                        {
                            int expr_37;
                            while (true)
                            {
                                bool arg_0D_0 = o.OrderNumber == proCode;
                                while (true)
                                {
                                    int arg_18_0;
                                    int arg_64_0;
                                    if (arg_0D_0)
                                    {
                                        if (6 == 0)
                                        {
                                            goto IL_37;
                                        }
                                        arg_18_0 = o.ProductType;
                                    }
                                    else
                                    {
                                        if (7 != 0)
                                        {
                                            arg_64_0 = 0;
                                            goto IL_32;
                                        }
                                        break;
                                    }
                                IL_16:
                                    if (arg_18_0 != 96)
                                    {
                                        int expr_5D = arg_64_0 = o.ProductType;
                                        if (!false)
                                        {
                                            arg_64_0 = ((arg_0D_0 = (expr_5D == 35)) ? 1 : 0);
                                            if (-1 == 0)
                                            {
                                                continue;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        arg_64_0 = 1;
                                    }
                                    goto IL_32;
                                IL_37:
                                    bool flag2;
                                    expr_37 = (arg_18_0 = (flag2 ? 1 : 0));
                                    if (!false)
                                    {
                                        return expr_37 != 0;
                                    }
                                    goto IL_16;
                                IL_32:
                                    flag2 = (arg_64_0 != 0);
                                    goto IL_37;
                                }
                            }
                            return expr_37 != 0;
                        }).ToList<BurnOrderInfo>();
                        foreach (BurnOrderInfo current in list)
                        {
                            new OrderBusiness().UpdateBurnOrderStatus(current.OrderDetailId, 1, LoginUser.UserId, new CustomBusineses().ServerDateTime());
                        }
                        this._cdOrderSuccess = burnData.ORDERNUMBER;
                    }
                    finally
                    {
                       // IStream stream;
                        if (stream != null)
                        {
                            Marshal.FinalReleaseComObject(stream);
                        }
                    }
                    msftDiscFormat2Data.Update -= new DiscFormat2Data_EventHandler(this.discFormatData_Update);
                    msftDiscRecorder.EjectMedia();
                }
                catch (COMException var_13_464)
                {
                    string proCode = (from o in this.listOfItems
                                      where o.OrderDetailId == burnData.BOID
                                      select o).FirstOrDefault<BurnOrderInfo>().OrderNumber;
                    List<BurnOrderInfo> list = this.listOfItems.Where(delegate(BurnOrderInfo o)
                    {
                        int expr_37;
                        while (true)
                        {
                            bool arg_0D_0 = o.OrderNumber == proCode;
                            while (true)
                            {
                                int arg_18_0;
                                int arg_64_0;
                                if (arg_0D_0)
                                {
                                    if (6 == 0)
                                    {
                                        goto IL_37;
                                    }
                                    arg_18_0 = o.ProductType;
                                }
                                else
                                {
                                    if (7 != 0)
                                    {
                                        arg_64_0 = 0;
                                        goto IL_32;
                                    }
                                    break;
                                }
                            IL_16:
                                if (arg_18_0 != 96)
                                {
                                    int expr_5D = arg_64_0 = o.ProductType;
                                    if (!false)
                                    {
                                        arg_64_0 = ((arg_0D_0 = (expr_5D == 35)) ? 1 : 0);
                                        if (-1 == 0)
                                        {
                                            continue;
                                        }
                                    }
                                }
                                else
                                {
                                    arg_64_0 = 1;
                                }
                                goto IL_32;
                            IL_37:
                                bool flag2;
                                expr_37 = (arg_18_0 = (flag2 ? 1 : 0));
                                if (!false)
                                {
                                    return expr_37 != 0;
                                }
                                goto IL_16;
                            IL_32:
                                flag2 = (arg_64_0 != 0);
                                goto IL_37;
                            }
                        }
                        return expr_37 != 0;
                    }).ToList<BurnOrderInfo>();
                    foreach (BurnOrderInfo current in list)
                    {
                        new OrderBusiness().UpdateBurnOrderStatus(burnData.BOID, 2, LoginUser.UserId, new CustomBusineses().ServerDateTime());
                    }
                    this._msg = "CD: Order " + burnData.ORDERNUMBER + " failed!";
                    e.Result = -1;
                }
                finally
                {
                    if (msftDiscRecorder != null)
                    {
                        Marshal.ReleaseComObject(msftDiscRecorder);
                    }
                    if (msftDiscFormat2Data != null)
                    {
                        Marshal.ReleaseComObject(msftDiscFormat2Data);
                    }
                }
            }
        }

        private void discFormatData_Update([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, [MarshalAs(UnmanagedType.IDispatch)] [In] object progress)
        {
            bool expr_11 = !this._backgroundBurnWorker.CancellationPending;
            bool flag;
            if (3 != 0)
            {
                flag = expr_11;
            }
            if (!flag)
            {
                IDiscFormat2Data discFormat2Data = (IDiscFormat2Data)sender;
                discFormat2Data.CancelWrite();
            }
            else
            {
                IDiscFormat2DataEventArgs discFormat2DataEventArgs = (IDiscFormat2DataEventArgs)progress;
                this._burnData.task = BURN_MEDIA_TASK.BURN_MEDIA_TASK_WRITING;
                this._burnData.elapsedTime = (long)discFormat2DataEventArgs.ElapsedTime;
                this._burnData.remainingTime = (long)discFormat2DataEventArgs.RemainingTime;
                this._burnData.totalTime = (long)discFormat2DataEventArgs.TotalTime;
                this._burnData.currentAction = discFormat2DataEventArgs.CurrentAction;
                this._burnData.startLba = (long)discFormat2DataEventArgs.StartLba;
                this._burnData.sectorCount = (long)discFormat2DataEventArgs.SectorCount;
                this._burnData.lastReadLba = (long)discFormat2DataEventArgs.LastReadLba;
                this._burnData.lastWrittenLba = (long)discFormat2DataEventArgs.LastWrittenLba;
                this._burnData.totalSystemBuffer = (long)discFormat2DataEventArgs.TotalSystemBuffer;
                this._burnData.usedSystemBuffer = (long)discFormat2DataEventArgs.UsedSystemBuffer;
                this._burnData.freeSystemBuffer = (long)discFormat2DataEventArgs.FreeSystemBuffer;
                this._backgroundBurnWorker.ReportProgress(0, this._burnData);
            }
        }

        private bool CreateMediaFileSystem(IDiscRecorder2 discRecorder, object[] multisessionInterfaces, out IStream dataStream)
        {
            MsftFileSystemImage expr_01 = null;
            MsftFileSystemImage msftFileSystemImage;
            if (!false)
            {
                msftFileSystemImage = expr_01;
            }
            bool result;
            try
            {
                MsftDiscFormat2Data expr_0F = (MsftDiscFormat2Data)new MsftDiscFormat2DataClass();
                MsftDiscFormat2Data msftDiscFormat2Data;
                if (3 != 0)
                {
                    msftDiscFormat2Data = expr_0F;
                }
                msftFileSystemImage = (MsftFileSystemImage)new MsftFileSystemImageClass();
                do
                {
                    msftFileSystemImage.ChooseImageDefaults(discRecorder);
                }
                while (2 == 0);
                msftFileSystemImage.FileSystemsToCreate = (FsiFileSystems.FsiFileSystemISO9660 | FsiFileSystems.FsiFileSystemJoliet);
                if (4 == 0)
                {
                    goto IL_BA;
                }
                if (msftDiscFormat2Data.IsCurrentMediaSupported(discRecorder))
                {
                    msftDiscFormat2Data.Recorder = discRecorder;
                    IMAPI_MEDIA_PHYSICAL_TYPE currentPhysicalMediaType = msftDiscFormat2Data.CurrentPhysicalMediaType;
                    msftFileSystemImage.ChooseImageDefaultsForMediaType(currentPhysicalMediaType);
                }
            IL_73:
                if (7 == 0)
                {
                    goto IL_A5;
                }
                msftFileSystemImage.Update += new DFileSystemImage_EventHandler(this.fileSystemImage_Update);
                bool flag = msftDiscFormat2Data.MediaHeuristicallyBlank;
            IL_93:
                if (!flag)
                {
                    msftFileSystemImage.MultisessionInterfaces = msftDiscFormat2Data.MultisessionInterfaces;
                }
                else
                {
                    if (2 != 0)
                    {
                        msftFileSystemImage.ChooseImageDefaults(discRecorder);
                        goto IL_BA;
                    }
                    goto IL_73;
                }
            IL_A5:
                msftFileSystemImage.ImportFileSystem();
            IL_AC:
                goto IL_C4;
            IL_BA:
                msftFileSystemImage.FileSystemsToCreate = FsiFileSystems.FsiFileSystemUDF;
            IL_C4:
                IFsiDirectoryItem root = msftFileSystemImage.Root;
                List<DirectoryItem> list = this._lstDir.ToList<DirectoryItem>();
                //foreach (IMediaItem current in list)
                //{
                //    if (this._backgroundBurnWorker.CancellationPending)
                //    {
                //        break;
                //    }
                //    current.AddToFileSystem(root);
                //}
                msftFileSystemImage.Update -= new DFileSystemImage_EventHandler(this.fileSystemImage_Update);
                flag = !this._backgroundBurnWorker.CancellationPending;
                if (!flag)
                {
                    if (false)
                    {
                        goto IL_93;
                    }
                    if (4 != 0)
                    {
                        dataStream = null;
                        result = false;
                        return result;
                    }
                    goto IL_AC;
                }
                else
                {
                    dataStream = msftFileSystemImage.CreateResultImage().ImageStream;
                }
            }
            catch (COMException var_6_1B6)
            {
                dataStream = null;
                result = false;
                return result;
            }
            finally
            {
                if (false || msftFileSystemImage != null)
                {
                    Marshal.ReleaseComObject(msftFileSystemImage);
                }
            }
            result = true;
            return result;
        }

        private void fileSystemImage_Update([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, [MarshalAs(UnmanagedType.BStr)] [In] string currentFile, [In] int copiedSectors, [In] int totalSectors)
        {
            int percentProgress;
            while (true)
            {
                int arg_44_0;
                int arg_3B_0;
                int arg_1B_0;
                int expr_02 = arg_1B_0 = (arg_3B_0 = (arg_44_0 = 0));
                if (expr_02 != 0)
                {
                    goto IL_36;
                }
                percentProgress = expr_02;
                arg_1B_0 = copiedSectors;
                int arg_1B_1;
                int expr_10 = arg_1B_1 = 0;
                if (expr_10 != 0)
                {
                    goto IL_1B;
                }
                if (copiedSectors > expr_10)
                {
                    arg_1B_0 = totalSectors;
                    arg_1B_1 = 0;
                    goto IL_1B;
                }
                bool arg_BB_0 = true;
                goto IL_23;
            IL_4B:
                if (false || string.IsNullOrEmpty(currentFile))
                {
                    return;
                }
                if (4 != 0)
                {
                    break;
                }
                continue;
            IL_23:
                if (!arg_BB_0)
                {
                    arg_44_0 = copiedSectors;
                    arg_3B_0 = copiedSectors;
                    arg_1B_0 = copiedSectors;
                    goto IL_36;
                }
                goto IL_4B;
            IL_1B:
                arg_BB_0 = (arg_1B_0 <= arg_1B_1);
                goto IL_23;
            IL_36:
                int arg_44_1;
                int expr_38 = arg_1B_1 = (arg_44_1 = 100);
                if (expr_38 != 0)
                {
                    arg_44_0 = (arg_1B_0 = arg_3B_0 * expr_38);
                    arg_44_1 = totalSectors;
                    arg_1B_1 = totalSectors;
                }
                if (!false)
                {
                    percentProgress = arg_44_0 / arg_44_1;
                    goto IL_4B;
                }
                goto IL_1B;
            }
            FileInfo fileInfo = new FileInfo(currentFile);
            this._burnData.statusMessage = "Adding \"" + fileInfo.Name + "\" to image...";
            this._burnData.task = BURN_MEDIA_TASK.BURN_MEDIA_TASK_FILE_SYSTEM;
            this._backgroundBurnWorker.ReportProgress(percentProgress, this._burnData);
        }

        private void backgroundFormatWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            MsftDiscRecorder2 msftDiscRecorder = null;
            MsftDiscFormat2Erase msftDiscFormat2Erase = null;
            try
            {
                MsftDiscRecorder2 expr_13 = (MsftDiscRecorder2)new MsftDiscRecorder2Class();
                if (5 != 0)
                {
                    msftDiscRecorder = expr_13;
                }
                string recorderUniqueId = (string)e.Argument;
                msftDiscRecorder.InitializeDiscRecorder(recorderUniqueId);
                MsftDiscFormat2Erase msftDiscFormat2Erase2 = (MsftDiscFormat2Erase)new MsftDiscFormat2EraseClass();
                if (false)
                {
                    goto IL_68;
                }
                msftDiscFormat2Erase2.Recorder = msftDiscRecorder;
            IL_5A:
                msftDiscFormat2Erase2.ClientName = "BurnMedia1";
            IL_68:
                msftDiscFormat2Erase = msftDiscFormat2Erase2;
                msftDiscFormat2Erase.Update += new DiscFormat2Erase_EventHandler(this.discFormatErase_Update);
                try
                {
                    do
                    {
                        msftDiscFormat2Erase.EraseMedia();
                    }
                    while (!true);
                    e.Result = 0;
                }
                catch (COMException var_3_99)
                {
                    while (false)
                    {
                    }
                }
                if (5 == 0)
                {
                    goto IL_5A;
                }
                msftDiscFormat2Erase.Update -= new DiscFormat2Erase_EventHandler(this.discFormatErase_Update);
            }
            catch (COMException serviceException)
            {
                do
                {
                    ErrorHandler.ErrorHandler.LogError(serviceException);
                }
                while (false);
            }
            finally
            {
                if (msftDiscRecorder != null)
                {
                    Marshal.ReleaseComObject(msftDiscRecorder);
                }
                bool arg_11C_0 = msftDiscFormat2Erase == null;
                if (-1 != 0)
                {
                    if (!arg_11C_0)
                    {
                        Marshal.ReleaseComObject(msftDiscFormat2Erase);
                    }
                }
            }
        }

        private void discFormatErase_Update([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, int elapsedSeconds, int estimatedTotalSeconds)
        {
            int arg_12_0 = elapsedSeconds * 100 / estimatedTotalSeconds;
        }

        private void backgroundFormatWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        private void backgroundFormatWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this._isFormatting = false;
        }

        private void UpdateVOS()
        {
            if (!true)
            {
                goto IL_14;
            }
        IL_04:
            string pendingBurnOrders = this.GetPendingBurnOrders();
        IL_13:
        IL_14:
            IEnumerator expr_DF = Application.Current.Windows.GetEnumerator();
            IEnumerator enumerator;
            if (7 != 0)
            {
                enumerator = expr_DF;
            }
            try
            {
                while (enumerator.MoveNext())
                {
                    Window window;
                    if (true)
                    {
                        window = (Window)enumerator.Current;
                    }
                    while (window.Title == "View/Order Station")
                    {
                        SearchResult searchResult = window as SearchResult;
                        searchResult.lblPendingOrders.Text = pendingBurnOrders;
                        if (-1 != 0)
                        {
                            break;
                        }
                    }
                }
            }
            finally
            {
                IDisposable disposable = enumerator as IDisposable;
                if (disposable != null)
                {
                    disposable.Dispose();
                }
            }
            if (4 == 0)
            {
                goto IL_04;
            }
            if (8 == 0)
            {
                goto IL_13;
            }
            if (4 != 0)
            {
                return;
            }
            goto IL_04;
        }

        private string GetPendingBurnOrders()
        {
            string result;
            while (!false)
            {
                string text;
                string[] array;
                if (6 != 0)
                {
                    text = "";
                    if (false)
                    {
                    }
                    if (false)
                    {
                        continue;
                    }
                    int num = 0;
                    int num2 = 0;
                    List<BurnOrderInfo> pendingBurnOrders = new OrderBusiness().GetPendingBurnOrders(true);
                    using (List<BurnOrderInfo>.Enumerator enumerator = pendingBurnOrders.GetEnumerator())
                    {
                        while (true)
                        {
                            if (!enumerator.MoveNext())
                            {
                                if (!false)
                                {
                                    break;
                                }
                            }
                            else
                            {
                                while (true)
                                {
                                IL_51:
                                    BurnOrderInfo current = enumerator.Current;
                                    while (current.Status != 1)
                                    {
                                        if (!this.isLocalOrder(current.OrderNumber, current.ProductType))
                                        {
                                            break;
                                        }
                                        string orderNumber = current.OrderNumber;
                                        int productType = current.ProductType;
                                        if (productType == 36)
                                        {
                                            if (5 != 0)
                                            {
                                                goto Block_9;
                                            }
                                            goto IL_51;
                                        }
                                        else if (7 != 0)
                                        {
                                            goto Block_10;
                                        }
                                    }
                                    break;
                                }
                                continue;
                                continue;
                            Block_9:
                                num++;
                                continue;
                            Block_10:
                                num2++;
                            }
                        }
                    }
                    string text2 = text;
                    array = new string[6];
                    array[0] = text2;
                    array[1] = "USB(";
                    array[2] = num.ToString();
                    array[3] = ") CD(";
                    array[4] = num2.ToString();
                }
                array[5] = ")";
                text = string.Concat(array);
            IL_130:
                result = text;
                break;
            }
            if (7 != 0)
            {
                return result;
            }
           // goto IL_130;
        }

        private void btnLoadOrders_Click(object sender, RoutedEventArgs e)
        {
            if (!BurnOrderElements.isExecuting)
            {
                this.LoadBurnOrders();
            }
        }

        private void btnCancelBurn_Click(object sender, RoutedEventArgs e)
        {
            Button expr_03 = sender as Button;
            Button button;
            if (!false)
            {
                button = expr_03;
            }
            int boId = button.Tag.ToInt32(false);
            new OrderBusiness().UpdateBurnOrderStatus(boId, Convert.ToInt32(BurnMediaOrderList.StatusCode.Success), LoginUser.UserId, new CustomBusineses().ServerDateTime());
            this.GetPendingBurnOrderDetails(true);
        }

        void IStyleConnector.Connect(int connectionId, object target)
        {
            while (true)
            {
                int arg_16_0 = connectionId;
                if (false)
                {
                    goto IL_16;
                }
                if (4 != 0)
                {
                    arg_16_0 = connectionId - 11;
                    goto IL_16;
                }
            IL_5A:
                if (!false)
                {
                    if (true)
                    {
                        break;
                    }
                    continue;
                }
            IL_23:
                goto IL_5A;
            IL_16:
                switch (arg_16_0)
                {
                    case 0:
                        ((Button)target).Click += new RoutedEventHandler(this.btnBurnMedia_Click);
                        break;
                    case 1:
                        if (!false)
                        {
                            ((Button)target).Click += new RoutedEventHandler(this.btnCancelBurn_Click);
                        }
                        break;
                }
                goto IL_23;
            }
        }
    }
}
