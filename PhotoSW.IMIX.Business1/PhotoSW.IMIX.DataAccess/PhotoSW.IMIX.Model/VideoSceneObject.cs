using System;

namespace PhotoSW.IMIX.Model
{
	public class VideoSceneObject
	{
		public int VideoObject_Pkey
		{
			get;
			set;
		}

		public string VideoObjectId
		{
			get;
			set;
		}

		public int SceneId
		{
			get;
			set;
		}

		public bool GuestVideoObject
		{
			get;
			set;
		}

        public VideoObjectFileMapping ObjectFileMapping
        {
            get;
            set;
        }

		public bool streamAudioEnabled
		{
			get;
			set;
		}

		public string FileName
		{
			get;
			set;
		}
	}
}
