using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class OrderBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public OrderBusiness ;

			public int ;

			public void ()
			{
				do
				{
					OrderAccess orderAccess;
					if (!false)
					{
						orderAccess = new OrderAccess(this..Transaction);
					}
					this. = orderAccess.GetOrderInvoiceNumber(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderDetailInfo ;

			public OrderBusiness ;

			public int ;

			public void ()
			{
				do
				{
					OrderDetailsDao orderDetailsDao;
					if (!false)
					{
						orderDetailsDao = new OrderDetailsDao(this..Transaction);
					}
					this. = orderDetailsDao.GetSemiOrderImage(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderBusiness. ;

			public OrderDetailsViewInfo ;

			public void ()
			{
				if (4 != 0)
				{
					OrderDetailsDao orderDetailsDao = new OrderDetailsDao(this...Transaction);
					if (!false)
					{
						this. = orderDetailsDao.SelectOrderDetailsByID(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderBusiness ;

			public int ;

			public bool ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderBusiness. ;

			public OrderDetailInfo ;

			public int ;

			public void ()
			{
				do
				{
					if (true)
					{
						OrderDetailsDao orderDetailsDao = new OrderDetailsDao(this...Transaction);
						if (7 == 0)
						{
							continue;
						}
						if (!false)
						{
							this. = orderDetailsDao.AddSemiOrderDetails(this., this.., this..);
						}
					}
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderDetailInfo ;

			public int ;

			public OrderBusiness ;

			public void ()
			{
				do
				{
					OrderDetailsDao orderDetailsDao;
					if (!false)
					{
						orderDetailsDao = new OrderDetailsDao(this..Transaction);
					}
					this. = orderDetailsDao.SetOrderDetails(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderInfo ;

			public OrderInfo ;

			public OrderBusiness ;

			public void ()
			{
				do
				{
					OrderDetailsDao orderDetailsDao;
					if (!false)
					{
						orderDetailsDao = new OrderDetailsDao(this..Transaction);
					}
					this. = orderDetailsDao.GenerateOrder(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;

			public OrderDetailInfo ;

			public OrderBusiness ;

			public void ()
			{
				do
				{
					OrderDetailsDao orderDetailsDao;
					if (!false)
					{
						orderDetailsDao = new OrderDetailsDao(this..Transaction);
					}
					this. = orderDetailsDao.InsetOrderLineItems(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<BurnOrderInfo> ;

			public OrderBusiness ;

			public bool ;

			public void ()
			{
				do
				{
					OrderDetailsDao orderDetailsDao;
					if (!false)
					{
						orderDetailsDao = new OrderDetailsDao(this..Transaction);
					}
					this. = orderDetailsDao.SelectPendingBurnOrders(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public OrderBusiness ;

			public int ;

			public int ;

			public void ()
			{
				while (true)
				{
					OrderDetailsDao orderDetailsDao = new OrderDetailsDao(this..Transaction);
					orderDetailsDao.UpdateBurnOrderStatus(this., this.);
					while (!false)
					{
						this. = true;
						if (!false)
						{
							if (false)
							{
								break;
							}
							if (5 != 0)
							{
								return;
							}
						}
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<BurnOrderInfo> ;

			public OrderBusiness ;

			public int ;

			public void ()
			{
				while (4 != 0 && 2 != 0)
				{
					OrderDetailsDao orderDetailsDao = new OrderDetailsDao(this..Transaction);
					if (7 != 0)
					{
						new List<OrderDetailInfo>();
						if (!false)
						{
							this. = orderDetailsDao.GetBODetailsByID(this.);
							break;
						}
						break;
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public OrderBusiness ;

			public int ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					OrderDetailsDao orderDetailsDao = new OrderDetailsDao(this..Transaction);
					this. = orderDetailsDao.UpdateBurnOrderStatus(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderBusiness ;

			public string ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderBusiness. ;

			public bool ;

			public void ()
			{
				OrderDetailsDao orderDetailsDao = new OrderDetailsDao(this...Transaction);
				this. = orderDetailsDao.UpdateCancelOrder(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<OrderDetailInfo> ;

			public OrderBusiness ;

			public string ;

			public void ()
			{
				do
				{
					OrderDetailsDao orderDetailsDao;
					if (!false)
					{
						orderDetailsDao = new OrderDetailsDao(this..Transaction);
					}
					this. = orderDetailsDao.GetOrderDetailsforRefund(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderInfo ;

			public OrderBusiness ;

			public string ;

			public void ()
			{
				do
				{
					OrderDetailsDao orderDetailsDao;
					if (!false)
					{
						orderDetailsDao = new OrderDetailsDao(this..Transaction);
					}
					this. = orderDetailsDao.GetOrder(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderBusiness ;

			public int? ;

			public string ;

			public int? ;

			public int ;

			public string ;

			public decimal ;

			public decimal ;

			public decimal ;

			public void ()
			{
				OrderDetailsDao orderDetailsDao = new OrderDetailsDao(this..Transaction);
				string[] array = this..Split(new char[]
				{
					','
				});
				for (int i = 0; i < array.Length; i++)
				{
					string text = array[i];
					if (text != null)
					{
						orderDetailsDao.UpdateSemiOrderImageOrderDetails(this., Convert.ToInt32(text), this., this., this., this., this., this.);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderDetailInfo ;

			public OrderBusiness ;

			public string ;

			public void ()
			{
				do
				{
					OrderDetailsDao orderDetailsDao;
					if (!false)
					{
						orderDetailsDao = new OrderDetailsDao(this..Transaction);
					}
					this. = orderDetailsDao.GetOrderDetailsByPhotoID(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public OrderBusiness ;

			public string ;

			public void ()
			{
				do
				{
					OrderDetailsDao orderDetailsDao;
					if (!false)
					{
						orderDetailsDao = new OrderDetailsDao(this..Transaction);
					}
					this. = orderDetailsDao.GetSemiOrderImageforValidation(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderBusiness ;

			public string ;

			public int ;

			public void ()
			{
				OrderDetailsDao expr_2D = new OrderDetailsDao(this..Transaction);
				OrderDetailsDao orderDetailsDao;
				if (!false)
				{
					orderDetailsDao = expr_2D;
				}
				orderDetailsDao.UpdatePostedOrder(this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderInfo ;

			public string ;

			public OrderBusiness ;

			public string ;

			[NonSerialized]
			internal static SmartAssembly.Delegates.GetString ;

			public void ()
			{
				OrderDetailsDao orderDetailsDao = new OrderDetailsDao(this..Transaction);
				this. = orderDetailsDao.GetOrdersNumber(this.);
				this. = Convert.ToDateTime(this..DG_Orders_Date).ToString(OrderBusiness..(3951));
			}

			static ()
			{
				// Note: this type is marked as 'beforefieldinit'.
				SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(OrderBusiness.));
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<OrderDetailInfo> ;

			public OrderBusiness ;

			public void ()
			{
				OrderDetailsDao orderDetailsDao = new OrderDetailsDao(this..Transaction);
				this. = orderDetailsDao.GetPhotoToUpload();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderReceiptReprintInfo ;

			public OrderBusiness ;

			public int ;

			public void ()
			{
				do
				{
					OrderAccess orderAccess;
					if (!false)
					{
						orderAccess = new OrderAccess(this..Transaction);
					}
					this. = orderAccess.GetOrderDetailForReceipt(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public OrderBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					OrderDetailsDao orderDetailsDao = new OrderDetailsDao(this...Transaction);
					if (!false)
					{
						this. = orderDetailsDao.chKIsWaterMarkedOrNot(this..);
					}
				}
			}
		}

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public string GetOrderInvoiceNumber(int OrderId)
		{
			OrderBusiness.  = new OrderBusiness.();
			. = OrderId;
			. = this;
			. = string.Empty;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool IsSemiOrderImage(int OrderDetailsID)
		{
			int expr_A4;
			while (true)
			{
				OrderBusiness.  = new OrderBusiness.();
				if (4 != 0)
				{
					. = OrderDetailsID;
					goto IL_1C;
				}
				IL_58:
				if (. == null)
				{
					goto IL_9D;
				}
				int arg_9B_0;
				bool expr_6E = (arg_9B_0 = (..DG_Orders_ID.HasValue ? 1 : 0)) != 0;
				if (!false)
				{
					if (!expr_6E)
					{
						goto IL_9D;
					}
					int? dG_Orders_ID = ..DG_Orders_ID;
					if (dG_Orders_ID.GetValueOrDefault() <= 0)
					{
						arg_9B_0 = (dG_Orders_ID.HasValue ? 1 : 0);
					}
					else
					{
						if (!true)
						{
							goto IL_50;
						}
						arg_9B_0 = 0;
					}
				}
				IL_9B:
				if (arg_9B_0 != 0)
				{
					goto IL_9D;
				}
				if (5 != 0)
				{
					return false;
				}
				continue;
				IL_95:
				goto IL_9B;
				IL_9D:
				if (8 == 0)
				{
					goto IL_1C;
				}
				expr_A4 = (arg_9B_0 = 1);
				if (expr_A4 != 0)
				{
					break;
				}
				goto IL_95;
				IL_50:
				base.Start(false);
				goto IL_58;
				IL_1C:
				. = this;
				. = new OrderDetailInfo();
				this.operation = new BaseBusiness.TransactionMethod(.);
				goto IL_50;
			}
			return expr_A4 != 0;
		}

		public OrderDetailsViewInfo GetOrderDetailsByID(int orderid)
		{
			if (!false)
			{
			}
			. = orderid;
			OrderDetailsViewInfo result;
			if (!false)
			{
				. = this;
				try
				{
					OrderBusiness.  = new OrderBusiness.();
					while (true)
					{
						. = ;
						. = new OrderDetailsViewInfo();
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (. != null || -1 == 0)
						{
							break;
						}
						if (!false)
						{
							goto Block_6;
						}
					}
					result = .;
					return result;
					Block_6:
					result = null;
				}
				catch (Exception)
				{
					if (!false)
					{
						result = null;
					}
				}
			}
			return result;
		}

		public int AddSemiOrderDetails(int? PhotoId, string ProductTypeId, int LocationId, string SyncCode, bool IsSentToPrinter, int SubStoreId)
		{
			OrderBusiness.  = new OrderBusiness.();
			. = LocationId;
			. = IsSentToPrinter;
			. = this;
			int result;
			try
			{
				OrderBusiness.  = new OrderBusiness.();
				. = ;
				if (!false)
				{
					. = new OrderDetailInfo();
					..DG_Photos_ID = PhotoId.ToString();
					..DG_Orders_Details_ProductType_pkey = new int?(Convert.ToInt32(ProductTypeId.Split(new char[]
					{
						','
					})[0]));
					..DG_Orders_Details_LineItem_ParentID = new int?(-1);
					..DG_Orders_LineItems_Quantity = new int?(1);
					..DG_Orders_Details_Items_TotalCost = new decimal?(0m);
					..DG_Orders_LineItems_DiscountAmount = new decimal?(0m);
					..SyncCode = SyncCode;
					..DG_Order_SubStoreId = new int?(SubStoreId);
					. = 0;
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				base.Start(false);
				result = .;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		public int SetOrderDetails(int? PhotoId, string ProductTypeId, int SubStoreId, string SyncCode)
		{
			int result;
			try
			{
				OrderBusiness. expr_16C = new OrderBusiness.();
				OrderBusiness. ;
				if (!false)
				{
					 = expr_16C;
				}
				. = this;
				. = new OrderDetailInfo();
				double productPricing;
				if (!false)
				{
					new CustomBusineses();
					ProductBusiness productBusiness = new ProductBusiness();
					..DG_Photos_ID = PhotoId.ToString();
					..DG_Orders_LineItems_Created = new DateTime?(DateTime.Now);
					..DG_Orders_Details_ProductType_pkey = new int?(Convert.ToInt32(ProductTypeId.Split(new char[]
					{
						','
					})[0]));
					..DG_Order_SubStoreId = new int?(SubStoreId);
					..DG_Orders_Details_LineItem_ParentID = new int?(-1);
					productPricing = productBusiness.GetProductPricing(ProductTypeId.ToInt32(false));
					..DG_Orders_Details_Items_UniPrice = new decimal?((decimal)productPricing);
					..DG_Orders_LineItems_Quantity = new int?(1);
				}
				..DG_Orders_Details_Items_TotalCost = new decimal?(0m);
				..DG_Orders_Details_Items_NetPrice = new decimal?((decimal)productPricing);
				..DG_Orders_LineItems_DiscountAmount = new decimal?(0m);
				..SyncCode = SyncCode;
				. = 0;
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				result = .;
			}
			catch (Exception)
			{
				do
				{
					if (6 != 0)
					{
						result = 0;
					}
				}
				while (2 == 0);
			}
			return result;
		}

		public OrderInfo GenerateOrder(string OrderNumber, decimal Ordercost, decimal OrderNetCost, string PaymentDetails, int PaymentMode, double TotalDiscount, string DiscountDetails, int UserID, int CurrencyId, string OrderMode, string SyncCode, string StoreCode)
		{
			OrderBusiness.  = new OrderBusiness.();
			. = this;
			. = new OrderInfo();
			CurrencyBusiness currencyBusiness = new CurrencyBusiness();
			new CustomBusineses();
			string empty = string.Empty;
			string systemName = this.getSystemName();
			. = new OrderInfo();
			..DG_Orders_Cost = new decimal?(decimal.Round(Ordercost, 3, MidpointRounding.ToEven));
			..DG_Orders_NetCost = new decimal?(decimal.Round(OrderNetCost, 3, MidpointRounding.ToEven));
			..DG_Orders_PaymentDetails = PaymentDetails;
			..DG_Orders_Currency_Conversion_Rate = empty;
			..DG_Orders_PaymentMode = new int?(PaymentMode);
			..DG_Orders_Total_Discount = new double?(decimal.Round(TotalDiscount.ToDecimal(false), 3, MidpointRounding.ToEven).ToDouble(false));
			..DG_Orders_Total_Discount_Details = DiscountDetails;
			..DG_Orders_UserID = new int?(UserID);
			..DG_Orders_Currency_ID = new int?(CurrencyId);
			..DG_Orders_Currency_Conversion_Rate = currencyBusiness.CurrentCurrencyConversionRate();
			..DG_Order_Mode = OrderMode;
			..DG_Orders_Date = new DateTime?(DateTime.Now);
			..DG_Orders_Number = OrderNumber;
			..SyncCode = SyncCode;
			..IsSynced = false;
			..DG_StoreCode = StoreCode;
			..PosName = systemName;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public int SaveOrderLineItems(int ProductType, int? OrderID, string PhotoId, int Qty, string DisCountDetails, decimal TotalDiscount, decimal UnitPrice, decimal TotalPrice, decimal NetPrice, int ParentID, int SubStoreID, int IdentifierType, string UniqueIdentifier, string SyncCode, string photoIDsUnsold, double? TaxPercent = null, decimal? TaxAmount = null, bool? IsTaxIncluded = null)
		{
			int result;
			try
			{
				OrderBusiness.  = new OrderBusiness.();
				. = this;
				. = 0;
				. = new OrderDetailInfo();
				..DG_Orders_ID = OrderID;
				..DG_Photos_ID = PhotoId;
				..DG_Orders_LineItems_Quantity = new int?(Qty);
				..DG_Orders_LineItems_DiscountType = DisCountDetails;
				..DG_Orders_LineItems_DiscountAmount = new decimal?(decimal.Round(TotalDiscount, 3, MidpointRounding.ToEven));
				..DG_Orders_LineItems_Created = new DateTime?(DateTime.Now);
				..DG_Orders_Details_ProductType_pkey = new int?(ProductType);
				..DG_Orders_Details_Items_UniPrice = new decimal?(decimal.Round(UnitPrice, 3, MidpointRounding.ToEven));
				..DG_Orders_Details_LineItem_ParentID = new int?(ParentID);
				..DG_Orders_Details_Items_TotalCost = new decimal?(decimal.Round(TotalPrice, 3, MidpointRounding.ToEven));
				..DG_Orders_Details_Items_NetPrice = new decimal?(decimal.Round(NetPrice, 3, MidpointRounding.ToEven));
				..DG_Order_SubStoreId = new int?(SubStoreID);
				..DG_Order_IdentifierType = new int?(IdentifierType);
				..DG_Order_ImageUniqueIdentifier = UniqueIdentifier;
				..SyncCode = SyncCode;
				..TaxAmount = TaxAmount;
				..TaxPercent = TaxPercent;
				..IsTaxIncluded = IsTaxIncluded;
				..DG_Photos_IDUnSold = photoIDsUnsold;
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				result = .;
			}
			catch (Exception)
			{
				result = -1;
			}
			return result;
		}

		public List<BurnOrderInfo> GetPendingBurnOrders(bool all)
		{
			OrderBusiness.  = new OrderBusiness.();
			. = all;
			. = this;
			. = new List<BurnOrderInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool UpdateBurnOrderStatus(int boId, int stat, int procBy, DateTime dateProcessed)
		{
			OrderBusiness.  = new OrderBusiness.();
			if (!false)
			{
				. = boId;
				if (!false)
				{
					. = stat;
				}
			}
			do
			{
				if (-1 != 0)
				{
					. = this;
				}
				if (8 == 0)
				{
					goto IL_4B;
				}
				. = false;
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_4B:
			base.Start(false);
			return .;
		}

		public List<BurnOrderInfo> GetBODetails(int boId)
		{
			OrderBusiness.  = new OrderBusiness.();
			. = boId;
			. = this;
			. = new List<BurnOrderInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool SetOrderDetailsForReprint(int LineItemId, int substoreID)
		{
			OrderBusiness.  = new OrderBusiness.();
			if (!false)
			{
				. = LineItemId;
				if (!false)
				{
					. = substoreID;
				}
			}
			do
			{
				if (-1 != 0)
				{
					. = this;
				}
				if (8 == 0)
				{
					goto IL_4B;
				}
				. = false;
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_4B:
			base.Start(false);
			return .;
		}

		public bool SetCancelOrder(string OrderNo, string CancelReason)
		{
			if (4 != 0)
			{
				string ;
				string ;
				while (4 != 0)
				{
					 = OrderNo;
					if (6 != 0)
					{
						 = CancelReason;
						break;
					}
				}
			}
			. = this;
			bool result;
			try
			{
				do
				{
				}
				while (7 == 0);
				. = ;
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_6F_0 = base.Start(false);
				if (!false)
				{
					arg_6F_0 = true;
				}
				result = arg_6F_0;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}

		public List<OrderDetailInfo> GetOrderDetailsforRefund(string OrderNo)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			OrderBusiness.  = new OrderBusiness.();
			. = OrderNo;
			. = this;
			. = new List<OrderDetailInfo>();
			List<OrderDetailInfo> result;
			try
			{
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
				if (. != null)
				{
					result = ..ToList<OrderDetailInfo>();
				}
				else
				{
					result = null;
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public OrderInfo GetOrder(string OrderNo)
		{
			OrderBusiness.  = new OrderBusiness.();
			. = OrderNo;
			. = this;
			. = new OrderInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool setSemiOrderImageOrderDetails(int? orderId, string imageNumber, int? parentId, int substorId, string discountType, decimal discountAmt, decimal totalCost, decimal netPrice)
		{
			OrderBusiness.  = new OrderBusiness.();
			do
			{
				. = orderId;
				if (-1 != 0)
				{
					. = imageNumber;
					. = parentId;
				}
				. = substorId;
				. = discountType;
				. = discountAmt;
				if (false)
				{
					return true;
				}
				. = totalCost;
				. = netPrice;
				. = this;
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return true;
		}

		public OrderDetailInfo GetSemiOrderImage(string photoId)
		{
			OrderBusiness.  = new OrderBusiness.();
			. = photoId;
			. = this;
			. = new OrderDetailInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool GetSemiOrderImageforValidation(string imageNumber)
		{
			OrderBusiness.  = new OrderBusiness.();
			. = imageNumber;
			if (false)
			{
				goto IL_3A;
			}
			. = this;
			IL_19:
			if (false)
			{
				goto IL_42;
			}
			. = false;
			new OrderDetailInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_3A:
			base.Start(false);
			IL_41:
			IL_42:
			if (false)
			{
				goto IL_19;
			}
			bool expr_46 = .;
			if (!false && !false)
			{
				return expr_46;
			}
			goto IL_41;
		}

		public void UpdatePostedOrder(string orderNumber, int Status)
		{
			OrderBusiness. ;
			if (!false)
			{
				OrderBusiness. expr_49 = new OrderBusiness.();
				if (!false)
				{
					 = expr_49;
				}
				. = orderNumber;
			}
			while (true)
			{
				. = Status;
				while (true)
				{
					if (!false)
					{
						. = this;
						this.operation = new BaseBusiness.TransactionMethod(.);
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

		public string GetOrderDateByOrderNo(string OrderNo)
		{
			OrderBusiness.  = new OrderBusiness.();
			if (!false)
			{
				. = OrderNo;
				if (!false)
				{
					. = this;
				}
			}
			do
			{
				if (-1 != 0)
				{
					. = new OrderInfo();
				}
				if (8 == 0)
				{
					goto IL_55;
				}
				. = string.Empty;
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_55:
			base.Start(false);
			return .;
		}

		public List<OrderDetailInfo> GetPhotoToUpload()
		{
			OrderBusiness. ;
			do
			{
				 = new OrderBusiness.();
				while (true)
				{
					. = this;
					if (!false)
					{
						. = new List<OrderDetailInfo>();
						if (-1 != 0)
						{
							this.operation = new BaseBusiness.TransactionMethod(.);
						}
						if (!false)
						{
							base.Start(false);
							if (. != null)
							{
								break;
							}
						}
					}
					if (4 != 0)
					{
						goto Block_5;
					}
				}
			}
			while (false);
			return ..ToList<OrderDetailInfo>();
			Block_5:
			return null;
		}

		public OrderReceiptReprintInfo GetOrderDetailForReceipt(int OrderId)
		{
			OrderBusiness.  = new OrderBusiness.();
			. = OrderId;
			. = this;
			. = null;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool chKIsWaterMarkedOrNot(int PackageID)
		{
			if (!false && -1 != 0)
			{
			}
			. = PackageID;
			. = this;
			bool result;
			try
			{
				OrderBusiness.  = new OrderBusiness.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public string getSystemName()
		{
			string result;
			try
			{
				ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(OrderBusiness.(2654), OrderBusiness.(2671));
				ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator();
				goto IL_3C;
				try
				{
					do
					{
						IL_3C:
						ManagementObject managementObject;
						while (true)
						{
							if (!enumerator.MoveNext())
							{
								if (!false)
								{
									goto Block_7;
								}
							}
							else if (5 != 0)
							{
								managementObject = (ManagementObject)enumerator.Current;
								if (!false)
								{
									break;
								}
							}
						}
						result = managementObject[OrderBusiness.(2724)].ToString();
					}
					while (false);
					return result;
					Block_7:;
				}
				finally
				{
					if (!false && enumerator != null)
					{
						((IDisposable)enumerator).Dispose();
					}
				}
				result = OrderBusiness.(886);
			}
			catch (Exception)
			{
				result = OrderBusiness.(886);
			}
			return result;
		}

		static OrderBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(OrderBusiness));
		}
	}
}
