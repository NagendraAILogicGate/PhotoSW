using System;

namespace PhotoSW.IMIX.Model
{
	public class ImixPOSDetail
	{
		public long ImixPOSDetailID
		{
			get;
			set;
		}

		public string SystemName
		{
			get;
			set;
		}

		public string IPAddress
		{
			get;
			set;
		}

		public string MacAddress
		{
			get;
			set;
		}

		public long SubStoreID
		{
			get;
			set;
		}

		public bool IsActive
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

		public string UpdatedBy
		{
			get;
			set;
		}

		public DateTime UpdatedOn
		{
			get;
			set;
		}

		public bool IsStart
		{
			get;
			set;
		}

		public DateTime StartStopTime
		{
			get;
			set;
		}

		public string SyncCode
		{
			get;
			set;
		}
	}
}
