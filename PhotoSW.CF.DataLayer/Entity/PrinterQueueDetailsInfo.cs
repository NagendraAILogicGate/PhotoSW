using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("PrinterQueueDetailsInfo")]
    public class printerqueuedetailsinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PS_AssociatedPrinters_Pkey { get; set; }

        public string PS_AssociatedPrinters_Name { get; set; }

        public int PS_Orders_pkey { get; set; }

        public string PS_Orders_Number { get; set; }

        public int PS_Order_SubStoreId { get; set; }

        public string PS_Orders_ProductType_Name { get; set; }

        public int PS_Orders_ProductType_pkey { get; set; }

        public int PS_PrinterQueue_Pkey { get; set; }

        public int PS_PrinterQueue_ProductID { get; set; }

        public string PS_PrinterQueue_Image_Pkey { get; set; }

        public int PS_Associated_PrinterId { get; set; }

        public int PS_Order_Details_Pkey { get; set; }

        public bool PS_SentToPrinter { get; set; }

        public bool is_Active { get; set; }

        public int QueueIndex { get; set; }

        public string PS_Photos_RFID { get; set; }

        public string PS_Photos_pKey { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
