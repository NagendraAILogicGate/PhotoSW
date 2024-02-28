namespace DigiPhoto
{
    using DigiPhoto.Common;
    using DigiPhoto.IMIX.Business;
    using DigiPhoto.IMIX.Model;
    using ErrorHandler;
    using FrameworkHelper;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media.Imaging;

    public static class RobotImageLoader
    {
        public static List<LstMyItems> _objnewincrement = new List<LstMyItems>();
        public static int _rfidSearch = 0;
        public static int BeforerPinterCount = 0;
        public static int? CharacterId = 0;
        public static string Code;
        public static int CodeType;
        public static LstMyItems curItem;
        public static int currentCount;
        public static string FilePath;
        public static DateTime FromTime;
        public static string GroupId;
        public static List<LstMyItems> GroupImages;
        public static long ImgCount = 0L;
        public static bool Is16ImgViewActive = false;
        public static bool Is9ImgViewActive = false;
        public static bool IsAnonymousQrCodeEnabled;
        public static bool isGroup = false;
        public static bool IsLastPage;
        public static bool IsMoreNextImages = false;
        public static bool IsMorePrevImages = true;
        public static bool IsNextPage = false;
        public static bool IsPreview9or16active = false;
        public static bool IsPreviewModeActive = false;
        public static bool IsZeroSearchNeeded = false;
        public static int ListPosition;
        public static int LocationId;
        public static List<string> LstUnlocknames;
        public static long MaxPhotoId = 0L;
        public static long MaxPhotoIdCriteria = 0L;
        public static int MediaTypes = 3;
        public static long MinPhotoId = 0L;
        public static long MinPhotoIdCriteria = 0L;
        public static int NewRecord = 0;
        public static List<LstMyItems> NotPrintedImages;
        public static string PageName;
        public static string PhotoId;
        public static List<LstMyItems> PrintImages;
        public static string RFID = "1";
        public static List<LstMyItems> robotImages;
        public static string SearchCriteria;
        public static string SearchedStoreId;
        public static int StartIndex = 0;
        public static long StartIndexRFID = 0L;
        public static int startLoad;
        public static int StopIndex = 0;
        public static int thumbSet = 20;
        public static int totalCount = 0;
        public static DateTime ToTime;
        public static int UniquePhotoId;
        public static int UserId;
        public static List<string> ViewGroupedImagesCount;

        public static void GetConfigData()
        {
            Exception exception;
            string str = "";
            string str2 = "";
            try
            {
                try
                {
                    StreamReader reader;
                    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    if (File.Exists(baseDirectory + @"\ss.dat"))
                    {
                        using (reader = new StreamReader(baseDirectory + @"\ss.dat"))
                        {
                            string str5 = DigiPhoto.CryptorEngine.Decrypt(reader.ReadLine(), true);
                            LoginUser.DefaultSubstores = str5;
                            LoginUser.SubstoreName = new StoreSubStoreDataBusniess().GetSubstoreNameById(Convert.ToInt32(str5.Split(new char[] { ',' })[0]));
                            LoginUser.SubStoreId = Convert.ToInt32(str5.Split(new char[] { ',' })[0]);
                        }
                    }
                    if (File.Exists(baseDirectory + @"\slipPrinter.dat"))
                    {
                        using (reader = new StreamReader(baseDirectory + @"\slipPrinter.dat"))
                        {
                            string str6 = reader.ReadLine();
                            str = str6.Split(new char[] { ',' }).ToArray<string>().First<string>().ToString();
                            str2 = str6.Split(new char[] { ',' }).ToArray<string>().Last<string>().ToString();
                        }
                    }
                }
                catch (Exception exception1)
                {
                    exception = exception1;
                    ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                }
                ConfigurationInfo configurationData = new ConfigBusiness().GetConfigurationData(LoginUser.SubStoreId);
                if (configurationData != null)
                {
                    LoginUser.DigiFolderBackGroundPath = configurationData.DG_BG_Path;
                    LoginUser.DigiFolderFramePath = configurationData.DG_Frame_Path;
                    LoginUser.DigiFolderPath = configurationData.DG_Hot_Folder_Path;
                    LoginUser.ModPassword = configurationData.DG_Mod_Password;
                    LoginUser.DigiFolderGraphicsPath = configurationData.DG_Graphics_Path;
                    LoginUser.DigiImagesCount = Convert.ToInt32(configurationData.DG_NoOfPhotos);
                    LoginUser.IsWatermark = configurationData.DG_Watermark;
                    LoginUser.IsHighResolution = configurationData.DG_HighResolution;
                    LoginUser.IsSemiOrder = configurationData.DG_SemiOrderMain;
                    LoginUser.DigiFolderBigThumbnailPath = configurationData.DG_Hot_Folder_Path + @"Thumbnails_Big\";
                    LoginUser.DigiFolderCropedPath = configurationData.DG_Hot_Folder_Path + @"Croped\";
                    LoginUser.DigiFolderThumbnailPath = configurationData.DG_Hot_Folder_Path + @"Thumbnails\";
                    LoginUser.DigiFolderAudioPath = configurationData.DG_Hot_Folder_Path + @"Audio\";
                    LoginUser.DigiFolderVideoTemplatePath = configurationData.DG_Hot_Folder_Path + @"VideoTemplate\";
                    LoginUser.DigiFolderVideoBackGroundPath = configurationData.DG_Hot_Folder_Path + @"VideoBackGround\";
                    LoginUser.DigiFolderProcessedVideosPath = configurationData.DG_Hot_Folder_Path + @"ProcessedVideos\";
                    LoginUser.DigiFolderVideoOverlayPath = configurationData.DG_Hot_Folder_Path + @"VideoOverlay\";
                    LoginUser.IsDiscountAllowed = configurationData.DG_AllowDiscount;
                    LoginUser.IsDiscountAllowedonTotal = configurationData.DG_EnableDiscountOnTotal;
                    LoginUser.DGNoOfPhotoIdSearch = configurationData.DG_NoOfPhotoIdSearch.Value;
                    int? nullable = configurationData.DG_PageCountGrid;
                    LoginUser.PageCountGrid = nullable.Value;
                    LoginUser.DigiReportPath = configurationData.DG_Hot_Folder_Path + @"Reports\";
                    LoginUser.ItemTemplatePath = configurationData.DG_Hot_Folder_Path + @"ItemTemplate\";
                    LoginUser.ItemCalenderPath = configurationData.DG_Hot_Folder_Path + @"ItemTemplate\Calendar\";
                    if (!string.IsNullOrEmpty(str))
                    {
                        LoginUser.ReceiptPrinterPath = str;
                    }
                    else
                    {
                        LoginUser.ReceiptPrinterPath = "";
                    }
                    if (!string.IsNullOrEmpty(str2))
                    {
                        LoginUser.GroupValue = str2;
                    }
                    else
                    {
                        LoginUser.GroupValue = "";
                    }
                    List<SemiOrderSettings> lstSemiOrderSettings = new SemiOrderBusiness().GetLstSemiOrderSettings(null);
                    if (lstSemiOrderSettings != null)
                    {
                        LoginUser.ListSemiOrderSettingsSubStoreWise = lstSemiOrderSettings;
                    }
                }
            }
            catch (Exception exception2)
            {
                exception = exception2;
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
            }
        }

        public static Dictionary<string, string> GetEmailType()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary = new Dictionary<string, string>();
            dictionary.Add("Select", "10");
            dictionary.Add("Not Sent", "0");
            dictionary.Add("Sent successfully", "1");
            dictionary.Add("Error", "2");
            return dictionary;
        }

        public static Dictionary<string, string> GetReports()
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary = new Dictionary<string, string>();
            dictionary.Add("Activity Reports", "0");
            dictionary.Add("Production Summary Report", "1");
            dictionary.Add("Operators Performance Report", "2");
            dictionary.Add("Taking Reports", "3");
            dictionary.Add("Operation Audit Trail", "4");
            dictionary.Add("Photographer Performance", "5");
            dictionary.Add("Site Performance Report", "6");
            dictionary.Add("Financial Audit Report", "7");
            dictionary.Add("Printing Report", "9");
            dictionary.Add("Payment Summary Report", "10");
            dictionary.Add("IP Print Tracking Report", "11");
            dictionary.Add("IP Content Tracking Report", "12");
            return dictionary;
        }

        public static bool GetShowAllSubstorePhotos()
        {
            bool flag = false;
            try
            {
                ConfigBusiness business = new ConfigBusiness();
                List<long> objList = new List<long> { 0x4aL };
                List<iMIXConfigurationInfo> list = (from o in business.GetNewConfigValues(LoginUser.SubStoreId)
                    where objList.Contains(o.IMIXConfigurationMasterId)
                    select o).ToList<iMIXConfigurationInfo>();
                if ((list != null) || (list.Count > 0))
                {
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list[i].IMIXConfigurationMasterId == 0x4aL)
                        {
                            flag = (list[i].ConfigurationValue != null) ? Convert.ToBoolean(list[i].ConfigurationValue) : false;
                        }
                    }
                }
                return flag;
            }
            catch (Exception exception)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                return false;
            }
        }

        public static List<LstMyItems> LoadImages()
        {
            List<LstMyItems> robotImages;
            List<LstMyItems> temprobotImages = new List<LstMyItems>();
            SearchDetailInfo searchdetails = new SearchDetailInfo();
            SearchCriteriaInfo searchBiz = new SearchCriteriaInfo();
            DirectoryInfo info3 = new DirectoryInfo(LoginUser.DigiFolderPath);
            string ssInfo = GetShowAllSubstorePhotos() ? string.Empty : LoginUser.DefaultSubstores;
            List<ModratePhotoInfo> moderatePhotosList = new List<ModratePhotoInfo>();
            PhotoBusiness phBiz = new PhotoBusiness();
            moderatePhotosList = phBiz.GetModeratePhotos();
            try
            {
                Stopwatch stopwatch;
                if (SearchCriteria == "TimeWithQrcode")
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    temprobotImages = SelectPhotoByTimeAndQRCode(temprobotImages, searchdetails, searchBiz, moderatePhotosList);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search TimeWithQrcode", stopwatch);
                    }
                }
                else if (SearchCriteria == "Time")
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    SelectPhotoByTime(temprobotImages, moderatePhotosList, phBiz);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search Time", stopwatch);
                    }
                }
                else if (SearchCriteria == "Group")
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    SelectPhotoByGroup(temprobotImages, moderatePhotosList, phBiz);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search Group", stopwatch);
                    }
                }
                else if (SearchCriteria == "QRCODE")
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    SelectPhotoByQRCode(temprobotImages, moderatePhotosList, phBiz);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search QRCODE", stopwatch);
                    }
                }
                else if (SearchCriteria == "QRCODEGROUP")
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    SelectPhotoByQRCodeGroup(temprobotImages, moderatePhotosList, phBiz);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search QRCODE GROUP", stopwatch);
                    }
                }
                else if (RFID == "0")
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    SelectPhotoByZeroSearch(temprobotImages, ssInfo, moderatePhotosList, phBiz, MediaTypes);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search 0", stopwatch);
                    }
                }
                else
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    SelectPhotoByRFID(temprobotImages, moderatePhotosList, phBiz);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search RFID", stopwatch);
                    }
                }
                if (SearchCriteria == "Group")
                {
                    GroupImages = temprobotImages;
                }
                else if (SearchCriteria == "Time")
                {
                    RobotImageLoader.robotImages = temprobotImages;
                }
                else if (SearchCriteria == "TimeWithQrcode")
                {
                    RobotImageLoader.robotImages = temprobotImages;
                }
                else if (SearchCriteria == "QRCODE")
                {
                    RobotImageLoader.robotImages = temprobotImages;
                }
                else if ((_objnewincrement.Count == 0) && (temprobotImages.Count != 0))
                {
                    RobotImageLoader.robotImages = temprobotImages;
                }
                else
                {
                    RobotImageLoader.robotImages = _objnewincrement;
                }
                temprobotImages = null;
                robotImages = RobotImageLoader.robotImages;
            }
            catch (Exception exception)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                robotImages = RobotImageLoader.robotImages;
            }
            finally
            {
                searchdetails = null;
                searchBiz = null;
            }
            return robotImages;
        }

        public static List<LstMyItems> LoadImages(SearchDetailInfo Searchdetails)
        {
            List<LstMyItems> robotImages;
            List<LstMyItems> temprobotImages = new List<LstMyItems>();
            SearchCriteriaInfo searchBiz = new SearchCriteriaInfo();
            string ssInfo = GetShowAllSubstorePhotos() ? string.Empty : LoginUser.DefaultSubstores;
            List<ModratePhotoInfo> moderatePhotosList = new List<ModratePhotoInfo>();
            PhotoBusiness phBiz = new PhotoBusiness();
            moderatePhotosList = phBiz.GetModeratePhotos();
            try
            {
                Stopwatch stopwatch;
                if (SearchCriteria == "TimeWithQrcode")
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    temprobotImages = SelectPhotoByTimeAndQRCode(temprobotImages, Searchdetails, searchBiz, moderatePhotosList);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search TimeWithQrcode", stopwatch);
                    }
                }
                else if (SearchCriteria == "Time")
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    SelectPhotoByTime(temprobotImages, moderatePhotosList, phBiz);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search Time", stopwatch);
                    }
                }
                else if (SearchCriteria == "Group")
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    SelectPhotoByGroup(temprobotImages, moderatePhotosList, phBiz);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search Group", stopwatch);
                    }
                }
                else if (SearchCriteria == "QRCODE")
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    SelectPhotoByQRCode(temprobotImages, moderatePhotosList, phBiz);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search QRCODE", stopwatch);
                    }
                }
                else if (SearchCriteria == "QRCODEGROUP")
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    SelectPhotoByQRCodeGroup(temprobotImages, moderatePhotosList, phBiz);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search QRCODE GROUP", stopwatch);
                    }
                }
                else if (RFID == "0")
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    SelectPhotoByZeroSearch(temprobotImages, ssInfo, moderatePhotosList, phBiz, MediaTypes);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search 0", stopwatch);
                    }
                }
                else
                {
                    stopwatch = CommonUtility.Watch();
                    stopwatch.Start();
                    SelectPhotoByRFID(temprobotImages, moderatePhotosList, phBiz);
                    if (stopwatch != null)
                    {
                        CommonUtility.WatchStop("Search RFID", stopwatch);
                    }
                }
                if (SearchCriteria == "Group")
                {
                    GroupImages = temprobotImages;
                }
                else if (SearchCriteria == "Time")
                {
                    RobotImageLoader.robotImages = temprobotImages;
                }
                else if (SearchCriteria == "TimeWithQrcode")
                {
                    RobotImageLoader.robotImages = temprobotImages;
                }
                else if (SearchCriteria == "QRCODE")
                {
                    RobotImageLoader.robotImages = temprobotImages;
                }
                else if (((_objnewincrement == null) || (_objnewincrement.Count == 0)) && (temprobotImages.Count != 0))
                {
                    RobotImageLoader.robotImages = temprobotImages;
                }
                else
                {
                    RobotImageLoader.robotImages = _objnewincrement;
                }
                temprobotImages = null;
                robotImages = RobotImageLoader.robotImages;
            }
            catch (Exception exception)
            {
                ErrorHandler.ErrorHandler.LogFileWrite(ErrorHandler.ErrorHandler.CreateErrorMessage(exception));
                robotImages = RobotImageLoader.robotImages;
            }
            finally
            {
                Searchdetails = null;
                searchBiz = null;
            }
            return robotImages;
        }

        private static void SelectPhotoByGroup(List<LstMyItems> temprobotImages, List<ModratePhotoInfo> moderatePhotosList, PhotoBusiness phBiz)
        {
            IsZeroSearchNeeded = false;
            StartIndex = 0;
            StopIndex = 0;
            RFID = "";
            List<PhotoInfo> savedGroupImages = phBiz.GetSavedGroupImages(GroupId);
            VideoProcessingClass class2 = new VideoProcessingClass();
            using (List<PhotoInfo>.Enumerator enumerator = savedGroupImages.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Func<ModratePhotoInfo, bool> predicate = null;
                    Func<LstMyItems, bool> func2 = null;
                    Func<LstMyItems, bool> func3 = null;
                    PhotoInfo item = enumerator.Current;
                    LstMyItems items = new LstMyItems {
                        Name = item.DG_Photos_RFID,
                        FileName = item.DG_Photos_FileName,
                        PhotoId = item.DG_Photos_pkey,
                        HotFolderPath = item.HotFolderPath,
                        MediaType = item.DG_MediaType,
                        VideoLength = item.DG_VideoLength,
                        CreatedOn = item.DG_Photos_CreatedOn,
                        OnlineQRCode = item.OnlineQRCode
                    };
                    if (predicate == null)
                    {
                        predicate = x => x.DG_Mod_Photo_ID == item.DG_Photos_pkey;
                    }
                    IEnumerable<ModratePhotoInfo> source = moderatePhotosList.AsEnumerable<ModratePhotoInfo>().Where<ModratePhotoInfo>(predicate);
                    if ((source != null) && (source.Count<ModratePhotoInfo>() > 0))
                    {
                        items.BigThumbnailPath = Path.Combine(items.BigDBThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), item.DG_Photos_FileName);
                        items.FilePath = items.HotFolderPath + "/Locked.png";
                        items.IsLocked = Visibility.Collapsed;
                        items.IsPassKeyVisible = Visibility.Visible;
                    }
                    else
                    {
                        string str = item.DG_Photos_FileName.Replace(class2.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mts"].ToString(), ".jpg");
                        items.BigThumbnailPath = Path.Combine(items.BigDBThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), str);
                        items.FilePath = Path.Combine(items.ThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), str);
                        if (string.IsNullOrEmpty(item.DG_Photos_Layering) && !string.IsNullOrEmpty(LoginUser.DefaultBorderPath))
                        {
                            items.FrameBrdr = LoginUser.DefaultBorderPath;
                        }
                        items.IsLocked = Visibility.Visible;
                        items.IsPassKeyVisible = Visibility.Collapsed;
                    }
                    if (func2 == null)
                    {
                        func2 = t => t.PhotoId == item.DG_Photos_pkey;
                    }
                    if (GroupImages.Where<LstMyItems>(func2).FirstOrDefault<LstMyItems>() == null)
                    {
                        items.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                        GroupImages.Add(items);
                    }
                    items.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                    if (PrintImages != null)
                    {
                        if (func3 == null)
                        {
                            func3 = t => t.PhotoId == item.DG_Photos_pkey;
                        }
                        if (PrintImages.Where<LstMyItems>(func3).FirstOrDefault<LstMyItems>() != null)
                        {
                            items.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                        }
                        else
                        {
                            items.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        }
                    }
                    else
                    {
                        items.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                    }
                    if (Is9ImgViewActive)
                    {
                        items.GridMainHeight = 190;
                        items.GridMainWidth = 0xe2;
                        items.GridMainRowHeight1 = 140;
                        items.GridMainRowHeight2 = 50;
                    }
                    else
                    {
                        items.GridMainHeight = 140;
                        items.GridMainWidth = 170;
                        items.GridMainRowHeight1 = 90;
                        items.GridMainRowHeight2 = 60;
                    }
                    temprobotImages.Add(items);
                }
            }
        }

        private static void SelectPhotoByQRCode(List<LstMyItems> temprobotImages, List<ModratePhotoInfo> moderatePhotosList, PhotoBusiness phBiz)
        {
            if (robotImages == null)
            {
                robotImages = new List<LstMyItems>();
            }
            if (GroupImages == null)
            {
                GroupImages = new List<LstMyItems>();
            }
            if (PrintImages == null)
            {
                PrintImages = new List<LstMyItems>();
            }
            VideoProcessingClass class2 = new VideoProcessingClass();
            List<PhotoInfo> imagesBYQRCode = phBiz.GetImagesBYQRCode(Code, IsAnonymousQrCodeEnabled);
            using (List<PhotoInfo>.Enumerator enumerator = imagesBYQRCode.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Func<ModratePhotoInfo, bool> predicate = null;
                    Func<LstMyItems, bool> func2 = null;
                    Func<LstMyItems, bool> func3 = null;
                    Func<LstMyItems, bool> func4 = null;
                    Func<LstMyItems, bool> func5 = null;
                    Func<LstMyItems, bool> func6 = null;
                    PhotoInfo item = enumerator.Current;
                    LstMyItems items = new LstMyItems {
                        HotFolderPath = item.HotFolderPath,
                        OnlineQRCode = item.OnlineQRCode
                    };
                    if (predicate == null)
                    {
                        predicate = x => x.DG_Mod_Photo_ID == item.DG_Photos_pkey;
                    }
                    IEnumerable<ModratePhotoInfo> source = moderatePhotosList.AsEnumerable<ModratePhotoInfo>().Where<ModratePhotoInfo>(predicate);
                    if ((source != null) && (source.Count<ModratePhotoInfo>() > 0))
                    {
                        items.PhotoId = item.DG_Photos_pkey;
                        items.Name = item.DG_Photos_RFID;
                        items.FileName = item.DG_Photos_FileName;
                        items.BmpImageGroup = null;
                        items.FilePath = items.HotFolderPath + "/Locked.png";
                        items.IsLocked = Visibility.Collapsed;
                        items.IsPassKeyVisible = Visibility.Visible;
                    }
                    else
                    {
                        items.PhotoId = item.DG_Photos_pkey;
                        items.Name = item.DG_Photos_RFID;
                        items.FileName = item.DG_Photos_FileName;
                        string str = item.DG_Photos_FileName.Replace(class2.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mts"].ToString(), ".jpg");
                        items.BigThumbnailPath = Path.Combine(items.BigDBThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), str);
                        items.FilePath = Path.Combine(items.ThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), str);
                        if (string.IsNullOrEmpty(item.DG_Photos_Layering) && !string.IsNullOrEmpty(LoginUser.DefaultBorderPath))
                        {
                            items.FrameBrdr = LoginUser.DefaultBorderPath;
                        }
                        items.IsLocked = Visibility.Visible;
                        items.IsPassKeyVisible = Visibility.Collapsed;
                    }
                    if (GroupImages != null)
                    {
                        if (func2 == null)
                        {
                            func2 = t => t.PhotoId == item.DG_Photos_pkey;
                        }
                        if (GroupImages.Where<LstMyItems>(func2).FirstOrDefault<LstMyItems>() != null)
                        {
                            items.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                        }
                        else
                        {
                            items.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                        }
                    }
                    else
                    {
                        items.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                    }
                    if (PrintImages != null)
                    {
                        if (func3 == null)
                        {
                            func3 = t => t.PhotoId == item.DG_Photos_pkey;
                        }
                        if (PrintImages.Where<LstMyItems>(func3).FirstOrDefault<LstMyItems>() != null)
                        {
                            items.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                        }
                        else
                        {
                            items.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        }
                    }
                    else
                    {
                        items.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                    }
                    if (func4 == null)
                    {
                        func4 = t => t.PhotoId == item.DG_Photos_pkey;
                    }
                    if (robotImages.Where<LstMyItems>(func4).FirstOrDefault<LstMyItems>() == null)
                    {
                        if (func5 == null)
                        {
                            func5 = gp1 => gp1.PhotoId == item.DG_Photos_pkey;
                        }
                        if (GroupImages.Where<LstMyItems>(func5).FirstOrDefault<LstMyItems>() != null)
                        {
                            items.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                        }
                        else
                        {
                            items.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                        }
                        if (func6 == null)
                        {
                            func6 = pr1 => pr1.PhotoId == item.DG_Photos_pkey;
                        }
                        if (PrintImages.Where<LstMyItems>(func6).FirstOrDefault<LstMyItems>() != null)
                        {
                            items.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                        }
                        else
                        {
                            items.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        }
                        robotImages.Add(items);
                    }
                    if (Is9ImgViewActive)
                    {
                        items.GridMainHeight = 190;
                        items.GridMainWidth = 0xe2;
                        items.GridMainRowHeight1 = 140;
                        items.GridMainRowHeight2 = 50;
                    }
                    else
                    {
                        items.GridMainHeight = 140;
                        items.GridMainWidth = 170;
                        items.GridMainRowHeight1 = 90;
                        items.GridMainRowHeight2 = 60;
                    }
                    temprobotImages.Add(items);
                }
            }
        }

        private static void SelectPhotoByQRCodeGroup(List<LstMyItems> temprobotImages, List<ModratePhotoInfo> moderatePhotosList, PhotoBusiness phBiz)
        {
            IsZeroSearchNeeded = false;
            StartIndex = 0;
            StopIndex = 0;
            RFID = "";
            if (GroupImages == null)
            {
                GroupImages = new List<LstMyItems>();
            }
            VideoProcessingClass class2 = new VideoProcessingClass();
            List<PhotoInfo> imagesBYQRCode = phBiz.GetImagesBYQRCode(Code, IsAnonymousQrCodeEnabled);
            using (List<PhotoInfo>.Enumerator enumerator = imagesBYQRCode.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Func<ModratePhotoInfo, bool> predicate = null;
                    Func<LstMyItems, bool> func2 = null;
                    Func<LstMyItems, bool> func3 = null;
                    PhotoInfo item = enumerator.Current;
                    LstMyItems items = new LstMyItems {
                        Name = item.DG_Photos_RFID,
                        FileName = item.DG_Photos_FileName,
                        PhotoId = item.DG_Photos_pkey,
                        HotFolderPath = item.HotFolderPath,
                        MediaType = item.DG_MediaType,
                        VideoLength = item.DG_VideoLength,
                        CreatedOn = item.DG_Photos_CreatedOn,
                        OnlineQRCode = item.OnlineQRCode
                    };
                    if (predicate == null)
                    {
                        predicate = x => x.DG_Mod_Photo_ID == item.DG_Photos_pkey;
                    }
                    IEnumerable<ModratePhotoInfo> source = moderatePhotosList.AsEnumerable<ModratePhotoInfo>().Where<ModratePhotoInfo>(predicate);
                    if ((source != null) && (source.Count<ModratePhotoInfo>() > 0))
                    {
                        items.FilePath = LoginUser.DigiFolderPath + "/Locked.png";
                        items.IsLocked = Visibility.Collapsed;
                        items.IsPassKeyVisible = Visibility.Visible;
                    }
                    else
                    {
                        string str = item.DG_Photos_FileName.Replace(class2.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mts"].ToString(), ".jpg");
                        items.BigThumbnailPath = Path.Combine(items.BigDBThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), str);
                        items.FilePath = Path.Combine(items.ThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), str);
                        if (string.IsNullOrEmpty(item.DG_Photos_Layering) && !string.IsNullOrEmpty(LoginUser.DefaultBorderPath))
                        {
                            items.FrameBrdr = LoginUser.DefaultBorderPath;
                        }
                        items.IsLocked = Visibility.Visible;
                        items.IsPassKeyVisible = Visibility.Collapsed;
                    }
                    if (func2 == null)
                    {
                        func2 = t => t.PhotoId == item.DG_Photos_pkey;
                    }
                    if (GroupImages.Where<LstMyItems>(func2).FirstOrDefault<LstMyItems>() == null)
                    {
                        items.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                        GroupImages.Add(items);
                    }
                    items.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                    if (PrintImages != null)
                    {
                        if (func3 == null)
                        {
                            func3 = t => t.PhotoId == item.DG_Photos_pkey;
                        }
                        if (PrintImages.Where<LstMyItems>(func3).FirstOrDefault<LstMyItems>() != null)
                        {
                            items.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                        }
                        else
                        {
                            items.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        }
                    }
                    else
                    {
                        items.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                    }
                    if (Is9ImgViewActive)
                    {
                        items.GridMainHeight = 190;
                        items.GridMainWidth = 0xe2;
                        items.GridMainRowHeight1 = 140;
                        items.GridMainRowHeight2 = 50;
                    }
                    else
                    {
                        items.GridMainHeight = 140;
                        items.GridMainWidth = 170;
                        items.GridMainRowHeight1 = 90;
                        items.GridMainRowHeight2 = 60;
                    }
                    temprobotImages.Add(items);
                }
            }
        }

        private static void SelectPhotoByRFID(List<LstMyItems> temprobotImages, List<ModratePhotoInfo> moderatePhotosList, PhotoBusiness phBiz)
        {
            GroupId = "";
            IsZeroSearchNeeded = false;
            StartIndex = 0;
            StopIndex = 0;
            int thumbSet = RobotImageLoader.thumbSet;
            VideoProcessingClass class2 = new VideoProcessingClass();
            List<PhotoInfo> source = new List<PhotoInfo>();
            source = (from t in phBiz.GetAllPhotosforSearch(LoginUser.DefaultSubstores, Convert.ToInt64(RFID), thumbSet, LoginUser.IsPhotographerSerailSearchActive, StartIndexRFID, _rfidSearch, NewRecord, out MaxPhotoIdCriteria, out MinPhotoIdCriteria, MediaTypes)
                orderby t.DG_Photos_pkey descending
                select t).ToList<PhotoInfo>();
            List<PhotoInfo> list2 = new List<PhotoInfo>();
            if (!LoginUser.IsPhotographerSerailSearchActive)
            {
                if (_rfidSearch == 0)
                {
                    list2 = (from T in source
                        where T.DG_Photos_RFID == RFID
                        select T).ToList<PhotoInfo>();
                }
                else
                {
                    list2 = source.ToList<PhotoInfo>();
                }
            }
            else
            {
                list2 = source.ToList<PhotoInfo>();
            }
            if (list2.Count != 0)
            {
                int imageid = list2.First<PhotoInfo>().DG_Photos_pkey;
                List<PhotoInfo> list3 = (from t in source
                    where t.DG_Photos_pkey < imageid
                    orderby t.DG_Photos_pkey descending
                    select t).ToList<PhotoInfo>();
                if (list3.Count > thumbSet)
                {
                    list3 = list3.Take<PhotoInfo>(thumbSet).ToList<PhotoInfo>();
                }
                list3 = (from t in list3
                    orderby t.DG_Photos_pkey
                    select t).ToList<PhotoInfo>().Union<PhotoInfo>(list2).ToList<PhotoInfo>();
                List<PhotoInfo> list4 = (from t in source
                    where t.DG_Photos_pkey > imageid
                    orderby t.DG_Photos_pkey
                    select t).ToList<PhotoInfo>();
                if (list4.Count > thumbSet)
                {
                    list4 = list4.Take<PhotoInfo>(thumbSet).ToList<PhotoInfo>();
                }
                list3 = list3.Union<PhotoInfo>(list4).ToList<PhotoInfo>();
                using (List<PhotoInfo>.Enumerator enumerator = list3.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Func<ModratePhotoInfo, bool> predicate = null;
                        Func<LstMyItems, bool> func2 = null;
                        Func<LstMyItems, bool> func3 = null;
                        PhotoInfo item = enumerator.Current;
                        LstMyItems items = new LstMyItems {
                            Name = item.DG_Photos_RFID,
                            FileName = item.DG_Photos_FileName,
                            PhotoId = item.DG_Photos_pkey,
                            HotFolderPath = item.HotFolderPath,
                            MediaType = item.DG_MediaType,
                            CreatedOn = item.DG_Photos_CreatedOn,
                            VideoLength = item.DG_VideoLength,
                            OnlineQRCode = item.OnlineQRCode
                        };
                        if (predicate == null)
                        {
                            predicate = x => x.DG_Mod_Photo_ID == item.DG_Photos_pkey;
                        }
                        IEnumerable<ModratePhotoInfo> enumerable = moderatePhotosList.AsEnumerable<ModratePhotoInfo>().Where<ModratePhotoInfo>(predicate);
                        if ((enumerable != null) && (enumerable.Count<ModratePhotoInfo>() > 0))
                        {
                            items.FilePath = items.HotFolderPath + "/Locked.png";
                            items.IsLocked = Visibility.Collapsed;
                            items.IsPassKeyVisible = Visibility.Visible;
                        }
                        else
                        {
                            string str = item.DG_Photos_FileName.Replace(class2.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mts"].ToString(), ".jpg");
                            items.BigThumbnailPath = Path.Combine(items.BigDBThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), str);
                            items.FilePath = Path.Combine(items.ThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), str);
                            items.IsLocked = Visibility.Visible;
                            if (string.IsNullOrEmpty(item.DG_Photos_Layering) && !string.IsNullOrEmpty(LoginUser.DefaultBorderPath))
                            {
                                items.FrameBrdr = LoginUser.DefaultBorderPath;
                            }
                            items.IsPassKeyVisible = Visibility.Collapsed;
                            items.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                        }
                        if (GroupImages != null)
                        {
                            if (func2 == null)
                            {
                                func2 = t => t.PhotoId == item.DG_Photos_pkey;
                            }
                            if (GroupImages.Where<LstMyItems>(func2).FirstOrDefault<LstMyItems>() != null)
                            {
                                items.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                            }
                            else
                            {
                                items.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                            }
                        }
                        else
                        {
                            items.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                        }
                        if (PrintImages != null)
                        {
                            if (func3 == null)
                            {
                                func3 = t => t.PhotoId == item.DG_Photos_pkey;
                            }
                            if (PrintImages.Where<LstMyItems>(func3).FirstOrDefault<LstMyItems>() != null)
                            {
                                items.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                            }
                            else
                            {
                                items.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                            }
                        }
                        else
                        {
                            items.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        }
                        if (Is9ImgViewActive)
                        {
                            items.GridMainHeight = 190;
                            items.GridMainWidth = 0xe2;
                            items.GridMainRowHeight1 = 140;
                            items.GridMainRowHeight2 = 50;
                        }
                        else
                        {
                            items.GridMainHeight = 140;
                            items.GridMainWidth = 170;
                            items.GridMainRowHeight1 = 90;
                            items.GridMainRowHeight2 = 60;
                        }
                        temprobotImages.Add(items);
                    }
                }
            }
        }

        private static void SelectPhotoByTime(List<LstMyItems> temprobotImages, List<ModratePhotoInfo> moderatePhotosList, PhotoBusiness phBiz)
        {
            GroupId = "";
            IsZeroSearchNeeded = false;
            StartIndex = 0;
            StopIndex = 0;
            if (string.IsNullOrEmpty(SearchedStoreId))
            {
                SearchedStoreId = LoginUser.DefaultSubstores;
            }
            List<PhotoInfo> list = phBiz.GetSearchedPhoto(new DateTime?(FromTime), new DateTime?(ToTime), new int?(UserId), new int?(LocationId), SearchedStoreId);
            VideoProcessingClass class2 = new VideoProcessingClass();
            using (List<PhotoInfo>.Enumerator enumerator = list.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    Func<ModratePhotoInfo, bool> predicate = null;
                    Func<LstMyItems, bool> func2 = null;
                    Func<LstMyItems, bool> func3 = null;
                    PhotoInfo photoItem = enumerator.Current;
                    LstMyItems item = new LstMyItems {
                        Name = photoItem.DG_Photos_RFID,
                        PhotoId = photoItem.DG_Photos_pkey,
                        FileName = photoItem.DG_Photos_FileName,
                        HotFolderPath = photoItem.HotFolderPath,
                        MediaType = photoItem.DG_MediaType,
                        VideoLength = photoItem.DG_VideoLength,
                        CreatedOn = photoItem.DG_Photos_CreatedOn,
                        OnlineQRCode = photoItem.OnlineQRCode
                    };
                    if (predicate == null)
                    {
                        predicate = x => x.DG_Mod_Photo_ID == photoItem.DG_Photos_pkey;
                    }
                    IEnumerable<ModratePhotoInfo> source = moderatePhotosList.AsEnumerable<ModratePhotoInfo>().Where<ModratePhotoInfo>(predicate);
                    if ((source != null) && (source.Count<ModratePhotoInfo>() > 0))
                    {
                        item.FilePath = item.HotFolderPath + "/Locked.png";
                        item.IsLocked = Visibility.Collapsed;
                        item.IsPassKeyVisible = Visibility.Visible;
                    }
                    else
                    {
                        string str = photoItem.DG_Photos_FileName.Replace(class2.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mts"].ToString(), ".jpg");
                        item.BigThumbnailPath = Path.Combine(item.BigDBThumnailPath, photoItem.DG_Photos_CreatedOn.ToString("yyyyMMdd"), str);
                        item.FilePath = Path.Combine(item.ThumnailPath, photoItem.DG_Photos_CreatedOn.ToString("yyyyMMdd"), str);
                        item.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                        item.IsLocked = Visibility.Visible;
                        item.IsPassKeyVisible = Visibility.Collapsed;
                    }
                    if (GroupImages != null)
                    {
                        if (func2 == null)
                        {
                            func2 = t => t.PhotoId == photoItem.DG_Photos_pkey;
                        }
                        if (GroupImages.Where<LstMyItems>(func2).FirstOrDefault<LstMyItems>() != null)
                        {
                            item.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                        }
                        else
                        {
                            item.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                        }
                    }
                    else
                    {
                        item.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                    }
                    if (PrintImages != null)
                    {
                        if (func3 == null)
                        {
                            func3 = t => t.PhotoId == photoItem.DG_Photos_pkey;
                        }
                        if (PrintImages.Where<LstMyItems>(func3).FirstOrDefault<LstMyItems>() != null)
                        {
                            item.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                        }
                        else
                        {
                            item.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        }
                    }
                    else
                    {
                        item.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                    }
                    if (Is9ImgViewActive)
                    {
                        item.GridMainHeight = 190;
                        item.GridMainWidth = 0xe2;
                        item.GridMainRowHeight1 = 140;
                        item.GridMainRowHeight2 = 50;
                    }
                    else
                    {
                        item.GridMainHeight = 140;
                        item.GridMainWidth = 170;
                        item.GridMainRowHeight1 = 90;
                        item.GridMainRowHeight2 = 60;
                    }
                    temprobotImages.Add(item);
                }
            }
        }

        private static List<LstMyItems> SelectPhotoByTimeAndQRCode(List<LstMyItems> temprobotImages, SearchDetailInfo Searchdetails, SearchCriteriaInfo SearchBiz, List<ModratePhotoInfo> moderatePhotosList)
        {
            if (robotImages == null)
            {
                robotImages = new List<LstMyItems>();
            }
            if (GroupImages == null)
            {
                GroupImages = new List<LstMyItems>();
            }
            if (PrintImages == null)
            {
                PrintImages = new List<LstMyItems>();
            }
            GroupId = "";
            IsZeroSearchNeeded = false;
            StartIndex = 0;
            StopIndex = 0;
            Searchdetails.FromDate = FromTime;
            Searchdetails.ToDate = ToTime;
            Searchdetails.Locationid = LocationId;
            Searchdetails.Userid = UserId;
            Searchdetails.PageSize = thumbSet;
            Searchdetails.SubstoreId = (SearchedStoreId == "0") ? null : SearchedStoreId;
            Searchdetails.CharacterId = CharacterId;
            Searchdetails.Qrcode = Code;
            Searchdetails.IsAnonymousQrcodeEnabled = IsAnonymousQrCodeEnabled;
            List<SearchDetailInfo> source = (from o in SearchBiz.GetSearchDetailWithQrcode(Searchdetails, out MaxPhotoIdCriteria, out MinPhotoIdCriteria, out ImgCount, MediaTypes)
                orderby o.PhotoId descending
                select o).ToList<SearchDetailInfo>();
            VideoProcessingClass class2 = new VideoProcessingClass();
            if (source.Count > 0)
            {
                Searchdetails.TotalRecords = source.FirstOrDefault<SearchDetailInfo>().TotalRecords;
                using (List<SearchDetailInfo>.Enumerator enumerator = source.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        Func<ModratePhotoInfo, bool> predicate = null;
                        Func<LstMyItems, bool> func2 = null;
                        Func<LstMyItems, bool> func3 = null;
                        SearchDetailInfo photoItem = enumerator.Current;
                        LstMyItems item = new LstMyItems {
                            OnlineQRCode = photoItem.OnlineQRCode,
                            Name = photoItem.Name,
                            PhotoId = photoItem.PhotoId,
                            FileName = photoItem.FileName,
                            HotFolderPath = photoItem.HotFolderPath,
                            MediaType = photoItem.MediaType,
                            VideoLength = photoItem.VideoLength,
                            CreatedOn = photoItem.CreatedOn
                        };
                        if (predicate == null)
                        {
                            predicate = x => x.DG_Mod_Photo_ID == photoItem.PhotoId;
                        }
                        IEnumerable<ModratePhotoInfo> enumerable = moderatePhotosList.AsEnumerable<ModratePhotoInfo>().Where<ModratePhotoInfo>(predicate);
                        if ((enumerable != null) && (enumerable.Count<ModratePhotoInfo>() > 0))
                        {
                            item.FilePath = item.HotFolderPath + "/Locked.png";
                            item.IsLocked = Visibility.Collapsed;
                            item.IsPassKeyVisible = Visibility.Visible;
                        }
                        else
                        {
                            string str = photoItem.FileName.Replace(class2.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mts"].ToString(), ".jpg");
                            item.BigThumbnailPath = Path.Combine(item.BigDBThumnailPath, photoItem.CreatedOn.ToString("yyyyMMdd"), str);
                            item.FilePath = Path.Combine(item.ThumnailPath, photoItem.CreatedOn.ToString("yyyyMMdd"), str);
                            item.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                            item.IsLocked = Visibility.Visible;
                            item.IsPassKeyVisible = Visibility.Collapsed;
                        }
                        if (GroupImages != null)
                        {
                            if (func2 == null)
                            {
                                func2 = t => t.PhotoId == photoItem.PhotoId;
                            }
                            if (GroupImages.Where<LstMyItems>(func2).FirstOrDefault<LstMyItems>() != null)
                            {
                                item.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                            }
                            else
                            {
                                item.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                            }
                        }
                        else
                        {
                            item.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                        }
                        if (PrintImages != null)
                        {
                            if (func3 == null)
                            {
                                func3 = t => t.PhotoId == photoItem.PhotoId;
                            }
                            if (PrintImages.Where<LstMyItems>(func3).FirstOrDefault<LstMyItems>() != null)
                            {
                                item.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                            }
                            else
                            {
                                item.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                            }
                        }
                        else
                        {
                            item.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                        }
                        if (Is9ImgViewActive)
                        {
                            item.GridMainHeight = 190;
                            item.GridMainWidth = 0xe2;
                            item.GridMainRowHeight1 = 140;
                            item.GridMainRowHeight2 = 50;
                        }
                        else
                        {
                            item.GridMainHeight = 140;
                            item.GridMainWidth = 170;
                            item.GridMainRowHeight1 = 90;
                            item.GridMainRowHeight2 = 60;
                        }
                        temprobotImages.Add(item);
                    }
                }
                return temprobotImages;
            }
            temprobotImages = new List<LstMyItems>();
            return temprobotImages;
        }

        private static void SelectPhotoByZeroSearch(List<LstMyItems> temprobotImages, string ssInfo, List<ModratePhotoInfo> moderatePhotosList, PhotoBusiness phBiz, int mediaType)
        {
            GroupId = "";
            int startIndex = 0;
            if ((currentCount == 0) && IsZeroSearchNeeded)
            {
                startIndex = -1;
            }
            else
            {
                if (!(((_objnewincrement == null) || (_objnewincrement.Count <= 0)) || IsNextPage))
                {
                    startIndex = _objnewincrement[_objnewincrement.Count - 1].PhotoId;
                }
                else if (((_objnewincrement != null) && (_objnewincrement.Count > 0)) && IsNextPage)
                {
                    startIndex = _objnewincrement[0].PhotoId;
                }
                else
                {
                    startIndex = -1;
                }
                if ((!IsZeroSearchNeeded && (currentCount == 0)) && (StartIndex != 0))
                {
                    if (!IsNextPage)
                    {
                        startIndex = StartIndex;
                    }
                    else
                    {
                        startIndex = StopIndex;
                    }
                }
                if (IsPreview9or16active)
                {
                    startIndex = StartIndex + 1;
                    IsPreview9or16active = false;
                }
            }
            IsZeroSearchNeeded = false;
            StartIndex = 0;
            StopIndex = 0;
            List<PhotoInfo> list = new List<PhotoInfo>();
            if (_objnewincrement == null)
            {
                _objnewincrement = new List<LstMyItems>();
            }
            _objnewincrement.Clear();
            if (IsNextPage)
            {
                list = (from x in phBiz.GetAllPhotosByPage(ssInfo, startIndex, thumbSet, IsNextPage, out MaxPhotoId, out IsMoreNextImages, out MinPhotoId, mediaType)
                    orderby x.DG_Photos_pkey descending
                    select x).ToList<PhotoInfo>();
                IsMorePrevImages = true;
            }
            else
            {
                list = phBiz.GetAllPhotosByPage(ssInfo, startIndex, thumbSet, IsNextPage, out MaxPhotoId, out IsMorePrevImages, out MinPhotoId, mediaType).ToList<PhotoInfo>();
                IsMoreNextImages = (startIndex != -1) && ((MaxPhotoId + 1L) != startIndex);
            }
            IsNextPage = false;
            totalCount = list.Count;
            startLoad = 0;
            VideoProcessingClass class2 = new VideoProcessingClass();
            for (int i = 0; i < totalCount; i++)
            {
                Func<LstMyItems, bool> predicate = null;
                Func<LstMyItems, bool> func2 = null;
                PhotoInfo item = list[i];
                LstMyItems items = new LstMyItems();
                IEnumerable<ModratePhotoInfo> source = from x in moderatePhotosList.AsEnumerable<ModratePhotoInfo>()
                    where x.DG_Mod_Photo_ID == item.DG_Photos_pkey
                    select x;
                items.Name = item.DG_Photos_RFID;
                items.FileName = item.DG_Photos_FileName;
                items.ListPosition = currentCount;
                items.PhotoId = item.DG_Photos_pkey;
                items.HotFolderPath = item.HotFolderPath;
                items.MediaType = item.DG_MediaType;
                items.CreatedOn = item.DG_Photos_CreatedOn;
                items.VideoLength = item.DG_VideoLength;
                items.OnlineQRCode = item.OnlineQRCode;
                if ((source != null) && (source.Count<ModratePhotoInfo>() > 0))
                {
                    items.FilePath = items.HotFolderPath + "/Locked.png";
                    items.IsLocked = Visibility.Collapsed;
                    items.IsPassKeyVisible = Visibility.Visible;
                }
                else
                {
                    string str = item.DG_Photos_FileName.Replace(class2.SupportedVideoFormats["avi"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mp4"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["wmv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mov"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3gp"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["3g2"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m2v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["m4v"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["flv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mpeg"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mkv"].ToString(), ".jpg").Replace(class2.SupportedVideoFormats["mts"].ToString(), ".jpg");
                    items.BigThumbnailPath = Path.Combine(items.BigDBThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), str);
                    items.FilePath = Path.Combine(items.ThumnailPath, item.DG_Photos_CreatedOn.ToString("yyyyMMdd"), str);
                    if (string.IsNullOrEmpty(item.DG_Photos_Layering) && !string.IsNullOrEmpty(LoginUser.DefaultBorderPath))
                    {
                        items.FrameBrdr = LoginUser.DefaultBorderPath;
                    }
                    items.IsLocked = Visibility.Visible;
                    items.IsPassKeyVisible = Visibility.Collapsed;
                }
                if (GroupImages != null)
                {
                    if (predicate == null)
                    {
                        predicate = t => t.PhotoId == item.DG_Photos_pkey;
                    }
                    if (GroupImages.Where<LstMyItems>(predicate).FirstOrDefault<LstMyItems>() != null)
                    {
                        items.BmpImageGroup = new BitmapImage(new Uri("/images/view-accept.png", UriKind.Relative));
                    }
                    else
                    {
                        items.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                    }
                }
                else
                {
                    items.BmpImageGroup = new BitmapImage(new Uri("/images/view-group.png", UriKind.Relative));
                }
                if (PrintImages != null)
                {
                    if (func2 == null)
                    {
                        func2 = t => t.PhotoId == item.DG_Photos_pkey;
                    }
                    if (PrintImages.Where<LstMyItems>(func2).FirstOrDefault<LstMyItems>() != null)
                    {
                        items.PrintGroup = new BitmapImage(new Uri("/images/print-accept.png", UriKind.Relative));
                    }
                    else
                    {
                        items.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                    }
                }
                else
                {
                    items.PrintGroup = new BitmapImage(new Uri("/images/print-group.png", UriKind.Relative));
                }
                if (!(IsPreviewModeActive || !Is9ImgViewActive))
                {
                    items.GridMainHeight = 190;
                    items.GridMainWidth = 0xe2;
                    items.GridMainRowHeight1 = 140;
                    items.GridMainRowHeight2 = 50;
                }
                else if (!(IsPreviewModeActive || !Is16ImgViewActive))
                {
                    items.GridMainHeight = 140;
                    items.GridMainWidth = 170;
                    items.GridMainRowHeight1 = 90;
                    items.GridMainRowHeight2 = 60;
                }
                else
                {
                    items.GridMainHeight = 140;
                    items.GridMainWidth = 170;
                    items.GridMainRowHeight1 = 90;
                    items.GridMainRowHeight2 = 60;
                }
                temprobotImages.Add(items);
                if (_objnewincrement == null)
                {
                    _objnewincrement = new List<LstMyItems>();
                }
                _objnewincrement.Add(items);
                startLoad++;
                currentCount++;
            }
        }
    }
}

