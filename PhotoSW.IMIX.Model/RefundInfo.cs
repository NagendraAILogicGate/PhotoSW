using System;

namespace PhotoSW.IMIX.Model
{
	public class RefundInfo
	{
		public int DG_RefundId
		{
			get;
			set;
		}

		public int DG_OrderId
		{
			get;
			set;
		}

		public decimal RefundAmount
		{
			get;
			set;
		}

		public DateTime RefundDate
		{
			get;
			set;
		}

		public int UserId
		{
			get;
			set;
		}

		public int Refund_Mode
		{
			get;
			set;
		}

		public int DG_LineItemId
		{
			get;
			set;
		}

		public int RefundPhotoId
		{
			get;
			set;
		}

		public int DG_RefundMaster_ID
		{
			get;
			set;
		}

		public decimal? Refunded_Amount
		{
			get;
			set;
		}

		public string RefundReason
		{
			get;
			set;
		}
	}
}
