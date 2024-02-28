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
	public class GraphicsBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<GraphicsInfo> ;

			public GraphicsBusiness ;

			public void ()
			{
				GraphicsDao graphicsDao = new GraphicsDao(this..Transaction);
				this. = graphicsDao.Select();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public GraphicsInfo ;

			public GraphicsBusiness ;

			public void ()
			{
				while (true)
				{
					GraphicsDao graphicsDao;
					if (!false)
					{
						graphicsDao = new GraphicsDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							graphicsDao.Add(this.);
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
			public GraphicsBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public GraphicsBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					GraphicsDao graphicsDao = new GraphicsDao(this...Transaction);
					if (!false)
					{
						this. = graphicsDao.Delete(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public GraphicsInfo ;

			public GraphicsBusiness ;

			public void ()
			{
				while (true)
				{
					GraphicsDao graphicsDao;
					if (!false)
					{
						graphicsDao = new GraphicsDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							graphicsDao.Update(this.);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}
		}

		public List<GraphicsInfo> GetGraphicsDetails()
		{
			List<GraphicsInfo> result;
			try
			{
				if (!false)
				{
					GraphicsBusiness.  = new GraphicsBusiness.();
					. = this;
					if (8 != 0)
					{
						if (false)
						{
							goto IL_3C;
						}
						. = new List<GraphicsInfo>();
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

		public void SetGraphicsDetails(string graphicsname, string graphicsdisplayname, bool isactive, string SyncCode, int userId)
		{
			while (true)
			{
				IL_00:
				GraphicsBusiness.  = new GraphicsBusiness.();
				. = this;
				. = new GraphicsInfo();
				..DG_Graphics_Name = graphicsname;
				if (true)
				{
					if (-1 == 0)
					{
						goto IL_BD;
					}
					..DG_Graphics_Displayname = graphicsdisplayname;
				}
				while (true)
				{
					..DG_Graphics_IsActive = new bool?(isactive);
					while (true)
					{
						..SyncCode = SyncCode;
						if (false)
						{
							goto IL_00;
						}
						..IsSynced = false;
						..CreatedBy = userId;
						if (false)
						{
							break;
						}
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (2 != 0)
						{
							goto Block_4;
						}
					}
				}
			}
			Block_4:
			ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(ConfigurationCache).FullName);
			IL_BD:
			factory.RemoveFromCache();
		}

		public bool DeleteGraphics(int id)
		{
			if (!false && -1 != 0)
			{
			}
			. = id;
			. = this;
			bool result;
			try
			{
				GraphicsBusiness.  = new GraphicsBusiness.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public void UpdateGraphicsDetails(string graphicsname, string graphicsdisplayname, bool isactive, string SyncCode, int graphicsId, int userId)
		{
			GraphicsBusiness.  = new GraphicsBusiness.();
			. = this;
			. = new GraphicsInfo();
			..DG_Graphics_Name = graphicsname;
			..DG_Graphics_Displayname = graphicsdisplayname;
			..DG_Graphics_IsActive = new bool?(isactive);
			..SyncCode = SyncCode;
			..DG_Graphics_pkey = graphicsId;
			..IsSynced = false;
			..ModifiedBy = userId;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(ConfigurationCache).FullName);
			factory.RemoveFromCache();
		}
	}
}
