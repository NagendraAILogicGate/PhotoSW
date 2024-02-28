using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("VideoConfigProfiles")]
    public class videoconfigprofiles
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long ProfileId { get; set; }

        public string ProfileName { get; set; }

        public string AspectRatio { get; set; }

        public int FrameRate { get; set; }

        public string OutputFormat { get; set; }

        public string VideoCodec { get; set; }

        public string AudioCodec { get; set; }

        public string AutoVideoEffects { get; set; }

        public int LocationId { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool IsActive { get; set; }

        }
}
