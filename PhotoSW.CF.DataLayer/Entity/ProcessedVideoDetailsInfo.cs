using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("ProcessedVideoDetailsInfo")]
    public class processedvideodetailsinfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public long ProcessedVideoDetailId { get; set; }

        public int ProcessedVideoId { get; set; }

        public int FrameTime { get; set; }

        public int DisplayTime { get; set; }

        public long MediaId { get; set; }

        public int MediaType { get; set; }

        public int JoiningOrder { get; set; }

        public int StartTime { get; set; }

        public int EndTime { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
