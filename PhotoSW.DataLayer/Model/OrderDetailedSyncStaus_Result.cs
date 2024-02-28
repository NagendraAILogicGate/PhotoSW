using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "OrderDetailedSyncStaus_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class OrderDetailedSyncStaus_Result : EntityObject
        {
        private DateTime? _PS_Orders_Date;

        private int _PS_Orders_pkey;

        private string _PS_Orders_Number;

        private string _PhotNumber;

        private int _SyncStatus;

        private DateTime? _SyncDate;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? DG_Orders_Date
            {
            get
                {
                return this._PS_Orders_Date;
                }
            set
                {
              //  this.ReportPropertyChanging(OrderDetailedSyncStaus_Result.(10894));
                this._PS_Orders_Date = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(OrderDetailedSyncStaus_Result.(10894));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_Orders_pkey
            {
            get
                {
                return this._PS_Orders_pkey;
                }
            set
                {
             //   this.ReportPropertyChanging(OrderDetailedSyncStaus_Result.(10848));
                this._PS_Orders_pkey = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(OrderDetailedSyncStaus_Result.(10848));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string DG_Orders_Number
            {
            get
                {
                return this._PS_Orders_Number;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(OrderDetailedSyncStaus_Result.(10869));
                    this._PS_Orders_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OrderDetailedSyncStaus_Result.(10869));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PhotNumber
            {
            get
                {
                return this._PhotNumber;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(OrderDetailedSyncStaus_Result.(20163));
                    this._PhotNumber = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OrderDetailedSyncStaus_Result.(20163));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int SyncStatus
            {
            get
                {
                return this._SyncStatus;
                }
            set
                {
             //   this.ReportPropertyChanging(OrderDetailedSyncStaus_Result.(7123));
                this._SyncStatus = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(OrderDetailedSyncStaus_Result.(7123));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? SyncDate
            {
            get
                {
                return this._SyncDate;
                }
            set
                {
             //   this.ReportPropertyChanging(OrderDetailedSyncStaus_Result.(7157));
                this._SyncDate = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(OrderDetailedSyncStaus_Result.(7157));
                }
            }

        public static OrderDetailedSyncStaus_Result CreateOrderDetailedSyncStaus_Result ( int dG_Orders_pkey, int syncStatus )
            {
            return new OrderDetailedSyncStaus_Result
                {
                PS_Orders_pkey = dG_Orders_pkey,
                SyncStatus = syncStatus
                };
            }

        static OrderDetailedSyncStaus_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(OrderDetailedSyncStaus_Result));
            }


        }
    }
