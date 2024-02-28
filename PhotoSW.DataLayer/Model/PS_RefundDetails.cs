using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_RefundDetails"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_RefundDetails : EntityObject
        {
        private int _PS_RefundDetail_ID;

        private int? _PS_LineItemId;

        private string _RefundPhotoId;

        private int? _PS_RefundMaster_ID;

        private decimal? _Refunded_Amount;

        private string _RefundReason;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_RefundDetail_ID
            {
            get
                {
                return this._PS_RefundDetail_ID;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_RefundDetail_ID == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(DG_RefundDetails.(13782));
                this._PS_RefundDetail_ID = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               /// this.ReportPropertyChanged(DG_RefundDetails.(13782));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_LineItemId
            {
            get
                {
                return this._PS_LineItemId;
                }
            set
                {
               // this.ReportPropertyChanging(DG_RefundDetails.(13807));
                this._PS_LineItemId = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_RefundDetails.(13807));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string RefundPhotoId
            {
            get
                {
                return this._RefundPhotoId;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_RefundDetails.(13828));
                    this._RefundPhotoId = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RefundDetails.(13828));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_RefundMaster_ID
            {
            get
                {
                return this._PS_RefundMaster_ID;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_RefundDetails.(13849));
                this._PS_RefundMaster_ID = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_RefundDetails.(13849));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? Refunded_Amount
            {
            get
                {
                return this._Refunded_Amount;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_RefundDetails.(13874));
                this._Refunded_Amount = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_RefundDetails.(13874));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string RefundReason
            {
            get
                {
                return this._RefundReason;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_RefundDetails.(13895));
                    this._RefundReason = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_RefundDetails.(13895));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        public static PS_RefundDetails CreateDG_RefundDetails ( int dG_RefundDetail_ID )
            {
            return new PS_RefundDetails
                {
                PS_RefundDetail_ID = dG_RefundDetail_ID
                };
            }

        static PS_RefundDetails ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_RefundDetails));
            }
        }
    }
