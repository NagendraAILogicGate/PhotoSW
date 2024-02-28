using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[ComEventInterface(typeof(DDiscFormat2TrackAtOnceEvents), typeof(DiscFormat2TrackAtOnce_EventProvider)), ComVisible(false), TypeLibType(TypeLibTypeFlags.FHidden)]
	public interface DiscFormat2TrackAtOnce_Event
	{
		event DiscFormat2TrackAtOnce_EventHandler Update;
	}
}
