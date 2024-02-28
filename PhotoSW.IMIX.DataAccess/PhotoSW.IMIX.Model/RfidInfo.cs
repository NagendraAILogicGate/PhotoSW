using System;

namespace PhotoSW.IMIX.Model
{
	public class RfidInfo
	{
		public long ImixConfigValueID
		{
			get;
			set;
		}

		public long ImixConfigMasterID
		{
			get;
			set;
		}

		public string ImixConfigMasterName
		{
			get;
			set;
		}

		public string ConfigurationValue
		{
			get;
			set;
		}

		public int SubStoreId
		{
			get;
			set;
		}

		public string SubStoreName
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
