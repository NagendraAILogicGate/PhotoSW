using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "PrintSummary_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class PrintSummary_Result :  ComplexObject
        {
        private int? _PrintedQuantity;

        private string _DG_Orders_ProductType_Name;

        private int? _PrintedSold;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PrintedQuantity
            {
            get
                {
                return this._PrintedQuantity;
                }
            set
                {
               // this.ReportPropertyChanging(PrintSummary_Result.(19864));
                this._PrintedQuantity = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(PrintSummary_Result.(19864));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string DG_Orders_ProductType_Name
            {
            get
                {
                return this._DG_Orders_ProductType_Name;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(PrintSummary_Result.(12495));
                    this._DG_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(PrintSummary_Result.(12495));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PrintedSold
            {
            get
                {
                return this._PrintedSold;
                }
            set
                {
              //  this.ReportPropertyChanging(PrintSummary_Result.(20267));
                this._PrintedSold = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(PrintSummary_Result.(20267));
                }
            }

        static PrintSummary_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(PrintSummary_Result));
            }

        }
    }
