using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetOrderDetails"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetOrderDetails : EntityObject
        {

        private int _PS_Orders_LineItems_pkey;

        private int? _PS_Orders_ID;

        private string _PS_Photos_ID;

        private DateTime? _PS_Orders_LineItems_Created;

        private string _PS_Orders_LineItems_DiscountType;

        private decimal? _PS_Orders_LineItems_DiscountAmount;

        private int _PS_Orders_LineItems_Quantity;

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

        private bool? _PS_IsBorder;

        //[NonSerialized]
        //internal static GetString ;

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
               // this.ReportPropertyChanging(vw_GetOrderDetails.(10944));
                this._PS_Orders_LineItems_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(vw_GetOrderDetails.(10944));
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
              //  this.ReportPropertyChanging(vw_GetOrderDetails.(10977));
                this._PS_Orders_ID = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetOrderDetails.(10977));
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
               //     this.ReportPropertyChanging(vw_GetOrderDetails.(10994));
                    this._PS_Photos_ID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetails.(10994));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
              //  this.ReportPropertyChanging(vw_GetOrderDetails.(11011));
                this._PS_Orders_LineItems_Created = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetOrderDetails.(11011));
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
                //    this.ReportPropertyChanging(vw_GetOrderDetails.(11048));
                    this._PS_Orders_LineItems_DiscountType = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetails.(11048));
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
              //  this.ReportPropertyChanging(vw_GetOrderDetails.(11093));
                this._PS_Orders_LineItems_DiscountAmount = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(vw_GetOrderDetails.(11093));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Orders_LineItems_Quantity
            {
            get
                {
                return this._PS_Orders_LineItems_Quantity;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Orders_LineItems_Quantity == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
            //    this.ReportPropertyChanging(vw_GetOrderDetails.(11142));
                this._PS_Orders_LineItems_Quantity = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetOrderDetails.(11142));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
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
            //    this.ReportPropertyChanging(vw_GetOrderDetails.(11183));
                this._PS_Orders_Details_Items_UniPrice = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetOrderDetails.(11183));
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
            //    this.ReportPropertyChanging(vw_GetOrderDetails.(11228));
                this._PS_Orders_Details_Items_TotalCost = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetOrderDetails.(11228));
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
          //      this.ReportPropertyChanging(vw_GetOrderDetails.(11273));
                this._PS_Orders_Details_Items_NetPrice = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetOrderDetails.(11273));
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
           //     this.ReportPropertyChanging(vw_GetOrderDetails.(11318));
                this._PS_Orders_Details_ProductType_pkey = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetOrderDetails.(11318));
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
           //     this.ReportPropertyChanging(vw_GetOrderDetails.(11367));
                this._PS_Orders_Details_LineItem_ParentID = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetOrderDetails.(11367));
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
           //     this.ReportPropertyChanging(vw_GetOrderDetails.(11416));
                this._PS_Orders_Details_LineItem_PrinterReferenceID = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetOrderDetails.(11416));
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
              //      this.ReportPropertyChanging(vw_GetOrderDetails.(10455));
                    this._PS_Orders_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetails.(10455));
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
           //     this.ReportPropertyChanging(vw_GetOrderDetails.(10480));
                this._PS_Orders_Date = StructuralObject.SetValidValue(value);
        //        this.ReportPropertyChanged(vw_GetOrderDetails.(10480));
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
           //     this.ReportPropertyChanging(vw_GetOrderDetails.(10564));
                this._PS_Orders_Cost = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetOrderDetails.(10564));
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
         //       this.ReportPropertyChanging(vw_GetOrderDetails.(10585));
                this._PS_Orders_NetCost = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetOrderDetails.(10585));
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
           //     this.ReportPropertyChanging(vw_GetOrderDetails.(10610));
                this._PS_Orders_Currency_ID = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetOrderDetails.(10610));
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
             //       this.ReportPropertyChanging(vw_GetOrderDetails.(10639));
                    this._PS_Orders_Currency_Conversion_Rate = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetails.(10639));
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
          //      this.ReportPropertyChanging(vw_GetOrderDetails.(10688));
                this._PS_Orders_Total_Discount = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetOrderDetails.(10688));
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
             //       this.ReportPropertyChanging(vw_GetOrderDetails.(10721));
                    this._PS_Orders_Total_Discount_Details = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetails.(10721));
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
             //       this.ReportPropertyChanging(vw_GetOrderDetails.(10795));
                    this._PS_Orders_PaymentDetails = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetails.(10795));
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
           //     this.ReportPropertyChanging(vw_GetOrderDetails.(10766));
                this._PS_Orders_PaymentMode = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetOrderDetails.(10766));
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
              //      this.ReportPropertyChanging(vw_GetOrderDetails.(12077));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetOrderDetails.(12077));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_IsBorder
            {
            get
                {
                return this._PS_IsBorder;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetOrderDetails.(12465));
                this._PS_IsBorder = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetOrderDetails.(12465));
                }
            }

        public static vw_GetOrderDetails Createvw_GetOrderDetails ( int dG_Orders_LineItems_pkey, int dG_Orders_LineItems_Quantity )
            {
            return new vw_GetOrderDetails
                {
                PS_Orders_LineItems_pkey = dG_Orders_LineItems_pkey,
                PS_Orders_LineItems_Quantity = dG_Orders_LineItems_Quantity
                };
            }

        static vw_GetOrderDetails ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(vw_GetOrderDetails));
            }

        }
    }
