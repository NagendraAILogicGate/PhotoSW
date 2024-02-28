using System;

namespace PhotoSW.IMIX.Model
{
	public class PreSoldAutoOnlineOrderInfo
	{
		public long IMIXImageAssociationId
		{
			get;
			set;
		}

		public int PhotoId
		{
			get;
			set;
		}

		public int IsOrdered
		{
			get;
			set;
		}

		public string CardUniqueIdentifier
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public int MaxImages
		{
			get;
			set;
		}

		public int PackageId
		{
			get;
			set;
		}

		public float DG_Product_Pricing_ProductPrice
		{
			get;
			set;
		}

		public int ImageIdentificationType
		{
			get;
			set;
		}

		public bool IsWaterMarked
		{
			get;
			set;
		}
	}
}
