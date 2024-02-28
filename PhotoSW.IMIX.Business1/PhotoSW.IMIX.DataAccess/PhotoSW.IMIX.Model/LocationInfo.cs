using System;

namespace PhotoSW.IMIX.Model
{
	public class LocationInfo
	{
		public int DG_Location_pkey
		{
			get;
			set;
		}

		public string DG_Location_Name
		{
			get;
			set;
		}

		public int DG_Store_ID
		{
			get;
			set;
		}

		public int DG_SubStore_Location_Pkey
		{
			get;
			set;
		}

		public string DG_Location_PhoneNumber
		{
			get;
			set;
		}

		public bool DG_Location_IsActive
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

		public int DG_SubStore_ID
		{
			get;
			set;
		}

		public int DG_Location_ID
		{
			get;
			set;
		}
	}
}
