
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("TransDetail")]
    public class transdetail
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		public long TransDetailID { get; set; }

		public int SubstoreID { get; set; }

        public DateTime TransDate { get; set; }

        public int PackageID { get; set; }

        public string PackageSyncCode { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal Quantity { get; set; }

        public decimal Discount { get; set; }

        public decimal Total { get; set; }

        public string PackageCode { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
