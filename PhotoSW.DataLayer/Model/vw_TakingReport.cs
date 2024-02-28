using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
	[EdmEntityType(NamespaceName = "PhotoSWModel", Name = "vw_TakingReport"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_TakingReport : EntityObject
        {

        private string _selectedSubStore;

        private DateTime? _FromDate;

        private DateTime? _Todate;

        private string _PS_Orders_Number;

        private DateTime? _PS_Orders_Date;

        private string _PS_Orders_PaymentMode;

        private string _PS_Orders_Currency_ID;

        private decimal? _NetCost;

        private string _ItemDetail;

        private int _State;

        private int _PS_Orders_pkey;

        private string _s1;

        private string _PS_SubStore_Name;

        private string _ItemCode;

        private string _InvoiceNumber;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string selectedSubStore
            {
            get
                {
                return this._selectedSubStore;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(vw_TakingReport.(19068));
                    this._selectedSubStore = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_TakingReport.(19068));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? FromDate
            {
            get
                {
                return this._FromDate;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_TakingReport.(4159));
                this._FromDate = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_TakingReport.(4159));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? Todate
            {
            get
                {
                return this._Todate;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_TakingReport.(19093));
                this._Todate = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_TakingReport.(19093));
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
                //    this.ReportPropertyChanging(vw_TakingReport.(10672));
                    this._PS_Orders_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_TakingReport.(10672));
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
         //       this.ReportPropertyChanging(vw_TakingReport.(10697));
                this._PS_Orders_Date = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_TakingReport.(10697));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_PaymentMode
            {
            get
                {
                return this._PS_Orders_PaymentMode;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_TakingReport.(10983));
                    this._PS_Orders_PaymentMode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_TakingReport.(10983));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_Currency_ID
            {
            get
                {
                return this._PS_Orders_Currency_ID;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(vw_TakingReport.(10827));
                    this._PS_Orders_Currency_ID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_TakingReport.(10827));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? NetCost
            {
            get
                {
                return this._NetCost;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_TakingReport.(19102));
                this._NetCost = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_TakingReport.(19102));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ItemDetail
            {
            get
                {
                return this._ItemDetail;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_TakingReport.(19115));
                    this._ItemDetail = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_TakingReport.(19115));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int State
            {
            get
                {
                return this._State;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._State == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
            //    this.ReportPropertyChanging(vw_TakingReport.(19132));
                this._State = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
          //      this.ReportPropertyChanged(vw_TakingReport.(19132));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

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
          //      this.ReportPropertyChanging(vw_TakingReport.(10651));
                this._PS_Orders_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
       //         this.ReportPropertyChanged(vw_TakingReport.(10651));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string s1
            {
            get
                {
                return this._s1;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(vw_TakingReport.(19141));
                    this._s1 = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_TakingReport.(19141));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_SubStore_Name
            {
            get
                {
                return this._PS_SubStore_Name;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(vw_TakingReport.(17265));
                    this._PS_SubStore_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_TakingReport.(17265));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string ItemCode
            {
            get
                {
                return this._ItemCode;
                }
            set
                {
                do
                    {
               //     this.ReportPropertyChanging(vw_TakingReport.(19146));
                    this._ItemCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_TakingReport.(19146));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
              //      this.ReportPropertyChanging(vw_TakingReport.(11140));
                    this._InvoiceNumber = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_TakingReport.(11140));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static vw_TakingReport Createvw_TakingReport ( int state, int dG_Orders_pkey )
            {
            return new vw_TakingReport
                {
                State = state,
                PS_Orders_pkey = dG_Orders_pkey
                };
            }

        static vw_TakingReport ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(vw_TakingReport));
            }

        }
    }
