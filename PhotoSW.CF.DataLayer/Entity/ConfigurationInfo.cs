using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    
    [Table("ConfigurationInfo")]
    public class configurationinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        //[ForeignKey("AddOns_Id")]
        //public virtual ICollection<serviceaddon> serviceaddons { get; set; }

    }
}
