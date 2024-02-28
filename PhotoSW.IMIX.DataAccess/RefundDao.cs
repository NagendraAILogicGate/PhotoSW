//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class RefundDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getProcessedVideoAccess;
        
        public RefundDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public RefundDao()
		{
		}

		public List<RefundInfo> GetRefund(int OrderId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(RefundDao.getProcessedVideoAccess(18747), OrderId);
			}
			IDataReader dataReader;
			List<RefundInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.RefundInfoHc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<RefundInfo> RefundInfoHc ( IDataReader IDataReader )
		{
			List<RefundInfo> list = new List<RefundInfo>();
			while (IDataReader.Read())
			{
				RefundInfo item = new RefundInfo
				{
					DG_RefundId = base.GetFieldValue(IDataReader, RefundDao.getProcessedVideoAccess(25543), 0),
					DG_OrderId = base.GetFieldValue(IDataReader, RefundDao.getProcessedVideoAccess(14989), 0),
					RefundAmount = base.GetFieldValue(IDataReader, RefundDao.getProcessedVideoAccess(25560), 0.0m),
					RefundDate = base.GetFieldValue(IDataReader, RefundDao.getProcessedVideoAccess(25577), DateTime.Now),
					UserId = base.GetFieldValue(IDataReader, RefundDao.getProcessedVideoAccess(25594), 0),
					Refund_Mode = base.GetFieldValue(IDataReader, RefundDao.getProcessedVideoAccess(25603), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public int InsandDelRefundMasterData(RefundInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(RefundDao.getProcessedVideoAccess(18747), objectInfo.DG_OrderId);
			base.AddParameter(RefundDao.getProcessedVideoAccess(3518), objectInfo.UserId);
			base.AddParameter(RefundDao.getProcessedVideoAccess(25620), objectInfo.RefundDate);
			base.AddParameter(RefundDao.getProcessedVideoAccess(25645), objectInfo.RefundAmount);
			base.AddParameter(RefundDao.getProcessedVideoAccess(25670), objectInfo.DG_RefundId, ParameterDirection.Output);
			base.ExecuteReader("");
			return (int)base.GetOutParameterValue(RefundDao.getProcessedVideoAccess(25670));
		}

		public bool SetRefundDetailsData(int DG_LineItemId, int DG_RefundMaster_ID, string PhotoId, decimal? Refundprice, string Reason)
		{
			base.DBParameters.Clear();
			base.AddParameter(RefundDao.getProcessedVideoAccess(25691), DG_LineItemId);
			base.AddParameter(RefundDao.getProcessedVideoAccess(25720), DG_RefundMaster_ID);
			base.AddParameter(RefundDao.getProcessedVideoAccess(7506), PhotoId);
			base.AddParameter(RefundDao.getProcessedVideoAccess(25753), Refundprice);
			base.AddParameter(RefundDao.getProcessedVideoAccess(7988), Reason);
			base.ExecuteReader("");
			return true;
		}

		public List<RefundInfo> GetRefundedItems(int OrderID)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(RefundDao.getProcessedVideoAccess(25778), OrderID);
			}
			IDataReader dataReader;
			List<RefundInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.RefundInfoIc(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<RefundInfo> RefundInfoIc ( IDataReader IDataReader )
		{
			List<RefundInfo> list = new List<RefundInfo>();
			while (true)
			{
				if (4 == 0)
				{
					goto IL_61;
				}
				IL_68:
				RefundInfo refundInfo;
				if (!IDataReader.Read())
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
					refundInfo = new RefundInfo();
					refundInfo.DG_LineItemId = base.GetFieldValue(IDataReader, RefundDao.getProcessedVideoAccess(25795), 0);
				}
				if (!false)
				{
					refundInfo.RefundPhotoId = base.GetFieldValue(IDataReader, RefundDao.getProcessedVideoAccess(23871), 0);
				}
				RefundInfo item = refundInfo;
				IL_61:
				list.Add(item);
				goto IL_68;
			}
			return list;
		}

		static RefundDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(RefundDao));
		}
	}
}
