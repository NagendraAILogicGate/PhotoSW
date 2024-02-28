using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetConfigdata"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetConfigdata : EntityObject
        {
        private int _PS_Config_pkey;

        private string _PS_Hot_Folder_Path;

        private string _PS_Frame_Path;

        private string _PS_BG_Path;

        private bool? _PS_IsCompression;

        private string _PS_Mod_Password;

        private int? _PS_NoOfPhotos;

        private string _PS_Graphics_Path;

        private bool? _PS_Watermark;

        private bool? _PS_SemiOrder;

        private bool? _PS_HighResolution;

        private bool? _PS_AllowDiscount;

        private bool? _PS_EnableDiscountOnTotal;

        private decimal? _WiFiStartingNumber;

        private decimal? _FolderStartingNumber;

        private bool? _IsAutoLock;

        private bool? _PosOnOff;

        private int? _PS_Substore_Id;

        private int? _PS_NoOfBillReceipt;

        private int? _PS_NoOfPhotoIdSearch;

        private int? _IntervalCount;

        private bool? _IsRecursive;

        private int? _intervalType;

        private bool? _IsDeleteFromUSB;

        private int? _DefaultCurrency;

        private bool? _PS_SemiOrderMain;

        private string _PS_ReceiptPrinter;

        private bool? _PS_IsAutoRotate;

        private bool? _PS_IsEnableGroup;

        private string _PS_ChromaColor;

        private decimal? _PS_ChromaTolerance;

        private string _PS_DbBackupPath;

        private string _PS_CleanupTables;

        private string _PS_HfBackupPath;

        private string _PS_ScheduleBackup;

        private bool? _PS_IsBackupScheduled;

        private double? _PS_Brightness;

        private double? _PS_Contrast;

        private int? _PS_PageCountGrid;

        private int? _PS_PageCountPreview;

        private string _PS_MktImgPath;

        private int? _PS_MktImgTimeInSec;

        private string _EK_SampleImagePath;

        private int? _EK_DisplayDuration;

        private int? _EK_ScreenStartTime;

        private bool? _EK_IsScreenSaverActive;

        private int? _PS_CleanUpDaysBackUp;

        private string _FtpIP;

        private string _FtpUid;

        private string _FtpPwd;

        private string _FtpFolder;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Config_pkey
            {
            get
                {
                return this._PS_Config_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Config_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(vw_GetConfigdata.(8177));
                this._PS_Config_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(vw_GetConfigdata.(8177));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Hot_Folder_Path
            {
            get
                {
                return this._PS_Hot_Folder_Path;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(vw_GetConfigdata.(8198));
                    this._PS_Hot_Folder_Path = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(8198));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Frame_Path
            {
            get
                {
                return this._PS_Frame_Path;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(vw_GetConfigdata.(8223));
                    this._PS_Frame_Path = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(8223));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_BG_Path
            {
            get
                {
                return this._PS_BG_Path;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(vw_GetConfigdata.(8244));
                    this._PS_BG_Path = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(8244));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_IsCompression
            {
            get
                {
                return this._PS_IsCompression;
                }
            set
                {
               // this.ReportPropertyChanging(vw_GetConfigdata.(8575));
                this._PS_IsCompression = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(vw_GetConfigdata.(8575));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Mod_Password
            {
            get
                {
                return this._PS_Mod_Password;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(vw_GetConfigdata.(8261));
                    this._PS_Mod_Password = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(8261));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_NoOfPhotos
            {
            get
                {
                return this._PS_NoOfPhotos;
                }
            set
                {
              //  this.ReportPropertyChanging(vw_GetConfigdata.(8282));
                this._PS_NoOfPhotos = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(vw_GetConfigdata.(8282));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Graphics_Path
            {
            get
                {
                return this._PS_Graphics_Path;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_GetConfigdata.(8550));
                    this._PS_Graphics_Path = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(8550));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Watermark
            {
            get
                {
                return this._PS_Watermark;
                }
            set
                {
              //  this.ReportPropertyChanging(vw_GetConfigdata.(8303));
                this._PS_Watermark = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(vw_GetConfigdata.(8303));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SemiOrder
            {
            get
                {
                return this._PS_SemiOrder;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_GetConfigdata.(8320));
                this._PS_SemiOrder = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(vw_GetConfigdata.(8320));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_HighResolution
            {
            get
                {
                return this._PS_HighResolution;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_GetConfigdata.(8337));
                this._PS_HighResolution = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetConfigdata.(8337));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_AllowDiscount
            {
            get
                {
                return this._PS_AllowDiscount;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetConfigdata.(8362));
                this._PS_AllowDiscount = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetConfigdata.(8362));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_EnableDiscountOnTotal
            {
            get
                {
                return this._PS_EnableDiscountOnTotal;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetConfigdata.(8387));
                this._PS_EnableDiscountOnTotal = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetConfigdata.(8387));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? WiFiStartingNumber
            {
            get
                {
                return this._WiFiStartingNumber;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetConfigdata.(8420));
                this._WiFiStartingNumber = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetConfigdata.(8420));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? FolderStartingNumber
            {
            get
                {
                return this._FolderStartingNumber;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetConfigdata.(8445));
                this._FolderStartingNumber = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetConfigdata.(8445));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? IsAutoLock
            {
            get
                {
                return this._IsAutoLock;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_GetConfigdata.(8474));
                this._IsAutoLock = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetConfigdata.(8474));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PosOnOff
            {
            get
                {
                return this._PosOnOff;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetConfigdata.(8516));
                this._PosOnOff = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetConfigdata.(8516));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Substore_Id
            {
            get
                {
                return this._PS_Substore_Id;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetConfigdata.(8625));
                this._PS_Substore_Id = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetConfigdata.(8625));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_NoOfBillReceipt
            {
            get
                {
                return this._PS_NoOfBillReceipt;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetConfigdata.(8646));
                this._PS_NoOfBillReceipt = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetConfigdata.(8646));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_NoOfPhotoIdSearch
            {
            get
                {
                return this._PS_NoOfPhotoIdSearch;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_GetConfigdata.(8930));
                this._PS_NoOfPhotoIdSearch = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetConfigdata.(8930));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? IntervalCount
            {
            get
                {
                return this._IntervalCount;
                }
            set
                {
         //       this.ReportPropertyChanging(vw_GetConfigdata.(8976));
                this._IntervalCount = StructuralObject.SetValidValue(value);
        //        this.ReportPropertyChanged(vw_GetConfigdata.(8976));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? IsRecursive
            {
            get
                {
                return this._IsRecursive;
                }
            set
                {
         //       this.ReportPropertyChanging(vw_GetConfigdata.(8959));
                this._IsRecursive = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetConfigdata.(8959));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? intervalType
            {
            get
                {
                return this._intervalType;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_GetConfigdata.(8997));
                this._intervalType = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetConfigdata.(8997));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? IsDeleteFromUSB
            {
            get
                {
                return this._IsDeleteFromUSB;
                }
            set
                {
         //       this.ReportPropertyChanging(vw_GetConfigdata.(9168));
                this._IsDeleteFromUSB = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetConfigdata.(9168));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? DefaultCurrency
            {
            get
                {
                return this._DefaultCurrency;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetConfigdata.(18615));
                this._DefaultCurrency = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetConfigdata.(18615));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SemiOrderMain
            {
            get
                {
                return this._PS_SemiOrderMain;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_GetConfigdata.(8491));
                this._PS_SemiOrderMain = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetConfigdata.(8491));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_ReceiptPrinter
            {
            get
                {
                return this._PS_ReceiptPrinter;
                }
            set
                {
                do
                    {
             //       this.ReportPropertyChanging(vw_GetConfigdata.(2826));
                    this._PS_ReceiptPrinter = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(2826));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_IsAutoRotate
            {
            get
                {
                return this._PS_IsAutoRotate;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_GetConfigdata.(8529));
                this._PS_IsAutoRotate = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(vw_GetConfigdata.(8529));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_IsEnableGroup
            {
            get
                {
                return this._PS_IsEnableGroup;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetConfigdata.(8600));
                this._PS_IsEnableGroup = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetConfigdata.(8600));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_ChromaColor
            {
            get
                {
                return this._PS_ChromaColor;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(vw_GetConfigdata.(8671));
                    this._PS_ChromaColor = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(8671));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_ChromaTolerance
            {
            get
                {
                return this._PS_ChromaTolerance;
                }
            set
                {
               // this.ReportPropertyChanging(vw_GetConfigdata.(8692));
                this._PS_ChromaTolerance = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(vw_GetConfigdata.(8692));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_DbBackupPath
            {
            get
                {
                return this._PS_DbBackupPath;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_GetConfigdata.(8717));
                    this._PS_DbBackupPath = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(8717));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_CleanupTables
            {
            get
                {
                return this._PS_CleanupTables;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(vw_GetConfigdata.(8738));
                    this._PS_CleanupTables = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(8738));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_HfBackupPath
            {
            get
                {
                return this._PS_HfBackupPath;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_GetConfigdata.(8763));
                    this._PS_HfBackupPath = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(8763));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_ScheduleBackup
            {
            get
                {
                return this._PS_ScheduleBackup;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(vw_GetConfigdata.(8784));
                    this._PS_ScheduleBackup = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(8784));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_IsBackupScheduled
            {
            get
                {
                return this._PS_IsBackupScheduled;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_GetConfigdata.(8809));
                this._PS_IsBackupScheduled = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetConfigdata.(8809));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public double? PS_Brightness
            {
            get
                {
                return this._PS_Brightness;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetConfigdata.(8838));
                this._PS_Brightness = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetConfigdata.(8838));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public double? PS_Contrast
            {
            get
                {
                return this._PS_Contrast;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_GetConfigdata.(8859));
                this._PS_Contrast = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetConfigdata.(8859));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_PageCountGrid
            {
            get
                {
                return this._PS_PageCountGrid;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetConfigdata.(8876));
                this._PS_PageCountGrid = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetConfigdata.(8876));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_PageCountPreview
            {
            get
                {
                return this._PS_PageCountPreview;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetConfigdata.(8901));
                this._PS_PageCountPreview = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetConfigdata.(8901));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_MktImgPath
            {
            get
                {
                return this._PS_MktImgPath;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(vw_GetConfigdata.(9014));
                    this._PS_MktImgPath = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(9014));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_MktImgTimeInSec
            {
            get
                {
                return this._PS_MktImgTimeInSec;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_GetConfigdata.(9035));
                this._PS_MktImgTimeInSec = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetConfigdata.(9035));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string EK_SampleImagePath
            {
            get
                {
                return this._EK_SampleImagePath;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(vw_GetConfigdata.(9060));
                    this._EK_SampleImagePath = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(9060));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? EK_DisplayDuration
            {
            get
                {
                return this._EK_DisplayDuration;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetConfigdata.(9085));
                this._EK_DisplayDuration = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetConfigdata.(9085));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? EK_ScreenStartTime
            {
            get
                {
                return this._EK_ScreenStartTime;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetConfigdata.(9110));
                this._EK_ScreenStartTime = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetConfigdata.(9110));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? EK_IsScreenSaverActive
            {
            get
                {
                return this._EK_IsScreenSaverActive;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetConfigdata.(9135));
                this._EK_IsScreenSaverActive = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetConfigdata.(9135));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_CleanUpDaysBackUp
            {
            get
                {
                return this._PS_CleanUpDaysBackUp;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetConfigdata.(9189));
                this._PS_CleanUpDaysBackUp = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetConfigdata.(9189));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string FtpIP
            {
            get
                {
                return this._FtpIP;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(vw_GetConfigdata.(9218));
                    this._FtpIP = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(9218));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string FtpUid
            {
            get
                {
                return this._FtpUid;
                }
            set
                {
                do
                    {
             //       this.ReportPropertyChanging(vw_GetConfigdata.(9227));
                    this._FtpUid = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(9227));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string FtpPwd
            {
            get
                {
                return this._FtpPwd;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(vw_GetConfigdata.(9236));
                    this._FtpPwd = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetConfigdata.(9236));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string FtpFolder
            {
            get
                {
                return this._FtpFolder;
                }
            set
                {
                do
                    {
             //       this.ReportPropertyChanging(vw_GetConfigdata.(9245));
					this._FtpFolder = StructuralObject.SetValidValue(value, true);
					//do
					//{
					//	if (!false)
					//	{
					//		this.ReportPropertyChanged(vw_GetConfigdata.(9245));
					//	}
					//}
					//while (false);
				}
				while (false);
			}
		}

		public static vw_GetConfigdata Createvw_GetConfigdata(int dG_Config_pkey)
		{
			return new vw_GetConfigdata
			{
				PS_Config_pkey = dG_Config_pkey
			};
		}

		static vw_GetConfigdata()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//Strings.CreateGetStringDelegate(typeof(vw_GetConfigdata));
		}

        }
    }
