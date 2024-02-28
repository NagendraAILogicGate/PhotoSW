//using #2j;
using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace PhotoSW.IMIX.DataAccess
{
	public class SubStoreLocationDao : BaseDataAccess
	{
		
      internal static SmartAssembly .Delegates.GetString getSubStoreLocationDao;
		public SubStoreLocationDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public SubStoreLocationDao()
		{
		}

		public int InsertSubStoreLocation(SubStoreLocationInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(SubStoreLocationDao.getSubStoreLocationDao(29264), objectInfo.DG_SubStore_ID);
			base.AddParameter(SubStoreLocationDao.getSubStoreLocationDao(29293), objectInfo.DG_Location_ID);
			base.AddParameter(SubStoreLocationDao.getSubStoreLocationDao(29322), objectInfo.DG_SubStore_Location_Pkey, ParameterDirection.Output);
			//base.ExecuteNonQuery(#1j.#ng);
			return (int)base.GetOutParameterValue(SubStoreLocationDao.getSubStoreLocationDao (29322));
		}

		public List<LocationInfo> SelectSubStoreLocations(int SubStoreId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(SubStoreLocationDao.getSubStoreLocationDao (2344), SubStoreId);
			}
			IDataReader dataReader=null;
			List<LocationInfo> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#lg);
				if (3 != 0)
				{
					result = this.LocationInfo5c(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<LocationInfo> LocationInfo5c(IDataReader IDataReader)
		{
			List<LocationInfo> list = new List<LocationInfo>();
			while (IDataReader.Read())
			{
				LocationInfo item = new LocationInfo
				{
					DG_SubStore_Location_Pkey = base.GetFieldValue(IDataReader, SubStoreLocationDao.getSubStoreLocationDao(16265), 0),
					DG_Location_Name = base.GetFieldValue(IDataReader,          SubStoreLocationDao.getSubStoreLocationDao(16379), string.Empty),
					DG_Location_pkey = base.GetFieldValue(IDataReader,          SubStoreLocationDao.getSubStoreLocationDao(16404), 0),
					DG_SubStore_ID = base.GetFieldValue(IDataReader,            SubStoreLocationDao.getSubStoreLocationDao(16323), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public SubStoreLocationInfo SelectSubStoreLocationsByLocationId(int LocationID)
		{
			base.DBParameters.Clear();
			base.AddParameter(SubStoreLocationDao.getSubStoreLocationDao (16219), LocationID);
			IDataReader dataReader=null;
			if (true && !false)
			{
				//dataReader = base.ExecuteReader(#1j.#ki);
			}
			List<SubStoreLocationInfo> source;
			do
			{
				source = this.SubStoreLocationInfoJb(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<SubStoreLocationInfo>();
		}

		private List<SubStoreLocationInfo> SubStoreLocationInfoJb(IDataReader IDataReader)
		{
			List<SubStoreLocationInfo> list = new List<SubStoreLocationInfo>();
			while (true)
			{
				while (IDataReader.Read())
				{
					SubStoreLocationInfo subStoreLocationInfo = new SubStoreLocationInfo();
					if (true)
					{
						subStoreLocationInfo.DG_SubStore_Location_Pkey = base.GetFieldValue(IDataReader, SubStoreLocationDao.getSubStoreLocationDao(16265), 0);
						subStoreLocationInfo.DG_Location_ID = base.GetFieldValue(IDataReader,            SubStoreLocationDao.getSubStoreLocationDao(16302), 0);
						subStoreLocationInfo.DG_SubStore_ID = base.GetFieldValue(IDataReader,            SubStoreLocationDao.getSubStoreLocationDao(16323), 0);
						SubStoreLocationInfo item = subStoreLocationInfo;
						list.Add(item);
					}
				}
				break;
			}
			return list;
		}

		public bool DelSubStoreLocationsBySubStoreId(int SubstoreId)
		{
			base.DBParameters.Clear();
			base.AddParameter(SubStoreLocationDao.getSubStoreLocationDao(28915), SubstoreId);
			//base.ExecuteNonQuery(#1j.#vi);
			return true;
		}

		public List<LocationInfo> SelListAvailableLocations(int SubstoreId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(SubStoreLocationDao.getSubStoreLocationDao (28915), SubstoreId);
			}
			IDataReader dataReader=null;
			List<LocationInfo> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#7h);
				if (3 != 0)
				{
					result = this.LocationInfoMb(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<LocationInfo> LocationInfoMb(IDataReader IDataReader)
		{
			List<LocationInfo> list = new List<LocationInfo>();
			while (true)
			{
				while (IDataReader.Read())
				{
					LocationInfo locationInfo = new LocationInfo();
					if (true)
					{
                        locationInfo.DG_Location_pkey = base.GetFieldValue(IDataReader, SubStoreLocationDao.getSubStoreLocationDao(16404), 0);
                        locationInfo.DG_Location_Name = base.GetFieldValue(IDataReader, SubStoreLocationDao.getSubStoreLocationDao(16379), string.Empty);
                        locationInfo.DG_Location_ID = base.GetFieldValue(IDataReader, SubStoreLocationDao.getSubStoreLocationDao(16302), 0);
						LocationInfo item = locationInfo;
						list.Add(item);
					}
				}
				break;
			}
			return list;
		}

		static SubStoreLocationDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(SubStoreLocationDao));
		}
	}
}
