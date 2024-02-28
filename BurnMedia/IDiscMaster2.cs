using System;
using System.Collections;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("27354130-7F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IDiscMaster2
	{
		[DispId(0)]
		string this[int index]
		{
			get;
		}

		[DispId(1)]
		int Count
		{
			get;
		}

		[DispId(2)]
		bool IsSupportedEnvironment
		{
			get;
		}

		[DispId(-4), TypeLibFunc(65)]
		IEnumerator GetEnumerator();
	}
}
