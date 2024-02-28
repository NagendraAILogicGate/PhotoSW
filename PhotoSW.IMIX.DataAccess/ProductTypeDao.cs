//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class ProductTypeDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getProductType;
        public ProductTypeDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public ProductTypeDao()
		{
		}

		public List<ProductTypeInfo> SelectProductType(int? ProductTypeId, bool? IsPackage, string OrdersProductTypeName)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ProductTypeDao.getProductType(19611), base.SetNullIntegerValue(ProductTypeId));
			}
			base.AddParameter(ProductTypeDao.getProductType(24195), base.SetNullBoolValue(IsPackage));
			base.AddParameter(ProductTypeDao.getProductType(24216), base.SetNullStringValue(OrdersProductTypeName));
			IDataReader dataReader;
			do
			{
				dataReader = base.ExecuteReader("");
			}
			while (false || false);
			List<ProductTypeInfo> result = this.productTypeInfo(dataReader);
			dataReader.Close();
			return result;
		}

		private List<ProductTypeInfo> productTypeInfo ( IDataReader dataReader)
		{
			List<ProductTypeInfo> list = new List<ProductTypeInfo>();
			while (dataReader.Read())
			{
				ProductTypeInfo item = new ProductTypeInfo
				{
					DG_Orders_ProductType_pkey = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(2957), 0),
					DG_Orders_ProductType_Name = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(2819), string.Empty),
					DG_Orders_ProductType_Desc = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24261), string.Empty),
					DG_Orders_ProductType_IsBundled = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(17547), false)),
					DG_Orders_ProductType_DiscountApplied = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24298), false)),
					DG_Orders_ProductType_Image = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24351), string.Empty),
					DG_IsPackage = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(17592), false),
					DG_MaxQuantity = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24388), 0),
					DG_Orders_ProductType_Active = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24409), false)),
					DG_IsActive = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(2802), false)),
					DG_IsAccessory = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(19960), false)),
					DG_IsPrimary = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24450), false)),
					DG_Orders_ProductCode = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24467), string.Empty),
					DG_Orders_ProductNumber = new int?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24496), 0)),
					DG_IsBorder = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(17659), false)),
					SyncCode = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(1991), string.Empty),
					IsSynced = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(2004), false),
					DG_IsTaxEnabled = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24529), false)),
					DG_IsWaterMarkIncluded = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24546), false)),
					DG_SubStore_pkey = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24571), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public List<ProductTypeInfo> GetOrdersProductTypeByPackage(bool IsPackage)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ProductTypeDao.getProductType(24195), IsPackage);
			}
			IDataReader dataReader;
			List<ProductTypeInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.productTypeInfo2(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<ProductTypeInfo> productTypeInfo2 ( IDataReader dataReader)
		{
			List<ProductTypeInfo> list = new List<ProductTypeInfo>();
			while (dataReader.Read())
			{
				ProductTypeInfo productTypeInfo = new ProductTypeInfo();
				productTypeInfo.DG_Orders_ProductType_pkey = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(2957), 0);
				productTypeInfo.DG_Orders_ProductType_Name = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(2819), string.Empty);
				productTypeInfo.DG_Orders_ProductType_Desc = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24261), string.Empty);
				productTypeInfo.DG_Orders_ProductType_IsBundled = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(17547), false));
				productTypeInfo.DG_Orders_ProductType_DiscountApplied = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24298), false));
				productTypeInfo.DG_Orders_ProductType_Image = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24351), string.Empty);
				do
				{
					productTypeInfo.DG_IsPackage = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(17592), false);
					productTypeInfo.DG_MaxQuantity = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24388), 0);
					productTypeInfo.DG_Orders_ProductType_Active = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24409), false));
					productTypeInfo.DG_IsActive = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(2802), false));
					productTypeInfo.DG_IsAccessory = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(19960), false));
					productTypeInfo.DG_IsPrimary = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24450), false));
					productTypeInfo.DG_Orders_ProductCode = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24467), string.Empty);
					productTypeInfo.DG_Orders_ProductNumber = new int?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24496), 0));
					productTypeInfo.DG_IsBorder = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(17659), false));
					productTypeInfo.SyncCode = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(1991), string.Empty);
					productTypeInfo.IsSynced = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(2004), false);
				}
				while (2 == 0);
				productTypeInfo.DG_IsWaterMarkIncluded = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24546), false));
				ProductTypeInfo item = productTypeInfo;
				list.Add(item);
			}
			return list;
		}

		public ProductTypeInfo GetProductPricing(int ProductPricingProductType)
		{
			base.DBParameters.Clear();
			base.AddParameter(ProductTypeDao.getProductType(24596), ProductPricingProductType);
			IDataReader dataReader;
			if (true && !false)
			{
				dataReader = base.ExecuteReader("");
			}
			List<ProductTypeInfo> source;
			do
			{
				source = this.productTypeInfo3(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<ProductTypeInfo>();
		}

		private List<ProductTypeInfo> productTypeInfo3 ( IDataReader dataReader)
		{
			List<ProductTypeInfo> list;
			while (true)
			{
				if (!false)
				{
					List<ProductTypeInfo> expr_50 = new List<ProductTypeInfo>();
					if (!false)
					{
						list = expr_50;
					}
				}
				while (true)
				{
					if (dataReader.Read() && -1 != 0)
					{
						ProductTypeInfo item = new ProductTypeInfo
						{
							DG_Product_Pricing_ProductPrice = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(22726), 0.0)
						};
						if (5 == 0)
						{
							break;
						}
						list.Add(item);
					}
					else
					{
						if (!true)
						{
							break;
						}
						if (!false)
						{
							return list;
						}
					}
				}
			}
			return list;
		}

		public ProductTypeInfo GetProductTypeDataByKey(int ProductTypekey)
		{
			base.DBParameters.Clear();
			base.AddParameter(ProductTypeDao.getProductType(24641), ProductTypekey);
			IDataReader dataReader;
			if (true && !false)
			{
				dataReader = base.ExecuteReader("");
			}
			List<ProductTypeInfo> source;
			do
			{
				source = this.productTypeInfo4(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<ProductTypeInfo>();
		}

		private List<ProductTypeInfo> productTypeInfo4 ( IDataReader dataReader)
		{
			List<ProductTypeInfo> expr_242 = new List<ProductTypeInfo>();
			List<ProductTypeInfo> list;
			if (true)
			{
				list = expr_242;
			}
			while (dataReader.Read())
			{
				ProductTypeInfo item = new ProductTypeInfo
				{
					DG_Orders_ProductType_pkey = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(2957), 0),
					DG_Orders_ProductType_Name = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(2819), string.Empty),
					DG_Orders_ProductType_Desc = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24261), string.Empty),
					DG_Orders_ProductType_IsBundled = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(17547), false)),
					DG_Orders_ProductType_DiscountApplied = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24298), false)),
					DG_IsPackage = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(17592), false),
					DG_MaxQuantity = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24388), 0),
					DG_IsActive = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(2802), false)),
					DG_IsAccessory = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(19960), false)),
					DG_IsTaxEnabled = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24529), false)),
					DG_Orders_ProductCode = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24467), string.Empty),
					DG_Orders_ProductNumber = base.GetFieldValueIntNull(dataReader, ProductTypeDao.getProductType(24496), 0),
					DG_Product_Pricing_ProductPrice = Math.Round((double)base.GetFieldValue(dataReader, ProductTypeDao.getProductType(22726), 0f), 2),
					DG_Product_Pricing_Currency_ID = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24670), 0),
					DG_IsWaterMarkIncluded = new bool?(base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24546), false)),
					DG_SubStore_pkey = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(24571), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public void UpdateBorderImages(bool chk4Large, bool chkUniq4, bool chk4small, bool chk3by3, bool chkUniq4SW)
		{
			if (false)
			{
				goto IL_60;
			}
			List<SqlParameter> expr_D2 = base.DBParameters;
			if (!false)
			{
				expr_D2.Clear();
			}
			IL_14:
			if (5 == 0)
			{
				return;
			}
			string expr_EC = ProductTypeDao.getProductType(24711);
			object expr_33 = chk4Large;
			if (!false)
			{
				base.AddParameter(expr_EC, expr_33);
			}
			IL_41:
			base.AddParameter(ProductTypeDao.getProductType(24732), chkUniq4);
			IL_60:
			if (false)
			{
				goto IL_14;
			}
			base.AddParameter(ProductTypeDao.getProductType(24753), chk4small);
			do
			{
				base.AddParameter(ProductTypeDao.getProductType(24774), chk3by3);
			}
			while (false);
			base.AddParameter(ProductTypeDao.getProductType(24795), chkUniq4SW);
			if (false)
			{
				goto IL_41;
			}
			base.ExecuteNonQuery("");
		}

		public bool UpdAndInsProductTypeInfo(int ProductTypeId, int StoreId, int UserId, int? IsInvisible, bool? IsDiscount, bool? IsPackage, bool? IsActive, bool? IsAccessory, bool? IsTaxIncluded, string ProductTypeName, string ProductTypeDesc, string ProductPrice, string Productcode, string SyncCode, string SyncodeforPackage, bool? IschkWaterMarked, int SubStoreID)
		{
			base.DBParameters.Clear();
			base.AddParameter(ProductTypeDao.getProductType(19611), ProductTypeId);
			base.AddParameter(ProductTypeDao.getProductType(24820), StoreId);
			base.AddParameter(ProductTypeDao.getProductType(3517), UserId);
			do
			{
				base.AddParameter(ProductTypeDao.getProductType(24841), IsInvisible);
				base.AddParameter(ProductTypeDao.getProductType(24866), base.SetNullBoolValue(IsDiscount));
				base.AddParameter(ProductTypeDao.getProductType(24195), base.SetNullBoolValue(IsPackage));
			}
			while (8 == 0);
			base.AddParameter(ProductTypeDao.getProductType(1200), base.SetNullBoolValue(IsActive));
			base.AddParameter(ProductTypeDao.getProductType(24891), base.SetNullBoolValue(IsAccessory));
			base.AddParameter(ProductTypeDao.getProductType(24916), base.SetNullBoolValue(IsTaxIncluded));
			base.AddParameter(ProductTypeDao.getProductType(24941), ProductTypeName);
			base.AddParameter(ProductTypeDao.getProductType(24970), ProductTypeDesc);
			base.AddParameter(ProductTypeDao.getProductType(24999), ProductPrice);
			base.AddParameter(ProductTypeDao.getProductType(25024), Productcode);
			base.AddParameter(ProductTypeDao.getProductType(399), SyncCode);
			base.AddParameter(ProductTypeDao.getProductType(25049), SyncodeforPackage);
			base.AddParameter(ProductTypeDao.getProductType(22812), base.SetNullBoolValue(IschkWaterMarked));
			base.AddParameter(ProductTypeDao.getProductType(25082), SubStoreID);
			base.ExecuteReader("");
			return true;
		}

		public List<ProductTypeInfo> SelProductTypeData(bool? IsPackage)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ProductTypeDao.getProductType(24195), IsPackage);
			}
			IDataReader dataReader;
			List<ProductTypeInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.ProductTypeInfoEc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<ProductTypeInfo> ProductTypeInfoEc ( IDataReader IDataReader )
		{
			List<ProductTypeInfo> list = new List<ProductTypeInfo>();
			while (IDataReader.Read())
			{
				ProductTypeInfo productTypeInfo;
				if (!false)
				{
					productTypeInfo = new ProductTypeInfo();
					productTypeInfo.DG_Orders_ProductType_pkey = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(2957), 0);
					productTypeInfo.DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(2819), string.Empty);
					productTypeInfo.DG_Orders_ProductType_Desc = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24261), string.Empty);
					productTypeInfo.DG_Orders_ProductType_IsBundled = new bool?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(17547), false));
					productTypeInfo.DG_Orders_ProductType_DiscountApplied = new bool?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24298), false));
					productTypeInfo.DG_IsPackage = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(17592), false);
					productTypeInfo.DG_MaxQuantity = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24388), 0);
					goto IL_108;
				}
				IL_1D4:
				productTypeInfo.DG_IsWaterMarkIncluded = new bool?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24546), false));
				ProductTypeInfo item;
				do
				{
					item = productTypeInfo;
					if (5 == 0)
					{
						goto IL_108;
					}
				}
				while (5 == 0);
				list.Add(item);
				continue;
				IL_108:
				if (!false)
				{
					productTypeInfo.DG_IsActive = new bool?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(2802), false));
					productTypeInfo.DG_IsAccessory = new bool?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(19960), false));
				}
				productTypeInfo.DG_Orders_ProductCode = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24467), string.Empty);
				productTypeInfo.DG_Orders_ProductNumber = new int?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24496), 0));
				productTypeInfo.DG_Product_Pricing_ProductPrice = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(22726), 0.0);
				productTypeInfo.DG_Product_Pricing_Currency_ID = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24670), 0);
				goto IL_1D4;
			}
			return list;
		}

		public void BulkSaveProduct(DataTable productTable, int createdBy, int storeId)
		{
			while (true)
			{
				base.DBParameters.Clear();
				base.AddParameter(ProductTypeDao.getProductType(25099), productTable);
				while (!false)
				{
					base.AddParameter(ProductTypeDao.getProductType(2214), createdBy);
					if (false)
					{
						return;
					}
					if (3 != 0)
					{
						base.AddParameter(ProductTypeDao.getProductType(25132), storeId);
						if (!false)
						{
							goto Block_3;
						}
						break;
					}
				}
			}
			Block_3:
			base.ExecuteNonQuery("");
		}

		public bool Delete(int objectvalueId)
		{
			base.DBParameters.Clear();
			base.AddParameter(ProductTypeDao.getProductType(19611), objectvalueId);
			base.ExecuteNonQuery("");
			return true;
		}

		public List<ProductPriceInfo> SelectProductPrice(int StoreId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ProductTypeDao.getProductType(25153), StoreId);
			}
			IDataReader dataReader;
			List<ProductPriceInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.ProductPriceInfoFc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<ProductPriceInfo> ProductPriceInfoFc ( IDataReader IDataReader)
		{
			List<ProductPriceInfo> list = new List<ProductPriceInfo>();
			if (8 != 0)
			{
				goto IL_14E;
			}
			IL_101:
			ProductPriceInfo productPriceInfo;
			productPriceInfo.DG_Product_Pricing_StoreId = new int?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(25354), 0));
			productPriceInfo.DG_Product_Pricing_IsAvaliable = new bool?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(25391), false));
			ProductPriceInfo item = productPriceInfo;
			list.Add(item);
			IL_14E:
			if (!IDataReader.Read())
			{
				return list;
			}
			productPriceInfo = new ProductPriceInfo();
			productPriceInfo.DG_Product_Pricing_Pkey = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(25198), 0);
			productPriceInfo.DG_Product_Pricing_ProductType = new int?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(25231), 0));
			productPriceInfo.DG_Product_Pricing_ProductPrice = new double?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(22726), 0.0));
			productPriceInfo.DG_Product_Pricing_Currency_ID = new int?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24670), 0));
			if (6 != 0)
			{
				productPriceInfo.DG_Product_Pricing_UpdateDate = new DateTime?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(25272), DateTime.MinValue));
				productPriceInfo.DG_Product_Pricing_CreatedBy = new int?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(25313), 0));
				goto IL_101;
			}
			goto IL_101;
		}

		public List<ProductTypeInfo> GetProductTypeforOrder(int SubStoreID)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ProductTypeDao.getProductType(25432), SubStoreID);
			}
			IDataReader dataReader;
			List<ProductTypeInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.ProductTypeInfoGc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<ProductTypeInfo> ProductTypeInfoGc ( IDataReader IDataReader)
		{
			List<ProductTypeInfo> list = new List<ProductTypeInfo>();
			while (IDataReader.Read())
			{
				ProductTypeInfo item = new ProductTypeInfo
				{
					DG_Orders_ProductType_pkey = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(2957), 0),
					DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(2819), string.Empty),
					DG_Orders_ProductType_Desc = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24261), string.Empty),
					DG_Orders_ProductType_IsBundled = new bool?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(17547), false)),
					DG_Orders_ProductType_DiscountApplied = new bool?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24298), false)),
					DG_Orders_ProductType_Image = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24351), string.Empty),
					DG_IsPackage = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(17592), false),
					DG_MaxQuantity = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24388), 0),
					DG_Orders_ProductType_Active = new bool?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24409), false)),
					DG_IsActive = new bool?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(2802), false)),
					DG_IsAccessory = new bool?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(19960), false)),
					Itemcount = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(25445), 0),
					DG_Orders_ProductNumber = base.GetFieldValueIntNull(IDataReader, ProductTypeDao.getProductType(24496), 0),
					IsPrintType = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(25458), 0),
					DG_IsWaterMarkIncluded = new bool?(base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24546), false)),
					DG_SubStore_pkey = base.GetFieldValue(IDataReader, ProductTypeDao.getProductType(24571), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public bool SetProductPricingData(int? ProductTypeId, double? ProductPrice, int? CurrencyId, int? CreatedBy, int? storeId, bool? Isavailable)
		{
			base.DBParameters.Clear();
			base.AddParameter(ProductTypeDao.getProductType(19611), base.SetNullIntegerValue(ProductTypeId));
			base.AddParameter(ProductTypeDao.getProductType(24999), base.SetNullDoubleValue(ProductPrice));
			base.AddParameter(ProductTypeDao.getProductType(13006), base.SetNullIntegerValue(CurrencyId));
			base.AddParameter(ProductTypeDao.getProductType(2214), base.SetNullIntegerValue(CreatedBy));
			base.AddParameter(ProductTypeDao.getProductType(24820), base.SetNullIntegerValue(storeId));
			base.AddParameter(ProductTypeDao.getProductType(25475), base.SetNullBoolValue(Isavailable));
			base.ExecuteReader("");
			return true;
		}

		public List<GroupInfo> GetGroupList()
		{
			if (!true)
			{
				goto IL_81;
			}
			if (6 == 0 || false)
			{
				goto IL_7F;
			}
			base.DBParameters.Clear();
			IL_18:
			IDataReader dataReader;
			List<GroupInfo> list;
			if (7 != 0)
			{
				dataReader = base.ExecuteReader("");
				list = new List<GroupInfo>();
			}
			goto IL_8B;
			IL_7F:
			GroupInfo groupInfo;
			GroupInfo item = groupInfo;
			IL_81:
			if (6 == 0)
			{
				goto IL_18;
			}
			list.Add(item);
			IL_8B:
			if (!dataReader.Read())
			{
				return list;
			}
			groupInfo = new GroupInfo();
			groupInfo.GroupID = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(25500), 0);
			groupInfo.GroupName = base.GetFieldValue(dataReader, ProductTypeDao.getProductType(25521), string.Empty);
			goto IL_7F;
		}

		public bool IsChkSpecOnlinePackage(int PackageID)
		{
			bool flag;
			if (!false && -1 != 0)
			{
				flag = false;
			}
			if (6 != 0)
			{
				base.DBParameters.Clear();
				base.AddParameter(ProductTypeDao.getProductType(15170), flag, ParameterDirection.Output);
				base.AddParameter(ProductTypeDao.getProductType(19590), base.SetNullIntegerValue(new int?(PackageID)));
				base.ExecuteNonQuery("");
			}
			return (bool)base.GetOutParameterValue(ProductTypeDao.getProductType(15170));
		}

		static ProductTypeDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ProductTypeDao));
		}
	}
}
