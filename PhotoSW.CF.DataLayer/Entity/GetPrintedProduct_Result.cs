using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("GetPrintedProduct_Result")]
    public class getprintedproduct_result
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PrintedQuantity { get; set; }

        public string PS_Orders_ProductType_Name { get; set; }

        public DateTime? PS_Print_Date { get; set; }

        public string PhotoNumber { get; set; }

        public string PS_SubStore_Name { get; set; }

        public string ProductCode { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
