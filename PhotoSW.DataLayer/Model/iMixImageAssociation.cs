using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "iMixImageAssociation"), DataContract(IsReference = true)]
    [Serializable]
    public class iMixImageAssociation : EntityObject
        {
        private long _IMIXImageAssociationId;

        private int _IMIXCardTypeId;

        private int _PhotoId;

        private string _CardUniqueIdentifier;

        private string _MappedIdentifier;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public long IMIXImageAssociationId
            {
            get
                {
                return this._IMIXImageAssociationId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._IMIXImageAssociationId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(iMixImageAssociation.(17925));
                this._IMIXImageAssociationId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
             //   this.ReportPropertyChanged(iMixImageAssociation.(17925));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int IMIXCardTypeId
            {
            get
                {
                return this._IMIXCardTypeId;
                }
            set
                {
            //    this.ReportPropertyChanging(iMixImageAssociation.(17958));
                this._IMIXCardTypeId = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(iMixImageAssociation.(17958));
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
           //     this.ReportPropertyChanging(iMixImageAssociation.(5650));
                this._PhotoId = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(iMixImageAssociation.(5650));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string CardUniqueIdentifier
            {
            get
                {
                return this._CardUniqueIdentifier;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(iMixImageAssociation.(17979));
                    this._CardUniqueIdentifier = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iMixImageAssociation.(17979));
                    //        }
                    //    }
                    while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string MappedIdentifier
            {
            get
                {
                return this._MappedIdentifier;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(iMixImageAssociation.(18008));
                    this._MappedIdentifier = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iMixImageAssociation.(18008));
                    //        }
                    //    }
                   // while(false);
                    }
                while(false);
                }
            }

        public static iMixImageAssociation CreateiMixImageAssociation ( long iMIXImageAssociationId, int iMIXCardTypeId, int photoId, string cardUniqueIdentifier, string mappedIdentifier )
            {
            iMixImageAssociation iMixImageAssociation;
            if(true)
                {
                iMixImageAssociation = new iMixImageAssociation();
                do
                    {
                    iMixImageAssociation.IMIXImageAssociationId = iMIXImageAssociationId;
                    }
                while(false);
                if(6 == 0)
                    {
                    return iMixImageAssociation;
                    }
                iMixImageAssociation.IMIXCardTypeId = iMIXCardTypeId;
                iMixImageAssociation.PhotoId = photoId;
                }
            iMixImageAssociation.CardUniqueIdentifier = cardUniqueIdentifier;
            iMixImageAssociation.MappedIdentifier = mappedIdentifier;
            return iMixImageAssociation;
            }

        static iMixImageAssociation ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(iMixImageAssociation));
            }


        }
    }
