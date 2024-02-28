using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;


namespace BurnMedia
{

    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DFileSystemImage_EventProvider : IDisposable, DFileSystemImage_Event
    {
        private Hashtable m_aEventSinkHelpers = new Hashtable();
        private IConnectionPoint m_connectionPoint = null;

        public event DFileSystemImage_EventHandler Update
        {
            add
            {
                // This item is obfuscated and can not be translated.
            }
            remove
            {
                // This item is obfuscated and can not be translated.
            }
        }

        public DFileSystemImage_EventProvider(object pointContainer)
        {
            lock (this)
            {
                Guid gUID = typeof(DFileSystemImageEvents).GUID;
                (pointContainer as IConnectionPointContainer).FindConnectionPoint(ref gUID, out this.m_connectionPoint);
            }
        }

        private void Cleanup()
        {
            // This item is obfuscated and can not be translated.
        }

        public void Dispose()
        {
            this.Cleanup();
            GC.SuppressFinalize(this);
        }

        //protected override void Finalize()
        //{
        //    try
        //    {
        //        if (0 == 0)
        //        {
        //            this.Cleanup();
        //        }
        //    }
        //    finally
        //    {
        //        //do
        //        //{
        //        //    base.Finalize();
        //        //}
        //        //while ((7 == 0) || (8 == 0));
        //    }
        //    //while (0 != 0)
        //    //{
        //    //}
        //}
    }
}
