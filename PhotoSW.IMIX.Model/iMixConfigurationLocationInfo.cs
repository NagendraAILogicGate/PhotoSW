using System;

namespace PhotoSW.IMIX.Model
{
	public class iMixConfigurationLocationInfo : iMIXConfigurationInfo
	{
		public long ConfigurationLocationValueId
		{
			get;
			set;
		}

		public new string ConfigurationValue
		{
			get;
			set;
		}

		public int LocationId
		{
			get;
			set;
		}
	}
}
