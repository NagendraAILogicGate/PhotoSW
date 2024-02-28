using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetPrinterQueue"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetPrinterQueue : EntityObject
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

        private string _PS_Photos_ID;

        //[NonSerialized]
        //internal static GetString ;

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
              //  this.ReportPropertyChanging(vw_GetPrinterQueue.(13390));
                this._PS_PrinterQueue_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
            //    this.ReportPropertyChanged(vw_GetPrinterQueue.(13390));
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
            //    this.ReportPropertyChanging(vw_GetPrinterQueue.(13526));
                this._PS_Order_Details_Pkey = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetPrinterQueue.(13526));
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
           //     this.ReportPropertyChanging(vw_GetPrinterQueue.(13555));
                this._PS_SentToPrinter = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetPrinterQueue.(13555));
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
          //      this.ReportPropertyChanging(vw_GetPrinterQueue.(7547));
                IL_1D:
                this._PS_AssociatedPrinters_Name = StructuralObject.SetValidValue(value, false);
        //        this.ReportPropertyChanged(vw_GetPrinterQueue.(7547));
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
              //      this.ReportPropertyChanging(vw_GetPrinterQueue.(12181));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrinterQueue.(12181));
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
             //       this.ReportPropertyChanging(vw_GetPrinterQueue.(6234));
                    this._PS_Photos_RFID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrinterQueue.(6234));
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
           //     this.ReportPropertyChanging(vw_GetPrinterQueue.(13493));
                this._PS_Associated_PrinterId = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetPrinterQueue.(13493));
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
           //     this.ReportPropertyChanging(vw_GetPrinterQueue.(13419));
                this._PS_PrinterQueue_ProductID = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetPrinterQueue.(13419));
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
        //        this.ReportPropertyChanging(vw_GetPrinterQueue.(13580));
                this._is_Active = StructuralObject.SetValidValue(value);
        //        this.ReportPropertyChanged(vw_GetPrinterQueue.(13580));
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
          //      this.ReportPropertyChanging(vw_GetPrinterQueue.(13593));
                this._QueueIndex = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetPrinterQueue.(13593));
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
          //      this.ReportPropertyChanging(vw_GetPrinterQueue.(12144));
                this._PS_Orders_ProductType_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
       //         this.ReportPropertyChanged(vw_GetPrinterQueue.(12144));
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
             //       this.ReportPropertyChanging(vw_GetPrinterQueue.(10559));
                    this._PS_Orders_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrinterQueue.(10559));
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
          //      this.ReportPropertyChanging(vw_GetPrinterQueue.(10538));
                this._PS_Orders_pkey = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetPrinterQueue.(10538));
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
          //      this.ReportPropertyChanging(vw_GetPrinterQueue.(11606));
                this._PS_Order_SubStoreId = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetPrinterQueue.(11606));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_ID
            {
            get
                {
                return this._PS_Photos_ID;
                }
            set
                {
                do
                    {
             //       this.ReportPropertyChanging(vw_GetPrinterQueue.(11098));
                    this._PS_Photos_ID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPrinterQueue.(11098));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static vw_GetPrinterQueue Createvw_GetPrinterQueue ( int dG_PrinterQueue_Pkey, string dG_AssociatedPrinters_Name, int dG_Orders_ProductType_pkey )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            vw_GetPrinterQueue expr_28 = new vw_GetPrinterQueue();
            vw_GetPrinterQueue vw_GetPrinterQueue;
            if(3 != 0)
                {
                vw_GetPrinterQueue = expr_28;
                }
            vw_GetPrinterQueue.PS_PrinterQueue_Pkey = dG_PrinterQueue_Pkey;
            IL_0F:
            vw_GetPrinterQueue expr_3F = vw_GetPrinterQueue;
            if(5 != 0)
                {
                expr_3F.PS_AssociatedPrinters_Name = dG_AssociatedPrinters_Name;
                }
            if(!false)
                {
                vw_GetPrinterQueue.PS_Orders_ProductType_pkey = dG_Orders_ProductType_pkey;
                }
            IL_23:
            if(5 != 0)
                {
                return vw_GetPrinterQueue;
                }
            goto IL_0F;
            }

        static vw_GetPrinterQueue ()
            {
            // Note: this type is marked as 'beforefieldinit'.
        //    Strings.CreateGetStringDelegate(typeof(vw_GetPrinterQueue));
            }

        }
    }
