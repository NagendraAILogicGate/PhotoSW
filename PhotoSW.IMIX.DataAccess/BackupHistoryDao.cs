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
	public class BackupHistoryDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getStrBackup;
        public BackupHistoryDao(BaseDataAccess baseaccess) : base(baseaccess)
		{

		}

		public BackupHistoryDao()
		{

		}

		public bool UpdAndInsScheduledConfig(int SubStoreId, int Status, DateTime ScheduleDate)
		{
			base.DBParameters.Clear();
			do
			{
				base.AddParameter(BackupHistoryDao.getStrBackup(2314), SubStoreId);
			}
			while (2 == 0);
			base.AddParameter(BackupHistoryDao.getStrBackup(2339), Status);
			do
			{
				base.AddParameter(BackupHistoryDao.getStrBackup(2356), ScheduleDate);
				base.ExecuteNonQuery("");
			}
			while (3 == 0);
			return true;
		}

		public List<BackupHistory> GetBackupHistoryData(int SubStoreId, DateTime StartDate, DateTime EndDate)
		{
			base.DBParameters.Clear();
            string expr_AC = BackupHistoryDao.getStrBackup(2314);
			object expr_28 = SubStoreId;
			if (4 != 0)
			{
				base.AddParameter(expr_AC, expr_28);
			}
			base.AddParameter(BackupHistoryDao.getStrBackup(2381), StartDate);
			base.AddParameter(BackupHistoryDao.getStrBackup(2402), EndDate);
			IDataReader dataReader = base.ExecuteReader("");
			List<BackupHistory> result = this.backupHistory(dataReader);
			dataReader.Close();
			return result;
		}

		private List<BackupHistory> backupHistory ( IDataReader dataReader)
		{
			List<BackupHistory> list = new List<BackupHistory>();
			while (dataReader.Read())
			{
				BackupHistory item = new BackupHistory
				{
					BackupId = base.GetFieldValue(dataReader, BackupHistoryDao.getStrBackup(2423), 0),
					ScheduleDate = base.GetFieldValue(dataReader, BackupHistoryDao.getStrBackup(2436), DateTime.Now),
					StartDate = base.GetFieldValue(dataReader, BackupHistoryDao.getStrBackup(2453), DateTime.Now),
					EndDate = base.GetFieldValue(dataReader, BackupHistoryDao.getStrBackup(2466), DateTime.Now),
					Status = base.GetFieldValue(dataReader, BackupHistoryDao.getStrBackup(2479), 0),
					ErrorMessage = base.GetFieldValue(dataReader, BackupHistoryDao.getStrBackup(2488), string.Empty),
					SubStoreId = base.GetFieldValue(dataReader, BackupHistoryDao.getStrBackup(2505), 0)
				};
				list.Add(item);
			}
			return list;
		}

		static BackupHistoryDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(BackupHistoryDao));
		}
	}
}
