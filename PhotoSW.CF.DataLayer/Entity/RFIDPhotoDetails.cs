using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("RFIDPhotoDetails")]
    public class rfidphotodetails
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PhotoGrapherId { get; set; }

        public string FileName { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
