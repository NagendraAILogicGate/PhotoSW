//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class AssociatedPrintersDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getStr;

        public AssociatedPrintersDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public AssociatedPrintersDao()
		{
		}

		public int Add(AssociatedPrintersInfo objectInfo)
		{
			base.DBParameters.Clear();
			if (6 != 0)
			{
				base.AddParameter(AssociatedPrintersDao.getStr(1068), objectInfo.DG_AssociatedPrinters_ProductType_ID);
				base.AddParameter(AssociatedPrintersDao.getStr(1097), objectInfo.DG_AssociatedPrinters_SubStoreID);
				//if (false)
				//{
				//	goto IL_EA;
				//}
				base.AddParameter(AssociatedPrintersDao.getStr(1122), objectInfo.DG_AssociatedPrinters_Pkey, ParameterDirection.Output);
				base.AddParameter(AssociatedPrintersDao.getStr(1139), objectInfo.DG_AssociatedPrinters_PaperSize);
				base.AddParameter(AssociatedPrintersDao.getStr(1160), objectInfo.DG_AssociatedPrinters_Name);
				base.AddParameter(AssociatedPrintersDao.getStr(1177), objectInfo.DG_AssociatedPrinters_IsActive);
			}
            //base.ExecuteNonQuery(#1j.#lh);
            base.ExecuteNonQuery("");
			IL_EA:
			return (int)base.GetOutParameterValue(AssociatedPrintersDao.getStr(1122));
		}

		public bool Update(AssociatedPrintersInfo objectInfo)
		{
			return true;
		}

		public bool Delete(int objectvalueId)
		{
			base.DBParameters.Clear();
			base.AddParameter(AssociatedPrintersDao.getStr(1198), objectvalueId);
            //	base.ExecuteNonQuery(#1j.#ph);
            base.ExecuteNonQuery("");
			return true;
		}

		public AssociatedPrintersInfo Get(int? subStoreId)
		{
			List<AssociatedPrintersInfo> source;
			do
			{
				if (7 != 0 && !false)
				{
					base.DBParameters.Clear();
					base.AddParameter(AssociatedPrintersDao.getStr(1219), base.SetNullIntegerValue(subStoreId));
				}
				using (IDataReader dataReader = base.ExecuteReader(""))
				{
					source = this.associatedPrintersInfo(dataReader);
				}
			}
			while (-1 == 0);
			return source.FirstOrDefault<AssociatedPrintersInfo>();
		}

		public List<AssociatedPrintersInfo> Select(int? subStoreId)
		{
			List<AssociatedPrintersInfo> result;
			if (!false)
			{
				base.DBParameters.Clear();
				base.AddParameter(AssociatedPrintersDao.getStr(1219), base.SetNullIntegerValue(subStoreId));
				IDataReader dataReader = base.ExecuteReader("");
				try
				{
					result = this.associatedPrintersInfo(dataReader);
				}
				finally
				{
					if (dataReader != null && 2 != 0)
					{
						dataReader.Dispose();
					}
				}
			}
			return result;
		}

		private List<AssociatedPrintersInfo> associatedPrintersInfo ( IDataReader dataReader)
		{
			List<AssociatedPrintersInfo> list = new List<AssociatedPrintersInfo>();
			while (dataReader.Read())
			{
				AssociatedPrintersInfo item = new AssociatedPrintersInfo
				{
					DG_AssociatedPrinters_Pkey = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1272), 0),
					DG_AssociatedPrinters_Name = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1309), string.Empty),
					DG_AssociatedPrinters_ProductType_ID = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1346), 0),
					DG_AssociatedPrinters_IsActive = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1395), false),
					DG_AssociatedPrinters_PaperSize = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1436), string.Empty),
					DG_AssociatedPrinters_SubStoreID = new int?(base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1481), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public List<AssociatedPrintersInfo> SelectAssociatedPrinter(int? ProductTypeID)
		{
			base.DBParameters.Clear();
			base.AddParameter(AssociatedPrintersDao.getStr(1526), base.SetNullIntegerValue(ProductTypeID));
			IDataReader dataReader;
			List<AssociatedPrintersInfo> result;
			do
			{
                //dataReader = base.ExecuteReader(#1j.#ci);
                dataReader = base.ExecuteReader("");
				result = this.associatedPrintersInfo2(dataReader);
			}
			while (5 == 0);
			dataReader.Close();
			return result;
		}

		private List<AssociatedPrintersInfo> associatedPrintersInfo2 ( IDataReader dataReader2)
		{
			List<AssociatedPrintersInfo> list = new List<AssociatedPrintersInfo>();
			while (dataReader2.Read())
			{
				AssociatedPrintersInfo item = new AssociatedPrintersInfo
				{
					DG_AssociatedPrinters_Pkey = base.GetFieldValue(dataReader2, AssociatedPrintersDao.getStr(1272), 0),
					DG_AssociatedPrinters_Name = base.GetFieldValue(dataReader2, AssociatedPrintersDao.getStr(1309), string.Empty),
					DG_AssociatedPrinters_ProductType_ID = base.GetFieldValue(dataReader2, AssociatedPrintersDao.getStr(1346), 0),
					DG_AssociatedPrinters_IsActive = base.GetFieldValue(dataReader2, AssociatedPrintersDao.getStr(1395), false),
					DG_AssociatedPrinters_PaperSize = base.GetFieldValue(dataReader2, AssociatedPrintersDao.getStr(1436), string.Empty),
					DG_AssociatedPrinters_SubStoreID = new int?(base.GetFieldValue(dataReader2, AssociatedPrintersDao.getStr(1481), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public AssociatedPrintersInfo GetAssociatedPrintersByKey(int AssociatedPrinterskey)
		{
			base.DBParameters.Clear();
			base.AddParameter(AssociatedPrintersDao.getStr(1583), AssociatedPrinterskey);
			IDataReader dataReader;
			if (true && !false)
			{
                //dataReader = base.ExecuteReader(#1j.#fi);
                dataReader = base.ExecuteReader("");
			}
			List<AssociatedPrintersInfo> source;
			do
			{
				source = this.associatedPrintersInfo3(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<AssociatedPrintersInfo>();
		}

		private List<AssociatedPrintersInfo> associatedPrintersInfo3 ( IDataReader dataReader)
		{
			List<AssociatedPrintersInfo> list = new List<AssociatedPrintersInfo>();
			while (dataReader.Read())
			{
				AssociatedPrintersInfo item = new AssociatedPrintersInfo
				{
					DG_AssociatedPrinters_Pkey = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1272), 0),
					DG_AssociatedPrinters_Name = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1309), string.Empty),
					DG_AssociatedPrinters_ProductType_ID = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1346), 0),
					DG_AssociatedPrinters_IsActive = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1395), false),
					DG_AssociatedPrinters_PaperSize = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1436), string.Empty),
					DG_AssociatedPrinters_SubStoreID = new int?(base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1481), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public List<AssociatedPrintersInfo> SelectAssociatedPrinterInfo(int? ProductType_ID, int SubStoreID, bool IsActive)
		{
			base.DBParameters.Clear();
			base.AddParameter(AssociatedPrintersDao.getStr(1068), base.SetNullIntegerValue(ProductType_ID));
			base.AddParameter(AssociatedPrintersDao.getStr(1097), SubStoreID);
			base.AddParameter(AssociatedPrintersDao.getStr(1177), true);
            //IDataReader dataReader = base.ExecuteReader(#1j.#mh);
            IDataReader dataReader = base.ExecuteReader("");
			List <AssociatedPrintersInfo> result = this.associatedPrintersInfo4(dataReader);
			dataReader.Close();
			return result;
		}

		private List<AssociatedPrintersInfo> associatedPrintersInfo4 ( IDataReader dataReader)
		{
			List<AssociatedPrintersInfo> list = new List<AssociatedPrintersInfo>();
			while (dataReader.Read())
			{
				AssociatedPrintersInfo item = new AssociatedPrintersInfo
				{
					DG_AssociatedPrinters_Pkey = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1272), 0),
					DG_AssociatedPrinters_Name = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1309), string.Empty),
					DG_AssociatedPrinters_ProductType_ID = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1346), 0),
					DG_AssociatedPrinters_IsActive = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1395), false),
					DG_AssociatedPrinters_PaperSize = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1436), string.Empty),
					DG_AssociatedPrinters_SubStoreID = new int?(base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1481), 0))
				};
				list.Add(item);
			}
			return list;
		}

		public AssociatedPrintersInfo GetAssociatedPrinterIdFromPRoductTypeId(int? ProductTypeID)
		{
			List<SqlParameter> expr_42 = base.DBParameters;
			if (!false)
			{
				expr_42.Clear();
			}
			base.AddParameter(AssociatedPrintersDao.getStr(1526), base.SetNullIntegerValue(ProductTypeID));
			IDataReader dataReader = base.ExecuteReader("");
			List<AssociatedPrintersInfo> source = this.associatedPrintersInfo2(dataReader);
			dataReader.Close();
			return source.FirstOrDefault<AssociatedPrintersInfo>();
		}

		public void AddAndUpdatePrinterDetails(string PrinterName, int productType, bool isactive, string Papersize, int SubStoreId)
		{
			if (!false)
			{
				base.DBParameters.Clear();
			}
			string expr_D1 = AssociatedPrintersDao.getStr(1068);
			object expr_2B = productType;
			if (7 != 0)
			{
				base.AddParameter(expr_D1, expr_2B);
			}
			do
			{
				base.AddParameter(AssociatedPrintersDao.getStr(1097), SubStoreId);
			}
			while (3 == 0);
			base.AddParameter(AssociatedPrintersDao.getStr(1139), Papersize);
			base.AddParameter(AssociatedPrintersDao.getStr(1160), PrinterName);
			base.AddParameter(AssociatedPrintersDao.getStr(1177), isactive);
			base.ExecuteNonQuery("");
		}

		public List<PrinterDetailsInfo> GetAssociatedPrinters(int? ProductTypeID)
		{
			base.DBParameters.Clear();
			base.AddParameter(AssociatedPrintersDao.getStr(1624), base.SetNullIntegerValue(ProductTypeID));
			IDataReader dataReader;
			List<PrinterDetailsInfo> result;
			do
			{
				dataReader = base.ExecuteReader("");
				result = this.printerDetailsInfo(dataReader);
			}
			while (5 == 0);
			dataReader.Close();
			return result;
		}

		private List<PrinterDetailsInfo> printerDetailsInfo ( IDataReader dataReader)
		{
			List<PrinterDetailsInfo> list = new List<PrinterDetailsInfo>();
			while (true)
			{
				if (4 == 0)
				{
					goto IL_6B;
				}
				IL_72:
				PrinterDetailsInfo printerDetailsInfo;
				if (!dataReader.Read())
				{
					if (5 != 0)
					{
						break;
					}
				}
				else if (8 != 0)
				{
					if (5 == 0)
					{
						continue;
					}
					printerDetailsInfo = new PrinterDetailsInfo();
					printerDetailsInfo.PrinterName = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1653), string.Empty);
				}
				if (!false)
				{
					printerDetailsInfo.PrinterID = base.GetFieldValue(dataReader, AssociatedPrintersDao.getStr(1678), 0);
				}
				PrinterDetailsInfo item = printerDetailsInfo;
				IL_6B:
				list.Add(item);
				goto IL_72;
			}
			return list;
		}

		static AssociatedPrintersDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(AssociatedPrintersDao));
		}
	}
}
