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
    public class baEmailDetailInfo
        {
        public long Id { get; set; }
        public long EmailDetailId_Pkey { get; set; }
        public int EmailKey { get; set; }
        public string OrderId { get; set; }
        public long PhotoId { get; set; }
        public string PS_Email_To { get; set; }
        public string PS_Email_Bcc { get; set; }
        public string PS_EmailSender { get; set; }
        public string PS_Message { get; set; }
        public string EmailTemplate { get; set; }
        public string PS_ReportMailBody { get; set; }
        public string PS_OtherMessage { get; set; }
        public string PS_MessageType { get; set; }
        public string PS_EmailSubject { get; set; }
        public string PS_MediaName { get; set; }
        public string message { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<emaildetailinfo> lst_emaildetailinfo = new List<emaildetailinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    emaildetailinfo emaildetailinfo = new emaildetailinfo();

                    emaildetailinfo.Id = 1;
                    emaildetailinfo.EmailDetailId_Pkey = 3;
                    emaildetailinfo.EmailKey = 2;
                    emaildetailinfo.OrderId = "";
                    emaildetailinfo.PhotoId = 1;
                    emaildetailinfo.PS_Email_To = "";
                    emaildetailinfo.PS_Email_Bcc = "";
                    emaildetailinfo.PS_EmailSender = "";
                    emaildetailinfo.PS_Message = "";
                    emaildetailinfo.EmailTemplate = "";
                    emaildetailinfo.PS_ReportMailBody = "";
                    emaildetailinfo.PS_OtherMessage = "";
                    emaildetailinfo.PS_MessageType = "";
                    emaildetailinfo.PS_EmailSubject = "";
                    emaildetailinfo.PS_MediaName = "";
                    emaildetailinfo.message = "";
                    emaildetailinfo.IsActive = true;

                    lst_emaildetailinfo.Add(emaildetailinfo);

                    var Id = lst_emaildetailinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.EmailDetailInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.EmailDetailInfos.AddRange(lst_emaildetailinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.EmailDetailInfos.AddRange(lst_emaildetailinfo);
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

        public static baEmailDetailInfo GetEmailDetailInfoDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.EmailDetailInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baEmailDetailInfo
                        {
                        Id = p.Id,
                        EmailDetailId_Pkey = p.EmailDetailId_Pkey,
                        EmailKey = p.EmailKey,
                        OrderId = p.OrderId,
                        PhotoId = p.PhotoId,
                        PS_Email_To = p.PS_Email_To,
                        PS_Email_Bcc = p.PS_Email_Bcc,
                        PS_EmailSender = p.PS_EmailSender,
                        PS_Message = p.PS_Message,
                        EmailTemplate = p.EmailTemplate,
                        PS_ReportMailBody = p.PS_ReportMailBody,
                        PS_OtherMessage = p.PS_OtherMessage,
                        PS_MessageType = p.PS_MessageType,
                        PS_EmailSubject = p.PS_EmailSubject,
                        PS_MediaName = p.PS_MediaName,
                        message = p.message,
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

        public static List<baEmailDetailInfo> GetEmailDetailInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.EmailDetailInfos.Where(p => p.IsActive == true).Select(p => new baEmailDetailInfo
                        {
                        Id = p.Id,
                        EmailDetailId_Pkey = p.EmailDetailId_Pkey,
                        EmailKey = p.EmailKey,
                        OrderId = p.OrderId,
                        PhotoId = p.PhotoId,
                        PS_Email_To = p.PS_Email_To,
                        PS_Email_Bcc = p.PS_Email_Bcc,
                        PS_EmailSender = p.PS_EmailSender,
                        PS_Message = p.PS_Message,
                        EmailTemplate = p.EmailTemplate,
                        PS_ReportMailBody = p.PS_ReportMailBody,
                        PS_OtherMessage = p.PS_OtherMessage,
                        PS_MessageType = p.PS_MessageType,
                        PS_EmailSubject = p.PS_EmailSubject,
                        PS_MediaName = p.PS_MediaName,
                        message = p.message,
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

        public static bool Insert ( baEmailDetailInfo baEmailDetailInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    emaildetailinfo emaildetailinfo = new emaildetailinfo();

                    emaildetailinfo.Id = baEmailDetailInfo.Id;
                    emaildetailinfo.EmailDetailId_Pkey = baEmailDetailInfo.EmailDetailId_Pkey;
                    emaildetailinfo.EmailKey = baEmailDetailInfo.EmailKey;
                    emaildetailinfo.OrderId = baEmailDetailInfo.OrderId;
                    emaildetailinfo.PhotoId = baEmailDetailInfo.PhotoId;
                    emaildetailinfo.PS_Email_To = baEmailDetailInfo.PS_Email_To;
                    emaildetailinfo.PS_Email_Bcc = baEmailDetailInfo.PS_Email_Bcc;
                    emaildetailinfo.PS_EmailSender = baEmailDetailInfo.PS_EmailSender;
                    emaildetailinfo.PS_Message = baEmailDetailInfo.PS_Message;
                    emaildetailinfo.EmailTemplate = baEmailDetailInfo.EmailTemplate;
                    emaildetailinfo.PS_ReportMailBody = baEmailDetailInfo.PS_ReportMailBody;
                    emaildetailinfo.PS_OtherMessage = baEmailDetailInfo.PS_OtherMessage;
                    emaildetailinfo.PS_MessageType = baEmailDetailInfo.PS_MessageType;
                    emaildetailinfo.PS_EmailSubject = baEmailDetailInfo.PS_EmailSubject;
                    emaildetailinfo.PS_MediaName = baEmailDetailInfo.PS_MediaName;
                    emaildetailinfo.message = baEmailDetailInfo.message;
                    emaildetailinfo.IsActive = baEmailDetailInfo.IsActive;

                    db.EmailDetailInfos.Add(emaildetailinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baEmailDetailInfo baEmailDetailInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.EmailDetailInfos.Where(p => p.Id == baEmailDetailInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        emaildetailinfo emaildetailinfo = new emaildetailinfo();

                        emaildetailinfo.Id = baEmailDetailInfo.Id;
                        emaildetailinfo.EmailDetailId_Pkey = baEmailDetailInfo.EmailDetailId_Pkey;
                        emaildetailinfo.EmailKey = baEmailDetailInfo.EmailKey;
                        emaildetailinfo.OrderId = baEmailDetailInfo.OrderId;
                        emaildetailinfo.PhotoId = baEmailDetailInfo.PhotoId;
                        emaildetailinfo.PS_Email_To = baEmailDetailInfo.PS_Email_To;
                        emaildetailinfo.PS_Email_Bcc = baEmailDetailInfo.PS_Email_Bcc;
                        emaildetailinfo.PS_EmailSender = baEmailDetailInfo.PS_EmailSender;
                        emaildetailinfo.PS_Message = baEmailDetailInfo.PS_Message;
                        emaildetailinfo.EmailTemplate = baEmailDetailInfo.EmailTemplate;
                        emaildetailinfo.PS_ReportMailBody = baEmailDetailInfo.PS_ReportMailBody;
                        emaildetailinfo.PS_OtherMessage = baEmailDetailInfo.PS_OtherMessage;
                        emaildetailinfo.PS_MessageType = baEmailDetailInfo.PS_MessageType;
                        emaildetailinfo.PS_EmailSubject = baEmailDetailInfo.PS_EmailSubject;
                        emaildetailinfo.PS_MediaName = baEmailDetailInfo.PS_MediaName;
                        emaildetailinfo.message = baEmailDetailInfo.message;
                        emaildetailinfo.IsActive = baEmailDetailInfo.IsActive;

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
                    var obj = db.EmailDetailInfos.Where(p => p.Id == Id).FirstOrDefault();
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
