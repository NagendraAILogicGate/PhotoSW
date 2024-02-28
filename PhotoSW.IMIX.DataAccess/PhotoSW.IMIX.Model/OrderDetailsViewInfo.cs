using System;

namespace PhotoSW.IMIX.Model
{
	public class OrderDetailsViewInfo
	{
		public int DG_Orders_LineItems_pkey
		{
			get;
			set;
		}

		public int? DG_Orders_ID
		{
			get;
			set;
		}

		public string DG_Photos_ID
		{
			get;
			set;
		}

		public DateTime? DG_Orders_LineItems_Created
		{
			get;
			set;
		}

		public string DG_Orders_LineItems_DiscountType
		{
			get;
			set;
		}

		public decimal? DG_Orders_LineItems_DiscountAmount
		{
			get;
			set;
		}

		public int DG_Orders_LineItems_Quantity
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

		public int? DG_Orders_Details_ProductType_pkey
		{
			get;
			set;
		}

		public int? DG_Orders_Details_LineItem_ParentID
		{
			get;
			set;
		}

		public int? DG_Orders_Details_LineItem_PrinterReferenceID
		{
			get;
			set;
		}

		public string DG_Orders_Number
		{
			get;
			set;
		}

		public DateTime? DG_Orders_Date
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

		public int? DG_Orders_Currency_ID
		{
			get;
			set;
		}

		public string DG_Orders_Currency_Conversion_Rate
		{
			get;
			set;
		}

		public float? DG_Orders_Total_Discount
		{
			get;
			set;
		}

		public string DG_Orders_Total_Discount_Details
		{
			get;
			set;
		}

		public string DG_Orders_PaymentDetails
		{
			get;
			set;
		}

		public int? DG_Orders_PaymentMode
		{
			get;
			set;
		}

		public string DG_Orders_ProductType_Name
		{
			get;
			set;
		}

		public bool? DG_IsBorder
		{
			get;
			set;
		}
	}
}
