using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("FolderStructureInfo")]
    public class folderdsructureinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string HotFolderPath { get; set; }

        public string BorderPath { get; set; }

        public string BackgroundPath { get; set; }

        public string GraphicPath { get; set; }

        public string CroppedPath { get; set; }

        public string EditedImagePath { get; set; }

        public string ThumbnailsPath { get; set; }

        public string BigThumbnailsPath { get; set; }

        public string PrintImagesPath { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
