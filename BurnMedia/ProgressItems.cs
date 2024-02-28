using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(ProgressItemsClass)), Guid("2C941FD7-975B-59BE-A960-9A2A262853A5")]
	[ComImport]
	public interface ProgressItems : IProgressItems
	{
	}
}
