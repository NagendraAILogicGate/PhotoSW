using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class PreSoldAutoOnlineOrderBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<PreSoldAutoOnlineOrderInfo> ;

			public PreSoldAutoOnlineOrderBusiness ;

			public void ()
			{
				PreSoldAutoOnlineOrderDao preSoldAutoOnlineOrderDao = new PreSoldAutoOnlineOrderDao(this..Transaction);
				this. = preSoldAutoOnlineOrderDao.GetAutoOnlineOrder();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PreSoldAutoOnlineOrderBusiness ;

			public string ;

			public bool ;

			public void ()
			{
				PreSoldAutoOnlineOrderDao expr_2D = new PreSoldAutoOnlineOrderDao(this..Transaction);
				PreSoldAutoOnlineOrderDao preSoldAutoOnlineOrderDao;
				if (!false)
				{
					preSoldAutoOnlineOrderDao = expr_2D;
				}
				preSoldAutoOnlineOrderDao.UpdateOrderStatus(this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PreSoldAutoOnlineOrderBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PreSoldAutoOnlineOrderBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					PreSoldAutoOnlineOrderDao preSoldAutoOnlineOrderDao = new PreSoldAutoOnlineOrderDao(this...Transaction);
					if (!false)
					{
						this. = preSoldAutoOnlineOrderDao.chKIsAutoPurchaseActiveOrNot(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PreSoldAutoOnlineOrderBusiness ;

			public PreSoldAutoOnlineOrderInfo ;

			public string ;

			public string ;

			public bool ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PreSoldAutoOnlineOrderBusiness. ;

			public bool ;

			public void ()
			{
				PreSoldAutoOnlineOrderDao preSoldAutoOnlineOrderDao = new PreSoldAutoOnlineOrderDao(this...Transaction);
				this. = preSoldAutoOnlineOrderDao.getOrderStatus(this.., this.., this.., this..);
			}
		}

		public List<PreSoldAutoOnlineOrderInfo> getAutoOnlineOrderDetails()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					2. = this;
				}
				while (false);
				2. = new List<PreSoldAutoOnlineOrderInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(2.2);
				}
				while (2 == 0);
				base.Start(false);
			}
			return 2.;
		}

		public bool UpdateOrderStatus(string IMIXImageAssociationIds, bool IsWaterMarked)
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
			. = this;
			bool result;
			try
			{
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool chKIsAutoPurchaseActiveOrNot(int SubStoreId)
		{
			if (!false && -1 != 0)
			{
			}
			. = SubStoreId;
			. = this;
			bool result;
			try
			{
				PreSoldAutoOnlineOrderBusiness.  = new PreSoldAutoOnlineOrderBusiness.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool getOrderStatus(PreSoldAutoOnlineOrderInfo cardNumber, string IMIXImageAssociationIds, string photoId, bool IsWaterMarked)
		{
			PreSoldAutoOnlineOrderBusiness.  = new PreSoldAutoOnlineOrderBusiness.();
			. = cardNumber;
			. = IMIXImageAssociationIds;
			. = photoId;
			. = IsWaterMarked;
			. = this;
			bool result;
			try
			{
				PreSoldAutoOnlineOrderBusiness.  = new PreSoldAutoOnlineOrderBusiness.();
				. = ;
				if (!false && !false)
				{
					. = false;
				}
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				bool expr_7F;
				do
				{
					expr_7F = .;
				}
				while (false);
				result = expr_7F;
			}
			catch
			{
				do
				{
					result = false;
				}
				while (false);
			}
			return result;
		}
	}
}
