using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("RfidFlushHistotyInfo")]
    public class rfidflushhistotyinfo
        {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int FlushId { get; set; }        

        public DateTime? ScheduleDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public int Status { get; set; }

        public string ErrorMessage { get; set; }

        public int SubStoreId { get; set; }

        public string StrStatus { get; set; }

        public string SubStore { get; set; }

        public int LocationId { get; set; }

        public string LocationName { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
