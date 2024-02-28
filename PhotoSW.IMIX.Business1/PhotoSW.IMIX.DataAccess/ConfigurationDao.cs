//using #2j;
using PhotoSW.IMIX.Model;
using DigiPhoto.Utility.Repository.ValueType;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace PhotoSW.IMIX.DataAccess
{
	public class ConfigurationDao : BaseDataAccess
	{
        //[NonSerialized]
        //internal static SmartAssembly.Delegates.GetString ;
        internal static SmartAssembly .Delegates.GetString getConfigurationDao;

		public ConfigurationDao(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public ConfigurationDao()
		{
		}

		public ConfigurationInfo GetConfigurationSetting(int subStoreId)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigurationDao.getConfigurationDao(2322), subStoreId);
			IDataReader dataReader=null;
			if (true && !false)
			{
				//dataReader = base.ExecuteReader(#1j.#8f);
			}
			List<ConfigurationInfo> source;
			do
			{
				source = this.MapConfigurationInfo(dataReader);
			}
			while (false);
			dataReader.Close();
			return source.FirstOrDefault<ConfigurationInfo>();
		}

		public List<ConfigurationInfo> GetAllConfigurationSetting()
		{
			List<ConfigurationInfo> result = null;
			do
			{
				List<SqlParameter> expr_56 = base.DBParameters;
				if (!false)
				{
					expr_56.Clear();
				}
				base.OpenConnection();
				base.AddParameter(ConfigurationDao.getConfigurationDao (2322), DBNull.Value);
			}
			while (false);
            //using (IDataReader dataReader = base.ExecuteReader(#1j.#8f))
            //{
            //    result = this.MapConfigurationInfo(dataReader);
            //    dataReader.Close();
            //}
			return result;
		}

		public List<ConfigurationInfo> GetConfigurationSettings()
		{
			List<ConfigurationInfo> result = null;
			do
			{
				base.DBParameters.Clear();
				if (!false)
				{
					base.OpenConnection();
					if (-1 == 0)
					{
						continue;
					}
                    //using (IDataReader dataReader = base.ExecuteReader(#1j.#8f))
                    //{
                    //    result = this.MapConfigurationInfo(dataReader);
                    //    dataReader.Close();
                    //}
				}
			}
			while (4 == 0);
			return result;
		}

		public List<ConfigurationInfo> MapConfigurationInfo(IDataReader sqlReader)
		{
			int num = 0;
			CurrencyInfo defaultCurrency = new CurrencyDao().GetDefaultCurrency();
			if (defaultCurrency != null)
			{
				num = defaultCurrency.DG_Currency_pkey;
			}
			List<ConfigurationInfo> list = new List<ConfigurationInfo>();
			while (sqlReader.Read())
			{
				ConfigurationInfo item = new ConfigurationInfo
				{
					DG_Config_pkey = base.GetFieldValue(sqlReader,                     ConfigurationDao.getConfigurationDao(8413), 0),
					DG_Hot_Folder_Path = base.GetFieldValue(sqlReader,                 ConfigurationDao.getConfigurationDao(8434), string.Empty),
					DG_Frame_Path = base.GetFieldValue(sqlReader,                      ConfigurationDao.getConfigurationDao(8459), string.Empty),
					DG_BG_Path = base.GetFieldValue(sqlReader,                         ConfigurationDao.getConfigurationDao(8480), string.Empty),
					DG_Mod_Password = base.GetFieldValue(sqlReader,                    ConfigurationDao.getConfigurationDao(8497), string.Empty),
					DG_NoOfPhotos = new int?(base.GetFieldValue(sqlReader,             ConfigurationDao.getConfigurationDao(8518), 0)),
					DG_Watermark = new bool?(base.GetFieldValue(sqlReader,             ConfigurationDao.getConfigurationDao(8539), false)),
					DG_SemiOrder = new bool?(base.GetFieldValue(sqlReader,             ConfigurationDao.getConfigurationDao(8556), false)),
					DG_HighResolution = new bool?(base.GetFieldValue(sqlReader,        ConfigurationDao.getConfigurationDao(8573), false)),
					DG_AllowDiscount = new bool?(base.GetFieldValue(sqlReader,         ConfigurationDao.getConfigurationDao(8598), false)),
					DG_EnableDiscountOnTotal = new bool?(base.GetFieldValue(sqlReader, ConfigurationDao.getConfigurationDao(8623), false)),
					WiFiStartingNumber = new decimal?(base.GetFieldValue(sqlReader,    ConfigurationDao.getConfigurationDao(8656), 0.0m)),
					FolderStartingNumber = new decimal?(base.GetFieldValue(sqlReader,  ConfigurationDao.getConfigurationDao(8681), 0.0m)),
					IsAutoLock = new bool?(base.GetFieldValue(sqlReader,               ConfigurationDao.getConfigurationDao(8710), false)),
					DG_SemiOrderMain = new bool?(base.GetFieldValue(sqlReader,         ConfigurationDao.getConfigurationDao(8727), false)),
					PosOnOff = new bool?(base.GetFieldValue(sqlReader,                 ConfigurationDao.getConfigurationDao(8752), false)),
					DG_ReceiptPrinter = base.GetFieldValue(sqlReader,                  ConfigurationDao.getConfigurationDao(8765), string.Empty),
					DG_IsAutoRotate = new bool?(base.GetFieldValue(sqlReader,          ConfigurationDao.getConfigurationDao(8790), false)),
					DG_Graphics_Path = base.GetFieldValue(sqlReader,                   ConfigurationDao.getConfigurationDao(8811), string.Empty),
					DG_IsCompression = new bool?(base.GetFieldValue(sqlReader,         ConfigurationDao.getConfigurationDao(8836), false)),
					DG_IsEnableGroup = new bool?(base.GetFieldValue(sqlReader,         ConfigurationDao.getConfigurationDao(8861), false)),
					DG_Substore_Id = new int?(base.GetFieldValue(sqlReader,            ConfigurationDao.getConfigurationDao(8886), 0)),
					DG_NoOfBillReceipt = new int?(base.GetFieldValue(sqlReader,        ConfigurationDao.getConfigurationDao(8907), 0)),
					DG_ChromaColor = base.GetFieldValue(sqlReader,                     ConfigurationDao.getConfigurationDao(8932), string.Empty),
					DG_ChromaTolerance = new decimal?(base.GetFieldValue(sqlReader,    ConfigurationDao.getConfigurationDao(8953), 0.0m)),
					DG_DbBackupPath = base.GetFieldValue(sqlReader,                    ConfigurationDao.getConfigurationDao(8978), string.Empty),
					DG_CleanupTables = base.GetFieldValue(sqlReader,                   ConfigurationDao.getConfigurationDao(8999), string.Empty),
					DG_HfBackupPath = base.GetFieldValue(sqlReader,                    ConfigurationDao.getConfigurationDao(9024), string.Empty),
					DG_ScheduleBackup = base.GetFieldValue(sqlReader,                  ConfigurationDao.getConfigurationDao(9045), string.Empty),
					DG_IsBackupScheduled = new bool?(base.GetFieldValue(sqlReader,     ConfigurationDao.getConfigurationDao(9070), false)),
					DG_Brightness = new double?((double)base.GetFieldValue(sqlReader,  ConfigurationDao.getConfigurationDao(9099), 0f)),
					DG_Contrast = new double?((double)base.GetFieldValue(sqlReader,    ConfigurationDao.getConfigurationDao(9120), 0f)),
					DG_PageCountGrid = new int?(base.GetFieldValue(sqlReader,          ConfigurationDao.getConfigurationDao(9137), 0)),
					DG_PageCountPreview = new int?(base.GetFieldValue(sqlReader,       ConfigurationDao.getConfigurationDao(9162), 0)),
					DG_NoOfPhotoIdSearch = new int?(base.GetFieldValue(sqlReader,      ConfigurationDao.getConfigurationDao(9191), 0)),
					IsRecursive = new bool?(base.GetFieldValue(sqlReader,              ConfigurationDao.getConfigurationDao(9220), false)),
					IntervalCount = new int?(base.GetFieldValue(sqlReader,             ConfigurationDao.getConfigurationDao(9237), 0)),
					intervalType = new int?(base.GetFieldValue(sqlReader,              ConfigurationDao.getConfigurationDao(9258), 0)),
					DG_MktImgPath = base.GetFieldValue(sqlReader,                      ConfigurationDao.getConfigurationDao(9275), string.Empty),
					DG_MktImgTimeInSec = new int?(base.GetFieldValue(sqlReader,        ConfigurationDao.getConfigurationDao(9296), 0)),
					EK_SampleImagePath = base.GetFieldValue(sqlReader,                 ConfigurationDao.getConfigurationDao(9321), string.Empty),
					EK_DisplayDuration = new int?(base.GetFieldValue(sqlReader,        ConfigurationDao.getConfigurationDao(9346), 0)),
					EK_ScreenStartTime = new int?(base.GetFieldValue(sqlReader,        ConfigurationDao.getConfigurationDao(9371), 0)),
					EK_IsScreenSaverActive = new bool?(base.GetFieldValue(sqlReader,   ConfigurationDao.getConfigurationDao(9396), false)),
					IsDeleteFromUSB = new bool?(base.GetFieldValue(sqlReader,          ConfigurationDao.getConfigurationDao(9429), false)),
					DG_CleanUpDaysBackUp = new int?(base.GetFieldValue(sqlReader,      ConfigurationDao.getConfigurationDao(9450), 0)),
					IsExportReportToAnyDrive = new bool?(base.GetFieldValue(sqlReader, ConfigurationDao.getConfigurationDao(9479), false)),
					FtpIP = base.GetFieldValue(sqlReader,     ConfigurationDao.getConfigurationDao(9512), string.Empty),
					FtpUid = base.GetFieldValue(sqlReader,    ConfigurationDao.getConfigurationDao(9521), string.Empty),
					FtpPwd = base.GetFieldValue(sqlReader,    ConfigurationDao.getConfigurationDao(9530), string.Empty),
					FtpFolder = base.GetFieldValue(sqlReader, ConfigurationDao.getConfigurationDao(9539), string.Empty),
					DefaultCurrencyId = new int?(num),
					DefaultCurrency = num
				};
				list.Add(item);
			}
			return list;
		}

		public List<ConfigurationInfo> SelectConfigurationSettings(int subStoreId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ConfigurationDao.getConfigurationDao(2322), subStoreId);
			}
			IDataReader dataReader=null;
			List<ConfigurationInfo> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#8f);
				if (3 != 0)
				{
					result = this.MapConfigurationInfo(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		public bool UpdateConfigSettings(ConfigurationInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigurationDao.getConfigurationDao(9552), objectInfo.DG_Config_pkey);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9581), objectInfo.DG_Hot_Folder_Path);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9614), objectInfo.DG_Frame_Path);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9643), objectInfo.DG_BG_Path);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9668), objectInfo.DG_Mod_Password);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9697), objectInfo.DG_NoOfPhotos);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9726), objectInfo.DG_Watermark);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9751), objectInfo.DG_SemiOrder);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9776), objectInfo.DG_HighResolution);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9809), objectInfo.DG_AllowDiscount);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9842), objectInfo.DG_SemiOrderMain);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9875), objectInfo.PosOnOff);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9896), objectInfo.DG_ReceiptPrinter);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9929), objectInfo.DG_IsAutoRotate);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9958), objectInfo.DG_Graphics_Path);
			base.AddParameter(ConfigurationDao.getConfigurationDao(9991), objectInfo.DG_IsCompression);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10024), objectInfo.DG_IsEnableGroup);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10057), objectInfo.DG_NoOfBillReceipt);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10090), objectInfo.DG_ChromaColor);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10119), objectInfo.DG_ChromaTolerance);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10152), objectInfo.DG_PageCountGrid);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10185), objectInfo.DG_PageCountPreview);
			base.AddParameter(ConfigurationDao.getConfigurationDao(407), objectInfo.IsSynced);
			//base.ExecuteNonQuery(#1j.#9f);
			return true;
		}

		public bool UpdateConfigValue(iMIXConfigurationInfo objectInfo)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigurationDao.getConfigurationDao(10222), objectInfo.IMIXConfigurationValueId);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10263), objectInfo.ConfigurationValue);
			base.AddParameter(ConfigurationDao.getConfigurationDao(407), objectInfo.IsSynced);
			//base.ExecuteNonQuery(#1j.#cg);
			return true;
		}

		public iMIXConfigurationInfo GetConfigValue(int? subStoreId, int? configMasterId)
		{
			if (3 != 0)
			{
				base.DBParameters.Clear();
			}
			do
			{
				base.AddParameter(ConfigurationDao.getConfigurationDao(2322), base.SetNullIntegerValue(subStoreId));
				base.AddParameter(ConfigurationDao.getConfigurationDao(10296), base.SetNullIntegerValue(configMasterId));
			}
			while (2 == 0);
			List<iMIXConfigurationInfo> source=null;
			if (3 != 0)
			{
                //using (IDataReader dataReader = base.ExecuteReader(#1j.#bg))
                //{
                //    source = this.IXConfigurationInfo4(dataReader);
                //}
			}
			return source.FirstOrDefault<iMIXConfigurationInfo>();
		}

		public List<iMIXConfigurationInfo> SelectConfigValue(int? subStoreId, int? configMasterId)
		{
			if (!false && -1 != 0)
			{
				base.DBParameters.Clear();
			}
			base.AddParameter(ConfigurationDao.getConfigurationDao(2322), base.SetNullIntegerValue(subStoreId));
			base.AddParameter(ConfigurationDao.getConfigurationDao(10296), base.SetNullIntegerValue(configMasterId));
			List<iMIXConfigurationInfo> result=null;
            //using (IDataReader dataReader = base.ExecuteReader(#1j.#bg))
            //{
            //    do
            //    {
            //        result = this.IXConfigurationInfo4(dataReader);
            //    }
            //    while (4 == 0);
            //}
			return result;
		}

		private List<iMIXConfigurationInfo> IXConfigurationInfo4(IDataReader IDataReader)
		{
			List<iMIXConfigurationInfo> list = new List<iMIXConfigurationInfo>();
			while (IDataReader.Read())
			{
				iMIXConfigurationInfo item = new iMIXConfigurationInfo
				{
					IMIXConfigurationValueId = base.GetFieldValue(IDataReader,  ConfigurationDao.getConfigurationDao(10333), 0L),
					IMIXConfigurationMasterId = base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(10366), 0L),
					ConfigurationValue = base.GetFieldValue(IDataReader,        ConfigurationDao.getConfigurationDao(10403), string.Empty),
					SubstoreId = base.GetFieldValue(IDataReader,                ConfigurationDao.getConfigurationDao(10428), 0),
					SyncCode = base.GetFieldValue(IDataReader,                  ConfigurationDao.getConfigurationDao(1978), string.Empty),
					IsSynced = base.GetFieldValue(IDataReader,                  ConfigurationDao.getConfigurationDao(1991), false)
				};
				list.Add(item);
			}
			return list;
		}

		public int GetCompressionLevel(long IMIXConfigurationMasterId)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigurationDao.getConfigurationDao(10445), IMIXConfigurationMasterId);
			IDataReader dataReader =null; //base.ExecuteReader(#1j.#Hi);
			List<iMIXConfigurationInfo> source = this.iMIXConfigurationInfoub(dataReader);
			dataReader.Close();
			return source.First<iMIXConfigurationInfo>().ConfigurationValue.ToInt32(false);
		}

		private List<iMIXConfigurationInfo> iMIXConfigurationInfoub(IDataReader IDataReader)
		{
			List<iMIXConfigurationInfo> expr_97 = new List<iMIXConfigurationInfo>();
			List<iMIXConfigurationInfo> list;
			if (5 != 0)
			{
				list = expr_97;
			}
			while (IDataReader.Read())
			{
				iMIXConfigurationInfo item = new iMIXConfigurationInfo
				{
					IMIXConfigurationValueId = (long)base.GetFieldValue(IDataReader,  ConfigurationDao.getConfigurationDao(10333), 0),
					IMIXConfigurationMasterId = (long)base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(10366), 0),
					ConfigurationValue = base.GetFieldValue(IDataReader,              ConfigurationDao.getConfigurationDao(10403), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public List<iMIXConfigurationInfo> GetNewConfigValues(int SubstoreId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ConfigurationDao.getConfigurationDao(3784), SubstoreId);
			}
			IDataReader dataReader=null;
			List<iMIXConfigurationInfo> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#Qi);
				if (3 != 0)
				{
					result = this.MapNewConfigValuesBase(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		public List<iMIXConfigurationInfo> GetAllNewConfigValues()
		{
            //if (false)
            //{
            //    goto IL_40;
            //}
			List<SqlParameter> expr_51 = base.DBParameters;
			if (!false)
			{
				expr_51.Clear();
			}
            //if (-1 == 0)
            //{
            //    goto IL_49;
            //}
			base.AddParameter(ConfigurationDao.getConfigurationDao(3784), DBNull.Value);
			base.OpenConnection();
			IL_28:
			IDataReader dataReader=null;;
            //if (!false)
            //{
            //    dataReader = base.ExecuteReader(#1j.#Qi);
            //}
			List<iMIXConfigurationInfo> result = this.MapNewConfigValuesBase(dataReader);
			IL_40:
			if (-1 == 0)
			{
				goto IL_28;
			}
			dataReader.Close();
			IL_49:
			if (!false)
			{
				return result;
			}
			goto IL_40;
		}

		public List<iMIXConfigurationInfo> MapNewConfigValuesBase(IDataReader sqlReader)
		{
			List<iMIXConfigurationInfo> list = new List<iMIXConfigurationInfo>();
			while (sqlReader.Read())
			{
				iMIXConfigurationInfo item = new iMIXConfigurationInfo
				{
					IMIXConfigurationValueId = base.GetFieldValue(sqlReader,  ConfigurationDao.getConfigurationDao(10333), 0L),
					IMIXConfigurationMasterId = base.GetFieldValue(sqlReader, ConfigurationDao.getConfigurationDao(10366), 0L),
					ConfigurationValue = base.GetFieldValue(sqlReader, ConfigurationDao.getConfigurationDao(10403), string.Empty),
					SubstoreId = base.GetFieldValue(sqlReader,         ConfigurationDao.getConfigurationDao(10428), 0),
					SyncCode = base.GetFieldValue(sqlReader, ConfigurationDao.getConfigurationDao(1978), string.Empty),
					IsSynced = base.GetFieldValue(sqlReader, ConfigurationDao.getConfigurationDao(1991), false)
				};
				list.Add(item);
			}
			return list;
		}

		public iMIXConfigurationInfo GetOnlineConfigDataById(int ObjConfig, int SubStoreId)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigurationDao.getConfigurationDao(10490), ObjConfig);
			base.AddParameter(ConfigurationDao.getConfigurationDao(2322), SubStoreId);
			IDataReader dataReader =null; //base.ExecuteReader(#1j.#ij);
			List<iMIXConfigurationInfo> source = this.iMIXConfigurationInfovb(dataReader);
			dataReader.Close();
			return source.FirstOrDefault<iMIXConfigurationInfo>();
		}

		private List<iMIXConfigurationInfo> iMIXConfigurationInfovb(IDataReader IDataReader)
		{
			List<iMIXConfigurationInfo> list;
			while (true)
			{
				if (!false)
				{
					List<iMIXConfigurationInfo> expr_4C = new List<iMIXConfigurationInfo>();
					if (!false)
					{
						list = expr_4C;
					}
				}
				while (true)
				{
					if (IDataReader.Read() && -1 != 0)
					{
						iMIXConfigurationInfo item = new iMIXConfigurationInfo
						{
							ConfigurationValue = base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(10403), string.Empty)
						};
						if (5 == 0)
						{
							break;
						}
						list.Add(item);
					}
					else
					{
						if (!true)
						{
							break;
						}
						if (!false)
						{
							return list;
						}
					}
				}
			}
			return list;
		}

		public List<ConfigInfo> GetAllConfig()
		{
			List<ConfigInfo> result = null;
			do
			{
				base.DBParameters.Clear();
				if (!false)
				{
					base.OpenConnection();
					if (-1 == 0)
					{
						continue;
					}
                    //using (IDataReader dataReader = base.ExecuteReader(#1j.#Gj))
                    //{
                    //    result = this.MapConfigvalue(dataReader);
                    //    dataReader.Close();
                    //}
				}
			}
			while (4 == 0);
			return result;
		}

		public List<ConfigInfo> MapConfigvalue(IDataReader sqlReader)
		{
			List<ConfigInfo> list = new List<ConfigInfo>();
			while (sqlReader.Read())
			{
				ConfigInfo item = new ConfigInfo
				{
					ConfigID = base.GetFieldValue(sqlReader,    ConfigurationDao.getConfigurationDao(10511), 0),
					SubStoreID = base.GetFieldValue(sqlReader,  ConfigurationDao.getConfigurationDao(10524), 0),
					ConfigKey = base.GetFieldValue(sqlReader,   ConfigurationDao.getConfigurationDao(10541), string.Empty),
					ConfigValue = base.GetFieldValue(sqlReader, ConfigurationDao.getConfigurationDao(10554), string.Empty),
					MasterID = base.GetFieldValue(sqlReader,    ConfigurationDao.getConfigurationDao(10571), 0)
				};
				list.Add(item);
			}
			return list;
		}

		public ConfigurationInfo GetDeafultPath()
		{
			ConfigurationInfo result = null;
			do
			{
				base.DBParameters.Clear();
				if (!false)
				{
					base.OpenConnection();
					if (-1 == 0)
					{
						continue;
					}
                    //using (IDataReader dataReader = base.ExecuteReader(#1j.#6e))
                    //{
                    //    result = this.ConfigurationInfowb(dataReader);
                    //    dataReader.Close();
                    //}
				}
			}
			while (4 == 0);
			return result;
		}

		private ConfigurationInfo ConfigurationInfowb(IDataReader IDataReader)
		{
			ConfigurationInfo result = new ConfigurationInfo();
			while (IDataReader.Read())
			{
				ConfigurationInfo configurationInfo = new ConfigurationInfo();
				configurationInfo.DG_Config_pkey = base.GetFieldValue(IDataReader,                          ConfigurationDao.getConfigurationDao(8413), 0);
				configurationInfo.DG_Hot_Folder_Path = base.GetFieldValue(IDataReader,                      ConfigurationDao.getConfigurationDao(8434), string.Empty);
				configurationInfo.DG_Frame_Path = base.GetFieldValue(IDataReader,                           ConfigurationDao.getConfigurationDao(8459), string.Empty);
				configurationInfo.DG_BG_Path = base.GetFieldValue(IDataReader,                              ConfigurationDao.getConfigurationDao(8480), string.Empty);
				configurationInfo.DG_Mod_Password = base.GetFieldValue(IDataReader,                         ConfigurationDao.getConfigurationDao(8497), string.Empty);
				configurationInfo.DG_NoOfPhotos = new int?(base.GetFieldValue(IDataReader,                  ConfigurationDao.getConfigurationDao(8518), 0));
				configurationInfo.DG_Watermark = new bool?(base.GetFieldValue(IDataReader,                  ConfigurationDao.getConfigurationDao(8539), false));
				configurationInfo.DG_SemiOrder = new bool?(base.GetFieldValue(IDataReader,                  ConfigurationDao.getConfigurationDao(8556), false));
				configurationInfo.DG_HighResolution = new bool?(base.GetFieldValue(IDataReader,             ConfigurationDao.getConfigurationDao(8573), false));
				configurationInfo.DG_AllowDiscount = new bool?(base.GetFieldValue(IDataReader,              ConfigurationDao.getConfigurationDao(8598), false));
				configurationInfo.DG_EnableDiscountOnTotal = new bool?(base.GetFieldValue(IDataReader,      ConfigurationDao.getConfigurationDao(8623), false));
				configurationInfo.WiFiStartingNumber = new decimal?(base.GetFieldValue(IDataReader,         ConfigurationDao.getConfigurationDao(8656), 0.0m));
				configurationInfo.FolderStartingNumber = new decimal?(base.GetFieldValue(IDataReader,       ConfigurationDao.getConfigurationDao(8681), 0.0m));
				configurationInfo.IsAutoLock = new bool?(base.GetFieldValue(IDataReader,                    ConfigurationDao.getConfigurationDao(8710), false));
				configurationInfo.DG_SemiOrderMain = new bool?(base.GetFieldValue(IDataReader,              ConfigurationDao.getConfigurationDao(8727), false));
				configurationInfo.PosOnOff = new bool?(base.GetFieldValue(IDataReader,                      ConfigurationDao.getConfigurationDao(8752), false));
				configurationInfo.DG_ReceiptPrinter = base.GetFieldValue(IDataReader,                       ConfigurationDao.getConfigurationDao(8765), string.Empty);
				configurationInfo.DG_IsAutoRotate = new bool?(base.GetFieldValue(IDataReader,               ConfigurationDao.getConfigurationDao(8790), false));
				configurationInfo.DG_Graphics_Path = base.GetFieldValue(IDataReader,                        ConfigurationDao.getConfigurationDao(8811), string.Empty);
				configurationInfo.DG_IsCompression = new bool?(base.GetFieldValue(IDataReader,              ConfigurationDao.getConfigurationDao(8836), false));
				configurationInfo.DG_IsEnableGroup = new bool?(base.GetFieldValue(IDataReader,              ConfigurationDao.getConfigurationDao(8861), false));
				configurationInfo.DG_Substore_Id = new int?(base.GetFieldValue(IDataReader,                 ConfigurationDao.getConfigurationDao(8886), 0));
				configurationInfo.DG_NoOfBillReceipt = new int?(base.GetFieldValue(IDataReader,             ConfigurationDao.getConfigurationDao(8907), 0));
				configurationInfo.DG_ChromaColor = base.GetFieldValue(IDataReader,                          ConfigurationDao.getConfigurationDao(8932), string.Empty);
				configurationInfo.DG_ChromaTolerance = new decimal?(base.GetFieldValue(IDataReader,         ConfigurationDao.getConfigurationDao(8953), 0.0m));
				configurationInfo.DG_DbBackupPath = base.GetFieldValue(IDataReader,                         ConfigurationDao.getConfigurationDao(8978), string.Empty);
				configurationInfo.DG_CleanupTables = base.GetFieldValue(IDataReader,                        ConfigurationDao.getConfigurationDao(8999), string.Empty);
				configurationInfo.DG_HfBackupPath = base.GetFieldValue(IDataReader,                         ConfigurationDao.getConfigurationDao(9024), string.Empty);
				configurationInfo.DG_ScheduleBackup = base.GetFieldValue(IDataReader,                       ConfigurationDao.getConfigurationDao(9045), string.Empty);
				configurationInfo.DG_IsBackupScheduled = new bool?(base.GetFieldValue(IDataReader,          ConfigurationDao.getConfigurationDao(9070), false));
				configurationInfo.DG_Brightness = new double?((double)base.GetFieldValue(IDataReader,       ConfigurationDao.getConfigurationDao(9099), 0f));
				configurationInfo.DG_Contrast = new double?((double)base.GetFieldValue(IDataReader,         ConfigurationDao.getConfigurationDao(9120), 0f));
				configurationInfo.DG_PageCountGrid = new int?(base.GetFieldValue(IDataReader,               ConfigurationDao.getConfigurationDao(9137), 0));
				configurationInfo.DG_PageCountPreview = new int?(base.GetFieldValue(IDataReader,            ConfigurationDao.getConfigurationDao(9162), 0));
				if (5 != 0)
				{
					configurationInfo.DG_NoOfPhotoIdSearch = new int?(base.GetFieldValue(IDataReader,       ConfigurationDao.getConfigurationDao(9191), 0));
					configurationInfo.IsRecursive = new bool?(base.GetFieldValue(IDataReader,               ConfigurationDao.getConfigurationDao(9220), false));
					configurationInfo.IntervalCount = new int?(base.GetFieldValue(IDataReader,              ConfigurationDao.getConfigurationDao(9237), 0));
					configurationInfo.intervalType = new int?(base.GetFieldValue(IDataReader,               ConfigurationDao.getConfigurationDao(9258), 0));
					configurationInfo.DG_MktImgPath = base.GetFieldValue(IDataReader,                       ConfigurationDao.getConfigurationDao(9275), string.Empty);
				}
				configurationInfo.DG_MktImgTimeInSec = new int?(base.GetFieldValue(IDataReader,             ConfigurationDao.getConfigurationDao(9296), 0));
				configurationInfo.EK_SampleImagePath = base.GetFieldValue(IDataReader,                      ConfigurationDao.getConfigurationDao(9321), string.Empty);
				configurationInfo.EK_DisplayDuration = new int?(base.GetFieldValue(IDataReader,             ConfigurationDao.getConfigurationDao(9346), 0));
				configurationInfo.EK_ScreenStartTime = new int?(base.GetFieldValue(IDataReader,             ConfigurationDao.getConfigurationDao(9371), 0));
				configurationInfo.EK_IsScreenSaverActive = new bool?(base.GetFieldValue(IDataReader,        ConfigurationDao.getConfigurationDao(9396), false));
				configurationInfo.IsDeleteFromUSB = new bool?(base.GetFieldValue(IDataReader,               ConfigurationDao.getConfigurationDao(9429), false));
				configurationInfo.DG_CleanUpDaysBackUp = new int?(base.GetFieldValue(IDataReader,           ConfigurationDao.getConfigurationDao(9450), 0));
				configurationInfo.FtpIP = base.GetFieldValue(IDataReader,                                   ConfigurationDao.getConfigurationDao(9512), string.Empty);
				configurationInfo.FtpUid = base.GetFieldValue(IDataReader,                                  ConfigurationDao.getConfigurationDao(9521), string.Empty);
				configurationInfo.FtpPwd = base.GetFieldValue(IDataReader,                                  ConfigurationDao.getConfigurationDao(9530), string.Empty);
				configurationInfo.FtpFolder = base.GetFieldValue(IDataReader,                               ConfigurationDao.getConfigurationDao(9539), string.Empty);
				result = configurationInfo;
			}
			return result;
		}

		public bool UPDANDINS_ConfigurationData(int NumberofImages, int DefaultCurrency, int SubstoreId, int NoOfReceipt, int PageSizeGrid, int PageSizePreview, int NoOfPhotoIdSearch, bool? Iswatermark, bool? IsHighResolution, bool? IsSemiorder, bool? IsAutoRotate, bool? IsLineItemDiscount, bool? IsTotalDiscount, bool? IsPosOnOff, bool? IsSemiOrderMain, bool? IsCompression, bool? IsEnableGroup, decimal ChromaTolerance, string SyncCode, string Hotfolder, string FramePath, string BgPath, string Graphics, string ChromaColor, string ModPassword, bool? isExportReportToAnyDrive)
		{
			string empty = string.Empty;
			base.DBParameters.Clear();
			base.AddParameter(ConfigurationDao.getConfigurationDao(10584), NumberofImages);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10613), DefaultCurrency);
			base.AddParameter(ConfigurationDao.getConfigurationDao(3784), SubstoreId);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10642), NoOfReceipt);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10667), PageSizeGrid);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10692), PageSizePreview);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10721), NoOfPhotoIdSearch);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10754), Iswatermark);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10779), IsHighResolution);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10812), IsSemiorder);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10837), IsAutoRotate);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10862), IsLineItemDiscount);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10895), IsTotalDiscount);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10924), IsPosOnOff);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10949), IsSemiOrderMain);
			base.AddParameter(ConfigurationDao.getConfigurationDao(10978), IsCompression);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11007), IsEnableGroup);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11036), ChromaTolerance);
			base.AddParameter(ConfigurationDao.getConfigurationDao(386), SyncCode);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11065), Hotfolder);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11086), FramePath);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11107), BgPath);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11124), Graphics);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11145), ChromaColor);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11170), empty, ParameterDirection.Output);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11207), ModPassword);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11232), isExportReportToAnyDrive);
			//base.ExecuteNonQuery(#1j.#7i);
			return true;
		}

		public bool UPDANDINS_SemiOrderConfigurationData(SemiOrderSettings objSemi)
		{
			string arg_05_0 = string.Empty;
			base.DBParameters.Clear();
			base.AddParameter(ConfigurationDao.getConfigurationDao(11273), objSemi.PS_SemiOrder_Settings_Pkey);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11318), objSemi.PS_SemiOrder_Settings_AutoBright);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11371), objSemi.PS_SemiOrder_Settings_AutoBright_Value);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11432), objSemi.PS_SemiOrder_Settings_AutoContrast);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11489), objSemi.PS_SemiOrder_Settings_AutoContrast_Value);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11554), objSemi.PS_SemiOrder_Settings_ImageFrame);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11607), objSemi.PS_SemiOrder_Settings_IsImageFrame);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11664), objSemi.PS_SemiOrder_Environment);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11705), objSemi.PS_SemiOrder_ProductTypeId);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11750), objSemi.PS_SemiOrder_Settings_ImageFrame_Vertical);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11815), objSemi.PS_SemiOrder_BG);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11844), objSemi.PS_SemiOrder_Settings_IsImageBG);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11897), objSemi.PS_SemiOrder_Graphics_layer);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11942), objSemi.PS_SemiOrder_Image_ZoomInfo);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11987), objSemi.PS_SubStoreId);
			base.AddParameter(ConfigurationDao.getConfigurationDao(12016), objSemi.PS_SemiOrder_IsPrintActive);
			base.AddParameter(ConfigurationDao.getConfigurationDao(12061), objSemi.PS_SemiOrder_IsCropActive);
			base.AddParameter(ConfigurationDao.getConfigurationDao(12106), objSemi.VerticalCropValues);
			base.AddParameter(ConfigurationDao.getConfigurationDao(12139), objSemi.HorizontalCropValues);
			base.AddParameter(ConfigurationDao.getConfigurationDao(12176), objSemi.PS_LocationId);
			base.AddParameter(ConfigurationDao.getConfigurationDao(11145), objSemi.ChromaColor);
			base.AddParameter(ConfigurationDao.getConfigurationDao(12205), objSemi.ColorCode);
			base.AddParameter(ConfigurationDao.getConfigurationDao(12226), objSemi.ClrTolerance);
			base.AddParameter(ConfigurationDao.getConfigurationDao(12251), objSemi.TextLogos);
			base.AddParameter(ConfigurationDao.getConfigurationDao(12288), objSemi.PS_SemiOrder_Settings_Pkey, ParameterDirection.Output);
			//base.ExecuteNonQuery(#1j.#oe);
			return true;
		}

		public List<iMixConfigurationLocationInfo> GetLocationWiseConfigParams(int SubStoreId)
		{
			base.DBParameters.Clear();
			if (!false)
			{
				base.AddParameter(ConfigurationDao.getConfigurationDao (12329), SubStoreId);
			}
			IDataReader dataReader=null;
			List<iMixConfigurationLocationInfo> result;
			if (!false)
			{
				//dataReader = base.ExecuteReader(#1j.#yj);
				if (3 != 0)
				{
					result = this.iMixConfigurationLocationInfoxb(dataReader);
				}
			}
			dataReader.Close();
			return result;
		}

		public void DeleteLocationWiseConfigParams(int LocationId)
		{
			while (true)
			{
				base.DBParameters.Clear();
				while (8 != 0)
				{
					base.AddParameter(ConfigurationDao.getConfigurationDao(12354), LocationId);
					if (7 != 0)
					{
                        //base.ExecuteScalar(#1j.#zj);
                        //if (!false)
                        //{
                        //    return;
                        //}
						break;
					}
				}
			}
		}

		private List<iMixConfigurationLocationInfo> iMixConfigurationLocationInfoxb(IDataReader IDataReader)
		{
			if (3 == 0)
			{
				goto IL_22;
			}
			List<iMixConfigurationLocationInfo> list = new List<iMixConfigurationLocationInfo>();
			IL_0D:
			goto IL_B0;
			IL_22:
			iMixConfigurationLocationInfo iMixConfigurationLocationInfo;
			iMixConfigurationLocationInfo.IMIXConfigurationMasterId = base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(10366), 0L);
			IL_4C:
			iMixConfigurationLocationInfo.ConfigurationValue = base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(10403), string.Empty);
			iMixConfigurationLocationInfo.LocationId = base.GetFieldValue(IDataReader,         ConfigurationDao.getConfigurationDao(12371), 0);
			iMixConfigurationLocationInfo.SubstoreId = base.GetFieldValue(IDataReader,         ConfigurationDao.getConfigurationDao(10428), 0);
			iMixConfigurationLocationInfo item = iMixConfigurationLocationInfo;
			list.Add(item);
			IL_B0:
			if (!IDataReader.Read())
			{
				return list;
			}
			if (6 == 0)
			{
				goto IL_0D;
			}
			if (3 != 0)
			{
				iMixConfigurationLocationInfo = new iMixConfigurationLocationInfo();
				goto IL_22;
			}
			goto IL_4C;
		}

		public List<iMIXStoreConfigurationInfo> GetAllReportConfiguration()
		{
			List<iMIXStoreConfigurationInfo> result;
			while (!false)
			{
				base.DBParameters.Clear();
				IDataReader dataReader;
				if (7 != 0)
				{
					base.OpenConnection();
					dataReader = base.ExecuteReader(ConfigurationDao.getConfigurationDao(12388));
					if (false)
					{
						continue;
					}
					result = this.iMIXStoreConfigurationInfoyb(dataReader);
				}
				dataReader.Close();
				break;
			}
			return result;
		}

		private List<iMIXStoreConfigurationInfo> iMIXStoreConfigurationInfoyb(IDataReader IDataReader)
		{
			if (3 == 0)
			{
				goto IL_22;
			}
			List<iMIXStoreConfigurationInfo> list = new List<iMIXStoreConfigurationInfo>();
			IL_0D:
			goto IL_B4;
			IL_22:
			iMIXStoreConfigurationInfo iMIXStoreConfigurationInfo;
			iMIXStoreConfigurationInfo.IMIXConfigurationMasterId = base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao (10366), 0L);
			IL_4C:
			iMIXStoreConfigurationInfo.ConfigurationValue = base.GetFieldValue(IDataReader,         ConfigurationDao.getConfigurationDao(10403), string.Empty);
			iMIXStoreConfigurationInfo.SyncCode = base.GetFieldValue(IDataReader,                   ConfigurationDao.getConfigurationDao(1978), string.Empty);
			iMIXStoreConfigurationInfo.IsSynced = base.GetFieldValue(IDataReader,                   ConfigurationDao.getConfigurationDao(1991), false);
			iMIXStoreConfigurationInfo item = iMIXStoreConfigurationInfo;
			list.Add(item);
			IL_B4:
			if (!IDataReader.Read())
			{
				return list;
			}
			if (6 == 0)
			{
				goto IL_0D;
			}
			if (3 != 0)
			{
				iMIXStoreConfigurationInfo = new iMIXStoreConfigurationInfo();
				goto IL_22;
			}
			goto IL_4C;
		}

		public List<ReportTypeDetails> GetReportTypes()
		{
			List<ReportTypeDetails> result;
			if (-1 != 0)
			{
				base.DBParameters.Clear();
				IDataReader dataReader = base.ExecuteReader(ConfigurationDao.getConfigurationDao(12425));
				try
				{
					result = this.ReportTypeDetailszb(dataReader);
				}
				finally
				{
					if (!false && !false && (-1 == 0 || dataReader != null))
					{
						dataReader.Dispose();
					}
				}
			}
			return result;
		}

		private List<ReportTypeDetails> ReportTypeDetailszb(IDataReader IDataReader)
		{
			List<ReportTypeDetails> list = new List<ReportTypeDetails>();
			while (IDataReader.Read())
			{
				ReportTypeDetails item = new ReportTypeDetails
				{
					Id = base.GetFieldValue(IDataReader,             ConfigurationDao.getConfigurationDao(12446), 0),
					ReportTypeName = base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(12451), string.Empty),
					IsActive = base.GetFieldValue(IDataReader,       ConfigurationDao.getConfigurationDao(3078), false),
					ReportLabel = base.GetFieldValue(IDataReader,    ConfigurationDao.getConfigurationDao(12468), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public bool InsertReportConfig(DataTable dt)
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
				base.AddParameter(ConfigurationDao.getConfigurationDao(12485), dt);
			}
			if (2 != 0)
			{
				base.ExecuteNonQuery(ConfigurationDao.getConfigurationDao (12502));
			}
			return true;
		}

		public bool SaveExportReportLogDetails(ExportServiceLog exportServiceLog)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigurationDao.getConfigurationDao(12535), exportServiceLog.EventTime);
			if (!false)
			{
				base.AddParameter(ConfigurationDao.getConfigurationDao (12552), exportServiceLog.ReportType);
			}
			base.AddParameter(   ConfigurationDao.getConfigurationDao(12569), exportServiceLog.ReportSent);
			base.AddParameter(   ConfigurationDao.getConfigurationDao(12586), exportServiceLog.ErrorDetails);
			base.AddParameter(   ConfigurationDao.getConfigurationDao(12607), exportServiceLog.ExportFile);
			base.AddParameter(   ConfigurationDao.getConfigurationDao(12620), exportServiceLog.ExportPath);
			base.ExecuteNonQuery(ConfigurationDao.getConfigurationDao(12637));
			return true;
		}

		public List<ExportServiceLog> GetExportServiceLogs()
		{
			List<ExportServiceLog> result;
			if (-1 != 0)
			{
				base.DBParameters.Clear();
				IDataReader dataReader = base.ExecuteReader(ConfigurationDao.getConfigurationDao (12674));
				try
				{
					result = this.ExportServiceLogAb(dataReader);
				}
				finally
				{
					if (!false && !false && (-1 == 0 || dataReader != null))
					{
						dataReader.Dispose();
					}
				}
			}
			return result;
		}

		private List<ExportServiceLog> ExportServiceLogAb(IDataReader IDataReader)
		{
			List<ExportServiceLog> list = new List<ExportServiceLog>();
			while (IDataReader.Read())
			{
				ExportServiceLog item = new ExportServiceLog
				{
					EventTime = base.GetFieldValue(IDataReader,    ConfigurationDao.getConfigurationDao(12699), DateTime.Now),
					ErrorDetails = base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(12716), string.Empty),
					ExportFile = base.GetFieldValue(IDataReader,   ConfigurationDao.getConfigurationDao(12733), string.Empty),
					ExportPath = base.GetFieldValue(IDataReader,   ConfigurationDao.getConfigurationDao(12750), string.Empty),
					ReportSent = base.GetFieldValue(IDataReader,   ConfigurationDao.getConfigurationDao(12767), false),
					ReportType = base.GetFieldValue(IDataReader,   ConfigurationDao.getConfigurationDao(12451), string.Empty)
				};
				list.Add(item);
			}
			return list;
		}

		public bool UpdateReportTypes(List<ReportTypeDetails> reportTypes)
		{
			foreach (ReportTypeDetails current in reportTypes)
			{
				base.DBParameters.Clear();
				base.AddParameter(   ConfigurationDao.getConfigurationDao(12784), current.Id);
				base.AddParameter(   ConfigurationDao.getConfigurationDao(12797), current.IsActive);
				base.ExecuteNonQuery(ConfigurationDao.getConfigurationDao(12810));
			}
			return true;
		}

		public bool CheckDummyScan(long photographerID)
		{
			bool expr_3B;
			do
			{
				bool flag;
				while (true)
				{
					base.DBParameters.Clear();
					if (!false)
					{
						base.AddParameter(ConfigurationDao.getConfigurationDao(12835), photographerID);
					}
					while (!false)
					{
						flag =false; //Convert.ToBoolean(base.ExecuteScalar(#1j.#lf));
						if (true)
						{
							goto Block_3;
						}
					}
				}
				Block_3:
				bool arg_40_0;
				expr_3B = (arg_40_0 = flag);
			}
			while (false);
			return expr_3B;
		}

		public string GetSubStoreNameBySuubStoreId(int subStoreId)
		{
			string result;
			while (true)
			{
				IL_00:
				result = string.Empty;
				while (!false)
				{
					base.DBParameters.Clear();
					base.AddParameter(ConfigurationDao.getConfigurationDao(12856), subStoreId);
					if (2 == 0)
					{
						goto IL_7C;
					}
					if (false)
					{
						goto IL_00;
					}
					if (-1 != 0)
					{
						//goto Block_3;
					}
				}
				goto IL_84;
			}
			IL_7C:
			IDataReader dataReader=null;
			while (dataReader.Read())
			{
				if (!false)
				{
					result = base.GetFieldValue(dataReader, ConfigurationDao.getConfigurationDao(12873), string.Empty);
				}
			}
			goto IL_84;
			//Block_3:
            //dataReader = base.ExecuteReader(#1j.#mf);
            //goto IL_7C;
			IL_84:
			dataReader.Close();
			return result;
		}

		public void DeleteLocationWiseConfigParamsGumbleRide(int LocationId)
		{
			do
			{
				base.DBParameters.Clear();
				string expr_50 = ConfigurationDao.getConfigurationDao(12354);
				object expr_16 = LocationId;
				if (!false)
				{
					base.AddParameter(expr_50, expr_16);
				}
				if (true)
				{
					base.ExecuteScalar(ConfigurationDao.getConfigurationDao(12898));
				}
			}
			while (7 == 0);
		}

		public bool IsLocationRFIDEnabled(int locationId)
		{
			if (-1 == 0)
			{
				goto IL_45;
			}
			int arg_4D_0 = 0;
			IL_04:
			bool flag;
			if (4 != 0)
			{
				flag = (arg_4D_0 != 0);
			}
			IL_08:
			base.DBParameters.Clear();
			string expr_64 = ConfigurationDao.getConfigurationDao(12947);
			object expr_1E = locationId;
			if (!false)
			{
				base.AddParameter(expr_64, expr_1E);
			}
			flag = Convert.ToBoolean(base.ExecuteScalar(ConfigurationDao.getConfigurationDao(12964)));
			IL_45:
			if (5 == 0)
			{
				goto IL_08;
			}
			bool expr_48 = (arg_4D_0 = (flag ? 1 : 0)) != 0;
			if (!false)
			{
				return expr_48;
			}
			goto IL_04;
		}

		public List<ConfigurationInfo> GetDeafultPathlist()
		{
			List<ConfigurationInfo> result = new List<ConfigurationInfo>();
			do
			{
				base.DBParameters.Clear();
				if (!false)
				{
					base.OpenConnection();
					if (-1 == 0)
					{
						continue;
					}
                    //using (IDataReader dataReader = base.ExecuteReader(#1j.#6e))
                    //{
                    //    result = this.ConfigurationInfomWb(dataReader);
                    //    dataReader.Close();
                    //}
				}
			}
			while (4 == 0);
			return result;
		}

		private List<ConfigurationInfo> ConfigurationInfomWb(IDataReader IDataReader)
		{
			List<ConfigurationInfo> list = new List<ConfigurationInfo>();
			new ConfigurationInfo();
			while (IDataReader.Read())
			{
				ConfigurationInfo configurationInfo = new ConfigurationInfo();
				configurationInfo.DG_Config_pkey = base.GetFieldValue(IDataReader,                      ConfigurationDao.getConfigurationDao(8413), 0);
				configurationInfo.DG_Hot_Folder_Path = base.GetFieldValue(IDataReader,                  ConfigurationDao.getConfigurationDao(8434), string.Empty);
				configurationInfo.DG_Frame_Path = base.GetFieldValue(IDataReader,                       ConfigurationDao.getConfigurationDao(8459), string.Empty);
				configurationInfo.DG_BG_Path = base.GetFieldValue(IDataReader,                          ConfigurationDao.getConfigurationDao(8480), string.Empty);
				configurationInfo.DG_Mod_Password = base.GetFieldValue(IDataReader,                     ConfigurationDao.getConfigurationDao(8497), string.Empty);
				configurationInfo.DG_NoOfPhotos = new int?(base.GetFieldValue(IDataReader,              ConfigurationDao.getConfigurationDao(8518), 0));
				configurationInfo.DG_Watermark = new bool?(base.GetFieldValue(IDataReader,              ConfigurationDao.getConfigurationDao(8539), false));
				configurationInfo.DG_SemiOrder = new bool?(base.GetFieldValue(IDataReader,              ConfigurationDao.getConfigurationDao(8556), false));
				configurationInfo.DG_HighResolution = new bool?(base.GetFieldValue(IDataReader,         ConfigurationDao.getConfigurationDao(8573), false));
				configurationInfo.DG_AllowDiscount = new bool?(base.GetFieldValue(IDataReader,          ConfigurationDao.getConfigurationDao(8598), false));
				configurationInfo.DG_EnableDiscountOnTotal = new bool?(base.GetFieldValue(IDataReader,  ConfigurationDao.getConfigurationDao(8623), false));
				configurationInfo.WiFiStartingNumber = new decimal?(base.GetFieldValue(IDataReader,     ConfigurationDao.getConfigurationDao(8656), 0.0m));
				configurationInfo.FolderStartingNumber = new decimal?(base.GetFieldValue(IDataReader,   ConfigurationDao.getConfigurationDao(8681), 0.0m));
				configurationInfo.IsAutoLock = new bool?(base.GetFieldValue(IDataReader,                ConfigurationDao.getConfigurationDao(8710), false));
				configurationInfo.DG_SemiOrderMain = new bool?(base.GetFieldValue(IDataReader,          ConfigurationDao.getConfigurationDao(8727), false));
				configurationInfo.PosOnOff = new bool?(base.GetFieldValue(IDataReader,                  ConfigurationDao.getConfigurationDao(8752), false));
				configurationInfo.DG_ReceiptPrinter = base.GetFieldValue(IDataReader,                   ConfigurationDao.getConfigurationDao(8765), string.Empty);
				configurationInfo.DG_IsAutoRotate = new bool?(base.GetFieldValue(IDataReader,           ConfigurationDao.getConfigurationDao(8790), false));
				configurationInfo.DG_Graphics_Path = base.GetFieldValue(IDataReader,                    ConfigurationDao.getConfigurationDao(8811), string.Empty);
				configurationInfo.DG_IsCompression = new bool?(base.GetFieldValue(IDataReader,          ConfigurationDao.getConfigurationDao(8836), false));
				configurationInfo.DG_IsEnableGroup = new bool?(base.GetFieldValue(IDataReader,          ConfigurationDao.getConfigurationDao(8861), false));
				configurationInfo.DG_Substore_Id = new int?(base.GetFieldValue(IDataReader,             ConfigurationDao.getConfigurationDao(8886), 0));
				if (!false)
				{
					configurationInfo.DG_NoOfBillReceipt = new int?(base.GetFieldValue(IDataReader,     ConfigurationDao.getConfigurationDao(8907), 0));
					configurationInfo.DG_ChromaColor = base.GetFieldValue(IDataReader,                  ConfigurationDao.getConfigurationDao(8932), string.Empty);
					configurationInfo.DG_ChromaTolerance = new decimal?(base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(8953), 0.0m));
					configurationInfo.DG_DbBackupPath = base.GetFieldValue(IDataReader,                 ConfigurationDao.getConfigurationDao(8978), string.Empty);
					configurationInfo.DG_CleanupTables = base.GetFieldValue(IDataReader,                ConfigurationDao.getConfigurationDao(8999), string.Empty);
					goto IL_3D8;
				}
				IL_512:
				configurationInfo.IntervalCount = new int?(base.GetFieldValue(IDataReader,      ConfigurationDao.getConfigurationDao(9237), 0));
				configurationInfo.intervalType = new int?(base.GetFieldValue(IDataReader,       ConfigurationDao.getConfigurationDao(9258), 0));
				configurationInfo.DG_MktImgPath = base.GetFieldValue(IDataReader,               ConfigurationDao.getConfigurationDao(9275), string.Empty);
				configurationInfo.DG_MktImgTimeInSec = new int?(base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(9296), 0));
				configurationInfo.EK_SampleImagePath = base.GetFieldValue(IDataReader,          ConfigurationDao.getConfigurationDao(9321), string.Empty);
				if (!false)
				{
					configurationInfo.EK_DisplayDuration = new int?(base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(9346), 0));
					configurationInfo.EK_ScreenStartTime = new int?(base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(9371), 0));
					configurationInfo.EK_IsScreenSaverActive = new bool?(base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(9396), false));
					configurationInfo.IsDeleteFromUSB = new bool?(base.GetFieldValue(IDataReader,        ConfigurationDao.getConfigurationDao(9429), false));
					configurationInfo.DG_CleanUpDaysBackUp = new int?(base.GetFieldValue(IDataReader,    ConfigurationDao.getConfigurationDao(9450), 0));
					configurationInfo.FtpIP = base.GetFieldValue(IDataReader,  ConfigurationDao.getConfigurationDao(9512), string.Empty);
					configurationInfo.FtpUid = base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(9521), string.Empty);
					configurationInfo.FtpPwd = base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(9530), string.Empty);
					configurationInfo.FtpFolder = base.GetFieldValue(IDataReader, ConfigurationDao.getConfigurationDao(9539), string.Empty);
					ConfigurationInfo item = configurationInfo;
					list.Add(item);
					continue;
				}
				IL_3D8:
				configurationInfo.DG_HfBackupPath = base.GetFieldValue(IDataReader,                    ConfigurationDao.getConfigurationDao(9024), string.Empty);
				configurationInfo.DG_ScheduleBackup = base.GetFieldValue(IDataReader,                  ConfigurationDao.getConfigurationDao(9045), string.Empty);
				configurationInfo.DG_IsBackupScheduled = new bool?(base.GetFieldValue(IDataReader,     ConfigurationDao.getConfigurationDao(9070), false));
				configurationInfo.DG_Brightness = new double?((double)base.GetFieldValue(IDataReader,  ConfigurationDao.getConfigurationDao(9099), 0f));
				configurationInfo.DG_Contrast = new double?((double)base.GetFieldValue(IDataReader,    ConfigurationDao.getConfigurationDao(9120), 0f));
				configurationInfo.DG_PageCountGrid = new int?(base.GetFieldValue(IDataReader,          ConfigurationDao.getConfigurationDao(9137), 0));
				configurationInfo.DG_PageCountPreview = new int?(base.GetFieldValue(IDataReader,       ConfigurationDao.getConfigurationDao(9162), 0));
				configurationInfo.DG_NoOfPhotoIdSearch = new int?(base.GetFieldValue(IDataReader,      ConfigurationDao.getConfigurationDao(9191), 0));
				configurationInfo.IsRecursive = new bool?(base.GetFieldValue(IDataReader,              ConfigurationDao.getConfigurationDao(9220), false));
				goto IL_512;
			}
			return list;
		}

		public List<iMixConfigurationLocationInfo> GetAllLocationWiseConfigParams()
		{
			base.DBParameters.Clear();
			IDataReader dataReader=null;
			if (8 != 0)
			{
				//dataReader = base.ExecuteReader(#1j.#uWb);
			}
			List<iMixConfigurationLocationInfo> result = this.iMixConfigurationLocationInfoxb(dataReader);
			dataReader.Close();
			return result;
		}

		static ConfigurationDao()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ConfigurationDao));
		}
	}
}
