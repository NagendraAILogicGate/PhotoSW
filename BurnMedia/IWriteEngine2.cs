using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace BurnMedia
{
	[Guid("27354135-7F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IWriteEngine2
	{
		[DispId(256)]
		IDiscRecorder2Ex Recorder
		{
			get;
			set;
		}

		[DispId(257)]
		bool UseStreamingWrite12
		{
			get;
			set;
		}

		[DispId(258)]
		int StartingSectorsPerSecond
		{
			get;
			set;
		}

		[DispId(259)]
		int EndingSectorsPerSecond
		{
			get;
			set;
		}

		[DispId(260)]
		int BytesPerSector
		{
			get;
			set;
		}

		[DispId(261)]
		bool WriteInProgress
		{
			get;
		}

		[DispId(512)]
		void WriteSection(IStream data, int startingBlockAddress, int numberOfBlocks);

		[DispId(513)]
		void CancelWrite();
	}
}
