using System;

namespace PhotoSW.IMIX.Model
{
	[Serializable]
	public class VenueTaxValueModel
	{
		public int VenueTaxValueId
		{
			get;
			set;
		}

		public int TaxId
		{
			get;
			set;
		}

		public decimal TaxPercentage
		{
			get;
			set;
		}

		public int VenueId
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

		public DateTime ModifiedDate
		{
			get;
			set;
		}
	}
}
