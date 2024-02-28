using System;

namespace PhotoSW.IMIX.Model
{
	public class SyncStatusInfo
	{
		public string Syncstatus
		{
			get;
			set;
		}

		public string SyncOrderNumber
		{
			get;
			set;
		}

		public string QRCode
		{
			get;
			set;
		}

		public DateTime? SyncOrderdate
		{
			get;
			set;
		}

		public string PhotoRfid
		{
			get;
			set;
		}

		public DateTime? Syncdate
		{
			get;
			set;
		}

		public string syncDateDisplay
		{
			get;
			set;
		}

		public int DGOrderspkey
		{
			get;
			set;
		}

		public int SyncStatusID
		{
			get;
			set;
		}

		public bool? IsAvailable
		{
			get;
			set;
		}

		public long ChangeTrackingId
		{
			get;
			set;
		}

		public string ImageSynced
		{
			get;
			set;
		}

		public long SyncFormID
		{
			get;
			set;
		}

		public DateTime SyncFormTransDate
		{
			get;
			set;
		}

		public string Form
		{
			get;
			set;
		}
	}
}
