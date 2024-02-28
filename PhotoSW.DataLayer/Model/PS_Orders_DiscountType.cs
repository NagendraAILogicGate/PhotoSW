using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_Orders_DiscountType"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Orders_DiscountType : EntityObject
        {
        private int _PS_Orders_DiscountType_Pkey;

        private string _PS_Orders_DiscountType_Name;

        private string _PS_Orders_DiscountType_Desc;

        private bool? _PS_Orders_DiscountType_Active;

        private bool? _PS_Orders_DiscountType_Secure;

        private bool? _PS_Orders_DiscountType_ItemLevel;

        private bool? _PS_Orders_DiscountType_AsPercentage;

        private string _PS_Orders_DiscountType_Code;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Orders_DiscountType_Pkey
            {
            get
                {
                return this._PS_Orders_DiscountType_Pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Orders_DiscountType_Pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_Orders_DiscountType.(11176));
                this._PS_Orders_DiscountType_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_Orders_DiscountType.(11176));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_DiscountType_Name
            {
            get
                {
                return this._PS_Orders_DiscountType_Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Orders_DiscountType.(11213));
                    this._PS_Orders_DiscountType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_DiscountType.(11213));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_DiscountType_Desc
            {
            get
                {
                return this._PS_Orders_DiscountType_Desc;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Orders_DiscountType.(11250));
                    this._PS_Orders_DiscountType_Desc = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_DiscountType.(11250));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Orders_DiscountType_Active
            {
            get
                {
                return this._PS_Orders_DiscountType_Active;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Orders_DiscountType.(11287));
                this._PS_Orders_DiscountType_Active = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_DiscountType.(11287));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Orders_DiscountType_Secure
            {
            get
                {
                return this._PS_Orders_DiscountType_Secure;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Orders_DiscountType.(11328));
                this._PS_Orders_DiscountType_Secure = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(DG_Orders_DiscountType.(11328));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Orders_DiscountType_ItemLevel
            {
            get
                {
                return this._PS_Orders_DiscountType_ItemLevel;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Orders_DiscountType.(11369));
                this._PS_Orders_DiscountType_ItemLevel = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_DiscountType.(11369));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Orders_DiscountType_AsPercentage
            {
            get
                {
                return this._PS_Orders_DiscountType_AsPercentage;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Orders_DiscountType.(11414));
                this._PS_Orders_DiscountType_AsPercentage = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_DiscountType.(11414));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_DiscountType_Code
            {
            get
                {
                return this._PS_Orders_DiscountType_Code;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Orders_DiscountType.(11463));
                    this._PS_Orders_DiscountType_Code = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_DiscountType.(11463));
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
                  //  this.ReportPropertyChanging(DG_Orders_DiscountType.(6595));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_DiscountType.(6595));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
             //   this.ReportPropertyChanging(DG_Orders_DiscountType.(6608));
                this._IsSynced = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(DG_Orders_DiscountType.(6608));
                }
            }

        public static PS_Orders_DiscountType CreateDG_Orders_DiscountType ( int dG_Orders_DiscountType_Pkey, bool isSynced )
            {
            return new PS_Orders_DiscountType
                {
                PS_Orders_DiscountType_Pkey = dG_Orders_DiscountType_Pkey,
                IsSynced = isSynced
                };
            }

        static PS_Orders_DiscountType ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Orders_DiscountType));
            }


        }
    }
