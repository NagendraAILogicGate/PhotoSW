using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "uspCheckUpdates_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class uspCheckUpdates_Result : ComplexObject
        {
        private string _VERSION;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string VERSION
            {
            get
                {
                return this._VERSION;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(uspCheckUpdates_Result.(20420));
                    this._VERSION = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(uspCheckUpdates_Result.(20420));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static uspCheckUpdates_Result CreateuspCheckUpdates_Result ( string vERSION )
            {
            return new uspCheckUpdates_Result
                {
                VERSION = vERSION
                };
            }

        static uspCheckUpdates_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(uspCheckUpdates_Result));
            }

        }
    }
