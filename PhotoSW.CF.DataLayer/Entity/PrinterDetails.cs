
using System.Collections.ObjectModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("PrinterDetails")]

    public class printerdetails
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string PrinterName { get; set; }

        //public ObservableCollection<printerjobinfo> PrinterJOb { get; set; }

        public string PrinterStatus { get; set; }

        //public printerdetails ( string printername, ObservableCollection<printerjobinfo> printerjOb, string questatus)
        //{
        //    this.PrinterName = printername + " (" + questatus + ")";
        //    this.PrinterJOb = printerjOb;
        //    this.PrinterStatus = questatus;
        //}

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
