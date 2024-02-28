using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("27354131-7F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface DDiscMaster2Events
	{
		[DispId(256)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void NotifyDeviceAdded([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, string uniqueId);

		[DispId(257)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void NotifyDeviceRemoved([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, string uniqueId);
	}
}
