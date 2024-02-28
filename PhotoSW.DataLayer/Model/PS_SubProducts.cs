using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_SubProducts"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_SubProducts : EntityObject
        {
        private int _id;

        private int _DG_Orders_ProductType_pkey;

        private int _Child_DG_Orders_ProductType_pkey;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int id
            {
            get
                {
                return this._id;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._id == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(PS_SubProducts.(16597));
                this._id = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
                //this.ReportPropertyChanged(PS_SubProducts.(16597));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int DG_Orders_ProductType_pkey
            {
            get
                {
                return this._DG_Orders_ProductType_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._DG_Orders_ProductType_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(PS_SubProducts.(11743));
                this._DG_Orders_ProductType_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(PS_SubProducts.(11743));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int Child_DG_Orders_ProductType_pkey
            {
            get
                {
                return this._Child_DG_Orders_ProductType_pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._Child_DG_Orders_ProductType_pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
             //   this.ReportPropertyChanging(DG_SubProducts.(16602));
                this._Child_DG_Orders_ProductType_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_SubProducts.(16602));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        public static PS_SubProducts CreateDG_SubProducts ( int id, int dG_Orders_ProductType_pkey, int child_DG_Orders_ProductType_pkey )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            PS_SubProducts expr_28 = new PS_SubProducts();
            PS_SubProducts dG_SubProducts;
            if(3 != 0)
                {
                dG_SubProducts = expr_28;
                }
            dG_SubProducts.id = id;
            IL_0F:
            PS_SubProducts expr_3F = dG_SubProducts;
            if(5 != 0)
                {
                expr_3F.DG_Orders_ProductType_pkey = dG_Orders_ProductType_pkey;
                }
            if(!false)
                {
                dG_SubProducts.Child_DG_Orders_ProductType_pkey = child_DG_Orders_ProductType_pkey;
                }
            IL_23:
            if(5 != 0)
                {
                return dG_SubProducts;
                }
            goto IL_0F;
            }

        static PS_SubProducts ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_SubProducts));
            }


        }
    }
