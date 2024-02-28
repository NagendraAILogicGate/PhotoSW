using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "OperatorPerformanceReport_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class OperatorPerformanceReport_Result : EntityObject
        {
        private string _CurrencySymbol;

        private string _StoreName;

        private string _UserName;

        private DateTime? _FromDate;

        private DateTime? _ToDate;

        private int _Data1;

        private decimal? _Revenue;

        private long? _TotalSale;

        private long? _Images_Sold;

        private int? _Capture;

        private int? _Shots_Previewed;

        private int? _TotalBurned;

        private string _OperatorName;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string CurrencySymbol
            {
            get
                {
                return this._CurrencySymbol;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(OperatorPerformanceReport_Result.(19972));
                    this._CurrencySymbol = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OperatorPerformanceReport_Result.(19972));
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
                  //  this.ReportPropertyChanging(OperatorPerformanceReport_Result.(4573));
                    this._StoreName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OperatorPerformanceReport_Result.(4573));
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
                  //  this.ReportPropertyChanging(OperatorPerformanceReport_Result.(4586));
                    this._UserName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OperatorPerformanceReport_Result.(4586));
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
              //  this.ReportPropertyChanging(OperatorPerformanceReport_Result.(4323));
                this._FromDate = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(OperatorPerformanceReport_Result.(4323));
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
             //   this.ReportPropertyChanging(OperatorPerformanceReport_Result.(4336));
                this._ToDate = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(OperatorPerformanceReport_Result.(4336));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int Data1
            {
            get
                {
                return this._Data1;
                }
            set
                {
             //   this.ReportPropertyChanging(OperatorPerformanceReport_Result.(19993));
                this._Data1 = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(OperatorPerformanceReport_Result.(19993));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? Revenue
            {
            get
                {
                return this._Revenue;
                }
            set
                {
             //   this.ReportPropertyChanging(OperatorPerformanceReport_Result.(19563));
                this._Revenue = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(OperatorPerformanceReport_Result.(19563));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public long? TotalSale
            {
            get
                {
                return this._TotalSale;
                }
            set
                {
            //    this.ReportPropertyChanging(OperatorPerformanceReport_Result.(20002));
                this._TotalSale = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(OperatorPerformanceReport_Result.(20002));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public long? Images_Sold
            {
            get
                {
                return this._Images_Sold;
                }
            set
                {
            //    this.ReportPropertyChanging(OperatorPerformanceReport_Result.(20015));
                this._Images_Sold = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(OperatorPerformanceReport_Result.(20015));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? Capture
            {
            get
                {
                return this._Capture;
                }
            set
                {
          //      this.ReportPropertyChanging(OperatorPerformanceReport_Result.(20032));
                this._Capture = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(OperatorPerformanceReport_Result.(20032));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? Shots_Previewed
            {
            get
                {
                return this._Shots_Previewed;
                }
            set
                {
            //    this.ReportPropertyChanging(OperatorPerformanceReport_Result.(19576));
                this._Shots_Previewed = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(OperatorPerformanceReport_Result.(19576));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? TotalBurned
            {
            get
                {
                return this._TotalBurned;
                }
            set
                {
          //      this.ReportPropertyChanging(OperatorPerformanceReport_Result.(20045));
                this._TotalBurned = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(OperatorPerformanceReport_Result.(20045));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string OperatorName
            {
            get
                {
                return this._OperatorName;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(OperatorPerformanceReport_Result.(20062));
                    this._OperatorName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OperatorPerformanceReport_Result.(20062));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static OperatorPerformanceReport_Result CreateOperatorPerformanceReport_Result ( int data1 )
            {
            return new OperatorPerformanceReport_Result
                {
                Data1 = data1
                };
            }

        static OperatorPerformanceReport_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(OperatorPerformanceReport_Result));
            }


        }
    }
