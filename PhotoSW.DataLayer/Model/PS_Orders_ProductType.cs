using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {

    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_Orders_ProductType"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Orders_ProductType : EntityObject
        {
        private int _PS_Orders_ProductType_pkey;

        private string _PS_Orders_ProductType_Name;

        private string _PS_Orders_ProductType_Desc;

        private bool? _PS_Orders_ProductType_IsBundled;

        private bool? _PS_Orders_ProductType_DiscountApplied;

        private string _PS_Orders_ProductType_Image;

        private bool _PS_IsPackage;

        private int _PS_MaxQuantity;

        private bool? _PS_Orders_ProductType_Active;

        private bool? _PS_IsActive;

        private bool? _PS_IsAccessory;

        private bool? _PS_IsPrimary;

        private string _PS_Orders_ProductCode;

        private int? _PS_Orders_ProductNumber;

        private bool? _PS_IsBorder;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

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
               // this.ReportPropertyChanging(DG_Orders_ProductType.(11518));
                this._PS_Orders_ProductType_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(DG_Orders_ProductType.(11518));
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
                  //  this.ReportPropertyChanging(DG_Orders_ProductType.(11555));
                    this._PS_Orders_ProductType_Name = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_ProductType.(11555));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_ProductType_Desc
            {
            get
                {
                return this._PS_Orders_ProductType_Desc;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Orders_ProductType.(11592));
                    this._PS_Orders_ProductType_Desc = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_ProductType.(11592));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
                //this.ReportPropertyChanging(DG_Orders_ProductType.(11629));
                this._PS_Orders_ProductType_IsBundled = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Orders_ProductType.(11629));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Orders_ProductType_DiscountApplied
            {
            get
                {
                return this._PS_Orders_ProductType_DiscountApplied;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Orders_ProductType.(11674));
                this._PS_Orders_ProductType_DiscountApplied = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_ProductType.(11674));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_ProductType_Image
            {
            get
                {
                return this._PS_Orders_ProductType_Image;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Orders_ProductType.(11727));
                    this._PS_Orders_ProductType_Image = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_ProductType.(11727));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public bool PS_IsPackage
            {
            get
                {
                return this._PS_IsPackage;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Orders_ProductType.(11764));
                this._PS_IsPackage = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_ProductType.(11764));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PS_MaxQuantity
            {
            get
                {
                return this._PS_MaxQuantity;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Orders_ProductType.(11781));
                this._PS_MaxQuantity = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_ProductType.(11781));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_Orders_ProductType_Active
            {
            get
                {
                return this._PS_Orders_ProductType_Active;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Orders_ProductType.(11802));
                this._PS_Orders_ProductType_Active = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_ProductType.(11802));
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
              //  this.ReportPropertyChanging(DG_Orders_ProductType.(7425));
                this._PS_IsActive = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Orders_ProductType.(7425));
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
               // this.ReportPropertyChanging(DG_Orders_ProductType.(11843));
                this._PS_IsAccessory = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_ProductType.(11843));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_IsPrimary
            {
            get
                {
                return this._PS_IsPrimary;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Orders_ProductType.(11864));
                this._PS_IsPrimary = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Orders_ProductType.(11864));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_ProductCode
            {
            get
                {
                return this._PS_Orders_ProductCode;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(DG_Orders_ProductType.(11881));
                    this._PS_Orders_ProductCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_ProductType.(11881));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_ProductNumber
            {
            get
                {
                return this._PS_Orders_ProductNumber;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Orders_ProductType.(11910));
                this._PS_Orders_ProductNumber = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_ProductType.(11910));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? PS_IsBorder
            {
            get
                {
                return this._PS_IsBorder;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Orders_ProductType.(11943));
                this._PS_IsBorder = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Orders_ProductType.(11943));
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
                 //   this.ReportPropertyChanging(DG_Orders_ProductType.(6613));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_ProductType.(6613));
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
              //  this.ReportPropertyChanging(DG_Orders_ProductType.(6626));
                this._IsSynced = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Orders_ProductType.(6626));
                }
            }

        public static PS_Orders_ProductType CreateDG_Orders_ProductType ( int dG_Orders_ProductType_pkey, bool dG_IsPackage, int dG_MaxQuantity, bool isSynced )
            {
            PS_Orders_ProductType dG_Orders_ProductType;
            while(true)
                {
                dG_Orders_ProductType = new PS_Orders_ProductType();
                if(5 != 0 && 8 != 0)
                    {
                    dG_Orders_ProductType.PS_Orders_ProductType_pkey = dG_Orders_ProductType_pkey;
                    dG_Orders_ProductType.PS_IsPackage = dG_IsPackage;
                    if(3 == 0)
                        {
                        return dG_Orders_ProductType;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            dG_Orders_ProductType.PS_MaxQuantity = dG_MaxQuantity;
            dG_Orders_ProductType.IsSynced = isSynced;
            return dG_Orders_ProductType;
            }

        static PS_Orders_ProductType ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(DG_Orders_ProductType));
            }


        }
    }
