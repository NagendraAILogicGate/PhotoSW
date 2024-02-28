using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ReportParams")]
    public class reportparams
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ReportType { get; set; }

       // public Dictionary<string, string> ReportFormats { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
