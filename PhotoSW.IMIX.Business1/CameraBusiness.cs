using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using ErrorHandler;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class CameraBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public List<CameraInfo> ;

			public CameraBusiness ;

			public void ()
			{
				CameraDao cameraDao = new CameraDao(this..Transaction);
				this. = cameraDao.SelectRideCamera();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<CameraInfo> ;

			public CameraBusiness ;

			public void ()
			{
				CameraDao cameraDao = new CameraDao(this..Transaction);
				this. = cameraDao.GetCameraList();
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CameraBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CameraBusiness. ;

			public List<CameraInfo> ;

			public void ()
			{
				do
				{
					if (2 != 0)
					{
						CameraDao cameraDao = new CameraDao(this...Transaction);
						if (false)
						{
							continue;
						}
						this. = cameraDao.GetCameraDetailsByID(new int?(this..), null);
					}
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CameraBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CameraBusiness. ;

			public List<CameraInfo> ;

			public void ()
			{
				do
				{
					if (2 != 0)
					{
						CameraDao cameraDao = new CameraDao(this...Transaction);
						if (false)
						{
							continue;
						}
						this. = cameraDao.GetCameraDetailsByID(null, new int?(this..));
					}
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public CameraBusiness ;

			public int ;

			public void ()
			{
				do
				{
					CameraDao cameraDao;
					if (!false)
					{
						cameraDao = new CameraDao(this..Transaction);
					}
					this. = cameraDao.Delete(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CameraBusiness ;

			public CameraInfo ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CameraBusiness. ;

			public bool ;

			public void ()
			{
				if (4 != 0)
				{
					CameraDao cameraDao = new CameraDao(this...Transaction);
					if (!false)
					{
						this. = cameraDao.SetGetCameraDetails(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<CameraInfo> ;

			public CameraBusiness ;

			public int ;

			public void ()
			{
				do
				{
					CameraDao cameraDao;
					if (!false)
					{
						cameraDao = new CameraDao(this..Transaction);
					}
					this. = cameraDao.GetIsResetDPIRequired(this.);
				}
				while (false);
			}

			public bool (CameraInfo )
			{
				bool? dG_Camera_IsDeleted;
				while (true)
				{
					if (7 == 0)
					{
						goto IL_26;
					}
					int? dG_AssignTo;
					int arg_5C_0;
					if (!false)
					{
						dG_AssignTo = .DG_AssignTo;
						arg_5C_0 = this.;
						goto IL_13;
					}
					IL_29:
					dG_Camera_IsDeleted = .DG_Camera_IsDeleted;
					if (!dG_Camera_IsDeleted.GetValueOrDefault())
					{
						break;
					}
					if (4 == 0)
					{
						continue;
					}
					int arg_27_0;
					int expr_46 = arg_27_0 = (arg_5C_0 = 0);
					if (expr_46 == 0)
					{
						return expr_46 != 0;
					}
					goto IL_21;
					IL_27:
					if (arg_27_0 != 0)
					{
						goto IL_29;
					}
					return false;
					IL_26:
					arg_27_0 = 0;
					goto IL_27;
					IL_21:
					if (6 != 0)
					{
						goto IL_27;
					}
					IL_13:
					int num = arg_5C_0;
					if (dG_AssignTo.GetValueOrDefault() == num)
					{
						arg_5C_0 = (arg_27_0 = (dG_AssignTo.HasValue ? 1 : 0));
						goto IL_21;
					}
					goto IL_26;
				}
				return dG_Camera_IsDeleted.HasValue;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public CameraBusiness ;

			public RideCameraSettingInfo ;

			public void ()
			{
				do
				{
					CameraDao cameraDao;
					if (!false)
					{
						cameraDao = new CameraDao(this..Transaction);
					}
					this. = cameraDao.SetTripCameraSetting(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public RideCameraSettingInfo ;

			public CameraBusiness ;

			public string ;

			public void ()
			{
				do
				{
					CameraDao cameraDao;
					if (!false)
					{
						cameraDao = new CameraDao(this..Transaction);
					}
					this. = cameraDao.GetRideCameraSetting(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CameraBusiness ;

			public string ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CameraBusiness. ;

			public string ;

			public void ()
			{
				if (4 != 0)
				{
					CameraDao cameraDao = new CameraDao(this...Transaction);
					if (!false)
					{
						this. = cameraDao.GetCameraPathForRideCameraId(this..);
					}
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CameraBusiness ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public CameraBusiness. ;

			public CameraInfo ;

			public void ()
			{
				if (4 != 0)
				{
					CameraDao cameraDao = new CameraDao(this...Transaction);
					if (!false)
					{
						this. = cameraDao.GetLocationWiseCameraDetails(this..);
					}
				}
			}
		}

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public List<CameraInfo> GetAvailableRideCameras()
		{
			List<CameraInfo> result;
			try
			{
				CameraBusiness.  = new CameraBusiness.();
				if (4 == 0)
				{
					goto IL_40;
				}
				. = this;
				do
				{
					IL_10:
					. = new List<CameraInfo>();
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
				while (7 == 0);
				result = .;
				IL_40:
				if (false)
				{
					goto IL_10;
				}
			}
			catch (Exception serviceException)
			{
				if (6 != 0)
				{
					ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
					result = null;
				}
			}
			return result;
		}

		public List<CameraInfo> GetCameraList()
		{
			List<CameraInfo> result;
			try
			{
				CameraBusiness.  = new CameraBusiness.();
				if (4 == 0)
				{
					goto IL_40;
				}
				. = this;
				do
				{
					IL_10:
					. = new List<CameraInfo>();
					this.operation = new BaseBusiness.TransactionMethod(.);
					base.Start(false);
				}
				while (7 == 0);
				result = .;
				IL_40:
				if (false)
				{
					goto IL_10;
				}
			}
			catch (Exception serviceException)
			{
				if (6 != 0)
				{
					ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
					result = null;
				}
			}
			return result;
		}

		public CameraInfo GetCameraByID(int CameraId)
		{
			CameraInfo result;
			if (-1 != 0)
			{
				CameraBusiness.  = new CameraBusiness.();
				. = CameraId;
				. = this;
				try
				{
					while (true)
					{
						CameraBusiness.  = new CameraBusiness.();
						while (7 != 0)
						{
							. = ;
							. = new List<CameraInfo>();
							while (!false)
							{
								this.operation = new BaseBusiness.TransactionMethod(.);
								base.Start(false);
								if (4 != 0)
								{
									result = ..FirstOrDefault<CameraInfo>();
									break;
								}
							}
							if (!false)
							{
								goto Block_6;
							}
						}
					}
					Block_6:;
				}
				catch (Exception serviceException)
				{
					ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
					result = null;
				}
			}
			return result;
		}

		public CameraInfo GetCameraByPhotographerId(int PhotographerId)
		{
			CameraInfo result;
			if (-1 != 0)
			{
				CameraBusiness.  = new CameraBusiness.();
				. = PhotographerId;
				. = this;
				try
				{
					while (true)
					{
						CameraBusiness.  = new CameraBusiness.();
						while (7 != 0)
						{
							. = ;
							. = new List<CameraInfo>();
							while (!false)
							{
								this.operation = new BaseBusiness.TransactionMethod(.);
								base.Start(false);
								if (4 != 0)
								{
									result = ..FirstOrDefault<CameraInfo>();
									break;
								}
							}
							if (!false)
							{
								goto Block_6;
							}
						}
					}
					Block_6:;
				}
				catch (Exception serviceException)
				{
					ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
					result = null;
				}
			}
			return result;
		}

		public string DeleteCameraDetails(int CameraId)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			if (4 != 0)
			{
				transactionMethod = null;
				if (4 == 0)
				{
					goto IL_31;
				}
			}
			. = this;
			IL_31:
			. = string.Empty;
			string 2;
			try
			{
				if (7 != 0)
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.2);
					}
					this.operation = transactionMethod;
				}
				base.Start(false);
				2 = .;
			}
			catch (Exception)
			{
				do
				{
					2 = .;
				}
				while (6 == 0 || 2 == 0);
			}
			return 2;
		}

		public bool SetCameraDetails(CameraInfo _objCameraInfo)
		{
			if (!false && -1 != 0)
			{
			}
			. = _objCameraInfo;
			. = this;
			bool result;
			try
			{
				CameraBusiness.  = new CameraBusiness.();
				if (!false)
				{
					. = ;
				}
				. = false;
				this.operation = new BaseBusiness.TransactionMethod(.);
				bool arg_67_0 = base.Start(false);
				if (!false && 4 != 0)
				{
					arg_67_0 = .;
				}
				result = arg_67_0;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool CheckResetDPIRequired(int PhotographerId)
		{
			bool result;
			try
			{
				bool expr_00 = false;
				bool flag;
				if (!false)
				{
					flag = expr_00;
				}
				if (4 != 0)
				{
					CameraInfo cameraByPhotographerId = this.GetCameraByPhotographerId(PhotographerId);
					if (cameraByPhotographerId == null)
					{
						goto IL_40;
					}
					bool? isChromaColor = cameraByPhotographerId.IsChromaColor;
					if (8 == 0)
					{
						goto IL_26;
					}
					int arg_24_0 = isChromaColor.HasValue ? 1 : 0;
					IL_24:
					int arg_3F_0;
					if (arg_24_0 != 0)
					{
						arg_3F_0 = (arg_24_0 = (Convert.ToBoolean(cameraByPhotographerId.IsChromaColor) ? 1 : 0));
						goto IL_3C;
					}
					IL_26:
					if (!true)
					{
						goto IL_45;
					}
					arg_3F_0 = (arg_24_0 = 0);
					IL_3C:
					if (false)
					{
						goto IL_24;
					}
					flag = (arg_3F_0 != 0);
					IL_40:
					bool expr_40 = (arg_24_0 = (arg_3F_0 = (flag ? 1 : 0))) != 0;
					if (false)
					{
						goto IL_3C;
					}
					result = expr_40;
				}
				IL_45:;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool CheckResetDPIRequired(string HR, string VR, int PhotographerId)
		{
			bool result;
			try
			{
				int num = Convert.ToInt32(HR.Replace(CameraBusiness.(227), CameraBusiness.(232)));
				int num2 = Convert.ToInt32(VR.Replace(CameraBusiness.(227), CameraBusiness.(232)));
				bool flag = false;
				int arg_B8_0;
				while (true)
				{
					CameraInfo cameraByPhotographerId = this.GetCameraByPhotographerId(PhotographerId);
					while (true)
					{
						if (cameraByPhotographerId == null)
						{
							goto IL_9B;
						}
						bool? isChromaColor = cameraByPhotographerId.IsChromaColor;
						if (!false)
						{
							bool arg_9A_0;
							if (!isChromaColor.HasValue)
							{
								if (!true)
								{
									break;
								}
								arg_9A_0 = false;
							}
							else
							{
								if (false)
								{
									goto IL_AE;
								}
								arg_9A_0 = Convert.ToBoolean(cameraByPhotographerId.IsChromaColor);
							}
							flag = arg_9A_0;
							goto IL_9B;
						}
						IL_B1:
						if (8 != 0 && !false)
						{
							goto Block_10;
						}
						continue;
						IL_AE:
						if (flag)
						{
							goto IL_B1;
						}
						goto IL_BC;
						IL_9B:
						if (num != 300)
						{
							goto IL_AE;
						}
						int expr_A3 = arg_B8_0 = num2;
						if (false)
						{
							goto IL_B8;
						}
						if (expr_A3 != 300)
						{
							goto IL_AE;
						}
						goto IL_BC;
					}
				}
				Block_10:
				arg_B8_0 = 1;
				IL_B8:
				result = (arg_B8_0 != 0);
				return result;
				IL_BC:
				result = false;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		public bool GetIsResetDPIRequired(int PhotoGrapherId)
		{
			bool? flag;
			while (true)
			{
				CameraBusiness.  = new CameraBusiness.();
				. = PhotoGrapherId;
				if (-1 != 0)
				{
					. = this;
				}
				. = new List<CameraInfo>();
				this.operation = new BaseBusiness.TransactionMethod(.);
				base.Start(false);
				bool? isChromaColor = ..Where(new Func<CameraInfo, bool>(.)).FirstOrDefault<CameraInfo>().IsChromaColor;
				if (!false)
				{
					bool arg_8A_0;
					int arg_8D_0 = (arg_8A_0 = isChromaColor.HasValue) ? 1 : 0;
					bool expr_8D;
					while (true)
					{
						if (true)
						{
							if (arg_8A_0)
							{
								goto IL_97;
							}
							arg_8D_0 = 0;
						}
						expr_8D = (arg_8A_0 = ((arg_8D_0 = arg_8D_0) != 0));
						if (!expr_8D)
						{
							goto Block_4;
						}
					}
					IL_98:
					bool? arg_98_0;
					flag = arg_98_0;
					if (6 != 0)
					{
						break;
					}
					continue;
					IL_97:
					arg_98_0 = isChromaColor;
					goto IL_98;
					Block_4:
					arg_98_0 = new bool?(expr_8D);
					goto IL_98;
				}
			}
			return flag.Value;
		}

		public bool SetTripCameraSetting(RideCameraSettingInfo objRid)
		{
			CameraBusiness.  = new CameraBusiness.();
			. = objRid;
			if (false)
			{
				goto IL_3A;
			}
			. = this;
			IL_19:
			if (false)
			{
				goto IL_42;
			}
			. = false;
			new List<CameraInfo>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_3A:
			base.Start(false);
			IL_41:
			IL_42:
			if (false)
			{
				goto IL_19;
			}
			bool expr_46 = .;
			if (!false && !false)
			{
				return expr_46;
			}
			goto IL_41;
		}

		public RideCameraSettingInfo GetRideCameraSetting(string CameraId)
		{
			CameraBusiness.  = new CameraBusiness.();
			. = CameraId;
			. = this;
			. = new RideCameraSettingInfo();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public string GetCameraPathForRideCameraId(string CameraId)
		{
			if (!false && -1 != 0)
			{
			}
			. = CameraId;
			. = this;
			string result;
			try
			{
				CameraBusiness.  = new CameraBusiness.();
				if (!false)
				{
					. = ;
				}
				. = string.Empty;
				if (6 != 0)
				{
					this.operation = new BaseBusiness.TransactionMethod(.);
					if (!false)
					{
						base.Start(false);
						result = .;
					}
				}
			}
			catch
			{
				result = string.Empty;
			}
			return result;
		}

		public CameraInfo GetLocationWiseCameraDetails(int LocationId)
		{
			CameraBusiness.  = new CameraBusiness.();
			. = LocationId;
			. = this;
			CameraInfo result;
			try
			{
				CameraBusiness.  = new CameraBusiness.();
				do
				{
					. = ;
					if (4 != 0)
					{
						. = new CameraInfo();
						this.operation = new BaseBusiness.TransactionMethod(.);
						if (false)
						{
							goto IL_6C;
						}
						if (!false)
						{
							base.Start(false);
						}
					}
					if (false)
					{
						continue;
					}
					result = .;
					IL_6C:;
				}
				while (6 == 0);
			}
			catch (Exception serviceException)
			{
				ErrorHandler.LogFileWrite(ErrorHandler.CreateErrorMessage(serviceException));
				result = null;
			}
			return result;
		}

		static CameraBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(CameraBusiness));
		}
	}
}
