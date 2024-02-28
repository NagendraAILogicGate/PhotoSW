using System;
using System.Collections.Generic;

namespace PhotoSW.IMIX.Model
{
	public class VideoScene
	{
		public int SceneId
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string ScenePath
		{
			get;
			set;
		}

		public int LocationId
		{
			get;
			set;
		}

		public string Settings
		{
			get;
			set;
		}

		public int VideoLength
		{
			get;
			set;
		}

		public bool IsActive
		{
			get;
			set;
		}

		public bool IsActiveForAdvanceProcessing
		{
			get;
			set;
		}

		public string IsActiveForAdvanceProcessingStatus
		{
			get;
			set;
		}

		public string LocationName
		{
			get;
			set;
		}

		public bool IsMixerScene
		{
			get;
			set;
		}

		public int CG_ConfigID
		{
			get;
			set;
		}

		public List<VideoSceneObject> lstVideoSceneObject
		{
			get;
			set;
		}
	}
}
