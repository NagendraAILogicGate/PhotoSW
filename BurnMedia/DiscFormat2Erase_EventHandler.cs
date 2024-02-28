using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void DiscFormat2Erase_EventHandler([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, [In] int elapsedSeconds, [In] int estimatedTotalSeconds);
}
