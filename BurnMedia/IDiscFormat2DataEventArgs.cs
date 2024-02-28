using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("2735413D-7F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FDispatchable)]
	public interface IDiscFormat2DataEventArgs
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

		[DispId(768)]
		int ElapsedTime
		{
			get;
		}

		[DispId(769)]
		int RemainingTime
		{
			get;
		}

		[DispId(770)]
		int TotalTime
		{
			get;
		}

		[DispId(771)]
		IMAPI_FORMAT2_DATA_WRITE_ACTION CurrentAction
		{
			get;
		}
	}
}
