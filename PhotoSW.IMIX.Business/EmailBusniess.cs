using PhotoSW.CF.DataLayer.BAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.IMIX.Business
{
    public class EmailBusniess
    {
        public List<PhotoSW.IMIX.Model.EmailDetailInfo> GetEmailDetails()
        {
            try
                {
                var obj = baEmailDetailInfo.GetEmailDetailInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.EmailDetailInfo()
                        {
                        EmailDetailId_Pkey = p.EmailDetailId_Pkey,
                        EmailKey = p.EmailKey,
                        OrderId = p.OrderId,
                        PhotoId = p.PhotoId,
                        DG_Email_To = p.PS_Email_To,
                        DG_Email_Bcc = p.PS_Email_Bcc,
                        DG_EmailSender = p.PS_EmailSender,
                        DG_Message = p.PS_Message,
                        EmailTemplate = p.EmailTemplate,
                        DG_ReportMailBody = p.PS_ReportMailBody,
                        DG_OtherMessage = p.PS_OtherMessage,
                        DG_MessageType = p.PS_MessageType,
                        DG_EmailSubject = p.PS_EmailSubject,
                        DG_MediaName = p.PS_MediaName,
                        message = p.message
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.EmailDetailInfo>();
                }
            // return new List<Model.EmailDetailInfo>();
            }
        public PhotoSW.IMIX.Model.EmailSettingsInfo GetEmailSettingsDetails()
        {
            try
                {
                var obj = baEmailSettingsInfo.GetEmailSettingsInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.EmailSettingsInfo()
                        {
                        DG_EmailSettings_pkey = p.PS_EmailSettings_pkey,
                        DG_MailSendFrom = p.PS_MailSendFrom,
                        DG_MailSubject = p.PS_MailSubject,
                        DG_MailBody = p.PS_MailBody,
                        DG_SmtpServername = p.PS_SmtpServername,
                        DG_SmtpServerport = p.PS_SmtpServerport,
                        DG_SmtpUserDefaultCredentials = p.PS_SmtpUserDefaultCredentials,
                        DG_SmtpServerUsername = p.PS_SmtpServerUsername,
                        DG_SmtpServerPassword = p.PS_SmtpServerPassword,
                        DG_SmtpServerEnableSSL = p.PS_SmtpServerEnableSSL,
                        DG_MailBCC = p.PS_MailBCC
                        }).FirstOrDefault();
                return obj;
                }
            catch
                {
                return new PhotoSW.IMIX.Model.EmailSettingsInfo();
                }
            // return new Model.EmailSettingsInfo();
            }
        public List<PhotoSW.IMIX.Model.EmailStatusInfo> GetEmailStatus(PhotoSW.IMIX.Model.EmailStatusInfo rfidEmailObj)
        {
            try
                {
                var obj = baEmailStatusInfo.GetEmailStatusInfoData()
                    .Select(p => new PhotoSW.IMIX.Model.EmailStatusInfo()
                        {
                        DG_Email_pkey = p.PS_Email_pkey,
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
                        PhotoCount = p.PhotoCount
                        }).ToList();
                return obj;
                }
            catch
                {
                return new List<PhotoSW.IMIX.Model.EmailStatusInfo>();
                }
            // return new List<Model.EmailStatusInfo>();
            }
        public bool InsertEmailDetails(PhotoSW.IMIX.Model.EMailInfo emailInfo)
        {
            return false;
        }
        public bool ResendEmail(string EmailId, int SendType)
        {
            return false;
        }
        public bool SetEmailSettings(string From, string subject, string body, string servername, string serverport, bool defaultcredential, string username, string password, bool enablessl, string mailbcc, int SsId)
        {
            return false;
        }
        public bool TruncateEmailSettingsTable()
        {
            return false;
        }
    }
}
