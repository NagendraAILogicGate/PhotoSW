using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GetConnectionStatus_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GetConnectionStatus_Result : ComplexObject
        {
        private int _constatus;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int constatus
            {
            get
                {
                return this._constatus;
                }
            set
                {
               // this.ReportPropertyChanging(GetConnectionStatus_Result.(19333));
                this._constatus = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetConnectionStatus_Result.(19333));
                }
            }

        public static GetConnectionStatus_Result CreateGetConnectionStatus_Result ( int constatus )
            {
            return new GetConnectionStatus_Result
                {
                constatus = constatus
                };
            }

        static GetConnectionStatus_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(GetConnectionStatus_Result));
            }


        }
    }
