using System;

namespace PhotoSW.IMIX.Model
{
	public class Product
	{
		public string ProductName
		{
			get;
			set;
		}

		public string ProductIcon
		{
			get;
			set;
		}

		public int ProductID
		{
			get;
			set;
		}

		public int MaxQuantity
		{
			get;
			set;
		}

		public bool DiscountOption
		{
			get;
			set;
		}

		public bool IsBundled
		{
			get;
			set;
		}

		public bool IsPackage
		{
			get;
			set;
		}

		public bool IsAccessory
		{
			get;
			set;
		}

		public bool IsWaterMarked
		{
			get;
			set;
		}

		public int? IsPrintType
		{
			get;
			set;
		}
	}
}
