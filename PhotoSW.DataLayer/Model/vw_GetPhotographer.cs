using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetPhotographer"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetPhotographer : EntityObject
        {
        private int _PS_User_pkey;

        private string _PS_User_Name;

        private int _PS_User_Roles_Id;

        private string _Photograper;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_User_pkey
            {
            get
                {
                return this._PS_User_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_User_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(vw_GetPhotographer.(17284));
                this._PS_User_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(vw_GetPhotographer.(17284));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_User_Name
            {
            get
                {
                return this._PS_User_Name;
                }
            set
                {
                if(!(this._PS_User_Name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
            //    this.ReportPropertyChanging(vw_GetPhotographer.(17301));
                IL_1D:
                this._PS_User_Name = StructuralObject.SetValidValue(value, false);
           //     this.ReportPropertyChanged(vw_GetPhotographer.(17301));
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
        public int PS_User_Roles_Id
            {
            get
                {
                return this._PS_User_Roles_Id;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_User_Roles_Id == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
            //    this.ReportPropertyChanging(vw_GetPhotographer.(12700));
                this._PS_User_Roles_Id = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetPhotographer.(12700));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Photograper
            {
            get
                {
                return this._Photograper;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(vw_GetPhotographer.(18813));
                    this._Photograper = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPhotographer.(18813));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static vw_GetPhotographer Createvw_GetPhotographer ( int dG_User_pkey, string dG_User_Name, int dG_User_Roles_Id )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            vw_GetPhotographer expr_28 = new vw_GetPhotographer();
            vw_GetPhotographer vw_GetPhotographer;
            if(3 != 0)
                {
                vw_GetPhotographer = expr_28;
                }
            vw_GetPhotographer.PS_User_pkey = dG_User_pkey;
            IL_0F:
            vw_GetPhotographer expr_3F = vw_GetPhotographer;
            if(5 != 0)
                {
                expr_3F.PS_User_Name = dG_User_Name;
                }
            if(!false)
                {
                vw_GetPhotographer.PS_User_Roles_Id = dG_User_Roles_Id;
                }
            IL_23:
            if(5 != 0)
                {
                return vw_GetPhotographer;
                }
            goto IL_0F;
            }

        static vw_GetPhotographer ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(vw_GetPhotographer));
            }


        }
    }
