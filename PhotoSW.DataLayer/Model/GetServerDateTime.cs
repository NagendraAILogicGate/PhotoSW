using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "GetServerDateTime"), DataContract(IsReference = true)]
    [Serializable]
    public class GetServerDateTime : EntityObject
        {
        private DateTime _CurrentDateTime;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public DateTime CurrentDateTime
            {
            get
                {
                return this._CurrentDateTime;
                }
            set
                {
                if(this._CurrentDateTime != value)
                    {
                   // string expr_54 = GetServerDateTime.(17446);
                    //if(3 != 0)
                    //    {
                    //    this.ReportPropertyChanging(expr_54);
                    //    }
                    this._CurrentDateTime = StructuralObject.SetValidValue(value);
                    //if(!false)
                    //    {
                    //    this.ReportPropertyChanged(GetServerDateTime.(17446));
                    //    }
                    }
                }
            }

        public static GetServerDateTime CreateGetServerDateTime ( DateTime currentDateTime )
            {
            return new GetServerDateTime
                {
                CurrentDateTime = currentDateTime
                };
            }

        static GetServerDateTime ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(GetServerDateTime));
            }


        }
    }
