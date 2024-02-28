using System;

namespace PhotoSW.IMIX.Model
{
	[Serializable]
	public class TaxDetailInfo
	{
		public int TaxId
		{
			get;
			set;
		}

		public decimal TaxAmount
		{
			get;
			set;
		}

		public decimal TaxPercentage
		{
			get;
			set;
		}

		public string TaxName
		{
			get;
			set;
		}

		public string CurrencyName
		{
			get;
			set;
		}
	}
}
