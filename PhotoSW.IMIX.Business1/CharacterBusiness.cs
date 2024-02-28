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
	public class CharacterBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<CharacterInfo> ;

			public CharacterBusiness ;

			public void ()
			{
				CharacterDao characterDao = new CharacterDao(this..Transaction);
				this. = characterDao.GetCharacter();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int? ;

			public CharacterBusiness ;

			public string ;

			public void ()
			{
				do
				{
					CharacterDao characterDao;
					if (!false)
					{
						characterDao = new CharacterDao(this..Transaction);
					}
					this. = characterDao.GetCharacterId(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<CharacterInfo> ;

			public CharacterBusiness ;

			public CharacterInfo ;

			public void ()
			{
				do
				{
					CharacterDao characterDao;
					if (!false)
					{
						characterDao = new CharacterDao(this..Transaction);
					}
					this. = characterDao.GetCharacter(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public CharacterBusiness ;

			public CharacterInfo ;

			public void ()
			{
				do
				{
					CharacterDao characterDao;
					if (!false)
					{
						characterDao = new CharacterDao(this..Transaction);
					}
					this. = characterDao.InsertCharacter(this.);
				}
				while (false);
			}
		}

		public List<CharacterInfo> GetCharacter()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					2. = this;
				}
				while (false);
				2. = new List<CharacterInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(2.2);
				}
				while (2 == 0);
				base.Start(false);
			}
			return 2.;
		}

		public int? GetCharacterId(string PhotographerId)
		{
			CharacterBusiness.  = new CharacterBusiness.();
			. = PhotographerId;
			. = this;
			. = null;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<CharacterInfo> GetCharacter(CharacterInfo obj)
		{
			if (!false)
			{
				if (-1 == 0)
				{
					goto IL_22;
				}
			}
			if (6 == 0)
			{
				goto IL_84;
			}
			2. = obj;
			IL_22:
			2. = this;
			2. = new List<CharacterInfo>();
			IL_40:
			this.operation = new BaseBusiness.TransactionMethod(2.);
			ICacheRepository factory;
			if (6 != 0)
			{
				base.Start(false);
				if (2..DG_Character_OperationType != 3)
				{
					goto IL_8D;
				}
				factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(CharacterCache).FullName);
			}
			IL_84:
			if (false)
			{
				goto IL_40;
			}
			factory.RemoveFromCache();
			IL_8D:
			return 2.;
		}

		public bool InsertCharacter(CharacterInfo charInfo)
		{
			CharacterBusiness.  = new CharacterBusiness.();
			. = charInfo;
			. = this;
			. = false;
			if (8 != 0)
			{
				this.operation = new BaseBusiness.TransactionMethod(.);
			}
			base.Start(false);
			ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(CharacterCache).FullName);
			factory.RemoveFromCache();
			return .;
		}
	}
}
