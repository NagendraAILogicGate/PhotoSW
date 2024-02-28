using DigiPhoto.Cache.DataCache;
using DigiPhoto.Cache.MasterDataCache;
using DigiPhoto.Cache.Repository;
using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class SceneBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<SceneInfo> ;

			public SceneBusiness ;

			public void ()
			{
				SceneDao sceneDao = new SceneDao(this..Transaction);
				this. = sceneDao.GetSceneDetails();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SceneBusiness ;

			public SceneInfo ;

			public void ()
			{
				while (true)
				{
					SceneDao sceneDao;
					if (!false)
					{
						sceneDao = new SceneDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							sceneDao.Add(this.);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SceneInfo ;

			public SceneBusiness ;

			public int ;

			public void ()
			{
				SceneDao expr_2E = new SceneDao(this..Transaction);
				SceneDao sceneDao;
				if (!false)
				{
					sceneDao = expr_2E;
				}
				this. = sceneDao.GetSceneFromId(new int?(this.));
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SceneBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SceneBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					SceneDao sceneDao = new SceneDao(this...Transaction);
					if (!false)
					{
						this. = sceneDao.Delete(this..);
					}
				}
			}
		}

		public List<SceneInfo> GetSceneDetails()
		{
			List<SceneInfo> result;
			try
			{
				if (!false)
				{
					SceneBusiness.  = new SceneBusiness.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new List<SceneInfo>();
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					IL_3C:
					result = .;
				}
			}
			catch (Exception)
			{
				if (2 != 0)
				{
					result = null;
				}
			}
			return result;
		}

		public void SetSceneDetails(SceneInfo sceneInfo)
		{
			while (true)
			{
				SceneBusiness.  = new SceneBusiness.();
				. = sceneInfo;
				if (!false)
				{
					. = this;
					goto IL_2B;
				}
				goto IL_60;
				IL_69:
				if (false)
				{
					continue;
				}
				if (!false)
				{
					break;
				}
				goto IL_4B;
				IL_2B:
				if (!false)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
					goto IL_4B;
				}
				goto IL_69;
				IL_60:
				ICacheRepository factory;
				if (!false)
				{
					factory.RemoveFromCache();
					goto IL_69;
				}
				goto IL_2B;
				IL_4B:
				factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(SceneCache).FullName);
				goto IL_60;
			}
		}

		public SceneInfo GetSceneNameFromID(int id)
		{
			SceneBusiness.  = new SceneBusiness.();
			. = id;
			. = this;
			. = new SceneInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool DeleteScene(int id)
		{
			do
			{
			}
			while (!true);
			. = this;
			bool result;
			try
			{
				SceneBusiness.  = new SceneBusiness.();
				if (false || false)
				{
					goto IL_61;
				}
				. = ;
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				IL_56:
				bool arg_85_0 = base.Start(false);
				if (false)
				{
					goto IL_85;
				}
				IL_61:
				ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(SceneCache).FullName);
				if (false)
				{
					goto IL_56;
				}
				factory.RemoveFromCache();
				arg_85_0 = .;
				IL_85:
				result = arg_85_0;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
	}
}
