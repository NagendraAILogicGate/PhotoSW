using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("2C941FDF-975B-59BE-A960-9A2A262853A5"), TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface DFileSystemImageEvents
	{
		[DispId(256)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Update([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, string currentFile, [In] int copiedSectors, [In] int totalSectors);
	}
}
