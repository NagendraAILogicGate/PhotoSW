using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("CurrencyInfo")]
    public class currencyinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PS_Currency_pkey { get; set; }

        public string PS_Currency_Name { get; set; }

        public float PS_Currency_Rate { get; set; }

        public string PS_Currency_Symbol { get; set; }

        public DateTime? PS_Currency_UpdatedDate { get; set; }

        public int? PS_Currency_ModifiedBy { get; set; }

        public bool? PS_Currency_Default { get; set; }

        public string PS_Currency_Icon { get; set; }

        public string PS_Currency_Code { get; set; }

        public bool? PS_Currency_IsActive { get; set; }

        public string SyncCode { get; set; }

        public bool IsSynced { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
