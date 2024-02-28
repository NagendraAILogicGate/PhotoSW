using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("OrderInfo")]
    
    public class orderinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PS_Orders_pkey { get; set; }

        public string PS_Orders_Number { get; set; }

        public DateTime? PS_Orders_Date { get; set; }

        public int? PS_Albums_ID { get; set; }

        public string PS_Order_Mode { get; set; }

        public int? PS_Orders_UserID { get; set; }

        public decimal? PS_Orders_Cost { get; set; }

        public decimal? PS_Orders_NetCost { get; set; }

        public int? PS_Orders_Currency_ID { get; set; }

        public string PS_Orders_Currency_Conversion_Rate { get; set; }

        public double? PS_Orders_Total_Discount { get; set; }

        public string PS_Orders_Total_Discount_Details { get; set; }

        public int? PS_Orders_PaymentMode { get; set; }

        public string PS_Orders_PaymentDetails { get; set; }

        public bool? PS_Orders_Canceled { get; set; }

        public DateTime? PS_Orders_Canceled_Date { get; set; }

        public string PS_Orders_Canceled_Reason { get; set; }

        public string SyncCode { get; set; }

        public bool IsSynced { get; set; }

        public bool SyncStatus { get; set; }

        public DateTime SyncDate { get; set; }

        public int PS_Photos_ID { get; set; }

        public string PS_StoreCode { get; set; }

        public string PosName { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
