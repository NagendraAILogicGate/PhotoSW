using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("RateDetailInfo")]
    public class ratedetailinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long ProfileAuditID { get; set; }

        public string DG_Currency_Name { get; set; }

        public string DG_Currency_Code { get; set; }

        public decimal ExchangeRate { get; set; }

      //  public bool IsActive { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }

        }
}
