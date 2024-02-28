using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ProductTypeInfo")]
    public class producttypeinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PS_Orders_ProductType_pkey { get; set; }

        public string PS_Orders_ProductType_Name { get; set; }

        public string PS_Orders_ProductType_Desc { get; set; }

        public bool? PS_Orders_ProductType_IsBundled { get; set; }

        public bool? PS_Orders_ProductType_DiscountApplied { get; set; }

        public string PS_Orders_ProductType_Image { get; set; }

        public bool PS_IsPackage { get; set; }

        public int PS_MaxQuantity { get; set; }

        public bool? PS_Orders_ProductType_Active { get; set; }

        public bool? PS_IsActive { get; set; }

        public bool? PS_IsAccessory { get; set; }

        public bool? PS_IsTaxEnabled { get; set; }

        public bool? PS_IsPrimary { get; set; }

        public string PS_Orders_ProductCode { get; set; }

        public int? PS_Orders_ProductNumber { get; set; }

        public bool? PS_IsBorder { get; set; }

        public string SyncCode { get; set; }

        public bool IsSynced { get; set; }

        public double PS_Product_Pricing_ProductPrice { get; set; }

        public int PS_Product_Pricing_Currency_ID { get; set; }

        public int Itemcount { get; set; }

        public int IsPrintType { get; set; }

        public bool IsChecked { get; set; }

        public bool? PS_IsWaterMarkIncluded { get; set; }

        public int PS_SubStore_pkey { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
