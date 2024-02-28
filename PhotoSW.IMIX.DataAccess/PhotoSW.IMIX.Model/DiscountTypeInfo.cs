using System;

namespace PhotoSW.IMIX.Model
{
	public class DiscountTypeInfo
	{
		public int DG_Orders_DiscountType_Pkey
		{
			get;
			set;
		}

		public string DG_Orders_DiscountType_Name
		{
			get;
			set;
		}

		public string DG_Orders_DiscountType_Desc
		{
			get;
			set;
		}

		public bool? DG_Orders_DiscountType_Active
		{
			get;
			set;
		}

		public bool? DG_Orders_DiscountType_Secure
		{
			get;
			set;
		}

		public bool? DG_Orders_DiscountType_ItemLevel
		{
			get;
			set;
		}

		public bool? DG_Orders_DiscountType_AsPercentage
		{
			get;
			set;
		}

		public string DG_Orders_DiscountType_Code
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
