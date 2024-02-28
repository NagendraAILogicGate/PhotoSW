using System;
using System.Windows.Threading;

namespace PhotoSW
{
	public static class DispatcherHelper
	{
		public static Dispatcher UIDispatcher
		{
			get;
			private set;
		}

		public static void CheckBeginInvokeOnUI(Action action)
		{
			if (DispatcherHelper.UIDispatcher.CheckAccess())
			{
				action();
			}
			else
			{
				DispatcherHelper.UIDispatcher.BeginInvoke(action, new object[0]);
			}
		}

		public static void Initialize()
		{
			if (DispatcherHelper.UIDispatcher == null)
			{
				DispatcherHelper.UIDispatcher = Dispatcher.CurrentDispatcher;
			}
		}
	}
}
