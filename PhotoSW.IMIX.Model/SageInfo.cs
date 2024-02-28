using System;
using System.Xml.Serialization;

namespace PhotoSW.IMIX.Model
{
	public class SageInfo
	{
		public long OpeningFormDetailID
		{
			get;
			set;
		}

		public long sixEightStartingNumber
		{
			get;
			set;
		}

		public long eightTenStartingNumber
		{
			get;
			set;
		}

		public long sixEightAutoStartingNumber
		{
			get;
			set;
		}

		public long eightTenAutoStartingNumber
		{
			get;
			set;
		}

		public long PosterStartingNumber
		{
			get;
			set;
		}

		public decimal CashFloatAmount
		{
			get;
			set;
		}

		[XmlIgnore]
		public int SubStoreID
		{
			get;
			set;
		}

		public DateTime? OpeningDate
		{
			get;
			set;
		}

		public string FilledBySyncCode
		{
			get;
			set;
		}

		[XmlIgnore]
		public int FilledBy
		{
			get;
			set;
		}

		[XmlIgnore]
		public long OpenCloseProcDetailID
		{
			get;
			set;
		}

		[XmlIgnore]
		public int FormTypeID
		{
			get;
			set;
		}

		[XmlIgnore]
		public DateTime? FilledOn
		{
			get;
			set;
		}

		[XmlIgnore]
		public DateTime? TransDate
		{
			get;
			set;
		}

		[XmlIgnore]
		public int FormID
		{
			get;
			set;
		}

		public string SyncCode
		{
			get;
			set;
		}

		public DateTime? BusinessDate
		{
			get;
			set;
		}

		[XmlIgnore]
		public DateTime ServerTime
		{
			get;
			set;
		}
	}
}
