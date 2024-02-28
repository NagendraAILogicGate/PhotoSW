using DigiPhoto.Cache.DataCache;
using DigiPhoto.Cache.Repository;
using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using ErrorHandler;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class SemiOrderBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<SemiOrderSettingsInfo> ;

			public SemiOrderBusiness ;

			public void ()
			{
				SemiOrderAccess semiOrderAccess = new SemiOrderAccess(this..Transaction);
				this. = semiOrderAccess.GetSemiOrderSettings();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SemiOrderBusiness ;

			public int? ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SemiOrderBusiness. ;

			public List<SemiOrderSettings> ;

			public void ()
			{
				SemiOrderSettingsDao semiOrderSettingsDao = new SemiOrderSettingsDao(this...Transaction);
				this. = semiOrderSettingsDao.GetSemiOrderSettings(this.., null);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SemiOrderBusiness ;

			public int? ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SemiOrderBusiness. ;

			public List<SemiOrderSettings> ;

			public void ()
			{
				do
				{
					if (2 != 0)
					{
						SemiOrderSettingsDao semiOrderSettingsDao = new SemiOrderSettingsDao(this...Transaction);
						if (false)
						{
							continue;
						}
						this. = semiOrderSettingsDao.GetSemiOrderSettings(this.., new int?(this..));
					}
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SemiOrderBusiness ;

			public int? ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SemiOrderBusiness. ;

			public List<SemiOrderSettings> ;

			public void ()
			{
				do
				{
					if (2 != 0)
					{
						SemiOrderSettingsDao semiOrderSettingsDao = new SemiOrderSettingsDao(this...Transaction);
						if (false)
						{
							continue;
						}
						this. = semiOrderSettingsDao.GetSemiOrderSettings(this.., new int?(this..));
					}
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SemiOrderBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SemiOrderBusiness. ;

			public List<SpecProfileProductMappingInfo> ;

			public void ()
			{
				if (4 != 0)
				{
					SemiOrderAccess semiOrderAccess = new SemiOrderAccess(this...Transaction);
					if (!false)
					{
						this. = semiOrderAccess.GetSemiOrderProfileProductMapping(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderDetailInfo ;

			public SemiOrderBusiness ;

			public int ;

			public void ()
			{
				do
				{
					OrderDetailsDao orderDetailsDao;
					if (!false)
					{
						orderDetailsDao = new OrderDetailsDao(this..Transaction);
					}
					this. = orderDetailsDao.GetSemiOrderImage(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public SemiOrderBusiness ;

			public int ;

			public void ()
			{
				do
				{
					SemiOrderSettingsDao semiOrderSettingsDao;
					if (!false)
					{
						semiOrderSettingsDao = new SemiOrderSettingsDao(this..Transaction);
					}
					this. = semiOrderSettingsDao.DeleteSpecSetting(this.);
				}
				while (false);
			}
		}

		public List<SemiOrderSettingsInfo> GetSemiOrderSettings()
		{
			List<SemiOrderSettingsInfo> result;
			try
			{
				if (!false)
				{
					SemiOrderBusiness.  = new SemiOrderBusiness.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new List<SemiOrderSettingsInfo>();
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					IL_3C:
					result = .;
				}
			}
			catch
			{
				if (2 != 0)
				{
					result = null;
				}
			}
			return result;
		}

		private List<SemiOrderSettings> ()
		{
			List<SemiOrderSettings> result;
			try
			{
				ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(SemiOrderSettingsInfo).FullName);
				result = (List<SemiOrderSettings>)factory.GetData();
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogError(serviceException);
				result = new List<SemiOrderSettings>();
			}
			return result;
		}

		public List<SemiOrderSettings> GetLstSemiOrderSettings(int? substoreId)
		{
			if (4 == 0)
			{
				goto IL_22;
			}
			IL_0D:
			List<SemiOrderSettings> result;
			if (4 == 0)
			{
				return result;
			}
			int?  = substoreId;
			IL_22:
			if (6 == 0)
			{
				goto IL_0D;
			}
			SemiOrderBusiness  = this;
			try
			{
				do
				{
				}
				while (7 == 0);
				. = new List<SemiOrderSettings>();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				result = .;
			}
			catch (Exception serviceException)
			{
				do
				{
					ErrorHandler.LogError(serviceException);
					result = null;
				}
				while (2 == 0);
			}
			return result;
		}

		public List<SemiOrderSettings> GetSemiOrderSetting(int? substoreId, int locationId)
		{
			if (!false)
			{
				int? ;
				do
				{
					 = substoreId;
				}
				while (-1 == 0);
				int  = locationId;
			}
			. = this;
			List<SemiOrderSettings> result;
			try
			{
				SemiOrderBusiness.  = new SemiOrderBusiness.();
				. = ;
				. = new List<SemiOrderSettings>();
				while (true)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					while (-1 != 0)
					{
						base.Start(false);
						result = .;
						if (true)
						{
							goto Block_6;
						}
					}
				}
				Block_6:;
			}
			catch (Exception serviceException)
			{
				if (-1 != 0)
				{
					ErrorHandler.LogError(serviceException);
					result = null;
				}
			}
			return result;
		}

		public List<SemiOrderSettings> GetSemiOrderSettings(int? substoreId, int locationId)
		{
			if (!false)
			{
				int? ;
				do
				{
					 = substoreId;
				}
				while (-1 == 0);
				int  = locationId;
			}
			. = this;
			List<SemiOrderSettings> result;
			try
			{
				SemiOrderBusiness.  = new SemiOrderBusiness.();
				. = ;
				. = new List<SemiOrderSettings>();
				while (true)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					while (-1 != 0)
					{
						base.Start(false);
						result = .;
						if (true)
						{
							goto Block_6;
						}
					}
				}
				Block_6:;
			}
			catch (Exception serviceException)
			{
				if (-1 != 0)
				{
					ErrorHandler.LogError(serviceException);
					result = null;
				}
			}
			return result;
		}

		public List<SpecProfileProductMappingInfo> GetSemiOrderProfileProductMapping(int ProfileId)
		{
			if (4 == 0)
			{
				goto IL_22;
			}
			IL_0D:
			List<SpecProfileProductMappingInfo> result;
			if (4 == 0)
			{
				return result;
			}
			int  = ProfileId;
			IL_22:
			if (6 == 0)
			{
				goto IL_0D;
			}
			SemiOrderBusiness  = this;
			try
			{
				do
				{
				}
				while (7 == 0);
				. = new List<SpecProfileProductMappingInfo>();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				result = .;
			}
			catch (Exception serviceException)
			{
				do
				{
					ErrorHandler.LogError(serviceException);
					result = null;
				}
				while (2 == 0);
			}
			return result;
		}

		public bool IsSemiOrderImage(int OrderDetailsID)
		{
			SemiOrderBusiness.  = new SemiOrderBusiness.();
			while (true)
			{
				. = OrderDetailsID;
				if (7 != 0)
				{
					. = this;
					. = new OrderDetailInfo();
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
					if (6 == 0 || ..DG_Orders_ID.HasValue)
					{
						goto IL_75;
					}
					if (2 != 0)
					{
						break;
					}
				}
			}
			int arg_71_0 = 1;
			IL_71:
			int arg_76_0;
			int expr_71 = arg_76_0 = arg_71_0;
			if (expr_71 != 0)
			{
				return expr_71 != 0;
			}
			goto IL_76;
			IL_75:
			arg_76_0 = 0;
			IL_76:
			int expr_76 = arg_71_0 = arg_76_0;
			if (expr_76 == 0)
			{
				return expr_76 != 0;
			}
			goto IL_71;
		}

		public bool DeleteSpecSetting(int id)
		{
			SemiOrderBusiness.  = new SemiOrderBusiness.();
			. = id;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}
	}
}
