using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetPhotoList"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetPhotoList : EntityObject
        {
        private int? _PS_Photos_UserID;

        private string _PS_User_Name;

        private string _PS_Photos_FileName;

        private DateTime _PS_Photos_CreatedOn;

        private string _PS_Photos_RFID;

        private string _PS_Photos_Background;

        private string _PS_Photos_Frame;

        private DateTime? _PS_Photos_DateTime;

        private int _PS_Photos_pkey;

        private string _PS_Photos_Layering;

        private string _PS_Photos_Effects;

        private bool? _PS_Photos_IsCroped;

        private bool? _PS_Photos_IsRedEye;

        private bool? _PS_Photos_Archive;

        private int? _PS_Location_ID;

        private int? _PS_SubStoreId;

        private bool _PS_IsCodeType;

        private DateTime? _DateTaken;

        private int? _RfidScanType;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Photos_UserID
            {
            get
                {
                return this._PS_Photos_UserID;
                }
            set
                {
              //  this.ReportPropertyChanging(vw_GetPhotoList.(6223));
                this._PS_Photos_UserID = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(vw_GetPhotoList.(6223));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_User_Name
            {
            get
                {
                return this._PS_User_Name;
                }
            set
                {
                if(!(this._PS_User_Name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
           //     this.ReportPropertyChanging(vw_GetPhotoList.(17321));
                IL_1D:
                this._PS_User_Name = StructuralObject.SetValidValue(value, false);
            //    this.ReportPropertyChanged(vw_GetPhotoList.(17321));
                IL_3E:
                if(false)
                    {
                    goto IL_0D;
                    }
                if(!false)
                    {
                    return;
                    }
                goto IL_1D;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_Photos_FileName
            {
            get
                {
                return this._PS_Photos_FileName;
                }
            set
                {
                if(!(this._PS_Photos_FileName != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
             //   this.ReportPropertyChanging(vw_GetPhotoList.(6148));
                IL_1D:
                this._PS_Photos_FileName = StructuralObject.SetValidValue(value, false);
            //    this.ReportPropertyChanged(vw_GetPhotoList.(6148));
                IL_3E:
                if(false)
                    {
                    goto IL_0D;
                    }
                if(!false)
                    {
                    return;
                    }
                goto IL_1D;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public DateTime PS_Photos_CreatedOn
            {
            get
                {
                return this._PS_Photos_CreatedOn;
                }
            set
                {
                if(this._PS_Photos_CreatedOn != value)
                    {
                 //   string expr_54 = vw_GetPhotoList.(6173);
                    //if(3 != 0)
                    //    {
                    //    this.ReportPropertyChanging(expr_54);
                    //    }
                    this._PS_Photos_CreatedOn = StructuralObject.SetValidValue(value);
                    //if(!false)
                    //    {
                    //    this.ReportPropertyChanged(vw_GetPhotoList.(6173));
                    //    }
                    }
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
                 //   this.ReportPropertyChanging(vw_GetPhotoList.(6202));
                    this._PS_Photos_RFID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPhotoList.(6202));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
                 //   this.ReportPropertyChanging(vw_GetPhotoList.(6248));
                    this._PS_Photos_Background = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPhotoList.(6248));
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
                 //   this.ReportPropertyChanging(vw_GetPhotoList.(6277));
                    this._PS_Photos_Frame = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPhotoList.(6277));
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
            //    this.ReportPropertyChanging(vw_GetPhotoList.(6298));
                this._PS_Photos_DateTime = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetPhotoList.(6298));
                }
            }

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
            //    this.ReportPropertyChanging(vw_GetPhotoList.(6127));
                this._PS_Photos_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetPhotoList.(6127));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
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
                //    this.ReportPropertyChanging(vw_GetPhotoList.(6323));
                    this._PS_Photos_Layering = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPhotoList.(6323));
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
                 //   this.ReportPropertyChanging(vw_GetPhotoList.(6348));
                    this._PS_Photos_Effects = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPhotoList.(6348));
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
            //    this.ReportPropertyChanging(vw_GetPhotoList.(6373));
                this._PS_Photos_IsCroped = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetPhotoList.(6373));
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
            //    this.ReportPropertyChanging(vw_GetPhotoList.(6398));
                this._PS_Photos_IsRedEye = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetPhotoList.(6398));
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
           //     this.ReportPropertyChanging(vw_GetPhotoList.(6494));
                this._PS_Photos_Archive = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetPhotoList.(6494));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Location_ID
            {
            get
                {
                return this._PS_Location_ID;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetPhotoList.(17074));
                this._PS_Location_ID = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetPhotoList.(17074));
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
           //     this.ReportPropertyChanging(vw_GetPhotoList.(6540));
                this._PS_SubStoreId = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetPhotoList.(6540));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public bool PS_IsCodeType
            {
            get
                {
                return this._PS_IsCodeType;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_IsCodeType == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
            //    this.ReportPropertyChanging(vw_GetPhotoList.(13071));
                this._PS_IsCodeType = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
           //     this.ReportPropertyChanged(vw_GetPhotoList.(13071));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
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
           //     this.ReportPropertyChanging(vw_GetPhotoList.(13092));
                this._DateTaken = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetPhotoList.(13092));
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
         //       this.ReportPropertyChanging(vw_GetPhotoList.(13105));
                this._RfidScanType = StructuralObject.SetValidValue(value);
        //        this.ReportPropertyChanged(vw_GetPhotoList.(13105));
                }
            }

        public static vw_GetPhotoList Createvw_GetPhotoList ( string dG_User_Name, string dG_Photos_FileName, DateTime dG_Photos_CreatedOn, int dG_Photos_pkey, bool dG_IsCodeType )
            {
            vw_GetPhotoList vw_GetPhotoList;
            if(true)
                {
                vw_GetPhotoList = new vw_GetPhotoList();
                do
                    {
                    vw_GetPhotoList.PS_User_Name = dG_User_Name;
                    }
                while(false);
                if(6 == 0)
                    {
                    return vw_GetPhotoList;
                    }
                vw_GetPhotoList.PS_Photos_FileName = dG_Photos_FileName;
                vw_GetPhotoList.PS_Photos_CreatedOn = dG_Photos_CreatedOn;
                }
            vw_GetPhotoList.PS_Photos_pkey = dG_Photos_pkey;
            vw_GetPhotoList.PS_IsCodeType = dG_IsCodeType;
            return vw_GetPhotoList;
            }

        static vw_GetPhotoList ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(vw_GetPhotoList));
            }

        }
    }
