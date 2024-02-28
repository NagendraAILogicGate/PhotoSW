using PhotoSW.IMIX.DataAccess;
using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace PhotoSW.IMIX.Business
{
	public class SageBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public SageInfo ;

			public SageBusiness ;

			public int ;

			public void ()
			{
				do
				{
					SageInfoAccess sageInfoAccess;
					if (!false)
					{
						sageInfoAccess = new SageInfoAccess(this..Transaction);
					}
					this. = sageInfoAccess.GetOpenCloseProcDetail(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataTable ;

			public DataTable ;

			public string ;

			public SageBusiness ;

			public SageInfo ;

			public void ()
			{
				while (true)
				{
					SageInfoAccess sageInfoAccess;
					if (-1 != 0)
					{
						sageInfoAccess = new SageInfoAccess(this..Transaction);
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
					this. = sageInfoAccess.SaveOpeningForm(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataTable ;

			public DataTable ;

			public DataTable ;

			public bool ;

			public SageBusiness ;

			public SageOpenClose ;

			public void ()
			{
				SageInfoAccess sageInfoAccess = new SageInfoAccess(this..Transaction);
				this. = sageInfoAccess.SaveClosingForm(this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<SageInfoWestage> ;

			public SageBusiness ;

			public DateTime ;

			public DateTime ;

			public int ;

			public void ()
			{
				while (true)
				{
					SageInfoAccess sageInfoAccess;
					if (-1 != 0)
					{
						sageInfoAccess = new SageInfoAccess(this..Transaction);
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
					this. = sageInfoAccess.ProductTypeWestage(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;

			public SageBusiness ;

			public DateTime ;

			public DateTime ;

			public int ;

			public void ()
			{
				while (true)
				{
					SageInfoAccess sageInfoAccess;
					if (-1 != 0)
					{
						sageInfoAccess = new SageInfoAccess(this..Transaction);
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
					this. = sageInfoAccess.GetCaptureBySubStoreAndDateRange(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;

			public SageBusiness ;

			public DateTime ;

			public DateTime ;

			public int ;

			public void ()
			{
				while (true)
				{
					SageInfoAccess sageInfoAccess;
					if (-1 != 0)
					{
						sageInfoAccess = new SageInfoAccess(this..Transaction);
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
					this. = sageInfoAccess.GetPreviewBySubStoreAndDateRange(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public long ;

			public SageBusiness ;

			public DateTime ;

			public DateTime ;

			public int ;

			public void ()
			{
				while (true)
				{
					SageInfoAccess sageInfoAccess;
					if (-1 != 0)
					{
						sageInfoAccess = new SageInfoAccess(this..Transaction);
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
					this. = sageInfoAccess.GetTotalSoldBySubStoreAndDateRange(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ImixPOSDetail> ;

			public SageBusiness ;

			public int ;

			public void ()
			{
				do
				{
					SageInfoAccess sageInfoAccess;
					if (!false)
					{
						sageInfoAccess = new SageInfoAccess(this..Transaction);
					}
					this. = sageInfoAccess.GetPrintServerDetails(this.);
				}
				while (false);
			}
		}

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public SageInfo GetOpenCloseProcDetail(int SubStoreID)
		{
			SageBusiness.  = new SageBusiness.();
			. = SubStoreID;
			. = this;
			do
			{
				. = new SageInfo();
				new SageBusiness();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
			}
			while (false);
			return .;
		}

		public string SaveOpeningForm(SageInfo _sageInfo, List<Printer6850> lst6850Printer, List<Printer8810> lst8810Printer)
		{
			SageBusiness.  = new SageBusiness.();
			. = _sageInfo;
			. = this;
			CommonBusiness commonBusiness = new CommonBusiness();
			DataTable table = commonBusiness.CopyGenericToDataTable<Printer6850>(lst6850Printer);
			DataView dataView = new DataView(table);
			. = dataView.ToTable(SageBusiness.(4503), false, new string[]
			{
				SageBusiness.(4516),
				SageBusiness.(4533),
				SageBusiness.(4562)
			});
			DataTable table2 = commonBusiness.CopyGenericToDataTable<Printer8810>(lst8810Printer);
			DataView dataView2 = new DataView(table2);
			. = dataView2.ToTable(SageBusiness.(4503), false, new string[]
			{
				SageBusiness.(4516),
				SageBusiness.(4533),
				SageBusiness.(4562)
			});
			. = SageBusiness.(1828);
			new SageBusiness();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool SaveClosingForm(SageOpenClose objOpenClose, List<Printer6850> lst6850Printer, List<Printer8810> lst8810Printer)
		{
			SageBusiness.  = new SageBusiness.();
			. = objOpenClose;
			. = this;
			CommonBusiness commonBusiness = new CommonBusiness();
			DataTable table = commonBusiness.CopyGenericToDataTable<InventoryConsumables>(..objClose.InventoryConsumable);
			if (!false)
			{
				DataView dataView = new DataView(table);
				. = dataView.ToTable(SageBusiness.(4503), false, new string[]
				{
					SageBusiness.(4579),
					SageBusiness.(4596)
				});
			}
			DataTable table2 = commonBusiness.CopyGenericToDataTable<Printer6850>(lst6850Printer);
			DataView dataView2 = new DataView(table2);
			. = dataView2.ToTable(SageBusiness.(4503), false, new string[]
			{
				SageBusiness.(4516),
				SageBusiness.(4533),
				SageBusiness.(4562)
			});
			DataTable table3 = commonBusiness.CopyGenericToDataTable<Printer8810>(lst8810Printer);
			DataView dataView3 = new DataView(table3);
			. = dataView3.ToTable(SageBusiness.(4503), false, new string[]
			{
				SageBusiness.(4516),
				SageBusiness.(4533),
				SageBusiness.(4562)
			});
			. = false;
			new SageBusiness();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<SageInfoWestage> ProductTypeWestage(DateTime FromDate, DateTime ToDate, int SubStoreID)
		{
			SageBusiness.  = new SageBusiness.();
			. = FromDate;
			. = ToDate;
			. = SubStoreID;
			. = this;
			. = new List<SageInfoWestage>();
			new SageBusiness();
			this.operation = new BaseBusiness.TransactionMethod(.);
			do
			{
				if (6 != 0)
				{
					base.Start(false);
				}
			}
			while (false);
			return .;
		}

		public int GetCaptureBySubStoreAndDateRange(DateTime FromDate, DateTime ToDate, int SubStoreID)
		{
			SageBusiness.  = new SageBusiness.();
			. = FromDate;
			. = ToDate;
			. = SubStoreID;
			. = this;
			. = 0;
			new SageBusiness();
			this.operation = new BaseBusiness.TransactionMethod(.);
			do
			{
				if (6 != 0)
				{
					base.Start(false);
				}
			}
			while (false);
			return .;
		}

		public int GetPreviewBySubStoreAndDateRange(DateTime FromDate, DateTime ToDate, int SubStoreID)
		{
			SageBusiness.  = new SageBusiness.();
			. = FromDate;
			. = ToDate;
			. = SubStoreID;
			. = this;
			. = 0;
			new SageBusiness();
			this.operation = new BaseBusiness.TransactionMethod(.);
			do
			{
				if (6 != 0)
				{
					base.Start(false);
				}
			}
			while (false);
			return .;
		}

		public long GetTotalSoldBySubStoreAndDateRange(DateTime FromDate, DateTime ToDate, int SubStoreID)
		{
			SageBusiness. ;
			do
			{
				SageBusiness. expr_82 = new SageBusiness.();
				if (!false)
				{
					 = expr_82;
				}
				do
				{
					IL_0C:
					. = FromDate;
					. = ToDate;
					. = SubStoreID;
					do
					{
						. = this;
						if (false)
						{
							goto IL_0C;
						}
						. = 0L;
						new SageBusiness();
					}
					while (false);
				}
				while (false);
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
			}
			while (4 == 0);
			return .;
		}

		public List<ImixPOSDetail> GetPrintServerDetails(int SubStoreID)
		{
			SageBusiness.  = new SageBusiness.();
			. = SubStoreID;
			. = this;
			do
			{
				. = new List<ImixPOSDetail>();
				new SageBusiness();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
			}
			while (false);
			return .;
		}

		static SageBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(SageBusiness));
		}
	}
}
