using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_Configuration"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Configuration : EntityObject
        {

        private int _PS_Config_pkey;

        private string _PS_Hot_Folder_Path;

        private string _PS_Frame_Path;

        private string _PS_BG_Path;

        private string _PS_Mod_Password;

        private int? _PS_NoOfPhotos;

        private bool? _PS_Watermark;

        private bool? _PS_SemiOrder;

        private bool? _PS_HighResolution;

        private bool? _PS_AllowDiscount;

        private bool? _PS_EnableDiscountOnTotal;

        private decimal? _WiFiStartingNumber;

        private decimal? _FolderStartingNumber;

        private bool? _IsAutoLock;

        private bool? _PS_SemiOrderMain;

        private bool? _PosOnOff;

        private string _PS_ReceiptPrinter;

        private bool? _PS_IsAutoRotate;

        private string _PS_Graphics_Path;

        private bool? _PS_IsCompression;

        private bool? _PS_IsEnableGroup;

        private int? _PS_Substore_Id;

        private int? _PS_NoOfBillReceipt;

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

        private int? _PS_NoOfPhotoIdSearch;

        private bool? _IsRecursive;

        private int? _IntervalCount;

        private int? _intervalType;

        private string _PS_MktImgPath;

        private int? _PS_MktImgTimeInSec;

        private string _EK_SampleImagePath;

        private int? _EK_DisplayDuration;

        private int? _EK_ScreenStartTime;

        private bool? _EK_IsScreenSaverActive;

        private bool? _IsDeleteFromUSB;

        private int? _PS_CleanUpDaysBackUp;

        private string _FtpIP;

        private string _FtpUid;

        private string _FtpPwd;

        private string _FtpFolder;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

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
               // this.ReportPropertyChanging(DG_Configuration.(7610));
                this._PS_Config_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_Configuration.(7610));
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
                   // this.ReportPropertyChanging(DG_Configuration.(7631));
                    this._PS_Hot_Folder_Path = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(7631));
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
                    //this.ReportPropertyChanging(DG_Configuration.(7656));
                    this._PS_Frame_Path = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(7656));
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
                  //  this.ReportPropertyChanging(DG_Configuration.(7677));
                    this._PS_BG_Path = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(7677));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
                   // this.ReportPropertyChanging(DG_Configuration.(7694));
                    this._PS_Mod_Password = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(7694));
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
              //  this.ReportPropertyChanging(DG_Configuration.(7715));
                this._PS_NoOfPhotos = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(7715));
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
              //  this.ReportPropertyChanging(DG_Configuration.(7736));
                this._PS_Watermark = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(7736));
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
              //  this.ReportPropertyChanging(DG_Configuration.(7753));
                this._PS_SemiOrder = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(7753));
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
              //  this.ReportPropertyChanging(DG_Configuration.(7770));
                this._PS_HighResolution = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Configuration.(7770));
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
               // this.ReportPropertyChanging(DG_Configuration.(7795));
                this._PS_AllowDiscount = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(7795));
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
               // this.ReportPropertyChanging(DG_Configuration.(7820));
                this._PS_EnableDiscountOnTotal = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(7820));
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
              //  this.ReportPropertyChanging(DG_Configuration.(7853));
                this._WiFiStartingNumber = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(7853));
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
              //  this.ReportPropertyChanging(DG_Configuration.(7878));
                this._FolderStartingNumber = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(7878));
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
              //  this.ReportPropertyChanging(DG_Configuration.(7907));
                this._IsAutoLock = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Configuration.(7907));
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
             //   this.ReportPropertyChanging(DG_Configuration.(7924));
                this._PS_SemiOrderMain = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Configuration.(7924));
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
             //   this.ReportPropertyChanging(DG_Configuration.(7949));
                this._PosOnOff = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Configuration.(7949));
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
               //     this.ReportPropertyChanging(DG_Configuration.(2259));
                    this._PS_ReceiptPrinter = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(2259));
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
             //   this.ReportPropertyChanging(DG_Configuration.(7962));
                this._PS_IsAutoRotate = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Configuration.(7962));
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
                  //  this.ReportPropertyChanging(DG_Configuration.(7983));
                    this._PS_Graphics_Path = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(7983));
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
               // this.ReportPropertyChanging(DG_Configuration.(8008));
                this._PS_IsCompression = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(8008));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? DG_IsEnableGroup
            {
            get
                {
                return this._PS_IsEnableGroup;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Configuration.(8033));
                this._PS_IsEnableGroup = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(8033));
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
               // this.ReportPropertyChanging(DG_Configuration.(8058));
                this._PS_Substore_Id = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Configuration.(8058));
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
               // this.ReportPropertyChanging(DG_Configuration.(8079));
                this._PS_NoOfBillReceipt = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Configuration.(8079));
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
                   // this.ReportPropertyChanging(DG_Configuration.(8104));
                    this._PS_ChromaColor = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(8104));
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
               // this.ReportPropertyChanging(DG_Configuration.(8125));
                this._PS_ChromaTolerance = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Configuration.(8125));
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
                  //  this.ReportPropertyChanging(DG_Configuration.(8150));
                    this._PS_DbBackupPath = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(8150));
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
                   // this.ReportPropertyChanging(DG_Configuration.(8171));
                    this._PS_CleanupTables = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(8171));
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
                  //  this.ReportPropertyChanging(DG_Configuration.(8196));
                    this._PS_HfBackupPath = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(8196));
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
                  //  this.ReportPropertyChanging(DG_Configuration.(8217));
                    this._PS_ScheduleBackup = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(8217));
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
              //  this.ReportPropertyChanging(DG_Configuration.(8242));
                this._PS_IsBackupScheduled = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(8242));
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
              //  this.ReportPropertyChanging(DG_Configuration.(8271));
                this._PS_Brightness = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(8271));
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
             //   this.ReportPropertyChanging(DG_Configuration.(8292));
                this._PS_Contrast = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Configuration.(8292));
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
             //   this.ReportPropertyChanging(DG_Configuration.(8309));
                this._PS_PageCountGrid = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(DG_Configuration.(8309));
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
               // this.ReportPropertyChanging(DG_Configuration.(8334));
                this._PS_PageCountPreview = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Configuration.(8334));
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
             //   this.ReportPropertyChanging(DG_Configuration.(8363));
                this._PS_NoOfPhotoIdSearch = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Configuration.(8363));
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
             //   this.ReportPropertyChanging(DG_Configuration.(8392));
                this._IsRecursive = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(8392));
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
              //  this.ReportPropertyChanging(DG_Configuration.(8409));
                this._IntervalCount = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Configuration.(8409));
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
              //  this.ReportPropertyChanging(DG_Configuration.(8430));
                this._intervalType = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(DG_Configuration.(8430));
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
                //    this.ReportPropertyChanging(DG_Configuration.(8447));
                    this._PS_MktImgPath = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(8447));
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
              //  this.ReportPropertyChanging(DG_Configuration.(8468));
                this._PS_MktImgTimeInSec = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(8468));
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
                 //   this.ReportPropertyChanging(DG_Configuration.(8493));
                    this._EK_SampleImagePath = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(8493));
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
              //  this.ReportPropertyChanging(DG_Configuration.(8518));
                this._EK_DisplayDuration = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(8518));
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
              //  this.ReportPropertyChanging(DG_Configuration.(8543));
                this._EK_ScreenStartTime = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(8543));
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
              //  this.ReportPropertyChanging(DG_Configuration.(8568));
                this._EK_IsScreenSaverActive = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Configuration.(8568));
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
             //   this.ReportPropertyChanging(DG_Configuration.(8601));
                this._IsDeleteFromUSB = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Configuration.(8601));
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
             //   this.ReportPropertyChanging(DG_Configuration.(8622));
                this._PS_CleanUpDaysBackUp = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Configuration.(8622));
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
                 //   this.ReportPropertyChanging(DG_Configuration.(8651));
                    this._FtpIP = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(8651));
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
                 //   this.ReportPropertyChanging(DG_Configuration.(8660));
                    this._FtpUid = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(8660));
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
                  //  this.ReportPropertyChanging(DG_Configuration.(8669));
                    this._FtpPwd = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(8669));
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
                 //   this.ReportPropertyChanging(DG_Configuration.(8678));
                    this._FtpFolder = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Configuration.(8678));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SyncCode
            {
            get
                {
                return this._SyncCode;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Configuration.(6485));
					this._SyncCode = StructuralObject.SetValidValue(value, true);
					//do
					//{
					//	if (!false)
					//	{
					//	//	this.ReportPropertyChanged(DG_Configuration.(6485));
					//	}
					//}
					//while (false);
				}
				while (false);
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public bool IsSynced
		{
			get
			{
				return this._IsSynced;
			}
			set
			{
			//	this.ReportPropertyChanging(DG_Configuration.(6498));
				this._IsSynced = StructuralObject.SetValidValue(value);
			//	this.ReportPropertyChanged(DG_Configuration.(6498));
			}
		}

		public static PS_Configuration CreateDG_Configuration(int dG_Config_pkey, bool isSynced)
		{
			return new PS_Configuration
			{
				PS_Config_pkey = dG_Config_pkey,
				IsSynced = isSynced
			};
		}

		static PS_Configuration()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//Strings.CreateGetStringDelegate(typeof(DG_Configuration));
		}

        }
    }
