using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(MsftDiscMaster2Class)), Guid("27354130-7F64-5B0F-8F00-5D77AFBE261E")]
	[ComImport]
	public interface MsftDiscMaster2 : IDiscMaster2
	{
	}
}
