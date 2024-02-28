using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class DeviceManager
    {
        public bool DeleteCameraDeviceAssociation(int cameraId)
        {
            return false;
        }
        public int DeleteCameraDeviceSyncDetails(int CameraId, string DeviceIds)
        {
            return 0;
        }
        public bool DeleteDevice(int deviceId)
        {
            return false;
        }
        public List<PhotoSW.IMIX.Model.CameraDeviceAssociationInfo> GetCameraDeviceList()
        {
            return new List<PhotoSW.IMIX.Model.CameraDeviceAssociationInfo>();
        }
        public List<PhotoSW.IMIX.Model.CameraDeviceAssociationInfo> GetCameraDeviceList(int CameraId)
        {
            try
                {
                var obj = baCameraDeviceAssociationInfo.GetCameraDeviceAssociationInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.CameraDeviceAssociationInfo()
                        {
                        DeviceId = p.DeviceId,
                        CameraId = p.CameraId
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.CameraDeviceAssociationInfo>();
                }

            //  return new List<PhotoSW.IMIX.Model.CameraDeviceAssociationInfo>();
            }
        public List<PhotoSW.IMIX.Model.DeviceInfo> GetDevice(int DeviceId)
        {
            try
                {
                var obj = baDeviceInfo.GetDeviceInfoData()
                    .Where(p=>p.DeviceId == DeviceId)
                    .Select(p => new PhotoSW.IMIX.Model.DeviceInfo()
                        {
                        DeviceId = p.DeviceId,
                        Name = p.Name,
                        BDA = p.BDA,
                        SerialNo = p.SerialNo,
                        DeviceTypeId = p.DeviceTypeId,
                        DeviceTypeName = p.DeviceTypeName,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        IsChecked = p.IsChecked,
                        DeviceSessionId = p.DeviceSessionId
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.DeviceInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.DeviceInfo>();
            }
        public List<PhotoSW.IMIX.Model.DeviceInfo> GetDeviceList()
        {
            try
                {
                var obj = baDeviceInfo.GetDeviceInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.DeviceInfo()
                        {
                        DeviceId = p.DeviceId,
                        Name = p.Name,
                        BDA = p.BDA,
                        SerialNo = p.SerialNo,
                        DeviceTypeId = p.DeviceTypeId,
                        DeviceTypeName = p.DeviceTypeName,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        IsChecked = p.IsChecked,
                        DeviceSessionId = p.DeviceSessionId
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.DeviceInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.DeviceInfo>();
            }
        public List<PhotoSW.IMIX.Model.DeviceInfo> GetPhotoGrapherDeviceList(int photographerId)
        {
            try
                {
                var obj = baDeviceInfo.GetDeviceInfoData()                    
                    .Select(p => new PhotoSW.IMIX.Model.DeviceInfo()
                        {
                        DeviceId = p.DeviceId,
                        Name = p.Name,
                        BDA = p.BDA,
                        SerialNo = p.SerialNo,
                        DeviceTypeId = p.DeviceTypeId,
                        DeviceTypeName = p.DeviceTypeName,
                        CreatedBy = p.CreatedBy,
                        CreatedDate = p.CreatedDate,
                        IsChecked = p.IsChecked,
                        DeviceSessionId = p.DeviceSessionId
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.DeviceInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.DeviceInfo>();
            }
        public bool IsDeviceAssociatedToOthers(int CameraId, string DeviceIds)
        {
            return false;
        }
        public bool SaveCameraCharacterAssociation(int CameraId, int Camerapkey, int? CharacterIds)
        {
            return false;
        }
        public bool SaveCameraDeviceAssociation(int CameraId, string DeviceIds)
        {
            return false;
        }
        public bool SaveDevice(PhotoSW.IMIX.Model.DeviceInfo device)
        {
            return false;
        }
    }
}
