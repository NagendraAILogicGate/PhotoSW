using DigiPhoto.IMIX.DataAccess;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class PackageBusniess : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public PackageBusniess ;

			public int ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					PackageDetailsDao packageDetailsDao = new PackageDetailsDao(this..Transaction);
					this. = packageDetailsDao.GetChildProductTypeQuantity(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;

			public PackageBusniess ;

			public int ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					PackageDetailsDao packageDetailsDao = new PackageDetailsDao(this..Transaction);
					this. = packageDetailsDao.GetMaxQuantityofIteminaPackage(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public PackageBusniess ;

			public int ;

			public void ()
			{
				do
				{
					PackageDetailsDao packageDetailsDao;
					if (!false)
					{
						packageDetailsDao = new PackageDetailsDao(this..Transaction);
					}
					this. = packageDetailsDao.GetChildProductTypeById(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PackageBusniess ;

			public int ;

			public int ;

			public int? ;

			public int? ;

			public int? ;

			public void ()
			{
				PackageDetailsDao packageDetailsDao = new PackageDetailsDao(this..Transaction);
				packageDetailsDao.InsertPackageDetails(this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PackageBusniess ;

			public int ;

			public string ;

			public string ;

			public void ()
			{
				if (4 != 0)
				{
					PackageDetailsDao packageDetailsDao = new PackageDetailsDao(this..Transaction);
					packageDetailsDao.UpdAndDelPackageMasterDetails(this., this., this.);
				}
			}
		}

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public string GetChildProductTypeQuantity(int Child, int parentId)
		{
			PackageBusniess. ;
			do
			{
				 = new PackageBusniess.();
				if (4 != 0)
				{
					. = Child;
					. = parentId;
					. = this;
					. = string.Empty;
					if (!false)
					{
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
				}
			}
			while (false);
			base.Start(false);
			if (. != null)
			{
				return .;
			}
			return PackageBusniess.(2816);
		}

		public int GetMaxQuantityofIteminaPackage(int pkgId, int productTypeId)
		{
			PackageBusniess.  = new PackageBusniess.();
			if (!false)
			{
				. = pkgId;
				if (!false)
				{
					. = productTypeId;
				}
			}
			do
			{
				if (-1 != 0)
				{
					. = this;
				}
				if (8 == 0)
				{
					goto IL_4B;
				}
				. = 1;
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_4B:
			base.Start(false);
			return .;
		}

		public string GetChildProductType(int parentid)
		{
			PackageBusniess.  = new PackageBusniess.();
			. = parentid;
			. = this;
			. = string.Empty;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool SetPackageDetails(int packageId, int ProductTypeId, int? PackageQuantity, int? PackageMaxQuanity, int? VideoLength)
		{
			PackageBusniess.  = new PackageBusniess.();
			. = packageId;
			. = ProductTypeId;
			. = PackageQuantity;
			. = PackageMaxQuanity;
			. = VideoLength;
			. = this;
			if (7 != 0)
			{
				if (6 == 0)
				{
					goto IL_63;
				}
				this.operation = new BaseBusiness.TransactionMethod(.);
			}
			int arg_64_0 = base.Start(false) ? 1 : 0;
			if (false)
			{
				return arg_64_0 != 0;
			}
			IL_63:
			arg_64_0 = 1;
			return arg_64_0 != 0;
		}

		public bool SetPackageMasterDetails(int packageId, string packageName, string Packageprice)
		{
			PackageBusniess.  = new PackageBusniess.();
			IL_04:
			while (!false)
			{
				. = packageId;
				. = packageName;
				while (!false)
				{
					. = Packageprice;
					if (3 != 0)
					{
						. = this;
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (!false)
						{
							base.Start(false);
							break;
						}
						goto IL_04;
					}
				}
				IL_4C:
				break;
			}
			int expr_4E = 1;
			if (expr_4E != 0)
			{
				return expr_4E != 0;
			}
			goto IL_4C;
		}

		static PackageBusniess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(PackageBusniess));
		}
	}
}
