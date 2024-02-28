using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[UnmanagedFunctionPointer(CallingConvention.StdCall)]
	public delegate void DFileSystemImageImport_EventHandler([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, FsiFileSystems fileSystem, string currentItem, int importedDirectoryItems, int totalDirectoryItems, int importedFileItems, int totalFileItems);
}
