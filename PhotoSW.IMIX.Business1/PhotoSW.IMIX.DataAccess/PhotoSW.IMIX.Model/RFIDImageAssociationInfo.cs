using System;

namespace PhotoSW.IMIX.Model
{
	public class RFIDImageAssociationInfo
	{
		public int DeviceId
		{
			get;
			set;
		}

		public string DeviceName
		{
			get;
			set;
		}

		public string RFID
		{
			get;
			set;
		}

		public int Count
		{
			get;
			set;
		}

		public string PhotoIds
		{
			get;
			set;
		}

		public bool IsShowDetailActive
		{
			get;
			set;
		}
	}
}
