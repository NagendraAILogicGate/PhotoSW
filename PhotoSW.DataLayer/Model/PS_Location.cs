using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Graphics"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Location : EntityObject
        {
        private int _PS_Location_pkey;

        private string _PS_Location_Name;

        private int _PS_Store_ID;

        private string _PS_Location_PhoneNumber;

        private bool? _PS_Location_IsActive;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

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
              //  this.ReportPropertyChanging(DG_Location.(9623));
                this._PS_Location_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_Location.(9623));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Location_Name
            {
            get
                {
                return this._PS_Location_Name;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Location.(9648));
                    this._PS_Location_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Location.(9648));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Store_ID
            {
            get
                {
                return this._PS_Store_ID;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Location.(9673));
                this._PS_Store_ID = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Location.(9673));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Location_PhoneNumber
            {
            get
                {
                return this._PS_Location_PhoneNumber;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Location.(9690));
                    this._PS_Location_PhoneNumber = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Location.(9690));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Location_IsActive
            {
            get
                {
                return this._PS_Location_IsActive;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Location.(9723));
                this._PS_Location_IsActive = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Location.(9723));
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
                 //   this.ReportPropertyChanging(DG_Location.(6537));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Location.(6537));
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
              //  this.ReportPropertyChanging(DG_Location.(6550));
                this._IsSynced = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Location.(6550));
                }
            }

        public static PS_Location CreateDG_Location ( int dG_Location_pkey, string dG_Location_Name, int dG_Store_ID, bool isSynced )
            {
            PS_Location dG_Location;
            while(true)
                {
                dG_Location = new PS_Location();
                if(5 != 0 && 8 != 0)
                    {
                    dG_Location.PS_Location_pkey = dG_Location_pkey;
                    dG_Location.PS_Location_Name = dG_Location_Name;
                    if(3 == 0)
                        {
                        return dG_Location;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            dG_Location.PS_Store_ID = dG_Store_ID;
            dG_Location.IsSynced = isSynced;
            return dG_Location;
            }

        static PS_Location ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Location));
            }

        }
    }
