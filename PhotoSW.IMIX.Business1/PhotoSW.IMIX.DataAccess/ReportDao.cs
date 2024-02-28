//using #2j;
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
	public class ReportDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getReportAccess;
        public ReportDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public ReportDao()
		{
		}

		public DataSet SelectFinancialAudit(DateTime StartDate, DateTime EndDate, string UserName, string StoreName, int SubStoreId)
		{
			base.DBParameters.Clear();
			base.AddParameter(ReportDao.getReportAccess(2404), StartDate);
			base.AddParameter(ReportDao.getReportAccess(2425), EndDate);
			base.AddParameter(ReportDao.getReportAccess(25813), UserName);
			base.AddParameter(ReportDao.getReportAccess(25834), StoreName);
			base.AddParameter(ReportDao.getReportAccess(25855), base.SetNullIntegerValue(new int?(SubStoreId)));
			return base.ExecuteDataSet("");
		}

		private List<FinancialAuditTrail_Result> FinancialAuditTrail_ResultJc ( IDataReader IDataReader )
		{
			List<FinancialAuditTrail_Result> list = new List<FinancialAuditTrail_Result>();
			while (IDataReader.Read())
			{
				FinancialAuditTrail_Result item = new FinancialAuditTrail_Result
				{
					UserName = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(25880), string.Empty),
					StoreName = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(25893), string.Empty),
					StartDate = new DateTime?(base.GetFieldValue(IDataReader, ReportDao.getReportAccess(2476), DateTime.Now)),
					EndDate = new DateTime?(base.GetFieldValue(IDataReader, ReportDao.getReportAccess(2489), DateTime.Now)),
					OrderNumber = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(25906), string.Empty),
					OrderDate = new DateTime?(base.GetFieldValue(IDataReader, ReportDao.getReportAccess(25923), DateTime.Now)),
					ProductType = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(25936), string.Empty),
					SellPrice = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(25953), string.Empty),
					Quantity = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(25966), 0),
					TotalPrice = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(25979), string.Empty),
					Discount = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(25996), string.Empty),
					revenue = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26009), string.Empty),
					TotalOrderPrice = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26022), string.Empty),
					DG_Order_SubStoreId = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(17724), string.Empty),
					ProductCode = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26043), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public DataSet SelectLocationPerformance(DateTime FromDate, DateTime ToDate, DateTime SecondFromDate, DateTime SecondToDate, bool Comparasion, string StoreName, string UserName, int SubStoreId)
		{
			while (true)
			{
				List<SqlParameter> expr_11D = base.DBParameters;
				if (6 != 0)
				{
					expr_11D.Clear();
				}
				if (6 != 0)
				{
					if (true)
					{
						base.AddParameter(ReportDao.getReportAccess(711), FromDate);
						goto IL_3D;
					}
					goto IL_77;
				}
				IL_C6:
				base.AddParameter(ReportDao.getReportAccess(25813), UserName);
				if (5 == 0)
				{
					continue;
				}
				base.AddParameter(ReportDao.getReportAccess(25855), base.SetNullIntegerValue(new int?(SubStoreId)));
				if (!false)
				{
					break;
				}
				goto IL_3D;
				IL_77:
				base.AddParameter(ReportDao.getReportAccess(26089), SecondToDate);
				base.AddParameter(ReportDao.getReportAccess(26114), Comparasion);
				base.AddParameter(ReportDao.getReportAccess(25834), StoreName);
				goto IL_C6;
				IL_3D:
				base.AddParameter(ReportDao.getReportAccess(732), ToDate);
				base.AddParameter(ReportDao.getReportAccess(26060), SecondFromDate);
				goto IL_77;
			}
			return base.ExecuteDataSet("");
		}

		private List<GetLocationPerformance_Result> GetLocationPerformance_ResultKc ( IDataReader IDataReader)
		{
			List<GetLocationPerformance_Result> list=null;
			if (-1 != 0)
			{
				List<GetLocationPerformance_Result> expr_2D8 = new List<GetLocationPerformance_Result>();
				if (-1 != 0)
				{
					list = expr_2D8;
				}
				goto IL_2CB;
			}
			GetLocationPerformance_Result getLocationPerformance_Result;
			do
			{
				IL_CB:
				getLocationPerformance_Result.DG_Location_Name = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(16372), string.Empty);
			}
			while (!true);
			getLocationPerformance_Result.StoreName = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(25893), string.Empty);
			getLocationPerformance_Result.Printedby = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26236), string.Empty);
			getLocationPerformance_Result.DG_Location_pkey = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(16397), 0);
			getLocationPerformance_Result.DG_SubStore_Name = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(12888), string.Empty);
			getLocationPerformance_Result.Shots_Previewed = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26249), 0);
			getLocationPerformance_Result.DataFlag = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26270), string.Empty);
			getLocationPerformance_Result.FromDate = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26283), DateTime.Now);
			getLocationPerformance_Result.ToDate = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26296), DateTime.Now);
			getLocationPerformance_Result.SecondFromDate = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26305), DateTime.Now);
			getLocationPerformance_Result.SecondToDate = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26326), DateTime.Now);
			getLocationPerformance_Result.AveragePrice = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26343), 0.0m);
			getLocationPerformance_Result.SellThru = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26360), 0.0m);
			getLocationPerformance_Result.defaultCurrency = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26373), string.Empty);
			getLocationPerformance_Result.TotalSiteRevenue = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26394), 0.0m);
			list.Add(getLocationPerformance_Result);
			IL_2CB:
			if (!IDataReader.Read())
			{
				return list;
			}
			getLocationPerformance_Result = new GetLocationPerformance_Result();
			getLocationPerformance_Result.selectedSubStore = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26139), string.Empty);
			getLocationPerformance_Result.Number_of_Capture = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26164), 0);
			getLocationPerformance_Result.Number_of_Sales = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26189), 0);
			getLocationPerformance_Result.ImageSold = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26210), 0);
			getLocationPerformance_Result.Revenue = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26223), 0.0m);
			//goto IL_CB;
            return list;
		}

		public DataSet SelectPhotgrapherPerformance(DateTime FromDate, DateTime ToDate, DateTime SecondFromDate, DateTime SecondToDate, bool Comparasion, string StoreName, string UserName)
		{
			do
			{
				base.DBParameters.Clear();
				base.AddParameter(ReportDao.getReportAccess(711), FromDate);
			}
			while (6 == 0);
			base.AddParameter(ReportDao.getReportAccess(732), ToDate);
			base.AddParameter(ReportDao.getReportAccess(26060), SecondFromDate);
			base.AddParameter(ReportDao.getReportAccess(26089), SecondToDate);
			do
			{
				if (!false)
				{
					base.AddParameter(ReportDao.getReportAccess(26114), Comparasion);
				}
				base.AddParameter(ReportDao.getReportAccess(25834), StoreName);
				base.AddParameter(ReportDao.getReportAccess(25813), UserName);
			}
			while (-1 == 0);
			return base.ExecuteDataSet("");
		}

		private List<GetPhotgrapherPerformance_Result> GetPhotgrapherPerformance_ResultLc ( IDataReader IDataReader)
		{
			List<GetPhotgrapherPerformance_Result> list;
			while (true)
			{
				if (6 == 0)
				{
					goto IL_1A0;
				}
				if (false)
				{
					goto IL_EF;
				}
				list = new List<GetPhotgrapherPerformance_Result>();
				IL_20B:
				if (!IDataReader.Read())
				{
					break;
				}
				GetPhotgrapherPerformance_Result getPhotgrapherPerformance_Result = new GetPhotgrapherPerformance_Result();
				if (!false)
				{
                    getPhotgrapherPerformance_Result.NumberofCapture = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26419), 0);
                    getPhotgrapherPerformance_Result.ImageSold = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26210), 0);
                    getPhotgrapherPerformance_Result.Revenue = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26223), 0.0m);
					getPhotgrapherPerformance_Result.DataFlag = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26270), string.Empty);
					getPhotgrapherPerformance_Result.NumberofSales = base.GetFieldValue(IDataReader,   ReportDao.getReportAccess(26440), 0);
					getPhotgrapherPerformance_Result.Shots_Previewed = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26249), 0);
					goto IL_EF;
				}
				continue;
				IL_179:
				if (false)
				{
					continue;
				}
				getPhotgrapherPerformance_Result.FromDate2 = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26487), DateTime.Now);
				IL_1A0:
				getPhotgrapherPerformance_Result.ToDate2 = base.GetFieldValue(IDataReader,  ReportDao.getReportAccess(26500), DateTime.Now);
				getPhotgrapherPerformance_Result.UserName = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(25880), string.Empty);
				if (!false)
				{
					getPhotgrapherPerformance_Result.DG_User_pkey = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(694), 0);
					goto IL_202;
				}
				goto IL_179;
				IL_EF:
				getPhotgrapherPerformance_Result.StoreName = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(25893), string.Empty);
				getPhotgrapherPerformance_Result.Printedby = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26236), string.Empty);
				getPhotgrapherPerformance_Result.FromDate1 = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26461), DateTime.Now);
				if (!false)
				{
					getPhotgrapherPerformance_Result.ToDate1 = base.GetFieldValue(IDataReader, ReportDao.getReportAccess (26474), DateTime.Now);
					goto IL_179;
				}
				IL_202:
				GetPhotgrapherPerformance_Result item = getPhotgrapherPerformance_Result;
				list.Add(item);
				goto IL_20B;
			}
			return list;
		}

		public DataSet SelectOperatorPerformanceReport(int CurrencyId, DateTime FromDate, DateTime ToDate, DateTime SecondFromDate, DateTime SecondToDate, bool Comparasion, string StoreName, string UserName)
		{
			base.DBParameters.Clear();
			base.AddParameter(ReportDao.getReportAccess(13008), CurrencyId);
			base.AddParameter(ReportDao.getReportAccess(711), FromDate);
			base.AddParameter(ReportDao.getReportAccess(732), ToDate);
			if (7 != 0)
			{
				base.AddParameter(ReportDao.getReportAccess (26060), SecondFromDate);
				if (false)
				{
					goto IL_C6;
				}
				base.AddParameter(ReportDao.getReportAccess(26089), SecondToDate);
			}
			base.AddParameter(ReportDao.getReportAccess (26114), Comparasion);
			IL_C6:
			base.AddParameter(ReportDao.getReportAccess(25834), StoreName);
			base.AddParameter(ReportDao.getReportAccess(25813), UserName);
			return null;//base.ExecuteDataSet(#1j.#Xe);
		}

		public DataSet SelectTakingReport(DateTime? FromDate, DateTime? ToDate, int SubStorePKey)
		{
			base.DBParameters.Clear();
			base.AddParameter(ReportDao.getReportAccess(711), base.SetNullDateTimeValue(FromDate));
			base.AddParameter(ReportDao.getReportAccess(732), base.SetNullDateTimeValue(ToDate));
			base.AddParameter(ReportDao.getReportAccess(1122), base.SetNullIntegerValue(new int?(SubStorePKey)));
			return null;//base.ExecuteDataSet(#1j.#Ye);
		}

		public DataSet SelectOperationalAudit(DateTime FromDate, DateTime ToDate, int SubStorePKey)
		{
			base.DBParameters.Clear();
			base.AddParameter(ReportDao.getReportAccess(711), base.SetNullDateTimeValue(new DateTime?(FromDate)));
			base.AddParameter(ReportDao.getReportAccess(732), base.SetNullDateTimeValue(new DateTime?(ToDate)));
			base.AddParameter(ReportDao.getReportAccess(25855), base.SetNullIntegerValue(new int?(SubStorePKey)));
			return null;//base.ExecuteDataSet(#1j.#xf);
		}

		private List<OperationalAudit_Result> OperationalAudit_ResultMc(IDataReader IDataReader)
		{
			List<OperationalAudit_Result> list = new List<OperationalAudit_Result>();
			while (true)
			{
				OperationalAudit_Result operationalAudit_Result;
				if (IDataReader.Read())
				{
					operationalAudit_Result = new OperationalAudit_Result();
					operationalAudit_Result.DG_Orders_pkey = base.GetFieldValue(IDataReader,   ReportDao.getReportAccess(16631), 0);
					operationalAudit_Result.DG_Orders_Number = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(16652), string.Empty);
					operationalAudit_Result.Location = base.GetFieldValue(IDataReader,         ReportDao.getReportAccess(26513), string.Empty);
					operationalAudit_Result.PhotoID = base.GetFieldValue(IDataReader,          ReportDao.getReportAccess(23872), string.Empty);
					operationalAudit_Result.Qty = base.GetFieldValue(IDataReader,              ReportDao.getReportAccess(26526), 0);
					operationalAudit_Result.PhotoGrapher = base.GetFieldValue(IDataReader,     ReportDao.getReportAccess(26531), string.Empty);
					goto IL_E3;
				}
				if (!false)
				{
					break;
				}
				IL_148:
				OperationalAudit_Result item;
				if (6 != 0)
				{
					list.Add(item);
					continue;
				}
				IL_E3:
				operationalAudit_Result.ProductType = base.GetFieldValue(IDataReader,  ReportDao.getReportAccess(25936), string.Empty);
				operationalAudit_Result.SubstoreName = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(26548), string.Empty);
				operationalAudit_Result.ProductCode = base.GetFieldValue(IDataReader,  ReportDao.getReportAccess(26043), string.Empty);
				item = operationalAudit_Result;
				goto IL_148;
			}
			return list;
		}

		public DataSet SelectProductSummary(DateTime ToDate, DateTime FROMDate, string UserName, string StoreName, int SubStorePKey)
		{
			base.DBParameters.Clear();
			base.AddParameter(ReportDao.getReportAccess(732), ToDate);
			base.AddParameter(ReportDao.getReportAccess(711), FROMDate);
			base.AddParameter(ReportDao.getReportAccess(25813), UserName);
			base.AddParameter(ReportDao.getReportAccess(25834), StoreName);
			base.AddParameter(ReportDao.getReportAccess(1122), base.SetNullIntegerValue(new int?(SubStorePKey)));
			return null;//base.ExecuteDataSet(#1j.#Ze);
		}

		public DataSet GetOrderDetailedDiscount(DateTime FromDate, DateTime ToDate, string UserName, string StoreName)
		{
			while (true)
			{
				if (!false && -1 != 0)
				{
					base.DBParameters.Clear();
				}
				base.AddParameter(ReportDao.getReportAccess(711), FromDate);
				while (!false)
				{
					base.AddParameter(ReportDao.getReportAccess(732), ToDate);
					base.AddParameter(ReportDao.getReportAccess(25813), UserName);
					if (5 != 0)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			base.AddParameter(ReportDao.getReportAccess (25834), StoreName);
			return base.ExecuteDataSet(ReportDao.getReportAccess (26565));
		}

		public DataSet SelectPrintedProduct(DateTime fromdate, DateTime todate, int SubStoreId)
		{
			while (true)
			{
				if (7 != 0 && !false)
				{
					base.DBParameters.Clear();
					goto IL_12;
				}
				IL_35:
				base.AddParameter(ReportDao.getReportAccess (732), todate);
				if (!false)
				{
					base.AddParameter(ReportDao.getReportAccess (1122), SubStoreId);
					if (4 != 0)
					{
						break;
					}
					continue;
				}
				IL_12:
				base.AddParameter(ReportDao.getReportAccess (711), fromdate);
				goto IL_35;
			}
			return null;//base.ExecuteDataSet(#1j.#Ue);
		}

		private List<GetPrintedProduct_Result> GetPrintedProduct_ResultNc(IDataReader IDataReader)
		{
			List<GetPrintedProduct_Result> list = new List<GetPrintedProduct_Result>();
			while (IDataReader.Read())
			{
				GetPrintedProduct_Result item = new GetPrintedProduct_Result
				{
					DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader,  ReportDao.getReportAccess(2821), string.Empty),
					DG_SubStore_Name = base.GetFieldValue(IDataReader,            ReportDao.getReportAccess(12888), string.Empty),
					PrintedQuantity = base.GetFieldValue(IDataReader,             ReportDao.getReportAccess(26610), 0),
					DG_Print_Date = new DateTime?(base.GetFieldValue(IDataReader, ReportDao.getReportAccess(23204), DateTime.Now)),
					PhotoNumber = base.GetFieldValue(IDataReader,                 ReportDao.getReportAccess(26631), string.Empty),
					ProductCode = base.GetFieldValue(IDataReader,                 ReportDao.getReportAccess(26043), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public DataSet GetPrintSummary(DateTime FromDate, DateTime ToDate, int SubStoreId)
		{
			while (true)
			{
				if (7 != 0 && !false)
				{
					base.DBParameters.Clear();
					goto IL_12;
				}
				IL_35:
				base.AddParameter(ReportDao.getReportAccess(732), ToDate);
				if (!false)
				{
					base.AddParameter(ReportDao.getReportAccess (1122), SubStoreId);
					if (4 != 0)
					{
						break;
					}
					continue;
				}
				IL_12:
				base.AddParameter(ReportDao.getReportAccess (711), FromDate);
				goto IL_35;
			}
			return null;// base.ExecuteDataSet(#1j.#Te);
		}

		public DataSet GetIPPrintTracking(DateTime FromDate, DateTime ToDate, int subStoreId, int packageID)
		{
			do
			{
				if (!false && -1 != 0)
				{
					base.DBParameters.Clear();
				}
				base.AddParameter(ReportDao.getReportAccess(711), FromDate);
			}
			while (false);
			base.AddParameter(ReportDao.getReportAccess (732), ToDate);
			do
			{
				base.AddParameter(ReportDao.getReportAccess (1122), subStoreId);
			}
			while (false || 4 == 0);
			base.AddParameter(ReportDao.getReportAccess (19592), packageID);
			return null;// base.ExecuteDataSet(#1j.#0e);
		}

		public DataSet GetIPContentTracking(DateTime FromDate, DateTime ToDate, int subStoreId, int packageID)
		{
			while (true)
			{
				if (7 != 0 && !false)
				{
					base.DBParameters.Clear();
					goto IL_12;
				}
				IL_35:
				base.AddParameter(ReportDao.getReportAccess(732), ToDate);
				if (!false)
				{
					base.AddParameter(ReportDao.getReportAccess (1122), subStoreId);
					if (4 != 0)
					{
						break;
					}
					continue;
				}
				IL_12:
				base.AddParameter(ReportDao.getReportAccess(711), FromDate);
				goto IL_35;
			}
			return null;//base.ExecuteDataSet(#1j.#kf);
		}

		private List<PrintSummary_Result> PrintSummary_ResultOc(IDataReader IDataReader)
		{
			List<PrintSummary_Result> list = new List<PrintSummary_Result>();
			while (true)
			{
				while (IDataReader.Read())
				{
					PrintSummary_Result printSummary_Result = new PrintSummary_Result();
					if (true)
					{
						printSummary_Result.DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader, ReportDao.getReportAccess(2821), string.Empty);
						printSummary_Result.PrintedQuantity = base.GetFieldValue(IDataReader,            ReportDao.getReportAccess(26610), 0);
						printSummary_Result.PrintedSold = base.GetFieldValue(IDataReader,                ReportDao.getReportAccess(26648), 0);
						PrintSummary_Result item = printSummary_Result;
						list.Add(item);
					}
				}
				break;
			}
			return list;
		}

		public void CollectOrderDetailedDiscountData(DateTime fromdate, DateTime todate)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(711), fromdate);
			}
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(732), todate);
			}
			//base.ExecuteNonQuery(#1j.#nf);
		}

		public void PurgeOrderDetailedDiscountData(DateTime fromdate, DateTime todate)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(711), fromdate);
			}
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess (732), todate);
			}
			//base.ExecuteNonQuery(#1j.#of);
		}

		public void CollectActivityReportData(DateTime fromdate, DateTime todate)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(711), fromdate);
			}
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(732), todate);
			}
			//base.ExecuteNonQuery(#1j.#pf);
		}

		public void PurgeActivityReportData(DateTime fromdate, DateTime todate)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(711), fromdate);
			}
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(732), todate);
			}
			//base.ExecuteNonQuery(#1j.#qf);
		}

		public void CollectOperatorPerformanceData(DateTime fromdate, DateTime todate)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(711), fromdate);
			}
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(732), todate);
			}
			//base.ExecuteNonQuery(#1j.#rf);
		}

		public void PurgeOperatorPerformanceData(DateTime fromdate, DateTime todate)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(711), fromdate);
			}
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(732), todate);
			}
			//base.ExecuteNonQuery(#1j.#sf);
		}

		public void CollectFinancialAuditData(DateTime fromdate, DateTime todate)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(711), fromdate);
			}
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(732), todate);
			}
			//base.ExecuteNonQuery(#1j.#tf);
		}

		public void PurgeFinancialAuditData(DateTime fromdate, DateTime todate)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(711), fromdate);
			}
			if (!false)
			{
				base.AddParameter(ReportDao.getReportAccess(732), todate);
			}
			//base.ExecuteNonQuery(#1j.#uf);
		}

		public ReportParams FetchReportFormatDetails(int reportType)
		{
			try
			{
				base.DBParameters.Clear();
				base.AddParameter(ReportDao.getReportAccess(26665), reportType);
				IDataReader dataReader;
				ReportParams reportParams;
				if (true)
				{
					dataReader = base.ExecuteReader(ReportDao.getReportAccess(26686));
					if (dataReader != null)
					{
						reportParams = new ReportParams();
						reportParams.ReportFormats = new Dictionary<string, string>();
						goto IL_D4;
					}
					goto IL_12F;
				}
				IL_A7:
				if (string.IsNullOrEmpty(reportParams.ReportType))
				{
					reportParams.ReportType = dataReader[ReportDao.getReportAccess(12466)].ToString();
				}
				IL_D4:
				if (!dataReader.Read())
				{
					return reportParams;
				}
				reportParams.ReportFormats.Add(dataReader[ReportDao.getReportAccess(26711)].ToString(), dataReader[ReportDao.getReportAccess(26728)].ToString());
				goto IL_A7;
			}
			catch (Exception)
			{
			}
			IL_12F:
			return null;
		}

		static ReportDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ReportDao));
		}
	}
}
