using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("PrintSummaryDetail")]
    public class printsummarydetail
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string SaleType { get; set; }

        public string PhotoNumbers { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
