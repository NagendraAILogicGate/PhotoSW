using ;
using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using ErrorHandler;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace DigiPhoto.IMIX.Business
{
	public class CurrencyBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<CurrencyInfo> ;

			public CurrencyBusiness ;

			public void ()
			{
				CurrencyDao currencyDao = new CurrencyDao(this..Transaction);
				this. = currencyDao.Select(new int?(0), null);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CurrencyInfo ;

			public CurrencyBusiness ;

			public void ()
			{
				CurrencyDao currencyDao = new CurrencyDao(this..Transaction);
				this. = currencyDao.GetDefaultCurrencyName();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<CurrencyInfo> ;

			public CurrencyBusiness ;

			public void ()
			{
				CurrencyDao currencyDao = new CurrencyDao(this..Transaction);
				this. = currencyDao.Select(new int?(0), null);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<CurrencyInfo> ;

			public CurrencyBusiness ;

			public void ()
			{
				CurrencyDao currencyDao = new CurrencyDao(this..Transaction);
				this. = currencyDao.Select(new int?(0), null);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<CurrencyInfo> ;

			public CurrencyBusiness ;

			public void ()
			{
				if (4 != 0)
				{
					CurrencyDao currencyDao = new CurrencyDao(this..Transaction);
					this. = currencyDao.Select(new int?(0), new bool?(true));
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<CurrencyInfo> ;

			public CurrencyBusiness ;

			public void ()
			{
				if (4 != 0)
				{
					CurrencyDao currencyDao = new CurrencyDao(this..Transaction);
					this. = currencyDao.Select(new int?(0), new bool?(true));
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<CurrencyInfo> ;

			public CurrencyBusiness ;

			public void ()
			{
				CurrencyDao currencyDao = new CurrencyDao(this..Transaction);
				this. = currencyDao.Select(null, new bool?(true));
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CurrencyInfo ;

			public CurrencyBusiness ;

			public int ;

			public void ()
			{
				CurrencyDao currencyDao = new CurrencyDao(this..Transaction);
				this. = currencyDao.Select(new int?(this.), null).FirstOrDefault<CurrencyInfo>();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public CurrencyBusiness ;

			public int ;

			public void ()
			{
				do
				{
					CurrencyDao currencyDao;
					if (!false)
					{
						currencyDao = new CurrencyDao(this..Transaction);
					}
					this. = currencyDao.Delete(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CurrencyInfo ;

			public CurrencyBusiness ;

			public void ()
			{
				while (true)
				{
					CurrencyDao currencyDao;
					if (!false)
					{
						currencyDao = new CurrencyDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							currencyDao.Add(this.);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}

			public void ()
			{
				while (true)
				{
					CurrencyDao currencyDao;
					if (!false)
					{
						currencyDao = new CurrencyDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							currencyDao.Update(this.);
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
		private static Func<CurrencyInfo, .<int, float, bool?, string>> ;

		[CompilerGenerated]
		private static Func<.<int, float, bool?, string>, XElement> ;

		[CompilerGenerated]
		private static Func<CurrencyInfo, bool> ;

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public List<CurrencyInfo> GetCurrencyList()
		{
			do
			{
			}
			while (false);
			2. = this;
			List<CurrencyInfo> list;
			if (7 != 0)
			{
				2. = new List<CurrencyInfo>();
				this.operation = new BaseBusiness.TransactionMethod(2.2);
				CurrencyInfo currencyInfo;
				do
				{
					base.Start(false);
					list = new List<CurrencyInfo>();
					currencyInfo = new CurrencyInfo();
				}
				while (7 == 0);
				currencyInfo.DG_Currency_Symbol = CurrencyBusiness.(1415);
				currencyInfo.DG_Currency_pkey = 0;
				list.Add(currencyInfo);
			}
			List<CurrencyInfo>.Enumerator enumerator = 2..GetEnumerator();
			try
			{
				while (true)
				{
					CurrencyInfo current;
					if (-1 != 0 && !enumerator.MoveNext())
					{
						if (!false)
						{
							break;
						}
					}
					else
					{
						current = enumerator.Current;
					}
					list.Add(current);
				}
			}
			finally
			{
				do
				{
					((IDisposable)enumerator).Dispose();
				}
				while (5 == 0);
			}
			return list;
		}

		public int GetDefaultCurrency()
		{
			CurrencyBusiness. ;
			do
			{
				 = new CurrencyBusiness.();
				while (true)
				{
					. = this;
					if (!false)
					{
						. = new CurrencyInfo();
						if (-1 != 0)
						{
							this.operation = new BaseBusiness.TransactionMethod(.);
						}
						if (!false)
						{
							base.Start(false);
							if (. != null)
							{
								break;
							}
						}
					}
					if (4 != 0)
					{
						return 0;
					}
				}
			}
			while (false);
			return ..DG_Currency_pkey;
		}

		public string CurrentCurrencyConversionRate()
		{
			if (!false)
			{
				if (4 == 0)
				{
					goto IL_48;
				}
			}
			. = new List<CurrencyInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_48:
			base.Start(false);
			XName arg_B7_0 = CurrencyBusiness.(1432);
			IEnumerable<CurrencyInfo> arg_8B_0 = .;
			if (CurrencyBusiness. == null)
			{
				CurrencyBusiness. = new Func<CurrencyInfo, .<int, float, bool?, string>>(CurrencyBusiness.);
			}
			IEnumerable<.<int, float, bool?, string>> arg_B2_0 = arg_8B_0.Select(CurrencyBusiness.).ToList<.<int, float, bool?, string>>();
			if (CurrencyBusiness. == null)
			{
				CurrencyBusiness. = new Func<.<int, float, bool?, string>, XElement>(CurrencyBusiness.);
			}
			XElement xElement = new XElement(arg_B7_0, arg_B2_0.Select(CurrencyBusiness.));
			return xElement.ToString();
		}

		public List<CurrencyInfo> GetCurrencyListforconfig()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<CurrencyInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public List<CurrencyInfo> GetCurrencyDetails()
		{
			List<CurrencyInfo> result;
			try
			{
				CurrencyBusiness.  = new CurrencyBusiness.();
				. = this;
				. = new List<CurrencyInfo>();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				result = .;
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogError(serviceException);
				result = null;
			}
			return result;
		}

		public string GetDefaultCurrencyName()
		{
			string result;
			try
			{
				if (-1 == 0)
				{
					goto IL_51;
				}
				CurrencyBusiness.  = new CurrencyBusiness.();
				. = this;
				. = new List<CurrencyInfo>();
				this.operation = new BaseBusiness.TransactionMethod(.);
				IL_45:
				base.Start(false);
				IL_51:
				if (false)
				{
					goto IL_45;
				}
				IEnumerable<CurrencyInfo> arg_77_0 = .;
				if (CurrencyBusiness. == null)
				{
					CurrencyBusiness. = new Func<CurrencyInfo, bool>(CurrencyBusiness.);
				}
				result = arg_77_0.Where(CurrencyBusiness.).FirstOrDefault<CurrencyInfo>().DG_Currency_Name;
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogError(serviceException);
				if (3 != 0)
				{
					result = null;
				}
			}
			return result;
		}

		public List<CurrencyInfo> GetCurrencyOnly()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<CurrencyInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public string GetCurrencyDetailFromID(int currencyId)
		{
			string result;
			if (!false)
			{
				if (4 == 0)
				{
					goto IL_F2;
				}
				if (8 == 0)
				{
					goto IL_C4;
				}
				result = string.Empty;
			}
			do
			{
				. = new CurrencyInfo();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
			}
			while (7 == 0);
			if (. == null)
			{
				goto IL_F9;
			}
			object[] array = new object[7];
			array[0] = ..DG_Currency_Name;
			array[1] = CurrencyBusiness.(1449);
			array[2] = ..DG_Currency_Rate;
			array[3] = CurrencyBusiness.(1449);
			IL_C4:
			array[4] = ..DG_Currency_Symbol;
			array[5] = CurrencyBusiness.(1449);
			array[6] = ..DG_Currency_Code;
			IL_F2:
			result = string.Concat(array);
			IL_F9:
			if (3 != 0)
			{
				return result;
			}
			goto IL_F2;
		}

		public bool DeleteCurrency(int id)
		{
			CurrencyBusiness.  = new CurrencyBusiness.();
			. = id;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public void SetCurrencyDetails(string CurrencyName, float rate, string symbol, int id, int modifiedby, bool IsDefault, DateTime UpdateDate, string Icon, string Currencycode, string SyncCode)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			BaseBusiness.TransactionMethod transactionMethod2 = null;
			CurrencyBusiness. expr_142 = new CurrencyBusiness.();
			CurrencyBusiness. ;
			if (true)
			{
				 = expr_142;
			}
			. = this;
			if (!false)
			{
				. = new CurrencyInfo();
				..DG_Currency_pkey = id;
				do
				{
					..DG_Currency_Name = CurrencyName;
					..DG_Currency_Rate = rate;
					..DG_Currency_Symbol = symbol;
				}
				while (8 == 0);
				..DG_Currency_ModifiedBy = new int?(modifiedby);
				if (false)
				{
					goto IL_E5;
				}
				..DG_Currency_Default = new bool?(IsDefault);
				..DG_Currency_UpdatedDate = new DateTime?(UpdateDate);
				..DG_Currency_Icon = Icon;
				..DG_Currency_Code = Currencycode;
			}
			..DG_Currency_IsActive = new bool?(true);
			..SyncCode = SyncCode;
			IL_E5:
			..IsSynced = false;
			if (id <= 0)
			{
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				return;
			}
			if (transactionMethod2 == null)
			{
				transactionMethod2 = new BaseBusiness.TransactionMethod(.);
			}
			this.operation = transactionMethod2;
			base.Start(false);
		}

		[CompilerGenerated]
		private static .<int, float, bool?, string> (CurrencyInfo )
		{
			return new .<int, float, bool?, string>(.DG_Currency_pkey, .DG_Currency_Rate, .DG_Currency_Default, .SyncCode);
		}

		[CompilerGenerated]
		private static XElement (.<int, float, bool?, string> )
		{
			return new XElement(CurrencyBusiness.(1454), new object[]
			{
				new XAttribute(CurrencyBusiness.(1467), .DG_Currency_pkey),
				new XAttribute(CurrencyBusiness.(1472), .DG_Currency_Rate),
				new XAttribute(CurrencyBusiness.(1481), .DG_Currency_Default),
				new XAttribute(CurrencyBusiness.(1502), .SyncCode)
			});
		}

		[CompilerGenerated]
		private static bool (CurrencyInfo )
		{
			bool? dG_Currency_Default;
			if (true)
			{
				if (!false)
				{
					dG_Currency_Default = .DG_Currency_Default;
				}
				while (!dG_Currency_Default.GetValueOrDefault() && !false)
				{
					if (8 != 0)
					{
						return false;
					}
				}
			}
			return dG_Currency_Default.HasValue;
		}

		static CurrencyBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CurrencyBusiness));
		}
	}
}
