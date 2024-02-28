using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;


namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_SubStores"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_SubStores : EntityObject
        {
        private int _PS_SubStore_pkey;

        private string _PS_SubStore_Name;

        private string _PS_SubStore_Description;

        private bool? _PS_SubStore_IsActive;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

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
              //  this.ReportPropertyChanging(DG_SubStores.(16737));
                this._PS_SubStore_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(DG_SubStores.(16737));
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
                  //  this.ReportPropertyChanging(DG_SubStores.(16762));
                    this._PS_SubStore_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_SubStores.(16762));
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
                  //  this.ReportPropertyChanging(DG_SubStores.(16787));
                    this._PS_SubStore_Description = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_SubStores.(16787));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SubStore_IsActive
            {
            get
                {
                return this._PS_SubStore_IsActive;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_SubStores.(16820));
                this._PS_SubStore_IsActive = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_SubStores.(16820));
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
                  //  this.ReportPropertyChanging(DG_SubStores.(6849));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_SubStores.(6849));
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
               // this.ReportPropertyChanging(DG_SubStores.(6862));
                this._IsSynced = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_SubStores.(6862));
                }
            }

        public static PS_SubStores CreateDG_SubStores ( int dG_SubStore_pkey, bool isSynced )
            {
            return new PS_SubStores
                {
                PS_SubStore_pkey = dG_SubStore_pkey,
                IsSynced = isSynced
                };
            }

        static PS_SubStores ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_SubStores));
            }


        }
    }
