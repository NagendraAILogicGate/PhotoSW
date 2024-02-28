//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class CurrencyDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getCurrency;
        public CurrencyDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public CurrencyDao()
		{
		}

		public List<CurrencyInfo> SelectCurrency()
		{
			base.DBParameters.Clear();
			base.OpenConnection();
			base.AddParameter(CurrencyDao.getCurrency(12994), base.SetNullIntegerValue(null));
			base.AddParameter(CurrencyDao.getCurrency(1188), base.SetNullBoolValue(null));
			List<CurrencyInfo> result;
			using (IDataReader dataReader = base.ExecuteReader(""))
			{
				result = this.currencyInfo(dataReader);
			}
			return result;
		}

		public List<CurrencyInfo> Select(int? currencyId, bool? isActive)
		{
			if (!false && -1 != 0)
			{
				base.DBParameters.Clear();
			}
			base.AddParameter(CurrencyDao.getCurrency(12994), base.SetNullIntegerValue(currencyId));
			base.AddParameter(CurrencyDao.getCurrency(1188), base.SetNullBoolValue(isActive));
			List<CurrencyInfo> result;
			using (IDataReader dataReader = base.ExecuteReader(""))
			{
				do
				{
					result = this.currencyInfo(dataReader);
				}
				while (4 == 0);
			}
			return result;
		}

		private List<CurrencyInfo> currencyInfo ( IDataReader dataReader)
		{
			List<CurrencyInfo> list = new List<CurrencyInfo>();
			while (dataReader.Read())
			{
				CurrencyInfo item = new CurrencyInfo
				{
					DG_Currency_pkey = base.GetFieldValue(dataReader, CurrencyDao.getCurrency(13019), 0),
					DG_Currency_Name = base.GetFieldValue(dataReader, CurrencyDao.getCurrency(13044), string.Empty),
					DG_Currency_Rate = base.GetFieldValue(dataReader, CurrencyDao.getCurrency(13069), 0f),
					DG_Currency_Symbol = base.GetFieldValue(dataReader, CurrencyDao.getCurrency(13094), string.Empty),
					DG_Currency_UpdatedDate = new DateTime?(base.GetFieldValue(dataReader, CurrencyDao.getCurrency(13119), DateTime.MinValue)),
					DG_Currency_ModifiedBy = new int?(base.GetFieldValue(dataReader, CurrencyDao.getCurrency(13152), 0)),
					DG_Currency_Default = new bool?(base.GetFieldValue(dataReader, CurrencyDao.getCurrency(13185), false)),
					DG_Currency_Icon = base.GetFieldValue(dataReader, CurrencyDao.getCurrency(13214), string.Empty),
					DG_Currency_Code = base.GetFieldValue(dataReader, CurrencyDao.getCurrency(13239), string.Empty),
					DG_Currency_IsActive = new bool?(base.GetFieldValue(dataReader, CurrencyDao.getCurrency(13264), false)),
					SyncCode = base.GetFieldValue(dataReader, CurrencyDao.getCurrency(1979), string.Empty),
					IsSynced = base.GetFieldValue(dataReader, CurrencyDao.getCurrency(1992), false)
				};
				list.Add(item);
			}
			return list;
		}

		public CurrencyInfo GetDefaultCurrencyName()
		{
			List<CurrencyInfo> source;
			do
			{
				IDataReader dataReader = base.ExecuteReader("");
			//	goto IL_0B;
				try
				{
					do
					{
						IL_0B:
						source = this.currencyInfo2(dataReader);
					}
					while (false);
				}
				finally
				{
					if (dataReader == null)
					{
						goto IL_31;
					}
					IL_2B:
					dataReader.Dispose();
					IL_31:
					if (false || false)
					{
						goto IL_2B;
					}
				}
			}
			while (false);
			return source.FirstOrDefault<CurrencyInfo>();
		}

		public CurrencyInfo GetDefaultCurrency()
		{
			if (false)
			{
				goto IL_3D;
			}
			base.OpenConnection();
			IL_08:
			List<CurrencyInfo> source;
			if (7 != 0)
			{
				IDataReader dataReader = base.ExecuteReader("");
				try
				{
					source = this.currencyInfo2(dataReader);
				}
				finally
				{
					if (false || dataReader != null)
					{
						dataReader.Dispose();
					}
				}
			}
			IL_3D:
			if (2 != 0)
			{
				return source.FirstOrDefault<CurrencyInfo>();
			}
			goto IL_08;
		}

		private List<CurrencyInfo> currencyInfo2 ( IDataReader dataReader)
		{
			List<CurrencyInfo> list = new List<CurrencyInfo>();
			while (true)
			{
				if (4 == 0)
				{
					goto IL_6B;
				}
				IL_72:
				CurrencyInfo currencyInfo;
				if (!dataReader.Read())
				{
					if (5 != 0)
					{
						break;
					}
				}
				else if (8 != 0)
				{
					if (5 == 0)
					{
						continue;
					}
					currencyInfo = new CurrencyInfo();
					currencyInfo.DG_Currency_pkey = base.GetFieldValue(dataReader, CurrencyDao.getCurrency(13019), 0);
				}
				if (!false)
				{
					currencyInfo.DG_Currency_Name = base.GetFieldValue(dataReader, CurrencyDao.getCurrency(13044), string.Empty);
				}
				CurrencyInfo item = currencyInfo;
				IL_6B:
				list.Add(item);
				goto IL_72;
			}
			return list;
		}

		public bool Delete(int objectvalueId)
		{
			base.DBParameters.Clear();
			base.AddParameter(CurrencyDao.getCurrency(12994), objectvalueId);
			base.ExecuteNonQuery("");
			return true;
		}

		public int Add(CurrencyInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(CurrencyDao.getCurrency(13293), objectInfo.DG_Currency_Name);
			base.AddParameter(CurrencyDao.getCurrency(13326), objectInfo.DG_Currency_Rate);
			base.AddParameter(CurrencyDao.getCurrency(13359), objectInfo.DG_Currency_Symbol);
			base.AddParameter(CurrencyDao.getCurrency(13392), objectInfo.DG_Currency_UpdatedDate);
			base.AddParameter(CurrencyDao.getCurrency(13433), objectInfo.DG_Currency_ModifiedBy);
			base.AddParameter(CurrencyDao.getCurrency(13474), objectInfo.DG_Currency_Default);
			base.AddParameter(CurrencyDao.getCurrency(13511), objectInfo.DG_Currency_Icon);
			base.AddParameter(CurrencyDao.getCurrency(13544), objectInfo.DG_Currency_Code);
			base.AddParameter(CurrencyDao.getCurrency(13577), objectInfo.DG_Currency_IsActive);
			base.AddParameter(CurrencyDao.getCurrency(387), objectInfo.SyncCode);
			base.AddParameter(CurrencyDao.getCurrency(408), objectInfo.IsSynced);
			base.AddParameter(CurrencyDao.getCurrency(13614), objectInfo.DG_Currency_pkey, ParameterDirection.Output);
			base.ExecuteNonQuery("");
			return (int)base.GetOutParameterValue(CurrencyDao.getCurrency(13614));
		}

		public bool Update(CurrencyInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(CurrencyDao.getCurrency(13639), objectInfo.DG_Currency_pkey);
			base.AddParameter(CurrencyDao.getCurrency(13293), objectInfo.DG_Currency_Name);
			base.AddParameter(CurrencyDao.getCurrency(13326), objectInfo.DG_Currency_Rate);
			base.AddParameter(CurrencyDao.getCurrency(13359), objectInfo.DG_Currency_Symbol);
			base.AddParameter(CurrencyDao.getCurrency(13544), objectInfo.DG_Currency_Code);
			base.AddParameter(CurrencyDao.getCurrency(408), objectInfo.IsSynced);
			base.ExecuteNonQuery("");
			return true;
		}

		static CurrencyDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CurrencyDao));
		}
	}
}
