//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class PreSoldAutoOnlineOrderDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getPreSoldAutoOnline;
        public PreSoldAutoOnlineOrderDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public PreSoldAutoOnlineOrderDao()
		{
		}

		public List<PreSoldAutoOnlineOrderInfo> GetAutoOnlineOrder()
		{
			IDataReader dataReader;
			List<PreSoldAutoOnlineOrderInfo> result;
			while (true)
			{
				if (!false)
				{
					dataReader = base.ExecuteReader("");
				}
				while (!false)
				{
					List<PreSoldAutoOnlineOrderInfo> expr_3A = this.preSoldAutoOnlineOrderInfo(dataReader);
					if (!false)
					{
						result = expr_3A;
					}
					if (7 == 0)
					{
						break;
					}
					if (8 != 0)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			dataReader.Close();
			return result;
		}

		private List<PreSoldAutoOnlineOrderInfo> preSoldAutoOnlineOrderInfo ( IDataReader dataReader)
		{
			List<PreSoldAutoOnlineOrderInfo> expr_16C = new List<PreSoldAutoOnlineOrderInfo>();
			List<PreSoldAutoOnlineOrderInfo> list;
			if (3 != 0)
			{
				list = expr_16C;
			}
			while (dataReader.Read())
			{
				PreSoldAutoOnlineOrderInfo item = new PreSoldAutoOnlineOrderInfo
				{
					IMIXImageAssociationId = (long)base.GetFieldValue(dataReader, PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(837), 0),
					PhotoId = base.GetFieldValue(dataReader, PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(891), 0),
					IsOrdered = base.GetFieldValue(dataReader, PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(22711), 0),
					CardUniqueIdentifier = base.GetFieldValue(dataReader, PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(904), string.Empty),
					Name = base.GetFieldValue(dataReader, PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(531), string.Empty),
					MaxImages = base.GetFieldValue(dataReader, PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(7328), 0),
					PackageId = base.GetFieldValue(dataReader, PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(7490), 0),
					DG_Product_Pricing_ProductPrice = base.GetFieldValue(dataReader, PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(22724), 0f),
					ImageIdentificationType = base.GetFieldValue(dataReader, PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(7444), 0),
					IsWaterMarked = base.GetFieldValue(dataReader, PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(7668), false)
				};
				list.Add(item);
			}
			return list;
		}

		public bool UpdateOrderStatus(string IMIXImageAssociationIds, bool IsWaterMarked)
		{
			bool flag = false;
			base.DBParameters.Clear();
			base.AddParameter(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(15168), flag, ParameterDirection.Output);
			base.AddParameter(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(22769), base.SetNullStringValue(IMIXImageAssociationIds));
			base.AddParameter(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(22810), base.SetNullBoolValue(new bool?(IsWaterMarked)));
			base.ExecuteNonQuery("");
			return (bool)base.GetOutParameterValue(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(15168));
		}

		public bool chKIsAutoPurchaseActiveOrNot(int SubStoreId)
		{
			bool flag;
			if (!false && -1 != 0)
			{
				flag = false;
			}
			if (6 != 0)
			{
				base.DBParameters.Clear();
				base.AddParameter(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(15168), flag, ParameterDirection.Output);
				base.AddParameter(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(2333), base.SetNullIntegerValue(new int?(SubStoreId)));
				base.ExecuteNonQuery("");
			}
			return (bool)base.GetOutParameterValue(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(15168));
		}

		public bool getOrderStatus(PreSoldAutoOnlineOrderInfo cardNumber, string IMIXImageAssociationIds, string photoId, bool IsWaterMarked)
		{
			bool flag = false;
			base.DBParameters.Clear();
			base.AddParameter(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(15168), flag, ParameterDirection.Output);
			base.AddParameter(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(22839), base.SetNullStringValue(cardNumber.CardUniqueIdentifier));
			base.AddParameter(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(22876), base.SetNullStringValue(IMIXImageAssociationIds));
			base.AddParameter(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(22917), base.SetNullStringValue(photoId));
			base.AddParameter(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(22930), base.SetNullBoolValue(new bool?(IsWaterMarked)));
			base.ExecuteNonQuery("");
			return (bool)base.GetOutParameterValue(PreSoldAutoOnlineOrderDao.getPreSoldAutoOnline(15168));
		}

		static PreSoldAutoOnlineOrderDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(PreSoldAutoOnlineOrderDao));
		}
	}
}
