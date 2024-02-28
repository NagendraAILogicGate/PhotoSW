using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("27354151-7F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IMultisessionSequential
	{
		[DispId(256)]
		bool IsSupportedOnCurrentMediaState
		{
			get;
		}

		[DispId(257)]
		bool InUse
		{
			get;
			set;
		}

		[DispId(258)]
		MsftDiscRecorder2 ImportRecorder
		{
			get;
		}

		[DispId(512)]
		bool IsFirstDataSession
		{
			get;
		}

		[DispId(513)]
		int StartAddressOfPreviousSession
		{
			get;
		}

		[DispId(514)]
		int LastWrittenAddressOfPreviousSession
		{
			get;
		}

		[DispId(515)]
		int NextWritableAddress
		{
			get;
		}

		[DispId(516)]
		int FreeSectorsOnMedia
		{
			get;
		}
	}
}
