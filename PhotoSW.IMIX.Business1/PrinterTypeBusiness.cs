using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using ErrorHandler;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class PrinterTypeBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public PrinterTypeBusiness ;

			public PrinterTypeInfo ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterTypeBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					PrinterTypeAccess printerTypeAccess = new PrinterTypeAccess(this...Transaction);
					if (!false)
					{
						this. = printerTypeAccess.SaveUpdatePrinterType(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterTypeBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterTypeBusiness. ;

			public List<PrinterTypeInfo> ;

			public void ()
			{
				if (4 != 0)
				{
					PrinterTypeAccess printerTypeAccess = new PrinterTypeAccess(this...Transaction);
					if (!false)
					{
						this. = printerTypeAccess.GetPrinterTypeList(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterTypeBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterTypeBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					PrinterTypeAccess printerTypeAccess = new PrinterTypeAccess(this...Transaction);
					if (!false)
					{
						this. = printerTypeAccess.DeletePrinterType(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterTypeBusiness ;

			public string ;

			public int ;

			public bool ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterTypeBusiness. ;

			public bool ;

			public void ()
			{
				PrinterTypeAccess printerTypeAccess = new PrinterTypeAccess(this...Transaction);
				this. = printerTypeAccess.RemapNewPrinter(this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterTypeBusiness ;

			public string ;

			public int ;

			public bool ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterTypeBusiness. ;

			public bool ;

			public void ()
			{
				PrinterTypeAccess printerTypeAccess = new PrinterTypeAccess(this...Transaction);
				this. = printerTypeAccess.SaveOrActivateNewPrinter(this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterTypeBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterTypeBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					PrinterTypeAccess printerTypeAccess = new PrinterTypeAccess(this...Transaction);
					if (!false)
					{
						this. = printerTypeAccess.DeleteAssociatedPrinters(this..);
					}
				}
			}
		}

		public bool SavePrinterType(PrinterTypeInfo lstPrinterInfo)
		{
			PrinterTypeBusiness.  = new PrinterTypeBusiness.();
			. = lstPrinterInfo;
			. = this;
			bool result;
			try
			{
				PrinterTypeBusiness.  = new PrinterTypeBusiness.();
				do
				{
					. = ;
					if (4 != 0)
					{
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (false)
						{
							goto IL_68;
						}
						if (!false)
						{
							base.Start(false);
						}
					}
					if (false)
					{
						continue;
					}
					result = .;
					IL_68:;
				}
				while (6 == 0);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
				result = false;
			}
			return result;
		}

		public List<PrinterTypeInfo> GetPrinterTypeList(int PrinterTypeId)
		{
			PrinterTypeBusiness.  = new PrinterTypeBusiness.();
			. = PrinterTypeId;
			. = this;
			List<PrinterTypeInfo> result;
			try
			{
				PrinterTypeBusiness.  = new PrinterTypeBusiness.();
				do
				{
					. = ;
					if (4 != 0)
					{
						. = new List<PrinterTypeInfo>();
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (false)
						{
							goto IL_6C;
						}
						if (!false)
						{
							base.Start(false);
						}
					}
					if (false)
					{
						continue;
					}
					result = .;
					IL_6C:;
				}
				while (6 == 0);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
				result = null;
			}
			return result;
		}

		public bool DeletePrinterType(int PrinterTypeId)
		{
			PrinterTypeBusiness.  = new PrinterTypeBusiness.();
			bool result;
			while (4 != 0)
			{
				. = PrinterTypeId;
				if (6 != 0)
				{
					. = this;
					try
					{
						PrinterTypeBusiness.  = new PrinterTypeBusiness.();
						. = ;
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						bool expr_5F;
						do
						{
							expr_5F = .;
						}
						while (false);
						result = expr_5F;
					}
					catch (Exception ex)
					{
						do
						{
							ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(ex));
						}
						while (false || false);
						throw ex;
					}
					break;
				}
			}
			return result;
		}

		public bool RemapNewPrinter(string PrinterName, int SubstoreId, bool active)
		{
			bool ;
			while (true)
			{
				int ;
				while (!false)
				{
					if (false)
					{
						return ;
					}
					 = SubstoreId;
					if (6 != 0)
					{
						goto Block_2;
					}
				}
			}
			Block_2:
			. = active;
			. = this;
			try
			{
				PrinterTypeBusiness.  = new PrinterTypeBusiness.();
				. = ;
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				 = .;
			}
			catch (Exception ex)
			{
				if (8 != 0 && 3 != 0)
				{
					ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(ex));
				}
				throw ex;
			}
			return ;
		}

		public bool SaveOrActivateNewPrinter(string PrinterName, int SubstoreId, bool active)
		{
			bool ;
			while (true)
			{
				int ;
				while (!false)
				{
					if (false)
					{
						return ;
					}
					 = SubstoreId;
					if (6 != 0)
					{
						goto Block_2;
					}
				}
			}
			Block_2:
			. = active;
			. = this;
			try
			{
				PrinterTypeBusiness.  = new PrinterTypeBusiness.();
				. = ;
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				 = .;
			}
			catch (Exception ex)
			{
				if (8 != 0 && 3 != 0)
				{
					ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(ex));
				}
				throw ex;
			}
			return ;
		}

		public bool DeleteAssociatedPrinters(int SubstoreId)
		{
			PrinterTypeBusiness.  = new PrinterTypeBusiness.();
			bool result;
			while (4 != 0)
			{
				. = SubstoreId;
				if (6 != 0)
				{
					. = this;
					try
					{
						PrinterTypeBusiness.  = new PrinterTypeBusiness.();
						. = ;
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						bool expr_5F;
						do
						{
							expr_5F = .;
						}
						while (false);
						result = expr_5F;
					}
					catch (Exception ex)
					{
						do
						{
							ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(ex));
						}
						while (false || false);
						throw ex;
					}
					break;
				}
			}
			return result;
		}
	}
}
