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
    public class baEmailSettingsInfo
        {
        public long Id { get; set; }
        public int PS_EmailSettings_pkey { get; set; }
        public string PS_MailSendFrom { get; set; }
        public string PS_MailSubject { get; set; }
        public string PS_MailBody { get; set; }
        public string PS_SmtpServername { get; set; }
        public string PS_SmtpServerport { get; set; }
        public bool PS_SmtpUserDefaultCredentials { get; set; }
        public string PS_SmtpServerUsername { get; set; }
        public string PS_SmtpServerPassword { get; set; }
        public bool PS_SmtpServerEnableSSL { get; set; }
        public string PS_MailBCC { get; set; }
        public bool? IsActive { get; set; }

        public static bool Marge ()
            {
            List<emailsettingsinfo> lst_emailsettingsinfo = new List<emailsettingsinfo>();

            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    emailsettingsinfo emailsettingsinfo = new emailsettingsinfo();

                    emailsettingsinfo.Id = 1;
                    emailsettingsinfo.PS_EmailSettings_pkey = 2;
                    emailsettingsinfo.PS_MailSendFrom = "";
                    emailsettingsinfo.PS_MailSubject = "";
                    emailsettingsinfo.PS_MailBody = "";
                    emailsettingsinfo.PS_SmtpServername = "";
                    emailsettingsinfo.PS_SmtpServerport = "";
                    emailsettingsinfo.PS_SmtpUserDefaultCredentials = false;
                    emailsettingsinfo.PS_SmtpServerUsername = "";
                    emailsettingsinfo.PS_SmtpServerPassword = "";
                    emailsettingsinfo.PS_SmtpServerEnableSSL = false;
                    emailsettingsinfo.PS_MailBCC = "";                   
                    emailsettingsinfo.IsActive = true;

                    lst_emailsettingsinfo.Add(emailsettingsinfo);

                    var Id = lst_emailsettingsinfo.Where(t => t.Id == 1).First().Id;
                    var IsExist = db.EmailSettingsInfos.Where(p => p.Id == Id).ToList();
                    if(IsExist == null)
                        {
                        db.EmailSettingsInfos.AddRange(lst_emailsettingsinfo);
                        db.SaveChanges();
                        }
                    else if(IsExist.Count == 0)
                        {
                        db.EmailSettingsInfos.AddRange(lst_emailsettingsinfo);
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

        public static baEmailSettingsInfo GetEmailSettingsInfoDataById ( long Id )
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {

                    var obj = db.EmailSettingsInfos.Where(p => p.Id == Id && p.IsActive == true).Select(p => new baEmailSettingsInfo
                        {
                        Id = p.Id,
                        PS_EmailSettings_pkey = p.PS_EmailSettings_pkey,
                        PS_MailSendFrom = p.PS_MailSendFrom,
                        PS_MailSubject = p.PS_MailSubject,
                        PS_MailBody = p.PS_MailBody,
                        PS_SmtpServername = p.PS_SmtpServername,
                        PS_SmtpServerport = p.PS_SmtpServerport,
                        PS_SmtpUserDefaultCredentials = p.PS_SmtpUserDefaultCredentials,
                        PS_SmtpServerUsername = p.PS_SmtpServerUsername,
                        PS_SmtpServerPassword = p.PS_SmtpServerPassword,
                        PS_SmtpServerEnableSSL = p.PS_SmtpServerEnableSSL,
                        PS_MailBCC = p.PS_MailBCC,                       
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

        public static List<baEmailSettingsInfo> GetEmailSettingsInfoData ()
            {
            try
                {

                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.EmailSettingsInfos.Where(p => p.IsActive == true).Select(p => new baEmailSettingsInfo
                        {
                        Id = p.Id,
                        PS_EmailSettings_pkey = p.PS_EmailSettings_pkey,
                        PS_MailSendFrom = p.PS_MailSendFrom,
                        PS_MailSubject = p.PS_MailSubject,
                        PS_MailBody = p.PS_MailBody,
                        PS_SmtpServername = p.PS_SmtpServername,
                        PS_SmtpServerport = p.PS_SmtpServerport,
                        PS_SmtpUserDefaultCredentials = p.PS_SmtpUserDefaultCredentials,
                        PS_SmtpServerUsername = p.PS_SmtpServerUsername,
                        PS_SmtpServerPassword = p.PS_SmtpServerPassword,
                        PS_SmtpServerEnableSSL = p.PS_SmtpServerEnableSSL,
                        PS_MailBCC = p.PS_MailBCC,
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

        public static bool Insert ( baEmailSettingsInfo baEmailSettingsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    emailsettingsinfo emailsettingsinfo = new emailsettingsinfo();

                    emailsettingsinfo.Id = baEmailSettingsInfo.Id;
                    emailsettingsinfo.PS_EmailSettings_pkey = baEmailSettingsInfo.PS_EmailSettings_pkey;
                    emailsettingsinfo.PS_MailSendFrom = baEmailSettingsInfo.PS_MailSendFrom;
                    emailsettingsinfo.PS_MailSubject = baEmailSettingsInfo.PS_MailSubject;
                    emailsettingsinfo.PS_MailBody = baEmailSettingsInfo.PS_MailBody;
                    emailsettingsinfo.PS_SmtpServername = baEmailSettingsInfo.PS_SmtpServername;
                    emailsettingsinfo.PS_SmtpServerport = baEmailSettingsInfo.PS_SmtpServerport;
                    emailsettingsinfo.PS_SmtpUserDefaultCredentials = baEmailSettingsInfo.PS_SmtpUserDefaultCredentials;
                    emailsettingsinfo.PS_SmtpServerUsername = baEmailSettingsInfo.PS_SmtpServerUsername;
                    emailsettingsinfo.PS_SmtpServerPassword = baEmailSettingsInfo.PS_SmtpServerPassword;
                    emailsettingsinfo.PS_SmtpServerEnableSSL = baEmailSettingsInfo.PS_SmtpServerEnableSSL;
                    emailsettingsinfo.PS_MailBCC = baEmailSettingsInfo.PS_MailBCC;
                    emailsettingsinfo.IsActive = baEmailSettingsInfo.IsActive;

                    db.EmailSettingsInfos.Add(emailsettingsinfo);
                    db.SaveChanges();

                    return true;
                    }
                }
            catch(Exception)
                {

                throw;
                }
            }

        public static bool Update ( baEmailSettingsInfo baEmailSettingsInfo )
            {
            try
                {
                using(PhotoSWEntities db = new PhotoSWEntities())
                    {
                    var obj = db.EmailSettingsInfos.Where(p => p.Id == baEmailSettingsInfo.Id).FirstOrDefault();
                    if(obj != null)
                        {
                        emailsettingsinfo emailsettingsinfo = new emailsettingsinfo();

                        emailsettingsinfo.Id = baEmailSettingsInfo.Id;
                        emailsettingsinfo.PS_EmailSettings_pkey = baEmailSettingsInfo.PS_EmailSettings_pkey;
                        emailsettingsinfo.PS_MailSendFrom = baEmailSettingsInfo.PS_MailSendFrom;
                        emailsettingsinfo.PS_MailSubject = baEmailSettingsInfo.PS_MailSubject;
                        emailsettingsinfo.PS_MailBody = baEmailSettingsInfo.PS_MailBody;
                        emailsettingsinfo.PS_SmtpServername = baEmailSettingsInfo.PS_SmtpServername;
                        emailsettingsinfo.PS_SmtpServerport = baEmailSettingsInfo.PS_SmtpServerport;
                        emailsettingsinfo.PS_SmtpUserDefaultCredentials = baEmailSettingsInfo.PS_SmtpUserDefaultCredentials;
                        emailsettingsinfo.PS_SmtpServerUsername = baEmailSettingsInfo.PS_SmtpServerUsername;
                        emailsettingsinfo.PS_SmtpServerPassword = baEmailSettingsInfo.PS_SmtpServerPassword;
                        emailsettingsinfo.PS_SmtpServerEnableSSL = baEmailSettingsInfo.PS_SmtpServerEnableSSL;
                        emailsettingsinfo.PS_MailBCC = baEmailSettingsInfo.PS_MailBCC;
                        emailsettingsinfo.IsActive = baEmailSettingsInfo.IsActive;

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
                    var obj = db.EmailSettingsInfos.Where(p => p.Id == Id).FirstOrDefault();
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
