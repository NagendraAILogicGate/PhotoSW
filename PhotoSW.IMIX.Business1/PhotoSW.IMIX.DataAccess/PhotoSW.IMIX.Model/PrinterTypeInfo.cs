using System;

namespace PhotoSW.IMIX.Model
{
	public class PrinterTypeInfo
	{
		public int PrinterTypeID { get; set; }
		
		public string PrinterType { get; set; }

        public int ProductTypeID { get; set; }

        public string ProductName { get; set; }

        public bool IsActive { get; set; }
        }
}
