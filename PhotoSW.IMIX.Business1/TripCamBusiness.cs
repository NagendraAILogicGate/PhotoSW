using DigiPhoto.DataLayer;
using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class TripCamBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public TripCamBusiness ;

			public int ;

			public int ;
		}

		[CompilerGenerated]
		private sealed class 
		{
			public TripCamBusiness. ;

			public bool ;

			public void ()
			{
				TripCamDao tripCamDao = new TripCamDao(this...Transaction);
				this. = tripCamDao.UpdCamIdForTripCamPOSMapping(this.., this..);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public TripCamInfo ;

			public TripCamBusiness ;

			public string ;

			public string ;

			public void ()
			{
				if (4 != 0)
				{
					TripCamDao tripCamDao = new TripCamDao(this..Transaction);
					this. = tripCamDao.GetTripCameraInfoById(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<TripCamSettingInfo> ;

			public TripCamBusiness ;

			public int ;

			public int ;

			public void ()
			{
				if (4 != 0)
				{
					TripCamDao tripCamDao = new TripCamDao(this..Transaction);
					this. = tripCamDao.GetTripCamSettingsForCameraId(this., this.);
				}
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<TripCamSettingInfo> ;

			public TripCamBusiness ;

			public int ;

			public void ()
			{
				do
				{
					TripCamDao tripCamDao;
					if (!false)
					{
						tripCamDao = new TripCamDao(this..Transaction);
					}
					this. = tripCamDao.GetSavedTripCamSettingsForCameraId(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public TripCamBusiness ;

			public string ;

			public void ()
			{
				do
				{
					TripCamDao tripCamDao;
					if (!false)
					{
						tripCamDao = new TripCamDao(this..Transaction);
					}
					this. = tripCamDao.ValidateCameraRunningStatus(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public TripCamBusiness ;

			public string ;

			public void ()
			{
				do
				{
					TripCamDao tripCamDao;
					if (!false)
					{
						tripCamDao = new TripCamDao(this..Transaction);
					}
					this. = tripCamDao.ValidateCameraAvailability(this.);
				}
				while (false);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public DataTable ;

			public bool ;

			public TripCamBusiness ;

			public void ()
			{
				do
				{
					TripCamDao tripCamDao;
					if (!false)
					{
						tripCamDao = new TripCamDao(this..Transaction);
					}
					this. = tripCamDao.InsUpdTripCamSettings(this.);
				}
				while (false);
			}
		}

		[NonSerialized]
		internal static SmartAssembly.Delegates.GetString ;

		public bool UpdCamIdForTripCamPOSMapping(int oldCamId, int NewCamid)
		{
			TripCamBusiness.  = new TripCamBusiness.();
			bool result;
			do
			{
				. = oldCamId;
				if (!false)
				{
					. = NewCamid;
					. = this;
					try
					{
						TripCamBusiness.  = new TripCamBusiness.();
						. = ;
						. = false;
						this.operation = new BaseBusiness.TransactionMethod(.);
						base.Start(false);
						if (6 != 0)
						{
							result = .;
						}
					}
					catch
					{
						do
						{
							result = false;
						}
						while (2 == 0);
					}
				}
			}
			while (3 == 0);
			return result;
		}

		public TripCamInfo GetTripCameraInfoById(string CameraName, string CameraId)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			if (6 != 0)
			{
				if (!false)
				{
					transactionMethod = null;
				}
				. = this;
			}
			. = new TripCamInfo();
			TripCamInfo 2;
			try
			{
				while (true)
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.2);
					}
					this.operation = transactionMethod;
					base.Start(false);
					if (!false)
					{
						2 = .;
						if (6 != 0)
						{
							break;
						}
					}
				}
			}
			catch
			{
				do
				{
					2 = .;
				}
				while (6 == 0);
			}
			return 2;
		}

		public List<TripCamSettingInfo> GetTripCamSettingsForCameraId(int CameraId, int TripCamTypeId)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			if (6 != 0)
			{
				if (!false)
				{
					transactionMethod = null;
				}
				. = this;
			}
			. = new List<TripCamSettingInfo>();
			List<TripCamSettingInfo> 2;
			try
			{
				while (true)
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.2);
					}
					this.operation = transactionMethod;
					base.Start(false);
					if (!false)
					{
						2 = .;
						if (6 != 0)
						{
							break;
						}
					}
				}
			}
			catch
			{
				do
				{
					2 = .;
				}
				while (6 == 0);
			}
			return 2;
		}

		public List<TripCamSettingInfo> GetSavedTripCamSettingsForCameraId(int Cameraid)
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
			. = this;
			IL_31:
			. = new List<TripCamSettingInfo>();
			List<TripCamSettingInfo> 2;
			try
			{
				if (7 != 0)
				{
					if (transactionMethod == null)
					{
						transactionMethod = new BaseBusiness.TransactionMethod(.2);
					}
					this.operation = transactionMethod;
				}
				base.Start(false);
				2 = .;
			}
			catch
			{
				do
				{
					2 = .;
				}
				while (6 == 0 || 2 == 0);
			}
			return 2;
		}

		public bool ValidateCameraRunningStatus(string CamMake)
		{
			TripCamBusiness.  = new TripCamBusiness.();
			. = CamMake;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public bool ValidateCameraAvailability(string CamMake)
		{
			TripCamBusiness.  = new TripCamBusiness.();
			. = CamMake;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public bool InsUpdTripCamSettings(TripCamFeaturesInfo tripCamFeaturesInfo, int CamId)
		{
			TripCamBusiness.  = new TripCamBusiness.();
			if (false)
			{
				goto IL_22;
			}
			. = this;
			IL_10:
			if (!false)
			{
				. = this.(tripCamFeaturesInfo, CamId);
			}
			IL_22:
			if (!false)
			{
				if (8 != 0)
				{
					. = false;
					if (false)
					{
						goto IL_10;
					}
					this.operation = new BaseBusiness.TransactionMethod(.);
				}
				base.Start(false);
			}
			return .;
		}

		private DataTable (TripCamFeaturesInfo , int )
		{
			return new DataTable
			{
				Columns = 
				{
					TripCamBusiness.(270),
					TripCamBusiness.(303),
					TripCamBusiness.(324)
				},
				Rows = 
				{
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Height),
						Convert.ToString(.Height),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.HeightMax),
						Convert.ToString(.HeightMax),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.OffsetX),
						Convert.ToString(.OffsetX),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.OffsetY),
						Convert.ToString(.OffsetY),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Width),
						Convert.ToString(.Width),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.WidthMax),
						Convert.ToString(.WidthMax),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Hue),
						Convert.ToString(.Hue),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Saturation),
						Convert.ToString(.Saturation),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.WhiteBalanceRed),
						Convert.ToString(.WhiteBalanceRed),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.WhiteBalanceBlue),
						Convert.ToString(.WhiteBalanceBlue),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.CameraName),
						Convert.ToString(.CameraName),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.NoOfImages),
						Convert.ToString(.NoOfImages),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.TriggerDelay),
						Convert.ToString(.TriggerDelay),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.ExposureTime),
						Convert.ToString(.ExposureTime),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.CameraRotation),
						Convert.ToString(.CameraRotation),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.StrobeDelay),
						Convert.ToString(.StrobeDelay),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.StrobeDuration),
						Convert.ToString(.StrobeDuration),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.StrobeDurationMode),
						Convert.ToString(.StrobeDurationMode),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.StrobeSource),
						Convert.ToString(.StrobeSource),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.PacketSize),
						Convert.ToString(.PacketSize),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.MACAddress),
						Convert.ToString(.MACAddress),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.IPConfigurationMode),
						Convert.ToString(.IPConfigurationMode),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.IPAddress),
						Convert.ToString(.IPAddress),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Subnet),
						Convert.ToString(.Subnet),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Gateway),
						Convert.ToString(.Gateway),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.PixelFormat),
						Convert.ToString(.PixelFormat),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.TriggerSource),
						Convert.ToString(.TriggerSource),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.LensFocus),
						Convert.ToString(.LensFocus),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Aperture),
						Convert.ToString(.Aperture),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.CameraRotation),
						Convert.ToString(.CameraRotation),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.StreamBytesPerSec),
						Convert.ToString(.StreamBytesPerSec),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.BlackLevel),
						Convert.ToString(.BlackLevel),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Gain),
						Convert.ToString(.Gain),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Gamma),
						Convert.ToString(.Gamma),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Gain00),
						Convert.ToString(.Gain00),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Gain01),
						Convert.ToString(.Gain01),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Gain02),
						Convert.ToString(.Gain02),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Gain10),
						Convert.ToString(.Gain10),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Gain11),
						Convert.ToString(.Gain11),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Gain12),
						Convert.ToString(.Gain12),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Gain20),
						Convert.ToString(.Gain20),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Gain21),
						Convert.ToString(.Gain21),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.Gain22),
						Convert.ToString(.Gain22),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.ColorTransformationMode),
						Convert.ToString(.ColorTransformationMode),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.StrobeSource),
						Convert.ToString(.ExposureMode),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.SyncOutPolarity),
						Convert.ToString(.SyncOutPolarity),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.SyncOutSelector),
						Convert.ToString(.SyncOutSelector),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.SyncOutSource),
						Convert.ToString(.SyncOutSource),
						
					},
					new object[]
					{
						Convert.ToInt32(TripCamFeatures.AcquisitionMode),
						Convert.ToString(.AcquisitionMode),
						
					}
				}
			};
		}

		static TripCamBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(TripCamBusiness));
		}
	}
}
