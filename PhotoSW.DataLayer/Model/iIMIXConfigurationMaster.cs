using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Data.Objects.DataClasses;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "iIMIXConfigurationMaster"), DataContract(IsReference = true)]
    [Serializable]
    public class iIMIXConfigurationMaster : EntityObject
        {
        private long _IMIXConfigurationMasterId;

        private string _Name;

        private string _DisplayLabel;

        private string _DataType;

        private bool _IsActive;

        private string _SyncCode;

        private bool _IsSynced;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public long IMIXConfigurationMasterId
            {
            get
                {
                return this._IMIXConfigurationMasterId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._IMIXConfigurationMasterId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(iIMIXConfigurationMaster.(17475));
                this._IMIXConfigurationMasterId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(iIMIXConfigurationMaster.(17475));
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
                   // this.ReportPropertyChanging(iIMIXConfigurationMaster.(17512));
                    this._Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iIMIXConfigurationMaster.(17512));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string DisplayLabel
            {
            get
                {
                return this._DisplayLabel;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(iIMIXConfigurationMaster.(17521));
                    this._DisplayLabel = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iIMIXConfigurationMaster.(17521));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public string DataType
            {
            get
                {
                return this._DataType;
                }
            set
                {
                do
                    {
                  //  this.ReportPropertyChanging(iIMIXConfigurationMaster.(17538));
                    this._DataType = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iIMIXConfigurationMaster.(17538));
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
              //  this.ReportPropertyChanging(iIMIXConfigurationMaster.(6672));
                this._IsActive = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(iIMIXConfigurationMaster.(6672));
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
                //    this.ReportPropertyChanging(iIMIXConfigurationMaster.(6902));
                    this._SyncCode = StructuralObject.SetValidValue(value, true);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(iIMIXConfigurationMaster.(6902));
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
              //  this.ReportPropertyChanging(iIMIXConfigurationMaster.(6915));
                this._IsSynced = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(iIMIXConfigurationMaster.(6915));
                }
            }

     //   [EdmRelationshipNavigationProperty("DigiphotoModel", "FK_iMIXConfigurationValue_iIMIXConfigurationMaster", "iMIXConfigurationValue"), DataMember, SoapIgnore, XmlIgnore]
        //public EntityCollection<iMIXConfigurationValue> iMIXConfigurationValue
        //    {
        //    get
        //        {
        //        return ((IEntityWithRelationships)this).RelationshipManager.GetRelatedCollection<iMIXConfigurationValue>(iIMIXConfigurationMaster.(17551), iIMIXConfigurationMaster.(3251));
        //        }
        //    set
        //        {
        //        if(value != null)
        //            {
        //            RelationshipManager expr_30 = ((IEntityWithRelationships)this).RelationshipManager;
        //            string expr_37 = iIMIXConfigurationMaster.(17551);
        //            string expr_3E = iIMIXConfigurationMaster.(3251);
        //            if(!false)
        //                {
        //                expr_30.InitializeRelatedCollection<iMIXConfigurationValue>(expr_37, expr_3E, value);
        //                }
        //            }
        //        }
        //    }

        public static iIMIXConfigurationMaster CreateiIMIXConfigurationMaster ( long iMIXConfigurationMasterId, string name, bool isActive, bool isSynced )
            {
            iIMIXConfigurationMaster iIMIXConfigurationMaster;
            while(true)
                {
                iIMIXConfigurationMaster = new iIMIXConfigurationMaster();
                if(5 != 0 && 8 != 0)
                    {
                    iIMIXConfigurationMaster.IMIXConfigurationMasterId = iMIXConfigurationMasterId;
                    iIMIXConfigurationMaster.Name = name;
                    if(3 == 0)
                        {
                        return iIMIXConfigurationMaster;
                        }
                    if(!false)
                        {
                        break;
                        }
                    }
                }
            iIMIXConfigurationMaster.IsActive = isActive;
            iIMIXConfigurationMaster.IsSynced = isSynced;
            return iIMIXConfigurationMaster;
            }

        static iIMIXConfigurationMaster ()
            {
            // Note: this type is marked as 'beforefieldinit'.
           // Strings.CreateGetStringDelegate(typeof(iIMIXConfigurationMaster));
            }


        }
    }
