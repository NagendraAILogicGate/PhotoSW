using System;

namespace PhotoSW.IMIX.Model
{
	public class SubStore
	{
		public int DG_SubStore_pkey
		{
			get;
			set;
		}

		public string DG_SubStore_Name
		{
			get;
			set;
		}

		public string DG_SubStore_Description
		{
			get;
			set;
		}

		public bool DG_SubStore_IsActive
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
