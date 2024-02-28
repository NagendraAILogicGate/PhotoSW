using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("LocationInfo")]
	public class locationinfo
	{

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
		public int Location_pkey
		{
			get;
			set;
		}

		public string Location_Name
		{
			get;
			set;
		}

		public int Store_ID
		{
			get;
			set;
		}

		public int SubStore_Location_Pkey
		{
			get;
			set;
		}

		public string Location_PhoneNumber
		{
			get;
			set;
		}

		public bool Location_IsActive
		{
			get;
			set;
		}

		public string SyncCode
		{
			get;
			set;
		}

		public bool IsSynced
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
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
