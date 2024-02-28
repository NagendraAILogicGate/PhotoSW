using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "ValueType"), DataContract(IsReference = true)]
    [Serializable]
    public class ValueType : EntityObject
        {
        private int _ValueTypeId;

        private int _ValueTypeGroupId;

        private string _Name;

        private int _DisplayOrder;

        private int _CreatedBy;

        private DateTime _CreatedDate;

        private int? _ModifiedBy;

        private DateTime? _ModifiedDate;

        private bool _IsActive;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int ValueTypeId
            {
            get
                {
                return this._ValueTypeId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._ValueTypeId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
                //this.ReportPropertyChanging(ValueType.(18344));
                this._ValueTypeId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(ValueType.(18344));
                IL_42:
                if(!false)
                    {
                    return;
                    }
                goto IL_0E;
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int ValueTypeGroupId
            {
            get
                {
                return this._ValueTypeGroupId;
                }
            set
                {
             //   this.ReportPropertyChanging(ValueType.(18361));
                this._ValueTypeGroupId = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(ValueType.(18361));
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
                 //   this.ReportPropertyChanging(ValueType.(17569));
                    this._Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(ValueType.(17569));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int DisplayOrder
            {
            get
                {
                return this._DisplayOrder;
                }
            set
                {
            //    this.ReportPropertyChanging(ValueType.(18386));
                this._DisplayOrder = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(ValueType.(18386));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public int CreatedBy
            {
            get
                {
                return this._CreatedBy;
                }
            set
                {
         //       this.ReportPropertyChanging(ValueType.(18403));
                this._CreatedBy = StructuralObject.SetValidValue(value);
          //      this.ReportPropertyChanged(ValueType.(18403));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
        public DateTime CreatedDate
            {
            get
                {
                return this._CreatedDate;
                }
            set
                {
          //      this.ReportPropertyChanging(ValueType.(8041));
                this._CreatedDate = StructuralObject.SetValidValue(value);
         //       this.ReportPropertyChanged(ValueType.(8041));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public int? ModifiedBy
            {
            get
                {
                return this._ModifiedBy;
                }
            set
                {
         //       this.ReportPropertyChanging(ValueType.(18416));
                this._ModifiedBy = StructuralObject.SetValidValue(value);
      //          this.ReportPropertyChanged(ValueType.(18416));
                }
            }

        [EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
        public DateTime? ModifiedDate
            {
            get
                {
                return this._ModifiedDate;
                }
            set
                {
              //  this.ReportPropertyChanging(ValueType.(18433));
                this._ModifiedDate = StructuralObject.SetValidValue(value);
              //  this.ReportPropertyChanged(ValueType.(18433));
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
         //       this.ReportPropertyChanging(ValueType.(6729));
                this._IsActive = StructuralObject.SetValidValue(value);
      //          this.ReportPropertyChanged(ValueType.(6729));
                }
            }

        public static ValueType CreateValueType ( int valueTypeId, int valueTypeGroupId, string name, int displayOrder, int createdBy, DateTime createdDate, bool isActive )
            {
            return new ValueType
                {
                ValueTypeId = valueTypeId,
                ValueTypeGroupId = valueTypeGroupId,
                Name = name,
                DisplayOrder = displayOrder,
                CreatedBy = createdBy,
                CreatedDate = createdDate,
                IsActive = isActive
                };
            }

        static ValueType ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(ValueType));
            }

        }
    }
