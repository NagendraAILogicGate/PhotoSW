using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GetPrintedProduct_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GetPrintedProduct_Result : ComplexObject
        {

        private int _PrintedQuantity;

        private string _PS_Orders_ProductType_Name;

        private DateTime? _PS_Print_Date;

        private string _PhotoNumber;

        private string _PS_SubStore_Name;

        private string _ProductCode;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PrintedQuantity
            {
            get
                {
                return this._PrintedQuantity;
                }
            set
                {
               // this.ReportPropertyChanging(GetPrintedProduct_Result.(19778));
                this._PrintedQuantity = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetPrintedProduct_Result.(19778));
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
                 //   this.ReportPropertyChanging(GetPrintedProduct_Result.(12409));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrintedProduct_Result.(12409));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Print_Date
            {
            get
                {
                return this._PS_Print_Date;
                }
            set
                {
              //  this.ReportPropertyChanging(GetPrintedProduct_Result.(13859));
                this._PS_Print_Date = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(GetPrintedProduct_Result.(13859));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PhotoNumber
            {
            get
                {
                return this._PhotoNumber;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(GetPrintedProduct_Result.(19799));
                    this._PhotoNumber = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrintedProduct_Result.(19799));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
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
                 //   this.ReportPropertyChanging(GetPrintedProduct_Result.(17380));
                    this._PS_SubStore_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrintedProduct_Result.(17380));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ProductCode
            {
            get
                {
                return this._ProductCode;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(GetPrintedProduct_Result.(19381));
                    this._ProductCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrintedProduct_Result.(19381));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static GetPrintedProduct_Result CreateGetPrintedProduct_Result ( int printedQuantity )
            {
            return new GetPrintedProduct_Result
                {
                PrintedQuantity = printedQuantity
                };
            }

        static GetPrintedProduct_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(GetPrintedProduct_Result));
            }

        }
    }
