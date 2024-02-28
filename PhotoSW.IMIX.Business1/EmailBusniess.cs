using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class EmailBusniess : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public EmailBusniess ;

			public string ;

			public string ;

			public string ;

			public string ;

			public string ;

			public bool ;

			public string ;

			public string ;

			public bool ;

			public string ;

			public int ;

			public void ()
			{
				while (true)
				{
					EmailDao emailDao = new EmailDao(this..Transaction);
					while (7 != 0)
					{
						emailDao.InsEmailSettings(this., this., this., this., this., this., this., this., this., this., this.);
						if (true)
						{
							return;
						}
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public EmailSettingsInfo ;

			public EmailBusniess ;

			public void ()
			{
				EmailDao emailDao = new EmailDao(this..Transaction);
				this. = emailDao.GetEmailSettingsDetail();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public EmailBusniess ;

			public EmailStatusInfo ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public EmailBusniess. ;

			public List<EmailStatusInfo> ;

			public void ()
			{
				if (4 != 0)
				{
					EmailDao emailDao = new EmailDao(this...Transaction);
					if (!false)
					{
						this. = emailDao.GetEmailStatus(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public EmailBusniess ;

			public string ;

			public int ;

			public void ()
			{
				EmailDao expr_2D = new EmailDao(this..Transaction);
				EmailDao emailDao;
				if (!false)
				{
					emailDao = expr_2D;
				}
				emailDao.ResendEmail(this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public EmailBusniess ;

			public EMailInfo ;

			public void ()
			{
				while (true)
				{
					EmailDao emailDao;
					if (!false)
					{
						emailDao = new EmailDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							emailDao.InsertEmailDetails(this.);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<EmailDetailInfo> ;

			public EmailBusniess ;

			public void ()
			{
				EmailDao emailDao = new EmailDao(this..Transaction);
				this. = emailDao.GetEmailDetails();
			}
		}

		public bool TruncateEmailSettingsTable()
		{
			bool result;
			do
			{
				BaseBusiness.TransactionMethod transactionMethod = null;
				goto IL_06;
				try
				{
					do
					{
						IL_06:
						if (transactionMethod == null)
						{
							transactionMethod = new BaseBusiness.TransactionMethod(this.);
						}
						this.operation = transactionMethod;
						int expr_2C;
						while (true)
						{
							base.Start(false);
							while (true)
							{
								expr_2C = 1;
								if (expr_2C != 0)
								{
									goto Block_4;
								}
							}
						}
						Block_4:
						result = (expr_2C != 0);
					}
					while (false);
				}
				catch (Exception)
				{
					do
					{
						result = false;
					}
					while (-1 == 0);
				}
			}
			while (false);
			return result;
		}

		public bool SetEmailSettings(string From, string subject, string body, string servername, string serverport, bool defaultcredential, string username, string password, bool enablessl, string mailbcc, int SsId)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			do
			{
				transactionMethod = null;
			}
			while (false);
			2. = subject;
			2. = body;
			2. = servername;
			2. = serverport;
			2. = defaultcredential;
			2. = username;
			2. = password;
			2. = enablessl;
			2. = mailbcc;
			2. = SsId;
			2. = this;
			bool result;
			try
			{
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(2.2);
				}
				this.operation = transactionMethod;
				base.Start(false);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public EmailSettingsInfo GetEmailSettingsDetails()
		{
			EmailSettingsInfo result;
			try
			{
				if (!false)
				{
					EmailBusniess.  = new EmailBusniess.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new EmailSettingsInfo();
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					IL_3C:
					result = .;
				}
			}
			catch (Exception)
			{
				if (2 != 0)
				{
					result = null;
				}
			}
			return result;
		}

		public List<EmailStatusInfo> GetEmailStatus(EmailStatusInfo rfidEmailObj)
		{
			if (!false && -1 != 0)
			{
			}
			. = rfidEmailObj;
			. = this;
			List<EmailStatusInfo> result;
			try
			{
				EmailBusniess.  = new EmailBusniess.();
				if (!false)
				{
					. = ;
				}
				. = new List<EmailStatusInfo>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public bool ResendEmail(string EmailId, int SendType)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			do
			{
				if (!false && -1 != 0)
				{
					transactionMethod = null;
				}
			}
			while (false);
			. = this;
			bool result;
			try
			{
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public bool InsertEmailDetails(EMailInfo emailInfo)
		{
			if (4 == 0)
			{
				goto IL_10;
			}
			BaseBusiness.TransactionMethod transactionMethod = null;
			IL_06:
			EmailBusniess.  = new EmailBusniess.();
			IL_10:
			if (4 == 0)
			{
				goto IL_06;
			}
			. = emailInfo;
			if (-1 != 0)
			{
				. = this;
				bool result;
				try
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.);
					}
					this.operation = transactionMethod;
					bool arg_56_0 = base.Start(false);
					if (3 != 0)
					{
						arg_56_0 = true;
					}
					result = arg_56_0;
				}
				catch (Exception)
				{
					if (true)
					{
						result = false;
					}
				}
				return result;
			}
			goto IL_06;
		}

		public List<EmailDetailInfo> GetEmailDetails()
		{
			BaseBusiness.TransactionMethod transactionMethod;
			if (!false)
			{
				transactionMethod = null;
			}
			while (!false)
			{
				if (!false)
				{
					EmailBusniess  = this;
					break;
				}
			}
			. = new List<EmailDetailInfo>();
			List<EmailDetailInfo> 2;
			try
			{
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.2);
				}
				this.operation = transactionMethod;
				do
				{
					base.Start(false);
					2 = .;
				}
				while (5 == 0);
			}
			catch (Exception)
			{
				2 = .;
			}
			return 2;
		}

		[CompilerGenerated]
		private void ()
		{
			EmailDao emailDao = new EmailDao(base.Transaction);
			emailDao.TruEmailSettingsTable();
		}
	}
}
