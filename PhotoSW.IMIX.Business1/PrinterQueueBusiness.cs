using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class PrinterQueueBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public PrinterQueueBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterQueueBusiness. ;

			public PrinterQueueInfo ;

			public void ()
			{
				if (4 != 0)
				{
					PrinterQueueAccess printerQueueAccess = new PrinterQueueAccess(this...Transaction);
					if (!false)
					{
						this. = printerQueueAccess.GetPrinterQueue(this..);
					}
				}
			}
		}

		public PrinterQueueInfo GetPrinterQueue(int subStoreID)
		{
			if (!false && -1 != 0)
			{
			}
			2. = subStoreID;
			2. = this;
			PrinterQueueInfo result;
			try
			{
				PrinterQueueBusiness. 2 = new PrinterQueueBusiness.();
				if (!false)
				{
					2. = 2;
				}
				2. = null;
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(2.2);
					if (!false)
					{
						base.Start(false);
						result = 2.;
					}
				}
			}
			catch
			{
				result = null;
			}
			return result;
		}
	}
}
