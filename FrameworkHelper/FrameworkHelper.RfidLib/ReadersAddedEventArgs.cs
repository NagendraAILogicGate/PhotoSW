using Baracoda.Cameleon.PC.Readers;
using System;
using System.Collections.Generic;

namespace FrameworkHelper.RfidLib
{
	public class ReadersAddedEventArgs : System.EventArgs
	{
		public System.Collections.Generic.IEnumerable<BaracodaReaderBase> AddedReaders
		{
			get;
			set;
		}
	}
}
