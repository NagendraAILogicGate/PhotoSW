namespace FrameworkHelper
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct LogObject
    {
        public float value;
        public string opName;
    }
}

