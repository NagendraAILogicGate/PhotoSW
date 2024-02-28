using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("AssociatedPrintersInfo")]
    public class associatedprintersinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int PS_AssociatedPrinters_Pkey { get; set; }

        public string PS_AssociatedPrinters_Name { get; set; }

        public int PS_AssociatedPrinters_ProductType_ID { get; set; }

        public bool PS_AssociatedPrinters_IsActive { get; set; }

        public string PS_AssociatedPrinters_PaperSize { get; set; }

        public int? PS_AssociatedPrinters_SubStoreID { get; set; }

        public string PS_Orders_ProductType_Name { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
