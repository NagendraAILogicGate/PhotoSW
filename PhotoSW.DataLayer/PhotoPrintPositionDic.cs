using System;
using System.Runtime.CompilerServices;

namespace PhotoSW.DataLayer
{
	public class PhotoPrintPositionDic
	{
		public PhotoPrintPosition PhotoPrintPositionList;

		
	//	private int ;

		public int PhotoId
		{
			get;
			set;
		}

		public PhotoPrintPositionDic()
		{
			this.PhotoPrintPositionList = new PhotoPrintPosition();
		}

		public PhotoPrintPositionDic(int PhotoId, PhotoPrintPosition photoPrintPosition)
		{
			this.PhotoPrintPositionList = new PhotoPrintPosition();
			this.PhotoPrintPositionList = photoPrintPosition;
			this.PhotoId = PhotoId;
		}
	}
}
