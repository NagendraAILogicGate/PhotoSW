using System;
using System.Collections.Generic;

namespace PhotoSW.IMIX.Model
{
	public class ReportParams
	{
		public string ReportType
		{
			get;
			set;
		}

		public Dictionary<string, string> ReportFormats
		{
			get;
			set;
		}
	}
}
