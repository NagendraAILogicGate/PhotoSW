using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void DFileSystemImage_EventHandler([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, string currentFile, int copiedSectors, int totalSectors);
}
