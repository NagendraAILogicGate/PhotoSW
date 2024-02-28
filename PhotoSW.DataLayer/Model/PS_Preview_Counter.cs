using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Preview_Counter"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Preview_Counter : EntityObject
        {
        private int _ID;

        private int _PhotoId;

        private DateTime? _PreviewDate;

        //[NonSerialized]
        //internal static GetString ;

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
                //this.ReportPropertyChanging(DG_Preview_Counter.(12806));
                this._ID = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_Preview_Counter.(12806));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PhotoId
            {
            get
                {
                return this._PhotoId;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Preview_Counter.(5408));
                this._PhotoId = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Preview_Counter.(5408));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PreviewDate
            {
            get
                {
                return this._PreviewDate;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Preview_Counter.(12811));
                this._PreviewDate = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Preview_Counter.(12811));
                }
            }

        public static PS_Preview_Counter CreateDG_Preview_Counter ( int id, int photoId )
            {
            return new PS_Preview_Counter
                {
                ID = id,
                PhotoId = photoId
                };
            }

        static PS_Preview_Counter ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Preview_Counter));
            }


        }
    }
