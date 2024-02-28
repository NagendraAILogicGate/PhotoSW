using System;

namespace PhotoSW.IMIX.Model
{
	public class PackageDetailsInfo
	{
		public int DG_Package_Details_Pkey
		{
			get;
			set;
		}

		public int DG_ProductTypeId
		{
			get;
			set;
		}

		public int DG_PackageId
		{
			get;
			set;
		}

		public int DG_Product_Quantity
		{
			get;
			set;
		}

		public int DG_Product_MaxImage
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

		public string DG_ProductTypeIdComa
		{
			get;
			set;
		}

		public int DG_Orders_ProductType_pkey
		{
			get;
			set;
		}
	}
}
