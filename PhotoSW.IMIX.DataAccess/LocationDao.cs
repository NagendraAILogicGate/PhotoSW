//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class LocationDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getLocationDao;
        public LocationDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public LocationDao()
		{
		}

		public int Add(LocationInfo objectInfo)
		{
			int result;
			do
			{
				List<SqlParameter> expr_115 = base.DBParameters;
				if (6 != 0)
				{
					expr_115.Clear();
				}
				if (6 != 0)
				{
					if (true)
					{
						base.AddParameter(LocationDao.getLocationDao(16109), objectInfo.DG_Location_Name);
						base.AddParameter(LocationDao.getLocationDao(16142), objectInfo.DG_Store_ID);
						base.AddParameter(LocationDao.getLocationDao(16167), objectInfo.DG_Location_IsActive);
					}
					base.AddParameter(LocationDao.getLocationDao(393), objectInfo.SyncCode);
					base.AddParameter(LocationDao.getLocationDao(414), objectInfo.IsSynced);
					if (false)
					{
						return result;
					}
					base.AddParameter(LocationDao.getLocationDao(12361), objectInfo.DG_Location_pkey, ParameterDirection.Output);
				}
			}
			while (5 == 0);
			base.ExecuteNonQuery("");
			result = (int)base.GetOutParameterValue(LocationDao.getLocationDao(12361));
			return result;
		}

		public int Update(LocationInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(LocationDao.getLocationDao(16204), objectInfo.DG_Location_pkey);
			base.AddParameter(LocationDao.getLocationDao(16109), objectInfo.DG_Location_Name);
			base.AddParameter(LocationDao.getLocationDao(414), objectInfo.IsSynced);
			base.AddParameter(LocationDao.getLocationDao(16229), objectInfo.DG_Location_pkey, ParameterDirection.Output);
			base.ExecuteNonQuery("");
			return (int)base.GetOutParameterValue(LocationDao.getLocationDao(16229));
		}

		public bool Delete(int objectvalueId)
		{
			base.DBParameters.Clear();
			base.AddParameter(LocationDao.getLocationDao(16204), objectvalueId);
			base.ExecuteNonQuery("");
			return true;
		}

		public SubStoreLocationInfo SelectSubStoreLocationsByLocationId(int LocationID)
		{
			base.DBParameters.Clear();
			base.AddParameter(LocationDao.getLocationDao(16204), LocationID);
			IDataReader dataReader;
			if (true && !false)
			{
				dataReader = base.ExecuteReader("");
			}
			List<SubStoreLocationInfo> source;
			do
			{
				source = this.subStoreLocationInfo(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<SubStoreLocationInfo>();
		}

		private List<SubStoreLocationInfo> subStoreLocationInfo ( IDataReader dataReader)
		{
			List<SubStoreLocationInfo> list = new List<SubStoreLocationInfo>();
			while (true)
			{
				while (dataReader.Read())
				{
					SubStoreLocationInfo subStoreLocationInfo = new SubStoreLocationInfo();
					if (true)
					{
						subStoreLocationInfo.DG_SubStore_Location_Pkey = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16250), 0);
						subStoreLocationInfo.DG_Location_ID = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16287), 0);
						subStoreLocationInfo.DG_SubStore_ID = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16308), 0);
						SubStoreLocationInfo item = subStoreLocationInfo;
						list.Add(item);
					}
				}
				break;
			}
			return list;
		}

		public Dictionary<string, string> GetLocationStoreWiseDir(int storeId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(LocationDao.getLocationDao(16329), storeId);
			}
			IDataReader dataReader;
			Dictionary<string, string> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.dictionaryType(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private Dictionary<string, string> dictionaryType ( IDataReader dataReader)
		{
			Dictionary<string, string> dictionary;
			do
			{
				if (!false && -1 != 0)
				{
					dictionary = new Dictionary<string, string>();
				}
				dictionary.Add(LocationDao.getLocationDao(16342), LocationDao.getLocationDao(16359));
			}
			while (false);
			while (dataReader.Read())
			{
				dictionary.Add(base.GetFieldValue(dataReader, LocationDao.getLocationDao(16364), string.Empty), base.GetFieldValue(dataReader, LocationDao.getLocationDao(16389), 0).ToString());
			}
			return dictionary;
		}

		public List<LocationInfo> GetLocationStoreWise(int storeId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(LocationDao.getLocationDao(16329), storeId);
			}
			IDataReader dataReader;
			List<LocationInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.locationInfo(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<LocationInfo> locationInfo ( IDataReader dataReader)
		{
			List<LocationInfo> list = new List<LocationInfo>();
			while (true)
			{
				if (4 == 0)
				{
					goto IL_6B;
				}
				IL_72:
				LocationInfo locationInfo;
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
					locationInfo = new LocationInfo();
					locationInfo.DG_Location_pkey = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16389), 0);
				}
				if (!false)
				{
					locationInfo.DG_Location_Name = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16364), string.Empty);
				}
				LocationInfo item = locationInfo;
				IL_6B:
				list.Add(item);
				goto IL_72;
			}
			return list;
		}

		public List<LocationInfo> GetLocationList(int Store_ID, bool Location_IsActive)
		{
			base.DBParameters.Clear();
			IDataReader dataReader;
			List<LocationInfo> result;
			do
			{
				base.AddParameter(LocationDao.getLocationDao(16414), Store_ID);
				base.AddParameter(LocationDao.getLocationDao(16435), Location_IsActive);
				dataReader = base.ExecuteReader("");
				result = this.locationInfo2(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		private List<LocationInfo> locationInfo2 ( IDataReader dataReader)
		{
			List<LocationInfo> list = new List<LocationInfo>();
			while (dataReader.Read())
			{
				LocationInfo item = new LocationInfo
				{
					DG_Location_pkey = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16389), 0),
					DG_Location_Name = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16364), string.Empty),
					DG_Store_ID = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16468), 0),
					DG_Location_PhoneNumber = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16485), string.Empty),
					DG_Location_IsActive = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16518), false),
					SyncCode = base.GetFieldValue(dataReader, LocationDao.getLocationDao(1985), string.Empty),
					IsSynced = base.GetFieldValue(dataReader, LocationDao.getLocationDao(1998), false)
				};
				list.Add(item);
			}
			return list;
		}

		public List<LocationInfo> GetLocationSubstoreWise(int substoreId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(LocationDao.getLocationDao(16547), substoreId);
			}
			IDataReader dataReader;
			List<LocationInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.locationInfo3(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<LocationInfo> locationInfo3 ( IDataReader dataReader)
		{
			List<LocationInfo> list = new List<LocationInfo>();
			while (dataReader.Read())
			{
				LocationInfo item = new LocationInfo
				{
					DG_Location_pkey = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16389), 0),
					DG_Location_Name = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16364), string.Empty),
					DG_Location_PhoneNumber = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16485), string.Empty),
					DG_Location_IsActive = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16518), false)
				};
				list.Add(item);
			}
			return list;
		}

		public LocationInfo Get(int? locationId)
		{
			List<LocationInfo> source;
			do
			{
				if (7 != 0 && !false)
				{
					base.DBParameters.Clear();
					base.AddParameter(LocationDao.getLocationDao(16204), base.SetNullIntegerValue(locationId));
				}
				using (IDataReader dataReader = base.ExecuteReader(""))
				{
					source = this.locationInfo4(dataReader);
				}
			}
			while (-1 == 0);
			return source.FirstOrDefault<LocationInfo>();
		}

		private List<LocationInfo> locationInfo4 ( IDataReader dataReader)
		{
			List<LocationInfo> list = new List<LocationInfo>();
			while (dataReader.Read())
			{
				LocationInfo item = new LocationInfo
				{
					DG_Location_pkey = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16389), 0),
					DG_Location_Name = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16364), string.Empty),
					DG_Store_ID = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16468), 0),
					DG_Location_PhoneNumber = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16485), string.Empty),
					DG_Location_IsActive = base.GetFieldValue(dataReader, LocationDao.getLocationDao(16518), false),
					SyncCode = base.GetFieldValue(dataReader, LocationDao.getLocationDao(1985), string.Empty),
					IsSynced = base.GetFieldValue(dataReader, LocationDao.getLocationDao(1998), false)
				};
				list.Add(item);
			}
			return list;
		}

		public bool IsLocationAssociatedToSite(int _locationId)
		{
			base.DBParameters.Clear();
			string expr_A6 = LocationDao.getLocationDao(16204);
			object expr_28 = _locationId;
			if (true)
			{
				base.AddParameter(expr_A6, expr_28);
			}
			base.AddParameter(LocationDao.getLocationDao(16564), 0, ParameterDirection.Output);
			if (2 != 0)
			{
				base.ExecuteNonQuery("");
				if ((int)base.GetOutParameterValue(LocationDao.getLocationDao(16564)) <= 0)
				{
					return false;
				}
			}
			return true;
		}

		public bool IsSiteAssociatedToLocation(int subStoreId)
		{
			base.DBParameters.Clear();
			string expr_A6 = LocationDao.getLocationDao(16585);
			object expr_28 = subStoreId;
			if (true)
			{
				base.AddParameter(expr_A6, expr_28);
			}
			base.AddParameter(LocationDao.getLocationDao(16602), 0, ParameterDirection.Output);
			if (2 != 0)
			{
				base.ExecuteNonQuery("");
				if ((int)base.GetOutParameterValue(LocationDao.getLocationDao(16602)) <= 0)
				{
					return false;
				}
			}
			return true;
		}

		static LocationDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(LocationDao));
		}
	}
}
