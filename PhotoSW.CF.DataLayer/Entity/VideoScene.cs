using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("VideoScene")]
    public class videoscene
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int SceneId { get; set; }

        public string Name { get; set; }

        public string ScenePath { get; set; }

        public int LocationId { get; set; }

        public string Settings { get; set; }

        public int VideoLength { get; set; }

       // public bool IsActive { get; set; }

        public bool IsActiveForAdvanceProcessing { get; set; }

        public string IsActiveForAdvanceProcessingStatus { get; set; }

        public string LocationName { get; set; }

        public bool IsMixerScene { get; set; }

        public int CG_ConfigID { get; set; }

        public List<videosceneobject> lstVideoSceneObject { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }
        }
}
