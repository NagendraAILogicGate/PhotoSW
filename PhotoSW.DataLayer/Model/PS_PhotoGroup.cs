using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_PhotoGroup"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_PhotoGroup : EntityObject
        {

        private long _PS_Group_pkey;

        private string _PS_Group_Name;

        private int? _PS_Photo_ID;

        private string _PS_Photo_RFID;

        private DateTime? _PS_CreatedDate;

        private int? _PS_SubstoreId;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public long PS_Group_pkey
            {
            get
                {
                return this._PS_Group_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Group_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_PhotoGroup.(12311));
                this._PS_Group_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_PhotoGroup.(12311));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_Group_Name
            {
            get
                {
                return this._PS_Group_Name;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_PhotoGroup.(12332));
                    this._PS_Group_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_PhotoGroup.(12332));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Photo_ID
            {
            get
                {
                return this._PS_Photo_ID;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PhotoGroup.(12353));
                this._PS_Photo_ID = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_PhotoGroup.(12353));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photo_RFID
            {
            get
                {
                return this._PS_Photo_RFID;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_PhotoGroup.(12370));
                    this._PS_Photo_RFID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_PhotoGroup.(12370));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_CreatedDate
            {
            get
                {
                return this._PS_CreatedDate;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PhotoGroup.(12391));
                this._PS_CreatedDate = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_PhotoGroup.(12391));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_SubstoreId
            {
            get
                {
                return this._PS_SubstoreId;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PhotoGroup.(12412));
                this._PS_SubstoreId = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_PhotoGroup.(12412));
                }
            }

        public static PS_PhotoGroup CreateDG_PhotoGroup ( long dG_Group_pkey, string dG_Group_Name )
            {
            return new PS_PhotoGroup
                {
                PS_Group_pkey = dG_Group_pkey,
                PS_Group_Name = dG_Group_Name
                };
            }

        static PS_PhotoGroup ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_PhotoGroup));
            }

        }
    }
