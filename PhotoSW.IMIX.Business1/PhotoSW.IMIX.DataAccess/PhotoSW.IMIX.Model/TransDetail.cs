using System;
using System.Xml.Serialization;

namespace PhotoSW.IMIX.Model
{
	public class TransDetail
	{
		[XmlIgnore]
		public long TransDetailID
		{
			get;
			set;
		}

		[XmlIgnore]
		public int SubstoreID
		{
			get;
			set;
		}

		public DateTime TransDate
		{
			get;
			set;
		}

		public int PackageID
		{
			get;
			set;
		}

		public string PackageSyncCode
		{
			get;
			set;
		}

		public decimal UnitPrice
		{
			get;
			set;
		}

		public decimal Quantity
		{
			get;
			set;
		}

		public decimal Discount
		{
			get;
			set;
		}

		public decimal Total
		{
			get;
			set;
		}

		public string PackageCode
		{
			get;
			set;
		}
	}
}
