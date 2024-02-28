using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("SubStoresInfo")]
    public class substoresinfo
	{

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
		public int PS_SubStore_pkey
		{
			get;
			set;
		}

		public string PS_SubStore_Name
		{
			get;
			set;
		}

		public string PS_SubStore_Description
		{
			get;
			set;
		}

		public bool PS_SubStore_IsActive
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

		public string PS_SubStore_Locations
		{
			get;
			set;
		}

		public bool IsLogicalSubStore
		{
			get;
			set;
		}

		public int? LogicalSubStoreID
		{
			get;
			set;
		}

		public string PS_SubStore_Code
		{
			get;
			set;
		}

		public int SiteID
		{
			get;
			set;
		}
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
