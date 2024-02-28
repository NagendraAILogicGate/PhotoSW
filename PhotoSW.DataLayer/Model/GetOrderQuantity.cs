using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "GetOrderQuantity"), DataContract(IsReference = true)]
    [Serializable]
    public class GetOrderQuantity : EntityObject
        {
        private int _PS_Orders_pkey;

        private long? _Quantity;

        //[NonSerialized]
        //internal static GetString ;

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
               // this.ReportPropertyChanging(GetOrderQuantity.(10191));
                this._PS_Orders_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(GetOrderQuantity.(10191));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public long? Quantity
            {
            get
                {
                return this._Quantity;
                }
            set
                {
             //   this.ReportPropertyChanging(GetOrderQuantity.(17431));
                this._Quantity = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(GetOrderQuantity.(17431));
                }
            }

        public static GetOrderQuantity CreateGetOrderQuantity ( int dG_Orders_pkey )
            {
            return new GetOrderQuantity
                {
                PS_Orders_pkey = dG_Orders_pkey
                };
            }

        static GetOrderQuantity ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            //Strings.CreateGetStringDelegate(typeof(GetOrderQuantity));
            }

        }
    }
