using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_SubStore_Locations"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_SubStore_Locations : EntityObject
        {
        private int _PS_SubStore_Location_Pkey;

        private int _PS_SubStore_ID;

        private int _PS_Location_ID;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_SubStore_Location_Pkey
            {
            get
                {
                return this._PS_SubStore_Location_Pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_SubStore_Location_Pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(DG_SubStore_Locations.(16651));
                this._PS_SubStore_Location_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_SubStore_Locations.(16651));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_SubStore_ID
            {
            get
                {
                return this._PS_SubStore_ID;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_SubStore_Locations.(16688));
                this._PS_SubStore_ID = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_SubStore_Locations.(16688));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Location_ID
            {
            get
                {
                return this._PS_Location_ID;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_SubStore_Locations.(16709));
                this._PS_Location_ID = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_SubStore_Locations.(16709));
                }
            }

        public static PS_SubStore_Locations CreateDG_SubStore_Locations ( int dG_SubStore_Location_Pkey, int dG_SubStore_ID, int dG_Location_ID )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            PS_SubStore_Locations expr_28 = new PS_SubStore_Locations();
            PS_SubStore_Locations dG_SubStore_Locations;
            if(3 != 0)
                {
                dG_SubStore_Locations = expr_28;
                }
            dG_SubStore_Locations.PS_SubStore_Location_Pkey = dG_SubStore_Location_Pkey;
            IL_0F:
            PS_SubStore_Locations expr_3F = dG_SubStore_Locations;
            if(5 != 0)
                {
                expr_3F.PS_SubStore_ID = dG_SubStore_ID;
                }
            if(!false)
                {
                dG_SubStore_Locations.PS_Location_ID = dG_Location_ID;
                }
            IL_23:
            if(5 != 0)
                {
                return dG_SubStore_Locations;
                }
            goto IL_0F;
            }

        static PS_SubStore_Locations ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(DG_SubStore_Locations));
            }


        }
    }
