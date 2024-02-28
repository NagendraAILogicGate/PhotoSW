using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("6CA38BE5-FBBB-4800-95A1-A438865EB0D4"), TypeLibType(TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IIsoImageManager
	{
		[DispId(256)]
		string path
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		[DispId(257)]
		FsiStream Stream
		{
			[MethodImpl(MethodImplOptions.InternalCall)]
			get;
		}

		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetPath(string Val);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void SetStream([MarshalAs(UnmanagedType.Interface)] [In] FsiStream Data);

		[MethodImpl(MethodImplOptions.InternalCall)]
		void Validate();
	}
}
