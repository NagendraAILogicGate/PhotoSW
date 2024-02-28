using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("Product")]
    public class product
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ProductName { get; set; }

        public string ProductIcon { get; set; }

        public int ProductID { get; set; }

        public int MaxQuantity { get; set; }

        public bool DiscountOption { get; set; }

        public bool IsBundled { get; set; }

        public bool IsPackage { get; set; }

        public bool IsAccessory { get; set; }

        public bool IsWaterMarked { get; set; }

        public int? IsPrintType { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
