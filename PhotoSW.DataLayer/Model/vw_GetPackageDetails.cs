using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "vw_GetPackageDetails"), DataContract(IsReference = true)]
    [Serializable]
    public class vw_GetPackageDetails : EntityObject
        {
        private int _PS_Package_Details_Pkey;

        private int _PS_ProductTypeId;

        private int _PS_PackageId;

        private int? _PS_Product_Quantity;

        private int _PS_Orders_ProductType_pkey;

        private string _PS_Orders_ProductType_Name;

        private int? _PS_Product_MaxImage;

        private bool? _PS_Orders_ProductType_IsBundled;

        private bool? _PS_IsAccessory;

        private bool? _PS_IsActive;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_Package_Details_Pkey
            {
            get
                {
                return this._PS_Package_Details_Pkey;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_Package_Details_Pkey == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(vw_GetPackageDetails.(12522));
                this._PS_Package_Details_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(vw_GetPackageDetails.(12522));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_ProductTypeId
            {
            get
                {
                return this._PS_ProductTypeId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_ProductTypeId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
             //   this.ReportPropertyChanging(vw_GetPackageDetails.(12555));
                this._PS_ProductTypeId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(vw_GetPackageDetails.(12555));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int PS_PackageId
            {
            get
                {
                return this._PS_PackageId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PS_PackageId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
            //    this.ReportPropertyChanging(vw_GetPackageDetails.(12580));
                this._PS_PackageId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(vw_GetPackageDetails.(12580));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Product_Quantity
            {
            get
                {
                return this._PS_Product_Quantity;
                }
            set
                {
          //      this.ReportPropertyChanging(vw_GetPackageDetails.(12597));
                this._PS_Product_Quantity = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetPackageDetails.(12597));
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
            //    this.ReportPropertyChanging(vw_GetPackageDetails.(12080));
                this._PS_Orders_ProductType_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
           //     this.ReportPropertyChanged(vw_GetPackageDetails.(12080));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

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
               //     this.ReportPropertyChanging(vw_GetPackageDetails.(12117));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(vw_GetPackageDetails.(12117));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Product_MaxImage
            {
            get
                {
                return this._PS_Product_MaxImage;
                }
            set
                {
            //    this.ReportPropertyChanging(vw_GetPackageDetails.(12626));
                this._PS_Product_MaxImage = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(vw_GetPackageDetails.(12626));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Orders_ProductType_IsBundled
            {
            get
                {
                return this._PS_Orders_ProductType_IsBundled;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetPackageDetails.(12191));
                this._PS_Orders_ProductType_IsBundled = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetPackageDetails.(12191));
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
          //      this.ReportPropertyChanging(vw_GetPackageDetails.(12405));
                this._PS_IsAccessory = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(vw_GetPackageDetails.(12405));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_IsActive
            {
            get
                {
                return this._PS_IsActive;
                }
            set
                {
           //     this.ReportPropertyChanging(vw_GetPackageDetails.(7987));
                this._PS_IsActive = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(vw_GetPackageDetails.(7987));
                }
            }

        public static vw_GetPackageDetails Createvw_GetPackageDetails ( int dG_Package_Details_Pkey, int dG_ProductTypeId, int dG_PackageId, int dG_Orders_ProductType_pkey )
            {
            vw_GetPackageDetails vw_GetPackageDetails;
            while(true)
                {
                vw_GetPackageDetails = new vw_GetPackageDetails();
                if(5 != 0 && 8 != 0)
                    {
                    vw_GetPackageDetails.PS_Package_Details_Pkey = dG_Package_Details_Pkey;
                    vw_GetPackageDetails.PS_ProductTypeId = dG_ProductTypeId;
                    if(3 == 0)
                        {
                        return vw_GetPackageDetails;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            vw_GetPackageDetails.PS_PackageId = dG_PackageId;
            vw_GetPackageDetails.PS_Orders_ProductType_pkey = dG_Orders_ProductType_pkey;
            return vw_GetPackageDetails;
            }

        static vw_GetPackageDetails ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(vw_GetPackageDetails));
            }

        }
    }
