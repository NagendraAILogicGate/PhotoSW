using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baRFIDTagInfo
        {
        public int Id { get; set; }
        public int IdentifierId { get; set; }
        public int DeviceID { get; set; }
        public string TagId { get; set; }
        public DateTime? ScanningTime { get; set; }
        public int Status { get; set; }
        public string RawData { get; set; }
        public string SerialNo { get; set; }
        public int DummyRFIDTagID { get; set; }
        public DateTime? CreatedOn { get; set; }
        public bool IsActive { get; set; }


        public static bool Marge ()
            {
            List<rfidtaginfo> lst_rfidtaginfo = new List<rfidtaginfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    rfidtaginfo rfidtaginfo = new rfidtaginfo();

                    rfidtaginfo.Id = 1;
                    rfidtaginfo.IdentifierId = 1;
                    rfidtaginfo.DeviceID = 2;
                    rfidtaginfo.TagId = "";
                    rfidtaginfo.ScanningTime = DateTime.Now;
                    rfidtaginfo.Status = 3;
                    rfidtaginfo.RawData = "";
                    rfidtaginfo.SerialNo = "";
                    rfidtaginfo.DummyRFIDTagID = 5;
                    rfidtaginfo.CreatedOn = DateTime.Now;
                    rfidtaginfo.IsActive = true;

                    lst_rfidtaginfo.Add(rfidtaginfo);

                    var Id = lst_rfidtaginfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.RFIDTagInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.RFIDTagInfos.AddRange(lst_rfidtaginfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.RFIDTagInfos.AddRange(lst_rfidtaginfo);
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

        public static baRFIDTagInfo GetRFIDTagInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RFIDTagInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baRFIDTagInfo
                        {
                        Id = p.Id,
                        IdentifierId = p.IdentifierId,
                        DeviceID = p.DeviceID,
                        TagId = p.TagId,
                        ScanningTime = p.ScanningTime,
                        Status = p.Status,
                        RawData = p.RawData,
                        SerialNo = p.SerialNo,
                        DummyRFIDTagID = p.DummyRFIDTagID,
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

        public static List<baRFIDTagInfo> GetRFIDTagInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RFIDTagInfos.Where(p => p.IsActive == true).Select(p => new baRFIDTagInfo
                        {
                        Id = p.Id,
                        IdentifierId = p.IdentifierId,
                        DeviceID = p.DeviceID,
                        TagId = p.TagId,
                        ScanningTime = p.ScanningTime,
                        Status = p.Status,
                        RawData = p.RawData,
                        SerialNo = p.SerialNo,
                        DummyRFIDTagID = p.DummyRFIDTagID,
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

        public static bool Insert ( baRFIDTagInfo baRFIDTagInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    rfidtaginfo rfidtaginfo = new rfidtaginfo();

                    rfidtaginfo.Id = baRFIDTagInfo.Id;
                    rfidtaginfo.IdentifierId = baRFIDTagInfo.IdentifierId;
                    rfidtaginfo.DeviceID = baRFIDTagInfo.DeviceID;
                    rfidtaginfo.TagId = baRFIDTagInfo.TagId;
                    rfidtaginfo.ScanningTime = baRFIDTagInfo.ScanningTime;
                    rfidtaginfo.Status = baRFIDTagInfo.Status;
                    rfidtaginfo.RawData = baRFIDTagInfo.RawData;
                    rfidtaginfo.SerialNo = baRFIDTagInfo.SerialNo;
                    rfidtaginfo.DummyRFIDTagID = rfidtaginfo.DummyRFIDTagID;
                    rfidtaginfo.CreatedOn = baRFIDTagInfo.CreatedOn;
                    rfidtaginfo.IsActive = baRFIDTagInfo.IsActive;

                    db.RFIDTagInfos.Add(rfidtaginfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baRFIDTagInfo baRFIDTagInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RFIDTagInfos.Where(p => p.Id == baRFIDTagInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        rfidtaginfo rfidtaginfo = new rfidtaginfo();

                        rfidtaginfo.Id = baRFIDTagInfo.Id;
                        rfidtaginfo.IdentifierId = baRFIDTagInfo.IdentifierId;
                        rfidtaginfo.DeviceID = baRFIDTagInfo.DeviceID;
                        rfidtaginfo.TagId = baRFIDTagInfo.TagId;
                        rfidtaginfo.ScanningTime = baRFIDTagInfo.ScanningTime;
                        rfidtaginfo.Status = baRFIDTagInfo.Status;
                        rfidtaginfo.RawData = baRFIDTagInfo.RawData;
                        rfidtaginfo.SerialNo = baRFIDTagInfo.SerialNo;
                        rfidtaginfo.DummyRFIDTagID = rfidtaginfo.DummyRFIDTagID;
                        rfidtaginfo.CreatedOn = baRFIDTagInfo.CreatedOn;
                        rfidtaginfo.IsActive = baRFIDTagInfo.IsActive;

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
                    var obj = db.RFIDTagInfos.Where(p => p.Id == Id).FirstOrDefault();
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
