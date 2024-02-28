using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("RefundDetailInfo")]
    public class refunddetailinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int DG_RefundDetail_ID { get; set; }

        public int? DG_LineItemId { get; set; }

        public string RefundPhotoId { get; set; }

        public int? DG_RefundMaster_ID { get; set; }

        public decimal? Refunded_Amount { get; set; }

        public string RefundReason { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
