using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {
    [EdmEntityType(NamespaceName = "DigiphotoModel", Name = "ChangeTracking"), DataContract(IsReference = true)]
    [Serializable]
    public class ChangeTracking : EntityObject
        {
        private long _ChangeTrackingId;

        private long _ApplicationObjectId;

        private long _ObjectValueId;

        private int _ChangeAction;

        private DateTime _ChangeDate;

        private long _ChangeBy;

        private int _SyncStatus;

        private string _EntityCode;

        private DateTime? _SyncDate;

        //[NonSerialized]
        //internal static GetString ;

		[EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public long ChangeTrackingId
		{
			get
			{
				return this._ChangeTrackingId;
			}
			set
			{
				if (!true)
				{
					goto IL_29;
				}
				if (this._ChangeTrackingId == value)
				{
					goto IL_42;
				}
				IL_0E:
				//this.ReportPropertyChanging(ChangeTracking.(5798));
				this._ChangeTrackingId = StructuralObject.SetValidValue(value);
				IL_29:
				if (false)
				{
					goto IL_0E;
				}
				//this.ReportPropertyChanged(ChangeTracking.(5798));
				IL_42:
				if (!false)
				{
					return;
				}
				goto IL_0E;
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public long ApplicationObjectId
		{
			get
			{
				return this._ApplicationObjectId;
			}
			set
			{
				//this.ReportPropertyChanging(ChangeTracking.(5823));
				this._ApplicationObjectId = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ChangeTracking.(5823));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public long ObjectValueId
		{
			get
			{
				return this._ObjectValueId;
			}
			set
			{
				//this.ReportPropertyChanging(ChangeTracking.(5852));
				this._ObjectValueId = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ChangeTracking.(5852));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public int ChangeAction
		{
			get
			{
				return this._ChangeAction;
			}
			set
			{
				//this.ReportPropertyChanging(ChangeTracking.(5873));
				this._ChangeAction = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ChangeTracking.(5873));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public DateTime ChangeDate
		{
			get
			{
				return this._ChangeDate;
			}
			set
			{
				//this.ReportPropertyChanging(ChangeTracking.(5890));
				this._ChangeDate = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ChangeTracking.(5890));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public long ChangeBy
		{
			get
			{
				return this._ChangeBy;
			}
			set
			{
				//this.ReportPropertyChanging(ChangeTracking.(5907));
				this._ChangeBy = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ChangeTracking.(5907));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public int SyncStatus
		{
			get
			{
				return this._SyncStatus;
			}
			set
			{
				//this.ReportPropertyChanging(ChangeTracking.(5920));
				this._SyncStatus = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(ChangeTracking.(5920));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public string EntityCode
		{
			get
			{
				return this._EntityCode;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(ChangeTracking.(5937));
					this._EntityCode = StructuralObject.SetValidValue(value, false);
                    //do
                    //{
                    //    if (!false)
                    //    {
                    //        this.ReportPropertyChanged(ChangeTracking.(5937));
                    //    }
                    //}
                    //while (false);
				}
				while (false);
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public DateTime? SyncDate
		{
			get
			{
				return this._SyncDate;
			}
			set
			{
				//this.ReportPropertyChanging(ChangeTracking.(5954));
				this._SyncDate = StructuralObject.SetValidValue(value);
			//	this.ReportPropertyChanged(ChangeTracking.(5954));
			}
		}

		public static ChangeTracking CreateChangeTracking(long changeTrackingId, long applicationObjectId, long objectValueId, int changeAction, DateTime changeDate, long changeBy, int syncStatus, string entityCode)
		{
			ChangeTracking changeTracking;
			if (7 != 0)
			{
				if (false)
				{
					goto IL_27;
				}
				ChangeTracking expr_49 = new ChangeTracking();
				if (!false)
				{
					changeTracking = expr_49;
				}
				changeTracking.ChangeTrackingId = changeTrackingId;
				changeTracking.ApplicationObjectId = applicationObjectId;
				changeTracking.ObjectValueId = objectValueId;
			}
			changeTracking.ChangeAction = changeAction;
			IL_27:
			changeTracking.ChangeDate = changeDate;
			changeTracking.ChangeBy = changeBy;
			changeTracking.SyncStatus = syncStatus;
			changeTracking.EntityCode = entityCode;
			return changeTracking;
		}

		static ChangeTracking()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//Strings.CreateGetStringDelegate(typeof(ChangeTracking));
		}
        }
    }
