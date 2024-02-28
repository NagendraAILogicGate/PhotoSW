using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class RefundBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public RefundBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RefundBusiness. ;

			public RefundInfo ;

			public void ()
			{
				RefundDao refundDao = new RefundDao(this...Transaction);
				this. = refundDao.GetRefund(this..).FirstOrDefault<RefundInfo>();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RefundInfo ;

			public int ;

			public RefundBusiness ;

			public void ()
			{
				do
				{
					RefundDao refundDao;
					if (!false)
					{
						refundDao = new RefundDao(this..Transaction);
					}
					this. = refundDao.InsandDelRefundMasterData(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RefundBusiness ;

			public int ;

			public int ;

			public string ;

			public decimal? ;

			public string ;

			public void ()
			{
				do
				{
					if (true)
					{
						RefundDao refundDao = new RefundDao(this..Transaction);
						if (!false)
						{
							refundDao.SetRefundDetailsData(this., this., this., this., this.);
						}
					}
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<RefundInfo> ;

			public RefundBusiness ;

			public int ;

			public void ()
			{
				do
				{
					RefundDao refundDao;
					if (!false)
					{
						refundDao = new RefundDao(this..Transaction);
					}
					this. = refundDao.GetRefundedItems(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public RefundBusiness ;

			public void ()
			{
				BillFormatDao billFormatDao = new BillFormatDao(this..Transaction);
				this. = billFormatDao.GetBillFormat();
			}
		}

		public double GetOrderRefundedAmount(int Orderid)
		{
			RefundBusiness.  = new RefundBusiness.();
			. = Orderid;
			. = this;
			double result;
			try
			{
				RefundBusiness.  = new RefundBusiness.();
				. = ;
				. = new RefundInfo();
				double arg_9B_0;
				while (true)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					do
					{
						base.Start(false);
					}
					while (8 == 0);
					double arg_84_0;
					double num;
					if (. != null)
					{
						arg_84_0 = Convert.ToDouble(..RefundAmount);
					}
					else
					{
						double expr_8A = arg_84_0 = (arg_9B_0 = 0.0);
						if (true)
						{
							num = expr_8A;
							goto IL_97;
						}
						goto IL_98;
					}
					IL_84:
					num = arg_84_0;
					if (4 != 0)
					{
						goto IL_97;
					}
					continue;
					IL_98:
					if (!false)
					{
						break;
					}
					goto IL_84;
					IL_97:
					arg_9B_0 = (arg_84_0 = num);
					goto IL_98;
				}
				result = arg_9B_0;
			}
			catch (Exception)
			{
				do
				{
					result = 0.0;
				}
				while (3 == 0 || false);
			}
			return result;
		}

		public int SetRefundMasterData(int OrderId, decimal RefundAmount, DateTime RefundDate, int UserId)
		{
			RefundBusiness.  = new RefundBusiness.();
			do
			{
				. = this;
			}
			while (!true);
			. = new RefundInfo();
			..DG_OrderId = OrderId;
			..RefundAmount = decimal.Round(RefundAmount, 3, MidpointRounding.ToEven);
			do
			{
				..RefundDate = RefundDate;
				..UserId = UserId;
				. = 0;
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool SetRefundDetailsData(int DG_LineItemId, int DG_RefundMaster_ID, string PhotoId, decimal? refundprice, string reason)
		{
			while (true)
			{
				int ;
				int ;
				string ;
				decimal? ;
				while (true)
				{
					 = DG_LineItemId;
					 = DG_RefundMaster_ID;
					 = PhotoId;
					 = refundprice;
					if (6 == 0)
					{
						break;
					}
					if (true)
					{
						goto Block_1;
					}
				}
			}
			Block_1:
			2. = reason;
			2. = this;
			RefundDetailInfo refundDetailInfo = new RefundDetailInfo();
			refundDetailInfo.DG_LineItemId = new int?(2.);
			refundDetailInfo.DG_RefundMaster_ID = new int?(2.);
			do
			{
				refundDetailInfo.RefundPhotoId = 2.;
			}
			while (false);
			refundDetailInfo.Refunded_Amount = new decimal?(decimal.Round(Convert.ToDecimal(2.), 3, MidpointRounding.ToEven));
			refundDetailInfo.RefundReason = 2.;
			this.operation = new BaseBusiness.TransactionMethod(2.);
			base.Start(false);
			return true;
		}

		public List<RefundInfo> GetRefundedItems(int OrderId)
		{
			RefundBusiness.  = new RefundBusiness.();
			. = OrderId;
			. = this;
			. = new List<RefundInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public string GetRefundText()
		{
			RefundBusiness.  = new RefundBusiness.();
			. = this;
			. = string.Empty;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (. != null)
			{
				return .;
			}
			return null;
		}
	}
}
