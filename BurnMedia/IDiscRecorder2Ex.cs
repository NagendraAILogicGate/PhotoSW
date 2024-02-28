using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("27354132-7F64-5B0F-8F00-5D77AFBE261E"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDiscRecorder2Ex
	{
		void SendCommandNoData([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] Cdb, uint CdbSize, [MarshalAs(UnmanagedType.LPArray, SizeConst = 18, SizeParamIndex = 0)] byte[] SenseBuffer, uint Timeout);

		void SendCommandSendDataToDevice([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] Cdb, uint CdbSize, [MarshalAs(UnmanagedType.LPArray, SizeConst = 18, SizeParamIndex = 0)] byte[] SenseBuffer, uint Timeout, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] byte[] Buffer, uint BufferSize);

		void SendCommandGetDataFromDevice([MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 1)] byte[] Cdb, uint CdbSize, [MarshalAs(UnmanagedType.LPArray, SizeConst = 18, SizeParamIndex = 0)] byte[] SenseBuffer, uint Timeout, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 5)] byte[] Buffer, uint BufferSize, out uint BufferFetched);

		void ReadDvdStructure(uint format, uint address, uint layer, uint agid, out IntPtr data, out uint Count);

		void SendDvdStructure(uint format, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] data, uint Count);

		void GetAdapterDescriptor(out IntPtr data, ref uint byteSize);

		void GetDeviceDescriptor(out IntPtr data, ref uint byteSize);

		void GetDiscInformation(out IntPtr discInformation, ref uint byteSize);

		void GetTrackInformation(uint address, IMAPI_READ_TRACK_ADDRESS_TYPE addressType, out IntPtr trackInformation, ref uint byteSize);

		void GetFeaturePage(IMAPI_FEATURE_PAGE_TYPE requestedFeature, sbyte currentFeatureOnly, out IntPtr featureData, ref uint byteSize);

		void GetModePage(IMAPI_MODE_PAGE_TYPE requestedModePage, IMAPI_MODE_PAGE_REQUEST_TYPE requestType, out IntPtr modePageData, ref uint byteSize);

		void SetModePage(IMAPI_MODE_PAGE_REQUEST_TYPE requestType, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.U1, SizeParamIndex = 2)] byte[] data, uint byteSize);

		void GetSupportedFeaturePages(sbyte currentFeatureOnly, out IntPtr featureData, ref uint byteSize);

		void GetSupportedProfiles(sbyte currentOnly, out IntPtr profileTypes, out uint validProfiles);

		void GetSupportedModePages(IMAPI_MODE_PAGE_REQUEST_TYPE requestType, out IntPtr modePageTypes, out uint validPages);

		uint GetByteAlignmentMask();

		uint GetMaximumNonPageAlignedTransferSize();

		uint GetMaximumPageAlignedTransferSize();
	}
}
