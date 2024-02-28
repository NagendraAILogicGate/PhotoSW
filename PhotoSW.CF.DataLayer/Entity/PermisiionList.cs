using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("PermisiionList")]
    public class permisiionlist
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public bool? IsAvailable { get; set; }

        public string PermissionName { get; set; }

        public int PermissionId { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
