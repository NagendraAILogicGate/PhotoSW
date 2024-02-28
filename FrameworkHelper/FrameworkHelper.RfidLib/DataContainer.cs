using System;

namespace FrameworkHelper.RfidLib
{
	public class DataContainer
	{
		public int NoOfIdReceived
		{
			get;
			set;
		}

		public string AckId
		{
			get;
			set;
		}

		public string Id
		{
			get;
			set;
		}

		public string TagId
		{
			get;
			set;
		}

		public System.DateTime Time
		{
			get;
			set;
		}

		public string Content
		{
			get;
			set;
		}
	}
}
