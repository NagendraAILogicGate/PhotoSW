using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(EnumFsiItemsClass)), Guid("2C941FDA-975B-59BE-A960-9A2A262853A5")]
	[ComImport]
	public interface EnumFsiItems : IEnumFsiItems
	{
	}
}
