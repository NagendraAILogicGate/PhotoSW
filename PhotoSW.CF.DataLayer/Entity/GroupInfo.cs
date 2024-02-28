using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("GroupInfo")]
    public class groupinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int GroupID { get; set; }

        public string GroupName { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
