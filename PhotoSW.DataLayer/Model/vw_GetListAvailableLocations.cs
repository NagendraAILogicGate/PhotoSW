using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetListAvailableLocations"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetListAvailableLocations : EntityObject
        {
        private string _PS_Location_Name;

        private int _PS_Location_pkey;

        private int? _PS_Location_ID;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_Location_Name
            {
            get
                {
                return this._PS_Location_Name;
                }
            set
                {
                if(!(this._PS_Location_Name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
               // this.ReportPropertyChanging(vw_GetListAvailableLocations.(10220));
                IL_1D:
                this._PS_Location_Name = StructuralObject.SetValidValue(value, false);
              //  this.ReportPropertyChanged(vw_GetListAvailableLocations.(10220));
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

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Location_pkey
            {
            get
                {
                return this._PS_Location_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Location_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
             //   this.ReportPropertyChanging(vw_GetListAvailableLocations.(10195));
                this._PS_Location_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetListAvailableLocations.(10195));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Location_ID
            {
            get
                {
                return this._PS_Location_ID;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_GetListAvailableLocations.(16976));
                this._PS_Location_ID = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetListAvailableLocations.(16976));
                }
            }

        public static vw_GetListAvailableLocations Createvw_GetListAvailableLocations ( string dG_Location_Name, int dG_Location_pkey )
            {
            return new vw_GetListAvailableLocations
                {
                PS_Location_Name = dG_Location_Name,
                PS_Location_pkey = dG_Location_pkey
                };
            }

        static vw_GetListAvailableLocations ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(vw_GetListAvailableLocations));
            }


        }
    }
