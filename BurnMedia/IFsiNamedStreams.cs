using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("ED79BA56-5294-4250-8D46-F9AECEE23459"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IFsiNamedStreams : IEnumerable
	{
		[DispId(0)]
		FsiFileItem this[int Index]
		{
			get;
		}

		[DispId(81)]
		int Count
		{
			[DispId(81)]
			get;
		}

		[DispId(82)]
		EnumFsiItems EnumNamedStreams
		{
			get;
		}
	}
}
