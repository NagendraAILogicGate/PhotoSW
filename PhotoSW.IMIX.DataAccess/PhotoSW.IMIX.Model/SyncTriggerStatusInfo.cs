using System;

namespace PhotoSW.IMIX.Model
{
	public class SyncTriggerStatusInfo
	{
		public long TableId
		{
			get;
			set;
		}

		public string TableName
		{
			get;
			set;
		}

		public bool IsSyncTriggerEnable
		{
			get;
			set;
		}
	}
}
