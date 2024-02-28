using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("SceneInfo")]

    public class sceneinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SceneId { get; set; }

        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public int BackGroundId { get; set; }

        public string BackgroundName { get; set; }

        public int BorderId { get; set; }

        public string BorderName { get; set; }

        public int GraphicsId { get; set; }

        public string GraphicName { get; set; }

        public string SyncCode { get; set; }

        public bool IsSynced { get; set; }

        //	public bool IsActive { get; set; }

        public string SceneName { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }

        }
}
