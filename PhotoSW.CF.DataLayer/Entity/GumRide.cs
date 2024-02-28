using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("GumRide")]
    public class gumride
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public int Locationid { get; set; }

        public string LocationName { get; set; }

        public decimal FontSize { get; set; }

        public string FontColor { get; set; }

        public string FontWeight { get; set; }

        public string BackgroundColor { get; set; }

        public string Margin { get; set; }

        public string FilePath { get; set; }

        public string PhotoPath { get; set; }

        public string IsGumbleRideActive { get; set; }

        public string Position { get; set; }

        public string IsSpecGumbRide { get; set; }

        public string FontStyle { get; set; }

        public string FontFamily { get; set; }

        public string TimeOut { get; set; }

        public string IsPrefixActiveFlow { get; set; }

        public string PrefixPhotoName { get; set; }

        public string PrefixScoreFileName { get; set; }

        public string GumballScoreSeperater { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }

        }
}
