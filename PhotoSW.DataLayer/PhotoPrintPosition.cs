using System;
using System.Runtime.CompilerServices;

namespace PhotoSW.DataLayer
{
	public class PhotoPrintPosition
	{
		
		//private int ;

		
		//private int ;

		
		//private int ;

		public int PageNo
		{
			get;
			set;
		}

		public int PhotoPosition
		{
			get;
			set;
		}

		public int RotationAngle
		{
			get;
			set;
		}

		public PhotoPrintPosition()
		{
		}

		public PhotoPrintPosition(int PageNo, int PhotoPosition, int RotationAngle)
		{
			this.PageNo = PageNo;
			this.PhotoPosition = PhotoPosition;
			this.RotationAngle = RotationAngle;
		}
	}
}
