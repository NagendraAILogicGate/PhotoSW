using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;


namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetAllTable"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetAllTable : EntityObject
        {        
        private string _name;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string name
            {
            get
                {
                return this._name;
                }
            set
                {
                if(!(this._name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
               // this.ReportPropertyChanging(vw_GetAllTable.(18489));
                IL_1D:
                this._name = StructuralObject.SetValidValue(value, false);
              //  this.ReportPropertyChanged(vw_GetAllTable.(18489));
                IL_3E:
                if(false)
                    {
                    goto IL_0D;
                    }
                if(!false)
                    {
                    return;
                    }
                goto IL_1D;
                }
            }

        public static vw_GetAllTable Createvw_GetAllTable ( string name )
            {
            return new vw_GetAllTable
                {
                name = name
                };
            }

        static vw_GetAllTable ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(vw_GetAllTable));
            }

        }
    }
