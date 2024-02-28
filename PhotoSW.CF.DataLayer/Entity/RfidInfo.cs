using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("RfidInfo")]
	public class rfidinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ImixConfigValueID { get; set; }
        public long ImixConfigMasterID { get; set; }
        public string ImixConfigMasterName { get; set; }
        public string ConfigurationValue { get; set; }
        public int SubStoreId { get; set; }
        public string SubStoreName { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
