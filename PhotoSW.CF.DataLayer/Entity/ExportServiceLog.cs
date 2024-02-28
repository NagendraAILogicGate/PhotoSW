using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ExportServiceLog")]
    public class exportservicelog
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string ReportType { get; set; }

        public bool ReportSent { get; set; }

        public DateTime EventTime { get; set; }

        public string ExportFile { get; set; }

        public string ErrorDetails { get; set; }

        public string ExportPath { get; set; }

        public string ReportStatus{ get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
