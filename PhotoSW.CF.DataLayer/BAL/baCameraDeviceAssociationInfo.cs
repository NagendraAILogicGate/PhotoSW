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
    public class baCameraDeviceAssociationInfo
        {
        public long Id { get; set; }
        public int DeviceId { get; set; }
        public int CameraId { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<cameradeviceassociationinfo> lst_cameradeviceassociationinfo = new List<cameradeviceassociationinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    cameradeviceassociationinfo burnorderinfo = new cameradeviceassociationinfo();

                    burnorderinfo.Id = 1;
                    burnorderinfo.DeviceId = 3;
                    burnorderinfo.CameraId = 2;                   
                    burnorderinfo.IsActive = true;

                    lst_cameradeviceassociationinfo.Add(burnorderinfo);

                    var Id = lst_cameradeviceassociationinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.CameraDeviceAssociationInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.CameraDeviceAssociationInfos.AddRange(lst_cameradeviceassociationinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.CameraDeviceAssociationInfos.AddRange(lst_cameradeviceassociationinfo);
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

        public static baCameraDeviceAssociationInfo GetCameraDeviceAssociationInfoById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.CameraDeviceAssociationInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baCameraDeviceAssociationInfo
                        {
                        Id = p.Id,
                        DeviceId = p.DeviceId,
                        CameraId = p.CameraId,                      
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

        public static List<baCameraDeviceAssociationInfo> GetCameraDeviceAssociationInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.CameraDeviceAssociationInfos.Where(p => p.IsActive == true).Select(p => new baCameraDeviceAssociationInfo
                        {
                        Id = p.Id,
                        DeviceId = p.DeviceId,
                        CameraId = p.CameraId,
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

        public static bool Insert ( baCameraDeviceAssociationInfo baCameraDeviceAssociationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    cameradeviceassociationinfo cameradeviceassociationinfo = new cameradeviceassociationinfo();

                    cameradeviceassociationinfo.Id = baCameraDeviceAssociationInfo.Id;
                    cameradeviceassociationinfo.DeviceId = baCameraDeviceAssociationInfo.DeviceId;
                    cameradeviceassociationinfo.CameraId = baCameraDeviceAssociationInfo.CameraId;
                    cameradeviceassociationinfo.IsActive = baCameraDeviceAssociationInfo.IsActive;

                    db.CameraDeviceAssociationInfos.Add(cameradeviceassociationinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baCameraDeviceAssociationInfo baCameraDeviceAssociationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.CameraDeviceAssociationInfos.Where(p => p.Id == baCameraDeviceAssociationInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        cameradeviceassociationinfo cameradeviceassociationinfo = new cameradeviceassociationinfo();
                        cameradeviceassociationinfo.Id = baCameraDeviceAssociationInfo.Id;
                        cameradeviceassociationinfo.DeviceId = baCameraDeviceAssociationInfo.DeviceId;
                        cameradeviceassociationinfo.CameraId = baCameraDeviceAssociationInfo.CameraId;
                        cameradeviceassociationinfo.IsActive = baCameraDeviceAssociationInfo.IsActive;

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
                    var obj = db.CameraDeviceAssociationInfos.Where(p => p.Id == Id).FirstOrDefault();
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
