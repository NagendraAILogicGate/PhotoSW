using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("PhotoGroupInfo")]
	public class photogroupinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
		public long Group_pkey{get;set;}
        public string Group_Name { get; set; }
        public int Photo_ID { get; set; }
        public string Photo_RFID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int SubstoreId { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
