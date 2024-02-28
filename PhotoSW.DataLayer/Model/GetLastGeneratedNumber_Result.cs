using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GetLastGeneratedNumber_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GetLastGeneratedNumber_Result : ComplexObject
        {
        private string _NextNumber;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string NextNumber
            {
            get
                {
                return this._NextNumber;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(GetLastGeneratedNumber_Result.(19368));
                    this._NextNumber = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetLastGeneratedNumber_Result.(19368));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static GetLastGeneratedNumber_Result CreateGetLastGeneratedNumber_Result ( string nextNumber )
            {
            return new GetLastGeneratedNumber_Result
                {
                NextNumber = nextNumber
                };
            }

        static GetLastGeneratedNumber_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(GetLastGeneratedNumber_Result));
            }


        }
    }
