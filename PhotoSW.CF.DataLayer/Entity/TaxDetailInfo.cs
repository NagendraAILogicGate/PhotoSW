using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("TaxDetailInfo")]
    [Serializable]
	public class taxdetailinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TaxId { get; set; }

        public decimal TaxAmount { get; set; }

        public decimal TaxPercentage { get; set; }

        public string TaxName { get; set; }

        public string CurrencyName { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
