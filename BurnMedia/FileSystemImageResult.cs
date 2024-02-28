using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(FileSystemImageResultClass)), Guid("2C941FD8-975B-59BE-A960-9A2A262853A5")]
	[ComImport]
	public interface FileSystemImageResult : IFileSystemImageResult
	{
	}
}
