using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
     [Table("ActivityInfo")]
    public class activityinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int PS_Acitivity_Action_Pkey { get; set; }
        public int PS_Acitivity_ActionType { get; set; }
        public DateTime PS_Acitivity_Date { get; set; }
        public int PS_Acitivity_By { get; set; }
        public string PS_Acitivity_Descrption { get; set; }
        public int PS_Reference_ID { get; set; }     
        public int PS_Actions_pkey { get; set; }
        public string PS_Actions_Name { get; set; }
        public string Name { get; set; }
        public DateTime ActivityDate { get; set; }
        public string SyncCode { get; set; }
        public bool IsSynced { get; set; }
        public string Version { get; set; }
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
