using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetRideCamera"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetRideCamera : EntityObject
        {

        private string _RideCameras;

        private int _PS_Camera_pkey;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string RideCameras
            {
            get
                {
                return this._RideCameras;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(vw_GetRideCamera.(18974));
                    this._RideCameras = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetRideCamera.(18974));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Camera_pkey
            {
            get
                {
                return this._PS_Camera_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Camera_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
             //   this.ReportPropertyChanging(vw_GetRideCamera.(8121));
                this._PS_Camera_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(vw_GetRideCamera.(8121));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        public static vw_GetRideCamera Createvw_GetRideCamera ( int dG_Camera_pkey )
            {
            return new vw_GetRideCamera
                {
                PS_Camera_pkey = dG_Camera_pkey
                };
            }

        static vw_GetRideCamera ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(vw_GetRideCamera));
            }
        }
    }
