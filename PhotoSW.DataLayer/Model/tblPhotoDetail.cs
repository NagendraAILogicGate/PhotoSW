using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    public class tblPhotoDetail : EntityObject
        {
        private bool? _UserName;

        private int _tblId;

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? UserName
            {
            get
                {
                return this._UserName;
                }
            set
                {
                //this.ReportPropertyChanging(tblPhotoDetail.(4015));
                this._UserName = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(tblPhotoDetail.(4015));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int tblId
            {
            get
                {
                return this._tblId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._tblId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(tblPhotoDetail.(18295));
                this._tblId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(tblPhotoDetail.(18295));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        public static tblPhotoDetail CreatetblPhotoDetail ( int tblId )
            {
            return new tblPhotoDetail
                {
                tblId = tblId
                };
            }

        static tblPhotoDetail ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(tblPhotoDetail));
            }

        }
    }
