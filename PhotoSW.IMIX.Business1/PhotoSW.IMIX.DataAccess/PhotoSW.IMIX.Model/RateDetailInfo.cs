using System;

namespace PhotoSW.IMIX.Model
{
	public class RateDetailInfo
	{
		public long ProfileAuditID
		{
			get;
			set;
		}

		public string DG_Currency_Name
		{
			get;
			set;
		}

		public string DG_Currency_Code
		{
			get;
			set;
		}

		public decimal ExchangeRate
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}
	}
}
