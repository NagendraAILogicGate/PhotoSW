using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace BurnMedia
{
  
    [ClassInterface(ClassInterfaceType.None)]
    internal sealed class DiscFormat2TrackAtOnce_EventProvider : IDisposable, DiscFormat2TrackAtOnce_Event
    {
        private Hashtable m_aEventSinkHelpers = new Hashtable();
        private IConnectionPoint m_connectionPoint = null;

        public event DiscFormat2TrackAtOnce_EventHandler Update
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

        public DiscFormat2TrackAtOnce_EventProvider(object pointContainer)
        {
            lock (this)
            {
                Guid gUID = typeof(DDiscFormat2TrackAtOnceEvents).GUID;
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

       
    }
}
