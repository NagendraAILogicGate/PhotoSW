using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void DWriteEngine2_EventHandler([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, [MarshalAs(UnmanagedType.IDispatch)] [In] object progress);
}
