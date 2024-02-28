using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baRFIDImageAssociationInfo
        {
        public int Id { get; set; }
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string RFID { get; set; }
        public int Count { get; set; }
        public string PhotoIds { get; set; }
        public bool IsShowDetailActive { get; set; }
        public bool? IsActive { get; set; }


        public static bool Marge ()
            {
            List<rfidimageassociationinfo> lst_rfidimageassociationinfo = new List<rfidimageassociationinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    rfidimageassociationinfo rfidimageassociationinfo = new rfidimageassociationinfo();

                    rfidimageassociationinfo.Id = 1;
                    rfidimageassociationinfo.DeviceId = 1;
                    rfidimageassociationinfo.DeviceName = "";
                    rfidimageassociationinfo.RFID = "";
                    rfidimageassociationinfo.Count = 2;
                    rfidimageassociationinfo.PhotoIds = "";
                    rfidimageassociationinfo.IsShowDetailActive = false;
                    rfidimageassociationinfo.IsActive = true;

                    lst_rfidimageassociationinfo.Add(rfidimageassociationinfo);

                    var Id = lst_rfidimageassociationinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.RFIDImageAssociationInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.RFIDImageAssociationInfos.AddRange(lst_rfidimageassociationinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.RFIDImageAssociationInfos.AddRange(lst_rfidimageassociationinfo);
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

        public static baRFIDImageAssociationInfo GetRFIDImageAssociationInfoDataById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RFIDImageAssociationInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baRFIDImageAssociationInfo
                        {
                        Id = p.Id,
                        DeviceId = p.DeviceId,
                        DeviceName = p.DeviceName,
                        RFID = p.RFID,
                        Count = p.Count,
                        PhotoIds = p.PhotoIds,
                        IsShowDetailActive = p.IsShowDetailActive,                       
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

        public static List<baRFIDImageAssociationInfo> GetRFIDImageAssociationInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RFIDImageAssociationInfos.Where(p => p.IsActive == true).Select(p => new baRFIDImageAssociationInfo
                        {
                        Id = p.Id,
                        DeviceId = p.DeviceId,
                        DeviceName = p.DeviceName,
                        RFID = p.RFID,
                        Count = p.Count,
                        PhotoIds = p.PhotoIds,
                        IsShowDetailActive = p.IsShowDetailActive,
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


        public static bool Insert ( baRFIDImageAssociationInfo baRFIDImageAssociationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    rfidimageassociationinfo rfidimageassociationinfo = new rfidimageassociationinfo();

                    rfidimageassociationinfo.Id = baRFIDImageAssociationInfo.Id;
                    rfidimageassociationinfo.DeviceId = baRFIDImageAssociationInfo.DeviceId;
                    rfidimageassociationinfo.DeviceName = baRFIDImageAssociationInfo.DeviceName;
                    rfidimageassociationinfo.RFID = baRFIDImageAssociationInfo.RFID;
                    rfidimageassociationinfo.Count = baRFIDImageAssociationInfo.Count;
                    rfidimageassociationinfo.PhotoIds = baRFIDImageAssociationInfo.PhotoIds;
                    rfidimageassociationinfo.IsShowDetailActive = baRFIDImageAssociationInfo.IsShowDetailActive;
                    rfidimageassociationinfo.IsActive = baRFIDImageAssociationInfo.IsActive;

                    db.RFIDImageAssociationInfos.Add(rfidimageassociationinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baRFIDImageAssociationInfo baRFIDImageAssociationInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.RFIDImageAssociationInfos.Where(p => p.Id == baRFIDImageAssociationInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        rfidimageassociationinfo rfidimageassociationinfo = new rfidimageassociationinfo();

                        rfidimageassociationinfo.Id = baRFIDImageAssociationInfo.Id;
                        rfidimageassociationinfo.DeviceId = baRFIDImageAssociationInfo.DeviceId;
                        rfidimageassociationinfo.DeviceName = baRFIDImageAssociationInfo.DeviceName;
                        rfidimageassociationinfo.RFID = baRFIDImageAssociationInfo.RFID;
                        rfidimageassociationinfo.Count = baRFIDImageAssociationInfo.Count;
                        rfidimageassociationinfo.PhotoIds = baRFIDImageAssociationInfo.PhotoIds;
                        rfidimageassociationinfo.IsShowDetailActive = baRFIDImageAssociationInfo.IsShowDetailActive;
                        rfidimageassociationinfo.IsActive = baRFIDImageAssociationInfo.IsActive;

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
                    var obj = db.RFIDImageAssociationInfos.Where(p => p.Id == Id).FirstOrDefault();
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
