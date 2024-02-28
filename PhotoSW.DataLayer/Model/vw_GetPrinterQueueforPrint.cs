using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetPrinterQueueforPrint"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetPrinterQueueforPrint : EntityObject
        {

        private int _PS_PrinterQueue_Pkey;

        private int? _PS_Order_Details_Pkey;

        private bool? _PS_SentToPrinter;

        private string _PS_AssociatedPrinters_Name;

        private string _PS_Orders_ProductType_Name;

        private string _PS_Photos_RFID;

        private int? _PS_Associated_PrinterId;

        private int? _PS_PrinterQueue_ProductID;

        private bool? _is_Active;

        private int? _QueueIndex;

        private int _PS_Orders_ProductType_pkey;

        private string _PS_Orders_Number;

        private int? _PS_Orders_pkey;

        private int? _PS_Order_SubStoreId;

        private string _RotationAngle;

        private string _PS_PrinterQueue_Image_Pkey;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_PrinterQueue_Pkey
            {
            get
                {
                return this._PS_PrinterQueue_Pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_PrinterQueue_Pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(13407));
                this._PS_PrinterQueue_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(13407));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Order_Details_Pkey
            {
            get
                {
                return this._PS_Order_Details_Pkey;
                }
            set
                {
              //  this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(13543));
                this._PS_Order_Details_Pkey = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(13543));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_SentToPrinter
            {
            get
                {
                return this._PS_SentToPrinter;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(13572));
                this._PS_SentToPrinter = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(13572));
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
             //   this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(7564));
                IL_1D:
                this._PS_AssociatedPrinters_Name = StructuralObject.SetValidValue(value, false);
             //   this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(7564));
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
                //    this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(12198));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(12198));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_RFID
            {
            get
                {
                return this._PS_Photos_RFID;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(6251));
                    this._PS_Photos_RFID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(6251));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Associated_PrinterId
            {
            get
                {
                return this._PS_Associated_PrinterId;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(13510));
                this._PS_Associated_PrinterId = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(13510));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_PrinterQueue_ProductID
            {
            get
                {
                return this._PS_PrinterQueue_ProductID;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(13436));
                this._PS_PrinterQueue_ProductID = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(13436));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? is_Active
            {
            get
                {
                return this._is_Active;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(13597));
                this._is_Active = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(13597));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? QueueIndex
            {
            get
                {
                return this._QueueIndex;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(13610));
                this._QueueIndex = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(13610));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Orders_ProductType_pkey
            {
            get
                {
                return this._PS_Orders_ProductType_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Orders_ProductType_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
           //     this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(12161));
                this._PS_Orders_ProductType_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(12161));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_Number
            {
            get
                {
                return this._PS_Orders_Number;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(10576));
                    this._PS_Orders_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(10576));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_pkey
            {
            get
                {
                return this._PS_Orders_pkey;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(10555));
                this._PS_Orders_pkey = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(10555));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Order_SubStoreId
            {
            get
                {
                return this._PS_Order_SubStoreId;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(11623));
                this._PS_Order_SubStoreId = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(11623));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string RotationAngle
            {
            get
                {
                return this._RotationAngle;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(13669));
                    this._RotationAngle = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(13669));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_PrinterQueue_Image_Pkey
            {
            get
                {
                return this._PS_PrinterQueue_Image_Pkey;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(vw_GetPrinterQueueforPrint.(13473));
                    this._PS_PrinterQueue_Image_Pkey = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrinterQueueforPrint.(13473));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static vw_GetPrinterQueueforPrint Createvw_GetPrinterQueueforPrint ( int dG_PrinterQueue_Pkey, string dG_AssociatedPrinters_Name, int dG_Orders_ProductType_pkey )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            vw_GetPrinterQueueforPrint expr_28 = new vw_GetPrinterQueueforPrint();
            vw_GetPrinterQueueforPrint vw_GetPrinterQueueforPrint;
            if(3 != 0)
                {
                vw_GetPrinterQueueforPrint = expr_28;
                }
            vw_GetPrinterQueueforPrint.PS_PrinterQueue_Pkey = dG_PrinterQueue_Pkey;
            IL_0F:
            vw_GetPrinterQueueforPrint expr_3F = vw_GetPrinterQueueforPrint;
            if(5 != 0)
                {
                expr_3F.PS_AssociatedPrinters_Name = dG_AssociatedPrinters_Name;
                }
            if(!false)
                {
                vw_GetPrinterQueueforPrint.PS_Orders_ProductType_pkey = dG_Orders_ProductType_pkey;
                }
            IL_23:
            if(5 != 0)
                {
                return vw_GetPrinterQueueforPrint;
                }
            goto IL_0F;
            }

        static vw_GetPrinterQueueforPrint ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(vw_GetPrinterQueueforPrint));
            }

        }
    }
