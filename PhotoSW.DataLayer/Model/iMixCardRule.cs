using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.ComponentModel;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "iMixCardRule"), DataContract(IsReference = true)]
    [Serializable]
    public class iMixCardRule : EntityObject
        {
        private long _IMIXCardRuleId;

        private int _IMIXImageAssociationRuleId;

        private int _IMIXImageCardTypeId;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public long IMIXCardRuleId
            {
            get
                {
                return this._IMIXCardRuleId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._IMIXCardRuleId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(iMixCardRule.(17644));
                this._IMIXCardRuleId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(iMixCardRule.(17644));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int IMIXImageAssociationRuleId
            {
            get
                {
                return this._IMIXImageAssociationRuleId;
                }
            set
                {
            //    this.ReportPropertyChanging(iMixCardRule.(17665));
                this._IMIXImageAssociationRuleId = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(iMixCardRule.(17665));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int IMIXImageCardTypeId
            {
            get
                {
                return this._IMIXImageCardTypeId;
                }
            set
                {
            //    this.ReportPropertyChanging(iMixCardRule.(17702));
                this._IMIXImageCardTypeId = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(iMixCardRule.(17702));
                }
            }

        //[EdmRelationshipNavigationProperty("DigiphotoModel", "FK_CardRule_CardRule", "iMIXImageAssociationRule"), DataMember, SoapIgnore, XmlIgnore]
        //public iMIXImageAssociationRule iMIXImageAssociationRule
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<iMIXImageAssociationRule>(iMixCardRule.(17731), iMixCardRule.(3397)).Value;
        //        }
        //    set
        //        {
        //        do
        //            {
        //            if(!false)
        //                {
        //                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<iMIXImageAssociationRule>(iMixCardRule.(17731), iMixCardRule.(3397)).Value = value;
        //                }
        //            }
        //        while(false);
        //        }
        //    }

        //[Browsable(false), DataMember]
        //public EntityReference<iMIXImageAssociationRule> iMIXImageAssociationRuleReference
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<iMIXImageAssociationRule>(iMixCardRule.(17731), iMixCardRule.(3397));
        //        }
        //    set
        //        {
        //        if(value != null)
        //            {
        //            RelationshipManager expr_30 = ((IEntityWithRelationships)this).RelationshipManager;
        //            string expr_37 = iMixCardRule.(17731);
        //            string expr_3E = iMixCardRule.(3397);
        //            if(!false)
        //                {
        //                expr_30.InitializeRelatedReference<iMIXImageAssociationRule>(expr_37, expr_3E, value);
        //                }
        //            }
        //        }
        //    }

        //[EdmRelationshipNavigationProperty("DigiphotoModel", "FK_CardRule_ImageCardType", "iMixImageCardType"), DataMember, SoapIgnore, XmlIgnore]
        //public iMixImageCardType iMixImageCardType
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<iMixImageCardType>(iMixCardRule.(17780), iMixCardRule.(3443)).Value;
        //        }
        //    set
        //        {
        //        do
        //            {
        //            if(!false)
        //                {
        //                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<iMixImageCardType>(iMixCardRule.(17780), iMixCardRule.(3443)).Value = value;
        //                }
        //            }
        //        while(false);
        //        }
        //    }

        //[Browsable(false), DataMember]
        //public EntityReference<iMixImageCardType> iMixImageCardTypeReference
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<iMixImageCardType>(iMixCardRule.(17780), iMixCardRule.(3443));
        //        }
        //    set
        //        {
        //        if(value != null)
        //            {
        //            RelationshipManager expr_30 = ((IEntityWithRelationships)this).RelationshipManager;
        //            string expr_37 = iMixCardRule.(17780);
        //            string expr_3E = iMixCardRule.(3443);
        //            if(!false)
        //                {
        //                expr_30.InitializeRelatedReference<iMixImageCardType>(expr_37, expr_3E, value);
        //                }
        //            }
        //        }
        //    }

        public static iMixCardRule CreateiMixCardRule ( long iMIXCardRuleId, int iMIXImageAssociationRuleId, int iMIXImageCardTypeId )
            {
            if(5 == 0)
                {
                goto IL_23;
                }
            iMixCardRule expr_28 = new iMixCardRule();
            iMixCardRule iMixCardRule;
            if(3 != 0)
                {
                iMixCardRule = expr_28;
                }
            iMixCardRule.IMIXCardRuleId = iMIXCardRuleId;
            IL_0F:
            iMixCardRule expr_3F = iMixCardRule;
            if(5 != 0)
                {
                expr_3F.IMIXImageAssociationRuleId = iMIXImageAssociationRuleId;
                }
            if(!false)
                {
                iMixCardRule.IMIXImageCardTypeId = iMIXImageCardTypeId;
                }
            IL_23:
            if(5 != 0)
                {
                return iMixCardRule;
                }
            goto IL_0F;
            }

        static iMixCardRule ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            //Strings.CreateGetStringDelegate(typeof(iMixCardRule));
            }


        }
    }
