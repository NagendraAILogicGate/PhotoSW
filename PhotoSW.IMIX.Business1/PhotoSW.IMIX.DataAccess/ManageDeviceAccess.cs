//using DigiPhoto.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PhotoSW.IMIX.Model;

namespace PhotoSW.IMIX.DataAccess
{
	public class ManageDeviceAccess : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getManageDevice;
        public ManageDeviceAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public ManageDeviceAccess()
		{
		}

		public bool SaveDevice(DeviceInfo device)
		{
			base.DBParameters.Clear();
			do
			{
				base.AddParameter(ManageDeviceAccess.getManageDevice(1619), device.Name);
				base.AddParameter(ManageDeviceAccess.getManageDevice(4304), device.SerialNo);
				base.AddParameter(ManageDeviceAccess.getManageDevice(48607), device.BDA);
				if (false)
				{
					return true;
				}
				base.AddParameter(ManageDeviceAccess.getManageDevice(48620), device.DeviceTypeId);
				base.AddParameter(ManageDeviceAccess.getManageDevice(2650), device.CreatedBy);
				if (3 == 0)
				{
					goto IL_11B;
				}
				base.AddParameter(ManageDeviceAccess.getManageDevice(8440), device.CreatedDate);
			}
			while (3 == 0);
			base.AddParameter(ManageDeviceAccess.getManageDevice(1636), device.IsActive);
			base.AddParameter(ManageDeviceAccess.getManageDevice(48645), device.DeviceId);
			IL_11B:
			base.ExecuteNonQuery(ManageDeviceAccess.getManageDevice(48666));
			return true;
		}

		public List<DeviceInfo> GetDeviceList(long DeviceId)
		{
			List<DeviceInfo> result;
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
					base.AddParameter(ManageDeviceAccess.getManageDevice(48695), DeviceId);
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
				dataReader = base.ExecuteReader(ManageDeviceAccess.getManageDevice(48708));
				result = this.deviceInfo(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<DeviceInfo> deviceInfo ( IDataReader dataReader)
		{
			List<DeviceInfo> list = new List<DeviceInfo>();
			while (dataReader.Read())
			{
				list.Add(new DeviceInfo
				{
					DeviceId = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(48721), 0),
					Name = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(969), string.Empty),
					SerialNo = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(3911), string.Empty),
					BDA = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(48734), string.Empty),
					DeviceTypeId = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(48739), 0),
					CreatedDate = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(3322), DateTime.Now),
					CreatedBy = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(3292), 0),
					IsActive = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(3527), false),
					DeviceTypeName = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(48756), string.Empty)
				});
			}
			return list;
		}

		public bool DeleteDevice(long DeviceId)
		{
			base.DBParameters.Clear();
			base.AddParameter(ManageDeviceAccess.getManageDevice(48645), DeviceId);
			base.ExecuteNonQuery(ManageDeviceAccess.getManageDevice(48777));
			return true;
		}

		public List<CameraDeviceAssociationInfo> GetCameraDeviceList(long cameraId)
		{
			List<CameraDeviceAssociationInfo> result;
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
					base.AddParameter(ManageDeviceAccess.getManageDevice(29998), cameraId);
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
				dataReader = base.ExecuteReader(ManageDeviceAccess.getManageDevice(48798));
				result = this.cameraDeviceAssociationInfo(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<CameraDeviceAssociationInfo> cameraDeviceAssociationInfo ( IDataReader dataReader)
		{
			List<CameraDeviceAssociationInfo> list = new List<CameraDeviceAssociationInfo>();
			while (true)
			{
				while (dataReader.Read())
				{
					CameraDeviceAssociationInfo cameraDeviceAssociationInfo = new CameraDeviceAssociationInfo();
					if (7 != 0)
					{
						cameraDeviceAssociationInfo.DeviceId = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(48721), 0);
						cameraDeviceAssociationInfo.CameraId = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(30086), 0);
						list.Add(cameraDeviceAssociationInfo);
					}
				}
				break;
			}
			return list;
		}

		public List<DeviceInfo> GetPhotoGrapherDeviceList(int photographerId)
		{
			List<DeviceInfo> result;
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
					base.AddParameter(ManageDeviceAccess.getManageDevice(48819), photographerId);
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
				dataReader = base.ExecuteReader(ManageDeviceAccess.getManageDevice(48840));
				result = this.deviceInfo2(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<DeviceInfo> deviceInfo2 ( IDataReader dataReader)
		{
			List<DeviceInfo> list = new List<DeviceInfo>();
			while (true)
			{
				while (dataReader.Read())
				{
					DeviceInfo deviceInfo = new DeviceInfo();
					if (7 != 0)
					{
						deviceInfo.DeviceId = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(48721), 0);
						deviceInfo.Name = base.GetFieldValue(dataReader, ManageDeviceAccess.getManageDevice(48877), string.Empty);
						list.Add(deviceInfo);
					}
				}
				break;
			}
			return list;
		}

		public bool SaveCameraDeviceAssociation(int CameraId, string DeviceIds)
		{
			while (true)
			{
				if (!false)
				{
					List<SqlParameter> expr_5D = base.DBParameters;
					if (!false)
					{
						expr_5D.Clear();
					}
					if (-1 == 0)
					{
						goto IL_52;
					}
					base.AddParameter(ManageDeviceAccess.getManageDevice(48894), DeviceIds);
					base.AddParameter(ManageDeviceAccess.getManageDevice(29998), CameraId);
				}
				IL_39:
				if (5 == 0)
				{
					continue;
				}
				base.ExecuteNonQuery(ManageDeviceAccess.getManageDevice(48911));
				IL_52:
				if (true)
				{
					if (!false)
					{
						break;
					}
					goto IL_39;
				}
			}
			return true;
		}

		public bool SaveCameraCharacterAssociation(int CameraId, int Camerapkey, int? CharacterIds)
		{
			base.DBParameters.Clear();
			base.AddParameter(ManageDeviceAccess.getManageDevice(48948), (CharacterIds == 0) ? null : CharacterIds);
			base.AddParameter(ManageDeviceAccess.getManageDevice(29998), CameraId);
			base.AddParameter(ManageDeviceAccess.getManageDevice(48969), Camerapkey);
			base.ExecuteNonQuery(ManageDeviceAccess.getManageDevice(48986));
			return true;
		}

		public bool DeleteCameraDeviceAssociation(int cameraId)
		{
			base.DBParameters.Clear();
			base.AddParameter(ManageDeviceAccess.getManageDevice(29998), cameraId);
			base.ExecuteNonQuery(ManageDeviceAccess.getManageDevice(49027));
			return true;
		}

		public bool IsDeviceAssociatedToOthers(int CameraId, string DeviceIds)
		{
			base.DBParameters.Clear();
			base.AddParameter(ManageDeviceAccess.getManageDevice(48894), DeviceIds);
			base.AddParameter(ManageDeviceAccess.getManageDevice(29998), CameraId);
			base.AddParameter(ManageDeviceAccess.getManageDevice(49072), 0, ParameterDirection.Output);
			base.ExecuteNonQuery(ManageDeviceAccess.getManageDevice(49081));
			return (int)base.GetOutParameterValue(ManageDeviceAccess.getManageDevice(49072)) > 0;
		}

		public int DeletCameraDeviceSyncDetailsAccess(int CameraId, string DeviceIds)
		{
			int expr_7C;
			while (true)
			{
				int arg_97_0 = Convert.ToInt32(DeviceIds);
				while (true)
				{
					int num = arg_97_0;
					if (7 == 0)
					{
						break;
					}
					base.DBParameters.Clear();
					int num2;
					do
					{
						base.AddParameter(ManageDeviceAccess.getManageDevice(48695), num);
						base.AddParameter(ManageDeviceAccess.getManageDevice(29998), CameraId);
						num2 = (int)base.ExecuteScalar(ManageDeviceAccess.getManageDevice(49114));
					}
					while (3 == 0);
					expr_7C = (arg_97_0 = num2);
					if (true)
					{
						return expr_7C;
					}
				}
			}
			return expr_7C;
		}

		static ManageDeviceAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			//SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ManageDeviceAccess));
		}
	}
}
