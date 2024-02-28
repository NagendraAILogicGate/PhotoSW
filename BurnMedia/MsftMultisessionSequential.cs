using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(MsftMultisessionSequentialClass)), Guid("27354151-7F64-5B0F-8F00-5D77AFBE261E")]
	[ComImport]
	public interface MsftMultisessionSequential : IMultisessionSequential
	{
	}
}
