using System;

namespace PhotoSW.IMIX.Model
{
	public class GroupDetails
	{
		public int DG_Group_pkey
		{
			get;
			set;
		}

		public string DG_Group_Name
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

		public int OperationType
		{
			get;
			set;
		}

		public string DG_ProductCode
		{
			get;
			set;
		}
	}
}
