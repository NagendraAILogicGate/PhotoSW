using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ItemTemplatePrintOrderModel")]
    public class itemtemplateprintordermodel
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

     //   public int Id { get; set; }

        public int OrderLineItemId { get; set; }

        public int MasterTemplateId { get; set; }

        public int DetailTemplateId { get; set; }

        public int PrintTypeId { get; set; }

        public int PhotoId { get; set; }

        public int PageNo { get; set; }

        public int PrintPosition { get; set; }

        public int RotationAngle { get; set; }

        public int Status { get; set; }

        public int PrinterQueueId { get; set; }

        public string CreatedBy { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
