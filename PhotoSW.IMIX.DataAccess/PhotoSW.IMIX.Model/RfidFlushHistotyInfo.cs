using System;

namespace PhotoSW.IMIX.Model
{
	public class RfidFlushHistotyInfo
	{
		public int FlushId
		{
			get;
			set;
		}

		public DateTime? ScheduleDate
		{
			get;
			set;
		}

		public DateTime? StartDate
		{
			get;
			set;
		}

		public DateTime? EndDate
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

		public string StrStatus
		{
			get;
			set;
		}

		public string SubStore
		{
			get;
			set;
		}

		public int LocationId
		{
			get;
			set;
		}

		public string LocationName
		{
			get;
			set;
		}
	}
}
