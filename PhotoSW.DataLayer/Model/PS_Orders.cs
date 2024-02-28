using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Orders"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Orders : EntityObject
        {
        private int _PS_Orders_pkey;

        private string _PS_Orders_Number;

        private DateTime? _PS_Orders_Date;

        private int? _PS_Albums_ID;

        private string _PS_Order_Mode;

        private int? _PS_Orders_UserID;

        private decimal? _PS_Orders_Cost;

        private decimal? _PS_Orders_NetCost;

        private int? _PS_Orders_Currency_ID;

        private string _PS_Orders_Currency_Conversion_Rate;

        private double? _PS_Orders_Total_Discount;

        private string _PS_Orders_Total_Discount_Details;

        private int? _PS_Orders_PaymentMode;

        private string _PS_Orders_PaymentDetails;

        private bool? _PS_Orders_Canceled;

        private DateTime? _PS_Orders_Canceled_Date;

        private string _PS_Orders_Canceled_Reason;

        private string _SyncCode;

        private bool _IsSynced;

        private string _InvoiceNumber;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Orders_pkey
            {
            get
                {
                return this._PS_Orders_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Orders_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(DG_Orders.(9862));
                this._PS_Orders_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_Orders.(9862));
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
                 //   this.ReportPropertyChanging(DG_Orders.(9883));
                    this._PS_Orders_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders.(9883));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Orders_Date
            {
            get
                {
                return this._PS_Orders_Date;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Orders.(9908));
                this._PS_Orders_Date = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Orders.(9908));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Albums_ID
            {
            get
                {
                return this._PS_Albums_ID;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Orders.(9929));
                this._PS_Albums_ID = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders.(9929));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Order_Mode
            {
            get
                {
                return this._PS_Order_Mode;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_Orders.(9946));
                    this._PS_Order_Mode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders.(9946));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_UserID
            {
            get
                {
                return this._PS_Orders_UserID;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Orders.(9967));
                this._PS_Orders_UserID = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Orders.(9967));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_Orders_Cost
            {
            get
                {
                return this._PS_Orders_Cost;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Orders.(9992));
                this._PS_Orders_Cost = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders.(9992));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_Orders_NetCost
            {
            get
                {
                return this._PS_Orders_NetCost;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Orders.(10013));
                this._PS_Orders_NetCost = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders.(10013));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_Currency_ID
            {
            get
                {
                return this._PS_Orders_Currency_ID;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Orders.(10038));
                this._PS_Orders_Currency_ID = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders.(10038));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_Currency_Conversion_Rate
            {
            get
                {
                return this._PS_Orders_Currency_Conversion_Rate;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Orders.(10067));
                    this._PS_Orders_Currency_Conversion_Rate = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders.(10067));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public double? PS_Orders_Total_Discount
            {
            get
                {
                return this._PS_Orders_Total_Discount;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Orders.(10116));
                this._PS_Orders_Total_Discount = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Orders.(10116));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_Total_Discount_Details
            {
            get
                {
                return this._PS_Orders_Total_Discount_Details;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_Orders.(10149));
                    this._PS_Orders_Total_Discount_Details = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders.(10149));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_PaymentMode
            {
            get
                {
                return this._PS_Orders_PaymentMode;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Orders.(10194));
                this._PS_Orders_PaymentMode = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders.(10194));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_PaymentDetails
            {
            get
                {
                return this._PS_Orders_PaymentDetails;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_Orders.(10223));
                    this._PS_Orders_PaymentDetails = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders.(10223));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Orders_Canceled
            {
            get
                {
                return this._PS_Orders_Canceled;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Orders.(10256));
                this._PS_Orders_Canceled = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Orders.(10256));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Orders_Canceled_Date
            {
            get
                {
                return this._PS_Orders_Canceled_Date;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Orders.(10281));
                this._PS_Orders_Canceled_Date = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Orders.(10281));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_Canceled_Reason
            {
            get
                {
                return this._PS_Orders_Canceled_Reason;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_Orders.(10314));
                    this._PS_Orders_Canceled_Reason = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders.(10314));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SyncCode
            {
            get
                {
                return this._SyncCode;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_Orders.(6563));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders.(6563));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public bool IsSynced
            {
            get
                {
                return this._IsSynced;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Orders.(6576));
                this._IsSynced = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Orders.(6576));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string InvoiceNumber
            {
            get
                {
                return this._InvoiceNumber;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(DG_Orders.(10351));
                    this._InvoiceNumber = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders.(10351));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static PS_Orders CreatePS_Orders ( int dG_Orders_pkey, bool isSynced )
            {
            return new PS_Orders
                {
                PS_Orders_pkey = dG_Orders_pkey,
                IsSynced = isSynced
                };
            }

        static PS_Orders ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_Orders));
            }


        }
    }
