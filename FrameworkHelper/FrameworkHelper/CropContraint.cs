using System;

namespace FrameworkHelper
{
	public class CropContraint
	{
		public string Name
		{
			get;
			private set;
		}

		public double? AspectRatio
		{
			get;
			private set;
		}

		public CropContraint(string name, double? aspectRatio)
		{
			this.Name = name;
			this.AspectRatio = aspectRatio;
		}
	}
}
