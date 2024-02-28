using DigiPhoto.Cache.DataCache;
using DigiPhoto.Cache.MasterDataCache;
using DigiPhoto.Cache.Repository;
using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class StoreSubStoreDataBusniess : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public StoreInfo ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				StoreDao storeDao = new StoreDao(this..Transaction);
				this. = storeDao.GetStore();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SubStoresInfo ;

			public StoreSubStoreDataBusniess ;

			public int ;

			public void ()
			{
				StoreDao storeDao = new StoreDao(this..Transaction);
				this. = storeDao.GetSubstoreData(this., null);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<StoreInfo> ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				StoreDao storeDao = new StoreDao(this..Transaction);
				this. = storeDao.SelectStore();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				while (true)
				{
					StoreDao storeDao;
					if (!false)
					{
						storeDao = new StoreDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							this. = storeDao.GETQRCodeWebUrl().DG_QRCodeWebUrl;
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
		private sealed class 
		{
			public List<SubStoresInfo> ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				SubStoreDao subStoreDao = new SubStoreDao(this..Transaction);
				this. = subStoreDao.GetSubstoreData();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<SubStoresInfo> ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				SubStoreDao subStoreDao = new SubStoreDao(this..Transaction);
				this. = subStoreDao.GetSubstoreDataFillGrid();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<SiteCodeDetail> ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				SubStoreDao subStoreDao = new SubStoreDao(this..Transaction);
				this. = subStoreDao.GetSiteCodeAccess();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<SubStoresInfo> ;

			public StoreSubStoreDataBusniess ;

			public int ;

			public void ()
			{
				this. = new SubStoreDao(this..Transaction).GetLoginUserDefaultSubstores(this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public Dictionary<string, string> ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				SubStoreDao subStoreDao = new SubStoreDao(this..Transaction);
				this. = subStoreDao.GetSubstoreDataDir();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<string> ;

			public StoreSubStoreDataBusniess ;

			public int ;

			public void ()
			{
				do
				{
					SubStoreDao subStoreDao;
					if (!false)
					{
						subStoreDao = new SubStoreDao(this..Transaction);
					}
					this. = subStoreDao.GetBackupSubStoreNameBySubStoreId(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<LocationInfo> ;

			public StoreSubStoreDataBusniess ;

			public int ;

			public void ()
			{
				LocationDao expr_2E = new LocationDao(this..Transaction);
				LocationDao locationDao;
				if (!false)
				{
					locationDao = expr_2E;
				}
				this. = locationDao.GetLocationSubstoreWise(this.).ToList<LocationInfo>();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public Dictionary<string, string> ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				StoreDao storeDao = new StoreDao(this..Transaction);
				this. = storeDao.SelStoreDir();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public StoreSubStoreDataBusniess ;

			public int ;

			public void ()
			{
				while (true)
				{
					SubStoreLocationDao subStoreLocationDao;
					if (!false)
					{
						subStoreLocationDao = new SubStoreLocationDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							subStoreLocationDao.DelSubStoreLocationsBySubStoreId(this.);
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
		private sealed class 
		{
			public StoreSubStoreDataBusniess ;

			public int ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public StoreSubStoreDataBusniess. ;

			public bool ;

			public int ;

			public SubStoreLocationInfo ;

			public void ()
			{
				SubStoreLocationDao subStoreLocationDao = new SubStoreLocationDao(this...Transaction);
				SubStoreLocationInfo expr_1D = this.;
				int expr_2C = this..;
				if (4 != 0)
				{
					expr_1D.DG_Location_ID = expr_2C;
				}
				this..DG_SubStore_ID = this..;
				this. = subStoreLocationDao.InsertSubStoreLocation(this.);
				if (this. > 0)
				{
					this. = true;
					return;
				}
				this. = false;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<LocationInfo> ;

			public StoreSubStoreDataBusniess ;

			public int ;

			public void ()
			{
				SubStoreLocationDao expr_2E = new SubStoreLocationDao(this..Transaction);
				SubStoreLocationDao subStoreLocationDao;
				if (!false)
				{
					subStoreLocationDao = expr_2E;
				}
				this. = subStoreLocationDao.SelListAvailableLocations(this.).ToList<LocationInfo>();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<LocationInfo> ;

			public StoreSubStoreDataBusniess ;

			public int ;

			public void ()
			{
				do
				{
					SubStoreLocationDao subStoreLocationDao;
					if (!false)
					{
						subStoreLocationDao = new SubStoreLocationDao(this..Transaction);
					}
					this. = subStoreLocationDao.SelectSubStoreLocations(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public StoreSubStoreDataBusniess ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public StoreSubStoreDataBusniess. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					StoreDao storeDao = new StoreDao(this...Transaction);
					if (!false)
					{
						this. = storeDao.UpdateStoreQRCode(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SubStoresInfo ;

			public StoreSubStoreDataBusniess ;

			public int ;

			public void ()
			{
				SubStoreDao expr_2D = new SubStoreDao(this..Transaction);
				SubStoreDao subStoreDao;
				if (!false)
				{
					subStoreDao = expr_2D;
				}
				this. = subStoreDao.GetSubstoreData(this., true);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public StoreSubStoreDataBusniess ;

			public int ;

			public void ()
			{
				do
				{
					SubStoreDao subStoreDao;
					if (!false)
					{
						subStoreDao = new SubStoreDao(this..Transaction);
					}
					this. = subStoreDao.DelSubstoreByID(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SubStoresInfo ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				while (true)
				{
					SubStoreDao subStoreDao;
					if (!false)
					{
						subStoreDao = new SubStoreDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							subStoreDao.Update(this.);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}

			public void ()
			{
				while (true)
				{
					SubStoreDao subStoreDao;
					if (!false)
					{
						subStoreDao = new SubStoreDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							subStoreDao.InsertSubStore(this.);
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
		private sealed class 
		{
			public List<SubStoresInfo> ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				while (true)
				{
					SubStoreDao subStoreDao;
					if (!false)
					{
						subStoreDao = new SubStoreDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							this. = subStoreDao.Getvw_GetSubStoreData().ToList<SubStoresInfo>();
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
		private sealed class 
		{
			public List<SubStoresInfo> ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				while (true)
				{
					SubStoreDao subStoreDao;
					if (!false)
					{
						subStoreDao = new SubStoreDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							this. = subStoreDao.Getvw_GetLogicalSubStoreData().ToList<SubStoresInfo>();
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
		private sealed class 
		{
			public string ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				while (true)
				{
					StoreDao storeDao;
					if (!false)
					{
						storeDao = new StoreDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							this. = storeDao.GetStore().Country;
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
		private sealed class 
		{
			public StoreInfo ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				StoreDao storeDao = new StoreDao(this..Transaction);
				this. = storeDao.GetStore();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<SubStoresInfo> ;

			public StoreSubStoreDataBusniess ;

			public void ()
			{
				while (true)
				{
					SubStoreDao subStoreDao;
					if (!false)
					{
						subStoreDao = new SubStoreDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							this. = subStoreDao.GetLogicalSubStore().ToList<SubStoresInfo>();
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
		private sealed class 
		{
			public List<RfidInfo> ;

			public StoreSubStoreDataBusniess ;

			public int ;

			public void ()
			{
				SubStoreDao expr_2E = new SubStoreDao(this..Transaction);
				SubStoreDao subStoreDao;
				if (!false)
				{
					subStoreDao = expr_2E;
				}
				this. = subStoreDao.GetRfidAccess(this.).ToList<RfidInfo>();
			}
		}

		[CompilerGenerated]
		private static Func<KeyValuePair<string, string>, string> ;

		[CompilerGenerated]
		private static Func<IGrouping<string, KeyValuePair<string, string>>, string> ;

		[CompilerGenerated]
		private static Func<IGrouping<string, KeyValuePair<string, string>>, string> ;

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public List<StoreInfo> SelectStores()
		{
			ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(StoreCaches).FullName);
			return (List<StoreInfo>)factory.GetData();
		}

		public Hashtable GetStoreDetails()
		{
			StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
			. = this;
			Hashtable hashtable;
			string value;
			if (!false)
			{
				hashtable = new Hashtable();
				if (!true)
				{
					return hashtable;
				}
				value = string.Empty;
			}
			string value2 = string.Empty;
			string arg_45_0 = string.Empty;
			. = new StoreInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (false)
			{
				goto IL_B1;
			}
			if (false)
			{
				goto IL_9E;
			}
			string dG_Store_Name = ..DG_Store_Name;
			if (dG_Store_Name != null)
			{
				if (false)
				{
					goto IL_B2;
				}
				value = dG_Store_Name;
			}
			IL_8B:
			string text = ..Country.ToString();
			IL_9E:
			if (text != null)
			{
				value2 = text;
			}
			int arg_B1_0 = ..DG_Store_pkey;
			IL_B1:
			IL_B2:
			hashtable.Add(StoreSubStoreDataBusniess.(4841), value);
			if (4 == 0)
			{
				goto IL_8B;
			}
			hashtable.Add(StoreSubStoreDataBusniess.(4850), value2);
			return hashtable;
		}

		public string GetSubstoreNameById(int SubstoreId)
		{
			StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
			do
			{
				. = SubstoreId;
			}
			while (7 == 0);
			. = this;
			. = new SubStoresInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (. != null)
			{
				return ..DG_SubStore_Name;
			}
			return StoreSubStoreDataBusniess.(1988);
		}

		public List<StoreInfo> GetStoreName()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<StoreInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public string GetQRCodeWebUrl()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = string.Empty;
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public List<SubStoresInfo> GetSubstoreData()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<SubStoresInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public List<SubStoresInfo> GetSubstoreDataFillGrid()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<SubStoresInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public List<SiteCodeDetail> GetSiteCodeBusiness()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<SiteCodeDetail>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public List<SubStoresInfo> GetLoginUserDefaultSubstores(int subStoreId)
		{
			StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
			. = subStoreId;
			. = this;
			. = new List<SubStoresInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public Dictionary<string, string> GetSubstoreDataDir(Dictionary<string, string> selectDict)
		{
			Dictionary<string, string> result;
			do
			{
				IEnumerable<KeyValuePair<string, string>> arg_9A_0 = selectDict.Concat(this.GetSubstoreDataDir());
				if (StoreSubStoreDataBusniess. == null)
				{
					StoreSubStoreDataBusniess. = new Func<KeyValuePair<string, string>, string>(StoreSubStoreDataBusniess.);
				}
				IEnumerable<IGrouping<string, KeyValuePair<string, string>>> arg_A1_0 = arg_9A_0.GroupBy(StoreSubStoreDataBusniess.);
				if (StoreSubStoreDataBusniess. == null)
				{
					StoreSubStoreDataBusniess. = new Func<IGrouping<string, KeyValuePair<string, string>>, string>(StoreSubStoreDataBusniess.);
				}
				Func<IGrouping<string, KeyValuePair<string, string>>, string> arg_A1_1 = StoreSubStoreDataBusniess.;
				if (StoreSubStoreDataBusniess. == null)
				{
					StoreSubStoreDataBusniess. = new Func<IGrouping<string, KeyValuePair<string, string>>, string>(StoreSubStoreDataBusniess.);
				}
				result = arg_A1_0.ToDictionary(arg_A1_1, StoreSubStoreDataBusniess.);
			}
			while (3 == 0);
			return result;
		}

		public Dictionary<string, string> GetSubstoreDataDir()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new Dictionary<string, string>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public List<string> GetBackupsubstorename(int SubStoreId)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			StoreSubStoreDataBusniess. ;
			if (3 != 0)
			{
				transactionMethod = null;
				StoreSubStoreDataBusniess. expr_95 = new StoreSubStoreDataBusniess.();
				if (!false)
				{
					 = expr_95;
				}
				. = SubStoreId;
				. = this;
			}
			. = null;
			List<string> result;
			try
			{
				new List<SubStoresInfo>();
				if (3 == 0)
				{
					goto IL_78;
				}
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				IL_63:
				if (. == null || 8 == 0 || 3 == 0)
				{
					result = null;
					return result;
				}
				result = .;
				IL_78:
				if (false)
				{
					goto IL_63;
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public List<LocationInfo> GetLocationSubstoreWise(int SubstoreId)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			if (4 != 0)
			{
				transactionMethod = null;
				if (4 == 0)
				{
					goto IL_31;
				}
			}
			. = this;
			IL_31:
			. = null;
			List<LocationInfo> result;
			try
			{
				if (7 != 0)
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.);
					}
					this.operation = transactionMethod;
				}
				base.Start(false);
				result = .;
			}
			catch (Exception)
			{
				do
				{
					result = .;
				}
				while (6 == 0 || 2 == 0);
			}
			return result;
		}

		public Dictionary<string, string> SelStoreDataDir()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new Dictionary<string, string>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public bool DeleteSubStoreLocations(int SubstoreID)
		{
			if (true)
			{
				StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
				do
				{
					. = SubstoreID;
				}
				while (false);
				if (6 == 0)
				{
					goto IL_3C;
				}
				. = this;
				this.operation = new BaseBusiness.TransactionMethod(.);
			}
			base.Start(false);
			IL_3B:
			IL_3C:
			int expr_3D = 1;
			if (expr_3D != 0)
			{
				return expr_3D != 0;
			}
			goto IL_3B;
		}

		public bool SetSubStoreLocationsDetails(int Substore_ID, int LocationId)
		{
			StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
			. = Substore_ID;
			bool result;
			if (!false)
			{
				. = LocationId;
				. = this;
				try
				{
					if (!false)
					{
					}
					. = ;
					. = false;
					if (6 != 0)
					{
						. = new SubStoreLocationInfo();
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
					}
					result = .;
				}
				catch (Exception)
				{
					result = false;
				}
			}
			return result;
		}

		public List<LocationInfo> GetAvailableLocationsSubstore(int SubstoreId)
		{
			StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
			. = SubstoreId;
			. = this;
			. = new List<LocationInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<LocationInfo> GetSelectedLocationsSubstore(int SubstoreId)
		{
			StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
			. = SubstoreId;
			. = this;
			. = new List<LocationInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool UpdateQRCodeWebUrl(string url)
		{
			do
			{
			}
			while (!true);
			. = this;
			bool result;
			try
			{
				StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
				if (false || false)
				{
					goto IL_61;
				}
				. = ;
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				IL_56:
				bool arg_85_0 = base.Start(false);
				if (false)
				{
					goto IL_85;
				}
				IL_61:
				ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(StoreCaches).FullName);
				if (false)
				{
					goto IL_56;
				}
				factory.RemoveFromCache();
				arg_85_0 = .;
				IL_85:
				result = arg_85_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public SubStoresInfo GetSubstoreData(int subStoreId)
		{
			StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
			. = subStoreId;
			. = this;
			. = new SubStoresInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public string DeleteSubstore(int SubStoreId)
		{
			StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
			. = SubStoreId;
			. = this;
			. = string.Empty;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool SetSubStoreDetails(string SubstoreName, string SubStoreDescription, int Substore_ID, string SyncCode, bool islogiaclsubstore, int? logicalsubstoreid, string SiteCode)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			BaseBusiness.TransactionMethod transactionMethod2 = null;
			StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
			do
			{
				. = this;
				. = new SubStoresInfo();
				..DG_SubStore_pkey = Substore_ID;
				..DG_SubStore_Name = SubstoreName;
			}
			while (false);
			..DG_SubStore_Description = SubStoreDescription;
			..DG_SubStore_IsActive = true;
			while (true)
			{
				..SyncCode = SyncCode;
				while (true)
				{
					..IsSynced = false;
					while (true)
					{
						..IsLogicalSubStore = islogiaclsubstore;
						..LogicalSubStoreID = logicalsubstoreid;
						..DG_SubStore_Code = SiteCode;
						if (Substore_ID > 0)
						{
							goto Block_2;
						}
						if (false)
						{
							break;
						}
						..DG_SubStore_pkey = Substore_ID;
						if (transactionMethod2 == null)
						{
							transactionMethod2 = new BaseBusiness.TransactionMethod(.);
						}
						this.operation = transactionMethod2;
						if (!false)
						{
							goto Block_7;
						}
					}
				}
				Block_2:
				if (false)
				{
					continue;
				}
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				IL_10A:
				if (!false)
				{
					break;
				}
				continue;
				Block_7:
				base.Start(false);
				if (3 != 0)
				{
				}
				goto IL_10A;
			}
			return true;
		}

		public List<SubStoresInfo> GetAllSubstoreName()
		{
			StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
			. = this;
			. = new List<SubStoresInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (. != null)
			{
				return .;
			}
			return null;
		}

		public List<SubStoresInfo> GetAllLogicalSubstoreName()
		{
			StoreSubStoreDataBusniess.  = new StoreSubStoreDataBusniess.();
			. = this;
			. = new List<SubStoresInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (. != null)
			{
				return .;
			}
			return null;
		}

		public string GetCountryName()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = string.Empty;
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public StoreInfo GetStore()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new StoreInfo();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public List<SubStoresInfo> GetLogicalSubStore()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<SubStoresInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public List<RfidInfo> GetRfidInfoBussines(int SubStoreId)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			if (4 != 0)
			{
				transactionMethod = null;
				if (4 == 0)
				{
					goto IL_31;
				}
			}
			. = this;
			IL_31:
			. = null;
			List<RfidInfo> result;
			try
			{
				if (7 != 0)
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.);
					}
					this.operation = transactionMethod;
				}
				base.Start(false);
				result = .;
			}
			catch
			{
				do
				{
					result = .;
				}
				while (6 == 0 || 2 == 0);
			}
			return result;
		}

		[CompilerGenerated]
		private static string (KeyValuePair<string, string> )
		{
			return .Key;
		}

		[CompilerGenerated]
		private static string (IGrouping<string, KeyValuePair<string, string>> )
		{
			return .Key;
		}

		[CompilerGenerated]
		private static string (IGrouping<string, KeyValuePair<string, string>> )
		{
			return .First<KeyValuePair<string, string>>().Value;
		}

		static StoreSubStoreDataBusniess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(StoreSubStoreDataBusniess));
		}
	}
}
