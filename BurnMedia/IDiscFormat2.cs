using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("27354152-8F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IDiscFormat2
	{
		[DispId(1792)]
		bool MediaPhysicallyBlank
		{
			get;
		}

		[DispId(1793)]
		bool MediaHeuristicallyBlank
		{
			get;
		}

		[DispId(1794)]
		object[] SupportedMediaTypes
		{
			get;
		}

		[DispId(2048)]
		bool IsRecorderSupported(IDiscRecorder2 Recorder);

		[DispId(2049)]
		bool IsCurrentMediaSupported(IDiscRecorder2 Recorder);
	}
}
