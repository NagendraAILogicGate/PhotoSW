using System;
using System.Collections.Generic;

namespace FrameworkHelper
{
	public class MyImageClassList : System.ICloneable
	{
		public System.Collections.Generic.List<MyImageClass> ListMyImageClass
		{
			get;
			set;
		}

		public string Barcode
		{
			get;
			set;
		}

		public string Format
		{
			get;
			set;
		}

		public MyImageClassList()
		{
			this.ListMyImageClass = new System.Collections.Generic.List<MyImageClass>();
		}

		public object Clone()
		{
			return new MyImageClassList
			{
				ListMyImageClass = this.ListMyImageClass,
				Barcode = this.Barcode,
				Format = this.Format
			};
		}
	}
}
