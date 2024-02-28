using System;

namespace PhotoSW.IMIX.Model
{
	public class iMIXStoreConfigurationInfo
	{
		public long iMIXStoreConfigurationValueId
		{
			get;
			set;
		}

		public long IMIXConfigurationMasterId
		{
			get;
			set;
		}

		public string ConfigurationValue
		{
			get;
			set;
		}

		public string SyncCode
		{
			get;
			set;
		}

		public bool IsSynced
		{
			get;
			set;
		}

		public DateTime ModifiedDate
		{
			get;
			set;
		}
	}
}
