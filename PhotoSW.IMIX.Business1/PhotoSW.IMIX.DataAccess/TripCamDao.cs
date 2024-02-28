//using #2j;
using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;

namespace PhotoSW.IMIX.DataAccess
{
	public class TripCamDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly.Delegates.GetString getTripCamDao;

		public TripCamDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public TripCamDao()
		{
		}

		public bool UpdCamIdForTripCamPOSMapping(int oldCamId, int NewCamid)
		{
			while (true)
			{
				base.DBParameters.Clear();
				if (4 != 0)
				{
					base.AddParameter(TripCamDao.getTripCamDao(29360), oldCamId);
					if (-1 != 0)
					{
						break;
					}
				}
			}
			base.AddParameter(TripCamDao.getTripCamDao (29381), NewCamid);
			if (4 != 0)
			{
				base.ExecuteNonQuery(TripCamDao.getTripCamDao (29402));
			}
			return true;
		}

		public bool InsUpdTripCamSettings(DataTable dt)
		{
			if (!false)
			{
				if (3 == 0)
				{
					return true;
				}
				base.DBParameters.Clear();
				if (false)
				{
					return true;
				}
				base.AddParameter(TripCamDao.getTripCamDao (29447), dt);
			}
			if (2 != 0)
			{
				base.ExecuteNonQuery(TripCamDao.getTripCamDao(29476));
			}
			return true;
		}

		public TripCamInfo GetTripCameraInfoById(string CameraName, string CameraId)
		{
			TripCamInfo result;
			if (!false)
			{
				base.DBParameters.Clear();
				base.AddParameter(TripCamDao.getTripCamDao(3603), CameraName);
				base.AddParameter(TripCamDao.getTripCamDao(3653), CameraId);
				IDataReader dataReader=null;
				do
				{
					//dataReader = base.ExecuteReader(IDataReaderj.#ef);
				}
				while (false);
				result = this.TripCamInfoc(dataReader);
				dataReader.Close();
			}
			return result;
		}

		private TripCamInfo TripCamInfoc(IDataReader IDataReader)
		{
			TripCamInfo expr_AA = new TripCamInfo();
			TripCamInfo tripCamInfo;
			if (5 != 0)
			{
				tripCamInfo = expr_AA;
			}
			while (IDataReader.Read())
			{
				tripCamInfo.CameraFolderpath = base.GetFieldValue(IDataReader, TripCamDao.getTripCamDao (29505), string.Empty);
				tripCamInfo.Camera_pKey = base.GetFieldValue(IDataReader, TripCamDao.getTripCamDao (3191), 0);
				tripCamInfo.CameraModel = base.GetFieldValue(IDataReader, TripCamDao.getTripCamDao (3279), string.Empty);
				tripCamInfo.TripCamTypeId = base.GetFieldValue(IDataReader, TripCamDao.getTripCamDao (29522), 0);
			}
			return tripCamInfo;
		}

		public List<TripCamSettingInfo> GetTripCamSettingsForCameraId(int CameraId, int TripCamTypeId)
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
			List<TripCamSettingInfo> result=null;
			do
			{
				base.AddParameter(TripCamDao.getTripCamDao(3582), CameraId);
				base.AddParameter(TripCamDao.getTripCamDao(29543), TripCamTypeId);
				//dataReader = base.ExecuteReader(#1j.#ff);
				//result = this.#7c(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		public List<TripCamSettingInfo> GetSavedTripCamSettingsForCameraId(int CameraId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(TripCamDao.getTripCamDao (29572), CameraId);
			}
			IDataReader dataReader=null;
			List<TripCamSettingInfo> result=null;
			if (!false)
			{
                //dataReader = base.ExecuteReader(#1j.#gf);
                //if (3 != 0)
                //{
                //    result = this.TripCamSettingInfo7c(dataReader);
                //}
			}
			dataReader.Close();
			return result;
		}

		private List<TripCamSettingInfo> TripCamSettingInfo7c(IDataReader IDataReader)
		{
			List<TripCamSettingInfo> list;
			while (true)
			{
				IL_00:
				list = new List<TripCamSettingInfo>();
				while (IDataReader.Read())
				{
					TripCamSettingInfo tripCamSettingInfo = new TripCamSettingInfo();
					tripCamSettingInfo.TripCamValueId = base.GetFieldValue(IDataReader, TripCamDao.getTripCamDao (29585), 0);
					if (6 == 0 || !true)
					{
						goto IL_00;
					}
					tripCamSettingInfo.TripCamSettingsMasterId = base.GetFieldValue(IDataReader, TripCamDao.getTripCamDao (29606), 0L);
					if (7 != 0)
					{
						tripCamSettingInfo.SettingsValue = base.GetFieldValue(IDataReader, TripCamDao.getTripCamDao(29639), string.Empty);
						tripCamSettingInfo.CameraId = base.GetFieldValue(IDataReader, TripCamDao.getTripCamDao (29660), 0);
					}
					tripCamSettingInfo.ModifiedDate = base.GetFieldValue(IDataReader, TripCamDao.getTripCamDao (2913), DateTime.MinValue);
					TripCamSettingInfo item = tripCamSettingInfo;
					list.Add(item);
				}
				break;
			}
			return list;
		}

		public bool ValidateCameraRunningStatus(string CamMake)
		{
			bool arg_3A_0;
			bool flag;
			while (true)
			{
				while (!false)
				{
					base.DBParameters.Clear();
					while (4 != 0)
					{
						base.AddParameter(TripCamDao.getTripCamDao (3628), CamMake);
                        //bool expr_2D = arg_3A_0 = Convert.ToBoolean(base.ExecuteScalar(#1j.#hf));
                        //if (false)
                        //{
                        //    return arg_3A_0;
                        //}
                        //flag = expr_2D;
                        //if (-1 != 0)
                        //{
                        //    goto Block_3;
                        //}
					}
				}
			}
			Block_3:
			arg_3A_0 = flag;
			return arg_3A_0;
		}

		public bool ValidateCameraAvailability(string CamMake)
		{
			bool arg_3A_0;
			bool flag;
			while (true)
			{
				while (!false)
				{
					base.DBParameters.Clear();
					while (4 != 0)
					{
                        //base.AddParameter(TripCamDao.getTripCamDao (3628), CamMake);
                        //bool expr_2D = arg_3A_0 = Convert.ToBoolean(base.ExecuteScalar(#1j.#if));
                        //if (false)
                        //{
                        //    return arg_3A_0;
                        //}
                        //flag = expr_2D;
                        //if (-1 != 0)
                        //{
                        //    goto Block_3;
                        //}
					}
				}
			}
			Block_3:
			arg_3A_0 = flag;
			return arg_3A_0;
		}

		static TripCamDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(TripCamDao));
		}
	}
}
