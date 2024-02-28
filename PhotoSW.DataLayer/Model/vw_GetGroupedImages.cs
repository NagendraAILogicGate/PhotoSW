using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetGroupedImages"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetGroupedImages : EntityObject
        {
        private string _PS_Group_Name;

        private long _PS_Group_pkey;

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

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_Group_Name
            {
            get
                {
                return this._PS_Group_Name;
                }
            set
                {
                if(!(this._PS_Group_Name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
             //   this.ReportPropertyChanging(vw_GetGroupedImages.(12797));
                IL_1D:
                this._PS_Group_Name = StructuralObject.SetValidValue(value, false);
             //   this.ReportPropertyChanged(vw_GetGroupedImages.(12797));
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
        public long PS_Group_pkey
            {
            get
                {
                return this._PS_Group_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Group_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
            //    this.ReportPropertyChanging(vw_GetGroupedImages.(12776));
                this._PS_Group_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetGroupedImages.(12776));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
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
           //     this.ReportPropertyChanging(vw_GetGroupedImages.(6025));
                this._PS_Photos_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
          //      this.ReportPropertyChanged(vw_GetGroupedImages.(6025));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
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
            //    this.ReportPropertyChanging(vw_GetGroupedImages.(6046));
                IL_1D:
                this._PS_Photos_FileName = StructuralObject.SetValidValue(value, false);
           //     this.ReportPropertyChanged(vw_GetGroupedImages.(6046));
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
                //    string expr_54 = vw_GetGroupedImages.(6071);
                    //if(3 != 0)
                    //    {
                    //    this.ReportPropertyChanging(expr_54);
                    //    }
                    this._PS_Photos_CreatedOn = StructuralObject.SetValidValue(value);
                    //if(!false)
                    //    {
                    //    this.ReportPropertyChanged(vw_GetGroupedImages.(6071));
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
                 //   this.ReportPropertyChanging(vw_GetGroupedImages.(6100));
                    this._PS_Photos_RFID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetGroupedImages.(6100));
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
            //    this.ReportPropertyChanging(vw_GetGroupedImages.(6121));
                this._PS_Photos_UserID = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetGroupedImages.(6121));
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
               //     this.ReportPropertyChanging(vw_GetGroupedImages.(6146));
                    this._PS_Photos_Background = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetGroupedImages.(6146));
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
                //    this.ReportPropertyChanging(vw_GetGroupedImages.(6175));
                    this._PS_Photos_Frame = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetGroupedImages.(6175));
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
           //     this.ReportPropertyChanging(vw_GetGroupedImages.(6196));
                this._PS_Photos_DateTime = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetGroupedImages.(6196));
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
               //     this.ReportPropertyChanging(vw_GetGroupedImages.(6221));
                    this._PS_Photos_Layering = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetGroupedImages.(6221));
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
             //       this.ReportPropertyChanging(vw_GetGroupedImages.(6246));
                    this._PS_Photos_Effects = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetGroupedImages.(6246));
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
            //    this.ReportPropertyChanging(vw_GetGroupedImages.(6271));
                this._PS_Photos_IsCroped = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetGroupedImages.(6271));
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
           //     this.ReportPropertyChanging(vw_GetGroupedImages.(6296));
                this._PS_Photos_IsRedEye = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetGroupedImages.(6296));
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
          //      this.ReportPropertyChanging(vw_GetGroupedImages.(6321));
                this._PS_Photos_IsGreen = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetGroupedImages.(6321));
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
               //     this.ReportPropertyChanging(vw_GetGroupedImages.(6346));
                    this._PS_Photos_MetaData = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetGroupedImages.(6346));
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
                //    this.ReportPropertyChanging(vw_GetGroupedImages.(6371));
                    this._PS_Photos_Sizes = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetGroupedImages.(6371));
                    //        }
                    //    }
                    //while(false);
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
            //    this.ReportPropertyChanging(vw_GetGroupedImages.(6392));
                this._PS_Photos_Archive = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetGroupedImages.(6392));
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
           //     this.ReportPropertyChanging(vw_GetGroupedImages.(6417));
                this._PS_Location_Id = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetGroupedImages.(6417));
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
          //      this.ReportPropertyChanging(vw_GetGroupedImages.(6438));
                this._PS_SubStoreId = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetGroupedImages.(6438));
                }
            }

        public static vw_GetGroupedImages Createvw_GetGroupedImages ( string dG_Group_Name, long dG_Group_pkey, int dG_Photos_pkey, string dG_Photos_FileName, DateTime dG_Photos_CreatedOn )
            {
            vw_GetGroupedImages vw_GetGroupedImages;
            if(true)
                {
                vw_GetGroupedImages = new vw_GetGroupedImages();
                do
                    {
                    vw_GetGroupedImages.PS_Group_Name = dG_Group_Name;
                    }
                while(false);
                if(6 == 0)
                    {
                    return vw_GetGroupedImages;
                    }
                vw_GetGroupedImages.PS_Group_pkey = dG_Group_pkey;
                vw_GetGroupedImages.PS_Photos_pkey = dG_Photos_pkey;
                }
            vw_GetGroupedImages.PS_Photos_FileName = dG_Photos_FileName;
            vw_GetGroupedImages.PS_Photos_CreatedOn = dG_Photos_CreatedOn;
            return vw_GetGroupedImages;
            }

        static vw_GetGroupedImages ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(vw_GetGroupedImages));
            }

        }
    }
