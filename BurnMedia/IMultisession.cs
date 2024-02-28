using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("27354150-7F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IMultisession
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
	}
}
