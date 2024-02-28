using System;

namespace PhotoSW.IMIX.Model
{
	public class VideoConfigProfiles
	{
		public long ProfileId
		{
			get;
			set;
		}

		public string ProfileName
		{
			get;
			set;
		}

		public string AspectRatio
		{
			get;
			set;
		}

		public int FrameRate
		{
			get;
			set;
		}

		public string OutputFormat
		{
			get;
			set;
		}

		public string VideoCodec
		{
			get;
			set;
		}

		public string AudioCodec
		{
			get;
			set;
		}

		public string AutoVideoEffects
		{
			get;
			set;
		}

		public int LocationId
		{
			get;
			set;
		}
	}
}
