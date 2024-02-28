using DigiPhoto.DataLayer;
using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class PrinterBusniess : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int ;

			public void ()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this..Transaction);
				printerQueueDao.UpdateReadyForPrint(this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int ;

			public void ()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this..Transaction);
				printerQueueDao.UpdatePrinterQueue(this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public PrinterQueueInfo ;

			public void ()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
				this. = printerQueueDao.GetPrinterQueueIsReadyForPrint(this.., false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int? ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public List<AssociatedPrintersInfo> ;

			public void ()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
				this. = printerQueueDao.SelectAssociatedPrintersforPrint(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int ;

			public bool (PrinterQueueforPrint )
			{
				return .DG_Order_SubStoreId == this.;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public string ;

			public List<PrinterQueueforPrint> ;

			public void ()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
					if (!false)
					{
						this. = printerQueueDao.SelectPrinterQueue(this..);
					}
				}
			}

			public bool (PrinterQueueforPrint )
			{
				int arg_2F_0;
				int arg_2F_1;
				while (true)
				{
					if (!true)
					{
						goto IL_32;
					}
					int arg_16_0;
					arg_2F_0 = (arg_16_0 = .DG_Order_SubStoreId);
					IL_07:
					int expr_0E = arg_2F_1 = this..;
					if (false)
					{
						goto IL_2F;
					}
					if (arg_16_0 == expr_0E)
					{
						if (7 != 0)
						{
							break;
						}
						continue;
					}
					IL_32:
					int expr_33 = arg_16_0 = (arg_2F_0 = 0);
					if (expr_33 == 0)
					{
						return expr_33 != 0;
					}
					goto IL_07;
				}
				arg_2F_0 = (this..Contains(.DG_Orders_ProductType_pkey.ToString()) ? 1 : 0);
				arg_2F_1 = 0;
				IL_2F:
				return arg_2F_0 == arg_2F_1;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public PrinterBusniess. ;

			public List<string> ;

			public bool (PrinterQueueforPrint )
			{
				int arg_2F_0;
				int arg_2F_1;
				while (true)
				{
					if (!true)
					{
						goto IL_32;
					}
					int arg_16_0;
					arg_2F_0 = (arg_16_0 = .DG_Order_SubStoreId);
					IL_07:
					int expr_0E = arg_2F_1 = this..;
					if (false)
					{
						goto IL_2F;
					}
					if (arg_16_0 == expr_0E)
					{
						if (7 != 0)
						{
							break;
						}
						continue;
					}
					IL_32:
					int expr_33 = arg_16_0 = (arg_2F_0 = 0);
					if (expr_33 == 0)
					{
						return expr_33 != 0;
					}
					goto IL_07;
				}
				arg_2F_0 = (this..Contains(.DG_Orders_ProductType_pkey.ToString()) ? 1 : 0);
				arg_2F_1 = 0;
				IL_2F:
				return arg_2F_0 == arg_2F_1;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int ;

			public bool (PrinterQueueforPrint )
			{
				return .DG_Order_SubStoreId == this.;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public List<PrinterQueueforPrint> ;

			public void ()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
					if (!false)
					{
						this. = printerQueueDao.SelectFilteredPrinterQueueforPrint(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public List<PrinterQueueforPrint> ;

			public List<int> ;

			public void ()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
					if (!false)
					{
						this. = printerQueueDao.SelectFilteredPrinterQueueforPrint(this..);
					}
				}
			}

			public bool (PrinterQueueforPrint )
			{
				int arg_10_0 = .DG_Order_SubStoreId;
				int arg_23_0;
				while (arg_10_0 != this.. || false)
				{
					int arg_25_0;
					int expr_27 = arg_25_0 = 0;
					if (expr_27 == 0)
					{
						arg_10_0 = expr_27;
						if (expr_27 != 0)
						{
							continue;
						}
						arg_23_0 = expr_27;
						if (expr_27 == 0)
						{
							return expr_27 != 0;
						}
						IL_22:
						arg_25_0 = ((arg_23_0 == 0) ? 1 : 0);
					}
					return arg_25_0 != 0;
				}
				arg_23_0 = (this..Contains(.DG_Orders_ProductType_pkey) ? 1 : 0);
				goto IL_22;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public List<PrinterQueueDetailsInfo> ;

			public void ()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
					if (!false)
					{
						this. = printerQueueDao.GetPrinterQueueDetailsByOrderNo(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrintLogInfo ;

			public PrinterBusniess ;

			public void ()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this..Transaction);
				printerQueueDao.InsertPrinterLog(this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public string ;

			public int? ;

			public int? ;

			public bool ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public bool ;

			public void ()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
				this. = printerQueueDao.InsDataToPrinterQueue(this.., this.., this.., this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int? ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public AssociatedPrintersInfo ;

			public void ()
			{
				if (4 != 0)
				{
					AssociatedPrintersDao associatedPrintersDao = new AssociatedPrintersDao(this...Transaction);
					if (!false)
					{
						this. = associatedPrintersDao.GetAssociatedPrinterIdFromPRoductTypeId(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public List<AssociatedPrintersInfo> ;

			public void ()
			{
				AssociatedPrintersDao associatedPrintersDao = new AssociatedPrintersDao(this...Transaction);
				this. = associatedPrintersDao.Select(new int?(this..));
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public AssociatedPrintersInfo ;

			public PrinterBusniess ;

			public int ;

			public void ()
			{
				do
				{
					AssociatedPrintersDao associatedPrintersDao;
					if (!false)
					{
						associatedPrintersDao = new AssociatedPrintersDao(this..Transaction);
					}
					this. = associatedPrintersDao.GetAssociatedPrintersByKey(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int ;

			public void ()
			{
				while (true)
				{
					AssociatedPrintersDao associatedPrintersDao;
					if (!false)
					{
						associatedPrintersDao = new AssociatedPrintersDao(this..Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							associatedPrintersDao.Delete(this.);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public int ;

			public PrinterBusniess ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public PrinterQueueInfo ;

			public PrinterQueueInfo ;

			public void ()
			{
				while (true)
				{
					PrinterQueueDao printerQueueDao;
					if (true && !false)
					{
						printerQueueDao = new PrinterQueueDao(this...Transaction);
					}
					while (true)
					{
						this. = printerQueueDao.Get();
						if (false)
						{
							break;
						}
						if (!false)
						{
							return;
						}
					}
				}
			}

			public void ()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
					if (!false)
					{
						this.. = printerQueueDao.Add(this.);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			private sealed class 
			{
				public PrinterBusniess. ;

				public PrinterBusniess. ;

				public PhotoPrintPositionDic ;

				public bool (int )
				{
					return  == this..PhotoId;
				}
			}

			public PrinterBusniess. ;

			public List<int> ;

			public bool (PhotoPrintPositionDic )
			{
				PrinterBusniess.. ;
				if (!false)
				{
					PrinterBusniess.. expr_4E = new PrinterBusniess..();
					if (!false)
					{
						 = expr_4E;
					}
				}
				. = this;
				. = this.;
				. = ;
				bool arg_45_0;
				bool arg_4D_0 = arg_45_0 = this..Any(new Func<int, bool>(.));
				do
				{
					if (!false)
					{
						arg_4D_0 = (arg_45_0 = !arg_45_0);
					}
				}
				while (false || false);
				return arg_4D_0;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public PrinterBusniess. ;

			public int ;

			public bool (PhotoPrintPositionDic )
			{
				return .PhotoPrintPositionList.PageNo == this.;
			}

			public bool (PhotoPrintPositionDic )
			{
				return .PhotoPrintPositionList.PageNo == this.;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public PrinterBusniess. ;

			public PrinterBusniess. ;

			public string ;

			[NonSerialized]
			internal static SmartAssembly.Delegates.GetString ;

			public void (PhotoPrintPositionDic )
			{
				do
				{
					if (!false)
					{
						this. = this. + PrinterBusniess..(1390) + .PhotoId;
					}
				}
				while (false);
			}

			public void (PhotoPrintPositionDic )
			{
				this. = this. + PrinterBusniess..(1390) + .PhotoPrintPositionList.RotationAngle;
			}

			static ()
			{
				// Note: this type is marked as 'beforefieldinit'.
				SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(PrinterBusniess.));
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public PrinterBusniess. ;

			public PrinterBusniess. ;

			public PrinterBusniess. ;

			public PrinterQueueInfo ;

			public PrinterQueueInfo ;

			public void ()
			{
				while (true)
				{
					PrinterQueueDao printerQueueDao;
					if (true && !false)
					{
						printerQueueDao = new PrinterQueueDao(this...Transaction);
					}
					while (true)
					{
						this. = printerQueueDao.Get();
						if (false)
						{
							break;
						}
						if (!false)
						{
							return;
						}
					}
				}
			}

			public void ()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
					if (!false)
					{
						this.. = printerQueueDao.Add(this.);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public PrinterQueueInfo ;

			public PrinterQueueInfo ;

			public void ()
			{
				while (true)
				{
					PrinterQueueDao printerQueueDao;
					if (true && !false)
					{
						printerQueueDao = new PrinterQueueDao(this...Transaction);
					}
					while (true)
					{
						this. = printerQueueDao.Get();
						if (false)
						{
							break;
						}
						if (!false)
						{
							return;
						}
					}
				}
			}

			public void ()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
					if (!false)
					{
						this.. = printerQueueDao.Add(this.);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public PrinterQueueInfo ;

			public PrinterQueueInfo ;

			public void ()
			{
				while (true)
				{
					PrinterQueueDao printerQueueDao;
					if (true && !false)
					{
						printerQueueDao = new PrinterQueueDao(this...Transaction);
					}
					while (true)
					{
						this. = printerQueueDao.Get();
						if (false)
						{
							break;
						}
						if (!false)
						{
							return;
						}
					}
				}
			}

			public void ()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
					if (!false)
					{
						this.. = printerQueueDao.Add(this.);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public PrinterQueueInfo ;

			public PrinterQueueInfo ;

			public void ()
			{
				while (true)
				{
					PrinterQueueDao printerQueueDao;
					if (true && !false)
					{
						printerQueueDao = new PrinterQueueDao(this...Transaction);
					}
					while (true)
					{
						this. = printerQueueDao.Get();
						if (false)
						{
							break;
						}
						if (!false)
						{
							return;
						}
					}
				}
			}

			public void ()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
					if (!false)
					{
						this.. = printerQueueDao.Add(this.);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<AssociatedPrintersInfo> ;

			public PrinterBusniess ;

			public int ;

			public void ()
			{
				do
				{
					PrinterQueueDao printerQueueDao;
					if (!false)
					{
						printerQueueDao = new PrinterQueueDao(this..Transaction);
					}
					this. = printerQueueDao.SelectPrinterDetailsBySubStoreID(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public string ;

			public int ;

			public bool ;

			public string ;

			public int ;

			public void ()
			{
				AssociatedPrintersDao associatedPrintersDao = new AssociatedPrintersDao(this..Transaction);
				associatedPrintersDao.AddAndUpdatePrinterDetails(this., this., this., this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int ;

			public string ;

			public void ()
			{
				do
				{
					PrinterQueueDao printerQueueDao;
					if (!false)
					{
						printerQueueDao = new PrinterQueueDao(this..Transaction);
					}
					printerQueueDao.UpdatePrintQueueIndex(this., this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PrinterQueueInfo> ;

			public PrinterBusniess ;

			public int ;

			public void ()
			{
				do
				{
					PrinterQueueDao printerQueueDao;
					if (!false)
					{
						printerQueueDao = new PrinterQueueDao(this..Transaction);
					}
					this. = printerQueueDao.GetAllFilteredPrinterQueueBySubStoreId(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int ;

			public void ()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this..Transaction);
				printerQueueDao.UpdatePrinterQueueForReprint(this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int ;

			public void ()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this..Transaction);
				printerQueueDao.UpdatePrintCountForReprint(this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterQueueInfo ;

			public PrinterBusniess ;

			public int ;

			public void ()
			{
				do
				{
					PrinterQueueDao printerQueueDao;
					if (!false)
					{
						printerQueueDao = new PrinterQueueDao(this..Transaction);
					}
					this. = printerQueueDao.GetPrinterQueue(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public ObservableCollection<PrinterJobInfo> ;

			public PrinterBusniess ;

			public DataTable ;

			public string ;

			public string ;

			public void ()
			{
				while (true)
				{
					PrinterQueueDao printerQueueDao;
					if (-1 != 0)
					{
						printerQueueDao = new PrinterQueueDao(this..Transaction);
						goto IL_10;
					}
					IL_33:
					if (!false)
					{
						if (false)
						{
							continue;
						}
						if (5 != 0)
						{
							break;
						}
					}
					IL_10:
					this. = printerQueueDao.GetPrinterJobInfo(this., this., this.);
					goto IL_33;
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataTable ;

			public PrinterBusniess ;

			public void ()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this..Transaction);
				printerQueueDao.SaveAlbumPrintPosition(this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PrinterDetailsInfo> ;

			public PrinterBusniess ;

			public int? ;

			public void ()
			{
				do
				{
					AssociatedPrintersDao associatedPrintersDao;
					if (!false)
					{
						associatedPrintersDao = new AssociatedPrintersDao(this..Transaction);
					}
					this. = associatedPrintersDao.GetAssociatedPrinters(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<PrinterQueueInfo> ;

			public PrinterBusniess ;

			public void ()
			{
				PrinterQueueDao printerQueueDao = new PrinterQueueDao(this..Transaction);
				this. = printerQueueDao.GetPrintLogDetails();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public string ;

			public void ()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
					if (!false)
					{
						this. = printerQueueDao.SelectQRCode(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public PrinterBusniess. ;

			public string ;

			public void ()
			{
				if (4 != 0)
				{
					PrinterQueueDao printerQueueDao = new PrinterQueueDao(this...Transaction);
					if (!false)
					{
						this. = printerQueueDao.CheckSpecSetting(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private static Func<PrinterQueueforPrint, int> ;

		[CompilerGenerated]
		private static Func<PrinterQueueforPrint, int> ;

		[CompilerGenerated]
		private static Func<PrinterQueueforPrint, int> ;

		[CompilerGenerated]
		private static Func<PrinterQueueforPrint, int> ;

		[CompilerGenerated]
		private static Func<PrinterQueueforPrint, int> ;

		[CompilerGenerated]
		private static Func<PrinterQueueforPrint, int> ;

		[CompilerGenerated]
		private static Func<PrinterQueueforPrint, int> ;

		[CompilerGenerated]
		private static Func<PrinterQueueforPrint, int> ;

		[CompilerGenerated]
		private static Func<PhotoPrintPositionDic, int> ;

		[CompilerGenerated]
		private static Func<int, int> ;

		[CompilerGenerated]
		private static Func<PhotoPrintPositionDic, int> ;

		[CompilerGenerated]
		private static Func<PhotoPrintPositionDic, int> ;

		[CompilerGenerated]
		private static Func<PhotoPrintPositionDic, int> ;

		[CompilerGenerated]
		private static Func<ItemTemplateDetailModel, bool> ;

		[CompilerGenerated]
		private static Func<PrinterQueueInfo, int?> ;

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public void ReadyForPrint(int QueueId)
		{
			BaseBusiness.TransactionMethod transactionMethod = null;
			PrinterBusniess.  = new PrinterBusniess.();
			. = QueueId;
			. = this;
			try
			{
				new PrinterQueueInfo();
				if (transactionMethod == null)
				{
					transactionMethod = new BaseBusiness.TransactionMethod(.);
				}
				this.operation = transactionMethod;
				base.Start(false);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void SetPrinterQueue(int QueueId)
		{
			do
			{
				BaseBusiness.TransactionMethod expr_00 = null;
				BaseBusiness.TransactionMethod transactionMethod;
				if (8 != 0)
				{
					transactionMethod = expr_00;
				}
				do
				{
				}
				while (-1 == 0);
				. = this;
				try
				{
					PrinterQueueInfo printerQueueInfo = new PrinterQueueInfo();
					printerQueueInfo.DG_SentToPrinter = new bool?(true);
					if (-1 != 0)
					{
						if (transactionMethod == null)
						{
							transactionMethod = new BaseBusiness.TransactionMethod(.);
						}
						this.operation = transactionMethod;
						base.Start(false);
					}
				}
				catch (Exception)
				{
				}
			}
			while (false);
		}

		public bool IsReadyForPrint(int QueueID)
		{
			bool result;
			do
			{
				PrinterBusniess.  = new PrinterBusniess.();
				. = QueueID;
				. = this;
				try
				{
					PrinterBusniess.  = new PrinterBusniess.();
					. = ;
					if (5 == 0)
					{
						goto IL_73;
					}
					. = new PrinterQueueInfo();
					do
					{
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					while (3 == 0);
					base.Start(false);
					IL_5F:
					if (. == null)
					{
						goto IL_80;
					}
					bool? is_Active = ..is_Active;
					IL_73:
					if (!is_Active.Value)
					{
						result = true;
						goto IL_A8;
					}
					IL_80:
					if (4 == 0)
					{
						goto IL_5F;
					}
					result = false;
				}
				catch (Exception)
				{
					do
					{
						result = false;
					}
					while (3 == 0 || false);
				}
				IL_A8:;
			}
			while (5 == 0);
			return result;
		}

		public List<AssociatedPrintersInfo> GetAssociatedPrintersforPrint(int? ProductType, int SubStoreID)
		{
			PrinterBusniess.  = new PrinterBusniess.();
			List<AssociatedPrintersInfo> result;
			do
			{
				. = ProductType;
				if (!false)
				{
					. = SubStoreID;
					. = this;
					try
					{
						PrinterBusniess.  = new PrinterBusniess.();
						. = ;
						. = new List<AssociatedPrintersInfo>();
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (6 != 0)
						{
							result = .;
						}
					}
					catch (Exception)
					{
						do
						{
							result = null;
						}
						while (2 == 0);
					}
				}
			}
			while (3 == 0);
			return result;
		}

		public List<PrinterQueueforPrint> GetPrinterQueue(int substoreID, ref string productypeId)
		{
			Func<PrinterQueueforPrint, bool> func = null;
			PrinterBusniess.  = new PrinterBusniess.();
			. = substoreID;
			. = this;
			List<PrinterQueueforPrint> result;
			try
			{
				Func<PrinterQueueforPrint, bool> func2 = null;
				PrinterBusniess.  = new PrinterBusniess.();
				. = ;
				. = productypeId;
				. = new List<PrinterQueueforPrint>();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				IEnumerable<PrinterQueueforPrint> enumerable;
				PrinterQueueforPrint printerQueueforPrint;
				if (string.IsNullOrEmpty(productypeId))
				{
					IEnumerable<PrinterQueueforPrint> arg_A1_0 = ..ToList<PrinterQueueforPrint>();
					if (func == null)
					{
						func = new Func<PrinterQueueforPrint, bool>(.);
					}
					enumerable = arg_A1_0.Where(func);
					if (enumerable == null)
					{
						productypeId = PrinterBusniess.(1327);
						result = new List<PrinterQueueforPrint>();
						return result;
					}
					if (enumerable.Count<PrinterQueueforPrint>() <= 0)
					{
						productypeId = PrinterBusniess.(1327);
						result = new List<PrinterQueueforPrint>();
						return result;
					}
					IEnumerable<PrinterQueueforPrint> arg_D4_0 = enumerable;
					if (PrinterBusniess. == null)
					{
						PrinterBusniess. = new Func<PrinterQueueforPrint, int>(PrinterBusniess.);
					}
					printerQueueforPrint = arg_D4_0.OrderBy(PrinterBusniess.).FirstOrDefault<PrinterQueueforPrint>();
					if (printerQueueforPrint == null)
					{
						productypeId = PrinterBusniess.(1327);
						goto IL_106;
					}
				}
				else
				{
					PrinterBusniess.  = new PrinterBusniess.();
					. = ;
					. = ;
					. = new List<string>();
					. = productypeId.Split(new char[]
					{
						','
					}).ToList<string>();
					IEnumerable<PrinterQueueforPrint> enumerable2 = ..ToList<PrinterQueueforPrint>().Where(new Func<PrinterQueueforPrint, bool>(.));
					if (enumerable2 != null)
					{
						if (enumerable2.Count<PrinterQueueforPrint>() <= 0)
						{
							productypeId = PrinterBusniess.(1327);
							result = new List<PrinterQueueforPrint>();
							return result;
						}
						string arg_230_0 = productypeId;
						string arg_230_1 = PrinterBusniess.(1317);
						IEnumerable<PrinterQueueforPrint> arg_218_0 = enumerable2;
						if (PrinterBusniess. == null)
						{
							PrinterBusniess. = new Func<PrinterQueueforPrint, int>(PrinterBusniess.);
						}
						productypeId = arg_230_0 + arg_230_1 + arg_218_0.OrderBy(PrinterBusniess.).FirstOrDefault<PrinterQueueforPrint>().DG_Orders_ProductType_pkey.ToString();
						if (!false)
						{
							IEnumerable<PrinterQueueforPrint> arg_25A_0 = enumerable2;
							if (PrinterBusniess. == null)
							{
								PrinterBusniess. = new Func<PrinterQueueforPrint, int>(PrinterBusniess.);
							}
							result = arg_25A_0.OrderBy(PrinterBusniess.).ToList<PrinterQueueforPrint>();
							return result;
						}
					}
					else
					{
						IEnumerable<PrinterQueueforPrint> arg_2A9_0 = ..ToList<PrinterQueueforPrint>();
						if (func2 == null)
						{
							func2 = new Func<PrinterQueueforPrint, bool>(.);
						}
						IEnumerable<PrinterQueueforPrint> enumerable3 = arg_2A9_0.Where(func2);
						if (enumerable3 == null)
						{
							productypeId = PrinterBusniess.(1327);
							result = new List<PrinterQueueforPrint>();
							return result;
						}
						if (enumerable3.Count<PrinterQueueforPrint>() > 0)
						{
							string arg_306_0 = productypeId;
							string arg_306_1 = PrinterBusniess.(1317);
							IEnumerable<PrinterQueueforPrint> arg_2EE_0 = enumerable3;
							if (PrinterBusniess. == null)
							{
								PrinterBusniess. = new Func<PrinterQueueforPrint, int>(PrinterBusniess.);
							}
							productypeId = arg_306_0 + arg_306_1 + arg_2EE_0.OrderBy(PrinterBusniess.).FirstOrDefault<PrinterQueueforPrint>().DG_Orders_ProductType_pkey.ToString();
							IEnumerable<PrinterQueueforPrint> arg_32A_0 = enumerable3;
							if (PrinterBusniess. == null)
							{
								PrinterBusniess. = new Func<PrinterQueueforPrint, int>(PrinterBusniess.);
							}
							result = arg_32A_0.OrderBy(PrinterBusniess.).ToList<PrinterQueueforPrint>();
							return result;
						}
						productypeId = PrinterBusniess.(1327);
						result = new List<PrinterQueueforPrint>();
						return result;
					}
				}
				productypeId = printerQueueforPrint.DG_Orders_ProductType_pkey.ToString();
				IL_106:
				IEnumerable<PrinterQueueforPrint> arg_124_0 = enumerable;
				if (PrinterBusniess. == null)
				{
					PrinterBusniess. = new Func<PrinterQueueforPrint, int>(PrinterBusniess.);
				}
				result = arg_124_0.OrderBy(PrinterBusniess.).ToList<PrinterQueueforPrint>();
			}
			catch (Exception)
			{
				result = new List<PrinterQueueforPrint>();
			}
			return result;
		}

		public PrinterQueueforPrint GetPrinterQueueforPrint(int SubStoreID, ref List<int> ProducttypeId)
		{
			Func<PrinterQueueforPrint, bool> func = null;
			if (5 != 0)
			{
			}
			. = SubStoreID;
			. = this;
			PrinterQueueforPrint result;
			try
			{
				if (ProducttypeId.Count == 0)
				{
					PrinterBusniess.  = new PrinterBusniess.();
					. = ;
					. = new List<PrinterQueueforPrint>();
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
					IEnumerable<PrinterQueueforPrint> arg_94_0 = ..ToList<PrinterQueueforPrint>();
					if (func == null)
					{
						func = new Func<PrinterQueueforPrint, bool>(.);
					}
					IEnumerable<PrinterQueueforPrint> enumerable = arg_94_0.Where(func);
					if (enumerable != null)
					{
						if (enumerable.Count<PrinterQueueforPrint>() > 0)
						{
							IEnumerable<PrinterQueueforPrint> arg_C4_0 = enumerable;
							if (PrinterBusniess. == null)
							{
								PrinterBusniess. = new Func<PrinterQueueforPrint, int>(PrinterBusniess.);
							}
							PrinterQueueforPrint printerQueueforPrint = arg_C4_0.OrderBy(PrinterBusniess.).FirstOrDefault<PrinterQueueforPrint>();
							ProducttypeId.Add(printerQueueforPrint.DG_Orders_ProductType_pkey);
							result = printerQueueforPrint;
						}
						else
						{
							result = new PrinterQueueforPrint();
						}
					}
					else
					{
						result = new PrinterQueueforPrint();
					}
				}
				else
				{
					Func<PrinterQueueforPrint, bool> func2 = null;
					PrinterBusniess.  = new PrinterBusniess.();
					. = ;
					. = new List<PrinterQueueforPrint>();
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
					. = ProducttypeId;
					if (ProducttypeId != null)
					{
						IEnumerable<PrinterQueueforPrint> arg_167_0 = ..ToList<PrinterQueueforPrint>();
						if (func2 == null)
						{
							func2 = new Func<PrinterQueueforPrint, bool>(.);
						}
						IEnumerable<PrinterQueueforPrint> enumerable2 = arg_167_0.Where(func2);
						if (enumerable2 != null)
						{
							if (enumerable2.Count<PrinterQueueforPrint>() > 0)
							{
								IEnumerable<PrinterQueueforPrint> arg_197_0 = enumerable2;
								if (PrinterBusniess. == null)
								{
									PrinterBusniess. = new Func<PrinterQueueforPrint, int>(PrinterBusniess.);
								}
								PrinterQueueforPrint printerQueueforPrint2 = arg_197_0.OrderBy(PrinterBusniess.).FirstOrDefault<PrinterQueueforPrint>();
								if (printerQueueforPrint2 != null)
								{
									ProducttypeId.Add(printerQueueforPrint2.DG_Orders_ProductType_pkey);
									result = printerQueueforPrint2;
								}
								else
								{
									ProducttypeId = new List<int>();
									result = new PrinterQueueforPrint();
								}
							}
							else
							{
								ProducttypeId = new List<int>();
								result = new PrinterQueueforPrint();
							}
						}
						else
						{
							ProducttypeId = new List<int>();
							result = new PrinterQueueforPrint();
						}
					}
					else
					{
						ProducttypeId = new List<int>();
						result = new PrinterQueueforPrint();
					}
				}
			}
			catch (Exception)
			{
				result = new PrinterQueueforPrint();
			}
			return result;
		}

		public List<PrinterQueueDetailsInfo> GetPrinterQueueDetails(string ordernumer)
		{
			if (!false && -1 != 0)
			{
			}
			. = ordernumer;
			. = this;
			List<PrinterQueueDetailsInfo> result;
			try
			{
				PrinterBusniess.  = new PrinterBusniess.();
				if (!false)
				{
					. = ;
				}
				. = new List<PrinterQueueDetailsInfo>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public void SetPrinterLog(int PhotoId, int UserId, int ProductTypeId)
		{
			PrinterBusniess.  = new PrinterBusniess.();
			. = this;
			new CustomBusineses();
			. = new PrintLogInfo();
			..PhotoId = PhotoId;
			..UserID = UserId;
			..ProductTypeId = ProductTypeId;
			..PrintTime = DateTime.Now;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
		}

		public bool SetDataToPrinterQueue(string PhotoId, int? ProductTypeId, int? DG_AssocatedPrinterId, bool DG_SentToPrinter, int orderDetailID)
		{
			if (8 != 0)
			{
			}
			. = PhotoId;
			. = ProductTypeId;
			. = DG_AssocatedPrinterId;
			. = DG_SentToPrinter;
			. = orderDetailID;
			. = this;
			bool result;
			try
			{
				PrinterBusniess.  = new PrinterBusniess.();
				. = ;
				if (5 != 0)
				{
					new PrinterQueueInfo();
					. = true;
					this.operation = new BaseBusiness.TransactionMethod(.);
					bool arg_93_0 = base.Start(false);
					if (!false && !false)
					{
						arg_93_0 = true;
					}
					result = arg_93_0;
				}
			}
			catch (Exception)
			{
				do
				{
					if (-1 != 0)
					{
						result = false;
					}
				}
				while (false);
			}
			return result;
		}

		public int GetAssociatedPrinterIdFromProductTypeId(int? ProductTypeId)
		{
			PrinterBusniess.  = new PrinterBusniess.();
			. = ProductTypeId;
			. = this;
			int result;
			try
			{
				PrinterBusniess.  = new PrinterBusniess.();
				int arg_7B_0;
				do
				{
					if (!false && !false)
					{
						. = ;
						. = new AssociatedPrintersInfo();
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (2 == 0)
						{
							continue;
						}
						arg_7B_0 = (base.Start(false) ? 1 : 0);
						if (false)
						{
							goto IL_7B;
						}
					}
					if (. == null)
					{
						goto IL_7E;
					}
				}
				while (false);
				arg_7B_0 = ..DG_AssociatedPrinters_Pkey;
				IL_7B:
				result = arg_7B_0;
				return result;
				IL_7E:
				result = 0;
			}
			catch (Exception)
			{
				result = 0;
			}
			return result;
		}

		public List<AssociatedPrintersInfo> GetAssociatedPrintersName(int substoreID)
		{
			if (!false && -1 != 0)
			{
			}
			. = substoreID;
			. = this;
			List<AssociatedPrintersInfo> result;
			try
			{
				PrinterBusniess.  = new PrinterBusniess.();
				if (!false)
				{
					. = ;
				}
				. = new List<AssociatedPrintersInfo>();
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public string GetPrinterNameFromID(int id)
		{
			PrinterBusniess. expr_EA = new PrinterBusniess.();
			PrinterBusniess. ;
			if (4 != 0)
			{
				 = expr_EA;
			}
			. = id;
			. = this;
			. = new AssociatedPrintersInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (. != null)
			{
				return string.Concat(new object[]
				{
					..DG_AssociatedPrinters_Name,
					PrinterBusniess.(2161),
					..DG_AssociatedPrinters_IsActive,
					PrinterBusniess.(2161),
					..DG_AssociatedPrinters_ProductType_ID,
					PrinterBusniess.(2161),
					..DG_AssociatedPrinters_PaperSize
				});
			}
			return null;
		}

		public bool DeletePrinter(int id)
		{
			if (true)
			{
				PrinterBusniess.  = new PrinterBusniess.();
				do
				{
					. = id;
				}
				while (false);
				if (6 == 0)
				{
					goto IL_3C;
				}
				. = this;
				this.operation = new BaseBusiness.TransactionMethod(.);
			}
			base.Start(false);
			IL_3B:
			IL_3C:
			int expr_3D = 1;
			if (expr_3D != 0)
			{
				return expr_3D != 0;
			}
			goto IL_3B;
		}

		public int AddImageToPrinterQueue(int ProductTypeId, List<string> Images, int OrderDetailedKey, bool IsBundled, bool GreenSpecPrint, List<PhotoPrintPositionDic> PhotoPrintPositionDicList, int MasterTemplateId = 1)
		{
			PrinterBusniess.  = new PrinterBusniess.();
			. = this;
			ProductBusiness productBusiness = new ProductBusiness();
			int associatedPrinterIdFromProductTypeId = this.GetAssociatedPrinterIdFromProductTypeId(new int?(ProductTypeId));
			. = -1;
			if (!IsBundled)
			{
				int num;
				int count;
				int arg_222_0;
				int arg_221_0;
				if (ProductTypeId == 98)
				{
					if (Images.Count % 2 == 1)
					{
						Images.Add(Images[Images.Count - 1]);
					}
					num = 0;
					count = Images.Count;
				}
				else
				{
					if (ProductTypeId == 79 && PhotoPrintPositionDicList != null)
					{
						Func<PhotoPrintPositionDic, bool> func = null;
						PrinterBusniess.  = new PrinterBusniess.();
						. = ;
						. = new List<int>();
						if (PrinterBusniess. == null)
						{
							PrinterBusniess. = new Func<PhotoPrintPositionDic, int>(PrinterBusniess.);
						}
						IEnumerable<int> arg_2A0_0 = PhotoPrintPositionDicList.Select(PrinterBusniess.).Distinct<int>();
						if (PrinterBusniess. == null)
						{
							PrinterBusniess. = new Func<int, int>(PrinterBusniess.);
						}
						using (List<int>.Enumerator enumerator = arg_2A0_0.OrderBy(PrinterBusniess.).ToList<int>().GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								Func<PhotoPrintPositionDic, bool> func2 = null;
								Func<PhotoPrintPositionDic, bool> func3 = null;
								PrinterBusniess.  = new PrinterBusniess.();
								. = ;
								. = ;
								. = enumerator.Current;
								Action<PhotoPrintPositionDic> action = null;
								Action<PhotoPrintPositionDic> action2 = null;
								PrinterBusniess.  = new PrinterBusniess.();
								. = ;
								. = ;
								. = ;
								. = string.Empty;
								ProductTypeInfo productType = productBusiness.GetProductType(ProductTypeId);
								if (!Convert.ToBoolean(productType.DG_IsAccessory))
								{
									PrinterBusniess.  = new PrinterBusniess.();
									. = ;
									. = ;
									. = ;
									. = ;
									if (func == null)
									{
										func = new Func<PhotoPrintPositionDic, bool>(.);
									}
									IEnumerable<PhotoPrintPositionDic> arg_39A_0 = PhotoPrintPositionDicList.Where(func);
									if (PrinterBusniess. == null)
									{
										PrinterBusniess. = new Func<PhotoPrintPositionDic, int>(PrinterBusniess.);
									}
									arg_39A_0.Min(PrinterBusniess.);
									string arg_3A5_0 = string.Empty;
									if (func2 == null)
									{
										func2 = new Func<PhotoPrintPositionDic, bool>(.);
									}
									IEnumerable<PhotoPrintPositionDic> arg_3DF_0 = PhotoPrintPositionDicList.Where(func2);
									if (PrinterBusniess. == null)
									{
										PrinterBusniess. = new Func<PhotoPrintPositionDic, int>(PrinterBusniess.);
									}
									List<PhotoPrintPositionDic> arg_3FE_0 = arg_3DF_0.OrderBy(PrinterBusniess.).ToList<PhotoPrintPositionDic>();
									if (action == null)
									{
										action = new Action<PhotoPrintPositionDic>(.);
									}
									arg_3FE_0.ForEach(action);
									. = string.Empty;
									if (func3 == null)
									{
										func3 = new Func<PhotoPrintPositionDic, bool>(.);
									}
									IEnumerable<PhotoPrintPositionDic> arg_448_0 = PhotoPrintPositionDicList.Where(func3);
									if (PrinterBusniess. == null)
									{
										PrinterBusniess. = new Func<PhotoPrintPositionDic, int>(PrinterBusniess.);
									}
									List<PhotoPrintPositionDic> arg_467_0 = arg_448_0.OrderBy(PrinterBusniess.).ToList<PhotoPrintPositionDic>();
									if (action2 == null)
									{
										action2 = new Action<PhotoPrintPositionDic>(.);
									}
									arg_467_0.ForEach(action2);
									. = new PrinterQueueInfo();
									..DG_Associated_PrinterId = new int?(associatedPrinterIdFromProductTypeId);
									..DG_PrinterQueue_Image_Pkey = ((..Length > 0) ? ..Substring(1) : string.Empty);
									..RotationAngle = ((..Length > 0) ? ..Substring(1) : string.Empty);
									..DG_PrinterQueue_ProductID = new int?(ProductTypeId);
									..DG_SentToPrinter = new bool?(false);
									..DG_Order_Details_Pkey = new int?(OrderDetailedKey);
									..is_Active = new bool?(true);
									..DG_IsSpecPrint = new bool?(GreenSpecPrint);
									..DG_Print_Date = new DateTime?(DateTime.Now);
									. = new PrinterQueueInfo();
									this.operation = new BaseBusiness.TransactionMethod(.);
									base.Start(false);
									if (. != null)
									{
										..QueueIndex = ..QueueIndex + 1;
									}
									else
									{
										..QueueIndex = new int?(1);
									}
									this.operation = new BaseBusiness.TransactionMethod(.);
									base.Start(false);
								}
							}
							goto IL_B81;
						}
					}
					arg_222_0 = ProductTypeId;
					int expr_617 = arg_221_0 = 100;
					if (expr_617 != 0)
					{
						if (ProductTypeId == expr_617)
						{
							int num2 = 1;
							using (List<string>.Enumerator enumerator2 = Images.GetEnumerator())
							{
								while (enumerator2.MoveNext())
								{
									string current = enumerator2.Current;
									ProductTypeInfo productType2 = productBusiness.GetProductType(ProductTypeId);
									if (!Convert.ToBoolean(productType2.DG_IsAccessory))
									{
										PrinterBusniess.  = new PrinterBusniess.();
										. = ;
										. = new PrinterQueueInfo();
										..DG_Associated_PrinterId = new int?(associatedPrinterIdFromProductTypeId);
										..DG_PrinterQueue_Image_Pkey = current;
										..DG_PrinterQueue_ProductID = new int?(ProductTypeId);
										..DG_SentToPrinter = new bool?(false);
										..DG_Order_Details_Pkey = new int?(OrderDetailedKey);
										..is_Active = new bool?(true);
										..DG_IsSpecPrint = new bool?(GreenSpecPrint);
										..DG_Print_Date = new DateTime?(DateTime.Now);
										. = new PrinterQueueInfo();
										this.operation = new BaseBusiness.TransactionMethod(.);
										base.Start(false);
										if (. != null)
										{
											..QueueIndex = ..QueueIndex + 1;
										}
										else
										{
											..QueueIndex = new int?(1);
										}
										this.operation = new BaseBusiness.TransactionMethod(.);
										base.Start(false);
										CalenderBusiness calenderBusiness = new CalenderBusiness();
										new List<ItemTemplateDetailModel>();
										IEnumerable<ItemTemplateDetailModel> arg_7D4_0 = calenderBusiness.GetItemTemplateDetail();
										if (PrinterBusniess. == null)
										{
											PrinterBusniess. = new Func<ItemTemplateDetailModel, bool>(PrinterBusniess.);
										}
										arg_7D4_0.Where(PrinterBusniess.).ToList<ItemTemplateDetailModel>();
										calenderBusiness.AddItemTemplatePrintOrder(new ItemTemplatePrintOrderModel
										{
											MasterTemplateId = MasterTemplateId,
											DetailTemplateId = num2,
											OrderLineItemId = .,
											PrinterQueueId = 0,
											PageNo = 0,
											PhotoId = 1,
											Status = 0,
											PrintTypeId = 0,
											PrintPosition = 0,
											RotationAngle = 0,
											CreatedBy = PrinterBusniess.(3289)
										});
										num2++;
									}
								}
								goto IL_B81;
							}
						}
						using (List<string>.Enumerator enumerator3 = Images.GetEnumerator())
						{
							while (enumerator3.MoveNext())
							{
								string current2 = enumerator3.Current;
								ProductTypeInfo productType3 = productBusiness.GetProductType(ProductTypeId);
								if (!Convert.ToBoolean(productType3.DG_IsAccessory))
								{
									PrinterBusniess.  = new PrinterBusniess.();
									. = ;
									. = new PrinterQueueInfo();
									..DG_Associated_PrinterId = new int?(associatedPrinterIdFromProductTypeId);
									..DG_PrinterQueue_Image_Pkey = current2;
									..DG_PrinterQueue_ProductID = new int?(ProductTypeId);
									..DG_SentToPrinter = new bool?(false);
									..DG_Order_Details_Pkey = new int?(OrderDetailedKey);
									..is_Active = new bool?(true);
									..DG_IsSpecPrint = new bool?(GreenSpecPrint);
									..DG_Print_Date = new DateTime?(DateTime.Now);
									. = new PrinterQueueInfo();
									this.operation = new BaseBusiness.TransactionMethod(.);
									base.Start(false);
									if (. != null)
									{
										..QueueIndex = ..QueueIndex + 1;
									}
									else
									{
										..QueueIndex = new int?(1);
									}
									this.operation = new BaseBusiness.TransactionMethod(.);
									base.Start(false);
								}
							}
							goto IL_B81;
						}
						goto IL_A20;
					}
					goto IL_220;
				}
				IL_21E:
				arg_222_0 = num;
				arg_221_0 = count;
				IL_220:
				if (arg_222_0 > arg_221_0 / 2)
				{
					goto IL_B81;
				}
				PrinterBusniess.  = new PrinterBusniess.();
				. = ;
				Images.ToArray();
				string dG_PrinterQueue_Image_Pkey = Images.ToArray()[num] + PrinterBusniess.(1317) + Images.ToArray()[num + 1];
				. = new PrinterQueueInfo();
				..DG_PrinterQueue_Image_Pkey = string.Join(PrinterBusniess.(1317), Images.ToArray());
				..DG_PrinterQueue_Image_Pkey = dG_PrinterQueue_Image_Pkey;
				..DG_Associated_PrinterId = new int?(associatedPrinterIdFromProductTypeId);
				..DG_PrinterQueue_ProductID = new int?(ProductTypeId);
				..is_Active = new bool?(true);
				..DG_SentToPrinter = new bool?(false);
				..DG_Order_Details_Pkey = new int?(OrderDetailedKey);
				..DG_IsSpecPrint = new bool?(GreenSpecPrint);
				..DG_Print_Date = new DateTime?(DateTime.Now);
				. = new PrinterQueueInfo();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				if (. != null)
				{
					..QueueIndex = ..QueueIndex + 1;
				}
				else
				{
					..QueueIndex = new int?(1);
				}
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				num += 2;
				goto IL_21E;
			}
			IL_A20:
			PrinterBusniess.  = new PrinterBusniess.();
			. = ;
			. = new PrinterQueueInfo();
			..DG_Associated_PrinterId = new int?(associatedPrinterIdFromProductTypeId);
			..DG_PrinterQueue_Image_Pkey = string.Join(PrinterBusniess.(1317), Images.ToArray());
			..DG_PrinterQueue_ProductID = new int?(ProductTypeId);
			..is_Active = new bool?(true);
			..DG_SentToPrinter = new bool?(false);
			..DG_Order_Details_Pkey = new int?(OrderDetailedKey);
			..DG_IsSpecPrint = new bool?(GreenSpecPrint);
			..DG_Print_Date = new DateTime?(DateTime.Now);
			. = new PrinterQueueInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			if (. != null)
			{
				..QueueIndex = ..QueueIndex + 1;
			}
			else
			{
				..QueueIndex = new int?(1);
			}
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			IL_B81:
			return .;
		}

		public List<AssociatedPrintersInfo> GetPrinterDetails(int substoreID)
		{
			PrinterBusniess.  = new PrinterBusniess.();
			. = substoreID;
			. = this;
			. = new List<AssociatedPrintersInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public void SetPrinterDetails(string PrinterName, int productType, bool isactive, string Papersize, int SubStoreId)
		{
			PrinterBusniess.  = new PrinterBusniess.();
			if (4 != 0)
			{
				. = PrinterName;
				. = productType;
				. = isactive;
				do
				{
					if (8 != 0)
					{
						. = Papersize;
						if (false)
						{
							goto IL_4C;
						}
						. = SubStoreId;
					}
				}
				while (7 == 0);
				. = this;
				IL_4C:
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
			}
		}

		public void SetPrintQueueIndex(int pkey, string flag)
		{
			PrinterBusniess. ;
			if (!false)
			{
				PrinterBusniess. expr_49 = new PrinterBusniess.();
				if (!false)
				{
					 = expr_49;
				}
				. = pkey;
			}
			while (true)
			{
				. = flag;
				while (true)
				{
					if (!false)
					{
						. = this;
						this.operation = new BaseBusiness.TransactionMethod(.);
					}
					base.Start(false);
					if (false)
					{
						break;
					}
					if (!false)
					{
						return;
					}
				}
			}
		}

		public List<PrinterQueueInfo> GetPrinterQueueForUpdown(int substoreID)
		{
			if (4 == 0)
			{
				goto IL_56;
			}
			PrinterBusniess.  = new PrinterBusniess.();
			if (4 == 0 || !true)
			{
				goto IL_5E;
			}
			. = substoreID;
			IL_22:
			. = this;
			. = new List<PrinterQueueInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_56:
			base.Start(false);
			IL_5E:
			if (. != null)
			{
				if (2 != 0)
				{
					IEnumerable<PrinterQueueInfo> arg_8C_0 = .;
					if (PrinterBusniess. == null)
					{
						PrinterBusniess. = new Func<PrinterQueueInfo, int?>(PrinterBusniess.);
					}
					return arg_8C_0.OrderBy(PrinterBusniess.).ToList<PrinterQueueInfo>();
				}
				goto IL_56;
			}
			else
			{
				if (!false)
				{
					return new List<PrinterQueueInfo>();
				}
				goto IL_22;
			}
		}

		public void SetPrinterQueueForReprint(int QueueId)
		{
			PrinterBusniess. ;
			while (true)
			{
				PrinterBusniess. expr_3C = new PrinterBusniess.();
				if (!false)
				{
					 = expr_3C;
				}
				while (!false)
				{
					. = QueueId;
					if (4 != 0)
					{
						goto Block_1;
					}
				}
			}
			Block_1:
			. = this;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
		}

		public void UpdatePrintCountForReprint(int QueueId)
		{
			PrinterBusniess. ;
			while (true)
			{
				PrinterBusniess. expr_3C = new PrinterBusniess.();
				if (!false)
				{
					 = expr_3C;
				}
				while (!false)
				{
					. = QueueId;
					if (4 != 0)
					{
						goto Block_1;
					}
				}
			}
			Block_1:
			. = this;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
		}

		public PrinterQueueInfo GetQueueDetail(int Name)
		{
			PrinterBusniess.  = new PrinterBusniess.();
			. = Name;
			. = this;
			. = new PrinterQueueInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public ObservableCollection<PrinterJobInfo> GetPrinterJobInfo(DataTable Dudt_PrintJobInfot, string PrinterName, string DigiFolderThumbnailPath)
		{
			PrinterBusniess.  = new PrinterBusniess.();
			. = Dudt_PrintJobInfot;
			. = PrinterName;
			. = DigiFolderThumbnailPath;
			. = this;
			. = new ObservableCollection<PrinterJobInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public void SaveAlbumPrintPosition(int OrderLineItemId, List<PhotoPrintPositionDic> PrintPhotoOrderIds)
		{
			if (PrintPhotoOrderIds != null)
			{
				PrinterBusniess.  = new PrinterBusniess.();
				. = this;
				. = new DataTable();
				..Columns.Add(PrinterBusniess.(3294), typeof(int));
				..Columns.Add(PrinterBusniess.(3315), typeof(int));
				..Columns.Add(PrinterBusniess.(3328), typeof(int));
				..Columns.Add(PrinterBusniess.(3337), typeof(int));
				..Columns.Add(PrinterBusniess.(3358), typeof(int));
				foreach (PhotoPrintPositionDic current in PrintPhotoOrderIds)
				{
					DataRow dataRow = ..NewRow();
					dataRow[PrinterBusniess.(3294)] = OrderLineItemId;
					dataRow[PrinterBusniess.(3315)] = current.PhotoId;
					dataRow[PrinterBusniess.(3328)] = current.PhotoPrintPositionList.PageNo;
					dataRow[PrinterBusniess.(3337)] = current.PhotoPrintPositionList.PhotoPosition;
					dataRow[PrinterBusniess.(3358)] = current.PhotoPrintPositionList.RotationAngle;
					..Rows.Add(dataRow);
				}
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
			}
		}

		public List<PrinterDetailsInfo> GetAssociatedPrinters(int? productType)
		{
			PrinterBusniess.  = new PrinterBusniess.();
			. = productType;
			. = this;
			. = new List<PrinterDetailsInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<PrinterQueueInfo> GetPrintLogDetails()
		{
			if (!false)
			{
				if (!false)
				{
				}
				do
				{
					. = this;
				}
				while (false);
				. = new List<PrinterQueueInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				while (2 == 0);
				base.Start(false);
			}
			return .;
		}

		public string SelectQRCode(int productId)
		{
			if (!false && -1 != 0)
			{
			}
			. = productId;
			. = this;
			string result;
			try
			{
				PrinterBusniess.  = new PrinterBusniess.();
				if (!false)
				{
					. = ;
				}
				. = string.Empty;
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		public string CheckSpecSetting(int PrinterId)
		{
			if (!false && -1 != 0)
			{
			}
			. = PrinterId;
			. = this;
			string result;
			try
			{
				PrinterBusniess.  = new PrinterBusniess.();
				if (!false)
				{
					. = ;
				}
				. = string.Empty;
				if (6 != 0)
				{
					base.Operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch (Exception)
			{
				result = null;
			}
			return result;
		}

		[CompilerGenerated]
		private static int (PrinterQueueforPrint )
		{
			return .QueueIndex;
		}

		[CompilerGenerated]
		private static int (PrinterQueueforPrint )
		{
			return .QueueIndex;
		}

		[CompilerGenerated]
		private static int (PrinterQueueforPrint )
		{
			return .DG_PrinterQueue_Pkey;
		}

		[CompilerGenerated]
		private static int (PrinterQueueforPrint )
		{
			return .QueueIndex;
		}

		[CompilerGenerated]
		private static int (PrinterQueueforPrint )
		{
			return .QueueIndex;
		}

		[CompilerGenerated]
		private static int (PrinterQueueforPrint )
		{
			return .QueueIndex;
		}

		[CompilerGenerated]
		private static int (PrinterQueueforPrint )
		{
			return .QueueIndex;
		}

		[CompilerGenerated]
		private static int (PrinterQueueforPrint )
		{
			return .QueueIndex;
		}

		[CompilerGenerated]
		private static int (PhotoPrintPositionDic )
		{
			return .PhotoPrintPositionList.PageNo;
		}

		[CompilerGenerated]
		private static int (int )
		{
			return ;
		}

		[CompilerGenerated]
		private static int (PhotoPrintPositionDic )
		{
			return .PhotoId;
		}

		[CompilerGenerated]
		private static int (PhotoPrintPositionDic )
		{
			return .PhotoPrintPositionList.PhotoPosition;
		}

		[CompilerGenerated]
		private static int (PhotoPrintPositionDic )
		{
			return .PhotoPrintPositionList.PhotoPosition;
		}

		[CompilerGenerated]
		private static bool (ItemTemplateDetailModel )
		{
			return .MasterTemplateId == 1;
		}

		[CompilerGenerated]
		private static int? (PrinterQueueInfo )
		{
			return .QueueIndex;
		}

		static PrinterBusniess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(PrinterBusniess));
		}
	}
}
