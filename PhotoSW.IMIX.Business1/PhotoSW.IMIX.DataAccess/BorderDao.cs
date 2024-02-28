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
	public class BorderDao : BaseDataAccess
	{
        //NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getBorder;
        public BorderDao(BaseDataAccess baseaccess) : base(baseaccess)
		{

		}

		public BorderDao()
		{
		}

		public int Add(BorderInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(BorderDao.getBorder(2595), objectInfo.DG_Border);
			base.AddParameter(BorderDao.getBorder(2616), objectInfo.DG_ProductTypeID);
			if (-1 == 0)
			{
				goto IL_D4;
			}
			base.AddParameter(BorderDao.getBorder(2649), objectInfo.DG_IsActive);
			base.AddParameter(BorderDao.getBorder(380), objectInfo.SyncCode);
			base.AddParameter(BorderDao.getBorder(401), objectInfo.IsSynced);
			IL_B4:
			base.AddParameter(BorderDao.getBorder(2195), objectInfo.CreatedBy);
			IL_D4:
			base.AddParameter(BorderDao.getBorder(2674), objectInfo.DG_Borders_pkey, ParameterDirection.Output);
			if (!false)
			{
				base.ExecuteNonQuery("");
				return (int)base.GetOutParameterValue(BorderDao.getBorder(2674));
			}
			goto IL_B4;
		}

		public bool Update(BorderInfo objectInfo)
		{
			base.DBParameters.Clear();
			do
			{
				base.AddParameter(BorderDao.getBorder(2695), objectInfo.DG_Borders_pkey);
				base.AddParameter(BorderDao.getBorder(2595), objectInfo.DG_Border);
				base.AddParameter(BorderDao.getBorder(2616), objectInfo.DG_ProductTypeID);
				base.AddParameter(BorderDao.getBorder(2649), objectInfo.DG_IsActive);
				base.AddParameter(BorderDao.getBorder(2274), objectInfo.ModifiedBy);
				base.AddParameter(BorderDao.getBorder(401), objectInfo.IsSynced);
				base.ExecuteNonQuery("");
			}
			while (4 == 0);
			return true;
		}

		public bool Delete(int objectvalueId)
		{
			base.DBParameters.Clear();
			base.AddParameter(BorderDao.getBorder(2695), objectvalueId);
			base.ExecuteNonQuery("");
			return true;
		}

		public BorderInfo Get(int? borderId)
		{
			List<BorderInfo> source;
			do
			{
				if (7 != 0 && !false)
				{
					base.DBParameters.Clear();
					base.AddParameter(BorderDao.getBorder(2674), base.SetNullIntegerValue(borderId));
				}
				using (IDataReader dataReader = base.ExecuteReader(""))
				{
					source = this.borderInfo(dataReader);
				}
			}
			while (-1 == 0);
			return source.FirstOrDefault<BorderInfo>();
		}

		public List<BorderInfo> Select(int? borderId)
		{
			List<BorderInfo> result;
			if (!false)
			{
				base.DBParameters.Clear();
				base.AddParameter(BorderDao.getBorder(2674), base.SetNullIntegerValue(borderId));
				IDataReader dataReader = base.ExecuteReader("");
				try
				{
					result = this.borderInfo(dataReader);
				}
				finally
				{
					if (dataReader != null && 2 != 0)
					{
						dataReader.Dispose();
					}
				}
			}
			return result;
		}

		public List<BorderInfo> SelectBorder()
		{
			while (true)
			{
				if (4 != 0)
				{
					base.DBParameters.Clear();
					base.OpenConnection();
				}
				if (!false)
				{
					base.AddParameter(BorderDao.getBorder(2674), base.SetNullIntegerValue(null));
					if (!false)
					{
						break;
					}
				}
			}
			IDataReader dataReader = base.ExecuteReader("");
			List<BorderInfo> result;
			try
			{
				result = this.borderInfo(dataReader);
			}
			finally
			{
				while (dataReader != null)
				{
					if (true)
					{
						dataReader.Dispose();
						break;
					}
				}
			}
			return result;
		}

		private List<BorderInfo> borderInfo ( IDataReader dataReader)
		{
			List<BorderInfo> list = new List<BorderInfo>();
			while (dataReader.Read())
			{
				BorderInfo item = new BorderInfo
				{
					DG_Borders_pkey = base.GetFieldValue(dataReader, BorderDao.getBorder(2724), 0),
					DG_Border = base.GetFieldValue(dataReader, BorderDao.getBorder(2745), string.Empty),
					DG_ProductTypeID = base.GetFieldValue(dataReader, BorderDao.getBorder(2758), 0),
					DG_IsActive = base.GetFieldValue(dataReader, BorderDao.getBorder(2783), false),
					SyncCode = base.GetFieldValue(dataReader, BorderDao.getBorder(1972), string.Empty),
					IsSynced = base.GetFieldValue(dataReader, BorderDao.getBorder(1985), false),
					DG_Orders_ProductType_Name = base.GetFieldValue(dataReader, BorderDao.getBorder(2800), string.Empty),
					CreatedBy = new int?(base.GetFieldValue(dataReader, BorderDao.getBorder(2837), 0)),
					ModifiedBy = new int?(base.GetFieldValue(dataReader, BorderDao.getBorder(2850), 0)),
					CreatedDate = new DateTime?(base.GetFieldValue(dataReader, BorderDao.getBorder(2867), DateTime.MinValue)),
					ModifiedDate = new DateTime?(base.GetFieldValue(dataReader, BorderDao.getBorder(2884), DateTime.MinValue))
				};
				list.Add(item);
			}
			return list;
		}

		public BorderInfo SelectBorderProductwise(int? ProductTypeID)
		{
			List<BorderInfo> source;
			do
			{
				if (7 != 0 && !false)
				{
					base.DBParameters.Clear();
					base.AddParameter(BorderDao.getBorder(2616), base.SetNullIntegerValue(ProductTypeID));
				}
				using (IDataReader dataReader = base.ExecuteReader(""))
				{
					source = this.borderInfo2(dataReader);
				}
			}
			while (-1 == 0);
			return source.FirstOrDefault<BorderInfo>();
		}

		private List<BorderInfo> borderInfo2 ( IDataReader dataReader)
		{
			List<BorderInfo> list;
			while (true)
			{
				list = new List<BorderInfo>();
				while (true)
				{
					BorderInfo item;
					if (!dataReader.Read())
					{
						if (7 != 0)
						{
							return list;
						}
					}
					else
					{
						BorderInfo borderInfo;
						if (!false)
						{
							borderInfo = new BorderInfo();
							if (false)
							{
								break;
							}
							borderInfo.DG_Borders_pkey = base.GetFieldValue(dataReader, BorderDao.getBorder(2724), 0);
							do
							{
								borderInfo.DG_Border = base.GetFieldValue(dataReader, BorderDao.getBorder(2745), string.Empty);
								if (!false)
								{
									borderInfo.DG_ProductTypeID = base.GetFieldValue(dataReader, BorderDao.getBorder(2758), 0);
									borderInfo.DG_IsActive = base.GetFieldValue(dataReader, BorderDao.getBorder(2783), false);
									borderInfo.SyncCode = base.GetFieldValue(dataReader, BorderDao.getBorder(1972), string.Empty);
								}
								borderInfo.IsSynced = base.GetFieldValue(dataReader, BorderDao.getBorder(1985), false);
								borderInfo.CreatedBy = new int?(base.GetFieldValue(dataReader, BorderDao.getBorder(2837), 0));
							}
							while (false);
							borderInfo.ModifiedBy = new int?(base.GetFieldValue(dataReader, BorderDao.getBorder(2850), 0));
							borderInfo.CreatedDate = new DateTime?(base.GetFieldValue(dataReader, BorderDao.getBorder(2867), DateTime.MinValue));
							borderInfo.ModifiedDate = new DateTime?(base.GetFieldValue(dataReader, BorderDao.getBorder(2884), DateTime.MinValue));
							//borderInfo.ProductTypeInfo = new ProductTypeInfo
							//{
							//	DG_Orders_ProductType_Name = base.GetFieldValue(dataReader, BorderDao.getBorder(2800), string.Empty)
							//};
						}
						item = borderInfo;
					}
					list.Add(item);
				}
			}
			return list;
		}

		public List<BorderInfo> SelectBorderDetails(string OrdersProductTypeName)
		{
			IDataReader dataReader;
			List<BorderInfo> result;
			while (-1 != 0)
			{
				base.DBParameters.Clear();
				if (false)
				{
					break;
				}
				base.AddParameter(BorderDao.getBorder(2901), OrdersProductTypeName);
				if (8 != 0)
				{
					if (!false)
					{
						dataReader = base.ExecuteReader("");
						result = this.borderInfo3(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private List<BorderInfo> borderInfo3 ( IDataReader dataReader)
		{
			List<BorderInfo> list = new List<BorderInfo>();
			while (true)
			{
				BorderInfo borderInfo;
				if (!false)
				{
					if (!dataReader.Read())
					{
						break;
					}
					borderInfo = new BorderInfo();
					borderInfo.DG_Borders_pkey = base.GetFieldValue(dataReader, BorderDao.getBorder(2724), 0);
					borderInfo.DG_Border = base.GetFieldValue(dataReader, BorderDao.getBorder(2745), string.Empty);
					borderInfo.DG_ProductTypeID = base.GetFieldValue(dataReader, BorderDao.getBorder(2758), 0);
					borderInfo.DG_IsActive = base.GetFieldValue(dataReader, BorderDao.getBorder(2783), false);
					do
					{
						borderInfo.DG_Orders_ProductType_pkey = base.GetFieldValue(dataReader, BorderDao.getBorder(2938), 0);
					}
					while (5 == 0);
					borderInfo.DG_Orders_ProductType_Name = base.GetFieldValue(dataReader, BorderDao.getBorder(2800), string.Empty);
					borderInfo.CreatedBy = new int?(base.GetFieldValue(dataReader, BorderDao.getBorder(2837), 0));
					borderInfo.ModifiedBy = new int?(base.GetFieldValue(dataReader, BorderDao.getBorder(2850), 0));
					borderInfo.CreatedDate = new DateTime?(base.GetFieldValue(dataReader, BorderDao.getBorder(2867), DateTime.MinValue));
					borderInfo.ModifiedDate = new DateTime?(base.GetFieldValue(dataReader, BorderDao.getBorder(2884), DateTime.MinValue));
				}
				BorderInfo item = borderInfo;
				list.Add(item);
			}
			return list;
		}

		public List<VideoOverlay> SelectVideoOverlay(int? id)
		{
			do
			{
				List<SqlParameter> expr_7F = base.DBParameters;
				if (!false)
				{
					expr_7F.Clear();
				}
				base.DBParameters.Clear();
				base.AddParameter(BorderDao.getBorder(2975), base.SetNullIntegerValue(id));
			}
			while (false);
			IDataReader dataReader = base.ExecuteReader(BorderDao.getBorder(2996));
			List<VideoOverlay> result;
			try
			{
				if (!false && !false)
				{
					result = this.videoOverlay(dataReader);
				}
			}
			finally
			{
				do
				{
					if (dataReader != null)
					{
						dataReader.Dispose();
					}
				}
				while (4 == 0);
			}
			return result;
		}

		private List<VideoOverlay> videoOverlay (IDataReader dateReader)
		{
			List<VideoOverlay> list = new List<VideoOverlay>();
			while (dateReader.Read())
			{
				VideoOverlay videoOverlay = new VideoOverlay();
				videoOverlay.VideoOverlayId = base.GetFieldValue(dateReader, BorderDao.getBorder(3017), 0L);
				videoOverlay.Name = base.GetFieldValue(dateReader, BorderDao.getBorder(514), string.Empty);
				videoOverlay.DisplayName = base.GetFieldValue(dateReader, BorderDao.getBorder(3038), string.Empty);
				videoOverlay.VideoLength = base.GetFieldValue(dateReader, BorderDao.getBorder(3055), 0L);
				if (!false)
				{
					videoOverlay.IsActive = base.GetFieldValue(dateReader, BorderDao.getBorder(3072), false);
				}
				videoOverlay.MediaType = base.GetFieldValue(dateReader, BorderDao.getBorder(3085), 0);
				videoOverlay.Description = base.GetFieldValue(dateReader, BorderDao.getBorder(3098), string.Empty);
				videoOverlay.CreatedBy = base.GetFieldValue(dateReader, BorderDao.getBorder(2837), 0);
				videoOverlay.ModifiedBy = base.GetFieldValue(dateReader, BorderDao.getBorder(2850), 0);
				videoOverlay.CreatedOn = new DateTime?(base.GetFieldValue(dateReader, BorderDao.getBorder(3115), DateTime.MinValue));
				videoOverlay.ModifiedOn = new DateTime?(base.GetFieldValue(dateReader, BorderDao.getBorder(3128), DateTime.MinValue));
				VideoOverlay item = videoOverlay;
				list.Add(item);
			}
			return list;
		}

		static BorderDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(BorderDao));
		}
	}
}
