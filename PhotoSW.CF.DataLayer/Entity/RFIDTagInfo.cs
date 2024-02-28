using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("RFIDTagInfo")]    

    public class rfidtaginfo
        {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int IdentifierId { get; set; }

        public int DeviceID { get; set; }

        public string TagId { get; set; }

        public DateTime? ScanningTime { get; set; }

        public int Status { get; set; }

        public string RawData { get; set; }

        public string SerialNo { get; set; }

       // public bool IsActive { get; set; }

        public int DummyRFIDTagID { get; set; }

        public DateTime? CreatedOn { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }
        }
}
