
using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PhotoSW.IMIX.DataAccess
{
	public class StoreDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly .Delegates .GetString getStoreDao;
		public StoreDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public StoreDao()
		{
		}

		public StoreInfo GetStore()
		{
			base.DBParameters.Clear();
			IDataReader dataReader = null;//base.ExecuteReader(#1j.#li);
			List<StoreInfo> source = this.StoreInfofd(dataReader);
			dataReader.Close();
			return source.FirstOrDefault<StoreInfo>();
		}

		private List<StoreInfo> StoreInfofd(IDataReader IDataReader)
		{
			List<StoreInfo> list = new List<StoreInfo>();
			while (IDataReader.Read())
			{
				StoreInfo storeInfo = new StoreInfo();
				storeInfo.DG_Store_pkey = base.GetFieldValue(IDataReader, StoreDao.getStoreDao(30320), 0);
				storeInfo.DG_Store_Name = base.GetFieldValue(IDataReader, StoreDao.getStoreDao(30086), string.Empty);
				do
				{
					storeInfo.Country = base.GetFieldValue(IDataReader,   StoreDao.getStoreDao(30341), string.Empty);
				}
				while (false);
				storeInfo.DG_CentralServerIP = base.GetFieldValue(IDataReader,                      StoreDao.getStoreDao(30354), string.Empty);
				storeInfo.DG_StoreCode = base.GetFieldValue(IDataReader,                            StoreDao.getStoreDao(30379), string.Empty);
				storeInfo.DG_CenetralServerUName = base.GetFieldValue(IDataReader,                  StoreDao.getStoreDao(30396), string.Empty);
				storeInfo.DG_CenetralServerPassword = base.GetFieldValue(IDataReader,               StoreDao.getStoreDao(30429), string.Empty);
				storeInfo.DG_PreferredTimeToSyncFrom = new decimal?(base.GetFieldValue(IDataReader, StoreDao.getStoreDao(30466), 0.0m));
				storeInfo.DG_PreferredTimeToSyncTo = new decimal?(base.GetFieldValue(IDataReader,   StoreDao.getStoreDao(30503), 0.0m));
				storeInfo.DG_QRCodeWebUrl = base.GetFieldValue(IDataReader,                         StoreDao.getStoreDao(30536), string.Empty);
				storeInfo.CountryCode = base.GetFieldValue(IDataReader,                             StoreDao.getStoreDao(30107), string.Empty);
				storeInfo.StoreCode = base.GetFieldValue(IDataReader,                               StoreDao.getStoreDao(30124), string.Empty);
				storeInfo.RunApplicationsSubStoreLevel = base.GetFieldValue(IDataReader,            StoreDao.getStoreDao(30557), false);
				storeInfo.IsOnline = base.GetFieldValue(IDataReader,                                StoreDao.getStoreDao(30598), false);
				StoreInfo item = storeInfo;
				list.Add(item);
			}
			return list;
		}

		public SubStoresInfo GetSubstoreData(int SubStore_pkey, bool? SubStore_IsActive)
		{
			base.DBParameters.Clear();
			base.AddParameter(StoreDao.getStoreDao(28743), SubStore_pkey);
			base.AddParameter(StoreDao.getStoreDao(28772), base.SetNullBoolValue(SubStore_IsActive));
			IDataReader dataReader = null; //base.ExecuteReader(#1j.#1i);
			List<SubStoresInfo> source = this.SubStoresInfoWc(dataReader);
			do
			{
				dataReader.Close();
			}
			while (false);
			return source.FirstOrDefault<SubStoresInfo>();
		}

		private List<SubStoresInfo> SubStoresInfoWc(IDataReader IDataReader)
		{
			List<SubStoresInfo> list = new List<SubStoresInfo>();
			while (IDataReader.Read())
			{
				SubStoresInfo item = new SubStoresInfo
				{
					DG_SubStore_pkey = base.GetFieldValue(IDataReader,        StoreDao.getStoreDao(24583), 0),
					DG_SubStore_Name = base.GetFieldValue(IDataReader,        StoreDao.getStoreDao(12898), string.Empty),
					DG_SubStore_Description = base.GetFieldValue(IDataReader, StoreDao.getStoreDao(28659), string.Empty),
					DG_SubStore_IsActive = base.GetFieldValue(IDataReader,    StoreDao.getStoreDao(28805), false),
					SyncCode = base.GetFieldValue(IDataReader,                StoreDao.getStoreDao(2003), string.Empty),
					IsSynced = base.GetFieldValue(IDataReader,                StoreDao.getStoreDao(2016), false)
				};
				list.Add(item);
			}
			return list;
		}

		public List<StoreInfo> Select()
		{
			base.OpenConnection();
			IDataReader dataReader=null;
			if (8 != 0)
			{
				//dataReader = base.ExecuteReader(#1j.#gg);
			}
			List<StoreInfo> result = this.StoreInfogd(dataReader);
			dataReader.Close();
			return result;
		}

		public List<StoreInfo> SelectStore()
		{
			IDataReader dataReader=null;
			List<StoreInfo> result;
			while (true)
			{
				if (!false)
				{
					//dataReader = base.ExecuteReader(#1j.#gg);
				}
				while (!false)
				{
					List<StoreInfo> expr_3A = this.StoreInfogd(dataReader);
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

		private List<StoreInfo> StoreInfogd(IDataReader IDataReader)
		{
			List<StoreInfo> list = new List<StoreInfo>();
			while (IDataReader.Read())
			{
				StoreInfo storeInfo;
				do
				{
					storeInfo = new StoreInfo();
					storeInfo.DG_Store_pkey = base.GetFieldValue(IDataReader,      StoreDao.getStoreDao(30320), 0);
					storeInfo.DG_Store_Name = base.GetFieldValue(IDataReader,      StoreDao.getStoreDao(30086), string.Empty);
					storeInfo.Country = base.GetFieldValue(IDataReader,            StoreDao.getStoreDao(30341), string.Empty);
					storeInfo.DG_CentralServerIP = base.GetFieldValue(IDataReader, StoreDao.getStoreDao(30354), string.Empty);
					storeInfo.DG_StoreCode = base.GetFieldValue(IDataReader,       StoreDao.getStoreDao(30379), string.Empty);
				}
				while (3 == 0);
				storeInfo.DG_CenetralServerUName = base.GetFieldValue(IDataReader,                  StoreDao.getStoreDao(30396), string.Empty);
				storeInfo.DG_CenetralServerPassword = base.GetFieldValue(IDataReader,               StoreDao.getStoreDao(30429), string.Empty);
				storeInfo.DG_PreferredTimeToSyncFrom = new decimal?(base.GetFieldValue(IDataReader, StoreDao.getStoreDao(30466), 0.0m));
				storeInfo.DG_PreferredTimeToSyncTo = new decimal?(base.GetFieldValue(IDataReader,   StoreDao.getStoreDao(30503), 0.0m));
				storeInfo.DG_QRCodeWebUrl = base.GetFieldValue(IDataReader,                         StoreDao.getStoreDao(30536), string.Empty);
				storeInfo.CountryCode = base.GetFieldValue(IDataReader,                             StoreDao.getStoreDao(30107), string.Empty);
				storeInfo.StoreCode = base.GetFieldValue(IDataReader,                               StoreDao.getStoreDao(30124), string.Empty);
				StoreInfo item = storeInfo;
				list.Add(item);
			}
			return list;
		}

		public StoreInfo GETQRCodeWebUrl()
		{
			//IDataReader expr_26 = base.ExecuteReader(#1j.#Ti);
			IDataReader dataReader=null;
			if (!false)
			{
				//dataReader = expr_26;
			}
			List<StoreInfo> source = this.StoreInfohd(dataReader);
			if (!false)
			{
				dataReader.Close();
			}
			return source.FirstOrDefault<StoreInfo>();
		}

		private List<StoreInfo> StoreInfohd(IDataReader IDataReader)
		{
			List<StoreInfo> list = new List<StoreInfo>();
			while (IDataReader.Read())
			{
				StoreInfo storeInfo;
				do
				{
					storeInfo = new StoreInfo();
					storeInfo.DG_Store_pkey = base.GetFieldValue(IDataReader,      StoreDao.getStoreDao(30320), 0);
					storeInfo.DG_Store_Name = base.GetFieldValue(IDataReader,      StoreDao.getStoreDao(30086), string.Empty);
					storeInfo.Country = base.GetFieldValue(IDataReader,            StoreDao.getStoreDao(30341), string.Empty);
					storeInfo.DG_CentralServerIP = base.GetFieldValue(IDataReader, StoreDao.getStoreDao(30354), string.Empty);
					storeInfo.DG_StoreCode = base.GetFieldValue(IDataReader,       StoreDao.getStoreDao(30379), string.Empty);
				}
				while (3 == 0);
				storeInfo.DG_CenetralServerUName = base.GetFieldValue(IDataReader,                  StoreDao.getStoreDao(30396), string.Empty);
				storeInfo.DG_CenetralServerPassword = base.GetFieldValue(IDataReader,               StoreDao.getStoreDao(30429), string.Empty);
				storeInfo.DG_PreferredTimeToSyncFrom = new decimal?(base.GetFieldValue(IDataReader, StoreDao.getStoreDao(30466), 0.0m));
				storeInfo.DG_PreferredTimeToSyncTo = new decimal?(base.GetFieldValue(IDataReader,   StoreDao.getStoreDao(30503), 0.0m));
				storeInfo.DG_QRCodeWebUrl = base.GetFieldValue(IDataReader,                         StoreDao.getStoreDao(30536), string.Empty);
				storeInfo.CountryCode = base.GetFieldValue(IDataReader,                             StoreDao.getStoreDao(30107), string.Empty);
				storeInfo.StoreCode = base.GetFieldValue(IDataReader,                               StoreDao.getStoreDao(30124), string.Empty);
				StoreInfo item = storeInfo;
				list.Add(item);
			}
			return list;
		}

		public List<PhotoGraphersInfo> SelectPhotoGraphersList(int StoreId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(StoreDao.getStoreDao(24832), StoreId);
			}
			IDataReader dataReader=null;
			List<PhotoGraphersInfo> result=null;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#Pf);
                if (3 != 0)
                {
                    result = this.PhotoGraphersInfobd(dataReader);
                }
			}
			dataReader.Close();
			return result;
		}

		private List<PhotoGraphersInfo> PhotoGraphersInfobd(IDataReader IDataReader)
		{
			List<PhotoGraphersInfo> list = new List<PhotoGraphersInfo>();
			while (IDataReader.Read())
			{
				PhotoGraphersInfo item = new PhotoGraphersInfo
				{
					DG_User_pkey = base.GetFieldValue(IDataReader,                     StoreDao.getStoreDao(704), 0),
					DG_User_Role = base.GetFieldValue(IDataReader,                     StoreDao.getStoreDao(26818), string.Empty),
					DG_User_First_Name = base.GetFieldValue(IDataReader,               StoreDao.getStoreDao(654), string.Empty),
					DG_User_Last_Name = base.GetFieldValue(IDataReader,                StoreDao.getStoreDao(679), string.Empty),
					DG_User_Password = base.GetFieldValue(IDataReader,                 StoreDao.getStoreDao(29981), string.Empty),
					DG_User_Name = base.GetFieldValue(IDataReader,                     StoreDao.getStoreDao(637), string.Empty),
					DG_User_Roles_Id = base.GetFieldValue(IDataReader,                 StoreDao.getStoreDao(22206), 0),
					DG_Location_Name = base.GetFieldValue(IDataReader,                 StoreDao.getStoreDao(16382), string.Empty),
					DG_Store_ID = base.GetFieldValue(IDataReader,                      StoreDao.getStoreDao(16486), 0),
					DG_Location_pkey = base.GetFieldValue(IDataReader,                 StoreDao.getStoreDao(16407), 0),
					DG_User_Status = new bool?(base.GetFieldValue(IDataReader,         StoreDao.getStoreDao(30006), false)),
					DG_User_PhoneNo = base.GetFieldValue(IDataReader,                  StoreDao.getStoreDao(30027), string.Empty),
					UserName = base.GetFieldValue(IDataReader,                         StoreDao.getStoreDao(25890), string.Empty),
					StatusName = base.GetFieldValue(IDataReader,                       StoreDao.getStoreDao(30048), string.Empty),
					DG_User_Email = base.GetFieldValue(IDataReader,                    StoreDao.getStoreDao(30065), string.Empty),
					DG_Store_Name = base.GetFieldValue(IDataReader,                    StoreDao.getStoreDao(30086), string.Empty),
					CountryCode = base.GetFieldValue(IDataReader,                      StoreDao.getStoreDao(30107), string.Empty),
					StoreCode = base.GetFieldValue(IDataReader,                        StoreDao.getStoreDao(30124), string.Empty),
					DG_Substore_ID = base.GetFieldValue(IDataReader,                   StoreDao.getStoreDao(30137), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public Dictionary<string, string> SelStoreDir()
		{
			IDataReader dataReader=null;
			Dictionary<string, string> result;
			while (true)
			{
                //if (!false)
                //{
                //    dataReader = base.ExecuteReader(#1j.#li);
                //}
				while (!false)
				{
					Dictionary<string, string> expr_3A = this.Dictionaryid(dataReader);
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

		private Dictionary<string, string> Dictionaryid(IDataReader IDataReader)
		{
			Dictionary<string, string> dictionary;
			do
			{
				if (!false && -1 != 0)
				{
					dictionary = new Dictionary<string, string>();
				}
				dictionary.Add(StoreDao.getStoreDao(16360), StoreDao.getStoreDao(16377));
			}
			while (false);
			while (IDataReader.Read())
			{
				dictionary.Add(base.GetFieldValue(IDataReader, StoreDao.getStoreDao(30086), string.Empty), base.GetFieldValue(IDataReader, StoreDao.getStoreDao(30320), 0).ToString());
			}
			return dictionary;
		}

		public bool UpdateStoreQRCode(string QRCodeWebUrl)
		{
			do
			{
				base.DBParameters.Clear();
			}
			while (8 == 0);
			base.AddParameter(StoreDao.getStoreDao(30611), QRCodeWebUrl);
			if (7 != 0)
			{
				//base.ExecuteNonQuery(#1j.#Ai);
			}
			return true;
		}

		static StoreDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(StoreDao));
		}
	}
}
