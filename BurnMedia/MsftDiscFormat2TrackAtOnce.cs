using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[CoClass(typeof(MsftDiscFormat2TrackAtOnceClass)), Guid("27354154-8F64-5B0F-8F00-5D77AFBE261E")]
	[ComImport]
	public interface MsftDiscFormat2TrackAtOnce : DiscFormat2TrackAtOnce_Event, IDiscFormat2TrackAtOnce
	{
	}
}
