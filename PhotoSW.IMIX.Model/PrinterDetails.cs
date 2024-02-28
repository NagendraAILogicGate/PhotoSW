using System;
using System.Collections.ObjectModel;

namespace PhotoSW.IMIX.Model
{
	public class PrinterDetails
	{
		public string PrinterName
		{
			get;
			set;
		}

		public ObservableCollection<PrinterJobInfo> PrinterJOb
		{
			get;
			set;
		}

		public string PrinterStatus
		{
			get;
			set;
		}

		public PrinterDetails(string printername, ObservableCollection<PrinterJobInfo> printerjOb, string questatus)
		{
			this.PrinterName = printername + " (" + questatus + ")";
			this.PrinterJOb = printerjOb;
			this.PrinterStatus = questatus;
		}
	}
}
