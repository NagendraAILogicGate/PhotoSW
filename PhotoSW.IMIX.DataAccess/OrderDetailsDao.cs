//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class OrderDetailsDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getOrderDetails;
        public OrderDetailsDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public OrderDetailsDao()
		{
		}

		public List<OrderDetailInfo> Get(int ProductType_pkey, int Date)
		{
			base.DBParameters.Clear();
			IDataReader dataReader;
			if (8 != 0)
			{
				dataReader = base.ExecuteReader("");
			}
			List<OrderDetailInfo> result = this.orderDetailInfo(dataReader);
			dataReader.Close();
			return result;
		}

		private List<OrderDetailInfo> orderDetailInfo ( IDataReader dataReader)
		{
			List<OrderDetailInfo> list = new List<OrderDetailInfo>();
			while (true)
			{
				OrderDetailInfo orderDetailInfo;
				if (!dataReader.Read())
				{
					if (7 != 0)
					{
						break;
					}
				}
				else
				{
					orderDetailInfo = new OrderDetailInfo();
				}
				orderDetailInfo.DG_Orders_pkey = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16624), 0);
				if (true)
				{
					orderDetailInfo.DG_Orders_Number = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16645), string.Empty);
					orderDetailInfo.DG_Orders_Date = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16670), DateTime.Now);
					orderDetailInfo.DG_Orders_LineItems_pkey = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16691), 0);
					if (4 != 0)
					{
						orderDetailInfo.DG_Orders_ID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16724), 0));
						orderDetailInfo.DG_Photos_ID = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(15034), string.Empty);
					}
					if (true)
					{
						orderDetailInfo.DG_Orders_Details_ProductType_pkey = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16741), 0));
						orderDetailInfo.DG_Order_Status = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16790), 0));
					}
				}
				OrderDetailInfo item = orderDetailInfo;
				list.Add(item);
			}
			return list;
		}

		public List<OrderDetailInfo> GetOrderDetailsforRefund(string Orders_Number)
		{
			IDataReader dataReader;
			List<OrderDetailInfo> result;
			while (-1 != 0)
			{
				base.DBParameters.Clear();
				if (false)
				{
					break;
				}
				base.AddParameter(OrderDetailsDao.getOrderDetails(16811), Orders_Number);
				if (8 != 0)
				{
					if (!false)
					{
						dataReader = base.ExecuteReader("");
						result = this.orderDetailInfo2(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private List<OrderDetailInfo> orderDetailInfo2 ( IDataReader dataReader)
		{
			List<OrderDetailInfo> list = new List<OrderDetailInfo>();
			while (dataReader.Read())
			{
				OrderInfo orderInfo;
				OrderDetailInfo orderDetailInfo;
				do
				{
					OrderInfo expr_445 = new OrderInfo();
					if (4 != 0)
					{
						orderInfo = expr_445;
					}
					orderDetailInfo = new OrderDetailInfo();
					orderDetailInfo.DG_Orders_LineItems_pkey = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16691), 0);
					orderDetailInfo.DG_Orders_ID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16724), 0));
					orderDetailInfo.DG_Photos_ID = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(15034), string.Empty);
					orderDetailInfo.DG_Orders_LineItems_Quantity = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16840), 0));
				}
				while (false);
				orderDetailInfo.TotalQuantity = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16881), 0L);
				orderDetailInfo.DG_Orders_LineItems_Created = new DateTime?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16902), DateTime.Now));
				orderDetailInfo.DG_Orders_LineItems_DiscountType = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16939), string.Empty);
				orderDetailInfo.DG_Orders_LineItems_DiscountAmount = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16984), 0.0m));
				orderDetailInfo.DG_Orders_Details_Items_UniPrice = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17033), 0.0m));
				orderDetailInfo.DG_Orders_Details_Items_TotalCost = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17078), 0.0m));
				orderDetailInfo.DG_Orders_Details_Items_NetPrice = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17123), 0.0m));
				orderDetailInfo.DG_Orders_Details_ProductType_pkey = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16741), 0));
				orderDetailInfo.DG_Orders_Details_LineItem_ParentID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17168), 0));
				orderDetailInfo.DG_Orders_Details_LineItem_PrinterReferenceID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17217), 0));
				orderDetailInfo.DG_Orders_Number = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16645), string.Empty);
				orderDetailInfo.DG_Orders_Date = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16670), DateTime.Now);
				orderInfo.DG_Orders_Cost = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17278), 0.0m));
				orderInfo.DG_Orders_NetCost = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17299), 0.0m));
				orderInfo.DG_Orders_Currency_ID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17324), 0));
				orderInfo.DG_Orders_Currency_Conversion_Rate = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17353), string.Empty);
				orderInfo.DG_Orders_Total_Discount = new double?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17402), 0.0));
				orderInfo.DG_Orders_Total_Discount_Details = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17435), string.Empty);
				orderInfo.DG_Orders_PaymentDetails = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17480), string.Empty);
				orderInfo.DG_Orders_PaymentMode = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17513), 0));
				orderDetailInfo.DG_Orders_ProductType_Name = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(2814), string.Empty);
				orderDetailInfo.DG_Orders_ProductType_IsBundled = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17542), false);
				orderDetailInfo.DG_IsPackage = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17587), false);
				orderDetailInfo.LineItemshare = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17604), 0.0m);
				orderDetailInfo.OrderInfo = orderInfo;
				list.Add(orderDetailInfo);
			}
			return list;
		}

		public List<OrderDetailInfo> GetOrderDetailsByID(int LineItemskey)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(OrderDetailsDao.getOrderDetails(17625), LineItemskey);
			}
			IDataReader dataReader;
			List<OrderDetailInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.orderDetailInfo3(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<OrderDetailInfo> orderDetailInfo3 ( IDataReader dataReader)
		{
			List<OrderDetailInfo> list = new List<OrderDetailInfo>();
			while (dataReader.Read())
			{
				OrderDetailInfo orderDetailInfo = new OrderDetailInfo();
				if (!false)
				{
					orderDetailInfo.DG_Orders_pkey = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16624), 0);
					orderDetailInfo.DG_Orders_Number = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16645), string.Empty);
					orderDetailInfo.DG_Orders_Date = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16670), DateTime.Now);
					orderDetailInfo.OrderInfo = new OrderInfo
					{
						DG_Orders_Cost = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17278), 0.0m)),
						DG_Orders_NetCost = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17299), 0.0m)),
						DG_Orders_Currency_ID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17324), 0)),
						DG_Orders_Currency_Conversion_Rate = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17353), string.Empty),
						DG_Orders_Total_Discount = new double?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17402), 0.0)),
						DG_Orders_Total_Discount_Details = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17435), string.Empty),
						DG_Orders_PaymentMode = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17513), 0)),
						DG_Orders_PaymentDetails = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17480), string.Empty)
					};
				}
				orderDetailInfo.DG_Orders_LineItems_pkey = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16691), 0);
				orderDetailInfo.DG_Orders_ID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16724), 0));
				orderDetailInfo.DG_Photos_ID = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(15034), string.Empty);
				orderDetailInfo.DG_Orders_LineItems_Created = new DateTime?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16902), DateTime.Now));
				orderDetailInfo.DG_Orders_LineItems_DiscountType = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16939), string.Empty);
				orderDetailInfo.DG_Orders_LineItems_DiscountAmount = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16984), 0.0m));
				orderDetailInfo.DG_Orders_LineItems_Quantity = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16840), 0));
				orderDetailInfo.DG_Orders_Details_Items_UniPrice = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17033), 0));
				orderDetailInfo.DG_Orders_Details_Items_TotalCost = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17078), 0.0m));
				orderDetailInfo.DG_Orders_Details_Items_NetPrice = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17123), 0.0m));
				orderDetailInfo.DG_Orders_Details_ProductType_pkey = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16741), 0));
				orderDetailInfo.DG_Orders_Details_LineItem_ParentID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17168), 0));
				orderDetailInfo.DG_Orders_Details_LineItem_PrinterReferenceID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17217), 0));
				orderDetailInfo.DG_Orders_ProductType_pkey = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(2952), 0);
				orderDetailInfo.DG_Orders_ProductType_Name = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(2814), string.Empty);
				orderDetailInfo.DG_IsBorder = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17654), false);
				OrderDetailInfo item = orderDetailInfo;
				list.Add(item);
			}
			return list;
		}

		public OrderDetailInfo GetOrderDetailsByPhotoID(string PhotosId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(OrderDetailsDao.getOrderDetails(17671), PhotosId);
			}
			IDataReader dataReader = base.ExecuteReader("");
			List<OrderDetailInfo> source = this.orderDetailInfo4(dataReader);
			dataReader.Close();
			return source.FirstOrDefault<OrderDetailInfo>();
		}

		private List<OrderDetailInfo> orderDetailInfo4 ( IDataReader dataReader)
		{
			List<OrderDetailInfo> list = new List<OrderDetailInfo>();
			while (dataReader.Read())
			{
				OrderDetailInfo item = new OrderDetailInfo
				{
					DG_Orders_LineItems_pkey = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16691), 0),
					DG_Orders_ID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16724), 0)),
					DG_Photos_ID = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(15034), string.Empty),
					DG_Orders_LineItems_Created = new DateTime?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16902), DateTime.Now)),
					DG_Orders_LineItems_DiscountType = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16939), string.Empty),
					DG_Orders_LineItems_DiscountAmount = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16984), 0.0m)),
					DG_Orders_LineItems_Quantity = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16840), 0)),
					DG_Orders_Details_Items_UniPrice = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17033), 0.0m)),
					DG_Orders_Details_Items_TotalCost = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17078), 0.0m)),
					DG_Orders_Details_Items_NetPrice = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17123), 0.0m)),
					DG_Orders_Details_ProductType_pkey = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16741), 0)),
					DG_Orders_Details_LineItem_ParentID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17168), 0)),
					DG_Orders_Details_LineItem_PrinterReferenceID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17217), 0)),
					DG_Photos_Burned = new bool?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17692), false)),
					DG_Order_SubStoreId = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17717), 0)),
					IsPostedToServer = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17746), 0)),
					DG_Order_IdentifierType = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17771), 0)),
					DG_Order_ImageUniqueIdentifier = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17804), string.Empty),
					DG_Order_Status = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16790), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public bool UpdateBurnOrderStatus(int OrdersLineItemskey, int OrderStatus)
		{
			base.DBParameters.Clear();
			base.AddParameter(OrderDetailsDao.getOrderDetails(17845), OrdersLineItemskey);
			do
			{
				base.AddParameter(OrderDetailsDao.getOrderDetails(17886), OrderStatus);
			}
			while (4 == 0);
			base.ExecuteNonQuery("");
			return true;
		}

		public void UpdateSemiOrderImageOrderDetails(int? OrderId, int PhotoID, int? parentId, int substorId, string DiscountType, decimal DiscountAmount, decimal TotalCost, decimal NetPrice)
		{
			if (true)
			{
				base.DBParameters.Clear();
				if (6 == 0)
				{
					goto IL_E2;
				}
				base.AddParameter(OrderDetailsDao.getOrderDetails(17915), substorId);
				base.AddParameter(OrderDetailsDao.getOrderDetails(17952), OrderId);
				base.AddParameter(OrderDetailsDao.getOrderDetails(17977), parentId);
				base.AddParameter(OrderDetailsDao.getOrderDetails(18034), PhotoID);
				base.AddParameter(OrderDetailsDao.getOrderDetails(18059), DiscountType);
				base.AddParameter(OrderDetailsDao.getOrderDetails(18080), DiscountAmount);
			}
			base.AddParameter(OrderDetailsDao.getOrderDetails(18101), TotalCost);
			IL_E2:
			base.AddParameter(OrderDetailsDao.getOrderDetails(18118), NetPrice);
			base.ExecuteNonQuery("");
		}

		public List<BurnOrderInfo> GetBODetailsByID(int LineItemskey)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(OrderDetailsDao.getOrderDetails(17625), LineItemskey);
			}
			IDataReader dataReader;
			List<BurnOrderInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.burnOrderInfo(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<BurnOrderInfo> burnOrderInfo ( IDataReader dataReader)
		{
			List<BurnOrderInfo> list = new List<BurnOrderInfo>();
			while (dataReader.Read())
			{
				BurnOrderInfo item = new BurnOrderInfo
				{
					PhotosId = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(15034), string.Empty),
					Status = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16790), 0),
					OrderNumber = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16645), string.Empty),
					OrderDetailId = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16691), 0),
					ProductType = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16741), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public OrderDetailInfo GetSemiOrderImage(int OrderDetailsID)
		{
			base.DBParameters.Clear();
			base.AddParameter(OrderDetailsDao.getOrderDetails(18131), OrderDetailsID);
			IDataReader dataReader;
			if (true && !false)
			{
				dataReader = base.ExecuteReader("");
			}
			List<OrderDetailInfo> source;
			do
			{
				source = this.orderDetailInfo5(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<OrderDetailInfo>();
		}

		private List<OrderDetailInfo> orderDetailInfo5 ( IDataReader dataReader)
		{
			List<OrderDetailInfo> list = new List<OrderDetailInfo>();
			IL_04:
			while (!false)
			{
				while (dataReader.Read())
				{
					if (4 == 0)
					{
						goto IL_04;
					}
					OrderDetailInfo item = new OrderDetailInfo
					{
						DG_Orders_ID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16724), 0))
					};
					if (4 == 0)
					{
						break;
					}
					list.Add(item);
				}
				break;
			}
			return list;
		}

		public OrderDetailsViewInfo SelectOrderDetailsByID(int OrdersLineItems)
		{
			base.DBParameters.Clear();
			base.AddParameter(OrderDetailsDao.getOrderDetails(18160), OrdersLineItems);
			IDataReader dataReader;
			if (true && !false)
			{
				dataReader = base.ExecuteReader("");
			}
			List<OrderDetailsViewInfo> source;
			do
			{
				source = this.orderDetailsViewInfo(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<OrderDetailsViewInfo>();
		}

		private List<OrderDetailsViewInfo> orderDetailsViewInfo ( IDataReader dataReader)
		{
			List<OrderDetailsViewInfo> list = new List<OrderDetailsViewInfo>();
			while (true)
			{
				while (dataReader.Read())
				{
					OrderDetailsViewInfo orderDetailsViewInfo = new OrderDetailsViewInfo();
					orderDetailsViewInfo.DG_Orders_LineItems_pkey = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16691), 0);
					orderDetailsViewInfo.DG_Orders_ID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16724), 0));
					if (!false)
					{
						orderDetailsViewInfo.DG_Photos_ID = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(15034), string.Empty);
						orderDetailsViewInfo.DG_Orders_LineItems_Created = new DateTime?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16902), DateTime.Now));
						orderDetailsViewInfo.DG_Orders_LineItems_DiscountType = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16939), string.Empty);
						orderDetailsViewInfo.DG_Orders_LineItems_DiscountAmount = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16984), 0.0m));
						orderDetailsViewInfo.DG_Orders_LineItems_Quantity = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16840), 0);
					}
					orderDetailsViewInfo.DG_Orders_Details_Items_UniPrice = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17033), 0.0m));
					orderDetailsViewInfo.DG_Orders_Details_Items_TotalCost = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17078), 0.0m));
					orderDetailsViewInfo.DG_Orders_Details_Items_NetPrice = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17123), 0.0m));
					orderDetailsViewInfo.DG_Orders_Details_ProductType_pkey = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16741), 0));
					orderDetailsViewInfo.DG_Orders_Details_LineItem_ParentID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17168), 0));
					if (3 != 0)
					{
						orderDetailsViewInfo.DG_Orders_Details_LineItem_PrinterReferenceID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17217), 0));
						orderDetailsViewInfo.DG_Orders_Number = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16645), string.Empty);
						orderDetailsViewInfo.DG_Orders_Date = new DateTime?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16670), DateTime.Now));
						orderDetailsViewInfo.DG_Orders_Cost = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17278), 0.0m));
						orderDetailsViewInfo.DG_Orders_NetCost = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17299), 0.0m));
						orderDetailsViewInfo.DG_Orders_Currency_ID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17324), 0));
						if (2 != 0)
						{
							if (2 == 0)
							{
								break;
							}
							orderDetailsViewInfo.DG_Orders_Currency_Conversion_Rate = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17353), string.Empty);
						}
						orderDetailsViewInfo.DG_Orders_Total_Discount = new float?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17402), 0f));
						orderDetailsViewInfo.DG_Orders_Total_Discount_Details = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17435), string.Empty);
						orderDetailsViewInfo.DG_Orders_PaymentDetails = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17480), string.Empty);
						orderDetailsViewInfo.DG_Orders_PaymentMode = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17513), 0));
						orderDetailsViewInfo.DG_Orders_ProductType_Name = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(2814), string.Empty);
						orderDetailsViewInfo.DG_IsBorder = new bool?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17654), false));
						OrderDetailsViewInfo item = orderDetailsViewInfo;
						list.Add(item);
					}
				}
				break;
			}
			return list;
		}

		public int InsetOrderLineItems(OrderDetailInfo Order)
		{
			base.DBParameters.Clear();
			base.AddParameter(OrderDetailsDao.getOrderDetails(18189), Order.DG_Orders_ID);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18210), Order.DG_Orders_LineItems_Quantity);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18260), Order.DG_Orders_Details_LineItem_ParentID);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18281), Order.DG_Order_SubStoreId);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18310), Order.DG_Order_IdentifierType);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18347), Order.DG_Orders_LineItems_pkey, ParameterDirection.Output);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18376), Order.DG_Orders_LineItems_DiscountAmount);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18405), Order.DG_Orders_Details_Items_UniPrice);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18426), Order.DG_Orders_Details_Items_TotalCost);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18447), Order.DG_Orders_Details_Items_NetPrice);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18468), Order.DG_Orders_LineItems_Created);
			base.AddParameter(OrderDetailsDao.getOrderDetails(17671), Order.DG_Photos_ID);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18489), base.SetNullStringValue(Order.DG_Orders_LineItems_DiscountType));
			base.AddParameter(OrderDetailsDao.getOrderDetails(18514), base.SetNullStringValue(Order.DG_Order_ImageUniqueIdentifier));
			base.AddParameter(OrderDetailsDao.getOrderDetails(394), Order.SyncCode);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18559), Order.TaxPercent);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18584), Order.TaxAmount);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18605), Order.IsTaxIncluded);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18634), Order.DG_Photos_IDUnSold);
			base.ExecuteNonQuery("");
			return (int)base.GetOutParameterValue(OrderDetailsDao.getOrderDetails(18347));
		}

		public List<string> GetCardImageSoldById(string Code)
		{
			IDataReader dataReader;
			List<string> result;
			while (-1 != 0)
			{
				base.DBParameters.Clear();
				if (false)
				{
					break;
				}
				base.AddParameter(OrderDetailsDao.getOrderDetails(7308), Code);
				if (8 != 0)
				{
					if (!false)
					{
						dataReader = base.ExecuteReader("");
						result = this.stringList(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private List<string> stringList(IDataReader dataReader)
		{
			List<string> list;
			if (true)
			{
				list = new List<string>();
			}
			while (dataReader.Read())
			{
				string fieldValue = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(15034), string.Empty);
				list.Add(fieldValue);
			}
			return list;
		}

		public OrderInfo GenerateOrder(OrderInfo ObjOrder)
		{
			base.DBParameters.Clear();
			base.AddParameter(OrderDetailsDao.getOrderDetails(18667), ObjOrder.DG_Orders_PaymentMode);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18704), ObjOrder.DG_Orders_Currency_ID);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18741), ObjOrder.DG_Orders_pkey, ParameterDirection.Output);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18762), ObjOrder.DG_Orders_UserID);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18795), ObjOrder.DG_Orders_Cost);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18824), ObjOrder.DG_Orders_NetCost);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18857), ObjOrder.DG_Orders_Date);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18886), ObjOrder.DG_Orders_Total_Discount);
			base.AddParameter(OrderDetailsDao.getOrderDetails(415), ObjOrder.IsSynced);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18927), ObjOrder.DG_Orders_Number);
			base.AddParameter(OrderDetailsDao.getOrderDetails(394), ObjOrder.SyncCode);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18960), ObjOrder.DG_Order_Mode);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18989), ObjOrder.DG_Orders_PaymentDetails);
			base.AddParameter(OrderDetailsDao.getOrderDetails(19030), ObjOrder.DG_Orders_Currency_Conversion_Rate);
			base.AddParameter(OrderDetailsDao.getOrderDetails(19087), ObjOrder.DG_Orders_Total_Discount_Details);
			base.AddOutParameterString(OrderDetailsDao.getOrderDetails(19140), SqlDbType.NVarChar, 350);
			base.AddParameter(OrderDetailsDao.getOrderDetails(19169), ObjOrder.PosName);
			base.ExecuteNonQuery("");
			return new OrderInfo
			{
				DG_Orders_pkey = (int)base.GetOutParameterValue(OrderDetailsDao.getOrderDetails(18741)),
				DG_Orders_Number = (string)base.GetOutParameterValue(OrderDetailsDao.getOrderDetails(19140))
			};
		}

		public int AddSemiOrderDetails(OrderDetailInfo objOrderD, int locationId, bool isSentToPrinter)
		{
			int num = 0;
			base.DBParameters.Clear();
			base.AddParameter(OrderDetailsDao.getOrderDetails(17671), base.SetNullStringValue(objOrderD.DG_Photos_ID));
			base.AddParameter(OrderDetailsDao.getOrderDetails(18741), objOrderD.DG_Orders_ID);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18231), base.SetNullIntegerValue(objOrderD.DG_Orders_Details_ProductType_pkey));
			base.AddParameter(OrderDetailsDao.getOrderDetails(3738), locationId);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18260), objOrderD.DG_Orders_Details_LineItem_ParentID);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18210), objOrderD.DG_Orders_LineItems_Quantity);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18426), objOrderD.DG_Orders_Details_Items_TotalCost);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18376), objOrderD.DG_Orders_LineItems_DiscountAmount);
			base.AddParameter(OrderDetailsDao.getOrderDetails(394), objOrderD.SyncCode);
			base.AddParameter(OrderDetailsDao.getOrderDetails(19190), isSentToPrinter);
			base.AddParameter(OrderDetailsDao.getOrderDetails(2330), objOrderD.DG_Order_SubStoreId);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18347), num, ParameterDirection.Output);
			base.ExecuteNonQuery("");
			return (int)base.GetOutParameterValue(OrderDetailsDao.getOrderDetails(18347));
		}

		public int SetOrderDetails(OrderDetailInfo objOrderD)
		{
			int num;
			do
			{
				num = 0;
				List<SqlParameter> expr_1F3 = base.DBParameters;
				if (!false)
				{
					expr_1F3.Clear();
				}
			}
			while (false);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18741), objOrderD.DG_Orders_ID);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18231), base.SetNullIntegerValue(objOrderD.DG_Orders_Details_ProductType_pkey));
			base.AddParameter(OrderDetailsDao.getOrderDetails(18281), objOrderD.DG_Order_SubStoreId);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18260), objOrderD.DG_Orders_Details_LineItem_ParentID);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18210), objOrderD.DG_Orders_LineItems_Quantity);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18347), num, ParameterDirection.Output);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18405), objOrderD.DG_Orders_Details_Items_UniPrice);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18426), objOrderD.DG_Orders_Details_Items_TotalCost);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18447), objOrderD.DG_Orders_Details_Items_NetPrice);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18376), objOrderD.DG_Orders_LineItems_DiscountAmount);
			base.AddParameter(OrderDetailsDao.getOrderDetails(18468), objOrderD.DG_Orders_LineItems_Created);
			base.AddParameter(OrderDetailsDao.getOrderDetails(17671), base.SetNullStringValue(objOrderD.DG_Photos_ID));
			base.AddParameter(OrderDetailsDao.getOrderDetails(394), objOrderD.SyncCode);
			do
			{
				base.ExecuteNonQuery("");
				num = (int)base.GetOutParameterValue(OrderDetailsDao.getOrderDetails(18347));
			}
			while (7 == 0);
			return num;
		}

		public List<BurnOrderInfo> SelectPendingBurnOrders(bool All)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(OrderDetailsDao.getOrderDetails(19219), All);
			}
			IDataReader dataReader;
			List<BurnOrderInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.burnOrderInfo2(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<BurnOrderInfo> burnOrderInfo2 ( IDataReader dataReader)
		{
			List<BurnOrderInfo> list = new List<BurnOrderInfo>();
			while (dataReader.Read())
			{
				BurnOrderInfo item = new BurnOrderInfo
				{
					OrderNumber = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16645), string.Empty),
					OrderDetailId = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16691), 0),
					PhotosId = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(15034), string.Empty),
					ProductType = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16741), 0),
					Status = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16790), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public bool UpdateCancelOrder(string OrderNo, string CancelReason)
		{
			if (!false && -1 != 0)
			{
				base.DBParameters.Clear();
			}
			base.AddParameter(OrderDetailsDao.getOrderDetails(18927), OrderNo);
			base.AddParameter(OrderDetailsDao.getOrderDetails(19232), DateTime.Now);
			base.AddParameter(OrderDetailsDao.getOrderDetails(19273), true);
			base.AddParameter(OrderDetailsDao.getOrderDetails(19306), CancelReason);
			base.ExecuteNonQuery("");
			return true;
		}

		//public OrderInfo GetOrder(string OrderNo)
		//{
		//	IDataReader dataReader;
		//	OrderInfo result;
		//	while (-1 != 0)
		//	{
		//		base.DBParameters.Clear();
		//		if (false)
		//		{
		//			break;
		//		}
		//		base.AddParameter(OrderDetailsDao.getOrderDetails(16811), OrderNo);
		//		if (8 != 0)
		//		{
		//			if (!false)
		//			{
		//				dataReader = base.ExecuteReader("");
		//				result = this.#Xb(dataReader);
		//				break;
		//			}
		//			break;
		//		}
		//	}
		//	dataReader.Close();
		//	return result;
		//}

		//private OrderInfo #Xb(IDataReader #1)
		//{
		//	OrderInfo orderInfo;
		//	if (!false)
		//	{
		//		orderInfo = new OrderInfo();
		//		goto IL_27F;
		//	}
		//	do
		//	{
		//		IL_8C:
		//		orderInfo.DG_Albums_ID = new int?(base.GetFieldValue(#1, OrderDetailsDao.(19351), 0));
		//		orderInfo.DG_Orders_Cost = new decimal?(base.GetFieldValue(#1, OrderDetailsDao.(17278), 0.0m));
		//		orderInfo.DG_Orders_NetCost = new decimal?(base.GetFieldValue(#1, OrderDetailsDao.(17299), 0.0m));
		//		orderInfo.DG_Orders_Currency_ID = new int?(base.GetFieldValue(#1, OrderDetailsDao.(17324), 0));
		//		orderInfo.DG_Orders_Currency_Conversion_Rate = base.GetFieldValue(#1, OrderDetailsDao.(17353), string.Empty);
		//		orderInfo.DG_Orders_Total_Discount = new double?((double)base.GetFieldValue(#1, OrderDetailsDao.(17402), 0f));
		//		orderInfo.DG_Orders_Total_Discount_Details = base.GetFieldValue(#1, OrderDetailsDao.(17435), string.Empty);
		//		orderInfo.DG_Orders_PaymentMode = new int?(base.GetFieldValue(#1, OrderDetailsDao.(17513), 0));
		//		orderInfo.DG_Orders_PaymentDetails = base.GetFieldValue(#1, OrderDetailsDao.(17480), string.Empty);
		//		orderInfo.DG_Orders_Canceled = new bool?(base.GetFieldValue(#1, OrderDetailsDao.(19368), false));
		//		orderInfo.DG_Orders_Canceled_Date = new DateTime?(base.GetFieldValue(#1, OrderDetailsDao.(19393), DateTime.Now));
		//		orderInfo.DG_Orders_Canceled_Reason = base.GetFieldValue(#1, OrderDetailsDao.(19426), string.Empty);
		//		orderInfo.SyncCode = base.GetFieldValue(#1, OrderDetailsDao.(1986), string.Empty);
		//	}
		//	while (false);
		//	orderInfo.IsSynced = base.GetFieldValue(#1, OrderDetailsDao.(1999), false);
		//	IL_27F:
		//	if (!#1.Read())
		//	{
		//		return orderInfo;
		//	}
		//	OrderInfo expr_29C = orderInfo;
		//	int expr_2B8 = base.GetFieldValue(#1, OrderDetailsDao.(16624), 0);
		//	if (!false)
		//	{
		//		expr_29C.DG_Orders_pkey = expr_2B8;
		//	}
		//	orderInfo.DG_Orders_Number = base.GetFieldValue(#1, OrderDetailsDao.(16645), string.Empty);
		//	orderInfo.DG_Orders_Date = new DateTime?(base.GetFieldValue(#1, OrderDetailsDao.(16670), DateTime.Now));
		//	goto IL_8C;
		//}

		public bool GetSemiOrderImageforValidation(string imageNumber)
		{
			bool flag = false;
			base.DBParameters.Clear();
			base.AddParameter(OrderDetailsDao.getOrderDetails(17671), imageNumber);
			base.AddParameter(OrderDetailsDao.getOrderDetails(19463), flag, ParameterDirection.Output);
			base.ExecuteNonQuery("");
			return (bool)base.GetOutParameterValue(OrderDetailsDao.getOrderDetails(19463));
		}

		public bool UpdatePostedOrder(int Status, string OrderNumber)
		{
			do
			{
				base.DBParameters.Clear();
				do
				{
					if (!false)
					{
						base.AddParameter(OrderDetailsDao.getOrderDetails(19484), Status);
					}
					if (8 != 0)
					{
						base.AddParameter(OrderDetailsDao.getOrderDetails(19497), OrderNumber);
					}
				}
				while (3 == 0);
			}
			while (2 == 0 || 6 == 0);
			base.ExecuteNonQuery("");
			return true;
		}

		public OrderInfo GetOrdersNumber(string OrdersNumber)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(OrderDetailsDao.getOrderDetails(19514), OrdersNumber);
			}
			IDataReader dataReader = base.ExecuteReader("");
			List<OrderInfo> source = this.orderInfo(dataReader);
			dataReader.Close();
			return source.FirstOrDefault<OrderInfo>();
		}

		private List<OrderInfo> orderInfo(IDataReader dataReader)
		{
			List<OrderInfo> list = new List<OrderInfo>();
			while (dataReader.Read())
			{
				OrderInfo item = new OrderInfo
				{
					DG_Orders_pkey = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16624), 0),
					DG_Orders_Number = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16645), string.Empty),
					DG_Orders_Date = new DateTime?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16670), DateTime.Now)),
					DG_Albums_ID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(19351), 0)),
					DG_Order_Mode = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(19539), string.Empty),
					DG_Orders_UserID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(19560), 0)),
					DG_Orders_Cost = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17278), 0.0m)),
					DG_Orders_NetCost = new decimal?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17299), 0.0m)),
					DG_Orders_Currency_ID = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17324), 0)),
					DG_Orders_Currency_Conversion_Rate = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17353), string.Empty),
					DG_Orders_Total_Discount = new double?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17402), 0.0)),
					DG_Orders_Total_Discount_Details = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17435), string.Empty),
					DG_Orders_PaymentMode = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17513), 0)),
					DG_Orders_PaymentDetails = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17480), string.Empty),
					DG_Orders_Canceled = new bool?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(19368), false)),
					DG_Orders_Canceled_Date = new DateTime?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(19393), DateTime.Now)),
					DG_Orders_Canceled_Reason = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(19426), string.Empty),
					SyncCode = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(1986), string.Empty),
					IsSynced = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(1999), false)
				};
				list.Add(item);
			}
			return list;
		}

		public List<OrderDetailInfo> GetPhotoToUpload()
		{
			base.DBParameters.Clear();
			IDataReader dataReader;
			if (8 != 0)
			{
				dataReader = base.ExecuteReader("");
			}
			List<OrderDetailInfo> result = this.orderDetailInfo6(dataReader);
			dataReader.Close();
			return result;
		}

		private List<OrderDetailInfo> orderDetailInfo6 ( IDataReader dataReader)
		{
			List<OrderDetailInfo> list = new List<OrderDetailInfo>();
			while (dataReader.Read())
			{
				OrderDetailInfo orderDetailInfo = new OrderDetailInfo();
				orderDetailInfo.DG_Orders_Number = base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(16645), string.Empty);
				OrderDetailInfo item;
				do
				{
					orderDetailInfo.DG_Order_SubStoreId = new int?(base.GetFieldValue(dataReader, OrderDetailsDao.getOrderDetails(17717), 0));
					item = orderDetailInfo;
				}
				while (5 == 0);
				list.Add(item);
			}
			return list;
		}

		public bool chKIsWaterMarkedOrNot(int PackageID)
		{
			bool flag;
			if (!false && -1 != 0)
			{
				flag = false;
			}
			if (6 != 0)
			{
				base.DBParameters.Clear();
				base.AddParameter(OrderDetailsDao.getOrderDetails(15165), flag, ParameterDirection.Output);
				base.AddParameter(OrderDetailsDao.getOrderDetails(19585), base.SetNullIntegerValue(new int?(PackageID)));
				base.ExecuteNonQuery("");
			}
			return (bool)base.GetOutParameterValue(OrderDetailsDao.getOrderDetails(15165));
		}

		static OrderDetailsDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(OrderDetailsDao));
		}
	}
}
