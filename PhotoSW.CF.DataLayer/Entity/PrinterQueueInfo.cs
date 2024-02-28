using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("PrinterQueueInfo")]
    public class printerqueueinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PS_PrinterQueue_Pkey { get; set; }

        public int? PS_PrinterQueue_ProductID { get; set; }

        public string PS_PrinterQueue_Image_Pkey { get; set; }

        public int? PS_Associated_PrinterId { get; set; }

        public int? PS_Order_Details_Pkey { get; set; }

        public bool? PS_SentToPrinter { get; set; }

        public bool? is_Active { get; set; }

        public int? QueueIndex { get; set; }

        public bool? PS_IsSpecPrint { get; set; }

        public DateTime? PS_Print_Date { get; set; }

        public string RotationAngle { get; set; }

        public string PS_AssociatedPrinters_Name { get; set; }

        public string PS_Orders_ProductType_Name { get; set; }

        public string PS_Photos_RFID { get; set; }

        public int PS_Orders_ProductType_pkey { get; set; }

        public string PS_Orders_Number { get; set; }

        public int PS_Orders_pkey { get; set; }

        public int PS_Order_SubStoreId { get; set; }

        public string PS_Photos_ID { get; set; }

        public int PS_Orders_LineItems_pkey { get; set; }

        public int PS_Orders_ID { get; set; }

        public int PS_AssociatedPrinters_Pkey { get; set; }

        public string PS_Photos_FileName { get; set; }

        public DateTime? PS_Photos_CreatedOn { get; set; }

        public string PrintedBy { get; set; }

        public string TakenBy { get; set; }

        public int ID { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }


        }
    }
