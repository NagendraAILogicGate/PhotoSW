using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baSvcRunningInfo
        {
        public int Id { get; set; }
        public string ServiceName { get; set; }
        public string SystemName { get; set; }
        public long ServicePOSMappingID { get; set; }
        public DateTime LastStatusOnDate { get; set; }
        public string Status { get; set; }
        public string SubStoreName { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<svcrunninginfo> lst_svcrunninginfo = new List<svcrunninginfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    svcrunninginfo svcrunninginfo = new svcrunninginfo();

                    svcrunninginfo.Id = 1;
                    svcrunninginfo.ServiceName = "";
                    svcrunninginfo.SystemName = "";
                    svcrunninginfo.ServicePOSMappingID = 5;
                    svcrunninginfo.LastStatusOnDate = DateTime.Now;
                    svcrunninginfo.Status = "";
                    svcrunninginfo.SubStoreName = "";
                    svcrunninginfo.IsActive = true;

                    lst_svcrunninginfo.Add(svcrunninginfo);

                    var Id = lst_svcrunninginfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SvcRunningInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.SvcRunningInfos.AddRange(lst_svcrunninginfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.SvcRunningInfos.AddRange(lst_svcrunninginfo);
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

        public static baSvcRunningInfo GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SvcRunningInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSvcRunningInfo
                        {
                        Id = p.Id,
                        ServiceName = p.ServiceName,
                        SystemName = p.SystemName,
                        ServicePOSMappingID = p.ServicePOSMappingID,
                        LastStatusOnDate = p.LastStatusOnDate,
                        Status = p.Status,
                        SubStoreName = p.SubStoreName,
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

        public static List<baSvcRunningInfo> GetSvcRunningInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SvcRunningInfos.Where(p => p.IsActive == true).Select(p => new baSvcRunningInfo
                        {
                        Id = p.Id,
                        ServiceName = p.ServiceName,
                        SystemName = p.SystemName,
                        ServicePOSMappingID = p.ServicePOSMappingID,
                        LastStatusOnDate = p.LastStatusOnDate,
                        Status = p.Status,
                        SubStoreName = p.SubStoreName,
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


        public static bool Insert ( baSvcRunningInfo baSvcRunningInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    svcrunninginfo svcrunninginfo = new svcrunninginfo();

                    svcrunninginfo.Id = baSvcRunningInfo.Id;
                    svcrunninginfo.ServiceName = baSvcRunningInfo.ServiceName;
                    svcrunninginfo.SystemName = baSvcRunningInfo.SystemName;
                    svcrunninginfo.ServicePOSMappingID = baSvcRunningInfo.ServicePOSMappingID;
                    svcrunninginfo.LastStatusOnDate = baSvcRunningInfo.LastStatusOnDate;
                    svcrunninginfo.Status = baSvcRunningInfo.Status;
                    svcrunninginfo.SubStoreName = baSvcRunningInfo.SubStoreName;
                    svcrunninginfo.IsActive = baSvcRunningInfo.IsActive;

                    db.SvcRunningInfos.Add(svcrunninginfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSvcRunningInfo baSvcRunningInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SvcRunningInfos.Where(p => p.Id == baSvcRunningInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        svcrunninginfo svcrunninginfo = new svcrunninginfo();

                        svcrunninginfo.Id = baSvcRunningInfo.Id;
                        svcrunninginfo.ServiceName = baSvcRunningInfo.ServiceName;
                        svcrunninginfo.SystemName = baSvcRunningInfo.SystemName;
                        svcrunninginfo.ServicePOSMappingID = baSvcRunningInfo.ServicePOSMappingID;
                        svcrunninginfo.LastStatusOnDate = baSvcRunningInfo.LastStatusOnDate;
                        svcrunninginfo.Status = baSvcRunningInfo.Status;
                        svcrunninginfo.SubStoreName = baSvcRunningInfo.SubStoreName;
                        svcrunninginfo.IsActive = baSvcRunningInfo.IsActive;


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
                    var obj = db.SvcRunningInfos.Where(p => p.Id == Id).FirstOrDefault();
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
