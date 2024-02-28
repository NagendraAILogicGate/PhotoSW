using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhotoSW.IMIX.Model
{
    public class VideoObjectFileMapping
    {
        public int ID
        {
            get;
            set;
        }

        public string VideoSceneObjectId
        {
            get;
            set;
        }

        public int ValueTypeId
        {
            get;
            set;
        }

        public string ChromaPath
        {
            get;
            set;
        }

        public string RoutePath
        {
            get;
            set;
        }

        public string StreamAudioEnabled
        {
            get;
            set;
        }

        public string ResourcePath
        {
            get;
            set;
        }
    }
}
