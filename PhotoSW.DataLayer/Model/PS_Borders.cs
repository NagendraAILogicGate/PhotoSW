using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_Borders"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Borders : EntityObject
        {
        private int _PS_Borders_pkey;

        private string _PS_Border;

        private int _PS_ProductTypeID;

        private bool _PS_IsActive;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Borders_pkey
            {
            get
                {
                return this._PS_Borders_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Borders_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(DG_Borders.(7163));
                this._PS_Borders_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_Borders.(7163));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Border
            {
            get
                {
                return this._PS_Border;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Borders.(7184));
                    this._PS_Border = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Borders.(7184));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_ProductTypeID
            {
            get
                {
                return this._PS_ProductTypeID;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Borders.(7197));
                this._PS_ProductTypeID = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(DG_Borders.(7197));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public bool PS_IsActive
            {
            get
                {
                return this._PS_IsActive;
                }
            set
                {
                //this.ReportPropertyChanging(DG_Borders.(7222));
                this._PS_IsActive = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(DG_Borders.(7222));
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
                   // this.ReportPropertyChanging(DG_Borders.(6410));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Borders.(6410));
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
               // this.ReportPropertyChanging(DG_Borders.(6423));
                this._IsSynced = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Borders.(6423));
                }
            }

        public static PS_Borders CreatePS_Borders ( int dG_Borders_pkey, string dG_Border, int dG_ProductTypeID, bool dG_IsActive, bool isSynced )
            {
            PS_Borders dG_Borders;
            if(true)
                {
                dG_Borders = new PS_Borders();
                do
                    {
                    dG_Borders.PS_Borders_pkey = dG_Borders_pkey;
                    }
                while(false);
                if(6 == 0)
                    {
                    return dG_Borders;
                    }
                dG_Borders.PS_Border = dG_Border;
                dG_Borders.PS_ProductTypeID = dG_ProductTypeID;
                }
            dG_Borders.PS_IsActive = dG_IsActive;
            dG_Borders.IsSynced = isSynced;
            return dG_Borders;
            }

        static PS_Borders ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(PS_Borders));
            }

        }
    }
