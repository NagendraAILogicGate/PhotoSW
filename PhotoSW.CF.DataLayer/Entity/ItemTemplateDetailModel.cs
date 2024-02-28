using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ItemTemplateDetailModel")]
    public class itemtemplatedetailmodel
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public int AssociationPhotoId { get; set; }

        public string AssociationPhotoName { get; set; }

        public string AssociationPhotoFileName { get; set; }

        public string AssociationPhotoFilePath { get; set; }

        public int FileOrder { get; set; }

     //   public int Id { get; set; }

        public int MasterTemplateId { get; set; }

        public int TemplateType { get; set; }

        public string FileName { get; set; }

        public string FilePath { get; set; }

        public int Status { get; set; }

        public int I1_X1 { get; set; }

        public int I1_Y1 { get; set; }

        public int I1_X2 { get; set; }

        public int I1_Y2 { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
