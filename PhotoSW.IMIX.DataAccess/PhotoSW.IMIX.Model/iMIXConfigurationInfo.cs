using System;

namespace PhotoSW.IMIX.Model
{
	public class iMIXConfigurationInfo
	{
		public long IMIXConfigurationValueId
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

		public int SubstoreId
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
	}
}
