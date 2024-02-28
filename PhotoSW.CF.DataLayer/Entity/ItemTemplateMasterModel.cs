using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ItemTemplateMasterModel")]
    public class itemtemplatemastermodel
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int SubtemplateCount { get; set; }

        public int PathType { get; set; }

        public int TemplateType { get; set; }

        public string ThumbnailImagePath { get; set; }

        public string ThumbnailImageName { get; set; }

        public int Status { get; set; }

        public string BasePath { get; set; }

        public List<itemtemplatedetailmodel> ItemTemplateDetailList { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
