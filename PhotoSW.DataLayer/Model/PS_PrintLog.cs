using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_PrintLog"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_PrintLog : EntityObject
        {
        private int _ID;

        private int? _PhotoId;

        private DateTime? _PrintTime;

        private int? _ProductTypeId;

        private int? _UserID;

        //NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int ID
            {
            get
                {
                return this._ID;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._ID == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_PrintLog.(12829));
                this._ID = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_PrintLog.(12829));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PhotoId
            {
            get
                {
                return this._PhotoId;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PrintLog.(5431));
                this._PhotoId = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_PrintLog.(5431));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PrintTime
            {
            get
                {
                return this._PrintTime;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PrintLog.(13250));
                this._PrintTime = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_PrintLog.(13250));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? ProductTypeId
            {
            get
                {
                return this._ProductTypeId;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_PrintLog.(13263));
                this._ProductTypeId = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_PrintLog.(13263));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? UserID
            {
            get
                {
                return this._UserID;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PrintLog.(3593));
                this._UserID = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_PrintLog.(3593));
                }
            }

        public static PS_PrintLog CreateDG_PrintLog ( int id )
            {
            return new PS_PrintLog
                {
                ID = id
                };
            }

        static PS_PrintLog ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_PrintLog));
            }

        }
    }
