using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ServicesInfo")]

    public class servicesinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int PS_Service_Id { get; set; }

        public string PS_Sevice_Name { get; set; }

        public string PS_Service_Display_Name { get; set; }

        public string PS_Service_Path { get; set; }

        public bool? IsInterface { get; set; }

        public long RunLevel { get; set; }

        public bool IsService { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
