using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("CharacterInfo")]
    public class characterinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		public int PS_Character_Pkey { get; set; }
        public string PS_Character_Name { get; set; }
        public int PS_Character_IsActive { get; set; }

        public DateTime PS_Character_CreatedDate { get; set; }

        public int PS_Character_OperationType { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
