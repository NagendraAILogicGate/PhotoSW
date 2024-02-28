using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Currency"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Currency : EntityObject
        {
        private int _PS_Currency_pkey;

        private string _PS_Currency_Name;

        private double _PS_Currency_Rate;

        private string _PS_Currency_Symbol;

        private DateTime? _PS_Currency_UpdatedDate;

        private int? _PS_Currency_ModifiedBy;

        private bool? _PS_Currency_Default;

        private string _PS_Currency_Icon;

        private string _PS_Currency_Code;

        private bool? _PS_Currency_IsActive;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Currency_pkey
            {
            get
                {
                return this._PS_Currency_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Currency_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(DG_Currency.(8704));
                this._PS_Currency_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_Currency.(8704));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Currency_Name
            {
            get
                {
                return this._PS_Currency_Name;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_Currency.(8729));
                    this._PS_Currency_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Currency.(8729));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public double PS_Currency_Rate
            {
            get
                {
                return this._PS_Currency_Rate;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Currency.(8754));
                this._PS_Currency_Rate = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Currency.(8754));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Currency_Symbol
            {
            get
                {
                return this._PS_Currency_Symbol;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_Currency.(8779));
                    this._PS_Currency_Symbol = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Currency.(8779));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Currency_UpdatedDate
            {
            get
                {
                return this._PS_Currency_UpdatedDate;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Currency.(8804));
                this._PS_Currency_UpdatedDate = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Currency.(8804));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Currency_ModifiedBy
            {
            get
                {
                return this._PS_Currency_ModifiedBy;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Currency.(8837));
                this._PS_Currency_ModifiedBy = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(DG_Currency.(8837));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Currency_Default
            {
            get
                {
                return this._PS_Currency_Default;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Currency.(8870));
                this._PS_Currency_Default = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Currency.(8870));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Currency_Icon
            {
            get
                {
                return this._PS_Currency_Icon;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_Currency.(8899));
                    this._PS_Currency_Icon = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Currency.(8899));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Currency_Code
            {
            get
                {
                return this._PS_Currency_Code;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Currency.(8924));
                    this._PS_Currency_Code = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Currency.(8924));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Currency_IsActive
            {
            get
                {
                return this._PS_Currency_IsActive;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Currency.(8949));
                this._PS_Currency_IsActive = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Currency.(8949));
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
                //    this.ReportPropertyChanging(DG_Currency.(6498));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Currency.(6498));
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
              //  this.ReportPropertyChanging(DG_Currency.(6511));
                this._IsSynced = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Currency.(6511));
                }
            }

        public static PS_Currency CreateDG_Currency ( int dG_Currency_pkey, string dG_Currency_Name, double dG_Currency_Rate, bool isSynced )
            {
            PS_Currency dG_Currency;
            while(true)
                {
                dG_Currency = new PS_Currency();
                if(5 != 0 && 8 != 0)
                    {
                    dG_Currency.PS_Currency_pkey = dG_Currency_pkey;
                    dG_Currency.PS_Currency_Name = dG_Currency_Name;
                    if(3 == 0)
                        {
                        return dG_Currency;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            dG_Currency.PS_Currency_Rate = dG_Currency_Rate;
            dG_Currency.IsSynced = isSynced;
            return dG_Currency;
            }

        static PS_Currency ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Currency));
            }


        }
    }
