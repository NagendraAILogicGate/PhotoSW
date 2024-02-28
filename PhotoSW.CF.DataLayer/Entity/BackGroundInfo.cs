using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
  
namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("BackGroundInfo")]
	public class backgroundinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int BackgroundId { get; set; }
        public int ProductId { get; set; }
        public string BackgroundImageName { get; set; }
        public string BackgroundImageDisplayName { get; set; }
        public int? BackgroundGroupId { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public string BackgroundPath { get; set; }
        public bool? BackgroundIsActive { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
