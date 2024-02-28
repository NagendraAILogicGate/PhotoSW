using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects.DataClasses;
using System.Runtime.Serialization;

namespace PhotoSW.DataLayer.Model
    {

    [EdmEntityType(NamespaceName = "PhotoSW", Name = "BackupHistory"), DataContract(IsReference = true)]
    [Serializable]
    public class BackupHistory : EntityObject
        {
        private int _BackupId;

        private DateTime? _ScheduleDate;

        private DateTime? _StartDate;

        private DateTime? _EndDate;

        private int _Status;

        private string _ErrorMessage;

        private int _SubStoreId;

        //[NonSerialized]
        //internal static GetString ;

        [EdmScalarProperty(EntityKeyProperty = true, IsNullable = false), DataMember]
		public int BackupId
		{
			get
			{
				return this._BackupId;
			}
			set
			{
				if (!true)
				{
					goto IL_29;
				}
				if (this._BackupId == value)
				{
					goto IL_42;
				}
				IL_0E:
				//this.ReportPropertyChanging(BackupHistory.(5741));
				this._BackupId = StructuralObject.SetValidValue(value);
				IL_29:
				if (false)
				{
					goto IL_0E;
				}
				//this.ReportPropertyChanged(BackupHistory.(5741));
				IL_42:
				if (!false)
				{
					return;
				}
				goto IL_0E;
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public DateTime? ScheduleDate
		{
			get
			{
				return this._ScheduleDate;
			}
			set
			{
				//this.ReportPropertyChanging(BackupHistory.(5754));
				this._ScheduleDate = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(BackupHistory.(5754));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public DateTime? StartDate
		{
			get
			{
				return this._StartDate;
			}
			set
			{
				//this.ReportPropertyChanging(BackupHistory.(3826));
				this._StartDate = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(BackupHistory.(3826));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public DateTime? EndDate
		{
			get
			{
				return this._EndDate;
			}
			set
			{
				//this.ReportPropertyChanging(BackupHistory.(3839));
				this._EndDate = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(BackupHistory.(3839));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public int Status
		{
			get
			{
				return this._Status;
			}
			set
			{
				//this.ReportPropertyChanging(BackupHistory.(4096));
				this._Status = StructuralObject.SetValidValue(value);
				//this.ReportPropertyChanged(BackupHistory.(4096));
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = true), DataMember]
		public string ErrorMessage
		{
			get
			{
				return this._ErrorMessage;
			}
			set
			{
				do
				{
					//this.ReportPropertyChanging(BackupHistory.(5771));
					this._ErrorMessage = StructuralObject.SetValidValue(value, true);
					do
					{
						if (!false)
						{
							//this.ReportPropertyChanged(BackupHistory.(5771));
						}
					}
					while (false);
				}
				while (false);
			}
		}

		[EdmScalarProperty(EntityKeyProperty = false, IsNullable = false), DataMember]
		public int SubStoreId
		{
			get
			{
				return this._SubStoreId;
			}
			set
			{
				//this.ReportPropertyChanging(BackupHistory.(4024));
				this._SubStoreId = StructuralObject.SetValidValue(value);
			//	this.ReportPropertyChanged(BackupHistory.(4024));
			}
		}

		public static BackupHistory CreateBackupHistory(int backupId, int status, int subStoreId)
		{
			if (5 == 0)
			{
				goto IL_23;
			}
			BackupHistory expr_28 = new BackupHistory();
			BackupHistory backupHistory;
			if (3 != 0)
			{
				backupHistory = expr_28;
			}
			backupHistory.BackupId = backupId;
			IL_0F:
			BackupHistory expr_3F = backupHistory;
			if (5 != 0)
			{
				expr_3F.Status = status;
			}
			if (!false)
			{
				backupHistory.SubStoreId = subStoreId;
			}
			IL_23:
			if (5 != 0)
			{
				return backupHistory;
			}
			goto IL_0F;
		}

		static BackupHistory()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//Strings.CreateGetStringDelegate(typeof(BackupHistory));
		}

        }
    }
