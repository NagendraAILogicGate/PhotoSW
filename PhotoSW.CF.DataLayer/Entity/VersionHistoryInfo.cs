using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("VersionHistoryInfo")]
    public class versionhistoryinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int PS_Version_Pkey { get; set; }

        public string PS_Version_Number { get; set; }

        public DateTime PS_Version_Date { get; set; }

        public int PS_UpdatedBY { get; set; }

        public string PS_Machine { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
