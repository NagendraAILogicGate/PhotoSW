using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("DeviceInfo")]
    public class deviceinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int DeviceId { get; set; }

        public string Name { get; set; }

        public string BDA { get; set; }

        public string SerialNo { get; set; }

        public int DeviceTypeId { get; set; }

        public string DeviceTypeName { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsChecked { get; set; }

        public int DeviceSessionId { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
