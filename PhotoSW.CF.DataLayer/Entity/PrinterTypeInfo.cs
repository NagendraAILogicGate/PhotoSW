using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("PrinterTypeInfo")]
    public class printertypeinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      //  public long Id { get; set; }

        public int PrinterTypeID { get; set; }

        public string PrinterType { get; set; }

        public int ProductTypeID { get; set; }

        public string ProductName { get; set; }

      //  public bool IsActive { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }

        }
}
