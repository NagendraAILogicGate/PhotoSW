using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("SageInfo")]
    public class sageinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
		public long OpeningFormDetailID
		{
			get;
			set;
		}

		public long sixEightStartingNumber
		{
			get;
			set;
		}

		public long eightTenStartingNumber
		{
			get;
			set;
		}

		public long sixEightAutoStartingNumber
		{
			get;
			set;
		}

		public long eightTenAutoStartingNumber
		{
			get;
			set;
		}

		public long PosterStartingNumber
		{
			get;
			set;
		}

		public decimal CashFloatAmount
		{
			get;
			set;
		}

		public int SubStoreID
		{
			get;
			set;
		}

		public DateTime? OpeningDate
		{
			get;
			set;
		}

		public string FilledBySyncCode
		{
			get;
			set;
		}


		public int FilledBy
		{
			get;
			set;
		}

	
		public long OpenCloseProcDetailID
		{
			get;
			set;
		}

	
		public int FormTypeID
		{
			get;
			set;
		}

		
		public DateTime? FilledOn
		{
			get;
			set;
		}

		
		public DateTime? TransDate
		{
			get;
			set;
		}

	
		public int FormID
		{
			get;
			set;
		}

		public string SyncCode
		{
			get;
			set;
		}

		public DateTime? BusinessDate
		{
			get;
			set;
		}

		public DateTime ServerTime
		{
			get;
			set;
		}
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
