using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "ProductSummary_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class ProductSummary_Result : ComplexObject
        {
        private string _ProductName;

        private int? _TotalQuantity;

        private decimal? _UnitPrice;

        private decimal? _TotalCost;

        private decimal? _Discount;

        private decimal? _NetPrice;

        private decimal? _TotalRevenue;

        private decimal? _Revpercentage;

        private DateTime? _FROMDate;

        private DateTime? _Todate;

        private string _UserName;

        private string _StoreName;

        private int _Flag;

        private string _DG_SubStore_Name;

        private string _DG_Orders_ProductCode;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ProductName
            {
            get
                {
                return this._ProductName;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(ProductSummary_Result.(20300));
                    this._ProductName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(ProductSummary_Result.(20300));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
             //   this.ReportPropertyChanging(ProductSummary_Result.(19153));
                this._TotalQuantity = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(ProductSummary_Result.(19153));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? UnitPrice
            {
            get
                {
                return this._UnitPrice;
                }
            set
                {
              //  this.ReportPropertyChanging(ProductSummary_Result.(20317));
                this._UnitPrice = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(ProductSummary_Result.(20317));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? TotalCost
            {
            get
                {
                return this._TotalCost;
                }
            set
                {
            //    this.ReportPropertyChanging(ProductSummary_Result.(20330));
                this._TotalCost = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(ProductSummary_Result.(20330));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? Discount
            {
            get
                {
                return this._Discount;
                }
            set
                {
          //      this.ReportPropertyChanging(ProductSummary_Result.(19436));
                this._Discount = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(ProductSummary_Result.(19436));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? NetPrice
            {
            get
                {
                return this._NetPrice;
                }
            set
                {
           //     this.ReportPropertyChanging(ProductSummary_Result.(20343));
                this._NetPrice = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(ProductSummary_Result.(20343));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? TotalRevenue
            {
            get
                {
                return this._TotalRevenue;
                }
            set
                {
          //      this.ReportPropertyChanging(ProductSummary_Result.(20356));
                this._TotalRevenue = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(ProductSummary_Result.(20356));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? Revpercentage
            {
            get
                {
                return this._Revpercentage;
                }
            set
                {
             //   this.ReportPropertyChanging(ProductSummary_Result.(20373));
                this._Revpercentage = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(ProductSummary_Result.(20373));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? FROMDate
            {
            get
                {
                return this._FROMDate;
                }
            set
                {
             //   this.ReportPropertyChanging(ProductSummary_Result.(5114));
                this._FROMDate = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(ProductSummary_Result.(5114));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? Todate
            {
            get
                {
                return this._Todate;
                }
            set
                {
           //     this.ReportPropertyChanging(ProductSummary_Result.(19310));
                this._Todate = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(ProductSummary_Result.(19310));
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
             //       this.ReportPropertyChanging(ProductSummary_Result.(4639));
                    this._UserName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(ProductSummary_Result.(4639));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
               //     this.ReportPropertyChanging(ProductSummary_Result.(4626));
                    this._StoreName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(ProductSummary_Result.(4626));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int Flag
            {
            get
                {
                return this._Flag;
                }
            set
                {
             //   this.ReportPropertyChanging(ProductSummary_Result.(20394));
                this._Flag = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(ProductSummary_Result.(20394));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string DG_SubStore_Name
            {
            get
                {
                return this._DG_SubStore_Name;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(ProductSummary_Result.(17482));
                    this._DG_SubStore_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(ProductSummary_Result.(17482));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string DG_Orders_ProductCode
            {
            get
                {
                return this._DG_Orders_ProductCode;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(ProductSummary_Result.(12837));
                    this._DG_Orders_ProductCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(ProductSummary_Result.(12837));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static ProductSummary_Result CreateProductSummary_Result ( int flag )
            {
            return new ProductSummary_Result
                {
                Flag = flag
                };
            }

        static ProductSummary_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(ProductSummary_Result));
            }


        }
    }
