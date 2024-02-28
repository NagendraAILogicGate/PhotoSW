using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
 
    [Table("SubStoreLocationInfo")]
	public class substorelocationinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
		public int SubStore_Location_Pkey
		{
			get;
			set;
		}

		public int SubStore_ID
		{
			get;
			set;
		}

		public int Location_ID
		{
			get;
			set;
		}

		public string Location_Name
		{
			get;
			set;
		}
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
