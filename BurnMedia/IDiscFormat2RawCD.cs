using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace BurnMedia
{
	[Guid("27354155-8F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IDiscFormat2RawCD
	{
		[DispId(1792)]
		bool MediaPhysicallyBlank
		{
			get;
		}

		[DispId(1793)]
		bool MediaHeuristicallyBlank
		{
			get;
		}

		[DispId(1794)]
		object[] SupportedMediaTypes
		{
			get;
		}

		[DispId(256)]
		IDiscRecorder2 Recorder
		{
			get;
			set;
		}

		[DispId(258)]
		bool BufferUnderrunFreeDisabled
		{
			get;
			set;
		}

		[DispId(259)]
		int StartOfNextSession
		{
			get;
		}

		[DispId(260)]
		int LastPossibleStartOfLeadout
		{
			get;
		}

		[DispId(261)]
		IMAPI_MEDIA_PHYSICAL_TYPE CurrentPhysicalMediaType
		{
			get;
		}

		[DispId(264)]
		object[] SupportedSectorTypes
		{
			get;
		}

		[DispId(265)]
		IMAPI_FORMAT2_RAW_CD_DATA_SECTOR_TYPE RequestedSectorType
		{
			get;
			set;
		}

		[DispId(266)]
		string ClientName
		{
			get;
			set;
		}

		[DispId(267)]
		int RequestedWriteSpeed
		{
			get;
		}

		[DispId(268)]
		bool RequestedRotationTypeIsPureCAV
		{
			get;
		}

		[DispId(269)]
		int CurrentWriteSpeed
		{
			get;
		}

		[DispId(270)]
		bool CurrentRotationTypeIsPureCAV
		{
			get;
		}

		[DispId(271)]
		object[] SupportedWriteSpeeds
		{
			get;
		}

		[DispId(272)]
		object[] SupportedWriteSpeedDescriptors
		{
			get;
		}

		[DispId(2048)]
		bool IsRecorderSupported(IDiscRecorder2 Recorder);

		[DispId(2049)]
		bool IsCurrentMediaSupported(IDiscRecorder2 Recorder);

		[DispId(512)]
		void PrepareMedia();

		[DispId(513)]
		void WriteMedia(IStream data);

		[DispId(514)]
		void WriteMedia2(IStream data, int streamLeadInSectors);

		[DispId(515)]
		void CancelWrite();

		[DispId(516)]
		void ReleaseMedia();

		[DispId(517)]
		void SetWriteSpeed(int RequestedSectorsPerSecond, bool RotationTypeIsPureCAV);
	}
}
