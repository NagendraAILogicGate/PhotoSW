//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class EmailDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getEmailDao;
        public EmailDao (BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public EmailDao()
		{
		}

		public void TruEmailSettingsTable()
		{
			base.ExecuteNonQuery("");
		}

		public EmailSettingsInfo GetEmailSettingsDetail()
		{
			IDataReader expr_26 = base.ExecuteReader("");
			IDataReader dataReader;
			if (!false)
			{
				dataReader = expr_26;
			}
			List<EmailSettingsInfo> source = this.emailSettingsInfo(dataReader);
			if (!false)
			{
				dataReader.Close();
			}
			return source.FirstOrDefault<EmailSettingsInfo>();
		}

		private List<EmailSettingsInfo> emailSettingsInfo ( IDataReader dataReader)
		{
			List<EmailSettingsInfo> list;
			if (2 != 0)
			{
				list = new List<EmailSettingsInfo>();
				goto IL_196;
			}
			IL_18D:
			EmailSettingsInfo emailSettingsInfo;
			EmailSettingsInfo item = emailSettingsInfo;
			list.Add(item);
			IL_196:
			if (!dataReader.Read())
			{
				if (!false)
				{
					return list;
				}
			}
			else
			{
				emailSettingsInfo = new EmailSettingsInfo();
				emailSettingsInfo.DG_EmailSettings_pkey = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14448), 0);
				do
				{
					emailSettingsInfo.DG_MailSendFrom = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14477), string.Empty);
					emailSettingsInfo.DG_MailSubject = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14498), string.Empty);
				}
				while (false);
				emailSettingsInfo.DG_MailBody = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14519), string.Empty);
				emailSettingsInfo.DG_SmtpServername = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14536), string.Empty);
				emailSettingsInfo.DG_SmtpServerport = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14561), string.Empty);
				emailSettingsInfo.DG_SmtpUserDefaultCredentials = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14586), false);
			}
			emailSettingsInfo.DG_SmtpServerUsername = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14627), string.Empty);
			emailSettingsInfo.DG_SmtpServerPassword = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14656), string.Empty);
			emailSettingsInfo.DG_SmtpServerEnableSSL = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14685), false);
			emailSettingsInfo.DG_MailBCC = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14718), string.Empty);
			goto IL_18D;
		}

		public bool InsEmailSettings(string From, string subject, string body, string servername, string serverport, bool defaultcredential, string username, string password, bool enablessl, string mailbcc, int SsId)
		{
			base.DBParameters.Clear();
			base.AddParameter(EmailDao.getEmailDao(14735), defaultcredential);
			base.AddParameter(EmailDao.getEmailDao(14768), enablessl);
			base.AddParameter(EmailDao.getEmailDao(14789), From);
			base.AddParameter(EmailDao.getEmailDao(14806), subject);
			base.AddParameter(EmailDao.getEmailDao(14827), body);
			base.AddParameter(EmailDao.getEmailDao(14844), servername);
			base.AddParameter(EmailDao.getEmailDao(14869), serverport);
			base.AddParameter(EmailDao.getEmailDao(14894), username);
			base.AddParameter(EmailDao.getEmailDao(14915), password);
			base.AddParameter(EmailDao.getEmailDao(14936), mailbcc);
			base.ExecuteNonQuery("");
			return true;
		}

		public List<EmailStatusInfo> GetEmailStatus(EmailStatusInfo rfidEmailObj)
		{
			if (false)
			{
				goto IL_70;
			}
			base.DBParameters.Clear();
			IL_12:
			if (5 == 0)
			{
				goto IL_B3;
			}
			base.AddParameter(EmailDao.getEmailDao(2392), base.SetNullDateTimeValue(new DateTime?(rfidEmailObj.StartDate)));
			base.AddParameter(EmailDao.getEmailDao(2413), base.SetNullDateTimeValue(new DateTime?(rfidEmailObj.EndDate)));
			IL_70:
			base.AddParameter(EmailDao.getEmailDao(2350), rfidEmailObj.Status);
			IDataReader dataReader = base.ExecuteReader("");
			List<EmailStatusInfo> result;
			if (true)
			{
				result = this.emailStatusInfo(dataReader);
			}
			if (2 == 0)
			{
				goto IL_12;
			}
			dataReader.Close();
			IL_B3:
			if (!false)
			{
				return result;
			}
			goto IL_70;
		}

		private List<EmailStatusInfo> emailStatusInfo ( IDataReader dataReader)
		{
			List<EmailStatusInfo> expr_163 = new List<EmailStatusInfo>();
			List<EmailStatusInfo> list;
			if (3 != 0)
			{
				list = expr_163;
			}
			while (dataReader.Read())
			{
				EmailStatusInfo item = new EmailStatusInfo
				{
					DG_Email_pkey = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14957), 0),
					OrderId = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14978), string.Empty),
					EmailDateTime = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14995), DateTime.Now),
					EmailId = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15012), string.Empty),
					PhotoId = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15029), string.Empty),
					StatusDetail = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15046), string.Empty),
					IsAvailable = new bool?(base.GetFieldValue(dataReader, EmailDao.getEmailDao(15067), false)),
					MediaName = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15084), string.Empty),
					PhotoCount = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15101), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public bool ResendEmail(string EmailId, int SendType)
		{
			bool flag = false;
			base.DBParameters.Clear();
			base.AddParameter(EmailDao.getEmailDao(15118), base.SetNullStringValue(EmailId));
			base.AddParameter(EmailDao.getEmailDao(15139), base.SetNullIntegerValue(new int?(SendType)));
			base.AddParameter(EmailDao.getEmailDao(15160), flag, ParameterDirection.Output);
			base.ExecuteNonQuery("");
			return (bool)base.GetOutParameterValue(EmailDao.getEmailDao(15160));
		}

		public bool InsertEmailDetails(EMailInfo emailInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(EmailDao.getEmailDao(15177), emailInfo.OrderId);
			base.AddParameter(EmailDao.getEmailDao(15190), emailInfo.Emailto);
			base.AddParameter(EmailDao.getEmailDao(15203), emailInfo.EmailBcc);
			base.AddParameter(EmailDao.getEmailDao(15216), emailInfo.EmailIsSent);
			base.AddParameter(EmailDao.getEmailDao(15233), emailInfo.Sendername);
			base.AddParameter(EmailDao.getEmailDao(15250), emailInfo.EmailMessage);
			base.AddParameter(EmailDao.getEmailDao(15271), emailInfo.MediaName);
			base.AddParameter(EmailDao.getEmailDao(15292), emailInfo.OtherMessage);
			base.AddParameter(EmailDao.getEmailDao(15317), emailInfo.MailSubject);
			base.AddParameter(EmailDao.getEmailDao(15338), emailInfo.MediaType);
			base.ExecuteNonQuery("");
			return true;
		}

		public List<EmailDetailInfo> GetEmailDetails()
		{
			base.DBParameters.Clear();
			IDataReader dataReader;
			if (8 != 0)
			{
				dataReader = base.ExecuteReader("");
			}
			List<EmailDetailInfo> result = this.emailDetailInfo(dataReader);
			dataReader.Close();
			return result;
		}

		private List<EmailDetailInfo> emailDetailInfo ( IDataReader dataReader)
		{
			List<EmailDetailInfo> list = new List<EmailDetailInfo>();
			while (dataReader.Read())
			{
				EmailDetailInfo emailDetailInfo = new EmailDetailInfo();
				emailDetailInfo.EmailKey = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15359), 0);
				emailDetailInfo.EmailDetailId_Pkey = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15372), 0L);
				emailDetailInfo.PhotoId = base.GetFieldValue(dataReader, EmailDao.getEmailDao(883), 0L);
				emailDetailInfo.OrderId = base.GetFieldValue(dataReader, EmailDao.getEmailDao(14978), string.Empty);
				emailDetailInfo.DG_Email_To = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15012), string.Empty);
				emailDetailInfo.DG_Email_Bcc = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15397), string.Empty);
				emailDetailInfo.DG_EmailSender = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15414), string.Empty);
				emailDetailInfo.DG_Message = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15435), string.Empty);
				emailDetailInfo.EmailTemplate = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15452), string.Empty);
				do
				{
					emailDetailInfo.DG_ReportMailBody = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15473), string.Empty);
					emailDetailInfo.DG_OtherMessage = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15498), string.Empty);
					emailDetailInfo.DG_MessageType = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15519), string.Empty);
					emailDetailInfo.DG_EmailSubject = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15540), string.Empty);
				}
				while (8 == 0);
				emailDetailInfo.DG_MediaName = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15084), string.Empty);
				emailDetailInfo.message = base.GetFieldValue(dataReader, EmailDao.getEmailDao(15561), string.Empty);
				list.Add(emailDetailInfo);
			}
			return list;
		}

		static EmailDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(EmailDao));
		}
	}
}
