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
	public class BackGroundDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getStrBase;
        public BackGroundDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public BackGroundDao()
		{

		}

		public List<BackGroundInfo> SelectBackground()
		{
			base.DBParameters.Clear();
			base.OpenConnection();
			base.AddParameter(BackGroundDao.getStrBase(1708), base.SetNullIntegerValue(null));
			base.AddParameter(BackGroundDao.getStrBase(1733), base.SetNullIntegerValue(null));
			base.AddParameter(BackGroundDao.getStrBase(1754), base.SetNullIntegerValue(null));
			base.AddParameter(BackGroundDao.getStrBase(1775), base.SetNullStringValue(null));
			List<BackGroundInfo> result;
			using (IDataReader dataReader = base.ExecuteReader(""))
			{
				result = this.backGroundInfo(dataReader);
			}
			return result;
		}

		public List<BackGroundInfo> Select(int? backgroundId, int productId, int groupId, string backgroundImageName)
		{
			base.DBParameters.Clear();
			string expr_DF = BackGroundDao.getStrBase(1708);
			object expr_F5 = base.SetNullIntegerValue(backgroundId);
			if (-1 != 0)
			{
				base.AddParameter(expr_DF, expr_F5);
			}
			base.AddParameter(BackGroundDao.getStrBase(1733), base.SetNullIntegerValue(new int?(productId)));
			base.AddParameter(BackGroundDao.getStrBase(1754), base.SetNullIntegerValue(new int?(groupId)));
			base.AddParameter(BackGroundDao.getStrBase(1775), base.SetNullStringValue(backgroundImageName));
			IDataReader dataReader = base.ExecuteReader("");
			List<BackGroundInfo> result;
			try
			{
				result = this.backGroundInfo(dataReader);
			}
			finally
			{
				if (5 == 0 || dataReader != null)
				{
					dataReader.Dispose();
				}
			}
			return result;
		}

		private List<BackGroundInfo> backGroundInfo ( IDataReader dateReader)
		{
			List<BackGroundInfo> list = new List<BackGroundInfo>();
			try
			{
				while (dateReader.Read())
				{
                    BackGroundInfo item = new BackGroundInfo
                        {
                        DG_Background_pkey = base.GetFieldValue(dateReader, BackGroundDao.getStrBase(1812), 0),
                        DG_Product_Id = base.GetFieldValue(dateReader, BackGroundDao.getStrBase(1837), 0),
                        DG_BackGround_Image_Name = base.GetFieldValue(dateReader, BackGroundDao.getStrBase(1858), string.Empty),
                        DG_BackGround_Image_Display_Name = base.GetFieldValue(dateReader, BackGroundDao.getStrBase(1891), string.Empty),
                        DG_BackGround_Group_Id = new int?(base.GetFieldValue(dateReader, BackGroundDao.getStrBase(1936), 0)),
                        SyncCode = base.GetFieldValue(dateReader, BackGroundDao.getStrBase(1969), string.Empty),
                        IsSynced = base.GetFieldValue(dateReader, BackGroundDao.getStrBase(1982), false),
                        DG_Background_IsActive = new bool?(base.GetFieldValue(dateReader, BackGroundDao.getStrBase(1995), false))
					};
					list.Add(item);
				}
			}
			catch (Exception)
			{
			}
			return list;
		}

		public BackGroundInfo Get(int? backgroundId, int productId, int groupId, string backgroundImageName)
		{
			base.DBParameters.Clear();
			base.AddParameter(BackGroundDao.getStrBase(1708), base.SetNullIntegerValue(backgroundId));
			base.AddParameter(BackGroundDao.getStrBase(1733), base.SetNullIntegerValue(new int?(productId)));
			base.AddParameter(BackGroundDao.getStrBase(1754), base.SetNullIntegerValue(new int?(groupId)));
			base.AddParameter(BackGroundDao.getStrBase(1775), base.SetNullStringValue(backgroundImageName));
            //IDataReader dataReader = base.ExecuteReader(#1j.#Ig);
            IDataReader dataReader = base.ExecuteReader("");
			List <BackGroundInfo> source;
			try
			{
				source = this.backGroundInfo(dataReader);
			}
			finally
			{
				if (dataReader == null)
				{
					goto IL_B5;
				}
				IL_AF:
				dataReader.Dispose();
				IL_B5:
				if (-1 == 0)
				{
					goto IL_AF;
				}
			}
			return source.FirstOrDefault<BackGroundInfo>();
		}

		public List<BackGroundInfo> GetBackgroundByGroup()
		{
			base.DBParameters.Clear();
            //IDataReader dataReader = base.ExecuteReader(#1j.#Lg);
            IDataReader dataReader = base.ExecuteReader("");
			List <BackGroundInfo> result;
			try
			{
				result = this.backGroundInfo(dataReader);
			}
			finally
			{
				while (false || dataReader != null)
				{
					if (!false)
					{
						dataReader.Dispose();
						break;
					}
				}
			}
			return result;
		}

		public int Add(BackGroundInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(BackGroundDao.getStrBase(2028), objectInfo.DG_Product_Id);
			if (7 != 0)
			{
				base.AddParameter(BackGroundDao.getStrBase(2057), objectInfo.DG_BackGround_Image_Name);
				base.AddParameter(BackGroundDao.getStrBase(2098), objectInfo.DG_BackGround_Image_Display_Name);
				base.AddParameter(BackGroundDao.getStrBase(2151), base.SetNullIntegerValue(objectInfo.DG_BackGround_Group_Id));
				base.AddParameter(BackGroundDao.getStrBase(377), objectInfo.SyncCode);
			}
			base.AddParameter(BackGroundDao.getStrBase(398), objectInfo.IsSynced);
			base.AddParameter(BackGroundDao.getStrBase(1178), objectInfo.DG_Background_IsActive);
			base.AddParameter(BackGroundDao.getStrBase(2192), objectInfo.CreatedBy);
			base.AddParameter(BackGroundDao.getStrBase(2213), objectInfo.DG_Background_pkey, ParameterDirection.Output);
			base.ExecuteNonQuery("");
			return (int)base.GetOutParameterValue(BackGroundDao.getStrBase(2213));
		}

		public bool Update(BackGroundInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(BackGroundDao.getStrBase(2238), objectInfo.DG_Background_pkey);
			base.AddParameter(BackGroundDao.getStrBase(2028), objectInfo.DG_Product_Id);
			base.AddParameter(BackGroundDao.getStrBase(2057), objectInfo.DG_BackGround_Image_Name);
			base.AddParameter(BackGroundDao.getStrBase(2098), objectInfo.DG_BackGround_Image_Display_Name);
			base.AddParameter(BackGroundDao.getStrBase(2151), objectInfo.DG_BackGround_Group_Id);
			base.AddParameter(BackGroundDao.getStrBase(398), objectInfo.IsSynced);
			base.AddParameter(BackGroundDao.getStrBase(1178), objectInfo.DG_Background_IsActive);
			base.AddParameter(BackGroundDao.getStrBase(2271), objectInfo.ModifiedBy);
			base.ExecuteNonQuery("");
			return true;
		}

		public bool Delete(int bgID)
		{
			base.DBParameters.Clear();
			base.AddParameter(BackGroundDao.getStrBase(2296), bgID);
			base.ExecuteNonQuery("");
			return true;
		}

		static BackGroundDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(BackGroundDao));
		}
	}
}
