using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using ErrorHandler;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class BackgroundBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<BackGroundInfo> ;

			public BackgroundBusiness ;

			public void ()
			{
				BackGroundDao backGroundDao = new BackGroundDao(this..Transaction);
				this. = backGroundDao.GetBackgroundByGroup();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<BackGroundInfo> ;

			public BackgroundBusiness ;

			public int ;

			public void ()
			{
				BackGroundDao backGroundDao = new BackGroundDao(this..Transaction);
				this. = backGroundDao.Select(null, this., 0, string.Empty);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<BackGroundInfo> ;

			public BackgroundBusiness ;

			public void ()
			{
				while (true)
				{
					BackGroundDao backGroundDao;
					if (-1 != 0)
					{
						backGroundDao = new BackGroundDao(this..Transaction);
						goto IL_10;
					}
					IL_2C:
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
					this. = backGroundDao.Select(null, 0, 0, string.Empty);
					goto IL_2C;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public BackGroundInfo ;

			public BackgroundBusiness ;

			public string ;

			public void ()
			{
				BackGroundDao backGroundDao = new BackGroundDao(this..Transaction);
				this. = backGroundDao.Get(null, 0, 0, this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public BackGroundInfo ;

			public BackgroundBusiness ;

			public void ()
			{
				BackGroundDao expr_2E = new BackGroundDao(this..Transaction);
				BackGroundDao backGroundDao;
				if (!false)
				{
					backGroundDao = expr_2E;
				}
				this..DG_Background_pkey = backGroundDao.Add(this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public BackGroundInfo ;

			public BackgroundBusiness ;

			public int ;

			public int ;

			public string ;

			public void ()
			{
				BackGroundDao backGroundDao = new BackGroundDao(this..Transaction);
				this. = backGroundDao.Get(new int?(this.), this., 0, string.Empty);
			}

			public void ()
			{
				while (true)
				{
					BackGroundDao backGroundDao;
					if (!false)
					{
						backGroundDao = new BackGroundDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							backGroundDao.Update(this.);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}

			public void ()
			{
				do
				{
					this..SyncCode = this.;
					BackGroundDao backGroundDao = new BackGroundDao(this..Transaction);
					do
					{
						if (!false)
						{
							backGroundDao.Add(this.);
						}
					}
					while (false);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public BackgroundBusiness ;

			public int ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public BackgroundBusiness. ;

			public BackGroundInfo ;

			public void ()
			{
				BackGroundDao backGroundDao = new BackGroundDao(this...Transaction);
				this. = backGroundDao.Get(new int?(this..), this.., 0, string.Empty);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public BackgroundBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public BackgroundBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					BackGroundDao backGroundDao = new BackGroundDao(this...Transaction);
					if (!false)
					{
						this. = backGroundDao.Delete(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public BackGroundInfo ;

			public BackgroundBusiness ;

			public int ;

			public BackGroundInfo ;

			public void ()
			{
				BackGroundDao backGroundDao = new BackGroundDao(this..Transaction);
				this. = backGroundDao.Get(new int?(this..DG_Background_pkey), this., 0, string.Empty);
			}

			public void ()
			{
				while (true)
				{
					BackGroundDao backGroundDao;
					if (!false)
					{
						backGroundDao = new BackGroundDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							backGroundDao.Update(this.);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}
		}

		public List<BackGroundInfo> GetBackgoundDetails()
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
				2. = new List<BackGroundInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(2.2);
				}
				while (2 == 0);
				base.Start(false);
			}
			return 2.;
		}

		public List<BackGroundInfo> GetBackgoundDetails(int productId)
		{
			BackgroundBusiness.  = new BackgroundBusiness.();
			. = productId;
			. = this;
			. = new List<BackGroundInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<BackGroundInfo> GetBackgoundDetailsALL()
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
				. = new List<BackGroundInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public int GetProductTypeforBackgorund(string bakgroundName)
		{
			BackgroundBusiness.  = new BackgroundBusiness.();
			. = bakgroundName;
			. = this;
			. = new BackGroundInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (. != null)
			{
				return ..DG_Product_Id;
			}
			return 0;
		}

		public int SetBackGroundDetails(int productid, string backgroundname, string backgrounddisplayname, string SyncCode, bool isActive, int loggedinUser)
		{
			BackgroundBusiness.  = new BackgroundBusiness.();
			. = this;
			. = new BackGroundInfo();
			..DG_BackGround_Image_Name = backgroundname;
			..DG_BackGround_Image_Display_Name = backgrounddisplayname;
			..DG_Product_Id = productid;
			..SyncCode = SyncCode;
			..IsSynced = false;
			..DG_Background_IsActive = new bool?(isActive);
			..CreatedBy = new int?(loggedinUser);
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return ..DG_Background_pkey;
		}

		public void SetBackGroundDetails(int productid, string backgroundname, string backgrounddisplayname, int bgid, string SyncCode, bool? isActive, int loggedinuser)
		{
			if (2 == 0)
			{
				goto IL_7A;
			}
			BaseBusiness.TransactionMethod transactionMethod = null;
			BaseBusiness.TransactionMethod transactionMethod2 = null;
			BackgroundBusiness.  = new BackgroundBusiness.();
			. = productid;
			. = bgid;
			. = SyncCode;
			IL_43:
			. = this;
			. = new BackGroundInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (. == null)
			{
				return;
			}
			IL_7A:
			..DG_BackGround_Image_Name = backgroundname;
			..DG_BackGround_Image_Display_Name = backgrounddisplayname;
			..DG_Product_Id = .;
			do
			{
				..DG_BackGround_Group_Id = new int?(.);
				..IsSynced = false;
				if (false)
				{
					goto IL_43;
				}
				..DG_Background_IsActive = isActive;
				..ModifiedBy = new int?(loggedinuser);
				if (..DG_Background_pkey <= 0)
				{
					goto IL_11B;
				}
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
			}
			while (false);
			base.Start(false);
			return;
			IL_11B:
			if (transactionMethod2 == null)
			{
				transactionMethod2 = new BaseBusiness.TransactionMethod(.);
			}
			this.operation = transactionMethod2;
			base.Start(false);
		}

		public string GetBackGroundFileName(int productId, int BgGroupId)
		{
			if (2 != 0)
			{
			}
			do
			{
				. = BgGroupId;
			}
			while (false);
			. = this;
			string result;
			try
			{
				BackgroundBusiness.  = new BackgroundBusiness.();
				. = ;
				. = new BackGroundInfo();
				this.operation = new BaseBusiness.TransactionMethod(.);
				if (!false)
				{
					base.Start(false);
					if (. != null)
					{
						result = ..DG_BackGround_Image_Name;
					}
					else
					{
						result = null;
					}
				}
			}
			catch (Exception serviceException)
			{
				string message = ErrorHandler.CreateErrorMessage(serviceException);
				ErrorHandler.LogFileWrite(message);
				result = null;
			}
			return result;
		}

		public bool DeleteBackGround(int bgID)
		{
			if (!false && -1 != 0)
			{
			}
			. = bgID;
			. = this;
			bool result;
			try
			{
				BackgroundBusiness.  = new BackgroundBusiness.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public void UpdateBackgroundDetails(int productid, string syncCode, BackGroundInfo backgroundInfo)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			do
			{
				if (2 == 0)
				{
					goto IL_34;
				}
			}
			while (false);
			. = backgroundInfo;
			IL_34:
			. = this;
			. = new BackGroundInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (. != null)
			{
				..DG_BackGround_Image_Name = ..DG_BackGround_Image_Name;
				..DG_BackGround_Image_Display_Name = ..DG_BackGround_Image_Display_Name;
				do
				{
					..DG_Product_Id = .;
					..DG_BackGround_Group_Id = ..DG_BackGround_Group_Id;
					..IsSynced = ..IsSynced;
				}
				while (false);
				..DG_Background_IsActive = ..DG_Background_IsActive;
				..ModifiedBy = ..ModifiedBy;
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
			}
		}
	}
}
