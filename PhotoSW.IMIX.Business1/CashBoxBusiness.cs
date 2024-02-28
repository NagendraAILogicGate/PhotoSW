using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class CashBoxBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public CashBoxInfo ;

			public CashBoxBusiness ;

			public void ()
			{
				CashBoxDao expr_2E = new CashBoxDao(this..Transaction);
				CashBoxDao cashBoxDao;
				if (!false)
				{
					cashBoxDao = expr_2E;
				}
				this..Id = cashBoxDao.Add(this.);
			}
		}

		public bool SetcashBoxReason(DateTime createddate, int userid, string reason)
		{
			CashBoxBusiness.  = new CashBoxBusiness.();
			. = this;
			if (false)
			{
				goto IL_74;
			}
			. = new CashBoxInfo();
			IL_2B:
			..UserId = userid;
			..CreatedDate = createddate;
			..Reason = reason;
			this.operation = new BaseBusiness.TransactionMethod(.);
			int arg_8E_0 = base.Start(false) ? 1 : 0;
			IL_70:
			if (6 == 0)
			{
				return arg_8E_0 != 0;
			}
			IL_74:
			if (6 != 0)
			{
				int expr_7D = arg_8E_0 = ..Id;
				if (false)
				{
					goto IL_70;
				}
				if (expr_7D > 0)
				{
					return true;
				}
			}
			if (3 == 0)
			{
				goto IL_2B;
			}
			arg_8E_0 = 0;
			return arg_8E_0 != 0;
		}
	}
}
