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
    public class baEMailInfo
        {
        public long Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string StoreId { get; set; }
        public string SubstoreId { get; set; }
        public string VenueId { get; set; }
        public string OrderId { get; set; }
        public string Emailto { get; set; }
        public string EmailBcc { get; set; }
        public string EmailIsSent { get; set; }
        public string Sendername { get; set; }
        public string EmailMessage { get; set; }
        public string MediaName { get; set; }
        public string OtherMessage { get; set; }
        public string MailSubject { get; set; }
        public string MediaType { get; set; }
        public string FileExtension { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<emailinfo> lst_emailinfo = new List<emailinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    emailinfo emailinfo = new emailinfo();

                    emailinfo.Id = 1;
                    emailinfo.UserId = "";
                    emailinfo.UserName = "";
                    emailinfo.StoreId = "";
                    emailinfo.SubstoreId = "";
                    emailinfo.VenueId = "";
                    emailinfo.OrderId = "";
                    emailinfo.Emailto = "";
                    emailinfo.EmailBcc = "";
                    emailinfo.EmailIsSent = "";
                    emailinfo.Sendername = "";
                    emailinfo.EmailMessage = "";
                    emailinfo.MediaName = "";
                    emailinfo.OtherMessage = "";
                    emailinfo.MailSubject = "";
                    emailinfo.MediaType = "";
                    emailinfo.FileExtension = "";
                    emailinfo.IsActive = true;

                    lst_emailinfo.Add(emailinfo);

                    var Id = lst_emailinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.EMailInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.EMailInfos.AddRange(lst_emailinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.EMailInfos.AddRange(lst_emailinfo);
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

        public static baEMailInfo GetEMailInfoDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.EMailInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baEMailInfo
                        {
                        Id = p.Id,
                        UserId = p.UserId,
                        UserName = p.UserName,
                        StoreId = p.StoreId,
                        SubstoreId = p.SubstoreId,
                        VenueId = p.VenueId,
                        OrderId = p.OrderId,
                        Emailto = p.Emailto,
                        EmailBcc = p.EmailBcc,
                        EmailIsSent = p.EmailIsSent,
                        Sendername = p.Sendername,
                        EmailMessage = p.EmailMessage,
                        MediaName = p.MediaName,
                        OtherMessage = p.OtherMessage,
                        MailSubject = p.MailSubject,
                        MediaType = p.MediaType,
                        FileExtension = p.FileExtension,
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

        public static List<baEMailInfo> GetEMailInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.EMailInfos.Where(p => p.IsActive == true).Select(p => new baEMailInfo
                        {
                        Id = p.Id,
                        UserId = p.UserId,
                        UserName = p.UserName,
                        StoreId = p.StoreId,
                        SubstoreId = p.SubstoreId,
                        VenueId = p.VenueId,
                        OrderId = p.OrderId,
                        Emailto = p.Emailto,
                        EmailBcc = p.EmailBcc,
                        EmailIsSent = p.EmailIsSent,
                        Sendername = p.Sendername,
                        EmailMessage = p.EmailMessage,
                        MediaName = p.MediaName,
                        OtherMessage = p.OtherMessage,
                        MailSubject = p.MailSubject,
                        MediaType = p.MediaType,
                        FileExtension = p.FileExtension,
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

        public static bool Insert ( baEMailInfo baEMailInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    emailinfo emailinfo = new emailinfo();

                    emailinfo.Id = baEMailInfo.Id;
                    emailinfo.UserId = baEMailInfo.UserId;
                    emailinfo.UserName = baEMailInfo.UserName;
                    emailinfo.StoreId = baEMailInfo.StoreId;
                    emailinfo.SubstoreId = baEMailInfo.SubstoreId;
                    emailinfo.VenueId = baEMailInfo.VenueId;
                    emailinfo.OrderId = baEMailInfo.OrderId;
                    emailinfo.Emailto = baEMailInfo.Emailto;
                    emailinfo.EmailBcc = baEMailInfo.EmailBcc;
                    emailinfo.EmailIsSent = baEMailInfo.EmailIsSent;
                    emailinfo.Sendername = baEMailInfo.Sendername;
                    emailinfo.EmailMessage = baEMailInfo.EmailMessage;
                    emailinfo.MediaName = baEMailInfo.MediaName;
                    emailinfo.OtherMessage = baEMailInfo.OtherMessage;
                    emailinfo.MailSubject = baEMailInfo.MailSubject;
                    emailinfo.MediaType = baEMailInfo.MediaType;
                    emailinfo.FileExtension = baEMailInfo.FileExtension;
                    emailinfo.IsActive = baEMailInfo.IsActive;

                    db.EMailInfos.Add(emailinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baEMailInfo baEMailInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.EMailInfos.Where(p => p.Id == baEMailInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        emailinfo emailinfo = new emailinfo();

                        emailinfo.Id = baEMailInfo.Id;
                        emailinfo.UserId = baEMailInfo.UserId;
                        emailinfo.UserName = baEMailInfo.UserName;
                        emailinfo.StoreId = baEMailInfo.StoreId;
                        emailinfo.SubstoreId = baEMailInfo.SubstoreId;
                        emailinfo.VenueId = baEMailInfo.VenueId;
                        emailinfo.OrderId = baEMailInfo.OrderId;
                        emailinfo.Emailto = baEMailInfo.Emailto;
                        emailinfo.EmailBcc = baEMailInfo.EmailBcc;
                        emailinfo.EmailIsSent = baEMailInfo.EmailIsSent;
                        emailinfo.Sendername = baEMailInfo.Sendername;
                        emailinfo.EmailMessage = baEMailInfo.EmailMessage;
                        emailinfo.MediaName = baEMailInfo.MediaName;
                        emailinfo.OtherMessage = baEMailInfo.OtherMessage;
                        emailinfo.MailSubject = baEMailInfo.MailSubject;
                        emailinfo.MediaType = baEMailInfo.MediaType;
                        emailinfo.FileExtension = baEMailInfo.FileExtension;
                        emailinfo.IsActive = baEMailInfo.IsActive;

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
                    var obj = db.EMailInfos.Where(p => p.Id == Id).FirstOrDefault();
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
