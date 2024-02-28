using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("SeperatorTagInfo")]

    public class seperatortaginfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SeparatorRFIDTagID { get; set; }

        public string TagID { get; set; }

        public DateTime CreatedOn { get; set; }

        public int LocationId { get; set; }

        public string LocationName { get; set; }

        //	public bool IsActive { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }
        }
}
