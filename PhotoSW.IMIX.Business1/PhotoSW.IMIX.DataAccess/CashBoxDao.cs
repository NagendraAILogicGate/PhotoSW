//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Data;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class CashBoxDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getCashBox;
        public CashBoxDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public CashBoxDao()
		{
		}

		public int Add(CashBoxInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(CashBoxDao.getCashBox(7971), objectInfo.Reason);
			base.AddParameter(CashBoxDao.getCashBox(3501), objectInfo.UserId);
			base.AddParameter(CashBoxDao.getCashBox(7988), objectInfo.CreatedDate);
			base.AddParameter(CashBoxDao.getCashBox(8013), objectInfo.Id, ParameterDirection.Output);
			base.ExecuteNonQuery("");
			return (int)base.GetOutParameterValue(CashBoxDao.getCashBox(8013));
		}

		static CashBoxDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CashBoxDao));
		}
	}
}
