using System;

namespace PhotoSW.IMIX.Model
{
	public class PhotographerRFIDAssociationInfo
	{
		public int PhotographerID
		{
			get;
			set;
		}

		public string PhotographerName
		{
			get;
			set;
		}

		public string Location
		{
			get;
			set;
		}

		public int TotalCaptured
		{
			get;
			set;
		}

		public int TotalAssociated
		{
			get;
			set;
		}

		public int TotalNonAssociated
		{
			get;
			set;
		}

		public DateTime? LastAssociatedOn
		{
			get;
			set;
		}
	}
}
