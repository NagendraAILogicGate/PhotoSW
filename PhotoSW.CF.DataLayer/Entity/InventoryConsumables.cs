using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("InventoryConsumables")]
    public class inventoryconsumables
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

      //  [XmlIgnore]
		public long InventoryConsumablesID { get; set; }

        public long AccessoryID { get; set; }

        public long ConsumeValue { get; set; }

       // [XmlIgnore]
		public string AccessoryName { get; set; }

        public string AccessorySyncCode { get; set; }

        public string AccessoryCode { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
