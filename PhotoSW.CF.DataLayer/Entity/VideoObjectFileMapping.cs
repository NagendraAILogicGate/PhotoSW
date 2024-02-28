using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("VideoObjectFileMapping")]
    public class videoobjectfilemapping
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

       // public int ID { get; set; }

        public string VideoSceneObjectId { get; set; }

        public int ValueTypeId { get; set; }

        public string ChromaPath { get; set; }

        public string RoutePath { get; set; }

        public string StreamAudioEnabled { get; set; }

        public string ResourcePath { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }
        }
}
