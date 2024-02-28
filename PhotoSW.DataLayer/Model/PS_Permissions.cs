using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Permissions"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Permissions : EntityObject
        {

        private int _PS_Permission_pkey;

        private string _PS_Permission_Name;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int DG_Permission_pkey
            {
            get
                {
                return this._PS_Permission_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Permission_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(DG_Permissions.(12193));
                this._PS_Permission_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_Permissions.(12193));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string DG_Permission_Name
            {
            get
                {
                return this._PS_Permission_Name;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Permissions.(12218));
                    this._PS_Permission_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Permissions.(12218));
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
                   // this.ReportPropertyChanging(DG_Permissions.(6630));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Permissions.(6630));
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
               // this.ReportPropertyChanging(DG_Permissions.(6643));
                this._IsSynced = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Permissions.(6643));
                }
            }

        public static PS_Permissions CreateDG_Permissions ( int dG_Permission_pkey, string dG_Permission_Name, bool isSynced )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            PS_Permissions expr_28 = new PS_Permissions();
            PS_Permissions dG_Permissions;
            if(3 != 0)
                {
                dG_Permissions = expr_28;
                }
            dG_Permissions.DG_Permission_pkey = dG_Permission_pkey;
            IL_0F:
            PS_Permissions expr_3F = dG_Permissions;
            if(5 != 0)
                {
                expr_3F.DG_Permission_Name = dG_Permission_Name;
                }
            if(!false)
                {
                dG_Permissions.IsSynced = isSynced;
                }
            IL_23:
            if(5 != 0)
                {
                return dG_Permissions;
                }
            goto IL_0F;
            }

        static PS_Permissions ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            //.CreateGetStringDelegate(typeof(DG_Permissions));
            }
        }
    }
