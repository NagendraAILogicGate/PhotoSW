using System;

namespace PhotoSW.IMIX.Model
{
	public class SliderInfo
	{
		public double MinValue
		{
			get;
			set;
		}

		public double MaxValue
		{
			get;
			set;
		}

		public string PropertyName
		{
			get;
			set;
		}

		public bool IsFloat
		{
			get;
			set;
		}

		public double tickFrequency
		{
			get;
			set;
		}
	}
}
