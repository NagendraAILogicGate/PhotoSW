using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(MsftWriteEngine2Class)), Guid("27354135-7F64-5B0F-8F00-5D77AFBE261E")]
	[ComImport]
	public interface MsftWriteEngine2 : DWriteEngine2_Event, IWriteEngine2
	{
	}
}
