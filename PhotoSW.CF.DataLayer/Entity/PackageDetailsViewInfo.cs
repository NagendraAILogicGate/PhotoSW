using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("PackageDetailsViewInfo")]
    public class packagedetailsviewinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PS_Package_Details_Pkey { get; set; }

        public int PS_ProductTypeId { get; set; }

        public int PS_PackageId { get; set; }

        public int PS_Product_Quantity { get; set; }

        public int PS_Orders_ProductType_pkey { get; set; }

        public string PS_Orders_ProductType_Name { get; set; }

        public int PS_Product_MaxImage { get; set; }

        public bool PS_Orders_ProductType_IsBundled { get; set; }

        public bool PS_IsAccessory { get; set; }

        public bool PS_IsActive { get; set; }

        public int? PS_Video_Length { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
