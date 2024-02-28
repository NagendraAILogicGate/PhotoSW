using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[Guid("27354133-7F64-5B0F-8F00-5D77AFBE261E"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IDiscRecorder2
	{
		[DispId(0)]
		string ActiveDiscRecorder
		{
			get;
		}

		[DispId(513)]
		string VendorId
		{
			get;
		}

		[DispId(514)]
		string ProductId
		{
			get;
		}

		[DispId(515)]
		string ProductRevision
		{
			get;
		}

		[DispId(516)]
		string VolumeName
		{
			get;
		}

		[DispId(517)]
		object[] VolumePathNames
		{
			[DispId(517)]
			get;
		}

		[DispId(518)]
		bool DeviceCanLoadMedia
		{
			[DispId(518)]
			get;
		}

		[DispId(519)]
		int LegacyDeviceNumber
		{
			[DispId(519)]
			get;
		}

		[DispId(520)]
		object[] SupportedFeaturePages
		{
			[DispId(520)]
			get;
		}

		[DispId(521)]
		object[] CurrentFeaturePages
		{
			[DispId(521)]
			get;
		}

		[DispId(522)]
		object[] SupportedProfiles
		{
			[DispId(522)]
			get;
		}

		[DispId(523)]
		object[] CurrentProfiles
		{
			[DispId(523)]
			get;
		}

		[DispId(524)]
		object[] SupportedModePages
		{
			[DispId(524)]
			get;
		}

		[DispId(525)]
		string ExclusiveAccessOwner
		{
			[DispId(525)]
			get;
		}

		[DispId(256)]
		void EjectMedia();

		[DispId(257)]
		void CloseTray();

		[DispId(258)]
		void AcquireExclusiveAccess(bool force, string clientName);

		[DispId(259)]
		void ReleaseExclusiveAccess();

		[DispId(260)]
		void DisableMcn();

		[DispId(261)]
		void EnableMcn();

		[DispId(262)]
		void InitializeDiscRecorder(string recorderUniqueId);
	}
}
