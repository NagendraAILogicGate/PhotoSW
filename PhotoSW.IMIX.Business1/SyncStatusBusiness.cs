using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class SyncStatusBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public SyncStatusBusiness ;

			public DateTime ;

			public DateTime ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SyncStatusBusiness. ;

			public List<SyncStatusInfo> ;

			public void ()
			{
				SyncStatusAccess syncStatusAccess = new SyncStatusAccess(this...Transaction);
				this. = syncStatusAccess.GetSyncStatus(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<SyncStatusInfo> ;

			public SyncStatusBusiness ;

			public DateTime? ;

			public DateTime? ;

			public void ()
			{
				if (4 != 0)
				{
					SyncStatusAccess syncStatusAccess = new SyncStatusAccess(this..Transaction);
					this. = syncStatusAccess.GetOrdersyncStatus(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public SyncStatusBusiness ;

			public string ;

			public void ()
			{
				do
				{
					SyncStatusAccess syncStatusAccess;
					if (!false)
					{
						syncStatusAccess = new SyncStatusAccess(this..Transaction);
					}
					this. = syncStatusAccess.ReSync(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public SyncStatusBusiness ;

			public string ;

			public void ()
			{
				do
				{
					SyncStatusAccess syncStatusAccess;
					if (!false)
					{
						syncStatusAccess = new SyncStatusAccess(this..Transaction);
					}
					this. = syncStatusAccess.ReSyncImage(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SyncStatusBusiness ;

			public DateTime ;

			public DateTime ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SyncStatusBusiness. ;

			public List<SyncStatusInfo> ;

			public void ()
			{
				SyncStatusAccess syncStatusAccess = new SyncStatusAccess(this...Transaction);
				this. = syncStatusAccess.GetSyncStatusOpenCloseForm(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public SyncStatusBusiness ;

			public DateTime ;

			public int ;

			public int ;

			public void ()
			{
				SyncStatusAccess syncStatusAccess = new SyncStatusAccess(this..Transaction);
				syncStatusAccess.InsertResyncHistory(this., this., this.);
			}
		}

		public List<SyncStatusInfo> GetSyncStatusList(DateTime FrmDate, DateTime ToDate)
		{
			SyncStatusBusiness.  = new SyncStatusBusiness.();
			List<SyncStatusInfo> result;
			do
			{
				. = FrmDate;
				if (!false)
				{
					. = ToDate;
					. = this;
					try
					{
						SyncStatusBusiness.  = new SyncStatusBusiness.();
						. = ;
						. = new List<SyncStatusInfo>();
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (6 != 0)
						{
							result = .;
						}
					}
					catch
					{
						do
						{
							result = null;
						}
						while (2 == 0);
					}
				}
			}
			while (3 == 0);
			return result;
		}

		public List<SyncStatusInfo> GetOrdersyncStatus(DateTime? FrmDate, DateTime? ToDate)
		{
			SyncStatusBusiness.  = new SyncStatusBusiness.();
			if (!false)
			{
				. = FrmDate;
				if (!false)
				{
					. = ToDate;
				}
			}
			do
			{
				if (-1 != 0)
				{
					. = this;
				}
				if (8 == 0)
				{
					goto IL_55;
				}
				. = new List<SyncStatusInfo>();
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_55:
			base.Start(false);
			return .;
		}

		public bool ReSync(string ReSyncId)
		{
			SyncStatusBusiness.  = new SyncStatusBusiness.();
			. = ReSyncId;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public bool ReSyncImages(string OrderId)
		{
			SyncStatusBusiness.  = new SyncStatusBusiness.();
			. = OrderId;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public List<SyncStatusInfo> GetFormSyncStatusList(DateTime FrmDate, DateTime ToDate)
		{
			SyncStatusBusiness.  = new SyncStatusBusiness.();
			List<SyncStatusInfo> result;
			do
			{
				. = FrmDate;
				if (!false)
				{
					. = ToDate;
					. = this;
					try
					{
						SyncStatusBusiness.  = new SyncStatusBusiness.();
						. = ;
						. = new List<SyncStatusInfo>();
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (6 != 0)
						{
							result = .;
						}
					}
					catch
					{
						do
						{
							result = null;
						}
						while (2 == 0);
					}
				}
			}
			while (3 == 0);
			return result;
		}

		public bool SetResyncHistory(DateTime ResyncDatetime, int ResyncStatus, int ResyncType)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			bool result;
			while (true)
			{
				SyncStatusBusiness.  = new SyncStatusBusiness.();
				. = ResyncDatetime;
				. = ResyncStatus;
				if (!false)
				{
					. = ResyncType;
					. = this;
					try
					{
						if (transactionMethod == null)
						{
							transactionMethod = new BaseBusiness.TransactionMethod(.);
						}
						this.operation = transactionMethod;
						bool arg_6A_0 = base.Start(false);
						if (6 != 0)
						{
							if (6 == 0)
							{
								goto IL_6B;
							}
							arg_6A_0 = true;
						}
						result = arg_6A_0;
						IL_6B:;
					}
					catch (Exception)
					{
						result = false;
					}
					if (3 != 0)
					{
						break;
					}
				}
			}
			return result;
		}
	}
}
