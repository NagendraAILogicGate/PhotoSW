using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace PhotoSW.IMIX.Model
{
	[XmlRoot(ElementName = "ClosingForm")]
	public class SageInfoClosing
	{
		public long ClosingFormDetailID
		{
			get;
			set;
		}

		[XmlElement("SubStore")]
		public SubStoresInfo objSubStore
		{
			get;
			set;
		}

		public long sixEightClosingNumber
		{
			get;
			set;
		}

		public long eightTenClosingNumber
		{
			get;
			set;
		}

		public long PosterClosingNumber
		{
			get;
			set;
		}

		public long sixEightAutoClosingNumber
		{
			get;
			set;
		}

		public long eightTenAutoClosingNumber
		{
			get;
			set;
		}

		public long SixEightWestage
		{
			get;
			set;
		}

		public long EightTenWestage
		{
			get;
			set;
		}

		public long SixEightAutoWestage
		{
			get;
			set;
		}

		public long EightTenAutoWestage
		{
			get;
			set;
		}

		public long PosterWestage
		{
			get;
			set;
		}

		public int Attendance
		{
			get;
			set;
		}

		public decimal LaborHour
		{
			get;
			set;
		}

		public long NoOfCapture
		{
			get;
			set;
		}

		public long NoOfPreview
		{
			get;
			set;
		}

		public long NoOfImageSold
		{
			get;
			set;
		}

		public string Comments
		{
			get;
			set;
		}

		public DateTime? ClosingDate
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

		public string FilledBySyncCode
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

		public DateTime? TransDate
		{
			get;
			set;
		}

		public decimal Cash
		{
			get;
			set;
		}

		public decimal CreditCard
		{
			get;
			set;
		}

		public decimal Amex
		{
			get;
			set;
		}

		public decimal FCV
		{
			get;
			set;
		}

		public decimal RoomCharges
		{
			get;
			set;
		}

		public decimal KVL
		{
			get;
			set;
		}

		public decimal Vouchers
		{
			get;
			set;
		}

		public long SixEightPrintCount
		{
			get;
			set;
		}

		public long EightTenPrintCount
		{
			get;
			set;
		}

		public long PosterPrintCount
		{
			get;
			set;
		}

		public string SyncCode
		{
			get;
			set;
		}

		public DateTime? OpeningDate
		{
			get;
			set;
		}

		public List<TransDetail> TransDetails
		{
			get;
			set;
		}

		public List<InventoryConsumables> InventoryConsumable
		{
			get;
			set;
		}
	}
}
