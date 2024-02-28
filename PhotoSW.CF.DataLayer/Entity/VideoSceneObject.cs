using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("VideoSceneObject")]
    public class videosceneobject
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int VideoObject_Pkey { get; set; }

        public string VideoObjectId { get; set; }

        public int SceneId { get; set; }

        public bool GuestVideoObject { get; set; }

     //   public videoobjectfilemapping ObjectFileMapping { get; set; }

        public bool streamAudioEnabled { get; set; }

        public string FileName { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }

        }
}
