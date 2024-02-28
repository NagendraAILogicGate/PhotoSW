using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_Permission_Role"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Permission_Role : EntityObject
        {
        private int _PS_Permission_Role_pkey;

        private int _PS_User_Roles_Id;

        private int _PS_Permission_Id;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Permission_Role_pkey
            {
            get
                {
                return this._PS_Permission_Role_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Permission_Role_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_Permission_Role.(12105));
                this._PS_Permission_Role_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
                //this.ReportPropertyChanged(DG_Permission_Role.(12105));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_User_Roles_Id
            {
            get
                {
                return this._PS_User_Roles_Id;
                }
            set
                {
                //this.ReportPropertyChanging(DG_Permission_Role.(12138));
                this._PS_User_Roles_Id = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(DG_Permission_Role.(12138));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Permission_Id
            {
            get
                {
                return this._PS_Permission_Id;
                }
            set
                {
                //this.ReportPropertyChanging(DG_Permission_Role.(12163));
                this._PS_Permission_Id = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Permission_Role.(12163));
                }
            }

        public static PS_Permission_Role CreateDG_Permission_Role ( int dG_Permission_Role_pkey, int dG_User_Roles_Id, int dG_Permission_Id )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            PS_Permission_Role expr_28 = new PS_Permission_Role();
            PS_Permission_Role dG_Permission_Role;
            if(3 != 0)
                {
                dG_Permission_Role = expr_28;
                }
            dG_Permission_Role.PS_Permission_Role_pkey = dG_Permission_Role_pkey;
            IL_0F:
            PS_Permission_Role expr_3F = dG_Permission_Role;
            if(5 != 0)
                {
                expr_3F.PS_User_Roles_Id = dG_User_Roles_Id;
                }
            if(!false)
                {
                dG_Permission_Role.PS_Permission_Id = dG_Permission_Id;
                }
            IL_23:
            if(5 != 0)
                {
                return dG_Permission_Role;
                }
            goto IL_0F;
            }

        static PS_Permission_Role ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            //.CreateGetStringDelegate(typeof(DG_Permission_Role));
            }


        }
    }
