using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(MsftWriteSpeedDescriptorClass)), Guid("27354144-7F64-5B0F-8F00-5D77AFBE261E")]
	[ComImport]
	public interface MsftWriteSpeedDescriptor : IWriteSpeedDescriptor
	{
	}
}
