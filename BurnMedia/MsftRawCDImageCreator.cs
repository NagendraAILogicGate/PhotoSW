using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(MsftRawCDImageCreatorClass)), Guid("25983550-9D65-49CE-B335-40630D901227")]
	[ComImport]
	public interface MsftRawCDImageCreator : IRawCDImageCreator
	{
	}
}
