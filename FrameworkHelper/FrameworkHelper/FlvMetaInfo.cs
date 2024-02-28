using System;

namespace FrameworkHelper
{
	public class FlvMetaInfo
	{
		private double _duration;

		private bool _hasMetaData;

		public double Duration
		{
			get
			{
				return this._duration;
			}
			set
			{
				this._duration = value;
			}
		}

		public bool HasMetaData
		{
			get
			{
				return this._hasMetaData;
			}
			set
			{
				this._hasMetaData = value;
			}
		}

		internal FlvMetaInfo(bool hasMetaData, double duration)
		{
			this._hasMetaData = hasMetaData;
			this._duration = duration;
		}
	}
}
