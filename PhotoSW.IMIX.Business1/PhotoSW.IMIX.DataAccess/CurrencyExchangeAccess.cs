//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class CurrencyExchangeAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getCurrencyExchangeAccess;
        public CurrencyExchangeAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public CurrencyExchangeAccess()
		{
		}

		public List<CurrencyExchangeinfo> GetProfileList()
		{
			base.DBParameters.Clear();
			IDataReader dataReader = base.ExecuteReader(CurrencyExchangeAccess.getCurrencyExchangeAccess(34488));
			List<CurrencyExchangeinfo> result;
			do
			{
				result = this.currencyExchangeinfo(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		private List<CurrencyExchangeinfo> currencyExchangeinfo ( IDataReader dataReader)
		{
			List<CurrencyExchangeinfo> list = new List<CurrencyExchangeinfo>();
			while (dataReader.Read())
			{
				CurrencyExchangeinfo currencyExchangeinfo = new CurrencyExchangeinfo();
				currencyExchangeinfo.ProfileAuditID = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(34525), 0L);
				currencyExchangeinfo.ProfileName = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(34546), string.Empty);
				currencyExchangeinfo.CreatedBy = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(2873), 0L);
				currencyExchangeinfo.Updatedby = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(34563), 0L);
				currencyExchangeinfo.CreatedOn = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(3151), DateTime.Now);
				currencyExchangeinfo.updatedon = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(34576), DateTime.Now);
				currencyExchangeinfo.startDate = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(34589), DateTime.Now);
				currencyExchangeinfo.PublishedOn = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(34602), DateTime.Now);
				currencyExchangeinfo.IsCurrent = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(34619), false);
				if (base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(34632), DateTime.MinValue) == DateTime.MinValue)
				{
					currencyExchangeinfo.Enddate = null;
				}
				else
				{
					currencyExchangeinfo.Enddate = new DateTime?(base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(34632), DateTime.Now));
				}
				currencyExchangeinfo.IsActive = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(3108), false);
				list.Add(currencyExchangeinfo);
			}
			return list;
		}

		public List<RateDetailInfo> GetProfilerateDetailList(long profileAuditID)
		{
			List<RateDetailInfo> result;
			while (true)
			{
				if (false)
				{
					goto IL_41;
				}
				List<SqlParameter> expr_55 = base.DBParameters;
				if (!false)
				{
					expr_55.Clear();
				}
				if (-1 != 0)
				{
					base.AddParameter(CurrencyExchangeAccess.getCurrencyExchangeAccess(34645), profileAuditID);
					goto IL_25;
				}
				IL_4A:
				if (!true)
				{
					continue;
				}
				if (!false)
				{
					break;
				}
				IL_41:
				IDataReader dataReader;
				if (-1 != 0)
				{
					dataReader.Close();
					goto IL_4A;
				}
				IL_25:
				dataReader = base.ExecuteReader(CurrencyExchangeAccess.getCurrencyExchangeAccess(34666));
				result = this.rateDetailInfo(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<RateDetailInfo> rateDetailInfo ( IDataReader dataReader)
		{
			List<RateDetailInfo> list = new List<RateDetailInfo>();
			while (dataReader.Read())
			{
				RateDetailInfo rateDetailInfo = new RateDetailInfo();
				rateDetailInfo.DG_Currency_Name = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(13073), string.Empty);
				do
				{
					rateDetailInfo.DG_Currency_Code = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(13268), string.Empty);
					rateDetailInfo.ExchangeRate = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(34707), 0m);
					rateDetailInfo.IsActive = base.GetFieldValue(dataReader, CurrencyExchangeAccess.getCurrencyExchangeAccess(3108), false);
				}
				while (2 == 0);
				list.Add(rateDetailInfo);
			}
			return list;
		}

		public bool UploadCurrencyData(long CreatedBy, DateTime CreatedOn, DataTable dtCurrencyExchange)
		{
			base.DBParameters.Clear();
			base.AddParameter(CurrencyExchangeAccess.getCurrencyExchangeAccess(31333), CreatedBy);
			base.AddParameter(CurrencyExchangeAccess.getCurrencyExchangeAccess(32229), CreatedOn);
			base.AddParameter(CurrencyExchangeAccess.getCurrencyExchangeAccess(34724), dtCurrencyExchange);
			base.ExecuteNonQuery(CurrencyExchangeAccess.getCurrencyExchangeAccess(34753));
			return true;
		}

		public bool UpdateInsertProfile(long CreatedBy)
		{
			base.DBParameters.Clear();
			base.AddParameter(CurrencyExchangeAccess.getCurrencyExchangeAccess(31333), CreatedBy);
			base.ExecuteNonQuery(CurrencyExchangeAccess.getCurrencyExchangeAccess(34798));
			return true;
		}

		static CurrencyExchangeAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CurrencyExchangeAccess));
		}
	}
}
