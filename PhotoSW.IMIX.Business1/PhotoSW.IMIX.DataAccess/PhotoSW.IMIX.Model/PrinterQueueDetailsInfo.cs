using System;

namespace PhotoSW.IMIX.Model
{
	public class PrinterQueueDetailsInfo
	{
		public int DG_AssociatedPrinters_Pkey
		{
			get;
			set;
		}

		public string DG_AssociatedPrinters_Name
		{
			get;
			set;
		}

		public int DG_Orders_pkey
		{
			get;
			set;
		}

		public string DG_Orders_Number
		{
			get;
			set;
		}

		public int DG_Order_SubStoreId
		{
			get;
			set;
		}

		public string DG_Orders_ProductType_Name
		{
			get;
			set;
		}

		public int DG_Orders_ProductType_pkey
		{
			get;
			set;
		}

		public int DG_PrinterQueue_Pkey
		{
			get;
			set;
		}

		public int DG_PrinterQueue_ProductID
		{
			get;
			set;
		}

		public string DG_PrinterQueue_Image_Pkey
		{
			get;
			set;
		}

		public int DG_Associated_PrinterId
		{
			get;
			set;
		}

		public int DG_Order_Details_Pkey
		{
			get;
			set;
		}

		public bool DG_SentToPrinter
		{
			get;
			set;
		}

		public bool is_Active
		{
			get;
			set;
		}

		public int QueueIndex
		{
			get;
			set;
		}

		public string DG_Photos_RFID
		{
			get;
			set;
		}

		public string DG_Photos_pKey
		{
			get;
			set;
		}
	}
}
