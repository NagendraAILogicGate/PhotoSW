using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("FinancialAuditTrail_Result")]
    public class financialaudittrail_result
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string UserName { get; set; }

        public string StoreName { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string OrderNumber { get; set; }

        public DateTime? OrderDate { get; set; }

        public string ProductType { get; set; }

        public string SellPrice { get; set; }

        public int Quantity { get; set; }

        public string TotalPrice { get; set; }

        public string Discount { get; set; }

        public string revenue { get; set; }

        public string TotalOrderPrice { get; set; }

        public string DG_Order_SubStoreId { get; set; }

        public string ProductCode { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
