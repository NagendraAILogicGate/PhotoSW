using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetPrinterDetails"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetPrinterDetails : EntityObject
        {
        private int _PS_AssociatedPrinters_Pkey;

        private string _PS_AssociatedPrinters_Name;

        private int _PS_AssociatedPrinters_ProductType_ID;

        private bool _PS_AssociatedPrinters_IsActive;

        private string _PS_Orders_ProductType_Name;

        private string _PS_AssociatedPrinters_PaperSize;

        private int? _PS_AssociatedPrinters_SubStoreID;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_AssociatedPrinters_Pkey
            {
            get
                {
                return this._PS_AssociatedPrinters_Pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_AssociatedPrinters_Pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
             //   this.ReportPropertyChanging(vw_GetPrinterDetails.(7494));
                this._PS_AssociatedPrinters_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(vw_GetPrinterDetails.(7494));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public string PS_AssociatedPrinters_Name
            {
            get
                {
                return this._PS_AssociatedPrinters_Name;
                }
            set
                {
                if(!(this._PS_AssociatedPrinters_Name != value))
                    {
                    goto IL_3E;
                    }
                IL_0D:
            //    this.ReportPropertyChanging(vw_GetPrinterDetails.(7531));
                IL_1D:
                this._PS_AssociatedPrinters_Name = StructuralObject.SetValidValue(value, false);
          //      this.ReportPropertyChanged(vw_GetPrinterDetails.(7531));
                IL_3E:
                if(false)
                    {
                    goto IL_0D;
                    }
                if(!false)
                    {
                    return;
                    }
                goto IL_1D;
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
            //    this.ReportPropertyChanging(vw_GetPrinterDetails.(7568));
                this._PS_AssociatedPrinters_ProductType_ID = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetPrinterDetails.(7568));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public bool PS_AssociatedPrinters_IsActive
            {
            get
                {
                return this._PS_AssociatedPrinters_IsActive;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_AssociatedPrinters_IsActive == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
            //    this.ReportPropertyChanging(vw_GetPrinterDetails.(7617));
                this._PS_AssociatedPrinters_IsActive = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
           //     this.ReportPropertyChanged(vw_GetPrinterDetails.(7617));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_ProductType_Name
            {
            get
                {
                return this._PS_Orders_ProductType_Name;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_GetPrinterDetails.(12165));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrinterDetails.(12165));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_AssociatedPrinters_PaperSize
            {
            get
                {
                return this._PS_AssociatedPrinters_PaperSize;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_GetPrinterDetails.(7658));
                    this._PS_AssociatedPrinters_PaperSize = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrinterDetails.(7658));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_AssociatedPrinters_SubStoreID
            {
            get
                {
                return this._PS_AssociatedPrinters_SubStoreID;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetPrinterDetails.(7703));
                this._PS_AssociatedPrinters_SubStoreID = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetPrinterDetails.(7703));
                }
            }

        public static vw_GetPrinterDetails Createvw_GetPrinterDetails ( int dG_AssociatedPrinters_Pkey, string dG_AssociatedPrinters_Name, int dG_AssociatedPrinters_ProductType_ID, bool dG_AssociatedPrinters_IsActive )
            {
            vw_GetPrinterDetails vw_GetPrinterDetails;
            while(true)
                {
                vw_GetPrinterDetails = new vw_GetPrinterDetails();
                if(5 != 0 && 8 != 0)
                    {
                    vw_GetPrinterDetails.PS_AssociatedPrinters_Pkey = dG_AssociatedPrinters_Pkey;
                    vw_GetPrinterDetails.PS_AssociatedPrinters_Name = dG_AssociatedPrinters_Name;
                    if(3 == 0)
                        {
                        return vw_GetPrinterDetails;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            vw_GetPrinterDetails.PS_AssociatedPrinters_ProductType_ID = dG_AssociatedPrinters_ProductType_ID;
            vw_GetPrinterDetails.PS_AssociatedPrinters_IsActive = dG_AssociatedPrinters_IsActive;
            return vw_GetPrinterDetails;
            }

        static vw_GetPrinterDetails ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(vw_GetPrinterDetails));
            }


        }
    }
