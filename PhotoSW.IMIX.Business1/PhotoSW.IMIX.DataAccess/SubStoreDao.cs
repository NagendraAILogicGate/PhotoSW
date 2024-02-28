
using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PhotoSW.IMIX.DataAccess
{
	public class SubStoreDao : BaseDataAccess
	{
		internal static SmartAssembly .Delegates.GetString getSubStoreDao;

		public SubStoreDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public SubStoreDao()
		{
		}

		public List<SubStoresInfo> GetSubstoreData()
		{
			IDataReader dataReader=null;
			List<SubStoresInfo> result;
			while (true)
			{
				if (!false)
				{
					//dataReader = base.ExecuteReader(#1j.#Zf);
				}
				while (!false)
				{
					List<SubStoresInfo> expr_3A = this.SubStoresInfoWc(dataReader);
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

		public List<SubStoresInfo> GetSubstoreDataFillGrid()
		{
			IDataReader dataReader=null;
			List<SubStoresInfo> result;
			while (true)
			{
				if (!false)
				{
					//dataReader = base.ExecuteReader(#1j.#Wj);
				}
				while (!false)
				{
					List<SubStoresInfo> expr_3A = this.SubStoresInfoWc(dataReader);
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

		public List<SiteCodeDetail> GetSiteCodeAccess()
		{
			IDataReader dataReader=null;
			List<SiteCodeDetail> result;
			while (true)
			{
				if (!false)
				{
					//dataReader = base.ExecuteReader(#1j.#Xj);
				}
				while (!false)
				{
					List<SiteCodeDetail> expr_3A = this.SiteCodeDetailXc(dataReader);
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

		public List<SubStoresInfo> GetLoginUserDefaultSubstores(int subStoreId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(SubStoreDao.getSubStoreDao(1128), subStoreId);
			}
			IDataReader dataReader=null;
			List<SubStoresInfo> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#0f);
				if (3 != 0)
				{
					result = this.SubStoresInfoWc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<SubStoresInfo> SubStoresInfoWc(IDataReader IDataReader)
		{
			List<SubStoresInfo> list = new List<SubStoresInfo>();
			while (IDataReader.Read())
			{
				SubStoresInfo item = new SubStoresInfo
				{
					DG_SubStore_pkey = base.GetFieldValue(IDataReader,        SubStoreDao.getSubStoreDao(24579), 0),
					DG_SubStore_Name = base.GetFieldValue(IDataReader,        SubStoreDao.getSubStoreDao(12894), string.Empty),
					DG_SubStore_Description = base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao(28655), string.Empty),
					DG_SubStore_Locations = base.GetFieldValue(IDataReader,   SubStoreDao.getSubStoreDao(28688), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		private List<SiteCodeDetail> SiteCodeDetailXc(IDataReader IDataReader)
		{
			List<SiteCodeDetail> list = new List<SiteCodeDetail>();
			while (true)
			{
				if (4 == 0)
				{
					goto IL_6B;
				}
				IL_72:
				SiteCodeDetail siteCodeDetail;
				if (!IDataReader.Read())
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
					siteCodeDetail = new SiteCodeDetail();
					siteCodeDetail.SiteId = base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao (28717), 0);
				}
				if (!false)
				{
					siteCodeDetail.SiteCode = base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao (28726), string.Empty);
				}
				SiteCodeDetail item = siteCodeDetail;
				IL_6B:
				list.Add(item);
				goto IL_72;
			}
			return list;
		}

		public List<string> GetBackupSubStoreNameBySubStoreId(int SubStoreId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(SubStoreDao.getSubStoreDao (2343), SubStoreId);
			}
			IDataReader dataReader=null;
			List<string> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#xi);
				if (3 != 0)
				{
					result = this.ListYc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<string> ListYc(IDataReader IDataReader)
		{
			List<string> list = new List<string>();
			while (IDataReader.Read() && !false)
			{
				list.Add(base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao(12894), string.Empty));
			}
			return list;
		}

		public Dictionary<string, string> GetSubstoreDataDir()
		{
			IDataReader dataReader=null;
			Dictionary<string, string> result;
			while (true)
			{
                //if (!false)
                //{
                //    dataReader = base.ExecuteReader(#1j.#Zf);
                //}
				while (!false)
				{
					Dictionary<string, string> expr_3A = this.DictionaryZc(dataReader);
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

		private Dictionary<string, string> DictionaryZc(IDataReader IDataReader)
		{
			Dictionary<string, string> dictionary;
			if (!false)
			{
				dictionary = new Dictionary<string, string>();
				while (2 == 0 || IDataReader.Read())
				{
					dictionary.Add(base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao(24579), 0).ToString(), base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao(12894), string.Empty));
				}
			}
			return dictionary;
		}

		public SubStoresInfo GetSubstoreData(int SubStore_pkey, bool SubStore_IsActive)
		{
			base.DBParameters.Clear();
			base.AddParameter(SubStoreDao.getSubStoreDao(28739), SubStore_pkey);
			base.AddParameter(SubStoreDao.getSubStoreDao(28768), SubStore_IsActive);
			IDataReader dataReader =null; //base.ExecuteReader(#1j.#1i);
			List<SubStoresInfo> source = this.SubStoresInfo0c(dataReader);
			dataReader.Close();
			return source.FirstOrDefault<SubStoresInfo>();
		}

		private List<SubStoresInfo> SubStoresInfo0c(IDataReader IDataReader)
		{
			List<SubStoresInfo> expr_174 = new List<SubStoresInfo>();
			List<SubStoresInfo> list;
			if (3 != 0)
			{
				list = expr_174;
			}
			while (IDataReader.Read())
			{
				SubStoresInfo item = new SubStoresInfo
				{
					DG_SubStore_pkey = base.GetFieldValue(IDataReader,           SubStoreDao.getSubStoreDao(24579), 0),
					DG_SubStore_Name = base.GetFieldValue(IDataReader,           SubStoreDao.getSubStoreDao(12894), string.Empty),
					DG_SubStore_Description = base.GetFieldValue(IDataReader,    SubStoreDao.getSubStoreDao(28655), string.Empty),
					DG_SubStore_IsActive = base.GetFieldValue(IDataReader,       SubStoreDao.getSubStoreDao(28801), false),
					SyncCode = base.GetFieldValue(IDataReader,                   SubStoreDao.getSubStoreDao(1999), string.Empty),
					IsSynced = base.GetFieldValue(IDataReader,                   SubStoreDao.getSubStoreDao(2012), false),
					IsLogicalSubStore = base.GetFieldValue(IDataReader,          SubStoreDao.getSubStoreDao(28830), false),
					LogicalSubStoreID = new int?(base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao(28855), 0)),
					DG_SubStore_Code = base.GetFieldValue(IDataReader,           SubStoreDao.getSubStoreDao(28880), string.Empty),
					SiteID = base.GetFieldValue(IDataReader,                     SubStoreDao.getSubStoreDao(28905), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public string DelSubstoreByID(int SubstoreId)
		{
			base.DBParameters.Clear();
			base.AddParameter(SubStoreDao.getSubStoreDao(28914), SubstoreId);
			base.AddParameter(SubStoreDao.getSubStoreDao(28939), SubStoreDao.getSubStoreDao(24181), ParameterDirection.Output);
			//base.ExecuteNonQuery(#1j.#wi);
			return Convert.ToString(base.GetOutParameterValue(SubStoreDao.getSubStoreDao (28939)));
		}

		public bool Update(SubStoresInfo objectInfo)
		{
			if (true)
			{
				base.DBParameters.Clear();
			}
			base.AddParameter(SubStoreDao.getSubStoreDao(28948), objectInfo.DG_SubStore_pkey);
			base.AddParameter(SubStoreDao.getSubStoreDao(428), objectInfo.IsSynced);
			base.AddParameter(SubStoreDao.getSubStoreDao(28981), objectInfo.DG_SubStore_Name);
			base.AddParameter(SubStoreDao.getSubStoreDao(29014), objectInfo.DG_SubStore_Description);
			if (!false)
			{
				base.AddParameter(SubStoreDao.getSubStoreDao(29055), objectInfo.IsLogicalSubStore);
			}
			base.AddParameter(SubStoreDao.getSubStoreDao(29076), objectInfo.LogicalSubStoreID);
			base.AddParameter(SubStoreDao.getSubStoreDao(29109), objectInfo.DG_SubStore_Code);
			//base.ExecuteNonQuery(#1j.#kg);
			return true;
		}

		public int InsertSubStore(SubStoresInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(SubStoreDao.getSubStoreDao(2343), objectInfo.DG_SubStore_pkey);
			base.AddParameter(SubStoreDao.getSubStoreDao(29122), objectInfo.DG_SubStore_IsActive);
			base.AddParameter(SubStoreDao.getSubStoreDao(428), objectInfo.IsSynced);
			base.AddParameter(SubStoreDao.getSubStoreDao(28981), objectInfo.DG_SubStore_Name);
			base.AddParameter(SubStoreDao.getSubStoreDao(29014), objectInfo.DG_SubStore_Description);
			base.AddParameter(SubStoreDao.getSubStoreDao(407), objectInfo.SyncCode);
			base.AddParameter(SubStoreDao.getSubStoreDao(29055), objectInfo.IsLogicalSubStore);
			base.AddParameter(SubStoreDao.getSubStoreDao(29076), objectInfo.LogicalSubStoreID);
			base.AddParameter(SubStoreDao.getSubStoreDao(29109), objectInfo.DG_SubStore_Code);
			//base.ExecuteNonQuery(#1j.#ig);
			return (int)base.GetOutParameterValue(SubStoreDao.getSubStoreDao (2343));
		}

		public List<SubStoresInfo> Getvw_GetSubStoreData()
		{
			IDataReader dataReader=null;
			List<SubStoresInfo> result;
			while (true)
			{
				if (!false)
				{
					//dataReader = base.ExecuteReader(#1j.#sg);
				}
				while (!false)
				{
					List<SubStoresInfo> expr_3A = this.SubStoresInfo1c(dataReader);
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

		public List<SubStoresInfo> Getvw_GetLogicalSubStoreData()
		{
			IDataReader dataReader=null;
			List<SubStoresInfo> result=null;
			while (true)
			{
				if (!false)
				{
					//dataReader = base.ExecuteReader(#1j.#Yj);
				}
				while (!false)
				{
					List<SubStoresInfo> expr_3A = this.SubStoresInfo2c(dataReader);
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

		private List<SubStoresInfo> SubStoresInfo1c(IDataReader IDataReader)
		{
			List<SubStoresInfo> list = new List<SubStoresInfo>();
			while (IDataReader.Read())
			{
				SubStoresInfo item = new SubStoresInfo
				{
					DG_SubStore_pkey = base.GetFieldValue(IDataReader,        SubStoreDao.getSubStoreDao(24579), 0),
					DG_SubStore_Name = base.GetFieldValue(IDataReader,        SubStoreDao.getSubStoreDao(12894), string.Empty),
					DG_SubStore_Description = base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao(28655), string.Empty),
					DG_SubStore_Locations = base.GetFieldValue(IDataReader,   SubStoreDao.getSubStoreDao(28688), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		private List<SubStoresInfo> SubStoresInfo2c(IDataReader IDataReader)
		{
			List<SubStoresInfo> list = new List<SubStoresInfo>();
			while (IDataReader.Read())
			{
				SubStoresInfo item = new SubStoresInfo
				{
					DG_SubStore_pkey = base.GetFieldValue(IDataReader,           SubStoreDao.getSubStoreDao(24579), 0),
					DG_SubStore_Name = base.GetFieldValue(IDataReader,           SubStoreDao.getSubStoreDao(12894), string.Empty),
					DG_SubStore_Description = base.GetFieldValue(IDataReader,    SubStoreDao.getSubStoreDao(28655), string.Empty),
					DG_SubStore_Locations = base.GetFieldValue(IDataReader,      SubStoreDao.getSubStoreDao(28688), string.Empty),
					DG_SubStore_Code = base.GetFieldValue(IDataReader,           SubStoreDao.getSubStoreDao(28880), string.Empty),
					SiteID = base.GetFieldValue(IDataReader,                     SubStoreDao.getSubStoreDao(28905), 0),
					IsLogicalSubStore = base.GetFieldValue(IDataReader,          SubStoreDao.getSubStoreDao(28830), false),
					LogicalSubStoreID = new int?(base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao(28855), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public List<SubStoresInfo> GetLogicalSubStore()
		{
			IDataReader dataReader=null;
			List<SubStoresInfo> result=null;
			while (true)
			{
				if (!false)
				{
					//dataReader = base.ExecuteReader(#1j.#Zj);
				}
				while (!false)
				{
					List<SubStoresInfo> expr_3A = this.SubStoresInfo3c(dataReader);
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

		private List<SubStoresInfo> SubStoresInfo3c(IDataReader IDataReader)
		{
			List<SubStoresInfo> list = new List<SubStoresInfo>();
			while (IDataReader.Read())
			{
				SubStoresInfo item = new SubStoresInfo
				{
					DG_SubStore_pkey = base.GetFieldValue(IDataReader,        SubStoreDao.getSubStoreDao(24579), 0),
					DG_SubStore_Name = base.GetFieldValue(IDataReader,        SubStoreDao.getSubStoreDao(12894), string.Empty),
					DG_SubStore_Description = base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao(28655), string.Empty),
					DG_SubStore_IsActive = base.GetFieldValue(IDataReader,    SubStoreDao.getSubStoreDao(28801), false)
				};
				list.Add(item);
			}
			return list;
		}

		public List<RfidInfo> GetRfidAccess(int SubStoreId)
		{
			List<RfidInfo> result;
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
					base.AddParameter(SubStoreDao.getSubStoreDao(2343), SubStoreId);
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
				dataReader = base.ExecuteReader(SubStoreDao.getSubStoreDao(29159));
				result = this.RfidInfo4c(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<RfidInfo> RfidInfo4c(IDataReader IDataReader)
		{
			List<RfidInfo> list = new List<RfidInfo>();
			do
			{
				while (true)
				{
					RfidInfo rfidInfo;
					if (!IDataReader.Read())
					{
						if (!false)
						{
							break;
						}
					}
					else
					{
						rfidInfo = new RfidInfo();
						rfidInfo.ImixConfigValueID = base.GetFieldValue(IDataReader,    SubStoreDao.getSubStoreDao(10354), 0L);
						rfidInfo.ImixConfigMasterID = base.GetFieldValue(IDataReader,   SubStoreDao.getSubStoreDao(10387), 0L);
						rfidInfo.ImixConfigMasterName = base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao(29200), string.Empty);
						rfidInfo.ConfigurationValue = base.GetFieldValue(IDataReader,   SubStoreDao.getSubStoreDao(10424), string.Empty);
					}
					rfidInfo.SubStoreId = base.GetFieldValue(IDataReader,   SubStoreDao.getSubStoreDao(2534), 0);
					rfidInfo.SubStoreName = base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao(29229), string.Empty);
					rfidInfo.LocationId = base.GetFieldValue(IDataReader,   SubStoreDao.getSubStoreDao(12392), 0);
					rfidInfo.LocationName = base.GetFieldValue(IDataReader, SubStoreDao.getSubStoreDao(29246), string.Empty);
					RfidInfo item = rfidInfo;
					list.Add(item);
				}
			}
			while (8 == 0);
			return list;
		}

		static SubStoreDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(SubStoreDao));
		}
	}
}
