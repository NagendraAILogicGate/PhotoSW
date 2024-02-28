using System;

namespace PhotoSW.IMIX.Model
{
	public class LinetItemsDetails
	{
		private string productname;

		private string productprice;

		private string productquantity;

		public string Productname
		{
			get
			{
				return this.productname;
			}
			set
			{
				this.productname = value;
			}
		}

		public string Productprice
		{
			get
			{
				return this.productprice;
			}
			set
			{
				this.productprice = value;
			}
		}

		public string Productquantity
		{
			get
			{
				return this.productquantity;
			}
			set
			{
				this.productquantity = value;
			}
		}
	}
}
