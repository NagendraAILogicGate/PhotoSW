using System;

namespace PhotoSW.IMIX.Model
{
	public class OrderReceiptReprintInfo
	{
		public long OrderId
		{
			get;
			set;
		}

		public string OrderNumber
		{
			get;
			set;
		}

		public int PaymentMode
		{
			get;
			set;
		}

		public double NetCost
		{
			get;
			set;
		}

		public double TotalCost
		{
			get;
			set;
		}

		public string CurrencySymbol
		{
			get;
			set;
		}

		public double DiscountTotal
		{
			get;
			set;
		}

		public string PaymentDetail
		{
			get;
			set;
		}

		public string PhotoIds
		{
			get;
			set;
		}
	}
}
