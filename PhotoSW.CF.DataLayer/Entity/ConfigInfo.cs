using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{

    [Table("ConfigInfo")]
	public class configinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
		public int ConfigID
		{
			get;
			set;
		}

		public int SubStoreID
		{
			get;
			set;
		}

		public string ConfigKey
		{
			get;
			set;
		}

		public string ConfigValue
		{
			get;
			set;
		}

		public int MasterID
		{
			get;
			set;
		}
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
