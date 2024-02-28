using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "tblprinter"), DataContract(IsReference = true)]
    [Serializable]
    public class tblprinter : EntityObject
        {
        private int _ID;

        private string _Printer1;

        private string _Printer2;

        //[NonSerialized]
        //internal static GetString ;

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
              //  this.ReportPropertyChanging(tblprinter.(13078));
                this._ID = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(tblprinter.(13078));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Printer1
            {
            get
                {
                return this._Printer1;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(tblprinter.(18308));
                    this._Printer1 = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(tblprinter.(18308));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Printer2
            {
            get
                {
                return this._Printer2;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(tblprinter.(18321));
                    this._Printer2 = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(tblprinter.(18321));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static tblprinter Createtblprinter ( int id )
            {
            return new tblprinter
                {
                ID = id
                };
            }

        static tblprinter ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(tblprinter));
            }

        }
    }
