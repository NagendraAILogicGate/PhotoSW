using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetProductNameforOrder"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetProductNameforOrder : EntityObject
        {
        private int _PS_Orders_ProductType_pkey;

        private string _PS_Orders_ProductType_Name;

        private string _PS_Orders_ProductType_Desc;

        private bool? _PS_Orders_ProductType_IsBundled;

        private bool? _PS_Orders_ProductType_DiscountApplied;

        private string _PS_Orders_ProductType_Image;

        private bool _PS_IsPackage;

        private int _PS_MaxQuantity;

        private bool? _PS_Orders_ProductType_Active;

        private bool? _PS_IsActive;

        private bool? _PS_IsAccessory;

        private int? _Itemcount;

        private int? _PS_Orders_ProductNumber;

        //[NonSerialized]
        //internal static GetString ;

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
             //   this.ReportPropertyChanging(vw_GetProductNameforOrder.(12175));
                this._PS_Orders_ProductType_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
           //     this.ReportPropertyChanged(vw_GetProductNameforOrder.(12175));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

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
                //    this.ReportPropertyChanging(vw_GetProductNameforOrder.(12212));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetProductNameforOrder.(12212));
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
               //     this.ReportPropertyChanging(vw_GetProductNameforOrder.(12249));
                    this._PS_Orders_ProductType_Desc = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetProductNameforOrder.(12249));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
            //    this.ReportPropertyChanging(vw_GetProductNameforOrder.(12286));
                this._PS_Orders_ProductType_IsBundled = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetProductNameforOrder.(12286));
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
           //     this.ReportPropertyChanging(vw_GetProductNameforOrder.(12331));
                this._PS_Orders_ProductType_DiscountApplied = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetProductNameforOrder.(12331));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_ProductType_Image
            {
            get
                {
                return this._PS_Orders_ProductType_Image;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_GetProductNameforOrder.(12384));
                    this._PS_Orders_ProductType_Image = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetProductNameforOrder.(12384));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
           //     this.ReportPropertyChanging(vw_GetProductNameforOrder.(12421));
                this._PS_IsPackage = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
          //      this.ReportPropertyChanged(vw_GetProductNameforOrder.(12421));
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
           //     this.ReportPropertyChanging(vw_GetProductNameforOrder.(12438));
                this._PS_MaxQuantity = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
          //      this.ReportPropertyChanged(vw_GetProductNameforOrder.(12438));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Orders_ProductType_Active
            {
            get
                {
                return this._PS_Orders_ProductType_Active;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_GetProductNameforOrder.(12459));
                this._PS_Orders_ProductType_Active = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetProductNameforOrder.(12459));
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
         //       this.ReportPropertyChanging(vw_GetProductNameforOrder.(8082));
                this._PS_IsActive = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetProductNameforOrder.(8082));
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
          //      this.ReportPropertyChanging(vw_GetProductNameforOrder.(12500));
                this._PS_IsAccessory = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetProductNameforOrder.(12500));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? Itemcount
            {
            get
                {
                return this._Itemcount;
                }
            set
                {
        //        this.ReportPropertyChanging(vw_GetProductNameforOrder.(18939));
                this._Itemcount = StructuralObject.SetValidValue(value);
       //         this.ReportPropertyChanged(vw_GetProductNameforOrder.(18939));
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
        //        this.ReportPropertyChanging(vw_GetProductNameforOrder.(12567));
                this._PS_Orders_ProductNumber = StructuralObject.SetValidValue(value);
       //         this.ReportPropertyChanged(vw_GetProductNameforOrder.(12567));
                }
            }

        public static vw_GetProductNameforOrder Createvw_GetProductNameforOrder ( int dG_Orders_ProductType_pkey, bool dG_IsPackage, int dG_MaxQuantity )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            vw_GetProductNameforOrder expr_28 = new vw_GetProductNameforOrder();
            vw_GetProductNameforOrder vw_GetProductNameforOrder;
            if(3 != 0)
                {
                vw_GetProductNameforOrder = expr_28;
                }
            vw_GetProductNameforOrder.PS_Orders_ProductType_pkey = dG_Orders_ProductType_pkey;
            IL_0F:
            vw_GetProductNameforOrder expr_3F = vw_GetProductNameforOrder;
            if(5 != 0)
                {
                expr_3F.PS_IsPackage = dG_IsPackage;
                }
            if(!false)
                {
                vw_GetProductNameforOrder.PS_MaxQuantity = dG_MaxQuantity;
                }
            IL_23:
            if(5 != 0)
                {
                return vw_GetProductNameforOrder;
                }
            goto IL_0F;
            }

        static vw_GetProductNameforOrder ()
            {
            // Note: this type is marked as 'beforefieldinit'.
        //    Strings.CreateGetStringDelegate(typeof(vw_GetProductNameforOrder));
            }

        }
    }
