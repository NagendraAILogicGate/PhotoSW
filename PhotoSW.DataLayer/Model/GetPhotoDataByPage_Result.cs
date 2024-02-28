using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GetPhotoDataByPage_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GetPhotoDataByPage_Result : ComplexObject
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

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Photos_pkey
            {
            get
                {
                return this._PS_Photos_pkey;
                }
            set
                {
              //  this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6377));
                this._PS_Photos_pkey = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6377));
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
                //    this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6398));
                    this._PS_Photos_FileName = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6398));
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
           //     this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6423));
                this._PS_Photos_CreatedOn = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6423));
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
                 //   this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6452));
                    this._PS_Photos_RFID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6452));
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
           //     this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6473));
                this._PS_Photos_UserID = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6473));
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
             //       this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6498));
                    this._PS_Photos_Background = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6498));
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
                //    this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6527));
                    this._PS_Photos_Frame = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6527));
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
           //     this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6548));
                this._PS_Photos_DateTime = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6548));
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
             //       this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6573));
                    this._PS_Photos_Layering = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6573));
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
                //    this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6598));
                    this._PS_Photos_Effects = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6598));
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
            //    this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6623));
                this._PS_Photos_IsCroped = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6623));
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
             //   this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6648));
                this._PS_Photos_IsRedEye = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6648));
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
            //    this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6673));
                this._PS_Photos_IsGreen = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6673));
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
             //       this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6698));
                    this._PS_Photos_MetaData = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6698));
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
             //       this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6723));
                    this._PS_Photos_Sizes = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6723));
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
           //     this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6744));
                this._PS_Photos_Archive = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6744));
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
           //     this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6769));
                this._PS_Location_Id = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6769));
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
          //      this.ReportPropertyChanging(GetPhotoDataByPage_Result.(6790));
                this._PS_SubStoreId = StructuralObject.SetValidValue(value);
          //     this.ReportPropertyChanged(GetPhotoDataByPage_Result.(6790));
                }
            }

        public static GetPhotoDataByPage_Result CreateGetPhotoDataByPage_Result ( int dG_Photos_pkey, string dG_Photos_FileName, DateTime dG_Photos_CreatedOn )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            GetPhotoDataByPage_Result expr_28 = new GetPhotoDataByPage_Result();
            GetPhotoDataByPage_Result getPhotoDataByPage_Result;
            if(3 != 0)
                {
                getPhotoDataByPage_Result = expr_28;
                }
            getPhotoDataByPage_Result.PS_Photos_pkey = dG_Photos_pkey;
            IL_0F:
            GetPhotoDataByPage_Result expr_3F = getPhotoDataByPage_Result;
            if(5 != 0)
                {
                expr_3F.PS_Photos_FileName = dG_Photos_FileName;
                }
            if(!false)
                {
                getPhotoDataByPage_Result.PS_Photos_CreatedOn = dG_Photos_CreatedOn;
                }
            IL_23:
            if(5 != 0)
                {
                return getPhotoDataByPage_Result;
                }
            goto IL_0F;
            }

        static GetPhotoDataByPage_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(GetPhotoDataByPage_Result));
            }

        }
    }
