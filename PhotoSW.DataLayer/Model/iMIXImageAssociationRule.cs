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
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "iMIXImageAssociationRule"), DataContract(IsReference = true)]
    [Serializable]
    public class iMIXImageAssociationRule : EntityObject
        {
        private int _iMIXImageAssociationRuleId;

        private string _Name;

        private string _Action;

        private bool _IsActive;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int iMIXImageAssociationRuleId
            {
            get
                {
                return this._iMIXImageAssociationRuleId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._iMIXImageAssociationRuleId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
              //  this.ReportPropertyChanging(iMIXImageAssociationRule.(18038));
                this._iMIXImageAssociationRuleId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(iMIXImageAssociationRule.(18038));
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
                 //   this.ReportPropertyChanging(iMIXImageAssociationRule.(17534));
                    this._Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iMIXImageAssociationRule.(17534));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string Action
            {
            get
                {
                return this._Action;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(iMIXImageAssociationRule.(18075));
                    this._Action = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iMIXImageAssociationRule.(18075));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public bool IsActive
            {
            get
                {
                return this._IsActive;
                }
            set
                {
            //    this.ReportPropertyChanging(iMIXImageAssociationRule.(6694));
                this._IsActive = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(iMIXImageAssociationRule.(6694));
                }
            }

        //[EdmRelationshipNavigationProperty("DigiphotoModel", "FK_CardRule_CardRule", "iMixCardRule"), DataMember, SoapIgnore, XmlIgnore]
        //public EntityCollection<iMixCardRule> iMixCardRule
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<iMixCardRule>(iMIXImageAssociationRule.(17749), iMIXImageAssociationRule.(3369));
        //        }
        //    set
        //        {
        //        if(value != null)
        //            {
        //            RelationshipManager expr_30 = ((IEntityWithRelationships)this).RelationshipManager;
        //            string expr_37 = iMIXImageAssociationRule.(17749);
        //            string expr_3E = iMIXImageAssociationRule.(3369);
        //            if(!false)
        //                {
        //                expr_30.InitializeRelatedCollection<iMixCardRule>(expr_37, expr_3E, value);
        //                }
        //            }
        //        }
        //    }

        public static iMIXImageAssociationRule CreateiMIXImageAssociationRule ( int iMIXImageAssociationRuleId, string name, string action, bool isActive )
            {
            iMIXImageAssociationRule iMIXImageAssociationRule;
            while(true)
                {
                iMIXImageAssociationRule = new iMIXImageAssociationRule();
                if(5 != 0 && 8 != 0)
                    {
                    iMIXImageAssociationRule.iMIXImageAssociationRuleId = iMIXImageAssociationRuleId;
                    iMIXImageAssociationRule.Name = name;
                    if(3 == 0)
                        {
                        return iMIXImageAssociationRule;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            iMIXImageAssociationRule.Action = action;
            iMIXImageAssociationRule.IsActive = isActive;
            return iMIXImageAssociationRule;
            }

        static iMIXImageAssociationRule ()
            {
            // Note: this type is marked as 'beforefieldinit'.
            //Strings.CreateGetStringDelegate(typeof(iMIXImageAssociationRule));
            }


        }
    }
