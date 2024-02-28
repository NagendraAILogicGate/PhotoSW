using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("OrderReceiptReprintInfo")]
    public class orderreceiptreprintinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long OrderId { get; set; }

        public string OrderNumber { get; set; }

        public int PaymentMode { get; set; }

        public double NetCost { get; set; }

        public double TotalCost { get; set; }

        public string CurrencySymbol { get; set; }

        public double DiscountTotal { get; set; }

        public string PaymentDetail { get; set; }

        public string PhotoIds { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
