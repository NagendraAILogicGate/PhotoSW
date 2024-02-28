using System;

namespace PhotoSW.IMIX.Model
{
	public class OrderInfo
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

		public DateTime? DG_Orders_Date
		{
			get;
			set;
		}

		public int? DG_Albums_ID
		{
			get;
			set;
		}

		public string DG_Order_Mode
		{
			get;
			set;
		}

		public int? DG_Orders_UserID
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

		public double? DG_Orders_Total_Discount
		{
			get;
			set;
		}

		public string DG_Orders_Total_Discount_Details
		{
			get;
			set;
		}

		public int? DG_Orders_PaymentMode
		{
			get;
			set;
		}

		public string DG_Orders_PaymentDetails
		{
			get;
			set;
		}

		public bool? DG_Orders_Canceled
		{
			get;
			set;
		}

		public DateTime? DG_Orders_Canceled_Date
		{
			get;
			set;
		}

		public string DG_Orders_Canceled_Reason
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

		public bool SyncStatus
		{
			get;
			set;
		}

		public DateTime SyncDate
		{
			get;
			set;
		}

		public int DG_Photos_ID
		{
			get;
			set;
		}

		public string DG_StoreCode
		{
			get;
			set;
		}

		public string PosName
		{
			get;
			set;
		}
	}
}
