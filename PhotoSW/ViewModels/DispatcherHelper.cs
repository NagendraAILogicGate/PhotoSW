using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace PhotoSW.ViewModels
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
