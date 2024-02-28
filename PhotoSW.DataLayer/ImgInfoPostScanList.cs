using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace PhotoSW.DataLayer
{
	public class ImgInfoPostScanList : ICloneable
	{
		
		//private List<int> ;

		
		//private string ;

		
		//private string ;

		
		//private int ;

		
		//private DateTime ;

		public List<int> ListImgPhotoId
		{
			get;
			set;
		}

		public string Barcode
		{
			get;
			set;
		}

		public string Format
		{
			get;
			set;
		}

		public int PhotoGrapherId
		{
			get;
			set;
		}

		public DateTime LastImgTime
		{
			get;
			set;
		}

		public ImgInfoPostScanList()
		{
			this.ListImgPhotoId = new List<int>();
		}

		public object Clone()
		{
			ImgInfoPostScanList imgInfoPostScanList = new ImgInfoPostScanList();
			imgInfoPostScanList.ListImgPhotoId = this.ListImgPhotoId;
			if (6 != 0)
			{
				imgInfoPostScanList.Barcode = this.Barcode;
				imgInfoPostScanList.Format = this.Format;
				imgInfoPostScanList.PhotoGrapherId = this.PhotoGrapherId;
				imgInfoPostScanList.LastImgTime = this.LastImgTime;
			}
			return imgInfoPostScanList;
		}
	}
}
