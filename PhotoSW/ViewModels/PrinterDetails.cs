using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.IMIX.Model;

namespace PhotoSW.ViewModels
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
