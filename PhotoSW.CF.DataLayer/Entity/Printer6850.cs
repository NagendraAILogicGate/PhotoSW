using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("Printer6850")]
    public class printer6850
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string ErrorMessage { get; set; }

        public long ImageCount { get; set; }

        public long ImageNewCount { get; set; }

        public long ImageOldCount { get; set; }

        public bool IsOnline { get; set; }

        public bool IsPrinting { get; set; }

        public int PrinterID { get; set; }

        public string PrinterSerialNumber { get; set; }

        public string PrinterStatus { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
