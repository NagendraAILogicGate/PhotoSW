//using #2j;
//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class CameraDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getCamera;

        public CameraDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public CameraDao()
		{
		}

		public List<CameraInfo> SelectRideCamera()
		{
			IDataReader dataReader;
			List<CameraInfo> result;
			while (true)
			{
				if (!false)
				{
					dataReader = base.ExecuteReader("");
				}
				while (!false)
				{
					List<CameraInfo> expr_3A = this.cameraInfo(dataReader);
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

		private List<CameraInfo> cameraInfo ( IDataReader dataReader)
		{
			List<CameraInfo> list = new List<CameraInfo>();
			while (true)
			{
				if (4 == 0)
				{
					goto IL_6B;
				}
				IL_72:
				CameraInfo cameraInfo;
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
					cameraInfo = new CameraInfo();
					cameraInfo.RideCameras = base.GetFieldValue(dataReader, CameraDao.getCamera(3146), string.Empty);
				}
				if (!false)
				{
					cameraInfo.DG_Camera_pkey = base.GetFieldValue(dataReader, CameraDao.getCamera(3163), 0);
				}
				CameraInfo item = cameraInfo;
				IL_6B:
				list.Add(item);
				goto IL_72;
			}
			return list;
		}

		public List<CameraInfo> GetCameraList()
		{
			IDataReader dataReader;
			List<CameraInfo> result;
			while (true)
			{
				if (!false)
				{
					dataReader = base.ExecuteReader("");
				}
				while (!false)
				{
					List<CameraInfo> expr_3A = this.cameraInfo2(dataReader);
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

		private List<CameraInfo> cameraInfo2 ( IDataReader dataReader)
		{
			List<CameraInfo> list = new List<CameraInfo>();
			while (dataReader.Read())
			{
				CameraInfo expr_239 = new CameraInfo();
				CameraInfo cameraInfo;
				if (true)
				{
					cameraInfo = expr_239;
				}
				cameraInfo.PhotographerName = base.GetFieldValue(dataReader, CameraDao.getCamera(3184), string.Empty);
				cameraInfo.DG_Camera_Name = base.GetFieldValue(dataReader, CameraDao.getCamera(3209), string.Empty);
				cameraInfo.DG_Camera_Make = base.GetFieldValue(dataReader, CameraDao.getCamera(3230), string.Empty);
				cameraInfo.DG_Camera_Model = base.GetFieldValue(dataReader, CameraDao.getCamera(3251), string.Empty);
				cameraInfo.DG_AssignTo = new int?(base.GetFieldValue(dataReader, CameraDao.getCamera(3272), 0));
				cameraInfo.DG_Camera_Start_Series = base.GetFieldValue(dataReader, CameraDao.getCamera(3289), string.Empty);
				cameraInfo.DG_Updatedby = base.GetFieldValue(dataReader, CameraDao.getCamera(3322), 0);
				cameraInfo.DG_UpdatedDate = base.GetFieldValue(dataReader, CameraDao.getCamera(3339), DateTime.Now);
				cameraInfo.DG_Camera_pkey = base.GetFieldValue(dataReader, CameraDao.getCamera(3163), 0);
				cameraInfo.DG_CameraFolder = base.GetFieldValue(dataReader, CameraDao.getCamera(3360), string.Empty);
				cameraInfo.DG_Camera_IsDeleted = new bool?(base.GetFieldValue(dataReader, CameraDao.getCamera(3381), true));
				cameraInfo.DG_Camera_ID = new int?(base.GetFieldValue(dataReader, CameraDao.getCamera(3410), 0));
				cameraInfo.IsTripCam = new bool?(base.GetFieldValue(dataReader, CameraDao.getCamera(3427), true));
				cameraInfo.IsLiveStream = new bool?(base.GetFieldValue(dataReader, CameraDao.getCamera(3440), false));
				cameraInfo.SerialNo = base.GetFieldValue(dataReader, CameraDao.getCamera(3457), string.Empty);
				CameraInfo item = cameraInfo;
				list.Add(item);
			}
			return list;
		}

		public List<CameraInfo> GetCameraDetailsByID(int? DG_Camera_pkey, int? UserId)
		{
			base.DBParameters.Clear();
			IDataReader dataReader;
			List<CameraInfo> result;
			do
			{
				base.AddParameter(CameraDao.getCamera(3470), DG_Camera_pkey);
				base.AddParameter(CameraDao.getCamera(3499), UserId);
				dataReader = base.ExecuteReader("");
				result = this.cameraInfo3(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		private List<CameraInfo> cameraInfo3 ( IDataReader dataReader)
		{
			List<CameraInfo> list = new List<CameraInfo>();
			while (dataReader.Read())
			{
				CameraInfo item = new CameraInfo
				{
					DG_Camera_pkey = base.GetFieldValue(dataReader, CameraDao.getCamera(3163), 0),
					DG_Camera_Name = base.GetFieldValue(dataReader, CameraDao.getCamera(3209), string.Empty),
					DG_Camera_Make = base.GetFieldValue(dataReader, CameraDao.getCamera(3230), string.Empty),
					DG_Camera_Model = base.GetFieldValue(dataReader, CameraDao.getCamera(3251), string.Empty),
					DG_AssignTo = new int?(base.GetFieldValue(dataReader, CameraDao.getCamera(3272), 0)),
					DG_Camera_Start_Series = base.GetFieldValue(dataReader, CameraDao.getCamera(3289), string.Empty),
					DG_Updatedby = base.GetFieldValue(dataReader, CameraDao.getCamera(3322), 0),
					DG_UpdatedDate = base.GetFieldValue(dataReader, CameraDao.getCamera(3339), DateTime.Now),
					DG_Camera_IsDeleted = new bool?(base.GetFieldValue(dataReader, CameraDao.getCamera(3381), false)),
					DG_Camera_ID = new int?(base.GetFieldValue(dataReader, CameraDao.getCamera(3410), 0)),
					SyncCode = base.GetFieldValue(dataReader, CameraDao.getCamera(1973), string.Empty),
					IsSynced = base.GetFieldValue(dataReader, CameraDao.getCamera(1986), false),
					IsChromaColor = new bool?(base.GetFieldValue(dataReader, CameraDao.getCamera(3516), false)),
					CharacterId = base.GetFieldValueIntNull(dataReader, CameraDao.getCamera(3537), 0),
					IsTripCam = new bool?(base.GetFieldValue(dataReader, CameraDao.getCamera(3427), false)),
					IsLiveStream = new bool?(base.GetFieldValue(dataReader, CameraDao.getCamera(3440), false)),
					SerialNo = base.GetFieldValue(dataReader, CameraDao.getCamera(3457), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public List<CameraInfo> Select(int? cameraId)
		{
			List<CameraInfo> result;
			if (!false)
			{
				base.DBParameters.Clear();
				base.AddParameter(CameraDao.getCamera(3470), base.SetNullIntegerValue(cameraId));
				IDataReader dataReader = base.ExecuteReader("");
				try
				{
					result = this.cameraInfo4(dataReader);
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

		private List<CameraInfo> cameraInfo4 ( IDataReader dataReader)
		{
			List<CameraInfo> list = new List<CameraInfo>();
			while (dataReader.Read())
			{
				CameraInfo item = new CameraInfo
				{
					PhotographerName = base.GetFieldValue(dataReader, CameraDao.getCamera(3184), string.Empty),
					DG_Camera_Name = base.GetFieldValue(dataReader, CameraDao.getCamera(3209), string.Empty),
					DG_Camera_Make = base.GetFieldValue(dataReader, CameraDao.getCamera(3230), string.Empty),
					DG_Camera_Model = base.GetFieldValue(dataReader, CameraDao.getCamera(3251), string.Empty),
					DG_AssignTo = new int?(base.GetFieldValue(dataReader, CameraDao.getCamera(3272), 0)),
					DG_Camera_Start_Series = base.GetFieldValue(dataReader, CameraDao.getCamera(3289), string.Empty),
					DG_Updatedby = base.GetFieldValue(dataReader, CameraDao.getCamera(3322), 0),
					DG_UpdatedDate = base.GetFieldValue(dataReader, CameraDao.getCamera(3339), DateTime.MinValue),
					DG_Camera_pkey = base.GetFieldValue(dataReader, CameraDao.getCamera(3163), 0),
					DG_CameraFolder = base.GetFieldValue(dataReader, CameraDao.getCamera(3360), string.Empty),
					DG_Camera_IsDeleted = new bool?(base.GetFieldValue(dataReader, CameraDao.getCamera(3381), false)),
					DG_Camera_ID = new int?(base.GetFieldValue(dataReader, CameraDao.getCamera(3410), 0)),
					IsChromaColor = new bool?(base.GetFieldValue(dataReader, CameraDao.getCamera(3516), false))
				};
				list.Add(item);
			}
			return list;
		}

		public string Delete(int objectvalueId)
		{
			base.DBParameters.Clear();
			object value;
			do
			{
				base.AddParameter(CameraDao.getCamera(3554), objectvalueId);
				if (true)
				{
					value = base.ExecuteScalar("");
				}
			}
			while (8 == 0);
			return Convert.ToString(value);
		}

		public bool SetGetCameraDetails(CameraInfo _objCameraInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(CameraDao.getCamera(3575), _objCameraInfo.DG_Camera_Name);
			base.AddParameter(CameraDao.getCamera(3600), _objCameraInfo.DG_Camera_Make);
			base.AddParameter(CameraDao.getCamera(3625), _objCameraInfo.DG_Camera_Model);
			base.AddParameter(CameraDao.getCamera(3650), _objCameraInfo.DG_Camera_Start_Series);
			base.AddParameter(CameraDao.getCamera(3554), _objCameraInfo.DG_Camera_ID);
			base.AddParameter(CameraDao.getCamera(3675), _objCameraInfo.DG_AssignTo);
			base.AddParameter(CameraDao.getCamera(3704), _objCameraInfo.DG_Updatedby);
			base.AddParameter(CameraDao.getCamera(3725), _objCameraInfo.DG_Location_ID);
			base.AddParameter(CameraDao.getCamera(381), _objCameraInfo.SyncCode);
			base.AddParameter(CameraDao.getCamera(3750), _objCameraInfo.IsChromaColor);
			base.AddParameter(CameraDao.getCamera(3779), _objCameraInfo.SubStoreId);
			base.AddParameter(CameraDao.getCamera(3804), _objCameraInfo.IsTripCam);
			base.AddParameter(CameraDao.getCamera(3825), _objCameraInfo.IsLiveStream);
			base.AddParameter(CameraDao.getCamera(3850), _objCameraInfo.SerialNo);
			base.AddParameter(CameraDao.getCamera(3871), _objCameraInfo.CameraId, ParameterDirection.InputOutput);
			base.AddParameter(CameraDao.getCamera(3896), _objCameraInfo.DG_Camera_pkey, ParameterDirection.InputOutput);
			base.ExecuteNonQuery("");
			_objCameraInfo.CameraId = (int)base.GetOutParameterValue(CameraDao.getCamera(3871));
			_objCameraInfo.DG_Camera_pkey = (int)base.GetOutParameterValue(CameraDao.getCamera(3896));
			return true;
		}

		public List<CameraInfo> GetIsResetDPIRequired(int PhotoGrapherId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(CameraDao.getCamera(3675), PhotoGrapherId);
			}
			IDataReader dataReader;
			List<CameraInfo> result;
			if (!false)
			{
				dataReader = base.ExecuteReader("");
				if (3 != 0)
				{
					result = this.cameraInfo5(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		private List<CameraInfo> cameraInfo5 ( IDataReader dataReader)
		{
			List<CameraInfo> list = new List<CameraInfo>();
			while (dataReader.Read())
			{
				CameraInfo item = new CameraInfo
				{
					DG_Camera_Name = base.GetFieldValue(dataReader, CameraDao.getCamera(3209), string.Empty),
					DG_Camera_Make = base.GetFieldValue(dataReader, CameraDao.getCamera(3230), string.Empty),
					DG_Camera_Model = base.GetFieldValue(dataReader, CameraDao.getCamera(3251), string.Empty),
					DG_AssignTo = new int?(base.GetFieldValue(dataReader, CameraDao.getCamera(3272), 0)),
					DG_Camera_Start_Series = base.GetFieldValue(dataReader, CameraDao.getCamera(3289), string.Empty),
					DG_Updatedby = base.GetFieldValue(dataReader, CameraDao.getCamera(3322), 0),
					DG_UpdatedDate = base.GetFieldValue(dataReader, CameraDao.getCamera(3339), DateTime.MinValue),
					DG_Camera_pkey = base.GetFieldValue(dataReader, CameraDao.getCamera(3163), 0),
					DG_Camera_IsDeleted = new bool?(base.GetFieldValue(dataReader, CameraDao.getCamera(3381), false)),
					DG_Camera_ID = new int?(base.GetFieldValue(dataReader, CameraDao.getCamera(3410), 0)),
					IsChromaColor = new bool?(base.GetFieldValue(dataReader, CameraDao.getCamera(3516), false))
				};
				list.Add(item);
			}
			return list;
		}

		public bool SetTripCameraSetting(RideCameraSettingInfo objRid)
		{
			base.DBParameters.Clear();
			base.AddParameter(CameraDao.getCamera(3925), objRid.DG_RideCamera_pkey, ParameterDirection.InputOutput);
			base.AddParameter(CameraDao.getCamera(3958), objRid.DG_RideCamera_Id);
			base.AddParameter(CameraDao.getCamera(3991), objRid.AcquisitionFrameCount);
			base.AddParameter(CameraDao.getCamera(4028), objRid.AcquisitionFrameRateAbs);
			base.AddParameter(CameraDao.getCamera(4069), objRid.AcquisitionFrameRateLimit);
			base.AddParameter(CameraDao.getCamera(4114), objRid.AcquisitionMode);
			base.AddParameter(CameraDao.getCamera(4143), objRid.BalanceRatioAbs);
			base.AddParameter(CameraDao.getCamera(4172), objRid.BalanceWhiteAuto);
			base.AddParameter(CameraDao.getCamera(4205), objRid.BalanceWhiteAutoAdjustTol);
			base.AddParameter(CameraDao.getCamera(4250), objRid.BalanceWhiteAutoRate);
			base.AddParameter(CameraDao.getCamera(4287), objRid.EventSelector);
			base.AddParameter(CameraDao.getCamera(4316), objRid.EventsEnable1);
			base.AddParameter(CameraDao.getCamera(4345), objRid.ExposureAuto);
			base.AddParameter(CameraDao.getCamera(4370), objRid.ExposureAutoAdjustTol);
			base.AddParameter(CameraDao.getCamera(4407), objRid.ExposureAutoAlg);
			base.AddParameter(CameraDao.getCamera(4436), objRid.ExposureAutoMax);
			base.AddParameter(CameraDao.getCamera(4465), objRid.ExposureAutoMin);
			base.AddParameter(CameraDao.getCamera(4494), objRid.ExposureAutoOutliers);
			base.AddParameter(CameraDao.getCamera(4531), objRid.ExposureAutoRate);
			base.AddParameter(CameraDao.getCamera(4564), objRid.ExposureAutoTarget);
			base.AddParameter(CameraDao.getCamera(4597), objRid.ExposureTimeAbs);
			base.AddParameter(CameraDao.getCamera(4626), objRid.GainAuto);
			base.AddParameter(CameraDao.getCamera(4647), objRid.GainAutoAdjustTol);
			base.AddParameter(CameraDao.getCamera(4680), objRid.GainAutoMax);
			base.AddParameter(CameraDao.getCamera(4705), objRid.GainAutoMin);
			base.AddParameter(CameraDao.getCamera(4730), objRid.GainAutoOutliers);
			base.AddParameter(CameraDao.getCamera(4763), objRid.GainAutoRate);
			base.AddParameter(CameraDao.getCamera(4788), objRid.GainAutoTarget);
			base.AddParameter(CameraDao.getCamera(4817), objRid.Gain);
			base.AddParameter(CameraDao.getCamera(4838), objRid.GainSelector);
			base.AddParameter(CameraDao.getCamera(4863), objRid.Hue);
			base.AddParameter(CameraDao.getCamera(4876), objRid.Gamma);
			base.AddParameter(CameraDao.getCamera(4893), objRid.StrobeDelay);
			base.AddParameter(CameraDao.getCamera(4918), objRid.StrobeDuration);
			base.AddParameter(CameraDao.getCamera(4947), objRid.StrobeDurationMode);
			base.AddParameter(CameraDao.getCamera(4980), objRid.StrobeSource);
			base.AddParameter(CameraDao.getCamera(5005), objRid.SyncInGlitchFilter);
			base.AddParameter(CameraDao.getCamera(5038), objRid.SyncInLevels);
			base.AddParameter(CameraDao.getCamera(5063), objRid.SyncInSelector);
			base.AddParameter(CameraDao.getCamera(5092), objRid.SyncOutLevels);
			base.AddParameter(CameraDao.getCamera(5121), objRid.SyncOutPolarity);
			base.AddParameter(CameraDao.getCamera(5150), objRid.SyncOutSelector);
			base.AddParameter(CameraDao.getCamera(5179), objRid.SyncOutSource);
			base.AddParameter(CameraDao.getCamera(5208), objRid.TriggerActivation);
			base.AddParameter(CameraDao.getCamera(5241), objRid.TriggerDelayAbs);
			base.AddParameter(CameraDao.getCamera(5270), objRid.TriggerMode);
			base.AddParameter(CameraDao.getCamera(5295), objRid.TriggerOverlap);
			base.AddParameter(CameraDao.getCamera(5324), objRid.TriggerSelector);
			base.AddParameter(CameraDao.getCamera(5353), objRid.TriggerSource);
			base.AddParameter(CameraDao.getCamera(5382), objRid.UserSetDefaultSelector);
			base.AddParameter(CameraDao.getCamera(5423), objRid.UserSetSelector);
			base.AddParameter(CameraDao.getCamera(5452), objRid.Width);
			base.AddParameter(CameraDao.getCamera(5469), objRid.WidthMax);
			base.AddParameter(CameraDao.getCamera(5490), objRid.Height);
			base.AddParameter(CameraDao.getCamera(5507), objRid.HeightMax);
			base.AddParameter(CameraDao.getCamera(5528), objRid.ImageSize);
			base.AddParameter(CameraDao.getCamera(5549), objRid.PixelFormat);
			base.AddParameter(CameraDao.getCamera(5574), objRid.IrisMode);
			base.AddParameter(CameraDao.getCamera(5595), objRid.IrisAutoTarget);
			base.AddParameter(CameraDao.getCamera(5624), objRid.LensPIrisFrequency);
			base.AddParameter(CameraDao.getCamera(5657), objRid.LensPIrisNumSteps);
			base.AddParameter(CameraDao.getCamera(5690), objRid.LensPIrisPosition);
			base.AddParameter(CameraDao.getCamera(5723), objRid.ColorTransformationMode);
			base.AddParameter(CameraDao.getCamera(5764), objRid.ColorTransformationValues);
			base.ExecuteNonQuery("");
			return true;
		}

		public string SetTestString(RideCameraSettingInfo objRid)
		{
			string arg_802_0 = string.Empty;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.DG_RideCamera_Id);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.AcquisitionFrameCount);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.AcquisitionFrameRateAbs);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.AcquisitionFrameRateLimit);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.AcquisitionMode);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.BalanceRatioAbs);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.BalanceRatioSelector);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.BalanceWhiteAuto);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.BalanceWhiteAutoAdjustTol);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.BalanceWhiteAutoRate);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.EventSelector);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.EventsEnable1);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.ExposureAuto);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.ExposureAutoAdjustTol);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.ExposureAutoAlg);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.ExposureAutoMax);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.ExposureAutoMin);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.ExposureAutoOutliers);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.ExposureAutoRate);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.ExposureAutoTarget);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.ExposureTimeAbs);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.GainAuto);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.GainAutoAdjustTol);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.GainAutoMax);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.GainAutoMin);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.GainAutoOutliers);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.GainAutoRate);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.GainAutoTarget);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.Gain);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.GainSelector);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.Hue);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.Gamma);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.StrobeDelay);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.StrobeDuration);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.StrobeDurationMode);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.StrobeSource);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.SyncInGlitchFilter);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.SyncInLevels);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.SyncInSelector);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.SyncOutLevels);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.SyncOutPolarity);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.SyncOutSelector);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.SyncOutSource);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.TriggerActivation);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.TriggerDelayAbs);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.TriggerMode);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.TriggerOverlap);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.TriggerSelector);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.TriggerSource);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.UserSetDefaultSelector);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.UserSetSelector);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.Width);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.WidthMax);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.Height);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.HeightMax);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.ImageSize);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.IrisMode);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.IrisAutoTarget);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.LensPIrisFrequency);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.LensPIrisNumSteps);
			stringBuilder.Append(CameraDao.getCamera(5809) + objRid.LensPIrisPosition);
			return stringBuilder.ToString();
		}

		public RideCameraSettingInfo GetRideCameraSetting(string RideCameraId)
		{
			IDataReader dataReader;
			RideCameraSettingInfo result;
			while (-1 != 0)
			{
				base.DBParameters.Clear();
				if (false)
				{
					break;
				}
				base.AddParameter(CameraDao.getCamera(5814), RideCameraId);
				if (8 != 0)
				{
					if (!false)
					{
						dataReader = base.ExecuteReader("");
						result = this.rideCameraSettingInfo(dataReader);
						break;
					}
					break;
				}
			}
			dataReader.Close();
			return result;
		}

		private RideCameraSettingInfo rideCameraSettingInfo ( IDataReader dataReader)
		{
			RideCameraSettingInfo rideCameraSettingInfo = new RideCameraSettingInfo();
			while (dataReader.Read())
			{
				rideCameraSettingInfo.DG_RideCamera_pkey = base.GetFieldValue(dataReader, CameraDao.getCamera(5843), 0);
				rideCameraSettingInfo.DG_RideCamera_Id = base.GetFieldValue(dataReader, CameraDao.getCamera(5868), string.Empty);
				rideCameraSettingInfo.AcquisitionFrameCount = base.GetFieldValue(dataReader, CameraDao.getCamera(5893), string.Empty);
				rideCameraSettingInfo.AcquisitionFrameRateAbs = base.GetFieldValue(dataReader, CameraDao.getCamera(5922), string.Empty);
				rideCameraSettingInfo.AcquisitionFrameRateLimit = base.GetFieldValue(dataReader, CameraDao.getCamera(5955), string.Empty);
				rideCameraSettingInfo.AcquisitionMode = base.GetFieldValue(dataReader, CameraDao.getCamera(5992), string.Empty);
				rideCameraSettingInfo.BalanceRatioAbs = base.GetFieldValue(dataReader, CameraDao.getCamera(6013), string.Empty);
				rideCameraSettingInfo.BalanceWhiteAuto = base.GetFieldValue(dataReader, CameraDao.getCamera(6034), string.Empty);
				rideCameraSettingInfo.BalanceWhiteAutoAdjustTol = base.GetFieldValue(dataReader, CameraDao.getCamera(6059), string.Empty);
				while (true)
				{
					rideCameraSettingInfo.BalanceWhiteAutoRate = base.GetFieldValue(dataReader, CameraDao.getCamera(6096), string.Empty);
					rideCameraSettingInfo.EventSelector = base.GetFieldValue(dataReader, CameraDao.getCamera(6125), string.Empty);
					rideCameraSettingInfo.EventsEnable1 = base.GetFieldValue(dataReader, CameraDao.getCamera(6146), string.Empty);
					rideCameraSettingInfo.ExposureAuto = base.GetFieldValue(dataReader, CameraDao.getCamera(6167), string.Empty);
					rideCameraSettingInfo.ExposureAutoAdjustTol = base.GetFieldValue(dataReader, CameraDao.getCamera(6184), string.Empty);
					rideCameraSettingInfo.ExposureAutoAlg = base.GetFieldValue(dataReader, CameraDao.getCamera(6213), string.Empty);
					rideCameraSettingInfo.ExposureAutoMax = base.GetFieldValue(dataReader, CameraDao.getCamera(6234), string.Empty);
					rideCameraSettingInfo.ExposureAutoMin = base.GetFieldValue(dataReader, CameraDao.getCamera(6255), string.Empty);
					rideCameraSettingInfo.ExposureAutoOutliers = base.GetFieldValue(dataReader, CameraDao.getCamera(6276), string.Empty);
					rideCameraSettingInfo.ExposureAutoRate = base.GetFieldValue(dataReader, CameraDao.getCamera(6305), string.Empty);
					rideCameraSettingInfo.ExposureAutoTarget = base.GetFieldValue(dataReader, CameraDao.getCamera(6330), string.Empty);
					rideCameraSettingInfo.ExposureTimeAbs = base.GetFieldValue(dataReader, CameraDao.getCamera(6355), string.Empty);
					rideCameraSettingInfo.GainAuto = base.GetFieldValue(dataReader, CameraDao.getCamera(6376), string.Empty);
					rideCameraSettingInfo.GainAutoAdjustTol = base.GetFieldValue(dataReader, CameraDao.getCamera(6389), string.Empty);
					rideCameraSettingInfo.GainAutoMax = base.GetFieldValue(dataReader, CameraDao.getCamera(6414), string.Empty);
					rideCameraSettingInfo.GainAutoMin = base.GetFieldValue(dataReader, CameraDao.getCamera(6431), string.Empty);
					rideCameraSettingInfo.GainAutoOutliers = base.GetFieldValue(dataReader, CameraDao.getCamera(6448), string.Empty);
					rideCameraSettingInfo.GainAutoRate = base.GetFieldValue(dataReader, CameraDao.getCamera(6473), string.Empty);
					rideCameraSettingInfo.GainAutoTarget = base.GetFieldValue(dataReader, CameraDao.getCamera(6490), string.Empty);
					rideCameraSettingInfo.Gain = base.GetFieldValue(dataReader, CameraDao.getCamera(6511), string.Empty);
					rideCameraSettingInfo.GainSelector = base.GetFieldValue(dataReader, CameraDao.getCamera(6524), string.Empty);
					rideCameraSettingInfo.Hue = base.GetFieldValue(dataReader, CameraDao.getCamera(6541), string.Empty);
					rideCameraSettingInfo.Gamma = base.GetFieldValue(dataReader, CameraDao.getCamera(6546), string.Empty);
					rideCameraSettingInfo.StrobeDelay = base.GetFieldValue(dataReader, CameraDao.getCamera(6555), string.Empty);
					rideCameraSettingInfo.StrobeDuration = base.GetFieldValue(dataReader, CameraDao.getCamera(6572), string.Empty);
					rideCameraSettingInfo.StrobeDurationMode = base.GetFieldValue(dataReader, CameraDao.getCamera(6593), string.Empty);
					rideCameraSettingInfo.StrobeSource = base.GetFieldValue(dataReader, CameraDao.getCamera(6618), string.Empty);
					while (true)
					{
						rideCameraSettingInfo.SyncInGlitchFilter = base.GetFieldValue(dataReader, CameraDao.getCamera(6635), string.Empty);
						rideCameraSettingInfo.SyncInLevels = base.GetFieldValue(dataReader, CameraDao.getCamera(6660), string.Empty);
						rideCameraSettingInfo.SyncInSelector = base.GetFieldValue(dataReader, CameraDao.getCamera(6677), string.Empty);
						rideCameraSettingInfo.SyncOutLevels = base.GetFieldValue(dataReader, CameraDao.getCamera(6698), string.Empty);
						rideCameraSettingInfo.SyncOutPolarity = base.GetFieldValue(dataReader, CameraDao.getCamera(6719), string.Empty);
						rideCameraSettingInfo.SyncOutSelector = base.GetFieldValue(dataReader, CameraDao.getCamera(6740), string.Empty);
						rideCameraSettingInfo.SyncOutSource = base.GetFieldValue(dataReader, CameraDao.getCamera(6761), string.Empty);
						rideCameraSettingInfo.TriggerActivation = base.GetFieldValue(dataReader, CameraDao.getCamera(6782), string.Empty);
						rideCameraSettingInfo.TriggerDelayAbs = base.GetFieldValue(dataReader, CameraDao.getCamera(6807), string.Empty);
						rideCameraSettingInfo.TriggerMode = base.GetFieldValue(dataReader, CameraDao.getCamera(6828), string.Empty);
						rideCameraSettingInfo.TriggerOverlap = base.GetFieldValue(dataReader, CameraDao.getCamera(6845), string.Empty);
						rideCameraSettingInfo.TriggerSelector = base.GetFieldValue(dataReader, CameraDao.getCamera(6866), string.Empty);
						rideCameraSettingInfo.TriggerSource = base.GetFieldValue(dataReader, CameraDao.getCamera(6887), string.Empty);
						rideCameraSettingInfo.UserSetDefaultSelector = base.GetFieldValue(dataReader, CameraDao.getCamera(6908), string.Empty);
						rideCameraSettingInfo.UserSetSelector = base.GetFieldValue(dataReader, CameraDao.getCamera(6941), string.Empty);
						rideCameraSettingInfo.Width = base.GetFieldValue(dataReader, CameraDao.getCamera(6962), string.Empty);
						rideCameraSettingInfo.WidthMax = base.GetFieldValue(dataReader, CameraDao.getCamera(6971), string.Empty);
						if (!true)
						{
							break;
						}
						rideCameraSettingInfo.Height = base.GetFieldValue(dataReader, CameraDao.getCamera(6984), string.Empty);
						rideCameraSettingInfo.HeightMax = base.GetFieldValue(dataReader, CameraDao.getCamera(6993), string.Empty);
						rideCameraSettingInfo.ImageSize = base.GetFieldValue(dataReader, CameraDao.getCamera(7006), string.Empty);
						rideCameraSettingInfo.PixelFormat = base.GetFieldValue(dataReader, CameraDao.getCamera(7019), string.Empty);
						rideCameraSettingInfo.IrisMode = base.GetFieldValue(dataReader, CameraDao.getCamera(7036), string.Empty);
						rideCameraSettingInfo.IrisAutoTarget = base.GetFieldValue(dataReader, CameraDao.getCamera(7049), string.Empty);
						if (!false)
						{
							goto Block_2;
						}
					}
				}
				Block_2:
				rideCameraSettingInfo.LensPIrisFrequency = base.GetFieldValue(dataReader, CameraDao.getCamera(7070), string.Empty);
				rideCameraSettingInfo.LensPIrisNumSteps = base.GetFieldValue(dataReader, CameraDao.getCamera(7095), string.Empty);
				rideCameraSettingInfo.LensPIrisPosition = base.GetFieldValue(dataReader, CameraDao.getCamera(7120), string.Empty);
				rideCameraSettingInfo.ColorTransformationMode = base.GetFieldValue(dataReader, CameraDao.getCamera(7145), string.Empty);
				rideCameraSettingInfo.ColorTransformationValues = base.GetFieldValue(dataReader, CameraDao.getCamera(7178), string.Empty);
			}
			return rideCameraSettingInfo;
		}

		public string GetCameraPathForRideCameraId(string CameraId)
		{
			base.DBParameters.Clear();
			base.AddParameter(CameraDao.getCamera(7215), CameraId);
			object value = base.ExecuteScalar("");
			return Convert.ToString(value);
		}

		public CameraInfo GetLocationWiseCameraDetails(int LocationId)
		{
			IDataReader dataReader;
			if (7 != 0)
			{
				//if (false)
				//{
				//	goto IL_37;
				//}
				List<SqlParameter> expr_4D = base.DBParameters;
				if (!false)
				{
					expr_4D.Clear();
				}
				base.AddParameter(CameraDao.getCamera(7236), LocationId);
				dataReader = base.ExecuteReader("");
			}
			List<CameraInfo> list = this.cameraInfo6(dataReader);
		//	IL_37:

            dataReader.Close();
			if (list != null)
			{
				return list[0];
			}
			return null;
		}

		private List<CameraInfo> cameraInfo6 ( IDataReader dataReader)
		{
			if (3 == 0)
			{
				goto IL_21;
			}
			List<CameraInfo> list = new List<CameraInfo>();
			IL_0D:
			goto IL_BA;
			IL_21:
			CameraInfo cameraInfo;
			cameraInfo.DG_Camera_pkey = base.GetFieldValue(dataReader, CameraDao.getCamera(3163), 0);
			cameraInfo.DG_Camera_Name = base.GetFieldValue(dataReader, CameraDao.getCamera(3209), string.Empty);
			if (!false)
			{
				cameraInfo.DG_AssignTo = new int?(base.GetFieldValue(dataReader, CameraDao.getCamera(3272), 0));
				cameraInfo.DG_CameraFolder = base.GetFieldValue(dataReader, CameraDao.getCamera(3360), string.Empty);
			}
			CameraInfo item = cameraInfo;
			list.Add(item);
			IL_BA:
			if (!dataReader.Read())
			{
				return list;
			}
			if (6 == 0)
			{
				goto IL_0D;
			}
			CameraInfo expr_D7 = new CameraInfo();
			if (6 == 0)
			{
				goto IL_21;
			}
			cameraInfo = expr_D7;
			goto IL_21;
		}

		static CameraDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CameraDao));
		}
	}
}
