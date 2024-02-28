using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("iMixConfigurationLocationInfoList")]
    public class imixconfigurationlocationinfolist
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

      //  public List<imixconfigurationlocationinfo> iMixConfigurationLocationList { get; set; }

        public int SubstoreId { get; set; }

        public int LocationId { get; set; }


        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
