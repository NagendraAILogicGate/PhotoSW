using System;

namespace PhotoSW.IMIX.Model
{
	public class RefundDetailInfo
	{
		public int DG_RefundDetail_ID
		{
			get;
			set;
		}

		public int? DG_LineItemId
		{
			get;
			set;
		}

		public string RefundPhotoId
		{
			get;
			set;
		}

		public int? DG_RefundMaster_ID
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
