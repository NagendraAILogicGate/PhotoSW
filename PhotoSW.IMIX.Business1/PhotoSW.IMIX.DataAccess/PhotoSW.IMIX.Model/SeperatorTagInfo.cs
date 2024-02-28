using System;

namespace PhotoSW.IMIX.Model
{
	public class SeperatorTagInfo
	{
		public int SeparatorRFIDTagID
		{
			get;
			set;
		}

		public string TagID
		{
			get;
			set;
		}

		public DateTime CreatedOn
		{
			get;
			set;
		}

		public int LocationId
		{
			get;
			set;
		}

		public string LocationName
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}
	}
}
