//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class BillFormatDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getBillFormat;

        public BillFormatDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public BillFormatDao()
		{
		}

		public List<BillFormatInfo> Select()
		{
			base.DBParameters.Clear();
            //	IDataReader dataReader = base.ExecuteReader(#1j.#Sh);
            IDataReader dataReader = base.ExecuteReader("");
			List <BillFormatInfo> result;
			try
			{
				result = this.billFormatInfo(dataReader);
			}
			finally
			{
				while (false || dataReader != null)
				{
					if (!false)
					{
						dataReader.Dispose();
						break;
					}
				}
			}
			return result;
		}

		private List<BillFormatInfo> billFormatInfo ( IDataReader dataReader)
		{
			if (false)
			{
				goto IL_28;
			}
			List<BillFormatInfo> list = new List<BillFormatInfo>();
			if (false)
			{
				goto IL_AB;
			}
			IL_A0:
			BillFormatInfo billFormatInfo;
			while (dataReader.Read())
			{
				if (5 != 0)
				{
					billFormatInfo = new BillFormatInfo();
					goto IL_28;
				}
			}
			goto IL_AB;
			IL_28:
			billFormatInfo.DG_Bill_Format_pkey = base.GetFieldValue(dataReader, BillFormatDao.getBillFormat(2523), 0);
			IL_51:
			billFormatInfo.DG_Bill_Type = new int?(base.GetFieldValue(dataReader, BillFormatDao.getBillFormat(2552), 0));
			billFormatInfo.DG_Refund_Slogan = base.GetFieldValue(dataReader, BillFormatDao.getBillFormat(2569), string.Empty);
			BillFormatInfo item;
			do
			{
				item = billFormatInfo;
			}
			while (!true);
			list.Add(item);
			goto IL_A0;
			IL_AB:
			if (!false)
			{
				return list;
			}
			goto IL_51;
		}

		public string GetBillFormat()
		{
			List<BillFormatInfo> source;
			using (IDataReader dataReader = base.ExecuteReader(""))
			{
				source = this.billFormatInfo(dataReader);
			}
			return source.FirstOrDefault<BillFormatInfo>().DG_Refund_Slogan;
		}

		private List<BillFormatInfo> billFormatInfo2 ( IDataReader dateReader)
		{
			if (false)
			{
				goto IL_28;
			}
			List<BillFormatInfo> list = new List<BillFormatInfo>();
			if (false)
			{
				goto IL_AB;
			}
			IL_A0:
			BillFormatInfo billFormatInfo;
			while (dateReader.Read())
			{
				if (5 != 0)
				{
					billFormatInfo = new BillFormatInfo();
					goto IL_28;
				}
			}
			goto IL_AB;
			IL_28:
			billFormatInfo.DG_Bill_Format_pkey = base.GetFieldValue(dateReader, BillFormatDao.getBillFormat(2523), 0);
			IL_51:
			billFormatInfo.DG_Bill_Type = new int?(base.GetFieldValue(dateReader, BillFormatDao.getBillFormat(2552), 0));
			billFormatInfo.DG_Refund_Slogan = base.GetFieldValue(dateReader, BillFormatDao.getBillFormat(2569), string.Empty);
			BillFormatInfo item;
			do
			{
				item = billFormatInfo;
			}
			while (!true);
			list.Add(item);
			goto IL_A0;
			IL_AB:
			if (!false)
			{
				return list;
			}
			goto IL_51;
		}

		static BillFormatDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//.HouseOfCards.Strings.CreateGetStringDelegate(typeof(BillFormatDao));
		}
	}
}
