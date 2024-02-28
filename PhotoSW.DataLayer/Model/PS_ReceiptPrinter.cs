using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;


namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_ReceiptPrinter"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_ReceiptPrinter : EntityObject
        {
        private int _PS_Receipt_PrinterId;

        private string _PS_Receipt_PrinterName;

        private int? _PS_SubStore_Id;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Receipt_PrinterId
            {
            get
                {
                return this._PS_Receipt_PrinterId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Receipt_PrinterId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_ReceiptPrinter.(13617));
                this._PS_Receipt_PrinterId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_ReceiptPrinter.(13617));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Receipt_PrinterName
            {
            get
                {
                return this._PS_Receipt_PrinterName;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_ReceiptPrinter.(13646));
                    this._PS_Receipt_PrinterName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_ReceiptPrinter.(13646));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_SubStore_Id
            {
            get
                {
                return this._PS_SubStore_Id;
                }
            set
                {
               // this.ReportPropertyChanging(DG_ReceiptPrinter.(13679));
                this._PS_SubStore_Id = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_ReceiptPrinter.(13679));
                }
            }

        public static PS_ReceiptPrinter CreateDG_ReceiptPrinter ( int dG_Receipt_PrinterId )
            {
            return new PS_ReceiptPrinter
                {
                PS_Receipt_PrinterId = dG_Receipt_PrinterId
                };
            }

        static PS_ReceiptPrinter ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            //Strings.CreateGetStringDelegate(typeof(DG_ReceiptPrinter));
            }

        }
    }
