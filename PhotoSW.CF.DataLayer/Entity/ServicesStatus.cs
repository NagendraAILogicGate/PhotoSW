using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ServicesStatus")]
    public class servicesstatus
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string RunningStatus { get; set; }
        public string ButtonText { get; set; }
        public string Originalservicename { get; set; }
        public string ServicePath { get; set; }
        public bool? IsInterface { get; set; }
        public string BackOffsetColor { get; set; }
        public string BackColor { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
