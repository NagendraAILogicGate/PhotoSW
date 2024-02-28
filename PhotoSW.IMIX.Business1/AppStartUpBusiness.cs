using DigiPhoto.IMIX.DataAccess;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PhotoSW.IMIX.Business
{
	public class AppStartUpBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<string> ;

			public AppStartUpBusiness ;

			public string ;

			public void  ()
			{
				do
				{
					ActivityDao activityDao =null;
					if (!false)
					{
						activityDao = new ActivityDao(this..Transaction);
					}
					this. = activityDao.IsUpdateAvailable(this.);
				}
				while (false);
			}
		}

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public string IsUpdateAvailable(string currVersion)
		{
			IL_00:
			AppStartUpBusiness. ;
			string result;
			while (-1 != 0)
			{
				 = new AppStartUpBusiness.();
				. = currVersion;
				. = this;
				do
				{
					result = string.Empty;
					if (7 == 0)
					{
						goto IL_00;
					}
				}
				while (false);
				. = null;
				this.operation = new BaseBusiness.TransactionMethod(.);
				int expr_75;
				while (true)
				{
					base.Start(false);
					while (5 != 0)
					{
						if (. == null)
						{
							return result;
						}
						expr_75 = ..Count;
						if (3 != 0)
						{
							goto Block_5;
						}
					}
				}
				Block_5:
				if (expr_75 > 0)
				{
					break;
				}
				return result;
			}
			result = string.Join(AppStartUpBusiness.(138), .);
			return result;
		}

		static AppStartUpBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(AppStartUpBusiness));
		}
	}
}
