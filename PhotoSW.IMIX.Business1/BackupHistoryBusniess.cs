using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class BackupHistoryBusniess : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<BackupHistory> ;

			public BackupHistoryBusniess ;

			public int ;

			public DateTime ;

			public DateTime ;

			public void ()
			{
				while (true)
				{
					BackupHistoryDao backupHistoryDao;
					if (-1 != 0)
					{
						backupHistoryDao = new BackupHistoryDao(this..Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					this. = backupHistoryDao.GetBackupHistoryData(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public BackupHistoryBusniess ;

			public int ;

			public DateTime ;

			public int ;

			public void ()
			{
				BackupHistoryDao backupHistoryDao = new BackupHistoryDao(this..Transaction);
				backupHistoryDao.UpdAndInsScheduledConfig(this., this., this.);
			}
		}

		public List<BackupHistory> GetBackupHistoryData(int SubstoreId, DateTime dfrom, DateTime dto)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			while (true)
			{
				IL_06:
				int ;
				DateTime ;
				DateTime ;
				while (true)
				{
					 = SubstoreId;
					if (4 == 0)
					{
						goto IL_06;
					}
					if (false)
					{
						break;
					}
					 = dfrom;
					 = dto;
					if (!false)
					{
						goto Block_3;
					}
				}
				IL_4D:
				if (!false)
				{
					break;
				}
				continue;
				Block_3:
				BackupHistoryBusniess  = this;
				goto IL_4D;
			}
			2. = new List<BackupHistory>();
			List<BackupHistory> result;
			try
			{
				do
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(2.2);
					}
					this.operation = transactionMethod;
				}
				while (false);
				base.Start(false);
				result = 2.;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		public bool SaveScheduledConfig(int substoreId, DateTime backupDateTime, int status)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			BackupHistoryBusniess.  = new BackupHistoryBusniess.();
			. = substoreId;
			. = backupDateTime;
			. = status;
			. = this;
			bool result;
			try
			{
				new BackupHistory();
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
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
	}
}
