using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baRfidFlushHistotyInfo
        {
        public int Id { get; set; }
        public int FlushId { get; set; }
        public DateTime? ScheduleDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Status { get; set; }
        public string ErrorMessage { get; set; }
        public int SubStoreId { get; set; }
        public string StrStatus { get; set; }
        public string SubStore { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<rfidflushhistotyinfo> lst_rfidflushhistotyinfo = new List<rfidflushhistotyinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    rfidflushhistotyinfo rfidflushhistotyinfo = new rfidflushhistotyinfo();

                    rfidflushhistotyinfo.Id = 1;
                    rfidflushhistotyinfo.FlushId = 1;
                    rfidflushhistotyinfo.ScheduleDate = DateTime.Now;
                    rfidflushhistotyinfo.StartDate = DateTime.Now;
                    rfidflushhistotyinfo.EndDate = DateTime.Now;
                    rfidflushhistotyinfo.Status = 5;
                    rfidflushhistotyinfo.ErrorMessage = "";
                    rfidflushhistotyinfo.SubStoreId = 2;
                    rfidflushhistotyinfo.StrStatus = "";
                    rfidflushhistotyinfo.SubStore = "";
                    rfidflushhistotyinfo.LocationId = 5;
                    rfidflushhistotyinfo.LocationName = "";
                    rfidflushhistotyinfo.IsActive = true;

                    lst_rfidflushhistotyinfo.Add(rfidflushhistotyinfo);

                    var Id = lst_rfidflushhistotyinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.RfidFlushHistotyInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.RfidFlushHistotyInfos.AddRange(lst_rfidflushhistotyinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.RfidFlushHistotyInfos.AddRange(lst_rfidflushhistotyinfo);
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

        public static baRfidFlushHistotyInfo GetRfidFlushHistotyInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RfidFlushHistotyInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baRfidFlushHistotyInfo
                        {
                        Id = p.Id,
                        FlushId = p.FlushId,
                        ScheduleDate = p.ScheduleDate,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        Status = p.Status,
                        ErrorMessage = p.ErrorMessage,
                        SubStoreId = p.SubStoreId,
                        StrStatus = p.StrStatus,
                        SubStore = p.SubStore,
                        LocationId = p.LocationId,
                        LocationName = p.LocationName,
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

        public static List<baRfidFlushHistotyInfo> GetRfidFlushHistotyInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RfidFlushHistotyInfos.Where(p => p.IsActive == true).Select(p => new baRfidFlushHistotyInfo
                        {
                        Id = p.Id,
                        FlushId = p.FlushId,
                        ScheduleDate = p.ScheduleDate,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        Status = p.Status,
                        ErrorMessage = p.ErrorMessage,
                        SubStoreId = p.SubStoreId,
                        StrStatus = p.StrStatus,
                        SubStore = p.SubStore,
                        LocationId = p.LocationId,
                        LocationName = p.LocationName,
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

        public static bool Insert ( baRfidFlushHistotyInfo baRfidFlushHistotyInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    rfidflushhistotyinfo rfidflushhistotyinfo = new rfidflushhistotyinfo();

                    rfidflushhistotyinfo.Id = rfidflushhistotyinfo.Id;
                    rfidflushhistotyinfo.FlushId = rfidflushhistotyinfo.FlushId;
                    rfidflushhistotyinfo.ScheduleDate = rfidflushhistotyinfo.ScheduleDate;
                    rfidflushhistotyinfo.StartDate = rfidflushhistotyinfo.StartDate;
                    rfidflushhistotyinfo.EndDate = rfidflushhistotyinfo.EndDate;
                    rfidflushhistotyinfo.Status = rfidflushhistotyinfo.Status;
                    rfidflushhistotyinfo.ErrorMessage = rfidflushhistotyinfo.ErrorMessage;
                    rfidflushhistotyinfo.SubStoreId = rfidflushhistotyinfo.SubStoreId;
                    rfidflushhistotyinfo.StrStatus = rfidflushhistotyinfo.StrStatus;
                    rfidflushhistotyinfo.SubStore = rfidflushhistotyinfo.SubStore;
                    rfidflushhistotyinfo.LocationId = rfidflushhistotyinfo.LocationId;
                    rfidflushhistotyinfo.LocationName = rfidflushhistotyinfo.LocationName;
                    rfidflushhistotyinfo.IsActive = rfidflushhistotyinfo.IsActive;

                    db.RfidFlushHistotyInfos.Add(rfidflushhistotyinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baRfidFlushHistotyInfo baRfidFlushHistotyInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RfidFlushHistotyInfos.Where(p => p.Id == baRfidFlushHistotyInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        rfidflushhistotyinfo rfidflushhistotyinfo = new rfidflushhistotyinfo();

                        rfidflushhistotyinfo.Id = rfidflushhistotyinfo.Id;
                        rfidflushhistotyinfo.FlushId = rfidflushhistotyinfo.FlushId;
                        rfidflushhistotyinfo.ScheduleDate = rfidflushhistotyinfo.ScheduleDate;
                        rfidflushhistotyinfo.StartDate = rfidflushhistotyinfo.StartDate;
                        rfidflushhistotyinfo.EndDate = rfidflushhistotyinfo.EndDate;
                        rfidflushhistotyinfo.Status = rfidflushhistotyinfo.Status;
                        rfidflushhistotyinfo.ErrorMessage = rfidflushhistotyinfo.ErrorMessage;
                        rfidflushhistotyinfo.SubStoreId = rfidflushhistotyinfo.SubStoreId;
                        rfidflushhistotyinfo.StrStatus = rfidflushhistotyinfo.StrStatus;
                        rfidflushhistotyinfo.SubStore = rfidflushhistotyinfo.SubStore;
                        rfidflushhistotyinfo.LocationId = rfidflushhistotyinfo.LocationId;
                        rfidflushhistotyinfo.LocationName = rfidflushhistotyinfo.LocationName;
                        rfidflushhistotyinfo.IsActive = rfidflushhistotyinfo.IsActive;

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
                    var obj = db.RfidFlushHistotyInfos.Where(p => p.Id == Id).FirstOrDefault();
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
