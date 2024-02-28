using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("2C941FDA-975B-59BE-A960-9A2A262853A5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IEnumFsiItems
	{
		void Next(uint celt, out IFsiItem rgelt, out uint pceltFetched);

		void RemoteNext(uint celt, out IFsiItem rgelt, out uint pceltFetched);

		void Skip(uint celt);

		void Reset();

		void Clone(out IEnumFsiItems ppEnum);
	}
}
