using System;

namespace PhotoSW.IMIX.Model
{
	public class BackupHistory
	{
		public int BackupId
		{
			get;
			set;
		}

		public DateTime ScheduleDate
		{
			get;
			set;
		}

		public DateTime StartDate
		{
			get;
			set;
		}

		public DateTime EndDate
		{
			get;
			set;
		}

		public int Status
		{
			get;
			set;
		}

		public string ErrorMessage
		{
			get;
			set;
		}

		public int SubStoreId
		{
			get;
			set;
		}
	}
}
