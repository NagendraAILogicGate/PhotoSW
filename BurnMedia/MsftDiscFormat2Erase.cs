using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(MsftDiscFormat2EraseClass)), Guid("27354156-8F64-5B0F-8F00-5D77AFBE261E")]
	[ComImport]
	public interface MsftDiscFormat2Erase : DiscFormat2Erase_Event, IDiscFormat2Erase
	{
	}
}
