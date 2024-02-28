using System;

namespace PhotoSW.IMIX.Model
{
	public class GetServiceStatus
	{
		public int ServiceId
		{
			get;
			set;
		}

		public long SubStoreID
		{
			get;
			set;
		}

		public int Runlevel
		{
			get;
			set;
		}

		public long iMixPosId
		{
			get;
			set;
		}
	}
}
