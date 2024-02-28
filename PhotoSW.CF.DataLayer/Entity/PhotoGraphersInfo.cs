using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{
    [Table("PhotoGraphersInfo")]
	public class photographersinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string CountryCode { get; set; }
        public string PS_Location_Name { get; set; }
        public int PS_Location_pkey { get; set; }
        public int PS_Store_ID { get; set; }
        public string PS_Store_Name { get; set; }
        public int PS_Substore_ID { get; set; }
        public string PS_User_Email { get; set; }
        public string PS_User_First_Name { get; set; }
        public string PS_User_Last_Name { get; set; }
        public string PS_User_Name { get; set; }
        public string PS_User_Password { get; set; }
        public string PS_User_PhoneNo { get; set; }
        public int PS_User_pkey { get; set; }
        public string PS_User_Role { get; set; }
        public int PS_User_Roles_Id { get; set; }
        public bool? PS_User_Status { get; set; }
        public string FullName { get; set; }
        public string Photograper { get; set; }
        public string StatusName { get; set; }
        public string StoreCode { get; set; }
        public string UserName { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
	}
}
