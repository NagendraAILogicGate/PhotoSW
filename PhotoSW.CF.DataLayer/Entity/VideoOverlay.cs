using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("VideoOverlay")]
    public class videooverlay
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long VideoOverlayId { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string Description { get; set; }

        public long VideoLength { get; set; }

        public int CreatedBy { get; set; }

        public int MediaType { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int ModifiedBy { get; set; }

        public DateTime? ModifiedOn { get; set; }

      //  public bool IsActive { get; set; }

        public string IsActiveDisplay { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }

        }
}
