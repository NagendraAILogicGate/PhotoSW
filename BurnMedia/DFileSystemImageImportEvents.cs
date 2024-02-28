using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("D25C30F9-4087-4366-9E24-E55BE286424B"), TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface DFileSystemImageImportEvents
	{
		[DispId(257)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void UpdateImport([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, FsiFileSystems fileSystem, string currentItem, int importedDirectoryItems, int totalDirectoryItems, int importedFileItems, int totalFileItems);
	}
}
