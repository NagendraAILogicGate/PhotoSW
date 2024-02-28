using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoSW.CF.DataLayer.Entity
    {
    [Table("videotemplateinfo")]
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
