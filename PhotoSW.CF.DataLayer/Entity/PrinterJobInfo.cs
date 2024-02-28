using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("PrinterJobInfo")]
    public class printerjobinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        private string JobName;

		private int JobId;

		private string JobStatus;

		private string Printername;

		private long ImageId;

		private string Filepath;

		public string PS_Orders_ProductType_Name { get; set; }

        public string PS_Orders_Number { get; set; }

        public string RFID { get; set; }

        public int PS_Orders_LineItems_pkey { get; set; }

        public string PhotoID { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
