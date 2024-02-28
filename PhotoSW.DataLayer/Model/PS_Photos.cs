using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Photos"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Photos : EntityObject
        {

        private int _PS_Photos_pkey;

        private string _PS_Photos_FileName;

        private DateTime _PS_Photos_CreatedOn;

        private string _PS_Photos_RFID;

        private int? _PS_Photos_UserID;

        private string _PS_Photos_Background;

        private string _PS_Photos_Frame;

        private DateTime? _PS_Photos_DateTime;

        private string _PS_Photos_Layering;

        private string _PS_Photos_Effects;

        private bool? _PS_Photos_IsCroped;

        private bool? _PS_Photos_IsRedEye;

        private bool? _PS_Photos_IsGreen;

        private string _PS_Photos_MetaData;

        private string _PS_Photos_Sizes;

        private bool? _PS_Photos_Archive;

        private int? _PS_Location_Id;

        private int? _PS_SubStoreId;

        private bool _PS_IsCodeType;

        private DateTime? _DateTaken;

        private int? _RfidScanType;

        private bool _IsImageProcessed;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Photos_pkey
            {
            get
                {
                return this._PS_Photos_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Photos_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_Photos.(5587));
                this._PS_Photos_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_Photos.(5587));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Photos_FileName
            {
            get
                {
                return this._PS_Photos_FileName;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Photos.(5608));
                    this._PS_Photos_FileName = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Photos.(5608));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public DateTime PS_Photos_CreatedOn
            {
            get
                {
                return this._PS_Photos_CreatedOn;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Photos.(5633));
                this._PS_Photos_CreatedOn = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Photos.(5633));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_RFID
            {
            get
                {
                return this._PS_Photos_RFID;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Photos.(5662));
                    this._PS_Photos_RFID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Photos.(5662));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Photos_UserID
            {
            get
                {
                return this._PS_Photos_UserID;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Photos.(5683));
                this._PS_Photos_UserID = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Photos.(5683));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_Background
            {
            get
                {
                return this._PS_Photos_Background;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Photos.(5708));
                    this._PS_Photos_Background = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Photos.(5708));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_Frame
            {
            get
                {
                return this._PS_Photos_Frame;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Photos.(5737));
                    this._PS_Photos_Frame = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Photos.(5737));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Photos_DateTime
            {
            get
                {
                return this._PS_Photos_DateTime;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Photos.(5758));
                this._PS_Photos_DateTime = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Photos.(5758));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_Layering
            {
            get
                {
                return this._PS_Photos_Layering;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_Photos.(5783));
                    this._PS_Photos_Layering = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Photos.(5783));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_Effects
            {
            get
                {
                return this._PS_Photos_Effects;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Photos.(5808));
                    this._PS_Photos_Effects = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Photos.(5808));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Photos_IsCroped
            {
            get
                {
                return this._PS_Photos_IsCroped;
                }
            set
                {
                //this.ReportPropertyChanging(DG_Photos.(5833));
                this._PS_Photos_IsCroped = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(DG_Photos.(5833));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Photos_IsRedEye
            {
            get
                {
                return this._PS_Photos_IsRedEye;
                }
            set
                {
                //this.ReportPropertyChanging(DG_Photos.(5858));
                this._PS_Photos_IsRedEye = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(DG_Photos.(5858));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Photos_IsGreen
            {
            get
                {
                return this._PS_Photos_IsGreen;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Photos.(5883));
                this._PS_Photos_IsGreen = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Photos.(5883));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_MetaData
            {
            get
                {
                return this._PS_Photos_MetaData;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Photos.(5908));
                    this._PS_Photos_MetaData = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Photos.(5908));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_Sizes
            {
            get
                {
                return this._PS_Photos_Sizes;
                }
            set
                {
                do
                    {
                    //this.ReportPropertyChanging(DG_Photos.(5933));
                    this._PS_Photos_Sizes = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Photos.(5933));
                    //        }
                    //    }
                    ////while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Photos_Archive
            {
            get
                {
                return this._PS_Photos_Archive;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Photos.(5954));
                this._PS_Photos_Archive = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Photos.(5954));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Location_Id
            {
            get
                {
                return this._PS_Location_Id;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Photos.(5979));
                this._PS_Location_Id = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Photos.(5979));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_SubStoreId
            {
            get
                {
                return this._PS_SubStoreId;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Photos.(6000));
                this._PS_SubStoreId = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Photos.(6000));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public bool PS_IsCodeType
            {
            get
                {
                return this._PS_IsCodeType;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Photos.(12531));
                this._PS_IsCodeType = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Photos.(12531));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? DateTaken
            {
            get
                {
                return this._DateTaken;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Photos.(12552));
                this._DateTaken = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Photos.(12552));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? RfidScanType
            {
            get
                {
                return this._RfidScanType;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Photos.(12565));
                this._RfidScanType = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Photos.(12565));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public bool IsImageProcessed
            {
            get
                {
                return this._IsImageProcessed;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Photos.(12582));
                this._IsImageProcessed = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Photos.(12582));
                }
            }

        //[EdmRelationshipNavigationProperty("DigiphotoModel", "FK_PrintOrder_DG_Photos", "PhotoAlbumPrintOrder"), DataMember, SoapIgnore, XmlIgnore]
        //public EntityCollection<PhotoAlbumPrintOrder> PhotoAlbumPrintOrder
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<PhotoAlbumPrintOrder>(DG_Photos.(12607), DG_Photos.(2651));
        //        }
        //    set
        //        {
        //        if(value != null)
        //            {
        //            RelationshipManager expr_30 = ((IEntityWithRelationships)this).RelationshipManager;
        //            string expr_37 = DG_Photos.(12607);
        //            string expr_3E = DG_Photos.(2651);
        //            if(!false)
        //                {
        //                expr_30.InitializeRelatedCollection<PhotoAlbumPrintOrder>(expr_37, expr_3E, value);
        //                }
        //            }
        //        }
        //    }

        public static PS_Photos CreateDG_Photos ( int dG_Photos_pkey, string dG_Photos_FileName, DateTime dG_Photos_CreatedOn, bool dG_IsCodeType, bool isImageProcessed )
            {
            PS_Photos dG_Photos;
            if(true)
                {
                dG_Photos = new PS_Photos();
                do
                    {
                    dG_Photos.PS_Photos_pkey = dG_Photos_pkey;
                    }
                while(false);
                if(6 == 0)
                    {
                    return dG_Photos;
                    }
                dG_Photos.PS_Photos_FileName = dG_Photos_FileName;
                dG_Photos.PS_Photos_CreatedOn = dG_Photos_CreatedOn;
                }
            dG_Photos.PS_IsCodeType = dG_IsCodeType;
            dG_Photos.IsImageProcessed = isImageProcessed;
            return dG_Photos;
            }

        static PS_Photos ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Photos));
            }

        }
    }
