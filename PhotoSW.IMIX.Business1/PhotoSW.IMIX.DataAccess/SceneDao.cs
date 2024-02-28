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
	public class SceneDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getSceneDao;
        public SceneDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public SceneDao()
		{
		}

		public List<SceneInfo> GetSceneDetails()
		{
			base.OpenConnection();
			IDataReader dataReader = base.ExecuteReader("");
			List<SceneInfo> result;
			try
			{
				result = this.SceneInfo(dataReader);
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

		private List<SceneInfo> SceneInfo ( IDataReader IDataReader )
		{
			List<SceneInfo> list;
			if (2 != 0)
			{
				list = new List<SceneInfo>();
				goto IL_18A;
			}
			IL_181:
			SceneInfo sceneInfo;
			SceneInfo item = sceneInfo;
			list.Add(item);
			IL_18A:
			if (!IDataReader.Read())
			{
				if (!false)
				{
					return list;
				}
			}
			else
			{
				sceneInfo = new SceneInfo();
				sceneInfo.SceneId = base.GetFieldValue(IDataReader, SceneDao.getSceneDao(27227), 0);
				do
				{
					sceneInfo.ProductId = base.GetFieldValue(IDataReader, SceneDao.getSceneDao(27240), 0);
					sceneInfo.ProductName = base.GetFieldValue(IDataReader, SceneDao.getSceneDao(27253), string.Empty);
				}
				while (false);
				sceneInfo.BackGroundId = base.GetFieldValue(IDataReader, SceneDao.getSceneDao(27270), 0);
				sceneInfo.BackgroundName = base.GetFieldValue(IDataReader, SceneDao.getSceneDao(27287), string.Empty);
				sceneInfo.BorderId = base.GetFieldValue(IDataReader, SceneDao.getSceneDao(27308), 0);
				sceneInfo.BorderName = base.GetFieldValue(IDataReader, SceneDao.getSceneDao(27321), string.Empty);
			}
			sceneInfo.SyncCode = base.GetFieldValue(IDataReader, SceneDao.getSceneDao(1996), string.Empty);
			sceneInfo.IsSynced = base.GetFieldValue(IDataReader, SceneDao.getSceneDao(2009), false);
			sceneInfo.IsActive = base.GetFieldValue(IDataReader, SceneDao.getSceneDao(3096), false);
			sceneInfo.SceneName = base.GetFieldValue(IDataReader, SceneDao.getSceneDao(27338), string.Empty);
			goto IL_181;
		}

		public bool Add(SceneInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(SceneDao.getSceneDao(27351), objectInfo.ProductId);
			base.AddParameter(SceneDao.getSceneDao(27372), objectInfo.BackGroundId);
			base.AddParameter(SceneDao.getSceneDao(27397), objectInfo.BorderId);
			base.AddParameter(SceneDao.getSceneDao(27418), objectInfo.GraphicsId);
			base.AddParameter(SceneDao.getSceneDao(27439), objectInfo.SyncCode);
			base.AddParameter(SceneDao.getSceneDao(27452), objectInfo.IsSynced);
			base.AddParameter(SceneDao.getSceneDao(27465), objectInfo.IsActive);
			base.AddParameter(SceneDao.getSceneDao(27478), objectInfo.SceneName);
			base.AddParameter(SceneDao.getSceneDao(27499), objectInfo.SceneId);
			base.ExecuteNonQuery("");
			return true;
		}

		public bool Delete(int objectvalueId)
		{
			base.DBParameters.Clear();
			base.AddParameter(SceneDao.getSceneDao(27499), objectvalueId);
			base.ExecuteNonQuery("");
			return true;
		}

		public SceneInfo GetSceneFromId(int? sceneId)
		{
			List<SceneInfo> source;
			do
			{
				if (7 != 0 && !false)
				{
					base.DBParameters.Clear();
					base.AddParameter(SceneDao.getSceneDao(27520), base.SetNullIntegerValue(sceneId));
				}
				using (IDataReader dataReader = base.ExecuteReader(""))
				{
					source = this.SceneInfo(dataReader);
				}
			}
			while (-1 == 0);
			return source.FirstOrDefault<SceneInfo>();
		}

		static SceneDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(SceneDao));
		}
	}
}
