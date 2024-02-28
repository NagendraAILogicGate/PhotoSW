using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("F7FB4B9B-6D96-4D7B-9115-201B144811EF"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IFsiDirectoryItem2 : IFsiDirectoryItem
	{
		[DispId(36)]
		void AddTreeWithNamedStreams(string sourceDirectory, bool includeBaseDirectory);
	}
}
