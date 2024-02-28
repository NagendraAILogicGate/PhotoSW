using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baTripCamSettingInfo
        {
        public int Id { get; set; }
        public int TripCamValueId { get; set; }
        public long TripCamSettingsMasterId { get; set; }
        public string SettingsValue { get; set; }
        public int CameraId { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<tripcamsettinginfo> lst_tripcamsettinginfo = new List<tripcamsettinginfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    tripcamsettinginfo tripcamsettinginfo = new tripcamsettinginfo();

                    tripcamsettinginfo.Id = 1;
                    tripcamsettinginfo.TripCamValueId = 5;
                    tripcamsettinginfo.TripCamSettingsMasterId = 8;
                    tripcamsettinginfo.SettingsValue = "";
                    tripcamsettinginfo.CameraId = 5;
                    tripcamsettinginfo.ModifiedDate = DateTime.Now;
                    tripcamsettinginfo.IsActive = true;

                    lst_tripcamsettinginfo.Add(tripcamsettinginfo);

                    var Id = lst_tripcamsettinginfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.TripCamSettingInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.TripCamSettingInfos.AddRange(lst_tripcamsettinginfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.TripCamSettingInfos.AddRange(lst_tripcamsettinginfo);
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

        public static baTripCamSettingInfo GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.TripCamSettingInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baTripCamSettingInfo
                        {
                        Id = p.Id,
                        TripCamValueId = p.TripCamValueId,
                        TripCamSettingsMasterId = p.TripCamSettingsMasterId,
                        SettingsValue = p.SettingsValue,
                        CameraId = p.CameraId,
                        ModifiedDate = p.ModifiedDate,
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

        public static List<baTripCamSettingInfo> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.TripCamSettingInfos.Where(p => p.IsActive == true).Select(p => new baTripCamSettingInfo
                        {
                        Id = p.Id,
                        TripCamValueId = p.TripCamValueId,
                        TripCamSettingsMasterId = p.TripCamSettingsMasterId,
                        SettingsValue = p.SettingsValue,
                        CameraId = p.CameraId,
                        ModifiedDate = p.ModifiedDate,
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

        public static bool Insert ( baTripCamSettingInfo baTripCamSettingInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    tripcamsettinginfo tripcamsettinginfo = new tripcamsettinginfo();

                    tripcamsettinginfo.Id = baTripCamSettingInfo.Id;
                    tripcamsettinginfo.TripCamValueId = baTripCamSettingInfo.TripCamValueId;
                    tripcamsettinginfo.TripCamSettingsMasterId = baTripCamSettingInfo.TripCamSettingsMasterId;
                    tripcamsettinginfo.SettingsValue = baTripCamSettingInfo.SettingsValue;
                    tripcamsettinginfo.CameraId = baTripCamSettingInfo.CameraId;
                    tripcamsettinginfo.ModifiedDate = baTripCamSettingInfo.ModifiedDate;
                    tripcamsettinginfo.IsActive = baTripCamSettingInfo.IsActive;

                    db.TripCamSettingInfos.Add(tripcamsettinginfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baTripCamSettingInfo baTripCamSettingInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.TripCamSettingInfos.Where(p => p.Id == baTripCamSettingInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        tripcamsettinginfo tripcamsettinginfo = new tripcamsettinginfo();

                        tripcamsettinginfo.Id = baTripCamSettingInfo.Id;
                        tripcamsettinginfo.TripCamValueId = baTripCamSettingInfo.TripCamValueId;
                        tripcamsettinginfo.TripCamSettingsMasterId = baTripCamSettingInfo.TripCamSettingsMasterId;
                        tripcamsettinginfo.SettingsValue = baTripCamSettingInfo.SettingsValue;
                        tripcamsettinginfo.CameraId = baTripCamSettingInfo.CameraId;
                        tripcamsettinginfo.ModifiedDate = baTripCamSettingInfo.ModifiedDate;
                        tripcamsettinginfo.IsActive = baTripCamSettingInfo.IsActive;

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
                    var obj = db.TripCamSettingInfos.Where(p => p.Id == Id).FirstOrDefault();
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
