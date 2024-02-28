using System;

namespace PhotoSW.IMIX.Model
{
	public class ProductPriceInfo
	{
		public int DG_Product_Pricing_Pkey
		{
			get;
			set;
		}

		public int? DG_Product_Pricing_ProductType
		{
			get;
			set;
		}

		public double? DG_Product_Pricing_ProductPrice
		{
			get;
			set;
		}

		public int? DG_Product_Pricing_Currency_ID
		{
			get;
			set;
		}

		public DateTime? DG_Product_Pricing_UpdateDate
		{
			get;
			set;
		}

		public int? DG_Product_Pricing_CreatedBy
		{
			get;
			set;
		}

		public int? DG_Product_Pricing_StoreId
		{
			get;
			set;
		}

		public bool? DG_Product_Pricing_IsAvaliable
		{
			get;
			set;
		}
	}
}
