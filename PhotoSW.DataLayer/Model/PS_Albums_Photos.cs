using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_Albums_Photos"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Albums_Photos : EntityObject
        {
        private int _PS_Albums_Photos_pkey;

        private int? _PS_Albums_pkey;

        private int? _PS_Photos_pkey;

        private DateTime? _PS_Albums_Photos_CreatedOn;

        private int? _PS_Albums_Photos_CreatedBy;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Albums_Photos_pkey
            {
            get
                {
                return this._PS_Albums_Photos_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Albums_Photos_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(DG_Albums_Photos.(6507));
                this._PS_Albums_Photos_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(DG_Albums_Photos.(6507));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Albums_pkey
            {
            get
                {
                return this._PS_Albums_pkey;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Albums_Photos.(6407));
                this._PS_Albums_pkey = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Albums_Photos.(6407));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Photos_pkey
            {
            get
                {
                return this._PS_Photos_pkey;
                }
            set
                {
            //    this.ReportPropertyChanging(DG_Albums_Photos.(5301));
                this._PS_Photos_pkey = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Albums_Photos.(5301));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Albums_Photos_CreatedOn
            {
            get
                {
                return this._PS_Albums_Photos_CreatedOn;
                }
            set
                {
            //    this.ReportPropertyChanging(DG_Albums_Photos.(6536));
                this._PS_Albums_Photos_CreatedOn = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(DG_Albums_Photos.(6536));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Albums_Photos_CreatedBy
            {
            get
                {
                return this._PS_Albums_Photos_CreatedBy;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Albums_Photos.(6573));
                this._PS_Albums_Photos_CreatedBy = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Albums_Photos.(6573));
                }
            }

        public static PS_Albums_Photos CreateDG_Albums_Photos ( int dG_Albums_Photos_pkey )
            {
            return new PS_Albums_Photos
                {
                PS_Albums_Photos_pkey = dG_Albums_Photos_pkey
                };
            }

        static PS_Albums_Photos ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(DG_Albums_Photos));
            }


        }
    }
