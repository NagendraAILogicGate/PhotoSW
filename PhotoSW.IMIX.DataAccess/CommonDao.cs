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
	public class CommonDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getCommon;

        public CommonDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public CommonDao()
		{
		}

		public List<TableBaseInfo> SelectAllTable()
		{
			IDataReader dataReader;
			List<TableBaseInfo> result;
			while (true)
			{
				if (!false)
				{
					dataReader = base.ExecuteReader("");
				}
				while (!false)
				{
					List<TableBaseInfo> expr_3A = this.tableBaseInfo(dataReader);
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

		private List<TableBaseInfo> tableBaseInfo ( IDataReader dataReader)
		{
			List<TableBaseInfo> list;
			while (true)
			{
				if (!false)
				{
					List<TableBaseInfo> expr_4C = new List<TableBaseInfo>();
					if (!false)
					{
						list = expr_4C;
					}
				}
				while (true)
				{
					if (dataReader.Read() && -1 != 0)
					{
						TableBaseInfo item = new TableBaseInfo
						{
							name = base.GetFieldValue(dataReader, CommonDao.getCommon(8339), string.Empty)
						};
						if (5 == 0)
						{
							break;
						}
						list.Add(item);
					}
					else
					{
						if (!true)
						{
							break;
						}
						if (!false)
						{
							return list;
						}
					}
				}
			}
			return list;
		}

		public bool ImportMasterData(DataTable dtSite, DataTable dtItem, DataTable dtpkg)
		{
			do
			{
				base.DBParameters.Clear();
				base.AddParameter(CommonDao.getCommon(8348), dtSite);
			}
			while (2 == 0);
			base.AddParameter(CommonDao.getCommon(8361), dtItem);
			base.AddParameter(CommonDao.getCommon(8374), dtpkg);
			base.ExecuteNonQuery(CommonDao.getCommon(8387));
			return true;
		}

		static CommonDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CommonDao));
		}
	}
}
