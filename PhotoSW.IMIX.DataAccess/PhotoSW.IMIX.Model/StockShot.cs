using System;

namespace PhotoSW.IMIX.Model
{
	public class StockShot
	{
		public long ImageId
		{
			get;
			set;
		}

		public string ImageName
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

		public DateTime CreatedOn
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public DateTime? ModifiedOn
		{
			get;
			set;
		}

		public int? ModifiedBy
		{
			get;
			set;
		}

		public string ImageThumbnailPath
		{
			get;
			set;
		}
	}
}
