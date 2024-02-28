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
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "iMixImageCardType"), DataContract(IsReference = true)]
    [Serializable]
    public class iMixImageCardType : EntityObject
        {

        private int _IMIXImageCardTypeId;

        private string _Name;

        private string _CardIdentificationDigit;

        private int _ImageIdentificationType;

        private bool? _IsActive;

        private int? _MaxImages;

        private string _Description;

        private DateTime? _CreatedOn;

        private bool? _IsPrepaid;

        private int? _PackageId;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int IMIXImageCardTypeId
            {
            get
                {
                return this._IMIXImageCardTypeId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._IMIXImageCardTypeId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(iMixImageCardType.(17731));
                this._IMIXImageCardTypeId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
               // this.ReportPropertyChanged(iMixImageCardType.(17731));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string Name
            {
            get
                {
                return this._Name;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(iMixImageCardType.(17545));
                    this._Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iMixImageCardType.(17545));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string CardIdentificationDigit
            {
            get
                {
                return this._CardIdentificationDigit;
                }
            set
                {
                do
                    {
                   // this.ReportPropertyChanging(iMixImageCardType.(18095));
                    this._CardIdentificationDigit = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iMixImageCardType.(18095));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int ImageIdentificationType
            {
            get
                {
                return this._ImageIdentificationType;
                }
            set
                {
               // this.ReportPropertyChanging(iMixImageCardType.(18128));
                this._ImageIdentificationType = StructuralObject.SetValidValue(value);
               // this.ReportPropertyChanged(iMixImageCardType.(18128));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? IsActive
            {
            get
                {
                return this._IsActive;
                }
            set
                {
             //   this.ReportPropertyChanging(iMixImageCardType.(6705));
                this._IsActive = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(iMixImageCardType.(6705));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? MaxImages
            {
            get
                {
                return this._MaxImages;
                }
            set
                {
            //    this.ReportPropertyChanging(iMixImageCardType.(18161));
                this._MaxImages = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(iMixImageCardType.(18161));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string Description
            {
            get
                {
                return this._Description;
                }
            set
                {
                do
                    {
              //      this.ReportPropertyChanging(iMixImageCardType.(18174));
                    this._Description = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iMixImageCardType.(18174));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? CreatedOn
            {
            get
                {
                return this._CreatedOn;
                }
            set
                {
             //   this.ReportPropertyChanging(iMixImageCardType.(6289));
                this._CreatedOn = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(iMixImageCardType.(6289));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public bool? IsPrepaid
            {
            get
                {
                return this._IsPrepaid;
                }
            set
                {
            //    this.ReportPropertyChanging(iMixImageCardType.(18191));
                this._IsPrepaid = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(iMixImageCardType.(18191));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? PackageId
            {
            get
                {
                return this._PackageId;
                }
            set
                {
            //    this.ReportPropertyChanging(iMixImageCardType.(18204));
                this._PackageId = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(iMixImageCardType.(18204));
                }
            }

        //[EdmRelationshipNavigationProperty("DigiphotoModel", "FK_CardRule_ImageCardType", "iMixCardRule"), DataMember, SoapIgnore, XmlIgnore]
        //public EntityCollection<iMixCardRule> iMixCardRule
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<iMixCardRule>(iMixImageCardType.(17809), iMixImageCardType.(3380));
        //        }
        //    set
        //        {
        //        if(value != null)
        //            {
        //            RelationshipManager expr_30 = ((IEntityWithRelationships)this).RelationshipManager;
        //            string expr_37 = iMixImageCardType.(17809);
        //            string expr_3E = iMixImageCardType.(3380);
        //            if(!false)
        //                {
        //                expr_30.InitializeRelatedCollection<iMixCardRule>(expr_37, expr_3E, value);
        //                }
        //            }
        //        }
        //    }

        public static iMixImageCardType CreateiMixImageCardType ( int iMIXImageCardTypeId, string name, string cardIdentificationDigit, int imageIdentificationType )
            {
            iMixImageCardType iMixImageCardType;
            while(true)
                {
                iMixImageCardType = new iMixImageCardType();
                if(5 != 0 && 8 != 0)
                    {
                    iMixImageCardType.IMIXImageCardTypeId = iMIXImageCardTypeId;
                    iMixImageCardType.Name = name;
                    if(3 == 0)
                        {
                        return iMixImageCardType;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            iMixImageCardType.CardIdentificationDigit = cardIdentificationDigit;
            iMixImageCardType.ImageIdentificationType = imageIdentificationType;
            return iMixImageCardType;
            }

        static iMixImageCardType ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(iMixImageCardType));
            }

        }
    }
