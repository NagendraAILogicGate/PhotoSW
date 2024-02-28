using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("CurrencyExchangeinfo")]
    public class currencyexchangeinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ProfileAuditID { get; set; }

        public string ProfileName { get; set; }

        public DateTime startDate { get; set; }

        public DateTime? Enddate { get; set; }

     //   public bool IsActive { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public long Updatedby { get; set; }

        public DateTime updatedon { get; set; }

        public DateTime PublishedOn { get; set; }

        public bool IsCurrent { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }
        }
}
