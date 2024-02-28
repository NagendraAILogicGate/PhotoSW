using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
{
    public class baConfigurationInfo
    {

        public int Id { get; set; }
        public int DefaultCurrency { get; set; }
        public int? DefaultCurrencyId { get; set; }
        public bool? PS_AllowDiscount { get; set; }
        public string PS_BG_Path { get; set; }
        public double? PS_Brightness { get; set; }
        public string PS_ChromaColor { get; set; }
        public decimal? PS_ChromaTolerance { get; set; }
        public int? PS_CleanUpDaysBackUp { get; set; }
        public string PS_CleanupTables { get; set; }
        public int PS_Config_pkey { get; set; }
        public double? PS_Contrast { get; set; }
        public string PS_DbBackupPath { get; set; }
        public bool? PS_EnableDiscountOnTotal { get; set; }
        public string PS_Frame_Path { get; set; }
        public string PS_Graphics_Path { get; set; }
        public string PS_HfBackupPath { get; set; }
        public bool? PS_HighResolution { get; set; }
        public string PS_Hot_Folder_Path { get; set; }
        public bool? PS_IsAutoRotate { get; set; }
        public bool? PS_IsBackupScheduled { get; set; }
        public bool? PS_IsCompression { get; set; }
        public bool? PS_IsEnableGroup { get; set; }
        public string PS_MktImgPath { get; set; }
        public int? PS_MktImgTimeInSec { get; set; }
        public string PS_Mod_Password { get; set; }
        public int? PS_NoOfBillReceipt { get; set; }
        public int? PS_NoOfPhotoIdSearch { get; set; }
        public int? PS_NoOfPhotos { get; set; }
        public int? PS_PageCountGrid { get; set; }
        public int? PS_PageCountPreview { get; set; }
        public string PS_ReceiptPrinter { get; set; }
        public string PS_ScheduleBackup { get; set; }
        public bool? PS_SemiOrder { get; set; }
        public bool? PS_SemiOrderMain { get; set; }
        public int? PS_Substore_Id { get; set; }
        public bool? PS_Watermark { get; set; }
        public int? EK_DisplayDuration { get; set; }
        public bool? EK_IsScreenSaverActive { get; set; }
        public string EK_SampleImagePath { get; set; }
        public int? EK_ScreenStartTime { get; set; }
        public decimal? FolderStartingNumber { get; set; }
        public string FtpFolder { get; set; }
        public string FtpIP { get; set; }
        public string FtpPwd { get; set; }
        public string FtpUid { get; set; }
        public int? IntervalCount { get; set; }
        public int? intervalType { get; set; }
        public bool? IsAutoLock { get; set; }
        public bool? IsDeleteFromUSB { get; set; }
        public bool? IsExportReportToAnyDrive { get; set; }
        public bool? IsRecursive { get; set; }
        public bool IsSynced { get; set; }
        public bool? PosOnOff { get; set; }
        public string SyncCode { get; set; }
        public decimal? WiFiStartingNumber { get; set; }

        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<configurationinfo> lst_companydetail = new List<configurationinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    //foreach (var item in lst_str)
                    //{
                    configurationinfo configurationinfo = new configurationinfo();

                    configurationinfo.Id = 1;
                    configurationinfo.DefaultCurrency = 1;
                    configurationinfo.DefaultCurrencyId = 1;
                    configurationinfo.PS_AllowDiscount = false;
                    configurationinfo.PS_BG_Path = "Backgrounds\\";
                    configurationinfo.PS_Brightness = 0;
                    configurationinfo.PS_ChromaColor = "#008000";
                    configurationinfo.PS_ChromaTolerance = 0;
                    configurationinfo.PS_CleanUpDaysBackUp = 0;
                    configurationinfo.PS_CleanupTables = "";
                    configurationinfo.PS_Config_pkey = 0;
                    configurationinfo.PS_Contrast = 0;
                    configurationinfo.PS_DbBackupPath = "DbBackupPath\\";
                    configurationinfo.PS_EnableDiscountOnTotal = false;
                    configurationinfo.PS_Frame_Path = "Frames\\";
                    configurationinfo.PS_Graphics_Path = "Graphics\\";
                    configurationinfo.PS_HfBackupPath = "HfBackupPath\\";
                    configurationinfo.PS_HighResolution = false;
                    configurationinfo.PS_Hot_Folder_Path = "HotFolderPath\\";
                    configurationinfo.PS_IsAutoRotate = true;
                    configurationinfo.PS_IsBackupScheduled = true;
                    configurationinfo.PS_IsCompression = true;
                    configurationinfo.PS_IsEnableGroup = true;
                    configurationinfo.PS_MktImgPath = "MktImgPath\\";
                    configurationinfo.PS_MktImgTimeInSec = 0;
                    configurationinfo.PS_Mod_Password = "123456";
                    configurationinfo.PS_NoOfBillReceipt = 1;
                    configurationinfo.PS_NoOfPhotoIdSearch = 1;
                    configurationinfo.PS_NoOfPhotos = 1;
                    configurationinfo.PS_PageCountGrid = 1;
                    configurationinfo.PS_PageCountPreview = 1;
                    configurationinfo.PS_ReceiptPrinter = "";
                    configurationinfo.PS_ScheduleBackup = "";
                    configurationinfo.PS_SemiOrder = false;
                    configurationinfo.PS_SemiOrderMain = false;
                    configurationinfo.PS_Substore_Id = 3;
                    configurationinfo.PS_Watermark = true;
                    configurationinfo.EK_DisplayDuration = 2;
                    configurationinfo.EK_IsScreenSaverActive = true;
                    configurationinfo.EK_SampleImagePath = "SampleImagePath\\";
                    configurationinfo.EK_ScreenStartTime = 3;
                    configurationinfo.FolderStartingNumber = 2;
                    configurationinfo.FtpFolder = "";
                    configurationinfo.FtpIP = "";
                    configurationinfo.FtpPwd = "123456";
                    configurationinfo.FtpUid = "";
                    configurationinfo.IntervalCount = 4;
                    configurationinfo.intervalType = 4;
                    configurationinfo.IsAutoLock = false;
                    configurationinfo.IsDeleteFromUSB = false;
                    configurationinfo.IsExportReportToAnyDrive = false;
                    configurationinfo.IsRecursive = false;
                    configurationinfo.IsSynced = false;
                    configurationinfo.PosOnOff = false;
                    configurationinfo.SyncCode = "123456";
                    configurationinfo.WiFiStartingNumber = 12;

                    configurationinfo.IsActive = true;


                    lst_companydetail.Add(configurationinfo);
                    // }
                    var Id = lst_companydetail.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ConfigurationInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ConfigurationInfos.AddRange(lst_companydetail);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ConfigurationInfos.AddRange(lst_companydetail);
                        db.SaveChanges();
                        }
                    return true;
                    }
                }
            catch(Exception ex)
                {
                return false;
                }
            }

        public static List<baConfigurationInfo> GetConfigurationData()
        {
            baConfigurationInfo baConfigurationInfo = new baConfigurationInfo();
            using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.ConfigurationInfos.Where(p => p.IsActive == true).Select(p => new baConfigurationInfo
                    {
                        Id = p.Id,
                        DefaultCurrency = p.DefaultCurrency,
                        DefaultCurrencyId = p.DefaultCurrencyId,
                        PS_AllowDiscount = p.PS_AllowDiscount,
                        PS_BG_Path = p.PS_BG_Path,
                        PS_Brightness = p.PS_Brightness,
                        PS_ChromaColor = p.PS_ChromaColor,
                        PS_ChromaTolerance = p.PS_ChromaTolerance,
                        PS_CleanUpDaysBackUp = p.PS_CleanUpDaysBackUp,
                        PS_CleanupTables = p.PS_CleanupTables,
                        PS_Config_pkey = p.PS_Config_pkey,
                        PS_Contrast = p.PS_Contrast,
                        PS_DbBackupPath = p.PS_DbBackupPath,
                        PS_EnableDiscountOnTotal = p.PS_EnableDiscountOnTotal,
                        PS_Frame_Path = p.PS_Frame_Path,
                        PS_Graphics_Path = p.PS_Graphics_Path,
                        PS_HfBackupPath = p.PS_HfBackupPath,
                        PS_HighResolution = p.PS_HighResolution,
                        PS_Hot_Folder_Path = p.PS_Hot_Folder_Path,
                        PS_IsAutoRotate = p.PS_IsAutoRotate,
                        PS_IsBackupScheduled = p.PS_IsBackupScheduled,
                        PS_IsCompression = p.PS_IsCompression,
                        PS_IsEnableGroup = p.PS_IsEnableGroup,
                        PS_MktImgPath = p.PS_MktImgPath,
                        PS_MktImgTimeInSec = p.PS_MktImgTimeInSec,
                        PS_Mod_Password = p.PS_Mod_Password,
                        PS_NoOfBillReceipt = p.PS_NoOfBillReceipt,
                        PS_NoOfPhotoIdSearch = p.PS_NoOfPhotoIdSearch,
                        PS_NoOfPhotos = p.PS_NoOfPhotos,
                        PS_PageCountGrid = p.PS_PageCountGrid,
                        PS_PageCountPreview = p.PS_PageCountPreview,
                        PS_ReceiptPrinter = p.PS_ReceiptPrinter,
                        PS_ScheduleBackup = p.PS_ScheduleBackup,
                        PS_SemiOrder = p.PS_SemiOrder,
                        PS_SemiOrderMain = p.PS_SemiOrderMain,
                        PS_Substore_Id = p.PS_Substore_Id,
                        PS_Watermark = p.PS_Watermark,
                        EK_DisplayDuration = p.EK_DisplayDuration,
                        EK_IsScreenSaverActive = p.EK_IsScreenSaverActive,
                        EK_SampleImagePath = p.EK_SampleImagePath,
                        EK_ScreenStartTime = p.EK_ScreenStartTime,
                        FolderStartingNumber = p.FolderStartingNumber,
                        FtpFolder = p.FtpFolder,
                        FtpIP = p.FtpIP,
                        FtpPwd = p.FtpPwd,
                        FtpUid = p.FtpUid,
                        IntervalCount = p.IntervalCount,
                        intervalType = p.intervalType,
                        IsAutoLock = p.IsAutoLock,
                        IsDeleteFromUSB = p.IsDeleteFromUSB,
                        IsExportReportToAnyDrive = p.IsExportReportToAnyDrive,
                        IsRecursive = p.IsRecursive,
                        IsSynced = p.IsSynced,
                        PosOnOff = p.PosOnOff,
                        SyncCode = p.SyncCode,
                        WiFiStartingNumber = p.WiFiStartingNumber,
                        IsActive = p.IsActive,
                    }).ToList();
                    return obj;
                 }
        }

        public static baConfigurationInfo GetConfigurationData(int Substore_Id)
        {
            try
            {

                configurationinfo configurationinfo = new configurationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.ConfigurationInfos.Where(p => p.PS_Substore_Id == Substore_Id && p.IsActive == true).Select(p => new baConfigurationInfo
                    {
                        Id = p.Id,
                        DefaultCurrency =p.DefaultCurrency,
                           DefaultCurrencyId = p.DefaultCurrencyId,
                           PS_AllowDiscount = p.PS_AllowDiscount,
                           PS_BG_Path = p.PS_BG_Path,
                           PS_Brightness = p.PS_Brightness,
                           PS_ChromaColor = p.PS_ChromaColor,
                           PS_ChromaTolerance = p.PS_ChromaTolerance,
                           PS_CleanUpDaysBackUp = p.PS_CleanUpDaysBackUp,
                           PS_CleanupTables = p.PS_CleanupTables,
                           PS_Config_pkey = p.PS_Config_pkey,
                           PS_Contrast = p.PS_Contrast,
                           PS_DbBackupPath = p.PS_DbBackupPath,
                           PS_EnableDiscountOnTotal = p.PS_EnableDiscountOnTotal,
                           PS_Frame_Path = p.PS_Frame_Path,
                           PS_Graphics_Path = p.PS_Graphics_Path,
                           PS_HfBackupPath = p.PS_HfBackupPath,
                           PS_HighResolution = p.PS_HighResolution,
                           PS_Hot_Folder_Path = p.PS_Hot_Folder_Path,
                           PS_IsAutoRotate = p.PS_IsAutoRotate,
                           PS_IsBackupScheduled = p.PS_IsBackupScheduled,
                           PS_IsCompression = p.PS_IsCompression,
                           PS_IsEnableGroup = p.PS_IsEnableGroup,
                           PS_MktImgPath = p.PS_MktImgPath,
                           PS_MktImgTimeInSec = p.PS_MktImgTimeInSec,
                           PS_Mod_Password = p.PS_Mod_Password,
                           PS_NoOfBillReceipt = p.PS_NoOfBillReceipt,
                           PS_NoOfPhotoIdSearch = p.PS_NoOfPhotoIdSearch,
                           PS_NoOfPhotos = p.PS_NoOfPhotos,
                           PS_PageCountGrid = p.PS_PageCountGrid,
                           PS_PageCountPreview = p.PS_PageCountPreview,
                           PS_ReceiptPrinter = p.PS_ReceiptPrinter,
                           PS_ScheduleBackup = p.PS_ScheduleBackup,
                           PS_SemiOrder = p.PS_SemiOrder,
                           PS_SemiOrderMain = p.PS_SemiOrderMain,
                           PS_Substore_Id = p.PS_Substore_Id,
                           PS_Watermark = p.PS_Watermark,
                           EK_DisplayDuration =p.EK_DisplayDuration,
                           EK_IsScreenSaverActive = p.EK_IsScreenSaverActive,
                           EK_SampleImagePath =p.EK_SampleImagePath,
                           EK_ScreenStartTime = p.EK_ScreenStartTime,
                           FolderStartingNumber = p.FolderStartingNumber,
                           FtpFolder = p.FtpFolder,
                           FtpIP = p.FtpIP,
                           FtpPwd = p.FtpPwd,
                           FtpUid =p.FtpUid,
                           IntervalCount = p.IntervalCount,
                           intervalType = p.intervalType,
                           IsAutoLock = p.IsAutoLock,
                           IsDeleteFromUSB = p.IsDeleteFromUSB,
                           IsExportReportToAnyDrive = p.IsExportReportToAnyDrive,
                           IsRecursive = p.IsRecursive,
                           IsSynced = p.IsSynced,
                           PosOnOff = p.PosOnOff,
                           SyncCode = p.SyncCode,
                           WiFiStartingNumber = p.WiFiStartingNumber,

                        IsActive = p.IsActive,

                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }
        public static baConfigurationInfo GetConfigurationInfoDataById(int Id)
        {
            try
            {

                configurationinfo configurationinfo = new configurationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.ConfigurationInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baConfigurationInfo
                    {
                        Id = p.Id,
                        DefaultCurrency =p.DefaultCurrency,
                           DefaultCurrencyId = p.DefaultCurrencyId,
                           PS_AllowDiscount = p.PS_AllowDiscount,
                           PS_BG_Path = p.PS_BG_Path,
                           PS_Brightness = p.PS_Brightness,
                           PS_ChromaColor = p.PS_ChromaColor,
                           PS_ChromaTolerance = p.PS_ChromaTolerance,
                           PS_CleanUpDaysBackUp = p.PS_CleanUpDaysBackUp,
                           PS_CleanupTables = p.PS_CleanupTables,
                           PS_Config_pkey = p.PS_Config_pkey,
                           PS_Contrast = p.PS_Contrast,
                           PS_DbBackupPath = p.PS_DbBackupPath,
                           PS_EnableDiscountOnTotal = p.PS_EnableDiscountOnTotal,
                           PS_Frame_Path = p.PS_Frame_Path,
                           PS_Graphics_Path = p.PS_Graphics_Path,
                           PS_HfBackupPath = p.PS_HfBackupPath,
                           PS_HighResolution = p.PS_HighResolution,
                           PS_Hot_Folder_Path = p.PS_Hot_Folder_Path,
                           PS_IsAutoRotate = p.PS_IsAutoRotate,
                           PS_IsBackupScheduled = p.PS_IsBackupScheduled,
                           PS_IsCompression = p.PS_IsCompression,
                           PS_IsEnableGroup = p.PS_IsEnableGroup,
                           PS_MktImgPath = p.PS_MktImgPath,
                           PS_MktImgTimeInSec = p.PS_MktImgTimeInSec,
                           PS_Mod_Password = p.PS_Mod_Password,
                           PS_NoOfBillReceipt = p.PS_NoOfBillReceipt,
                           PS_NoOfPhotoIdSearch = p.PS_NoOfPhotoIdSearch,
                           PS_NoOfPhotos = p.PS_NoOfPhotos,
                           PS_PageCountGrid = p.PS_PageCountGrid,
                           PS_PageCountPreview = p.PS_PageCountPreview,
                           PS_ReceiptPrinter = p.PS_ReceiptPrinter,
                           PS_ScheduleBackup = p.PS_ScheduleBackup,
                           PS_SemiOrder = p.PS_SemiOrder,
                           PS_SemiOrderMain = p.PS_SemiOrderMain,
                           PS_Substore_Id = p.PS_Substore_Id,
                           PS_Watermark = p.PS_Watermark,
                           EK_DisplayDuration =p.EK_DisplayDuration,
                           EK_IsScreenSaverActive = p.EK_IsScreenSaverActive,
                           EK_SampleImagePath =p.EK_SampleImagePath,
                           EK_ScreenStartTime = p.EK_ScreenStartTime,
                           FolderStartingNumber = p.FolderStartingNumber,
                           FtpFolder = p.FtpFolder,
                           FtpIP = p.FtpIP,
                           FtpPwd = p.FtpPwd,
                           FtpUid =p.FtpUid,
                           IntervalCount = p.IntervalCount,
                           intervalType = p.intervalType,
                           IsAutoLock = p.IsAutoLock,
                           IsDeleteFromUSB = p.IsDeleteFromUSB,
                           IsExportReportToAnyDrive = p.IsExportReportToAnyDrive,
                           IsRecursive = p.IsRecursive,
                           IsSynced = p.IsSynced,
                           PosOnOff = p.PosOnOff,
                           SyncCode = p.SyncCode,
                           WiFiStartingNumber = p.WiFiStartingNumber,

                        IsActive = p.IsActive,

                    }).FirstOrDefault();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }

        public static List<baConfigurationInfo> GetConfigurationInfoData ()
        {
            try
            {

                configurationinfo configurationinfo = new configurationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.ConfigurationInfos.Where(p => p.IsActive == true).Select(p => new baConfigurationInfo
                    {
                        Id = p.Id,
                        DefaultCurrency = p.DefaultCurrency,
                        DefaultCurrencyId = p.DefaultCurrencyId,
                        PS_AllowDiscount = p.PS_AllowDiscount,
                        PS_BG_Path = p.PS_BG_Path,
                        PS_Brightness = p.PS_Brightness,
                        PS_ChromaColor = p.PS_ChromaColor,
                        PS_ChromaTolerance = p.PS_ChromaTolerance,
                        PS_CleanUpDaysBackUp = p.PS_CleanUpDaysBackUp,
                        PS_CleanupTables = p.PS_CleanupTables,
                        PS_Config_pkey = p.PS_Config_pkey,
                        PS_Contrast = p.PS_Contrast,
                        PS_DbBackupPath = p.PS_DbBackupPath,
                        PS_EnableDiscountOnTotal = p.PS_EnableDiscountOnTotal,
                        PS_Frame_Path = p.PS_Frame_Path,
                        PS_Graphics_Path = p.PS_Graphics_Path,
                        PS_HfBackupPath = p.PS_HfBackupPath,
                        PS_HighResolution = p.PS_HighResolution,
                        PS_Hot_Folder_Path = p.PS_Hot_Folder_Path,
                        PS_IsAutoRotate = p.PS_IsAutoRotate,
                        PS_IsBackupScheduled = p.PS_IsBackupScheduled,
                        PS_IsCompression = p.PS_IsCompression,
                        PS_IsEnableGroup = p.PS_IsEnableGroup,
                        PS_MktImgPath = p.PS_MktImgPath,
                        PS_MktImgTimeInSec = p.PS_MktImgTimeInSec,
                        PS_Mod_Password = p.PS_Mod_Password,
                        PS_NoOfBillReceipt = p.PS_NoOfBillReceipt,
                        PS_NoOfPhotoIdSearch = p.PS_NoOfPhotoIdSearch,
                        PS_NoOfPhotos = p.PS_NoOfPhotos,
                        PS_PageCountGrid = p.PS_PageCountGrid,
                        PS_PageCountPreview = p.PS_PageCountPreview,
                        PS_ReceiptPrinter = p.PS_ReceiptPrinter,
                        PS_ScheduleBackup = p.PS_ScheduleBackup,
                        PS_SemiOrder = p.PS_SemiOrder,
                        PS_SemiOrderMain = p.PS_SemiOrderMain,
                        PS_Substore_Id = p.PS_Substore_Id,
                        PS_Watermark = p.PS_Watermark,
                        EK_DisplayDuration = p.EK_DisplayDuration,
                        EK_IsScreenSaverActive = p.EK_IsScreenSaverActive,
                        EK_SampleImagePath = p.EK_SampleImagePath,
                        EK_ScreenStartTime = p.EK_ScreenStartTime,
                        FolderStartingNumber = p.FolderStartingNumber,
                        FtpFolder = p.FtpFolder,
                        FtpIP = p.FtpIP,
                        FtpPwd = p.FtpPwd,
                        FtpUid = p.FtpUid,
                        IntervalCount = p.IntervalCount,
                        intervalType = p.intervalType,
                        IsAutoLock = p.IsAutoLock,
                        IsDeleteFromUSB = p.IsDeleteFromUSB,
                        IsExportReportToAnyDrive = p.IsExportReportToAnyDrive,
                        IsRecursive = p.IsRecursive,
                        IsSynced = p.IsSynced,
                        PosOnOff = p.PosOnOff,
                        SyncCode = p.SyncCode,
                        WiFiStartingNumber = p.WiFiStartingNumber,
                        IsActive = p.IsActive,

                    }).ToList();
                    return obj;
                }
            }
            catch
            {
                return null; ;
            }
        }


        public static bool Insert(baConfigurationInfo baConfigurationInfo)
        {
            try
            {

                configurationinfo configurationinfo = new configurationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    configurationinfo.Id = baConfigurationInfo.Id;
                   configurationinfo. DefaultCurrency = baConfigurationInfo.DefaultCurrency;
                        configurationinfo.DefaultCurrencyId = baConfigurationInfo.DefaultCurrencyId;
                        configurationinfo.PS_AllowDiscount = baConfigurationInfo.PS_AllowDiscount;
                        configurationinfo.PS_BG_Path = baConfigurationInfo.PS_BG_Path;
                        configurationinfo.PS_Brightness =baConfigurationInfo.PS_Brightness;
                        configurationinfo.PS_ChromaColor = baConfigurationInfo.PS_ChromaColor;
                        configurationinfo.PS_ChromaTolerance = baConfigurationInfo.PS_ChromaTolerance;
                        configurationinfo.PS_CleanUpDaysBackUp = baConfigurationInfo.PS_CleanUpDaysBackUp;
                        configurationinfo.PS_CleanupTables = baConfigurationInfo.PS_CleanupTables;
                        configurationinfo.PS_Config_pkey = baConfigurationInfo.PS_Config_pkey;
                        configurationinfo.PS_Contrast = baConfigurationInfo.PS_Contrast;
                        configurationinfo.PS_DbBackupPath = baConfigurationInfo.PS_DbBackupPath;
                        configurationinfo.PS_EnableDiscountOnTotal = baConfigurationInfo.PS_EnableDiscountOnTotal;
                        configurationinfo.PS_Frame_Path = baConfigurationInfo.PS_Frame_Path;
                        configurationinfo.PS_Graphics_Path = baConfigurationInfo.PS_Graphics_Path;
                        configurationinfo.PS_HfBackupPath = baConfigurationInfo.PS_HfBackupPath;
                        configurationinfo.PS_HighResolution = baConfigurationInfo.PS_HighResolution;
                        configurationinfo.PS_Hot_Folder_Path = baConfigurationInfo.PS_Hot_Folder_Path;
                        configurationinfo.PS_IsAutoRotate = baConfigurationInfo.PS_IsAutoRotate;
                        configurationinfo.PS_IsBackupScheduled = baConfigurationInfo.PS_IsBackupScheduled;
                        configurationinfo.PS_IsCompression = baConfigurationInfo.PS_IsCompression;
                        configurationinfo.PS_IsEnableGroup = baConfigurationInfo.PS_IsEnableGroup;
                        configurationinfo.PS_MktImgPath = baConfigurationInfo.PS_MktImgPath;
                        configurationinfo.PS_MktImgTimeInSec = baConfigurationInfo.PS_MktImgTimeInSec;
                        configurationinfo.PS_Mod_Password = baConfigurationInfo.PS_Mod_Password;
                        configurationinfo.PS_NoOfBillReceipt = baConfigurationInfo.PS_NoOfBillReceipt;
                        configurationinfo.PS_NoOfPhotoIdSearch = baConfigurationInfo.PS_NoOfPhotoIdSearch;
                        configurationinfo.PS_NoOfPhotos = baConfigurationInfo.PS_NoOfPhotos;
                        configurationinfo.PS_PageCountGrid = baConfigurationInfo.PS_PageCountGrid;
                        configurationinfo.PS_PageCountPreview = baConfigurationInfo.PS_PageCountPreview;
                        configurationinfo.PS_ReceiptPrinter = baConfigurationInfo.PS_ReceiptPrinter;
                        configurationinfo.PS_ScheduleBackup = baConfigurationInfo.PS_ScheduleBackup;
                        configurationinfo.PS_SemiOrder = baConfigurationInfo.PS_SemiOrder;
                        configurationinfo.PS_SemiOrderMain = baConfigurationInfo.PS_SemiOrderMain;
                        configurationinfo.PS_Substore_Id = baConfigurationInfo.PS_Substore_Id;
                        configurationinfo.PS_Watermark = baConfigurationInfo.PS_Watermark;
                        configurationinfo.EK_DisplayDuration = baConfigurationInfo.EK_DisplayDuration;
                        configurationinfo.EK_IsScreenSaverActive = baConfigurationInfo.EK_IsScreenSaverActive;
                        configurationinfo.EK_SampleImagePath = baConfigurationInfo.EK_SampleImagePath;
                        configurationinfo.EK_ScreenStartTime = baConfigurationInfo.EK_ScreenStartTime;
                        configurationinfo.FolderStartingNumber = baConfigurationInfo.FolderStartingNumber;
                        configurationinfo.FtpFolder = baConfigurationInfo.FtpFolder;
                        configurationinfo.FtpIP = baConfigurationInfo.FtpIP;
                        configurationinfo.FtpPwd = baConfigurationInfo.FtpPwd;
                        configurationinfo.FtpUid = baConfigurationInfo.FtpUid;
                        configurationinfo.IntervalCount = baConfigurationInfo.IntervalCount;
                        configurationinfo.intervalType = baConfigurationInfo.intervalType;
                        configurationinfo.IsAutoLock = baConfigurationInfo.IsAutoLock;
                        configurationinfo.IsDeleteFromUSB = baConfigurationInfo.IsDeleteFromUSB;
                        configurationinfo.IsExportReportToAnyDrive = baConfigurationInfo.IsExportReportToAnyDrive;
                        configurationinfo.IsRecursive = baConfigurationInfo.IsRecursive;
                        configurationinfo.IsSynced = baConfigurationInfo.IsSynced;
                        configurationinfo.PosOnOff = baConfigurationInfo.PosOnOff;
                        configurationinfo.SyncCode = baConfigurationInfo.SyncCode;
                        configurationinfo.WiFiStartingNumber =baConfigurationInfo.WiFiStartingNumber;
                    db.ConfigurationInfos.Add(configurationinfo);
                    db.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Update ( baConfigurationInfo baConfigurationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ConfigurationInfos.Where(p => p.Id == baConfigurationInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        configurationinfo configurationinfo = new configurationinfo();

                        configurationinfo.Id = baConfigurationInfo.Id;
                        configurationinfo.DefaultCurrency = baConfigurationInfo.DefaultCurrency;
                        configurationinfo.DefaultCurrencyId = baConfigurationInfo.DefaultCurrencyId;
                        configurationinfo.PS_AllowDiscount = baConfigurationInfo.PS_AllowDiscount;
                        configurationinfo.PS_BG_Path = baConfigurationInfo.PS_BG_Path;
                        configurationinfo.PS_Brightness = baConfigurationInfo.PS_Brightness;
                        configurationinfo.PS_ChromaColor = baConfigurationInfo.PS_ChromaColor;
                        configurationinfo.PS_ChromaTolerance = baConfigurationInfo.PS_ChromaTolerance;
                        configurationinfo.PS_CleanUpDaysBackUp = baConfigurationInfo.PS_CleanUpDaysBackUp;
                        configurationinfo.PS_CleanupTables = baConfigurationInfo.PS_CleanupTables;
                        configurationinfo.PS_Config_pkey = baConfigurationInfo.PS_Config_pkey;
                        configurationinfo.PS_Contrast = baConfigurationInfo.PS_Contrast;
                        configurationinfo.PS_DbBackupPath = baConfigurationInfo.PS_DbBackupPath;
                        configurationinfo.PS_EnableDiscountOnTotal = baConfigurationInfo.PS_EnableDiscountOnTotal;
                        configurationinfo.PS_Frame_Path = baConfigurationInfo.PS_Frame_Path;
                        configurationinfo.PS_Graphics_Path = baConfigurationInfo.PS_Graphics_Path;
                        configurationinfo.PS_HfBackupPath = baConfigurationInfo.PS_HfBackupPath;
                        configurationinfo.PS_HighResolution = baConfigurationInfo.PS_HighResolution;
                        configurationinfo.PS_Hot_Folder_Path = baConfigurationInfo.PS_Hot_Folder_Path;
                        configurationinfo.PS_IsAutoRotate = baConfigurationInfo.PS_IsAutoRotate;
                        configurationinfo.PS_IsBackupScheduled = baConfigurationInfo.PS_IsBackupScheduled;
                        configurationinfo.PS_IsCompression = baConfigurationInfo.PS_IsCompression;
                        configurationinfo.PS_IsEnableGroup = baConfigurationInfo.PS_IsEnableGroup;
                        configurationinfo.PS_MktImgPath = baConfigurationInfo.PS_MktImgPath;
                        configurationinfo.PS_MktImgTimeInSec = baConfigurationInfo.PS_MktImgTimeInSec;
                        configurationinfo.PS_Mod_Password = baConfigurationInfo.PS_Mod_Password;
                        configurationinfo.PS_NoOfBillReceipt = baConfigurationInfo.PS_NoOfBillReceipt;
                        configurationinfo.PS_NoOfPhotoIdSearch = baConfigurationInfo.PS_NoOfPhotoIdSearch;
                        configurationinfo.PS_NoOfPhotos = baConfigurationInfo.PS_NoOfPhotos;
                        configurationinfo.PS_PageCountGrid = baConfigurationInfo.PS_PageCountGrid;
                        configurationinfo.PS_PageCountPreview = baConfigurationInfo.PS_PageCountPreview;
                        configurationinfo.PS_ReceiptPrinter = baConfigurationInfo.PS_ReceiptPrinter;
                        configurationinfo.PS_ScheduleBackup = baConfigurationInfo.PS_ScheduleBackup;
                        configurationinfo.PS_SemiOrder = baConfigurationInfo.PS_SemiOrder;
                        configurationinfo.PS_SemiOrderMain = baConfigurationInfo.PS_SemiOrderMain;
                        configurationinfo.PS_Substore_Id = baConfigurationInfo.PS_Substore_Id;
                        configurationinfo.PS_Watermark = baConfigurationInfo.PS_Watermark;
                        configurationinfo.EK_DisplayDuration = baConfigurationInfo.EK_DisplayDuration;
                        configurationinfo.EK_IsScreenSaverActive = baConfigurationInfo.EK_IsScreenSaverActive;
                        configurationinfo.EK_SampleImagePath = baConfigurationInfo.EK_SampleImagePath;
                        configurationinfo.EK_ScreenStartTime = baConfigurationInfo.EK_ScreenStartTime;
                        configurationinfo.FolderStartingNumber = baConfigurationInfo.FolderStartingNumber;
                        configurationinfo.FtpFolder = baConfigurationInfo.FtpFolder;
                        configurationinfo.FtpIP = baConfigurationInfo.FtpIP;
                        configurationinfo.FtpPwd = baConfigurationInfo.FtpPwd;
                        configurationinfo.FtpUid = baConfigurationInfo.FtpUid;
                        configurationinfo.IntervalCount = baConfigurationInfo.IntervalCount;
                        configurationinfo.intervalType = baConfigurationInfo.intervalType;
                        configurationinfo.IsAutoLock = baConfigurationInfo.IsAutoLock;
                        configurationinfo.IsDeleteFromUSB = baConfigurationInfo.IsDeleteFromUSB;
                        configurationinfo.IsExportReportToAnyDrive = baConfigurationInfo.IsExportReportToAnyDrive;
                        configurationinfo.IsRecursive = baConfigurationInfo.IsRecursive;
                        configurationinfo.IsSynced = baConfigurationInfo.IsSynced;
                        configurationinfo.PosOnOff = baConfigurationInfo.PosOnOff;
                        configurationinfo.SyncCode = baConfigurationInfo.SyncCode;
                        configurationinfo.WiFiStartingNumber = baConfigurationInfo.WiFiStartingNumber;

                        db.SaveChanges();

                        return true;
                        }
                    else
                        {
                        return false;
                        }
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }


        public static bool Marge(baConfigurationInfo baConfigurationInfo)
        {
            try
            {


                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.ConfigurationInfos.Where(p => p.Id == 1).FirstOrDefault();
                    if (obj == null)
                    {
                        configurationinfo configurationinfo = new configurationinfo();
                        configurationinfo.DefaultCurrency = baConfigurationInfo.DefaultCurrency;
                        configurationinfo.DefaultCurrencyId = baConfigurationInfo.DefaultCurrencyId;
                        configurationinfo.PS_AllowDiscount = baConfigurationInfo.PS_AllowDiscount;
                        configurationinfo.PS_BG_Path = baConfigurationInfo.PS_BG_Path;
                        configurationinfo.PS_Brightness = baConfigurationInfo.PS_Brightness;
                        configurationinfo.PS_ChromaColor = baConfigurationInfo.PS_ChromaColor;
                        configurationinfo.PS_ChromaTolerance = baConfigurationInfo.PS_ChromaTolerance;
                        configurationinfo.PS_CleanUpDaysBackUp = baConfigurationInfo.PS_CleanUpDaysBackUp;
                        configurationinfo.PS_CleanupTables = baConfigurationInfo.PS_CleanupTables;
                        configurationinfo.PS_Config_pkey = baConfigurationInfo.PS_Config_pkey;
                        configurationinfo.PS_Contrast = baConfigurationInfo.PS_Contrast;
                        configurationinfo.PS_DbBackupPath = baConfigurationInfo.PS_DbBackupPath;
                        configurationinfo.PS_EnableDiscountOnTotal = baConfigurationInfo.PS_EnableDiscountOnTotal;
                        configurationinfo.PS_Frame_Path = baConfigurationInfo.PS_Frame_Path;
                        configurationinfo.PS_Graphics_Path = baConfigurationInfo.PS_Graphics_Path;
                        configurationinfo.PS_HfBackupPath = baConfigurationInfo.PS_HfBackupPath;
                        configurationinfo.PS_HighResolution = baConfigurationInfo.PS_HighResolution;
                        configurationinfo.PS_Hot_Folder_Path = baConfigurationInfo.PS_Hot_Folder_Path;
                        configurationinfo.PS_IsAutoRotate = baConfigurationInfo.PS_IsAutoRotate;
                        configurationinfo.PS_IsBackupScheduled = baConfigurationInfo.PS_IsBackupScheduled;
                        configurationinfo.PS_IsCompression = baConfigurationInfo.PS_IsCompression;
                        configurationinfo.PS_IsEnableGroup = baConfigurationInfo.PS_IsEnableGroup;
                        configurationinfo.PS_MktImgPath = baConfigurationInfo.PS_MktImgPath;
                        configurationinfo.PS_MktImgTimeInSec = baConfigurationInfo.PS_MktImgTimeInSec;
                        configurationinfo.PS_Mod_Password = baConfigurationInfo.PS_Mod_Password;
                        configurationinfo.PS_NoOfBillReceipt = baConfigurationInfo.PS_NoOfBillReceipt;
                        configurationinfo.PS_NoOfPhotoIdSearch = baConfigurationInfo.PS_NoOfPhotoIdSearch;
                        configurationinfo.PS_NoOfPhotos = baConfigurationInfo.PS_NoOfPhotos;
                        configurationinfo.PS_PageCountGrid = baConfigurationInfo.PS_PageCountGrid;
                        configurationinfo.PS_PageCountPreview = baConfigurationInfo.PS_PageCountPreview;
                        configurationinfo.PS_ReceiptPrinter = baConfigurationInfo.PS_ReceiptPrinter;
                        configurationinfo.PS_ScheduleBackup = baConfigurationInfo.PS_ScheduleBackup;
                        configurationinfo.PS_SemiOrder = baConfigurationInfo.PS_SemiOrder;
                        configurationinfo.PS_SemiOrderMain = baConfigurationInfo.PS_SemiOrderMain;
                        configurationinfo.PS_Substore_Id = baConfigurationInfo.PS_Substore_Id;
                        configurationinfo.PS_Watermark = baConfigurationInfo.PS_Watermark;
                        configurationinfo.EK_DisplayDuration = baConfigurationInfo.EK_DisplayDuration;
                        configurationinfo.EK_IsScreenSaverActive = baConfigurationInfo.EK_IsScreenSaverActive;
                        configurationinfo.EK_SampleImagePath = baConfigurationInfo.EK_SampleImagePath;
                        configurationinfo.EK_ScreenStartTime = baConfigurationInfo.EK_ScreenStartTime;
                        configurationinfo.FolderStartingNumber = baConfigurationInfo.FolderStartingNumber;
                        configurationinfo.FtpFolder = baConfigurationInfo.FtpFolder;
                        configurationinfo.FtpIP = baConfigurationInfo.FtpIP;
                        configurationinfo.FtpPwd = baConfigurationInfo.FtpPwd;
                        configurationinfo.FtpUid = baConfigurationInfo.FtpUid;
                        configurationinfo.IntervalCount = baConfigurationInfo.IntervalCount;
                        configurationinfo.intervalType = baConfigurationInfo.intervalType;
                        configurationinfo.IsAutoLock = baConfigurationInfo.IsAutoLock;
                        configurationinfo.IsDeleteFromUSB = baConfigurationInfo.IsDeleteFromUSB;
                        configurationinfo.IsExportReportToAnyDrive = baConfigurationInfo.IsExportReportToAnyDrive;
                        configurationinfo.IsRecursive = baConfigurationInfo.IsRecursive;
                        configurationinfo.IsSynced = baConfigurationInfo.IsSynced;
                        configurationinfo.PosOnOff = baConfigurationInfo.PosOnOff;
                        configurationinfo.SyncCode = baConfigurationInfo.SyncCode;
                        configurationinfo.WiFiStartingNumber = baConfigurationInfo.WiFiStartingNumber;
                        db.ConfigurationInfos.Add(configurationinfo);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        //obj.Id = baConfigurationInfo.Id;
                        obj.DefaultCurrency = baConfigurationInfo.DefaultCurrency;
                        obj.DefaultCurrencyId = baConfigurationInfo.DefaultCurrencyId;
                        obj.PS_AllowDiscount = baConfigurationInfo.PS_AllowDiscount;
                        obj.PS_BG_Path = baConfigurationInfo.PS_BG_Path;
                        obj.PS_Brightness = baConfigurationInfo.PS_Brightness;
                        obj.PS_ChromaColor = baConfigurationInfo.PS_ChromaColor;
                        obj.PS_ChromaTolerance = baConfigurationInfo.PS_ChromaTolerance;
                        obj.PS_CleanUpDaysBackUp = baConfigurationInfo.PS_CleanUpDaysBackUp;
                        obj.PS_CleanupTables = baConfigurationInfo.PS_CleanupTables;
                        obj.PS_Config_pkey = baConfigurationInfo.PS_Config_pkey;
                        obj.PS_Contrast = baConfigurationInfo.PS_Contrast;
                        obj.PS_DbBackupPath = baConfigurationInfo.PS_DbBackupPath;
                        obj.PS_EnableDiscountOnTotal = baConfigurationInfo.PS_EnableDiscountOnTotal;
                        obj.PS_Frame_Path = baConfigurationInfo.PS_Frame_Path;
                        obj.PS_Graphics_Path = baConfigurationInfo.PS_Graphics_Path;
                        obj.PS_HfBackupPath = baConfigurationInfo.PS_HfBackupPath;
                        obj.PS_HighResolution = baConfigurationInfo.PS_HighResolution;
                        obj.PS_Hot_Folder_Path = baConfigurationInfo.PS_Hot_Folder_Path;
                        obj.PS_IsAutoRotate = baConfigurationInfo.PS_IsAutoRotate;
                        obj.PS_IsBackupScheduled = baConfigurationInfo.PS_IsBackupScheduled;
                        obj.PS_IsCompression = baConfigurationInfo.PS_IsCompression;
                        obj.PS_IsEnableGroup = baConfigurationInfo.PS_IsEnableGroup;
                        obj.PS_MktImgPath = baConfigurationInfo.PS_MktImgPath;
                        obj.PS_MktImgTimeInSec = baConfigurationInfo.PS_MktImgTimeInSec;
                        obj.PS_Mod_Password = baConfigurationInfo.PS_Mod_Password;
                        obj.PS_NoOfBillReceipt = baConfigurationInfo.PS_NoOfBillReceipt;
                        obj.PS_NoOfPhotoIdSearch = baConfigurationInfo.PS_NoOfPhotoIdSearch;
                        obj.PS_NoOfPhotos = baConfigurationInfo.PS_NoOfPhotos;
                        obj.PS_PageCountGrid = baConfigurationInfo.PS_PageCountGrid;
                        obj.PS_PageCountPreview = baConfigurationInfo.PS_PageCountPreview;
                        obj.PS_ReceiptPrinter = baConfigurationInfo.PS_ReceiptPrinter;
                        obj.PS_ScheduleBackup = baConfigurationInfo.PS_ScheduleBackup;
                        obj.PS_SemiOrder = baConfigurationInfo.PS_SemiOrder;
                        obj.PS_SemiOrderMain = baConfigurationInfo.PS_SemiOrderMain;
                        obj.PS_Substore_Id = baConfigurationInfo.PS_Substore_Id;
                        obj.PS_Watermark = baConfigurationInfo.PS_Watermark;
                        obj.EK_DisplayDuration = baConfigurationInfo.EK_DisplayDuration;
                        obj.EK_IsScreenSaverActive = baConfigurationInfo.EK_IsScreenSaverActive;
                        obj.EK_SampleImagePath = baConfigurationInfo.EK_SampleImagePath;
                        obj.EK_ScreenStartTime = baConfigurationInfo.EK_ScreenStartTime;
                        obj.FolderStartingNumber = baConfigurationInfo.FolderStartingNumber;
                        obj.FtpFolder = baConfigurationInfo.FtpFolder;
                        obj.FtpIP = baConfigurationInfo.FtpIP;
                        obj.FtpPwd = baConfigurationInfo.FtpPwd;
                        obj.FtpUid = baConfigurationInfo.FtpUid;
                        obj.IntervalCount = baConfigurationInfo.IntervalCount;
                        obj.intervalType = baConfigurationInfo.intervalType;
                        obj.IsAutoLock = baConfigurationInfo.IsAutoLock;
                        obj.IsDeleteFromUSB = baConfigurationInfo.IsDeleteFromUSB;
                        obj.IsExportReportToAnyDrive = baConfigurationInfo.IsExportReportToAnyDrive;
                        obj.IsRecursive = baConfigurationInfo.IsRecursive;
                        obj.IsSynced = baConfigurationInfo.IsSynced;
                        obj.PosOnOff = baConfigurationInfo.PosOnOff;
                        obj.SyncCode = baConfigurationInfo.SyncCode;
                        obj.WiFiStartingNumber = baConfigurationInfo.WiFiStartingNumber;
                        obj.IsActive = baConfigurationInfo.IsActive;

                        db.SaveChanges();
                        return true;
                    }

                }
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete ( int Id )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ConfigurationInfos.Where(p => p.Id == Id).FirstOrDefault();
                    if(obj != null)
                        {
                        obj.IsActive = false;
                        db.SaveChanges();

                        }
                    return true;

                    }
                }
            catch(Exception)
                {
                throw;
                }

            }

        }
    }
