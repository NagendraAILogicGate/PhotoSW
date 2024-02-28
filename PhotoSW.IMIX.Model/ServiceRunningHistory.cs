using System;

namespace PhotoSW.IMIX.Model
{
	public class ServiceRunningHistory
	{
		public long ServiceRunningHistoryId
		{
			get;
			set;
		}

		public long ServiceID
		{
			get;
			set;
		}

		public long ImixPOSDetailID
		{
			get;
			set;
		}

		public DateTime LastStatusOnDate
		{
			get;
			set;
		}

		public bool Status
		{
			get;
			set;
		}

		public string CreatedBy
		{
			get;
			set;
		}

		public DateTime CreatedOn
		{
			get;
			set;
		}
	}
}
