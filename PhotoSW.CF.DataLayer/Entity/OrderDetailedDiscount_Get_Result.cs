using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("OrderDetailedDiscount_Get_Result")]
    public class orderdetaileddiscount_get_result
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PS_Orders_pkey { get; set; }

        public string PS_Orders_Number { get; set; }

        public DateTime PS_Orders_Date { get; set; }

        public int? OrderDetailId { get; set; }

        public decimal? PS_Orders_LineItems_DiscountAmount { get; set; }

        public decimal? PS_Orders_Details_Items_UniPrice { get; set; }

        public decimal? PS_Orders_Details_Items_TotalCost { get; set; }

        public decimal? PS_Orders_Details_Items_NetPrice { get; set; }

        public decimal? PS_Orders_Cost { get; set; }

        public decimal? PS_Orders_NetCost { get; set; }

        public double? PS_Orders_Total_Discount { get; set; }

        public string PS_Orders_ProductType_Name { get; set; }

        public string PS_Orders_ProductCode { get; set; }

        public string Discount { get; set; }

        public string Value { get; set; }

        public bool InPercentmode { get; set; }

        public string StoreName { get; set; }

        public string USerName { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public double ActualValue { get; set; }

        public string TotalOrderDiscountDetails { get; set; }

        public decimal TotalLineItemDiscount { get; set; }

        public int Quantity { get; set; }

        public string PhotNumber { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
