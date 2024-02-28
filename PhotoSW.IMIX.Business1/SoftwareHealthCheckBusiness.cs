using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class SoftwareHealthCheckBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<ServicesInfo> ;

			public SoftwareHealthCheckBusiness ;

			public void ()
			{
				ServicesDao servicesDao = new ServicesDao(this..Transaction);
				this. = servicesDao.GetServices();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<VersionHistoryInfo> ;

			public SoftwareHealthCheckBusiness ;

			public string ;

			public void ()
			{
				do
				{
					VersionHistoryDao versionHistoryDao;
					if (!false)
					{
						versionHistoryDao = new VersionHistoryDao(this..Transaction);
					}
					this. = versionHistoryDao.GetVersionDetails(this.);
				}
				while (false);
			}
		}

		public List<ServicesInfo> GetRunningServices()
		{
			List<ServicesInfo> result;
			try
			{
				if (!false)
				{
					SoftwareHealthCheckBusiness.  = new SoftwareHealthCheckBusiness.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new List<ServicesInfo>();
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					IL_3C:
					result = .;
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

		public List<VersionHistoryInfo> GetVersionDetails(string MachineName)
		{
			SoftwareHealthCheckBusiness.  = new SoftwareHealthCheckBusiness.();
			. = MachineName;
			. = this;
			. = new List<VersionHistoryInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}
	}
}
