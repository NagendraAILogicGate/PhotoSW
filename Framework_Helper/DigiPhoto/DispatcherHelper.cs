namespace DigiPhoto
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Threading;

    public static class DispatcherHelper
    {
        public static void CheckBeginInvokeOnUI(Action action)
        {
            if (UIDispatcher.CheckAccess())
            {
                action();
            }
            else
            {
                UIDispatcher.BeginInvoke(action, new object[0]);
            }
        }

        public static void Initialize()
        {
            if (UIDispatcher == null)
            {
                UIDispatcher = Dispatcher.CurrentDispatcher;
            }
        }

        public static Dispatcher UIDispatcher
        {
            [CompilerGenerated]
            get
            {
                return <UIDispatcher>k__BackingField;
            }
            [CompilerGenerated]
            private set
            {
                <UIDispatcher>k__BackingField = value;
            }
        }
    }
}

