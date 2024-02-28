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
	public class PackageDetailsDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal new static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getPackageDetails;
        public PackageDetailsDao(BaseDataAccess baseaccess) : base(baseaccess)
		{

		}

		public PackageDetailsDao()
		{
		}

		public string GetChildProductTypeQuantity(int PackageId, int ProductTypeId)
		{
			List<SqlParameter> expr_8D = base.DBParameters;
			if (!false)
			{
				expr_8D.Clear();
			}
			base.AddParameter(PackageDetailsDao.getPackageDetails(7916), PackageId);
			List<PackageDetailsInfo> source;
			do
			{
				base.AddParameter(PackageDetailsDao.getPackageDetails(19607), ProductTypeId);
				do
				{
					IDataReader dataReader = base.ExecuteReader("");
					source = this.packageDetailsInfo(dataReader);
					dataReader.Close();
				}
				while (false);
			}
			while (false);
			return source.FirstOrDefault<PackageDetailsInfo>().DG_Product_Quantity.ToString();
		}

		private List<PackageDetailsInfo> packageDetailsInfo ( IDataReader dataReader)
		{
			List<PackageDetailsInfo> list = new List<PackageDetailsInfo>();
			while (true)
			{
				while (dataReader.Read())
				{
					PackageDetailsInfo packageDetailsInfo = new PackageDetailsInfo();
					if (true)
					{
						packageDetailsInfo.DG_ProductTypeId = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19636), 0);
						packageDetailsInfo.DG_PackageId = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19661), 0);
						packageDetailsInfo.DG_Product_Quantity = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19678), 0);
						PackageDetailsInfo item = packageDetailsInfo;
						list.Add(item);
					}
				}
				break;
			}
			return list;
		}

		public int GetMaxQuantityofIteminaPackage(int PackageId, int ProductTypeId)
		{
			base.DBParameters.Clear();
			base.AddParameter(PackageDetailsDao.getPackageDetails(7916), PackageId);
			base.AddParameter(PackageDetailsDao.getPackageDetails(19607), ProductTypeId);
			IDataReader dataReader = base.ExecuteReader("");
			List<PackageDetailsInfo> source = this.packageDetailsInfo2(dataReader);
			dataReader.Close();
			return source.FirstOrDefault<PackageDetailsInfo>().DG_Product_MaxImage;
		}

		private List<PackageDetailsInfo> packageDetailsInfo2 ( IDataReader dataReader )
		{
			List<PackageDetailsInfo> list = new List<PackageDetailsInfo>();
			while (dataReader.Read())
			{
				PackageDetailsInfo item = new PackageDetailsInfo
				{
					DG_Package_Details_Pkey = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19707), 0),
					DG_ProductTypeId = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19636), 0),
					DG_PackageId = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19661), 0),
					DG_Product_Quantity = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19678), 0),
					DG_Product_MaxImage = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19740), 0),
					SyncCode = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(1987), string.Empty),
					IsSynced = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(2000), false)
				};
				list.Add(item);
			}
			return list;
		}

		public string GetChildProductTypeById(int Parentid)
		{
			base.DBParameters.Clear();
			base.AddParameter(PackageDetailsDao.getPackageDetails(19769), Parentid);
			List<PackageDetailsInfo> source;
			do
			{
				IDataReader dataReader = base.ExecuteReader("");
				source = this.packageDetailsInfo3(dataReader);
				dataReader.Close();
			}
			while (-1 == 0);
			return source.FirstOrDefault<PackageDetailsInfo>().DG_ProductTypeIdComa;
		}

		private List<PackageDetailsInfo> packageDetailsInfo3 ( IDataReader dataReader)
		{
			List<PackageDetailsInfo> list;
			while (true)
			{
				if (!false)
				{
					List<PackageDetailsInfo> expr_4C = new List<PackageDetailsInfo>();
					if (!false)
					{
						list = expr_4C;
					}
				}
				while (true)
				{
					if (dataReader.Read() && -1 != 0)
					{
						PackageDetailsInfo item = new PackageDetailsInfo
						{
							DG_ProductTypeIdComa = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19636), string.Empty)
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

		public void InsertPackageDetails(int packageId, int ProductTypeId, int? PackageQuantity, int? PackageMaxQuanity, int? VideoLength)
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
			string expr_EC = PackageDetailsDao.getPackageDetails(19790);
			object expr_33 = packageId;
			if (!false)
			{
				base.AddParameter(expr_EC, expr_33);
			}
			IL_41:
			base.AddParameter(PackageDetailsDao.getPackageDetails(19607), ProductTypeId);
			IL_60:
			if (false)
			{
				goto IL_14;
			}
			base.AddParameter(PackageDetailsDao.getPackageDetails(19811), PackageQuantity);
			do
			{
				base.AddParameter(PackageDetailsDao.getPackageDetails(19840), PackageMaxQuanity);
			}
			while (false);
			base.AddParameter(PackageDetailsDao.getPackageDetails(19873), VideoLength);
			if (false)
			{
				goto IL_41;
			}
			base.ExecuteNonQuery("");
		}

		public void UpdAndDelPackageMasterDetails(int PackageId, string PackageName, string Packageprice)
		{
			do
			{
				base.DBParameters.Clear();
				base.AddParameter(PackageDetailsDao.getPackageDetails(7916), PackageId);
			}
			while (false);
			base.AddParameter(PackageDetailsDao.getPackageDetails(19906), PackageName);
			do
			{
				base.AddParameter(PackageDetailsDao.getPackageDetails(19931), Packageprice);
			}
			while (2 == 0);
			base.ExecuteNonQuery("");
		}

		public List<PackageDetailsViewInfo> GetPackagDetails(int PackageId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(PackageDetailsDao.getPackageDetails(19790), PackageId);
			}
			IDataReader dataReader;
			List<PackageDetailsViewInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.packageDetailsViewInfo(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<PackageDetailsViewInfo> packageDetailsViewInfo ( IDataReader dataReader)
		{
			List<PackageDetailsViewInfo> list = new List<PackageDetailsViewInfo>();
			while (dataReader.Read())
			{
				PackageDetailsViewInfo expr_195 = new PackageDetailsViewInfo();
				PackageDetailsViewInfo packageDetailsViewInfo;
				if (true)
				{
					packageDetailsViewInfo = expr_195;
				}
				packageDetailsViewInfo.DG_Package_Details_Pkey = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19707), 0);
				packageDetailsViewInfo.DG_ProductTypeId = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19636), 0);
				packageDetailsViewInfo.DG_PackageId = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19661), 0);
				packageDetailsViewInfo.DG_Product_Quantity = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19678), 0);
				packageDetailsViewInfo.DG_Orders_ProductType_pkey = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(2953), 0);
				packageDetailsViewInfo.DG_Orders_ProductType_Name = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(2815), string.Empty);
				packageDetailsViewInfo.DG_Product_MaxImage = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19740), 0);
				packageDetailsViewInfo.DG_Orders_ProductType_IsBundled = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(17543), false);
				packageDetailsViewInfo.DG_IsAccessory = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19956), false);
				packageDetailsViewInfo.DG_IsActive = base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(2798), false);
				packageDetailsViewInfo.DG_Video_Length = new int?(base.GetFieldValue(dataReader, PackageDetailsDao.getPackageDetails(19977), 0));
				PackageDetailsViewInfo item = packageDetailsViewInfo;
				list.Add(item);
			}
			return list;
		}

		static PackageDetailsDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(PackageDetailsDao));
		}
	}
}
