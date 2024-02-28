using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[ComEventInterface(typeof(DWriteEngine2Events), typeof(DWriteEngine2_EventProvider)), ComVisible(false), TypeLibType(TypeLibTypeFlags.FHidden)]
	public interface DWriteEngine2_Event
	{
		event DWriteEngine2_EventHandler Update;
	}
}
