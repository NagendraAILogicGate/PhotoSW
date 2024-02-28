using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "SetDataToCentralServer_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class SetDataToCentralServer_Result : ComplexObject
        {
        private int _Column1;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int Column1
            {
            get
                {
                return this._Column1;
                }
            set
                {
               // this.ReportPropertyChanging(SetDataToCentralServer_Result.(20405));
                this._Column1 = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(SetDataToCentralServer_Result.(20405));
                }
            }

        public static SetDataToCentralServer_Result CreateSetDataToCentralServer_Result ( int column1 )
            {
            return new SetDataToCentralServer_Result
                {
                Column1 = column1
                };
            }

        static SetDataToCentralServer_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(SetDataToCentralServer_Result));
            }



        }
    }
