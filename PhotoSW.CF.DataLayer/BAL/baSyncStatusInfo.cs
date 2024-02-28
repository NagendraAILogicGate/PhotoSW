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
	public class baSyncStatusInfo
    {
        public long Id { get; set; }
        public string Syncstatus { get; set; }
        public string SyncOrderNumber { get; set; }
        public string QRCode { get; set; }
        public DateTime? SyncOrderdate { get; set; }
        public string PhotoRfid { get; set; }
        public DateTime? Syncdate { get; set; }
        public string syncDateDisplay { get; set; }
        public int DGOrderspkey { get; set; }
        public int SyncStatusID { get; set; }
        public bool? IsAvailable { get; set; }
        public long ChangeTrackingId { get; set; }
        public string ImageSynced { get; set; }
        public long SyncFormID { get; set; }
        public DateTime SyncFormTransDate { get; set; }
        public string Form { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge()
        {
            List<syncstatusinfo> lst_syncstatusinfo = new List<syncstatusinfo>();
            try
            {
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    //foreach (var item in lst_str)
                    //{
                    syncstatusinfo syncstatusinfo = new syncstatusinfo();

                    syncstatusinfo.Syncstatus = "";
                    syncstatusinfo.SyncOrderNumber = "";
                    syncstatusinfo.QRCode = "";
                    syncstatusinfo.SyncOrderdate = null;
                    syncstatusinfo.PhotoRfid = "";
                    syncstatusinfo.Syncdate = null;
                    //syncstatusinfo.SyncDateDisplay =
                    //syncstatusinfo.PSOrderspkey =
                    syncstatusinfo.SyncStatusID = 1;
                    syncstatusinfo.IsAvailable = true;
                    syncstatusinfo.ChangeTrackingId = 1;
                    syncstatusinfo.ImageSynced = "";
                    syncstatusinfo.SyncFormID = 1;
                    syncstatusinfo.SyncFormTransDate = DateTime.Now;
                    syncstatusinfo.Form = "";
                    syncstatusinfo.IsActive = true;
                    lst_syncstatusinfo.Add(syncstatusinfo);

                    // }
                    var Id = lst_syncstatusinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.SyncStatusInfos.Where(p => p.Id == Id).ToList();
                    if (IsExist == null)
                    {
                        db.SyncStatusInfos.AddRange(lst_syncstatusinfo);
                        db.SaveChanges();
                    }
                    else if (IsExist.Count == 0)
                    {
                        db.SyncStatusInfos.AddRange(lst_syncstatusinfo);
                        db.SaveChanges();
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public static baSyncStatusInfo GetSyncStatusInfoDataById ( int Id)
        {
            try
            {

                substorelocationinfo substorelocationinfo = new substorelocationinfo();
                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SyncStatusInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baSyncStatusInfo
                    {
                        Id = p.Id,
                        Syncstatus = p.Syncstatus,
                        SyncOrderNumber = p.SyncOrderNumber,
                        QRCode = p.QRCode,
                        SyncOrderdate = p.SyncOrderdate,
                        PhotoRfid = p.PhotoRfid,
                        Syncdate = p.Syncdate,
                        //SyncDateDisplay =
                        //PSOrderspkey =
                         SyncStatusID = p.SyncStatusID,
                         IsAvailable = p.IsAvailable,
                         ChangeTrackingId = p.ChangeTrackingId,
                         ImageSynced = p.ImageSynced,
                         SyncFormID = p.SyncFormID,
                         SyncFormTransDate =p.SyncFormTransDate,
                         Form = p.Form,
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
        public static List<baSyncStatusInfo> GetSyncStatusInfoData ()
        {
            try
            {

                using (PhotoSWEntities db = new PhotoSWEntities())
                {
                    var obj = db.SyncStatusInfos.Where(p => p.IsActive == true).Select(p => new baSyncStatusInfo
                    {
                        Id = p.Id,
                        Syncstatus = p.Syncstatus,
                        SyncOrderNumber = p.SyncOrderNumber,
                        QRCode = p.QRCode,
                        SyncOrderdate = p.SyncOrderdate,
                        PhotoRfid = p.PhotoRfid,
                        Syncdate = p.Syncdate,
                        SyncStatusID = p.SyncStatusID,
                        IsAvailable = p.IsAvailable,
                        ChangeTrackingId = p.ChangeTrackingId,
                        ImageSynced = p.ImageSynced,
                        SyncFormID = p.SyncFormID,
                        SyncFormTransDate = p.SyncFormTransDate,
                        Form = p.Form,
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


        public static bool Insert ( baSyncStatusInfo baSyncStatusInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    syncstatusinfo syncstatusinfo = new syncstatusinfo();

                    syncstatusinfo.Id = baSyncStatusInfo.Id;
                    syncstatusinfo.Syncstatus = baSyncStatusInfo.Syncstatus;
                    syncstatusinfo.SyncOrderNumber = baSyncStatusInfo.SyncOrderNumber;
                    syncstatusinfo.QRCode = baSyncStatusInfo.QRCode;
                    syncstatusinfo.SyncOrderdate = baSyncStatusInfo.SyncOrderdate;
                    syncstatusinfo.PhotoRfid = baSyncStatusInfo.PhotoRfid;
                    syncstatusinfo.Syncdate = baSyncStatusInfo.Syncdate;
                    syncstatusinfo.SyncStatusID = baSyncStatusInfo.SyncStatusID;
                    syncstatusinfo.IsAvailable = baSyncStatusInfo.IsAvailable;
                    syncstatusinfo.ChangeTrackingId = baSyncStatusInfo.ChangeTrackingId;
                    syncstatusinfo.ImageSynced = baSyncStatusInfo.ImageSynced;
                    syncstatusinfo.SyncFormID = baSyncStatusInfo.SyncFormID;
                    syncstatusinfo.SyncFormTransDate = baSyncStatusInfo.SyncFormTransDate;
                    syncstatusinfo.Form = baSyncStatusInfo.Form;
                    syncstatusinfo.IsActive = baSyncStatusInfo.IsActive;

                    db.SyncStatusInfos.Add(syncstatusinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baSyncStatusInfo baSyncStatusInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.SyncStatusInfos.Where(p => p.Id == baSyncStatusInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        syncstatusinfo syncstatusinfo = new syncstatusinfo();

                        syncstatusinfo.Id = baSyncStatusInfo.Id;
                        syncstatusinfo.Syncstatus = baSyncStatusInfo.Syncstatus;
                        syncstatusinfo.SyncOrderNumber = baSyncStatusInfo.SyncOrderNumber;
                        syncstatusinfo.QRCode = baSyncStatusInfo.QRCode;
                        syncstatusinfo.SyncOrderdate = baSyncStatusInfo.SyncOrderdate;
                        syncstatusinfo.PhotoRfid = baSyncStatusInfo.PhotoRfid;
                        syncstatusinfo.Syncdate = baSyncStatusInfo.Syncdate;
                        syncstatusinfo.SyncStatusID = baSyncStatusInfo.SyncStatusID;
                        syncstatusinfo.IsAvailable = baSyncStatusInfo.IsAvailable;
                        syncstatusinfo.ChangeTrackingId = baSyncStatusInfo.ChangeTrackingId;
                        syncstatusinfo.ImageSynced = baSyncStatusInfo.ImageSynced;
                        syncstatusinfo.SyncFormID = baSyncStatusInfo.SyncFormID;
                        syncstatusinfo.SyncFormTransDate = baSyncStatusInfo.SyncFormTransDate;
                        syncstatusinfo.Form = baSyncStatusInfo.Form;
                        syncstatusinfo.IsActive = baSyncStatusInfo.IsActive;

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
                    var obj = db.SyncStatusInfos.Where(p => p.Id == Id).FirstOrDefault();
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
