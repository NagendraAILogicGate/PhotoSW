using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoSW.CF.DataLayer.Entity;

namespace PhotoSW.CF.DataLayer.BAL
    {
    public class baPhotoCaptureInfo
        {
        public long Id { get; set; }
        public int PhotoGrapherId { get; set; }
        public string PhotoName { get; set; }
        public DateTime SysDate { get; set; }
        public DateTime CaptureDate { get; set; }
        public string PhotoGrapherName { get; set; }
        public string GroupName { get; set; }
        public string RFIDNo { get; set; }
        public string LocationName { get; set; }
        public string SubstoreName { get; set; }
        public int pkey { get; set; }
        public string CharacterId { get; set; }
        public string MetaData { get; set; }
        public int LocationId { get; set; }
        public string UniqueIdentifier { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<photocaptureinfo> lst_photocaptureinfo = new List<photocaptureinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    photocaptureinfo photocaptureinfo = new photocaptureinfo();

                    photocaptureinfo.Id = 1;
                    photocaptureinfo.PhotoGrapherId = 2;
                    photocaptureinfo.PhotoName = "";
                    photocaptureinfo.SysDate = DateTime.Now; 
                    photocaptureinfo.CaptureDate = DateTime.Now;
                    photocaptureinfo.PhotoGrapherName = "";
                    photocaptureinfo.GroupName = "";
                    photocaptureinfo.RFIDNo = "";
                    photocaptureinfo.LocationName = "";
                    photocaptureinfo.SubstoreName = "";
                    photocaptureinfo.pkey = 2;
                    photocaptureinfo.CharacterId = "";
                    photocaptureinfo.MetaData = "";
                    photocaptureinfo.LocationId = 3;
                    photocaptureinfo.UniqueIdentifier = "";
                    photocaptureinfo.IsActive = true;

                    lst_photocaptureinfo.Add(photocaptureinfo);

                    var Id = lst_photocaptureinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.PhotoCaptureInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.PhotoCaptureInfos.AddRange(lst_photocaptureinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.PhotoCaptureInfos.AddRange(lst_photocaptureinfo);
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

        public static baPhotoCaptureInfo GetPhotoCaptureInfoById ( int Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotoCaptureInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baPhotoCaptureInfo
                        {
                        Id = p.Id,
                        PhotoGrapherId = p.PhotoGrapherId,
                        PhotoName = p.PhotoName,
                        SysDate = p.SysDate,
                        CaptureDate = p.CaptureDate,
                        PhotoGrapherName = p.PhotoGrapherName,
                        GroupName = p.GroupName,
                        RFIDNo = p.RFIDNo,
                        LocationName = p.LocationName,
                        SubstoreName = p.SubstoreName,
                        pkey = p.pkey,
                        CharacterId = p.CharacterId,
                        MetaData = p.MetaData,
                        LocationId = p.LocationId,
                        UniqueIdentifier = p.UniqueIdentifier,
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

        public static List<baPhotoCaptureInfo> GetPhotoCaptureInfoData ()
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotoCaptureInfos.Where(p => p.IsActive == true).Select(p => new baPhotoCaptureInfo
                        {
                        Id = p.Id,
                        PhotoGrapherId = p.PhotoGrapherId,
                        PhotoName = p.PhotoName,
                        SysDate = p.SysDate,
                        CaptureDate = p.CaptureDate,
                        PhotoGrapherName = p.PhotoGrapherName,
                        GroupName = p.GroupName,
                        RFIDNo = p.RFIDNo,
                        LocationName = p.LocationName,
                        SubstoreName = p.SubstoreName,
                        pkey = p.pkey,
                        CharacterId = p.CharacterId,
                        MetaData = p.MetaData,
                        LocationId = p.LocationId,
                        UniqueIdentifier = p.UniqueIdentifier,
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

        public static bool Insert ( baPhotoCaptureInfo baPhotoCaptureInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    photocaptureinfo photocaptureinfo = new photocaptureinfo();

                    photocaptureinfo.Id = photocaptureinfo.Id;
                    photocaptureinfo.PhotoGrapherId = photocaptureinfo.PhotoGrapherId;
                    photocaptureinfo.PhotoName = photocaptureinfo.PhotoName;
                    photocaptureinfo.SysDate = photocaptureinfo.SysDate;
                    photocaptureinfo.CaptureDate = photocaptureinfo.CaptureDate;
                    photocaptureinfo.PhotoGrapherName = photocaptureinfo.PhotoGrapherName;
                    photocaptureinfo.GroupName = photocaptureinfo.GroupName;
                    photocaptureinfo.RFIDNo = photocaptureinfo.RFIDNo;
                    photocaptureinfo.LocationName = photocaptureinfo.LocationName;
                    photocaptureinfo.SubstoreName = photocaptureinfo.SubstoreName;
                    photocaptureinfo.pkey = photocaptureinfo.pkey;
                    photocaptureinfo.CharacterId = photocaptureinfo.CharacterId;
                    photocaptureinfo.MetaData = photocaptureinfo.MetaData;
                    photocaptureinfo.LocationId = photocaptureinfo.LocationId;
                    photocaptureinfo.UniqueIdentifier = photocaptureinfo.UniqueIdentifier;
                    photocaptureinfo.IsActive = photocaptureinfo.IsActive;

                    db.PhotoCaptureInfos.Add(photocaptureinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baPhotoCaptureInfo baPhotoCaptureInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.PhotoCaptureInfos.Where(p => p.Id == baPhotoCaptureInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        photocaptureinfo photocaptureinfo = new photocaptureinfo();

                        photocaptureinfo.Id = photocaptureinfo.Id;
                        photocaptureinfo.PhotoGrapherId = photocaptureinfo.PhotoGrapherId;
                        photocaptureinfo.PhotoName = photocaptureinfo.PhotoName;
                        photocaptureinfo.SysDate = photocaptureinfo.SysDate;
                        photocaptureinfo.CaptureDate = photocaptureinfo.CaptureDate;
                        photocaptureinfo.PhotoGrapherName = photocaptureinfo.PhotoGrapherName;
                        photocaptureinfo.GroupName = photocaptureinfo.GroupName;
                        photocaptureinfo.RFIDNo = photocaptureinfo.RFIDNo;
                        photocaptureinfo.LocationName = photocaptureinfo.LocationName;
                        photocaptureinfo.SubstoreName = photocaptureinfo.SubstoreName;
                        photocaptureinfo.pkey = photocaptureinfo.pkey;
                        photocaptureinfo.CharacterId = photocaptureinfo.CharacterId;
                        photocaptureinfo.MetaData = photocaptureinfo.MetaData;
                        photocaptureinfo.LocationId = photocaptureinfo.LocationId;
                        photocaptureinfo.UniqueIdentifier = photocaptureinfo.UniqueIdentifier;
                        photocaptureinfo.IsActive = photocaptureinfo.IsActive;

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
                    var obj = db.PhotoCaptureInfos.Where(p => p.Id == Id).FirstOrDefault();
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
