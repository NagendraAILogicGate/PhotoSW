using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class CameraBusiness
    {
        public bool CheckResetDPIRequired(int PhotographerId)
        {
            return false;
        }
        public bool CheckResetDPIRequired(string HR, string VR, int PhotographerId)
        {
            return false;
        }
        public string DeleteCameraDetails(int CameraId)
        {
            return "";
        }
        public List<PhotoSW.IMIX.Model.CameraInfo> GetAvailableRideCameras()
        {
            try
                {
                var obj = baCameraInfo.GetCameraInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.CameraInfo
                        {
                       // Id = p.Id,
                        DG_Camera_pkey = p.PS_Camera_pkey,
                        DG_Camera_Name = p.PS_Camera_Name,
                        DG_Camera_Make = p.PS_Camera_Make,
                        DG_AssignTo = p.PS_AssignTo,
                        DG_Camera_Start_Series = p.PS_Camera_Start_Series,
                        DG_Updatedby = p.PS_Updatedby,
                        DG_UpdatedDate = p.PS_UpdatedDate,
                        DG_Camera_IsDeleted = p.PS_Camera_IsDeleted,
                        DG_Camera_ID = p.PS_Camera_ID,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        RideCameras = p.RideCameras,
                        PhotographerName = p.PhotographerName,
                        DG_CameraFolder = p.PS_CameraFolder,
                        DG_Location_ID = p.PS_Location_ID,
                        IsChromaColor = p.IsChromaColor,
                        SubStoreId = p.SubStoreId,
                        CameraId = p.CameraId,
                        CharacterId = p.CharacterId,
                        IsTripCam = p.IsTripCam,
                        IsLiveStream = p.IsLiveStream,
                        SerialNo = p.SerialNo,
                      //  IsActive = p.IsActive

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.CameraInfo>();
                }
            // return new List<Model.CameraInfo>();
            }
        public PhotoSW.IMIX.Model.CameraInfo GetCameraByID(int CameraId)
        {
            try
                {
                var obj = baCameraInfo.GetCameraInfoData()
                    .Where(p=>p.CameraId == CameraId)
                    .Select(p => new PhotoSW.IMIX.Model.CameraInfo
                        {
                        // Id = p.Id,
                        DG_Camera_pkey = p.PS_Camera_pkey,
                        DG_Camera_Name = p.PS_Camera_Name,
                        DG_Camera_Make = p.PS_Camera_Make,
                        DG_AssignTo = p.PS_AssignTo,
                        DG_Camera_Start_Series = p.PS_Camera_Start_Series,
                        DG_Updatedby = p.PS_Updatedby,
                        DG_UpdatedDate = p.PS_UpdatedDate,
                        DG_Camera_IsDeleted = p.PS_Camera_IsDeleted,
                        DG_Camera_ID = p.PS_Camera_ID,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        RideCameras = p.RideCameras,
                        PhotographerName = p.PhotographerName,
                        DG_CameraFolder = p.PS_CameraFolder,
                        DG_Location_ID = p.PS_Location_ID,
                        IsChromaColor = p.IsChromaColor,
                        SubStoreId = p.SubStoreId,
                        CameraId = p.CameraId,
                        CharacterId = p.CharacterId,
                        IsTripCam = p.IsTripCam,
                        IsLiveStream = p.IsLiveStream,
                        SerialNo = p.SerialNo,
                        //  IsActive = p.IsActive

                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return new PhotoSW.IMIX.Model.CameraInfo();
                }
            // return new PhotoSW.IMIX.Model.CameraInfo();
            }
        public PhotoSW.IMIX.Model.CameraInfo GetCameraByPhotographerId(int PhotographerId)
        {
            try
                {
                var obj = baCameraInfo.GetCameraInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.CameraInfo
                        {
                        // Id = p.Id,
                        DG_Camera_pkey = p.PS_Camera_pkey,
                        DG_Camera_Name = p.PS_Camera_Name,
                        DG_Camera_Make = p.PS_Camera_Make,
                        DG_AssignTo = p.PS_AssignTo,
                        DG_Camera_Start_Series = p.PS_Camera_Start_Series,
                        DG_Updatedby = p.PS_Updatedby,
                        DG_UpdatedDate = p.PS_UpdatedDate,
                        DG_Camera_IsDeleted = p.PS_Camera_IsDeleted,
                        DG_Camera_ID = p.PS_Camera_ID,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        RideCameras = p.RideCameras,
                        PhotographerName = p.PhotographerName,
                        DG_CameraFolder = p.PS_CameraFolder,
                        DG_Location_ID = p.PS_Location_ID,
                        IsChromaColor = p.IsChromaColor,
                        SubStoreId = p.SubStoreId,
                        CameraId = p.CameraId,
                        CharacterId = p.CharacterId,
                        IsTripCam = p.IsTripCam,
                        IsLiveStream = p.IsLiveStream,
                        SerialNo = p.SerialNo,
                        //  IsActive = p.IsActive

                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return new PhotoSW.IMIX.Model.CameraInfo();
                }
            //  return new PhotoSW.IMIX.Model.CameraInfo();
            }
        public List<PhotoSW.IMIX.Model.CameraInfo> GetCameraList()
        {
            try
                {
                var obj = baCameraInfo.GetCameraInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.CameraInfo
                        {
                        // Id = p.Id,
                        DG_Camera_pkey = p.PS_Camera_pkey,
                        DG_Camera_Name = p.PS_Camera_Name,
                        DG_Camera_Make = p.PS_Camera_Make,
                        DG_AssignTo = p.PS_AssignTo,
                        DG_Camera_Start_Series = p.PS_Camera_Start_Series,
                        DG_Updatedby = p.PS_Updatedby,
                        DG_UpdatedDate = p.PS_UpdatedDate,
                        DG_Camera_IsDeleted = p.PS_Camera_IsDeleted,
                        DG_Camera_ID = p.PS_Camera_ID,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        RideCameras = p.RideCameras,
                        PhotographerName = p.PhotographerName,
                        DG_CameraFolder = p.PS_CameraFolder,
                        DG_Location_ID = p.PS_Location_ID,
                        IsChromaColor = p.IsChromaColor,
                        SubStoreId = p.SubStoreId,
                        CameraId = p.CameraId,
                        CharacterId = p.CharacterId,
                        IsTripCam = p.IsTripCam,
                        IsLiveStream = p.IsLiveStream,
                        SerialNo = p.SerialNo,
                        //  IsActive = p.IsActive

                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.CameraInfo>();
                }
            // return new List<PhotoSW.IMIX.Model.CameraInfo>();
            }
        public string GetCameraPathForRideCameraId(string CameraId)
        {
            return "";
        }
        public bool GetIsResetDPIRequired(int PhotoGrapherId)
        {
            return false;
        }
        public PhotoSW.IMIX.Model.CameraInfo GetLocationWiseCameraDetails(int LocationId)
        {
            try
                {
                var obj = baCameraInfo.GetCameraInfoData()
                    .Where(p => p.PS_Location_ID == LocationId)
                    .Select(p => new PhotoSW.IMIX.Model.CameraInfo
                        {
                        // Id = p.Id,
                        DG_Camera_pkey = p.PS_Camera_pkey,
                        DG_Camera_Name = p.PS_Camera_Name,
                        DG_Camera_Make = p.PS_Camera_Make,
                        DG_AssignTo = p.PS_AssignTo,
                        DG_Camera_Start_Series = p.PS_Camera_Start_Series,
                        DG_Updatedby = p.PS_Updatedby,
                        DG_UpdatedDate = p.PS_UpdatedDate,
                        DG_Camera_IsDeleted = p.PS_Camera_IsDeleted,
                        DG_Camera_ID = p.PS_Camera_ID,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        RideCameras = p.RideCameras,
                        PhotographerName = p.PhotographerName,
                        DG_CameraFolder = p.PS_CameraFolder,
                        DG_Location_ID = p.PS_Location_ID,
                        IsChromaColor = p.IsChromaColor,
                        SubStoreId = p.SubStoreId,
                        CameraId = p.CameraId,
                        CharacterId = p.CharacterId,
                        IsTripCam = p.IsTripCam,
                        IsLiveStream = p.IsLiveStream,
                        SerialNo = p.SerialNo,
                        //  IsActive = p.IsActive

                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return new PhotoSW.IMIX.Model.CameraInfo();
                }
            // return new PhotoSW.IMIX.Model.CameraInfo();
            }
        public PhotoSW.IMIX.Model.RideCameraSettingInfo GetRideCameraSetting(string CameraId)
        {
           
             return new PhotoSW.IMIX.Model.RideCameraSettingInfo();
            }
        public bool SetCameraDetails(PhotoSW.IMIX.Model.CameraInfo _objCameraInfo)
        {
            return false;
        }
        public bool SetTripCameraSetting(PhotoSW.IMIX.Model.RideCameraSettingInfo objRid)
        {
            return false;
        }
    }
}
