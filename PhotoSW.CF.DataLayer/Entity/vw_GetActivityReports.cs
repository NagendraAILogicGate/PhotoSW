using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("vw_GetActivityReports")]
    public class vw_getactivityreports
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PS_Acitivity_Action_Pkey { get; set; }

        public int PS_Acitivity_ActionType { get; set; }

        public DateTime PS_Acitivity_Date { get; set; }

        public int PS_Acitivity_By { get; set; }

        public string PS_Acitivity_Descrption { get; set; }

        public int PS_Reference_ID { get; set; }

        public int PS_User_pkey { get; set; }

        public string PS_User_Name { get; set; }

        public string PS_User_First_Name { get; set; }

        public string PS_User_Last_Name { get; set; }

        public int PS_Actions_pkey { get; set; }

        public string PS_Actions_Name { get; set; }

        public string Name { get; set; }

        public DateTime ActivityDate { get; set; }

        public string SyncCode { get; set; }

        public bool IsSynced { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
