using System;

namespace PhotoSW.IMIX.Model
{
	public class RoleInfo
	{
		public int DG_User_Roles_pkey
		{
			get;
			set;
		}

		public string DG_User_Role
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
