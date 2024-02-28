using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "DG_Orders_Details"), DataContract(IsReference = true)]
    [Serializable]
    public class PS_Orders_Details : EntityObject
        {
        private int _PS_Orders_LineItems_pkey;

        private int? _PS_Orders_ID;

        private string _PS_Photos_ID;

        private DateTime? _PS_Orders_LineItems_Created;

        private string _PS_Orders_LineItems_DiscountType;

        private decimal? _PS_Orders_LineItems_DiscountAmount;

        private int? _PS_Orders_LineItems_Quantity;

        private decimal? _PS_Orders_Details_Items_UniPrice;

        private decimal? _PS_Orders_Details_Items_TotalCost;

        private decimal? _PS_Orders_Details_Items_NetPrice;

        private int? _PS_Orders_Details_ProductType_pkey;

        private int? _PS_Orders_Details_LineItem_ParentID;

        private int? _PS_Orders_Details_LineItem_PrinterReferenceID;

        private bool? _PS_Photos_Burned;

        private int? _PS_Order_SubStoreId;

        private int? _IsPostedToServer;

        private int? _PS_Order_IdentifierType;

        private string _PS_Order_ImageUniqueIdentifier;

        private int? _PS_Order_Status;

        private string _SyncCode;

        //[NonSerialized]
        //internal static GetString ;

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
               // this.ReportPropertyChanging(DG_Orders_Details.(10393));
                this._PS_Orders_LineItems_pkey = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(DG_Orders_Details.(10393));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
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
               // this.ReportPropertyChanging(DG_Orders_Details.(10426));
                this._PS_Orders_ID = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_Details.(10426));
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
                    //this.ReportPropertyChanging(DG_Orders_Details.(10443));
                    this._PS_Photos_ID = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_Details.(10443));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? PS_Orders_LineItems_Created
            {
            get
                {
                return this._PS_Orders_LineItems_Created;
                }
            set
                {
                //this.ReportPropertyChanging(DG_Orders_Details.(10460));
                this._PS_Orders_LineItems_Created = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Orders_Details.(10460));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Orders_LineItems_DiscountType
            {
            get
                {
                return this._PS_Orders_LineItems_DiscountType;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(DG_Orders_Details.(10497));
                    this._PS_Orders_LineItems_DiscountType = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_Details.(10497));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_Orders_LineItems_DiscountAmount
            {
            get
                {
                return this._PS_Orders_LineItems_DiscountAmount;
                }
            set
                {
               // this.ReportPropertyChanging(DG_Orders_Details.(10542));
                this._PS_Orders_LineItems_DiscountAmount = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_Details.(10542));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_LineItems_Quantity
            {
            get
                {
                return this._PS_Orders_LineItems_Quantity;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Orders_Details.(10591));
                this._PS_Orders_LineItems_Quantity = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_Details.(10591));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_Orders_Details_Items_UniPrice
            {
            get
                {
                return this._PS_Orders_Details_Items_UniPrice;
                }
            set
                {
              //  this.ReportPropertyChanging(DG_Orders_Details.(10632));
                this._PS_Orders_Details_Items_UniPrice = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(DG_Orders_Details.(10632));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_Orders_Details_Items_TotalCost
            {
            get
                {
                return this._PS_Orders_Details_Items_TotalCost;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Orders_Details.(10677));
                this._PS_Orders_Details_Items_TotalCost = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_Details.(10677));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public decimal? PS_Orders_Details_Items_NetPrice
            {
            get
                {
                return this._PS_Orders_Details_Items_NetPrice;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Orders_Details.(10722));
                this._PS_Orders_Details_Items_NetPrice = StructuralObject.SetValidValue(value);
          ///      this.ReportPropertyChanged(DG_Orders_Details.(10722));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_Details_ProductType_pkey
            {
            get
                {
                return this._PS_Orders_Details_ProductType_pkey;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Orders_Details.(10767));
                this._PS_Orders_Details_ProductType_pkey = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(DG_Orders_Details.(10767));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_Details_LineItem_ParentID
            {
            get
                {
                return this._PS_Orders_Details_LineItem_ParentID;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Orders_Details.(10816));
                this._PS_Orders_Details_LineItem_ParentID = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(DG_Orders_Details.(10816));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Orders_Details_LineItem_PrinterReferenceID
            {
            get
                {
                return this._PS_Orders_Details_LineItem_PrinterReferenceID;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Orders_Details.(10865));
                this._PS_Orders_Details_LineItem_PrinterReferenceID = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_Details.(10865));
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
              //  this.ReportPropertyChanging(DG_Orders_Details.(10926));
                this._PS_Photos_Burned = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(DG_Orders_Details.(10926));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Order_SubStoreId
            {
            get
                {
                return this._PS_Order_SubStoreId;
                }
            set
                {
            //    this.ReportPropertyChanging(DG_Orders_Details.(10951));
                this._PS_Order_SubStoreId = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_Details.(10951));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? IsPostedToServer
            {
            get
                {
                return this._IsPostedToServer;
                }
            set
                {
            //    this.ReportPropertyChanging(DG_Orders_Details.(10980));
                this._IsPostedToServer = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(DG_Orders_Details.(10980));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Order_IdentifierType
            {
            get
                {
                return this._PS_Order_IdentifierType;
                }
            set
                {
            //    this.ReportPropertyChanging(DG_Orders_Details.(11005));
                this._PS_Order_IdentifierType = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(DG_Orders_Details.(11005));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string PS_Order_ImageUniqueIdentifier
            {
            get
                {
                return this._PS_Order_ImageUniqueIdentifier;
                }
            set
                {
                do
                    {
                //    this.ReportPropertyChanging(DG_Orders_Details.(11038));
                    this._PS_Order_ImageUniqueIdentifier = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_Details.(11038));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PS_Order_Status
            {
            get
                {
                return this._PS_Order_Status;
                }
            set
                {
             //   this.ReportPropertyChanging(DG_Orders_Details.(11079));
                this._PS_Order_Status = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(DG_Orders_Details.(11079));
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
               //     this.ReportPropertyChanging(DG_Orders_Details.(6584));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(DG_Orders_Details.(6584));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

       // [EdmRelationshipNavigationProperty("DigiphotoModel", "FK_PrintOrder_DG_Orders_Details", "PhotoAlbumPrintOrder"), DataMember, SoapIgnore, XmlIgnore]
        //public EntityCollection<PhotoAlbumPrintOrder> PhotoAlbumPrintOrder
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<PhotoAlbumPrintOrder>(DG_Orders_Details.(11100), DG_Orders_Details.(2568));
        //        }
        //    set
        //        {
        //        if(value != null)
        //            {
        //            RelationshipManager expr_30 = ((IEntityWithRelationships)this).RelationshipManager;
        //            string expr_37 = DG_Orders_Details.(11100);
        //            string expr_3E = DG_Orders_Details.(2568);
        //            if(!false)
        //                {
        //                expr_30.InitializeRelatedCollection<PhotoAlbumPrintOrder>(expr_37, expr_3E, value);
        //                }
        //            }
        //        }
        //    }

        public static PS_Orders_Details CreatePS_Orders_Details ( int dG_Orders_LineItems_pkey )
            {
            return new PS_Orders_Details
                {
                PS_Orders_LineItems_pkey = dG_Orders_LineItems_pkey
                };
            }

        static PS_Orders_Details ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(DG_Orders_Details));
            }


        }
    }
