//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Data;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class PrinterQueueAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getPrinterQueueAccess;
        public PrinterQueueAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public PrinterQueueAccess()
		{
		}

		public PrinterQueueInfo GetPrinterQueue(int subStoreID)
		{
			base.DBParameters.Clear();
			base.AddParameter(PrinterQueueAccess.getPrinterQueueAccess(25101), subStoreID);
			IDataReader dataReader = base.ExecuteReader(PrinterQueueAccess.getPrinterQueueAccess(34924));
			PrinterQueueInfo printerQueueInfo = null;
			if (dataReader.Read())
			{
				printerQueueInfo = new PrinterQueueInfo();
				printerQueueInfo.DG_PrinterQueue_Pkey = base.GetFieldValue(dataReader, PrinterQueueAccess.getPrinterQueueAccess(22980), 0);
				printerQueueInfo.DG_PrinterQueue_ProductID = new int?(base.GetFieldValue(dataReader, PrinterQueueAccess.getPrinterQueueAccess(23096), 0));
				printerQueueInfo.DG_Orders_ProductType_pkey = base.GetFieldValue(dataReader, PrinterQueueAccess.getPrinterQueueAccess(2976), 0);
				printerQueueInfo.DG_Photos_ID = base.GetFieldValue(dataReader, PrinterQueueAccess.getPrinterQueueAccess(15058), string.Empty);
				printerQueueInfo.DG_Order_Details_Pkey = new int?(base.GetFieldValue(dataReader, PrinterQueueAccess.getPrinterQueueAccess(23009), 0));
				printerQueueInfo.DG_SentToPrinter = new bool?(base.GetFieldValue(dataReader, PrinterQueueAccess.getPrinterQueueAccess(23038), false));
				printerQueueInfo.is_Active = new bool?(base.GetFieldValue(dataReader, PrinterQueueAccess.getPrinterQueueAccess(23133), false));
			}
			return printerQueueInfo;
		}

		static PrinterQueueAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(PrinterQueueAccess));
		}
	}
}
