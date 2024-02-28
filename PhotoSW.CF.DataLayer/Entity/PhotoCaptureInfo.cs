using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("PhotoCaptureInfo")]
    public class photocaptureinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PhotoGrapherId { get; set; }

        public string PhotoName { get; set; }

        public DateTime SysDate { get; set; }

        public DateTime CaptureDate { get; set; }

        public string PhotoGrapherName { get; set; }

        public string GroupName { get; set; }

        public string RFIDNo { get; set; }

        public string LocationName { get; set; }

        public string SubstoreName { get; set; }

        public int pkey { get; set; }

        public string CharacterId { get; set; }

        public string MetaData { get; set; }

        public int LocationId { get; set; }

        public string UniqueIdentifier { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
