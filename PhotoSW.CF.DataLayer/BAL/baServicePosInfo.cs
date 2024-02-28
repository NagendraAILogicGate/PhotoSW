using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baServicePosInfo
        {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public long ImixPosId { get; set; }
        public int SubstoreId { get; set; }
        public string ServiceName { get; set; }
        public string SystemName { get; set; }
        public string SubStoremName { get; set; }
        public string UniqueCode { get; set; }
        public int RunLevel { get; set; }
        public string Status { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<serviceposinfo> lst_serviceposinfo = new List<serviceposinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    serviceposinfo serviceposinfo = new serviceposinfo();

                    serviceposinfo.Id = 1;
                    serviceposinfo.ServiceId = 1;
                    serviceposinfo.ImixPosId = 5;
                    serviceposinfo.ServiceName = "";
                    serviceposinfo.SystemName = "";
                    serviceposinfo.SubStoremName = "";
                    serviceposinfo.UniqueCode = "";
                    serviceposinfo.RunLevel = 5;
                    serviceposinfo.Status = "";
                    serviceposinfo.IsActive = true;

                    lst_serviceposinfo.Add(serviceposinfo);

                    var Id = lst_serviceposinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ServicePosInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ServicePosInfos.AddRange(lst_serviceposinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ServicePosInfos.AddRange(lst_serviceposinfo);
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

        public static baServicePosInfo GetServicePosInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServicePosInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baServicePosInfo
                        {
                        Id = p.Id,
                        ServiceId = p.ServiceId,
                        ImixPosId = p.ImixPosId,
                        SubstoreId = p.SubstoreId,
                        ServiceName = p.ServiceName,
                        SystemName = p.SystemName,
                        SubStoremName = p.SubStoremName,
                        UniqueCode = p.UniqueCode,
                        RunLevel = p.RunLevel,
                        Status = p.Status,
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

        public static List<baServicePosInfo> GetServicePosInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServicePosInfos.Where(p => p.IsActive == true).Select(p => new baServicePosInfo
                        {
                        Id = p.Id,
                        ServiceId = p.ServiceId,
                        ImixPosId = p.ImixPosId,
                        SubstoreId = p.SubstoreId,
                        ServiceName = p.ServiceName,
                        SystemName = p.SystemName,
                        SubStoremName = p.SubStoremName,
                        UniqueCode = p.UniqueCode,
                        RunLevel = p.RunLevel,
                        Status = p.Status,
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


        public static bool Insert ( baServicePosInfo baServicePosInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    serviceposinfo serviceposinfo = new serviceposinfo();

                    serviceposinfo.Id = baServicePosInfo.Id;
                    serviceposinfo.ServiceId = baServicePosInfo.ServiceId;
                    serviceposinfo.ImixPosId = baServicePosInfo.ImixPosId;
                    serviceposinfo.ServiceName = baServicePosInfo.ServiceName;
                    serviceposinfo.SystemName = baServicePosInfo.SystemName;
                    serviceposinfo.SubStoremName = baServicePosInfo.SubStoremName;
                    serviceposinfo.UniqueCode = baServicePosInfo.UniqueCode;
                    serviceposinfo.RunLevel = baServicePosInfo.RunLevel;
                    serviceposinfo.Status = baServicePosInfo.Status;
                    serviceposinfo.IsActive = baServicePosInfo.IsActive;

                    db.ServicePosInfos.Add(serviceposinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baServicePosInfo baServicePosInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServicePosInfos.Where(p => p.Id == baServicePosInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        serviceposinfo serviceposinfo = new serviceposinfo();

                        serviceposinfo.Id = baServicePosInfo.Id;
                        serviceposinfo.ServiceId = baServicePosInfo.ServiceId;
                        serviceposinfo.ImixPosId = baServicePosInfo.ImixPosId;
                        serviceposinfo.ServiceName = baServicePosInfo.ServiceName;
                        serviceposinfo.SystemName = baServicePosInfo.SystemName;
                        serviceposinfo.SubStoremName = baServicePosInfo.SubStoremName;
                        serviceposinfo.UniqueCode = baServicePosInfo.UniqueCode;
                        serviceposinfo.RunLevel = baServicePosInfo.RunLevel;
                        serviceposinfo.Status = baServicePosInfo.Status;
                        serviceposinfo.IsActive = baServicePosInfo.IsActive;

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
                    var obj = db.ServicePosInfos.Where(p => p.Id == Id).FirstOrDefault();
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
