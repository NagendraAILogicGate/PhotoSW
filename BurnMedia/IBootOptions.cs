using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace BurnMedia
{
	[Guid("2C941FD4-975B-59BE-A960-9A2A262853A5"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FDispatchable)]
	public interface IBootOptions
	{
		[DispId(1)]
		IStream BootImage
		{
			get;
		}

		[DispId(2)]
		string Manufacturer
		{
			get;
			set;
		}

		[DispId(3)]
		PlatformId PlatformId
		{
			get;
			set;
		}

		[DispId(4)]
		EmulationType Emulation
		{
			get;
			set;
		}

		[DispId(5)]
		uint ImageSize
		{
			get;
		}

		[DispId(20)]
		void AssignBootImage(IStream newVal);
	}
}
