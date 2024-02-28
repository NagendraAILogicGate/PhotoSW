using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("OrderDetails")]
    public class orderdetails
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string PS_Orders_ProductType_Name { get; set; }

        public decimal? PS_Orders_Details_Items_TotalCost { get; set; }

        public decimal? PS_Orders_LineItems_DiscountAmount { get; set; }

        public long? PS_Orders_LineItems_Quantity { get; set; }

        public int PS_Refund_Quantity { get; set; }

        public decimal? PS_Refund_Amount { get; set; }

        public int PS_LineItemId { get; set; }

        public decimal? PS_LineItem_RefundPrice { get; set; }

        public decimal? PS_LineItemUnitPrice { get; set; }

        public string PhotoIds { get; set; }

        public int? PS_ProductTypeId { get; set; }

        public bool IsBundled { get; set; }

        public bool IsPackage { get; set; }
        public int loopquantity { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
