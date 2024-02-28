using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_OrderBurnedItems"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_OrderBurnedItems : EntityObject
        {
        private string _PS_Orders_ProductType_Name;

        private int _PS_Orders_ProductType_pkey;

        private bool? _PS_IsAccessory;

        private string _PS_Photos_ID;

        private int _PS_Orders_LineItems_pkey;

        private bool? _PS_Photos_Burned;

        private int? _PS_Orders_ID;

        //[NonSerialized]
        //internal static GetString ;

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
                 //   this.ReportPropertyChanging(vw_OrderBurnedItems.(12272));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_OrderBurnedItems.(12272));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Orders_ProductType_pkey
            {
            get
                {
                return this._PS_Orders_ProductType_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Orders_ProductType_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(vw_OrderBurnedItems.(12235));
                this._PS_Orders_ProductType_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
          //      this.ReportPropertyChanged(vw_OrderBurnedItems.(12235));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_IsAccessory
            {
            get
                {
                return this._PS_IsAccessory;
                }
            set
                {
             //   this.ReportPropertyChanging(vw_OrderBurnedItems.(12560));
                this._PS_IsAccessory = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(vw_OrderBurnedItems.(12560));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Photos_ID
            {
            get
                {
                return this._PS_Photos_ID;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(vw_OrderBurnedItems.(11189));
                    this._PS_Photos_ID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_OrderBurnedItems.(11189));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Orders_LineItems_pkey
            {
            get
                {
                return this._PS_Orders_LineItems_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Orders_LineItems_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
          //      this.ReportPropertyChanging(vw_OrderBurnedItems.(11139));
                this._PS_Orders_LineItems_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
         //       this.ReportPropertyChanged(vw_OrderBurnedItems.(11139));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Photos_Burned
            {
            get
                {
                return this._PS_Photos_Burned;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_OrderBurnedItems.(11672));
                this._PS_Photos_Burned = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_OrderBurnedItems.(11672));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_ID
            {
            get
                {
                return this._PS_Orders_ID;
                }
            set
                {
         //       this.ReportPropertyChanging(vw_OrderBurnedItems.(11172));
                this._PS_Orders_ID = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_OrderBurnedItems.(11172));
                }
            }

        public static vw_OrderBurnedItems Createvw_OrderBurnedItems ( int dG_Orders_ProductType_pkey, int dG_Orders_LineItems_pkey )
            {
            return new vw_OrderBurnedItems
                {
                PS_Orders_ProductType_pkey = dG_Orders_ProductType_pkey,
                PS_Orders_LineItems_pkey = dG_Orders_LineItems_pkey
                };
            }

        static vw_OrderBurnedItems ()
            {
            // Note: this type is marked as 'beforefieldinit'.
        //    Strings.CreateGetStringDelegate(typeof(vw_OrderBurnedItems));
            }


        }
    }
