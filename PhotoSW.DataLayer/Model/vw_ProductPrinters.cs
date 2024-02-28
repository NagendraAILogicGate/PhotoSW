using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_ProductPrinters"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_ProductPrinters : EntityObject
        {
        private int _PS_Printers_Pkey;

        private string _PS_Printers_NickName;

        private string _PS_Printers_Address;

        private string _PS_Printers_DefaultName;

        private int _PS_AssociatedPrinters_ProductType_ID;

        //[NonSerialized]
        //internal static GetString ;

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
             //   this.ReportPropertyChanging(vw_ProductPrinters.(13770));
                this._PS_Printers_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_ProductPrinters.(13770));
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
               //     this.ReportPropertyChanging(vw_ProductPrinters.(13795));
                    this._PS_Printers_NickName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_ProductPrinters.(13795));
                    //        }
                    //    }
                    while(false);
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
               //     this.ReportPropertyChanging(vw_ProductPrinters.(13857));
                    this._PS_Printers_Address = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_ProductPrinters.(13857));
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
                //    this.ReportPropertyChanging(vw_ProductPrinters.(13824));
                    this._PS_Printers_DefaultName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_ProductPrinters.(13824));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_AssociatedPrinters_ProductType_ID
            {
            get
                {
                return this._PS_AssociatedPrinters_ProductType_ID;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_AssociatedPrinters_ProductType_ID == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
          //      this.ReportPropertyChanging(vw_ProductPrinters.(7681));
                this._PS_AssociatedPrinters_ProductType_ID = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
           //     this.ReportPropertyChanged(vw_ProductPrinters.(7681));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        public static vw_ProductPrinters Createvw_ProductPrinters ( int dG_Printers_Pkey, int dG_AssociatedPrinters_ProductType_ID )
            {
            return new vw_ProductPrinters
                {
                PS_Printers_Pkey = dG_Printers_Pkey,
                PS_AssociatedPrinters_ProductType_ID = dG_AssociatedPrinters_ProductType_ID
                };
            }

        static vw_ProductPrinters ()
            {
            // Note: this type is marked as 'beforefieldinit'.
        //    Strings.CreateGetStringDelegate(typeof(vw_ProductPrinters));
            }

        }
    }
