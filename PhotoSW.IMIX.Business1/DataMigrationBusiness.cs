using DigiPhoto.IMIX.DataAccess;
using System;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class DataMigrationBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public DataMigrationBusiness ;

			public string ;

			public string ;

			public void ()
			{
				if (4 != 0)
				{
					DataMigrationAccess dataMigrationAccess = new DataMigrationAccess(this..Transaction);
					this. = dataMigrationAccess.ExecuteDataMigration(this., this.);
				}
			}
		}

		public string ExecuteDataMigration(string _databasename, string backUpPath)
		{
			string 2;
			while (true)
			{
				BaseBusiness.TransactionMethod transactionMethod;
				if (4 != 0)
				{
					transactionMethod = null;
					goto IL_06;
				}
				goto IL_31;
				IL_40:
				if (7 == 0)
				{
					continue;
				}
				DataMigrationBusiness. ;
				. = string.Empty;
				try
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.);
					}
					this.operation = transactionMethod;
					if (8 != 0)
					{
						base.Start(false);
					}
					2 = .;
				}
				catch
				{
					throw;
				}
				if (!false)
				{
					break;
				}
				IL_06:
				if (4 == 0)
				{
					goto IL_40;
				}
				 = new DataMigrationBusiness.();
				. = _databasename;
				. = backUpPath;
				IL_31:
				. = this;
				goto IL_40;
			}
			return 2;
		}
	}
}
