using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("SageInfoClosing")]
	public class sageinfoclosing
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ClosingFormDetailID { get; set; }
        public long SubStoresInfoId { get; set; }
        //public SubStoresInfo objSubStore { get; set; }
        public long sixEightClosingNumber { get; set; }
        public long eightTenClosingNumber { get; set; }
        public long PosterClosingNumber { get; set; }
        public long sixEightAutoClosingNumber { get; set; }
        public long eightTenAutoClosingNumber { get; set; }
        public long SixEightWestage { get; set; }
        public long EightTenWestage { get; set; }
        public long SixEightAutoWestage { get; set; }
        public long EightTenAutoWestage { get; set; }
        public long PosterWestage { get; set; }
        public int Attendance { get; set; }
        public decimal LaborHour { get; set; }
        public long NoOfCapture { get; set; }
        public long NoOfPreview { get; set; }
        public long NoOfImageSold { get; set; }
        public string Comments { get; set; }
        public DateTime? ClosingDate { get; set; }
        public int FilledBy { get; set; }
        public string FilledBySyncCode { get; set; }
        public long OpenCloseProcDetailID { get; set; }
        public int FormTypeID { get; set; }
        public DateTime? TransDate { get; set; }
        public decimal Cash { get; set; }
        public decimal CreditCard { get; set; }
        public decimal Amex { get; set; }
        public decimal FCV { get; set; }
        public decimal RoomCharges { get; set; }
        public decimal KVL { get; set; }
        public decimal Vouchers { get; set; }
        public long SixEightPrintCount { get; set; }
        public long EightTenPrintCount { get; set; }
        public long PosterPrintCount { get; set; }
        public string SyncCode { get; set; }
        public DateTime? OpeningDate { get; set; }
        //public List<TransDetail> TransDetails { get; set; }
        //public List<InventoryConsumables> InventoryConsumable { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
