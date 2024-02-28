using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("EmailDetailInfo")]
    public class emaildetailinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long EmailDetailId_Pkey { get; set; }

        public int EmailKey { get; set; }

        public string OrderId { get; set; }

        public long PhotoId { get; set; }

        public string PS_Email_To { get; set; }

        public string PS_Email_Bcc { get; set; }

        public string PS_EmailSender { get; set; }

        public string PS_Message { get; set; }

        public string EmailTemplate { get; set; }

        public string PS_ReportMailBody { get; set; }

        public string PS_OtherMessage { get; set; }

        public string PS_MessageType { get; set; }

        public string PS_EmailSubject { get; set; }

        public string PS_MediaName { get; set; }

        public string message { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
