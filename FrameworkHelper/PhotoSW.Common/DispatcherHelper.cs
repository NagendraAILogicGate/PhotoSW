using System;
using System.Security.Permissions;
using System.Windows.Threading;

namespace PhotoSW.Common
{
	public static class DispatcherHelper
	{
		[System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand, Flags = System.Security.Permissions.SecurityPermissionFlag.UnmanagedCode)]
		public static void DoEvents()
		{
			DispatcherFrame dispatcherFrame = new DispatcherFrame();
			Dispatcher.CurrentDispatcher.BeginInvoke(DispatcherPriority.Background, new DispatcherOperationCallback(DispatcherHelper.ExitFrames), dispatcherFrame);
			try
			{
				Dispatcher.PushFrame(dispatcherFrame);
			}
			catch (System.InvalidOperationException)
			{
			}
		}

		private static object ExitFrames(object frame)
		{
			((DispatcherFrame)frame).Continue = false;
			return null;
		}
	}
}
