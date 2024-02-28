//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class ReportAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getReportAccess;
        public ReportAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public ReportAccess()
		{
		}

		public DataSet GetPrintSummaryDetail(DateTime from, DateTime To, int SubStoreID)
		{
			while (true)
			{
				if (7 != 0 && !false)
				{
					base.DBParameters.Clear();
					goto IL_12;
				}
				IL_35:
				base.AddParameter(ReportAccess.getReportAccess(1171), To);
				if (!false)
				{
					base.AddParameter(ReportAccess.getReportAccess(1561), SubStoreID);
					if (4 != 0)
					{
						break;
					}
					continue;
				}
				IL_12:
				base.AddParameter(ReportAccess.getReportAccess(1150), from);
				goto IL_35;
			}
			return base.ExecuteDataSet("");
		}

		private List<PrintSummaryDetail> PrintSummaryDetailok ( IDataReader IDataReader )
		{
			List<PrintSummaryDetail> list = new List<PrintSummaryDetail>();
			while (true)
			{
				while (IDataReader.Read())
				{
					PrintSummaryDetail printSummaryDetail = new PrintSummaryDetail();
					if (7 != 0)
					{
						printSummaryDetail.SaleType = base.GetFieldValue(IDataReader, ReportAccess.getReportAccess(50634), string.Empty);
						printSummaryDetail.PhotoNumbers = base.GetFieldValue(IDataReader, ReportAccess.getReportAccess(50647), string.Empty);
						list.Add(printSummaryDetail);
					}
				}
				break;
			}
			return list;
		}

		public List<PaymentSummaryInfo> GetPaymentSummary(DateTime FromDt, DateTime ToDt, string storeName)
		{
			while (true)
			{
				base.DBParameters.Clear();
				base.AddParameter(ReportAccess.getReportAccess(50664), FromDt);
				base.AddParameter(ReportAccess.getReportAccess(50673), ToDt);
				while (8 != 0)
				{
					base.AddParameter(ReportAccess.getReportAccess(50678), storeName);
					if (8 != 0)
					{
						goto Block_1;
					}
				}
			}
			Block_1:
			IDataReader dataReader = base.ExecuteReader(ReportAccess.getReportAccess(50695));
			List<PaymentSummaryInfo> result = this.PaymentSummaryInfopk(dataReader);
			dataReader.Close();
			return result;
		}

		private List<PaymentSummaryInfo> PaymentSummaryInfopk ( IDataReader IDataReader)
		{
			List<PaymentSummaryInfo> expr_8E1 = new List<PaymentSummaryInfo>();
			List<PaymentSummaryInfo> list;
			if (!false)
			{
				list = expr_8E1;
			}
			while (IDataReader.Read())
			{
				list.Add(new PaymentSummaryInfo
				{
					StoreId = base.GetFieldValue(IDataReader, ReportAccess.getReportAccess(50724), -2147483648),
					StoreName = base.GetFieldValue(IDataReader, ReportAccess.getReportAccess(26332), string.Empty),
					StoreCardSale = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(50737)]),
					StoreCashSale = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(50758)]),
					StoreDiscountSale = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(50779)]),
					StoreRoomChargeSale = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(50804)]),
					FC = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(50833)]),
					//StoreId = base.GetFieldValue(IDataReader, ReportAccess.getReportAccess(2967), -2147483648),
					SubStoreName = base.GetFieldValue(IDataReader, ReportAccess.getReportAccess(29662), string.Empty),
					SubStoreCardSale = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(50838)]),
					SubStoreCashSale = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(50863)]),
					SubStoreDiscountSale = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(50888)]),
					SubStoreRoomChargeSale = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(50917)]),
					SubStoreFC = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(50950)]),
					Productcode = base.GetFieldValue(IDataReader, ReportAccess.getReportAccess(50967), string.Empty),
					TotalCost = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(49286)]),
					Quantity = base.GetFieldValue(IDataReader, ReportAccess.getReportAccess(26405), -2147483648),
					ProductUnitPrice = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(50984)]),
					Tax = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(51009)]),
					DiscountAmount = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(51014)]),
					NetPrice = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(51035)]),
					FromDate = Convert.ToDateTime(IDataReader[ReportAccess.getReportAccess(26722)]),
					ToDate = Convert.ToDateTime(IDataReader[ReportAccess.getReportAccess(26735)]),
					ConSubStoreName = Convert.ToString(IDataReader[ReportAccess.getReportAccess(51048)]),
					SubStoreCashTransactionCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51069)]),
					SubStoreCCTransactionCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51110)]),
					TotalSubStoreFCTransactionCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51147)]),
					SubStoreDiscountedVoucherTransactionCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51192)]),
					SubstoreRoomChargeTransactionCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51249)]),
					TotalStoreSale = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(51298)]),
					TotalStoreSaleTransactionCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51319)]),
					StoreVoidSale = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(51360)]),
					StoreVoidSaleTransactionCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51381)]),
					StoreCashSaleTransactionsCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51422)]),
					StoreCardSaleTransactionsCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51463)]),
					StoreDiscountSaleTransactionsCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51504)]),
					StoreRoomChargeSaleTransactionsCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51553)]),
					FCStoreTransactionCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51602)]),
					SubStoreVoidSaleTransactionCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51635)]),
					SubStoreVoidSale = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(51680)]),
					KVLStoreTransactionCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51705)]),
					KVLStoreTransactionAmount = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(51738)]),
					SubStoreKVLTransactionCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51775)]),
					SubStoreKVLTransactionAmount = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(51812)]),
					TotalSubStoreSaleTransactionCount = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(51853)]),
					StoreCardSaleVoid = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(51898)]),
					StoreCashSaleVoid = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(51923)]),
					StoreDiscountSaleVoid = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(51948)]),
					StoreRoomChargeSaleVoid = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(51977)]),
					FCVoid = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(52010)]),
					KVLStoreTransactionAmountVoid = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(52019)]),
					StoreCashSaleTransactionsCountVoid = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(52060)]),
					StoreCardSaleTransactionsCountVoid = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(52109)]),
					StoreDiscountSaleTransactionsCountVoid = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(52158)]),
					StoreRoomChargeSaleTransactionsCountVoid = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(52211)]),
					FCStoreTransactionCountVoid = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(52268)]),
					KVLStoreTransactionCountVoid = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(52305)]),
					SubStoreCardSaleVoid = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(52346)]),
					SubStoreCashSaleVoid = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(52375)]),
					SubStoreDiscountSaleVoid = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(52404)]),
					SubStoreRoomChargeSaleVoid = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(52437)]),
					SubStoreFCVoid = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(52474)]),
					SubStoreKVLTransactionAmountVoid = Convert.ToDecimal(IDataReader[ReportAccess.getReportAccess(52495)]),
					SubStoreCashTransactionCountVoid = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(52540)]),
					SubStoreCCTransactionCountVoid = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(52585)]),
					TotalSubStoreFCTransactionCountVoid = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(52626)]),
					SubStoreDiscountedVoucherTransactionCountVoid = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(52675)]),
					SubstoreRoomChargeTransactionCountVoid = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(52736)]),
					SubStoreKVLTransactionCountVoid = Convert.ToInt32(IDataReader[ReportAccess.getReportAccess(52789)])
				});
			}
			return list;
		}

		static ReportAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ReportAccess));
		}
	}
}
