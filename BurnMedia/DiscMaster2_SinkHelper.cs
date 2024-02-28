using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[ClassInterface(ClassInterfaceType.None), TypeLibType(TypeLibTypeFlags.FHidden)]
	public sealed class DiscMaster2_SinkHelper : DDiscMaster2Events
	{
		private int m_dwCookie;

		private DiscMaster2_NotifyDeviceAddedEventHandler m_AddedDelegate = null;

		private DiscMaster2_NotifyDeviceRemovedEventHandler m_RemovedDelegate = null;

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

		public DiscMaster2_NotifyDeviceAddedEventHandler NotifyDeviceAddedDelegate
		{
			get
			{
				return this.m_AddedDelegate;
			}
			set
			{
				this.m_AddedDelegate = value;
			}
		}

		public DiscMaster2_NotifyDeviceRemovedEventHandler NotifyDeviceRemovedDelegate
		{
			get
			{
				return this.m_RemovedDelegate;
			}
			set
			{
				this.m_RemovedDelegate = value;
			}
		}

		public DiscMaster2_SinkHelper(DiscMaster2_NotifyDeviceAddedEventHandler eventHandler)
		{
			if (eventHandler == null)
			{
				throw new ArgumentNullException("Delegate (callback function) cannot be null");
			}
			this.m_dwCookie = 0;
			this.m_AddedDelegate = eventHandler;
		}

		public DiscMaster2_SinkHelper(DiscMaster2_NotifyDeviceRemovedEventHandler eventHandler)
		{
			if (eventHandler == null)
			{
				throw new ArgumentNullException("Delegate (callback function) cannot be null");
			}
			this.m_dwCookie = 0;
			this.m_RemovedDelegate = eventHandler;
		}

		public void NotifyDeviceAdded(object sender, string uniqueId)
		{
			this.m_AddedDelegate(sender, uniqueId);
		}

		public void NotifyDeviceRemoved(object sender, string uniqueId)
		{
			this.m_RemovedDelegate(sender, uniqueId);
		}
	}
}
