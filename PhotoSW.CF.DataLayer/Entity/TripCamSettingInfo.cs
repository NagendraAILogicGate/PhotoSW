using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("TripCamSettingInfo")]
    public class tripcamsettinginfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int TripCamValueId { get; set; }

        public long TripCamSettingsMasterId { get; set; }

        public string SettingsValue { get; set; }

        public int CameraId { get; set; }

        public DateTime ModifiedDate { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
