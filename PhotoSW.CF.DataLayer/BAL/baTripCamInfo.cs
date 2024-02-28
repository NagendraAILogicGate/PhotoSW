using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baTripCamInfo
        {
        public int Id { get; set; }
        public int Camera_pKey { get; set; }
        public string CameraModel { get; set; }
        public string CameraFolderpath { get; set; }
        public int TripCamTypeId { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<tripcaminfo> lst_tripcaminfo = new List<tripcaminfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    tripcaminfo tripcaminfo = new tripcaminfo();

                    tripcaminfo.Id = 1;
                    tripcaminfo.Camera_pKey = 5;
                    tripcaminfo.CameraModel = "";
                    tripcaminfo.CameraFolderpath = "";
                    tripcaminfo.TripCamTypeId = 5;
                    tripcaminfo.IsActive = true;

                    lst_tripcaminfo.Add(tripcaminfo);

                    var Id = lst_tripcaminfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.TripCamInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.TripCamInfos.AddRange(lst_tripcaminfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.TripCamInfos.AddRange(lst_tripcaminfo);
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

        public static baTripCamInfo GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.TripCamInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baTripCamInfo
                        {
                        Id = p.Id,
                        Camera_pKey = p.Camera_pKey,
                        CameraModel = p.CameraModel,
                        CameraFolderpath = p.CameraFolderpath,
                        TripCamTypeId = p.TripCamTypeId,
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

        public static List<baTripCamInfo> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.TripCamInfos.Where(p => p.IsActive == true).Select(p => new baTripCamInfo
                        {
                        Id = p.Id,
                        Camera_pKey = p.Camera_pKey,
                        CameraModel = p.CameraModel,
                        CameraFolderpath = p.CameraFolderpath,
                        TripCamTypeId = p.TripCamTypeId,
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


        public static bool Insert ( baTripCamInfo baTripCamInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    tripcaminfo tripcaminfo = new tripcaminfo();

                    tripcaminfo.Id = baTripCamInfo.Id;
                    tripcaminfo.Camera_pKey = baTripCamInfo.Camera_pKey;
                    tripcaminfo.CameraModel = baTripCamInfo.CameraModel;
                    tripcaminfo.CameraFolderpath = baTripCamInfo.CameraFolderpath;
                    tripcaminfo.TripCamTypeId = baTripCamInfo.TripCamTypeId;
                    tripcaminfo.IsActive = baTripCamInfo.IsActive;

                    db.TripCamInfos.Add(tripcaminfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baTripCamInfo baTripCamInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.TripCamInfos.Where(p => p.Id == baTripCamInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        tripcaminfo tripcaminfo = new tripcaminfo();

                        tripcaminfo.Id = baTripCamInfo.Id;
                        tripcaminfo.Camera_pKey = baTripCamInfo.Camera_pKey;
                        tripcaminfo.CameraModel = baTripCamInfo.CameraModel;
                        tripcaminfo.CameraFolderpath = baTripCamInfo.CameraFolderpath;
                        tripcaminfo.TripCamTypeId = baTripCamInfo.TripCamTypeId;
                        tripcaminfo.IsActive = baTripCamInfo.IsActive;

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
                    var obj = db.TripCamInfos.Where(p => p.Id == Id).FirstOrDefault();
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
