using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_Product_Pricing"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Product_Pricing : EntityObject
        {
        private int _PS_Product_Pricing_Pkey;

        private int? _PS_Product_Pricing_ProductType;

        private double? _PS_Product_Pricing_ProductPrice;

        private int? _PS_Product_Pricing_Currency_ID;

        private DateTime? _PS_Product_Pricing_UpdateDate;

        private int? _PS_Product_Pricing_CreatedBy;

        private int? _PS_Product_Pricing_StoreId;

        private bool? _PS_Product_Pricing_IsAvaliable;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Product_Pricing_Pkey
            {
            get
                {
                return this._PS_Product_Pricing_Pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Product_Pricing_Pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(DG_Product_Pricing.(13293));
                this._PS_Product_Pricing_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_Product_Pricing.(13293));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Product_Pricing_ProductType
            {
            get
                {
                return this._PS_Product_Pricing_ProductType;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Product_Pricing.(13326));
                this._PS_Product_Pricing_ProductType = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Product_Pricing.(13326));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public double? PS_Product_Pricing_ProductPrice
            {
            get
                {
                return this._PS_Product_Pricing_ProductPrice;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Product_Pricing.(13367));
                this._PS_Product_Pricing_ProductPrice = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Product_Pricing.(13367));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Product_Pricing_Currency_ID
            {
            get
                {
                return this._PS_Product_Pricing_Currency_ID;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Product_Pricing.(13412));
                this._PS_Product_Pricing_Currency_ID = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Product_Pricing.(13412));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Product_Pricing_UpdateDate
            {
            get
                {
                return this._PS_Product_Pricing_UpdateDate;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Product_Pricing.(13453));
                this._PS_Product_Pricing_UpdateDate = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Product_Pricing.(13453));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Product_Pricing_CreatedBy
            {
            get
                {
                return this._PS_Product_Pricing_CreatedBy;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Product_Pricing.(13494));
                this._PS_Product_Pricing_CreatedBy = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Product_Pricing.(13494));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Product_Pricing_StoreId
            {
            get
                {
                return this._PS_Product_Pricing_StoreId;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Product_Pricing.(13535));
                this._PS_Product_Pricing_StoreId = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(DG_Product_Pricing.(13535));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Product_Pricing_IsAvaliable
            {
            get
                {
                return this._PS_Product_Pricing_IsAvaliable;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Product_Pricing.(13572));
                this._PS_Product_Pricing_IsAvaliable = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Product_Pricing.(13572));
                }
            }

        public static PS_Product_Pricing CreateDG_Product_Pricing ( int dG_Product_Pricing_Pkey )
            {
            return new PS_Product_Pricing
                {
                PS_Product_Pricing_Pkey = dG_Product_Pricing_Pkey
                };
            }

        static PS_Product_Pricing ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(DG_Product_Pricing));
            }


        }
    }
