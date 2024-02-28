using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(MsftIsoImageManagerClass)), Guid("6CA38BE5-FBBB-4800-95A1-A438865EB0D4")]
	[ComImport]
	public interface MsftIsoImageManager : IIsoImageManager
	{
	}
}
