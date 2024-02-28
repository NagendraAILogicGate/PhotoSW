//using DigiPhoto.IMIX.Model;
//using DigiPhoto.Utility.Repository.ValueType;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class PrinterTypeAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getPrinterTypeAccess;
        public PrinterTypeAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public PrinterTypeAccess()
		{
		}

		public bool SaveUpdatePrinterType(PrinterTypeInfo printInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(49692), printInfo.PrinterTypeID);
			base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(49713), printInfo.PrinterType);
			base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(49730), printInfo.ProductTypeID);
			base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(27899), printInfo.IsActive);
			base.ExecuteNonQuery(PrinterTypeAccess.getPrinterTypeAccess(49751));
			return true;
		}

		public List<PrinterTypeInfo> GetPrinterTypeList(int PrinterTypeId)
		{
			List<PrinterTypeInfo> result;
			while (true)
			{
				if (false)
				{
					goto IL_41;
				}
				List<SqlParameter> expr_55 = base.DBParameters;
				if (!false)
				{
					expr_55.Clear();
				}
				if (-1 != 0)
				{
					base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(49692), PrinterTypeId);
					goto IL_25;
				}
				IL_4A:
				if (!true)
				{
					continue;
				}
				if (!false)
				{
					break;
				}
				IL_41:
				IDataReader dataReader;
				if (-1 != 0)
				{
					dataReader.Close();
					goto IL_4A;
				}
				IL_25:
				dataReader = base.ExecuteReader(PrinterTypeAccess.getPrinterTypeAccess(49780));
				result = this.printerTypeInfo(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<PrinterTypeInfo> printerTypeInfo ( IDataReader dataReader)
		{
			List<PrinterTypeInfo> list = new List<PrinterTypeInfo>();
			while (dataReader.Read())
			{
				list.Add(new PrinterTypeInfo
				{
					PrinterTypeID = base.GetFieldValue(dataReader, PrinterTypeAccess.getPrinterTypeAccess(49805), 0),
					PrinterType = base.GetFieldValue(dataReader, PrinterTypeAccess.getPrinterTypeAccess(49826), string.Empty),
					ProductTypeID = base.GetFieldValue(dataReader, PrinterTypeAccess.getPrinterTypeAccess(49843), 0),
					ProductName = base.GetFieldValue(dataReader, PrinterTypeAccess.getPrinterTypeAccess(27687), string.Empty),
					IsActive = base.GetFieldValue(dataReader, PrinterTypeAccess.getPrinterTypeAccess(3530), false)
				});
			}
			return list;
		}

		public bool DeletePrinterType(int PrinterTypeId)
		{
			base.DBParameters.Clear();
			base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(49692), PrinterTypeId);
			base.ExecuteNonQuery(PrinterTypeAccess.getPrinterTypeAccess(49864));
			return true;
		}

		public bool SaveOrActivateNewPrinter(string PrinterName, int SubstoreId, bool active)
		{
			base.DBParameters.Clear();
			if (8 != 0)
			{
				base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(49893), PrinterName);
			}
			do
			{
				base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(13308), SubstoreId);
				base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(49910), active);
                base.ExecuteNonQuery(PrinterTypeAccess.getPrinterTypeAccess(49935));
                //base.ExecuteNonQuery(PrinterTypeAccess.(49935)).ToInt32(false);
                }
			while (5 == 0);
			return true;
		}

		public bool RemapNewPrinter(string PrinterName, int SubstoreId, bool active)
		{
			base.DBParameters.Clear();
			if (8 != 0)
			{
				base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(49968), PrinterName);
			}
			do
			{
				base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(13308), SubstoreId);
				base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(49910), active);
                //base.ExecuteNonQuery(PrinterTypeAccess.(50001)).ToInt32(false);
                base.ExecuteNonQuery(PrinterTypeAccess.getPrinterTypeAccess(50001));
                }
			while (5 == 0);
			return true;
		}

		public bool DeleteAssociatedPrinters(int SubstoreId)
		{
			if (!false)
			{
				if (!false)
				{
					base.DBParameters.Clear();
				}
				if (7 != 0)
				{
					base.AddParameter(PrinterTypeAccess.getPrinterTypeAccess(13308), SubstoreId);
                    //base.ExecuteNonQuery(PrinterTypeAccess.(50026)).ToInt32(false);
                    base.ExecuteNonQuery(PrinterTypeAccess.getPrinterTypeAccess(50026));
                    }
			}
			IL_3F:
			int expr_41 = 1;
			if (expr_41 != 0)
			{
				return expr_41 != 0;
			}
			goto IL_3F;
		}

		static PrinterTypeAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(PrinterTypeAccess));
		}
	}
}
