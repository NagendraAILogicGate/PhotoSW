using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ReportTypeDetail")]
    public class reporttypedetail
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        private int Id { get; set; }
        private string ReportTypeName { get; set; }
        private string ReportLabel { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
    }
