using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using ErrorHandler;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class CalenderBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<ItemTemplateDetailModel> ;

			public CalenderBusiness ;

			public void ()
			{
				CalenderDao calenderDao = new CalenderDao(this..Transaction);
				this. = calenderDao.GetItemTemplateDetail();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<ItemTemplateMasterModel> ;

			public CalenderBusiness ;

			public void ()
			{
				CalenderDao calenderDao = new CalenderDao(this..Transaction);
				this. = calenderDao.GetItemTemplateMaster();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CalenderBusiness ;

			public ItemTemplatePrintOrderModel ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CalenderBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					CalenderDao calenderDao = new CalenderDao(this...Transaction);
					if (!false)
					{
						this. = calenderDao.AddItemTemplatePrintOrder(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CalenderBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CalenderBusiness. ;

			public List<ItemTemplateDetailModel> ;

			public void ()
			{
				if (4 != 0)
				{
					CalenderDao calenderDao = new CalenderDao(this...Transaction);
					if (!false)
					{
						this. = calenderDao.GetTemplatePath(this..);
					}
				}
			}
		}

		public List<ItemTemplateDetailModel> GetItemTemplateDetail()
		{
			List<ItemTemplateDetailModel> result;
			try
			{
				CalenderBusiness.  = new CalenderBusiness.();
				if (4 == 0)
				{
					goto IL_40;
				}
				. = this;
				do
				{
					IL_10:
					. = new List<ItemTemplateDetailModel>();
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
				while (7 == 0);
				result = .;
				IL_40:
				if (false)
				{
					goto IL_10;
				}
			}
			catch (Exception serviceException)
			{
				if (6 != 0)
				{
					ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
					result = null;
				}
			}
			return result;
		}

		public List<ItemTemplateMasterModel> GetItemTemplateMaster()
		{
			List<ItemTemplateMasterModel> result;
			try
			{
				CalenderBusiness.  = new CalenderBusiness.();
				if (4 == 0)
				{
					goto IL_40;
				}
				. = this;
				do
				{
					IL_10:
					. = new List<ItemTemplateMasterModel>();
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
				while (7 == 0);
				result = .;
				IL_40:
				if (false)
				{
					goto IL_10;
				}
			}
			catch (Exception serviceException)
			{
				if (6 != 0)
				{
					ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
					result = null;
				}
			}
			return result;
		}

		public bool AddItemTemplatePrintOrder(ItemTemplatePrintOrderModel obj)
		{
			CalenderBusiness.  = new CalenderBusiness.();
			. = obj;
			. = this;
			bool result;
			try
			{
				CalenderBusiness.  = new CalenderBusiness.();
				do
				{
					. = ;
					if (4 != 0)
					{
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (false)
						{
							goto IL_68;
						}
						if (!false)
						{
							base.Start(false);
						}
					}
					if (false)
					{
						continue;
					}
					result = .;
					IL_68:;
				}
				while (6 == 0);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
				result = false;
			}
			return result;
		}

		public List<ItemTemplateDetailModel> GetItemTemplatePath(int Id)
		{
			CalenderBusiness.  = new CalenderBusiness.();
			. = Id;
			. = this;
			List<ItemTemplateDetailModel> result;
			try
			{
				CalenderBusiness.  = new CalenderBusiness.();
				do
				{
					. = ;
					if (4 != 0)
					{
						. = new List<ItemTemplateDetailModel>();
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (false)
						{
							goto IL_6C;
						}
						if (!false)
						{
							base.Start(false);
						}
					}
					if (false)
					{
						continue;
					}
					result = .;
					IL_6C:;
				}
				while (6 == 0);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
				result = null;
			}
			return result;
		}
	}
}
