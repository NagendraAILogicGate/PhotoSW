namespace FrameworkHelper.RfidLib
{
    using System;
    using System.Runtime.CompilerServices;

    public class DataEventArgs : EventArgs
    {
        public DataContainer RfidData { get; set; }
    }
}

