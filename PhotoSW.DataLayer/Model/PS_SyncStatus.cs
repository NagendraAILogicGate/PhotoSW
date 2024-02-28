using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_SyncStatus"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_SyncStatus : EntityObject
        {

        private int _PS_Sync_pkey;

        private DateTime? _PS_Sync_Date;

        private bool? _PS_Sync_Status;

        //[NonSerialized]
        //internal static GetString ;

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Sync_pkey
            {
            get
                {
                return this._PS_Sync_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Sync_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
                //this.ReportPropertyChanging(DG_SyncStatus.(16853));
                this._PS_Sync_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_SyncStatus.(16853));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Sync_Date
            {
            get
                {
                return this._PS_Sync_Date;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_SyncStatus.(16870));
                this._PS_Sync_Date = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(DG_SyncStatus.(16870));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Sync_Status
            {
            get
                {
                return this._PS_Sync_Status;
                }
            set
                {
                //this.ReportPropertyChanging(DG_SyncStatus.(16887));
                this._PS_Sync_Status = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_SyncStatus.(16887));
                }
            }

        public static PS_SyncStatus CreateDG_SyncStatus ( int dG_Sync_pkey )
            {
            return new PS_SyncStatus
                {
                PS_Sync_pkey = dG_Sync_pkey
                };
            }

        static PS_SyncStatus ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            //Strings.CreateGetStringDelegate(typeof(DG_SyncStatus));
            }

        }
    }
