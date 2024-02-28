using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
     public class baServiceRunningHistory
        {
        public int Id { get; set; }
        public long ServiceRunningHistoryId { get; set; }
        public long ServiceID { get; set; }
        public long ImixPOSDetailID { get; set; }
        public DateTime LastStatusOnDate { get; set; }
        public bool Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<servicerunninghistory> lst_servicerunninghistory = new List<servicerunninghistory>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    servicerunninghistory servicerunninghistory = new servicerunninghistory();

                    servicerunninghistory.Id = 1;
                    servicerunninghistory.ServiceRunningHistoryId = 1;
                    servicerunninghistory.ServiceID = 5;
                    servicerunninghistory.ImixPOSDetailID = 2;
                    servicerunninghistory.LastStatusOnDate = DateTime.Now;
                    servicerunninghistory.CreatedBy = "";
                    servicerunninghistory.CreatedOn = DateTime.Now;
                    servicerunninghistory.IsActive = true;

                    lst_servicerunninghistory.Add(servicerunninghistory);

                    var Id = lst_servicerunninghistory.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ServiceRunningHistorys.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ServiceRunningHistorys.AddRange(lst_servicerunninghistory);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ServiceRunningHistorys.AddRange(lst_servicerunninghistory);
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

        public static baServiceRunningHistory GetPhotoGroupInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServiceRunningHistorys.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baServiceRunningHistory
                        {
                        Id = p.Id,
                        ServiceRunningHistoryId = p.ServiceRunningHistoryId,
                        ServiceID = p.ServiceID,
                        ImixPOSDetailID = p.ImixPOSDetailID,
                        LastStatusOnDate = p.LastStatusOnDate,
                        Status = p.Status,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
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

        public static List<baServiceRunningHistory> GetPhotoGroupInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServiceRunningHistorys.Where(p => p.IsActive == true).Select(p => new baServiceRunningHistory
                        {
                        Id = p.Id,
                        ServiceRunningHistoryId = p.ServiceRunningHistoryId,
                        ServiceID = p.ServiceID,
                        ImixPOSDetailID = p.ImixPOSDetailID,
                        LastStatusOnDate = p.LastStatusOnDate,
                        Status = p.Status,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
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


        public static bool Insert ( baServiceRunningHistory baServiceRunningHistory )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    servicerunninghistory servicerunninghistory = new servicerunninghistory();

                    servicerunninghistory.Id = baServiceRunningHistory.Id;
                    servicerunninghistory.ServiceRunningHistoryId = baServiceRunningHistory.ServiceRunningHistoryId;
                    servicerunninghistory.ServiceID = baServiceRunningHistory.ServiceID;
                    servicerunninghistory.ImixPOSDetailID = baServiceRunningHistory.ImixPOSDetailID;
                    servicerunninghistory.LastStatusOnDate = baServiceRunningHistory.LastStatusOnDate;
                    servicerunninghistory.CreatedBy = baServiceRunningHistory.CreatedBy;
                    servicerunninghistory.CreatedOn = baServiceRunningHistory.CreatedOn;
                    servicerunninghistory.IsActive = baServiceRunningHistory.IsActive;

                    db.ServiceRunningHistorys.Add(servicerunninghistory);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baServiceRunningHistory baServiceRunningHistory )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ServiceRunningHistorys.Where(p => p.Id == baServiceRunningHistory.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        servicerunninghistory servicerunninghistory = new servicerunninghistory();

                        servicerunninghistory.Id = baServiceRunningHistory.Id;
                        servicerunninghistory.ServiceRunningHistoryId = baServiceRunningHistory.ServiceRunningHistoryId;
                        servicerunninghistory.ServiceID = baServiceRunningHistory.ServiceID;
                        servicerunninghistory.ImixPOSDetailID = baServiceRunningHistory.ImixPOSDetailID;
                        servicerunninghistory.LastStatusOnDate = baServiceRunningHistory.LastStatusOnDate;
                        servicerunninghistory.CreatedBy = baServiceRunningHistory.CreatedBy;
                        servicerunninghistory.CreatedOn = baServiceRunningHistory.CreatedOn;
                        servicerunninghistory.IsActive = baServiceRunningHistory.IsActive;

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
                    var obj = db.ServiceRunningHistorys.Where(p => p.Id == Id).FirstOrDefault();
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
