namespace FrameworkHelper.RfidLib
{
    using System;
    using System.Runtime.CompilerServices;

    public class DataContainer
    {
        public string AckId { get; set; }

        public string Content { get; set; }

        public string Id { get; set; }

        public int NoOfIdReceived { get; set; }

        public string TagId { get; set; }

        public DateTime Time { get; set; }
    }
}

