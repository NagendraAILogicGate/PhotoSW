using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GetImagesBYQRCode_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GetImagesBYQRCode_Result : ComplexObject
        {
        private long _IMIXImageAssociationId;

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
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public long IMIXImageAssociationId
            {
            get
                {
                return this._IMIXImageAssociationId;
                }
            set
                {
               // this.ReportPropertyChanging(GetImagesBYQRCode_Result.(18401));
                this._IMIXImageAssociationId = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(GetImagesBYQRCode_Result.(18401));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Photos_pkey
            {
            get
                {
                return this._PS_Photos_pkey;
                }
            set
                {
             //   this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6315));
                this._PS_Photos_pkey = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6315));
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
                   // this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6336));
                    this._PS_Photos_FileName = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6336));
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
              //  this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6361));
                this._PS_Photos_CreatedOn = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6361));
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
                  //  this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6390));
                    this._PS_Photos_RFID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6390));
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
               // this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6411));
                this._PS_Photos_UserID = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6411));
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
                 //   this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6436));
                    this._PS_Photos_Background = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6436));
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
                 //   this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6465));
                    this._PS_Photos_Frame = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6465));
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
               // this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6486));
                this._PS_Photos_DateTime = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6486));
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
                  //  this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6511));
                    this._PS_Photos_Layering = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6511));
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
                  //  this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6536));
                    this._PS_Photos_Effects = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6536));
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
              //  this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6561));
                this._PS_Photos_IsCroped = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6561));
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
           //     this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6586));
                this._PS_Photos_IsRedEye = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6586));
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
              //  this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6611));
                this._PS_Photos_IsGreen = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6611));
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
                   // this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6636));
                    this._PS_Photos_MetaData = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6636));
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
                  //  this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6661));
                    this._PS_Photos_Sizes = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6661));
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
               // this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6682));
                this._PS_Photos_Archive = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6682));
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
               // this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6707));
                this._PS_Location_Id = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6707));
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
             //   this.ReportPropertyChanging(GetImagesBYQRCode_Result.(6728));
                this._PS_SubStoreId = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetImagesBYQRCode_Result.(6728));
                }
            }

        public static GetImagesBYQRCode_Result CreateGetImagesBYQRCode_Result ( long iMIXImageAssociationId, int dG_Photos_pkey, string dG_Photos_FileName, DateTime dG_Photos_CreatedOn )
            {
            GetImagesBYQRCode_Result getImagesBYQRCode_Result;
            while(true)
                {
                getImagesBYQRCode_Result = new GetImagesBYQRCode_Result();
                if(5 != 0 && 8 != 0)
                    {
                    getImagesBYQRCode_Result.IMIXImageAssociationId = iMIXImageAssociationId;
                    getImagesBYQRCode_Result.PS_Photos_pkey = dG_Photos_pkey;
                    if(3 == 0)
                        {
                        return getImagesBYQRCode_Result;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            getImagesBYQRCode_Result.PS_Photos_FileName = dG_Photos_FileName;
            getImagesBYQRCode_Result.PS_Photos_CreatedOn = dG_Photos_CreatedOn;
            return getImagesBYQRCode_Result;
            }

        static GetImagesBYQRCode_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(GetImagesBYQRCode_Result));
            }

        }
    }
