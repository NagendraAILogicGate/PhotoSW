using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_AssociatedPrinters"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_AssociatedPrinters : EntityObject
        {
        private int _PS_AssociatedPrinters_Pkey;

        private string _PS_AssociatedPrinters_Name;

        private int _PS_AssociatedPrinters_ProductType_ID;

        private bool _PS_AssociatedPrinters_IsActive;

        private string _PS_AssociatedPrinters_PaperSize;

        private int? _PS_AssociatedPrinters_SubStoreID;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int DG_AssociatedPrinters_Pkey
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
               // this.ReportPropertyChanging(DG_AssociatedPrinters.(6662));
                this._PS_AssociatedPrinters_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_AssociatedPrinters.(6662));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PS_AssociatedPrinters_Name
            {
            get
                {
                return this._PS_AssociatedPrinters_Name;
                }
            set
                {
                do
                    {
                    //this.ReportPropertyChanging(DG_AssociatedPrinters.(6699));
                    this._PS_AssociatedPrinters_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_AssociatedPrinters.(6699));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int DG_AssociatedPrinters_ProductType_ID
            {
            get
                {
                return this._PS_AssociatedPrinters_ProductType_ID;
                }
            set
                {
              //  this.ReportPropertyChanging(PS_AssociatedPrinters.(6736));
                this._PS_AssociatedPrinters_ProductType_ID = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(PS_AssociatedPrinters.(6736));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public bool DG_AssociatedPrinters_IsActive
            {
            get
                {
                return this._PS_AssociatedPrinters_IsActive;
                }
            set
                {
               // this.ReportPropertyChanging(DG_AssociatedPrinters.(6785));
                this._PS_AssociatedPrinters_IsActive = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_AssociatedPrinters.(6785));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string DG_AssociatedPrinters_PaperSize
            {
            get
                {
                return this._PS_AssociatedPrinters_PaperSize;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_AssociatedPrinters.(6826));
                    this._PS_AssociatedPrinters_PaperSize = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_AssociatedPrinters.(6826));
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
               // this.ReportPropertyChanging(DG_AssociatedPrinters.(6871));
                this._PS_AssociatedPrinters_SubStoreID = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_AssociatedPrinters.(6871));
                }
            }

        public static PS_AssociatedPrinters CreatePS_AssociatedPrinters ( int dG_AssociatedPrinters_Pkey, string dG_AssociatedPrinters_Name, int dG_AssociatedPrinters_ProductType_ID, bool dG_AssociatedPrinters_IsActive )
            {
            PS_AssociatedPrinters dG_AssociatedPrinters;
            while(true)
                {
                dG_AssociatedPrinters = new PS_AssociatedPrinters();
                if(5 != 0 && 8 != 0)
                    {
                    dG_AssociatedPrinters.DG_AssociatedPrinters_Pkey = dG_AssociatedPrinters_Pkey;
                    dG_AssociatedPrinters.PS_AssociatedPrinters_Name = dG_AssociatedPrinters_Name;
                    if(3 == 0)
                        {
                        return dG_AssociatedPrinters;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            dG_AssociatedPrinters.DG_AssociatedPrinters_ProductType_ID = dG_AssociatedPrinters_ProductType_ID;
            dG_AssociatedPrinters.DG_AssociatedPrinters_IsActive = dG_AssociatedPrinters_IsActive;
            return dG_AssociatedPrinters;
            }

        static PS_AssociatedPrinters ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_AssociatedPrinters));
            }


        }
    }
