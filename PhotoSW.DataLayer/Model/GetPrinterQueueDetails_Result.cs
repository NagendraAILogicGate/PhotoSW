using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "GetPrinterQueueDetails_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class GetPrinterQueueDetails_Result : ComplexObject
        {
        private string _PS_Orders_ProductType_Name;

        private string _PS_Orders_Number;

        private string _RFID;

        private int _PS_Orders_LineItems_pkey;

        private string _PhotoID;

        //[NonSerialized]
        //internal static GetString ;

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
                   // this.ReportPropertyChanging(GetPrinterQueueDetails_Result.(12415));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrinterQueueDetails_Result.(12415));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
                   // this.ReportPropertyChanging(GetPrinterQueueDetails_Result.(10793));
                    this._PS_Orders_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrinterQueueDetails_Result.(10793));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string RFID
            {
            get
                {
                return this._RFID;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(GetPrinterQueueDetails_Result.(19822));
                    this._RFID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrinterQueueDetails_Result.(19822));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Orders_LineItems_pkey
            {
            get
                {
                return this._PS_Orders_LineItems_pkey;
                }
            set
                {
             //   this.ReportPropertyChanging(GetPrinterQueueDetails_Result.(11282));
                this._PS_Orders_LineItems_pkey = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetPrinterQueueDetails_Result.(11282));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PhotoID
            {
            get
                {
                return this._PhotoID;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(GetPrinterQueueDetails_Result.(19831));
                    this._PhotoID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(GetPrinterQueueDetails_Result.(19831));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static GetPrinterQueueDetails_Result CreateGetPrinterQueueDetails_Result ( int dG_Orders_LineItems_pkey )
            {
            return new GetPrinterQueueDetails_Result
                {
                PS_Orders_LineItems_pkey = dG_Orders_LineItems_pkey
                };
            }

        static GetPrinterQueueDetails_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(GetPrinterQueueDetails_Result));
            }


        }
    }
