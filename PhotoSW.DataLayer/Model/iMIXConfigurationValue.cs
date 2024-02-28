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
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "iMIXConfigurationValue"), DataContract(IsReference = true)]
    [Serializable]
    public class iMIXConfigurationValue : EntityObject
        {
        private long _IMIXConfigurationValueId;

        private long _IMIXConfigurationMasterId;

        private string _ConfigurationValue;

        private int _SubstoreId;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public long IMIXConfigurationValueId
            {
            get
                {
                return this._IMIXConfigurationValueId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._IMIXConfigurationValueId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(iMIXConfigurationValue.(17844));
                this._IMIXConfigurationValueId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(iMIXConfigurationValue.(17844));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public long IMIXConfigurationMasterId
            {
            get
                {
                return this._IMIXConfigurationMasterId;
                }
            set
                {
               // this.ReportPropertyChanging(iMIXConfigurationValue.(17486));
                this._IMIXConfigurationMasterId = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(iMIXConfigurationValue.(17486));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public string ConfigurationValue
            {
            get
                {
                return this._ConfigurationValue;
                }
            set
                {
                do
                    {
                 //   this.ReportPropertyChanging(iMIXConfigurationValue.(17877));
                    this._ConfigurationValue = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iMIXConfigurationValue.(17877));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int SubstoreId
            {
            get
                {
                return this._SubstoreId;
                }
            set
                {
              //  this.ReportPropertyChanging(iMIXConfigurationValue.(17902));
                this._SubstoreId = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(iMIXConfigurationValue.(17902));
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
                //    this.ReportPropertyChanging(iMIXConfigurationValue.(6913));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iMIXConfigurationValue.(6913));
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
              //  this.ReportPropertyChanging(iMIXConfigurationValue.(6926));
                this._IsSynced = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(iMIXConfigurationValue.(6926));
                }
            }

        //[EdmRelationshipNavigationProperty("DigiphotoModel", "FK_iMIXConfigurationValue_iIMIXConfigurationMaster", "iIMIXConfigurationMaster"), DataMember, SoapIgnore, XmlIgnore]
        //public iIMIXConfigurationMaster iIMIXConfigurationMaster
        //    {
        //    get
        //        {
        //      //  return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<iIMIXConfigurationMaster>(iMIXConfigurationValue.(17562), iMIXConfigurationValue.(3229)).Value;
        //        }
        //    set
        //        {
        //        do
        //            {
        //            if(!false)
        //                {
        //                ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<iIMIXConfigurationMaster>(iMIXConfigurationValue.(17562), iMIXConfigurationValue.(3229)).Value = value;
        //                }
        //            }
        //        while(false);
        //        }
        //    }

        //[Browsable(false), DataMember]
        //public EntityReference<iIMIXConfigurationMaster> iIMIXConfigurationMasterReference
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedReference<iIMIXConfigurationMaster>(iMIXConfigurationValue.(17562), iMIXConfigurationValue.(3229));
        //        }
        //    set
        //        {
        //        if(value != null)
        //            {
        //            RelationshipManager expr_30 = ((IEntityWithRelationships)this).RelationshipManager;
        //            string expr_37 = iMIXConfigurationValue.(17562);
        //            string expr_3E = iMIXConfigurationValue.(3229);
        //            if(!false)
        //                {
        //                expr_30.InitializeRelatedReference<iIMIXConfigurationMaster>(expr_37, expr_3E, value);
        //                }
        //            }
        //        }
        //    }

        public static iMIXConfigurationValue CreateiMIXConfigurationValue ( long iMIXConfigurationValueId, long iMIXConfigurationMasterId, string configurationValue, int substoreId, bool isSynced )
            {
            iMIXConfigurationValue iMIXConfigurationValue;
            if(true)
                {
                iMIXConfigurationValue = new iMIXConfigurationValue();
                do
                    {
                    iMIXConfigurationValue.IMIXConfigurationValueId = iMIXConfigurationValueId;
                    }
                while(false);
                if(6 == 0)
                    {
                    return iMIXConfigurationValue;
                    }
                iMIXConfigurationValue.IMIXConfigurationMasterId = iMIXConfigurationMasterId;
                iMIXConfigurationValue.ConfigurationValue = configurationValue;
                }
            iMIXConfigurationValue.SubstoreId = substoreId;
            iMIXConfigurationValue.IsSynced = isSynced;
            return iMIXConfigurationValue;
            }

        static iMIXConfigurationValue ()
            {
            // Note: this type is marked as 'beforefieldinit'.
          //  Strings.CreateGetStringDelegate(typeof(iMIXConfigurationValue));
            }


        }
    }
