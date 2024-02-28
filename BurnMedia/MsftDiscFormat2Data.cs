using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(MsftDiscFormat2DataClass)), Guid("27354153-9F64-5B0F-8F00-5D77AFBE261E")]
	[ComImport]
	public interface MsftDiscFormat2Data : DiscFormat2Data_Event, IDiscFormat2Data
	{
	}
}
