using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baCameraInfo
        {
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
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<camerainfo> lst_camerainfo = new List<camerainfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    camerainfo camerainfo = new camerainfo();

                    camerainfo.Id = 1;
                    camerainfo.PS_Camera_pkey = 3;
                    camerainfo.PS_Camera_Name = "";
                    camerainfo.PS_Camera_Make = "";
                    camerainfo.PS_Camera_Model = "";
                    camerainfo.PS_AssignTo = 2;
                    camerainfo.PS_Camera_Start_Series = "";
                    camerainfo.PS_Updatedby = 1;
                    camerainfo.PS_UpdatedDate = DateTime.Now;
                    camerainfo.PS_Camera_IsDeleted = false;
                    camerainfo.PS_Camera_ID = 2;
                    camerainfo.SyncCode = "";
                    camerainfo.IsSynced = true; 
                    camerainfo.RideCameras = "";
                    camerainfo.PhotographerName = "";
                    camerainfo.PS_CameraFolder = "";
                    camerainfo.PS_Location_ID = 2;
                    camerainfo.IsChromaColor = false;
                    camerainfo.SubStoreId = 3;
                    camerainfo.CameraId = 5;
                    camerainfo.CharacterId = 2;
                    camerainfo.IsTripCam = false;
                    camerainfo.IsLiveStream = false;
                    camerainfo.SerialNo = "";
                    camerainfo.IsActive = true;

                    lst_camerainfo.Add(camerainfo);

                    var Id = lst_camerainfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.CameraInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.CameraInfos.AddRange(lst_camerainfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.CameraInfos.AddRange(lst_camerainfo);
                        db.SaveChanges();
                        }
                    return true;
                    }
                }
            catch(Exception ex)
                {
                return false;
                }
            }

        public static baCameraInfo GetCameraInfoDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.CameraInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baCameraInfo
                        {
                        Id = p.Id,
                        PS_Camera_pkey = p.PS_Camera_pkey,
                        PS_Camera_Name = p.PS_Camera_Name,
                        PS_Camera_Make = p.PS_Camera_Make,
                        PS_AssignTo = p.PS_AssignTo,
                        PS_Camera_Start_Series = p.PS_Camera_Start_Series,
                        PS_Updatedby = p.PS_Updatedby,
                        PS_UpdatedDate = p.PS_UpdatedDate,
                        PS_Camera_IsDeleted = p.PS_Camera_IsDeleted,
                        PS_Camera_ID = p.PS_Camera_ID,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        RideCameras = p.RideCameras,
                        PhotographerName = p.PhotographerName,
                        PS_CameraFolder = p.PS_CameraFolder,
                        PS_Location_ID = p.PS_Location_ID,
                        IsChromaColor = p.IsChromaColor,
                        SubStoreId = p.SubStoreId,
                        CameraId = p.CameraId,
                        CharacterId = p.CharacterId,
                        IsTripCam = p.IsTripCam,
                        IsLiveStream = p.IsLiveStream,
                        SerialNo = p.SerialNo,
                        IsActive = p.IsActive
                        }).FirstOrDefault();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static List<baCameraInfo> GetCameraInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.CameraInfos.Where(p => p.IsActive == true).Select(p => new baCameraInfo
                        {
                        Id = p.Id,
                        PS_Camera_pkey = p.PS_Camera_pkey,
                        PS_Camera_Name = p.PS_Camera_Name,
                        PS_Camera_Make = p.PS_Camera_Make,
                        PS_AssignTo = p.PS_AssignTo,
                        PS_Camera_Start_Series = p.PS_Camera_Start_Series,
                        PS_Updatedby = p.PS_Updatedby,
                        PS_UpdatedDate = p.PS_UpdatedDate,
                        PS_Camera_IsDeleted = p.PS_Camera_IsDeleted,
                        PS_Camera_ID = p.PS_Camera_ID,
                        SyncCode = p.SyncCode,
                        IsSynced = p.IsSynced,
                        RideCameras = p.RideCameras,
                        PhotographerName = p.PhotographerName,
                        PS_CameraFolder = p.PS_CameraFolder,
                        PS_Location_ID = p.PS_Location_ID,
                        IsChromaColor = p.IsChromaColor,
                        SubStoreId = p.SubStoreId,
                        CameraId = p.CameraId,
                        CharacterId = p.CharacterId,
                        IsTripCam = p.IsTripCam,
                        IsLiveStream = p.IsLiveStream,
                        SerialNo = p.SerialNo,
                        IsActive = p.IsActive
                        }).ToList();
                    return obj;
                    }
                }
            catch
                {
                return null; ;
                }
            }

        public static bool Insert ( baCameraInfo baCameraInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    camerainfo camerainfo = new camerainfo();

                    camerainfo.Id = baCameraInfo.Id;
                    camerainfo.PS_Camera_pkey = baCameraInfo.PS_Camera_pkey;
                    camerainfo.PS_Camera_Name = baCameraInfo.PS_Camera_Name;
                    camerainfo.PS_Camera_Make = baCameraInfo.PS_Camera_Make;
                    camerainfo.PS_Camera_Model = baCameraInfo.PS_Camera_Model;
                    camerainfo.PS_AssignTo = baCameraInfo.PS_AssignTo;
                    camerainfo.PS_Camera_Start_Series = baCameraInfo.PS_Camera_Start_Series;
                    camerainfo.PS_Updatedby = baCameraInfo.PS_Updatedby;
                    camerainfo.PS_UpdatedDate = baCameraInfo.PS_UpdatedDate;
                    camerainfo.PS_Camera_IsDeleted = baCameraInfo.PS_Camera_IsDeleted;
                    camerainfo.PS_Camera_ID = baCameraInfo.PS_Camera_ID;
                    camerainfo.SyncCode = baCameraInfo.SyncCode;
                    camerainfo.IsSynced = baCameraInfo.IsSynced;
                    camerainfo.RideCameras = baCameraInfo.RideCameras;
                    camerainfo.PhotographerName = baCameraInfo.PhotographerName;
                    camerainfo.PS_CameraFolder = baCameraInfo.PS_CameraFolder;
                    camerainfo.PS_Location_ID = baCameraInfo.PS_Location_ID;
                    camerainfo.IsChromaColor = baCameraInfo.IsChromaColor;
                    camerainfo.SubStoreId = baCameraInfo.SubStoreId;
                    camerainfo.CameraId = baCameraInfo.CameraId;
                    camerainfo.CharacterId = baCameraInfo.CharacterId;
                    camerainfo.IsTripCam = baCameraInfo.IsTripCam;
                    camerainfo.IsLiveStream = baCameraInfo.IsLiveStream;
                    camerainfo.SerialNo = baCameraInfo.SerialNo;
                    camerainfo.IsActive = baCameraInfo.IsActive;

                    db.CameraInfos.Add(camerainfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baCameraInfo baCameraInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.CameraInfos.Where(p => p.Id == baCameraInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        camerainfo camerainfo = new camerainfo();

                        camerainfo.Id = baCameraInfo.Id;
                        camerainfo.PS_Camera_pkey = baCameraInfo.PS_Camera_pkey;
                        camerainfo.PS_Camera_Name = baCameraInfo.PS_Camera_Name;
                        camerainfo.PS_Camera_Make = baCameraInfo.PS_Camera_Make;
                        camerainfo.PS_Camera_Model = baCameraInfo.PS_Camera_Model;
                        camerainfo.PS_AssignTo = baCameraInfo.PS_AssignTo;
                        camerainfo.PS_Camera_Start_Series = baCameraInfo.PS_Camera_Start_Series;
                        camerainfo.PS_Updatedby = baCameraInfo.PS_Updatedby;
                        camerainfo.PS_UpdatedDate = baCameraInfo.PS_UpdatedDate;
                        camerainfo.PS_Camera_IsDeleted = baCameraInfo.PS_Camera_IsDeleted;
                        camerainfo.PS_Camera_ID = baCameraInfo.PS_Camera_ID;
                        camerainfo.SyncCode = baCameraInfo.SyncCode;
                        camerainfo.IsSynced = baCameraInfo.IsSynced;
                        camerainfo.RideCameras = baCameraInfo.RideCameras;
                        camerainfo.PhotographerName = baCameraInfo.PhotographerName;
                        camerainfo.PS_CameraFolder = baCameraInfo.PS_CameraFolder;
                        camerainfo.PS_Location_ID = baCameraInfo.PS_Location_ID;
                        camerainfo.IsChromaColor = baCameraInfo.IsChromaColor;
                        camerainfo.SubStoreId = baCameraInfo.SubStoreId;
                        camerainfo.CameraId = baCameraInfo.CameraId;
                        camerainfo.CharacterId = baCameraInfo.CharacterId;
                        camerainfo.IsTripCam = baCameraInfo.IsTripCam;
                        camerainfo.IsLiveStream = baCameraInfo.IsLiveStream;
                        camerainfo.SerialNo = baCameraInfo.SerialNo;
                        camerainfo.IsActive = baCameraInfo.IsActive;

                        db.SaveChanges();

                        return true;
                        }
                    else
                        {
                        return false;
                        }
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Delete ( int Id )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.CameraInfos.Where(p => p.Id == Id).FirstOrDefault();
                    if(obj != null)
                        {
                        obj.IsActive = false;
                        db.SaveChanges();

                        }
                    return true;

                    }
                }
            catch(Exception)
                {
                throw;
                }

            }


        }
    }
