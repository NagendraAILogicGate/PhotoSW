using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GetLocationPerformance_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GetLocationPerformance_Result : ComplexObject
        {
        private string _selectedSubStore;

        private int _Number_of_Capture;

        private int _Number_of_Sales;

        private int _ImageSold;

        private decimal _Revenue;

        private string _PS_Location_Name;

        private int _PS_Location_pkey;

        private int? _Shots_Previewed;

        private string _DataFlag;

        private string _PrintedBy;

        private string _StoreName;

        private DateTime? _FromDate;

        private DateTime? _ToDate;

        private DateTime? _SecondFromDate;

        private DateTime? _SecondToDate;

        private decimal _AveragePrice;

        private decimal? _SellThru;

        private string _PS_SubStore_Name;

        private string _defaultCurrency;

        private decimal? _TotalSiteRevenue;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string selectedSubStore
            {
            get
                {
                return this._selectedSubStore;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(GetLocationPerformance_Result.(19134));
                    this._selectedSubStore = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetLocationPerformance_Result.(19134));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int Number_of_Capture
            {
            get
                {
                return this._Number_of_Capture;
                }
            set
                {
               // this.ReportPropertyChanging(GetLocationPerformance_Result.(19406));
                this._Number_of_Capture = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetLocationPerformance_Result.(19406));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int Number_of_Sales
            {
            get
                {
                return this._Number_of_Sales;
                }
            set
                {
             //   this.ReportPropertyChanging(GetLocationPerformance_Result.(19431));
                this._Number_of_Sales = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetLocationPerformance_Result.(19431));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int ImageSold
            {
            get
                {
                return this._ImageSold;
                }
            set
                {
             //   this.ReportPropertyChanging(GetLocationPerformance_Result.(19452));
                this._ImageSold = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetLocationPerformance_Result.(19452));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public decimal Revenue
            {
            get
                {
                return this._Revenue;
                }
            set
                {
              //  this.ReportPropertyChanging(GetLocationPerformance_Result.(19465));
                this._Revenue = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetLocationPerformance_Result.(19465));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Location_Name
            {
            get
                {
                return this._PS_Location_Name;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(GetLocationPerformance_Result.(10529));
                    this._PS_Location_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetLocationPerformance_Result.(10529));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Location_pkey
            {
            get
                {
                return this._PS_Location_pkey;
                }
            set
                {
              //  this.ReportPropertyChanging(GetLocationPerformance_Result.(10504));
                this._PS_Location_pkey = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(GetLocationPerformance_Result.(10504));
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
            //    this.ReportPropertyChanging(GetLocationPerformance_Result.(19478));
                this._Shots_Previewed = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetLocationPerformance_Result.(19478));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string DataFlag
            {
            get
                {
                return this._DataFlag;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(GetLocationPerformance_Result.(19499));
                    this._DataFlag = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetLocationPerformance_Result.(19499));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PrintedBy
            {
            get
                {
                return this._PrintedBy;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(GetLocationPerformance_Result.(19061));
                    this._PrintedBy = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetLocationPerformance_Result.(19061));
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
                //    this.ReportPropertyChanging(GetLocationPerformance_Result.(4475));
                    this._StoreName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetLocationPerformance_Result.(4475));
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
             //   this.ReportPropertyChanging(GetLocationPerformance_Result.(4225));
                this._FromDate = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(GetLocationPerformance_Result.(4225));
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
            //    this.ReportPropertyChanging(GetLocationPerformance_Result.(4238));
                this._ToDate = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(GetLocationPerformance_Result.(4238));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? SecondFromDate
            {
            get
                {
                return this._SecondFromDate;
                }
            set
                {
             //   this.ReportPropertyChanging(GetLocationPerformance_Result.(4437));
                this._SecondFromDate = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetLocationPerformance_Result.(4437));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? SecondToDate
            {
            get
                {
                return this._SecondToDate;
                }
            set
                {
            //    this.ReportPropertyChanging(GetLocationPerformance_Result.(4458));
                this._SecondToDate = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetLocationPerformance_Result.(4458));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public decimal AveragePrice
            {
            get
                {
                return this._AveragePrice;
                }
            set
                {
           //     this.ReportPropertyChanging(GetLocationPerformance_Result.(19512));
                this._AveragePrice = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetLocationPerformance_Result.(19512));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? SellThru
            {
            get
                {
                return this._SellThru;
                }
            set
                {
         //       this.ReportPropertyChanging(GetLocationPerformance_Result.(19529));
                this._SellThru = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(GetLocationPerformance_Result.(19529));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_SubStore_Name
            {
            get
                {
                return this._PS_SubStore_Name;
                }
            set
                {
                do
                    {
            //        this.ReportPropertyChanging(GetLocationPerformance_Result.(17331));
                    this._PS_SubStore_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetLocationPerformance_Result.(17331));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string defaultCurrency
            {
            get
                {
                return this._defaultCurrency;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(GetLocationPerformance_Result.(19542));
                    this._defaultCurrency = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetLocationPerformance_Result.(19542));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? TotalSiteRevenue
            {
            get
                {
                return this._TotalSiteRevenue;
                }
            set
                {
               // this.ReportPropertyChanging(GetLocationPerformance_Result.(19563));
                this._TotalSiteRevenue = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetLocationPerformance_Result.(19563));
                }
            }

        public static GetLocationPerformance_Result CreateGetLocationPerformance_Result ( string selectedSubStore, int number_of_Capture, int number_of_Sales, int imageSold, decimal revenue, string dG_Location_Name, int dG_Location_pkey, string dataFlag, decimal averagePrice, string dG_SubStore_Name )
            {
            GetLocationPerformance_Result getLocationPerformance_Result = new GetLocationPerformance_Result();
            getLocationPerformance_Result.selectedSubStore = selectedSubStore;
            GetLocationPerformance_Result expr_74 = getLocationPerformance_Result;
            if(true)
                {
                expr_74.Number_of_Capture = number_of_Capture;
                }
            getLocationPerformance_Result.Number_of_Sales = number_of_Sales;
            getLocationPerformance_Result.ImageSold = imageSold;
            do
                {
                getLocationPerformance_Result.Revenue = revenue;
                getLocationPerformance_Result.PS_Location_Name = dG_Location_Name;
                getLocationPerformance_Result.PS_Location_pkey = dG_Location_pkey;
                getLocationPerformance_Result.DataFlag = dataFlag;
                }
            while(5 == 0);
            getLocationPerformance_Result.AveragePrice = averagePrice;
            getLocationPerformance_Result.PS_SubStore_Name = dG_SubStore_Name;
            return getLocationPerformance_Result;
            }

        static GetLocationPerformance_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(GetLocationPerformance_Result));
            }


        }
    }
