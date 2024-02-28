using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_PhotoNumberConfiguration"), DataContract(IsReference = true)]
    [Serializable]
     public class PS_PhotoNumberConfiguration : EntityObject
        {
        private int _PS_PhotoSequence_pkey;

        private string _PS_WifiName;

        private decimal? _PS_StartingNumber;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_PhotoSequence_pkey
            {
            get
                {
                return this._PS_PhotoSequence_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_PhotoSequence_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_PhotoNumberConfiguration.(12437));
                this._PS_PhotoSequence_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_PhotoNumberConfiguration.(12437));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_WifiName
            {
            get
                {
                return this._PS_WifiName;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_PhotoNumberConfiguration.(12466));
                    this._PS_WifiName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_PhotoNumberConfiguration.(12466));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? DG_StartingNumber
            {
            get
                {
                return this._PS_StartingNumber;
                }
            set
                {
               // this.ReportPropertyChanging(DG_PhotoNumberConfiguration.(12483));
                this._PS_StartingNumber = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_PhotoNumberConfiguration.(12483));
                }
            }

        public static PS_PhotoNumberConfiguration CreateDG_PhotoNumberConfiguration ( int dG_PhotoSequence_pkey )
            {
            return new PS_PhotoNumberConfiguration
                {
                PS_PhotoSequence_pkey = dG_PhotoSequence_pkey
                };
            }

        static PS_PhotoNumberConfiguration ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(DG_PhotoNumberConfiguration));
            }

        }
    }
