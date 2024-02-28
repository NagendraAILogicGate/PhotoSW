using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GetPrinterQueueDetailsByOrderNo_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GetPrinterQueueDetailsByOrderNo_Result : ComplexObject
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

        private string _PS_Photos_pKey;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_PrinterQueue_Pkey
            {
            get
                {
                return this._PS_PrinterQueue_Pkey;
                }
            set
                {
              //  this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(13640));
                this._PS_PrinterQueue_Pkey = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(13640));
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
              //  this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(13776));
                this._PS_Order_Details_Pkey = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(13776));
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
             //   this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(13805));
                this._PS_SentToPrinter = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(13805));
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
               //     this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(7797));
                    this._PS_AssociatedPrinters_Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(7797));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
                 //   this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(12431));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(12431));
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
               //     this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(6484));
                    this._PS_Photos_RFID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(6484));
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
              //  this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(13743));
                this._PS_Associated_PrinterId = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(13743));
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
             //   this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(13669));
                this._PS_PrinterQueue_ProductID = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(13669));
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
              //  this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(13830));
                this._is_Active = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(13830));
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
           //     this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(13843));
                this._QueueIndex = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(13843));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Orders_ProductType_pkey
            {
            get
                {
                return this._PS_Orders_ProductType_pkey;
                }
            set
                {
          //      this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(12394));
                this._PS_Orders_ProductType_pkey = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(12394));
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
                //    this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(10809));
                    this._PS_Orders_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(10809));
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
              //  this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(10788));
                this._PS_Orders_pkey = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(10788));
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
            //    this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(11856));
                this._PS_Order_SubStoreId = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(11856));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_pKey
            {
            get
                {
                return this._PS_Photos_pKey;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(GetPrinterQueueDetailsByOrderNo_Result.(19860));
                    this._PS_Photos_pKey = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrinterQueueDetailsByOrderNo_Result.(19860));
                    //        }
                    //    }
                  //  while(false);
                    }
                while(false);
                }
            }

        public static GetPrinterQueueDetailsByOrderNo_Result CreateGetPrinterQueueDetailsByOrderNo_Result ( int dG_PrinterQueue_Pkey, string dG_AssociatedPrinters_Name, int dG_Orders_ProductType_pkey )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            GetPrinterQueueDetailsByOrderNo_Result expr_28 = new GetPrinterQueueDetailsByOrderNo_Result();
            GetPrinterQueueDetailsByOrderNo_Result getPrinterQueueDetailsByOrderNo_Result;
            if(3 != 0)
                {
                getPrinterQueueDetailsByOrderNo_Result = expr_28;
                }
            getPrinterQueueDetailsByOrderNo_Result.PS_PrinterQueue_Pkey = dG_PrinterQueue_Pkey;
            IL_0F:
            GetPrinterQueueDetailsByOrderNo_Result expr_3F = getPrinterQueueDetailsByOrderNo_Result;
            if(5 != 0)
                {
                expr_3F.PS_AssociatedPrinters_Name = dG_AssociatedPrinters_Name;
                }
            if(!false)
                {
                getPrinterQueueDetailsByOrderNo_Result.PS_Orders_ProductType_pkey = dG_Orders_ProductType_pkey;
                }
            IL_23:
            if(5 != 0)
                {
                return getPrinterQueueDetailsByOrderNo_Result;
                }
            goto IL_0F;
            }

        static GetPrinterQueueDetailsByOrderNo_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(GetPrinterQueueDetailsByOrderNo_Result));
            }


        }
    }
