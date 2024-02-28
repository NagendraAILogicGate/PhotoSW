using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ProductSummary_Result")]
    public class productsummary_result
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ProductName { get; set; }

        public int TotalQuantity { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalCost { get; set; }

        public decimal Discount { get; set; }

        public decimal NetPrice { get; set; }

        public decimal TotalRevenue { get; set; }

        public decimal Revpercentage { get; set; }

        public DateTime? FROMDate { get; set; }

        public DateTime? Todate { get; set; }

        public string UserName { get; set; }

        public string StoreName { get; set; }

        public int Flag { get; set; }

        public string PS_SubStore_Name { get; set; }

        public string PS_Orders_ProductCode { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
