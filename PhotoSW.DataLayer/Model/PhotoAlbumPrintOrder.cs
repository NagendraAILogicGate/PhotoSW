using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "PhotoAlbumPrintOrder"), DataContract(IsReference = true)]
    [Serializable]
    public class PhotoAlbumPrintOrder : EntityObject
        {

        private long _PrintOrderId;

        private int _OrderLineItemId;

        private int _PhotoId;

        private int _PageNo;

        private int _PrintPosition;

        private int? _RotationAngle;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public long PrintOrderId
            {
            get
                {
                return this._PrintOrderId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._PrintOrderId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(PhotoAlbumPrintOrder.(18224));
                this._PrintOrderId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(PhotoAlbumPrintOrder.(18224));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int OrderLineItemId
            {
            get
                {
                return this._OrderLineItemId;
                }
            set
                {
             //   this.ReportPropertyChanging(PhotoAlbumPrintOrder.(18241));
                this._OrderLineItemId = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(PhotoAlbumPrintOrder.(18241));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PhotoId
            {
            get
                {
                return this._PhotoId;
                }
            set
                {
             //   this.ReportPropertyChanging(PhotoAlbumPrintOrder.(5673));
                this._PhotoId = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(PhotoAlbumPrintOrder.(5673));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PageNo
            {
            get
                {
                return this._PageNo;
                }
            set
                {
            //    this.ReportPropertyChanging(PhotoAlbumPrintOrder.(18262));
                this._PageNo = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(PhotoAlbumPrintOrder.(18262));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int PrintPosition
            {
            get
                {
                return this._PrintPosition;
                }
            set
                {
           //     this.ReportPropertyChanging(PhotoAlbumPrintOrder.(18271));
                this._PrintPosition = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(PhotoAlbumPrintOrder.(18271));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? RotationAngle
            {
            get
                {
                return this._RotationAngle;
                }
            set
                {
            //    this.ReportPropertyChanging(PhotoAlbumPrintOrder.(13355));
                this._RotationAngle = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(PhotoAlbumPrintOrder.(13355));
                }
            }

        //[EdmRelationshipNavigationProperty("DigiphotoModel", "FK_PrintOrder_DG_Orders_Details", "DG_Orders_Details"), DataMember, SoapIgnore, XmlIgnore]
        //public DG_Orders_Details DG_Orders_Details
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<DG_Orders_Details>(PhotoAlbumPrintOrder.(11458), PhotoAlbumPrintOrder.(3611)).Value;
        //        }
        //    set
        //        {
        //        do
        //            {
        //            if(!false)
        //                {
        //                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<DG_Orders_Details>(PhotoAlbumPrintOrder.(11458), PhotoAlbumPrintOrder.(3611)).Value = value;
        //                }
        //            }
        //        while(false);
        //        }
        //    }

        //[Browsable(false), DataMember]
        //public EntityReference<DG_Orders_Details> DG_Orders_DetailsReference
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<DG_Orders_Details>(PhotoAlbumPrintOrder.(11458), PhotoAlbumPrintOrder.(3611));
        //        }
        //    set
        //        {
        //        if(value != null)
        //            {
        //            RelationshipManager expr_30 = ((IEntityWithRelationships)this).RelationshipManager;
        //            string expr_37 = PhotoAlbumPrintOrder.(11458);
        //            string expr_3E = PhotoAlbumPrintOrder.(3611);
        //            if(!false)
        //                {
        //                expr_30.InitializeRelatedReference<DG_Orders_Details>(expr_37, expr_3E, value);
        //                }
        //            }
        //        }
        //    }

        //[EdmRelationshipNavigationProperty("DigiphotoModel", "FK_PrintOrder_DG_Photos", "DG_Photos"), DataMember, SoapIgnore, XmlIgnore]
        //public DG_Photos DG_Photos
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<DG_Photos>(PhotoAlbumPrintOrder.(12882), PhotoAlbumPrintOrder.(3636)).Value;
        //        }
        //    set
        //        {
        //        do
        //            {
        //            if(!false)
        //                {
        //                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<DG_Photos>(PhotoAlbumPrintOrder.(12882), PhotoAlbumPrintOrder.(3636)).Value = value;
        //                }
        //            }
        //        while(false);
        //        }
        //    }

        //[Browsable(false), DataMember]
        //public EntityReference<DG_Photos> DG_PhotosReference
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<DG_Photos>(PhotoAlbumPrintOrder.(12882), PhotoAlbumPrintOrder.(3636));
        //        }
        //    set
        //        {
        //        if(value != null)
        //            {
        //            RelationshipManager expr_30 = ((IEntityWithRelationships)this).RelationshipManager;
        //            string expr_37 = PhotoAlbumPrintOrder.(12882);
        //            string expr_3E = PhotoAlbumPrintOrder.(3636);
        //            if(!false)
        //                {
        //                expr_30.InitializeRelatedReference<DG_Photos>(expr_37, expr_3E, value);
        //                }
        //            }
        //        }
        //    }

        public static PhotoAlbumPrintOrder CreatePhotoAlbumPrintOrder ( long printOrderId, int orderLineItemId, int photoId, int pageNo, int printPosition )
            {
            PhotoAlbumPrintOrder photoAlbumPrintOrder;
            if(true)
                {
                photoAlbumPrintOrder = new PhotoAlbumPrintOrder();
                do
                    {
                    photoAlbumPrintOrder.PrintOrderId = printOrderId;
                    }
                while(false);
                if(6 == 0)
                    {
                    return photoAlbumPrintOrder;
                    }
                photoAlbumPrintOrder.OrderLineItemId = orderLineItemId;
                photoAlbumPrintOrder.PhotoId = photoId;
                }
            photoAlbumPrintOrder.PageNo = pageNo;
            photoAlbumPrintOrder.PrintPosition = printPosition;
            return photoAlbumPrintOrder;
            }

        static PhotoAlbumPrintOrder ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(PhotoAlbumPrintOrder));
            }

        }
    }
