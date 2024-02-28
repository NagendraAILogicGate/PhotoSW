using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GenerateBill_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GenerateBill_Result : EntityObject
        {
        private string _Name;

        private string _Qty;

        private string _Price;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Name
            {
            get
                {
                return this._Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(GenerateBill_Result.(17983));
                    this._Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GenerateBill_Result.(17983));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Qty
            {
            get
                {
                return this._Qty;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(GenerateBill_Result.(19317));
                    this._Qty = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GenerateBill_Result.(19317));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Price
            {
            get
                {
                return this._Price;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(GenerateBill_Result.(19322));
                    this._Price = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GenerateBill_Result.(19322));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        static GenerateBill_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            //Strings.CreateGetStringDelegate(typeof(GenerateBill_Result));
            }

        }
    }
