using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("27354144-7F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IWriteSpeedDescriptor
	{
		[DispId(257)]
		IMAPI_MEDIA_PHYSICAL_TYPE MediaType
		{
			get;
		}

		[DispId(258)]
		bool RotationTypeIsPureCAV
		{
			get;
		}

		[DispId(259)]
		int WriteSpeed
		{
			get;
		}
	}
}
