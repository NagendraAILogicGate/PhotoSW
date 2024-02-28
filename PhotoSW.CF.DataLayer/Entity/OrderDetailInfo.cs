using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("OrderDetailInfo")]
    public class orderdetailinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PS_Orders_pkey { get; set; }

        public string PS_Orders_Number { get; set; }

        public DateTime PS_Orders_Date { get; set; }

        public int PS_Orders_LineItems_pkey { get; set; }

        public int? PS_Orders_ID { get; set; }

        public string PS_Photos_ID { get; set; }

        public DateTime? PS_Orders_LineItems_Created { get; set; }

        public string PS_Orders_LineItems_DiscountType { get; set; }

        public decimal? PS_Orders_LineItems_DiscountAmount { get; set; }

        public int? PS_Orders_LineItems_Quantity { get; set; }

        public decimal? PS_Orders_Details_Items_UniPrice { get; set; }

        public decimal? PS_Orders_Details_Items_TotalCost { get; set; }

        public decimal? PS_Orders_Details_Items_NetPrice { get; set; }

        public int? PS_Orders_Details_ProductType_pkey { get; set; }

        public int? PS_Orders_Details_LineItem_ParentID { get; set; }

        public int? PS_Orders_Details_LineItem_PrinterReferenceID { get; set; }

        public bool? PS_Photos_Burned { get; set; }

        public int? PS_Order_SubStoreId { get; set; }

        public int? IsPostedToServer { get; set; }

        public int? PS_Order_IdentifierType { get; set; }

        public string PS_Order_ImageUniqueIdentifier { get; set; }

        public int? PS_Order_Status { get; set; }

        public decimal? PS_Orders_Cost { get; set; }

        public decimal? PS_Orders_NetCost { get; set; }

        public double? PS_Orders_Total_Discount { get; set; }

        public long TotalQuantity { get; set; }

        public bool PS_Orders_ProductType_IsBundled { get; set; }

        public decimal LineItemshare { get; set; }

        public bool PS_IsPackage { get; set; }

        public string PS_Orders_ProductType_Name { get; set; }

        public orderinfo OrderInfo { get; set; }

        public int PS_Orders_ProductType_pkey { get; set; }

        public string PS_Orders_ProductCode { get; set; }

        public int LineItemID { get; set; }

        public decimal Discount { get; set; }

        public float Value { get; set; }

        public bool PS_IsBorder { get; set; }

        public bool InPercentmode { get; set; }

        public string SyncCode { get; set; }

        public string RFID { get; set; }

        public string PhotoID { get; set; }

        public double? TaxPercent { get; set; }

        public decimal? TaxAmount { get; set; }

        public bool? IsTaxIncluded { get; set; }

        public string PS_Photos_IDUnSold { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
