using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[ClassInterface(ClassInterfaceType.None), TypeLibType(TypeLibTypeFlags.FHidden)]
	public sealed class DFileSystemImageImport_SinkHelper : DFileSystemImageImportEvents
	{
		private int m_dwCookie;

		private DFileSystemImageImport_EventHandler m_UpdateDelegate;

		public int Cookie
		{
			get
			{
				return this.m_dwCookie;
			}
			set
			{
				this.m_dwCookie = value;
			}
		}

		public DFileSystemImageImport_EventHandler UpdateDelegate
		{
			get
			{
				return this.m_UpdateDelegate;
			}
			set
			{
				this.m_UpdateDelegate = value;
			}
		}

		public DFileSystemImageImport_SinkHelper(DFileSystemImageImport_EventHandler eventHandler)
		{
			if (eventHandler == null)
			{
				throw new ArgumentNullException("Delegate (callback function) cannot be null");
			}
			this.m_dwCookie = 0;
			this.m_UpdateDelegate = eventHandler;
		}

		public void UpdateImport(object sender, FsiFileSystems fileSystems, string currentItem, int importedDirectoryItems, int totalDirectoryItems, int importedFileItems, int totalFileItems)
		{
			while (true)
			{
				if (-1 == 0)
				{
					goto IL_1E;
				}
				IL_04:
				if (false)
				{
					continue;
				}
				this.m_UpdateDelegate(sender, fileSystems, currentItem, importedDirectoryItems, totalDirectoryItems, importedFileItems, totalFileItems);
				IL_1E:
				if (!false)
				{
					if (!false)
					{
						break;
					}
					goto IL_04;
				}
			}
		}
	}
}
