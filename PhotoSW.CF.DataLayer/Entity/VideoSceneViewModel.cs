using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("VideoSceneViewModel")]
    public class videosceneviewmodel
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public videoscene VideoScene { get; set; }

        public videosceneobject VideoSceneObject { get; set; }

        public List<videosceneobject> ListVideoSceneObject { get; set; }

        public List<videoobjectfilemapping> ListVideoObjectFileMapping { get; set; }

        public videoobjectfilemapping VideoObjectFileMapping { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }
        }
}
