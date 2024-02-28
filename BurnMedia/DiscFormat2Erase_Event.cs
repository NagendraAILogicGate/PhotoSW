using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[ComEventInterface(typeof(DDiscFormat2EraseEvents), typeof(DiscFormat2Erase_EventProvider)), ComVisible(false), TypeLibType(TypeLibTypeFlags.FHidden)]
	public interface DiscFormat2Erase_Event
	{
		event DiscFormat2Erase_EventHandler Update;
	}
}
