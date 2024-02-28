using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("PhotoInfo")]
	public class photoinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PS_Photos_pkey { get; set; }
        public string PS_Photos_FileName { get; set; }
        public DateTime PS_Photos_CreatedOn { get; set; }
        public string PS_Photos_RFID { get; set; }
        public int? PS_Photos_UserID { get; set; }
        public string PS_Photos_Background { get; set; }
        public string PS_Photos_Frame { get; set; }
        public DateTime? PS_Photos_DateTime { get; set; }
        public string PS_Photos_Layering { get; set; }
        public string PS_Photos_Effects { get; set; }
        public bool? PS_Photos_IsCroped { get; set; }
        public bool? PS_Photos_IsRedEye { get; set; }
        public bool? PS_Photos_IsGreen { get; set; }
        public string PS_Photos_MetaData { get; set; }
        public string PS_Photos_Sizes { get; set; }
        public bool? PS_Photos_Archive { get; set; }
        public int? PS_Location_Id { get; set; }
        public int? PS_SubStoreId { get; set; }
        public bool PS_IsCodeType { get; set; }
        public DateTime? DateTaken { get; set; }
        public int? RfidScanType { get; set; }
        public string PS_Orders_Number { get; set; }
        public int PS_Order_SubStoreId { get; set; }
        public long IMIXImageAssociationId { get; set; }
        public long PS_Group_pkey { get; set; }
        public string PS_Group_Name { get; set; }
        public int PS_Photo_ID { get; set; }
        public int? IsImageProcessed { get; set; }
        public string PS_User_Name { get; set; }
        public string HotFolderPath { get; set; }
        public string PS_Photos_CharacterID { get; set; }
        public int PS_MediaType { get; set; }
        public long? PS_VideoLength { get; set; }
        public int SemiOrderProfileId { get; set; }
        public bool IsGumRideShow { get; set; }

        public bool IsCollageShow { get; set; }
        public string OnlineQRCode { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
