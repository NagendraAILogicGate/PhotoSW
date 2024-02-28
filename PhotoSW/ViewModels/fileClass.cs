using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace PhotoSW.ViewModels
{
    public class fileClass
	{
		public string fileName
		{
			get;
			set;
		}

		public int ID
		{
			get;
			set;
		}

		public string filePath
		{
			get;
			set;
		}

		public BitmapImage imgThumbnail
		{
			get;
			set;
		}
	}
}

