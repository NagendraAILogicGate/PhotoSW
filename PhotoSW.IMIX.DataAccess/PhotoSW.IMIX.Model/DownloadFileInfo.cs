using System;

namespace PhotoSW.IMIX.Model
{
	public class DownloadFileInfo
	{
		public DateTime CreatedDate
		{
			get;
			set;
		}

		public bool isVideo
		{
			get;
			set;
		}

		public string fileName
		{
			get;
			set;
		}

		public string filePath
		{
			get;
			set;
		}

		public string videoPath
		{
			get;
			set;
		}

		public string fileExtension
		{
			get;
			set;
		}

		public string drivePath
		{
			get;
			set;
		}
	}
}
