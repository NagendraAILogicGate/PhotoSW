using System;

namespace PhotoSW.IMIX.Model
{
	public class GetPrintedProduct_Result
	{
		public int PrintedQuantity
		{
			get;
			set;
		}

		public string DG_Orders_ProductType_Name
		{
			get;
			set;
		}

		public DateTime? DG_Print_Date
		{
			get;
			set;
		}

		public string PhotoNumber
		{
			get;
			set;
		}

		public string DG_SubStore_Name
		{
			get;
			set;
		}

		public string ProductCode
		{
			get;
			set;
		}
	}
}
