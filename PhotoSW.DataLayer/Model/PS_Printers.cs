using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Printers"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Printers : EntityObject
        {
        private int _PS_Printers_Pkey;

        private string _PS_Printers_NickName;

        private string _PS_Printers_DefaultName;

        private string _PS_Printers_Address;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Printers_Pkey
            {
            get
                {
                return this._PS_Printers_Pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Printers_Pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
                //this.ReportPropertyChanging(DG_Printers.(13128));
                this._PS_Printers_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_Printers.(13128));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Printers_NickName
            {
            get
                {
                return this._PS_Printers_NickName;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Printers.(13153));
                    this._PS_Printers_NickName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Printers.(13153));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Printers_DefaultName
            {
            get
                {
                return this._PS_Printers_DefaultName;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Printers.(13182));
                    this._PS_Printers_DefaultName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Printers.(13182));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Printers_Address
            {
            get
                {
                return this._PS_Printers_Address;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Printers.(13215));
                    this._PS_Printers_Address = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Printers.(13215));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static PS_Printers CreateDG_Printers ( int dG_Printers_Pkey )
            {
            return new PS_Printers
                {
                PS_Printers_Pkey = dG_Printers_Pkey
                };
            }

        static PS_Printers ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Printers));
            }

        }
    }
