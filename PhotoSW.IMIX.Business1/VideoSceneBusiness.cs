using DigiPhoto.IMIX.DataAccess;
using DigiPhoto.IMIX.Model;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DigiPhoto.IMIX.Business
{
	public class VideoSceneBusiness : BaseBusiness
	{
		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public VideoSceneBusiness ;

			public string ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...SaveVideoSceneObject(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<VideoSceneObject> ;

			public VideoSceneBusiness ;

			public VideoSceneObject ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...GetVideoSceneObjects(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public VideoSceneBusiness ;

			public VideoSceneViewModel ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...SaveVideoScene(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public VideoSceneBusiness ;

			public VideoSceneViewModel ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...SaveMixerScene(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<VideoScene> ;

			public VideoSceneBusiness ;

			public int ;

			public int? ;

			public void ()
			{
				do
				{
					this.. = new VideoSceneAccess(this..Transaction);
				}
				while (false);
				this. = this...GetVideoScene(this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public VideoSceneBusiness ;

			public int? ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...DeleteVideoSceneDetails(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public VideoSceneViewModel ;

			public VideoSceneBusiness ;

			public int? ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...GetVideoSceneToEdit(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public VideoSceneViewModel ;

			public VideoSceneBusiness ;

			public int? ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...GetVideoSceneEditToResource(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<VideoScene> ;

			public VideoSceneBusiness ;

			public int ;

			public int ;

			public void ()
			{
				do
				{
					this.. = new VideoSceneAccess(this..Transaction);
				}
				while (false);
				this. = this...GetVideoSceneByCriteria(this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<VideoSceneObject> ;

			public VideoSceneBusiness ;

			public int ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...GuestVideoObjectBySceneID(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public VideoObjectFileMapping ;

			public VideoSceneBusiness ;

			public int ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...GetobjectVideoDetails(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public List<Watchersetting> ;

			public VideoSceneBusiness ;

			public int ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...GetSettingWatcher(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public VideoSceneBusiness ;

			public int ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...checkIsActiveForAdvance(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public string ;

			public VideoSceneBusiness ;

			public int ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...checkIsActiveForVideoProcessing(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public VideoSceneBusiness ;

			public int ;

			public int ;

			public void ()
			{
				do
				{
					this.. = new VideoSceneAccess(this..Transaction);
				}
				while (false);
				this. = this...UpdateSceneGraphicProfile(this., this.);
			}
		}

		[CompilerGenerated]
		private sealed class 
		{
			public bool ;

			public VideoSceneBusiness ;

			public string ;

			public void ()
			{
				if (-1 == 0)
				{
					goto IL_39;
				}
				this.. = new VideoSceneAccess(this..Transaction);
				IL_1A:
				if (!false)
				{
					this. = this...CheckProfileName(this.);
				}
				IL_39:
				if (!false && true)
				{
					return;
				}
				goto IL_1A;
			}
		}

		private VideoSceneAccess ;

		public bool SaveVideoSceneObject(string VideoObjectIds)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = VideoObjectIds;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public List<VideoSceneObject> GetVideoSceneObjects(VideoSceneObject videoSceneObject)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = videoSceneObject;
			. = this;
			. = new List<VideoSceneObject>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool SaveVideoScene(VideoSceneViewModel VideoScene)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = VideoScene;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public bool SaveMixerScene(VideoSceneViewModel VideoScene)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = VideoScene;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}

		public List<VideoScene> GetVideoScene(int sceneId, int? substoreId = 0)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			if (!false)
			{
				. = sceneId;
				if (!false)
				{
					. = substoreId;
				}
			}
			do
			{
				if (-1 != 0)
				{
					. = this;
				}
				if (8 == 0)
				{
					goto IL_55;
				}
				. = new List<VideoScene>();
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_55:
			base.Start(false);
			return .;
		}

		public string DeleteVideoSceneDetails(int? Sceneid)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = Sceneid;
			. = this;
			. = string.Empty;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public VideoSceneViewModel GetVideoSceneToEdit(int? Sceneid)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = Sceneid;
			. = this;
			. = new VideoSceneViewModel();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public VideoSceneViewModel GetVideoSceneEditToResource(int? Sceneid)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = Sceneid;
			. = this;
			. = new VideoSceneViewModel();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<VideoScene> GetVideoSceneByCriteria(int locationId, int sceneId)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			if (!false)
			{
				. = locationId;
				if (!false)
				{
					. = sceneId;
				}
			}
			do
			{
				if (-1 != 0)
				{
					. = this;
				}
				if (8 == 0)
				{
					goto IL_55;
				}
				. = new List<VideoScene>();
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_55:
			base.Start(false);
			return .;
		}

		public List<VideoSceneObject> GuestVideoObjectBySceneID(int sceneId)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = sceneId;
			. = this;
			. = new List<VideoSceneObject>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public VideoObjectFileMapping GetobjectVideoDetails(int vidobjectId)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = vidobjectId;
			. = this;
			. = new VideoObjectFileMapping();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public List<Watchersetting> GetSettingWatcher(int LocationId)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = LocationId;
			. = this;
			. = new List<Watchersetting>();
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public string checkIsActiveForAdvance(int locationId)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = locationId;
			. = this;
			. = string.Empty;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public string checkIsActiveForVideoProcessing(int locationId)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = locationId;
			. = this;
			. = string.Empty;
			this.operation = new BaseBusiness.TransactionMethod(.);
			base.Start(false);
			return .;
		}

		public bool UpdateSceneGraphicProfile(int sceneID, int configID)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			if (!false)
			{
				. = sceneID;
				if (!false)
				{
					. = configID;
				}
			}
			do
			{
				if (-1 != 0)
				{
					. = this;
				}
				if (8 == 0)
				{
					goto IL_4B;
				}
				. = false;
			}
			while (false);
			this.operation = new BaseBusiness.TransactionMethod(.);
			IL_4B:
			base.Start(false);
			return .;
		}

		public bool CheckProfileName(string name)
		{
			VideoSceneBusiness.  = new VideoSceneBusiness.();
			. = name;
			. = this;
			. = false;
			this.operation = new BaseBusiness.TransactionMethod(.);
			bool arg_46_0 = base.Start(false);
			do
			{
				if (5 != 0)
				{
					arg_46_0 = .;
				}
			}
			while (2 == 0);
			return arg_46_0;
		}
	}
}
