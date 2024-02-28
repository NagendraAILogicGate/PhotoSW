using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(MsftFileSystemImageClass)), Guid("2C941FE1-975B-59BE-A960-9A2A262853A5")]
	[ComImport]
	public interface MsftFileSystemImage : DFileSystemImage_Event, IFileSystemImage
	{
	}
}
