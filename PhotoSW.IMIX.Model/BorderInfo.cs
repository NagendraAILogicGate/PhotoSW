using System;

namespace PhotoSW.IMIX.Model
{
	public class BorderInfo
	{
		public int DG_Borders_pkey
		{
			get;
			set;
		}

		public string DG_Border
		{
			get;
			set;
		}

		public int DG_ProductTypeID
		{
			get;
			set;
		}

		public bool DG_IsActive
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

		public int DG_Orders_ProductType_pkey
		{
			get;
			set;
		}

		public string DG_Orders_ProductType_Name
		{
			get;
			set;
		}

		//public ProductTypeInfo ProductTypeInfo
		//{
		//	get;
		//	set;
		//}

		public string FilePath
		{
			get;
			set;
		}

		public int? CreatedBy
		{
			get;
			set;
		}

		public int? ModifiedBy
		{
			get;
			set;
		}

		public DateTime? CreatedDate
		{
			get;
			set;
		}

		public DateTime? ModifiedDate
		{
			get;
			set;
		}
	}
}
