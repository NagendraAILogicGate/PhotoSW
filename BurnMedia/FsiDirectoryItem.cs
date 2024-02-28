using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(FsiDirectoryItemClass)), Guid("F7FB4B9B-6D96-4D7B-9115-201B144811EF")]
	[ComImport]
	public interface FsiDirectoryItem : IFsiDirectoryItem, IFsiDirectoryItem2
	{
	}
}
