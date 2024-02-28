using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct tagCONNECTDATA
	{
		[MarshalAs(UnmanagedType.IUnknown)]
		public object pUnk;

		public uint dwCookie;
	}
}
