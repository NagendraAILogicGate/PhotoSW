using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("CashBoxInfo")]
    public class cashboxinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      //  public long Id { get; set; }

        public int Id { get; set; }

        public string Reason { get; set; }

        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
