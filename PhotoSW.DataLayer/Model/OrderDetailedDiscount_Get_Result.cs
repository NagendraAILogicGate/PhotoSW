using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "OrderDetailedDiscount_Get_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class OrderDetailedDiscount_Get_Result : EntityObject
        {
        private DateTime? _PS_Orders_Date;

        private decimal? _PS_Orders_Cost;

        private double? _PS_Orders_Total_Discount;

        private int _PS_Orders_pkey;

        private string _PS_Orders_Number;

        private decimal? _PS_Orders_NetCost;

        private int? _OrderDetailID;

        private string _PS_Orders_ProductType_Name;

        private int? _Quantity;

        private string _Discount;

        private string _Value;

        private bool? _InPercentmode;

        private string _PhotNumber;

        private decimal? _PS_Orders_LineItems_DiscountAmount;

        private decimal? _PS_Orders_Details_Items_UniPrice;

        private decimal? _PS_Orders_Details_Items_TotalCost;

        private decimal? _PS_Orders_Details_Items_NetPrice;

        private string _StoreName;

        private string _UserName;

        private DateTime? _FromDate;

        private DateTime? _ToDate;

        private string _TotalOrderDiscountDetails;

        private double? _ActualValue;

        private decimal? _TotalLineItemDiscount;

        private string _PS_Orders_ProductCode;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Orders_Date
            {
            get
                {
                return this._PS_Orders_Date;
                }
            set
                {
               // this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(10887));
                this._PS_Orders_Date = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(10887));
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
             //   this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(10971));
                this._PS_Orders_Cost = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(10971));
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
             //   this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(11095));
                this._PS_Orders_Total_Discount = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(11095));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Orders_pkey
            {
            get
                {
                return this._PS_Orders_pkey;
                }
            set
                {
            //    this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(10841));
                this._PS_Orders_pkey = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(10841));
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
                //    this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(10862));
                    this._PS_Orders_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(10862));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
              //  this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(10992));
                this._PS_Orders_NetCost = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(10992));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? OrderDetailID
            {
            get
                {
                return this._OrderDetailID;
                }
            set
                {
             //   this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(20105));
                this._OrderDetailID = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(20105));
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
               //     this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(12484));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(12484));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? Quantity
            {
            get
                {
                return this._Quantity;
                }
            set
                {
              //  this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(18081));
                this._Quantity = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(18081));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Discount
            {
            get
                {
                return this._Discount;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(19409));
                    this._Discount = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(19409));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Value
            {
            get
                {
                return this._Value;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(20126));
                    this._Value = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(20126));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? InPercentmode
            {
            get
                {
                return this._InPercentmode;
                }
            set
                {
             //   this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(20135));
                this._InPercentmode = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(20135));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PhotNumber
            {
            get
                {
                return this._PhotNumber;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(20156));
                    this._PhotNumber = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(20156));
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
              //  this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(11500));
                this._PS_Orders_LineItems_DiscountAmount = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(11500));
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
            //    this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(11590));
                this._PS_Orders_Details_Items_UniPrice = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(11590));
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
            //    this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(11635));
                this._PS_Orders_Details_Items_TotalCost = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(11635));
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
           //     this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(11680));
                this._PS_Orders_Details_Items_NetPrice = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(11680));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string StoreName
            {
            get
                {
                return this._StoreName;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(4599));
                    this._StoreName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(4599));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string UserName
            {
            get
                {
                return this._UserName;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(4612));
                    this._UserName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(4612));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? FromDate
            {
            get
                {
                return this._FromDate;
                }
            set
                {
            //    this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(4349));
                this._FromDate = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(4349));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? ToDate
            {
            get
                {
                return this._ToDate;
                }
            set
                {
            //    this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(4362));
                this._ToDate = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(4362));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string TotalOrderDiscountDetails
            {
            get
                {
                return this._TotalOrderDiscountDetails;
                }
            set
                {
                do
                    {
            //        this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(20173));
                    this._TotalOrderDiscountDetails = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(20173));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public double? ActualValue
            {
            get
                {
                return this._ActualValue;
                }
            set
                {
          //      this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(20210));
                this._ActualValue = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(20210));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? TotalLineItemDiscount
            {
            get
                {
                return this._TotalLineItemDiscount;
                }
            set
                {
           //     this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(20227));
                this._TotalLineItemDiscount = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(20227));
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
               //     this.ReportPropertyChanging(OrderDetailedDiscount_Get_Result.(12810));
                    this._PS_Orders_ProductCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OrderDetailedDiscount_Get_Result.(12810));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static OrderDetailedDiscount_Get_Result CreateOrderDetailedDiscount_Get_Result ( int dG_Orders_pkey )
            {
            return new OrderDetailedDiscount_Get_Result
                {
                PS_Orders_pkey = dG_Orders_pkey
                };
            }

        static OrderDetailedDiscount_Get_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            //Strings.CreateGetStringDelegate(typeof(OrderDetailedDiscount_Get_Result));
            }


        }
    }
