using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_Bill_Format"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Bill_Format : EntityObject
        {
        private int _PS_Bill_Format_pkey;

        private int? _PS_Bill_Type;

        private string _PS_Refund_Slogan;

        //[NonSerialized]
        //internal static GetString ;

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Bill_Format_pkey
            {
            get
                {
                return this._PS_Bill_Format_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Bill_Format_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
                //this.ReportPropertyChanging(DG_Bill_Format.(7085));
                this._PS_Bill_Format_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_Bill_Format.(7085));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? DG_Bill_Type
            {
            get
                {
                return this._PS_Bill_Type;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Bill_Format.(7114));
                this._PS_Bill_Type = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Bill_Format.(7114));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Refund_Slogan
            {
            get
                {
                return this._PS_Refund_Slogan;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Bill_Format.(7131));
                    this._PS_Refund_Slogan = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Bill_Format.(7131));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static PS_Bill_Format CreateDG_Bill_Format ( int dG_Bill_Format_pkey )
            {
            return new PS_Bill_Format
                {
                PS_Bill_Format_pkey = dG_Bill_Format_pkey
                };
            }

        static PS_Bill_Format ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Bill_Format));
            }


        }
    }
