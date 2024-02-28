using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class LocationBusniess : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public LocationBusniess ;

			public int ;

			public void ()
			{
				do
				{
					LocationDao locationDao;
					if (!false)
					{
						locationDao = new LocationDao(this..Transaction);
					}
					this. = locationDao.Delete(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;

			public UsersInfo ;

			public LocationBusniess ;

			public void ()
			{
				do
				{
					UsersDao usersDao;
					if (!false)
					{
						usersDao = new UsersDao(this..Transaction);
					}
					this. = usersDao.GetLocationIdbyUserId(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public LocationBusniess ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public LocationBusniess. ;

			public SubStoreLocationInfo ;

			public void ()
			{
				if (4 != 0)
				{
					LocationDao locationDao = new LocationDao(this...Transaction);
					if (!false)
					{
						this. = locationDao.SelectSubStoreLocationsByLocationId(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public StoreInfo ;

			public LocationBusniess ;

			public void ()
			{
				StoreDao storeDao = new StoreDao(this..Transaction);
				this. = storeDao.GETQRCodeWebUrl();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<LocationInfo> ;

			public LocationBusniess ;

			public int ;

			public void ()
			{
				do
				{
					LocationDao locationDao;
					if (!false)
					{
						locationDao = new LocationDao(this..Transaction);
					}
					this. = locationDao.GetLocationStoreWise(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public Dictionary<string, string> ;

			public LocationBusniess ;

			public int ;

			public void ()
			{
				do
				{
					LocationDao locationDao;
					if (!false)
					{
						locationDao = new LocationDao(this..Transaction);
					}
					this. = locationDao.GetLocationStoreWiseDir(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<SubStoresInfo> ;

			public LocationBusniess ;

			public void ()
			{
				SubStoreDao subStoreDao = new SubStoreDao(this..Transaction);
				this. = subStoreDao.GetSubstoreData();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<LocationInfo> ;

			public LocationBusniess ;

			public int ;

			public void ()
			{
				LocationDao expr_2D = new LocationDao(this..Transaction);
				LocationDao locationDao;
				if (!false)
				{
					locationDao = expr_2D;
				}
				this. = locationDao.GetLocationList(this., true);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public LocationInfo ;

			public LocationBusniess ;

			public int ;

			public void ()
			{
				LocationDao expr_2E = new LocationDao(this..Transaction);
				LocationDao locationDao;
				if (!false)
				{
					locationDao = expr_2E;
				}
				this. = locationDao.Get(new int?(this.));
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public LocationInfo ;

			public int ;

			public LocationBusniess ;

			public void ()
			{
				do
				{
					LocationDao locationDao;
					if (!false)
					{
						locationDao = new LocationDao(this..Transaction);
					}
					this. = locationDao.Add(this.);
				}
				while (false);
			}

			public void ()
			{
				do
				{
					LocationDao locationDao;
					if (!false)
					{
						locationDao = new LocationDao(this..Transaction);
					}
					this. = locationDao.Update(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<LocationInfo> ;

			public LocationBusniess ;

			public int ;

			public void ()
			{
				LocationDao expr_2D = new LocationDao(this..Transaction);
				LocationDao locationDao;
				if (!false)
				{
					locationDao = expr_2D;
				}
				this. = locationDao.GetLocationList(this., true);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public LocationBusniess ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public LocationBusniess. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					LocationDao locationDao = new LocationDao(this...Transaction);
					if (!false)
					{
						this. = locationDao.IsLocationAssociatedToSite(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public LocationBusniess ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public LocationBusniess. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					LocationDao locationDao = new LocationDao(this...Transaction);
					if (!false)
					{
						this. = locationDao.IsSiteAssociatedToLocation(this..);
					}
				}
			}
		}

		public bool DeleteLocations(int LocationId)
		{
			LocationBusniess.  = new LocationBusniess.();
			. = LocationId;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public int GetLocationIdbyUserId(string UserId)
		{
			int result;
			try
			{
				LocationBusniess.  = new LocationBusniess.();
				. = this;
				. = UserId.ToInt32(false);
				. = new UsersInfo();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				result = ..DG_Location_ID;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		public int GetSubStoreIdbyLocationId(int LocationId)
		{
			if (3 != 0)
			{
			}
			. = LocationId;
			. = this;
			int result;
			try
			{
				LocationBusniess.  = new LocationBusniess.();
				. = ;
				if (false)
				{
					goto IL_68;
				}
				. = new SubStoreLocationInfo();
				IL_42:
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				result = ..DG_SubStore_ID;
				IL_68:
				if (false)
				{
					goto IL_42;
				}
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		public string GetQRCodeWebUrl()
		{
			string dG_QRCodeWebUrl;
			try
			{
				if (!false)
				{
					LocationBusniess.  = new LocationBusniess.();
					while (true)
					{
						. = this;
						if (8 == 0)
						{
							goto IL_33;
						}
						if (!false)
						{
							. = new StoreInfo();
							this.operation = new BaseBusiness.TransactionMethod(.);
							goto IL_33;
						}
						IL_3C:
						if (!false)
						{
							break;
						}
						continue;
						IL_33:
						base.Start(false);
						goto IL_3C;
					}
					dG_QRCodeWebUrl = ..DG_QRCodeWebUrl;
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			return dG_QRCodeWebUrl;
		}

		public List<LocationInfo> GetLocationName(int StoreId)
		{
			LocationBusniess.  = new LocationBusniess.();
			. = StoreId;
			. = this;
			. = new List<LocationInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public Dictionary<string, string> GetLocationNameDir(int StoreId)
		{
			LocationBusniess.  = new LocationBusniess.();
			. = StoreId;
			. = this;
			. = new Dictionary<string, string>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
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
					. = this;
				}
				while (false);
				. = new List<SubStoresInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public List<LocationInfo> GetLocationList(int storeId)
		{
			LocationBusniess.  = new LocationBusniess.();
			. = storeId;
			. = this;
			. = new List<LocationInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public LocationInfo GetLocationsbyId(int LocationId)
		{
			LocationBusniess.  = new LocationBusniess.();
			. = LocationId;
			. = this;
			. = new LocationInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool SetLocations(int LocationId, string LocationName, int StoreId, string SyncCode)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			BaseBusiness.TransactionMethod expr_06 = null;
			BaseBusiness.TransactionMethod transactionMethod2;
			if (3 != 0)
			{
				transactionMethod2 = expr_06;
			}
			while (true)
			{
				LocationBusniess.  = new LocationBusniess.();
				. = this;
				. = new LocationInfo();
				..DG_Location_pkey = LocationId;
				while (true)
				{
					..DG_Location_Name = LocationName;
					..DG_Store_ID = StoreId;
					..DG_Location_IsActive = true;
					..SyncCode = SyncCode;
					..IsSynced = false;
					. = 0;
					while (true)
					{
						if (LocationId <= 0)
						{
							if (transactionMethod == null)
							{
								transactionMethod = new BaseBusiness.TransactionMethod(.);
							}
							this.operation = transactionMethod;
							base.Start(false);
						}
						else
						{
							..DG_Location_pkey = LocationId;
							..DG_Location_Name = LocationName;
							..IsSynced = false;
							if (2 == 0)
							{
								break;
							}
							if (transactionMethod2 == null)
							{
								transactionMethod2 = new BaseBusiness.TransactionMethod(.);
							}
							this.operation = transactionMethod2;
							base.Start(false);
						}
						if (. > 0)
						{
							return true;
						}
						if (!false)
						{
							goto Block_6;
						}
					}
				}
				Block_6:
				if (8 != 0)
				{
					return false;
				}
			}
			return true;
		}

		public List<LocationInfo> GetLocations(int storeId)
		{
			LocationBusniess.  = new LocationBusniess.();
			. = storeId;
			. = this;
			. = new List<LocationInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool IsLocationAssociatedToSite(int _locationId)
		{
			if (!false && -1 != 0)
			{
			}
			. = _locationId;
			. = this;
			bool result;
			try
			{
				LocationBusniess.  = new LocationBusniess.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool IsSiteAssociatedToLocation(int subStoreId)
		{
			if (!false && -1 != 0)
			{
			}
			. = subStoreId;
			. = this;
			bool result;
			try
			{
				LocationBusniess.  = new LocationBusniess.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}
	}
}
