//using DigiPhoto.Utility.Repository.ValueType;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace PhotoSW.IMIX.Business
{
	public static class ConfigManager
	{
		private static Dictionary<long, string> Dic_SOH;

		private static int STX;

		private static string ETX;

		internal static SmartAssembly.Delegates.GetString getConfigManager;

		public static Dictionary<long, string> IMIXConfigurations
		{
			get
			{
				if (ConfigManager.Dic_SOH.Count == 0)
				{
					ConfigBusiness configBusiness = new ConfigBusiness();
					//ConfigManager.Dic_SOH = configBusiness.GetConfigurations(ConfigManager.Dic_SOH, ConfigManager.SubStoreId);
				}
				return ConfigManager.Dic_SOH;
			}
			set
			{
				ConfigManager.Dic_SOH = value;
			}
		}

		public static int SubStoreId
		{
			get
			{
				string directoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				if (File.Exists(directoryName + ConfigManager.getConfigManager (1343)))
				{
					using (StreamReader streamReader = new StreamReader(directoryName + ConfigManager.getConfigManager (1343)))
					{
						string cipherString = streamReader.ReadLine();
						string text = CryptorEngine.Decrypt(cipherString, true);
						if (!false)
						{
                            //ConfigManager.STX = text.Split(new char[]
                            //{
                            //    ','
                            //})[0].ToInt32(false);
                            ConfigManager.STX =Convert .ToInt32( text.Split(new char[]
                            {
                                ','
                            })[0]);
							if (ConfigManager.STX == 0)
							{
								throw new Exception(ConfigManager.getConfigManager (1356));
							}
						}
					}
				}
				return ConfigManager.STX;
			}
			set
			{
				ConfigManager.STX = value;
			}
		}

		public static string DigiFolderPath
		{
			get
			{
				ConfigBusiness configBusiness = new ConfigBusiness();
				//ConfigManager.ETX = configBusiness.GetHotFolderPath(ConfigManager.SubStoreId);
				return ConfigManager.ETX;
			}
			set
			{
				ConfigManager.ETX = value;
			}
		}

		static ConfigManager()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ConfigManager));
			ConfigManager.Dic_SOH = new Dictionary<long, string>();
		}
	}
}
