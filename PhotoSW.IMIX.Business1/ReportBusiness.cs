using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class ReportBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public int ;

			public void ()
			{
				this. = new ActivityDao(this..Transaction).GetActivityReport(new DateTime?(this.), new DateTime?(this.), new int?(this.));
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public int ;

			public void ()
			{
				while (true)
				{
					ReportAccess reportAccess;
					if (-1 != 0)
					{
						reportAccess = new ReportAccess(this..Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					this. = reportAccess.GetPrintSummaryDetail(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public int ;

			public DateTime ;

			public DateTime ;

			public DateTime ;

			public DateTime ;

			public string ;

			public string ;

			public bool ;

			public void ()
			{
				ReportDao reportDao = new ReportDao(this..Transaction);
				this. = reportDao.SelectOperatorPerformanceReport(this., this., this., this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public DateTime? ;

			public DateTime? ;

			public int ;

			public void ()
			{
				while (true)
				{
					ReportDao reportDao;
					if (-1 != 0)
					{
						reportDao = new ReportDao(this..Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					this. = reportDao.SelectTakingReport(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public int ;

			public void ()
			{
				while (true)
				{
					ReportDao reportDao;
					if (-1 != 0)
					{
						reportDao = new ReportDao(this..Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					this. = reportDao.SelectOperationalAudit(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public DateTime ;

			public DateTime ;

			public string ;

			public string ;

			public bool ;

			public int ;

			public void ()
			{
				ReportDao reportDao = new ReportDao(this..Transaction);
				this. = reportDao.SelectLocationPerformance(this., this., this., this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public string ;

			public string ;

			public DateTime ;

			public DateTime ;

			public int ;

			public void ()
			{
				ReportDao reportDao = new ReportDao(this..Transaction);
				this. = reportDao.SelectFinancialAudit(this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public string ;

			public string ;

			public void ()
			{
				ReportDao reportDao = new ReportDao(this..Transaction);
				this. = reportDao.GetOrderDetailedDiscount(this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public DateTime ;

			public DateTime ;

			public string ;

			public string ;

			public bool ;

			public void ()
			{
				ReportDao expr_55 = new ReportDao(this..Transaction);
				ReportDao reportDao;
				if (!false)
				{
					reportDao = expr_55;
				}
				this. = reportDao.SelectPhotgrapherPerformance(this., this., this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public int ;

			public void ()
			{
				while (true)
				{
					ReportDao reportDao;
					if (-1 != 0)
					{
						reportDao = new ReportDao(this..Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					this. = reportDao.SelectPrintedProduct(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public int ;

			public void ()
			{
				while (true)
				{
					ReportDao reportDao;
					if (-1 != 0)
					{
						reportDao = new ReportDao(this..Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					this. = reportDao.GetPrintSummary(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public void ()
			{
				do
				{
					ReportDao reportDao;
					if (!false)
					{
						reportDao = new ReportDao(this..Transaction);
					}
					reportDao.CollectOrderDetailedDiscountData(this., this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public void ()
			{
				do
				{
					ReportDao reportDao;
					if (!false)
					{
						reportDao = new ReportDao(this..Transaction);
					}
					reportDao.PurgeOrderDetailedDiscountData(this., this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public void ()
			{
				do
				{
					ReportDao reportDao;
					if (!false)
					{
						reportDao = new ReportDao(this..Transaction);
					}
					reportDao.CollectActivityReportData(this., this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public void ()
			{
				do
				{
					ReportDao reportDao;
					if (!false)
					{
						reportDao = new ReportDao(this..Transaction);
					}
					reportDao.PurgeActivityReportData(this., this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public void ()
			{
				do
				{
					ReportDao reportDao;
					if (!false)
					{
						reportDao = new ReportDao(this..Transaction);
					}
					reportDao.CollectOperatorPerformanceData(this., this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public void ()
			{
				do
				{
					ReportDao reportDao;
					if (!false)
					{
						reportDao = new ReportDao(this..Transaction);
					}
					reportDao.PurgeOperatorPerformanceData(this., this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public void ()
			{
				do
				{
					ReportDao reportDao;
					if (!false)
					{
						reportDao = new ReportDao(this..Transaction);
					}
					reportDao.CollectFinancialAuditData(this., this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public void ()
			{
				do
				{
					ReportDao reportDao;
					if (!false)
					{
						reportDao = new ReportDao(this..Transaction);
					}
					reportDao.PurgeFinancialAuditData(this., this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PaymentSummaryInfo> ;

			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public string ;

			public void ()
			{
				while (true)
				{
					ReportAccess reportAccess;
					if (-1 != 0)
					{
						reportAccess = new ReportAccess(this..Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					this. = reportAccess.GetPaymentSummary(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public int ;

			public int ;

			public void ()
			{
				ReportDao reportDao = new ReportDao(this..Transaction);
				this. = reportDao.GetIPPrintTracking(this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataSet ;

			public ReportBusiness ;

			public DateTime ;

			public DateTime ;

			public int ;

			public int ;

			public void ()
			{
				ReportDao reportDao = new ReportDao(this..Transaction);
				this. = reportDao.GetIPContentTracking(this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ReportParams ;

			public ReportBusiness ;

			public int ;

			public void ()
			{
				do
				{
					ReportDao reportDao;
					if (!false)
					{
						reportDao = new ReportDao(this..Transaction);
					}
					this. = reportDao.FetchReportFormatDetails(this.);
				}
				while (false);
			}
		}

		public DataSet GetActivityReport(DateTime fromDate, DateTime toDate, int userId)
		{
			ReportBusiness.  = new ReportBusiness.();
			. = fromDate;
			. = toDate;
			. = userId;
			. = this;
			. = new DataSet();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public DataSet GetPrintSummaryDetail(DateTime from, DateTime to, int SubStoreId)
		{
			ReportBusiness.  = new ReportBusiness.();
			. = from;
			. = to;
			. = SubStoreId;
			. = this;
			. = new DataSet();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public DataSet GetOperatorReports(int CurrencyId, DateTime FromDate, DateTime ToDate, DateTime secfromDate, DateTime SecToDate, string StoreName, string UserName, bool Comparision)
		{
			if (3 == 0)
			{
				goto IL_66;
			}
			ReportBusiness.  = new ReportBusiness.();
			. = CurrencyId;
			. = FromDate;
			. = ToDate;
			. = secfromDate;
			. = SecToDate;
			IL_4E:
			. = StoreName;
			. = UserName;
			. = Comparision;
			IL_66:
			. = this;
			. = new DataSet();
			if (-1 != 0)
			{
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				return .;
			}
			goto IL_4E;
		}

		public DataSet GetTakingReport(bool ISFromDate, bool IsToDate, DateTime? FromDate, DateTime? ToDate, int UserID, int SubStorePKey)
		{
			ReportBusiness.  = new ReportBusiness.();
			. = FromDate;
			. = ToDate;
			. = SubStorePKey;
			. = this;
			. = new DataSet();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public DataSet GetAuditTrail(DateTime FromDate, DateTime ToDate, int SubStorePKey)
		{
			ReportBusiness.  = new ReportBusiness.();
			. = FromDate;
			. = ToDate;
			. = SubStorePKey;
			. = this;
			. = new DataSet();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public DataSet GetLocationPerformanceReports(DateTime FromDate, DateTime ToDate, DateTime secfromDate, DateTime SecToDate, string StoreName, string UserName, bool Comparision, string subStore, int SubStoreId)
		{
			if (3 == 0)
			{
				goto IL_66;
			}
			ReportBusiness.  = new ReportBusiness.();
			. = FromDate;
			. = ToDate;
			. = secfromDate;
			. = SecToDate;
			. = StoreName;
			IL_4E:
			. = UserName;
			. = Comparision;
			. = SubStoreId;
			IL_66:
			. = this;
			. = new DataSet();
			if (-1 != 0)
			{
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				return .;
			}
			goto IL_4E;
		}

		public DataSet GetFinancialAuditData(string username, string storename, DateTime startdat, DateTime enddate, int SubStoreId)
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
			2. = username;
			IL_1F:
			2. = storename;
			2. = startdat;
			2. = enddate;
			2. = SubStoreId;
			do
			{
				2. = this;
			}
			while (7 == 0);
			2. = new DataSet();
			IL_60:
			this.operation = new BaseBusiness.TransactionMethod(2.);
			base.Start(false);
			return 2.;
		}

		public DataSet GetOrderDetailReport(DateTime FromDate, DateTime ToDate, string StoreName, string UserName)
		{
			ReportBusiness. ;
			do
			{
				 = new ReportBusiness.();
				do
				{
					IL_0A:
					. = FromDate;
					. = ToDate;
					. = StoreName;
					do
					{
						. = UserName;
						if (false)
						{
							goto IL_0A;
						}
						. = this;
						if (!false)
						{
							. = new DataSet();
						}
					}
					while (false);
				}
				while (false);
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
			}
			while (4 == 0);
			return .;
		}

		public DataSet GetPhotographerPerformanceReports(DateTime FromDate, DateTime ToDate, DateTime secfromDate, DateTime SecToDate, string StoreName, string UserName, bool Comparision)
		{
			ReportBusiness.  = new ReportBusiness.();
			while (true)
			{
				if (!false)
				{
					. = FromDate;
					if (!false)
					{
						. = ToDate;
						. = secfromDate;
						goto IL_3D;
					}
					goto IL_8B;
				}
				IL_49:
				. = StoreName;
				. = UserName;
				. = Comparision;
				. = this;
				if (false)
				{
					continue;
				}
				. = new DataSet();
				if (!false)
				{
					break;
				}
				IL_3D:
				. = SecToDate;
				goto IL_49;
			}
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_8B:
			base.Start(false);
			return .;
		}

		public DataSet GetDataForPrintingLog(DateTime fromdate, DateTime todate, int SubStoreId)
		{
			ReportBusiness.  = new ReportBusiness.();
			. = fromdate;
			. = todate;
			. = SubStoreId;
			. = this;
			. = new DataSet();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public DataSet GetDataForPrintingSummary(DateTime fromdate, DateTime todate, int SubStoreId)
		{
			ReportBusiness.  = new ReportBusiness.();
			. = fromdate;
			. = todate;
			. = SubStoreId;
			. = this;
			. = new DataSet();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public void CollectOrderDetailedDiscountData(DateTime fromdate, DateTime todate)
		{
			ReportBusiness. ;
			if (!false)
			{
				ReportBusiness. expr_49 = new ReportBusiness.();
				if (!false)
				{
					 = expr_49;
				}
				. = fromdate;
			}
			while (true)
			{
				. = todate;
				while (true)
				{
					if (!false)
					{
						. = this;
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
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

		public void PurgeOrderDetailedDiscountData(DateTime fromdate, DateTime todate)
		{
			ReportBusiness. ;
			if (!false)
			{
				ReportBusiness. expr_49 = new ReportBusiness.();
				if (!false)
				{
					 = expr_49;
				}
				. = fromdate;
			}
			while (true)
			{
				. = todate;
				while (true)
				{
					if (!false)
					{
						. = this;
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
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

		public void CollectActivityReportData(DateTime fromdate, DateTime todate)
		{
			ReportBusiness. ;
			if (!false)
			{
				ReportBusiness. expr_49 = new ReportBusiness.();
				if (!false)
				{
					 = expr_49;
				}
				. = fromdate;
			}
			while (true)
			{
				. = todate;
				while (true)
				{
					if (!false)
					{
						. = this;
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
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

		public void PurgeActivityReportData(DateTime fromdate, DateTime todate)
		{
			ReportBusiness. ;
			if (!false)
			{
				ReportBusiness. expr_49 = new ReportBusiness.();
				if (!false)
				{
					 = expr_49;
				}
				. = fromdate;
			}
			while (true)
			{
				. = todate;
				while (true)
				{
					if (!false)
					{
						. = this;
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
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

		public void CollectOperatorPerformanceData(DateTime fromdate, DateTime todate)
		{
			ReportBusiness. ;
			if (!false)
			{
				ReportBusiness. expr_49 = new ReportBusiness.();
				if (!false)
				{
					 = expr_49;
				}
				. = fromdate;
			}
			while (true)
			{
				. = todate;
				while (true)
				{
					if (!false)
					{
						. = this;
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
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

		public void PurgeOperatorPerformanceData(DateTime fromdate, DateTime todate)
		{
			ReportBusiness. ;
			if (!false)
			{
				ReportBusiness. expr_49 = new ReportBusiness.();
				if (!false)
				{
					 = expr_49;
				}
				. = fromdate;
			}
			while (true)
			{
				. = todate;
				while (true)
				{
					if (!false)
					{
						. = this;
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
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

		public void CollectFinancialAuditData(DateTime fromdate, DateTime todate)
		{
			ReportBusiness. ;
			if (!false)
			{
				ReportBusiness. expr_49 = new ReportBusiness.();
				if (!false)
				{
					 = expr_49;
				}
				. = fromdate;
			}
			while (true)
			{
				. = todate;
				while (true)
				{
					if (!false)
					{
						. = this;
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
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

		public void PurgeFinancialAuditData(DateTime fromdate, DateTime todate)
		{
			ReportBusiness. ;
			if (!false)
			{
				ReportBusiness. expr_49 = new ReportBusiness.();
				if (!false)
				{
					 = expr_49;
				}
				. = fromdate;
			}
			while (true)
			{
				. = todate;
				while (true)
				{
					if (!false)
					{
						. = this;
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
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

		public List<PaymentSummaryInfo> GetPaymentSummary(DateTime FromDt, DateTime ToDt, string storeName)
		{
			ReportBusiness.  = new ReportBusiness.();
			. = FromDt;
			. = ToDt;
			. = storeName;
			. = this;
			. = new List<PaymentSummaryInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public DataSet GetDataForIPPrintTracking(DateTime fromdate, DateTime todate, int SubStoreId, int packageID)
		{
			ReportBusiness. ;
			do
			{
				 = new ReportBusiness.();
				do
				{
					IL_0A:
					. = fromdate;
					. = todate;
					. = SubStoreId;
					do
					{
						. = packageID;
						if (false)
						{
							goto IL_0A;
						}
						. = this;
						if (!false)
						{
							. = new DataSet();
						}
					}
					while (false);
				}
				while (false);
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
			}
			while (4 == 0);
			return .;
		}

		public DataSet GetDataForIPContentTracking(DateTime fromdate, DateTime todate, int SubStoreId, int packageID)
		{
			ReportBusiness. ;
			do
			{
				 = new ReportBusiness.();
				do
				{
					IL_0A:
					. = fromdate;
					. = todate;
					. = SubStoreId;
					do
					{
						. = packageID;
						if (false)
						{
							goto IL_0A;
						}
						. = this;
						if (!false)
						{
							. = new DataSet();
						}
					}
					while (false);
				}
				while (false);
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
			}
			while (4 == 0);
			return .;
		}

		public ReportParams FetchReportFormatDetails(int reportType)
		{
			ReportBusiness.  = new ReportBusiness.();
			. = reportType;
			. = this;
			. = new ReportParams();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}
	}
}
