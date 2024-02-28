using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("UserInfo")]
	public class userinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int UserId { get; set; }
        public string Photographer { get; set; }
        public string UserName { get; set; }
        public int Role_ID { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
