using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ProductPriceInfo")]
    public class productpriceinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PS_Product_Pricing_Pkey { get; set; }

        public int? PS_Product_Pricing_ProductType { get; set; }

        public double? PS_Product_Pricing_ProductPrice { get; set; }

        public int? PS_Product_Pricing_Currency_ID { get; set; }

        public DateTime? PS_Product_Pricing_UpdateDate { get; set; }

        public int? PS_Product_Pricing_CreatedBy { get; set; }

        public int? PS_Product_Pricing_StoreId { get; set; }

        public bool? PS_Product_Pricing_IsAvaliable { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
