using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("StoreInfo")]
	public class storeinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
		public int Store_pkey
		{
			get;
			set;
		}

		public string Store_Name
		{
			get;
			set;
		}

		public string Country
		{
			get;
			set;
		}

		public string CentralServerIP
		{
			get;
			set;
		}

		public string StoreCode
		{
			get;
			set;
		}

		public string CenetralServerUName
		{
			get;
			set;
		}

		public string CenetralServerPassword
		{
			get;
			set;
		}

		public decimal? PreferredTimeToSyncFrom
		{
			get;
			set;
		}

		public decimal? PreferredTimeToSyncTo
		{
			get;
			set;
		}

		public string QRCodeWebUrl
		{
			get;
			set;
		}

		public string CountryCode
		{
			get;
			set;
		}

		public string Address
		{
			get;
			set;
		}

		public string BillReceiptTitle
		{
			get;
			set;
		}

		public bool? IsSequenceNoRequired
		{
			get;
			set;
		}

		public bool IsTaxEnabled
		{
			get;
			set;
		}

		public string PhoneNo
		{
			get;
			set;
		}

		public string PS_StoreCode
		{
			get;
			set;
		}

		public string StoreName
		{
			get;
			set;
		}

		public long TaxMaxSequenceNo
		{
			get;
			set;
		}

		public long TaxMinSequenceNo
		{
			get;
			set;
		}

		public string TaxRegistrationNumber
		{
			get;
			set;
		}

		public string TaxRegistrationText
		{
			get;
			set;
		}

		public string WebsiteURL
		{
			get;
			set;
		}

		public string EmailID
		{
			get;
			set;
		}

		public bool RunApplicationsSubStoreLevel
		{
			get;
			set;
		}

		public string ServerHotFolderPath
		{
			get;
			set;
		}

		public bool IsActiveStockShot
		{
			get;
			set;
		}

		public bool RunImageProcessingEngineLocationWise
		{
			get;
			set;
		}

		public bool RunVideoProcessingEngineLocationWise
		{
			get;
			set;
		}

		public bool IsTaxIncluded
		{
			get;
			set;
		}

		public bool IsOnline
		{
			get;
			set;
		}
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
