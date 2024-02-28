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
    public class baEmailStatusInfo
        {
        public long Id { get; set; }
        public int PS_Email_pkey { get; set; }
        public string OrderId { get; set; }
        public string EmailId { get; set; }
        public string PhotoId { get; set; }
        public int Status { get; set; }
        public DateTime EmailDateTime { get; set; }
        public string StatusDetail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool? IsAvailable { get; set; }
        public string MediaName { get; set; }
        public string PhotoCount { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<emailstatusinfo> lst_emailstatusinfo = new List<emailstatusinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    emailstatusinfo emailstatusinfo = new emailstatusinfo();

                    emailstatusinfo.Id = 1;
                    emailstatusinfo.PS_Email_pkey = 2;
                    emailstatusinfo.OrderId = "";
                    emailstatusinfo.EmailId = "";
                    emailstatusinfo.PhotoId = "";
                    emailstatusinfo.Status = 1;
                    emailstatusinfo.EmailDateTime = DateTime.Now;
                    emailstatusinfo.StatusDetail = "";
                    emailstatusinfo.StartDate = DateTime.Now;
                    emailstatusinfo.EndDate = DateTime.Now;
                    emailstatusinfo.IsAvailable = false;
                    emailstatusinfo.MediaName = "";
                    emailstatusinfo.PhotoCount = "";
                    emailstatusinfo.IsActive = true;

                    lst_emailstatusinfo.Add(emailstatusinfo);

                    var Id = lst_emailstatusinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.EmailStatusInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.EmailStatusInfos.AddRange(lst_emailstatusinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.EmailStatusInfos.AddRange(lst_emailstatusinfo);
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

        public static baEmailStatusInfo GetEmailStatusInfoDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.EmailStatusInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baEmailStatusInfo
                        {
                        Id = p.Id,
                        PS_Email_pkey = p.PS_Email_pkey,
                        OrderId = p.OrderId,
                        EmailId = p.EmailId,
                        PhotoId = p.PhotoId,
                        Status = p.Status,
                        EmailDateTime = p.EmailDateTime,
                        StatusDetail = p.StatusDetail,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        IsAvailable = p.IsAvailable,
                        MediaName = p.MediaName,
                        PhotoCount = p.PhotoCount,
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

        public static List<baEmailStatusInfo> GetEmailStatusInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.EmailStatusInfos.Where(p => p.IsActive == true).Select(p => new baEmailStatusInfo
                        {
                        Id = p.Id,
                        PS_Email_pkey = p.PS_Email_pkey,
                        OrderId = p.OrderId,
                        EmailId = p.EmailId,
                        PhotoId = p.PhotoId,
                        Status = p.Status,
                        EmailDateTime = p.EmailDateTime,
                        StatusDetail = p.StatusDetail,
                        StartDate = p.StartDate,
                        EndDate = p.EndDate,
                        IsAvailable = p.IsAvailable,
                        MediaName = p.MediaName,
                        PhotoCount = p.PhotoCount,
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

        public static bool Insert ( baEmailStatusInfo baEmailStatusInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    emailstatusinfo emailstatusinfo = new emailstatusinfo();

                    emailstatusinfo.Id = baEmailStatusInfo.Id;
                    emailstatusinfo.PS_Email_pkey = baEmailStatusInfo.PS_Email_pkey;
                    emailstatusinfo.OrderId = baEmailStatusInfo.OrderId;
                    emailstatusinfo.EmailId = baEmailStatusInfo.EmailId;
                    emailstatusinfo.PhotoId = baEmailStatusInfo.PhotoId;
                    emailstatusinfo.Status = baEmailStatusInfo.Status;
                    emailstatusinfo.EmailDateTime = baEmailStatusInfo.EmailDateTime;
                    emailstatusinfo.StatusDetail = baEmailStatusInfo.StatusDetail;
                    emailstatusinfo.StartDate = baEmailStatusInfo.StartDate;
                    emailstatusinfo.EndDate = baEmailStatusInfo.EndDate;
                    emailstatusinfo.IsAvailable = baEmailStatusInfo.IsAvailable;
                    emailstatusinfo.MediaName = baEmailStatusInfo.MediaName;
                    emailstatusinfo.PhotoCount = baEmailStatusInfo.PhotoCount;
                    emailstatusinfo.IsActive = baEmailStatusInfo.IsActive;

                    db.EmailStatusInfos.Add(emailstatusinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baEmailStatusInfo baEmailStatusInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.EmailStatusInfos.Where(p => p.Id == baEmailStatusInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        emailstatusinfo emailstatusinfo = new emailstatusinfo();

                        emailstatusinfo.Id = baEmailStatusInfo.Id;
                        emailstatusinfo.PS_Email_pkey = baEmailStatusInfo.PS_Email_pkey;
                        emailstatusinfo.OrderId = baEmailStatusInfo.OrderId;
                        emailstatusinfo.EmailId = baEmailStatusInfo.EmailId;
                        emailstatusinfo.PhotoId = baEmailStatusInfo.PhotoId;
                        emailstatusinfo.Status = baEmailStatusInfo.Status;
                        emailstatusinfo.EmailDateTime = baEmailStatusInfo.EmailDateTime;
                        emailstatusinfo.StatusDetail = baEmailStatusInfo.StatusDetail;
                        emailstatusinfo.StartDate = baEmailStatusInfo.StartDate;
                        emailstatusinfo.EndDate = baEmailStatusInfo.EndDate;
                        emailstatusinfo.IsAvailable = baEmailStatusInfo.IsAvailable;
                        emailstatusinfo.MediaName = baEmailStatusInfo.MediaName;
                        emailstatusinfo.PhotoCount = baEmailStatusInfo.PhotoCount;
                        emailstatusinfo.IsActive = baEmailStatusInfo.IsActive;

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
                    var obj = db.EmailStatusInfos.Where(p => p.Id == Id).FirstOrDefault();
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
