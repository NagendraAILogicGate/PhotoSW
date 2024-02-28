using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{

    [Table("SubStore")]
    public class substore
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PS_SubStore_pkey { get; set; }
        public string PS_SubStore_Name { get; set; }
        public string PS_SubStore_Description { get; set; }
       // public bool PS_SubStore_IsActive { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public DateTime ModifiedDate { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        //[ForeignKey("AddOns_Id")]
        //public virtual ICollection<serviceaddon> serviceaddons { get; set; }

    }
}
