using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("iMIXStoreConfigurationInfo")]
    public class imixstoreconfigurationinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long iMIXStoreConfigurationValueId
		{
			get;
			set;
		}

		public long IMIXConfigurationMasterId
		{
			get;
			set;
		}

		public string ConfigurationValue
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

		public DateTime ModifiedDate
		{
			get;
			set;
		}

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
