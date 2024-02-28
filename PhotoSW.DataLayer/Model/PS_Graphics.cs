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
    public class PS_Graphics : EntityObject
        {

        private int _PS_Graphics_pkey;

        private string _PS_Graphics_Name;

        private string _PS_Graphics_Displayname;

        private bool? _PS_Graphics_IsActive;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Graphics_pkey
            {
            get
                {
                return this._PS_Graphics_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Graphics_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
                //this.ReportPropertyChanging(DG_Graphics.(9503));
                this._PS_Graphics_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(DG_Graphics.(9503));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Graphics_Name
            {
            get
                {
                return this._PS_Graphics_Name;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Graphics.(9528));
                    this._PS_Graphics_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Graphics.(9528));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string DG_Graphics_Displayname
            {
            get
                {
                return this._PS_Graphics_Displayname;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Graphics.(9553));
                    this._PS_Graphics_Displayname = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Graphics.(9553));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? DG_Graphics_IsActive
            {
            get
                {
                return this._PS_Graphics_IsActive;
                }
            set
                {
                //this.ReportPropertyChanging(DG_Graphics.(9586));
                this._PS_Graphics_IsActive = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(DG_Graphics.(9586));
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
                  //  this.ReportPropertyChanging(DG_Graphics.(6529));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Graphics.(6529));
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
                //this.ReportPropertyChanging(DG_Graphics.(6542));
                this._IsSynced = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Graphics.(6542));
                }
            }

        public static PS_Graphics CreateDG_Graphics ( int dG_Graphics_pkey, bool isSynced )
            {
            return new PS_Graphics
                {
                PS_Graphics_pkey = dG_Graphics_pkey,
                IsSynced = isSynced
                };
            }

        static PS_Graphics ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Graphics));
            }

        }
    }
