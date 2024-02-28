using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("CameraInfo")]
    public class camerainfo
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public int PS_Camera_pkey { get; set; }

        public string PS_Camera_Name { get; set; }

        public string PS_Camera_Make { get; set; }

        public string PS_Camera_Model { get; set; }

        public int? PS_AssignTo { get; set; }

        public string PS_Camera_Start_Series { get; set; }

        public int PS_Updatedby { get; set; }

        public DateTime PS_UpdatedDate { get; set; }

        public bool? PS_Camera_IsDeleted { get; set; }

        public int? PS_Camera_ID { get; set; }

        public string SyncCode { get; set; }

        public bool IsSynced { get; set; }

        public string RideCameras { get; set; }

        public string PhotographerName { get; set; }

        public string PS_CameraFolder { get; set; }

        public int PS_Location_ID { get; set; }

        public bool? IsChromaColor { get; set; }

        public int SubStoreId { get; set; }

        public int CameraId { get; set; }

        public int? CharacterId { get; set; }

        public bool? IsTripCam { get; set; }

        public bool? IsLiveStream { get; set; }

        public string SerialNo { get; set; }

        [System.ComponentModel.DefaultValue(true)]
        public bool? IsActive { get; set; }
        }
}
