using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetProductTypeData"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetProductTypeData : EntityObject
        {
        private string _PS_Orders_ProductType_Name;

        private string _PS_Orders_ProductType_Desc;

        private bool? _PS_Orders_ProductType_DiscountApplied;

        private bool? _PS_Orders_ProductType_IsBundled;

        private bool _PS_IsPackage;

        private int _PS_MaxQuantity;

        private double? _PS_Product_Pricing_ProductPrice;

        private int? _PS_Product_Pricing_Currency_ID;

        private int _PS_Orders_ProductType_pkey;

        private bool? _PS_IsActive;

        private bool? _PS_IsAccessory;

        private string _PS_Orders_ProductCode;

        private int? _PS_Orders_ProductNumber;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_ProductType_Name
            {
            get
                {
                return this._PS_Orders_ProductType_Name;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(vw_GetProductTypeData.(12226));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetProductTypeData.(12226));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_ProductType_Desc
            {
            get
                {
                return this._PS_Orders_ProductType_Desc;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(vw_GetProductTypeData.(12263));
                    this._PS_Orders_ProductType_Desc = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetProductTypeData.(12263));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Orders_ProductType_DiscountApplied
            {
            get
                {
                return this._PS_Orders_ProductType_DiscountApplied;
                }
            set
                {
              //  this.ReportPropertyChanging(vw_GetProductTypeData.(12345));
                this._PS_Orders_ProductType_DiscountApplied = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(vw_GetProductTypeData.(12345));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Orders_ProductType_IsBundled
            {
            get
                {
                return this._PS_Orders_ProductType_IsBundled;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetProductTypeData.(12300));
                this._PS_Orders_ProductType_IsBundled = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetProductTypeData.(12300));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public bool PS_IsPackage
            {
            get
                {
                return this._PS_IsPackage;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_IsPackage == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
           //     this.ReportPropertyChanging(vw_GetProductTypeData.(12435));
                this._PS_IsPackage = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetProductTypeData.(12435));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_MaxQuantity
            {
            get
                {
                return this._PS_MaxQuantity;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_MaxQuantity == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
            //    this.ReportPropertyChanging(vw_GetProductTypeData.(12452));
                this._PS_MaxQuantity = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
          //      this.ReportPropertyChanged(vw_GetProductTypeData.(12452));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
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
           //     this.ReportPropertyChanging(vw_GetProductTypeData.(13942));
                this._PS_Product_Pricing_ProductPrice = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetProductTypeData.(13942));
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
            //    this.ReportPropertyChanging(vw_GetProductTypeData.(13987));
                this._PS_Product_Pricing_Currency_ID = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetProductTypeData.(13987));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Orders_ProductType_pkey
            {
            get
                {
                return this._PS_Orders_ProductType_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Orders_ProductType_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
           //     this.ReportPropertyChanging(vw_GetProductTypeData.(12189));
                this._PS_Orders_ProductType_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
           //     this.ReportPropertyChanged(vw_GetProductTypeData.(12189));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_IsActive
            {
            get
                {
                return this._PS_IsActive;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetProductTypeData.(8096));
                this._PS_IsActive = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetProductTypeData.(8096));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_IsAccessory
            {
            get
                {
                return this._PS_IsAccessory;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_GetProductTypeData.(12514));
                this._PS_IsAccessory = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetProductTypeData.(12514));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_ProductCode
            {
            get
                {
                return this._PS_Orders_ProductCode;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_GetProductTypeData.(12552));
                    this._PS_Orders_ProductCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetProductTypeData.(12552));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_ProductNumber
            {
            get
                {
                return this._PS_Orders_ProductNumber;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetProductTypeData.(12581));
                this._PS_Orders_ProductNumber = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetProductTypeData.(12581));
                }
            }

        public static vw_GetProductTypeData Createvw_GetProductTypeData ( bool dG_IsPackage, int dG_MaxQuantity, int dG_Orders_ProductType_pkey )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            vw_GetProductTypeData expr_28 = new vw_GetProductTypeData();
            vw_GetProductTypeData vw_GetProductTypeData;
            if(3 != 0)
                {
                vw_GetProductTypeData = expr_28;
                }
            vw_GetProductTypeData.PS_IsPackage = dG_IsPackage;
            IL_0F:
            vw_GetProductTypeData expr_3F = vw_GetProductTypeData;
            if(5 != 0)
                {
                expr_3F.PS_MaxQuantity = dG_MaxQuantity;
                }
            if(!false)
                {
                vw_GetProductTypeData.PS_Orders_ProductType_pkey = dG_Orders_ProductType_pkey;
                }
            IL_23:
            if(5 != 0)
                {
                return vw_GetProductTypeData;
                }
            goto IL_0F;
            }

        static vw_GetProductTypeData ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(vw_GetProductTypeData));
            }


        }
    }
