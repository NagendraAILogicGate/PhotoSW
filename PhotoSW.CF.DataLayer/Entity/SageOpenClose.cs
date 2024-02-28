using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("SageOpenClose")]
	public class sageopenclose
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long SageInfoClosingId { get; set; }
        public long SageInfoId { get; set; }
        //public SageInfoClosing objClose
        //{
        //    get;
        //    set;
        //}

		
        //public SageInfo objOpen
        //{
        //    get;
        //    set;
        //}
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
