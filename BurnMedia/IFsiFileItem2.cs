using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace BurnMedia
{
	[Guid("199D0C19-11E1-40EB-8EC2-C8C822A07792"), TypeLibType(TypeLibTypeFlags.FDual | TypeLibTypeFlags.FNonExtensible | TypeLibTypeFlags.FDispatchable)]
	[ComImport]
	public interface IFsiFileItem2
	{
		[DispId(11)]
		string Name
		{
			get;
		}

		[DispId(12)]
		string FullPath
		{
			get;
		}

		[DispId(13)]
		DateTime CreationTime
		{
			get;
			set;
		}

		[DispId(14)]
		DateTime LastAccessedTime
		{
			get;
			set;
		}

		[DispId(15)]
		DateTime LastModifiedTime
		{
			get;
			set;
		}

		[DispId(16)]
		bool IsHidden
		{
			get;
			set;
		}

		[DispId(41)]
		long DataSize
		{
			get;
		}

		[DispId(42)]
		int DataSize32BitLow
		{
			get;
		}

		[DispId(43)]
		int DataSize32BitHigh
		{
			get;
		}

		[DispId(44)]
		IStream Data
		{
			get;
			set;
		}

		[DispId(45)]
		FsiNamedStreams FsiNamedStreams
		{
			get;
		}

		[DispId(46)]
		bool IsNamedStream
		{
			get;
		}

		[DispId(49)]
		bool IsRealTime
		{
			get;
			set;
		}

		[DispId(17)]
		string FileSystemName(FsiFileSystems fileSystem);

		[DispId(18)]
		string FileSystemPath(FsiFileSystems fileSystem);

		[DispId(47)]
		void AddStream(string Name, FsiStream streamData);

		[DispId(48)]
		void RemoveStream(string Name);
	}
}
