using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("EmailSettingsInfo")]
    public class emailsettingsinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int PS_EmailSettings_pkey { get; set; }

        public string PS_MailSendFrom { get; set; }

        public string PS_MailSubject { get; set; }

        public string PS_MailBody { get; set; }

        public string PS_SmtpServername { get; set; }

        public string PS_SmtpServerport { get; set; }

        public bool PS_SmtpUserDefaultCredentials { get; set; }

        public string PS_SmtpServerUsername { get; set; }

        public string PS_SmtpServerPassword { get; set; }

        public bool PS_SmtpServerEnableSSL { get; set; }

        public string PS_MailBCC { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
