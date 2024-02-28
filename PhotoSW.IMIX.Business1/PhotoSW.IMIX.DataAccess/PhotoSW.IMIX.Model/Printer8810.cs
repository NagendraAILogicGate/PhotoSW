using System;

namespace PhotoSW.IMIX.Model
{
	public class Printer8810
	{
		public string ErrorMessage
		{
			get;
			set;
		}

		public long ImageCount
		{
			get;
			set;
		}

		public long ImageNewCount
		{
			get;
			set;
		}

		public long ImageOldCount
		{
			get;
			set;
		}

		public bool IsOnline
		{
			get;
			set;
		}

		public bool IsPrinting
		{
			get;
			set;
		}

		public int PrinterID
		{
			get;
			set;
		}

		public string PrinterSerialNumber
		{
			get;
			set;
		}

		public string PrinterStatus
		{
			get;
			set;
		}
	}
}
