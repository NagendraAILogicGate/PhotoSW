using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void DiscMaster2_NotifyDeviceAddedEventHandler([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, string uniqueId);
}
