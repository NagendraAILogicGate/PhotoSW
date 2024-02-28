using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetSubStoreLocations"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetSubStoreLocations : EntityObject
        {
        private int _PS_SubStore_Location_Pkey;

        private string _PS_Location_Name;

        private int _PS_Location_pkey;

        private int _PS_SubStore_ID;

        //[NonSerialized]
        //internal static GetString ;

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
             //   this.ReportPropertyChanging(vw_GetSubStoreLocations.(17111));
                this._PS_SubStore_Location_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetSubStoreLocations.(17111));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

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
            //    this.ReportPropertyChanging(vw_GetSubStoreLocations.(10413));
                IL_1D:
                this._PS_Location_Name = StructuralObject.SetValidValue(value, false);
            //    this.ReportPropertyChanged(vw_GetSubStoreLocations.(10413));
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
         //       this.ReportPropertyChanging(vw_GetSubStoreLocations.(10388));
                this._PS_Location_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
           //     this.ReportPropertyChanged(vw_GetSubStoreLocations.(10388));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_SubStore_ID
            {
            get
                {
                return this._PS_SubStore_ID;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_SubStore_ID == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
          //      this.ReportPropertyChanging(vw_GetSubStoreLocations.(17148));
                this._PS_SubStore_ID = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
       //         this.ReportPropertyChanged(vw_GetSubStoreLocations.(17148));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        public static vw_GetSubStoreLocations Createvw_GetSubStoreLocations ( int dG_SubStore_Location_Pkey, string dG_Location_Name, int dG_Location_pkey, int dG_SubStore_ID )
            {
            vw_GetSubStoreLocations vw_GetSubStoreLocations;
            while(true)
                {
                vw_GetSubStoreLocations = new vw_GetSubStoreLocations();
                if(5 != 0 && 8 != 0)
                    {
                    vw_GetSubStoreLocations.PS_SubStore_Location_Pkey = dG_SubStore_Location_Pkey;
                    vw_GetSubStoreLocations.PS_Location_Name = dG_Location_Name;
                    if(3 == 0)
                        {
                        return vw_GetSubStoreLocations;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            vw_GetSubStoreLocations.PS_Location_pkey = dG_Location_pkey;
            vw_GetSubStoreLocations.PS_SubStore_ID = dG_SubStore_ID;
            return vw_GetSubStoreLocations;
            }

        static vw_GetSubStoreLocations ()
            {
            // Note: this type is marked as 'beforefieldinit'.
        //    Strings.CreateGetStringDelegate(typeof(vw_GetSubStoreLocations));
            }

        }
    }
