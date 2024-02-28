using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("SvcRunningInfo")]
    public class svcrunninginfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ServiceName { get; set; }

        public string SystemName { get; set; }

        public long ServicePOSMappingID { get; set; }

        public DateTime LastStatusOnDate { get; set; }

        public string Status { get; set; }

        public string SubStoreName { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
