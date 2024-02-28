using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("D2FFD834-958B-426D-8470-2A13879C6A91"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IBurnVerification
	{
		[DispId(1024)]
		IMAPI_BURN_VERIFICATION_LEVEL BurnVerificationLevel
		{
			get;
			set;
		}
	}
}
