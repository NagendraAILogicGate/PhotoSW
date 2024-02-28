using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.IMIX.Model;
using PhotoSW.CF.DataLayer.BAL;
using System.Data;
using PhotoSW.DataLayer;

namespace PhotoSW.IMIX.Business
{
   public class ConfigBusiness
    {

      //  private string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;

        private string baseDirectory = System.AppDomain.CurrentDomain.BaseDirectory;
        public PhotoSW.IMIX.Model.VideoConfigProfiles List { get; set; }

       public bool CheckDummyScan(long photographerID)
       {
           return false;
       }
       public DataTable CreateReportData(DataTable dt, ReportTypes reportType) 
       {
           

            return new DataTable();
       }
       public bool DeleteAudio(long audioId)
       {
           return true;
       }
       public bool DeleteCGConfigSettngs(int configId)
       {
           return true;
       }
       public void DeleteLocationWiseConfigParams(int LocationId)
       {
           
       }
       public void DeleteLocationWiseConfigParamsGumbleRide(int LocationId) { }
       public bool DeletePreviewDummyTag(long iMIXStoreConfigurationValueId)
       {
           return true;
       }
       public bool DeleteProfile(long profileId)
       {
           return true;
       }
       public bool DeleteStockShotImg(long ImgId)
       {
           return true;
       }
       public bool DeleteVideoBackground(long vidBgID)
       {
           return true;
       }
       public bool DeleteVideoOverlay(long videoId)
       {
           return true;
       }
       public bool DeleteVideoTemplate(long videoId)
       {
           return true;
       }
       public List<PhotoSW.IMIX.Model.ReportTypeDetails> GetActiveReports()
       {
            List<PhotoSW.IMIX.Model.ReportTypeDetails> obj = new List<ReportTypeDetails>();
            return obj;
       }
       public List<PhotoSW.IMIX.Model.ConfigInfo> GetAllConfigs()
       {
            try
                {
                var obj1 = baConfigInfo.GetConfigInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ConfigInfo
                        {
                     //   Id = p.Id,
                        ConfigID = p.ConfigID,
                        SubStoreID = p.SubStoreID,
                        ConfigKey = p.ConfigKey,
                        ConfigValue = p.ConfigValue,
                        MasterID = p.MasterID,
                  //      IsActive = p.IsActive,

                        }).ToList();
                return obj1;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ConfigInfo>();
                }
            //List<PhotoSW.IMIX.Model.ConfigInfo> obj = new List<PhotoSW.IMIX.Model.ConfigInfo>();
            //return obj;
            }
       public List<PhotoSW.IMIX.Model.iMixConfigurationLocationInfo> GetAllLocationWiseConfigParams()
       {
            try
                {
                var obj1 = baiMixConfigurationLocationInfo.GetiMixConfigurationLocationInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.iMixConfigurationLocationInfo
                        {
                        ConfigurationLocationValueId = p.ConfigurationLocationValueId,
                        ConfigurationValue = p.ConfigurationValue,
                        LocationId = p.LocationId

                        }).ToList();
                return obj1;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.iMixConfigurationLocationInfo>();
                }
            //  return new List<PhotoSW.IMIX.Model.iMixConfigurationLocationInfo>();
            }
       public List<PhotoSW.IMIX.Model.ConfigurationInfo> GetAllSubstoreConfigdata()
       {
            try
                {
                var obj1 = baConfigurationInfo.GetConfigurationInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ConfigurationInfo
                        {
                      //  Id = p.Id,
                        DefaultCurrency = p.DefaultCurrency,
                        DefaultCurrencyId = p.DefaultCurrencyId,
                        DG_AllowDiscount = p.PS_AllowDiscount,
                        DG_BG_Path = p.PS_BG_Path,
                        DG_Brightness = p.PS_Brightness,
                        DG_ChromaColor = p.PS_ChromaColor,
                        DG_ChromaTolerance = p.PS_ChromaTolerance,
                        DG_CleanUpDaysBackUp = p.PS_CleanUpDaysBackUp,
                        DG_CleanupTables = p.PS_CleanupTables,
                        DG_Config_pkey = p.PS_Config_pkey,
                        DG_Contrast = p.PS_Contrast,
                        DG_DbBackupPath = p.PS_DbBackupPath,
                        DG_EnableDiscountOnTotal = p.PS_EnableDiscountOnTotal,
                        DG_Frame_Path = p.PS_Frame_Path,
                        DG_Graphics_Path = p.PS_Graphics_Path,
                        DG_HfBackupPath = p.PS_HfBackupPath,
                        DG_HighResolution = p.PS_HighResolution,
                        DG_Hot_Folder_Path = p.PS_Hot_Folder_Path,
                        DG_IsAutoRotate = p.PS_IsAutoRotate,
                        DG_IsBackupScheduled = p.PS_IsBackupScheduled,
                        DG_IsCompression = p.PS_IsCompression,
                        DG_IsEnableGroup = p.PS_IsEnableGroup,
                        DG_MktImgPath = p.PS_MktImgPath,
                        DG_MktImgTimeInSec = p.PS_MktImgTimeInSec,
                        DG_Mod_Password = p.PS_Mod_Password,
                        DG_NoOfBillReceipt = p.PS_NoOfBillReceipt,
                        DG_NoOfPhotoIdSearch = p.PS_NoOfPhotoIdSearch,
                        DG_NoOfPhotos = p.PS_NoOfPhotos,
                        DG_PageCountGrid = p.PS_PageCountGrid,
                        DG_PageCountPreview = p.PS_PageCountPreview,
                        DG_ReceiptPrinter = p.PS_ReceiptPrinter,
                        DG_ScheduleBackup = p.PS_ScheduleBackup,
                        DG_SemiOrder = p.PS_SemiOrder,
                        DG_SemiOrderMain = p.PS_SemiOrderMain,
                        DG_Substore_Id = p.PS_Substore_Id,
                        DG_Watermark = p.PS_Watermark,
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
                        //IsActive = p.IsActive,

                        }).ToList();
                return obj1;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ConfigurationInfo>();
                }
            // return new  List<PhotoSW.IMIX.Model.ConfigurationInfo>();
            }
       public List<PhotoSW.IMIX.Model.SyncTriggerStatusInfo> GetAllSyncTriggerTables()
       {
            try
                {
                var obj = baSyncTriggerStatusInfo.GetPhotoGroupInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.SyncTriggerStatusInfo
                        {
                      //  Id = p.Id,
                        TableId = p.TableId,
                        TableName = p.TableName,
                        IsSyncTriggerEnable = p.IsSyncTriggerEnable                        

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.SyncTriggerStatusInfo>();
                }

            // return new List<PhotoSW.IMIX.Model.SyncTriggerStatusInfo>();
            }
       public List<PhotoSW.IMIX.Model.AudioTemplateInfo> GetAudioTemplateList()
       {
            try
                {
                var obj = baAudioTemplateInfo.GetAudioTemplateInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.AudioTemplateInfo
                        {
                     
                        AudioTemplateId = p.AudioTemplateId,
                        Name = p.Name,
                        DisplayName = p.DisplayName,
                        Description = p.Description,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedOn = p.ModifiedOn,
                        IsActiveDisplay = p.IsActiveDisplay,
                        AudioLength = p.AudioLength
                       // IsActive = p.IsActive

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.AudioTemplateInfo>();
                }
            // return new  List<PhotoSW.IMIX.Model.AudioTemplateInfo>();
            }
       public PhotoSW.IMIX.Model.AudioTemplateInfo GetAudioTemplateList(long audioID)
       {
            try
                {
                var obj = baAudioTemplateInfo.GetAudioTemplateInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.AudioTemplateInfo
                        {

                        AudioTemplateId = p.AudioTemplateId,
                        Name = p.Name,
                        DisplayName = p.DisplayName,
                        Description = p.Description,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        ModifiedBy = p.ModifiedBy,
                        ModifiedOn = p.ModifiedOn,
                        IsActiveDisplay = p.IsActiveDisplay,
                        AudioLength = p.AudioLength
                        // IsActive = p.IsActive

                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return new PhotoSW.IMIX.Model.AudioTemplateInfo();
                }
            // return new PhotoSW.IMIX.Model.AudioTemplateInfo();
            }
       public List<PhotoSW.IMIX.Model.CGConfigSettings> GetCGConfigSettngs(int configId)
       {
            try
                {
                var obj = baCGConfigSettings.GetCGConfigSettingsData()
                    .Select(p => new PhotoSW.IMIX.Model.CGConfigSettings
                        {

                        ConfigFileName = p.ConfigFileName,
                        Extension = p.Extension,
                        DisplayName = p.DisplayName

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.CGConfigSettings>();
                }
            //  return new List<PhotoSW.IMIX.Model.CGConfigSettings>();
            }
       public int GetCompressionLevel(int substoreid, long mediaEnum)
       {
           return 0;
       }
       public List<PhotoSW.IMIX.Model.iMixConfigurationLocationInfo> GetConfigBasedOnLocation(int LocationId)
       {
            try
                {
                var obj = baiMixConfigurationLocationInfo.GetiMixConfigurationLocationInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.iMixConfigurationLocationInfo
                        {
                        ConfigurationLocationValueId = p.ConfigurationLocationValueId,
                        ConfigurationValue = p.ConfigurationValue,
                        LocationId = p.LocationId
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.iMixConfigurationLocationInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.iMixConfigurationLocationInfo>();
            }
       public bool? GetConfigCompression(int SubstoreId)
       {
           return false;
       }
       public bool? GetConfigEnableGroup(int SubstoreID)
       {
           return false;
       }
       public List<PhotoSW.IMIX.Model.iMixConfigurationLocationInfo> GetConfigLocation(int LocationId, int SubstoreId)
       {
            try
                {
                var obj = baiMixConfigurationLocationInfo.GetiMixConfigurationLocationInfoData()
                   // .Where(p=>p.LocationId == LocationId && p.Id == SubstoreId)
                    .Select(p => new PhotoSW.IMIX.Model.iMixConfigurationLocationInfo
                        {
                        ConfigurationLocationValueId = p.ConfigurationLocationValueId,
                        ConfigurationValue = p.ConfigurationValue,
                        LocationId = p.LocationId
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.iMixConfigurationLocationInfo>();
                }
            //  return new List<iMixConfigurationLocationInfo>();
            }
        public List<PhotoSW.IMIX.Model.ConfigurationInfo> GetConfigurationData ()
            {
            try
                {
                var obj = baConfigurationInfo.GetConfigurationData()
                    .Select(p => new PhotoSW.IMIX.Model.ConfigurationInfo
                        {
                        DefaultCurrency = p.DefaultCurrency,
                        DefaultCurrencyId = p.DefaultCurrencyId,
                        DG_AllowDiscount = p.PS_AllowDiscount,
                        DG_BG_Path = baseDirectory + p.PS_BG_Path,
                        DG_Brightness = p.PS_Brightness,
                        DG_ChromaColor = p.PS_ChromaColor,
                        DG_ChromaTolerance = p.PS_ChromaTolerance,
                        DG_CleanUpDaysBackUp = p.PS_CleanUpDaysBackUp,
                        DG_CleanupTables = p.PS_CleanupTables,
                        DG_Config_pkey = p.Id,
                        DG_Contrast = p.PS_Contrast,
                        DG_DbBackupPath = baseDirectory + p.PS_DbBackupPath,
                        DG_EnableDiscountOnTotal = p.PS_EnableDiscountOnTotal,
                        DG_Frame_Path = baseDirectory + p.PS_Frame_Path,
                        DG_Graphics_Path = baseDirectory + p.PS_Graphics_Path,
                        DG_HfBackupPath = baseDirectory + p.PS_HfBackupPath,
                        DG_HighResolution = p.PS_HighResolution,
                        DG_Hot_Folder_Path = baseDirectory + p.PS_Hot_Folder_Path,
                        DG_IsAutoRotate = p.PS_IsAutoRotate,
                        DG_IsBackupScheduled = p.PS_IsBackupScheduled,
                        DG_IsCompression = p.PS_IsCompression,
                        DG_IsEnableGroup = p.PS_IsEnableGroup,
                        DG_MktImgPath = baseDirectory + p.PS_MktImgPath,
                        DG_MktImgTimeInSec = p.PS_MktImgTimeInSec,
                        DG_Mod_Password = p.PS_Mod_Password,
                        DG_NoOfBillReceipt = p.PS_NoOfBillReceipt,
                        DG_NoOfPhotoIdSearch = p.PS_NoOfPhotoIdSearch,
                        DG_NoOfPhotos = p.PS_NoOfPhotos,
                        DG_PageCountGrid = p.PS_PageCountGrid,
                        DG_PageCountPreview = p.PS_PageCountPreview,
                        DG_ReceiptPrinter = p.PS_ReceiptPrinter,
                        DG_ScheduleBackup = p.PS_ScheduleBackup,
                        DG_SemiOrder = p.PS_SemiOrder,
                        DG_SemiOrderMain = p.PS_SemiOrderMain,
                        DG_Substore_Id = p.PS_Substore_Id,
                        DG_Watermark = p.PS_Watermark,
                        EK_DisplayDuration = p.EK_DisplayDuration,
                        EK_IsScreenSaverActive = p.EK_IsScreenSaverActive,
                        EK_SampleImagePath = baseDirectory + p.EK_SampleImagePath,
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
                        }).ToList();
                return obj;
                }
            catch
                {
                return null;
                }
            }
        public PhotoSW.IMIX.Model.ConfigurationInfo GetConfigurationData ( int subStoreId )
            {
            try
                {
                var obj = baConfigurationInfo.GetConfigurationData().Where(p => p.PS_Substore_Id == subStoreId)
                    .Select(p => new PhotoSW.IMIX.Model.ConfigurationInfo
                        {
                        DefaultCurrency = p.DefaultCurrency,
                        DefaultCurrencyId = p.DefaultCurrencyId,
                        DG_AllowDiscount = p.PS_AllowDiscount,
                        DG_BG_Path = baseDirectory + p.PS_BG_Path,
                        DG_Brightness = p.PS_Brightness,
                        DG_ChromaColor = p.PS_ChromaColor,
                        DG_ChromaTolerance = p.PS_ChromaTolerance,
                        DG_CleanUpDaysBackUp = p.PS_CleanUpDaysBackUp,
                        DG_CleanupTables = p.PS_CleanupTables,
                        DG_Config_pkey = p.Id,
                        DG_Contrast = p.PS_Contrast,
                        DG_DbBackupPath = baseDirectory + p.PS_DbBackupPath,
                        DG_EnableDiscountOnTotal = p.PS_EnableDiscountOnTotal,
                        DG_Frame_Path = baseDirectory + p.PS_Frame_Path,
                        DG_Graphics_Path = baseDirectory + p.PS_Graphics_Path,
                        DG_HfBackupPath = baseDirectory + p.PS_HfBackupPath,
                        DG_HighResolution = p.PS_HighResolution,
                        DG_Hot_Folder_Path = baseDirectory + p.PS_Hot_Folder_Path,
                        DG_IsAutoRotate = p.PS_IsAutoRotate,
                        DG_IsBackupScheduled = p.PS_IsBackupScheduled,
                        DG_IsCompression = p.PS_IsCompression,
                        DG_IsEnableGroup = p.PS_IsEnableGroup,
                        DG_MktImgPath = baseDirectory + p.PS_MktImgPath,
                        DG_MktImgTimeInSec = p.PS_MktImgTimeInSec,
                        DG_Mod_Password = p.PS_Mod_Password,
                        DG_NoOfBillReceipt = p.PS_NoOfBillReceipt,
                        DG_NoOfPhotoIdSearch = p.PS_NoOfPhotoIdSearch,
                        DG_NoOfPhotos = p.PS_NoOfPhotos,
                        DG_PageCountGrid = p.PS_PageCountGrid,
                        DG_PageCountPreview = p.PS_PageCountPreview,
                        DG_ReceiptPrinter = p.PS_ReceiptPrinter,
                        DG_ScheduleBackup = p.PS_ScheduleBackup,
                        DG_SemiOrder = p.PS_SemiOrder,
                        DG_SemiOrderMain = p.PS_SemiOrderMain,
                        DG_Substore_Id = p.PS_Substore_Id,
                        DG_Watermark = p.PS_Watermark,
                        EK_DisplayDuration = p.EK_DisplayDuration,
                        EK_IsScreenSaverActive = p.EK_IsScreenSaverActive,
                        EK_SampleImagePath = baseDirectory + p.EK_SampleImagePath,
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
                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return null;
                }

            }
        public Dictionary<long, string> GetConfigurations(Dictionary<long, string> iMIXConfigurations,
           int subStoreId)
       {
           Dictionary<long, string> obj = new Dictionary<long, string>();
           return obj;
       }
       public Dictionary<string, decimal?> GetCromaColor(int SubStoreId)
       {
           Dictionary<string, decimal?> obj = new Dictionary<string, decimal?>();
           obj.Add("Green", (decimal)0.1);
           obj.Add("Blue", (decimal)0.2);
           obj.Add("Red", (decimal)0.3);
           obj.Add("Gray", (decimal)0.4);
           return obj;
       }
       public PhotoSW.IMIX.Model.ConfigurationInfo GetDeafultPathData()
       {
            try
                {
                var obj = baConfigurationInfo.GetConfigurationData()
                    .Select(p => new PhotoSW.IMIX.Model.ConfigurationInfo
                        {
                        DefaultCurrency = p.DefaultCurrency,
                        DefaultCurrencyId = p.DefaultCurrencyId,
                        DG_AllowDiscount = p.PS_AllowDiscount,
                        DG_BG_Path = p.PS_BG_Path,
                        DG_Brightness = p.PS_Brightness,
                        DG_ChromaColor = p.PS_ChromaColor,
                        DG_ChromaTolerance = p.PS_ChromaTolerance,
                        DG_CleanUpDaysBackUp = p.PS_CleanUpDaysBackUp,
                        DG_CleanupTables = p.PS_CleanupTables,
                        DG_Config_pkey = p.Id,
                        DG_Contrast = p.PS_Contrast,
                        DG_DbBackupPath = p.PS_DbBackupPath,
                        DG_EnableDiscountOnTotal = p.PS_EnableDiscountOnTotal,
                        DG_Frame_Path = p.PS_Frame_Path,
                        DG_Graphics_Path = p.PS_Graphics_Path,
                        DG_HfBackupPath = p.PS_HfBackupPath,
                        DG_HighResolution = p.PS_HighResolution,
                        DG_Hot_Folder_Path = p.PS_Hot_Folder_Path,
                        DG_IsAutoRotate = p.PS_IsAutoRotate,
                        DG_IsBackupScheduled = p.PS_IsBackupScheduled,
                        DG_IsCompression = p.PS_IsCompression,
                        DG_IsEnableGroup = p.PS_IsEnableGroup,
                        DG_MktImgPath = p.PS_MktImgPath,
                        DG_MktImgTimeInSec = p.PS_MktImgTimeInSec,
                        DG_Mod_Password = p.PS_Mod_Password,
                        DG_NoOfBillReceipt = p.PS_NoOfBillReceipt,
                        DG_NoOfPhotoIdSearch = p.PS_NoOfPhotoIdSearch,
                        DG_NoOfPhotos = p.PS_NoOfPhotos,
                        DG_PageCountGrid = p.PS_PageCountGrid,
                        DG_PageCountPreview = p.PS_PageCountPreview,
                        DG_ReceiptPrinter = p.PS_ReceiptPrinter,
                        DG_ScheduleBackup = p.PS_ScheduleBackup,
                        DG_SemiOrder = p.PS_SemiOrder,
                        DG_SemiOrderMain = p.PS_SemiOrderMain,
                        DG_Substore_Id = p.PS_Substore_Id,
                        DG_Watermark = p.PS_Watermark,
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
                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return null;
                }
            //PhotoSW.IMIX.Model.ConfigurationInfo obj = new ConfigurationInfo();
            //return obj;
            }
       public List<PhotoSW.IMIX.Model.ConfigurationInfo> GetDeafultPathlist()
       {
            try
                {
                var obj = baConfigurationInfo.GetConfigurationData()
                    .Select(p => new PhotoSW.IMIX.Model.ConfigurationInfo()
                    {
                        DefaultCurrency = p.DefaultCurrency,
                        DefaultCurrencyId = p.DefaultCurrencyId,
                        DG_AllowDiscount = p.PS_AllowDiscount,
                        DG_BG_Path = p.PS_BG_Path,
                        DG_Brightness = p.PS_Brightness,
                        DG_ChromaColor = p.PS_ChromaColor,
                        DG_ChromaTolerance = p.PS_ChromaTolerance,
                        DG_CleanUpDaysBackUp = p.PS_CleanUpDaysBackUp,
                        DG_CleanupTables = p.PS_CleanupTables,
                        DG_Config_pkey = p.Id,
                        DG_Contrast = p.PS_Contrast,
                        DG_DbBackupPath = p.PS_DbBackupPath,
                        DG_EnableDiscountOnTotal = p.PS_EnableDiscountOnTotal,
                        DG_Frame_Path = p.PS_Frame_Path,
                        DG_Graphics_Path = p.PS_Graphics_Path,
                        DG_HfBackupPath = p.PS_HfBackupPath,
                        DG_HighResolution = p.PS_HighResolution,
                        DG_Hot_Folder_Path = p.PS_Hot_Folder_Path,
                        DG_IsAutoRotate = p.PS_IsAutoRotate,
                        DG_IsBackupScheduled = p.PS_IsBackupScheduled,
                        DG_IsCompression = p.PS_IsCompression,
                        DG_IsEnableGroup = p.PS_IsEnableGroup,
                        DG_MktImgPath = p.PS_MktImgPath,
                        DG_MktImgTimeInSec = p.PS_MktImgTimeInSec,
                        DG_Mod_Password = p.PS_Mod_Password,
                        DG_NoOfBillReceipt = p.PS_NoOfBillReceipt,
                        DG_NoOfPhotoIdSearch = p.PS_NoOfPhotoIdSearch,
                        DG_NoOfPhotos = p.PS_NoOfPhotos,
                        DG_PageCountGrid = p.PS_PageCountGrid,
                        DG_PageCountPreview = p.PS_PageCountPreview,
                        DG_ReceiptPrinter = p.PS_ReceiptPrinter,
                        DG_ScheduleBackup = p.PS_ScheduleBackup,
                        DG_SemiOrder = p.PS_SemiOrder,
                        DG_SemiOrderMain = p.PS_SemiOrderMain,
                        DG_Substore_Id = p.PS_Substore_Id,
                        DG_Watermark = p.PS_Watermark,
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
                        }).ToList();
                return obj;
                }
            catch
                {
                return null;
                }
            //List<PhotoSW.IMIX.Model.ConfigurationInfo> obj = new List<ConfigurationInfo>();
            //return obj;
            }
       public List<PhotoSW.IMIX.Model.ExportServiceLog> GetExportServiceLogs() 
       {

            List<PhotoSW.IMIX.Model.ExportServiceLog> obj = new List<ExportServiceLog>();
            return obj;
            }
       public PhotoSW.IMIX.Model.FolderStructureInfo GetFolderStructureInfo(int subStoreId) 
       {
            try
                {
                var obj = baFolderStructureInfo.GetFolderStructureInfoData()
                    .Where(p=>p.Id == subStoreId)
                    .Select(p => new PhotoSW.IMIX.Model.FolderStructureInfo()
                        {
                       // Id = p.Id,
                        HotFolderPath = p.HotFolderPath,
                        BorderPath = p.BorderPath,
                        BackgroundPath = p.BackgroundPath,
                        GraphicPath = p.GraphicPath,
                        CroppedPath = p.CroppedPath,
                        EditedImagePath = p.EditedImagePath,
                        ThumbnailsPath = p.ThumbnailsPath,
                        BigThumbnailsPath = p.BigThumbnailsPath,
                        PrintImagesPath = p.PrintImagesPath,
                       // IsActive = p.IsActive
                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return new PhotoSW.IMIX.Model.FolderStructureInfo();
                }
            //PhotoSW.IMIX.Model.FolderStructureInfo obj = new FolderStructureInfo();
            //return obj;
            }
       public string GetHotFolderPath(int SubStoreId)
       {
           return "";
       }
       public List<PhotoSW.IMIX.Model.iMixConfigurationLocationInfo> GetLocationWiseConfigParams
           (int SubStoreId)
       {
            try
                {
                var obj = baiMixConfigurationLocationInfo.GetiMixConfigurationLocationInfoData()
                    .Where(p => p.Id == SubStoreId)
                    .Select(p => new PhotoSW.IMIX.Model.iMixConfigurationLocationInfo()
                        {
                        ConfigurationLocationValueId = p.ConfigurationLocationValueId,
                        ConfigurationValue = p.ConfigurationValue,
                        LocationId = p.LocationId
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.iMixConfigurationLocationInfo>();
                }
            //List<PhotoSW.IMIX.Model.iMixConfigurationLocationInfo> obj = new List<iMixConfigurationLocationInfo>();
            //return obj;
            }
       public List<PhotoSW.IMIX.Model.iMIXConfigurationInfo> GetNewConfigValues(int subStoreId)
       {
           var obj = baiMIXConfigurationInfo.GetiMIXConfigurationInfoData().Where(p => p.SubstoreId == subStoreId)
                .Select(p => new PhotoSW.IMIX.Model.iMIXConfigurationInfo
                {

                    IMIXConfigurationValueId = p.IMIXConfigurationValueId,
                    IMIXConfigurationMasterId = p.IMIXConfigurationMasterId,
                    ConfigurationValue = p.ConfigurationValue,
                    SubstoreId = p.SubstoreId,
                    SyncCode = p.SyncCode,
                    IsSynced = p.IsSynced,

                }).ToList();
           return obj;
       }
       public string GetOnlineConfigData(ConfigParams objConfigParams, int SubStoreId)
       {
           return "";
       }
       public List<PhotoSW.IMIX.Model.ReportTypeDetails> GetReport()
       {

            List<PhotoSW.IMIX.Model.ReportTypeDetails> obj = new List<ReportTypeDetails>();
            return obj;
       }
       public PhotoSW.IMIX.Model.ReportConfigurationDetails GetReportConfigurationDetails()
       {
            PhotoSW.IMIX.Model.ReportConfigurationDetails obj = new ReportConfigurationDetails();
            return obj;
       }
       public List<PhotoSW.IMIX.Model.ReportTypeDetails> GetRequestedReports()
       {
           List<PhotoSW.IMIX.Model.ReportTypeDetails> obj = new List<ReportTypeDetails>();
           return obj;
       }
       public List<PhotoSW.IMIX.Model.StockShot> GetStockShotImagesList(long ImageId)
       {
           List<PhotoSW.IMIX.Model.StockShot> obj = new List<StockShot>();
           return obj;
       }
       public List<PhotoSW.IMIX.Model.iMIXStoreConfigurationInfo> GetStoreConfigData()
       {
            try
                {
                var obj = baiMIXStoreConfigurationInfo.GetiMIXStoreConfigurationInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.iMIXStoreConfigurationInfo()
                        {
                        iMIXStoreConfigurationValueId = p.iMIXStoreConfigurationValueId,
                        IMIXConfigurationMasterId = p.IMIXConfigurationMasterId,
                        ConfigurationValue = p.ConfigurationValue,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        ModifiedDate = p.ModifiedDate
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.iMIXStoreConfigurationInfo>();
                }
            //List<PhotoSW.IMIX.Model.iMIXStoreConfigurationInfo> obj = new List<iMIXStoreConfigurationInfo>();
            //return obj;
            }
       public List<PhotoSW.IMIX.Model.ConfigInfo> GetSubStoreConfigs(int subStoreId)
       {
            try
                {
                var obj = baConfigInfo.GetConfigInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.ConfigInfo()
                        {
                        ConfigID = p.ConfigID,
                        SubStoreID = p.SubStoreID,
                        ConfigKey = p.ConfigKey,
                        ConfigValue = p.ConfigValue,
                        MasterID = p.MasterID
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.ConfigInfo>();
                }

            //List<PhotoSW.IMIX.Model.ConfigInfo> obj = new List<ConfigInfo>();
            //return obj;
            }
       public int GetSubstoreLocationWise(int locationid)
       {
           return 0;
       }
       public string GetSubStoreNameBySuubStoreId(int subStoreId)
       {
           return "";
       }
       public string GetSubStorePasswordPath(int configId, int subStoreId)
       {
           return "";
       }
       public List<PhotoSW.IMIX.Model.VideoBackgroundInfo> GetVideoBackgrounds()
       {
           return new List<PhotoSW.IMIX.Model.VideoBackgroundInfo>();
       }
       public PhotoSW.IMIX.Model.VideoBackgroundInfo GetVideoBackgrounds(long vidBgID)
       {
           return new PhotoSW.IMIX.Model.VideoBackgroundInfo();
       }
       public List<PhotoSW.IMIX.Model.VideoSceneViewModel> GetVideoConfigProfileList(int profileId, int substoreid)
       {
           return new List<PhotoSW.IMIX.Model.VideoSceneViewModel>();
       }
       public PhotoSW.IMIX.Model.VideoSceneViewModel GetVideoConfigProfileList(long profileId, int substoreid)
       {
           return new PhotoSW.IMIX.Model.VideoSceneViewModel();
       }
       public List<PhotoSW.IMIX.Model.VideoOverlay> GetVideoOverlays()
       {
           return new List<PhotoSW.IMIX.Model.VideoOverlay>();
       }
       public PhotoSW.IMIX.Model.VideoOverlay GetVideoOverlays(long VideoOverlayId)
       {
           return new  PhotoSW.IMIX.Model.VideoOverlay();
       }
       public PhotoSW.IMIX.Model.VideoSceneViewModel GetVideoSceneBasedOnPhotoId(int photoId)
       {
           return new PhotoSW.IMIX.Model.VideoSceneViewModel();
       }
       public List<PhotoSW.IMIX.Model.VideoTemplateInfo> GetVideoTemplate()
       {
           return new List<PhotoSW.IMIX.Model.VideoTemplateInfo>();
       }
       public PhotoSW.IMIX.Model.VideoTemplateInfo GetVideoTemplate(long videoTemplateId)
       {
           return new PhotoSW.IMIX.Model.VideoTemplateInfo();
       }
       public bool InsertReportConfig(PhotoSW.IMIX.Model.ReportConfigurationDetails reportConfigurationDetails)
       {
           return false;
       }
       public bool IsLocationRFIDEnabled(int locationId)
       {
           return false;
       }
       public DataTable ParseListIntoPaymentDataTable(List<PhotoSW.IMIX.Model.PaymentSummaryInfo> paymentSummaryInfo)
       {
           return new DataTable ();
       }
       public int SaveCGConfigSetting(PhotoSW.IMIX.Model.CGConfigSettings CGConfigSettings)
       {
           return 0 ;
       }

        public bool SaveUpdateChromaKeyTemplate ( PhotoSW.IMIX.Model.ChromaKeyTemplateInfo lstChromaKeyValue )
            {
            return false;
            }

        public bool SaveEmailDetails(string toAddress, string toBCC, string sender,
           string msgBody, string msgType) 
       { return false; }
       public bool SaveEmailDetails(string toAddress, string toBCC, string sender, string msgBody, string msgType, int subStoreId) 
       { return false; }
       public bool SaveExportReportLogDetails(PhotoSW.IMIX.Model.ExportServiceLog exportReportLogDetails)
       { return false; }


       public bool SaveUpdateAudioTemplate(PhotoSW.IMIX.Model.AudioTemplateInfo lstAudioValue)
       { return false; }
       public bool SaveUpdateConfigLocation(List<PhotoSW.IMIX.Model.iMixConfigurationLocationInfo> lstIMixConfigLocInfo)
       { return false; }
       public bool SaveUpdateNewConfig(List<PhotoSW.IMIX.Model.iMIXConfigurationInfo> lstConfigValue)
       { return false; }
       public bool SaveUpdateNewStoreConfig(List<PhotoSW.IMIX.Model.iMIXStoreConfigurationInfo> lstStoreConfigValue) 
       { return false; }
       public bool SaveUpdatePreviewDummyTag(PhotoSW.IMIX.Model.iMIXStoreConfigurationInfo objImixStoreInfo)
       { return false; }
       public long SaveUpdateStockShotImage(PhotoSW.IMIX.Model.StockShot image)
       { return 0; }
       public int SaveUpdateVideoBackground(PhotoSW.IMIX.Model.VideoBackgroundInfo lstVideoBGValue)
       { return 0; }
       public int SaveUpdateVideoOverlay(PhotoSW.IMIX.Model.VideoOverlay lstVideoBGValue)
       {
           return 0;
       }
       public bool SaveVideoSlot(PhotoSW.IMIX.Model.VideoTemplateInfo videoTemplate)
       { return false; }
       public bool SaveVideoTemplate(PhotoSW.IMIX.Model.VideoTemplateInfo videoTemplate)
       { return false; }
       public bool SetConfigurationData(string SyncCode, string hotfolder,
           string framePath, string bgPath, string ModPassword, string graphics,
           int NumberofImages, bool? Iswatermark, bool? IsHighResolution,
           bool? isSemiorder, bool? isAutoRotate, bool? IsLineItemDiscount,
           bool? IsTotalDiscount, bool? IsPosOnOff, int defaultCurrency,
           bool? IsSemiOrderMain, int substoreId, bool? IsCompression,
           bool? IsEnableGroup, int NoOfReceipt, string ChromaColor,
           decimal ChromaTolerance, int PageSizeGrid, int PageSizePreview,
           int NoOfPhotoIdSearch, bool? isExportReportToAnyDrive)
       {

           return false; 
       }
       public bool SetSemiorderConfigurationData(PhotoSW.IMIX.Model.SemiOrderSettings objSemi)
       { return false; }
       public void UpdateReportTypes(List<PhotoSW.IMIX.Model.ReportTypeDetails> reportTypes)
       { 
          
       }
       public bool UpdateTriggerStatus(List<PhotoSW.IMIX.Model.SyncTriggerStatusInfo> lstTriggerStatus)
       { 
           return false;
       }

    }
}
