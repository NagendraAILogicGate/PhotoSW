using System;

namespace PhotoSW.IMIX.Model
{
	public class OrderDetailInfo
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

		public int? DG_Orders_LineItems_Quantity
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

		public bool? DG_Photos_Burned
		{
			get;
			set;
		}

		public int? DG_Order_SubStoreId
		{
			get;
			set;
		}

		public int? IsPostedToServer
		{
			get;
			set;
		}

		public int? DG_Order_IdentifierType
		{
			get;
			set;
		}

		public string DG_Order_ImageUniqueIdentifier
		{
			get;
			set;
		}

		public int? DG_Order_Status
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

		public long TotalQuantity
		{
			get;
			set;
		}

		public bool DG_Orders_ProductType_IsBundled
		{
			get;
			set;
		}

		public decimal LineItemshare
		{
			get;
			set;
		}

		public bool DG_IsPackage
		{
			get;
			set;
		}

		public string DG_Orders_ProductType_Name
		{
			get;
			set;
		}

		public OrderInfo OrderInfo
		{
			get;
			set;
		}

		public int DG_Orders_ProductType_pkey
		{
			get;
			set;
		}

		public string DG_Orders_ProductCode
		{
			get;
			set;
		}

		public int LineItemID
		{
			get;
			set;
		}

		public decimal Discount
		{
			get;
			set;
		}

		public float Value
		{
			get;
			set;
		}

		public bool DG_IsBorder
		{
			get;
			set;
		}

		public bool InPercentmode
		{
			get;
			set;
		}

		public string SyncCode
		{
			get;
			set;
		}

		public string RFID
		{
			get;
			set;
		}

		public string PhotoID
		{
			get;
			set;
		}

		public double? TaxPercent
		{
			get;
			set;
		}

		public decimal? TaxAmount
		{
			get;
			set;
		}

		public bool? IsTaxIncluded
		{
			get;
			set;
		}

		public string DG_Photos_IDUnSold
		{
			get;
			set;
		}
	}
}
