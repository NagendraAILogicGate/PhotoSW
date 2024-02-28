using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "FinancialAuditTrail_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class FinancialAuditTrail_Result : EntityObject
        {
        private string _UserName;

        private string _StoreName;

        private DateTime? _StartDate;

        private DateTime? _EndDate;

        private string _OrderNumber;

        private DateTime? _OrderDate;

        private string _ProductType;

        private string _SellPrice;

        private int? _Quantity;

        private string _TotalPrice;

        private string _Discount;

        private string _revenue;

        private string _TotalOrderPrice;

        private string _PS_Order_SubStoreId;

        private string _ProductCode;

        private int? _OrderID;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string UserName
            {
            get
                {
                return this._UserName;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(FinancialAuditTrail_Result.(4439));
                    this._UserName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(FinancialAuditTrail_Result.(4439));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string StoreName
            {
            get
                {
                return this._StoreName;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(FinancialAuditTrail_Result.(4426));
                    this._StoreName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(FinancialAuditTrail_Result.(4426));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? StartDate
            {
            get
                {
                return this._StartDate;
                }
            set
                {
               // this.ReportPropertyChanging(FinancialAuditTrail_Result.(4859));
                this._StartDate = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(FinancialAuditTrail_Result.(4859));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? EndDate
            {
            get
                {
                return this._EndDate;
                }
            set
                {
               // this.ReportPropertyChanging(FinancialAuditTrail_Result.(4872));
                this._EndDate = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(FinancialAuditTrail_Result.(4872));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string OrderNumber
            {
            get
                {
                return this._OrderNumber;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(FinancialAuditTrail_Result.(5112));
                    this._OrderNumber = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(FinancialAuditTrail_Result.(5112));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? OrderDate
            {
            get
                {
                return this._OrderDate;
                }
            set
                {
             //   this.ReportPropertyChanging(FinancialAuditTrail_Result.(19176));
                this._OrderDate = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(FinancialAuditTrail_Result.(19176));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ProductType
            {
            get
                {
                return this._ProductType;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(FinancialAuditTrail_Result.(19189));
                    this._ProductType = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(FinancialAuditTrail_Result.(19189));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SellPrice
            {
            get
                {
                return this._SellPrice;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(FinancialAuditTrail_Result.(19206));
                    this._SellPrice = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(FinancialAuditTrail_Result.(19206));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? Quantity
            {
            get
                {
                return this._Quantity;
                }
            set
                {
              //  this.ReportPropertyChanging(FinancialAuditTrail_Result.(17908));
                this._Quantity = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(FinancialAuditTrail_Result.(17908));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string TotalPrice
            {
            get
                {
                return this._TotalPrice;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(FinancialAuditTrail_Result.(19219));
                    this._TotalPrice = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(FinancialAuditTrail_Result.(19219));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Discount
            {
            get
                {
                return this._Discount;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(FinancialAuditTrail_Result.(19236));
                    this._Discount = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(FinancialAuditTrail_Result.(19236));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string revenue
            {
            get
                {
                return this._revenue;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(FinancialAuditTrail_Result.(19249));
                    this._revenue = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(FinancialAuditTrail_Result.(19249));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string TotalOrderPrice
            {
            get
                {
                return this._TotalOrderPrice;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(FinancialAuditTrail_Result.(19262));
                    this._TotalOrderPrice = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(FinancialAuditTrail_Result.(19262));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string DG_Order_SubStoreId
            {
            get
                {
                return this._PS_Order_SubStoreId;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(FinancialAuditTrail_Result.(11736));
                    this._PS_Order_SubStoreId = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(FinancialAuditTrail_Result.(11736));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ProductCode
            {
            get
                {
                return this._ProductCode;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(FinancialAuditTrail_Result.(19283));
                    this._ProductCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(FinancialAuditTrail_Result.(19283));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? OrderID
            {
            get
                {
                return this._OrderID;
                }
            set
                {
              //  this.ReportPropertyChanging(FinancialAuditTrail_Result.(19300));
                this._OrderID = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(FinancialAuditTrail_Result.(19300));
                }
            }

        static FinancialAuditTrail_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(FinancialAuditTrail_Result));
            }



        }
    }
