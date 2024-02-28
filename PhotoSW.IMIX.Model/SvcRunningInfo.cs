using System;

namespace PhotoSW.IMIX.Model
{
	public class SvcRunningInfo
	{
		public string ServiceName
		{
			get;
			set;
		}

		public string SystemName
		{
			get;
			set;
		}

		public long ServicePOSMappingID
		{
			get;
			set;
		}

		public DateTime LastStatusOnDate
		{
			get;
			set;
		}

		public string Status
		{
			get;
			set;
		}

		public string SubStoreName
		{
			get;
			set;
		}
	}
}
