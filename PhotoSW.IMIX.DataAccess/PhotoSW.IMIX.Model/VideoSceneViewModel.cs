using System;
using System.Collections.Generic;

namespace PhotoSW.IMIX.Model
{
	public class VideoSceneViewModel
	{
		public VideoScene VideoScene
		{
			get;
			set;
		}

		public VideoSceneObject VideoSceneObject
		{
			get;
			set;
		}

		public List<VideoSceneObject> ListVideoSceneObject
		{
			get;
			set;
		}

        public List<VideoObjectFileMapping> ListVideoObjectFileMapping
        {
            get;
            set;
        }

        public VideoObjectFileMapping VideoObjectFileMapping
        {
            get;
            set;
        }
	}
}
