using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("PermissionInfo")]
	public class permissioninfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int PS_Permission_pkey { get; set; }
        public string PS_Permission_Name { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
