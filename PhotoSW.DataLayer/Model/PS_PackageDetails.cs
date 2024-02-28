using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PS_PackageDetails"), DataContract(IsReference = true)]
    [Serializable]
     public class PS_PackageDetails : EntityObject
        {

        private int _PS_Package_Details_Pkey;

        private int _PS_ProductTypeId;

        private int _PS_PackageId;

        private int? _PS_Product_Quantity;

        private int? _PS_Product_MaxImage;

        private string _SyncCode;

        private bool _IsSynced;

       // [NonSerialized]
        //internal static GetString ;

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
              //  this.ReportPropertyChanging(DG_PackageDetails.(11968));
                this._PS_Package_Details_Pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
                //this.ReportPropertyChanged(DG_PackageDetails.(11968));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_ProductTypeId
            {
            get
                {
                return this._PS_ProductTypeId;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_PackageDetails.(12001));
                this._PS_ProductTypeId = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_PackageDetails.(12001));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_PackageId
            {
            get
                {
                return this._PS_PackageId;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_PackageDetails.(12026));
                this._PS_PackageId = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_PackageDetails.(12026));
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
              //  this.ReportPropertyChanging(DG_PackageDetails.(12043));
                this._PS_Product_Quantity = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_PackageDetails.(12043));
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
              //  this.ReportPropertyChanging(DG_PackageDetails.(12072));
                this._PS_Product_MaxImage = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_PackageDetails.(12072));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string SyncCode
            {
            get
                {
                return this._SyncCode;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_PackageDetails.(6621));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_PackageDetails.(6621));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public bool IsSynced
            {
            get
                {
                return this._IsSynced;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_PackageDetails.(6634));
                this._IsSynced = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_PackageDetails.(6634));
                }
            }

        public static PS_PackageDetails CreateDG_PackageDetails ( int dG_Package_Details_Pkey, int dG_ProductTypeId, int dG_PackageId, bool isSynced )
            {
            PS_PackageDetails dG_PackageDetails;
            while(true)
                {
                dG_PackageDetails = new PS_PackageDetails();
                if(5 != 0 && 8 != 0)
                    {
                    dG_PackageDetails.PS_Package_Details_Pkey = dG_Package_Details_Pkey;
                    dG_PackageDetails.PS_ProductTypeId = dG_ProductTypeId;
                    if(3 == 0)
                        {
                        return dG_PackageDetails;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            dG_PackageDetails.PS_PackageId = dG_PackageId;
            dG_PackageDetails.IsSynced = isSynced;
            return dG_PackageDetails;
            }

        static PS_PackageDetails ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(DG_PackageDetails));
            }
        }
    }
