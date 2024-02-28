using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("SyncStatusInfo")]
	public class syncstatusinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
		public string Syncstatus
		{
			get;
			set;
		}

		public string SyncOrderNumber
		{
			get;
			set;
		}

		public string QRCode
		{
			get;
			set;
		}

		public DateTime? SyncOrderdate
		{
			get;
			set;
		}

		public string PhotoRfid
		{
			get;
			set;
		}

		public DateTime? Syncdate
		{
			get;
			set;
		}

		public string syncDateDisplay
		{
			get;
			set;
		}

		public int DGOrderspkey
		{
			get;
			set;
		}

		public int SyncStatusID
		{
			get;
			set;
		}

		public bool? IsAvailable
		{
			get;
			set;
		}

		public long ChangeTrackingId
		{
			get;
			set;
		}

		public string ImageSynced
		{
			get;
			set;
		}

		public long SyncFormID
		{
			get;
			set;
		}

		public DateTime SyncFormTransDate
		{
			get;
			set;
		}

		public string Form
		{
			get;
			set;
		}
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
