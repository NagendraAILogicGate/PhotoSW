
using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;

namespace PhotoSW.IMIX.DataAccess
{
	public class PrinterQueueDao : BaseDataAccess
	{
		

        internal static SmartAssembly.Delegates.GetString getPrinterQueueDao;

		public PrinterQueueDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public PrinterQueueDao()
		{
		}

		public List<PrinterQueueInfo> GetAllFilteredPrinterQueue()
		{
			IDataReader dataReader=null;
			List<PrinterQueueInfo> result;
			while (true)
			{
                //if (!false)
                //{
                //    dataReader = base.ExecuteReader(#1j.#Lh);
                //}
				while (!false)
				{
					List<PrinterQueueInfo> expr_3A = this.PrinterQueueInfopc(dataReader);
					if (!false)
					{
						result = expr_3A;
					}
					if (7 == 0)
					{
						break;
					}
					if (8 != 0)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			dataReader.Close();
			return result;
		}

		private List<PrinterQueueInfo> PrinterQueueInfopc(IDataReader IDataReader)
		{
			List<PrinterQueueInfo> list = new List<PrinterQueueInfo>();
			while (IDataReader.Read())
			{
				PrinterQueueInfo item = new PrinterQueueInfo
				{
					DG_PrinterQueue_Pkey = base.GetFieldValue(IDataReader,               PrinterQueueDao.getPrinterQueueDao(22960), 0),
					DG_Order_Details_Pkey = new int?(base.GetFieldValue(IDataReader,     PrinterQueueDao.getPrinterQueueDao(22989), 0)),
					DG_SentToPrinter = new bool?(base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(23018), false)),
					DG_AssociatedPrinters_Name = base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(1331), string.Empty),
					DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(2818), string.Empty),
					DG_Photos_RFID = base.GetFieldValue(IDataReader,                     PrinterQueueDao.getPrinterQueueDao(20754), string.Empty),
					DG_Associated_PrinterId = new int?(base.GetFieldValue(IDataReader,   PrinterQueueDao.getPrinterQueueDao(23043), 0)),
					DG_PrinterQueue_ProductID = new int?(base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(23076), 0)),
					is_Active = new bool?(base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(23113), false)),
					QueueIndex = new int?(base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(23126), 0)),
					DG_Orders_ProductType_pkey = base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(2956), 0),
					DG_Orders_Number = base.GetFieldValue(IDataReader,                   PrinterQueueDao.getPrinterQueueDao(16649), string.Empty),
					DG_Orders_pkey = base.GetFieldValue(IDataReader,                     PrinterQueueDao.getPrinterQueueDao(16628), 0),
					DG_Order_SubStoreId = base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(17721), 0),
					DG_Photos_ID = base.GetFieldValue(IDataReader,                       PrinterQueueDao.getPrinterQueueDao(15038), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public List<PrinterQueueInfo> GetAllFilteredPrinterQueueBySubStoreId(int substoreID)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(1119), substoreID);
			}
			IDataReader dataReader=null;
			List<PrinterQueueInfo> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#Me);
				if (3 != 0)
				{
					result = this.PrinterQueueInfoqc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<PrinterQueueInfo> PrinterQueueInfoqc(IDataReader IDataReader)
		{
			List<PrinterQueueInfo> list = new List<PrinterQueueInfo>();
			while (IDataReader.Read())
			{
				PrinterQueueInfo item = new PrinterQueueInfo
				{
					DG_PrinterQueue_Pkey = base.GetFieldValue(IDataReader,               PrinterQueueDao.getPrinterQueueDao(22960), 0),
					DG_Order_Details_Pkey = new int?(base.GetFieldValue(IDataReader,     PrinterQueueDao.getPrinterQueueDao(22989), 0)),
					DG_SentToPrinter = new bool?(base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(23018), false)),
					DG_AssociatedPrinters_Name = base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(1331), string.Empty),
					DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(2818), string.Empty),
					DG_Photos_RFID = base.GetFieldValue(IDataReader,                     PrinterQueueDao.getPrinterQueueDao(20754), string.Empty),
					DG_Associated_PrinterId = new int?(base.GetFieldValue(IDataReader,   PrinterQueueDao.getPrinterQueueDao(23043), 0)),
					DG_PrinterQueue_ProductID = new int?(base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(23076), 0)),
					is_Active = new bool?(base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(23113), false)),
					QueueIndex = new int?(base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(23126), 0)),
					DG_Orders_ProductType_pkey = base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(2956), 0),
					DG_Orders_Number = base.GetFieldValue(IDataReader,                   PrinterQueueDao.getPrinterQueueDao(16649), string.Empty),
					DG_Orders_pkey = base.GetFieldValue(IDataReader,                     PrinterQueueDao.getPrinterQueueDao(16628), 0),
					DG_Order_SubStoreId = base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(17721), 0),
					DG_Photos_ID = base.GetFieldValue(IDataReader,                       PrinterQueueDao.getPrinterQueueDao(15038), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public List<PrinterQueueInfo> Select()
		{
			IDataReader dataReader=null;
			List<PrinterQueueInfo> result;
			while (true)
			{
                //if (!false)
                //{
                //    dataReader = base.ExecuteReader(#1j.#Ih);
                //}
				while (!false)
				{
					List<PrinterQueueInfo> expr_3A = this.PrinterQueueInforc(dataReader);
					if (!false)
					{
						result = expr_3A;
					}
					if (7 == 0)
					{
						break;
					}
					if (8 != 0)
					{
						goto Block_3;
					}
				}
			}
			Block_3:
			dataReader.Close();
			return result;
		}

		public PrinterQueueInfo Get()
		{
			IDataReader expr_26 = null;//base.ExecuteReader(#1j.#Jh);
			IDataReader dataReader;
			if (!false)
			{
				dataReader = expr_26;
			}
			List<PrinterQueueInfo> source = this.PrinterQueueInforc(dataReader);
			if (!false)
			{
				dataReader.Close();
			}
			return source.FirstOrDefault<PrinterQueueInfo>();
		}

		private List<PrinterQueueInfo> PrinterQueueInforc(IDataReader IDataReader)
		{
			List<PrinterQueueInfo> list = new List<PrinterQueueInfo>();
			while (IDataReader.Read())
			{
				PrinterQueueInfo printerQueueInfo = new PrinterQueueInfo();
				if (!false)
				{
					printerQueueInfo.DG_PrinterQueue_Pkey = base.GetFieldValue(IDataReader,               PrinterQueueDao.getPrinterQueueDao(22960), 0);
					printerQueueInfo.DG_PrinterQueue_ProductID = new int?(base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(23076), 0));
					printerQueueInfo.DG_PrinterQueue_Image_Pkey = base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(23143), string.Empty);
					printerQueueInfo.DG_Associated_PrinterId = new int?(base.GetFieldValue(IDataReader,   PrinterQueueDao.getPrinterQueueDao(23043), 0));
					printerQueueInfo.DG_Order_Details_Pkey = new int?(base.GetFieldValue(IDataReader,     PrinterQueueDao.getPrinterQueueDao(22989), 0));
					printerQueueInfo.DG_SentToPrinter = new bool?(base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(23018), false));
					printerQueueInfo.is_Active = new bool?(base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(23113), false));
					printerQueueInfo.QueueIndex = new int?(base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(23126), 0));
				}
				printerQueueInfo.DG_IsSpecPrint = new bool?(base.GetFieldValue(IDataReader,               PrinterQueueDao.getPrinterQueueDao(23180), false));
				printerQueueInfo.DG_Print_Date = new DateTime?(base.GetFieldValue(IDataReader,            PrinterQueueDao.getPrinterQueueDao(23201), DateTime.Now));
				printerQueueInfo.RotationAngle = base.GetFieldValue(IDataReader,                          PrinterQueueDao.getPrinterQueueDao(23222), string.Empty);
				PrinterQueueInfo item = printerQueueInfo;
				list.Add(item);
			}
			return list;
		}

		public int Add(PrinterQueueInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23243), objectInfo.DG_PrinterQueue_Pkey);
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23280), objectInfo.DG_PrinterQueue_ProductID);
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23325), objectInfo.DG_Associated_PrinterId);
			if (5 != 0)
			{
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23366), objectInfo.DG_Order_Details_Pkey);
			}
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23403), objectInfo.QueueIndex);
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23428), objectInfo.DG_Print_Date);
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23457), objectInfo.DG_SentToPrinter);
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23490), objectInfo.is_Active);
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23511), objectInfo.DG_IsSpecPrint);
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23540), objectInfo.DG_PrinterQueue_Pkey, ParameterDirection.Output);
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23569), objectInfo.DG_PrinterQueue_Image_Pkey);
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23614), objectInfo.RotationAngle);
			//base.ExecuteNonQuery(#1j.#Kh);
			return (int)base.GetOutParameterValue(PrinterQueueDao.getPrinterQueueDao (23540));
		}

		public List<PrinterQueueInfo> GetPrinterQueueDetails(int QueueID)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao (23643), QueueID);
			}
			IDataReader dataReader=null;
			List<PrinterQueueInfo> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#Wh);
				if (3 != 0)
				{
					result = this.PrinterQueueInfosc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<PrinterQueueInfo> PrinterQueueInfosc(IDataReader IDataReader)
		{
			List<PrinterQueueInfo> list = new List<PrinterQueueInfo>();
			while (true)
			{
				while (IDataReader.Read())
				{
					if (!false)
					{
						PrinterQueueInfo printerQueueInfo = new PrinterQueueInfo();
						printerQueueInfo.DG_Orders_pkey = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao (16628), 0);
						if (7 != 0)
						{
							printerQueueInfo.DG_Orders_Number = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao (16649), string.Empty);
							IL_6C:
							while (!false)
							{
								printerQueueInfo.DG_Orders_LineItems_pkey = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao (16695), 0);
								while (5 != 0)
								{
									printerQueueInfo.DG_Orders_ID = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao (16728), 0);
									printerQueueInfo.DG_Orders_ProductType_pkey = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(2956), 0);
									printerQueueInfo.DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(2818), string.Empty);
									if (-1 != 0)
									{
										printerQueueInfo.DG_PrinterQueue_Pkey = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao (22960), 0);
										if (-1 != 0)
										{
											printerQueueInfo.DG_PrinterQueue_ProductID = new int?(base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao (23076), 0));
											break;
										}
										goto IL_6C;
									}
								}
								printerQueueInfo.DG_PrinterQueue_Image_Pkey = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(23143), string.Empty);
								break;
							}
							printerQueueInfo.DG_Order_Details_Pkey = new int?(base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao (22989), 0));
							PrinterQueueInfo item = printerQueueInfo;
							if (false)
							{
								break;
							}
							list.Add(item);
						}
					}
				}
				break;
			}
			return list;
		}

		public PrinterQueueInfo GetPrinterQueueIsReadyForPrint(int PrinterQueuekey, bool SentToPrinter)
		{
			base.DBParameters.Clear();
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23656), PrinterQueuekey);
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23685), base.SetNullBoolValue(new bool?(SentToPrinter)));
			IDataReader dataReader =null; //base.ExecuteReader(#1j.#ii);
			List<PrinterQueueInfo> source = this.PrinterQueueInfotc(dataReader);
			dataReader.Close();
			return source.FirstOrDefault<PrinterQueueInfo>();
		}

		private List<PrinterQueueInfo> PrinterQueueInfotc(IDataReader IDataReader)
		{
			List<PrinterQueueInfo> list = new List<PrinterQueueInfo>();
			while (IDataReader.Read())
			{
				PrinterQueueInfo printerQueueInfo = new PrinterQueueInfo();
				if (!false)
				{
					printerQueueInfo.DG_PrinterQueue_Pkey = base.GetFieldValue(IDataReader,               PrinterQueueDao.getPrinterQueueDao(22960), 0);
					printerQueueInfo.DG_PrinterQueue_ProductID = new int?(base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(23076), 0));
					printerQueueInfo.DG_PrinterQueue_Image_Pkey = base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(23143), string.Empty);
					printerQueueInfo.DG_Associated_PrinterId = new int?(base.GetFieldValue(IDataReader,   PrinterQueueDao.getPrinterQueueDao(23043), 0));
					printerQueueInfo.DG_Order_Details_Pkey = new int?(base.GetFieldValue(IDataReader,     PrinterQueueDao.getPrinterQueueDao(22989), 0));
					printerQueueInfo.DG_SentToPrinter = new bool?(base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(23018), false));
					printerQueueInfo.is_Active = new bool?(base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(23113), false));
					printerQueueInfo.QueueIndex = new int?(base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(23126), 0));
				}
				printerQueueInfo.DG_IsSpecPrint = new bool?(base.GetFieldValue(IDataReader,               PrinterQueueDao.getPrinterQueueDao(23180), false));
				printerQueueInfo.DG_Print_Date = new DateTime?(base.GetFieldValue(IDataReader,            PrinterQueueDao.getPrinterQueueDao(23201), DateTime.Now));
				printerQueueInfo.RotationAngle = base.GetFieldValue(IDataReader,                          PrinterQueueDao.getPrinterQueueDao(23222), string.Empty);
				PrinterQueueInfo item = printerQueueInfo;
				list.Add(item);
			}
			return list;
		}

		public bool InsDataToPrinterQueue(string PhotoId, int? ProductTypeId, int? AssocatedPrinterId, bool SentToPrinter, int OrderDetailID)
		{
			if (!false)
			{
				base.DBParameters.Clear();
				if (5 == 0)
				{
					goto IL_B7;
				}
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(19610), ProductTypeId);
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23714), AssocatedPrinterId);
			}
			IL_5A:
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23751), OrderDetailID);
			do
			{
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23457), SentToPrinter);
			}
			while (false);
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(7504), PhotoId);
			//base.ExecuteNonQuery(#1j.#9i);
			IL_B7:
			if (!false)
			{
				return true;
			}
			goto IL_5A;
		}

		public void UpdatePrinterQueueForReprint(int QueueId)
		{
			while (true)
			{
				base.DBParameters.Clear();
				while (8 != 0)
				{
					base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23780), QueueId);
					if (7 != 0)
					{
						//base.ExecuteNonQuery(#1j.#Bj);
						if (!false)
						{
							return;
						}
						break;
					}
				}
			}
		}

		public void UpdatePrintCountForReprint(int QueueId)
		{
			while (true)
			{
				base.DBParameters.Clear();
				while (8 != 0)
				{
					base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23780), QueueId);
					if (7 != 0)
					{
						//base.ExecuteNonQuery(#1j.#Cj);
						if (!false)
						{
							return;
						}
						break;
					}
				}
			}
		}

		public void UpdatePrintQueueIndex(int Pkey, string Flag)
		{
			base.DBParameters.Clear();
			while (true)
			{
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(1144), Pkey);
				while (true)
				{
					base.AddParameter(PrinterQueueDao.getPrinterQueueDao (21641), Flag);
					//base.ExecuteNonQuery(#1j.#Dj);
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

		public List<AssociatedPrintersInfo> SelectAssociatedPrintersforPrint(int? ProductType_ID, int SubStoreID)
		{
			base.DBParameters.Clear();
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(1090), base.SetNullIntegerValue(ProductType_ID));
			List<AssociatedPrintersInfo> result;
			IDataReader dataReader=null;
			do
			{
				if (8 != 0)
				{
					if (false)
					{
						return result;
					}
					base.AddParameter(PrinterQueueDao.getPrinterQueueDao (1119), SubStoreID);
					//dataReader = base.ExecuteReader(#1j.#6f);
				}
				if (false)
				{
					goto IL_6F;
				}
			}
			while (4 == 0);
			result = this.AssociatedPrintersInfo7(dataReader);
			IL_6F:
			dataReader.Close();
			return result;
		}

		private List<AssociatedPrintersInfo> AssociatedPrintersInfo7(IDataReader IDataReader)
		{
			List<AssociatedPrintersInfo> list = new List<AssociatedPrintersInfo>();
			while (IDataReader.Read())
			{
				AssociatedPrintersInfo item = new AssociatedPrintersInfo
				{
					DG_AssociatedPrinters_Pkey = base.GetFieldValue(IDataReader,                 PrinterQueueDao.getPrinterQueueDao(1294), 0),
					DG_AssociatedPrinters_Name = base.GetFieldValue(IDataReader,                 PrinterQueueDao.getPrinterQueueDao(1331), string.Empty),
					DG_AssociatedPrinters_ProductType_ID = base.GetFieldValue(IDataReader,       PrinterQueueDao.getPrinterQueueDao(1368), 0),
					DG_AssociatedPrinters_IsActive = base.GetFieldValue(IDataReader,             PrinterQueueDao.getPrinterQueueDao(1417), false),
					DG_AssociatedPrinters_PaperSize = base.GetFieldValue(IDataReader,            PrinterQueueDao.getPrinterQueueDao(1458), string.Empty),
					DG_AssociatedPrinters_SubStoreID = new int?(base.GetFieldValue(IDataReader,  PrinterQueueDao.getPrinterQueueDao(1503), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public List<PrinterQueueforPrint> SelectPrinterQueue(int SubStoreID)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao (1119), SubStoreID);
			}
			IDataReader dataReader=null;
			List<PrinterQueueforPrint> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#5f);
				if (3 != 0)
				{
					result = this.PrinterQueueforPrintuc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<PrinterQueueforPrint> PrinterQueueforPrintuc(IDataReader IDataReader)
		{
			List<PrinterQueueforPrint> list = new List<PrinterQueueforPrint>();
			while (IDataReader.Read())
			{
				PrinterQueueforPrint printerQueueforPrint = new PrinterQueueforPrint();
				printerQueueforPrint.DG_PrinterQueue_Pkey = base.GetFieldValue(IDataReader,       PrinterQueueDao.getPrinterQueueDao(22960), 0);
				printerQueueforPrint.DG_Order_Details_Pkey = base.GetFieldValue(IDataReader,      PrinterQueueDao.getPrinterQueueDao(22989), 0);
				printerQueueforPrint.DG_SentToPrinter = base.GetFieldValue(IDataReader,           PrinterQueueDao.getPrinterQueueDao(23018), false);
				printerQueueforPrint.DG_AssociatedPrinters_Name = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(1331), string.Empty);
				printerQueueforPrint.DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(2818), string.Empty);
				do
				{
					printerQueueforPrint.DG_Photos_RFID = base.GetFieldValue(IDataReader,            PrinterQueueDao.getPrinterQueueDao(20754), string.Empty);
					printerQueueforPrint.DG_Associated_PrinterId = base.GetFieldValue(IDataReader,   PrinterQueueDao.getPrinterQueueDao(23043), 0);
					printerQueueforPrint.DG_PrinterQueue_ProductID = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(23076), 0);
					printerQueueforPrint.is_Active = base.GetFieldValue(IDataReader,                 PrinterQueueDao.getPrinterQueueDao(23113), false);
				}
				while (false);
				printerQueueforPrint.QueueIndex = base.GetFieldValue(IDataReader,                     PrinterQueueDao.getPrinterQueueDao(23126), 0);
				printerQueueforPrint.DG_Orders_ProductType_pkey = base.GetFieldValue(IDataReader,     PrinterQueueDao.getPrinterQueueDao(2956), 0);
				printerQueueforPrint.DG_Orders_Number = base.GetFieldValue(IDataReader,               PrinterQueueDao.getPrinterQueueDao(16649), string.Empty);
				printerQueueforPrint.DG_Orders_pkey = base.GetFieldValue(IDataReader,                 PrinterQueueDao.getPrinterQueueDao(16628), 0);
				printerQueueforPrint.DG_Order_SubStoreId = base.GetFieldValue(IDataReader,            PrinterQueueDao.getPrinterQueueDao(17721), 0);
				printerQueueforPrint.RotationAngle = base.GetFieldValue(IDataReader,                  PrinterQueueDao.getPrinterQueueDao(23222), string.Empty);
				printerQueueforPrint.DG_PrinterQueue_Image_Pkey = base.GetFieldValue(IDataReader,     PrinterQueueDao.getPrinterQueueDao(23143), string.Empty);
				printerQueueforPrint.DG_Order_ImageUniqueIdentifier = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(17808), string.Empty);
				printerQueueforPrint.DG_IsSpecPrint = base.GetFieldValue(IDataReader,                 PrinterQueueDao.getPrinterQueueDao(23180), false);
				PrinterQueueforPrint item = printerQueueforPrint;
				list.Add(item);
			}
			return list;
		}

		public void UpdateReadyForPrint(int QueueId)
		{
			while (true)
			{
				base.DBParameters.Clear();
				while (8 != 0)
				{
					base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23780), QueueId);
					if (7 != 0)
					{
						//base.ExecuteNonQuery(#1j.#4f);
						if (!false)
						{
							return;
						}
						break;
					}
				}
			}
		}

		public void UpdatePrinterQueue(int QueueId)
		{
			while (true)
			{
				base.DBParameters.Clear();
				while (8 != 0)
				{
					base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23780), QueueId);
					if (7 != 0)
					{
						//base.ExecuteNonQuery(#1j.#3f);
						if (!false)
						{
							return;
						}
						break;
					}
				}
			}
		}

		public List<PrinterQueueDetailsInfo> GetPrinterQueueDetailsByOrderNo(string OrderNumber)
		{
			IDataReader dataReader=null;
			List<PrinterQueueDetailsInfo> result;
			while (-1 != 0)
			{
				base.DBParameters.Clear();
				if (false)
				{
					break;
				}
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(19501), OrderNumber);
				if (8 != 0)
				{
					if (!false)
					{
						//dataReader = base.ExecuteReader(#1j.#2h);
						result = this.PrinterQueueDetailsInfo6(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private List<PrinterQueueDetailsInfo> PrinterQueueDetailsInfo6(IDataReader IDataReader)
		{
			List<PrinterQueueDetailsInfo> list = new List<PrinterQueueDetailsInfo>();
			IL_201:
			while (IDataReader.Read())
			{
				PrinterQueueDetailsInfo printerQueueDetailsInfo = new PrinterQueueDetailsInfo();
				printerQueueDetailsInfo.DG_AssociatedPrinters_Name = base.GetFieldValue(IDataReader,   PrinterQueueDao.getPrinterQueueDao(1331), string.Empty);
				printerQueueDetailsInfo.DG_Orders_pkey = base.GetFieldValue(IDataReader,               PrinterQueueDao.getPrinterQueueDao(16628), 0);
				printerQueueDetailsInfo.DG_Orders_Number = base.GetFieldValue(IDataReader,             PrinterQueueDao.getPrinterQueueDao(16649), string.Empty);
				printerQueueDetailsInfo.DG_Order_SubStoreId = base.GetFieldValue(IDataReader,          PrinterQueueDao.getPrinterQueueDao(17721), 0);
				printerQueueDetailsInfo.DG_Orders_ProductType_pkey = base.GetFieldValue(IDataReader,   PrinterQueueDao.getPrinterQueueDao(2956), 0);
				printerQueueDetailsInfo.DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader,   PrinterQueueDao.getPrinterQueueDao(2818), string.Empty);
				printerQueueDetailsInfo.DG_PrinterQueue_Pkey = base.GetFieldValue(IDataReader,         PrinterQueueDao.getPrinterQueueDao(22960), 0);
				printerQueueDetailsInfo.DG_PrinterQueue_ProductID = base.GetFieldValue(IDataReader,    PrinterQueueDao.getPrinterQueueDao(23076), 0);
				while (true)
				{
					printerQueueDetailsInfo.DG_Photos_pKey = base.GetFieldValue(IDataReader,           PrinterQueueDao.getPrinterQueueDao (23801), string.Empty);
					if (!true)
					{
						goto IL_201;
					}
					if (8 == 0)
					{
						break;
					}
					printerQueueDetailsInfo.DG_Associated_PrinterId = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(23043), 0);
					printerQueueDetailsInfo.DG_Order_Details_Pkey = base.GetFieldValue(IDataReader,   PrinterQueueDao.getPrinterQueueDao(22989), 0);
					if (7 != 0)
					{
						goto Block_3;
					}
				}
				IL_1BA:
				printerQueueDetailsInfo.QueueIndex = base.GetFieldValue(IDataReader,     PrinterQueueDao.getPrinterQueueDao(23126), 0);
				printerQueueDetailsInfo.DG_Photos_RFID = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(20754), string.Empty);
				PrinterQueueDetailsInfo item = printerQueueDetailsInfo;
				list.Add(item);
				continue;
				Block_3:
				printerQueueDetailsInfo.DG_SentToPrinter = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(23018), false);
				printerQueueDetailsInfo.is_Active = base.GetFieldValue(IDataReader,        PrinterQueueDao.getPrinterQueueDao(23113), false);
				goto IL_1BA;
			}
			return list;
		}

		public void InsertPrinterLog(PrintLogInfo objectInfo)
		{
			if (true)
			{
				base.DBParameters.Clear();
				if (7 != 0)
				{
					base.AddParameter(PrinterQueueDao.getPrinterQueueDao(7504), objectInfo.PhotoId);
				}
				if (false)
				{
					return;
				}
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(19610), objectInfo.ProductTypeId);
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23822), objectInfo.UserID);
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23839), objectInfo.PrintTime);
			}
			//base.ExecuteNonQuery(#1j.#ti);
		}

		public List<PrinterQueueforPrint> SelectFilteredPrinterQueueforPrint(int SubStoreID)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao (1119), SubStoreID);
			}
			IDataReader dataReader=null;
			List<PrinterQueueforPrint> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#1f);
				if (3 != 0)
				{
					result = this.PrinterQueueforPrintvc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<PrinterQueueforPrint> PrinterQueueforPrintvc(IDataReader IDataReader)
		{
			List<PrinterQueueforPrint> list = new List<PrinterQueueforPrint>();
			IL_201:
			while (IDataReader.Read())
			{
				PrinterQueueforPrint printerQueueforPrint = new PrinterQueueforPrint();
				printerQueueforPrint.DG_PrinterQueue_Pkey = base.GetFieldValue(IDataReader,       PrinterQueueDao.getPrinterQueueDao(22960), 0);
				printerQueueforPrint.DG_Order_Details_Pkey = base.GetFieldValue(IDataReader,      PrinterQueueDao.getPrinterQueueDao(22989), 0);
				printerQueueforPrint.DG_SentToPrinter = base.GetFieldValue(IDataReader,           PrinterQueueDao.getPrinterQueueDao(23018), false);
				printerQueueforPrint.DG_AssociatedPrinters_Name = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(1331), string.Empty);
				printerQueueforPrint.DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(2818), string.Empty);
				printerQueueforPrint.DG_Photos_RFID = base.GetFieldValue(IDataReader,             PrinterQueueDao.getPrinterQueueDao(20754), string.Empty);
				printerQueueforPrint.DG_Associated_PrinterId = base.GetFieldValue(IDataReader,    PrinterQueueDao.getPrinterQueueDao(23043), 0);
				printerQueueforPrint.DG_PrinterQueue_ProductID = base.GetFieldValue(IDataReader,  PrinterQueueDao.getPrinterQueueDao(23076), 0);
				while (true)
				{
					printerQueueforPrint.is_Active = base.GetFieldValue(IDataReader,               PrinterQueueDao.getPrinterQueueDao (23113), false);
					if (!true)
					{
						goto IL_201;
					}
					if (8 == 0)
					{
						break;
					}
					printerQueueforPrint.QueueIndex = base.GetFieldValue(IDataReader,                 PrinterQueueDao.getPrinterQueueDao(23126), 0);
					printerQueueforPrint.DG_Orders_ProductType_pkey = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(2956), 0);
					if (7 != 0)
					{
						goto Block_3;
					}
				}
				IL_1BA:
				printerQueueforPrint.DG_Order_SubStoreId = base.GetFieldValue(IDataReader,             PrinterQueueDao.getPrinterQueueDao(17721), 0);
				printerQueueforPrint.DG_Photos_ID = base.GetFieldValue(IDataReader,                    PrinterQueueDao.getPrinterQueueDao(15038), string.Empty);
				PrinterQueueforPrint item = printerQueueforPrint;
				list.Add(item);
				continue;
				Block_3:
				printerQueueforPrint.DG_Orders_Number = base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(16649), string.Empty);
				printerQueueforPrint.DG_Orders_pkey = base.GetFieldValue(IDataReader,                  PrinterQueueDao.getPrinterQueueDao(16628), 0);
				goto IL_1BA;
			}
			return list;
		}

		public void InsertPrinterQueue(DataTable Dt)
		{
			if (4 != 0)
			{
				base.DBParameters.Clear();
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(7504), Dt);
				//base.ExecuteNonQuery(#1j.#ti);
			}
		}

		public List<AssociatedPrintersInfo> SelectPrinterDetailsBySubStoreID(int substoreID)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao (1119), substoreID);
			}
			IDataReader dataReader=null;
			List<AssociatedPrintersInfo> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#kh);
				if (3 != 0)
				{
					result = this.AssociatedPrintersInfowc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<AssociatedPrintersInfo> AssociatedPrintersInfowc(IDataReader IDataReader)
		{
			List<AssociatedPrintersInfo> list = new List<AssociatedPrintersInfo>();
			while (IDataReader.Read())
			{
				AssociatedPrintersInfo item = new AssociatedPrintersInfo
				{
					DG_AssociatedPrinters_Pkey = base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(1294), 0),
					DG_AssociatedPrinters_Name = base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(1331), string.Empty),
					DG_AssociatedPrinters_ProductType_ID = base.GetFieldValue(IDataReader,      PrinterQueueDao.getPrinterQueueDao(1368), 0),
					DG_AssociatedPrinters_IsActive = base.GetFieldValue(IDataReader,            PrinterQueueDao.getPrinterQueueDao(1417), false),
					DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader,                PrinterQueueDao.getPrinterQueueDao(2818), string.Empty),
					DG_AssociatedPrinters_PaperSize = base.GetFieldValue(IDataReader,           PrinterQueueDao.getPrinterQueueDao(1458), string.Empty),
					DG_AssociatedPrinters_SubStoreID = new int?(base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(1503), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public PrinterQueueInfo GetPrinterQueue(int QueueID)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao (23643), QueueID);
			}
			IDataReader dataReader=null;
			PrinterQueueInfo result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#Wh);
				if (3 != 0)
				{
					result = this.PrinterQueueInfoxc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private PrinterQueueInfo PrinterQueueInfoxc(IDataReader IDataReader)
		{
			PrinterQueueInfo printerQueueInfo = new PrinterQueueInfo();
			while (IDataReader.Read())
			{
				do
				{
					printerQueueInfo.DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(2818), string.Empty);
					printerQueueInfo.DG_Orders_Number = base.GetFieldValue(IDataReader,           PrinterQueueDao.getPrinterQueueDao(16649), string.Empty);
				}
				while (7 == 0);
				printerQueueInfo.DG_Photos_RFID = base.GetFieldValue(IDataReader,           PrinterQueueDao.getPrinterQueueDao(23860), string.Empty);
				printerQueueInfo.DG_Orders_LineItems_pkey = base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(16695), 0);
				printerQueueInfo.DG_Photos_ID = base.GetFieldValue(IDataReader,             PrinterQueueDao.getPrinterQueueDao(23869), string.Empty);
			}
			return printerQueueInfo;
		}

		public ObservableCollection<PrinterJobInfo> GetPrinterJobInfo(DataTable Dudt_PrintJobInfot, string PrinterName, string DigiFolderThumbnailPath)
		{
			base.DBParameters.Clear();
			if (8 != 0)
			{
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23882), PrinterName);
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23907), DigiFolderThumbnailPath);
			}
			ObservableCollection<PrinterJobInfo> result;
			do
			{
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao (23948), Dudt_PrintJobInfot);
				IDataReader dataReader = null;//base.ExecuteReader(#1j.#Be);
				result = this.ObservableCollectionyc(dataReader);
				dataReader.Close();
			}
			while (5 == 0);
			return result;
		}

		private ObservableCollection<PrinterJobInfo> ObservableCollectionyc(IDataReader IDataReader)
		{
			ObservableCollection<PrinterJobInfo> observableCollection = new ObservableCollection<PrinterJobInfo>();
			while (IDataReader.Read())
			{
				PrinterJobInfo item = new PrinterJobInfo
				{
					DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader,     PrinterQueueDao.getPrinterQueueDao(2818), string.Empty),
					DG_Orders_Number = base.GetFieldValue(IDataReader,               PrinterQueueDao.getPrinterQueueDao(16649), string.Empty),
					RFID = base.GetFieldValue(IDataReader,                           PrinterQueueDao.getPrinterQueueDao(23860), string.Empty),
					DG_Orders_LineItems_pkey = base.GetFieldValue(IDataReader,       PrinterQueueDao.getPrinterQueueDao(16695), 0),
					PhotoID = base.GetFieldValue(IDataReader,                        PrinterQueueDao.getPrinterQueueDao(23869), string.Empty),
					Filepath1 = base.GetFieldValue(IDataReader,                      PrinterQueueDao.getPrinterQueueDao(23973), string.Empty),
					Printername = base.GetFieldValue(IDataReader,                    PrinterQueueDao.getPrinterQueueDao(24006), string.Empty),
					JobName = base.GetFieldValue(IDataReader,                        PrinterQueueDao.getPrinterQueueDao(24023), string.Empty),
					JobId = base.GetFieldValue(IDataReader,                          PrinterQueueDao.getPrinterQueueDao(24036), 0),
					JobStatus = base.GetFieldValue(IDataReader,                      PrinterQueueDao.getPrinterQueueDao(24057), string.Empty)
				};
				observableCollection.Add(item);
			}
			return observableCollection;
		}

		public void SaveAlbumPrintPosition(DataTable udt_Printer)
		{
			if (4 != 0)
			{
				base.DBParameters.Clear();
				base.AddParameter(PrinterQueueDao.getPrinterQueueDao(24070), udt_Printer);
				//base.ExecuteReader(#1j.#xe);
			}
		}

		public List<PrinterQueueInfo> GetPrintLogDetails()
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
			if (8 != 0)
			{
				//dataReader = base.ExecuteReader(#1j.#Ag);
			}
			List<PrinterQueueInfo> result = this.PrinterQueueInfozc(dataReader);
			dataReader.Close();
			return result;
		}

		private List<PrinterQueueInfo> PrinterQueueInfozc(IDataReader IDataReader)
		{
			List<PrinterQueueInfo> list = new List<PrinterQueueInfo>();
			while (IDataReader.Read())
			{
				PrinterQueueInfo printerQueueInfo = new PrinterQueueInfo();
				printerQueueInfo.DG_Orders_ProductType_Name = base.GetFieldValue(IDataReader,           PrinterQueueDao.getPrinterQueueDao(2818), string.Empty);
				printerQueueInfo.DG_Photos_FileName = base.GetFieldValue(IDataReader,                   PrinterQueueDao.getPrinterQueueDao(20700), string.Empty);
				if (2 != 0)
				{
					printerQueueInfo.DG_Photos_CreatedOn = new DateTime?(base.GetFieldValue(IDataReader, PrinterQueueDao.getPrinterQueueDao(20725), DateTime.MinValue));
					printerQueueInfo.DG_Print_Date = new DateTime?(base.GetFieldValue(IDataReader,       PrinterQueueDao.getPrinterQueueDao(23201), DateTime.MinValue));
					printerQueueInfo.PrintedBy = base.GetFieldValue(IDataReader,                         PrinterQueueDao.getPrinterQueueDao(24095), string.Empty);
					printerQueueInfo.TakenBy = base.GetFieldValue(IDataReader,                           PrinterQueueDao.getPrinterQueueDao(24108), string.Empty);
				}
				printerQueueInfo.ID = base.GetFieldValue(IDataReader,                                    PrinterQueueDao.getPrinterQueueDao(24121), 0);
				PrinterQueueInfo item = printerQueueInfo;
				list.Add(item);
			}
			return list;
		}

		public string SelectQRCode(int productId)
		{
			string result;
			do
			{
				result = string.Empty;
				if (false)
				{
					return result;
				}
				if (false)
				{
					goto IL_71;
				}
				base.DBParameters.Clear();
                string expr_BA = PrinterQueueDao.getPrinterQueueDao(22361);
				object expr_3B = productId;
				if (!false)
				{
					base.AddParameter(expr_BA, expr_3B);
				}
				if (2 == 0)
				{
					goto IL_71;
				}
			}
			while (false);
			IDataReader dataReader = base.ExecuteReader(PrinterQueueDao.getPrinterQueueDao(24126));
			if (!dataReader.Read())
			{
				goto IL_8C;
			}
			IL_71:
			result = (string)dataReader[PrinterQueueDao.getPrinterQueueDao(21269)];
			IL_8C:
			dataReader.Close();
			return result;
		}

		public string CheckSpecSetting(int printerId)
		{
			string expr_00 = string.Empty;
			string text;
			if (5 != 0)
			{
				text = expr_00;
			}
			base.DBParameters.Clear();
			base.AddParameter(PrinterQueueDao.getPrinterQueueDao(23366), printerId);
			IDataReader dataReader = base.ExecuteReader(PrinterQueueDao.getPrinterQueueDao(24147));
			if (dataReader.Read())
			{
				text = Convert.ToString(dataReader[PrinterQueueDao.getPrinterQueueDao(16728)]);
				if (text == PrinterQueueDao.getPrinterQueueDao(24172) || text == null)
				{
					text = PrinterQueueDao.getPrinterQueueDao(24173);
				}
			}
			dataReader.Close();
			return text;
		}

		static PrinterQueueDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(PrinterQueueDao));
		}
	}
}
