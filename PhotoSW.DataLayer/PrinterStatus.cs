using System;

namespace PhotoSW.DataLayer
{
	public enum PrinterStatus
	{
		Other = 1,
		Unknown,
		Idle,
		Printing,
		WarmUp,
		StoppedPrinting,
		Offline
	}
}
