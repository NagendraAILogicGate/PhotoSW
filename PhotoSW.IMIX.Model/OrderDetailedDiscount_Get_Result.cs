using System;

namespace PhotoSW.IMIX.Model
{
	public class OrderDetailedDiscount_Get_Result
	{
		public int DG_Orders_pkey
		{
			get;
			set;
		}

		public string DG_Orders_Number
		{
			get;
			set;
		}

		public DateTime DG_Orders_Date
		{
			get;
			set;
		}

		public int? OrderDetailId
		{
			get;
			set;
		}

		public decimal? DG_Orders_LineItems_DiscountAmount
		{
			get;
			set;
		}

		public decimal? DG_Orders_Details_Items_UniPrice
		{
			get;
			set;
		}

		public decimal? DG_Orders_Details_Items_TotalCost
		{
			get;
			set;
		}

		public decimal? DG_Orders_Details_Items_NetPrice
		{
			get;
			set;
		}

		public decimal? DG_Orders_Cost
		{
			get;
			set;
		}

		public decimal? DG_Orders_NetCost
		{
			get;
			set;
		}

		public double? DG_Orders_Total_Discount
		{
			get;
			set;
		}

		public string DG_Orders_ProductType_Name
		{
			get;
			set;
		}

		public string DG_Orders_ProductCode
		{
			get;
			set;
		}

		public string Discount
		{
			get;
			set;
		}

		public string Value
		{
			get;
			set;
		}

		public bool InPercentmode
		{
			get;
			set;
		}

		public string StoreName
		{
			get;
			set;
		}

		public string USerName
		{
			get;
			set;
		}

		public DateTime FromDate
		{
			get;
			set;
		}

		public DateTime ToDate
		{
			get;
			set;
		}

		public double ActualValue
		{
			get;
			set;
		}

		public string TotalOrderDiscountDetails
		{
			get;
			set;
		}

		public decimal TotalLineItemDiscount
		{
			get;
			set;
		}

		public int Quantity
		{
			get;
			set;
		}

		public string PhotNumber
		{
			get;
			set;
		}
	}
}
