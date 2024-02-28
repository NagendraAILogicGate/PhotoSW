using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("PhotographerRFIDAssociationInfo")]
    public class photographerRFIDassociationinfo
        {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PhotographerID { get; set; }

        public string PhotographerName { get; set; }

        public string Location { get; set; }

        public int TotalCaptured { get; set; }

        public int TotalAssociated { get; set; }

        public int TotalNonAssociated { get; set; }

        public DateTime? LastAssociatedOn { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
