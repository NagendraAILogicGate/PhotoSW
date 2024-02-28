namespace FrameworkHelper
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public class MyImageClassList : ICloneable
    {
        public MyImageClassList()
        {
            this.ListMyImageClass = new List<MyImageClass>();
        }

        public object Clone()
        {
            return new MyImageClassList { ListMyImageClass = this.ListMyImageClass, Barcode = this.Barcode, Format = this.Format };
        }

        public string Barcode { get; set; }

        public string Format { get; set; }

        public List<MyImageClass> ListMyImageClass { get; set; }
    }
}

