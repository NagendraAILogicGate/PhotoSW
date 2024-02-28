using System;

namespace PhotoSW.IMIX.Model
{
	public class GraphicsInfo
	{
		public int DG_Graphics_pkey
		{
			get;
			set;
		}

		public string DG_Graphics_Name
		{
			get;
			set;
		}

		public string DG_Graphics_Displayname
		{
			get;
			set;
		}

		public bool? DG_Graphics_IsActive
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

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public int ModifiedBy
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
