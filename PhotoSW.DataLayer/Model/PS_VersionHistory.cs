using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_VersionHistory"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_VersionHistory : EntityObject
        {
        private int _PS_Version_Pkey;

        private string _PS_Version_Number;

        private DateTime? _PS_Version_Date;

        private int? _PS_UpdatedBY;

        private string _PS_Machine;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Version_Pkey
            {
            get
                {
                return this._PS_Version_Pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Version_Pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_VersionHistory.(17198));
                this._PS_Version_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_VersionHistory.(17198));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Version_Number
            {
            get
                {
                return this._PS_Version_Number;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_VersionHistory.(17219));
                    this._PS_Version_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_VersionHistory.(17219));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Version_Date
            {
            get
                {
                return this._PS_Version_Date;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_VersionHistory.(17244));
                this._PS_Version_Date = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_VersionHistory.(17244));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_UpdatedBY
            {
            get
                {
                return this._PS_UpdatedBY;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_VersionHistory.(17265));
                this._PS_UpdatedBY = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_VersionHistory.(17265));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Machine
            {
            get
                {
                return this._PS_Machine;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(DG_VersionHistory.(17282));
                    this._PS_Machine = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_VersionHistory.(17282));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static PS_VersionHistory CreateDG_VersionHistory ( int dG_Version_Pkey )
            {
            return new PS_VersionHistory
                {
                PS_Version_Pkey = dG_Version_Pkey
                };
            }

        static PS_VersionHistory ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_VersionHistory));
            }



        }
    }
