using System;

namespace PhotoSW.IMIX.Model
{
	public class ProductSummary_Result
	{
		public string ProductName
		{
			get;
			set;
		}

		public int TotalQuantity
		{
			get;
			set;
		}

		public decimal UnitPrice
		{
			get;
			set;
		}

		public decimal TotalCost
		{
			get;
			set;
		}

		public decimal Discount
		{
			get;
			set;
		}

		public decimal NetPrice
		{
			get;
			set;
		}

		public decimal TotalRevenue
		{
			get;
			set;
		}

		public decimal Revpercentage
		{
			get;
			set;
		}

		public DateTime? FROMDate
		{
			get;
			set;
		}

		public DateTime? Todate
		{
			get;
			set;
		}

		public string UserName
		{
			get;
			set;
		}

		public string StoreName
		{
			get;
			set;
		}

		public int Flag
		{
			get;
			set;
		}

		public string DG_SubStore_Name
		{
			get;
			set;
		}

		public string DG_Orders_ProductCode
		{
			get;
			set;
		}
	}
}
