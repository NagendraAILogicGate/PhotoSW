//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class SageInfoAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getSageInfoAccess;
        public SageInfoAccess (BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public SageInfoAccess()
		{
		}

		public SageInfo GetOpenCloseProcDetail(int SubStoreID)
		{
			SageInfo result;
			while (true)
			{
				if (false)
				{
					goto IL_41;
				}
				List<SqlParameter> expr_55 = base.DBParameters;
				if (!false)
				{
					expr_55.Clear();
				}
				if (-1 != 0)
				{
					base.AddParameter(SageInfoAccess.getSageInfoAccess(25525), SubStoreID);
					goto IL_25;
				}
				IL_4A:
				if (!true)
				{
					continue;
				}
				if (!false)
				{
					break;
				}
				IL_41:
				IDataReader dataReader;
				if (-1 != 0)
				{
					dataReader.Close();
					goto IL_4A;
				}
				IL_25:
				dataReader = base.ExecuteReader(SageInfoAccess.getSageInfoAccess(54134));
				result = this.PopulateSageInfo(dataReader);
				goto IL_41;
			}
			return result;
		}

		public SageInfo PopulateSageInfo(IDataReader sqlReader)
		{
			SageInfo expr_00 = null;
			SageInfo sageInfo;
			if (!false)
			{
				sageInfo = expr_00;
			}
			while (sqlReader.Read())
			{
				sageInfo = new SageInfo();
				sageInfo.OpenCloseProcDetailID = base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(54179), 0L);
				sageInfo.FormTypeID = base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(54208), 0);
				sageInfo.SubStoreID = base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(10980), 0);
				sageInfo.FilledOn = new DateTime?(base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(54225), Convert.ToDateTime(SageInfoAccess.getSageInfoAccess(54242))));
				sageInfo.FormID = base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(54259), 0);
				sageInfo.sixEightStartingNumber = base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(54268), 0L);
				sageInfo.eightTenStartingNumber = base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(54293), 0L);
				sageInfo.PosterStartingNumber = base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(54318), 0L);
				sageInfo.TransDate = new DateTime?(base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(54347), Convert.ToDateTime(SageInfoAccess.getSageInfoAccess(54242))));
				sageInfo.BusinessDate = new DateTime?(base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(54360), Convert.ToDateTime(SageInfoAccess.getSageInfoAccess(54242))));
				sageInfo.ServerTime = base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(54381), Convert.ToDateTime(SageInfoAccess.getSageInfoAccess(54242)));
				sageInfo.sixEightAutoStartingNumber = base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(54398), 0L);
				sageInfo.eightTenAutoStartingNumber = base.GetFieldValue(sqlReader, SageInfoAccess.getSageInfoAccess(54427), 0L);
			}
			return sageInfo;
		}

		public string SaveOpeningForm(SageInfo _sageInfo, DataTable dt6850, DataTable dt8810)
		{
			base.DBParameters.Clear();
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54460), _sageInfo.sixEightStartingNumber);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54485), _sageInfo.eightTenStartingNumber);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54514), _sageInfo.sixEightAutoStartingNumber);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54547), _sageInfo.eightTenAutoStartingNumber);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54580), _sageInfo.PosterStartingNumber);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54609), _sageInfo.CashFloatAmount);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(25525), _sageInfo.SubStoreID);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54634), _sageInfo.OpeningDate);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54651), _sageInfo.FilledBy);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54664), _sageInfo.FormTypeID);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(27877), _sageInfo.SyncCode);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54681), _sageInfo.BusinessDate);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54702), dt6850);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54731), dt8810);
			object obj = base.ExecuteScalar(SageInfoAccess.getSageInfoAccess(54760));
			return obj.ToString();
		}

		public bool SaveClosingForm(SageOpenClose objOpenClose, DataTable dtInventoryConsumable, DataTable dt6850, DataTable dt8810)
		{
			SageInfoClosing objClose = objOpenClose.objClose;
			List<TransDetail> list = new List<TransDetail>();
			base.DBParameters.Clear();
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54793), objClose.sixEightClosingNumber);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54818), objClose.eightTenClosingNumber);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54843), objClose.sixEightAutoClosingNumber);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54872), objClose.eightTenAutoClosingNumber);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54905), objClose.PosterClosingNumber);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54934), objClose.SixEightWestage);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54951), objClose.EightTenWestage);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54968), objClose.SixEightAutoWestage);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54989), objClose.EightTenAutoWestage);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55014), objClose.PosterWestage);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55035), objClose.Attendance);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55052), objClose.LaborHour);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55069), objClose.NoOfCapture);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55086), objClose.NoOfPreview);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55103), objClose.NoOfImageSold);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55124), objClose.Comments);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(25525), objClose.objSubStore.DG_SubStore_pkey);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55137), objClose.ClosingDate);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54651), objClose.FilledBy);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54664), objClose.FormTypeID);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55154), objClose.TransDate);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55171), objClose.SixEightPrintCount);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55192), objClose.EightTenPrintCount);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55213), objClose.PosterPrintCount);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(27877), objClose.SyncCode);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54634), objClose.OpeningDate);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55238), dtInventoryConsumable);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54702), dt6850);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(54731), dt8810);
			IDataReader dataReader = base.ExecuteReader(SageInfoAccess.getSageInfoAccess(55271));
			while (dataReader.Read())
			{
				list.Add(new TransDetail
				{
					SubstoreID = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55304), 0),
					TransDate = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(54347), DateTime.MinValue),
					PackageID = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55321), 0),
					UnitPrice = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55334), 0.0m),
					Quantity = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(26407), 0.0m),
					Discount = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(26437), 0.0m),
					Total = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(51037), 0.0m),
					PackageSyncCode = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(2434), string.Empty),
					PackageCode = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(24910), string.Empty)
				});
			}
			objClose.TransDetails = list;
			dataReader.NextResult();
			objClose.objSubStore = new SubStoresInfo();
			while (dataReader.Read())
			{
				objClose.objSubStore.DG_SubStore_pkey = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(25014), 0);
				objClose.objSubStore.DG_SubStore_Name = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(13329), string.Empty);
				objClose.objSubStore.DG_SubStore_Code = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(29315), string.Empty);
				objClose.objSubStore.SyncCode = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(2434), string.Empty);
			}
			dataReader.NextResult();
			objClose.InventoryConsumable = new List<InventoryConsumables>();
			while (dataReader.Read())
			{
				InventoryConsumables inventoryConsumables = new InventoryConsumables();
				inventoryConsumables.AccessoryID = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55347), 0L);
				inventoryConsumables.ConsumeValue = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55364), 0L);
				inventoryConsumables.AccessorySyncCode = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(2434), string.Empty);
				inventoryConsumables.AccessoryCode = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(24910), string.Empty);
				objClose.InventoryConsumable.Add(inventoryConsumables);
			}
			dataReader.NextResult();
			while (dataReader.Read())
			{
				objClose.FilledBySyncCode = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55381), string.Empty);
			}
			dataReader.NextResult();
			while (dataReader.Read())
			{
				objClose.ClosingFormDetailID = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55406), 0L);
				objClose.Cash = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55435), 0.0m);
				objClose.CreditCard = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55444), 0.0m);
				objClose.Amex = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55461), 0.0m);
				objClose.FCV = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55470), 0.0m);
				objClose.RoomCharges = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55475), 0.0m);
				objClose.KVL = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55492), 0.0m);
				objClose.Vouchers = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55497), 0.0m);
			}
			dataReader.NextResult();
			while (dataReader.Read())
			{
				objOpenClose.objOpen = new SageInfo
				{
					OpeningFormDetailID = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55510), 0L),
					sixEightStartingNumber = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55539), 0L),
					eightTenStartingNumber = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55564), 0L),
					PosterStartingNumber = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(54318), 0L),
					CashFloatAmount = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55589), 0.0m),
					OpeningDate = new DateTime?(base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(54225), Convert.ToDateTime(SageInfoAccess.getSageInfoAccess(55610)))),
					SyncCode = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(2434), string.Empty),
					BusinessDate = new DateTime?(base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(54360), Convert.ToDateTime(SageInfoAccess.getSageInfoAccess(55610)))),
					FilledBySyncCode = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55381), string.Empty)
				};
			}
			dataReader.Close();
			return true;
		}

		public List<SageInfoWestage> ProductTypeWestage(DateTime FromDate, DateTime ToDate, int SubStoreID)
		{
			IDataReader dataReader;
			List<SageInfoWestage> list;
			while (true)
			{
				IL_00:
				base.DBParameters.Clear();
				base.AddParameter(SageInfoAccess.getSageInfoAccess(55623), FromDate);
				base.AddParameter(SageInfoAccess.getSageInfoAccess(55636), ToDate);
				while (true)
				{
					IL_51:
					base.AddParameter(SageInfoAccess.getSageInfoAccess(25525), SubStoreID);
					dataReader = base.ExecuteReader(SageInfoAccess.getSageInfoAccess(55649));
					list = new List<SageInfoWestage>();
					while (dataReader.Read())
					{
						if (!false)
						{
							SageInfoWestage sageInfoWestage = new SageInfoWestage();
							sageInfoWestage.ProductType = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(3400), 0);
							if (false)
							{
								goto IL_00;
							}
							sageInfoWestage.Reprint = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55686), 0);
							sageInfoWestage.Printed = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(27089), 0L);
							if (!true)
							{
								goto IL_51;
							}
							list.Add(sageInfoWestage);
						}
					}
					goto Block_3;
				}
			}
			Block_3:
			dataReader.Close();
			return list;
		}

		public int GetCaptureBySubStoreAndDateRange(DateTime FromDate, DateTime ToDate, int SubStoreID)
		{
			while (true)
			{
				base.DBParameters.Clear();
				if (7 != 0)
				{
					base.AddParameter(SageInfoAccess.getSageInfoAccess(55623), FromDate);
					if (!false)
					{
						break;
					}
				}
			}
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55636), ToDate);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(25525), SubStoreID);
			int result;
			do
			{
				result = 0;
			}
			while (4 == 0);
			IDataReader dataReader = base.ExecuteReader(SageInfoAccess.getSageInfoAccess(55703));
			if (dataReader.Read() && 6 != 0 && 6 != 0)
			{
				result = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(17329), 0);
			}
			return result;
		}

		public int GetPreviewBySubStoreAndDateRange(DateTime FromDate, DateTime ToDate, int SubStoreID)
		{
			while (true)
			{
				base.DBParameters.Clear();
				if (7 != 0)
				{
					base.AddParameter(SageInfoAccess.getSageInfoAccess(55623), FromDate);
					if (!false)
					{
						break;
					}
				}
			}
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55636), ToDate);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(25525), SubStoreID);
			int result;
			do
			{
				result = 0;
			}
			while (4 == 0);
			IDataReader dataReader = base.ExecuteReader(SageInfoAccess.getSageInfoAccess(55760));
			if (dataReader.Read() && 6 != 0 && 6 != 0)
			{
				result = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(17329), 0);
			}
			return result;
		}

		public long GetTotalSoldBySubStoreAndDateRange(DateTime FromDate, DateTime ToDate, int SubStoreID)
		{
			base.DBParameters.Clear();
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55623), FromDate);
			base.AddParameter(SageInfoAccess.getSageInfoAccess(55636), ToDate);
			long result;
			do
			{
				base.AddParameter(SageInfoAccess.getSageInfoAccess(25525), SubStoreID);
				result = 0L;
			}
			while (8 == 0);
			IDataReader dataReader = base.ExecuteReader(SageInfoAccess.getSageInfoAccess(55817));
			if (dataReader.Read())
			{
				result = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(26651), 0L);
			}
			return result;
		}

		public List<ImixPOSDetail> GetPrintServerDetails(int SubStoreID)
		{
			base.DBParameters.Clear();
			string expr_118 = SageInfoAccess.getSageInfoAccess(25525);
			object expr_28 = SubStoreID;
			if (2 != 0)
			{
				base.AddParameter(expr_118, expr_28);
			}
			IDataReader dataReader = base.ExecuteReader(SageInfoAccess.getSageInfoAccess(55878));
			List<ImixPOSDetail> list = new List<ImixPOSDetail>();
			while (true)
			{
				while (dataReader.Read())
				{
					if (7 != 0)
					{
						list.Add(new ImixPOSDetail
						{
							ImixPOSDetailID = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55919), 0L),
							SystemName = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(55940), string.Empty),
							SubStoreID = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(10980), 0L),
							IsActive = base.GetFieldValue(dataReader, SageInfoAccess.getSageInfoAccess(3534), false)
						});
					}
				}
				break;
			}
			dataReader.Close();
			return list;
		}

		static SageInfoAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(SageInfoAccess));
		}
	}
}
