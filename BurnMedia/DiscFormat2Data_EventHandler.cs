using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void DiscFormat2Data_EventHandler([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, [MarshalAs(UnmanagedType.IDispatch)] [In] object progress);
}
