using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("EmailStatusInfo")]
    public class emailstatusinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int PS_Email_pkey { get; set; }

        public string OrderId { get; set; }

        public string EmailId { get; set; }

        public string PhotoId { get; set; }

        public int Status { get; set; }

        public DateTime EmailDateTime { get; set; }

        public string StatusDetail { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool? IsAvailable { get; set; }

        public string MediaName { get; set; }

        public string PhotoCount { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
