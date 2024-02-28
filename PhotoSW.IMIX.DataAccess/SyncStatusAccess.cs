//using #2j;
using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;

namespace PhotoSW.IMIX.DataAccess
{
	public class SyncStatusAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly .Delegates.GetString getSyncStatusAccess;

		public SyncStatusAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public SyncStatusAccess()
		{
		}

		public List<SyncStatusInfo> GetSyncStatus(DateTime FromDate, DateTime ToDate)
		{
			base.DBParameters.Clear();
			base.AddParameter(SyncStatusAccess.getSyncStatusAccess(55627), FromDate);
			base.AddParameter(SyncStatusAccess.getSyncStatusAccess(55640), ToDate);
			IDataReader dataReader = base.ExecuteReader(SyncStatusAccess.getSyncStatusAccess (56935));
			List<SyncStatusInfo> result = this.SyncStatusInfoHk(dataReader);
			dataReader.Close();
			return result;
		}

		private List<SyncStatusInfo> SyncStatusInfoHk(IDataReader IDataReader)
		{
			List<SyncStatusInfo> list = new List<SyncStatusInfo>();
			while (IDataReader.Read())
			{
				SyncStatusInfo syncStatusInfo = new SyncStatusInfo();
				syncStatusInfo.SyncOrderNumber = base.GetFieldValue(IDataReader, SyncStatusAccess.getSyncStatusAccess(17097), string.Empty);
				syncStatusInfo.SyncOrderdate = new DateTime?(base.GetFieldValue(IDataReader, SyncStatusAccess.getSyncStatusAccess (17122), DateTime.Now));
				syncStatusInfo.PhotoRfid = base.GetFieldValue(IDataReader, SyncStatusAccess.getSyncStatusAccess (53147), string.Empty);
				syncStatusInfo.Syncdate = base.GetFieldValueDateTimeNull(IDataReader, SyncStatusAccess .getSyncStatusAccess(56988), DateTime.Now);
				syncStatusInfo.IsAvailable = new bool?(base.GetFieldValue(IDataReader, SyncStatusAccess.getSyncStatusAccess(15524), false));
				switch (base.GetFieldValue(IDataReader, SyncStatusAccess.getSyncStatusAccess(57001), 0))
				{
				case -5:
					syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.FailedtoProcessonPartnerDB.ToString();
					break;
				case -4:
					syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.FailedToProcessDataOnCentralServer.ToString();
					break;
				case -3:
					syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.UploadedDataOnCentralServerButFailedonCloudinary.ToString();
					break;
				case -2:
					syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.Invalid.ToString();
					break;
				case -1:
					syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.Error.ToString();
					break;
				case 0:
					syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.NotSynced.ToString();
					break;
				case 1:
					syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.Synced.ToString();
					break;
				case 3:
					syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.UploadedDataOnCentralServerandCloudinary.ToString();
					break;
				case 4:
					syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.ProcessedDataOnCentralServer.ToString();
					break;
				}
				list.Add(syncStatusInfo);
			}
			return list;
		}

		public List<SyncStatusInfo> GetOrdersyncStatus(DateTime? FromDate, DateTime? ToDate)
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
			List<SyncStatusInfo> result=null;
			do
			{
				base.AddParameter(SyncStatusAccess.getSyncStatusAccess(1156), FromDate);
				base.AddParameter(SyncStatusAccess.getSyncStatusAccess(1177), ToDate);
				//dataReader = base.ExecuteReader(#1j.#De);
				//result = this.SyncStatusInfoIk(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		private List<SyncStatusInfo> SyncStatusInfoIk(IDataReader IDataReader)
		{
			List<SyncStatusInfo> list = new List<SyncStatusInfo>();
			while (IDataReader.Read())
			{
				SyncStatusInfo expr_1B1 = new SyncStatusInfo();
				SyncStatusInfo syncStatusInfo;
				if (true)
				{
					syncStatusInfo = expr_1B1;
				}
				syncStatusInfo.SyncOrderNumber = base.GetFieldValue(IDataReader,             SyncStatusAccess.getSyncStatusAccess(17097), string.Empty);
				syncStatusInfo.QRCode = base.GetFieldValue(IDataReader,                      SyncStatusAccess.getSyncStatusAccess(18256), string.Empty);
				syncStatusInfo.DGOrderspkey = base.GetFieldValue(IDataReader,                SyncStatusAccess.getSyncStatusAccess(17076), 0);
				syncStatusInfo.SyncOrderdate = new DateTime?(base.GetFieldValue(IDataReader, SyncStatusAccess.getSyncStatusAccess(17122), DateTime.Now));
				syncStatusInfo.PhotoRfid = base.GetFieldValue(IDataReader,                   SyncStatusAccess.getSyncStatusAccess(57018), string.Empty);
				syncStatusInfo.Syncdate = base.GetFieldValueDateTimeNull(IDataReader,        SyncStatusAccess.getSyncStatusAccess(56988), DateTime.Now);
				syncStatusInfo.SyncStatusID = base.GetFieldValue(IDataReader,                SyncStatusAccess.getSyncStatusAccess(57001), 0);
				syncStatusInfo.Syncstatus = base.GetFieldValue(IDataReader,                  SyncStatusAccess.getSyncStatusAccess(57035), string.Empty);
				syncStatusInfo.IsAvailable = new bool?(base.GetFieldValue(IDataReader,       SyncStatusAccess.getSyncStatusAccess(15524), false));
				syncStatusInfo.ChangeTrackingId = base.GetFieldValue(IDataReader,            SyncStatusAccess.getSyncStatusAccess(57056), 0L);
				syncStatusInfo.ImageSynced = base.GetFieldValue(IDataReader,                 SyncStatusAccess.getSyncStatusAccess(57081), string.Empty);
				list.Add(syncStatusInfo);
			}
			return list;
		}

		public bool ReSync(string ReSyncId)
		{
			bool flag = false;
			base.DBParameters.Clear();
			base.AddParameter(SyncStatusAccess.getSyncStatusAccess(57102), base.SetNullStringValue(ReSyncId));
			base.AddParameter(SyncStatusAccess.getSyncStatusAccess(15617), flag, ParameterDirection.Output);
			//base.ExecuteNonQuery(#1j.#be);
			return (bool)base.GetOutParameterValue(SyncStatusAccess.getSyncStatusAccess(15617));
		}

		public bool ReSyncImage(string OrderId)
		{
			bool flag = false;
			base.DBParameters.Clear();
			base.AddParameter(SyncStatusAccess.getSyncStatusAccess(19193), OrderId);
			base.AddParameter(SyncStatusAccess.getSyncStatusAccess(15617), flag, ParameterDirection.Output);
			//base.ExecuteNonQuery(#1j.#ce);
			return (bool)base.GetOutParameterValue(SyncStatusAccess.getSyncStatusAccess(15617));
		}

		public List<SyncStatusInfo> GetSyncStatusOpenCloseForm(DateTime FromDate, DateTime ToDate)
		{
			base.DBParameters.Clear();
			base.AddParameter(SyncStatusAccess.getSyncStatusAccess(55627), FromDate);
			base.AddParameter(SyncStatusAccess.getSyncStatusAccess(55640), ToDate);
			IDataReader dataReader = base.ExecuteReader(SyncStatusAccess.getSyncStatusAccess (57119));
			List<SyncStatusInfo> result = this.SyncStatusInfoJk(dataReader);
			dataReader.Close();
			return result;
		}

		private List<SyncStatusInfo> SyncStatusInfoJk(IDataReader IDataReader)
		{
			List<SyncStatusInfo> list = new List<SyncStatusInfo>();
			while (IDataReader.Read())
			{
				SyncStatusInfo syncStatusInfo = new SyncStatusInfo();
				syncStatusInfo.SyncFormID = base.GetFieldValue(IDataReader,        SyncStatusAccess.getSyncStatusAccess(54263), 0L);
				syncStatusInfo.SyncFormTransDate = base.GetFieldValue(IDataReader, SyncStatusAccess.getSyncStatusAccess(54351), DateTime.Now);
				while (true)
				{
					syncStatusInfo.Syncdate = base.GetFieldValueDateTimeNull(IDataReader,  SyncStatusAccess.getSyncStatusAccess(56988), DateTime.Now);
					syncStatusInfo.IsAvailable = new bool?(base.GetFieldValue(IDataReader, SyncStatusAccess.getSyncStatusAccess(15524), false));
					syncStatusInfo.Form = base.GetFieldValue(IDataReader,                  SyncStatusAccess.getSyncStatusAccess(57160), string.Empty);
					syncStatusInfo.ChangeTrackingId = base.GetFieldValue(IDataReader,      SyncStatusAccess.getSyncStatusAccess(57056), 0L);
					while (true)
					{
						int fieldValue = base.GetFieldValue(IDataReader, SyncStatusAccess.getSyncStatusAccess (57001) , 0);
						if (6 != 0)
						{
							switch (fieldValue)
							{
							case -5:
								goto IL_1E3;
							case -4:
								goto IL_1CF;
							case -3:
								goto IL_1A2;
							case -2:
								goto IL_17B;
							case -1:
								goto IL_168;
							case 0:
								goto IL_13C;
							case 1:
								goto IL_152;
							case 3:
								goto IL_18F;
							case 4:
								if (!false)
								{
									goto Block_3;
								}
								continue;
							}
							goto Block_2;
						}
						break;
					}
				}
				IL_1F5:
				list.Add(syncStatusInfo);
				continue;
				Block_2:
				goto IL_1F5;
				IL_13C:
				syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.NotSynced.ToString();
				goto IL_1F5;
				IL_152:
				syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.Synced.ToString();
				goto IL_1F5;
				IL_168:
				syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.Error.ToString();
				goto IL_1F5;
				IL_17B:
				syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.Invalid.ToString();
				goto IL_1F5;
				IL_18F:
				syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.UploadedDataOnCentralServerandCloudinary.ToString();
				goto IL_1F5;
				IL_1A2:
				syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.UploadedDataOnCentralServerButFailedonCloudinary.ToString();
				goto IL_1F5;
				Block_3:
				syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.ProcessedDataOnCentralServer.ToString();
				goto IL_1F5;
				IL_1CF:
				syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.FailedToProcessDataOnCentralServer.ToString();
				goto IL_1F5;
				IL_1E3:
				syncStatusInfo.Syncstatus = Constants.SyncOrderStatus.FailedtoProcessonPartnerDB.ToString();
				goto IL_1F5;
			}
			return list;
		}

		public bool InsertResyncHistory(DateTime ResyncDatetime, int ResyncStatus, int ResyncType)
		{
			base.DBParameters.Clear();
			do
			{
				base.AddParameter(SyncStatusAccess.getSyncStatusAccess(57169), ResyncDatetime);
			}
			while (2 == 0);
			base.AddParameter(SyncStatusAccess.getSyncStatusAccess(57198), ResyncStatus);
			do
			{
				base.AddParameter(SyncStatusAccess.getSyncStatusAccess (57223), ResyncType);
				//base.ExecuteNonQuery(#1j.#2Ub);
			}
			while (3 == 0);
			return true;
		}

		static SyncStatusAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(SyncStatusAccess));
		}
	}
}
