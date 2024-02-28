//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
//using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class OrderAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getOrderAccess;

        public OrderAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public OrderAccess()
		{
		}

		public string GetOrderInvoiceNumber(int OrderId)
		{
			List<SqlParameter> expr_3E = base.DBParameters;
			if (!false)
			{
				expr_3E.Clear();
			}
			do
			{
				base.AddParameter(OrderAccess.getOrderAccess(15624), OrderId);
			}
			while (!true);
			return base.ExecuteScalar(OrderAccess.getOrderAccess(49156)).ToString();
		}

		public OrderReceiptReprintInfo GetOrderDetailForReceipt(int OrderId)
		{
			OrderReceiptReprintInfo result;
			while (true)
			{
				if (false)
				{
					goto IL_41;
				}
				List<SqlParameter> expr_55 = base.DBParameters;
				if (!false)
				{
					expr_55.Clear();
				}
				if (-1 != 0)
				{
					base.AddParameter(OrderAccess.getOrderAccess(15624), OrderId);
					goto IL_25;
				}
				IL_4A:
				if (!true)
				{
					continue;
				}
				if (!false)
				{
					break;
				}
				IL_41:
				IDataReader dataReader;
				if (-1 != 0)
				{
					dataReader.Close();
					goto IL_4A;
				}
				IL_25:
				dataReader = base.ExecuteReader(OrderAccess.getOrderAccess(49185));
				result = this.PopulateOrder(dataReader);
				goto IL_41;
			}
			return result;
		}

		public OrderReceiptReprintInfo PopulateOrder(IDataReader sqlReader)
		{
			OrderReceiptReprintInfo expr_00 = null;
			OrderReceiptReprintInfo orderReceiptReprintInfo;
			if (3 != 0)
			{
				orderReceiptReprintInfo = expr_00;
			}
			while (sqlReader.Read())
			{
				orderReceiptReprintInfo = new OrderReceiptReprintInfo();
				OrderReceiptReprintInfo expr_185 = orderReceiptReprintInfo;
				long expr_3B = (long)base.GetFieldValue(sqlReader, OrderAccess.getOrderAccess(49218), 0);
				if (3 != 0)
				{
					expr_185.OrderId = expr_3B;
				}
				orderReceiptReprintInfo.OrderNumber = base.GetFieldValue(sqlReader, OrderAccess.getOrderAccess(26341), string.Empty);
				orderReceiptReprintInfo.PaymentMode = base.GetFieldValue(sqlReader, OrderAccess.getOrderAccess(49231), 0);
				orderReceiptReprintInfo.PaymentDetail = base.GetFieldValue(sqlReader, OrderAccess.getOrderAccess(49248), string.Empty);
				orderReceiptReprintInfo.NetCost = (double)base.GetFieldValue(sqlReader, OrderAccess.getOrderAccess(49269), 0.0m);
				orderReceiptReprintInfo.TotalCost = (double)base.GetFieldValue(sqlReader, OrderAccess.getOrderAccess(49282), 0.0m);
				orderReceiptReprintInfo.CurrencySymbol = base.GetFieldValue(sqlReader, OrderAccess.getOrderAccess(49295), string.Empty);
				orderReceiptReprintInfo.DiscountTotal = base.GetFieldValue(sqlReader, OrderAccess.getOrderAccess(49316), 0.0);
				orderReceiptReprintInfo.PhotoIds = base.GetFieldValue(sqlReader, OrderAccess.getOrderAccess(49337), string.Empty);
			}
			return orderReceiptReprintInfo;
		}

		static OrderAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(OrderAccess));
		}
	}
}
