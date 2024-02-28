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
	public class GraphicsDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getGraphics;
        public GraphicsDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public GraphicsDao()
		{
		}

		public List<GraphicsInfo> Select()
		{
			IDataReader dataReader = base.ExecuteReader("");
			//goto IL_0B;
			List<GraphicsInfo> result;
			try
			{
				do
				{
					IL_0B:
					result = this.graphicsInfo(dataReader);
				}
				while (3 == 0 || false);
			}
			finally
			{
				if (dataReader != null)
				{
					dataReader.Dispose();
				}
			}
			return result;
		}

		private List<GraphicsInfo> graphicsInfo ( IDataReader dataReader)
		{
			List<GraphicsInfo> expr_178 = new List<GraphicsInfo>();
			List<GraphicsInfo> list;
			if (3 != 0)
			{
				list = expr_178;
			}
			while (dataReader.Read())
			{
				GraphicsInfo item = new GraphicsInfo
				{
					DG_Graphics_pkey = base.GetFieldValue(dataReader, GraphicsDao.getGraphics(15575), 0),
					DG_Graphics_Name = base.GetFieldValue(dataReader, GraphicsDao.getGraphics(15600), string.Empty),
					DG_Graphics_Displayname = base.GetFieldValue(dataReader, GraphicsDao.getGraphics(15625), string.Empty),
					DG_Graphics_IsActive = new bool?(base.GetFieldValue(dataReader, GraphicsDao.getGraphics(15658), false)),
					SyncCode = base.GetFieldValue(dataReader, GraphicsDao.getGraphics(1982), string.Empty),
					IsSynced = base.GetFieldValue(dataReader, GraphicsDao.getGraphics(1995), false),
					CreatedBy = base.GetFieldValue(dataReader, GraphicsDao.getGraphics(2847), 0),
					ModifiedBy = base.GetFieldValue(dataReader, GraphicsDao.getGraphics(2860), 0),
					CreatedDate = base.GetFieldValue(dataReader, GraphicsDao.getGraphics(2877), DateTime.MinValue),
					ModifiedDate = base.GetFieldValue(dataReader, GraphicsDao.getGraphics(2894), DateTime.MinValue)
				};
				list.Add(item);
			}
			return list;
		}

		public int Add(GraphicsInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(GraphicsDao.getGraphics(15687), objectInfo.DG_Graphics_Name);
			base.AddParameter(GraphicsDao.getGraphics(15720), objectInfo.DG_Graphics_Displayname);
			base.AddParameter(GraphicsDao.getGraphics(15761), objectInfo.DG_Graphics_IsActive);
			do
			{
				base.AddParameter(GraphicsDao.getGraphics(390), objectInfo.SyncCode);
				base.AddParameter(GraphicsDao.getGraphics(411), objectInfo.IsSynced);
				base.AddParameter(GraphicsDao.getGraphics(2205), objectInfo.CreatedBy);
			}
			while (6 == 0);
			base.AddParameter(GraphicsDao.getGraphics(15798), objectInfo.DG_Graphics_pkey, ParameterDirection.Output);
			base.ExecuteNonQuery("");
			return (int)base.GetOutParameterValue(GraphicsDao.getGraphics(15798));
		}

		public bool Delete(int objectvalueId)
		{
			base.DBParameters.Clear();
			base.AddParameter(GraphicsDao.getGraphics(15798), objectvalueId);
			base.ExecuteNonQuery("");
			return true;
		}

		public bool Update(GraphicsInfo objectInfo)
		{
			if (true)
			{
				base.DBParameters.Clear();
			}
			do
			{
				base.AddParameter(GraphicsDao.getGraphics(15687), objectInfo.DG_Graphics_Name);
				base.AddParameter(GraphicsDao.getGraphics(15720), objectInfo.DG_Graphics_Displayname);
				base.AddParameter(GraphicsDao.getGraphics(15761), objectInfo.DG_Graphics_IsActive);
				base.AddParameter(GraphicsDao.getGraphics(390), objectInfo.SyncCode);
				base.AddParameter(GraphicsDao.getGraphics(411), objectInfo.IsSynced);
			}
			while (7 == 0);
			base.AddParameter(GraphicsDao.getGraphics(15823), objectInfo.DG_Graphics_pkey);
			base.AddParameter(GraphicsDao.getGraphics(15848), objectInfo.ModifiedBy);
			base.ExecuteNonQuery("");
			return true;
		}

		static GraphicsDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
		//	SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(GraphicsDao));
		}
	}
}
