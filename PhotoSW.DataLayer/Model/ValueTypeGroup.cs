using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "ValueTypeGroup"), DataContract(IsReference = true)]
    [Serializable]
    public class ValueTypeGroup : EntityObject
        {
        private int _ValueTypeGroupId;

        private string _Name;

        private int _CreatedBy;

        private DateTime _CreatedDate;

        private int? _ModifiedBy;

        private DateTime? _ModifiedDate;

        private bool _IsActive;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
        public int ValueTypeGroupId
            {
            get
                {
                return this._ValueTypeGroupId;
                }
            set
                {
                if(!true)
                    {
                    goto IL_29;
                    }
                if(this._ValueTypeGroupId == value)
                    {
                    goto IL_42;
                    }
                IL_0E:
               // this.ReportPropertyChanging(ValueTypeGroup.(18369));
                this._ValueTypeGroupId = StructuralObject.SetValidValue(value);
                IL_29:
                if(false)
                    {
                    goto IL_0E;
                    }
              //  this.ReportPropertyChanged(ValueTypeGroup.(18369));
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
                   // this.ReportPropertyChanging(ValueTypeGroup.(17577));
                    this._Name = StructuralObject.SetValidValue(value, false);
                    //do
                    //    {
                    //    if(!false)
                    //        {
                    //        this.ReportPropertyChanged(ValueTypeGroup.(17577));
                    //        }
                    //    }
                    //while(false);
                    }
                while(false);
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
               // this.ReportPropertyChanging(ValueTypeGroup.(18411));
                this._CreatedBy = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(ValueTypeGroup.(18411));
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
             //   this.ReportPropertyChanging(ValueTypeGroup.(8049));
                this._CreatedDate = StructuralObject.SetValidValue(value);
             //   this.ReportPropertyChanged(ValueTypeGroup.(8049));
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
              //  this.ReportPropertyChanging(ValueTypeGroup.(18424));
                this._ModifiedBy = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(ValueTypeGroup.(18424));
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
             //   this.ReportPropertyChanging(ValueTypeGroup.(18441));
                this._ModifiedDate = StructuralObject.SetValidValue(value);
            //    this.ReportPropertyChanged(ValueTypeGroup.(18441));
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
            //    this.ReportPropertyChanging(ValueTypeGroup.(6737));
                this._IsActive = StructuralObject.SetValidValue(value);
           //     this.ReportPropertyChanged(ValueTypeGroup.(6737));
                }
            }

        public static ValueTypeGroup CreateValueTypeGroup ( int valueTypeGroupId, string name, int createdBy, DateTime createdDate, bool isActive )
            {
            ValueTypeGroup valueTypeGroup;
            if(true)
                {
                valueTypeGroup = new ValueTypeGroup();
                do
                    {
                    valueTypeGroup.ValueTypeGroupId = valueTypeGroupId;
                    }
                while(false);
                if(6 == 0)
                    {
                    return valueTypeGroup;
                    }
                valueTypeGroup.Name = name;
                valueTypeGroup.CreatedBy = createdBy;
                }
            valueTypeGroup.CreatedDate = createdDate;
            valueTypeGroup.IsActive = isActive;
            return valueTypeGroup;
            }

        static ValueTypeGroup ()
            {
            // Note: this type is marked as 'beforefieldinit'.
         //   Strings.CreateGetStringDelegate(typeof(ValueTypeGroup));
            }

        }
    }
