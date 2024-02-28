using System;

namespace PhotoSW.IMIX.Model
{
	public class EmailSettingsInfo
	{
		public int DG_EmailSettings_pkey
		{
			get;
			set;
		}

		public string DG_MailSendFrom
		{
			get;
			set;
		}

		public string DG_MailSubject
		{
			get;
			set;
		}

		public string DG_MailBody
		{
			get;
			set;
		}

		public string DG_SmtpServername
		{
			get;
			set;
		}

		public string DG_SmtpServerport
		{
			get;
			set;
		}

		public bool DG_SmtpUserDefaultCredentials
		{
			get;
			set;
		}

		public string DG_SmtpServerUsername
		{
			get;
			set;
		}

		public string DG_SmtpServerPassword
		{
			get;
			set;
		}

		public bool DG_SmtpServerEnableSSL
		{
			get;
			set;
		}

		public string DG_MailBCC
		{
			get;
			set;
		}
	}
}
