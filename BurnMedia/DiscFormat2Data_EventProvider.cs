using System;
using System.Collections;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace BurnMedia
{
   
        [ClassInterface(ClassInterfaceType.None)]
        internal sealed class DiscFormat2Data_EventProvider : IDisposable, DiscFormat2Data_Event
        {
            private Hashtable m_aEventSinkHelpers = new Hashtable();
            private IConnectionPoint m_connectionPoint = null;

            public event DiscFormat2Data_EventHandler Update
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

            public DiscFormat2Data_EventProvider(object pointContainer)
            {
                lock (this)
                {
                    Guid gUID = typeof(DDiscFormat2DataEvents).GUID;
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
            //    catch
            //    {
            //        throw;
            //    }
            //    finally
            //    {
            //        //do
            //        //{
            //        //    base.Finalize();
            //        //}
            //        //while ((7 == 0) || (8 == 0));
            //    }
               
            //}
        }
   

}
