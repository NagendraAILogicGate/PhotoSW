using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("OperationalAudit_Result")]
    public class operationalaudit_result
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PS_Orders_pkey { get; set; }

        public string PS_Orders_Number { get; set; }

        public string Location { get; set; }

        public string PhotoID { get; set; }

        public int Qty { get; set; }

        public string PhotoGrapher { get; set; }

        public string ProductType { get; set; }

        public string SubstoreName { get; set; }

        public string ProductCode { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
