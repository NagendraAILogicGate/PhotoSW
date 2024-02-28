using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_Refund"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Refund : EntityObject
        {
        private int _PS_RefundId;

        private int? _PS_OrderId;

        private decimal? _RefundAmount;

        private DateTime? _RefundDate;

        private int? _UserId;

        private int? _Refund_Mode;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_RefundId
            {
            get
                {
                return this._PS_RefundId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_RefundId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
                //this.ReportPropertyChanging(DG_Refund.(13707));
                this._PS_RefundId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
                //.ReportPropertyChanged(DG_Refund.(13707));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_OrderId
            {
            get
                {
                return this._PS_OrderId;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Refund.(9221));
                this._PS_OrderId = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(DG_Refund.(9221));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? RefundAmount
            {
            get
                {
                return this._RefundAmount;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Refund.(13724));
                this._RefundAmount = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Refund.(13724));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? RefundDate
            {
            get
                {
                return this._RefundDate;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Refund.(13741));
                this._RefundDate = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Refund.(13741));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? UserId
            {
            get
                {
                return this._UserId;
                }
            set
                {
                //this.ReportPropertyChanging(DG_Refund.(3549));
                this._UserId = StructuralObject.SetValidValue(value);
                //this.ReportPropertyChanged(DG_Refund.(3549));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? Refund_Mode
            {
            get
                {
                return this._Refund_Mode;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Refund.(13758));
                this._Refund_Mode = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Refund.(13758));
                }
            }

        public static PS_Refund CreateDG_Refund ( int dG_RefundId )
            {
            return new PS_Refund
                {
                PS_RefundId = dG_RefundId
                };
            }

        static PS_Refund ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            //Strings.CreateGetStringDelegate(typeof(DG_Refund));
            }

        }
    }
