using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("27354137-7F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FOleAutomation | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface DWriteEngine2Events
	{
		[DispId(256)]
		[MethodImpl(MethodImplOptions.InternalCall)]
		void Update([MarshalAs(UnmanagedType.IDispatch)] [In] object sender, [MarshalAs(UnmanagedType.IDispatch)] [In] object progress);
	}
}
