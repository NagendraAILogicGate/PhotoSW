using PhotoSW.IMIX.Model;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PhotoSW.IMIX.DataAccess
{
	public class ConfigAccess : BaseDataAccess
	{
		  internal static SmartAssembly.Delegates.GetString getConfigAccess;

		public ConfigAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public ConfigAccess()
		{
		}

		public bool SaveUpdateNewConfig(DataTable dt)
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
				base.AddParameter(ConfigAccess.getConfigAccess(12514), dt);
			}
			if (2 != 0)
			{
				base.ExecuteNonQuery(ConfigAccess.getConfigAccess (31374));
			}
			return true;
		}

		public bool SaveUpdateNewStoreConfig(DataTable dt)
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
				base.AddParameter(ConfigAccess.getConfigAccess(12514), dt);
			}
			if (2 != 0)
			{
				base.ExecuteNonQuery(ConfigAccess.getConfigAccess (12531));
			}
			return true;
		}

		public bool SaveUpdatePreviewDummyTag(iMIXStoreConfigurationInfo objImixStoreInfo)
		{
			while (!false)
			{
				base.DBParameters.Clear();
				if (7 != 0)
				{
					base.AddParameter(ConfigAccess.getConfigAccess(31403), objImixStoreInfo.iMIXStoreConfigurationValueId);
					break;
				}
			}
			base.AddParameter(ConfigAccess.getConfigAccess (31444), objImixStoreInfo.ConfigurationValue);
			do
			{
				base.AddParameter(ConfigAccess.getConfigAccess (31473), objImixStoreInfo.IMIXConfigurationMasterId);
			}
			while (4 == 0);
			base.AddOutParameter(ConfigAccess.getConfigAccess (31510), SqlDbType.Bit);
			base.ExecuteReader(ConfigAccess.getConfigAccess (31527));
			return Convert.ToBoolean(base.GetOutParameterValue(ConfigAccess.getConfigAccess(31510)));
		}

		public bool DeletePreviewDummyTag(long iMIXStoreConfigurationValueId)
		{
			base.DBParameters.Clear();
			base.AddParameter(   ConfigAccess.getConfigAccess(31403), iMIXStoreConfigurationValueId);
			base.ExecuteNonQuery(ConfigAccess.getConfigAccess(31564));
			return true;
		}

		public List<iMIXConfigurationInfo> GetConfigurations(int subStoreId)
		{
			List<iMIXConfigurationInfo> result=null;
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
					base.AddParameter(ConfigAccess.getConfigAccess(12885), subStoreId);
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
				IDataReader dataReader=null;
				if (-1 != 0)
				{
					dataReader.Close();
					goto IL_4A;
				}
				IL_25:
				dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(31593));
				result = this.iMIXConfigurationInford(dataReader);
				goto IL_41;
			}
			return result;
		}

		public string GetHotFolderPath(int SubStoreId)
		{
			if (true)
			{
				base.DBParameters.Clear();
				base.AddParameter(ConfigAccess.getConfigAccess (25098), SubStoreId);
			}
			return base.ExecuteScalar(ConfigAccess.getConfigAccess (31618)).ToString();
		}

		public bool SaveUpdateConfigLocation(DataTable dt)
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
				base.AddParameter(ConfigAccess.getConfigAccess(31643), dt);
			}
			if (2 != 0)
			{
				base.ExecuteNonQuery(ConfigAccess.getConfigAccess (31664));
			}
			return true;
		}

		public List<iMixConfigurationLocationInfo> GetConfigLocation(int LocationId, int SubstoreId)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigAccess.getConfigAccess(12885), SubstoreId);
			base.AddParameter(ConfigAccess.getConfigAccess(7270), LocationId);
			IDataReader dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(31697));
			List<iMixConfigurationLocationInfo> result = this.iMixConfigurationLocationInfosd(dataReader);
			dataReader.Close();
			return result;
		}

		public List<iMixConfigurationLocationInfo> GetConfigBasedOnLocation(int LocationId)
		{
			List<iMixConfigurationLocationInfo> result;
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
					base.AddParameter(ConfigAccess.getConfigAccess (7270), LocationId);
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
				dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess (31730));
				result = this.iMixConfigurationLocationInfosd(dataReader);
				goto IL_41;
			}
			return result;
		}

		public FolderStructureInfo GetFolderStructureInfo(int subStoreId)
		{
			FolderStructureInfo result;
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
					base.AddParameter(ConfigAccess.getConfigAccess(12885), subStoreId);
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
				dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess (31759));
				result = this.FolderStructureInfoqd(dataReader);
				goto IL_41;
			}
			return result;
		}

		private FolderStructureInfo FolderStructureInfoqd(IDataReader IDataReader)
		{
			FolderStructureInfo folderStructureInfo = new FolderStructureInfo();
			do
			{
				while (true)
				{
					if (!IDataReader.Read())
					{
						if (!false)
						{
							break;
						}
					}
					else
					{
						folderStructureInfo.HotFolderPath = base.GetFieldValue(IDataReader,  ConfigAccess.getConfigAccess(21181), string.Empty);
						folderStructureInfo.BorderPath = base.GetFieldValue(IDataReader,     ConfigAccess.getConfigAccess(31792), string.Empty);
						folderStructureInfo.BackgroundPath = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(31809), string.Empty);
						folderStructureInfo.GraphicPath = base.GetFieldValue(IDataReader,    ConfigAccess.getConfigAccess(31830), string.Empty);
					}
					folderStructureInfo.CroppedPath = base.GetFieldValue(IDataReader,       ConfigAccess.getConfigAccess(31847), string.Empty);
					folderStructureInfo.EditedImagePath = base.GetFieldValue(IDataReader,   ConfigAccess.getConfigAccess(31864), string.Empty);
					folderStructureInfo.ThumbnailsPath = base.GetFieldValue(IDataReader,    ConfigAccess.getConfigAccess(31885), string.Empty);
					folderStructureInfo.BigThumbnailsPath = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(31906), string.Empty);
					folderStructureInfo.PrintImagesPath = base.GetFieldValue(IDataReader,   ConfigAccess.getConfigAccess(31931), string.Empty);
				}
			}
			while (8 == 0);
			return folderStructureInfo;
		}

		private List<iMIXConfigurationInfo> iMIXConfigurationInford(IDataReader IDataReader)
		{
			List<iMIXConfigurationInfo> list = new List<iMIXConfigurationInfo>();
			while (IDataReader.Read())
			{
				list.Add(new iMIXConfigurationInfo
				{
					IMIXConfigurationValueId = base.GetFieldValue(IDataReader,  ConfigAccess.getConfigAccess(10362), 0L),
					IMIXConfigurationMasterId = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(10395), 0L),
					ConfigurationValue = base.GetFieldValue(IDataReader,        ConfigAccess.getConfigAccess(10432), string.Empty),
					SubstoreId = base.GetFieldValue(IDataReader,                ConfigAccess.getConfigAccess(10457), 0)
				});
			}
			return list;
		}

		private List<iMixConfigurationLocationInfo> iMixConfigurationLocationInfosd(IDataReader IDataReader)
		{
			List<iMixConfigurationLocationInfo> list = new List<iMixConfigurationLocationInfo>();
			while (IDataReader.Read())
			{
				iMixConfigurationLocationInfo iMixConfigurationLocationInfo = new iMixConfigurationLocationInfo();
				iMixConfigurationLocationInfo.IMIXConfigurationValueId = base.GetFieldValue(IDataReader,  ConfigAccess.getConfigAccess(31952), 0L);
				iMixConfigurationLocationInfo.IMIXConfigurationMasterId = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(31981), 0L);
				if (!false)
				{
					iMixConfigurationLocationInfo.ConfigurationValue = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(10432), string.Empty);
					iMixConfigurationLocationInfo.SubstoreId = base.GetFieldValue(IDataReader,         ConfigAccess.getConfigAccess(10457), 0);
					iMixConfigurationLocationInfo.LocationId = base.GetFieldValue(IDataReader,         ConfigAccess.getConfigAccess(12400), 0);
				}
				list.Add(iMixConfigurationLocationInfo);
			}
			return list;
		}

		public bool UpdateTriggerStatus(DataTable dtValues)
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
				base.AddParameter(ConfigAccess.getConfigAccess(32010), dtValues);
			}
			if (2 != 0)
			{
				base.ExecuteNonQuery(ConfigAccess.getConfigAccess (32043));
			}
			return true;
		}

		public List<SyncTriggerStatusInfo> GetAllSyncTriggerTables()
		{
			base.DBParameters.Clear();
			IDataReader dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(32072));
			List<SyncTriggerStatusInfo> result;
			do
			{
				result = this.SyncTriggerStatusInfotd(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		private List<SyncTriggerStatusInfo> SyncTriggerStatusInfotd(IDataReader IDataReader)
		{
			List<SyncTriggerStatusInfo> list = new List<SyncTriggerStatusInfo>();
			IL_94:
			while (IDataReader.Read())
			{
				SyncTriggerStatusInfo syncTriggerStatusInfo;
				do
				{
					if (true)
					{
						syncTriggerStatusInfo = new SyncTriggerStatusInfo();
						if (false)
						{
							goto IL_94;
						}
						syncTriggerStatusInfo.TableId = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess (32105), 0L);
					}
				}
				while (false);
				syncTriggerStatusInfo.TableName = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess (32118), string.Empty);
				syncTriggerStatusInfo.IsSyncTriggerEnable = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess (32131), true);
				if (5 != 0)
				{
					list.Add(syncTriggerStatusInfo);
				}
			}
			return list;
		}

		public bool SaveUpdateAudioTemplate(AudioTemplateInfo list)
		{
			while (true)
			{
				base.DBParameters.Clear();
				base.AddParameter(ConfigAccess.getConfigAccess (32160), list.AudioTemplateId);
				if (8 != 0)
				{
					base.AddParameter(ConfigAccess.getConfigAccess (32185), list.Name);
					goto IL_59;
				}
				do
				{
					IL_74:
					base.AddParameter(ConfigAccess.getConfigAccess(32211), list.Description);
					base.AddParameter(ConfigAccess.getConfigAccess(31332), list.CreatedBy);
				}
				while (7 == 0);
				base.AddParameter(ConfigAccess.getConfigAccess (32228), list.CreatedOn);
				if (false)
				{
					continue;
				}
				base.AddParameter(ConfigAccess.getConfigAccess(32245), list.ModifiedBy);
				if (!false)
				{
					break;
				}
				IL_59:
				base.AddParameter( ConfigAccess.getConfigAccess(32194), list.DisplayName);
				//goto IL_74;
			}
			base.AddParameter(     ConfigAccess.getConfigAccess(32262), list.ModifiedOn);
			base.AddParameter(     ConfigAccess.getConfigAccess(27476), list.IsActive);
			base.AddParameter(     ConfigAccess.getConfigAccess(32279), list.AudioLength);
			base.ExecuteNonQuery(  ConfigAccess.getConfigAccess(32296));
			return true;
		}

		public List<AudioTemplateInfo> GetAudioTemplateList(long AudioTemplateId)
		{
			List<AudioTemplateInfo> result;
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
					base.AddParameter(ConfigAccess.getConfigAccess (32160), AudioTemplateId);
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
                dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(32329));
				result = this.AudioTemplateInfoud(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<AudioTemplateInfo> AudioTemplateInfoud(IDataReader IDataReader)
		{
			List<AudioTemplateInfo> expr_1AF = new List<AudioTemplateInfo>();
			List<AudioTemplateInfo> list;
			if (7 != 0)
			{
				list = expr_1AF;
			}
			while (IDataReader.Read())
			{
				AudioTemplateInfo audioTemplateInfo;
				do
				{
					if (!false)
					{
						AudioTemplateInfo expr_1BF = new AudioTemplateInfo();
						if (4 != 0)
						{
							audioTemplateInfo = expr_1BF;
						}
						audioTemplateInfo.AudioTemplateId = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(32362), 0L);
						audioTemplateInfo.Name = base.GetFieldValue(IDataReader,            ConfigAccess.getConfigAccess(549), string.Empty);
						audioTemplateInfo.Description = base.GetFieldValue(IDataReader,     ConfigAccess.getConfigAccess(3133), string.Empty);
						audioTemplateInfo.DisplayName = base.GetFieldValue(IDataReader,     ConfigAccess.getConfigAccess(3073), string.Empty);
						audioTemplateInfo.CreatedOn = base.GetFieldValue(IDataReader,       ConfigAccess.getConfigAccess(3150), DateTime.Now);
						audioTemplateInfo.CreatedBy = base.GetFieldValue(IDataReader,       ConfigAccess.getConfigAccess(2872), 0);
						audioTemplateInfo.ModifiedOn = base.GetFieldValue(IDataReader,      ConfigAccess.getConfigAccess(3163), DateTime.Now);
						audioTemplateInfo.ModifiedBy = base.GetFieldValue(IDataReader,      ConfigAccess.getConfigAccess(2885), 0);
						audioTemplateInfo.IsActive = base.GetFieldValue(IDataReader,        ConfigAccess.getConfigAccess(3107), false);
						audioTemplateInfo.IsActiveDisplay = (audioTemplateInfo.IsActive ?   ConfigAccess.getConfigAccess(32396) : ConfigAccess.getConfigAccess(32383));
					}
				}
				while (4 == 0);
				audioTemplateInfo.AudioLength = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess (32405), 0L);
				list.Add(audioTemplateInfo);
			}
			return list;
		}

		public bool DeleteAudio(long AudioTemplateId)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigAccess.getConfigAccess (32160), AudioTemplateId);
			base.ExecuteNonQuery(ConfigAccess.getConfigAccess (32422));
			return true;
		}

		public bool SaveVideoTemplate(VideoTemplateInfo videoTemplate)
		{
			while (true)
			{
				base.DBParameters.Clear();
				base.AddParameter(ConfigAccess.getConfigAccess (32447), videoTemplate.VideoTemplateId);
				if (8 != 0)
				{
					base.AddParameter(ConfigAccess.getConfigAccess (32185), videoTemplate.Name);
					goto IL_59;
				}
				do
				{
					IL_74:
					base.AddParameter(ConfigAccess.getConfigAccess(32211), videoTemplate.Description);
					base.AddParameter(ConfigAccess.getConfigAccess(31332), videoTemplate.CreatedBy);
				}
				while (7 == 0);
				base.AddParameter(ConfigAccess.getConfigAccess (32228), videoTemplate.CreatedOn);
				if (false)
				{
					continue;
				}
				base.AddParameter(ConfigAccess.getConfigAccess(32245), videoTemplate.ModifiedBy);
				if (!false)
				{
					break;
				}
				IL_59:
				base.AddParameter(ConfigAccess.getConfigAccess (32194), videoTemplate.DisplayName);
				//goto IL_74;
			}
			base.AddParameter(ConfigAccess.getConfigAccess(32262), videoTemplate.ModifiedOn);
			base.AddParameter(ConfigAccess.getConfigAccess(27476), videoTemplate.IsActive);
			base.AddParameter(ConfigAccess.getConfigAccess(32472), videoTemplate.VideoLength);
			base.ExecuteNonQuery(ConfigAccess.getConfigAccess (32489));
			return true;
		}

		public bool SaveVideoSlot(VideoTemplateInfo videoTemplate)
		{
			DataTable dataTable = new DataTable();
			dataTable.Columns.Add(ConfigAccess.getConfigAccess(32514));
			dataTable.Columns.Add(ConfigAccess.getConfigAccess(32531));
			dataTable.Columns.Add(ConfigAccess.getConfigAccess(32548));
			using (List<VideoTemplateInfo.VideoSlot>.Enumerator enumerator = videoTemplate.videoSlots.GetEnumerator())
			{
				while (true)
				{
					if (!enumerator.MoveNext())
					{
						if (true)
						{
							break;
						}
					}
					else
					{
						VideoTemplateInfo.VideoSlot current = enumerator.Current;
						dataTable.Rows.Add(new object[]
						{
							current.VideoSlotId,
							current.FrameTimeIn,
							current.PhotoDisplayTime
						});
					}
				}
			}
			base.DBParameters.Clear();
			base.AddParameter(ConfigAccess.getConfigAccess(32447), videoTemplate.VideoTemplateId);
			base.AddParameter(ConfigAccess.getConfigAccess(32573), dataTable);
			base.ExecuteNonQuery(ConfigAccess.getConfigAccess (32598));
			return true;
		}

		public List<VideoTemplateInfo> GetVideoTemplate(long VideoTemplateId)
		{
			List<VideoTemplateInfo> result;
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
					base.AddParameter(ConfigAccess.getConfigAccess(32447), VideoTemplateId);
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
				dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(32619));
				result = this.VideoTemplateInfovd(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<VideoTemplateInfo> VideoTemplateInfovd(IDataReader IDataReader)
		{
			List<VideoTemplateInfo> list = new List<VideoTemplateInfo>();
			while (IDataReader.Read())
			{
				VideoTemplateInfo videoTemplateInfo = new VideoTemplateInfo();
				videoTemplateInfo.VideoTemplateId = base.GetFieldValue(IDataReader,          ConfigAccess.getConfigAccess(32644), 0L);
				videoTemplateInfo.Name = base.GetFieldValue(IDataReader,                     ConfigAccess.getConfigAccess(549), string.Empty);
				videoTemplateInfo.Description = base.GetFieldValue(IDataReader,              ConfigAccess.getConfigAccess(3133), string.Empty);
				videoTemplateInfo.VideoLength = base.GetFieldValue(IDataReader,              ConfigAccess.getConfigAccess(3090), 0L);
				videoTemplateInfo.DisplayName = base.GetFieldValue(IDataReader,              ConfigAccess.getConfigAccess(3073), string.Empty);
				videoTemplateInfo.CreatedOn = new DateTime?(base.GetFieldValue(IDataReader,  ConfigAccess.getConfigAccess(3150), DateTime.Now));
				videoTemplateInfo.CreatedBy = base.GetFieldValue(IDataReader,                ConfigAccess.getConfigAccess(2872), 0);
				videoTemplateInfo.ModifiedOn = new DateTime?(base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(3163), DateTime.Now));
				videoTemplateInfo.ModifiedBy = base.GetFieldValue(IDataReader,               ConfigAccess.getConfigAccess(2885), 0);
				videoTemplateInfo.IsActive = base.GetFieldValue(IDataReader,                 ConfigAccess.getConfigAccess(3107), false);
				videoTemplateInfo.IsActiveDisplay = (videoTemplateInfo.IsActive ?            ConfigAccess.getConfigAccess(32396) : ConfigAccess.getConfigAccess(32383));
				list.Add(videoTemplateInfo);
			}
			return list;
		}

		public List<VideoTemplateInfo.VideoSlot> GetVideoSlots(long VideoTemplateId)
		{
			List<VideoTemplateInfo.VideoSlot> result;
			if (!false)
			{
				base.DBParameters.Clear();
				base.OpenConnection();
				IDataReader dataReader;
				while (true)
				{
					IL_0E:
					base.AddParameter(ConfigAccess.getConfigAccess(32447), VideoTemplateId);
					while (true)
					{
						dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(32665));
						if (!false)
						{
							if (3 != 0)
							{
								goto Block_4;
							}
							goto IL_0E;
						}
					}
					return result;
				}
				Block_4:
				result = this.VideoSlotwd(dataReader);
				dataReader.Close();
			}
			return result;
		}

		private List<VideoTemplateInfo.VideoSlot> VideoSlotwd(IDataReader IDataReader)
		{
			List<VideoTemplateInfo.VideoSlot> list = new List<VideoTemplateInfo.VideoSlot>();
			while (true)
			{
				while (IDataReader.Read())
				{
					VideoTemplateInfo.VideoSlot videoSlot = new VideoTemplateInfo.VideoSlot();
					if (true)
					{
						videoSlot.VideoSlotId = base.GetFieldValue(IDataReader,      ConfigAccess.getConfigAccess(32514), 0L);
						videoSlot.FrameTimeIn = base.GetFieldValue(IDataReader,      ConfigAccess.getConfigAccess(32531), 0L);
						videoSlot.PhotoDisplayTime = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(32548), 0);
						list.Add(videoSlot);
					}
				}
				break;
			}
			return list;
		}

		public bool DeleteVideoTemplate(long videoTemplateId)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigAccess.getConfigAccess (32686), videoTemplateId);
			base.ExecuteNonQuery(ConfigAccess.getConfigAccess (32711));
			return true;
		}

		public int SaveUpdateVideoBackground(VideoBackgroundInfo list)
		{
			base.DBParameters.Clear();
			int result;
			do
			{
				base.AddParameter(ConfigAccess.getConfigAccess(32740), list.VideoBackgroundId);
				base.AddParameter(ConfigAccess.getConfigAccess(32185), list.Name);
				base.AddParameter(ConfigAccess.getConfigAccess(32194), list.DisplayName);
				base.AddParameter(ConfigAccess.getConfigAccess(32211), list.Description);
				base.AddParameter(ConfigAccess.getConfigAccess(22033), list.MediaType);
				do
				{
					base.AddParameter(ConfigAccess.getConfigAccess(31332), list.CreatedBy);
					base.AddParameter(ConfigAccess.getConfigAccess(32228), list.CreatedOn);
					base.AddParameter(ConfigAccess.getConfigAccess(32245), list.ModifiedBy);
					do
					{
						base.AddParameter(ConfigAccess.getConfigAccess(32262), list.ModifiedOn);
					}
					while (false);
					base.AddParameter(ConfigAccess.getConfigAccess(27476), list.IsActive);
					result = Convert.ToInt32(base.ExecuteScalar(ConfigAccess.getConfigAccess(32765)));
				}
				while (false);
			}
			while (8 == 0);
			return result;
		}

		public List<VideoBackgroundInfo> GetVideoBackgrounds(long videoBackgroundId)
		{
			List<VideoBackgroundInfo> result;
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
					base.AddParameter(ConfigAccess.getConfigAccess(32740), videoBackgroundId);
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
				dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(32802));
				result = this.VideoBackgroundInfoxd(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<VideoBackgroundInfo> VideoBackgroundInfoxd(IDataReader IDataReader)
		{
			List<VideoBackgroundInfo> list = new List<VideoBackgroundInfo>();
			while (IDataReader.Read())
			{
				VideoBackgroundInfo videoBackgroundInfo = new VideoBackgroundInfo();
				videoBackgroundInfo.VideoBackgroundId = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(32831), 0L);
				if (-1 != 0)
				{
					videoBackgroundInfo.Name = base.GetFieldValue(IDataReader,        ConfigAccess.getConfigAccess(549), string.Empty);
					videoBackgroundInfo.Description = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(3133), string.Empty);
					videoBackgroundInfo.DisplayName = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(3073), string.Empty);
					videoBackgroundInfo.MediaType = base.GetFieldValue(IDataReader,   ConfigAccess.getConfigAccess(3120), 0);
					videoBackgroundInfo.CreatedOn = base.GetFieldValue(IDataReader,   ConfigAccess.getConfigAccess(3150), DateTime.Now);
					videoBackgroundInfo.CreatedBy = base.GetFieldValue(IDataReader,   ConfigAccess.getConfigAccess(2872), 0);
					videoBackgroundInfo.ModifiedOn = base.GetFieldValue(IDataReader,  ConfigAccess.getConfigAccess(3163), DateTime.Now);
					videoBackgroundInfo.ModifiedBy = base.GetFieldValue(IDataReader,  ConfigAccess.getConfigAccess(2885), 0);
				}
				videoBackgroundInfo.IsActive = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess (3107), false);
				videoBackgroundInfo.MediaTypeDisplay = ((videoBackgroundInfo.MediaType == 1) ? ConfigAccess.getConfigAccess (32865) : ConfigAccess.getConfigAccess(32856));
				videoBackgroundInfo.IsActiveDisplay = (videoBackgroundInfo.IsActive ? ConfigAccess.getConfigAccess(32396) : ConfigAccess.getConfigAccess(32383));
				list.Add(videoBackgroundInfo);
			}
			return list;
		}

		public bool DeleteVideoBackground(long videoBackgroundId)
		{
			base.DBParameters.Clear();
			base.AddParameter(   ConfigAccess.getConfigAccess(32740), videoBackgroundId);
			base.ExecuteNonQuery(ConfigAccess.getConfigAccess(32874));
			return true;
		}

		public List<VideoSceneViewModel> GetVideoConfigProfileList(long ProfileId, int substoreid)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigAccess.getConfigAccess(32911), ProfileId);
			base.AddParameter(ConfigAccess.getConfigAccess(32928), substoreid);
			IDataReader dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(32945));
			List<VideoSceneViewModel> result = this.VideoSceneViewModelyd(dataReader);
			dataReader.Close();
			return result;
		}

		private List<VideoSceneViewModel> VideoSceneViewModelyd(IDataReader IDataReader)
		{
			List<VideoSceneViewModel> list;
			while (true)
			{
				IL_00:
				list = new List<VideoSceneViewModel>();
				while (IDataReader.Read())
				{
					VideoSceneViewModel videoSceneViewModel = new VideoSceneViewModel();
					VideoScene videoScene = new VideoScene();
					VideoObjectFileMapping videoObjectFileMapping = new VideoObjectFileMapping();
					videoScene.SceneId = base.GetFieldValue(IDataReader,                       ConfigAccess.getConfigAccess(27238), 0);
					videoScene.Name = base.GetFieldValue(IDataReader,                          ConfigAccess.getConfigAccess(549), string.Empty);
					videoScene.IsActiveForAdvanceProcessing = base.GetFieldValue(IDataReader,  ConfigAccess.getConfigAccess(32978), false);
					videoScene.ScenePath = base.GetFieldValue(IDataReader,                     ConfigAccess.getConfigAccess(33019), string.Empty);
					videoScene.LocationId = base.GetFieldValue(IDataReader,                    ConfigAccess.getConfigAccess(12400), 0);
					videoScene.VideoLength = base.GetFieldValue(IDataReader,                   ConfigAccess.getConfigAccess(3090), 0);
					videoScene.CG_ConfigID = base.GetFieldValue(IDataReader,                   ConfigAccess.getConfigAccess(33032), 0);
					if (6 == 0)
					{
						goto IL_00;
					}
					videoScene.IsActive = base.GetFieldValue(IDataReader,               ConfigAccess.getConfigAccess(3107), false);
					videoScene.Settings = base.GetFieldValue(IDataReader,               ConfigAccess.getConfigAccess(33049), string.Empty);
					videoObjectFileMapping.ChromaPath = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(33062), string.Empty);
					videoSceneViewModel.VideoScene = videoScene;
					list.Add(videoSceneViewModel);
				}
				break;
			}
			return list;
		}

		public bool DeleteVideoConfigProfile(long ProfileId)
		{
			int arg_89_0 = 0;
			while (true)
			{
				int num = arg_89_0;
				while (true)
				{
					if (4 == 0)
					{
						goto IL_75;
					}
					base.DBParameters.Clear();
					base.AddOutParameterString(ConfigAccess.getConfigAccess(33079), SqlDbType.NVarChar, 350);
					IL_38:
					base.AddParameter(ConfigAccess.getConfigAccess(33100), ProfileId);
					if (false)
					{
						continue;
					}
					num = Convert.ToInt32(base.ExecuteNonQuery(ConfigAccess.getConfigAccess (33121)));
					IL_75:
					if (num > 0)
					{
						return true;
					}
					if (5 != 0 && 8 != 0)
					{
						break;
					}
					goto IL_38;
				}
				int expr_82 = arg_89_0 = 0;
				if (expr_82 == 0)
				{
					return expr_82 != 0;
				}
			}
			return true;
		}

		public bool UpdateReceiptData(StoreInfo store)
		{
			base.AddParameter(    ConfigAccess.getConfigAccess(33158), store.BillReceiptTitle);
			base.AddParameter(    ConfigAccess.getConfigAccess(33183), store.TaxRegistrationNumber);
			if (!false)
			{
				base.AddParameter(ConfigAccess.getConfigAccess(33216), store.TaxRegistrationText);
				base.AddParameter(ConfigAccess.getConfigAccess(33245), store.Address);
				base.AddParameter(ConfigAccess.getConfigAccess(33258), store.PhoneNo);
				base.AddParameter(ConfigAccess.getConfigAccess(33271), store.TaxMinSequenceNo);
			}
			base.AddParameter(    ConfigAccess.getConfigAccess(33296), store.TaxMaxSequenceNo);
			base.AddParameter(    ConfigAccess.getConfigAccess(33321), store.IsSequenceNoRequired);
			base.AddParameter(    ConfigAccess.getConfigAccess(33350), store.IsTaxEnabled);
			base.ExecuteNonQuery( ConfigAccess.getConfigAccess(33371));
			return true;
		}

		public StoreInfo getTaxConfigData()
		{
			StoreInfo result;
			IDataReader dataReader;
			while (true)
			{
				result = new StoreInfo();
				if (5 != 0)
				{
					dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(33404));
					if (3 == 0)
					{
						return result;
					}
					if (!false)
					{
						result = this.StoreInfozd(dataReader);
						if (!false)
						{
							break;
						}
					}
				}
			}
			dataReader.Close();
			return result;
		}

		private StoreInfo StoreInfozd(IDataReader IDataReader)
		{
			StoreInfo storeInfo = new StoreInfo();
			while (IDataReader.Read())
			{
				storeInfo.BillReceiptTitle = base.GetFieldValue(IDataReader,               ConfigAccess.getConfigAccess(33429), string.Empty);
				storeInfo.Address = base.GetFieldValue(IDataReader,                        ConfigAccess.getConfigAccess(33454), string.Empty);
				storeInfo.PhoneNo = base.GetFieldValue(IDataReader,                        ConfigAccess.getConfigAccess(33467), string.Empty);
				storeInfo.TaxRegistrationNumber = base.GetFieldValue(IDataReader,          ConfigAccess.getConfigAccess(33480), string.Empty);
				storeInfo.TaxRegistrationText = base.GetFieldValue(IDataReader,            ConfigAccess.getConfigAccess(33509), string.Empty);
				storeInfo.IsSequenceNoRequired = new bool?(base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(33538), false));
				storeInfo.IsTaxEnabled = base.GetFieldValue(IDataReader,                   ConfigAccess.getConfigAccess(24545), false);
				storeInfo.TaxMinSequenceNo = base.GetFieldValue(IDataReader,               ConfigAccess.getConfigAccess(33567), 0L);
				storeInfo.TaxMaxSequenceNo = base.GetFieldValue(IDataReader,               ConfigAccess.getConfigAccess(33592), 0L);
			}
			return storeInfo;
		}

		public int GetSubstoreLocationWise(int locationid)
		{
			if (true)
			{
				base.DBParameters.Clear();
				base.AddParameter(ConfigAccess.getConfigAccess(12976), locationid);
			}
			int arg_38_0 = Convert.ToInt32(base.ExecuteScalar(ConfigAccess.getConfigAccess (33617)));
			int expr_39;
			do
			{
				int num = arg_38_0;
				expr_39 = (arg_38_0 = num);
			}
			while (false);
			return expr_39;
		}

		public bool SaveEmailDetails(string toAddress, string toBCC, string sender, string msgBody, string msgType)
		{
			if (!true)
			{
				goto IL_2E;
			}
			List<SqlParameter> expr_10F = base.DBParameters;
			if (4 != 0)
			{
				expr_10F.Clear();
			}
			IL_14:
			base.AddParameter(ConfigAccess.getConfigAccess (15203), null);
			IL_2E:
			base.AddParameter(ConfigAccess.getConfigAccess (15216), toAddress);
			if (!false)
			{
				base.AddParameter(ConfigAccess.getConfigAccess(15229), toBCC);
				base.AddParameter(ConfigAccess.getConfigAccess(15242), false);
				base.AddParameter(ConfigAccess.getConfigAccess(15259), sender);
				base.AddParameter(ConfigAccess.getConfigAccess(15276), msgBody);
				if (7 == 0)
				{
					goto IL_14;
				}
				base.AddParameter(ConfigAccess.getConfigAccess(15297), ConfigAccess.getConfigAccess (33650));
			}                                 
			base.AddParameter(    ConfigAccess.getConfigAccess(15364), msgType);
			base.ExecuteNonQuery( ConfigAccess.getConfigAccess(33655));
			return true;
		}

		public bool SaveEmailDetails(string toAddress, string toBCC, string sender, string msgBody, string msgType, int subStoreID)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigAccess.getConfigAccess(15203), null);
			base.AddParameter(ConfigAccess.getConfigAccess(15216), toAddress);
			base.AddParameter(ConfigAccess.getConfigAccess(15229), toBCC);
			base.AddParameter(ConfigAccess.getConfigAccess(15242), false);
			base.AddParameter(ConfigAccess.getConfigAccess(15259), sender);
			base.AddParameter(ConfigAccess.getConfigAccess(15276), msgBody);
			base.AddParameter(ConfigAccess.getConfigAccess(15297), ConfigAccess.getConfigAccess (33650));
			base.AddParameter(ConfigAccess.getConfigAccess(15364), msgType);
			base.AddParameter(ConfigAccess.getConfigAccess(33680), subStoreID);
			base.ExecuteNonQuery(ConfigAccess.getConfigAccess(33655));
			return true;
		}

		public bool DeleteConfigLocation(int substoreId, int locationId)
		{
			while (true)
			{
				base.DBParameters.Clear();
				if (4 != 0)
				{
					base.AddParameter(ConfigAccess.getConfigAccess (33697), substoreId);
					if (-1 != 0)
					{
						break;
					}
				}
			}
			base.AddParameter(ConfigAccess.getConfigAccess (33722), locationId);
			if (4 != 0)
			{
				base.ExecuteNonQuery(ConfigAccess.getConfigAccess (33747));
			}
			return true;
		}

		public List<StockShot> GetStockShotImagesList(long ImageId)
		{
			List<StockShot> result;
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
					base.AddParameter(ConfigAccess.getConfigAccess(33780), ImageId);
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
				dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess (33801));
				result = this.StockShotAd(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<StockShot> StockShotAd(IDataReader IDataReader)
		{
			List<StockShot> list = new List<StockShot>();
			IL_94:
			while (IDataReader.Read())
			{
				StockShot stockShot;
				do
				{
					if (true)
					{
						stockShot = new StockShot();
						if (false)
						{
							goto IL_94;
						}
						stockShot.ImageId = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess (33834), 0L);
					}
				}
				while (false);
				stockShot.ImageName = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(33847), string.Empty);
				stockShot.IsActive = base.GetFieldValue(IDataReader,  ConfigAccess.getConfigAccess(3107), false);
				if (5 != 0)
				{
					list.Add(stockShot);
				}
			}
			return list;
		}

		public long SaveUpdateStockShotImage(StockShot img)
		{
			do
			{
				base.DBParameters.Clear();
				string expr_FD = ConfigAccess.getConfigAccess (33860);
				object expr_2D = img.ImageId;
				if (!false)
				{
					base.AddParameter(expr_FD, expr_2D);
				}
			}
			while (-1 == 0);
			base.AddParameter(ConfigAccess.getConfigAccess(33881), img.ImageName);
			if (!false)
			{
				base.AddParameter(ConfigAccess.getConfigAccess(2230), img.CreatedBy);
				base.AddParameter(ConfigAccess.getConfigAccess(2309), img.ModifiedBy);
				base.AddParameter(ConfigAccess.getConfigAccess(1216), img.IsActive);
			}
			return Convert.ToInt64(base.ExecuteScalar(ConfigAccess.getConfigAccess(33902)));
		}

		public bool DeleteStockShotImg(long ImgId)
		{
			base.DBParameters.Clear();
			base.AddParameter(   ConfigAccess.getConfigAccess(33935), ImgId);
			base.ExecuteNonQuery(ConfigAccess.getConfigAccess(33964));
			return true;
		}

		public List<ConfigurationInfo> GetAllSubstoreConfigdata()
		{
			base.DBParameters.Clear();
			IDataReader dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(33997));
			List<ConfigurationInfo> result;
			do
			{
				result = this.ConfigurationInfoBd(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		private List<ConfigurationInfo> ConfigurationInfoBd(IDataReader IDataReader)
		{
			List<ConfigurationInfo> list = new List<ConfigurationInfo>();
			while (true)
			{
				if (!false)
				{
					goto IL_DB;
				}
				IL_1C:
				ConfigurationInfo configurationInfo;
				configurationInfo.DG_Hot_Folder_Path = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(8463), string.Empty);
				configurationInfo.DG_Frame_Path = base.GetFieldValue(IDataReader,      ConfigAccess.getConfigAccess(8488), string.Empty);
				configurationInfo.DG_BG_Path = base.GetFieldValue(IDataReader,         ConfigAccess.getConfigAccess(8509), string.Empty);
				if (false)
				{
					continue;
				}
				configurationInfo.DG_Graphics_Path = base.GetFieldValue(IDataReader,        ConfigAccess.getConfigAccess(8840), string.Empty);
				configurationInfo.DG_Substore_Id = new int?(base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(8915), 0));
				list.Add(configurationInfo);
				IL_DB:
				if (!IDataReader.Read())
				{
					break;
				}
				configurationInfo = new ConfigurationInfo();
				goto IL_1C;
			}
			return list;
		}

		public List<iMIXStoreConfigurationInfo> GetStoreConfigData()
		{
			base.DBParameters.Clear();
			IDataReader dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(12417));
			List<iMIXStoreConfigurationInfo> result;
			do
			{
				result = this.iMIXStoreConfigurationInfoCd(dataReader);
			}
			while (false);
			dataReader.Close();
			return result;
		}

		private List<iMIXStoreConfigurationInfo> iMIXStoreConfigurationInfoCd(IDataReader IDataReader)
		{
			List<iMIXStoreConfigurationInfo> list = new List<iMIXStoreConfigurationInfo>();
			while (IDataReader.Read())
			{
				list.Add(new iMIXStoreConfigurationInfo
				{
					iMIXStoreConfigurationValueId = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(34038), 0L),
					IMIXConfigurationMasterId = base.GetFieldValue(IDataReader,     ConfigAccess.getConfigAccess(10395), 0L),
					ConfigurationValue = base.GetFieldValue(IDataReader,            ConfigAccess.getConfigAccess(10432), string.Empty),
					SyncCode = base.GetFieldValue(IDataReader,                      ConfigAccess.getConfigAccess(2007), string.Empty),
					IsSynced = base.GetFieldValue(IDataReader,                      ConfigAccess.getConfigAccess(2020), false),
					ModifiedDate = base.GetFieldValue(IDataReader,                  ConfigAccess.getConfigAccess(2919), DateTime.MinValue)
				});
			}
			return list;
		}

		public VideoSceneViewModel GetVideoSceneBasedOnPhotoId(int PhotoId)
		{
			base.DBParameters.Clear();
			base.AddParameter(                          ConfigAccess.getConfigAccess(34079), PhotoId);
			IDataReader dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(34092));
			List<VideoSceneViewModel> list = this.VideoSceneViewModelyd(dataReader);
			dataReader.Close();
			if (list.Count > 0)
			{
				return list[0];
			}
			return null;
		}

		public int SaveCGConfigSetting(CGConfigSettings CGConfigSettings)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigAccess.getConfigAccess(34141), CGConfigSettings.ID, ParameterDirection.InputOutput);
			base.AddParameter(ConfigAccess.getConfigAccess(34154), CGConfigSettings.ConfigFileName);
			base.AddParameter(ConfigAccess.getConfigAccess(34179), CGConfigSettings.Extension);
			base.AddParameter(ConfigAccess.getConfigAccess(34200), CGConfigSettings.ConfigFileName);
			base.AddParameter(ConfigAccess.getConfigAccess(1216),  CGConfigSettings.IsActive);
			int result;
			if (!false)
			{
				Convert.ToInt64(base.ExecuteScalar(ConfigAccess.getConfigAccess(34225)));
				result = Convert.ToInt32(base.GetOutParameterValue(ConfigAccess.getConfigAccess(34141)));
			}
			return result;
		}

		public List<CGConfigSettings> GetCGConfigSettngs(int configId)
		{
			List<CGConfigSettings> result;
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
					base.AddParameter(ConfigAccess.getConfigAccess (34270), configId);
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
				dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(34291));
				result = this.CGConfigSettingsDd(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<CGConfigSettings> CGConfigSettingsDd(IDataReader IDataReader)
		{
			List<CGConfigSettings> list;
			if (!false)
			{
				list = new List<CGConfigSettings>();
			}
			while (IDataReader.Read())
			{
				list.Add(new CGConfigSettings
				{
					ID = base.GetFieldValue(IDataReader,             ConfigAccess.getConfigAccess(24138), 0),
					ConfigFileName = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(34324), string.Empty),
					Extension = base.GetFieldValue(IDataReader,      ConfigAccess.getConfigAccess(34341), string.Empty),
					DisplayName = base.GetFieldValue(IDataReader,    ConfigAccess.getConfigAccess(3073), string.Empty)
				});
			}
			return list;
		}

		public bool DeleteCGConfigSettngs(int ConfigId)
		{
			while (true)
			{
				if (false)
				{
					goto IL_42;
				}
				List<SqlParameter> expr_52 = base.DBParameters;
				if (!false)
				{
					expr_52.Clear();
				}
				if (-1 != 0)
				{
					base.AddParameter(ConfigAccess.getConfigAccess (34354), ConfigId);
					goto IL_25;
				}
				IL_47:
				if (!true)
				{
					continue;
				}
				if (!false)
				{
					return false;
				}
				goto IL_42;
				IL_25:
				int num = Convert.ToInt32(base.ExecuteNonQuery(ConfigAccess.getConfigAccess(34375)));
				if (num <= 0)
				{
					goto IL_47;
				}
				IL_42:
				if (-1 != 0)
				{
					break;
				}
				goto IL_25;
			}
			return true;
		}

		public int SaveUpdateVideoOverlay(VideoOverlay list)
		{
			do
			{
				base.DBParameters.Clear();
				base.AddParameter(ConfigAccess.getConfigAccess(3010), list.VideoOverlayId);
				base.AddParameter(ConfigAccess.getConfigAccess(32185), list.Name);
				base.AddParameter(ConfigAccess.getConfigAccess(32194), list.DisplayName);
			}
			while (false);
			base.AddParameter(ConfigAccess.getConfigAccess(32211), list.Description);
			base.AddParameter(ConfigAccess.getConfigAccess(22033), list.MediaType);
			base.AddParameter(ConfigAccess.getConfigAccess(32472), list.VideoLength);
			base.AddParameter(ConfigAccess.getConfigAccess(31332), list.CreatedBy);
			base.AddParameter(ConfigAccess.getConfigAccess(32228), list.CreatedOn);
			base.AddParameter(ConfigAccess.getConfigAccess(32245), list.ModifiedBy);
			base.AddParameter(ConfigAccess.getConfigAccess(32262), list.ModifiedOn);
			base.AddParameter(ConfigAccess.getConfigAccess(27476), list.IsActive);
			int arg_18E_0;
			int expr_184 = arg_18E_0 = Convert.ToInt32(base.ExecuteScalar(ConfigAccess.getConfigAccess(34408)));
			if (true)
			{
				int num = expr_184;
				arg_18E_0 = num;
			}
			return arg_18E_0;
		}

		public bool DeleteVideoOverlay(long overlayId)
		{
			base.DBParameters.Clear();
			base.AddParameter(ConfigAccess.getConfigAccess(34441), overlayId);
			base.ExecuteNonQuery(ConfigAccess.getConfigAccess (34462));
			return true;
		}

		public List<VideoBackgroundInfo> GetVideoOverlay(long VideoOverlayId)
		{
			List<VideoBackgroundInfo> result;
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
					base.AddParameter(ConfigAccess.getConfigAccess(3010), VideoOverlayId);
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
				dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(32619));
				result = this.VideoBackgroundInfoEd(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<VideoBackgroundInfo> VideoBackgroundInfoEd(IDataReader IDataReader)
		{
			List<VideoBackgroundInfo> list = new List<VideoBackgroundInfo>();
			while (IDataReader.Read())
			{
				VideoBackgroundInfo expr_1AF = new VideoBackgroundInfo();
				VideoBackgroundInfo videoBackgroundInfo;
				if (true)
				{
					videoBackgroundInfo = expr_1AF;
				}
				videoBackgroundInfo.Name = base.GetFieldValue(IDataReader,        ConfigAccess.getConfigAccess(549), string.Empty);
				videoBackgroundInfo.Description = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(3133), string.Empty);
				videoBackgroundInfo.MediaType = base.GetFieldValue(IDataReader,   ConfigAccess.getConfigAccess(3120), 0);
				videoBackgroundInfo.VideoLength = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(3090), 0);
				videoBackgroundInfo.DisplayName = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(3073), string.Empty);
				videoBackgroundInfo.CreatedOn = base.GetFieldValue(IDataReader,   ConfigAccess.getConfigAccess(3150), DateTime.Now);
				videoBackgroundInfo.CreatedBy = base.GetFieldValue(IDataReader,   ConfigAccess.getConfigAccess(2872), 0);
				videoBackgroundInfo.ModifiedOn = base.GetFieldValue(IDataReader,  ConfigAccess.getConfigAccess(3163), DateTime.Now);
				videoBackgroundInfo.ModifiedBy = base.GetFieldValue(IDataReader,  ConfigAccess.getConfigAccess(2885), 0);
				videoBackgroundInfo.IsActive = base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess (3107), false);
				videoBackgroundInfo.IsActiveDisplay = (videoBackgroundInfo.IsActive ? ConfigAccess.getConfigAccess(32396) : ConfigAccess.getConfigAccess(32383));
				list.Add(videoBackgroundInfo);
			}
			return list;
		}

		public List<VideoOverlay> GetVideoOverlays(long videoBackgroundId)
		{
			List<VideoOverlay> result;
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
					base.AddParameter(ConfigAccess.getConfigAccess(3010), videoBackgroundId);
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
				dataReader = base.ExecuteReader(ConfigAccess.getConfigAccess(3031));
				result = this.VideoOverlayEd(dataReader);
				goto IL_41;
			}
			return result;
		}

		private List<VideoOverlay> VideoOverlayEd(IDataReader IDataReader)
		{
			List<VideoOverlay> list = new List<VideoOverlay>();
			while (IDataReader.Read())
			{
				VideoOverlay videoOverlay = new VideoOverlay();
				videoOverlay.VideoOverlayId = base.GetFieldValue(IDataReader,           ConfigAccess.getConfigAccess(3052), 0L);
				videoOverlay.Name = base.GetFieldValue(IDataReader,                     ConfigAccess.getConfigAccess(549), string.Empty);
				videoOverlay.Description = base.GetFieldValue(IDataReader,              ConfigAccess.getConfigAccess(3133), string.Empty);
				videoOverlay.MediaType = base.GetFieldValue(IDataReader,                ConfigAccess.getConfigAccess(3120), 0);
				videoOverlay.VideoLength = base.GetFieldValue(IDataReader,              ConfigAccess.getConfigAccess(3090), 0L);
				videoOverlay.DisplayName = base.GetFieldValue(IDataReader,              ConfigAccess.getConfigAccess(3073), string.Empty);
				videoOverlay.CreatedOn = new DateTime?(base.GetFieldValue(IDataReader,  ConfigAccess.getConfigAccess(3150), DateTime.Now));
				videoOverlay.CreatedBy = base.GetFieldValue(IDataReader,                ConfigAccess.getConfigAccess(2872), 0);
				videoOverlay.ModifiedOn = new DateTime?(base.GetFieldValue(IDataReader, ConfigAccess.getConfigAccess(3163), DateTime.Now));
				videoOverlay.ModifiedBy = base.GetFieldValue(IDataReader,               ConfigAccess.getConfigAccess(2885), 0);
				videoOverlay.IsActive = base.GetFieldValue(IDataReader,                 ConfigAccess.getConfigAccess(3107), false);
				videoOverlay.IsActiveDisplay = (videoOverlay.IsActive ?                 ConfigAccess.getConfigAccess(32396) : ConfigAccess.getConfigAccess(32383));
				list.Add(videoOverlay);
			}
			return list;
		}

		static ConfigAccess()
		{
			// Note: this type is marked as 'beforefieldinit'.
			SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(ConfigAccess));
		}
	}
}
