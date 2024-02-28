using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Photo_Effects"), DataContract(IsReference = true)]
    [Serializable]
     public class PS_Photo_Effects : EntityObject
        {
        private int _PS_Photo_Effects_pkey;

        private string _PS_Photo_Effects_Name;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int DG_Photo_Effects_pkey
            {
            get
                {
                return this._PS_Photo_Effects_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Photo_Effects_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_Photo_Effects.(12246));
                this._PS_Photo_Effects_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_Photo_Effects.(12246));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photo_Effects_Name
            {
            get
                {
                return this._PS_Photo_Effects_Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Photo_Effects.(12275));
                    this._PS_Photo_Effects_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Photo_Effects.(12275));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static PS_Photo_Effects CreateDG_Photo_Effects ( int dG_Photo_Effects_pkey )
            {
            return new PS_Photo_Effects
                {
                DG_Photo_Effects_pkey = dG_Photo_Effects_pkey
                };
            }

        static PS_Photo_Effects ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Photo_Effects));
            }


        }
    }
