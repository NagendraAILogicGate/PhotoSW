using System;

namespace FrameworkHelper.RfidLib
{
	public class DataEventArgs : System.EventArgs
	{
		public DataContainer RfidData
		{
			get;
			set;
		}
	}
}
