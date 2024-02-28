using System;

namespace PhotoSW.IMIX.Model
{
	public class ArchivedPhotoInfo
	{
		public string FileName
		{
			get;
			set;
		}

		public int MediaType
		{
			get;
			set;
		}

		public int ArchivedPhotoId
		{
			get;
			set;
		}

		public bool FileDeleted
		{
			get;
			set;
		}
	}
}
