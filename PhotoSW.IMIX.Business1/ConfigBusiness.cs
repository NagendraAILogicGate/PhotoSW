using PhotoSW.Cache.DataCache;
using PhotoSW.Cache.MasterDataCache;
using PhotoSW.Cache.Repository;
//using PhotoSW.Cache.SqlDependentCache;
using PhotoSW.DataLayer;
using PhotoSW.IMIX.DataAccess;
using PhotoSW.IMIX.Model;
//using DigiPhoto.Utility.Repository.ValueType;
//using ErrorHandler;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;


namespace PhotoSW.IMIX.Business
{
	public class ConfigBusiness : BaseBusiness
	{
        private sealed class csSOH
		{
			public DataTable dtSOH;

			public bool STX;

			public ConfigBusiness ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.ETX.Transaction);
					}
					this.STX= configAccess.SaveUpdateConfigLocation(this.dtSOH);
				}
				while (false);
			}
		}
        private sealed class csSTX
		{
			public DataTable dtSOH;

			public bool STX;

			public ConfigBusiness ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
            
						configAccess = new ConfigAccess(this.ETX.Transaction);
					}
                    this.STX = configAccess.SaveUpdateNewConfig(this.dtSOH);
				}
				while (false);
			}
		}
        private sealed class csETX
		{
			public ConfigBusiness ConfigBusiness_SOH;

			public Dictionary<long, string> STX;

			public int ETX;

			private static Func<iMIXConfigurationInfo, long> EOT;

			private static Func<iMIXConfigurationInfo, string> ENQ;

			public void SOH()
			{
				ConfigAccess configAccess = new ConfigAccess(this.ConfigBusiness_SOH.Transaction);
				IEnumerable<iMIXConfigurationInfo> arg_98_0 = configAccess.GetConfigurations(this.ETX);
               ConfigBusiness.csETX ETX=new csETX ();
				if (ConfigBusiness.csETX.EOT == null)
				{
					ConfigBusiness.csETX.EOT = new Func<iMIXConfigurationInfo, long>(ConfigBusiness.csETX.EOT);
				}
				Func<iMIXConfigurationInfo, long> arg_98_1 = ConfigBusiness.csETX.EOT;
				if (ConfigBusiness.csETX.ENQ == null)
				{
					ConfigBusiness.csETX.ENQ = new Func<iMIXConfigurationInfo, string>(ConfigBusiness.csETX.ENQ );
				}
				this.STX = arg_98_0.ToDictionary(arg_98_1, ConfigBusiness.csETX.ENQ );
			}

			private static long LongSOH(iMIXConfigurationInfo STX)
			{
				return STX.IMIXConfigurationMasterId;
			}

			private static string StrSOH(iMIXConfigurationInfo STX)
			{
				return STX.ConfigurationValue;
			}
		}
       private sealed class csEOT
		{
			public List<iMixConfigurationLocationInfo> lst_SOH;

			public ConfigBusiness STX;
			public int ETX;
			public int EOT; 

			public void SOH()
			{
				if (4 != 0)
				{
					ConfigAccess configAccess = new ConfigAccess(this.STX.Transaction);
					this.lst_SOH= configAccess.GetConfigLocation(this.ETX, this.EOT);
				}
			}
		}

		private sealed class csENQ
		{
			public List<iMixConfigurationLocationInfo> lst_SOH;

			public ConfigBusiness STX;

			public int ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.lst_SOH= configAccess.GetConfigBasedOnLocation(this.ETX);
				}
				while (false);
			}
		}
        private sealed class ACK
		{
			public string str_SOH;

			public ConfigBusiness STX;

			public int ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
                    this.str_SOH = configAccess.GetHotFolderPath(this.ETX);
				}
				while (false);
			}
		}
        private sealed class csBEL
		{
			public FolderStructureInfo  FolderStructureInfo_SOH;

			public ConfigBusiness STX;

			public int ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.FolderStructureInfo_SOH= configAccess.GetFolderStructureInfo(this.ETX);
				}
				while (false);
			}
		}
        
		private sealed class csBS
		{
			public DataTable dt_SOH;

			public bool STX;

			public ConfigBusiness ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.ETX.Transaction);
					}
					this.STX= configAccess.UpdateTriggerStatus(this.dt_SOH);
				}
				while (false);
			}
		}

		private sealed class csSO
		{
			public List<SyncTriggerStatusInfo> lst_SOH;

			public ConfigBusiness STX;

			public void SOH()
			{
				ConfigAccess configAccess = new ConfigAccess(this.STX.Transaction);
                this.lst_SOH = configAccess.GetAllSyncTriggerTables();
			}
		}

        private sealed class csSI
		{
			public int int_SOH;

			public ConfigBusiness STX;

			public int ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.int_SOH = configAccess.GetSubstoreLocationWise(this.ETX);
				}
				while (false);
			}
		}
        private sealed class csDLE
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public string ETX;

			public string EOT;

			public string ENQ;

			public string ACK;

			public string BEL;

			public void SOH()
			{
				ConfigAccess configAccess = new ConfigAccess(this.STX.Transaction);
                this.Is_SOH = configAccess.SaveEmailDetails(this.ETX, this.EOT, this.ENQ, this.ACK, this.BEL);
			}
		}
        private sealed class csDC1
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public string ETX;

			public string EOT;

			public string ENQ;

			public string ACK;

			public string BEL;

			public int BS;

			public void SOH()
			{
				ConfigAccess configAccess;
				do
				{
					configAccess = new ConfigAccess(this.STX.Transaction);
				}
				while (false);
				this.Is_SOH = configAccess.SaveEmailDetails(this.ETX, this.EOT, this.ENQ, this.ACK, this.BEL , this.BS);
			}
		}
        private sealed class csDC2
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public AudioTemplateInfo ETX;

			public void SOH()
			{
				do
				{
                    ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Is_SOH = configAccess.SaveUpdateAudioTemplate(this.ETX);
				}
				while (false);
			}
		}

        	private sealed class csDC3
		{
			public List<AudioTemplateInfo> list_SOH;

			public ConfigBusiness STX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.list_SOH = configAccess.GetAudioTemplateList(0L);
				}
				while (false);
			}
		}

		private sealed class csDC4
		{
			public AudioTemplateInfo AudioTemplateInfo_SOH;

			public ConfigBusiness STX;

			public long ETX;

			public void SOH()
			{
				ConfigAccess expr_2E = new ConfigAccess(this.STX.Transaction);
				ConfigAccess configAccess;
				if (!false)
				{
					configAccess = expr_2E;
				}
				this.AudioTemplateInfo_SOH= configAccess.GetAudioTemplateList(this.ETX).FirstOrDefault<AudioTemplateInfo>();
			}
		}
        private sealed class csNAK
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public long ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Is_SOH= configAccess.DeleteAudio(this.ETX);
				}
				while (false);
			}
		}		
        private sealed class csSYN
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public VideoTemplateInfo ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Is_SOH= configAccess.SaveVideoTemplate(this.ETX);
				}
				while (false);
			}
		}
        private sealed class csETB
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public VideoTemplateInfo EXT;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Is_SOH = configAccess.SaveVideoSlot(this.EXT);
				}
				while (false);
			}
		}
		private sealed class csCAN
		{
			public List<VideoTemplateInfo> lst_SOH;

			public ConfigBusiness STX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.lst_SOH = configAccess.GetVideoTemplate(0L);
				}
				while (false);
			}
		}

        private sealed class csEM
		{
			public VideoTemplateInfo VideoTemplateInfo_SOH;

			public ConfigBusiness STX;

			public long ETX;

			public void SOH()
			{
				ConfigAccess configAccess = new ConfigAccess(this.STX.Transaction);
				this.VideoTemplateInfo_SOH= configAccess.GetVideoTemplate(this.ETX).FirstOrDefault<VideoTemplateInfo>();
				this.VideoTemplateInfo_SOH.videoSlots = new ConfigAccess().GetVideoSlots(this.ETX);
			}
		}

		
		private sealed class csSUB
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public long ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Is_SOH= configAccess.DeleteVideoTemplate(this.ETX);
				}
				while (false);
			}
		}
       private sealed class csESC
		{
			public int Int_SOH;

			public ConfigBusiness STX;

			public VideoBackgroundInfo ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Int_SOH = configAccess.SaveUpdateVideoBackground(this.ETX);
				}
				while (false);
			}
		}

	
		private sealed class csFS
		{
			public List<VideoBackgroundInfo> lst_SOH;

			public ConfigBusiness STX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
                    this.lst_SOH = configAccess.GetVideoBackgrounds(0L);
				}
				while (false);
			}
		}
        private sealed class csGS
		{
			public VideoBackgroundInfo VideoBackgroundInfo_SOH;

			public ConfigBusiness STX;

			public long ETX;

			public void SOH()
			{
				ConfigAccess expr_2E = new ConfigAccess(this.STX.Transaction);
				ConfigAccess configAccess;
				if (!false)
				{
					configAccess = expr_2E;
				}
				this.VideoBackgroundInfo_SOH = configAccess.GetVideoBackgrounds(this.ETX).FirstOrDefault<VideoBackgroundInfo>();
			}
		}
        private sealed class csRS
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

            public long ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Is_SOH= configAccess.DeleteVideoBackground(this.ETX);
				}
				while (false);
			}
		}
        	private sealed class csUS
		{
			public List<VideoSceneViewModel> lst_SOH;

			public ConfigBusiness STX;

			public int ETX;

			public int EOT;

			public void SOH()
			{
				ConfigAccess configAccess = new ConfigAccess(this.STX.Transaction);
				this.lst_SOH= configAccess.GetVideoConfigProfileList((long)this.ETX, this.EOT);
			}
		}

		private sealed class csDEL
		{
			public VideoSceneViewModel VideoSceneViewModel_SOH;

			public ConfigBusiness STX;

			public long EXT;

			public int EOT;

			public void SOH()
			{
				ConfigAccess configAccess = new ConfigAccess(this.STX.Transaction);
                this.VideoSceneViewModel_SOH = configAccess.GetVideoConfigProfileList(this.EXT, this.EOT).FirstOrDefault<VideoSceneViewModel>();
			}
		}
        private sealed class csPAD
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public long ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Is_SOH = configAccess.DeleteVideoConfigProfile(this.ETX);
				}
				while (false);
			}
		}

        private sealed class HOP
		{
			public List<StockShot> lst_SOH;

			public ConfigBusiness STX;

			public long ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.lst_SOH = configAccess.GetStockShotImagesList(this.ETX);
				}
				while (false);
			}
		}

		private sealed class csBPH
		{
			public long long_SOH;

			public ConfigBusiness STX;

			public StockShot ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.long_SOH = configAccess.SaveUpdateStockShotImage(this.ETX);
				}
				while (false);
			}
		}
        private sealed class csNBH
		{
			public ConfigBusiness ConfigBusiness_SOH;

			public long STX;
		}

	
		private sealed class csIND
		{
            public ConfigBusiness.csNBH ConfigBusiness_SOH;

			public bool STX;

			public void SOH()
			{
				ConfigAccess configAccess = new ConfigAccess(this.ConfigBusiness_SOH.ConfigBusiness_SOH.Transaction);
					this.STX= configAccess.DeleteStockShotImg(this.ConfigBusiness_SOH.STX);
					
			}
		}
        
		private sealed class csSSA
		{
			public List<ConfigurationInfo> ConfigurationInfo_SOH;

			public ConfigBusiness STX;

			public void SOH()
			{
				ConfigAccess configAccess = new ConfigAccess(this.STX.Transaction);
				this.ConfigurationInfo_SOH= configAccess.GetAllSubstoreConfigdata();
			}
		}

		private sealed class csESA
		{
			public VideoSceneViewModel VideoSceneViewModel_SOH;

			public ConfigBusiness STX;

			public int ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.VideoSceneViewModel_SOH= configAccess.GetVideoSceneBasedOnPhotoId(this.ETX);
				}
				while (false);
			}
		}
        private sealed class csHTS
		{
			public int Int_SOH;

			public ConfigBusiness STX;

			public CGConfigSettings ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Int_SOH= configAccess.SaveCGConfigSetting(this.ETX);
				}
				while (false);
			}
		}


        private sealed class csHTJ
        {
            public List<CGConfigSettings> lst_SOH;

            public ConfigBusiness STX;

            public int ETX;

            public void SOH()
            {
                do
                {
                    ConfigAccess configAccess;
                    if (!false)
                    {
                        configAccess = new ConfigAccess(this.STX.Transaction);
                    }
                    this.lst_SOH = configAccess.GetCGConfigSettngs(this.ETX);
                }
                while (false);
            }
        }
        private sealed class csVTS
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public int ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Is_SOH = configAccess.DeleteCGConfigSettngs(this.ETX);
				}
				while (false);
			}
		}

        	private sealed class csPLD
		{
			public int Int_SOH;

			public ConfigBusiness STX;

			public VideoOverlay ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Int_SOH = configAccess.SaveUpdateVideoOverlay(this.ETX);
				}
				while (false);
			}
		}

        private sealed class csPLU
		{
            public bool Is_SOH;

			public ConfigBusiness STX;

			public long  ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Is_SOH = configAccess.DeleteVideoOverlay(this.ETX);
				}
				while (false);
			}
		}
        private sealed class csRI
		{
			public List<VideoOverlay> lst_SOH;

			public ConfigBusiness STX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.lst_SOH= configAccess.GetVideoOverlays(0L);
				}
				while (false);
			}
		}
       private sealed class csSS2
		{
			public VideoOverlay VideoOverlay_SOH;

			public ConfigBusiness STX;

			public long ETX;

			public void SOH()
			{
				ConfigAccess expr_2E = new ConfigAccess(this.STX.Transaction);
				ConfigAccess configAccess;
				if (!false)
				{
					configAccess = expr_2E;
				}
				this.VideoOverlay_SOH= configAccess.GetVideoOverlays(this.ETX).FirstOrDefault<VideoOverlay>();
			}
		}

		
		private sealed class csSS3
		{
			public List<iMIXStoreConfigurationInfo> lst_SOH;

			public ConfigBusiness STX;

			public void SOH()
			{
				ConfigAccess configAccess = new ConfigAccess(this.STX.Transaction);
				this.lst_SOH= configAccess.GetStoreConfigData();
			}
		}

        private sealed class csDCS
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public long ETX;

			public void SOH()
			{
				do
				{
					ConfigurationDao configurationDao;
					if (!false)
					{
						configurationDao = new ConfigurationDao(this.STX.Transaction);
					}
					this.Is_SOH= configurationDao.CheckDummyScan(this.ETX);
				}
				while (false);
			}
		}


        private sealed class csPU1
		{
			public List<ConfigurationInfo> list_SOH;

			public ConfigBusiness STX;

			public void SOH()
			{
				ConfigurationDao configurationDao = new ConfigurationDao(this.STX.Transaction);
				this.list_SOH= configurationDao.GetDeafultPathlist();
			}
		}
       private sealed class csPU2
		{
			public int int_SOH;

			public bool Is_SOH(ConfigInfo STX)
			{
				return  STX.SubStoreID == this.int_SOH;
			}
		}
private sealed class csSTS
		{
			public int int_SOH;

			public int int_STX;

			public bool SOH(ConfigInfo STX)
			{
				int arg_1E_0;
				int arg_1E_1;
				while (true)
				{
					int arg_0E_0;
					arg_1E_0 = (arg_0E_0 = STX.SubStoreID);
					int arg_0E_1;
					arg_1E_1 = (arg_0E_1 = this.int_STX);
					while (true)
					{
						if (!false)
						{
							if (arg_0E_0 != arg_0E_1)
							{
								if (false)
								{
									break;
								}
								if (2 != 0)
								{
									return false;
								}
							}
							arg_1E_0 = (arg_0E_0 =STX.ConfigID);
							arg_1E_1 = (arg_0E_1 = this.int_SOH);
						}
						if (-1 != 0)
						{
							goto Block_1;
						}
					}
				}
				Block_1:
				return arg_1E_0 == arg_1E_1;
			}
		}
        	private sealed class csCCH
		{
			public int int_SOH;

			public bool SOH(iMIXConfigurationInfo STX)
			{
               return STX.SubstoreId== this.int_SOH;

				
			}
		}

	
		private sealed class csMW
		{
			public int Int_SOH;

			public bool SOH(ConfigurationInfo STX)
			{
				int? dG_Substore_Id = STX.DG_Substore_Id;
				if (8 != 0)
				{
					int arg_27_0;
					int arg_3A_0 = arg_27_0 = this.Int_SOH;
					goto IL_10;
				}
				IL_15:
				int num;
				while (dG_Substore_Id.GetValueOrDefault() == num)
				{
					if (7 != 0)
					{
						int arg_27_0;
						int arg_3A_0 = arg_27_0 = (dG_Substore_Id.HasValue ? 1 : 0);
						goto IL_24;
					}
				}
				return false;
				IL_10:
				if (!false)
				{
					int arg_3A_0=0;
					num = arg_3A_0;
					goto IL_15;
				}
				IL_24:
				if (!false)
				{
					int arg_27_0=0;
					return arg_27_0 != 0;
				}
				goto IL_10;
			}
		}

		
		private sealed class csSPA
		{
			public long long_SOH;

            public bool SOH(iMIXConfigurationInfo STX)
            {
                return STX.IMIXConfigurationMasterId == this.long_SOH;
            }
		}

        
		private sealed class csEPA
		{
			public ConfigParams ConfigParams_SOH;

			public bool SOH(iMIXConfigurationInfo STX)
			{
				return STX.IMIXConfigurationMasterId == Convert.ToInt64(this.ConfigParams_SOH);
			}
		}

	
		private sealed class csSOS
		{
			public ConfigurationInfo ConfigurationInfo_SOH;

			public ConfigBusiness STX;

			public void SOH()
			{
				ConfigurationDao configurationDao = new ConfigurationDao(this.STX.Transaction);
				this.ConfigurationInfo_SOH= configurationDao.GetDeafultPath();
			}
		}
        private sealed class csSGCI
		{
			public ConfigBusiness ConfigBusiness_SOH;

			public string STX;

			public string ETX;

			public string EOT;

			public string ENQ;

			public string ACK;

			public string BEL;

			public int BS;

			public bool? SO;

			public bool? SI;

			public bool? DLE;

			public bool? DC1;
			public bool? DC2;

			public bool? DC3;

			public bool? DC4;

			public int NAK;

			public bool? SYN;

			public int ETB;

			public bool? CAN;

			public bool? EM;

			public int SUB;

			public string ESC;

			public decimal FS;

			public int GS;

			public int RS;

			public int US;

			public bool? DEL; 

			public void SOH()
			{
				ConfigurationDao configurationDao = new ConfigurationDao(this.ConfigBusiness_SOH.Transaction);
					
		configurationDao.UPDANDINS_ConfigurationData(
                    this.BS, this.NAK,
                this.ETB, this.SUB, this.GS, this.RS, 
                this.US, this.SO, 
                this.SI, this.DLE,
                this.DC1, this.DC2,
                this.DC3, this.DC4,
                this.SYN, this.CAN, 
                this.EM, this.FS, 
                this.STX, this.ETX, 
                this.EOT, this.ENQ, 
                this.BEL, this.ESC, 
                this.ACK, this.DEL);
			}
		}
        	private sealed class csSCI
		{
			public bool IS_SOH;

			public ConfigBusiness STX;

			public SemiOrderSettings ETX;

			public void SOH()
			{
				do
				{
					ConfigurationDao configurationDao;
					if (!false)
					{
						configurationDao = new ConfigurationDao(this.STX.Transaction);
					}
					this.IS_SOH= configurationDao.UPDANDINS_SemiOrderConfigurationData(this.ETX);
				}
				while (false);
			}
		}

	
		private sealed class csCSI
		{
			public List<iMixConfigurationLocationInfo> lst_SOH;

			public ConfigBusiness STX;

			public int ETX;

			public void SOH()
			{
				do
				{
					ConfigurationDao configurationDao;
					if (!false)
					{
						configurationDao = new ConfigurationDao(this.STX.Transaction);
					}
					this.lst_SOH = configurationDao.GetLocationWiseConfigParams(this.ETX);
				}
				while (false);
			}
		}
        private sealed class csST
		{
			public ConfigBusiness ConfigBusiness_SOH;

			public int STX;

			public void SOH()
			{
				ConfigurationDao configurationDao = new ConfigurationDao(this.ConfigBusiness_SOH.Transaction);
				configurationDao.DeleteLocationWiseConfigParams(this.STX);
			}
		}
        private sealed class csOSC
		{
			public DataTable dt_SOH;

			public bool STX;

			public ConfigBusiness ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.ETX.Transaction);
					}
                    this.STX = configAccess.SaveUpdateNewStoreConfig(this.dt_SOH);
                }
				while (false);
			}
		}

        private sealed class csPM
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public iMIXStoreConfigurationInfo ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
                    this.Is_SOH = configAccess.SaveUpdatePreviewDummyTag(this.ETX);
				}
				while (false);
			}
		}

        	private sealed class csAPC
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

            public long ETX;

			public void SOH()
			{
				do
				{
					ConfigAccess configAccess;
					if (!false)
					{
						configAccess = new ConfigAccess(this.STX.Transaction);
					}
					this.Is_SOH= configAccess.DeletePreviewDummyTag(this.ETX);
				}
				while (false);
			}
		}

        private sealed class csSOH_STX
		{
			public List<ReportTypeDetails> lst_SOH;

			public ConfigBusiness STX;

			public void SOH()
			{
				ConfigurationDao configurationDao = new ConfigurationDao(this.STX.Transaction);
				this.lst_SOH= configurationDao.GetReportTypes();
			}
		}
        private sealed class csSTX_STX
		{
			public bool Is_SOH;

			public DataTable STX;

			public ConfigBusiness ETX;

			public void SOH()
			{
				do
				{
					ConfigurationDao configurationDao;
					if (!false)
					{
						configurationDao = new ConfigurationDao(this.ETX.Transaction);
					}
					this.Is_SOH= configurationDao.InsertReportConfig(this.STX);
				}
				while (false);
			}
		}

        	private sealed class csETX_ETX
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public ExportServiceLog ETX;

			public void SOH()
			{
				do
				{
					ConfigurationDao configurationDao;
					if (!false)
					{
						configurationDao = new ConfigurationDao(this.STX.Transaction);
					}
					this.Is_SOH= configurationDao.SaveExportReportLogDetails(this.ETX);
				}
				while (false);
			}
		}

		private sealed class csEOT_STX
		{
			public List<ExportServiceLog> list_SOH;

			public ConfigBusiness STX;

			public void SOH()
			{
				ConfigurationDao configurationDao = new ConfigurationDao(this.STX.Transaction);
				this.list_SOH = configurationDao.GetExportServiceLogs();
			}
		}
      private sealed class csENQ_STX
		{
			public string str_SOH;

			public bool IsSOH(PaymentSummaryInfo STX)
			{
				return STX.StoreName == this.str_SOH;
			}

			public bool IsSTX(PaymentSummaryInfo STX)
			{
				return STX.StoreName == this.str_SOH;
			}

			public bool ISETX (PaymentSummaryInfo STX)
			{
				return STX.StoreName == this.str_SOH;
			}
		}

		private sealed class csACK_STK
		{
			public ConfigBusiness.csENQ_STX ConfigBusiness_SOH;

			public string STX;

		
			public bool SOH(PaymentSummaryInfo STX)
			{
                return STX.StoreName == this.ConfigBusiness_SOH.str_SOH && STX.SubStoreName == this.STX;
			}
		}

        private sealed class csBEL_STX
		{
            public ConfigBusiness ConfigBusiness_SOH;

            public List<ReportTypeDetails> STX;

			public void SOH()
			{
				while (true)
				{
					ConfigurationDao configurationDao;
					if (!false)
					{
                        configurationDao = new ConfigurationDao(this.ConfigBusiness_SOH.Transaction);
					}
					if (!false)
					{
						if (5 != 0)
						{
							configurationDao.UpdateReportTypes(this.STX);
						}
						if (!false)
						{
							break;
						}
					}
				}
			}
		}
     private sealed class csBS_STX
		{
			public string[] arr_SOH;

            public bool SOH(ReportTypeDetails STX)
            {
                return this.arr_SOH.Contains(STX.ReportTypeName);
            }

		}

		private sealed class csSO_STX
		{
			public string str_SOH;

			public ConfigBusiness STX;

			public int ETX;

			public void SOH()
			{
				do
				{
					ConfigurationDao configurationDao;
					if (!false)
					{
						configurationDao = new ConfigurationDao(this.STX.Transaction);
					}
                    this.str_SOH = configurationDao.GetSubStoreNameBySuubStoreId(this.ETX);
				}
				while (false);
			}
		}
        private sealed class csSI_STX 
		{
			public ConfigBusiness  ConfigBusiness_SOH;

			public int STX;

			public void SOH()
			{
				ConfigurationDao configurationDao = new ConfigurationDao(this.ConfigBusiness_SOH.Transaction);
				configurationDao.DeleteLocationWiseConfigParamsGumbleRide(this.STX);
			}
		}

		private sealed class csDLE_STX
		{
			public bool Is_SOH;

			public ConfigBusiness STX;

			public int EXT;

			public void SOH()
			{
				do
				{
					ConfigurationDao configurationDao;
					if (!false)
					{
						configurationDao = new ConfigurationDao(this.STX.Transaction);
					}
					this.Is_SOH = configurationDao.IsLocationRFIDEnabled(this.EXT);
				}
				while (false);
			}
		}
        private sealed class csDC1_STX
		{
			public List<iMixConfigurationLocationInfo>lst_SOH;

            public ConfigBusiness STX;

			public void SOH()
			{
				ConfigurationDao configurationDao = new ConfigurationDao(this.STX.Transaction);
				this.lst_SOH= configurationDao.GetAllLocationWiseConfigParams();
			}
		}
        
		private VideoConfigProfiles propSOH;
		private static Func<iMIXStoreConfigurationInfo, bool> propSTX;
		private static Func<iMIXStoreConfigurationInfo, bool> propETX;
		private static Func<iMIXStoreConfigurationInfo, bool> propEOT;
		private static Func<iMIXStoreConfigurationInfo, bool> propENQ;
		private static Func<ReportTypeDetails, bool> propACK;
		private static Func<PaymentSummaryInfo, string> propBEL;
		private static Func<PaymentSummaryInfo, string> propBS;
		private static Func<PaymentSummaryInfo, string> propSO;
		private static Func<PaymentSummaryInfo, string> propSI;
		private static Func<PaymentSummaryInfo, string> propDLE;
		private static Func<string, string, string> propDC1;
		private static Func<string, string, string> propDC2;
		private static Func<PaymentSummaryInfo, string> propDC3;
		private static Func<PaymentSummaryInfo, string> propDC4;
		private static Func<string, string, string> propNAK;
		private static Func<ReportTypeDetails, ReportTypeDetails> propSYN;
		internal static SmartAssembly.Delegates.GetString getConfigBusiness;
        public VideoConfigProfiles List{get; set;}

        public bool SaveUpdateConfigLocation(List<iMixConfigurationLocationInfo> lstIMixConfigLocInfo)
		{
			ConfigBusiness.csSOH SOH= new ConfigBusiness.csSOH();
			SOH.ETX=this;
          SOH.dtSOH=new DataTable ();
            SOH.dtSOH.Columns.Add(ConfigBusiness.getConfigBusiness(533));
            SOH.dtSOH.Columns.Add(ConfigBusiness.getConfigBusiness(562));
            SOH.dtSOH.Columns.Add(ConfigBusiness.getConfigBusiness(587));
            SOH.dtSOH.Columns.Add(ConfigBusiness.getConfigBusiness(604));
            SOH.dtSOH.Columns.Add(ConfigBusiness.getConfigBusiness(604));
            foreach (iMixConfigurationLocationInfo current in lstIMixConfigLocInfo)
            {
                SOH.dtSOH.Rows.Add(new object[]
                {
                    current.IMIXConfigurationMasterId,
                    current.ConfigurationValue,
                    current.SubstoreId,
                    current.LocationId
                });
            }
            SOH.STX = false;
            this.operation = new BaseBusiness.TransactionMethod( SOH.SOH);
            base.Start(false);
          return SOH.STX;
		}


        public bool SaveUpdateNewConfig(List<iMIXConfigurationInfo> lstConfigValue)
		{
			ConfigBusiness.csSOH STX= new ConfigBusiness.csSOH();
			STX.ETX=this;
         STX.dtSOH=new DataTable ();
            STX.dtSOH.Columns.Add(ConfigBusiness.getConfigBusiness(533));
            STX.dtSOH.Columns.Add(ConfigBusiness.getConfigBusiness(562));
            STX.dtSOH.Columns.Add(ConfigBusiness.getConfigBusiness(587));
           
			foreach (iMIXConfigurationInfo current in lstConfigValue)
			{
				STX.dtSOH.Rows.Add(new object[]
				{
					current.IMIXConfigurationMasterId,
					current.ConfigurationValue,
					current.SubstoreId
				});
			}
			STX.STX=false;
			this.operation = new BaseBusiness.TransactionMethod(STX.SOH);
			base.Start(false);
			//SqlDepandencyCache.ClearCacheNewConfigValues();
			ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(ImixConfigurationCache).FullName);
			factory.RemoveFromCache();
			ConfigManager.IMIXConfigurations.Clear();
            return STX.STX;
		}
        public Dictionary<long, string> GetConfigurations(Dictionary<long, string> iMIXConfigurations, int subStoreId)
		{
			BaseBusiness.TransactionMethod transactionMethod;
			if (!false)
			{
				if (-1 == 0)
				{
					goto IL_15;
				}
				transactionMethod = null;
			}
			IL_09:
            ConfigBusiness.csETX expr_8A=new ConfigBusiness.csETX();
            ConfigBusiness.csETX ETX;
			if (3 != 0)
			{
                ETX= expr_8A;
			}
			IL_15:
			ETX.STX= iMIXConfigurations;
			ETX.ETX= subStoreId;
			if (!false)
			{

			  ETX.ConfigBusiness_SOH=this;
				bool arg_56_0 =ETX.STX. Count != 0;
				if (6 != 0 && 2 != 0)
				{
					if (!arg_56_0)
					{
						new ConfigBusiness();
						if (transactionMethod == null)
						{
                            transactionMethod = new BaseBusiness.TransactionMethod(ETX.SOH);
						}
						this.operation = transactionMethod;
						base.Start(false);
					}
				}
				return ETX.STX;
			}
			goto IL_09;
		}
        public List<iMixConfigurationLocationInfo> GetConfigLocation(int LocationId, int SubstoreId)
		{
            csEOT EOT=new csEOT ();
           
			do
			{
			
			    EOT.lst_SOH= new List<iMixConfigurationLocationInfo>();
				new ConfigBusiness();
				
			}
			while (3 == 0);
			this.operation = new BaseBusiness.TransactionMethod(EOT.SOH);
			base.Start(false);
            EOT.STX = this;
			return EOT.lst_SOH;
            
		}
        public List<iMixConfigurationLocationInfo> GetConfigBasedOnLocation(int LocationId)
		{
			ConfigBusiness.csENQ ENQ = new ConfigBusiness.csENQ();
			ENQ.ETX = LocationId;
			ENQ.STX = this;
			do
			{
			ENQ.lst_SOH	 = new List<iMixConfigurationLocationInfo>();
				new ConfigBusiness();
				this.operation = new BaseBusiness.TransactionMethod(ENQ.SOH);
				base.Start(false);
			}
			while (false);
            return ENQ.lst_SOH;
		}

        public string GetHotFolderPath(int SubStoreId)
		{
			ConfigBusiness.ACK ACK = new ConfigBusiness.ACK();
			ACK.ETX = SubStoreId;
			ACK.STX = this;
			do
			{
				ACK.str_SOH= string.Empty;
				new ConfigBusiness();
				this.operation = new BaseBusiness.TransactionMethod(ACK.SOH);
				base.Start(false);
			}
			while (false);
            return ACK.str_SOH;
		}


        public FolderStructureInfo GetFolderStructureInfo(int subStoreId)
		{
			ConfigBusiness.csBEL BEL= new ConfigBusiness.csBEL();
		     BEL.ETX= subStoreId;
		     BEL.STX= this;
		     BEL.FolderStructureInfo_SOH= new FolderStructureInfo();
			this.operation = new BaseBusiness.TransactionMethod(BEL.SOH);
			base.Start(false);
			return  BEL.FolderStructureInfo_SOH;
		}

		public bool UpdateTriggerStatus(List<SyncTriggerStatusInfo> lstTriggerStatus)
		{
			ConfigBusiness.csBS BS= new ConfigBusiness.csBS();
		    BS.ETX=this;
		    BS.dt_SOH= new DataTable();
			do
			{
		     BS.dt_SOH.Columns.Add(ConfigBusiness.getConfigBusiness(621));
			BS.dt_SOH.Columns.Add(ConfigBusiness.getConfigBusiness(634));
			}
			while (4 == 0);
		     BS.dt_SOH.Columns.Add(ConfigBusiness.getConfigBusiness(647));
			foreach (SyncTriggerStatusInfo current in lstTriggerStatus)
			{
			BS.dt_SOH.Rows.Add(new object[]
				{
					current.TableId,
					current.TableName,
					current.IsSyncTriggerEnable
				});
			}
			do
			{
			BS.STX = false;
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(BS.SOH);
			base.Start(false);
			return BS.STX;
		}

        public List<SyncTriggerStatusInfo> GetAllSyncTriggerTables()
		{
            csSO SO=new csSO ();
			if (!false)
			{
				
				do
				{
			      SO.STX= this;
				}
				while (false);
			       SO.lst_SOH= new List<SyncTriggerStatusInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(SO.SOH);
				}
				while (2 == 0);
				base.Start(false);
			}
			return SO.lst_SOH;
		}

        public int GetSubstoreLocationWise(int locationid)
        {
            ConfigBusiness.csSI SI=new ConfigBusiness.csSI ();
            SI.ETX= locationid;
			
            SI.STX= this;
			
            SI.int_SOH= 0;
            new ConfigBusiness();
                this.operation = new BaseBusiness.TransactionMethod(SI.SOH);
			
            base.Start(false);
			
            int expr_46 =SI.int_SOH;
			
                return expr_46;
			
			
        }
        public bool SaveEmailDetails(string toAddress, string toBCC, string sender, string msgBody, string msgType)
		{
			ConfigBusiness.csDLE DLE= new ConfigBusiness.csDLE();
			
			DLE.ETX = toAddress;
			DLE.EOT = toBCC;
			DLE.ENQ = sender;
			DLE.ACK = msgBody;
			DLE.BEL = msgType;
			DLE.STX = this;
			
			new ConfigBusiness();
			DLE.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(DLE.SOH);
			bool arg_8E_0 = base.Start(false);
			
			
			arg_8E_0 =DLE.Is_SOH;
			return arg_8E_0;
		}
        public bool SaveEmailDetails(string toAddress, string toBCC, string sender, string msgBody, string msgType, int subStoreId)
		{
			ConfigBusiness.csDC1 DC1= new ConfigBusiness.csDC1();
		      DC1.ETX= toAddress;
		      DC1.EOT= toBCC;
		      DC1.ENQ= sender;
		      DC1.ACK= msgBody;
		      DC1.BEL= msgType;
		      DC1.BS= subStoreId;
		      DC1.STX= this;
			new ConfigBusiness();
		      DC1.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(DC1.SOH);
			base.Start(false);
			return DC1.Is_SOH;
		}

		public bool SaveUpdateAudioTemplate(AudioTemplateInfo lstAudioValue)
		{
			ConfigBusiness.csDC2 DC2= new ConfigBusiness.csDC2();
		    DC2.ETX= lstAudioValue;
		    DC2.STX= this;
		    DC2.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(DC2.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 =DC2.Is_SOH;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public List<AudioTemplateInfo> GetAudioTemplateList()
		{csDC3 DC3=new csDC3 ();
			if (!false)
			{
				
				do
				{
			      DC3.STX= this;
				}
				while (false);
			    DC3.list_SOH= new List<AudioTemplateInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(DC3.SOH);
				}
				while (2 == 0);
				base.Start(false);
			}
			return DC3.list_SOH;
		}
        public AudioTemplateInfo GetAudioTemplateList(long audioID)
		{
			ConfigBusiness.csDC4 DC4= new ConfigBusiness.csDC4();
		    DC4.ETX= audioID;
		    DC4.STX= this;
		    DC4.AudioTemplateInfo_SOH= new AudioTemplateInfo();
			this.operation = new BaseBusiness.TransactionMethod(DC4.SOH);
			base.Start(false);
			return DC4.AudioTemplateInfo_SOH;
		}

		public bool DeleteAudio(long audioId)
		{
			ConfigBusiness.csNAK NAK=new ConfigBusiness.csNAK();
		    NAK.ETX= audioId;
		    NAK.STX= this;
		    NAK.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(NAK.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
				
					arg_46_0 = NAK.Is_SOH;
				
			}
			while (2 == 0);
			return arg_46_0;
		}

		public bool SaveVideoTemplate(VideoTemplateInfo videoTemplate)
		{
			ConfigBusiness.csSYN SYN = new ConfigBusiness.csSYN();
		    SYN.ETX= videoTemplate;
		    SYN.STX= this;
		    SYN.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(SYN.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
				
					arg_46_0 = SYN.Is_SOH;
				
			}
			while (2 == 0);
			return arg_46_0;
		}
        public bool SaveVideoSlot(VideoTemplateInfo videoTemplate)
		{
			ConfigBusiness.csETB ETB= new ConfigBusiness.csETB();
		    ETB.EXT= videoTemplate;
		    ETB.STX= this;
		    ETB.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(ETB.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
			
					arg_46_0 =ETB.Is_SOH;
			
			}
			while (2 == 0);
			return arg_46_0;
		}

		public List<VideoTemplateInfo> GetVideoTemplate()
		{
            csCAN CAN=new csCAN ();
			if (!false)
			{
				do
				{
				  CAN.STX = this;
				}
				while (false);
			    CAN.lst_SOH= new List<VideoTemplateInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(CAN.SOH);
				}
				while (2 == 0);
				base.Start(false);
			}
			return CAN.lst_SOH;
		}

		public VideoTemplateInfo GetVideoTemplate(long videoTemplateId)
		{
			ConfigBusiness.csEM EM= new ConfigBusiness.csEM();
		    EM.ETX= videoTemplateId;
		    EM.STX= this;
		    EM.VideoTemplateInfo_SOH= new VideoTemplateInfo();
			this.operation = new BaseBusiness.TransactionMethod(EM.SOH);
			base.Start(false);
			return EM.VideoTemplateInfo_SOH;
		}

		public bool DeleteVideoTemplate(long videoId)
		{
			ConfigBusiness.csSUB SUB= new ConfigBusiness.csSUB();
		    SUB.ETX= videoId;
		    SUB.STX= this;
		    SUB.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(SUB.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
					arg_46_0 =SUB.Is_SOH;
				
			}
			while (2 == 0);
			return arg_46_0;
		}
        public int SaveUpdateVideoBackground(VideoBackgroundInfo lstVideoBGValue)
		{
			ConfigBusiness.csESC ESC= new ConfigBusiness.csESC();
		    ESC.ETX= lstVideoBGValue;
		    ESC.STX= this;
		    ESC.Int_SOH= 0;
			this.operation = new BaseBusiness.TransactionMethod(ESC.SOH);
			int arg_46_0 = base.Start(false) ? 1 : 0;
			do
			{
                arg_46_0 =ESC.Int_SOH;
			}
			while (2 == 0);
			return arg_46_0;
		}

		public List<VideoBackgroundInfo> GetVideoBackgrounds()
		{
            csFS FS=new csFS ();
			if (!false)
			{
				do
				{
                    FS.STX=this;
				}
				while (false);
			      FS.lst_SOH= new List<VideoBackgroundInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(FS.SOH);
				}
				while (2 == 0);
				base.Start(false);
			}
			return FS.lst_SOH;
		}

		public VideoBackgroundInfo GetVideoBackgrounds(long vidBgID)
		{
			ConfigBusiness.csGS GS= new ConfigBusiness.csGS();
		    GS.ETX= vidBgID;
		    GS.STX= this;
		    GS.VideoBackgroundInfo_SOH= new VideoBackgroundInfo();
			this.operation = new BaseBusiness.TransactionMethod(GS.SOH);
			base.Start(false);
			return GS.VideoBackgroundInfo_SOH;
		}

		public bool DeleteVideoBackground(long vidBgID)
		{
			ConfigBusiness.csRS RS= new ConfigBusiness.csRS();
		    RS.ETX= vidBgID;
		    RS.STX= this;
		    RS.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(RS.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
					arg_46_0 =RS.Is_SOH;
				
			}
			while (2 == 0);
			return arg_46_0;
		}
        public List<VideoSceneViewModel> GetVideoConfigProfileList(int profileId, int substoreid)
		{
            ConfigBusiness.csUS US = new ConfigBusiness.csUS();
			if (!false)
			{
				US.ETX = profileId;
				
				 US.EOT= substoreid;
				
			}
			do
			{
				
			    US.STX = this;
				US.lst_SOH= new List<VideoSceneViewModel>();
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(US.SOH);
			IL_55:
			base.Start(false);
			return US.lst_SOH;
		}

		public VideoSceneViewModel GetVideoConfigProfileList(long profileId, int substoreid)
		{
			ConfigBusiness.csDEL DEL = new ConfigBusiness.csDEL();
			if (!false)
			{
			    DEL.EXT= profileId;
				
			    DEL.EOT= substoreid;
				
			}
			do
			{
				DEL.STX= this;
			    DEL.VideoSceneViewModel_SOH= new VideoSceneViewModel();
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(DEL.SOH);
			IL_55:
			base.Start(false);
			return DEL.VideoSceneViewModel_SOH;
		}

		public bool DeleteProfile(long profileId)
		{
			ConfigBusiness.csPAD PAD= new ConfigBusiness.csPAD();
		    PAD.ETX= profileId;
		    PAD.STX= this;
		    PAD.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(PAD.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 =PAD.Is_SOH;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}
        public List<StockShot> GetStockShotImagesList(long ImageId)
		{
			ConfigBusiness.HOP HOP= new ConfigBusiness.HOP();
		    HOP.ETX= ImageId;
		    HOP.STX= this;
		    HOP.lst_SOH= new List<StockShot>();
            this.operation = new BaseBusiness.TransactionMethod(HOP.SOH);
			base.Start(false);
			return HOP.lst_SOH;
		}

		public long SaveUpdateStockShotImage(StockShot image)
		{
			ConfigBusiness.csBPH expr_44 = new ConfigBusiness.csBPH();
			ConfigBusiness.csBPH BPH;
			if (!false)
			{
		      BPH= expr_44;
			}
		     BPH.ETX= image;
		     BPH.STX= this;
		     BPH.long_SOH= 0L;
			this.operation = new BaseBusiness.TransactionMethod(BPH.SOH);
			base.Start(false);
			return BPH.long_SOH;
		}

		public bool DeleteStockShotImg(long ImgId)
		{
			csNBH NBH=new csNBH ();
		    NBH.STX = ImgId;
		    NBH.ConfigBusiness_SOH= this;
			bool result;
			try
			{
				ConfigBusiness.csIND  IND= new ConfigBusiness.csIND();
				if (!false)
				{
                    IND.ConfigBusiness_SOH=NBH;
				}
			    IND.STX= false;
				this.operation = new BaseBusiness.TransactionMethod(IND.SOH);
				bool arg_67_0 = base.Start(false);
				
					arg_67_0 =IND.STX;
				
				result = arg_67_0;
			}
			catch (Exception)
			{
				result = false;
			}
			return result;
		}
        public List<ConfigurationInfo> GetAllSubstoreConfigdata()
		{
            csSSA SSA=new csSSA ();
			if (!false)
			{
				do
				{
		           SSA.STX=this;
				}
				while (false);
		          SSA.ConfigurationInfo_SOH= new List<ConfigurationInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(SSA.SOH);
				}
				while (2 == 0);
				base.Start(false);
			}
			return SSA.ConfigurationInfo_SOH;
		}

		public VideoSceneViewModel GetVideoSceneBasedOnPhotoId(int photoId)
		{
            ConfigBusiness.csESA ESA = new ConfigBusiness.csESA();
		    ESA.ETX= photoId;
		    ESA.STX= this;
		    ESA.VideoSceneViewModel_SOH= new VideoSceneViewModel();
			this.operation = new BaseBusiness.TransactionMethod(ESA.SOH);
			base.Start(false);
			return ESA.VideoSceneViewModel_SOH;
		}

		public int SaveCGConfigSetting(CGConfigSettings CGConfigSettings)
		{
			ConfigBusiness.csHTS HTS= new ConfigBusiness.csHTS();
		    HTS.ETX= CGConfigSettings;
		    HTS.STX= this;
		    HTS.Int_SOH= 0;
			this.operation = new BaseBusiness.TransactionMethod(HTS.SOH);
			int arg_46_0 = base.Start(false) ? 1 : 0;
			do
			{
                arg_46_0 =HTS.Int_SOH;
				
			}
			while (2 == 0);
			return arg_46_0;
		}

        public List<CGConfigSettings> GetCGConfigSettngs(int configId)
		{
			ConfigBusiness.csHTJ HTJ= new ConfigBusiness.csHTJ();
		    HTJ.ETX= configId;
		    HTJ.STX= this;
		    HTJ.lst_SOH= new List<CGConfigSettings>();
			this.operation = new BaseBusiness.TransactionMethod(HTJ.SOH);
			base.Start(false);
			return HTJ.lst_SOH;
		}

		public bool DeleteCGConfigSettngs(int configId)
		{
			ConfigBusiness.csVTS VTS= new ConfigBusiness.csVTS();
		    VTS.ETX= configId;
		    VTS.STX= this;
		    VTS.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(VTS.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
					arg_46_0 =VTS.Is_SOH;
				
			}
			while (2 == 0);
			return arg_46_0;
		}

		public int SaveUpdateVideoOverlay(VideoOverlay lstVideoBGValue)
		{
			ConfigBusiness.csPLD PLD=new ConfigBusiness.csPLD();
		    PLD.ETX= lstVideoBGValue;
		    PLD.STX= this;
		    PLD.Int_SOH= 0;
			this.operation = new BaseBusiness.TransactionMethod(PLD.SOH);
			int arg_46_0 = base.Start(false) ? 1 : 0;
			do
			{
					arg_46_0=PLD.Int_SOH;
			
			}
			while (2 == 0);
			return arg_46_0;
		}
        public bool DeleteVideoOverlay(long videoId)
		{
			ConfigBusiness.csPLU PLU=new ConfigBusiness.csPLU();
		    PLU.ETX= videoId;
		    PLU.STX= this;
		    PLU.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(PLU.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
					arg_46_0 = PLU.Is_SOH;
				
			}
			while (2 == 0);
			return arg_46_0;
		}

		public List<VideoOverlay> GetVideoOverlays()
		{
            ConfigBusiness.csRI RI=new ConfigBusiness.csRI();
			if (!false)
			{
				do
				{
                    RI.STX=this;
				}
				while (false);
		         RI.lst_SOH= new List<VideoOverlay>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(RI.SOH);
				}
				while (2 == 0);
				base.Start(false);
			}
			return RI.lst_SOH;
		}

		public VideoOverlay GetVideoOverlays(long VideoOverlayId)
		{
            ConfigBusiness.csSS2 SS2 = new ConfigBusiness.csSS2();
		    SS2.ETX= VideoOverlayId;
		    SS2.STX= this;
		    SS2.VideoOverlay_SOH= new VideoOverlay();
			this.operation = new BaseBusiness.TransactionMethod(SS2.SOH);
			base.Start(false);
			return SS2.VideoOverlay_SOH;
		}

        public List<iMIXStoreConfigurationInfo> GetStoreConfigData()
		{
             csSS3 SS3=new csSS3 ();
			if (!false)
			{
				do
				{
			      SS3.STX= this;
				}
				while (false);
		          SS3.lst_SOH= new List<iMIXStoreConfigurationInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(SS3.SOH);
				}
				while (2 == 0);
				base.Start(false);
			}
			return SS3.lst_SOH;
		}

		public bool CheckDummyScan(long photographerID)
		{
			ConfigBusiness.csDCS DCS=new csDCS ();
		    DCS.ETX= photographerID;
		    DCS.STX= this;
		    DCS.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(DCS.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
				
					arg_46_0 =DCS.Is_SOH;
				
			}
			while (2 == 0);
			return arg_46_0;
		}

		public List<ConfigurationInfo> GetDeafultPathlist()
		{
            csPU1 PU1=new csPU1 ();
			if (!false)
			{
				do
				{
                    PU1.STX=this;
				}
				while (false);
                PU1.list_SOH= new List<ConfigurationInfo>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(PU1.SOH);
				}
				while (2 == 0);
				base.Start(false);
			}
            return PU1.list_SOH;
		}

		public List<ConfigInfo> GetAllConfigs()
		{
			ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(ConfigCache).FullName);
			return factory.GetData() as List<ConfigInfo>;
		}
        public List<ConfigInfo> GetSubStoreConfigs(int subStoreId)
		{
			ConfigBusiness.csPU2 PU2;
			while (true)
			{
				ConfigBusiness.csPU2 expr_40 = new ConfigBusiness.csPU2();
				PU2=expr_40;
			    PU2.int_SOH= subStoreId;
				
			}
			ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(ConfigCache).FullName);
            return ((List<ConfigInfo>)factory.GetData()).FindAll(new Predicate<ConfigInfo>(PU2.Is_SOH));
			
		}

		public string GetSubStorePasswordPath(int configId, int subStoreId)
		{
            ConfigBusiness.csSTS STS = new ConfigBusiness.csSTS();
		    STS.int_SOH= configId;
		    STS.int_STX= subStoreId;
			ICacheRepository factory;
			do
			{
				factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(ConfigCache).FullName);
			}
			while (false);
            return ((List<ConfigInfo>)factory.GetData ()).FindAll(new Predicate<ConfigInfo>(STS.SOH)).FirstOrDefault<ConfigInfo>().ConfigValue;
			
		}

		public List<iMIXConfigurationInfo> GetNewConfigValues(int subStoreId)
		{
			ConfigBusiness.csCCH expr_25 = new ConfigBusiness.csCCH();
			ConfigBusiness.csCCH CCH;
			if (!false)
			{
		       CCH= expr_25;
			}
	         CCH.int_SOH= subStoreId;
             List<iMIXConfigurationInfo> newConfigValues = null;//SqlDepandencyCache.GetNewConfigValues();
			return newConfigValues.FindAll(new Predicate<iMIXConfigurationInfo>(CCH.SOH));
		}

		public ConfigurationInfo GetConfigurationData(int subStoreId)
		{
            csMW MW=new csMW ();
			List<ConfigurationInfo> allConfigurationSetting=null;
			while (true)
			{
				IL_00:
		        int int_SOH;
				while (!false)
				{
				  int_SOH= subStoreId; 
					while (4 != 0)
					{
						//allConfigurationSetting = SqlDepandencyCache.GetAllConfigurationSetting();
						
						if (allConfigurationSetting != null)
						{
							goto Block_3;
						}
						if (-1 != 0)
						{
							goto Block_4;
                            
						}
					}
				}
			}
			Block_3:
			return allConfigurationSetting.FindAll(new Predicate<ConfigurationInfo>(MW.SOH)).FirstOrDefault<ConfigurationInfo>();
			Block_4:
			return null;
		}

        //public List<ConfigurationInfo> GetConfigurationData()
        //{
        //    return SqlDepandencyCache.GetAllConfigurationSetting();
        //}
        public Dictionary<string, decimal?> GetCromaColor(int SubStoreId)
		{
			Dictionary<string, decimal?> dictionary;
			while (2 != 0)
			{
				dictionary = null;
				while (!false && !false)
				{
					ConfigurationInfo expr_3F = this.GetConfigurationData(SubStoreId);
					ConfigurationInfo configurationInfo;
					if (4 != 0)
					{
						configurationInfo = expr_3F;
					}
					if (configurationInfo == null)
					{
						return dictionary;
					}
					if (4 != 0)
					{
						dictionary = new Dictionary<string, decimal?>();
						dictionary.Add(configurationInfo.DG_ChromaColor, configurationInfo.DG_ChromaTolerance);
						return dictionary;
					}
				}
			}
			return dictionary;
		}

		public bool? GetConfigCompression(int SubstoreId)
		{
			bool? result;
			try
			{
				ConfigurationInfo configurationData;
				do
				{
					configurationData = this.GetConfigurationData(SubstoreId);
				}
				while (2 == 0);
				if (!false)
				{
					while (configurationData.DG_IsCompression.HasValue)
					{
						if (4 != 0)
						{
							result = configurationData.DG_IsCompression;
							goto IL_25;
						}
					}
					result = new bool?(false);
				}
				IL_25:;
			}
			catch (Exception serviceException)
			{
				do
				{
					if (!false)
					{
						//ErrorHandler.LogError(serviceException);
						result = new bool?(false);
					}
				}
				while (3 == 0);
			}
			return result;
		}

		public bool? GetConfigEnableGroup(int SubstoreID)
		{
			bool? result;
			try
			{
				ConfigurationInfo configurationData;
				do
				{
					configurationData = this.GetConfigurationData(SubstoreID);
				}
				while (2 == 0);
				if (!false)
				{
					while (configurationData.DG_IsEnableGroup.HasValue)
					{
						if (4 != 0)
						{
							result = configurationData.DG_IsEnableGroup;
							goto IL_25;
						}
					}
					result = new bool?(false);
				}
				IL_25:;
			}
			catch (Exception serviceException)
			{
				do
				{
					if (!false)
					{
						//ErrorHandler.LogError(serviceException);
						result = new bool?(false);
					}
				}
				while (3 == 0);
			}
			return result;
		}

        public int GetCompressionLevel(int substoreid, long mediaEnum)
		{
			Func<iMIXConfigurationInfo, bool> func = null;
            ConfigBusiness.csSPA  expr_93=new ConfigBusiness.csSPA();
		    ConfigBusiness.csSPA SPA;
			if (!false)
			{
		       SPA= expr_93;
			}
		     SPA.long_SOH= mediaEnum;
			int arg_B1_0 = 0;
			int expr_84;
			do
			{
				int num = arg_B1_0;
				int num2;
				try
				{
					IEnumerable<iMIXConfigurationInfo> arg_3F_0 = this.GetNewConfigValues(substoreid);
					if (func == null)
					{
						func = new Func<iMIXConfigurationInfo, bool>(SPA.SOH);
					}
					iMIXConfigurationInfo iMIXConfigurationInfo = arg_3F_0.Where(func).FirstOrDefault<iMIXConfigurationInfo>();
					if (iMIXConfigurationInfo == null || -1 == 0)
					{
						goto IL_5D;
					}
					int arg_5C_0 =Convert.ToInt32(iMIXConfigurationInfo.ConfigurationValue);
					IL_5C:
					num = arg_5C_0;
					IL_5D:
					int expr_5D = arg_5C_0 = num;
					if (false || false)
					{
						goto IL_5C;
					}
					num2 = expr_5D;
				}
				catch (Exception serviceException)
				{
					if (-1 != 0)
					{
						//ErrorHandler.LogError(serviceException);
						num2 = num;
					}
				}
				expr_84 = (arg_B1_0 = num2);
			}
			while (7 == 0);
			return expr_84;
		}

		public string GetOnlineConfigData(ConfigParams objConfigParams, int SubStoreId)
		{
			Func<iMIXConfigurationInfo, bool> func;
			if (!false && -1 != 0)
			{
				func = null;
			}
			string result;
			if (6 != 0)
			{
                ConfigBusiness.csEPA expr_85 = new ConfigBusiness.csEPA();
				ConfigBusiness.csEPA EPA;
			EPA=expr_85;
		    EPA.ConfigParams_SOH=objConfigParams;
				try
				{
					IEnumerable<iMIXConfigurationInfo> arg_42_0 = this.GetNewConfigValues(SubStoreId);
					if (func == null)
					{
						func = new Func<iMIXConfigurationInfo, bool>(EPA.SOH);
					}
					iMIXConfigurationInfo iMIXConfigurationInfo = arg_42_0.Where(func).FirstOrDefault<iMIXConfigurationInfo>();
					if (7 != 0 && iMIXConfigurationInfo != null)
					{
						result = iMIXConfigurationInfo.ConfigurationValue;
					}
					else
					{
						result = string.Empty;
					}
				}
				catch
				{
					result = string.Empty;
				}
			}
			return result;
		}

		public ConfigurationInfo GetDeafultPathData()
		{
            csSOS SOS=new csSOS();
			if (!false)
			{
				do
				{
			       SOS.STX = this;
				}
				while (false);
			      SOS.ConfigurationInfo_SOH= new ConfigurationInfo();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(SOS.SOH);
				}
				while (2 == 0);
				base.Start(false);
			}
			return SOS.ConfigurationInfo_SOH;
		}
public bool SetConfigurationData(string SyncCode, string hotfolder, string framePath, string bgPath, string ModPassword, string graphics, int NumberofImages, bool? Iswatermark, bool? IsHighResolution, bool? isSemiorder, bool? isAutoRotate, bool? IsLineItemDiscount, bool? IsTotalDiscount, bool? IsPosOnOff, int defaultCurrency, bool? IsSemiOrderMain, int substoreId, bool? IsCompression, bool? IsEnableGroup, int NoOfReceipt, string ChromaColor, decimal ChromaTolerance, int PageSizeGrid, int PageSizePreview, int NoOfPhotoIdSearch, bool? isExportReportToAnyDrive)
		{
           ConfigBusiness.csSGCI SGCI=new csSGCI ();
    
		   SGCI.STX= SyncCode;
		   SGCI.ETX= hotfolder;
		   SGCI.EOT= framePath;
		   SGCI.ENQ= bgPath;
		   SGCI.ACK= ModPassword;
		   SGCI.BEL= graphics;
		   SGCI.BS= NumberofImages;
		   SGCI.SO= Iswatermark;
		   SGCI.SI= IsHighResolution;
		   SGCI.DLE= isSemiorder;
		   SGCI.DC1= isAutoRotate;
		   SGCI.DC2= IsLineItemDiscount;
		   SGCI.DC3= IsTotalDiscount;
		   SGCI.DC4= IsPosOnOff;
		   SGCI.NAK= defaultCurrency;
		   SGCI.SYN= IsSemiOrderMain;
		   SGCI.ETB= substoreId;
		   SGCI.CAN= IsCompression;
		   SGCI.EM= IsEnableGroup;
		   SGCI.SUB= NoOfReceipt;
		   SGCI.ESC= ChromaColor;
		   SGCI.FS= ChromaTolerance;
		   SGCI.GS= PageSizeGrid;
		   SGCI.RS= PageSizePreview;
		   SGCI.US= NoOfPhotoIdSearch;
		   SGCI.DEL= isExportReportToAnyDrive;
		   SGCI.ConfigBusiness_SOH= this;
			this.operation = new BaseBusiness.TransactionMethod(SGCI.SOH);
			base.Start(false);
			//SqlDepandencyCache.ClearCacheAllConfigurationSetting();
			ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(ConfigurationCache).FullName);
			factory.RemoveFromCache();
			return true;
		}

		public bool SetSemiorderConfigurationData(SemiOrderSettings objSemi)
		{
			ConfigBusiness.csSCI SCI=new ConfigBusiness.csSCI();
		    SCI.ETX= objSemi;
		    SCI.STX= this;
		    SCI.IS_SOH= false;
			
				this.operation = new BaseBusiness.TransactionMethod(SCI.SOH);
			
			base.Start(false);
			ICacheRepository factory = DataCacheFactory.GetFactory<ICacheRepository>(typeof(ConfigurationCache).FullName);
			factory.RemoveFromCache();
			return SCI.IS_SOH;
		}

		public List<iMixConfigurationLocationInfo> GetLocationWiseConfigParams(int SubStoreId)
		{
			ConfigBusiness.csCSI CSI= new ConfigBusiness.csCSI();
		     CSI.ETX= SubStoreId;
		     CSI.STX= this;
		     CSI.lst_SOH= new List<iMixConfigurationLocationInfo>();
			this.operation = new BaseBusiness.TransactionMethod(CSI.SOH);
			base.Start(false);
            return CSI.lst_SOH;
		}

        public void DeleteLocationWiseConfigParams(int LocationId)
		{
			ConfigBusiness.csST ST;
			while (true)
			{
				ConfigBusiness.csST expr_3C =new csST ();
				if (!false)
				{
				ST= expr_3C;
				}
				while (!false)
				{
				 ST.STX= LocationId;
					if (4 != 0)
					{
						goto Block_1;
					}
				}
			}
			Block_1:
		     ST.ConfigBusiness_SOH= this;
			this.operation = new BaseBusiness.TransactionMethod(ST.SOH);
			base.Start(false);
		}

		public bool SaveUpdateNewStoreConfig(List<iMIXStoreConfigurationInfo> lstStoreConfigValue)
		{
			ConfigBusiness.csOSC OSC =new csOSC ();
		    OSC.ETX= this;
		    OSC.dt_SOH= new DataTable();
		    OSC.dt_SOH.Columns.Add(ConfigBusiness.getConfigBusiness(533));
		    OSC.dt_SOH.Columns.Add(ConfigBusiness.getConfigBusiness(562));
		    OSC.dt_SOH.Columns.Add(ConfigBusiness.getConfigBusiness(676));
			foreach (iMIXStoreConfigurationInfo current in lstStoreConfigValue)
			{
			 OSC.dt_SOH.Rows.Add(new object[]
				{
					current.IMIXConfigurationMasterId,
					current.ConfigurationValue,
					0
				});
			}
	        OSC.STX= false;
			this.operation = new BaseBusiness.TransactionMethod(OSC.SOH);
			base.Start(false);
			return OSC.STX;
		}

		public bool SaveUpdatePreviewDummyTag(iMIXStoreConfigurationInfo objImixStoreInfo)
		{
			ConfigBusiness.csPM PM=new csPM ();
		    PM.ETX= objImixStoreInfo;
		    PM.STX= this;
		    PM.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(PM.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 =PM.Is_SOH;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public bool DeletePreviewDummyTag(long iMIXStoreConfigurationValueId)
		{
            ConfigBusiness.csAPC APC=new csAPC ();
            APC.ETX=iMIXStoreConfigurationValueId;
            APC.STX=this;
            APC.Is_SOH=false;
			this.operation = new BaseBusiness.TransactionMethod(APC.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 =APC.Is_SOH;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

        public ReportConfigurationDetails GetReportConfigurationDetails()
		{
			ReportConfigurationDetails reportConfigurationDetails = ReportConfigurationDetails.LoadDefaultData();
			try
			{
                ConfigBusiness.csSTX STX=null;
                ConfigBusiness.csSOH SOH=new csSOH ();
                List<iMIXStoreConfigurationInfo> allReportConfiguration = null; //SqlDepandencyCache.GetAllReportConfiguration();
				
				if (allReportConfiguration == null)
				{
					//goto IL_152;
				}
				
				if (allReportConfiguration.Count <= 0)
				{
					//goto IL_152;
				}
				IEnumerable<iMIXStoreConfigurationInfo> arg_19E_0 = allReportConfiguration;
                //if (STX== null)
                //{
                //  STX = new Func<iMIXStoreConfigurationInfo, bool>(ConfigBusiness.csSOH));
                //}
				iMIXStoreConfigurationInfo iMIXStoreConfigurationInfo = null;//arg_19E_0.FirstOrDefault(STX);
				if (iMIXStoreConfigurationInfo == null)
				{
					goto IL_71;
				}
				IL_65:
				reportConfigurationDetails.ExportPath = iMIXStoreConfigurationInfo.ConfigurationValue;
				IL_71:
				IEnumerable<iMIXStoreConfigurationInfo> arg_8F_0 = allReportConfiguration;
				ConfigBusiness.csETX ETX=new csETX ();
                if (ETX== null)
				{
				//ETX = new Func<iMIXStoreConfigurationInfo, bool>(SOH);
				}
				iMIXStoreConfigurationInfo iMIXStoreConfigurationInfo2 = null;//arg_8F_0.FirstOrDefault(ETX);
				do
				{
					if (iMIXStoreConfigurationInfo2 != null)
					{
						string[] array = iMIXStoreConfigurationInfo2.ConfigurationValue.Split(new char[]
						{
							':',
							' '
						});
						if (array != null)
						{
							reportConfigurationDetails.SelectedHour = Convert.ToInt32(array[0]);
							reportConfigurationDetails.SelectedMinute = Convert.ToInt32(array[1]);
						}
					}
				}
				while (false);
				IEnumerable<iMIXStoreConfigurationInfo> arg_FE_0 = allReportConfiguration;
				ConfigBusiness.csEOT EOT=new csEOT ();
                //ConfigBusiness.csETX ETX=new csETX ();
                if (EOT == null)
				{
					//EOT = new Func<iMIXStoreConfigurationInfo, bool>(ETX.ETX);
				}
				iMIXStoreConfigurationInfo iMIXStoreConfigurationInfo3 =null; //arg_FE_0.FirstOrDefault(EOT);
				if (iMIXStoreConfigurationInfo3 == null)
				{
					goto IL_11C;
				}
				IL_109:
				reportConfigurationDetails.IsRecursive = Convert.ToBoolean(iMIXStoreConfigurationInfo3.ConfigurationValue);//.ToBoolean(false);
				IL_11C:
				IEnumerable<iMIXStoreConfigurationInfo> arg_13A_0 = allReportConfiguration;
				ConfigBusiness.csENQ ENQ=new csENQ ();
                if (ENQ== null)
				{
					//ENQ= new Func<iMIXStoreConfigurationInfo, bool>(EOT.EOT);
				}
				iMIXStoreConfigurationInfo iMIXStoreConfigurationInfo4 = null;//arg_13A_0.FirstOrDefault(ENQ);
				if (iMIXStoreConfigurationInfo4 != null)
				{
					reportConfigurationDetails.EmailAddress = iMIXStoreConfigurationInfo4.ConfigurationValue;
				}
                //IL_152:
                //reportConfigurationDetails.ReportTypeDetails = this.GetRequestedReports();
                //reportConfigurationDetails.ExportServiceLogs = this.GetExportServiceLogs();
				if (false)
				{
					goto IL_65;
				}
			}
			catch (Exception ex)
			{
				reportConfigurationDetails.HasError = true;
				reportConfigurationDetails.ErrorDetails = ex.Message + '\n' + ex.StackTrace;
				reportConfigurationDetails.ErrorMessage = ConfigBusiness.getConfigBusiness(693);
			}
			return reportConfigurationDetails;
		}

		public List<ReportTypeDetails> GetReport()
		{
            csSOH_STX SOH_STX=new csSOH_STX ();
			if (!false)
			{
				
				do
				{
		         SOH_STX.STX= this;
				}
				while (false);
		        SOH_STX.lst_SOH= new List<ReportTypeDetails>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(SOH_STX.SOH);
				}
				while (2 == 0);
				base.Start(false);
			}
			return SOH_STX.lst_SOH;
		}

		public List<ReportTypeDetails> GetActiveReports()
		{
			List<ReportTypeDetails> report;
			if (4 != 0)
			{
				report = this.GetReport();
			}
			IEnumerable<ReportTypeDetails> arg_3D_0 = report;
            ConfigBusiness .ACK ACK=new ACK ();
			if (ACK ==null)
			{
				//ACK= new Func<ReportTypeDetails, bool>(ConfigBusiness.csSOH);
			}
			return null; //arg_3D_0.Where(ACK).ToList<ReportTypeDetails>();
		}



        public bool InsertReportConfig(ReportConfigurationDetails reportConfigurationDetails)
		{
			ConfigBusiness.csSTX_STX  STX_STX=new ConfigBusiness.csSTX_STX();
            STX_STX.ETX=this;
            STX_STX.Is_SOH=false;

			List<iMIXStoreConfigurationInfo> list = new List<iMIXStoreConfigurationInfo>();
			list.Add(new iMIXStoreConfigurationInfo
			{
				IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.ExportPath),
				ConfigurationValue = reportConfigurationDetails.ExportPath
			});
			list.Add(new iMIXStoreConfigurationInfo
			{
				IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.ScheduledTime),
				ConfigurationValue = reportConfigurationDetails.ScheduleTime
			});
			list.Add(new iMIXStoreConfigurationInfo
			{
				IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.IsServiceRecursive),
				ConfigurationValue = reportConfigurationDetails.IsRecursive.ToString()
			});
			list.Add(new iMIXStoreConfigurationInfo
			{
				IMIXConfigurationMasterId = (long)Convert.ToInt32(ConfigParams.ExportReportEmailAddress),
				ConfigurationValue = reportConfigurationDetails.EmailAddress
			});
		    STX_STX.STX = new DataTable();
		    STX_STX.STX.Columns.Add(ConfigBusiness.getConfigBusiness(533));
			do
			{
		     STX_STX.STX.Columns.Add(ConfigBusiness.getConfigBusiness(562));
			}
			while (5 == 0);
		    STX_STX.STX.Columns.Add(ConfigBusiness.getConfigBusiness(587));
			foreach (iMIXStoreConfigurationInfo current in list)
			{
			STX_STX.STX.Rows.Add(new object[]
				{
					current.IMIXConfigurationMasterId,
					current.ConfigurationValue,
					0
				});
			}
			this.operation = new BaseBusiness.TransactionMethod(STX_STX.SOH);
			base.Start(false);
			this.UpdateReportTypes(reportConfigurationDetails.ReportTypeDetails);
			return STX_STX.Is_SOH;
		}

		public bool SaveExportReportLogDetails(ExportServiceLog exportReportLogDetails)
		{
			ConfigBusiness.csETX_ETX ETX_ETX=new csETX_ETX ();
		     ETX_ETX.ETX= exportReportLogDetails;
		     ETX_ETX.STX= this;
		     ETX_ETX.Is_SOH= false;
			this.operation = new BaseBusiness.TransactionMethod(ETX_ETX.SOH);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 =ETX_ETX.Is_SOH;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public List<ExportServiceLog> GetExportServiceLogs()
		{
            csEOT_STX EOT_STX=new csEOT_STX ();
			if (!false)
			{
				do
				{
			       EOT_STX.STX= this;
				}
				while (false);
			    EOT_STX.list_SOH= new List<ExportServiceLog>();
				do
				{
					this.operation = new BaseBusiness.TransactionMethod(EOT_STX.SOH);
				}
				while (2 == 0);
				base.Start(false);
			}
			return EOT_STX.list_SOH;
		}

		public DataTable ParseListIntoPaymentDataTable(List<PaymentSummaryInfo> paymentSummaryInfo)
		{
			DataTable dataTable = new DataTable();
            //if (paymentSummaryInfo != null && paymentSummaryInfo.Count > 0)
            //{
            //    ConfigBusiness.  = new ConfigBusiness.();
            //    ReportParams reportParams = new ReportBusiness().FetchReportFormatDetails(4);
            //    foreach (KeyValuePair<string, string> current in reportParams.ReportFormats)
            //    {
            //        dataTable.Columns.Add(new DataColumn(current.Key));
            //    }
            //    ConfigBusiness. arg_B0_0 = ;
            //    if (ConfigBusiness. == null)
            //    {
            //        ConfigBusiness. = new Func<PaymentSummaryInfo, string>(ConfigBusiness.);
            //    }
            //    arg_B0_0. = paymentSummaryInfo.DistinctBy(ConfigBusiness.).FirstOrDefault<PaymentSummaryInfo>().StoreName;
            //    IEnumerable<PaymentSummaryInfo> arg_E5_0 = paymentSummaryInfo.Where(new Func<PaymentSummaryInfo, bool>(.));
            //    if (ConfigBusiness. == null)
            //    {
            //        ConfigBusiness. = new Func<PaymentSummaryInfo, string>(ConfigBusiness.);
            //    }
            //    IEnumerable<PaymentSummaryInfo> arg_107_0 = arg_E5_0.DistinctBy(ConfigBusiness.);
            //    if (ConfigBusiness. == null)
            //    {
            //        ConfigBusiness. = new Func<PaymentSummaryInfo, string>(ConfigBusiness.);
            //    }
            //    List<string> list = arg_107_0.Select(ConfigBusiness.).ToList<string>();
            //    IEnumerable<PaymentSummaryInfo> arg_142_0 = paymentSummaryInfo.Where(new Func<PaymentSummaryInfo, bool>(.));
            //    if (ConfigBusiness. == null)
            //    {
            //        ConfigBusiness. = new Func<PaymentSummaryInfo, string>(ConfigBusiness.);
            //    }
            //    IEnumerable<PaymentSummaryInfo> arg_164_0 = arg_142_0.DistinctBy(ConfigBusiness.);
            //    if (ConfigBusiness. == null)
            //    {
            //        ConfigBusiness. = new Func<PaymentSummaryInfo, string>(ConfigBusiness.);
            //    }
            //    List<string> list2 = arg_164_0.Select(ConfigBusiness.).ToList<string>();
            //    IEnumerable<string> arg_18E_0 = list;
            //    if (ConfigBusiness. == null)
            //    {
            //        ConfigBusiness. = new Func<string, string, string>(ConfigBusiness.);
            //    }
            //    string value = arg_18E_0.Aggregate(ConfigBusiness.);
            //    IEnumerable<string> arg_1B4_0 = list2;
            //    if (ConfigBusiness. == null)
            //    {
            //        ConfigBusiness. = new Func<string, string, string>(ConfigBusiness.);
            //    }
            //    string value2 = arg_1B4_0.Aggregate(ConfigBusiness.);
            //    PaymentSummaryInfo paymentSummaryInfo2 = paymentSummaryInfo.Where(new Func<PaymentSummaryInfo, bool>(.)).FirstOrDefault<PaymentSummaryInfo>();
            //    decimal storeCardSale = paymentSummaryInfo2.StoreCardSale;
            //    decimal storeCashSale = paymentSummaryInfo2.StoreCashSale;
            //    decimal storeDiscountSale;
            //    decimal fC;
            //    decimal storeRoomChargeSale;
            //    decimal kVLStoreTransactionAmount;
            //    decimal storeCardSaleVoid;
            //    decimal storeCashSaleVoid;
            //    decimal storeDiscountSaleVoid;
            //    decimal fCVoid;
            //    decimal storeRoomChargeSaleVoid;
            //    do
            //    {
            //        storeDiscountSale = paymentSummaryInfo2.StoreDiscountSale;
            //        fC = paymentSummaryInfo2.FC;
            //        storeRoomChargeSale = paymentSummaryInfo2.StoreRoomChargeSale;
            //        kVLStoreTransactionAmount = paymentSummaryInfo2.KVLStoreTransactionAmount;
            //        storeCardSaleVoid = paymentSummaryInfo2.StoreCardSaleVoid;
            //        storeCashSaleVoid = paymentSummaryInfo2.StoreCashSaleVoid;
            //        storeDiscountSaleVoid = paymentSummaryInfo2.StoreDiscountSaleVoid;
            //        fCVoid = paymentSummaryInfo2.FCVoid;
            //        storeRoomChargeSaleVoid = paymentSummaryInfo2.StoreRoomChargeSaleVoid;
            //    }
            //    while (8 == 0);
            //    decimal kVLStoreTransactionAmountVoid = paymentSummaryInfo2.KVLStoreTransactionAmountVoid;
            //    int totalStoreSaleTransactionCount = paymentSummaryInfo2.TotalStoreSaleTransactionCount;
            //    int storeVoidSaleTransactionCount = paymentSummaryInfo2.StoreVoidSaleTransactionCount;
            //    DataRow dataRow = dataTable.NewRow();
            //    dataRow[ConfigBusiness.(718)] = .;
            //    do
            //    {
            //        dataRow[ConfigBusiness.(735)] = value;
            //        dataRow[ConfigBusiness.(748)] = value2;
            //        dataRow[ConfigBusiness.(761)] = storeCardSale;
            //        dataRow[ConfigBusiness.(766)] = storeCashSale;
            //        dataRow[ConfigBusiness.(775)] = storeDiscountSale;
            //    }
            //    while (false);
            //    dataRow[ConfigBusiness.(804)] = fC;
            //    dataRow[ConfigBusiness.(809)] = storeRoomChargeSale;
            //    dataRow[ConfigBusiness.(826)] = kVLStoreTransactionAmount;
            //    dataRow[ConfigBusiness.(831)] = storeCardSale + storeCashSale + storeDiscountSale + fC + storeRoomChargeSale + kVLStoreTransactionAmount;
            //    dataRow[ConfigBusiness.(840)] = storeCardSaleVoid;
            //    dataRow[ConfigBusiness.(853)] = storeCashSaleVoid;
            //    dataRow[ConfigBusiness.(866)] = storeDiscountSaleVoid;
            //    dataRow[ConfigBusiness.(899)] = fCVoid;
            //    dataRow[ConfigBusiness.(912)] = storeRoomChargeSaleVoid;
            //    dataRow[ConfigBusiness.(937)] = kVLStoreTransactionAmountVoid;
            //    dataRow[ConfigBusiness.(950)] = storeCardSaleVoid + storeCashSaleVoid + storeDiscountSaleVoid + fCVoid + storeRoomChargeSaleVoid + kVLStoreTransactionAmountVoid;
            //    dataRow[ConfigBusiness.(967)] = storeCardSale + storeCashSale + storeDiscountSale + fC + storeRoomChargeSale + kVLStoreTransactionAmount - (storeCardSaleVoid + storeCashSaleVoid + storeDiscountSaleVoid + fCVoid + storeRoomChargeSaleVoid + kVLStoreTransactionAmountVoid);
            //    dataRow[ConfigBusiness.(972)] = totalStoreSaleTransactionCount;
            //    dataRow[ConfigBusiness.(1009)] = storeVoidSaleTransactionCount;
            //    dataRow[ConfigBusiness.(1050)] = totalStoreSaleTransactionCount - storeVoidSaleTransactionCount;
            //    dataTable.Rows.Add(dataRow);
            //    using (List<string>.Enumerator enumerator2 = list.GetEnumerator())
            //    {
            //        while (enumerator2.MoveNext())
            //        {
            //            Func<PaymentSummaryInfo, bool> func = null;
            //            ConfigBusiness.  = new ConfigBusiness.();
            //            . = ;
            //            . = enumerator2.Current;
            //            if (func == null)
            //            {
            //                func = new Func<PaymentSummaryInfo, bool>(.);
            //            }
            //            List<PaymentSummaryInfo> list3 = paymentSummaryInfo.Where(func).ToList<PaymentSummaryInfo>();
            //            PaymentSummaryInfo paymentSummaryInfo3 = list3.FirstOrDefault<PaymentSummaryInfo>();
            //            IEnumerable<PaymentSummaryInfo> arg_5D6_0 = list3;
            //            if (ConfigBusiness. == null)
            //            {
            //                ConfigBusiness. = new Func<PaymentSummaryInfo, string>(ConfigBusiness.);
            //            }
            //            IEnumerable<PaymentSummaryInfo> arg_5F8_0 = arg_5D6_0.DistinctBy(ConfigBusiness.);
            //            if (ConfigBusiness. == null)
            //            {
            //                ConfigBusiness. = new Func<PaymentSummaryInfo, string>(ConfigBusiness.);
            //            }
            //            List<string> list4 = arg_5F8_0.Select(ConfigBusiness.).ToList<string>();
            //            IEnumerable<string> arg_623_0 = list4;
            //            if (ConfigBusiness. == null)
            //            {
            //                ConfigBusiness. = new Func<string, string, string>(ConfigBusiness.);
            //            }
            //            arg_623_0.Aggregate(ConfigBusiness.);
            //            decimal arg_630_0 = paymentSummaryInfo3.SubStoreCardSale;
            //            decimal arg_638_0 = paymentSummaryInfo3.SubStoreCashSale;
            //            decimal arg_640_0 = paymentSummaryInfo3.SubStoreDiscountSale;
            //            decimal arg_648_0 = paymentSummaryInfo3.SubStoreFC;
            //            decimal arg_650_0 = paymentSummaryInfo3.SubStoreRoomChargeSale;
            //            decimal subStoreKVLTransactionAmountVoid = paymentSummaryInfo2.SubStoreKVLTransactionAmountVoid;
            //            decimal subStoreCardSaleVoid = paymentSummaryInfo2.SubStoreCardSaleVoid;
            //            decimal subStoreCashSaleVoid = paymentSummaryInfo2.SubStoreCashSaleVoid;
            //            decimal subStoreDiscountSaleVoid = paymentSummaryInfo2.SubStoreDiscountSaleVoid;
            //            decimal subStoreFCVoid = paymentSummaryInfo2.SubStoreFCVoid;
            //            decimal subStoreRoomChargeSaleVoid = paymentSummaryInfo2.SubStoreRoomChargeSaleVoid;
            //            decimal subStoreKVLTransactionAmountVoid2 = paymentSummaryInfo2.SubStoreKVLTransactionAmountVoid;
            //            int totalSubStoreSaleTransactionCount = paymentSummaryInfo2.TotalSubStoreSaleTransactionCount;
            //            int subStoreVoidSaleTransactionCount = paymentSummaryInfo2.SubStoreVoidSaleTransactionCount;
            //            dataRow = dataTable.NewRow();
            //            dataRow[ConfigBusiness.(718)] = .;
            //            dataRow[ConfigBusiness.(735)] = value;
            //            dataRow[ConfigBusiness.(748)] = value2;
            //            dataRow[ConfigBusiness.(761)] = storeCardSale;
            //            dataRow[ConfigBusiness.(766)] = storeCashSale;
            //            dataRow[ConfigBusiness.(775)] = storeDiscountSale;
            //            dataRow[ConfigBusiness.(804)] = fC;
            //            dataRow[ConfigBusiness.(809)] = storeRoomChargeSale;
            //            dataRow[ConfigBusiness.(826)] = subStoreKVLTransactionAmountVoid;
            //            dataRow[ConfigBusiness.(831)] = storeCardSale + storeCashSale + storeDiscountSale + fC + storeRoomChargeSale + subStoreKVLTransactionAmountVoid;
            //            dataRow[ConfigBusiness.(840)] = subStoreCardSaleVoid;
            //            dataRow[ConfigBusiness.(853)] = subStoreCashSaleVoid;
            //            dataRow[ConfigBusiness.(866)] = subStoreDiscountSaleVoid;
            //            dataRow[ConfigBusiness.(899)] = subStoreFCVoid;
            //            dataRow[ConfigBusiness.(912)] = subStoreRoomChargeSaleVoid;
            //            dataRow[ConfigBusiness.(937)] = subStoreKVLTransactionAmountVoid2;
            //            dataRow[ConfigBusiness.(950)] = subStoreCardSaleVoid + subStoreCashSaleVoid + subStoreDiscountSaleVoid + subStoreFCVoid + subStoreRoomChargeSaleVoid + subStoreKVLTransactionAmountVoid2;
            //            dataRow[ConfigBusiness.(967)] = storeCardSale + storeCashSale + storeDiscountSale + fC + storeRoomChargeSale + subStoreKVLTransactionAmountVoid - (subStoreCardSaleVoid + subStoreCashSaleVoid + subStoreDiscountSaleVoid + subStoreFCVoid + subStoreRoomChargeSaleVoid + subStoreKVLTransactionAmountVoid2);
            //            dataRow[ConfigBusiness.(972)] = totalSubStoreSaleTransactionCount;
            //            dataRow[ConfigBusiness.(1009)] = subStoreVoidSaleTransactionCount;
            //            dataRow[ConfigBusiness.(1050)] = totalSubStoreSaleTransactionCount - subStoreVoidSaleTransactionCount;
            //            dataTable.Rows.Add(dataRow);
            //        }
            //    }
            //}
			return dataTable;
		}

		public DataTable CreateReportData(DataTable dt, ReportTypes reportType)
		{
			DataTable dataTable = new DataTable();
            //string arg_2AE_0 = string.Empty;
            //double num = 0.0;
            //string arg_2BA_0 = string.Empty;
            //ReportParams reportParams = new ReportBusiness().FetchReportFormatDetails((int)reportType);
            //foreach (KeyValuePair<string, string> current in reportParams.ReportFormats)
            //{
            //    dataTable.Columns.Add(new DataColumn(current.Key));
            //}
            //foreach (DataRow dataRow in dt.Rows)
            //{
            //    bool flag = false;
            //    try
            //    {
            //        string text = Convert.ToString(dataRow[ConfigBusiness.(1083)]);
            //        if (text.ToLower().Contains(ConfigBusiness.(1100)))
            //        {
            //            flag = true;
            //        }
            //    }
            //    catch
            //    {
            //        flag = false;
            //    }
            //    DataRow dataRow2 = dataTable.NewRow();
            //    foreach (KeyValuePair<string, string> current2 in reportParams.ReportFormats)
            //    {
            //        string[] array = current2.Value.Split(new char[]
            //        {
            //            '~'
            //        });
            //        string text2 = string.Empty;
            //        num = 0.0;
            //        string text3 = string.Empty;
            //        if (array.Length > 1)
            //        {
            //            string[] array2 = array;
            //            for (int i = 0; i < array2.Length; i++)
            //            {
            //                string columnName = array2[i];
            //                text2 = dataRow[columnName].ToString();
            //                if (double.TryParse(text2, out num))
            //                {
            //                    text2 = num.ToString(ConfigBusiness.(1105));
            //                    if (flag)
            //                    {
            //                        text2 = ConfigBusiness.(1114) + text2;
            //                    }
            //                }
            //                if (string.IsNullOrEmpty(text3))
            //                {
            //                    text3 = text2;
            //                }
            //                else
            //                {
            //                    text3 = text3 + ConfigBusiness.(1119) + text2;
            //                }
            //            }
            //            dataRow2[current2.Key] = text3;
            //        }
            //        else
            //        {
            //            text2 = dataRow[current2.Value].ToString();
            //            if (double.TryParse(text2, out num))
            //            {
            //                text2 = num.ToString(ConfigBusiness.(1105));
            //                if (flag)
            //                {
            //                    text2 = ConfigBusiness.(1114) + text2;
            //                }
            //            }
            //            dataRow2[current2.Key] = text2;
            //        }
            //    }
            //    dataTable.Rows.Add(dataRow2);
            //}
			return dataTable;
		}

		public void UpdateReportTypes(List<ReportTypeDetails> reportTypes)
		{
            //ConfigBusiness. ;
            //while (true)
            //{
            //    ConfigBusiness. expr_3C = new ConfigBusiness.();
            //    if (!false)
            //    {
            //         = expr_3C;
            //    }
            //    while (!false)
            //    {
            //        . = reportTypes;
            //        if (4 != 0)
            //        {
            //            goto Block_1;
            //        }
            //    }
            //}
            //Block_1:
            //. = this;
            //this.operation = new BaseBusiness.TransactionMethod(.);
            //base.Start(false);
		}

		public List<ReportTypeDetails> GetRequestedReports()
		{
			ConfigBusiness.csBS_STX BS_STX=new csBS_STX ();
			List<ReportTypeDetails> report = this.GetReport();
	         BS_STX.arr_SOH= Enum.GetNames(typeof(ReportTypes));
			IEnumerable<ReportTypeDetails> arg_4A_0 = report.Where(new Func<ReportTypeDetails, bool>(BS_STX.SOH));
			ConfigBusiness.csSYN SYN=null;
            ConfigBusiness.csSOH SOH=new csSOH();
            if (SYN== null)
			{
				//SYN = new Func<ReportTypeDetails, ReportTypeDetails>(SOH);
			}
			return null;//arg_4A_0.Select(ConfigBusiness.csSYN).ToList<ReportTypeDetails>();
		}

		public string GetSubStoreNameBySuubStoreId(int subStoreId)
		{
            ConfigBusiness.csSO_STX SO_STX=new csSO_STX ();
            SO_STX.ETX= subStoreId;
            SO_STX.STX= this;
            SO_STX.str_SOH= string.Empty;
            this.operation = new BaseBusiness.TransactionMethod(SO_STX.SOH);
            base.Start(false);
			return SO_STX.str_SOH;
		}

		public void DeleteLocationWiseConfigParamsGumbleRide(int LocationId)
		{
            //ConfigBusiness. ;
            //while (true)
            //{
            //    ConfigBusiness. expr_3C = new ConfigBusiness.();
            //    if (!false)
            //    {
            //         = expr_3C;
            //    }
            //    while (!false)
            //    {
            //        . = LocationId;
            //        if (4 != 0)
            //        {
            //            goto Block_1;
            //        }
            //    }
            //}
            //Block_1:
            //. = this;
            //this.operation = new BaseBusiness.TransactionMethod(.);
            //base.Start(false);
		}

		public bool IsLocationRFIDEnabled(int locationId)
		{
            //ConfigBusiness.  = new ConfigBusiness.();
            //. = locationId;
            //. = this;
            //. = false;
            //this.operation = new BaseBusiness.TransactionMethod(.);
            bool arg_46_0 =false; //base.Start(false);
            //do
            //{
            //    if (5 != 0)
            //    {
            //        arg_46_0 = .;
            //    }
            //}
            //while (2 == 0);
			return arg_46_0;
		}

		public List<iMixConfigurationLocationInfo> GetAllLocationWiseConfigParams()
		{
            //if (!false)
            //{
            //    do
            //    {
            //       = this;
            //    }
            //    while (false);
            //    . = new List<iMixConfigurationLocationInfo>();
            //    do
            //    {
            //        this.operation = new BaseBusiness.TransactionMethod(.);
            //    }
            //    while (2 == 0);
            //    base.Start(false);
            //}
			return null;
		}

        //private static bool (iMIXStoreConfigurationInfo )
        //{
        //    return false;//.IMIXConfigurationMasterId == 143L;
        //}

		
        //private static bool (iMIXStoreConfigurationInfo )
        //{
        //    return false;//.IMIXConfigurationMasterId == 144L;
        //}

		
        //private static bool (iMIXStoreConfigurationInfo )
        //{
        //    return false;//.IMIXConfigurationMasterId == 145L;
        //}

        //private static bool (iMIXStoreConfigurationInfo )
        //{
        //    return .IMIXConfigurationMasterId == 146L;
        //}

        //private static bool (ReportTypeDetails )
        //{
        //    return .IsActive;
        //}

        //private static string (PaymentSummaryInfo )
        //{
        //    return .StoreName;
        //}

		
        //private static string (PaymentSummaryInfo )
        //{
        //    return .SubStoreName;
        //}

        //private static string (PaymentSummaryInfo )
        //{
        //    return .SubStoreName;
        //}

		
        //private static string (PaymentSummaryInfo )
        //{
        //    return .Productcode;
        //}

		
        //private static string (PaymentSummaryInfo )
        //{
        //    return .Productcode;
        //}

		
        //private static string (string , string )
        //{
        //    return  + ConfigBusiness.(381) + ;
        //}

		
        //private static string (string , string )
        //{
        //    return  + ConfigBusiness.(381) + ;
        //}

		
        //private static string (PaymentSummaryInfo )
        //{
        //    return .Productcode;
        //}

	
        //private static string (PaymentSummaryInfo )
        //{
        //    return .Productcode;
        //}

		
        //private static string (string , string )
        //{
        //    return  + ConfigBusiness.(381) + ;
        //}

        //private static ReportTypeDetails (ReportTypeDetails )
        //{
        //    ReportTypeDetails expr_36 = new ReportTypeDetails();
        //    ReportTypeDetails reportTypeDetails;
        //    if (3 != 0)
        //    {
        //        reportTypeDetails = expr_36;
        //    }
        //    reportTypeDetails.Id = .Id;
        //    reportTypeDetails.IsActive = .IsActive;
        //    reportTypeDetails.ReportLabel = .ReportLabel;
        //    if (!false)
        //    {
        //        reportTypeDetails.ReportTypeName = .ReportTypeName;
        //    }
        //    return reportTypeDetails;
        //}




		static ConfigBusiness()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ConfigBusiness));
		}
	}
}
