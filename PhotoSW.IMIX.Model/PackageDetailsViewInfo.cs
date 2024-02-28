using System;

namespace PhotoSW.IMIX.Model
{
	public class PackageDetailsViewInfo
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

		public int DG_Product_MaxImage
		{
			get;
			set;
		}

		public bool DG_Orders_ProductType_IsBundled
		{
			get;
			set;
		}

		public bool DG_IsAccessory
		{
			get;
			set;
		}

		public bool DG_IsActive
		{
			get;
			set;
		}

		public int? DG_Video_Length
		{
			get;
			set;
		}
	}
}
