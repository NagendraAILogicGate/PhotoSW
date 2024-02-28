using System;

namespace PhotoSW.IMIX.Model
{
	public class OrderDetails
	{
		public string DG_Orders_ProductType_Name
		{
			get;
			set;
		}

		public decimal? DG_Orders_Details_Items_TotalCost
		{
			get;
			set;
		}

		public decimal? DG_Orders_LineItems_DiscountAmount
		{
			get;
			set;
		}

		public long? DG_Orders_LineItems_Quantity
		{
			get;
			set;
		}

		public int DG_Refund_Quantity
		{
			get;
			set;
		}

		public decimal? DG_Refund_Amount
		{
			get;
			set;
		}

		public int DG_LineItemId
		{
			get;
			set;
		}

		public decimal? DG_LineItem_RefundPrice
		{
			get;
			set;
		}

		public decimal? DG_LineItemUnitPrice
		{
			get;
			set;
		}

		public string PhotoIds
		{
			get;
			set;
		}

		public int? DG_ProductTypeId
		{
			get;
			set;
		}

		public bool IsBundled
		{
			get;
			set;
		}

		public bool IsPackage
		{
			get;
			set;
		}

		public int loopquantity
		{
			get;
			set;
		}
	}
}
