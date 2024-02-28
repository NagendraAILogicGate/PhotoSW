using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("PhotoDetail")]
    public class photodetail
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int PhotoId { get; set; }
        public string FileName { get; set; }
        public DateTime PS_Photos_CreatedOn { get; set; }
        public string PhotoRFID { get; set; }
        public string Layering { get; set; }
        public string Effects { get; set; }
        public bool IsCropped { get; set; }
        public bool IsGreen { get; set; }
        public int LocationId { get; set; }
        public int SubstoreId { get; set; }
        public bool IsEnabled { get; set; }
        public bool IsChecked { get; set; }
        public string HotFolderPath { get; set; }
        public int MediaType { get; set; }
        public int PhotoGrapherId { get; set; }
        public long VideoLength { get; set; }
        public int PhotoIdSequence { get; set; }
        public int SemiOrderProfileId { get; set; }
        public bool? IsGumRideShow { get; set; }
      
        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
