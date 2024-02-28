using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
{

    //
   
    [Table("User")]
    public class user
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int User_pkey { get; set; }
        public string User_Name { get; set; }
        public string User_First_Name { get; set; }
        public string User_Last_Name { get; set; }
        public string User_Password { get; set; }
        public int User_Roles_Id { get; set; }
        public int Location_ID { get; set; }
        public bool? User_Status { get; set; }
        public string User_PhoneNo { get; set; }
        public string User_Email { get; set; }
        public string SyncCode { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }


    }
}
