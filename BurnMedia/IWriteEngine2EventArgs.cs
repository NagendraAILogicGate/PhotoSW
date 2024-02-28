using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("27354136-7F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IWriteEngine2EventArgs
	{
		[DispId(256)]
		int StartLba
		{
			get;
		}

		[DispId(257)]
		int SectorCount
		{
			get;
		}

		[DispId(258)]
		int LastReadLba
		{
			get;
		}

		[DispId(259)]
		int LastWrittenLba
		{
			get;
		}

		[DispId(262)]
		int TotalSystemBuffer
		{
			get;
		}

		[DispId(263)]
		int UsedSystemBuffer
		{
			get;
		}

		[DispId(264)]
		int FreeSystemBuffer
		{
			get;
		}
	}
}
