using System;

namespace PhotoSW.IMIX.Model
{
	public class OperatorPerformanceReport_Result
	{
		public string CurrencySymbol
		{
			get;
			set;
		}

		public string StoreName
		{
			get;
			set;
		}

		public string UserName
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

		public int Data1
		{
			get;
			set;
		}

		public decimal Revenue
		{
			get;
			set;
		}

		public long TotalSale
		{
			get;
			set;
		}

		public long Images_Sold
		{
			get;
			set;
		}

		public int Capture
		{
			get;
			set;
		}

		public int Shots_Previewed
		{
			get;
			set;
		}

		public int TotalBurned
		{
			get;
			set;
		}

		public string OperatorName
		{
			get;
			set;
		}
	}
}
