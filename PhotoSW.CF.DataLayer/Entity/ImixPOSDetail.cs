using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity  
    {
    [Table("ImixPOSDetail")]
    public class imixposdetail
        {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long ImixPOSDetailID { get; set; }

        public string SystemName { get; set; }

        public string IPAddress { get; set; }

        public string MacAddress { get; set; }

        public long SubStoreID { get; set; }

     //   public bool IsActive { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsStart { get; set; }

        public DateTime StartStopTime { get; set; }

        public string SyncCode { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }

        }
}
