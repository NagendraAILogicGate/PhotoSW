using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_User_Roles"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_User_Roles : EntityObject
        {

        private int _PS_User_Roles_pkey;

        private string _PS_User_Role;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_User_Roles_pkey
            {
            get
                {
                return this._PS_User_Roles_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_User_Roles_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_User_Roles.(16913));
                this._PS_User_Roles_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_User_Roles.(16913));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_User_Role
            {
            get
                {
                return this._PS_User_Role;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_User_Roles.(16938));
                    this._PS_User_Role = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_User_Roles.(16938));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SyncCode
            {
            get
                {
                return this._SyncCode;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_User_Roles.(6858));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_User_Roles.(6858));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public bool IsSynced
            {
            get
                {
                return this._IsSynced;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_User_Roles.(6871));
                this._IsSynced = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_User_Roles.(6871));
                }
            }

        public static PS_User_Roles CreateDG_User_Roles ( int dG_User_Roles_pkey, string dG_User_Role, bool isSynced )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            PS_User_Roles expr_28 = new PS_User_Roles();
            PS_User_Roles dG_User_Roles;
            if(3 != 0)
                {
                dG_User_Roles = expr_28;
                }
            dG_User_Roles.PS_User_Roles_pkey = dG_User_Roles_pkey;
            IL_0F:
            PS_User_Roles expr_3F = dG_User_Roles;
            if(5 != 0)
                {
                expr_3F.PS_User_Role = dG_User_Role;
                }
            if(!false)
                {
                dG_User_Roles.IsSynced = isSynced;
                }
            IL_23:
            if(5 != 0)
                {
                return dG_User_Roles;
                }
            goto IL_0F;
            }

        static PS_User_Roles ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_User_Roles));
            }

        }
    }
