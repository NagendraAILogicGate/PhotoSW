using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("VenueTaxValueModel")]
    [Serializable]
	public class venuetaxvaluemodel
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int VenueTaxValueId { get; set; }

        public int TaxId { get; set; }

        public decimal TaxPercentage { get; set; }

        public int VenueId { get; set; }

      //  public bool IsActive { get; set; }

        public DateTime ModifiedDate { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }
        }
}
