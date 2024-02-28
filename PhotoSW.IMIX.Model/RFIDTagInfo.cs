using System;

namespace PhotoSW.IMIX.Model
{
	public class RFIDTagInfo
	{
		public int IdentifierId
		{
			get;
			set;
		}

		public int DeviceID
		{
			get;
			set;
		}

		public string TagId
		{
			get;
			set;
		}

		public DateTime? ScanningTime
		{
			get;
			set;
		}

		public int Status
		{
			get;
			set;
		}

		public string RawData
		{
			get;
			set;
		}

		public string SerialNo
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

		public int DummyRFIDTagID
		{
			get;
			set;
		}

		public DateTime? CreatedOn
		{
			get;
			set;
		}
	}
}
