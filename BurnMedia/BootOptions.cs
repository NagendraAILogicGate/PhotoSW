using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(BootOptionsClass)), Guid("2C941FD4-975B-59BE-A960-9A2A262853A5")]
	[ComImport]
	public interface BootOptions : IBootOptions
	{
	}
}
