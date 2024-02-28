using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("vw_TakingReport")]
    public class vw_takingreport
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string DG_Orders_Number { get; set; }

        public DateTime? DG_Orders_Date { get; set; }

        public string DG_Orders_PaymentMode { get; set; }

        public string DG_Orders_Currency_ID { get; set; }

        public decimal NetCost { get; set; }

        public string ItemDetail { get; set; }

        public int State { get; set; }

        public int DG_Orders_pkey { get; set; }

        public string s1 { get; set; }

        public string DG_SubStore_Name { get; set; }

        public string ItemCode { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
