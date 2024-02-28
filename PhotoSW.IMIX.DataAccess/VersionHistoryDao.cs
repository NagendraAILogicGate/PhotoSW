//using #2j;


using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class VersionHistoryDao : BaseDataAccess
	{
		//[NonSerialized]
		//internal static SmartAssembly.Delegates.GetString getVersionHistoryDao;
        internal static SmartAssembly.Delegates.GetString getVersionHistoryDao;
		public VersionHistoryDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public VersionHistoryDao()
		{
		}

		public List<VersionHistoryInfo> GetVersionDetails(string MachineName)
		{
			IDataReader dataReader;
			List<VersionHistoryInfo> result;
			while (-1 != 0)
			{
				base.DBParameters.Clear();
				if (false)
				{
					break;
				}
				base.AddParameter(VersionHistoryDao.getVersionHistoryDao (30734), MachineName);
				if (8 != 0)
				{
					if (!false)
					{
						dataReader = base.ExecuteReader(VersionHistoryDao.getVersionHistoryDao (30734));
						result = this.VersionHistoryInfomd(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private List<VersionHistoryInfo> VersionHistoryInfomd(IDataReader IDataReader)
		{
			List<VersionHistoryInfo> list = new List<VersionHistoryInfo>();
			while (IDataReader.Read())
			{
				VersionHistoryInfo item = new VersionHistoryInfo
				{
					DG_Version_Pkey = base.GetFieldValue(IDataReader, VersionHistoryDao.getVersionHistoryDao (30759), 0),
					DG_Version_Number = base.GetFieldValue(IDataReader, VersionHistoryDao.getVersionHistoryDao (30780), string.Empty),
					DG_Version_Date = base.GetFieldValue(IDataReader, VersionHistoryDao.getVersionHistoryDao (30805), DateTime.Now),
					DG_UpdatedBY = base.GetFieldValue(IDataReader, VersionHistoryDao.getVersionHistoryDao (30826), 0),
                    DG_Machine = base.GetFieldValue(IDataReader, VersionHistoryDao.getVersionHistoryDao(30843), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		static VersionHistoryDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(VersionHistoryDao));
		}
	}
}
