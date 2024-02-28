using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[ComEventInterface(typeof(DDiscFormat2DataEvents), typeof(DiscFormat2Data_EventProvider)), ComVisible(false), TypeLibType(TypeLibTypeFlags.FHidden)]
	public interface DiscFormat2Data_Event
	{
		event DiscFormat2Data_EventHandler Update;
	}
}
