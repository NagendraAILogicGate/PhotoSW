using System;

namespace PhotoSW.IMIX.Model
{
	public class PermissionInfo
	{
		public int DG_Permission_pkey
		{
			get;
			set;
		}

		public string DG_Permission_Name
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
