using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class TripCamBusiness
    {
        public List<PhotoSW.IMIX.Model.TripCamSettingInfo> GetSavedTripCamSettingsForCameraId(int Cameraid) 
        {
            return new List<PhotoSW.IMIX.Model.TripCamSettingInfo>();
        }
        public PhotoSW.IMIX.Model.TripCamInfo GetTripCameraInfoById(string CameraName, string CameraId) 
        {
            return new PhotoSW.IMIX.Model.TripCamInfo();
        }
        public List<PhotoSW.IMIX.Model.TripCamSettingInfo> GetTripCamSettingsForCameraId(int CameraId, int TripCamTypeId)
        {
            return new  List<PhotoSW.IMIX.Model.TripCamSettingInfo>();
        }
        public bool InsUpdTripCamSettings(PhotoSW.IMIX.Model.TripCamFeaturesInfo tripCamFeaturesInfo, int CamId)
        {
            return false;
        }
        public bool UpdCamIdForTripCamPOSMapping(int oldCamId, int NewCamid)
        {
            return false;
        }
        public bool ValidateCameraAvailability(string CamMake)
        {
            return false;
        }
        public bool ValidateCameraRunningStatus(string CamMake)
        {
            return false;
        }
    }
}
