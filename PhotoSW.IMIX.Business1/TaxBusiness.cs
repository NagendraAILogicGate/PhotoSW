using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class TaxBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public TaxBusiness ;

			public int ;

			public int ;

			public int ;

			public void ()
			{
				while (true)
				{
					TaxAccess taxAccess;
					if (-1 != 0)
					{
						taxAccess = new TaxAccess(this..Transaction);
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
					this. = taxAccess.SaveOrderTaxDetails(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public TaxBusiness ;

			public int ;

			public int ;

			public decimal ;

			public bool ;

			public DateTime ;

			public void ()
			{
				TaxAccess taxAccess = new TaxAccess(this..Transaction);
				this. = taxAccess.SaveTaxDetails(this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ObservableCollection<TaxDetailInfo> ;

			public TaxBusiness ;

			public void ()
			{
				TaxAccess taxAccess = new TaxAccess(this..Transaction);
				this. = taxAccess.GetTaxDetail();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<TaxDetailInfo> ;

			public TaxBusiness ;

			public int? ;

			public void ()
			{
				do
				{
					TaxAccess taxAccess;
					if (!false)
					{
						taxAccess = new TaxAccess(this..Transaction);
					}
					this. = taxAccess.GetTaxDetail(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<TaxDetailInfo> ;

			public TaxBusiness ;

			public DateTime ;

			public DateTime ;

			public int ;

			public void ()
			{
				while (true)
				{
					TaxAccess taxAccess;
					if (-1 != 0)
					{
						taxAccess = new TaxAccess(this..Transaction);
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
					this. = taxAccess.GetReportTaxDetail(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public TaxBusiness ;

			public StoreInfo ;

			public void ()
			{
				do
				{
					TaxAccess taxAccess;
					if (!false)
					{
						taxAccess = new TaxAccess(this..Transaction);
					}
					this. = taxAccess.UpdateStoreTaxData(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public StoreInfo ;

			public TaxBusiness ;

			public void ()
			{
				TaxAccess taxAccess = new TaxAccess(this..Transaction);
				this. = taxAccess.getTaxConfigData();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<TaxDetailInfo> ;

			public TaxBusiness ;

			public int ;

			public void ()
			{
				do
				{
					TaxAccess taxAccess;
					if (!false)
					{
						taxAccess = new TaxAccess(this..Transaction);
					}
					this. = taxAccess.GetApplicableTaxes(this.);
				}
				while (false);
			}
		}

		public bool SaveOrderTaxDetails(int StoreId, int OrderId, int SubStoreId)
		{
			TaxBusiness.  = new TaxBusiness.();
			do
			{
				. = StoreId;
				. = OrderId;
				if (8 == 0)
				{
					goto IL_60;
				}
			}
			while (false);
			. = SubStoreId;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_69_0 = base.Start(false);
			IL_5C:
			if (false)
			{
				goto IL_66;
			}
			IL_60:
			arg_69_0 = .;
			IL_66:
			if (!false)
			{
				return arg_69_0;
			}
			goto IL_5C;
		}

		public bool SaveTaxDetails(int VenueId, int TaxId, decimal TaxPercentage, bool Status, DateTime modifiedate)
		{
			TaxBusiness. ;
			if (!false)
			{
				if (-1 == 0)
				{
					goto IL_21;
				}
				TaxBusiness. expr_85 = new TaxBusiness.();
				if (true)
				{
					 = expr_85;
				}
			}
			if (6 == 0)
			{
				goto IL_5E;
			}
			. = VenueId;
			IL_21:
			. = TaxId;
			. = TaxPercentage;
			. = Status;
			. = modifiedate;
			. = this;
			. = false;
			IL_5E:
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_84_0 = base.Start(false);
			if (5 != 0 && !false)
			{
				arg_84_0 = .;
			}
			return arg_84_0;
		}

		public ObservableCollection<TaxDetailInfo> GetTaxDetail()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new ObservableCollection<TaxDetailInfo>();
				do
				{
					base.Operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public List<TaxDetailInfo> GetTaxDetail(int? orderId)
		{
			TaxBusiness.  = new TaxBusiness.();
			. = orderId;
			. = this;
			. = new List<TaxDetailInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<TaxDetailInfo> GetReportTaxDetail(DateTime FromDate, DateTime ToDate, int subStoreID)
		{
			TaxBusiness.  = new TaxBusiness.();
			. = FromDate;
			. = ToDate;
			. = subStoreID;
			. = this;
			. = new List<TaxDetailInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool UpdateStoreTaxData(StoreInfo store)
		{
			TaxBusiness.  = new TaxBusiness.();
			. = store;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public StoreInfo getTaxConfigData()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new StoreInfo();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public List<TaxDetailInfo> GetApplicableTaxes(int taxID)
		{
			TaxBusiness.  = new TaxBusiness.();
			. = taxID;
			. = this;
			. = new List<TaxDetailInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}
	}
}
