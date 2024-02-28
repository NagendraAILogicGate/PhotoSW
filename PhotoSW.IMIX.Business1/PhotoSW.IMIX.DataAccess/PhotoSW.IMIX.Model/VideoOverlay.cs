using System;

namespace PhotoSW.IMIX.Model
{
	public class VideoOverlay
	{
		public long VideoOverlayId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string DisplayName
		{
			get;
			set;
		}

		public string Description
		{
			get;
			set;
		}

		public long VideoLength
		{
			get;
			set;
		}

		public int CreatedBy
		{
			get;
			set;
		}

		public int MediaType
		{
			get;
			set;
		}

		public DateTime? CreatedOn
		{
			get;
			set;
		}

		public int ModifiedBy
		{
			get;
			set;
		}

		public DateTime? ModifiedOn
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

		public string IsActiveDisplay
		{
			get;
			set;
		}
	}
}
