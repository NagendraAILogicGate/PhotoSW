using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("EMailInfo")]
    public class emailinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string StoreId { get; set; }

        public string SubstoreId { get; set; }

        public string VenueId { get; set; }

        public string OrderId { get; set; }

        public string Emailto { get; set; }

        public string EmailBcc { get; set; }

        public string EmailIsSent { get; set; }

        public string Sendername { get; set; }

        public string EmailMessage { get; set; }

        public string MediaName { get; set; }

        public string OtherMessage { get; set; }

        public string MailSubject { get; set; }

        public string MediaType { get; set; }

        public string FileExtension { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
