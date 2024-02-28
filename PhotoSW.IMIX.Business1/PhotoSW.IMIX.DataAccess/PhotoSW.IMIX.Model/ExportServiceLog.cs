using System;

namespace PhotoSW.IMIX.Model
{
	public class ExportServiceLog
	{
		public long Id
		{
			get;
			set;
		}

		public string ReportType
		{
			get;
			set;
		}

		public bool ReportSent
		{
			get;
			set;
		}

		public DateTime EventTime
		{
			get;
			set;
		}

		public string ExportFile
		{
			get;
			set;
		}

		public string ErrorDetails
		{
			get;
			set;
		}

		public string ExportPath
		{
			get;
			set;
		}

		public string ReportStatus
		{
			get
			{
				return this.ReportSent ? "Successful" : "Failed";
			}
		}
	}
}
