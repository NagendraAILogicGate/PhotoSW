using System;

namespace PhotoSW.IMIX.Model
{
	public class DeviceInfo
	{
		public int DeviceId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string BDA
		{
			get;
			set;
		}

		public string SerialNo
		{
			get;
			set;
		}

		public int DeviceTypeId
		{
			get;
			set;
		}

		public string DeviceTypeName
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

		public bool IsChecked
		{
			get;
			set;
		}

		public int DeviceSessionId
		{
			get;
			set;
		}
	}
}
