using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("RefundInfo")]
    public class refundinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PS_RefundId { get; set; }

        public int PS_OrderId { get; set; }

        public decimal RefundAmount { get; set; }

        public DateTime RefundDate { get; set; }

        public int UserId { get; set; }

        public int Refund_Mode { get; set; }

        public int PS_LineItemId { get; set; }

        public int RefundPhotoId { get; set; }

        public int PS_RefundMaster_ID { get; set; }

        public decimal? Refunded_Amount { get; set; }

        public string RefundReason { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
    }
