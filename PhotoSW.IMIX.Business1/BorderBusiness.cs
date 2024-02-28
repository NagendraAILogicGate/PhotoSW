using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class BorderBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<BorderInfo> ;

			public BorderBusiness ;

			public void ()
			{
				BorderDao expr_2F = new BorderDao(this..Transaction);
				BorderDao borderDao;
				if (!false)
				{
					borderDao = expr_2F;
				}
				this. = borderDao.Select(null);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public BorderBusiness ;

			public int ;

			public void ()
			{
				do
				{
					BorderDao borderDao;
					if (!false)
					{
						borderDao = new BorderDao(this..Transaction);
					}
					this. = borderDao.Delete(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public BorderInfo ;

			public BorderBusiness ;

			public void ()
			{
				while (true)
				{
					BorderDao borderDao;
					if (!false)
					{
						borderDao = new BorderDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							borderDao.Add(this.);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}

			public void ()
			{
				while (true)
				{
					BorderDao borderDao;
					if (!false)
					{
						borderDao = new BorderDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							borderDao.Update(this.);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public BorderInfo ;

			public BorderBusiness ;

			public int ;

			public void ()
			{
				BorderDao expr_2E = new BorderDao(this..Transaction);
				BorderDao borderDao;
				if (!false)
				{
					borderDao = expr_2E;
				}
				this. = borderDao.Get(new int?(this.));
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<VideoOverlay> ;

			public BorderBusiness ;

			public void ()
			{
				BorderDao expr_2F = new BorderDao(this..Transaction);
				BorderDao borderDao;
				if (!false)
				{
					borderDao = expr_2F;
				}
				this. = borderDao.SelectVideoOverlay(null);
			}
		}

		public List<BorderInfo> GetBorderDetails()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					2. = this;
				}
				while (false);
				2. = new List<BorderInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(2.2);
				}
				while (2 == 0);
				base.Start(false);
			}
			return 2.;
		}

		public bool DeleteBorder(int borderId)
		{
			BorderBusiness.  = new BorderBusiness.();
			. = borderId;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public void SetBorderDetails(string Bordername, int productType, bool isactive, int borderid, string SyncCode, int userId)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			BaseBusiness.TransactionMethod transactionMethod2 = null;
			BorderBusiness.  = new BorderBusiness.();
			. = this;
			. = new BorderInfo();
			..DG_Border = Bordername;
			..DG_ProductTypeID = productType;
			..DG_IsActive = isactive;
			..SyncCode = SyncCode;
			..IsSynced = false;
			..DG_Borders_pkey = borderid;
			if (borderid <= 0)
			{
				..CreatedBy = new int?(userId);
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				return;
			}
			..ModifiedBy = new int?(userId);
			if (transactionMethod2 == null)
			{
				transactionMethod2 = new BaseBusiness.TransactionMethod(.);
			}
			this.operation = transactionMethod2;
			do
			{
				base.Start(false);
			}
			while (3 == 0);
		}

		public BorderInfo GetBorderNameFromID(int id)
		{
			BorderBusiness.  = new BorderBusiness.();
			. = id;
			. = this;
			. = new BorderInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<VideoOverlay> GetVideoOverlays()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<VideoOverlay>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}
	}
}
