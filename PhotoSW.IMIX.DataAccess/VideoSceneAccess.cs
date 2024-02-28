using PhotoSW.IMIX.Model;
//using SmartAssembly.Delegates;
//using SmartAssembly.HouseOfCards;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace PhotoSW.IMIX.DataAccess
{
	public class VideoSceneAccess : BaseDataAccess
	{
		
		//internal static SmartAssembly.Delegates.GetString ;
        internal static GetString getVideoSceneAccess;
		public VideoSceneAccess(BaseDataAccess baseaccess) : base(baseaccess)
		{
		}

		public VideoSceneAccess()
		{
		}

		public bool SaveVideoSceneObject(string VideoObjectIds)
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
				base.AddParameter(VideoSceneAccess.getVideoSceneAccess(57999), VideoObjectIds);
			}
			if (2 != 0)
			{
				base.ExecuteNonQuery(VideoSceneAccess.getVideoSceneAccess(58028));
			}
			return true;
		}

		public List<VideoSceneObject> GetVideoSceneObjects(VideoSceneObject videoSceneObject)
		{
			IDataReader IDataReader;
			do
			{
				List<SqlParameter> expr_4A = base.DBParameters;
				if (6 != 0)
				{
					expr_4A.Clear();
				}
				base.AddParameter(VideoSceneAccess.getVideoSceneAccess (58061), videoSceneObject.SceneId);
				new List<VideoSceneObject>();
				IDataReader = base.ExecuteReader(VideoSceneAccess.getVideoSceneAccess(58082));
			}
			while (false);
			return this.videoSceneObjectOk(IDataReader);
		}

		private List<VideoSceneObject> videoSceneObjectOk(IDataReader IDataReader)
		{
			List<VideoSceneObject> list = new List<VideoSceneObject>();
			while (true)
			{
				while (IDataReader.Read())
				{
					VideoSceneObject videoSceneObject = new VideoSceneObject();
					if (7 != 0)
					{
						videoSceneObject.VideoObject_Pkey = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(58111), 0);
						videoSceneObject.VideoObjectId = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(58136), string.Empty);
						list.Add(videoSceneObject);
					}
				}
				break;
			}
			return list;
		}

		public List<VideoScene> GetVideoSceneByCriteria(int locationId, int sceneId)
		{
			new List<VideoScene>();
			do
			{
				base.DBParameters.Clear();
			}
			while (7 == 0);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess (23101), locationId);
			List<VideoScene> result;
			do
			{
				base.AddParameter(VideoSceneAccess.getVideoSceneAccess(33534), sceneId);
				IDataReader IDataReader;
				do
				{
					IDataReader = base.ExecuteReader(VideoSceneAccess.getVideoSceneAccess(58157));
				}
				while (false);
				result = this.VideoScenePk(IDataReader);
			}
			while (3 == 0);
			return result;
		}

		private List<VideoScene> VideoScenePk(IDataReader IDataReader)
		{
			List<VideoScene> list = new List<VideoScene>();
			while (IDataReader.Read())
			{
				list.Add(new VideoScene
				{
					SceneId = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(27672), 0),
					LocationId = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(12834), 0),
					Name = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(983), string.Empty),
					ScenePath = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(33453), string.Empty),
					VideoLength = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (3524), 0),
					Settings = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (33483), string.Empty),
					IsActive = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (3541), false),
					IsMixerScene = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (58194), false),
					IsActiveForAdvanceProcessing = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (33412), false),
					CG_ConfigID = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (33466), 0)
				});
			}
			return list;
		}

		public bool SaveVideoScene(VideoSceneViewModel VideoScene)
		{
			 base.DBParameters.Clear();
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(33534), VideoScene.VideoScene.SceneId);
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(33513), VideoScene.VideoScene.Name);
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58211), VideoScene.VideoScene.ScenePath);
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(23101), VideoScene.VideoScene.LocationId);
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58232), VideoScene.VideoSceneObject.VideoObject_Pkey);
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58253), VideoScene.VideoObjectFileMapping.ChromaPath);
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58278), VideoScene.VideoObjectFileMapping.RoutePath);
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58307), VideoScene.VideoScene.Settings);
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58328), VideoScene.VideoScene.VideoLength);
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58353), VideoScene.VideoSceneObject.GuestVideoObject);
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58386), VideoScene.VideoScene.IsActive);
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58407), VideoScene.VideoScene.IsActiveForAdvanceProcessing);
			 base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58456), VideoScene.VideoObjectFileMapping.StreamAudioEnabled);
			 base.ExecuteNonQuery(VideoSceneAccess.getVideoSceneAccess(58489));
			return true;
		}

		public bool SaveMixerScene(VideoSceneViewModel VideoScene)
		{
			base.DBParameters.Clear();
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(33534), VideoScene.VideoScene.SceneId);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(33513), VideoScene.VideoScene.Name);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58211), VideoScene.VideoScene.ScenePath);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(23101), VideoScene.VideoScene.LocationId);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58518), VideoScene.VideoSceneObject.VideoObjectId);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58253), VideoScene.VideoObjectFileMapping.ChromaPath);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58307), VideoScene.VideoScene.Settings);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58328), VideoScene.VideoScene.VideoLength);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58353), VideoScene.VideoSceneObject.GuestVideoObject);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58386), VideoScene.VideoScene.IsActive);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58407), VideoScene.VideoScene.IsActiveForAdvanceProcessing);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58547), VideoScene.VideoScene.IsMixerScene);
			do
			{
				base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58572), VideoScene.VideoScene.CG_ConfigID);
				base.ExecuteNonQuery(VideoSceneAccess.getVideoSceneAccess (58597));
			}
			while (7 == 0);
			return true;
		}

		public List<VideoSceneObject> GuestVideoObjectBySceneID(int sceneId)
		{
			new List<VideoSceneObject>();
			if (false)
			{
			}
			base.DBParameters.Clear();
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess (33534), sceneId);
			IDataReader IDataReader = base.ExecuteReader(VideoSceneAccess.getVideoSceneAccess (58622));
			return this.VideoSceneObjectRk(IDataReader);
		}

		private List<VideoSceneObject> VideoSceneObjectRk(IDataReader IDataReader)
		{
			List<VideoSceneObject> list = new List<VideoSceneObject>();
			while (true)
			{
				while (IDataReader.Read())
				{
					VideoSceneObject videoSceneObject = new VideoSceneObject();
					VideoObjectFileMapping videoObjectFileMapping = new VideoObjectFileMapping();
					if (5 != 0)
					{
						string arg_18A_0 = string.Empty;
						while (!false)
						{
							if (7 != 0)
							{
                                //videoSceneObject.VideoObject_Pkey = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(58111, 0);
                                videoSceneObject.VideoObject_Pkey = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (58111), 0);
								if (false)
								{
									continue;
								}
								videoSceneObject.VideoObjectId = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (58136), string.Empty);
								videoSceneObject.GuestVideoObject = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(58667), false);
							}
							videoObjectFileMapping.ChromaPath = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (33496), string.Empty);
							videoObjectFileMapping.RoutePath = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(58692), string.Empty);
							videoObjectFileMapping.StreamAudioEnabled = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(58705), string.Empty);
							string fieldValue = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (58705), string.Empty);
							videoSceneObject.streamAudioEnabled = (fieldValue == VideoSceneAccess.getVideoSceneAccess (58730));
							break;
						}
						videoSceneObject.ObjectFileMapping = videoObjectFileMapping;
						list.Add(videoSceneObject);
					}
				}
				break;
			}
			return list;
		}

		public List<VideoScene> GetVideoScene(int sceneId, int? substoreId)
		{
			base.DBParameters.Clear();
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(33534), sceneId);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(58739), substoreId);
			List<VideoScene> list = new List<VideoScene>();
			IDataReader IDataReader = base.ExecuteReader(VideoSceneAccess.getVideoSceneAccess(58764));
			return this.VideoSceneSk(IDataReader);
		}

		private List<VideoScene> VideoSceneSk(IDataReader IDataReader)
		{
			List<VideoScene> list = new List<VideoScene>();
			while (IDataReader.Read())
			{
				list.Add(new VideoScene
				{
					Name = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (983), string.Empty),
					ScenePath = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (33453), string.Empty),
					IsActive = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (3541), false),
					IsActiveForAdvanceProcessingStatus = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(33412), string.Empty),
					SceneId = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(27672), 0),
					LocationId = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(12834), 0),
					Settings = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(33483), string.Empty),
					LocationName = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(16820), string.Empty),
					VideoLength = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(3524), 0)
				});
			}
			return list;
		}

		public string DeleteVideoSceneDetails(int? Sceneid)
		{
			base.DBParameters.Clear();
			base.AddOutParameterString(VideoSceneAccess.getVideoSceneAccess(33513), SqlDbType.NVarChar, 350);
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess(33534), Sceneid);
			base.ExecuteNonQuery(VideoSceneAccess.getVideoSceneAccess(33555));
			return (string)base.GetOutParameterValue(VideoSceneAccess.getVideoSceneAccess(33513));
		}

		public VideoSceneViewModel GetVideoSceneToEdit(int? Sceneid)
		{
			new VideoSceneViewModel();
			if (false)
			{
			}
			base.DBParameters.Clear();
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess (58061), Sceneid);
			IDataReader IDataReader = base.ExecuteReader(VideoSceneAccess.getVideoSceneAccess(58789));
			return this.VideoSceneViewModelTk(IDataReader);
		}

		private VideoSceneViewModel VideoSceneViewModelTk(IDataReader IDataReader)
		{
			VideoSceneViewModel expr_18B = new VideoSceneViewModel();
			VideoSceneViewModel videoSceneViewModel;
			if (!false)
			{
				videoSceneViewModel = expr_18B;
			}
			VideoScene videoScene = null;
			List<VideoSceneObject> list = new List<VideoSceneObject>();
			while (IDataReader.Read())
			{
				videoScene = new VideoScene();
				VideoSceneObject videoSceneObject = new VideoSceneObject();
				videoScene.Name = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (983), string.Empty);
				videoScene.ScenePath = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (33453), string.Empty);
				videoScene.LocationId = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (12834), 0);
				videoScene.VideoLength = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (3524), 0);
				videoScene.IsActive = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(3541), false);
				videoScene.IsActiveForAdvanceProcessing = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(33412), false);
				videoScene.Settings = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (33483), string.Empty);
				videoSceneObject.VideoObject_Pkey = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (58111), 0);
				videoSceneObject.VideoObjectId = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (58136), string.Empty);
				videoSceneObject.GuestVideoObject = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (58822), false);
				list.Add(videoSceneObject);
			}
			videoSceneViewModel.VideoScene = videoScene;
			videoSceneViewModel.ListVideoSceneObject = list;
			return videoSceneViewModel;
		}

		public VideoSceneViewModel GetVideoSceneEditToResource(int? Sceneid)
		{
			new VideoSceneViewModel();
			if (false)
			{
			}
			base.DBParameters.Clear();
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess (58061), Sceneid);
			IDataReader IDataReader = base.ExecuteReader(VideoSceneAccess.getVideoSceneAccess (58847));
			return this.VideoSceneViewModelUk(IDataReader);
		}

		private VideoSceneViewModel VideoSceneViewModelUk(IDataReader IDataReader)
		{
			VideoSceneViewModel videoSceneViewModel = new VideoSceneViewModel();
			List<VideoObjectFileMapping> list = new List<VideoObjectFileMapping>();
			List<VideoSceneObject> list2 = new List<VideoSceneObject>();
			while (IDataReader.Read())
			{
				VideoObjectFileMapping videoObjectFileMapping = new VideoObjectFileMapping();
				VideoSceneObject videoSceneObject = new VideoSceneObject();
				videoObjectFileMapping.ValueTypeId = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (31078), 0);
				do
				{
					videoObjectFileMapping.ResourcePath = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (58892), string.Empty);
					videoSceneObject.VideoObject_Pkey = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(58111), 0);
				}
				while (false);
				videoSceneObject.VideoObjectId = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (58136), string.Empty);
				list.Add(videoObjectFileMapping);
				list2.Add(videoSceneObject);
			}
			videoSceneViewModel.ListVideoSceneObject = list2;
			videoSceneViewModel.ListVideoObjectFileMapping = list;
			return videoSceneViewModel;
		}

		public VideoObjectFileMapping GetobjectVideoDetails(int vidObjectID)
		{
			List<SqlParameter> expr_46 = base.DBParameters;
			if (!false)
			{
				expr_46.Clear();
			}
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess (58909), vidObjectID);
			new VideoObjectFileMapping();
			IDataReader IDataReader = base.ExecuteReader(VideoSceneAccess.getVideoSceneAccess(58934));
			return this.VideoObjectFileMappingVk(IDataReader);
		}

		private VideoObjectFileMapping VideoObjectFileMappingVk(IDataReader IDataReader)
		{
			VideoObjectFileMapping videoObjectFileMapping;
			if (!false && -1 != 0)
			{
				videoObjectFileMapping = new VideoObjectFileMapping();
			}
			if (6 != 0)
			{
			}
			while (IDataReader.Read())
			{
				videoObjectFileMapping.ChromaPath = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(33496), string.Empty);
				videoObjectFileMapping.RoutePath = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (58692), string.Empty);
				videoObjectFileMapping.StreamAudioEnabled = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (58705), string.Empty);
			}
			return videoObjectFileMapping;
		}

		public List<Watchersetting> GetSettingWatcher(int LocationId)
		{
			new List<Watchersetting>();
			if (false)
			{
			}
			base.DBParameters.Clear();
			base.AddParameter(VideoSceneAccess.getVideoSceneAccess (58971), LocationId);
			IDataReader IDataReader  = base.ExecuteReader(VideoSceneAccess.getVideoSceneAccess (58996));
			return this.WatchersettingWk(IDataReader);
		}

		private List<Watchersetting> WatchersettingWk(IDataReader IDataReader)
		{
			List<Watchersetting> list;
			if (true)
			{
				if (6 == 0)
				{
					goto IL_92;
				}
				if (false)
				{
					goto IL_75;
				}
				list = new List<Watchersetting>();
			}
			goto IL_9F;
			IL_75:
			Watchersetting watchersetting;
			watchersetting.Isstream = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (3908), false);
			IL_92:
			if (6 != 0)
			{
				list.Add(watchersetting);
			}
			IL_9F:
			if (!IDataReader.Read())
			{
				return list;
			}
			if (7 != 0)
			{
				watchersetting = new Watchersetting();
			}
			watchersetting.SceneName = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess (983), string.Empty);
			watchersetting.IsMixerScene = base.GetFieldValue(IDataReader, VideoSceneAccess.getVideoSceneAccess(58194), false);
			goto IL_75;
		}

		public string checkIsActiveForAdvance(int locationId)
		{
			if (!false)
			{
				base.DBParameters.Clear();
			}
			base.AddOutParameterString(VideoSceneAccess.getVideoSceneAccess(59017), SqlDbType.NVarChar, 350);
			do
			{
				base.AddParameter(VideoSceneAccess.getVideoSceneAccess (23101), locationId);
			}
			while (3 == 0);
			if (false)
			{
				goto IL_93;
			}
			base.ExecuteNonQuery(VideoSceneAccess.getVideoSceneAccess (59034));
			IL_71:
			string result = string.Empty;
			if (base.GetOutParameterValue(VideoSceneAccess.getVideoSceneAccess (59017)) == DBNull.Value)
			{
				return result;
			}
			IL_93:
			if (-1 == 0)
			{
				goto IL_71;
			}
			result = (string)base.GetOutParameterValue(VideoSceneAccess.getVideoSceneAccess (59017));
			return result;
		}

		public string checkIsActiveForVideoProcessing(int locationId)
		{
			if (!false)
			{
				base.DBParameters.Clear();
			}
			base.AddOutParameterString(VideoSceneAccess.getVideoSceneAccess (59017), SqlDbType.NVarChar, 350);
			do
			{
				base.AddParameter(VideoSceneAccess.getVideoSceneAccess (23101), locationId);
			}
			while (3 == 0);
			if (false)
			{
				goto IL_93;
			}
			base.ExecuteNonQuery(VideoSceneAccess.getVideoSceneAccess (59071));
			IL_71:
			string result = string.Empty;
			if (base.GetOutParameterValue(VideoSceneAccess.getVideoSceneAccess (59017)) == DBNull.Value)
			{
				return result;
			}
			IL_93:
			if (-1 == 0)
			{
				goto IL_71;
			}
			result = (string)base.GetOutParameterValue(VideoSceneAccess.getVideoSceneAccess (59017));
			return result;
		}

		public bool UpdateSceneGraphicProfile(int sceneID, int configID)
		{
			base.DBParameters.Clear();
			do
			{
				if (2 != 0)
				{
					string expr_A5 = VideoSceneAccess.getVideoSceneAccess(58061);
					object expr_2B = sceneID;
					if (!false)
					{
						base.AddParameter(expr_A5, expr_2B);
					}
					base.AddParameter(VideoSceneAccess.getVideoSceneAccess (59104), configID);
				}
				if (Convert.ToInt32(base.ExecuteNonQuery(VideoSceneAccess.getVideoSceneAccess (59125))) <= 0)
				{
					goto IL_7D;
				}
			}
			while (false);
			int arg_79_0 = 1;
			IL_79:
			int arg_7E_0;
			int expr_79 = arg_7E_0 = arg_79_0;
			if (expr_79 != 0)
			{
				return expr_79 != 0;
			}
			goto IL_7E;
			IL_7D:
			arg_7E_0 = 0;
			IL_7E:
			int expr_7E = arg_79_0 = arg_7E_0;
			if (expr_7E != 0)
			{
				goto IL_79;
			}
			arg_79_0 = expr_7E;
			if (expr_7E == 0)
			{
				return expr_7E != 0;
			}
			goto IL_79;
		}

		public bool CheckProfileName(string name)
		{
            bool rtr=false;
			base.DBParameters.Clear();
            string expr_66 = VideoSceneAccess.getVideoSceneAccess(59166);
			if (!false)
			{
				base.AddParameter(expr_66, name);
			}
			int arg_46_0;
			int arg_3A_0;
			int arg_43_0;
			if (!false)
			{
				arg_43_0 = (arg_3A_0 = (arg_46_0 = Convert.ToInt32(base.ExecuteScalar(VideoSceneAccess.getVideoSceneAccess (59191)))));
				goto IL_37;
			}
			goto IL_3B;
			int expr_46;
			do
			{
				IL_3C:
				if (4 != 0)
				{
					if (false)
					{
						goto IL_37;
					}
					if (arg_43_0 <= 0)
					{
						return false;
					}
					arg_46_0 = 1;
				}
				expr_46 = (arg_3A_0 = (arg_43_0 = (arg_46_0)));
			}
			while (expr_46 == 0);
			return expr_46 != 0;
			IL_37:
            //if (7 == 0)
            //{
            //    goto IL_3C;
            //}
			int num = arg_3A_0;
			IL_3B:
			arg_43_0 = (arg_3A_0 = (arg_46_0 = num));
			//goto IL_3C;
            return rtr;
		}

        static VideoSceneAccess()
        {
            // Note: this type is marked as 'beforefieldinit'.
        
            SmartAssembly.HouseOfCards.Strings.CreateGetStringDelegate(typeof(VideoSceneAccess));
        }
	}
}
