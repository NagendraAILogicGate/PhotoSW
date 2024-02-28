using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("iMIXConfigurationInfo")]
	public class iMIXconfigurationinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long IMIXConfigurationValueId { get; set; }
        public long IMIXConfigurationMasterId { get; set; }
        public string ConfigurationValue { get; set; }
        public int SubstoreId { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
