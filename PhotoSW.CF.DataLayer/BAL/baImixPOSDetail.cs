using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baImixPOSDetail
        {
        public long Id { get; set; }
        public long ImixPOSDetailID { get; set; }
        public string SystemName { get; set; }
        public string IPAddress { get; set; }
        public string MacAddress { get; set; }
        public long SubStoreID { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime UpdatedOn { get; set; }
        public bool IsStart { get; set; }
        public DateTime StartStopTime { get; set; }
        public string SyncCode { get; set; }
        public bool IsActive { get; set; }

        public static bool Marge ()
            {
            List<imixposdetail> lst_imixposdetail = new List<imixposdetail>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    imixposdetail imixposdetail = new imixposdetail();

                    imixposdetail.Id = 1;
                    imixposdetail.ImixPOSDetailID = 2;
                    imixposdetail.SystemName = "";
                    imixposdetail.IPAddress = "";
                    imixposdetail.MacAddress = "";
                    imixposdetail.SubStoreID = 4;
                    imixposdetail.CreatedBy = "";
                    imixposdetail.CreatedOn = DateTime.Now;
                    imixposdetail.UpdatedBy = "";
                    imixposdetail.UpdatedOn = DateTime.Now;
                    imixposdetail.IsStart = false;
                    imixposdetail.StartStopTime = DateTime.Now;
                    imixposdetail.SyncCode = "";
                    imixposdetail.IsActive = true;

                    lst_imixposdetail.Add(imixposdetail);

                    var Id = lst_imixposdetail.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.ImixPOSDetails.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.ImixPOSDetails.AddRange(lst_imixposdetail);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.ImixPOSDetails.AddRange(lst_imixposdetail);
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

        public static baImixPOSDetail GetImixPOSDetailInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ImixPOSDetails.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baImixPOSDetail
                        {
                        Id = p.Id,
                        ImixPOSDetailID = p.ImixPOSDetailID,
                        SystemName = p.SystemName,
                        IPAddress = p.IPAddress,
                        MacAddress = p.MacAddress,
                        SubStoreID = p.SubStoreID,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        UpdatedBy = p.UpdatedBy,
                        UpdatedOn = p.UpdatedOn,
                        IsStart = p.IsStart,
                        StartStopTime = p.StartStopTime,
                        SyncCode = p.SyncCode,
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

        public static List<baImixPOSDetail> GetImixPOSDetailData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ImixPOSDetails.Where(p => p.IsActive == true).Select(p => new baImixPOSDetail
                        {
                        Id = p.Id,
                        ImixPOSDetailID = p.ImixPOSDetailID,
                        SystemName = p.SystemName,
                        IPAddress = p.IPAddress,
                        MacAddress = p.MacAddress,
                        SubStoreID = p.SubStoreID,
                        CreatedBy = p.CreatedBy,
                        CreatedOn = p.CreatedOn,
                        UpdatedBy = p.UpdatedBy,
                        UpdatedOn = p.UpdatedOn,
                        IsStart = p.IsStart,
                        StartStopTime = p.StartStopTime,
                        SyncCode = p.SyncCode,
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

        public static bool Insert ( baImixPOSDetail baImixPOSDetail )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    imixposdetail imixposdetail = new imixposdetail();

                    imixposdetail.Id = baImixPOSDetail.Id;
                    imixposdetail.ImixPOSDetailID = baImixPOSDetail.ImixPOSDetailID;
                    imixposdetail.SystemName = baImixPOSDetail.SystemName;
                    imixposdetail.IPAddress = baImixPOSDetail.IPAddress;
                    imixposdetail.MacAddress = baImixPOSDetail.MacAddress;
                    imixposdetail.SubStoreID = baImixPOSDetail.SubStoreID;
                    imixposdetail.CreatedBy = baImixPOSDetail.CreatedBy;
                    imixposdetail.CreatedOn = baImixPOSDetail.CreatedOn;
                    imixposdetail.UpdatedBy = baImixPOSDetail.UpdatedBy;
                    imixposdetail.UpdatedOn = baImixPOSDetail.UpdatedOn;
                    imixposdetail.IsStart = baImixPOSDetail.IsStart;
                    imixposdetail.StartStopTime = baImixPOSDetail.StartStopTime;
                    imixposdetail.SyncCode = baImixPOSDetail.SyncCode;
                    imixposdetail.IsActive = baImixPOSDetail.IsActive;

                    db.ImixPOSDetails.Add(imixposdetail);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baImixPOSDetail baImixPOSDetail )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.ImixPOSDetails.Where(p => p.Id == baImixPOSDetail.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        imixposdetail imixposdetail = new imixposdetail();

                        imixposdetail.Id = baImixPOSDetail.Id;
                        imixposdetail.ImixPOSDetailID = baImixPOSDetail.ImixPOSDetailID;
                        imixposdetail.SystemName = baImixPOSDetail.SystemName;
                        imixposdetail.IPAddress = baImixPOSDetail.IPAddress;
                        imixposdetail.MacAddress = baImixPOSDetail.MacAddress;
                        imixposdetail.SubStoreID = baImixPOSDetail.SubStoreID;
                        imixposdetail.CreatedBy = baImixPOSDetail.CreatedBy;
                        imixposdetail.CreatedOn = baImixPOSDetail.CreatedOn;
                        imixposdetail.UpdatedBy = baImixPOSDetail.UpdatedBy;
                        imixposdetail.UpdatedOn = baImixPOSDetail.UpdatedOn;
                        imixposdetail.IsStart = baImixPOSDetail.IsStart;
                        imixposdetail.StartStopTime = baImixPOSDetail.StartStopTime;
                        imixposdetail.SyncCode = baImixPOSDetail.SyncCode;
                        imixposdetail.IsActive = baImixPOSDetail.IsActive;

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
                    var obj = db.ImixPOSDetails.Where(p => p.Id == Id).FirstOrDefault();
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
