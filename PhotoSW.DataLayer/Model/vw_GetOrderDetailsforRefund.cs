using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetOrderDetailsforRefund"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetOrderDetailsforRefund : EntityObject
        {

        private int _PS_Orders_LineItems_pkey;

        private int? _PS_Orders_ID;

        private string _PS_Photos_ID;

        private int? _PS_Orders_LineItems_Quantity;

        private int? _TotalQuantity;

        private DateTime? _PS_Orders_LineItems_Created;

        private string _PS_Orders_LineItems_DiscountType;

        private decimal? _PS_Orders_LineItems_DiscountAmount;

        private decimal? _PS_Orders_Details_Items_UniPrice;

        private decimal? _PS_Orders_Details_Items_TotalCost;

        private decimal? _PS_Orders_Details_Items_NetPrice;

        private int? _PS_Orders_Details_ProductType_pkey;

        private int? _PS_Orders_Details_LineItem_ParentID;

        private int? _PS_Orders_Details_LineItem_PrinterReferenceID;

        private string _PS_Orders_Number;

        private DateTime? _PS_Orders_Date;

        private decimal? _PS_Orders_Cost;

        private decimal? _PS_Orders_NetCost;

        private int? _PS_Orders_Currency_ID;

        private string _PS_Orders_Currency_Conversion_Rate;

        private double? _PS_Orders_Total_Discount;

        private string _PS_Orders_Total_Discount_Details;

        private string _PS_Orders_PaymentDetails;

        private int? _PS_Orders_PaymentMode;

        private string _PS_Orders_ProductType_Name;

        private bool? _PS_Orders_ProductType_IsBundled;

        private bool _PS_IsPackage;

        private decimal? _LineItemshare;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Orders_LineItems_pkey
            {
            get
                {
                return this._PS_Orders_LineItems_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Orders_LineItems_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(10973));
                this._PS_Orders_LineItems_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(10973));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_ID
            {
            get
                {
                return this._PS_Orders_ID;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(11006));
                this._PS_Orders_ID = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(11006));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_ID
            {
            get
                {
                return this._PS_Photos_ID;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(11023));
                    this._PS_Photos_ID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(11023));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_LineItems_Quantity
            {
            get
                {
                return this._PS_Orders_LineItems_Quantity;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(11171));
                this._PS_Orders_LineItems_Quantity = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(11171));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? TotalQuantity
            {
            get
                {
                return this._TotalQuantity;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(18748));
                this._TotalQuantity = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(18748));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Orders_LineItems_Created
            {
            get
                {
                return this._PS_Orders_LineItems_Created;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(11040));
                this._PS_Orders_LineItems_Created = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(11040));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_LineItems_DiscountType
            {
            get
                {
                return this._PS_Orders_LineItems_DiscountType;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(11077));
                    this._PS_Orders_LineItems_DiscountType = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(11077));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_Orders_LineItems_DiscountAmount
            {
            get
                {
                return this._PS_Orders_LineItems_DiscountAmount;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(11122));
                this._PS_Orders_LineItems_DiscountAmount = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(11122));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_Orders_Details_Items_UniPrice
            {
            get
                {
                return this._PS_Orders_Details_Items_UniPrice;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(11212));
                this._PS_Orders_Details_Items_UniPrice = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(11212));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_Orders_Details_Items_TotalCost
            {
            get
                {
                return this._PS_Orders_Details_Items_TotalCost;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(11257));
                this._PS_Orders_Details_Items_TotalCost = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(11257));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_Orders_Details_Items_NetPrice
            {
            get
                {
                return this._PS_Orders_Details_Items_NetPrice;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(11302));
                this._PS_Orders_Details_Items_NetPrice = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(11302));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_Details_ProductType_pkey
            {
            get
                {
                return this._PS_Orders_Details_ProductType_pkey;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(11347));
                this._PS_Orders_Details_ProductType_pkey = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(11347));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_Details_LineItem_ParentID
            {
            get
                {
                return this._PS_Orders_Details_LineItem_ParentID;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(11396));
                this._PS_Orders_Details_LineItem_ParentID = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(11396));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_Details_LineItem_PrinterReferenceID
            {
            get
                {
                return this._PS_Orders_Details_LineItem_PrinterReferenceID;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(11445));
                this._PS_Orders_Details_LineItem_PrinterReferenceID = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(11445));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_Number
            {
            get
                {
                return this._PS_Orders_Number;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(10484));
                    this._PS_Orders_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(10484));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Orders_Date
            {
            get
                {
                return this._PS_Orders_Date;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(10509));
                this._PS_Orders_Date = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(10509));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_Orders_Cost
            {
            get
                {
                return this._PS_Orders_Cost;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(10593));
                this._PS_Orders_Cost = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(10593));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_Orders_NetCost
            {
            get
                {
                return this._PS_Orders_NetCost;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(10614));
                this._PS_Orders_NetCost = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(10614));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_Currency_ID
            {
            get
                {
                return this._PS_Orders_Currency_ID;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(10639));
                this._PS_Orders_Currency_ID = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(10639));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_Currency_Conversion_Rate
            {
            get
                {
                return this._PS_Orders_Currency_Conversion_Rate;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(10668));
                    this._PS_Orders_Currency_Conversion_Rate = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(10668));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public double? PS_Orders_Total_Discount
            {
            get
                {
                return this._PS_Orders_Total_Discount;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(10717));
                this._PS_Orders_Total_Discount = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(10717));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_Total_Discount_Details
            {
            get
                {
                return this._PS_Orders_Total_Discount_Details;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(10750));
                    this._PS_Orders_Total_Discount_Details = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(10750));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_PaymentDetails
            {
            get
                {
                return this._PS_Orders_PaymentDetails;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(10824));
                    this._PS_Orders_PaymentDetails = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(10824));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_PaymentMode
            {
            get
                {
                return this._PS_Orders_PaymentMode;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(10795));
                this._PS_Orders_PaymentMode = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(10795));
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
              //      this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(12106));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(12106));
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
           //     this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(12180));
                this._PS_Orders_ProductType_IsBundled = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(12180));
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
          //      this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(12315));
                this._PS_IsPackage = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
         //       this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(12315));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? LineItemshare
            {
            get
                {
                return this._LineItemshare;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_GetOrderDetailsforRefund.(18769));
                this._LineItemshare = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetOrderDetailsforRefund.(18769));
                }
            }

        public static vw_GetOrderDetailsforRefund Createvw_GetOrderDetailsforRefund ( int dG_Orders_LineItems_pkey, bool dG_IsPackage )
            {
            return new vw_GetOrderDetailsforRefund
                {
                PS_Orders_LineItems_pkey = dG_Orders_LineItems_pkey,
                PS_IsPackage = dG_IsPackage
                };
            }

        static vw_GetOrderDetailsforRefund ()
            {
            // Note: this type is marked as 'beforefieldinit'.
        //    Strings.CreateGetStringDelegate(typeof(vw_GetOrderDetailsforRefund));
            }
        }
    }
