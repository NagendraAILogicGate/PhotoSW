using System;

namespace PhotoSW.IMIX.Model
{
	[Serializable]
	public class ServiceEmailContent
	{
		public string ReportType
		{
			get;
			set;
		}

		public string Status
		{
			get;
			set;
		}

		public string StatusDetails
		{
			get;
			set;
		}
	}
}
