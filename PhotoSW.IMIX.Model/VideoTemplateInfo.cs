using System;
using System.Collections.Generic;

namespace PhotoSW.IMIX.Model
{
	public class VideoTemplateInfo
	{
		public class VideoSlot
		{
			public long VideoSlotId
			{
				get;
				set;
			}

			public long FrameTimeIn
			{
				get;
				set;
			}

			public int PhotoDisplayTime
			{
				get;
				set;
			}

			public VideoSlot()
			{
			}

			public VideoSlot(long VideoSlotId, long FrameTimeIn, int PhotoDisplayTime)
			{
				this.VideoSlotId = VideoSlotId;
				this.FrameTimeIn = FrameTimeIn;
				this.PhotoDisplayTime = PhotoDisplayTime;
			}
		}

		public List<VideoTemplateInfo.VideoSlot> videoSlots = new List<VideoTemplateInfo.VideoSlot>();

		public long VideoTemplateId
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
