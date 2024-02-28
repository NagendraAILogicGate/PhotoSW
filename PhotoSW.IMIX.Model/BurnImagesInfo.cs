using System;

namespace PhotoSW.IMIX.Model
{
	public class BurnImagesInfo
	{
		private int _ImageID;

		private int producttype;

		public int ImageID
		{
			get
			{
				return this._ImageID;
			}
			set
			{
				this._ImageID = value;
			}
		}

		public int Producttype
		{
			get
			{
				return this.producttype;
			}
			set
			{
				this.producttype = value;
			}
		}
	}
}
