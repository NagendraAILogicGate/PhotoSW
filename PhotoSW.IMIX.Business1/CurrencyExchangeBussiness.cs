using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class CurrencyExchangeBussiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<CurrencyExchangeinfo> ;

			public CurrencyExchangeBussiness ;

			public void ()
			{
				CurrencyExchangeAccess currencyExchangeAccess = new CurrencyExchangeAccess(this..Transaction);
				this. = currencyExchangeAccess.GetProfileList();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CurrencyExchangeBussiness ;

			public long ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CurrencyExchangeBussiness. ;

			public List<RateDetailInfo> ;

			public void ()
			{
				if (4 != 0)
				{
					CurrencyExchangeAccess currencyExchangeAccess = new CurrencyExchangeAccess(this...Transaction);
					if (!false)
					{
						this. = currencyExchangeAccess.GetProfilerateDetailList(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CurrencyExchangeBussiness ;

			public long ;

			public DateTime ;

			public DataTable ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CurrencyExchangeBussiness. ;

			public bool ;

			public void ()
			{
				CurrencyExchangeAccess currencyExchangeAccess = new CurrencyExchangeAccess(this...Transaction);
				this. = currencyExchangeAccess.UploadCurrencyData(this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CurrencyExchangeBussiness ;

			public long ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CurrencyExchangeBussiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					CurrencyExchangeAccess currencyExchangeAccess = new CurrencyExchangeAccess(this...Transaction);
					if (!false)
					{
						this. = currencyExchangeAccess.UpdateInsertProfile(this..);
					}
				}
			}
		}

		public List<CurrencyExchangeinfo> GetCurrencyProfileList()
		{
			List<CurrencyExchangeinfo> result;
			try
			{
				if (!false)
				{
					CurrencyExchangeBussiness.  = new CurrencyExchangeBussiness.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new List<CurrencyExchangeinfo>();
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

		public List<RateDetailInfo> GetProfilerateDetailList(long profileAuditID)
		{
			if (!false && -1 != 0)
			{
			}
			2. = profileAuditID;
			2. = this;
			List<RateDetailInfo> result;
			try
			{
				CurrencyExchangeBussiness.  = new CurrencyExchangeBussiness.();
				if (!false)
				{
					. = 2;
				}
				. = new List<RateDetailInfo>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}

		public bool UploadCurrencyData(long CreatedBy, DateTime CreatedOn, DataTable dtCurrencyExchange)
		{
			bool result;
			do
			{
				if (false)
				{
					return result;
				}
				DateTime  = CreatedOn;
				DataTable  = dtCurrencyExchange;
			}
			while (false);
			2. = this;
			try
			{
				CurrencyExchangeBussiness.  = new CurrencyExchangeBussiness.();
				. = 2;
				if (6 != 0)
				{
					. = false;
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
				result = .;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool UpdateInsertProfile(long CreatedBy)
		{
			if (!false && -1 != 0)
			{
			}
			. = CreatedBy;
			. = this;
			bool result;
			try
			{
				CurrencyExchangeBussiness.  = new CurrencyExchangeBussiness.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}
	}
}
