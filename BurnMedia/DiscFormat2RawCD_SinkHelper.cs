using System;
using System.Runtime.InteropServices;

namespace BurnMedia
{
	[ClassInterface(ClassInterfaceType.None), TypeLibType(TypeLibTypeFlags.FHidden)]
	public sealed class DiscFormat2RawCD_SinkHelper : DDiscFormat2RawCDEvents
	{
		private int m_dwCookie;

		private DiscFormat2RawCD_EventHandler m_UpdateDelegate;

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

		public DiscFormat2RawCD_EventHandler UpdateDelegate
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

		public DiscFormat2RawCD_SinkHelper(DiscFormat2RawCD_EventHandler eventHandler)
		{
			if (eventHandler == null)
			{
				throw new ArgumentNullException("Delegate (callback function) cannot be null");
			}
			this.m_dwCookie = 0;
			this.m_UpdateDelegate = eventHandler;
		}

		public void Update(object sender, object progress)
		{
			this.m_UpdateDelegate(sender, progress);
		}
	}
}
