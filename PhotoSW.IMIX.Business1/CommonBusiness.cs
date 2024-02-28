using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class CommonBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public Dictionary<string, int> ;

			[NonSerialized]
			internal static SmartAssembly.Delegates.GetString ;

			public void ()
			{
				this..Add(CommonBusiness..(424), 405);
				while (true)
				{
					Dictionary<string, int> expr_25 = this.;
					string expr_A1 = CommonBusiness..(441);
					int expr_36 = 403;
					if (!false)
					{
						expr_25.Add(expr_A1, expr_36);
					}
					while (true)
					{
						this..Add(CommonBusiness..(450), 404);
						if (8 == 0)
						{
							break;
						}
						this..Add(CommonBusiness..(459), 406);
						if (5 != 0)
						{
							return;
						}
					}
				}
			}

			static ()
			{
				// Note: this type is marked as 'beforefieldinit'.
				SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CommonBusiness.));
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<TableBaseInfo> ;

			public CommonBusiness ;

			public void ()
			{
				CommonDao commonDao = new CommonDao(this..Transaction);
				this. = commonDao.SelectAllTable();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public CommonBusiness ;

			public DataTable ;

			public DataTable ;

			public DataTable ;

			public void ()
			{
				while (true)
				{
					CommonDao commonDao;
					if (-1 != 0)
					{
						commonDao = new CommonDao(this..Transaction);
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
					this. = commonDao.ImportMasterData(this., this., this.);
					goto IL_33;
				}
			}
		}

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public Dictionary<string, int> GetCardCodeTypes()
		{
			Dictionary<string, int> 2;
			try
			{
				CommonBusiness.  = new CommonBusiness.();
				. = new Dictionary<string, int>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
					2 = .;
				}
				while (4 == 0);
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return 2;
		}

		public List<TableBaseInfo> GetAllTable()
		{
			BaseBusiness.TransactionMethod expr_00 = null;
			BaseBusiness.TransactionMethod transactionMethod;
			if (5 != 0)
			{
				transactionMethod = expr_00;
			}
			CommonBusiness.  = new CommonBusiness.();
			List<TableBaseInfo> result;
			do
			{
				. = this;
				. = new List<TableBaseInfo>();
				try
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.);
					}
					this.operation = transactionMethod;
					base.Start(false);
					result = .;
				}
				catch (Exception)
				{
					result = null;
				}
			}
			while (5 == 0);
			return result;
		}

		public DataTable CopyGenericToDataTable<T>(IEnumerable<T> items)
		{
			IEnumerable<PropertyInfo> enumerable = typeof(T).GetProperties().Where(new Func<PropertyInfo, bool>(CommonBusiness.<T>));
			DataTable dataTable = new DataTable();
			using (IEnumerator<PropertyInfo> enumerator = enumerable.GetEnumerator())
			{
				if (!false)
				{
					goto IL_8E;
				}
				IL_5A:
				Type type;
				bool arg_6F_0 = type.GetGenericTypeDefinition() == typeof(Nullable<>);
				IL_6F:
				if (arg_6F_0)
				{
					type = Nullable.GetUnderlyingType(type);
				}
				IL_78:
				if (false)
				{
					goto IL_5A;
				}
				PropertyInfo current;
				dataTable.Columns.Add(current.Name, type);
				IL_8E:
				bool expr_90 = arg_6F_0 = enumerator.MoveNext();
				if (2 == 0)
				{
					goto IL_6F;
				}
				if (expr_90)
				{
					current = enumerator.Current;
					type = current.PropertyType;
					if (type.IsGenericType)
					{
						goto IL_5A;
					}
					goto IL_78;
				}
			}
			IEnumerator<T> enumerator2 = items.GetEnumerator();
			try
			{
				while (enumerator2.MoveNext())
				{
					T current2 = enumerator2.Current;
					DataRow dataRow;
					do
					{
						dataRow = dataTable.NewRow();
						using (IEnumerator<PropertyInfo> enumerator3 = enumerable.GetEnumerator())
						{
							if (!false)
							{
							}
							IL_11E:
							while (enumerator3.MoveNext())
							{
								PropertyInfo current3 = enumerator3.Current;
								object value = current3.GetValue(current2, new object[0]);
								if (value != null)
								{
									if (4 != 0)
									{
										dataRow[current3.Name] = value;
									}
								}
								else
								{
									dataRow[current3.Name] = DBNull.Value;
								}
							}
							goto IL_135;
							goto IL_11E;
						}
						IL_135:;
					}
					while (false);
					dataTable.Rows.Add(dataRow);
				}
			}
			finally
			{
				if (enumerator2 != null && !false)
				{
					enumerator2.Dispose();
				}
			}
			return dataTable;
		}

		public bool ImportMasterData(DataTable dtSite, DataTable dtItem, DataTable dtpkg)
		{
			BaseBusiness.TransactionMethod expr_00 = null;
			BaseBusiness.TransactionMethod transactionMethod;
			if (!false)
			{
				transactionMethod = expr_00;
			}
			while (true)
			{
				DataTable ;
				DataTable ;
				DataTable ;
				while (true)
				{
					 = dtSite;
					if (4 == 0)
					{
						break;
					}
					if (false)
					{
						goto IL_4F;
					}
					 = dtItem;
					 = dtpkg;
					if (!false)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			2. = this;
			IL_4F:
			2. = false;
			bool result;
			try
			{
				do
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(2.);
					}
					this.operation = transactionMethod;
				}
				while (false);
				base.Start(false);
				bool expr_79;
				do
				{
					expr_79 = 2.;
				}
				while (false);
				result = expr_79;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		[CompilerGenerated]
		private static bool <>(PropertyInfo )
		{
			bool arg_15_0;
			int arg_2B_0 = (arg_15_0 = (.Name != CommonBusiness.(466))) ? 1 : 0;
			bool arg_29_0;
			bool expr_2B;
			while (true)
			{
				if (!false)
				{
					if (arg_15_0)
					{
						break;
					}
					arg_2B_0 = 0;
				}
				expr_2B = (arg_29_0 = (arg_2B_0 != 0));
				if (expr_2B)
				{
					return arg_29_0;
				}
				arg_2B_0 = (expr_2B ? 1 : 0);
				arg_15_0 = expr_2B;
				if (!expr_2B)
				{
					goto Block_4;
				}
			}
			arg_29_0 = (.Name != CommonBusiness.(479));
			return arg_29_0;
			Block_4:
			arg_29_0 = expr_2B;
			if (!expr_2B)
			{
				return expr_2B;
			}
			return arg_29_0;
		}

		static CommonBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CommonBusiness));
		}
	}
}
