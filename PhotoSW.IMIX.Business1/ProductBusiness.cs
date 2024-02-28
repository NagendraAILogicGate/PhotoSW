using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using ErrorHandler;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class ProductBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public DataTable ;

			public ProductBusiness ;

			public int ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					ProductTypeDao productTypeDao = new ProductTypeDao(this..Transaction);
					productTypeDao.BulkSaveProduct(this., this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness. ;

			public List<ProductTypeInfo> ;

			public void ()
			{
				do
				{
					if (true)
					{
						ProductTypeDao productTypeDao = new ProductTypeDao(this...Transaction);
						if (7 == 0)
						{
							continue;
						}
						if (!false)
						{
							this. = productTypeDao.SelectProductType(new int?(0), null, this..);
						}
					}
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness. ;

			public ProductTypeInfo ;

			public void ()
			{
				if (4 != 0)
				{
					ProductTypeDao productTypeDao = new ProductTypeDao(this...Transaction);
					if (!false)
					{
						this. = productTypeDao.GetProductPricing(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness. ;

			public List<PackageDetailsViewInfo> ;

			public void ()
			{
				if (4 != 0)
				{
					PackageDetailsDao packageDetailsDao = new PackageDetailsDao(this...Transaction);
					if (!false)
					{
						this. = packageDetailsDao.GetPackagDetails(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ProductTypeInfo> ;

			public ProductBusiness ;

			public void ()
			{
				ProductTypeDao productTypeDao = new ProductTypeDao(this..Transaction);
				this. = productTypeDao.SelectProductType(new int?(0), new bool?(false), string.Empty);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ProductTypeInfo> ;

			public ProductBusiness ;

			public void ()
			{
				ProductTypeDao productTypeDao = new ProductTypeDao(this..Transaction);
				this. = productTypeDao.SelectProductType(new int?(0), new bool?(true), string.Empty);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ProductTypeInfo> ;

			public ProductBusiness ;

			public int ;

			public void ()
			{
				ProductTypeDao productTypeDao = new ProductTypeDao(this..Transaction);
				this. = productTypeDao.SelectProductType(new int?(this.), null, string.Empty);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness ;

			public bool ;

			public bool ;

			public bool ;

			public bool ;

			public bool ;

			public void ()
			{
				ProductTypeDao productTypeDao = new ProductTypeDao(this..Transaction);
				productTypeDao.UpdateBorderImages(this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ProductBusiness ;

			public DateTime ;

			public DateTime ;

			public string ;

			public string ;

			public int ;

			public void ()
			{
				ReportDao reportDao = new ReportDao(this..Transaction);
				this. = reportDao.SelectProductSummary(this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public BackGroundInfo ;

			public ProductBusiness ;

			public int ;

			public int ;

			public void ()
			{
				BackGroundDao backGroundDao = new BackGroundDao(this..Transaction);
				this. = backGroundDao.Get(new int?(this.), this., 0, string.Empty);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ProductTypeInfo> ;

			public ProductBusiness ;

			public int ;

			public void ()
			{
				ProductTypeDao productTypeDao = new ProductTypeDao(this..Transaction);
				this. = productTypeDao.SelectProductType(new int?(this.), null, string.Empty);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness ;

			public int ;

			public string ;

			public string ;

			public bool? ;

			public string ;

			public int ;

			public int ;

			public bool? ;

			public bool? ;

			public bool? ;

			public bool? ;

			public string ;

			public string ;

			public string ;

			public int? ;

			public bool? ;

			public int ;

			public void ()
			{
				ProductTypeDao productTypeDao = new ProductTypeDao(this..Transaction);
				productTypeDao.UpdAndInsProductTypeInfo(this., this., this., this., this., this., this., this., this., this., this., this., this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ProductTypeInfo> ;

			public ProductBusiness ;

			public bool? ;

			public void ()
			{
				do
				{
					ProductTypeDao productTypeDao;
					if (!false)
					{
						productTypeDao = new ProductTypeDao(this..Transaction);
					}
					this. = productTypeDao.SelProductTypeData(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductTypeInfo ;

			public ProductBusiness ;

			public int ;

			public void ()
			{
				do
				{
					ProductTypeDao productTypeDao;
					if (!false)
					{
						productTypeDao = new ProductTypeDao(this..Transaction);
					}
					this. = productTypeDao.GetProductTypeDataByKey(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness ;

			public bool ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness. ;

			public List<ProductTypeInfo> ;

			public void ()
			{
				if (4 != 0)
				{
					ProductTypeDao productTypeDao = new ProductTypeDao(this...Transaction);
					if (!false)
					{
						this. = productTypeDao.GetOrdersProductTypeByPackage(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					ProductTypeDao productTypeDao = new ProductTypeDao(this...Transaction);
					if (!false)
					{
						this. = productTypeDao.Delete(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ProductPriceInfo> ;

			public ProductBusiness ;

			public int ;

			public void ()
			{
				do
				{
					ProductTypeDao productTypeDao;
					if (!false)
					{
						productTypeDao = new ProductTypeDao(this..Transaction);
					}
					this. = productTypeDao.SelectProductPrice(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ProductTypeInfo> ;

			public ProductBusiness ;

			public int ;

			public void ()
			{
				do
				{
					ProductTypeDao productTypeDao;
					if (!false)
					{
						productTypeDao = new ProductTypeDao(this..Transaction);
					}
					this. = productTypeDao.GetProductTypeforOrder(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ProductTypeInfo> ;

			public ProductBusiness ;

			public string ;

			public void ()
			{
				ProductTypeDao productTypeDao = new ProductTypeDao(this..Transaction);
				this. = productTypeDao.SelectProductType(null, null, this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness ;

			public int? ;

			public double? ;

			public int? ;

			public int? ;

			public int? ;

			public bool? ;

			public void ()
			{
				while (true)
				{
					ProductTypeDao productTypeDao = new ProductTypeDao(this..Transaction);
					while (true)
					{
						productTypeDao.SetProductPricingData(this., this., this., this., this., this.);
						if (false)
						{
							break;
						}
						if (!false)
						{
							return;
						}
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<GroupInfo> ;

			public ProductBusiness ;

			public void ()
			{
				ProductTypeDao productTypeDao = new ProductTypeDao(this..Transaction);
				this. = productTypeDao.GetGroupList();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ProductBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					ProductTypeDao productTypeDao = new ProductTypeDao(this...Transaction);
					if (!false)
					{
						this. = productTypeDao.IsChkSpecOnlinePackage(this..);
					}
				}
			}
		}

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		private DataColumn (string , string , bool )
		{
			DataColumn dataColumn;
			if (4 != 0)
			{
				dataColumn = new DataColumn(ProductBusiness.(3687), Type.GetType(ProductBusiness.(3716)));
				dataColumn.AllowDBNull = true;
			}
			return dataColumn;
		}

		private DataTable ()
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(ProductBusiness.(3687), typeof(string));
			dataTable.Columns.Add(ProductBusiness.(3737), typeof(string));
			dataTable.Columns.Add(ProductBusiness.(3774), typeof(string));
			do
			{
				dataTable.Columns.Add(ProductBusiness.(3811), typeof(bool));
			}
			while (false);
			dataTable.Columns.Add(ProductBusiness.(3832), typeof(bool));
			dataTable.Columns.Add(ProductBusiness.(3849), typeof(bool));
			dataTable.Columns.Add(ProductBusiness.(3866), typeof(bool));
			dataTable.Columns.Add(ProductBusiness.(3919), typeof(int));
			dataTable.Columns.Add(ProductBusiness.(3940), typeof(string));
			dataTable.Columns.Add(ProductBusiness.(2365), typeof(string));
			dataTable.Columns.Add(ProductBusiness.(3977), typeof(int));
			dataTable.Columns.Add(ProductBusiness.(3990), typeof(string));
			dataTable.Columns.Add(ProductBusiness.(4015), typeof(double));
			return dataTable;
		}

		public bool BulkSaveProduct(DataTable productDataTable, int createdBy, int storeId)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			ProductBusiness.  = new ProductBusiness.();
			. = createdBy;
			. = storeId;
			. = this;
			. = new DataTable();
			..Columns.Add(ProductBusiness.(3687), typeof(string));
			..Columns.Add(ProductBusiness.(3737), typeof(string));
			..Columns.Add(ProductBusiness.(3774), typeof(string));
			..Columns.Add(ProductBusiness.(3811), typeof(bool));
			..Columns.Add(ProductBusiness.(3832), typeof(bool));
			..Columns.Add(ProductBusiness.(3849), typeof(bool));
			..Columns.Add(ProductBusiness.(3866), typeof(bool));
			..Columns.Add(ProductBusiness.(3919), typeof(int));
			..Columns.Add(ProductBusiness.(3940), typeof(string));
			..Columns.Add(ProductBusiness.(2365), typeof(string));
			..Columns.Add(ProductBusiness.(3977), typeof(int));
			..Columns.Add(ProductBusiness.(3990), typeof(string));
			..Columns.Add(ProductBusiness.(4015), typeof(double));
			bool result;
			try
			{
				if (productDataTable.Rows[0][3] is DBNull)
				{
					productDataTable.Rows.Remove(productDataTable.Rows[0]);
				}
				IEnumerator enumerator = productDataTable.Rows.GetEnumerator();
				try
				{
					while (enumerator.MoveNext())
					{
						DataRow dataRow = (DataRow)enumerator.Current;
						DataRow dataRow2 = ..NewRow();
						dataRow2[ProductBusiness.(3687)] = dataRow.ItemArray[1].ToString();
						dataRow2[ProductBusiness.(3737)] = dataRow.ItemArray[2].ToString();
						dataRow2[ProductBusiness.(3774)] = dataRow.ItemArray[2].ToString();
						dataRow2[ProductBusiness.(3811)] = Convert.ToBoolean(dataRow.ItemArray[4]);
						dataRow2[ProductBusiness.(3832)] = Convert.ToBoolean(dataRow.ItemArray[5]);
						dataRow2[ProductBusiness.(3849)] = Convert.ToBoolean(dataRow.ItemArray[6]);
						dataRow2[ProductBusiness.(3866)] = Convert.ToBoolean(dataRow.ItemArray[7]);
						dataRow2[ProductBusiness.(3919)] = 0;
						dataRow2[ProductBusiness.(3940)] = ProductBusiness.(4060);
						dataRow2[ProductBusiness.(2365)] = dataRow.ItemArray[8].ToString();
						dataRow2[ProductBusiness.(3977)] = false;
						dataRow2[ProductBusiness.(3990)] = dataRow.ItemArray[0].ToString();
						dataRow2[ProductBusiness.(4015)] = dataRow.ItemArray[3].ToDouble(false);
						..Rows.Add(dataRow2);
					}
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					if (6 == 0 || disposable != null)
					{
						disposable.Dispose();
					}
				}
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				result = true;
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogError(serviceException);
				result = false;
			}
			return result;
		}

		public int GetProductID(string ProductTypeName)
		{
			do
			{
			}
			while (false);
			int result;
			if (!false)
			{
				. = this;
				try
				{
					ProductBusiness. ;
					while (true)
					{
						if (6 != 0)
						{
							 = new ProductBusiness.();
							. = ;
							. = new List<ProductTypeInfo>();
							this.operation = new BaseBusiness.TransactionMethod(.);
						}
						base.Start(false);
						if (. != null && 4 != 0)
						{
							break;
						}
						result = 0;
						if (8 != 0)
						{
							goto Block_6;
						}
					}
					result = ..FirstOrDefault<ProductTypeInfo>().DG_Orders_ProductType_pkey;
					Block_6:;
				}
				catch (Exception)
				{
					result = 0;
				}
			}
			return result;
		}

		public double GetProductPricing(int ProductTypeID)
		{
			if (4 == 0)
			{
				goto IL_22;
			}
			IL_0D:
			double result;
			if (4 == 0)
			{
				return result;
			}
			int  = ProductTypeID;
			IL_22:
			if (6 == 0)
			{
				goto IL_0D;
			}
			ProductBusiness  = this;
			try
			{
				do
				{
				}
				while (7 == 0);
				. = new ProductTypeInfo();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				result = ..DG_Product_Pricing_ProductPrice;
			}
			catch (Exception)
			{
				do
				{
					result = -1.0;
				}
				while (2 == 0);
			}
			return result;
		}

		public List<PackageDetailsViewInfo> GetPackagDetails(int PackageId)
		{
			if (!false && -1 != 0)
			{
			}
			. = PackageId;
			. = this;
			List<PackageDetailsViewInfo> result;
			try
			{
				ProductBusiness.  = new ProductBusiness.();
				if (!false)
				{
					. = ;
				}
				. = new List<PackageDetailsViewInfo>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public List<ProductTypeInfo> GetProductType()
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
				. = new List<ProductTypeInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public List<ProductTypeInfo> GetPackageType()
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
				. = new List<ProductTypeInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public ProductTypeInfo GetProductType(int productId)
		{
			ProductBusiness. expr_4E = new ProductBusiness.();
			ProductBusiness. ;
			if (!false)
			{
				 = expr_4E;
			}
			. = productId;
			. = this;
			do
			{
				. = new List<ProductTypeInfo>();
				if (!false)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
			}
			while (-1 == 0);
			return ..FirstOrDefault<ProductTypeInfo>();
		}

		public bool SaveBorderFor4Images(bool chk4Large, bool chkUniq4, bool chk4small, bool chk3by3, bool chkUniq4SW)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			ProductBusiness.  = new ProductBusiness.();
			. = chk4Large;
			. = chkUniq4;
			. = chk4small;
			. = chk3by3;
			. = chkUniq4SW;
			. = this;
			bool result;
			try
			{
				new List<ProductTypeInfo>();
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				result = true;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public DataSet GetProductSummary(DateTime FromDate, DateTime ToDate, string StoreName, string UserName, int SubStorePKey)
		{
			if (!false)
			{
				if (-1 == 0)
				{
					goto IL_1F;
				}
			}
			if (6 == 0)
			{
				goto IL_60;
			}
			. = FromDate;
			IL_1F:
			. = ToDate;
			. = StoreName;
			. = UserName;
			. = SubStorePKey;
			do
			{
				. = this;
			}
			while (7 == 0);
			. = new DataSet();
			IL_60:
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool CheckIsVisibleProductForBackGround(int BGID, int ProductID)
		{
			ProductBusiness.  = new ProductBusiness.();
			. = BGID;
			. = ProductID;
			. = this;
			if (8 != 0)
			{
				if (false)
				{
					goto IL_6E;
				}
				. = new BackGroundInfo();
				if (!false)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
			}
			int arg_71_0 = base.Start(false) ? 1 : 0;
			if (!false)
			{
				if (. == null)
				{
					goto IL_6E;
				}
				arg_71_0 = 1;
			}
			int arg_6F_0;
			int expr_71 = arg_6F_0 = arg_71_0;
			if (expr_71 != 0)
			{
				return expr_71 != 0;
			}
			return arg_6F_0 != 0;
			IL_6E:
			arg_6F_0 = 0;
			return arg_6F_0 != 0;
		}

		public ProductTypeInfo GetProductByID(int productid)
		{
			ProductBusiness. expr_4E = new ProductBusiness.();
			ProductBusiness. ;
			if (!false)
			{
				 = expr_4E;
			}
			. = productid;
			. = this;
			do
			{
				. = new List<ProductTypeInfo>();
				if (!false)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
			}
			while (-1 == 0);
			return ..FirstOrDefault<ProductTypeInfo>();
		}

		public bool SetProductTypeInfo(int ProductTypeId, string ProductTypeName, string ProductTypeDesc, bool? IsDiscount, string ProductPrice, int stroreId, int UserId, bool? ispackage, bool? Isactive, bool? IsAccessory, bool? IsTaxIncluded, string Productcode, string SyncCode, string syncodeforPackage, int? IsInvisible, bool? IschkWaterMarked, int SubStoreID)
		{
			ProductBusiness.  = new ProductBusiness.();
			. = ProductTypeId;
			. = ProductTypeName;
			. = ProductTypeDesc;
			. = IsDiscount;
			. = ProductPrice;
			. = stroreId;
			. = UserId;
			. = ispackage;
			. = Isactive;
			. = IsAccessory;
			. = IsTaxIncluded;
			. = Productcode;
			. = SyncCode;
			. = syncodeforPackage;
			. = IsInvisible;
			. = IschkWaterMarked;
			. = SubStoreID;
			. = this;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return true;
		}

		public List<ProductTypeInfo> GetProductTypeList(bool? IsPackage)
		{
			ProductBusiness.  = new ProductBusiness.();
			. = IsPackage;
			. = this;
			. = new List<ProductTypeInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public ProductTypeInfo GetProductTypeListById(int ProductId)
		{
			ProductBusiness.  = new ProductBusiness.();
			. = ProductId;
			. = this;
			. = new ProductTypeInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<ProductTypeInfo> GetPackageNames(bool IsPackage)
		{
			if (!false && -1 != 0)
			{
			}
			. = IsPackage;
			. = this;
			List<ProductTypeInfo> result;
			try
			{
				ProductBusiness.  = new ProductBusiness.();
				if (!false)
				{
					. = ;
				}
				. = new List<ProductTypeInfo>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public bool DeleteProductType(int ProductTypeId)
		{
			if (!false && -1 != 0)
			{
			}
			. = ProductTypeId;
			. = this;
			bool result;
			try
			{
				ProductBusiness.  = new ProductBusiness.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public List<ProductPriceInfo> GetProductPricingStoreWise(int StoreId)
		{
			ProductBusiness.  = new ProductBusiness.();
			. = StoreId;
			. = this;
			. = new List<ProductPriceInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<ProductTypeInfo> GetProductTypeforOrder(int SubStoreID)
		{
			ProductBusiness.  = new ProductBusiness.();
			. = SubStoreID;
			. = this;
			. = new List<ProductTypeInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public int GetProductsynccodeName(string ProductTypeName)
		{
			ProductBusiness.  = new ProductBusiness.();
			. = ProductTypeName;
			do
			{
				. = this;
				. = new List<ProductTypeInfo>();
				if (8 != 0)
				{
					if (false)
					{
						goto IL_77;
					}
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				base.Start(false);
				if (. == null)
				{
					goto IL_77;
				}
			}
			while (false);
			int arg_76_0;
			int arg_78_0 = arg_76_0 = ..FirstOrDefault<ProductTypeInfo>().DG_Orders_ProductType_pkey;
			IL_73:
			if (!false)
			{
				return arg_76_0;
			}
			goto IL_78;
			IL_77:
			arg_78_0 = 0;
			IL_78:
			int expr_78 = arg_76_0 = (arg_78_0 = arg_78_0);
			if (expr_78 == 0)
			{
				return expr_78;
			}
			goto IL_73;
		}

		public bool SetProductPricingData(int? ProductTypeId, double? ProductPrice, int? CurrencyId, int? CreatedBy, int? storeId, bool? Isavailable)
		{
			ProductBusiness.  = new ProductBusiness.();
			. = ProductTypeId;
			. = ProductPrice;
			. = CurrencyId;
			. = CreatedBy;
			. = storeId;
			. = Isavailable;
			. = this;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return true;
		}

		public List<GroupInfo> GetGroupList()
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
				. = new List<GroupInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public bool IsChkSpecOnlinePackage(int PackageId)
		{
			if (!false && -1 != 0)
			{
			}
			. = PackageId;
			. = this;
			bool result;
			try
			{
				ProductBusiness.  = new ProductBusiness.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		static ProductBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ProductBusiness));
		}
	}
}
