using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GetPhotgrapherPerformance_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GetPhotgrapherPerformance_Result : ComplexObject
        {
        private string _UserName;

        private int? _NumberofCapture;

        private int _NumberofSales;

        private int _ImageSold;

        private decimal _Revenue;

        private string _Dataflag;

        private string _StoreName;

        private string _Printedby;

        private int? _Shots_Previewed;

        private DateTime? _FromDate1;

        private DateTime? _ToDate1;

        private DateTime? _FromDate2;

        private DateTime? _ToDate2;

        private int _PrintImageSold;

        //[NonSerialized]
        //internal static GetString ;

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
                   // this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(4508));
                    this._UserName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(4508));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? NumberofCapture
            {
            get
                {
                return this._NumberofCapture;
                }
            set
                {
             //   this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(19608));
                this._NumberofCapture = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(19608));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int NumberofSales
            {
            get
                {
                return this._NumberofSales;
                }
            set
                {
             //   this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(19629));
                this._NumberofSales = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(19629));
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
             //   this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(19472));
                this._ImageSold = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(19472));
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
            //    this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(19485));
                this._Revenue = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(19485));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string Dataflag
            {
            get
                {
                return this._Dataflag;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(19650));
                    this._Dataflag = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(19650));
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
               //     this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(4495));
                    this._StoreName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(4495));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Printedby
            {
            get
                {
                return this._Printedby;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(19663));
                    this._Printedby = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(19663));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
            //    this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(19498));
                this._Shots_Previewed = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(19498));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? FromDate1
            {
            get
                {
                return this._FromDate1;
                }
            set
                {
           //     this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(19676));
                this._FromDate1 = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(19676));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? ToDate1
            {
            get
                {
                return this._ToDate1;
                }
            set
                {
           //     this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(19689));
                this._ToDate1 = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(19689));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? FromDate2
            {
            get
                {
                return this._FromDate2;
                }
            set
                {
         //       this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(19702));
                this._FromDate2 = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(19702));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? ToDate2
            {
            get
                {
                return this._ToDate2;
                }
            set
                {
            //    this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(19715));
                this._ToDate2 = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(19715));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PrintImageSold
            {
            get
                {
                return this._PrintImageSold;
                }
            set
                {
           //     this.ReportPropertyChanging(GetPhotgrapherPerformance_Result.(19728));
                this._PrintImageSold = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(GetPhotgrapherPerformance_Result.(19728));
                }
            }

        public static GetPhotgrapherPerformance_Result CreateGetPhotgrapherPerformance_Result ( int numberofSales, int imageSold, decimal revenue, string dataflag, int printImageSold )
            {
            GetPhotgrapherPerformance_Result getPhotgrapherPerformance_Result;
            if(true)
                {
                getPhotgrapherPerformance_Result = new GetPhotgrapherPerformance_Result();
                do
                    {
                    getPhotgrapherPerformance_Result.NumberofSales = numberofSales;
                    }
                while(false);
                if(6 == 0)
                    {
                    return getPhotgrapherPerformance_Result;
                    }
                getPhotgrapherPerformance_Result.ImageSold = imageSold;
                getPhotgrapherPerformance_Result.Revenue = revenue;
                }
            getPhotgrapherPerformance_Result.Dataflag = dataflag;
            getPhotgrapherPerformance_Result.PrintImageSold = printImageSold;
            return getPhotgrapherPerformance_Result;
            }

        static GetPhotgrapherPerformance_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(GetPhotgrapherPerformance_Result));
            }


        }
    }
