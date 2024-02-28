using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(MsftDiscFormat2RawCDClass)), Guid("27354155-8F64-5B0F-8F00-5D77AFBE261E")]
	[ComImport]
	public interface MsftDiscFormat2RawCD : DiscFormat2RawCD_Event, IDiscFormat2RawCD
	{
	}
}
