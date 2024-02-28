using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Moderate_Photos"), DataContract(IsReference = true)]
    [Serializable]
     public class PS_Moderate_Photos : EntityObject
        {

        private int _PS_Mod_Photo_pkey;

        private int _PS_Mod_Photo_ID;

        private DateTime _PS_Mod_Date;

        private int _PS_Mod_User_ID;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Mod_Photo_pkey
            {
            get
                {
                return this._PS_Mod_Photo_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Mod_Photo_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_Moderate_Photos.(9757));
                this._PS_Mod_Photo_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_Moderate_Photos.(9757));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Mod_Photo_ID
            {
            get
                {
                return this._PS_Mod_Photo_ID;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Moderate_Photos.(9782));
                this._PS_Mod_Photo_ID = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Moderate_Photos.(9782));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public DateTime PS_Mod_Date
            {
            get
                {
                return this._PS_Mod_Date;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Moderate_Photos.(9803));
                this._PS_Mod_Date = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Moderate_Photos.(9803));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Mod_User_ID
            {
            get
                {
                return this._PS_Mod_User_ID;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Moderate_Photos.(9820));
                this._PS_Mod_User_ID = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Moderate_Photos.(9820));
                }
            }

        public static PS_Moderate_Photos CreateDG_Moderate_Photos ( int dG_Mod_Photo_pkey, int dG_Mod_Photo_ID, DateTime dG_Mod_Date, int dG_Mod_User_ID )
            {
            PS_Moderate_Photos dG_Moderate_Photos;
            while(true)
                {
                dG_Moderate_Photos = new PS_Moderate_Photos();
                if(5 != 0 && 8 != 0)
                    {
                    dG_Moderate_Photos.PS_Mod_Photo_pkey = dG_Mod_Photo_pkey;
                    dG_Moderate_Photos.PS_Mod_Photo_ID = dG_Mod_Photo_ID;
                    if(3 == 0)
                        {
                        return dG_Moderate_Photos;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            dG_Moderate_Photos.PS_Mod_Date = dG_Mod_Date;
            dG_Moderate_Photos.PS_Mod_User_ID = dG_Mod_User_ID;
            return dG_Moderate_Photos;
            }

        static PS_Moderate_Photos ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Moderate_Photos));
            }

        }
    }
