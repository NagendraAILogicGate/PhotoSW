using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetSubStoreData"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetSubStoreData : EntityObject
        {
        private int _PS_SubStore_pkey;

        private string _PS_SubStore_Name;

        private string _PS_SubStore_Description;

        private string _PS_SubStore_Locations;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_SubStore_pkey
            {
            get
                {
                return this._PS_SubStore_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_SubStore_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(vw_GetSubStoreData.(17185));
                this._PS_SubStore_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetSubStoreData.(17185));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SubStore_Name
            {
            get
                {
                return this._PS_SubStore_Name;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(vw_GetSubStoreData.(17210));
                    this._PS_SubStore_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetSubStoreData.(17210));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SubStore_Description
            {
            get
                {
                return this._PS_SubStore_Description;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(vw_GetSubStoreData.(17235));
                    this._PS_SubStore_Description = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetSubStoreData.(17235));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SubStore_Locations
            {
            get
                {
                return this._PS_SubStore_Locations;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_GetSubStoreData.(2942));
                    this._PS_SubStore_Locations = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetSubStoreData.(2942));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static vw_GetSubStoreData Createvw_GetSubStoreData ( int dG_SubStore_pkey )
            {
            return new vw_GetSubStoreData
                {
                PS_SubStore_pkey = dG_SubStore_pkey
                };
            }

        static vw_GetSubStoreData ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(vw_GetSubStoreData));
            }

        }
    }
