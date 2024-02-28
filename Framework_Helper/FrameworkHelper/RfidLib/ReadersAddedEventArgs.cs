namespace FrameworkHelper.RfidLib
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class ReadersAddedEventArgs : EventArgs
    {
        public IEnumerable<BaracodaReaderBase> AddedReaders { get; set; }
    }
}

