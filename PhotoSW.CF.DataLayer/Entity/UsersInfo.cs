using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("UsersInfo")]
	public class usersinfo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int PS_User_pkey { get; set; }
        public string PS_User_Name { get; set; }
        public string PS_User_First_Name { get; set; }
        public string PS_User_Last_Name { get; set; }
        public string PS_User_Password { get; set; }
        public int PS_User_Roles_Id { get; set; }
        public int PS_Location_ID { get; set; }
        public bool? PS_User_Status { get; set; }
        public string PS_User_PhoneNo { get; set; }
        public string PS_User_Email { get; set; }
        public DateTime? User_CreatedDate { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public string User_Role { get; set; }
        public string Location_Name { get; set; }
        public int Store_ID { get; set; }
        public int Location_pkey { get; set; }
        public string UserName { get; set; }
        public string StatusName { get; set; }
        public string Store_Name { get; set; }
        public string CountryCode { get; set; }
        public string StoreCode { get; set; }
        public string UserFullName { get; set; }
        public int Substore_ID { get; set; }
        public string ServerHotFolderPath { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
