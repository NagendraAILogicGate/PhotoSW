using System;

namespace PhotoSW.IMIX.Model
{
	public class AssociatedPrintersInfo
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

		public int DG_AssociatedPrinters_ProductType_ID
		{
			get;
			set;
		}

		public bool DG_AssociatedPrinters_IsActive
		{
			get;
			set;
		}

		public string DG_AssociatedPrinters_PaperSize
		{
			get;
			set;
		}

		public int? DG_AssociatedPrinters_SubStoreID
		{
			get;
			set;
		}

		public string DG_Orders_ProductType_Name
		{
			get;
			set;
		}
	}
}
