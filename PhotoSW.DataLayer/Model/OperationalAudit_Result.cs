using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmComplexType(NamespaceName = "DigiphotoModel", Name = "OperationalAudit_Result"), DataContract(IsReference = true)]
    [Serializable]
    public class OperationalAudit_Result : EntityObject
        {
        private int? _PS_Orders_pkey;

        private string _PS_Orders_Number;

        private string _Location;

        private string _PhotoID;

        private int? _Qty;

        private string _PhotoGrapher;

        private string _ProductType;

        private string _SubstoreName;

        private string _ProductCode;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_pkey
            {
            get
                {
                return this._PS_Orders_pkey;
                }
            set
                {
               // this.ReportPropertyChanging(OperationalAudit_Result.(10801));
                this._PS_Orders_pkey = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(OperationalAudit_Result.(10801));
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
                  //  this.ReportPropertyChanging(OperationalAudit_Result.(10822));
                    this._PS_Orders_Number = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OperationalAudit_Result.(10822));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string Location
            {
            get
                {
                return this._Location;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(OperationalAudit_Result.(19911));
                    this._Location = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OperationalAudit_Result.(19911));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
                  //  this.ReportPropertyChanging(OperationalAudit_Result.(19860));
                    this._PhotoID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OperationalAudit_Result.(19860));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? Qty
            {
            get
                {
                return this._Qty;
                }
            set
                {
               // this.ReportPropertyChanging(OperationalAudit_Result.(19446));
                this._Qty = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(OperationalAudit_Result.(19446));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string PhotoGrapher
            {
            get
                {
                return this._PhotoGrapher;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(OperationalAudit_Result.(19924));
                    this._PhotoGrapher = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OperationalAudit_Result.(19924));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
                 //   this.ReportPropertyChanging(OperationalAudit_Result.(19322));
                    this._ProductType = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OperationalAudit_Result.(19322));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SubstoreName
            {
            get
                {
                return this._SubstoreName;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(OperationalAudit_Result.(19941));
                    this._SubstoreName = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OperationalAudit_Result.(19941));
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
                  //  this.ReportPropertyChanging(OperationalAudit_Result.(19416));
                    this._ProductCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(OperationalAudit_Result.(19416));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static OperationalAudit_Result CreateOperationalAudit_Result ( string location, string photoGrapher )
            {
            return new OperationalAudit_Result
                {
                Location = location,
                PhotoGrapher = photoGrapher
                };
            }

        static OperationalAudit_Result ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(OperationalAudit_Result));
            }


        }
    }
