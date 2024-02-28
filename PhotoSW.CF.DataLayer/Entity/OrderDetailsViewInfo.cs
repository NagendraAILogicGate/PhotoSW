using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("OrderDetailsViewInfo")]
    public class orderdetailsviewinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PS_Orders_LineItems_pkey { get; set; }

        public int? PS_Orders_ID { get; set; }

        public string PS_Photos_ID { get; set; }

        public DateTime? PS_Orders_LineItems_Created { get; set; }

        public string PS_Orders_LineItems_DiscountType { get; set; }

        public decimal? PS_Orders_LineItems_DiscountAmount { get; set; }

        public int PS_Orders_LineItems_Quantity { get; set; }

        public decimal? PS_Orders_Details_Items_UniPrice { get; set; }

        public decimal? PS_Orders_Details_Items_TotalCost { get; set; }

        public decimal? PS_Orders_Details_Items_NetPrice { get; set; }

        public int? PS_Orders_Details_ProductType_pkey { get; set; }

        public int? PS_Orders_Details_LineItem_ParentID { get; set; }

        public int? PS_Orders_Details_LineItem_PrinterReferenceID { get; set; }

        public string PS_Orders_Number { get; set; }

        public DateTime? PS_Orders_Date { get; set; }

        public decimal? PS_Orders_Cost { get; set; }

        public decimal? PS_Orders_NetCost { get; set; }

        public int? PS_Orders_Currency_ID { get; set; }

        public string PS_Orders_Currency_Conversion_Rate { get; set; }

        public float? PS_Orders_Total_Discount { get; set; }

        public string PS_Orders_Total_Discount_Details { get; set; }

        public string PS_Orders_PaymentDetails { get; set; }

        public int? PS_Orders_PaymentMode { get; set; }

        public string PS_Orders_ProductType_Name { get; set; }

        public bool? PS_IsBorder { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
