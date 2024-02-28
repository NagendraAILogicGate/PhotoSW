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
	public class DiscountTypeDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getDiscountType;
        public DiscountTypeDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public DiscountTypeDao()
		{
		}

		public int Add(DiscountTypeInfo objectInfo)
		{
			base.DBParameters.Clear();
			string expr_19B = DiscountTypeDao.getDiscountType(13673);
			object expr_1AB = objectInfo.DG_Orders_DiscountType_Name;
			if (!false)
			{
				base.AddParameter(expr_19B, expr_1AB);
			}
			base.AddParameter(DiscountTypeDao.getDiscountType(13718), objectInfo.DG_Orders_DiscountType_Desc);
			base.AddParameter(DiscountTypeDao.getDiscountType(13763), objectInfo.DG_Orders_DiscountType_Active);
			base.AddParameter(DiscountTypeDao.getDiscountType(13812), objectInfo.DG_Orders_DiscountType_Secure);
			do
			{
				base.AddParameter(DiscountTypeDao.getDiscountType(13861), objectInfo.DG_Orders_DiscountType_ItemLevel);
				base.AddParameter(DiscountTypeDao.getDiscountType(13914), objectInfo.DG_Orders_DiscountType_AsPercentage);
				base.AddParameter(DiscountTypeDao.getDiscountType(13971), objectInfo.DG_Orders_DiscountType_Code);
				base.AddParameter(DiscountTypeDao.getDiscountType(388), objectInfo.SyncCode);
				base.AddParameter(DiscountTypeDao.getDiscountType(409), objectInfo.IsSynced);
			}
			while (false);
			base.AddParameter(DiscountTypeDao.getDiscountType(14016), objectInfo.DG_Orders_DiscountType_Pkey, ParameterDirection.Output);
			base.ExecuteNonQuery("");
			return (int)base.GetOutParameterValue(DiscountTypeDao.getDiscountType(14016));
		}

		public bool Update(DiscountTypeInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(DiscountTypeDao.getDiscountType(14045), objectInfo.DG_Orders_DiscountType_Pkey);
			base.AddParameter(DiscountTypeDao.getDiscountType(13673), objectInfo.DG_Orders_DiscountType_Name);
			base.AddParameter(DiscountTypeDao.getDiscountType(13718), objectInfo.DG_Orders_DiscountType_Desc);
			base.AddParameter(DiscountTypeDao.getDiscountType(13763), objectInfo.DG_Orders_DiscountType_Active);
			base.AddParameter(DiscountTypeDao.getDiscountType(13812), objectInfo.DG_Orders_DiscountType_Secure);
			base.AddParameter(DiscountTypeDao.getDiscountType(13861), objectInfo.DG_Orders_DiscountType_ItemLevel);
			base.AddParameter(DiscountTypeDao.getDiscountType(13914), objectInfo.DG_Orders_DiscountType_AsPercentage);
			base.AddParameter(DiscountTypeDao.getDiscountType(13971), objectInfo.DG_Orders_DiscountType_Code);
			base.AddParameter(DiscountTypeDao.getDiscountType(409), objectInfo.IsSynced);
			base.ExecuteNonQuery("");
			return true;
		}

		public bool Delete(int objectvalueId)
		{
			base.DBParameters.Clear();
			base.AddParameter(DiscountTypeDao.getDiscountType(14045), objectvalueId);
			base.ExecuteNonQuery("");
			return true;
		}

		public DiscountTypeInfo Get(int? discountTypeId, string discountTypeName)
		{
			if (3 != 0)
			{
				base.DBParameters.Clear();
			}
			do
			{
				base.AddParameter(DiscountTypeDao.getDiscountType(14016), base.SetNullIntegerValue(discountTypeId));
				base.AddParameter(DiscountTypeDao.getDiscountType(14090), base.SetNullStringValue(discountTypeName));
			}
			while (2 == 0);
			List<DiscountTypeInfo> source;
			if (3 != 0)
			{
				using (IDataReader dataReader = base.ExecuteReader(""))
				{
					source = this.discountTypeInfo(dataReader);
				}
			}
			return source.FirstOrDefault<DiscountTypeInfo>();
		}

		public List<DiscountTypeInfo> Select(int? discountTypeId, string discountTypeName)
		{
			if (!false && -1 != 0)
			{
				base.DBParameters.Clear();
			}
			base.AddParameter(DiscountTypeDao.getDiscountType(14016), base.SetNullIntegerValue(discountTypeId));
			base.AddParameter(DiscountTypeDao.getDiscountType(14090), base.SetNullStringValue(discountTypeName));
			List<DiscountTypeInfo> result;
			using (IDataReader dataReader = base.ExecuteReader(""))
			{
				do
				{
					result = this.discountTypeInfo(dataReader);
				}
				while (4 == 0);
			}
			return result;
		}

		private List<DiscountTypeInfo> discountTypeInfo ( IDataReader dataReader)
		{
			List<DiscountTypeInfo> list = new List<DiscountTypeInfo>();
			while (true)
			{
				DiscountTypeInfo discountTypeInfo;
				if (!false)
				{
					if (!dataReader.Read())
					{
						break;
					}
					do
					{
						discountTypeInfo = new DiscountTypeInfo();
						discountTypeInfo.DG_Orders_DiscountType_Pkey = base.GetFieldValue(dataReader, DiscountTypeDao.getDiscountType(14123), 0);
						discountTypeInfo.DG_Orders_DiscountType_Name = base.GetFieldValue(dataReader, DiscountTypeDao.getDiscountType(14160), string.Empty);
						discountTypeInfo.DG_Orders_DiscountType_Desc = base.GetFieldValue(dataReader, DiscountTypeDao.getDiscountType(14197), string.Empty);
						discountTypeInfo.DG_Orders_DiscountType_Active = new bool?(base.GetFieldValue(dataReader, DiscountTypeDao.getDiscountType(14234), false));
						discountTypeInfo.DG_Orders_DiscountType_Secure = new bool?(base.GetFieldValue(dataReader, DiscountTypeDao.getDiscountType(14275), false));
						discountTypeInfo.DG_Orders_DiscountType_ItemLevel = new bool?(base.GetFieldValue(dataReader, DiscountTypeDao.getDiscountType(14316), false));
						discountTypeInfo.DG_Orders_DiscountType_AsPercentage = new bool?(base.GetFieldValue(dataReader, DiscountTypeDao.getDiscountType(14361), false));
						discountTypeInfo.DG_Orders_DiscountType_Code = base.GetFieldValue(dataReader, DiscountTypeDao.getDiscountType(14410), string.Empty);
					}
					while (false);
					discountTypeInfo.SyncCode = base.GetFieldValue(dataReader, DiscountTypeDao.getDiscountType(1980), string.Empty);
					discountTypeInfo.IsSynced = base.GetFieldValue(dataReader, DiscountTypeDao.getDiscountType(1993), false);
				}
				DiscountTypeInfo item = discountTypeInfo;
				list.Add(item);
			}
			return list;
		}

		static DiscountTypeDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(DiscountTypeDao));
		}
	}
}
