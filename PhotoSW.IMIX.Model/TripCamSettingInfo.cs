using System;

namespace PhotoSW.IMIX.Model
{
	public class TripCamSettingInfo
	{
		public int TripCamValueId
		{
			get;
			set;
		}

		public long TripCamSettingsMasterId
		{
			get;
			set;
		}

		public string SettingsValue
		{
			get;
			set;
		}

		public int CameraId
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
