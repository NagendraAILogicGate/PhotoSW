using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("SpecProfileProductMappingInfo")]
    public class specprofileproductmappinginfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SemiOrderProfileId { get; set; }

        public int ProductTypeId { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
